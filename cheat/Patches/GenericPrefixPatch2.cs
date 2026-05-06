using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using HarmonyLib;
using CerberusConfig;

[CompilerGenerated]
public sealed class GenericPrefixPatch2
{
	private float float_0;

	private bool bool_2;

	private string string_0;

	private long long_0;

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

	private static MethodInfo TargetMethod()
	{
		return AccessTools.PropertyGetter(AccessTools.TypeByName("Robust.Shared.Reflection.ReflectionManager"), "Assemblies");
	}

	public static void Patch()
	{
		MethodInfo method = TargetMethod();
		MethodInfo method2 = NukePdaPatchHelper.GetMethod(typeof(GenericPrefixPatch2), "Prefix");
		NukePdaPatchHelper.PatchMethod(method, method2, (HarmonyPatchType)1);
	}

	private static bool Prefix(object __instance, ref IReadOnlyList<Assembly> __result)
	{
		CerberusConfig.NoSavedConfig.HasAntiCheat = true;
		FieldInfo fieldInfo = AccessTools.Field(__instance.GetType(), "assemblies");
		if (((fieldInfo != null) ? fieldInfo.GetValue(__instance) : null) is List<Assembly> source)
		{
			ReadOnlyCollection<Assembly> readOnlyCollection = source.Where(delegate(Assembly a)
			{
				string name = a.GetName().Name;
				return name != null && !AntiTamperWatchlists.hashSet_0.Contains(name);
			}).ToList().AsReadOnly();
			__result = readOnlyCollection;
			return false;
		}
		__result = Array.Empty<Assembly>();
		return false;
	}
}
