using System.Numerics;
using Content.Shared.Turrets;
using Content.Shared.Weapons.Ranged.Components;
using Robust.Client.Graphics;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Maths;
using Robust.Shared.Prototypes;
using CerberusConfig;

namespace TurretEspOverlay;

public sealed class TurretEspOverlay : Overlay
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IEyeManager ieyeManager_0;

	private SharedTransformSystem? sharedTransformSystem_0;

	private int int_0;

	private bool bool_0;

	private float float_0;

	private double double_1;

	private bool bool_1;

	public override OverlaySpace Space => (OverlaySpace)4;

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

	private bool Boolean_0
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public TurretEspOverlay()
	{
		IoCManager.InjectDependencies<TurretEspOverlay>(this);
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_04ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_044d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0458: Unknown result type (might be due to invalid IL or missing references)
		//IL_045e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0494: Unknown result type (might be due to invalid IL or missing references)
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0436: Unknown result type (might be due to invalid IL or missing references)
		if (!bool_0)
		{
			bool_0 = true;
		}
		if (!CerberusConfig.TurretEsp.Enabled)
		{
			return;
		}
		if (sharedTransformSystem_0 == null)
		{
			sharedTransformSystem_0 = ientityManager_0.System<SharedTransformSystem>();
		}
		DrawingHandleWorld worldHandle = ((OverlayDrawArgs)(ref args)).WorldHandle;
		Vector2 position = ieyeManager_0.CurrentEye.Position.Position;
		float maxDistance = CerberusConfig.TurretEsp.MaxDistance;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		AllEntityQueryEnumerator<DeployableTurretComponent, TransformComponent, MetaDataComponent> val = ientityManager_0.AllEntityQueryEnumerator<DeployableTurretComponent, TransformComponent, MetaDataComponent>();
		EntityUid val2 = default(EntityUid);
		DeployableTurretComponent val3 = default(DeployableTurretComponent);
		TransformComponent val4 = default(TransformComponent);
		MetaDataComponent val5 = default(MetaDataComponent);
		Color val6 = default(Color);
		Color val7 = default(Color);
		while (val.MoveNext(ref val2, ref val3, ref val4, ref val5))
		{
			num++;
			if (val4.MapID != args.MapId)
			{
				continue;
			}
			Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(val4);
			if ((worldPosition - position).Length() > maxDistance)
			{
				continue;
			}
			num2++;
			Vector2 vector = new Vector2(worldPosition.X, worldPosition.Y);
			string entityName = val5.EntityName;
			object obj;
			if (entityName == null)
			{
				obj = null;
			}
			else
			{
				obj = entityName.ToLower();
				if (obj != null)
				{
					goto IL_0136;
				}
			}
			obj = "";
			goto IL_0136;
			IL_0158:
			object obj2;
			string text = (string)obj2;
			string text2;
			Vector4 vector2 = ((!text2.Contains("syndicate") && !text2.Contains("hostile") && !text.Contains("syndicate") && !text.Contains("hostile")) ? CerberusConfig.TurretEsp.FriendlyColor : CerberusConfig.TurretEsp.HostileColor);
			if (!val3.Enabled || (int)val3.CurrentState == 0)
			{
				vector2.W *= 0.5f;
			}
			((Color)(ref val6))._002Ector(vector2.X, vector2.Y, vector2.Z, vector2.W);
			float num5 = 0.3f;
			((DrawingHandleBase)worldHandle).DrawLine(vector + new Vector2(0f - num5, 0f), vector + new Vector2(num5, 0f), val6);
			((DrawingHandleBase)worldHandle).DrawLine(vector + new Vector2(0f, 0f - num5), vector + new Vector2(0f, num5), val6);
			((DrawingHandleBase)worldHandle).DrawCircle(vector, num5 * 0.7f, val6, false);
			if (CerberusConfig.TurretEsp.ShowAttackRadius && val3.Enabled)
			{
				float num6 = 10f;
				((Color)(ref val7))._002Ector(val6.R, val6.G, val6.B, 0.3f);
				((DrawingHandleBase)worldHandle).DrawCircle(vector, num6, val7, false);
			}
			continue;
			IL_0136:
			text2 = (string)obj;
			EntityPrototype entityPrototype = val5.EntityPrototype;
			if (entityPrototype != null)
			{
				string iD = entityPrototype.ID;
				if (iD == null)
				{
					obj2 = null;
				}
				else
				{
					obj2 = iD.ToLower();
					if (obj2 != null)
					{
						goto IL_0158;
					}
				}
			}
			else
			{
				obj2 = null;
			}
			obj2 = "";
			goto IL_0158;
		}
		AllEntityQueryEnumerator<GunComponent, TransformComponent, MetaDataComponent> val8 = ientityManager_0.AllEntityQueryEnumerator<GunComponent, TransformComponent, MetaDataComponent>();
		EntityUid val9 = default(EntityUid);
		GunComponent val10 = default(GunComponent);
		TransformComponent val11 = default(TransformComponent);
		MetaDataComponent val12 = default(MetaDataComponent);
		Color val13 = default(Color);
		Color val14 = default(Color);
		while (val8.MoveNext(ref val9, ref val10, ref val11, ref val12))
		{
			if (ientityManager_0.HasComponent<DeployableTurretComponent>(val9) || val11.MapID != args.MapId)
			{
				continue;
			}
			string entityName2 = val12.EntityName;
			object obj3;
			if (entityName2 == null)
			{
				obj3 = null;
			}
			else
			{
				obj3 = entityName2.ToLower();
				if (obj3 != null)
				{
					goto IL_0482;
				}
			}
			obj3 = "";
			goto IL_0482;
			IL_0092:
			object obj4;
			string text3 = (string)obj4;
			string text4;
			if (!text4.Contains("turret") && !text3.Contains("turret"))
			{
				continue;
			}
			num3++;
			Vector2 worldPosition2 = sharedTransformSystem_0.GetWorldPosition(val11);
			if (!((worldPosition2 - position).Length() > maxDistance))
			{
				num4++;
				Vector2 vector3 = new Vector2(worldPosition2.X, worldPosition2.Y);
				Vector4 vector4 = ((text4.Contains("syndicate") || text4.Contains("hostile") || text3.Contains("syndicate") || text3.Contains("hostile")) ? CerberusConfig.TurretEsp.HostileColor : CerberusConfig.TurretEsp.FriendlyColor);
				((Color)(ref val13))._002Ector(vector4.X, vector4.Y, vector4.Z, vector4.W);
				float num7 = 0.3f;
				((DrawingHandleBase)worldHandle).DrawLine(vector3 + new Vector2(0f - num7, 0f), vector3 + new Vector2(num7, 0f), val13);
				((DrawingHandleBase)worldHandle).DrawLine(vector3 + new Vector2(0f, 0f - num7), vector3 + new Vector2(0f, num7), val13);
				((DrawingHandleBase)worldHandle).DrawCircle(vector3, num7 * 0.7f, val13, false);
				if (CerberusConfig.TurretEsp.ShowAttackRadius)
				{
					float num8 = 10f;
					((Color)(ref val14))._002Ector(val13.R, val13.G, val13.B, 0.3f);
					((DrawingHandleBase)worldHandle).DrawCircle(vector3, num8, val14, false);
				}
			}
			continue;
			IL_0482:
			text4 = (string)obj3;
			EntityPrototype entityPrototype2 = val12.EntityPrototype;
			if (entityPrototype2 == null)
			{
				obj4 = null;
			}
			else
			{
				string iD2 = entityPrototype2.ID;
				if (iD2 != null)
				{
					obj4 = iD2.ToLower();
					if (obj4 != null)
					{
						goto IL_0092;
					}
				}
				else
				{
					obj4 = null;
				}
			}
			obj4 = "";
			goto IL_0092;
		}
		int_0++;
		if (int_0 >= 60)
		{
			int_0 = 0;
		}
	}
}
