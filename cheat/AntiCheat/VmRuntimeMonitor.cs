using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32;
using VmDetectionResult;
using TelemetryCollector;

namespace VmRuntimeMonitor;

public sealed class VmRuntimeMonitor
{
	private struct SYSTEM_INFO
	{
	}

	private sealed class NativeMethods
	{
		private long long_0;

		private double double_0;

		private double double_1;

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

		private double Double_1
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

		public static bool TryGetCPUID(int function, int[] result)
		{
			try
			{
				return false;
			}
			catch
			{
				return false;
			}
		}

		private string method_4(double double_2, byte byte_0)
		{
			return "Хитролох_иди_нахуй._4_________9_2_____";
		}
	}

	private static Thread? thread_0;

	private static volatile bool bool_0;

	private static readonly object object_0 = new object();

	private static TelemetryCollector? gclass155_0;

	private bool bool_2;

	private string string_0;

	private string string_1;

	private float float_1;

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

	private string String_1
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

	private float Single_0
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

	[DllImport("kernel32.dll")]
	private static extern void GetSystemInfo(out SYSTEM_INFO lpSystemInfo);

	public static void PerformOneTimeCheck(TelemetryCollector telemetry)
	{
		Logger.Info("[AntiVM] Performing one-time VM detection check...");
		gclass155_0 = telemetry;
		VmDetectionResult gClass = PerformCheck();
		if (!gClass.IsVM)
		{
			Logger.Info("[AntiVM] ✅ No VM detected");
		}
		else
		{
			OnVMDetected(gClass);
		}
	}

	public static void StartMonitoring(TelemetryCollector telemetry)
	{
		lock (object_0)
		{
			if (!bool_0)
			{
				gclass155_0 = telemetry;
				bool_0 = true;
				thread_0 = new Thread(MonitorLoop)
				{
					IsBackground = true,
					Name = "AntiVM Monitor",
					Priority = ThreadPriority.Normal
				};
				thread_0.Start();
				Logger.Info("[AntiVM] ✅ Monitoring started");
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
				Logger.Info("[AntiVM] Monitoring stopped");
			}
		}
	}

	private static void MonitorLoop()
	{
		Logger.Info("[AntiVM] Monitor thread started");
		VmDetectionResult gClass = PerformCheck();
		if (gClass.IsVM)
		{
			OnVMDetected(gClass);
		}
		while (bool_0)
		{
			try
			{
				Thread.Sleep(30000);
				gClass = PerformCheck();
				if (gClass.IsVM)
				{
					OnVMDetected(gClass);
					break;
				}
			}
			catch (Exception ex)
			{
				Logger.Warn("[AntiVM] Error in monitor loop: " + ex.Message);
			}
		}
		Logger.Info("[AntiVM] Monitor thread stopped");
	}

	public static VmDetectionResult PerformCheck()
	{
		VmDetectionResult gClass = new VmDetectionResult();
		if (DetectHypervisorCPUID())
		{
			gClass.IsVM = true;
			gClass.Indicators.Add("CPUID hypervisor bit set");
		}
		List<string> list = DetectVMProcesses();
		if (list.Count > 0)
		{
			gClass.IsVM = true;
			gClass.Indicators.AddRange(list.Select((string p) => "VM process: " + p));
		}
		List<string> list2 = DetectVMArtifacts();
		if (list2.Count > 0)
		{
			gClass.IsVM = true;
			gClass.Indicators.AddRange(list2);
		}
		if (DetectVMHardware())
		{
			gClass.IsVM = true;
			gClass.Indicators.Add("VM hardware detected");
		}
		if (DetectVMMacAddress())
		{
			gClass.IsVM = true;
			gClass.Indicators.Add("VM MAC address detected");
		}
		if (DetectVMTiming())
		{
			gClass.IsVM = true;
			gClass.Indicators.Add("VM timing anomaly detected");
		}
		return gClass;
	}

	private static bool DetectHypervisorCPUID()
	{
		try
		{
			int[] array = new int[4];
			if (NativeMethods.TryGetCPUID(1, array))
			{
				return (array[2] & int.MinValue) != 0;
			}
		}
		catch
		{
		}
		return false;
	}

