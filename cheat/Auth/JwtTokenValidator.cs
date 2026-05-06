using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace JwtTokenValidator;

public class JwtTokenValidator : IDisposable
{
	private class TokenPayload
	{
		[CompilerGenerated]
		private string? PwXoQdNKHZ;

		[CompilerGenerated]
		private string? CRJoWTc7g4;

		[CompilerGenerated]
		private long pqfoCb3vfT;

		[CompilerGenerated]
		private long QjNoU1T5g7;

		private string? string_0;

		private string? string_1;

		private long long_2;

		public string? hwid
		{
			[CompilerGenerated]
			get
			{
				return CRJoWTc7g4;
			}
			[CompilerGenerated]
			set
			{
				CRJoWTc7g4 = value;
			}
		}

		private string? String_0
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

		private string? String_1
		{
			get
			{
				return string_1;
			}
			set
			{
				string_1 = value;
			}
		}

		private long Int64_0
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

		[SpecialName]
		[CompilerGenerated]
		public string? zFSiGKjFGv()
		{
			return PwXoQdNKHZ;
		}

		[SpecialName]
		[CompilerGenerated]
		public void pCsiYjYFRF(string? string_2)
		{
			PwXoQdNKHZ = string_2;
		}

		[SpecialName]
		[CompilerGenerated]
		public long SyoizCOOtM()
		{
			return pqfoCb3vfT;
		}

		[SpecialName]
		[CompilerGenerated]
		public void dmIop4AjYv(long long_3)
		{
			pqfoCb3vfT = long_3;
		}

		[SpecialName]
		[CompilerGenerated]
		public long CAyo1ZMP5Q()
		{
			return QjNoU1T5g7;
		}

		[SpecialName]
		[CompilerGenerated]
		public void buWoVolSNI(long long_3)
		{
			QjNoU1T5g7 = long_3;
		}
	}

	private class ValidationResponse
	{
		[CompilerGenerated]
		private bool OLQoA5Gyc5;

		[CompilerGenerated]
		private string? eSkoL7tCMl;

		private bool bool_1;

		private char char_0;

		private char char_1;

		private double double_0;

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

