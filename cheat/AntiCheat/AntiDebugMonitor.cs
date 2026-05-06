using System;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using TelemetryHttpClient;
using HwidProvider;

namespace AntiDebugMonitor;

public sealed class AntiDebugMonitor
{
	private delegate int VectoredExceptionHandler(ref EXCEPTION_POINTERS exceptionInfo);

	private struct EXCEPTION_POINTERS
	{
		public nint jVbMMk0Qt9;
	}

	private struct EXCEPTION_RECORD
	{
		public uint KXKMeETc9g;
	}

	[StructLayout(LayoutKind.Auto)]
	[Flags]
	private struct Enum4 : Enum
	{
	}

	private struct CONTEXT
	{
		public uint xLFMl2TewC;

		public uint Xckfarsrxi;

		public ulong iCnfQvI0fj;

		public ulong FrBfWQs6Hv;

		public ulong D1ZfCcVDFG;

		public ulong lJRfUlr95M;

		public ulong Eivf9lJyij;

		public ulong VwTfsI5SIh;
	}

	private struct PEB
	{
		public byte YDsfdjaOtj;

		public nint cfef8JUQ6U;

		public uint bxwfGkMt2L;
	}

	private struct PROCESS_HEAP
	{
	}

	private struct SYSTEM_INFO
	{
		public uint AoLeFvofgW;
	}

	private static Timer? timer_0;

	private static readonly object object_0 = new object();

	private static bool bool_0 = false;

	private static bool bool_1 = false;

	private static Thread? thread_0;

	private static nint intptr_0 = IntPtr.Zero;

	private static uint uint_0 = 0u;

	private static long long_0 = 0L;

	private static readonly string[] string_0 = new string[25]
	{
		"x64dbg", "x32dbg", "ollydbg", "windbg", "ida", "ida64", "idaq", "idaq64", "idaw", "idaw64",
		"procmon", "procmon64", "apimonitor", "apimonitor-x64", "apimonitor-x86", "wireshark", "fiddler", "processhacker", "ghidra", "radare2",
		"r2", "cutter", "cheatengine", "cheatengine-x86_64", "artmoney"
	};

	private static readonly string[] string_1 = new string[26]
	{
		"C:\\Program Files\\VMware\\VMware Tools\\", "C:\\Program Files (x86)\\VMware\\VMware Tools\\", "C:\\Program Files\\Oracle\\VirtualBox Guest Additions\\", "C:\\Windows\\System32\\drivers\\VBoxGuest.sys", "C:\\Windows\\System32\\drivers\\VBoxMouse.sys", "C:\\Windows\\System32\\drivers\\VBoxSF.sys", "C:\\Windows\\System32\\vboxdisp.dll", "C:\\Windows\\System32\\vboxhook.dll", "C:\\Windows\\System32\\vboxmrxnp.dll", "C:\\Windows\\System32\\vboxogl.dll",
		"C:\\Windows\\System32\\vboxoglarrayspu.dll", "C:\\Windows\\System32\\vboxoglcrutil.dll", "C:\\Windows\\System32\\vboxoglerrorspu.dll", "C:\\Windows\\System32\\vboxoglfeedbackspu.dll", "C:\\Windows\\System32\\vboxoglpackspu.dll", "C:\\Windows\\System32\\vboxoglpassthroughspu.dll", "C:\\Windows\\System32\\vboxservice.exe", "C:\\Windows\\System32\\vboxtray.exe", "C:\\Windows\\System32\\vmicheartbeat.dll", "C:\\Windows\\System32\\vmickvpexchange.dll",
		"C:\\Windows\\System32\\vmicshutdown.dll", "C:\\Windows\\System32\\vmictimesync.dll", "C:\\Windows\\System32\\vmicvss.dll", "C:\\Windows\\System32\\drivers\\vmbus.sys", "C:\\Windows\\System32\\drivers\\VMBusHID.sys", "C:\\Windows\\System32\\drivers\\hyperkbd.sys"
	};

	private static readonly string[] string_2 = new string[7] { "00:0C:29", "00:50:56", "00:05:69", "08:00:27", "00:15:5D", "00:1C:42", "00:16:3E" };

	private long long_2;

	private float float_1;

	private string string_3;

	private string string_4;

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
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	private string String_0
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	private string String_1
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
	private static extern bool IsDebuggerPresent();

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool CheckRemoteDebuggerPresent(nint hProcess, out bool isDebuggerPresent);

