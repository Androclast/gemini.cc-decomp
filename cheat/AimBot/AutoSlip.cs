using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using CerberusWareV3.Features.AimBot;
using Content.Client.Verbs;
using Content.Shared.Hands.Components;
using Content.Shared.Hands.EntitySystems;
using Content.Shared.Input;
using Content.Shared.Storage;
using Content.Shared.Verbs;
using Robust.Client.GameObjects;
using Robust.Client.Input;
using Robust.Client.Player;
using Robust.Shared.Configuration;
using Robust.Shared.Containers;
using Robust.Shared.GameObjects;
using Robust.Shared.Input;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using Robust.Shared.Network;
using Robust.Shared.Player;
using Robust.Shared.Prototypes;
using Robust.Shared.Timing;
using DamageableHelper;
using TargetFilter;
using CerberusConfig;

namespace AutoSlip;

public class AutoSlip : EntitySystem
{
	[StructLayout(LayoutKind.Auto)]
	private struct Enum8 : Enum
	{
	}

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly IClientNetManager iclientNetManager_0;

	[Dependency]
	private readonly IConfigurationManager iconfigurationManager_0;

	[Dependency]
	private readonly SharedTransformSystem sharedTransformSystem_0;

	[Dependency]
	private readonly EntityLookupSystem entityLookupSystem_0;

	[Dependency]
	private readonly SharedHandsSystem sharedHandsSystem_0;

	[Dependency]
	private readonly TargetFilter gclass294_0;

	[Dependency]
	private readonly PriorityList gclass8_0;

	[Dependency]
	private readonly IInputManager iinputManager_0;

	[Dependency]
	private readonly InputSystem inputSystem_0;

	[Dependency]
	private readonly SharedContainerSystem sharedContainerSystem_0;

	[Dependency]
	private readonly VerbSystem verbSystem_0;

	private bool bool_0;

	private float float_0;

	private int int_0;

	private EntityUid? nullable_0;

	private float float_1;

	private readonly HashSet<string> hashSet_0 = new HashSet<string> { "Soap", "SoapNT", "SoapDeluxe", "SoapSyndie", "SoapOmega", "BananaPeel", "TrashBananaPeel", "TrashBananaPeelExplosive", "ClownPeel", "MimePeel" };

	private EntityUid? nullable_1;

	private Vector2 vector2_0 = Vector2.Zero;

	private double double_0;

	private long long_0;

	private string string_1;

	private int int_2;

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

	private long Int64_0
	{
		get
		{
			return long_0;
		}
		set
		{
			long_0 = value;
		}
	}

	private string String_0
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	private int Int32_0
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public override void Update(float frameTime)
	{
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		((EntitySystem)this).Update(frameTime);
		if (!CerberusConfig.AutoSlip.Enabled)
		{
			int_0 = 0;
			return;
		}
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (!localEntity.HasValue)
		{
			int_0 = 0;
			return;
		}
		float_1 -= frameTime;
		switch (int_0)
		{
		case 4:
			ExecuteThrow(localEntity.Value);
			break;
		case 0:
		{
			bool flag = KeyStateHelper.IsKeyDown(CerberusConfig.AutoSlip.ActivationKey);
			if (flag && !bool_0)
			{
				float num = (float)igameTiming_0.CurTime.TotalSeconds;
				if (num - float_0 >= 0.5f)
				{
					StartAutoSlip(localEntity.Value);
					float_0 = num;
				}
			}
			bool_0 = flag;
			break;
		}
		case 1:
			nullable_0 = FindSlipItemInInventory(localEntity.Value);
			if (!nullable_0.HasValue)
			{
				int_0 = 0;
				break;
			}
			int_0 = 2;
			float_1 = 0.5f;
			break;
		case 3:
			if (float_1 <= 0f)
			{
				EntityUid? val = default(EntityUid?);
				if (sharedHandsSystem_0.TryGetActiveItem(Entity<HandsComponent>.op_Implicit(localEntity.Value), ref val) && IsSlipItem(val.Value))
				{
					int_0 = 4;
				}
				else
				{
					int_0 = 0;
				}
			}
			break;
		case 2:
			if (!nullable_0.HasValue || !base.EntityManager.EntityExists(nullable_0.Value))
			{
				int_0 = 0;
				break;
			}
			TryEquipItem(localEntity.Value, nullable_0.Value);
			int_0 = 3;
			float_1 = 0.3f;
			break;
		}
	}

