using System;
using System.Collections;
using System.Numerics;
using System.Reflection;
using Content.Shared.Weapons.Melee;
using HarmonyLib;
using Robust.Client.Graphics;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Player;
using HitParticlesOverlay;
using CerberusConfig;

namespace MeleeAttackPatch;

public sealed class MeleeAttackPatch : EntitySystem
{
	private char char_1;

	private string string_0;

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

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
	}

	public override void Shutdown()
	{
		((EntitySystem)this).Shutdown();
	}

	public static void ApplyPatches(Harmony harmony)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		try
		{
			MethodInfo methodInfo = (MethodInfo)((MeleeAttackPatch)(object)typeof(SharedMeleeWeaponSystem)).method_0("DoLightAttack", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (methodInfo != null)
			{
				harmony.Patch((MethodBase)methodInfo, (HarmonyMethod)null, new HarmonyMethod((MethodInfo)((MeleeAttackPatch)(object)typeof(MeleeAttackPatch)).method_0("LightAttackPostfix", BindingFlags.Static | BindingFlags.Public)), (HarmonyMethod)null, (HarmonyMethod)null);
			}
		}
		catch
		{
		}
		try
		{
			MethodInfo methodInfo2 = (MethodInfo)((MeleeAttackPatch)(object)typeof(SharedMeleeWeaponSystem)).method_0("DoHeavyAttack", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (methodInfo2 != null)
			{
				harmony.Patch((MethodBase)methodInfo2, (HarmonyMethod)null, new HarmonyMethod((MethodInfo)((MeleeAttackPatch)(object)typeof(MeleeAttackPatch)).method_0("HeavyAttackPostfix", BindingFlags.Static | BindingFlags.Public)), (HarmonyMethod)null, (HarmonyMethod)null);
			}
		}
		catch
		{
		}
	}

	private static void ProcessAttack(EntityUid user, object ev)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (ev == null)
			{
				return;
			}
			IEntityManager entMan = IoCManager.Resolve<IEntityManager>();
			ICommonSession localSession = ((ISharedPlayerManager)IoCManager.Resolve<IPlayerManager>()).LocalSession;
			EntityUid? val = ((localSession == null) ? ((EntityUid?)null) : localSession.AttachedEntity);
			if (!val.HasValue || user != val.Value)
			{
				return;
			}
			Type type = ev.GetType();
			bool flag = false;
			object obj = null;
			PropertyInfo property = type.GetProperty("Target");
			if (!(property != null))
			{
				FieldInfo field = type.GetField("Target");
				if (field != null)
				{
					obj = field.GetValue(ev);
				}
			}
			else
			{
				obj = property.GetValue(ev);
			}
			if (obj != null)
			{
				EntityUid? val2 = ResolveEntity(entMan, obj);
				if (val2.HasValue)
				{
					RegisterHit(val2.Value);
					flag = true;
				}
			}
			if (flag)
			{
				return;
			}
			object obj2 = null;
			PropertyInfo propertyInfo = type.GetProperty("Entities") ?? type.GetProperty("HitEntities");
			if (propertyInfo != null)
			{
				obj2 = propertyInfo.GetValue(ev);
			}
			else
			{
				FieldInfo fieldInfo = type.GetField("Entities") ?? type.GetField("HitEntities");
				if (fieldInfo != null)
				{
					obj2 = fieldInfo.GetValue(ev);
				}
			}
			if (!(obj2 is IEnumerable enumerable))
			{
				return;
			}
			int num = 0;
			foreach (object item in enumerable)
			{
				EntityUid? val3 = ResolveEntity(entMan, item);
				if (val3.HasValue)
				{
					RegisterHit(val3.Value);
					num++;
					break;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private static EntityUid? ResolveEntity(IEntityManager entMan, object obj)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		if (obj is EntityUid)
		{
			return (EntityUid)obj;
		}
		if (obj is NetEntity val)
		{
			try
			{
				return entMan.GetEntity(val);
			}
			catch
			{
			}
		}
		return null;
	}

	private static void RegisterHit(EntityUid target)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.HitParticles.Enabled)
		{
			return;
		}
		try
		{
			IEntityManager val = IoCManager.Resolve<IEntityManager>();
			IOverlayManager val2 = IoCManager.Resolve<IOverlayManager>();
			TransformComponent val3 = default(TransformComponent);
			if (val.TryGetComponent<TransformComponent>(target, ref val3))
			{
				Vector2 worldPosition = val.System<SharedTransformSystem>().GetWorldPosition(val3);
				val2.GetOverlay<HitParticlesOverlay>()?.SpawnParticles(worldPosition);
			}
		}
		catch (Exception)
		{
		}
	}

	public object method_0(string string_1, BindingFlags bindingFlags_0)
	{
		return ((Type)this).GetMethod(string_1, bindingFlags_0);
	}
}
