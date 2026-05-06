using System;
using Content.Client.Crayon.UI;
using Content.Shared.Crayon;
using HarmonyLib;
using Robust.Shared.GameObjects;
using CrayonInterfaceManager;

namespace CrayonUiPatch;

[HarmonyPatch]
public sealed class CrayonUiPatch
{
	private float float_0;

	private bool bool_1;

	private byte byte_0;

	private byte byte_1;

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

	private byte Byte_1
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

	[HarmonyPostfix]
	[HarmonyPatch(/*Could not decode attribute arguments.*/)]
	public static void CtorPostfix(CrayonBoundUserInterface __instance)
	{
		Logger.Debug("[AutoPainter] Crayon UI constructor hook triggered");
		CrayonInterfaceManager.RegisterInterface(__instance);
	}

	[HarmonyPostfix]
	[HarmonyPatch(typeof(CrayonBoundUserInterface), "Open")]
	public static void OpenPostfix(CrayonBoundUserInterface __instance)
	{
		CrayonInterfaceManager.RegisterInterface(__instance);
		Logger.Info("[AutoPainter] Crayon UI opened (Hook)");
	}

	[HarmonyPatch(typeof(CrayonBoundUserInterface), "UpdateState")]
	[HarmonyPostfix]
	public static void UpdateStatePostfix(CrayonBoundUserInterface __instance, BoundUserInterfaceState state)
	{
		Logger.Debug("[AutoPainter] Crayon UpdateState hook triggered");
		CrayonInterfaceManager.RegisterInterface(__instance);
		CrayonBoundUserInterfaceState val = (CrayonBoundUserInterfaceState)(object)((state is CrayonBoundUserInterfaceState) ? state : null);
		if (val != null)
		{
			CrayonInterfaceManager.OnStateUpdated(__instance, val);
		}
	}

	[HarmonyPatch(typeof(BoundUserInterface), "Dispose", new Type[] { })]
	[HarmonyPostfix]
	public static void DisposePostfix(BoundUserInterface __instance)
	{
		CrayonBoundUserInterface val = (CrayonBoundUserInterface)(object)((__instance is CrayonBoundUserInterface) ? __instance : null);
		if (val != null)
		{
			Logger.Debug("[AutoPainter] Crayon UI disposed (Hook)");
			CrayonInterfaceManager.UnregisterInterface(val);
		}
	}
}
