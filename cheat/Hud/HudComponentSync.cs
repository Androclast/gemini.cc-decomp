using System;
using System.Runtime.CompilerServices;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Player;
using CerberusConfig;

[CompilerGenerated]
public class HudComponentSync : EntitySystem
{
	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	private readonly PlayerComponentHelper gclass0_0;

	private float float_0;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7 = true;

	private double double_0;

	private string string_2;

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

	private string String_0
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public HudComponentSync()
	{
		gclass0_0 = new PlayerComponentHelper();
	}

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
		((EntitySystem)this).SubscribeLocalEvent<LocalPlayerAttachedEvent>((EntityEventHandler<LocalPlayerAttachedEvent>)OnLocalPlayerAttached, (Type[])null, (Type[])null);
	}

	private void OnLocalPlayerAttached(LocalPlayerAttachedEvent ev)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		bool_7 = true;
		UpdateHudComponents(ev.Entity);
	}

	public override void Update(float frameTime)
	{
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		float_0 += frameTime;
		if (!(float_0 >= 0.1f))
		{
			return;
		}
		float_0 = 0f;
		if (bool_0 != CerberusConfig.Hud.ShowAntag || bool_1 != CerberusConfig.Hud.ShowJobIcons || bool_2 != CerberusConfig.Hud.ShowMindShieldIcons || bool_3 != CerberusConfig.Hud.ShowCriminalRecordIcons || bool_4 != CerberusConfig.Hud.ShowSyndicateIcons || bool_5 != CerberusConfig.Hud.ChemicalAnalysis || bool_6 != CerberusConfig.Hud.ShowElectrocution || bool_7)
		{
			bool_0 = CerberusConfig.Hud.ShowAntag;
			bool_1 = CerberusConfig.Hud.ShowJobIcons;
			bool_2 = CerberusConfig.Hud.ShowMindShieldIcons;
			bool_3 = CerberusConfig.Hud.ShowCriminalRecordIcons;
			bool_4 = CerberusConfig.Hud.ShowSyndicateIcons;
			bool_5 = CerberusConfig.Hud.ChemicalAnalysis;
			bool_6 = CerberusConfig.Hud.ShowElectrocution;
			bool_7 = false;
			if (((ISharedPlayerManager)iplayerManager_0).LocalEntity.HasValue)
			{
				UpdateHudComponents(((ISharedPlayerManager)iplayerManager_0).LocalEntity.Value);
			}
		}
	}

	private void UpdateHudComponents(EntityUid entity)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		SyncComponent(entity, "ShowAntagIcons", CerberusConfig.Hud.ShowAntag);
		SyncComponent(entity, "ShowJobIcons", CerberusConfig.Hud.ShowJobIcons);
		SyncComponent(entity, "ShowMindShieldIcons", CerberusConfig.Hud.ShowMindShieldIcons);
		SyncComponent(entity, "ShowCriminalRecordIcons", CerberusConfig.Hud.ShowCriminalRecordIcons);
		SyncComponent(entity, "ShowSyndicateIcons", CerberusConfig.Hud.ShowSyndicateIcons);
		SyncComponent(entity, "SolutionScanner", CerberusConfig.Hud.ChemicalAnalysis);
		SyncComponent(entity, "ShowElectrocutionHUD", CerberusConfig.Hud.ShowElectrocution);
	}

	private void SyncComponent(EntityUid uid, string componentName, bool isEnabled)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		if (!isEnabled || gclass0_0.HasComponent(componentName, uid))
		{
			if (!isEnabled && gclass0_0.HasComponent(componentName, uid))
			{
				gclass0_0.RemoveComponent(componentName, uid);
			}
		}
		else
		{
			gclass0_0.AddComponent(componentName, uid);
		}
	}
}
