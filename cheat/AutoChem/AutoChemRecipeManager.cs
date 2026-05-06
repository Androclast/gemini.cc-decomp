using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using AutoChemRecipe;

namespace AutoChemRecipeManager;

public sealed class AutoChemRecipeManager
{
	private static List<AutoChemRecipe> list_0 = new List<AutoChemRecipe>();

	private static string string_0 = GetRecipesDirectory();

	private static bool bool_0 = false;

	private int int_0;

	private byte byte_1;

	private string string_1;

	private double double_1;

	private int Int32_0
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	private byte Byte_0
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

	private static string GetRecipesDirectory()
	{
		try
		{
			string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			if (!string.IsNullOrEmpty(directoryName))
			{
				return Path.Combine(directoryName, "chem");
			}
		}
		catch
		{
		}
		try
		{
			return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "kaban.cc", "chem");
		}
		catch
		{
		}
		return Path.Combine(Directory.GetCurrentDirectory(), "chem");
	}

	public static void EnsureInitialized()
	{
		if (!bool_0)
		{
			Logger.Info("[AutoChem] Initializing recipe system...");
			LoadRecipesFromFiles();
			bool_0 = true;
		}
	}

	public static void LoadRecipesFromFiles()
	{
		list_0.Clear();
		List<string> list = new List<string>();
		try
		{
			string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			if (!string.IsNullOrEmpty(directoryName))
			{
				list.Add(Path.Combine(directoryName, "chem"));
			}
		}
		catch
		{
		}
		try
		{
			list.Add(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "kaban.cc", "chem"));
		}
		catch
		{
		}
		try
		{
			list.Add(Path.Combine(Directory.GetCurrentDirectory(), "chem"));
		}
		catch
		{
		}
		bool flag = false;
		foreach (string item in list)
		{
			try
			{
				if (!Directory.Exists(item))
				{
					continue;
				}
				Logger.Info("[AutoChem] Checking recipes in: " + item);
				string[] files = Directory.GetFiles(item, "*.json");
				if (files.Length == 0)
				{
					continue;
				}
				Logger.Info($"[AutoChem] Found {files.Length} JSON files in {item}");
				string[] array = files;
				foreach (string path in array)
				{
					try
					{
						foreach (AutoChemRecipe item2 in DeserializeRecipes(File.ReadAllText(path)))
						{
							ProcessRecipe(item2);
						}
					}
					catch (Exception ex)
					{
						Logger.Warn("[AutoChem] Failed to load recipe from " + Path.GetFileName(path) + ": " + ex.Message);
					}
				}
				flag = true;
				string_0 = item;
				Logger.Info($"[AutoChem] Loaded {list_0.Count} recipes from {files.Length} files");
				break;
			}
			catch (Exception ex2)
			{
				Logger.Warn("[AutoChem] Error checking path " + item + ": " + ex2.Message);
			}
		}
		if (flag)
		{
			return;
		}
		foreach (string item3 in list)
		{
			try
			{
				Logger.Info("[AutoChem] Creating recipes directory: " + item3);
				Directory.CreateDirectory(item3);
				string_0 = item3;
				CreateExampleRecipe();
				Logger.Info("[AutoChem] Created example recipe in " + item3);
				break;
			}
			catch (Exception ex3)
			{
				Logger.Warn("[AutoChem] Failed to create directory " + item3 + ": " + ex3.Message);
			}
		}
	}

	private static List<AutoChemRecipe> DeserializeRecipes(string json)
	{
		List<AutoChemRecipe> list = new List<AutoChemRecipe>();
		try
		{
			using JsonDocument jsonDocument = JsonDocument.Parse(json);
			JsonElement rootElement = jsonDocument.RootElement;
			if (rootElement.ValueKind == JsonValueKind.Array)
			{
				foreach (JsonElement item in rootElement.EnumerateArray())
				{
					AutoChemRecipe gClass = ParseRecipeElement(item);
					if (gClass != null)
					{
						list.Add(gClass);
					}
				}
			}
			else if (rootElement.ValueKind == JsonValueKind.Object)
			{
				AutoChemRecipe gClass2 = ParseRecipeElement(rootElement);
				if (gClass2 != null)
				{
					list.Add(gClass2);
				}
			}
		}
		catch (Exception ex)
		{
			Logger.Warn("[AutoChem] Failed to deserialize recipes: " + ex.Message);
		}
		return list;
	}

	private static AutoChemRecipe ParseRecipeElement(JsonElement element)
	{
		try
		{
			AutoChemRecipe gClass = new AutoChemRecipe();
			FieldInfo[] array = (from f in typeof(AutoChemRecipe).GetFields(BindingFlags.Instance | BindingFlags.Public)
				where f.FieldType == typeof(string)
				select f).ToArray();
			if (array.Length != 0 && element.TryGetProperty("name", out var value))
			{
				array[0].SetValue(gClass, value.GetString() ?? "");
			}
			if (array.Length > 1 && element.TryGetProperty("recipe", out var value2))
			{
				array[1].SetValue(gClass, value2.GetString() ?? "");
			}
			return gClass;
		}
		catch (Exception ex)
		{
			Logger.Warn("[AutoChem] Failed to parse recipe element: " + ex.Message);
			return null;
		}
	}

	private static void ProcessRecipe(AutoChemRecipe recipe)
	{
		if (!string.IsNullOrEmpty(recipe.string_1))
		{
			string[] array = recipe.string_1.Split(',');
			recipe.dictionary_0 = new Dictionary<string, float>();
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string text = array2[i].Trim();
				if (!string.IsNullOrEmpty(text))
				{
					recipe.dictionary_0[text] = 1f;
				}
			}
		}
		if (string.IsNullOrEmpty(recipe.string_2))
		{
			recipe.string_2 = recipe.string_0;
		}
		if (!string.IsNullOrEmpty(recipe.string_0) && recipe.dictionary_0 != null && recipe.dictionary_0.Count > 0)
		{
			list_0.Add(recipe);
			Logger.Info($"[AutoChem] Loaded recipe: {recipe.string_0} ({string.Join(", ", recipe.dictionary_0.Keys)})");
		}
	}

	public static List<AutoChemRecipe> GetAllRecipes()
	{
		EnsureInitialized();
		return list_0;
	}

	private static void CreateExampleRecipe()
	{
		try
		{
			string text = Path.Combine(string_0, "example.json");
			string contents = "[\r\n  {\r\n    \"name\": \"Dylovene\",\r\n    \"recipe\": \"silicon, potassium, nitrogen\"\r\n  },\r\n  {\r\n    \"name\": \"Inaprovaline\",\r\n    \"recipe\": \"oxygen, carbon, sugar\"\r\n  },\r\n  {\r\n    \"name\": \"Kelotane\",\r\n    \"recipe\": \"silicon, carbon\"\r\n  }\r\n]";
			File.WriteAllText(text, contents);
			Logger.Info("[AutoChem] Created example recipe file: " + text);
		}
		catch (Exception ex)
		{
			Logger.Warn("[AutoChem] Failed to create example recipe: " + ex.Message);
		}
	}

	public static Dictionary<string, float> GetBaseIngredients(string name, float totalAmount)
	{
		Dictionary<string, float> dictionary = new Dictionary<string, float>();
		FlattenRecipeRecursive(name, totalAmount, dictionary);
		return dictionary;
	}

	public static HashSet<string> GetDirectIngredients(string name)
	{
		AutoChemRecipe gClass = list_0.FirstOrDefault((AutoChemRecipe r) => r.string_2.Equals(name, StringComparison.OrdinalIgnoreCase) || r.string_0.Equals(name, StringComparison.OrdinalIgnoreCase));
		if (gClass == null)
		{
			return new HashSet<string>();
		}
		return new HashSet<string>(gClass.dictionary_0.Keys, StringComparer.OrdinalIgnoreCase);
	}

	private static void FlattenRecipeRecursive(string name, float amount, Dictionary<string, float> accumulator)
	{
		AutoChemRecipe gClass = list_0.FirstOrDefault((AutoChemRecipe r) => r.string_2.Equals(name, StringComparison.OrdinalIgnoreCase) || r.string_0.Equals(name, StringComparison.OrdinalIgnoreCase));
		if (gClass == null)
		{
			if (accumulator.ContainsKey(name))
			{
				accumulator[name] += amount;
			}
			else
			{
				accumulator[name] = amount;
			}
			return;
		}
		float num = gClass.dictionary_0.Values.Sum();
		foreach (KeyValuePair<string, float> item in gClass.dictionary_0)
		{
			float amount2 = item.Value / num * amount;
			FlattenRecipeRecursive(item.Key, amount2, accumulator);
		}
	}
}
