using System;
using Content.Client.Store.Ui;
using Robust.Shared.GameObjects;
using AntagAutoBuyEngine;

namespace AntagStoreUiPatch;

public sealed class AntagStoreUiPatch
{
	private double double_0;

	private byte byte_0;

	private int int_0;

	private int int_1;

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

	private int Int32_0
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	private int Int32_1
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

	public static void OpenPostfix(BoundUserInterface __instance)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			StoreBoundUserInterface val = (StoreBoundUserInterface)(object)((__instance is StoreBoundUserInterface) ? __instance : null);
			if (val != null)
			{
				Logger.Info($"[AutoBuy] StoreBoundUserInterface OPENED. Owner={((BoundUserInterface)val).Owner}");
				AntagAutoBuyEngine.RegisterInterface(val);
			}
		}
		catch (Exception ex)
		{
			Logger.Warn("[AutoBuy] OpenPostfix error: " + ex.Message);
		}
	}

	public static void UpdateStatePostfix(BoundUserInterface __instance, BoundUserInterfaceState state)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			StoreBoundUserInterface val = (StoreBoundUserInterface)(object)((__instance is StoreBoundUserInterface) ? __instance : null);
			if (val != null)
			{
				Logger.Info($"[AutoBuy] StoreBoundUserInterface UpdateState. Owner={((BoundUserInterface)val).Owner}");
				AntagAutoBuyEngine.OnStoreStateUpdated(val);
			}
		}
		catch (Exception ex)
		{
			Logger.Warn("[AutoBuy] UpdateStatePostfix error: " + ex.Message);
		}
	}

	public static void DisposePostfix(BoundUserInterface __instance)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			StoreBoundUserInterface val = (StoreBoundUserInterface)(object)((__instance is StoreBoundUserInterface) ? __instance : null);
			if (val != null)
			{
				Logger.Info($"[AutoBuy] StoreBoundUserInterface DISPOSED. Owner={((BoundUserInterface)val).Owner}");
				AntagAutoBuyEngine.UnregisterInterface(val);
			}
		}
		catch (Exception ex)
		{
			Logger.Warn("[AutoBuy] DisposePostfix error: " + ex.Message);
		}
	}
}
