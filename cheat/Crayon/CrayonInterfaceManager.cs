using System;
using System.Collections.Generic;
using System.Linq;
using Content.Client.Crayon.UI;
using Content.Shared.Crayon;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;

namespace CrayonInterfaceManager;

public sealed class CrayonInterfaceManager
{
	public static HashSet<CrayonBoundUserInterface> hashSet_0 = new HashSet<CrayonBoundUserInterface>();

	public static Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

	public static string? string_0 = null;

	private float float_0;

	private byte byte_0;

	private string string_1;

	private float float_1;

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

	private string String_0
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

	private float Single_1
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

	public static void RegisterInterface(CrayonBoundUserInterface ui)
	{
		if (ui != null && !hashSet_0.Contains(ui))
		{
			hashSet_0.Add(ui);
			Logger.Info($"[AutoPainter] Tracking crayon UI. Total: {hashSet_0.Count}");
		}
	}

	public static void UnregisterInterface(CrayonBoundUserInterface ui)
	{
		hashSet_0.Remove(ui);
	}

	public static void OnStateUpdated(CrayonBoundUserInterface ui, CrayonBoundUserInterfaceState state)
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		string_0 = state.Selected;
		Logger.Debug($"[AutoPainter] Crayon state updated: Selected={state.Selected}, Color={state.Color}");
	}

	public static CrayonBoundUserInterface? GetActiveUi()
	{
		hashSet_0.RemoveWhere((CrayonBoundUserInterface ui) => ui == null || IsDisposed((BoundUserInterface)(object)ui));
		CrayonBoundUserInterface? obj = hashSet_0.FirstOrDefault();
		if (obj == null)
		{
			Logger.Debug($"[AutoPainter] No active crayon UI found. Known interfaces: {hashSet_0.Count}");
		}
		return obj;
	}

	private static bool IsDisposed(BoundUserInterface ui)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			return !IoCManager.Resolve<IEntityManager>().EntityExists(ui.Owner);
		}
		catch
		{
			return true;
		}
	}

	public static bool SelectDecal(string decalId)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		CrayonBoundUserInterface activeUi = GetActiveUi();
		if (activeUi == null)
		{
			Logger.Warn("[AutoPainter] Cannot select decal: UI not found");
			return false;
		}
		try
		{
			((BoundUserInterface)activeUi).SendMessage((BoundUserInterfaceMessage)new CrayonSelectMessage(decalId));
			string_0 = decalId;
			Logger.Debug("[AutoPainter] Selected decal: " + decalId);
			return true;
		}
		catch (Exception ex)
		{
			Logger.Error("[AutoPainter] Failed to select decal: " + ex.Message);
			return false;
		}
	}
}
