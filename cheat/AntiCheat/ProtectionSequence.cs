using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using HostAvailabilityChecker;
using HwidProvider;
using LicenseStorage;
using SecurityPaths;

namespace ProtectionSequence;

public sealed class ProtectionSequence
{
	private static readonly string string_0;

	private byte byte_1;

	private int int_0;

	private long long_1;

	private long long_2;

	private byte Byte_0
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = value;
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

	private long Int64_0
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

	private long Int64_1
	{
		get
		{
			return long_2;
		}
		set
		{
			long_2 = value;
		}
	}

	static ProtectionSequence()
	{
		string_0 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Kaban", "screenshots");
		try
		{
			if (!Directory.Exists(string_0))
			{
				Directory.CreateDirectory(string_0);
			}
		}
		catch (Exception)
		{
		}
	}

	public static async Task ExecuteProtectionSequenceAsync(string eventType, string threatDescription, Process? threatProcess = null, object? additionalData = null)
	{
		try
		{
			Logger.Fatal("[SecurityResponse] ⚠\ufe0f THREAT DETECTED: " + eventType);
			Logger.Fatal("[SecurityResponse] Description: " + threatDescription);
			await HostAvailabilityChecker.CheckHostOrExitAsync();
			Logger.Info("[SecurityResponse] ✅ Host is available, continuing protection sequence");
			bool threatKilled = false;
			if (threatProcess != null)
			{
				threatKilled = TryKillProcess(threatProcess);
			}
			string screenshotPath = await CaptureScreenshotAsync(eventType);
			Logger.Info("[SecurityResponse] \ud83d\udce1 Sending security alert to server...");
			await SendSecurityAlertAsync(eventType, threatDescription, screenshotPath, threatKilled, additionalData);
			Logger.Fatal("[SecurityResponse] \ud83d\uded1 Terminating application for security");
			await Task.Delay(5000);
			Environment.Exit(57005);
		}
		catch (Exception ex)
		{
			Logger.Error("[SecurityResponse] Protection sequence error: " + ex.Message);
			Environment.Exit(57005);
		}
	}

