using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using HarmonyLib;
using Robust.Shared.GameObjects;

[CompilerGenerated]
public sealed class GenericGameObjectPatch
{
	private string string_0;

	private int int_1;

	private long long_1;

	private float float_0;

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

	private long Int64_0
	{
		get
		{
			return long_1;
		}
		set
		{
			long_1 = value;
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

	private static MethodInfo TargetMethod()
	{
		return AccessTools.Method(typeof(EntitySystem), "SubscribeNetworkEvent", (Type[])null, (Type[])null);
	}

	public static void Patch()
	{
		try
		{
			MethodInfo[] methods = typeof(EntitySystem).GetMethods(BindingFlags.Instance | BindingFlags.Public);
			foreach (MethodInfo methodInfo in methods)
			{
				if (methodInfo.Name == "SubscribeNetworkEvent")
				{
					try
					{
						MethodInfo method = NukePdaPatchHelper.GetMethod(typeof(GenericGameObjectPatch), "Prefix");
						NukePdaPatchHelper.PatchMethod(methodInfo, method, (HarmonyPatchType)1);
					}
					catch
					{
					}
				}
			}
		}
		catch
		{
		}
	}

	private static bool Prefix(object __instance, object handler)
	{
		try
		{
			Type type = __instance.GetType();
			string text = type.FullName ?? type.Name;
			string[] array = new string[4] { "AntiCheatChecks", "JoinReplySystem", "ScreengrabSystem", "Anticheat" };
			foreach (string value in array)
			{
				if (text.Contains(value, StringComparison.OrdinalIgnoreCase))
				{
					return false;
				}
			}
			if (handler != null)
			{
				Type type2 = handler.GetType();
				if (type2.IsGenericType)
				{
					Type[] genericArguments = type2.GetGenericArguments();
					if (genericArguments.Length != 0)
					{
						Type type3 = genericArguments[0];
						string text2 = type3.FullName ?? type3.Name;
						array = new string[4] { "AnticheatJoinReqEvent", "AnticheatJoinRespEvent", "ScreengrabRequestEvent", "ScreengrabResponseEvent" };
						foreach (string value2 in array)
						{
							if (text2.Contains(value2, StringComparison.OrdinalIgnoreCase))
							{
								return false;
							}
						}
					}
				}
			}
		}
		catch
		{
		}
		return true;
	}
}
