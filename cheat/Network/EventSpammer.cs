using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CerberusWareV3.Features.Utility;
using Content.Shared.Interaction;
using Content.Shared.Movement.Events;
using Content.Shared.Movement.Pulling.Events;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Log;
using EventLogEntry;
using CerberusConfig;
using Хитролох_иди_нахуй._____1___9_1____1____.Хитролох_иди_нахуй;

namespace EventSpammer;

public sealed class EventSpammer : EntitySystem
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	private ISawmill isawmill_0;

	private CancellationTokenSource? cancellationTokenSource_0;

	private Task? task_0;

	private bool bool_0;

	private int int_0;

	private Random random_0 = new Random();

	public static List<EventLogEntry> list_0 = new List<EventLogEntry>();

	private static int int_1 = 1;

	private float float_0;

	private bool bool_2;

	private double double_1;

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

	private bool Boolean_0
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
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

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
		isawmill_0 = Logger.GetSawmill("EventSpammer");
		isawmill_0.Info("EventSpammerSystem initialized");
	}

	public void StartEventSpam()
	{
		if (!bool_0)
		{
			isawmill_0.Info("Starting EventSpammer...");
			bool_0 = true;
			int_0 = 0;
			cancellationTokenSource_0 = new CancellationTokenSource();
			task_0 = Task.Run([AsyncStateMachine(typeof(_003C_003CStartEventSpam_003Eb__12_0_003Ed))] () =>
			{
				_003C_003CStartEventSpam_003Eb__12_0_003Ed stateMachine = default(_003C_003CStartEventSpam_003Eb__12_0_003Ed);
				stateMachine._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
				stateMachine._003C_003E4__this = this;
				stateMachine._003C_003E1__state = -1;
				stateMachine._003C_003Et__builder.Start(ref stateMachine);
				return stateMachine._003C_003Et__builder.Task;
			});
			isawmill_0.Info("EventSpammer started successfully");
		}
		else
		{
			isawmill_0.Warning("EventSpammer already running");
		}
	}

	public void StopEventSpam()
	{
		if (!bool_0)
		{
			isawmill_0.Warning("EventSpammer not running");
			return;
		}
		isawmill_0.Info("Stopping EventSpammer...");
		bool_0 = false;
		cancellationTokenSource_0?.Cancel();
		task_0?.Wait(1000);
		cancellationTokenSource_0?.Dispose();
		cancellationTokenSource_0 = null;
		task_0 = null;
		isawmill_0.Info($"EventSpammer stopped. Total events sent: {int_0}");
	}

	private async Task SpamLoop(CancellationToken token)
	{
		isawmill_0.Info("SpamLoop started");
		while (!token.IsCancellationRequested && bool_0)
		{
			try
			{
				List<GEnum7> F482GZh7jh = GetActiveEventTypes();
				if (F482GZh7jh.Count == 0)
				{
					await Task.Delay(100, token);
					continue;
				}
				int num = ((!CerberusConfig.EventSpammer.BurstMode) ? 1 : CerberusConfig.EventSpammer.BurstSize);
				if (!CerberusConfig.EventSpammer.ParallelMode || F482GZh7jh.Count <= 0)
				{
					for (int i = 0; i < num; i++)
					{
						if (token.IsCancellationRequested)
						{
							break;
						}
						GEnum7 gEnum = F482GZh7jh[random_0.Next(F482GZh7jh.Count)];
						SendEvent((int)gEnum);
						int_0++;
					}
				}
				else
				{
					Parallel.For(0, num, (Action<int>)delegate
					{
						//IL_0069: Expected I4, but got O
						if (!token.IsCancellationRequested)
						{
							GEnum7 gEnum2 = F482GZh7jh[random_0.Next(F482GZh7jh.Count)];
							SendEvent((int)gEnum2);
							Interlocked.Increment(ref int_0);
						}
					});
				}
				int num2 = random_0.Next(CerberusConfig.EventSpammer.MinDelay, Math.Max(CerberusConfig.EventSpammer.MinDelay + 1, CerberusConfig.EventSpammer.MaxDelay));
				if (num2 > 0)
				{
					await Task.Delay(num2, token);
				}
			}
			catch (OperationCanceledException)
			{
				break;
			}
			catch (Exception ex2)
			{
				isawmill_0.Error("Error in SpamLoop: " + ex2.Message);
				await Task.Delay(1000, token);
			}
		}
		isawmill_0.Info("SpamLoop ended");
	}

	private List<GEnum7> GetActiveEventTypes()
	{
		//IL_0072: Expected O, but got I4
		//IL_016f: Expected O, but got I4
		//IL_00d5: Expected O, but got I4
		//IL_018c: Expected O, but got I4
		//IL_00f4: Expected O, but got I4
		//IL_01f1: Expected O, but got I4
		//IL_0101: Expected O, but got I4
		//IL_015f: Expected O, but got I4
		//IL_00a2: Expected O, but got I4
		//IL_00c5: Expected O, but got I4
		//IL_017c: Expected O, but got I4
		//IL_01d1: Expected O, but got I4
		//IL_0052: Expected O, but got I4
		//IL_0062: Expected O, but got I4
		//IL_0139: Expected O, but got I4
		//IL_01e1: Expected O, but got I4
		//IL_0024: Expected O, but got I4
		//IL_01bf: Expected O, but got I4
		//IL_0122: Expected O, but got I4
		List<GEnum7> list = new List<GEnum7>();
		if (CerberusConfig.EventSpammer.SpamInteraction)
		{
			list.Add((GEnum7)0);
		}
		if (CerberusConfig.EventSpammer.SpamHandActivate)
		{
			list.Add((GEnum7)1);
		}
		if (CerberusConfig.EventSpammer.SpamItemDrop)
		{
			list.Add((GEnum7)2);
		}
		if (CerberusConfig.EventSpammer.SpamItemPickup)
		{
			list.Add((GEnum7)3);
		}
		if (CerberusConfig.EventSpammer.SpamPull)
		{
			list.Add((GEnum7)4);
		}
		if (CerberusConfig.EventSpammer.SpamPush)
		{
			list.Add((GEnum7)5);
		}
		if (CerberusConfig.EventSpammer.SpamMoveInput)
		{
			list.Add((GEnum7)6);
		}
		if (CerberusConfig.EventSpammer.SpamSprint)
		{
			list.Add((GEnum7)7);
		}
		if (CerberusConfig.EventSpammer.SpamCrouch)
		{
			list.Add((GEnum7)8);
		}
		if (CerberusConfig.EventSpammer.SpamVerb)
		{
			list.Add((GEnum7)9);
		}
		if (CerberusConfig.EventSpammer.SpamExamine)
		{
			list.Add((GEnum7)10);
		}
		if (CerberusConfig.EventSpammer.SpamAttack)
		{
			list.Add((GEnum7)11);
		}
		if (CerberusConfig.EventSpammer.SpamUse)
		{
			list.Add((GEnum7)12);
		}
		if (CerberusConfig.EventSpammer.SpamThrow)
		{
			list.Add((GEnum7)13);
		}
		if (CerberusConfig.EventSpammer.SpamEquip)
		{
			list.Add((GEnum7)14);
		}
		if (CerberusConfig.EventSpammer.SpamUnequip)
		{
			list.Add((GEnum7)15);
		}
		if (CerberusConfig.EventSpammer.SpamStorage)
		{
			list.Add((GEnum7)16);
		}
		if (CerberusConfig.EventSpammer.SpamContainer)
		{
			list.Add((GEnum7)17);
		}
		if (CerberusConfig.EventSpammer.SpamWield)
		{
			list.Add((GEnum7)18);
		}
		return list;
	}

	public void SendSpecificEvent(int type)
	{
		//IL_002b: Expected O, but got I4
		isawmill_0.Info($"Sending specific event: {(GEnum7)(object)type}");
		SendEvent(type);
	}

	private void SendEvent(int type)
	{
		//IL_00f3: Expected O, but got I4
		int num = int_1++;
		EventLogEntry log = new EventLogEntry
		{
			Id = num,
			Type = type.ToString(),
			Status = "sending",
			Timestamp = DateTime.Now.ToString("HH:mm:ss.fff"),
			Error = ""
		};
		AddLog(log);
		try
		{
			switch (type)
			{
			case 6:
				SendMoveInputEvent();
				break;
			case 0:
				SendInteractionEvent();
				break;
			default:
				SendGenericEvent(type);
				break;
			case 4:
				SendPullEvent();
				break;
			case 1:
				SendHandActivateEvent();
				break;
			}
			UpdateLogStatus(num, "success", "");
		}
		catch (Exception ex)
		{
			isawmill_0.Error($"Error sending event {(GEnum7)(object)type}: {ex.Message}");
			UpdateLogStatus(num, "failed", ex.Message);
		}
	}

	private void AddLog(EventLogEntry log)
	{
		lock (list_0)
		{
			list_0.Add(log);
			if (list_0.Count > 100)
			{
				list_0.RemoveAt(0);
			}
		}
	}

	private void UpdateLogStatus(int logId, string status, string error)
	{
		lock (list_0)
		{
			EventLogEntry gClass = list_0.Find((EventLogEntry l) => l.Id == logId);
			if (gClass != null)
			{
				gClass.Status = status;
				gClass.Error = error;
			}
		}
	}

	public static List<EventLogEntry> GetLogs()
	{
		lock (list_0)
		{
			return new List<EventLogEntry>(list_0);
		}
	}

	public static void ClearLogs()
	{
		lock (list_0)
		{
			list_0.Clear();
			int_1 = 1;
		}
	}

	private void SendInteractionEvent()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		List<EntityUid> randomEntities = GetRandomEntities(10);
		if (randomEntities.Count > 0)
		{
			EntityUid val = randomEntities[random_0.Next(randomEntities.Count)];
			InteractHandEvent val2 = new InteractHandEvent(val, val);
			((IDirectedEventBus)base.EntityManager.EventBus).RaiseLocalEvent<InteractHandEvent>(val, val2, false);
			isawmill_0.Debug($"Sent Interaction event for {val}");
		}
	}

	private void SendHandActivateEvent()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		List<EntityUid> randomEntities = GetRandomEntities(10);
		if (randomEntities.Count > 0)
		{
			EntityUid val = randomEntities[random_0.Next(randomEntities.Count)];
			InteractHandEvent val2 = new InteractHandEvent(val, val);
			((IDirectedEventBus)base.EntityManager.EventBus).RaiseLocalEvent<InteractHandEvent>(val, val2, false);
			isawmill_0.Debug($"Sent HandActivate event for {val}");
		}
	}

	private void SendPullEvent()
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		List<EntityUid> randomEntities = GetRandomEntities(10);
		if (randomEntities.Count >= 2)
		{
			EntityUid val = randomEntities[0];
			EntityUid val2 = randomEntities[1];
			PullAttemptEvent val3 = new PullAttemptEvent(val, val2);
			((IDirectedEventBus)base.EntityManager.EventBus).RaiseLocalEvent<PullAttemptEvent>(val, val3, false);
			isawmill_0.Debug($"Sent Pull event: {val} -> {val2}");
		}
	}

	private void SendMoveInputEvent()
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		List<EntityUid> randomEntities = GetRandomEntities(10);
		if (randomEntities.Count > 0)
		{
			EntityUid value = randomEntities[random_0.Next(randomEntities.Count)];
			((IBroadcastEventBus)base.EntityManager.EventBus).RaiseEvent<MoveInputEvent>((EventSource)1, default(MoveInputEvent));
			isawmill_0.Debug($"Sent MoveInput event for {value}");
		}
	}

	private void SendGenericEvent(int type)
	{
		//IL_002b: Expected O, but got I4
		isawmill_0.Debug($"Sent Generic event: {(GEnum7)(object)type}");
	}

	private List<EntityUid> GetRandomEntities(int count)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		List<EntityUid> list = new List<EntityUid>();
		foreach (EntityUid entity in ientityManager_0.GetEntities())
		{
			list.Add(entity);
			if (list.Count >= count)
			{
				break;
			}
		}
		return list;
	}

	public override void Shutdown()
	{
		StopEventSpam();
		((EntitySystem)this).Shutdown();
	}
}
