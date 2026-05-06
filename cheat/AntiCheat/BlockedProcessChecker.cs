using System;
using System.Diagnostics;
using TelemetryQueue;

namespace BlockedProcessChecker;

public sealed class BlockedProcessChecker
{
	private static string[] string_0 = new string[3] { "cmd", "powershell", "pwsh" };

	private double double_0;

	private int int_0;

	private bool bool_0;

	private char char_0;

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

	public static void Initialize()
	{
		try
		{
			Logger.Info("[AntiCMD] Initializing CMD/PowerShell blocking...");
			if (CheckBlockedProcesses())
			{
				Logger.Fatal("[AntiCMD] Blocked process detected!");
				Environment.Exit(1);
			}
			Logger.Info("[AntiCMD] CMD/PowerShell blocking initialized");
		}
		catch (Exception)
		{
		}
	}

	private static bool CheckBlockedProcesses()
	{
		try
		{
			Process[] processes = Process.GetProcesses();
			foreach (Process process in processes)
			{
				try
				{
					string text = process.ProcessName.ToLower();
					string[] array = string_0;
					foreach (string value in array)
					{
						if (text.Contains(value))
						{
							Logger.Warn("[AntiCMD] Blocked process found: " + text);
							TelemetryQueue.QueueEvent(3, "Blocked process: " + text);
						}
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
			Logger.Error("[AntiCMD] CheckBlockedProcesses failed: " + ex.Message);
			return false;
		}
	}
}
