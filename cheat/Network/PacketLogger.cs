using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using HarmonyLib;
using Robust.Shared.Network;
using PacketLogEntryFull;
using PacketField;

namespace PacketLogger;

public sealed class PacketLogger
{
	[CompilerGenerated]
	private static bool bool_0 = true;

	[CompilerGenerated]
	private static int int_0 = 1000;

	[CompilerGenerated]
	private static bool bool_1 = true;

	[CompilerGenerated]
	private static int int_1 = 2;

	[CompilerGenerated]
	private static bool bool_2 = false;

	[CompilerGenerated]
	private static int int_2 = 100;

	[CompilerGenerated]
	private static bool bool_3 = true;

	[CompilerGenerated]
	private static int int_3 = 500;

	private static readonly ConcurrentDictionary<int, PacketLogEntryFull> concurrentDictionary_0 = new ConcurrentDictionary<int, PacketLogEntryFull>();

	private static int int_4 = 0;

	private static int int_5 = 0;

	private static Harmony? harmony_0;

	private static bool bool_4 = false;

	private static readonly ConcurrentQueue<PacketLogEntryFull> concurrentQueue_0 = new ConcurrentQueue<PacketLogEntryFull>();

	private static INetManager? inetManager_0;

	private byte byte_0;

	private long long_0;

	private byte byte_1;

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

	public static int MaxPackets
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

	public static bool FilterByFields
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

	public static int MinFields
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

	public static bool FilterBySize
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

	public static int MinSizeBytes
	{
		[CompilerGenerated]
		get
		{
			return int_2;
		}
		[CompilerGenerated]
		set
		{
			int_2 = value;
		}
	}

	public static bool GroupSimilarPackets
	{
		[CompilerGenerated]
		get
		{
			return bool_3;
		}
		[CompilerGenerated]
		set
		{
			bool_3 = value;
		}
	}

	public static int GroupTimeWindowMs
	{
		[CompilerGenerated]
		get
		{
			return int_3;
		}
		[CompilerGenerated]
		set
		{
			int_3 = value;
		}
	}

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

