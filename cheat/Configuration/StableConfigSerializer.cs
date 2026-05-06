using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;
using CerberusConfig;
using ConfigIdAttribute;
using ConfigSerializerStats;

namespace StableConfigSerializer;

public sealed class StableConfigSerializer
{
	private static readonly Dictionary<string, FieldInfo> dictionary_0 = new Dictionary<string, FieldInfo>();

	private static readonly Dictionary<FieldInfo, ConfigIdAttribute> dictionary_1 = new Dictionary<FieldInfo, ConfigIdAttribute>();

	private static bool bool_0 = false;

	private float float_0;

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

	private static void InitializeCache()
	{
		if (bool_0)
		{
			return;
		}
		dictionary_0.Clear();
		dictionary_1.Clear();
		try
		{
			Type typeFromHandle = typeof(CerberusConfig);
			Type[] array = Array.Empty<Type>();
			try
			{
				array = typeFromHandle.GetNestedTypes(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			}
			catch (TypeInitializationException ex)
			{
				Console.WriteLine("[StableConfigSerializer] TypeInitializationException getting nested types: " + ex.Message);
				if (ex.InnerException != null)
				{
					Console.WriteLine("[StableConfigSerializer] Inner exception: " + ex.InnerException.GetType().Name + ": " + ex.InnerException.Message);
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine("[StableConfigSerializer] Error getting nested types: " + ex2.GetType().Name + ": " + ex2.Message);
			}
			Console.WriteLine($"[StableConfigSerializer] Found {array.Length} nested types in CerberusConfig");
			try
			{
				FieldInfo[] fields = typeFromHandle.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public);
				foreach (FieldInfo fieldInfo in fields)
				{
					ConfigIdAttribute customAttribute = fieldInfo.GetCustomAttribute<ConfigIdAttribute>();
					if (customAttribute != null && !dictionary_0.ContainsKey(customAttribute.Id))
					{
						dictionary_0[customAttribute.Id] = fieldInfo;
						dictionary_1[fieldInfo] = customAttribute;
					}
				}
			}
			catch (Exception ex3)
			{
				Console.WriteLine("[StableConfigSerializer] Error processing top-level fields: " + ex3.Message);
			}
			Type[] array2 = array;
			foreach (Type type in array2)
			{
				try
				{
					FieldInfo[] fields = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public);
					foreach (FieldInfo fieldInfo2 in fields)
					{
						try
						{
							ConfigIdAttribute customAttribute2 = fieldInfo2.GetCustomAttribute<ConfigIdAttribute>();
							if (customAttribute2 != null)
							{
								if (dictionary_0.ContainsKey(customAttribute2.Id))
								{
									Console.WriteLine($"[StableConfigSerializer] Warning: Duplicate ConfigId '{customAttribute2.Id}' found in {type.Name}.{fieldInfo2.Name}");
								}
								else
								{
									dictionary_0[customAttribute2.Id] = fieldInfo2;
									dictionary_1[fieldInfo2] = customAttribute2;
								}
							}
						}
						catch (Exception ex4)
						{
							Console.WriteLine($"[StableConfigSerializer] Error processing field {fieldInfo2.Name} in {type.Name}: {ex4.Message}");
						}
					}
				}
				catch (TypeInitializationException ex5)
				{
					Console.WriteLine("[StableConfigSerializer] TypeInitializationException processing nested type " + type.Name + ": " + ex5.Message);
					if (ex5.InnerException != null)
					{
						Console.WriteLine("[StableConfigSerializer] Inner exception: " + ex5.InnerException.GetType().Name + ": " + ex5.InnerException.Message);
					}
				}
				catch (Exception ex6)
				{
					Console.WriteLine("[StableConfigSerializer] Error processing nested type " + type.Name + ": " + ex6.Message);
				}
			}
			bool_0 = true;
			Console.WriteLine($"[StableConfigSerializer] Cache initialized with {dictionary_0.Count} fields");
		}
		catch (Exception ex7)
		{
			Console.WriteLine("[StableConfigSerializer] Fatal error in InitializeCache: " + ex7.GetType().Name + ": " + ex7.Message);
			Console.WriteLine("[StableConfigSerializer] Stack trace: " + ex7.StackTrace);
			bool_0 = true;
		}
	}

