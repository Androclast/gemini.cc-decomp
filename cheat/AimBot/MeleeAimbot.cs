using System.Numerics;
using Content.Client.Weapons.Melee;
using Content.Shared.Weapons.Melee;
using Robust.Client.Graphics;
using Robust.Client.Input;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using CerberusConfig;

namespace MeleeAimbot;

public sealed class MeleeAimbot : EntitySystem
{
	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IInputManager iinputManager_0;

	[Dependency]
	private readonly IEyeManager ieyeManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	private SharedTransformSystem? sharedTransformSystem_0;

	private ThrowTargetSelector? gclass14_0;

	private MeleeWeaponSystem? meleeWeaponSystem_0;

	private PlayerRotator? gclass16_0;

	private string string_0;

	private char char_0;

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

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
		sharedTransformSystem_0 = base.EntityManager.System<SharedTransformSystem>();
		gclass14_0 = base.EntityManager.System<ThrowTargetSelector>();
		meleeWeaponSystem_0 = base.EntityManager.System<MeleeWeaponSystem>();
		gclass16_0 = base.EntityManager.System<PlayerRotator>();
	}

	public override void Update(float frameTime)
	{
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		((EntitySystem)this).Update(frameTime);
		if (!igameTiming_0.IsFirstTimePredicted)
		{
			return;
		}
		if (CerberusConfig.MeleeHelper.RotateToTarget)
		{
			EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
			EntityUid val = default(EntityUid);
			MeleeWeaponComponent melee = default(MeleeWeaponComponent);
			if (!localEntity.HasValue || sharedTransformSystem_0 == null || gclass14_0 == null || meleeWeaponSystem_0 == null || gclass16_0 == null || !((SharedMeleeWeaponSystem)meleeWeaponSystem_0).TryGetWeapon(localEntity.Value, ref val, ref melee))
			{
				return;
			}
			MapCoordinates val2 = ieyeManager_0.PixelToMap(iinputManager_0.MouseScreenPosition);
			if (!(val2.MapId == MapId.Nullspace))
			{
				Vector2 position = val2.Position;
				EntityUid? val3 = null;
				switch (CerberusConfig.MeleeAimBot.TargetPriority)
				{
				case 2:
					val3 = gclass14_0.GetHighestHealthTarget(melee, position, CerberusConfig.MeleeAimBot.CircleRadius, CerberusConfig.MeleeAimBot.TargetCritical);
					break;
				case 0:
					val3 = gclass14_0.GetClosestTargetToPlayer(melee, position, CerberusConfig.MeleeAimBot.CircleRadius, CerberusConfig.MeleeAimBot.TargetCritical);
					break;
				case 1:
					val3 = gclass14_0.GetClosestTargetToMouse(melee, position, CerberusConfig.MeleeAimBot.CircleRadius, CerberusConfig.MeleeAimBot.TargetCritical);
					break;
				}
				if (val3.HasValue && ientityManager_0.EntityExists(val3.Value))
				{
					Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(val3.Value);
					CerberusConfig.NoSavedConfig.HasTarget = true;
					gclass16_0.RotateToTarget(worldPosition);
				}
				else
				{
					CerberusConfig.NoSavedConfig.HasTarget = false;
				}
			}
		}
		else
		{
			CerberusConfig.NoSavedConfig.HasTarget = false;
		}
	}

	private string method_9(int int_1, float float_0)
	{
		return "Хитролох_иди_нахуй.____6__2___9__9____8__";
	}
}
