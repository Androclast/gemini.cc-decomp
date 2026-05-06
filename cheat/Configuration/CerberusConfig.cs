using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CerberusWareV3.Configuration;
using CerberusWareV3.Localization;
using Hexa.NET.ImGui;
using Robust.Shared.GameObjects;
using ConfigIdAttribute;

namespace CerberusConfig;

[CompilerGenerated]
public sealed class CerberusConfig
{
	public sealed class ProjectileEsp
	{
		[ConfigIdAttribute("projectile_esp.enabled")]
		public static bool Enabled = true;

		[ConfigIdAttribute("projectile_esp.show_trajectory")]
		public static bool ShowTrajectory = true;

		[ConfigIdAttribute("projectile_esp.detection_radius")]
		public static float DetectionRadius = 30f;

		[ConfigIdAttribute("projectile_esp.color")]
		public static Vector4 Color = new Vector4(1f, 0f, 0f, 1f);

		[ConfigIdAttribute("projectile_esp.auto_dodge")]
		public static bool AutoDodge = false;

		[ConfigIdAttribute("projectile_esp.dodge_range")]
		public static float DodgeRange = 1f;

		private double double_0;

		private char char_0;

		private string string_0;

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

		private string String_0
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
	}

	public sealed class HudOverlay
	{
		[ConfigIdAttribute("hud_overlay.enabled")]
		public static bool Enabled = true;

		[ConfigIdAttribute("hud_overlay.edit_mode")]
		public static bool EditMode = false;

		[ConfigIdAttribute("hud_overlay.show_watermark")]
		public static bool ShowWatermark = true;

		[ConfigIdAttribute("hud_overlay.watermark_pos")]
		public static Vector2 WatermarkPos = new Vector2(10f, 10f);

		[ConfigIdAttribute("hud_overlay.show_fps")]
		public static bool ShowFps = true;

		[ConfigIdAttribute("hud_overlay.fps_pos")]
		public static Vector2 FpsPos = new Vector2(10f, 30f);

		[ConfigIdAttribute("hud_overlay.show_coords")]
		public static bool ShowCoords = true;

		[ConfigIdAttribute("hud_overlay.coords_pos")]
		public static Vector2 CoordsPos = new Vector2(10f, 50f);

		[ConfigIdAttribute("hud_overlay.show_speed")]
		public static bool ShowSpeed = true;

		[ConfigIdAttribute("hud_overlay.speed_pos")]
		public static Vector2 SpeedPos = new Vector2(10f, 70f);

		[ConfigIdAttribute("hud_overlay.text_color")]
		public static Vector4 TextColor = new Vector4(1f, 1f, 1f, 1f);

		[ConfigIdAttribute("hud_overlay.bg_color")]
		public static Vector4 BgColor = new Vector4(0f, 0f, 0f, 0.4f);

		[ConfigIdAttribute("hud_overlay.show_target_info")]
		public static bool ShowTargetInfo = true;

		[ConfigIdAttribute("hud_overlay.target_info_pos")]
		public static Vector2 TargetInfoPos = new Vector2(500f, 500f);

		[ConfigIdAttribute("hud_overlay.show_ping")]
		public static bool ShowPing = true;

		[ConfigIdAttribute("hud_overlay.ping_pos")]
		public static Vector2 PingPos = new Vector2(10f, 90f);

		[ConfigIdAttribute("hud_overlay.show_round_time")]
		public static bool ShowRoundTime = true;

		[ConfigIdAttribute("hud_overlay.round_time_pos")]
		public static Vector2 RoundTimePos = new Vector2(10f, 110f);

		[ConfigIdAttribute("hud_overlay.current_target")]
		public static EntityUid? CurrentTarget = null;

		[ConfigIdAttribute("hud_overlay.show_array_list")]
		public static bool ShowArrayList = true;

		[ConfigIdAttribute("hud_overlay.array_list_pos")]
		public static Vector2 ArrayListPos = new Vector2(10f, 200f);

		[ConfigIdAttribute("hud_overlay.array_list_rainbow")]
		public static bool ArrayListRainbow = true;

		[ConfigIdAttribute("hud_overlay.show_staff_list")]
		public static bool ShowStaffList = false;

		[ConfigIdAttribute("hud_overlay.staff_list_pos")]
		public static Vector2 StaffListPos = new Vector2(10f, 240f);

		[ConfigIdAttribute("hud_overlay.staff_list_refresh_seconds")]
		public static float StaffListRefreshSeconds = 30f;

		[ConfigIdAttribute("hud_overlay.show_compass")]
		public static bool ShowCompass = false;

		[ConfigIdAttribute("hud_overlay.compass_pos")]
		public static Vector2 CompassPos = new Vector2(100f, 100f);

		[ConfigIdAttribute("hud_overlay.show_session_timer")]
		public static bool ShowSessionTimer = false;

		[ConfigIdAttribute("hud_overlay.session_timer_pos")]
		public static Vector2 SessionTimerPos = new Vector2(10f, 130f);

		[ConfigIdAttribute("hud_overlay.show_kill_counter")]
		public static bool ShowKillCounter = false;

		[ConfigIdAttribute("hud_overlay.kill_counter_pos")]
		public static Vector2 KillCounterPos = new Vector2(10f, 150f);

		[ConfigIdAttribute("hud_overlay.show_velocity_meter")]
		public static bool ShowVelocityMeter = false;

		[ConfigIdAttribute("hud_overlay.velocity_meter_pos")]
		public static Vector2 VelocityMeterPos = new Vector2(10f, 170f);

		[ConfigIdAttribute("hud_overlay.session_kills")]
		public static int SessionKills = 0;

		[ConfigIdAttribute("hud_overlay.session_start_time")]
		public static DateTime SessionStartTime = DateTime.UtcNow;

		[ConfigIdAttribute("hud_overlay.show_server_info")]
		public static bool ShowServerInfo = false;

		[ConfigIdAttribute("hud_overlay.server_info_pos")]
		public static Vector2 ServerInfoPos = new Vector2(10f, 190f);

		[ConfigIdAttribute("hud_overlay.show_keybinds")]
		public static bool ShowKeybinds = false;

		[ConfigIdAttribute("hud_overlay.keybinds_pos")]
		public static Vector2 KeybindsPos = new Vector2(10f, 210f);

		[ConfigIdAttribute("hud_overlay.show_crosshair")]
		public static bool ShowCrosshair = false;

		[ConfigIdAttribute("hud_overlay.crosshair_style")]
		public static int CrosshairStyle = 0;

		[ConfigIdAttribute("hud_overlay.crosshair_color")]
		public static Vector4 CrosshairColor = new Vector4(0f, 1f, 0f, 1f);

		[ConfigIdAttribute("hud_overlay.show_radar")]
		public static bool ShowRadar = false;

		[ConfigIdAttribute("hud_overlay.radar_pos")]
		public static Vector2 RadarPos = new Vector2(800f, 100f);

		[ConfigIdAttribute("hud_overlay.radar_range")]
		public static float RadarRange = 20f;

		[ConfigIdAttribute("hud_overlay.show_shuttle_tracker")]
		public static bool ShowShuttleTracker = false;

		[ConfigIdAttribute("hud_overlay.shuttle_tracker_pos")]
		public static Vector2 ShuttleTrackerPos = new Vector2(10f, 230f);

		[ConfigIdAttribute("hud_overlay.shuttle_show_distance")]
		public static bool ShuttleShowDistance = true;

		[ConfigIdAttribute("hud_overlay.shuttle_show_direction")]
		public static bool ShuttleShowDirection = true;

		[ConfigIdAttribute("hud_overlay.shuttle_show_status")]
		public static bool ShuttleShowStatus = true;

		[ConfigIdAttribute("hud_overlay.show_connection_quality")]
		public static bool ShowConnectionQuality = false;

		[ConfigIdAttribute("hud_overlay.connection_quality_pos")]
		public static Vector2 ConnectionQualityPos = new Vector2(10f, 280f);

		[ConfigIdAttribute("hud_overlay.connection_show_graph")]
		public static bool ConnectionShowGraph = true;

		[ConfigIdAttribute("hud_overlay.connection_show_stats")]
		public static bool ConnectionShowStats = true;

		[ConfigIdAttribute("hud_overlay.connection_history_size")]
		public static int ConnectionHistorySize = 100;

		[ConfigIdAttribute("hud_overlay.show_spectator_list")]
		public static bool ShowSpectatorList = false;

		[ConfigIdAttribute("hud_overlay.spectator_list_pos")]
		public static Vector2 SpectatorListPos = new Vector2(10f, 230f);

		[ConfigIdAttribute("hud_overlay.show_damage_counter")]
		public static bool ShowDamageCounter = false;

		[ConfigIdAttribute("hud_overlay.damage_counter_pos")]
		public static Vector2 DamageCounterPos = new Vector2(10f, 250f);

		[ConfigIdAttribute("hud_overlay.session_damage")]
		public static float SessionDamage = 0f;

		[ConfigIdAttribute("hud_overlay.show_movement_keys")]
		public static bool ShowMovementKeys = false;

		[ConfigIdAttribute("hud_overlay.movement_keys_pos")]
		public static Vector2 MovementKeysPos = new Vector2(10f, 270f);

		[ConfigIdAttribute("hud_overlay.show_c_p_s")]
		public static bool ShowCPS = false;

		[ConfigIdAttribute("hud_overlay.c_p_s_pos")]
		public static Vector2 CPSPos = new Vector2(10f, 290f);

		private string string_0;

		private long long_1;

		private double double_1;

		private float float_1;

		private string String_0
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

		private long Int64_0
		{
			get
			{
				return long_1;
			}
			set
			{
				long_1 = value;
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
				return float_1;
			}
			set
			{
				float_1 = value;
			}
		}

		private string method_10(char char_0, double double_2, float float_2)
		{
			return "Хитролох_иди_нахуй.____7___2_1_____6_";
		}
	}

	public sealed class GunAimBot
	{
		[ConfigIdAttribute("gun_aim_bot.enabled")]
		public static bool Enabled;

		[ConfigIdAttribute("gun_aim_bot.hot_key")]
		public static ImGuiKey HotKey = (ImGuiKey)657;

		[ConfigIdAttribute("gun_aim_bot.target_critical")]
		public static bool TargetCritical;

		[ConfigIdAttribute("gun_aim_bot.min_spread")]
		public static bool MinSpread;

		[ConfigIdAttribute("gun_aim_bot.hit_scan")]
		public static bool HitScan;

		[ConfigIdAttribute("gun_aim_bot.auto_predict")]
		public static bool AutoPredict = true;

		[ConfigIdAttribute("gun_aim_bot.predict_enabled")]
		public static bool PredictEnabled = true;

		[ConfigIdAttribute("gun_aim_bot.predict_correction")]
		public static float PredictCorrection;

		[ConfigIdAttribute("gun_aim_bot.predict_strength")]
		public static float PredictStrength = 1f;

		[ConfigIdAttribute("gun_aim_bot.predict_damping")]
		public static float PredictDamping = 0f;

		[ConfigIdAttribute("gun_aim_bot.predict_strafe_compensation")]
		public static bool PredictStrafeCompensation = true;

		[ConfigIdAttribute("gun_aim_bot.max_predict_time")]
		public static float MaxPredictTime = 0.8f;

		[ConfigIdAttribute("gun_aim_bot.show_circle")]
		public static bool ShowCircle = true;

		[ConfigIdAttribute("gun_aim_bot.show_line")]
		public static bool ShowLine = true;

		[ConfigIdAttribute("gun_aim_bot.circle_radius")]
		public static float CircleRadius = 2.5f;

		[ConfigIdAttribute("gun_aim_bot.color")]
		public static Vector4 Color = new Vector4(1f, 0f, 0f, 1f);

