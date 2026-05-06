using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TelemetryHttpClient;
using HwidProvider;
using LicenseStorage;

namespace WatermarkValidator;

public sealed class WatermarkValidator
{
	private static bool bool_0;

	private long long_0;

	private bool bool_1;

	private string string_0;

	private long long_1;

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

	private long Int64_1
	{
		get
		{
			return long_1;
		}
		set
		{
			long_1 = value;
		}
	}

	public static void ValidateWatermark()
	{
		if (bool_0)
		{
			return;
		}
		try
		{
			string environmentVariable = Environment.GetEnvironmentVariable("KABAN_LAUNCHER_WATERMARK");
			if (string.IsNullOrEmpty(environmentVariable))
			{
				Logger.Fatal("[WatermarkValidator] ❌ WATERMARK NOT FOUND!");
				SendSecurityAlert("watermark_missing", "Watermark environment variable not found");
				Environment.Exit(1);
			}
			else if (!VerifyWatermarkSignature(environmentVariable))
			{
				Logger.Fatal("[WatermarkValidator] ❌ INVALID WATERMARK SIGNATURE!");
				Logger.Fatal("[WatermarkValidator] Watermark verification failed - possible tampering detected!");
				SendSecurityAlert("watermark_invalid", "Invalid watermark signature: " + environmentVariable.Substring(0, Math.Min(16, environmentVariable.Length)) + "...");
				Environment.Exit(1);
			}
			else if (VerifyWatermarkTimestamp(environmentVariable))
			{
				bool_0 = true;
				Environment.SetEnvironmentVariable("KABAN_LAUNCHER_WATERMARK", null);
			}
			else
			{
				Logger.Fatal("[WatermarkValidator] ❌ WATERMARK EXPIRED!");
				Logger.Fatal("[WatermarkValidator] Watermark is too old - possible replay attack!");
				SendSecurityAlert("watermark_expired", "Watermark timestamp verification failed");
				Environment.Exit(1);
			}
		}
		catch (Exception ex)
		{
			Logger.Fatal("[WatermarkValidator] ❌ Watermark validation error: " + ex.Message);
			SendSecurityAlert("watermark_error", ex.Message);
			Environment.Exit(1);
		}
	}

	private static bool VerifyWatermarkSignature(string watermark)
	{
		try
		{
			string[] array = watermark.Split('|');
			if (array.Length == 2)
			{
				string timestamp = array[0];
				string a = array[1];
				string b = CalculateWatermarkSignature(timestamp);
				return ConstantTimeEquals(a, b);
			}
			Logger.Warn("[WatermarkValidator] Invalid watermark format");
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}

	private static bool VerifyWatermarkTimestamp(string watermark)
	{
		try
		{
			string[] array = watermark.Split('|');
			if (array.Length == 2)
			{
				if (long.TryParse(array[0], out var result))
				{
					DateTime utcDateTime = DateTimeOffset.FromUnixTimeSeconds(result).UtcDateTime;
					TimeSpan timeSpan = DateTime.UtcNow - utcDateTime;
					if (timeSpan.TotalMinutes <= 5.0)
					{
						if (timeSpan.TotalMinutes >= -1.0)
						{
							return true;
						}
						return false;
					}
					return false;
				}
				Logger.Warn("[WatermarkValidator] Invalid timestamp format");
				return false;
			}
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}

	private static string CalculateWatermarkSignature(string timestamp)
	{
		using HMACSHA256 hMACSHA = new HMACSHA256(Encoding.UTF8.GetBytes("KabanCC_Launcher_Secret_2024_v3"));
		return Convert.ToBase64String(hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(timestamp)));
	}

	private static bool ConstantTimeEquals(string a, string b)
	{
		if (a == null || b == null)
		{
			return false;
		}
		if (a.Length != b.Length)
		{
			return false;
		}
		int num = 0;
		for (int i = 0; i < a.Length; i++)
		{
			num |= a[i] ^ b[i];
		}
		return num == 0;
	}

	private static void SendSecurityAlert(string alertType, string details)
	{
		Task.Run(async delegate
		{
			try
			{
				string orCreateHWID = HwidProvider.GetOrCreateHWID();
				string value = LicenseStorage.LoadLicense();
				if (!string.IsNullOrEmpty(orCreateHWID) && !string.IsNullOrEmpty(value))
				{
					await TelemetryHttpClient.SendSecurityEventAsync(orCreateHWID, alertType, details, new
					{
						timestamp = DateTime.UtcNow
					});
				}
			}
			catch
			{
			}
		});
	}

	public static string GenerateWatermark()
	{
		long value = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
		string value2 = CalculateWatermarkSignature(value.ToString());
		return $"{value}|{value2}";
	}
}