	[DllImport("ntdll.dll", SetLastError = true)]
	private static extern int NtQueryInformationProcess(nint processHandle, int processInformationClass, out nint processInformation, int processInformationLength, out int returnLength);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool QueryPerformanceFrequency(out long lpFrequency);

	[DllImport("kernel32.dll")]
	private static extern void GetNativeSystemInfo(ref SYSTEM_INFO lpSystemInfo);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool GetThreadContext(nint hThread, ref CONTEXT lpContext);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern nint OpenThread(Enum4 dwDesiredAccess, bool bInheritHandle, uint dwThreadId);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool CloseHandle(nint hObject);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool DebugActiveProcess(int dwProcessId);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool DebugActiveProcessStop(int dwProcessId);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern nint AddVectoredExceptionHandler(uint first, VectoredExceptionHandler handler);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern uint RemoveVectoredExceptionHandler(nint handle);

	public static void StartMonitoring()
	{
		//IL_0065: Expected I8, but got I4
		//IL_006f: Expected I8, but got I4
		lock (object_0)
		{
			if (!bool_0)
			{
				Console.WriteLine("[AntiDebug] Starting debugger detection monitoring...");
				InitializePerformanceCounter();
				EnableSelfDebugging();
				CalculateInitialChecksum();
				PerformDebuggerChecks();
				timer_0 = new Timer(delegate
				{
					PerformDebuggerChecks();
				}, null, TimeSpan.FromSeconds(15L), TimeSpan.FromSeconds(15L));
				bool_0 = true;
				Console.WriteLine("[AntiDebug] Monitoring started successfully");
			}
			else
			{
				Console.WriteLine("[AntiDebug] Monitoring already started");
			}
		}
	}

	public static void StopMonitoring()
	{
		lock (object_0)
		{
			if (bool_0)
			{
				Console.WriteLine("[AntiDebug] Stopping debugger detection monitoring...");
				timer_0?.Dispose();
				timer_0 = null;
				DisableSelfDebugging();
				RemoveVEH();
				bool_0 = false;
				Console.WriteLine("[AntiDebug] Monitoring stopped");
			}
		}
	}

