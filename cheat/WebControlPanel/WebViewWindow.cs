using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Threading;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using FileIntegrityVerifier;
using WebMessageValidator;
using WebCommandEventArgs;
using WebInvalidMessageEventArgs;
using JwtTokenValidator;

namespace WebViewWindow;

public class WebViewWindow : Window
{
	private class SecurityEventData
	{
		[CompilerGenerated]
		private string? VVk3wOZp1u;

		[CompilerGenerated]
		private string? nOQ3im9tAl;

		[CompilerGenerated]
		private long Aho3o8FXdo;

		[CompilerGenerated]
		private object? CEd3nBbwD9;

		[CompilerGenerated]
		private string? EcX32VdgDE;

		[CompilerGenerated]
		private object? F5t3HEraiG;

		[CompilerGenerated]
		private object? api3Z1BNIX;

		private double double_1;

		private bool bool_2;

		private byte byte_0;

		public string? Type
		{
			[CompilerGenerated]
			get
			{
				return VVk3wOZp1u;
			}
			[CompilerGenerated]
			set
			{
				VVk3wOZp1u = value;
			}
		}

		public long Timestamp
		{
			[CompilerGenerated]
			get
			{
				return Aho3o8FXdo;
			}
			[CompilerGenerated]
			set
			{
				Aho3o8FXdo = value;
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

		private bool Boolean_0
		{
			get
			{
				return bool_2;
			}
			set
			{
				bool_2 = value;
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

		[SpecialName]
		[CompilerGenerated]
		public string? EK43JQU7BY()
		{
			return nOQ3im9tAl;
		}

		[SpecialName]
		[CompilerGenerated]
		public void ip33vBxNtZ(string? string_0)
		{
			nOQ3im9tAl = string_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public object? IuN37h31dd()
		{
			return CEd3nBbwD9;
		}

		[SpecialName]
		[CompilerGenerated]
		public void dKR345kNUO(object? object_2)
		{
			CEd3nBbwD9 = object_2;
		}

		[SpecialName]
		[CompilerGenerated]
		public string? v0K3NJxcJm()
		{
			return EcX32VdgDE;
		}

		[SpecialName]
		[CompilerGenerated]
		public void BeN30CloHx(string? string_0)
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public object? Q8g387Cpja()
		{
			return F5t3HEraiG;
		}

		[SpecialName]
		[CompilerGenerated]
		public void YNH3kBfmee(object? object_2)
		{
			F5t3HEraiG = object_2;
		}

		[SpecialName]
		[CompilerGenerated]
		public object? bvO3MMblN6()
		{
			return api3Z1BNIX;
		}

		[SpecialName]
		[CompilerGenerated]
		public void Gkd3fMIhWy(object? object_2)
		{
			api3Z1BNIX = object_2;
		}
	}

	private WebView2? webView2_0;

	private string? string_0;

	private bool bool_0;

	private JwtTokenValidator? gclass159_0;

	private WebMessageValidator? gclass150_0;

	private FileIntegrityVerifier? gclass144_0;

	private int int_0;

	private byte byte_1;

	private string string_1;

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

	private string String_0
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

	public WebViewWindow()
	{
		InitializeWindow();
	}

	private void InitializeWindow()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		method_3("Kaban.cc Web Menu");
		Rect workArea = SystemParameters.WorkArea;
		method_1(Math.Min(1400.0, ((Rect)(ref workArea)).Width - 100.0));
		method_0(Math.Min(950.0, ((Rect)(ref workArea)).Height - 80.0));
		((Window)this).WindowStartupLocation = (WindowStartupLocation)1;
		webView2_0 = new WebView2();
		method_2(webView2_0);
	}

	public async Task InitializeAsync(string authToken)
	{
		if (!bool_0)
		{
			if (string.IsNullOrEmpty(authToken))
			{
				throw new ArgumentException("Auth token cannot be null or empty", "authToken");
			}
			string_0 = authToken;
			try
			{
				Console.WriteLine("[WebMenuWindow] Verifying Web Menu file integrity...");
				string webResourcesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Web");
				gclass144_0 = new FileIntegrityVerifier(webResourcesPath);
				if (!gclass144_0.VerifyIntegrity())
				{
					throw new InvalidOperationException("Web Menu file integrity verification failed. One or more files have been modified or are missing. This is a security violation.");
				}
				Console.WriteLine("[WebMenuWindow] ✓ Web Menu file integrity verified successfully");
				gclass159_0 = new JwtTokenValidator(string_0);
				if (gclass159_0.ValidateTokenClientSide())
				{
					gclass159_0.Event_0 += OnTokenExpired;
					gclass159_0.Event_1 += OnTokenRevoked;
					gclass159_0.Event_2 += OnValidationError;
					if (!(await gclass159_0.StartPeriodicValidationAsync()))
					{
						throw new InvalidOperationException("Token validation failed on server-side");
					}
					Console.WriteLine("[WebMenuWindow] Token validation successful, starting periodic checks");
					gclass150_0 = new WebMessageValidator(string_0);
					gclass150_0.Event_0 += OnCommandReceived;
					gclass150_0.Event_1 += OnInvalidMessageDetected;
					Console.WriteLine("[MessageBridge] Initialized with HMAC-SHA256 signing and command whitelist");
					string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Kaban.cc", "WebView2");
					string text2 = "--disable-web-security --disable-features=IsolateOrigins,site-per-process";
					text2 += " --remote-debugging-port=0";
					text2 += " --disable-extensions";
					text2 += " --disable-plugins";
					text2 += " --disable-sync";
					text2 += " --disable-background-networking";
					text2 += " --disable-default-apps";
					text2 += " --disable-translate";
					text2 += " --disable-client-side-phishing-detection";
					text2 += " --disable-component-update";
					text2 += " --disable-domain-reliability";
					CoreWebView2EnvironmentOptions val = new CoreWebView2EnvironmentOptions((string)null, (string)null, (string)null, false, (List<CoreWebView2CustomSchemeRegistration>)null)
					{
						AdditionalBrowserArguments = text2
					};
					CoreWebView2Environment val2 = await CoreWebView2Environment.CreateAsync((string)null, text, val);
					await webView2_0.EnsureCoreWebView2Async(val2);
					ConfigureWebViewSecurity();
					SetupEventHandlers();
					bool_0 = true;
					return;
				}
				throw new InvalidOperationException("Token validation failed on client-side");
			}
			catch (Exception ex)
			{
				if (gclass144_0 != null)
				{
					gclass144_0 = null;
				}
				if (gclass150_0 != null)
				{
					gclass150_0.Event_0 -= OnCommandReceived;
					gclass150_0.Event_1 -= OnInvalidMessageDetected;
					gclass150_0.Dispose();
					gclass150_0 = null;
				}
				if (gclass159_0 != null)
				{
					gclass159_0.Event_0 -= OnTokenExpired;
					gclass159_0.Event_1 -= OnTokenRevoked;
					gclass159_0.Event_2 -= OnValidationError;
					gclass159_0.Dispose();
					gclass159_0 = null;
				}
				throw new InvalidOperationException("Failed to initialize WebView2: " + ex.Message, ex);
			}
		}
		throw new InvalidOperationException("WebMenuWindow already initialized");
	}

	private void ConfigureWebViewSecurity()
	{
		WebView2? obj = webView2_0;
		if (((obj != null) ? obj.CoreWebView2 : null) != null)
		{
			CoreWebView2Settings settings = webView2_0.CoreWebView2.Settings;
			settings.AreDevToolsEnabled = false;
			settings.AreDefaultContextMenusEnabled = false;
			settings.IsStatusBarEnabled = false;
			settings.IsZoomControlEnabled = false;
			settings.IsScriptEnabled = true;
			settings.IsGeneralAutofillEnabled = false;
			settings.IsPasswordAutosaveEnabled = false;
			settings.IsBuiltInErrorPageEnabled = false;
			settings.AreDefaultScriptDialogsEnabled = false;
			settings.AreHostObjectsAllowed = false;
			settings.AreBrowserAcceleratorKeysEnabled = false;
			settings.IsSwipeNavigationEnabled = false;
			settings.IsPinchZoomEnabled = false;
			return;
		}
		throw new InvalidOperationException("WebView2 not initialized");
	}

	private void SetupEventHandlers()
	{
		WebView2? obj = webView2_0;
		if (((obj != null) ? obj.CoreWebView2 : null) == null)
		{
			throw new InvalidOperationException("WebView2 not initialized");
		}
		webView2_0.CoreWebView2.NavigationStarting += OnNavigationStarting;
		webView2_0.CoreWebView2.NavigationCompleted += OnNavigationCompleted;
		webView2_0.CoreWebView2.WebMessageReceived += OnWebMessageReceived;
		webView2_0.CoreWebView2.ProcessFailed += OnProcessFailed;
		string text = Environment.GetEnvironmentVariable("KABAN_API_URL") ?? "http://localhost:3001/api/v1";
		webView2_0.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.KABAN_API_URL = '" + text + "';");
	}

	private void OnNavigationStarting(object? sender, CoreWebView2NavigationStartingEventArgs e)
	{
		string value = "Content-Security-Policy: default-src 'self'; script-src 'self' 'unsafe-inline'; style-src 'self' 'unsafe-inline'; img-src 'self' data:; font-src 'self'; connect-src 'self'; object-src 'none'; frame-src 'none';";
		string value2 = "X-Frame-Options: DENY";
		string value3 = "X-Content-Type-Options: nosniff";
		string value4 = "X-XSS-Protection: 1; mode=block";
		string value5 = "Referrer-Policy: no-referrer";
		string value6 = "Permissions-Policy: geolocation=(), microphone=(), camera=(), payment=(), usb=(), magnetometer=(), gyroscope=(), accelerometer=()";
		string value7 = "Strict-Transport-Security: max-age=31536000; includeSubDomains";
		string value8 = "Authorization: Bearer " + string_0;
		try
		{
			_ = $"{value}\r\n{value2}\r\n{value3}\r\n{value4}\r\n{value5}\r\n{value6}\r\n{value7}\r\n{value8}";
			Console.WriteLine("[WebMenuWindow] Security headers prepared for injection");
		}
		catch
		{
			Console.WriteLine("[WebMenuWindow] Warning: Could not set additional headers");
		}
		ValidateNavigationUrl(e);
	}

	private void ValidateNavigationUrl(CoreWebView2NavigationStartingEventArgs e)
	{
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Uri D6M3tcOGkj = new Uri(e.Uri);
			if (!new string[4] { "localhost", "127.0.0.1", "kaban.cc", "menu.kaban.cc" }.Any((string host) => D6M3tcOGkj.Host.Equals(host, StringComparison.OrdinalIgnoreCase) || D6M3tcOGkj.Host.EndsWith("." + host, StringComparison.OrdinalIgnoreCase)))
			{
				e.Cancel = true;
				Console.WriteLine("[WebMenuWindow] Blocked navigation to unauthorized URL: " + e.Uri);
				MessageBox.Show("Navigation to " + D6M3tcOGkj.Host + " is not allowed for security reasons.", "Security Warning", (MessageBoxButton)0, (MessageBoxImage)48);
			}
		}
		catch (UriFormatException ex)
		{
			e.Cancel = true;
			Console.WriteLine("[WebMenuWindow] Blocked navigation to invalid URL: " + e.Uri + ", Error: " + ex.Message);
		}
	}

	private void OnNavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		if (!e.IsSuccess)
		{
			MessageBox.Show($"Failed to load web menu: {e.WebErrorStatus}", "Navigation Error", (MessageBoxButton)0, (MessageBoxImage)16);
		}
	}

	private void OnWebMessageReceived(object? sender, CoreWebView2WebMessageReceivedEventArgs e)
	{
		try
		{
			string text = e.TryGetWebMessageAsString();
			if (string.IsNullOrEmpty(text))
			{
				Console.WriteLine("[WebMenuWindow] Received empty message from web");
				return;
			}
			Console.WriteLine("[WebMenuWindow] Received message from web: " + text.Substring(0, Math.Min(100, text.Length)) + "...");
			if (gclass150_0 != null)
			{
				if (!gclass150_0.ProcessMessageFromWeb(text))
				{
					Console.WriteLine("[WebMenuWindow] Message validation failed - message rejected");
				}
			}
			else
			{
				Console.WriteLine("[WebMenuWindow] MessageBridge not initialized");
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("[WebMenuWindow] Error processing web message: " + ex.Message);
		}
	}

	private void OnCommandReceived(object? sender, WebCommandEventArgs e)
	{
		Console.WriteLine("[WebMenuWindow] Executing validated command: " + e.Command);
		try
		{
			switch (e.Command.ToLowerInvariant())
			{
			case "ping":
				HandlePing();
				break;
			default:
				Console.WriteLine("[WebMenuWindow] Unknown command: " + e.Command);
				break;
			case "getfeaturelist":
				HandleGetFeatureList();
				break;
			case "savesettings":
				HandleSaveSettings(e.Data);
				break;
			case "securityevent":
				HandleSecurityEvent(e.Data);
				break;
			case "updateconfig":
				HandleUpdateConfig(e.Data);
				break;
			case "executefeature":
				HandleExecuteFeature(e.Data);
				break;
			case "togglefeature":
				HandleToggleFeature(e.Data);
				break;
			case "loadsettings":
				HandleLoadSettings();
				break;
			case "getstatus":
				HandleGetStatus();
				break;
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("[WebMenuWindow] Error executing command '" + e.Command + "': " + ex.Message);
		}
	}

	private void OnInvalidMessageDetected(object? sender, WebInvalidMessageEventArgs e)
	{
		Console.WriteLine("[WebMenuWindow] Invalid message detected: " + e.Reason);
		if (!string.IsNullOrEmpty(e.MessageJson))
		{
			Console.WriteLine("[WebMenuWindow] Invalid message content: " + e.MessageJson.Substring(0, Math.Min(200, e.MessageJson.Length)));
		}
	}

	private void HandleUpdateConfig(object? data)
	{
		Console.WriteLine("[WebMenuWindow] Handling updateConfig command");
		SendResponseToWeb("updateConfig", new
		{
			success = true,
			message = "Config updated"
		});
	}

	private void HandleGetStatus()
	{
		Console.WriteLine("[WebMenuWindow] Handling getStatus command");
		SendResponseToWeb("getStatus", new
		{
			success = true,
			status = new
			{
				authenticated = (gclass159_0?.IsValid ?? false),
				version = "1.0.0",
				uptime = DateTime.UtcNow.ToString("o")
			}
		});
	}

	private void HandleExecuteFeature(object? data)
	{
		Console.WriteLine("[WebMenuWindow] Handling executeFeature command");
		SendResponseToWeb("executeFeature", new
		{
			success = true,
			message = "Feature executed"
		});
	}

	private void HandleToggleFeature(object? data)
	{
		Console.WriteLine("[WebMenuWindow] Handling toggleFeature command");
		SendResponseToWeb("toggleFeature", new
		{
			success = true,
			message = "Feature toggled"
		});
	}

	private void HandleGetFeatureList()
	{
		Console.WriteLine("[WebMenuWindow] Handling getFeatureList command");
		SendResponseToWeb("getFeatureList", new
		{
			success = true,
			features = new[]
			{
				new
				{
					id = "feature1",
					name = "Feature 1",
					enabled = true
				},
				new
				{
					id = "feature2",
					name = "Feature 2",
					enabled = false
				}
			}
		});
	}

	private void HandleSaveSettings(object? data)
	{
		Console.WriteLine("[WebMenuWindow] Handling saveSettings command");
		SendResponseToWeb("saveSettings", new
		{
			success = true,
			message = "Settings saved"
		});
	}

	private void HandleLoadSettings()
	{
		Console.WriteLine("[WebMenuWindow] Handling loadSettings command");
		SendResponseToWeb("loadSettings", new
		{
			success = true,
			settings = new
			{
				theme = "dark",
				language = "en"
			}
		});
	}

	private void HandlePing()
	{
		Console.WriteLine("[WebMenuWindow] Handling ping command");
		SendResponseToWeb("ping", new
		{
			success = true,
			timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
		});
	}

	private void HandleSecurityEvent(object? data)
	{
		try
		{
			Console.WriteLine("[WebMenuWindow] Handling security event");
			if (data == null)
			{
				Console.WriteLine("[WebMenuWindow] Security event data is null");
				return;
			}
			SecurityEventData securityEventData = JsonSerializer.Deserialize<SecurityEventData>(JsonSerializer.Serialize(data));
			if (securityEventData != null)
			{
				Console.WriteLine("[WebMenuWindow] Security Event: Type=" + securityEventData.Type + ", Severity=" + securityEventData.EK43JQU7BY());
				if (securityEventData.IuN37h31dd() != null)
				{
					string text = JsonSerializer.Serialize(securityEventData.IuN37h31dd());
					Console.WriteLine("[WebMenuWindow] Event Details: " + text);
				}
				switch (securityEventData.Type?.ToLowerInvariant())
				{
				case "devtools_detector_initialized":
					Console.WriteLine("[WebMenuWindow] DevTools detector initialized successfully");
					break;
				case "devtools_closed":
					HandleDevToolsClosed(securityEventData);
					break;
				case "devtools_opened":
					HandleDevToolsOpened(securityEventData);
					break;
				default:
					Console.WriteLine("[WebMenuWindow] Unknown security event type: " + securityEventData.Type);
					break;
				case "debugger_detected":
					HandleDebuggerDetected(securityEventData);
					break;
				}
				SendResponseToWeb("securityEvent", new
				{
					success = true,
					message = "Security event received and logged",
					eventType = securityEventData.Type
				});
			}
			else
			{
				Console.WriteLine("[WebMenuWindow] Failed to parse security event data");
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("[WebMenuWindow] Error handling security event: " + ex.Message);
		}
	}

	private void HandleDevToolsOpened(SecurityEventData eventData)
	{
		Console.WriteLine("[WebMenuWindow] ⚠\ufe0f SECURITY ALERT: DevTools opened detected!");
		if (eventData.IuN37h31dd() != null)
		{
			string text = JsonSerializer.Serialize(eventData.IuN37h31dd());
			Console.WriteLine("[WebMenuWindow] DevTools Detection Details: " + text);
		}
		SendSecurityNotificationToServer(new
		{
			eventType = "devtools_opened",
			severity = "high",
			timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
			details = eventData.IuN37h31dd(),
			windowDimensions = eventData.bvO3MMblN6(),
			userAgent = eventData.v0K3NJxcJm()
		});
	}

	private void HandleDevToolsClosed(SecurityEventData eventData)
	{
		Console.WriteLine("[WebMenuWindow] DevTools closed");
		SendSecurityNotificationToServer(new
		{
			eventType = "devtools_closed",
			severity = "medium",
			timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
			details = eventData.IuN37h31dd()
		});
	}

	private void HandleDebuggerDetected(SecurityEventData eventData)
	{
		Console.WriteLine("[WebMenuWindow] \ud83d\udea8 CRITICAL: Debugger detected!");
		SendSecurityNotificationToServer(new
		{
			eventType = "debugger_detected",
			severity = "critical",
			timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
			details = eventData.IuN37h31dd()
		});
	}

	private void SendSecurityNotificationToServer(object notificationData)
	{
		try
		{
			string text = JsonSerializer.Serialize(notificationData);
			Console.WriteLine("[WebMenuWindow] Security notification prepared for server: " + text);
			Console.WriteLine("[WebMenuWindow] Security notification sent to server (placeholder)");
		}
		catch (Exception ex)
		{
			Console.WriteLine("[WebMenuWindow] Error sending security notification to server: " + ex.Message);
		}
	}

	private void SendResponseToWeb(string command, object data)
	{
		if (gclass150_0 != null)
		{
			try
			{
				string message = gclass150_0.CreateMessageToWeb(command, data);
				PostMessageToWeb(message);
				Console.WriteLine("[WebMenuWindow] Sent signed response: " + command);
				return;
			}
			catch (Exception ex)
			{
				Console.WriteLine("[WebMenuWindow] Error sending response: " + ex.Message);
				return;
			}
		}
		Console.WriteLine("[WebMenuWindow] Cannot send response - MessageBridge not initialized");
	}

	private void OnProcessFailed(object? sender, CoreWebView2ProcessFailedEventArgs e)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Invalid comparison between Unknown and I4
		MessageBox.Show($"WebView2 process failed: {e.ProcessFailedKind}", "Process Error", (MessageBoxButton)0, (MessageBoxImage)16);
		if ((int)e.ProcessFailedKind == 0 || (int)e.ProcessFailedKind == 2)
		{
			((Window)this).Close();
		}
	}

	public void NavigateToMenu(string url)
	{
		if (bool_0)
		{
			if (!string.IsNullOrEmpty(url))
			{
				if (gclass144_0 != null && !gclass144_0.IsIntegrityVerified)
				{
					Console.WriteLine("[WebMenuWindow] ⚠\ufe0f Integrity not verified, re-checking...");
					if (!gclass144_0.VerifyIntegrity())
					{
						throw new InvalidOperationException("Web Menu file integrity verification failed before navigation. Files may have been modified at runtime.");
					}
				}
				WebView2? obj = webView2_0;
				if (obj != null)
				{
					CoreWebView2 coreWebView = obj.CoreWebView2;
					if (coreWebView != null)
					{
						coreWebView.Navigate(url);
					}
				}
				return;
			}
			throw new ArgumentException("URL cannot be null or empty", "url");
		}
		throw new InvalidOperationException("WebMenuWindow not initialized. Call InitializeAsync first.");
	}

	public void PostMessageToWeb(string message)
	{
		if (bool_0)
		{
			WebView2? obj = webView2_0;
			if (obj != null)
			{
				CoreWebView2 coreWebView = obj.CoreWebView2;
				if (coreWebView != null)
				{
					coreWebView.PostWebMessageAsString(message);
				}
			}
			return;
		}
		throw new InvalidOperationException("WebMenuWindow not initialized");
	}

	public void SendCommandToWeb(string command, object? data = null)
	{
		if (bool_0)
		{
			if (gclass150_0 == null)
			{
				throw new InvalidOperationException("MessageBridge not initialized");
			}
			try
			{
				string message = gclass150_0.CreateMessageToWeb(command, data);
				PostMessageToWeb(message);
				Console.WriteLine("[WebMenuWindow] Sent signed command to web: " + command);
				return;
			}
			catch (Exception ex)
			{
				Console.WriteLine("[WebMenuWindow] Error sending command to web: " + ex.Message);
				throw;
			}
		}
		throw new InvalidOperationException("WebMenuWindow not initialized");
	}

	protected override void OnClosed(EventArgs e)
	{
		((Window)this).OnClosed(e);
		if (gclass144_0 != null)
		{
			gclass144_0 = null;
		}
		if (gclass150_0 != null)
		{
			gclass150_0.Event_0 -= OnCommandReceived;
			gclass150_0.Event_1 -= OnInvalidMessageDetected;
			gclass150_0.Dispose();
			gclass150_0 = null;
		}
		if (gclass159_0 != null)
		{
			gclass159_0.Event_0 -= OnTokenExpired;
			gclass159_0.Event_1 -= OnTokenRevoked;
			gclass159_0.Event_2 -= OnValidationError;
			gclass159_0.StopPeriodicValidation();
			gclass159_0.Dispose();
			gclass159_0 = null;
		}
		WebView2? obj = webView2_0;
		if (((obj == null) ? null : obj.CoreWebView2) != null)
		{
			webView2_0.CoreWebView2.NavigationStarting -= OnNavigationStarting;
			webView2_0.CoreWebView2.NavigationCompleted -= OnNavigationCompleted;
			webView2_0.CoreWebView2.WebMessageReceived -= OnWebMessageReceived;
			webView2_0.CoreWebView2.ProcessFailed -= OnProcessFailed;
		}
		((WebViewWindow)(object)webView2_0)?.method_4();
		webView2_0 = null;
		string_0 = null;
		bool_0 = false;
	}

	private void OnTokenExpired(object? sender, EventArgs e)
	{
		Console.WriteLine("[WebMenuWindow] Token expired - blocking UI");
		((DispatcherObject)this).Dispatcher.Invoke((Action)delegate
		{
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			WebView2? obj = webView2_0;
			if (((obj != null) ? obj.CoreWebView2 : null) != null)
			{
				webView2_0.CoreWebView2.NavigateToString("\r\n                    <!DOCTYPE html>\r\n                    <html>\r\n                    <head>\r\n                        <title>Token Expired</title>\r\n                        <style>\r\n                            body {\r\n                                font-family: Arial, sans-serif;\r\n                                display: flex;\r\n                                justify-content: center;\r\n                                align-items: center;\r\n                                height: 100vh;\r\n                                margin: 0;\r\n                                background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);\r\n                            }\r\n                            .container {\r\n                                text-align: center;\r\n                                background: white;\r\n                                padding: 40px;\r\n                                border-radius: 10px;\r\n                                box-shadow: 0 10px 40px rgba(0,0,0,0.2);\r\n                            }\r\n                            h1 {\r\n                                color: #ef4444;\r\n                                margin-bottom: 20px;\r\n                            }\r\n                            p {\r\n                                color: #6b7280;\r\n                                font-size: 16px;\r\n                            }\r\n                        </style>\r\n                    </head>\r\n                    <body>\r\n                        <div class='container'>\r\n                            <h1>⏰ Token Expired</h1>\r\n                            <p>Your authentication token has expired.</p>\r\n                            <p>Please restart the application to continue.</p>\r\n                        </div>\r\n                    </body>\r\n                    </html>\r\n                ");
			}
			MessageBox.Show("Your authentication token has expired. Please restart the application.", "Token Expired", (MessageBoxButton)0, (MessageBoxImage)48);
		});
	}

	private void OnTokenRevoked(object? sender, EventArgs e)
	{
		Console.WriteLine("[WebMenuWindow] Token revoked - blocking UI");
		((DispatcherObject)this).Dispatcher.Invoke((Action)delegate
		{
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			WebView2? obj = webView2_0;
			if (((obj == null) ? null : obj.CoreWebView2) != null)
			{
				webView2_0.CoreWebView2.NavigateToString("\r\n                    <!DOCTYPE html>\r\n                    <html>\r\n                    <head>\r\n                        <title>Token Revoked</title>\r\n                        <style>\r\n                            body {\r\n                                font-family: Arial, sans-serif;\r\n                                display: flex;\r\n                                justify-content: center;\r\n                                align-items: center;\r\n                                height: 100vh;\r\n                                margin: 0;\r\n                                background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);\r\n                            }\r\n                            .container {\r\n                                text-align: center;\r\n                                background: white;\r\n                                padding: 40px;\r\n                                border-radius: 10px;\r\n                                box-shadow: 0 10px 40px rgba(0,0,0,0.2);\r\n                            }\r\n                            h1 {\r\n                                color: #ef4444;\r\n                                margin-bottom: 20px;\r\n                            }\r\n                            p {\r\n                                color: #6b7280;\r\n                                font-size: 16px;\r\n                            }\r\n                        </style>\r\n                    </head>\r\n                    <body>\r\n                        <div class='container'>\r\n                            <h1>\ud83d\udeab Token Revoked</h1>\r\n                            <p>Your authentication token has been revoked.</p>\r\n                            <p>Please contact support for assistance.</p>\r\n                        </div>\r\n                    </body>\r\n                    </html>\r\n                ");
			}
			MessageBox.Show("Your authentication token has been revoked. Please contact support.", "Token Revoked", (MessageBoxButton)0, (MessageBoxImage)16);
		});
	}

	private void OnValidationError(object? sender, string error)
	{
		Console.WriteLine("[WebMenuWindow] Token validation error: " + error);
	}

	public void method_0(double double_1)
	{
		((FrameworkElement)this).Height = double_1;
	}

	public void method_1(double double_1)
	{
		((FrameworkElement)this).Width = double_1;
	}

	public void method_2(object object_2)
	{
		((ContentControl)this).Content = object_2;
	}

	public void method_3(string string_2)
	{
		((Window)this).Title = string_2;
	}

	public void method_4()
	{
		((HwndHost)this).Dispose();
	}
}
