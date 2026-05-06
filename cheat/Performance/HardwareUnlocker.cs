using System;
using System.Diagnostics;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Threading;
using Robust.Shared.GameObjects;
using CerberusConfig;

namespace HardwareUnlocker;

public sealed class HardwareUnlocker : EntitySystem
{
	private Process process_0;

	private ProcessPriorityClass processPriorityClass_0;

	private nint intptr_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private uint uint_0;

	private bool bool_0;

	private bool bool_1;

	private float float_0;

	private float float_1;

	private static DateTime dateTime_0 = DateTime.MinValue;

	private static TimeSpan timeSpan_0 = TimeSpan.Zero;

	private static double double_0 = 0.0;

	private bool bool_3;

	private double double_2;

	private string string_0;

	private long long_1;

	private bool Boolean_0
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	private double Double_0
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
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

	private long Int64_0
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

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern nint GetCurrentProcess();

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool SetPriorityClass(nint hProcess, uint dwPriorityClass);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool SetProcessAffinityMask(nint hProcess, nint dwProcessAffinityMask);

	[DllImport("ntdll.dll", SetLastError = true)]
	private static extern int NtSetTimerResolution(uint DesiredResolution, bool SetResolution, out uint CurrentResolution);

	[DllImport("ntdll.dll", SetLastError = true)]
	private static extern int NtQueryTimerResolution(out uint MinimumResolution, out uint MaximumResolution, out uint CurrentResolution);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool SetProcessWorkingSetSize(nint hProcess, nint dwMinimumWorkingSetSize, nint dwMaximumWorkingSetSize);

