using System;
using System.Reflection;
using HarmonyLib;
using CerberusConfig;

namespace ShowRulesPatch;

[HarmonyPatch]
public sealed class ShowRulesPatch
{
	private static bool bool_0;

	private byte byte_0;

	private double double_1;

	private string string_0;

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

	public static void ApplyPatch(Harmony harmony)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		if (bool_0)
		{
			return;
		}
		try
		{
			Type type = AccessTools.TypeByName("Content.Client.UserInterface.Systems.Info.InfoUIController");
			if (!(type == null))
			{
				MethodInfo methodInfo = AccessTools.Method(type, "ShowRules", (Type[])null, (Type[])null);
				if (!(methodInfo == null))
				{
					MethodInfo methodInfo2 = AccessTools.Method(typeof(ShowRulesPatch), "ShowRulesPrefix", (Type[])null, (Type[])null);
					harmony.Patch((MethodBase)methodInfo, new HarmonyMethod(methodInfo2), (HarmonyMethod)null, (HarmonyMethod)null, (HarmonyMethod)null);
					bool_0 = true;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private static bool ShowRulesPrefix(object __instance, float time)
	{
		try
		{
			if (!CerberusConfig.Misc.AutoFuckRulesEnabled)
			{
				return true;
			}
			if (CerberusConfig.Misc.AutoFuckRulesMode == 1)
			{
				FieldInfo field = __instance.GetType().GetField("_rulesPopup", BindingFlags.Instance | BindingFlags.NonPublic);
				if (!(field != null) || field.GetValue(__instance) == null)
				{
					MethodInfo method = __instance.GetType().GetMethod("OnAcceptPressed", BindingFlags.Instance | BindingFlags.NonPublic);
					if (method != null)
					{
						method.Invoke(__instance, null);
					}
					return false;
				}
				return false;
			}
			return true;
		}
		catch (Exception)
		{
			return true;
		}
	}
}
