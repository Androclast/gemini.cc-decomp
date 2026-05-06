using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace SandboxDetector;

public sealed class SandboxDetector
{
	private char char_1;

	private int int_0;

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

	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
	private static extern nint GetModuleHandle(string lpModuleName);

	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
	private static extern nint GetProcAddress(nint hModule, string lpProcName);

	public static void Initialize()
	{
		DetectScyllaHide();
		DetectSandboxie();
		DetectCuckoo();
		DetectHybridAnalysis();
	}

	public static bool DetectScyllaHide()
	{
		try
		{
			string[] array = new string[3] { "ScyllaHide.dll", "ScyllaHideX64.dll", "ScyllaHideX86.dll" };
			int num = 0;
			string text;
			while (true)
			{
				if (num >= array.Length)
				{
					if (!CheckHookedFunction("ntdll.dll", "NtQueryInformationProcess"))
					{
						if (!CheckHookedFunction("ntdll.dll", "NtSetInformationThread"))
						{
							return false;
						}
						Logger.Fatal("[ScyllaHideDetector] NtSetInformationThread is hooked (ScyllaHide)");
						return true;
					}
					Logger.Fatal("[ScyllaHideDetector] NtQueryInformationProcess is hooked (ScyllaHide)");
					return true;
				}
				text = array[num];
				if (GetModuleHandle(text) == IntPtr.Zero)
				{
					num++;
					continue;
				}
				break;
			}
			Logger.Fatal("[ScyllaHideDetector] ScyllaHide DLL detected: " + text);
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public static bool DetectSandboxie()
	{
		try
		{
			if (GetModuleHandle("SbieDll.dll") != IntPtr.Zero)
			{
				Logger.Fatal("[ScyllaHideDetector] Sandboxie DLL detected: SbieDll.dll");
				return true;
			}
			try
			{
				RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Sandboxie");
				if (registryKey != null)
				{
					registryKey.Close();
					Logger.Fatal("[ScyllaHideDetector] Sandboxie registry key detected");
					return true;
				}
			}
			catch
			{
			}
			if (CheckHookedFunction("kernel32.dll", "CreateFileW"))
			{
				Logger.Warn("[ScyllaHideDetector] CreateFileW is hooked (possible Sandboxie)");
			}
			return false;
		}
		catch (Exception ex)
		{
			Logger.Warn("[ScyllaHideDetector] DetectSandboxie failed: " + ex.Message);
			return false;
		}
	}

	public static bool DetectCuckoo()
	{
		try
		{
			if (GetModuleHandle("cuckoomon.dll") == IntPtr.Zero)
			{
				string[] array = new string[3] { "C:\\cuckoo\\", "C:\\analysis\\", "C:\\sandbox\\" };
				foreach (string text in array)
				{
					if (Directory.Exists(text))
					{
						Logger.Fatal("[ScyllaHideDetector] Cuckoo directory detected: " + text);
						return true;
					}
				}
				array = new string[2] { "cuckoo", "analyzer" };
				foreach (string text2 in array)
				{
					if (Process.GetProcessesByName(text2).Length != 0)
					{
						Logger.Fatal("[ScyllaHideDetector] Cuckoo process detected: " + text2);
						return true;
					}
				}
				return false;
			}
			Logger.Fatal("[ScyllaHideDetector] Cuckoo DLL detected: cuckoomon.dll");
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public static bool DetectHybridAnalysis()
	{
		try
		{
			try
			{
				RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Hybrid Analysis");
				if (registryKey != null)
				{
					registryKey.Close();
					Logger.Fatal("[ScyllaHideDetector] Hybrid Analysis registry key detected");
					return true;
				}
			}
			catch
			{
			}
			string[] array = new string[2] { "C:\\analysis\\", "C:\\hybridanalysis\\" };
			foreach (string text in array)
			{
				if (Directory.Exists(text))
				{
					Logger.Fatal("[ScyllaHideDetector] Hybrid Analysis directory detected: " + text);
					return true;
				}
			}
			array = new string[2] { "agent", "analyzer" };
			for (int i = 0; i < array.Length; i++)
			{
				_ = Process.GetProcessesByName(array[i]).LongLength;
			}
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}

	private static bool CheckHookedFunction(string moduleName, string functionName)
	{
		try
		{
			nint moduleHandle = GetModuleHandle(moduleName);
			if (moduleHandle != IntPtr.Zero)
			{
				nint procAddress = GetProcAddress(moduleHandle, functionName);
				if (procAddress != IntPtr.Zero)
				{
					byte[] array = new byte[16];
					Marshal.Copy(procAddress, array, 0, 16);
					if (array[0] != 233)
					{
						if (array[0] != 232)
						{
							if (array[0] != 204)
							{
								return false;
							}
							Logger.Warn("[ScyllaHideDetector] INT3 detected at start of " + functionName);
							return true;
						}
						Logger.Warn("[ScyllaHideDetector] CALL detected at start of " + functionName);
						return true;
					}
					Logger.Warn("[ScyllaHideDetector] JMP detected at start of " + functionName);
					return true;
				}
				return false;
			}
			return false;
		}
		catch (Exception ex)
		{
			Logger.Warn("[ScyllaHideDetector] CheckHookedFunction failed for " + functionName + ": " + ex.Message);
			return false;
		}
	}

	private string method_5(bool bool_1)
	{
		return "Хитролох_иди_нахуй.______7_3_____________";
	}
}
