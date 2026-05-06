using System;
using System.Collections.Generic;
using System.Numerics;
using Robust.Client.Graphics;
using Robust.Shared.Enums;
using Robust.Shared.IoC;
using Robust.Shared.Maths;
using Robust.Shared.Random;
using Robust.Shared.Timing;
using TextureLoader;
using CerberusConfig;

namespace HitParticlesOverlay;

public sealed class HitParticlesOverlay : Overlay
{
	private class HitParticle
	{
		public Vector2 rIP2saRWg8;

		public Vector2 imd2bmpoFr;

		public float qvs2rJACVy;

		public TimeSpan VTx2D4NQjc;

		public float Wrv2uCDUHm;

		public float yOe2AuLMty;

		public float RBc2LBmgoO;

		public Texture xSC2FO6Fqt;

		private int int_0;

		private float float_1;

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
	}

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly IRobustRandom irobustRandom_0;

	private readonly List<HitParticle> list_0 = new List<HitParticle>();

	private readonly Dictionary<string, Texture> dictionary_0 = new Dictionary<string, Texture>();

	private bool bool_0;

	private readonly List<Texture> list_1 = new List<Texture>();

	private readonly List<Texture> list_2 = new List<Texture>();

	private readonly List<Texture> list_3 = new List<Texture>();

	private readonly List<Texture> list_4 = new List<Texture>();

	private byte byte_1;

	private long long_0;

	private long long_1;

	private bool bool_3;

	public override OverlaySpace Space => (OverlaySpace)4;

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

	private bool Boolean_0
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public HitParticlesOverlay()
	{
		IoCManager.InjectDependencies<HitParticlesOverlay>(this);
		((Overlay)this).ZIndex = 200;
	}

	private void LoadTextures()
	{
		if (bool_0)
		{
			return;
		}
		try
		{
			dictionary_0["amongus"] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.particles.amongus.png", "amongus");
			dictionary_0["star"] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.particles.star.png", "star");
			dictionary_0["pumpkin"] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.particles.pumpkin.png", "pumpkin");
			dictionary_0["crown"] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.particles.crown.png", "crown");
			dictionary_0["dead"] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.particles.dead.png", "dead");
			dictionary_0["dollar"] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.particles.dollar.png", "dollar");
			dictionary_0["heart"] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.particles.heart.png", "heart");
			dictionary_0["light"] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.particles.light.png", "light");
			dictionary_0["polygon"] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.particles.polygon.png", "polygon");
			dictionary_0["rhombus"] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.particles.rhombus.png", "rhombus");
			dictionary_0["snow"] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.particles.snow.png", "snow");
			dictionary_0["swastika"] = TextureLoader.LoadTexture("Kaban.cc.Resources.Visuals.particles.svastun.png", "swastika");
			for (int i = 1; i <= 11; i++)
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
			bool_0 = true;
		}
		catch (Exception)
		{
		}
	}

	public void SpawnParticles(Vector2 worldPos)
	{
		if (!CerberusConfig.HitParticles.Enabled)
		{
			return;
		}
		if (!bool_0)
		{
			LoadTextures();
		}
		int particleCount = CerberusConfig.HitParticles.ParticleCount;
		TimeSpan curTime = igameTiming_0.CurTime;
		int particleMode = CerberusConfig.HitParticles.ParticleMode;
		for (int i = 0; i < particleCount; i++)
		{
			float num = (float)(irobustRandom_0.NextDouble() * Math.PI * 2.0);
			float num2 = (float)(irobustRandom_0.NextDouble() * 3.0 + 1.0);
			Vector2 imd2bmpoFr = new Vector2((float)Math.Cos(num) * num2, (float)Math.Sin(num) * num2);
			float num3 = 0.15f * CerberusConfig.HitParticles.ParticleSize;
			float qvs2rJACVy = (float)(irobustRandom_0.NextDouble() * (double)num3 + (double)(num3 * 0.5f));
			float yOe2AuLMty = (float)(irobustRandom_0.NextDouble() * Math.PI * 2.0);
			float rBc2LBmgoO = (float)(irobustRandom_0.NextDouble() * 10.0 - 5.0);
			Texture textureForMode = GetTextureForMode(particleMode);
			if (textureForMode != null)
			{
				list_0.Add(new HitParticle
				{
					rIP2saRWg8 = worldPos,
					imd2bmpoFr = imd2bmpoFr,
					qvs2rJACVy = qvs2rJACVy,
					VTx2D4NQjc = curTime,
					Wrv2uCDUHm = CerberusConfig.HitParticles.ParticleLifetime,
					yOe2AuLMty = yOe2AuLMty,
					RBc2LBmgoO = rBc2LBmgoO,
					xSC2FO6Fqt = textureForMode
				});
			}
		}
	}