	[DllImport("ntdll.dll", SetLastError = true)]
	private static extern int NtSetInformationProcess(nint ProcessHandle, int ProcessInformationClass, ref int ProcessInformation, int ProcessInformationLength);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool SetThreadExecutionState(uint esFlags);

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
		process_0 = Process.GetCurrentProcess();
		processPriorityClass_0 = process_0.PriorityClass;
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
		{
			intptr_0 = process_0.ProcessorAffinity;
		}
		ThreadPool.GetMinThreads(out int_0, out int_2);
		ThreadPool.GetMaxThreads(out int_1, out int_3);
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		{
			try
			{
				NtQueryTimerResolution(out var _, out var _, out uint_0);
			}
			catch
			{
				uint_0 = 156250u;
			}
		}
	}

	public override void Update(float frameTime)
	{
		((EntitySystem)this).Update(frameTime);
		float_1 += frameTime;
		if (!(float_1 >= 1.2f))
		{
			return;
		}
		float_1 = 0f;
		if (CerberusConfig.HardwareUnlocker.Enabled && !bool_1)
		{
			UnlockHardware();
		}
		else if (!CerberusConfig.HardwareUnlocker.Enabled && bool_1)
		{
			RestoreHardware();
		}
		if (bool_1)
		{
			float_0 += frameTime;
			if (float_0 >= 5f)
			{
				float_0 = 0f;
				VerifyUnlockStatus();
			}
		}
	}

	private void UnlockHardware()
	{
		try
		{
			if (CerberusConfig.HardwareUnlocker.HighPriority)
			{
				SetProcessPriority();
			}
			if (CerberusConfig.HardwareUnlocker.UnlockAllCores)
			{
				UnlockCPUCores();
			}
			if (CerberusConfig.HardwareUnlocker.OptimizeThreadPool)
			{
				OptimizeThreadPool();
			}
			if (CerberusConfig.HardwareUnlocker.OptimizeGC)
			{
				OptimizeGarbageCollector();
			}
			if (CerberusConfig.HardwareUnlocker.GPUPriority && RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				SetGPUPriority();
			}
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				SetHighPrecisionTimer();
			}
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				IncreaseWorkingSet();
			}
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				SetHighIOPriority();
			}
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				DisablePowerThrottling();
			}
			OptimizeThreadPriorities();
			bool_1 = true;
		}
		catch (Exception)
		{
		}
	}

	private void SetProcessPriority()
	{
		try
		{
			ProcessPriorityClass priorityClass = (CerberusConfig.HardwareUnlocker.RealtimePriority ? ProcessPriorityClass.RealTime : ProcessPriorityClass.High);
			process_0.PriorityClass = priorityClass;
		}
		catch (Exception)
		{
		}
	}

	private void UnlockCPUCores()
	{
		try
		{
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
			{
				int processorCount = Environment.ProcessorCount;
				nint processorAffinity = new IntPtr((1 << processorCount) - 1);
				process_0.ProcessorAffinity = processorAffinity;
			}
		}
		catch (Exception)
		{
		}
	}

	private static void OptimizeThreadPool()
	{
		try
		{
			int processorCount = Environment.ProcessorCount;
			int workerThreads = processorCount * 2;
			int workerThreads2 = processorCount * 4;
			int completionPortThreads = processorCount;
			int completionPortThreads2 = processorCount * 2;
			ThreadPool.SetMinThreads(workerThreads, completionPortThreads);
			ThreadPool.SetMaxThreads(workerThreads2, completionPortThreads2);
		}
		catch (Exception)
		{
		}
	}

	private static void OptimizeGarbageCollector()
	{
		try
		{
			GCSettings.LatencyMode = GCLatencyMode.SustainedLowLatency;
		}
		catch (Exception)
		{
		}
	}

	private void SetGPUPriority()
	{
		try
		{
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				SetPriorityClass(GetCurrentProcess(), 128u);
			}
		}
		catch (Exception)
		{
		}
	}

	private void SetHighPrecisionTimer()
	{
		try
		{
			NtQueryTimerResolution(out var _, out var MaximumResolution, out uint_0);
			if (NtSetTimerResolution(MaximumResolution, SetResolution: true, out var _) == 0)
			{
				bool_0 = true;
			}
		}
		catch (Exception)
		{
		}
	}

	private void IncreaseWorkingSet()
	{
		try
		{
			nint currentProcess = GetCurrentProcess();
			nint dwMinimumWorkingSetSize = new IntPtr(536870912);
			nint dwMaximumWorkingSetSize = new IntPtr(4294967296L);
			SetProcessWorkingSetSize(currentProcess, dwMinimumWorkingSetSize, dwMaximumWorkingSetSize);
		}
		catch (Exception)
		{
		}
	}

	private void SetHighIOPriority()
	{
		try
		{
			nint currentProcess = GetCurrentProcess();
			int ProcessInformation = 3;
			NtSetInformationProcess(currentProcess, 33, ref ProcessInformation, 4);
		}
		catch (Exception)
		{
		}
	}

	private void DisablePowerThrottling()
	{
		try
		{
			SetThreadExecutionState(2147483713u);
		}
		catch (Exception)
		{
		}
	}

	private void OptimizeThreadPriorities()
	{
		try
		{
			Thread.CurrentThread.Priority = ThreadPriority.Highest;
			if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				return;
			}
			foreach (ProcessThread thread in process_0.Threads)
			{
				try
				{
					thread.PriorityLevel = ThreadPriorityLevel.TimeCritical;
				}
				catch
				{
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private void VerifyUnlockStatus()
	{
		try
		{
			if (CerberusConfig.HardwareUnlocker.HighPriority)
			{
				ProcessPriorityClass priorityClass = process_0.PriorityClass;
				ProcessPriorityClass processPriorityClass = (CerberusConfig.HardwareUnlocker.RealtimePriority ? ProcessPriorityClass.RealTime : ProcessPriorityClass.High);
				if (priorityClass != processPriorityClass)
				{
					SetProcessPriority();
				}
			}
			if (CerberusConfig.HardwareUnlocker.UnlockAllCores && (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux)))
			{
				int processorCount = Environment.ProcessorCount;
				nint num = new IntPtr((1 << processorCount) - 1);
				if (process_0.ProcessorAffinity != num)
				{
					UnlockCPUCores();
				}
			}
			if (!bool_0 || !RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				return;
			}
			try
			{
				NtQueryTimerResolution(out var _, out var MaximumResolution, out var CurrentResolution);
				if ((double)CurrentResolution > (double)MaximumResolution * 1.5)
				{
					SetHighPrecisionTimer();
				}
			}
			catch
			{
			}
		}
		catch (Exception)
		{
		}
	}

	private void RestoreHardware()
	{
		try
		{
			process_0.PriorityClass = processPriorityClass_0;
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
			{
				process_0.ProcessorAffinity = intptr_0;
			}
			ThreadPool.SetMinThreads(int_0, int_2);
			ThreadPool.SetMaxThreads(int_1, int_3);
			GCSettings.LatencyMode = GCLatencyMode.Interactive;
			if (bool_0 && RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				try
				{
					NtSetTimerResolution(uint_0, SetResolution: true, out var _);
					bool_0 = false;
				}
				catch
				{
				}
			}
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				try
				{
					SetThreadExecutionState(2147483648u);
				}
				catch
				{
				}
			}
			bool_1 = false;
		}
		catch (Exception)
		{
		}
	}

	public string GetUsageStats()
	{
		try
		{
			process_0.Refresh();
			double cPUUsage = GetCPUUsage();
			long value = process_0.WorkingSet64 / 1048576;
			int count = process_0.Threads.Count;
			return $"CPU: {cPUUsage:F1}% | RAM: {value}MB | Threads: {count}";
		}
		catch
		{
			return "Stats unavailable";
		}
	}

	private double GetCPUUsage()
	{
		try
		{
			DateTime now = DateTime.Now;
			TimeSpan totalProcessorTime = process_0.TotalProcessorTime;
			if (dateTime_0 == DateTime.MinValue)
			{
				dateTime_0 = now;
				timeSpan_0 = totalProcessorTime;
				return 0.0;
			}
			double totalMilliseconds = (now - dateTime_0).TotalMilliseconds;
			if (totalMilliseconds >= 500.0)
			{
				double result = (totalProcessorTime - timeSpan_0).TotalMilliseconds / ((double)Environment.ProcessorCount * totalMilliseconds) * 100.0;
				dateTime_0 = now;
				timeSpan_0 = totalProcessorTime;
				double_0 = result;
				return result;
			}
			return double_0;
		}
		catch
		{
			return 0.0;
		}
	}

	public override void Shutdown()
	{
		((EntitySystem)this).Shutdown();
		if (bool_1)
		{
			RestoreHardware();
		}
	}

	private string method_7(byte byte_0, long long_2)
	{
		return "Хитролох_иди_нахуй.__1_________1_____7";
	}
}
