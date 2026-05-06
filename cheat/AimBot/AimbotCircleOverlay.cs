using System.Numerics;
using CerberusWareV3.Features.AimBot;
using Content.Shared.CombatMode;
using Robust.Client.Graphics;
using Robust.Client.Player;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Maths;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using ThrowAimbot;
using CerberusConfig;

public sealed class AimbotCircleOverlay : Overlay
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	private ThrowAimbot gclass296_0;

	private double double_0;

	private bool bool_1;

	private char char_0;

	public override OverlaySpace Space => (OverlaySpace)4;

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

	public AimbotCircleOverlay()
	{
		IoCManager.InjectDependencies<AimbotCircleOverlay>(this);
		gclass296_0 = new ThrowAimbot(ientityManager_0);
	}

	protected override void FrameUpdate(FrameEventArgs args)
	{
		gclass296_0.Update(((FrameEventArgs)(ref args)).DeltaSeconds);
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.ThrowAimbot.Enabled)
		{
			return;
		}
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		CombatModeComponent val = default(CombatModeComponent);
		if (!localEntity.HasValue || !ientityManager_0.TryGetComponent<CombatModeComponent>(localEntity.Value, ref val) || !val.IsInCombatMode)
		{
			return;
		}
		TransformComponent component = ientityManager_0.GetComponent<TransformComponent>(localEntity.Value);
		if (!(component.MapID != args.MapId))
		{
			Vector2 worldPosition = ientityManager_0.System<SharedTransformSystem>().GetWorldPosition(component);
			if (CerberusConfig.ThrowAimbot.Range > 0f)
			{
				DrawingHandleWorld worldHandle = ((OverlayDrawArgs)(ref args)).WorldHandle;
				float range = CerberusConfig.ThrowAimbot.Range;
				Color cyan = Color.Cyan;
				((DrawingHandleBase)worldHandle).DrawCircle(worldPosition, range, ((Color)(ref cyan)).WithAlpha(0.3f), false);
			}
			if (ThrowAimbotGlobals.nullable_0.HasValue)
			{
				Vector2 vector = worldPosition + ThrowAimbotGlobals.nullable_0.Value;
				((DrawingHandleBase)((OverlayDrawArgs)(ref args)).WorldHandle).DrawLine(worldPosition, vector, Color.Red);
			}
		}
	}
}
