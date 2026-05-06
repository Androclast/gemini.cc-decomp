using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using Content.Shared.Mobs.Components;
using Content.Shared.Weapons.Ranged.Components;
using Content.Shared.Weapons.Ranged.Systems;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using Robust.Shared.Physics;
using Robust.Shared.Physics.Components;
using Robust.Shared.Physics.Systems;
using Robust.Shared.Player;
using GunHelper;
using DamageableHelper;
using TargetFilter;
using CerberusConfig;
using PositionBacktracker;

[CompilerGenerated]
public sealed class GunTargetSelector : EntitySystem
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IEntitySystemManager ientitySystemManager_0;

	private EntityLookupSystem entityLookupSystem_0;

	private PriorityList gclass8_0;

	private FriendsList gclass6_0;

	private SharedGunSystem sharedGunSystem_0;

	private SharedTransformSystem sharedTransformSystem_0;

	private SharedPhysicsSystem sharedPhysicsSystem_0;

	private PositionBacktracker gclass113_0;

	private TargetFilter gclass294_0;

	private List<EntityUid> list_0 = new List<EntityUid>();

	private int int_0;

	private int int_1;

	private char char_0;

	private double double_0;

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

	private void EnsureSystems()
	{
		if (ientitySystemManager_0 != null)
		{
			if (entityLookupSystem_0 == null)
			{
				entityLookupSystem_0 = ientitySystemManager_0.GetEntitySystem<EntityLookupSystem>();
			}
			if (gclass8_0 == null)
			{
				gclass8_0 = ientitySystemManager_0.GetEntitySystem<PriorityList>();
			}
			if (gclass6_0 == null)
			{
				gclass6_0 = ientitySystemManager_0.GetEntitySystem<FriendsList>();
			}
			if (sharedGunSystem_0 == null)
			{
				sharedGunSystem_0 = ientitySystemManager_0.GetEntitySystem<SharedGunSystem>();
			}
			if (sharedTransformSystem_0 == null)
			{
				sharedTransformSystem_0 = ientitySystemManager_0.GetEntitySystem<SharedTransformSystem>();
			}
			if (sharedPhysicsSystem_0 == null)
			{
				sharedPhysicsSystem_0 = ientitySystemManager_0.GetEntitySystem<SharedPhysicsSystem>();
			}
			if (gclass113_0 == null)
			{
				gclass113_0 = ientitySystemManager_0.GetEntitySystem<PositionBacktracker>();
			}
			if (gclass294_0 == null)
			{
				gclass294_0 = ientitySystemManager_0.GetEntitySystem<TargetFilter>();
			}
		}
	}

	public EntityUid? GetClosestTargetToPlayer(EntityUid player, Vector2 circleCenter, float circleRadius, bool targetCritical, AimbotRenderOverlay overlay)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		EnsureSystems();
		if (sharedTransformSystem_0 != null && entityLookupSystem_0 != null)
		{
			List<EntityUid> list = new List<EntityUid>();
			MapId mapId = sharedTransformSystem_0.GetMapId(Entity<TransformComponent>.op_Implicit(player));
			int num = 0;
			foreach (EntityUid item in entityLookupSystem_0.GetEntitiesInRange(mapId, circleCenter, circleRadius, (LookupFlags)110))
			{
				if (++num <= 30)
				{
					if (IsValidTarget(item, targetCritical, overlay) && sharedTransformSystem_0.GetMapId(Entity<TransformComponent>.op_Implicit(item)) == sharedTransformSystem_0.GetMapId(Entity<TransformComponent>.op_Implicit(player)))
					{
						list.Add(item);
					}
					continue;
				}
				break;
			}
			Vector2 OwDNWL8Qs1 = sharedTransformSystem_0.GetWorldPosition(player);
			list.Sort(delegate(EntityUid a, EntityUid b)
			{
				//IL_0025: Unknown result type (might be due to invalid IL or missing references)
				//IL_0096: Unknown result type (might be due to invalid IL or missing references)
				//IL_0053: Unknown result type (might be due to invalid IL or missing references)
				//IL_0073: Unknown result type (might be due to invalid IL or missing references)
				bool flag = gclass8_0.IsPriority(a);
				bool flag2 = gclass8_0.IsPriority(b);
				if (!flag || flag2)
				{
					if (!(!flag && flag2))
					{
						float num2 = (sharedTransformSystem_0.GetWorldPosition(a) - OwDNWL8Qs1).LengthSquared();
						float value = (sharedTransformSystem_0.GetWorldPosition(b) - OwDNWL8Qs1).LengthSquared();
						return num2.CompareTo(value);
					}
					return 1;
				}
				return -1;
			});
			return CerberusConfig.GunAimBot.OnlyPriority ? new EntityUid?(list.FirstOrDefault((EntityUid t) => gclass8_0.IsPriority(t))) : new EntityUid?(list.FirstOrDefault());
		}
		return null;
	}

	public EntityUid? GetClosestTargetToMouse(Vector2 circleCenter, float circleRadius, bool targetCritical, AimbotRenderOverlay overlay)
	{
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		EnsureSystems();
		if (sharedTransformSystem_0 != null && entityLookupSystem_0 != null)
		{
			IPlayerManager obj = iplayerManager_0;
			if (obj != null && ((ISharedPlayerManager)obj).LocalEntity.HasValue)
			{
				List<EntityUid> list = new List<EntityUid>();
				EntityUid value = ((ISharedPlayerManager)iplayerManager_0).LocalEntity.Value;
				MapId mapId = sharedTransformSystem_0.GetMapId(Entity<TransformComponent>.op_Implicit(value));
				int num = 0;
				float num2 = circleRadius * circleRadius;
				foreach (EntityUid item in entityLookupSystem_0.GetEntitiesInRange(mapId, circleCenter, circleRadius, (LookupFlags)110))
				{
					if (++num <= 30)
					{
						if (IsValidTarget(item, targetCritical, overlay) && (sharedTransformSystem_0.GetWorldPosition(item) - circleCenter).LengthSquared() <= num2)
						{
							list.Add(item);
						}
						continue;
					}
					break;
				}
				list.Sort(delegate(EntityUid a, EntityUid b)
				{
					//IL_0018: Unknown result type (might be due to invalid IL or missing references)
					//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
					//IL_0048: Unknown result type (might be due to invalid IL or missing references)
					//IL_007b: Unknown result type (might be due to invalid IL or missing references)
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
					float num3 = (sharedTransformSystem_0.GetWorldPosition(a) - circleCenter).LengthSquared();
					float value2 = (sharedTransformSystem_0.GetWorldPosition(b) - circleCenter).LengthSquared();
					return num3.CompareTo(value2);
				});
				return CerberusConfig.GunAimBot.OnlyPriority ? new EntityUid?(list.FirstOrDefault((EntityUid t) => gclass8_0.IsPriority(t))) : new EntityUid?(list.FirstOrDefault());
			}
		}
		return null;
	}

	private bool IsValidTarget(EntityUid entity, bool targetCritical, AimbotRenderOverlay overlay)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (!localEntity.HasValue || !(entity == localEntity.GetValueOrDefault()))
		{
			EnsureSystems();
			if (gclass294_0 == null || gclass294_0.IsValidGunTarget(entity))
			{
				EntityCoordinates? targetCoords = null;
				Vector2 backtrackPosition;
				TransformComponent val = default(TransformComponent);
				if (!CerberusConfig.Backtrack.Enabled || gclass113_0 == null)
				{
					if (CerberusConfig.GunAimBot.PredictEnabled && overlay.nullable_1.HasValue)
					{
						targetCoords = overlay.nullable_1;
					}
				}
				else if (gclass113_0.TryGetBacktrackPosition(entity, out backtrackPosition) && ientityManager_0.TryGetComponent<TransformComponent>(entity, ref val))
				{
					targetCoords = new EntityCoordinates(val.ParentUid, backtrackPosition);
				}
				return CanHitTargetWithHitScan(((ISharedPlayerManager)iplayerManager_0).LocalEntity.Value, entity, targetCoords);
			}
			return false;
		}
		return false;
	}

	public List<EntityUid> GetMultiTargets(EntityUid player, Vector2 circleCenter, float circleRadius, bool targetCritical, AimbotRenderOverlay overlay)
	{
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		EnsureSystems();
		if (sharedTransformSystem_0 != null && entityLookupSystem_0 != null)
		{
			List<EntityUid> list = new List<EntityUid>();
			MapId mapId = sharedTransformSystem_0.GetMapId(Entity<TransformComponent>.op_Implicit(player));
			int num = 0;
			foreach (EntityUid item in entityLookupSystem_0.GetEntitiesInRange(mapId, circleCenter, circleRadius, (LookupFlags)110))
			{
				if (++num <= 50)
				{
					if (IsValidTarget(item, targetCritical, overlay) && sharedTransformSystem_0.GetMapId(Entity<TransformComponent>.op_Implicit(item)) == sharedTransformSystem_0.GetMapId(Entity<TransformComponent>.op_Implicit(player)))
					{
						list.Add(item);
					}
					continue;
				}
				break;
			}
			if (gclass294_0 != null)
			{
				gclass294_0.SortTargetsByPriority(list);
			}
			int num2 = Math.Min(CerberusConfig.GunAimBot.MultiTargetCount, list.Count);
			if (num2 < list.Count)
			{
				list = list.Take(num2).ToList();
			}
			return list;
		}
		return new List<EntityUid>();
	}

	public EntityUid? GetNextMultiTarget(EntityUid player, Vector2 circleCenter, float circleRadius, bool targetCritical, AimbotRenderOverlay overlay, int currentShotCount)
	{
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		if (list_0.Count == 0 || new Random().Next(0, 10) == 0)
		{
			list_0 = GetMultiTargets(player, circleCenter, circleRadius, targetCritical, overlay);
			int_0 = 0;
		}
		if (list_0.Count == 0)
		{
			return null;
		}
		if (currentShotCount != int_1)
		{
			int_1 = currentShotCount;
			int_0 = (int_0 + 1) % list_0.Count;
		}
		if (int_0 >= list_0.Count)
		{
			int_0 = 0;
		}
		EntityUid val = list_0[int_0];
		if (!ientityManager_0.EntityExists(val))
		{
			list_0 = GetMultiTargets(player, circleCenter, circleRadius, targetCritical, overlay);
			int_0 = 0;
			if (list_0.Count == 0)
			{
				return null;
			}
			val = list_0[int_0];
		}
		return val;
	}

	public EntityUid? GetHighestHealthTarget(Vector2 circleCenter, float circleRadius, bool targetCritical, AimbotRenderOverlay overlay)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		EnsureSystems();
		if (sharedTransformSystem_0 == null || entityLookupSystem_0 == null)
		{
			return null;
		}
		List<EntityUid> list = new List<EntityUid>();
		EntityUid value = ((ISharedPlayerManager)iplayerManager_0).LocalEntity.Value;
		MapId mapId = sharedTransformSystem_0.GetMapId(Entity<TransformComponent>.op_Implicit(value));
		foreach (EntityUid item in entityLookupSystem_0.GetEntitiesInRange(mapId, circleCenter, circleRadius, (LookupFlags)110))
		{
			if (DamageableHelper.HasDamageableComponent(item, ientityManager_0) && IsValidTarget(item, targetCritical, overlay))
			{
				list.Add(item);
			}
		}
		list.Sort(delegate(EntityUid a, EntityUid b)
		{
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			bool flag = gclass8_0.IsPriority(a);
			bool flag2 = gclass8_0.IsPriority(b);
			if (flag && !flag2)
			{
				return -1;
			}
			if (!(!flag && flag2))
			{
				if (!DamageableHelper.TryGetDamageableComponent(a, ientityManager_0, out object component) || !DamageableHelper.TryGetDamageableComponent(b, ientityManager_0, out object component2))
				{
					float num = (sharedTransformSystem_0.GetWorldPosition(a) - circleCenter).LengthSquared();
					float value2 = (sharedTransformSystem_0.GetWorldPosition(b) - circleCenter).LengthSquared();
					return num.CompareTo(value2);
				}
				float totalDamage = DamageableHelper.GetTotalDamage(component);
				float totalDamage2 = DamageableHelper.GetTotalDamage(component2);
				return totalDamage.CompareTo(totalDamage2);
			}
			return 1;
		});
		if (!CerberusConfig.GunAimBot.OnlyPriority)
		{
			return list.FirstOrDefault();
		}
		return list.FirstOrDefault((EntityUid t) => gclass8_0.IsPriority(t));
	}

	public bool CanHitTargetWithHitScan(EntityUid userUid, EntityUid targetUid, EntityCoordinates? targetCoords = null)
	{
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Invalid comparison between Unknown and I4
		EnsureSystems();
		if (!CerberusConfig.GunAimBot.HitScan)
		{
			return true;
		}
		if (sharedTransformSystem_0 == null || sharedPhysicsSystem_0 == null || sharedGunSystem_0 == null)
		{
			return true;
		}
		MapCoordinates mapCoordinates = sharedTransformSystem_0.GetMapCoordinates(userUid, (TransformComponent)null);
		Vector2 vector = ((!targetCoords.HasValue) ? sharedTransformSystem_0.GetWorldPosition(targetUid) : sharedTransformSystem_0.ToMapCoordinates(targetCoords.Value, true).Position);
		if (GunHelper.TryGetGunSafe(sharedGunSystem_0, userUid, out Entity<GunComponent> _))
		{
			Vector2 vector2 = vector - mapCoordinates.Position;
			float num = vector2.Length();
			if (!(num <= 0.01f))
			{
				CollisionRay val = default(CollisionRay);
				((CollisionRay)(ref val))._002Ector(mapCoordinates.Position, Vector2Helpers.Normalized(vector2), 11);
				MobStateComponent val2 = default(MobStateComponent);
				PhysicsComponent val3 = default(PhysicsComponent);
				foreach (RayCastResults item in sharedPhysicsSystem_0.IntersectRay(mapCoordinates.MapId, val, num, (EntityUid?)userUid, false).ToList())
				{
					RayCastResults current = item;
					if (((RayCastResults)(ref current)).HitEntity == targetUid)
					{
						return true;
					}
					if ((!ientityManager_0.TryGetComponent<MobStateComponent>(((RayCastResults)(ref current)).HitEntity, ref val2) || (int)val2.CurrentState != 3) && ientityManager_0.TryGetComponent<PhysicsComponent>(((RayCastResults)(ref current)).HitEntity, ref val3) && (val3.CollisionLayer & 0xB) != 0)
					{
						return false;
					}
				}
				return true;
			}
			return true;
		}
		return false;
	}
}
