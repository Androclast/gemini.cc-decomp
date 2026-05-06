using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace ManagedDebuggerDetector;

public sealed class ManagedDebuggerDetector
{
	private struct PROCESS_BASIC_INFORMATION
	{
		public nint Sq5oGQH4a0;
	}

	private static bool bool_0;

	[CompilerGenerated]
	private static Action<string> action_0;

	private float float_0;

	private char char_1;

	private long long_0;

	private float float_1;

	private float Single_0
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

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

	private long Int64_0
	{
		get
		{
			return long_0;
		}
		set
		{
			long_0 = value;
		}
	}

	private float Single_1
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
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

	[DllImport("ntdll.dll", SetLastError = true)]
	private static extern int NtSetInformationThread(nint threadHandle, int threadInformationClass, nint threadInformation, int threadInformationLength);

	[DllImport("ntdll.dll", SetLastError = true)]
	private static extern int NtQueryInformationProcess(nint processHandle, int processInformationClass, out PROCESS_BASIC_INFORMATION processInformation, int processInformationLength, out int returnLength);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern nint OpenThread(int dwDesiredAccess, bool bInheritHandle, int dwThreadId);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool CloseHandle(nint hObject);

	public static void Initialize()
	{
		if (bool_0)
		{
			return;
		}
		try
		{
			Logger.Info("[ManagedDebuggerDetector] Initializing managed debugger detection...");
			if (CheckManagedDebugger())
			{
				Logger.Fatal("[ManagedDebuggerDetector] Managed debugger detected via Debugger.IsAttached!");
				action_0?.Invoke("Debugger.IsAttached");
				Environment.Exit(1);
			}
			if (CheckDebuggerThreads())
			{
				Logger.Fatal("[ManagedDebuggerDetector] Debugger threads detected!");
				action_0?.Invoke("DebuggerThreads");
				Environment.Exit(1);
			}
			if (CheckParentProcess())
			{
				Logger.Fatal("[ManagedDebuggerDetector] .NET debugger parent process detected!");
				action_0?.Invoke("ParentProcess");
				Environment.Exit(1);
			}
			HideFromDebugger();
			bool_0 = true;
			Logger.Info("[ManagedDebuggerDetector] Managed debugger detection initialized successfully");
		}
		catch (Exception ex)
		{
			Logger.Error("[ManagedDebuggerDetector] Initialization error: " + ex.Message);
		}
	}

	public static bool CheckManagedDebugger()
	{
		try
		{
			if (!Debugger.IsAttached)
			{
				try
				{
					PropertyInfo property = typeof(Debugger).GetProperty("IsAttached", BindingFlags.Static | BindingFlags.Public);
					if (property != null && (bool)property.GetValue(null))
					{
						Logger.Fatal("[ManagedDebuggerDetector] Debugger.IsAttached via reflection is true");
						return true;
					}
				}
				catch (Exception ex)
				{
					Logger.Warn("[ManagedDebuggerDetector] Reflection check failed: " + ex.Message);
				}
				return false;
			}
			Logger.Fatal("[ManagedDebuggerDetector] Debugger.IsAttached is true");
			return true;
		}
		catch (Exception ex2)
		{
			Logger.Warn("[ManagedDebuggerDetector] CheckManagedDebugger failed: " + ex2.Message);
			return false;
		}
	}

	public static bool CheckDebuggerThreads()
	{
		try
		{
			Process currentProcess = Process.GetCurrentProcess();
			foreach (ProcessThread thread in currentProcess.Threads)
			{
				_ = thread;
			}
			int count = currentProcess.Threads.Count;
			if (count > 20)
			{
				Logger.Warn($"[ManagedDebuggerDetector] Suspicious thread count: {count}");
			}
			return false;
		}
		catch (Exception ex)
		{
			Logger.Warn("[ManagedDebuggerDetector] CheckDebuggerThreads failed: " + ex.Message);
			return false;
		}
	}

	public static bool HideFromDebugger()
	{
		try
		{
			foreach (ProcessThread thread in Process.GetCurrentProcess().Threads)
			{
				try
				{
					nint num = OpenThread(2032639, bInheritHandle: false, thread.Id);
					if (num != IntPtr.Zero)
					{
						int num2 = NtSetInformationThread(num, 17, IntPtr.Zero, 0);
						if (num2 != 0)
						{
							Logger.Warn($"[ManagedDebuggerDetector] Failed to hide thread {thread.Id}: 0x{num2:X}");
						}
						else
						{
							Logger.Info($"[ManagedDebuggerDetector] Thread {thread.Id} hidden from debugger");
						}
						CloseHandle(num);
					}
				}
				catch (Exception ex)
				{
					Logger.Warn($"[ManagedDebuggerDetector] Failed to hide thread {thread.Id}: {ex.Message}");
				}
			}
			Logger.Info("[ManagedDebuggerDetector] All threads hidden from debugger");
			return true;
		}
		catch (Exception ex2)
		{
			Logger.Error("[ManagedDebuggerDetector] HideFromDebugger failed: " + ex2.Message);
			return false;
		}
	}

	private static bool CheckParentProcess()
	{
		try
		{
			if (NtQueryInformationProcess(Process.GetCurrentProcess().Handle, 0, out var processInformation, Marshal.SizeOf(typeof(PROCESS_BASIC_INFORMATION)), out var _) == 0)
			{
				int processId = ((IntPtr)processInformation.Sq5oGQH4a0).ToInt32();
				try
				{
					string text = Process.GetProcessById(processId).ProcessName.ToLower();
					string[] array = new string[10] { "dnspy", "ilspy", "dotpeek", "rider", "rider64", "devenv", "vshost", "vsjitdebugger", "jetbrains.rider", "jetbrains.dotpeek" };
					foreach (string value in array)
					{
						if (text.Contains(value))
						{
							Logger.Fatal("[ManagedDebuggerDetector] .NET debugger parent process detected: " + text);
							return true;
						}
					}
				}
				catch
				{
				}
				return false;
			}
			return false;
		}
		catch (Exception ex)
		{
			Logger.Warn("[ManagedDebuggerDetector] CheckParentProcess failed: " + ex.Message);
			return false;
		}
	}

	private string method_7(string string_0, float float_2)
	{
		return "Хитролох_иди_нахуй.__279__8__3_______0____";
	}
}
