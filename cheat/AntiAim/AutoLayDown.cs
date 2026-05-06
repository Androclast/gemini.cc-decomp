using System;
using System.Collections.Generic;
using System.Numerics;
using Content.Shared.Hands.Components;
using Content.Shared.Standing;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Network;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using CerberusConfig;

namespace AutoLayDown;

public sealed class AutoLayDown : EntitySystem
{
	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly SharedTransformSystem sharedTransformSystem_0;

	[Dependency]
	private readonly IClientNetManager iclientNetManager_0;

	[Dependency]
	private readonly StandingStateSystem standingStateSystem_0;

	private TimeSpan timeSpan_0 = TimeSpan.Zero;

	private bool bool_0;

	private DateTime dateTime_0 = DateTime.MinValue;

	private long long_1;

	private long long_2;

	private float float_0;

	private string string_0;

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

	private long Int64_1
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

	public override void FrameUpdate(float frameTime)
	{
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		((EntitySystem)this).FrameUpdate(frameTime);
		if (CerberusConfig.Combat.AutoLaydownEnabled)
		{
			ICommonSession localSession = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
			EntityUid? val = ((localSession == null) ? ((EntityUid?)null) : localSession.AttachedEntity);
			if (val.HasValue)
			{
				DateTime utcNow = DateTime.UtcNow;
				if (!((utcNow - dateTime_0).TotalSeconds < 5.0))
				{
					_ = HudUpdateSystem.list_0?.Count;
					dateTime_0 = utcNow;
				}
				if (!DetectIncomingProjectiles(val.Value))
				{
					float autoLaydownStandUpDelay = CerberusConfig.Combat.AutoLaydownStandUpDelay;
					if (bool_0 && !((igameTiming_0.CurTime - timeSpan_0).TotalSeconds < (double)autoLaydownStandUpDelay))
					{
						TryStandUp();
					}
				}
				else
				{
					timeSpan_0 = igameTiming_0.CurTime;
					if (!bool_0)
					{
						TryLayDown(val.Value);
					}
				}
			}
			else
			{
				bool_0 = false;
			}
		}
		else if (bool_0)
		{
			TryStandUp();
		}
	}

	private bool DetectIncomingProjectiles(EntityUid playerUid)
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		List<(Vector2, Vector2, Vector2)> list_ = HudUpdateSystem.list_0;
		int count = list_.Count;
		if (count != 0)
		{
			TransformComponent component = ientityManager_0.GetComponent<TransformComponent>(playerUid);
			Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(component);
			float x = worldPosition.X;
			float y = worldPosition.Y;
			INetChannel serverChannel = iclientNetManager_0.ServerChannel;
			float num = (float)((serverChannel != null) ? serverChannel.Ping : 0) / 1000f + 0.15f;
			for (int i = 0; i < count; i++)
			{
				(Vector2, Vector2, Vector2) tuple = list_[i];
				float x2 = tuple.Item3.X;
				float y2 = tuple.Item3.Y;
				if (!(x2 * x2 + y2 * y2 >= 25f))
				{
					continue;
				}
				float num2 = x - tuple.Item1.X;
				float num3 = y - tuple.Item1.Y;
				if (num2 * x2 + num3 * y2 < 0f)
				{
					continue;
				}
				float num4 = tuple.Item1.X + x2 * num;
				float num5 = tuple.Item1.Y + y2 * num;
				float num6 = x - num4;
				float num7 = y - num5;
				float num8 = x2 * x2 + y2 * y2;
				if (!(num8 <= 0.0001f))
				{
					float num9 = (num6 * x2 + num7 * y2) / num8;
					float num10 = num4 + x2 * num9;
					float num11 = num5 + y2 * num9;
					if ((x - num10) * (x - num10) + (y - num11) * (y - num11) < 0.81f && num9 > -0.2f && num6 * num6 + num7 * num7 < 225f)
					{
						return true;
					}
				}
			}
			return false;
		}
		return false;
	}

	private void TryLayDown(EntityUid playerUid)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		StandingStateComponent val = default(StandingStateComponent);
		if (ientityManager_0.TryGetComponent<StandingStateComponent>(playerUid, ref val))
		{
			if (val.Standing)
			{
				standingStateSystem_0.Down(playerUid, false, false, false, (StandingStateComponent)null, (AppearanceComponent)null, (HandsComponent)null);
				bool_0 = true;
			}
			else
			{
				bool_0 = true;
			}
		}
	}

	private void TryStandUp()
	{
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		ICommonSession localSession = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
		EntityUid? val = ((localSession != null) ? localSession.AttachedEntity : ((EntityUid?)null));
		StandingStateComponent val2 = default(StandingStateComponent);
		if (!val.HasValue)
		{
			bool_0 = false;
		}
		else if (!ientityManager_0.TryGetComponent<StandingStateComponent>(val.Value, ref val2))
		{
			bool_0 = false;
		}
		else if (!val2.Standing)
		{
			standingStateSystem_0.Stand(val.Value, (StandingStateComponent)null, (AppearanceComponent)null, false);
			bool_0 = false;
		}
		else
		{
			bool_0 = false;
		}
	}
}
