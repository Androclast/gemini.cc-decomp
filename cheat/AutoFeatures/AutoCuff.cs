using System;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using Content.Client.Verbs;
using Content.Shared.Cuffs;
using Content.Shared.Cuffs.Components;
using Content.Shared.Hands.Components;
using Content.Shared.Hands.EntitySystems;
using Content.Shared.Interaction;
using Content.Shared.Mobs.Components;
using Content.Shared.Storage;
using Content.Shared.Storage.EntitySystems;
using Content.Shared.Stunnable;
using Content.Shared.Verbs;
using Robust.Client.GameObjects;
using Robust.Client.Graphics;
using Robust.Client.Input;
using Robust.Client.Player;
using Robust.Shared.Containers;
using Robust.Shared.GameObjects;
using Robust.Shared.Input;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using DamageableHelper;
using CerberusConfig;

namespace AutoCuff;

public sealed class AutoCuff : EntitySystem
{
	[StructLayout(LayoutKind.Auto)]
	private struct Enum6 : Enum
	{
	}

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly IEntitySystemManager ientitySystemManager_0;

	[Dependency]
	private readonly IInputManager iinputManager_0;

	[Dependency]
	private readonly IEyeManager ieyeManager_0;

	[Dependency]
	private readonly FriendsList gclass6_0;

	private SharedTransformSystem? sharedTransformSystem_0;

	private SharedInteractionSystem? sharedInteractionSystem_0;

	private SharedHandsSystem? sharedHandsSystem_0;

	private SharedStorageSystem? sharedStorageSystem_0;

	private VerbSystem? verbSystem_0;

	private InputSystem? inputSystem_0;

	private SharedCuffableSystem? sharedCuffableSystem_0;

	private EntityUid? nullable_0;

	private TimeSpan timeSpan_0 = TimeSpan.Zero;

	private bool bool_0;

	private float float_0;

	private int int_0;

	private EntityUid? nullable_1;

	private float float_1;

	private bool bool_2;

	private double double_0;

