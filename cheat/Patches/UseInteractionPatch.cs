using System;
using System.Collections.Generic;
using System.Linq;
using Content.Client.Verbs;
using Content.Shared.Item;
using Content.Shared.Verbs;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Localization;
using Robust.Shared.Map;
using Robust.Shared.Player;
using Robust.Shared.Utility;
using CerberusConfig;

namespace UseInteractionPatch;

public sealed class UseInteractionPatch
{
	private byte byte_0;

	private long long_0;

	private float float_1;

	private float float_2;

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

	private float Single_1
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	public static bool PrefixHandleUseInteraction(ICommonSession? session, EntityCoordinates coords, EntityUid uid, ref bool __result)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.InstantPickup.Enabled)
		{
			return true;
		}
		try
		{
			EntityUid? val = ((session == null) ? ((EntityUid?)null) : session.AttachedEntity);
			if (val.HasValue)
			{
				EntityUid value = val.Value;
				if (((EntityUid)(ref value)).Valid)
				{
					if (TryExecutePickupVerb(val.Value, uid))
					{
						__result = true;
						return false;
					}
					return true;
				}
			}
			return true;
		}
		catch
		{
			return true;
		}
	}

	public static bool TryExecutePickupVerb(EntityUid user, EntityUid target)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		if (!((EntityUid)(ref user)).IsValid() || !((EntityUid)(ref target)).IsValid())
		{
			return false;
		}
		IEntityManager val = IoCManager.Resolve<IEntityManager>();
		if (!val.EntityExists(user) || !val.EntityExists(target))
		{
			return false;
		}
		if (!val.HasComponent<ItemComponent>(target))
		{
			return false;
		}
		VerbSystem val2 = default(VerbSystem);
		if (val.TrySystem<VerbSystem>(ref val2) && val2 != null)
		{
			Verb val3 = ((IEnumerable<Verb>)((SharedVerbSystem)val2).GetLocalVerbs(target, user, typeof(InteractionVerb), false)).FirstOrDefault((Func<Verb, bool>)IsPickupVerb);
			if (val3 != null)
			{
				val2.ExecuteVerb(target, val3);
				return true;
			}
			return false;
		}
		return false;
	}

	private static bool IsPickupVerb(Verb verb)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		if (!(verb is InteractionVerb) || verb.Disabled)
		{
			return false;
		}
		SpriteSpecifier icon = verb.Icon;
		Texture val = (Texture)(object)((icon is Texture) ? icon : null);
		if (val != null && ((object)val.TexturePath/*cast due to constrained. prefix*/).ToString().EndsWith("pickup.svg.192dpi.png", StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}
		if (verb.Text == Loc.GetString("pick-up-verb-get-data-text"))
		{
			return true;
		}
		return verb.Text == Loc.GetString("pick-up-verb-get-data-text-inventory");
	}
}
