using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using Content.Client.Verbs;
using Content.Shared.Hands;
using Content.Shared.Hands.Components;
using Content.Shared.Hands.EntitySystems;
using Content.Shared.Inventory;
using Content.Shared.Inventory.Events;
using Content.Shared.Item.ItemToggle.Components;
using Content.Shared.Storage;
using Content.Shared.Storage.EntitySystems;
using Content.Shared.Tools.Components;
using Content.Shared.Tools.Systems;
using Hexa.NET.ImGui;
using Robust.Client.GameObjects;
using Robust.Client.Graphics;
using Robust.Client.Input;
using Robust.Client.Player;
using Robust.Shared.Containers;
using Robust.Shared.GameObjects;
using Robust.Shared.Input;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using CerberusConfig;

namespace AutoDeconstruct;

public class AutoDeconstruct : EntitySystem
{
	private struct DeconstructionStep(string tool, float doAfter)
	{
		public string avgknp5LnA = tool;

		public float eSXk21cxfK = doAfter;

		private float float_1;

		private long long_1;

		private string string_0;

		private float Single_0
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

		private long Int64_0
		{
			get
			{
				return long_1;
			}
			set
			{
				long_1 = value;
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
	}

	[StructLayout(LayoutKind.Auto)]
	private struct Enum3 : Enum
	{
	}

	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IInputManager iinputManager_0;

	[Dependency]
	private readonly IEyeManager ieyeManager_0;

	[Dependency]
	private readonly IEntitySystemManager ientitySystemManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	private SharedHandsSystem sharedHandsSystem_0;

	private InputSystem inputSystem_0;

	private SharedTransformSystem sharedTransformSystem_0;

	private SharedToolSystem sharedToolSystem_0;

	private InventorySystem inventorySystem_0;

	private SharedStorageSystem sharedStorageSystem_0;

	private SharedContainerSystem sharedContainerSystem_0;

	private VerbSystem verbSystem_0;

	private bool bool_0;

	private static readonly string[] string_0 = new string[6] { "Screwing", "Prying", "Cutting", "Welding", "Anchoring", "Wrenching" };

	private static readonly Dictionary<string, DeconstructionStep[]> dictionary_0 = new Dictionary<string, DeconstructionStep[]>
	{
		{
			"WallSolid",
			new DeconstructionStep[1]
			{
				new DeconstructionStep("Welding", 10f)
			}
		},
		{
			"WallSolidRust",
			new DeconstructionStep[1]
			{
				new DeconstructionStep("Welding", 2f)
			}
		},
		{
			"WallSolidChitin",
			new DeconstructionStep[1]
			{
				new DeconstructionStep("Welding", 10f)
			}
		},
		{
			"WallUranium",
			new DeconstructionStep[2]
			{
				new DeconstructionStep("Welding", 10f),
				new DeconstructionStep("Prying", 10f)
			}
		},
		{
			"WallSilver",
			new DeconstructionStep[2]
			{
				new DeconstructionStep("Welding", 20f),
				new DeconstructionStep("Prying", 10f)
			}
		},
		{
			"WallPlastic",
			new DeconstructionStep[1]
			{
				new DeconstructionStep("Prying", 10f)
			}
		},
		{
			"WallPlasma",
			new DeconstructionStep[2]
			{
				new DeconstructionStep("Welding", 20f),
				new DeconstructionStep("Prying", 10f)
			}
		},
		{
			"WallGold",
			new DeconstructionStep[2]
			{
				new DeconstructionStep("Welding", 20f),
				new DeconstructionStep("Prying", 10f)
			}
		},
		{
			"WallClown",
			new DeconstructionStep[2]
			{
				new DeconstructionStep("Welding", 20f),
				new DeconstructionStep("Prying", 10f)
			}
		},
		{
			"WallMeat",
			new DeconstructionStep[1]
			{
				new DeconstructionStep("Prying", 5f)
			}
		},
		{
			"Girder",
			new DeconstructionStep[1]
			{
				new DeconstructionStep("Screwing", 2f)
			}
		},
		{
			"WallReinforced",
			new DeconstructionStep[9]
			{
				new DeconstructionStep("Cutting", 1f),
				new DeconstructionStep("Screwing", 1f),
				new DeconstructionStep("Welding", 5f),
				new DeconstructionStep("Prying", 1f),
				new DeconstructionStep("Anchoring", 1f),
				new DeconstructionStep("Welding", 10f),
				new DeconstructionStep("Prying", 1f),
				new DeconstructionStep("Screwing", 1f),
				new DeconstructionStep("Cutting", 1f)
			}
		},
		{
			"WallReinforcedRust",
			new DeconstructionStep[1]
			{
				new DeconstructionStep("Welding", 2f)
			}
		},
		{
			"WallReinforcedChitin",
			new DeconstructionStep[9]
			{
				new DeconstructionStep("Cutting", 1f),
				new DeconstructionStep("Screwing", 1f),
				new DeconstructionStep("Welding", 5f),
				new DeconstructionStep("Prying", 1f),
				new DeconstructionStep("Anchoring", 1f),
				new DeconstructionStep("Welding", 10f),
				new DeconstructionStep("Prying", 1f),
				new DeconstructionStep("Screwing", 1f),
				new DeconstructionStep("Cutting", 1f)
			}
		},
		{
			"ReinforcedGirder",
			new DeconstructionStep[1]
			{
				new DeconstructionStep("Cutting", 2f)
			}
		},
		{
			"WallShuttle",
			new DeconstructionStep[10]
			{
				new DeconstructionStep("Welding", 10f),
				new DeconstructionStep("Cutting", 1f),
				new DeconstructionStep("Screwing", 2f),
				new DeconstructionStep("Welding", 5f),
				new DeconstructionStep("Prying", 2f),
				new DeconstructionStep("Anchoring", 1f),
				new DeconstructionStep("Welding", 10f),
				new DeconstructionStep("Prying", 1f),
				new DeconstructionStep("Screwing", 1f),
				new DeconstructionStep("Cutting", 4f)
			}
		},
		{
			"WallShuttleDiagonal",
			new DeconstructionStep[10]
			{
				new DeconstructionStep("Welding", 5f),
				new DeconstructionStep("Cutting", 1f),
				new DeconstructionStep("Screwing", 1f),
				new DeconstructionStep("Welding", 5f),
				new DeconstructionStep("Prying", 1f),
				new DeconstructionStep("Anchoring", 1f),
				new DeconstructionStep("Welding", 10f),
				new DeconstructionStep("Prying", 1f),
				new DeconstructionStep("Screwing", 1f),
				new DeconstructionStep("Cutting", 1f)
			}
		},
		{
			"Grille",
			new DeconstructionStep[1]
			{
				new DeconstructionStep("Cutting", 0.5f)
			}
		},
		{
			"GrilleBroken",
			new DeconstructionStep[1]
			{
				new DeconstructionStep("Cutting", 0.5f)
			}
		},
		{
			"Window",
			new DeconstructionStep[2]
			{
				new DeconstructionStep("Screwing", 1f),
				new DeconstructionStep("Prying", 1f)
			}
		},
		{
			"WindowReinforced",
			new DeconstructionStep[3]
			{
				new DeconstructionStep("Screwing", 2f),
				new DeconstructionStep("Prying", 2f),
				new DeconstructionStep("Cutting", 2f)
			}
		},
		{
			"Catwalk",
			new DeconstructionStep[1]
			{
				new DeconstructionStep("Cutting", 1f)
			}
		},
		{
			"Table",
			new DeconstructionStep[2]
			{
				new DeconstructionStep("Anchoring", 1f),
				new DeconstructionStep("Cutting", 1f)
			}
		},
		{
			"TableReinforced",
			new DeconstructionStep[2]
			{
				new DeconstructionStep("Anchoring", 2f),
				new DeconstructionStep("Cutting", 2f)
			}
		},
		{
			"TableGlass",
			new DeconstructionStep[2]
			{
				new DeconstructionStep("Anchoring", 1f),
				new DeconstructionStep("Cutting", 1f)
			}
		},
		{
			"TableWood",
			new DeconstructionStep[2]
			{
				new DeconstructionStep("Anchoring", 1f),
				new DeconstructionStep("Cutting", 1f)
			}
		},
		{
			"Rack",
			new DeconstructionStep[1]
			{
				new DeconstructionStep("Anchoring", 1f)
			}
		}
	};

	private EntityUid? nullable_0;

	private string string_1;

	private int int_0;

	private TimeSpan timeSpan_0;

	private TimeSpan timeSpan_1;

	private bool bool_1;

	private EntityUid? nullable_1;

	private int int_1;

	private EntityUid? nullable_2;

	private string string_2;

	private EntityUid? nullable_3;

	private string string_3;

	private DeconstructionStep[] deconstructionStep_0;

	private int int_2;

	private int int_3;

	private EntityUid? nullable_4;

	private EntityUid? nullable_5;

	private string string_4;

	private float float_0;

	private bool bool_2;

	private TimeSpan timeSpan_2 = TimeSpan.Zero;

	private long long_0;

	private float float_1;

	private int int_4;

	private byte byte_0;

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
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	private int Int32_0
	{
		get
		{
			return int_4;
		}
		set
		{
			int_4 = value;
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

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
	}

	private void InitializeSystems()
	{
		if (sharedHandsSystem_0 == null)
		{
			sharedHandsSystem_0 = ientitySystemManager_0.GetEntitySystem<SharedHandsSystem>();
		}
		if (inputSystem_0 == null)
		{
			inputSystem_0 = ientitySystemManager_0.GetEntitySystem<InputSystem>();
		}
		if (sharedTransformSystem_0 == null)
		{
			sharedTransformSystem_0 = ientitySystemManager_0.GetEntitySystem<SharedTransformSystem>();
		}
		if (sharedToolSystem_0 == null)
		{
			sharedToolSystem_0 = ientitySystemManager_0.GetEntitySystem<SharedToolSystem>();
		}
		if (inventorySystem_0 == null)
		{
			inventorySystem_0 = ientitySystemManager_0.GetEntitySystem<InventorySystem>();
		}
		if (sharedStorageSystem_0 == null)
		{
			sharedStorageSystem_0 = ientitySystemManager_0.GetEntitySystem<SharedStorageSystem>();
		}
		if (sharedContainerSystem_0 == null)
		{
			sharedContainerSystem_0 = ientitySystemManager_0.GetEntitySystem<SharedContainerSystem>();
		}
		if (verbSystem_0 == null)
		{
			verbSystem_0 = ientitySystemManager_0.GetEntitySystem<VerbSystem>();
		}
	}

	public override void Update(float frameTime)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.AutoDeconstruct.Enabled)
		{
			return;
		}
		InitializeSystems();
		float_0 += frameTime;
		if (!(float_0 >= 0.1f))
		{
			return;
		}
		float_0 = 0f;
		ImGuiKey targetKey = CerberusConfig.AutoDeconstruct.TargetKey;
		if ((int)targetKey != 0)
		{
			bool flag = KeyStateHelper.IsKeyDown(targetKey);
			if (flag && !bool_0)
			{
				StartAutoDeconstruct();
				bool_0 = true;
			}
			else if (!flag)
			{
				bool_0 = false;
			}
		}
		if (nullable_0.HasValue)
		{
			int actionDelay = CerberusConfig.AutoDeconstruct.ActionDelay;
			if (actionDelay <= 0 || !(igameTiming_0.CurTime < timeSpan_0 + TimeSpan.FromMilliseconds(actionDelay)))
			{
				ProcessAutoDeconstruct();
			}
		}
	}

