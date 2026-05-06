using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using HarmonyLib;

[CompilerGenerated]
public sealed class GenericSealedPatch
{
	private byte byte_1;

	private string string_0;

	private byte Byte_0
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = value;
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

	private static MethodInfo TargetMethod()
	{
		Type type = AccessTools.TypeByName("Robust.Shared.Log.Log");
		if (type != null)
		{
			return AccessTools.Method(type, "Warning", new Type[1] { typeof(string) }, (Type[])null);
		}
		return null;
	}

	public static void Patch()
	{
		try
		{
			Type type = AccessTools.TypeByName("Robust.Shared.Log.Log");
			if (type == null)
			{
				return;
			}
			string[] array = new string[4] { "Warning", "Error", "Info", "Debug" };
			foreach (string text in array)
			{
				try
				{
					MethodInfo methodInfo = AccessTools.Method(type, text, new Type[1] { typeof(string) }, (Type[])null);
					if (methodInfo != null)
					{
						MethodInfo method = NukePdaPatchHelper.GetMethod(typeof(GenericSealedPatch), "Prefix");
						NukePdaPatchHelper.PatchMethod(methodInfo, method, (HarmonyPatchType)1);
					}
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
	}

	private static bool Prefix(string message)
	{
		try
		{
			if (string.IsNullOrEmpty(message))
			{
				return true;
			}
			string[] array = new string[12]
			{
				"Detected a patch metadata type", "Detected Moonyware", "Detected a type not from a Content module", "Detected an extra module", "Detected a suspicious cvar", "Detected extra types from EntitySystemManager", "Detected an extra component on player entity", "Detected extra UI window", "Running tests", "Offender:",
				"AntiCheat", "Anticheat"
			};
			foreach (string value in array)
			{
				if (message.Contains(value, StringComparison.OrdinalIgnoreCase))
				{
					return false;
				}
			}
		}
		catch
		{
		}
		return true;
	}
}
