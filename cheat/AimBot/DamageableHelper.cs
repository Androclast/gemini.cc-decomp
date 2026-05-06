using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Robust.Shared.GameObjects;

namespace DamageableHelper;

public sealed class DamageableHelper
{
	private static Type? type_0;

	private static PropertyInfo? propertyInfo_0;

	private static FieldInfo? fieldInfo_0;

	private static PropertyInfo? propertyInfo_1;

	private static FieldInfo? fieldInfo_1;

	private static PropertyInfo? propertyInfo_2;

	private static FieldInfo? fieldInfo_2;

	private static bool bool_0 = false;

	private static bool bool_1 = false;

	private static string string_0 = "Unknown";

	private byte byte_0;

	private int int_0;

	private int int_1;

	private char char_0;

	public static bool IsAvailable
	{
		get
		{
			if (bool_0)
			{
				return type_0 != null;
			}
			return false;
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

	private int Int32_1
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
			return char_0;
		}
		set
		{
			char_0 = value;
		}
	}

	public static void Initialize()
	{
		if (bool_0 || bool_1)
		{
			return;
		}
		try
		{
			Logger.Info("[UniversalDamageableHelper] Starting initialization...");
			Assembly assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault((Assembly a) => a.GetName().Name == "Content.Shared");
			if (assembly == null)
			{
				Logger.Error("[UniversalDamageableHelper] Content.Shared assembly not found!");
				bool_1 = true;
				return;
			}
			Logger.Info("[UniversalDamageableHelper] Found Content.Shared assembly: " + assembly.FullName);
			string[] array = new string[2] { "Content.Shared.Damage.DamageableComponent", "Content.Shared.Damage.Components.DamageableComponent" };
			foreach (string text in array)
			{
				Logger.Info("[UniversalDamageableHelper] Trying namespace: " + text);
				type_0 = assembly.GetType(text);
				if (type_0 != null)
				{
					string_0 = text;
					Logger.Info("[UniversalDamageableHelper] ✓ Found DamageableComponent in: " + text);
					break;
				}
			}
			if (!(type_0 == null))
			{
				Logger.Info("[UniversalDamageableHelper] Looking for TotalDamage...");
				fieldInfo_0 = type_0.GetField("TotalDamage", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (fieldInfo_0 != null)
				{
					Logger.Info("[UniversalDamageableHelper] ✓ Found TotalDamage as Field: " + fieldInfo_0.FieldType.Name);
				}
				else
				{
					propertyInfo_0 = type_0.GetProperty("TotalDamage", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					if (!(propertyInfo_0 != null))
					{
						Logger.Warn("[UniversalDamageableHelper] ✗ TotalDamage not found!");
					}
					else
					{
						Logger.Info("[UniversalDamageableHelper] ✓ Found TotalDamage as Property: " + propertyInfo_0.PropertyType.Name);
					}
				}
				Logger.Info("[UniversalDamageableHelper] Looking for Damage...");
				fieldInfo_1 = type_0.GetField("Damage", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (!(fieldInfo_1 != null))
				{
					propertyInfo_1 = type_0.GetProperty("Damage", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					if (propertyInfo_1 != null)
					{
						Logger.Info("[UniversalDamageableHelper] ✓ Found Damage as Property: " + propertyInfo_1.PropertyType.Name);
					}
					else
					{
						Logger.Warn("[UniversalDamageableHelper] ✗ Damage not found!");
					}
				}
				else
				{
					Logger.Info("[UniversalDamageableHelper] ✓ Found Damage as Field: " + fieldInfo_1.FieldType.Name);
				}
				Logger.Info("[UniversalDamageableHelper] Looking for DamagePerGroup...");
				fieldInfo_2 = type_0.GetField("DamagePerGroup", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (!(fieldInfo_2 != null))
				{
					propertyInfo_2 = type_0.GetProperty("DamagePerGroup", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					if (propertyInfo_2 != null)
					{
						Logger.Info("[UniversalDamageableHelper] ✓ Found DamagePerGroup as Property: " + propertyInfo_2.PropertyType.Name);
					}
					else
					{
						Logger.Warn("[UniversalDamageableHelper] ✗ DamagePerGroup not found!");
					}
				}
				else
				{
					Logger.Info("[UniversalDamageableHelper] ✓ Found DamagePerGroup as Field: " + fieldInfo_2.FieldType.Name);
				}
				bool_0 = true;
				Logger.Info("[UniversalDamageableHelper] ✓✓✓ Initialization completed successfully!");
				Logger.Info("[UniversalDamageableHelper] Detected namespace: " + string_0);
				Logger.Info("[UniversalDamageableHelper] TotalDamage: " + ((fieldInfo_0 != null) ? "Field" : ((propertyInfo_0 != null) ? "Property" : "NOT FOUND")));
				Logger.Info("[UniversalDamageableHelper] Damage: " + ((fieldInfo_1 != null) ? "Field" : ((propertyInfo_1 != null) ? "Property" : "NOT FOUND")));
				Logger.Info("[UniversalDamageableHelper] DamagePerGroup: " + ((fieldInfo_2 != null) ? "Field" : ((!(propertyInfo_2 != null)) ? "NOT FOUND" : "Property")));
			}
			else
			{
				Logger.Error("[UniversalDamageableHelper] DamageableComponent not found in any known namespace!");
				bool_1 = true;
			}
		}
		catch (Exception ex)
		{
			Logger.Error("[UniversalDamageableHelper] Initialization failed with exception: " + ex.Message);
			Logger.Error("[UniversalDamageableHelper] Stack trace: " + ex.StackTrace);
			bool_1 = true;
		}
	}

	public static bool HasDamageableComponent(EntityUid entity, IEntityManager entityManager)
	{
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		if (!bool_0 && !bool_1)
		{
			Initialize();
		}
		if (!(type_0 == null))
		{
			try
			{
				MethodInfo method = ((object)entityManager).GetType().GetMethod("HasComponent", BindingFlags.Instance | BindingFlags.Public, null, new Type[2]
				{
					typeof(EntityUid),
					typeof(Type)
				}, null);
				if (method != null)
				{
					return (bool)method.Invoke(entityManager, new object[2] { entity, type_0 });
				}
				object component;
				return TryGetDamageableComponent(entity, entityManager, out component);
			}
			catch
			{
			}
			return false;
		}
		return false;
	}

	public static bool TryGetDamageableComponent(EntityUid entity, IEntityManager entityManager, out object? component)
	{
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		component = null;
		if (!bool_0 && !bool_1)
		{
			Initialize();
		}
		if (!(type_0 == null))
		{
			try
			{
				foreach (MethodInfo item in (from m in ((object)entityManager).GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public)
					where m.Name == "TryGetComponent" && m.IsGenericMethod
					select m).ToList())
				{
					ParameterInfo[] parameters = item.GetParameters();
					if (parameters.Length != 2 || !(parameters[0].ParameterType == typeof(EntityUid)) || !parameters[1].IsOut)
					{
						continue;
					}
					try
					{
						MethodInfo methodInfo = item.MakeGenericMethod(type_0);
						object[] array = new object[2] { entity, null };
						if (!(bool)methodInfo.Invoke(entityManager, array))
						{
							return false;
						}
						component = array[1];
						return true;
					}
					catch
					{
					}
				}
			}
			catch
			{
			}
			return false;
		}
		return false;
	}

	public static float GetTotalDamage(object damageableComponent)
	{
		if (!bool_0 && !bool_1)
		{
			Initialize();
		}
		if (damageableComponent != null)
		{
			if (!bool_0)
			{
				return 0f;
			}
			try
			{
				object obj = null;
				if (!(fieldInfo_0 != null))
				{
					if (!(propertyInfo_0 != null))
					{
						return 0f;
					}
					obj = propertyInfo_0.GetValue(damageableComponent);
				}
				else
				{
					obj = fieldInfo_0.GetValue(damageableComponent);
				}
				if (obj != null)
				{
					return ConvertFixedPoint2ToFloat(obj);
				}
				return 0f;
			}
			catch
			{
				return 0f;
			}
		}
		return 0f;
	}

	public static float GetDamageByGroup(object damageableComponent, string groupId)
	{
		if (!bool_0 && !bool_1)
		{
			Initialize();
		}
		if (damageableComponent != null)
		{
			if (!(propertyInfo_2 == null) || !(fieldInfo_2 == null))
			{
				try
				{
					IDictionary dictionary = null;
					if (fieldInfo_2 != null)
					{
						dictionary = fieldInfo_2.GetValue(damageableComponent) as IDictionary;
					}
					else if (propertyInfo_2 != null)
					{
						dictionary = propertyInfo_2.GetValue(damageableComponent) as IDictionary;
					}
					if (dictionary != null && dictionary.Contains(groupId))
					{
						return ConvertFixedPoint2ToFloat(dictionary[groupId]);
					}
				}
				catch
				{
				}
				return 0f;
			}
			return 0f;
		}
		return 0f;
	}

	public static float GetDamageByType(object damageableComponent, string typeId)
	{
		if (!bool_0 && !bool_1)
		{
			Initialize();
		}
		if (damageableComponent == null)
		{
			return 0f;
		}
		if (!(propertyInfo_1 == null) || !(fieldInfo_1 == null))
		{
			try
			{
				object obj = null;
				if (!(fieldInfo_1 != null))
				{
					if (propertyInfo_1 != null)
					{
						obj = propertyInfo_1.GetValue(damageableComponent);
					}
				}
				else
				{
					obj = fieldInfo_1.GetValue(damageableComponent);
				}
				if (obj == null)
				{
					return 0f;
				}
				PropertyInfo property = obj.GetType().GetProperty("DamageDict", BindingFlags.Instance | BindingFlags.Public);
				if (property != null && property.GetValue(obj) is IDictionary dictionary && dictionary.Contains(typeId))
				{
					return ConvertFixedPoint2ToFloat(dictionary[typeId]);
				}
			}
			catch
			{
			}
			return 0f;
		}
		return 0f;
	}

	public static Dictionary<string, float> GetAllDamageGroups(object damageableComponent)
	{
		if (!bool_0 && !bool_1)
		{
			Initialize();
		}
		Dictionary<string, float> dictionary = new Dictionary<string, float>();
		if (damageableComponent == null)
		{
			return dictionary;
		}
		if (propertyInfo_2 == null && fieldInfo_2 == null)
		{
			return dictionary;
		}
		try
		{
			IDictionary dictionary2 = null;
			if (fieldInfo_2 != null)
			{
				dictionary2 = fieldInfo_2.GetValue(damageableComponent) as IDictionary;
			}
			else if (propertyInfo_2 != null)
			{
				dictionary2 = propertyInfo_2.GetValue(damageableComponent) as IDictionary;
			}
			if (dictionary2 != null)
			{
				foreach (object key2 in dictionary2.Keys)
				{
					string key = key2.ToString();
					object fixedPointValue = dictionary2[key2];
					dictionary[key] = ConvertFixedPoint2ToFloat(fixedPointValue);
				}
			}
		}
		catch
		{
		}
		return dictionary;
	}

	public static Dictionary<string, float> GetAllDamageTypes(object damageableComponent)
	{
		if (!bool_0 && !bool_1)
		{
			Initialize();
		}
		Dictionary<string, float> dictionary = new Dictionary<string, float>();
		if (damageableComponent == null)
		{
			return dictionary;
		}
		if (!(propertyInfo_1 == null) || !(fieldInfo_1 == null))
		{
			try
			{
				object obj = null;
				if (fieldInfo_1 != null)
				{
					obj = fieldInfo_1.GetValue(damageableComponent);
				}
				else if (propertyInfo_1 != null)
				{
					obj = propertyInfo_1.GetValue(damageableComponent);
				}
				if (obj == null)
				{
					return dictionary;
				}
				PropertyInfo property = obj.GetType().GetProperty("DamageDict", BindingFlags.Instance | BindingFlags.Public);
				if (property != null && property.GetValue(obj) is IDictionary dictionary2)
				{
					foreach (object key2 in dictionary2.Keys)
					{
						string key = key2.ToString();
						object fixedPointValue = dictionary2[key2];
						dictionary[key] = ConvertFixedPoint2ToFloat(fixedPointValue);
					}
				}
			}
			catch
			{
			}
			return dictionary;
		}
		return dictionary;
	}

	private static float ConvertFixedPoint2ToFloat(object? fixedPointValue)
	{
		if (fixedPointValue == null)
		{
			return 0f;
		}
		try
		{
			try
			{
				return NumericValue.FromObject(fixedPointValue).ToFloat();
			}
			catch
			{
			}
			Type type = fixedPointValue.GetType();
			FieldInfo field = type.GetField("Value", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (field != null)
			{
				object value = field.GetValue(fixedPointValue);
				if (value is int num)
				{
					return (float)num / 100f;
				}
				if (value is float result)
				{
					return result;
				}
			}
			MethodInfo method = type.GetMethod("Float", BindingFlags.Instance | BindingFlags.Public);
			if (method != null && method.ReturnType == typeof(float))
			{
				return (float)method.Invoke(fixedPointValue, null);
			}
			MethodInfo method2 = type.GetMethod("ToFloat", BindingFlags.Instance | BindingFlags.Public);
			if (method2 != null && method2.ReturnType == typeof(float))
			{
				return (float)method2.Invoke(fixedPointValue, null);
			}
			if (fixedPointValue is float result2)
			{
				return result2;
			}
			if (fixedPointValue is int num2)
			{
				return (float)num2 / 100f;
			}
			if (float.TryParse(fixedPointValue.ToString(), out var result3))
			{
				return result3;
			}
		}
		catch
		{
		}
		return 0f;
	}
}
