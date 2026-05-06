using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Content.Shared.CombatMode;
using Content.Shared.Ghost;
using Content.Shared.Mobs.Components;
using Robust.Client.GameObjects;
using Robust.Client.Graphics;
using Robust.Client.Input;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.Input;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Physics;
using Robust.Shared.Physics.Systems;
using Robust.Shared.Player;
using Robust.Shared.Random;
using Robust.Shared.Timing;
using AutoPath;
using CerberusConfig;

namespace StrafeAntiAim;

public sealed class StrafeAntiAim : EntitySystem
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
	private readonly EntityLookupSystem entityLookupSystem_0;

	[Dependency]
	private readonly IRobustRandom irobustRandom_0;

	[Dependency]
	private readonly SharedPhysicsSystem sharedPhysicsSystem_0;

	private AutoPath gclass270_0;

	public bool bool_0 = true;

	private float float_0 = 1f;

	private TimeSpan timeSpan_0 = TimeSpan.Zero;

	private List<Vector2>? list_0;

	private int int_0;

	private Vector2? nullable_0;

	private bool bool_1;

	private TimeSpan timeSpan_1 = TimeSpan.Zero;

	private TimeSpan timeSpan_2 = TimeSpan.Zero;

	private EntityUid? nullable_1;

	private bool bool_2;

	private Vector2 vector2_0 = Vector2.Zero;

	private Vector2 vector2_1 = Vector2.Zero;

	private TimeSpan timeSpan_3 = TimeSpan.Zero;

	private bool bool_3;

	private int int_1 = 1;

	private Vector2 vector2_2 = Vector2.Zero;

	private TimeSpan timeSpan_4 = TimeSpan.Zero;

	private TimeSpan timeSpan_5 = TimeSpan.Zero;

	private float float_1 = float.MaxValue;

	private Vector2 vector2_3 = Vector2.Zero;

	private TimeSpan timeSpan_6 = TimeSpan.Zero;

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

	private int int_3;

	private int int_4;

	private string string_0;

	private int Int32_0
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
		}
	}

	private int Int32_1
	{
		get
		{
			return int_4;
		}
		set
		{
			int_4 = value;
		}
	}

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

	public override void FrameUpdate(float frameTime)
	{
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		((EntitySystem)this).FrameUpdate(frameTime);
		if (!bool_0 || !CerberusConfig.Misc.TargetStrafeEnabled)
		{
			if (bool_2)
			{
				ICommonSession localSession = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
				EntityUid? val = ((localSession != null) ? localSession.AttachedEntity : ((EntityUid?)null));
				if (val.HasValue)
				{
					ReleaseAllKeys(val.Value);
				}
				bool_2 = false;
			}
			return;
		}
		ICommonSession localSession2 = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
		EntityUid? val2 = ((localSession2 != null) ? localSession2.AttachedEntity : ((EntityUid?)null));
		if (!val2.HasValue)
		{
			return;
		}
		bool flag = false;
		CombatModeComponent val3 = default(CombatModeComponent);
		if (((EntitySystem)this).TryComp<CombatModeComponent>(val2.Value, ref val3))
		{
			flag = val3.IsInCombatMode;
		}
		if (flag != bool_2)
		{
			if (!flag)
			{
				nullable_1 = null;
				ReleaseAllKeys(val2.Value);
			}
			bool_2 = flag;
		}
		if (flag)
		{
			UpdateRandomization();
			PerformTargetStrafe(val2.Value);
		}
	}

	private void PerformTargetStrafe(EntityUid localPlayer)
	{
		//IL_04b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0523: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0436: Unknown result type (might be due to invalid IL or missing references)
		//IL_0466: Unknown result type (might be due to invalid IL or missing references)
		//IL_054e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0451: Unknown result type (might be due to invalid IL or missing references)
		//IL_0457: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_041e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0532: Unknown result type (might be due to invalid IL or missing references)
		float targetStrafeRange = CerberusConfig.Misc.TargetStrafeRange;
		if (nullable_1.HasValue)
		{
			if (base.EntityManager.EntityExists(nullable_1.Value) && !IsDead(nullable_1.Value) && !((EntitySystem)this).HasComp<GhostComponent>(nullable_1.Value))
			{
				Vector2 position = sharedTransformSystem_0.GetMapCoordinates(nullable_1.Value, (TransformComponent)null).Position;
				Vector2 position2 = sharedTransformSystem_0.GetMapCoordinates(localPlayer, (TransformComponent)null).Position;
				if (Vector2.Distance(position, position2) > targetStrafeRange + 5f)
				{
					nullable_1 = null;
					bool_3 = false;
					list_0 = null;
					nullable_0 = null;
				}
				else
				{
					vector2_1 = (position - vector2_0) / 0.016f;
					vector2_0 = position;
				}
			}
			else
			{
				nullable_1 = null;
				bool_3 = false;
				list_0 = null;
				nullable_0 = null;
			}
		}
		if (!nullable_1.HasValue)
		{
			FindNearestTarget(localPlayer, targetStrafeRange);
			if (!nullable_1.HasValue)
			{
				ReleaseAllKeys(localPlayer);
				bool_3 = false;
				list_0 = null;
				nullable_0 = null;
				gclass270_0 = null;
				return;
			}
			gclass270_0 = base.EntityManager.System<AutoPath>();
		}
		if (gclass270_0 == null)
		{
			gclass270_0 = base.EntityManager.System<AutoPath>();
		}
		Vector2 position3 = sharedTransformSystem_0.GetMapCoordinates(nullable_1.Value, (TransformComponent)null).Position;
		Vector2 position4 = sharedTransformSystem_0.GetMapCoordinates(localPlayer, (TransformComponent)null).Position;
		Vector2 vector = position3 + vector2_1 * 0.25f;
		float num = Vector2.Distance(vector, position4);
		float targetStrafeDistance = CerberusConfig.Misc.TargetStrafeDistance;
		Vector2 vector2 = default(Vector2);
		bool num2 = HasLineOfSight(position4, vector, localPlayer);
		Vector2 vector3 = Vector2.Zero;
		if (!num2)
		{
			if (!bool_3)
			{
				bool_3 = true;
			}
			if ((list_0 == null || list_0.Count == 0 || (igameTiming_0.CurTime - timeSpan_5).TotalSeconds > 1.0) && gclass270_0 != null)
			{
				list_0 = gclass270_0.FindPathPublic(position4, vector);
				timeSpan_5 = igameTiming_0.CurTime;
				int_0 = 0;
				if (list_0 != null)
				{
					_ = list_0.Count;
				}
			}
			if (list_0 == null || list_0.Count <= 0 || int_0 >= list_0.Count)
			{
				vector3 = Vector2.Normalize(vector - position4);
				list_0 = null;
			}
			else
			{
				Vector2 vector4 = list_0[int_0];
				if (!(Vector2.Distance(position4, vector4) >= 0.3f))
				{
					int_0++;
				}
				else
				{
					vector3 = Vector2.Normalize(vector4 - position4);
				}
			}
		}
		else
		{
			if (bool_3)
			{
				bool_3 = false;
				list_0 = null;
			}
			vector3 = Vector2.Normalize(vector - position4);
		}
		Vector2 vector5 = Vector2.Normalize(vector - position4);
		Vector2 vector6 = new Vector2(0f - vector5.Y, vector5.X) * float_0;
		float num3 = 0f;
		float num4 = 1f;
		if (num > targetStrafeDistance + 2f)
		{
			num3 = 0.2f;
			num4 = 0.8f;
		}
		else
		{
			float num5 = num - targetStrafeDistance;
			if (MathF.Abs(num5) >= 0.3f)
			{
				if (num5 > 0f)
				{
					num3 = 0.4f;
					num4 = 0.6f;
				}
				else
				{
					num3 = 0.9f;
					num4 = 0.1f;
				}
			}
			else
			{
				num3 = 0.8f;
				num4 = 0.2f;
			}
		}
		vector2 = Vector2.Normalize(vector3 * num4 + vector6 * num3);
		float num6 = 0.05f;
		Vector2 vector7 = new Vector2(irobustRandom_0.NextFloat(0f - num6, num6), irobustRandom_0.NextFloat(0f - num6, num6));
		vector2 = Vector2.Normalize(vector2 + vector7);
		ApplyMovementInput(vector2, localPlayer);
	}

	private void UpdateRandomization()
	{
		TimeSpan curTime = igameTiming_0.CurTime;
		if (curTime >= timeSpan_0)
		{
			float_0 = (RandomExtensions.Prob(irobustRandom_0, 0.5f) ? 1f : (-1f));
			timeSpan_0 = curTime + TimeSpan.FromSeconds(irobustRandom_0.NextFloat(0.4f, 1.5f));
		}
		if (bool_1)
		{
			if (curTime >= timeSpan_2)
			{
				bool_1 = false;
				timeSpan_1 = curTime + TimeSpan.FromSeconds(irobustRandom_0.NextFloat(2f, 5f));
			}
		}
		else if (curTime >= timeSpan_1)
		{
			if (!RandomExtensions.Prob(irobustRandom_0, 0.7f))
			{
				timeSpan_1 = curTime + TimeSpan.FromSeconds(1.0);
				return;
			}
			bool_1 = true;
			timeSpan_2 = curTime + TimeSpan.FromSeconds(irobustRandom_0.NextFloat(0.4f, 0.9f));
		}
	}

	private Vector2 CalculateStrafeVector(Vector2 playerPos, Vector2 targetPos, float currentDist, float targetDist)
	{
		if (!(currentDist >= 0.01f))
		{
			return Vector2.Zero;
		}
		Vector2 vector = Vector2.Normalize(targetPos - playerPos);
		Vector2 vector2 = new Vector2(0f - vector.Y, vector.X) * float_0;
		float num = currentDist - targetDist;
		float num2;
		float num3;
		if (targetDist >= 0.1f)
		{
			if (MathF.Abs(num) >= 0.2f)
			{
				if (num <= 0f)
				{
					num2 = 0.9f;
					num3 = 5f;
				}
				else
				{
					num2 = 0.4f;
					num3 = 7f;
				}
			}
			else
			{
				num2 = 1.8f;
				num3 = 3f;
			}
		}
		else
		{
			num2 = 0.15f;
			num3 = 10f;
		}
		Vector2 vector3 = vector * (num * num3);
		Vector2 vector4 = vector2 * num2 + vector3;
		float num4 = 0.08f;
		Vector2 vector5 = new Vector2(irobustRandom_0.NextFloat(-0.08f, num4), irobustRandom_0.NextFloat(-0.08f, num4));
		return Vector2.Normalize(vector4 + vector5);
	}

	private void ApplyMovementInput(Vector2 direction, EntityUid playerUid)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
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
				num = (float)ieyeManager_0.CurrentEye.Rotation.Theta;
			}
			float num2 = MathF.Cos(0f - num);
			float num3 = MathF.Sin(0f - num);
			float num4 = direction.X * num2 - direction.Y * num3;
			float num5 = direction.X * num3 + direction.Y * num2;
			bool pressed = num5 > 0.4f;
			bool pressed2 = num5 < -0.4f;
			bool pressed3 = num4 > 0.4f;
			bool pressed4 = num4 < -0.4f;
			UpdateKey(EngineKeyFunctions.MoveUp, pressed, playerUid);
			UpdateKey(EngineKeyFunctions.MoveDown, pressed2, playerUid);
			UpdateKey(EngineKeyFunctions.MoveRight, pressed3, playerUid);
			UpdateKey(EngineKeyFunctions.MoveLeft, pressed4, playerUid);
		}
		else
		{
			ReleaseAllKeys(playerUid);
		}
	}

	private void UpdateKey(BoundKeyFunction function, bool pressed, EntityUid playerUid)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
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
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		UpdateKey(EngineKeyFunctions.MoveUp, pressed: false, playerUid);
		UpdateKey(EngineKeyFunctions.MoveDown, pressed: false, playerUid);
		UpdateKey(EngineKeyFunctions.MoveLeft, pressed: false, playerUid);
		UpdateKey(EngineKeyFunctions.MoveRight, pressed: false, playerUid);
	}

	private void FindNearestTarget(EntityUid localPlayer, float range)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		Vector2 position = sharedTransformSystem_0.GetMapCoordinates(localPlayer, (TransformComponent)null).Position;
		float num = range * range;
		EntityUid? val = null;
		foreach (EntityUid item in entityLookupSystem_0.GetEntitiesInRange(localPlayer, range, (LookupFlags)110))
		{
			if (!(item == localPlayer) && !((EntitySystem)this).HasComp<GhostComponent>(item) && ((EntitySystem)this).HasComp<MobStateComponent>(item) && !IsDead(item))
			{
				Vector2 position2 = sharedTransformSystem_0.GetMapCoordinates(item, (TransformComponent)null).Position;
				float num2 = Vector2.DistanceSquared(position, position2);
				if (num2 < num)
				{
					num = num2;
					val = item;
				}
			}
		}
		if (val.HasValue)
		{
			nullable_1 = val;
			vector2_0 = sharedTransformSystem_0.GetMapCoordinates(nullable_1.Value, (TransformComponent)null).Position;
			vector2_1 = Vector2.Zero;
			HasLineOfSight(position, vector2_0, localPlayer);
		}
	}

	private bool IsDead(EntityUid uid)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Invalid comparison between Unknown and I4
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Invalid comparison between Unknown and I4
		MobStateComponent val = default(MobStateComponent);
		if (!((EntitySystem)this).TryComp<MobStateComponent>(uid, ref val))
		{
			return false;
		}
		if ((int)val.CurrentState == 3)
		{
			return true;
		}
		return (int)val.CurrentState == 2;
	}

	private bool HasLineOfSight(Vector2 from, Vector2 to, EntityUid ignoreEntity)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			MapId mapId = sharedTransformSystem_0.GetMapCoordinates(ignoreEntity, (TransformComponent)null).MapId;
			float num = Vector2.Distance(from, to);
			if (!(num < 0.01f))
			{
				Vector2 direction = Vector2.Normalize(to - from);
				bool flag = CheckRay(mapId, from, direction, num, ignoreEntity);
				if (!flag)
				{
					return false;
				}
				Vector2 vector = new Vector2(0f - direction.Y, direction.X);
				float num2 = 0.2f;
				Vector2 vector2 = from + vector * num2;
				Vector2 vector3 = from - vector * num2;
				bool flag2 = CheckRay(mapId, vector2, direction, num, ignoreEntity);
				bool flag3 = CheckRay(mapId, vector3, direction, num, ignoreEntity);
				return (flag ? 1 : 0) + (flag2 ? 1 : 0) + (flag3 ? 1 : 0) >= 2;
			}
			return true;
		}
		catch (Exception)
		{
			return true;
		}
	}

	private bool CheckRay(MapId mapId, Vector2 from, Vector2 direction, float distance, EntityUid ignoreEntity)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			foreach (RayCastResults item in sharedPhysicsSystem_0.IntersectRay(mapId, new CollisionRay(from, direction, 14), distance - 0.1f, (EntityUid?)ignoreEntity, false))
			{
				RayCastResults current = item;
				EntityUid hitEntity = ((RayCastResults)(ref current)).HitEntity;
				if ((!nullable_1.HasValue || !(hitEntity == nullable_1.Value)) && !((EntitySystem)this).HasComp<MobStateComponent>(hitEntity))
				{
					return false;
				}
			}
			return true;
		}
		catch (Exception)
		{
			return true;
		}
	}

	private Vector2 PerformSimpleWallFollowing(Vector2 playerPos, Vector2 targetPos, EntityUid localPlayer)
	{
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0308: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		Vector2 TcJkoHKH4c = Vector2.Normalize(targetPos - playerPos);
		float num = Vector2.Distance(playerPos, targetPos);
		bool flag = true;
		int num2 = Math.Min(5, (int)(num / 0.5f));
		for (int i = 1; i <= num2; i++)
		{
			float num3 = (float)i / (float)num2;
			Vector2 to = playerPos + TcJkoHKH4c * (num * num3);
			if (!HasLineOfSight(playerPos, to, localPlayer))
			{
				flag = false;
				break;
			}
		}
		if (!flag)
		{
			Vector2 vector = new Vector2(0f - TcJkoHKH4c.Y, TcJkoHKH4c.X) * int_1;
			float[] array = new float[11]
			{
				25f, 40f, 55f, 70f, 85f, 10f, -15f, -30f, 95f, 110f,
				-45f
			};
			int num4 = 0;
			Vector2 vector6;
			while (true)
			{
				if (num4 >= array.Length)
				{
					Vector2 vector2 = -vector;
					if (HasLineOfSight(playerPos, playerPos + vector2 * 1f, localPlayer))
					{
						int_1 *= -1;
						return vector2;
					}
					array = new float[12]
					{
						30f, 45f, 60f, 75f, 90f, 105f, 120f, 135f, 150f, -30f,
						-45f, -60f
					};
					for (num4 = 0; num4 < array.Length; num4++)
					{
						float x = array[num4] * (float)Math.PI / 180f;
						float num5 = MathF.Cos(x);
						float num6 = MathF.Sin(x);
						Vector2 vector3 = new Vector2(TcJkoHKH4c.X * num5 - TcJkoHKH4c.Y * num6, TcJkoHKH4c.X * num6 + TcJkoHKH4c.Y * num5);
						if (HasLineOfSight(playerPos, playerPos + vector3 * 1f, localPlayer))
						{
							return vector3;
						}
					}
					Vector2 vector4 = -TcJkoHKH4c;
					if (HasLineOfSight(playerPos, playerPos + vector4 * 0.5f, localPlayer))
					{
						return vector4;
					}
					Vector2[] array2 = new Vector2[8]
					{
						new Vector2(1f, 0f),
						new Vector2(-1f, 0f),
						new Vector2(0f, 1f),
						new Vector2(0f, -1f),
						new Vector2(0.707f, 0.707f),
						new Vector2(-0.707f, 0.707f),
						new Vector2(0.707f, -0.707f),
						new Vector2(-0.707f, -0.707f)
					}.OrderByDescending((Vector2 dir) => Vector2.Dot(dir, TcJkoHKH4c)).ToArray();
					foreach (Vector2 vector5 in array2)
					{
						if (HasLineOfSight(playerPos, playerPos + vector5 * 0.6f, localPlayer))
						{
							return vector5;
						}
					}
					return Vector2.Zero;
				}
				float x2 = array[num4] * (float)Math.PI / 180f;
				float num7 = MathF.Cos(x2);
				float num8 = MathF.Sin(x2);
				vector6 = new Vector2(vector.X * num7 - vector.Y * num8, vector.X * num8 + vector.Y * num7);
				float num9 = Math.Min(1.5f, num * 0.4f);
				if (!HasLineOfSight(playerPos, playerPos + vector6 * num9, localPlayer))
				{
					num4++;
					continue;
				}
				break;
			}
			float num10 = 0.35f;
			Vector2 result = Vector2.Normalize(vector6 * (1f - num10) + TcJkoHKH4c * num10);
			_ = igameTiming_0.CurTick.Value % 120;
			return result;
		}
		_ = igameTiming_0.CurTick.Value % 60;
		return TcJkoHKH4c;
	}

	private float EvaluatePathDirection(Vector2 startPos, Vector2 targetPos, Vector2 direction, EntityUid localPlayer)
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		float num = 0f;
		Vector2 vector = startPos;
		float num2 = 0.5f;
		for (int i = 1; i <= 10; i++)
		{
			Vector2 vector2 = vector + direction * num2;
			if (HasLineOfSight(vector, vector2, localPlayer))
			{
				num += 1f;
				float num3 = Vector2.Distance(vector, targetPos);
				num = ((!(Vector2.Distance(vector2, targetPos) < num3)) ? (num - 0.5f) : (num + 2f));
				Vector2 vector3 = Vector2.Normalize(targetPos - vector2);
				if (!HasLineOfSight(vector2, vector2 + vector3 * 1f, localPlayer))
				{
					vector = vector2;
					continue;
				}
				num += 10f;
				break;
			}
			break;
		}
		return num;
	}

	private Vector2 FindClearDirection(Vector2 playerPos, Vector2 desiredDir, EntityUid localPlayer)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		float[] array = new float[8] { 15f, -15f, 30f, -30f, 45f, -45f, 60f, -60f };
		int num = 0;
		Vector2 vector;
		while (true)
		{
			if (num < array.Length)
			{
				float x = array[num] * (float)Math.PI / 180f;
				float num2 = MathF.Cos(x);
				float num3 = MathF.Sin(x);
				vector = new Vector2(desiredDir.X * num2 - desiredDir.Y * num3, desiredDir.X * num3 + desiredDir.Y * num2);
				if (!HasLineOfSight(playerPos, playerPos + vector * 0.8f, localPlayer))
				{
					num++;
					continue;
				}
				break;
			}
			return Vector2.Zero;
		}
		return vector;
	}

	private int CountFreeSteps(Vector2 startPos, Vector2 direction, EntityUid localPlayer, int maxSteps)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		Vector2 vector = startPos;
		float num2 = 0.5f;
		for (int i = 0; i < maxSteps; i++)
		{
			Vector2 vector2 = vector + direction * num2;
			if (HasLineOfSight(vector, vector2, localPlayer))
			{
				num++;
				vector = vector2;
				continue;
			}
			break;
		}
		return num;
	}

	private List<Vector2> FindSimplePath(Vector2 start, Vector2 goal)
	{
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		List<Vector2> list = new List<Vector2>();
		ICommonSession localSession = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
		if (HasLineOfSight(start, goal, (EntityUid)(((_003F?)((localSession == null) ? ((EntityUid?)null) : localSession.AttachedEntity)) ?? EntityUid.Invalid)))
		{
			list.Add(goal);
			return list;
		}
		Vector2 vector = Vector2.Normalize(goal - start);
		float num = Vector2.Distance(start, goal);
		int num2 = Math.Min((int)(num / 2f), 5);
		for (int i = 1; i <= num2; i++)
		{
			Vector2 item = start + vector * (num * (float)i / (float)num2);
			list.Add(item);
		}
		return list;
	}

	public override void Shutdown()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		((EntitySystem)this).Shutdown();
		ICommonSession localSession = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
		EntityUid? val = ((localSession == null) ? ((EntityUid?)null) : localSession.AttachedEntity);
		if (val.HasValue)
		{
			ReleaseAllKeys(val.Value);
		}
	}

	public List<Vector2>? GetCurrentPath()
	{
		return list_0;
	}

	public EntityUid? GetCurrentTarget()
	{
		return nullable_1;
	}
}
