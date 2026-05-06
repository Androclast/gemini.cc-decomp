using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using TelemetryEventEntry;

namespace TelemetryQueue;

public sealed class TelemetryQueue
{
	private static readonly Queue<TelemetryEventEntry> queue_0 = new Queue<TelemetryEventEntry>();

	private static readonly object object_0 = new object();

	private static Timer? timer_0;

	private static bool bool_0 = false;

	private static string string_0 = "telemetry_cache.dat";

	private static int int_0 = 60;

	private double double_0;

	private float float_1;

	private double double_1;

	private string string_1;

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

	private float Single_0
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	private double Double_1
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

	public static void Initialize(int batchIntervalSeconds = 60, string storagePath = "telemetry_cache.dat")
	{
		if (!bool_0)
		{
			int_0 = batchIntervalSeconds;
			string_0 = storagePath;
			LoadOfflineEvents();
			timer_0 = new Timer(BatchSendCallback, null, TimeSpan.FromSeconds(int_0), TimeSpan.FromSeconds(int_0));
			bool_0 = true;
		}
	}

	public static void Shutdown()
	{
		if (bool_0)
		{
			timer_0?.Dispose();
			timer_0 = null;
			BatchSendCallback(null);
			bool_0 = false;
			Logger.Info("[TelemetryClient] Shutdown complete");
		}
	}

	public static void QueueEvent(int eventType, string details)
	{
		TelemetryEventEntry item = new TelemetryEventEntry
		{
			EventType = eventType,
			Timestamp = DateTime.UtcNow,
			Details = details
		};
		lock (object_0)
		{
			queue_0.Enqueue(item);
		}
	}

	private static void BatchSendCallback(object? state)
	{
		try
		{
			List<TelemetryEventEntry> AO5oE0uh4k;
			lock (object_0)
			{
				if (queue_0.Count == 0)
				{
					return;
				}
				AO5oE0uh4k = new List<TelemetryEventEntry>(queue_0);
				queue_0.Clear();
			}
			Task.Run(() => SendTelemetryAsync(AO5oE0uh4k));
		}
		catch (Exception)
		{
		}
	}

	private static async Task SendTelemetryAsync(List<TelemetryEventEntry> events)
	{
		try
		{
			EncryptEvents(events);
		}
		catch (Exception)
		{
			SaveOfflineEvents(events);
		}
	}

	private static string EncryptEvents(List<TelemetryEventEntry> events)
	{
		try
		{
			string s = JsonSerializer.Serialize(events);
			return Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
		}
		catch (Exception)
		{
			return string.Empty;
		}
	}

	private static void SaveOfflineEvents(List<TelemetryEventEntry> events)
	{
		try
		{
			List<TelemetryEventEntry> list = LoadOfflineEventsFromFile();
			list.AddRange(events);
			string contents = JsonSerializer.Serialize(list);
			File.WriteAllText(string_0, contents);
		}
		catch (Exception)
		{
		}
	}

	private static void LoadOfflineEvents()
	{
		try
		{
			List<TelemetryEventEntry> list = LoadOfflineEventsFromFile();
			if (list.Count <= 0)
			{
				return;
			}
			lock (object_0)
			{
				foreach (TelemetryEventEntry item in list)
				{
					queue_0.Enqueue(item);
				}
			}
			File.Delete(string_0);
		}
		catch (Exception)
		{
		}
	}

	private static List<TelemetryEventEntry> LoadOfflineEventsFromFile()
	{
		try
		{
			if (File.Exists(string_0))
			{
				return JsonSerializer.Deserialize<List<TelemetryEventEntry>>(File.ReadAllText(string_0)) ?? new List<TelemetryEventEntry>();
			}
			return new List<TelemetryEventEntry>();
		}
		catch
		{
			return new List<TelemetryEventEntry>();
		}
	}

	private string method_7(char char_0, double double_2, string string_2)
	{
		return "Хитролох_иди_нахуй.____75_3__1_4_";
	}
}