	private static List<string> DetectVMProcesses()
	{
		List<string> list = new List<string>();
		string[] source = new string[8] { "vmware", "vmtoolsd", "vboxservice", "vboxtray", "xenservice", "qemu-ga", "prl_tools", "prl_cc" };
		try
		{
			Process[] processes = Process.GetProcesses();
			foreach (Process process in processes)
			{
				try
				{
					string sT7ezB1hTo = process.ProcessName.ToLowerInvariant();
					if (source.Any((string vm) => sT7ezB1hTo.Contains(vm)))
					{
						list.Add(process.ProcessName);
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
		return list;
	}

	private static List<string> DetectVMArtifacts()
	{
		List<string> list = new List<string>();
		try
		{
			string[] array = new string[3] { "HARDWARE\\DEVICEMAP\\Scsi\\Scsi Port 0\\Scsi Bus 0\\Target Id 0\\Logical Unit Id 0", "HARDWARE\\Description\\System", "SOFTWARE\\VMware, Inc.\\VMware Tools" };
			foreach (string text in array)
			{
				try
				{
					using RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(text);
					if (registryKey != null)
					{
						string text2 = registryKey.GetValue("Identifier")?.ToString()?.ToLowerInvariant();
						string text3 = registryKey.GetValue("SystemBiosVersion")?.ToString()?.ToLowerInvariant();
						if (text2 != null && (text2.Contains("vmware") || text2.Contains("vbox") || text2.Contains("qemu")))
						{
							list.Add("Registry: " + text + " contains VM identifier");
						}
						if (text3 != null && (text3.Contains("vmware") || text3.Contains("vbox") || text3.Contains("qemu")))
						{
							list.Add("Registry: SystemBiosVersion contains VM identifier");
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
		return list;
	}

	private static bool DetectVMHardware()
	{
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		try
		{
			_ = Environment.ProcessorCount;
			ManagementObjectSearcher val = new ManagementObjectSearcher("SELECT TotalPhysicalMemory FROM Win32_ComputerSystem");
			try
			{
				ManagementObjectEnumerator enumerator = val.Get().GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						_ = (double)Convert.ToUInt64(enumerator.Current["TotalPhysicalMemory"]) / 1073741824.0;
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
			ManagementObjectSearcher val2 = new ManagementObjectSearcher("SELECT Manufacturer FROM Win32_BIOS");
			try
			{
				ManagementObjectEnumerator enumerator = val2.Get().GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						string text = enumerator.Current["Manufacturer"]?.ToString()?.ToLowerInvariant();
						if (text != null && (text.Contains("vmware") || text.Contains("innotek") || text.Contains("xen") || text.Contains("qemu")))
						{
							goto IL_0125;
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
				((IDisposable)val2)?.Dispose();
			}
		}
		catch
		{
		}
		return false;
		IL_0125:
		return true;
	}

	private static bool DetectVMMacAddress()
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		try
		{
			string[] array = new string[7] { "00:05:69", "00:0C:29", "00:1C:14", "00:50:56", "08:00:27", "00:16:3E", "52:54:00" };
			ManagementObjectSearcher val = new ManagementObjectSearcher("SELECT MACAddress FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = True");
			try
			{
				ManagementObjectEnumerator enumerator = val.Get().GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						string text = enumerator.Current["MACAddress"]?.ToString();
						if (text == null)
						{
							continue;
						}
						string[] array2 = array;
						foreach (string value in array2)
						{
							if (text.StartsWith(value, StringComparison.OrdinalIgnoreCase))
							{
								goto IL_0107;
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
		}
		catch
		{
		}
		return false;
		IL_0107:
		return true;
	}

	private static bool DetectVMTiming()
	{
		try
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			Thread.Sleep(100);
			stopwatch.Stop();
			if (stopwatch.ElapsedMilliseconds >= 90 && stopwatch.ElapsedMilliseconds <= 150)
			{
				goto IL_003f;
			}
		}
		catch
		{
			goto IL_003f;
		}
		return true;
		IL_003f:
		return false;
	}

	private static void OnVMDetected(VmDetectionResult result)
	{
		Logger.Fatal("[AntiVM] ❌ Virtual Machine detected!");
		foreach (string indicator in result.Indicators)
		{
			_ = indicator;
		}
		Task.Run(delegate
		{
			ExecuteProtectionSequence(result);
		});
	}

	private static async void ExecuteProtectionSequence(VmDetectionResult result)
	{
		try
		{
			BootstrapHooks.SendSecurityScreenshot("VM detected: " + string.Join(", ", result.Indicators));
			await SendSecurityAlert(result);
			Logger.Fatal("[AntiVM] \ud83d\uded1 Terminating application for security");
			await Task.Delay(2000);
			Environment.Exit(57005);
		}
		catch (Exception ex)
		{
			Logger.Error("[AntiVM] Protection sequence error: " + ex.Message);
			Environment.Exit(57005);
		}
	}

	private static async Task SendSecurityAlert(VmDetectionResult result)
	{
		try
		{
			gclass155_0?.LogUserAction("vm_detected", new Dictionary<string, object>
			{
				["indicators"] = result.Indicators,
				["timestamp"] = DateTime.UtcNow
			});
			await Task.CompletedTask;
		}
		catch (Exception)
		{
		}
	}
}
