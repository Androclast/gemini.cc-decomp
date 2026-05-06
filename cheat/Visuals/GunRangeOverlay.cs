using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using Content.Shared.CombatMode;
using Robust.Client.Graphics;
using Robust.Client.Player;
using Robust.Client.ResourceManagement;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using Robust.Shared.Player;
using CerberusConfig;

[CompilerGenerated]
public sealed class GunRangeOverlay : Overlay
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IEyeManager ieyeManager_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IResourceCache iresourceCache_0;

	[Dependency]
	private readonly IEntitySystemManager ientitySystemManager_0;

	private FriendsList gclass6_0;

	private PriorityList gclass8_0;

	private ContrabandCheckSystem gclass25_0;

	private EntityLookupSystem entityLookupSystem_0;

	private AntagDetectorSystem gclass23_0;

	private AutoSlipMovement gclass21_0;

	private readonly List<ICommonSession> list_0 = new List<ICommonSession>();

	private Font font_0;

	private Font font_1;

	private string string_0 = "";

	private int int_0;

	private string string_1 = "";

	private int int_1;

	private int int_2;

	private char char_0;

	private byte byte_2;

	private double double_0;

	public override OverlaySpace Space => (OverlaySpace)2;

	private char Char_0
	{
		get
		{
			return char_0;
		}
		set
		{
			char_0 = value;
		}
	}

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

	private double Double_0
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public GunRangeOverlay()
	{
		IoCManager.InjectDependencies<GunRangeOverlay>(this);
		((Overlay)this).ZIndex = 200;
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected O, but got Unknown
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Expected O, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0770: Unknown result type (might be due to invalid IL or missing references)
		//IL_0775: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_07aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_061c: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f0: Invalid comparison between Unknown and I4
		//IL_08f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0909: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fb: Invalid comparison between Unknown and I4
		//IL_0602: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_0694: Unknown result type (might be due to invalid IL or missing references)
		//IL_0915: Unknown result type (might be due to invalid IL or missing references)
		//IL_085d: Unknown result type (might be due to invalid IL or missing references)
		//IL_065d: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0709: Unknown result type (might be due to invalid IL or missing references)
		//IL_0681: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_0460: Unknown result type (might be due to invalid IL or missing references)
		//IL_0484: Unknown result type (might be due to invalid IL or missing references)
		//IL_0883: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_081c: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0516: Unknown result type (might be due to invalid IL or missing references)
		//IL_0532: Unknown result type (might be due to invalid IL or missing references)
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_03eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0556: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_056c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0371: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0401: Unknown result type (might be due to invalid IL or missing references)
		//IL_0592: Unknown result type (might be due to invalid IL or missing references)
		//IL_074c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0794: Unknown result type (might be due to invalid IL or missing references)
		//IL_042f: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.Esp.Enabled)
		{
			return;
		}
		int_2++;
		if (int_2 < 1)
		{
			return;
		}
		int_2 = 0;
		UpdateValidSessions();
		if (font_0 == null || string_0 != CerberusConfig.Esp.MainFontPath || int_0 != CerberusConfig.Esp.MainFontSize)
		{
			font_0 = (Font)new VectorFont(iresourceCache_0.GetResource<FontResource>(CerberusConfig.Esp.MainFontPath, true), CerberusConfig.Esp.MainFontSize);
			string_0 = CerberusConfig.Esp.MainFontPath;
			int_0 = CerberusConfig.Esp.MainFontSize;
		}
		if (font_1 == null || string_1 != CerberusConfig.Esp.OtherFontPath || int_1 != CerberusConfig.Esp.OtherFontSize)
		{
			font_1 = (Font)new VectorFont(iresourceCache_0.GetResource<FontResource>(CerberusConfig.Esp.OtherFontPath, true), CerberusConfig.Esp.OtherFontSize);
			string_1 = CerberusConfig.Esp.OtherFontPath;
			int_1 = CerberusConfig.Esp.OtherFontSize;
		}
		Font val = font_0;
		Font val2 = font_1;
		if (gclass6_0 == null)
		{
			gclass6_0 = ientitySystemManager_0.GetEntitySystem<FriendsList>();
		}
		if (gclass8_0 == null)
		{
			gclass8_0 = ientitySystemManager_0.GetEntitySystem<PriorityList>();
		}
		if (gclass25_0 == null)
		{
			gclass25_0 = ientitySystemManager_0.GetEntitySystem<ContrabandCheckSystem>();
		}
		if (entityLookupSystem_0 == null)
		{
			entityLookupSystem_0 = ientitySystemManager_0.GetEntitySystem<EntityLookupSystem>();
		}
		if (gclass23_0 == null)
		{
			gclass23_0 = ientitySystemManager_0.GetEntitySystem<AntagDetectorSystem>();
		}
		if (gclass21_0 == null)
		{
			gclass21_0 = ientitySystemManager_0.GetEntitySystem<AutoSlipMovement>();
		}
		Box2 worldAABB = args.WorldAABB;
		Angle val3 = default(Angle);
		((Angle)(ref val3))._002Ector(Angle.op_Implicit(-ieyeManager_0.CurrentEye.Rotation));
		MapId currentMap = ieyeManager_0.CurrentMap;
		ICommonSession localSession = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
		string text = ((localSession != null) ? localSession.Name : null);
		Vector2 vector = new Vector2(0f, CerberusConfig.Esp.FontInterval);
		CombatModeComponent val4 = default(CombatModeComponent);
		foreach (ICommonSession item in list_0)
		{
			EntityUid? attachedEntity = item.AttachedEntity;
			if (!attachedEntity.HasValue)
			{
				continue;
			}
			EntityUid valueOrDefault = attachedEntity.GetValueOrDefault();
			if (!ientityManager_0.EntityExists(valueOrDefault) || item.Name == text || ientityManager_0.GetComponent<TransformComponent>(valueOrDefault).MapID != currentMap)
			{
				continue;
			}
			MetaDataComponent component = ientityManager_0.GetComponent<MetaDataComponent>(valueOrDefault);
			Box2 worldAABB2 = entityLookupSystem_0.GetWorldAABB(valueOrDefault, (TransformComponent)null);
			if (!((Box2)(ref worldAABB2)).Intersects(ref worldAABB))
			{
				continue;
			}
			Vector2 center = ((Box2)(ref worldAABB2)).Center;
			Vector2 vector2 = worldAABB2.TopRight - center;
			Vector2 vector3 = ieyeManager_0.WorldToScreen(center + ((Angle)(ref val3)).RotateVec(ref vector2)) + new Vector2(1f, 7f);
			if (CerberusConfig.Esp.ShowName)
			{
				((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(val, vector3, component.EntityName, (Color)(((int)item.Status != 4) ? new Color(ref CerberusConfig.Esp.NameColor) : Color.White));
				vector3 += vector;
			}
			if (CerberusConfig.Esp.ShowCKey)
			{
				((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(val, vector3, item.Name, (Color)(((int)item.Status != 4) ? new Color(ref CerberusConfig.Esp.CKeyColor) : Color.White));
				vector3 += vector;
			}
			if (CerberusConfig.Esp.ShowAntag)
			{
				if (gclass23_0.IsAgent(valueOrDefault) && CerberusConfig.Esp.ShowAntag)
				{
					((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(val, vector3, LocalizationStringProvider.GetString("ESP_Agent"), new Color(ref CerberusConfig.Esp.AntagColor));
					vector3 += vector;
				}
				if (gclass23_0.IsHeretic(valueOrDefault))
				{
					((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(val, vector3, LocalizationStringProvider.GetString("ESP_Heretic"), new Color(ref CerberusConfig.Esp.AntagColor));
					vector3 += vector;
				}
				if (gclass23_0.IsVampire(valueOrDefault))
				{
					((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(val, vector3, LocalizationStringProvider.GetString("ESP_Vampire"), new Color(ref CerberusConfig.Esp.AntagColor));
					vector3 += vector;
				}
				if (gclass23_0.IsFleshCultist(valueOrDefault))
				{
					((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(val, vector3, LocalizationStringProvider.GetString("ESP_FleshCult"), new Color(ref CerberusConfig.Esp.AntagColor));
					vector3 += vector;
				}
				if (gclass23_0.IsZeroZombie(valueOrDefault))
				{
					((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(val, vector3, LocalizationStringProvider.GetString("ESP_ZeroZombie"), new Color(ref CerberusConfig.Esp.AntagColor));
					vector3 += vector;
				}
				if (gclass23_0.IsChangeling(valueOrDefault))
				{
					((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(val, vector3, LocalizationStringProvider.GetString("ESP_Changeling"), new Color(ref CerberusConfig.Esp.AntagColor));
					vector3 += vector;
				}
				if (gclass23_0.IsCosmicCult(valueOrDefault))
				{
					((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(val, vector3, LocalizationStringProvider.GetString("ESP_CosmicCult"), new Color(ref CerberusConfig.Esp.AntagColor));
					vector3 += vector;
				}
				if (gclass23_0.IsDevil(valueOrDefault))
				{
					((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(val, vector3, LocalizationStringProvider.GetString("ESP_Devil"), new Color(ref CerberusConfig.Esp.AntagColor));
					vector3 += vector;
				}
				if (gclass23_0.IsBlob(valueOrDefault))
				{
					((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(val, vector3, LocalizationStringProvider.GetString("ESP_Blob"), new Color(ref CerberusConfig.Esp.AntagColor));
					vector3 += vector;
				}
				if (gclass23_0.IsThief(valueOrDefault))
				{
					((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(val, vector3, LocalizationStringProvider.GetString("ESP_Thief"), new Color(ref CerberusConfig.Esp.AntagColor));
					vector3 += vector;
				}
			}
			if (CerberusConfig.Esp.ShowFriend && gclass6_0.IsFriend(valueOrDefault))
			{
				((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(val, vector3, LocalizationStringProvider.GetString("ESP_Friend"), new Color(ref CerberusConfig.Esp.FriendColor));
				vector3 += vector;
			}
			if (CerberusConfig.Esp.ShowPriority && gclass8_0.IsPriority(valueOrDefault))
			{
				((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(val, vector3, LocalizationStringProvider.GetString("ESP_Priority"), new Color(ref CerberusConfig.Esp.PriorityColor));
				vector3 += vector;
			}
			if (CerberusConfig.Esp.ShowCombatMode && ientityManager_0.TryGetComponent<CombatModeComponent>(valueOrDefault, ref val4) && val4.IsInCombatMode)
			{
				((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(val, vector3, LocalizationStringProvider.GetString("ESP_CombatMode"), new Color(ref CerberusConfig.Esp.CombatModeColor));
				vector3 += vector;
			}
			if (gclass25_0.HasContraband(valueOrDefault) && CerberusConfig.Esp.ShowContraband)
			{
				((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(val2, vector3, LocalizationStringProvider.GetString("ESP_Contraband"), new Color(ref CerberusConfig.Esp.ContrabandColor));
				vector3 += vector;
			}
			if (gclass25_0.HasImplants(valueOrDefault) && CerberusConfig.Esp.ShowImplants)
			{
				((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(val2, vector3, LocalizationStringProvider.GetString("ESP_Implants"), new Color(ref CerberusConfig.Esp.ImplantsColor));
				vector3 += vector;
			}
			if (gclass25_0.HasWeapons(valueOrDefault) && CerberusConfig.Esp.ShowWeapon)
			{
				((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(val2, vector3, LocalizationStringProvider.GetString("ESP_Weapon"), new Color(ref CerberusConfig.Esp.WeaponColor));
				vector3 += vector;
			}
			if (!gclass21_0.CanSlip(valueOrDefault) && CerberusConfig.Esp.ShowNoSlip)
			{
				((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(val2, vector3, LocalizationStringProvider.GetString("ESP_NoSlip"), new Color(ref CerberusConfig.Esp.NoSlipColor));
				vector3 += vector;
			}
		}
	}

	private void UpdateValidSessions()
	{
		List<ICommonSession> list = ((ISharedPlayerManager)iplayerManager_0).Sessions.ToList();
		foreach (ICommonSession item in list_0.ToList())
		{
			if (!list.Contains(item))
			{
				((ISharedPlayerManager)iplayerManager_0).SetStatus(item, (SessionStatus)4);
			}
		}
		foreach (ICommonSession item2 in list)
		{
			if (!list_0.Contains(item2))
			{
				list_0.Add(item2);
			}
		}
	}
}
