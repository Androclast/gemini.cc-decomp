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
using PositionBacktracker;

namespace ChamsOverlay;

public sealed class ChamsOverlay : Overlay
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IEyeManager ieyeManager_0;

	[Dependency]
	private readonly IEntitySystemManager ientitySystemManager_0;

	private SharedTransformSystem sharedTransformSystem_0;

	private MobStateSystem mobStateSystem_0;

	private PositionBacktracker gclass113_0;

	private int int_0;

	private string string_0;

	private bool bool_0;

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

	public ChamsOverlay()
	{
		IoCManager.InjectDependencies<ChamsOverlay>(this);
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0475: Unknown result type (might be due to invalid IL or missing references)
		//IL_047a: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0341: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Unknown result type (might be due to invalid IL or missing references)
		//IL_0368: Unknown result type (might be due to invalid IL or missing references)
		//IL_036d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0410: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0347: Unknown result type (might be due to invalid IL or missing references)
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0391: Unknown result type (might be due to invalid IL or missing references)
		//IL_0393: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.Backtrack.Enabled || !CerberusConfig.Backtrack.ShowVisuals)
		{
			return;
		}
		if (sharedTransformSystem_0 == null)
		{
			sharedTransformSystem_0 = ientityManager_0.System<SharedTransformSystem>();
			mobStateSystem_0 = ientityManager_0.System<MobStateSystem>();
			gclass113_0 = ientitySystemManager_0.GetEntitySystem<PositionBacktracker>();
		}
		if (gclass113_0 == null)
		{
			return;
		}
		DrawingHandleWorld worldHandle = ((OverlayDrawArgs)(ref args)).WorldHandle;
		float num = (float)igameTiming_0.RealTime.TotalSeconds;
		ShaderInstance val = null;
		val = (ShaderInstance)(CerberusConfig.Backtrack.VisualsMode switch
		{
			0 => ShaderDrawHelpers.ChamsFlatInstance, 
			6 => ShaderDrawHelpers.ChamsGlowInstance, 
			3 => ShaderDrawHelpers.ChamsMetallicInstance, 
			2 => ShaderDrawHelpers.ChamsGalaxyInstance, 
			5 => ShaderDrawHelpers.ChamsWireframeInstance, 
			4 => ShaderDrawHelpers.ChamsRainbowInstance, 
			1 => ShaderDrawHelpers.ChamsPulseInstance, 
			_ => ShaderDrawHelpers.ChamsFlatInstance, 
		});
		if (val == null)
		{
			return;
		}
		Vector4 visualsColor = CerberusConfig.Backtrack.VisualsColor;
		Color val2 = default(Color);
		((Color)(ref val2))._002Ector(visualsColor.X, visualsColor.Y, visualsColor.Z, visualsColor.W);
		val.SetParameter("color", val2);
		val.SetParameter("time", num);
		Angle rotation = ieyeManager_0.CurrentEye.Rotation;
		LocalPlayer localPlayer = iplayerManager_0.LocalPlayer;
		EntityUid? val3 = ((localPlayer == null) ? ((EntityUid?)null) : localPlayer.ControlledEntity);
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
			if ((val10.HasValue && val9 == val10.GetValueOrDefault()) || !gclass113_0.TryGetBacktrackPosition(val5, out var backtrackPosition))
			{
				continue;
			}
			var (vector, val11) = sharedTransformSystem_0.GetWorldPositionRotation(val8);
			if (!((Box2)(ref args.WorldAABB)).Contains(backtrackPosition, true))
			{
				continue;
			}
			Angle val12 = ((!val7.NoRotation) ? val11 : (-rotation));
			Matrix3x2 value = Matrix3Helpers.CreateTransform(ref backtrackPosition, ref val12);
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
				object obj;
				if (actualState == null)
				{
					obj = null;
				}
				else
				{
					obj = actualState.GetFrame(val16, val14.AnimationFrame);
					if (obj != null)
					{
						goto IL_0406;
					}
				}
				obj = texture;
				goto IL_0406;
				IL_0406:
				Texture val17 = (Texture)obj;
				if (val17 != null)
				{
					Vector2 scale2 = val14.Scale;
					offset = val14.Offset;
					val13 = Angle.Zero;
					Matrix3x2 matrix3x = Matrix3x2.Multiply(Matrix3Helpers.CreateTransform(ref offset, ref val13, ref scale2), value2);
					((DrawingHandleBase)worldHandle).SetTransform(ref matrix3x);
					Vector2 vector2 = Vector2i.op_Implicit(val17.Size) / 32f;
					Box2 val18 = Box2.FromDimensions(-vector2 / 2f, vector2);
					worldHandle.DrawTextureRect(val17, val18, (Color?)Color.White);
				}
			}
			((DrawingHandleBase)worldHandle).UseShader((ShaderInstance)null);
			Matrix3x2 identity = Matrix3x2.Identity;
			((DrawingHandleBase)worldHandle).SetTransform(ref identity);
			if (CerberusConfig.Backtrack.ShowLine)
			{
				((DrawingHandleBase)worldHandle).DrawLine(vector, backtrackPosition, val2);
			}
		}
	}
}
