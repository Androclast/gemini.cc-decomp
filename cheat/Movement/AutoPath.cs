using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using Content.Shared.Humanoid;
using Content.Shared.Mobs.Components;
using Robust.Client.GameObjects;
using Robust.Client.Input;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.Input;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using Robust.Shared.Physics.Components;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using CerberusConfig;

namespace AutoPath;

public sealed class AutoPath : EntitySystem
{
	private class PathNode
	{
		public Vector2 CncHIs1npl;

		public float bffHXdIr7B;

		public float xMeHc6Rtyi;

		public PathNode yNgHmBHRY5;

		private double double_2;

		private double double_3;

		private double Double_0
		{
			get
			{
				return double_2;
			}
			set
			{
				double_2 = value;
			}
		}

		private double Double_1
		{
			get
			{
				return double_3;
			}
			set
			{
				double_3 = value;
			}
		}

		[SpecialName]
		public float H7aHLvG16S()
		{
			return bffHXdIr7B + xMeHc6Rtyi;
		}
	}

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly SharedTransformSystem sharedTransformSystem_0;

	[Dependency]
	private readonly EntityLookupSystem entityLookupSystem_0;

	[Dependency]
	private readonly FriendsList gclass6_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly IInputManager iinputManager_0;

	[Dependency]
	private readonly InputSystem inputSystem_0;

	private readonly Dictionary<BoundKeyFunction, bool> dictionary_0 = new Dictionary<BoundKeyFunction, bool>();

	private List<Vector2> list_0 = new List<Vector2>();

	private int int_0;

	private EntityUid? nullable_0;

	private float float_0;

	private long long_1;

	private char char_1;

	private byte byte_1;

	private char char_2;

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

	private char Char_1
	{
		get
		{
			return char_2;
		}
		set
		{
			char_2 = value;
		}
	}

