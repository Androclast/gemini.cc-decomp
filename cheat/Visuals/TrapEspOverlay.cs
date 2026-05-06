using System.Numerics;
using Content.Shared.Trigger.Components;
using Robust.Client.GameObjects;
using Robust.Client.Graphics;
using Robust.Client.ResourceManagement;
using Robust.Shared.Containers;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Maths;
using CerberusConfig;

public class TrapEspOverlay : Overlay
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IEyeManager ieyeManager_0;

	[Dependency]
	private readonly IResourceCache iresourceCache_0;

	private readonly Font font_0;

	private SharedTransformSystem sharedTransformSystem_0;

	private SharedContainerSystem sharedContainerSystem_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private long long_1;

	public override OverlaySpace Space => (OverlaySpace)2;

	private string String_0
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	private string String_1
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	private string String_2
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	private long Int64_0
	{
		get
		{
			return long_1;
		}
		set
		{
			long_1 = value;
		}
	}

	public TrapEspOverlay()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		IoCManager.InjectDependencies<TrapEspOverlay>(this);
		if (font_0 == null)
		{
			font_0 = (Font)new VectorFont(iresourceCache_0.GetResource<FontResource>("/Fonts/Boxfont-round/Boxfont Round.ttf", true), 12);
		}
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.Misc.ShowExplosive)
		{
			return;
		}
		if (sharedTransformSystem_0 == null)
		{
			sharedTransformSystem_0 = ientityManager_0.System<SharedTransformSystem>();
		}
		if (sharedContainerSystem_0 == null)
		{
			sharedContainerSystem_0 = ientityManager_0.System<SharedContainerSystem>();
		}
		EntityQueryEnumerator<ActiveTimerTriggerComponent> val = ientityManager_0.EntityQueryEnumerator<ActiveTimerTriggerComponent>();
		EntityUid val2 = default(EntityUid);
		ActiveTimerTriggerComponent val3 = default(ActiveTimerTriggerComponent);
		SpriteComponent val4 = default(SpriteComponent);
		while (val.MoveNext(ref val2, ref val3))
		{
			Vector2 vector = ieyeManager_0.WorldToScreen(sharedTransformSystem_0.GetWorldPosition(val2));
			Angle worldRotation = sharedTransformSystem_0.GetWorldRotation(val2);
			if (ientityManager_0.TryGetComponent<SpriteComponent>(val2, ref val4) && val4.Icon != null)
			{
				((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(font_0, vector + new Vector2(-35f, 20f), "Danger", Color.Red);
				if (sharedContainerSystem_0.IsEntityInContainer(val2, (MetaDataComponent)null))
				{
					((OverlayDrawArgs)(ref args)).ScreenHandle.DrawEntity(val2, vector, new Vector2(3f), (Angle?)DirectionExtensions.ToAngle(((Angle)(ref worldRotation)).GetDir()), ieyeManager_0.CurrentEye.Rotation, (Direction?)null, (SpriteComponent)null, (TransformComponent)null, (SharedTransformSystem)null);
					continue;
				}
				break;
			}
			break;
		}
	}
}
