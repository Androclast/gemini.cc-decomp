using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using HarmonyLib;
using Robust.Shared.GameObjects;

[CompilerGenerated]
public sealed class AnticheatCallStackPatch1
{
	private float float_0;

	private char char_0;

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

	private static MethodInfo TargetMethod()
	{
		return AccessTools.Method(typeof(EntityManager), "GetComponents", new Type[1] { typeof(EntityUid) }, (Type[])null);
	}

	public static void Patch()
	{
		try
		{
			MethodInfo methodInfo = TargetMethod();
			if (methodInfo != null)
			{
				MethodInfo method = NukePdaPatchHelper.GetMethod(typeof(AnticheatCallStackPatch1), "Postfix");
				NukePdaPatchHelper.PatchMethod(methodInfo, method, (HarmonyPatchType)2);
			}
		}
		catch
		{
		}
	}

	private static void Postfix(ref IEnumerable<IComponent> __result)
	{
		try
		{
			if (!IsCalledFromAnticheat())
			{
				return;
			}
			List<IComponent> list = __result.Where(delegate(IComponent comp)
			{
				Type type = ((object)comp).GetType();
				string OayP0dWd2j = type.Namespace ?? "";
				return AntiTamperWatchlists.hashSet_0.Any((string allowed) => OayP0dWd2j.StartsWith(allowed));
			}).ToList();
			__result = list;
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
				if (!(methodBase?.DeclaringType != null))
				{
					continue;
				}
				string text = methodBase.DeclaringType.FullName ?? "";
				if (text.Contains("AntiCheatChecks", StringComparison.OrdinalIgnoreCase) || text.Contains("Anticheat", StringComparison.OrdinalIgnoreCase))
				{
					goto IL_00af;
				}
			}
		}
		catch
		{
		}
		return false;
		IL_00af:
		return true;
	}

	private string method_10(byte byte_1, char char_1)
	{
		return "Хитролох_иди_нахуй.___6_____6";
	}
}
