using System;
using System.Reflection;
using HarmonyLib;
using Robust.Shared.Network;
using PacketLogger;

namespace NetMessagePatchPrefix;

[HarmonyPatch]
public class NetMessagePatchPrefix
{
	private string string_0;

	private byte byte_1;

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

	private static MethodBase TargetMethod()
	{
		return typeof(NetManager).GetMethod("ClientSendMessage", BindingFlags.Instance | BindingFlags.Public);
	}

	private static void Prefix(NetMessage message)
	{
		try
		{
			if (message != null && PacketLogger.Enabled)
			{
				PacketLogger.LogOutgoingPacket(message);
			}
		}
		catch (Exception)
		{
		}
	}
}
