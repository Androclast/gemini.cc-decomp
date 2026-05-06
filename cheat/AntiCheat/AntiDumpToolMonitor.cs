using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using TelemetryHttpClient;
using HwidProvider;
using LicenseStorage;

namespace AntiDumpToolMonitor;

public sealed class AntiDumpToolMonitor
{
	private struct PROCESS_BASIC_INFORMATION
	{
		public nint KkqevMCwsX;
	}

	private static Thread? thread_0;

	private static volatile bool bool_0;

	private static readonly object object_0 = new object();

	private static bool bool_1 = false;

	private static int int_0 = 0;

	private static readonly string[] string_0 = new string[56]
	{
		"processhacker", "procexp", "procexp64", "x64dbg", "x32dbg", "ida", "ida64", "ida32", "ollydbg", "ollyice",
		"windbg", "windbgx", "immunity", "immunitydebugger", "cheatengine-x86_64", "cheatengine", "cheat engine", "megadumper", "extremedumper", "procdump",
		"procdump64", "dnspy", "ilspy", "dotpeek", "reflector", "de4dot", "codecracker", "simpleassemblyexplorer", "scylla", "scylla_x64",
		"scylla_x86", "hollows_hunter", "pe-sieve", "pesieve", "pestudio", "memoryze", "volatility", "injector", "dllinjector", "extremeinjector",
		"xenos", "ghidra", "radare2", "r2", "hopper", "binary ninja", "binaryninja", "relyze", "apimonitor", "procmon",
		"procmon64", "wireshark", "fiddler", "justdecompile", "jetbrains.dotpeek", "redgate.reflector"
	};

	private static readonly string[] string_1 = new string[18]
	{
		"Process Hacker", "Process Explorer", "x64dbg", "x32dbg", "Cheat Engine", "IDA", "OllyDbg", "WinDbg", "Scylla", "MegaDumper",
		"ExtremeDumper", "dnSpy", "ILSpy", "dotPeek", ".NET Reflector", "de4dot", "PE-sieve", "Hollows Hunter"
	};

	private byte byte_0;

	private char char_2;

	private bool bool_2;

	private double double_1;

	private byte Byte_0
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	private char Char_0
	{
		get
		{
			return char_2;
		}
		set
		{
			char_2 = value;
		}
	}

	private bool Boolean_0
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	private double Double_0
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	[DllImport("user32.dll", SetLastError = true)]
	private static extern nint FindWindow(string? lpClassName, string lpWindowName);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool IsDebuggerPresent();

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool CheckRemoteDebuggerPresent(nint hProcess, ref bool isDebuggerPresent);

	[DllImport("ntdll.dll", SetLastError = true)]
	private static extern int NtQueryInformationProcess(nint processHandle, int processInformationClass, ref PROCESS_BASIC_INFORMATION processInformation, int processInformationLength, out int returnLength);

	[DllImport("kernel32.dll")]
	private static extern nint GetModuleHandle(string lpModuleName);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool VirtualProtect(nint lpAddress, nuint dwSize, uint flNewProtect, out uint lpflOldProtect);

	[DllImport("kernel32.dll")]
	private static extern nint GetCurrentProcess();

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern nint OpenProcess(uint processAccess, bool bInheritHandle, int processId);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool TerminateProcess(nint hProcess, uint uExitCode);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool CloseHandle(nint hObject);

	public static void StartMonitoring()
	{
		lock (object_0)
		{
			if (!bool_1)
			{
				bool_1 = true;
				Logger.Info("[AntiDump] \ud83d\udd0d Starting continuous monitoring...");
				Process process = PerformCheck();
				if (process == null)
				{
					bool_0 = true;
					thread_0 = new Thread(MonitorLoop)
					{
						IsBackground = true,
						Name = "AntiDump Monitor",
						Priority = ThreadPriority.Highest
					};
					thread_0.Start();
					Logger.Info("[AntiDump] ✅ Continuous monitoring started");
				}
				else
				{
					OnDumpToolDetected("Dump tool detected during initialization", process);
				}
			}
		}
	}

