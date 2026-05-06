using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using CerberusWareV3.MyImGui;
using Content.Shared.Mobs;
using Content.Shared.Mobs.Components;
using HarmonyLib;
using Hexa.NET.ImGui;
using Robust.Client;
using Robust.Client.Console;
using Robust.Client.Player;
using Robust.Shared.Console;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using Robust.Shared.Network;
using Robust.Shared.Physics.Components;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using DamageableHelper;
using CerberusConfig;

public class HudRenderer : IOverlay
{
	private struct HudModuleItem(string name, Func<bool> isEnabled, Vector4? color = null)
	{
		public string T0mNPik8N5 = name;

		public Func<bool> XZEN8jy750 = isEnabled;

		public Vector4? bV4NkhP63E = color;

		public float qmqN3C7rJH = 0f;

		public float A6INM46xvQ = 0f;

		public float NxQNfFyHVE = 0f;

		private byte byte_0;

		private long long_0;

		private int int_0;

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
				return int_0;
			}
			set
			{
				int_0 = value;
			}
		}
	}

	private IPlayerManager iplayerManager_0;

	private IEntityManager ientityManager_0;

	private IClientNetManager iclientNetManager_0;

	private IGameTiming igameTiming_0;

	private IClientConsoleHost iclientConsoleHost_0;

	private SpriteRenderQueue gclass40_0;

	private EntityUid? nullable_0;

	private TimeSpan timeSpan_0;

	private readonly List<string> list_0 = new List<string>();

	private DateTime dateTime_0 = DateTime.MinValue;

	private bool bool_0;

	private EventHandler<AddStringArgs> eventHandler_0;

	private bool bool_1;

	private static bool bool_2 = false;

	private static int int_0 = 0;

	private static FieldInfo? fieldInfo_0;

	private static bool bool_3 = false;

	private float float_0;

	private string string_0 = "0, 0";

	private Vector2 vector2_0 = Vector2.Zero;

	private string string_1;

	private bool bool_4;

	private float float_1;

	private string string_2 = "0.0 m/s";

	private float float_2;

	private string string_3 = "0 ms";

	private short short_0;

	private float float_3;

	private int int_1;

	private float float_4;

	private List<string> list_1 = new List<string>();

	private float float_5;

	private List<(Vector2, uint)> list_2 = new List<(Vector2, uint)>();

	private float float_6;

	private string string_4 = "Unknown";

	private readonly Vector4 vector4_0 = new Vector4(0.02f, 0.71f, 0.83f, 1f);

	private readonly Vector4 vector4_1 = new Vector4(0.66f, 0.33f, 0.97f, 1f);

	private readonly Vector4 vector4_2 = new Vector4(0.04f, 0.04f, 0.06f, 0.6f);

	private readonly Vector4 vector4_3 = new Vector4(1f, 1f, 1f, 0.1f);

	private Dictionary<string, HudModuleItem> dictionary_0 = new Dictionary<string, HudModuleItem>();

	private List<HudModuleItem> list_3;

	private static readonly List<DateTime> list_4 = new List<DateTime>();

	private byte byte_0;

	private string string_5;

	private byte byte_1;

	private byte byte_2;

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
			return string_5;
		}
		set
		{
			string_5 = value;
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

	private byte Byte_2
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

	private static Vector4 GetRainbowColor(float speed, float offset)
	{
		return HsvToRgb(((float)ImGui.GetTime() * speed + offset) % 1f, 0.8f, 1f);
	}

	private static Vector4 HsvToRgb(float h, float s, float v)
	{
		int num = (int)(h * 6f);
		float num2 = h * 6f - (float)num;
		float num3 = v * (1f - s);
		float num4 = v * (1f - num2 * s);
		float num5 = v * (1f - (1f - num2) * s);
		return (num % 6) switch
		{
			5 => new Vector4(v, num3, num4, 1f), 
			0 => new Vector4(v, num5, num3, 1f), 
			1 => new Vector4(num4, v, num3, 1f), 
			2 => new Vector4(num3, v, num5, 1f), 
			3 => new Vector4(num3, num4, v, 1f), 
			4 => new Vector4(num5, num3, v, 1f), 
			_ => new Vector4(1f, 1f, 1f, 1f), 
		};
	}

	private void InitializeModulesList()
	{
		list_3 = new List<HudModuleItem>
		{
			new HudModuleItem("Gun Aimbot", () => CerberusConfig.GunAimBot.Enabled),
			new HudModuleItem("Melee Aimbot", () => CerberusConfig.MeleeAimBot.Enabled),
			new HudModuleItem("Throw Aimbot", () => CerberusConfig.ThrowAimbot.Enabled),
			new HudModuleItem("Auto Slip", () => CerberusConfig.AutoSlip.Enabled),
			new HudModuleItem("ESP", () => CerberusConfig.Esp.Enabled),
			new HudModuleItem("Item ESP", () => CerberusConfig.Misc.ItemSearcherEnabled),
			new HudModuleItem("Projectile ESP", () => CerberusConfig.ProjectileEsp.Enabled),
			new HudModuleItem("Target ESP", () => CerberusConfig.TargetEsp.SpiritsEnabled),
			new HudModuleItem("Tracers", () => CerberusConfig.Tracers.Enabled),
			new HudModuleItem("Chams", () => CerberusConfig.Chams.Enabled),
			new HudModuleItem("Trails", () => CerberusConfig.Trails.Enabled),
			new HudModuleItem("Player Glow", () => CerberusConfig.PlayerGlow.Enabled),
			new HudModuleItem("World Particles", () => CerberusConfig.WorldParticles.Enabled),
			new HudModuleItem("Hit Particles", () => CerberusConfig.HitParticles.Enabled),
			new HudModuleItem("Minecraft Visuals", () => CerberusConfig.MinecraftVisuals.JumpCirclesEnabled || CerberusConfig.MinecraftVisuals.BlockOutlineEnabled),
			new HudModuleItem("Grenade Helper", () => CerberusConfig.GrenadeHelper.Enabled),
			new HudModuleItem("Storage Viewer", () => CerberusConfig.StorageViewer.Enabled),
			new HudModuleItem("Access Viewer", () => CerberusConfig.AccessViewer.Enabled),
			new HudModuleItem("Access Checker", () => CerberusConfig.AccessChecker.Enabled),
			new HudModuleItem("Health Info", () => CerberusConfig.HealthInfo.Enabled),
			new HudModuleItem("Anomaly Scanner", () => CerberusConfig.AnomalyScanner.Enabled),
			new HudModuleItem("Cloaked Detector", () => CerberusConfig.CloakedPlayerDetector.Enabled),
			new HudModuleItem("Turret ESP", () => CerberusConfig.TurretEsp.Enabled),
			new HudModuleItem("Trap ESP", () => CerberusConfig.TrapEsp.Enabled),
			new HudModuleItem("Container Viewer", () => CerberusConfig.ContainerViewer.Enabled),
			new HudModuleItem("Hitbox Visualizer", () => CerberusConfig.HitboxVisualizer.Enabled),
			new HudModuleItem("Target Strafe", () => CerberusConfig.Misc.TargetStrafeEnabled),
			new HudModuleItem("Shield Surf", () => CerberusConfig.Movement.ShieldSurfEnabled),
			new HudModuleItem("Pixel Surf", () => CerberusConfig.Movement.PixelSurfEnabled),
			new HudModuleItem("Anti Aim", () => CerberusConfig.Movement.AntiAimEnabled),
			new HudModuleItem("Zero-G Speed", () => CerberusConfig.Misc.ZeroGSpeedHackEnabled),
			new HudModuleItem("Speed Saver", () => CerberusConfig.Movement.SpeedSaverEnabled),
			new HudModuleItem("Auto Path", () => CerberusConfig.AutoPath.Enabled),
			new HudModuleItem("Auto Block", () => CerberusConfig.Combat.AutoBlockEnabled),
			new HudModuleItem("Auto Laydown", () => CerberusConfig.Combat.AutoLaydownEnabled),
			new HudModuleItem("Backtrack", () => CerberusConfig.Backtrack.Enabled),
			new HudModuleItem("Smart Target", () => CerberusConfig.SmartTargetSelection.Enabled),
			new HudModuleItem("Target Lock", () => CerberusConfig.TargetLock.Enabled),
			new HudModuleItem("Auto Shoot", () => CerberusConfig.AutoShoot.Enabled),
			new HudModuleItem("Auto Looter", () => CerberusConfig.AutoLooter.Enabled),
			new HudModuleItem("Auto Medipen", () => CerberusConfig.AutoMedipen.Enabled),
			new HudModuleItem("Auto Implant", () => CerberusConfig.AutoImplant.Enabled),
			new HudModuleItem("Auto Deconstruct", () => CerberusConfig.AutoDeconstruct.Enabled),
			new HudModuleItem("Auto Cuff", () => CerberusConfig.AutoCuff.Enabled),
			new HudModuleItem("Auto Door", () => CerberusConfig.AutoDoor.Enabled),
			new HudModuleItem("Nuke Bruteforce", () => CerberusConfig.NukeBruteforce.Enabled),
			new HudModuleItem("FullBright", () => CerberusConfig.Eye.FullBrightEnabled),
			new HudModuleItem("FOV Changer", () => CerberusConfig.Eye.FovEnabled),
			new HudModuleItem("Trash Talk", () => CerberusConfig.Misc.TrashTalkEnabled),
			new HudModuleItem("Damage Numbers", () => CerberusConfig.Misc.DamageOverlayEnabled),
			new HudModuleItem("Anti Soap", () => CerberusConfig.Misc.AntiSoapEnabled),
			new HudModuleItem("Anti-AFK", () => CerberusConfig.Misc.AntiAfkEnabled),
			new HudModuleItem("Spinbot", () => CerberusConfig.Misc.AntiAimEnabled),
			new HudModuleItem("Auto Peek", () => CerberusConfig.Misc.AutoPeekEnabled),
			new HudModuleItem("Fun Mode", () => CerberusConfig.Fun.Enabled),
			new HudModuleItem("Light Smooth", () => CerberusConfig.LightSmooth.Enabled),
			new HudModuleItem("Ambient Light", () => CerberusConfig.AmbientLight.Enabled),
			new HudModuleItem("Light Enhancement", () => CerberusConfig.LightEnhancement.Enabled)
		};
	}

	public HudRenderer()
	{
		DamageableHelper.Initialize();
		EnsureThresholdsInitialized();
		InitializeModulesList();
	}

	private static void EnsureThresholdsInitialized()
	{
		if (!bool_3)
		{
			bool_3 = true;
			try
			{
				fieldInfo_0 = AccessTools.Field(typeof(MobThresholdsComponent), "_thresholds");
			}
			catch (Exception)
			{
			}
		}
	}

	public static void ForcePositionUpdate()
	{
		bool_2 = true;
		int_0 = 10;
	}

	private void DrawArrayList()
	{
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0815: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0871: Unknown result type (might be due to invalid IL or missing references)
		//IL_0878: Unknown result type (might be due to invalid IL or missing references)
		//IL_0879: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		if (list_3 == null)
		{
			InitializeModulesList();
		}
		HashSet<string> hashSet = new HashSet<string>();
		foreach (HudModuleItem item in list_3)
		{
			if (item.XZEN8jy750())
			{
				hashSet.Add(item.T0mNPik8N5);
			}
		}
		ImGuiIOPtr iO = ImGui.GetIO();
		float deltaTime = ((ImGuiIOPtr)(ref iO)).DeltaTime;
		float num = 5f;
		foreach (string q8r0ev49rS in hashSet)
		{
			if (!dictionary_0.ContainsKey(q8r0ev49rS))
			{
				HudModuleItem value = list_3.First((HudModuleItem m) => m.T0mNPik8N5 == q8r0ev49rS);
				value.qmqN3C7rJH = 0f;
				dictionary_0[q8r0ev49rS] = value;
			}
		}
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, HudModuleItem> item2 in dictionary_0.ToList())
		{
			HudModuleItem value2 = item2.Value;
			if (hashSet.Contains(item2.Key))
			{
				value2.qmqN3C7rJH = Math.Min(1f, value2.qmqN3C7rJH + deltaTime * num);
			}
			else
			{
				value2.qmqN3C7rJH = Math.Max(0f, value2.qmqN3C7rJH - deltaTime * num);
				if (value2.qmqN3C7rJH <= 0f)
				{
					list.Add(item2.Key);
					continue;
				}
			}
			dictionary_0[item2.Key] = value2;
		}
		foreach (string item3 in list)
		{
			dictionary_0.Remove(item3);
		}
		List<HudModuleItem> list2 = dictionary_0.Values.Where((HudModuleItem m) => m.qmqN3C7rJH > 0f).ToList();
		list2.Sort(delegate(HudModuleItem a, HudModuleItem b)
		{
			float x2 = ImGui.CalcTextSize(a.T0mNPik8N5).X;
			float x3 = ImGui.CalcTextSize(b.T0mNPik8N5).X;
			return x3.CompareTo(x2);
		});
		if (list2.Count == 0 && !CerberusConfig.HudOverlay.EditMode)
		{
			return;
		}
		ImGuiIOPtr iO2 = ImGui.GetIO();
		float x = ((ImGuiIOPtr)(ref iO2)).DisplaySize.X;
		Vector2 arrayListPos = CerberusConfig.HudOverlay.ArrayListPos;
		bool flag = arrayListPos.X > x / 2f;
		ImGuiWindowFlags val = (ImGuiWindowFlags)201155;
		if (CerberusConfig.HudOverlay.EditMode)
		{
			if (bool_2)
			{
				ImGui.SetNextWindowPos(arrayListPos, (ImGuiCond)1);
			}
			else
			{
				ImGui.SetNextWindowPos(arrayListPos, (ImGuiCond)8);
			}
		}
		else
		{
			val = (ImGuiWindowFlags)(val | 0x30204);
			ImGui.SetNextWindowPos(arrayListPos, (ImGuiCond)1);
		}
		if (ImGui.Begin("##ArrayList", val))
		{
			ImDrawListPtr windowDrawList = ImGui.GetWindowDrawList();
			Vector2 windowPos = ImGui.GetWindowPos();
			Vector2 cursorScreenPos = ImGui.GetCursorScreenPos();
			float textLineHeightWithSpacing = ImGui.GetTextLineHeightWithSpacing();
			float num2 = 8f;
			float num3 = 2f;
			float auS0wxaZI8 = textLineHeightWithSpacing + num3 * 2f;
			float SJG0iWfZZK = 2f;
			ImGui.GetColorU32(vector4_2);
			float num4 = 100f;
			if (list2.Count > 0)
			{
				num4 = list2.Max((HudModuleItem m) => ImGui.CalcTextSize(m.T0mNPik8N5).X) + num2 * 2f + 10f;
			}
			if (list2.Count == 0 && CerberusConfig.HudOverlay.EditMode)
			{
				ImGui.Text("ArrayList (Empty)");
				CerberusConfig.HudOverlay.ArrayListPos = windowPos;
				ImGui.End();
				return;
			}
			float num5 = cursorScreenPos.Y;
			for (int num6 = 0; num6 < list2.Count; num6++)
			{
				HudModuleItem value3 = list2[num6];
				value3.A6INM46xvQ = num5;
				if (value3.NxQNfFyHVE == 0f)
				{
					value3.NxQNfFyHVE = value3.A6INM46xvQ;
				}
				float num7 = 15f * deltaTime;
				value3.NxQNfFyHVE += (value3.A6INM46xvQ - value3.NxQNfFyHVE) * num7;
				list2[num6] = value3;
				num5 += (auS0wxaZI8 + SJG0iWfZZK) * value3.qmqN3C7rJH;
			}
			for (int num8 = 0; num8 < list2.Count; num8++)
			{
				HudModuleItem hudModuleItem = list2[num8];
				string t0mNPik8N = hudModuleItem.T0mNPik8N5;
				Vector2 vector = ImGui.CalcTextSize(t0mNPik8N);
				float qmqN3C7rJH = hudModuleItem.qmqN3C7rJH;
				Vector4 vector2 = (CerberusConfig.HudOverlay.ArrayListRainbow ? GetRainbowColor(0.5f, (float)num8 * -0.1f) : vector4_0);
				vector2.W *= qmqN3C7rJH;
				float num9 = 0f;
				if (flag)
				{
					num9 = num4 - (vector.X + num2 * 2f);
				}
				float num10 = ((!flag) ? ((0f - (1f - qmqN3C7rJH)) * 20f) : ((1f - qmqN3C7rJH) * 20f));
				Vector2 vector3 = new Vector2(cursorScreenPos.X + num9 + num10, hudModuleItem.NxQNfFyHVE);
				Vector2 vector4 = new Vector2(vector3.X + vector.X + num2 * 2f, vector3.Y + auS0wxaZI8);
				Vector4 vector5 = vector4_2;
				vector5.W *= qmqN3C7rJH;
				uint colorU = ImGui.GetColorU32(vector5);
				((ImDrawListPtr)(ref windowDrawList)).AddRectFilled(vector3, vector4, colorU, 4f);
				Vector4 vector6 = vector4_3;
				vector6.W *= qmqN3C7rJH;
				((ImDrawListPtr)(ref windowDrawList)).AddRect(vector3, vector4, ImGui.GetColorU32(vector6), 4f);
				Vector4 vector7 = vector2;
				Vector4 vector8 = vector4_1;
				vector8.W *= qmqN3C7rJH;
				uint colorU2 = ImGui.GetColorU32(vector7);
				uint colorU3 = ImGui.GetColorU32(vector8);
				if (!flag)
				{
					((ImDrawListPtr)(ref windowDrawList)).AddRectFilledMultiColor(new Vector2(vector3.X, vector3.Y), new Vector2(vector3.X + 2f, vector4.Y), colorU2, colorU2, colorU3, colorU3);
				}
				else
				{
					((ImDrawListPtr)(ref windowDrawList)).AddRectFilledMultiColor(new Vector2(vector4.X - 2f, vector3.Y), new Vector2(vector4.X, vector4.Y), colorU2, colorU2, colorU3, colorU3);
				}
				Vector2 vector9 = new Vector2(vector3.X + num2, vector3.Y + num3);
				Vector4 vector10 = new Vector4(0f, 0f, 0f, qmqN3C7rJH);
				((ImDrawListPtr)(ref windowDrawList)).AddText(vector9 + new Vector2(1f, 1f), ImGui.GetColorU32(vector10), t0mNPik8N);
				Vector4 vector11 = new Vector4(1f, 1f, 1f, qmqN3C7rJH);
				((ImDrawListPtr)(ref windowDrawList)).AddText(vector9, ImGui.GetColorU32(vector11), t0mNPik8N);
			}
			float y = ((list2.Count <= 0) ? 0f : list2.Sum((HudModuleItem m) => (auS0wxaZI8 + SJG0iWfZZK) * m.qmqN3C7rJH));
			ImGui.Dummy(new Vector2(num4, y));
			if (CerberusConfig.HudOverlay.EditMode)
			{
				Vector2 windowPos2 = ImGui.GetWindowPos();
				if (windowPos2 != CerberusConfig.HudOverlay.ArrayListPos)
				{
					CerberusConfig.HudOverlay.ArrayListPos = windowPos2;
				}
				Vector2 vector12 = windowPos;
				Vector2 vector13 = vector12 + ImGui.GetWindowSize();
				((ImDrawListPtr)(ref windowDrawList)).AddRect(vector12, vector13, 4278190335u);
			}
		}
		ImGui.End();
	}

	private void EnsureSystems()
	{
		if (bool_1)
		{
			return;
		}
		try
		{
			iplayerManager_0 = IoCManager.Resolve<IPlayerManager>();
			ientityManager_0 = IoCManager.Resolve<IEntityManager>();
			igameTiming_0 = IoCManager.Resolve<IGameTiming>();
			IClientNetManager val = IoCManager.Resolve<IClientNetManager>();
			if (val != null)
			{
				iclientNetManager_0 = val;
			}
			try
			{
				iclientConsoleHost_0 = IoCManager.Resolve<IClientConsoleHost>();
			}
			catch
			{
			}
			IEntitySystemManager val2 = IoCManager.Resolve<IEntitySystemManager>();
			if (val2 != null)
			{
				try
				{
					val2.TryGetEntitySystem<SpriteRenderQueue>(ref gclass40_0);
				}
				catch
				{
				}
			}
			if (iclientConsoleHost_0 != null && eventHandler_0 == null)
			{
				eventHandler_0 = delegate(object? _, AddStringArgs args)
				{
					HandleConsoleOutput(args);
				};
				iclientConsoleHost_0.AddString += eventHandler_0;
			}
			bool_1 = true;
		}
		catch
		{
			bool_1 = true;
		}
	}

	public unsafe void Render()
	{
		//IL_06e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_076d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0772: Unknown result type (might be due to invalid IL or missing references)
		//IL_079a: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Unknown result type (might be due to invalid IL or missing references)
		//IL_04dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		EnsureSystems();
		if (ientityManager_0 == null || iplayerManager_0 == null || !CerberusConfig.HudOverlay.Enabled)
		{
			return;
		}
		if (bool_2 && int_0 > 0)
		{
			int_0--;
			if (int_0 <= 0)
			{
				bool_2 = false;
			}
		}
		ImGuiIOPtr iO = ImGui.GetIO();
		float deltaTime = ((ImGuiIOPtr)(ref iO)).DeltaTime;
		float_0 += deltaTime;
		float_1 += deltaTime;
		float_2 += deltaTime;
		float_3 += deltaTime;
		float_4 += deltaTime;
		float_5 += deltaTime;
		float_6 += deltaTime;
		ImFontPtr font = ImGuiFontManager.GetFont("global-small");
		bool flag = false;
		if (font.Handle == null)
		{
			ImGui.SetWindowFontScale(2f);
		}
		else
		{
			ImGui.PushFont(font);
			flag = true;
		}
		try
		{
			if (CerberusConfig.HudOverlay.ShowWatermark)
			{
				DrawStyledModule("Watermark", "KABAN", "CC", ref CerberusConfig.HudOverlay.WatermarkPos, isLogo: true);
			}
			if (CerberusConfig.HudOverlay.ShowFps)
			{
				iO = ImGui.GetIO();
				float framerate = ((ImGuiIOPtr)(ref iO)).Framerate;
				Vector4 value = ((framerate <= 50f) ? ((!(framerate <= 30f)) ? new Vector4(1f, 1f, 0f, 1f) : new Vector4(1f, 0f, 0f, 1f)) : new Vector4(0f, 1f, 0f, 1f));
				DrawStyledModule("FPS", "FPS", $"{framerate:F0}", ref CerberusConfig.HudOverlay.FpsPos, isLogo: false, value);
			}
			LocalPlayer localPlayer = iplayerManager_0.LocalPlayer;
			EntityUid? val = ((localPlayer == null) ? ((EntityUid?)null) : localPlayer.ControlledEntity);
			if (val.HasValue)
			{
				if (CerberusConfig.HudOverlay.ShowCoords)
				{
					if (float_0 >= 0.1f)
					{
						float_0 = 0f;
						TransformComponent val2 = default(TransformComponent);
						if (ientityManager_0.TryGetComponent<TransformComponent>(val.Value, ref val2))
						{
							MapCoordinates mapPosition = val2.MapPosition;
							vector2_0 = new Vector2(((MapCoordinates)(ref mapPosition)).X, ((MapCoordinates)(ref mapPosition)).Y);
							string_0 = $"{((MapCoordinates)(ref mapPosition)).X:F0}, {((MapCoordinates)(ref mapPosition)).Y:F0}";
							try
							{
								if (!bool_4)
								{
									try
									{
										ServerInfo gameInfo = IoCManager.Resolve<IBaseClient>().GameInfo;
										object obj;
										if (gameInfo != null)
										{
											obj = gameInfo.ServerName;
											if (obj != null)
											{
												goto IL_0462;
											}
										}
										else
										{
											obj = null;
										}
										obj = "Unknown";
										goto IL_0462;
										IL_0462:
										string_1 = (string)obj;
									}
									catch
									{
										string_1 = "Unknown";
									}
									bool_4 = true;
								}
								WinFormsMenuWindow.Instance?.UpdateGameData(vector2_0.X, vector2_0.Y, string_1);
							}
							catch
							{
							}
						}
					}
					DrawStyledModule("Coords", "POS", string_0, ref CerberusConfig.HudOverlay.CoordsPos);
				}
				if (CerberusConfig.HudOverlay.ShowSpeed)
				{
					if (float_1 >= 0.05f)
					{
						float_1 = 0f;
						PhysicsComponent val3 = default(PhysicsComponent);
						if (ientityManager_0.TryGetComponent<PhysicsComponent>(val.Value, ref val3))
						{
							float value2 = val3.LinearVelocity.Length();
							string_2 = $"{value2:F1} m/s";
						}
					}
					DrawStyledModule("Speed", "SPD", string_2, ref CerberusConfig.HudOverlay.SpeedPos);
				}
			}
			if (CerberusConfig.HudOverlay.ShowPing && iclientNetManager_0 != null)
			{
				if (!(float_2 < 0.2f))
				{
					float_2 = 0f;
					INetChannel serverChannel = iclientNetManager_0.ServerChannel;
					short_0 = (short)((serverChannel != null) ? serverChannel.Ping : 0);
					string_3 = $"{short_0} ms";
				}
				Vector4 value3 = ((short_0 >= 100) ? new Vector4(1f, 0f, 0f, 1f) : new Vector4(0f, 1f, 0f, 1f));
				DrawStyledModule("Ping", "PING", string_3, ref CerberusConfig.HudOverlay.PingPos, isLogo: false, value3);
			}
			if (CerberusConfig.HudOverlay.ShowRoundTime && igameTiming_0 != null)
			{
				TimeSpan curTime = igameTiming_0.CurTime;
				DrawStyledModule("Time", "TIME", $"{curTime.Hours:D2}:{curTime.Minutes:D2}:{curTime.Seconds:D2}", ref CerberusConfig.HudOverlay.RoundTimePos);
			}
			if (CerberusConfig.HudOverlay.ShowTargetInfo)
			{
				DrawTargetInfo();
			}
			if (CerberusConfig.HudOverlay.ShowArrayList)
			{
				DrawArrayList();
			}
			if (CerberusConfig.HudOverlay.ShowStaffList)
			{
				MaybeRequestStaffList();
				DrawStaffList();
			}
			if (CerberusConfig.HudOverlay.ShowCompass && val.HasValue)
			{
				DrawCompass(val.Value);
			}
			if (CerberusConfig.HudOverlay.ShowSessionTimer)
			{
				DrawSessionTimer();
			}
			if (CerberusConfig.HudOverlay.ShowKillCounter)
			{
				DrawKillCounter();
			}
			if (CerberusConfig.HudOverlay.ShowVelocityMeter && val.HasValue)
			{
				DrawVelocityMeter(val.Value);
			}
			if (CerberusConfig.HudOverlay.ShowServerInfo)
			{
				DrawServerInfo();
			}
			if (CerberusConfig.HudOverlay.ShowKeybinds)
			{
				DrawKeybinds();
			}
			if (CerberusConfig.HudOverlay.ShowSpectatorList)
			{
				DrawSpectatorList();
			}
			if (CerberusConfig.HudOverlay.ShowDamageCounter)
			{
				DrawDamageCounter();
			}
			if (CerberusConfig.HudOverlay.ShowMovementKeys && val.HasValue)
			{
				DrawMovementKeys(val.Value);
			}
			if (CerberusConfig.HudOverlay.ShowCPS)
			{
				DrawCPS();
			}
			if (CerberusConfig.HudOverlay.ShowShuttleTracker)
			{
				DrawShuttleTracker();
			}
			if (CerberusConfig.HudOverlay.ShowConnectionQuality)
			{
				DrawConnectionQuality();
			}
		}
		catch
		{
		}
		finally
		{
			if (flag)
			{
				ImGui.PopFont();
			}
			else
			{
				ImGui.SetWindowFontScale(1f);
			}
		}
		if (CerberusConfig.HudOverlay.ShowCrosshair)
		{
			DrawCrosshair();
		}
	}

	private void DrawStyledModule(string id, string label, string value, ref Vector2 position, bool isLogo = false, Vector4? valueColor = null)
	{
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		ImGuiWindowFlags val = (ImGuiWindowFlags)201155;
		ImGuiCond val2;
		if (CerberusConfig.HudOverlay.EditMode)
		{
			if (bool_2)
			{
				val2 = (ImGuiCond)1;
				if (int_0 != 10)
				{
				}
			}
			else
			{
				val2 = (ImGuiCond)8;
			}
		}
		else
		{
			val = (ImGuiWindowFlags)(val | 0x30204);
			val2 = (ImGuiCond)1;
		}
		ImGui.SetNextWindowPos(position, val2);
		if (ImGui.Begin("##Hud_" + id, val))
		{
			ImDrawListPtr windowDrawList = ImGui.GetWindowDrawList();
			Vector2 cursorScreenPos = ImGui.GetCursorScreenPos();
			string text = ((!isLogo) ? (label + " |") : label);
			Vector2 vector = ImGui.CalcTextSize(text);
			Vector2 vector2 = ImGui.CalcTextSize(value);
			float x = 10f;
			float y = 4f;
			float num = 6f;
			Vector2 vector3 = new Vector2(vector.X + num + vector2.X + 20f, Math.Max(vector.Y, vector2.Y) + 8f);
			Vector2 vector4 = cursorScreenPos;
			Vector2 vector5 = cursorScreenPos + vector3;
			uint colorU = ImGui.GetColorU32(vector4_2);
			((ImDrawListPtr)(ref windowDrawList)).AddRectFilled(vector4, vector5, colorU, 12f);
			((ImDrawListPtr)(ref windowDrawList)).AddRect(vector4, vector5, ImGui.GetColorU32(vector4_3), 12f);
			Vector2 vector6 = cursorScreenPos + new Vector2(x, y);
			if (isLogo)
			{
				((ImDrawListPtr)(ref windowDrawList)).AddText(vector6, ImGui.GetColorU32(vector4_0), text);
			}
			else
			{
				((ImDrawListPtr)(ref windowDrawList)).AddText(vector6, 4289374890u, text);
			}
			Vector2 vector7 = vector6 + new Vector2(vector.X + num, 0f);
			uint num2 = (valueColor.HasValue ? ImGui.GetColorU32(valueColor.Value) : uint.MaxValue);
			((ImDrawListPtr)(ref windowDrawList)).AddText(vector7, num2, value);
			ImGui.Dummy(vector3);
			if (CerberusConfig.HudOverlay.EditMode)
			{
				Vector2 windowPos = ImGui.GetWindowPos();
				if (windowPos != position)
				{
					position = windowPos;
				}
				((ImDrawListPtr)(ref windowDrawList)).AddRect(vector4, vector5, 4278190335u, 12f, (ImDrawFlags)0, 2f);
			}
		}
		ImGui.End();
	}

	private void DrawTargetInfo()
	{
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		EntityUid? currentTarget = CerberusConfig.HudOverlay.CurrentTarget;
		TimeSpan curTime = igameTiming_0.CurTime;
		EntityUid? val = null;
		if (currentTarget.HasValue && ientityManager_0.EntityExists(currentTarget.Value))
		{
			nullable_0 = currentTarget;
			val = currentTarget;
			timeSpan_0 = curTime;
		}
		else if (nullable_0.HasValue && (curTime - timeSpan_0).TotalSeconds < 3.0 && ientityManager_0.EntityExists(nullable_0.Value))
		{
			val = nullable_0;
		}
		if (val.HasValue)
		{
			EntityUid value = val.Value;
			string name = "Unknown";
			MetaDataComponent val2 = default(MetaDataComponent);
			if (ientityManager_0.TryGetComponent<MetaDataComponent>(value, ref val2))
			{
				name = val2.EntityName;
			}
			string ckey = "";
			ICommonSession[] sessions = ((ISharedPlayerManager)iplayerManager_0).Sessions;
			foreach (ICommonSession val3 in sessions)
			{
				EntityUid? attachedEntity = val3.AttachedEntity;
				EntityUid val4 = value;
				if (attachedEntity.HasValue && attachedEntity.GetValueOrDefault() == val4)
				{
					ckey = val3.Name;
					break;
				}
			}
			float dist = 0f;
			LocalPlayer localPlayer = iplayerManager_0.LocalPlayer;
			if (localPlayer != null)
			{
				MapCoordinates mapPosition = ientityManager_0.GetComponent<TransformComponent>(localPlayer.ControlledEntity.Value).MapPosition;
				MapCoordinates mapPosition2 = ientityManager_0.GetComponent<TransformComponent>(value).MapPosition;
				if (mapPosition.MapId == mapPosition2.MapId)
				{
					dist = (mapPosition.Position - mapPosition2.Position).Length();
				}
			}
			float hpRatio = 1f;
			MobStateComponent comp = default(MobStateComponent);
			if (ientityManager_0.TryGetComponent<MobStateComponent>(value, ref comp) && DamageableHelper.TryGetDamageableComponent(value, ientityManager_0, out object component) && component != null)
			{
				MobThresholdsComponent thresholds = default(MobThresholdsComponent);
				ientityManager_0.TryGetComponent<MobThresholdsComponent>(value, ref thresholds);
				(float, float, float)? tuple = CalcHealth(value, comp, component, thresholds);
				if (tuple.HasValue)
				{
					hpRatio = tuple.Value.Item1;
				}
			}
			Vector2 position = CerberusConfig.HudOverlay.TargetInfoPos;
			DrawTargetCard(value, name, ckey, dist, hpRatio, ref position, CerberusConfig.HudOverlay.EditMode);
			CerberusConfig.HudOverlay.TargetInfoPos = position;
		}
		else if (CerberusConfig.HudOverlay.EditMode)
		{
			Vector2 position2 = CerberusConfig.HudOverlay.TargetInfoPos;
			DrawTargetCard(EntityUid.Invalid, "Target Name", "Unknown", 10.5f, 0.75f, ref position2, isEditing: true);
			CerberusConfig.HudOverlay.TargetInfoPos = position2;
		}
	}

	private void DrawTargetCard(EntityUid uid, string name, string ckey, float dist, float hpRatio, ref Vector2 position, bool isEditing)
	{
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		ImGuiWindowFlags val = (ImGuiWindowFlags)197059;
		if (isEditing)
		{
			if (bool_2)
			{
				ImGui.SetNextWindowPos(position, (ImGuiCond)1);
			}
			else
			{
				ImGui.SetNextWindowPos(position, (ImGuiCond)8);
			}
		}
		else
		{
			val = (ImGuiWindowFlags)(val | 0x30204);
			ImGui.SetNextWindowPos(position, (ImGuiCond)1);
		}
		if (ImGui.Begin("##TargetInfoCard", val))
		{
			ImDrawListPtr windowDrawList = ImGui.GetWindowDrawList();
			Vector2 cursorScreenPos = ImGui.GetCursorScreenPos();
			float num = 220f;
			float num2 = 85f;
			float num3 = 10f;
			Vector2 vector = cursorScreenPos;
			Vector2 vector2 = cursorScreenPos + new Vector2(num, num2);
			uint colorU = ImGui.GetColorU32(vector4_2);
			((ImDrawListPtr)(ref windowDrawList)).AddRectFilled(vector, vector2, colorU, 16f);
			((ImDrawListPtr)(ref windowDrawList)).AddRect(vector, vector2, ImGui.GetColorU32(vector4_3), 16f);
			float num4 = 50f;
			Vector2 vector3 = cursorScreenPos + new Vector2(num3, (num2 - num4) / 2f);
			((ImDrawListPtr)(ref windowDrawList)).AddCircleFilled(vector3 + new Vector2(num4 / 2f, num4 / 2f), num4 / 2f + 2f, ImGui.GetColorU32(vector4_1), 0);
			((ImDrawListPtr)(ref windowDrawList)).AddCircleFilled(vector3 + new Vector2(num4 / 2f, num4 / 2f), num4 / 2f, 4278190080u, 0);
			if (uid != EntityUid.Invalid && gclass40_0 != null)
			{
				try
				{
					gclass40_0.RenderSpriteAsync(uid, (Direction)0);
					ImTextureID imGuiTexture = gclass40_0.GetImGuiTexture(uid);
					if (((ImTextureID)(ref imGuiTexture)).Handle != (ulong)IntPtr.Zero)
					{
						ImGui.SetCursorPos(new Vector2(num3, (num2 - num4) / 2f));
						ImGui.Image(imGuiTexture, new Vector2(num4, num4));
					}
				}
				catch
				{
				}
			}
			float num5 = num4 + num3 * 2f;
			float num6 = num3;
			((ImDrawListPtr)(ref windowDrawList)).AddText(cursorScreenPos + new Vector2(num5, num6), uint.MaxValue, name);
			num6 += 16f;
			if (!string.IsNullOrEmpty(ckey))
			{
				((ImDrawListPtr)(ref windowDrawList)).AddText(cursorScreenPos + new Vector2(num5, num6), 4291611852u, ckey);
				num6 += 16f;
			}
			((ImDrawListPtr)(ref windowDrawList)).AddText(cursorScreenPos + new Vector2(num5, num6), 4289374890u, $"{dist:F1}m");
			float num7 = num - num5 - num3;
			float num8 = 5f;
			Vector2 vector4 = cursorScreenPos + new Vector2(num5, num2 - num3 - num8);
			((ImDrawListPtr)(ref windowDrawList)).AddRectFilled(vector4, vector4 + new Vector2(num7, num8), 4280427042u, 2.5f);
			Vector4 vector5 = ((hpRatio <= 0.5f) ? new Vector4(1f, 0f, 0f, 1f) : new Vector4(0f, 1f, 0f, 1f));
			Vector4 vector6 = ((hpRatio <= 0.5f) ? new Vector4(0.8f, 0f, 0f, 1f) : new Vector4(0f, 0.8f, 0.2f, 1f));
			float num9 = num7 * hpRatio;
			if (num9 > 0f)
			{
				((ImDrawListPtr)(ref windowDrawList)).AddRectFilledMultiColor(vector4, vector4 + new Vector2(num9, num8), ImGui.GetColorU32(vector5), ImGui.GetColorU32(vector6), ImGui.GetColorU32(vector6), ImGui.GetColorU32(vector5));
			}
			ImGui.Dummy(new Vector2(num, num2));
			if (isEditing)
			{
				Vector2 windowPos = ImGui.GetWindowPos();
				if (windowPos != position)
				{
					position = windowPos;
				}
			}
		}
		ImGui.End();
	}

	private (float ratio, float damage, float max)? CalcHealth(EntityUid uid, MobStateComponent comp, object damageableComp, MobThresholdsComponent thresholds)
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Invalid comparison between Unknown and I4
		//IL_00b6: Invalid comparison between Unknown and I4
		if (damageableComp == null)
		{
			return null;
		}
		float totalDamage = DamageableHelper.GetTotalDamage(damageableComp);
		float num = 0f;
		float num2 = 0f;
		if (thresholds != null && fieldInfo_0 != null)
		{
			try
			{
				if (fieldInfo_0.GetValue(thresholds) is IDictionary dictionary)
				{
					foreach (DictionaryEntry item in dictionary)
					{
						MobState val = (MobState)item.Value;
						float num3 = NumericValue.FromObject(item.Key).ToFloat();
						if ((int)val == 2)
						{
							num = num3;
						}
						if ((int)val == 3)
						{
							num2 = num3;
						}
					}
				}
			}
			catch
			{
			}
		}
		if (!(num2 > 0.1f))
		{
			num2 = 100f;
		}
		if (!(num > 0.1f))
		{
			num = num2;
		}
		float num4 = ((num <= 0.1f) ? 100f : num);
		return (Math.Clamp(1f - totalDamage / num4, 0f, 1f), totalDamage, num4);
	}

	private void MaybeRequestStaffList()
	{
		if (iclientConsoleHost_0 == null || !CerberusConfig.HudOverlay.ShowStaffList)
		{
			return;
		}
		DateTime utcNow = DateTime.UtcNow;
		if (bool_0 && (utcNow - dateTime_0).TotalSeconds > 5.0)
		{
			bool_0 = false;
		}
		if (bool_0 || !((utcNow - dateTime_0).TotalSeconds > (double)CerberusConfig.HudOverlay.StaffListRefreshSeconds))
		{
			return;
		}
		bool_0 = true;
		dateTime_0 = utcNow;
		list_0.Clear();
		try
		{
			((IConsoleHost)iclientConsoleHost_0).ExecuteCommand((ICommonSession)null, "adminwho");
		}
		catch
		{
			bool_0 = false;
		}
	}

	private void HandleConsoleOutput(AddStringArgs args)
	{
		if (!bool_0)
		{
			return;
		}
		string text = ((object)args.Text).ToString();
		if (string.IsNullOrWhiteSpace(text) || text.Trim().StartsWith("> adminwho", StringComparison.OrdinalIgnoreCase) || text.Trim().StartsWith(">", StringComparison.OrdinalIgnoreCase))
		{
			return;
		}
		if (!text.Contains("Administrators:") && !text.Contains("No administrators") && !text.Contains("---"))
		{
			string text2 = text.Trim();
			if (!string.IsNullOrEmpty(text2) && !list_0.Contains(text2))
			{
				list_0.Add(text2);
			}
			if (string.IsNullOrWhiteSpace(text) && list_0.Count > 0)
			{
				bool_0 = false;
			}
		}
		else if (text.Contains("Administrators:"))
		{
			list_0.Clear();
		}
	}

	private void DrawStaffList()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0369: Unknown result type (might be due to invalid IL or missing references)
		//IL_036f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0370: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		ImGuiWindowFlags val = (ImGuiWindowFlags)197059;
		if (CerberusConfig.HudOverlay.EditMode)
		{
			if (bool_2)
			{
				ImGui.SetNextWindowPos(CerberusConfig.HudOverlay.StaffListPos, (ImGuiCond)1);
			}
			else
			{
				ImGui.SetNextWindowPos(CerberusConfig.HudOverlay.StaffListPos, (ImGuiCond)8);
			}
		}
		else
		{
			val = (ImGuiWindowFlags)(val | 0x30204);
			ImGui.SetNextWindowPos(CerberusConfig.HudOverlay.StaffListPos, (ImGuiCond)1);
		}
		if (ImGui.Begin("##StaffListWidget", val))
		{
			ImDrawListPtr windowDrawList = ImGui.GetWindowDrawList();
			Vector2 cursorScreenPos = ImGui.GetCursorScreenPos();
			string text = $"Staff Online ({list_0.Count})";
			float num = 8f;
			float textLineHeightWithSpacing = ImGui.GetTextLineHeightWithSpacing();
			float num2 = 200f;
			int num3 = ((list_0.Count <= 0) ? 1 : list_0.Count);
			if (num3 > 10)
			{
				num3 = 10;
			}
			float num4 = (float)num3 * textLineHeightWithSpacing;
			float y = textLineHeightWithSpacing + num * 2f + num4 + 4f;
			Vector2 vector = cursorScreenPos;
			Vector2 vector2 = cursorScreenPos + new Vector2(num2, y);
			((ImDrawListPtr)(ref windowDrawList)).AddRectFilled(vector, vector2, ImGui.GetColorU32(vector4_2), 10f);
			((ImDrawListPtr)(ref windowDrawList)).AddRect(vector, vector2, ImGui.GetColorU32(vector4_3), 10f);
			((ImDrawListPtr)(ref windowDrawList)).AddText(cursorScreenPos + new Vector2(num, num), ImGui.GetColorU32(vector4_0), text);
			float num5 = cursorScreenPos.Y + num + textLineHeightWithSpacing;
			((ImDrawListPtr)(ref windowDrawList)).AddLine(new Vector2(cursorScreenPos.X + num, num5), new Vector2(cursorScreenPos.X + num2 - num, num5), ImGui.GetColorU32(vector4_3));
			float num6 = num5 + 4f;
			((ImDrawListPtr)(ref windowDrawList)).PushClipRect(vector, vector2);
			if (list_0.Count != 0)
			{
				for (int i = 0; i < num3; i++)
				{
					string text2 = list_0[i];
					((ImDrawListPtr)(ref windowDrawList)).AddText(new Vector2(cursorScreenPos.X + num, num6), uint.MaxValue, text2);
					num6 += textLineHeightWithSpacing;
				}
				if (list_0.Count > 10)
				{
					((ImDrawListPtr)(ref windowDrawList)).AddText(new Vector2(cursorScreenPos.X + num, num6 - textLineHeightWithSpacing), 4287137928u, $"... and {list_0.Count - 9} more");
				}
			}
			else
			{
				((ImDrawListPtr)(ref windowDrawList)).AddText(new Vector2(cursorScreenPos.X + num, num6), 4287137928u, "Fetching...");
			}
			((ImDrawListPtr)(ref windowDrawList)).PopClipRect();
			ImGui.Dummy(new Vector2(num2, y));
			if (CerberusConfig.HudOverlay.EditMode)
			{
				Vector2 windowPos = ImGui.GetWindowPos();
				if (windowPos != CerberusConfig.HudOverlay.StaffListPos)
				{
					CerberusConfig.HudOverlay.StaffListPos = windowPos;
				}
				((ImDrawListPtr)(ref windowDrawList)).AddRect(vector, vector2, 4278255615u);
			}
		}
		ImGui.End();
	}

	private void DrawCompass(EntityUid playerEntity)
	{
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		TransformComponent val = default(TransformComponent);
		if (!ientityManager_0.TryGetComponent<TransformComponent>(playerEntity, ref val))
		{
			return;
		}
		Angle localRotation = val.LocalRotation;
		float num;
		for (num = (float)(localRotation.Theta * 180.0 / Math.PI); !(num >= 0f); num += 360f)
		{
		}
		while (!(num < 360f))
		{
			num -= 360f;
		}
		string text = "N";
		if (!(num < 337.5f) || num < 22.5f)
		{
			text = "N";
		}
		else if (!(num >= 22.5f) || !(num < 67.5f))
		{
			if (num < 67.5f || !(num < 112.5f))
			{
				if (!(num < 112.5f) && num < 157.5f)
				{
					text = "SE";
				}
				else if (!(num >= 157.5f) || num >= 202.5f)
				{
					if (num < 202.5f || !(num < 247.5f))
					{
						if (num < 247.5f || !(num < 292.5f))
						{
							if (num >= 292.5f && num < 337.5f)
							{
								text = "NW";
							}
						}
						else
						{
							text = "W";
						}
					}
					else
					{
						text = "SW";
					}
				}
				else
				{
					text = "S";
				}
			}
			else
			{
				text = "E";
			}
		}
		else
		{
			text = "NE";
		}
		ImGuiWindowFlags val2 = (ImGuiWindowFlags)201155;
		if (CerberusConfig.HudOverlay.EditMode)
		{
			if (bool_2)
			{
				ImGui.SetNextWindowPos(CerberusConfig.HudOverlay.CompassPos, (ImGuiCond)1);
			}
			else
			{
				ImGui.SetNextWindowPos(CerberusConfig.HudOverlay.CompassPos, (ImGuiCond)8);
			}
		}
		else
		{
			val2 = (ImGuiWindowFlags)(val2 | 0x30204);
			ImGui.SetNextWindowPos(CerberusConfig.HudOverlay.CompassPos, (ImGuiCond)1);
		}
		if (ImGui.Begin("##Compass", val2))
		{
			ImDrawListPtr windowDrawList = ImGui.GetWindowDrawList();
			Vector2 cursorScreenPos = ImGui.GetCursorScreenPos();
			float num2 = 60f;
			float num3 = cursorScreenPos.X + 30f;
			float num4 = cursorScreenPos.Y + 30f;
			Vector2 vector = new Vector2(num3, num4);
			((ImDrawListPtr)(ref windowDrawList)).AddCircleFilled(vector, num2 / 2f, ImGui.GetColorU32(vector4_2), 32);
			((ImDrawListPtr)(ref windowDrawList)).AddCircle(vector, num2 / 2f, ImGui.GetColorU32(vector4_3), 32, 2f);
			float x = (float)localRotation.Theta;
			Vector2 vector2 = vector + new Vector2(MathF.Cos(x) * (num2 / 2f - 10f), MathF.Sin(x) * (num2 / 2f - 10f));
			((ImDrawListPtr)(ref windowDrawList)).AddLine(vector, vector2, ImGui.GetColorU32(vector4_0), 3f);
			((ImDrawListPtr)(ref windowDrawList)).AddCircleFilled(vector2, 4f, ImGui.GetColorU32(vector4_1));
			Vector2 vector3 = new Vector2(num3 - ImGui.CalcTextSize(text).X / 2f, num4 + num2 / 2f + 5f);
			((ImDrawListPtr)(ref windowDrawList)).AddText(vector3, uint.MaxValue, text);
			ImGui.Dummy(new Vector2(num2, num2 + 20f));
			if (CerberusConfig.HudOverlay.EditMode)
			{
				Vector2 windowPos = ImGui.GetWindowPos();
				if (windowPos != CerberusConfig.HudOverlay.CompassPos)
				{
					CerberusConfig.HudOverlay.CompassPos = windowPos;
				}
			}
		}
		ImGui.End();
	}

	private void DrawSessionTimer()
	{
		TimeSpan timeSpan = DateTime.UtcNow - CerberusConfig.HudOverlay.SessionStartTime;
		string value = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
		DrawStyledModule("SessionTimer", "SESSION", value, ref CerberusConfig.HudOverlay.SessionTimerPos);
	}

	private void DrawKillCounter()
	{
		string value = CerberusConfig.HudOverlay.SessionKills.ToString();
		Vector4 value2 = ((CerberusConfig.HudOverlay.SessionKills <= 0) ? new Vector4(0.5f, 0.5f, 0.5f, 1f) : new Vector4(1f, 0.2f, 0.2f, 1f));
		DrawStyledModule("KillCounter", "KILLS", value, ref CerberusConfig.HudOverlay.KillCounterPos, isLogo: false, value2);
	}

	private void DrawVelocityMeter(EntityUid playerEntity)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		PhysicsComponent val = default(PhysicsComponent);
		if (!ientityManager_0.TryGetComponent<PhysicsComponent>(playerEntity, ref val))
		{
			return;
		}
		float num = val.LinearVelocity.Length();
		float num2 = 10f;
		float num3 = Math.Clamp(num / num2, 0f, 1f);
		ImGuiWindowFlags val2 = (ImGuiWindowFlags)201155;
		if (CerberusConfig.HudOverlay.EditMode)
		{
			if (!bool_2)
			{
				ImGui.SetNextWindowPos(CerberusConfig.HudOverlay.VelocityMeterPos, (ImGuiCond)8);
			}
			else
			{
				ImGui.SetNextWindowPos(CerberusConfig.HudOverlay.VelocityMeterPos, (ImGuiCond)1);
			}
		}
		else
		{
			val2 = (ImGuiWindowFlags)(val2 | 0x30204);
			ImGui.SetNextWindowPos(CerberusConfig.HudOverlay.VelocityMeterPos, (ImGuiCond)1);
		}
		if (ImGui.Begin("##VelocityMeter", val2))
		{
			ImDrawListPtr windowDrawList = ImGui.GetWindowDrawList();
			Vector2 cursorScreenPos = ImGui.GetCursorScreenPos();
			float num4 = 10f;
			float textLineHeightWithSpacing = ImGui.GetTextLineHeightWithSpacing();
			string text = $"{num:F1} m/s";
			Vector2 vector = ImGui.CalcTextSize("VELOCITY");
			Vector2 vector2 = ImGui.CalcTextSize(text);
			float num5 = Math.Max(Math.Max(vector.X, vector2.X) + 20f, 150f);
			float num6 = 20f + textLineHeightWithSpacing * 2f + 8f;
			Vector2 vector3 = cursorScreenPos;
			Vector2 vector4 = cursorScreenPos + new Vector2(num5, num6);
			((ImDrawListPtr)(ref windowDrawList)).AddRectFilled(vector3, vector4, ImGui.GetColorU32(vector4_2), 12f);
			((ImDrawListPtr)(ref windowDrawList)).AddRect(vector3, vector4, ImGui.GetColorU32(vector4_3), 12f);
			((ImDrawListPtr)(ref windowDrawList)).PushClipRect(vector3, vector4);
			Vector2 vector5 = cursorScreenPos + new Vector2(num4, num4);
			((ImDrawListPtr)(ref windowDrawList)).AddText(vector5, 4289374890u, "VELOCITY");
			Vector2 vector6 = cursorScreenPos + new Vector2(num5 - num4 - vector2.X, num4);
			((ImDrawListPtr)(ref windowDrawList)).AddText(vector6, uint.MaxValue, text);
			float num7 = num5 - 20f;
			float num8 = 8f;
			Vector2 vector7 = cursorScreenPos + new Vector2(num4, num6 - num4 - num8);
			((ImDrawListPtr)(ref windowDrawList)).AddRectFilled(vector7, vector7 + new Vector2(num7, num8), 4280427042u, 4f);
			if (!(num3 <= 0f))
			{
				Vector4 vector8 = ((num3 >= 0.5f) ? new Vector4(1f, 1f, 0f, 1f) : new Vector4(0f, 1f, 0f, 1f));
				Vector4 vector9 = ((num3 >= 0.5f) ? new Vector4(1f, 0f, 0f, 1f) : new Vector4(0f, 0.8f, 0f, 1f));
				float x = num7 * num3;
				((ImDrawListPtr)(ref windowDrawList)).AddRectFilledMultiColor(vector7, vector7 + new Vector2(x, num8), ImGui.GetColorU32(vector8), ImGui.GetColorU32(vector9), ImGui.GetColorU32(vector9), ImGui.GetColorU32(vector8));
			}
			((ImDrawListPtr)(ref windowDrawList)).PopClipRect();
			ImGui.Dummy(new Vector2(num5, num6));
			if (CerberusConfig.HudOverlay.EditMode)
			{
				Vector2 windowPos = ImGui.GetWindowPos();
				if (windowPos != CerberusConfig.HudOverlay.VelocityMeterPos)
				{
					CerberusConfig.HudOverlay.VelocityMeterPos = windowPos;
				}
			}
		}
		ImGui.End();
	}

	private void DrawServerInfo()
	{
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		if (!(float_3 < 1f))
		{
			float_3 = 0f;
			if (!bool_4)
			{
				try
				{
					IBaseClient val = IoCManager.Resolve<IBaseClient>();
					ServerInfo gameInfo = val.GameInfo;
					object obj;
					if (gameInfo == null)
					{
						obj = null;
					}
					else
					{
						obj = gameInfo.ServerName;
						if (obj != null)
						{
							goto IL_036c;
						}
					}
					obj = "Unknown Server";
					goto IL_036c;
					IL_036c:
					string_1 = (string)obj;
				}
				catch
				{
					string_1 = "Unknown Server";
				}
				bool_4 = true;
			}
			IPlayerManager obj3 = iplayerManager_0;
			int_1 = ((obj3 != null) ? ((ISharedPlayerManager)obj3).PlayerCount : 0);
		}
		string text = $"SERVER | {string_1} | Players: {int_1}";
		ImGuiWindowFlags val2 = (ImGuiWindowFlags)201155;
		if (!CerberusConfig.HudOverlay.EditMode)
		{
			val2 = (ImGuiWindowFlags)(val2 | 0x30204);
			ImGui.SetNextWindowPos(CerberusConfig.HudOverlay.ServerInfoPos, (ImGuiCond)1);
		}
		else if (!bool_2)
		{
			ImGui.SetNextWindowPos(CerberusConfig.HudOverlay.ServerInfoPos, (ImGuiCond)8);
		}
		else
		{
			ImGui.SetNextWindowPos(CerberusConfig.HudOverlay.ServerInfoPos, (ImGuiCond)1);
		}
		if (ImGui.Begin("##ServerInfo", val2))
		{
			ImDrawListPtr windowDrawList = ImGui.GetWindowDrawList();
			Vector2 cursorScreenPos = ImGui.GetCursorScreenPos();
			float num = 10f;
			Vector2 vector = ImGui.CalcTextSize(text);
			float x = vector.X + 20f;
			float y = vector.Y + 20f;
			Vector2 vector2 = cursorScreenPos;
			Vector2 vector3 = cursorScreenPos + new Vector2(x, y);
			((ImDrawListPtr)(ref windowDrawList)).AddRectFilled(vector2, vector3, ImGui.GetColorU32(vector4_2), 12f);
			((ImDrawListPtr)(ref windowDrawList)).AddRect(vector2, vector3, ImGui.GetColorU32(vector4_3), 12f);
			((ImDrawListPtr)(ref windowDrawList)).PushClipRect(vector2, vector3);
			Vector2 vector4 = cursorScreenPos + new Vector2(num, num);
			float x2 = vector4.X;
			string text2 = "SERVER";
			((ImDrawListPtr)(ref windowDrawList)).AddText(new Vector2(x2, vector4.Y), ImGui.GetColorU32(vector4_0), text2);
			x2 += ImGui.CalcTextSize(text2).X;
			string text3 = " | ";
			((ImDrawListPtr)(ref windowDrawList)).AddText(new Vector2(x2, vector4.Y), 4289374890u, text3);
			x2 += ImGui.CalcTextSize(text3).X;
			((ImDrawListPtr)(ref windowDrawList)).AddText(new Vector2(x2, vector4.Y), uint.MaxValue, string_1);
			x2 += ImGui.CalcTextSize(string_1).X;
			((ImDrawListPtr)(ref windowDrawList)).AddText(new Vector2(x2, vector4.Y), 4289374890u, text3);
			x2 += ImGui.CalcTextSize(text3).X;
			string text4 = $"Players: {int_1}";
			((ImDrawListPtr)(ref windowDrawList)).AddText(new Vector2(x2, vector4.Y), ImGui.GetColorU32(vector4_1), text4);
			((ImDrawListPtr)(ref windowDrawList)).PopClipRect();
			ImGui.Dummy(new Vector2(x, y));
			if (CerberusConfig.HudOverlay.EditMode)
			{
				Vector2 windowPos = ImGui.GetWindowPos();
				if (windowPos != CerberusConfig.HudOverlay.ServerInfoPos)
				{
					CerberusConfig.HudOverlay.ServerInfoPos = windowPos;
				}
			}
		}
		ImGui.End();
	}

	private void DrawKeybinds()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		ImGuiWindowFlags val = (ImGuiWindowFlags)201155;
		if (!CerberusConfig.HudOverlay.EditMode)
		{
			val = (ImGuiWindowFlags)(val | 0x30204);
			ImGui.SetNextWindowPos(CerberusConfig.HudOverlay.KeybindsPos, (ImGuiCond)1);
		}
		else if (!bool_2)
		{
			ImGui.SetNextWindowPos(CerberusConfig.HudOverlay.KeybindsPos, (ImGuiCond)8);
		}
		else
		{
			ImGui.SetNextWindowPos(CerberusConfig.HudOverlay.KeybindsPos, (ImGuiCond)1);
		}
		if (ImGui.Begin("##Keybinds", val))
		{
			ImDrawListPtr windowDrawList = ImGui.GetWindowDrawList();
			Vector2 cursorScreenPos = ImGui.GetCursorScreenPos();
			float num = 8f;
			float textLineHeightWithSpacing = ImGui.GetTextLineHeightWithSpacing();
			List<(string, string)> list = new List<(string, string)>();
			if (CerberusConfig.GunAimBot.Enabled)
			{
				list.Add((((object)Unsafe.As<ImGuiKey, ImGuiKey>(ref CerberusConfig.GunAimBot.HotKey)/*cast due to constrained. prefix*/).ToString(), "Gun Aim"));
			}
			if (CerberusConfig.MeleeAimBot.Enabled)
			{
				list.Add((((object)Unsafe.As<ImGuiKey, ImGuiKey>(ref CerberusConfig.MeleeAimBot.LightHotKey)/*cast due to constrained. prefix*/).ToString(), "Melee Light"));
			}
			if (CerberusConfig.MeleeAimBot.Enabled && (int)CerberusConfig.MeleeAimBot.HeavyHotKey != 0)
			{
				list.Add((((object)Unsafe.As<ImGuiKey, ImGuiKey>(ref CerberusConfig.MeleeAimBot.HeavyHotKey)/*cast due to constrained. prefix*/).ToString(), "Melee Heavy"));
			}
			if (CerberusConfig.Eye.FullBrightEnabled)
			{
				list.Add((((object)Unsafe.As<ImGuiKey, ImGuiKey>(ref CerberusConfig.Eye.FullBrightHotKey)/*cast due to constrained. prefix*/).ToString(), "FullBright"));
			}
			if (CerberusConfig.Misc.AutoPeekEnabled)
			{
				list.Add((((object)Unsafe.As<ImGuiKey, ImGuiKey>(ref CerberusConfig.Misc.AutoPeekKey)/*cast due to constrained. prefix*/).ToString(), "Auto Peek"));
			}
			float num2 = ImGui.CalcTextSize("KEYBINDS").X;
			foreach (var item in list)
			{
				float x = ImGui.CalcTextSize("[" + item.Item1 + "] " + item.Item2).X;
				if (x > num2)
				{
					num2 = x;
				}
			}
			float num3 = num2 + num * 2f + 10f;
			float y = num * 2f + textLineHeightWithSpacing + (float)list.Count * textLineHeightWithSpacing + 4f;
			Vector2 vector = cursorScreenPos;
			Vector2 vector2 = cursorScreenPos + new Vector2(num3, y);
			((ImDrawListPtr)(ref windowDrawList)).AddRectFilled(vector, vector2, ImGui.GetColorU32(vector4_2), 10f);
			((ImDrawListPtr)(ref windowDrawList)).AddRect(vector, vector2, ImGui.GetColorU32(vector4_3), 10f);
			((ImDrawListPtr)(ref windowDrawList)).PushClipRect(vector, vector2);
			Vector2 vector3 = cursorScreenPos + new Vector2(num, num);
			((ImDrawListPtr)(ref windowDrawList)).AddText(vector3, ImGui.GetColorU32(vector4_0), "KEYBINDS");
			float num4 = cursorScreenPos.Y + num + textLineHeightWithSpacing;
			((ImDrawListPtr)(ref windowDrawList)).AddLine(new Vector2(cursorScreenPos.X + num, num4), new Vector2(cursorScreenPos.X + num3 - num, num4), ImGui.GetColorU32(vector4_3));
			float num5 = num4 + 4f;
			foreach (var item2 in list)
			{
				string text = "[" + item2.Item1 + "]";
				Vector2 vector4 = ImGui.CalcTextSize(text);
				Vector2 vector5 = new Vector2(cursorScreenPos.X + num, num5);
				((ImDrawListPtr)(ref windowDrawList)).AddText(vector5, ImGui.GetColorU32(vector4_1), text);
				Vector2 vector6 = new Vector2(cursorScreenPos.X + num + vector4.X + 5f, num5);
				((ImDrawListPtr)(ref windowDrawList)).AddText(vector6, uint.MaxValue, item2.Item2);
				num5 += textLineHeightWithSpacing;
			}
			if (list.Count == 0)
			{
				((ImDrawListPtr)(ref windowDrawList)).AddText(new Vector2(cursorScreenPos.X + num, num4 + 4f), 4287137928u, "No active binds");
			}
			((ImDrawListPtr)(ref windowDrawList)).PopClipRect();
			ImGui.Dummy(new Vector2(num3, y));
			if (CerberusConfig.HudOverlay.EditMode)
			{
				Vector2 windowPos = ImGui.GetWindowPos();
				if (windowPos != CerberusConfig.HudOverlay.KeybindsPos)
				{
					CerberusConfig.HudOverlay.KeybindsPos = windowPos;
				}
			}
		}
		ImGui.End();
	}

	private void DrawCrosshair()
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		ImGuiIOPtr iO = ImGui.GetIO();
		Vector2 vector = new Vector2(((ImGuiIOPtr)(ref iO)).DisplaySize.X / 2f, ((ImGuiIOPtr)(ref iO)).DisplaySize.Y / 2f);
		ImDrawListPtr foregroundDrawList = ImGui.GetForegroundDrawList();
		uint colorU = ImGui.GetColorU32(CerberusConfig.HudOverlay.CrosshairColor);
		switch (CerberusConfig.HudOverlay.CrosshairStyle)
		{
		case 2:
			((ImDrawListPtr)(ref foregroundDrawList)).AddCircle(vector, 8f, colorU, 32, 2f);
			((ImDrawListPtr)(ref foregroundDrawList)).AddCircleFilled(vector, 1.5f, colorU);
			break;
		case 1:
			((ImDrawListPtr)(ref foregroundDrawList)).AddCircleFilled(vector, 3f, colorU);
			((ImDrawListPtr)(ref foregroundDrawList)).AddCircle(vector, 3f, 4278190080u, 12, 1.5f);
			break;
		case 0:
		{
			float num = 10f;
			float num2 = 3f;
			float num3 = 2f;
			((ImDrawListPtr)(ref foregroundDrawList)).AddLine(new Vector2(vector.X, vector.Y - num2 - num), new Vector2(vector.X, vector.Y - num2), colorU, num3);
			((ImDrawListPtr)(ref foregroundDrawList)).AddLine(new Vector2(vector.X, vector.Y + num2), new Vector2(vector.X, vector.Y + num2 + num), colorU, num3);
			((ImDrawListPtr)(ref foregroundDrawList)).AddLine(new Vector2(vector.X - num2 - num, vector.Y), new Vector2(vector.X - num2, vector.Y), colorU, num3);
			((ImDrawListPtr)(ref foregroundDrawList)).AddLine(new Vector2(vector.X + num2, vector.Y), new Vector2(vector.X + num2 + num, vector.Y), colorU, num3);
			((ImDrawListPtr)(ref foregroundDrawList)).AddCircleFilled(vector, 1.5f, colorU);
			break;
		}
		}
	}

	private void DrawSpectatorList()
	{
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_0487: Unknown result type (might be due to invalid IL or missing references)
		//IL_048d: Unknown result type (might be due to invalid IL or missing references)
		//IL_048e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		if (!(float_4 < 0.5f))
		{
			float_4 = 0f;
			list_1.Clear();
			ICommonSession[] sessions = ((ISharedPlayerManager)iplayerManager_0).Sessions;
			foreach (ICommonSession val in sessions)
			{
				if (!val.AttachedEntity.HasValue)
				{
					list_1.Add(val.Name);
				}
			}
		}
		ImGuiWindowFlags val2 = (ImGuiWindowFlags)201155;
		if (CerberusConfig.HudOverlay.EditMode)
		{
			if (bool_2)
			{
				ImGui.SetNextWindowPos(CerberusConfig.HudOverlay.SpectatorListPos, (ImGuiCond)1);
			}
			else
			{
				ImGui.SetNextWindowPos(CerberusConfig.HudOverlay.SpectatorListPos, (ImGuiCond)8);
			}
		}
		else
		{
			val2 = (ImGuiWindowFlags)(val2 | 0x30204);
			ImGui.SetNextWindowPos(CerberusConfig.HudOverlay.SpectatorListPos, (ImGuiCond)1);
		}
		if (ImGui.Begin("##SpectatorList", val2))
		{
			ImDrawListPtr windowDrawList = ImGui.GetWindowDrawList();
			Vector2 cursorScreenPos = ImGui.GetCursorScreenPos();
			float num = 8f;
			float textLineHeightWithSpacing = ImGui.GetTextLineHeightWithSpacing();
			string text = $"Spectators ({list_1.Count})";
			float num2 = ImGui.CalcTextSize(text).X;
			foreach (string item in list_1)
			{
				float x = ImGui.CalcTextSize(item).X;
				if (!(x <= num2))
				{
					num2 = x;
				}
			}
			float num3 = num2 + num * 2f + 10f;
			int num4 = ((list_1.Count <= 0) ? 1 : Math.Min(list_1.Count, 5));
			float y = num * 2f + textLineHeightWithSpacing + (float)num4 * textLineHeightWithSpacing + 4f;
			Vector2 vector = cursorScreenPos;
			Vector2 vector2 = cursorScreenPos + new Vector2(num3, y);
			((ImDrawListPtr)(ref windowDrawList)).AddRectFilled(vector, vector2, ImGui.GetColorU32(vector4_2), 10f);
			((ImDrawListPtr)(ref windowDrawList)).AddRect(vector, vector2, ImGui.GetColorU32(vector4_3), 10f);
			((ImDrawListPtr)(ref windowDrawList)).PushClipRect(vector, vector2);
			Vector2 vector3 = cursorScreenPos + new Vector2(num, num);
			((ImDrawListPtr)(ref windowDrawList)).AddText(vector3, ImGui.GetColorU32(vector4_0), text);
			float num5 = cursorScreenPos.Y + num + textLineHeightWithSpacing;
			((ImDrawListPtr)(ref windowDrawList)).AddLine(new Vector2(cursorScreenPos.X + num, num5), new Vector2(cursorScreenPos.X + num3 - num, num5), ImGui.GetColorU32(vector4_3));
			float num6 = num5 + 4f;
			if (list_1.Count == 0)
			{
				((ImDrawListPtr)(ref windowDrawList)).AddText(new Vector2(cursorScreenPos.X + num, num6), 4287137928u, "None");
			}
			else
			{
				for (int j = 0; j < num4; j++)
				{
					((ImDrawListPtr)(ref windowDrawList)).AddText(new Vector2(cursorScreenPos.X + num, num6), uint.MaxValue, list_1[j]);
					num6 += textLineHeightWithSpacing;
				}
				if (list_1.Count > 5)
				{
					((ImDrawListPtr)(ref windowDrawList)).AddText(new Vector2(cursorScreenPos.X + num, num6 - textLineHeightWithSpacing), 4287137928u, $"... +{list_1.Count - 5}");
				}
			}
			((ImDrawListPtr)(ref windowDrawList)).PopClipRect();
			ImGui.Dummy(new Vector2(num3, y));
			if (CerberusConfig.HudOverlay.EditMode)
			{
				Vector2 windowPos = ImGui.GetWindowPos();
				if (windowPos != CerberusConfig.HudOverlay.SpectatorListPos)
				{
					CerberusConfig.HudOverlay.SpectatorListPos = windowPos;
				}
			}
		}
		ImGui.End();
	}

	private void DrawDamageCounter()
	{
		string value = $"{CerberusConfig.HudOverlay.SessionDamage:F0}";
		Vector4 value2 = ((!(CerberusConfig.HudOverlay.SessionDamage <= 0f)) ? new Vector4(1f, 0.5f, 0f, 1f) : new Vector4(0.5f, 0.5f, 0.5f, 1f));
		DrawStyledModule("DamageCounter", "DAMAGE", value, ref CerberusConfig.HudOverlay.DamageCounterPos, isLogo: false, value2);
	}

	private void DrawMovementKeys(EntityUid playerEntity)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		PhysicsComponent val = default(PhysicsComponent);
		if (!ientityManager_0.TryGetComponent<PhysicsComponent>(playerEntity, ref val))
		{
			return;
		}
		Vector2 linearVelocity = val.LinearVelocity;
		bool flag = linearVelocity.Y < -0.1f;
		bool flag2 = linearVelocity.Y > 0.1f;
		bool flag3 = linearVelocity.X < -0.1f;
		bool flag4 = linearVelocity.X > 0.1f;
		ImGuiWindowFlags val2 = (ImGuiWindowFlags)201155;
		if (!CerberusConfig.HudOverlay.EditMode)
		{
			val2 = (ImGuiWindowFlags)(val2 | 0x30204);
			ImGui.SetNextWindowPos(CerberusConfig.HudOverlay.MovementKeysPos, (ImGuiCond)1);
		}
		else if (!bool_2)
		{
			ImGui.SetNextWindowPos(CerberusConfig.HudOverlay.MovementKeysPos, (ImGuiCond)8);
		}
		else
		{
			ImGui.SetNextWindowPos(CerberusConfig.HudOverlay.MovementKeysPos, (ImGuiCond)1);
		}
		if (ImGui.Begin("##MovementKeys", val2))
		{
			ImDrawListPtr windowDrawList = ImGui.GetWindowDrawList();
			Vector2 cursorScreenPos = ImGui.GetCursorScreenPos();
			float num = 30f;
			float num2 = 5f;
			float x = 100f;
			float y = 65f;
			_ = cursorScreenPos + new Vector2(x, y);
			uint colorU = ImGui.GetColorU32(vector4_0);
			uint colorU2 = ImGui.GetColorU32(new Vector4(0.2f, 0.2f, 0.2f, 0.8f));
			uint colorU3 = ImGui.GetColorU32(vector4_3);
			Vector2 vector = cursorScreenPos + new Vector2(35f, 0f);
			((ImDrawListPtr)(ref windowDrawList)).AddRectFilled(vector, vector + new Vector2(num, num), (!flag) ? colorU2 : colorU, 4f);
			((ImDrawListPtr)(ref windowDrawList)).AddRect(vector, vector + new Vector2(num, num), colorU3, 4f);
			Vector2 vector2 = ImGui.CalcTextSize("W");
			((ImDrawListPtr)(ref windowDrawList)).AddText(vector + new Vector2((num - vector2.X) / 2f, (num - vector2.Y) / 2f), uint.MaxValue, "W");
			Vector2 vector3 = cursorScreenPos + new Vector2(0f, num + num2);
			((ImDrawListPtr)(ref windowDrawList)).AddRectFilled(vector3, vector3 + new Vector2(num, num), (!flag3) ? colorU2 : colorU, 4f);
			((ImDrawListPtr)(ref windowDrawList)).AddRect(vector3, vector3 + new Vector2(num, num), colorU3, 4f);
			Vector2 vector4 = ImGui.CalcTextSize("A");
			((ImDrawListPtr)(ref windowDrawList)).AddText(vector3 + new Vector2((num - vector4.X) / 2f, (num - vector4.Y) / 2f), uint.MaxValue, "A");
			Vector2 vector5 = cursorScreenPos + new Vector2(num + num2, num + num2);
			((ImDrawListPtr)(ref windowDrawList)).AddRectFilled(vector5, vector5 + new Vector2(num, num), flag2 ? colorU : colorU2, 4f);
			((ImDrawListPtr)(ref windowDrawList)).AddRect(vector5, vector5 + new Vector2(num, num), colorU3, 4f);
			Vector2 vector6 = ImGui.CalcTextSize("S");
			((ImDrawListPtr)(ref windowDrawList)).AddText(vector5 + new Vector2((num - vector6.X) / 2f, (num - vector6.Y) / 2f), uint.MaxValue, "S");
			Vector2 vector7 = cursorScreenPos + new Vector2((num + num2) * 2f, num + num2);
			((ImDrawListPtr)(ref windowDrawList)).AddRectFilled(vector7, vector7 + new Vector2(num, num), (!flag4) ? colorU2 : colorU, 4f);
			((ImDrawListPtr)(ref windowDrawList)).AddRect(vector7, vector7 + new Vector2(num, num), colorU3, 4f);
			Vector2 vector8 = ImGui.CalcTextSize("D");
			((ImDrawListPtr)(ref windowDrawList)).AddText(vector7 + new Vector2((num - vector8.X) / 2f, (num - vector8.Y) / 2f), uint.MaxValue, "D");
			ImGui.Dummy(new Vector2(x, y));
			if (CerberusConfig.HudOverlay.EditMode)
			{
				Vector2 windowPos = ImGui.GetWindowPos();
				if (windowPos != CerberusConfig.HudOverlay.MovementKeysPos)
				{
					CerberusConfig.HudOverlay.MovementKeysPos = windowPos;
				}
			}
		}
		ImGui.End();
	}

	private void DrawCPS()
	{
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		DateTime wa60oS7imE = DateTime.UtcNow;
		list_4.RemoveAll((DateTime t) => (wa60oS7imE - t).TotalSeconds > 1.0);
		ImGuiIOPtr iO = ImGui.GetIO();
		if (((ImGuiIOPtr)(ref iO)).MouseClicked[0])
		{
			list_4.Add(wa60oS7imE);
		}
		int count = list_4.Count;
		Vector4 value = ((count > 10) ? new Vector4(1f, 0f, 0f, 1f) : ((count <= 5) ? new Vector4(0f, 1f, 0f, 1f) : new Vector4(1f, 1f, 0f, 1f)));
		DrawStyledModule("CPS", "CPS", count.ToString(), ref CerberusConfig.HudOverlay.CPSPos, isLogo: false, value);
	}

	private void DrawRadar(EntityUid playerEntity)
	{
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		TransformComponent val = default(TransformComponent);
		if (!ientityManager_0.TryGetComponent<TransformComponent>(playerEntity, ref val))
		{
			return;
		}
		ImGuiWindowFlags val2 = (ImGuiWindowFlags)201155;
		if (CerberusConfig.HudOverlay.EditMode)
		{
			if (bool_2)
			{
				ImGui.SetNextWindowPos(CerberusConfig.HudOverlay.RadarPos, (ImGuiCond)1);
			}
			else
			{
				ImGui.SetNextWindowPos(CerberusConfig.HudOverlay.RadarPos, (ImGuiCond)8);
			}
		}
		else
		{
			val2 = (ImGuiWindowFlags)(val2 | 0x30204);
			ImGui.SetNextWindowPos(CerberusConfig.HudOverlay.RadarPos, (ImGuiCond)1);
		}
		if (ImGui.Begin("##Radar", val2))
		{
			ImDrawListPtr windowDrawList = ImGui.GetWindowDrawList();
			Vector2 cursorScreenPos = ImGui.GetCursorScreenPos();
			float num = 120f;
			float num2 = num / 2f;
			Vector2 vector = cursorScreenPos + new Vector2(num2, num2);
			((ImDrawListPtr)(ref windowDrawList)).AddCircleFilled(vector, num2, ImGui.GetColorU32(vector4_2), 32);
			((ImDrawListPtr)(ref windowDrawList)).AddCircle(vector, num2, ImGui.GetColorU32(vector4_3), 32, 2f);
			((ImDrawListPtr)(ref windowDrawList)).AddLine(new Vector2(vector.X, vector.Y - num2), new Vector2(vector.X, vector.Y + num2), ImGui.GetColorU32(vector4_3));
			((ImDrawListPtr)(ref windowDrawList)).AddLine(new Vector2(vector.X - num2, vector.Y), new Vector2(vector.X + num2, vector.Y), ImGui.GetColorU32(vector4_3));
			((ImDrawListPtr)(ref windowDrawList)).AddCircle(vector, num2 / 2f, ImGui.GetColorU32(vector4_3), 32, 1f);
			((ImDrawListPtr)(ref windowDrawList)).AddCircleFilled(vector, 3f, ImGui.GetColorU32(vector4_0));
			MapCoordinates mapPosition = val.MapPosition;
			EntityQueryEnumerator<ActorComponent, TransformComponent> val3 = ientityManager_0.EntityQueryEnumerator<ActorComponent, TransformComponent>();
			EntityUid val4 = default(EntityUid);
			ActorComponent val5 = default(ActorComponent);
			TransformComponent val6 = default(TransformComponent);
			MetaDataComponent val7 = default(MetaDataComponent);
			while (val3.MoveNext(ref val4, ref val5, ref val6))
			{
				if (val4 == playerEntity)
				{
					continue;
				}
				MapCoordinates mapPosition2 = val6.MapPosition;
				if (!(mapPosition2.MapId != mapPosition.MapId))
				{
					Vector2 vector2 = mapPosition2.Position - mapPosition.Position;
					if (!(vector2.Length() > CerberusConfig.HudOverlay.RadarRange))
					{
						float num3 = (num2 - 5f) / CerberusConfig.HudOverlay.RadarRange;
						Vector2 vector3 = vector + new Vector2(vector2.X * num3, (0f - vector2.Y) * num3);
						ientityManager_0.TryGetComponent<MetaDataComponent>(val4, ref val7);
						((ImDrawListPtr)(ref windowDrawList)).AddCircleFilled(vector3, 2.5f, 4294901760u);
					}
				}
			}
			Vector2 vector4 = cursorScreenPos + new Vector2(5f, 5f);
			((ImDrawListPtr)(ref windowDrawList)).AddText(vector4, ImGui.GetColorU32(vector4_0), "RADAR");
			ImGui.Dummy(new Vector2(num, num));
			if (CerberusConfig.HudOverlay.EditMode)
			{
				Vector2 windowPos = ImGui.GetWindowPos();
				if (windowPos != CerberusConfig.HudOverlay.RadarPos)
				{
					CerberusConfig.HudOverlay.RadarPos = windowPos;
				}
			}
		}
		ImGui.End();
	}

	private void DrawShuttleTracker()
	{
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		if (!(float_6 < 1f))
		{
			float_6 = 0f;
			if (ientityManager_0 != null)
			{
				EntityQueryEnumerator<MetaDataComponent, TransformComponent> val = ientityManager_0.EntityQueryEnumerator<MetaDataComponent, TransformComponent>();
				bool flag = false;
				EntityUid val2 = default(EntityUid);
				MetaDataComponent val3 = default(MetaDataComponent);
				TransformComponent val4 = default(TransformComponent);
				PhysicsComponent val5 = default(PhysicsComponent);
				while (val.MoveNext(ref val2, ref val3, ref val4))
				{
					if (val3.EntityName.Contains("Emergency Shuttle") || val3.EntityName.Contains("Evacuation"))
					{
						if (!ientityManager_0.TryGetComponent<PhysicsComponent>(val2, ref val5))
						{
							string_4 = "Found";
						}
						else
						{
							string_4 = ((val5.LinearVelocity.LengthSquared() <= 0.01f) ? "Docked" : "Moving");
						}
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					string_4 = "Unknown";
				}
			}
		}
		Vector2 position = CerberusConfig.HudOverlay.ShuttleTrackerPos;
		DrawStyledModule("ShuttleTracker", "SHUTTLE", string_4, ref position);
		CerberusConfig.HudOverlay.ShuttleTrackerPos = position;
	}

	private void DrawConnectionQuality()
	{
		Vector2 position = CerberusConfig.HudOverlay.ConnectionQualityPos;
		IClientNetManager obj = iclientNetManager_0;
		object obj2;
		if (obj == null)
		{
			obj2 = null;
		}
		else
		{
			INetChannel serverChannel = obj.ServerChannel;
			obj2 = ((serverChannel == null) ? null : serverChannel.Ping.ToString());
		}
		IClientNetManager obj3 = iclientNetManager_0;
		short? obj4;
		if (obj3 == null)
		{
			obj4 = null;
		}
		else
		{
			INetChannel serverChannel2 = obj3.ServerChannel;
			obj4 = ((serverChannel2 == null) ? ((short?)null) : new short?(serverChannel2.Ping));
		}
		short? num = obj4;
		int valueOrDefault = num.GetValueOrDefault();
		string value = "Excellent";
		Vector4 value2 = new Vector4(0f, 1f, 0f, 1f);
		if (valueOrDefault > 150)
		{
			value = "Poor";
			value2 = new Vector4(1f, 0f, 0f, 1f);
		}
		else if (valueOrDefault <= 80)
		{
			if (valueOrDefault > 40)
			{
				value = "Good";
				value2 = new Vector4(0.5f, 1f, 0f, 1f);
			}
		}
		else
		{
			value = "Fair";
			value2 = new Vector4(1f, 1f, 0f, 1f);
		}
		DrawStyledModule("ConnQuality", "CONN", $"{valueOrDefault}ms ({value})", ref position, isLogo: false, value2);
		CerberusConfig.HudOverlay.ConnectionQualityPos = position;
	}
}
