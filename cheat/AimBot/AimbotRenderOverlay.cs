using System;
using System.Collections;
using System.Numerics;
using System.Reflection;
using Content.Client.Weapons.Ranged.Systems;
using Content.Shared.CombatMode;
using Content.Shared.Weapons.Ranged.Components;
using Content.Shared.Weapons.Ranged.Systems;
using HarmonyLib;
using Robust.Client.Graphics;
using Robust.Client.Input;
using Robust.Client.Player;
using Robust.Shared.Configuration;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using Robust.Shared.Network;
using Robust.Shared.Physics.Components;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using GunHelper;
using CerberusConfig;

public sealed class AimbotRenderOverlay : Overlay
{
	private Angle angle_0;

	private bool bool_0;

	private int int_0;

	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IEyeManager ieyeManager_0;

	[Dependency]
	private readonly IInputManager iinputManager_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IEntitySystemManager ientitySystemManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly IConfigurationManager iconfigurationManager_0;

	[Dependency]
	private readonly IClientNetManager iclientNetManager_0;

	private GunTargetSelector gclass11_0;

	private EntityUid entityUid_0;

	private EntityUid? nullable_0;

	public EntityCoordinates? nullable_1;

	public Vector2 vector2_0;

	private byte byte_2;

	private bool bool_1;

	private char char_0;

	public override OverlaySpace Space => (OverlaySpace)4;

	public EntityUid? CurrentGunTarget => nullable_0;

	private byte Byte_0
	{
		get
		{
			return byte_2;
		}
		set
		{
			byte_2 = value;
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

	public AimbotRenderOverlay()
	{
		IoCManager.InjectDependencies<AimbotRenderOverlay>(this);
	}

	protected override void FrameUpdate(FrameEventArgs args)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		MapCoordinates val = ieyeManager_0.PixelToMap(iinputManager_0.MouseScreenPosition);
		if (val.MapId != MapId.Nullspace)
		{
			vector2_0 = val.Position;
		}
		bool_0 = false;
		if (CerberusConfig.GunAimBot.Enabled)
		{
			if (gclass11_0 == null)
			{
				gclass11_0 = ientitySystemManager_0.GetEntitySystem<GunTargetSelector>();
			}
			EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
			CombatModeComponent val2 = default(CombatModeComponent);
			if (!localEntity.HasValue || gclass11_0 == null)
			{
				Reset();
			}
			else if (ientityManager_0.TryGetComponent<CombatModeComponent>(localEntity.Value, ref val2) && val2.IsInCombatMode)
			{
				if (GunHelper.TryGetGunSafe((SharedGunSystem)(object)ientitySystemManager_0.GetEntitySystem<GunSystem>(), localEntity.Value, out Entity<GunComponent> gunEntity))
				{
					bool_0 = true;
					entityUid_0 = gunEntity.Owner;
					GunComponent comp = gunEntity.Comp;
					double totalSeconds = (igameTiming_0.CurTime - comp.NextFire).TotalSeconds;
					double num = comp.CurrentAngle.Theta - comp.AngleDecayModified.Theta * totalSeconds;
					num = MathHelper.Clamp(num, comp.MinAngleModified.Theta, comp.MaxAngleModified.Theta);
					angle_0 = new Angle(num);
					nullable_0 = GetTarget(localEntity.Value, vector2_0);
					CerberusConfig.HudOverlay.CurrentTarget = nullable_0;
					if (!nullable_0.HasValue)
					{
						nullable_1 = null;
						return;
					}
					if (CerberusConfig.GunAimBot.PredictEnabled && ientityManager_0.HasComponent<TransformComponent>(nullable_0.Value) && ientityManager_0.HasComponent<PhysicsComponent>(nullable_0.Value))
					{
						float projectileSpeedModified = comp.ProjectileSpeedModified;
						Vector2 predictedWorldShootPosition = ProjectilePredictor.GetPredictedWorldShootPosition(localEntity.Value, nullable_0.Value, projectileSpeedModified);
						if (predictedWorldShootPosition != Vector2.Zero)
						{
							EntityUid? mapUid = ientityManager_0.GetComponent<TransformComponent>(localEntity.Value).MapUid;
							if (mapUid.HasValue)
							{
								SharedTransformSystem entitySystem = ientitySystemManager_0.GetEntitySystem<SharedTransformSystem>();
								Vector2 vector = Vector2.Transform(predictedWorldShootPosition, entitySystem.GetInvWorldMatrix(mapUid.Value));
								nullable_1 = new EntityCoordinates(mapUid.Value, vector);
							}
							else
							{
								nullable_1 = null;
							}
						}
					}
					else
					{
						nullable_1 = null;
					}
					HandleShooting(comp);
				}
				else
				{
					Reset();
				}
			}
			else
			{
				Reset();
			}
		}
		else
		{
			Reset();
		}
	}

	private void Reset()
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		nullable_0 = null;
		nullable_1 = null;
		EntityUid? currentTarget = CerberusConfig.HudOverlay.CurrentTarget;
		EntityUid? val = nullable_0;
		if (currentTarget.HasValue == val.HasValue && (!currentTarget.HasValue || currentTarget.GetValueOrDefault() == val.GetValueOrDefault()))
		{
			CerberusConfig.HudOverlay.CurrentTarget = null;
		}
	}

