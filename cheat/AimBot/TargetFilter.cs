using System.Collections.Generic;
using System.Linq;
using Content.Shared.Cuffs.Components;
using Content.Shared.Mind;
using Content.Shared.Mind.Components;
using Content.Shared.Mobs.Components;
using Content.Shared.Roles;
using Content.Shared.Roles.Components;
using Content.Shared.Standing;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Prototypes;
using CerberusConfig;

namespace TargetFilter;

public class TargetFilter : EntitySystem
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly FriendsList gclass6_0;

	[Dependency]
	private readonly PriorityList gclass8_0;

	private float float_0;

	private char char_1;

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

	private char Char_0
	{
		get
		{
			return char_1;
		}
		set
		{
			char_1 = value;
		}
	}

	public bool IsValidGunTarget(EntityUid entity)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		if (IsHumanoid(entity))
		{
			if (gclass6_0.IsFriend(entity))
			{
				return false;
			}
			if (CheckMobState(entity, CerberusConfig.GunAimBot.IgnoreDead, CerberusConfig.GunAimBot.IgnoreDowned, CerberusConfig.GunAimBot.TargetCritical))
			{
				if (!CerberusConfig.GunAimBot.IgnoreCuffed || !IsCuffed(entity))
				{
					if (CheckJobFilters(entity, CerberusConfig.GunAimBot.AllowedJobs, CerberusConfig.GunAimBot.BlockedJobs))
					{
						return true;
					}
					return false;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	public bool IsValidThrowTarget(EntityUid entity)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		if (!IsHumanoid(entity))
		{
			return false;
		}
		if (!gclass6_0.IsFriend(entity))
		{
			if (!CheckMobState(entity, CerberusConfig.ThrowAimbot.IgnoreDead, CerberusConfig.ThrowAimbot.IgnoreDowned, targetCritical: false))
			{
				return false;
			}
			if (!CerberusConfig.ThrowAimbot.IgnoreCuffed || !IsCuffed(entity))
			{
				if (CheckJobFilters(entity, CerberusConfig.ThrowAimbot.AllowedJobs, CerberusConfig.ThrowAimbot.BlockedJobs))
				{
					return true;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	public bool IsValidMeleeTarget(EntityUid entity)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		if (IsHumanoid(entity))
		{
			if (!gclass6_0.IsFriend(entity))
			{
				if (CheckMobState(entity, CerberusConfig.MeleeAimBot.IgnoreDead, CerberusConfig.MeleeAimBot.IgnoreDowned, CerberusConfig.MeleeAimBot.TargetCritical))
				{
					if (!CerberusConfig.MeleeAimBot.IgnoreCuffed || !IsCuffed(entity))
					{
						if (CheckJobFilters(entity, CerberusConfig.MeleeAimBot.AllowedJobs, CerberusConfig.MeleeAimBot.BlockedJobs))
						{
							return true;
						}
						return false;
					}
					return false;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	private bool IsHumanoid(EntityUid entity)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return ientityManager_0.HasComponent<MobStateComponent>(entity);
	}

	private bool CheckMobState(EntityUid entity, bool ignoreDead, bool ignoreDowned, bool targetCritical)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Invalid comparison between Unknown and I4
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Invalid comparison between Unknown and I4
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		MobStateComponent val = default(MobStateComponent);
		if (!ientityManager_0.TryGetComponent<MobStateComponent>(entity, ref val))
		{
			return false;
		}
		if (!ignoreDead || (int)val.CurrentState != 3)
		{
			if ((int)val.CurrentState != 2 || targetCritical)
			{
				StandingStateComponent val2 = default(StandingStateComponent);
				if (ignoreDowned && ientityManager_0.TryGetComponent<StandingStateComponent>(entity, ref val2) && !val2.Standing)
				{
					return false;
				}
				return true;
			}
			return false;
		}
		return false;
	}

	private bool IsCuffed(EntityUid entity)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		CuffableComponent val = default(CuffableComponent);
		if (ientityManager_0.TryGetComponent<CuffableComponent>(entity, ref val))
		{
			return val.CuffedHandCount > 0;
		}
		return false;
	}

	private bool CheckJobFilters(EntityUid entity, List<string> allowedJobs, List<string> blockedJobs)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if ((allowedJobs != null && allowedJobs.Count != 0) || (blockedJobs != null && blockedJobs.Count != 0))
		{
			string jobName = GetJobName(entity);
			if (string.IsNullOrEmpty(jobName))
			{
				return true;
			}
			string text = jobName.ToLower();
			if (blockedJobs != null && blockedJobs.Count > 0)
			{
				foreach (string blockedJob in blockedJobs)
				{
					if (!text.Contains(blockedJob.ToLower()))
					{
						continue;
					}
					goto IL_00d3;
				}
			}
			if (allowedJobs != null && allowedJobs.Count > 0)
			{
				bool flag = false;
				foreach (string allowedJob in allowedJobs)
				{
					if (text.Contains(allowedJob.ToLower()))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return false;
				}
			}
			return true;
		}
		return true;
		IL_00d3:
		return false;
	}

	private string GetJobName(EntityUid entity)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		MindContainerComponent val = default(MindContainerComponent);
		object obj;
		if (ientityManager_0.TryGetComponent<MindContainerComponent>(entity, ref val))
		{
			if (!val.Mind.HasValue)
			{
				return string.Empty;
			}
			Entity<MindRoleComponent, JobRoleComponent>? val2 = default(Entity<MindRoleComponent, JobRoleComponent>?);
			if (!ientityManager_0.System<SharedRoleSystem>().MindHasRole<JobRoleComponent>(Entity<MindComponent>.op_Implicit(val.Mind.Value), ref val2))
			{
				return string.Empty;
			}
			if (!val2.HasValue || val2.Value.Comp1 == null)
			{
				return string.Empty;
			}
			ref ProtoId<JobPrototype>? jobPrototype = ref val2.Value.Comp1.JobPrototype;
			if (jobPrototype.HasValue)
			{
				obj = ((object)jobPrototype.GetValueOrDefault()/*cast due to constrained. prefix*/).ToString();
				if (obj != null)
				{
					goto IL_003d;
				}
			}
			else
			{
				obj = null;
			}
			obj = string.Empty;
			goto IL_003d;
		}
		return string.Empty;
		IL_003d:
		return (string)obj;
	}

	public string GetEntityJob(EntityUid entity)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return GetJobName(entity);
	}

	public void SortTargetsByPriority(List<EntityUid> targets)
	{
		targets.Sort(delegate(EntityUid a, EntityUid b)
		{
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			bool flag = gclass8_0.IsPriority(a);
			bool flag2 = gclass8_0.IsPriority(b);
			if (flag && !flag2)
			{
				return -1;
			}
			return (!flag && flag2) ? 1 : 0;
		});
	}

	public List<EntityUid> FilterOnlyPriority(List<EntityUid> targets)
	{
		return targets.Where((EntityUid t) => gclass8_0.IsPriority(t)).ToList();
	}

	private string method_6(char char_2, float float_1, bool bool_0)
	{
		return "Хитролох_иди_нахуй.__0__5_05__5_75__80";
	}
}