	private static async Task<string?> CaptureScreenshotAsync(string eventType)
	{
		return await Task.Run(delegate
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Expected O, but got Unknown
			try
			{
				Rectangle bounds = Screen.PrimaryScreen.Bounds;
				Bitmap val = new Bitmap(bounds.Width, bounds.Height);
				try
				{
					Graphics val2 = Graphics.FromImage((Image)(object)val);
					try
					{
						val2.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);
					}
					finally
					{
						((IDisposable)val2)?.Dispose();
					}
					string value = DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss");
					string path = $"security_{eventType}_{value}.jpg";
					string text = Path.Combine(string_0, path);
					((Image)val).Save(text, ImageFormat.Jpeg);
					new FileInfo(text);
					return text;
				}
				finally
				{
					((IDisposable)val)?.Dispose();
				}
			}
			catch (Exception ex)
			{
				Logger.Error("[SecurityResponse] ❌ Screenshot capture failed: " + ex.Message);
				return (string)null;
			}
		});
	}

	private static async Task SendSecurityAlertAsync(string eventType, string description, string? screenshotPath, bool threatKilled, object? additionalData)
	{
		try
		{
			string hwid = HwidProvider.GetOrCreateHWID();
			string licenseKey = LicenseStorage.LoadLicense();
			if (!string.IsNullOrEmpty(hwid) && !string.IsNullOrEmpty(licenseKey))
			{
				var value = new
				{
					hwid = hwid,
					event_type = eventType,
					description = description,
					threat_killed = threatKilled,
					timestamp = DateTime.UtcNow,
					additional_data = additionalData
				};
				string licenseServerUrl = SecurityPaths.LicenseServerUrl;
				bool alertSent = false;
				using (HttpClient httpClient = new HttpClient
				{
					Timeout = TimeSpan.FromSeconds(30L)
				})
				{
					httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + licenseKey);
					StringContent content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
					try
					{
						HttpResponseMessage response = await httpClient.PostAsync(licenseServerUrl + "/api/v1/security/event", content);
						if (response.IsSuccessStatusCode)
						{
							Logger.Info("[SecurityResponse] ✅ Security alert sent successfully. Response: " + await response.Content.ReadAsStringAsync());
							alertSent = true;
						}
						else
						{
							string value2 = await response.Content.ReadAsStringAsync();
							Logger.Fatal($"[SecurityResponse] ❌ CRITICAL: Failed to send security alert: {response.StatusCode} - {value2}");
						}
					}
					catch (Exception ex)
					{
						Logger.Fatal("[SecurityResponse] ❌ CRITICAL: Network error sending security alert: " + ex.Message);
					}
				}
				if (alertSent)
				{
					if (string.IsNullOrEmpty(screenshotPath) || !File.Exists(screenshotPath))
					{
						return;
					}
					if (!(await SendScreenshotAsync(hwid, licenseKey, screenshotPath)))
					{
						Logger.Warn("[SecurityResponse] ⚠\ufe0f Failed to send screenshot (non-critical)");
						return;
					}
					try
					{
						File.Delete(screenshotPath);
					}
					catch (Exception)
					{
					}
				}
				else
				{
					Logger.Fatal("[SecurityResponse] ❌ CRITICAL: Security alert was not delivered to server");
					Logger.Fatal("[SecurityResponse] This could indicate network tampering or server unavailability");
					Logger.Fatal("[SecurityResponse] Terminating immediately to prevent bypass");
					Environment.Exit(57005);
				}
			}
			else
			{
				Logger.Fatal("[SecurityResponse] ❌ CRITICAL: Cannot send alert - HWID or license key missing");
				Logger.Fatal("[SecurityResponse] This indicates tampering - terminating immediately");
				Environment.Exit(57005);
			}
		}
		catch (Exception ex3)
		{
			Logger.Fatal("[SecurityResponse] ❌ CRITICAL: Failed to send security alert: " + ex3.Message);
			Logger.Fatal("[SecurityResponse] Terminating to prevent bypass");
			Environment.Exit(57005);
		}
	}

	private static async Task<bool> SendScreenshotAsync(string hwid, string licenseKey, string screenshotPath)
	{
		try
		{
			string screenshot = Convert.ToBase64String(await File.ReadAllBytesAsync(screenshotPath));
			var value = new
			{
				hwid = hwid,
				screenshot = screenshot,
				timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss")
			};
			string licenseServerUrl = SecurityPaths.LicenseServerUrl;
			using HttpClient httpClient = new HttpClient
			{
				Timeout = TimeSpan.FromSeconds(60L)
			};
			httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + licenseKey);
			StringContent content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
			HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(licenseServerUrl + "/api/v1/telemetry/screenshot", content);
			if (httpResponseMessage.IsSuccessStatusCode)
			{
				await httpResponseMessage.Content.ReadAsStringAsync();
				return true;
			}
			await httpResponseMessage.Content.ReadAsStringAsync();
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}

	private static bool TryKillProcess(Process process)
	{
		string value = "Unknown";
		int value2 = -1;
		try
		{
			try
			{
				value = process.ProcessName;
			}
			catch
			{
			}
			try
			{
				value2 = process.Id;
			}
			catch
			{
			}
			process.Kill();
			process.WaitForExit(3000);
			Logger.Info($"[SecurityResponse] ⚔\ufe0f Terminated threat: {value} (PID: {value2})");
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public static void CleanupOldScreenshots()
	{
		try
		{
			if (!Directory.Exists(string_0))
			{
				return;
			}
			string[] files = Directory.GetFiles(string_0, "security_*.jpg");
			DateTime dateTime = DateTime.UtcNow.AddHours(-1.0);
			string[] array = files;
			foreach (string text in array)
			{
				try
				{
					if (new FileInfo(text).LastWriteTimeUtc < dateTime)
					{
						File.Delete(text);
					}
				}
				catch
				{
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private string method_5(double double_0, int int_1, long long_3)
	{
		return "Хитролох_иди_нахуй.___9____4_8__";
	}
}
