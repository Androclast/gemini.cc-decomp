using System;
using System.Collections.Generic;
using System.Linq;
using Content.Client.Verbs;
using Content.Shared.FixedPoint;
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
using Hexa.NET.ImGui;
using Robust.Client.Player;
using Robust.Shared.Containers;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using DamageableHelper;
using CerberusConfig;

namespace AutoHypo;

public sealed class AutoHypo : EntitySystem
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly IEntitySystemManager ientitySystemManager_0;

	private VerbSystem verbSystem_0;

	private SharedHandsSystem sharedHandsSystem_0;

	private SharedStorageSystem sharedStorageSystem_0;

	private InventorySystem inventorySystem_0;

	private SharedContainerSystem sharedContainerSystem_0;

	private MobStateSystem mobStateSystem_0;

	private EntityUid? nullable_0;

	private EntityUid? nullable_1;

	private TimeSpan timeSpan_0;

	private TimeSpan timeSpan_1;

	private TimeSpan timeSpan_2;

	private bool bool_0;

	private TimeSpan timeSpan_3;

	private int int_0;

	private bool bool_1;

	private bool bool_2;

	private float float_0;

	private string string_1;

	private int int_1;

	private byte byte_0;

	private string String_0
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

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
		DamageableHelper.Initialize();
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
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.AutoHypo.Enabled)
		{
			return;
		}
		InitializeSystems();
		ImGuiKey forceKey = CerberusConfig.AutoHypo.ForceKey;
		if ((int)forceKey != 0)
		{
			bool flag = KeyStateHelper.IsKeyDown(forceKey);
			if (flag && !bool_2)
			{
				bool_1 = true;
				int_0 = 0;
				nullable_0 = null;
				Logger.Info("[AutoHypo] Force triggered");
			}
			bool_2 = flag;
		}
		float_0 += frameTime;
		if (!(float_0 >= 0.2f))
		{
			return;
		}
		float_0 = 0f;
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (!localEntity.HasValue || igameTiming_0.CurTime < timeSpan_1 + TimeSpan.FromSeconds(0.10000000149011612))
		{
			return;
		}
		timeSpan_1 = igameTiming_0.CurTime;
		bool flag2 = bool_1;
		if (!flag2)
		{
			(float, float, float)? playerHealth = GetPlayerHealth(localEntity.Value);
			if (!playerHealth.HasValue)
			{
				return;
			}
			float item = playerHealth.Value.Item1;
			float num = CerberusConfig.AutoHypo.HpThreshold / 100f;
			if (item > num)
			{
				if (int_0 > 0 || nullable_0.HasValue)
				{
					nullable_0 = null;
					int_0 = 0;
					bool_0 = false;
				}
				return;
			}
			flag2 = true;
		}
		if (!flag2)
		{
			return;
		}
		int injectCount = CerberusConfig.AutoHypo.InjectCount;
		if (int_0 < injectCount)
		{
			if (igameTiming_0.CurTime < timeSpan_0 + TimeSpan.FromSeconds(0.10000000149011612))
			{
				return;
			}
			if (bool_0 && igameTiming_0.CurTime > timeSpan_3 + TimeSpan.FromSeconds(0.20000000298023224))
			{
				bool_0 = false;
			}
			if (bool_0)
			{
				return;
			}
			if (!nullable_0.HasValue || !ientityManager_0.EntityExists(nullable_0.Value))
			{
				if (!TryFindHypoInInventory(localEntity.Value, out var hypoUid))
				{
					return;
				}
				nullable_0 = hypoUid;
			}
			TryUseHypo(localEntity.Value, nullable_0.Value);
			timeSpan_0 = igameTiming_0.CurTime;
		}
		else
		{
			bool_1 = false;
			int_0 = 0;
			nullable_0 = null;
		}
	}

	private (float ratio, float damage, float max)? GetPlayerHealth(EntityUid playerUid)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		MobStateComponent mob = default(MobStateComponent);
		if (ientityManager_0.TryGetComponent<MobStateComponent>(playerUid, ref mob))
		{
			if (!DamageableHelper.TryGetDamageableComponent(playerUid, ientityManager_0, out object component))
			{
				return null;
			}
			return CalcHealth(playerUid, mob, component);
		}
		return null;
	}

	private (float ratio, float damage, float max)? CalcHealth(EntityUid uid, MobStateComponent mob, object damageableComp)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			float totalDamage = DamageableHelper.GetTotalDamage(damageableComp);
			float num = 100f;
			MobThresholdsComponent val = default(MobThresholdsComponent);
			if (ientityManager_0.TryGetComponent<MobThresholdsComponent>(uid, ref val))
			{
				try
				{
					float? num2 = val.Thresholds.Where((KeyValuePair<FixedPoint2, MobState> t) => (int)t.Value == 3).Select((Func<KeyValuePair<FixedPoint2, MobState>, float?>)delegate(KeyValuePair<FixedPoint2, MobState> t)
					{
						//IL_0002: Unknown result type (might be due to invalid IL or missing references)
						//IL_0007: Unknown result type (might be due to invalid IL or missing references)
						FixedPoint2 key = t.Key;
						return ((FixedPoint2)(ref key)).Float();
					}).FirstOrDefault();
					if (num2.HasValue && num2.Value > 0f)
					{
						num = num2.Value;
					}
				}
				catch
				{
				}
			}
			return (1f - Math.Clamp(totalDamage / num, 0f, 1f), totalDamage, num);
		}
		catch
		{
			return null;
		}
	}

	private bool TryFindHypoInInventory(EntityUid playerUid, out EntityUid hypoUid)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		hypoUid = default(EntityUid);
		if (sharedHandsSystem_0 != null && inventorySystem_0 != null)
		{
			HandsComponent val = default(HandsComponent);
			if (ientityManager_0.TryGetComponent<HandsComponent>(playerUid, ref val))
			{
				foreach (string key in val.Hands.Keys)
				{
					EntityUid? heldItem = sharedHandsSystem_0.GetHeldItem(Entity<HandsComponent>.op_Implicit(playerUid), key);
					if (!heldItem.HasValue || !IsHypo(heldItem.Value))
					{
						continue;
					}
					hypoUid = heldItem.Value;
					goto IL_00b3;
				}
			}
			InventoryComponent val2 = default(InventoryComponent);
			if (ientityManager_0.TryGetComponent<InventoryComponent>(playerUid, ref val2))
			{
				string[] array = new string[13]
				{
					"back", "belt", "pocket1", "pocket2", "innerclothing", "outerclothing", "shoes", "gloves", "head", "mask",
					"ears", "id", "suitstorage"
				};
				EntityUid? val3 = default(EntityUid?);
				foreach (string text in array)
				{
					if (inventorySystem_0.TryGetSlotEntity(playerUid, text, ref val3, (InventoryComponent)null, (ContainerManagerComponent)null) && val3.HasValue)
					{
						if (IsHypo(val3.Value))
						{
							hypoUid = val3.Value;
							return true;
						}
						if (ientityManager_0.HasComponent<StorageComponent>(val3.Value) && TryFindHypoInStorage(val3.Value, out var hypoUid2))
						{
							hypoUid = hypoUid2;
							return true;
						}
					}
				}
			}
			return false;
		}
		return false;
		IL_00b3:
		return true;
	}

	private bool TryFindHypoInStorage(EntityUid storageUid, out EntityUid hypoUid)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		hypoUid = default(EntityUid);
		if (sharedContainerSystem_0 != null)
		{
			BaseContainer val = default(BaseContainer);
			if (sharedContainerSystem_0.TryGetContainer(storageUid, "storagebase", ref val, (ContainerManagerComponent)null))
			{
				foreach (EntityUid containedEntity in val.ContainedEntities)
				{
					if (!IsHypo(containedEntity))
					{
						continue;
					}
					hypoUid = containedEntity;
					goto IL_007c;
				}
			}
			return false;
		}
		return false;
		IL_007c:
		return true;
	}

	private bool IsHypo(EntityUid entityUid)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		MetaDataComponent val = default(MetaDataComponent);
		if (ientityManager_0.TryGetComponent<MetaDataComponent>(entityUid, ref val))
		{
			if (val.EntityPrototype != null)
			{
				string iD = val.EntityPrototype.ID;
				if (iD.Contains("Hypo", StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
				return iD.Contains("hypospray", StringComparison.OrdinalIgnoreCase);
			}
			return false;
		}
		return false;
	}

	private void TryUseHypo(EntityUid playerUid, EntityUid hypoUid)
	{
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		if (!ientityManager_0.EntityExists(hypoUid))
		{
			nullable_0 = null;
		}
		else
		{
			HandsComponent val = default(HandsComponent);
			if (!ientityManager_0.TryGetComponent<HandsComponent>(playerUid, ref val))
			{
				return;
			}
			EntityUid? val2 = nullable_1;
			EntityUid val3 = hypoUid;
			if (val2.HasValue && val2.GetValueOrDefault() == val3 && igameTiming_0.CurTime > timeSpan_2 + TimeSpan.FromSeconds(0.05000000074505806))
			{
				int_0++;
				nullable_1 = null;
				nullable_0 = null;
				timeSpan_0 = igameTiming_0.CurTime;
				return;
			}
			EntityUid? activeItem = sharedHandsSystem_0.GetActiveItem(Entity<HandsComponent>.op_Implicit(playerUid));
			val2 = activeItem;
			val3 = hypoUid;
			if (!val2.HasValue || !(val2.GetValueOrDefault() == val3))
			{
				foreach (string key in val.Hands.Keys)
				{
					val2 = sharedHandsSystem_0.GetHeldItem(Entity<HandsComponent>.op_Implicit(playerUid), key);
					val3 = hypoUid;
					if (val2.HasValue && val2.GetValueOrDefault() == val3)
					{
						SwitchToHand(key);
						bool_0 = true;
						timeSpan_3 = igameTiming_0.CurTime;
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
					if (text != null)
					{
						SwitchToHand(text);
						bool_0 = true;
						timeSpan_3 = igameTiming_0.CurTime;
					}
				}
				else
				{
					TryPutHypoInHand(playerUid, hypoUid);
				}
			}
			else
			{
				val2 = nullable_1;
				val3 = hypoUid;
				if (!val2.HasValue || val2.GetValueOrDefault() != val3)
				{
					ientityManager_0.RaisePredictiveEvent<RequestUseInHandEvent>(new RequestUseInHandEvent());
					nullable_1 = hypoUid;
					timeSpan_2 = igameTiming_0.CurTime;
				}
			}
		}
	}

	private void SwitchToHand(string handName)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		try
		{
			ientityManager_0.RaisePredictiveEvent<RequestSetHandEvent>(new RequestSetHandEvent(handName));
		}
		catch
		{
		}
	}

	private void TryPutHypoInHand(EntityUid playerUid, EntityUid hypoUid)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		try
		{
			Verb val = ((SharedVerbSystem)verbSystem_0).GetLocalVerbs(hypoUid, playerUid, typeof(InteractionVerb), false).FirstOrDefault((Verb v) => v.Text.Contains("Put in hand", StringComparison.OrdinalIgnoreCase) || v.Text.Contains("Взять в руку", StringComparison.OrdinalIgnoreCase));
			if (val != null)
			{
				ientityManager_0.RaisePredictiveEvent<ExecuteVerbEvent>(new ExecuteVerbEvent(ientityManager_0.GetNetEntity(hypoUid, (MetaDataComponent)null), val));
			}
		}
		catch
		{
		}
	}
}
