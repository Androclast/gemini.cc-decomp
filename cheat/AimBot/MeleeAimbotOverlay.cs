using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using Content.Shared.CombatMode;
using Content.Shared.Weapons.Melee;
using Content.Shared.Weapons.Melee.Events;
using Content.Shared.Weapons.Ranged.Components;
using Robust.Client.Graphics;
using Robust.Client.Input;
using Robust.Client.Player;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using CerberusConfig;

[CompilerGenerated]
public sealed class MeleeAimbotOverlay : Overlay
{
	private bool bool_0;

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

	private SharedMeleeWeaponSystem sharedMeleeWeaponSystem_0;

	private SharedTransformSystem sharedTransformSystem_0;

	private ThrowTargetSelector gclass14_0;

	private PlayerRotator gclass16_0;

	private int int_0;

	private float float_0;

	private int int_1;

	public override OverlaySpace Space => (OverlaySpace)4;

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

	private float Single_0
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	private int Int32_1
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

	public MeleeAimbotOverlay()
	{
		IoCManager.InjectDependencies<MeleeAimbotOverlay>(this);
	}

	private void EnsureSystems()
	{
		if (!bool_0)
		{
			sharedMeleeWeaponSystem_0 = ientitySystemManager_0.GetEntitySystem<SharedMeleeWeaponSystem>();
			sharedTransformSystem_0 = ientitySystemManager_0.GetEntitySystem<SharedTransformSystem>();
			gclass14_0 = ientitySystemManager_0.GetEntitySystem<ThrowTargetSelector>();
			gclass16_0 = ientitySystemManager_0.GetEntitySystem<PlayerRotator>();
			bool_0 = true;
		}
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		EnsureSystems();
		if (!CerberusConfig.MeleeAimBot.Enabled || args.MapId == MapId.Nullspace)
		{
			return;
		}
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		CombatModeComponent val = default(CombatModeComponent);
		if (localEntity.HasValue && ientityManager_0.TryGetComponent<CombatModeComponent>(localEntity.Value, ref val) && val.IsInCombatMode)
		{
			Vector2? mouseWorldPosition = GetMouseWorldPosition(args);
			if (mouseWorldPosition.HasValue && TryGetWeapon(localEntity.Value, out MeleeWeaponComponent weaponComp))
			{
				DrawAimBotElements(args, mouseWorldPosition.Value);
				ProcessAttackLogic(mouseWorldPosition.Value, weaponComp);
			}
		}
	}