	private void StartAutoSlip(EntityUid user)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		EntityUid? val = default(EntityUid?);
		if (sharedHandsSystem_0.TryGetActiveItem(Entity<HandsComponent>.op_Implicit(user), ref val) && IsSlipItem(val.Value))
		{
			int_0 = 4;
		}
		else
		{
			int_0 = 1;
		}
	}

	private unsafe EntityUid? FindSlipItemInInventory(EntityUid user)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			AllContainersEnumerable allContainers = sharedContainerSystem_0.GetAllContainers(user, (ContainerManagerComponent)null);
			AllContainersEnumerator enumerator = ((AllContainersEnumerable)(ref allContainers)).GetEnumerator();
			try
			{
				StorageComponent val = default(StorageComponent);
				while (((AllContainersEnumerator)(ref enumerator)).MoveNext())
				{
					foreach (EntityUid containedEntity in ((AllContainersEnumerator)(ref enumerator)).Current.ContainedEntities)
					{
						if (IsSlipItem(containedEntity))
						{
							return containedEntity;
						}
						if (!base.EntityManager.TryGetComponent<StorageComponent>(containedEntity, ref val))
						{
							continue;
						}
						AllContainersEnumerable allContainers2 = sharedContainerSystem_0.GetAllContainers(containedEntity, (ContainerManagerComponent)null);
						AllContainersEnumerator enumerator3 = ((AllContainersEnumerable)(ref allContainers2)).GetEnumerator();
						try
						{
							while (((AllContainersEnumerator)(ref enumerator3)).MoveNext())
							{
								foreach (EntityUid containedEntity2 in ((AllContainersEnumerator)(ref enumerator3)).Current.ContainedEntities)
								{
									if (IsSlipItem(containedEntity2))
									{
										return containedEntity2;
									}
								}
							}
						}
						finally
						{
							((IDisposable)(*(AllContainersEnumerator*)(&enumerator3))/*cast due to constrained. prefix*/).Dispose();
						}
					}
				}
			}
			finally
			{
				((IDisposable)(*(AllContainersEnumerator*)(&enumerator))/*cast due to constrained. prefix*/).Dispose();
			}
		}
		catch (Exception)
		{
		}
		return null;
	}

	private void TryEquipItem(EntityUid user, EntityUid item)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		try
		{
			Verb val = ((SharedVerbSystem)verbSystem_0).GetLocalVerbs(item, user, typeof(InteractionVerb), false).FirstOrDefault((Verb v) => v.Text.Contains("Put in hand", StringComparison.OrdinalIgnoreCase) || v.Text.Contains("Взять в руку", StringComparison.OrdinalIgnoreCase) || v.Text == "Put in hand");
			if (val != null)
			{
				NetEntity netEntity = base.EntityManager.GetNetEntity(item, (MetaDataComponent)null);
				base.EntityManager.RaisePredictiveEvent<ExecuteVerbEvent>(new ExecuteVerbEvent(netEntity, val));
			}
		}
		catch (Exception)
		{
		}
	}

	private void ExecuteThrow(EntityUid user)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Expected O, but got Unknown
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Expected O, but got Unknown
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		EntityUid? val = default(EntityUid?);
		if (sharedHandsSystem_0.TryGetActiveItem(Entity<HandsComponent>.op_Implicit(user), ref val))
		{
			if (!IsSlipItem(val.Value))
			{
				int_0 = 0;
				return;
			}
			EntityUid? bestTarget = GetBestTarget(user);
			if (bestTarget.HasValue)
			{
				Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(bestTarget.Value);
				Vector2 worldPosition2 = sharedTransformSystem_0.GetWorldPosition(user);
				Vector2 vector;
				if (!CerberusConfig.AutoSlip.UsePrediction)
				{
					vector = worldPosition;
				}
				else
				{
					if (!ProjectilePredictor._isInitialized)
					{
						ProjectilePredictor.InitializeDependencies(iclientNetManager_0, igameTiming_0, iconfigurationManager_0, (IEntityManager)(object)base.EntityManager);
					}
					vector = ProjectilePredictor.GetPredictedWorldShootPosition(user, bestTarget.Value, CerberusConfig.AutoSlip.ThrowSpeed);
				}
				Vector2 vector2 = Vector2Helpers.Normalized(vector - worldPosition2);
				vector -= vector2 * CerberusConfig.AutoSlip.LeadDistance;
				Vector2 vector3 = vector - worldPosition2;
				if (vector3 != Vector2.Zero)
				{
					ThrowAimbotGlobals.nullable_0 = vector3;
					MapCoordinates val2 = default(MapCoordinates);
					((MapCoordinates)(ref val2))._002Ector(vector, sharedTransformSystem_0.GetMapId(Entity<TransformComponent>.op_Implicit(user)));
					ThrowAimbotGlobals.nullable_1 = sharedTransformSystem_0.ToCoordinates(val2);
					try
					{
						ICommonSession localSession = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
						if (localSession != null)
						{
							BoundKeyFunction throwItemInHand = ContentKeyFunctions.ThrowItemInHand;
							KeyFunctionId val3 = iinputManager_0.NetworkBindMap.KeyFunctionID(throwItemInHand);
							EntityCoordinates moverCoordinates = sharedTransformSystem_0.GetMoverCoordinates(user);
							ClientFullInputCmdMessage val4 = new ClientFullInputCmdMessage(igameTiming_0.CurTick, igameTiming_0.TickFraction, val3);
							val4.set_State((BoundKeyState)1);
							val4.set_Coordinates(moverCoordinates);
							val4.set_ScreenCoordinates(iinputManager_0.MouseScreenPosition);
							val4.set_Uid(user);
							ClientFullInputCmdMessage val5 = val4;
							ClientFullInputCmdMessage val6 = new ClientFullInputCmdMessage(igameTiming_0.CurTick, igameTiming_0.TickFraction, val3);
							val6.set_State((BoundKeyState)0);
							val6.set_Coordinates(moverCoordinates);
							val6.set_ScreenCoordinates(iinputManager_0.MouseScreenPosition);
							val6.set_Uid(user);
							ClientFullInputCmdMessage val7 = val6;
							inputSystem_0.HandleInputCommand(localSession, throwItemInHand, (IFullInputCmdMessage)(object)val5, false);
							inputSystem_0.HandleInputCommand(localSession, throwItemInHand, (IFullInputCmdMessage)(object)val7, false);
						}
					}
					catch (Exception)
					{
					}
					int_0 = 0;
				}
				else
				{
					int_0 = 0;
				}
			}
			else
			{
				int_0 = 0;
			}
		}
		else
		{
			int_0 = 0;
		}
	}

	private bool IsSlipItem(EntityUid entity)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		MetaDataComponent val = default(MetaDataComponent);
		if (((EntitySystem)this).TryComp<MetaDataComponent>(entity, ref val))
		{
			EntityPrototype entityPrototype = val.EntityPrototype;
			string text = ((entityPrototype == null) ? null : entityPrototype.ID);
			if (text == null)
			{
				return false;
			}
			return hashSet_0.Contains(text);
		}
		return false;
	}

	private EntityUid? GetBestTarget(EntityUid user)
	{
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		Vector2 eE2Hfle5Ku = sharedTransformSystem_0.GetWorldPosition(user);
		float range = CerberusConfig.AutoSlip.Range;
		MapId mapId = sharedTransformSystem_0.GetMapId(Entity<TransformComponent>.op_Implicit(user));
		if (nullable_1.HasValue && base.EntityManager.EntityExists(nullable_1.Value))
		{
			Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(nullable_1.Value);
			if (Vector2.Distance(eE2Hfle5Ku, worldPosition) > 50f)
			{
				nullable_1 = null;
			}
		}
		List<EntityUid> list = new List<EntityUid>();
		foreach (EntityUid item in entityLookupSystem_0.GetEntitiesInRange(mapId, eE2Hfle5Ku, range, (LookupFlags)110))
		{
			if (!(item == user) && gclass294_0.IsValidThrowTarget(item))
			{
				list.Add(item);
			}
		}
		if (list.Count == 0)
		{
			nullable_1 = null;
			return null;
		}
		if (CerberusConfig.AutoSlip.UseRolePriority && CerberusConfig.ThrowAimbot.RolePriority.Count > 0)
		{
			list = SortByRolePriority(list);
		}
		if (CerberusConfig.ThrowAimbot.OnlyPriority && gclass8_0 != null)
		{
			List<EntityUid> list2 = list.Where((EntityUid t) => gclass8_0.IsPriority(t)).ToList();
			if (list2.Count > 0)
			{
				list = list2;
			}
		}
		switch (CerberusConfig.ThrowAimbot.TargetPriority)
		{
		case 2:
			list.Sort(delegate(EntityUid a, EntityUid b)
			{
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				//IL_0013: Unknown result type (might be due to invalid IL or missing references)
				float healthPercent = GetHealthPercent(a);
				return GetHealthPercent(b).CompareTo(healthPercent);
			});
			break;
		case 1:
			list.Sort(delegate(EntityUid a, EntityUid b)
			{
				//IL_000b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0030: Unknown result type (might be due to invalid IL or missing references)
				float num = (sharedTransformSystem_0.GetWorldPosition(a) - eE2Hfle5Ku).LengthSquared();
				float value = (sharedTransformSystem_0.GetWorldPosition(b) - eE2Hfle5Ku).LengthSquared();
				return num.CompareTo(value);
			});
			break;
		case 0:
			list.Sort(delegate(EntityUid a, EntityUid b)
			{
				//IL_0018: Unknown result type (might be due to invalid IL or missing references)
				//IL_0060: Unknown result type (might be due to invalid IL or missing references)
				string entityJob = gclass294_0.GetEntityJob(a);
				string entityJob2 = gclass294_0.GetEntityJob(b);
				List<string> rolePriority = CerberusConfig.ThrowAimbot.RolePriority;
				int num = ((entityJob != null) ? rolePriority.IndexOf(entityJob) : int.MaxValue);
				int num2 = ((entityJob2 == null) ? int.MaxValue : rolePriority.IndexOf(entityJob2));
				if (num == -1)
				{
					num = int.MaxValue;
				}
				if (num2 == -1)
				{
					num2 = int.MaxValue;
				}
				return num.CompareTo(num2);
			});
			break;
		}
		return list.FirstOrDefault();
	}

	private List<EntityUid> SortByRolePriority(List<EntityUid> targets)
	{
		List<string> KyfHwY8IAD = CerberusConfig.ThrowAimbot.RolePriority;
		return targets.OrderBy(delegate(EntityUid entity)
		{
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			string entityJob = gclass294_0.GetEntityJob(entity);
			if (entityJob == null)
			{
				return int.MaxValue;
			}
			int num = KyfHwY8IAD.IndexOf(entityJob);
			return (num == -1) ? int.MaxValue : num;
		}).ToList();
	}

	private float GetHealthPercent(EntityUid entity)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if (DamageableHelper.TryGetDamageableComponent(entity, (IEntityManager)(object)base.EntityManager, out object component))
		{
			float totalDamage = DamageableHelper.GetTotalDamage(component);
			float num = 100f;
			return Math.Max(0f, num - totalDamage) / num * 100f;
		}
		return 100f;
	}
}
