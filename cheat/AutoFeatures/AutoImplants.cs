using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Content.Shared.Actions;
using Content.Shared.Actions.Components;
using Content.Shared.Mobs;
using Content.Shared.Mobs.Components;
using Content.Shared.Mobs.Systems;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using DamageableHelper;
using CerberusConfig;

namespace AutoImplants;

public class AutoImplants : EntitySystem
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly IEntitySystemManager ientitySystemManager_0;

	[Dependency]
	private readonly SharedActionsSystem sharedActionsSystem_0;

	private MobStateSystem mobStateSystem_0;

	private TimeSpan timeSpan_0;

	private TimeSpan timeSpan_1;

	private HashSet<string> hashSet_0 = new HashSet<string>();

	private float float_0;

	private byte byte_0;

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
		DamageableHelper.Initialize();
		((EntitySystem)this).SubscribeLocalEvent<LocalPlayerAttachedEvent>((EntityEventHandler<LocalPlayerAttachedEvent>)OnPlayerAttached, (Type[])null, (Type[])null);
	}

	private void OnPlayerAttached(LocalPlayerAttachedEvent ev)
	{
		hashSet_0.Clear();
	}

	private void InitializeSystems()
	{
		if (mobStateSystem_0 == null)
		{
			mobStateSystem_0 = ientitySystemManager_0.GetEntitySystem<MobStateSystem>();
		}
	}

	public override void Update(float frameTime)
	{
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected I8, but got I4
		if (!CerberusConfig.AutoImplant.Enabled)
		{
			return;
		}
		InitializeSystems();
		float_0 += frameTime;
		if (!(float_0 >= 0.5f))
		{
			return;
		}
		float_0 = 0f;
		if (igameTiming_0.CurTime < timeSpan_1)
		{
			return;
		}
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (!localEntity.HasValue || igameTiming_0.CurTime < timeSpan_0 + TimeSpan.FromSeconds(0.5))
		{
			return;
		}
		timeSpan_0 = igameTiming_0.CurTime;
		(float, float, float)? playerHealth = GetPlayerHealth(localEntity.Value);
		if (!playerHealth.HasValue)
		{
			return;
		}
		float item = playerHealth.Value.Item1;
		float num = CerberusConfig.AutoImplant.HpThreshold / 100f;
		if (!(item <= num))
		{
			if (hashSet_0.Count > 0)
			{
				hashSet_0.Clear();
			}
		}
		else if (!TryActivateImplants(localEntity.Value) && hashSet_0.Count > 0)
		{
			timeSpan_1 = igameTiming_0.CurTime + TimeSpan.FromMinutes(1L);
			hashSet_0.Clear();
		}
	}

	private (float ratio, float damage, float max)? GetPlayerHealth(EntityUid playerUid)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		MobStateComponent comp = default(MobStateComponent);
		if (ientityManager_0.TryGetComponent<MobStateComponent>(playerUid, ref comp))
		{
			if (!DamageableHelper.TryGetDamageableComponent(playerUid, ientityManager_0, out object component))
			{
				return null;
			}
			MobThresholdsComponent thresholds = default(MobThresholdsComponent);
			ientityManager_0.TryGetComponent<MobThresholdsComponent>(playerUid, ref thresholds);
			return CalcHealth(playerUid, comp, component, thresholds);
		}
		return null;
	}

	private (float ratio, float damage, float max)? CalcHealth(EntityUid uid, MobStateComponent comp, object damageableComp, MobThresholdsComponent thresholds)
	{
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Invalid comparison between Unknown and I4
		//IL_0169: Invalid comparison between Unknown and I4
		if (damageableComp != null)
		{
			float totalDamage = DamageableHelper.GetTotalDamage(damageableComp);
			float num = 0f;
			float num2 = 0f;
			if (thresholds != null)
			{
				try
				{
					Type typeFromHandle = typeof(MobThresholdsComponent);
					FieldInfo fieldInfo = typeFromHandle.GetField("Thresholds", BindingFlags.Instance | BindingFlags.NonPublic) ?? typeFromHandle.GetField("_thresholds", BindingFlags.Instance | BindingFlags.NonPublic);
					if (fieldInfo != null && fieldInfo.GetValue(thresholds) is IDictionary dictionary)
					{
						foreach (DictionaryEntry item in dictionary)
						{
							MobState val = (MobState)item.Value;
							float num3 = NumericValue.FromObject(item.Key).ToFloat();
							if ((int)val == 2)
							{
								num = num3;
							}
							if ((int)val == 3)
							{
								num2 = num3;
							}
						}
					}
				}
				catch (Exception)
				{
				}
			}
			if (num2 <= 0.1f)
			{
				num2 = 100f;
			}
			if (num <= 0.1f)
			{
				num = num2;
			}
			float num4 = 0f;
			float num5 = num;
			if (mobStateSystem_0 != null && mobStateSystem_0.IsAlive(uid, comp))
			{
				if (num5 <= 0.1f)
				{
					num5 = 100f;
				}
				num4 = 1f - totalDamage / num5;
				num4 = Math.Clamp(num4, 0f, 1f);
			}
			else if (mobStateSystem_0 == null || !mobStateSystem_0.IsCritical(uid, comp))
			{
				num5 = ((!(num > 0.1f)) ? 100f : num);
				num4 = Math.Clamp(1f - totalDamage / num5, 0f, 1f);
			}
			else
			{
				float num6 = totalDamage - num;
				float num7 = num2 - num;
				if (num7 <= 0.1f)
				{
					num4 = 0f;
				}
				else
				{
					num4 = 1f - num6 / num7;
					num4 = Math.Clamp(num4, 0f, 1f);
				}
				num5 = num2;
			}
			return (num4, totalDamage, num5);
		}
		return null;
	}

	private bool TryActivateImplants(EntityUid playerUid)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected O, but got Unknown
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		ActionsComponent val = default(ActionsComponent);
		if (ientityManager_0.TryGetComponent<ActionsComponent>(playerUid, ref val))
		{
			List<string> allowedImplants = CerberusConfig.AutoImplant.AllowedImplants;
			if (allowedImplants != null && allowedImplants.Count != 0)
			{
				bool flag = false;
				int num = 0;
				MetaDataComponent val2 = default(MetaDataComponent);
				foreach (EntityUid action2 in val.Actions)
				{
					num++;
					Entity<ActionComponent>? action = sharedActionsSystem_0.GetAction((Entity<ActionComponent>?)Entity<ActionComponent>.op_Implicit(action2), true);
					if (!action.HasValue)
					{
						continue;
					}
					Entity<ActionComponent> valueOrDefault = action.GetValueOrDefault();
					if (!ientityManager_0.TryGetComponent<MetaDataComponent>(action2, ref val2) || val2.EntityPrototype == null)
					{
						continue;
					}
					string AVfkGmO7uU = val2.EntityPrototype.ID;
					if (!allowedImplants.Any((string id) => string.Equals(id, AVfkGmO7uU, StringComparison.OrdinalIgnoreCase)) || hashSet_0.Contains(AVfkGmO7uU))
					{
						continue;
					}
					if (!valueOrDefault.Comp.Cooldown.HasValue || !(igameTiming_0.CurTime < valueOrDefault.Comp.Cooldown.Value.End))
					{
						try
						{
							RequestPerformActionEvent val3 = new RequestPerformActionEvent(ientityManager_0.GetNetEntity(action2, (MetaDataComponent)null));
							ientityManager_0.RaisePredictiveEvent<RequestPerformActionEvent>(val3);
							hashSet_0.Add(AVfkGmO7uU);
							flag = true;
						}
						catch (Exception)
						{
						}
					}
					else
					{
						_ = (valueOrDefault.Comp.Cooldown.Value.End - igameTiming_0.CurTime).TotalSeconds;
					}
				}
				if (!flag)
				{
				}
				return flag;
			}
			return false;
		}
		return false;
	}
}
