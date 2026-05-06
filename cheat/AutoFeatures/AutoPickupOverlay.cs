using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Content.Client.Verbs;
using Content.Shared.Hands.Components;
using Content.Shared.Hands.EntitySystems;
using Content.Shared.Interaction;
using Content.Shared.Inventory;
using Content.Shared.Physics;
using Content.Shared.Verbs;
using Hexa.NET.ImGui;
using Robust.Client.Graphics;
using Robust.Client.Player;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using CerberusConfig;

public sealed class AutoPickupOverlay : Overlay
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IEntitySystemManager ientitySystemManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	private EntityLookupSystem entityLookupSystem_0;

	private SharedInteractionSystem sharedInteractionSystem_0;

	private VerbSystem verbSystem_0;

	private SharedHandsSystem sharedHandsSystem_0;

	private TimeSpan timeSpan_0;

	private bool bool_0;

	private bool bool_1;

	private string string_0;

	private float float_0;

	private string string_1;

	public override OverlaySpace Space => (OverlaySpace)2;

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

	public AutoPickupOverlay()
	{
		IoCManager.InjectDependencies<AutoPickupOverlay>(this);
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		HandleToggleKey();
		if (!CerberusConfig.AutoLooter.Enabled)
		{
			bool_0 = false;
			return;
		}
		if (!bool_0)
		{
			bool_0 = true;
		}
		if (entityLookupSystem_0 == null)
		{
			entityLookupSystem_0 = ientitySystemManager_0.GetEntitySystem<EntityLookupSystem>();
		}
		if (sharedInteractionSystem_0 == null)
		{
			sharedInteractionSystem_0 = ientitySystemManager_0.GetEntitySystem<SharedInteractionSystem>();
		}
		if (verbSystem_0 == null)
		{
			verbSystem_0 = ientitySystemManager_0.GetEntitySystem<VerbSystem>();
		}
		if (sharedHandsSystem_0 == null)
		{
			sharedHandsSystem_0 = ientitySystemManager_0.GetEntitySystem<SharedHandsSystem>();
		}
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (!localEntity.HasValue || igameTiming_0.CurTime < timeSpan_0 + TimeSpan.FromSeconds(CerberusConfig.AutoLooter.PickupDelay))
		{
			return;
		}
		EntityQuery<TransformComponent> entityQuery = ientityManager_0.GetEntityQuery<TransformComponent>();
		TransformComponent val = default(TransformComponent);
		if (!entityQuery.TryGetComponent(localEntity.Value, ref val))
		{
			return;
		}
		MapId mapID = val.MapID;
		Vector2 worldPosition = val.WorldPosition;
		float range = CerberusConfig.AutoLooter.Range;
		HashSet<EntityUid> entitiesInRange = entityLookupSystem_0.GetEntitiesInRange(val.Coordinates, range, (LookupFlags)110);
		int num = 0;
		TransformComponent val2 = default(TransformComponent);
		foreach (EntityUid item in entitiesInRange)
		{
			if (!(item == localEntity.Value))
			{
				if (++num > 20)
				{
					break;
				}
				if (!IsRecursiveParent(item, localEntity.Value) && IsItemWanted(item) && entityQuery.TryGetComponent(item, ref val2) && !(val2.MapID != mapID) && !((val2.WorldPosition - worldPosition).LengthSquared() > range * range) && sharedInteractionSystem_0.InRangeUnobstructed(Entity<TransformComponent>.op_Implicit(localEntity.Value), Entity<TransformComponent>.op_Implicit(item), range, (CollisionGroup)130, (Ignored)null, false, true) && TryPickup(localEntity.Value, item))
				{
					timeSpan_0 = igameTiming_0.CurTime;
					break;
				}
			}
		}
	}

	private void HandleToggleKey()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		ImGuiKey toggleKey = CerberusConfig.AutoLooter.ToggleKey;
		if ((int)toggleKey == 0)
		{
			return;
		}
		bool flag = KeyStateHelper.IsKeyDown(toggleKey);
		if (!flag || bool_1)
		{
			if (!flag)
			{
				bool_1 = false;
			}
		}
		else
		{
			CerberusConfig.AutoLooter.Enabled = !CerberusConfig.AutoLooter.Enabled;
			bool_1 = true;
		}
	}

	private bool IsRecursiveParent(EntityUid child, EntityUid possibleParent)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		EntityUid val = child;
		TransformComponent val2 = default(TransformComponent);
		while (ientityManager_0.TryGetComponent<TransformComponent>(val, ref val2))
		{
			EntityUid parentUid = val2.ParentUid;
			if (((EntityUid)(ref parentUid)).IsValid())
			{
				if (val2.ParentUid == possibleParent)
				{
					return true;
				}
				val = val2.ParentUid;
				if (val == child)
				{
					return false;
				}
				continue;
			}
			return false;
		}
		return false;
	}

	private bool IsItemWanted(EntityUid entityUid)
	{
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		if (CerberusConfig.AutoLooter.LootEntries.Count == 0)
		{
			return false;
		}
		MetaDataComponent val = default(MetaDataComponent);
		if (ientityManager_0.TryGetComponent<MetaDataComponent>(entityUid, ref val))
		{
			TransformComponent component = ientityManager_0.GetComponent<TransformComponent>(entityUid);
			EntityUid parentUid = component.ParentUid;
			if (((EntityUid)(ref parentUid)).IsValid())
			{
				parentUid = component.ParentUid;
				EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
				if ((!localEntity.HasValue || parentUid != localEntity.GetValueOrDefault()) && (ientityManager_0.HasComponent<HandsComponent>(component.ParentUid) || ientityManager_0.HasComponent<InventoryComponent>(component.ParentUid)))
				{
					return false;
				}
			}
			foreach (ColoredString lootEntry in CerberusConfig.AutoLooter.LootEntries)
			{
				if (string.IsNullOrWhiteSpace(lootEntry.string_0) || !val.EntityName.Contains(lootEntry.string_0, StringComparison.OrdinalIgnoreCase))
				{
					continue;
				}
				goto IL_0090;
			}
			return false;
		}
		return false;
		IL_0090:
		return true;
	}

	private bool TryPickup(EntityUid user, EntityUid item)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		try
		{
			SortedSet<Verb> localVerbs = ((SharedVerbSystem)verbSystem_0).GetLocalVerbs(item, user, typeof(InteractionVerb), false);
			Verb val = localVerbs.FirstOrDefault((Verb v) => v.Text.Contains("Pick Up", StringComparison.OrdinalIgnoreCase) || v.Text.Contains("Podb", StringComparison.OrdinalIgnoreCase) || v.Text == "Pick Up" || v.Text == "Взять");
			if (val == null)
			{
				Verb val2 = localVerbs.FirstOrDefault((Verb v) => !v.Text.Contains("Examine", StringComparison.OrdinalIgnoreCase) && !v.Text.Contains("Осмотреть", StringComparison.OrdinalIgnoreCase));
				if (val2 == null)
				{
					return false;
				}
				ientityManager_0.RaisePredictiveEvent<ExecuteVerbEvent>(new ExecuteVerbEvent(ientityManager_0.GetNetEntity(item, (MetaDataComponent)null), val2));
				return true;
			}
			ientityManager_0.RaisePredictiveEvent<ExecuteVerbEvent>(new ExecuteVerbEvent(ientityManager_0.GetNetEntity(item, (MetaDataComponent)null), val));
			return true;
		}
		catch (Exception)
		{
		}
		return false;
	}
}