	private void StartAutoDeconstruct()
	{
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (!localEntity.HasValue)
		{
			return;
		}
		EntityUid? targetUnderCursor = GetTargetUnderCursor(localEntity.Value);
		if (!targetUnderCursor.HasValue)
		{
			return;
		}
		nullable_0 = targetUnderCursor;
		int_0 = 0;
		bool_1 = false;
		bool_2 = false;
		timeSpan_0 = TimeSpan.Zero;
		nullable_1 = null;
		int_1 = 0;
		int_3 = 0;
		nullable_4 = null;
		nullable_5 = null;
		string_4 = null;
		deconstructionStep_0 = null;
		int_2 = 0;
		nullable_2 = null;
		string_2 = null;
		nullable_3 = null;
		string_3 = null;
		MetaDataComponent val = default(MetaDataComponent);
		if (!ientityManager_0.TryGetComponent<MetaDataComponent>(targetUnderCursor.Value, ref val) || val.EntityPrototype == null)
		{
			string_1 = null;
		}
		else
		{
			string_1 = val.EntityPrototype.ID;
			if (dictionary_0.ContainsKey(string_1))
			{
				deconstructionStep_0 = dictionary_0[string_1];
				string.Join(" → ", deconstructionStep_0.Select((DeconstructionStep s) => $"{s.avgknp5LnA}({s.eSXk21cxfK}s)"));
			}
		}
		_ = ientityManager_0.GetComponent<MetaDataComponent>(targetUnderCursor.Value).EntityName;
	}

