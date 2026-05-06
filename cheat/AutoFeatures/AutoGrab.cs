using System;
using System.Numerics;
using Content.Shared.Input;
using Content.Shared.Mobs.Components;
using Hexa.NET.ImGui;
using Robust.Client.GameObjects;
using Robust.Client.Input;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.Input;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using CerberusConfig;

namespace AutoGrab;

public sealed class AutoGrab : EntitySystem
{
	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly IInputManager iinputManager_0;

	[Dependency]
	private readonly FriendsList gclass6_0;

	private SharedTransformSystem? sharedTransformSystem_0;

	private EntityLookupSystem? entityLookupSystem_0;

	private InputSystem? inputSystem_0;

	private bool bool_0;

	private float float_0;

	private bool bool_1;

	private long long_0;

	private long long_1;

	public bool IsActive => bool_0;

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
		sharedTransformSystem_0 = base.EntityManager.System<SharedTransformSystem>();
		entityLookupSystem_0 = base.EntityManager.System<EntityLookupSystem>();
		inputSystem_0 = base.EntityManager.System<InputSystem>();
	}

	public override void Update(float frameTime)
	{
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		((EntitySystem)this).Update(frameTime);
		if (!igameTiming_0.IsFirstTimePredicted)
		{
			return;
		}
		if (CerberusConfig.AutoStop.Enabled)
		{
			ImGuiKey activationKey = CerberusConfig.AutoStop.ActivationKey;
			if ((int)activationKey != 0)
			{
				bool flag = KeyStateHelper.IsKeyDown(activationKey);
				if (flag && !bool_1)
				{
					bool_0 = !bool_0;
					Logger.Info("[AutoStop] " + (bool_0 ? "Activated" : "Deactivated"));
				}
				bool_1 = flag;
			}
			if (!bool_0)
			{
				return;
			}
			float_0 -= frameTime;
			if (!(float_0 <= 0f))
			{
				return;
			}
			float val = CerberusConfig.AutoStop.IntervalMs / 1000f;
			float_0 = Math.Max(val, 0.01f);
			EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
			if (localEntity.HasValue)
			{
				EntityUid? val2 = FindNearestTarget(localEntity.Value);
				if (val2.HasValue)
				{
					DoGrab(localEntity.Value, val2.Value);
				}
			}
		}
		else
		{
			bool_0 = false;
		}
	}

	private EntityUid? FindNearestTarget(EntityUid user)
	{
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Invalid comparison between Unknown and I4
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		if (sharedTransformSystem_0 != null && entityLookupSystem_0 != null)
		{
			Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(user);
			MapId mapId = sharedTransformSystem_0.GetMapId(Entity<TransformComponent>.op_Implicit(user));
			EntityUid? result = null;
			float num = float.MaxValue;
			{
				MobStateComponent val = default(MobStateComponent);
				foreach (EntityUid item in entityLookupSystem_0.GetEntitiesInRange(mapId, worldPosition, 3f, (LookupFlags)110))
				{
					if (!(item == user) && base.EntityManager.HasComponent<MobStateComponent>(item) && (!base.EntityManager.TryGetComponent<MobStateComponent>(item, ref val) || (int)val.CurrentState != 3) && !gclass6_0.IsFriend(item))
					{
						float num2 = (sharedTransformSystem_0.GetWorldPosition(item) - worldPosition).LengthSquared();
						if (num2 < num)
						{
							num = num2;
							result = item;
						}
					}
				}
				return result;
			}
		}
		return null;
	}

	private void DoGrab(EntityUid user, EntityUid target)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (inputSystem_0 != null)
			{
				ICommonSession localSession = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
				if (localSession != null)
				{
					BoundKeyFunction tryPullObject = ContentKeyFunctions.TryPullObject;
					KeyFunctionId val = iinputManager_0.NetworkBindMap.KeyFunctionID(tryPullObject);
					EntityCoordinates moverCoordinates = sharedTransformSystem_0.GetMoverCoordinates(target);
					ClientFullInputCmdMessage val2 = new ClientFullInputCmdMessage(igameTiming_0.CurTick, igameTiming_0.TickFraction, val);
					val2.set_State((BoundKeyState)1);
					val2.set_Coordinates(moverCoordinates);
					val2.set_ScreenCoordinates(iinputManager_0.MouseScreenPosition);
					val2.set_Uid(target);
					ClientFullInputCmdMessage val3 = val2;
					inputSystem_0.HandleInputCommand(localSession, tryPullObject, (IFullInputCmdMessage)(object)val3, false);
					ClientFullInputCmdMessage val4 = new ClientFullInputCmdMessage(igameTiming_0.CurTick, igameTiming_0.TickFraction, val);
					val4.set_State((BoundKeyState)0);
					val4.set_Coordinates(moverCoordinates);
					val4.set_ScreenCoordinates(iinputManager_0.MouseScreenPosition);
					val4.set_Uid(target);
					ClientFullInputCmdMessage val5 = val4;
					inputSystem_0.HandleInputCommand(localSession, tryPullObject, (IFullInputCmdMessage)(object)val5, false);
				}
			}
		}
		catch (Exception ex)
		{
			Logger.Warn("[AutoStop] Grab error: " + ex.Message);
		}
	}
}
