using System;
using System.Numerics;
using Content.Shared.Interaction;
using Content.Shared.Physics;
using HarmonyLib;
using Robust.Client.GameObjects;
using Robust.Shared.GameObjects;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using CerberusConfig;

namespace InRangeCheckPatches;

[HarmonyPatch]
public sealed class InRangeCheckPatches
{
	private char char_1;

	private byte byte_0;

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
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	[HarmonyPatch(typeof(SharedTransformSystem), "InRange", new Type[]
	{
		typeof(EntityCoordinates),
		typeof(EntityCoordinates),
		typeof(float)
	})]
	[HarmonyPrefix]
	public static void InRange_Coords_Prefix(ref float range)
	{
		try
		{
			if (CerberusConfig.HitboxVisualizer.ExtendReach)
			{
				range *= CerberusConfig.HitboxVisualizer.ReachMultiplier;
			}
		}
		catch (Exception)
		{
		}
	}

	[HarmonyPatch(typeof(SharedTransformSystem), "InRange", new Type[]
	{
		typeof(Entity<TransformComponent>),
		typeof(Entity<TransformComponent>),
		typeof(float)
	})]
	[HarmonyPrefix]
	public static void InRange_Entity_Prefix(ref float range)
	{
		try
		{
			if (CerberusConfig.HitboxVisualizer.ExtendReach)
			{
				range *= CerberusConfig.HitboxVisualizer.ReachMultiplier;
			}
		}
		catch (Exception)
		{
		}
	}

	[HarmonyPatch(typeof(SharedInteractionSystem), "InRangeUnobstructed", new Type[]
	{
		typeof(EntityUid),
		typeof(EntityUid),
		typeof(float),
		typeof(CollisionGroup),
		typeof(Func<EntityUid, bool>),
		typeof(bool)
	})]
	[HarmonyPrefix]
	public static void InRangeUnobstructed_Prefix(ref float range)
	{
		try
		{
			if (CerberusConfig.HitboxVisualizer.ExtendReach)
			{
				range *= CerberusConfig.HitboxVisualizer.ReachMultiplier;
			}
		}
		catch (Exception)
		{
		}
	}

	[HarmonyPrefix]
	[HarmonyPatch(typeof(SharedInteractionSystem), "InRangeUnobstructed", new Type[]
	{
		typeof(EntityUid),
		typeof(EntityCoordinates),
		typeof(float),
		typeof(CollisionGroup),
		typeof(Func<EntityUid, bool>),
		typeof(bool)
	})]
	public static void InRangeUnobstructed_Coords_Prefix(ref float range)
	{
		try
		{
			if (CerberusConfig.HitboxVisualizer.ExtendReach)
			{
				range *= CerberusConfig.HitboxVisualizer.ReachMultiplier;
			}
		}
		catch (Exception)
		{
		}
	}

	[HarmonyPatch(typeof(SpriteSystem), "CalculateBounds", new Type[]
	{
		typeof(Entity<SpriteComponent>),
		typeof(Vector2),
		typeof(Angle),
		typeof(Angle)
	})]
	[HarmonyPostfix]
	public static void CalculateBounds_Postfix(ref Box2Rotated __result)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (CerberusConfig.HitboxVisualizer.ExtendReach)
			{
				float reachMultiplier = CerberusConfig.HitboxVisualizer.ReachMultiplier;
				Vector2 center = ((Box2Rotated)(ref __result)).Center;
				Box2 val = ((Box2Rotated)(ref __result)).CalcBoundingBox();
				float num = ((Box2)(ref val)).Width * reachMultiplier;
				float num2 = ((Box2)(ref val)).Height * reachMultiplier;
				Box2 val2 = default(Box2);
				((Box2)(ref val2))._002Ector(center.X - num / 2f, center.Y - num2 / 2f, center.X + num / 2f, center.Y + num2 / 2f);
				__result = new Box2Rotated(val2, __result.Rotation, center);
			}
		}
		catch (Exception)
		{
		}
	}
}
