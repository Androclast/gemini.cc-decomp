using System.Numerics;
using System.Runtime.CompilerServices;
using Content.Shared.Inventory;
using Content.Shared.Movement.Components;
using Content.Shared.Slippery;
using Content.Shared.StepTrigger.Components;
using Robust.Client.GameObjects;
using Robust.Client.Graphics;
using Robust.Client.Input;
using Robust.Client.Player;
using Robust.Shared.Containers;
using Robust.Shared.GameObjects;
using Robust.Shared.Input;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Physics.Components;
using Robust.Shared.Player;
using Robust.Shared.Prototypes;
using Robust.Shared.Timing;
using CerberusConfig;

[CompilerGenerated]
public sealed class AutoSlipMovement : EntitySystem
{
	private KeyFunctionId keyFunctionId_0;

	private bool bool_0;

	[Dependency]
	private readonly IEyeManager ieyeManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly IInputManager iinputManager_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly InputSystem inputSystem_0;

	[Dependency]
	private readonly EntityLookupSystem entityLookupSystem_0;

	[Dependency]
	private readonly ContainerSystem containerSystem_0;

	[Dependency]
	private readonly SharedTransformSystem sharedTransformSystem_0;

	private bool bool_1;

	private bool bool_2;

	private string string_0;

	private long long_0;

