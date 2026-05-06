using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Content.Client.Chemistry.UI;
using Content.Shared.Chemistry;
using Content.Shared.Storage;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using AutoChemRecipe;
using AutoChemRecipeManager;

namespace AutoChemCooker;

public sealed class AutoChemCooker
{
	public static HashSet<ReagentDispenserBoundUserInterface> hashSet_0 = new HashSet<ReagentDispenserBoundUserInterface>();

	public static Dictionary<string, ItemStorageLocation> dictionary_0 = new Dictionary<string, ItemStorageLocation>();

	public static HashSet<BoundUserInterface> hashSet_1 = new HashSet<BoundUserInterface>();

	public static Dictionary<string, object> dictionary_1 = new Dictionary<string, object>();

	private static Type? type_0 = null;

	private static Type? type_1 = null;

	public static int int_0 = 0;

	public static int int_1 = 50;

	private bool bool_0;

	private char char_0;

	private bool Boolean_0
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
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

	public static void RegisterInterface(ReagentDispenserBoundUserInterface ui)
	{
		if (ui != null && !hashSet_0.Contains(ui))
		{
			hashSet_0.Add(ui);
			Logger.Info($"[AutoChem] Tracking new Dispenser UI. Total: {hashSet_0.Count}");
		}
	}

	public static void UnregisterInterface(ReagentDispenserBoundUserInterface ui)
	{
		if (hashSet_0.Contains(ui))
		{
			hashSet_0.Remove(ui);
		}
	}

	public static void OnStateUpdated(ReagentDispenserBoundUserInterface ui, ReagentDispenserBoundUserInterfaceState state)
	{
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		dictionary_0.Clear();
		if (state.Inventory == null)
		{
			return;
		}
		Logger.Info($"[AutoChem] Dispenser state updated. Inventory items: {state.Inventory.Count}");
		foreach (ReagentInventoryItem item in state.Inventory)
		{
			if (!string.IsNullOrEmpty(item.ReagentLabel))
			{
				string key = item.ReagentLabel.ToLowerInvariant();
				if (!dictionary_0.ContainsKey(key))
				{
					dictionary_0[key] = item.StorageLocation;
					Logger.Debug($"[AutoChem] Cached reagent: {item.ReagentLabel} -> {item.StorageLocation}");
				}
			}
		}
		Logger.Info($"[AutoChem] Cached {dictionary_0.Count} reagents");
	}

	public static ReagentDispenserBoundUserInterface? GetActiveDispenserUi()
	{
		hashSet_0.RemoveWhere((ReagentDispenserBoundUserInterface ui) => ui == null || IsDisposed((BoundUserInterface)(object)ui));
		ReagentDispenserBoundUserInterface? obj = hashSet_0.FirstOrDefault();
		if (obj != null)
		{
			Logger.Debug($"[AutoChem] Active Dispenser UI found. Total interfaces: {hashSet_0.Count}");
			return obj;
		}
		Logger.Warn($"[AutoChem] No active Dispenser UI found. Known interfaces: {hashSet_0.Count}");
		return obj;
	}

	public static void RegisterChemMasterInterface(BoundUserInterface ui)
	{
		if (ui != null && !hashSet_1.Contains(ui))
		{
			hashSet_1.Add(ui);
			Logger.Info($"[AutoChem] Tracking new ChemMaster UI. Total: {hashSet_1.Count}");
		}
	}

	public static void UnregisterChemMasterInterface(BoundUserInterface ui)
	{
		if (hashSet_1.Contains(ui))
		{
			hashSet_1.Remove(ui);
		}
	}

