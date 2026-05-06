using System;
using System.Collections.Generic;
using System.Numerics;
using Robust.Client.Graphics;
using Robust.Client.Player;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using Robust.Shared.Random;
using Robust.Shared.Timing;
using TextureLoader;
using CerberusConfig;

namespace BloomTrailOverlay;

public sealed class BloomTrailOverlay : Overlay
{
	private struct TrailPoint
	{
		public Vector2 IV83Gxs9eY;

		public Vector2 xfs3YlSK4b;

		public float ORy3lamkva;

		public MapId iJe3KkqWpi;

		public Texture xdU3BYAJ6Y;

		public float AIe3zSQdpH;

		public float rUJMpZSocV;
	}

	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly IRobustRandom irobustRandom_0;

	private SharedTransformSystem sharedTransformSystem_0;

	private List<TrailPoint> list_0 = new List<TrailPoint>();

	private Vector2 vector2_0 = Vector2.Zero;

	private readonly Dictionary<string, Texture> dictionary_0 = new Dictionary<string, Texture>();

	private bool bool_0;

	private readonly List<Texture> list_1 = new List<Texture>();

	private readonly List<Texture> list_2 = new List<Texture>();

	private readonly List<Texture> list_3 = new List<Texture>();

	private readonly List<Texture> list_4 = new List<Texture>();

	private long long_0;

	private string string_1;

	private long long_1;

	private double double_0;

	public override OverlaySpace Space => (OverlaySpace)64;

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

	private long Int64_1
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

	private float GetSpawnDistance()
	{
		float trailLength = CerberusConfig.Trails.TrailLength;
		return 0.05f / trailLength;
	}

	public BloomTrailOverlay()
	{
		IoCManager.InjectDependencies<BloomTrailOverlay>(this);
	}

	private void LoadTextures()
	{
		if (bool_0)
		{
			return;
		}
		try
		{
			dictionary_0["amongus"] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.particles.amongus.png", "trail_amongus");
			dictionary_0["star"] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.particles.star.png", "trail_star");
			dictionary_0["pumpkin"] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.particles.pumpkin.png", "trail_pumpkin");
			dictionary_0["crown"] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.particles.crown.png", "trail_crown");
			dictionary_0["dead"] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.particles.dead.png", "trail_dead");
			dictionary_0["dollar"] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.particles.dollar.png", "trail_dollar");
			dictionary_0["heart"] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.particles.heart.png", "trail_heart");
			dictionary_0["light"] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.particles.light.png", "trail_light");
			dictionary_0["polygon"] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.particles.polygon.png", "trail_polygon");
			dictionary_0["rhombus"] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.particles.rhombus.png", "trail_rhombus");
			dictionary_0["snow"] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.particles.snow.png", "trail_snow");
			dictionary_0["swastika"] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.particles.svastun.png", "trail_swastika");
			dictionary_0["bloom"] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.world.bloom.png", "trail_bloom");
			for (int i = 1; i <= 8; i++)
			{
				Texture val = TextureLoader.LoadTexture($"Kaban.cc.Resources.Visuals.particles.geometry_pack.p{i}.png", $"trail_geometry_p{i}");
				if (val != null)
				{
					list_1.Add(val);
				}
			}
			string[] array = new string[9] { "crown", "dollar", "feather", "genshin", "heart", "lightning", "mcross", "moon", "star" };
			foreach (string text in array)
			{
				Texture val2 = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.particles.mix." + text + ".png", "trail_mix_" + text);
				if (val2 != null)
				{
					list_2.Add(val2);
				}
			}
			array = new string[6] { "snow", "snowbag1", "snowbcataclysm1", "snowblast1", "snowbrich1", "snownew1" };
			foreach (string text2 in array)
			{
				Texture val3 = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.particles.pack_snow." + text2 + ".png", "trail_snow_" + text2);
				if (val3 != null)
				{
					list_3.Add(val3);
				}
			}
			array = new string[3] { "genshin", "spark", "sparkle" };
			foreach (string text3 in array)
			{
				Texture val4 = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.particles.spark_pack." + text3 + ".png", "trail_spark_" + text3);
				if (val4 != null)
				{
					list_4.Add(val4);
				}
			}
			bool_0 = true;
		}
		catch (Exception)
		{
		}
	}