	public override void Update(float frameTime)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		if (CerberusConfig.AutoPath.Enabled)
		{
			EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
			if (!localEntity.HasValue)
			{
				return;
			}
			try
			{
				if (!nullable_0.HasValue || !base.EntityManager.EntityExists(nullable_0.Value))
				{
					nullable_0 = FindNearestTarget(localEntity.Value);
					if (!nullable_0.HasValue)
					{
						list_0.Clear();
						return;
					}
				}
				Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(localEntity.Value);
				Vector2 worldPosition2 = sharedTransformSystem_0.GetWorldPosition(nullable_0.Value);
				float_0 -= frameTime;
				if (float_0 <= 0f || list_0.Count == 0)
				{
					float_0 = 0.5f;
					list_0 = FindPath(worldPosition, worldPosition2);
					int_0 = 0;
					if (list_0.Count == 0)
					{
						nullable_0 = null;
						return;
					}
				}
				if (int_0 >= list_0.Count)
				{
					nullable_0 = null;
					list_0.Clear();
					return;
				}
				Vector2 vector = list_0[int_0];
				if (Vector2.Distance(worldPosition, vector) < 0.3f)
				{
					int_0++;
				}
				else
				{
					MoveTowards(localEntity.Value, vector);
				}
				return;
			}
			catch (Exception)
			{
				return;
			}
		}
		list_0.Clear();
		nullable_0 = null;
		EntityUid? localEntity2 = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (localEntity2.HasValue)
		{
			ReleaseAllKeys(localEntity2.Value);
		}
	}

	private EntityUid? FindNearestTarget(EntityUid player)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(player);
		MapId mapId = sharedTransformSystem_0.GetMapId(Entity<TransformComponent>.op_Implicit(player));
		EntityUid? result = null;
		float num = float.MaxValue;
		foreach (EntityUid item in entityLookupSystem_0.GetEntitiesInRange(mapId, worldPosition, 30f, (LookupFlags)110))
		{
			if (!(item == player) && IsValidTarget(item))
			{
				float num2 = Vector2.Distance(worldPosition, sharedTransformSystem_0.GetWorldPosition(item));
				if (num2 < num)
				{
					num = num2;
					result = item;
				}
			}
		}
		return result;
	}

	private bool IsValidTarget(EntityUid entity)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Invalid comparison between Unknown and I4
		if (base.EntityManager.HasComponent<HumanoidAppearanceComponent>(entity))
		{
			if (!gclass6_0.IsFriend(entity))
			{
				MobStateComponent val = default(MobStateComponent);
				if (!base.EntityManager.TryGetComponent<MobStateComponent>(entity, ref val) || (int)val.CurrentState != 3)
				{
					return true;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	public List<Vector2> FindPathPublic(Vector2 start, Vector2 goal)
	{
		return FindPath(start, goal);
	}

	private List<Vector2> FindPath(Vector2 start, Vector2 goal)
	{
		List<Vector2> list = new List<Vector2>();
		if (!HasLineOfSight(start, goal))
		{
			if (Vector2.Distance(start, goal) <= 30f)
			{
				List<PathNode> list2 = new List<PathNode>();
				HashSet<Vector2> hashSet = new HashSet<Vector2>();
				PathNode item = new PathNode
				{
					CncHIs1npl = SnapToGrid(start),
					bffHXdIr7B = 0f,
					xMeHc6Rtyi = Vector2.Distance(start, goal),
					yNgHmBHRY5 = null
				};
				list2.Add(item);
				int num = 0;
				PathNode pathNode;
				while (true)
				{
					if (list2.Count > 0 && num < 500)
					{
						num++;
						pathNode = list2.OrderBy((PathNode n) => n.H7aHLvG16S()).First();
						list2.Remove(pathNode);
						hashSet.Add(pathNode.CncHIs1npl);
						if (!(Vector2.Distance(pathNode.CncHIs1npl, goal) >= 0.5f))
						{
							break;
						}
						foreach (Vector2 xlrHJwEqN8 in GetNeighbors(pathNode.CncHIs1npl))
						{
							if (hashSet.Contains(xlrHJwEqN8) || !IsWalkable(xlrHJwEqN8))
							{
								continue;
							}
							float num2 = pathNode.bffHXdIr7B + Vector2.Distance(pathNode.CncHIs1npl, xlrHJwEqN8);
							PathNode pathNode2 = list2.FirstOrDefault((PathNode n) => n.CncHIs1npl == xlrHJwEqN8);
							if (pathNode2 != null)
							{
								if (num2 < pathNode2.bffHXdIr7B)
								{
									pathNode2.bffHXdIr7B = num2;
									pathNode2.yNgHmBHRY5 = pathNode;
								}
							}
							else
							{
								pathNode2 = new PathNode
								{
									CncHIs1npl = xlrHJwEqN8,
									bffHXdIr7B = num2,
									xMeHc6Rtyi = Vector2.Distance(xlrHJwEqN8, goal),
									yNgHmBHRY5 = pathNode
								};
								list2.Add(pathNode2);
							}
						}
						continue;
					}
					return list;
				}
				return ReconstructPath(pathNode);
			}
			return list;
		}
		list.Add(goal);
		return list;
	}

	private List<Vector2> ReconstructPath(PathNode endNode)
	{
		List<Vector2> list = new List<Vector2>();
		for (PathNode pathNode = endNode; pathNode != null; pathNode = pathNode.yNgHmBHRY5)
		{
			list.Add(pathNode.CncHIs1npl);
		}
		list.Reverse();
		return list;
	}

	private List<Vector2> GetNeighbors(Vector2 position)
	{
		List<Vector2> list = new List<Vector2>();
		for (int i = -1; i <= 1; i++)
		{
			for (int j = -1; j <= 1; j++)
			{
				if (i != 0 || j != 0)
				{
					Vector2 item = position + new Vector2((float)i * 0.5f, (float)j * 0.5f);
					list.Add(item);
				}
			}
		}
		return list;
	}

	private bool IsWalkable(Vector2 position)
	{
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Invalid comparison between Unknown and I4
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
			if (!localEntity.HasValue)
			{
				return true;
			}
			MapId mapId = sharedTransformSystem_0.GetMapId(Entity<TransformComponent>.op_Implicit(localEntity.Value));
			Box2 val = default(Box2);
			((Box2)(ref val))._002Ector(position - Vector2.One * 0.3f, position + Vector2.One * 0.3f);
			PhysicsComponent val2 = default(PhysicsComponent);
			foreach (EntityUid item in entityLookupSystem_0.GetEntitiesIntersecting(mapId, val, (LookupFlags)4))
			{
				if (!(item == localEntity.Value) && base.EntityManager.TryGetComponent<PhysicsComponent>(item, ref val2) && val2.CanCollide && val2.Hard && ((int)val2.BodyType == 4 || (int)val2.BodyType == 0))
				{
					return false;
				}
			}
			return true;
		}
		catch
		{
			return true;
		}
	}

	private bool HasLineOfSight(Vector2 start, Vector2 end)
	{
		Vector2 vector = Vector2.Normalize(end - start);
		float num = Vector2.Distance(start, end);
		int num2 = (int)(num / 0.25f);
		for (int i = 1; i < num2; i++)
		{
			Vector2 position = start + vector * (num * (float)i / (float)num2);
			if (!IsWalkable(position))
			{
				return false;
			}
		}
		return true;
	}

	private Vector2 SnapToGrid(Vector2 position)
	{
		return new Vector2(MathF.Round(position.X / 0.5f) * 0.5f, MathF.Round(position.Y / 0.5f) * 0.5f);
	}

	private void MoveTowards(EntityUid player, Vector2 targetPos)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(player);
		Vector2 vector = Vector2.Normalize(targetPos - worldPosition);
		float num = 0f;
		try
		{
			TransformComponent val = default(TransformComponent);
			if (base.EntityManager.TryGetComponent<TransformComponent>(player, ref val))
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
		float num4 = vector.X * num2 - vector.Y * num3;
		float num5 = vector.X * num3 + vector.Y * num2;
		bool pressed = num5 > 0.3f;
		bool pressed2 = num5 < -0.3f;
		bool pressed3 = num4 < -0.3f;
		bool pressed4 = num4 > 0.3f;
		UpdateKey(EngineKeyFunctions.MoveUp, pressed, player);
		UpdateKey(EngineKeyFunctions.MoveDown, pressed2, player);
		UpdateKey(EngineKeyFunctions.MoveLeft, pressed3, player);
		UpdateKey(EngineKeyFunctions.MoveRight, pressed4, player);
		UpdateKey(EngineKeyFunctions.Walk, pressed: false, player);
	}

	private void UpdateKey(BoundKeyFunction function, bool pressed, EntityUid playerUid)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
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
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		foreach (BoundKeyFunction item in (from kvp in dictionary_0
			where kvp.Value
			select kvp.Key).ToList())
		{
			UpdateKey(item, pressed: false, playerUid);
		}
	}

	public List<Vector2> GetCurrentPath()
	{
		return list_0;
	}

	public EntityUid? GetCurrentTarget()
	{
		return nullable_0;
	}

	private string method_4(int int_1)
	{
		return "Хитролох_иди_нахуй.__6____6____8_6____3";
	}
}
