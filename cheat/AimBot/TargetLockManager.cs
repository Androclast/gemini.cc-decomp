using System.Numerics;
using Content.Shared.Mobs.Components;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Player;
using CerberusConfig;

namespace TargetLockManager;

public class TargetLockManager : EntitySystem
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly SharedTransformSystem sharedTransformSystem_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	private EntityUid? nullable_0;

	private float float_0;

	private long long_0;

	private int int_2;

	private int int_3;

	private double double_1;

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

	private int Int32_0
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

	private int Int32_1
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
		}
	}

	private double Double_0
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public void LockTarget(EntityUid target)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		nullable_0 = target;
		float_0 = 0f;
	}

	public void UnlockTarget()
	{
		nullable_0 = null;
	}

	public override void Update(float frameTime)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.TargetLock.Enabled)
		{
			nullable_0 = null;
		}
		else
		{
			if (!nullable_0.HasValue)
			{
				return;
			}
			if (!ientityManager_0.EntityExists(nullable_0.Value))
			{
				UnlockTarget();
				return;
			}
			EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
			if (!localEntity.HasValue)
			{
				return;
			}
			Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(localEntity.Value);
			Vector2 worldPosition2 = sharedTransformSystem_0.GetWorldPosition(nullable_0.Value);
			if (Vector2.Distance(worldPosition, worldPosition2) <= CerberusConfig.TargetLock.MaxDistance)
			{
				if (!CerberusConfig.TargetLock.UnlockOnDeath || !IsDead(nullable_0.Value))
				{
					float_0 += frameTime;
				}
				else
				{
					UnlockTarget();
				}
			}
			else
			{
				UnlockTarget();
			}
		}
	}

	private bool IsDead(EntityUid target)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Invalid comparison between Unknown and I4
		MobStateComponent val = default(MobStateComponent);
		if (!ientityManager_0.TryGetComponent<MobStateComponent>(target, ref val))
		{
			return false;
		}
		return (int)val.CurrentState == 3;
	}

	public EntityUid? GetLockedTarget()
	{
		return nullable_0;
	}
}
