using System;
using System.Diagnostics;
using System.Reflection;
using TelemetryQueue;

namespace AssemblyComparisonChecker;

public sealed class AssemblyComparisonChecker
{
	private long long_0;

	private int int_0;

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
			if (!CompareAssemblies())
			{
				Logger.Fatal("[AssemblyValidator] Assembly mismatch detected!");
				Environment.Exit(1);
			}
			if (CheckParentProcess())
			{
				Logger.Fatal("[AssemblyValidator] Suspicious parent process!");
				Environment.Exit(1);
			}
			if (CheckLoadedModules())
			{
				Logger.Fatal("[AssemblyValidator] Suspicious modules loaded!");
				Environment.Exit(1);
			}
		}
		catch (Exception)
		{
		}
	}

	public static bool CompareAssemblies()
	{
		try
		{
			Assembly? entryAssembly = Assembly.GetEntryAssembly();
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (!(entryAssembly == null))
			{
				_ = executingAssembly == null;
			}
			return true;
		}
		catch (Exception)
		{
			return true;
		}
	}

	public static bool CheckParentProcess()
	{
		try
		{
			string[] obj = new string[5] { "dnspy", "ilspy", "powershell", "devenv", "rider" };
			string text = Process.GetCurrentProcess().ProcessName.ToLower();
			string[] array = obj;
			int num = 0;
			while (true)
			{
				if (num >= array.Length)
				{
					return false;
				}
				string value = array[num];
				if (!text.Contains(value))
				{
					num++;
					continue;
				}
				break;
			}
			TelemetryQueue.QueueEvent(0, "Blacklisted parent: " + text);
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public static bool CheckLoadedModules()
	{
		try
		{
			string[] array = new string[4] { "harmony", "dnlib", "easyhook", "inject" };
			foreach (ProcessModule module in Process.GetCurrentProcess().Modules)
			{
				string text = module.ModuleName.ToLower();
				string[] array2 = array;
				foreach (string value in array2)
				{
					if (text.Contains(value))
					{
						Logger.Warn("[AssemblyValidator] Suspicious module: " + text);
						TelemetryQueue.QueueEvent(3, "Suspicious module: " + text);
					}
				}
			}
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}
}