	private void HandleShooting(GunComponent gunComponent)
	{
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		if (nullable_0.HasValue && ientityManager_0.EntityExists(nullable_0.Value) && ientityManager_0.EntityExists(entityUid_0) && KeyStateHelper.IsKeyDown(CerberusConfig.GunAimBot.HotKey) && !(gunComponent.NextFire > igameTiming_0.CurTime))
		{
			bool flag = true;
			if (CerberusConfig.GunAimBot.MinSpread && !(Angle.op_Implicit(angle_0) <= Angle.op_Implicit(gunComponent.MinAngleModified + Angle.FromDegrees(1.0))))
			{
				SharedTransformSystem entitySystem = ientitySystemManager_0.GetEntitySystem<SharedTransformSystem>();
				Vector2 worldPosition = entitySystem.GetWorldPosition(ientityManager_0.GetComponent<TransformComponent>(((ISharedPlayerManager)iplayerManager_0).LocalEntity.Value));
				Vector2 vector = ((!nullable_1.HasValue) ? entitySystem.GetWorldPosition(ientityManager_0.GetComponent<TransformComponent>(nullable_0.Value)) : entitySystem.ToMapCoordinates(nullable_1.Value, true).Position);
				flag = !((vector - worldPosition).Length() * (float)Math.Tan(angle_0.Theta) >= 0.6f);
			}
			if (flag)
			{
				EntityCoordinates coords = ((!nullable_1.HasValue) ? ientityManager_0.GetComponent<TransformComponent>(nullable_0.Value).Coordinates : nullable_1.Value);
				EntityEventArgs e = CreateShootEvent(coords, entityUid_0, nullable_0.Value);
				ientityManager_0.RaisePredictiveEvent<EntityEventArgs>(e);
				int_0++;
				AimbotMovementSystem.OnBotFired();
			}
		}
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Invalid comparison between Unknown and I4
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.GunAimBot.Enabled || !bool_0 || (int)args.Space != 4)
		{
			return;
		}
		if (!ProjectilePredictor._isInitialized)
		{
			ProjectilePredictor.InitializeDependencies(iclientNetManager_0, igameTiming_0, iconfigurationManager_0, ientityManager_0);
		}
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (!localEntity.HasValue || args.MapId == MapId.Nullspace)
		{
			return;
		}
		if (CerberusConfig.GunAimBot.ShowCircle)
		{
			((DrawingHandleBase)((OverlayDrawArgs)(ref args)).WorldHandle).DrawCircle(vector2_0, CerberusConfig.GunAimBot.CircleRadius, new Color(ref CerberusConfig.GunAimBot.Color), false);
		}
		TransformComponent val = default(TransformComponent);
		if (!CerberusConfig.GunAimBot.ShowLine || !nullable_0.HasValue || !ientityManager_0.TryGetComponent<TransformComponent>(nullable_0.Value, ref val))
		{
			return;
		}
		SharedTransformSystem entitySystem = ientitySystemManager_0.GetEntitySystem<SharedTransformSystem>();
		TransformComponent val2 = default(TransformComponent);
		if (ientityManager_0.TryGetComponent<TransformComponent>(localEntity.Value, ref val2))
		{
			Vector2 worldPosition = entitySystem.GetWorldPosition(val2);
			if (!nullable_1.HasValue)
			{
				Vector2 worldPosition2 = entitySystem.GetWorldPosition(val);
				((DrawingHandleBase)((OverlayDrawArgs)(ref args)).WorldHandle).DrawLine(worldPosition, worldPosition2, new Color(ref CerberusConfig.GunAimBot.Color));
			}
			else
			{
				Vector2 position = entitySystem.ToMapCoordinates(nullable_1.Value, true).Position;
				((DrawingHandleBase)((OverlayDrawArgs)(ref args)).WorldHandle).DrawLine(worldPosition, position, Color.LimeGreen);
				((DrawingHandleBase)((OverlayDrawArgs)(ref args)).WorldHandle).DrawCircle(position, 0.15f, Color.LimeGreen, true);
			}
		}
	}

	private EntityUid? GetTarget(EntityUid playerEnt, Vector2 circleCenter)
	{
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		if (gclass11_0 != null)
		{
			if (!CerberusConfig.GunAimBot.MultiTarget)
			{
				return CerberusConfig.GunAimBot.TargetPriority switch
				{
					2 => gclass11_0.GetHighestHealthTarget(circleCenter, CerberusConfig.GunAimBot.CircleRadius, CerberusConfig.GunAimBot.TargetCritical, this), 
					0 => gclass11_0.GetClosestTargetToPlayer(playerEnt, circleCenter, CerberusConfig.GunAimBot.CircleRadius, CerberusConfig.GunAimBot.TargetCritical, this), 
					1 => gclass11_0.GetClosestTargetToMouse(circleCenter, CerberusConfig.GunAimBot.CircleRadius, CerberusConfig.GunAimBot.TargetCritical, this), 
					_ => null, 
				};
			}
			return gclass11_0.GetNextMultiTarget(playerEnt, circleCenter, CerberusConfig.GunAimBot.CircleRadius, CerberusConfig.GunAimBot.TargetCritical, this, int_0);
		}
		return null;
	}

	private EntityEventArgs CreateShootEvent(EntityCoordinates coords, EntityUid gunUid, EntityUid targetUid)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		Type type = AccessTools.TypeByName("Content.Shared.Weapons.Ranged.Events.RequestShootEvent");
		EntityEventArgs e = (EntityEventArgs)AccessTools.CreateInstance(type);
		AccessTools.Field(type, "Gun").SetValue(e, ientityManager_0.GetNetEntity(gunUid, (MetaDataComponent)null));
		AccessTools.Field(type, "Coordinates").SetValue(e, ientityManager_0.GetNetCoordinates(coords, (MetaDataComponent)null));
		FieldInfo fieldInfo = AccessTools.Field(type, "Target");
		if (!(fieldInfo != null))
		{
			FieldInfo fieldInfo2 = AccessTools.Field(type, "Targets");
			if (fieldInfo2 != null && fieldInfo2.GetValue(e) is IList list)
			{
				list.Add(ientityManager_0.GetNetEntity(targetUid, (MetaDataComponent)null));
			}
		}
		else
		{
			fieldInfo.SetValue(e, ientityManager_0.GetNetEntity(targetUid, (MetaDataComponent)null));
		}
		return e;
	}

	private string method_8(bool bool_2, long long_0)
	{
		return "Хитролох_иди_нахуй._______4_______9__";
	}
}
