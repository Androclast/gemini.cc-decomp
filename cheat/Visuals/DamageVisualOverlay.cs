using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Content.Client.Damage.Systems;
using Content.Shared.Damage.Components;
using Content.Shared.Damage.Systems;
using Content.Shared.Mobs.Components;
using Content.Shared.StatusIcon.Components;
using Robust.Client.GameObjects;
using Robust.Client.Graphics;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.Graphics;
using Robust.Shared.IoC;
using Robust.Shared.Maths;
using CerberusConfig;

[CompilerGenerated]
public sealed class DamageVisualOverlay : Overlay
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	private SharedTransformSystem sharedTransformSystem_0;

	private StaminaSystem staminaSystem_0;

	private char char_0;

	private char char_1;

	public override OverlaySpace Space => (OverlaySpace)8;

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

	public DamageVisualOverlay()
	{
		IoCManager.InjectDependencies<DamageVisualOverlay>(this);
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Invalid comparison between Unknown and I4
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_041e: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_037e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0383: Unknown result type (might be due to invalid IL or missing references)
		//IL_0357: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_0458: Unknown result type (might be due to invalid IL or missing references)
		//IL_045a: Unknown result type (might be due to invalid IL or missing references)
		//IL_045f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0468: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.Hud.ShowStamina)
		{
			return;
		}
		if (sharedTransformSystem_0 == null)
		{
			sharedTransformSystem_0 = ientityManager_0.System<SharedTransformSystem>();
		}
		if (staminaSystem_0 == null)
		{
			staminaSystem_0 = ientityManager_0.System<StaminaSystem>();
		}
		if (sharedTransformSystem_0 == null || staminaSystem_0 == null)
		{
			return;
		}
		DrawingHandleWorld worldHandle = ((OverlayDrawArgs)(ref args)).WorldHandle;
		IEye eye = args.Viewport.Eye;
		Angle val = ((eye == null) ? Angle.Zero : eye.Rotation);
		EntityQuery<TransformComponent> entityQuery = ientityManager_0.GetEntityQuery<TransformComponent>();
		Vector2 vector = new Vector2(1f, 1f);
		Matrix3x2 value = Matrix3Helpers.CreateScale(ref vector);
		Matrix3x2 value2 = Matrix3Helpers.CreateRotation(Angle.op_Implicit(-val));
		AllEntityQueryEnumerator<StaminaComponent, MobStateComponent, SpriteComponent> val2 = ientityManager_0.AllEntityQueryEnumerator<StaminaComponent, MobStateComponent, SpriteComponent>();
		EntityUid val3 = default(EntityUid);
		StaminaComponent stam = default(StaminaComponent);
		MobStateComponent val4 = default(MobStateComponent);
		SpriteComponent val5 = default(SpriteComponent);
		TransformComponent val6 = default(TransformComponent);
		Box2 val9 = default(Box2);
		Box2 val11 = default(Box2);
		Box2 val12 = default(Box2);
		while (val2.MoveNext(ref val3, ref stam, ref val4, ref val5))
		{
			if (!entityQuery.TryGetComponent(val3, ref val6) || val6.MapID != args.MapId || (int)val4.CurrentState == 3)
			{
				continue;
			}
			Box2 val7 = (Box2)(((_003F?)EntityManagerExt.GetComponentOrNull<StatusIconComponent>(ientityManager_0, val3)?.Bounds) ?? val5.Bounds);
			Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(val6, entityQuery);
			Box2 worldAABB = args.WorldAABB;
			Box2 val8 = ((Box2)(ref val7)).Translated(worldPosition);
			if (((Box2)(ref val8)).Intersects(ref worldAABB))
			{
				(float, bool)? tuple = CalcProgress(val3, staminaSystem_0, stam);
				if (tuple.HasValue)
				{
					float item = tuple.Value.Item1;
					Matrix3x2 value3 = Matrix3Helpers.CreateTranslation(sharedTransformSystem_0.GetWorldPosition(val6));
					Matrix3x2 value4 = Matrix3x2.Multiply(value, value3);
					Matrix3x2 matrix3x = Matrix3x2.Multiply(value2, value4);
					((DrawingHandleBase)worldHandle).SetTransform(ref matrix3x);
					float staminaBarOffsetX = CerberusConfig.Hud.StaminaBarOffsetX;
					float staminaBarOffsetY = CerberusConfig.Hud.StaminaBarOffsetY;
					float staminaBarWidth = CerberusConfig.Hud.StaminaBarWidth;
					float staminaBarHeight = CerberusConfig.Hud.StaminaBarHeight;
					float num = ((Box2)(ref val7)).Height * 32f / 2f + staminaBarOffsetY;
					float num2 = ((staminaBarWidth <= 0f) ? (((Box2)(ref val7)).Width * 32f) : staminaBarWidth);
					Vector2 vector2 = new Vector2((0f - num2) / 32f / 2f + staminaBarOffsetX / 32f, num / 32f);
					float num3 = num2 - 8f;
					float x = num3 * item + 8f;
					float num4 = ((staminaBarHeight <= 0f) ? 3f : staminaBarHeight);
					((Box2)(ref val9))._002Ector(new Vector2(8f, 0f) / 32f, new Vector2(num3 + 8f, num4) / 32f);
					val9 = ((Box2)(ref val9)).Translated(vector2);
					Box2 val10 = val9;
					Color black = Color.Black;
					worldHandle.DrawRect(val10, ((Color)(ref black)).WithAlpha((byte)192), true);
					((Box2)(ref val11))._002Ector(new Vector2(8f, 0f) / 32f, new Vector2(x, num4) / 32f);
					val11 = ((Box2)(ref val11)).Translated(vector2);
					worldHandle.DrawRect(val11, new Color(ref CerberusConfig.Hud.StaminaColor), true);
					((Box2)(ref val12))._002Ector(new Vector2(8f, num4 - 1f) / 32f, new Vector2(x, num4) / 32f);
					val12 = ((Box2)(ref val12)).Translated(vector2);
					Box2 val13 = val12;
					black = Color.Black;
					worldHandle.DrawRect(val13, ((Color)(ref black)).WithAlpha((byte)128), true);
				}
			}
		}
		Matrix3x2 identity = Matrix3x2.Identity;
		((DrawingHandleBase)worldHandle).SetTransform(ref identity);
	}

	private (float, bool)? CalcProgress(EntityUid uid, StaminaSystem staminaSystem, StaminaComponent stam)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		(float, bool)? result;
		if (stam.CritThreshold <= 0f)
		{
			result = null;
		}
		else
		{
			float staminaDamage = ((SharedStaminaSystem)staminaSystem).GetStaminaDamage(uid, stam);
			float value = 1f - staminaDamage / stam.CritThreshold;
			result = (Math.Clamp(value, 0f, 1f), stam.Critical);
		}
		return result;
	}
}
