using System;
using Content.Shared.Chemistry.Components;
using Robust.Shared.GameObjects;
using Robust.Shared.Player;
using CerberusConfig;

namespace SolutionScannerProvider;

public sealed class SolutionScannerProvider : EntitySystem
{
	private bool bool_0;

	private EntityUid? nullable_0;

	private float float_0;

	private long long_1;

	private long long_2;

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

	private long Int64_1
	{
		get
		{
			return long_2;
		}
		set
		{
			long_2 = value;
		}
	}

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
		((EntitySystem)this).SubscribeLocalEvent<LocalPlayerAttachedEvent>((EntityEventHandler<LocalPlayerAttachedEvent>)OnLocalPlayerAttached, (Type[])null, (Type[])null);
	}

	public override void Update(float frameTime)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		((EntitySystem)this).Update(frameTime);
		float_0 += frameTime;
		if (!(float_0 >= 0.5f))
		{
			return;
		}
		float_0 = 0f;
		bool enabled = CerberusConfig.SolutionScanner.Enabled;
		if (enabled && !bool_0)
		{
			if (nullable_0.HasValue && base.EntityManager.EntityExists(nullable_0.Value))
			{
				Logger.Info("[SolutionScanner] Enabled - adding component");
				AddSolutionScanner(nullable_0.Value);
			}
		}
		else if (!enabled && bool_0 && nullable_0.HasValue && base.EntityManager.EntityExists(nullable_0.Value))
		{
			Logger.Info("[SolutionScanner] Disabled - removing component");
			RemoveSolutionScanner(nullable_0.Value);
		}
		bool_0 = enabled;
	}

	private void OnLocalPlayerAttached(LocalPlayerAttachedEvent args)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		nullable_0 = args.Entity;
		Logger.Info($"[SolutionScanner] Player attached: {args.Entity}, Enabled: {CerberusConfig.SolutionScanner.Enabled}");
		if (CerberusConfig.SolutionScanner.Enabled)
		{
			AddSolutionScanner(args.Entity);
		}
	}

	private void AddSolutionScanner(EntityUid uid)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		try
		{
			if (!((EntitySystem)this).HasComp<SolutionScannerComponent>(uid))
			{
				((EntitySystem)this).AddComp<SolutionScannerComponent>(uid, new SolutionScannerComponent
				{
					NetSyncEnabled = false
				}, false);
				Logger.Info("[SolutionScanner] Component added successfully!");
			}
			else
			{
				Logger.Info("[SolutionScanner] Component already exists");
			}
		}
		catch (Exception ex)
		{
			Logger.Error("[SolutionScanner] Failed to add component: " + ex.Message);
		}
	}

	private void RemoveSolutionScanner(EntityUid uid)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (((EntitySystem)this).HasComp<SolutionScannerComponent>(uid))
			{
				((EntitySystem)this).RemComp<SolutionScannerComponent>(uid);
				Logger.Info("[SolutionScanner] Component removed");
			}
		}
		catch (Exception ex)
		{
			Logger.Error("[SolutionScanner] Failed to remove component: " + ex.Message);
		}
	}
}