	private Texture GetTextureForMode(int mode)
	{
		switch (mode)
		{
		case 16:
			return dictionary_0.GetValueOrDefault("bloom");
		default:
			return null;
		case 3:
			if (list_4.Count > 0)
			{
				return list_4[irobustRandom_0.Next(list_4.Count)];
			}
			return null;
		case 0:
			if (list_1.Count <= 0)
			{
				return null;
			}
			return list_1[irobustRandom_0.Next(list_1.Count)];
		case 1:
			if (list_2.Count <= 0)
			{
				return null;
			}
			return list_2[irobustRandom_0.Next(list_2.Count)];
		case 2:
			if (list_3.Count <= 0)
			{
				return null;
			}
			return list_3[irobustRandom_0.Next(list_3.Count)];
		case 4:
			return dictionary_0.GetValueOrDefault("amongus");
		case 5:
			return dictionary_0.GetValueOrDefault("crown");
		case 6:
			return dictionary_0.GetValueOrDefault("dead");
		case 7:
			return dictionary_0.GetValueOrDefault("dollar");
		case 8:
			return dictionary_0.GetValueOrDefault("heart");
		case 9:
			return dictionary_0.GetValueOrDefault("light");
		case 10:
			return dictionary_0.GetValueOrDefault("polygon");
		case 11:
			return dictionary_0.GetValueOrDefault("pumpkin");
		case 12:
			return dictionary_0.GetValueOrDefault("rhombus");
		case 13:
			return dictionary_0.GetValueOrDefault("snow");
		case 14:
			return dictionary_0.GetValueOrDefault("star");
		case 15:
			return dictionary_0.GetValueOrDefault("swastika");
		}
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_03c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_0495: Unknown result type (might be due to invalid IL or missing references)
		//IL_0497: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.Trails.Enabled)
		{
			return;
		}
		if (!bool_0)
		{
			LoadTextures();
		}
		if (sharedTransformSystem_0 == null)
		{
			sharedTransformSystem_0 = ientityManager_0.System<SharedTransformSystem>();
		}
		LocalPlayer localPlayer = iplayerManager_0.LocalPlayer;
		EntityUid? val = ((localPlayer != null) ? localPlayer.ControlledEntity : ((EntityUid?)null));
		TransformComponent val2 = default(TransformComponent);
		if (!val.HasValue || !ientityManager_0.TryGetComponent<TransformComponent>(val.Value, ref val2))
		{
			return;
		}
		Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(val2);
		MapId mapID = val2.MapID;
		float H5IMxCLwQC = (float)igameTiming_0.RealTime.TotalSeconds;
		float spawnDistance = GetSpawnDistance();
		int particleCount = CerberusConfig.Trails.ParticleCount;
		if ((worldPosition - vector2_0).LengthSquared() > spawnDistance)
		{
			int trailMode = CerberusConfig.Trails.TrailMode;
			Texture textureForMode = GetTextureForMode(trailMode);
			if (trailMode != 16)
			{
				float particleSpawnRate = CerberusConfig.Trails.ParticleSpawnRate;
				int num = Math.Max(1, (int)Math.Round(particleSpawnRate));
				for (int i = 0; i < num; i++)
				{
					float x = irobustRandom_0.NextFloat() * (float)Math.PI * 2f;
					float num2 = irobustRandom_0.NextFloat(0.3f, 0.8f);
					Vector2 xfs3YlSK4b = new Vector2(MathF.Cos(x), MathF.Sin(x)) * num2;
					float rUJMpZSocV = irobustRandom_0.NextFloat(-5f, 5f);
					list_0.Add(new TrailPoint
					{
						IV83Gxs9eY = worldPosition + new Vector2(irobustRandom_0.NextFloat(-0.1f, 0.1f), irobustRandom_0.NextFloat(-0.1f, 0.1f)),
						xfs3YlSK4b = xfs3YlSK4b,
						ORy3lamkva = H5IMxCLwQC,
						iJe3KkqWpi = mapID,
						xdU3BYAJ6Y = textureForMode,
						AIe3zSQdpH = irobustRandom_0.NextFloat() * (float)Math.PI * 2f,
						rUJMpZSocV = rUJMpZSocV
					});
				}
			}
			else
			{
				list_0.Add(new TrailPoint
				{
					IV83Gxs9eY = worldPosition,
					xfs3YlSK4b = Vector2.Zero,
					ORy3lamkva = H5IMxCLwQC,
					iJe3KkqWpi = mapID,
					xdU3BYAJ6Y = textureForMode,
					AIe3zSQdpH = 0f,
					rUJMpZSocV = 0f
				});
			}
			vector2_0 = worldPosition;
		}
		float Ej6M160dmo = CerberusConfig.Trails.TrailLifetime;
		list_0.RemoveAll((TrailPoint p) => H5IMxCLwQC - p.ORy3lamkva > Ej6M160dmo);
		while (list_0.Count > particleCount)
		{
			list_0.RemoveAt(0);
		}
		DrawingHandleWorld worldHandle = ((OverlayDrawArgs)(ref args)).WorldHandle;
		((DrawingHandleBase)worldHandle).UseShader((ShaderInstance)null);
		Matrix3x2 identity = Matrix3x2.Identity;
		((DrawingHandleBase)worldHandle).SetTransform(ref identity);
		Vector4 trailColor = CerberusConfig.Trails.TrailColor;
		Color val3 = default(Color);
		((Color)(ref val3))._002Ector(trailColor.X, trailColor.Y, trailColor.Z, trailColor.W);
		float trailSize = CerberusConfig.Trails.TrailSize;
		int trailMode2 = CerberusConfig.Trails.TrailMode;
		_ = igameTiming_0.FrameTime.TotalSeconds;
		foreach (TrailPoint item in list_0)
		{
			if (!(item.iJe3KkqWpi != args.MapId) && item.xdU3BYAJ6Y != null)
			{
				float num3 = H5IMxCLwQC - item.ORy3lamkva;
				float num4 = num3 / Ej6M160dmo;
				Vector2 position = item.IV83Gxs9eY + item.xfs3YlSK4b * num3;
				float rotation = item.AIe3zSQdpH + item.rUJMpZSocV * num3;
				float num5 = (1f - num4) * val3.A;
				if (trailMode2 != 16)
				{
					DrawParticleWithRotation(worldHandle, position, item.xdU3BYAJ6Y, trailSize, ((Color)(ref val3)).WithAlpha(num5), num4, rotation);
				}
				else
				{
					DrawBloomTrail(worldHandle, position, item.xdU3BYAJ6Y, trailSize, ((Color)(ref val3)).WithAlpha(num5), num4);
				}
			}
		}
		((DrawingHandleBase)worldHandle).Modulate = Color.White;
	}

