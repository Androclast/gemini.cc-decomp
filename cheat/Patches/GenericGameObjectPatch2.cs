using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using HarmonyLib;
using Robust.Shared.GameObjects;

[CompilerGenerated]
public sealed class GenericGameObjectPatch2
{
	private float float_0;

	private int int_1;

	private float float_1;

	private double double_0;

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

	private float Single_1
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

	private static MethodInfo TargetMethod()
	{
		return AccessTools.Method(typeof(EntitySystem), "Initialize", (Type[])null, (Type[])null);
	}

	public static void Patch()
	{
		try
		{
			MethodInfo methodInfo = TargetMethod();
			if (methodInfo != null)
			{
				MethodInfo method = NukePdaPatchHelper.GetMethod(typeof(GenericGameObjectPatch2), "Prefix");
				NukePdaPatchHelper.PatchMethod(methodInfo, method, (HarmonyPatchType)1);
			}
		}
		catch
		{
		}
	}

	private static bool Prefix(EntitySystem __instance)
	{
		try
		{
			Type type = ((object)__instance).GetType();
			string text = type.FullName ?? type.Name;
			string[] array = new string[4] { "AntiCheatChecks", "JoinReplySystem", "ScreengrabSystem", "Content.Anticheat" };
			int num = 0;
			while (num < array.Length)
			{
				string value = array[num];
				if (!text.Contains(value, StringComparison.OrdinalIgnoreCase))
				{
					num++;
					continue;
				}
				Console.WriteLine("[AnticheatBlocker] Blocked initialization of: " + text);
				goto IL_00b6;
			}
		}
		catch
		{
		}
		return true;
		IL_00b6:
		return false;
	}
}
