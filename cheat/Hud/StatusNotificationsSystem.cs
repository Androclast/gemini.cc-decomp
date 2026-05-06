using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using Content.Client.Damage.Systems;
using Content.Shared.Damage.Components;
using Content.Shared.Damage.Systems;
using Content.Shared.Hands.Components;
using Content.Shared.Hands.EntitySystems;
using Content.Shared.Mobs;
using Content.Shared.Mobs.Components;
using Content.Shared.Weapons.Ranged.Components;
using Content.Shared.Weapons.Ranged.Events;
using HarmonyLib;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using DamageableHelper;
using CerberusConfig;

namespace StatusNotificationsSystem;

public sealed class StatusNotificationsSystem : EntitySystem
{
	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly SharedHandsSystem sharedHandsSystem_0;

	private TimeSpan timeSpan_0 = TimeSpan.Zero;

	private TimeSpan timeSpan_1 = TimeSpan.Zero;

	private TimeSpan timeSpan_2 = TimeSpan.Zero;

	private TimeSpan timeSpan_3 = TimeSpan.Zero;

	private TimeSpan timeSpan_4 = TimeSpan.Zero;

	private bool bool_0;

	private bool bool_1;

	private HashSet<string> hashSet_0 = new HashSet<string>();

	private bool bool_2;

	private static FieldInfo? fieldInfo_0;

	private static bool bool_3;

	private float float_0;

	private float float_1;

