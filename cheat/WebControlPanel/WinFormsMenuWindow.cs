using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using CerberusConfig;

public class WinFormsMenuWindow : Form
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CInitializeAsync_003Ed__18 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public WinFormsMenuWindow _003C_003E4__this;

		private TaskAwaiter<CoreWebView2Environment> _003C_003Eu__1;

		private TaskAwaiter<CoreWebView2Controller> _003C_003Eu__2;

		private unsafe void MoveNext()
		{
			//IL_0428: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			WinFormsMenuWindow CS_0024_003C_003E8__locals19 = _003C_003E4__this;
			try
			{
				try
				{
					TaskAwaiter<CoreWebView2Controller> awaiter2;
					CoreWebView2Environment val;
					TaskAwaiter<CoreWebView2Environment> awaiter;
					string text = default(string);
					CoreWebView2Controller result;
					switch (num)
					{
					case 2:
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<CoreWebView2Controller>);
						num = (_003C_003E1__state = -1);
						goto IL_0076;
					default:
					{
						val = null;
						object object_ = object_0;
						bool lockTaken = false;
						try
						{
							Monitor.Enter(object_, ref lockTaken);
							val = coreWebView2Environment_0;
						}
						finally
						{
							if (num < 0 && lockTaken)
							{
								Monitor.Exit(object_);
							}
						}
						if (val != null)
						{
							goto IL_0093;
						}
						if (task_0 == null)
						{
							goto IL_0029;
						}
						awaiter = task_0.GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							return;
						}
						goto IL_013d;
					}
					case 0:
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<CoreWebView2Environment>);
						num = (_003C_003E1__state = -1);
						goto IL_013d;
					case 1:
						{
							try
							{
								if (num == 1)
								{
									awaiter = _003C_003Eu__1;
									_003C_003Eu__1 = default(TaskAwaiter<CoreWebView2Environment>);
									num = (_003C_003E1__state = -1);
								}
								else
								{
									awaiter = CoreWebView2Environment.CreateAsync((string)null, text, (CoreWebView2EnvironmentOptions)null).GetAwaiter();
									if (!awaiter.IsCompleted)
									{
										num = (_003C_003E1__state = 1);
										_003C_003Eu__1 = awaiter;
										_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
										return;
									}
								}
								val = awaiter.GetResult();
							}
							catch (Exception ex)
							{
								if (ex.Message.Contains("Couldn't find a compatible") || ex.Message.Contains("WebView2") || ex.HResult == -2147024894)
								{
									throw new InvalidOperationException("Couldn't find a compatible Webview2 Runtime installation to host WebViews. Check WebView2Loader.dll!", ex);
								}
								throw;
							}
							object object_ = object_0;
							bool lockTaken = false;
							try
							{
								Monitor.Enter(object_, ref lockTaken);
								coreWebView2Environment_0 = val;
							}
							finally
							{
								if (num < 0 && lockTaken)
								{
									Monitor.Exit(object_);
								}
							}
							goto IL_0093;
						}
						IL_0076:
						result = awaiter2.GetResult();
						CS_0024_003C_003E8__locals19.coreWebView2Controller_0 = result;
						CS_0024_003C_003E8__locals19.coreWebView2_0 = CS_0024_003C_003E8__locals19.coreWebView2Controller_0.CoreWebView2;
						CS_0024_003C_003E8__locals19.coreWebView2Controller_0.DefaultBackgroundColor = Color.Transparent;
						CS_0024_003C_003E8__locals19.coreWebView2_0.Settings.IsZoomControlEnabled = false;
						CS_0024_003C_003E8__locals19.coreWebView2_0.Settings.AreDefaultContextMenusEnabled = false;
						CS_0024_003C_003E8__locals19.coreWebView2Controller_0.Bounds = new Rectangle(0, 0, ((Form)CS_0024_003C_003E8__locals19).ClientSize.Width, ((Form)CS_0024_003C_003E8__locals19).ClientSize.Height);
						CS_0024_003C_003E8__locals19.coreWebView2Controller_0.IsVisible = true;
						CS_0024_003C_003E8__locals19.coreWebView2_0.WebMessageReceived += CS_0024_003C_003E8__locals19.OnWebMessageReceived;
						CS_0024_003C_003E8__locals19.coreWebView2_0.Navigate("http://localhost:4649/");
						CS_0024_003C_003E8__locals19.bool_0 = true;
						CS_0024_003C_003E8__locals19.taskCompletionSource_0.TrySetResult(result: true);
						CS_0024_003C_003E8__locals19.coreWebView2_0.NavigationCompleted += delegate
						{
							CS_0024_003C_003E8__locals19.SendWindowSizeToWebView();
						};
						break;
						IL_013d:
						val = awaiter.GetResult();
						goto IL_0029;
						IL_0029:
						if (val == null)
						{
							text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Kaban.cc", "WebView2Cache");
							if (!Directory.Exists(text))
							{
								Directory.CreateDirectory(text);
							}
							goto case 1;
						}
						goto IL_0093;
						IL_0093:
						awaiter2 = val.CreateCoreWebView2ControllerAsync((IntPtr)((_003CInitializeAsync_003Ed__18*)CS_0024_003C_003E8__locals19)->method_0()).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter2;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
							return;
						}
						goto IL_0076;
					}
				}
				catch (Exception ex2)
				{
					if (ex2.Message.Contains("Couldn't find a compatible") || ex2.Message.Contains("WebView2") || ex2.HResult == -2147024894)
					{
						throw new InvalidOperationException("WebView2 Runtime not installed", ex2);
					}
					MessageBox.Show("WebView2 Error: " + ex2.Message + "\n\nPlease check:\n1. WebView2Loader.dll is present\n2. Microsoft Edge WebView2 Runtime is installed\n3. Your Windows version is up to date", "WebView2 Initialization Error", (MessageBoxButtons)0, (MessageBoxIcon)16);
					CS_0024_003C_003E8__locals19.taskCompletionSource_0.TrySetResult(result: false);
					throw;
				}
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			_003C_003Et__builder.SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}

		public nint method_0()
		{
			return ((Control)(ref this)).Handle;
		}
	}

	private CoreWebView2Controller coreWebView2Controller_0;

	private CoreWebView2 coreWebView2_0;

	[CompilerGenerated]
	private static WinFormsMenuWindow? gform0_0;

	private static CoreWebView2Environment coreWebView2Environment_0;

	private static readonly object object_0 = new object();

	private static Task<CoreWebView2Environment> task_0;

	private bool bool_0;

	private TaskCompletionSource<bool> taskCompletionSource_0 = new TaskCompletionSource<bool>();

	public const int int_0 = 161;

	public const int int_1 = 2;

	private int int_3;

	private float float_0;

	public static WinFormsMenuWindow? Instance
	{
		[CompilerGenerated]
		get
		{
			return gform0_0;
		}
		[CompilerGenerated]
		private set
		{
			gform0_0 = value;
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

	[DllImport("user32.dll")]
	public static extern int SendMessage(nint hWnd, int Msg, int wParam, int lParam);

	[DllImport("user32.dll")]
	public static extern bool ReleaseCapture();

	public static void PreInitializeEnvironment()
	{
		if (task_0 == null)
		{
			task_0 = PreInitializeEnvironmentAsync();
		}
	}

	private static async Task<CoreWebView2Environment> PreInitializeEnvironmentAsync()
	{
		try
		{
			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Kaban.cc", "WebView2Cache");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			CoreWebView2Environment result = await CoreWebView2Environment.CreateAsync((string)null, text, (CoreWebView2EnvironmentOptions)null);
			lock (object_0)
			{
				coreWebView2Environment_0 = result;
			}
			return result;
		}
		catch (Exception)
		{
			return null;
		}
	}

	public WinFormsMenuWindow()
	{
		Instance = this;
		try
		{
			((Control)this).Text = "Cerberus V3";
			_ = Screen.PrimaryScreen.WorkingArea;
			Rectangle bounds = Screen.PrimaryScreen.Bounds;
			int width = 900;
			int height = 720;
			if (bounds.Width > 1920)
			{
				double num = (double)bounds.Width / 1920.0;
				width = (int)(900.0 * num);
				height = (int)(720.0 * num);
				width = Math.Min(width, 1600);
				height = Math.Min(height, 1280);
			}
			((Form)this).Size = new Size(width, height);
			((Control)this).MinimumSize = new Size(900, 720);
			((Form)this).StartPosition = (FormStartPosition)1;
			((Form)this).TopMost = true;
			((Form)this).ShowInTaskbar = false;
			((Form)this).FormBorderStyle = (FormBorderStyle)0;
			((Control)this).BackColor = Color.FromArgb(20, 20, 20);
			((Control)this).Resize += MenuWindow_Resize;
			((Form)this).Load += async delegate
			{
				await InitializeAsync();
			};
		}
		catch (Exception)
		{
		}
	}

	private unsafe async Task InitializeAsync()
	{
		try
		{
			CoreWebView2Environment val = null;
			lock (object_0)
			{
				val = coreWebView2Environment_0;
			}
			if (val == null)
			{
				if (task_0 != null)
				{
					val = await task_0;
				}
				if (val == null)
				{
					string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Kaban.cc", "WebView2Cache");
					if (!Directory.Exists(text))
					{
						Directory.CreateDirectory(text);
					}
					try
					{
						val = await CoreWebView2Environment.CreateAsync((string)null, text, (CoreWebView2EnvironmentOptions)null);
					}
					catch (Exception ex)
					{
						if (ex.Message.Contains("Couldn't find a compatible") || ex.Message.Contains("WebView2") || ex.HResult == -2147024894)
						{
							throw new InvalidOperationException("Couldn't find a compatible Webview2 Runtime installation to host WebViews. Check WebView2Loader.dll!", ex);
						}
						throw;
					}
					lock (object_0)
					{
						coreWebView2Environment_0 = val;
					}
				}
			}
			coreWebView2Controller_0 = await val.CreateCoreWebView2ControllerAsync((IntPtr)((_003CInitializeAsync_003Ed__18*)this)->method_0());
			coreWebView2_0 = coreWebView2Controller_0.CoreWebView2;
			coreWebView2Controller_0.DefaultBackgroundColor = Color.Transparent;
			coreWebView2_0.Settings.IsZoomControlEnabled = false;
			coreWebView2_0.Settings.AreDefaultContextMenusEnabled = false;
			coreWebView2Controller_0.Bounds = new Rectangle(0, 0, ((Form)this).ClientSize.Width, ((Form)this).ClientSize.Height);
			coreWebView2Controller_0.IsVisible = true;
			coreWebView2_0.WebMessageReceived += OnWebMessageReceived;
			coreWebView2_0.Navigate("http://localhost:4649/");
			bool_0 = true;
			taskCompletionSource_0.TrySetResult(result: true);
			coreWebView2_0.NavigationCompleted += delegate
			{
				SendWindowSizeToWebView();
			};
		}
		catch (Exception ex2)
		{
			if (ex2.Message.Contains("Couldn't find a compatible") || ex2.Message.Contains("WebView2") || ex2.HResult == -2147024894)
			{
				throw new InvalidOperationException("WebView2 Runtime not installed", ex2);
			}
			MessageBox.Show("WebView2 Error: " + ex2.Message + "\n\nPlease check:\n1. WebView2Loader.dll is present\n2. Microsoft Edge WebView2 Runtime is installed\n3. Your Windows version is up to date", "WebView2 Initialization Error", (MessageBoxButtons)0, (MessageBoxIcon)16);
			taskCompletionSource_0.TrySetResult(result: false);
			throw;
		}
	}

	private void OnWebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
	{
		try
		{
			string text = e.TryGetWebMessageAsString();
			if (text == "drag_window")
			{
				((Control)this).BeginInvoke((Delegate)(Action)delegate
				{
					ReleaseCapture();
					SendMessage(method_0(), 161, 2, 0);
				});
			}
			else if (!(text == "close_window"))
			{
				if (text.StartsWith("chat_ping:"))
				{
					string text2 = text.Substring("chat_ping:".Length);
					int num = text2.IndexOf('|');
					if (num > 0)
					{
						string fromUser = text2.Substring(0, num);
						string message = text2.Substring(num + 1);
						ShowChatPingNotification(fromUser, message);
					}
				}
				else if (text == "get_window_size")
				{
					SendWindowSizeToWebView();
				}
			}
			else
			{
				((Control)this).Hide();
				if (coreWebView2Controller_0 != null)
				{
					coreWebView2Controller_0.IsVisible = false;
				}
			}
		}
		catch
		{
		}
	}

	private void SendWindowSizeToWebView()
	{
		if (coreWebView2_0 == null)
		{
			return;
		}
		try
		{
			string text = $"window.__KABAN_WINDOW_SIZE__ = {{width:{((Form)this).ClientSize.Width},height:{((Form)this).ClientSize.Height}}};";
			coreWebView2_0.ExecuteScriptAsync(text);
		}
		catch
		{
		}
	}

	private void MenuWindow_Resize(object sender, EventArgs e)
	{
		if (coreWebView2Controller_0 != null)
		{
			coreWebView2Controller_0.Bounds = new Rectangle(0, 0, ((Form)this).ClientSize.Width, ((Form)this).ClientSize.Height);
			SendWindowSizeToWebView();
		}
	}

	public static void ShowChatPingNotification(string fromUser, string message)
	{
		if (!CerberusConfig.NotificationSettings.ChatPingNotification)
		{
			return;
		}
		try
		{
			string text = ((message.Length <= 60) ? message : (message.Substring(0, 60) + "…"));
			NotificationOverlay.ShowNotification("\ud83d\udcac " + fromUser + " упомянул вас: " + text, 6f, 0.3f, 0.5f, new Vector4(0.39f, 0.72f, 0.96f, 1f));
		}
		catch
		{
		}
	}

	public void UpdateGameData(float x, float y, string serverName)
	{
		if (coreWebView2_0 == null)
		{
			return;
		}
		try
		{
			string text = $"window.__KABAN_COORDS__ = {{x:{x:F1},y:{y:F1}}}; window.__KABAN_SERVER_NAME__ = '{serverName.Replace("'", "\\'")}';";
			coreWebView2_0.ExecuteScriptAsync(text);
		}
		catch
		{
		}
	}

	public async Task WaitForReadyAsync(int timeoutMs = 5000)
	{
		if (!bool_0)
		{
			await Task.WhenAny(task2: Task.Delay(timeoutMs), task1: taskCompletionSource_0.Task);
		}
	}

	protected override void OnFormClosing(FormClosingEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)e.CloseReason != 3)
		{
			CoreWebView2Controller obj = coreWebView2Controller_0;
			if (obj != null)
			{
				obj.Close();
			}
			coreWebView2Controller_0 = null;
			((Form)this).OnFormClosing(e);
		}
		else
		{
			((CancelEventArgs)(object)e).Cancel = true;
			((Control)this).Hide();
			if (coreWebView2Controller_0 != null)
			{
				coreWebView2Controller_0.IsVisible = false;
			}
		}
	}

	protected override void OnVisibleChanged(EventArgs e)
	{
		((Form)this).OnVisibleChanged(e);
		if (coreWebView2Controller_0 != null)
		{
			coreWebView2Controller_0.IsVisible = ((Control)this).Visible;
		}
	}

	protected override void SetVisibleCore(bool value)
	{
		if (!((Control)this).IsHandleCreated)
		{
			((Control)this).CreateHandle();
			value = false;
		}
		((Form)this).SetVisibleCore(value);
	}

	public nint method_0()
	{
		return ((Control)this).Handle;
	}

	private string method_5(double double_0, string string_1)
	{
		return "Хитролох_иди_нахуй._2__4_7_________";
	}
}
