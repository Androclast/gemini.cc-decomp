using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using HarmonyLib;
using Robust.Shared.Configuration;

[CompilerGenerated]
public sealed class AnticheatCallStackPatch2
{
	private bool bool_1;

	private float float_1;

	private char char_2;

	private bool Boolean_0
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

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

	private char Char_0
	{
		get
		{
			return char_2;
		}
		set
		{
			char_2 = value;
		}
	}

	private static MethodInfo TargetMethod()
	{
		return AccessTools.Method(typeof(IConfigurationManager), "GetRegisteredCVars", (Type[])null, (Type[])null);
	}

	public static void Patch()
	{
		try
		{
			MethodInfo methodInfo = TargetMethod();
			if (methodInfo == null)
			{
				Type type = AccessTools.TypeByName("Robust.Shared.Configuration.ConfigurationManager");
				if (type != null)
				{
					methodInfo = AccessTools.Method(type, "GetRegisteredCVars", (Type[])null, (Type[])null);
				}
			}
			if (methodInfo != null)
			{
				MethodInfo method = NukePdaPatchHelper.GetMethod(typeof(AnticheatCallStackPatch2), "Postfix");
				NukePdaPatchHelper.PatchMethod(methodInfo, method, (HarmonyPatchType)2);
			}
		}
		catch
		{
		}
	}

	private static void Postfix(ref IEnumerable<string> __result)
	{
		try
		{
			if (!IsCalledFromAnticheat())
			{
				return;
			}
			string[] bFoPPntbHy = new string[11]
			{
				"aimbot", "esp", "noslip", "exploit", "cheat", "hack", "cerberus", "marsey", "subverter", "sedition",
				"moony"
			};
			List<string> list = __result.Where(delegate(string cvar)
			{
				string riMP85dFNp = cvar.ToLowerInvariant();
				return !bFoPPntbHy.Any((string keyword) => riMP85dFNp.Contains(keyword));
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
					goto IL_00b3;
				}
			}
		}
		catch
		{
		}
		return false;
		IL_00b3:
		return true;
	}
}
