using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using Robust.Client.Graphics;
using Robust.Client.Player;
using Robust.Client.ResourceManagement;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using CerberusConfig;

[CompilerGenerated]
public sealed class GenericCachedEspOverlay : Overlay
{
	private struct CachedItemResult
	{
		public string nUjNvVsMDT;

		public Vector2 vklNSXeHkW;

		public Vector4 SFHNOqIc68;
	}

	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IEyeManager ieyeManager_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IResourceCache iresourceCache_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	private readonly Font font_0;

	private EntityLookupSystem entityLookupSystem_0;

	private double double_0;

	private readonly List<CachedItemResult> list_0 = new List<CachedItemResult>();

	private string string_1;

	private char char_0;

	private long long_0;

	private byte byte_1;

	public override OverlaySpace Space => (OverlaySpace)2;

	private string String_0
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

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

	public GenericCachedEspOverlay()
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		IoCManager.InjectDependencies<GenericCachedEspOverlay>(this);
		((Overlay)this).ZIndex = 200;
		if (font_0 == null)
		{
			font_0 = (Font)new VectorFont(iresourceCache_0.GetResource<FontResource>("/Fonts/Boxfont-round/Boxfont Round.ttf", true), 10);
		}
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.Misc.ItemSearcherEnabled || CerberusConfig.Misc.ItemSearchEntries.Count == 0)
		{
			return;
		}
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (localEntity.HasValue)
		{
			EntityUid value = localEntity.Value;
			double totalSeconds = igameTiming_0.RealTime.TotalSeconds;
			if (totalSeconds - double_0 >= 0.05)
			{
				double_0 = totalSeconds;
				UpdateCache(value);
				DrawCachedResults(in args, value);
			}
			else
			{
				DrawCachedResults(in args, value);
			}
		}
	}

	private void UpdateCache(EntityUid playerEntity)
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		list_0.Clear();
		if (entityLookupSystem_0 == null)
		{
			entityLookupSystem_0 = ientityManager_0.System<EntityLookupSystem>();
		}
		MapId mapID = ientityManager_0.GetComponent<TransformComponent>(playerEntity).MapID;
		Box2 worldViewport = ieyeManager_0.GetWorldViewport();
		HashSet<EntityUid> entitiesIntersecting = entityLookupSystem_0.GetEntitiesIntersecting(mapID, worldViewport, (LookupFlags)110);
		List<ColoredString> itemSearchEntries = CerberusConfig.Misc.ItemSearchEntries;
		MetaDataComponent val = default(MetaDataComponent);
		TransformComponent val2 = default(TransformComponent);
		foreach (EntityUid item in entitiesIntersecting)
		{
			if (!ientityManager_0.TryGetComponent<MetaDataComponent>(item, ref val) || !ientityManager_0.TryGetComponent<TransformComponent>(item, ref val2))
			{
				continue;
			}
			foreach (ColoredString item2 in itemSearchEntries)
			{
				if (!string.IsNullOrWhiteSpace(item2.string_0) && val.EntityName.Contains(item2.string_0, StringComparison.OrdinalIgnoreCase))
				{
					list_0.Add(new CachedItemResult
					{
						nUjNvVsMDT = val.EntityName,
						vklNSXeHkW = val2.WorldPosition,
						SFHNOqIc68 = item2.vector4_0
					});
					break;
				}
			}
		}
	}

	private void DrawCachedResults(in OverlayDrawArgs args, EntityUid playerEntity)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		if (list_0.Count == 0)
		{
			return;
		}
		TransformComponent component = ientityManager_0.GetComponent<TransformComponent>(playerEntity);
		Vector2 vector = ieyeManager_0.WorldToScreen(component.WorldPosition);
		bool itemSearcherShowName = CerberusConfig.Misc.ItemSearcherShowName;
		Color val = default(Color);
		foreach (CachedItemResult item in list_0)
		{
			Vector2 vector2 = ieyeManager_0.WorldToScreen(item.vklNSXeHkW);
			((Color)(ref val))._002Ector(item.SFHNOqIc68.X, item.SFHNOqIc68.Y, item.SFHNOqIc68.Z, item.SFHNOqIc68.W);
			((DrawingHandleBase)((OverlayDrawArgs)(ref args)).ScreenHandle).DrawLine(vector, vector2, val);
			if (itemSearcherShowName)
			{
				((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(font_0, vector2 - new Vector2(0f, 10f), item.nUjNvVsMDT, val);
			}
		}
	}
}
