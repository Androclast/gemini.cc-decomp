using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using Content.Client.Store.Ui;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Prototypes;
using AutoBuyPreset;
using AntagStoreListing;

namespace AntagAutoBuyEngine;

public sealed class AntagAutoBuyEngine
{
	public static HashSet<StoreBoundUserInterface> hashSet_0 = new HashSet<StoreBoundUserInterface>();

	private static List<AutoBuyPreset> list_0 = new List<AutoBuyPreset>();

	public static bool bool_0 = false;

	private static Queue<string> queue_0 = new Queue<string>();

	private static StoreBoundUserInterface? storeBoundUserInterface_0 = null;

	private static DateTime dateTime_0 = DateTime.MinValue;

	private static int int_0 = 150;

	private static MethodInfo? methodInfo_0;

	private static List<AntagStoreListing> list_1 = new List<AntagStoreListing>();

	[CompilerGenerated]
	private static Action? action_0;

	private static Type? type_0 = null;

	private static bool bool_1 = false;

	private string string_0;

	private int int_1;

	private char char_1;

	private string string_1;

	public static IReadOnlyList<AutoBuyPreset> Presets => list_0;

	public static IReadOnlyList<AntagStoreListing> CachedListings => list_1;

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

	private char Char_0
	{
		get
		{
			return char_1;
		}
		set
		{
			char_1 = value;
		}
	}

	private string String_1
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

