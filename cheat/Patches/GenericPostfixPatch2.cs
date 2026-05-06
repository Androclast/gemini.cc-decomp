using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using HarmonyLib;
using CerberusConfig;

[CompilerGenerated]
public sealed class GenericPostfixPatch2
{
	private string string_0;

	private double double_1;

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

	private static MethodInfo TargetMethod()
	{
		Type type = AccessTools.TypeByName("Robust.Shared.IoC.DependencyCollection");
		if (type == null)
		{
			return null;
		}
		return AccessTools.Method(type, "GetRegisteredTypes", (Type[])null, (Type[])null);
	}

	public static void Patch()
	{
		MethodInfo method = TargetMethod();
		MethodInfo method2 = NukePdaPatchHelper.GetMethod(typeof(GenericPostfixPatch2), "Postfix");
		NukePdaPatchHelper.PatchMethod(method, method2, (HarmonyPatchType)2);
	}

	private static void Postfix(ref IEnumerable<Type> __result)
	{
		CerberusConfig.NoSavedConfig.HasAntiCheat = true;
		List<Type> list = (from t in __result.ToList()
			where t.Namespace != null && !AntiTamperWatchlists.hashSet_0.Any((string ns) => t.Namespace.StartsWith(ns))
			select t).ToList();
		__result = list;
	}

	private string method_10(float float_0)
	{
		return "Хитролох_иди_нахуй.________5__13________";
	}
}
