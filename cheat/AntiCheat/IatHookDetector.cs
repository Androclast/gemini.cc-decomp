using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace IatHookDetector;

public sealed class IatHookDetector
{
	private double double_0;

	private char char_0;

	private char char_1;

	private bool bool_0;

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

	private char Char_1
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
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
	private static extern nint GetModuleHandle(string lpModuleName);

	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
	private static extern nint GetProcAddress(nint hModule, string lpProcName);

	public static void Initialize()
	{
		CheckIATModifications();
		CheckInlineHooks();
	}

	public static bool CheckIATModifications()
	{
		try
		{
			string[] array = new string[6] { "LoadLibraryA", "LoadLibraryW", "GetProcAddress", "VirtualProtect", "VirtualAlloc", "CreateThread" };
			foreach (string text in array)
			{
				if (CheckInlineHook("kernel32.dll", text))
				{
					Logger.Fatal("[IATChecker] Inline hook detected on " + text);
					return true;
				}
			}
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public static bool CheckInlineHooks()
	{
		try
		{
			Logger.Info("[IATChecker] Checking inline hooks...");
			string[] array = new string[8] { "LoadLibraryA", "LoadLibraryW", "GetProcAddress", "VirtualProtect", "VirtualAlloc", "CreateThread", "CreateProcessA", "CreateProcessW" };
			foreach (string text in array)
			{
				if (CheckInlineHook("kernel32.dll", text))
				{
					Logger.Fatal("[IATChecker] Inline hook detected on kernel32." + text);
					return true;
				}
			}
			array = new string[5] { "NtQueryInformationProcess", "NtSetInformationThread", "NtCreateThread", "NtAllocateVirtualMemory", "NtProtectVirtualMemory" };
			int i = 0;
			string text2;
			while (true)
			{
				if (i >= array.Length)
				{
					return false;
				}
				text2 = array[i];
				if (CheckInlineHook("ntdll.dll", text2))
				{
					break;
				}
				i++;
			}
			Logger.Fatal("[IATChecker] Inline hook detected on ntdll." + text2);
			return true;
		}
		catch (Exception ex)
		{
			Logger.Warn("[IATChecker] CheckInlineHooks failed: " + ex.Message);
			return false;
		}
	}

	private static bool CheckInlineHook(string moduleName, string functionName)
	{
		try
		{
			nint moduleHandle = GetModuleHandle(moduleName);
			if (moduleHandle == IntPtr.Zero)
			{
				return false;
			}
			nint procAddress = GetProcAddress(moduleHandle, functionName);
			if (procAddress != IntPtr.Zero)
			{
				byte[] array = new byte[16];
				Marshal.Copy(procAddress, array, 0, 16);
				if (array[0] == 233)
				{
					int num = BitConverter.ToInt32(array, 1);
					if (!IsAddressInModule(IntPtr.Add(procAddress, num + 5), moduleHandle))
					{
						Logger.Warn("[IATChecker] JMP hook detected on " + functionName + " (target outside module)");
						return true;
					}
				}
				if (array[0] != 232)
				{
					if (array[0] != 204)
					{
						if (array[0] != 72 || array[1] != 184 || array[10] != byte.MaxValue || array[11] != 224)
						{
							if (array[0] != 104 || array[5] != 195)
							{
								return false;
							}
							Logger.Warn("[IATChecker] PUSH+RET hook detected on " + functionName);
							return true;
						}
						Logger.Warn("[IATChecker] x64 trampoline hook detected on " + functionName);
						return true;
					}
					Logger.Warn("[IATChecker] INT3 breakpoint detected on " + functionName);
					return true;
				}
				Logger.Warn("[IATChecker] CALL hook detected on " + functionName);
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			Logger.Warn("[IATChecker] CheckInlineHook failed for " + functionName + ": " + ex.Message);
			return false;
		}
	}

	private static bool IsAddressInModule(nint address, nint moduleHandle)
	{
		try
		{
			foreach (ProcessModule module in Process.GetCurrentProcess().Modules)
			{
				if (module.BaseAddress == moduleHandle)
				{
					long num = ((IntPtr)module.BaseAddress).ToInt64();
					long num2 = num + module.ModuleMemorySize;
					long num3 = ((IntPtr)address).ToInt64();
					return num3 >= num && num3 < num2;
				}
			}
			return false;
		}
		catch
		{
			return true;
		}
	}

	private string method_5(long long_2)
	{
		return "Хитролох_иди_нахуй.___8____3___5";
	}
}
