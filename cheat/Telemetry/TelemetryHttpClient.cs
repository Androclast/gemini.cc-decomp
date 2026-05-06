using System;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LicenseValidationResult;
using VersionCheckResult;

namespace TelemetryHttpClient;

public sealed class TelemetryHttpClient
{
	private static readonly HttpClient httpClient_0;

	private int int_0;

	private bool bool_1;

	private double double_1;

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

	static TelemetryHttpClient()
	{
		//IL_002b: Expected I8, but got I4
		httpClient_0 = new HttpClient(new HttpClientHandler
		{
			ServerCertificateCustomValidationCallback = (HttpRequestMessage message, X509Certificate2? cert, X509Chain? chain, SslPolicyErrors sslPolicyErrors) => true
		})
		{
			Timeout = TimeSpan.FromSeconds(30L)
		};
	}

	public static async Task<LicenseValidationResult> ValidateLicenseAsync(string licenseKey, string hwid)
	{
		try
		{
			string text = "http://31.177.83.245:3001";
			StringContent content = new StringContent(JsonConvert.SerializeObject((object)new { licenseKey, hwid }), Encoding.UTF8, "application/json");
			HttpResponseMessage response = await httpClient_0.PostAsync(text + "/api/v1/auth/validate-license", content);
			string text2 = await response.Content.ReadAsStringAsync();
			if (response.IsSuccessStatusCode)
			{
				return JsonConvert.DeserializeObject<LicenseValidationResult>(text2) ?? new LicenseValidationResult
				{
					Valid = false,
					Message = "Invalid response"
				};
			}
			return new LicenseValidationResult
			{
				Valid = false,
				Message = $"Server error: {response.StatusCode}"
			};
		}
		catch (Exception ex)
		{
			return new LicenseValidationResult
			{
				Valid = false,
				Message = "Connection error: " + ex.Message
			};
		}
	}

	public static async Task<bool> SendTelemetryAsync(string hwid, string licenseKey, string eventType, object? data = null)
	{
		try
		{
			string text = "http://31.177.83.245:3001";
			StringContent content = new StringContent(JsonConvert.SerializeObject((object)new
			{
				hwid = hwid,
				licenseKey = licenseKey,
				eventType = eventType,
				data = data,
				timestamp = DateTime.UtcNow
			}), Encoding.UTF8, "application/json");
			return (await httpClient_0.PostAsync(text + "/api/v1/telemetry/event", content)).IsSuccessStatusCode;
		}
		catch
		{
			return false;
		}
	}

	public static async Task<bool> SendStartupEventAsync(string hwid, string licenseKey, string version)
	{
		try
		{
			string text = "http://31.177.83.245:3001";
			StringContent content = new StringContent(JsonConvert.SerializeObject((object)new
			{
				hwid = hwid,
				licenseKey = licenseKey,
				version = version,
				timestamp = DateTime.UtcNow
			}), Encoding.UTF8, "application/json");
			return (await httpClient_0.PostAsync(text + "/api/v1/telemetry/startup", content)).IsSuccessStatusCode;
		}
		catch
		{
			return false;
		}
	}

	public static async Task<bool> SendSecurityEventAsync(string hwid, string eventType, string description, object? metadata = null)
	{
		return await SendSecurityEventAsync(hwid, eventType, description, metadata, "http://31.177.83.245:3001");
	}

	public static async Task<bool> SendSecurityEventAsync(string hwid, string eventType, string description, object? metadata, string apiUrl)
	{
		try
		{
			StringContent content = new StringContent(JsonConvert.SerializeObject((object)new
			{
				hwid = hwid,
				eventType = eventType,
				description = description,
				metadata = metadata,
				timestamp = DateTime.UtcNow,
				severity = "critical"
			}), Encoding.UTF8, "application/json");
			return (await httpClient_0.PostAsync(apiUrl + "/api/v1/security/event", content)).IsSuccessStatusCode;
		}
		catch
		{
			return false;
		}
	}

	public static async Task<VersionCheckResult> CheckVersionAsync(string currentVersion, string hwid)
	{
		return await CheckVersionAsync(currentVersion, hwid, "http://31.177.83.245:3001");
	}

	public static async Task<VersionCheckResult> CheckVersionAsync(string currentVersion, string hwid, string apiUrl)
	{
		try
		{
			string requestUri = $"{apiUrl}/api/v1/version/check?currentVersion={Uri.EscapeDataString(currentVersion)}&hwid={Uri.EscapeDataString(hwid)}";
			HttpResponseMessage response = await httpClient_0.GetAsync(requestUri);
			string text = await response.Content.ReadAsStringAsync();
			if (!response.IsSuccessStatusCode)
			{
				return new VersionCheckResult
				{
					IsLatest = true,
					LatestVersion = currentVersion
				};
			}
			return JsonConvert.DeserializeObject<VersionCheckResult>(text) ?? new VersionCheckResult
			{
				IsLatest = false,
				LatestVersion = "unknown"
			};
		}
		catch
		{
			return new VersionCheckResult
			{
				IsLatest = true,
				LatestVersion = currentVersion
			};
		}
	}
}
