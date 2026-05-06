using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using HardwareDetectionResult;

namespace HardwareEnvironmentDetector;

public sealed class HardwareEnvironmentDetector
{
	private struct MEMORYSTATUSEX
	{
		public uint lkXoRs0FiB;

		public ulong yxPovSQLlW;
	}

	private static bool bool_0;

	[CompilerGenerated]
	private static Action<HardwareDetectionResult> action_0;

	private char char_1;

	private string string_1;

	private long long_2;

	private float float_0;

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

	private string String_0
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	private long Int64_0
	{
		get
		{
			return long_2;
		}
		set
		{
			long_2 = value;
		}
	}

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

	public static event Action<HardwareDetectionResult> Event_0
	{
		[CompilerGenerated]
		add
		{
			Action<HardwareDetectionResult> action = action_0;
			Action<HardwareDetectionResult> action2;
			do
			{
				action2 = action;
				Action<HardwareDetectionResult> value2 = (Action<HardwareDetectionResult>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<HardwareDetectionResult> action = action_0;
			Action<HardwareDetectionResult> action2;
			do
			{
				action2 = action;
				Action<HardwareDetectionResult> value2 = (Action<HardwareDetectionResult>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool GlobalMemoryStatusEx(ref MEMORYSTATUSEX lpBuffer);

	public static void Initialize()
	{
		if (bool_0)
		{
			return;
		}
		try
		{
			Logger.Info("[AdvancedAntiVM] Initializing advanced anti-VM detection...");
			bool_0 = true;
			Logger.Info("[AdvancedAntiVM] Advanced anti-VM detection initialized successfully");
		}
		catch (Exception)
		{
		}
	}

	public static HardwareDetectionResult PerformExtendedCheck()
	{
		HardwareDetectionResult gClass = new HardwareDetectionResult();
		try
		{
			Logger.Info("[AdvancedAntiVM] Performing extended VM detection...");
			gClass.CPUCountSuspicious = CheckCPUCount();
			gClass.RAMSizeSuspicious = CheckRAMSize();
			gClass.DiskSizeSuspicious = CheckDiskSize();
			gClass.AVXSupported = CheckAVXSupport();
			gClass.RDRANDSupported = CheckRDRANDSupport();
			gClass.ACPITablesDetected = CheckACPITables();
			gClass.SandboxDetected = CheckSandboxIndicators();
			gClass.WineDetected = CheckWineEnvironment();
			gClass.KVMDetected = CheckKVMSignatures();
			gClass.QemuDetected = CheckQemuSignatures();
			gClass.IsVMDetected = gClass.CPUCountSuspicious || gClass.RAMSizeSuspicious || gClass.DiskSizeSuspicious || !gClass.AVXSupported || !gClass.RDRANDSupported || gClass.ACPITablesDetected || gClass.SandboxDetected || gClass.WineDetected || gClass.KVMDetected || gClass.QemuDetected;
			if (gClass.IsVMDetected)
			{
				Logger.Warn("[AdvancedAntiVM] VM/Sandbox detected: " + gClass.GetDetectionSummary());
				action_0?.Invoke(gClass);
			}
			else
			{
				Logger.Info("[AdvancedAntiVM] No VM/Sandbox detected");
			}
			return gClass;
		}
		catch (Exception)
		{
			return gClass;
		}
	}

	public static bool CheckCPUCount()
	{
		try
		{
			int processorCount = Environment.ProcessorCount;
			bool num = processorCount < 2;
			if (num)
			{
				Logger.Warn($"[AdvancedAntiVM] Suspicious CPU count: {processorCount}");
			}
			return num;
		}
		catch
		{
			return false;
		}
	}

	public static bool CheckRAMSize()
	{
		try
		{
			MEMORYSTATUSEX lpBuffer = new MEMORYSTATUSEX
			{
				lkXoRs0FiB = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX))
			};
			if (!GlobalMemoryStatusEx(ref lpBuffer))
			{
				return false;
			}
			ulong num = lpBuffer.yxPovSQLlW / 1073741824;
			bool num2 = num < 4;
			if (num2)
			{
				Logger.Warn($"[AdvancedAntiVM] Suspicious RAM size: {num}GB");
			}
			return num2;
		}
		catch
		{
			return false;
		}
	}

	public static bool CheckDiskSize()
	{
		try
		{
			long num = new DriveInfo(Path.GetPathRoot(Environment.SystemDirectory)).TotalSize / 1073741824;
			bool num2 = num < 80;
			if (num2)
			{
				Logger.Warn($"[AdvancedAntiVM] Suspicious disk size: {num}GB");
			}
			return num2;
		}
		catch
		{
			return false;
		}
	}

	public static bool CheckAVXSupport()
	{
		try
		{
			CPUID(1, 0, out var _, out var _, out var ecx, out var _);
			bool num = (ecx & 0x10000000) != 0;
			if (!num)
			{
				Logger.Warn("[AdvancedAntiVM] AVX instructions not supported (VM indicator)");
			}
			return num;
		}
		catch
		{
			return true;
		}
	}

	public static bool CheckRDRANDSupport()
	{
		try
		{
			CPUID(1, 0, out var _, out var _, out var ecx, out var _);
			bool num = (ecx & 0x40000000) != 0;
			if (!num)
			{
				Logger.Warn("[AdvancedAntiVM] RDRAND instruction not supported (VM indicator)");
			}
			return num;
		}
		catch
		{
			return true;
		}
	}

	public static bool CheckACPITables()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			ManagementObjectSearcher val = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS");
			try
			{
				ManagementObjectEnumerator enumerator = val.Get().GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						ManagementObject val2 = (ManagementObject)enumerator.Current;
						object obj = ((ManagementBaseObject)val2)["Version"];
						object obj2;
						if (obj == null)
						{
							obj2 = null;
						}
						else
						{
							string? text = obj.ToString();
							if (text == null)
							{
								obj2 = null;
							}
							else
							{
								obj2 = text.ToLower();
								if (obj2 != null)
								{
									goto IL_0046;
								}
							}
						}
						obj2 = "";
						goto IL_0046;
						IL_0046:
						string text2 = (string)obj2;
						object obj3 = ((ManagementBaseObject)val2)["Manufacturer"];
						object obj4;
						object obj5;
						if (obj3 != null)
						{
							string? text3 = obj3.ToString();
							if (text3 != null)
							{
								obj4 = text3.ToLower() ?? "";
								goto IL_0070;
							}
							obj5 = null;
						}
						else
						{
							obj5 = null;
						}
						obj4 = "";
						goto IL_0070;
						IL_0070:
						string text4 = (string)obj4;
						string[] array = new string[7] { "vbox", "vmware", "qemu", "bochs", "xen", "kvm", "parallels" };
						foreach (string text5 in array)
						{
							if (text2.Contains(text5) || text4.Contains(text5))
							{
								Logger.Warn("[AdvancedAntiVM] VM signature in BIOS: " + text5);
								return true;
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			return false;
		}
		catch
		{
			return false;
		}
	}

	public static bool CheckSandboxIndicators()
	{
		try
		{
			string[] array = new string[8] { "any.run", "agent", "tria_agent", "cuckoo", "analyzer", "cuckoomon", "vmtoolsd", "vboxservice" };
			Process[] processes = Process.GetProcesses();
			string[] array2;
			for (int i = 0; i < processes.Length; i++)
			{
				string text = processes[i].ProcessName.ToLower();
				array2 = array;
				foreach (string value in array2)
				{
					if (text.Contains(value))
					{
						Logger.Warn("[AdvancedAntiVM] Sandbox process detected: " + text);
						return true;
					}
				}
			}
			array2 = new string[4] { "C:\\analysis", "C:\\cuckoo", "C:\\hybridanalysis", "C:\\sandbox" };
			foreach (string text2 in array2)
			{
				if (Directory.Exists(text2))
				{
					Logger.Warn("[AdvancedAntiVM] Sandbox directory detected: " + text2);
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

	public static bool CheckWineEnvironment()
	{
		try
		{
			if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WINEPREFIX")))
			{
				Logger.Warn("[AdvancedAntiVM] Wine environment detected (WINEPREFIX)");
				return true;
			}
			return false;
		}
		catch
		{
			return false;
		}
	}

	public static bool CheckKVMSignatures()
	{
		try
		{
			CPUID(1073741824, 0, out var _, out var ebx, out var ecx, out var edx);
			if (!GetCPUIDString(ebx, ecx, edx).Contains("KVM"))
			{
				return false;
			}
			Logger.Warn("[AdvancedAntiVM] KVM hypervisor detected");
			return true;
		}
		catch
		{
			return false;
		}
	}

	public static bool CheckQemuSignatures()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			ManagementObjectSearcher val = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
			try
			{
				ManagementObjectEnumerator enumerator = val.Get().GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						ManagementObject val2 = (ManagementObject)enumerator.Current;
						object obj = ((ManagementBaseObject)val2)["Model"];
						object obj2;
						if (obj != null)
						{
							string? text = obj.ToString();
							if (text == null)
							{
								obj2 = null;
							}
							else
							{
								obj2 = text.ToLower();
								if (obj2 != null)
								{
									goto IL_004b;
								}
							}
						}
						else
						{
							obj2 = null;
						}
						obj2 = "";
						goto IL_004b;
						IL_004b:
						string text2 = (string)obj2;
						object obj3 = ((ManagementBaseObject)val2)["Manufacturer"];
						object obj4;
						if (obj3 == null)
						{
							obj4 = null;
						}
						else
						{
							string? text3 = obj3.ToString();
							if (text3 != null)
							{
								obj4 = text3.ToLower();
								if (obj4 != null)
								{
									goto IL_0061;
								}
							}
							else
							{
								obj4 = null;
							}
						}
						obj4 = "";
						goto IL_0061;
						IL_0061:
						string text4 = (string)obj4;
						if (text2.Contains("qemu") || text4.Contains("qemu") || text2.Contains("bochs") || text4.Contains("bochs"))
						{
							Logger.Warn("[AdvancedAntiVM] QEMU/Bochs detected");
							return true;
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			return false;
		}
		catch
		{
			return false;
		}
	}

	private static void CPUID(int function, int subfunction, out int eax, out int ebx, out int ecx, out int edx)
	{
		try
		{
			_ = new int[4];
			eax = 0;
			ebx = 0;
			ecx = 0;
			edx = 0;
		}
		catch
		{
			eax = 0;
			ebx = 0;
			ecx = 0;
			edx = 0;
		}
	}

	private static string GetCPUIDString(int ebx, int ecx, int edx)
	{
		byte[] array = new byte[12];
		Array.Copy(BitConverter.GetBytes(ebx), 0, array, 0, 4);
		Array.Copy(BitConverter.GetBytes(edx), 0, array, 4, 4);
		Array.Copy(BitConverter.GetBytes(ecx), 0, array, 8, 4);
		return Encoding.ASCII.GetString(array);
	}
}
