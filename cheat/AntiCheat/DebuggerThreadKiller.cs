using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace DebuggerThreadKiller;

public sealed class DebuggerThreadKiller
{
	private static bool bool_0;

	[CompilerGenerated]
	private static Action action_0;

	private double double_0;

	private char char_0;

	private int int_1;

	private bool bool_1;

	private double Double_0
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	private char Char_0
	{
		get
		{
			return char_0;
		}
		set
		{
			char_0 = value;
		}
	}

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

	public static event Action Event_0
	{
		[CompilerGenerated]
		add
		{
			Action action = action_0;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = action_0;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern nint OpenThread(int dwDesiredAccess, bool bInheritHandle, int dwThreadId);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool TerminateThread(nint hThread, uint dwExitCode);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool CloseHandle(nint hObject);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool VirtualProtect(nint lpAddress, nuint dwSize, uint flNewProtect, out uint lpflOldProtect);

	public static void Initialize()
	{
		if (bool_0)
		{
			return;
		}
		try
		{
			Logger.Info("[CLRDebuggerThreadKiller] Initializing CLR debugger thread killer...");
			if (!CheckCLRVersionCompatibility())
			{
				Logger.Warn("[CLRDebuggerThreadKiller] CLR version not supported, skipping initialization");
				return;
			}
			KillDebuggerRCThread();
			BlockIPCChannel();
			BlockRuntimeAttach();
			bool_0 = true;
			Logger.Info("[CLRDebuggerThreadKiller] CLR debugger thread killer initialized successfully");
		}
		catch (Exception ex)
		{
			Logger.Error("[CLRDebuggerThreadKiller] Initialization error: " + ex.Message);
		}
	}

	public static bool KillDebuggerRCThread()
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
						CloseHandle(num);
					}
				}
				catch
				{
				}
			}
			try
			{
				if (typeof(Thread).GetMethod("GetCurrentThread", BindingFlags.Static | BindingFlags.Public) != null)
				{
					_ = AppDomain.CurrentDomain;
					Logger.Info("[CLRDebuggerThreadKiller] Searched for DebuggerRCThread");
				}
			}
			catch (Exception ex)
			{
				Logger.Warn("[CLRDebuggerThreadKiller] Managed thread enumeration failed: " + ex.Message);
			}
			Logger.Info("[CLRDebuggerThreadKiller] No DebuggerRCThread found");
			return false;
		}
		catch (Exception ex2)
		{
			Logger.Error("[CLRDebuggerThreadKiller] KillDebuggerRCThread failed: " + ex2.Message);
			return false;
		}
	}

	public static bool BlockIPCChannel()
	{
		try
		{
			Logger.Info("[CLRDebuggerThreadKiller] Attempting to block IPC channel...");
			Logger.Info("[CLRDebuggerThreadKiller] IPC channel blocking attempted (placeholder)");
			return true;
		}
		catch (Exception ex)
		{
			Logger.Error("[CLRDebuggerThreadKiller] BlockIPCChannel failed: " + ex.Message);
			return false;
		}
	}

	public static bool BlockRuntimeAttach()
	{
		try
		{
			Logger.Info("[CLRDebuggerThreadKiller] Blocking runtime profiler attach...");
			string[] array = new string[6] { "COR_ENABLE_PROFILING", "COR_PROFILER", "COR_PROFILER_PATH", "CORECLR_ENABLE_PROFILING", "CORECLR_PROFILER", "CORECLR_PROFILER_PATH" };
			foreach (string text in array)
			{
				try
				{
					if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable(text)))
					{
						Environment.SetEnvironmentVariable(text, null);
						Logger.Info("[CLRDebuggerThreadKiller] Removed environment variable: " + text);
					}
				}
				catch (Exception ex)
				{
					Logger.Warn("[CLRDebuggerThreadKiller] Failed to remove " + text + ": " + ex.Message);
				}
			}
			Logger.Info("[CLRDebuggerThreadKiller] Runtime profiler attach blocked");
			return true;
		}
		catch (Exception ex2)
		{
			Logger.Error("[CLRDebuggerThreadKiller] BlockRuntimeAttach failed: " + ex2.Message);
			return false;
		}
	}

	private static bool CheckCLRVersionCompatibility()
	{
		try
		{
			Version version = Environment.Version;
			Logger.Info($"[CLRDebuggerThreadKiller] CLR Version: {version}");
			if (version.Major != 2)
			{
				if (version.Major == 4)
				{
					Logger.Info("[CLRDebuggerThreadKiller] CLR 4.0 detected - supported");
					return true;
				}
				if (version.Major >= 5)
				{
					Logger.Warn("[CLRDebuggerThreadKiller] .NET Core/.NET 5+ detected - limited support");
					return false;
				}
				Logger.Warn($"[CLRDebuggerThreadKiller] Unknown CLR version: {version}");
				return false;
			}
			Logger.Info("[CLRDebuggerThreadKiller] CLR 2.0 detected - supported");
			return true;
		}
		catch (Exception ex)
		{
			Logger.Error("[CLRDebuggerThreadKiller] CLR version check failed: " + ex.Message);
			return false;
		}
	}

	private static string GetCLRModuleName()
	{
		Version version = Environment.Version;
		if (version.Major == 2)
		{
			return "mscorwks.dll";
		}
		if (version.Major == 4)
		{
			return "clr.dll";
		}
		if (version.Major < 5)
		{
			return "clr.dll";
		}
		return "coreclr.dll";
	}
}
