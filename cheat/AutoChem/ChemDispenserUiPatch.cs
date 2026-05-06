using System;
using Content.Client.Chemistry.UI;
using Content.Shared.Chemistry;
using HarmonyLib;
using Robust.Shared.GameObjects;
using AutoChemCooker;

namespace ChemDispenserUiPatch;

[HarmonyPatch]
public sealed class ChemDispenserUiPatch
{
	private byte byte_1;

	private char char_0;

	private long long_0;

	private int int_1;

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

	[HarmonyPostfix]
	[HarmonyPatch(/*Could not decode attribute arguments.*/)]
	public static void CtorPostfix(ReagentDispenserBoundUserInterface __instance)
	{
		Logger.Info("[AutoChem] Constructor hook triggered");
		AutoChemCooker.RegisterInterface(__instance);
	}

	[HarmonyPostfix]
	[HarmonyPatch(typeof(ReagentDispenserBoundUserInterface), "Open")]
	public static void OpenPostfix(ReagentDispenserBoundUserInterface __instance)
	{
		AutoChemCooker.RegisterInterface(__instance);
		Logger.Info("[AutoChem] UI Opened (Hook).");
	}

	[HarmonyPatch(typeof(ReagentDispenserBoundUserInterface), "UpdateState")]
	[HarmonyPostfix]
	public static void UpdateStatePostfix(ReagentDispenserBoundUserInterface __instance, BoundUserInterfaceState state)
	{
		Logger.Debug("[AutoChem] UpdateState hook triggered");
		AutoChemCooker.RegisterInterface(__instance);
		ReagentDispenserBoundUserInterfaceState val = (ReagentDispenserBoundUserInterfaceState)(object)((state is ReagentDispenserBoundUserInterfaceState) ? state : null);
		if (val != null)
		{
			AutoChemCooker.OnStateUpdated(__instance, val);
		}
	}

	[HarmonyPatch(typeof(BoundUserInterface), "Dispose", new Type[] { })]
	[HarmonyPostfix]
	public static void DisposePostfix(BoundUserInterface __instance)
	{
		ReagentDispenserBoundUserInterface val = (ReagentDispenserBoundUserInterface)(object)((__instance is ReagentDispenserBoundUserInterface) ? __instance : null);
		if (val != null)
		{
			Logger.Info("[AutoChem] Dispenser UI Disposed (Hook)");
			AutoChemCooker.UnregisterInterface(val);
		}
	}
}
