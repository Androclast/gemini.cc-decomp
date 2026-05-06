using System;
using System.Collections.Generic;
using System.Numerics;
using Robust.Client.Graphics;
using Robust.Client.Input;
using Robust.Client.Player;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Map.Components;
using Robust.Shared.Maths;
using Robust.Shared.Timing;
using TextureLoader;
using CerberusConfig;

namespace MinecraftVisualsOverlay;

public sealed class MinecraftVisualsOverlay : Overlay
{
	private struct JumpCircle
	{
		public Vector2 E1P36cm6Z8;

		public float vpb3gcYOZQ;

		public MapId xLl3hAvn9S;
	}

	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly IMapManager imapManager_0;

	[Dependency]
	private readonly IInputManager iinputManager_0;

	[Dependency]
	private readonly IEyeManager ieyeManager_0;

	private SharedTransformSystem sharedTransformSystem_0;

	private List<JumpCircle> list_0 = new List<JumpCircle>();

	private Vector2 vector2_0 = Vector2.Zero;

	private Texture[] texture_0 = (Texture[])(object)new Texture[10];

	private Texture[] texture_1 = (Texture[])(object)new Texture[100];

	private Texture[] texture_2 = (Texture[])(object)new Texture[200];

	private bool bool_0;

	private byte byte_1;

	private int int_1;

	private long long_0;

	private byte byte_2;

	public override OverlaySpace Space => (OverlaySpace)64;

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

	public MinecraftVisualsOverlay()
	{
		IoCManager.InjectDependencies<MinecraftVisualsOverlay>(this);
	}