	private void ProcessAutoDeconstruct()
	{
		//IL_0b00: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b05: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_09db: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_073d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0abe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0752: Unknown result type (might be due to invalid IL or missing references)
		//IL_0757: Unknown result type (might be due to invalid IL or missing references)
		//IL_0761: Unknown result type (might be due to invalid IL or missing references)
		//IL_0766: Unknown result type (might be due to invalid IL or missing references)
		//IL_076b: Unknown result type (might be due to invalid IL or missing references)
		//IL_077d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0782: Unknown result type (might be due to invalid IL or missing references)
		//IL_0787: Unknown result type (might be due to invalid IL or missing references)
		//IL_078f: Unknown result type (might be due to invalid IL or missing references)
		//IL_079f: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d4: Expected O, but got Unknown
		//IL_07da: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0804: Unknown result type (might be due to invalid IL or missing references)
		//IL_0805: Unknown result type (might be due to invalid IL or missing references)
		//IL_080c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0813: Unknown result type (might be due to invalid IL or missing references)
		//IL_081f: Expected O, but got Unknown
		//IL_0835: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a11: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a16: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a21: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a22: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a31: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a34: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a40: Expected O, but got Unknown
		//IL_0a46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a68: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a69: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a71: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a78: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a87: Expected O, but got Unknown
		//IL_0a9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0868: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae0: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0d10: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d15: Unknown result type (might be due to invalid IL or missing references)
		//IL_0538: Unknown result type (might be due to invalid IL or missing references)
		//IL_067a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c04: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da8: Unknown result type (might be due to invalid IL or missing references)
		//IL_038b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0390: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0709: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Expected O, but got Unknown
		//IL_08ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_056b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0572: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0439: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d39: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0912: Unknown result type (might be due to invalid IL or missing references)
		//IL_0919: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Expected O, but got Unknown
		//IL_0c8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c96: Expected O, but got Unknown
		//IL_0b49: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b54: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b62: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b68: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b71: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b80: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b82: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b97: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b99: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba5: Expected O, but got Unknown
		if (nullable_0.HasValue && ientityManager_0.EntityExists(nullable_0.Value))
		{
			EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
			if (localEntity.HasValue)
			{
				if (bool_2)
				{
					EntityUid? activeItem = sharedHandsSystem_0.GetActiveItem(Entity<HandsComponent>.op_Implicit(localEntity.Value));
					ItemToggleComponent val = default(ItemToggleComponent);
					if (activeItem.HasValue && ientityManager_0.TryGetComponent<ItemToggleComponent>(activeItem.Value, ref val) && val.Activated && !(igameTiming_0.CurTime > timeSpan_2))
					{
						return;
					}
					bool_2 = false;
				}
				if (bool_1 && !((timeSpan_1 - igameTiming_0.CurTime).TotalSeconds <= 0.0))
				{
					_ = (int)(igameTiming_0.CurTime.TotalSeconds * 4.0) % 4;
				}
				MetaDataComponent val2 = default(MetaDataComponent);
				if (ientityManager_0.TryGetComponent<MetaDataComponent>(nullable_0.Value, ref val2) && val2.EntityPrototype != null && !string.IsNullOrEmpty(string_1) && val2.EntityPrototype.ID != string_1)
				{
					string_1 = val2.EntityPrototype.ID;
					int_0 = 0;
					int_1 = 0;
					int_3 = 0;
					int_2 = 0;
					if (!dictionary_0.ContainsKey(string_1))
					{
						deconstructionStep_0 = null;
					}
					else
					{
						deconstructionStep_0 = dictionary_0[string_1];
						string.Join(" → ", deconstructionStep_0.Select((DeconstructionStep s) => $"{s.avgknp5LnA}({s.eSXk21cxfK}s)"));
					}
				}
				if (int_3 != 2)
				{
					if (!bool_1)
					{
						if (deconstructionStep_0 == null || int_2 < deconstructionStep_0.Length)
						{
							if (bool_1)
							{
								return;
							}
							float num = 1f;
							string text;
							if (deconstructionStep_0 == null || int_2 >= deconstructionStep_0.Length)
							{
								if (int_0 >= string_0.Length)
								{
									nullable_0 = null;
									int_3 = 0;
									return;
								}
								text = string_0[int_0];
							}
							else
							{
								DeconstructionStep deconstructionStep = deconstructionStep_0[int_2];
								text = deconstructionStep.avgknp5LnA;
								num = deconstructionStep.eSXk21cxfK;
							}
							EntityUid? sfGk5ccZbc = sharedHandsSystem_0.GetActiveItem(Entity<HandsComponent>.op_Implicit(localEntity.Value));
							EntityUid? val3 = null;
							string text2 = null;
							HandsComponent val4 = default(HandsComponent);
							if (ientityManager_0.TryGetComponent<HandsComponent>(localEntity.Value, ref val4))
							{
								foreach (string key in val4.Hands.Keys)
								{
									EntityUid? heldItem = sharedHandsSystem_0.GetHeldItem(Entity<HandsComponent>.op_Implicit(localEntity.Value), key);
									if (heldItem.HasValue && sharedToolSystem_0.HasQuality(heldItem.Value, text, (ToolComponent)null))
									{
										val3 = heldItem;
										text2 = key;
										break;
									}
								}
							}
							if (val3.HasValue)
							{
								EntityUid? val5 = sfGk5ccZbc;
								EntityUid? val6 = val3;
								if (val5.HasValue != val6.HasValue || (val5.HasValue && val5.GetValueOrDefault() != val6.GetValueOrDefault()))
								{
									ientityManager_0.RaisePredictiveEvent<RequestSetHandEvent>(new RequestSetHandEvent(text2));
									timeSpan_0 = igameTiming_0.CurTime;
									return;
								}
							}
							if (sfGk5ccZbc.HasValue && sharedToolSystem_0.HasQuality(sfGk5ccZbc.Value, text, (ToolComponent)null))
							{
								_ = ientityManager_0.GetComponent<MetaDataComponent>(sfGk5ccZbc.Value).EntityName;
								ItemToggleComponent val7 = default(ItemToggleComponent);
								if (ientityManager_0.TryGetComponent<ItemToggleComponent>(sfGk5ccZbc.Value, ref val7) && !val7.Activated)
								{
									try
									{
										ientityManager_0.RaisePredictiveEvent<RequestUseInHandEvent>(new RequestUseInHandEvent());
										timeSpan_0 = igameTiming_0.CurTime;
										return;
									}
									catch (Exception)
									{
									}
								}
								SimulateClick(nullable_0.Value);
								float num2 = num + 0.5f;
								bool_1 = true;
								timeSpan_1 = igameTiming_0.CurTime + TimeSpan.FromSeconds(num2);
								nullable_1 = sfGk5ccZbc;
								timeSpan_0 = igameTiming_0.CurTime;
								return;
							}
							if (sfGk5ccZbc.HasValue)
							{
								_ = ientityManager_0.GetComponent<MetaDataComponent>(sfGk5ccZbc.Value).EntityName;
								string_0.Any((string q) => sharedToolSystem_0.HasQuality(sfGk5ccZbc.Value, q, (ToolComponent)null));
							}
							EntityUid? val8 = FindToolInInventory(localEntity.Value, text);
							if (val8.HasValue)
							{
								_ = ientityManager_0.GetComponent<MetaDataComponent>(val8.Value).EntityName;
								if (TryEquipTool(localEntity.Value, val8.Value))
								{
									timeSpan_0 = igameTiming_0.CurTime;
									return;
								}
								int_0++;
								timeSpan_0 = igameTiming_0.CurTime;
							}
							else
							{
								int_0++;
								timeSpan_0 = igameTiming_0.CurTime;
							}
						}
						else
						{
							nullable_0 = null;
							int_3 = 0;
						}
					}
					else if (!(igameTiming_0.CurTime < timeSpan_1))
					{
						bool_1 = false;
						EntityUid? activeItem2 = sharedHandsSystem_0.GetActiveItem(Entity<HandsComponent>.op_Implicit(localEntity.Value));
						if (activeItem2.HasValue)
						{
							_ = ientityManager_0.GetComponent<MetaDataComponent>(activeItem2.Value).EntityName;
							ItemToggleComponent val9 = default(ItemToggleComponent);
							if (ientityManager_0.TryGetComponent<ItemToggleComponent>(activeItem2.Value, ref val9) && val9.Activated)
							{
								try
								{
									ientityManager_0.RaisePredictiveEvent<RequestUseInHandEvent>(new RequestUseInHandEvent());
									bool_2 = true;
									timeSpan_2 = igameTiming_0.CurTime + TimeSpan.FromSeconds(1.0);
									return;
								}
								catch (Exception)
								{
								}
							}
							bool flag = false;
							if (!nullable_2.HasValue || !ientityManager_0.EntityExists(nullable_2.Value))
							{
								if (!string.IsNullOrEmpty(string_2))
								{
									try
									{
										ientityManager_0.RaisePredictiveEvent<UseSlotNetworkMessage>(new UseSlotNetworkMessage(string_2));
										flag = true;
									}
									catch (Exception)
									{
									}
								}
							}
							else
							{
								try
								{
									ScreenCoordinates mouseScreenPosition = iinputManager_0.MouseScreenPosition;
									EntityCoordinates moverCoordinates = sharedTransformSystem_0.GetMoverCoordinates(localEntity.Value);
									KeyFunctionId val10 = iinputManager_0.NetworkBindMap.KeyFunctionID(BoundKeyFunction.op_Implicit("Use"));
									ClientFullInputCmdMessage val11 = new ClientFullInputCmdMessage(igameTiming_0.CurTick, igameTiming_0.TickFraction, val10);
									val11.set_State((BoundKeyState)1);
									val11.set_Coordinates(moverCoordinates);
									val11.set_ScreenCoordinates(mouseScreenPosition);
									val11.set_Uid(nullable_2.Value);
									ClientFullInputCmdMessage val12 = val11;
									ClientFullInputCmdMessage val13 = new ClientFullInputCmdMessage(igameTiming_0.CurTick, igameTiming_0.TickFraction, val10);
									val13.set_State((BoundKeyState)0);
									val13.set_Coordinates(moverCoordinates);
									val13.set_ScreenCoordinates(mouseScreenPosition);
									val13.set_Uid(nullable_2.Value);
									ClientFullInputCmdMessage val14 = val13;
									inputSystem_0.HandleInputCommand(((ISharedPlayerManager)iplayerManager_0).LocalSession, BoundKeyFunction.op_Implicit("Use"), (IFullInputCmdMessage)(object)val12, false);
									inputSystem_0.HandleInputCommand(((ISharedPlayerManager)iplayerManager_0).LocalSession, BoundKeyFunction.op_Implicit("Use"), (IFullInputCmdMessage)(object)val14, false);
									flag = true;
								}
								catch (Exception)
								{
								}
							}
							if (!flag)
							{
								try
								{
									KeyFunctionId val15 = iinputManager_0.NetworkBindMap.KeyFunctionID(BoundKeyFunction.op_Implicit("Drop"));
									ScreenCoordinates mouseScreenPosition2 = iinputManager_0.MouseScreenPosition;
									EntityCoordinates moverCoordinates2 = sharedTransformSystem_0.GetMoverCoordinates(localEntity.Value);
									ClientFullInputCmdMessage val16 = new ClientFullInputCmdMessage(igameTiming_0.CurTick, igameTiming_0.TickFraction, val15);
									val16.set_State((BoundKeyState)1);
									val16.set_Coordinates(moverCoordinates2);
									val16.set_ScreenCoordinates(mouseScreenPosition2);
									val16.set_Uid(localEntity.Value);
									ClientFullInputCmdMessage val17 = val16;
									ClientFullInputCmdMessage val18 = new ClientFullInputCmdMessage(igameTiming_0.CurTick, igameTiming_0.TickFraction, val15);
									val18.set_State((BoundKeyState)0);
									val18.set_Coordinates(moverCoordinates2);
									val18.set_ScreenCoordinates(mouseScreenPosition2);
									val18.set_Uid(localEntity.Value);
									ClientFullInputCmdMessage val19 = val18;
									inputSystem_0.HandleInputCommand(((ISharedPlayerManager)iplayerManager_0).LocalSession, BoundKeyFunction.op_Implicit("Drop"), (IFullInputCmdMessage)(object)val17, false);
									inputSystem_0.HandleInputCommand(((ISharedPlayerManager)iplayerManager_0).LocalSession, BoundKeyFunction.op_Implicit("Drop"), (IFullInputCmdMessage)(object)val19, false);
								}
								catch (Exception)
								{
									sharedHandsSystem_0.TryDrop(Entity<HandsComponent>.op_Implicit(localEntity.Value), activeItem2.Value, (EntityCoordinates?)null, true, true);
								}
							}
						}
						int_2++;
						nullable_1 = null;
						nullable_2 = null;
						string_2 = null;
						timeSpan_0 = igameTiming_0.CurTime;
					}
					else
					{
						_ = (timeSpan_1 - igameTiming_0.CurTime).TotalSeconds;
						_ = (int)(igameTiming_0.CurTime.TotalSeconds * 2.0) % 2;
					}
				}
				else
				{
					if (bool_1)
					{
						return;
					}
					EntityUid? val5 = sharedHandsSystem_0.GetActiveItem(Entity<HandsComponent>.op_Implicit(localEntity.Value));
					EntityUid? val6 = nullable_4;
					if (val5.HasValue == val6.HasValue && (!val5.HasValue || val5.GetValueOrDefault() == val6.GetValueOrDefault()))
					{
						int_3 = 0;
						nullable_4 = null;
						nullable_5 = null;
						string_4 = null;
						return;
					}
					val6 = nullable_3;
					val5 = nullable_5;
					float num3 = ((val6.HasValue == val5.HasValue && (!val6.HasValue || val6.GetValueOrDefault() == val5.GetValueOrDefault()) && string_3 == string_4) ? 0.05f : 0.1f);
					if (igameTiming_0.CurTime >= timeSpan_0 + TimeSpan.FromSeconds(num3) && nullable_4.HasValue && nullable_5.HasValue)
					{
						NetEntity netEntity = ientityManager_0.GetNetEntity(nullable_4.Value, (MetaDataComponent)null);
						NetEntity netEntity2 = ientityManager_0.GetNetEntity(nullable_5.Value, (MetaDataComponent)null);
						if (netEntity != NetEntity.Invalid && netEntity2 != NetEntity.Invalid)
						{
							ientityManager_0.RaisePredictiveEvent<StorageInteractWithItemEvent>(new StorageInteractWithItemEvent(netEntity, netEntity2));
							timeSpan_0 = igameTiming_0.CurTime;
						}
						else
						{
							int_3 = 0;
						}
					}
				}
			}
			else
			{
				nullable_0 = null;
			}
		}
		else
		{
			nullable_0 = null;
		}
	}