	private static void EnableSelfDebugging()
	{
		try
		{
			if (!bool_1)
			{
				if (DebugActiveProcess(Process.GetCurrentProcess().Id))
				{
					bool_1 = true;
					Console.WriteLine("[AntiDebug] ✅ Self-debugging enabled - external debuggers blocked");
					thread_0 = new Thread(SelfDebugEventLoop)
					{
						IsBackground = true,
						Name = "Self-Debug Event Loop"
					};
					thread_0.Start();
					return;
				}
				int lastWin32Error = Marshal.GetLastWin32Error();
				Console.WriteLine($"[AntiDebug] ⚠\ufe0f Failed to enable self-debugging (error {lastWin32Error})");
				if (lastWin32Error != 5 && lastWin32Error != 87)
				{
					Console.WriteLine("[AntiDebug] This may indicate a debugger is already attached");
					OnDebuggerDetected("Failed to enable self-debugging (debugger already attached?)");
				}
				else
				{
					Console.WriteLine("[AntiDebug] Self-debugging not available (insufficient privileges), continuing without it");
				}
			}
			else
			{
				Console.WriteLine("[AntiDebug] Self-debugging already enabled");
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("[AntiDebug] EnableSelfDebugging error: " + ex.Message);
		}
	}

	private static void DisableSelfDebugging()
	{
		try
		{
			if (bool_1)
			{
				DebugActiveProcessStop(Process.GetCurrentProcess().Id);
				bool_1 = false;
				thread_0?.Join(1000);
				thread_0 = null;
				Console.WriteLine("[AntiDebug] Self-debugging disabled");
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("[AntiDebug] DisableSelfDebugging error: " + ex.Message);
		}
	}

	private static void SelfDebugEventLoop()
	{
		Console.WriteLine("[AntiDebug] Self-debug event loop started");
		while (bool_1 && bool_0)
		{
			Thread.Sleep(1000);
		}
		Console.WriteLine("[AntiDebug] Self-debug event loop stopped");
	}

	private static void PerformDebuggerChecks()
	{
		try
		{
			GetPerformanceCounter();
			if (IsDebuggerPresent())
			{
				OnDebuggerDetected("IsDebuggerPresent");
			}
			else if (CheckRemoteDebugger())
			{
				OnDebuggerDetected("CheckRemoteDebuggerPresent");
			}
			else if (!CheckDebugPort())
			{
				string text = CheckBlacklistedProcesses();
				if (text == null)
				{
					if (!CheckSingleStepDebugging())
					{
						if (!CheckKernelDebugger())
						{
							if (!CheckCodeIntegrity())
							{
								if (CheckPEBBeingDebugged())
								{
									OnDebuggerDetected("PEB BeingDebugged flag set");
								}
								else if (CheckNtGlobalFlag())
								{
									OnDebuggerDetected("NtGlobalFlag indicates debugging");
								}
								else if (CheckHeapFlags())
								{
									OnDebuggerDetected("Heap flags indicate debugging");
								}
								else if (CheckAntiAntiDebug())
								{
									OnDebuggerDetected("Anti-anti-debug tool detected (ScyllaHide/TitanHide)");
								}
							}
							else
							{
								OnDebuggerDetected("Code integrity violation (software breakpoint detected)");
							}
						}
						else
						{
							OnDebuggerDetected("Kernel debugger detected");
						}
					}
					else
					{
						OnDebuggerDetected("Single-step debugging detected");
					}
				}
				else
				{
					OnDebuggerDetected("Blacklisted process detected: " + text);
				}
			}
			else
			{
				OnDebuggerDetected("NtQueryInformationProcess (ProcessDebugPort)");
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("[AntiDebug] Error during checks: " + ex.Message);
		}
	}

	private static bool CheckRemoteDebugger()
	{
		try
		{
			if (CheckRemoteDebuggerPresent(Process.GetCurrentProcess().Handle, out var isDebuggerPresent))
			{
				return isDebuggerPresent;
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("[AntiDebug] CheckRemoteDebugger error: " + ex.Message);
		}
		return false;
	}

	private static bool CheckDebugPort()
	{
		try
		{
			nint handle = Process.GetCurrentProcess().Handle;
			nint processInformation = IntPtr.Zero;
			if (NtQueryInformationProcess(handle, 7, out processInformation, IntPtr.Size, out var _) == 0 && processInformation != IntPtr.Zero)
			{
				goto IL_0051;
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("[AntiDebug] CheckDebugPort error: " + ex.Message);
		}
		return false;
		IL_0051:
		return true;
	}

	private static string? CheckBlacklistedProcesses()
	{
		try
		{
			Process[] processes = Process.GetProcesses();
			foreach (Process process in processes)
			{
				try
				{
					string text = process.ProcessName.ToLowerInvariant();
					string[] array = string_0;
					foreach (string text2 in array)
					{
						if (text.Contains(text2.ToLowerInvariant()))
						{
							return process.ProcessName;
						}
					}
				}
				catch
				{
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("[AntiDebug] CheckBlacklistedProcesses error: " + ex.Message);
		}
		return null;
	}

	private static bool CheckCPUIDHypervisor()
	{
		try
		{
			SYSTEM_INFO lpSystemInfo = default(SYSTEM_INFO);
			GetNativeSystemInfo(ref lpSystemInfo);
			if (lpSystemInfo.AoLeFvofgW >= 2)
			{
				return false;
			}
			Console.WriteLine($"[AntiDebug] Suspicious: Only {lpSystemInfo.AoLeFvofgW} CPU core(s) detected");
			return true;
		}
		catch (Exception ex)
		{
			Console.WriteLine("[AntiDebug] CheckCPUIDHypervisor error: " + ex.Message);
			return false;
		}
	}

	private static string? CheckVMFiles()
	{
		try
		{
			string[] array = string_1;
			foreach (string text in array)
			{
				if (File.Exists(text) || Directory.Exists(text))
				{
					return text;
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("[AntiDebug] CheckVMFiles error: " + ex.Message);
		}
		return null;
	}

	private static string? CheckVMMacAddresses()
	{
		try
		{
			NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
			foreach (NetworkInterface networkInterface in allNetworkInterfaces)
			{
				try
				{
					PhysicalAddress physicalAddress = networkInterface.GetPhysicalAddress();
					if (physicalAddress == null || physicalAddress.ToString().Length < 8)
					{
						continue;
					}
					string text = physicalAddress.ToString();
					if (text.Length < 6)
					{
						continue;
					}
					string text2 = $"{text.Substring(0, 2)}:{text.Substring(2, 2)}:{text.Substring(4, 2)}";
					string[] array = string_2;
					foreach (string value in array)
					{
						if (text2.Equals(value, StringComparison.OrdinalIgnoreCase))
						{
							return networkInterface.Name + " (" + text2 + ")";
						}
					}
				}
				catch
				{
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("[AntiDebug] CheckVMMacAddresses error: " + ex.Message);
		}
		return null;
	}

	private static bool CheckVirtualMachine()
	{
		try
		{
			if (!CheckCPUIDHypervisor())
			{
				string text = CheckVMFiles();
				if (text != null)
				{
					OnDebuggerDetected("Virtual Machine detected: VM-specific file found (" + text + ")");
					return true;
				}
				string text2 = CheckVMMacAddresses();
				if (text2 != null)
				{
					OnDebuggerDetected("Virtual Machine detected: VM vendor MAC address (" + text2 + ")");
					return true;
				}
				return false;
			}
			OnDebuggerDetected("Virtual Machine detected: CPUID/CPU core check");
			return true;
		}
		catch (Exception ex)
		{
			Console.WriteLine("[AntiDebug] CheckVirtualMachine error: " + ex.Message);
			return false;
		}
	}

	private static bool CheckHardwareBreakpoints()
	{
		//IL_0036: Expected O, but got I4
		//IL_01f8: Expected I8, but got I4
		//IL_009a: Expected I8, but got I4
		//IL_008c: Expected I8, but got I4
		//IL_00a8: Expected I8, but got I4
		//IL_00c7: Expected I8, but got I4
		//IL_00d3: Expected I8, but got I4
		try
		{
			foreach (ProcessThread thread in Process.GetCurrentProcess().Threads)
			{
				try
				{
					nint num = OpenThread((Enum4)72, bInheritHandle: false, (uint)thread.Id);
					if (num == IntPtr.Zero)
					{
						continue;
					}
					try
					{
						CONTEXT lpContext = new CONTEXT
						{
							xLFMl2TewC = 65552u
						};
						if (GetThreadContext(num, ref lpContext))
						{
							if (lpContext.iCnfQvI0fj != 0L || lpContext.FrBfWQs6Hv != 0L || lpContext.D1ZfCcVDFG != 0L || lpContext.lJRfUlr95M != 0L)
							{
								Console.WriteLine($"[AntiDebug] Hardware breakpoint detected on thread {thread.Id}");
								Console.WriteLine($"[AntiDebug] DR0=0x{lpContext.iCnfQvI0fj:X}, DR1=0x{lpContext.FrBfWQs6Hv:X}, DR2=0x{lpContext.D1ZfCcVDFG:X}, DR3=0x{lpContext.lJRfUlr95M:X}");
								Console.WriteLine($"[AntiDebug] DR7=0x{lpContext.VwTfsI5SIh:X}");
								lpContext.iCnfQvI0fj = 0uL;
								lpContext.FrBfWQs6Hv = 0uL;
								lpContext.D1ZfCcVDFG = 0uL;
								lpContext.lJRfUlr95M = 0uL;
								lpContext.Eivf9lJyij = 0uL;
								lpContext.VwTfsI5SIh = 0uL;
								return true;
							}
							if ((lpContext.VwTfsI5SIh & 0xFF) != 0L)
							{
								Console.WriteLine($"[AntiDebug] Hardware breakpoint control flags detected on thread {thread.Id}");
								Console.WriteLine($"[AntiDebug] DR7=0x{lpContext.VwTfsI5SIh:X}");
								return true;
							}
						}
					}
					finally
					{
						CloseHandle(num);
					}
				}
				catch
				{
				}
			}
			return false;
		}
		catch (Exception ex)
		{
			Console.WriteLine("[AntiDebug] CheckHardwareBreakpoints error: " + ex.Message);
			return false;
		}
	}

	private static bool CheckSingleStepDebugging()
	{
		//IL_0036: Expected O, but got I4
		try
		{
			foreach (ProcessThread thread in Process.GetCurrentProcess().Threads)
			{
				try
				{
					nint num = OpenThread((Enum4)72, bInheritHandle: false, (uint)thread.Id);
					if (num == IntPtr.Zero)
					{
						continue;
					}
					try
					{
						CONTEXT lpContext = new CONTEXT
						{
							xLFMl2TewC = 65537u
						};
						if (!GetThreadContext(num, ref lpContext) || ((ulong)lpContext.Xckfarsrxi & 0x100uL) == 0L)
						{
							continue;
						}
						Console.WriteLine($"[AntiDebug] Trap Flag detected on thread {thread.Id}");
						Console.WriteLine($"[AntiDebug] EFLAGS=0x{lpContext.Xckfarsrxi:X}");
						lpContext.Xckfarsrxi &= 4294967039u;
						return true;
					}
					finally
					{
						CloseHandle(num);
					}
				}
				catch
				{
				}
			}
			return false;
		}
		catch (Exception ex)
		{
			Console.WriteLine("[AntiDebug] CheckSingleStepDebugging error: " + ex.Message);
			return false;
		}
	}

	private static bool CheckKernelDebugger()
	{
		try
		{
			return false;
		}
		catch (Exception ex)
		{
			Console.WriteLine("[AntiDebug] CheckKernelDebugger error: " + ex.Message);
			return false;
		}
	}

	private static void CalculateInitialChecksum()
	{
		try
		{
			ProcessModule mainModule = Process.GetCurrentProcess().MainModule;
			if (mainModule != null)
			{
				nint baseAddress = mainModule.BaseAddress;
				byte[] array = new byte[4096];
				Marshal.Copy(baseAddress, array, 0, array.Length);
				uint_0 = CalculateCRC32(array);
				Console.WriteLine($"[AntiDebug] Initial code checksum: 0x{uint_0:X8}");
			}
			else
			{
				Console.WriteLine("[AntiDebug] Failed to get main module for checksumming");
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("[AntiDebug] CalculateInitialChecksum error: " + ex.Message);
		}
	}

	private static bool CheckCodeIntegrity()
	{
		try
		{
			if (uint_0 == 0)
			{
				return false;
			}
			ProcessModule mainModule = Process.GetCurrentProcess().MainModule;
			if (mainModule == null)
			{
				return false;
			}
			nint baseAddress = mainModule.BaseAddress;
			byte[] array = new byte[4096];
			Marshal.Copy(baseAddress, array, 0, array.Length);
			uint num = CalculateCRC32(array);
			if (num == uint_0)
			{
				return false;
			}
			Console.WriteLine("[AntiDebug] Code integrity violation detected!");
			Console.WriteLine($"[AntiDebug] Initial checksum: 0x{uint_0:X8}");
			Console.WriteLine($"[AntiDebug] Current checksum: 0x{num:X8}");
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == 204)
				{
					Console.WriteLine($"[AntiDebug] Software breakpoint (0xCC) detected at offset 0x{i:X}");
				}
			}
			return true;
		}
		catch (Exception ex)
		{
			Console.WriteLine("[AntiDebug] CheckCodeIntegrity error: " + ex.Message);
			return false;
		}
	}

	private static uint CalculateCRC32(byte[] data)
	{
		uint num = uint.MaxValue;
		foreach (byte b in data)
		{
			num ^= b;
			for (int j = 0; j < 8; j++)
			{
				num = (((num & 1) != 0) ? ((num >> 1) ^ 0xEDB88320u) : (num >> 1));
			}
		}
		return ~num;
	}

	private static void InstallVEH()
	{
		try
		{
			if (intptr_0 == IntPtr.Zero)
			{
				intptr_0 = AddVectoredExceptionHandler(1u, VectoredExceptionHandlerCallback);
				if (intptr_0 == IntPtr.Zero)
				{
					Console.WriteLine("[AntiDebug] ⚠\ufe0f Failed to install VEH");
				}
				else
				{
					Console.WriteLine("[AntiDebug] ✅ Vectored Exception Handler installed");
				}
			}
			else
			{
				Console.WriteLine("[AntiDebug] VEH already installed");
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("[AntiDebug] InstallVEH error: " + ex.Message);
		}
	}

	private static void RemoveVEH()
	{
		try
		{
			if (intptr_0 != IntPtr.Zero)
			{
				RemoveVectoredExceptionHandler(intptr_0);
				intptr_0 = IntPtr.Zero;
				Console.WriteLine("[AntiDebug] Vectored Exception Handler removed");
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("[AntiDebug] RemoveVEH error: " + ex.Message);
		}
	}

	private static int VectoredExceptionHandlerCallback(ref EXCEPTION_POINTERS exceptionInfo)
	{
		try
		{
			EXCEPTION_RECORD eXCEPTION_RECORD = Marshal.PtrToStructure<EXCEPTION_RECORD>(exceptionInfo.jVbMMk0Qt9);
			if (eXCEPTION_RECORD.KXKMeETc9g != 2147483652u)
			{
				if (eXCEPTION_RECORD.KXKMeETc9g != 2147483651u)
				{
					return -1;
				}
				Console.WriteLine("[AntiDebug] VEH: Breakpoint exception intercepted");
				return 0;
			}
			Console.WriteLine("[AntiDebug] VEH: Single-step exception intercepted");
			return 0;
		}
		catch
		{
			return -1;
		}
	}

	private static bool CheckPEBBeingDebugged()
	{
		try
		{
			nint pEBAddress = GetPEBAddress();
			if (pEBAddress != IntPtr.Zero)
			{
				PEB pEB = Marshal.PtrToStructure<PEB>(pEBAddress);
				if (pEB.YDsfdjaOtj != 0)
				{
					Console.WriteLine($"[AntiDebug] PEB.BeingDebugged = {pEB.YDsfdjaOtj}");
					return true;
				}
				return false;
			}
			return false;
		}
		catch (Exception ex)
		{
			Console.WriteLine("[AntiDebug] CheckPEBBeingDebugged error: " + ex.Message);
			return false;
		}
	}

	private static bool CheckNtGlobalFlag()
	{
		try
		{
			nint pEBAddress = GetPEBAddress();
			if (pEBAddress == IntPtr.Zero)
			{
				return false;
			}
			PEB pEB = Marshal.PtrToStructure<PEB>(pEBAddress);
			if ((pEB.bxwfGkMt2L & 0x70) == 0)
			{
				return false;
			}
			Console.WriteLine($"[AntiDebug] NtGlobalFlag = 0x{pEB.bxwfGkMt2L:X} (debug flags detected)");
			return true;
		}
		catch (Exception ex)
		{
			Console.WriteLine("[AntiDebug] CheckNtGlobalFlag error: " + ex.Message);
			return false;
		}
	}

	private static bool CheckHeapFlags()
	{
		try
		{
			nint pEBAddress = GetPEBAddress();
			if (pEBAddress != IntPtr.Zero)
			{
				nint cfef8JUQ6U = Marshal.PtrToStructure<PEB>(pEBAddress).cfef8JUQ6U;
				if (cfef8JUQ6U != IntPtr.Zero)
				{
					uint num = (uint)Marshal.ReadInt32(IntPtr.Add(cfef8JUQ6U, 64));
					uint num2 = (uint)Marshal.ReadInt32(IntPtr.Add(cfef8JUQ6U, 68));
					if (num2 != 0)
					{
						Console.WriteLine($"[AntiDebug] Heap ForceFlags = 0x{num2:X} (should be 0 in non-debug)");
						return true;
					}
					if ((num & 0xFFFFFFFDu) == 0)
					{
						return false;
					}
					Console.WriteLine($"[AntiDebug] Heap Flags = 0x{num:X} (contains debug flags)");
					return true;
				}
				return false;
			}
			return false;
		}
		catch (Exception ex)
		{
			Console.WriteLine("[AntiDebug] CheckHeapFlags error: " + ex.Message);
			return false;
		}
	}

	private static bool CheckAntiAntiDebug()
	{
		try
		{
			string[] array = new string[5] { "scyllahide.dll", "scyllahidex64.dll", "scyllahidex86.dll", "HookLibraryx64.dll", "HookLibraryx86.dll" };
			Process currentProcess = Process.GetCurrentProcess();
			string text = currentProcess.ProcessName.ToLowerInvariant();
			foreach (ProcessModule module in currentProcess.Modules)
			{
				string text2 = module.ModuleName.ToLowerInvariant();
				if (text2.Equals(text + ".exe", StringComparison.OrdinalIgnoreCase) || text2.Equals(text, StringComparison.OrdinalIgnoreCase))
				{
					continue;
				}
				string[] array2 = array;
				foreach (string text3 in array2)
				{
					if (text2.Contains(text3.ToLowerInvariant()))
					{
						Console.WriteLine("[AntiDebug] ScyllaHide detected: " + module.ModuleName);
						return true;
					}
				}
			}
			try
			{
				nint num = CreateFile("\\\\.\\TitanHide", 0u, 0u, IntPtr.Zero, 3u, 0u, IntPtr.Zero);
				if (num != new IntPtr(-1))
				{
					CloseHandle(num);
					Console.WriteLine("[AntiDebug] TitanHide driver detected");
					return true;
				}
			}
			catch
			{
			}
			return false;
		}
		catch (Exception ex)
		{
			Console.WriteLine("[AntiDebug] CheckAntiAntiDebug error: " + ex.Message);
			return false;
		}
	}

	private static nint GetPEBAddress()
	{
		try
		{
			nint handle = Process.GetCurrentProcess().Handle;
			nint processInformation = IntPtr.Zero;
			if (NtQueryInformationProcess(handle, 0, out processInformation, IntPtr.Size, out var _) == 0)
			{
				return Marshal.ReadIntPtr(processInformation, 8);
			}
			return IntPtr.Zero;
		}
		catch (Exception ex)
		{
			Console.WriteLine("[AntiDebug] GetPEBAddress error: " + ex.Message);
			return IntPtr.Zero;
		}
	}

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern nint CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, nint lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, nint hTemplateFile);

	private static void OnDebuggerDetected(string detectionMethod)
	{
		//IL_006a: Expected I8, but got I4
		Console.WriteLine("========================================");
		Console.WriteLine("[AntiDebug] DEBUGGER DETECTED!");
		Console.WriteLine("[AntiDebug] Detection method: " + detectionMethod);
		Console.WriteLine("========================================");
		try
		{
			Console.WriteLine("[AntiDebug] Sending security screenshot...");
			BootstrapHooks.SendSecurityScreenshot("AntiDebug: " + detectionMethod);
			Console.WriteLine("[AntiDebug] Sending security alert...");
			Task.Run(async delegate
			{
				try
				{
					await TelemetryHttpClient.SendSecurityEventAsync(HwidProvider.GetOrCreateHWID(), "debugger_detected", "Debugger detected: " + detectionMethod, new
					{
						method = detectionMethod,
						timestamp = DateTime.UtcNow
					});
					Console.WriteLine("[AntiDebug] Security alert sent");
				}
				catch (Exception ex2)
				{
					Console.WriteLine("[AntiDebug] Failed to send security alert: " + ex2.Message);
				}
			}).Wait(TimeSpan.FromSeconds(3L));
			Console.WriteLine("[AntiDebug] Attempting to kill debugger process...");
			TryKillDebuggerProcess();
			StopMonitoring();
			Console.WriteLine("[AntiDebug] Terminating process...");
			Environment.Exit(1);
		}
		catch (Exception ex)
		{
			Console.WriteLine("[AntiDebug] Error in OnDebuggerDetected: " + ex.Message);
			Environment.Exit(1);
		}
	}

	private static void TryKillDebuggerProcess()
	{
		try
		{
			Process[] processes = Process.GetProcesses();
			foreach (Process process in processes)
			{
				try
				{
					string text = process.ProcessName.ToLowerInvariant();
					string[] array = string_0;
					foreach (string text2 in array)
					{
						if (text.Contains(text2.ToLowerInvariant()))
						{
							Console.WriteLine("[AntiDebug] Killing debugger process: " + process.ProcessName);
							process.Kill();
							Console.WriteLine("[AntiDebug] Process killed: " + process.ProcessName);
						}
					}
				}
				catch
				{
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("[AntiDebug] TryKillDebuggerProcess error: " + ex.Message);
		}
	}

	private static void InitializePerformanceCounter()
	{
		//IL_001f: Expected I8, but got I4
		if (long_0 == 0L && !QueryPerformanceFrequency(out long_0))
		{
			Console.WriteLine("[AntiDebug] Warning: QueryPerformanceFrequency failed, timing checks may be inaccurate");
			long_0 = 1L;
		}
	}

	private static long GetPerformanceCounter()
	{
		return Environment.TickCount64 * (long_0 / 1000);
	}

	private static double GetElapsedMilliseconds(long startCounter, long endCounter)
	{
		if (long_0 == 0L)
		{
			return 0.0;
		}
		return (double)(endCounter - startCounter) * 1000.0 / (double)long_0;
	}
}
