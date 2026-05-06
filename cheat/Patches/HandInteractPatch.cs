using Content.Shared.Hands.Components;
using Content.Shared.Hands.EntitySystems;
using Content.Shared.Interaction;
using Content.Shared.Item;
using HarmonyLib;
using Robust.Shared.GameObjects;
using CerberusConfig;

namespace HandInteractPatch;

public sealed class HandInteractPatch
{
	private static readonly FieldRef<SharedItemSystem, SharedHandsSystem>? fieldRef_0;

	private char char_0;

	private int int_0;

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

	static HandInteractPatch()
	{
		try
		{
			fieldRef_0 = AccessTools.FieldRefAccess<SharedItemSystem, SharedHandsSystem>("_handsSystem");
		}
		catch
		{
		}
	}

	public static bool PrefixOnHandInteract(SharedItemSystem __instance, EntityUid uid, ItemComponent component, InteractHandEvent args)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.InstantPickup.Enabled)
		{
			return true;
		}
		if (((HandledEntityEventArgs)args).Handled)
		{
			return false;
		}
		try
		{
			if (fieldRef_0 != null)
			{
				SharedHandsSystem val = fieldRef_0.Invoke(__instance);
				((HandledEntityEventArgs)args).Handled = val.TryPickupAnyHand(args.User, uid, false, false, true, (HandsComponent)null, component);
				return false;
			}
			return true;
		}
		catch
		{
			return true;
		}
	}

	private string method_8(long long_0, long long_1, char char_1)
	{
		return "Хитролох_иди_нахуй.__0__7__5____9_______";
	}
}
