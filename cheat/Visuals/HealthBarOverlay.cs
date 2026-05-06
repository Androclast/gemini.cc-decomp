using System;
using System.Collections;
using System.Numerics;
using System.Reflection;
using Content.Client.StatusIcon;
using Content.Client.UserInterface.Systems;
using Content.Shared.Damage.Components;
using Content.Shared.Mobs;
using Content.Shared.Mobs.Components;
using Content.Shared.Mobs.Systems;
using Content.Shared.StatusIcon.Components;
using HarmonyLib;
using Robust.Client.GameObjects;
using Robust.Client.Graphics;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.Graphics;
using Robust.Shared.IoC;
using Robust.Shared.Maths;
using DamageableHelper;
using CerberusConfig;

public class HealthBarOverlay : Overlay
{
	[Dependency]
	private readonly IEntityManager entity;

	private readonly SharedTransformSystem sharedTransformSystem_0;

	private readonly MobStateSystem mobStateSystem_0;

	private readonly MobThresholdSystem mobThresholdSystem_0;

	private readonly StatusIconSystem statusIconSystem_0;

	private readonly ProgressColorSystem progressColorSystem_0;

	private static bool bool_0 = true;

	private static bool bool_1 = false;

	private static FieldInfo? fieldInfo_0;

	private static bool bool_2 = false;

	private int int_0;

	private double double_0;

	private long long_0;

	public override OverlaySpace Space => (OverlaySpace)8;

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

	public HealthBarOverlay(IEntityManager entity)
	{
		IoCManager.InjectDependencies<HealthBarOverlay>(this);
		this.entity = entity;
		sharedTransformSystem_0 = this.entity.System<SharedTransformSystem>();
		mobStateSystem_0 = this.entity.System<MobStateSystem>();
		mobThresholdSystem_0 = this.entity.System<MobThresholdSystem>();
		statusIconSystem_0 = this.entity.System<StatusIconSystem>();
		progressColorSystem_0 = this.entity.System<ProgressColorSystem>();
		DamageableHelper.Initialize();
		if (!bool_2 && !bool_0)
		{
			InitializeReflectionCache();
		}
	}

