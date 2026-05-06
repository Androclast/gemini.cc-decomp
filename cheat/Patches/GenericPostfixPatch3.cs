using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using HarmonyLib;
using Robust.Shared.Reflection;
using CerberusConfig;

[CompilerGenerated]
public sealed class GenericPostfixPatch3
{
	private byte byte_1;

	private float float_0;

	private double double_0;

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

	private static MethodInfo TargetMethod()
	{
		return AccessTools.Method(typeof(ReflectionManager), "FindAllTypes", (Type[])null, (Type[])null);
	}

	public static void Patch()
	{
		MethodInfo method = TargetMethod();
		MethodInfo method2 = NukePdaPatchHelper.GetMethod(typeof(GenericPostfixPatch3), "Postfix");
		NukePdaPatchHelper.PatchMethod(method, method2, (HarmonyPatchType)2);
	}

	private static void Postfix(ref IEnumerable<Type> __result)
	{
		CerberusConfig.NoSavedConfig.HasAntiCheat = true;
		List<Type> list = (from t in __result.ToList()
			where !AntiTamperWatchlists.hashSet_1.Any((string blockedName) => t.Name.Contains(blockedName, StringComparison.OrdinalIgnoreCase))
			select t).ToList();
		__result = list;
	}

	private string method_5(bool bool_1)
	{
		return "Хитролох_иди_нахуй.___4____7___84_2_1";
	}
}
