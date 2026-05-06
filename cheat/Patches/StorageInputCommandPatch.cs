using System;
using System.Collections.Generic;
using System.Reflection;
using Content.Shared.Hands.Components;
using Content.Shared.Hands.EntitySystems;
using Content.Shared.Input;
using Content.Shared.Inventory;
using Content.Shared.Inventory.Events;
using Content.Shared.Item;
using Content.Shared.Storage;
using HarmonyLib;
using Robust.Shared.Containers;
using Robust.Shared.GameObjects;
using Robust.Shared.Input;
using Robust.Shared.IoC;
using Robust.Shared.Player;
using CerberusConfig;

namespace StorageInputCommandPatch;

public sealed class StorageInputCommandPatch
{
	private static readonly Type? type_0;

	private static readonly ConstructorInfo? constructorInfo_0;

	private static readonly MethodInfo? methodInfo_0;

	private bool bool_0;

	private float float_2;

	private char char_0;

	private double double_0;

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

	static StorageInputCommandPatch()
	{
		type_0 = AccessTools.TypeByName("Robust.Shared.GameObjects.BoundUIWrapMessage");
		constructorInfo_0 = (ConstructorInfo?)((StorageInputCommandPatch)(object)type_0)?.method_1(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, (object)null, new Type[3]
		{
			typeof(NetEntity),
			typeof(BoundUserInterfaceMessage),
			typeof(Enum)
		}, (ParameterModifier[])null);
		methodInfo_0 = ((type_0 == null) ? null : ((MethodInfo)((StorageInputCommandPatch)(object)typeof(IEntityManager)).method_0("RaisePredictiveEvent"))?.MakeGenericMethod(new Type[1] { type_0 }));
	}

	public static bool PrefixHandleInputCommand(ICommonSession? session, BoundKeyFunction function, IFullInputCmdMessage message, ref bool __result)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Invalid comparison between Unknown and I4
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if (CerberusConfig.InstantPickup.SmartEquipEnabled)
		{
			if ((int)message.State != 1)
			{
				return true;
			}
			if (!TryGetStorageSlot(function, out string slot))
			{
				return true;
			}
			try
			{
				if (TryTakeLastStoredItem(session, slot))
				{
					__result = true;
					return false;
				}
				return true;
			}
			catch
			{
				return true;
			}
		}
		return true;
	}

	private static bool TryGetStorageSlot(BoundKeyFunction function, out string slot)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		if (function == ContentKeyFunctions.SmartEquipBackpack)
		{
			slot = "back";
			return true;
		}
		if (!(function == ContentKeyFunctions.SmartEquipBelt))
		{
			slot = string.Empty;
			return false;
		}
		slot = "belt";
		return true;
	}

	private static bool TryTakeLastStoredItem(ICommonSession? session, string slot)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Expected O, but got Unknown
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		EntityUid? val = ((session == null) ? ((EntityUid?)null) : session.AttachedEntity);
		IEntityManager val2;
		EntityUid? val6 = default(EntityUid?);
		EntityUid val8;
		int num;
		if (val.HasValue)
		{
			EntityUid value = val.Value;
			if (((EntityUid)(ref value)).Valid)
			{
				val2 = IoCManager.Resolve<IEntityManager>();
				if (val2.EntityExists(val.Value))
				{
					InventorySystem val3 = default(InventorySystem);
					SharedHandsSystem val4 = default(SharedHandsSystem);
					HandsComponent val5 = default(HandsComponent);
					if (!val2.TrySystem<InventorySystem>(ref val3) || !val2.TrySystem<SharedHandsSystem>(ref val4) || !val2.TryGetComponent<HandsComponent>(val.Value, ref val5) || val5.ActiveHandId == null)
					{
						return false;
					}
					if (val4.GetActiveItem(Entity<HandsComponent>.op_Implicit((val.Value, val5))).HasValue)
					{
						return false;
					}
					if (!val3.TryGetSlotEntity(val.Value, slot, ref val6, (InventoryComponent)null, (ContainerManagerComponent)null) || !val6.HasValue)
					{
						return false;
					}
					StorageComponent val7 = default(StorageComponent);
					if (val2.TryGetComponent<StorageComponent>(val6.Value, ref val7))
					{
						IReadOnlyList<EntityUid> containedEntities = ((BaseContainer)val7.Container).ContainedEntities;
						if (containedEntities.Count == 0)
						{
							return false;
						}
						val8 = containedEntities[containedEntities.Count - 1];
						if (val2.EntityExists(val8) && val2.HasComponent<ItemComponent>(val8))
						{
							SharedUserInterfaceSystem val9 = default(SharedUserInterfaceSystem);
							if (!val2.TrySystem<SharedUserInterfaceSystem>(ref val9))
							{
								num = 0;
								if (num == 0)
								{
									goto IL_0129;
								}
							}
							else
							{
								num = (val9.IsUiOpen(Entity<UserInterfaceComponent>.op_Implicit(val6.Value), (Enum)(object)(StorageUiKey)0, val.Value) ? 1 : 0);
								if (num == 0)
								{
									goto IL_0129;
								}
							}
							goto IL_0135;
						}
						return false;
					}
					return false;
				}
				return false;
			}
		}
		return false;
		IL_0129:
		val2.RaisePredictiveEvent<OpenSlotStorageNetworkMessage>(new OpenSlotStorageNetworkMessage(slot));
		goto IL_0135;
		IL_0135:
		val2.RaisePredictiveEvent<StorageInteractWithItemEvent>(new StorageInteractWithItemEvent(val2.GetNetEntity(val8, (MetaDataComponent)null), val2.GetNetEntity(val6.Value, (MetaDataComponent)null)));
		if (num == 0)
		{
			TryCloseStorageUi(val2, val6.Value);
		}
		return true;
	}

	private static void TryCloseStorageUi(IEntityManager entityManager, EntityUid storage)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		if (constructorInfo_0 == null || methodInfo_0 == null)
		{
			return;
		}
		try
		{
			CloseBoundInterfaceMessage val = new CloseBoundInterfaceMessage();
			object obj = constructorInfo_0.Invoke(new object[3]
			{
				entityManager.GetNetEntity(storage, (MetaDataComponent)null),
				val,
				(object)(StorageUiKey)0
			});
			methodInfo_0.Invoke(entityManager, new object[1] { obj });
		}
		catch
		{
		}
	}

	public object method_0(string string_1)
	{
		return ((Type)this).GetMethod(string_1);
	}

	public object method_1(BindingFlags bindingFlags_0, object object_4, Type[] type_1, ParameterModifier[] parameterModifier_0)
	{
		return ((Type)this).GetConstructor(bindingFlags_0, (Binder?)object_4, type_1, parameterModifier_0);
	}

	private string method_11(byte byte_1)
	{
		return "Хитролох_иди_нахуй._1___1__6___6________3";
	}
}
