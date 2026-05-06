using System.Numerics;
using Content.Shared.StepTrigger.Components;
using Robust.Client.Graphics;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Maths;
using Robust.Shared.Prototypes;
using CerberusConfig;

namespace StepTriggerEspOverlay;

public sealed class StepTriggerEspOverlay : Overlay
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IEyeManager ieyeManager_0;

	private SharedTransformSystem? sharedTransformSystem_0;

	private int int_0;

	private bool bool_0;

	private byte byte_0;

	private byte byte_1;

	public override OverlaySpace Space => (OverlaySpace)4;

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

	private byte Byte_1
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = value;
		}
	}

	public StepTriggerEspOverlay()
	{
		IoCManager.InjectDependencies<StepTriggerEspOverlay>(this);
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		if (!bool_0)
		{
			bool_0 = true;
		}
		if (!CerberusConfig.TrapEsp.Enabled)
		{
			return;
		}
		if (sharedTransformSystem_0 == null)
		{
			sharedTransformSystem_0 = ientityManager_0.System<SharedTransformSystem>();
		}
		DrawingHandleWorld worldHandle = ((OverlayDrawArgs)(ref args)).WorldHandle;
		Vector2 position = ieyeManager_0.CurrentEye.Position.Position;
		float maxDistance = CerberusConfig.TrapEsp.MaxDistance;
		AllEntityQueryEnumerator<StepTriggerComponent, TransformComponent, MetaDataComponent> val = ientityManager_0.AllEntityQueryEnumerator<StepTriggerComponent, TransformComponent, MetaDataComponent>();
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		EntityUid val2 = default(EntityUid);
		StepTriggerComponent val3 = default(StepTriggerComponent);
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
			string entityName = val5.EntityName;
			object obj;
			if (entityName != null)
			{
				obj = entityName.ToLower();
				if (obj != null)
				{
					goto IL_0451;
				}
			}
			else
			{
				obj = null;
			}
			obj = "";
			goto IL_0451;
			IL_0591:
			object obj2;
			string text = (string)obj2;
			string text2;
			if (!text2.Contains("puddle") && !text.Contains("puddle") && !text2.Contains("pool") && !text.Contains("pool"))
			{
				if (text2.Contains("shard") || text.Contains("shard") || text2.Contains("debris") || text.Contains("debris") || text2.Contains("trash") || text.Contains("trash") || text2.Contains("garbage") || text.Contains("garbage"))
				{
					num3++;
				}
				else if (!text2.Contains("glass") && !text.Contains("glass"))
				{
					bool flag = text2.Contains("mine") || text.Contains("mine");
					bool flag2 = text2.Contains("proximity") || text.Contains("proximity");
					bool flag3 = text2.Contains("trap") || text.Contains("trap") || text2.Contains("snare") || text.Contains("snare") || text2.Contains("landmine") || text.Contains("landmine");
					if (flag || flag2 || flag3)
					{
						if (!flag || CerberusConfig.TrapEsp.ShowLandMines)
						{
							if (flag2 && !CerberusConfig.TrapEsp.ShowProximitySensors)
							{
								num3++;
							}
							else if (flag || flag2 || CerberusConfig.TrapEsp.ShowStepTriggers)
							{
								num2++;
								Vector2 vector = new Vector2(worldPosition.X, worldPosition.Y);
								Vector4 vector2 = ((!val3.Active) ? CerberusConfig.TrapEsp.DisarmedColor : CerberusConfig.TrapEsp.ArmedColor);
								((Color)(ref val6))._002Ector(vector2.X, vector2.Y, vector2.Z, vector2.W);
								float num4 = 0.25f;
								Vector2 vector3 = vector + new Vector2(0f, num4);
								Vector2 vector4 = vector + new Vector2(0f - num4, 0f - num4);
								Vector2 vector5 = vector + new Vector2(num4, 0f - num4);
								((DrawingHandleBase)worldHandle).DrawLine(vector3, vector4, val6);
								((DrawingHandleBase)worldHandle).DrawLine(vector4, vector5, val6);
								((DrawingHandleBase)worldHandle).DrawLine(vector5, vector3, val6);
								((DrawingHandleBase)worldHandle).DrawLine(vector + new Vector2(0f, -0.1f), vector + new Vector2(0f, 0.1f), val6);
								if (CerberusConfig.TrapEsp.ShowTriggerRadius && val3.Active)
								{
									float num5 = 0.5f;
									((Color)(ref val7))._002Ector(val6.R, val6.G, val6.B, 0.25f);
									((DrawingHandleBase)worldHandle).DrawCircle(vector, num5, val7, false);
								}
							}
							else
							{
								num3++;
							}
						}
						else
						{
							num3++;
						}
					}
					else
					{
						num3++;
					}
				}
				else
				{
					num3++;
				}
			}
			else
			{
				num3++;
			}
			continue;
			IL_0451:
			text2 = (string)obj;
			EntityPrototype entityPrototype = val5.EntityPrototype;
			object obj3;
			if (entityPrototype == null)
			{
				obj3 = null;
			}
			else
			{
				string iD = entityPrototype.ID;
				if (iD != null)
				{
					obj2 = iD.ToLower() ?? "";
					goto IL_0591;
				}
				obj3 = null;
			}
			obj2 = "";
			goto IL_0591;
		}
		int_0++;
		if (int_0 >= 60)
		{
			int_0 = 0;
		}
	}
}
