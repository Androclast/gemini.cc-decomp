using System.Collections.Generic;
using System.Numerics;
using Robust.Client.Graphics;
using Robust.Shared.Enums;
using Robust.Shared.IoC;
using Robust.Shared.Maths;
using CerberusConfig;

namespace LightSmoothOverlay;

public sealed class LightSmoothOverlay : Overlay
{
	private long long_0;

	private char char_0;

	public override OverlaySpace Space => (OverlaySpace)4;

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

	public LightSmoothOverlay()
	{
		IoCManager.InjectDependencies<LightSmoothOverlay>(this);
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.ProjectileEsp.Enabled)
		{
			return;
		}
		List<(Vector2, Vector2)> list_ = HudUpdateSystem.list_1;
		if (list_ == null || list_.Count == 0)
		{
			return;
		}
		DrawingHandleWorld worldHandle = ((OverlayDrawArgs)(ref args)).WorldHandle;
		Vector4 color = CerberusConfig.ProjectileEsp.Color;
		Color val = default(Color);
		((Color)(ref val))._002Ector(color.X, color.Y, color.Z, color.W);
		foreach (var (vector, vector2) in list_)
		{
			((DrawingHandleBase)worldHandle).DrawCircle(vector, 0.4f, val, false);
			if (CerberusConfig.ProjectileEsp.ShowTrajectory)
			{
				((DrawingHandleBase)worldHandle).DrawLine(vector, vector2, val);
			}
		}
	}
}
