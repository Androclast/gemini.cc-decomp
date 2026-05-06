using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace DebugApiHook;

public sealed class DebugApiHook
{
	private struct PROCESS_BASIC_INFORMATION
	{
		public nint iOqonPl83B;
	}

	private static bool bool_0;

	private static bool bool_1;

	[CompilerGenerated]
	private static Action<string> action_0;

	private byte byte_0;

	private double double_0;

	private long long_0;

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

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern void OutputDebugString(string lpOutputString);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool VirtualProtect(nint lpAddress, nuint dwSize, uint flNewProtect, out uint lpflOldProtect);

	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
	private static extern nint GetModuleHandle(string lpModuleName);

	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
	private static extern nint GetProcAddress(nint hModule, string lpProcName);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool CloseHandle(nint hObject);

	[DllImport("ntdll.dll", SetLastError = true)]
	private static extern int NtSetInformationThread(nint threadHandle, int threadInformationClass, nint threadInformation, int threadInformationLength);

	[DllImport("ntdll.dll", SetLastError = true)]
	private static extern int NtQueryInformationProcess(nint processHandle, int processInformationClass, out PROCESS_BASIC_INFORMATION processInformation, int processInformationLength, out int returnLength);

	public static void Initialize()
	{
		if (bool_0)
		{
			return;
		}
		try
		{
			Logger.Info("[AdvancedAntiDebug] Initializing advanced anti-debug protection...");
			if (CheckOutputDebugString())
			{
				Logger.Fatal("[AdvancedAntiDebug] Debugger detected via OutputDebugString!");
				action_0?.Invoke("OutputDebugString");
				Environment.Exit(1);
			}
			if (CheckCloseHandleInvalid())
			{
				Logger.Fatal("[AdvancedAntiDebug] Debugger detected via CloseHandle!");
				action_0?.Invoke("CloseHandle");
				Environment.Exit(1);
			}
			if (CheckParentProcess())
			{
				Logger.Fatal("[AdvancedAntiDebug] Debugger detected via parent process!");
				action_0?.Invoke("ParentProcess");
				Environment.Exit(1);
			}
			PatchDbgUiRemoteBreakin();
			HideThreadsFromDebugger();
			bool_0 = true;
			Logger.Info("[AdvancedAntiDebug] Advanced anti-debug protection initialized successfully");
		}
		catch (Exception)
		{
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
			Logger.Info("[AdvancedAntiDebug] Monitoring started (using ThreadPool)");
		}
	}

	public static void StopMonitoring()
	{
		bool_1 = false;
		Logger.Info("[AdvancedAntiDebug] Monitoring stopped");
	}

	private static void MonitoringLoop()
	{
		while (bool_1)
		{
			try
			{
				if (CheckOutputDebugString())
				{
					Logger.Fatal("[AdvancedAntiDebug] Debugger detected during monitoring!");
					action_0?.Invoke("OutputDebugString");
					Environment.Exit(1);
				}
				if (CheckParentProcess())
				{
					Logger.Fatal("[AdvancedAntiDebug] Debugger parent process detected!");
					action_0?.Invoke("ParentProcess");
					Environment.Exit(1);
				}
				Thread.Sleep(10000);
			}
			catch (Exception ex)
			{
				Logger.Error("[AdvancedAntiDebug] Monitoring error: " + ex.Message);
			}
		}
	}

	public static bool CheckOutputDebugString()
	{
		try
		{
			OutputDebugString("AntiDebug Test");
			Marshal.GetLastWin32Error();
			return false;
		}
		catch
		{
			return false;
		}
	}

	public static bool PatchDbgUiRemoteBreakin()
	{
		try
		{
			nint moduleHandle = GetModuleHandle("ntdll.dll");
			if (moduleHandle != IntPtr.Zero)
			{
				nint procAddress = GetProcAddress(moduleHandle, "DbgUiRemoteBreakin");
				if (procAddress != IntPtr.Zero)
				{
					if (VirtualProtect(procAddress, 1u, 64u, out var lpflOldProtect))
					{
						Marshal.WriteByte(procAddress, 195);
						VirtualProtect(procAddress, 1u, lpflOldProtect, out lpflOldProtect);
						return true;
					}
					Logger.Warn("[AdvancedAntiDebug] Failed to change memory protection");
					return false;
				}
				return false;
			}
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public static bool CheckCloseHandleInvalid()
	{
		//IL_000c: Expected I8, but got I4
		try
		{
			nint hObject = new IntPtr(-559038737L);
			try
			{
				CloseHandle(hObject);
				return false;
			}
			catch
			{
				return true;
			}
		}
		catch
		{
			return false;
		}
	}

	public static bool HideThreadsFromDebugger()
	{
		try
		{
			foreach (ProcessThread thread in Process.GetCurrentProcess().Threads)
			{
				try
				{
					nint num = OpenThread(thread.Id);
					if (num != IntPtr.Zero)
					{
						NtSetInformationThread(num, 17, IntPtr.Zero, 0);
						CloseHandle(num);
					}
				}
				catch
				{
				}
			}
			Logger.Info("[AdvancedAntiDebug] Threads hidden from debugger");
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public static bool CheckParentProcess()
	{
		try
		{
			if (NtQueryInformationProcess(Process.GetCurrentProcess().Handle, 0, out var processInformation, Marshal.SizeOf(typeof(PROCESS_BASIC_INFORMATION)), out var _) != 0)
			{
				return false;
			}
			int processId = ((IntPtr)processInformation.iOqonPl83B).ToInt32();
			try
			{
				string text = Process.GetProcessById(processId).ProcessName.ToLower();
				string[] array = new string[13]
				{
					"dnspy", "ilspy", "dotpeek", "x64dbg", "x32dbg", "ollydbg", "windbg", "ida", "devenv", "rider",
					"processhacker", "procexp", "procmon"
				};
				foreach (string value in array)
				{
					if (text.Contains(value))
					{
						Logger.Fatal("[AdvancedAntiDebug] Debugger parent process detected: " + text);
						return true;
					}
				}
			}
			catch
			{
			}
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern nint OpenThread(int dwDesiredAccess, bool bInheritHandle, int dwThreadId);

	private static nint OpenThread(int threadId)
	{
		return OpenThread(2032639, bInheritHandle: false, threadId);
	}
}
