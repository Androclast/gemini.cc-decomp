using System;
using System.Reflection;
using HarmonyLib;
using Robust.Shared.Network;
using PacketLogger;

namespace NetMessagePatchPostfix;

[HarmonyPatch]
public class NetMessagePatchPostfix
{
	private long long_0;

	private bool bool_1;

	private float float_0;

	private long Int64_0
	{
		get
		{
			return long_0;
		}
		set
		{
			long_0 = value;
		}
	}

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
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	private static MethodBase TargetMethod()
	{
		ConstructorInfo[] constructors = typeof(NetMessage).GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		if (0 < constructors.Length)
		{
			return constructors[0];
		}
		return null;
	}

	private static void Postfix(NetMessage __instance)
	{
		try
		{
			if (__instance != null)
			{
				_ = PacketLogger.Enabled;
			}
		}
		catch (Exception)
		{
		}
	}
}
