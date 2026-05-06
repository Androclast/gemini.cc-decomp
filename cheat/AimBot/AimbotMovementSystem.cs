using System;
using System.Collections.Generic;
using System.Numerics;
using Content.Shared.Weapons.Ranged.Components;
using Content.Shared.Weapons.Ranged.Systems;
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
using GunHelper;
using CerberusConfig;

public sealed class AimbotMovementSystem : EntitySystem
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

	[Dependency]
	private readonly SharedGunSystem sharedGunSystem_0;

	[Dependency]
	private readonly IOverlayManager ioverlayManager_0;

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

	public static Vector2? nullable_0;

	public static bool bool_0;

	private TimeSpan timeSpan_0 = TimeSpan.Zero;

	private AimbotCircleDrawer gclass20_0;

	private TimeSpan timeSpan_1 = TimeSpan.Zero;

	private readonly TimeSpan timeSpan_2 = TimeSpan.FromMilliseconds(60L);

	private long long_1;

	private long long_2;

	private string string_1;

	private long long_3;

	private long Int64_0
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

	private long Int64_1
	{
		get
		{
			return long_2;
		}
		set
		{
			long_2 = value;
		}
	}

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

	private long Int64_2
	{
		get
		{
			return long_3;
		}
		set
		{
			long_3 = value;
		}
	}

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
		gclass20_0 = new AimbotCircleDrawer();
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass20_0);
	}

	public override void Shutdown()
	{
		((EntitySystem)this).Shutdown();
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass20_0);
	}

	public static void OnBotFired()
	{
		if (nullable_0.HasValue)
		{
			bool_0 = true;
		}
	}

	public override void FrameUpdate(float frameTime)
	{
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Invalid comparison between Unknown and I4
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		((EntitySystem)this).FrameUpdate(frameTime);
		if (!CerberusConfig.Misc.AutoPeekEnabled || (int)CerberusConfig.Misc.AutoPeekKey == 0)
		{
			Reset();
			return;
		}
		ICommonSession localSession = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
		EntityUid? val = ((localSession != null) ? localSession.AttachedEntity : ((EntityUid?)null));
		if (!val.HasValue)
		{
			return;
		}
		if (KeyStateHelper.IsKeyDown(CerberusConfig.Misc.AutoPeekKey))
		{
			if (!nullable_0.HasValue)
			{
				TransformComponent component = base.EntityManager.GetComponent<TransformComponent>(val.Value);
				nullable_0 = sharedTransformSystem_0.GetMapCoordinates(component).Position;
				bool_0 = false;
				timeSpan_1 = TimeSpan.Zero;
				if (GunHelper.TryGetGunSafe(sharedGunSystem_0, val.Value, out Entity<GunComponent> gunEntity))
				{
					timeSpan_0 = gunEntity.Comp.NextFire;
				}
			}
			if (!nullable_0.HasValue)
			{
				return;
			}
			if (!bool_0 && GunHelper.TryGetGunSafe(sharedGunSystem_0, val.Value, out Entity<GunComponent> gunEntity2))
			{
				if (!(gunEntity2.Comp.NextFire > timeSpan_0))
				{
					if (igameTiming_0.CurTime >= gunEntity2.Comp.NextFire && (int)inputSystem_0.CmdStates.GetState(EngineKeyFunctions.Use) == 1)
					{
						TriggerRetreat(igameTiming_0.CurTime);
						timeSpan_0 = igameTiming_0.CurTime + TimeSpan.FromSeconds(0.1);
					}
				}
				else
				{
					TriggerRetreat(gunEntity2.Comp.NextFire);
					timeSpan_0 = gunEntity2.Comp.NextFire;
				}
			}
			if (bool_0 && timeSpan_1 == TimeSpan.Zero)
			{
				timeSpan_1 = igameTiming_0.CurTime;
			}
			if (!bool_0)
			{
				return;
			}
			if (!(igameTiming_0.CurTime < timeSpan_1 + timeSpan_2))
			{
				MoveToPosition(val.Value, nullable_0.Value);
				if (Vector2.Distance(sharedTransformSystem_0.GetMapCoordinates(val.Value, base.EntityManager.GetComponent<TransformComponent>(val.Value)).Position, nullable_0.Value) < 0.2f)
				{
					bool_0 = false;
					ReleaseAllKeys();
					timeSpan_1 = TimeSpan.Zero;
				}
			}
			else
			{
				ReleaseAllKeys();
			}
		}
		else
		{
			Reset();
		}
	}

	private void TriggerRetreat(TimeSpan fireTime)
	{
		bool_0 = true;
		timeSpan_1 = igameTiming_0.CurTime;
	}

	private void MoveToPosition(EntityUid playerUid, Vector2 targetPos)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		Vector2 position = sharedTransformSystem_0.GetMapCoordinates(playerUid, base.EntityManager.GetComponent<TransformComponent>(playerUid)).Position;
		Vector2 vector = targetPos - position;
		if (!(vector == Vector2.Zero))
		{
			ApplyMovementInput(vector, playerUid);
		}
	}

	private void ApplyMovementInput(Vector2 direction, EntityUid playerUid)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
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
		else
		{
			ReleaseAllKeys();
		}
	}

	private void SetKeyState(BoundKeyFunction function, bool pressed, EntityUid playerUid)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
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
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
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

	private void Reset()
	{
		if (nullable_0.HasValue)
		{
			ReleaseAllKeys();
			nullable_0 = null;
			bool_0 = false;
			timeSpan_1 = TimeSpan.Zero;
		}
	}
}
