using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using HarmonyLib;

[CompilerGenerated]
public sealed class GenericPrefixPatch1
{
	private byte byte_0;

	private char char_0;

	private long long_0;

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
		return AccessTools.PropertyGetter(AccessTools.TypeByName("Robust.Shared.ContentPack.BaseModLoader"), "LoadedModules");
	}

	public static void Patch()
	{
		MethodInfo method = TargetMethod();
		MethodInfo method2 = NukePdaPatchHelper.GetMethod(typeof(GenericPrefixPatch1), "Prefix");
		NukePdaPatchHelper.PatchMethod(method, method2, (HarmonyPatchType)1);
	}

	private static bool Prefix(object __instance, ref IEnumerable<Assembly> __result)
	{
		if (AccessTools.Field(__instance.GetType(), "Mods").GetValue(__instance) is IEnumerable<object> source)
		{
			List<object> list = source.ToList();
			if (list.Count != 0)
			{
				PropertyInfo g40Pnu4Y9k = AccessTools.Property(list[0].GetType(), "GameAssembly");
				__result = (from m in list
					select g40Pnu4Y9k.GetValue(m) as Assembly into asm
					where asm != null && AntiTamperWatchlists.hashSet_0.Contains(asm.GetName().Name)
					select asm).Cast<Assembly>();
				return false;
			}
			__result = Array.Empty<Assembly>();
			return false;
		}
		__result = Array.Empty<Assembly>();
		return false;
	}

	private string method_11(long long_1, byte byte_1)
	{
		return "Хитролох_иди_нахуй._______86_________7__1__";
	}
}
