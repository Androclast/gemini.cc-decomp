using System;
using System.Reflection;
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

namespace SpeedSaver;

public sealed class SpeedSaver : EntitySystem
{
	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IInputManager iinputManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly SharedTransformSystem sharedTransformSystem_0;

	private TimeSpan timeSpan_0 = TimeSpan.Zero;

	private TimeSpan timeSpan_1 = TimeSpan.Zero;

	private bool bool_0;

	private BoundKeyFunction? nullable_0;

	private bool bool_1;

	private static bool bool_2;

	private static Type? type_0;

	private static PropertyInfo? propertyInfo_0;

	private byte byte_0;

	private float float_0;

	private char char_0;

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
			return float_0;
		}
		set
		{
			float_0 = value;
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

	public override void FrameUpdate(float frameTime)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		((EntitySystem)this).FrameUpdate(frameTime);
		if (!CerberusConfig.Misc.ZeroGSpeedHackEnabled)
		{
			if (bool_1 || nullable_0.HasValue)
			{
				ReleaseAllKeys();
			}
			return;
		}
		TimeSpan curTime = igameTiming_0.CurTime;
		if (!((curTime - timeSpan_0).TotalSeconds >= 0.10000000149011612))
		{
			return;
		}
		timeSpan_0 = curTime;
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (localEntity.HasValue)
		{
			if (!IsWeightless(localEntity.Value))
			{
				ReleaseAllKeys();
				return;
			}
			if (!IsPlayerMoving())
			{
				ReleaseAllKeys();
				return;
			}
			float zeroGSpeedDelay = CerberusConfig.Misc.ZeroGSpeedDelay;
			if (!bool_1)
			{
				PerformSpeedBoost(localEntity.Value);
				timeSpan_1 = curTime;
				bool_1 = true;
			}
			else if ((curTime - timeSpan_1).TotalSeconds >= (double)zeroGSpeedDelay)
			{
				ReleaseCurrentKey();
				bool_1 = false;
			}
		}
		else
		{
			ReleaseAllKeys();
		}
	}

	private bool IsWeightless(EntityUid entity)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		if (!bool_2)
		{
			bool_2 = true;
			try
			{
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				for (int i = 0; i < assemblies.Length; i++)
				{
					type_0 = assemblies[i].GetType("Content.Shared.Gravity.GravityAffectedComponent");
					if (type_0 != null)
					{
						propertyInfo_0 = type_0.GetProperty("Weightless");
						break;
					}
				}
			}
			catch
			{
			}
		}
		if (!(type_0 == null))
		{
			try
			{
				if (!base.EntityManager.HasComponent(entity, type_0))
				{
					return false;
				}
				IComponent component = base.EntityManager.GetComponent(entity, type_0);
				object obj2 = propertyInfo_0?.GetValue(component);
				return obj2 is bool && (bool)obj2;
			}
			catch
			{
				return false;
			}
		}
		return false;
	}

	private bool IsPlayerMoving()
	{
		if (iinputManager_0.IsKeyDown((Key)32) || iinputManager_0.IsKeyDown((Key)10) || iinputManager_0.IsKeyDown((Key)28))
		{
			return true;
		}
		return iinputManager_0.IsKeyDown((Key)13);
	}

	private void PerformSpeedBoost(EntityUid player)
	{
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		bool flag = iinputManager_0.IsKeyDown((Key)10) || iinputManager_0.IsKeyDown((Key)13);
		bool flag2 = iinputManager_0.IsKeyDown((Key)32) || iinputManager_0.IsKeyDown((Key)28);
		BoundKeyFunction? val = null;
		if (!flag || flag2)
		{
			if (flag2 && !flag)
			{
				val = ((!bool_0) ? EngineKeyFunctions.MoveRight : EngineKeyFunctions.MoveLeft);
				bool_0 = !bool_0;
			}
		}
		else
		{
			val = (bool_0 ? EngineKeyFunctions.MoveUp : EngineKeyFunctions.MoveDown);
			bool_0 = !bool_0;
		}
		if (val.HasValue)
		{
			SendKeyCommand(val.Value, (BoundKeyState)1, player);
			nullable_0 = val;
		}
	}

	private void ReleaseCurrentKey()
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		if (nullable_0.HasValue && ((ISharedPlayerManager)iplayerManager_0).LocalEntity.HasValue)
		{
			SendKeyCommand(nullable_0.Value, (BoundKeyState)0, ((ISharedPlayerManager)iplayerManager_0).LocalEntity.Value);
		}
	}

	private void ReleaseAllKeys()
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		if (nullable_0.HasValue && ((ISharedPlayerManager)iplayerManager_0).LocalEntity.HasValue)
		{
			SendKeyCommand(nullable_0.Value, (BoundKeyState)0, ((ISharedPlayerManager)iplayerManager_0).LocalEntity.Value);
			nullable_0 = null;
		}
		bool_1 = false;
	}

	private void SendKeyCommand(BoundKeyFunction function, BoundKeyState state, EntityUid playerUid)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		ICommonSession localSession = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
		if (localSession != null)
		{
			InputSystem obj = base.EntityManager.System<InputSystem>();
			KeyFunctionId val = iinputManager_0.NetworkBindMap.KeyFunctionID(function);
			EntityCoordinates moverCoordinates = sharedTransformSystem_0.GetMoverCoordinates(playerUid);
			ClientFullInputCmdMessage val2 = new ClientFullInputCmdMessage(igameTiming_0.CurTick, igameTiming_0.TickFraction, val);
			val2.set_State(state);
			val2.set_Coordinates(moverCoordinates);
			val2.set_ScreenCoordinates(iinputManager_0.MouseScreenPosition);
			val2.set_Uid(playerUid);
			ClientFullInputCmdMessage val3 = val2;
			obj.HandleInputCommand(localSession, function, (IFullInputCmdMessage)(object)val3, false);
		}
	}
}
