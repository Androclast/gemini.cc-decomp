using System.Runtime.CompilerServices;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Player;

[CompilerGenerated]
public class PlayerComponentHelper2 : EntitySystem
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	private float float_0;

	private int int_0;

	private long long_1;

	private string string_0;

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

	private long Int64_0
	{
		get
		{
			return long_1;
		}
		set
		{
			long_1 = value;
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

	public void AddComponent(string componentName, EntityUid? uid = null)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		if (ComponentExists(componentName) && (uid.HasValue || GetPlayer(out uid)) && !ientityManager_0.HasComponent(uid, ientityManager_0.ComponentFactory.GetRegistration(componentName, false).Type))
		{
			IComponent component = ientityManager_0.ComponentFactory.GetComponent(componentName, false);
			component.NetSyncEnabled = false;
			ientityManager_0.AddComponent<IComponent>(uid.Value, component, false, (MetaDataComponent)null);
		}
	}

	public void RemoveComponent(string componentName, EntityUid? uid = null)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		if (ComponentExists(componentName) && (uid.HasValue || GetPlayer(out uid)) && ientityManager_0.HasComponent(uid, ientityManager_0.ComponentFactory.GetRegistration(componentName, false).Type))
		{
			ientityManager_0.RemoveComponent(uid.Value, ientityManager_0.ComponentFactory.GetRegistration(componentName, false).Type, (MetaDataComponent)null);
		}
	}

	public bool HasComponent(string componentName, EntityUid? uid = null)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		if (ComponentExists(componentName))
		{
			if (uid.HasValue || GetPlayer(out uid))
			{
				return ientityManager_0.HasComponent(uid.Value, ientityManager_0.ComponentFactory.GetRegistration(componentName, false).Type);
			}
			return false;
		}
		return false;
	}

	public bool ComponentExists(string componentName)
	{
		ComponentRegistration val = default(ComponentRegistration);
		return ientityManager_0.ComponentFactory.TryGetRegistration(componentName, ref val, false);
	}

	private bool GetPlayer(out EntityUid? player)
	{
		player = null;
		if (((ISharedPlayerManager)iplayerManager_0).LocalEntity.HasValue)
		{
			player = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
			return true;
		}
		return false;
	}
}