	private bool TryGetWeapon(EntityUid uid, [NotNullWhen(true)] out MeleeWeaponComponent weaponComp)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		weaponComp = null;
		EntityUid val = default(EntityUid);
		if (!sharedMeleeWeaponSystem_0.TryGetWeapon(uid, ref val, ref weaponComp))
		{
			return false;
		}
		if (ientityManager_0.HasComponent<GunComponent>(val))
		{
			return false;
		}
		return true;
	}

	private Vector2? GetMouseWorldPosition(OverlayDrawArgs args)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		MapCoordinates val = ieyeManager_0.PixelToMap(iinputManager_0.MouseScreenPosition);
		if (!(val.MapId != args.MapId))
		{
			return val.Position;
		}
		return null;
	}

	private void DrawAimBotElements(OverlayDrawArgs args, Vector2 mousePos)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		if (CerberusConfig.MeleeAimBot.ShowCircle)
		{
			((DrawingHandleBase)((OverlayDrawArgs)(ref args)).WorldHandle).DrawCircle(mousePos, CerberusConfig.MeleeAimBot.CircleRadius, new Color(ref CerberusConfig.MeleeAimBot.Color), false);
		}
		if (TryGetTarget(mousePos, out var target) && CerberusConfig.MeleeAimBot.ShowLine)
		{
			Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(target.Value);
			((DrawingHandleBase)((OverlayDrawArgs)(ref args)).WorldHandle).DrawLine(mousePos, worldPosition, new Color(ref CerberusConfig.MeleeAimBot.Color));
		}
	}

	private bool TryGetTarget(Vector2 mousePos, [NotNullWhen(true)] out EntityUid? target)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		target = null;
		EntityUid val = default(EntityUid);
		MeleeWeaponComponent melee = default(MeleeWeaponComponent);
		if (!sharedMeleeWeaponSystem_0.TryGetWeapon(((ISharedPlayerManager)iplayerManager_0).LocalEntity.Value, ref val, ref melee))
		{
			return false;
		}
		switch (CerberusConfig.MeleeAimBot.TargetPriority)
		{
		case 2:
			target = gclass14_0.GetHighestHealthTarget(melee, mousePos, CerberusConfig.MeleeAimBot.CircleRadius, CerberusConfig.MeleeAimBot.TargetCritical);
			break;
		case 1:
			target = gclass14_0.GetClosestTargetToMouse(melee, mousePos, CerberusConfig.MeleeAimBot.CircleRadius, CerberusConfig.MeleeAimBot.TargetCritical);
			break;
		case 0:
			target = gclass14_0.GetClosestTargetToPlayer(melee, mousePos, CerberusConfig.MeleeAimBot.CircleRadius, CerberusConfig.MeleeAimBot.TargetCritical);
			break;
		}
		CerberusConfig.HudOverlay.CurrentTarget = target;
		gclass14_0.SetMeleeTarget(target);
		if (target.HasValue)
		{
			return ientityManager_0.EntityExists(target.Value);
		}
		return false;
	}

	private void ProcessAttackLogic(Vector2 mousePos, MeleeWeaponComponent weaponComp)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		if (weaponComp.NextAttack > igameTiming_0.CurTime || weaponComp.Attacking)
		{
			return;
		}
		if (TryGetTarget(mousePos, out var target))
		{
			CerberusConfig.NoSavedConfig.HasTarget = true;
			if (CerberusConfig.MeleeHelper.RotateToTarget)
			{
				gclass16_0.RotateToTarget(sharedTransformSystem_0.GetWorldPosition(target.Value));
			}
			HandleLightAttack(weaponComp, target.Value);
			HandleHeavyAttack(weaponComp, target.Value);
		}
		else
		{
			CerberusConfig.NoSavedConfig.HasTarget = false;
		}
	}

	private void HandleLightAttack(MeleeWeaponComponent weapon, EntityUid target)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		if (KeyStateHelper.IsKeyDown(CerberusConfig.MeleeAimBot.LightHotKey))
		{
			EntityCoordinates val = sharedTransformSystem_0.ToCoordinates(Entity<TransformComponent>.op_Implicit(target), sharedTransformSystem_0.GetMapCoordinates(target, (TransformComponent)null));
			EntityUid owner = ((Component)weapon).Owner;
			for (int i = 0; i < 15; i++)
			{
				LightAttackEvent val2 = new LightAttackEvent((NetEntity?)ientityManager_0.GetNetEntity(target, (MetaDataComponent)null), ientityManager_0.GetNetEntity(owner, (MetaDataComponent)null), ientityManager_0.GetNetCoordinates(val, (MetaDataComponent)null));
				ientityManager_0.RaisePredictiveEvent<LightAttackEvent>(val2);
			}
		}
	}

	private void HandleHeavyAttack(MeleeWeaponComponent weapon, EntityUid target)
	{
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		if (!KeyStateHelper.IsKeyDown(CerberusConfig.MeleeAimBot.HeavyHotKey))
		{
			return;
		}
		Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(((ISharedPlayerManager)iplayerManager_0).LocalEntity.Value);
		Vector2 vector = Vector2Helpers.Normalized(sharedTransformSystem_0.GetWorldPosition(target) - worldPosition);
		EntityCoordinates val = sharedTransformSystem_0.ToCoordinates(Entity<TransformComponent>.op_Implicit(target), sharedTransformSystem_0.GetMapCoordinates(target, (TransformComponent)null));
		for (int i = 0; i < 15; i++)
		{
			if (weapon.AltDisarm)
			{
				EntityUid owner = ((Component)weapon).Owner;
				EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
				if (localEntity.HasValue && owner == localEntity.GetValueOrDefault())
				{
					ientityManager_0.RaisePredictiveEvent<DisarmAttackEvent>(new DisarmAttackEvent((NetEntity?)ientityManager_0.GetNetEntity(target, (MetaDataComponent)null), ientityManager_0.GetNetCoordinates(val, (MetaDataComponent)null)));
					continue;
				}
			}
			List<NetEntity> list = (from e in gclass14_0.ArcRayCast(worldPosition, DirectionExtensions.ToWorldAngle(vector), weapon.Angle, weapon.Range, sharedTransformSystem_0.GetMapId(Entity<TransformComponent>.op_Implicit(((ISharedPlayerManager)iplayerManager_0).LocalEntity.Value)), ((ISharedPlayerManager)iplayerManager_0).LocalEntity.Value)
				select ientityManager_0.GetNetEntity(e, (MetaDataComponent)null)).ToList();
			ientityManager_0.RaisePredictiveEvent<HeavyAttackEvent>(new HeavyAttackEvent(ientityManager_0.GetNetEntity(((Component)weapon).Owner, (MetaDataComponent)null), list, ientityManager_0.GetNetCoordinates(val, (MetaDataComponent)null)));
		}
	}
}
