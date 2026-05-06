using System;
using Content.Client.Nuke;
using Content.Shared.Nuke;
using Robust.Shared.GameObjects;
using NukeBruteforceEngine;

namespace NukeUiPatch;

public sealed class NukeUiPatch
{
	private float float_1;

	private char char_0;

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
			return char_0;
		}
		set
		{
			char_0 = value;
		}
	}

	public static void CtorPostfix(NukeBoundUserInterface __instance)
	{
		try
		{
			NukeBruteforceEngine.RegisterInterface(__instance);
		}
		catch (Exception)
		{
		}
	}

	public static void OpenPostfix(BoundUserInterface __instance)
	{
		try
		{
			NukeBoundUserInterface val = (NukeBoundUserInterface)(object)((__instance is NukeBoundUserInterface) ? __instance : null);
			if (val != null)
			{
				NukeBruteforceEngine.RegisterInterface(val);
			}
		}
		catch (Exception)
		{
		}
	}

	public static void UpdateStatePostfix(BoundUserInterface __instance, BoundUserInterfaceState state)
	{
		try
		{
			NukeBoundUserInterface val = (NukeBoundUserInterface)(object)((__instance is NukeBoundUserInterface) ? __instance : null);
			if (val != null)
			{
				NukeUiState val2 = (NukeUiState)(object)((state is NukeUiState) ? state : null);
				if (val2 != null)
				{
					NukeBruteforceEngine.RegisterInterface(val);
					NukeBruteforceEngine.OnStateUpdated(val, val2);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public static void DisposePostfix(BoundUserInterface __instance)
	{
		try
		{
			NukeBoundUserInterface val = (NukeBoundUserInterface)(object)((__instance is NukeBoundUserInterface) ? __instance : null);
			if (val != null)
			{
				NukeBruteforceEngine.UnregisterInterface(val);
			}
		}
		catch (Exception)
		{
		}
	}
}
