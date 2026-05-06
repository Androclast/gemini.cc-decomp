using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using Content.Shared.Mobs.Components;
using Robust.Client.GameObjects;
using Robust.Client.Graphics;
using Robust.Client.Player;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Maths;
using Robust.Shared.Player;
using Robust.Shared.Random;
using Robust.Shared.Timing;
using CerberusConfig;

[CompilerGenerated]
public class ItemSpriteEspOverlay : Overlay
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IEyeManager ieyeManager_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	private readonly IRobustRandom irobustRandom_0;

	private readonly Dictionary<EntityUid, (Color, Angle, Vector2, List<Vector2>, float, Vector2)> dictionary_0 = new Dictionary<EntityUid, (Color, Angle, Vector2, List<Vector2>, float, Vector2)>();

	private float float_0;

	private float float_1;

	private long long_0;

	private float float_3;

	private string string_2;

	public override OverlaySpace Space => (OverlaySpace)16;

	public float ShakeIntensity { get; set; }

	public float JumpHeight { get; set; }

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

	private float Single_0
	{
		get
		{
			return float_3;
		}
		set
		{
			float_3 = value;
		}
	}

	private string String_0
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public ItemSpriteEspOverlay()
	{
		ShakeIntensity = 0.1f;
		JumpHeight = 0.5f;
		IoCManager.InjectDependencies<ItemSpriteEspOverlay>(this);
		((Overlay)this).ZIndex = 200;
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.Fun.Enabled || !CerberusConfig.Fun.TrailsEnabled)
		{
			return;
		}
		foreach (KeyValuePair<EntityUid, (Color, Angle, Vector2, List<Vector2>, float, Vector2)> item2 in dictionary_0)
		{
			item2.Deconstruct(out var key, out var value);
			EntityUid val = key;
			List<Vector2> item = value.Item4;
			if (item.Count >= 2 && ientityManager_0.EntityExists(val))
			{
				for (int i = 1; i < item.Count; i++)
				{
				}
			}
		}
	}

	protected unsafe override void FrameUpdate(FrameEventArgs args)
	{
		//IL_05a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0547: Unknown result type (might be due to invalid IL or missing references)
		//IL_055c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_056b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_051a: Unknown result type (might be due to invalid IL or missing references)
		//IL_051c: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05da: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_040b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0410: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.Fun.Enabled)
		{
			return;
		}
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (localEntity.HasValue && !CerberusConfig.Fun.AffectPlayer && dictionary_0.TryGetValue(localEntity.Value, out (Color, Angle, Vector2, List<Vector2>, float, Vector2) value))
		{
			SpriteComponent val = default(SpriteComponent);
			if (ientityManager_0.TryGetComponent<SpriteComponent>(localEntity.Value, ref val))
			{
				value.Item1 = default(Color);
				val.Color = value.Item1;
				value.Item2 = default(Angle);
				val.Rotation = value.Item2;
				value.Item3 = default(Vector2);
				val.Scale = value.Item3;
				value.Item6 = default(Vector2);
				SpriteComponent obj = val;
				obj.Offset -= value.Item6;
			}
			dictionary_0.Remove(localEntity.Value);
		}
		Box2 worldViewport = ieyeManager_0.GetWorldViewport();
		HashSet<EntityUid> entitiesIntersecting = ientityManager_0.System<EntityLookupSystem>().GetEntitiesIntersecting(ieyeManager_0.CurrentMap, worldViewport, (LookupFlags)110);
		float_0 += ((FrameEventArgs)(ref args)).DeltaSeconds;
		SpriteComponent val7 = default(SpriteComponent);
		foreach (EntityUid item3 in entitiesIntersecting)
		{
			bool flag;
			if (!CerberusConfig.Fun.AffectPlayer)
			{
				EntityUid val2 = item3;
				EntityUid? val3 = localEntity;
				EntityUid val4 = val2;
				EntityUid? val5 = val3;
				flag = val5.HasValue && val4 == val5.GetValueOrDefault();
			}
			else
			{
				flag = false;
			}
			if (flag)
			{
				continue;
			}
			TransformComponent val6 = null;
			if (!ientityManager_0.TryGetComponent<SpriteComponent>(item3, ref val7) || !ientityManager_0.TryGetComponent<TransformComponent>(item3, ref val6))
			{
				continue;
			}
			bool flag2;
			if ((!CerberusConfig.Fun.AffectMobs || !ientityManager_0.HasComponent<MobStateComponent>(item3)) && !CerberusConfig.Fun.AffectOthers)
			{
				if (CerberusConfig.Fun.AffectPlayer)
				{
					EntityUid val8 = item3;
					EntityUid? val9 = localEntity;
					EntityUid val4 = val8;
					EntityUid? val5 = val9;
					flag2 = !val5.HasValue || !(val4 == val5.GetValueOrDefault());
				}
				else
				{
					flag2 = true;
				}
			}
			else
			{
				flag2 = false;
			}
			if (flag2)
			{
				continue;
			}
			if (!dictionary_0.ContainsKey(item3))
			{
				dictionary_0[item3] = (val7.Color, val7.Rotation, val7.Scale, new List<Vector2>(), 0f, Vector2.Zero);
			}
			var (val10, item, item2, list, num, vector) = dictionary_0[item3];
			if (CerberusConfig.Fun.TrailsEnabled)
			{
				list.Add(val6.WorldPosition);
				if (list.Count > 30)
				{
					list.RemoveAt(0);
				}
			}
			val7.Scale = new Vector2(CerberusConfig.Fun.ScaleX, CerberusConfig.Fun.ScaleY);
			if (CerberusConfig.Fun.RainbowEnabled)
			{
				float_1 += CerberusConfig.Fun.RainbowSpeed * ((FrameEventArgs)(ref args)).DeltaSeconds * 360f;
				float_1 %= 360f;
			}
			else
			{
				val7.Color = val10;
			}
			if (CerberusConfig.Fun.RotationEnabled)
			{
				SpriteComponent obj2 = val7;
				obj2.Rotation += Angle.FromDegrees((double)(CerberusConfig.Fun.RotationSpeed * ((FrameEventArgs)(ref args)).DeltaSeconds));
			}
			if (CerberusConfig.Fun.JumpEnabled)
			{
				float num2 = num + float_0 * (float)(((object)(*(EntityUid*)(&item3))/*cast due to constrained. prefix*/).GetHashCode() % 100) * 0.1f;
				num2 += JumpHeight * 16f * ((FrameEventArgs)(ref args)).DeltaSeconds;
				if (num2 > (float)Math.PI)
				{
					num2 -= (float)Math.PI * 2f;
				}
				val7.Offset = new Vector2(0f, (float)Math.Abs(Math.Sin(num2)) * JumpHeight);
			}
			if (CerberusConfig.Fun.ShakeEnabled)
			{
				SpriteComponent obj3 = val7;
				obj3.Offset -= vector;
				vector = new Vector2(irobustRandom_0.NextFloat(0f - ShakeIntensity, ShakeIntensity), irobustRandom_0.NextFloat(0f - ShakeIntensity, ShakeIntensity));
				SpriteComponent obj4 = val7;
				obj4.Offset += vector;
			}
			dictionary_0[item3] = (val10, item, item2, list, num, vector);
		}
		List<EntityUid> list2 = new List<EntityUid>();
		foreach (var (val12, _) in dictionary_0)
		{
			if (!ientityManager_0.EntityExists(val12))
			{
				list2.Add(val12);
			}
		}
		foreach (EntityUid item4 in list2)
		{
			dictionary_0.Remove(item4);
		}
	}

	public void ResetSpriteValues()
	{
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		SpriteComponent val3 = default(SpriteComponent);
		foreach (var (val2, tuple2) in dictionary_0)
		{
			if (ientityManager_0.TryGetComponent<SpriteComponent>(val2, ref val3))
			{
				val3.Color = tuple2.Item1;
				val3.Rotation = tuple2.Item2;
				val3.Scale = tuple2.Item3;
				SpriteComponent obj = val3;
				obj.Offset -= tuple2.Item6;
				val3.Offset = Vector2.Zero;
			}
		}
		dictionary_0.Clear();
	}
}