	public static void OnChemMasterStateUpdated(BoundUserInterface ui, BoundUserInterfaceState state)
	{
		try
		{
			FieldInfo field = ((object)state).GetType().GetField("BufferReagents");
			if (!(field != null) || !(field.GetValue(state) is IEnumerable enumerable))
			{
				return;
			}
			dictionary_1.Clear();
			foreach (object item in enumerable)
			{
				PropertyInfo property = item.GetType().GetProperty("Reagent");
				if (property != null)
				{
					object value = property.GetValue(item);
					if (value != null)
					{
						string text = value.ToString().ToLowerInvariant();
						dictionary_1[text] = value;
						Logger.Debug("[AutoChem] Cached ChemMaster reagent: " + text);
					}
				}
			}
			Logger.Info($"[AutoChem] ChemMaster cached {dictionary_1.Count} reagents");
		}
		catch (Exception ex)
		{
			Logger.Warn("[AutoChem] Error updating ChemMaster state: " + ex.Message);
		}
	}

	public static BoundUserInterface? GetActiveChemMasterUi()
	{
		hashSet_1.RemoveWhere((BoundUserInterface ui) => ui == null || IsDisposed(ui));
		BoundUserInterface? obj = hashSet_1.FirstOrDefault();
		if (obj == null)
		{
			Logger.Warn($"[AutoChem] No active ChemMaster UI found. Known interfaces: {hashSet_1.Count}");
			return obj;
		}
		Logger.Debug($"[AutoChem] Active ChemMaster UI found. Total interfaces: {hashSet_1.Count}");
		return obj;
	}