	private void DrawParticleWithRotation(DrawingHandleWorld handle, Vector2 position, Texture texture, float size, Color color, float progress, float rotation)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		float num = 1f - progress * 0.5f;
		float num2 = size * num;
		Matrix3x2 matrix3x = Matrix3x2.CreateRotation(rotation) * Matrix3x2.CreateTranslation(position);
		((DrawingHandleBase)handle).SetTransform(ref matrix3x);
		Box2 val = Box2.FromDimensions(new Vector2((0f - num2) / 2f, (0f - num2) / 2f), new Vector2(num2, num2));
		((DrawingHandleBase)handle).Modulate = color;
		handle.DrawTextureRect(texture, val, (Color?)Color.White);
		Matrix3x2 identity = Matrix3x2.Identity;
		((DrawingHandleBase)handle).SetTransform(ref identity);
	}

	private void DrawBloomTrail(DrawingHandleWorld handle, Vector2 position, Texture texture, float size, Color color, float progress)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		float num = 1f + progress * 0.8f;
		float num2 = size * num;
		Box2 val = Box2.CenteredAround(position, new Vector2(num2, num2));
		((DrawingHandleBase)handle).Modulate = color;
		handle.DrawTextureRect(texture, val, (Color?)Color.White);
		if (color.A > 0.3f)
		{
			Box2 val2 = Box2.CenteredAround(position, new Vector2(num2 * 1.3f, num2 * 1.3f));
			((DrawingHandleBase)handle).Modulate = ((Color)(ref color)).WithAlpha(color.A * 0.5f);
			handle.DrawTextureRect(texture, val2, (Color?)Color.White);
			Box2 val3 = Box2.CenteredAround(position, new Vector2(num2 * 1.6f, num2 * 1.6f));
			((DrawingHandleBase)handle).Modulate = ((Color)(ref color)).WithAlpha(color.A * 0.25f);
			handle.DrawTextureRect(texture, val3, (Color?)Color.White);
		}
	}
}