	private byte Byte_1
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = value;
		}
	}

	public static void Initialize(INetManager netManager)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		if (harmony_0 != null)
		{
			return;
		}
		inetManager_0 = netManager;
		harmony_0 = new Harmony("CerberusWareV3.NetLogger");
		try
		{
			MethodInfo method = ((object)netManager).GetType().GetMethod("ClientSendMessage", BindingFlags.Instance | BindingFlags.Public, null, new Type[1] { typeof(NetMessage) }, null);
			if (method != null)
			{
				MethodInfo methodInfo = (MethodInfo)((PacketLogger)(object)typeof(PacketLogger)).method_0("Postfix_ClientSendMessage", BindingFlags.Static | BindingFlags.NonPublic);
				harmony_0.Patch((MethodBase)method, (HarmonyMethod)null, new HarmonyMethod(methodInfo), (HarmonyMethod)null, (HarmonyMethod)null);
			}
			netManager.Connected += OnConnected;
		}
		catch (Exception)
		{
		}
	}

	public static void Shutdown()
	{
		Harmony? obj = harmony_0;
		if (obj != null)
		{
			obj.UnpatchAll("CerberusWareV3.NetLogger");
		}
		harmony_0 = null;
		if (inetManager_0 != null)
		{
			inetManager_0.Connected -= OnConnected;
			inetManager_0 = null;
		}
	}

	public static void ProcessQueue()
	{
		PacketLogEntryFull result;
		while (concurrentQueue_0.TryDequeue(out result))
		{
			concurrentDictionary_0.TryAdd(result.Id, result);
			int_5 = result.Id;
			TrimPackets();
		}
	}

	private static void Postfix_ClientSendMessage(NetMessage message)
	{
		if (Enabled && !bool_4)
		{
			EnqueuePacket(message, 0);
		}
	}

	private static void OnConnected(object? sender, NetChannelArgs args)
	{
		if (inetManager_0 == null)
		{
			return;
		}
		try
		{
			WrapIncomingCallbacks();
		}
		catch (Exception)
		{
		}
	}

	private static void WrapIncomingCallbacks()
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		if (inetManager_0 == null)
		{
			return;
		}
		Type type = ((object)inetManager_0).GetType();
		FieldInfo field = type.GetField("_messages", BindingFlags.Instance | BindingFlags.NonPublic);
		if (field == null || !(field.GetValue(inetManager_0) is IDictionary dictionary))
		{
			return;
		}
		Type type2 = null;
		Type[] nestedTypes = type.GetNestedTypes(BindingFlags.Public | BindingFlags.NonPublic);
		foreach (Type type3 in nestedTypes)
		{
			if (type3.Name == "MessageData")
			{
				type2 = type3;
				break;
			}
		}
		if (type2 == null)
		{
			return;
		}
		FieldInfo field2 = type2.GetField("Callback", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		if (field2 == null)
		{
			return;
		}
		int num = 0;
		foreach (DictionaryEntry item in dictionary)
		{
			object value = item.Value;
			if (value == null)
			{
				continue;
			}
			object? value2 = field2.GetValue(value);
			ProcessMessage val = (ProcessMessage)((value2 is ProcessMessage) ? value2 : null);
			if (val == null)
			{
				continue;
			}
			ProcessMessage pQeHAYxpwh = val;
			ProcessMessage value3 = (ProcessMessage)delegate(NetMessage msg)
			{
				pQeHAYxpwh.Invoke(msg);
				if (!bool_4 && Enabled)
				{
					EnqueuePacket(msg, 1);
				}
			};
			field2.SetValue(value, value3);
			num++;
		}
	}

	private static void EnqueuePacket(NetMessage message, int direction)
	{
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Dictionary<string, PacketField> dictionary = ExtractFields(message);
			string text = SerializeMessage(message);
			int byteCount = Encoding.UTF8.GetByteCount(text);
			bool num = !FilterByFields || dictionary.Count >= MinFields;
			bool flag = !FilterBySize || byteCount >= MinSizeBytes;
			if (!num || !flag)
			{
				return;
			}
			string detailName = "";
			try
			{
				PropertyInfo property = ((object)message).GetType().GetProperty("SystemMessage");
				if (property != null)
				{
					object value = property.GetValue(message);
					if (value != null)
					{
						detailName = value.GetType().Name;
					}
				}
			}
			catch
			{
			}
			NetMessage originalMessage = TryCopyMessage(message);
			PacketLogEntryFull obj2 = new PacketLogEntryFull
			{
				Id = Interlocked.Increment(ref int_4),
				Timestamp = DateTime.Now,
				Direction = direction,
				MessageType = ((object)message).GetType().Name,
				MsgName = message.MsgName,
				DetailName = detailName,
				MsgGroup = ((object)message.MsgGroup/*cast due to constrained. prefix*/).ToString(),
				Size = byteCount
			};
			INetChannel msgChannel = message.MsgChannel;
			object obj3;
			if (msgChannel == null)
			{
				obj3 = null;
			}
			else
			{
				obj3 = ((object)msgChannel).ToString();
				if (obj3 != null)
				{
					goto IL_0245;
				}
			}
			obj3 = "Unknown";
			goto IL_0245;
			IL_0245:
			obj2.Channel = (string)obj3;
			obj2.RawData = text;
			obj2.Fields = dictionary;
			obj2.OriginalMessage = originalMessage;
			PacketLogEntryFull gClass = obj2;
			if (GroupSimilarPackets)
			{
				string packetSignature = GetPacketSignature(message, dictionary);
				if (int_5 > 0 && concurrentDictionary_0.TryGetValue(int_5, out PacketLogEntryFull value2))
				{
					string packetSignature2 = GetPacketSignature(value2.OriginalMessage, value2.Fields);
					double totalMilliseconds = (gClass.Timestamp - value2.Timestamp).TotalMilliseconds;
					if (packetSignature == packetSignature2 && totalMilliseconds < 100.0)
					{
						return;
					}
					if (packetSignature == packetSignature2 && totalMilliseconds <= (double)GroupTimeWindowMs)
					{
						value2.GroupCount++;
						value2.GroupedPacketIds.Add(gClass.Id);
						value2.IsGrouped = true;
						value2.Timestamp = gClass.Timestamp;
						return;
					}
				}
			}
			concurrentQueue_0.Enqueue(gClass);
		}
		catch
		{
		}
	}

	private static NetMessage? TryCopyMessage(NetMessage original)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		try
		{
			Type type = ((object)original).GetType();
			NetMessage val = (NetMessage)Activator.CreateInstance(type);
			if (val != null)
			{
				PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
				foreach (PropertyInfo propertyInfo in properties)
				{
					if (propertyInfo.CanRead && propertyInfo.CanWrite)
					{
						try
						{
							propertyInfo.SetValue(val, propertyInfo.GetValue(original));
						}
						catch
						{
						}
					}
				}
				return val;
			}
			return null;
		}
		catch
		{
			return null;
		}
	}

	public static IEnumerable<PacketLogEntryFull> GetPackets()
	{
		return concurrentDictionary_0.Values.OrderBy((PacketLogEntryFull p) => p.Id);
	}

	public static void LogIncomingPacket(NetMessage message)
	{
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		if (!Enabled)
		{
			return;
		}
		try
		{
			Dictionary<string, PacketField> dictionary = ExtractFields(message);
			string text = SerializeMessage(message);
			int byteCount = Encoding.UTF8.GetByteCount(text);
			bool num = !FilterByFields || dictionary.Count >= MinFields;
			bool flag = !FilterBySize || byteCount >= MinSizeBytes;
			if (!num || !flag)
			{
				return;
			}
			PacketLogEntryFull obj = new PacketLogEntryFull
			{
				Id = Interlocked.Increment(ref int_4),
				Timestamp = DateTime.Now,
				Direction = 1,
				MessageType = ((object)message).GetType().Name,
				MsgName = message.MsgName,
				MsgGroup = ((object)message.MsgGroup/*cast due to constrained. prefix*/).ToString(),
				Size = byteCount
			};
			INetChannel msgChannel = message.MsgChannel;
			object obj2;
			if (msgChannel != null)
			{
				obj2 = ((object)msgChannel).ToString();
				if (obj2 != null)
				{
					goto IL_00d1;
				}
			}
			else
			{
				obj2 = null;
			}
			obj2 = "Unknown";
			goto IL_00d1;
			IL_00d1:
			obj.Channel = (string)obj2;
			obj.RawData = text;
			obj.Fields = dictionary;
			obj.OriginalMessage = message;
			PacketLogEntryFull gClass = obj;
			string packetSignature = GetPacketSignature(message, dictionary);
			PacketLogEntryFull gClass2 = TryGroupWithLast(gClass, packetSignature);
			if (gClass2 != null)
			{
				gClass2.GroupCount++;
				gClass2.GroupedPacketIds.Add(gClass.Id);
				gClass2.IsGrouped = true;
				gClass2.Timestamp = gClass.Timestamp;
			}
			else
			{
				concurrentDictionary_0.TryAdd(gClass.Id, gClass);
				int_5 = gClass.Id;
				TrimPackets();
			}
		}
		catch (Exception)
		{
		}
	}

	public static void LogOutgoingPacket(NetMessage message)
	{
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		if (!Enabled)
		{
			return;
		}
		try
		{
			Dictionary<string, PacketField> dictionary = ExtractFields(message);
			string text = SerializeMessage(message);
			int byteCount = Encoding.UTF8.GetByteCount(text);
			bool num = !FilterByFields || dictionary.Count >= MinFields;
			bool flag = !FilterBySize || byteCount >= MinSizeBytes;
			if (!num || !flag)
			{
				return;
			}
			PacketLogEntryFull obj = new PacketLogEntryFull
			{
				Id = Interlocked.Increment(ref int_4),
				Timestamp = DateTime.Now,
				Direction = 0,
				MessageType = ((object)message).GetType().Name,
				MsgName = message.MsgName,
				MsgGroup = ((object)message.MsgGroup/*cast due to constrained. prefix*/).ToString(),
				Size = byteCount
			};
			INetChannel msgChannel = message.MsgChannel;
			object obj2;
			if (msgChannel == null)
			{
				obj2 = null;
			}
			else
			{
				obj2 = ((object)msgChannel).ToString();
				if (obj2 != null)
				{
					goto IL_00f9;
				}
			}
			obj2 = "Unknown";
			goto IL_00f9;
			IL_00f9:
			obj.Channel = (string)obj2;
			obj.RawData = text;
			obj.Fields = dictionary;
			obj.OriginalMessage = message;
			PacketLogEntryFull gClass = obj;
			string packetSignature = GetPacketSignature(message, dictionary);
			PacketLogEntryFull gClass2 = TryGroupWithLast(gClass, packetSignature);
			if (gClass2 != null)
			{
				gClass2.GroupCount++;
				gClass2.GroupedPacketIds.Add(gClass.Id);
				gClass2.IsGrouped = true;
				gClass2.Timestamp = gClass.Timestamp;
			}
			else
			{
				concurrentDictionary_0.TryAdd(gClass.Id, gClass);
				int_5 = gClass.Id;
				TrimPackets();
			}
		}
		catch (Exception)
		{
		}
	}

	private static void TrimPackets()
	{
		while (concurrentDictionary_0.Count > MaxPackets)
		{
			int num = concurrentDictionary_0.Keys.OrderBy((int k) => k).FirstOrDefault();
			if (num > 0)
			{
				concurrentDictionary_0.TryRemove(num, out PacketLogEntryFull _);
			}
		}
	}

	private static string GetPacketSignature(NetMessage message, Dictionary<string, PacketField> fields)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(message.MsgName);
			stringBuilder.Append("|");
			stringBuilder.Append(message.MsgGroup);
			stringBuilder.Append("|");
			HashSet<string> hashSet = new HashSet<string> { "Tick", "SourceTick", "SubTick", "Sequence", "InputSequence", "Timestamp", "MsgChannel", "MsgName", "MsgGroup", "MsgSize" };
			foreach (KeyValuePair<string, PacketField> item in fields.OrderBy<KeyValuePair<string, PacketField>, string>((KeyValuePair<string, PacketField> f) => f.Key))
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
			return message.MsgName + "|" + ((object)message).GetHashCode();
		}
	}

	private static PacketLogEntryFull TryGroupWithLast(PacketLogEntryFull newPacket, string signature)
	{
		if (GroupSimilarPackets)
		{
			try
			{
				if (int_5 == 0 || !concurrentDictionary_0.TryGetValue(int_5, out PacketLogEntryFull value))
				{
					return null;
				}
				if ((newPacket.Timestamp - value.Timestamp).TotalMilliseconds <= (double)GroupTimeWindowMs)
				{
					string packetSignature = GetPacketSignature(value.OriginalMessage, value.Fields);
					if (!(signature != packetSignature))
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

	private static Dictionary<string, PacketField> ExtractFields(NetMessage message)
	{
		Dictionary<string, PacketField> dictionary = new Dictionary<string, PacketField>();
		try
		{
			PropertyInfo[] properties = ((object)message).GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
			foreach (PropertyInfo propertyInfo in properties)
			{
				try
				{
					if (propertyInfo.Name == "MsgChannel" || propertyInfo.Name == "MsgName" || propertyInfo.Name == "MsgGroup" || propertyInfo.Name == "MsgSize")
					{
						continue;
					}
					object value = propertyInfo.GetValue(message);
					PacketField obj = new PacketField
					{
						Name = propertyInfo.Name,
						Type = propertyInfo.PropertyType.Name
					};
					object obj2;
					if (value != null)
					{
						obj2 = value.ToString();
						if (obj2 != null)
						{
							goto IL_00af;
						}
					}
					else
					{
						obj2 = null;
					}
					obj2 = "null";
					goto IL_00af;
					IL_00af:
					obj.Value = (string)obj2;
					obj.IsEditable = propertyInfo.CanWrite && IsEditableType(propertyInfo.PropertyType);
					PacketField value2 = obj;
					dictionary[propertyInfo.Name] = value2;
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

	private static bool IsEditableType(Type type)
	{
		if (type == typeof(string) || type == typeof(int) || type == typeof(float) || type == typeof(double) || type == typeof(bool) || type == typeof(byte) || type == typeof(short))
		{
			return true;
		}
		return type == typeof(long);
	}

	private static string SerializeMessage(NetMessage message)
	{
		//IL_08c6: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("╔══════════════════════════════════════════════════════════════");
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder3 = stringBuilder2;
			StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(16, 1, stringBuilder2);
			handler.AppendLiteral("║ Message Type: ");
			handler.AppendFormatted(((object)message).GetType().FullName);
			stringBuilder3.AppendLine(ref handler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder4 = stringBuilder2;
			handler = new StringBuilder.AppendInterpolatedStringHandler(8, 1, stringBuilder2);
			handler.AppendLiteral("║ Name: ");
			handler.AppendFormatted(message.MsgName);
			stringBuilder4.AppendLine(ref handler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder5 = stringBuilder2;
			handler = new StringBuilder.AppendInterpolatedStringHandler(9, 1, stringBuilder2);
			handler.AppendLiteral("║ Group: ");
			handler.AppendFormatted<MsgGroups>(message.MsgGroup);
			stringBuilder5.AppendLine(ref handler);
			stringBuilder.AppendLine("╠══════════════════════════════════════════════════════════════");
			PropertyInfo[] properties = ((object)message).GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
			if (properties.Length != 0)
			{
				PropertyInfo[] array = properties;
				foreach (PropertyInfo propertyInfo in array)
				{
					try
					{
						if (propertyInfo.Name == "MsgChannel" || propertyInfo.Name == "MsgName" || propertyInfo.Name == "MsgGroup" || propertyInfo.Name == "MsgSize")
						{
							continue;
						}
						object value = propertyInfo.GetValue(message);
						object obj;
						if (value != null)
						{
							obj = value.ToString() ?? "null";
						}
						else
						{
							_ = null;
							obj = "null";
						}
						string value2 = (string)obj;
						if (value != null)
						{
							if (!propertyInfo.PropertyType.IsEnum)
							{
								if (propertyInfo.PropertyType == typeof(bool))
								{
									stringBuilder2 = stringBuilder;
									StringBuilder stringBuilder6 = stringBuilder2;
									handler = new StringBuilder.AppendInterpolatedStringHandler(4, 2, stringBuilder2);
									handler.AppendLiteral("║ ");
									handler.AppendFormatted(propertyInfo.Name);
									handler.AppendLiteral(": ");
									handler.AppendFormatted(value2);
									stringBuilder6.AppendLine(ref handler);
								}
								else if (!propertyInfo.PropertyType.IsPrimitive && !(propertyInfo.PropertyType == typeof(string)))
								{
									stringBuilder2 = stringBuilder;
									StringBuilder stringBuilder7 = stringBuilder2;
									handler = new StringBuilder.AppendInterpolatedStringHandler(6, 2, stringBuilder2);
									handler.AppendLiteral("║ ");
									handler.AppendFormatted(propertyInfo.Name);
									handler.AppendLiteral(" (");
									handler.AppendFormatted(propertyInfo.PropertyType.Name);
									handler.AppendLiteral("):");
									stringBuilder7.AppendLine(ref handler);
									try
									{
										if (value is IEnumerable enumerable && !(value is string))
										{
											int num = 0;
											foreach (object item in enumerable)
											{
												if (num < 5)
												{
													stringBuilder2 = stringBuilder;
													StringBuilder stringBuilder8 = stringBuilder2;
													handler = new StringBuilder.AppendInterpolatedStringHandler(8, 2, stringBuilder2);
													handler.AppendLiteral("║   [");
													handler.AppendFormatted(num);
													handler.AppendLiteral("]: ");
													handler.AppendFormatted<object>(item);
													stringBuilder8.AppendLine(ref handler);
												}
												num += 213257996;
											}
											if (num > 5)
											{
												stringBuilder2 = stringBuilder;
												StringBuilder stringBuilder9 = stringBuilder2;
												handler = new StringBuilder.AppendInterpolatedStringHandler(23, 1, stringBuilder2);
												handler.AppendLiteral("║   ... and ");
												handler.AppendFormatted(num - 5);
												handler.AppendLiteral(" more items");
												stringBuilder9.AppendLine(ref handler);
											}
											if (num == 0)
											{
												stringBuilder.AppendLine("║   (empty collection)");
											}
											continue;
										}
										PropertyInfo[] properties2 = value.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
										if (properties2.Length != 0 && properties2.Length < 10)
										{
											PropertyInfo[] array2 = properties2;
											foreach (PropertyInfo propertyInfo2 in array2)
											{
												try
												{
													object value3 = propertyInfo2.GetValue(value);
													object obj2;
													if (value3 == null)
													{
														obj2 = null;
													}
													else
													{
														obj2 = value3.ToString();
														if (obj2 != null)
														{
															goto IL_032e;
														}
													}
													obj2 = "null";
													goto IL_032e;
													IL_032e:
													string value4 = (string)obj2;
													if (value3 == null || !propertyInfo2.PropertyType.IsEnum)
													{
														stringBuilder2 = stringBuilder;
														StringBuilder stringBuilder10 = stringBuilder2;
														handler = new StringBuilder.AppendInterpolatedStringHandler(6, 2, stringBuilder2);
														handler.AppendLiteral("║   ");
														handler.AppendFormatted(propertyInfo2.Name);
														handler.AppendLiteral(": ");
														handler.AppendFormatted(value4);
														stringBuilder10.AppendLine(ref handler);
														continue;
													}
													try
													{
														int value5 = Convert.ToInt32(value3);
														stringBuilder2 = stringBuilder;
														StringBuilder stringBuilder11 = stringBuilder2;
														handler = new StringBuilder.AppendInterpolatedStringHandler(9, 3, stringBuilder2);
														handler.AppendLiteral("║   ");
														handler.AppendFormatted(propertyInfo2.Name);
														handler.AppendLiteral(": ");
														handler.AppendFormatted(value4);
														handler.AppendLiteral(" (");
														handler.AppendFormatted(value5);
														handler.AppendLiteral(")");
														stringBuilder11.AppendLine(ref handler);
													}
													catch
													{
														stringBuilder2 = stringBuilder;
														StringBuilder stringBuilder12 = stringBuilder2;
														handler = new StringBuilder.AppendInterpolatedStringHandler(6, 2, stringBuilder2);
														handler.AppendLiteral("║   ");
														handler.AppendFormatted(propertyInfo2.Name);
														handler.AppendLiteral(": ");
														handler.AppendFormatted(value4);
														stringBuilder12.AppendLine(ref handler);
													}
												}
												catch (Exception ex)
												{
													stringBuilder2 = stringBuilder;
													StringBuilder stringBuilder13 = stringBuilder2;
													handler = new StringBuilder.AppendInterpolatedStringHandler(15, 2, stringBuilder2);
													handler.AppendLiteral("║   ");
													handler.AppendFormatted(propertyInfo2.Name);
													handler.AppendLiteral(": <error: ");
													handler.AppendFormatted(ex.Message);
													handler.AppendLiteral(">");
													stringBuilder13.AppendLine(ref handler);
												}
											}
										}
										else
										{
											stringBuilder2 = stringBuilder;
											StringBuilder stringBuilder14 = stringBuilder2;
											handler = new StringBuilder.AppendInterpolatedStringHandler(4, 1, stringBuilder2);
											handler.AppendLiteral("║   ");
											handler.AppendFormatted(value2);
											stringBuilder14.AppendLine(ref handler);
										}
									}
									catch (Exception ex2)
									{
										stringBuilder2 = stringBuilder;
										StringBuilder stringBuilder15 = stringBuilder2;
										handler = new StringBuilder.AppendInterpolatedStringHandler(34, 1, stringBuilder2);
										handler.AppendLiteral("║   <error reading complex type: ");
										handler.AppendFormatted(ex2.Message);
										handler.AppendLiteral(">");
										stringBuilder15.AppendLine(ref handler);
									}
								}
								else
								{
									stringBuilder2 = stringBuilder;
									StringBuilder stringBuilder16 = stringBuilder2;
									handler = new StringBuilder.AppendInterpolatedStringHandler(7, 3, stringBuilder2);
									handler.AppendLiteral("║ ");
									handler.AppendFormatted(propertyInfo.Name);
									handler.AppendLiteral(" (");
									handler.AppendFormatted(propertyInfo.PropertyType.Name);
									handler.AppendLiteral("): ");
									handler.AppendFormatted(value2);
									stringBuilder16.AppendLine(ref handler);
								}
							}
							else
							{
								try
								{
									int value6 = Convert.ToInt32(value);
									stringBuilder2 = stringBuilder;
									StringBuilder stringBuilder17 = stringBuilder2;
									handler = new StringBuilder.AppendInterpolatedStringHandler(10, 4, stringBuilder2);
									handler.AppendLiteral("║ ");
									handler.AppendFormatted(propertyInfo.Name);
									handler.AppendLiteral(" (");
									handler.AppendFormatted(propertyInfo.PropertyType.Name);
									handler.AppendLiteral("): ");
									handler.AppendFormatted(value2);
									handler.AppendLiteral(" (");
									handler.AppendFormatted(value6);
									handler.AppendLiteral(")");
									stringBuilder17.AppendLine(ref handler);
								}
								catch
								{
									stringBuilder2 = stringBuilder;
									StringBuilder stringBuilder18 = stringBuilder2;
									handler = new StringBuilder.AppendInterpolatedStringHandler(7, 3, stringBuilder2);
									handler.AppendLiteral("║ ");
									handler.AppendFormatted(propertyInfo.Name);
									handler.AppendLiteral(" (");
									handler.AppendFormatted(propertyInfo.PropertyType.Name);
									handler.AppendLiteral("): ");
									handler.AppendFormatted(value2);
									stringBuilder18.AppendLine(ref handler);
								}
							}
						}
						else
						{
							stringBuilder2 = stringBuilder;
							StringBuilder stringBuilder19 = stringBuilder2;
							handler = new StringBuilder.AppendInterpolatedStringHandler(11, 2, stringBuilder2);
							handler.AppendLiteral("║ ");
							handler.AppendFormatted(propertyInfo.Name);
							handler.AppendLiteral(" (");
							handler.AppendFormatted(propertyInfo.PropertyType.Name);
							handler.AppendLiteral("): null");
							stringBuilder19.AppendLine(ref handler);
						}
					}
					catch (Exception ex3)
					{
						stringBuilder2 = stringBuilder;
						StringBuilder stringBuilder20 = stringBuilder2;
						handler = new StringBuilder.AppendInterpolatedStringHandler(21, 2, stringBuilder2);
						handler.AppendLiteral("║ ");
						handler.AppendFormatted(propertyInfo.Name);
						handler.AppendLiteral(": <error reading: ");
						handler.AppendFormatted(ex3.Message);
						handler.AppendLiteral(">");
						stringBuilder20.AppendLine(ref handler);
					}
				}
			}
			else
			{
				stringBuilder.AppendLine("║ (No public properties)");
			}
			stringBuilder.AppendLine("╚══════════════════════════════════════════════════════════════");
			return stringBuilder.ToString();
		}
		catch (Exception ex4)
		{
			return "Failed to serialize message: " + ex4.Message + "\n" + ex4.StackTrace;
		}
	}

	public static void Clear()
	{
		concurrentDictionary_0.Clear();
		int_4 = 0;
		int_5 = 0;
	}

	public static PacketLogEntryFull GetPacketById(int id)
	{
		concurrentDictionary_0.TryGetValue(id, out PacketLogEntryFull value);
		return value;
	}

	public static bool UpdatePacketField(int packetId, string fieldName, string newValue)
	{
		try
		{
			PacketLogEntryFull packetById = GetPacketById(packetId);
			if (packetById == null || packetById.OriginalMessage == null)
			{
				return false;
			}
			if (!packetById.Fields.ContainsKey(fieldName))
			{
				return false;
			}
			PacketField gClass = packetById.Fields[fieldName];
			if (!gClass.IsEditable)
			{
				return false;
			}
			PropertyInfo property = ((object)packetById.OriginalMessage).GetType().GetProperty(fieldName);
			if (property == null || !property.CanWrite)
			{
				return false;
			}
			object obj = ConvertValue(newValue, property.PropertyType);
			if (obj != null)
			{
				property.SetValue(packetById.OriginalMessage, obj);
				gClass.Value = newValue;
				packetById.RawData = SerializeMessage(packetById.OriginalMessage);
				return true;
			}
		}
		catch (Exception)
		{
		}
		return false;
	}

	private static object ConvertValue(string value, Type targetType)
	{
		try
		{
			if (targetType == typeof(string))
			{
				return value;
			}
			if (targetType == typeof(int))
			{
				return int.Parse(value);
			}
			if (targetType == typeof(float))
			{
				return float.Parse(value);
			}
			if (targetType == typeof(double))
			{
				return double.Parse(value);
			}
			if (targetType == typeof(bool))
			{
				return bool.Parse(value);
			}
			if (targetType == typeof(byte))
			{
				return byte.Parse(value);
			}
			if (targetType == typeof(short))
			{
				return short.Parse(value);
			}
			if (targetType == typeof(long))
			{
				return long.Parse(value);
			}
		}
		catch
		{
		}
		return null;
	}

	public static NetMessage GetMessageForReplay(int packetId)
	{
		return GetPacketById(packetId)?.OriginalMessage;
	}

	public static void ResendPacket(int packetId)
	{
		if (inetManager_0 == null)
		{
			return;
		}
		PacketLogEntryFull packetById = GetPacketById(packetId);
		if (packetById?.OriginalMessage == null)
		{
			return;
		}
		bool_4 = true;
		try
		{
			inetManager_0.ClientSendMessage(packetById.OriginalMessage);
		}
		catch (Exception)
		{
		}
		finally
		{
			bool_4 = false;
		}
	}

	public static void ResendPackets(IEnumerable<int> packetIds)
	{
		if (inetManager_0 == null)
		{
			return;
		}
		bool_4 = true;
		try
		{
			int num = 0;
			foreach (int packetId in packetIds)
			{
				PacketLogEntryFull packetById = GetPacketById(packetId);
				if (packetById?.OriginalMessage != null)
				{
					inetManager_0.ClientSendMessage(packetById.OriginalMessage);
					num++;
				}
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			bool_4 = false;
		}
	}

	public object method_0(string string_0, BindingFlags bindingFlags_0)
	{
		return ((Type)this).GetMethod(string_0, bindingFlags_0);
	}
}
