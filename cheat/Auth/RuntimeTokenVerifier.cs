using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TelemetryHttpClient;
using HwidProvider;
using LicenseStorage;

namespace RuntimeTokenVerifier;

public sealed class RuntimeTokenVerifier
{
	private static bool bool_0;

	private int int_1;

	private float float_0;

	private float float_1;

	private long long_0;

	private int Int32_0
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

	public static void VerifyRuntimeContext()
	{
		if (bool_0)
		{
			return;
		}
		try
		{
			Logger.Info("[DropperWatermark] Validating dropper watermark...");
			string environmentVariable = Environment.GetEnvironmentVariable("KABAN_DROPPER_WATERMARK");
			if (!string.IsNullOrEmpty(environmentVariable))
			{
				if (ValidateTokenSignature(environmentVariable))
				{
					if (ValidateTokenTimestamp(environmentVariable))
					{
						bool_0 = true;
						Logger.Info("[DropperWatermark] ✅ Dropper watermark validated successfully");
						Environment.SetEnvironmentVariable("KABAN_DROPPER_WATERMARK", null);
					}
					else
					{
						Logger.Fatal("[DropperWatermark] ❌ DROPPER WATERMARK EXPIRED!");
						Logger.Fatal("[DropperWatermark] ❌ Watermark is too old - possible replay attack!");
						ReportSecurityIncident("dropper_watermark_expired", "Dropper watermark timestamp verification failed");
						Environment.Exit(57005);
					}
				}
				else
				{
					Logger.Fatal("[DropperWatermark] ❌ INVALID DROPPER WATERMARK!");
					Logger.Fatal("[DropperWatermark] ❌ Watermark signature verification failed!");
					Logger.Fatal("[DropperWatermark] ❌ This indicates fake/modified dropper!");
					ReportSecurityIncident("dropper_watermark_invalid", "Invalid dropper watermark: " + environmentVariable.Substring(0, Math.Min(16, environmentVariable.Length)) + "...");
					Environment.Exit(57005);
				}
			}
			else
			{
				Logger.Fatal("[DropperWatermark] ❌ DROPPER WATERMARK NOT FOUND!");
				Logger.Fatal("[DropperWatermark] ❌ Patch must be loaded by official KabanDropper!");
				Logger.Fatal("[DropperWatermark] ❌ Direct execution is not allowed!");
				ReportSecurityIncident("dropper_watermark_missing", "Dropper watermark not found - possible fake dropper");
				Environment.Exit(57005);
			}
		}
		catch (Exception ex)
		{
			Logger.Fatal("[DropperWatermark] ❌ Watermark validation error: " + ex.Message);
			ReportSecurityIncident("dropper_watermark_error", ex.Message);
			Environment.Exit(57005);
		}
	}

	private static bool ValidateTokenSignature(string token)
	{
		try
		{
			string[] array = token.Split('|');
			if (array.Length == 3)
			{
				string timestamp = array[0];
				string identifier = array[1];
				string a = array[2];
				string b = ComputeSignature(timestamp, identifier);
				bool num = CompareSecure(a, b);
				if (!num)
				{
					Logger.Warn("[DropperWatermark] Signature mismatch");
				}
				return num;
			}
			Logger.Warn("[DropperWatermark] Invalid watermark format (expected 3 parts)");
			return false;
		}
		catch (Exception ex)
		{
			Logger.Error("[DropperWatermark] Signature verification error: " + ex.Message);
			return false;
		}
	}

	private static bool ValidateTokenTimestamp(string token)
	{
		try
		{
			string[] array = token.Split('|');
			if (array.Length == 3)
			{
				if (long.TryParse(array[0], out var result))
				{
					DateTime utcDateTime = DateTimeOffset.FromUnixTimeSeconds(result).UtcDateTime;
					TimeSpan timeSpan = DateTime.UtcNow - utcDateTime;
					if (timeSpan.TotalMinutes <= 10.0)
					{
						if (timeSpan.TotalMinutes >= -2.0)
						{
							return true;
						}
						Logger.Warn($"[DropperWatermark] Watermark from future: {timeSpan.TotalMinutes:F1} minutes");
						return false;
					}
					Logger.Warn($"[DropperWatermark] Watermark too old: {timeSpan.TotalMinutes:F1} minutes");
					return false;
				}
				Logger.Warn("[DropperWatermark] Invalid timestamp format");
				return false;
			}
			return false;
		}
		catch (Exception ex)
		{
			Logger.Error("[DropperWatermark] Timestamp verification error: " + ex.Message);
			return false;
		}
	}

	private static string ComputeSignature(string timestamp, string identifier)
	{
		using HMACSHA256 hMACSHA = new HMACSHA256(Encoding.UTF8.GetBytes("KabanDropper_To_Patch_Secret_2024_v1"));
		string s = timestamp + "|" + identifier;
		return Convert.ToBase64String(hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(s)));
	}

	private static bool CompareSecure(string a, string b)
	{
		if (a == null || b == null)
		{
			return false;
		}
		if (a.Length == b.Length)
		{
			int num = 0;
			for (int i = 0; i < a.Length; i++)
			{
				num |= a[i] ^ b[i];
			}
			return num == 0;
		}
		return false;
	}

	private static void ReportSecurityIncident(string incidentType, string details)
	{
		Task.Run(async delegate
		{
			try
			{
				string orCreateHWID = HwidProvider.GetOrCreateHWID();
				string value = LicenseStorage.LoadLicense();
				if (!string.IsNullOrEmpty(orCreateHWID) && !string.IsNullOrEmpty(value))
				{
					await TelemetryHttpClient.SendSecurityEventAsync(orCreateHWID, incidentType, details, new
					{
						timestamp = DateTime.UtcNow,
						severity = "critical"
					});
				}
			}
			catch
			{
			}
		});
	}
}
