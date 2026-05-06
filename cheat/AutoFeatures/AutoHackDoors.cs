using System;
using System.Numerics;
using Content.Shared.Doors.Components;
using Content.Shared.Hands.Components;
using Content.Shared.Hands.EntitySystems;
using Content.Shared.Interaction;
using Content.Shared.Tools.Components;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Player;
using Robust.Shared.Prototypes;
using Robust.Shared.Timing;
using CerberusConfig;

namespace AutoHackDoors;

public sealed class AutoHackDoors : EntitySystem
{
	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	private SharedTransformSystem? sharedTransformSystem_0;

	private SharedInteractionSystem? sharedInteractionSystem_0;

	private TimeSpan timeSpan_0 = TimeSpan.Zero;

	private float float_0;

	private byte byte_2;

	private int int_0;

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

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
		sharedTransformSystem_0 = ientityManager_0.System<SharedTransformSystem>();
		sharedInteractionSystem_0 = ientityManager_0.System<SharedInteractionSystem>();
	}

	public override void Update(float frameTime)
	{
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.AutoHackDoors.Enabled)
		{
			return;
		}
		float_0 += frameTime;
		if (!(float_0 >= 0.3f))
		{
			return;
		}
		float_0 = 0f;
		if (!((igameTiming_0.CurTime - timeSpan_0).TotalSeconds >= (double)CerberusConfig.AutoHackDoors.Cooldown))
		{
			return;
		}
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (!localEntity.HasValue)
		{
			return;
		}
		try
		{
			if (!CerberusConfig.AutoHackDoors.RequireMultitool || HasMultitool(localEntity.Value))
			{
				EntityUid? val = FindNearestHackableDoor(localEntity.Value);
				if (val.HasValue && HackDoor(localEntity.Value, val.Value))
				{
					timeSpan_0 = igameTiming_0.CurTime;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private EntityUid? FindNearestHackableDoor(EntityUid player)
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		if (sharedTransformSystem_0 == null)
		{
			return null;
		}
		Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(player);
		EntityUid? result = null;
		float num = float.MaxValue;
		AllEntityQueryEnumerator<DoorComponent, TransformComponent> val = ientityManager_0.AllEntityQueryEnumerator<DoorComponent, TransformComponent>();
		EntityUid val2 = default(EntityUid);
		DoorComponent val3 = default(DoorComponent);
		TransformComponent val4 = default(TransformComponent);
		DoorBoltComponent val5 = default(DoorBoltComponent);
		while (val.MoveNext(ref val2, ref val3, ref val4))
		{
			float num2 = Vector2.Distance(worldPosition, sharedTransformSystem_0.GetWorldPosition(val4));
			if (!(num2 > CerberusConfig.AutoHackDoors.Range) && (!CerberusConfig.AutoHackDoors.OnlyBoltedDoors || (ientityManager_0.TryGetComponent<DoorBoltComponent>(val2, ref val5) && val5.BoltsDown)) && (!CerberusConfig.AutoHackDoors.OnlyLockedDoors || (int)val3.State == 0) && num2 < num)
			{
				num = num2;
				result = val2;
			}
		}
		return result;
	}

	private bool HasMultitool(EntityUid player)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		EntityUid? val = default(EntityUid?);
		string text;
		object obj;
		if (ientityManager_0.System<SharedHandsSystem>().TryGetActiveItem(Entity<HandsComponent>.op_Implicit(player), ref val))
		{
			EntityUid value = val.Value;
			if (!ientityManager_0.HasComponent<MultipleToolComponent>(value))
			{
				MetaDataComponent component = ientityManager_0.GetComponent<MetaDataComponent>(value);
				text = component.EntityName.ToLower();
				EntityPrototype entityPrototype = component.EntityPrototype;
				if (entityPrototype != null)
				{
					string iD = entityPrototype.ID;
					if (iD != null)
					{
						obj = iD.ToLower();
						if (obj != null)
						{
							goto IL_0066;
						}
					}
					else
					{
						obj = null;
					}
				}
				else
				{
					obj = null;
				}
				obj = "";
				goto IL_0066;
			}
			return true;
		}
		return false;
		IL_0066:
		string text2 = (string)obj;
		if (text.Contains("multitool") || text.Contains("wire") || text2.Contains("multitool"))
		{
			return true;
		}
		return text2.Contains("wire");
	}

	private bool HackDoor(EntityUid player, EntityUid door)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		if (sharedInteractionSystem_0 == null)
		{
			return false;
		}
		EntityUid? val = default(EntityUid?);
		if (ientityManager_0.System<SharedHandsSystem>().TryGetActiveItem(Entity<HandsComponent>.op_Implicit(player), ref val))
		{
			sharedInteractionSystem_0.InteractUsing(player, val.Value, door, ((EntitySystem)this).Transform(door).Coordinates, true, true);
			return true;
		}
		return false;
	}

	private string method_10(char char_0, bool bool_0, double double_0)
	{
		return "Хитролох_иди_нахуй._2___6___________9___0__";
	}
}
