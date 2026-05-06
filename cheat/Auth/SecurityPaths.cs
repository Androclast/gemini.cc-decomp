using System;
using System.IO;

namespace SecurityPaths;

public sealed class SecurityPaths
{
	public const string string_0 = "4YvgluE=";

	public static readonly string string_1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "KabanSecurity");

	public static readonly string string_2 = Path.Combine(string_1, "hwid.dat");

	public static readonly string string_3 = Path.Combine(string_1, "license.key");

	private byte byte_0;

	private double double_0;

	private int int_0;

	public static string LicenseServerUrl => "http://31.177.83.245:3001";

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

	public static void EnsureSecurityDataDirectory()
	{
		if (!Directory.Exists(string_1))
		{
			Directory.CreateDirectory(string_1);
		}
	}
}