	public static void StopMonitoring()
	{
		lock (object_0)
		{
			if (bool_0)
			{
				bool_0 = false;
				thread_0?.Join(1000);
				Logger.Info("[AntiDump] Monitoring stopped");
			}
		}
	}

	private static void MonitorLoop()
	{
		Logger.Info("[AntiDump] \ud83d\udd04 Monitor thread started - scanning every 10 seconds");
		while (bool_0)
		{
			try
			{
				int_0++;
				bool flag = int_0 % 10 == 0;
				Process process = DetectDumpToolProcesses();
				if (process == null)
				{
					if (!DetectDumpToolWindows())
					{
						if (DetectDebugger())
						{
							OnDumpToolDetected("Debugger detected");
							break;
						}
						if (!DetectCLRProfiler())
						{
							if (flag)
							{
								Thread.Sleep(2000);
							}
							continue;
						}
						OnDumpToolDetected("CLR Profiler detected (Extreme Dumper technique)");
					}
					else
					{
						Process dumperProcess = TryFindProcessByWindow();
						OnDumpToolDetected("Dump tool window detected", dumperProcess);
					}
				}
				else
				{
					OnDumpToolDetected("Dump tool process detected: " + process.ProcessName, process);
				}
			}
			catch (Exception ex)
			{
				Logger.Warn("[AntiDump] ⚠\ufe0f Error in monitor loop: " + ex.Message);
				Thread.Sleep(10000);
				continue;
			}
			break;
		}
		Logger.Info("[AntiDump] Monitor thread stopped");
	}

	private static Process? DetectDumpToolProcesses()
	{
		try
		{
			Process[] processes = Process.GetProcesses();
			foreach (Process process in processes)
			{
				try
				{
					string text = process.ProcessName.ToLowerInvariant();
					string[] array = string_0;
					foreach (string value in array)
					{
						if (text.Contains(value))
						{
							Logger.Fatal($"[AntiDump] ❌ DETECTED: {process.ProcessName} (PID: {process.Id}) matches '{value}'");
							return process;
						}
					}
				}
				catch
				{
				}
			}
			return null;
		}
		catch (Exception)
		{
			return null;
		}
	}

