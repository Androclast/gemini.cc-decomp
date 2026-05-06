using System;
using System.Numerics;
using System.Runtime.InteropServices;
using Content.Shared.Actions;
using Content.Shared.Actions.Components;
using Content.Shared.Movement.Components;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using CerberusConfig;

namespace AutoJumpDash;

public sealed class AutoJumpDash : EntitySystem
{
	[StructLayout(LayoutKind.Auto)]
	public struct GEnum2 : Enum
	{
	}

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly SharedActionsSystem sharedActionsSystem_0;

	private int int_0;

	private TimeSpan timeSpan_0 = TimeSpan.Zero;

	private float float_0;

	private char char_0;

	private string string_0;

	private double double_0;

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

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
	}

	public override void Update(float frameTime)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		((EntitySystem)this).Update(frameTime);
		if (!CerberusConfig.AbilitySpeed.Enabled)
		{
			return;
		}
		float_0 += frameTime;
		if (!(float_0 >= 0.05f))
		{
			return;
		}
		float_0 = 0f;
		int_0 = CerberusConfig.AbilitySpeed.Mode;
		if (int_0 == 0)
		{
			return;
		}
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (!localEntity.HasValue)
		{
			return;
		}
		TimeSpan timeSpan = TimeSpan.FromMilliseconds(CerberusConfig.AbilitySpeed.DelayMs);
		if (igameTiming_0.CurTime < timeSpan_0 + timeSpan)
		{
			return;
		}
		switch (int_0)
		{
		case 1:
			TryUseJump(localEntity.Value);
			break;
		case 3:
			if (!TryUseDash(localEntity.Value))
			{
				TryUseJump(localEntity.Value);
			}
			break;
		case 2:
			TryUseDash(localEntity.Value);
			break;
		}
	}

	private bool TryUseJump(EntityUid player)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		JumpAbilityComponent val = default(JumpAbilityComponent);
		if (!((EntitySystem)this).TryComp<JumpAbilityComponent>(player, ref val))
		{
			return false;
		}
		ActionsComponent val2 = default(ActionsComponent);
		if (((EntitySystem)this).TryComp<ActionsComponent>(player, ref val2))
		{
			ActionComponent val3 = default(ActionComponent);
			InstantActionComponent val4 = default(InstantActionComponent);
			foreach (EntityUid action in val2.Actions)
			{
				if (!((EntitySystem)this).TryComp<ActionComponent>(action, ref val3) || !((EntitySystem)this).TryComp<InstantActionComponent>(action, ref val4) || (val3.Cooldown.HasValue && igameTiming_0.CurTime < val3.Cooldown.Value.End) || !val3.Enabled)
				{
					continue;
				}
				sharedActionsSystem_0.PerformAction(Entity<ActionsComponent>.op_Implicit(player), Entity<ActionComponent>.op_Implicit((action, val3)), (BaseActionEvent)null, false);
				timeSpan_0 = igameTiming_0.CurTime;
				goto IL_00db;
			}
			return false;
		}
		return false;
		IL_00db:
		return true;
	}

	private bool TryUseDash(EntityUid player)
	{
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		ActionsComponent val = default(ActionsComponent);
		if (((EntitySystem)this).TryComp<ActionsComponent>(player, ref val))
		{
			ActionComponent val2 = default(ActionComponent);
			WorldTargetActionComponent val3 = default(WorldTargetActionComponent);
			foreach (EntityUid action in val.Actions)
			{
				if (!((EntitySystem)this).TryComp<ActionComponent>(action, ref val2) || !((EntitySystem)this).TryComp<WorldTargetActionComponent>(action, ref val3) || (val2.Cooldown.HasValue && igameTiming_0.CurTime < val2.Cooldown.Value.End) || !val2.Enabled)
				{
					continue;
				}
				EntityCoordinates? dashTarget = GetDashTarget(player);
				if (dashTarget.HasValue)
				{
					BaseActionEvent obj = sharedActionsSystem_0.GetEvent(action);
					WorldTargetActionEvent val4 = (WorldTargetActionEvent)(object)((obj is WorldTargetActionEvent) ? obj : null);
					if (val4 != null)
					{
						val4.Target = dashTarget.Value;
						sharedActionsSystem_0.PerformAction(Entity<ActionsComponent>.op_Implicit(player), Entity<ActionComponent>.op_Implicit((action, val2)), (BaseActionEvent)(object)val4, false);
						timeSpan_0 = igameTiming_0.CurTime;
						goto IL_0109;
					}
					continue;
				}
			}
			return false;
		}
		return false;
		IL_0109:
		return true;
	}

	private EntityCoordinates? GetDashTarget(EntityUid player)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		TransformComponent val = default(TransformComponent);
		if (((EntitySystem)this).TryComp<TransformComponent>(player, ref val))
		{
			Angle localRotation = val.LocalRotation;
			Vector2 vector = ((Angle)(ref localRotation)).ToWorldVec();
			float dashDistance = CerberusConfig.AbilitySpeed.DashDistance;
			Vector2 vector2 = vector * dashDistance;
			EntityCoordinates coordinates = val.Coordinates;
			return ((EntityCoordinates)(ref coordinates)).Offset(vector2);
		}
		return null;
	}
}