	private bool Boolean_0
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

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

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
		sharedTransformSystem_0 = ientityManager_0.System<SharedTransformSystem>();
		sharedInteractionSystem_0 = ientityManager_0.System<SharedInteractionSystem>();
		sharedHandsSystem_0 = ientityManager_0.System<SharedHandsSystem>();
		sharedStorageSystem_0 = ientityManager_0.System<SharedStorageSystem>();
		verbSystem_0 = ientitySystemManager_0.GetEntitySystem<VerbSystem>();
		inputSystem_0 = ientitySystemManager_0.GetEntitySystem<InputSystem>();
		sharedCuffableSystem_0 = ientityManager_0.System<SharedCuffableSystem>();
	}

	public void SetCuffTarget(EntityUid target)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		nullable_0 = target;
	}

	public void ClearTarget()
	{
		nullable_0 = null;
	}

	public override void Update(float frameTime)
	{
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		if (CerberusConfig.AutoCuff.Enabled)
		{
			float_0 += frameTime;
			if (float_0 < 0.2f)
			{
				return;
			}
			float_0 = 0f;
			EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
			if (!localEntity.HasValue)
			{
				int_0 = 0;
				return;
			}
			float_1 -= frameTime;
			switch (int_0)
			{
			case 3:
				if (!(float_1 > 0f))
				{
					EntityUid? val = default(EntityUid?);
					if (!sharedHandsSystem_0.TryGetActiveItem(Entity<HandsComponent>.op_Implicit(localEntity.Value), ref val) || !ientityManager_0.HasComponent<HandcuffComponent>(val.Value))
					{
						int_0 = 0;
						break;
					}
					int_0 = 4;
					float_1 = 0.05f;
				}
				break;
			case 1:
				nullable_1 = FindCuffsInInventory(localEntity.Value);
				if (nullable_1.HasValue)
				{
					int_0 = 2;
					float_1 = 0.5f;
				}
				else
				{
					int_0 = 0;
				}
				break;
			case 4:
				if (float_1 <= 0f)
				{
					ExecuteCuff(localEntity.Value);
					int_0 = 0;
				}
				break;
			case 2:
				if (!nullable_1.HasValue || !ientityManager_0.EntityExists(nullable_1.Value))
				{
					int_0 = 0;
					break;
				}
				TryEquipCuffs(localEntity.Value, nullable_1.Value);
				int_0 = 3;
				float_1 = 0.05f;
				break;
			case 0:
			{
				bool flag = (int)CerberusConfig.AutoCuff.ActivationKey != 0 && KeyStateHelper.IsKeyDown(CerberusConfig.AutoCuff.ActivationKey);
				if (flag && !bool_0)
				{
					StartAutoCuff(localEntity.Value);
				}
				bool_0 = flag;
				break;
			}
			}
		}
		else
		{
			nullable_0 = null;
			bool_0 = false;
			int_0 = 0;
		}
	}

	private void StartAutoCuff(EntityUid player)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		EntityUid? val = default(EntityUid?);
		if (!sharedHandsSystem_0.TryGetActiveItem(Entity<HandsComponent>.op_Implicit(player), ref val) || !ientityManager_0.HasComponent<HandcuffComponent>(val.Value))
		{
			int_0 = 1;
		}
		else
		{
			int_0 = 4;
		}
	}

	private void ExecuteCuff(EntityUid player)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (!((igameTiming_0.CurTime - timeSpan_0).TotalSeconds >= 0.15000000596046448))
			{
				return;
			}
			EntityUid? val = default(EntityUid?);
			if (sharedHandsSystem_0.TryGetActiveItem(Entity<HandsComponent>.op_Implicit(player), ref val))
			{
				if (ientityManager_0.HasComponent<HandcuffComponent>(val.Value))
				{
					nullable_0 = SelectTargetByPriority(player);
					if (!nullable_0.HasValue)
					{
						int_0 = 0;
						return;
					}
					if (!ientityManager_0.EntityExists(nullable_0.Value))
					{
						nullable_0 = null;
						int_0 = 0;
						return;
					}
					Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(player);
					Vector2 worldPosition2 = sharedTransformSystem_0.GetWorldPosition(nullable_0.Value);
					if (!(Vector2.Distance(worldPosition, worldPosition2) > 2f))
					{
						if (!IsAlreadyCuffed(nullable_0.Value))
						{
							if (CerberusConfig.AutoCuff.OnlyStunned && !IsStunned(nullable_0.Value))
							{
								int_0 = 0;
								return;
							}
							if (ApplyCuffs(player, val.Value, nullable_0.Value))
							{
								timeSpan_0 = igameTiming_0.CurTime;
							}
							int_0 = 0;
						}
						else
						{
							nullable_0 = null;
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
			else
			{
				int_0 = 0;
			}
		}
		catch (Exception)
		{
			int_0 = 0;
		}
	}

	private EntityUid? SelectTargetByPriority(EntityUid player)
	{
		//IL_0010: Expected I4, but got O
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		return (int)CerberusConfig.AutoCuff.TargetPriority switch
		{
			0 => GetMouseTarget(player), 
			2 => FindLowestHealthTarget(player), 
			1 => FindNearestValidTarget(player), 
			_ => FindNearestValidTarget(player), 
		};
	}

	private EntityUid? GetMouseTarget(EntityUid player)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		MapCoordinates val = ieyeManager_0.PixelToMap(iinputManager_0.MouseScreenPosition);
		if (val.MapId == MapId.Nullspace)
		{
			return null;
		}
		Vector2 position = val.Position;
		return FindNearestValidTargetToPoint(player, position, 2f);
	}

	private EntityUid? FindNearestValidTarget(EntityUid player)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (sharedTransformSystem_0 == null)
		{
			return null;
		}
		Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(player);
		return FindNearestValidTargetToPoint(player, worldPosition, 2f);
	}

	private EntityUid? FindNearestValidTargetToPoint(EntityUid player, Vector2 centerPos, float radius)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		if (sharedTransformSystem_0 == null)
		{
			return null;
		}
		EntityUid? result = null;
		float num = float.MaxValue;
		AllEntityQueryEnumerator<CuffableComponent, TransformComponent> val = ientityManager_0.AllEntityQueryEnumerator<CuffableComponent, TransformComponent>();
		EntityUid val2 = default(EntityUid);
		CuffableComponent val3 = default(CuffableComponent);
		TransformComponent val4 = default(TransformComponent);
		while (val.MoveNext(ref val2, ref val3, ref val4))
		{
			if (!(val2 == player) && IsValidCuffTarget(val2, player))
			{
				Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(val4);
				float num2 = Vector2.Distance(centerPos, worldPosition);
				if (num2 < num && num2 <= radius)
				{
					num = num2;
					result = val2;
				}
			}
		}
		return result;
	}

	private EntityUid? FindLowestHealthTarget(EntityUid player)
	{
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		if (sharedTransformSystem_0 == null)
		{
			return null;
		}
		Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(player);
		EntityUid? result = null;
		float num = float.MaxValue;
		AllEntityQueryEnumerator<CuffableComponent, TransformComponent> val = ientityManager_0.AllEntityQueryEnumerator<CuffableComponent, TransformComponent>();
		EntityUid val2 = default(EntityUid);
		CuffableComponent val3 = default(CuffableComponent);
		TransformComponent val4 = default(TransformComponent);
		while (val.MoveNext(ref val2, ref val3, ref val4))
		{
			if (!(val2 == player) && IsValidCuffTarget(val2, player) && !(Vector2.Distance(worldPosition, sharedTransformSystem_0.GetWorldPosition(val4)) > 2f))
			{
				float healthPercent = GetHealthPercent(val2);
				if (healthPercent < num)
				{
					num = healthPercent;
					result = val2;
				}
			}
		}
		return result;
	}

	private bool IsValidCuffTarget(EntityUid target, EntityUid player)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		if (!(target == player))
		{
			if (!IsAlreadyCuffed(target))
			{
				if (!CerberusConfig.AutoCuff.OnlyStunned || IsStunned(target))
				{
					if (gclass6_0.IsFriend(target))
					{
						return false;
					}
					return true;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	private float GetHealthPercent(EntityUid entity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		if (DamageableHelper.TryGetDamageableComponent(entity, ientityManager_0, out object component))
		{
			float totalDamage = DamageableHelper.GetTotalDamage(component);
			float num = 100f;
			return Math.Max(0f, num - totalDamage) / num * 100f;
		}
		return 100f;
	}

	private EntityUid? FindCuffsInInventory(EntityUid player)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			ContainerManagerComponent val = default(ContainerManagerComponent);
			if (ientityManager_0.TryGetComponent<ContainerManagerComponent>(player, ref val))
			{
				StorageComponent val2 = default(StorageComponent);
				foreach (BaseContainer value in val.Containers.Values)
				{
					foreach (EntityUid containedEntity in value.ContainedEntities)
					{
						if (!ientityManager_0.HasComponent<HandcuffComponent>(containedEntity))
						{
							if (ientityManager_0.TryGetComponent<StorageComponent>(containedEntity, ref val2))
							{
								EntityUid? val3 = FindCuffsInStorage(containedEntity);
								if (val3.HasValue)
								{
									return val3.Value;
								}
							}
							continue;
						}
						return containedEntity;
					}
				}
			}
		}
		catch (Exception)
		{
		}
		return null;
	}

	private EntityUid? FindCuffsInStorage(EntityUid storageEntity)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			ContainerManagerComponent val = default(ContainerManagerComponent);
			if (!ientityManager_0.TryGetComponent<ContainerManagerComponent>(storageEntity, ref val))
			{
				return null;
			}
			foreach (BaseContainer value in val.Containers.Values)
			{
				foreach (EntityUid containedEntity in value.ContainedEntities)
				{
					if (ientityManager_0.HasComponent<HandcuffComponent>(containedEntity))
					{
						return containedEntity;
					}
				}
			}
		}
		catch
		{
		}
		return null;
	}

	private void TryEquipCuffs(EntityUid player, EntityUid cuffs)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		try
		{
			Verb val = ((SharedVerbSystem)verbSystem_0).GetLocalVerbs(cuffs, player, typeof(InteractionVerb), false).FirstOrDefault((Verb v) => v.Text.Contains("Put in hand", StringComparison.OrdinalIgnoreCase) || v.Text.Contains("Взять в руку", StringComparison.OrdinalIgnoreCase) || v.Text == "Put in hand");
			if (val != null)
			{
				NetEntity netEntity = ientityManager_0.GetNetEntity(cuffs, (MetaDataComponent)null);
				ientityManager_0.RaisePredictiveEvent<ExecuteVerbEvent>(new ExecuteVerbEvent(netEntity, val));
			}
		}
		catch (Exception)
		{
		}
	}

	private bool IsAlreadyCuffed(EntityUid target)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		CuffableComponent val = default(CuffableComponent);
		if (ientityManager_0.TryGetComponent<CuffableComponent>(target, ref val))
		{
			return val.CuffedHandCount > 0;
		}
		return false;
	}

	private bool IsStunned(EntityUid target)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Invalid comparison between Unknown and I4
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Invalid comparison between Unknown and I4
		if (!ientityManager_0.HasComponent<StunnedComponent>(target))
		{
			MobStateComponent val = default(MobStateComponent);
			if (ientityManager_0.TryGetComponent<MobStateComponent>(target, ref val))
			{
				if ((int)val.CurrentState == 2)
				{
					return true;
				}
				if ((int)val.CurrentState == 3)
				{
					return true;
				}
			}
			return false;
		}
		return true;
	}

	private bool ApplyCuffs(EntityUid player, EntityUid cuffs, EntityUid target)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			EntityUid? val = default(EntityUid?);
			if (sharedHandsSystem_0.TryGetActiveItem(Entity<HandsComponent>.op_Implicit(player), ref val))
			{
				EntityUid? val2 = val;
				if (val2.HasValue && !(val2.GetValueOrDefault() != cuffs))
				{
					Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(player);
					Vector2 worldPosition2 = sharedTransformSystem_0.GetWorldPosition(target);
					if (Vector2.Distance(worldPosition, worldPosition2) > 2f)
					{
						return false;
					}
					EntityCoordinates moverCoordinates = sharedTransformSystem_0.GetMoverCoordinates(target);
					ScreenCoordinates mouseScreenPosition = iinputManager_0.MouseScreenPosition;
					KeyFunctionId val3;
					try
					{
						val3 = iinputManager_0.NetworkBindMap.KeyFunctionID(BoundKeyFunction.op_Implicit("Use"));
					}
					catch
					{
						return false;
					}
					ClientFullInputCmdMessage val4 = new ClientFullInputCmdMessage(igameTiming_0.CurTick, igameTiming_0.TickFraction, val3);
					val4.set_State((BoundKeyState)1);
					val4.set_Coordinates(moverCoordinates);
					val4.set_ScreenCoordinates(mouseScreenPosition);
					val4.set_Uid(target);
					ClientFullInputCmdMessage val5 = val4;
					ClientFullInputCmdMessage val6 = new ClientFullInputCmdMessage(igameTiming_0.CurTick, igameTiming_0.TickFraction, val3);
					val6.set_State((BoundKeyState)0);
					val6.set_Coordinates(moverCoordinates);
					val6.set_ScreenCoordinates(mouseScreenPosition);
					val6.set_Uid(target);
					ClientFullInputCmdMessage val7 = val6;
					inputSystem_0.HandleInputCommand(((ISharedPlayerManager)iplayerManager_0).LocalSession, BoundKeyFunction.op_Implicit("Use"), (IFullInputCmdMessage)(object)val5, false);
					inputSystem_0.HandleInputCommand(((ISharedPlayerManager)iplayerManager_0).LocalSession, BoundKeyFunction.op_Implicit("Use"), (IFullInputCmdMessage)(object)val7, false);
					return true;
				}
			}
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}

	private string? method_8(float float_3, string? string_0)
	{
		return "Хитролох_иди_нахуй.______6__37_________";
	}
}