	public static event Action? Event_0
	{
		[CompilerGenerated]
		add
		{
			Action action = action_0;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = action_0;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	[SpecialName]
	private static string XOmsIZn9nW()
	{
		return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Kaban.cc", "autobuy");
	}

	public static void RegisterInterface(StoreBoundUserInterface ui)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		if (ui != null)
		{
			hashSet_0.Add(ui);
			Logger.Info($"[AutoBuy] StoreBoundUserInterface registered. Owner={((BoundUserInterface)ui).Owner}. Total known: {hashSet_0.Count}");
		}
	}

	public static void UnregisterInterface(StoreBoundUserInterface ui)
	{
		hashSet_0.Remove(ui);
		Logger.Info($"[AutoBuy] StoreBoundUserInterface unregistered. Remaining: {hashSet_0.Count}");
		if (hashSet_0.Count == 0 && bool_0)
		{
			Logger.Warn("[AutoBuy] All UIs closed during execution — stopping.");
			bool_0 = false;
			storeBoundUserInterface_0 = null;
		}
	}

	public static void LoadPresets()
	{
		list_0.Clear();
		try
		{
			if (!Directory.Exists(XOmsIZn9nW()))
			{
				return;
			}
			string[] files = Directory.GetFiles(XOmsIZn9nW(), "*.json");
			foreach (string path in files)
			{
				try
				{
					AutoBuyPreset gClass = DeserializePreset(File.ReadAllText(path));
					if (gClass != null)
					{
						list_0.Add(gClass);
					}
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
	}

	public static void SavePreset(AutoBuyPreset preset)
	{
		try
		{
			if (!Directory.Exists(XOmsIZn9nW()))
			{
				Directory.CreateDirectory(XOmsIZn9nW());
			}
			string text = string.Join("_", preset.Name.Split(Path.GetInvalidFileNameChars()));
			string path = Path.Combine(XOmsIZn9nW(), text + ".json");
			string contents = SerializePreset(preset);
			File.WriteAllText(path, contents);
			int num = list_0.FindIndex((AutoBuyPreset p) => p.Name == preset.Name);
			if (num >= 0)
			{
				list_0[num] = preset;
			}
			else
			{
				list_0.Add(preset);
			}
		}
		catch
		{
		}
	}

	public static void DeletePreset(string name)
	{
		try
		{
			string text = string.Join("_", name.Split(Path.GetInvalidFileNameChars()));
			string path = Path.Combine(XOmsIZn9nW(), text + ".json");
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			list_0.RemoveAll((AutoBuyPreset p) => p.Name == name);
		}
		catch
		{
		}
	}

	private static string SerializePreset(AutoBuyPreset preset)
	{
		string value = string.Join(",", preset.Items.Select((string i) => "\"" + EscapeJson(i) + "\""));
		return $"{{\"Name\":\"{EscapeJson(preset.Name)}\",\"Items\":[{value}]}}";
	}

	private static AutoBuyPreset? DeserializePreset(string json)
	{
		try
		{
			using JsonDocument jsonDocument = JsonDocument.Parse(json);
			JsonElement rootElement = jsonDocument.RootElement;
			AutoBuyPreset gClass = new AutoBuyPreset();
			if (rootElement.TryGetProperty("Name", out var value))
			{
				gClass.Name = value.GetString() ?? "Preset";
			}
			if (rootElement.TryGetProperty("Items", out var value2))
			{
				foreach (JsonElement item in value2.EnumerateArray())
				{
					gClass.Items.Add(item.GetString() ?? "");
				}
			}
			return gClass;
		}
		catch
		{
			return null;
		}
	}

	private static string EscapeJson(string s)
	{
		return s.Replace("\\", "\\\\").Replace("\"", "\\\"");
	}

	public static void ExecutePreset(string presetName, int delayMs = 150)
	{
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		Logger.Info($"[AutoBuy] ExecutePreset called: '{presetName}', delay={delayMs}ms");
		if (bool_0)
		{
			Logger.Warn("[AutoBuy] Already running, ignoring.");
			return;
		}
		AutoBuyPreset gClass = list_0.FirstOrDefault((AutoBuyPreset p) => p.Name == presetName);
		if (gClass != null)
		{
			if (gClass.Items.Count == 0)
			{
				Logger.Warn("[AutoBuy] Preset '" + presetName + "' has no items.");
				return;
			}
			Logger.Info($"[AutoBuy] Known store UIs: {hashSet_0.Count}");
			StoreBoundUserInterface val = hashSet_0.FirstOrDefault();
			if (val != null)
			{
				Logger.Info($"[AutoBuy] Active UI owner: {((BoundUserInterface)val).Owner}");
				EnsureSendMethod();
				if (methodInfo_0 == null)
				{
					Logger.Warn("[AutoBuy] SendMessage method NOT FOUND via reflection!");
					return;
				}
				Logger.Info("[AutoBuy] SendMessage method: " + methodInfo_0.Name);
				storeBoundUserInterface_0 = val;
				queue_0 = new Queue<string>(gClass.Items);
				int_0 = delayMs;
				bool_0 = true;
				dateTime_0 = DateTime.MinValue;
				Logger.Info($"[AutoBuy] Started! Items to buy: {gClass.Items.Count} — [{string.Join(", ", gClass.Items)}]");
			}
			else
			{
				Logger.Warn("[AutoBuy] No StoreBoundUserInterface found! Open the Uplink store first.");
			}
		}
		else
		{
			Logger.Warn("[AutoBuy] Preset '" + presetName + "' not found. Available: " + string.Join(", ", list_0.Select((AutoBuyPreset p) => p.Name)));
		}
	}

	public static void Update(float deltaTime)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		if (!bool_0 || storeBoundUserInterface_0 == null)
		{
			return;
		}
		try
		{
			if (!IoCManager.Resolve<IEntityManager>().EntityExists(((BoundUserInterface)storeBoundUserInterface_0).Owner))
			{
				Stop();
				return;
			}
		}
		catch
		{
			Stop();
			return;
		}
		if (queue_0.Count != 0)
		{
			if (!((DateTime.Now - dateTime_0).TotalMilliseconds < (double)int_0))
			{
				string listingId = queue_0.Dequeue();
				TryBuyItem(storeBoundUserInterface_0, listingId);
				dateTime_0 = DateTime.Now;
				if (queue_0.Count == 0)
				{
					Stop();
				}
			}
		}
		else
		{
			Stop();
		}
	}

	private static void Stop()
	{
		bool_0 = false;
		storeBoundUserInterface_0 = null;
		queue_0.Clear();
	}

	private static void TryBuyItem(StoreBoundUserInterface ui, string listingId)
	{
		try
		{
			Logger.Info("[AutoBuy] Trying to buy: '" + listingId + "'");
			Type type = null;
			Type type2 = null;
			Type type3 = null;
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (Assembly assembly in assemblies)
			{
				try
				{
					if (type == null)
					{
						type = assembly.GetType("Content.Shared.Store.StoreBuyListingMessage");
					}
					if (type2 == null)
					{
						type2 = assembly.GetType("Content.Shared.Store.ListingPrototype");
					}
					if (type3 == null)
					{
						type3 = assembly.GetType("Robust.Shared.Prototypes.ProtoId`1");
					}
					if (!(type != null) || !(type2 != null) || !(type3 != null))
					{
						continue;
					}
					break;
				}
				catch
				{
				}
			}
			if (type == null)
			{
				Logger.Warn("[AutoBuy] StoreBuyListingMessage NOT FOUND in any assembly! Searching for store types:");
				assemblies = AppDomain.CurrentDomain.GetAssemblies();
				foreach (Assembly assembly2 in assemblies)
				{
					try
					{
						List<Type> list = (from t in assembly2.GetTypes()
							where t.Name.Contains("StoreBuy") || t.Name.Contains("StoreList")
							select t).ToList();
						if (list.Count > 0)
						{
							Logger.Info("  [" + assembly2.GetName().Name + "]: " + string.Join(", ", list.Select((Type t) => t.FullName)));
						}
					}
					catch
					{
					}
				}
				return;
			}
			Logger.Info("[AutoBuy] Found StoreBuyListingMessage in: " + type.Assembly.GetName().Name);
			if (type2 == null)
			{
				Logger.Warn("[AutoBuy] ListingPrototype NOT FOUND!");
			}
			else if (!(type3 == null))
			{
				object obj3 = Activator.CreateInstance(type3.MakeGenericType(type2), listingId);
				if (obj3 != null)
				{
					ConstructorInfo constructorInfo = type.GetConstructors().FirstOrDefault();
					if (constructorInfo == null)
					{
						Logger.Warn("[AutoBuy] No constructor on StoreBuyListingMessage!");
						return;
					}
					ParameterInfo[] parameters = constructorInfo.GetParameters();
					Logger.Info("[AutoBuy] Ctor params: [" + string.Join(", ", parameters.Select((ParameterInfo p) => p.ParameterType.Name)) + "]");
					object obj4 = ((parameters.Length >= 2) ? constructorInfo.Invoke(new object[2] { obj3, null }) : constructorInfo.Invoke(new object[1] { obj3 }));
					if (obj4 != null)
					{
						methodInfo_0?.Invoke(ui, new object[1] { obj4 });
						Logger.Info("[AutoBuy] Sent buy for '" + listingId + "' via " + methodInfo_0?.Name);
					}
					else
					{
						Logger.Warn("[AutoBuy] Failed to create message!");
					}
				}
				else
				{
					Logger.Warn("[AutoBuy] Failed to create ProtoId for '" + listingId + "'");
				}
			}
			else
			{
				Logger.Warn("[AutoBuy] ProtoId<T> NOT FOUND!");
			}
		}
		catch (Exception ex)
		{
			Logger.Warn("[AutoBuy] TryBuyItem error for '" + listingId + "': " + ex.Message);
		}
	}

	private static void EnsureSendMethod()
	{
		if (!(methodInfo_0 != null))
		{
			methodInfo_0 = (MethodInfo?)(((AntagAutoBuyEngine)(object)typeof(BoundUserInterface)).method_0("SendMessage", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic) ?? ((AntagAutoBuyEngine)(object)typeof(BoundUserInterface)).method_0("SendPredictedMessage", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
		}
	}

	public static void OnStoreStateUpdated(StoreBoundUserInterface ui)
	{
		try
		{
			List<AntagStoreListing> list = ExtractListings(ui);
			Logger.Info($"[AutoBuy] OnStoreStateUpdated: extracted {list.Count} listings from store UI");
			if (list.Count > 0)
			{
				list_1 = list;
				action_0?.Invoke();
			}
		}
		catch (Exception ex)
		{
			Logger.Warn("[AutoBuy] OnStoreStateUpdated error: " + ex.Message);
		}
	}

	private static List<AntagStoreListing> ExtractListings(StoreBoundUserInterface ui)
	{
		List<AntagStoreListing> list = new List<AntagStoreListing>();
		FieldInfo field = typeof(StoreBoundUserInterface).GetField("_listings", BindingFlags.Instance | BindingFlags.NonPublic);
		if (!(field == null))
		{
			object value = field.GetValue(ui);
			if (value == null)
			{
				return list;
			}
			object protoManager = null;
			try
			{
				protoManager = IoCManager.Resolve<IPrototypeManager>();
			}
			catch
			{
			}
			foreach (object item in (IEnumerable)value)
			{
				try
				{
					Type type = item.GetType();
					PropertyInfo? property = type.GetProperty("ID", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					object obj2;
					if ((object)property != null)
					{
						object? value2 = property.GetValue(item);
						if (value2 == null)
						{
							obj2 = null;
						}
						else
						{
							obj2 = value2.ToString();
							if (obj2 != null)
							{
								goto IL_009a;
							}
						}
					}
					else
					{
						obj2 = null;
					}
					obj2 = "";
					goto IL_009a;
					IL_009a:
					string text = (string)obj2;
					if (!string.IsNullOrEmpty(text))
					{
						string name = ResolveListingName(type, item, protoManager) ?? text;
						string cost = ResolveCost(type, item);
						string category = ResolveCategory(type, item);
						list.Add(new AntagStoreListing(text, name, cost, category));
					}
				}
				catch
				{
				}
			}
			list.Sort(delegate(AntagStoreListing a, AntagStoreListing b)
			{
				int num = string.Compare(a.Category, b.Category, StringComparison.OrdinalIgnoreCase);
				return (num == 0) ? string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase) : num;
			});
			return list;
		}
		return list;
	}

	private static string ResolveListingName(Type type, object item, object? protoManager)
	{
		string text = type.GetField("Name", BindingFlags.Instance | BindingFlags.Public)?.GetValue(item)?.ToString();
		if (string.IsNullOrEmpty(text))
		{
			if (protoManager != null)
			{
				object obj = type.GetField("ProductEntity", BindingFlags.Instance | BindingFlags.Public)?.GetValue(item);
				if (obj != null)
				{
					try
					{
						object obj4;
						if (!string.IsNullOrEmpty(obj.ToString()))
						{
							MethodInfo methodInfo = protoManager.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault((MethodInfo m) => m.Name == "Index" && m.IsGenericMethod && m.GetParameters().Length == 1);
							if (methodInfo != null)
							{
								Type type2 = AppDomain.CurrentDomain.GetAssemblies().SelectMany(delegate(Assembly a)
								{
									try
									{
										return a.GetTypes();
									}
									catch
									{
										return Array.Empty<Type>();
									}
								}).FirstOrDefault((Type t) => t.Name == "EntityPrototype");
								if (type2 != null)
								{
									object obj2 = methodInfo.MakeGenericMethod(type2).Invoke(protoManager, new object[1] { obj });
									object obj3;
									if (obj2 == null)
									{
										obj3 = null;
									}
									else
									{
										obj3 = obj2.GetType().GetProperty("Name");
										if (obj3 != null)
										{
											obj4 = ((PropertyInfo)obj3).GetValue(obj2)?.ToString();
											goto IL_010c;
										}
									}
									obj4 = null;
									goto IL_010c;
								}
							}
						}
						goto end_IL_004f;
						IL_010c:
						string text2 = (string)obj4;
						if (!string.IsNullOrEmpty(text2))
						{
							return text2;
						}
						end_IL_004f:;
					}
					catch
					{
					}
				}
			}
			return null;
		}
		try
		{
			if (!bool_1)
			{
				bool_1 = true;
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				foreach (Assembly assembly in assemblies)
				{
					try
					{
						Type type3 = assembly.GetType("Robust.Shared.Localization.Loc");
						if (!(type3 != null) || !(type3.GetMethod("GetString", new Type[1] { typeof(string) }) != null))
						{
							continue;
						}
						type_0 = type3;
						break;
					}
					catch
					{
					}
				}
			}
			if (type_0 != null)
			{
				string text3 = type_0.GetMethod("GetString", new Type[1] { typeof(string) })?.Invoke(null, new object[1] { text })?.ToString();
				if (!string.IsNullOrEmpty(text3) && text3 != text)
				{
					return text3;
				}
			}
		}
		catch
		{
		}
		return text;
	}

	private static string ResolveCost(Type type, object item)
	{
		string[] array = new string[2] { "Cost", "OriginalCost" };
		foreach (string name in array)
		{
			try
			{
				object obj = type.GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)?.GetValue(item);
				if (obj == null)
				{
					continue;
				}
				List<string> list = new List<string>();
				IEnumerator enumerator = ((IEnumerable)obj).GetEnumerator();
				while (enumerator.MoveNext())
				{
					object current = enumerator.Current;
					if (current == null)
					{
						continue;
					}
					Type type2 = current.GetType();
					PropertyInfo? property = type2.GetProperty("Key");
					object obj2;
					object obj3;
					if ((object)property == null)
					{
						obj2 = null;
					}
					else
					{
						obj2 = property.GetValue(current);
						if (obj2 != null)
						{
							obj3 = obj2.ToString();
							if (obj3 == null)
							{
								goto IL_00f7;
							}
							goto IL_00fd;
						}
					}
					obj3 = null;
					goto IL_00f7;
					IL_00fd:
					string text = (string)obj3;
					string text2 = (text.Contains('.') ? text.Split('.').Last() : text);
					object obj4 = type2.GetProperty("Value")?.GetValue(current);
					string text3 = "0";
					if (obj4 != null)
					{
						PropertyInfo property2 = obj4.GetType().GetProperty("Value", BindingFlags.Instance | BindingFlags.Public);
						if (property2 != null)
						{
							double num = (double)Convert.ToInt32(property2.GetValue(obj4)) / 100.0;
							text3 = ((num != Math.Floor(num)) ? num.ToString("0.##") : ((int)num).ToString());
						}
						else
						{
							text3 = obj4.ToString() ?? "0";
						}
					}
					if (!string.IsNullOrEmpty(text2))
					{
						list.Add(text3 + " " + text2);
					}
					continue;
					IL_00f7:
					obj3 = "";
					goto IL_00fd;
				}
				if (list.Count <= 0)
				{
					continue;
				}
				return string.Join(", ", list);
			}
			catch
			{
			}
		}
		return "";
	}

	private static string ResolveCategory(Type type, object item)
	{
		try
		{
			object obj = type.GetField("Categories", BindingFlags.Instance | BindingFlags.Public)?.GetValue(item);
			if (obj == null)
			{
				return "";
			}
			IEnumerator enumerator = ((IEnumerable)obj).GetEnumerator();
			try
			{
				object obj2;
				if (enumerator.MoveNext())
				{
					object current = enumerator.Current;
					if (current != null)
					{
						obj2 = current.ToString();
						if (obj2 != null)
						{
							goto IL_0037;
						}
					}
					else
					{
						obj2 = null;
					}
					obj2 = "";
					goto IL_0037;
				}
				goto end_IL_0018;
				IL_0037:
				return (string)obj2;
				end_IL_0018:;
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}
		catch
		{
		}
		return "";
	}

	public static List<(string Id, string Name, int Cost)> GetAvailableListings()
	{
		return list_1.Select((AntagStoreListing l) => (Id: l.Id, Name: l.Name, 0)).ToList();
	}

	public object method_0(string string_2, BindingFlags bindingFlags_0)
	{
		return ((Type)this).GetMethod(string_2, bindingFlags_0);
	}
}