	private void LoadTextures()
	{
		if (bool_0)
		{
			return;
		}
		try
		{
			texture_0[0] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.jumpcircles.circle.png", "circle");
			texture_0[1] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.jumpcircles.circle3.png", "circle3");
			texture_0[2] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.jumpcircles.circle4.png", "circle4");
			texture_0[3] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.jumpcircles.circle5.png", "circle5");
			texture_0[4] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.jumpcircles.glowedcircle.png", "glowedcircle");
			texture_0[5] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.jumpcircles.jump.png", "jump");
			texture_0[6] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.jumpcircles.jump_2.png", "jump_2");
			texture_0[7] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.jumpcircles.konchal.png", "konchal");
			texture_0[8] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.jumpcircles.swastika.png", "swastika");
			texture_0[9] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.particles.svastun.png", "swastun");
			for (int i = 0; i < 100; i++)
			{
				texture_1[i] = TextureLoader.LoadTexture($"Kaban.cc.Resources.Visuals.jumpcircles.animated.animation1.circleframe_{i + 1}.jpeg", $"anim1_frame{i}");
			}
			for (int j = 0; j < 200; j++)
			{
				texture_2[j] = TextureLoader.LoadTexture($"Kaban.cc.Resources.Visuals.jumpcircles.animated.animation2.circleframe_{j + 1}.png", $"anim2_frame{j}");
			}
			bool_0 = true;
		}
		catch (Exception)
		{
		}
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_064e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0650: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0397: Unknown result type (might be due to invalid IL or missing references)
		//IL_039c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03da: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0487: Unknown result type (might be due to invalid IL or missing references)
		//IL_0489: Unknown result type (might be due to invalid IL or missing references)
		if (sharedTransformSystem_0 == null)
		{
			sharedTransformSystem_0 = ientityManager_0.System<SharedTransformSystem>();
		}
		DrawingHandleWorld worldHandle = ((OverlayDrawArgs)(ref args)).WorldHandle;
		float X323jsUs2a = (float)igameTiming_0.RealTime.TotalSeconds;
		LocalPlayer localPlayer = iplayerManager_0.LocalPlayer;
		EntityUid? val = ((localPlayer != null) ? localPlayer.ControlledEntity : ((EntityUid?)null));
		TransformComponent val2 = default(TransformComponent);
		if (!val.HasValue || !ientityManager_0.TryGetComponent<TransformComponent>(val.Value, ref val2))
		{
			return;
		}
		Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(val2);
		MapId mapID = val2.MapID;
		if (CerberusConfig.MinecraftVisuals.JumpCirclesEnabled)
		{
			if (!bool_0)
			{
				LoadTextures();
			}
			if (!((worldPosition - vector2_0).LengthSquared() <= 2.25f))
			{
				list_0.Add(new JumpCircle
				{
					E1P36cm6Z8 = worldPosition,
					vpb3gcYOZQ = X323jsUs2a,
					xLl3hAvn9S = mapID
				});
				vector2_0 = worldPosition;
			}
			float num = 0.2f / CerberusConfig.MinecraftVisuals.JumpCircleFadeInSpeed;
			float num2 = 0.2f / CerberusConfig.MinecraftVisuals.JumpCircleFadeOutSpeed;
			float xBE35OSaWu = num + 0.6f + num2;
			list_0.RemoveAll((JumpCircle c) => X323jsUs2a - c.vpb3gcYOZQ > xBE35OSaWu);
			((DrawingHandleBase)worldHandle).UseShader((ShaderInstance)null);
			Matrix3x2 identity = Matrix3x2.Identity;
			((DrawingHandleBase)worldHandle).SetTransform(ref identity);
			int num3 = Math.Clamp(CerberusConfig.MinecraftVisuals.JumpCircleVariant, 0, 11);
			Color val3 = default(Color);
			((Color)(ref val3))._002Ector(CerberusConfig.MinecraftVisuals.JumpCircleColor.X, CerberusConfig.MinecraftVisuals.JumpCircleColor.Y, CerberusConfig.MinecraftVisuals.JumpCircleColor.Z, CerberusConfig.MinecraftVisuals.JumpCircleColor.W);
			foreach (JumpCircle item in list_0)
			{
				if (item.xLl3hAvn9S != args.MapId)
				{
					continue;
				}
				float num4 = X323jsUs2a - item.vpb3gcYOZQ;
				float value = 1f;
				if (num4 >= num)
				{
					if (num4 > xBE35OSaWu - num2)
					{
						float num5 = (num4 - (xBE35OSaWu - num2)) / num2;
						value = 1f - num5;
					}
				}
				else
				{
					value = 1f;
				}
				value = Math.Clamp(value, 0f, 1f);
				float num6 = 1f;
				if (!(num4 >= num))
				{
					float num7 = num4 / num;
					num7 = 1f - MathF.Pow(1f - num7, 3f);
					num6 = 0.1f + num7 * 0.9f;
				}
				float num8 = 0f;
				if (num3 <= 9 && CerberusConfig.MinecraftVisuals.JumpCircleRotationSpeed > 0f)
				{
					num8 = (0f - num4) * CerberusConfig.MinecraftVisuals.JumpCircleRotationSpeed * (float)Math.PI;
				}
				Texture val4 = null;
				float num9 = num4 / xBE35OSaWu;
				if (num3 > 9)
				{
					if (num3 != 10)
					{
						if (num3 == 11)
						{
							int num10 = (int)(num9 * 199f);
							val4 = texture_2[num10];
						}
					}
					else
					{
						int num11 = (int)(num9 * 99f);
						val4 = texture_1[num11];
					}
				}
				else
				{
					val4 = texture_0[num3];
				}
				if (val4 == null)
				{
					continue;
				}
				float num12 = 1f * num6;
				Box2 val5 = Box2.CenteredAround(item.E1P36cm6Z8, new Vector2(num12, num12));
				Color val6 = ((Color)(ref val3)).WithAlpha(value);
				if ((num3 >= 1 && num3 <= 3) || (num3 >= 7 && num3 <= 11))
				{
					((DrawingHandleBase)worldHandle).Modulate = val6;
					if (num8 != 0f)
					{
						Matrix3x2 matrix3x = Matrix3x2.CreateRotation(num8, item.E1P36cm6Z8);
						((DrawingHandleBase)worldHandle).SetTransform(ref matrix3x);
					}
					worldHandle.DrawTextureRect(val4, val5, (Color?)val6);
					if (num8 != 0f)
					{
						identity = Matrix3x2.Identity;
						((DrawingHandleBase)worldHandle).SetTransform(ref identity);
					}
				}
				else
				{
					((DrawingHandleBase)worldHandle).Modulate = val6;
					if (num8 != 0f)
					{
						Matrix3x2 matrix3x2 = Matrix3x2.CreateRotation(num8, item.E1P36cm6Z8);
						((DrawingHandleBase)worldHandle).SetTransform(ref matrix3x2);
					}
					worldHandle.DrawTextureRect(val4, val5, (Color?)Color.White);
					if (num8 != 0f)
					{
						identity = Matrix3x2.Identity;
						((DrawingHandleBase)worldHandle).SetTransform(ref identity);
					}
				}
				((DrawingHandleBase)worldHandle).Modulate = Color.White;
			}
		}
		if (CerberusConfig.MinecraftVisuals.BlockOutlineEnabled)
		{
			ScreenCoordinates mouseScreenPosition = iinputManager_0.MouseScreenPosition;
			MapCoordinates val7 = ieyeManager_0.PixelToMap(mouseScreenPosition);
			EntityUid val8 = default(EntityUid);
			MapGridComponent val9 = default(MapGridComponent);
			if (val7.MapId == args.MapId && imapManager_0.TryFindGridAt(val7.MapId, val7.Position, ref val8, ref val9))
			{
				TransformComponent component = ientityManager_0.GetComponent<TransformComponent>(val8);
				Matrix3x2 worldMatrix = sharedTransformSystem_0.GetWorldMatrix(component);
				Matrix3x2 invWorldMatrix = sharedTransformSystem_0.GetInvWorldMatrix(component);
				Vector2 vector = Vector2.Transform(val7.Position, invWorldMatrix);
				int num13 = (int)Math.Floor(vector.X / (float)(int)val9.TileSize);
				int num14 = (int)Math.Floor(vector.Y / (float)(int)val9.TileSize);
				Vector2i val10 = default(Vector2i);
				((Vector2i)(ref val10))._002Ector(num13, num14);
				float num15 = (int)val9.TileSize;
				Vector2 vector2 = new Vector2((float)val10.X * num15, (float)val10.Y * num15);
				Vector2 vector3 = vector2 + new Vector2(num15, num15);
				Box2 val11 = default(Box2);
				((Box2)(ref val11))._002Ector(vector2, vector3);
				((DrawingHandleBase)worldHandle).SetTransform(ref worldMatrix);
				((DrawingHandleBase)worldHandle).UseShader((ShaderInstance)null);
				worldHandle.DrawRect(val11, Color.Black, false);
				Box2 val12 = ((Box2)(ref val11)).Enlarged(-0.05f);
				Color white = Color.White;
				worldHandle.DrawRect(val12, ((Color)(ref white)).WithAlpha(0.3f), false);
				Matrix3x2 identity = Matrix3x2.Identity;
				((DrawingHandleBase)worldHandle).SetTransform(ref identity);
			}
		}
	}

	private string method_4(string string_0)
	{
		return "Хитролох_иди_нахуй.____48_________8_____";
	}
}
