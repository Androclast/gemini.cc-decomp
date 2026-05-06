using System.Numerics;
using Robust.Client.Graphics;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using CerberusConfig;

namespace AimbotOverlayBase;

public sealed class AimbotOverlayBase : EntitySystem
{
	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	private SharedTransformSystem? sharedTransformSystem_0;

	private AimbotRenderOverlay? gclass9_0;

	private int int_0;

	private byte byte_0;

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

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
		sharedTransformSystem_0 = base.EntityManager.System<SharedTransformSystem>();
	}

	public override void Update(float frameTime)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		((EntitySystem)this).Update(frameTime);
		if (!igameTiming_0.IsFirstTimePredicted)
		{
			return;
		}
		if (!CerberusConfig.GunHelper.RotateToTarget || !CerberusConfig.GunAimBot.Enabled)
		{
			CerberusConfig.NoSavedConfig.HasTarget = false;
		}
		else
		{
			if (!((ISharedPlayerManager)iplayerManager_0).LocalEntity.HasValue)
			{
				return;
			}
			if (gclass9_0 == null)
			{
				IOverlayManager val = IoCManager.Resolve<IOverlayManager>();
				gclass9_0 = val.GetOverlay<AimbotRenderOverlay>();
			}
			if (gclass9_0 != null && sharedTransformSystem_0 != null)
			{
				EntityUid? currentGunTarget = gclass9_0.CurrentGunTarget;
				if (currentGunTarget.HasValue && ientityManager_0.EntityExists(currentGunTarget.Value))
				{
					Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(currentGunTarget.Value);
					CerberusConfig.NoSavedConfig.HasTarget = true;
					base.EntityManager.System<PlayerRotator>()?.RotateToTarget(worldPosition);
				}
				else
				{
					CerberusConfig.NoSavedConfig.HasTarget = false;
				}
			}
		}
	}
}
