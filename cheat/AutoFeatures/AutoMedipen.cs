using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Content.Client.Verbs;
using Content.Shared.Chemistry.Components.SolutionManager;
using Content.Shared.Hands;
using Content.Shared.Hands.Components;
using Content.Shared.Hands.EntitySystems;
using Content.Shared.Inventory;
using Content.Shared.Mobs;
using Content.Shared.Mobs.Components;
using Content.Shared.Mobs.Systems;
using Content.Shared.Storage;
using Content.Shared.Storage.EntitySystems;
using Content.Shared.Verbs;
using Robust.Client.GameObjects;
using Robust.Client.Input;
using Robust.Client.Player;
using Robust.Shared.Containers;
using Robust.Shared.GameObjects;
using Robust.Shared.Input;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using DamageableHelper;
using CerberusConfig;

namespace AutoMedipen;

public class AutoMedipen : EntitySystem
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly IEntitySystemManager ientitySystemManager_0;

	[Dependency]
	private readonly IInputManager iinputManager_0;

	[Dependency]
	private readonly InputSystem inputSystem_0;

	[Dependency]
	private readonly SharedTransformSystem sharedTransformSystem_0;

	private VerbSystem verbSystem_0;

	private SharedHandsSystem sharedHandsSystem_0;

	private SharedStorageSystem sharedStorageSystem_0;

	private InventorySystem inventorySystem_0;

	private SharedContainerSystem sharedContainerSystem_0;

	private MobStateSystem mobStateSystem_0;

	private EntityUid? nullable_0;

	private TimeSpan timeSpan_0;

	private HashSet<string> hashSet_0 = new HashSet<string>();

	private TimeSpan timeSpan_1;

	private TimeSpan timeSpan_2;

	private EntityUid? nullable_1;

	private TimeSpan timeSpan_3;

	private EntityUid? nullable_3;

	private string string_0;

	private TimeSpan timeSpan_4;

	private bool bool_1;

	private float float_0;

	private byte byte_0;

	private float float_2;

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

	private float Single_0
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
		DamageableHelper.Initialize();
		((EntitySystem)this).SubscribeLocalEvent<LocalPlayerAttachedEvent>((EntityEventHandler<LocalPlayerAttachedEvent>)OnPlayerAttached, (Type[])null, (Type[])null);
	}

	private void OnPlayerAttached(LocalPlayerAttachedEvent ev)
	{
		nullable_1 = null;
		bool_1 = false;
	}

	private void InitializeSystems()
	{
		if (verbSystem_0 == null)
		{
			verbSystem_0 = ientitySystemManager_0.GetEntitySystem<VerbSystem>();
		}
		if (sharedHandsSystem_0 == null)
		{
			sharedHandsSystem_0 = ientitySystemManager_0.GetEntitySystem<SharedHandsSystem>();
		}
		if (sharedStorageSystem_0 == null)
		{
			sharedStorageSystem_0 = ientitySystemManager_0.GetEntitySystem<SharedStorageSystem>();
		}
		if (inventorySystem_0 == null)
		{
			inventorySystem_0 = ientitySystemManager_0.GetEntitySystem<InventorySystem>();
		}
		if (sharedContainerSystem_0 == null)
		{
			sharedContainerSystem_0 = ientitySystemManager_0.GetEntitySystem<SharedContainerSystem>();
		}
		if (mobStateSystem_0 == null)
		{
			mobStateSystem_0 = ientitySystemManager_0.GetEntitySystem<MobStateSystem>();
		}
	}

	public override void Update(float frameTime)
	{
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected I8, but got I4
		if (!CerberusConfig.AutoMedipen.Enabled)
		{
			return;
		}
		InitializeSystems();
		float_0 += frameTime;
		if (!(float_0 >= 0.2f))
		{
			return;
		}
		float_0 = 0f;
		if (igameTiming_0.CurTime < timeSpan_0)
		{
			return;
		}
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (!localEntity.HasValue || igameTiming_0.CurTime < timeSpan_2 + TimeSpan.FromSeconds(0.10000000149011612))
		{
			return;
		}
		timeSpan_2 = igameTiming_0.CurTime;
		(float, float, float)? playerHealth = GetPlayerHealth(localEntity.Value);
		if (!playerHealth.HasValue)
		{
			return;
		}
		float item = playerHealth.Value.Item1;
		float num = CerberusConfig.AutoMedipen.HpThreshold / 100f;
		if (!(item > num))
		{
			if (igameTiming_0.CurTime < timeSpan_1 + TimeSpan.FromSeconds(0.10000000149011612))
			{
				return;
			}
			int actionDelay = CerberusConfig.AutoMedipen.ActionDelay;
			if (actionDelay > 0 && igameTiming_0.CurTime < timeSpan_1 + TimeSpan.FromMilliseconds(actionDelay))
			{
				return;
			}
			if (bool_1 && igameTiming_0.CurTime > timeSpan_4 + TimeSpan.FromSeconds(0.20000000298023224))
			{
				bool_1 = false;
			}
			if (bool_1)
			{
				return;
			}
			if (!nullable_1.HasValue || !ientityManager_0.EntityExists(nullable_1.Value))
			{
				if (!TryFindMedipenInInventory(localEntity.Value, out var medipenUid))
				{
					if (hashSet_0.Count > 0)
					{
						timeSpan_0 = igameTiming_0.CurTime + TimeSpan.FromMinutes(1L);
						nullable_1 = null;
						nullable_0 = null;
						hashSet_0.Clear();
					}
					return;
				}
				nullable_1 = medipenUid;
			}
			TryUseMedipen(localEntity.Value, nullable_1.Value);
			timeSpan_1 = igameTiming_0.CurTime;
		}
		else if (nullable_1.HasValue || hashSet_0.Count > 0)
		{
			nullable_1 = null;
			bool_1 = false;
			nullable_0 = null;
			hashSet_0.Clear();
		}
	}

	private (float ratio, float damage, float max)? GetPlayerHealth(EntityUid playerUid)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		MobStateComponent comp = default(MobStateComponent);
		if (!ientityManager_0.TryGetComponent<MobStateComponent>(playerUid, ref comp))
		{
			return null;
		}
		if (!DamageableHelper.TryGetDamageableComponent(playerUid, ientityManager_0, out object component))
		{
			return null;
		}
		MobThresholdsComponent thresholds = default(MobThresholdsComponent);
		ientityManager_0.TryGetComponent<MobThresholdsComponent>(playerUid, ref thresholds);
		(float, float, float)? result = CalcHealth(playerUid, comp, component, thresholds);
		_ = result.HasValue;
		return result;
	}

	private (float ratio, float damage, float max)? CalcHealth(EntityUid uid, MobStateComponent comp, object damageableComp, MobThresholdsComponent thresholds)
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Invalid comparison between Unknown and I4
		//IL_01be: Invalid comparison between Unknown and I4
		if (damageableComp == null)
		{
			return null;
		}
		float totalDamage = DamageableHelper.GetTotalDamage(damageableComp);
		float num = 0f;
		float num2 = 0f;
		if (thresholds != null)
		{
			try
			{
				Type typeFromHandle = typeof(MobThresholdsComponent);
				FieldInfo fieldInfo = typeFromHandle.GetField("Thresholds", BindingFlags.Instance | BindingFlags.NonPublic) ?? typeFromHandle.GetField("_thresholds", BindingFlags.Instance | BindingFlags.NonPublic);
				if (fieldInfo != null && fieldInfo.GetValue(thresholds) is IDictionary dictionary)
				{
					foreach (DictionaryEntry item in dictionary)
					{
						MobState val = (MobState)item.Value;
						float num3 = NumericValue.FromObject(item.Key).ToFloat();
						if ((int)val == 2)
						{
							num = num3;
						}
						if ((int)val == 3)
						{
							num2 = num3;
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}
		if (num2 <= 0.1f)
		{
			num2 = 100f;
		}
		if (!(num > 0.1f))
		{
			num = num2;
		}
		float num4 = 0f;
		float num5 = num;
		if (mobStateSystem_0 != null && mobStateSystem_0.IsAlive(uid, comp))
		{
			if (num5 <= 0.1f)
			{
				num5 = 100f;
			}
			num4 = 1f - totalDamage / num5;
			num4 = Math.Clamp(num4, 0f, 1f);
		}
		else if (mobStateSystem_0 == null || !mobStateSystem_0.IsCritical(uid, comp))
		{
			num5 = ((!(num <= 0.1f)) ? num : 100f);
			num4 = Math.Clamp(1f - totalDamage / num5, 0f, 1f);
		}
		else
		{
			float num6 = totalDamage - num;
			float num7 = num2 - num;
			if (num7 > 0.1f)
			{
				num4 = 1f - num6 / num7;
				num4 = Math.Clamp(num4, 0f, 1f);
			}
			else
			{
				num4 = 0f;
			}
			num5 = num2;
		}
		return (num4, totalDamage, num5);
	}

	private bool TryFindMedipenInInventory(EntityUid playerUid, out EntityUid medipenUid)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		medipenUid = EntityUid.Invalid;
		nullable_3 = null;
		string_0 = null;
		HandsComponent val = default(HandsComponent);
		InventoryComponent val2 = default(InventoryComponent);
		if (!ientityManager_0.TryGetComponent<HandsComponent>(playerUid, ref val) || !ientityManager_0.TryGetComponent<InventoryComponent>(playerUid, ref val2))
		{
			return false;
		}
		foreach (string key in val.Hands.Keys)
		{
			EntityUid? heldItem = sharedHandsSystem_0.GetHeldItem(Entity<HandsComponent>.op_Implicit(playerUid), key);
			if (heldItem.HasValue && IsMedipen(heldItem.Value))
			{
				medipenUid = heldItem.Value;
				return true;
			}
		}
		string[] array = new string[4] { "belt", "pocket1", "pocket2", "back" };
		ContainerSlot val3 = default(ContainerSlot);
		SlotDefinition val4 = default(SlotDefinition);
		foreach (string text in array)
		{
			if (!inventorySystem_0.TryGetSlotContainer(playerUid, text, ref val3, ref val4, val2, (ContainerManagerComponent)null))
			{
				continue;
			}
			_ = ((BaseContainer)val3).Count;
			foreach (EntityUid containedEntity in ((BaseContainer)val3).ContainedEntities)
			{
				if (ientityManager_0.EntityExists(containedEntity))
				{
					if (IsMedipen(containedEntity))
					{
						medipenUid = containedEntity;
						string_0 = text;
						return true;
					}
					if (ientityManager_0.HasComponent<StorageComponent>(containedEntity) && TryFindMedipenInStorage(containedEntity, out var medipenUid2))
					{
						medipenUid = medipenUid2;
						nullable_3 = containedEntity;
						string_0 = text;
						return true;
					}
				}
			}
		}
		return false;
	}

	private void RaiseEventDynamic(object ev)
	{
		if (ev == null)
		{
			return;
		}
		try
		{
			MethodInfo methodInfo = ((AutoMedipen)(object)typeof(IEntityManager)).method_0().FirstOrDefault((MethodInfo m) => m.Name == "RaisePredictiveEvent" && m.IsGenericMethod && m.GetParameters().Length == 1);
			if (methodInfo != null)
			{
				methodInfo.MakeGenericMethod(ev.GetType()).Invoke(ientityManager_0, new object[1] { ev });
			}
		}
		catch (Exception)
		{
		}
	}

	private bool TryFindMedipenInStorage(EntityUid storageUid, out EntityUid medipenUid)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		medipenUid = EntityUid.Invalid;
		StorageComponent val = default(StorageComponent);
		if (ientityManager_0.TryGetComponent<StorageComponent>(storageUid, ref val))
		{
			foreach (EntityUid containedEntity in ((BaseContainer)val.Container).ContainedEntities)
			{
				if (IsMedipen(containedEntity))
				{
					medipenUid = containedEntity;
					goto IL_0031;
				}
			}
			return false;
		}
		return false;
		IL_0031:
		return true;
	}

	private bool IsMedipen(EntityUid entityUid)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		MetaDataComponent val = default(MetaDataComponent);
		if (ientityManager_0.TryGetComponent<MetaDataComponent>(entityUid, ref val))
		{
			if (val.EntityPrototype == null)
			{
				return false;
			}
			List<string> allowedMedipens = CerberusConfig.AutoMedipen.AllowedMedipens;
			if (allowedMedipens == null || allowedMedipens.Count == 0)
			{
				return val.EntityPrototype.ID.Equals("EmergencyMedipen", StringComparison.OrdinalIgnoreCase);
			}
			string fYv3pmlLJp = val.EntityPrototype.ID;
			if (hashSet_0.Contains(fYv3pmlLJp))
			{
				return false;
			}
			return allowedMedipens.Any((string id) => string.Equals(id, fYv3pmlLJp, StringComparison.OrdinalIgnoreCase));
		}
		return false;
	}

	private bool TrySendDropEvent(EntityUid playerUid, EntityUid itemUid)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			KeyFunctionId val;
			try
			{
				val = iinputManager_0.NetworkBindMap.KeyFunctionID(BoundKeyFunction.op_Implicit("Drop"));
			}
			catch
			{
				sharedHandsSystem_0.TryDrop(Entity<HandsComponent>.op_Implicit(playerUid), itemUid, (EntityCoordinates?)null, true, true);
				return true;
			}
			ScreenCoordinates mouseScreenPosition = iinputManager_0.MouseScreenPosition;
			EntityCoordinates moverCoordinates = sharedTransformSystem_0.GetMoverCoordinates(playerUid);
			ClientFullInputCmdMessage val2 = new ClientFullInputCmdMessage(igameTiming_0.CurTick, igameTiming_0.TickFraction, val);
			val2.set_State((BoundKeyState)1);
			val2.set_Coordinates(moverCoordinates);
			val2.set_ScreenCoordinates(mouseScreenPosition);
			val2.set_Uid(playerUid);
			ClientFullInputCmdMessage val3 = val2;
			ClientFullInputCmdMessage val4 = new ClientFullInputCmdMessage(igameTiming_0.CurTick, igameTiming_0.TickFraction, val);
			val4.set_State((BoundKeyState)0);
			val4.set_Coordinates(moverCoordinates);
			val4.set_ScreenCoordinates(mouseScreenPosition);
			val4.set_Uid(playerUid);
			ClientFullInputCmdMessage val5 = val4;
			inputSystem_0.HandleInputCommand(((ISharedPlayerManager)iplayerManager_0).LocalSession, BoundKeyFunction.op_Implicit("Drop"), (IFullInputCmdMessage)(object)val3, false);
			inputSystem_0.HandleInputCommand(((ISharedPlayerManager)iplayerManager_0).LocalSession, BoundKeyFunction.op_Implicit("Drop"), (IFullInputCmdMessage)(object)val5, false);
			return true;
		}
		catch (Exception)
		{
			sharedHandsSystem_0.TryDrop(Entity<HandsComponent>.op_Implicit(playerUid), itemUid, (EntityCoordinates?)null, true, true);
			return false;
		}
	}

	private void TryUseMedipen(EntityUid playerUid, EntityUid medipenUid)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Expected O, but got Unknown
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		if (ientityManager_0.EntityExists(medipenUid))
		{
			HandsComponent val = default(HandsComponent);
			if (!ientityManager_0.TryGetComponent<HandsComponent>(playerUid, ref val))
			{
				return;
			}
			EntityUid? val2 = nullable_0;
			EntityUid val3 = medipenUid;
			if (!val2.HasValue || !(val2.GetValueOrDefault() == val3) || !(igameTiming_0.CurTime > timeSpan_3 + TimeSpan.FromSeconds(0.05000000074505806)))
			{
				EntityUid? activeItem = sharedHandsSystem_0.GetActiveItem(Entity<HandsComponent>.op_Implicit(playerUid));
				val2 = activeItem;
				val3 = medipenUid;
				if (val2.HasValue && val2.GetValueOrDefault() == val3)
				{
					val2 = nullable_0;
					val3 = medipenUid;
					if (!val2.HasValue || val2.GetValueOrDefault() != val3)
					{
						ientityManager_0.RaisePredictiveEvent<RequestUseInHandEvent>(new RequestUseInHandEvent());
						nullable_0 = medipenUid;
						timeSpan_3 = igameTiming_0.CurTime;
						MetaDataComponent val4 = default(MetaDataComponent);
						if (ientityManager_0.TryGetComponent<MetaDataComponent>(medipenUid, ref val4) && val4.EntityPrototype != null)
						{
							hashSet_0.Add(val4.EntityPrototype.ID);
						}
					}
					return;
				}
				foreach (string key in val.Hands.Keys)
				{
					val2 = sharedHandsSystem_0.GetHeldItem(Entity<HandsComponent>.op_Implicit(playerUid), key);
					val3 = medipenUid;
					if (val2.HasValue && val2.GetValueOrDefault() == val3)
					{
						SwitchToHand(key);
						bool_1 = true;
						timeSpan_4 = igameTiming_0.CurTime;
						return;
					}
				}
				if (activeItem.HasValue)
				{
					string text = null;
					foreach (string key2 in val.Hands.Keys)
					{
						if (!sharedHandsSystem_0.GetHeldItem(Entity<HandsComponent>.op_Implicit(playerUid), key2).HasValue)
						{
							text = key2;
							break;
						}
					}
					if (text == null)
					{
						TrySendDropEvent(playerUid, activeItem.Value);
						timeSpan_1 = igameTiming_0.CurTime;
					}
					else
					{
						SwitchToHand(text);
						bool_1 = true;
						timeSpan_4 = igameTiming_0.CurTime;
					}
				}
				else
				{
					TryPutMedipenInHand(playerUid, medipenUid);
				}
			}
			else
			{
				TrySendDropEvent(playerUid, medipenUid);
				nullable_0 = null;
				nullable_1 = null;
				timeSpan_1 = igameTiming_0.CurTime;
			}
		}
		else
		{
			nullable_1 = null;
		}
	}

	private bool IsMedipenEmpty(EntityUid uid)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		SolutionContainerManagerComponent val = default(SolutionContainerManagerComponent);
		if (ientityManager_0.TryGetComponent<SolutionContainerManagerComponent>(uid, ref val))
		{
			foreach (string key in val.Solutions.Keys)
			{
				if ((!(key == "pen") && !(key == "hypospray")) || !(val.Solutions[key].Volume == 0))
				{
					continue;
				}
				goto IL_008d;
			}
		}
		return false;
		IL_008d:
		return true;
	}

	private void SwitchToHand(string handName)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		try
		{
			RequestSetHandEvent val = new RequestSetHandEvent(handName);
			ientityManager_0.RaisePredictiveEvent<RequestSetHandEvent>(val);
		}
		catch (Exception)
		{
		}
	}

	private void TryTakeMedipenFromContainer(EntityUid playerUid, EntityUid medipenUid, EntityUid containerUid)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (sharedHandsSystem_0.GetActiveItem(Entity<HandsComponent>.op_Implicit(playerUid)).HasValue)
			{
				return;
			}
			NetEntity netEntity = ientityManager_0.GetNetEntity(medipenUid, (MetaDataComponent)null);
			NetEntity netEntity2 = ientityManager_0.GetNetEntity(containerUid, (MetaDataComponent)null);
			if (!(netEntity != NetEntity.Invalid) || !(netEntity2 != NetEntity.Invalid))
			{
				return;
			}
			Type type = null;
			try
			{
				type = Type.GetType("Content.Shared.Storage.Events.StorageInteractWithItemEvent, Content.Shared") ?? Type.GetType("Content.Shared.Storage.StorageInteractWithItemEvent, Content.Shared");
			}
			catch
			{
			}
			if (type != null)
			{
				try
				{
					object obj2 = Activator.CreateInstance(type, netEntity, netEntity2);
					MethodInfo methodInfo = ((AutoMedipen)(object)typeof(IEntityManager)).method_0().FirstOrDefault((MethodInfo m) => m.Name == "RaisePredictiveEvent" && m.IsGenericMethod && m.GetParameters().Length == 1);
					if (methodInfo != null)
					{
						methodInfo.MakeGenericMethod(type).Invoke(ientityManager_0, new object[1] { obj2 });
						return;
					}
				}
				catch (Exception)
				{
				}
			}
			TryPutMedipenInHand(playerUid, medipenUid);
		}
		catch (Exception)
		{
		}
	}

	private bool TryPutMedipenInHand(EntityUid playerUid, EntityUid medipenUid)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		try
		{
			Verb val = ((SharedVerbSystem)verbSystem_0).GetLocalVerbs(medipenUid, playerUid, typeof(InteractionVerb), false).FirstOrDefault((Verb v) => v.Text.Contains("Put in hand", StringComparison.OrdinalIgnoreCase) || v.Text.Contains("Взять в руку", StringComparison.OrdinalIgnoreCase) || v.Text == "Put in hand");
			if (val != null)
			{
				NetEntity netEntity = ientityManager_0.GetNetEntity(medipenUid, (MetaDataComponent)null);
				ientityManager_0.RaisePredictiveEvent<ExecuteVerbEvent>(new ExecuteVerbEvent(netEntity, val));
				goto IL_0073;
			}
		}
		catch
		{
		}
		return false;
		IL_0073:
		return true;
	}

	private void UseMedipenVerb(EntityUid playerUid, EntityUid medipenUid)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		try
		{
			SortedSet<Verb> localVerbs = ((SharedVerbSystem)verbSystem_0).GetLocalVerbs(medipenUid, playerUid, typeof(InteractionVerb), false);
			foreach (Verb item in localVerbs)
			{
				_ = item;
			}
			Verb val = localVerbs.FirstOrDefault((Verb v) => v.Text.Contains("Use", StringComparison.OrdinalIgnoreCase) || v.Text.Contains("Inject", StringComparison.OrdinalIgnoreCase) || v.Text.Contains("Activate", StringComparison.OrdinalIgnoreCase) || v.Text.Contains("Использовать", StringComparison.OrdinalIgnoreCase) || v.Text.Contains("Уколоть", StringComparison.OrdinalIgnoreCase) || v.Text.Contains("Применить", StringComparison.OrdinalIgnoreCase));
			if (val == null)
			{
				foreach (Verb item2 in localVerbs)
				{
					_ = item2;
				}
				return;
			}
			NetEntity netEntity = ientityManager_0.GetNetEntity(medipenUid, (MetaDataComponent)null);
			ientityManager_0.RaisePredictiveEvent<ExecuteVerbEvent>(new ExecuteVerbEvent(netEntity, val));
		}
		catch (Exception)
		{
		}
	}

	public MethodInfo[] method_0()
	{
		return ((Type)this).GetMethods();
	}
}
