using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Threading;
using TelemetryHttpClient;
using HwidProvider;

namespace PatchTamperingValidator;

public sealed class PatchTamperingValidator
{
	private static bool bool_0;

	private bool bool_1;

	private float float_0;

	private char char_1;

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

	public static void StartMonitoring()
	{
		if (bool_0)
		{
			return;
		}
		bool_0 = true;
		if (!ValidateMainPatchInMemory())
		{
			Logger.Fatal("[EnvironmentValidator] ❌ SECURITY VIOLATION!");
			Logger.Fatal("[EnvironmentValidator] ❌ Main patch is loaded from disk!");
			Logger.Fatal("[EnvironmentValidator] ❌ Patch must be loaded from memory only");
			Logger.Fatal("[EnvironmentValidator] ❌ This indicates a cracked version");
			SendSecurityAlert("main_patch_on_disk", "Main patch loaded from disk instead of memory");
			Thread.Sleep(3000);
			Environment.Exit(1);
			return;
		}
		Logger.Info("[EnvironmentValidator] ⚠\ufe0f Dependencies validation disabled (dropper uses disk cache)");
		if (!ValidateParentProcess())
		{
			Logger.Warn("[EnvironmentValidator] ⚠\ufe0f Parent process validation failed");
			Logger.Warn("[EnvironmentValidator] ⚠\ufe0f This may indicate unusual launch method");
			try
			{
				Process? parentProcess = GetParentProcess(Process.GetCurrentProcess());
				object obj;
				if (parentProcess != null)
				{
					obj = parentProcess.ProcessName;
					if (obj != null)
					{
						goto IL_00a2;
					}
				}
				else
				{
					obj = null;
				}
				obj = "unknown";
				goto IL_00a2;
				IL_00a2:
				string text = (string)obj;
				SendSecurityAlert("invalid_parent_process", "Parent process is not expected: " + text);
			}
			catch
			{
				SendSecurityAlert("invalid_parent_process", "Parent process is not expected");
			}
		}
		if (!ValidateLoadMethod())
		{
			Logger.Fatal("[EnvironmentValidator] ❌ SECURITY VIOLATION!");
			Logger.Fatal("[EnvironmentValidator] ❌ Patch loaded using incorrect method!");
			Logger.Fatal("[EnvironmentValidator] ❌ Expected: Assembly.Load from memory");
			SendSecurityAlert("invalid_load_method", "Patch loaded using LoadFile or LoadFrom instead of Load");
			Thread.Sleep(3000);
			Environment.Exit(1);
		}
		else if (!ValidateNoPatchFilesNearGame())
		{
			Logger.Fatal("[EnvironmentValidator] ❌ SECURITY VIOLATION!");
			Logger.Fatal("[EnvironmentValidator] ❌ Patch DLL files found near game executable!");
			Logger.Fatal("[EnvironmentValidator] ❌ This indicates disk-based crack attempt");
			SendSecurityAlert("patch_files_near_game", "Kaban.cc.dll or related files found near game");
			Thread.Sleep(3000);
			Environment.Exit(1);
		}
		else
		{
			if (!ValidateProcessCreationTime())
			{
				Logger.Warn("[EnvironmentValidator] ⚠\ufe0f Process creation time validation failed");
				Logger.Warn("[EnvironmentValidator] ⚠\ufe0f Process may have been running for too long");
				SendSecurityAlert("suspicious_process_age", "Process running for unusually long time");
			}
			StartPeriodicValidation();
		}
	}

	private static bool ValidateMainPatchInMemory()
	{
		try
		{
			string location = Assembly.GetExecutingAssembly().Location;
			if (string.IsNullOrEmpty(location))
			{
				return true;
			}
			if (File.Exists(location))
			{
				return false;
			}
			Logger.Info("[EnvironmentValidator] Assembly location: " + location + " (file not found - OK)");
			return true;
		}
		catch (Exception)
		{
			return true;
		}
	}

	private static bool ValidateDependenciesNotOnDisk()
	{
		try
		{
			string text = Process.GetCurrentProcess().MainModule?.FileName;
			if (!string.IsNullOrEmpty(text))
			{
				string directoryName = Path.GetDirectoryName(text);
				if (!string.IsNullOrEmpty(directoryName))
				{
					string[] array = new string[5] { "Kaban.cc.dll", "Harmony.dll", "0Harmony.dll", "Newtonsoft.Json.dll", "System.Drawing.Common.dll" };
					string[] array2 = array;
					int num = 0;
					string text4;
					while (true)
					{
						if (num >= array2.Length)
						{
							string text2 = Path.Combine(directoryName, "bin");
							if (Directory.Exists(text2))
							{
								array2 = array;
								foreach (string path in array2)
								{
									string text3 = Path.Combine(text2, path);
									if (File.Exists(text3))
									{
										Logger.Fatal("[EnvironmentValidator] Found suspicious DLL in bin: " + text3);
										return false;
									}
								}
							}
							return true;
						}
						string path2 = array2[num];
						text4 = Path.Combine(directoryName, path2);
						if (File.Exists(text4))
						{
							break;
						}
						num++;
					}
					Logger.Fatal("[EnvironmentValidator] Found suspicious DLL: " + text4);
					return false;
				}
				return true;
			}
			return true;
		}
		catch (Exception)
		{
			return true;
		}
	}

