using System.Runtime.CompilerServices;
using Content.Client.Weapons.Melee;
using Content.Shared.CombatMode;
using Content.Shared.Weapons.Melee;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Maths;
using Robust.Shared.Player;
using CerberusConfig;

[CompilerGenerated]
public sealed class MeleeAimbotSystem : EntitySystem
{
	[Dependency]
	private readonly MeleeWeaponSystem meleeWeaponSystem_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IEntitySystemManager ientitySystemManager_0;

	private ThrowTargetSelector? gclass14_0;

	private SharedTransformSystem? sharedTransformSystem_0;

	private string string_0;

	private double double_1;

	private long long_1;

	private byte byte_0;

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

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
		gclass14_0 = ientitySystemManager_0.GetEntitySystemOrNull<ThrowTargetSelector>();
		sharedTransformSystem_0 = base.EntityManager.System<SharedTransformSystem>();
	}

	public override void Update(float frameTime)
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.MeleeHelper.Enabled)
		{
			return;
		}
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		CombatModeComponent val = default(CombatModeComponent);
		EntityUid val2 = default(EntityUid);
		MeleeWeaponComponent val3 = default(MeleeWeaponComponent);
		if (localEntity.HasValue && ((EntitySystem)this).TryComp<CombatModeComponent>(localEntity.Value, ref val) && val.IsInCombatMode && ((SharedMeleeWeaponSystem)meleeWeaponSystem_0).TryGetWeapon(localEntity.Value, ref val2, ref val3))
		{
			if (CerberusConfig.MeleeHelper.Attack360)
			{
				val3.Angle = Angle.op_Implicit(360f);
			}
			if (CerberusConfig.MeleeHelper.AutoAttack)
			{
				val3.AutoAttack = true;
				val3.AttackRate = 10f;
			}
		}
	}
}
