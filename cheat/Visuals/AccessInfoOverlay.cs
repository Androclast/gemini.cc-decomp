using System.Linq;
using System.Numerics;
using Content.Shared.Access;
using Content.Shared.Access.Components;
using Robust.Client.Graphics;
using Robust.Client.Input;
using Robust.Client.Player;
using Robust.Client.ResourceManagement;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Localization;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using Robust.Shared.Player;
using Robust.Shared.Prototypes;
using CerberusConfig;

namespace AccessInfoOverlay;

public sealed class AccessInfoOverlay : Overlay
{
	[Dependency]
	private readonly IInputManager iinputManager_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IResourceCache iresourceCache_0;

	[Dependency]
	private readonly IEntitySystemManager ientitySystemManager_0;

	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IEyeManager ieyeManager_0;

	[Dependency]
	private readonly IPrototypeManager iprototypeManager_0;

	private EntityLookupSystem entityLookupSystem_0;

	private Font font_0;

	private string string_0 = "";

	private int int_0;

	private EntityUid? nullable_0;

	private float float_0;

	private int int_1;

	public override OverlaySpace Space => (OverlaySpace)2;

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

	private int Int32_0
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public AccessInfoOverlay()
	{
		IoCManager.InjectDependencies<AccessInfoOverlay>(this);
		((Overlay)this).ZIndex = 200;
		UpdateFont();
	}

	private void UpdateFont()
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		if (string_0 != CerberusConfig.AccessViewer.FontPath || int_0 != CerberusConfig.AccessViewer.FontSize)
		{
			string_0 = CerberusConfig.AccessViewer.FontPath;
			int_0 = CerberusConfig.AccessViewer.FontSize;
			try
			{
				font_0 = (Font)new VectorFont(iresourceCache_0.GetResource<FontResource>(string_0, true), int_0);
			}
			catch
			{
				font_0 = (Font)new VectorFont(iresourceCache_0.GetResource<FontResource>("/Fonts/Boxfont-round/Boxfont Round.ttf", true), 8);
			}
		}
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.AccessViewer.Enabled)
		{
			return;
		}
		UpdateFont();
		if (entityLookupSystem_0 == null)
		{
			entityLookupSystem_0 = ientitySystemManager_0.GetEntitySystem<EntityLookupSystem>();
		}
		if (entityLookupSystem_0 != null)
		{
			HandleTargetLocking(in args);
			EntityUid? targetEntity = GetTargetEntity(in args);
			if (targetEntity.HasValue)
			{
				DisplayAccessInfo(in args, targetEntity.Value);
			}
		}
	}

	private void HandleTargetLocking(in OverlayDrawArgs args)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		if (!KeyStateHelper.IsKeyDown(CerberusConfig.AccessViewer.HotKey))
		{
			return;
		}
		EntityUid? entityUnderCursor = GetEntityUnderCursor(in args);
		if (entityUnderCursor.HasValue)
		{
			EntityUid? val = nullable_0;
			EntityUid? val2 = entityUnderCursor;
			if (val.HasValue == val2.HasValue && (!val.HasValue || val.GetValueOrDefault() == val2.GetValueOrDefault()))
			{
				nullable_0 = null;
			}
			else
			{
				nullable_0 = entityUnderCursor;
			}
		}
	}

	private EntityUid? GetTargetEntity(in OverlayDrawArgs args)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		if (!nullable_0.HasValue || !ientityManager_0.EntityExists(nullable_0.Value))
		{
			return GetEntityUnderCursor(in args);
		}
		return nullable_0;
	}

	private EntityUid? GetEntityUnderCursor(in OverlayDrawArgs args)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (localEntity.HasValue && ientityManager_0.HasComponent<TransformComponent>(localEntity.Value))
		{
			ScreenCoordinates mouseScreenPosition = iinputManager_0.MouseScreenPosition;
			MapCoordinates val = ieyeManager_0.ScreenToMap(mouseScreenPosition);
			if (ientityManager_0.GetComponent<TransformComponent>(localEntity.Value).MapPosition.MapId != val.MapId)
			{
				return null;
			}
			Box2 val2 = Box2.CenteredAround(val.Position, new Vector2(0.2f, 0.2f));
			return entityLookupSystem_0.GetEntitiesIntersecting(val.MapId, val2, (LookupFlags)110).FirstOrDefault(delegate(EntityUid uid)
			{
				//IL_0015: Unknown result type (might be due to invalid IL or missing references)
				//IL_0029: Unknown result type (might be due to invalid IL or missing references)
				//IL_0008: Unknown result type (might be due to invalid IL or missing references)
				if (!ientityManager_0.HasComponent<TransformComponent>(uid))
				{
					return false;
				}
				return ientityManager_0.HasComponent<IdCardComponent>(uid) || ientityManager_0.HasComponent<AccessComponent>(uid);
			});
		}
		return null;
	}

	private void DisplayAccessInfo(in OverlayDrawArgs args, EntityUid targetEntity)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		TransformComponent val = default(TransformComponent);
		if (!ientityManager_0.TryGetComponent<TransformComponent>(targetEntity, ref val))
		{
			return;
		}
		Vector2 worldPosition = val.WorldPosition;
		Vector2 vector = ieyeManager_0.WorldToScreen(worldPosition) - new Vector2(230f, 30f);
		string text = "ID Карта";
		string text2 = "Неизвестно";
		string text3 = "Неизвестно";
		IdCardComponent val2 = default(IdCardComponent);
		if (ientityManager_0.TryGetComponent<IdCardComponent>(targetEntity, ref val2))
		{
			text = ientityManager_0.GetComponent<MetaDataComponent>(targetEntity).EntityName;
			text2 = val2.FullName ?? "Неизвестно";
			text3 = val2.LocalizedJobTitle ?? "Неизвестно";
		}
		((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(font_0, vector, "═══ " + text + " ═══", new Color(ref CerberusConfig.AccessViewer.Color));
		vector.Y += 14f;
		((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(font_0, vector, "Владелец: " + text2, new Color(ref CerberusConfig.AccessViewer.Color));
		vector.Y += 12f;
		((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(font_0, vector, "Должность: " + text3, new Color(ref CerberusConfig.AccessViewer.Color));
		vector.Y += 14f;
		AccessComponent val3 = default(AccessComponent);
		if (!ientityManager_0.TryGetComponent<AccessComponent>(targetEntity, ref val3))
		{
			((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(font_0, vector, "Нет компонента доступов", Color.Gray);
			return;
		}
		if (val3.Tags.Count <= 0)
		{
			((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(font_0, vector, "Нет доступов", Color.Gray);
			return;
		}
		((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(font_0, vector, "Доступы:", new Color(ref CerberusConfig.AccessViewer.Color));
		vector.Y += 12f;
		AccessLevelPrototype val4 = default(AccessLevelPrototype);
		foreach (ProtoId<AccessLevelPrototype> item in val3.Tags.OrderBy((ProtoId<AccessLevelPrototype> tag) => tag.Id).ToList())
		{
			string text4 = item.Id;
			if (iprototypeManager_0.TryIndex<AccessLevelPrototype>(item, ref val4))
			{
				text4 = Loc.GetString(val4.Name);
			}
			((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(font_0, vector, "  • " + text4, new Color(ref CerberusConfig.AccessViewer.Color));
			vector.Y += 12f;
		}
	}
}
