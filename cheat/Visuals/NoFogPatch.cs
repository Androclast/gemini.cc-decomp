using System;
using System.Numerics;
using HarmonyLib;
using Robust.Shared.Maths;
using CerberusConfig;

namespace NoFogPatch;

[HarmonyPatch]
public sealed class NoFogPatch
{
	private static Color color_0 = Color.FromSrgb(Color.Black);

	private static bool bool_0 = false;

	private double double_0;

	private float float_1;

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

	[HarmonyPatch(/*Could not decode attribute arguments.*/)]
	[HarmonyPostfix]
	public static void GetClearColor_Postfix(ref Color __result)
	{
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		if (CerberusConfig.LightSmooth.Enabled)
		{
			if (!bool_0)
			{
				color_0 = __result;
				bool_0 = true;
			}
			try
			{
				Vector4 fogColor = CerberusConfig.LightSmooth.FogColor;
				Vector4 tintColor = CerberusConfig.LightSmooth.TintColor;
				float brightness = CerberusConfig.LightSmooth.Brightness;
				float fogDensity = CerberusConfig.LightSmooth.FogDensity;
				Color val = __result;
				Color val2 = Color.FromSrgb(new Color(fogColor.X, fogColor.Y, fogColor.Z, fogColor.W));
				Color val3 = Color.FromSrgb(new Color(tintColor.X, tintColor.Y, tintColor.Z, tintColor.W));
				Color val4 = Color.InterpolateBetween(val, val2, fogDensity);
				((Color)(ref val4))._002Ector(val4.R * val3.R, val4.G * val3.G, val4.B * val3.B, val4.A);
				((Color)(ref val4))._002Ector(val4.R * brightness, val4.G * brightness, val4.B * brightness, val4.A);
				__result = val4;
				return;
			}
			catch (Exception)
			{
				return;
			}
		}
		if (bool_0)
		{
			__result = color_0;
		}
	}
}
