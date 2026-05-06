using System;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace HostAvailabilityChecker;

public sealed class HostAvailabilityChecker
{
	private static readonly HttpClient httpClient_0;

	private long long_0;

	private double double_1;

	private float float_0;

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

	static HostAvailabilityChecker()
	{
		//IL_002b: Expected I8, but got I4
		httpClient_0 = new HttpClient(new HttpClientHandler
		{
			ServerCertificateCustomValidationCallback = (HttpRequestMessage message, X509Certificate2? cert, X509Chain? chain, SslPolicyErrors sslPolicyErrors) => true
		})
		{
			Timeout = TimeSpan.FromSeconds(10L)
		};
	}

	public static async Task<bool> CheckHostAvailabilityAsync()
	{
		try
		{
			string requestUri = "http://31.177.83.245:3001";
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Head, requestUri);
			using CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(5L));
			await httpClient_0.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cts.Token);
			return true;
		}
		catch (HttpRequestException ex)
		{
			Logger.Fatal("[HostAvailability] ❌ Host is NOT available: " + ex.Message);
			return false;
		}
		catch (TaskCanceledException)
		{
			Logger.Fatal("[HostAvailability] ❌ Host check timeout (5s)");
			return false;
		}
		catch (Exception ex3)
		{
			Logger.Fatal("[HostAvailability] ❌ Host check error: " + ex3.Message);
			return false;
		}
	}

	public static async Task CheckHostOrExitAsync()
	{
		if (!(await CheckHostAvailabilityAsync()))
		{
			Logger.Fatal("[HostAvailability] ⚠\ufe0f CRITICAL: Host is not available!");
			Logger.Fatal("[HostAvailability] Cannot send security events to server.");
			Logger.Fatal("[HostAvailability] This may indicate an attempt to bypass protection.");
			Logger.Fatal("[HostAvailability] \ud83d\uded1 Terminating application for security.");
			await Task.Delay(2000);
			Environment.Exit(57005);
		}
	}
}
