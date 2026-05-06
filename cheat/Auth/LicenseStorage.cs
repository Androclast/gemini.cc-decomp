using System.IO;
using SecurityPaths;

namespace LicenseStorage;

public sealed class LicenseStorage
{
	private byte byte_0;

	private int int_0;

	private double double_1;

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
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public static bool LicenseExists()
	{
		return File.Exists(SecurityPaths.string_3);
	}

	public static string? LoadLicense()
	{
		if (File.Exists(SecurityPaths.string_3))
		{
			try
			{
				string text = File.ReadAllText(SecurityPaths.string_3);
				if (!string.IsNullOrWhiteSpace(text))
				{
					return text;
				}
				return null;
			}
			catch
			{
				return null;
			}
		}
		return null;
	}

	public static void SaveLicense(string licenseKey)
	{
		SecurityPaths.EnsureSecurityDataDirectory();
		File.WriteAllText(SecurityPaths.string_3, licenseKey);
	}

	public static void DeleteLicense()
	{
		if (File.Exists(SecurityPaths.string_3))
		{
			File.Delete(SecurityPaths.string_3);
		}
	}

	private string method_8(long long_0, bool bool_0, bool bool_1)
	{
		return "Хитролох_иди_нахуй.____6__2___9__________";
	}
}
