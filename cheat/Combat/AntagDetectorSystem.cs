using System;
using Robust.Shared.Containers;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;

public class AntagDetectorSystem : EntitySystem
{
	[Dependency]
	private readonly SharedContainerSystem sharedContainerSystem_0;

	[Dependency]
	private readonly PlayerComponentHelper2 gclass75_0;

	private byte byte_0;

	private char char_1;

	private double double_0;

	private float float_0;

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

	private char Char_0
	{
		get
		{
			return char_1;
		}
		set
		{
			char_1 = value;
		}
	}

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

	public bool IsAgent(EntityUid target)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		if (AntagExists("StoreDiscount"))
		{
			BaseContainer val = default(BaseContainer);
			if (sharedContainerSystem_0.TryGetContainer(target, "id", ref val, (ContainerManagerComponent)null))
			{
				foreach (EntityUid containedEntity in val.ContainedEntities)
				{
					if (!gclass75_0.HasComponent("StoreDiscount", containedEntity))
					{
						continue;
					}
					goto IL_0094;
				}
				return false;
			}
			return false;
		}
		return false;
		IL_0094:
		return true;
	}

	public bool IsHeretic(EntityUid target)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		if (AntagExists("Heretic"))
		{
			return gclass75_0.HasComponent("Heretic", target);
		}
		return false;
	}

	public bool IsVampire(EntityUid target)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		if (!AntagExists("Vampire"))
		{
			return false;
		}
		return gclass75_0.HasComponent("Vampire", target);
	}

	public bool IsFleshCultist(EntityUid target)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		if (AntagExists("FleshCultist"))
		{
			return gclass75_0.HasComponent("FleshCultist", target);
		}
		return false;
	}

	public bool IsZeroZombie(EntityUid target)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		if (AntagExists("PendingZombie"))
		{
			return gclass75_0.HasComponent("PendingZombie", target);
		}
		return false;
	}

	public bool IsChangeling(EntityUid target)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		if (!AntagExists("Changeling"))
		{
			return false;
		}
		return gclass75_0.HasComponent("Changeling", target);
	}

	public bool IsCosmicCult(EntityUid target)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		if (AntagExists("CosmicCult"))
		{
			return gclass75_0.HasComponent("CosmicCult", target);
		}
		return false;
	}

	public bool IsDevil(EntityUid target)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		if (!AntagExists("CheatDeath"))
		{
			return false;
		}
		return gclass75_0.HasComponent("CheatDeath", target);
	}

	public bool IsBlob(EntityUid target)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		if (AntagExists("BlobCarrier"))
		{
			return gclass75_0.HasComponent("BlobCarrier", target);
		}
		return false;
	}

	public unsafe bool IsThief(EntityUid target)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		ContainerManagerComponent val = default(ContainerManagerComponent);
		if (!((EntitySystem)this).TryComp<ContainerManagerComponent>(target, ref val))
		{
			return false;
		}
		AllContainersEnumerable allContainers = sharedContainerSystem_0.GetAllContainers(target, val);
		AllContainersEnumerator enumerator = ((AllContainersEnumerable)(ref allContainers)).GetEnumerator();
		try
		{
			while (((AllContainersEnumerator)(ref enumerator)).MoveNext())
			{
				BaseContainer current = ((AllContainersEnumerator)(ref enumerator)).Current;
				if (ContainsThief(current))
				{
					goto IL_006e;
				}
			}
		}
		finally
		{
			((IDisposable)(*(AllContainersEnumerator*)(&enumerator))/*cast due to constrained. prefix*/).Dispose();
		}
		return false;
		IL_006e:
		return true;
	}

	private bool AntagExists(string name)
	{
		return gclass75_0.ComponentExists(name);
	}

	private unsafe bool ContainsThief(BaseContainer container)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		if (container == null)
		{
			return false;
		}
		MetaDataComponent val = default(MetaDataComponent);
		ContainerManagerComponent val2 = default(ContainerManagerComponent);
		foreach (EntityUid containedEntity in container.ContainedEntities)
		{
			if (((EntitySystem)this).TryComp<MetaDataComponent>(containedEntity, ref val) && val.EntityPrototype != null && val.EntityPrototype.ID.Contains("Thief"))
			{
				return true;
			}
			if (!((EntitySystem)this).TryComp<ContainerManagerComponent>(containedEntity, ref val2))
			{
				continue;
			}
			AllContainersEnumerable allContainers = sharedContainerSystem_0.GetAllContainers(containedEntity, val2);
			AllContainersEnumerator enumerator2 = ((AllContainersEnumerable)(ref allContainers)).GetEnumerator();
			try
			{
				while (((AllContainersEnumerator)(ref enumerator2)).MoveNext())
				{
					BaseContainer current2 = ((AllContainersEnumerator)(ref enumerator2)).Current;
					if (ContainsThief(current2))
					{
						return true;
					}
				}
			}
			finally
			{
				((IDisposable)(*(AllContainersEnumerator*)(&enumerator2))/*cast due to constrained. prefix*/).Dispose();
			}
		}
		return false;
	}

	private string method_7(bool bool_0, int int_0)
	{
		return "Хитролох_иди_нахуй._6_________8";
	}
}
