using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ProtectionSequence;

namespace AntiDumpFileMonitor;

public sealed class AntiDumpFileMonitor
{
	private class FileCheckResult
	{
		[CompilerGenerated]
		private bool m2pwc0Ft0B;

		[CompilerGenerated]
		private string? H8cwmNuJje;

		[CompilerGenerated]
		private int HAJwErusrm;

		[CompilerGenerated]
		private DateTime GOuwqm2BuV;

		private long long_0;

		private float float_0;

		private string? string_0;

		private float float_1;

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

		private string? String_0
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

		private float Single_1
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

		[SpecialName]
		[CompilerGenerated]
		public bool QDfwUgDRrH()
		{
			return m2pwc0Ft0B;
		}

		[SpecialName]
		[CompilerGenerated]
		public void X9Sw9JHwQp(bool bool_0)
		{
			m2pwc0Ft0B = bool_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public string? nrFwb96WWg()
		{
			return H8cwmNuJje;
		}

		[SpecialName]
		[CompilerGenerated]
		public void lKewrKimHu(string? string_1)
		{
			H8cwmNuJje = string_1;
		}

		[SpecialName]
		[CompilerGenerated]
		public int Oe3wuuAHWm()
		{
			return HAJwErusrm;
		}

		[SpecialName]
		[CompilerGenerated]
		public void yHTwAvXjVs(int int_0)
		{
			HAJwErusrm = int_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public DateTime LxYwFh5PZr()
		{
			return GOuwqm2BuV;
		}

		[SpecialName]
		[CompilerGenerated]
		public void yEnwIwgSvi(DateTime dateTime_0)
		{
			GOuwqm2BuV = dateTime_0;
		}
	}

	private class ProcessCacheEntry
	{
		[CompilerGenerated]
		private string VHAw4DjhUs = "";

		[CompilerGenerated]
		private bool NqtwTD5OOx;

		[CompilerGenerated]
		private DateTime VS0wNApcL3;

		private long long_0;

		private string string_1;

		public string ProcessName
		{
			[CompilerGenerated]
			get
			{
				return VHAw4DjhUs;
			}
			[CompilerGenerated]
			set
			{
				VHAw4DjhUs = value;
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

		[SpecialName]
		[CompilerGenerated]
		public bool PMjwJJ0Mi6()
		{
			return NqtwTD5OOx;
		}

		[SpecialName]
		[CompilerGenerated]
		public void Sy1wvtgvUK(bool bool_0)
		{
			NqtwTD5OOx = bool_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public DateTime EkVwOcDoin()
		{
			return VS0wNApcL3;
		}

		[SpecialName]
		[CompilerGenerated]
		public void OsHwdhEewB(DateTime dateTime_0)
		{
			VS0wNApcL3 = dateTime_0;
		}
	}

	private static Thread? thread_0;

	private static bool bool_0;

	private static readonly ConcurrentDictionary<int, ProcessCacheEntry> concurrentDictionary_0 = new ConcurrentDictionary<int, ProcessCacheEntry>();

	private static readonly ConcurrentDictionary<string, DateTime> concurrentDictionary_1 = new ConcurrentDictionary<string, DateTime>();

	private static readonly ConcurrentDictionary<int, string> concurrentDictionary_2 = new ConcurrentDictionary<int, string>();

	private static readonly ConcurrentDictionary<string, FileCheckResult> concurrentDictionary_3 = new ConcurrentDictionary<string, FileCheckResult>();

	private static readonly HashSet<string> hashSet_0 = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
	{
		"kiro", "kiro.exe", "discord", "discord.exe", "discordptb.exe", "discordcanary.exe", "chrome", "chrome.exe", "firefox", "firefox.exe",
		"msedge", "msedge.exe", "code", "code.exe", "devenv", "devenv.exe", "rider64", "rider64.exe", "explorer", "explorer.exe",
		"notepad", "notepad.exe", "notepad++", "notepad++.exe", "steam", "steam.exe", "epicgameslauncher", "epicgameslauncher.exe", "spotify", "spotify.exe",
		"obs64", "obs64.exe", "obs32", "obs32.exe", "streamlabs obs", "streamlabs obs.exe"
	};

	private static readonly HashSet<string> hashSet_1 = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
	{
		"extremedumper", "extremedumper.exe", "extremedumper-x86.exe", "extremedumper-x64.exe", "megadumper", "megadumper.exe", "ksdumper", "ksdumper.exe", "ksdumper11", "ksdumper11.exe",
		"jitdumper", "jitdumper.exe", "vmunprotect", "vmunprotect.dumper", "vmunprotect.dumper.exe", "vmunprotect.exe", "nemesis", "nemesis.exe", "nemesis.gui.exe", "memoscope",
		"memoscope.exe", "memoscope.net.exe", "dotnet-dump", "dotnet-dump.exe", "dotnet-trace", "dotnet-trace.exe", "dotnet-stack", "dotnet-stack.exe", "turdshovel", "turdshovel.exe",
		"python.exe", "pythonw.exe", "codecracker", "codecracker.exe", "dnspy", "dnspy.exe", "dnspy-x86.exe", "dnspy-x64.exe", "ilspy", "ilspy.exe",
		"ilspy-x86.exe", "ilspy-x64.exe", "de4dot", "de4dot.exe", "de4dot-x64.exe", "de4dot-x86.exe", "simpleassemblyexplorer.exe", "sae.exe", "reflexil.exe", "dotpeek",
		"dotpeek.exe", "dotpeek32.exe", "dotpeek64.exe", "justdecompile.exe", "reflector.exe", ".net reflector.exe", "x64dbg.exe", "x32dbg.exe", "x96dbg.exe", "ollydbg.exe",
		"windbg.exe", "cdb.exe", "ida.exe", "ida64.exe", "idaq.exe", "idaq64.exe", "idaw.exe", "idaw64.exe", "ghidra", "ghidrarun",
		"ghidrarun.exe", "processhacker.exe", "processhacker2.exe", "procexp.exe", "procexp64.exe", "procmon.exe", "procmon64.exe", "cheatengine-x86_64.exe", "cheatengine-i386.exe", "cheatengine.exe",
		"cheatengine-x86_64-ssdt.exe", "scylla.exe", "scylla_x64.exe", "scylla_x86.exe", "scyllahide.exe", "volatility", "volatility.exe", "rekall", "rekall.exe", "windbgx.exe",
		"kd.exe"
	};

	private static readonly string[] string_0 = new string[40]
	{
		"ExtremeDumper", "MegaDumper", "Mega Dumper", "KsDumper", "KsDumper11", "JitDumper", "VMUnprotect", "VMUnprotect.Dumper", "Nemesis", "MemoScope",
		"MemoScope.Net", "Turdshovel", "dnSpy", "ILSpy", "de4dot", "dotPeek", "JustDecompile", ".NET Reflector", "Simple Assembly Explorer", "Reflexil",
		"x64dbg", "x32dbg", "x96dbg", "OllyDbg", "WinDbg", "IDA Pro", "IDA Free", "IDA Freeware", "Ghidra", "Ghidra:",
		"Ghidra -", "Process Hacker", "Process Explorer", "Process Monitor", "Cheat Engine", "Scylla", "ScyllaHide", "dotnet-dump", "dotnet-trace", "dotnet-stack"
	};

	private static readonly Dictionary<string, string[]> dictionary_0 = new Dictionary<string, string[]>
	{
		["ExtremeDumper"] = new string[5] { "EXTREMEDUMPER_MAGIC", "C41F3A60", "ExtremeDumper.AntiAntiDump", "AADClient", "AADServer" },
		["MegaDumper"] = new string[5] { "Mega_Dumper", "DetectAntidumps", "EnumAppDomains", "HeapHealper", "MiniDmp" },
		["KsDumper"] = new string[3] { "KsDumper11", "KsDumperDriver", "DriverInterface" },
		["JitDumper"] = new string[5] { "JitDumper", "jit_hook.dll", "compile_method", "DumpedBodyReader", "CilOperandResolver" },
		["VMUnprotect"] = new string[3] { "VMUnprotect.Dumper", "VMUnprotect", "void-stack" },
		["Nemesis"] = new string[7] { "Nemesis.dll", "NemesisApi", "NemesisImports", "DumpProcessExport", "DumpModuleExport", "DumpMemoryExport", "DumpDriverExport" },
		["MemoScope"] = new string[6] { "MemoScope", "MemoScopeApi", "MemoScopeServer", "MemoScopeClient", "IClrDump", "ClrDump" },
		["MicrosoftDiagnostics"] = new string[5] { "Microsoft.Diagnostics.Tools", "dotnet-dump", "dotnet-trace", "Microsoft.Diagnostics.NETCore.Client", "Microsoft.Diagnostics.Tracing" },
		["Turdshovel"] = new string[4] { "turdshovel", "TurdShovel", "Python.NET", "ClrMD" },
		["dnSpy"] = new string[3] { "dnSpy", "ICSharpCode.Decompiler", "dnlib" },
		["ILSpy"] = new string[3] { "ILSpy", "ICSharpCode.Decompiler", "ICSharpCode.ILSpy" },
		["de4dot"] = new string[4] { "de4dot", "de4dot.code", "de4dot.cui", "de4dot.mdecrypt" },
		["dotPeek"] = new string[3] { "dotPeek", "JetBrains.dotPeek", "JetBrains.Decompiler" },
		["x64dbg"] = new string[5] { "x64dbg", "x32dbg", "TitanEngine", "x64_dbg_gui", "x64_dbg_bridge" },
		["IDA"] = new string[5] { "IDA Pro", "ida64", "idaq64", "Hex-Rays", "idapython" },
		["Ghidra"] = new string[4] { "Ghidra", "ghidra.app", "ghidra.program", "NSA" },
		["ProcessHacker"] = new string[4] { "Process Hacker", "ProcessHacker", "KProcessHacker", "phlib" },
		["CheatEngine"] = new string[6] { "Cheat Engine", "CheatEngine", "ceserver", "speedhack", "dbk32.sys", "dbk64.sys" },
		["Scylla"] = new string[4] { "Scylla", "ScyllaHide", "IATSearch", "ImportRebuild" }
	};

	private static readonly HashSet<string> hashSet_2 = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

	private static readonly Dictionary<string, byte[]> dictionary_1 = new Dictionary<string, byte[]>
	{
		["ExtremeDumper_Magic"] = Encoding.ASCII.GetBytes("C41F3A60"),
		["ExtremeDumper_Env"] = Encoding.ASCII.GetBytes("EXTREMEDUMPER_MAGIC"),
		["Dumper_String1"] = Encoding.Unicode.GetBytes("ExtremeDumper"),
		["Dumper_String2"] = Encoding.Unicode.GetBytes("MegaDumper"),
		["Dumper_String3"] = Encoding.Unicode.GetBytes("KsDumper"),
		["Dumper_String4"] = Encoding.Unicode.GetBytes("JitDumper"),
		["Dumper_String5"] = Encoding.Unicode.GetBytes("VMUnprotect"),
		["Dumper_String6"] = Encoding.Unicode.GetBytes("Nemesis.dll"),
		["Dumper_String7"] = Encoding.Unicode.GetBytes("MemoScope"),
		["Dumper_ASCII1"] = Encoding.ASCII.GetBytes("ExtremeDumper"),
		["Dumper_ASCII2"] = Encoding.ASCII.GetBytes("MegaDumper"),
		["Dumper_ASCII3"] = Encoding.ASCII.GetBytes("KsDumper"),
		["Dumper_ASCII4"] = Encoding.ASCII.GetBytes("JitDumper"),
		["Dumper_ASCII5"] = Encoding.ASCII.GetBytes("VMUnprotect.Dumper"),
		["Dumper_ASCII6"] = Encoding.ASCII.GetBytes("Nemesis"),
		["Dumper_ASCII7"] = Encoding.ASCII.GetBytes("MemoScopeApi"),
		["Namespace1"] = Encoding.Unicode.GetBytes("Mega_Dumper"),
		["Namespace2"] = Encoding.Unicode.GetBytes("Microsoft.Diagnostics.Tools"),
		["DLL_Import1"] = Encoding.ASCII.GetBytes("jit_hook.dll"),
		["DLL_Import2"] = Encoding.ASCII.GetBytes("Nemesis.dll"),
		["DLL_Import3"] = Encoding.ASCII.GetBytes("KsDumperDriver"),
		["Decompiler1"] = Encoding.Unicode.GetBytes("ICSharpCode.Decompiler"),
		["Decompiler2"] = Encoding.Unicode.GetBytes("dnlib"),
		["Decompiler3"] = Encoding.ASCII.GetBytes("de4dot"),
		["Debugger1"] = Encoding.ASCII.GetBytes("x64_dbg_bridge"),
		["Debugger2"] = Encoding.ASCII.GetBytes("TitanEngine"),
		["Debugger3"] = Encoding.ASCII.GetBytes("idapython"),
		["ProcessTool1"] = Encoding.ASCII.GetBytes("KProcessHacker"),
		["ProcessTool2"] = Encoding.ASCII.GetBytes("ceserver"),
		["ProcessTool3"] = Encoding.ASCII.GetBytes("ScyllaHide")
	};

	private int int_0;

	private double double_0;

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

	public static void StartMonitoring()
	{
		if (!bool_0)
		{
			bool_0 = true;
			thread_0 = new Thread(MonitorLoop)
			{
				IsBackground = true,
				Priority = ThreadPriority.BelowNormal,
				Name = "DumperDetector"
			};
			thread_0.Start();
			Logger.Info($"[DumperDetector] ✅ Started monitoring with {hashSet_1.Count} signatures");
		}
	}

	public static void StopMonitoring()
	{
		bool_0 = false;
		thread_0?.Join(1000);
		Logger.Info("[DumperDetector] Stopped");
	}

	private static void MonitorLoop()
	{
		while (bool_0)
		{
			try
			{
				ScanForDumpers();
				CleanupCache();
				Thread.Sleep(500);
			}
			catch (Exception ex)
			{
				Logger.Warn("[DumperDetector] Scan error: " + ex.Message);
			}
		}
	}

	private static void ScanForDumpers()
	{
		Process[] processes = Process.GetProcesses();
		int processId = Environment.ProcessId;
		HashSet<int> hashSet = new HashSet<int>();
		Process[] array = processes;
		foreach (Process process in array)
		{
			try
			{
				if (process.Id == processId)
				{
					continue;
				}
				hashSet.Add(process.Id);
				string text = process.ProcessName.ToLower();
				if (hashSet_0.Contains(text) || hashSet_0.Contains(text + ".exe") || (concurrentDictionary_0.TryGetValue(process.Id, out ProcessCacheEntry value) && value.PMjwJJ0Mi6() && (DateTime.UtcNow - value.EkVwOcDoin()).TotalMinutes < 5.0))
				{
					continue;
				}
				bool flag = false;
				string text2 = "";
				int confidenceScore = 0;
				if (hashSet_1.Contains(text) || hashSet_1.Contains(text + ".exe"))
				{
					flag = true;
					text2 = "ProcessName";
					confidenceScore = 90;
				}
				if (!flag && CheckWindowTitle(process, out string match))
				{
					flag = true;
					text2 = "WindowTitle:" + match;
					confidenceScore = 70;
				}
				if (!flag)
				{
					try
					{
						string value2 = null;
						if (!concurrentDictionary_2.TryGetValue(process.Id, out value2))
						{
							value2 = process.MainModule?.FileName;
							if (!string.IsNullOrEmpty(value2))
							{
								concurrentDictionary_2[process.Id] = value2;
							}
						}
						if (!string.IsNullOrEmpty(value2) && File.Exists(value2))
						{
							if (concurrentDictionary_3.TryGetValue(value2, out FileCheckResult value3))
							{
								if ((DateTime.UtcNow - value3.LxYwFh5PZr()).TotalMinutes >= 10.0)
								{
									concurrentDictionary_3.TryRemove(value2, out FileCheckResult _);
								}
								else if (value3.QDfwUgDRrH())
								{
									flag = true;
									text2 = value3.nrFwb96WWg() ?? "Cached";
									confidenceScore = value3.Oe3wuuAHWm();
								}
							}
							if (!flag && !concurrentDictionary_3.ContainsKey(value2))
							{
								if (CheckFileMetadata(value2, out string match2))
								{
									flag = true;
									text2 = "Metadata:" + match2;
									confidenceScore = 85;
								}
								if (!flag && CheckFileHash(value2, out string match3))
								{
									flag = true;
									text2 = "FileHash:" + match3;
									confidenceScore = 100;
								}
								if (!flag && CheckBytePatterns(value2, out string match4))
								{
									flag = true;
									text2 = "BytePattern:" + match4;
									confidenceScore = 95;
								}
								if (!flag && CheckDumperSignatures(value2, out string match5))
								{
									flag = true;
									text2 = "Signature:" + match5;
									confidenceScore = 80;
								}
								ConcurrentDictionary<string, FileCheckResult> concurrentDictionary = concurrentDictionary_3;
								string key = value2;
								FileCheckResult fileCheckResult = new FileCheckResult();
								fileCheckResult.X9Sw9JHwQp(flag);
								fileCheckResult.lKewrKimHu(text2);
								fileCheckResult.yHTwAvXjVs(confidenceScore);
								fileCheckResult.yEnwIwgSvi(DateTime.UtcNow);
								concurrentDictionary[key] = fileCheckResult;
							}
						}
					}
					catch
					{
					}
				}
				ConcurrentDictionary<int, ProcessCacheEntry> concurrentDictionary2 = concurrentDictionary_0;
				int id = process.Id;
				ProcessCacheEntry processCacheEntry = new ProcessCacheEntry();
				processCacheEntry.ProcessName = process.ProcessName;
				processCacheEntry.Sy1wvtgvUK(!flag);
				processCacheEntry.OsHwdhEewB(DateTime.UtcNow);
				concurrentDictionary2[id] = processCacheEntry;
				if (flag)
				{
					HandleThreatDetection(process, text2, confidenceScore);
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
		foreach (int item in concurrentDictionary_0.Keys.Except(hashSet).ToList())
		{
			concurrentDictionary_0.TryRemove(item, out ProcessCacheEntry _);
			concurrentDictionary_2.TryRemove(item, out string _);
		}
	}

	private static bool CheckWindowTitle(Process process, out string? match)
	{
		match = null;
		try
		{
			string mainWindowTitle = process.MainWindowTitle;
			if (string.IsNullOrEmpty(mainWindowTitle))
			{
				return false;
			}
			string[] array = string_0;
			foreach (string text in array)
			{
				if (mainWindowTitle.Contains(text, StringComparison.OrdinalIgnoreCase))
				{
					match = text;
					return true;
				}
			}
		}
		catch
		{
		}
		return false;
	}

	private static bool CheckFileMetadata(string filePath, out string? match)
	{
		match = null;
		try
		{
			FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(filePath);
			string[] array = new string[5] { versionInfo.ProductName, versionInfo.FileDescription, versionInfo.CompanyName, versionInfo.InternalName, versionInfo.OriginalFilename };
			foreach (string text in array)
			{
				if (string.IsNullOrEmpty(text))
				{
					continue;
				}
				foreach (KeyValuePair<string, string[]> item in dictionary_0)
				{
					string[] value = item.Value;
					foreach (string text2 in value)
					{
						if (text.Contains(text2, StringComparison.OrdinalIgnoreCase))
						{
							match = item.Key + ":" + text2;
							goto IL_011c;
						}
					}
				}
			}
		}
		catch
		{
		}
		return false;
		IL_011c:
		return true;
	}

	private static bool CheckFileHash(string filePath, out string? match)
	{
		match = null;
		try
		{
			using SHA256 sHA = SHA256.Create();
			using FileStream inputStream = File.OpenRead(filePath);
			string text = BitConverter.ToString(sHA.ComputeHash(inputStream)).Replace("-", "");
			if (hashSet_2.Contains(text))
			{
				match = text.Substring(0, 16) + "...";
				goto IL_007a;
			}
		}
		catch
		{
		}
		return false;
		IL_007a:
		return true;
	}

	private static bool CheckBytePatterns(string filePath, out string? match)
	{
		//IL_0018: Expected I8, but got I4
		match = null;
		try
		{
			byte[] array = new byte[Math.Min(1048576L, new FileInfo(filePath).Length)];
			using (FileStream fileStream = File.OpenRead(filePath))
			{
				fileStream.Read(array, 0, array.Length);
			}
			foreach (KeyValuePair<string, byte[]> item in dictionary_1)
			{
				if (ContainsPattern(array, item.Value))
				{
					match = item.Key;
					goto IL_0097;
				}
			}
		}
		catch
		{
		}
		return false;
		IL_0097:
		return true;
	}

	private static bool CheckDumperSignatures(string filePath, out string? match)
	{
		match = null;
		try
		{
			string text = File.ReadAllText(filePath, Encoding.UTF8);
			foreach (KeyValuePair<string, string[]> item in dictionary_0)
			{
				int num = 0;
				List<string> list = new List<string>();
				string[] value = item.Value;
				foreach (string text2 in value)
				{
					if (text.Contains(text2, StringComparison.OrdinalIgnoreCase))
					{
						num++;
						list.Add(text2);
					}
				}
				if (num >= 3)
				{
					match = $"{item.Key}({num} matches: {string.Join(", ", list.Take(3))})";
					goto IL_012b;
				}
			}
		}
		catch
		{
		}
		return false;
		IL_012b:
		return true;
	}

	private static bool ContainsPattern(byte[] buffer, byte[] pattern)
	{
		int num = 0;
		while (true)
		{
			if (num > buffer.Length - pattern.Length)
			{
				return false;
			}
			bool flag = true;
			for (int i = 0; i < pattern.Length; i++)
			{
				if (buffer[num + i] != pattern[i])
				{
					flag = false;
					break;
				}
			}
			if (!flag)
			{
				num++;
				continue;
			}
			break;
		}
		return true;
	}

	private static void HandleThreatDetection(Process threat, string detectionMethod, int confidenceScore)
	{
		//IL_012a: Expected I8, but got I4
		string MB0wM6KvHq;
		int ENYwfHoAas;
		string SOlweoc4H5;
		try
		{
			MB0wM6KvHq = threat.ProcessName;
			ENYwfHoAas = threat.Id;
			SOlweoc4H5 = GetProcessFilePath(threat);
		}
		catch (Exception ex)
		{
			Logger.Error("[DumperDetector] Failed to get process info: " + ex.Message);
			return;
		}
		string key = $"{MB0wM6KvHq}_{ENYwfHoAas}";
		if (concurrentDictionary_1.TryGetValue(key, out var value) && (DateTime.UtcNow - value).TotalSeconds < 30.0)
		{
			return;
		}
		concurrentDictionary_1[key] = DateTime.UtcNow;
		Logger.Fatal($"[DumperDetector] ❌ THREAT DETECTED: {MB0wM6KvHq} (PID: {ENYwfHoAas})");
		Logger.Fatal($"[DumperDetector] Detection: {detectionMethod} | Confidence: {confidenceScore}%");
		Logger.Fatal("[DumperDetector] \ud83d\udea8 EXECUTING PROTECTION SEQUENCE...");
		Task task = Task.Run(async delegate
		{
			try
			{
				await ExecuteProtectionSequence(MB0wM6KvHq, ENYwfHoAas, SOlweoc4H5, detectionMethod, confidenceScore);
			}
			catch (Exception ex3)
			{
				Logger.Error("[DumperDetector] Protection sequence failed: " + ex3.Message);
				Logger.Error("[DumperDetector] Stack trace: " + ex3.StackTrace);
				Logger.Fatal("[DumperDetector] \ud83d\uded1 FORCE TERMINATING APPLICATION");
				Environment.Exit(57005);
			}
		});
		try
		{
			task.Wait(TimeSpan.FromSeconds(15L));
		}
		catch (Exception ex2)
		{
			Logger.Error("[DumperDetector] Failed to wait for protection sequence: " + ex2.Message);
		}
	}

	private static async Task ExecuteProtectionSequence(string processName, int processId, string? filePath, string detectionMethod, int confidenceScore)
	{
		try
		{
			Logger.Info($"[DumperDetector] Starting protection sequence for {processName} (PID: {processId})");
			string threatDescription = $"{processName} (PID: {processId}) | Method: {detectionMethod} | Confidence: {confidenceScore}%";
			var additionalData = new
			{
				process_name = processName,
				process_id = processId,
				detection_method = detectionMethod,
				confidence_score = confidenceScore,
				file_path = filePath
			};
			Logger.Info("[DumperDetector] Calling SecurityResponseHandler.ExecuteProtectionSequenceAsync...");
			Process threatProcess = null;
			try
			{
				threatProcess = Process.GetProcessById(processId);
				Logger.Info($"[DumperDetector] Found threat process by ID {processId}");
			}
			catch (Exception ex)
			{
				Logger.Warn($"[DumperDetector] Could not get process by ID {processId}: {ex.Message}");
				Logger.Warn("[DumperDetector] Process may have already exited. Continuing with protection sequence...");
			}
			await ProtectionSequence.ExecuteProtectionSequenceAsync("dump_tool_detected", threatDescription, threatProcess, additionalData);
			Logger.Info("[DumperDetector] Protection sequence completed");
		}
		catch (Exception ex2)
		{
			Logger.Error("[DumperDetector] ExecuteProtectionSequence error: " + ex2.Message);
			Logger.Error("[DumperDetector] Stack: " + ex2.StackTrace);
			throw;
		}
	}

	private static string? GetProcessFilePath(Process process)
	{
		try
		{
			return process.MainModule?.FileName;
		}
		catch
		{
			return null;
		}
	}

	private static void CleanupCache()
	{
		DateTime value = DateTime.UtcNow;
		DateTime ITKwonpZpb = value.AddMinutes(-10.0);
		foreach (int item in (from kvp in concurrentDictionary_0
			where kvp.Value.EkVwOcDoin() < ITKwonpZpb
			select kvp.Key).ToList())
		{
			concurrentDictionary_0.TryRemove(item, out ProcessCacheEntry _);
		}
		foreach (string item2 in (from kvp in concurrentDictionary_1
			where (DateTime.UtcNow - kvp.Value).TotalMinutes > 5.0
			select kvp.Key).ToList())
		{
			concurrentDictionary_1.TryRemove(item2, out value);
		}
	}
}
