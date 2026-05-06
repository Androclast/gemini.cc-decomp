using System;
using Content.Client.PDA.Ringer;
using Robust.Shared.GameObjects;
using UplinkBruteforceEngine;

namespace PdaRingerUiPatch;

public sealed class PdaRingerUiPatch
{
	private float float_0;

	private long long_0;

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

	public static void CtorPostfix(RingerBoundUserInterface __instance)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Logger.Info($"[UplinkBruteforce] RingerBoundUserInterface CTOR. Owner={((BoundUserInterface)__instance).Owner}");
			UplinkBruteforceEngine.RegisterInterface(__instance);
		}
		catch (Exception ex)
		{
			Logger.Warn("[UplinkBruteforce] CtorPostfix error: " + ex.Message);
		}
	}

	public static void OpenPostfix(BoundUserInterface __instance)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			RingerBoundUserInterface val = (RingerBoundUserInterface)(object)((__instance is RingerBoundUserInterface) ? __instance : null);
			if (val != null)
			{
				Logger.Info($"[UplinkBruteforce] RingerBoundUserInterface OPENED. Owner={((BoundUserInterface)val).Owner}");
				UplinkBruteforceEngine.RegisterInterface(val);
			}
		}
		catch (Exception ex)
		{
			Logger.Warn("[UplinkBruteforce] OpenPostfix error: " + ex.Message);
		}
	}

	public static void UpdateStatePostfix(BoundUserInterface __instance, BoundUserInterfaceState state)
	{
		try
		{
			RingerBoundUserInterface val = (RingerBoundUserInterface)(object)((__instance is RingerBoundUserInterface) ? __instance : null);
			if (val != null)
			{
				UplinkBruteforceEngine.RegisterInterface(val);
				UplinkBruteforceEngine.OnUiUpdated(val);
			}
		}
		catch (Exception ex)
		{
			Logger.Warn("[UplinkBruteforce] UpdateStatePostfix error: " + ex.Message);
		}
	}

	public static void DisposePostfix(BoundUserInterface __instance)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			RingerBoundUserInterface val = (RingerBoundUserInterface)(object)((__instance is RingerBoundUserInterface) ? __instance : null);
			if (val != null)
			{
				Logger.Info($"[UplinkBruteforce] RingerBoundUserInterface DISPOSED. Owner={((BoundUserInterface)val).Owner}");
				UplinkBruteforceEngine.UnregisterInterface(val);
			}
		}
		catch (Exception ex)
		{
			Logger.Warn("[UplinkBruteforce] DisposePostfix error: " + ex.Message);
		}
	}
}
