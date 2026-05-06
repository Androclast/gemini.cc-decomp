using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Content.Client.Camera;
using HarmonyLib;
using CerberusConfig;

[CompilerGenerated]
public class CameraPatch
{
	private bool bool_0;

	private bool bool_1;

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

	private bool Boolean_1
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	private static MethodInfo TargetMethod()
	{
		return AccessTools.Method(typeof(CameraRecoilSystem), "KickCamera", (Type[])null, (Type[])null);
	}

	public static void Patch()
	{
		MethodInfo method = TargetMethod();
		MethodInfo method2 = NukePdaPatchHelper.GetMethod(typeof(CameraPatch), "Prefix");
		NukePdaPatchHelper.PatchMethod(method, method2, (HarmonyPatchType)1);
	}

	private static bool Prefix()
	{
		return !CerberusConfig.Settings.NoCameraKickPatch;
	}
}
