using System;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace WineDetector;

public sealed class WineDetector
{
	private static volatile bool bool_0 = false;

	private static readonly object object_0 = new object();

	private byte byte_0;

	private float float_0;

	private float float_1;

	private char char_1;

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

	[DllImport("ntdll.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	private static extern nint wine_get_version();

	public static void CheckOnce()
	{
		if (bool_0)
		{
			return;
		}
		lock (object_0)
		{
			if (!bool_0)
			{
				bool_0 = true;
				if (IsWine())
				{
					Environment.Exit(1);
				}
			}
		}
	}

	private static bool IsWine()
	{
		if (CheckWineGetVersion())
		{
			return true;
		}
		if (!CheckWineRegistry())
		{
			return false;
		}
		return true;
	}

	private static bool CheckWineGetVersion()
	{
		try
		{
			wine_get_version();
			return true;
		}
		catch (EntryPointNotFoundException)
		{
			return false;
		}
		catch
		{
			return false;
		}
	}

	private static bool CheckWineRegistry()
	{
		try
		{
			using RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software\\Wine");
			return registryKey != null;
		}
		catch
		{
			return false;
		}
	}
}