	private byte byte_0;

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
		DamageableHelper.Initialize();
		if (!bool_3)
		{
			bool_3 = true;
			try
			{
				fieldInfo_0 = AccessTools.Field(typeof(MobThresholdsComponent), "_thresholds");
			}
			catch (Exception)
			{
			}
		}
	}

	public override void Update(float frameTime)
	{
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		((EntitySystem)this).Update(frameTime);
		if (!CerberusConfig.NotificationSettings.Enabled)
		{
			return;
		}
		float_0 += frameTime;
		if (!(float_0 >= 1.1f))
		{
			return;
		}
		float_0 = 0f;
		TimeSpan curTime = igameTiming_0.CurTime;
		LocalPlayer localPlayer = iplayerManager_0.LocalPlayer;
		if (localPlayer != null && localPlayer.ControlledEntity.HasValue)
		{
			EntityUid value = localPlayer.ControlledEntity.Value;
			if (!bool_1 && curTime.TotalSeconds > 5.0)
			{
				bool_1 = true;
				timeSpan_4 = curTime;
				bool_0 = false;
			}
			if (CerberusConfig.NotificationSettings.AntagSpawnNotification && bool_1 && !bool_0 && (curTime - timeSpan_4).TotalSeconds >= (double)CerberusConfig.NotificationSettings.AntagSpawnDelay)
			{
				ShowNotification("⚠\ufe0f Antagonists may have been spawned!", new Vector4(1f, 0.5f, 0f, 1f), 5f);
				bool_0 = true;
			}
			if (CerberusConfig.NotificationSettings.LowHpNotification && (curTime - timeSpan_0).TotalSeconds >= 1.0)
			{
				timeSpan_0 = curTime;
				CheckHealthStatus(value);
			}
			if (CerberusConfig.NotificationSettings.LowStaminaNotification && (curTime - timeSpan_1).TotalSeconds >= 1.0)
			{
				timeSpan_1 = curTime;
				CheckStaminaStatus(value);
			}
			if (CerberusConfig.NotificationSettings.LowAmmoNotification && !((curTime - timeSpan_2).TotalSeconds < 2.0))
			{
				timeSpan_2 = curTime;
				CheckAmmoStatus(value);
			}
			if (CerberusConfig.NotificationSettings.DangerousAtmosNotification && (curTime - timeSpan_3).TotalSeconds >= 3.0)
			{
				timeSpan_3 = curTime;
				CheckAtmosphereStatus(value);
			}
			if (CerberusConfig.NotificationSettings.FriendJoinNotification)
			{
				CheckFriendsOnline();
			}
		}
	}

	private void CheckHealthStatus(EntityUid playerEntity)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Invalid comparison between Unknown and I4
		try
		{
			MobStateComponent val = default(MobStateComponent);
			MobThresholdsComponent obj = default(MobThresholdsComponent);
			if (!base.EntityManager.TryGetComponent<MobStateComponent>(playerEntity, ref val) || !DamageableHelper.TryGetDamageableComponent(playerEntity, (IEntityManager)(object)base.EntityManager, out object component) || !base.EntityManager.TryGetComponent<MobThresholdsComponent>(playerEntity, ref obj))
			{
				return;
			}
			float totalDamage = DamageableHelper.GetTotalDamage(component);
			float num = 100f;
			if (fieldInfo_0 != null && fieldInfo_0.GetValue(obj) is IDictionary dictionary)
			{
				foreach (DictionaryEntry item in dictionary)
				{
					if ((int)(MobState)item.Value == 2)
					{
						num = NumericValue.FromObject(item.Key).ToFloat();
						break;
					}
				}
			}
			float num2 = Math.Max(0f, num - totalDamage) / num * 100f;
			if (!(num2 > CerberusConfig.NotificationSettings.LowHpThreshold) && num2 > 0f)
			{
				ShowNotification($"❤\ufe0f Low Health: {num2:F0}%", new Vector4(1f, 0f, 0f, 1f), 3f);
			}
		}
		catch (Exception)
		{
		}
	}

	private void CheckStaminaStatus(EntityUid playerEntity)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			StaminaComponent val = default(StaminaComponent);
			StaminaSystem val2 = default(StaminaSystem);
			if (base.EntityManager.TryGetComponent<StaminaComponent>(playerEntity, ref val) && val.CritThreshold > 0f && base.EntityManager.EntitySysManager.TryGetEntitySystem<StaminaSystem>(ref val2) && val2 != null)
			{
				float staminaDamage = ((SharedStaminaSystem)val2).GetStaminaDamage(playerEntity, val);
				float num = Math.Max(0f, val.CritThreshold - staminaDamage) / val.CritThreshold * 100f;
				if (!(num > CerberusConfig.NotificationSettings.LowStaminaThreshold) && num > 0f)
				{
					ShowNotification($"⚡ Low Stamina: {num:F0}%", new Vector4(1f, 1f, 0f, 1f), 3f);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private void CheckAmmoStatus(EntityUid playerEntity)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			EntityUid? activeItem = sharedHandsSystem_0.GetActiveItem(Entity<HandsComponent>.op_Implicit(playerEntity));
			if (activeItem.HasValue)
			{
				GunComponent val = default(GunComponent);
				if (base.EntityManager.TryGetComponent<GunComponent>(activeItem.Value, ref val))
				{
					GetAmmoCountEvent val2 = default(GetAmmoCountEvent);
					((IDirectedEventBus)base.EntityManager.EventBus).RaiseLocalEvent<GetAmmoCountEvent>(activeItem.Value, ref val2, false);
					int count = val2.Count;
					if (count <= CerberusConfig.NotificationSettings.LowAmmoThreshold && !bool_2)
					{
						ShowNotification($"\ud83d\udd2b Low Ammo: {count} rounds left!", new Vector4(1f, 0.65f, 0f, 1f), 4f);
						bool_2 = true;
					}
					else if (count > CerberusConfig.NotificationSettings.LowAmmoThreshold)
					{
						bool_2 = false;
					}
				}
				else
				{
					bool_2 = false;
				}
			}
			else
			{
				bool_2 = false;
			}
		}
		catch (Exception)
		{
		}
	}

	private void CheckAtmosphereStatus(EntityUid playerEntity)
	{
	}

	private void CheckFriendsOnline()
	{
		try
		{
			HashSet<string> hashSet = new HashSet<string>();
			ICommonSession[] sessions = ((ISharedPlayerManager)iplayerManager_0).Sessions;
			for (int i = 0; i < sessions.Length; i++)
			{
				string name = sessions[i].Name;
				if (CerberusConfig.list_0.Contains(name))
				{
					hashSet.Add(name);
					if (!hashSet_0.Contains(name))
					{
						ShowNotification("\ud83d\udc4b Friend joined: " + name, new Vector4(0f, 1f, 0f, 1f), 4f);
					}
				}
			}
			hashSet_0 = hashSet;
		}
		catch (Exception)
		{
		}
	}

	public static void ShowFeatureToggleNotification(string featureName, bool enabled)
	{
		if (CerberusConfig.NotificationSettings.FeatureToggleNotification)
		{
			string message = ((!enabled) ? ("✗ " + featureName + " Disabled") : ("✓ " + featureName + " Enabled"));
			Vector4 lineColor = (enabled ? new Vector4(0f, 1f, 0f, 1f) : new Vector4(0.5f, 0.5f, 0.5f, 1f));
			ShowNotification(message, lineColor, 2f);
		}
	}

	public static void ShowFeatureDisabledNotification(string featureName, string reason)
	{
		if (CerberusConfig.NotificationSettings.FeatureAutoDisableNotification)
		{
			ShowNotification("⚠\ufe0f " + featureName + " auto-disabled: " + reason, new Vector4(1f, 0f, 0f, 1f), 5f);
		}
	}

	private static void ShowNotification(string message, Vector4 lineColor, float duration)
	{
		NotificationOverlay.ShowNotification(message, duration, CerberusConfig.NotificationSettings.FadeInTime, CerberusConfig.NotificationSettings.FadeOutTime, lineColor, CerberusConfig.NotificationSettings.ShowProgressBar);
	}
}
