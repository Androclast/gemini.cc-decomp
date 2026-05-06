using System;
using HarmonyLib;
using Robust.Shared.Network;
using PacketLogger;

namespace NetSendPatchPostfix;

[HarmonyPatch(typeof(NetMessage), "ReadFromBuffer")]
public class NetSendPatchPostfix
{
	private byte byte_0;

	private double double_0;

	private byte Byte_0
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
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

	private static void Postfix(NetMessage __instance)
	{
		try
		{
			if (__instance != null && PacketLogger.Enabled)
			{
				PacketLogger.LogIncomingPacket(__instance);
			}
		}
		catch (Exception)
		{
		}
	}
}
