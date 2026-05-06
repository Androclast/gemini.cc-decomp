using Robust.Client.Graphics;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using PlayerEspOverlay;
using LightSmoothOverlay;
using GrenadeHelperOverlay;
using HitMarkerOverlay;
using AccessInfoOverlay;
using AnomalyInfoOverlay;
using PlayerArrowsOverlay;
using DamageBreakdownOverlay;
using EntityHitboxOverlay;
using HitParticlesOverlay;
using MobArrowsOverlay;
using StepTriggerEspOverlay;
using TurretEspOverlay;
using TracersOverlay;
using MobStatusOverlay;
using MinecraftVisualsOverlay;
using PlayerGlowOverlay;
using SpiritsOverlay;
using BloomTrailOverlay;
using WorldParticlesOverlay;

public sealed class OverlayRegistration : EntitySystem
{
	[Dependency]
	private readonly IOverlayManager ioverlayManager_0;

	[Dependency]
	private readonly IEntityManager ientityManager_0;

	private readonly AimbotRenderOverlay gclass9_0 = new AimbotRenderOverlay();

	private readonly MagazineEspOverlay gclass10_0 = new MagazineEspOverlay();

	private readonly MeleeAimbotOverlay gclass12_0 = new MeleeAimbotOverlay();

	private readonly GunRangeOverlay gclass30_0 = new GunRangeOverlay();

	private readonly DamageVisualOverlay gclass35_0 = new DamageVisualOverlay();

	private readonly TextureEspOverlay gclass37_0 = new TextureEspOverlay();

	private readonly StorageContentEspOverlay gclass36_0 = new StorageContentEspOverlay();

	private readonly AccessInfoOverlay gclass219_0 = new AccessInfoOverlay();

	private readonly HitMarkerOverlay gclass217_0 = new HitMarkerOverlay();

	private readonly GenericCachedEspOverlay gclass33_0 = new GenericCachedEspOverlay();

	private readonly GrenadeHelperOverlay gclass216_0 = new GrenadeHelperOverlay();

	private readonly GenericInputOverlay gclass38_0 = new GenericInputOverlay();

	private HealthBarOverlay gclass32_0;

	private readonly LightSmoothOverlay gclass215_0 = new LightSmoothOverlay();

	private readonly SpiritsOverlay gclass121_0 = new SpiritsOverlay();

	private readonly AutoPickupOverlay gclass24_0 = new AutoPickupOverlay();

	private readonly AimbotCircleOverlay gclass17_0 = new AimbotCircleOverlay();

	private readonly MobStatusOverlay gclass117_0 = new MobStatusOverlay();

	private readonly MinecraftVisualsOverlay gclass118_0 = new MinecraftVisualsOverlay();

	private readonly WorldParticlesOverlay gclass123_0 = new WorldParticlesOverlay();

	private readonly BloomTrailOverlay gclass122_0 = new BloomTrailOverlay();

	private readonly PlayerGlowOverlay gclass120_0 = new PlayerGlowOverlay();

	private readonly MobArrowsOverlay gclass234_0 = new MobArrowsOverlay();

	private readonly DamageBreakdownOverlay gclass226_0 = new DamageBreakdownOverlay();

	private readonly EntityHitboxOverlay gclass228_0 = new EntityHitboxOverlay();

	private readonly AnomalyInfoOverlay gclass220_0 = new AnomalyInfoOverlay();

	private readonly HitParticlesOverlay gclass229_0 = new HitParticlesOverlay();

	private readonly PlayerArrowsOverlay gclass225_0 = new PlayerArrowsOverlay();

	private readonly TracersOverlay gclass269_0 = new TracersOverlay();

	private readonly PlayerEspOverlay gclass97_0 = new PlayerEspOverlay();

	private readonly TurretEspOverlay gclass236_0 = new TurretEspOverlay();

	private readonly StepTriggerEspOverlay gclass235_0 = new StepTriggerEspOverlay();

	private byte byte_0;

	private char char_0;

	private byte byte_1;

	private byte byte_2;

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

	private byte Byte_1
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

	private byte Byte_2
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

	public override void Initialize()
	{
		gclass32_0 = new HealthBarOverlay(ientityManager_0);
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass32_0);
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass9_0);
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass10_0);
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass12_0);
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass30_0);
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass35_0);
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass37_0);
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass36_0);
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass219_0);
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass217_0);
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass33_0);
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass38_0);
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass215_0);
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass121_0);
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass24_0);
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass17_0);
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass216_0);
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass117_0);
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass118_0);
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass123_0);
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass122_0);
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass120_0);
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass234_0);
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass226_0);
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass228_0);
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass220_0);
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass229_0);
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass225_0);
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass269_0);
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass97_0);
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass236_0);
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass235_0);
	}

	public override void Shutdown()
	{
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass32_0);
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass9_0);
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass10_0);
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass12_0);
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass30_0);
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass35_0);
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass37_0);
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass36_0);
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass219_0);
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass217_0);
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass33_0);
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass38_0);
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass215_0);
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass121_0);
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass24_0);
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass17_0);
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass216_0);
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass117_0);
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass118_0);
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass123_0);
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass122_0);
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass120_0);
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass234_0);
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass226_0);
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass228_0);
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass220_0);
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass229_0);
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass225_0);
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass269_0);
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass97_0);
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass236_0);
		ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass235_0);
	}

	private string method_6(int int_0, double double_1, byte byte_3)
	{
		return "Хитролох_иди_нахуй.__37______________1__";
	}
}
