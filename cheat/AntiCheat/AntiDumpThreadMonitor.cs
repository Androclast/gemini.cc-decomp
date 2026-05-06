using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using AntiDumpToolMonitor;
using SecurityPaths;

namespace AntiDumpThreadMonitor;

public sealed class AntiDumpThreadMonitor
{
	private struct PROCESS_BASIC_INFORMATION
	{
	}

	private static bool bool_0;

	private static CancellationTokenSource cancellationTokenSource_0;

	private static DateTime dateTime_0 = DateTime.UtcNow;

	private static int int_0;

	private static readonly object object_0 = new object();

	private int int_1;

	private byte byte_1;

	private string string_0;

	private int Int32_0
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	private byte Byte_0
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = value;
		}
	}

	private string String_0
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	[DllImport("ntdll.dll", SetLastError = true)]
	private static extern int NtSetInformationThread(nint threadHandle, int threadInformationClass, nint threadInformation, int threadInformationLength);

	[DllImport("kernel32.dll")]
	private static extern nint GetCurrentThread();

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool SetThreadPriority(nint hThread, int nPriority);

	[DllImport("kernel32.dll")]
	private static extern uint GetCurrentThreadId();

	[DllImport("ntdll.dll")]
	private static extern int NtQueryInformationProcess(nint processHandle, int processInformationClass, ref PROCESS_BASIC_INFORMATION processInformation, int processInformationLength, out int returnLength);

	[DllImport("kernel32.dll")]
	private static extern nint GetCurrentProcess();

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool IsDebuggerPresent();

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool CheckRemoteDebuggerPresent(nint hProcess, ref bool isDebuggerPresent);

	public static void Initialize()
	{
		if (!bool_0)
		{
			bool_0 = true;
			cancellationTokenSource_0 = new CancellationTokenSource();
			HideThreadFromDebugger();
			SetCriticalThreadPriority();
			Task.Run(() => SuspendDetectionLoop(cancellationTokenSource_0.Token), cancellationTokenSource_0.Token);
			Task.Run(() => AntiDumpLoop(cancellationTokenSource_0.Token), cancellationTokenSource_0.Token);
			Task.Run(() => MemoryIntegrityLoop(cancellationTokenSource_0.Token), cancellationTokenSource_0.Token);
			Console.WriteLine("[AntiFreezeProtection] Initialized");
		}
	}

	public static void Shutdown()
	{
		if (bool_0)
		{
			bool_0 = false;
			cancellationTokenSource_0?.Cancel();
			cancellationTokenSource_0?.Dispose();
			cancellationTokenSource_0 = null;
			Console.WriteLine("[AntiFreezeProtection] Shutdown");
		}
	}

	private static void HideThreadFromDebugger()
	{
		try
		{
			NtSetInformationThread(GetCurrentThread(), 17, IntPtr.Zero, 0);
		}
		catch (Exception ex)
		{
			Console.WriteLine("[AntiFreezeProtection] Failed to hide thread: " + ex.Message);
		}
	}

	private static void SetCriticalThreadPriority()
	{
		try
		{
			SetThreadPriority(GetCurrentThread(), 15);
		}
		catch (Exception ex)
		{
			Console.WriteLine("[AntiFreezeProtection] Failed to set priority: " + ex.Message);
		}
	}

	private static async Task SuspendDetectionLoop(CancellationToken ct)
	{
		while (!ct.IsCancellationRequested)
		{
			try
			{
				DateTime utcNow = DateTime.UtcNow;
				TimeSpan suspendDuration = utcNow - dateTime_0;
				if (!(suspendDuration.TotalMilliseconds <= 2000.0))
				{
					int_0++;
					OnSuspendDetected(suspendDuration);
				}
				dateTime_0 = utcNow;
				await Task.Delay(500, ct);
			}
			catch (TaskCanceledException)
			{
				break;
			}
			catch (Exception ex2)
			{
				Console.WriteLine("[AntiFreezeProtection] Suspend detection error: " + ex2.Message);
			}
		}
	}

	private static void OnSuspendDetected(TimeSpan suspendDuration)
	{
		Console.WriteLine($"[AntiFreezeProtection] ⚠\ufe0f SUSPEND DETECTED! Duration: {suspendDuration.TotalMilliseconds}ms, Count: {int_0}");
		if (IsBeingDumped())
		{
			Console.WriteLine("[AntiFreezeProtection] \ud83d\udea8 DUMP ATTEMPT DETECTED!");
			OnDumpAttemptDetected();
		}
		if (int_0 > 20)
		{
			Console.WriteLine("[AntiFreezeProtection] \ud83d\udea8 MULTIPLE SUSPENDS DETECTED - POSSIBLE ATTACK!");
			OnAttackDetected("Multiple process suspensions");
		}
	}

	private static async Task AntiDumpLoop(CancellationToken ct)
	{
		while (!ct.IsCancellationRequested)
		{
			try
			{
				if (IsDebuggerPresent())
				{
					Console.WriteLine("[AntiFreezeProtection] \ud83d\udea8 DEBUGGER DETECTED!");
					OnAttackDetected("Debugger present");
				}
				bool isDebuggerPresent = false;
				CheckRemoteDebuggerPresent(GetCurrentProcess(), ref isDebuggerPresent);
				if (isDebuggerPresent)
				{
					Console.WriteLine("[AntiFreezeProtection] \ud83d\udea8 REMOTE DEBUGGER DETECTED!");
					OnAttackDetected("Remote debugger present");
				}
				if (IsBeingDumped())
				{
					Console.WriteLine("[AntiFreezeProtection] \ud83d\udea8 DUMP ATTEMPT DETECTED!");
					OnDumpAttemptDetected();
				}
				await Task.Delay(3000, ct);
			}
			catch (TaskCanceledException)
			{
				break;
			}
			catch (Exception ex2)
			{
				Console.WriteLine("[AntiFreezeProtection] Anti-dump error: " + ex2.Message);
			}
		}
	}

	private static bool IsBeingDumped()
	{
		try
		{
			if (Process.GetCurrentProcess().HandleCount <= 2000)
			{
				return CheckSuspiciousHandles();
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private static bool CheckSuspiciousHandles()
	{
		try
		{
			string[] array = new string[24]
			{
				"services", "svchost", "system", "smss", "csrss", "wininit", "winlogon", "lsass", "explorer", "dwm",
				"taskhostw", "searchindexer", "runtimebroker", "applicationframehost", "sihost", "fontdrvhost", "conhost", "dllhost", "msiexec", "trustedinstaller",
				"tiworker", "wuauclt", "searchprotocolhost", "searchfilterhost"
			};
			string[] array2 = new string[20]
			{
				"processhacker", "processhacker2", "procexp", "procexp64", "x64dbg", "x32dbg", "ollydbg", "windbg", "ida", "ida64",
				"idaq", "idaq64", "cheatengine", "cheatengine-x86_64", "procdump", "procdump64", "extremedumper", "megadumper", "ksdumper", "jitdumper"
			};
			Process[] processes = Process.GetProcesses();
			foreach (Process process in processes)
			{
				try
				{
					string text = process.ProcessName.ToLower();
					bool flag = false;
					string[] array3 = array;
					foreach (string value in array3)
					{
						if (text.Equals(value, StringComparison.OrdinalIgnoreCase))
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						continue;
					}
					array3 = array2;
					foreach (string value2 in array3)
					{
						if (text.Equals(value2, StringComparison.OrdinalIgnoreCase))
						{
							Console.WriteLine("[AntiFreezeProtection] Suspicious process detected: " + process.ProcessName);
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
		catch
		{
			return false;
		}
	}

	private static async Task MemoryIntegrityLoop(CancellationToken ct)
	{
		int criticalDataHash = GetCriticalDataHash();
		while (!ct.IsCancellationRequested)
		{
			try
			{
				int criticalDataHash2 = GetCriticalDataHash();
				if (criticalDataHash2 != criticalDataHash)
				{
					Console.WriteLine("[AntiFreezeProtection] \ud83d\udea8 MEMORY TAMPERING DETECTED!");
					OnAttackDetected("Memory tampering");
					criticalDataHash = criticalDataHash2;
				}
				await Task.Delay(5000, ct);
			}
			catch (TaskCanceledException)
			{
				break;
			}
			catch (Exception ex2)
			{
				Console.WriteLine("[AntiFreezeProtection] Memory integrity error: " + ex2.Message);
			}
		}
	}

	private static int GetCriticalDataHash()
	{
		try
		{
			return 0 ^ typeof(AntiDumpThreadMonitor).GetHashCode() ^ typeof(AntiDumpToolMonitor).GetHashCode() ^ typeof(SecurityPaths).GetHashCode();
		}
		catch
		{
			return 0;
		}
	}

	private static void OnDumpAttemptDetected()
	{
		lock (object_0)
		{
			try
			{
				ReportSecurityEvent("dump_attempt");
				ActivateCountermeasures();
			}
			catch (Exception ex)
			{
				Console.WriteLine("[AntiFreezeProtection] Dump handler error: " + ex.Message);
			}
		}
	}

	private static void OnAttackDetected(string attackType)
	{
		lock (object_0)
		{
			try
			{
				Console.WriteLine("[AntiFreezeProtection] \ud83d\udea8 ATTACK DETECTED: " + attackType);
				ReportSecurityEvent("attack_" + attackType);
				ActivateCountermeasures();
			}
			catch (Exception ex)
			{
				Console.WriteLine("[AntiFreezeProtection] Attack handler error: " + ex.Message);
			}
		}
	}

	private static void ActivateCountermeasures()
	{
		try
		{
			ClearSensitiveData();
			AntiDumpToolMonitor.StartMonitoring();
		}
		catch (Exception ex)
		{
			Console.WriteLine("[AntiFreezeProtection] Countermeasures error: " + ex.Message);
		}
	}

	private static void ClearSensitiveData()
	{
		try
		{
			GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, blocking: true, compacting: true);
			GC.WaitForPendingFinalizers();
			GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, blocking: true, compacting: true);
		}
		catch (Exception ex)
		{
			Console.WriteLine("[AntiFreezeProtection] Clear data error: " + ex.Message);
		}
	}

	private static void ReportSecurityEvent(string eventType)
	{
		try
		{
			Console.WriteLine("[AntiFreezeProtection] Security event reported: " + eventType);
		}
		catch (Exception ex)
		{
			Console.WriteLine("[AntiFreezeProtection] Report error: " + ex.Message);
		}
	}

	public static string GetStatistics()
	{
		return $"Suspend detections: {int_0}, Running: {bool_0}";
	}
}
