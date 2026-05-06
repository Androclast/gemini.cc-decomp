using System;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace KernelDebuggerDetector;

public sealed class KernelDebuggerDetector
{
	private char char_1;

	private bool bool_0;

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
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	[DllImport("ntdll.dll")]
	private static extern int NtQuerySystemInformation(int SystemInformationClass, nint SystemInformation, int SystemInformationLength, out int ReturnLength);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern uint GetFirmwareEnvironmentVariable(string lpName, string lpGuid, nint pBuffer, uint nSize);

	public static void Initialize()
	{
		Logger.Info("[SystemIntegrityChecker] Initializing system integrity checks");
		PerformAllChecks();
	}

	public static void PerformAllChecks()
	{
		CheckTestSigning();
		CheckKernelDebugging();
		CheckSecureBoot();
		CheckVBS();
		CheckMemoryIntegrity();
		CheckWindowsDefender();
	}

	public static bool CheckUnsignedDrivers()
	{
		try
		{
			using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Services"))
			{
				if (registryKey != null)
				{
					string[] subKeyNames = registryKey.GetSubKeyNames();
					foreach (string text in subKeyNames)
					{
						using RegistryKey registryKey2 = registryKey.OpenSubKey(text);
						if (registryKey2 != null)
						{
							object value = registryKey2.GetValue("Type");
							if (value != null && (int)value == 1 && !string.IsNullOrEmpty(registryKey2.GetValue("ImagePath") as string))
							{
								Logger.Warn("[SystemIntegrityChecker] Kernel driver detected: " + text);
							}
						}
					}
				}
			}
			return false;
		}
		catch (Exception ex)
		{
			Logger.Warn("[SystemIntegrityChecker] CheckUnsignedDrivers failed: " + ex.Message);
			return false;
		}
	}

	public static bool CheckTestSigning()
	{
		try
		{
			using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\CI\\Policy"))
			{
				if (registryKey != null)
				{
					object value = registryKey.GetValue("TestSigning");
					if (value != null && (int)value == 1)
					{
						Logger.Warn("[SystemIntegrityChecker] Test-signing mode is ENABLED - system allows unsigned drivers");
						return true;
					}
				}
			}
			using (RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey("BCD00000000"))
			{
				if (registryKey2 != null)
				{
					Logger.Warn("[SystemIntegrityChecker] BCD test-signing check detected potential configuration");
				}
			}
			Logger.Info("[SystemIntegrityChecker] Test-signing mode is disabled");
			return false;
		}
		catch (Exception ex)
		{
			Logger.Warn("[SystemIntegrityChecker] CheckTestSigning failed: " + ex.Message);
			return false;
		}
	}

	public static bool CheckKernelDebugging()
	{
		try
		{
			nint num = Marshal.AllocHGlobal(8);
			try
			{
				if (NtQuerySystemInformation(35, num, 8, out var _) == 0)
				{
					byte num2 = Marshal.ReadByte(num);
					byte b = Marshal.ReadByte(num, 1);
					if (num2 != 0 || b == 0)
					{
						Logger.Warn("[SystemIntegrityChecker] Kernel debugging is ENABLED");
						return true;
					}
				}
				Logger.Info("[SystemIntegrityChecker] Kernel debugging is disabled");
				return false;
			}
			finally
			{
				Marshal.FreeHGlobal(num);
			}
		}
		catch (Exception ex)
		{
			Logger.Warn("[SystemIntegrityChecker] CheckKernelDebugging failed: " + ex.Message);
			return false;
		}
	}

	public static bool CheckSecureBoot()
	{
		try
		{
			nint num = Marshal.AllocHGlobal(1);
			try
			{
				if (GetFirmwareEnvironmentVariable("SecureBoot", "{8be4df61-93ca-11d2-aa0d-00e098032b8c}", num, 1u) != 0)
				{
					if (Marshal.ReadByte(num) != 0)
					{
						Logger.Info("[SystemIntegrityChecker] Secure Boot is enabled");
						return true;
					}
					Logger.Warn("[SystemIntegrityChecker] Secure Boot is DISABLED");
					return false;
				}
			}
			finally
			{
				Marshal.FreeHGlobal(num);
			}
			using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\SecureBoot\\State"))
			{
				if (registryKey != null)
				{
					object value = registryKey.GetValue("UEFISecureBootEnabled");
					if (value != null && (int)value == 0)
					{
						Logger.Warn("[SystemIntegrityChecker] Secure Boot is DISABLED (registry check)");
						return false;
					}
				}
			}
			return false;
		}
		catch (Exception ex)
		{
			Logger.Warn("[SystemIntegrityChecker] CheckSecureBoot failed: " + ex.Message);
			return false;
		}
	}

	public static bool CheckVBS()
	{
		try
		{
			using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\DeviceGuard"))
			{
				if (registryKey != null)
				{
					object value = registryKey.GetValue("EnableVirtualizationBasedSecurity");
					if (value != null && (int)value == 0)
					{
						Logger.Warn("[SystemIntegrityChecker] VBS (Virtualization Based Security) is DISABLED");
						return false;
					}
					if (value != null && (int)value == 1)
					{
						Logger.Info("[SystemIntegrityChecker] VBS is enabled");
						return true;
					}
				}
			}
			Logger.Warn("[SystemIntegrityChecker] VBS status unknown");
			return false;
		}
		catch (Exception ex)
		{
			Logger.Warn("[SystemIntegrityChecker] CheckVBS failed: " + ex.Message);
			return false;
		}
	}

	public static bool CheckMemoryIntegrity()
	{
		try
		{
			using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\DeviceGuard\\Scenarios\\HypervisorEnforcedCodeIntegrity"))
			{
				if (registryKey != null)
				{
					object value = registryKey.GetValue("Enabled");
					if (value != null && (int)value == 0)
					{
						Logger.Warn("[SystemIntegrityChecker] Memory Integrity (HVCI) is DISABLED");
						return false;
					}
					if (value != null && (int)value == 1)
					{
						Logger.Info("[SystemIntegrityChecker] Memory Integrity (HVCI) is enabled");
						return true;
					}
				}
			}
			Logger.Warn("[SystemIntegrityChecker] Memory Integrity status unknown");
			return false;
		}
		catch (Exception ex)
		{
			Logger.Warn("[SystemIntegrityChecker] CheckMemoryIntegrity failed: " + ex.Message);
			return false;
		}
	}

	public static bool CheckWindowsDefender()
	{
		try
		{
			using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows Defender"))
			{
				if (registryKey != null)
				{
					object value = registryKey.GetValue("DisableAntiSpyware");
					if (value != null && (int)value == 1)
					{
						Logger.Warn("[SystemIntegrityChecker] Windows Defender is DISABLED");
						return false;
					}
				}
			}
			using (RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows Defender\\Real-Time Protection"))
			{
				if (registryKey2 != null)
				{
					object value2 = registryKey2.GetValue("DisableRealtimeMonitoring");
					if (value2 != null && (int)value2 == 1)
					{
						Logger.Warn("[SystemIntegrityChecker] Windows Defender Real-Time Protection is DISABLED");
						return false;
					}
				}
			}
			Logger.Info("[SystemIntegrityChecker] Windows Defender appears to be enabled");
			return true;
		}
		catch (Exception ex)
		{
			Logger.Warn("[SystemIntegrityChecker] CheckWindowsDefender failed: " + ex.Message);
			return false;
		}
	}
}
