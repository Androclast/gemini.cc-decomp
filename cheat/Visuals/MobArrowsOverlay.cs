using System;
using System.Collections.Generic;
using System.Numerics;
using Content.Shared.Mobs.Components;
using Content.Shared.Mobs.Systems;
using Robust.Client.Graphics;
using Robust.Client.Player;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using Robust.Shared.Player;
using TextureLoader;
using CerberusConfig;

namespace MobArrowsOverlay;

public sealed class MobArrowsOverlay : Overlay
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	private SharedTransformSystem sharedTransformSystem_0;

	private MobStateSystem mobStateSystem_0;

	private readonly List<(EntityUid, Vector2)> list_0 = new List<(EntityUid, Vector2)>();

	private float float_0;

	private Texture[] texture_0 = (Texture[])(object)new Texture[12];

	private bool bool_0;

	private int int_0;

	private int int_1;

	private float float_1;

	public override OverlaySpace Space => (OverlaySpace)4;

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

	private int Int32_1
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

	public MobArrowsOverlay()
	{
		IoCManager.InjectDependencies<MobArrowsOverlay>(this);
	}

	private void LoadTextures()
	{
		if (bool_0)
		{
			return;
		}
		try
		{
			texture_0[0] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.arrow.arrow.png", "arrow0");
			for (int i = 1; i < 12; i++)
			{
				texture_0[i] = TextureLoader.LoadTexture($"Kaban.cc.Resources.Visuals.arrow.arrow{i}.png", $"arrow{i}");
			}
			bool_0 = true;
		}
		catch (Exception)
		{
		}
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.Tracers.Enabled)
		{
			return;
		}
		if (!bool_0)
		{
			LoadTextures();
		}
		if (sharedTransformSystem_0 == null)
		{
			try
			{
				sharedTransformSystem_0 = ientityManager_0.System<SharedTransformSystem>();
				mobStateSystem_0 = ientityManager_0.System<MobStateSystem>();
			}
			catch
			{
				return;
			}
		}
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		TransformComponent val = default(TransformComponent);
		if (!localEntity.HasValue || !ientityManager_0.TryGetComponent<TransformComponent>(localEntity.Value, ref val))
		{
			return;
		}
		Vector2 worldPosition = val.WorldPosition;
		DrawingHandleWorld worldHandle = ((OverlayDrawArgs)(ref args)).WorldHandle;
		MapId mapId = args.MapId;
		float_0 += 1f / 60f;
		if (float_0 >= 0.1f || list_0.Count == 0)
		{
			UpdateTargetCache(localEntity.Value, worldPosition, mapId);
			float_0 = 0f;
		}
		int num = Math.Clamp(CerberusConfig.Tracers.ArrowVariant, 0, 11);
		Texture val2 = texture_0[num];
		if (val2 == null)
		{
			return;
		}
		foreach (var item in list_0)
		{
			Vector2 value = item.Item2 - worldPosition;
			float angle = (float)Math.Atan2(value.Y, value.X);
			Vector2 position = worldPosition + Vector2.Normalize(value) * 1f;
			DrawArrowTexture(worldHandle, position, angle, val2);
		}
	}

	private void UpdateTargetCache(EntityUid localPlayer, Vector2 localPos, MapId mapId)
	{
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		list_0.Clear();
		AllEntityQueryEnumerator<MobStateComponent, TransformComponent> val = ientityManager_0.AllEntityQueryEnumerator<MobStateComponent, TransformComponent>();
		EntityUid val2 = default(EntityUid);
		MobStateComponent val3 = default(MobStateComponent);
		TransformComponent val4 = default(TransformComponent);
		while (val.MoveNext(ref val2, ref val3, ref val4))
		{
			if (val2 == localPlayer || mobStateSystem_0.IsDead(val2, val3) || val4.MapID != mapId)
			{
				continue;
			}
			Vector2 worldPosition = val4.WorldPosition;
			if ((worldPosition - localPos).Length() <= 50f)
			{
				list_0.Add((val2, worldPosition));
				if (list_0.Count >= 20)
				{
					break;
				}
			}
		}
	}

	private void DrawArrowTexture(DrawingHandleWorld handle, Vector2 position, float angle, Texture texture)
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		Color modulate = default(Color);
		((Color)(ref modulate))._002Ector(CerberusConfig.Tracers.ArrowColor.X, CerberusConfig.Tracers.ArrowColor.Y, CerberusConfig.Tracers.ArrowColor.Z, CerberusConfig.Tracers.ArrowColor.W);
		((DrawingHandleBase)handle).UseShader((ShaderInstance)null);
		Matrix3x2 matrix3x = Matrix3x2.CreateRotation(angle - (float)Math.PI / 2f) * Matrix3x2.CreateTranslation(position);
		((DrawingHandleBase)handle).SetTransform(ref matrix3x);
		Box2 val = Box2.CenteredAround(Vector2.Zero, new Vector2(0.6f, 0.6f));
		((DrawingHandleBase)handle).Modulate = modulate;
		handle.DrawTextureRect(texture, val, (Color?)Color.White);
		((DrawingHandleBase)handle).Modulate = Color.White;
		Matrix3x2 identity = Matrix3x2.Identity;
		((DrawingHandleBase)handle).SetTransform(ref identity);
	}
}
