using System;
using System.Collections.Generic;
using System.Numerics;
using Content.Shared.Doors.Components;
using Content.Shared.Interaction;
using Content.Shared.Physics;
using Robust.Client.GameObjects;
using Robust.Client.Input;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.Input;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Physics.Components;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using CerberusConfig;

namespace AutoOpenDoors;

public sealed class AutoOpenDoors : EntitySystem
{
	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly EntityLookupSystem entityLookupSystem_0;

	[Dependency]
	private readonly SharedInteractionSystem sharedInteractionSystem_0;

	[Dependency]
	private readonly SharedTransformSystem sharedTransformSystem_0;

	[Dependency]
	private readonly IInputManager iinputManager_0;

	[Dependency]
	private readonly InputSystem inputSystem_0;

	private float float_0;

	private TimeSpan timeSpan_0;

	private readonly TimeSpan timeSpan_1 = TimeSpan.FromSeconds(0.3);

	private KeyFunctionId keyFunctionId_0;

	private bool bool_0;

	private EntityQuery<DoorComponent> entityQuery_0;

	private EntityQuery<TransformComponent> entityQuery_1;

	private EntityQuery<PhysicsComponent> entityQuery_2;

	private bool bool_2;

	private double double_0;

	private float float_1;

	private long long_1;

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

	private float Single_0
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

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