	public static void Save(string path)
	{
		try
		{
			InitializeCache();
			Console.WriteLine("[StableConfigSerializer] Initializing save to: " + path);
			Console.WriteLine($"[StableConfigSerializer] Found {dictionary_0.Count} fields with ConfigId attributes");
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			int num = 0;
			int num2 = 0;
			foreach (KeyValuePair<string, FieldInfo> item in dictionary_0)
			{
				string key = item.Key;
				FieldInfo value = item.Value;
				try
				{
					object value2 = value.GetValue(null);
					dictionary[key] = ConvertToSerializable(value2, value.FieldType);
					num++;
				}
				catch (Exception ex)
				{
					Console.WriteLine("[StableConfigSerializer] Failed to serialize field " + key + ": " + ex.Message);
					num2++;
				}
			}
			Console.WriteLine($"[StableConfigSerializer] Serialized {num} fields successfully, {num2} failed");
			JsonSerializerOptions options = new JsonSerializerOptions
			{
				WriteIndented = true,
				Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
			};
			string text = JsonSerializer.Serialize(dictionary, options);
			Console.WriteLine($"[StableConfigSerializer] JSON size: {text.Length} characters");
			string directoryName = Path.GetDirectoryName(path);
			if (!string.IsNullOrEmpty(directoryName) && !Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
				Console.WriteLine("[StableConfigSerializer] Created directory: " + directoryName);
			}
			File.WriteAllText(path, text);
			Console.WriteLine("[StableConfigSerializer] Config saved successfully to: " + path);
		}
		catch (Exception ex2)
		{
			Console.WriteLine("[StableConfigSerializer] Save failed: " + ex2.Message);
			Console.WriteLine("[StableConfigSerializer] Stack trace: " + ex2.StackTrace);
			throw;
		}
	}

