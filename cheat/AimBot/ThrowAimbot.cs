using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using CerberusWareV3.Features.AimBot;
using Content.Shared.CombatMode;
using Robust.Client.Graphics;
using Robust.Client.Input;
using Robust.Client.Player;
using Robust.Shared.Configuration;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Network;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using DamageableHelper;
using TargetFilter;
using CerberusConfig;

namespace ThrowAimbot;

public class ThrowAimbot
{
	private readonly IEntityManager entityManager;

	private readonly IPlayerManager iplayerManager_0;

	private readonly IGameTiming igameTiming_0;

	private readonly IClientNetManager iclientNetManager_0;

	private readonly IConfigurationManager iconfigurationManager_0;

	private readonly IEntitySystemManager ientitySystemManager_0;

	private SharedTransformSystem sharedTransformSystem_0;

	private EntityLookupSystem entityLookupSystem_0;

	private TargetFilter gclass294_0;

	private PriorityList gclass8_0;

	private bool bool_0;

	private string string_0;

	private string string_1;

	private string string_2;

	private char char_1;

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

	public ThrowAimbot(IEntityManager entityManager)
	{
		this.entityManager = entityManager;
		iplayerManager_0 = IoCManager.Resolve<IPlayerManager>();
		igameTiming_0 = IoCManager.Resolve<IGameTiming>();
		iclientNetManager_0 = IoCManager.Resolve<IClientNetManager>();
		iconfigurationManager_0 = IoCManager.Resolve<IConfigurationManager>();
		ientitySystemManager_0 = IoCManager.Resolve<IEntitySystemManager>();
	}

	private void EnsureSystems()
	{
		if (!bool_0)
		{
			sharedTransformSystem_0 = ientitySystemManager_0.GetEntitySystem<SharedTransformSystem>();
			entityLookupSystem_0 = ientitySystemManager_0.GetEntitySystem<EntityLookupSystem>();
			gclass294_0 = ientitySystemManager_0.GetEntitySystem<TargetFilter>();
			gclass8_0 = ientitySystemManager_0.GetEntitySystem<PriorityList>();
			bool_0 = true;
		}
	}

	public void Update(float frameTime)
	{
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		ThrowAimbotGlobals.nullable_0 = null;
		ThrowAimbotGlobals.nullable_1 = null;
		if (!CerberusConfig.ThrowAimbot.Enabled)
		{
			return;
		}
		EnsureSystems();
		if (sharedTransformSystem_0 == null || entityLookupSystem_0 == null)
		{
			return;
		}
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		CombatModeComponent val = default(CombatModeComponent);
		if (!localEntity.HasValue || !entityManager.TryGetComponent<CombatModeComponent>(localEntity.Value, ref val) || !val.IsInCombatMode)
		{
			return;
		}
		Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(localEntity.Value);
		float range = CerberusConfig.ThrowAimbot.Range;
		Vector2 mouseWorldPos = worldPosition;
		try
		{
			IInputManager obj = IoCManager.Resolve<IInputManager>();
			IEyeManager val2 = IoCManager.Resolve<IEyeManager>();
			ScreenCoordinates mouseScreenPosition = obj.MouseScreenPosition;
			MapCoordinates val3 = val2.PixelToMap(mouseScreenPosition);
			if (val3.MapId != MapId.Nullspace)
			{
				mouseWorldPos = val3.Position;
			}
		}
		catch
		{
		}
		EntityUid? bestTarget = GetBestTarget(localEntity.Value, worldPosition, mouseWorldPos, range);
		if (igameTiming_0.CurTick.Value % 60 == 0)
		{
			_ = bestTarget.HasValue;
		}
		if (bestTarget.HasValue)
		{
			Vector2 vector;
			if (!CerberusConfig.ThrowAimbot.PredictionEnabled)
			{
				vector = sharedTransformSystem_0.GetWorldPosition(bestTarget.Value);
			}
			else if (!ProjectilePredictor._isInitialized)
			{
				ProjectilePredictor.InitializeDependencies(iclientNetManager_0, igameTiming_0, iconfigurationManager_0, entityManager);
				vector = sharedTransformSystem_0.GetWorldPosition(bestTarget.Value);
			}
			else
			{
				vector = ProjectilePredictor.GetPredictedWorldShootPosition(localEntity.Value, bestTarget.Value, CerberusConfig.ThrowAimbot.ThrowSpeed);
			}
			Vector2 vector2 = vector - worldPosition;
			if (vector2 != Vector2.Zero)
			{
				ThrowAimbotGlobals.nullable_0 = vector2;
				MapCoordinates val4 = default(MapCoordinates);
				((MapCoordinates)(ref val4))._002Ector(vector, sharedTransformSystem_0.GetMapId(Entity<TransformComponent>.op_Implicit(localEntity.Value)));
				ThrowAimbotGlobals.nullable_1 = sharedTransformSystem_0.ToCoordinates(val4);
			}
		}
	}

