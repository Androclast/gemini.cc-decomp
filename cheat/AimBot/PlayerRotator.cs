using System.Numerics;
using System.Runtime.CompilerServices;
using Content.Shared.MouseRotator;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Maths;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using CerberusConfig;

[CompilerGenerated]
public class PlayerRotator : EntitySystem
{
	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly SharedTransformSystem sharedTransformSystem_0;

	private float float_0;

	private char char_0;

	private char char_1;

	private int int_0;

	private double double_1;

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

	private char Char_1
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

	public override void Update(float frameTime)
	{
		if (igameTiming_0.IsFirstTimePredicted && CerberusConfig.Misc.AntiAimEnabled)
		{
			EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
			MouseRotatorComponent val = default(MouseRotatorComponent);
			if (localEntity.HasValue && ((EntitySystem)this).TryComp<MouseRotatorComponent>(localEntity, ref val))
			{
				RotatePlayer(frameTime);
			}
		}
	}

	public void RotateToTarget(Vector2 targetPosition)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		if (igameTiming_0.IsFirstTimePredicted)
		{
			EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
			MouseRotatorComponent val = default(MouseRotatorComponent);
			if (localEntity.HasValue && ((EntitySystem)this).TryComp<MouseRotatorComponent>(localEntity, ref val))
			{
				Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(localEntity.Value);
				Angle targetRotation = DirectionExtensions.ToWorldAngle(targetPosition - worldPosition);
				SendRotationEvent(targetRotation);
			}
		}
	}

	private void RotatePlayer(float frameTime)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		float autoRotateSpeed = CerberusConfig.Misc.AutoRotateSpeed;
		if (float_0 + autoRotateSpeed * frameTime > 360f)
		{
			float_0 = 0f;
		}
		float_0 += autoRotateSpeed * frameTime;
		Angle targetRotation = Angle.FromDegrees((double)float_0);
		SendRotationEvent(targetRotation);
	}

	private void SendRotationEvent(Angle targetRotation)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (localEntity.HasValue)
		{
			((EntitySystem)this).RaisePredictiveEvent<RequestMouseRotatorRotationEvent>(new RequestMouseRotatorRotationEvent
			{
				Rotation = targetRotation,
				User = ((EntitySystem)this).GetNetEntity(localEntity.Value, (MetaDataComponent)null)
			});
		}
	}
}
