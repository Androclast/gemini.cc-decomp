using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using AntiCheatBlacklists;

namespace DebuggerProcessKiller;

public sealed class DebuggerProcessKiller
{
	private static bool bool_0;

	private static bool bool_1;

	[CompilerGenerated]
	private static Action<string> action_0;

	private char char_1;

	private bool bool_4;

	private string string_0;

	private char char_2;

	private char Char_0
	{
		get
		{
			return char_1;
		}
		set
		{
			char_1 = value;
		}
	}

	private bool Boolean_0
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
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

	private char Char_1
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

	public static event Action<string> Event_0
	{
		[CompilerGenerated]
		add
		{
			Action<string> action = action_0;
			Action<string> action2;
			do
			{
				action2 = action;
				Action<string> value2 = (Action<string>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<string> action = action_0;
			Action<string> action2;
			do
			{
				action2 = action;
				Action<string> value2 = (Action<string>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern nint OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool TerminateProcess(nint hProcess, uint uExitCode);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool CloseHandle(nint hObject);

	[DllImport("ntdll.dll", SetLastError = true)]
	private static extern int NtTerminateProcess(nint processHandle, uint exitStatus);

	public static void Initialize()
	{
		if (!bool_0)
		{
			try
			{
				Logger.Info("[DebuggerKiller] Initializing debugger killer...");
				ScanAndKillDebuggers();
				bool_0 = true;
				Logger.Info("[DebuggerKiller] Debugger killer initialized successfully");
			}
			catch (Exception ex)
			{
				Logger.Error("[DebuggerKiller] Initialization error: " + ex.Message);
			}
		}
	}

	public static void StartMonitoring()
	{
		if (!bool_1)
		{
			bool_1 = true;
			Task.Run(delegate
			{
				MonitoringLoop();
			});
			Logger.Info("[DebuggerKiller] Monitoring started (using ThreadPool)");
		}
	}

	public static void StopMonitoring()
	{
		bool_1 = false;
		Logger.Info("[DebuggerKiller] Monitoring stopped");
	}

	private static void MonitoringLoop()
	{
		while (bool_1)
		{
			try
			{
				ScanAndKillDebuggers();
				Thread.Sleep(15000);
			}
			catch (Exception ex)
			{
				Logger.Error("[DebuggerKiller] Monitoring error: " + ex.Message);
			}
		}
	}

	private static void ScanAndKillDebuggers()
	{
		try
		{
			Process[] processes = Process.GetProcesses();
			foreach (Process process in processes)
			{
				try
				{
					string text = process.ProcessName.ToLower();
					string[] array = AntiCheatBlacklists.string_0;
					foreach (string text2 in array)
					{
						if (text.Contains(text2.Replace(" ", "")))
						{
							Logger.Warn($"[DebuggerKiller] Debugger process detected: {process.ProcessName} (PID: {process.Id})");
							if (!KillDebugger(process))
							{
								Logger.Warn("[DebuggerKiller] Failed to kill debugger: " + process.ProcessName);
								break;
							}
							Logger.Info("[DebuggerKiller] Successfully killed debugger: " + process.ProcessName);
							action_0?.Invoke(process.ProcessName);
							break;
						}
					}
				}
				catch
				{
				}
			}
		}
		catch (Exception ex)
		{
			Logger.Error("[DebuggerKiller] ScanAndKillDebuggers failed: " + ex.Message);
		}
	}

	public static bool KillDebugger(Process process)
	{
		try
		{
			try
			{
				process.Kill();
				process.WaitForExit(2000);
				if (process.HasExited)
				{
					Logger.Info("[DebuggerKiller] Killed " + process.ProcessName + " using Process.Kill()");
					return true;
				}
			}
			catch (Exception ex)
			{
				Logger.Warn("[DebuggerKiller] Process.Kill() failed for " + process.ProcessName + ": " + ex.Message);
			}
			try
			{
				nint num = OpenProcess(1, bInheritHandle: false, process.Id);
				if (num != IntPtr.Zero)
				{
					bool flag = TerminateProcess(num, 1u);
					CloseHandle(num);
					if (flag)
					{
						Thread.Sleep(500);
						process.Refresh();
						if (process.HasExited)
						{
							Logger.Info("[DebuggerKiller] Killed " + process.ProcessName + " using TerminateProcess()");
							return true;
						}
					}
				}
			}
			catch (Exception ex2)
			{
				Logger.Warn("[DebuggerKiller] TerminateProcess() failed for " + process.ProcessName + ": " + ex2.Message);
			}
			try
			{
				nint num2 = OpenProcess(2035711, bInheritHandle: false, process.Id);
				if (num2 != IntPtr.Zero)
				{
					int num3 = NtTerminateProcess(num2, 1u);
					CloseHandle(num2);
					if (num3 == 0)
					{
						Thread.Sleep(500);
						process.Refresh();
						if (process.HasExited)
						{
							Logger.Info("[DebuggerKiller] Killed " + process.ProcessName + " using NtTerminateProcess()");
							return true;
						}
					}
				}
			}
			catch (Exception ex3)
			{
				Logger.Warn("[DebuggerKiller] NtTerminateProcess() failed for " + process.ProcessName + ": " + ex3.Message);
			}
			return false;
		}
		catch (Exception ex4)
		{
			Logger.Error("[DebuggerKiller] KillDebugger failed: " + ex4.Message);
			return false;
		}
	}

	public static bool KillDebugger(string processName)
	{
		try
		{
			Process[] processesByName = Process.GetProcessesByName(processName);
			if (processesByName.Length == 0)
			{
				return false;
			}
			bool result = false;
			Process[] array = processesByName;
			for (int i = 0; i < array.Length; i++)
			{
				if (KillDebugger(array[i]))
				{
					result = true;
				}
			}
			return result;
		}
		catch (Exception ex)
		{
			Logger.Error("[DebuggerKiller] KillDebugger by name failed: " + ex.Message);
			return false;
		}
	}
}