	private static void InitializeReflectionCache()
	{
		if (bool_2)
		{
			return;
		}
		bool_2 = true;
		try
		{
			fieldInfo_0 = AccessTools.Field(typeof(MobThresholdsComponent), "_thresholds");
		}
		catch
		{
		}
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.Hud.ShowHealth)
		{
			return;
		}
		int_0++;
		if (int_0 < 1)
		{
			return;
		}
		int_0 = 0;
		DrawingHandleWorld worldHandle = ((OverlayDrawArgs)(ref args)).WorldHandle;
		IEye eye = args.Viewport.Eye;
		Angle val = ((eye == null) ? Angle.Zero : eye.Rotation);
		EntityQuery<TransformComponent> entityQuery = entity.GetEntityQuery<TransformComponent>();
		Vector2 vector = new Vector2(1f, 1f);
		Matrix3x2 scaleMatrix = Matrix3Helpers.CreateScale(ref vector);
		Matrix3x2 rotationMatrix = Matrix3Helpers.CreateRotation(Angle.op_Implicit(-val));
		if (bool_0)
		{
			try
			{
				DrawFastPath(in args, worldHandle, entityQuery, scaleMatrix, rotationMatrix);
				if (!bool_1)
				{
					bool_1 = true;
				}
				return;
			}
			catch (Exception)
			{
				bool_0 = false;
				InitializeReflectionCache();
			}
		}
		DrawReflectionPath(in args, worldHandle, entityQuery, scaleMatrix, rotationMatrix);
	}

	private void DrawFastPath(in OverlayDrawArgs args, DrawingHandleWorld worldHandle, EntityQuery<TransformComponent> entityQuery, Matrix3x2 scaleMatrix, Matrix3x2 rotationMatrix)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Invalid comparison between Unknown and I4
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		AllEntityQueryEnumerator<DamageableComponent, MobStateComponent, SpriteComponent> val = entity.AllEntityQueryEnumerator<DamageableComponent, MobStateComponent, SpriteComponent>();
		EntityUid val2 = default(EntityUid);
		DamageableComponent damageableComp = default(DamageableComponent);
		MobStateComponent val3 = default(MobStateComponent);
		SpriteComponent spriteComponent = default(SpriteComponent);
		TransformComponent val4 = default(TransformComponent);
		while (val.MoveNext(ref val2, ref damageableComp, ref val3, ref spriteComponent))
		{
			if ((int)val3.CurrentState != 3 && entityQuery.TryGetComponent(val2, ref val4) && !(val4.MapID != args.MapId))
			{
				MobThresholdsComponent thresholds = null;
				entity.TryGetComponent<MobThresholdsComponent>(val2, ref thresholds);
				(float, bool)? tuple = CalcProgressFast(val2, val3, damageableComp, thresholds);
				if (tuple.HasValue)
				{
					var (ratio, inCrit) = tuple.Value;
					DrawHealthBar(worldHandle, val2, spriteComponent, val4, scaleMatrix, rotationMatrix, ratio, inCrit);
				}
			}
		}
		Matrix3x2 identity = Matrix3x2.Identity;
		((DrawingHandleBase)worldHandle).SetTransform(ref identity);
	}

	private void DrawReflectionPath(in OverlayDrawArgs args, DrawingHandleWorld worldHandle, EntityQuery<TransformComponent> entityQuery, Matrix3x2 scaleMatrix, Matrix3x2 rotationMatrix)
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Invalid comparison between Unknown and I4
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		AllEntityQueryEnumerator<MobStateComponent, SpriteComponent> val = entity.AllEntityQueryEnumerator<MobStateComponent, SpriteComponent>();
		EntityUid val2 = default(EntityUid);
		MobStateComponent val3 = default(MobStateComponent);
		SpriteComponent spriteComponent = default(SpriteComponent);
		TransformComponent val4 = default(TransformComponent);
		while (val.MoveNext(ref val2, ref val3, ref spriteComponent))
		{
			if ((int)val3.CurrentState != 3 && entityQuery.TryGetComponent(val2, ref val4) && !(val4.MapID != args.MapId) && DamageableHelper.TryGetDamageableComponent(val2, entity, out object component) && component != null)
			{
				MobThresholdsComponent thresholds = null;
				entity.TryGetComponent<MobThresholdsComponent>(val2, ref thresholds);
				(float, bool)? tuple = CalcProgressReflection(val2, val3, component, thresholds);
				if (tuple.HasValue)
				{
					var (ratio, inCrit) = tuple.Value;
					DrawHealthBar(worldHandle, val2, spriteComponent, val4, scaleMatrix, rotationMatrix, ratio, inCrit);
				}
			}
		}
		Matrix3x2 identity = Matrix3x2.Identity;
		((DrawingHandleBase)worldHandle).SetTransform(ref identity);
	}

	private void DrawHealthBar(DrawingHandleWorld worldHandle, EntityUid entityUid, SpriteComponent spriteComponent, TransformComponent transformComponent, Matrix3x2 scaleMatrix, Matrix3x2 rotationMatrix, float ratio, bool inCrit)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		Box2 val = (Box2)(((_003F?)EntityManagerExt.GetComponentOrNull<StatusIconComponent>(entity, entityUid)?.Bounds) ?? spriteComponent.Bounds);
		Matrix3x2 value = Matrix3Helpers.CreateTranslation(sharedTransformSystem_0.GetWorldPosition(transformComponent));
		Matrix3x2 value2 = Matrix3x2.Multiply(scaleMatrix, value);
		value2 = Matrix3x2.Multiply(rotationMatrix, value2);
		((DrawingHandleBase)worldHandle).SetTransform(ref value2);
		float healthBarOffsetX = CerberusConfig.Hud.HealthBarOffsetX;
		float healthBarOffsetY = CerberusConfig.Hud.HealthBarOffsetY;
		float healthBarWidth = CerberusConfig.Hud.HealthBarWidth;
		float healthBarHeight = CerberusConfig.Hud.HealthBarHeight;
		float num = ((Box2)(ref val)).Height * 32f / 2f + healthBarOffsetY;
		float num2 = ((!(healthBarWidth <= 0f)) ? healthBarWidth : Math.Max(((Box2)(ref val)).Width * 32f, 32f));
		Vector2 vector = new Vector2((0f - num2) / 32f / 2f + healthBarOffsetX / 32f, num / 32f);
		Color progressColor = GetProgressColor(ratio, inCrit);
		float num3 = num2 - 8f;
		float num4 = num3 * ratio + 8f;
		float num5 = ((healthBarHeight <= 0f) ? 3f : healthBarHeight);
		Box2 val2 = default(Box2);
		((Box2)(ref val2))._002Ector(new Vector2(8f, 0f) / 32f, new Vector2(num3 + 8f, num5) / 32f);
		val2 = ((Box2)(ref val2)).Translated(vector);
		Box2 val3 = val2;
		Color black = Color.Black;
		worldHandle.DrawRect(val3, ((Color)(ref black)).WithAlpha((byte)192), true);
		if (num4 > 8f)
		{
			Box2 val4 = default(Box2);
			((Box2)(ref val4))._002Ector(new Vector2(8f, 0f) / 32f, new Vector2(num4, num5) / 32f);
			val4 = ((Box2)(ref val4)).Translated(vector);
			worldHandle.DrawRect(val4, progressColor, true);
		}
		Box2 val5 = default(Box2);
		((Box2)(ref val5))._002Ector(new Vector2(8f, num5 - 1f) / 32f, new Vector2(num4, num5) / 32f);
		val5 = ((Box2)(ref val5)).Translated(vector);
		Box2 val6 = val5;
		black = Color.Black;
		worldHandle.DrawRect(val6, ((Color)(ref black)).WithAlpha((byte)128), true);
	}

	private (float ratio, bool inCrit)? CalcProgressFast(EntityUid uid, MobStateComponent comp, DamageableComponent damageableComp, MobThresholdsComponent? thresholds)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Invalid comparison between Unknown and I4
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Invalid comparison between Unknown and I4
		if (damageableComp != null)
		{
			float totalDamage = DamageableHelper.GetTotalDamage(damageableComp);
			float num = 100f;
			float num2 = 100f;
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
							else if ((int)val == 3)
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
			if (mobStateSystem_0.IsAlive(uid, comp))
			{
				return (Math.Clamp(1f - totalDamage / Math.Max(num, 0.1f), 0f, 1f), false);
			}
			if (!mobStateSystem_0.IsCritical(uid, comp))
			{
				return null;
			}
			float num4 = num2 - num;
			if (num4 > 0.1f)
			{
				return (Math.Clamp(1f - (totalDamage - num) / num4, 0f, 1f), true);
			}
			return (0f, true);
		}
		return null;
	}

	private (float ratio, bool inCrit)? CalcProgressReflection(EntityUid uid, MobStateComponent comp, object damageableComp, MobThresholdsComponent? thresholds)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Invalid comparison between Unknown and I4
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Invalid comparison between Unknown and I4
		if (damageableComp != null)
		{
			float totalDamage = DamageableHelper.GetTotalDamage(damageableComp);
			float num = 100f;
			float num2 = 100f;
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
							if ((int)val != 2)
							{
								if ((int)val == 3)
								{
									num2 = num3;
								}
							}
							else
							{
								num = num3;
							}
						}
					}
				}
				catch
				{
				}
			}
			if (!mobStateSystem_0.IsAlive(uid, comp))
			{
				if (mobStateSystem_0.IsCritical(uid, comp))
				{
					float num4 = num2 - num;
					if (num4 > 0.1f)
					{
						return (Math.Clamp(1f - (totalDamage - num) / num4, 0f, 1f), true);
					}
					return (0f, true);
				}
				return null;
			}
			return (Math.Clamp(1f - totalDamage / Math.Max(num, 0.1f), 0f, 1f), false);
		}
		return null;
	}

	public Color GetProgressColor(float progress, bool crit)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		if (!crit)
		{
			if (progress <= 0.5f)
			{
				return Color.InterpolateBetween(Color.Red, Color.Yellow, progress * 2f);
			}
			return Color.InterpolateBetween(Color.Yellow, Color.LimeGreen, (progress - 0.5f) * 2f);
		}
		return Color.Red;
	}
}
