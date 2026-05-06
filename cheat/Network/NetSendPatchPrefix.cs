using System;
using System.Reflection;
using HarmonyLib;
using Robust.Shared.Network;
using PacketLogger;

namespace NetSendPatchPrefix;

[HarmonyPatch]
public class NetSendPatchPrefix
{
	private double double_0;

	private string string_0;

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

	private string String_1
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

	private static MethodBase TargetMethod()
	{
		try
		{
			Type typeFromHandle = typeof(NetManager);
			MethodInfo method = typeFromHandle.GetMethod("ProcessMessage", BindingFlags.Instance | BindingFlags.NonPublic);
			if (method == null)
			{
				method = typeFromHandle.GetMethod("HandleClientMessage", BindingFlags.Instance | BindingFlags.NonPublic);
			}
			_ = method != null;
			return method;
		}
		catch (Exception)
		{
			return null;
		}
	}

	private static void Prefix(NetMessage message)
	{
		try
		{
			if (message != null && PacketLogger.Enabled)
			{
				PacketLogger.LogIncomingPacket(message);
			}
		}
		catch (Exception)
		{
		}
	}
}
