using System.Numerics;
using Content.Shared.Humanoid;
using Content.Shared.Stealth.Components;
using Robust.Client.Graphics;
using Robust.Client.Player;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Maths;
using Robust.Shared.Player;
using Robust.Shared.Prototypes;
using CerberusConfig;

namespace CloakedPlayerDetectorOverlay;

public sealed class CloakedPlayerDetectorOverlay : Overlay
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	private SharedTransformSystem? sharedTransformSystem_0;

	private byte byte_0;

	private int int_1;

	private int int_2;

	public override OverlaySpace Space => (OverlaySpace)4;

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

	private int Int32_0
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

	private int Int32_1
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public CloakedPlayerDetectorOverlay()
	{
		IoCManager.InjectDependencies<CloakedPlayerDetectorOverlay>(this);
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.CloakedPlayerDetector.Enabled)
		{
			return;
		}
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (!localEntity.HasValue)
		{
			return;
		}
		if (sharedTransformSystem_0 == null)
		{
			sharedTransformSystem_0 = ientityManager_0.System<SharedTransformSystem>();
		}
		Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(localEntity.Value);
		DrawingHandleWorld worldHandle = ((OverlayDrawArgs)(ref args)).WorldHandle;
		AllEntityQueryEnumerator<StealthComponent, HumanoidAppearanceComponent, TransformComponent> val = ientityManager_0.AllEntityQueryEnumerator<StealthComponent, HumanoidAppearanceComponent, TransformComponent>();
		EntityUid val2 = default(EntityUid);
		StealthComponent val3 = default(StealthComponent);
		HumanoidAppearanceComponent val4 = default(HumanoidAppearanceComponent);
		TransformComponent val5 = default(TransformComponent);
		Color val6 = default(Color);
		Box2 val7 = default(Box2);
		while (val.MoveNext(ref val2, ref val3, ref val4, ref val5))
		{
			if (val2 == localEntity.Value || val5.MapID != args.MapId)
			{
				continue;
			}
			Vector2 worldPosition2 = sharedTransformSystem_0.GetWorldPosition(val5);
			if (Vector2.Distance(worldPosition, worldPosition2) > CerberusConfig.CloakedPlayerDetector.MaxDistance)
			{
				continue;
			}
			Vector4 vector = CerberusConfig.CloakedPlayerDetector.CloakedColor;
			MetaDataComponent component = ientityManager_0.GetComponent<MetaDataComponent>(val2);
			EntityPrototype entityPrototype = component.EntityPrototype;
			if (entityPrototype == null || entityPrototype.ID?.Contains("Ninja") != true)
			{
				EntityPrototype entityPrototype2 = component.EntityPrototype;
				if (entityPrototype2 == null || entityPrototype2.ID?.Contains("ninja") != true)
				{
					goto IL_00d1;
				}
			}
			vector = CerberusConfig.CloakedPlayerDetector.NinjaColor;
			goto IL_00d1;
			IL_00d1:
			((Color)(ref val6))._002Ector(vector.X, vector.Y, vector.Z, vector.W);
			if (CerberusConfig.CloakedPlayerDetector.ShowOutline)
			{
				((Box2)(ref val7))._002Ector(worldPosition2 - new Vector2(0.4f, 0.9f), worldPosition2 + new Vector2(0.4f, 0.1f));
				worldHandle.DrawRect(val7, val6, true);
			}
			if (CerberusConfig.CloakedPlayerDetector.ShowWarningForNinja && vector == CerberusConfig.CloakedPlayerDetector.NinjaColor)
			{
				Vector2 center = worldPosition2 + new Vector2(0f, 1.2f);
				DrawWarningTriangle(worldHandle, center, 0.3f, new Color(1f, 0f, 0f, 0.8f));
			}
		}
	}

	private void DrawWarningTriangle(DrawingHandleWorld handle, Vector2 center, float size, Color color)
	{
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		Vector2 vector = center + new Vector2(0f, size);
		Vector2 vector2 = center + new Vector2((0f - size) * 0.866f, (0f - size) * 0.5f);
		Vector2 vector3 = center + new Vector2(size * 0.866f, (0f - size) * 0.5f);
		((DrawingHandleBase)handle).DrawLine(vector, vector2, color);
		((DrawingHandleBase)handle).DrawLine(vector2, vector3, color);
		((DrawingHandleBase)handle).DrawLine(vector3, vector, color);
		Vector2 vector4 = center + new Vector2(0f, 0.1f);
		Vector2 vector5 = center + new Vector2(0f, -0.15f);
		((DrawingHandleBase)handle).DrawLine(vector4, vector5, color);
		Vector2 vector6 = center + new Vector2(0f, -0.25f);
		((DrawingHandleBase)handle).DrawCircle(vector6, 0.03f, color, true);
	}
}
