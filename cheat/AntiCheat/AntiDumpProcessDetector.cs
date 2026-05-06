using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace AntiDumpProcessDetector;

public sealed class AntiDumpProcessDetector
{
	private static readonly HashSet<string> hashSet_0 = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
	{
		"megadumper", "extremedumper", "codecracker", "de4dot", "dnspy", "ilspy", "dotpeek", "reflector", "justdecompile", "telerik",
		"scyllahide", "titanHide", "x64dbg", "x32dbg", "ollydbg", "windbg", "ida", "ghidra", "radare", "hopper",
		"binary ninja", "processhacker", "systemexplorer", "apimonitor", "rohitab", "cheatengine", "artmoney", "scanmem", "gameguardian", "injectdll",
		"dllinjector", "remoteinjector", "loadlibrary", "memoryeditor", "hexeditor", "memoryhacker", "ramhacker", "reversing", "cracking", "unpacking",
		"deobfuscator"
	};

	private static readonly HashSet<string> hashSet_1 = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
	{
		"dump", "inject", "hack", "cheat", "crack", "patch", "trainer", "debugger", "disassembler", "decompiler",
		"unpacker", "memory editor", "process explorer", "process hacker", "api monitor", "spy++", "resource hacker", "pe explorer", "cff explorer", "lordpe"
	};

	private static int int_0 = 0;

	private char char_0;

	private int int_2;

	private char char_1;

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
			return int_2;
		}
		set
		{
			int_2 = value;
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

	[DllImport("kernel32.dll")]
	private static extern nint OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

	[DllImport("kernel32.dll")]
	private static extern bool CloseHandle(nint hObject);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool ReadProcessMemory(nint hProcess, nint lpBaseAddress, byte[] lpBuffer, int dwSize, out int lpNumberOfBytesRead);

	[DllImport("psapi.dll", SetLastError = true)]
	private static extern bool EnumProcessModules(nint hProcess, [Out] nint[] lphModule, uint cb, out uint lpcbNeeded);

	[DllImport("psapi.dll", CharSet = CharSet.Auto)]
	private static extern uint GetModuleFileNameEx(nint hProcess, nint hModule, [Out] StringBuilder lpBaseName, uint nSize);

	public static void StartMonitoring()
	{
		Thread thread = new Thread((ThreadStart)delegate
		{
			//Discarded unreachable code: IL_0048, IL_0057
			Thread.Sleep(2000);
			while (true)
			{
				try
				{
					if (DetectDumpers())
					{
						int_0++;
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(54, 2);
						while (true)
						{
							defaultInterpolatedStringHandler.AppendLiteral("[AdvancedAntiDump] ⚠\ufe0f Suspicious activity detected (");
						}
					}
					if (int_0 > 0)
					{
						int_0--;
					}
				}
				catch (Exception ex)
				{
					Logger.Warn("[AdvancedAntiDump] Monitoring error: " + ex.Message);
				}
				Thread.Sleep(5000);
			}
		});
		thread.IsBackground = true;
		thread.Priority = ThreadPriority.BelowNormal;
		thread.Start();
		Logger.Info("[AdvancedAntiDump] ✅ Monitoring started (soft mode)");
	}

	public static bool DetectDumpers()
	{
		try
		{
			Process[] processes = Process.GetProcesses();
			Process currentProcess = Process.GetCurrentProcess();
			Process[] array = processes;
			foreach (Process process in array)
			{
				try
				{
					if (process.Id != currentProcess.Id && process.Id != 0 && process.Id != 4)
					{
						Logger.Warn("[AdvancedAntiDump] Suspicious process name: " + process.ProcessName);
						Logger.Warn("[AdvancedAntiDump] Suspicious window title: " + process.MainWindowTitle);
						Logger.Warn("[AdvancedAntiDump] Suspicious modules in: " + process.ProcessName);
						Logger.Warn("[AdvancedAntiDump] Suspicious executable path: " + process.ProcessName);
					}
				}
				catch
				{
				}
				finally
				{
					process.Dispose();
				}
			}
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}

	private static bool CheckProcessName(Process process)
	{
		string text = process.ProcessName.ToLower();
		foreach (string item in hashSet_0)
		{
			if (!text.Contains(item))
			{
				continue;
			}
			goto IL_017d;
		}
		string[] obj = new string[16]
		{
			"dump", "inject", "hack", "cheat", "crack", "patch", "debug", "spy", "monitor", "hook",
			"detour", "mem", "trainer", "editor", "modifier", "scanner"
		};
		int num = 0;
		string[] array = obj;
		foreach (string value in array)
		{
			if (text.Contains(value))
			{
				num++;
			}
		}
		return num >= 3;
		IL_017d:
		return true;
	}

	private static bool CheckWindowTitle(Process process)
	{
		try
		{
			if (!string.IsNullOrEmpty(process.MainWindowTitle))
			{
				string text = process.MainWindowTitle.ToLower();
				foreach (string item in hashSet_1)
				{
					if (text.Contains(item))
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}
		catch
		{
			return false;
		}
	}

	private static bool CheckLoadedModules(Process process)
	{
		try
		{
			nint num = OpenProcess(1024, bInheritHandle: false, process.Id);
			if (num == IntPtr.Zero)
			{
				return false;
			}
			try
			{
				nint[] array = new nint[1024];
				if (!EnumProcessModules(num, array, (uint)(array.Length * IntPtr.Size), out var lpcbNeeded))
				{
					return false;
				}
				int num2 = (int)(lpcbNeeded / IntPtr.Size);
				for (int i = 0; i < num2; i++)
				{
					StringBuilder stringBuilder = new StringBuilder(260);
					if (GetModuleFileNameEx(num, array[i], stringBuilder, (uint)stringBuilder.Capacity) == 0)
					{
						continue;
					}
					string text = stringBuilder.ToString().ToLower();
					string[] array2 = new string[11]
					{
						"scyllahide", "titanhide", "inject", "hook", "detour", "easyhook", "minhook", "polyhook", "deviare", "madcodehook",
						"nekohook"
					};
					foreach (string value in array2)
					{
						if (text.Contains(value))
						{
							return true;
						}
					}
				}
				return false;
			}
			finally
			{
				CloseHandle(num);
			}
		}
		catch
		{
			return false;
		}
	}

	private static bool CheckExecutablePath(Process process)
	{
		try
		{
			string text = process.MainModule?.FileName?.ToLower();
			if (!string.IsNullOrEmpty(text))
			{
				string[] array = new string[12]
				{
					"\\tools\\", "\\hacking\\", "\\cracking\\", "\\reversing\\", "\\cheats\\", "\\trainers\\", "\\mods\\", "\\inject\\", "\\debug\\", "\\re\\",
					"\\reverse\\", "\\crack\\"
				};
				int num = 0;
				while (true)
				{
					if (num < array.Length)
					{
						string value = array[num];
						if (!text.Contains(value))
						{
							num++;
							continue;
						}
						break;
					}
					return false;
				}
				return true;
			}
			return false;
		}
		catch
		{
			return false;
		}
	}
}
