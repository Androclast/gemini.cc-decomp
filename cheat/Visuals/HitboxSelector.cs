using System.Collections.Generic;
using System.Numerics;
using Hexa.NET.ImGui;
using Robust.Client.GameObjects;
using Robust.Client.Graphics;
using Robust.Client.Input;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using Robust.Shared.Player;
using DamageableHelper;
using DamageBreakdownOverlay;
using CerberusConfig;

namespace HitboxSelector;

public sealed class HitboxSelector : EntitySystem
{
	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IEyeManager ieyeManager_0;

	[Dependency]
	private readonly IInputManager iinputManager_0;

	[Dependency]
	private readonly EntityLookupSystem entityLookupSystem_0;

	[Dependency]
	private readonly SharedTransformSystem sharedTransformSystem_0;

	[Dependency]
	private readonly IEntityManager ientityManager_0;

	private bool bool_0;

	private float float_0;

	private long long_1;

	private string string_0;

	private int int_0;

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

	private string String_0
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

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

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
		DamageableHelper.Initialize();
	}

	public override void Update(float frameTime)
	{
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		((EntitySystem)this).Update(frameTime);
		if (!CerberusConfig.HealthInfo.Enabled)
		{
			if (DamageBreakdownOverlay.Instance != null)
			{
				DamageBreakdownOverlay.Instance.Selected = null;
				DamageBreakdownOverlay.Instance.LockedTarget = null;
			}
			return;
		}
		float_0 += frameTime;
		if (!(float_0 >= 0.1f))
		{
			return;
		}
		float_0 = 0f;
		bool flag = ImGui.IsKeyDown(CerberusConfig.HealthInfo.HoldKey);
		if (!flag || bool_0)
		{
			if (!flag && bool_0 && DamageBreakdownOverlay.Instance != null)
			{
				DamageBreakdownOverlay.Instance.LockedTarget = null;
			}
		}
		else if (DamageBreakdownOverlay.Instance != null && DamageBreakdownOverlay.Instance.Selected.HasValue)
		{
			DamageBreakdownOverlay.Instance.LockedTarget = DamageBreakdownOverlay.Instance.Selected;
		}
		bool_0 = flag;
		TrySelectEntity();
	}

	private void TrySelectEntity()
	{
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		ICommonSession localSession = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
		EntityUid? val = ((localSession != null) ? localSession.AttachedEntity : ((EntityUid?)null));
		if (!val.HasValue)
		{
			return;
		}
		ScreenCoordinates mouseScreenPosition = iinputManager_0.MouseScreenPosition;
		MapCoordinates val2 = ieyeManager_0.PixelToMap(mouseScreenPosition);
		if (val2.MapId == MapId.Nullspace)
		{
			return;
		}
		Vector2 position = val2.Position;
		MapId mapId = val2.MapId;
		float num = 0.4f;
		Box2 val3 = Box2.CenteredAround(position, new Vector2(num * 2f, num * 2f));
		HashSet<EntityUid> entitiesIntersecting = entityLookupSystem_0.GetEntitiesIntersecting(mapId, val3, (LookupFlags)7);
		EntityUid? selected = null;
		float num2 = float.MaxValue;
		SpriteComponent val4 = default(SpriteComponent);
		foreach (EntityUid item in entitiesIntersecting)
		{
			if (!(item == val.Value) && HasDamageableComponent(item) && (!((EntitySystem)this).TryComp<SpriteComponent>(item, ref val4) || val4.Visible))
			{
				float num3 = (sharedTransformSystem_0.GetWorldPosition(item) - position).LengthSquared();
				if (num3 < num2)
				{
					num2 = num3;
					selected = item;
				}
			}
		}
		if (DamageBreakdownOverlay.Instance != null)
		{
			DamageBreakdownOverlay.Instance.Selected = selected;
		}
	}

	private bool HasDamageableComponent(EntityUid entity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return DamageableHelper.HasDamageableComponent(entity, ientityManager_0);
	}
}
