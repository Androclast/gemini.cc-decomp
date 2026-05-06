using System;
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

namespace CircleAntiAim;

public sealed class CircleAntiAim : EntitySystem
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

	private bool bool_0;

	private BoundKeyFunction? nullable_0;

	private int int_0;

	private byte byte_0;

	private double double_0;

	private byte byte_1;

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

	private byte Byte_1
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

	public override void FrameUpdate(float frameTime)
	{
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		((EntitySystem)this).FrameUpdate(frameTime);
		if (CerberusConfig.Movement.AntiAimEnabled)
		{
			EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
			if (localEntity.HasValue)
			{
				float antiAimStepLength = CerberusConfig.Movement.AntiAimStepLength;
				float num = 0.03f + antiAimStepLength * 0.12f;
				bool flag = IsPlayerMoving();
				if (!((igameTiming_0.CurTime - timeSpan_0).TotalSeconds < (double)num))
				{
					if (flag)
					{
						PerformAntiAim(localEntity.Value);
					}
					else
					{
						PerformCircleMovement(localEntity.Value);
					}
					timeSpan_0 = igameTiming_0.CurTime;
				}
			}
			else
			{
				ReleaseAllKeys();
			}
		}
		else
		{
			ReleaseAllKeys();
		}
	}

	private bool IsPlayerMoving()
	{
		if (iinputManager_0.IsKeyDown((Key)32) || iinputManager_0.IsKeyDown((Key)10) || iinputManager_0.IsKeyDown((Key)28))
		{
			return true;
		}
		return iinputManager_0.IsKeyDown((Key)13);
	}

	private void PerformAntiAim(EntityUid player)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		if (nullable_0.HasValue)
		{
			SendKeyCommand(nullable_0.Value, (BoundKeyState)0, player);
		}
		bool flag = iinputManager_0.IsKeyDown((Key)10) || iinputManager_0.IsKeyDown((Key)13);
		bool flag2 = iinputManager_0.IsKeyDown((Key)32) || iinputManager_0.IsKeyDown((Key)28);
		BoundKeyFunction? val = null;
		if (flag && !flag2)
		{
			val = ((!bool_0) ? EngineKeyFunctions.MoveDown : EngineKeyFunctions.MoveUp);
			bool_0 = !bool_0;
		}
		else if (flag2 && !flag)
		{
			val = ((!bool_0) ? EngineKeyFunctions.MoveRight : EngineKeyFunctions.MoveLeft);
			bool_0 = !bool_0;
		}
		if (!val.HasValue)
		{
			nullable_0 = null;
			return;
		}
		SendKeyCommand(val.Value, (BoundKeyState)1, player);
		nullable_0 = val;
	}

	private void PerformCircleMovement(EntityUid player)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		if (nullable_0.HasValue)
		{
			SendKeyCommand(nullable_0.Value, (BoundKeyState)0, player);
		}
		BoundKeyFunction val;
		switch (int_0)
		{
		case 2:
			val = EngineKeyFunctions.MoveDown;
			break;
		case 3:
			val = EngineKeyFunctions.MoveLeft;
			break;
		case 0:
			val = EngineKeyFunctions.MoveUp;
			break;
		case 1:
			val = EngineKeyFunctions.MoveRight;
			break;
		default:
			val = EngineKeyFunctions.MoveUp;
			int_0 = 0;
			break;
		}
		SendKeyCommand(val, (BoundKeyState)1, player);
		nullable_0 = val;
		int_0 = (int_0 + 1) % 4;
	}

	private void ReleaseAllKeys()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		if (nullable_0.HasValue && ((ISharedPlayerManager)iplayerManager_0).LocalEntity.HasValue)
		{
			SendKeyCommand(nullable_0.Value, (BoundKeyState)0, ((ISharedPlayerManager)iplayerManager_0).LocalEntity.Value);
			nullable_0 = null;
		}
	}

	private void SendKeyCommand(BoundKeyFunction function, BoundKeyState state, EntityUid playerUid)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
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
