using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Content.Shared.CombatMode;
using Content.Shared.Mobs.Components;
using Content.Shared.Mobs.Systems;
using Robust.Client.GameObjects;
using Robust.Client.Graphics;
using Robust.Client.Player;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Maths;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using TextureLoader;
using ShaderDrawHelpers;
using CerberusConfig;

namespace SpiritsOverlay;

[CompilerGenerated]
public sealed class SpiritsOverlay : Overlay
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	private SharedTransformSystem sharedTransformSystem_0;

	private MobStateSystem mobStateSystem_0;

	private Texture texture_0;

	private Texture texture_1;

	private Texture texture_2;

	private Texture texture_3;

	private Texture texture_4;

	private Texture texture_5;

	private Texture texture_6;

	private Texture texture_7;

	private Texture texture_8;

	private Texture texture_9;

	private Texture texture_10;

	private bool bool_0;

	private EntityUid? nullable_0;

	private float float_0;

	private float float_1;

	private byte byte_0;

	private char char_0;

	private long long_1;

	public override OverlaySpace Space => (OverlaySpace)4;

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

	public SpiritsOverlay()
	{
		IoCManager.InjectDependencies<SpiritsOverlay>(this);
	}

	private void LoadTextures()
	{
		if (bool_0)
		{
			return;
		}
		try
		{
			texture_0 = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.souls.glow.png", "soul_glow");
			texture_1 = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.targetesp.capture1.png", "capture1");
			texture_2 = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.targetesp.capture2.png", "capture2");
			texture_3 = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.targetesp.capture5.png", "capture5");
			texture_4 = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.targetesp.fuckfinger.png", "fuckfinger");
			texture_5 = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.targetesp.quadstapple.png", "quadstapple");
			texture_6 = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.targetesp.target.png", "target");
			texture_7 = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.targetesp.target2.png", "target2");
			texture_8 = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.targetesp.targetpro.png", "targetpro");
			texture_9 = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.targetesp.trianglestapple.png", "trianglestapple");
			texture_10 = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.targetesp.trianglestipple.png", "trianglestipple");
			bool_0 = true;
		}
		catch (Exception)
		{
		}
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0377: Unknown result type (might be due to invalid IL or missing references)
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.TargetEsp.SpiritsEnabled)
		{
			return;
		}
		if (!bool_0)
		{
			LoadTextures();
		}
		if (sharedTransformSystem_0 == null)
		{
			try
			{
				sharedTransformSystem_0 = ientityManager_0.System<SharedTransformSystem>();
				mobStateSystem_0 = ientityManager_0.System<MobStateSystem>();
			}
			catch
			{
				return;
			}
		}
		ICommonSession localSession = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
		EntityUid? val = ((localSession != null) ? localSession.AttachedEntity : ((EntityUid?)null));
		if (!val.HasValue)
		{
			return;
		}
		bool flag = false;
		CombatModeComponent val2 = default(CombatModeComponent);
		if (ientityManager_0.TryGetComponent<CombatModeComponent>(val.Value, ref val2))
		{
			flag = val2.IsInCombatMode;
		}
		if (!flag)
		{
			nullable_0 = null;
			float_1 = 0f;
			return;
		}
		DrawingHandleWorld worldHandle = ((OverlayDrawArgs)(ref args)).WorldHandle;
		float time = (float)igameTiming_0.RealTime.TotalSeconds;
		float num = (float)igameTiming_0.FrameTime.TotalSeconds;
		EntityUid? currentTarget = CerberusConfig.HudOverlay.CurrentTarget;
		if (!currentTarget.HasValue)
		{
			if (!nullable_0.HasValue)
			{
				float_1 = 0f;
				return;
			}
			float_0 += num;
			if (float_0 >= 2f)
			{
				float_1 = Math.Max(0f, float_1 - 1.5f * num);
				if (!(float_1 > 0f))
				{
					nullable_0 = null;
				}
			}
			else
			{
				float_1 = 1f;
			}
		}
		else
		{
			nullable_0 = currentTarget;
			float_0 = 0f;
			float_1 = Math.Min(1f, float_1 + 3f * num);
		}
		if (!(float_1 > 0f))
		{
			return;
		}
		EntityUid val3 = (EntityUid)(((_003F?)currentTarget) ?? nullable_0.Value);
		TransformComponent val4 = default(TransformComponent);
		MobStateComponent val5 = default(MobStateComponent);
		SpriteComponent val6 = default(SpriteComponent);
		if (!ientityManager_0.TryGetComponent<TransformComponent>(val3, ref val4) || !ientityManager_0.TryGetComponent<MobStateComponent>(val3, ref val5) || !ientityManager_0.TryGetComponent<SpriteComponent>(val3, ref val6) || val4.MapID != args.MapId || mobStateSystem_0.IsDead(val3, val5) || (((ISharedPlayerManager)iplayerManager_0).LocalEntity.HasValue && val3 == ((ISharedPlayerManager)iplayerManager_0).LocalEntity.Value))
		{
			return;
		}
		Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(val4);
		if (!((Box2)(ref args.WorldAABB)).Contains(worldPosition, true))
		{
			return;
		}
		int spiritsMode = CerberusConfig.TargetEsp.SpiritsMode;
		Angle worldRotation = sharedTransformSystem_0.GetWorldRotation(val4);
		if (spiritsMode >= 5 && spiritsMode <= 16)
		{
			Texture textureForMode = GetTextureForMode(spiritsMode);
			if (textureForMode != null)
			{
				switch (spiritsMode)
				{
				default:
					DrawMinecraftStylePNG(worldHandle, worldPosition, time, worldRotation, textureForMode, float_1);
					break;
				case 5:
					DrawSpiritsPNG(worldHandle, worldPosition, time, worldRotation, float_1);
					break;
				case 6:
					DrawSpiritsPNGUpDown(worldHandle, worldPosition, time, worldRotation, float_1);
					break;
				}
			}
		}
		else
		{
			DrawSpiritsImproved(worldHandle, worldPosition, time, float_1);
		}
	}

	private void DrawSpiritsPNG(DrawingHandleWorld handle, Vector2 transformPos, float time, Angle gridRotation, float alpha)
	{
		//IL_043f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_036f: Unknown result type (might be due to invalid IL or missing references)
		//IL_037f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0337: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_0348: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Unknown result type (might be due to invalid IL or missing references)
		//IL_047a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0456: Unknown result type (might be due to invalid IL or missing references)
		//IL_045b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		Vector4 spiritsColor = CerberusConfig.TargetEsp.SpiritsColor;
		Color val = default(Color);
		((Color)(ref val))._002Ector(spiritsColor.X, spiritsColor.Y, spiritsColor.Z, spiritsColor.W * alpha);
		float num = 3f;
		float num2 = 0.7f;
		float num3 = 0.2f;
		float spiritsSize = CerberusConfig.TargetEsp.SpiritsSize;
		float num4 = 1.5f;
		((DrawingHandleBase)handle).UseShader((ShaderInstance)null);
		for (int i = 0; i < 3; i++)
		{
			float num5 = time * num + (float)((double)i * (Math.PI * 2.0 / 3.0));
			for (int num6 = 25; num6 >= 1; num6--)
			{
				float num7 = (float)num6 / 25f;
				float num8 = num5 - num7 * num4;
				float num9 = (float)Math.Cos(num8) * num2;
				float num10 = (float)Math.Sin(num8) * num3;
				float x = num9 * (float)Math.Cos(gridRotation.Theta) - num10 * (float)Math.Sin(gridRotation.Theta);
				float y = num9 * (float)Math.Sin(gridRotation.Theta) + num10 * (float)Math.Cos(gridRotation.Theta);
				Vector2 vector = transformPos + new Vector2(x, y);
				float num11 = (float)Math.Pow(1f - num7, 2.0);
				float num12 = 1f;
				if (!(num10 <= 0f))
				{
					float num13 = Math.Abs(num9);
					float num14 = 0.8f;
					if (num13 < num14)
					{
						float num15 = num13 / num14;
						num12 = num15 * num15 * (3f - 2f * num15);
						if (num12 < 0.2f)
						{
							continue;
						}
					}
				}
				float num16 = spiritsSize * num11 * 1.2f;
				float num17 = num11 * 0.6f * num12;
				Color modulate = ((Color)(ref val)).WithAlpha(val.A * num17);
				((DrawingHandleBase)handle).Modulate = modulate;
				Box2 val2 = Box2.CenteredAround(vector, new Vector2(num16, num16));
				handle.DrawTextureRect(texture_0, val2, (Color?)Color.White);
			}
			float num18 = (float)Math.Cos(num5) * num2;
			float num19 = (float)Math.Sin(num5) * num3;
			float x2 = num18 * (float)Math.Cos(gridRotation.Theta) - num19 * (float)Math.Sin(gridRotation.Theta);
			float y2 = num18 * (float)Math.Sin(gridRotation.Theta) + num19 * (float)Math.Cos(gridRotation.Theta);
			Vector2 vector2 = transformPos + new Vector2(x2, y2);
			float num20 = 1f;
			bool flag = true;
			if (!(num19 <= 0f))
			{
				float num21 = Math.Abs(num18);
				float num22 = 0.8f;
				if (num21 < num22)
				{
					float num23 = num21 / num22;
					num20 = num23 * num23 * (3f - 2f * num23);
					if (num20 < 0.2f)
					{
						flag = false;
					}
				}
			}
			if (flag)
			{
				Color val3 = (((DrawingHandleBase)handle).Modulate = ((Color)(ref val)).WithAlpha(val.A * num20));
				Box2 val5 = Box2.CenteredAround(vector2, new Vector2(spiritsSize, spiritsSize));
				handle.DrawTextureRect(texture_0, val5, (Color?)Color.White);
				((DrawingHandleBase)handle).Modulate = ((Color)(ref val3)).WithAlpha(num20 * 0.3f);
				Box2 val6 = Box2.CenteredAround(vector2, new Vector2(spiritsSize * 1.4f, spiritsSize * 1.4f));
				handle.DrawTextureRect(texture_0, val6, (Color?)Color.White);
				((DrawingHandleBase)handle).Modulate = ((Color)(ref val3)).WithAlpha(num20 * 0.15f);
				Box2 val7 = Box2.CenteredAround(vector2, new Vector2(spiritsSize * 1.8f, spiritsSize * 1.8f));
				handle.DrawTextureRect(texture_0, val7, (Color?)Color.White);
				((DrawingHandleBase)handle).Modulate = ((Color)(ref val3)).WithAlpha(num20 * 0.08f);
				Box2 val8 = Box2.CenteredAround(vector2, new Vector2(spiritsSize * 2.2f, spiritsSize * 2.2f));
				handle.DrawTextureRect(texture_0, val8, (Color?)Color.White);
			}
		}
		((DrawingHandleBase)handle).Modulate = Color.White;
	}

	private void DrawSpiritsPNGUpDown(DrawingHandleWorld handle, Vector2 transformPos, float time, Angle gridRotation, float alpha)
	{
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Unknown result type (might be due to invalid IL or missing references)
		Vector4 spiritsColor = CerberusConfig.TargetEsp.SpiritsColor;
		Color val = default(Color);
		((Color)(ref val))._002Ector(spiritsColor.X, spiritsColor.Y, spiritsColor.Z, spiritsColor.W * alpha);
		float num = 0.7f;
		float num2 = 0.25f;
		float num3 = 0.42f;
		float num4 = 0.6f;
		float num5 = 2.5f;
		float num6 = 0.55f;
		float spiritsSize = CerberusConfig.TargetEsp.SpiritsSize;
		((DrawingHandleBase)handle).UseShader((ShaderInstance)null);
		for (int i = 0; i < 3; i++)
		{
			float num7 = (float)i * ((float)Math.PI * 2f / 3f);
			for (int j = 0; j < 15; j++)
			{
				float num8 = time - (float)j * 0.05f;
				float num9 = (float)Math.Sin(num8 * num4) * num3;
				float num10 = Math.Abs(num9) / num3;
				float num11 = 1f - num10 * num6;
				float num12 = num8 * num5 + num7;
				float num13 = num * num11;
				float num14 = num2 * num11;
				float num15 = (float)Math.Cos(num12) * num13;
				float num16 = (float)Math.Sin(num12) * num14;
				float num17 = num15 * (float)Math.Cos(gridRotation.Theta) - num16 * (float)Math.Sin(gridRotation.Theta);
				float num18 = num15 * (float)Math.Sin(gridRotation.Theta) + num16 * (float)Math.Cos(gridRotation.Theta);
				float x = num17;
				float y = num18 + num9;
				Vector2 vector = transformPos + new Vector2(x, y);
				float num19 = (float)j / 15f;
				float num20 = (float)Math.Pow(1f - num19, 2.5);
				float num21 = 1f;
				if (num16 > 0f)
				{
					float num22 = Math.Abs(num15);
					float num23 = num13 * 0.85f;
					if (num22 < num23)
					{
						float num24 = num22 / num23;
						num21 = num24 * num24 * (3f - 2f * num24);
						if (!(num21 >= 0.2f))
						{
							continue;
						}
					}
				}
				float num25 = num20 * num21;
				float num26 = spiritsSize * (0.5f + num20 * 0.5f);
				Color val2 = (((DrawingHandleBase)handle).Modulate = ((Color)(ref val)).WithAlpha(val.A * num25));
				Box2 val4 = Box2.CenteredAround(vector, new Vector2(num26, num26));
				handle.DrawTextureRect(texture_0, val4, (Color?)Color.White);
				if (j == 0)
				{
					((DrawingHandleBase)handle).Modulate = ((Color)(ref val2)).WithAlpha(num25 * 0.35f);
					Box2 val5 = Box2.CenteredAround(vector, new Vector2(num26 * 1.4f, num26 * 1.4f));
					handle.DrawTextureRect(texture_0, val5, (Color?)Color.White);
					((DrawingHandleBase)handle).Modulate = ((Color)(ref val2)).WithAlpha(num25 * 0.18f);
					Box2 val6 = Box2.CenteredAround(vector, new Vector2(num26 * 1.8f, num26 * 1.8f));
					handle.DrawTextureRect(texture_0, val6, (Color?)Color.White);
				}
			}
		}
		((DrawingHandleBase)handle).Modulate = Color.White;
	}

	private void DrawSpiritsImproved(DrawingHandleWorld handle, Vector2 transformPos, float time, float alpha)
	{
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_053f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0544: Unknown result type (might be due to invalid IL or missing references)
		//IL_0547: Unknown result type (might be due to invalid IL or missing references)
		//IL_0549: Unknown result type (might be due to invalid IL or missing references)
		ShaderInstance spiritShaderInstance = ShaderDrawHelpers.SpiritShaderInstance;
		if (spiritShaderInstance == null)
		{
			DrawSpiritsFallback(handle, transformPos, time);
			return;
		}
		Vector4 spiritsColor = CerberusConfig.TargetEsp.SpiritsColor;
		Color val = default(Color);
		((Color)(ref val))._002Ector(spiritsColor.X, spiritsColor.Y, spiritsColor.Z, spiritsColor.W * alpha);
		float spiritsOrbitRadiusX = CerberusConfig.TargetEsp.SpiritsOrbitRadiusX;
		float spiritsOrbitRadiusY = CerberusConfig.TargetEsp.SpiritsOrbitRadiusY;
		float spiritsSpeed = CerberusConfig.TargetEsp.SpiritsSpeed;
		float spiritsSize = CerberusConfig.TargetEsp.SpiritsSize;
		float spiritsTrailLength = CerberusConfig.TargetEsp.SpiritsTrailLength;
		int spiritsMode = CerberusConfig.TargetEsp.SpiritsMode;
		spiritShaderInstance.SetParameter("time", time);
		Matrix3x2 identity;
		for (int i = 0; i < 3; i++)
		{
			float num = time * spiritsSpeed + (float)((double)i * (Math.PI * 2.0 / 3.0));
			for (int j = 1; j <= 18; j++)
			{
				float num2 = (float)j / 18f;
				float angle = num - num2 * spiritsTrailLength;
				(float x, float y) spiritPosition = GetSpiritPosition(angle, spiritsOrbitRadiusX, spiritsOrbitRadiusY, spiritsMode, time, i);
				float item = spiritPosition.x;
				float item2 = spiritPosition.y;
				Vector2 vector = transformPos + new Vector2(item, item2);
				float num3 = (float)Math.Pow(1f - num2, 2.5);
				float num4 = 1f;
				if (spiritsMode != 1)
				{
					if (!(item2 <= 0f))
					{
						float num5 = Math.Abs(item);
						float num6 = 0.8f;
						if (num5 < num6)
						{
							float num7 = num5 / num6;
							num4 = num7 * num7 * (3f - 2f * num7);
							if (!(num4 >= 0.2f))
							{
								continue;
							}
						}
					}
				}
				else
				{
					float num8 = Math.Abs(item);
					float num9 = 0.9f;
					float num10 = -0.1f;
					float num11 = 0.4f;
					if (num8 < num9 && !(item2 <= num10) && item2 < num11)
					{
						float num12 = num8 / num9;
						num4 = num12 * num12 * (3f - 2f * num12);
						if (num4 < 0.15f)
						{
							continue;
						}
					}
				}
				float num13 = num3 * 0.8f * num4;
				float num14 = spiritsSize * 2.2f * num3;
				Color val2 = ((Color)(ref val)).WithAlpha(val.A * num13);
				spiritShaderInstance.SetParameter("color", val2);
				((DrawingHandleBase)handle).UseShader(spiritShaderInstance);
				Matrix3x2 matrix3x = Matrix3Helpers.CreateTranslation(vector);
				((DrawingHandleBase)handle).SetTransform(ref matrix3x);
				Box2 val3 = Box2.FromDimensions(new Vector2((0f - num14) / 2f, (0f - num14) / 2f), new Vector2(num14, num14));
				handle.DrawRect(val3, Color.White, true);
				((DrawingHandleBase)handle).UseShader((ShaderInstance)null);
				identity = Matrix3x2.Identity;
				((DrawingHandleBase)handle).SetTransform(ref identity);
			}
			(float x, float y) spiritPosition2 = GetSpiritPosition(num, spiritsOrbitRadiusX, spiritsOrbitRadiusY, spiritsMode, time, i);
			float item3 = spiritPosition2.x;
			float item4 = spiritPosition2.y;
			Vector2 vector2 = transformPos + new Vector2(item3, item4);
			float num15 = 1f;
			bool flag = true;
			if (spiritsMode != 1)
			{
				if (item4 > 0f)
				{
					float num16 = Math.Abs(item3);
					float num17 = 0.8f;
					if (num16 < num17)
					{
						float num18 = num16 / num17;
						num15 = num18 * num18 * (3f - 2f * num18);
						if (num15 < 0.2f)
						{
							flag = false;
						}
					}
				}
			}
			else
			{
				float num19 = Math.Abs(item3);
				float num20 = 0.9f;
				float num21 = -0.1f;
				float num22 = 0.4f;
				if (!(num19 >= num20) && item4 > num21 && item4 < num22)
				{
					float num23 = num19 / num20;
					num15 = num23 * num23 * (3f - 2f * num23);
					if (num15 < 0.15f)
					{
						flag = false;
					}
				}
			}
			if (flag)
			{
				((DrawingHandleBase)handle).UseShader(spiritShaderInstance);
				Color val4 = ((Color)(ref val)).WithAlpha(val.A * num15);
				spiritShaderInstance.SetParameter("color", val4);
				float num24 = spiritsSize;
				Matrix3x2 matrix3x2 = Matrix3Helpers.CreateTranslation(vector2);
				((DrawingHandleBase)handle).SetTransform(ref matrix3x2);
				Box2 val5 = Box2.FromDimensions(new Vector2((0f - num24) / 2f, (0f - num24) / 2f), new Vector2(num24, num24));
				handle.DrawRect(val5, Color.White, true);
				((DrawingHandleBase)handle).UseShader((ShaderInstance)null);
				identity = Matrix3x2.Identity;
				((DrawingHandleBase)handle).SetTransform(ref identity);
				((DrawingHandleBase)handle).DrawCircle(vector2, num24 * 1.2f, ((Color)(ref val4)).WithAlpha(num15 * 0.2f), true);
				((DrawingHandleBase)handle).DrawCircle(vector2, num24 * 1.6f, ((Color)(ref val4)).WithAlpha(num15 * 0.12f), true);
				((DrawingHandleBase)handle).DrawCircle(vector2, num24 * 2f, ((Color)(ref val4)).WithAlpha(num15 * 0.06f), true);
			}
		}
		((DrawingHandleBase)handle).UseShader((ShaderInstance)null);
		identity = Matrix3x2.Identity;
		((DrawingHandleBase)handle).SetTransform(ref identity);
	}

	private (float x, float y) GetSpiritPosition(float angle, float radiusX, float radiusY, int mode, float time, int spiritIndex)
	{
		switch (mode)
		{
		case 4:
		{
			float num15 = (float)spiritIndex * ((float)Math.PI * 2f / 3f);
			float num16 = 1f + (float)spiritIndex * 0.2f;
			float num17 = time * num16 * 2f + num15;
			float item3 = (float)Math.Sin(num17) * radiusY * 1.5f;
			float num18 = 0.6f + (float)spiritIndex * 0.15f;
			float num19 = (float)Math.Cos(num17) * radiusX * num18;
			float num20 = (float)spiritIndex * 1.5f;
			float num21 = (float)Math.Sin(num17 * 0.5f + num20) * radiusX * 0.25f;
			num19 += num21;
			return (x: num19, y: item3);
		}
		case 0:
			return (x: (float)Math.Cos(angle) * radiusX, y: (float)Math.Sin(angle) * radiusY);
		case 1:
		{
			float num22 = angle * 0.5f;
			float num23 = (float)Math.Sin(num22);
			float item4 = (float)Math.Sin(num22 * 2f) * radiusX * 0.8f;
			float item5 = num23 * radiusY * 1.2f;
			return (x: item4, y: item5);
		}
		case 2:
		{
			float num24 = angle / ((float)Math.PI * 2f) % 1f;
			if (!(num24 >= 0f))
			{
				num24 += 1f;
			}
			if (num24 >= 0.25f)
			{
				if (num24 >= 0.5f)
				{
					if (num24 >= 0.75f)
					{
						return (x: 0f - radiusX, y: radiusY * (1f - (num24 - 0.75f) * 4f * 2f));
					}
					return (x: radiusX * (1f - (num24 - 0.5f) * 4f * 2f), y: radiusY);
				}
				return (x: radiusX, y: radiusY * ((num24 - 0.25f) * 4f * 2f - 1f));
			}
			return (x: radiusX * (num24 * 4f * 2f - 1f), y: 0f - radiusY);
		}
		default:
			return (x: (float)Math.Cos(angle) * radiusX, y: (float)Math.Sin(angle) * radiusY);
		case 3:
		{
			float num = angle / ((float)Math.PI * 2f) % 1f;
			if (num < 0f)
			{
				num += 1f;
			}
			float num2 = 1f / 10f;
			int num3 = (int)(num / num2);
			float num4 = (num - (float)num3 * num2) / num2;
			float num5 = num4 * num4 * (3f - 2f * num4);
			int num6 = (num3 + 1) % 10;
			float num7 = (float)num3 * ((float)Math.PI / 5f) - (float)Math.PI / 2f;
			float num8 = (float)num6 * ((float)Math.PI / 5f) - (float)Math.PI / 2f;
			float num9 = ((num3 % 2 != 0) ? 0.5f : 1f);
			float num10 = ((num6 % 2 != 0) ? 0.5f : 1f);
			float num11 = (float)Math.Cos(num7) * radiusX * num9;
			float num12 = (float)Math.Sin(num7) * radiusY * num9;
			float num13 = (float)Math.Cos(num8) * radiusX * num10;
			float num14 = (float)Math.Sin(num8) * radiusY * num10;
			float item = num11 + (num13 - num11) * num5;
			float item2 = num12 + (num14 - num12) * num5;
			return (x: item, y: item2);
		}
		}
	}

	private Texture GetTextureForMode(int mode)
	{
		return (Texture)(mode switch
		{
			14 => texture_8, 
			16 => texture_10, 
			11 => texture_5, 
			9 => texture_3, 
			13 => texture_7, 
			8 => texture_2, 
			15 => texture_9, 
			12 => texture_6, 
			10 => texture_4, 
			7 => texture_1, 
			6 => texture_0, 
			5 => texture_0, 
			_ => null, 
		});
	}

	private void DrawMinecraftStylePNG(DrawingHandleWorld handle, Vector2 transformPos, float time, Angle gridRotation, Texture texture, float alpha)
	{
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		float spiritsSize = CerberusConfig.TargetEsp.SpiritsSize;
		bool enableSpringEffect = CerberusConfig.TargetEsp.EnableSpringEffect;
		bool enableColorTint = CerberusConfig.TargetEsp.EnableColorTint;
		Vector4 pngTintColor = CerberusConfig.TargetEsp.PngTintColor;
		float radians;
		if (enableSpringEffect)
		{
			float num = 0.6f;
			float num2 = 8.16814f;
			radians = (float)Math.Sin(time * num) * num2;
		}
		else
		{
			float num3 = 3f;
			radians = (0f - time) * num3;
		}
		_003F val;
		if (enableColorTint)
		{
			val = new Color(pngTintColor.X, pngTintColor.Y, pngTintColor.Z, pngTintColor.W * alpha);
		}
		else
		{
			Color white = Color.White;
			val = ((Color)(ref white)).WithAlpha(alpha);
		}
		Color modulate = (Color)val;
		((DrawingHandleBase)handle).UseShader((ShaderInstance)null);
		((DrawingHandleBase)handle).Modulate = modulate;
		Matrix3x2 matrix3x = Matrix3x2.CreateRotation(radians) * Matrix3x2.CreateTranslation(transformPos);
		((DrawingHandleBase)handle).SetTransform(ref matrix3x);
		Box2 val2 = Box2.FromDimensions(new Vector2((0f - spiritsSize) / 2f, (0f - spiritsSize) / 2f), new Vector2(spiritsSize, spiritsSize));
		handle.DrawTextureRect(texture, val2, (Color?)Color.White);
		Matrix3x2 identity = Matrix3x2.Identity;
		((DrawingHandleBase)handle).SetTransform(ref identity);
		((DrawingHandleBase)handle).Modulate = Color.White;
	}

	private void DrawSpiritsFallback(DrawingHandleWorld handle, Vector2 transformPos, float time)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		Matrix3x2 identity = Matrix3x2.Identity;
		((DrawingHandleBase)handle).SetTransform(ref identity);
		Vector4 spiritsColor = CerberusConfig.TargetEsp.SpiritsColor;
		Color val = default(Color);
		((Color)(ref val))._002Ector(spiritsColor.X, spiritsColor.Y, spiritsColor.Z, spiritsColor.W);
		float num = 0.6f;
		float num2 = 0.15f;
		float num3 = 3f;
		for (int i = 0; i < 3; i++)
		{
			float num4 = time * num3 + (float)((double)i * (Math.PI * 2.0 / 3.0));
			float num5 = (float)Math.Cos(num4) * num;
			float num6 = (float)Math.Sin(num4) * num2;
			Vector2 vector = transformPos + new Vector2(num5, num6);
			bool flag = num6 > 0f;
			if (!flag || Math.Abs(num5) >= 0.4f)
			{
				float num7 = (0f - num6) / num2;
				float num8 = 0.09f * (1f + num7 * 0.2f);
				float num9 = (flag ? 0.6f : 1f);
				Color val2 = ((Color)(ref val)).WithAlpha(val.A * num9);
				for (int j = 0; j < 5; j++)
				{
					float num10 = num8 + (float)j * 0.025f;
					float num11 = num9 * (0.35f / (float)(j + 1));
					((DrawingHandleBase)handle).DrawCircle(vector, num10, ((Color)(ref val2)).WithAlpha(num11), j == 0);
				}
			}
		}
	}

	private string method_6(string string_0, double double_1)
	{
		return "Хитролох_иди_нахуй.__0_2____17_9__4";
	}
}