	private static bool DetectDumpToolWindows()
	{
		try
		{
			string[] array = string_1;
			int num = 0;
			string text;
			while (true)
			{
				if (num < array.Length)
				{
					text = array[num];
					if (FindWindow(null, text) != IntPtr.Zero)
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			Logger.Fatal("[AntiDump] ❌ Detected dump tool window: " + text);
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	private static void OnDumpToolDetected(string reason, Process? dumperProcess = null)
	{
		Logger.Fatal("[AntiDump] ❌❌❌ DUMP TOOL DETECTED: " + reason);
		Task.Run(async delegate
		{
			try
			{
				BootstrapHooks.SendSecurityScreenshot(reason);
				string orCreateHWID = HwidProvider.GetOrCreateHWID();
				string text = LicenseStorage.LoadLicense();
				if (!string.IsNullOrEmpty(orCreateHWID) && !string.IsNullOrEmpty(text))
				{
					var data = new
					{
						reason = reason,
						processName = dumperProcess?.ProcessName,
						processId = dumperProcess?.Id,
						timestamp = DateTime.UtcNow
					};
					await TelemetryHttpClient.SendTelemetryAsync(orCreateHWID, text, "dump_tool_detected", data);
					Logger.Info("[AntiDump] Security event sent to server");
				}
			}
			catch (Exception)
			{
			}
		});
		if (dumperProcess != null)
		{
			try
			{
				Logger.Fatal($"[AntiDump] \ud83d\udd2a Attempting to terminate dumper process: {dumperProcess.ProcessName} (PID: {dumperProcess.Id})");
				try
				{
					dumperProcess.Kill();
					dumperProcess.WaitForExit(1000);
					Logger.Fatal("[AntiDump] ✅ Successfully terminated dumper process!");
				}
				catch
				{
					nint num = OpenProcess(1u, bInheritHandle: false, dumperProcess.Id);
					if (num != IntPtr.Zero)
					{
						TerminateProcess(num, 1u);
						CloseHandle(num);
						Logger.Fatal("[AntiDump] ✅ Forcefully terminated dumper process!");
					}
				}
			}
			catch (Exception ex)
			{
				Logger.Warn("[AntiDump] Failed to terminate dumper: " + ex.Message);
			}
		}
		Logger.Fatal("[AntiDump] \ud83d\uded1 Terminating game for security...");
		try
		{
			TerminateProcess(GetCurrentProcess(), 1u);
		}
		catch
		{
			Environment.Exit(1);
		}
	}

	private static bool DetectDebugger()
	{
		try
		{
			if (IsDebuggerPresent())
			{
				Logger.Fatal("[AntiDump] ❌ Debugger detected (IsDebuggerPresent)");
				return true;
			}
			bool isDebuggerPresent = false;
			CheckRemoteDebuggerPresent(GetCurrentProcess(), ref isDebuggerPresent);
			if (isDebuggerPresent)
			{
				Logger.Fatal("[AntiDump] ❌ Debugger detected (CheckRemoteDebuggerPresent)");
				return true;
			}
			PROCESS_BASIC_INFORMATION processInformation = default(PROCESS_BASIC_INFORMATION);
			if (NtQueryInformationProcess(GetCurrentProcess(), 7, ref processInformation, Marshal.SizeOf(processInformation), out var _) != 0 || processInformation.KkqevMCwsX == IntPtr.Zero)
			{
				return false;
			}
			Logger.Fatal("[AntiDump] ❌ Debugger detected (NtQueryInformationProcess)");
			return true;
		}
		catch (Exception ex)
		{
			Logger.Warn("[AntiDump] Error detecting debugger: " + ex.Message);
			return false;
		}
	}

	private static bool DetectCLRProfiler()
	{
		try
		{
			string environmentVariable = Environment.GetEnvironmentVariable("COR_ENABLE_PROFILING");
			if (string.IsNullOrEmpty(environmentVariable) || !(environmentVariable == "1"))
			{
				string environmentVariable2 = Environment.GetEnvironmentVariable("COR_PROFILER");
				if (!string.IsNullOrEmpty(environmentVariable2))
				{
					Logger.Fatal("[AntiDump] ❌ CLR Profiler CLSID detected: " + environmentVariable2 + " - EXTREME DUMPER!");
					return true;
				}
				if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("COMPLUS_ProfAPI_ProfilerCompatibilitySetting")))
				{
					Logger.Fatal("[AntiDump] ❌ COMPLUS ProfAPI detected - EXTREME DUMPER!");
					return true;
				}
				return false;
			}
			Logger.Fatal("[AntiDump] ❌ CLR Profiler detected (COR_ENABLE_PROFILING=1) - EXTREME DUMPER!");
			return true;
		}
		catch (Exception ex)
		{
			Logger.Warn("[AntiDump] Error detecting CLR profiler: " + ex.Message);
			return false;
		}
	}

	private static void ErasePEHeaders()
	{
		try
		{
			nint baseAddress = Process.GetCurrentProcess().MainModule.BaseAddress;
			if (VirtualProtect(baseAddress, 2u, 4u, out var lpflOldProtect))
			{
				Marshal.Copy(new byte[2], 0, baseAddress, 2);
				VirtualProtect(baseAddress, 2u, lpflOldProtect, out var _);
			}
		}
		catch (Exception)
		{
		}
	}

	public static Process? PerformCheck()
	{
		Process process = DetectDumpToolProcesses();
		if (process == null)
		{
			if (!DetectDumpToolWindows())
			{
				if (!DetectDebugger())
				{
					DetectCLRProfiler();
					return null;
				}
				return null;
			}
			return TryFindProcessByWindow();
		}
		return process;
	}

	private static Process? TryFindProcessByWindow()
	{
		try
		{
			Process[] processes = Process.GetProcesses();
			foreach (Process process in processes)
			{
				try
				{
					if (process.MainWindowHandle != IntPtr.Zero)
					{
						string dDbeP0GIY6 = process.MainWindowTitle;
						if (string_1.Any((string tool) => dDbeP0GIY6.Contains(tool)))
						{
							return process;
						}
					}
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
		return null;
	}
}
