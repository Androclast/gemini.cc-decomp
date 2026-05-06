using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Player;
using CerberusConfig;

namespace AutoStop;

public class AutoStop : EntitySystem
{
	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	private float float_0;

	private long long_1;

	private double double_0;

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

	public override void Update(float frameTime)
	{
		if (!CerberusConfig.AutoShoot.Enabled || !((ISharedPlayerManager)iplayerManager_0).LocalEntity.HasValue)
		{
			return;
		}
		float_0 += frameTime;
		float num = (float)CerberusConfig.AutoShoot.FireDelay / 1000f;
		if (!(float_0 < num))
		{
			EntityUid? currentTarget = CerberusConfig.HudOverlay.CurrentTarget;
			if (currentTarget.HasValue)
			{
				SimulateMouseClick();
				float_0 = 0f;
			}
		}
	}

	private void SimulateMouseClick()
	{
	}
}
