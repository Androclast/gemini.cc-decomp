using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using HarmonyLib;

[CompilerGenerated]
public sealed class AnticheatCallStackPatch3
{
	private string string_1;

	private char char_0;

	private float float_0;

	private char char_1;

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

	private char Char_1
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
		Type type = AccessTools.TypeByName("Robust.Client.UserInterface.Controls.Control");
		if (!(type != null))
		{
			return null;
		}
		return AccessTools.PropertyGetter(type, "Children");
	}

	public static void Patch()
	{
		try
		{
			MethodInfo methodInfo = TargetMethod();
			if (methodInfo != null)
			{
				MethodInfo method = NukePdaPatchHelper.GetMethod(typeof(AnticheatCallStackPatch3), "Postfix");
				NukePdaPatchHelper.PatchMethod(methodInfo, method, (HarmonyPatchType)2);
			}
		}
		catch
		{
		}
	}

	private static void Postfix(object __instance, ref object __result)
	{
		try
		{
			if (!IsCalledFromAnticheat() || !__instance.GetType().Name.Contains("WindowRoot") || !(__result is IEnumerable enumerable))
			{
				return;
			}
			List<object> list = new List<object>();
			foreach (object item in enumerable)
			{
				if (item != null)
				{
					Type type = item.GetType();
					string OF3PhcAWBG = type.Namespace ?? "";
					if (AntiTamperWatchlists.hashSet_0.Any((string allowed) => OF3PhcAWBG.StartsWith(allowed)))
					{
						list.Add(item);
					}
				}
			}
			Type type2 = __result.GetType();
			if (!type2.IsGenericType)
			{
				return;
			}
			type2.GetGenericTypeDefinition();
			Type type3 = type2.GetGenericArguments()[0];
			Type type4 = typeof(List<>).MakeGenericType(type3);
			object obj = Activator.CreateInstance(type4);
			MethodInfo method = type4.GetMethod("Add");
			foreach (object item2 in list)
			{
				method?.Invoke(obj, new object[1] { item2 });
			}
			__result = obj;
		}
		catch
		{
		}
	}

	private static bool IsCalledFromAnticheat()
	{
		try
		{
			StackTrace stackTrace = new StackTrace();
			for (int i = 0; i < Math.Min(stackTrace.FrameCount, 15); i++)
			{
				MethodBase methodBase = stackTrace.GetFrame(i)?.GetMethod();
				if (methodBase?.DeclaringType != null)
				{
					string text = methodBase.DeclaringType.FullName ?? "";
					if (!text.Contains("AntiCheatChecks", StringComparison.OrdinalIgnoreCase) && !text.Contains("Anticheat", StringComparison.OrdinalIgnoreCase))
					{
						continue;
					}
					goto IL_00ab;
				}
			}
		}
		catch
		{
		}
		return false;
		IL_00ab:
		return true;
	}
}
