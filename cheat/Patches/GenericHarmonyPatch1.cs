using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Content.Shared.Weapons.Melee;
using HarmonyLib;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using Robust.Shared.Physics;
using Robust.Shared.Physics.Systems;
using CerberusConfig;

[CompilerGenerated]
public sealed class GenericHarmonyPatch1
{
	private static FriendsList gclass6_0;

	private static SharedPhysicsSystem sharedPhysicsSystem_0;

	private double double_1;

	private byte byte_0;

	private long long_1;

	private double double_2;

	private double Double_0
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

	private double Double_1
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

	private static MethodInfo TargetMethod()
	{
		return AccessTools.Method(typeof(SharedMeleeWeaponSystem), "ArcRayCast", (Type[])null, (Type[])null);
	}

	public static void Patch()
	{
		MethodInfo method = TargetMethod();
		MethodInfo method2 = NukePdaPatchHelper.GetMethod(typeof(GenericHarmonyPatch1), "Prefix");
		NukePdaPatchHelper.PatchMethod(method, method2, (HarmonyPatchType)1);
	}

	public static bool Prefix(SharedMeleeWeaponSystem __instance, Vector2 position, Angle angle, Angle arcWidth, float range, MapId mapId, EntityUid ignore, ref HashSet<EntityUid> __result)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		if (CerberusConfig.Settings.NoDmgFriendPatch)
		{
			if (gclass6_0 == null)
			{
				gclass6_0 = IoCManager.Resolve<IEntityManager>().System<FriendsList>();
			}
			if (sharedPhysicsSystem_0 == null)
			{
				sharedPhysicsSystem_0 = IoCManager.Resolve<IEntityManager>().System<SharedPhysicsSystem>();
			}
			int val = 1 + 35 * (int)Math.Ceiling(arcWidth.Theta / (Math.PI * 2.0));
			val = Math.Max(1, val);
			double num = Angle.op_Implicit(arcWidth) / (double)val;
			Angle val2 = angle - Angle.op_Implicit(Angle.op_Implicit(arcWidth) / 2.0);
			HashSet<EntityUid> hashSet = new HashSet<EntityUid>();
			for (int i = 0; i < val; i++)
			{
				Angle val3 = val2 + Angle.op_Implicit(num * (double)i);
				List<RayCastResults> list = sharedPhysicsSystem_0.IntersectRay(mapId, new CollisionRay(position, ((Angle)(ref val3)).ToWorldVec(), 31), range, (EntityUid?)ignore, false).ToList();
				if (list.Count != 0)
				{
					RayCastResults val4 = list[0];
					EntityUid hitEntity = ((RayCastResults)(ref val4)).HitEntity;
					if (!gclass6_0.IsFriend(hitEntity))
					{
						hashSet.Add(hitEntity);
					}
				}
			}
			__result = hashSet;
			return false;
		}
		return true;
	}
}
