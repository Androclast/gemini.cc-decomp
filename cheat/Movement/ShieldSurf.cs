using System;
using System.Numerics;
using Content.Shared.Actions;
using Content.Shared.Actions.Components;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Map.Components;
using Robust.Shared.Maths;
using Robust.Shared.Physics.Components;
using Robust.Shared.Player;
using Robust.Shared.Prototypes;
using Robust.Shared.Timing;
using CerberusConfig;

namespace ShieldSurf;

public sealed class ShieldSurf : EntitySystem
{
	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly SharedTransformSystem sharedTransformSystem_0;

	[Dependency]
	private readonly IMapManager imapManager_0;

	private Vector2i vector2i_0 = Vector2i.Zero;

	private Vector2i vector2i_1 = new Vector2i(-9999, -9999);

	private bool bool_0;

	private TimeSpan timeSpan_0 = TimeSpan.Zero;

	private EntityUid? nullable_0;

	private bool bool_1;

	private bool bool_2;

	private readonly TimeSpan timeSpan_1 = TimeSpan.FromMilliseconds(25L);

	private float float_0;

	private byte byte_0;

	private string string_0;

	private double double_1;

	private long long_1;

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
			return double_1;
		}
		set
		{
			double_1 = value;
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

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
		float shieldSurfRadius = CerberusConfig.Movement.ShieldSurfRadius;
		float_0 = shieldSurfRadius * shieldSurfRadius;
		bool_2 = CerberusConfig.Movement.ShieldSurfEnabled;
	}

	public override void FrameUpdate(float frameTime)
	{
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		HandleKeybind();
		if (bool_2 && !CerberusConfig.Movement.ShieldSurfEnabled && bool_0)
		{
			ForceStopShield();
		}
		bool_2 = CerberusConfig.Movement.ShieldSurfEnabled;
		if (!CerberusConfig.Movement.ShieldSurfEnabled)
		{
			bool_0 = false;
			return;
		}
		float shieldSurfRadius = CerberusConfig.Movement.ShieldSurfRadius;
		float_0 = shieldSurfRadius * shieldSurfRadius;
		ICommonSession localSession = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
		EntityUid? val = ((localSession == null) ? ((EntityUid?)null) : localSession.AttachedEntity);
		if (!val.HasValue)
		{
			return;
		}
		PhysicsComponent val2 = default(PhysicsComponent);
		if (ientityManager_0.TryGetComponent<PhysicsComponent>(val.Value, ref val2) && val2.LinearVelocity.LengthSquared() >= 0.1f)
		{
			if (!bool_0 || !(igameTiming_0.CurTime >= timeSpan_0))
			{
				TransformComponent component = ientityManager_0.GetComponent<TransformComponent>(val.Value);
				Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(component);
				EntityUid val3 = default(EntityUid);
				MapGridComponent val4 = default(MapGridComponent);
				if (!imapManager_0.TryFindGridAt(component.MapID, worldPosition, ref val3, ref val4))
				{
					if (bool_0)
					{
						StopBoost(val.Value);
					}
					return;
				}
				TransformComponent component2 = ientityManager_0.GetComponent<TransformComponent>(val3);
				Matrix3x2 invWorldMatrix = sharedTransformSystem_0.GetInvWorldMatrix(component2);
				Vector2 vector = Vector2.Transform(new Vector2(worldPosition.X, worldPosition.Y), invWorldMatrix);
				int num = (int)Math.Floor(vector.X / (float)(int)val4.TileSize);
				int num2 = (int)Math.Floor(vector.Y / (float)(int)val4.TileSize);
				Vector2i val5 = default(Vector2i);
				((Vector2i)(ref val5))._002Ector(num, num2);
				if (!(val5 == vector2i_1))
				{
					float num3 = ((float)num + 0.5f) * (float)(int)val4.TileSize;
					float num4 = ((float)num2 + 0.5f) * (float)(int)val4.TileSize;
					float num5 = vector.X - num3;
					float num6 = vector.Y - num4;
					if (!(num5 * num5 + num6 * num6 >= float_0) && ToggleAction(val.Value, state: true))
					{
						bool_0 = true;
						timeSpan_0 = igameTiming_0.CurTime + timeSpan_1;
						vector2i_1 = val5;
					}
				}
			}
			else
			{
				StopBoost(val.Value);
			}
		}
		else if (bool_0)
		{
			StopBoost(val.Value);
		}
	}

	private void HandleKeybind()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		if ((int)CerberusConfig.Movement.ToggleKey != 0)
		{
			bool flag = KeyStateHelper.IsKeyDown(CerberusConfig.Movement.ToggleKey);
			if (flag && !bool_1)
			{
				CerberusConfig.Movement.ShieldSurfEnabled = !CerberusConfig.Movement.ShieldSurfEnabled;
			}
			bool_1 = flag;
		}
	}

	private void ForceStopShield()
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		ICommonSession localSession = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
		EntityUid? val = ((localSession == null) ? ((EntityUid?)null) : localSession.AttachedEntity);
		if (val.HasValue)
		{
			ToggleAction(val.Value, state: false);
		}
		bool_0 = false;
		vector2i_1 = new Vector2i(-9999, -9999);
	}

	private void StopBoost(EntityUid? uid)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		if (uid.HasValue)
		{
			ToggleAction(uid.Value, state: false);
		}
		bool_0 = false;
	}

	private bool ToggleAction(EntityUid user, bool state)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		ActionsComponent val = default(ActionsComponent);
		if (ientityManager_0.TryGetComponent<ActionsComponent>(user, ref val))
		{
			if (nullable_0.HasValue)
			{
				if (FastProcess(nullable_0.Value, state))
				{
					return true;
				}
				nullable_0 = null;
			}
			MetaDataComponent val2 = default(MetaDataComponent);
			foreach (EntityUid action in val.Actions)
			{
				if (ientityManager_0.EntityExists(action) && ientityManager_0.TryGetComponent<MetaDataComponent>(action, ref val2))
				{
					EntityPrototype entityPrototype = val2.EntityPrototype;
					if (((entityPrototype == null) ? null : entityPrototype.ID) == "ActionToggleBlock")
					{
						nullable_0 = action;
						return FastProcess(action, state);
					}
				}
			}
			return false;
		}
		return false;
	}

	private bool FastProcess(EntityUid actionId, bool wantState)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		ActionComponent val = default(ActionComponent);
		if (!ientityManager_0.TryGetComponent<ActionComponent>(actionId, ref val))
		{
			return false;
		}
		if (val.Toggled != wantState)
		{
			RequestPerformActionEvent val2 = new RequestPerformActionEvent(ientityManager_0.GetNetEntity(actionId, (MetaDataComponent)null));
			ientityManager_0.RaisePredictiveEvent<RequestPerformActionEvent>(val2);
			return true;
		}
		return true;
	}
}
