using System;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;

namespace ClientReporterPatches;

public sealed class ClientReporterPatches
{
	private static Type type_0;

	private static bool bool_0 = false;

	private static readonly string[] string_0 = new string[14]
	{
		"harmony", "harmonylib", "minhook", "imgui", "cimgui", "imguiimpl", "hexa", "cerberus", "marsey", "sedition",
		"subverter", "teal", "0harmony", "minHook.net"
	};

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

	public static void Patch()
	{
		if (bool_0)
		{
			return;
		}
		try
		{
			type_0 = AccessTools.TypeByName("Content.Client._RMC14.Weapons.RMCWeaponGun");
			if (!(type_0 == null))
			{
				PatchSendBurstSnapshot();
				PatchTryReportRangeSpread();
				PatchTryReportSightSpread();
				PatchOnSignalFrameRequest();
				bool_0 = true;
			}
		}
		catch
		{
		}
	}

	private static void PatchSendBurstSnapshot()
	{
		MethodInfo methodInfo = AccessTools.Method(type_0, "SendBurstSnapshot", (Type[])null, (Type[])null);
		if (!(methodInfo == null))
		{
			MethodInfo patch = AccessTools.Method(typeof(ClientReporterPatches), "SendBurstSnapshotPrefix", (Type[])null, (Type[])null);
			NukePdaPatchHelper.PatchMethod(methodInfo, patch, (HarmonyPatchType)1);
		}
	}

	private static void PatchTryReportRangeSpread()
	{
		MethodInfo methodInfo = AccessTools.Method(type_0, "TryReportRangeSpread", (Type[])null, (Type[])null);
		if (!(methodInfo == null))
		{
			MethodInfo patch = AccessTools.Method(typeof(ClientReporterPatches), "BlockMethodPrefix", (Type[])null, (Type[])null);
			NukePdaPatchHelper.PatchMethod(methodInfo, patch, (HarmonyPatchType)1);
		}
	}

	private static void PatchTryReportSightSpread()
	{
		MethodInfo methodInfo = AccessTools.Method(type_0, "TryReportSightSpread", (Type[])null, (Type[])null);
		if (!(methodInfo == null))
		{
			MethodInfo patch = AccessTools.Method(typeof(ClientReporterPatches), "BlockMethodPrefix", (Type[])null, (Type[])null);
			NukePdaPatchHelper.PatchMethod(methodInfo, patch, (HarmonyPatchType)1);
		}
	}

	private static void PatchOnSignalFrameRequest()
	{
		MethodInfo methodInfo = AccessTools.Method(type_0, "OnSignalFrameRequest", (Type[])null, (Type[])null);
		if (!(methodInfo == null))
		{
			MethodInfo patch = AccessTools.Method(typeof(ClientReporterPatches), "BlockMethodPrefix", (Type[])null, (Type[])null);
			NukePdaPatchHelper.PatchMethod(methodInfo, patch, (HarmonyPatchType)1);
		}
	}

	private static bool SendBurstSnapshotPrefix(object __instance)
	{
		try
		{
			FieldInfo fieldInfo = AccessTools.Field(type_0, "_burstSeed");
			FieldInfo fieldInfo2 = AccessTools.Field(type_0, "_burstSequence");
			if (fieldInfo == null || fieldInfo2 == null)
			{
				return true;
			}
			int num = (int)fieldInfo.GetValue(__instance);
			int num2 = (int)fieldInfo2.GetValue(__instance);
			List<string> list = BuildCleanManagedModules();
			List<string> list2 = new List<string>();
			List<string> list3 = new List<string>();
			string buildVersion = GetBuildVersion(__instance);
			Type type = AccessTools.TypeByName("Content.Shared._RMC14.Weapons.PubgTelemetryPulseEvent");
			if (type == null)
			{
				return true;
			}
			object obj = type.GetConstructors()[0].Invoke(new object[11]
			{
				num, num2, buildVersion, false, 0, list.Count, 0, list3.Count, list, list2,
				list3
			});
			MethodInfo methodInfo = (MethodInfo)(((ClientReporterPatches)(object)AccessTools.TypeByName("Robust.Shared.GameObjects.EntitySystem"))?.method_0("RaiseNetworkEvent", BindingFlags.Instance | BindingFlags.NonPublic, (object)null, new Type[1] { AccessTools.TypeByName("Robust.Shared.GameObjects.EntityEventArgs") }, (ParameterModifier[])null));
			if (methodInfo != null)
			{
				methodInfo.Invoke(__instance, new object[1] { obj });
			}
			fieldInfo2.SetValue(__instance, num2 + 1);
			return false;
		}
		catch
		{
			return true;
		}
	}

	private static List<string> BuildCleanManagedModules()
	{
		List<string> list = new List<string>();
		string[] array = new string[5] { "Content.Client", "Content.Shared", "Content.Shared.Database", "Robust.Client", "Robust.Shared" };
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		foreach (Assembly assembly in assemblies)
		{
			string name;
			try
			{
				name = assembly.GetName().Name;
			}
			catch
			{
				continue;
			}
			if (string.IsNullOrWhiteSpace(name) || IsSuspiciousModule(name))
			{
				continue;
			}
			string[] array2 = array;
			foreach (string value in array2)
			{
				if (name.StartsWith(value, StringComparison.OrdinalIgnoreCase))
				{
					if (!ContainsCI(list, name))
					{
						list.Add(name);
					}
					break;
				}
			}
		}
		list.Sort(StringComparer.OrdinalIgnoreCase);
		return list;
	}

	private static string GetBuildVersion(object instance)
	{
		try
		{
			MethodInfo methodInfo = AccessTools.Method(type_0, "GetBuildVersion", (Type[])null, (Type[])null);
			if (methodInfo != null)
			{
				return (string)methodInfo.Invoke(instance, null);
			}
		}
		catch
		{
		}
		return "unknown";
	}

	private static bool IsSuspiciousModule(string name)
	{
		string[] array = string_0;
		int num = 0;
		while (true)
		{
			if (num >= array.Length)
			{
				return false;
			}
			string value = array[num];
			if (name.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0)
			{
				break;
			}
			num++;
		}
		return true;
	}

	private static bool ContainsCI(List<string> list, string value)
	{
		foreach (string item in list)
		{
			if (!string.Equals(item, value, StringComparison.OrdinalIgnoreCase))
			{
				continue;
			}
			goto IL_003a;
		}
		return false;
		IL_003a:
		return true;
	}

	public object method_0(string string_1, BindingFlags bindingFlags_0, object object_3, Type[] type_1, ParameterModifier[] parameterModifier_0)
	{
		return ((Type)this).GetMethod(string_1, bindingFlags_0, (Binder?)object_3, type_1, parameterModifier_0);
	}
}
