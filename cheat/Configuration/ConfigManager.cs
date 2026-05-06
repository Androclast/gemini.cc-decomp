using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using Hexa.NET.ImGui;
using WebControlServer;
using GhostRoleAutoTaker;
using CerberusConfig;
using CerberusConfigData;
using StableConfigSerializer;

namespace ConfigManager;

public sealed class ConfigManager
{
	public class Vector4Converter : JsonConverter<Vector4>
	{
		private bool bool_0;

		private int int_0;

		private byte byte_1;

		private char char_1;

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

		private char Char_0
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

		public override Vector4 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType != JsonTokenType.StartArray)
			{
				throw new JsonException();
			}
			reader.Read();
			float single = reader.GetSingle();
			reader.Read();
			float single2 = reader.GetSingle();
			reader.Read();
			float single3 = reader.GetSingle();
			reader.Read();
			float single4 = reader.GetSingle();
			reader.Read();
			return new Vector4(single, single2, single3, single4);
		}

		public override void Write(Utf8JsonWriter writer, Vector4 value, JsonSerializerOptions options)
		{
			writer.WriteStartArray();
			writer.WriteNumberValue(value.X);
			writer.WriteNumberValue(value.Y);
			writer.WriteNumberValue(value.Z);
			writer.WriteNumberValue(value.W);
			writer.WriteEndArray();
		}
	}

	public static string string_0 = "";

	public static int int_0 = -1;

	public static List<string> list_0 = new List<string>();

	public static string string_1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Kaban.cc", "cfg");

	private double double_0;

	private byte byte_0;

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

	public static void SaveConfig(string name)
	{
		try
		{
			if (!Directory.Exists(string_1))
			{
				Directory.CreateDirectory(string_1);
			}
			StableConfigSerializer.Save(Path.Combine(string_1, name + ".json"));
			Console.WriteLine("[ConfigManager] Config saved: " + name);
		}
		catch (Exception ex)
		{
			Console.WriteLine("[ConfigManager] Save failed: " + ex.Message);
		}
	}

	public static CerberusConfigData LoadConfig(string name)
	{
		try
		{
			string path = Path.Combine(string_1, name + ".json");
			if (!File.Exists(path))
			{
				Console.WriteLine("[ConfigManager] Config not found: " + name);
				return new CerberusConfigData();
			}
			StableConfigSerializer.Load(path);
			Console.WriteLine("[ConfigManager] Config loaded: " + name);
			if (WebControlServer.Instance != null)
			{
				WebControlServer.Instance.BroadcastConfig();
			}
			return GatherData();
		}
		catch (Exception ex)
		{
			Console.WriteLine("[ConfigManager] Load failed: " + ex.Message);
			return new CerberusConfigData();
		}
	}

	public static CerberusConfigData GatherData()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		//IL_043b: Unknown result type (might be due to invalid IL or missing references)
		//IL_044b: Unknown result type (might be due to invalid IL or missing references)
		//IL_045b: Unknown result type (might be due to invalid IL or missing references)
		//IL_07cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_081b: Unknown result type (might be due to invalid IL or missing references)
		//IL_08cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_091b: Unknown result type (might be due to invalid IL or missing references)
		//IL_097b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ddb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff5: Expected I4, but got O
		//IL_112c: Unknown result type (might be due to invalid IL or missing references)
		//IL_119c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c81: Expected I4, but got O
		//IL_1dfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e0d: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			CerberusConfigData gClass = new CerberusConfigData();
			gClass.GunAimBotData.Enabled = CerberusConfig.GunAimBot.Enabled;
			gClass.GunAimBotData.HotKey = CerberusConfig.GunAimBot.HotKey;
			gClass.GunAimBotData.TargetCritical = CerberusConfig.GunAimBot.TargetCritical;
			gClass.GunAimBotData.MinSpread = CerberusConfig.GunAimBot.MinSpread;
			gClass.GunAimBotData.HitScan = CerberusConfig.GunAimBot.HitScan;
			gClass.GunAimBotData.AutoPredict = CerberusConfig.GunAimBot.AutoPredict;
			gClass.GunAimBotData.PredictEnabled = CerberusConfig.GunAimBot.PredictEnabled;
			gClass.GunAimBotData.PredictCorrection = CerberusConfig.GunAimBot.PredictCorrection;
			gClass.GunAimBotData.ShowCircle = CerberusConfig.GunAimBot.ShowCircle;
			gClass.GunAimBotData.ShowLine = CerberusConfig.GunAimBot.ShowLine;
			gClass.GunAimBotData.CircleRadius = CerberusConfig.GunAimBot.CircleRadius;
			gClass.GunAimBotData.Color = CerberusConfig.GunAimBot.Color;
			gClass.GunAimBotData.TargetPriority = CerberusConfig.GunAimBot.TargetPriority;
			gClass.GunAimBotData.OnlyPriority = CerberusConfig.GunAimBot.OnlyPriority;
			gClass.GunAimBotData.MultiTarget = CerberusConfig.GunAimBot.MultiTarget;
			gClass.GunAimBotData.MultiTargetCount = CerberusConfig.GunAimBot.MultiTargetCount;
			gClass.GunAimBotData.IgnoreCuffed = CerberusConfig.GunAimBot.IgnoreCuffed;
			gClass.GunAimBotData.IgnoreDowned = CerberusConfig.GunAimBot.IgnoreDowned;
			gClass.GunAimBotData.IgnoreDead = CerberusConfig.GunAimBot.IgnoreDead;
			gClass.GunAimBotData.OnlyVisibleTargets = CerberusConfig.GunAimBot.OnlyVisibleTargets;
			gClass.GunAimBotData.AllowedJobs = CerberusConfig.GunAimBot.AllowedJobs;
			gClass.GunAimBotData.BlockedJobs = CerberusConfig.GunAimBot.BlockedJobs;
			gClass.GunAimBotData.RolePriority = CerberusConfig.GunAimBot.RolePriority;
			gClass.MeleeAimBotData.Enabled = CerberusConfig.MeleeAimBot.Enabled;
			gClass.MeleeAimBotData.LightHotKey = CerberusConfig.MeleeAimBot.LightHotKey;
			gClass.MeleeAimBotData.HeavyHotKey = CerberusConfig.MeleeAimBot.HeavyHotKey;
			gClass.MeleeAimBotData.TargetCritical = CerberusConfig.MeleeAimBot.TargetCritical;
			gClass.MeleeAimBotData.ShowCircle = CerberusConfig.MeleeAimBot.ShowCircle;
			gClass.MeleeAimBotData.ShowLine = CerberusConfig.MeleeAimBot.ShowLine;
			gClass.MeleeAimBotData.CircleRadius = CerberusConfig.MeleeAimBot.CircleRadius;
			gClass.MeleeAimBotData.Color = CerberusConfig.MeleeAimBot.Color;
			gClass.MeleeAimBotData.TargetPriority = CerberusConfig.MeleeAimBot.TargetPriority;
			gClass.MeleeAimBotData.OnlyPriority = CerberusConfig.MeleeAimBot.OnlyPriority;
			gClass.MeleeAimBotData.FixNetworkDelay = CerberusConfig.MeleeAimBot.FixNetworkDelay;
			gClass.MeleeAimBotData.FixDelay = CerberusConfig.MeleeAimBot.FixDelay;
			gClass.MeleeAimBotData.IgnoreCuffed = CerberusConfig.MeleeAimBot.IgnoreCuffed;
			gClass.MeleeAimBotData.IgnoreDowned = CerberusConfig.MeleeAimBot.IgnoreDowned;
			gClass.MeleeAimBotData.IgnoreDead = CerberusConfig.MeleeAimBot.IgnoreDead;
			gClass.MeleeAimBotData.AllowedJobs = CerberusConfig.MeleeAimBot.AllowedJobs;
			gClass.MeleeAimBotData.BlockedJobs = CerberusConfig.MeleeAimBot.BlockedJobs;
			gClass.MeleeAimBotData.RolePriority = CerberusConfig.MeleeAimBot.RolePriority;
			gClass.ThrowAimbotData.Enabled = CerberusConfig.ThrowAimbot.Enabled;
			gClass.ThrowAimbotData.Range = CerberusConfig.ThrowAimbot.Range;
			gClass.ThrowAimbotData.ThrowSpeed = CerberusConfig.ThrowAimbot.ThrowSpeed;
			gClass.ThrowAimbotData.PredictionEnabled = CerberusConfig.ThrowAimbot.PredictionEnabled;
			gClass.ThrowAimbotData.ShowTrajectory = CerberusConfig.ThrowAimbot.ShowTrajectory;
			gClass.ThrowAimbotData.TargetPriority = CerberusConfig.ThrowAimbot.TargetPriority;
			gClass.ThrowAimbotData.OnlyPriority = CerberusConfig.ThrowAimbot.OnlyPriority;
			gClass.ThrowAimbotData.IgnoreCuffed = CerberusConfig.ThrowAimbot.IgnoreCuffed;
			gClass.ThrowAimbotData.IgnoreDowned = CerberusConfig.ThrowAimbot.IgnoreDowned;
			gClass.ThrowAimbotData.IgnoreDead = CerberusConfig.ThrowAimbot.IgnoreDead;
			gClass.ThrowAimbotData.AllowedJobs = CerberusConfig.ThrowAimbot.AllowedJobs;
			gClass.ThrowAimbotData.BlockedJobs = CerberusConfig.ThrowAimbot.BlockedJobs;
			gClass.ThrowAimbotData.RolePriority = CerberusConfig.ThrowAimbot.RolePriority;
			gClass.BacktrackData.Enabled = CerberusConfig.Backtrack.Enabled;
			gClass.BacktrackData.Mode = CerberusConfig.Backtrack.Mode;
			gClass.BacktrackData.UseFakeLag = CerberusConfig.Backtrack.UseFakeLag;
			gClass.BacktrackData.FakeLagMs = CerberusConfig.Backtrack.FakeLagMs;
			gClass.BacktrackData.ShowVisuals = CerberusConfig.Backtrack.ShowVisuals;
			gClass.BacktrackData.VisualsMode = CerberusConfig.Backtrack.VisualsMode;
			gClass.BacktrackData.VisualsColor = CerberusConfig.Backtrack.VisualsColor;
			gClass.BacktrackData.ShowLine = CerberusConfig.Backtrack.ShowLine;
			gClass.EyeData.FovEnabled = CerberusConfig.Eye.FovEnabled;
			gClass.EyeData.FullBrightEnabled = CerberusConfig.Eye.FullBrightEnabled;
			gClass.EyeData.Zoom = CerberusConfig.Eye.Zoom;
			gClass.EyeData.SuperFastZoom = CerberusConfig.Eye.SuperFastZoom;
			gClass.EyeData.FovHotKey = CerberusConfig.Eye.FovHotKey;
			gClass.EyeData.FullBrightHotKey = CerberusConfig.Eye.FullBrightHotKey;
			gClass.EyeData.ZoomUpHotKey = CerberusConfig.Eye.ZoomUpHotKey;
			gClass.EyeData.ZoomDownHotKey = CerberusConfig.Eye.ZoomDownHotKey;
			gClass.EspData.Enabled = CerberusConfig.Esp.Enabled;
			gClass.EspData.ShowName = CerberusConfig.Esp.ShowName;
			gClass.EspData.ShowCKey = CerberusConfig.Esp.ShowCKey;
			gClass.EspData.ShowAntag = CerberusConfig.Esp.ShowAntag;
			gClass.EspData.ShowFriend = CerberusConfig.Esp.ShowFriend;
			gClass.EspData.ShowPriority = CerberusConfig.Esp.ShowPriority;
			gClass.EspData.ShowCombatMode = CerberusConfig.Esp.ShowCombatMode;
			gClass.EspData.ShowImplants = CerberusConfig.Esp.ShowImplants;
			gClass.EspData.ShowContraband = CerberusConfig.Esp.ShowContraband;
			gClass.EspData.ShowWeapon = CerberusConfig.Esp.ShowWeapon;
			gClass.EspData.ShowNoSlip = CerberusConfig.Esp.ShowNoSlip;
			gClass.EspData.NameColor = CerberusConfig.Esp.NameColor;
			gClass.EspData.CKeyColor = CerberusConfig.Esp.CKeyColor;
			gClass.EspData.AntagColor = CerberusConfig.Esp.AntagColor;
			gClass.EspData.FriendColor = CerberusConfig.Esp.FriendColor;
			gClass.EspData.PriorityColor = CerberusConfig.Esp.PriorityColor;
			gClass.EspData.CombatModeColor = CerberusConfig.Esp.CombatModeColor;
			gClass.EspData.ImplantsColor = CerberusConfig.Esp.ImplantsColor;
			gClass.EspData.ContrabandColor = CerberusConfig.Esp.ContrabandColor;
			gClass.EspData.WeaponColor = CerberusConfig.Esp.WeaponColor;
			gClass.EspData.NoSlipColor = CerberusConfig.Esp.NoSlipColor;
			gClass.EspData.MainFontPath = CerberusConfig.Esp.MainFontPath;
			gClass.EspData.MainFontIndex = CerberusConfig.Esp.MainFontIndex;
			gClass.EspData.MainFontSize = CerberusConfig.Esp.MainFontSize;
			gClass.EspData.OtherFontPath = CerberusConfig.Esp.OtherFontPath;
			gClass.EspData.OtherFontIndex = CerberusConfig.Esp.OtherFontIndex;
			gClass.EspData.OtherFontSize = CerberusConfig.Esp.OtherFontSize;
			gClass.EspData.FontInterval = CerberusConfig.Esp.FontInterval;
			gClass.EspData.TextOffsetX = CerberusConfig.Esp.TextOffsetX;
			gClass.EspData.TextOffsetY = CerberusConfig.Esp.TextOffsetY;
			gClass.HudData.ShowHealth = CerberusConfig.Hud.ShowHealth;
			gClass.HudData.ShowAntag = CerberusConfig.Hud.ShowAntag;
			gClass.HudData.ShowJobIcons = CerberusConfig.Hud.ShowJobIcons;
			gClass.HudData.ShowMindShieldIcons = CerberusConfig.Hud.ShowMindShieldIcons;
			gClass.HudData.ShowCriminalRecordIcons = CerberusConfig.Hud.ShowCriminalRecordIcons;
			gClass.HudData.ShowSyndicateIcons = CerberusConfig.Hud.ShowSyndicateIcons;
			gClass.HudData.ChemicalAnalysis = CerberusConfig.Hud.ChemicalAnalysis;
			gClass.HudData.ShowElectrocution = CerberusConfig.Hud.ShowElectrocution;
			gClass.HudData.ShowStamina = CerberusConfig.Hud.ShowStamina;
			gClass.HudData.StaminaColor = CerberusConfig.Hud.StaminaColor;
			gClass.HudData.ShowThirstIcons = CerberusConfig.Hud.ShowThirstIcons;
			gClass.HudData.ShowHungerIcons = CerberusConfig.Hud.ShowHungerIcons;
			gClass.HudData.ShowContrabandDetails = CerberusConfig.Hud.ShowContrabandDetails;
			gClass.HudData.ShowAccessReaderSettings = CerberusConfig.Hud.ShowAccessReaderSettings;
			gClass.HudData.HealthBarOffsetX = CerberusConfig.Hud.HealthBarOffsetX;
			gClass.HudData.HealthBarOffsetY = CerberusConfig.Hud.HealthBarOffsetY;
			gClass.HudData.HealthBarWidth = CerberusConfig.Hud.HealthBarWidth;
			gClass.HudData.HealthBarHeight = CerberusConfig.Hud.HealthBarHeight;
			gClass.HudData.StaminaBarOffsetX = CerberusConfig.Hud.StaminaBarOffsetX;
			gClass.HudData.StaminaBarOffsetY = CerberusConfig.Hud.StaminaBarOffsetY;
			gClass.HudData.StaminaBarWidth = CerberusConfig.Hud.StaminaBarWidth;
			gClass.HudData.StaminaBarHeight = CerberusConfig.Hud.StaminaBarHeight;
			gClass.StorageViewerData.Enabled = CerberusConfig.StorageViewer.Enabled;
			gClass.StorageViewerData.Color = CerberusConfig.StorageViewer.Color;
			gClass.StorageViewerData.HotKey = CerberusConfig.StorageViewer.HotKey;
			gClass.StorageViewerData.FontPath = CerberusConfig.StorageViewer.FontPath;
			gClass.StorageViewerData.FontSize = CerberusConfig.StorageViewer.FontSize;
			gClass.AccessViewerData.Enabled = CerberusConfig.AccessViewer.Enabled;
			gClass.AccessViewerData.Color = CerberusConfig.AccessViewer.Color;
			gClass.AccessViewerData.HotKey = CerberusConfig.AccessViewer.HotKey;
			gClass.AccessViewerData.FontPath = CerberusConfig.AccessViewer.FontPath;
			gClass.AccessViewerData.FontSize = CerberusConfig.AccessViewer.FontSize;
			gClass.AccessCheckerData.Enabled = CerberusConfig.AccessChecker.Enabled;
			gClass.AccessCheckerData.Range = CerberusConfig.AccessChecker.Range;
			gClass.AccessCheckerData.IconSize = CerberusConfig.AccessChecker.IconSize;
			gClass.AccessCheckerData.CheckmarkColor = CerberusConfig.AccessChecker.CheckmarkColor;
			gClass.AccessCheckerData.CrossColor = CerberusConfig.AccessChecker.CrossColor;
			gClass.AccessCheckerData.UseTextures = CerberusConfig.AccessChecker.UseTextures;
			gClass.MovementData.ShieldSurfEnabled = CerberusConfig.Movement.ShieldSurfEnabled;
			gClass.MovementData.ShieldSurfRadius = CerberusConfig.Movement.ShieldSurfRadius;
			gClass.MovementData.ToggleKey = CerberusConfig.Movement.ToggleKey;
			gClass.MovementData.AntiAimEnabled = CerberusConfig.Movement.AntiAimEnabled;
			gClass.MovementData.AntiAimStepLength = CerberusConfig.Movement.AntiAimStepLength;
			gClass.MovementData.AntiAimCircleRadius = CerberusConfig.Movement.AntiAimCircleRadius;
			gClass.MovementData.PixelSurfEnabled = CerberusConfig.Movement.PixelSurfEnabled;
			gClass.MovementData.PixelSurfKey = CerberusConfig.Movement.PixelSurfKey;
			gClass.MovementData.PixelSurfMode = CerberusConfig.Movement.PixelSurfMode;
			gClass.MovementData.SpeedSaverEnabled = CerberusConfig.Movement.SpeedSaverEnabled;
			gClass.MovementData.SpeedSaverStrafeDurationMs = CerberusConfig.Movement.SpeedSaverStrafeDurationMs;
			gClass.SettingsData.UiCustomizable = CerberusConfig.Settings.UiCustomizable;
			gClass.SettingsData.ShowMenu = CerberusConfig.Settings.ShowMenu;
			gClass.SettingsData.ShowMenuHotKey = CerberusConfig.Settings.ShowMenuHotKey;
			gClass.SettingsData.ShowDebugConsole = CerberusConfig.Settings.ShowDebugConsole;
			gClass.SettingsData.CurrentLanguage = CerberusConfig.Settings.CurrentLanguage;
			gClass.SettingsData.ClydePatch = CerberusConfig.Settings.ClydePatch;
			gClass.SettingsData.OverlaysPatch = CerberusConfig.Settings.OverlaysPatch;
			gClass.SettingsData.SmokePatch = CerberusConfig.Settings.SmokePatch;
			gClass.SettingsData.AdminPatch = CerberusConfig.Settings.AdminPatch;
			gClass.SettingsData.DamageForcePatch = CerberusConfig.Settings.DamageForcePatch;
			gClass.SettingsData.NoDmgFriendPatch = CerberusConfig.Settings.NoDmgFriendPatch;
			gClass.SettingsData.AntiScreenGrubPatch = CerberusConfig.Settings.AntiScreenGrubPatch;
			gClass.SettingsData.TranslateChatPatch = CerberusConfig.Settings.TranslateChatPatch;
			gClass.SettingsData.TranslateChatLang = CerberusConfig.Settings.TranslateChatLang;
			gClass.SettingsData.TranslateMePatch = CerberusConfig.Settings.TranslateMePatch;
			gClass.SettingsData.TranslateMeLang = CerberusConfig.Settings.TranslateMeLang;
			gClass.SettingsData.NoCameraKickPatch = CerberusConfig.Settings.NoCameraKickPatch;
			gClass.HudOverlayData.Enabled = CerberusConfig.HudOverlay.Enabled;
			gClass.HudOverlayData.EditMode = CerberusConfig.HudOverlay.EditMode;
			gClass.HudOverlayData.ShowWatermark = CerberusConfig.HudOverlay.ShowWatermark;
			gClass.HudOverlayData.WatermarkPos = CerberusConfig.HudOverlay.WatermarkPos;
			gClass.HudOverlayData.ShowFps = CerberusConfig.HudOverlay.ShowFps;
			gClass.HudOverlayData.FpsPos = CerberusConfig.HudOverlay.FpsPos;
			gClass.HudOverlayData.ShowCoords = CerberusConfig.HudOverlay.ShowCoords;
			gClass.HudOverlayData.CoordsPos = CerberusConfig.HudOverlay.CoordsPos;
			gClass.HudOverlayData.ShowSpeed = CerberusConfig.HudOverlay.ShowSpeed;
			gClass.HudOverlayData.SpeedPos = CerberusConfig.HudOverlay.SpeedPos;
			gClass.HudOverlayData.TextColor = CerberusConfig.HudOverlay.TextColor;
			gClass.HudOverlayData.BgColor = CerberusConfig.HudOverlay.BgColor;
			gClass.HudOverlayData.ShowTargetInfo = CerberusConfig.HudOverlay.ShowTargetInfo;
			gClass.HudOverlayData.TargetInfoPos = CerberusConfig.HudOverlay.TargetInfoPos;
			gClass.HudOverlayData.ShowPing = CerberusConfig.HudOverlay.ShowPing;
			gClass.HudOverlayData.PingPos = CerberusConfig.HudOverlay.PingPos;
			gClass.HudOverlayData.ShowRoundTime = CerberusConfig.HudOverlay.ShowRoundTime;
			gClass.HudOverlayData.RoundTimePos = CerberusConfig.HudOverlay.RoundTimePos;
			gClass.HudOverlayData.ShowArrayList = CerberusConfig.HudOverlay.ShowArrayList;
			gClass.HudOverlayData.ArrayListPos = CerberusConfig.HudOverlay.ArrayListPos;
			gClass.HudOverlayData.ArrayListRainbow = CerberusConfig.HudOverlay.ArrayListRainbow;
			gClass.HudOverlayData.ShowStaffList = CerberusConfig.HudOverlay.ShowStaffList;
			gClass.HudOverlayData.StaffListPos = CerberusConfig.HudOverlay.StaffListPos;
			gClass.HudOverlayData.StaffListRefreshSeconds = CerberusConfig.HudOverlay.StaffListRefreshSeconds;
			gClass.GunHelperData.Enabled = CerberusConfig.GunHelper.Enabled;
			gClass.GunHelperData.ShowAmmo = CerberusConfig.GunHelper.ShowAmmo;
			gClass.GunHelperData.AutoBolt = CerberusConfig.GunHelper.AutoBolt;
			gClass.GunHelperData.AutoReload = CerberusConfig.GunHelper.AutoReload;
			gClass.GunHelperData.AutoReloadDelay = CerberusConfig.GunHelper.AutoReloadDelay;
			gClass.GunHelperData.RotateToTarget = CerberusConfig.GunHelper.RotateToTarget;
			gClass.MeleeHelperData.Enabled = CerberusConfig.MeleeHelper.Enabled;
			gClass.MeleeHelperData.Attack360 = CerberusConfig.MeleeHelper.Attack360;
			gClass.MeleeHelperData.AutoAttack = CerberusConfig.MeleeHelper.AutoAttack;
			gClass.MeleeHelperData.RotateToTarget = CerberusConfig.MeleeHelper.RotateToTarget;
			gClass.HitSoundData.Enabled = CerberusConfig.HitSound.Enabled;
			gClass.HitSoundData.SoundIndex = CerberusConfig.HitSound.SoundIndex;
			gClass.HitSoundData.Volume = CerberusConfig.HitSound.Volume;
			gClass.KillSoundData.Enabled = CerberusConfig.KillSound.Enabled;
			gClass.KillSoundData.SoundIndex = CerberusConfig.KillSound.SoundIndex;
			gClass.KillSoundData.Volume = CerberusConfig.KillSound.Volume;
			gClass.GrillElectrocutionData.Enabled = CerberusConfig.GrillElectrocution.Enabled;
			gClass.GrillElectrocutionData.Color = CerberusConfig.GrillElectrocution.Color;
			gClass.GrillElectrocutionData.MaxDistance = CerberusConfig.GrillElectrocution.MaxDistance;
			gClass.GrillElectrocutionData.Opacity = CerberusConfig.GrillElectrocution.Opacity;
			gClass.HealthInfoData.Enabled = CerberusConfig.HealthInfo.Enabled;
			gClass.HealthInfoData.FontPath = CerberusConfig.HealthInfo.FontPath;
			gClass.HealthInfoData.FontIndex = CerberusConfig.HealthInfo.FontIndex;
			gClass.HealthInfoData.FontSize = CerberusConfig.HealthInfo.FontSize;
			gClass.HealthInfoData.TextOffset = CerberusConfig.HealthInfo.TextOffset;
			gClass.HealthInfoData.HoldKey = CerberusConfig.HealthInfo.HoldKey;
			gClass.AnomalyScannerData.Enabled = CerberusConfig.AnomalyScanner.Enabled;
			gClass.AnomalyScannerData.Color = CerberusConfig.AnomalyScanner.Color;
			gClass.AnomalyScannerData.MaxDistance = CerberusConfig.AnomalyScanner.MaxDistance;
			gClass.AnomalyScannerData.FontPath = CerberusConfig.AnomalyScanner.FontPath;
			gClass.AnomalyScannerData.FontSize = CerberusConfig.AnomalyScanner.FontSize;
			gClass.AnomalyScannerData.HotKey = CerberusConfig.AnomalyScanner.HotKey;
			gClass.AutoDoorData.Enabled = CerberusConfig.AutoDoor.Enabled;
			gClass.AutoDoorData.AutoClose = CerberusConfig.AutoDoor.AutoClose;
			gClass.AutoLooterData.Enabled = CerberusConfig.AutoLooter.Enabled;
			gClass.AutoLooterData.Range = CerberusConfig.AutoLooter.Range;
			gClass.AutoLooterData.PickupDelay = CerberusConfig.AutoLooter.PickupDelay;
			gClass.AutoLooterData.ToggleKey = CerberusConfig.AutoLooter.ToggleKey;
			gClass.AutoLooterData.LootEntries = CerberusConfig.AutoLooter.LootEntries;
			gClass.MiscData.ZeroGSpeedHackEnabled = CerberusConfig.Misc.ZeroGSpeedHackEnabled;
			gClass.MiscData.ZeroGSpeedDelay = CerberusConfig.Misc.ZeroGSpeedDelay;
			gClass.MiscData.TargetStrafeEnabled = CerberusConfig.Misc.TargetStrafeEnabled;
			gClass.MiscData.TargetStrafeDistance = CerberusConfig.Misc.TargetStrafeDistance;
			gClass.MiscData.TargetStrafeRange = CerberusConfig.Misc.TargetStrafeRange;
			gClass.MiscData.TrashTalkEnabled = CerberusConfig.Misc.TrashTalkEnabled;
			gClass.MiscData.DamageOverlayEnabled = CerberusConfig.Misc.DamageOverlayEnabled;
			gClass.MiscData.AntiSoapEnabled = CerberusConfig.Misc.AntiSoapEnabled;
			gClass.MiscData.AntiAfkEnabled = CerberusConfig.Misc.AntiAfkEnabled;
			gClass.MiscData.AntiAimEnabled = CerberusConfig.Misc.AntiAimEnabled;
			gClass.MiscData.AutoRotateSpeed = CerberusConfig.Misc.AutoRotateSpeed;
			gClass.MiscData.ItemSearcherEnabled = CerberusConfig.Misc.ItemSearcherEnabled;
			gClass.MiscData.ItemSearchEntries = CerberusConfig.Misc.ItemSearchEntries;
			gClass.MiscData.ItemSearcherShowName = CerberusConfig.Misc.ItemSearcherShowName;
			gClass.MiscData.ShowExplosive = CerberusConfig.Misc.ShowExplosive;
			gClass.MiscData.ShowTrajectory = CerberusConfig.Misc.ShowTrajectory;
			gClass.MiscData.AutoPeekEnabled = CerberusConfig.Misc.AutoPeekEnabled;
			gClass.MiscData.AutoPeekKey = CerberusConfig.Misc.AutoPeekKey;
			gClass.MiscData.AutoPeekColor = CerberusConfig.Misc.AutoPeekColor;
			gClass.MiscData.AutoGhostRoleEnabled = GhostRoleAutoTaker.bool_0;
			gClass.MiscData.AutoGhostRoleWantedRoles = GhostRoleAutoTaker.hashSet_0.ToList();
			gClass.MiscData.AutoGhostRolePickDelay = GhostRoleAutoTaker.int_0;
			gClass.AutoCuffData.Enabled = CerberusConfig.AutoCuff.Enabled;
			gClass.AutoCuffData.ActivationKey = ((object)Unsafe.As<ImGuiKey, ImGuiKey>(ref CerberusConfig.AutoCuff.ActivationKey)/*cast due to constrained. prefix*/).ToString();
			gClass.AutoCuffData.TargetPriority = (int)CerberusConfig.AutoCuff.TargetPriority;
			gClass.AutoCuffData.OnlyStunned = CerberusConfig.AutoCuff.OnlyStunned;
			gClass.AutoStopData.Enabled = CerberusConfig.AutoStop.Enabled;
			gClass.AutoStopData.ActivationKey = ((object)Unsafe.As<ImGuiKey, ImGuiKey>(ref CerberusConfig.AutoStop.ActivationKey)/*cast due to constrained. prefix*/).ToString();
			gClass.AutoStopData.IntervalMs = CerberusConfig.AutoStop.IntervalMs;
			gClass.AutoHypoData.Enabled = CerberusConfig.AutoHypo.Enabled;
			gClass.AutoHypoData.HpThreshold = CerberusConfig.AutoHypo.HpThreshold;
			gClass.AutoHypoData.InjectCount = CerberusConfig.AutoHypo.InjectCount;
			gClass.AutoHypoData.ForceKey = ((object)Unsafe.As<ImGuiKey, ImGuiKey>(ref CerberusConfig.AutoHypo.ForceKey)/*cast due to constrained. prefix*/).ToString();
			gClass.AutoStripData.Enabled = CerberusConfig.AutoStrip.Enabled;
			gClass.AutoStripData.Range = CerberusConfig.AutoStrip.Range;
			gClass.AutoStripData.Cooldown = CerberusConfig.AutoStrip.Cooldown;
			gClass.AutoStripData.StripWeaponsFirst = CerberusConfig.AutoStrip.StripWeaponsFirst;
			gClass.AutoStripData.StripArmor = CerberusConfig.AutoStrip.StripArmor;
			gClass.AutoStripData.StripClothing = CerberusConfig.AutoStrip.StripClothing;
			gClass.AutoStripData.AutoMode = CerberusConfig.AutoStrip.AutoMode;
			gClass.AutoStripData.StripAllKey = ((object)Unsafe.As<ImGuiKey, ImGuiKey>(ref CerberusConfig.AutoStrip.StripAllKey)/*cast due to constrained. prefix*/).ToString();
			gClass.AutoSlipData.Enabled = CerberusConfig.AutoSlip.Enabled;
			gClass.AutoSlipData.ActivationKey = CerberusConfig.AutoSlip.ActivationKey;
			gClass.AutoSlipData.Range = CerberusConfig.AutoSlip.Range;
			gClass.AutoSlipData.ThrowSpeed = CerberusConfig.AutoSlip.ThrowSpeed;
			gClass.AutoSlipData.UsePrediction = CerberusConfig.AutoSlip.UsePrediction;
			gClass.AutoSlipData.LeadDistance = CerberusConfig.AutoSlip.LeadDistance;
			gClass.AutoSlipData.UseRolePriority = CerberusConfig.AutoSlip.UseRolePriority;
			gClass.AutoDeconstructData.Enabled = CerberusConfig.AutoDeconstruct.Enabled;
			gClass.AutoDeconstructData.TargetKey = CerberusConfig.AutoDeconstruct.TargetKey;
			gClass.AutoDeconstructData.ActionDelay = CerberusConfig.AutoDeconstruct.ActionDelay;
			gClass.HardwareUnlockerData.Enabled = CerberusConfig.HardwareUnlocker.Enabled;
			gClass.HardwareUnlockerData.HighPriority = CerberusConfig.HardwareUnlocker.HighPriority;
			gClass.HardwareUnlockerData.RealtimePriority = CerberusConfig.HardwareUnlocker.RealtimePriority;
			gClass.HardwareUnlockerData.UnlockAllCores = CerberusConfig.HardwareUnlocker.UnlockAllCores;
			gClass.HardwareUnlockerData.OptimizeThreadPool = CerberusConfig.HardwareUnlocker.OptimizeThreadPool;
			gClass.HardwareUnlockerData.OptimizeGC = CerberusConfig.HardwareUnlocker.OptimizeGC;
			gClass.HardwareUnlockerData.GPUPriority = CerberusConfig.HardwareUnlocker.GPUPriority;
			gClass.PerformanceData.Enabled = CerberusConfig.Performance.Enabled;
			gClass.PerformanceData.DisableParticles = CerberusConfig.Performance.DisableParticles;
			gClass.PerformanceData.DisableAnimations = CerberusConfig.Performance.DisableAnimations;
			gClass.PerformanceData.SimplifyShaders = CerberusConfig.Performance.SimplifyShaders;
			gClass.PerformanceData.SimplifyLighting = CerberusConfig.Performance.SimplifyLighting;
			gClass.PerformanceData.DisablePostProcessing = CerberusConfig.Performance.DisablePostProcessing;
			gClass.PerformanceData.AggressiveCulling = CerberusConfig.Performance.AggressiveCulling;
			gClass.PerformanceData.CullingDistance = CerberusConfig.Performance.CullingDistance;
			gClass.PerformanceData.DisableDecals = CerberusConfig.Performance.DisableDecals;
			gClass.PerformanceData.LowQualitySprites = CerberusConfig.Performance.LowQualitySprites;
			gClass.PerformanceData.DisableWeatherEffects = CerberusConfig.Performance.DisableWeatherEffects;
			gClass.PerformanceData.ReducePhysicsQuality = CerberusConfig.Performance.ReducePhysicsQuality;
			gClass.PerformanceData.DisableFootsteps = CerberusConfig.Performance.DisableFootsteps;
			gClass.NoTrashData.HideCasings = CerberusConfig.NoTrash.HideCasings;
			gClass.NoTrashData.HideDecals = CerberusConfig.NoTrash.HideDecals;
			gClass.NoTrashData.HideLamps = CerberusConfig.NoTrash.HideLamps;
			gClass.FoamFadingData.Enabled = CerberusConfig.FoamFading.Enabled;
			gClass.FoamFadingData.Alpha = CerberusConfig.FoamFading.Alpha;
			gClass.InsulationCheckerData.Enabled = CerberusConfig.InsulationChecker.Enabled;
			gClass.HitParticlesData.Enabled = CerberusConfig.HitParticles.Enabled;
			gClass.HitParticlesData.ParticleCount = CerberusConfig.HitParticles.ParticleCount;
			gClass.HitParticlesData.ParticleMode = CerberusConfig.HitParticles.ParticleMode;
			gClass.HitParticlesData.Opacity = CerberusConfig.HitParticles.Opacity;
			gClass.HitParticlesData.ParticleSize = CerberusConfig.HitParticles.ParticleSize;
			gClass.HitParticlesData.ParticleLifetime = CerberusConfig.HitParticles.ParticleLifetime;
			gClass.HitParticlesData.ParticleColor = CerberusConfig.HitParticles.ParticleColor;
			gClass.FreeCamData.Enabled = CerberusConfig.FreeCam.Enabled;
			gClass.FreeCamData.Speed = CerberusConfig.FreeCam.Speed;
			gClass.AutoMedipenData.Enabled = CerberusConfig.AutoMedipen.Enabled;
			gClass.AutoMedipenData.HpThreshold = CerberusConfig.AutoMedipen.HpThreshold;
			gClass.AutoImplantData.Enabled = CerberusConfig.AutoImplant.Enabled;
			gClass.GrenadeHelperData.Enabled = CerberusConfig.GrenadeHelper.Enabled;
			gClass.GrenadeHelperData.ShowTrajectory = CerberusConfig.GrenadeHelper.ShowTrajectory;
			gClass.GrenadeHelperData.ShowRadius = CerberusConfig.GrenadeHelper.ShowRadius;
			gClass.NukeBruteforceData.Enabled = CerberusConfig.NukeBruteforce.Enabled;
			gClass.NukeBruteforceData.CodeLength = CerberusConfig.NukeBruteforce.CodeLength;
			gClass.NukeBruteforceData.Speed = CerberusConfig.NukeBruteforce.Speed;
			gClass.NukeBruteforceData.InputDelay = CerberusConfig.NukeBruteforce.InputDelay;
			gClass.UplinkBruteforceData.Enabled = CerberusConfig.UplinkBruteforce.Enabled;
			gClass.UplinkBruteforceData.Speed = CerberusConfig.UplinkBruteforce.Speed;
			gClass.UplinkBruteforceData.InputDelay = CerberusConfig.UplinkBruteforce.InputDelay;
			gClass.UplinkBruteforceData.RandomMode = CerberusConfig.UplinkBruteforce.RandomMode;
			gClass.InstantPickupData.Enabled = CerberusConfig.InstantPickup.Enabled;
			gClass.InstantPickupData.SmartEquipEnabled = CerberusConfig.InstantPickup.SmartEquipEnabled;
			gClass.HitboxVisualizerData.Enabled = CerberusConfig.HitboxVisualizer.Enabled;
			gClass.SolutionScannerData.Enabled = CerberusConfig.SolutionScanner.Enabled;
			gClass.NoInteractData.Enabled = CerberusConfig.NoInteract.Enabled;
			gClass.NotificationsData.Enabled = CerberusConfig.Notifications.Enabled;
			gClass.NotificationsData.MaxNotifications = CerberusConfig.Notifications.MaxNotifications;
			gClass.NotificationsData.FontSize = CerberusConfig.Notifications.FontSize;
			gClass.NotificationsData.AnchorPosition = CerberusConfig.Notifications.AnchorPosition;
			gClass.NotificationsData.IgnoreSizeCheck = CerberusConfig.Notifications.IgnoreSizeCheck;
			gClass.NotificationSettingsData.Enabled = CerberusConfig.NotificationSettings.Enabled;
			gClass.NotificationSettingsData.LowHpNotification = CerberusConfig.NotificationSettings.LowHpNotification;
			gClass.NotificationSettingsData.LowHpThreshold = CerberusConfig.NotificationSettings.LowHpThreshold;
			gClass.NotificationSettingsData.LowStaminaNotification = CerberusConfig.NotificationSettings.LowStaminaNotification;
			gClass.NotificationSettingsData.LowStaminaThreshold = CerberusConfig.NotificationSettings.LowStaminaThreshold;
			gClass.NotificationSettingsData.AntagSpawnNotification = CerberusConfig.NotificationSettings.AntagSpawnNotification;
			gClass.NotificationSettingsData.AntagSpawnDelay = CerberusConfig.NotificationSettings.AntagSpawnDelay;
			gClass.NotificationSettingsData.FeatureToggleNotification = CerberusConfig.NotificationSettings.FeatureToggleNotification;
			gClass.NotificationSettingsData.LowAmmoNotification = CerberusConfig.NotificationSettings.LowAmmoNotification;
			gClass.NotificationSettingsData.LowAmmoThreshold = CerberusConfig.NotificationSettings.LowAmmoThreshold;
			gClass.NotificationSettingsData.FriendJoinNotification = CerberusConfig.NotificationSettings.FriendJoinNotification;
			gClass.NotificationSettingsData.DangerousAtmosNotification = CerberusConfig.NotificationSettings.DangerousAtmosNotification;
			gClass.NotificationSettingsData.FeatureAutoDisableNotification = CerberusConfig.NotificationSettings.FeatureAutoDisableNotification;
			gClass.NotificationSettingsData.AnimationMode = CerberusConfig.NotificationSettings.AnimationMode;
			gClass.NotificationSettingsData.FadeInTime = CerberusConfig.NotificationSettings.FadeInTime;
			gClass.NotificationSettingsData.FadeOutTime = CerberusConfig.NotificationSettings.FadeOutTime;
			gClass.NotificationSettingsData.ShowProgressBar = CerberusConfig.NotificationSettings.ShowProgressBar;
			gClass.SoundsData.Enabled = CerberusConfig.Sounds.Enabled;
			gClass.SoundsData.SelectedPackIndex = CerberusConfig.Sounds.SelectedPackIndex;
			gClass.ChamsData.Enabled = CerberusConfig.Chams.Enabled;
			gClass.ChamsData.Mode = CerberusConfig.Chams.Mode;
			gClass.ChamsData.Color = CerberusConfig.Chams.Color;
			gClass.ChamsData.ShowOnLocalPlayer = CerberusConfig.Chams.ShowOnLocalPlayer;
			gClass.TracersData.Enabled = CerberusConfig.Tracers.Enabled;
			gClass.TracersData.ArrowVariant = CerberusConfig.Tracers.ArrowVariant;
			gClass.TracersData.ArrowColor = CerberusConfig.Tracers.ArrowColor;
			gClass.MinecraftVisualsData.JumpCirclesEnabled = CerberusConfig.MinecraftVisuals.JumpCirclesEnabled;
			gClass.MinecraftVisualsData.JumpCircleVariant = CerberusConfig.MinecraftVisuals.JumpCircleVariant;
			gClass.MinecraftVisualsData.JumpCircleFadeInSpeed = CerberusConfig.MinecraftVisuals.JumpCircleFadeInSpeed;
			gClass.MinecraftVisualsData.JumpCircleFadeOutSpeed = CerberusConfig.MinecraftVisuals.JumpCircleFadeOutSpeed;
			gClass.MinecraftVisualsData.JumpCircleRotationSpeed = CerberusConfig.MinecraftVisuals.JumpCircleRotationSpeed;
			gClass.MinecraftVisualsData.JumpCircleColor = CerberusConfig.MinecraftVisuals.JumpCircleColor;
			gClass.MinecraftVisualsData.BlockOutlineEnabled = CerberusConfig.MinecraftVisuals.BlockOutlineEnabled;
			gClass.TrailsData.Enabled = CerberusConfig.Trails.Enabled;
			gClass.TrailsData.TrailMode = CerberusConfig.Trails.TrailMode;
			gClass.TrailsData.TrailSize = CerberusConfig.Trails.TrailSize;
			gClass.TrailsData.TrailLifetime = CerberusConfig.Trails.TrailLifetime;
			gClass.TrailsData.TrailLength = CerberusConfig.Trails.TrailLength;
			gClass.TrailsData.ParticleCount = CerberusConfig.Trails.ParticleCount;
			gClass.TrailsData.ParticleSpawnRate = CerberusConfig.Trails.ParticleSpawnRate;
			gClass.TrailsData.TrailColor = CerberusConfig.Trails.TrailColor;
			gClass.PlayerGlowData.Enabled = CerberusConfig.PlayerGlow.Enabled;
			gClass.PlayerGlowData.GlowSize = CerberusConfig.PlayerGlow.GlowSize;
			gClass.PlayerGlowData.GlowDensity = CerberusConfig.PlayerGlow.GlowDensity;
			gClass.PlayerGlowData.GlowColor = CerberusConfig.PlayerGlow.GlowColor;
			gClass.LightSmoothData.Enabled = CerberusConfig.LightSmooth.Enabled;
			gClass.LightSmoothData.FogDensity = CerberusConfig.LightSmooth.FogDensity;
			gClass.LightSmoothData.Brightness = CerberusConfig.LightSmooth.Brightness;
			gClass.LightSmoothData.FogColor = CerberusConfig.LightSmooth.FogColor;
			gClass.LightSmoothData.TintColor = CerberusConfig.LightSmooth.TintColor;
			gClass.LightSmoothData.VignetteStrength = CerberusConfig.LightSmooth.VignetteStrength;
			gClass.WorldParticlesData.Enabled = CerberusConfig.WorldParticles.Enabled;
			gClass.WorldParticlesData.ParticleCount = CerberusConfig.WorldParticles.ParticleCount;
			gClass.WorldParticlesData.SpawnRadius = CerberusConfig.WorldParticles.SpawnRadius;
			gClass.WorldParticlesData.Speed = CerberusConfig.WorldParticles.Speed;
			gClass.WorldParticlesData.Size = CerberusConfig.WorldParticles.Size;
			gClass.WorldParticlesData.ParticleMode = CerberusConfig.WorldParticles.ParticleMode;
			gClass.WorldParticlesData.Opacity = CerberusConfig.WorldParticles.Opacity;
			gClass.WorldParticlesData.UseGlow = CerberusConfig.WorldParticles.UseGlow;
			gClass.WorldParticlesData.UseBlur = CerberusConfig.WorldParticles.UseBlur;
			gClass.WorldParticlesData.ParticleColor = CerberusConfig.WorldParticles.ParticleColor;
			gClass.TrapEspData.Enabled = CerberusConfig.TrapEsp.Enabled;
			gClass.TrapEspData.MaxDistance = CerberusConfig.TrapEsp.MaxDistance;
			gClass.TrapEspData.ShowLandMines = CerberusConfig.TrapEsp.ShowLandMines;
			gClass.TrapEspData.ShowProximitySensors = CerberusConfig.TrapEsp.ShowProximitySensors;
			gClass.TrapEspData.ShowStepTriggers = CerberusConfig.TrapEsp.ShowStepTriggers;
			gClass.TrapEspData.ShowTriggerRadius = CerberusConfig.TrapEsp.ShowTriggerRadius;
			gClass.TrapEspData.ArmedColor = CerberusConfig.TrapEsp.ArmedColor;
			gClass.TrapEspData.DisarmedColor = CerberusConfig.TrapEsp.DisarmedColor;
			gClass.TurretEspData.Enabled = CerberusConfig.TurretEsp.Enabled;
			gClass.TurretEspData.MaxDistance = CerberusConfig.TurretEsp.MaxDistance;
			gClass.TurretEspData.ShowAttackRadius = CerberusConfig.TurretEsp.ShowAttackRadius;
			gClass.TurretEspData.HostileColor = CerberusConfig.TurretEsp.HostileColor;
			gClass.TurretEspData.FriendlyColor = CerberusConfig.TurretEsp.FriendlyColor;
			gClass.AmbientLightData.Enabled = CerberusConfig.AmbientLight.Enabled;
			gClass.AmbientLightData.Mode = CerberusConfig.AmbientLight.Mode;
			gClass.AmbientLightData.Intensity = CerberusConfig.AmbientLight.Intensity;
			gClass.AmbientLightData.CustomColor = CerberusConfig.AmbientLight.CustomColor;
			gClass.LightEnhancementData.Enabled = CerberusConfig.LightEnhancement.Enabled;
			gClass.LightEnhancementData.EnergyMultiplier = CerberusConfig.LightEnhancement.EnergyMultiplier;
			gClass.LightEnhancementData.RadiusMultiplier = CerberusConfig.LightEnhancement.RadiusMultiplier;
			gClass.ProjectileEspData.Enabled = CerberusConfig.ProjectileEsp.Enabled;
			gClass.ProjectileEspData.ShowTrajectory = CerberusConfig.ProjectileEsp.ShowTrajectory;
			gClass.ProjectileEspData.DetectionRadius = CerberusConfig.ProjectileEsp.DetectionRadius;
			gClass.ProjectileEspData.Color = CerberusConfig.ProjectileEsp.Color;
			gClass.ProjectileEspData.AutoDodge = CerberusConfig.ProjectileEsp.AutoDodge;
			gClass.ProjectileEspData.DodgeRange = CerberusConfig.ProjectileEsp.DodgeRange;
			gClass.CombatData.AutoBlockEnabled = CerberusConfig.Combat.AutoBlockEnabled;
			gClass.CombatData.AutoLaydownEnabled = CerberusConfig.Combat.AutoLaydownEnabled;
			gClass.CombatData.AutoLaydownStandUpDelay = CerberusConfig.Combat.AutoLaydownStandUpDelay;
			gClass.GrenadeHelperData.ShowTimer = CerberusConfig.GrenadeHelper.ShowTimer;
			gClass.TargetEspData.SpiritsEnabled = CerberusConfig.TargetEsp.SpiritsEnabled;
			gClass.TargetEspData.SpiritsColor = CerberusConfig.TargetEsp.SpiritsColor;
			gClass.TargetEspData.SpiritsOrbitRadiusX = CerberusConfig.TargetEsp.SpiritsOrbitRadiusX;
			gClass.TargetEspData.SpiritsOrbitRadiusY = CerberusConfig.TargetEsp.SpiritsOrbitRadiusY;
			gClass.TargetEspData.SpiritsSpeed = CerberusConfig.TargetEsp.SpiritsSpeed;
			gClass.TargetEspData.SpiritsSize = CerberusConfig.TargetEsp.SpiritsSize;
			gClass.TargetEspData.SpiritsTrailLength = CerberusConfig.TargetEsp.SpiritsTrailLength;
			gClass.TargetEspData.SpiritsSmoothFade = CerberusConfig.TargetEsp.SpiritsSmoothFade;
			gClass.TargetEspData.SpiritsMode = CerberusConfig.TargetEsp.SpiritsMode;
			gClass.TargetEspData.EnableSpringEffect = CerberusConfig.TargetEsp.EnableSpringEffect;
			gClass.TargetEspData.EnableColorTint = CerberusConfig.TargetEsp.EnableColorTint;
			gClass.TargetEspData.PngTintColor = CerberusConfig.TargetEsp.PngTintColor;
			gClass.CloakedPlayerDetectorData.Enabled = CerberusConfig.CloakedPlayerDetector.Enabled;
			gClass.CloakedPlayerDetectorData.MaxDistance = CerberusConfig.CloakedPlayerDetector.MaxDistance;
			gClass.CloakedPlayerDetectorData.CloakedColor = CerberusConfig.CloakedPlayerDetector.CloakedColor;
			gClass.CloakedPlayerDetectorData.NinjaColor = CerberusConfig.CloakedPlayerDetector.NinjaColor;
			gClass.CloakedPlayerDetectorData.ShowOutline = CerberusConfig.CloakedPlayerDetector.ShowOutline;
			gClass.CloakedPlayerDetectorData.ShowWarningForNinja = CerberusConfig.CloakedPlayerDetector.ShowWarningForNinja;
			gClass.CloakedPlayerDetectorData.MinVisibilityThreshold = CerberusConfig.CloakedPlayerDetector.MinVisibilityThreshold;
			gClass.AutoCuffData.Enabled = CerberusConfig.AutoCuff.Enabled;
			gClass.AutoCuffData.ActivationKey = ((object)Unsafe.As<ImGuiKey, ImGuiKey>(ref CerberusConfig.AutoCuff.ActivationKey)/*cast due to constrained. prefix*/).ToString();
			gClass.AutoCuffData.TargetPriority = (int)CerberusConfig.AutoCuff.TargetPriority;
			gClass.AutoCuffData.OnlyStunned = CerberusConfig.AutoCuff.OnlyStunned;
			gClass.AutoStopData.Enabled = CerberusConfig.AutoStop.Enabled;
			gClass.AutoStopData.ActivationKey = ((object)Unsafe.As<ImGuiKey, ImGuiKey>(ref CerberusConfig.AutoStop.ActivationKey)/*cast due to constrained. prefix*/).ToString();
			gClass.AutoStopData.IntervalMs = CerberusConfig.AutoStop.IntervalMs;
			gClass.AutoHypoData.Enabled = CerberusConfig.AutoHypo.Enabled;
			gClass.AutoHypoData.HpThreshold = CerberusConfig.AutoHypo.HpThreshold;
			gClass.AutoHypoData.InjectCount = CerberusConfig.AutoHypo.InjectCount;
			gClass.AutoHypoData.ForceKey = ((object)Unsafe.As<ImGuiKey, ImGuiKey>(ref CerberusConfig.AutoHypo.ForceKey)/*cast due to constrained. prefix*/).ToString();
			gClass.AutoHackDoorsData.Enabled = CerberusConfig.AutoHackDoors.Enabled;
			gClass.AutoHackDoorsData.Range = CerberusConfig.AutoHackDoors.Range;
			gClass.AutoHackDoorsData.Cooldown = CerberusConfig.AutoHackDoors.Cooldown;
			gClass.AutoHackDoorsData.RequireMultitool = CerberusConfig.AutoHackDoors.RequireMultitool;
			gClass.AutoHackDoorsData.OnlyBoltedDoors = CerberusConfig.AutoHackDoors.OnlyBoltedDoors;
			gClass.AutoHackDoorsData.OnlyLockedDoors = CerberusConfig.AutoHackDoors.OnlyLockedDoors;
			gClass.AutoPathData.Enabled = CerberusConfig.AutoPath.Enabled;
			gClass.SmartTargetSelectionData.Enabled = CerberusConfig.SmartTargetSelection.Enabled;
			gClass.SmartTargetSelectionData.Priority = CerberusConfig.SmartTargetSelection.Priority;
			gClass.SmartTargetSelectionData.IgnoreTeammates = CerberusConfig.SmartTargetSelection.IgnoreTeammates;
			gClass.SmartTargetSelectionData.IgnoreCuffed = CerberusConfig.SmartTargetSelection.IgnoreCuffed;
			gClass.SmartTargetSelectionData.IgnoreDead = CerberusConfig.SmartTargetSelection.IgnoreDead;
			gClass.SmartTargetSelectionData.MaxRange = CerberusConfig.SmartTargetSelection.MaxRange;
			gClass.TargetLockData.Enabled = CerberusConfig.TargetLock.Enabled;
			gClass.TargetLockData.LockKey = CerberusConfig.TargetLock.LockKey;
			gClass.TargetLockData.UnlockKey = CerberusConfig.TargetLock.UnlockKey;
			gClass.TargetLockData.MaxDistance = CerberusConfig.TargetLock.MaxDistance;
			gClass.TargetLockData.UnlockOnDeath = CerberusConfig.TargetLock.UnlockOnDeath;
			gClass.TargetLockData.ShowLockIndicator = CerberusConfig.TargetLock.ShowLockIndicator;
			gClass.TargetLockData.LockColor = CerberusConfig.TargetLock.LockColor;
			gClass.AutoShootData.Enabled = CerberusConfig.AutoShoot.Enabled;
			gClass.AutoShootData.AimTolerance = CerberusConfig.AutoShoot.AimTolerance;
			gClass.AutoShootData.FireDelay = CerberusConfig.AutoShoot.FireDelay;
			gClass.AutoShootData.OnlyWhenLocked = CerberusConfig.AutoShoot.OnlyWhenLocked;
			gClass.AutoShootData.RequireLineOfSight = CerberusConfig.AutoShoot.RequireLineOfSight;
			gClass.TargetFiltersData.IgnoreDead = CerberusConfig.TargetFilters.IgnoreDead;
			gClass.TargetFiltersData.IgnoreGhosts = CerberusConfig.TargetFilters.IgnoreGhosts;
			gClass.TargetFiltersData.IgnoreInvisible = CerberusConfig.TargetFilters.IgnoreInvisible;
			gClass.TargetFiltersData.MinVisibility = CerberusConfig.TargetFilters.MinVisibility;
			gClass.TargetFiltersData.IgnoreCuffed = CerberusConfig.TargetFilters.IgnoreCuffed;
			gClass.TargetFiltersData.IgnoreStunned = CerberusConfig.TargetFilters.IgnoreStunned;
			gClass.TargetFiltersData.IgnoreSleeping = CerberusConfig.TargetFilters.IgnoreSleeping;
			gClass.TargetFiltersData.IgnoreBuckled = CerberusConfig.TargetFilters.IgnoreBuckled;
			gClass.TargetFiltersData.IgnoreCritical = CerberusConfig.TargetFilters.IgnoreCritical;
			gClass.TargetFiltersData.IgnoreParalyzed = CerberusConfig.TargetFilters.IgnoreParalyzed;
			gClass.TargetFiltersData.MinHealthPercent = CerberusConfig.TargetFilters.MinHealthPercent;
			gClass.TargetFiltersData.MaxHealthPercent = CerberusConfig.TargetFilters.MaxHealthPercent;
			gClass.TargetFiltersData.OnlyArmed = CerberusConfig.TargetFilters.OnlyArmed;
			gClass.TargetFiltersData.OnlyWithGuns = CerberusConfig.TargetFilters.OnlyWithGuns;
			gClass.TargetFiltersData.IgnoreUnarmed = CerberusConfig.TargetFilters.IgnoreUnarmed;
			gClass.TargetFiltersData.OnlyInCombatMode = CerberusConfig.TargetFilters.OnlyInCombatMode;
			gClass.TargetFiltersData.IgnoreSecurity = CerberusConfig.TargetFilters.IgnoreSecurity;
			gClass.TargetFiltersData.IgnoreMedical = CerberusConfig.TargetFilters.IgnoreMedical;
			gClass.TargetFiltersData.OnlyAntagonists = CerberusConfig.TargetFilters.OnlyAntagonists;
			gClass.TargetFiltersData.IgnoreNinja = CerberusConfig.TargetFilters.IgnoreNinja;
			gClass.TargetFiltersData.IgnoreNukeOps = CerberusConfig.TargetFilters.IgnoreNukeOps;
			gClass.TargetFiltersData.IgnoreTeammates = CerberusConfig.TargetFilters.IgnoreTeammates;
			gClass.TargetFiltersData.IgnoreAdmins = CerberusConfig.TargetFilters.IgnoreAdmins;
			gClass.TargetFiltersData.MaxDistance = CerberusConfig.TargetFilters.MaxDistance;
			gClass.TargetFiltersData.MinDistance = CerberusConfig.TargetFilters.MinDistance;
			gClass.SpammerData.ChatEnabled = CerberusConfig.Spammer.ChatEnabled;
			gClass.SpammerData.ChatText = CerberusConfig.Spammer.ChatText;
			gClass.SpammerData.ChatDelay = CerberusConfig.Spammer.ChatDelay;
			gClass.SpammerData.ProtectTextEnabled = CerberusConfig.Spammer.ProtectTextEnabled;
			gClass.SpammerData.ProtectRandomLength = CerberusConfig.Spammer.ProtectRandomLength;
			gClass.SpammerData.ProtectLength = CerberusConfig.Spammer.ProtectLength;
			gClass.SpammerData.AHelpEnabled = CerberusConfig.Spammer.AHelpEnabled;
			gClass.SpammerData.AHelpText = CerberusConfig.Spammer.AHelpText;
			gClass.SpammerData.AHelpDelay = CerberusConfig.Spammer.AHelpDelay;
			gClass.SpammerData.Channels = CerberusConfig.Spammer.Channels;
			gClass.PacketSpammerData.Enabled = CerberusConfig.PacketSpammer.Enabled;
			gClass.PacketSpammerData.PacketSize = CerberusConfig.PacketSpammer.PacketSize;
			gClass.PacketSpammerData.PacketsPerBurst = CerberusConfig.PacketSpammer.PacketsPerBurst;
			gClass.PacketSpammerData.BurstDelay = CerberusConfig.PacketSpammer.BurstDelay;
			gClass.PacketSpammerData.ThreadCount = CerberusConfig.PacketSpammer.ThreadCount;
			gClass.PacketSpammerData.UseRandomData = CerberusConfig.PacketSpammer.UseRandomData;
			gClass.PacketSpammerData.LogSending = CerberusConfig.PacketSpammer.LogSending;
			gClass.PacketSpammerData.PacketType = CerberusConfig.PacketSpammer.PacketType;
			gClass.EventSpammerData.Enabled = CerberusConfig.EventSpammer.Enabled;
			gClass.EventSpammerData.MinDelay = CerberusConfig.EventSpammer.MinDelay;
			gClass.EventSpammerData.MaxDelay = CerberusConfig.EventSpammer.MaxDelay;
			gClass.EventSpammerData.BurstMode = CerberusConfig.EventSpammer.BurstMode;
			gClass.EventSpammerData.BurstSize = CerberusConfig.EventSpammer.BurstSize;
			gClass.EventSpammerData.SpamInteraction = CerberusConfig.EventSpammer.SpamInteraction;
			gClass.EventSpammerData.SpamHandActivate = CerberusConfig.EventSpammer.SpamHandActivate;
			gClass.EventSpammerData.SpamItemDrop = CerberusConfig.EventSpammer.SpamItemDrop;
			gClass.EventSpammerData.SpamItemPickup = CerberusConfig.EventSpammer.SpamItemPickup;
			gClass.EventSpammerData.SpamPull = CerberusConfig.EventSpammer.SpamPull;
			gClass.EventSpammerData.SpamPush = CerberusConfig.EventSpammer.SpamPush;
			gClass.EventSpammerData.SpamMoveInput = CerberusConfig.EventSpammer.SpamMoveInput;
			gClass.EventSpammerData.SpamSprint = CerberusConfig.EventSpammer.SpamSprint;
			gClass.EventSpammerData.SpamCrouch = CerberusConfig.EventSpammer.SpamCrouch;
			gClass.EventSpammerData.SpamVerb = CerberusConfig.EventSpammer.SpamVerb;
			gClass.EventSpammerData.SpamExamine = CerberusConfig.EventSpammer.SpamExamine;
			gClass.EventSpammerData.SpamAttack = CerberusConfig.EventSpammer.SpamAttack;
			gClass.EventSpammerData.SpamUse = CerberusConfig.EventSpammer.SpamUse;
			gClass.EventSpammerData.SpamThrow = CerberusConfig.EventSpammer.SpamThrow;
			gClass.EventSpammerData.SpamEquip = CerberusConfig.EventSpammer.SpamEquip;
			gClass.EventSpammerData.SpamUnequip = CerberusConfig.EventSpammer.SpamUnequip;
			gClass.EventSpammerData.SpamStorage = CerberusConfig.EventSpammer.SpamStorage;
			gClass.EventSpammerData.SpamContainer = CerberusConfig.EventSpammer.SpamContainer;
			gClass.EventSpammerData.SpamWield = CerberusConfig.EventSpammer.SpamWield;
			gClass.FunData.Enabled = CerberusConfig.Fun.Enabled;
			gClass.FunData.RainbowEnabled = CerberusConfig.Fun.RainbowEnabled;
			gClass.FunData.RotationEnabled = CerberusConfig.Fun.RotationEnabled;
			gClass.FunData.TrailsEnabled = CerberusConfig.Fun.TrailsEnabled;
			gClass.FunData.JumpEnabled = CerberusConfig.Fun.JumpEnabled;
			gClass.FunData.ShakeEnabled = CerberusConfig.Fun.ShakeEnabled;
			gClass.FunData.RotationSpeed = CerberusConfig.Fun.RotationSpeed;
			gClass.FunData.Color = CerberusConfig.Fun.Color;
			gClass.FunData.ScaleX = CerberusConfig.Fun.ScaleX;
			gClass.FunData.ScaleY = CerberusConfig.Fun.ScaleY;
			gClass.FunData.RainbowSpeed = CerberusConfig.Fun.RainbowSpeed;
			gClass.FunData.AffectPlayer = CerberusConfig.Fun.AffectPlayer;
			gClass.FunData.AffectMobs = CerberusConfig.Fun.AffectMobs;
			gClass.FunData.AffectOthers = CerberusConfig.Fun.AffectOthers;
			gClass.TextureData.Enabled = CerberusConfig.Texture.Enabled;
			gClass.TextureData.Size = CerberusConfig.Texture.Size;
			gClass.TextureData.MakeEntitiesInvisible = CerberusConfig.Texture.MakeEntitiesInvisible;
			gClass.FriendsList = new List<string>(CerberusConfig.list_0);
			gClass.PriorityList = new List<string>(CerberusConfig.list_1);
			return gClass;
		}
		catch (Exception ex)
		{
			Console.WriteLine("[ConfigManager] GatherData failed: " + ex.Message);
			return new CerberusConfigData();
		}
	}

	public static void ApplyConfig(CerberusConfigData config)
	{
	}

	public static bool DeleteConfig(string name)
	{
		try
		{
			if (name == "default")
			{
				Console.WriteLine("[ConfigManager] Cannot delete default config");
				return false;
			}
			string path = Path.Combine(string_1, name + ".json");
			if (!File.Exists(path))
			{
				return false;
			}
			File.Delete(path);
			Console.WriteLine("[ConfigManager] Config deleted: " + name);
			return true;
		}
		catch (Exception ex)
		{
			Console.WriteLine("[ConfigManager] Delete failed: " + ex.Message);
			return false;
		}
	}

	public static List<string> GetConfigList()
	{
		try
		{
			if (!Directory.Exists(string_1))
			{
				Directory.CreateDirectory(string_1);
				return new List<string> { "default" };
			}
			List<string> list = (from f in Directory.GetFiles(string_1, "*.json")
				select Path.GetFileNameWithoutExtension(f)).ToList();
			if (!list.Contains("default"))
			{
				list.Insert(0, "default");
			}
			list_0 = list;
			return list;
		}
		catch (Exception ex)
		{
			Console.WriteLine("[ConfigManager] GetConfigList failed: " + ex.Message);
			return new List<string> { "default" };
		}
	}

	private string method_7(char char_1, string string_2)
	{
		return "Хитролох_иди_нахуй.___9__5___5___7";
	}
}
