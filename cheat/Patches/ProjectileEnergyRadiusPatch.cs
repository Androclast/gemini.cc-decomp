using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using HarmonyLib;
using CerberusConfig;

[CompilerGenerated]
public sealed class ProjectileEnergyRadiusPatch
{
	private char char_0;

	private char char_1;

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

	private char Char_1
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

	public static void Patch()
	{
		Type type = AccessTools.TypeByName("Robust.Shared.GameObjects.SharedPointLightComponent");
		if (type != null)
		{
			MethodInfo methodInfo = AccessTools.PropertyGetter(type, "Energy");
			if (methodInfo != null)
			{
				MethodInfo method = NukePdaPatchHelper.GetMethod(typeof(ProjectileEnergyRadiusPatch), "EnergyGetterPostfix");
				NukePdaPatchHelper.PatchMethod(methodInfo, method, (HarmonyPatchType)2);
			}
			MethodInfo methodInfo2 = AccessTools.PropertyGetter(type, "Radius");
			if (methodInfo2 != null)
			{
				MethodInfo method2 = NukePdaPatchHelper.GetMethod(typeof(ProjectileEnergyRadiusPatch), "RadiusGetterPostfix");
				NukePdaPatchHelper.PatchMethod(methodInfo2, method2, (HarmonyPatchType)2);
			}
			MethodInfo methodInfo3 = AccessTools.PropertySetter(type, "Energy");
			if (methodInfo3 != null)
			{
				MethodInfo method3 = NukePdaPatchHelper.GetMethod(typeof(ProjectileEnergyRadiusPatch), "EnergySetterPrefix");
				NukePdaPatchHelper.PatchMethod(methodInfo3, method3, (HarmonyPatchType)1);
			}
			MethodInfo methodInfo4 = AccessTools.PropertySetter(type, "Radius");
			if (methodInfo4 != null)
			{
				MethodInfo method4 = NukePdaPatchHelper.GetMethod(typeof(ProjectileEnergyRadiusPatch), "RadiusSetterPrefix");
				NukePdaPatchHelper.PatchMethod(methodInfo4, method4, (HarmonyPatchType)1);
			}
		}
	}

	private static void EnergyGetterPostfix(ref float __result)
	{
		if (CerberusConfig.LightEnhancement.Enabled)
		{
			__result *= CerberusConfig.LightEnhancement.EnergyMultiplier;
		}
	}

	private static void RadiusGetterPostfix(ref float __result)
	{
		if (CerberusConfig.LightEnhancement.Enabled)
		{
			__result *= CerberusConfig.LightEnhancement.RadiusMultiplier;
		}
	}

	private static void EnergySetterPrefix(object __instance)
	{
		if (!CerberusConfig.LightEnhancement.Enabled)
		{
			return;
		}
		try
		{
			FieldInfo fieldInfo = AccessTools.Field(__instance.GetType(), "_netSync");
			if (fieldInfo != null)
			{
				fieldInfo.SetValue(__instance, false);
			}
		}
		catch (Exception)
		{
		}
	}

	private static void RadiusSetterPrefix(object __instance)
	{
		if (!CerberusConfig.LightEnhancement.Enabled)
		{
			return;
		}
		try
		{
			FieldInfo fieldInfo = AccessTools.Field(__instance.GetType(), "_netSync");
			if (fieldInfo != null)
			{
				fieldInfo.SetValue(__instance, false);
			}
		}
		catch (Exception)
		{
		}
	}
}
