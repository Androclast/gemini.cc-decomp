using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using HarmonyLib;
using Robust.Shared.GameObjects;
using CerberusConfig;

[CompilerGenerated]
public sealed class GenericPostfixPatch1
{
	private int int_1;

	private bool bool_0;

	private bool bool_1;

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
		return AccessTools.Method(typeof(EntitySystemManager), "GetEntitySystemTypes", (Type[])null, (Type[])null);
	}

	public static void Patch()
	{
		MethodInfo method = TargetMethod();
		MethodInfo method2 = NukePdaPatchHelper.GetMethod(typeof(GenericPostfixPatch1), "Postfix");
		NukePdaPatchHelper.PatchMethod(method, method2, (HarmonyPatchType)2);
	}

	private static void Postfix(ref IEnumerable<Type> __result)
	{
		CerberusConfig.NoSavedConfig.HasAntiCheat = true;
		List<Type> list = (from t in __result.ToList()
			where t.Namespace != null && AntiTamperWatchlists.hashSet_0.Any((string ns) => t.Namespace.StartsWith(ns))
			select t).ToList();
		__result = list;
	}
}
