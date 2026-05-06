using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Content.Shared.Humanoid;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using DamageableHelper;
using TargetFilter;
using CerberusConfig;

namespace TargetSelector;

public class TargetSelector : EntitySystem
{
	[Dependency]
	private readonly SharedTransformSystem sharedTransformSystem_0;

	[Dependency]
	private readonly IEntityManager ientityManager_0;

	private TargetFilter gclass294_0;

	private byte byte_0;

	private string string_0;

	private bool bool_0;

	private long long_2;

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

	private bool Boolean_0
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	private long Int64_0
	{
		get
		{
			return long_2;
		}
		set
		{
			long_2 = value;
		}
	}

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
		gclass294_0 = ientityManager_0.System<TargetFilter>();
	}

	public EntityUid? GetBestTarget(EntityUid player, int priority)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		Vector2 RW9H7fltJw = sharedTransformSystem_0.GetWorldPosition(player);
		List<EntityUid> allValidTargets = GetAllValidTargets(player);
		if (allValidTargets.Count != 0)
		{
			return priority switch
			{
				0 => allValidTargets.OrderBy((EntityUid t) => Vector2.Distance(RW9H7fltJw, GetPosition(t))).FirstOrDefault(), 
				3 => allValidTargets.OrderByDescending(delegate
				{
					_ = this;
					return 1f;
				}).FirstOrDefault(), 
				1 => allValidTargets.OrderBy((EntityUid t) => GetHealth(t)).FirstOrDefault(), 
				2 => allValidTargets.OrderByDescending((EntityUid t) => CalculateThreat(t, RW9H7fltJw)).FirstOrDefault(), 
				_ => allValidTargets.OrderBy((EntityUid t) => Vector2.Distance(RW9H7fltJw, GetPosition(t))).FirstOrDefault(), 
			};
		}
		return null;
	}

	private List<EntityUid> GetAllValidTargets(EntityUid player)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		List<EntityUid> list = new List<EntityUid>();
		Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(player);
		EntityQueryEnumerator<HumanoidAppearanceComponent, TransformComponent> val = ientityManager_0.EntityQueryEnumerator<HumanoidAppearanceComponent, TransformComponent>();
		EntityUid val2 = default(EntityUid);
		HumanoidAppearanceComponent val3 = default(HumanoidAppearanceComponent);
		TransformComponent val4 = default(TransformComponent);
		while (val.MoveNext(ref val2, ref val3, ref val4))
		{
			if (!(val2 == player))
			{
				float num = Vector2.Distance(worldPosition, sharedTransformSystem_0.GetWorldPosition(val4));
				if (!(num < CerberusConfig.TargetFilters.MinDistance) && !(num > CerberusConfig.TargetFilters.MaxDistance) && (gclass294_0 == null || gclass294_0.IsValidGunTarget(val2)))
				{
					list.Add(val2);
				}
			}
		}
		return list;
	}

	private float CalculateThreat(EntityUid target, Vector2 playerPos)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		float num = Vector2.Distance(playerPos, GetPosition(target));
		float num2 = 0f + (20f - num) * 2f + 1f * 10f;
		float health = GetHealth(target);
		return num2 + health * 0.5f;
	}

	private Vector2 GetPosition(EntityUid target)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return sharedTransformSystem_0.GetWorldPosition(target);
	}

	private float GetHealth(EntityUid target)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		if (!DamageableHelper.TryGetDamageableComponent(target, ientityManager_0, out object component))
		{
			return 100f;
		}
		return DamageableHelper.GetTotalDamage(component);
	}
}
