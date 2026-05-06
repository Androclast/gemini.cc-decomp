using System;
using System.Threading;
using ConfigManager;

namespace ConfigAutoSaver;

public sealed class ConfigAutoSaver
{
	private static Timer timer_0;

	private static bool bool_0 = false;

	private static readonly object object_0 = new object();

	private static string string_0 = "default";

	private bool bool_1;

	private char char_0;

	private string string_1;

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

	public static void Initialize(string configName = "default")
	{
		//IL_002c: Expected I8, but got I4
		//IL_0036: Expected I8, but got I4
		string_0 = configName;
		timer_0 = new Timer(SaveIfDirty, null, TimeSpan.FromSeconds(5L), TimeSpan.FromSeconds(5L));
	}

	public static void MarkDirty()
	{
	}

	public static void SetConfigName(string name)
	{
		lock (object_0)
		{
			string_0 = name;
		}
	}

	public static void ForceSave()
	{
		try
		{
			ConfigManager.SaveConfig(string_0);
			lock (object_0)
			{
				bool_0 = false;
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("[ConfigAutoSaver] Error saving config: " + ex.Message);
		}
	}

	private static void SaveIfDirty(object state)
	{
		bool flag = false;
		lock (object_0)
		{
			flag = bool_0;
		}
		if (flag)
		{
			ForceSave();
		}
	}

	public static void Shutdown()
	{
		timer_0?.Dispose();
		if (bool_0)
		{
			ForceSave();
		}
	}
}
