using System;
using System.Reflection;
using HarmonyLib;

namespace ClientCommandPatch;

[HarmonyPatch]
internal sealed class ClientCommandPatch
{
	private double double_0;

	private int int_0;

	private bool bool_0;

	private string string_1;

	private double Double_0
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
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

	[HarmonyTargetMethod]
	private static MethodBase TargetMethod()
	{
		return AccessTools.Method(AccessTools.TypeByName("Robust.Client.Console.ClientConsoleHost"), "CanExecute", (Type[])null, (Type[])null);
	}

	[HarmonyPostfix]
	private static void Postfix(ref bool __result)
	{
		__result = true;
	}
}
