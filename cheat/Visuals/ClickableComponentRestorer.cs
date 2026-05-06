using System.Collections.Generic;
using Content.Client.Clickable;
using Content.Shared.Tag;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Prototypes;
using CerberusConfig;

namespace ClickableComponentRestorer;

public sealed class ClickableComponentRestorer : EntitySystem
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	private TagSystem tagSystem_0;

	private readonly HashSet<EntityUid> hashSet_0 = new HashSet<EntityUid>();

	private readonly Dictionary<EntityUid, ClickableComponent> dictionary_0 = new Dictionary<EntityUid, ClickableComponent>();

	private float float_0;

	private HashSet<string> hashSet_1 = new HashSet<string>();

	private bool bool_0;

	private int int_0;

	private bool bool_1;

	private string string_0;

	private long long_0;

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
			return bool_1;
		}
		set
		{
			bool_1 = value;
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

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
		tagSystem_0 = ientityManager_0.System<TagSystem>();
	}

	public override void Update(float frameTime)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Unknown result type (might be due to invalid IL or missing references)
		((EntitySystem)this).Update(frameTime);
		float_0 += frameTime;
		if (!(float_0 >= 0.1f))
		{
			return;
		}
		float_0 = 0f;
		if (CerberusConfig.NoInteract.Enabled)
		{
			bool_0 = true;
			if (CerberusConfig.NoInteract.BlockedTags != null && CerberusConfig.NoInteract.BlockedTags.Count != 0)
			{
				if (hashSet_1.Count != CerberusConfig.NoInteract.BlockedTags.Count)
				{
					hashSet_1.Clear();
					foreach (string blockedTag in CerberusConfig.NoInteract.BlockedTags)
					{
						hashSet_1.Add(blockedTag);
					}
				}
				EntityQueryEnumerator<TagComponent> val = ((EntitySystem)this).EntityQueryEnumerator<TagComponent>();
				HashSet<EntityUid> hashSet = new HashSet<EntityUid>();
				EntityUid val2 = default(EntityUid);
				TagComponent val3 = default(TagComponent);
				ClickableComponent value = default(ClickableComponent);
				while (val.MoveNext(ref val2, ref val3))
				{
					hashSet.Add(val2);
					bool flag = false;
					foreach (ProtoId<TagPrototype> tag in val3.Tags)
					{
						if (hashSet_1.Contains(ProtoId<TagPrototype>.op_Implicit(tag)))
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						if (ientityManager_0.TryGetComponent<ClickableComponent>(val2, ref value) && !dictionary_0.ContainsKey(val2))
						{
							dictionary_0[val2] = value;
							ientityManager_0.RemoveComponent<ClickableComponent>(val2, (MetaDataComponent)null);
						}
						hashSet_0.Add(val2);
					}
					else if (dictionary_0.ContainsKey(val2))
					{
						if (!ientityManager_0.HasComponent<ClickableComponent>(val2))
						{
							ientityManager_0.AddComponent<ClickableComponent>(val2);
						}
						dictionary_0.Remove(val2);
					}
				}
				List<EntityUid> list = new List<EntityUid>();
				foreach (EntityUid key in dictionary_0.Keys)
				{
					if (!hashSet.Contains(key) || !ientityManager_0.EntityExists(key))
					{
						list.Add(key);
					}
				}
				{
					foreach (EntityUid item in list)
					{
						if (ientityManager_0.EntityExists(item) && !ientityManager_0.HasComponent<ClickableComponent>(item))
						{
							ientityManager_0.AddComponent<ClickableComponent>(item);
						}
						dictionary_0.Remove(item);
					}
					return;
				}
			}
			RestoreAllComponents();
		}
		else if (bool_0)
		{
			RestoreAllComponents();
			bool_0 = false;
		}
	}

	private void RestoreAllComponents()
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		foreach (KeyValuePair<EntityUid, ClickableComponent> item in dictionary_0)
		{
			if (ientityManager_0.EntityExists(item.Key) && !ientityManager_0.HasComponent<ClickableComponent>(item.Key))
			{
				ientityManager_0.AddComponent<ClickableComponent>(item.Key);
			}
		}
		dictionary_0.Clear();
		hashSet_0.Clear();
	}
}
