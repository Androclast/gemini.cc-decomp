using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Content.Client.Verbs;
using Content.Client.Weapons.Ranged.Systems;
using Content.Shared.Containers.ItemSlots;
using Content.Shared.Hands;
using Content.Shared.Hands.Components;
using Content.Shared.Hands.EntitySystems;
using Content.Shared.Inventory;
using Content.Shared.Inventory.Events;
using Content.Shared.Storage;
using Content.Shared.Storage.EntitySystems;
using Content.Shared.Verbs;
using Content.Shared.Weapons.Ranged;
using Content.Shared.Weapons.Ranged.Components;
using Content.Shared.Weapons.Ranged.Events;
using Content.Shared.Whitelist;
using Robust.Client.Graphics;
using Robust.Client.Input;
using Robust.Client.Player;
using Robust.Client.ResourceManagement;
using Robust.Shared.Containers;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Localization;
using Robust.Shared.Maths;
using Robust.Shared.Player;
using Robust.Shared.Prototypes;
using Robust.Shared.Timing;
using CerberusConfig;

public sealed class MagazineEspOverlay : Overlay
{
	[StructLayout(LayoutKind.Auto)]
	private struct Enum0 : Enum
	{
	}

	private readonly record struct FoundMagazineInfo
	{
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

		[CompilerGenerated]
		private readonly EntityUid NueTSbTaEp;

		[CompilerGenerated]
		private readonly Enum0 alKTOiGkJx;

		[CompilerGenerated]
		private readonly string q0oTdnDRIL;

		[CompilerGenerated]
		private readonly EntityUid? fQaT7chKMl;

		[CompilerGenerated]
		private readonly string CYKT4jV6bs;

		[CompilerGenerated]
		private readonly string X9ETTIqQnT;

		[CompilerGenerated]
		private readonly bool yuJTNF645f;

		private float float_0;

		private string string_0;

		public FoundMagazineInfo(EntityUid MagazineUid, Enum0 SourceType, string HandName = null, EntityUid? ContainerEntityUid = null, string ContainerParentSlotId = null, string DirectSlotId = null)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			ePiTUFw1eN(MagazineUid);
			Ej5TbHXfCW(SourceType);
			I2kTu8ya8A(HandName);
			grHTFwL5KU(ContainerEntityUid);
			IsPTcicGFm(ContainerParentSlotId);
			HqUTqUNfIM(DirectSlotId);
			tyLTJ1v5H9(bool_0: true);
		}

