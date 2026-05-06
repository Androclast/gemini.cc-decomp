using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using Content.Shared.Storage;
using Robust.Client.Graphics;
using Robust.Client.Input;
using Robust.Client.Player;
using Robust.Client.ResourceManagement;
using Robust.Shared.Containers;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using Robust.Shared.Player;
using CerberusConfig;

[CompilerGenerated]
public sealed class StorageContentEspOverlay : Overlay
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

	private EntityLookupSystem entityLookupSystem_0;

	private readonly (string, string)[] valueTuple_0 = new(string, string)[8]
	{
		("pocket1", "Карман 1"),
		("pocket2", "Карман 2"),
		("back", "Спина"),
		("belt", "Пояс"),
		("body_part_slot_right_hand", "Правая рука"),
		("body_part_slot_left_hand", "Левая рука"),
		("entity_storage", "Контейнер"),
		("disposals", "Мусорка")
	};

	private Font font_0;

	private string string_0 = "";

	private int int_0;

	private readonly string string_1 = "implant";

	private EntityUid? nullable_0;

	private bool bool_1;

	private double double_0;

	public override OverlaySpace Space => (OverlaySpace)2;

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

	public StorageContentEspOverlay()
	{
		IoCManager.InjectDependencies<StorageContentEspOverlay>(this);
		((Overlay)this).ZIndex = 200;
		UpdateFont();
	}

	private void UpdateFont()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		if (string_0 != CerberusConfig.StorageViewer.FontPath || int_0 != CerberusConfig.StorageViewer.FontSize)
		{
			string_0 = CerberusConfig.StorageViewer.FontPath;
			int_0 = CerberusConfig.StorageViewer.FontSize;
			try
			{
				font_0 = (Font)new VectorFont(iresourceCache_0.GetResource<FontResource>(string_0, true), int_0);
			}
			catch
			{
				font_0 = (Font)new VectorFont(iresourceCache_0.GetResource<FontResource>("/Fonts/Boxfont-round/Boxfont Round.ttf", true), 10);
			}
		}
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.StorageViewer.Enabled)
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
				DisplayTargetContents(in args, targetEntity.Value);
			}
		}
	}

	private void HandleTargetLocking(in OverlayDrawArgs args)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		if (!KeyStateHelper.IsKeyDown(CerberusConfig.StorageViewer.HotKey))
		{
			return;
		}
		EntityUid? entityUnderCursor = GetEntityUnderCursor(in args);
		if (entityUnderCursor.HasValue)
		{
			EntityUid? val = nullable_0;
			EntityUid? val2 = entityUnderCursor;
			if (val.HasValue != val2.HasValue || (val.HasValue && !(val.GetValueOrDefault() == val2.GetValueOrDefault())))
			{
				nullable_0 = entityUnderCursor;
			}
			else
			{
				nullable_0 = null;
			}
		}
	}

	private EntityUid? GetTargetEntity(in OverlayDrawArgs args)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		if (!nullable_0.HasValue || !ientityManager_0.EntityExists(nullable_0.Value))
		{
			return GetEntityUnderCursor(in args);
		}
		return nullable_0;
	}

	private EntityUid? GetEntityUnderCursor(in OverlayDrawArgs args)
	{
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		EntityUid? result;
		if (localEntity.HasValue && ientityManager_0.HasComponent<TransformComponent>(localEntity.Value))
		{
			ScreenCoordinates mouseScreenPosition = iinputManager_0.MouseScreenPosition;
			MapCoordinates val = ieyeManager_0.ScreenToMap(mouseScreenPosition);
			if (ientityManager_0.GetComponent<TransformComponent>(localEntity.Value).MapPosition.MapId != val.MapId)
			{
				result = null;
			}
			else
			{
				Box2 val2 = Box2.CenteredAround(val.Position, new Vector2(0.2f, 0.2f));
				result = entityLookupSystem_0.GetEntitiesIntersecting(val.MapId, val2, (LookupFlags)110).FirstOrDefault(delegate(EntityUid uid)
				{
					//IL_000e: Unknown result type (might be due to invalid IL or missing references)
					//IL_001c: Unknown result type (might be due to invalid IL or missing references)
					//IL_002a: Unknown result type (might be due to invalid IL or missing references)
					if (!ientityManager_0.HasComponent<TransformComponent>(uid))
					{
						return false;
					}
					return ientityManager_0.HasComponent<StorageComponent>(uid) || ientityManager_0.HasComponent<ContainerManagerComponent>(uid);
				});
			}
		}
		else
		{
			result = null;
		}
		return result;
	}

	private void DisplayTargetContents(in OverlayDrawArgs args, EntityUid targetEntity)
	{
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		TransformComponent val = default(TransformComponent);
		if (!ientityManager_0.TryGetComponent<TransformComponent>(targetEntity, ref val))
		{
			return;
		}
		Vector2 textPosition = ieyeManager_0.WorldToScreen(val.WorldPosition) - new Vector2(230f, 30f);
		bool hasContents = false;
		StorageComponent val2 = default(StorageComponent);
		if (!ientityManager_0.TryGetComponent<StorageComponent>(targetEntity, ref val2) || ((BaseContainer)val2.Container).ContainedEntities.Count <= 0)
		{
			ContainerManagerComponent val3 = default(ContainerManagerComponent);
			if (!ientityManager_0.TryGetComponent<ContainerManagerComponent>(targetEntity, ref val3))
			{
				return;
			}
			(string, string)[] array = valueTuple_0;
			BaseContainer container = default(BaseContainer);
			for (int i = 0; i < array.Length; i++)
			{
				var (text, containerName) = array[i];
				if (val3.TryGetContainer(text, ref container) && HasContainerContents(container))
				{
					DisplayContainerName(in args, ref textPosition, containerName, ref hasContents);
					DisplayContainerContents(in args, ref textPosition, container, ref hasContents);
				}
			}
			BaseContainer val4 = default(BaseContainer);
			if (!val3.TryGetContainer(string_1, ref val4))
			{
				return;
			}
			{
				StorageComponent val5 = default(StorageComponent);
				foreach (EntityUid containedEntity in val4.ContainedEntities)
				{
					if (ientityManager_0.TryGetComponent<StorageComponent>(containedEntity, ref val5) && ((BaseContainer)val5.Container).ContainedEntities.Count > 0)
					{
						string entityName = ientityManager_0.GetComponent<MetaDataComponent>(containedEntity).EntityName;
						DisplayContainerName(in args, ref textPosition, entityName, ref hasContents);
						DisplayContainerContents(in args, ref textPosition, (BaseContainer)(object)val5.Container, ref hasContents, 2);
					}
				}
				return;
			}
		}
		DisplayContainerContents(in args, ref textPosition, (BaseContainer)(object)val2.Container, ref hasContents);
	}

	private void DisplayContainerName(in OverlayDrawArgs args, ref Vector2 textPosition, string containerName, ref bool hasContents)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		if (!hasContents)
		{
			((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(font_0, textPosition, "Хранится:", new Color(ref CerberusConfig.StorageViewer.Color));
			textPosition.Y += 12f;
			hasContents = true;
		}
		((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(font_0, textPosition, " " + containerName + ":", new Color(ref CerberusConfig.StorageViewer.Color));
		textPosition.Y += 12f;
	}

	private void DisplayContainerContents(in OverlayDrawArgs args, ref Vector2 textPosition, BaseContainer container, ref bool hasContents, int nestingLevel = 1)
	{
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		foreach (var item3 in from entity in container.ContainedEntities
			group entity by ientityManager_0.GetComponent<MetaDataComponent>(entity).EntityName into @group
			select (@group.Key, @group.Count()))
		{
			string item = item3.Item1;
			int item2 = item3.Item2;
			string text = new string(' ', nestingLevel * 2);
			string text2 = ((item2 <= 1) ? item : $"{item} {item2}x");
			string text3 = text2;
			((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(font_0, textPosition, text + "- " + text3, new Color(ref CerberusConfig.StorageViewer.Color));
			textPosition.Y += 12f;
		}
		StorageComponent val = default(StorageComponent);
		foreach (EntityUid containedEntity in container.ContainedEntities)
		{
			if (ientityManager_0.TryGetComponent<StorageComponent>(containedEntity, ref val) && ((BaseContainer)val.Container).ContainedEntities.Count > 0)
			{
				string text4 = new string(' ', nestingLevel * 2);
				((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(font_0, textPosition, text4 + "- " + ientityManager_0.GetComponent<MetaDataComponent>(((Component)val).Owner).EntityName + ":", new Color(ref CerberusConfig.StorageViewer.Color));
				textPosition.Y += 12f;
				DisplayContainerContents(in args, ref textPosition, (BaseContainer)(object)val.Container, ref hasContents, nestingLevel + 1);
			}
		}
	}

	private bool HasContainerContents(BaseContainer container)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		if (container.ContainedEntities.Count <= 0)
		{
			StorageComponent val = default(StorageComponent);
			foreach (EntityUid containedEntity in container.ContainedEntities)
			{
				if (ientityManager_0.TryGetComponent<StorageComponent>(containedEntity, ref val) && ((BaseContainer)val.Container).ContainedEntities.Count > 0)
				{
					goto IL_0061;
				}
			}
			return false;
		}
		return true;
		IL_0061:
		return true;
	}
}
