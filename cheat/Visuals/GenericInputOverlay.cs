using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using Robust.Client.Graphics;
using Robust.Client.Input;
using Robust.Client.Player;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using Robust.Shared.Physics;
using Robust.Shared.Physics.Systems;
using Robust.Shared.Player;
using CerberusConfig;

[CompilerGenerated]
public sealed class GenericInputOverlay : Overlay
{
	private Vector2 vector2_0;

	private Vector2 vector2_1;

	private Color color_0;

	private int int_0;

	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IEyeManager ieyeManager_0;

	[Dependency]
	private readonly IInputManager iinputManager_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	private SharedPhysicsSystem sharedPhysicsSystem_0;

	private SharedTransformSystem sharedTransformSystem_0;

	private int int_1;

	private double double_0;

	private byte byte_0;

	private byte byte_1;

	public override OverlaySpace Space => (OverlaySpace)4;

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

	private byte Byte_1
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

	public GenericInputOverlay()
	{
		IoCManager.InjectDependencies<GenericInputOverlay>(this);
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.Misc.ShowTrajectory)
		{
			return;
		}
		if (sharedPhysicsSystem_0 == null)
		{
			sharedPhysicsSystem_0 = ientityManager_0.System<SharedPhysicsSystem>();
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
		MapCoordinates val = ieyeManager_0.PixelToMap(iinputManager_0.MouseScreenPosition);
		if (!(val.MapId != sharedTransformSystem_0.GetMapId(Entity<TransformComponent>.op_Implicit(localEntity.Value))))
		{
			int_0++;
			if (int_0 >= 2)
			{
				int_0 = 0;
				vector2_1 = sharedTransformSystem_0.GetWorldPosition(localEntity.Value);
				vector2_0 = RayCast(localEntity.Value, val);
				color_0 = ((vector2_0 == val.Position) ? Color.Green : Color.Red);
			}
			((DrawingHandleBase)((OverlayDrawArgs)(ref args)).WorldHandle).DrawLine(vector2_1, vector2_0, color_0);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private Vector2 RayCast(EntityUid player, MapCoordinates targetPos)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		MapCoordinates mapCoordinates = sharedTransformSystem_0.GetMapCoordinates(player, (TransformComponent)null);
		Vector2 position = targetPos.Position;
		Vector2 vector = position - mapCoordinates.Position;
		float num = vector.Length();
		CollisionRay val = default(CollisionRay);
		((CollisionRay)(ref val))._002Ector(mapCoordinates.Position, Vector2Helpers.Normalized(vector), 2);
		RayCastResults val2 = sharedPhysicsSystem_0.IntersectRay(mapCoordinates.MapId, val, num, (EntityUid?)player, true).FirstOrDefault();
		EntityUid hitEntity = ((RayCastResults)(ref val2)).HitEntity;
		if (((EntityUid)(ref hitEntity)).IsValid())
		{
			return ((RayCastResults)(ref val2)).HitPos;
		}
		return position;
	}
}