	private static Type[] GetTypesSafe(Assembly assembly)
	{
		try
		{
			return assembly.GetTypes();
		}
		catch (ReflectionTypeLoadException ex)
		{
			return ex.Types.Where((Type t) => t != null).ToArray();
		}
		catch
		{
			return Array.Empty<Type>();
		}
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

	public static async void Cook(string recipeName, int totalAmount)
	{
		if (int_0 == 0)
		{
			await CookWithDispenser(recipeName, totalAmount);
		}
		else
		{
			await CookWithChemMaster(recipeName, totalAmount);
		}
	}

	private static async Task CookWithDispenser(string recipeName, int totalAmount)
	{
		ReagentDispenserBoundUserInterface ui = GetActiveDispenserUi();
		if (ui != null)
		{
			Dictionary<string, float> baseIngredients = AutoChemRecipeManager.GetBaseIngredients(recipeName, totalAmount);
			Logger.Info($"[AutoChem] Cooking {totalAmount}u {recipeName} with Dispenser. Parts: {string.Join(", ", baseIngredients.Select((KeyValuePair<string, float> x) => $"{x.Value:F1}u {x.Key}"))}");
			foreach (KeyValuePair<string, float> item in baseIngredients)
			{
				int num = (int)Math.Round(item.Value);
				if (num > 0)
				{
					await DispenseComplexAmount(ui, item.Key, num);
					await Task.Delay(int_1);
				}
			}
			Logger.Info("[AutoChem] Done.");
		}
		else
		{
			Logger.Warn("[AutoChem] Dispenser UI not found. Open dispenser window!");
		}
	}

	private static async Task CookWithChemMaster(string recipeName, int totalAmount)
	{
		BoundUserInterface ui = GetActiveChemMasterUi();
		if (ui == null)
		{
			Logger.Warn("[AutoChem] ChemMaster UI not found. Open ChemMaster window!");
			return;
		}
		Dictionary<string, float> dictionary = new Dictionary<string, float>();
		BuildIngredientsSmartly(recipeName, totalAmount, dictionary, recipeName);
		Logger.Info($"[AutoChem] Cooking {totalAmount}u {recipeName} with ChemMaster. Adding: {string.Join(", ", dictionary.Select((KeyValuePair<string, float> x) => $"{x.Value:F1}u {x.Key}"))}");
		foreach (KeyValuePair<string, float> item in dictionary)
		{
			int num = (int)Math.Round(item.Value);
			if (num > 0)
			{
				await TransferFromBuffer(ui, item.Key, num);
				await Task.Delay(int_1);
			}
		}
		await Task.Delay(int_1);
		Logger.Info("[AutoChem] Done.");
	}

	private static void BuildIngredientsSmartly(string name, float amount, Dictionary<string, float> result, string rootRecipeName = null)
	{
		AutoChemRecipe gClass = AutoChemRecipeManager.GetAllRecipes().FirstOrDefault((AutoChemRecipe r) => r.string_2.Equals(name, StringComparison.OrdinalIgnoreCase) || r.string_0.Equals(name, StringComparison.OrdinalIgnoreCase));
		if (gClass != null)
		{
			if (rootRecipeName == null || !name.Equals(rootRecipeName, StringComparison.OrdinalIgnoreCase))
			{
				string DbgkNDdNc3 = name.ToLowerInvariant();
				if (dictionary_1.ContainsKey(DbgkNDdNc3) || dictionary_1.Keys.Any((string k) => k.Equals(DbgkNDdNc3, StringComparison.OrdinalIgnoreCase)))
				{
					Logger.Info("[AutoChem] '" + name + "' already in buffer — using existing, not re-cooking");
					if (result.ContainsKey(name))
					{
						result[name] += amount;
					}
					else
					{
						result[name] = amount;
					}
					return;
				}
			}
			float num = gClass.dictionary_0.Values.Sum();
			{
				foreach (KeyValuePair<string, float> item in gClass.dictionary_0)
				{
					float amount2 = item.Value / num * amount;
					BuildIngredientsSmartly(item.Key, amount2, result, rootRecipeName);
				}
				return;
			}
		}
		if (!result.ContainsKey(name))
		{
			result[name] = amount;
		}
		else
		{
			result[name] += amount;
		}
	}

	private static async Task DispenseComplexAmount(ReagentDispenserBoundUserInterface ui, string name, int amount)
	{
		string mIOk085xOH = name.ToLowerInvariant();
		if (!dictionary_0.TryGetValue(mIOk085xOH, out var location))
		{
			string text = dictionary_0.Keys.FirstOrDefault((string k) => k.Contains(mIOk085xOH));
			if (text == null)
			{
				Logger.Warn("[AutoChem] Missing ingredient: " + name);
				return;
			}
			location = dictionary_0[text];
		}
		int[] buttons = new int[9] { 100, 50, 30, 25, 20, 15, 10, 5, 1 };
		int MSvkPcXLmb = amount;
		while (MSvkPcXLmb > 0)
		{
			int num = buttons.FirstOrDefault((int b) => b <= MSvkPcXLmb);
			if (num == 0)
			{
				num = 1;
			}
			ReagentDispenserDispenseAmount val = (ReagentDispenserDispenseAmount)num;
			try
			{
				((BoundUserInterface)ui).SendMessage((BoundUserInterfaceMessage)new ReagentDispenserSetDispenseAmountMessage(val));
				((BoundUserInterface)ui).SendMessage((BoundUserInterfaceMessage)new ReagentDispenserDispenseReagentMessage(location));
			}
			catch
			{
				break;
			}
			MSvkPcXLmb -= num;
			if (MSvkPcXLmb > 0)
			{
				await Task.Delay(int_1);
			}
		}
	}

	private static async Task TransferFromBuffer(BoundUserInterface ui, string name, int amount)
	{
		string XYBkk78lTT = name.ToLowerInvariant();
		if (!dictionary_1.TryGetValue(XYBkk78lTT, out object reagentId))
		{
			string text = dictionary_1.Keys.FirstOrDefault((string k) => k.Contains(XYBkk78lTT));
			if (text == null)
			{
				Logger.Warn("[AutoChem] Missing reagent in buffer: " + name);
				return;
			}
			reagentId = dictionary_1[text];
		}
		try
		{
			if (type_0 == null)
			{
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				foreach (Assembly assembly in assemblies)
				{
					Type type = assembly.GetType("Content.Shared.Chemistry.ChemMasterReagentAmountButtonMessage") ?? assembly.GetType("ChemMasterReagentAmountButtonMessage");
					if (type != null)
					{
						type_0 = type;
						break;
					}
				}
				if (type_0 == null)
				{
					type_0 = AppDomain.CurrentDomain.GetAssemblies().SelectMany((Assembly a) => GetTypesSafe(a)).FirstOrDefault((Type t) => t.Name == "ChemMasterReagentAmountButtonMessage");
				}
				if (type_0 != null)
				{
					Logger.Debug("[AutoChem] Cached ChemMasterReagentAmountButtonMessage type");
				}
			}
			if (type_0 == null)
			{
				Logger.Warn("[AutoChem] ChemMasterReagentAmountButtonMessage type not found");
				return;
			}
			if (type_1 == null)
			{
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				foreach (Assembly assembly2 in assemblies)
				{
					Type type2 = assembly2.GetType("Content.Shared.Chemistry.ChemMasterReagentAmount") ?? assembly2.GetType("ChemMasterReagentAmount");
					if (type2 != null)
					{
						type_1 = type2;
						break;
					}
				}
				if (type_1 == null)
				{
					type_1 = AppDomain.CurrentDomain.GetAssemblies().SelectMany((Assembly a) => GetTypesSafe(a)).FirstOrDefault((Type t) => t.Name == "ChemMasterReagentAmount");
				}
				if (type_1 != null)
				{
					Logger.Debug("[AutoChem] Cached ChemMasterReagentAmount enum type");
				}
			}
			if (type_1 == null)
			{
				Logger.Warn("[AutoChem] ChemMasterReagentAmount enum not found");
				return;
			}
			int[] buttons = new int[9] { 100, 50, 30, 25, 20, 15, 10, 5, 1 };
			int IKak3Qjx1w = amount;
			while (IKak3Qjx1w > 0)
			{
				int num2 = buttons.FirstOrDefault((int b) => b <= IKak3Qjx1w);
				if (num2 == 0)
				{
					num2 = 1;
				}
				object obj = Enum.ToObject(type_1, num2);
				object obj2 = Activator.CreateInstance(type_0, reagentId, obj, true);
				ui.SendMessage((BoundUserInterfaceMessage)obj2);
				IKak3Qjx1w -= num2;
				if (IKak3Qjx1w > 0)
				{
					await Task.Delay(int_1);
				}
			}
		}
		catch (Exception ex)
		{
			Logger.Warn("[AutoChem] Error transferring from buffer: " + ex.Message);
		}
	}

	private static async Task TransferAllToBuffer(BoundUserInterface ui)
	{
		try
		{
			Type typeFromHandle = typeof(BoundUserInterface);
			FieldInfo field = typeFromHandle.GetField("_lastState", BindingFlags.Instance | BindingFlags.NonPublic);
			object obj = null;
			if (field != null)
			{
				obj = field.GetValue(ui);
				Logger.Debug("[AutoChem] Got state from _lastState field");
			}
			if (obj == null)
			{
				PropertyInfo property = typeFromHandle.GetProperty("State", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (property != null)
				{
					obj = property.GetValue(ui);
					Logger.Debug("[AutoChem] Got state from State property");
				}
			}
			if (obj == null)
			{
				MethodInfo method = typeFromHandle.GetMethod("GetState", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (method != null)
				{
					obj = method.Invoke(ui, null);
					Logger.Debug("[AutoChem] Got state from GetState() method");
				}
			}
			if (obj == null)
			{
				FieldInfo[] fields = typeFromHandle.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				PropertyInfo[] properties = typeFromHandle.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				Logger.Warn("[AutoChem] Cannot access UI state. Available fields: " + string.Join(", ", fields.Select((FieldInfo f) => f.Name)));
				Logger.Warn("[AutoChem] Available properties: " + string.Join(", ", properties.Select((PropertyInfo p) => p.Name)));
				return;
			}
			Type type = obj.GetType();
			FieldInfo fieldInfo = type.GetField("InputContainerInfo") ?? type.GetField("OutputContainerInfo");
			if (!(fieldInfo == null))
			{
				object value = fieldInfo.GetValue(obj);
				if (value == null)
				{
					FieldInfo fieldInfo2 = type.GetField("OutputContainerInfo") ?? type.GetField("InputContainerInfo");
					if (fieldInfo2 != null)
					{
						value = fieldInfo2.GetValue(obj);
					}
				}
				if (value == null)
				{
					Logger.Debug("[AutoChem] No output container (beaker not inserted)");
					return;
				}
				PropertyInfo property2 = value.GetType().GetProperty("Reagents");
				if (property2 == null)
				{
					Logger.Warn("[AutoChem] Reagents property not found");
					return;
				}
				if (!(property2.GetValue(value) is IEnumerable enumerable))
				{
					Logger.Debug("[AutoChem] No reagents in beaker");
					return;
				}
				if (type_0 == null)
				{
					Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
					foreach (Assembly assembly in assemblies)
					{
						Type type2 = assembly.GetType("Content.Shared.Chemistry.ChemMasterReagentAmountButtonMessage") ?? assembly.GetType("ChemMasterReagentAmountButtonMessage");
						if (type2 != null)
						{
							type_0 = type2;
							break;
						}
					}
					if (type_0 == null)
					{
						type_0 = AppDomain.CurrentDomain.GetAssemblies().SelectMany((Assembly a) => GetTypesSafe(a)).FirstOrDefault((Type t) => t.Name == "ChemMasterReagentAmountButtonMessage");
					}
					if (type_0 != null)
					{
						Logger.Debug("[AutoChem] Cached ChemMasterReagentAmountButtonMessage type");
					}
				}
				if (type_0 == null)
				{
					Logger.Warn("[AutoChem] ChemMasterReagentAmountButtonMessage type not found");
					return;
				}
				if (type_1 == null)
				{
					Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
					foreach (Assembly assembly2 in assemblies)
					{
						Type type3 = assembly2.GetType("Content.Shared.Chemistry.ChemMasterReagentAmount") ?? assembly2.GetType("ChemMasterReagentAmount");
						if (type3 != null)
						{
							type_1 = type3;
							break;
						}
					}
					if (type_1 == null)
					{
						type_1 = AppDomain.CurrentDomain.GetAssemblies().SelectMany((Assembly a) => GetTypesSafe(a)).FirstOrDefault((Type t) => t.Name == "ChemMasterReagentAmount");
					}
					if (type_1 != null)
					{
						Logger.Debug("[AutoChem] Cached ChemMasterReagentAmount enum type");
					}
				}
				if (type_1 == null)
				{
					Logger.Warn("[AutoChem] ChemMasterReagentAmount enum not found");
					return;
				}
				object allEnumValue = Enum.Parse(type_1, "All");
				foreach (object item in enumerable)
				{
					PropertyInfo property3 = item.GetType().GetProperty("Reagent");
					if (property3 != null)
					{
						object value2 = property3.GetValue(item);
						if (value2 != null)
						{
							object obj2 = Activator.CreateInstance(type_0, value2, allEnumValue, false);
							ui.SendMessage((BoundUserInterfaceMessage)obj2);
							Logger.Info($"[AutoChem] Transferred {value2} back to buffer");
							await Task.Delay(int_1);
						}
					}
				}
			}
			else
			{
				Logger.Warn("[AutoChem] ContainerInfo field not found in state");
			}
		}
		catch (Exception ex)
		{
			Logger.Warn("[AutoChem] Error transferring to buffer: " + ex.Message);
		}
	}

	public static void TryDispense(string reagentName, int amount)
	{
		Cook(reagentName, amount);
	}

	public static void smethod_236(string string_0, int int_3)
	{
		Cook(string_0, int_3);
	}
}