	private byte byte_1;

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
			return byte_1;
		}
		set
		{
			byte_1 = value;
		}
	}

	public override void Initialize()
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		((EntitySystem)this).Initialize();
		if (!bool_0 && iinputManager_0 != null)
		{
			keyFunctionId_0 = iinputManager_0.NetworkBindMap.KeyFunctionID(EngineKeyFunctions.Walk);
			bool_0 = true;
		}
	}

	public override void FrameUpdate(float frameTime)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.Misc.AntiSoapEnabled)
		{
			return;
		}
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (localEntity.HasValue)
		{
			bool flag = ShouldPressWalk(localEntity.Value);
			if (flag != bool_2)
			{
				bool_1 = true;
				bool_2 = flag;
				PressWalk((BoundKeyState)flag);
			}
		}
	}

	private void PressWalk(BoundKeyState state)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (!localEntity.HasValue)
		{
			return;
		}
		EntityUid value = localEntity.Value;
		if (CanSlip(value))
		{
			EntityCoordinates moverCoordinates = sharedTransformSystem_0.GetMoverCoordinates(value);
			ScreenCoordinates screenCoordinates = ieyeManager_0.CoordinatesToScreen(moverCoordinates);
			if (!bool_0)
			{
				keyFunctionId_0 = iinputManager_0.NetworkBindMap.KeyFunctionID(EngineKeyFunctions.Walk);
				bool_0 = true;
			}
			ClientFullInputCmdMessage val = new ClientFullInputCmdMessage(igameTiming_0.CurTick, igameTiming_0.TickFraction, keyFunctionId_0);
			val.set_State(state);
			val.set_Coordinates(moverCoordinates);
			val.set_ScreenCoordinates(screenCoordinates);
			val.set_Uid(EntityUid.Invalid);
			ClientFullInputCmdMessage val2 = val;
			inputSystem_0.HandleInputCommand(((ISharedPlayerManager)iplayerManager_0).LocalSession, EngineKeyFunctions.Walk, (IFullInputCmdMessage)(object)val2, false);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private bool ShouldPressWalk(EntityUid player)
	{
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		bool flag = false;
		BaseContainer val = default(BaseContainer);
		if (((SharedContainerSystem)containerSystem_0).TryGetContainer(player, "shoes", ref val, (ContainerManagerComponent)null) && val.ContainedEntities.Count > 0)
		{
			flag = true;
		}
		TransformComponent val2 = default(TransformComponent);
		if (((EntitySystem)this).TryComp<TransformComponent>(player, ref val2))
		{
			Vector2 position = val2.MapPosition.Position;
			Vector2 vector = Vector2.Zero;
			float num = 0f;
			PhysicsComponent val3 = default(PhysicsComponent);
			if (((EntitySystem)this).TryComp<PhysicsComponent>(player, ref val3))
			{
				vector = val3.LinearVelocity;
				num = vector.Length();
			}
			if (num >= 0.1f)
			{
				float num2 = 1f + num * 0.4f;
				if (num2 > 3f)
				{
					num2 = 3f;
				}
				TransformComponent val4 = default(TransformComponent);
				StepTriggerComponent val5 = default(StepTriggerComponent);
				MetaDataComponent val6 = default(MetaDataComponent);
				foreach (EntityUid item in entityLookupSystem_0.GetEntitiesInRange(player, num2, (LookupFlags)110))
				{
					if ((((EntitySystem)this).TryComp<TransformComponent>(item, ref val4) && val4.ParentUid == player) || IsOwnedByLocalPlayer(item) || !((EntitySystem)this).TryComp<StepTriggerComponent>(item, ref val5) || !val5.Active || !((EntitySystem)this).HasComp<SlipperyComponent>(item))
					{
						continue;
					}
					bool flag2 = false;
					if (((EntitySystem)this).TryComp<MetaDataComponent>(item, ref val6))
					{
						EntityPrototype entityPrototype = val6.EntityPrototype;
						if (entityPrototype != null && entityPrototype.ID.Length > 10 && entityPrototype.ID.Contains("ShardGlass"))
						{
							flag2 = true;
						}
					}
					if (!(flag2 && flag))
					{
						Vector2 vector2 = ((EntitySystem)this).Transform(item).MapPosition.Position - position;
						float num3 = vector2.Length();
						float num4 = 0.75f;
						if (!(num3 >= num4))
						{
							return true;
						}
						Vector2 value = vector2 / num3;
						if (!(Vector2.Dot(vector / num, value) < 0.5f) && (num3 - num4) / num <= 0.125f)
						{
							return true;
						}
					}
				}
				return false;
			}
			return CheckImmediateSurroundings(player, position, flag);
		}
		return false;
	}

	private bool CheckImmediateSurroundings(EntityUid player, Vector2 playerPos, bool hasShoes)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		TransformComponent val = default(TransformComponent);
		StepTriggerComponent val2 = default(StepTriggerComponent);
		MetaDataComponent val3 = default(MetaDataComponent);
		foreach (EntityUid item in entityLookupSystem_0.GetEntitiesInRange(player, 0.6f, (LookupFlags)110))
		{
			if ((((EntitySystem)this).TryComp<TransformComponent>(item, ref val) && val.ParentUid == player) || IsOwnedByLocalPlayer(item) || !((EntitySystem)this).TryComp<StepTriggerComponent>(item, ref val2) || !val2.Active || !((EntitySystem)this).HasComp<SlipperyComponent>(item))
			{
				continue;
			}
			bool flag = false;
			if (((EntitySystem)this).TryComp<MetaDataComponent>(item, ref val3))
			{
				EntityPrototype entityPrototype = val3.EntityPrototype;
				if (entityPrototype != null && entityPrototype.ID.Length > 10 && entityPrototype.ID.Contains("ShardGlass"))
				{
					flag = true;
				}
			}
			if (flag && hasShoes)
			{
				continue;
			}
			goto IL_00fe;
		}
		return false;
		IL_00fe:
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private (float, float) GetPlayerSpeed(EntityUid player)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		MovementSpeedModifierComponent val = default(MovementSpeedModifierComponent);
		if (!((EntitySystem)this).TryComp<MovementSpeedModifierComponent>(player, ref val))
		{
			return (2.5f, 4.5f);
		}
		return (val.CurrentWalkSpeed, val.CurrentSprintSpeed);
	}

	public bool CanSlip(EntityUid target)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		if (((EntitySystem)this).HasComp<NoSlipComponent>(target))
		{
			return false;
		}
		BaseContainer val = default(BaseContainer);
		if (((SharedContainerSystem)containerSystem_0).TryGetContainer(target, "shoes", ref val, (ContainerManagerComponent)null) && val.ContainedEntities.Count > 0)
		{
			EntityUid val2 = val.ContainedEntities[0];
			if (((EntitySystem)this).HasComp<NoSlipComponent>(val2))
			{
				return false;
			}
		}
		return true;
	}

	public bool IsOwnedByLocalPlayer(EntityUid slipperyEntity)
	{
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (!localEntity.HasValue)
		{
			return false;
		}
		EntityUid value = localEntity.Value;
		TransformComponent val = default(TransformComponent);
		if (((EntitySystem)this).TryComp<TransformComponent>(slipperyEntity, ref val))
		{
			if (val.ParentUid == value)
			{
				return true;
			}
			TransformComponent val2 = default(TransformComponent);
			if (((EntitySystem)this).TryComp<TransformComponent>(val.ParentUid, ref val2) && val2.ParentUid == value)
			{
				return true;
			}
		}
		string[] array = new string[7] { "back", "belt", "pocket1", "pocket2", "suitstorage", "innerclothing", "outerclothing" };
		InventoryComponent val3 = default(InventoryComponent);
		if (((EntitySystem)this).TryComp<InventoryComponent>(value, ref val3))
		{
			InventorySystem val4 = base.EntityManager.System<InventorySystem>();
			string[] array2 = array;
			EntityUid? val5 = default(EntityUid?);
			BaseContainer val7 = default(BaseContainer);
			foreach (string text in array2)
			{
				if (val4.TryGetSlotEntity(value, text, ref val5, (InventoryComponent)null, (ContainerManagerComponent)null))
				{
					EntityUid? val6 = val5;
					if (val6.HasValue && val6.GetValueOrDefault() == slipperyEntity)
					{
						return true;
					}
				}
				if (!val5.HasValue || !((SharedContainerSystem)containerSystem_0).TryGetContainer(val5.Value, "storagebase", ref val7, (ContainerManagerComponent)null))
				{
					continue;
				}
				foreach (EntityUid containedEntity in val7.ContainedEntities)
				{
					if (containedEntity == slipperyEntity)
					{
						goto IL_0121;
					}
				}
				continue;
				IL_0121:
				return true;
			}
		}
		return false;
	}
}