		private char Char_1
		{
			get
			{
				return char_1;
			}
			set
			{
				char_1 = value;
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

		[SpecialName]
		[CompilerGenerated]
		public bool DUoo9BfHQ2()
		{
			return OLQoA5Gyc5;
		}

		[SpecialName]
		[CompilerGenerated]
		public void OsuosFkNqh(bool bool_2)
		{
			OLQoA5Gyc5 = bool_2;
		}

		[SpecialName]
		[CompilerGenerated]
		public string? rdtorJr6HP()
		{
			return eSkoL7tCMl;
		}

		[SpecialName]
		[CompilerGenerated]
		public void IfloDqoLsR(string? string_0)
		{
			eSkoL7tCMl = string_0;
		}

		private string? method_4(float float_1)
		{
			return "Хитролох_иди_нахуй.___9___3____5______4____";
		}

		private string? method_7(double double_1, double double_2)
		{
			return "Хитролох_иди_нахуй.______4__4____2____";
		}
	}

	private readonly string token;

	private readonly string string_0;

	private readonly HttpClient httpClient_0;

	private Timer? timer_0;

	private bool bool_0;

	private bool bool_1;

	[CompilerGenerated]
	private EventHandler? eventHandler_0;

	[CompilerGenerated]
	private EventHandler? eventHandler_1;

	[CompilerGenerated]
	private EventHandler<string>? eventHandler_2;

	private double double_0;

	private int int_1;

	private string? string_1;

	public bool IsValid
	{
		get
		{
			if (bool_0)
			{
				return !bool_1;
			}
			return false;
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

	private string? String_0
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public event EventHandler? Event_0
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
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

	public event EventHandler<string>? Event_2
	{
		[CompilerGenerated]
		add
		{
			EventHandler<string> eventHandler = eventHandler_2;
			EventHandler<string> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<string> value2 = (EventHandler<string>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<string> eventHandler = eventHandler_2;
			EventHandler<string> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<string> value2 = (EventHandler<string>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public JwtTokenValidator(string token, string? licenseServerUrl = null)
	{
		//IL_002f: Expected I8, but got I4
		if (string.IsNullOrEmpty(token))
		{
			throw new ArgumentException("Token cannot be null or empty", "token");
		}
		this.token = token;
		string_0 = licenseServerUrl ?? "https://license.kaban.cc";
		bool_0 = false;
		httpClient_0 = new HttpClient
		{
			Timeout = TimeSpan.FromSeconds(30L)
		};
		httpClient_0.DefaultRequestHeaders.Add("Authorization", "Bearer " + this.token);
	}

	public async Task<bool> StartPeriodicValidationAsync()
	{
		if (!bool_1)
		{
			if (await ValidateTokenAsync())
			{
				timer_0 = new Timer(async delegate
				{
					await PeriodicValidationCallback();
				}, null, 600000, 600000);
				return true;
			}
			Logger.Info("[TokenValidator] Initial validation failed");
			return false;
		}
		throw new ObjectDisposedException("TokenValidator");
	}

	public async Task<bool> ValidateTokenAsync()
	{
		if (!bool_1)
		{
			try
			{
				StringContent content = new StringContent(JsonSerializer.Serialize(new
				{
					token = token,
					timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
				}), Encoding.UTF8, "application/json");
				HttpResponseMessage httpResponseMessage = await httpClient_0.PostAsync(string_0 + "/api/v1/auth/validate", content);
				if (httpResponseMessage.IsSuccessStatusCode)
				{
					ValidationResponse validationResponse = JsonSerializer.Deserialize<ValidationResponse>(await httpResponseMessage.Content.ReadAsStringAsync());
					if (validationResponse != null && validationResponse.DUoo9BfHQ2())
					{
						bool_0 = true;
						return true;
					}
					bool_0 = false;
					if (!(validationResponse?.rdtorJr6HP() == "expired"))
					{
						if (validationResponse?.rdtorJr6HP() == "revoked")
						{
							eventHandler_1?.Invoke(this, EventArgs.Empty);
						}
					}
					else
					{
						eventHandler_0?.Invoke(this, EventArgs.Empty);
					}
					return false;
				}
				bool_0 = false;
				string e = $"Validation failed with status: {httpResponseMessage.StatusCode}";
				eventHandler_2?.Invoke(this, e);
				return false;
			}
			catch (HttpRequestException ex)
			{
				bool_0 = false;
				string e2 = "Network error during validation: " + ex.Message;
				eventHandler_2?.Invoke(this, e2);
				return false;
			}
			catch (TaskCanceledException ex2)
			{
				bool_0 = false;
				string e3 = "Validation timeout: " + ex2.Message;
				eventHandler_2?.Invoke(this, e3);
				return false;
			}
			catch (Exception ex3)
			{
				bool_0 = false;
				string e4 = "Unexpected error during validation: " + ex3.Message;
				eventHandler_2?.Invoke(this, e4);
				return false;
			}
		}
		throw new ObjectDisposedException("TokenValidator");
	}

	public bool ValidateTokenClientSide()
	{
		if (!bool_1)
		{
			try
			{
				if (string.IsNullOrEmpty(token))
				{
					Logger.Info("[TokenValidator] Client-side validation failed: empty token");
					return false;
				}
				string[] array = token.Split('.');
				if (array.Length == 3)
				{
					try
					{
						byte[] bytes = DecodeBase64Url(array[1]);
						TokenPayload tokenPayload = JsonSerializer.Deserialize<TokenPayload>(Encoding.UTF8.GetString(bytes));
						if (tokenPayload == null)
						{
							Logger.Info("[TokenValidator] Client-side validation failed: invalid payload");
							return false;
						}
						if (DateTimeOffset.FromUnixTimeSeconds(tokenPayload.CAyo1ZMP5Q()) < DateTimeOffset.UtcNow)
						{
							Logger.Info("[TokenValidator] Client-side validation failed: token expired");
							eventHandler_0?.Invoke(this, EventArgs.Empty);
							return false;
						}
						return true;
					}
					catch (Exception ex)
					{
						Logger.Info("[TokenValidator] Client-side validation failed: " + ex.Message);
						return false;
					}
				}
				Logger.Info("[TokenValidator] Client-side validation failed: invalid JWT format");
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}
		throw new ObjectDisposedException("TokenValidator");
	}

	private async Task PeriodicValidationCallback()
	{
		if (!bool_1 && !(await ValidateTokenAsync()))
		{
			Logger.Info("[TokenValidator] Periodic validation failed - token is no longer valid");
			timer_0?.Change(-1, -1);
		}
	}

	public void StopPeriodicValidation()
	{
		if (timer_0 != null)
		{
			timer_0.Change(-1, -1);
		}
	}

	private byte[] DecodeBase64Url(string base64Url)
	{
		string text = base64Url.Replace('-', '+').Replace('_', '/');
		switch (text.Length % 4)
		{
		case 2:
			text += "==";
			break;
		case 3:
			text += "=";
			break;
		}
		return Convert.FromBase64String(text);
	}

	public void Dispose()
	{
		if (!bool_1)
		{
			bool_1 = true;
			timer_0?.Dispose();
			timer_0 = null;
			((JwtTokenValidator)(object)httpClient_0)?.method_0();
		}
	}

	public void method_0()
	{
		((HttpMessageInvoker)this).Dispose();
	}

	private string? method_10(string? string_2)
	{
		return "Хитролох_иди_нахуй.________02______72";
	}
}
