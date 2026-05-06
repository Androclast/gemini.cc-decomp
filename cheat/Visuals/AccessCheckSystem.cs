using System;
using System.Collections.Generic;
using System.Numerics;
using Content.Shared.Access;
using Content.Shared.Access.Components;
using Content.Shared.Access.Systems;
using Content.Shared.Doors.Components;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using Robust.Shared.Player;
using Robust.Shared.Prototypes;
using Robust.Shared.Timing;
using CerberusConfig;

namespace AccessCheckSystem;

public sealed class AccessCheckSystem : EntitySystem
{
	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly EntityLookupSystem entityLookupSystem_0;

	[Dependency]
	private readonly AccessReaderSystem accessReaderSystem_0;

	private Dictionary<EntityUid, bool> dictionary_0 = new Dictionary<EntityUid, bool>();

	private TimeSpan timeSpan_0 = TimeSpan.Zero;

	private HashSet<string> hashSet_0 = new HashSet<string>();

	private bool bool_1;

	private long long_0;

	private byte byte_0;

	private bool Boolean_0
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
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

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
	}

	public override void Update(float frameTime)
	{
		((EntitySystem)this).Update(frameTime);
		if (!CerberusConfig.AccessChecker.Enabled)
		{
			if (dictionary_0.Count > 0)
			{
				dictionary_0.Clear();
				hashSet_0.Clear();
			}
			return;
		}
		TimeSpan curTime = igameTiming_0.CurTime;
		if (HasPlayerAccessChanged() || (curTime - timeSpan_0).TotalSeconds >= 10.0)
		{
			timeSpan_0 = curTime;
			UpdateAccessCache();
		}
	}

	private bool HasPlayerAccessChanged()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (localEntity.HasValue)
		{
			HashSet<string> hashSet = new HashSet<string>();
			AccessComponent val = default(AccessComponent);
			if (ientityManager_0.TryGetComponent<AccessComponent>(localEntity.Value, ref val))
			{
				foreach (ProtoId<AccessLevelPrototype> tag in val.Tags)
				{
					hashSet.Add(ProtoId<AccessLevelPrototype>.op_Implicit(tag));
				}
			}
			if (hashSet.Count == hashSet_0.Count)
			{
				foreach (string item in hashSet)
				{
					if (!hashSet_0.Contains(item))
					{
						goto IL_00c9;
					}
				}
				return false;
			}
			return true;
		}
		return false;
		IL_00c9:
		return true;
	}

	private void UpdateAccessCache()
	{
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (!localEntity.HasValue || !ientityManager_0.HasComponent<TransformComponent>(localEntity.Value))
		{
			return;
		}
		ientityManager_0.GetComponent<TransformComponent>(localEntity.Value);
		MapCoordinates mapCoordinates = ientityManager_0.System<SharedTransformSystem>().GetMapCoordinates(localEntity.Value, (TransformComponent)null);
		hashSet_0.Clear();
		AccessComponent val = default(AccessComponent);
		if (ientityManager_0.TryGetComponent<AccessComponent>(localEntity.Value, ref val))
		{
			foreach (ProtoId<AccessLevelPrototype> tag in val.Tags)
			{
				hashSet_0.Add(ProtoId<AccessLevelPrototype>.op_Implicit(tag));
			}
		}
		dictionary_0.Clear();
		float range = CerberusConfig.AccessChecker.Range;
		Box2 val2 = Box2.CenteredAround(mapCoordinates.Position, new Vector2(range * 2f, range * 2f));
		HashSet<EntityUid> entitiesIntersecting = entityLookupSystem_0.GetEntitiesIntersecting(mapCoordinates.MapId, val2, (LookupFlags)110);
		int num = 0;
		AccessReaderComponent val3 = default(AccessReaderComponent);
		foreach (EntityUid item in entitiesIntersecting)
		{
			if (num >= 50)
			{
				break;
			}
			if (ientityManager_0.HasComponent<DoorComponent>(item) && ientityManager_0.TryGetComponent<AccessReaderComponent>(item, ref val3) && IsValidDoorType(item))
			{
				num++;
				bool value = accessReaderSystem_0.IsAllowed(localEntity.Value, item, val3);
				dictionary_0[item] = value;
			}
		}
	}

	private bool IsValidDoorType(EntityUid entity)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		MetaDataComponent val = default(MetaDataComponent);
		if (!ientityManager_0.TryGetComponent<MetaDataComponent>(entity, ref val))
		{
			return false;
		}
		EntityPrototype entityPrototype = val.EntityPrototype;
		if (entityPrototype != null)
		{
			string text = entityPrototype.ID.ToLowerInvariant();
			bool num = text.Contains("door") || text.Contains("airlock") || text.Contains("windoor");
			bool flag = text.Contains("locker") || text.Contains("crate") || text.Contains("closet") || text.Contains("shutter") || text.Contains("blast") || (text.Contains("window") && !text.Contains("windoor"));
			if (num)
			{
				return !flag;
			}
			return false;
		}
		return false;
	}

	public bool TryGetAccessStatus(EntityUid doorEntity, out bool hasAccess)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return dictionary_0.TryGetValue(doorEntity, out hasAccess);
	}

	public IReadOnlyDictionary<EntityUid, bool> GetAllCachedAccesses()
	{
		return dictionary_0;
	}

	public void ForceUpdate()
	{
		timeSpan_0 = TimeSpan.Zero;
	}
}