		[ConfigIdAttribute("gun_aim_bot.target_priority")]
		public static int TargetPriority;

		[ConfigIdAttribute("gun_aim_bot.only_priority")]
		public static bool OnlyPriority;

		[ConfigIdAttribute("gun_aim_bot.multi_target")]
		public static bool MultiTarget = false;

		[ConfigIdAttribute("gun_aim_bot.multi_target_count")]
		public static int MultiTargetCount = 3;

		[ConfigIdAttribute("gun_aim_bot.ignore_cuffed")]
		public static bool IgnoreCuffed = true;

		[ConfigIdAttribute("gun_aim_bot.ignore_downed")]
		public static bool IgnoreDowned = false;

		[ConfigIdAttribute("gun_aim_bot.ignore_dead")]
		public static bool IgnoreDead = true;

		[ConfigIdAttribute("gun_aim_bot.only_visible_targets")]
		public static bool OnlyVisibleTargets = false;

		[ConfigIdAttribute("gun_aim_bot.allowed_jobs")]
		public static List<string> AllowedJobs = new List<string>();

		[ConfigIdAttribute("gun_aim_bot.blocked_jobs")]
		public static List<string> BlockedJobs = new List<string>();

		[ConfigIdAttribute("gun_aim_bot.role_priority")]
		public static List<string> RolePriority = new List<string>();

		private byte byte_0;

		private string string_0;

		private long long_0;

		private string string_1;

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
				return string_0;
			}
			set
			{
				string_0 = value;
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

		private string String_1
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

		private string method_4(float float_1, string string_2)
		{
			return "Хитролох_иди_нахуй.___0__9__1__";
		}
	}

	public sealed class MeleeAimBot
	{
		[ConfigIdAttribute("melee_aim_bot.enabled")]
		public static bool Enabled;

		[ConfigIdAttribute("melee_aim_bot.light_hot_key")]
		public static ImGuiKey LightHotKey = (ImGuiKey)660;

		[ConfigIdAttribute("melee_aim_bot.heavy_hot_key")]
		public static ImGuiKey HeavyHotKey = (ImGuiKey)659;

		[ConfigIdAttribute("melee_aim_bot.target_critical")]
		public static bool TargetCritical;

		[ConfigIdAttribute("melee_aim_bot.show_circle")]
		public static bool ShowCircle = true;

		[ConfigIdAttribute("melee_aim_bot.show_line")]
		public static bool ShowLine = true;

		[ConfigIdAttribute("melee_aim_bot.circle_radius")]
		public static float CircleRadius = 2.5f;

		[ConfigIdAttribute("melee_aim_bot.color")]
		public static Vector4 Color = new Vector4(1f, 0f, 0f, 1f);

		[ConfigIdAttribute("melee_aim_bot.target_priority")]
		public static int TargetPriority;

		[ConfigIdAttribute("melee_aim_bot.only_priority")]
		public static bool OnlyPriority;

		[ConfigIdAttribute("melee_aim_bot.fix_network_delay")]
		public static bool FixNetworkDelay;

		[ConfigIdAttribute("melee_aim_bot.fix_delay")]
		public static float FixDelay = 0.6f;

		[ConfigIdAttribute("melee_aim_bot.ignore_cuffed")]
		public static bool IgnoreCuffed = true;

		[ConfigIdAttribute("melee_aim_bot.ignore_downed")]
		public static bool IgnoreDowned = false;

		[ConfigIdAttribute("melee_aim_bot.ignore_dead")]
		public static bool IgnoreDead = true;

		[ConfigIdAttribute("melee_aim_bot.allowed_jobs")]
		public static List<string> AllowedJobs = new List<string>();

		[ConfigIdAttribute("melee_aim_bot.blocked_jobs")]
		public static List<string> BlockedJobs = new List<string>();

		[ConfigIdAttribute("melee_aim_bot.role_priority")]
		public static List<string> RolePriority = new List<string>();

		private byte byte_0;

		private int int_1;

		private int int_2;

		private long long_0;

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

