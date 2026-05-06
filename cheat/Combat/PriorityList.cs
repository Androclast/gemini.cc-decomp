using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Content.Shared.Mobs.Components;
using Content.Shared.Verbs;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Player;
using CerberusConfig;

[CompilerGenerated]
public sealed class PriorityList : EntitySystem
{
	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	private readonly Dictionary<ICommonSession, HashSet<EntityUid>> dictionary_0 = new Dictionary<ICommonSession, HashSet<EntityUid>>();

	private int int_0;

	private bool bool_0;

	private bool bool_1;

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

	private bool Boolean_0
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	private bool Boolean_1
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

	public override void Initialize()
	{
		((EntitySystem)this).SubscribeLocalEvent<GetVerbsEvent<AlternativeVerb>>((EntityEventHandler<GetVerbsEvent<AlternativeVerb>>)AddPriorityVerb, (Type[])null, (Type[])null);
	}

	public bool IsPriority(EntityUid entity)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		ICommonSession localSession = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
		if (localSession == null)
		{
			return false;
		}
		if (!dictionary_0.TryGetValue(localSession, out HashSet<EntityUid> value) || !value.Contains(entity))
		{
			ActorComponent val = default(ActorComponent);
			if (((EntitySystem)this).TryComp<ActorComponent>(entity, ref val))
			{
				string name = val.PlayerSession.Name;
				return CerberusConfig.list_1.Contains(name);
			}
			return false;
		}
		return true;
	}

	public void AddPriorityByCkey(string ckey)
	{
		if (!CerberusConfig.list_1.Contains(ckey))
		{
			CerberusConfig.list_1.Add(ckey);
		}
	}

	public void RemovePriorityByCkey(string ckey)
	{
		CerberusConfig.list_1.Remove(ckey);
	}

	private void AddPriorityVerb(GetVerbsEvent<AlternativeVerb> ev)
	{
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		if (ev.User == ev.Target || !((EntitySystem)this).HasComp<MobStateComponent>(ev.Target) || !((ISharedPlayerManager)iplayerManager_0).LocalEntity.HasValue || ev.User != ((ISharedPlayerManager)iplayerManager_0).LocalEntity.Value)
		{
			return;
		}
		ICommonSession localSession = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
		if (localSession == null)
		{
			return;
		}
		if (!dictionary_0.TryGetValue(localSession, out HashSet<EntityUid> PJ2TWlD2oC))
		{
			PJ2TWlD2oC = new HashSet<EntityUid>();
			dictionary_0[localSession] = PJ2TWlD2oC;
		}
		string text = (PJ2TWlD2oC.Contains(ev.Target) ? "Delete priority" : "Make priority");
		AlternativeVerb item = new AlternativeVerb
		{
			Act = delegate
			{
				//IL_0027: Unknown result type (might be due to invalid IL or missing references)
				//IL_000e: Unknown result type (might be due to invalid IL or missing references)
				if (!PJ2TWlD2oC.Add(ev.Target))
				{
					PJ2TWlD2oC.Remove(ev.Target);
				}
			},
			Text = text,
			Priority = 200
		};
		ev.Verbs.Add(item);
	}
}
