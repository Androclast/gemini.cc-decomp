using System;
using System.Collections.Generic;
using System.Numerics;
using Robust.Client.Graphics;
using Robust.Client.Player;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Maths;
using Robust.Shared.Random;
using Robust.Shared.Timing;
using TextureLoader;
using CerberusConfig;

namespace WorldParticlesOverlay;

public sealed class WorldParticlesOverlay : Overlay
{
	private class WorldParticle
	{
		public Vector2 qSsMVNoSDX;

		public Vector2 dsDMawa8FQ;

		public float uxYMQbPnka;

		public float BNUMW8wxnl;

		public float RPwMCm3g8q;

		public float Fx5MUTP4GU;

		public float UMKM9bipB5;

		public float PJDMs8tJjS;

		public float SePMbphVKg;

		public float akbMrXy9l7;

		public Texture KoNMDkVkLB;

		private double double_0;

		private byte byte_0;

		private char char_0;

		private long long_2;

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
				return long_2;
			}
			set
			{
				long_2 = value;
			}
		}
	}

	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	private SharedTransformSystem sharedTransformSystem_0;

	private IRobustRandom irobustRandom_0;

	private List<WorldParticle> list_0 = new List<WorldParticle>();

	private bool bool_0;

	private int int_0 = -1;

	private int int_1 = -1;

	private readonly Dictionary<string, Texture> dictionary_0 = new Dictionary<string, Texture>();

	private bool bool_1;

	private readonly List<Texture> list_1 = new List<Texture>();

	private readonly List<Texture> list_2 = new List<Texture>();

	private readonly List<Texture> list_3 = new List<Texture>();

	private readonly List<Texture> list_4 = new List<Texture>();

	private int int_2;

	private string string_0;

	private float float_0;

	private float float_1;

	public override OverlaySpace Space => (OverlaySpace)4;

	private int Int32_0
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
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

	public WorldParticlesOverlay()
	{
		IoCManager.InjectDependencies<WorldParticlesOverlay>(this);
		irobustRandom_0 = IoCManager.Resolve<IRobustRandom>();
	}

	private void LoadTextures()
	{
		if (bool_1)
		{
			return;
		}
		try
		{
			dictionary_0["swastika"] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.particles.svastun.png", "swastika");
			dictionary_0["bloom"] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.world.bloom.png", "bloom");
			for (int i = 1; i <= 8; i++)
			{
				Texture val = TextureLoader.LoadTexture($"Kaban.cc.Resources.Visuals.particles.geometry_pack.p{i}.png", $"geometry_p{i}");
				if (val != null)
				{
					list_1.Add(val);
				}
			}
			string[] array = new string[9] { "crown", "dollar", "feather", "genshin", "heart", "lightning", "mcross", "moon", "star" };
			foreach (string text in array)
			{
				Texture val2 = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.particles.mix." + text + ".png", "mix_" + text);
				if (val2 != null)
				{
					list_2.Add(val2);
				}
			}
			array = new string[6] { "snow", "snowbag1", "snowbcataclysm1", "snowblast1", "snowbrich1", "snownew1" };
			foreach (string text2 in array)
			{
				Texture val3 = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.particles.pack_snow." + text2 + ".png", "snow_" + text2);
				if (val3 != null)
				{
					list_3.Add(val3);
				}
			}
			array = new string[3] { "genshin", "spark", "sparkle" };
			foreach (string text3 in array)
			{
				Texture val4 = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.particles.spark_pack." + text3 + ".png", "spark_" + text3);
				if (val4 != null)
				{
					list_4.Add(val4);
				}
			}
			bool_1 = true;
		}
		catch (Exception)
		{
		}
	}

	private void InitializeParticles(Vector2 playerPos)
	{
		int num = Math.Min(CerberusConfig.WorldParticles.ParticleCount, 250);
		int particleMode = CerberusConfig.WorldParticles.ParticleMode;
		if (!bool_0 || int_1 != num || int_0 != particleMode)
		{
			list_0.Clear();
			for (int i = 0; i < num; i++)
			{
				list_0.Add(CreateParticle(playerPos, randomPos: true));
			}
			bool_0 = true;
			int_1 = num;
			int_0 = particleMode;
		}
	}

	private WorldParticle CreateParticle(Vector2 playerPos, bool randomPos)
	{
		WorldParticle worldParticle = new WorldParticle();
		float spawnRadius = CerberusConfig.WorldParticles.SpawnRadius;
		int particleMode = CerberusConfig.WorldParticles.ParticleMode;
		worldParticle.qSsMVNoSDX = (randomPos ? (playerPos + new Vector2(irobustRandom_0.NextFloat(0f - spawnRadius, spawnRadius), irobustRandom_0.NextFloat(0f - spawnRadius, spawnRadius))) : playerPos);
		float speed = CerberusConfig.WorldParticles.Speed;
		float size = CerberusConfig.WorldParticles.Size;
		worldParticle.UMKM9bipB5 = irobustRandom_0.NextFloat(0f, (float)Math.PI * 2f);
		worldParticle.PJDMs8tJjS = irobustRandom_0.NextFloat(0.5f, 2.5f);
		worldParticle.RPwMCm3g8q = 0f;
		worldParticle.BNUMW8wxnl = irobustRandom_0.NextFloat(0.6f, 1f);
		worldParticle.SePMbphVKg = irobustRandom_0.NextFloat(0f, (float)Math.PI * 2f);
		worldParticle.akbMrXy9l7 = irobustRandom_0.NextFloat(-2f, 2f);
		float x = irobustRandom_0.NextFloat(0f, (float)Math.PI * 2f);
		worldParticle.dsDMawa8FQ = new Vector2(MathF.Cos(x), MathF.Sin(x)) * irobustRandom_0.NextFloat(0.2f, 0.6f) * speed;
		worldParticle.uxYMQbPnka = irobustRandom_0.NextFloat(0.08f, 0.18f) * size;
		worldParticle.Fx5MUTP4GU = irobustRandom_0.NextFloat(5f, 12f);
		worldParticle.KoNMDkVkLB = GetTextureForMode(particleMode);
		return worldParticle;
	}

	private Texture GetTextureForMode(int mode)
	{
		switch (mode)
		{
		case 5:
			return dictionary_0.GetValueOrDefault("bloom");
		case 0:
			if (list_1.Count <= 0)
			{
				return null;
			}
			return list_1[irobustRandom_0.Next(list_1.Count)];
		default:
			return null;
		case 1:
			if (list_2.Count > 0)
			{
				return list_2[irobustRandom_0.Next(list_2.Count)];
			}
			return null;
		case 4:
			return dictionary_0.GetValueOrDefault("swastika");
		case 3:
			if (list_4.Count <= 0)
			{
				return null;
			}
			return list_4[irobustRandom_0.Next(list_4.Count)];
		case 2:
			if (list_3.Count <= 0)
			{
				return null;
			}
			return list_3[irobustRandom_0.Next(list_3.Count)];
		}
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.WorldParticles.Enabled)
		{
			return;
		}
		if (!bool_1)
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
		Vector2 vector = new Vector2(worldPosition.X, worldPosition.Y);
		int particleMode = CerberusConfig.WorldParticles.ParticleMode;
		int num = Math.Min(CerberusConfig.WorldParticles.ParticleCount, 250);
		if (!bool_0 || int_1 != num || int_0 != particleMode)
		{
			InitializeParticles(vector);
		}
		DrawingHandleWorld worldHandle = ((OverlayDrawArgs)(ref args)).WorldHandle;
		_ = igameTiming_0.RealTime.TotalSeconds;
		float num2 = Math.Min((float)igameTiming_0.FrameTime.TotalSeconds, 0.033f);
		float opacity = CerberusConfig.WorldParticles.Opacity;
		float spawnRadius = CerberusConfig.WorldParticles.SpawnRadius;
		Color color = default(Color);
		for (int i = 0; i < list_0.Count; i++)
		{
			WorldParticle worldParticle = list_0[i];
			worldParticle.UMKM9bipB5 += worldParticle.PJDMs8tJjS * num2;
			worldParticle.RPwMCm3g8q += num2;
			worldParticle.SePMbphVKg += worldParticle.akbMrXy9l7 * num2;
			Vector2 vector2 = new Vector2(MathF.Sin(worldParticle.UMKM9bipB5) * 0.15f, MathF.Cos(worldParticle.UMKM9bipB5 * 0.7f) * 0.15f);
			worldParticle.qSsMVNoSDX += (worldParticle.dsDMawa8FQ + vector2) * num2;
			float num3 = Vector2.Distance(vector, worldParticle.qSsMVNoSDX);
			if (num3 <= spawnRadius && !(worldParticle.RPwMCm3g8q > worldParticle.Fx5MUTP4GU))
			{
				if (worldParticle.KoNMDkVkLB == null)
				{
					continue;
				}
				float num4 = worldParticle.RPwMCm3g8q / worldParticle.Fx5MUTP4GU;
				float num5 = worldParticle.BNUMW8wxnl * opacity;
				if (num4 >= 0.15f)
				{
					if (!(num4 <= 0.75f))
					{
						num5 *= (1f - num4) / 0.25f;
					}
				}
				else
				{
					num5 *= num4 / 0.15f;
				}
				float num6 = spawnRadius * 0.75f;
				if (!(num3 <= num6))
				{
					num5 *= 1f - (num3 - num6) / (spawnRadius - num6);
				}
				if (!(num5 <= 0.01f))
				{
					Vector4 particleColor = CerberusConfig.WorldParticles.ParticleColor;
					((Color)(ref color))._002Ector(particleColor.X, particleColor.Y, particleColor.Z, num5);
					DrawWorldParticle(worldHandle, worldParticle, color);
				}
			}
			else
			{
				list_0[i] = CreateParticle(vector, randomPos: true);
			}
		}
	}

	private void DrawWorldParticle(DrawingHandleWorld handle, WorldParticle p, Color color)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Box2 val = Box2.CenteredAround(p.qSsMVNoSDX, new Vector2(p.uxYMQbPnka, p.uxYMQbPnka));
			if (p.SePMbphVKg != 0f)
			{
				Matrix3x2 matrix3x = Matrix3x2.CreateRotation(p.SePMbphVKg, p.qSsMVNoSDX);
				((DrawingHandleBase)handle).SetTransform(ref matrix3x);
			}
			((DrawingHandleBase)handle).Modulate = color;
			handle.DrawTextureRect(p.KoNMDkVkLB, val, (Color?)Color.White);
			((DrawingHandleBase)handle).Modulate = Color.White;
			if (p.SePMbphVKg != 0f)
			{
				Matrix3x2 identity = Matrix3x2.Identity;
				((DrawingHandleBase)handle).SetTransform(ref identity);
			}
		}
		catch (Exception)
		{
		}
	}
}
