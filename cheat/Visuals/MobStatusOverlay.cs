using System.Numerics;
using Content.Shared.Mobs.Components;
using Content.Shared.Mobs.Systems;
using Robust.Client.GameObjects;
using Robust.Client.Graphics;
using Robust.Client.Player;
using Robust.Client.Utility;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.Graphics.RSI;
using Robust.Shared.IoC;
using Robust.Shared.Maths;
using Robust.Shared.Timing;
using ShaderDrawHelpers;
using CerberusConfig;

namespace MobStatusOverlay;

public sealed class MobStatusOverlay : Overlay
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IEyeManager ieyeManager_0;

	private SharedTransformSystem sharedTransformSystem_0;

	private MobStateSystem mobStateSystem_0;

	private int int_0;

	private byte byte_0;

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

	public MobStatusOverlay()
	{
		IoCManager.InjectDependencies<MobStatusOverlay>(this);
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_047b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_03df: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_037f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0399: Unknown result type (might be due to invalid IL or missing references)
		//IL_039e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0352: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.Chams.Enabled)
		{
			return;
		}
		if (sharedTransformSystem_0 == null)
		{
			sharedTransformSystem_0 = ientityManager_0.System<SharedTransformSystem>();
			mobStateSystem_0 = ientityManager_0.System<MobStateSystem>();
		}
		DrawingHandleWorld worldHandle = ((OverlayDrawArgs)(ref args)).WorldHandle;
		float num = (float)igameTiming_0.RealTime.TotalSeconds;
		ShaderInstance val = null;
		val = (ShaderInstance)(CerberusConfig.Chams.Mode switch
		{
			6 => ShaderDrawHelpers.ChamsGlowInstance, 
			3 => ShaderDrawHelpers.ChamsMetallicInstance, 
			2 => ShaderDrawHelpers.ChamsGalaxyInstance, 
			0 => ShaderDrawHelpers.ChamsFlatInstance, 
			1 => ShaderDrawHelpers.ChamsPulseInstance, 
			4 => ShaderDrawHelpers.ChamsRainbowInstance, 
			5 => ShaderDrawHelpers.ChamsWireframeInstance, 
			_ => ShaderDrawHelpers.ChamsFlatInstance, 
		});
		if (val == null)
		{
			return;
		}
		Vector4 color = CerberusConfig.Chams.Color;
		Color val2 = default(Color);
		((Color)(ref val2))._002Ector(color.X, color.Y, color.Z, color.W);
		val.SetParameter("color", val2);
		val.SetParameter("time", num);
		Angle rotation = ieyeManager_0.CurrentEye.Rotation;
		LocalPlayer localPlayer = iplayerManager_0.LocalPlayer;
		EntityUid? val3 = ((localPlayer != null) ? localPlayer.ControlledEntity : ((EntityUid?)null));
		AllEntityQueryEnumerator<MobStateComponent, SpriteComponent, TransformComponent> val4 = ientityManager_0.AllEntityQueryEnumerator<MobStateComponent, SpriteComponent, TransformComponent>();
		EntityUid val5 = default(EntityUid);
		MobStateComponent val6 = default(MobStateComponent);
		SpriteComponent val7 = default(SpriteComponent);
		TransformComponent val8 = default(TransformComponent);
		while (val4.MoveNext(ref val5, ref val6, ref val7, ref val8))
		{
			if (val8.MapID != args.MapId || mobStateSystem_0.IsDead(val5, val6))
			{
				continue;
			}
			EntityUid val9 = val5;
			EntityUid? val10 = val3;
			if (val10.HasValue && val9 == val10.GetValueOrDefault() && !CerberusConfig.Chams.ShowOnLocalPlayer)
			{
				continue;
			}
			Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(val8);
			if (!((Box2)(ref args.WorldAABB)).Contains(worldPosition, true))
			{
				continue;
			}
			var (vector, val11) = sharedTransformSystem_0.GetWorldPositionRotation(val8);
			_ = val11 + rotation;
			Angle val12 = (val7.NoRotation ? (-rotation) : val11);
			Matrix3x2 value = Matrix3Helpers.CreateTransform(ref vector, ref val12);
			Vector2 offset = val7.Offset;
			Angle val13 = val7.Rotation;
			Vector2 scale = val7.Scale;
			Matrix3x2 value2 = Matrix3x2.Multiply(Matrix3Helpers.CreateTransform(ref offset, ref val13, ref scale), value);
			((DrawingHandleBase)worldHandle).UseShader(val);
			foreach (ISpriteLayer allLayer in val7.AllLayers)
			{
				if (!allLayer.Visible)
				{
					continue;
				}
				Layer val14 = (Layer)(object)((allLayer is Layer) ? allLayer : null);
				if (val14 == null)
				{
					continue;
				}
				State actualState = val14.ActualState;
				Texture texture = val14.Texture;
				val13 = val11 + rotation;
				val13 = ((Angle)(ref val13)).Reduced();
				Angle val15 = ((Angle)(ref val13)).FlipPositive();
				RsiDirection val16 = (RsiDirection)((actualState != null) ? ((int)Layer.GetDirection(actualState.RsiDirections, val15)) : 0);
				val16 = DirExt.OffsetRsiDir(val16, val14.DirOffset);
				Texture val17 = ((actualState == null) ? texture : (actualState.GetFrame(val16, val14.AnimationFrame) ?? texture));
				if (val17 != null && val17.Size.X != 0 && val17.Size.Y != 0)
				{
					Vector2 vector2 = Vector2i.op_Implicit(val17.Size) / 32f;
					if (!(vector2.X <= 0f) && !(vector2.Y <= 0f))
					{
						Vector2 scale2 = val14.Scale;
						offset = val14.Offset;
						val13 = Angle.Zero;
						Matrix3x2 matrix3x = Matrix3x2.Multiply(Matrix3Helpers.CreateTransform(ref offset, ref val13, ref scale2), value2);
						((DrawingHandleBase)worldHandle).SetTransform(ref matrix3x);
						Box2 val18 = Box2.FromDimensions(-vector2 / 2f, vector2);
						worldHandle.DrawTextureRect(val17, val18, (Color?)Color.White);
					}
				}
			}
			((DrawingHandleBase)worldHandle).UseShader((ShaderInstance)null);
			Matrix3x2 identity = Matrix3x2.Identity;
			((DrawingHandleBase)worldHandle).SetTransform(ref identity);
		}
	}
}
