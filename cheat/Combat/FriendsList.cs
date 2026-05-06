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
public sealed class FriendsList : EntitySystem
{
	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	private readonly Dictionary<ICommonSession, HashSet<EntityUid>> dictionary_0 = new Dictionary<ICommonSession, HashSet<EntityUid>>();

	private int int_0;

	private int int_1;

	private int int_2;

	private float float_1;

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

	private int Int32_2
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
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

	public override void Initialize()
	{
		((EntitySystem)this).SubscribeLocalEvent<GetVerbsEvent<AlternativeVerb>>((EntityEventHandler<GetVerbsEvent<AlternativeVerb>>)AddFriendVerb, (Type[])null, (Type[])null);
	}

	public bool IsFriend(EntityUid entity)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		ICommonSession localSession = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
		if (localSession == null)
		{
			return false;
		}
		if (dictionary_0.TryGetValue(localSession, out HashSet<EntityUid> value) && value.Contains(entity))
		{
			return true;
		}
		ActorComponent val = default(ActorComponent);
		if (!((EntitySystem)this).TryComp<ActorComponent>(entity, ref val))
		{
			return false;
		}
		string name = val.PlayerSession.Name;
		return CerberusConfig.list_0.Contains(name);
	}

	public void AddFriendByCkey(string ckey)
	{
		if (!CerberusConfig.list_0.Contains(ckey))
		{
			CerberusConfig.list_0.Add(ckey);
		}
	}

	public void RemoveFriendByCkey(string ckey)
	{
		CerberusConfig.list_0.Remove(ckey);
	}

	private void AddFriendVerb(GetVerbsEvent<AlternativeVerb> ev)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		if (ev.User == ev.Target || !((EntitySystem)this).HasComp<MobStateComponent>(ev.Target) || !((ISharedPlayerManager)iplayerManager_0).LocalEntity.HasValue || ev.User != ((ISharedPlayerManager)iplayerManager_0).LocalEntity.Value)
		{
			return;
		}
		ICommonSession localSession = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
		if (localSession == null)
		{
			return;
		}
		if (!dictionary_0.TryGetValue(localSession, out HashSet<EntityUid> CBZTaHy2Th))
		{
			CBZTaHy2Th = new HashSet<EntityUid>();
			dictionary_0[localSession] = CBZTaHy2Th;
		}
		string text = (CBZTaHy2Th.Contains(ev.Target) ? "Delete friend" : "Make friend");
		AlternativeVerb item = new AlternativeVerb
		{
			Act = delegate
			{
				//IL_000c: Unknown result type (might be due to invalid IL or missing references)
				//IL_002b: Unknown result type (might be due to invalid IL or missing references)
				if (!CBZTaHy2Th.Add(ev.Target))
				{
					CBZTaHy2Th.Remove(ev.Target);
				}
			},
			Text = text,
			Priority = 200
		};
		ev.Verbs.Add(item);
	}
}
