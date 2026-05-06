using System;
using System.Linq;
using System.Numerics;
using Content.Shared.Clothing.Components;
using Content.Shared.Hands.Components;
using Content.Shared.Hands.EntitySystems;
using Content.Shared.Interaction;
using Content.Shared.Inventory;
using Content.Shared.Strip;
using Content.Shared.Strip.Components;
using Content.Shared.Weapons.Melee;
using Content.Shared.Weapons.Ranged.Components;
using Robust.Client.Player;
using Robust.Shared.Containers;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using CerberusConfig;

namespace AutoStrip;

public sealed class AutoStrip : EntitySystem
{
	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	private SharedTransformSystem? sharedTransformSystem_0;

	private SharedInteractionSystem? sharedInteractionSystem_0;

	private InventorySystem? inventorySystem_0;

	private SharedStrippableSystem? sharedStrippableSystem_0;

	private SharedUserInterfaceSystem? sharedUserInterfaceSystem_0;

	private EntityUid? nullable_0;

	private TimeSpan timeSpan_0 = TimeSpan.Zero;

	private bool bool_0;

	private bool bool_1;

	private float float_0;

	private double double_1;

	private char char_0;

	private char char_1;

	private char char_2;

	private double Double_0
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
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

	private char Char_1
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

	private char Char_2
	{
		get
		{
			return char_2;
		}
		set
		{
			char_2 = value;
		}
	}

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
		sharedTransformSystem_0 = ientityManager_0.System<SharedTransformSystem>();
		sharedInteractionSystem_0 = ientityManager_0.System<SharedInteractionSystem>();
		inventorySystem_0 = ientityManager_0.System<InventorySystem>();
		sharedStrippableSystem_0 = ientityManager_0.System<SharedStrippableSystem>();
		sharedUserInterfaceSystem_0 = ientityManager_0.System<SharedUserInterfaceSystem>();
	}

	public void SetStripTarget(EntityUid target)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		nullable_0 = target;
		bool_1 = false;
	}

	public void ClearTarget()
	{
		nullable_0 = null;
		bool_1 = false;
	}

	public override void Update(float frameTime)
	{
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.AutoStrip.Enabled)
		{
			nullable_0 = null;
			bool_1 = false;
			bool_0 = false;
			return;
		}
		float_0 += frameTime;
		if (!(float_0 >= 0.2f))
		{
			return;
		}
		float_0 = 0f;
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (!localEntity.HasValue)
		{
			return;
		}
		bool flag = (int)CerberusConfig.AutoStrip.StripAllKey != 0 && KeyStateHelper.IsKeyDown(CerberusConfig.AutoStrip.StripAllKey);
		if (flag && !bool_0 && nullable_0.HasValue)
		{
			TryStripAll(localEntity.Value, nullable_0.Value);
		}
		bool_0 = flag;
		if (nullable_0.HasValue && !bool_1)
		{
			TryOpenStripUI(localEntity.Value, nullable_0.Value);
		}
		if (!((igameTiming_0.CurTime - timeSpan_0).TotalSeconds >= (double)CerberusConfig.AutoStrip.Cooldown) || !nullable_0.HasValue)
		{
			return;
		}
		try
		{
			if (ientityManager_0.EntityExists(nullable_0.Value))
			{
				if (sharedTransformSystem_0 != null)
				{
					Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(localEntity.Value);
					Vector2 worldPosition2 = sharedTransformSystem_0.GetWorldPosition(nullable_0.Value);
					if (Vector2.Distance(worldPosition, worldPosition2) > CerberusConfig.AutoStrip.Range)
					{
						return;
					}
				}
				if (CerberusConfig.AutoStrip.AutoMode && StripNextItem(localEntity.Value, nullable_0.Value))
				{
					timeSpan_0 = igameTiming_0.CurTime;
				}
			}
			else
			{
				nullable_0 = null;
				bool_1 = false;
			}
		}
		catch (Exception)
		{
		}
	}

	private void TryOpenStripUI(EntityUid player, EntityUid target)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			StrippableComponent item = default(StrippableComponent);
			if (sharedStrippableSystem_0 != null && sharedUserInterfaceSystem_0 != null && ientityManager_0.TryGetComponent<StrippableComponent>(target, ref item) && sharedStrippableSystem_0.TryOpenStrippingUi(player, Entity<StrippableComponent>.op_Implicit((target, item)), true))
			{
				bool_1 = true;
			}
		}
		catch (Exception)
		{
		}
	}

	private void TryStripAll(EntityUid player, EntityUid target)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			SlotDefinition[] array = default(SlotDefinition[]);
			if (inventorySystem_0 == null || !inventorySystem_0.TryGetSlots(target, ref array))
			{
				return;
			}
			int num = 0;
			SlotDefinition[] array2 = array;
			EntityUid? val2 = default(EntityUid?);
			foreach (SlotDefinition val in array2)
			{
				if (inventorySystem_0.TryGetSlotEntity(target, val.Name, ref val2, (InventoryComponent)null, (ContainerManagerComponent)null) && inventorySystem_0.TryUnequip(player, target, val.Name, false, false, true, (InventoryComponent)null, (ClothingComponent)null, true, false, false))
				{
					num++;
				}
			}
			HandsComponent val3 = default(HandsComponent);
			if (ientityManager_0.TryGetComponent<HandsComponent>(target, ref val3))
			{
				SharedHandsSystem val4 = ientityManager_0.System<SharedHandsSystem>();
				foreach (string item in val3.Hands.Keys.ToList())
				{
					EntityUid? heldItem = val4.GetHeldItem(Entity<HandsComponent>.op_Implicit(target), item);
					if (heldItem.HasValue && val4.TryDrop(Entity<HandsComponent>.op_Implicit(target), heldItem.Value, (EntityCoordinates?)null, true, true))
					{
						num++;
					}
				}
			}
			timeSpan_0 = igameTiming_0.CurTime;
		}
		catch (Exception)
		{
		}
	}

	private bool StripNextItem(EntityUid player, EntityUid target)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		if (inventorySystem_0 == null || sharedInteractionSystem_0 == null)
		{
			return false;
		}
		if (!CerberusConfig.AutoStrip.StripWeaponsFirst || !TryStripWeaponFromHands(player, target))
		{
			if (CerberusConfig.AutoStrip.StripArmor && TryStripArmor(player, target))
			{
				return true;
			}
			if (CerberusConfig.AutoStrip.StripClothing && TryStripClothing(player, target))
			{
				return true;
			}
			return false;
		}
		return true;
	}

	private bool TryStripWeaponFromHands(EntityUid player, EntityUid target)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		SharedHandsSystem val = ientityManager_0.System<SharedHandsSystem>();
		HandsComponent val2 = default(HandsComponent);
		if (!ientityManager_0.TryGetComponent<HandsComponent>(target, ref val2))
		{
			return false;
		}
		foreach (string key in val2.Hands.Keys)
		{
			EntityUid? heldItem = val.GetHeldItem(Entity<HandsComponent>.op_Implicit(target), key);
			if (!heldItem.HasValue)
			{
				continue;
			}
			EntityUid value = heldItem.Value;
			if (!ientityManager_0.HasComponent<GunComponent>(value) && !ientityManager_0.HasComponent<MeleeWeaponComponent>(value))
			{
				continue;
			}
			sharedInteractionSystem_0.InteractHand(player, target);
			goto IL_00bf;
		}
		return false;
		IL_00bf:
		return true;
	}

	private bool TryStripArmor(EntityUid player, EntityUid target)
	{
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		string[] array = new string[4] { "outerClothing", "head", "gloves", "shoes" };
		int num = 0;
		EntityUid? val = default(EntityUid?);
		ClothingComponent val2 = default(ClothingComponent);
		while (true)
		{
			if (num >= array.Length)
			{
				return false;
			}
			string text = array[num];
			if (inventorySystem_0.TryGetSlotEntity(target, text, ref val, (InventoryComponent)null, (ContainerManagerComponent)null) && ientityManager_0.TryGetComponent<ClothingComponent>(val.Value, ref val2))
			{
				break;
			}
			num++;
		}
		sharedInteractionSystem_0.InteractHand(player, target);
		return true;
	}

	private bool TryStripClothing(EntityUid player, EntityUid target)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		string[] array = new string[7] { "jumpsuit", "neck", "back", "belt", "pocket1", "pocket2", "id" };
		EntityUid? val = default(EntityUid?);
		foreach (string text in array)
		{
			if (inventorySystem_0.TryGetSlotEntity(target, text, ref val, (InventoryComponent)null, (ContainerManagerComponent)null))
			{
				sharedInteractionSystem_0.InteractHand(player, target);
				return true;
			}
		}
		return false;
	}
}
