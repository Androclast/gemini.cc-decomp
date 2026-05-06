using System.Numerics;
using Content.Shared.Anomaly;
using Content.Shared.Anomaly.Components;
using Robust.Client.Graphics;
using Robust.Client.Input;
using Robust.Client.Player;
using Robust.Client.ResourceManagement;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using Robust.Shared.Player;
using CerberusConfig;

namespace AnomalyInfoOverlay;

public sealed class AnomalyInfoOverlay : Overlay
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

	private Font font_0;

	private string string_0 = "";

	private int int_0;

	private EntityUid? nullable_0;

	private char char_1;

	private bool bool_0;

	private float float_0;

	private byte byte_0;

	public override OverlaySpace Space => (OverlaySpace)2;

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

	public AnomalyInfoOverlay()
	{
		IoCManager.InjectDependencies<AnomalyInfoOverlay>(this);
		((Overlay)this).ZIndex = 200;
		UpdateFont();
	}

	private void UpdateFont()
	{
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		if (string_0 != CerberusConfig.AnomalyScanner.FontPath || int_0 != CerberusConfig.AnomalyScanner.FontSize)
		{
			string_0 = CerberusConfig.AnomalyScanner.FontPath;
			int_0 = CerberusConfig.AnomalyScanner.FontSize;
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
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.AnomalyScanner.Enabled)
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
			AnomalyComponent anomaly = default(AnomalyComponent);
			TransformComponent val = default(TransformComponent);
			if (targetEntity.HasValue && ientityManager_0.TryGetComponent<AnomalyComponent>(targetEntity.Value, ref anomaly) && ientityManager_0.TryGetComponent<TransformComponent>(targetEntity.Value, ref val))
			{
				DisplayAnomalyInfo(in args, targetEntity.Value, anomaly, val.WorldPosition);
			}
		}
	}

	private void HandleTargetLocking(in OverlayDrawArgs args)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		if (!KeyStateHelper.IsKeyDown(CerberusConfig.AnomalyScanner.HotKey))
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
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		if (nullable_0.HasValue && ientityManager_0.EntityExists(nullable_0.Value))
		{
			return nullable_0;
		}
		return GetEntityUnderCursor(in args);
	}

	private EntityUid? GetEntityUnderCursor(in OverlayDrawArgs args)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (!localEntity.HasValue || !ientityManager_0.HasComponent<TransformComponent>(localEntity.Value))
		{
			return null;
		}
		ScreenCoordinates mouseScreenPosition = iinputManager_0.MouseScreenPosition;
		MapCoordinates val = ieyeManager_0.ScreenToMap(mouseScreenPosition);
		if (ientityManager_0.GetComponent<TransformComponent>(localEntity.Value).MapPosition.MapId != val.MapId)
		{
			return null;
		}
		Box2 val2 = Box2.CenteredAround(val.Position, new Vector2(0.2f, 0.2f));
		foreach (EntityUid item in entityLookupSystem_0.GetEntitiesIntersecting(val.MapId, val2, (LookupFlags)110))
		{
			if (ientityManager_0.HasComponent<AnomalyComponent>(item))
			{
				return item;
			}
		}
		return null;
	}

	private void DisplayAnomalyInfo(in OverlayDrawArgs args, EntityUid anomalyEntity, AnomalyComponent anomaly, Vector2 worldPos)
	{
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Invalid comparison between Unknown and I4
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		Vector2 vector = ieyeManager_0.WorldToScreen(worldPos) + new Vector2(20f, -60f);
		Color val = new Color(ref CerberusConfig.AnomalyScanner.Color);
		string text = "Аномалия";
		MetaDataComponent val2 = default(MetaDataComponent);
		if (ientityManager_0.TryGetComponent<MetaDataComponent>(anomalyEntity, ref val2))
		{
			text = val2.EntityName;
		}
		((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(font_0, vector, "═══ " + text + " ═══", val);
		vector.Y += 14f;
		string stabilityStatus = GetStabilityStatus(anomaly.Stability);
		Color stabilityColor = GetStabilityColor(anomaly.Stability);
		((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(font_0, vector, "Статус: " + stabilityStatus, stabilityColor);
		vector.Y += 12f;
		((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(font_0, vector, $"Стабильность: {anomaly.Stability:F2} | Серьезность: {anomaly.Severity:F2}", val);
		vector.Y += 12f;
		((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(font_0, vector, $"Здоровье: {anomaly.Health:F2}", val);
		vector.Y += 14f;
		((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(font_0, vector, "Частицы:", val);
		vector.Y += 12f;
		string particleName = GetParticleName(anomaly.SeverityParticleType);
		((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(font_0, vector, "  Серьезность: " + particleName, new Color(1f, 0.3f, 0.3f, 1f));
		vector.Y += 12f;
		string particleName2 = GetParticleName(anomaly.DestabilizingParticleType);
		((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(font_0, vector, "  Дестабилизация: " + particleName2, new Color(1f, 0.7f, 0.3f, 1f));
		vector.Y += 12f;
		string particleName3 = GetParticleName(anomaly.WeakeningParticleType);
		((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(font_0, vector, "  Ослабление: " + particleName3, new Color(0.3f, 1f, 0.3f, 1f));
		vector.Y += 12f;
		if ((int)anomaly.TransformationParticleType != 4)
		{
			string particleName4 = GetParticleName(anomaly.TransformationParticleType);
			((OverlayDrawArgs)(ref args)).ScreenHandle.DrawString(font_0, vector, "  Трансформация: " + particleName4, new Color(0.7f, 0.3f, 1f, 1f));
		}
	}

	private string GetParticleName(AnomalousParticleType particleType)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected I4, but got Unknown
		return (int)particleType switch
		{
			4 => "Нет", 
			3 => "Сигма (Σ)", 
			0 => "Дельта (Δ)", 
			1 => "Эпсилон (Ε)", 
			2 => "Зета (Ζ)", 
			_ => "Неизвестно", 
		};
	}

	private string GetStabilityStatus(float stability)
	{
		if (stability >= 0.15f)
		{
			if (stability >= 0.5f)
			{
				if (stability >= 0.8f)
				{
					return "Критично";
				}
				return "Нестабильно";
			}
			return "Стабильно";
		}
		return "Распад";
	}

	private Color GetStabilityColor(float stability)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		if (!(stability >= 0.15f))
		{
			return new Color(0.5f, 0.5f, 1f, 1f);
		}
		if (stability >= 0.5f)
		{
			if (stability >= 0.8f)
			{
				return new Color(1f, 0.3f, 0.3f, 1f);
			}
			return new Color(1f, 0.7f, 0.3f, 1f);
		}
		return new Color(0.3f, 1f, 0.3f, 1f);
	}
}