	public static void Load(string path)
	{
		try
		{
			if (File.Exists(path))
			{
				InitializeCache();
				string json = File.ReadAllText(path);
				JsonSerializerOptions options = new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true,
					ReadCommentHandling = JsonCommentHandling.Skip,
					AllowTrailingCommas = true
				};
				Dictionary<string, object> dictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(json, options);
				if (dictionary != null)
				{
					int num = 0;
					int num2 = 0;
					foreach (KeyValuePair<string, object> item in dictionary)
					{
						string key = item.Key;
						if (dictionary_0.TryGetValue(key, out FieldInfo value))
						{
							try
							{
								object value2 = ConvertFromSerializable(item.Value, value.FieldType);
								value.SetValue(null, value2);
								num++;
							}
							catch (Exception ex)
							{
								Console.WriteLine("[StableConfigSerializer] Failed to load field " + key + ": " + ex.Message);
								num2++;
							}
						}
						else
						{
							num2++;
						}
					}
					Console.WriteLine($"[StableConfigSerializer] Config loaded: {num} fields, {num2} skipped");
				}
				else
				{
					Console.WriteLine("[StableConfigSerializer] Failed to deserialize config");
				}
			}
			else
			{
				Console.WriteLine("[StableConfigSerializer] Config file not found: " + path);
			}
		}
		catch (Exception ex2)
		{
			Console.WriteLine("[StableConfigSerializer] Load failed: " + ex2.Message);
		}
	}

	private static object ConvertToSerializable(object value, Type type)
	{
		if (value != null)
		{
			if (!type.IsEnum)
			{
				if (type == typeof(Vector4))
				{
					Vector4 vector = (Vector4)value;
					return new int[4]
					{
						(int)Math.Round(vector.X * 255f),
						(int)Math.Round(vector.Y * 255f),
						(int)Math.Round(vector.Z * 255f),
						(int)Math.Round(vector.W * 255f)
					};
				}
				if (type == typeof(Vector2))
				{
					Vector2 vector2 = (Vector2)value;
					return new float[2] { vector2.X, vector2.Y };
				}
				if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>) && value is IList list)
				{
					object[] array = new object[list.Count];
					for (int i = 0; i < list.Count; i++)
					{
						array[i] = list[i];
					}
					return array;
				}
				return value;
			}
			return Convert.ToInt32(value);
		}
		return null;
	}

	private static object ConvertFromSerializable(object value, Type targetType)
	{
		if (value == null)
		{
			return null;
		}
		if (value is JsonElement element)
		{
			return ConvertJsonElement(element, targetType);
		}
		if (!targetType.IsEnum)
		{
			if (!(targetType == typeof(Vector4)))
			{
				if (targetType == typeof(Vector2))
				{
					if (value is JsonElement { ValueKind: JsonValueKind.Array } jsonElement)
					{
						float[] array = (from e in jsonElement.EnumerateArray()
							select e.GetSingle()).ToArray();
						if (array.Length >= 2)
						{
							return new Vector2(array[0], array[1]);
						}
					}
					return new Vector2(0f, 0f);
				}
				if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(List<>))
				{
					Type type = targetType.GetGenericArguments()[0];
					IList list = Activator.CreateInstance(typeof(List<>).MakeGenericType(type)) as IList;
					if (value is JsonElement { ValueKind: JsonValueKind.Array } jsonElement2)
					{
						foreach (JsonElement item in jsonElement2.EnumerateArray())
						{
							list.Add(ConvertJsonElement(item, type));
						}
					}
					return list;
				}
				return Convert.ChangeType(value, targetType);
			}
			if (value is JsonElement { ValueKind: JsonValueKind.Array } jsonElement3)
			{
				float[] array2 = (from e in jsonElement3.EnumerateArray()
					select e.GetSingle()).ToArray();
				if (array2.Length >= 4)
				{
					if (array2.Any((float v) => v > 1f))
					{
						return new Vector4(array2[0] / 255f, array2[1] / 255f, array2[2] / 255f, array2[3] / 255f);
					}
					return new Vector4(array2[0], array2[1], array2[2], array2[3]);
				}
			}
			return new Vector4(1f, 1f, 1f, 1f);
		}
		return Enum.ToObject(targetType, Convert.ToInt32(value));
	}

	private static object ConvertJsonElement(JsonElement element, Type targetType)
	{
		switch (element.ValueKind)
		{
		case JsonValueKind.True:
		case JsonValueKind.False:
			if (targetType == typeof(bool))
			{
				return element.GetBoolean();
			}
			goto default;
		default:
			return Convert.ChangeType(element.ToString(), targetType);
		case JsonValueKind.Number:
			if (!(targetType == typeof(int)))
			{
				if (!(targetType == typeof(float)))
				{
					if (targetType == typeof(double))
					{
						return element.GetDouble();
					}
					if (targetType == typeof(long))
					{
						return element.GetInt64();
					}
					if (targetType.IsEnum)
					{
						return Enum.ToObject(targetType, element.GetInt32());
					}
					goto default;
				}
				return element.GetSingle();
			}
			return element.GetInt32();
		case JsonValueKind.String:
			if (targetType == typeof(string))
			{
				return element.GetString();
			}
			goto default;
		case JsonValueKind.Array:
		{
			if (targetType == typeof(Vector4))
			{
				float[] array = (from e in element.EnumerateArray()
					select e.GetSingle()).ToArray();
				if (array.Length < 4)
				{
					return new Vector4(1f, 1f, 1f, 1f);
				}
				if (array.Any((float v) => v > 1f))
				{
					return new Vector4(array[0] / 255f, array[1] / 255f, array[2] / 255f, array[3] / 255f);
				}
				return new Vector4(array[0], array[1], array[2], array[3]);
			}
			if (targetType == typeof(Vector2))
			{
				float[] array2 = (from e in element.EnumerateArray()
					select e.GetSingle()).ToArray();
				if (array2.Length >= 2)
				{
					return new Vector2(array2[0], array2[1]);
				}
				return new Vector2(0f, 0f);
			}
			if (!targetType.IsGenericType || !(targetType.GetGenericTypeDefinition() == typeof(List<>)))
			{
				goto default;
			}
			Type type = targetType.GetGenericArguments()[0];
			IList list = Activator.CreateInstance(typeof(List<>).MakeGenericType(type)) as IList;
			{
				foreach (JsonElement item in element.EnumerateArray())
				{
					list.Add(ConvertJsonElement(item, type));
				}
				return list;
			}
		}
		case JsonValueKind.Object:
			return JsonSerializer.Deserialize(element.GetRawText(), targetType);
		}
	}

	public static ConfigSerializerStats GetStats()
	{
		InitializeCache();
		return new ConfigSerializerStats
		{
			TotalFields = dictionary_0.Count,
			ConfigSections = typeof(CerberusConfig).GetNestedTypes(BindingFlags.Static | BindingFlags.Public).Length
		};
	}
}