		[SpecialName]
		[CompilerGenerated]
		public EntityUid RYbTCAwwlp()
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return NueTSbTaEp;
		}

		[SpecialName]
		[CompilerGenerated]
		public void ePiTUFw1eN(EntityUid entityUid_0)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			NueTSbTaEp = entityUid_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public Enum0 iKKTsJDSHx()
		{
			return alKTOiGkJx;
		}

		[SpecialName]
		[CompilerGenerated]
		public void Ej5TbHXfCW(Enum0 enum0_0)
		{
			alKTOiGkJx = enum0_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public string vHcTDa2Vk7()
		{
			return q0oTdnDRIL;
		}

		[SpecialName]
		[CompilerGenerated]
		public void I2kTu8ya8A(string string_1)
		{
			q0oTdnDRIL = string_1;
		}

		[SpecialName]
		[CompilerGenerated]
		public EntityUid? QaWTLIGNF5()
		{
			return fQaT7chKMl;
		}

		[SpecialName]
		[CompilerGenerated]
		public void grHTFwL5KU(EntityUid? nullable_0)
		{
			fQaT7chKMl = nullable_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public string WqMTXw6GJW()
		{
			return CYKT4jV6bs;
		}

		[SpecialName]
		[CompilerGenerated]
		public void IsPTcicGFm(string string_1)
		{
			CYKT4jV6bs = string_1;
		}

		[SpecialName]
		[CompilerGenerated]
		public string gbYTEWX2TD()
		{
			return X9ETTIqQnT;
		}

		[SpecialName]
		[CompilerGenerated]
		public void HqUTqUNfIM(string string_1)
		{
			X9ETTIqQnT = string_1;
		}

		public FoundMagazineInfo()
			: this(default(EntityUid), (Enum0)0)
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Expected O, but got I4
			tyLTJ1v5H9(bool_0: false);
		}

		[SpecialName]
		[CompilerGenerated]
		public bool pPjTRUogeZ()
		{
			return yuJTNF645f;
		}

		[SpecialName]
		[CompilerGenerated]
		public void tyLTJ1v5H9(bool bool_0)
		{
			yuJTNF645f = bool_0;
		}

		[CompilerGenerated]
		private bool PrintMembers(StringBuilder builder)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			builder.Append("MagazineUid = ");
			builder.Append(((object)RYbTCAwwlp()/*cast due to constrained. prefix*/).ToString());
			builder.Append(", SourceType = ");
			builder.Append(iKKTsJDSHx().ToString());
			builder.Append(", HandName = ");
			builder.Append(vHcTDa2Vk7());
			builder.Append(", ContainerEntityUid = ");
			builder.Append(QaWTLIGNF5().ToString());
			builder.Append(", ContainerParentSlotId = ");
			builder.Append(WqMTXw6GJW());
			builder.Append(", DirectSlotId = ");
			builder.Append(gbYTEWX2TD());
			builder.Append(", IsValid = ");
			builder.Append(pPjTRUogeZ().ToString());
			return true;
		}

		[CompilerGenerated]
		public override int GetHashCode()
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			return (((((EqualityComparer<EntityUid>.Default.GetHashCode(RYbTCAwwlp()) * -1521134295 + EqualityComparer<Enum0>.Default.GetHashCode(iKKTsJDSHx())) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(vHcTDa2Vk7())) * -1521134295 + EqualityComparer<EntityUid?>.Default.GetHashCode(QaWTLIGNF5())) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(WqMTXw6GJW())) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(gbYTEWX2TD())) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(pPjTRUogeZ());
		}

		[CompilerGenerated]
		public bool Equals(FoundMagazineInfo other)
		{
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			if (EqualityComparer<EntityUid>.Default.Equals(RYbTCAwwlp(), other.RYbTCAwwlp()) && EqualityComparer<Enum0>.Default.Equals(iKKTsJDSHx(), other.iKKTsJDSHx()) && EqualityComparer<string>.Default.Equals(vHcTDa2Vk7(), other.vHcTDa2Vk7()) && EqualityComparer<EntityUid?>.Default.Equals(QaWTLIGNF5(), other.QaWTLIGNF5()) && EqualityComparer<string>.Default.Equals(WqMTXw6GJW(), other.WqMTXw6GJW()) && EqualityComparer<string>.Default.Equals(gbYTEWX2TD(), other.gbYTEWX2TD()))
			{
				return EqualityComparer<bool>.Default.Equals(pPjTRUogeZ(), other.pPjTRUogeZ());
			}
			return false;
		}

		[CompilerGenerated]
		public void Deconstruct(out EntityUid MagazineUid, out Enum0 SourceType, out string HandName, out EntityUid? ContainerEntityUid, out string ContainerParentSlotId, out string DirectSlotId)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected I4, but got O
			MagazineUid = RYbTCAwwlp();
			Unsafe.As<Enum0, int>(ref SourceType) = (int)iKKTsJDSHx();
			HandName = vHcTDa2Vk7();
			ContainerEntityUid = QaWTLIGNF5();
			ContainerParentSlotId = WqMTXw6GJW();
			DirectSlotId = gbYTEWX2TD();
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct Enum1 : Enum
	{
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003C_003Ec__DisplayClass84_0
	{
		public MagazineEspOverlay NqtNV3CtwD;

		public BallisticAmmoProviderComponent gdUNaUWE3m;
	}

	[Dependency]
	private readonly IResourceCache iresourceCache_0;

	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly IInputManager iinputManager_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IEntitySystemManager ientitySystemManager_0;

	private VerbSystem verbSystem_0;

	private SharedHandsSystem sharedHandsSystem_0;

	private SharedStorageSystem sharedStorageSystem_0;

	private InventorySystem inventorySystem_0;

	private SharedContainerSystem sharedContainerSystem_0;

	private EntityWhitelistSystem entityWhitelistSystem_0;

	private GunSystem gunSystem_0;

	private readonly Font font_0;

	private TimeSpan timeSpan_0;

	private TimeSpan timeSpan_1;

	private TimeSpan timeSpan_2;

	private TimeSpan timeSpan_3;

	private TimeSpan timeSpan_4;

	private TimeSpan timeSpan_5;

	private EntityUid? nullable_0;

	private bool bool_0;

	private int int_0;

	private EntityUid? nullable_1;

	private EntityUid? nullable_2;

	private EntityUid? nullable_3;

	private string string_1;

	private bool bool_1;

	private TimeSpan timeSpan_6;

	private readonly float float_0 = 1.5f;

	private FoundMagazineInfo foundMagazineInfo_0;

	private string string_2;

	private string string_3;

	private float float_1;

	public override OverlaySpace Space => (OverlaySpace)2;

	private string String_0
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
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

	public MagazineEspOverlay()
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		IoCManager.InjectDependencies<MagazineEspOverlay>(this);
		((Overlay)this).ZIndex = 200;
		if (font_0 == null)
		{
			font_0 = (Font)new VectorFont(iresourceCache_0.GetResource<FontResource>("/Fonts/Boxfont-round/Boxfont Round.ttf", true), 10);
		}
	}

	[SpecialName]
	private static TimeSpan DpJaRUYwhv()
	{
		return TimeSpan.FromSeconds(CerberusConfig.GunHelper.AutoReloadDelay);
	}

	private void ResetReloadState()
	{
		int num = int_0;
		int_0 = 0;
		nullable_1 = null;
		nullable_2 = null;
		nullable_3 = null;
		string_1 = null;
		bool_1 = false;
		foundMagazineInfo_0 = new FoundMagazineInfo();
		string_2 = null;
		timeSpan_6 = igameTiming_0.CurTime;
		if (num > 0)
		{
			timeSpan_0 = igameTiming_0.CurTime;
		}
	}

	private void SetReloadState(int newState)
	{
		if (int_0 != newState)
		{
			int_0 = newState;
			timeSpan_6 = igameTiming_0.CurTime;
			bool_1 = false;
		}
	}

	private bool CanPerformAction()
	{
		return igameTiming_0.CurTime >= timeSpan_2 + DpJaRUYwhv();
	}

	private void RecordActionAttempt()
	{
		timeSpan_2 = igameTiming_0.CurTime;
		bool_1 = true;
		if (int_0 != 0 && int_0 != 1)
		{
			timeSpan_0 = igameTiming_0.CurTime;
		}
	}

	private void InitializeSystems()
	{
		if (verbSystem_0 == null)
		{
			verbSystem_0 = ientitySystemManager_0.GetEntitySystem<VerbSystem>();
		}
		if (sharedHandsSystem_0 == null)
		{
			sharedHandsSystem_0 = ientitySystemManager_0.GetEntitySystem<SharedHandsSystem>();
		}
		if (sharedStorageSystem_0 == null)
		{
			sharedStorageSystem_0 = ientitySystemManager_0.GetEntitySystem<SharedStorageSystem>();
		}
		if (inventorySystem_0 == null)
		{
			inventorySystem_0 = ientitySystemManager_0.GetEntitySystem<InventorySystem>();
		}
		if (sharedContainerSystem_0 == null)
		{
			sharedContainerSystem_0 = ientitySystemManager_0.GetEntitySystem<SharedContainerSystem>();
		}
		if (entityWhitelistSystem_0 == null)
		{
			entityWhitelistSystem_0 = ientitySystemManager_0.GetEntitySystem<EntityWhitelistSystem>();
		}
		if (gunSystem_0 == null)
		{
			gunSystem_0 = ientitySystemManager_0.GetEntitySystem<GunSystem>();
		}
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_037c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Expected I8, but got I4
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		if (CerberusConfig.GunHelper.Enabled)
		{
			InitializeSystems();
			EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
			if (localEntity.HasValue && gunSystem_0 != null)
			{
				bool_1 = false;
				EntityUid? val = null;
				EntityUid? val2 = default(EntityUid?);
				GunComponent val3 = default(GunComponent);
				if (sharedHandsSystem_0.TryGetActiveItem(Entity<HandsComponent>.op_Implicit(localEntity.Value), ref val2) && ientityManager_0.TryGetComponent<GunComponent>(val2.Value, ref val3))
				{
					val = val2.Value;
				}
				if (val.HasValue)
				{
					DisplayAmmoInfo(in args, val.Value);
					if (CerberusConfig.GunHelper.AutoBolt && igameTiming_0.CurTime >= timeSpan_3 + TimeSpan.FromMilliseconds(10L))
					{
						timeSpan_3 = igameTiming_0.CurTime;
						bool flag = bool_1;
						bool_1 = false;
						HandleAutoBoltClose(localEntity.Value, val.Value);
						bool num = bool_1;
						bool_1 = false;
						HandleAutoChamberRack(localEntity.Value, val.Value);
						if (!num && !bool_1)
						{
							bool_1 = flag;
						}
						else
						{
							bool_1 = true;
						}
					}
				}
				if (CerberusConfig.GunHelper.AutoReload)
				{
					EntityUid? val4 = null;
					if (int_0 == 0 || !nullable_3.HasValue || !ientityManager_0.EntityExists(nullable_3.Value))
					{
						HandsComponent val5 = default(HandsComponent);
						if (val.HasValue)
						{
							val4 = val;
						}
						else if (ientityManager_0.TryGetComponent<HandsComponent>(localEntity.Value, ref val5))
						{
							foreach (string key in val5.Hands.Keys)
							{
								EntityUid? heldItem = sharedHandsSystem_0.GetHeldItem(Entity<HandsComponent>.op_Implicit(localEntity.Value), key);
								if (heldItem.HasValue && IsShotgunType(heldItem.Value))
								{
									val4 = heldItem;
									break;
								}
							}
						}
					}
					else
					{
						val4 = nullable_3;
					}
					if (val4.HasValue && (!bool_1 || int_0 == 15 || int_0 == 16))
					{
						if (IsShotgunType(val4.Value))
						{
							HandleShotgunReload(localEntity.Value, val4.Value);
						}
						else
						{
							HandleAutoMagazineReload(localEntity.Value, val4.Value);
						}
					}
					else if (int_0 != 0 && !val4.HasValue)
					{
						ResetReloadState();
					}
				}
				else if (int_0 > 0)
				{
					ResetReloadState();
				}
			}
			else if (int_0 > 0)
			{
				ResetReloadState();
			}
		}
		else if (int_0 > 0)
		{
			ResetReloadState();
		}
	}

	private void DisplayAmmoInfo(in OverlayDrawArgs args, EntityUid gunUid)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		if (CerberusConfig.GunHelper.ShowAmmo)
		{
			GetAmmoCountEvent val = default(GetAmmoCountEvent);
			((IDirectedEventBus)ientityManager_0.EventBus).RaiseLocalEvent<GetAmmoCountEvent>(gunUid, ref val, false);
			int count = val.Count;
			int capacity = val.Capacity;
			Vector2 position = iinputManager_0.MouseScreenPosition.Position;
			DrawingHandleScreen screenHandle = ((OverlayDrawArgs)(ref args)).ScreenHandle;
			if (font_0 != null)
			{
				Vector2 vector = new Vector2(position.X - 10f, position.Y + 30f);
				screenHandle.DrawString(font_0, vector, $"{count}/{capacity}", Color.White);
			}
			if (capacity > 0)
			{
				DrawAmmoCircle(screenHandle, position, count, capacity);
			}
		}
	}

	private void DrawAmmoCircle(DrawingHandleScreen handle, Vector2 center, int current, int max)
	{
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		float num = 35f;
		float num2 = 6f;
		float num3 = (float)Math.PI * 3f / 4f;
		float num4 = ((max <= 1) ? 0f : 0.06f);
		float num5 = 4.712389f - num4 * (float)(max - 1);
		if (!(num5 >= 0f))
		{
			num5 = 0f;
		}
		float num6 = ((max <= 0) ? 0f : (num5 / (float)max));
		for (int i = 0; i < max; i++)
		{
			float num7 = num3 + (float)i * (num6 + num4);
			Color val;
			if (i >= current)
			{
				Color black = Color.Black;
				val = ((Color)(ref black)).WithAlpha(0.4f);
			}
			else
			{
				float num8 = (float)current / (float)max;
				val = ((!(num8 <= 0.5f)) ? Color.LimeGreen : ((!(num8 <= 0.2f)) ? Color.Yellow : Color.Red));
			}
			float num9 = num6 / 8f;
			for (int j = 0; j < 8; j++)
			{
				float x = num7 + (float)j * num9;
				float x2 = num7 + (float)(j + 1) * num9;
				float num10 = 0.5f;
				for (float num11 = num - num2 / 2f; !(num11 > num + num2 / 2f); num11 += num10)
				{
					Vector2 vector = center + new Vector2(MathF.Cos(x), MathF.Sin(x)) * num11;
					Vector2 vector2 = center + new Vector2(MathF.Cos(x2), MathF.Sin(x2)) * num11;
					((DrawingHandleBase)handle).DrawLine(vector, vector2, val);
				}
			}
		}
	}

	private void HandleAutoBoltClose(EntityUid playerUid, EntityUid gunUid)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		ChamberMagazineAmmoProviderComponent val = default(ChamberMagazineAmmoProviderComponent);
		if (!ientityManager_0.TryGetComponent<ChamberMagazineAmmoProviderComponent>(gunUid, ref val) || verbSystem_0 == null || sharedContainerSystem_0 == null)
		{
			return;
		}
		BaseContainer val2 = default(BaseContainer);
		bool flag = sharedContainerSystem_0.TryGetContainer(gunUid, "gun_chamber", ref val2, (ContainerManagerComponent)null) && val2.ContainedEntities.Count > 0;
		bool flag2 = false;
		BaseContainer val3 = default(BaseContainer);
		if (!flag && sharedContainerSystem_0.TryGetContainer(gunUid, "gun_magazine", ref val3, (ContainerManagerComponent)null) && val3.ContainedEntities.Any())
		{
			EntityUid val4 = val3.ContainedEntities.First();
			GetAmmoCountEvent val5 = default(GetAmmoCountEvent);
			((IDirectedEventBus)ientityManager_0.EventBus).RaiseLocalEvent<GetAmmoCountEvent>(val4, ref val5, false);
			if (val5.Count > 0)
			{
				flag2 = true;
			}
		}
		if (val.BoltClosed != true && (flag || flag2))
		{
			string xvnTKWJ6eZ = Loc.GetString("gun-chamber-bolt-close");
			VerbSystem obj = verbSystem_0;
			List<Type> list = new List<Type>(2);
			CollectionsMarshal.SetCount(list, 2);
			Span<Type> span = CollectionsMarshal.AsSpan(list);
			int num = 0;
			span[num] = typeof(Verb);
			num++;
			span[num] = typeof(InteractionVerb);
			Verb val6 = ((SharedVerbSystem)obj).GetLocalVerbs(gunUid, playerUid, list, false).FirstOrDefault((Verb v) => v.Text == xvnTKWJ6eZ && !v.Disabled);
			if (val6 != null)
			{
				ientityManager_0.RaisePredictiveEvent<ExecuteVerbEvent>(new ExecuteVerbEvent(ientityManager_0.GetNetEntity(gunUid, (MetaDataComponent)null), val6));
				bool_1 = true;
			}
		}
	}

	private void HandleAutoChamberRack(EntityUid playerUid, EntityUid gunUid)
	{
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected O, but got Unknown
		ChamberMagazineAmmoProviderComponent val = default(ChamberMagazineAmmoProviderComponent);
		BaseContainer val2 = default(BaseContainer);
		if (!CanPerformAction() || igameTiming_0.CurTime <= timeSpan_1 + TimeSpan.FromSeconds(0.5) || !ientityManager_0.TryGetComponent<ChamberMagazineAmmoProviderComponent>(gunUid, ref val) || verbSystem_0 == null || sharedContainerSystem_0 == null || (sharedContainerSystem_0.TryGetContainer(gunUid, "gun_chamber", ref val2, (ContainerManagerComponent)null) && val2.ContainedEntities.Any()) || val.BoltClosed != true)
		{
			return;
		}
		bool flag = false;
		BaseContainer val3 = default(BaseContainer);
		if (sharedContainerSystem_0.TryGetContainer(gunUid, "gun_magazine", ref val3, (ContainerManagerComponent)null) && val3.ContainedEntities.Any())
		{
			EntityUid val4 = val3.ContainedEntities.First();
			GetAmmoCountEvent val5 = default(GetAmmoCountEvent);
			((IDirectedEventBus)ientityManager_0.EventBus).RaiseLocalEvent<GetAmmoCountEvent>(val4, ref val5, false);
			if (val5.Count > 0)
			{
				flag = true;
			}
		}
		if (flag)
		{
			Verb val6 = ((SharedVerbSystem)verbSystem_0).GetLocalVerbs(gunUid, playerUid, typeof(Verb), false).FirstOrDefault((Verb v) => v.Text == Loc.GetString("gun-chamber-rack") && !v.Disabled);
			if (val6 != null)
			{
				ientityManager_0.RaisePredictiveEvent<ExecuteVerbEvent>(new ExecuteVerbEvent(ientityManager_0.GetNetEntity(gunUid, (MetaDataComponent)null), val6));
				timeSpan_1 = igameTiming_0.CurTime;
				RecordActionAttempt();
			}
		}
	}

	private void HandleAutoMagazineReload(EntityUid playerUid, EntityUid gunUid)
	{
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		if (int_0 != 0 && igameTiming_0.CurTime > timeSpan_6 + TimeSpan.FromSeconds(float_0))
		{
			ResetReloadState();
		}
		else if ((int_0 != 0 || !(igameTiming_0.CurTime < timeSpan_0 + TimeSpan.FromSeconds(CerberusConfig.GunHelper.AutoReloadDelay))) && (CanPerformAction() || int_0 == 0 || int_0 == 1 || int_0 == 2 || int_0 == 11 || int_0 == 13))
		{
			switch (int_0)
			{
			case 16:
				ExecutePostReloadRack(playerUid, gunUid, 0);
				break;
			case 10:
				ExecuteEjectingOldMagazine(playerUid, gunUid);
				break;
			case 15:
				ExecutePostReloadRack(playerUid, gunUid, 16);
				break;
			case 12:
				ExecuteReadyToInsertNewMagazine(playerUid, gunUid);
				break;
			case 9:
				ExecuteNewMagazineInHand(playerUid, gunUid);
				break;
			case 5:
				ExecuteSwitchingToFreeHandForContainerTake(playerUid, gunUid);
				break;
			case 4:
				ExecuteRequestingOpenContainerSlot();
				break;
			case 8:
				ExecuteTakingDirectlyFromPocketSlot(playerUid);
				break;
			case 7:
				ExecutePreparingToTakeFromPocketSlot(playerUid, gunUid);
				break;
			case 2:
				ExecuteFindingNewMagazine(playerUid, gunUid);
				break;
			case 13:
				ExecuteWaitingForInsertConfirm(playerUid, gunUid);
				break;
			case 11:
				ExecuteWaitingForEject(gunUid);
				break;
			case 6:
				ExecuteTakingMagazineFromOpenedContainer(playerUid);
				break;
			case 0:
			case 1:
				ExecuteCheckingNeed(playerUid, gunUid);
				break;
			case 14:
				ExecuteSwitchingBackToGunHand(playerUid);
				break;
			case 3:
				ExecuteSwitchingToNewMagazineHand(playerUid);
				break;
			}
		}
	}

	private void ExecuteCheckingNeed(EntityUid playerUid, EntityUid gunUidFromContext)
	{
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		timeSpan_0 = igameTiming_0.CurTime;
		bool flag = false;
		nullable_2 = null;
		BaseContainer val = default(BaseContainer);
		if (sharedContainerSystem_0.TryGetContainer(gunUidFromContext, "gun_magazine", ref val, (ContainerManagerComponent)null))
		{
			if (val.ContainedEntities.Any())
			{
				nullable_2 = val.ContainedEntities.First();
				GetAmmoCountEvent val2 = default(GetAmmoCountEvent);
				((IDirectedEventBus)ientityManager_0.EventBus).RaiseLocalEvent<GetAmmoCountEvent>(nullable_2.Value, ref val2, false);
				if (val2.Count == 0 || val2.Count <= 3)
				{
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
			if (flag)
			{
				nullable_3 = gunUidFromContext;
				string_1 = null;
				HandsComponent val3 = default(HandsComponent);
				if (ientityManager_0.TryGetComponent<HandsComponent>(playerUid, ref val3))
				{
					foreach (string key in val3.Hands.Keys)
					{
						string text = key;
						EntityUid? heldItem = sharedHandsSystem_0.GetHeldItem(Entity<HandsComponent>.op_Implicit(playerUid), key);
						EntityUid? val4 = nullable_3;
						if (heldItem.HasValue == val4.HasValue && (!heldItem.HasValue || heldItem.GetValueOrDefault() == val4.GetValueOrDefault()))
						{
							string_1 = text;
							break;
						}
					}
				}
				SetReloadState(2);
			}
			else
			{
				EntityUid? heldItem = nullable_3;
				EntityUid val5 = gunUidFromContext;
				if ((heldItem.HasValue && heldItem.GetValueOrDefault() == val5) || int_0 > 0)
				{
					ResetReloadState();
				}
			}
		}
		else
		{
			EntityUid? val4 = nullable_3;
			EntityUid val5 = gunUidFromContext;
			if (val4.HasValue && val4.GetValueOrDefault() == val5)
			{
				ResetReloadState();
			}
		}
	}

	private bool CanFreeHandToRetrieve(EntityUid playerUid, EntityUid gunBeingReloaded)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		HandsComponent val = default(HandsComponent);
		if (ientityManager_0.TryGetComponent<HandsComponent>(playerUid, ref val) && sharedHandsSystem_0 != null)
		{
			sharedHandsSystem_0.GetActiveHand(Entity<HandsComponent>.op_Implicit(playerUid));
			foreach (string key in val.Hands.Keys)
			{
				EntityUid? heldItem = sharedHandsSystem_0.GetHeldItem(Entity<HandsComponent>.op_Implicit(playerUid), key);
				if (!heldItem.HasValue || !(heldItem.GetValueOrDefault() == gunBeingReloaded))
				{
					continue;
				}
				foreach (string key2 in val.Hands.Keys)
				{
					if (!(key2 == key))
					{
						EntityUid? heldItem2 = sharedHandsSystem_0.GetHeldItem(Entity<HandsComponent>.op_Implicit(playerUid), key2);
						if (!heldItem2.HasValue || IsVirtualItem(heldItem2.Value))
						{
							return true;
						}
					}
				}
				return false;
			}
			foreach (string key3 in val.Hands.Keys)
			{
				EntityUid? heldItem3 = sharedHandsSystem_0.GetHeldItem(Entity<HandsComponent>.op_Implicit(playerUid), key3);
				if (!heldItem3.HasValue || IsVirtualItem(heldItem3.Value))
				{
					return true;
				}
			}
			return false;
		}
		return false;
	}

	private void ExecuteFindingNewMagazine(EntityUid playerUid, EntityUid gunUid)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected I4, but got O
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		if (TryFindMagazineForReload(playerUid, gunUid, out foundMagazineInfo_0) && (!foundMagazineInfo_0.pPjTRUogeZ() || ((long)igameTiming_0.CurTime.TotalMilliseconds ^ ((object)foundMagazineInfo_0.RYbTCAwwlp()/*cast due to constrained. prefix*/).GetHashCode()) % 300007 != 21))
		{
			nullable_1 = foundMagazineInfo_0.RYbTCAwwlp();
			GetAmmoCountEvent val = default(GetAmmoCountEvent);
			((IDirectedEventBus)ientityManager_0.EventBus).RaiseLocalEvent<GetAmmoCountEvent>(foundMagazineInfo_0.RYbTCAwwlp(), ref val, false);
			if (val.Count <= 0)
			{
				bool flag = false;
				BaseContainer val2 = default(BaseContainer);
				if (sharedContainerSystem_0.TryGetContainer(gunUid, "gun_magazine", ref val2, (ContainerManagerComponent)null))
				{
					if (!val2.ContainedEntities.Any())
					{
						flag = true;
					}
					else
					{
						EntityUid val3 = val2.ContainedEntities.First();
						GetAmmoCountEvent val4 = default(GetAmmoCountEvent);
						((IDirectedEventBus)ientityManager_0.EventBus).RaiseLocalEvent<GetAmmoCountEvent>(val3, ref val4, false);
						if (val4.Count == 0)
						{
							flag = true;
						}
					}
				}
				else
				{
					flag = true;
				}
				if (flag)
				{
					ResetReloadState();
					return;
				}
			}
			if (((nint)foundMagazineInfo_0.iKKTsJDSHx() == 1 || (nint)foundMagazineInfo_0.iKKTsJDSHx() == 2) && !CanFreeHandToRetrieve(playerUid, gunUid))
			{
				ResetReloadState();
				return;
			}
			switch ((int)foundMagazineInfo_0.iKKTsJDSHx())
			{
			case 0:
				if (sharedHandsSystem_0.GetActiveHand(Entity<HandsComponent>.op_Implicit(playerUid)) != null)
				{
					EntityUid? activeItem = sharedHandsSystem_0.GetActiveItem(Entity<HandsComponent>.op_Implicit(playerUid));
					EntityUid? val5 = activeItem;
					EntityUid? val6 = nullable_1;
					SetReloadState((val5.HasValue != val6.HasValue || (val5.HasValue && !(val5.GetValueOrDefault() == val6.GetValueOrDefault()))) ? 3 : 9);
				}
				else
				{
					ResetReloadState();
				}
				break;
			default:
				ResetReloadState();
				break;
			case 2:
				if (!string.IsNullOrEmpty(foundMagazineInfo_0.gbYTEWX2TD()))
				{
					SetReloadState(7);
				}
				else
				{
					ResetReloadState();
				}
				break;
			case 1:
				string_2 = foundMagazineInfo_0.WqMTXw6GJW();
				if (!string.IsNullOrEmpty(string_2) && foundMagazineInfo_0.QaWTLIGNF5().HasValue)
				{
					SetReloadState(4);
				}
				else
				{
					ResetReloadState();
				}
				break;
			}
		}
		else
		{
			ResetReloadState();
		}
	}

	private void TryRequestHandSwitch(string targetHandName)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		ientityManager_0.RaisePredictiveEvent<RequestSetHandEvent>(new RequestSetHandEvent(targetHandName));
		RecordActionAttempt();
	}

	private string FindOtherFreeHandName(EntityUid playerUid, string currentActiveHandName)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		HandsComponent val = default(HandsComponent);
		if (!ientityManager_0.TryGetComponent<HandsComponent>(playerUid, ref val))
		{
			return null;
		}
		return (from h in val.Hands.Keys
			where h != currentActiveHandName
			let held = sharedHandsSystem_0.GetHeldItem(Entity<HandsComponent>.op_Implicit(playerUid), h)
			where !held.HasValue || IsVirtualItem(held.Value)
			select h).FirstOrDefault();
	}

	private void ExecuteSwitchingToNewMagazineHand(EntityUid playerUid)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		string activeHand = sharedHandsSystem_0.GetActiveHand(Entity<HandsComponent>.op_Implicit(playerUid));
		EntityUid? activeItem = sharedHandsSystem_0.GetActiveItem(Entity<HandsComponent>.op_Implicit(playerUid));
		if (activeHand == null)
		{
			ResetReloadState();
			return;
		}
		EntityUid? val = activeItem;
		EntityUid? val2 = nullable_1;
		if (val.HasValue != val2.HasValue || (val.HasValue && !(val.GetValueOrDefault() == val2.GetValueOrDefault())))
		{
			string text = foundMagazineInfo_0.vHcTDa2Vk7();
			if (text != null && activeHand != text)
			{
				TryRequestHandSwitch(text);
			}
			else if (text == null && nullable_1.HasValue)
			{
				ResetReloadState();
			}
			else if (text != null && activeHand == text)
			{
				val2 = activeItem;
				val = nullable_1;
				if (val2.HasValue != val.HasValue || (val2.HasValue && val2.GetValueOrDefault() != val.GetValueOrDefault()))
				{
					ResetReloadState();
				}
			}
		}
		else
		{
			SetReloadState(9);
			RecordActionAttempt();
		}
	}

	private void ExecuteRequestingOpenContainerSlot()
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		if (string.IsNullOrEmpty(string_2) || !foundMagazineInfo_0.QaWTLIGNF5().HasValue)
		{
			ResetReloadState();
			return;
		}
		ientityManager_0.RaisePredictiveEvent<OpenSlotStorageNetworkMessage>(new OpenSlotStorageNetworkMessage(string_2));
		RecordActionAttempt();
		timeSpan_6 = igameTiming_0.CurTime;
		SetReloadState(5);
	}

	private void ExecuteSwitchingToFreeHandForContainerTake(EntityUid playerUid, EntityUid gunUid)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		string activeHand = sharedHandsSystem_0.GetActiveHand(Entity<HandsComponent>.op_Implicit(playerUid));
		EntityUid? activeItem = sharedHandsSystem_0.GetActiveItem(Entity<HandsComponent>.op_Implicit(playerUid));
		if (activeHand != null)
		{
			if (activeItem.HasValue && !IsVirtualItem(activeItem.Value))
			{
				EntityUid? val = activeItem;
				if (val.HasValue && val.GetValueOrDefault() == gunUid)
				{
					string text = FindOtherFreeHandName(playerUid);
					if (text != null)
					{
						TryRequestHandSwitch(text);
					}
					else
					{
						ResetReloadState();
					}
				}
				else
				{
					ResetReloadState();
				}
			}
			else
			{
				SetReloadState(6);
				RecordActionAttempt();
			}
		}
		else
		{
			ResetReloadState();
		}
	}

	private string FindOtherFreeHandName(EntityUid playerUid)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		return FindOtherFreeHandName(playerUid, sharedHandsSystem_0.GetActiveHand(Entity<HandsComponent>.op_Implicit(playerUid)));
	}

	private void ExecuteTakingMagazineFromOpenedContainer(EntityUid playerUid)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		string activeHand = sharedHandsSystem_0.GetActiveHand(Entity<HandsComponent>.op_Implicit(playerUid));
		EntityUid? activeItem = sharedHandsSystem_0.GetActiveItem(Entity<HandsComponent>.op_Implicit(playerUid));
		if (activeHand != null)
		{
			EntityUid? val = activeItem;
			EntityUid? val2 = nullable_1;
			if (val.HasValue == val2.HasValue && (!val.HasValue || val.GetValueOrDefault() == val2.GetValueOrDefault()))
			{
				SetReloadState(9);
				RecordActionAttempt();
			}
			else if (nullable_1.HasValue && ientityManager_0.EntityExists(nullable_1.Value) && foundMagazineInfo_0.QaWTLIGNF5().HasValue && ientityManager_0.EntityExists(foundMagazineInfo_0.QaWTLIGNF5().Value))
			{
				NetEntity netEntity = ientityManager_0.GetNetEntity(nullable_1.Value, (MetaDataComponent)null);
				NetEntity netEntity2 = ientityManager_0.GetNetEntity(foundMagazineInfo_0.QaWTLIGNF5().Value, (MetaDataComponent)null);
				if (netEntity == NetEntity.Invalid || netEntity2 == NetEntity.Invalid)
				{
					ResetReloadState();
				}
				else if (activeItem.HasValue && !IsVirtualItem(activeItem.Value))
				{
					val2 = activeItem;
					val = nullable_1;
					if (val2.HasValue != val.HasValue || (val2.HasValue && val2.GetValueOrDefault() != val.GetValueOrDefault()))
					{
						ResetReloadState();
					}
				}
				else
				{
					ientityManager_0.RaisePredictiveEvent<StorageInteractWithItemEvent>(new StorageInteractWithItemEvent(netEntity, netEntity2));
					RecordActionAttempt();
					timeSpan_6 = igameTiming_0.CurTime;
				}
			}
			else
			{
				ResetReloadState();
			}
		}
		else
		{
			ResetReloadState();
		}
	}

	private void ExecutePreparingToTakeFromPocketSlot(EntityUid playerUid, EntityUid gunUid)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		string activeHand = sharedHandsSystem_0.GetActiveHand(Entity<HandsComponent>.op_Implicit(playerUid));
		EntityUid? activeItem = sharedHandsSystem_0.GetActiveItem(Entity<HandsComponent>.op_Implicit(playerUid));
		if (activeHand == null)
		{
			ResetReloadState();
			return;
		}
		if (!activeItem.HasValue || IsVirtualItem(activeItem.Value))
		{
			SetReloadState(8);
			RecordActionAttempt();
			return;
		}
		EntityUid? val = activeItem;
		if (val.HasValue && val.GetValueOrDefault() == gunUid)
		{
			string text = FindOtherFreeHandName(playerUid);
			if (text == null)
			{
				ResetReloadState();
			}
			else
			{
				TryRequestHandSwitch(text);
			}
		}
		else
		{
			ResetReloadState();
		}
	}

	private void ExecuteTakingDirectlyFromPocketSlot(EntityUid playerUid)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		string activeHand = sharedHandsSystem_0.GetActiveHand(Entity<HandsComponent>.op_Implicit(playerUid));
		EntityUid? activeItem = sharedHandsSystem_0.GetActiveItem(Entity<HandsComponent>.op_Implicit(playerUid));
		if (activeHand == null)
		{
			ResetReloadState();
			return;
		}
		EntityUid? val = activeItem;
		EntityUid? val2 = nullable_1;
		if (val.HasValue == val2.HasValue && (!val.HasValue || val.GetValueOrDefault() == val2.GetValueOrDefault()))
		{
			SetReloadState(9);
			RecordActionAttempt();
		}
		else if (string.IsNullOrEmpty(foundMagazineInfo_0.gbYTEWX2TD()) || !nullable_1.HasValue)
		{
			ResetReloadState();
		}
		else if (activeItem.HasValue && !IsVirtualItem(activeItem.Value))
		{
			ResetReloadState();
		}
		else
		{
			ientityManager_0.RaisePredictiveEvent<UseSlotNetworkMessage>(new UseSlotNetworkMessage(foundMagazineInfo_0.gbYTEWX2TD()));
			RecordActionAttempt();
			timeSpan_6 = igameTiming_0.CurTime;
		}
	}

	private void ExecuteNewMagazineInHand(EntityUid playerUid, EntityUid gunUid)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		string activeHand = sharedHandsSystem_0.GetActiveHand(Entity<HandsComponent>.op_Implicit(playerUid));
		EntityUid? activeItem = sharedHandsSystem_0.GetActiveItem(Entity<HandsComponent>.op_Implicit(playerUid));
		if (activeHand != null && activeItem.HasValue)
		{
			EntityUid? val = activeItem;
			EntityUid? val2 = nullable_1;
			if (val.HasValue == val2.HasValue && (!val.HasValue || !(val.GetValueOrDefault() != val2.GetValueOrDefault())))
			{
				RecordActionAttempt();
				BaseContainer val3 = default(BaseContainer);
				if (nullable_2.HasValue && ientityManager_0.EntityExists(nullable_2.Value) && sharedContainerSystem_0.TryGetContainer(gunUid, "gun_magazine", ref val3, (ContainerManagerComponent)null) && val3.ContainedEntities.Contains(nullable_2.Value))
				{
					SetReloadState(10);
					return;
				}
				nullable_2 = null;
				SetReloadState(12);
				return;
			}
		}
		ResetReloadState();
	}

	private Verb TryFindEjectVerb(EntityUid gunUid, EntityUid playerUid, EntityUid oldMagazineUid)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		SortedSet<Verb> localVerbs = ((SharedVerbSystem)verbSystem_0).GetLocalVerbs(gunUid, playerUid, typeof(AlternativeVerb), false);
		NetEntity aixNxkxlUM = ientityManager_0.GetNetEntity(oldMagazineUid, (MetaDataComponent)null);
		Verb result;
		if ((result = localVerbs.FirstOrDefault(delegate(Verb v)
		{
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			if (!(v.Text == "Magazine") || !(v.Category?.Text == Loc.GetString("verb-categories-eject")) || v.Disabled)
			{
				return false;
			}
			NetEntity? iconEntity = v.IconEntity;
			NetEntity val = aixNxkxlUM;
			return iconEntity.HasValue && iconEntity.GetValueOrDefault() == val;
		})) == null)
		{
			result = localVerbs.FirstOrDefault((Verb v) => v.Text == "Magazine" && v.Category?.Text == Loc.GetString("verb-categories-eject") && !v.Disabled);
		}
		return result;
	}

	private Verb TryFindInsertVerb(EntityUid gunUid, EntityUid playerUid, EntityUid newMagazineUid)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		SortedSet<Verb> localVerbs = ((SharedVerbSystem)verbSystem_0).GetLocalVerbs(gunUid, playerUid, typeof(InteractionVerb), false);
		NetEntity AhdN1oQm9O = ientityManager_0.GetNetEntity(newMagazineUid, (MetaDataComponent)null);
		Verb result;
		if ((result = localVerbs.FirstOrDefault(delegate(Verb v)
		{
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			if (!(v.Text == "Magazine") || !(v.Category?.Text == Loc.GetString("verb-categories-insert")) || v.Disabled)
			{
				return false;
			}
			NetEntity? iconEntity = v.IconEntity;
			NetEntity val = AhdN1oQm9O;
			return iconEntity.HasValue && iconEntity.GetValueOrDefault() == val;
		})) == null)
		{
			result = localVerbs.FirstOrDefault((Verb v) => v.Text == "Magazine" && v.Category?.Text == Loc.GetString("verb-categories-insert") && !v.Disabled);
		}
		return result;
	}

	private void ExecuteEjectingOldMagazine(EntityUid playerUid, EntityUid gunUid)
	{
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		BaseContainer val = default(BaseContainer);
		if (nullable_2.HasValue && ientityManager_0.EntityExists(nullable_2.Value) && sharedContainerSystem_0.TryGetContainer(gunUid, "gun_magazine", ref val, (ContainerManagerComponent)null) && val.ContainedEntities.Contains(nullable_2.Value))
		{
			Verb val2 = TryFindEjectVerb(gunUid, playerUid, nullable_2.Value);
			if (val2 == null)
			{
				nullable_2 = null;
				SetReloadState(12);
				RecordActionAttempt();
			}
			else
			{
				ientityManager_0.RaisePredictiveEvent<ExecuteVerbEvent>(new ExecuteVerbEvent(ientityManager_0.GetNetEntity(gunUid, (MetaDataComponent)null), val2));
				RecordActionAttempt();
				SetReloadState(11);
			}
		}
		else
		{
			nullable_2 = null;
			SetReloadState(12);
			RecordActionAttempt();
		}
	}

	private void ExecuteWaitingForEject(EntityUid gunUid)
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		BaseContainer val = default(BaseContainer);
		if (!nullable_2.HasValue || (sharedContainerSystem_0.TryGetContainer(gunUid, "gun_magazine", ref val, (ContainerManagerComponent)null) && !val.ContainedEntities.Contains(nullable_2.Value)))
		{
			nullable_2 = null;
			SetReloadState(12);
		}
	}

	private void ExecuteReadyToInsertNewMagazine(EntityUid playerUid, EntityUid gunUid)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		string activeHand = sharedHandsSystem_0.GetActiveHand(Entity<HandsComponent>.op_Implicit(playerUid));
		EntityUid? activeItem = sharedHandsSystem_0.GetActiveItem(Entity<HandsComponent>.op_Implicit(playerUid));
		if (activeHand != null)
		{
			EntityUid? val = activeItem;
			EntityUid? val2 = nullable_1;
			if (val.HasValue == val2.HasValue && (!val.HasValue || !(val.GetValueOrDefault() != val2.GetValueOrDefault())) && nullable_1.HasValue)
			{
				BaseContainer val3 = default(BaseContainer);
				if (sharedContainerSystem_0.TryGetContainer(gunUid, "gun_magazine", ref val3, (ContainerManagerComponent)null) && val3.ContainedEntities.Any())
				{
					ResetReloadState();
					return;
				}
				Verb val4 = TryFindInsertVerb(gunUid, playerUid, nullable_1.Value);
				if (val4 != null)
				{
					ientityManager_0.RaisePredictiveEvent<ExecuteVerbEvent>(new ExecuteVerbEvent(ientityManager_0.GetNetEntity(gunUid, (MetaDataComponent)null), val4));
					RecordActionAttempt();
					SetReloadState(13);
				}
				else
				{
					ResetReloadState();
				}
				return;
			}
		}
		ResetReloadState();
	}

	private void ExecuteWaitingForInsertConfirm(EntityUid playerUid, EntityUid gunUid)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		BaseContainer val = default(BaseContainer);
		if (sharedContainerSystem_0.TryGetContainer(gunUid, "gun_magazine", ref val, (ContainerManagerComponent)null) && nullable_1.HasValue && val.ContainedEntities.Contains(nullable_1.Value))
		{
			timeSpan_3 = TimeSpan.Zero;
			string activeHand = sharedHandsSystem_0.GetActiveHand(Entity<HandsComponent>.op_Implicit(playerUid));
			if (string.IsNullOrEmpty(string_1) || activeHand == null || !(activeHand != string_1))
			{
				SetReloadState(15);
			}
			else
			{
				SetReloadState(14);
			}
		}
	}

	private void ExecutePostReloadRack(EntityUid playerUid, EntityUid gunUid, int nextState)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		BaseContainer val = default(BaseContainer);
		if (sharedContainerSystem_0.TryGetContainer(gunUid, "gun_magazine", ref val, (ContainerManagerComponent)null) && val.ContainedEntities.Any())
		{
			EntityUid val2 = val.ContainedEntities.First();
			GetAmmoCountEvent val3 = default(GetAmmoCountEvent);
			((IDirectedEventBus)ientityManager_0.EventBus).RaiseLocalEvent<GetAmmoCountEvent>(val2, ref val3, false);
			if (val3.Count > 0)
			{
				Verb val4 = ((SharedVerbSystem)verbSystem_0).GetLocalVerbs(gunUid, playerUid, typeof(Verb), false).FirstOrDefault((Verb v) => v.Text == Loc.GetString("gun-chamber-rack") && !v.Disabled);
				if (val4 != null)
				{
					ientityManager_0.RaisePredictiveEvent<ExecuteVerbEvent>(new ExecuteVerbEvent(ientityManager_0.GetNetEntity(gunUid, (MetaDataComponent)null), val4));
					timeSpan_1 = igameTiming_0.CurTime;
				}
				SetReloadState(nextState);
			}
			else
			{
				SetReloadState(nextState);
			}
		}
		else
		{
			SetReloadState(nextState);
		}
	}

	private void ExecuteSwitchingBackToGunHand(EntityUid playerUid)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(string_1))
		{
			SetReloadState(15);
			return;
		}
		string activeHand = sharedHandsSystem_0.GetActiveHand(Entity<HandsComponent>.op_Implicit(playerUid));
		if (activeHand == null)
		{
			SetReloadState(15);
		}
		else if (activeHand == string_1)
		{
			SetReloadState(15);
		}
		else
		{
			TryRequestHandSwitch(string_1);
		}
	}

	private bool TryFindMagazineForReload(EntityUid playerUid, EntityUid gunUid, out FoundMagazineInfo bestMagazine)
	{
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got I4
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Expected O, but got I4
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got I4
		bestMagazine = new FoundMagazineInfo();
		int num = -1;
		InventoryComponent val = null;
		HandsComponent val2 = default(HandsComponent);
		if (ientityManager_0.TryGetComponent<HandsComponent>(playerUid, ref val2) && ientityManager_0.TryGetComponent<InventoryComponent>(playerUid, ref val) && inventorySystem_0 != null)
		{
			foreach (string key in val2.Hands.Keys)
			{
				EntityUid? heldItem = sharedHandsSystem_0.GetHeldItem(Entity<HandsComponent>.op_Implicit(playerUid), key);
				if (heldItem.HasValue && IsMagazineCompatible(gunUid, heldItem.Value))
				{
					GetAmmoCountEvent val3 = default(GetAmmoCountEvent);
					((IDirectedEventBus)ientityManager_0.EventBus).RaiseLocalEvent<GetAmmoCountEvent>(heldItem.Value, ref val3, false);
					if (val3.Count > num)
					{
						num = val3.Count;
						bestMagazine = new FoundMagazineInfo(heldItem.Value, (Enum0)0, key);
					}
				}
			}
			string[] array = new string[4] { "belt", "pocket1", "pocket2", "back" };
			ContainerSlot val4 = default(ContainerSlot);
			SlotDefinition val5 = default(SlotDefinition);
			foreach (string text in array)
			{
				if (!inventorySystem_0.TryGetSlotContainer(playerUid, text, ref val4, ref val5, val, (ContainerManagerComponent)null) || ((BaseContainer)val4).Count == 0)
				{
					continue;
				}
				foreach (EntityUid containedEntity in ((BaseContainer)val4).ContainedEntities)
				{
					if (!ientityManager_0.EntityExists(containedEntity))
					{
						continue;
					}
					if (!IsMagazineCompatible(gunUid, containedEntity))
					{
						if (ientityManager_0.HasComponent<StorageComponent>(containedEntity) && TryFindSuitableMagazineInStorage(containedEntity, gunUid, out var foundMagazineUid, out var ammoCount) && ammoCount > num)
						{
							num = ammoCount;
							bestMagazine = new FoundMagazineInfo(foundMagazineUid, (Enum0)1, null, containedEntity, text);
						}
						continue;
					}
					GetAmmoCountEvent val6 = default(GetAmmoCountEvent);
					((IDirectedEventBus)ientityManager_0.EventBus).RaiseLocalEvent<GetAmmoCountEvent>(containedEntity, ref val6, false);
					if (val6.Count > num)
					{
						num = val6.Count;
						EntityUid magazineUid = containedEntity;
						string handName = null;
						string directSlotId = text;
						bestMagazine = new FoundMagazineInfo(magazineUid, (Enum0)2, handName, null, null, directSlotId);
					}
				}
			}
			return bestMagazine.pPjTRUogeZ();
		}
		return false;
	}

	private bool TryFindSuitableMagazineInStorage(EntityUid storageUid, EntityUid gunUid, out EntityUid foundMagazineUid, out int ammoCount)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		foundMagazineUid = default(EntityUid);
		ammoCount = -1;
		StorageComponent val = default(StorageComponent);
		if (ientityManager_0.TryGetComponent<StorageComponent>(storageUid, ref val))
		{
			EntityUid? val2 = null;
			int num = -1;
			foreach (EntityUid containedEntity in ((BaseContainer)val.Container).ContainedEntities)
			{
				if (IsMagazineCompatible(gunUid, containedEntity))
				{
					GetAmmoCountEvent val3 = default(GetAmmoCountEvent);
					((IDirectedEventBus)ientityManager_0.EventBus).RaiseLocalEvent<GetAmmoCountEvent>(containedEntity, ref val3, false);
					if (val3.Count > num)
					{
						num = val3.Count;
						val2 = containedEntity;
					}
				}
			}
			if (!val2.HasValue)
			{
				return false;
			}
			foundMagazineUid = val2.Value;
			ammoCount = num;
			return true;
		}
		return false;
	}

	private bool IsMagazineCompatible(EntityUid gunUid, EntityUid magazineUid)
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		if (!ientityManager_0.EntityExists(gunUid) || !ientityManager_0.EntityExists(magazineUid) || entityWhitelistSystem_0 == null)
		{
			return false;
		}
		ItemSlotsComponent val = default(ItemSlotsComponent);
		if (ientityManager_0.TryGetComponent<ItemSlotsComponent>(gunUid, ref val))
		{
			if (val.Slots.TryGetValue("gun_magazine", out var value))
			{
				bool flag = value.Whitelist == null || entityWhitelistSystem_0.IsValid(value.Whitelist, magazineUid);
				if (flag && value.Blacklist != null && entityWhitelistSystem_0.IsValid(value.Blacklist, magazineUid))
				{
					flag = false;
				}
				if (flag)
				{
					GetAmmoCountEvent val2 = default(GetAmmoCountEvent);
					((IDirectedEventBus)ientityManager_0.EventBus).RaiseLocalEvent<GetAmmoCountEvent>(magazineUid, ref val2, false);
					if (val2.Capacity <= 0 && val2.Count <= 0 && !ientityManager_0.HasComponent<BallisticAmmoProviderComponent>(magazineUid) && !ientityManager_0.HasComponent<MagazineAmmoProviderComponent>(magazineUid) && !ientityManager_0.HasComponent<BatteryAmmoProviderComponent>(magazineUid))
					{
						return false;
					}
				}
				return flag;
			}
			return false;
		}
		return false;
	}

	private bool IsVirtualItem(EntityUid entityUid)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		if (!ientityManager_0.EntityExists(entityUid))
		{
			return false;
		}
		MetaDataComponent val = default(MetaDataComponent);
		return ientityManager_0.TryGetComponent<MetaDataComponent>(entityUid, ref val) && val.EntityPrototype != null && val.EntityPrototype.ID.Contains("VirtualItem", StringComparison.OrdinalIgnoreCase);
	}

	private bool IsShotgunType(EntityUid gunUid)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		if (ientityManager_0.HasComponent<BallisticAmmoProviderComponent>(gunUid))
		{
			ItemSlotsComponent val = default(ItemSlotsComponent);
			if (!ientityManager_0.TryGetComponent<ItemSlotsComponent>(gunUid, ref val) || !val.Slots.ContainsKey("gun_magazine"))
			{
				return true;
			}
			return false;
		}
		return false;
	}

	private void HandleShotgunReload(EntityUid playerUid, EntityUid gunUid)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected I8, but got I4
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0528: Unknown result type (might be due to invalid IL or missing references)
		//IL_0529: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0482: Unknown result type (might be due to invalid IL or missing references)
		//IL_0487: Unknown result type (might be due to invalid IL or missing references)
		//IL_077f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0784: Unknown result type (might be due to invalid IL or missing references)
		//IL_0800: Unknown result type (might be due to invalid IL or missing references)
		//IL_0805: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Expected I8, but got I4
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Expected I8, but got I4
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0659: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_066b: Unknown result type (might be due to invalid IL or missing references)
		//IL_066c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0393: Unknown result type (might be due to invalid IL or missing references)
		//IL_039d: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		//IL_0402: Unknown result type (might be due to invalid IL or missing references)
		//IL_0403: Unknown result type (might be due to invalid IL or missing references)
		//IL_0411: Unknown result type (might be due to invalid IL or missing references)
		//IL_0412: Unknown result type (might be due to invalid IL or missing references)
		//IL_0439: Unknown result type (might be due to invalid IL or missing references)
		//IL_043e: Unknown result type (might be due to invalid IL or missing references)
		//IL_069a: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_055e: Unknown result type (might be due to invalid IL or missing references)
		//IL_055f: Unknown result type (might be due to invalid IL or missing references)
		//IL_087a: Unknown result type (might be due to invalid IL or missing references)
		//IL_087b: Unknown result type (might be due to invalid IL or missing references)
		//IL_087e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0593: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_06be: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08da: Unknown result type (might be due to invalid IL or missing references)
		//IL_0861: Unknown result type (might be due to invalid IL or missing references)
		//IL_0862: Unknown result type (might be due to invalid IL or missing references)
		//IL_0865: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b4: Expected O, but got Unknown
		//IL_0629: Unknown result type (might be due to invalid IL or missing references)
		//IL_062a: Unknown result type (might be due to invalid IL or missing references)
		//IL_060a: Unknown result type (might be due to invalid IL or missing references)
		//IL_04df: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0505: Expected O, but got Unknown
		//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		BallisticAmmoProviderComponent val = default(BallisticAmmoProviderComponent);
		if (!ientityManager_0.TryGetComponent<BallisticAmmoProviderComponent>(gunUid, ref val) || igameTiming_0.CurTime < timeSpan_5 + TimeSpan.FromMilliseconds(100L))
		{
			return;
		}
		timeSpan_5 = igameTiming_0.CurTime;
		GetAmmoCountEvent val2 = default(GetAmmoCountEvent);
		((IDirectedEventBus)ientityManager_0.EventBus).RaiseLocalEvent<GetAmmoCountEvent>(gunUid, ref val2, false);
		int count = val2.Count;
		int num = ((val2.Capacity <= 0) ? val.Capacity : val2.Capacity);
		EntityUid val4;
		EntityUid? val3;
		if (bool_0)
		{
			val3 = nullable_0;
			val4 = gunUid;
			if (val3.HasValue && val3.GetValueOrDefault() == val4)
			{
				if (igameTiming_0.CurTime < timeSpan_4 + TimeSpan.FromMilliseconds(200L))
				{
					return;
				}
				string text = null;
				HandsComponent val5 = default(HandsComponent);
				if (ientityManager_0.TryGetComponent<HandsComponent>(playerUid, ref val5))
				{
					foreach (string key in val5.Hands.Keys)
					{
						val3 = sharedHandsSystem_0.GetHeldItem(Entity<HandsComponent>.op_Implicit(playerUid), key);
						val4 = gunUid;
						if (val3.HasValue && val3.GetValueOrDefault() == val4)
						{
							text = key;
							break;
						}
					}
				}
				if (text != null)
				{
					if (!(sharedHandsSystem_0.GetActiveHand(Entity<HandsComponent>.op_Implicit(playerUid)) != text))
					{
						string text2 = null;
						HandsComponent val6 = default(HandsComponent);
						if (ientityManager_0.TryGetComponent<HandsComponent>(playerUid, ref val6))
						{
							foreach (string key2 in val6.Hands.Keys)
							{
								if (!(key2 == text))
								{
									EntityUid? heldItem = sharedHandsSystem_0.GetHeldItem(Entity<HandsComponent>.op_Implicit(playerUid), key2);
									if (!heldItem.HasValue || IsVirtualItem(heldItem.Value))
									{
										text2 = key2;
										break;
									}
								}
							}
						}
						if (text2 != null)
						{
							ientityManager_0.RaisePredictiveEvent<RequestHandInteractUsingEvent>(new RequestHandInteractUsingEvent(text2));
							timeSpan_4 = igameTiming_0.CurTime;
						}
						bool_0 = false;
						nullable_0 = null;
					}
					else
					{
						ientityManager_0.RaisePredictiveEvent<RequestSetHandEvent>(new RequestSetHandEvent(text));
						timeSpan_4 = igameTiming_0.CurTime;
					}
				}
				else
				{
					bool_0 = false;
					nullable_0 = null;
				}
				return;
			}
		}
		if (count >= num)
		{
			val3 = nullable_0;
			val4 = gunUid;
			if (val3.HasValue && val3.GetValueOrDefault() == val4)
			{
				bool_0 = true;
				timeSpan_4 = igameTiming_0.CurTime;
			}
			return;
		}
		val3 = nullable_0;
		val4 = gunUid;
		if ((!val3.HasValue || !(val3.GetValueOrDefault() == val4)) && count > 1)
		{
			return;
		}
		val3 = nullable_0;
		val4 = gunUid;
		if (!val3.HasValue || val3.GetValueOrDefault() != val4)
		{
			nullable_0 = gunUid;
			bool_0 = false;
		}
		HandsComponent val7 = default(HandsComponent);
		if (igameTiming_0.CurTime < timeSpan_4 + TimeSpan.FromMilliseconds(150L) || !ientityManager_0.TryGetComponent<HandsComponent>(playerUid, ref val7))
		{
			return;
		}
		EntityUid? val8 = FindCompatibleAmmoForShotgun(playerUid, gunUid, val);
		if (!val8.HasValue)
		{
			bool_0 = true;
			timeSpan_4 = igameTiming_0.CurTime;
			return;
		}
		val3 = sharedHandsSystem_0.GetActiveItem(Entity<HandsComponent>.op_Implicit(playerUid));
		EntityUid? val9 = val8;
		if (val3.HasValue != val9.HasValue || (val3.HasValue && !(val3.GetValueOrDefault() == val9.GetValueOrDefault())))
		{
			string text3 = null;
			foreach (string key3 in val7.Hands.Keys)
			{
				val9 = sharedHandsSystem_0.GetHeldItem(Entity<HandsComponent>.op_Implicit(playerUid), key3);
				val3 = val8;
				if (val9.HasValue == val3.HasValue && (!val9.HasValue || val9.GetValueOrDefault() == val3.GetValueOrDefault()))
				{
					text3 = key3;
					break;
				}
			}
			if (text3 == null)
			{
				string text4 = null;
				foreach (string key4 in val7.Hands.Keys)
				{
					EntityUid? heldItem2 = sharedHandsSystem_0.GetHeldItem(Entity<HandsComponent>.op_Implicit(playerUid), key4);
					if (!heldItem2.HasValue || IsVirtualItem(heldItem2.Value))
					{
						text4 = key4;
						break;
					}
				}
				if (text4 == null)
				{
					return;
				}
				if (!(sharedHandsSystem_0.GetActiveHand(Entity<HandsComponent>.op_Implicit(playerUid)) != text4))
				{
					InventoryComponent val10 = default(InventoryComponent);
					if (!ientityManager_0.TryGetComponent<InventoryComponent>(playerUid, ref val10))
					{
						return;
					}
					string[] array = new string[4] { "belt", "pocket1", "pocket2", "back" };
					int num2 = 0;
					string text5;
					ContainerSlot val11 = default(ContainerSlot);
					SlotDefinition val12 = default(SlotDefinition);
					StorageComponent val13 = default(StorageComponent);
					while (true)
					{
						if (num2 >= array.Length)
						{
							return;
						}
						text5 = array[num2];
						if (inventorySystem_0.TryGetSlotContainer(playerUid, text5, ref val11, ref val12, val10, (ContainerManagerComponent)null))
						{
							if (((BaseContainer)val11).ContainedEntities.Contains(val8.Value))
							{
								break;
							}
							foreach (EntityUid containedEntity in ((BaseContainer)val11).ContainedEntities)
							{
								if (ientityManager_0.TryGetComponent<StorageComponent>(containedEntity, ref val13) && ((BaseContainer)val13.Container).ContainedEntities.Contains(val8.Value))
								{
									ientityManager_0.RaisePredictiveEvent<OpenSlotStorageNetworkMessage>(new OpenSlotStorageNetworkMessage(text5));
									NetEntity netEntity = ientityManager_0.GetNetEntity(val8.Value, (MetaDataComponent)null);
									NetEntity netEntity2 = ientityManager_0.GetNetEntity(containedEntity, (MetaDataComponent)null);
									ientityManager_0.RaisePredictiveEvent<StorageInteractWithItemEvent>(new StorageInteractWithItemEvent(netEntity, netEntity2));
									timeSpan_4 = igameTiming_0.CurTime;
									return;
								}
							}
						}
						num2++;
					}
					ientityManager_0.RaisePredictiveEvent<UseSlotNetworkMessage>(new UseSlotNetworkMessage(text5));
					timeSpan_4 = igameTiming_0.CurTime;
				}
				else
				{
					ientityManager_0.RaisePredictiveEvent<RequestSetHandEvent>(new RequestSetHandEvent(text4));
					timeSpan_4 = igameTiming_0.CurTime;
				}
			}
			else if (sharedHandsSystem_0.GetActiveHand(Entity<HandsComponent>.op_Implicit(playerUid)) != text3)
			{
				ientityManager_0.RaisePredictiveEvent<RequestSetHandEvent>(new RequestSetHandEvent(text3));
				timeSpan_4 = igameTiming_0.CurTime;
			}
			else
			{
				InsertAmmoIntoShotgun(playerUid, gunUid, val8.Value);
				timeSpan_4 = igameTiming_0.CurTime;
			}
		}
		else
		{
			InsertAmmoIntoShotgun(playerUid, gunUid, val8.Value);
			timeSpan_4 = igameTiming_0.CurTime;
		}
	}

	private EntityUid? FindCompatibleAmmoForShotgun(EntityUid playerUid, EntityUid gunUid, BallisticAmmoProviderComponent ballisticComp)
	{
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_043f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0429: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0391: Unknown result type (might be due to invalid IL or missing references)
		//IL_0365: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass84_0 _003C_003Ec__DisplayClass84_0_ = default(_003C_003Ec__DisplayClass84_0);
		_003C_003Ec__DisplayClass84_0_.NqtNV3CtwD = this;
		_003C_003Ec__DisplayClass84_0_.gdUNaUWE3m = ballisticComp;
		HandsComponent val = default(HandsComponent);
		if (ientityManager_0.TryGetComponent<HandsComponent>(playerUid, ref val))
		{
			MetaDataComponent val2 = default(MetaDataComponent);
			foreach (string key in val.Hands.Keys)
			{
				try
				{
					EntityUid? heldItem = sharedHandsSystem_0.GetHeldItem(Entity<HandsComponent>.op_Implicit(playerUid), key);
					if (heldItem.HasValue)
					{
						bool flag = method_0(heldItem.Value, ref _003C_003Ec__DisplayClass84_0_);
						if (ientityManager_0.TryGetComponent<MetaDataComponent>(heldItem.Value, ref val2))
						{
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(28, 3);
							defaultInterpolatedStringHandler.AppendLiteral("[FindAmmo] Hand '");
							defaultInterpolatedStringHandler.AppendFormatted(key);
							defaultInterpolatedStringHandler.AppendLiteral("': ");
							EntityPrototype entityPrototype = val2.EntityPrototype;
							defaultInterpolatedStringHandler.AppendFormatted((entityPrototype != null) ? entityPrototype.ID : null);
							defaultInterpolatedStringHandler.AppendLiteral(" compat=");
							defaultInterpolatedStringHandler.AppendFormatted(flag);
							Logger.Info(defaultInterpolatedStringHandler.ToStringAndClear());
						}
						if (flag)
						{
							return heldItem.Value;
						}
					}
				}
				catch (Exception ex)
				{
					Logger.Warn("[FindAmmo] Hand '" + key + "' exception: " + ex.Message);
				}
			}
		}
		InventoryComponent val3 = default(InventoryComponent);
		if (!ientityManager_0.TryGetComponent<InventoryComponent>(playerUid, ref val3))
		{
			Logger.Warn("[FindAmmo] No InventoryComponent");
			return null;
		}
		string[] obj = new string[6] { "belt", "pocket1", "pocket2", "back", "outerClothing", "innerClothing" };
		Logger.Info($"[FindAmmo] Searching inventory, _inventorySystem={inventorySystem_0 != null}");
		string[] array = obj;
		ContainerSlot val4 = default(ContainerSlot);
		SlotDefinition val5 = default(SlotDefinition);
		MetaDataComponent val6 = default(MetaDataComponent);
		StorageComponent val7 = default(StorageComponent);
		MetaDataComponent val8 = default(MetaDataComponent);
		foreach (string text in array)
		{
			try
			{
				if (!inventorySystem_0.TryGetSlotContainer(playerUid, text, ref val4, ref val5, val3, (ContainerManagerComponent)null))
				{
					continue;
				}
				foreach (EntityUid containedEntity in ((BaseContainer)val4).ContainedEntities)
				{
					if (ientityManager_0.TryGetComponent<MetaDataComponent>(containedEntity, ref val6))
					{
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler2 = new DefaultInterpolatedStringHandler(33, 3);
						defaultInterpolatedStringHandler2.AppendLiteral("[FindAmmo] Slot '");
						defaultInterpolatedStringHandler2.AppendFormatted(text);
						defaultInterpolatedStringHandler2.AppendLiteral("' item: ");
						EntityPrototype entityPrototype2 = val6.EntityPrototype;
						defaultInterpolatedStringHandler2.AppendFormatted((entityPrototype2 == null) ? null : entityPrototype2.ID);
						defaultInterpolatedStringHandler2.AppendLiteral(" compat=");
						defaultInterpolatedStringHandler2.AppendFormatted(method_0(containedEntity, ref _003C_003Ec__DisplayClass84_0_));
						Logger.Info(defaultInterpolatedStringHandler2.ToStringAndClear());
					}
					if (method_0(containedEntity, ref _003C_003Ec__DisplayClass84_0_))
					{
						return containedEntity;
					}
					if (!ientityManager_0.TryGetComponent<StorageComponent>(containedEntity, ref val7))
					{
						continue;
					}
					foreach (EntityUid containedEntity2 in ((BaseContainer)val7.Container).ContainedEntities)
					{
						if (ientityManager_0.TryGetComponent<MetaDataComponent>(containedEntity2, ref val8))
						{
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler3 = new DefaultInterpolatedStringHandler(40, 3);
							defaultInterpolatedStringHandler3.AppendLiteral("[FindAmmo] Storage in '");
							defaultInterpolatedStringHandler3.AppendFormatted(text);
							defaultInterpolatedStringHandler3.AppendLiteral("' inner: ");
							EntityPrototype entityPrototype3 = val8.EntityPrototype;
							defaultInterpolatedStringHandler3.AppendFormatted((entityPrototype3 == null) ? null : entityPrototype3.ID);
							defaultInterpolatedStringHandler3.AppendLiteral(" compat=");
							defaultInterpolatedStringHandler3.AppendFormatted(method_0(containedEntity2, ref _003C_003Ec__DisplayClass84_0_));
							Logger.Info(defaultInterpolatedStringHandler3.ToStringAndClear());
						}
						if (method_0(containedEntity2, ref _003C_003Ec__DisplayClass84_0_))
						{
							return containedEntity2;
						}
					}
				}
			}
			catch (Exception ex2)
			{
				Logger.Warn("[FindAmmo] Slot '" + text + "' exception: " + ex2.Message);
			}
		}
		return null;
	}

	private EntityUid? FindAmmoInStorage(EntityUid storageUid, string requiredProto)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		BaseContainer val = default(BaseContainer);
		if (sharedContainerSystem_0.TryGetContainer(storageUid, "storagebase", ref val, (ContainerManagerComponent)null))
		{
			MetaDataComponent val2 = default(MetaDataComponent);
			foreach (EntityUid containedEntity in val.ContainedEntities)
			{
				if (ientityManager_0.TryGetComponent<MetaDataComponent>(containedEntity, ref val2))
				{
					EntityPrototype entityPrototype = val2.EntityPrototype;
					if (((entityPrototype != null) ? entityPrototype.ID : null) == requiredProto)
					{
						return containedEntity;
					}
				}
			}
			return null;
		}
		return null;
	}

	private void InsertAmmoIntoShotgun(EntityUid playerUid, EntityUid gunUid, EntityUid ammoUid)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Expected O, but got Unknown
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		EntityUid? activeItem = sharedHandsSystem_0.GetActiveItem(Entity<HandsComponent>.op_Implicit(playerUid));
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(40, 3);
		defaultInterpolatedStringHandler.AppendLiteral("[InsertAmmo] activeItem=");
		defaultInterpolatedStringHandler.AppendFormatted(activeItem);
		defaultInterpolatedStringHandler.AppendLiteral(" ammoUid=");
		defaultInterpolatedStringHandler.AppendFormatted<EntityUid>(ammoUid);
		defaultInterpolatedStringHandler.AppendLiteral(" match=");
		EntityUid? val = activeItem;
		EntityUid val2 = ammoUid;
		defaultInterpolatedStringHandler.AppendFormatted(val.HasValue && val.GetValueOrDefault() == val2);
		Logger.Info(defaultInterpolatedStringHandler.ToStringAndClear());
		string text = null;
		HandsComponent val3 = default(HandsComponent);
		if (ientityManager_0.TryGetComponent<HandsComponent>(playerUid, ref val3))
		{
			foreach (string key in val3.Hands.Keys)
			{
				val = sharedHandsSystem_0.GetHeldItem(Entity<HandsComponent>.op_Implicit(playerUid), key);
				val2 = gunUid;
				if (val.HasValue && val.GetValueOrDefault() == val2)
				{
					text = key;
					break;
				}
			}
		}
		Logger.Info("[InsertAmmo] gunHandName=" + text);
		if (text != null)
		{
			val = activeItem;
			val2 = ammoUid;
			if (val.HasValue && val.GetValueOrDefault() == val2)
			{
				Logger.Info("[InsertAmmo] Using RequestHandInteractUsingEvent on gun hand '" + text + "'");
				ientityManager_0.RaisePredictiveEvent<RequestHandInteractUsingEvent>(new RequestHandInteractUsingEvent(text));
				return;
			}
		}
		SortedSet<Verb> localVerbs = ((SharedVerbSystem)verbSystem_0).GetLocalVerbs(gunUid, playerUid, typeof(InteractionVerb), false);
		Logger.Info($"[InsertAmmo] InteractionVerbs on gun: {localVerbs.Count}");
		foreach (Verb item in localVerbs)
		{
			Logger.Info($"[InsertAmmo]   verb: '{item.Text}' disabled={item.Disabled}");
		}
		Verb val4 = localVerbs.FirstOrDefault((Verb v) => !v.Disabled);
		if (val4 == null)
		{
			Logger.Warn("[InsertAmmo] No verbs found!");
			return;
		}
		Logger.Info("[InsertAmmo] Executing verb '" + val4.Text + "'");
		ientityManager_0.RaisePredictiveEvent<ExecuteVerbEvent>(new ExecuteVerbEvent(ientityManager_0.GetNetEntity(gunUid, (MetaDataComponent)null), val4));
	}

	[CompilerGenerated]
	private bool method_0(EntityUid entity, ref _003C_003Ec__DisplayClass84_0 _003C_003Ec__DisplayClass84_0_0)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (!ientityManager_0.EntityExists(entity))
			{
				return false;
			}
			if (_003C_003Ec__DisplayClass84_0_0.gdUNaUWE3m.Whitelist != null && entityWhitelistSystem_0 != null)
			{
				return entityWhitelistSystem_0.IsValid(_003C_003Ec__DisplayClass84_0_0.gdUNaUWE3m.Whitelist, entity);
			}
			EntProtoId? proto = _003C_003Ec__DisplayClass84_0_0.gdUNaUWE3m.Proto;
			MetaDataComponent val = default(MetaDataComponent);
			if (string.IsNullOrEmpty((!proto.HasValue) ? null : EntProtoId.op_Implicit(proto.GetValueOrDefault())) || !ientityManager_0.TryGetComponent<MetaDataComponent>(entity, ref val))
			{
				return false;
			}
			EntityPrototype entityPrototype = val.EntityPrototype;
			proto = EntProtoId.op_Implicit((entityPrototype != null) ? entityPrototype.ID : null);
			EntProtoId? proto2 = _003C_003Ec__DisplayClass84_0_0.gdUNaUWE3m.Proto;
			return proto.HasValue == proto2.HasValue && (!proto.HasValue || proto.GetValueOrDefault() == proto2.GetValueOrDefault());
		}
		catch (Exception ex)
		{
			Logger.Warn($"[FindAmmo] IsCompatible exception for {entity}: {ex.Message}");
			return false;
		}
	}
}
