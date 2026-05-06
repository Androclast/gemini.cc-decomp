using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace MethodIntegrityMonitor;

public sealed class MethodIntegrityMonitor
{
	private static bool bool_0 = false;

	private static bool bool_1 = false;

	private static Dictionary<MethodInfo, byte[]> dictionary_0 = new Dictionary<MethodInfo, byte[]>();

	private static Dictionary<MethodInfo, uint> dictionary_1 = new Dictionary<MethodInfo, uint>();

	[CompilerGenerated]
	private static Action<string> action_0;

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

	public static event Action<string> Event_0
	{
		[CompilerGenerated]
		add
		{
			Action<string> action = action_0;
			Action<string> action2;
			do
			{
				action2 = action;
				Action<string> value2 = (Action<string>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<string> action = action_0;
			Action<string> action2;
			do
			{
				action2 = action;
				Action<string> value2 = (Action<string>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public static void Initialize()
	{
		if (bool_0)
		{
			return;
		}
		try
		{
			string environmentVariable = Environment.GetEnvironmentVariable("KABAN_OPCODES_BASELINE");
			if (!string.IsNullOrEmpty(environmentVariable))
			{
				Logger.Info("[OpcodesVerifier] Baseline found, verifying against stored baseline");
				if (!VerifyAgainstStoredBaseline(environmentVariable))
				{
					Logger.Fatal("[OpcodesVerifier] Baseline verification failed! Possible drag-and-drop injection detected!");
					action_0?.Invoke("Baseline mismatch");
					Environment.Exit(1);
				}
			}
			else
			{
				Logger.Info("[OpcodesVerifier] No baseline found, creating new baseline");
				CreateBaseline();
			}
			bool_0 = true;
		}
		catch (Exception)
		{
		}
	}

	public static void AddCriticalMethod(MethodInfo method)
	{
		try
		{
			if (!(method == null))
			{
				byte[] methodOpcodes = GetMethodOpcodes(method);
				if (methodOpcodes != null && methodOpcodes.Length != 0)
				{
					uint value = CalculateCRC32(methodOpcodes);
					dictionary_0[method] = methodOpcodes;
					dictionary_1[method] = value;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public static bool VerifyMethod(MethodInfo method)
	{
		try
		{
			if (!dictionary_0.ContainsKey(method))
			{
				return true;
			}
			byte[] methodOpcodes = GetMethodOpcodes(method);
			if (methodOpcodes == null)
			{
				return true;
			}
			uint num = CalculateCRC32(methodOpcodes);
			uint num2 = dictionary_1[method];
			if (num == num2)
			{
				return true;
			}
			Logger.Fatal("[OpcodesVerifier] Tampering detected in method: " + method.DeclaringType?.Name + "." + method.Name);
			return false;
		}
		catch (Exception)
		{
			return true;
		}
	}

	public static void StartMonitoring()
	{
		if (!bool_1)
		{
			bool_1 = true;
			Task.Run(delegate
			{
				MonitoringLoop();
			});
			Logger.Info("[OpcodesVerifier] Monitoring started (using ThreadPool)");
		}
	}

	public static void StopMonitoring()
	{
		bool_1 = false;
		Logger.Info("[OpcodesVerifier] Monitoring stopped");
	}

	private static void MonitoringLoop()
	{
		while (bool_1)
		{
			try
			{
				foreach (KeyValuePair<MethodInfo, byte[]> item in dictionary_0)
				{
					if (!VerifyMethod(item.Key))
					{
						Logger.Fatal("[OpcodesVerifier] Tampering detected during monitoring!");
						action_0?.Invoke("Method: " + item.Key.Name);
						Environment.Exit(1);
					}
				}
				Thread.Sleep(15000);
			}
			catch (Exception ex)
			{
				Logger.Error("[OpcodesVerifier] Monitoring error: " + ex.Message);
			}
		}
	}

	private static byte[] GetMethodOpcodes(MethodInfo method)
	{
		try
		{
			return method.GetMethodBody()?.GetILAsByteArray();
		}
		catch (Exception)
		{
			return null;
		}
	}

	private static uint CalculateCRC32(byte[] data)
	{
		uint num = uint.MaxValue;
		foreach (byte b in data)
		{
			num ^= b;
			for (int j = 0; j < 8; j++)
			{
				num = (((num & 1) == 0) ? (num >> 1) : ((num >> 1) ^ 0xEDB88320u));
			}
		}
		return ~num;
	}

	private static void CreateBaseline()
	{
		try
		{
			List<string> list = new List<string>();
			foreach (KeyValuePair<MethodInfo, uint> item in dictionary_1)
			{
				string value = item.Key.DeclaringType?.Name + "." + item.Key.Name;
				list.Add($"{value}:{item.Value:X8}");
			}
			string value2 = string.Join("|", list);
			Environment.SetEnvironmentVariable("KABAN_OPCODES_BASELINE", value2);
		}
		catch (Exception)
		{
		}
	}

	private static bool VerifyAgainstStoredBaseline(string storedBaseline)
	{
		try
		{
			string[] array = storedBaseline.Split('|');
			Dictionary<string, uint> dictionary = new Dictionary<string, uint>();
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string[] array3 = array2[i].Split(':');
				if (array3.Length == 2)
				{
					string key = array3[0];
					uint value = Convert.ToUInt32(array3[1], 16);
					dictionary[key] = value;
				}
			}
			foreach (KeyValuePair<MethodInfo, uint> item in dictionary_1)
			{
				string text = item.Key.DeclaringType?.Name + "." + item.Key.Name;
				if (dictionary.ContainsKey(text) && dictionary[text] != item.Value)
				{
					Logger.Fatal("[OpcodesVerifier] CRC32 mismatch for " + text);
					return false;
				}
			}
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}
}
