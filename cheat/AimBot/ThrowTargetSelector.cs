using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using Content.Shared.Mobs.Components;
using Content.Shared.Weapons.Melee;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using Robust.Shared.Physics;
using Robust.Shared.Physics.Systems;
using Robust.Shared.Player;
using DamageableHelper;
using CerberusConfig;
using PositionBacktracker;

[CompilerGenerated]
public sealed class ThrowTargetSelector : EntitySystem
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly PriorityList gclass8_0;

	[Dependency]
	private readonly EntityLookupSystem entityLookupSystem_0;

	[Dependency]
	private readonly SharedPhysicsSystem sharedPhysicsSystem_0;

	[Dependency]
	private readonly FriendsList gclass6_0;

	[Dependency]
	private readonly SharedTransformSystem sharedTransformSystem_0;

	[Dependency]
	private readonly IEntitySystemManager ientitySystemManager_0;

	private PositionBacktracker gclass113_0;

	private long long_0;

	private bool bool_0;

	private long long_1;

	public EntityUid? CurrentMeleeTarget { get; private set; }

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

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
		DamageableHelper.Initialize();
		if (ientitySystemManager_0 != null)
		{
			gclass113_0 = ientitySystemManager_0.GetEntitySystem<PositionBacktracker>();
		}
	}

	public IEnumerable<EntityUid> FindPotentialTargets(Vector2 circleCenter, float circleRadius, MeleeWeaponComponent melee, bool targetCritical)
	{
		EntityUid value = ((ISharedPlayerManager)iplayerManager_0).LocalEntity.Value;
		MapId mapId = sharedTransformSystem_0.GetMapId(Entity<TransformComponent>.op_Implicit(value));
		foreach (EntityUid item in entityLookupSystem_0.GetEntitiesInRange(mapId, circleCenter, circleRadius, (LookupFlags)110))
		{
			if (IsValidTarget(item, melee, circleCenter, circleRadius, targetCritical))
			{
				yield return item;
			}
		}
	}

	public EntityUid? GetClosestTargetToPlayer(MeleeWeaponComponent melee, Vector2 circleCenter, float circleRadius, bool targetCritical)
	{
		return SelectTarget(FindPotentialTargets(circleCenter, circleRadius, melee, targetCritical), (EntityUid a, EntityUid b) => CompareByDistanceToPlayer(a, b));
	}

	public EntityUid? GetClosestTargetToMouse(MeleeWeaponComponent melee, Vector2 circleCenter, float circleRadius, bool targetCritical)
	{
		return SelectTarget(FindPotentialTargets(circleCenter, circleRadius, melee, targetCritical), (EntityUid a, EntityUid b) => CompareByDistanceToPoint(a, b, circleCenter));
	}

	public EntityUid? GetHighestHealthTarget(MeleeWeaponComponent melee, Vector2 circleCenter, float circleRadius, bool targetCritical)
	{
		IEnumerable<EntityUid> targets = from e in FindPotentialTargets(circleCenter, circleRadius, melee, targetCritical)
			where DamageableHelper.HasDamageableComponent(e, ientityManager_0)
			select e;
		return SelectTarget(targets, (EntityUid a, EntityUid b) => CompareByHealth(a, b, circleCenter));
	}

	private EntityUid? SelectTarget(IEnumerable<EntityUid> targets, Func<EntityUid, EntityUid, int> comparison)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		List<EntityUid> list = targets.ToList();
		if (list.Count == 0)
		{
			return null;
		}
		list.Sort((EntityUid a, EntityUid b) => CompareTargets(a, b, comparison));
		if (CerberusConfig.MeleeAimBot.OnlyPriority)
		{
			return list.FirstOrDefault((EntityUid t) => gclass8_0.IsPriority(t));
		}
		return list.FirstOrDefault();
	}

	private int CompareTargets(EntityUid a, EntityUid b, Func<EntityUid, EntityUid, int> customCompare)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		bool flag = gclass8_0.IsPriority(a);
		bool flag2 = gclass8_0.IsPriority(b);
		if (flag && !flag2)
		{
			return -1;
		}
		if (!flag && flag2)
		{
			return 1;
		}
		return customCompare(a, b);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private bool IsValidTarget(EntityUid entity, MeleeWeaponComponent melee, Vector2 circleCenter, float circleRadius, bool targetCritical)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		if (entity == ((ISharedPlayerManager)iplayerManager_0).LocalEntity.Value)
		{
			return false;
		}
		if (!IsWithinCircle(entity, circleCenter, circleRadius))
		{
			return false;
		}
		if (IsInRange(entity, melee.Range))
		{
			if (!gclass6_0.IsFriend(entity))
			{
				return HasValidMobState(entity, targetCritical);
			}
			return false;
		}
		return false;
	}

	private bool HasValidMobState(EntityUid entity, bool targetCritical)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Invalid comparison between Unknown and I4
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Invalid comparison between Unknown and I4
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		MobStateComponent val = default(MobStateComponent);
		if (ientityManager_0.TryGetComponent<MobStateComponent>(entity, ref val))
		{
			if ((int)val.CurrentState != 3)
			{
				if ((int)val.CurrentState == 2)
				{
					if (!targetCritical)
					{
						return false;
					}
					if (HasBetterCriticalTarget(entity, targetCritical))
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}
		return false;
	}

	private bool HasBetterCriticalTarget(EntityUid entity, bool targetCritical)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Invalid comparison between Unknown and I4
		Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(entity);
		MapId mapId = sharedTransformSystem_0.GetMapId(Entity<TransformComponent>.op_Implicit(entity));
		MobStateComponent val = default(MobStateComponent);
		foreach (EntityUid item in entityLookupSystem_0.GetEntitiesInRange(mapId, worldPosition, 5f, (LookupFlags)110))
		{
			if (item == entity || !ientityManager_0.TryGetComponent<MobStateComponent>(item, ref val) || (int)val.CurrentState != 1)
			{
				continue;
			}
			goto IL_009f;
		}
		return false;
		IL_009f:
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private bool IsInRange(EntityUid entity, float maxRange)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(((ISharedPlayerManager)iplayerManager_0).LocalEntity.Value);
		Vector2 backtrackPosition;
		Vector2 vector = ((CerberusConfig.Backtrack.Enabled && gclass113_0 != null) ? ((!gclass113_0.TryGetBacktrackPosition(entity, out backtrackPosition)) ? sharedTransformSystem_0.GetWorldPosition(entity) : backtrackPosition) : sharedTransformSystem_0.GetWorldPosition(entity));
		return (vector - worldPosition).LengthSquared() <= maxRange * maxRange;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private bool IsWithinCircle(EntityUid entity, Vector2 center, float radius)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return (sharedTransformSystem_0.GetWorldPosition(entity) - center).LengthSquared() <= radius * radius;
	}

	private int CompareByDistanceToPlayer(EntityUid a, EntityUid b)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(((ISharedPlayerManager)iplayerManager_0).LocalEntity.Value);
		return GetDistSq(a, worldPosition).CompareTo(GetDistSq(b, worldPosition));
	}

	private int CompareByDistanceToPoint(EntityUid a, EntityUid b, Vector2 point)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		return GetDistSq(a, point).CompareTo(GetDistSq(b, point));
	}

	private float GetDistSq(EntityUid uid, Vector2 point)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return (sharedTransformSystem_0.GetWorldPosition(uid) - point).LengthSquared();
	}

	private int CompareByHealth(EntityUid a, EntityUid b, Vector2 referencePoint)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		float? num = null;
		float? num2 = null;
		if (DamageableHelper.TryGetDamageableComponent(a, ientityManager_0, out object component))
		{
			num = DamageableHelper.GetTotalDamage(component);
		}
		if (DamageableHelper.TryGetDamageableComponent(b, ientityManager_0, out object component2))
		{
			num2 = DamageableHelper.GetTotalDamage(component2);
		}
		if (num.HasValue || num2.HasValue)
		{
			if (num.HasValue)
			{
				if (num2.HasValue)
				{
					int num3 = num.Value.CompareTo(num2.Value);
					if (num3 == 0)
					{
						return CompareByDistanceToPoint(a, b, referencePoint);
					}
					return num3;
				}
				return -1;
			}
			return 1;
		}
		return 0;
	}

	public HashSet<EntityUid> ArcRayCast(Vector2 position, Angle angle, Angle arcWidth, float range, MapId mapId, EntityUid ignore)
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		int num = Math.Max(1, (int)Math.Ceiling(arcWidth.Theta / 0.20000000298023224));
		double num2 = arcWidth.Theta / (double)num;
		Angle val = angle - Angle.op_Implicit(Angle.op_Implicit(arcWidth) / 2.0);
		HashSet<EntityUid> hashSet = new HashSet<EntityUid>();
		Angle val2 = default(Angle);
		CollisionRay val3 = default(CollisionRay);
		for (int i = 0; i <= num; i++)
		{
			((Angle)(ref val2))._002Ector(val.Theta + num2 * (double)i);
			((CollisionRay)(ref val3))._002Ector(position, ((Angle)(ref val2)).ToWorldVec(), 30);
			RayCastResults val4 = sharedPhysicsSystem_0.IntersectRay(mapId, val3, range, (EntityUid?)ignore, false).FirstOrDefault();
			EntityUid hitEntity = ((RayCastResults)(ref val4)).HitEntity;
			if (((EntityUid)(ref hitEntity)).IsValid() && (!CerberusConfig.Settings.NoDmgFriendPatch || !gclass6_0.IsFriend(((RayCastResults)(ref val4)).HitEntity)))
			{
				hashSet.Add(((RayCastResults)(ref val4)).HitEntity);
			}
		}
		return hashSet;
	}

	public void SetMeleeTarget(EntityUid? target)
	{
		CurrentMeleeTarget = target;
	}

	private string method_6(byte byte_0, long long_2)
	{
		return "Хитролох_иди_нахуй.___8____6_8_";
	}
}
