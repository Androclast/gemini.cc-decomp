using System.Collections.Generic;
using System.Numerics;
using Robust.Client.Graphics;
using Robust.Client.Player;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using Robust.Shared.Player;
using AccessCheckSystem;
using CerberusConfig;

namespace HitMarkerOverlay;

public sealed class HitMarkerOverlay : Overlay
{
	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IEntitySystemManager ientitySystemManager_0;

	private AccessCheckSystem? gclass218_0;

	private Texture? texture_0;

	private Texture? texture_1;

	private char char_1;

	private char char_2;

	public override OverlaySpace Space => (OverlaySpace)4;

	private char Char_0
	{
		get
		{
			return char_1;
		}
		set
		{
			char_1 = value;
		}
	}

	private char Char_1
	{
		get
		{
			return char_2;
		}
		set
		{
			char_2 = value;
		}
	}

	public HitMarkerOverlay()
	{
		IoCManager.InjectDependencies<HitMarkerOverlay>(this);
		((Overlay)this).ZIndex = 200;
		LoadTextures();
	}

	private void LoadTextures()
	{
		texture_0 = null;
		texture_1 = null;
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.AccessChecker.Enabled)
		{
			return;
		}
		if (gclass218_0 == null)
		{
			gclass218_0 = ientitySystemManager_0.GetEntitySystem<AccessCheckSystem>();
		}
		if (gclass218_0 == null)
		{
			return;
		}
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (!localEntity.HasValue || !ientityManager_0.HasComponent<TransformComponent>(localEntity.Value))
		{
			return;
		}
		DrawingHandleWorld worldHandle = ((OverlayDrawArgs)(ref args)).WorldHandle;
		IReadOnlyDictionary<EntityUid, bool> allCachedAccesses = gclass218_0.GetAllCachedAccesses();
		SharedTransformSystem val = ientityManager_0.System<SharedTransformSystem>();
		EntityUid? gridUid = ientityManager_0.GetComponent<TransformComponent>(localEntity.Value).GridUid;
		Matrix3x2 identity = Matrix3x2.Identity;
		Matrix3x2 result = Matrix3x2.Identity;
		bool flag = false;
		TransformComponent val2 = default(TransformComponent);
		if (gridUid.HasValue && ientityManager_0.TryGetComponent<TransformComponent>(gridUid.Value, ref val2))
		{
			identity = val.GetWorldMatrix(val2);
			Matrix3x2.Invert(identity, out result);
			flag = true;
			((DrawingHandleBase)worldHandle).SetTransform(ref identity);
		}
		TransformComponent val5 = default(TransformComponent);
		foreach (var (val4, flag3) in allCachedAccesses)
		{
			if (ientityManager_0.EntityExists(val4) && ientityManager_0.TryGetComponent<TransformComponent>(val4, ref val5) && !(val5.MapID != args.MapId))
			{
				EntityCoordinates coordinates = val5.Coordinates;
				Vector2 vector = ((EntityCoordinates)(ref coordinates)).ToMapPos(ientityManager_0, val);
				Vector2 position = ((!flag) ? vector : Vector2.Transform(vector, result));
				if (!flag3)
				{
					DrawCross(worldHandle, position, new Color(ref CerberusConfig.AccessChecker.CrossColor));
				}
				else
				{
					DrawCheckmark(worldHandle, position, new Color(ref CerberusConfig.AccessChecker.CheckmarkColor));
				}
			}
		}
		if (flag)
		{
			Matrix3x2 identity2 = Matrix3x2.Identity;
			((DrawingHandleBase)worldHandle).SetTransform(ref identity2);
		}
	}

	private void DrawCheckmark(DrawingHandleWorld handle, Vector2 position, Color color)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		float num = CerberusConfig.AccessChecker.IconSize / 1.8f;
		Vector2 vector = position + new Vector2((0f - num) * 0.5f, 0f);
		Vector2 vector2 = position + new Vector2((0f - num) * 0.2f, num * 0.4f);
		Vector2 vector3 = position + new Vector2(num * 0.6f, (0f - num) * 0.6f);
		((DrawingHandleBase)handle).DrawLine(vector, vector2, color);
		((DrawingHandleBase)handle).DrawLine(vector2, vector3, color);
	}

	private void DrawCross(DrawingHandleWorld handle, Vector2 position, Color color)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		float num = CerberusConfig.AccessChecker.IconSize / 1.8f;
		Vector2 vector = position + new Vector2(0f - num, 0f - num);
		Vector2 vector2 = position + new Vector2(num, num);
		Vector2 vector3 = position + new Vector2(0f - num, num);
		Vector2 vector4 = position + new Vector2(num, 0f - num);
		((DrawingHandleBase)handle).DrawLine(vector, vector2, color);
		((DrawingHandleBase)handle).DrawLine(vector3, vector4, color);
	}
}
