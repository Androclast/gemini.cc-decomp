using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using Content.Client.PDA.Ringer;
using Content.Shared.PDA;
using Content.Shared.PDA.Ringer;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using CerberusConfig;

namespace UplinkBruteforceEngine;

public sealed class UplinkBruteforceEngine
{
	private static readonly Note[] note_0;

	private static readonly long long_0;

	public static HashSet<RingerBoundUserInterface> hashSet_0;

	public static bool bool_0;

	public static bool bool_1;

	public static Note[]? note_1;

	private static long long_1;

	private static DateTime dateTime_0;

	private static RingerBoundUserInterface? ringerBoundUserInterface_0;

	private static bool bool_2;

	private static DateTime dateTime_1;

	private static Queue<string> queue_0;

	private static MethodInfo? methodInfo_0;

	private static Note[]? note_2;

	private static readonly Random random_0;

	private static readonly HashSet<string> hashSet_1;

	private byte byte_0;

	private char char_0;

	public static long CurrentIndex => long_1;

	public static long Total => long_0;

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

	public static List<string> GetAttemptHistory()
	{
		return queue_0.ToList();
	}

	public static void RegisterInterface(RingerBoundUserInterface ui)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		if (ui != null && !hashSet_0.Contains(ui))
		{
			hashSet_0.Add(ui);
			Logger.Info($"[UplinkBruteforce] ✓ RingerUI registered. Owner={((BoundUserInterface)ui).Owner}. Total known: {hashSet_0.Count}");
		}
	}

	public static void UnregisterInterface(RingerBoundUserInterface ui)
	{
		if (hashSet_0.Contains(ui))
		{
			hashSet_0.Remove(ui);
			Logger.Info($"[UplinkBruteforce] RingerUI unregistered. Remaining: {hashSet_0.Count}");
			if (hashSet_0.Count == 0 && bool_0)
			{
				Logger.Warn("[UplinkBruteforce] All UIs closed during bruteforce — stopping.");
				bool_0 = false;
			}
		}
	}

	public unsafe static void OnUiUpdated(RingerBoundUserInterface ui)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		if (!bool_0)
		{
			return;
		}
		try
		{
			RingerUplinkComponent val = default(RingerUplinkComponent);
			if (IoCManager.Resolve<IEntityManager>().TryGetComponent<RingerUplinkComponent>(((BoundUserInterface)ui).Owner, ref val) && val.Unlocked && note_2 != null)
			{
				string text = string.Join("-", note_2.Select((Note n) => ((object)(*(Note*)(&n))/*cast due to constrained. prefix*/).ToString()));
				Logger.Info("[UplinkBruteforce] ✓✓✓ CODE FOUND! Ringtone: " + text);
				Logger.Info($"[UplinkBruteforce] Attempts: {long_1}/{long_0}");
				bool_1 = true;
				note_1 = note_2;
				StopBruteforce();
			}
		}
		catch (Exception ex)
		{
			Logger.Warn("[UplinkBruteforce] OnUiUpdated error: " + ex.Message);
		}
	}

	public static RingerBoundUserInterface? GetActiveUi()
	{
		return hashSet_0.FirstOrDefault();
	}

	public static void StartBruteforce()
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected I8, but got I4
		if (!bool_0)
		{
			Logger.Info($"[UplinkBruteforce] Known interfaces: {hashSet_0.Count}");
			RingerBoundUserInterface activeUi = GetActiveUi();
			if (activeUi != null)
			{
				Logger.Info($"[UplinkBruteforce] Active UI owner: {((BoundUserInterface)activeUi).Owner}");
				if (methodInfo_0 == null)
				{
					methodInfo_0 = (MethodInfo?)(((UplinkBruteforceEngine)(object)typeof(BoundUserInterface)).method_0("SendPredictedMessage", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic) ?? ((UplinkBruteforceEngine)(object)typeof(BoundUserInterface)).method_0("SendMessage", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
					if (!(methodInfo_0 != null))
					{
						Logger.Warn("[UplinkBruteforce] SendMessage method NOT FOUND!");
					}
					else
					{
						Logger.Info("[UplinkBruteforce] Found send method: " + methodInfo_0.Name);
					}
				}
				if (!(methodInfo_0 == null))
				{
					bool_0 = true;
					bool_1 = false;
					note_1 = null;
					long_1 = 0L;
					dateTime_0 = DateTime.Now;
					ringerBoundUserInterface_0 = activeUi;
					bool_2 = false;
					queue_0.Clear();
					hashSet_1.Clear();
					Logger.Info("[UplinkBruteforce] ═══════════════════════════════════════");
					Logger.Info("[UplinkBruteforce] Starting bruteforce!");
					Logger.Info($"[UplinkBruteforce] Total combinations: {long_0:N0}");
					Logger.Info($"[UplinkBruteforce] Speed: {CerberusConfig.UplinkBruteforce.Speed}ms per attempt");
					Logger.Info($"[UplinkBruteforce] Input delay: {CerberusConfig.UplinkBruteforce.InputDelay}ms between notes");
					Logger.Info("[UplinkBruteforce] Random mode: " + (CerberusConfig.UplinkBruteforce.RandomMode ? "ON" : "OFF"));
					if (CerberusConfig.UplinkBruteforce.Speed < 250)
					{
						Logger.Warn($"[UplinkBruteforce] ⚠\ufe0f Speed {CerberusConfig.UplinkBruteforce.Speed}ms < server cooldown 250ms! Server will ignore attempts. Set speed >= 300ms.");
					}
					Logger.Info("[UplinkBruteforce] ═══════════════════════════════════════");
				}
			}
			else
			{
				Logger.Warn("[UplinkBruteforce] No RingerUI found! Open PDA ringer first.");
			}
		}
		else
		{
			Logger.Warn("[UplinkBruteforce] Already running!");
		}
	}

	public static void StopBruteforce()
	{
		if (bool_0)
		{
			bool_0 = false;
			ringerBoundUserInterface_0 = null;
			bool_2 = false;
			Logger.Info($"[UplinkBruteforce] Stopped. Attempts: {long_1}/{long_0}");
		}
		else
		{
			Logger.Warn("[UplinkBruteforce] Not running!");
		}
	}

	public unsafe static void Update(float deltaTime)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		if (!bool_0 || ringerBoundUserInterface_0 == null)
		{
			return;
		}
		try
		{
			if (!IoCManager.Resolve<IEntityManager>().EntityExists(((BoundUserInterface)ringerBoundUserInterface_0).Owner))
			{
				Logger.Warn("[UplinkBruteforce] UI entity no longer exists — stopping.");
				StopBruteforce();
				return;
			}
		}
		catch (Exception ex)
		{
			Logger.Warn("[UplinkBruteforce] Entity check error: " + ex.Message);
			StopBruteforce();
			return;
		}
		if (bool_2)
		{
			if (!((DateTime.Now - dateTime_1).TotalMilliseconds >= (double)CerberusConfig.UplinkBruteforce.Speed))
			{
				return;
			}
			bool_2 = false;
		}
		if (long_1 >= long_0)
		{
			Logger.Warn($"[UplinkBruteforce] ✗ All {long_0:N0} combinations exhausted. Code not found.");
			StopBruteforce();
			return;
		}
		Note[] array = (CerberusConfig.UplinkBruteforce.RandomMode ? GenerateRandomRingtone() : IndexToRingtone(long_1));
		string text = string.Join("-", array.Select((Note n) => ((object)(*(Note*)(&n))/*cast due to constrained. prefix*/).ToString()));
		if (queue_0.Count >= 10)
		{
			queue_0.Dequeue();
		}
		queue_0.Enqueue(text);
		if (long_1 % 100 == 0L)
		{
			double value = (double)long_1 / (double)long_0 * 100.0;
			double totalSeconds = (DateTime.Now - dateTime_0).TotalSeconds;
			double value2 = ((!(totalSeconds <= 0.0)) ? ((double)long_1 / totalSeconds) : 0.0);
			Logger.Info($"[UplinkBruteforce] Progress: {value:F2}% ({long_1}/{long_0}) | Rate: {value2:F1}/s | Current: {text}");
		}
		TryRingtone(ringerBoundUserInterface_0, array);
		note_2 = array;
		bool_2 = true;
		dateTime_1 = DateTime.Now;
		long_1++;
	}

	private static Note[] IndexToRingtone(long index)
	{
		Note[] array = (Note[])(object)new Note[6];
		for (int num = 5; num >= 0; num--)
		{
			array[num] = note_0[index % 7];
			index /= 7;
		}
		return array;
	}

	private static Note[] GenerateRandomRingtone()
	{
		if (hashSet_1.Count >= long_0)
		{
			Logger.Warn("[UplinkBruteforce] All combinations tried in random mode, resetting cache.");
			hashSet_1.Clear();
		}
		int num = 0;
		Note[] array;
		string item;
		do
		{
			array = (Note[])(object)new Note[6];
			for (int i = 0; i < 6; i++)
			{
				array[i] = note_0[random_0.Next(7)];
			}
			item = string.Join(",", array.Select((Note n) => (int)n));
			num++;
		}
		while (hashSet_1.Contains(item) && num < 1000);
		hashSet_1.Add(item);
		return array;
	}

	private unsafe static void TryRingtone(RingerBoundUserInterface ui, Note[] ringtone)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected O, but got Unknown
		try
		{
			int inputDelay = CerberusConfig.UplinkBruteforce.InputDelay;
			if (inputDelay > 0)
			{
				Thread.Sleep(inputDelay);
			}
			RingerSetRingtoneMessage val = new RingerSetRingtoneMessage(ringtone);
			string text;
			object obj;
			if (long_1 <= 3)
			{
				text = string.Join("-", ringtone.Select((Note n) => ((object)(*(Note*)(&n))/*cast due to constrained. prefix*/).ToString()));
				MethodInfo? methodInfo = methodInfo_0;
				if ((object)methodInfo == null)
				{
					obj = null;
				}
				else
				{
					obj = methodInfo.Name;
					if (obj != null)
					{
						goto IL_0068;
					}
				}
				obj = "null";
				goto IL_0068;
			}
			goto IL_0017;
			IL_0068:
			Logger.Info("[UplinkBruteforce] Sending RingerSetRingtoneMessage: [" + text + "] via " + (string?)obj);
			goto IL_0017;
			IL_0017:
			methodInfo_0?.Invoke(ui, new object[1] { val });
		}
		catch (Exception ex)
		{
			Logger.Warn("[UplinkBruteforce] TryRingtone error: " + ex.Message);
			StopBruteforce();
		}
	}

	public static string GetStats()
	{
		if (bool_0)
		{
			double value = (double)long_1 / (double)long_0 * 100.0;
			double totalSeconds = (DateTime.Now - dateTime_0).TotalSeconds;
			double num = ((totalSeconds <= 0.0) ? 0.0 : ((double)long_1 / totalSeconds));
			double value2 = ((num <= 0.0) ? 0.0 : ((double)(long_0 - long_1) / num));
			return $"Progress: {value:F3}% ({long_1}/{long_0}) | Rate: {num:F1}/s | ETA: {value2:F0}s";
		}
		return "Not running.";
	}

	static UplinkBruteforceEngine()
	{
		//IL_00cd: Expected I8, but got I4
		Note[] array = new Note[7];
		RuntimeHelpers.InitializeArray(array, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		note_0 = (Note[])(object)array;
		long_0 = (long)Math.Pow(7.0, 6.0);
		hashSet_0 = new HashSet<RingerBoundUserInterface>();
		bool_0 = false;
		bool_1 = false;
		note_1 = null;
		long_1 = 0L;
		ringerBoundUserInterface_0 = null;
		bool_2 = false;
		dateTime_1 = DateTime.Now;
		queue_0 = new Queue<string>(10);
		note_2 = null;
		random_0 = new Random();
		hashSet_1 = new HashSet<string>();
	}

	public object method_0(string string_2, BindingFlags bindingFlags_0)
	{
		return ((Type)this).GetMethod(string_2, bindingFlags_0);
	}
}
