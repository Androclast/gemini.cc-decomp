using System;
using System.Numerics;
using Robust.Client.Graphics;
using Robust.Client.Input;
using Robust.Shared.GameObjects;
using Robust.Shared.Graphics;
using Robust.Shared.IoC;
using CerberusConfig;

namespace ZoomController;

public sealed class ZoomController : EntitySystem
{
	[Dependency]
	private readonly IEyeManager ieyeManager_0;

	[Dependency]
	private readonly IInputManager iinputManager_0;

	private Vector2 vector2_0 = Vector2.Zero;

	private Vector2 vector2_1 = Vector2.Zero;

	private bool bool_0;

	private float float_0 = 1f;

	private bool bool_1;

	private bool bool_2;

	private long long_1;

	private string string_1;

	private long Int64_0
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

	public override void Update(float frameTime)
	{
		((EntitySystem)this).Update(frameTime);
		if (CerberusConfig.FreeCam.Enabled)
		{
			if (!bool_0)
			{
				Enable();
			}
			Vector2 vector = Vector2.Zero;
			if (iinputManager_0.IsKeyDown((Key)32) || iinputManager_0.IsKeyDown((Key)92))
			{
				vector.Y += 1f;
			}
			if (iinputManager_0.IsKeyDown((Key)28) || iinputManager_0.IsKeyDown((Key)93))
			{
				vector.Y -= 1f;
			}
			if (iinputManager_0.IsKeyDown((Key)10) || iinputManager_0.IsKeyDown((Key)90))
			{
				vector.X -= 1f;
			}
			if (iinputManager_0.IsKeyDown((Key)13) || iinputManager_0.IsKeyDown((Key)91))
			{
				vector.X += 1f;
			}
			if (vector.LengthSquared() > 1f)
			{
				vector = Vector2.Normalize(vector);
			}
			float num = ((!iinputManager_0.IsKeyDown((Key)58)) ? CerberusConfig.FreeCam.Speed : (CerberusConfig.FreeCam.Speed * 3f));
			vector2_1 += vector * num * frameTime;
			float amount = Math.Clamp(Math.Clamp(CerberusConfig.FreeCam.Smoothing, 0.1f, 10f) * frameTime * 10f, 0f, 1f);
			vector2_0 = Vector2.Lerp(vector2_0, vector2_1, amount);
			if (vector2_0.LengthSquared() > 1000000f)
			{
				vector2_0 = Vector2.Normalize(vector2_0) * 1000f;
				vector2_1 = vector2_0;
			}
			ApplyEyeOffset();
			HandleZoomControls(frameTime);
		}
		else if (bool_0)
		{
			Disable();
		}
	}

	private void Enable()
	{
		vector2_0 = Vector2.Zero;
		vector2_1 = Vector2.Zero;
		bool_0 = true;
	}

	private void Disable()
	{
		vector2_0 = Vector2.Zero;
		vector2_1 = Vector2.Zero;
		ApplyEyeOffset();
		bool_0 = false;
	}

	private void ApplyEyeOffset()
	{
		IEye currentEye = ieyeManager_0.CurrentEye;
		if (currentEye != null)
		{
			currentEye.Offset = new Vector2(vector2_0.X, vector2_0.Y);
			currentEye.Zoom = new Vector2(float_0, float_0);
		}
	}

	private void HandleZoomControls(float frameTime)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		bool flag = (int)CerberusConfig.Eye.ZoomUpHotKey != 0 && KeyStateHelper.IsKeyDown(CerberusConfig.Eye.ZoomUpHotKey);
		bool flag2 = (int)CerberusConfig.Eye.ZoomDownHotKey != 0 && KeyStateHelper.IsKeyDown(CerberusConfig.Eye.ZoomDownHotKey);
		if (flag && !bool_1)
		{
			float_0 = Math.Clamp(float_0 + 0.1f, 0.5f, 3f);
		}
		if (flag2 && !bool_2)
		{
			float_0 = Math.Clamp(float_0 - 0.1f, 0.5f, 3f);
		}
		bool_1 = flag;
		bool_2 = flag2;
	}
}
