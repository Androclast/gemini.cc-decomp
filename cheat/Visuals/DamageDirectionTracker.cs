using System;
using Robust.Client.GameObjects;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Maths;
using Robust.Shared.Prototypes;
using Robust.Shared.Timing;
using CerberusConfig;

namespace DamageDirectionTracker;

public sealed class DamageDirectionTracker : EntitySystem
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	private TimeSpan timeSpan_0 = TimeSpan.Zero;

	private float float_0;

	private string string_0;

	private bool bool_0;

	private byte byte_1;

	private double double_1;

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

	private byte Byte_0
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

	public override void Update(float frameTime)
	{
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		((EntitySystem)this).Update(frameTime);
		float_0 += frameTime;
		if (float_0 < 0.2f)
		{
			return;
		}
		float_0 = 0f;
		float num = (CerberusConfig.FoamFading.Enabled ? CerberusConfig.FoamFading.Alpha : 1f);
		int num2 = 0;
		EntityQueryEnumerator<SpriteComponent> val = ((EntitySystem)this).EntityQueryEnumerator<SpriteComponent>();
		EntityUid val2 = default(EntityUid);
		SpriteComponent val3 = default(SpriteComponent);
		while (val.MoveNext(ref val2, ref val3))
		{
			try
			{
				MetaDataComponent component = ientityManager_0.GetComponent<MetaDataComponent>(val2);
				bool flag = false;
				EntityPrototype entityPrototype = component.EntityPrototype;
				if (((entityPrototype != null) ? entityPrototype.ID : null) != null)
				{
					string iD = component.EntityPrototype.ID;
					if (iD.Contains("Foam", StringComparison.OrdinalIgnoreCase) || iD.Contains("foam", StringComparison.OrdinalIgnoreCase))
					{
						flag = true;
					}
				}
				if (!flag && component.EntityName != null)
				{
					string entityName = component.EntityName;
					if (entityName.Contains("foam", StringComparison.OrdinalIgnoreCase) || entityName.Contains("пена", StringComparison.OrdinalIgnoreCase))
					{
						flag = true;
					}
				}
				if (flag)
				{
					SpriteComponent obj = val3;
					Color color = val3.Color;
					obj.Color = ((Color)(ref color)).WithAlpha(num);
					num2++;
				}
			}
			catch
			{
			}
		}
		if (!((igameTiming_0.CurTime - timeSpan_0).TotalSeconds < 5.0))
		{
			if (num2 > 0)
			{
				Logger.Info($"[FoamFading] Applied alpha {num:F2} to {num2} foam entities (Enabled: {CerberusConfig.FoamFading.Enabled})");
			}
			timeSpan_0 = igameTiming_0.CurTime;
		}
	}
}
