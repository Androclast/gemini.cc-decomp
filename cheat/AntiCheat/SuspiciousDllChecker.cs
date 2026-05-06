using System;
using System.Diagnostics;
using TelemetryQueue;

namespace SuspiciousDllChecker;

public sealed class SuspiciousDllChecker
{
	private static string[] string_0 = new string[4] { "inject.dll", "hook.dll", "detour.dll", "easyhook" };

	private long long_0;

	private byte byte_0;

	private bool bool_0;

	private bool bool_1;

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

	private byte Byte_0
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
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

	private bool Boolean_1
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

	public static void Initialize()
	{
		try
		{
			Logger.Info("[AntiDLL] Initializing DLL blocking...");
			if (CheckSuspiciousDLLs())
			{
				Logger.Fatal("[AntiDLL] Suspicious DLL detected!");
				Environment.Exit(1);
			}
			Logger.Info("[AntiDLL] DLL blocking initialized");
		}
		catch (Exception)
		{
		}
	}

	private static bool CheckSuspiciousDLLs()
	{
		try
		{
			foreach (ProcessModule module in Process.GetCurrentProcess().Modules)
			{
				string text = module.ModuleName.ToLower();
				string[] array = string_0;
				foreach (string value in array)
				{
					if (text.Contains(value))
					{
						TelemetryQueue.QueueEvent(3, "Blacklisted DLL: " + text);
						return true;
					}
				}
			}
			return false;
		}
		catch (Exception ex)
		{
			Logger.Error("[AntiDLL] CheckSuspiciousDLLs failed: " + ex.Message);
			return false;
		}
	}

	private string method_5(int int_2)
	{
		return "Хитролох_иди_нахуй._______7_6_5__9_";
	}
}
