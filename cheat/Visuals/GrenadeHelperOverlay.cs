using System;
using System.Collections.Generic;
using System.Numerics;
using Content.Shared.Atmos.Components;
using Content.Shared.Explosion.Components;
using Content.Shared.Hands.Components;
using Content.Shared.Hands.EntitySystems;
using Content.Shared.Throwing;
using Content.Shared.Trigger.Components;
using Robust.Client.Graphics;
using Robust.Client.Input;
using Robust.Client.Player;
using Robust.Client.ResourceManagement;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Map.Components;
using Robust.Shared.Maths;
using Robust.Shared.Physics;
using Robust.Shared.Physics.Components;
using Robust.Shared.Physics.Systems;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using CerberusConfig;

namespace GrenadeHelperOverlay;

public sealed class GrenadeHelperOverlay : Overlay
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IEyeManager ieyeManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly IResourceCache iresourceCache_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IInputManager iinputManager_0;

	[Dependency]
	private readonly IMapManager imapManager_0;

	private SharedPhysicsSystem sharedPhysicsSystem_0;

	private SharedTransformSystem sharedTransformSystem_0;

	private SharedHandsSystem sharedHandsSystem_0;

	private readonly Font font_0;

	private int int_1;

	private byte byte_0;

	private bool bool_0;

	public override OverlaySpace Space => (OverlaySpace)6;

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
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public GrenadeHelperOverlay()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		IoCManager.InjectDependencies<GrenadeHelperOverlay>(this);
		font_0 = (Font)new VectorFont(iresourceCache_0.GetResource<FontResource>("/Fonts/Boxfont-round/Boxfont Round.ttf", true), 12);
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Invalid comparison between Unknown and I4
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Invalid comparison between Unknown and I4
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.GrenadeHelper.Enabled)
		{
			return;
		}
		if (sharedPhysicsSystem_0 == null)
		{
			sharedPhysicsSystem_0 = ientityManager_0.System<SharedPhysicsSystem>();
		}
		if (sharedTransformSystem_0 == null)
		{
			sharedTransformSystem_0 = ientityManager_0.System<SharedTransformSystem>();
		}
		if (sharedHandsSystem_0 == null)
		{
			sharedHandsSystem_0 = ientityManager_0.System<SharedHandsSystem>();
		}
		if ((int)args.Space != 4)
		{
			if ((int)args.Space == 2)
			{
				DrawScreen(args);
			}
		}
		else
		{
			DrawWorld(args);
		}
	}

	private void DrawWorld(OverlayDrawArgs args)
	{
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		DrawingHandleWorld worldHandle = ((OverlayDrawArgs)(ref args)).WorldHandle;
		EntityQueryEnumerator<ActiveTimerTriggerComponent, TransformComponent> val = ientityManager_0.EntityQueryEnumerator<ActiveTimerTriggerComponent, TransformComponent>();
		EntityUid val2 = default(EntityUid);
		ActiveTimerTriggerComponent val3 = default(ActiveTimerTriggerComponent);
		TransformComponent val4 = default(TransformComponent);
		PhysicsComponent val5 = default(PhysicsComponent);
		while (val.MoveNext(ref val2, ref val3, ref val4))
		{
			if (val4.MapID != args.MapId || !IsActualGrenade(val2))
			{
				continue;
			}
			if (CerberusConfig.GrenadeHelper.ShowRadius)
			{
				float explosionRadius = GetExplosionRadius(val2);
				if (explosionRadius > 0f)
				{
					DrawExplosionGrid(worldHandle, val4, explosionRadius);
				}
			}
			if (CerberusConfig.GrenadeHelper.ShowTrajectory && ientityManager_0.TryGetComponent<PhysicsComponent>(val2, ref val5) && val5.LinearVelocity.LengthSquared() > 0.1f)
			{
				SimulatePhysicsTrajectory(worldHandle, val4.Coordinates, val5.LinearVelocity, val5.LinearDamping, val2);
			}
		}
		if (!CerberusConfig.GrenadeHelper.ShowTrajectory && !CerberusConfig.GrenadeHelper.ShowRadius)
		{
			return;
		}
		ICommonSession localSession = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
		EntityUid? val6 = ((localSession == null) ? ((EntityUid?)null) : localSession.AttachedEntity);
		HandsComponent val7 = default(HandsComponent);
		EntityUid? val8 = default(EntityUid?);
		if (!val6.HasValue || !ientityManager_0.TryGetComponent<HandsComponent>(val6.Value, ref val7) || !sharedHandsSystem_0.TryGetActiveItem(Entity<HandsComponent>.op_Implicit((val6.Value, val7)), ref val8))
		{
			return;
		}
		EntityUid value = val8.Value;
		if (!IsActualGrenade(value))
		{
			return;
		}
		MapCoordinates mapCoordinates = sharedTransformSystem_0.GetMapCoordinates(val6.Value, (TransformComponent)null);
		MapCoordinates val9 = ieyeManager_0.PixelToMap(iinputManager_0.MouseScreenPosition);
		if (!(mapCoordinates.MapId == val9.MapId))
		{
			return;
		}
		float num = val7.ThrowRange;
		if (num <= 0f)
		{
			num = 10f;
		}
		Vector2 vector = val9.Position - mapCoordinates.Position;
		float num2 = vector.Length();
		if (!(num2 <= num))
		{
			vector = Vector2.Normalize(vector) * num;
			num2 = num;
		}
		float num3 = 18f;
		_ = Vector2.Zero;
		if (num2 > 0.1f)
		{
			_ = Vector2.Normalize(vector) * num3;
		}
		float damping = 0.2f;
		PhysicsComponent val10 = default(PhysicsComponent);
		if (ientityManager_0.TryGetComponent<PhysicsComponent>(value, ref val10))
		{
			damping = val10.LinearDamping;
		}
		Vector2 vector2 = SimulateThrowTrajectoryWithCollision(worldHandle, mapCoordinates, vector, damping, val6.Value, num);
		if (CerberusConfig.GrenadeHelper.ShowRadius)
		{
			float explosionRadius2 = GetExplosionRadius(value);
			EntityUid val11 = default(EntityUid);
			MapGridComponent grid = default(MapGridComponent);
			if (explosionRadius2 > 0f && imapManager_0.TryFindGridAt(mapCoordinates.MapId, vector2, ref val11, ref grid))
			{
				TransformComponent component = ientityManager_0.GetComponent<TransformComponent>(val11);
				DrawExplosionGridAtPosition(worldHandle, vector2, explosionRadius2, grid, component);
			}
		}
	}

	private bool IsActualGrenade(EntityUid uid)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		if (ientityManager_0.HasComponent<ExplosiveComponent>(uid) || ientityManager_0.HasComponent<TimerTriggerComponent>(uid))
		{
			if (!ientityManager_0.HasComponent<GasTankComponent>(uid))
			{
				MetaDataComponent val = default(MetaDataComponent);
				if (ientityManager_0.TryGetComponent<MetaDataComponent>(uid, ref val))
				{
					string text = val.EntityName.ToLower();
					if (text.Contains("tank") || text.Contains("canister") || text.Contains("cylinder"))
					{
						return false;
					}
					if (text.Contains("grenade") || text.Contains("explosive") || text.Contains("bomb"))
					{
						return true;
					}
				}
				return ientityManager_0.HasComponent<ExplosiveComponent>(uid);
			}
			return false;
		}
		return false;
	}

	private float GetExplosionRadius(EntityUid uid)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		ExplosiveComponent val = default(ExplosiveComponent);
		if (ientityManager_0.TryGetComponent<ExplosiveComponent>(uid, ref val) && val.TotalIntensity > 0f)
		{
			float num = ((val.IntensitySlope <= 0f) ? 1f : val.IntensitySlope);
			return MathF.Pow(val.TotalIntensity / num, 1f / 3f);
		}
		return 0f;
	}

	private void DrawExplosionGrid(DrawingHandleWorld handle, TransformComponent xform, float radius)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(xform);
		EntityUid val = default(EntityUid);
		MapGridComponent grid = default(MapGridComponent);
		if (imapManager_0.TryFindGridAt(xform.MapID, worldPosition, ref val, ref grid))
		{
			TransformComponent component = ientityManager_0.GetComponent<TransformComponent>(val);
			DrawExplosionGridAtPosition(handle, worldPosition, radius, grid, component);
		}
	}

	private void DrawExplosionGridAtPosition(DrawingHandleWorld handle, Vector2 worldPos, float radius, MapGridComponent grid, TransformComponent gridXform)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		Matrix3x2 invWorldMatrix = sharedTransformSystem_0.GetInvWorldMatrix(gridXform);
		Vector2 vector = Vector2.Transform(worldPos, invWorldMatrix);
		int num = (int)Math.Floor(vector.X / (float)(int)grid.TileSize);
		int num2 = (int)Math.Floor(vector.Y / (float)(int)grid.TileSize);
		int num3 = (int)Math.Ceiling(radius);
		Matrix3x2 worldMatrix = sharedTransformSystem_0.GetWorldMatrix(gridXform);
		((DrawingHandleBase)handle).SetTransform(ref worldMatrix);
		Color val = new Color(ref CerberusConfig.GrenadeHelper.RadiusColor);
		HashSet<Vector2i> hashSet = new HashSet<Vector2i>();
		for (int i = -num3; i <= num3; i++)
		{
			for (int j = -num3; j <= num3; j++)
			{
				if ((float)(i * i + j * j) <= radius * radius)
				{
					hashSet.Add(new Vector2i(num + i, num2 + j));
				}
			}
		}
		float num4 = 0.08f;
		foreach (Vector2i item in hashSet)
		{
			Vector2 vector2 = new Vector2(item.X * grid.TileSize, item.Y * grid.TileSize);
			Vector2 vector3 = vector2 + new Vector2((int)grid.TileSize, (int)grid.TileSize);
			if (hashSet.Contains(new Vector2i(item.X - 1, item.Y)))
			{
				goto IL_01c3;
			}
			goto IL_023f;
			IL_01c3:
			if (!hashSet.Contains(new Vector2i(item.X + 1, item.Y)))
			{
				for (float num5 = 0f - num4; !(num5 > num4); num5 += num4 / 2f)
				{
					((DrawingHandleBase)handle).DrawLine(new Vector2(vector3.X + num5, vector2.Y), new Vector2(vector3.X + num5, vector3.Y), val);
				}
			}
			if (!hashSet.Contains(new Vector2i(item.X, item.Y + 1)))
			{
				for (float num6 = 0f - num4; num6 <= num4; num6 += num4 / 2f)
				{
					((DrawingHandleBase)handle).DrawLine(new Vector2(vector2.X, vector3.Y + num6), new Vector2(vector3.X, vector3.Y + num6), val);
				}
			}
			if (!hashSet.Contains(new Vector2i(item.X, item.Y - 1)))
			{
				float num7 = 0f - num4;
				goto IL_023f;
			}
			continue;
			IL_023f:
			for (float num8 = 0f - num4; !(num8 > num4); num8 += num4 / 2f)
			{
				((DrawingHandleBase)handle).DrawLine(new Vector2(vector2.X + num8, vector2.Y), new Vector2(vector2.X + num8, vector3.Y), val);
			}
			goto IL_01c3;
		}
		Matrix3x2 identity = Matrix3x2.Identity;
		((DrawingHandleBase)handle).SetTransform(ref identity);
	}

	private Vector2 SimulateThrowTrajectoryWithCollision(DrawingHandleWorld handle, MapCoordinates startPos, Vector2 throwVector, float damping, EntityUid ignoreEnt, float maxDist)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		Vector2 position = startPos.Position;
		if (throwVector.LengthSquared() >= 0.1f)
		{
			Vector2 vector = Vector2.Normalize(throwVector);
			float num = throwVector.Length();
			CollisionRay val = default(CollisionRay);
			((CollisionRay)(ref val))._002Ector(position, vector, 3);
			IEnumerable<RayCastResults> enumerable = sharedPhysicsSystem_0.IntersectRayWithPredicate<float>(startPos.MapId, val, num, (Func<EntityUid, float, bool>)((EntityUid uid, float _) => uid == ignoreEnt), 50f, true);
			Vector2 vector2 = position + vector * num;
			_ = Vector2.Zero;
			foreach (RayCastResults item in enumerable)
			{
				RayCastResults current = item;
				if (!(((RayCastResults)(ref current)).Distance >= num))
				{
					vector2 = ((RayCastResults)(ref current)).HitPos;
					break;
				}
			}
			Color val2 = new Color(ref CerberusConfig.GrenadeHelper.TrajectoryColor);
			((DrawingHandleBase)handle).DrawLine(position, vector2, val2);
			float num2 = 0.2f;
			((DrawingHandleBase)handle).DrawLine(vector2 - new Vector2(num2, num2), vector2 + new Vector2(num2, num2), Color.Red);
			((DrawingHandleBase)handle).DrawLine(vector2 - new Vector2(num2, 0f - num2), vector2 + new Vector2(num2, 0f - num2), Color.Red);
			return vector2;
		}
		return position;
	}

	private void SimulatePhysicsTrajectory(DrawingHandleWorld handle, EntityCoordinates startCoords, Vector2 velocity, float damping, EntityUid uid)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		Vector2 position = sharedTransformSystem_0.ToMapCoordinates(startCoords, true).Position;
		TimeSpan? timeSpan = null;
		ThrownItemComponent val = default(ThrownItemComponent);
		if (ientityManager_0.TryGetComponent<ThrownItemComponent>(uid, ref val))
		{
			timeSpan = val.LandTime;
		}
		Vector2 item = position;
		Vector2 vector = velocity;
		float num = 0.05f;
		List<Vector2> list = new List<Vector2> { item };
		for (float num2 = 0f; num2 < 3f && (!timeSpan.HasValue || !(igameTiming_0.CurTime + TimeSpan.FromSeconds(num2) > timeSpan.Value)); num2 += num)
		{
			item += vector * num;
			vector *= Math.Clamp(1f - damping * num, 0f, 1f);
			list.Add(item);
			if (vector.LengthSquared() < 0.1f)
			{
				break;
			}
		}
		Color val2 = new Color(ref CerberusConfig.GrenadeHelper.TrajectoryColor);
		for (int i = 0; i < list.Count - 1; i++)
		{
			((DrawingHandleBase)handle).DrawLine(list[i], list[i + 1], val2);
		}
	}

	private void DrawScreen(OverlayDrawArgs args)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		DrawingHandleScreen screenHandle = ((OverlayDrawArgs)(ref args)).ScreenHandle;
		EntityQueryEnumerator<ActiveTimerTriggerComponent, TimerTriggerComponent, TransformComponent> val = ientityManager_0.EntityQueryEnumerator<ActiveTimerTriggerComponent, TimerTriggerComponent, TransformComponent>();
		EntityUid val2 = default(EntityUid);
		ActiveTimerTriggerComponent val3 = default(ActiveTimerTriggerComponent);
		TimerTriggerComponent val4 = default(TimerTriggerComponent);
		TransformComponent val5 = default(TransformComponent);
		while (val.MoveNext(ref val2, ref val3, ref val4, ref val5))
		{
			if (val5.MapID != ieyeManager_0.CurrentMap)
			{
				continue;
			}
			Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(val5);
			Vector2 vector = ieyeManager_0.WorldToScreen(worldPosition);
			if (CerberusConfig.GrenadeHelper.ShowTimer)
			{
				double totalSeconds = (val4.NextTrigger - igameTiming_0.CurTime).TotalSeconds;
				if (totalSeconds > 0.0)
				{
					string text = $"{totalSeconds:F1}s";
					screenHandle.DrawString(font_0, vector + new Vector2(-15f, -20f), text, new Color(ref CerberusConfig.GrenadeHelper.TimerColor));
				}
			}
		}
	}
}
