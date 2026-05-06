using System.Collections.Generic;
using System.Numerics;
using Robust.Client.Graphics;
using Robust.Client.Player;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Maths;
using Robust.Shared.Player;
using StrafeAntiAim;
using CerberusConfig;

namespace PlayerEspOverlay;

public sealed class PlayerEspOverlay : Overlay
{
	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	private SharedTransformSystem? sharedTransformSystem_0;

	private StrafeAntiAim? gclass96_0;

	private float float_0;

	private bool bool_1;

	public override OverlaySpace Space => (OverlaySpace)4;

	private float Single_0
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
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

	public PlayerEspOverlay()
	{
		IoCManager.InjectDependencies<PlayerEspOverlay>(this);
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.Misc.TargetStrafeEnabled)
		{
			return;
		}
		if (sharedTransformSystem_0 == null || gclass96_0 == null)
		{
			try
			{
				IEntitySystemManager val = IoCManager.Resolve<IEntitySystemManager>();
				sharedTransformSystem_0 = val.GetEntitySystem<SharedTransformSystem>();
				gclass96_0 = val.GetEntitySystem<StrafeAntiAim>();
			}
			catch
			{
				return;
			}
		}
		DrawingHandleWorld worldHandle = ((OverlayDrawArgs)(ref args)).WorldHandle;
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (!localEntity.HasValue)
		{
			return;
		}
		Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(localEntity.Value);
		List<Vector2> currentPath = gclass96_0.GetCurrentPath();
		if (currentPath == null || currentPath.Count == 0)
		{
			return;
		}
		Color val2;
		for (int i = 0; i < currentPath.Count - 1; i++)
		{
			Vector2 vector = currentPath[i];
			Vector2 vector2 = currentPath[i + 1];
			float num = (float)i / (float)currentPath.Count;
			val2 = new Color((byte)(0f * (1f - num) + 255f * num), (byte)(255f * (1f - num) + 0f * num), (byte)(255f * (1f - num) + 255f * num), byte.MaxValue);
			Color val3 = ((Color)(ref val2)).WithAlpha(0.8f);
			((DrawingHandleBase)worldHandle).DrawLine(vector, vector2, val3);
		}
		for (int j = 0; j < currentPath.Count; j++)
		{
			Vector2 vector3 = currentPath[j];
			float num2 = 0.2f;
			Color val4 = ((j == 0) ? Color.Cyan : ((j == currentPath.Count - 1) ? Color.Red : Color.Yellow));
			((DrawingHandleBase)worldHandle).DrawCircle(vector3, num2, ((Color)(ref val4)).WithAlpha(0.9f), true);
		}
		if (currentPath.Count > 0)
		{
			Vector2 vector4 = currentPath[0];
			val2 = Color.LimeGreen;
			((DrawingHandleBase)worldHandle).DrawLine(worldPosition, vector4, ((Color)(ref val2)).WithAlpha(0.7f));
		}
		EntityUid? currentTarget = gclass96_0.GetCurrentTarget();
		if (currentTarget.HasValue && currentTarget.HasValue && IoCManager.Resolve<IEntityManager>().EntityExists(currentTarget.Value))
		{
			Vector2 worldPosition2 = sharedTransformSystem_0.GetWorldPosition(currentTarget.Value);
			val2 = Color.OrangeRed;
			((DrawingHandleBase)worldHandle).DrawCircle(worldPosition2, 0.6f, ((Color)(ref val2)).WithAlpha(0.6f), true);
			if (currentPath.Count > 0)
			{
				Vector2 vector5 = currentPath[currentPath.Count - 1];
				val2 = Color.Orange;
				((DrawingHandleBase)worldHandle).DrawLine(vector5, worldPosition2, ((Color)(ref val2)).WithAlpha(0.5f));
			}
		}
	}
}
