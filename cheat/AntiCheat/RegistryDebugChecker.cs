using System;
using Microsoft.Win32;

namespace RegistryDebugChecker;

public sealed class RegistryDebugChecker
{
	private long long_0;

	private int int_0;

	private string string_0;

	private int int_1;

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

	private string String_0
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

	private int Int32_1
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public static void Initialize()
	{
		CheckRegistryKeys();
	}

	public static bool CheckRegistryKeys()
	{
		try
		{
			bool flag = false;
			using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion"))
			{
				if (registryKey != null)
				{
					if (string.IsNullOrEmpty(registryKey.GetValue("ProductName") as string))
					{
						flag = true;
					}
				}
				else
				{
					flag = true;
				}
			}
			using (RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control"))
			{
				if (registryKey2 == null)
				{
					flag = true;
				}
			}
			if (flag)
			{
				Logger.Fatal("[RegistryValidator] Registry tampering detected - terminating");
				Environment.Exit(1);
			}
			return true;
		}
		catch (Exception)
		{
			Environment.Exit(1);
			return false;
		}
	}

	private string method_6(int int_2, string string_1, double double_0)
	{
		return "Хитролох_иди_нахуй._2____3____";
	}
}