	private Texture GetTextureForMode(int mode)
	{
		switch (mode)
		{
		case 15:
			return dictionary_0.GetValueOrDefault("swastika");
		case 0:
			if (list_1.Count <= 0)
			{
				return null;
			}
			return list_1[irobustRandom_0.Next(list_1.Count)];
		case 3:
			if (list_4.Count > 0)
			{
				return list_4[irobustRandom_0.Next(list_4.Count)];
			}
			return null;
		default:
			return null;
		case 2:
			if (list_3.Count <= 0)
			{
				return null;
			}
			return list_3[irobustRandom_0.Next(list_3.Count)];
		case 1:
			if (list_2.Count <= 0)
			{
				return null;
			}
			return list_2[irobustRandom_0.Next(list_2.Count)];
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
		}
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		if (!CerberusConfig.HitParticles.Enabled || list_0.Count == 0)
		{
			return;
		}
		DrawingHandleWorld worldHandle = ((OverlayDrawArgs)(ref args)).WorldHandle;
		TimeSpan curTime = igameTiming_0.CurTime;
		float num = (float)igameTiming_0.FrameTime.TotalSeconds;
		for (int num2 = list_0.Count - 1; num2 >= 0; num2--)
		{
			HitParticle hitParticle = list_0[num2];
			float num3 = (float)(curTime - hitParticle.VTx2D4NQjc).TotalSeconds;
			if (num3 <= hitParticle.Wrv2uCDUHm)
			{
				hitParticle.imd2bmpoFr *= 0.96f;
				hitParticle.imd2bmpoFr += new Vector2(0f, -3f * num);
				hitParticle.rIP2saRWg8 += hitParticle.imd2bmpoFr * num;
				hitParticle.yOe2AuLMty += hitParticle.RBc2LBmgoO * num;
				float num4 = num3 / hitParticle.Wrv2uCDUHm;
				float alpha = (float)Math.Pow(1f - num4, 1.5) * CerberusConfig.HitParticles.Opacity;
				float num5 = ((num4 >= 0.2f) ? (1f - (num4 - 0.2f) * 0.6f) : (0.5f + num4 * 2.5f));
				float size = hitParticle.qvs2rJACVy * num5;
				DrawParticle(worldHandle, hitParticle, size, alpha);
			}
			else
			{
				list_0.RemoveAt(num2);
			}
		}
	}

	private void DrawParticle(DrawingHandleWorld handle, HitParticle particle, float size, float alpha)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Vector4 particleColor = CerberusConfig.HitParticles.ParticleColor;
			Color val = default(Color);
			((Color)(ref val))._002Ector(particleColor.X, particleColor.Y, particleColor.Z, alpha);
			if (particle.xSC2FO6Fqt != null)
			{
				Box2 val2 = Box2.CenteredAround(particle.rIP2saRWg8, new Vector2(size, size));
				if (particle.yOe2AuLMty != 0f)
				{
					Matrix3x2 matrix3x = Matrix3x2.CreateRotation(particle.yOe2AuLMty, particle.rIP2saRWg8);
					((DrawingHandleBase)handle).SetTransform(ref matrix3x);
				}
				((DrawingHandleBase)handle).Modulate = val;
				handle.DrawTextureRect(particle.xSC2FO6Fqt, val2, (Color?)Color.White);
				((DrawingHandleBase)handle).Modulate = Color.White;
				if (particle.yOe2AuLMty != 0f)
				{
					Matrix3x2 identity = Matrix3x2.Identity;
					((DrawingHandleBase)handle).SetTransform(ref identity);
				}
			}
			else
			{
				((DrawingHandleBase)handle).DrawCircle(particle.rIP2saRWg8, size, val, true);
			}
		}
		catch (Exception)
		{
		}
	}

	private string method_4(char char_0, bool bool_4, string string_0)
	{
		return "Хитролох_иди_нахуй._5__49___5____2_4_______";
	}
}