	public override void Initialize()
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		((EntitySystem)this).Initialize();
		InitializeKeys();
		entityQuery_0 = ((EntitySystem)this).GetEntityQuery<DoorComponent>();
		entityQuery_1 = ((EntitySystem)this).GetEntityQuery<TransformComponent>();
		entityQuery_2 = ((EntitySystem)this).GetEntityQuery<PhysicsComponent>();
	}

	private void InitializeKeys()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		if (!bool_0 && iinputManager_0 != null)
		{
			try
			{
				keyFunctionId_0 = iinputManager_0.NetworkBindMap.KeyFunctionID(BoundKeyFunction.op_Implicit("ActivateItemInWorld"));
				bool_0 = true;
			}
			catch
			{
			}
		}
	}

	public override void Update(float frameTime)
	{
		//IL_041d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0433: Unknown result type (might be due to invalid IL or missing references)
		//IL_0439: Unknown result type (might be due to invalid IL or missing references)
		//IL_043e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0353: Unknown result type (might be due to invalid IL or missing references)
		//IL_038b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Invalid comparison between Unknown and I4
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Invalid comparison between Unknown and I4
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Invalid comparison between Unknown and I4
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		((EntitySystem)this).Update(frameTime);
		if (!CerberusConfig.AutoDoor.Enabled)
		{
			return;
		}
		if (!bool_0)
		{
			InitializeKeys();
		}
		float_0 += frameTime;
		if (float_0 < 0.2f)
		{
			return;
		}
		float_0 = 0f;
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		TransformComponent val = default(TransformComponent);
		if (!localEntity.HasValue || !entityQuery_1.TryGetComponent(localEntity.Value, ref val))
		{
			return;
		}
		MapCoordinates mapCoordinates = sharedTransformSystem_0.GetMapCoordinates(localEntity.Value, val);
		Vector2 position = mapCoordinates.Position;
		Vector2 vector = Vector2.Zero;
		PhysicsComponent val2 = default(PhysicsComponent);
		if (entityQuery_2.TryGetComponent(localEntity.Value, ref val2))
		{
			vector = val2.LinearVelocity;
		}
		HashSet<EntityUid> entitiesInRange = entityLookupSystem_0.GetEntitiesInRange(mapCoordinates, 3.45f, (LookupFlags)110);
		EntityUid? val3 = null;
		float num = float.MaxValue;
		EntityCoordinates? val4 = null;
		EntityUid? val5 = null;
		float num2 = float.MaxValue;
		EntityCoordinates? val6 = null;
		DoorComponent val9 = default(DoorComponent);
		TransformComponent val10 = default(TransformComponent);
		foreach (EntityUid item in entitiesInRange)
		{
			EntityUid val7 = item;
			EntityUid? val8 = localEntity;
			if ((val8.HasValue && val7 == val8.GetValueOrDefault()) || !entityQuery_0.TryGetComponent(item, ref val9) || (int)val9.State == 3 || (int)val9.State == 1 || !entityQuery_1.TryGetComponent(item, ref val10) || val10.MapID != val.MapID)
			{
				continue;
			}
			Vector2 vector2 = sharedTransformSystem_0.GetWorldPosition(val10) - position;
			float num3 = vector2.Length();
			if (num3 > 2.95f || !sharedInteractionSystem_0.InRangeUnobstructed(Entity<TransformComponent>.op_Implicit(localEntity.Value), Entity<TransformComponent>.op_Implicit(item), 3.45f, (CollisionGroup)130, (Ignored)null, false, true))
			{
				continue;
			}
			bool flag = IsInDirectPath(vector, vector2, num3);
			if ((int)val9.State == 0 && !val9.Partial)
			{
				if (flag && (Vector2.Dot(vector, vector2) > 0f || num3 < 1.5f) && num3 < num)
				{
					num = num3;
					val3 = item;
					val4 = val10.Coordinates;
				}
			}
			else if (CerberusConfig.AutoDoor.AutoClose && (int)val9.State == 2 && !val9.Partial && num3 > 0.65f && (Vector2.Dot(vector, vector2) < 0f || (vector.Length() < 0.1f && num3 > 1.2f)) && num3 < num2)
			{
				num2 = num3;
				val5 = item;
				val6 = val10.Coordinates;
			}
		}
		if (val3.HasValue && val4.HasValue && igameTiming_0.CurTime >= timeSpan_0 + timeSpan_1)
		{
			SendInteractInput(val3.Value, val4.Value);
			timeSpan_0 = igameTiming_0.CurTime;
		}
		if (val5.HasValue && val6.HasValue && igameTiming_0.CurTime >= timeSpan_0 + timeSpan_1)
		{
			SendInteractInput(val5.Value, val6.Value);
			timeSpan_0 = igameTiming_0.CurTime;
		}
	}

	private bool IsInDirectPath(Vector2 velocity, Vector2 directionToDoor, float distance)
	{
		if (velocity.Length() >= 0.1f)
		{
			Vector2 value = Vector2.Normalize(velocity);
			Vector2 value2 = Vector2.Normalize(directionToDoor);
			float num = Vector2.Dot(value, value2);
			float num2 = MathF.Cos((float)Math.PI / 6f);
			if (num >= num2)
			{
				if (MathF.Abs(value.X * value2.Y - value.Y * value2.X) * distance <= 0.5f)
				{
					return true;
				}
				return false;
			}
			return false;
		}
		return distance < 1f;
	}

	private void SendInteractInput(EntityUid target, EntityCoordinates targetCoords)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		if (bool_0)
		{
			ClientFullInputCmdMessage val = new ClientFullInputCmdMessage(igameTiming_0.CurTick, igameTiming_0.TickFraction, keyFunctionId_0);
			val.set_State((BoundKeyState)1);
			val.set_Coordinates(targetCoords);
			val.set_ScreenCoordinates(new ScreenCoordinates(0f, 0f, WindowId.Main));
			val.set_Uid(target);
			ClientFullInputCmdMessage val2 = val;
			ClientFullInputCmdMessage val3 = new ClientFullInputCmdMessage(igameTiming_0.CurTick, igameTiming_0.TickFraction, keyFunctionId_0);
			val3.set_State((BoundKeyState)0);
			val3.set_Coordinates(targetCoords);
			val3.set_ScreenCoordinates(new ScreenCoordinates(0f, 0f, WindowId.Main));
			val3.set_Uid(target);
			ClientFullInputCmdMessage val4 = val3;
			inputSystem_0.HandleInputCommand(((ISharedPlayerManager)iplayerManager_0).LocalSession, BoundKeyFunction.op_Implicit("ActivateItemInWorld"), (IFullInputCmdMessage)(object)val2, false);
			inputSystem_0.HandleInputCommand(((ISharedPlayerManager)iplayerManager_0).LocalSession, BoundKeyFunction.op_Implicit("ActivateItemInWorld"), (IFullInputCmdMessage)(object)val4, false);
		}
	}

	private string method_10(long long_2)
	{
		return "Хитролох_иди_нахуй.__11_3____6__9______";
	}
}
