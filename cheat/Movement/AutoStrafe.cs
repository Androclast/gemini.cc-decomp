using System;
using System.Numerics;
using Content.Shared.Movement.Components;
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

namespace AutoStrafe;

public sealed class AutoStrafe : EntitySystem
{
	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly SharedTransformSystem sharedTransformSystem_0;

	[Dependency]
	private readonly IInputManager iinputManager_0;

	[Dependency]
	private readonly InputSystem inputSystem_0;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private float float_0;

	private BoundKeyFunction boundKeyFunction_0 = EngineKeyFunctions.MoveUp;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8;

	private bool bool_9;

	private bool bool_10;

	private double double_0;

	private double double_1;

	private byte byte_0;

	private bool Boolean_0
	{
		get
		{
			return bool_10;
		}
		set
		{
			bool_10 = value;
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

	private double Double_1
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

	public override void FrameUpdate(float frameTime)
	{
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.Movement.SpeedSaverEnabled)
		{
			if (bool_4)
			{
				StopStrafe();
			}
			return;
		}
		ICommonSession localSession = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
		EntityUid? val = ((localSession != null) ? localSession.AttachedEntity : ((EntityUid?)null));
		InputMoverComponent val2 = default(InputMoverComponent);
		if (!val.HasValue || !base.EntityManager.TryGetComponent<InputMoverComponent>(val.Value, ref val2))
		{
			return;
		}
		if (bool_4)
		{
			float_0 -= frameTime * 1000f;
			if (!(float_0 > 0f))
			{
				StopStrafe();
				ApplyPendingInput(val.Value);
			}
			return;
		}
		Vector2 curTickSprintMovement = val2.CurTickSprintMovement;
		bool flag = curTickSprintMovement.Y > 0.1f;
		bool flag2 = curTickSprintMovement.Y < -0.1f;
		bool flag3 = curTickSprintMovement.X > 0.1f;
		bool flag4 = curTickSprintMovement.X < -0.1f;
		bool flag5 = (bool_0 && flag2) || (bool_1 && flag);
		bool flag6 = (bool_2 && flag3) || (bool_3 && flag4);
		if (flag5 || flag6)
		{
			bool_5 = flag;
			bool_6 = flag2;
			bool_7 = flag4;
			bool_8 = flag3;
			if (flag5)
			{
				boundKeyFunction_0 = (bool_3 ? EngineKeyFunctions.MoveRight : EngineKeyFunctions.MoveLeft);
			}
			else
			{
				boundKeyFunction_0 = ((!bool_0) ? EngineKeyFunctions.MoveDown : EngineKeyFunctions.MoveUp);
			}
			bool_4 = true;
			float_0 = CerberusConfig.Movement.SpeedSaverStrafeDurationMs;
			ReleaseAllKeys(val.Value);
			PressKey(boundKeyFunction_0, val.Value);
			bool_9 = true;
		}
		else
		{
			bool_0 = flag;
			bool_1 = flag2;
			bool_2 = flag4;
			bool_3 = flag3;
		}
	}

	private void StopStrafe()
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		bool_4 = false;
		float_0 = 0f;
		bool_9 = false;
		ICommonSession localSession = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
		EntityUid? val = ((localSession != null) ? localSession.AttachedEntity : ((EntityUid?)null));
		if (val.HasValue)
		{
			ReleaseKey(boundKeyFunction_0, val.Value);
		}
	}

	private void ApplyPendingInput(EntityUid player)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		if (bool_5)
		{
			PressKey(EngineKeyFunctions.MoveUp, player);
		}
		if (bool_6)
		{
			PressKey(EngineKeyFunctions.MoveDown, player);
		}
		if (bool_7)
		{
			PressKey(EngineKeyFunctions.MoveLeft, player);
		}
		if (bool_8)
		{
			PressKey(EngineKeyFunctions.MoveRight, player);
		}
		bool_0 = bool_5;
		bool_1 = bool_6;
		bool_2 = bool_7;
		bool_3 = bool_8;
		bool_5 = (bool_6 = (bool_7 = (bool_8 = false)));
	}

	private void PressKey(BoundKeyFunction function, EntityUid playerUid)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		SendKeyState(function, (BoundKeyState)1, playerUid);
	}

	private void ReleaseKey(BoundKeyFunction function, EntityUid playerUid)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		SendKeyState(function, (BoundKeyState)0, playerUid);
	}

	private void ReleaseAllKeys(EntityUid playerUid)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		ReleaseKey(EngineKeyFunctions.MoveUp, playerUid);
		ReleaseKey(EngineKeyFunctions.MoveDown, playerUid);
		ReleaseKey(EngineKeyFunctions.MoveLeft, playerUid);
		ReleaseKey(EngineKeyFunctions.MoveRight, playerUid);
	}

	private void SendKeyState(BoundKeyFunction function, BoundKeyState state, EntityUid playerUid)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		ICommonSession localSession = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
		if (localSession == null)
		{
			return;
		}
		try
		{
			KeyFunctionId val = iinputManager_0.NetworkBindMap.KeyFunctionID(function);
			EntityCoordinates moverCoordinates = sharedTransformSystem_0.GetMoverCoordinates(playerUid);
			ClientFullInputCmdMessage val2 = new ClientFullInputCmdMessage(igameTiming_0.CurTick, igameTiming_0.TickFraction, val);
			val2.set_State(state);
			val2.set_Coordinates(moverCoordinates);
			val2.set_ScreenCoordinates(iinputManager_0.MouseScreenPosition);
			val2.set_Uid(playerUid);
			ClientFullInputCmdMessage val3 = val2;
			inputSystem_0.HandleInputCommand(localSession, function, (IFullInputCmdMessage)(object)val3, false);
		}
		catch (Exception ex)
		{
			Logger.Warn("[SpeedSaver] SendKeyState error: " + ex.Message);
		}
	}
}
