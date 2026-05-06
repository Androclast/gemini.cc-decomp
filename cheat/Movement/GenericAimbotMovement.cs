using System.Collections.Generic;
using System.Numerics;
using Robust.Client.GameObjects;
using Robust.Client.Graphics;
using Robust.Client.Input;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.Input;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using CerberusConfig;

public sealed class GenericAimbotMovement : EntitySystem
{
	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IInputManager iinputManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly InputSystem inputSystem_0;

	[Dependency]
	private readonly SharedTransformSystem sharedTransformSystem_0;

	[Dependency]
	private readonly IEyeManager ieyeManager_0;

	private Dictionary<BoundKeyFunction, bool> dictionary_0 = new Dictionary<BoundKeyFunction, bool>
	{
		{
			EngineKeyFunctions.MoveUp,
			false
		},
		{
			EngineKeyFunctions.MoveDown,
			false
		},
		{
			EngineKeyFunctions.MoveLeft,
			false
		},
		{
			EngineKeyFunctions.MoveRight,
			false
		}
	};

	private double double_0;

	private char char_1;

	private byte byte_1;

	private bool bool_0;

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

	private char Char_0
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

	public override void FrameUpdate(float frameTime)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		((EntitySystem)this).FrameUpdate(frameTime);
		if (!CerberusConfig.ProjectileEsp.AutoDodge || HudUpdateSystem.list_0 == null || HudUpdateSystem.list_0.Count == 0)
		{
			ReleaseAllKeys();
			return;
		}
		ICommonSession localSession = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
		EntityUid? val = ((localSession != null) ? localSession.AttachedEntity : ((EntityUid?)null));
		if (!val.HasValue)
		{
			return;
		}
		TransformComponent component = base.EntityManager.GetComponent<TransformComponent>(val.Value);
		Vector2 position = sharedTransformSystem_0.GetMapCoordinates(component).Position;
		Vector2 zero = Vector2.Zero;
		bool flag = false;
		foreach (var item3 in HudUpdateSystem.list_0)
		{
			Vector2 item = item3.Start;
			Vector2 item2 = item3.Velocity;
			Vector2 vector = position - item;
			float num = vector.Length();
			Vector2 vector2 = Vector2.Normalize(item2);
			float num2 = Vector2.Dot(Vector2.Normalize(vector), vector2);
			bool flag2 = num2 > 0.95f;
			Vector2 vector3 = item + vector2 * Vector2.Dot(vector, vector2);
			if ((Vector2.Distance(position, vector3) < CerberusConfig.ProjectileEsp.DodgeRange && !(num2 <= 0f)) || (flag2 && num < 10f))
			{
				Vector2 value = position - vector3;
				if (value.LengthSquared() < 0.001f)
				{
					value = new Vector2(0f - vector2.Y, vector2.X);
				}
				float num3 = 1f + 10f / (num + 0.1f);
				Vector2 vector4 = Vector2.Normalize(value) * 2.5f * num3 + vector2 * 1f;
				zero += vector4;
				flag = true;
			}
		}
		if (flag)
		{
			ApplyMovementInput(zero, val.Value);
		}
		else
		{
			ReleaseAllKeys();
		}
	}

	private void ApplyMovementInput(Vector2 direction, EntityUid playerUid)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		if (!(direction == Vector2.Zero))
		{
			direction = Vector2.Normalize(direction);
			Angle val = -ieyeManager_0.CurrentEye.Rotation;
			Vector2 vector = ((Angle)(ref val)).RotateVec(ref direction);
			bool pressed = vector.Y > 0.15f;
			bool pressed2 = vector.Y < -0.15f;
			bool pressed3 = vector.X > 0.15f;
			bool pressed4 = vector.X < -0.15f;
			SetKeyState(EngineKeyFunctions.MoveUp, pressed, playerUid);
			SetKeyState(EngineKeyFunctions.MoveDown, pressed2, playerUid);
			SetKeyState(EngineKeyFunctions.MoveRight, pressed3, playerUid);
			SetKeyState(EngineKeyFunctions.MoveLeft, pressed4, playerUid);
		}
	}

	private void SetKeyState(BoundKeyFunction function, bool pressed, EntityUid playerUid)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		if (dictionary_0[function] != pressed)
		{
			dictionary_0[function] = pressed;
			ICommonSession localSession = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
			KeyFunctionId val = iinputManager_0.NetworkBindMap.KeyFunctionID(function);
			BoundKeyState state = (BoundKeyState)(pressed ? 1 : 0);
			EntityCoordinates moverCoordinates = sharedTransformSystem_0.GetMoverCoordinates(playerUid);
			ClientFullInputCmdMessage val2 = new ClientFullInputCmdMessage(igameTiming_0.CurTick, igameTiming_0.TickFraction, val);
			val2.set_State(state);
			val2.set_Coordinates(moverCoordinates);
			val2.set_ScreenCoordinates(iinputManager_0.MouseScreenPosition);
			val2.set_Uid(playerUid);
			ClientFullInputCmdMessage val3 = val2;
			inputSystem_0.HandleInputCommand(localSession, function, (IFullInputCmdMessage)(object)val3, false);
		}
	}

	private void ReleaseAllKeys()
	{
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		ICommonSession localSession = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
		if (localSession == null || !localSession.AttachedEntity.HasValue)
		{
			return;
		}
		EntityUid value = ((ISharedPlayerManager)iplayerManager_0).LocalSession.AttachedEntity.Value;
		foreach (BoundKeyFunction item in new List<BoundKeyFunction>(dictionary_0.Keys))
		{
			if (dictionary_0[item])
			{
				SetKeyState(item, pressed: false, value);
			}
		}
	}

	private string method_5(byte byte_2, string string_0, byte byte_3)
	{
		return "Хитролох_иди_нахуй._7____5_____4__";
	}
}
