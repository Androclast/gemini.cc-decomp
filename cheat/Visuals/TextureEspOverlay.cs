using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Runtime.CompilerServices;
using Content.Shared.Mobs.Components;
using Robust.Client.GameObjects;
using Robust.Client.Graphics;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.Graphics;
using Robust.Shared.IoC;
using Robust.Shared.Maths;
using CerberusConfig;

[CompilerGenerated]
public class TextureEspOverlay : Overlay
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	private readonly IEyeManager ieyeManager_0;

	private EntityLookupSystem entityLookupSystem_0;

	private SharedTransformSystem sharedTransformSystem_0;

	private readonly Dictionary<EntityUid, Color> dictionary_0 = new Dictionary<EntityUid, Color>();

	private bool bool_0;

	private Texture texture_0;

	private float float_0;

	private long long_0;

	private float float_1;

	private double double_1;

	public override OverlaySpace Space => (OverlaySpace)16;

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

	private float Single_1
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

	private double Double_0
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public TextureEspOverlay()
	{
		IoCManager.InjectDependencies<TextureEspOverlay>(this);
		((Overlay)this).ZIndex = 200;
	}

	private void LoadTextureFromAppData()
	{
		string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CerberusWare", "image.png");
		if (!File.Exists(path))
		{
			NotificationOverlay.ShowNotification("Custom texture not found");
			return;
		}
		try
		{
			using FileStream fileStream = File.OpenRead(path);
			texture_0 = Texture.LoadFromPNGStream((Stream)fileStream, "CustomTexture", (TextureLoadParameters?)null);
		}
		catch (Exception)
		{
			NotificationOverlay.ShowNotification("Failed to load texture from");
		}
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.Texture.Enabled)
		{
			return;
		}
		if (entityLookupSystem_0 == null)
		{
			entityLookupSystem_0 = ientityManager_0.System<EntityLookupSystem>();
		}
		if (sharedTransformSystem_0 == null)
		{
			sharedTransformSystem_0 = ientityManager_0.System<SharedTransformSystem>();
		}
		if (entityLookupSystem_0 == null || sharedTransformSystem_0 == null)
		{
			return;
		}
		if (!bool_0)
		{
			LoadTextureFromAppData();
			bool_0 = true;
		}
		if (texture_0 == null)
		{
			return;
		}
		TransformComponent val2 = default(TransformComponent);
		foreach (EntityUid item in entityLookupSystem_0.GetEntitiesIntersecting(ieyeManager_0.CurrentMap, ieyeManager_0.GetWorldViewport(), (LookupFlags)110))
		{
			SpriteComponent val = null;
			if (!ientityManager_0.TryGetComponent<TransformComponent>(item, ref val2) || !ientityManager_0.TryGetComponent<SpriteComponent>(item, ref val) || !ientityManager_0.HasComponent<MobStateComponent>(item))
			{
				continue;
			}
			if (!CerberusConfig.Texture.MakeEntitiesInvisible)
			{
				if (dictionary_0.ContainsKey(item))
				{
					val.Color = dictionary_0[item];
					dictionary_0.Remove(item);
				}
			}
			else
			{
				if (!dictionary_0.ContainsKey(item))
				{
					dictionary_0[item] = val.Color;
				}
				val.Color = new Color((byte)0, (byte)0, (byte)0, (byte)0);
			}
			Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(item);
			sharedTransformSystem_0.GetWorldRotation(item);
			Box2.CenteredAround(worldPosition, new Vector2(CerberusConfig.Texture.Size));
			Box2Rotated val3 = default(Box2Rotated);
			((OverlayDrawArgs)(ref args)).WorldHandle.DrawTextureRect(texture_0, ref val3, (Color?)null);
		}
	}
}
