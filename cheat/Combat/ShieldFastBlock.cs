using System;
using System.Collections.Generic;
using System.Numerics;
using Content.Shared.Actions;
using Content.Shared.Actions.Components;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Network;
using Robust.Shared.Player;
using Robust.Shared.Prototypes;
using Robust.Shared.Timing;
using CerberusConfig;

namespace ShieldFastBlock;

public sealed class ShieldFastBlock : EntitySystem
{
	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly SharedActionsSystem sharedActionsSystem_0;

	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly SharedTransformSystem sharedTransformSystem_0;

	[Dependency]
	private readonly IClientNetManager iclientNetManager_0;

	private readonly TimeSpan timeSpan_0 = TimeSpan.FromSeconds(0.4);

	private readonly TimeSpan timeSpan_1 = TimeSpan.FromMilliseconds(35L);

	private TimeSpan timeSpan_2 = TimeSpan.Zero;

	private TimeSpan timeSpan_3 = TimeSpan.Zero;

	private EntityUid? nullable_0;

	private DateTime dateTime_0 = DateTime.MinValue;

	private bool bool_1;

	private float float_1;

	private bool bool_2;

	private double double_0;

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

	private float Single_0
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	private bool Boolean_1
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
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

	public override void FrameUpdate(float frameTime)
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected I8, but got I4
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		if (CerberusConfig.Combat.AutoBlockEnabled && !CerberusConfig.Movement.ShieldSurfEnabled)
		{
			ICommonSession localSession = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
			EntityUid? val = ((localSession != null) ? localSession.AttachedEntity : ((EntityUid?)null));
			if (!val.HasValue)
			{
				return;
			}
			DateTime utcNow = DateTime.UtcNow;
			if ((utcNow - dateTime_0).TotalSeconds >= 5.0)
			{
				_ = HudUpdateSystem.list_0?.Count;
				dateTime_0 = utcNow;
			}
			if (UnsafeFastCheck(val.Value))
			{
				timeSpan_2 = igameTiming_0.CurTime;
			}
			if (igameTiming_0.CurTime < timeSpan_2 + timeSpan_0)
			{
				if (igameTiming_0.CurTime >= timeSpan_3 - TimeSpan.FromMilliseconds(15L))
				{
					SetBlockState(val.Value, active: true);
				}
			}
			else if (igameTiming_0.CurTime >= timeSpan_3)
			{
				SetBlockState(val.Value, active: false);
			}
		}
		else if (nullable_0.HasValue)
		{
			nullable_0 = null;
		}
	}

	private bool UnsafeFastCheck(EntityUid playerUid)
	{
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		List<(Vector2, Vector2, Vector2)> list_ = HudUpdateSystem.list_0;
		int count = list_.Count;
		if (count == 0)
		{
			return false;
		}
		TransformComponent component = ientityManager_0.GetComponent<TransformComponent>(playerUid);
		Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(component);
		float x = worldPosition.X;
		float y = worldPosition.Y;
		INetChannel serverChannel = iclientNetManager_0.ServerChannel;
		float num = (float)((serverChannel != null) ? serverChannel.Ping : 0) / 1000f + 0.15f;
		for (int i = 0; i < count; i++)
		{
			(Vector2, Vector2, Vector2) tuple = list_[i];
			float x2 = tuple.Item3.X;
			float y2 = tuple.Item3.Y;
			if (x2 * x2 + y2 * y2 < 25f)
			{
				continue;
			}
			float num2 = x - tuple.Item1.X;
			float num3 = y - tuple.Item1.Y;
			if (!(num2 * x2 + num3 * y2 >= 0f))
			{
				continue;
			}
			float num4 = tuple.Item1.X + x2 * num;
			float num5 = tuple.Item1.Y + y2 * num;
			float num6 = x - num4;
			float num7 = y - num5;
			float num8 = x2 * x2 + y2 * y2;
			if (!(num8 <= 0.0001f))
			{
				float num9 = (num6 * x2 + num7 * y2) / num8;
				float num10 = num4 + x2 * num9;
				float num11 = num5 + y2 * num9;
				if ((x - num10) * (x - num10) + (y - num11) * (y - num11) < 0.81f && num9 > -0.2f && num6 * num6 + num7 * num7 < 225f)
				{
					return true;
				}
			}
		}
		return false;
	}

	private void SetBlockState(EntityUid user, bool active)
	{
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		ActionsComponent val = default(ActionsComponent);
		if (!ientityManager_0.TryGetComponent<ActionsComponent>(user, ref val))
		{
			return;
		}
		if (nullable_0.HasValue)
		{
			if (FastToggle(nullable_0.Value, active))
			{
				return;
			}
			nullable_0 = null;
		}
		MetaDataComponent val2 = default(MetaDataComponent);
		foreach (EntityUid action2 in val.Actions)
		{
			Entity<ActionComponent>? action = sharedActionsSystem_0.GetAction((Entity<ActionComponent>?)Entity<ActionComponent>.op_Implicit(action2), true);
			if (!action.HasValue)
			{
				continue;
			}
			action.GetValueOrDefault();
			if (ientityManager_0.TryGetComponent<MetaDataComponent>(action2, ref val2))
			{
				EntityPrototype entityPrototype = val2.EntityPrototype;
				if (((entityPrototype == null) ? null : entityPrototype.ID) == "ActionToggleBlock")
				{
					nullable_0 = action2;
					FastToggle(action2, active);
					break;
				}
			}
		}
	}

	private bool FastToggle(EntityUid actionId, bool wantActive)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		Entity<ActionComponent>? action = sharedActionsSystem_0.GetAction((Entity<ActionComponent>?)Entity<ActionComponent>.op_Implicit(actionId), true);
		if (!action.HasValue)
		{
			return false;
		}
		Entity<ActionComponent> valueOrDefault = action.GetValueOrDefault();
		if (valueOrDefault.Comp.Toggled != wantActive)
		{
			if (!valueOrDefault.Comp.Cooldown.HasValue || !(igameTiming_0.CurTime < valueOrDefault.Comp.Cooldown.Value.End))
			{
				RequestPerformActionEvent val = new RequestPerformActionEvent(ientityManager_0.GetNetEntity(actionId, (MetaDataComponent)null));
				ientityManager_0.RaisePredictiveEvent<RequestPerformActionEvent>(val);
				timeSpan_3 = igameTiming_0.CurTime + timeSpan_1;
				return true;
			}
			return true;
		}
		return true;
	}
}
