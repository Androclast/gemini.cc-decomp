using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using Content.Shared.Access.Components;
using Content.Shared.Access.Systems;
using Content.Shared.Mobs.Components;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Network;
using Robust.Shared.Player;
using DamageableHelper;

public sealed class SessionTrackerSystem : EntitySystem
{
	[CompilerGenerated]
	private readonly Dictionary<NetUserId, PlayerInfo> dictionary_0;

	private float float_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly SharedIdCardSystem sharedIdCardSystem_0;

	private IReadOnlyDictionary<NetUserId, ICommonSession> ireadOnlyDictionary_0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action<ICommonSession> action_0;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action<ICommonSession> action_1;

	private char char_0;

	private string string_0;

	private int int_0;

	public Dictionary<NetUserId, PlayerInfo> AllPlayerSessions
	{
		[CompilerGenerated]
		get
		{
			return dictionary_0;
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

	private string String_0
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
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

	public event Action<ICommonSession> Event_0
	{
		add
		{
			Action<ICommonSession> action = action_0;
			Action<ICommonSession> action2;
			do
			{
				action2 = action;
				Action<ICommonSession> value2 = (Action<ICommonSession>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while (action != action2);
		}
		remove
		{
			Action<ICommonSession> action = action_0;
			Action<ICommonSession> action2;
			do
			{
				action2 = action;
				Action<ICommonSession> value2 = (Action<ICommonSession>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while (action != action2);
		}
	}

	public event Action<ICommonSession> Event_1
	{
		add
		{
			Action<ICommonSession> action = action_1;
			Action<ICommonSession> action2;
			do
			{
				action2 = action;
				Action<ICommonSession> value2 = (Action<ICommonSession>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref action_1, value2, action2);
			}
			while (action != action2);
		}
		remove
		{
			Action<ICommonSession> action = action_1;
			Action<ICommonSession> action2;
			do
			{
				action2 = action;
				Action<ICommonSession> value2 = (Action<ICommonSession>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref action_1, value2, action2);
			}
			while (action != action2);
		}
	}

	public override void Initialize()
	{
		iplayerManager_0.PlayerListUpdated += OnPlayerListUpdated;
	}

	public override void Shutdown()
	{
		iplayerManager_0.PlayerListUpdated -= OnPlayerListUpdated;
	}

	public override void Update(float frameTime)
	{
		float_0 += frameTime;
		if (float_0 >= 1f)
		{
			float_0 = 0f;
			UpdateSessionDetails();
		}
	}

	private void UpdateSessionDetails()
	{
		//IL_051c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0499: Unknown result type (might be due to invalid IL or missing references)
		//IL_049e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0372: Unknown result type (might be due to invalid IL or missing references)
		//IL_0376: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_044d: Unknown result type (might be due to invalid IL or missing references)
		//IL_045b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Invalid comparison between Unknown and I4
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		Vector2 value = Vector2.Zero;
		bool flag = false;
		TransformComponent val = default(TransformComponent);
		if (localEntity.HasValue && ((EntitySystem)this).TryComp<TransformComponent>(localEntity.Value, ref val))
		{
			value = val.LocalPosition;
			flag = true;
		}
		Entity<IdCardComponent> val5 = default(Entity<IdCardComponent>);
		MobStateComponent val6 = default(MobStateComponent);
		Entity<IdCardComponent> val7 = default(Entity<IdCardComponent>);
		foreach (PlayerInfo value3 in AllPlayerSessions.Values)
		{
			if (value3.Status == "Offline")
			{
				continue;
			}
			EntityUid? val2 = (value3.AttachedEntity = value3.Session.AttachedEntity);
			if (!val2.HasValue)
			{
				if (string.IsNullOrEmpty(value3.EntityName) || value3.EntityName == "Unknown")
				{
					value3.EntityName = "Not Spawned";
				}
				if (string.IsNullOrEmpty(value3.Job) || value3.Job == "Unknown")
				{
					value3.Job = "No Job";
				}
				continue;
			}
			EntityUid value2 = val2.Value;
			bool flag2 = flag && localEntity.HasValue && value2 == localEntity.Value;
			TransformComponent val3 = null;
			MetaDataComponent val4 = null;
			bool num = ((EntitySystem)this).TryComp(value2, ref val3);
			if (((EntitySystem)this).TryComp(value2, ref val4) && !string.IsNullOrEmpty(val4.EntityName))
			{
				value3.EntityName = val4.EntityName;
			}
			else if (string.IsNullOrEmpty(value3.EntityName) || value3.EntityName == "Unknown")
			{
				value3.EntityName = "Loading...";
			}
			if (!num)
			{
				if (string.IsNullOrEmpty(value3.Job) || value3.Job == "Unknown")
				{
					value3.Job = "Loading...";
				}
				continue;
			}
			Vector2 localPosition = val3.LocalPosition;
			if (flag2 || localPosition != Vector2.Zero)
			{
				value3.LastKnownPosition = localPosition;
				value3.Distance = Vector2.Distance(value, localPosition);
				value3.IsVisible = true;
				if (sharedIdCardSystem_0.TryFindIdCard(value2, ref val5))
				{
					string text = val5.Comp.LocalizedJobTitle;
					if (string.IsNullOrEmpty(text))
					{
						text = Regex.Match(((EntitySystem)this).MetaData(Entity<IdCardComponent>.op_Implicit(val5)).EntityName ?? "", "\\(([^)]*)\\)").Groups[1].Value;
					}
					if (!string.IsNullOrEmpty(text))
					{
						value3.Job = text;
					}
					else if (string.IsNullOrEmpty(value3.Job) || value3.Job == "Unknown")
					{
						value3.Job = "No Job";
					}
				}
				else if (string.IsNullOrEmpty(value3.Job) || value3.Job == "Unknown")
				{
					value3.Job = "No Job";
				}
				if (DamageableHelper.TryGetDamageableComponent(value2, (IEntityManager)(object)base.EntityManager, out object component))
				{
					value3.Health = DamageableHelper.GetTotalDamage(component);
					value3.MaxHealth = 200f;
				}
				else if (value3.Health == 0f && value3.MaxHealth == 0f)
				{
					value3.Health = 0f;
					value3.MaxHealth = 100f;
				}
				if (!((EntitySystem)this).TryComp<MobStateComponent>(value2, ref val6))
				{
					value3.IsAlive = true;
				}
				else
				{
					value3.IsAlive = (int)val6.CurrentState == 1;
				}
				value3.IsAntag = false;
				continue;
			}
			value3.IsVisible = false;
			if (sharedIdCardSystem_0.TryFindIdCard(value2, ref val7))
			{
				string text2 = val7.Comp.LocalizedJobTitle;
				if (string.IsNullOrEmpty(text2))
				{
					text2 = Regex.Match(((EntitySystem)this).MetaData(Entity<IdCardComponent>.op_Implicit(val7)).EntityName ?? "", "\\(([^)]*)\\)").Groups[1].Value;
				}
				if (!string.IsNullOrEmpty(text2))
				{
					value3.Job = text2;
				}
			}
			if (value3.LastKnownPosition != Vector2.Zero)
			{
				value3.Distance = Vector2.Distance(value, value3.LastKnownPosition);
			}
		}
	}

	private void OnPlayerListUpdated()
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		Dictionary<NetUserId, ICommonSession> dictionary = new Dictionary<NetUserId, ICommonSession>(((ISharedPlayerManager)iplayerManager_0).SessionsDict);
		if (ireadOnlyDictionary_0 != null)
		{
			foreach (NetUserId item in ireadOnlyDictionary_0.Keys.Except(dictionary.Keys).ToList())
			{
				if (ireadOnlyDictionary_0.TryGetValue(item, out ICommonSession value))
				{
					action_1?.Invoke(value);
				}
				if (AllPlayerSessions.TryGetValue(item, out PlayerInfo value2))
				{
					value2.Status = "Offline";
				}
			}
			List<NetUserId> list = dictionary.Keys.Where(delegate(NetUserId k)
			{
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				//IL_0020: Unknown result type (might be due to invalid IL or missing references)
				if (!ireadOnlyDictionary_0.ContainsKey(k))
				{
					return true;
				}
				PlayerInfo value5;
				return AllPlayerSessions.TryGetValue(k, out value5) && value5.Status == "Offline";
			}).ToList();
			bool flag = false;
			foreach (NetUserId item2 in list)
			{
				if (dictionary.TryGetValue(item2, out var value3))
				{
					bool flag2 = false;
					if (AllPlayerSessions.TryGetValue(item2, out PlayerInfo value4))
					{
						flag2 = value4.Status == "Offline";
						value4.Session = value3;
						value4.Status = "Online";
					}
					else
					{
						AllPlayerSessions.Add(item2, new PlayerInfo(value3));
						flag = true;
					}
					if (flag2 || !ireadOnlyDictionary_0.ContainsKey(item2))
					{
						action_0?.Invoke(value3);
						flag = true;
					}
				}
			}
			ireadOnlyDictionary_0 = dictionary;
			if (flag)
			{
				UpdateSessionDetails();
			}
			return;
		}
		foreach (var (key, session) in dictionary)
		{
			if (!AllPlayerSessions.ContainsKey(key))
			{
				AllPlayerSessions.Add(key, new PlayerInfo(session));
			}
		}
		ireadOnlyDictionary_0 = dictionary;
		UpdateSessionDetails();
	}

	public SessionTrackerSystem()
	{
		dictionary_0 = new Dictionary<NetUserId, PlayerInfo>();
	}
}
