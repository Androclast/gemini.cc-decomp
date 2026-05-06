using System.Numerics;
using Robust.Client.Graphics;
using Robust.Shared.Enums;
using Robust.Shared.Maths;
using CerberusConfig;

public sealed class AimbotCircleDrawer : Overlay
{
	private int int_0;

	private int int_1;

	public override OverlaySpace Space => (OverlaySpace)4;

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

	private int Int32_1
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		if (CerberusConfig.Misc.AutoPeekEnabled && AimbotMovementSystem.nullable_0.HasValue)
		{
			Vector2 value = AimbotMovementSystem.nullable_0.Value;
			Color val = new Color(ref CerberusConfig.Misc.AutoPeekColor);
			((DrawingHandleBase)((OverlayDrawArgs)(ref args)).WorldHandle).DrawCircle(value, 0.3f, val, false);
			((DrawingHandleBase)((OverlayDrawArgs)(ref args)).WorldHandle).DrawLine(value - new Vector2(0.2f, 0f), value + new Vector2(0.2f, 0f), val);
			((DrawingHandleBase)((OverlayDrawArgs)(ref args)).WorldHandle).DrawLine(value - new Vector2(0f, 0.2f), value + new Vector2(0f, 0.2f), val);
		}
	}
}
