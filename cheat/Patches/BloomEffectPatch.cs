using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using HarmonyLib;

[CompilerGenerated]
public sealed class BloomEffectPatch
{
	private bool bool_1;

	private byte byte_0;

	private double double_1;

	private long long_0;

	private bool Boolean_0
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

	private long Int64_0
	{
		get
		{
			return long_0;
		}
		set
		{
			long_0 = value;
		}
	}

	private static MethodInfo GetBloomMethod()
	{
		Type type = AccessTools.TypeByName("Robust.Client.Graphics.Clyde.Clyde");
		if (type == null)
		{
			return null;
		}
		foreach (MethodInfo declaredMethod in AccessTools.GetDeclaredMethods(type))
		{
			if (!declaredMethod.Name.Contains("Bloom"))
			{
				declaredMethod.Name.Contains("PostProcess");
			}
		}
		return null;
	}

	public static void Patch()
	{
		GetBloomMethod();
	}
}
