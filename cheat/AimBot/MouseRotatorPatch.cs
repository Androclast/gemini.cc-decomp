using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Content.Client.MouseRotator;
using HarmonyLib;
using CerberusConfig;

[CompilerGenerated]
public class MouseRotatorPatch
{
	private float float_0;

	private long long_1;

	private float Single_0
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
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

	private static MethodInfo TargetMethod()
	{
		return AccessTools.Method(typeof(MouseRotatorSystem), "Update", (Type[])null, (Type[])null);
	}

	public static void Patch()
	{
		MethodInfo method = TargetMethod();
		MethodInfo method2 = NukePdaPatchHelper.GetMethod(typeof(MouseRotatorPatch), "Prefix");
		NukePdaPatchHelper.PatchMethod(method, method2, (HarmonyPatchType)1);
	}

	public static bool Prefix()
	{
		if (!CerberusConfig.Misc.AntiAimEnabled)
		{
			return (!CerberusConfig.MeleeHelper.RotateToTarget && !CerberusConfig.GunHelper.RotateToTarget) || !CerberusConfig.NoSavedConfig.HasTarget;
		}
		return false;
	}

	private string method_6(bool bool_1)
	{
		return "Хитролох_иди_нахуй._____0______889_________";
	}
}
