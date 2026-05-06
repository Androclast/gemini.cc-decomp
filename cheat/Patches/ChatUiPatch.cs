using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Content.Client.UserInterface.Systems.Chat;
using HarmonyLib;
using CerberusConfig;

[CompilerGenerated]
public sealed class ChatUiPatch
{
	private bool bool_0;

	private char char_1;

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

	private char Char_0
	{
		get
		{
			return char_1;
		}
		set
		{
			char_1 = value;
		}
	}

	private static MethodInfo TargetMethod()
	{
		return AccessTools.Method(typeof(ChatUIController), "OnDamageForceSay", (Type[])null, (Type[])null);
	}

	public static void Patch()
	{
		MethodInfo method = TargetMethod();
		MethodInfo method2 = NukePdaPatchHelper.GetMethod(typeof(ChatUiPatch), "Prefix");
		NukePdaPatchHelper.PatchMethod(method, method2, (HarmonyPatchType)1);
	}

	private static bool Prefix()
	{
		return !CerberusConfig.Settings.DamageForcePatch;
	}
}
