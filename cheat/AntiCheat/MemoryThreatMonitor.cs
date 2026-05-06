using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using TelemetryHttpClient;
using HwidProvider;
using LicenseStorage;

namespace MemoryThreatMonitor;

public sealed class MemoryThreatMonitor
{
	private static bool bool_0 = false;

	private static CancellationTokenSource cancellationTokenSource_0;

	private static readonly HashSet<int> hashSet_0 = new HashSet<int>();

	private static readonly object object_0 = new object();

	private bool bool_1;

	private int int_0;

	private bool Boolean_0
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	private int Int32_0
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern nint OpenProcess(uint processAccess, bool bInheritHandle, int processId);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool CloseHandle(nint hObject);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool ReadProcessMemory(nint hProcess, nint lpBaseAddress, byte[] lpBuffer, int dwSize, out int lpNumberOfBytesRead);

	[DllImport("ntdll.dll")]
	private static extern int NtQuerySystemInformation(int SystemInformationClass, nint SystemInformation, int SystemInformationLength, out int ReturnLength);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool VirtualProtect(nint lpAddress, nuint dwSize, uint flNewProtect, out uint lpflOldProtect);

	[DllImport("kernel32.dll")]
	private static extern nint GetCurrentProcess();

	public static void Initialize()
	{
		lock (object_0)
		{
			if (!bool_0)
			{
				Logger.Info("[AdvancedMemoryProtection] Initializing advanced memory protection...");
				hashSet_0.Add(Process.GetCurrentProcess().Id);
				StartMonitoring();
				Logger.Info("[AdvancedMemoryProtection] ✅ Advanced memory protection active");
			}
			else
			{
				Logger.Warn("[AdvancedMemoryProtection] Already initialized");
			}
		}
	}

	private static void StartMonitoring()
	{
		bool_0 = true;
		cancellationTokenSource_0 = new CancellationTokenSource();
		Task.Run(() => MonitoringLoop(cancellationTokenSource_0.Token), cancellationTokenSource_0.Token);
		Logger.Info("[AdvancedMemoryProtection] Monitoring started");
	}

	public static void StopMonitoring()
	{
		lock (object_0)
		{
			if (bool_0)
			{
				bool_0 = false;
				cancellationTokenSource_0?.Cancel();
				Logger.Info("[AdvancedMemoryProtection] Monitoring stopped");
			}
		}
	}

	private static async Task MonitoringLoop(CancellationToken cancellationToken)
	{
		int scanCount = 0;
		while (!cancellationToken.IsCancellationRequested && bool_0)
		{
			try
			{
				scanCount++;
				bool flag = scanCount % 20 == 0;
				if (flag)
				{
					Logger.Info($"[AdvancedMemoryProtection] Scan #{scanCount} - Checking for external memory access...");
				}
				if (!DetectSuspiciousHandles())
				{
					if (!DetectDumperProcesses())
					{
						if (scanCount % 5 != 0 || !DetectMemoryModification())
						{
							if (flag)
							{
								Logger.Info($"[AdvancedMemoryProtection] ✅ Scan #{scanCount} complete - No threats detected");
							}
							await Task.Delay(10000, cancellationToken);
							continue;
						}
						Logger.Fatal("[AdvancedMemoryProtection] ❌ Critical memory modification detected!");
						OnMemoryThreatDetected("Critical memory section modified");
					}
					else
					{
						Logger.Fatal("[AdvancedMemoryProtection] ❌ Known dumper process detected!");
						OnMemoryThreatDetected("Known dumper process running");
					}
				}
				else
				{
					Logger.Fatal("[AdvancedMemoryProtection] ❌ Suspicious process handle detected!");
					OnMemoryThreatDetected("Suspicious process handle to our memory");
				}
			}
			catch (OperationCanceledException)
			{
			}
			catch (Exception ex2)
			{
				Logger.Warn("[AdvancedMemoryProtection] Error in monitoring loop: " + ex2.Message);
				await Task.Delay(10000, cancellationToken);
				continue;
			}
			break;
		}
		Logger.Info("[AdvancedMemoryProtection] Monitoring loop stopped");
	}

