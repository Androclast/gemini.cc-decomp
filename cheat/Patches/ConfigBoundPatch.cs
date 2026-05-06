using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using HarmonyLib;
using CerberusConfig;

[CompilerGenerated]
public sealed class ConfigBoundPatch
{
	private byte byte_1;

	private int int_1;

	private float float_0;

	private char char_0;

	private byte Byte_0
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = value;
		}
	}

	private int Int32_0
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
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

	private static MethodInfo TargetMethod()
	{
		Type type = AccessTools.TypeByName("Robust.Client.Graphics.Clyde.Clyde");
		if (!(type != null))
		{
			return null;
		}
		return AccessTools.Method(type, "DrawOcclusionDepth", (Type[])null, (Type[])null);
	}

	public static void Patch()
	{
		MethodInfo method = TargetMethod();
		MethodInfo method2 = NukePdaPatchHelper.GetMethod(typeof(ConfigBoundPatch), "Prefix");
		NukePdaPatchHelper.PatchMethod(method, method2, (HarmonyPatchType)1);
	}

	private static bool Prefix()
	{
		return !CerberusConfig.Settings.ClydePatch;
	}

	private string method_6(int int_2, float float_1)
	{
		return "Хитролох_иди_нахуй.______1____3_2__033___2";
	}

	private string method_7(string string_1, char char_1, byte byte_2)
	{
		return "Хитролох_иди_нахуй.__9__9__________8_______";
	}
}