	private EntityUid? FindToolInInventory(EntityUid player, string toolQuality)
	{
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		if (!bool_1)
		{
			HandsComponent val = default(HandsComponent);
			InventoryComponent val2 = default(InventoryComponent);
			if (!ientityManager_0.TryGetComponent<HandsComponent>(player, ref val) || !ientityManager_0.TryGetComponent<InventoryComponent>(player, ref val2))
			{
				return null;
			}
			foreach (string key in val.Hands.Keys)
			{
				EntityUid? heldItem = sharedHandsSystem_0.GetHeldItem(Entity<HandsComponent>.op_Implicit(player), key);
				if (heldItem.HasValue && sharedToolSystem_0.HasQuality(heldItem.Value, toolQuality, (ToolComponent)null))
				{
					return heldItem;
				}
			}
			string[] array = new string[4] { "belt", "pocket1", "pocket2", "back" };
			ContainerSlot val3 = default(ContainerSlot);
			SlotDefinition val4 = default(SlotDefinition);
			foreach (string text in array)
			{
				if (!inventorySystem_0.TryGetSlotContainer(player, text, ref val3, ref val4, val2, (ContainerManagerComponent)null))
				{
					continue;
				}
				foreach (EntityUid containedEntity in ((BaseContainer)val3).ContainedEntities)
				{
					if (sharedToolSystem_0.HasQuality(containedEntity, toolQuality, (ToolComponent)null))
					{
						return containedEntity;
					}
					if (ientityManager_0.HasComponent<StorageComponent>(containedEntity))
					{
						EntityUid? result = FindToolInStorage(containedEntity, toolQuality);
						if (result.HasValue)
						{
							return result;
						}
					}
				}
			}
			return null;
		}
		return null;
	}