	private EntityUid? GetBestTarget(EntityUid user, Vector2 userPos, Vector2 mouseWorldPos, float range)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		MapId mapId = sharedTransformSystem_0.GetMapId(Entity<TransformComponent>.op_Implicit(user));
		List<EntityUid> list = new List<EntityUid>();
		foreach (EntityUid item in entityLookupSystem_0.GetEntitiesInRange(mapId, userPos, range, (LookupFlags)110))
		{
			if (!(item == user) && (gclass294_0 == null || gclass294_0.IsValidThrowTarget(item)))
			{
				list.Add(item);
			}
		}
		if (list.Count != 0)
		{
			if (CerberusConfig.ThrowAimbot.OnlyPriority && gclass8_0 != null)
			{
				List<EntityUid> list2 = list.Where((EntityUid t) => gclass8_0.IsPriority(t)).ToList();
				if (list2.Count > 0)
				{
					list = list2;
				}
			}
			switch (CerberusConfig.ThrowAimbot.TargetPriority)
			{
			case 2:
				list.Sort(delegate(EntityUid a, EntityUid b)
				{
					//IL_0006: Unknown result type (might be due to invalid IL or missing references)
					//IL_0013: Unknown result type (might be due to invalid IL or missing references)
					float healthPercent = GetHealthPercent(a);
					return GetHealthPercent(b).CompareTo(healthPercent);
				});
				break;
			case 1:
				list.Sort(delegate(EntityUid a, EntityUid b)
				{
					//IL_000b: Unknown result type (might be due to invalid IL or missing references)
					//IL_002a: Unknown result type (might be due to invalid IL or missing references)
					float num = (sharedTransformSystem_0.GetWorldPosition(a) - mouseWorldPos).LengthSquared();
					float value = (sharedTransformSystem_0.GetWorldPosition(b) - mouseWorldPos).LengthSquared();
					return num.CompareTo(value);
				});
				break;
			case 0:
				list.Sort(delegate(EntityUid a, EntityUid b)
				{
					//IL_0034: Unknown result type (might be due to invalid IL or missing references)
					//IL_000d: Unknown result type (might be due to invalid IL or missing references)
					float num = (sharedTransformSystem_0.GetWorldPosition(a) - userPos).LengthSquared();
					float value = (sharedTransformSystem_0.GetWorldPosition(b) - userPos).LengthSquared();
					return num.CompareTo(value);
				});
				break;
			}
			if (gclass294_0 != null && CerberusConfig.ThrowAimbot.RolePriority.Count > 0)
			{
				gclass294_0.SortTargetsByPriority(list);
			}
			return list.FirstOrDefault();
		}
		return null;
	}

	private float GetHealthPercent(EntityUid entity)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if (DamageableHelper.TryGetDamageableComponent(entity, entityManager, out object component))
		{
			float totalDamage = DamageableHelper.GetTotalDamage(component);
			float num = 100f;
			return Math.Max(0f, num - totalDamage) / num * 100f;
		}
		return 100f;
	}

	private string method_9(int int_1, int int_2, byte byte_0)
	{
		return "Хитролох_иди_нахуй.________18__5___5____";
	}
}
