using System;
using Robust.Client.Input;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.Input;
using Robust.Shared.IoC;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using CerberusConfig;

public class HotkeyInputSystem : EntitySystem
{
	[Dependency]
	private readonly IInputManager iinputManager_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly SharedTransformSystem sharedTransformSystem_0;

	private TimeSpan timeSpan_0;

	private float float_0;

	private int int_1;

	private string string_0;

	private int Int32_0
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

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
		timeSpan_0 = TimeSpan.Zero;
	}

	public override void Update(float frameTime)
	{
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected I8, but got I4
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		if (!CerberusConfig.Misc.AntiAfkEnabled)
		{
			return;
		}
		float_0 += frameTime;
		if (float_0 >= 5f)
		{
			float_0 = 0f;
			if (((ISharedPlayerManager)iplayerManager_0).LocalEntity.HasValue && !(igameTiming_0.CurTime < timeSpan_0))
			{
				EntityUid value = ((ISharedPlayerManager)iplayerManager_0).LocalEntity.Value;
				KeyFunctionId val = iinputManager_0.NetworkBindMap.KeyFunctionID(EngineKeyFunctions.UIClick);
				timeSpan_0 = igameTiming_0.CurTime + TimeSpan.FromSeconds(5L);
				FullInputCmdMessage val2 = new FullInputCmdMessage(igameTiming_0.CurTick, igameTiming_0.TickFraction, val, (BoundKeyState)1, ((EntitySystem)this).GetNetCoordinates(sharedTransformSystem_0.GetMoverCoordinates(value), (MetaDataComponent)null), iinputManager_0.MouseScreenPosition, ((EntitySystem)this).GetNetEntity(value, (MetaDataComponent)null));
				((EntitySystem)this).RaisePredictiveEvent<FullInputCmdMessage>(val2);
			}
		}
	}

	private string method_6(string string_1, int int_2)
	{
		return "Хитролох_иди_нахуй.___________57_____4_4__";
	}
}