	private EntityUid? FindToolInStorage(EntityUid storage, string toolQuality)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		StorageComponent val = default(StorageComponent);
		if (!ientityManager_0.TryGetComponent<StorageComponent>(storage, ref val))
		{
			return null;
		}
		foreach (EntityUid containedEntity in ((BaseContainer)val.Container).ContainedEntities)
		{
			if (sharedToolSystem_0.HasQuality(containedEntity, toolQuality, (ToolComponent)null))
			{
				return containedEntity;
			}
		}
		return null;
	}

	private bool TryEquipTool(EntityUid player, EntityUid tool)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_03c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_0413: Unknown result type (might be due to invalid IL or missing references)
		//IL_041d: Expected O, but got Unknown
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_0390: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0365: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Expected O, but got Unknown
		//IL_0308: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (bool_1)
			{
				return false;
			}
			HandsComponent val = default(HandsComponent);
			if (ientityManager_0.TryGetComponent<HandsComponent>(player, ref val))
			{
				foreach (string key in val.Hands.Keys)
				{
					EntityUid? heldItem = sharedHandsSystem_0.GetHeldItem(Entity<HandsComponent>.op_Implicit(player), key);
					EntityUid val2 = tool;
					if (heldItem.HasValue && heldItem.GetValueOrDefault() == val2)
					{
						ientityManager_0.RaisePredictiveEvent<RequestSetHandEvent>(new RequestSetHandEvent(key));
						return true;
					}
				}
				EntityUid? activeItem = sharedHandsSystem_0.GetActiveItem(Entity<HandsComponent>.op_Implicit(player));
				if (!activeItem.HasValue || IsVirtualItem(activeItem.Value))
				{
					InventoryComponent val3 = default(InventoryComponent);
					if (ientityManager_0.TryGetComponent<InventoryComponent>(player, ref val3))
					{
						string[] array = new string[4] { "belt", "pocket1", "pocket2", "back" };
						ContainerSlot val4 = default(ContainerSlot);
						SlotDefinition val5 = default(SlotDefinition);
						StorageComponent val6 = default(StorageComponent);
						foreach (string text in array)
						{
							if (!inventorySystem_0.TryGetSlotContainer(player, text, ref val4, ref val5, val3, (ContainerManagerComponent)null))
							{
								continue;
							}
							if (((BaseContainer)val4).ContainedEntities.Contains(tool))
							{
								nullable_2 = null;
								string_2 = text;
								ientityManager_0.RaisePredictiveEvent<UseSlotNetworkMessage>(new UseSlotNetworkMessage(text));
								return true;
							}
							foreach (EntityUid containedEntity in ((BaseContainer)val4).ContainedEntities)
							{
								if (ientityManager_0.HasComponent<StorageComponent>(containedEntity) && ientityManager_0.TryGetComponent<StorageComponent>(containedEntity, ref val6) && ((BaseContainer)val6.Container).ContainedEntities.Contains(tool))
								{
									nullable_2 = containedEntity;
									string_2 = text;
									EntityUid? heldItem = nullable_3;
									EntityUid val2 = containedEntity;
									if (!heldItem.HasValue || heldItem.GetValueOrDefault() != val2 || string_3 != text)
									{
										ientityManager_0.RaisePredictiveEvent<OpenSlotStorageNetworkMessage>(new OpenSlotStorageNetworkMessage(text));
										nullable_3 = containedEntity;
										string_3 = text;
									}
									int_3 = 2;
									nullable_4 = tool;
									nullable_5 = containedEntity;
									string_4 = text;
									timeSpan_0 = igameTiming_0.CurTime;
									return true;
								}
							}
						}
						return false;
					}
					return false;
				}
				_ = ientityManager_0.GetComponent<MetaDataComponent>(activeItem.Value).EntityName;
				string text2 = null;
				foreach (string key2 in val.Hands.Keys)
				{
					EntityUid? heldItem2 = sharedHandsSystem_0.GetHeldItem(Entity<HandsComponent>.op_Implicit(player), key2);
					if (!heldItem2.HasValue || IsVirtualItem(heldItem2.Value))
					{
						text2 = key2;
						break;
					}
				}
				if (text2 == null)
				{
					return false;
				}
				ientityManager_0.RaisePredictiveEvent<RequestSetHandEvent>(new RequestSetHandEvent(text2));
				return true;
			}
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}

	private bool IsVirtualItem(EntityUid entityUid)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		if (ientityManager_0.EntityExists(entityUid))
		{
			MetaDataComponent val = default(MetaDataComponent);
			if (!ientityManager_0.TryGetComponent<MetaDataComponent>(entityUid, ref val) || val.EntityPrototype == null || !val.EntityPrototype.ID.Contains("VirtualItem", StringComparison.OrdinalIgnoreCase))
			{
				return false;
			}
			return true;
		}
		return false;
	}

	private void SimulateClick(EntityUid target)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (!localEntity.HasValue)
		{
			return;
		}
		try
		{
			ScreenCoordinates mouseScreenPosition = iinputManager_0.MouseScreenPosition;
			EntityCoordinates moverCoordinates = sharedTransformSystem_0.GetMoverCoordinates(localEntity.Value);
			KeyFunctionId val;
			try
			{
				val = iinputManager_0.NetworkBindMap.KeyFunctionID(BoundKeyFunction.op_Implicit("Use"));
			}
			catch
			{
				return;
			}
			ClientFullInputCmdMessage val2 = new ClientFullInputCmdMessage(igameTiming_0.CurTick, igameTiming_0.TickFraction, val);
			val2.set_State((BoundKeyState)1);
			val2.set_Coordinates(moverCoordinates);
			val2.set_ScreenCoordinates(mouseScreenPosition);
			val2.set_Uid(target);
			ClientFullInputCmdMessage val3 = val2;
			ClientFullInputCmdMessage val4 = new ClientFullInputCmdMessage(igameTiming_0.CurTick, igameTiming_0.TickFraction, val);
			val4.set_State((BoundKeyState)0);
			val4.set_Coordinates(moverCoordinates);
			val4.set_ScreenCoordinates(mouseScreenPosition);
			val4.set_Uid(target);
			ClientFullInputCmdMessage val5 = val4;
			inputSystem_0.HandleInputCommand(((ISharedPlayerManager)iplayerManager_0).LocalSession, BoundKeyFunction.op_Implicit("Use"), (IFullInputCmdMessage)(object)val3, false);
			inputSystem_0.HandleInputCommand(((ISharedPlayerManager)iplayerManager_0).LocalSession, BoundKeyFunction.op_Implicit("Use"), (IFullInputCmdMessage)(object)val5, false);
		}
		catch (Exception)
		{
		}
	}

	private EntityUid? GetTargetUnderCursor(EntityUid player)
	{
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		ScreenCoordinates mouseScreenPosition = iinputManager_0.MouseScreenPosition;
		MapCoordinates val = ieyeManager_0.ScreenToMap(mouseScreenPosition);
		TransformComponent val2 = default(TransformComponent);
		if (ientityManager_0.TryGetComponent<TransformComponent>(player, ref val2))
		{
			if (!(val2.MapPosition.MapId != val.MapId))
			{
				EntityLookupSystem entitySystem = ientitySystemManager_0.GetEntitySystem<EntityLookupSystem>();
				Box2 val3 = Box2.CenteredAround(val.Position, new Vector2(0.5f, 0.5f));
				HashSet<EntityUid> entitiesIntersecting = entitySystem.GetEntitiesIntersecting(val.MapId, val3, (LookupFlags)110);
				EntityUid? result = null;
				float num = float.MaxValue;
				{
					MetaDataComponent val4 = default(MetaDataComponent);
					TransformComponent val5 = default(TransformComponent);
					foreach (EntityUid item in entitiesIntersecting)
					{
						if (!(item == player) && ientityManager_0.TryGetComponent<MetaDataComponent>(item, ref val4) && ientityManager_0.TryGetComponent<TransformComponent>(item, ref val5))
						{
							float num2 = (val5.WorldPosition - val.Position).Length();
							if (num2 < num)
							{
								num = num2;
								result = item;
							}
						}
					}
					return result;
				}
			}
			return null;
		}
		return null;
	}
}
