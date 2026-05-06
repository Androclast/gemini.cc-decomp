using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Win32;
using CpuIdHelper;

namespace VmDetector;

public class VmDetector
{
	private struct SYSTEM_INFO
	{
	}

	public class VMDetectionResult
	{
		[CompilerGenerated]
		private bool f9cMSlZAkt;

		[CompilerGenerated]
		private string[] CyAMODV4aR = Array.Empty<string>();

		[CompilerGenerated]
		private int EPUMdT6PvA;

		[CompilerGenerated]
		private bool mGAM7rlH36;

		[CompilerGenerated]
		private string? HJoM4wVFmc;

		private long long_0;

		private char char_0;

		private bool bool_1;

		private long long_1;

		public bool IsVirtualMachine
		{
			[CompilerGenerated]
			get
			{
				return f9cMSlZAkt;
			}
			[CompilerGenerated]
			set
			{
				f9cMSlZAkt = value;
			}
		}

		public string[] DetectionMethods
		{
			[CompilerGenerated]
			get
			{
				return CyAMODV4aR;
			}
			[CompilerGenerated]
			set
			{
				CyAMODV4aR = value;
			}
		}

		public int ConfidenceScore
		{
			[CompilerGenerated]
			get
			{
				return EPUMdT6PvA;
			}
			[CompilerGenerated]
			set
			{
				EPUMdT6PvA = value;
			}
		}

		public bool RequireStricterChecks
		{
			[CompilerGenerated]
			get
			{
				return mGAM7rlH36;
			}
			[CompilerGenerated]
			set
			{
				mGAM7rlH36 = value;
			}
		}