	private static bool ValidateParentProcess()
	{
		try
		{
			Process parentProcess = GetParentProcess(Process.GetCurrentProcess());
			if (parentProcess == null)
			{
				return true;
			}
			string k9lwgZKsTT = parentProcess.ProcessName.ToLower();
			if (new string[12]
			{
				"explorer", "cmd", "powershell", "openloader", "devenv", "rider64", "robust.loader", "ss14.loader", "loader", "spacestationmultiplayerclient",
				"ss14", "services"
			}.Any((string p) => k9lwgZKsTT.Contains(p)))
			{
				return true;
			}
			return false;
		}
		catch (Exception)
		{
			return true;
		}
	}

	private static bool ValidateLoadMethod()
	{
		try
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (string.IsNullOrEmpty(executingAssembly.Location))
			{
				return true;
			}
			string location = executingAssembly.Location;
			if (!File.Exists(location))
			{
				return true;
			}
			Logger.Fatal("[EnvironmentValidator] Assembly loaded from file: " + location);
			return false;
		}
		catch (Exception ex)
		{
			Logger.Warn("[EnvironmentValidator] Error checking load method: " + ex.Message);
			return true;
		}
	}

	private static bool ValidateNoPatchFilesNearGame()
	{
		try
		{
			string text = Process.GetCurrentProcess().MainModule?.FileName;
			if (!string.IsNullOrEmpty(text))
			{
				string directoryName = Path.GetDirectoryName(text);
				if (string.IsNullOrEmpty(directoryName))
				{
					return true;
				}
				string[] array = new string[4] { "Kaban.cc.dll", "KabanDropper.exe", "KabanDropper.dll", "OpenLoader.exe" };
				string[] array2 = array;
				int num = 0;
				while (true)
				{
					if (num < array2.Length)
					{
						string path = array2[num];
						string text2 = Path.Combine(directoryName, path);
						if (File.Exists(text2))
						{
							Logger.Fatal("[EnvironmentValidator] Found patch file near game: " + text2);
							FileInfo fileInfo = new FileInfo(text2);
							if ((DateTime.Now - fileInfo.CreationTime).TotalMinutes < 10.0)
							{
								Logger.Fatal($"[EnvironmentValidator] File was created recently: {fileInfo.CreationTime}");
								return false;
							}
						}
						num++;
						continue;
					}
					array2 = new string[4] { "bin", "mods", "plugins", "addons" };
					foreach (string path2 in array2)
					{
						string text3 = Path.Combine(directoryName, path2);
						if (!Directory.Exists(text3))
						{
							continue;
						}
						string[] array3 = array;
						foreach (string path3 in array3)
						{
							string text4 = Path.Combine(text3, path3);
							if (File.Exists(text4))
							{
								Logger.Fatal("[EnvironmentValidator] Found patch file in subfolder: " + text4);
								return false;
							}
						}
					}
					break;
				}
				return true;
			}
			return true;
		}
		catch (Exception ex)
		{
			Logger.Warn("[EnvironmentValidator] Error checking patch files: " + ex.Message);
			return true;
		}
	}

	private static bool ValidateProcessCreationTime()
	{
		try
		{
			Process currentProcess = Process.GetCurrentProcess();
			TimeSpan timeSpan = DateTime.Now - currentProcess.StartTime;
			if (timeSpan.TotalHours <= 12.0)
			{
				return true;
			}
			Logger.Warn($"[EnvironmentValidator] Process running for {timeSpan.TotalHours:F1} hours");
			return false;
		}
		catch (Exception ex)
		{
			Logger.Warn("[EnvironmentValidator] Error checking process age: " + ex.Message);
			return true;
		}
	}

	private static Process? GetParentProcess(Process process)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		try
		{
			ManagementObjectSearcher val = new ManagementObjectSearcher($"SELECT ParentProcessId FROM Win32_Process WHERE ProcessId = {process.Id}");
			try
			{
				ManagementObjectEnumerator enumerator = val.Get().GetEnumerator();
				try
				{
					if (enumerator.MoveNext())
					{
						return Process.GetProcessById(Convert.ToInt32(enumerator.Current["ParentProcessId"]));
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
		return null;
	}

	private static void StartPeriodicValidation()
	{
		Thread thread = new Thread((ThreadStart)delegate
		{
			do
			{
				Thread.Sleep(300000);
				if (!ValidateMainPatchInMemory())
				{
					Logger.Fatal("[EnvironmentValidator] ❌ Runtime check failed: Patch on disk!");
					SendSecurityAlert("runtime_patch_on_disk", "Patch appeared on disk during runtime");
					Thread.Sleep(2000);
					Environment.Exit(1);
					return;
				}
			}
			while (ValidateNoPatchFilesNearGame());
			Logger.Fatal("[EnvironmentValidator] ❌ Runtime check failed: Patch files near game!");
			SendSecurityAlert("runtime_patch_files_near_game", "Patch files appeared near game during runtime");
			Thread.Sleep(2000);
			Environment.Exit(1);
		});
		thread.IsBackground = true;
		thread.Priority = ThreadPriority.BelowNormal;
		thread.Start();
	}

	private static void SendSecurityAlert(string eventType, string message)
	{
		try
		{
			string orCreateHWID = HwidProvider.GetOrCreateHWID();
			string apiUrl = "http://localhost:3001";
			TelemetryHttpClient.SendSecurityEventAsync(orCreateHWID, eventType, message, new
			{
				assemblyLocation = Assembly.GetExecutingAssembly().Location,
				processPath = Process.GetCurrentProcess().MainModule?.FileName,
				timestamp = DateTime.UtcNow
			}, apiUrl);
		}
		catch (Exception ex)
		{
			Logger.Warn("[EnvironmentValidator] Failed to send security alert: " + ex.Message);
		}
	}
}
