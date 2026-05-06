using System;
using System.Collections.Generic;
using System.Numerics;
using Content.Shared.Electrocution;
using Robust.Client.GameObjects;
using Robust.Client.Graphics;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Maths;
using Robust.Shared.Prototypes;
using Robust.Shared.Timing;
using CerberusConfig;

namespace InsulatedGlovesScanner;

public sealed class InsulatedGlovesScanner : EntitySystem
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IEyeManager ieyeManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	private readonly HashSet<EntityUid> hashSet_0 = new HashSet<EntityUid>();

	private readonly Dictionary<EntityUid, Color> dictionary_0 = new Dictionary<EntityUid, Color>();

	private readonly HashSet<EntityUid> hashSet_1 = new HashSet<EntityUid>();

	private bool bool_0;

	private TimeSpan timeSpan_0 = TimeSpan.Zero;

	private float float_0;

	private char char_1;

	private int int_0;

	private float float_1;

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

	private float Single_1
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

	public override void Update(float frameTime)
	{
		((EntitySystem)this).Update(frameTime);
		bool enabled = CerberusConfig.InsulationChecker.Enabled;
		if (!bool_0 || enabled)
		{
			bool_0 = enabled;
			if (enabled)
			{
				TimeSpan curTime = igameTiming_0.CurTime;
				if (!((float)(curTime - timeSpan_0).TotalSeconds < 0.5f))
				{
					timeSpan_0 = curTime;
					PerformScan();
				}
			}
		}
		else
		{
			RestoreOriginalColors();
			bool_0 = false;
		}
	}

	private void PerformScan()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		UpdateGlovesCache();
		Box2 worldViewport = ieyeManager_0.GetWorldViewport();
		InsulatedComponent val = default(InsulatedComponent);
		TransformComponent val2 = default(TransformComponent);
		SpriteComponent val3 = default(SpriteComponent);
		foreach (EntityUid item in hashSet_1)
		{
			if (!ientityManager_0.EntityExists(item) || !ientityManager_0.TryGetComponent<InsulatedComponent>(item, ref val) || !ientityManager_0.TryGetComponent<TransformComponent>(item, ref val2) || !ientityManager_0.TryGetComponent<SpriteComponent>(item, ref val3))
			{
				continue;
			}
			Vector2 worldPosition = val2.WorldPosition;
			if (!((Box2)(ref worldViewport)).Contains(worldPosition, true) || hashSet_0.Contains(item))
			{
				continue;
			}
			if (!dictionary_0.ContainsKey(item))
			{
				dictionary_0[item] = val3.Color;
			}
			Color color;
			if (val.Coefficient != 0f)
			{
				if (val.Coefficient <= 0.1f || !(val.Coefficient <= 1f))
				{
					if (!(val.Coefficient > 1f))
					{
						continue;
					}
					color = Color.FromHex("#FF0000".AsSpan(), (Color?)null);
				}
				else
				{
					color = Color.FromHex("#FFA500".AsSpan(), (Color?)null);
				}
			}
			else
			{
				color = Color.FromHex("#00FF00".AsSpan(), (Color?)null);
			}
			val3.Color = color;
			hashSet_0.Add(item);
		}
	}

	private void UpdateGlovesCache()
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		hashSet_1.Clear();
		EntityQueryEnumerator<InsulatedComponent, MetaDataComponent> val = ientityManager_0.EntityQueryEnumerator<InsulatedComponent, MetaDataComponent>();
		EntityUid item = default(EntityUid);
		InsulatedComponent val2 = default(InsulatedComponent);
		MetaDataComponent val3 = default(MetaDataComponent);
		while (val.MoveNext(ref item, ref val2, ref val3))
		{
			EntityPrototype entityPrototype = val3.EntityPrototype;
			object obj;
			if (entityPrototype != null)
			{
				obj = entityPrototype.ID;
				if (obj != null)
				{
					goto IL_0021;
				}
			}
			else
			{
				obj = null;
			}
			obj = "";
			goto IL_0021;
			IL_0021:
			string text = (string)obj;
			if (text.Contains("Glove", StringComparison.OrdinalIgnoreCase) || text.Contains("glove", StringComparison.Ordinal))
			{
				hashSet_1.Add(item);
			}
		}
	}

	private void RestoreOriginalColors()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		SpriteComponent val = default(SpriteComponent);
		foreach (EntityUid item in hashSet_0)
		{
			if (ientityManager_0.TryGetComponent<SpriteComponent>(item, ref val) && dictionary_0.TryGetValue(item, out var value))
			{
				val.Color = value;
			}
		}
		hashSet_0.Clear();
		dictionary_0.Clear();
		hashSet_1.Clear();
	}

	public override void Shutdown()
	{
		((EntitySystem)this).Shutdown();
		RestoreOriginalColors();
	}

	private string method_6(string string_1, string string_2, byte byte_1)
	{
		return "Хитролох_иди_нахуй.________9____9____";
	}
}
