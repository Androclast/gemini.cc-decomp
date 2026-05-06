using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Content.Shared.Examine;
using Content.Shared.Movement.Components;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Player;
using CerberusConfig;

[CompilerGenerated]
public class ZoomSystem : EntitySystem
{
	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IEntityManager ientityManager_0;

	private EntityUid? nullable_0;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private float float_0;

	private float float_2;

	private byte byte_1;

	private char char_0;

	private float Single_0
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	private byte Byte_0
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = value;
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

	public override void Update(float frameTime)
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		float_0 += frameTime;
		if (!(float_0 >= 0.05f))
		{
			return;
		}
		float_0 = 0f;
		if (!CerberusConfig.Eye.FovEnabled && !CerberusConfig.Eye.FullBrightEnabled && CerberusConfig.Eye.Zoom == 0.5f && (int)CerberusConfig.Eye.FovHotKey == 0 && (int)CerberusConfig.Eye.FullBrightHotKey == 0 && (int)CerberusConfig.Eye.ZoomUpHotKey == 0 && (int)CerberusConfig.Eye.ZoomDownHotKey == 0)
		{
			return;
		}
		nullable_0 = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (nullable_0.HasValue)
		{
			EyeComponent eyeComponent = null;
			ExaminerComponent examinerComponent = null;
			ContentEyeComponent zoomComponent = default(ContentEyeComponent);
			if (ientityManager_0.TryGetComponent<ContentEyeComponent>(nullable_0, ref zoomComponent) && ientityManager_0.TryGetComponent<EyeComponent>(nullable_0, ref eyeComponent) && ientityManager_0.TryGetComponent<ExaminerComponent>(nullable_0, ref examinerComponent))
			{
				DisableNetSync(zoomComponent, eyeComponent, examinerComponent);
				HandleHotkeys();
				HandleZoomControls();
				ApplyVisualConfigurations(eyeComponent, examinerComponent);
				UpdateZoom(zoomComponent, eyeComponent);
			}
		}
	}

	private void HandleZoomControls()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		if ((int)CerberusConfig.Eye.ZoomUpHotKey != 0)
		{
			bool flag = KeyStateHelper.IsKeyDown(CerberusConfig.Eye.ZoomUpHotKey);
			if (flag && !bool_2)
			{
				CerberusConfig.Eye.Zoom = Math.Clamp(CerberusConfig.Eye.Zoom + 0.1f, 0.1f, 3f);
			}
			bool_2 = flag;
		}
		if ((int)CerberusConfig.Eye.ZoomDownHotKey != 0)
		{
			bool flag2 = KeyStateHelper.IsKeyDown(CerberusConfig.Eye.ZoomDownHotKey);
			if (flag2 && !bool_3)
			{
				CerberusConfig.Eye.Zoom = Math.Clamp(CerberusConfig.Eye.Zoom - 0.1f, 0.1f, 3f);
			}
			bool_3 = flag2;
		}
	}

	private void HandleHotkeys()
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		if ((int)CerberusConfig.Eye.FovHotKey != 0)
		{
			bool flag = KeyStateHelper.IsKeyDown(CerberusConfig.Eye.FovHotKey);
			if (flag && !bool_0)
			{
				CerberusConfig.Eye.FovEnabled = !CerberusConfig.Eye.FovEnabled;
			}
			bool_0 = flag;
		}
		if ((int)CerberusConfig.Eye.FullBrightHotKey != 0)
		{
			bool flag2 = KeyStateHelper.IsKeyDown(CerberusConfig.Eye.FullBrightHotKey);
			if (flag2 && !bool_1)
			{
				CerberusConfig.Eye.FullBrightEnabled = !CerberusConfig.Eye.FullBrightEnabled;
			}
			bool_1 = flag2;
		}
	}

	private void DisableNetSync(ContentEyeComponent zoomComponent, EyeComponent eyeComponent, ExaminerComponent examinerComponent)
	{
		((Component)zoomComponent).NetSyncEnabled = false;
		((Component)eyeComponent).NetSyncEnabled = false;
		((Component)examinerComponent).NetSyncEnabled = false;
	}

	private void ApplyVisualConfigurations(EyeComponent eyeComponent, ExaminerComponent examinerComponent)
	{
		eyeComponent.Eye.DrawFov = !CerberusConfig.Eye.FovEnabled;
		eyeComponent.Eye.DrawLight = !CerberusConfig.Eye.FullBrightEnabled;
		examinerComponent.CheckInRangeUnOccluded = !CerberusConfig.Eye.FovEnabled;
		examinerComponent.SkipChecks = CerberusConfig.Eye.FovEnabled;
	}

	private void UpdateZoom(ContentEyeComponent zoomComponent, EyeComponent eyeComponent)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		float zoom = CerberusConfig.Eye.Zoom;
		zoomComponent.TargetZoom = new Vector2(zoom);
		((EntitySystem)this).Dirty(nullable_0.Value, (IComponent)(object)eyeComponent, (MetaDataComponent)null);
	}
}
