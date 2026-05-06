using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using HarmonyLib;
using CerberusConfig;

[CompilerGenerated]
public sealed class OverlayDrawPatch
{
	private double double_0;

	private int int_0;

	private float float_0;

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

	private int Int32_0
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

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

	private static MethodInfo GetOverlayDraw(string typeName)
	{
		Type type = AccessTools.TypeByName(typeName);
		if (!(type != null))
		{
			return null;
		}
		return AccessTools.Method(type, "Draw", (Type[])null, (Type[])null);
	}

	private static IEnumerable<MethodInfo> TargetMethods()
	{
		return from m in new List<MethodInfo>
			{
				GetOverlayDraw("Content.Client.Drunk.DrunkOverlay"),
				GetOverlayDraw("Content.Client.Drugs.RainbowOverlay"),
				GetOverlayDraw("Content.Client.Eye.Blinding.BlurryVisionOverlay"),
				GetOverlayDraw("Content.Client.Eye.Blinding.BlindOverlay"),
				GetOverlayDraw("Content.Client.Flash.FlashOverlay"),
				GetOverlayDraw("Content.Client.Silicons.StationAi.StationAiOverlay")
			}
			where m != null
			select (m);
	}

	public static void Patch()
	{
		IEnumerable<MethodInfo> enumerable = TargetMethods();
		MethodInfo method = NukePdaPatchHelper.GetMethod(typeof(OverlayDrawPatch), "Prefix");
		foreach (MethodInfo item in enumerable)
		{
			NukePdaPatchHelper.PatchMethod(item, method, (HarmonyPatchType)1);
		}
	}

	private static bool Prefix()
	{
		return !CerberusConfig.Settings.OverlaysPatch;
	}
}
