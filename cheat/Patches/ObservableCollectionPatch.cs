using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using HarmonyLib;
using Robust.Shared.Reflection;
using CerberusConfig;

[CompilerGenerated]
public sealed class ObservableCollectionPatch
{
	private byte byte_0;

	private int int_0;

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
		return AccessTools.PropertyGetter(typeof(ReflectionManager), "Assemblies");
	}

	public static void Patch()
	{
		MethodInfo method = TargetMethod();
		MethodInfo method2 = NukePdaPatchHelper.GetMethod(typeof(ObservableCollectionPatch), "Postfix");
		NukePdaPatchHelper.PatchMethod(method, method2, (HarmonyPatchType)2);
	}

	private static void Postfix(ref IReadOnlyList<Assembly> __result)
	{
		CerberusConfig.NoSavedConfig.HasAntiCheat = true;
		ReadOnlyCollection<Assembly> readOnlyCollection = __result.Where((Assembly a) => a.GetName().Name != null && AntiTamperWatchlists.hashSet_0.Contains(a.GetName().Name)).ToList().AsReadOnly();
		__result = readOnlyCollection;
	}
}
