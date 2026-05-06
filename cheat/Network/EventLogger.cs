using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using EventLogEntryFull;
using EventField;

namespace EventLogger;

public sealed class EventLogger
{
	[CompilerGenerated]
	private static bool bool_0 = true;

	[CompilerGenerated]
	private static int int_0 = 1000;

	[CompilerGenerated]
	private static bool bool_1 = false;

	[CompilerGenerated]
	private static HashSet<string> hashSet_0 = new HashSet<string>();

	[CompilerGenerated]
	private static bool bool_2 = true;

	[CompilerGenerated]
	private static int int_1 = 500;

	private static readonly ConcurrentDictionary<int, EventLogEntryFull> concurrentDictionary_0 = new ConcurrentDictionary<int, EventLogEntryFull>();

	private static int int_2 = 0;

	private static int int_3 = 0;

	private long long_0;

	private float float_1;

	private bool bool_3;

	private string string_0;

	public static bool Enabled
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public static int MaxEvents
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public static bool FilterByType
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	public static HashSet<string> AllowedEventTypes
	{
		[CompilerGenerated]
		get
		{
			return hashSet_0;
		}
		[CompilerGenerated]
		set
		{
			hashSet_0 = value;
		}
	}

	public static bool GroupSimilarEvents
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
		[CompilerGenerated]
		set
		{
			bool_2 = value;
		}
	}

	public static int GroupTimeWindowMs
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	private long Int64_0
	{
		get
		{
			return long_0;
		}
		set
		{
			long_0 = value;
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

	private bool Boolean_0
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
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

	public static IEnumerable<EventLogEntryFull> GetEvents()
	{
		return concurrentDictionary_0.Values.OrderBy((EventLogEntryFull e) => e.Id);
	}

	public static void LogEvent(object eventObj, int source, string entityId = null)
	{
		if (!Enabled)
		{
			return;
		}
		try
		{
			Type type = eventObj.GetType();
			string name = type.Name;
			if (!FilterByType || AllowedEventTypes.Count <= 0 || AllowedEventTypes.Contains(name))
			{
				Dictionary<string, EventField> fields = ExtractFields(eventObj);
				string rawData = SerializeEvent(eventObj);
				EventLogEntryFull gClass = new EventLogEntryFull
				{
					Id = Interlocked.Increment(ref int_2),
					Timestamp = DateTime.Now,
					Source = source,
					EventType = name,
					EventNamespace = type.Namespace,
					EntityId = entityId,
					RawData = rawData,
					Fields = fields,
					OriginalEvent = eventObj
				};
				string eventSignature = GetEventSignature(eventObj, fields);
				EventLogEntryFull gClass2 = TryGroupWithLast(gClass, eventSignature);
				if (gClass2 == null)
				{
					concurrentDictionary_0.TryAdd(gClass.Id, gClass);
					int_3 = gClass.Id;
					TrimEvents();
				}
				else
				{
					gClass2.GroupCount++;
					gClass2.GroupedEventIds.Add(gClass.Id);
					gClass2.IsGrouped = true;
					gClass2.Timestamp = gClass.Timestamp;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private static void TrimEvents()
	{
		while (concurrentDictionary_0.Count > MaxEvents)
		{
			int num = concurrentDictionary_0.Keys.OrderBy((int k) => k).FirstOrDefault();
			if (num > 0)
			{
				concurrentDictionary_0.TryRemove(num, out EventLogEntryFull _);
			}
		}
	}

	private static string GetEventSignature(object eventObj, Dictionary<string, EventField> fields)
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(eventObj.GetType().Name);
			stringBuilder.Append("|");
			HashSet<string> hashSet = new HashSet<string> { "Timestamp", "Time", "Tick", "GameTick", "Handled" };
			foreach (KeyValuePair<string, EventField> item in fields.OrderBy<KeyValuePair<string, EventField>, string>((KeyValuePair<string, EventField> f) => f.Key))
			{
				if (!hashSet.Contains(item.Key))
				{
					stringBuilder.Append(item.Key);
					stringBuilder.Append("=");
					stringBuilder.Append(item.Value.Value);
					stringBuilder.Append("|");
				}
			}
			return stringBuilder.ToString();
		}
		catch
		{
			return eventObj.GetType().Name + "|" + eventObj.GetHashCode();
		}
	}

	private static EventLogEntryFull TryGroupWithLast(EventLogEntryFull newEvent, string signature)
	{
		if (GroupSimilarEvents)
		{
			try
			{
				if (int_3 != 0 && concurrentDictionary_0.TryGetValue(int_3, out EventLogEntryFull value))
				{
					if ((newEvent.Timestamp - value.Timestamp).TotalMilliseconds > (double)GroupTimeWindowMs)
					{
						return null;
					}
					string eventSignature = GetEventSignature(value.OriginalEvent, value.Fields);
					if (!(signature != eventSignature))
					{
						return value;
					}
					return null;
				}
				return null;
			}
			catch
			{
				return null;
			}
		}
		return null;
	}

	private static Dictionary<string, EventField> ExtractFields(object eventObj)
	{
		Dictionary<string, EventField> dictionary = new Dictionary<string, EventField>();
		try
		{
			PropertyInfo[] properties = eventObj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
			foreach (PropertyInfo propertyInfo in properties)
			{
				try
				{
					object value = propertyInfo.GetValue(eventObj);
					EventField obj = new EventField
					{
						Name = propertyInfo.Name,
						Type = propertyInfo.PropertyType.Name
					};
					object obj2;
					if (value == null)
					{
						obj2 = null;
					}
					else
					{
						obj2 = value.ToString();
						if (obj2 != null)
						{
							goto IL_0100;
						}
					}
					obj2 = "null";
					goto IL_0100;
					IL_0100:
					obj.Value = (string)obj2;
					EventField value2 = obj;
					dictionary[propertyInfo.Name] = value2;
				}
				catch
				{
				}
			}
			FieldInfo[] fields = eventObj.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
			foreach (FieldInfo fieldInfo in fields)
			{
				try
				{
					object value3 = fieldInfo.GetValue(eventObj);
					EventField obj4 = new EventField
					{
						Name = fieldInfo.Name,
						Type = fieldInfo.FieldType.Name
					};
					object obj5;
					if (value3 == null)
					{
						obj5 = null;
					}
					else
					{
						obj5 = value3.ToString();
						if (obj5 != null)
						{
							goto IL_007b;
						}
					}
					obj5 = "null";
					goto IL_007b;
					IL_007b:
					obj4.Value = (string)obj5;
					EventField value4 = obj4;
					dictionary[fieldInfo.Name] = value4;
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
		return dictionary;
	}

	private static string SerializeEvent(object eventObj)
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			Type type = eventObj.GetType();
			stringBuilder.AppendLine("╔══════════════════════════════════════════════════════════════");
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder3 = stringBuilder2;
			StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(14, 1, stringBuilder2);
			handler.AppendLiteral("║ Event Type: ");
			handler.AppendFormatted(type.FullName);
			stringBuilder3.AppendLine(ref handler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder4 = stringBuilder2;
			handler = new StringBuilder.AppendInterpolatedStringHandler(8, 1, stringBuilder2);
			handler.AppendLiteral("║ Name: ");
			handler.AppendFormatted(type.Name);
			stringBuilder4.AppendLine(ref handler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder5 = stringBuilder2;
			handler = new StringBuilder.AppendInterpolatedStringHandler(13, 1, stringBuilder2);
			handler.AppendLiteral("║ Namespace: ");
			handler.AppendFormatted(type.Namespace);
			stringBuilder5.AppendLine(ref handler);
			stringBuilder.AppendLine("╠══════════════════════════════════════════════════════════════");
			PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			if (properties.Length != 0)
			{
				stringBuilder.AppendLine("║ Properties:");
				PropertyInfo[] array = properties;
				foreach (PropertyInfo propertyInfo in array)
				{
					try
					{
						object value = propertyInfo.GetValue(eventObj);
						stringBuilder2 = stringBuilder;
						StringBuilder stringBuilder6 = stringBuilder2;
						handler = new StringBuilder.AppendInterpolatedStringHandler(9, 3, stringBuilder2);
						handler.AppendLiteral("║   ");
						handler.AppendFormatted(propertyInfo.Name);
						handler.AppendLiteral(" (");
						handler.AppendFormatted(propertyInfo.PropertyType.Name);
						handler.AppendLiteral("): ");
						object obj;
						if (value != null)
						{
							obj = value.ToString();
							if (obj != null)
							{
								goto IL_02f3;
							}
						}
						else
						{
							obj = null;
						}
						obj = "null";
						goto IL_02f3;
						IL_02f3:
						handler.AppendFormatted((string?)obj);
						stringBuilder6.AppendLine(ref handler);
					}
					catch (Exception ex)
					{
						stringBuilder2 = stringBuilder;
						StringBuilder stringBuilder7 = stringBuilder2;
						handler = new StringBuilder.AppendInterpolatedStringHandler(15, 2, stringBuilder2);
						handler.AppendLiteral("║   ");
						handler.AppendFormatted(propertyInfo.Name);
						handler.AppendLiteral(": <error: ");
						handler.AppendFormatted(ex.Message);
						handler.AppendLiteral(">");
						stringBuilder7.AppendLine(ref handler);
					}
				}
			}
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
			if (fields.Length != 0)
			{
				stringBuilder.AppendLine("║ Fields:");
				FieldInfo[] array2 = fields;
				foreach (FieldInfo fieldInfo in array2)
				{
					try
					{
						object value2 = fieldInfo.GetValue(eventObj);
						stringBuilder2 = stringBuilder;
						StringBuilder stringBuilder8 = stringBuilder2;
						handler = new StringBuilder.AppendInterpolatedStringHandler(9, 3, stringBuilder2);
						handler.AppendLiteral("║   ");
						handler.AppendFormatted(fieldInfo.Name);
						handler.AppendLiteral(" (");
						handler.AppendFormatted(fieldInfo.FieldType.Name);
						handler.AppendLiteral("): ");
						object obj2;
						if (value2 != null)
						{
							obj2 = value2.ToString();
							if (obj2 != null)
							{
								goto IL_00e8;
							}
						}
						else
						{
							obj2 = null;
						}
						obj2 = "null";
						goto IL_00e8;
						IL_00e8:
						handler.AppendFormatted((string?)obj2);
						stringBuilder8.AppendLine(ref handler);
					}
					catch (Exception ex2)
					{
						stringBuilder2 = stringBuilder;
						StringBuilder stringBuilder9 = stringBuilder2;
						handler = new StringBuilder.AppendInterpolatedStringHandler(15, 2, stringBuilder2);
						handler.AppendLiteral("║   ");
						handler.AppendFormatted(fieldInfo.Name);
						handler.AppendLiteral(": <error: ");
						handler.AppendFormatted(ex2.Message);
						handler.AppendLiteral(">");
						stringBuilder9.AppendLine(ref handler);
					}
				}
			}
			stringBuilder.AppendLine("╚══════════════════════════════════════════════════════════════");
			return stringBuilder.ToString();
		}
		catch (Exception ex3)
		{
			return "Failed to serialize event: " + ex3.Message;
		}
	}

	public static void Clear()
	{
		concurrentDictionary_0.Clear();
		int_2 = 0;
		int_3 = 0;
	}

	public static EventLogEntryFull GetEventById(int id)
	{
		concurrentDictionary_0.TryGetValue(id, out EventLogEntryFull value);
		return value;
	}

	public static object GetEventForReplay(int eventId)
	{
		return GetEventById(eventId)?.OriginalEvent;
	}
}
