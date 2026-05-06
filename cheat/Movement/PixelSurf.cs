using System;
using System.Collections.Generic;
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

namespace PixelSurf;

public sealed class PixelSurf : EntitySystem
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

	private readonly Dictionary<BoundKeyFunction, bool> dictionary_0 = new Dictionary<BoundKeyFunction, bool>
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

	private bool bool_0;

	private Vector2 vector2_0 = Vector2.Zero;

	private Vector2 vector2_1 = Vector2.Zero;

	private Vector2 vector2_2 = Vector2.Zero;

	private bool bool_1;

	private Vector2 vector2_3 = Vector2.Zero;

	private Vector2 vector2_4 = Vector2.Zero;

	private static int int_0 = 0;

	private static readonly Vector2[] vector2_5 = new Vector2[4]
	{
		new Vector2(1f, 1f),
		new Vector2(1f, -1f),
		new Vector2(-1f, -1f),
		new Vector2(-1f, 1f)
	};

	private Queue<Vector2> queue_0 = new Queue<Vector2>();

	private long long_0;

	private bool bool_2;

	private int int_2;

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

	private bool Boolean_0
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	private int Int32_0
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
	}

	public override void FrameUpdate(float frameTime)
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.Movement.PixelSurfEnabled)
		{
			if (bool_0)
			{
				StopPixelSurf();
			}
			return;
		}
		ICommonSession localSession = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
		EntityUid? val = ((localSession != null) ? localSession.AttachedEntity : ((EntityUid?)null));
		if (!val.HasValue)
		{
			return;
		}
		if ((int)CerberusConfig.Movement.PixelSurfKey != 0 && KeyStateHelper.IsKeyDown(CerberusConfig.Movement.PixelSurfKey))
		{
			if (bool_0)
			{
				PerformPixelSurf(val.Value);
			}
			else if (TryCapturePlayerDirection(val.Value))
			{
				bool_0 = true;
				bool_1 = false;
			}
		}
		else if (bool_0)
		{
			StopPixelSurf();
		}
	}

	private bool TryCapturePlayerDirection(EntityUid player)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		InputMoverComponent val = default(InputMoverComponent);
		if (!base.EntityManager.TryGetComponent<InputMoverComponent>(player, ref val))
		{
			return false;
		}
		if (CerberusConfig.Movement.PixelSurfMode == 0)
		{
			vector2_0 = vector2_5[int_0];
			int_0 = (int_0 + 1) % vector2_5.Length;
			return true;
		}
		Vector2 curTickSprintMovement = val.CurTickSprintMovement;
		if (curTickSprintMovement.LengthSquared() < 0.01f)
		{
			return false;
		}
		Vector2 direction = Vector2.Normalize(curTickSprintMovement);
		vector2_0 = SnapToEightDirections(direction);
		return vector2_0.LengthSquared() > 0.01f;
	}

	private void PerformPixelSurf(EntityUid player)
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		TransformComponent val = default(TransformComponent);
		if (!base.EntityManager.TryGetComponent<TransformComponent>(player, ref val))
		{
			return;
		}
		Vector2 localPosition = val.LocalPosition;
		if (!bool_1)
		{
			Vector2 vector = CenterToTile(localPosition);
			float num = Vector2.Distance(localPosition, vector);
			if (vector2_3 == Vector2.Zero)
			{
				vector2_4 = vector;
				vector2_3 = Vector2.Normalize(vector - localPosition);
			}
			if (num > 0.0625f)
			{
				ApplyMovementInput(vector2_3, player);
				return;
			}
			bool_1 = true;
			vector2_1 = vector;
			vector2_2 = vector;
			vector2_3 = Vector2.Zero;
			queue_0.Clear();
		}
		if (Vector2.Distance(localPosition, vector2_2) < 0.009375f)
		{
			Vector2 vector2 = ((CerberusConfig.Movement.PixelSurfMode == 0) ? CalculateStaircaseStep(vector2_0) : CalculateDiagonalStep(vector2_0));
			vector2_1 = vector2_2;
			vector2_2 = vector2_1 + vector2;
		}
		Vector2 vector3 = vector2_2 - localPosition;
		if (CerberusConfig.Movement.PixelSurfMode == 0)
		{
			vector3 = ((MathF.Abs(vector3.X) > 0.001f && MathF.Abs(vector3.Y) < 0.001f) ? new Vector2(MathF.Sign(vector3.X), 0f) : ((MathF.Abs(vector3.Y) > 0.001f && MathF.Abs(vector3.X) < 0.001f) ? new Vector2(0f, MathF.Sign(vector3.Y)) : ((MathF.Abs(vector3.X) <= 0.001f || !(MathF.Abs(vector3.Y) > 0.001f)) ? Vector2.Zero : ((!(MathF.Abs(vector3.X) > MathF.Abs(vector3.Y))) ? new Vector2(0f, MathF.Sign(vector3.Y)) : new Vector2(MathF.Sign(vector3.X), 0f)))));
		}
		else if (!(vector3.LengthSquared() <= 0.001f))
		{
			vector3 = Vector2.Normalize(vector3);
		}
		ApplyMovementInput(vector3, player);
	}

	private Vector2 CenterToTile(Vector2 position)
	{
		float x = MathF.Floor(position.X) + 0.5f;
		float y = MathF.Floor(position.Y) + 0.5f;
		return new Vector2(x, y);
	}

	private Vector2 CalculateStaircaseStep(Vector2 direction)
	{
		bool flag = MathF.Abs(direction.X) > 0.01f;
		bool flag2 = MathF.Abs(direction.Y) > 0.01f;
		if (!(flag && flag2))
		{
			if (flag)
			{
				return new Vector2((float)MathF.Sign(direction.X) * (1f / 32f), 0f);
			}
			if (!flag2)
			{
				return Vector2.Zero;
			}
			return new Vector2(0f, (float)MathF.Sign(direction.Y) * (1f / 32f));
		}
		if (queue_0.Count == 0)
		{
			GenerateBresenhamPath(direction);
		}
		if (queue_0.Count <= 0)
		{
			return new Vector2((float)MathF.Sign(direction.X) * (1f / 32f), 0f);
		}
		return queue_0.Dequeue();
	}

	private void GenerateBresenhamPath(Vector2 direction)
	{
		queue_0.Clear();
		int num = Math.Sign(direction.X);
		int num2 = Math.Sign(direction.Y);
		float num3 = MathF.Abs(direction.X);
		float num4 = MathF.Abs(direction.Y);
		if (!(num3 >= num4))
		{
			float num5 = 0f;
			float num6 = num3 / num4;
			for (int i = 0; i < 10; i++)
			{
				queue_0.Enqueue(new Vector2(0f, (float)num2 * (1f / 32f)));
				num5 += num6;
				if (!(num5 < 0.5f))
				{
					queue_0.Enqueue(new Vector2((float)num * (1f / 32f), 0f));
					num5 -= 1f;
				}
			}
			return;
		}
		float num7 = 0f;
		float num8 = num4 / num3;
		for (int j = 0; j < 10; j++)
		{
			queue_0.Enqueue(new Vector2((float)num * (1f / 32f), 0f));
			num7 += num8;
			if (num7 >= 0.5f)
			{
				queue_0.Enqueue(new Vector2(0f, (float)num2 * (1f / 32f)));
				num7 -= 1f;
			}
		}
	}

	private Vector2 CalculateDiagonalStep(Vector2 direction)
	{
		if (direction.LengthSquared() <= 0.01f)
		{
			return Vector2.Zero;
		}
		return Vector2.Normalize(direction) * (1f / 32f);
	}

	private void ApplyMovementInput(Vector2 direction, EntityUid playerUid)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		if (!(direction == Vector2.Zero))
		{
			float num = 0f;
			try
			{
				TransformComponent val = default(TransformComponent);
				if (base.EntityManager.TryGetComponent<TransformComponent>(playerUid, ref val))
				{
					EntityUid parentUid = val.ParentUid;
					TransformComponent val2 = default(TransformComponent);
					if (((EntityUid)(ref parentUid)).IsValid() && base.EntityManager.TryGetComponent<TransformComponent>(parentUid, ref val2))
					{
						num = (float)val2.LocalRotation.Theta;
					}
				}
			}
			catch
			{
			}
			float num2 = MathF.Cos(0f - num);
			float num3 = MathF.Sin(0f - num);
			float num4 = direction.X * num2 - direction.Y * num3;
			float num5 = direction.X * num3 + direction.Y * num2;
			bool pressed = false;
			bool pressed2 = false;
			bool pressed3 = false;
			bool pressed4 = false;
			if (CerberusConfig.Movement.PixelSurfMode != 0)
			{
				pressed = num5 > 0.1f;
				pressed2 = num5 < -0.1f;
				pressed3 = num4 < -0.1f;
				pressed4 = num4 > 0.1f;
			}
			else if (!(MathF.Abs(num4) > MathF.Abs(num5)))
			{
				if (!(num5 > 0.01f))
				{
					if (num5 < -0.01f)
					{
						pressed2 = true;
					}
				}
				else
				{
					pressed = true;
				}
			}
			else if (num4 <= 0.01f)
			{
				if (num4 < -0.01f)
				{
					pressed3 = true;
				}
			}
			else
			{
				pressed4 = true;
			}
			UpdateKey(EngineKeyFunctions.MoveUp, pressed, playerUid);
			UpdateKey(EngineKeyFunctions.MoveDown, pressed2, playerUid);
			UpdateKey(EngineKeyFunctions.MoveLeft, pressed3, playerUid);
			UpdateKey(EngineKeyFunctions.MoveRight, pressed4, playerUid);
		}
		else
		{
			ReleaseAllKeys(playerUid);
		}
	}

	private void UpdateKey(BoundKeyFunction function, bool pressed, EntityUid playerUid)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		if (!dictionary_0.TryGetValue(function, out var value) || value != pressed)
		{
			dictionary_0[function] = pressed;
			ICommonSession localSession = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
			if (localSession != null)
			{
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
	}

	private void ReleaseAllKeys(EntityUid playerUid)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		UpdateKey(EngineKeyFunctions.MoveUp, pressed: false, playerUid);
		UpdateKey(EngineKeyFunctions.MoveDown, pressed: false, playerUid);
		UpdateKey(EngineKeyFunctions.MoveLeft, pressed: false, playerUid);
		UpdateKey(EngineKeyFunctions.MoveRight, pressed: false, playerUid);
	}

	private static Vector2 SnapToFourDirections(Vector2 direction)
	{
		if (direction.LengthSquared() >= 0.01f)
		{
			float x = MathF.Round(MathF.Atan2(direction.Y, direction.X) / ((float)Math.PI / 2f)) * ((float)Math.PI / 2f);
			return new Vector2(MathF.Cos(x), MathF.Sin(x));
		}
		return Vector2.Zero;
	}

	private static Vector2 SnapToEightDirections(Vector2 direction)
	{
		if (!(direction.LengthSquared() >= 0.01f))
		{
			return Vector2.Zero;
		}
		float x = MathF.Round(MathF.Atan2(direction.Y, direction.X) / ((float)Math.PI / 4f)) * ((float)Math.PI / 4f);
		return new Vector2(MathF.Cos(x), MathF.Sin(x));
	}

	private void StopPixelSurf()
	{
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		if (bool_0)
		{
			bool_0 = false;
			bool_1 = false;
			vector2_0 = Vector2.Zero;
			vector2_1 = Vector2.Zero;
			vector2_2 = Vector2.Zero;
			vector2_3 = Vector2.Zero;
			vector2_4 = Vector2.Zero;
			queue_0.Clear();
			ICommonSession localSession = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
			EntityUid? val = ((localSession != null) ? localSession.AttachedEntity : ((EntityUid?)null));
			if (val.HasValue)
			{
				ReleaseAllKeys(val.Value);
			}
		}
	}
}
