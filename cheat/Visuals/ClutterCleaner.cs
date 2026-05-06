using System.Collections.Generic;
using Content.Client.Decals;
using Content.Shared.Weapons.Ranged.Components;
using Robust.Client.GameObjects;
using Robust.Shared.GameObjects;
using Robust.Shared.Prototypes;
using CerberusConfig;

namespace ClutterCleaner;

public sealed class ClutterCleaner : EntitySystem
{
	private SpriteSystem spriteSystem_0;

	private DecalSystem decalSystem_0;

	private readonly HashSet<EntityUid> hashSet_0 = new HashSet<EntityUid>();

	private readonly HashSet<EntityUid> hashSet_1 = new HashSet<EntityUid>();

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3 = true;

	private float float_0;

	private long long_0;

	private float float_2;

	private char char_1;

	private byte byte_1;

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
			return float_2;
		}
		set
		{
			float_2 = value;
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

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
		spriteSystem_0 = base.EntityManager.System<SpriteSystem>();
		decalSystem_0 = base.EntityManager.System<DecalSystem>();
	}

	public override void FrameUpdate(float frameTime)
	{
		HandleDecals();
		float_0 += frameTime;
		if (float_0 >= 0.2f)
		{
			float_0 = 0f;
			HandleCasings();
			HandleLamps();
		}
	}

	private void HandleCasings()
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		bool hideCasings = CerberusConfig.NoTrash.HideCasings;
		if (bool_0 && !hideCasings)
		{
			RestoreSprites(hashSet_0);
			hashSet_0.Clear();
		}
		bool_0 = hideCasings;
		if (!hideCasings)
		{
			return;
		}
		EntityQueryEnumerator<CartridgeAmmoComponent, SpriteComponent> val = ((EntitySystem)this).EntityQueryEnumerator<CartridgeAmmoComponent, SpriteComponent>();
		EntityUid val2 = default(EntityUid);
		CartridgeAmmoComponent val3 = default(CartridgeAmmoComponent);
		SpriteComponent item = default(SpriteComponent);
		while (val.MoveNext(ref val2, ref val3, ref item))
		{
			if (val3.Spent && !hashSet_0.Contains(val2))
			{
				spriteSystem_0.SetVisible(Entity<SpriteComponent>.op_Implicit((val2, item)), false);
				hashSet_0.Add(val2);
			}
		}
	}

	private void HandleDecals()
	{
		bool hideDecals = CerberusConfig.NoTrash.HideDecals;
		if (bool_1 != hideDecals)
		{
			bool_1 = hideDecals;
			bool flag = !hideDecals;
			if (bool_3 != flag)
			{
				decalSystem_0.ToggleOverlay();
				bool_3 = flag;
			}
		}
	}

	private void HandleLamps()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		bool hideLamps = CerberusConfig.NoTrash.HideLamps;
		if (bool_2 && !hideLamps)
		{
			RestoreSprites(hashSet_1);
			hashSet_1.Clear();
		}
		bool_2 = hideLamps;
		if (!hideLamps)
		{
			return;
		}
		EntityQueryEnumerator<MetaDataComponent, SpriteComponent> val = ((EntitySystem)this).EntityQueryEnumerator<MetaDataComponent, SpriteComponent>();
		EntityUid val2 = default(EntityUid);
		MetaDataComponent val3 = default(MetaDataComponent);
		SpriteComponent item = default(SpriteComponent);
		while (val.MoveNext(ref val2, ref val3, ref item))
		{
			EntityPrototype entityPrototype = val3.EntityPrototype;
			string text = ((entityPrototype != null) ? entityPrototype.ID : null);
			if (text != null && IsClutterPrototype(text) && !hashSet_0.Contains(val2))
			{
				spriteSystem_0.SetVisible(Entity<SpriteComponent>.op_Implicit((val2, item)), false);
				hashSet_1.Add(val2);
			}
		}
	}

	private void RestoreSprites(HashSet<EntityUid> cache)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		SpriteComponent item = default(SpriteComponent);
		foreach (EntityUid item2 in cache)
		{
			if (((EntitySystem)this).TryComp<SpriteComponent>(item2, ref item))
			{
				spriteSystem_0.SetVisible(Entity<SpriteComponent>.op_Implicit((item2, item)), true);
			}
		}
	}

	private static bool IsClutterPrototype(string protoId)
	{
		string text = protoId.ToLowerInvariant();
		if (text.Contains("closet") || text.Contains("toolbox") || text.Contains("locker") || text.Contains("rack") || text.Contains("shelf") || text.Contains("bookshelf") || text.Contains("cabinet") || text.Contains("crate") || text.Contains("jetpack") || text.Contains("canister") || text.Contains("button") || text.Contains("chest") || text.Contains("tank") || text.Contains("plasma") || text.Contains("extinguisher") || text.Contains("oxygen") || text.Contains("emergency"))
		{
			return false;
		}
		if (text.Contains("light") || text.Contains("lamp") || text.Contains("tube") || text.Contains("bulb") || text.Contains("lantern") || text.Contains("led"))
		{
			return true;
		}
		if (text.Contains("apc") || text.Contains("powercell") || text.Contains("smes") || text.Contains("substation"))
		{
			return true;
		}
		if (text.Contains("wire") || text.Contains("cable"))
		{
			return true;
		}
		if (text.Contains("catwalk") || text.Contains("lattice") || text.Contains("grating") || text.Contains("walkway"))
		{
			return true;
		}
		if (text.Contains("vent") || text.Contains("scrubber") || text.Contains("pipe") || text.Contains("pump") || text.Contains("connector"))
		{
			return true;
		}
		if (text.Contains("airalarm") || text.Contains("air_alarm") || text.Contains("firealarm") || text.Contains("smokedetect"))
		{
			return true;
		}
		if (text.Contains("poster") || text.Contains("painting") || text.Contains("artwork") || text.Contains("picture"))
		{
			return true;
		}
		if (text.Contains("chair") || text.Contains("stool") || text.Contains("bench") || text.Contains("sofa") || text.Contains("couch"))
		{
			return true;
		}
		if (text.Contains("sign") || text.Contains("plaque") || text.Contains("notice") || text.Contains("label") || text.Contains("banner"))
		{
			return true;
		}
		if (text.Contains("surveillancecamera") || text.Contains("camera"))
		{
			return true;
		}
		if (!text.Contains("beacon"))
		{
			if (text.Contains("garbage") || text.Contains("trash") || text.Contains("litter") || text.Contains("cigbutt") || text.Contains("foodwaste") || text.Contains("rubbish") || text.Contains("remains") || text.Contains("debris"))
			{
				return true;
			}
			if (text.Contains("plant") || text.Contains("flower") || text.Contains("bush") || text.Contains("fern") || text.Contains("cactus") || text.Contains("grass") || text.Contains("vine") || text.Contains("potted"))
			{
				return true;
			}
			if (text.Contains("stationmap") || text.Contains("station_map") || text.Contains("navmap"))
			{
				return true;
			}
			if (!text.Contains("carpet") && !text.Contains("rug"))
			{
				return false;
			}
			return true;
		}
		return true;
	}
}