		public string? Details
		{
			[CompilerGenerated]
			get
			{
				return HJoM4wVFmc;
			}
			[CompilerGenerated]
			set
			{
				HJoM4wVFmc = value;
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

		private long Int64_1
		{
			get
			{
				return long_1;
			}
			set
			{
				long_1 = value;
			}
		}

		private string method_8(double double_0, bool bool_2, int int_1)
		{
			return "Хитролох_иди_нахуй._94_____5__________";
		}
	}

	private bool bool_1;

	private char char_0;

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

	[DllImport("kernel32.dll")]
	private static extern void GetNativeSystemInfo(ref SYSTEM_INFO lpSystemInfo);

	public static VMDetectionResult DetectVM()
	{
		List<string> list = new List<string>();
		int num = 0;
		if (DetectHypervisorCPUID())
		{
			list.Add("CPUID_Hypervisor");
			num += 30;
		}
		if (DetectVMTiming())
		{
			list.Add("Timing_Attack");
			num += 25;
		}
		if (DetectVMArtifacts())
		{
			list.Add("VM_Artifacts");
			num += 20;
		}
		if (DetectHardwareVirtualization())
		{
			list.Add("Hardware_Virtualization");
			num += 15;
		}
		if (DetectRDTSCTimeDilation())
		{
			list.Add("RDTSC_Time_Dilation");
			num += 20;
		}
		if (DetectVMMacAddress())
		{
			list.Add("VM_MAC_Address");
			num += 15;
		}
		if (DetectContainer())
		{
			list.Add("Container_Detection");
			num += 25;
		}
		bool flag = num >= 60;
		return new VMDetectionResult
		{
			IsVirtualMachine = flag,
			DetectionMethods = list.ToArray(),
			ConfidenceScore = Math.Min(num, 100),
			RequireStricterChecks = flag,
			Details = ((!flag) ? null : $"VM detected with {num}% confidence using {list.Count} methods")
		};
	}

	private static bool DetectHypervisorCPUID()
	{
		try
		{
			int[] array = new int[4];
			if (!CpuIdHelper.TryGetCPUID(1, array) || (array[2] & int.MinValue) == 0)
			{
				if (!CpuIdHelper.TryGetCPUID(1073741824, array))
				{
					return false;
				}
				return true;
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private static bool DetectVMTiming()
	{
		//IL_0006: Expected I8, but got I4
		try
		{
			long num = 0L;
			for (int i = 0; i < 100; i++)
			{
				long timestamp = Stopwatch.GetTimestamp();
				int[] result = new int[4];
				CpuIdHelper.TryGetCPUID(0, result);
				long timestamp2 = Stopwatch.GetTimestamp();
				num += timestamp2 - timestamp;
			}
			return num / 100 > 1000;
		}
		catch
		{
			return false;
		}
	}

	private static bool DetectVMArtifacts()
	{
		try
		{
			string[] array = new string[6] { "C:\\Program Files\\VMware\\VMware Tools\\", "C:\\Program Files\\Oracle\\VirtualBox Guest Additions\\", "C:\\Windows\\System32\\drivers\\vmmouse.sys", "C:\\Windows\\System32\\drivers\\vmhgfs.sys", "C:\\Windows\\System32\\drivers\\VBoxGuest.sys", "C:\\Windows\\System32\\drivers\\VBoxMouse.sys" };
			foreach (string path in array)
			{
				if (File.Exists(path) || Directory.Exists(path))
				{
					return true;
				}
			}
			array = new string[3] { "SOFTWARE\\VMware, Inc.\\VMware Tools", "SOFTWARE\\Oracle\\VirtualBox Guest Additions", "HARDWARE\\DEVICEMAP\\Scsi\\Scsi Port 0\\Scsi Bus 0\\Target Id 0\\Logical Unit Id 0\\Identifier" };
			foreach (string name in array)
			{
				try
				{
					using RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(name);
					if (registryKey != null)
					{
						return true;
					}
				}
				catch
				{
				}
			}
			try
			{
				using RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey("HARDWARE\\DEVICEMAP\\Scsi\\Scsi Port 0\\Scsi Bus 0\\Target Id 0\\Logical Unit Id 0");
				if (registryKey2 != null)
				{
					string j0JMToKyQf = registryKey2.GetValue("Identifier") as string;
					if (j0JMToKyQf != null && new string[4] { "VBOX", "VMWARE", "QEMU", "VIRTUAL" }.Any((string vm) => j0JMToKyQf.Contains(vm, StringComparison.OrdinalIgnoreCase)))
					{
						return true;
					}
				}
			}
			catch
			{
			}
			return false;
		}
		catch
		{
			return false;
		}
	}

	private static bool DetectHardwareVirtualization()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Expected O, but got Unknown
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
							obj2 = obj.ToString();
							if (obj2 != null)
							{
								goto IL_0051;
							}
						}
						else
						{
							obj2 = null;
						}
						obj2 = "";
						goto IL_0051;
						IL_0051:
						string c5qMNZiu6q = (string)obj2;
						if (new string[5] { "Virtual Machine", "VMware", "VirtualBox", "KVM", "QEMU" }.Any((string vm) => c5qMNZiu6q.Contains(vm, StringComparison.OrdinalIgnoreCase)))
						{
							return true;
						}
						object obj3 = ((ManagementBaseObject)val2)["HypervisorPresent"];
						if (obj3 != null && (bool)obj3)
						{
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
			ManagementObjectSearcher val3 = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS");
			try
			{
				ManagementObjectEnumerator enumerator = val3.Get().GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						ManagementObject val4 = (ManagementObject)enumerator.Current;
						object obj4 = ((ManagementBaseObject)val4)["Manufacturer"];
						object obj5;
						if (obj4 != null)
						{
							obj5 = obj4.ToString();
							if (obj5 != null)
							{
								goto IL_01ed;
							}
						}
						else
						{
							obj5 = null;
						}
						obj5 = "";
						goto IL_01ed;
						IL_020b:
						object obj6;
						string drQMPEwH4e = (string)obj6;
						string UcqM0D0LRo;
						if (new string[6] { "VBOX", "VirtualBox", "VMware", "Xen", "QEMU", "Bochs" }.Any((string vm) => UcqM0D0LRo.Contains(vm, StringComparison.OrdinalIgnoreCase) || drQMPEwH4e.Contains(vm, StringComparison.OrdinalIgnoreCase)))
						{
							return true;
						}
						continue;
						IL_01ed:
						UcqM0D0LRo = (string)obj5;
						object obj7 = ((ManagementBaseObject)val4)["Version"];
						if (obj7 != null)
						{
							obj6 = obj7.ToString();
							if (obj6 != null)
							{
								goto IL_020b;
							}
						}
						else
						{
							obj6 = null;
						}
						obj6 = "";
						goto IL_020b;
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val3)?.Dispose();
			}
			return false;
		}
		catch
		{
			return false;
		}
	}

	private static bool DetectRDTSCTimeDilation()
	{
		try
		{
			long[] array = new long[10];
			long[] array2 = new long[10];
			for (int i = 0; i < 10; i++)
			{
				long timestamp = Stopwatch.GetTimestamp();
				Thread.Sleep(10);
				long timestamp2 = Stopwatch.GetTimestamp();
				array[i] = timestamp2 - timestamp;
				long timestamp3 = Stopwatch.GetTimestamp();
				Thread.Sleep(10);
				long timestamp4 = Stopwatch.GetTimestamp();
				array2[i] = timestamp4 - timestamp3;
			}
			double WdcM8RIs0H = array.Average();
			double KHTMkEFJPP = array2.Average();
			double num = array.Select((long x) => Math.Pow((double)x - WdcM8RIs0H, 2.0)).Average();
			double num2 = array2.Select((long x) => Math.Pow((double)x - KHTMkEFJPP, 2.0)).Average();
			return !(num <= 10000.0) || num2 > 10000.0;
		}
		catch
		{
			return false;
		}
	}

	private static bool DetectVMMacAddress()
	{
		try
		{
			string[] source = new string[8] { "00:0C:29", "00:1C:14", "00:50:56", "08:00:27", "00:15:5D", "00:16:3E", "52:54:00", "00:1C:42" };
			NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
			int num = 0;
			while (true)
			{
				if (num >= allNetworkInterfaces.Length)
				{
					return false;
				}
				NetworkInterface networkInterface = allNetworkInterfaces[num];
				if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet || networkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
				{
					string text = networkInterface.GetPhysicalAddress().ToString();
					if (text.Length >= 6)
					{
						string avuM3PTCi1 = $"{text.Substring(0, 2)}:{text.Substring(2, 2)}:{text.Substring(4, 2)}";
						if (source.Any((string prefix) => avuM3PTCi1.Equals(prefix, StringComparison.OrdinalIgnoreCase)))
						{
							break;
						}
					}
				}
				num++;
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private static bool DetectContainer()
	{
		try
		{
			if (!File.Exists("/.dockerenv"))
			{
				string[] array = new string[3] { "DOCKER_CONTAINER", "KUBERNETES_SERVICE_HOST", "container" };
				int num = 0;
				while (true)
				{
					if (num >= array.Length)
					{
						if (File.Exists("/proc/1/cgroup"))
						{
							string text = File.ReadAllText("/proc/1/cgroup");
							if (text.Contains("docker") || text.Contains("kubepods"))
							{
								return true;
							}
						}
						if (Environment.OSVersion.Platform == PlatformID.Win32NT)
						{
							try
							{
								using RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\cexecsvc");
								if (registryKey != null)
								{
									return true;
								}
							}
							catch
							{
							}
						}
						return false;
					}
					if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(array[num])))
					{
						num++;
						continue;
					}
					break;
				}
				return true;
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	public static bool ShouldApplyStricterChecks(VMDetectionResult vmResult)
	{
		if (vmResult.IsVirtualMachine)
		{
			if (vmResult.ConfidenceScore < 50)
			{
				return vmResult.DetectionMethods.Length >= 3;
			}
			return true;
		}
		return false;
	}
}
