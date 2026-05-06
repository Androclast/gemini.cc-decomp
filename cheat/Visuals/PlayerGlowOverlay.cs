using System;
using System.Numerics;
using Robust.Client.GameObjects;
using Robust.Client.Graphics;
using Robust.Client.Player;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.Graphics.RSI;
using Robust.Shared.IoC;
using Robust.Shared.Maths;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using TextureLoader;
using CerberusConfig;

namespace PlayerGlowOverlay;

public sealed class PlayerGlowOverlay : Overlay
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly IEyeManager ieyeManager_0;

	private SharedTransformSystem sharedTransformSystem_0;

	private SpriteSystem spriteSystem_0;

	private Texture texture_0;

	private bool bool_0;

	private string string_0;

	private float float_0;

	public override OverlaySpace Space => (OverlaySpace)4;

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
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	public PlayerGlowOverlay()
	{
		IoCManager.InjectDependencies<PlayerGlowOverlay>(this);
	}

	private void LoadTexture()
	{
		if (bool_0)
		{
			return;
		}
		try
		{
			texture_0 = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.world.bloom.png", "player_glow_bloom");
			bool_0 = true;
		}
		catch (Exception)
		{
		}
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.PlayerGlow.Enabled)
		{
			return;
		}
		if (!bool_0)
		{
			LoadTexture();
		}
		if (texture_0 != null)
		{
			if (sharedTransformSystem_0 == null)
			{
				sharedTransformSystem_0 = ientityManager_0.System<SharedTransformSystem>();
				spriteSystem_0 = ientityManager_0.System<SpriteSystem>();
			}
			ICommonSession localSession = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
			EntityUid? val = ((localSession != null) ? localSession.AttachedEntity : ((EntityUid?)null));
			TransformComponent val2 = default(TransformComponent);
			SpriteComponent sprite = default(SpriteComponent);
			if (val.HasValue && ientityManager_0.TryGetComponent<TransformComponent>(val.Value, ref val2) && ientityManager_0.TryGetComponent<SpriteComponent>(val.Value, ref sprite) && !(val2.MapID != args.MapId))
			{
				ValueTuple<Vector2, Angle> worldPositionRotation = sharedTransformSystem_0.GetWorldPositionRotation(val2);
				Vector2 item = worldPositionRotation.Item1;
				Angle item2 = worldPositionRotation.Item2;
				float time = (float)igameTiming_0.RealTime.TotalSeconds;
				float glowSize = CerberusConfig.PlayerGlow.GlowSize;
				int glowDensity = CerberusConfig.PlayerGlow.GlowDensity;
				Vector4 glowColor = CerberusConfig.PlayerGlow.GlowColor;
				Color color = default(Color);
				((Color)(ref color))._002Ector(glowColor.X, glowColor.Y, glowColor.Z, glowColor.W);
				Angle rotation = ieyeManager_0.CurrentEye.Rotation;
				DrawingHandleWorld worldHandle = ((OverlayDrawArgs)(ref args)).WorldHandle;
				((DrawingHandleBase)worldHandle).UseShader((ShaderInstance)null);
				DrawGlowAroundSprite(worldHandle, sprite, item, item2, rotation, glowSize, glowDensity, color, time);
			}
		}
	}

	private void DrawGlowAroundSprite(DrawingHandleWorld handle, SpriteComponent sprite, Vector2 worldPos, Angle worldRot, Angle eyeRot, float glowSize, int density, Color color, float time)
	{
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		float num = 0.8f + MathF.Sin(time * 2f) * 0.2f;
		float glowSize2 = glowSize * num;
		Angle val = ((!sprite.NoRotation) ? worldRot : (-eyeRot));
		foreach (ISpriteLayer allLayer in sprite.AllLayers)
		{
			if (!allLayer.Visible)
			{
				continue;
			}
			Layer val2 = (Layer)(object)((allLayer is Layer) ? allLayer : null);
			if (val2 == null)
			{
				continue;
			}
			State actualState = val2.ActualState;
			Texture texture = val2.Texture;
			Angle val3 = worldRot + eyeRot;
			val3 = ((Angle)(ref val3)).Reduced();
			Angle val4 = ((Angle)(ref val3)).FlipPositive();
			RsiDirection val5 = (RsiDirection)((actualState != null) ? ((int)Layer.GetDirection(actualState.RsiDirections, val4)) : 0);
			Texture val6 = ((actualState == null) ? texture : (actualState.GetFrame(val5, val2.AnimationFrame) ?? texture));
			if (val6 != null && val6.Size.X != 0 && val6.Size.Y != 0)
			{
				Vector2 size = Vector2i.op_Implicit(val6.Size) / 32f;
				if (!(size.X <= 0f) && !(size.Y <= 0f))
				{
					Vector2 vector = val2.Scale * sprite.Scale;
					Vector2 vector2 = val2.Offset + sprite.Offset;
					Matrix3x2 value = Matrix3Helpers.CreateTransform(ref worldPos, ref val);
					val3 = sprite.Rotation + val2.Rotation;
					Matrix3x2 layerTransform = Matrix3x2.Multiply(Matrix3Helpers.CreateTransform(ref vector2, ref val3, ref vector), value);
					DrawGlowOutlineForLayer(handle, layerTransform, size, glowSize2, density, color, time);
				}
			}
		}
	}

	private void DrawGlowOutlineForLayer(DrawingHandleWorld handle, Matrix3x2 layerTransform, Vector2 size, float glowSize, int density, Color color, float time)
	{
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		float num = size.X / 2f;
		float num2 = size.Y / 2f;
		int num3 = Math.Max(2, density / 4);
		for (int i = 0; i <= num3; i++)
		{
			float num4 = (float)i / (float)num3;
			float x = 0f - num + size.X * num4;
			float y = 0f - num2;
			Vector2 localPos = new Vector2(x, y);
			DrawGlowParticle(handle, layerTransform, localPos, glowSize, color, time, i);
		}
		for (int j = 1; j <= num3; j++)
		{
			float num5 = (float)j / (float)num3;
			float x2 = num;
			float y2 = 0f - num2 + size.Y * num5;
			Vector2 localPos2 = new Vector2(x2, y2);
			DrawGlowParticle(handle, layerTransform, localPos2, glowSize, color, time, j + num3);
		}
		for (int k = 1; k <= num3; k++)
		{
			float num6 = (float)k / (float)num3;
			float x3 = num - size.X * num6;
			float y3 = num2;
			Vector2 localPos3 = new Vector2(x3, y3);
			DrawGlowParticle(handle, layerTransform, localPos3, glowSize, color, time, k + num3 * 2);
		}
		for (int l = 1; l < num3; l++)
		{
			float num7 = (float)l / (float)num3;
			float x4 = 0f - num;
			float y4 = num2 - size.Y * num7;
			Vector2 localPos4 = new Vector2(x4, y4);
			DrawGlowParticle(handle, layerTransform, localPos4, glowSize, color, time, l + num3 * 3);
		}
	}

	private void DrawGlowParticle(DrawingHandleWorld handle, Matrix3x2 layerTransform, Vector2 localPos, float size, Color color, float time, int index)
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		float num = MathF.Sin(time * 3f + (float)index * 0.5f) * 0.02f;
		Vector2 vector = Vector2.Transform(localPos + new Vector2(num, num), layerTransform);
		((DrawingHandleBase)handle).Modulate = color;
		Box2 val = Box2.CenteredAround(vector, new Vector2(size, size));
		handle.DrawTextureRect(texture_0, val, (Color?)Color.White);
		((DrawingHandleBase)handle).Modulate = ((Color)(ref color)).WithAlpha(color.A * 0.5f);
		Box2 val2 = Box2.CenteredAround(vector, new Vector2(size * 1.5f, size * 1.5f));
		handle.DrawTextureRect(texture_0, val2, (Color?)Color.White);
		((DrawingHandleBase)handle).Modulate = ((Color)(ref color)).WithAlpha(color.A * 0.25f);
		Box2 val3 = Box2.CenteredAround(vector, new Vector2(size * 2f, size * 2f));
		handle.DrawTextureRect(texture_0, val3, (Color?)Color.White);
		((DrawingHandleBase)handle).Modulate = Color.White;
	}

	private string method_8(float float_1)
	{
		return "Хитролох_иди_нахуй._____82____0";
	}
}