	private static bool DetectSuspiciousHandles()
	{
		try
		{
			int id = Process.GetCurrentProcess().Id;
			Process[] processes = Process.GetProcesses();
			foreach (Process process in processes)
			{
				try
				{
					if (process.Id == id || IsKnownSafeProcess(process))
					{
						continue;
					}
					nint num = OpenProcess(16u, bInheritHandle: false, id);
					if (num != IntPtr.Zero)
					{
						CloseHandle(num);
						if (IsSuspiciousProcess(process))
						{
							Logger.Fatal($"[AdvancedMemoryProtection] Suspicious process has handle to our memory: {process.ProcessName} (PID: {process.Id})");
							return true;
						}
					}
				}
				catch
				{
				}
			}
			return false;
		}
		catch (Exception ex)
		{
			Logger.Warn("[AdvancedMemoryProtection] DetectSuspiciousHandles error: " + ex.Message);
			return false;
		}
	}

	private static bool IsKnownSafeProcess(Process process)
	{
		try
		{
			string text = process.ProcessName.ToLowerInvariant();
			string[] array = new string[31]
			{
				"system", "idle", "registry", "smss", "csrss", "wininit", "services", "lsass", "svchost", "explorer",
				"dwm", "taskmgr", "conhost", "fontdrvhost", "winlogon", "spoolsv", "searchindexer", "runtimebroker", "applicationframehost", "shellexperiencehost",
				"startmenuexperiencehost", "searchapp", "textinputhost", "securityhealthservice", "msmpeng", "nissrv", "mssense", "audiodg", "wudfhost", "dashost",
				"sihost"
			};
			int num = 0;
			while (true)
			{
				if (num >= array.Length)
				{
					return false;
				}
				string value = array[num];
				if (text.Contains(value))
				{
					break;
				}
				num++;
			}
			return true;
		}
		catch
		{
			return true;
		}
	}

	private static bool IsSuspiciousProcess(Process process)
	{
		try
		{
			string text = process.ProcessName.ToLowerInvariant();
			string[] array = new string[20]
			{
				"dump", "extreme", "megadumper", "procdump", "processhacker", "cheatengine", "x64dbg", "x32dbg", "ollydbg", "windbg",
				"ida", "ghidra", "dnspy", "ilspy", "dotpeek", "reflector", "scylla", "hollows_hunter", "pe-sieve", "memoryze"
			};
			foreach (string value in array)
			{
				if (text.Contains(value))
				{
					return true;
				}
			}
			return false;
		}
		catch
		{
			return false;
		}
	}

	private static bool DetectDumperProcesses()
	{
		try
		{
			Process[] processes = Process.GetProcesses();
			foreach (Process process in processes)
			{
				try
				{
					if (!IsSuspiciousProcess(process))
					{
						continue;
					}
					Logger.Fatal($"[AdvancedMemoryProtection] Known dumper process detected: {process.ProcessName} (PID: {process.Id})");
					return true;
				}
				catch
				{
				}
			}
			return false;
		}
		catch (Exception ex)
		{
			Logger.Warn("[AdvancedMemoryProtection] DetectDumperProcesses error: " + ex.Message);
			return false;
		}
	}

	private static bool DetectMemoryModification()
	{
		try
		{
			return false;
		}
		catch (Exception ex)
		{
			Logger.Warn("[AdvancedMemoryProtection] DetectMemoryModification error: " + ex.Message);
			return false;
		}
	}

	private static void OnMemoryThreatDetected(string reason)
	{
		Logger.Fatal("[AdvancedMemoryProtection] ❌❌❌ MEMORY THREAT DETECTED: " + reason);
		Task.Run(async delegate
		{
			try
			{
				string orCreateHWID = HwidProvider.GetOrCreateHWID();
				string text = LicenseStorage.LoadLicense();
				if (!string.IsNullOrEmpty(orCreateHWID) && !string.IsNullOrEmpty(text))
				{
					var data = new
					{
						reason = reason,
						timestamp = DateTime.UtcNow
					};
					await TelemetryHttpClient.SendTelemetryAsync(orCreateHWID, text, "memory_threat_detected", data);
					Logger.Info("[AdvancedMemoryProtection] Security event sent to server");
				}
			}
			catch (Exception ex)
			{
				Logger.Warn("[AdvancedMemoryProtection] Failed to send telemetry: " + ex.Message);
			}
		});
		Logger.Fatal("[AdvancedMemoryProtection] \ud83d\uded1 Terminating for security...");
		Environment.Exit(1);
	}

	private string method_4(bool bool_2)
	{
		return "Хитролох_иди_нахуй.____0___5_4__7";
	}
}
