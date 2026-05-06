using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading;
using WebCommandEventArgs;
using WebInvalidMessageEventArgs;

namespace WebMessageValidator;

public class WebMessageValidator : IDisposable
{
	private class WebMessage
	{
		[CompilerGenerated]
		private string o9FiX9PV1J = string.Empty;

		[CompilerGenerated]
		private object? GGoicr06JR;

		[CompilerGenerated]
		private long BBkimwdEYJ;

		[CompilerGenerated]
		private string slViEf3EFM = string.Empty;

		private double double_1;

		private long long_0;

		private char char_0;

		private bool bool_1;

		public object? cc9iDS4O3T
		{
			[CompilerGenerated]
			get
			{
				return GGoicr06JR;
			}
			[CompilerGenerated]
			set
			{
				GGoicr06JR = value;
			}
		}

		public long Timestamp
		{
			[CompilerGenerated]
			get
			{
				return BBkimwdEYJ;
			}
			[CompilerGenerated]
			set
			{
				BBkimwdEYJ = value;
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

		private char Char_0
		{
			get
			{
				return char_0;
			}
			set
			{
				char_0 = value;
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

		[SpecialName]
		[CompilerGenerated]
		public string HR8iU8wN8t()
		{
			return o9FiX9PV1J;
		}

		[SpecialName]
		[CompilerGenerated]
		public void wuYi98T3LZ(string string_0)
		{
			o9FiX9PV1J = string_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public string nbdiLXFjEE()
		{
			return slViEf3EFM;
		}

		[SpecialName]
		[CompilerGenerated]
		public void pvtiFuAalE(string string_0)
		{
			slViEf3EFM = string_0;
		}

		private string method_9(float float_0)
		{
			return "Хитролох_иди_нахуй._8_3___8320_";
		}
	}

	private readonly string authToken;

	private readonly byte[] byte_0;

	private readonly HashSet<string> hashSet_0;

	private bool bool_0;

	[CompilerGenerated]
	private EventHandler<WebCommandEventArgs>? eventHandler_0;

	[CompilerGenerated]
	private EventHandler<WebInvalidMessageEventArgs>? eventHandler_1;

	private bool bool_3;

	private double double_0;

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

	private double Double_0
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public event EventHandler<WebCommandEventArgs>? Event_0
	{
		[CompilerGenerated]
		add
		{
			EventHandler<WebCommandEventArgs> eventHandler = eventHandler_0;
			EventHandler<WebCommandEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<WebCommandEventArgs> value2 = (EventHandler<WebCommandEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<WebCommandEventArgs> eventHandler = eventHandler_0;
			EventHandler<WebCommandEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<WebCommandEventArgs> value2 = (EventHandler<WebCommandEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<WebInvalidMessageEventArgs>? Event_1
	{
		[CompilerGenerated]
		add
		{
			EventHandler<WebInvalidMessageEventArgs> eventHandler = eventHandler_1;
			EventHandler<WebInvalidMessageEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<WebInvalidMessageEventArgs> value2 = (EventHandler<WebInvalidMessageEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<WebInvalidMessageEventArgs> eventHandler = eventHandler_1;
			EventHandler<WebInvalidMessageEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<WebInvalidMessageEventArgs> value2 = (EventHandler<WebInvalidMessageEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public WebMessageValidator(string authToken)
	{
		if (string.IsNullOrEmpty(authToken))
		{
			throw new ArgumentException("Auth token cannot be null or empty", "authToken");
		}
		this.authToken = authToken;
		byte_0 = DeriveHmacKey(authToken);
		hashSet_0 = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "updateConfig", "getStatus", "executeFeature", "toggleFeature", "getFeatureList", "saveSettings", "loadSettings", "ping", "securityEvent" };
	}

	public bool ProcessMessageFromWeb(string messageJson)
	{
		if (bool_0)
		{
			throw new ObjectDisposedException("MessageBridge");
		}
		if (string.IsNullOrEmpty(messageJson))
		{
			OnInvalidMessage("Empty message", null);
			return false;
		}
		try
		{
			WebMessage webMessage = JsonSerializer.Deserialize<WebMessage>(messageJson);
			if (webMessage != null)
			{
				if (ValidateMessageStructure(webMessage, out string error))
				{
					if (ValidateCommandWhitelist(webMessage.HR8iU8wN8t()))
					{
						if (ValidateTimestamp(webMessage.Timestamp))
						{
							if (ValidateSignature(webMessage))
							{
								OnCommandReceived(webMessage.HR8iU8wN8t(), webMessage.cc9iDS4O3T);
								return true;
							}
							Logger.Info("[MessageBridge] Message signature validation failed");
							OnInvalidMessage("Invalid message signature", messageJson);
							return false;
						}
						Logger.Info("[MessageBridge] Message timestamp invalid or too old");
						OnInvalidMessage("Message timestamp invalid or expired", messageJson);
						return false;
					}
					OnInvalidMessage("Command '" + webMessage.HR8iU8wN8t() + "' not allowed", messageJson);
					return false;
				}
				Logger.Info("[MessageBridge] Message validation failed: " + error);
				OnInvalidMessage(error, messageJson);
				return false;
			}
			OnInvalidMessage("Invalid JSON format", messageJson);
			return false;
		}
		catch (JsonException ex)
		{
			OnInvalidMessage("JSON parsing error: " + ex.Message, messageJson);
			return false;
		}
		catch (Exception ex2)
		{
			OnInvalidMessage("Processing error: " + ex2.Message, messageJson);
			return false;
		}
	}

	public string CreateMessageToWeb(string command, object? data = null)
	{
		if (bool_0)
		{
			throw new ObjectDisposedException("MessageBridge");
		}
		if (string.IsNullOrEmpty(command))
		{
			throw new ArgumentException("Command cannot be null or empty", "command");
		}
		WebMessage webMessage = new WebMessage();
		webMessage.wuYi98T3LZ(command);
		webMessage.cc9iDS4O3T = data;
		webMessage.Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
		WebMessage webMessage2 = webMessage;
		webMessage2.pvtiFuAalE(ComputeSignature(webMessage2));
		return JsonSerializer.Serialize(webMessage2, new JsonSerializerOptions
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase
		});
	}

	private bool ValidateMessageStructure(WebMessage message, out string? error)
	{
		if (string.IsNullOrEmpty(message.HR8iU8wN8t()))
		{
			error = "Command is required";
			return false;
		}
		if (message.Timestamp <= 0)
		{
			error = "Timestamp is required";
			return false;
		}
		if (string.IsNullOrEmpty(message.nbdiLXFjEE()))
		{
			error = "Signature is required";
			return false;
		}
		error = null;
		return true;
	}

	private bool ValidateCommandWhitelist(string command)
	{
		return hashSet_0.Contains(command);
	}

	private bool ValidateTimestamp(long timestamp)
	{
		DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(timestamp);
		DateTimeOffset utcNow = DateTimeOffset.UtcNow;
		if (!(dateTimeOffset > utcNow.AddSeconds(5.0)))
		{
			if (dateTimeOffset < utcNow.AddSeconds(-30.0))
			{
				return false;
			}
			return true;
		}
		return false;
	}

	private bool ValidateSignature(WebMessage message)
	{
		string b = ComputeSignature(message);
		return ConstantTimeEquals(message.nbdiLXFjEE(), b);
	}

	private string ComputeSignature(WebMessage message)
	{
		string s = $"{message.HR8iU8wN8t()}|{JsonSerializer.Serialize(message.cc9iDS4O3T)}|{message.Timestamp}";
		byte[] bytes = Encoding.UTF8.GetBytes(s);
		using HMACSHA256 hMACSHA = new HMACSHA256(byte_0);
		return BitConverter.ToString(hMACSHA.ComputeHash(bytes)).Replace("-", "").ToLowerInvariant();
	}

	private byte[] DeriveHmacKey(string authToken)
	{
		byte[] bytes = Encoding.UTF8.GetBytes("KabanMessageBridgeSalt2024");
		using Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(authToken, bytes, 10000, HashAlgorithmName.SHA256);
		return rfc2898DeriveBytes.GetBytes(32);
	}

	private bool ConstantTimeEquals(string a, string b)
	{
		if (a != null && b != null)
		{
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
		return false;
	}

	private void OnCommandReceived(string command, object? data)
	{
		eventHandler_0?.Invoke(this, new WebCommandEventArgs(command, data));
	}

	private void OnInvalidMessage(string reason, string? messageJson)
	{
		eventHandler_1?.Invoke(this, new WebInvalidMessageEventArgs(reason, messageJson));
	}

	public void Dispose()
	{
		if (!bool_0)
		{
			bool_0 = true;
			Array.Clear(byte_0, 0, byte_0.Length);
		}
	}

	private string method_5(double double_1, byte byte_2, double double_2)
	{
		return "Хитролох_иди_нахуй.__75___5_________1______";
	}
}
