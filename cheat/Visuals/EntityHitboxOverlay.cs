using System.Collections.Generic;
using System.Numerics;
using Content.Shared.Item;
using Content.Shared.Mobs.Components;
using Robust.Client.Graphics;
using Robust.Client.Player;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using Robust.Shared.Physics.Components;
using Robust.Shared.Player;
using CerberusConfig;

namespace EntityHitboxOverlay;

public sealed class EntityHitboxOverlay : Overlay
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	private EntityLookupSystem entityLookupSystem_0;

	private SharedTransformSystem sharedTransformSystem_0;

	private float float_0;

	private readonly List<(EntityUid, Vector2, Vector4)> list_0 = new List<(EntityUid, Vector2, Vector4)>();

	private float float_2;

	private float float_3;

	private float float_4;

	public override OverlaySpace Space => (OverlaySpace)4;

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

	private float Single_1
	{
		get
		{
			return float_3;
		}
		set
		{
			float_3 = value;
		}
	}

	private float Single_2
	{
		get
		{
			return float_4;
		}
		set
		{
			float_4 = value;
		}
	}

	public EntityHitboxOverlay()
	{
		IoCManager.InjectDependencies<EntityHitboxOverlay>(this);
		((Overlay)this).ZIndex = 200;
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.HitboxVisualizer.Enabled)
		{
			return;
		}
		if (entityLookupSystem_0 == null)
		{
			entityLookupSystem_0 = ientityManager_0.System<EntityLookupSystem>();
		}
		if (sharedTransformSystem_0 == null)
		{
			sharedTransformSystem_0 = ientityManager_0.System<SharedTransformSystem>();
		}
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (!localEntity.HasValue)
		{
			return;
		}
		DrawingHandleWorld worldHandle = ((OverlayDrawArgs)(ref args)).WorldHandle;
		Box2Rotated worldBounds = args.WorldBounds;
		Box2 val = ((Box2Rotated)(ref worldBounds)).CalcBoundingBox();
		Box2 viewport = ((Box2)(ref val)).Enlarged(10f);
		float_0 += 1f / 60f;
		if (float_0 >= 0.2f || list_0.Count == 0)
		{
			UpdateEntityCache(args.MapId, viewport, localEntity.Value);
			float_0 = 0f;
		}
		PhysicsComponent physics = default(PhysicsComponent);
		foreach (var (val2, pos, colorVec) in list_0)
		{
			if (ientityManager_0.TryGetComponent<PhysicsComponent>(val2, ref physics))
			{
				DrawEntityHitbox(worldHandle, val2, physics, pos, colorVec);
			}
		}
	}

	private void UpdateEntityCache(MapId mapId, Box2 viewport, EntityUid localPlayer)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		list_0.Clear();
		HashSet<EntityUid> entitiesIntersecting = entityLookupSystem_0.GetEntitiesIntersecting(mapId, viewport, (LookupFlags)6);
		int num = 0;
		TransformComponent val = default(TransformComponent);
		foreach (EntityUid item2 in entitiesIntersecting)
		{
			if (num >= 50)
			{
				break;
			}
			if (item2 == localPlayer)
			{
				continue;
			}
			Vector4 item = CerberusConfig.HitboxVisualizer.OtherColor;
			bool flag = false;
			if (ientityManager_0.HasComponent<MobStateComponent>(item2))
			{
				if (CerberusConfig.HitboxVisualizer.ShowPlayers || CerberusConfig.HitboxVisualizer.ShowAll)
				{
					item = CerberusConfig.HitboxVisualizer.PlayerColor;
					flag = true;
				}
			}
			else if (ientityManager_0.HasComponent<ItemComponent>(item2))
			{
				if (CerberusConfig.HitboxVisualizer.ShowItems || CerberusConfig.HitboxVisualizer.ShowAll)
				{
					item = CerberusConfig.HitboxVisualizer.ItemColor;
					flag = true;
				}
			}
			else if (CerberusConfig.HitboxVisualizer.ShowAll)
			{
				flag = true;
			}
			if (flag && ientityManager_0.TryGetComponent<TransformComponent>(item2, ref val))
			{
				Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(val);
				list_0.Add((item2, worldPosition, item));
				num++;
			}
		}
	}

	private void DrawEntityHitbox(DrawingHandleWorld worldHandle, EntityUid uid, PhysicsComponent physics, Vector2 pos, Vector4 colorVec)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		Color val = default(Color);
		((Color)(ref val))._002Ector(colorVec.X, colorVec.Y, colorVec.Z, colorVec.W);
		Box2 worldAABB = entityLookupSystem_0.GetWorldAABB(uid, (TransformComponent)null);
		Vector2 vector = new Vector2(worldAABB.Left, worldAABB.Top);
		Vector2 vector2 = new Vector2(worldAABB.Right, worldAABB.Top);
		Vector2 vector3 = new Vector2(worldAABB.Left, worldAABB.Bottom);
		Vector2 vector4 = new Vector2(worldAABB.Right, worldAABB.Bottom);
		((DrawingHandleBase)worldHandle).DrawLine(vector, vector2, val);
		((DrawingHandleBase)worldHandle).DrawLine(vector2, vector4, val);
		((DrawingHandleBase)worldHandle).DrawLine(vector4, vector3, val);
		((DrawingHandleBase)worldHandle).DrawLine(vector3, vector, val);
	}

	private string method_4(int int_1)
	{
		return "Хитролох_иди_нахуй._8__2___7____";
	}
}
