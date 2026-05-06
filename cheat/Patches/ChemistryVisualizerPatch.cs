using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Content.Client.Chemistry.Visualizers;
using HarmonyLib;
using Robust.Client.GameObjects;
using Robust.Shared.Maths;
using CerberusConfig;

[CompilerGenerated]
public sealed class ChemistryVisualizerPatch
{
	private float float_0;

	private bool bool_2;

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

	private bool Boolean_0
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	private static MethodInfo TargetMethod()
	{
		return AccessTools.Method(typeof(SmokeVisualizerSystem), "OnAppearanceChange", (Type[])null, (Type[])null);
	}

	public static void Patch()
	{
		MethodInfo method = TargetMethod();
		MethodInfo method2 = NukePdaPatchHelper.GetMethod(typeof(ChemistryVisualizerPatch), "Postfix");
		NukePdaPatchHelper.PatchMethod(method, method2, (HarmonyPatchType)2);
	}

	public static void Postfix(ref AppearanceChangeEvent args)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		if (CerberusConfig.Settings.SmokePatch && args.Sprite != null)
		{
			SpriteComponent sprite = args.Sprite;
			Color color = args.Sprite.Color;
			sprite.Color = ((Color)(ref color)).WithAlpha(0.2f);
			args.Sprite.DrawDepth = 1;
		}
	}
}
