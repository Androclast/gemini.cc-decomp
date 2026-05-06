using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Content.Shared.Mobs.Components;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Maths;
using Robust.Shared.Network;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using CerberusConfig;

namespace PositionBacktracker;

public class PositionBacktracker : EntitySystem
{
	public struct PositionRecord(TimeSpan time, Vector2 pos, Angle rotation, Vector2 velocity)
	{
		public TimeSpan Time = time;

		public Vector2 Position = pos;

		public Angle Rotation = rotation;

		public Vector2 Velocity = velocity;

		private double double_0;

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
	}

	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly IClientNetManager iclientNetManager_0;

	[Dependency]
	private readonly SharedTransformSystem sharedTransformSystem_0;

	private Dictionary<EntityUid, Queue<PositionRecord>> dictionary_0 = new Dictionary<EntityUid, Queue<PositionRecord>>();

	private float float_0;

	private float float_1;

	private float float_2;

	private string string_0;

	private float float_3;

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

	private float Single_1
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
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

	private float Single_2
	{
		get
		{
			return float_3;
		}
		set
		{
			float_3 = value;
		}
	}

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
	}

	public override void Update(float frameTime)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Invalid comparison between Unknown and I4
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		if (CerberusConfig.Backtrack.Enabled)
		{
			TimeSpan curTime = igameTiming_0.CurTime;
			EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
			if (!localEntity.HasValue)
			{
				return;
			}
			float_0 += frameTime;
			if (float_0 >= 2f)
			{
				float_0 = 0f;
				CleanupOldData(curTime);
			}
			int num = 0;
			EntityQueryEnumerator<MobStateComponent, TransformComponent> val = ientityManager_0.EntityQueryEnumerator<MobStateComponent, TransformComponent>();
			EntityUid val2 = default(EntityUid);
			MobStateComponent val3 = default(MobStateComponent);
			TransformComponent val4 = default(TransformComponent);
			while (val.MoveNext(ref val2, ref val3, ref val4) && num < 50)
			{
				if (val2 == localEntity.Value || (int)val3.CurrentState == 3)
				{
					continue;
				}
				Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(ientityManager_0.GetComponent<TransformComponent>(localEntity.Value));
				Vector2 worldPosition2 = sharedTransformSystem_0.GetWorldPosition(val4);
				if (Vector2.Distance(worldPosition, worldPosition2) > 50f)
				{
					continue;
				}
				if (!dictionary_0.ContainsKey(val2))
				{
					dictionary_0[val2] = new Queue<PositionRecord>();
				}
				Queue<PositionRecord> queue = dictionary_0[val2];
				if (queue.Count >= 100)
				{
					queue.Dequeue();
				}
				Vector2 velocity = Vector2.Zero;
				if (queue.Count > 0)
				{
					PositionRecord positionRecord = queue.Last();
					float num2 = (float)(curTime - positionRecord.Time).TotalSeconds;
					if (!(num2 <= 0f) && num2 < 1f)
					{
						velocity = (sharedTransformSystem_0.GetWorldPosition(val4) - positionRecord.Position) / num2;
					}
				}
				Vector2 worldPosition3 = sharedTransformSystem_0.GetWorldPosition(val4);
				Angle worldRotation = val4.WorldRotation;
				queue.Enqueue(new PositionRecord(curTime, worldPosition3, worldRotation, velocity));
				num++;
			}
		}
		else if (dictionary_0.Count > 0)
		{
			dictionary_0.Clear();
		}
	}

	private void CleanupOldData(TimeSpan currentTime)
	{
		//IL_0108: Expected I8, but got I4
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		TimeSpan timeSpan = currentTime - TimeSpan.FromMilliseconds(750L);
		List<EntityUid> list = new List<EntityUid>();
		foreach (KeyValuePair<EntityUid, Queue<PositionRecord>> item in dictionary_0)
		{
			EntityUid key = item.Key;
			Queue<PositionRecord> value = item.Value;
			if (ientityManager_0.EntityExists(key))
			{
				while (value.Count > 0 && value.Peek().Time < timeSpan)
				{
					value.Dequeue();
				}
				if (value.Count == 0)
				{
					list.Add(key);
				}
			}
			else
			{
				list.Add(key);
			}
		}
		foreach (EntityUid item2 in list)
		{
			dictionary_0.Remove(item2);
		}
		if (dictionary_0.Count <= 50)
		{
			return;
		}
		foreach (EntityUid item3 in (from kvp in (from kvp in dictionary_0
				where kvp.Value.Count > 0
				orderby kvp.Value.First().Time
				select kvp).Take(dictionary_0.Count - 50)
			select kvp.Key).ToList())
		{
			dictionary_0.Remove(item3);
		}
	}

	public bool TryGetBacktrackPosition(EntityUid targetUid, out Vector2 backtrackPosition)
	{
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		backtrackPosition = Vector2.Zero;
		if (!CerberusConfig.Backtrack.Enabled)
		{
			return false;
		}
		if (dictionary_0.ContainsKey(targetUid))
		{
			Queue<PositionRecord> queue = dictionary_0[targetUid];
			if (queue.Count != 0)
			{
				INetChannel serverChannel = iclientNetManager_0.ServerChannel;
				short num = (short)((serverChannel != null) ? serverChannel.Ping : 0);
				if (num <= 0)
				{
					backtrackPosition = queue.Last().Position;
					return true;
				}
				float num2 = 1.5f;
				switch (CerberusConfig.Backtrack.Mode)
				{
				case 2:
					num2 = 0.5f;
					break;
				case 1:
					num2 = 1f;
					break;
				case 0:
					num2 = 1.5f;
					break;
				}
				float num3 = (float)num * num2;
				if (CerberusConfig.Backtrack.UseFakeLag)
				{
					num3 += (float)CerberusConfig.Backtrack.FakeLagMs;
				}
				TimeSpan timeSpan = igameTiming_0.CurTime - TimeSpan.FromMilliseconds(num3);
				PositionRecord? positionRecord = null;
				foreach (PositionRecord item in queue)
				{
					positionRecord = item;
					if (item.Time >= timeSpan)
					{
						break;
					}
				}
				if (positionRecord.HasValue)
				{
					backtrackPosition = positionRecord.Value.Position;
				}
				else
				{
					backtrackPosition = queue.First().Position;
				}
				return true;
			}
			return false;
		}
		return false;
	}

	public bool TryGetBacktrackPositionWithPrediction(EntityUid targetUid, out Vector2 predictedPosition)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		predictedPosition = Vector2.Zero;
		if (!TryGetBacktrackPosition(targetUid, out var backtrackPosition))
		{
			return false;
		}
		if (dictionary_0.ContainsKey(targetUid))
		{
			Queue<PositionRecord> queue = dictionary_0[targetUid];
			if (queue.Count != 0)
			{
				PositionRecord positionRecord = queue.Last();
				if (positionRecord.Velocity.LengthSquared() <= 0.01f)
				{
					predictedPosition = backtrackPosition;
				}
				else
				{
					INetChannel serverChannel = iclientNetManager_0.ServerChannel;
					float num = (float)((serverChannel != null) ? serverChannel.Ping : 0) / 1000f * 0.3f;
					predictedPosition = backtrackPosition + positionRecord.Velocity * num;
				}
				return true;
			}
			return false;
		}
		return false;
	}

	public List<PositionRecord> GetPositionHistory(EntityUid targetUid)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		if (!dictionary_0.ContainsKey(targetUid))
		{
			return new List<PositionRecord>();
		}
		return new List<PositionRecord>(dictionary_0[targetUid]);
	}

	public Vector2 GetVelocity(EntityUid targetUid)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		if (dictionary_0.ContainsKey(targetUid))
		{
			Queue<PositionRecord> queue = dictionary_0[targetUid];
			if (queue.Count != 0)
			{
				return queue.Last().Velocity;
			}
			return Vector2.Zero;
		}
		return Vector2.Zero;
	}

	public string GetDebugInfo(EntityUid targetUid)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		if (!dictionary_0.ContainsKey(targetUid))
		{
			return "No history";
		}
		Queue<PositionRecord> queue = dictionary_0[targetUid];
		if (queue.Count == 0)
		{
			return "Empty history";
		}
		PositionRecord positionRecord = queue.Last();
		INetChannel serverChannel = iclientNetManager_0.ServerChannel;
		short num = (short)((serverChannel != null) ? serverChannel.Ping : 0);
		float num2 = 1.5f;
		switch (CerberusConfig.Backtrack.Mode)
		{
		case 2:
			num2 = 0.5f;
			break;
		case 1:
			num2 = 1f;
			break;
		case 0:
			num2 = 1.5f;
			break;
		}
		float value = (float)num * num2;
		return $"Ping: {num}ms | Backtrack: {value:F1}ms | Velocity: {positionRecord.Velocity.Length():F2} u/s | Records: {queue.Count}";
	}
}
