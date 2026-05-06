using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using Content.Client.Nuke;
using Content.Shared.Nuke;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using CerberusConfig;

namespace NukeBruteforceEngine;

public sealed class NukeBruteforceEngine
{
	public static HashSet<NukeBoundUserInterface> hashSet_0 = new HashSet<NukeBoundUserInterface>();

	public static bool bool_0 = false;

	private static int int_0 = 0;

	private static int int_1 = 0;

	private static DateTime dateTime_0;

	private static NukeUiState? nukeUiState_0;

	private static int int_2 = 0;

	private static int int_3 = 6;

	private static NukeBoundUserInterface? nukeBoundUserInterface_0 = null;

	private static bool bool_1 = false;

	private static DateTime dateTime_1 = DateTime.Now;

	private static Queue<string> queue_0 = new Queue<string>(10);

	private static MethodInfo methodInfo_0;

	private byte byte_0;

	private double double_0;

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

	private double Double_0
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public static List<string> GetAttemptHistory()
	{
		return queue_0.ToList();
	}

	public static void RegisterInterface(NukeBoundUserInterface ui)
	{
		if (ui != null && !hashSet_0.Contains(ui))
		{
			hashSet_0.Add(ui);
			_ = hashSet_0.Count;
		}
	}

	public static void UnregisterInterface(NukeBoundUserInterface ui)
	{
		if (hashSet_0.Contains(ui))
		{
			hashSet_0.Remove(ui);
			if (hashSet_0.Count == 0 && bool_0)
			{
				bool_0 = false;
			}
		}
	}

	public static void OnStateUpdated(NukeBoundUserInterface ui, NukeUiState state)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between Unknown and I4
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		nukeUiState_0 = state;
		if (!bool_0)
		{
			return;
		}
		if ((int)state.Status != 2)
		{
			if ((int)state.Status == 0)
			{
				StopBruteforce();
			}
		}
		else
		{
			StopBruteforce();
		}
	}

	public static NukeBoundUserInterface? GetActiveUi()
	{
		return hashSet_0.FirstOrDefault();
	}

	private static bool IsDisposed(BoundUserInterface ui)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			return !IoCManager.Resolve<IEntityManager>().EntityExists(ui.Owner);
		}
		catch
		{
			return true;
		}
	}

	public static void StartBruteforce(int codeLength = 6)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Invalid comparison between Unknown and I4
		if (bool_0)
		{
			return;
		}
		NukeBoundUserInterface activeUi = GetActiveUi();
		if (activeUi != null && nukeUiState_0 != null && (int)nukeUiState_0.Status == 1)
		{
			if (methodInfo_0 == null)
			{
				methodInfo_0 = (MethodInfo)((NukeBruteforceEngine)(object)typeof(BoundUserInterface)).method_0("SendMessage", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			}
			if (!(methodInfo_0 == null))
			{
				bool_0 = true;
				int_0 = 0;
				int_2 = 0;
				int_3 = codeLength;
				int_1 = (int)Math.Pow(10.0, codeLength);
				dateTime_0 = DateTime.Now;
				nukeBoundUserInterface_0 = activeUi;
			}
		}
	}

	public static void StopBruteforce()
	{
		if (bool_0)
		{
			bool_0 = false;
			nukeBoundUserInterface_0 = null;
			bool_1 = false;
			queue_0.Clear();
		}
	}

	public static void Update(float deltaTime)
	{
		if (!bool_0 || nukeBoundUserInterface_0 == null)
		{
			return;
		}
		if (IsDisposed((BoundUserInterface)(object)nukeBoundUserInterface_0))
		{
			StopBruteforce();
			return;
		}
		if (bool_1)
		{
			if ((DateTime.Now - dateTime_1).TotalMilliseconds < (double)CerberusConfig.NukeBruteforce.Speed)
			{
				return;
			}
			bool_1 = false;
		}
		if (int_2 < int_1)
		{
			int_0 = int_2 + 1;
			string text = int_2.ToString().PadLeft(int_3, '0');
			if (queue_0.Count >= 10)
			{
				queue_0.Dequeue();
			}
			queue_0.Enqueue(text);
			if (int_0 % 100 == 0)
			{
				double totalSeconds = (DateTime.Now - dateTime_0).TotalSeconds;
				double num = ((!(totalSeconds <= 0.0)) ? ((double)int_0 / totalSeconds) : 0.0);
				if (!(num > 0.0))
				{
				}
			}
			TryCodeSync(nukeBoundUserInterface_0, text);
			bool_1 = true;
			dateTime_1 = DateTime.Now;
			int_2++;
		}
		else
		{
			StopBruteforce();
		}
	}

	private static void TryCodeSync(NukeBoundUserInterface ui, string code)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		try
		{
			methodInfo_0?.Invoke(ui, new object[1] { (object)new NukeKeypadClearMessage() });
			for (int i = 0; i < code.Length; i++)
			{
				int num = code[i] - 48;
				methodInfo_0?.Invoke(ui, new object[1] { (object)new NukeKeypadMessage(num) });
				if (i < code.Length - 1 && CerberusConfig.NukeBruteforce.InputDelay > 0)
				{
					Thread.Sleep(CerberusConfig.NukeBruteforce.InputDelay);
				}
			}
			methodInfo_0?.Invoke(ui, new object[1] { (object)new NukeKeypadEnterMessage() });
		}
		catch (Exception)
		{
			StopBruteforce();
		}
	}

	public static string GetStats()
	{
		if (bool_0)
		{
			double value = (double)int_0 / (double)int_1 * 100.0;
			double totalSeconds = (DateTime.Now - dateTime_0).TotalSeconds;
			double num = ((!(totalSeconds <= 0.0)) ? ((double)int_0 / totalSeconds) : 0.0);
			double value2 = ((num <= 0.0) ? 0.0 : ((double)(int_1 - int_0) / num));
			return $"Progress: {value:F2}% ({int_0}/{int_1}) | Rate: {num:F1}/s | Elapsed: {totalSeconds:F1}s | ETA: {value2:F1}s";
		}
		return "Bruteforce is not running.";
	}

	public object method_0(string string_2, BindingFlags bindingFlags_0)
	{
		return ((Type)this).GetMethod(string_2, bindingFlags_0);
	}

	private string method_5(double double_1)
	{
		return "Хитролох_иди_нахуй._0_4_6__9___3__";
	}

	private string method_6(long long_1, bool bool_2, int int_4)
	{
		return "Хитролох_иди_нахуй._____4____17_5_18_6_";
	}
}
