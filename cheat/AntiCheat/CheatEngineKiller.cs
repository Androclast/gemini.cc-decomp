using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CheatEngineKiller;

public sealed class CheatEngineKiller
{
	private static string[] string_0 = new string[3] { "cheatengine", "cheatengine-x86_64", "cheatengine-i386" };

	private double double_0;

	private bool bool_0;

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

	[DllImport("kernel32.dll")]
	private static extern nint OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

	[DllImport("kernel32.dll")]
	private static extern bool TerminateProcess(nint hProcess, uint uExitCode);

	[DllImport("kernel32.dll")]
	private static extern bool CloseHandle(nint hObject);

	public static void Initialize()
	{
		try
		{
			if (DetectAndKillCheatEngine())
			{
				Logger.Fatal("[CheatEngineDetector] Cheat Engine detected and terminated!");
				Environment.Exit(1);
			}
		}
		catch (Exception)
		{
		}
	}

	private static bool DetectAndKillCheatEngine()
	{
		try
		{
			Process[] processes = Process.GetProcesses();
			bool result = false;
			Process[] array = processes;
			foreach (Process process in array)
			{
				try
				{
					string text = process.ProcessName.ToLower();
					string[] array2 = string_0;
					foreach (string value in array2)
					{
						if (text.Contains(value))
						{
							Logger.Fatal("[CheatEngineDetector] Cheat Engine found: " + text);
							nint num = OpenProcess(1, bInheritHandle: false, process.Id);
							if (num != IntPtr.Zero)
							{
								TerminateProcess(num, 1u);
								CloseHandle(num);
							}
							result = true;
						}
					}
				}
				catch
				{
				}
			}
			return result;
		}
		catch (Exception)
		{
			return false;
		}
	}
}
