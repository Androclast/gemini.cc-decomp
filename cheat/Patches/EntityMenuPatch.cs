using System;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using CerberusConfig;

public sealed class EntityMenuPatch
{
	private float float_1;

	private string string_1;

	private string string_2;

	private float Single_0
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	private string String_0
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	private string String_1
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	private static IEnumerable<MethodInfo> TargetMethods()
	{
		Type adminManagerType = AccessTools.TypeByName("Content.Client.Administration.Managers.ClientAdminManager");
		if (adminManagerType != null)
		{
			MethodInfo methodInfo = AccessTools.Method(adminManagerType, "HasFlag", (Type[])null, (Type[])null);
			if (methodInfo != null)
			{
				yield return methodInfo;
			}
			MethodInfo methodInfo2 = AccessTools.PropertyGetter(adminManagerType, "IsActive");
			if (methodInfo2 != null)
			{
				yield return methodInfo2;
			}
			MethodInfo methodInfo3 = AccessTools.Method(adminManagerType, "CanCommand", (Type[])null, (Type[])null);
			if (methodInfo3 != null)
			{
				yield return methodInfo3;
			}
			MethodInfo methodInfo4 = AccessTools.Method(adminManagerType, "CanAdminPlace", (Type[])null, (Type[])null);
			if (methodInfo4 != null)
			{
				yield return methodInfo4;
			}
			MethodInfo methodInfo5 = AccessTools.Method(adminManagerType, "CanScript", (Type[])null, (Type[])null);
			if (methodInfo5 != null)
			{
				yield return methodInfo5;
			}
			MethodInfo methodInfo6 = AccessTools.Method(adminManagerType, "CanAdminMenu", (Type[])null, (Type[])null);
			if (methodInfo6 != null)
			{
				yield return methodInfo6;
			}
		}
		Type type = AccessTools.TypeByName("Content.Shared.Administration.Managers.SharedAdminManager");
		if (type != null)
		{
			MethodInfo methodInfo7 = AccessTools.Method(type, "HasFlag", (Type[])null, (Type[])null);
			if (methodInfo7 != null)
			{
				yield return methodInfo7;
			}
		}
		Type type2 = AccessTools.TypeByName("Robust.Client.Console.ClientConsoleHost");
		if (type2 != null)
		{
			MethodInfo methodInfo8 = AccessTools.Method(type2, "CanExecute", (Type[])null, (Type[])null);
			if (methodInfo8 != null)
			{
				yield return methodInfo8;
			}
		}
	}

	public static void Patch()
	{
		IEnumerable<MethodInfo> enumerable = TargetMethods();
		MethodInfo method = NukePdaPatchHelper.GetMethod(typeof(EntityMenuPatch), "Postfix");
		foreach (MethodInfo item in enumerable)
		{
			if (item != null)
			{
				NukePdaPatchHelper.PatchMethod(item, method, (HarmonyPatchType)2);
			}
		}
		try
		{
			Type type = AccessTools.TypeByName("Content.Client.ContextMenu.UI.EntityMenuElement");
			if (type != null)
			{
				MethodInfo methodInfo = AccessTools.Method(type, "GetEntityDescription", (Type[])null, (Type[])null);
				if (methodInfo != null)
				{
					MethodInfo method2 = NukePdaPatchHelper.GetMethod(typeof(EntityMenuPatch), "EntityMenuPostfix");
					NukePdaPatchHelper.PatchMethod(methodInfo, method2, (HarmonyPatchType)2);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private static void Postfix(ref bool __result)
	{
		if (CerberusConfig.Settings.AdminPatch)
		{
			__result = true;
		}
	}

	private static void EntityMenuPostfix(object entity, object __instance, ref string __result)
	{
		if (!CerberusConfig.Settings.AdminPatch)
		{
			return;
		}
		try
		{
			MethodInfo methodInfo = AccessTools.Method(__instance.GetType(), "GetEntityDescriptionAdmin", (Type[])null, (Type[])null);
			if (methodInfo != null)
			{
				object obj = methodInfo.Invoke(__instance, new object[1] { entity });
				if (obj != null)
				{
					__result = (string)obj;
				}
			}
		}
		catch
		{
		}
	}

	private string method_6(int int_0)
	{
		return "Хитролох_иди_нахуй._3____3___8_6__4_";
	}
}
