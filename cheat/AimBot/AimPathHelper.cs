using System;
using System.Collections.Generic;
using System.Numerics;
using Robust.Shared.GameObjects;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using Robust.Shared.Physics.Components;
using Robust.Shared.Physics.Systems;

namespace AimPathHelper;

public sealed class AimPathHelper
{
	private readonly SharedPhysicsSystem physics;

	private readonly SharedTransformSystem transformSystem;

	private readonly IEntityManager entityManager;

	private readonly EntityLookupSystem entityLookup;

	private readonly EntityUid ignoreEntity;

	private readonly EntityUid? targetEntity;

	private List<Vector2> list_0 = new List<Vector2>();

	private Vector2 vector2_0 = Vector2.Zero;

	private Vector2 vector2_1 = Vector2.Zero;

	private float float_0;

	private string string_0;

	private char char_0;

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

	public AimPathHelper(SharedPhysicsSystem physics, SharedTransformSystem transformSystem, IEntityManager entityManager, EntityLookupSystem entityLookup, EntityUid ignoreEntity, EntityUid? targetEntity = null)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		this.physics = physics;
		this.transformSystem = transformSystem;
		this.entityManager = entityManager;
		this.entityLookup = entityLookup;
		this.ignoreEntity = ignoreEntity;
		this.targetEntity = targetEntity;
	}

	public List<Vector2> FindPath(Vector2 start, Vector2 target, float deltaTime)
	{
		float_0 -= deltaTime;
		if (!(float_0 <= 0f) && list_0.Count > 0)
		{
			float num = Vector2.Distance(start, vector2_0);
			float num2 = Vector2.Distance(target, vector2_1);
			if (num < 0.6f && num2 < 0.6f)
			{
				return list_0;
			}
		}
		if (!HasLineOfSight(start, target))
		{
			if (Vector2.Distance(start, target) <= 25f)
			{
				List<Vector2> result = (list_0 = FindPathAStar(start, target));
				vector2_0 = start;
				vector2_1 = target;
				float_0 = 1f;
				return result;
			}
			list_0 = new List<Vector2> { target };
			vector2_0 = start;
			vector2_1 = target;
			float_0 = 1f;
			return list_0;
		}
		list_0 = new List<Vector2> { target };
		vector2_0 = start;
		vector2_1 = target;
		float_0 = 1f;
		return list_0;
	}

	private List<Vector2> FindPathAStar(Vector2 start, Vector2 target)
	{
		List<Vector2> list = new List<Vector2>();
		if (Vector2.Distance(start, target) >= 1.8000001f)
		{
			Vector2 vector = Vector2.Normalize(target - start);
			float num = Vector2.Distance(start, target);
			int num2 = Math.Min((int)(num / 0.6f), 10);
			for (int i = 1; i <= num2; i++)
			{
				Vector2 vector2 = start + vector * (num * (float)i / (float)num2);
				if (IsWalkable(vector2))
				{
					list.Add(vector2);
				}
			}
			if (list.Count == 0)
			{
				list.Add(target);
			}
			return list;
		}
		list.Add(target);
		return list;
	}

	private bool HasLineOfSight(Vector2 start, Vector2 target)
	{
		Vector2 vector = Vector2.Normalize(target - start);
		float num = Vector2.Distance(start, target);
		int num2 = (int)(num / 0.3f);
		int num3 = 1;
		while (true)
		{
			if (num3 >= num2)
			{
				return true;
			}
			Vector2 position = start + vector * (num * (float)num3 / (float)num2);
			if (!IsWalkable(position))
			{
				break;
			}
			num3++;
		}
		return false;
	}

	private bool IsWalkable(Vector2 position)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			MapId nullspace = MapId.Nullspace;
			Box2 val = default(Box2);
			((Box2)(ref val))._002Ector(position - Vector2.One * 0.15f, position + Vector2.One * 0.15f);
			foreach (EntityUid item in entityLookup.GetEntitiesIntersecting(nullspace, val, (LookupFlags)6))
			{
				if (!(item == ignoreEntity) && entityManager.HasComponent<PhysicsComponent>(item))
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

	private Vector2 SnapToGrid(Vector2 position)
	{
		return new Vector2(MathF.Round(position.X / 0.6f) * 0.6f, MathF.Round(position.Y / 0.6f) * 0.6f);
	}
}
