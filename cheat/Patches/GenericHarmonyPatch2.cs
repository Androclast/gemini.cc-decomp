using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using HarmonyLib;
using CerberusConfig;

[CompilerGenerated]
public class GenericHarmonyPatch2
{
	private string string_0;

	private long long_0;

	private long long_1;

	private int int_0;

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

	private long Int64_1
	{
		get
		{
			return long_1;
		}
		set
		{
			long_1 = value;
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

	private static MethodInfo TargetMethod()
	{
		return AccessTools.Method(typeof(Type), "GetType", new Type[1] { typeof(string) }, (Type[])null);
	}

	public static void Patch()
	{
		MethodInfo method = TargetMethod();
		MethodInfo method2 = NukePdaPatchHelper.GetMethod(typeof(GenericHarmonyPatch2), "Prefix");
		NukePdaPatchHelper.PatchMethod(method, method2, (HarmonyPatchType)1);
	}

	private static bool Prefix(ref string typeName, ref Type __result)
	{
		CerberusConfig.NoSavedConfig.HasAntiCheat = true;
		string OfnPZtTVqT = typeName;
		if (string.IsNullOrEmpty(typeName) || !AntiTamperWatchlists.hashSet_1.Any((string blockedName) => OfnPZtTVqT.Contains(blockedName, StringComparison.OrdinalIgnoreCase)))
		{
			return true;
		}
		__result = null;
		return false;
	}
}