		private int Int32_1
		{
			get
			{
				return int_2;
			}
			set
			{
				int_2 = value;
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

		private string method_8(int int_3, int int_4, int int_5)
		{
			return "Хитролох_иди_нахуй._91_________3__";
		}
	}

	public sealed class GunHelper
	{
		[ConfigIdAttribute("gun_helper.enabled")]
		public static bool Enabled;

		[ConfigIdAttribute("gun_helper.show_ammo")]
		public static bool ShowAmmo;

		[ConfigIdAttribute("gun_helper.auto_bolt")]
		public static bool AutoBolt;

		[ConfigIdAttribute("gun_helper.auto_reload")]
		public static bool AutoReload;

		[ConfigIdAttribute("gun_helper.auto_reload_delay")]
		public static float AutoReloadDelay = 0.1f;

		[ConfigIdAttribute("gun_helper.rotate_to_target")]
		public static bool RotateToTarget = true;

		private int int_1;

		private long long_0;

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
	}

	public sealed class MeleeHelper
	{
		[ConfigIdAttribute("melee_helper.enabled")]
		public static bool Enabled;

		[ConfigIdAttribute("melee_helper.attack360")]
		public static bool Attack360;

		[ConfigIdAttribute("melee_helper.auto_attack")]
		public static bool AutoAttack;

		[ConfigIdAttribute("melee_helper.rotate_to_target")]
		public static bool RotateToTarget = true;

		private string string_0;

		private int int_2;

		private string String_0
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

		private int Int32_0
		{
			get
			{
				return int_2;
			}
			set
			{
				int_2 = value;
			}
		}
	}

	public sealed class HitSound
	{
		[ConfigIdAttribute("hit_sound.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("hit_sound.sound_index")]
		public static int SoundIndex = 0;

		[ConfigIdAttribute("hit_sound.volume")]
		public static float Volume = 100f;

		private byte byte_0;

		private long long_0;

		private int int_2;

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

		private int Int32_0
		{
			get
			{
				return int_2;
			}
			set
			{
				int_2 = value;
			}
		}

		private string method_6(long long_1, char char_0)
		{
			return "Хитролох_иди_нахуй._37_7_1__6__";
		}
	}

	public sealed class Esp
	{
		[ConfigIdAttribute("esp.enabled")]
		public static bool Enabled;

		[ConfigIdAttribute("esp.show_name")]
		public static bool ShowName = true;

		[ConfigIdAttribute("esp.show_c_key")]
		public static bool ShowCKey = true;

		[ConfigIdAttribute("esp.show_antag")]
		public static bool ShowAntag = true;

		[ConfigIdAttribute("esp.show_friend")]
		public static bool ShowFriend = true;

		[ConfigIdAttribute("esp.show_priority")]
		public static bool ShowPriority = true;

		[ConfigIdAttribute("esp.show_combat_mode")]
		public static bool ShowCombatMode = true;

		[ConfigIdAttribute("esp.show_implants")]
		public static bool ShowImplants = true;

		[ConfigIdAttribute("esp.show_contraband")]
		public static bool ShowContraband = true;

		[ConfigIdAttribute("esp.show_weapon")]
		public static bool ShowWeapon = true;

		[ConfigIdAttribute("esp.show_no_slip")]
		public static bool ShowNoSlip = true;

		[ConfigIdAttribute("esp.name_color")]
		public static Vector4 NameColor = new Vector4(0.49803922f, 1f, 0.83137256f, 1f);

		[ConfigIdAttribute("esp.ckey_color")]
		public static Vector4 CKeyColor = new Vector4(1f, 1f, 0f, 1f);

		[ConfigIdAttribute("esp.antag_color")]
		public static Vector4 AntagColor = new Vector4(0.54509807f, 0f, 0f, 1f);

		[ConfigIdAttribute("esp.friend_color")]
		public static Vector4 FriendColor = new Vector4(0f, 0.5019608f, 0f, 1f);

		[ConfigIdAttribute("esp.priority_color")]
		public static Vector4 PriorityColor = new Vector4(0f, 0.5019608f, 0f, 1f);

		[ConfigIdAttribute("esp.combat_mode_color")]
		public static Vector4 CombatModeColor = new Vector4(1f, 0f, 0f, 1f);

		[ConfigIdAttribute("esp.implants_color")]
		public static Vector4 ImplantsColor = new Vector4(1f, 23f / 85f, 0f, 1f);

		[ConfigIdAttribute("esp.contraband_color")]
		public static Vector4 ContrabandColor = new Vector4(1f, 23f / 85f, 0f, 1f);

		[ConfigIdAttribute("esp.weapon_color")]
		public static Vector4 WeaponColor = new Vector4(1f, 23f / 85f, 0f, 1f);

		[ConfigIdAttribute("esp.no_slip_color")]
		public static Vector4 NoSlipColor = new Vector4(0.6784314f, 72f / 85f, 46f / 51f, 1f);

		[ConfigIdAttribute("esp.main_font_path")]
		public static string MainFontPath = "/Fonts/Boxfont-round/Boxfont Round.ttf";

		[ConfigIdAttribute("esp.main_font_index")]
		public static int MainFontIndex;

		[ConfigIdAttribute("esp.main_font_size")]
		public static int MainFontSize = 10;

		[ConfigIdAttribute("esp.other_font_path")]
		public static string OtherFontPath = "/Fonts/Boxfont-round/Boxfont Round.ttf";

		[ConfigIdAttribute("esp.other_font_index")]
		public static int OtherFontIndex;

		[ConfigIdAttribute("esp.other_font_size")]
		public static int OtherFontSize = 8;

		[ConfigIdAttribute("esp.font_interval")]
		public static int FontInterval = 15;

		[ConfigIdAttribute("esp.text_offset_x")]
		public static float TextOffsetX = 0f;

		[ConfigIdAttribute("esp.text_offset_y")]
		public static float TextOffsetY = 0f;

		private bool bool_0;

		private int int_1;

		private float float_0;

		private string string_0;

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
				return int_1;
			}
			set
			{
				int_1 = value;
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

		private string String_0
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
	}

	public sealed class Eye
	{
		[ConfigIdAttribute("eye.fov_enabled")]
		public static bool FovEnabled;

		[ConfigIdAttribute("eye.full_bright_enabled")]
		public static bool FullBrightEnabled;

		[ConfigIdAttribute("eye.zoom")]
		public static float Zoom = 1f;

		[ConfigIdAttribute("eye.super_fast_zoom")]
		public static bool SuperFastZoom;

		[ConfigIdAttribute("eye.fov_hot_key")]
		public static ImGuiKey FovHotKey = (ImGuiKey)0;

		[ConfigIdAttribute("eye.full_bright_hot_key")]
		public static ImGuiKey FullBrightHotKey = (ImGuiKey)0;

		[ConfigIdAttribute("eye.zoom_up_hot_key")]
		public static ImGuiKey ZoomUpHotKey = (ImGuiKey)515;

		[ConfigIdAttribute("eye.zoom_down_hot_key")]
		public static ImGuiKey ZoomDownHotKey = (ImGuiKey)516;

		private int int_1;

		private int int_2;

		private char char_0;

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

		private int Int32_1
		{
			get
			{
				return int_2;
			}
			set
			{
				int_2 = value;
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
	}

	public sealed class Hud
	{
		[ConfigIdAttribute("hud.show_health")]
		public static bool ShowHealth;

		[ConfigIdAttribute("hud.show_antag")]
		public static bool ShowAntag;

		[ConfigIdAttribute("hud.show_job_icons")]
		public static bool ShowJobIcons;

		[ConfigIdAttribute("hud.show_mind_shield_icons")]
		public static bool ShowMindShieldIcons;

		[ConfigIdAttribute("hud.show_criminal_record_icons")]
		public static bool ShowCriminalRecordIcons;

		[ConfigIdAttribute("hud.show_syndicate_icons")]
		public static bool ShowSyndicateIcons;

		[ConfigIdAttribute("hud.chemical_analysis")]
		public static bool ChemicalAnalysis;

		[ConfigIdAttribute("hud.show_electrocution")]
		public static bool ShowElectrocution;

		[ConfigIdAttribute("hud.show_stamina")]
		public static bool ShowStamina;

		[ConfigIdAttribute("hud.stamina_color")]
		public static Vector4 StaminaColor = new Vector4(1f, 31f / 51f, 2f / 3f, 1f);

		[ConfigIdAttribute("hud.show_thirst_icons")]
		public static bool ShowThirstIcons;

		[ConfigIdAttribute("hud.show_hunger_icons")]
		public static bool ShowHungerIcons;

		[ConfigIdAttribute("hud.show_contraband_details")]
		public static bool ShowContrabandDetails;

		[ConfigIdAttribute("hud.show_access_reader_settings")]
		public static bool ShowAccessReaderSettings;

		[ConfigIdAttribute("hud.health_bar_offset_x")]
		public static float HealthBarOffsetX = 0f;

		[ConfigIdAttribute("hud.health_bar_offset_y")]
		public static float HealthBarOffsetY = -30f;

		[ConfigIdAttribute("hud.health_bar_width")]
		public static float HealthBarWidth = 50f;

		[ConfigIdAttribute("hud.health_bar_height")]
		public static float HealthBarHeight = 6f;

		[ConfigIdAttribute("hud.stamina_bar_offset_x")]
		public static float StaminaBarOffsetX = 0f;

		[ConfigIdAttribute("hud.stamina_bar_offset_y")]
		public static float StaminaBarOffsetY = -22f;

		[ConfigIdAttribute("hud.stamina_bar_width")]
		public static float StaminaBarWidth = 50f;

		[ConfigIdAttribute("hud.stamina_bar_height")]
		public static float StaminaBarHeight = 4f;

		private float float_1;

		private bool bool_0;

		private float Single_0
		{
			get
			{
				return float_1;
			}
			set
			{
				float_1 = value;
			}
		}

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

		private string method_5(bool bool_1, bool bool_2, long long_1)
		{
			return "Хитролох_иди_нахуй._______9_4_1______";
		}
	}

	public sealed class StorageViewer
	{
		[ConfigIdAttribute("storage_viewer.enabled")]
		public static bool Enabled;

		[ConfigIdAttribute("storage_viewer.color")]
		public static Vector4 Color = new Vector4(1f, 0f, 0f, 1f);

		[ConfigIdAttribute("storage_viewer.hot_key")]
		public static ImGuiKey HotKey = (ImGuiKey)658;

		[ConfigIdAttribute("storage_viewer.font_path")]
		public static string FontPath = "/Fonts/Boxfont-round/Boxfont Round.ttf";

		[ConfigIdAttribute("storage_viewer.font_size")]
		public static int FontSize = 10;

		private long long_0;

		private bool bool_0;

		private string string_0;

		private float float_2;

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
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		private string String_0
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

		private float Single_0
		{
			get
			{
				return float_2;
			}
			set
			{
				float_2 = value;
			}
		}
	}

	public sealed class AccessViewer
	{
		[ConfigIdAttribute("access_viewer.enabled")]
		public static bool Enabled;

		[ConfigIdAttribute("access_viewer.color")]
		public static Vector4 Color = new Vector4(0f, 1f, 1f, 1f);

		[ConfigIdAttribute("access_viewer.hot_key")]
		public static ImGuiKey HotKey = (ImGuiKey)658;

		[ConfigIdAttribute("access_viewer.font_path")]
		public static string FontPath = "/Fonts/Boxfont-round/Boxfont Round.ttf";

		[ConfigIdAttribute("access_viewer.font_size")]
		public static int FontSize = 8;

		private int int_1;

		private byte byte_1;

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

		private string method_5(bool bool_0, float float_1, int int_2)
		{
			return "Хитролох_иди_нахуй.____3___998__4___";
		}
	}

	public sealed class AccessChecker
	{
		[ConfigIdAttribute("access_checker.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("access_checker.range")]
		public static float Range = 20f;

		[ConfigIdAttribute("access_checker.checkmark_color")]
		public static Vector4 CheckmarkColor = new Vector4(0f, 1f, 0f, 1f);

		[ConfigIdAttribute("access_checker.cross_color")]
		public static Vector4 CrossColor = new Vector4(1f, 0f, 0f, 1f);

		[ConfigIdAttribute("access_checker.icon_size")]
		public static float IconSize = 0.4f;

		[ConfigIdAttribute("access_checker.use_textures")]
		public static bool UseTextures = false;

		private int int_0;

		private bool bool_0;

		private byte byte_2;

		private bool bool_1;

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
				return byte_2;
			}
			set
			{
				byte_2 = value;
			}
		}

		private bool Boolean_1
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
	}

	public sealed class GrillElectrocution
	{
		[ConfigIdAttribute("grill_electrocution.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("grill_electrocution.color")]
		public static Vector4 Color = new Vector4(1f, 0f, 0f, 0.5f);

		[ConfigIdAttribute("grill_electrocution.max_distance")]
		public static float MaxDistance = 30f;

		[ConfigIdAttribute("grill_electrocution.opacity")]
		public static float Opacity = 0.5f;

		private int int_1;

		private long long_1;

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

		private long Int64_0
		{
			get
			{
				return long_1;
			}
			set
			{
				long_1 = value;
			}
		}
	}

	public sealed class HealthInfo
	{
		[ConfigIdAttribute("health_info.enabled")]
		public static bool Enabled;

		[ConfigIdAttribute("health_info.font_path")]
		public static string FontPath = "/Fonts/Boxfont-round/Boxfont Round.ttf";

		[ConfigIdAttribute("health_info.font_index")]
		public static int FontIndex;

		[ConfigIdAttribute("health_info.font_size")]
		public static int FontSize = 12;

		[ConfigIdAttribute("health_info.text_offset")]
		public static Vector2 TextOffset = new Vector2(0f, -30f);

		[ConfigIdAttribute("health_info.hold_key")]
		public static ImGuiKey HoldKey = (ImGuiKey)658;

		private long long_0;

		private string string_0;

		private char char_3;

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

		private string String_0
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

		private char Char_0
		{
			get
			{
				return char_3;
			}
			set
			{
				char_3 = value;
			}
		}

		private string method_8(long long_1)
		{
			return "Хитролох_иди_нахуй._0_6____96________8_9_";
		}
	}

	public sealed class AnomalyScanner
	{
		[ConfigIdAttribute("anomaly_scanner.enabled")]
		public static bool Enabled;

		[ConfigIdAttribute("anomaly_scanner.color")]
		public static Vector4 Color = new Vector4(1f, 0.5f, 0f, 1f);

		[ConfigIdAttribute("anomaly_scanner.max_distance")]
		public static float MaxDistance = 50f;

		[ConfigIdAttribute("anomaly_scanner.font_path")]
		public static string FontPath = "/Fonts/Boxfont-round/Boxfont Round.ttf";

		[ConfigIdAttribute("anomaly_scanner.font_size")]
		public static int FontSize = 10;

		[ConfigIdAttribute("anomaly_scanner.hot_key")]
		public static ImGuiKey HotKey = (ImGuiKey)658;

		private long long_0;

		private int int_0;

		private float float_1;

		private int int_1;

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

		private float Single_0
		{
			get
			{
				return float_1;
			}
			set
			{
				float_1 = value;
			}
		}

		private int Int32_1
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
	}

	public sealed class Performance
	{
		[ConfigIdAttribute("performance.enabled")]
		public static bool Enabled;

		[ConfigIdAttribute("performance.disable_particles")]
		public static bool DisableParticles = true;

		[ConfigIdAttribute("performance.disable_animations")]
		public static bool DisableAnimations = true;

		[ConfigIdAttribute("performance.simplify_shaders")]
		public static bool SimplifyShaders = true;

		[ConfigIdAttribute("performance.simplify_lighting")]
		public static bool SimplifyLighting = true;

		[ConfigIdAttribute("performance.disable_post_processing")]
		public static bool DisablePostProcessing = true;

		[ConfigIdAttribute("performance.aggressive_culling")]
		public static bool AggressiveCulling = true;

		[ConfigIdAttribute("performance.culling_distance")]
		public static float CullingDistance = 15f;

		[ConfigIdAttribute("performance.disable_decals")]
		public static bool DisableDecals = false;

		[ConfigIdAttribute("performance.low_quality_sprites")]
		public static bool LowQualitySprites = false;

		[ConfigIdAttribute("performance.disable_weather_effects")]
		public static bool DisableWeatherEffects = false;

		[ConfigIdAttribute("performance.reduce_physics_quality")]
		public static bool ReducePhysicsQuality = false;

		[ConfigIdAttribute("performance.disable_footsteps")]
		public static bool DisableFootsteps = false;

		private string string_1;

		private byte byte_0;

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
	}

	public sealed class Spammer
	{
		[ConfigIdAttribute("spammer.chat_enabled")]
		public static bool ChatEnabled;

		[ConfigIdAttribute("spammer.chat_text")]
		public static string ChatText;

		[ConfigIdAttribute("spammer.chat_delay")]
		public static int ChatDelay;

		[ConfigIdAttribute("spammer.protect_text_enabled")]
		public static bool ProtectTextEnabled;

		[ConfigIdAttribute("spammer.protect_random_length")]
		public static bool ProtectRandomLength;

		[ConfigIdAttribute("spammer.protect_length")]
		public static int ProtectLength;

		[ConfigIdAttribute("spammer.a_help_enabled")]
		public static bool AHelpEnabled;

		[ConfigIdAttribute("spammer.a_help_text")]
		public static string AHelpText;

		[ConfigIdAttribute("spammer.a_help_delay")]
		public static int AHelpDelay;

		[ConfigIdAttribute("spammer.channels")]
		public static List<int> Channels;

		private long long_0;

		private double double_0;

		private double double_1;

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
				return double_0;
			}
			set
			{
				double_0 = value;
			}
		}

		private double Double_1
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

		static Spammer()
		{
			ChatText = "https://t.me/RobusterHome";
			ChatDelay = 200;
			ProtectRandomLength = true;
			ProtectLength = 6;
			AHelpText = "https://t.me/RobusterHome";
			AHelpDelay = 200;
			List<int> list = new List<int>(1);
			CollectionsMarshal.SetCount(list, 1);
			CollectionsMarshal.AsSpan(list)[0] = 16;
			Channels = list;
		}
	}

	public sealed class Misc
	{
		public static bool TargetStrafeEnabled;

		public static float TargetStrafeDistance = 0.2f;

		public static float TargetStrafeRange = 10f;

		[ConfigIdAttribute("misc.trash_talk_enabled")]
		public static bool TrashTalkEnabled;

		[ConfigIdAttribute("misc.auto_fuck_rules_enabled")]
		public static bool AutoFuckRulesEnabled = false;

		[ConfigIdAttribute("misc.auto_fuck_rules_mode")]
		public static int AutoFuckRulesMode = 0;

		[ConfigIdAttribute("misc.damage_overlay_enabled")]
		public static bool DamageOverlayEnabled;

		[ConfigIdAttribute("misc.anti_soap_enabled")]
		public static bool AntiSoapEnabled;

		[ConfigIdAttribute("misc.anti_afk_enabled")]
		public static bool AntiAfkEnabled;

		[ConfigIdAttribute("misc.anti_aim_enabled")]
		public static bool AntiAimEnabled;

		[ConfigIdAttribute("misc.auto_rotate_speed")]
		public static float AutoRotateSpeed = 2700f;

		[ConfigIdAttribute("misc.item_searcher_enabled")]
		public static bool ItemSearcherEnabled;

		[ConfigIdAttribute("misc.item_search_entries")]
		public static List<ColoredString> ItemSearchEntries = new List<ColoredString>();

		[ConfigIdAttribute("misc.item_searcher_show_name")]
		public static bool ItemSearcherShowName = true;

		[ConfigIdAttribute("misc.show_explosive")]
		public static bool ShowExplosive;

		[ConfigIdAttribute("misc.show_trajectory")]
		public static bool ShowTrajectory;

		[ConfigIdAttribute("misc.zero_g_speed_hack_enabled")]
		public static bool ZeroGSpeedHackEnabled = false;

		[ConfigIdAttribute("misc.zero_g_speed_delay")]
		public static float ZeroGSpeedDelay = 0.15f;

		[ConfigIdAttribute("misc.auto_peek_enabled")]
		public static bool AutoPeekEnabled = false;

		[ConfigIdAttribute("misc.auto_peek_key")]
		public static ImGuiKey AutoPeekKey = (ImGuiKey)0;

		[ConfigIdAttribute("misc.auto_peek_color")]
		public static Vector4 AutoPeekColor = new Vector4(0f, 1f, 0f, 1f);

		private string string_1;

		private double double_1;

		private int int_0;

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

		private string method_8(long long_0, long long_1, long long_2)
		{
			return "Хитролох_иди_нахуй.__6_7__0__";
		}

		private string method_9(char char_0)
		{
			return "Хитролох_иди_нахуй.______01____";
		}
	}

	public sealed class GrenadeHelper
	{
		[ConfigIdAttribute("grenade_helper.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("grenade_helper.show_timer")]
		public static bool ShowTimer = true;

		[ConfigIdAttribute("grenade_helper.show_radius")]
		public static bool ShowRadius = true;

		[ConfigIdAttribute("grenade_helper.show_trajectory")]
		public static bool ShowTrajectory = true;

		[ConfigIdAttribute("grenade_helper.timer_color")]
		public static Vector4 TimerColor = new Vector4(1f, 0f, 0f, 1f);

		[ConfigIdAttribute("grenade_helper.radius_color")]
		public static Vector4 RadiusColor = new Vector4(1f, 0.5f, 0f, 0.3f);

		[ConfigIdAttribute("grenade_helper.trajectory_color")]
		public static Vector4 TrajectoryColor = new Vector4(1f, 1f, 0f, 1f);

		private bool bool_0;

		private double double_1;

		private float float_1;

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
				return float_1;
			}
			set
			{
				float_1 = value;
			}
		}

		private string method_9(byte byte_1, int int_0, float float_2)
		{
			return "Хитролох_иди_нахуй._____87_4__2______";
		}
	}

	public static class AutoDoor
	{
		[ConfigIdAttribute("auto_door.enabled")]
		public static bool Enabled;

		[ConfigIdAttribute("auto_door.auto_close")]
		public static bool AutoClose;
	}

	public static class InstantPickup
	{
		[ConfigIdAttribute("instant_pickup.enabled")]
		public static bool Enabled;

		[ConfigIdAttribute("instant_pickup.smart_equip_enabled")]
		public static bool SmartEquipEnabled;
	}

	public sealed class KillSound
	{
		[ConfigIdAttribute("kill_sound.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("kill_sound.sound_index")]
		public static int SoundIndex = 0;

		[ConfigIdAttribute("kill_sound.volume")]
		public static float Volume = 100f;

		private long long_0;

		private float float_0;

		private bool bool_1;

		private bool bool_2;

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

		private bool Boolean_1
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
	}

	public sealed class TargetEsp
	{
		[ConfigIdAttribute("target_esp.spirits_enabled")]
		public static bool SpiritsEnabled = true;

		[ConfigIdAttribute("target_esp.spirits_color")]
		public static Vector4 SpiritsColor = new Vector4(1f, 0f, 1f, 1f);

		[ConfigIdAttribute("target_esp.spirits_orbit_radius_x")]
		public static float SpiritsOrbitRadiusX = 0.7f;

		[ConfigIdAttribute("target_esp.spirits_orbit_radius_y")]
		public static float SpiritsOrbitRadiusY = 0.2f;

		[ConfigIdAttribute("target_esp.spirits_speed")]
		public static float SpiritsSpeed = 3f;

		[ConfigIdAttribute("target_esp.spirits_size")]
		public static float SpiritsSize = 0.12f;

		[ConfigIdAttribute("target_esp.spirits_trail_length")]
		public static float SpiritsTrailLength = 1.2f;

		[ConfigIdAttribute("target_esp.spirits_smooth_fade")]
		public static bool SpiritsSmoothFade = true;

		[ConfigIdAttribute("target_esp.spirits_mode")]
		public static int SpiritsMode = 0;

		[ConfigIdAttribute("target_esp.enable_spring_effect")]
		public static bool EnableSpringEffect = false;

		[ConfigIdAttribute("target_esp.enable_color_tint")]
		public static bool EnableColorTint = false;

		[ConfigIdAttribute("target_esp.png_tint_color")]
		public static Vector4 PngTintColor = new Vector4(1f, 1f, 1f, 1f);

		private char char_0;

		private long long_0;

		private float float_1;

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

		private float Single_0
		{
			get
			{
				return float_1;
			}
			set
			{
				float_1 = value;
			}
		}
	}

	public sealed class Tracers
	{
		[ConfigIdAttribute("tracers.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("tracers.arrow_variant")]
		public static int ArrowVariant = 0;

		[ConfigIdAttribute("tracers.arrow_color")]
		public static Vector4 ArrowColor = new Vector4(1f, 1f, 1f, 1f);

		private string string_0;

		private double double_0;

		private string String_0
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

		private string method_9(int int_1, double double_1, string string_1)
		{
			return "Хитролох_иди_нахуй._____9_2____2_";
		}

		private string method_11(int int_1, char char_0, long long_0)
		{
			return "Хитролох_иди_нахуй.____69____5___11_7__7_1_";
		}
	}

	public sealed class Movement
	{
		[ConfigIdAttribute("movement.shield_surf_enabled")]
		public static bool ShieldSurfEnabled = false;

		[ConfigIdAttribute("movement.shield_surf_radius")]
		public static float ShieldSurfRadius = 0.35f;

		[ConfigIdAttribute("movement.toggle_key")]
		public static ImGuiKey ToggleKey = (ImGuiKey)0;

		[ConfigIdAttribute("movement.anti_aim_enabled")]
		public static bool AntiAimEnabled = false;

		[ConfigIdAttribute("movement.anti_aim_step_length")]
		public static float AntiAimStepLength = 0.5f;

		[ConfigIdAttribute("movement.anti_aim_circle_radius")]
		public static float AntiAimCircleRadius = 0.3f;

		[ConfigIdAttribute("movement.pixel_surf_enabled")]
		public static bool PixelSurfEnabled = false;

		[ConfigIdAttribute("movement.pixel_surf_key")]
		public static ImGuiKey PixelSurfKey = (ImGuiKey)0;

		[ConfigIdAttribute("movement.pixel_surf_mode")]
		public static int PixelSurfMode = 0;

		[ConfigIdAttribute("movement.speed_saver_enabled")]
		public static bool SpeedSaverEnabled = false;

		[ConfigIdAttribute("movement.speed_saver_strafe_duration_ms")]
		public static int SpeedSaverStrafeDurationMs = 50;

		private string string_0;

		private double double_0;

		private double double_1;

		private long long_1;

		private string String_0
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

		private double Double_1
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
				return long_1;
			}
			set
			{
				long_1 = value;
			}
		}
	}

	public sealed class ThrowAimbot
	{
		[ConfigIdAttribute("throw_aimbot.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("throw_aimbot.range")]
		public static float Range = 15f;

		[ConfigIdAttribute("throw_aimbot.throw_speed")]
		public static float ThrowSpeed = 15f;

		[ConfigIdAttribute("throw_aimbot.prediction_enabled")]
		public static bool PredictionEnabled = true;

		[ConfigIdAttribute("throw_aimbot.show_trajectory")]
		public static bool ShowTrajectory = true;

		[ConfigIdAttribute("throw_aimbot.target_priority")]
		public static int TargetPriority = 0;

		[ConfigIdAttribute("throw_aimbot.only_priority")]
		public static bool OnlyPriority = false;

		[ConfigIdAttribute("throw_aimbot.ignore_cuffed")]
		public static bool IgnoreCuffed = true;

		[ConfigIdAttribute("throw_aimbot.ignore_downed")]
		public static bool IgnoreDowned = false;

		[ConfigIdAttribute("throw_aimbot.ignore_dead")]
		public static bool IgnoreDead = true;

		[ConfigIdAttribute("throw_aimbot.allowed_jobs")]
		public static List<string> AllowedJobs = new List<string>();

		[ConfigIdAttribute("throw_aimbot.blocked_jobs")]
		public static List<string> BlockedJobs = new List<string>();

		[ConfigIdAttribute("throw_aimbot.role_priority")]
		public static List<string> RolePriority = new List<string>();

		private char char_0;

		private double double_2;

		private byte byte_0;

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

		private double Double_0
		{
			get
			{
				return double_2;
			}
			set
			{
				double_2 = value;
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

		private string method_8(char char_1, float float_0)
		{
			return "Хитролох_иди_нахуй.___6___4____3_____";
		}

		private string method_9(double double_3, int int_2)
		{
			return "Хитролох_иди_нахуй.________0___8__________";
		}
	}

	public sealed class AutoSlip
	{
		[ConfigIdAttribute("auto_slip.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("auto_slip.activation_key")]
		public static ImGuiKey ActivationKey = (ImGuiKey)0;

		[ConfigIdAttribute("auto_slip.range")]
		public static float Range = 15f;

		[ConfigIdAttribute("auto_slip.throw_speed")]
		public static float ThrowSpeed = 15f;

		[ConfigIdAttribute("auto_slip.use_prediction")]
		public static bool UsePrediction = true;

		[ConfigIdAttribute("auto_slip.lead_distance")]
		public static float LeadDistance = 1.5f;

		[ConfigIdAttribute("auto_slip.use_role_priority")]
		public static bool UseRolePriority = true;

		private float float_0;

		private bool bool_0;

		private bool bool_1;

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

		private bool Boolean_1
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
	}

	public sealed class Backtrack
	{
		[ConfigIdAttribute("backtrack.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("backtrack.mode")]
		public static int Mode = 1;

		[ConfigIdAttribute("backtrack.use_fake_lag")]
		public static bool UseFakeLag = false;

		[ConfigIdAttribute("backtrack.fake_lag_ms")]
		public static int FakeLagMs = 200;

		[ConfigIdAttribute("backtrack.show_visuals")]
		public static bool ShowVisuals = true;

		[ConfigIdAttribute("backtrack.visuals_mode")]
		public static int VisualsMode = 6;

		[ConfigIdAttribute("backtrack.visuals_color")]
		public static Vector4 VisualsColor = new Vector4(1f, 0f, 1f, 0.5f);

		[ConfigIdAttribute("backtrack.show_line")]
		public static bool ShowLine = true;

		private byte byte_0;

		private float float_0;

		private char char_0;

		private double double_0;

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

		private string method_8(byte byte_1)
		{
			return "Хитролох_иди_нахуй.__1_0____0____";
		}
	}

	public sealed class Chams
	{
		[ConfigIdAttribute("chams.enabled")]
		public static bool Enabled;

		[ConfigIdAttribute("chams.mode")]
		public static int Mode;

		[ConfigIdAttribute("chams.color")]
		public static Vector4 Color = new Vector4(0f, 1f, 0f, 0.5f);

		[ConfigIdAttribute("chams.show_on_local_player")]
		public static bool ShowOnLocalPlayer;

		private float float_0;

		private long long_0;

		private bool bool_1;

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
				return bool_1;
			}
			set
			{
				bool_1 = value;
			}
		}
	}

	public sealed class Combat
	{
		[ConfigIdAttribute("combat.auto_block_enabled")]
		public static bool AutoBlockEnabled = false;

		[ConfigIdAttribute("combat.auto_laydown_enabled")]
		public static bool AutoLaydownEnabled = false;

		[ConfigIdAttribute("combat.auto_laydown_stand_up_delay")]
		public static float AutoLaydownStandUpDelay = 2f;

		private string string_0;

		private double double_1;

		private float float_0;

		private bool bool_0;

		private string String_0
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

		private string method_5(bool bool_1, char char_0, float float_1)
		{
			return "Хитролох_иди_нахуй.______5__450____46_35";
		}
	}

	public sealed class MinecraftVisuals
	{
		[ConfigIdAttribute("minecraft_visuals.jump_circles_enabled")]
		public static bool JumpCirclesEnabled;

		[ConfigIdAttribute("minecraft_visuals.block_outline_enabled")]
		public static bool BlockOutlineEnabled;

		[ConfigIdAttribute("minecraft_visuals.jump_circle_variant")]
		public static int JumpCircleVariant = 0;

		[ConfigIdAttribute("minecraft_visuals.jump_circle_fade_in_speed")]
		public static float JumpCircleFadeInSpeed = 1f;

		[ConfigIdAttribute("minecraft_visuals.jump_circle_fade_out_speed")]
		public static float JumpCircleFadeOutSpeed = 1f;

		[ConfigIdAttribute("minecraft_visuals.jump_circle_rotation_speed")]
		public static float JumpCircleRotationSpeed = 1f;

		[ConfigIdAttribute("minecraft_visuals.jump_circle_color")]
		public static Vector4 JumpCircleColor = new Vector4(1f, 1f, 1f, 1f);

		private float float_0;

		private double double_2;

		private double double_3;

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

		private double Double_0
		{
			get
			{
				return double_2;
			}
			set
			{
				double_2 = value;
			}
		}

		private double Double_1
		{
			get
			{
				return double_3;
			}
			set
			{
				double_3 = value;
			}
		}

		private string method_8(double double_4)
		{
			return "Хитролох_иди_нахуй.____0____3__8";
		}
	}

	public sealed class HitParticles
	{
		[ConfigIdAttribute("hit_particles.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("hit_particles.particle_count")]
		public static int ParticleCount = 15;

		[ConfigIdAttribute("hit_particles.particle_mode")]
		public static int ParticleMode = 0;

		[ConfigIdAttribute("hit_particles.opacity")]
		public static float Opacity = 0.8f;

		[ConfigIdAttribute("hit_particles.particle_size")]
		public static float ParticleSize = 1f;

		[ConfigIdAttribute("hit_particles.particle_lifetime")]
		public static float ParticleLifetime = 0.8f;

		[ConfigIdAttribute("hit_particles.particle_color")]
		public static Vector4 ParticleColor = new Vector4(1f, 1f, 1f, 1f);

		private int int_1;

		private int int_2;

		private byte byte_0;

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

		private int Int32_1
		{
			get
			{
				return int_2;
			}
			set
			{
				int_2 = value;
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

		private string method_4(string string_0)
		{
			return "Хитролох_иди_нахуй._0_9_____79___";
		}
	}

	public sealed class LightSmooth
	{
		[ConfigIdAttribute("light_smooth.enabled")]
		public static bool Enabled;

		[ConfigIdAttribute("light_smooth.fog_density")]
		public static float FogDensity = 0.5f;

		[ConfigIdAttribute("light_smooth.brightness")]
		public static float Brightness = 1f;

		[ConfigIdAttribute("light_smooth.fog_color")]
		public static Vector4 FogColor = new Vector4(0.3f, 0.4f, 0.6f, 1f);

		[ConfigIdAttribute("light_smooth.tint_color")]
		public static Vector4 TintColor = new Vector4(1f, 0.95f, 0.9f, 1f);

		[ConfigIdAttribute("light_smooth.vignette_strength")]
		public static float VignetteStrength = 1f;

		private int int_0;

		private int int_1;

		private char char_0;

		private string string_2;

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

		private int Int32_1
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

		private string String_0
		{
			get
			{
				return string_2;
			}
			set
			{
				string_2 = value;
			}
		}

		private string method_10(double double_0, char char_1, string string_3)
		{
			return "Хитролох_иди_нахуй.__1_8________";
		}
	}

	public sealed class WorldParticles
	{
		[ConfigIdAttribute("world_particles.enabled")]
		public static bool Enabled;

		[ConfigIdAttribute("world_particles.particle_count")]
		public static int ParticleCount = 60;

		[ConfigIdAttribute("world_particles.spawn_radius")]
		public static float SpawnRadius = 15f;

		[ConfigIdAttribute("world_particles.speed")]
		public static float Speed = 1f;

		[ConfigIdAttribute("world_particles.size")]
		public static float Size = 1f;

		[ConfigIdAttribute("world_particles.particle_mode")]
		public static int ParticleMode = 0;

		[ConfigIdAttribute("world_particles.opacity")]
		public static float Opacity = 0.8f;

		[ConfigIdAttribute("world_particles.use_glow")]
		public static bool UseGlow = true;

		[ConfigIdAttribute("world_particles.use_blur")]
		public static bool UseBlur = false;

		[ConfigIdAttribute("world_particles.particle_color")]
		public static Vector4 ParticleColor = new Vector4(1f, 1f, 1f, 1f);

		private float float_1;

		private float float_2;

		private byte byte_0;

		private float Single_0
		{
			get
			{
				return float_1;
			}
			set
			{
				float_1 = value;
			}
		}

		private float Single_1
		{
			get
			{
				return float_2;
			}
			set
			{
				float_2 = value;
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

		private string method_10(byte byte_1)
		{
			return "Хитролох_иди_нахуй.__9____00__26____07__";
		}
	}

	public sealed class Trails
	{
		[ConfigIdAttribute("trails.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("trails.trail_mode")]
		public static int TrailMode = 16;

		[ConfigIdAttribute("trails.trail_size")]
		public static float TrailSize = 0.3f;

		[ConfigIdAttribute("trails.trail_lifetime")]
		public static float TrailLifetime = 2f;

		[ConfigIdAttribute("trails.trail_length")]
		public static float TrailLength = 1f;

		[ConfigIdAttribute("trails.particle_count")]
		public static int ParticleCount = 50;

		[ConfigIdAttribute("trails.particle_spawn_rate")]
		public static float ParticleSpawnRate = 3f;

		[ConfigIdAttribute("trails.trail_color")]
		public static Vector4 TrailColor = new Vector4(1f, 1f, 1f, 1f);

		private double double_0;

		private int int_1;

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
	}

	public sealed class PlayerGlow
	{
		[ConfigIdAttribute("player_glow.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("player_glow.glow_size")]
		public static float GlowSize = 0.15f;

		[ConfigIdAttribute("player_glow.glow_density")]
		public static int GlowDensity = 30;

		[ConfigIdAttribute("player_glow.glow_color")]
		public static Vector4 GlowColor = new Vector4(1f, 1f, 1f, 1f);

		private bool bool_0;

		private string string_1;

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
	}

	public sealed class Sounds
	{
		[ConfigIdAttribute("sounds.enabled")]
		public static bool Enabled = true;

		[ConfigIdAttribute("sounds.selected_pack_index")]
		public static int SelectedPackIndex = 0;

		[ConfigIdAttribute("sounds.volume")]
		public static float Volume = 100f;

		private double double_1;

		private long long_0;

		private long long_1;

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

		private long Int64_1
		{
			get
			{
				return long_1;
			}
			set
			{
				long_1 = value;
			}
		}

		private string method_6(double double_2, char char_1)
		{
			return "Хитролох_иди_нахуй._9__98___3_4__";
		}
	}

	public sealed class AutoLooter
	{
		[ConfigIdAttribute("auto_looter.enabled")]
		public static bool Enabled;

		[ConfigIdAttribute("auto_looter.range")]
		public static float Range = 2.5f;

		[ConfigIdAttribute("auto_looter.pickup_delay")]
		public static float PickupDelay = 0.5f;

		[ConfigIdAttribute("auto_looter.toggle_key")]
		public static ImGuiKey ToggleKey = (ImGuiKey)0;

		[ConfigIdAttribute("auto_looter.loot_entries")]
		public static List<ColoredString> LootEntries = new List<ColoredString>();

		private int int_1;

		private char char_1;

		private string string_0;

		private bool bool_0;

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

		private string String_0
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
	}

	public sealed class AutoMedipen
	{
		[ConfigIdAttribute("auto_medipen.enabled")]
		public static bool Enabled;

		[ConfigIdAttribute("auto_medipen.hp_threshold")]
		public static float HpThreshold = 50f;

		[ConfigIdAttribute("auto_medipen.action_delay")]
		public static int ActionDelay = 0;

		[ConfigIdAttribute("auto_medipen.allowed_medipens")]
		public static List<string> AllowedMedipens = new List<string>();

		private int int_0;

		private int int_1;

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

		private int Int32_1
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
	}

	public sealed class AutoImplant
	{
		[ConfigIdAttribute("auto_implant.enabled")]
		public static bool Enabled;

		[ConfigIdAttribute("auto_implant.hp_threshold")]
		public static float HpThreshold = 30f;

		[ConfigIdAttribute("auto_implant.allowed_implants")]
		public static List<string> AllowedImplants = new List<string>();

		private char char_0;

		private string string_0;

		private float float_1;

		private long long_1;

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

		private string String_0
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

		private float Single_0
		{
			get
			{
				return float_1;
			}
			set
			{
				float_1 = value;
			}
		}

		private long Int64_0
		{
			get
			{
				return long_1;
			}
			set
			{
				long_1 = value;
			}
		}
	}

	public static class AutoDeconstruct
	{
		[ConfigIdAttribute("auto_deconstruct.enabled")]
		public static bool Enabled;

		[ConfigIdAttribute("auto_deconstruct.target_key")]
		public static ImGuiKey TargetKey;

		[ConfigIdAttribute("auto_deconstruct.action_delay")]
		public static int ActionDelay;
	}

	public sealed class NukeBruteforce
	{
		[ConfigIdAttribute("nuke_bruteforce.enabled")]
		public static bool Enabled;

		[ConfigIdAttribute("nuke_bruteforce.code_length")]
		public static int CodeLength = 6;

		[ConfigIdAttribute("nuke_bruteforce.speed")]
		public static int Speed = 100;

		[ConfigIdAttribute("nuke_bruteforce.input_delay")]
		public static int InputDelay = 50;

		private byte byte_1;

		private int int_0;

		private long long_1;

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

		private long Int64_0
		{
			get
			{
				return long_1;
			}
			set
			{
				long_1 = value;
			}
		}
	}

	public sealed class UplinkBruteforce
	{
		[ConfigIdAttribute("uplink_bruteforce.enabled")]
		public static bool Enabled;

		[ConfigIdAttribute("uplink_bruteforce.speed")]
		public static int Speed = 300;

		[ConfigIdAttribute("uplink_bruteforce.input_delay")]
		public static int InputDelay = 0;

		[ConfigIdAttribute("uplink_bruteforce.random_mode")]
		public static bool RandomMode = false;

		private bool bool_1;

		private string string_0;

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

		private string String_0
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
	}

	public sealed class AbilitySpeed
	{
		[ConfigIdAttribute("ability_speed.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("ability_speed.mode")]
		public static int Mode = 0;

		[ConfigIdAttribute("ability_speed.dash_distance")]
		public static float DashDistance = 5f;

		[ConfigIdAttribute("ability_speed.delay_ms")]
		public static int DelayMs = 50;

		private float float_0;

		private double double_0;

		private bool bool_1;

		private double double_1;

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

		private double Double_1
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

		private string method_7(bool bool_2, double double_2, char char_0)
		{
			return "Хитролох_иди_нахуй.________55______0__";
		}
	}

	public sealed class Fun
	{
		[ConfigIdAttribute("fun.enabled")]
		public static bool Enabled;

		[ConfigIdAttribute("fun.rainbow_enabled")]
		public static bool RainbowEnabled;

		[ConfigIdAttribute("fun.rotation_enabled")]
		public static bool RotationEnabled;

		[ConfigIdAttribute("fun.trails_enabled")]
		public static bool TrailsEnabled;

		[ConfigIdAttribute("fun.jump_enabled")]
		public static bool JumpEnabled;

		[ConfigIdAttribute("fun.shake_enabled")]
		public static bool ShakeEnabled;

		[ConfigIdAttribute("fun.rotation_speed")]
		public static float RotationSpeed = 180f;

		[ConfigIdAttribute("fun.color")]
		public static Vector4 Color = new Vector4(1f, 1f, 1f, 1f);

		[ConfigIdAttribute("fun.scale_x")]
		public static float ScaleX = 1f;

		[ConfigIdAttribute("fun.scale_y")]
		public static float ScaleY = 1f;

		[ConfigIdAttribute("fun.rainbow_speed")]
		public static float RainbowSpeed = 1f;

		[ConfigIdAttribute("fun.affect_player")]
		public static bool AffectPlayer;

		[ConfigIdAttribute("fun.affect_mobs")]
		public static bool AffectMobs = true;

		[ConfigIdAttribute("fun.affect_others")]
		public static bool AffectOthers = true;

		private double double_0;

		private float float_0;

		private long long_1;

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

		private long Int64_0
		{
			get
			{
				return long_1;
			}
			set
			{
				long_1 = value;
			}
		}

		private string method_7(char char_0, char char_1)
		{
			return "Хитролох_иди_нахуй.__1_4___9_______8";
		}
	}

	public sealed class Texture
	{
		[ConfigIdAttribute("texture.enabled")]
		public static bool Enabled;

		[ConfigIdAttribute("texture.size")]
		public static float Size = 1.5f;

		[ConfigIdAttribute("texture.make_entities_invisible")]
		public static bool MakeEntitiesInvisible;

		private long long_0;

		private float float_1;

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

		private float Single_0
		{
			get
			{
				return float_1;
			}
			set
			{
				float_1 = value;
			}
		}
	}

	public sealed class Settings
	{
		[ConfigIdAttribute("settings.ui_customizable")]
		public static bool UiCustomizable;

		[ConfigIdAttribute("settings.show_menu")]
		public static bool ShowMenu = true;

		[ConfigIdAttribute("settings.show_menu_hot_key")]
		public static ImGuiKey ShowMenuHotKey = (ImGuiKey)522;

		[ConfigIdAttribute("settings.show_debug_console")]
		public static bool ShowDebugConsole;

		[ConfigIdAttribute("settings.current_language")]
		public static GEnum4 CurrentLanguage = (GEnum4)1;

		[ConfigIdAttribute("settings.clyde_patch")]
		public static bool ClydePatch = true;

		[ConfigIdAttribute("settings.overlays_patch")]
		public static bool OverlaysPatch = true;

		[ConfigIdAttribute("settings.smoke_patch")]
		public static bool SmokePatch = true;

		[ConfigIdAttribute("settings.admin_patch")]
		public static bool AdminPatch = false;

		[ConfigIdAttribute("settings.damage_force_patch")]
		public static bool DamageForcePatch = true;

		[ConfigIdAttribute("settings.no_dmg_friend_patch")]
		public static bool NoDmgFriendPatch = true;

		[ConfigIdAttribute("settings.anti_screen_grub_patch")]
		public static bool AntiScreenGrubPatch = true;

		[ConfigIdAttribute("settings.translate_chat_patch")]
		public static bool TranslateChatPatch;

		[ConfigIdAttribute("settings.translate_chat_lang")]
		public static string TranslateChatLang = "ru";

		[ConfigIdAttribute("settings.translate_me_patch")]
		public static bool TranslateMePatch;

		[ConfigIdAttribute("settings.translate_me_lang")]
		public static string TranslateMeLang = "en";

		[ConfigIdAttribute("settings.no_camera_kick_patch")]
		public static bool NoCameraKickPatch = true;

		private long long_2;

		private int int_0;

		private int int_1;

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

		private int Int32_1
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

		private string method_5(char char_0)
		{
			return "Хитролох_иди_нахуй._6__3__1_";
		}
	}

	public sealed class Notifications
	{
		[ConfigIdAttribute("notifications.enabled")]
		public static bool Enabled = true;

		[ConfigIdAttribute("notifications.max_notifications")]
		public static int MaxNotifications = 5;

		[ConfigIdAttribute("notifications.font_size")]
		public static int FontSize = 1;

		[ConfigIdAttribute("notifications.anchor_position")]
		public static Vector2 AnchorPosition = Vector2.Zero;

		[ConfigIdAttribute("notifications.ignore_size_check")]
		public static bool IgnoreSizeCheck;

		private int int_0;

		private float float_0;

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

		private string method_4(long long_1)
		{
			return "Хитролох_иди_нахуй._________2____0___7_1";
		}

		private string method_5(char char_0, bool bool_0, int int_1)
		{
			return "Хитролох_иди_нахуй.___59___1_________";
		}
	}

	public sealed class NotificationSettings
	{
		[ConfigIdAttribute("notification_settings.enabled")]
		public static bool Enabled = true;

		[ConfigIdAttribute("notification_settings.low_hp_notification")]
		public static bool LowHpNotification = true;

		[ConfigIdAttribute("notification_settings.low_hp_threshold")]
		public static float LowHpThreshold = 50f;

		[ConfigIdAttribute("notification_settings.low_stamina_notification")]
		public static bool LowStaminaNotification = true;

		[ConfigIdAttribute("notification_settings.low_stamina_threshold")]
		public static float LowStaminaThreshold = 30f;

		[ConfigIdAttribute("notification_settings.antag_spawn_notification")]
		public static bool AntagSpawnNotification = true;

		[ConfigIdAttribute("notification_settings.antag_spawn_delay")]
		public static float AntagSpawnDelay = 180f;

		[ConfigIdAttribute("notification_settings.feature_toggle_notification")]
		public static bool FeatureToggleNotification = true;

		[ConfigIdAttribute("notification_settings.low_ammo_notification")]
		public static bool LowAmmoNotification = true;

		[ConfigIdAttribute("notification_settings.low_ammo_threshold")]
		public static int LowAmmoThreshold = 10;

		[ConfigIdAttribute("notification_settings.friend_join_notification")]
		public static bool FriendJoinNotification = true;

		[ConfigIdAttribute("notification_settings.dangerous_atmos_notification")]
		public static bool DangerousAtmosNotification = true;

		[ConfigIdAttribute("notification_settings.low_oxygen_threshold")]
		public static float LowOxygenThreshold = 16f;

		[ConfigIdAttribute("notification_settings.high_temperature_threshold")]
		public static float HighTemperatureThreshold = 350f;

		[ConfigIdAttribute("notification_settings.feature_auto_disable_notification")]
		public static bool FeatureAutoDisableNotification = true;

		[ConfigIdAttribute("notification_settings.chat_ping_notification")]
		public static bool ChatPingNotification = true;

		[ConfigIdAttribute("notification_settings.animation_mode")]
		public static int AnimationMode = 0;

		[ConfigIdAttribute("notification_settings.fade_in_time")]
		public static float FadeInTime = 0.3f;

		[ConfigIdAttribute("notification_settings.fade_out_time")]
		public static float FadeOutTime = 0.5f;

		[ConfigIdAttribute("notification_settings.show_progress_bar")]
		public static bool ShowProgressBar = true;

		private double double_1;

		private int int_0;

		private int int_1;

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

		private int Int32_1
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

		private string method_9(double double_2, string string_1, int int_2)
		{
			return "Хитролох_иди_нахуй.__3______9__51_4_____";
		}
	}

	public sealed class ContainerViewer
	{
		[ConfigIdAttribute("container_viewer.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("container_viewer.max_distance")]
		public static float MaxDistance = 15f;

		[ConfigIdAttribute("container_viewer.show_contents")]
		public static bool ShowContents = true;

		[ConfigIdAttribute("container_viewer.show_count")]
		public static bool ShowCount = true;

		[ConfigIdAttribute("container_viewer.ignore_self")]
		public static bool IgnoreSelf = true;

		[ConfigIdAttribute("container_viewer.normal_color")]
		public static Vector4 NormalColor = new Vector4(0.5f, 0.5f, 1f, 0.8f);

		[ConfigIdAttribute("container_viewer.valuable_color")]
		public static Vector4 ValuableColor = new Vector4(1f, 0.84f, 0f, 1f);

		[ConfigIdAttribute("container_viewer.valuable_items")]
		public static List<string> ValuableItems = new List<string>
		{
			"gun", "rifle", "pistol", "shotgun", "medipen", "hypospray", "brutepack", "ointment", "emag", "uplink",
			"syndicate", "captain", "hos", "ce", "cmo", "rd", "nuke", "disk", "plasma", "uranium",
			"diamond", "gold", "silver"
		};

		private bool bool_0;

		private double double_0;

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
	}

	public sealed class NoSavedConfig
	{
		public static bool HasTarget;

		[ConfigIdAttribute("no_saved_config.has_anti_cheat")]
		public static bool HasAntiCheat;

		[ConfigIdAttribute("no_saved_config.version")]
		public static string Version = "V3.1.2";

		private char char_0;

		private long long_0;

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

		private string method_10(byte byte_1)
		{
			return "Хитролох_иди_нахуй._02______9_____3";
		}
	}

	public sealed class NoInteract
	{
		[ConfigIdAttribute("no_interact.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("no_interact.blocked_tags")]
		public static List<string> BlockedTags = new List<string>();

		private double double_0;

		private double double_1;

		private bool bool_0;

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

		private double Double_1
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
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}
	}

	public sealed class HitboxVisualizer
	{
		[ConfigIdAttribute("hitbox_visualizer.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("hitbox_visualizer.show_players")]
		public static bool ShowPlayers = true;

		[ConfigIdAttribute("hitbox_visualizer.show_items")]
		public static bool ShowItems = true;

		[ConfigIdAttribute("hitbox_visualizer.show_all")]
		public static bool ShowAll = false;

		[ConfigIdAttribute("hitbox_visualizer.player_color")]
		public static Vector4 PlayerColor = new Vector4(0f, 1f, 0f, 0.5f);

		[ConfigIdAttribute("hitbox_visualizer.item_color")]
		public static Vector4 ItemColor = new Vector4(1f, 1f, 0f, 0.5f);

		[ConfigIdAttribute("hitbox_visualizer.other_color")]
		public static Vector4 OtherColor = new Vector4(1f, 0f, 0f, 0.5f);

		[ConfigIdAttribute("hitbox_visualizer.line_thickness")]
		public static float LineThickness = 2f;

		[ConfigIdAttribute("hitbox_visualizer.extend_reach")]
		public static bool ExtendReach = false;

		[ConfigIdAttribute("hitbox_visualizer.reach_multiplier")]
		public static float ReachMultiplier = 2f;

		private bool bool_2;

		private byte byte_0;

		private byte byte_1;

		private float float_0;

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

		private byte Byte_1
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
	}

	public sealed class AutoInteract
	{
		[ConfigIdAttribute("auto_interact.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("auto_interact.range")]
		public static float Range = 2f;

		[ConfigIdAttribute("auto_interact.cooldown")]
		public static float Cooldown = 0.5f;

		[ConfigIdAttribute("auto_interact.auto_pickup")]
		public static bool AutoPickup = true;

		[ConfigIdAttribute("auto_interact.auto_activate")]
		public static bool AutoActivate = true;

		private string string_1;

		private bool bool_1;

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
	}

	public sealed class QuickUse
	{
		[ConfigIdAttribute("quick_use.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("quick_use.medipen_key")]
		public static ImGuiKey MedipenKey = (ImGuiKey)571;

		[ConfigIdAttribute("quick_use.food_key")]
		public static ImGuiKey FoodKey = (ImGuiKey)569;

		[ConfigIdAttribute("quick_use.drink_key")]
		public static ImGuiKey DrinkKey = (ImGuiKey)548;

		private byte byte_0;

		private double double_0;

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

		private string method_9(bool bool_0, double double_1)
		{
			return "Хитролох_иди_нахуй._9___4_2_1_7___4";
		}
	}

	public sealed class XRay
	{
		[ConfigIdAttribute("x_ray.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("x_ray.range")]
		public static float Range = 20f;

		[ConfigIdAttribute("x_ray.alpha")]
		public static float Alpha = 0.5f;

		[ConfigIdAttribute("x_ray.show_center")]
		public static bool ShowCenter = true;

		[ConfigIdAttribute("x_ray.default_color")]
		public static Vector4 DefaultColor = new Vector4(1f, 1f, 1f, 1f);

		[ConfigIdAttribute("x_ray.player_color")]
		public static Vector4 PlayerColor = new Vector4(1f, 0f, 0f, 1f);

		[ConfigIdAttribute("x_ray.item_color")]
		public static Vector4 ItemColor = new Vector4(0f, 1f, 0f, 1f);

		[ConfigIdAttribute("x_ray.door_color")]
		public static Vector4 DoorColor = new Vector4(0f, 0.5f, 1f, 1f);

		private string string_0;

		private string string_1;

		private char char_1;

		private string string_2;

		private string String_0
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

		private string String_1
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

		private string String_2
		{
			get
			{
				return string_2;
			}
			set
			{
				string_2 = value;
			}
		}
	}

	public sealed class CloakedPlayerDetector
	{
		[ConfigIdAttribute("cloaked_player_detector.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("cloaked_player_detector.max_distance")]
		public static float MaxDistance = 30f;

		[ConfigIdAttribute("cloaked_player_detector.cloaked_color")]
		public static Vector4 CloakedColor = new Vector4(1f, 0f, 1f, 0.7f);

		[ConfigIdAttribute("cloaked_player_detector.ninja_color")]
		public static Vector4 NinjaColor = new Vector4(1f, 0f, 0f, 1f);

		[ConfigIdAttribute("cloaked_player_detector.show_outline")]
		public static bool ShowOutline = true;

		[ConfigIdAttribute("cloaked_player_detector.show_warning_for_ninja")]
		public static bool ShowWarningForNinja = true;

		[ConfigIdAttribute("cloaked_player_detector.min_visibility_threshold")]
		public static float MinVisibilityThreshold = 0.5f;

		private bool bool_0;

		private int int_0;

		private float float_0;

		private char char_0;

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
	}

	public sealed class AutoCuff
	{
		[ConfigIdAttribute("auto_cuff.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("auto_cuff.activation_key")]
		public static ImGuiKey ActivationKey = (ImGuiKey)0;

		[ConfigIdAttribute("auto_cuff.target_priority")]
		public static GEnum11 TargetPriority = (GEnum11)1;

		[ConfigIdAttribute("auto_cuff.only_stunned")]
		public static bool OnlyStunned = true;

		private long long_0;

		private float float_1;

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

		private float Single_0
		{
			get
			{
				return float_1;
			}
			set
			{
				float_1 = value;
			}
		}
	}

	public sealed class AutoStop
	{
		[ConfigIdAttribute("auto_stop.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("auto_stop.activation_key")]
		public static ImGuiKey ActivationKey = (ImGuiKey)0;

		[ConfigIdAttribute("auto_stop.interval_ms")]
		public static float IntervalMs = 100f;

		private byte byte_1;

		private long long_0;

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
	}

	public sealed class AutoHypo
	{
		[ConfigIdAttribute("auto_hypo.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("auto_hypo.hp_threshold")]
		public static float HpThreshold = 50f;

		[ConfigIdAttribute("auto_hypo.inject_count")]
		public static int InjectCount = 1;

		[ConfigIdAttribute("auto_hypo.force_key")]
		public static ImGuiKey ForceKey = (ImGuiKey)0;

		private double double_0;

		private char char_0;

		private double double_1;

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

		private double Double_1
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
	}

	public sealed class AutoCombo
	{
		[ConfigIdAttribute("auto_combo.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("auto_combo.macro_keybinds")]
		public static Dictionary<string, ImGuiKey> MacroKeybinds = new Dictionary<string, ImGuiKey>();

		private bool bool_1;

		private long long_0;

		private byte byte_0;

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
				return byte_0;
			}
			set
			{
				byte_0 = value;
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

		private string method_9(byte byte_1, char char_0)
		{
			return "Хитролох_иди_нахуй._1___6______6";
		}
	}

	public sealed class AutoHackDoors
	{
		[ConfigIdAttribute("auto_hack_doors.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("auto_hack_doors.range")]
		public static float Range = 2f;

		[ConfigIdAttribute("auto_hack_doors.cooldown")]
		public static float Cooldown = 1f;

		[ConfigIdAttribute("auto_hack_doors.require_multitool")]
		public static bool RequireMultitool = true;

		[ConfigIdAttribute("auto_hack_doors.only_bolted_doors")]
		public static bool OnlyBoltedDoors = true;

		[ConfigIdAttribute("auto_hack_doors.only_locked_doors")]
		public static bool OnlyLockedDoors = false;

		private double double_0;

		private bool bool_0;

		private char char_2;

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

		private char Char_0
		{
			get
			{
				return char_2;
			}
			set
			{
				char_2 = value;
			}
		}
	}

	public sealed class AutoStrip
	{
		[ConfigIdAttribute("auto_strip.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("auto_strip.range")]
		public static float Range = 1.5f;

		[ConfigIdAttribute("auto_strip.cooldown")]
		public static float Cooldown = 0.5f;

		[ConfigIdAttribute("auto_strip.strip_weapons_first")]
		public static bool StripWeaponsFirst = true;

		[ConfigIdAttribute("auto_strip.strip_armor")]
		public static bool StripArmor = true;

		[ConfigIdAttribute("auto_strip.strip_clothing")]
		public static bool StripClothing = false;

		[ConfigIdAttribute("auto_strip.auto_mode")]
		public static bool AutoMode = false;

		[ConfigIdAttribute("auto_strip.strip_all_key")]
		public static ImGuiKey StripAllKey = (ImGuiKey)0;

		private bool bool_1;

		private long long_0;

		private int int_0;

		private bool bool_2;

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

		private bool Boolean_1
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
	}

	public static class AutoPath
	{
		[ConfigIdAttribute("auto_path.enabled")]
		public static bool Enabled;
	}

	public sealed class TurretEsp
	{
		[ConfigIdAttribute("turret_esp.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("turret_esp.max_distance")]
		public static float MaxDistance = 30f;

		[ConfigIdAttribute("turret_esp.hostile_color")]
		public static Vector4 HostileColor = new Vector4(1f, 0f, 0f, 1f);

		[ConfigIdAttribute("turret_esp.friendly_color")]
		public static Vector4 FriendlyColor = new Vector4(0f, 1f, 0f, 1f);

		[ConfigIdAttribute("turret_esp.show_attack_radius")]
		public static bool ShowAttackRadius = true;

		private float float_1;

		private byte byte_0;

		private char char_0;

		private string string_0;

		private float Single_0
		{
			get
			{
				return float_1;
			}
			set
			{
				float_1 = value;
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

		private string String_0
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

		private string method_5(float float_2)
		{
			return "Хитролох_иди_нахуй._4_9___7______84____545";
		}
	}

	public sealed class TrapEsp
	{
		[ConfigIdAttribute("trap_esp.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("trap_esp.max_distance")]
		public static float MaxDistance = 20f;

		[ConfigIdAttribute("trap_esp.show_land_mines")]
		public static bool ShowLandMines = true;

		[ConfigIdAttribute("trap_esp.show_proximity_sensors")]
		public static bool ShowProximitySensors = true;

		[ConfigIdAttribute("trap_esp.show_step_triggers")]
		public static bool ShowStepTriggers = true;

		[ConfigIdAttribute("trap_esp.show_trigger_radius")]
		public static bool ShowTriggerRadius = true;

		[ConfigIdAttribute("trap_esp.armed_color")]
		public static Vector4 ArmedColor = new Vector4(1f, 0f, 0f, 1f);

		[ConfigIdAttribute("trap_esp.disarmed_color")]
		public static Vector4 DisarmedColor = new Vector4(0f, 1f, 0f, 0.5f);

		private char char_0;

		private string string_0;

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

		private string String_0
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

		private string method_6(float float_0)
		{
			return "Хитролох_иди_нахуй.______5_____4___1__";
		}
	}

	public sealed class SmartTargetSelection
	{
		[ConfigIdAttribute("smart_target_selection.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("smart_target_selection.priority")]
		public static int Priority = 2;

		[ConfigIdAttribute("smart_target_selection.ignore_teammates")]
		public static bool IgnoreTeammates = true;

		[ConfigIdAttribute("smart_target_selection.ignore_cuffed")]
		public static bool IgnoreCuffed = true;

		[ConfigIdAttribute("smart_target_selection.ignore_dead")]
		public static bool IgnoreDead = true;

		[ConfigIdAttribute("smart_target_selection.max_range")]
		public static float MaxRange = 20f;

		private string string_0;

		private byte byte_0;

		private bool bool_1;

		private string String_0
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
	}

	public sealed class TargetLock
	{
		[ConfigIdAttribute("target_lock.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("target_lock.lock_key")]
		public static ImGuiKey LockKey = (ImGuiKey)565;

		[ConfigIdAttribute("target_lock.unlock_key")]
		public static ImGuiKey UnlockKey = (ImGuiKey)570;

		[ConfigIdAttribute("target_lock.max_distance")]
		public static float MaxDistance = 25f;

		[ConfigIdAttribute("target_lock.unlock_on_death")]
		public static bool UnlockOnDeath = true;

		[ConfigIdAttribute("target_lock.show_lock_indicator")]
		public static bool ShowLockIndicator = true;

		[ConfigIdAttribute("target_lock.lock_color")]
		public static Vector4 LockColor = new Vector4(1f, 0f, 0f, 1f);

		private bool bool_0;

		private string string_1;

		private byte byte_1;

		private byte byte_2;

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

		private byte Byte_1
		{
			get
			{
				return byte_2;
			}
			set
			{
				byte_2 = value;
			}
		}
	}

	public sealed class AutoShoot
	{
		[ConfigIdAttribute("auto_shoot.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("auto_shoot.aim_tolerance")]
		public static float AimTolerance = 0.1f;

		[ConfigIdAttribute("auto_shoot.fire_delay")]
		public static int FireDelay = 100;

		[ConfigIdAttribute("auto_shoot.only_when_locked")]
		public static bool OnlyWhenLocked = true;

		[ConfigIdAttribute("auto_shoot.require_line_of_sight")]
		public static bool RequireLineOfSight = true;

		private byte byte_0;

		private string string_0;

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
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}
	}

	public sealed class TargetFilters
	{
		[ConfigIdAttribute("target_filters.ignore_dead")]
		public static bool IgnoreDead = true;

		[ConfigIdAttribute("target_filters.ignore_ghosts")]
		public static bool IgnoreGhosts = true;

		[ConfigIdAttribute("target_filters.ignore_invisible")]
		public static bool IgnoreInvisible = false;

		[ConfigIdAttribute("target_filters.min_visibility")]
		public static float MinVisibility = 0.3f;

		[ConfigIdAttribute("target_filters.ignore_cuffed")]
		public static bool IgnoreCuffed = true;

		[ConfigIdAttribute("target_filters.ignore_stunned")]
		public static bool IgnoreStunned = true;

		[ConfigIdAttribute("target_filters.ignore_sleeping")]
		public static bool IgnoreSleeping = true;

		[ConfigIdAttribute("target_filters.ignore_buckled")]
		public static bool IgnoreBuckled = false;

		[ConfigIdAttribute("target_filters.ignore_critical")]
		public static bool IgnoreCritical = true;

		[ConfigIdAttribute("target_filters.ignore_paralyzed")]
		public static bool IgnoreParalyzed = true;

		[ConfigIdAttribute("target_filters.min_health_percent")]
		public static float MinHealthPercent = 0f;

		[ConfigIdAttribute("target_filters.max_health_percent")]
		public static float MaxHealthPercent = 100f;

		[ConfigIdAttribute("target_filters.only_armed")]
		public static bool OnlyArmed = false;

		[ConfigIdAttribute("target_filters.only_with_guns")]
		public static bool OnlyWithGuns = false;

		[ConfigIdAttribute("target_filters.ignore_unarmed")]
		public static bool IgnoreUnarmed = false;

		[ConfigIdAttribute("target_filters.only_in_combat_mode")]
		public static bool OnlyInCombatMode = false;

		[ConfigIdAttribute("target_filters.ignore_security")]
		public static bool IgnoreSecurity = false;

		[ConfigIdAttribute("target_filters.ignore_medical")]
		public static bool IgnoreMedical = false;

		[ConfigIdAttribute("target_filters.only_antagonists")]
		public static bool OnlyAntagonists = false;

		[ConfigIdAttribute("target_filters.ignore_ninja")]
		public static bool IgnoreNinja = false;

		[ConfigIdAttribute("target_filters.ignore_nuke_ops")]
		public static bool IgnoreNukeOps = false;

		[ConfigIdAttribute("target_filters.ignore_teammates")]
		public static bool IgnoreTeammates = true;

		[ConfigIdAttribute("target_filters.ignore_admins")]
		public static bool IgnoreAdmins = true;

		[ConfigIdAttribute("target_filters.max_distance")]
		public static float MaxDistance = 20f;

		[ConfigIdAttribute("target_filters.min_distance")]
		public static float MinDistance = 0f;

		private byte byte_1;

		private string string_0;

		private bool bool_0;

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
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

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

		private string method_11(string string_1)
		{
			return "Хитролох_иди_нахуй.___0_87_3_______2__2___";
		}
	}

	public sealed class AmbientLight
	{
		[ConfigIdAttribute("ambient_light.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("ambient_light.mode")]
		public static int Mode = 0;

		[ConfigIdAttribute("ambient_light.intensity")]
		public static float Intensity = 1f;

		[ConfigIdAttribute("ambient_light.custom_color")]
		public static Vector4 CustomColor = new Vector4(1f, 1f, 1f, 1f);

		private string string_1;

		private long long_0;

		private bool bool_0;

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
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		private string method_7(int int_0)
		{
			return "Хитролох_иди_нахуй.__6___86_";
		}
	}

	public sealed class LightEnhancement
	{
		[ConfigIdAttribute("light_enhancement.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("light_enhancement.energy_multiplier")]
		public static float EnergyMultiplier = 2f;

		[ConfigIdAttribute("light_enhancement.radius_multiplier")]
		public static float RadiusMultiplier = 1.5f;

		private bool bool_0;

		private byte byte_0;

		private long long_0;

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
	}

	public sealed class VisualEnhancement
	{
		[ConfigIdAttribute("visual_enhancement.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("visual_enhancement.brightness")]
		public static float Brightness = 1f;

		[ConfigIdAttribute("visual_enhancement.contrast")]
		public static float Contrast = 1f;

		[ConfigIdAttribute("visual_enhancement.saturation")]
		public static float Saturation = 1f;

		[ConfigIdAttribute("visual_enhancement.gamma")]
		public static float Gamma = 1f;

		private bool bool_0;

		private int int_0;

		private byte byte_0;

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
				return byte_0;
			}
			set
			{
				byte_0 = value;
			}
		}
	}

	public sealed class PacketSpammer
	{
		[ConfigIdAttribute("packet_spammer.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("packet_spammer.packet_size")]
		public static int PacketSize = 8;

		[ConfigIdAttribute("packet_spammer.packets_per_burst")]
		public static int PacketsPerBurst = 300;

		[ConfigIdAttribute("packet_spammer.burst_delay")]
		public static int BurstDelay = 100;

		[ConfigIdAttribute("packet_spammer.thread_count")]
		public static int ThreadCount = 4;

		[ConfigIdAttribute("packet_spammer.use_random_data")]
		public static bool UseRandomData = true;

		[ConfigIdAttribute("packet_spammer.log_sending")]
		public static bool LogSending = true;

		[ConfigIdAttribute("packet_spammer.packet_type")]
		public static int PacketType = 0;

		private long long_0;

		private long long_1;

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

		private long Int64_1
		{
			get
			{
				return long_1;
			}
			set
			{
				long_1 = value;
			}
		}
	}

	public sealed class EventSpammer
	{
		[ConfigIdAttribute("event_spammer.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("event_spammer.min_delay")]
		public static int MinDelay = 0;

		[ConfigIdAttribute("event_spammer.max_delay")]
		public static int MaxDelay = 200;

		[ConfigIdAttribute("event_spammer.burst_mode")]
		public static bool BurstMode = false;

		[ConfigIdAttribute("event_spammer.burst_size")]
		public static int BurstSize = 5;

		[ConfigIdAttribute("event_spammer.parallel_mode")]
		public static bool ParallelMode = false;

		[ConfigIdAttribute("event_spammer.spam_interaction")]
		public static bool SpamInteraction = true;

		[ConfigIdAttribute("event_spammer.spam_hand_activate")]
		public static bool SpamHandActivate = true;

		[ConfigIdAttribute("event_spammer.spam_item_drop")]
		public static bool SpamItemDrop = true;

		[ConfigIdAttribute("event_spammer.spam_item_pickup")]
		public static bool SpamItemPickup = true;

		[ConfigIdAttribute("event_spammer.spam_pull")]
		public static bool SpamPull = true;

		[ConfigIdAttribute("event_spammer.spam_push")]
		public static bool SpamPush = true;

		[ConfigIdAttribute("event_spammer.spam_move_input")]
		public static bool SpamMoveInput = true;

		[ConfigIdAttribute("event_spammer.spam_sprint")]
		public static bool SpamSprint = true;

		[ConfigIdAttribute("event_spammer.spam_crouch")]
		public static bool SpamCrouch = true;

		[ConfigIdAttribute("event_spammer.spam_verb")]
		public static bool SpamVerb = true;

		[ConfigIdAttribute("event_spammer.spam_examine")]
		public static bool SpamExamine = true;

		[ConfigIdAttribute("event_spammer.spam_attack")]
		public static bool SpamAttack = true;

		[ConfigIdAttribute("event_spammer.spam_use")]
		public static bool SpamUse = true;

		[ConfigIdAttribute("event_spammer.spam_throw")]
		public static bool SpamThrow = true;

		[ConfigIdAttribute("event_spammer.spam_equip")]
		public static bool SpamEquip = true;

		[ConfigIdAttribute("event_spammer.spam_unequip")]
		public static bool SpamUnequip = true;

		[ConfigIdAttribute("event_spammer.spam_storage")]
		public static bool SpamStorage = true;

		[ConfigIdAttribute("event_spammer.spam_container")]
		public static bool SpamContainer = true;

		[ConfigIdAttribute("event_spammer.spam_wield")]
		public static bool SpamWield = true;

		private float float_0;

		private long long_0;

		private float float_1;

		private bool bool_1;

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

		private float Single_1
		{
			get
			{
				return float_1;
			}
			set
			{
				float_1 = value;
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
	}

	public sealed class FreeCam
	{
		[ConfigIdAttribute("freecam.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("freecam.speed")]
		public static float Speed = 10f;

		[ConfigIdAttribute("freecam.smoothing")]
		public static float Smoothing = 15f;

		private double double_0;

		private char char_0;

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
	}

	public static class NoTrash
	{
		[ConfigIdAttribute("notrash.hide_casings")]
		public static bool HideCasings;

		[ConfigIdAttribute("notrash.hide_decals")]
		public static bool HideDecals;

		[ConfigIdAttribute("notrash.hide_lamps")]
		public static bool HideLamps;
	}

	public sealed class FoamFading
	{
		[ConfigIdAttribute("foam_fading.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("foam_fading.alpha")]
		public static float Alpha = 0.3f;

		private bool bool_1;

		private double double_1;

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
	}

	public static class SolutionScanner
	{
		[ConfigIdAttribute("solution_scanner.enabled")]
		public static bool Enabled;
	}

	public static class SurgeryExploit
	{
		[ConfigIdAttribute("surgery_exploit.enabled")]
		public static bool Enabled;

		[ConfigIdAttribute("surgery_exploit.group1_depth_enabled")]
		public static bool Group1DepthEnabled;

		[ConfigIdAttribute("surgery_exploit.group2_depth_enabled")]
		public static bool Group2DepthEnabled;
	}

	public static class InsulationChecker
	{
		[ConfigIdAttribute("insulation_checker.enabled")]
		public static bool Enabled;
	}

	public sealed class AutoPainter
	{
		[ConfigIdAttribute("auto_painter.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("auto_painter.draw_delay_ms")]
		public static int DrawDelayMs = 100;

		[ConfigIdAttribute("auto_painter.target_size")]
		public static int TargetSize = 32;

		[ConfigIdAttribute("auto_painter.detail_level")]
		public static int DetailLevel = 2;

		[ConfigIdAttribute("auto_painter.loaded_image_path")]
		public static string LoadedImagePath = "";

		private double double_0;

		private string string_1;

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
	}

	public sealed class HardwareUnlocker
	{
		[ConfigIdAttribute("hardware_unlocker.enabled")]
		public static bool Enabled = false;

		[ConfigIdAttribute("hardware_unlocker.high_priority")]
		public static bool HighPriority = true;

		[ConfigIdAttribute("hardware_unlocker.realtime_priority")]
		public static bool RealtimePriority = false;

		[ConfigIdAttribute("hardware_unlocker.unlock_all_cores")]
		public static bool UnlockAllCores = true;

		[ConfigIdAttribute("hardware_unlocker.optimize_thread_pool")]
		public static bool OptimizeThreadPool = true;

		[ConfigIdAttribute("hardware_unlocker.optimize_gc")]
		public static bool OptimizeGC = true;

		[ConfigIdAttribute("hardware_unlocker.gpu_priority")]
		public static bool GPUPriority = true;

		private double double_1;

		private int int_1;

		private long long_1;

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

		private long Int64_0
		{
			get
			{
				return long_1;
			}
			set
			{
				long_1 = value;
			}
		}
	}

	[ConfigIdAttribute("friends_list")]
	public static List<string> list_0 = new List<string>();

	[ConfigIdAttribute("priority_list")]
	public static List<string> list_1 = new List<string>();

	private int int_0;

	private char char_0;

	private byte byte_1;

	private double double_0;

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
}
