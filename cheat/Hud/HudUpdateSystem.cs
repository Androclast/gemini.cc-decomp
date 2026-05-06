using System;
using System.Collections.Generic;
using System.Numerics;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Network;
using Robust.Shared.Physics.Components;
using Robust.Shared.Player;
using CerberusConfig;

public sealed class HudUpdateSystem : EntitySystem
{
	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly SharedTransformSystem sharedTransformSystem_0;

	[Dependency]
	private readonly IClientNetManager iclientNetManager_0;

	public static List<(Vector2 Start, Vector2 End, Vector2 Velocity)> list_0 = new List<(Vector2, Vector2, Vector2)>();

	public static List<(Vector2 Start, Vector2 End)> list_1 = new List<(Vector2, Vector2)>();

	private bool bool_0;

	private int int_0;

	private DateTime dateTime_0 = DateTime.MinValue;

	private float float_0;

	private bool bool_2;

	private double double_1;

	private byte byte_0;

	private string string_0;

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
			return double_1;
		}
		set
		{
			double_1 = value;
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

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
		bool_0 = true;
	}

	public override void Update(float frameTime)
	{
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		((EntitySystem)this).Update(frameTime);
		float_0 += frameTime;
		if (!(float_0 >= 0.1f))
		{
			return;
		}
		float_0 = 0f;
		int_0++;
		if (!bool_0)
		{
			bool_0 = true;
		}
		DateTime utcNow = DateTime.UtcNow;
		if (!((utcNow - dateTime_0).TotalSeconds < 5.0))
		{
			dateTime_0 = utcNow;
		}
		if (CerberusConfig.ProjectileEsp.Enabled || CerberusConfig.ProjectileEsp.AutoDodge || CerberusConfig.Combat.AutoBlockEnabled || CerberusConfig.Combat.AutoLaydownEnabled)
		{
			EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
			if (!localEntity.HasValue)
			{
				return;
			}
			TransformComponent component = base.EntityManager.GetComponent<TransformComponent>(localEntity.Value);
			MapId mapID = component.MapID;
			Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(component);
			Vector2 vector = new Vector2(worldPosition.X, worldPosition.Y);
			List<(Vector2, Vector2)> list = new List<(Vector2, Vector2)>();
			List<(Vector2, Vector2, Vector2)> list2 = new List<(Vector2, Vector2, Vector2)>();
			INetChannel serverChannel = iclientNetManager_0.ServerChannel;
			float num = (float)((serverChannel != null) ? serverChannel.Ping : 0) / 1000f + 0.05f;
			EntityQueryEnumerator<PhysicsComponent, TransformComponent> val = base.EntityManager.EntityQueryEnumerator<PhysicsComponent, TransformComponent>();
			ComponentRegistration val2 = default(ComponentRegistration);
			bool flag = base.EntityManager.ComponentFactory.TryGetRegistration("Projectile", ref val2, false);
			int num2 = 0;
			EntityUid val3 = default(EntityUid);
			PhysicsComponent val4 = default(PhysicsComponent);
			TransformComponent val5 = default(TransformComponent);
			while (val.MoveNext(ref val3, ref val4, ref val5) && ++num2 <= 30)
			{
				if (!(val5.MapID != mapID) && (!flag || base.EntityManager.HasComponent(val3, val2.Type)) && val4.LinearVelocity.LengthSquared() >= 0.01f)
				{
					Vector2 worldPosition2 = sharedTransformSystem_0.GetWorldPosition(val5);
					Vector2 vector2 = new Vector2(worldPosition2.X, worldPosition2.Y);
					Vector2 vector3 = new Vector2(val4.LinearVelocity.X, val4.LinearVelocity.Y);
					Vector2 vector4 = vector2 + vector3 * num;
					float num3 = (vector4 - vector).LengthSquared();
					float num4 = CerberusConfig.ProjectileEsp.DetectionRadius * CerberusConfig.ProjectileEsp.DetectionRadius;
					if (!(num3 > num4))
					{
						Vector2 item = vector4 + vector3 * 2f;
						list.Add((vector2, item));
						list2.Add((vector4, item, vector3));
					}
				}
			}
			list_1 = list;
			list_0 = list2;
		}
		else if (list_1.Count > 0)
		{
			list_1.Clear();
			list_0.Clear();
		}
	}
}
