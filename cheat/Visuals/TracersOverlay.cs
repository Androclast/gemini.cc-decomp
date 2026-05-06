using System.Collections.Generic;
using System.Numerics;
using Robust.Client.Graphics;
using Robust.Client.Player;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.Graphics;
using Robust.Shared.IoC;
using Robust.Shared.Maths;
using Robust.Shared.Player;
using AutoPath;
using CerberusConfig;

namespace TracersOverlay;

public sealed class TracersOverlay : Overlay
{
	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	private SharedTransformSystem? sharedTransformSystem_0;

	private AutoPath? gclass270_0;

	private bool bool_0;

	private bool bool_1;

	private double double_0;

	public override OverlaySpace Space => (OverlaySpace)4;

	private bool Boolean_0
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	private bool Boolean_1
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

	public TracersOverlay()
	{
		IoCManager.InjectDependencies<TracersOverlay>(this);
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_0341: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.AutoPath.Enabled)
		{
			return;
		}
		if (sharedTransformSystem_0 == null || gclass270_0 == null)
		{
			try
			{
				IEntitySystemManager val = IoCManager.Resolve<IEntitySystemManager>();
				sharedTransformSystem_0 = val.GetEntitySystem<SharedTransformSystem>();
				gclass270_0 = val.GetEntitySystem<AutoPath>();
			}
			catch
			{
				return;
			}
		}
		DrawingHandleWorld worldHandle = ((OverlayDrawArgs)(ref args)).WorldHandle;
		IEye eye = args.Viewport.Eye;
		if (eye == null)
		{
			_ = Angle.Zero;
		}
		else
		{
			_ = eye.Rotation;
		}
		List<Vector2> currentPath = gclass270_0.GetCurrentPath();
		if (currentPath == null || currentPath.Count == 0)
		{
			return;
		}
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (!localEntity.HasValue)
		{
			return;
		}
		Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(localEntity.Value);
		Color val2;
		for (int i = 0; i < currentPath.Count - 1; i++)
		{
			Vector2 vector = currentPath[i];
			Vector2 vector2 = currentPath[i + 1];
			float num = (float)i / (float)currentPath.Count;
			val2 = new Color((byte)(0f * (1f - num) + 255f * num), (byte)(255f * (1f - num) + 255f * num), (byte)(0f * (1f - num) + 0f * num), byte.MaxValue);
			Color val3 = ((Color)(ref val2)).WithAlpha(0.8f);
			((DrawingHandleBase)worldHandle).DrawLine(vector, vector2, val3);
		}
		for (int j = 0; j < currentPath.Count; j++)
		{
			Vector2 vector3 = currentPath[j];
			float num2 = 0.15f;
			Color val4 = ((j != 0) ? ((j == currentPath.Count - 1) ? Color.Red : Color.Yellow) : Color.Lime);
			((DrawingHandleBase)worldHandle).DrawCircle(vector3, num2, ((Color)(ref val4)).WithAlpha(0.9f), true);
		}
		if (currentPath.Count > 0)
		{
			Vector2 vector4 = currentPath[0];
			val2 = Color.Cyan;
			((DrawingHandleBase)worldHandle).DrawLine(worldPosition, vector4, ((Color)(ref val2)).WithAlpha(0.6f));
		}
		EntityUid? currentTarget = gclass270_0.GetCurrentTarget();
		if (currentTarget.HasValue && currentTarget.HasValue && IoCManager.Resolve<IEntityManager>().EntityExists(currentTarget.Value))
		{
			Vector2 worldPosition2 = sharedTransformSystem_0.GetWorldPosition(currentTarget.Value);
			val2 = Color.Red;
			((DrawingHandleBase)worldHandle).DrawCircle(worldPosition2, 0.5f, ((Color)(ref val2)).WithAlpha(0.5f), true);
			if (currentPath.Count > 0)
			{
				Vector2 vector5 = currentPath[currentPath.Count - 1];
				val2 = Color.Orange;
				((DrawingHandleBase)worldHandle).DrawLine(vector5, worldPosition2, ((Color)(ref val2)).WithAlpha(0.6f));
			}
		}
	}

	private string method_4(string string_0, char char_0)
	{
		return "Хитролох_иди_нахуй._5_372_____8_____85__";
	}
}
