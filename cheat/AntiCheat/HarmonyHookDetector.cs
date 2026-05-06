using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace HarmonyHookDetector;

public sealed class HarmonyHookDetector
{
	private static readonly string[] string_0 = new string[6] { "Kaban.cc.dll", "Cerberus.dll", "TargetStrafe.dll", "Kaban.cc", "Cerberus", "TargetStrafe" };

	private float float_0;

	private int int_0;

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

	public static void Initialize()
	{
		DetectHarmonyHooks();
	}

	public static bool DetectHarmonyHooks()
	{
		try
		{
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (Assembly assembly in assemblies)
			{
				string name = assembly.GetName().Name;
				if (!name.Contains("Harmony") && !name.Contains("0Harmony"))
				{
					continue;
				}
				string location = assembly.Location;
				bool flag = false;
				string[] array = string_0;
				foreach (string value in array)
				{
					if (location.Contains(value) || name.Contains(value))
					{
						flag = true;
						Logger.Info("[HarmonyHookDetector] Whitelisted Harmony detected: " + name);
						break;
					}
				}
				if (!flag)
				{
					Logger.Fatal("[HarmonyHookDetector] Non-whitelisted Harmony detected: " + name);
					return true;
				}
			}
			List<MethodInfo> hookedMethods = GetHookedMethods();
			if (hookedMethods.Count > 0)
			{
				Logger.Warn($"[HarmonyHookDetector] Found {hookedMethods.Count} potentially hooked methods");
				foreach (MethodInfo item in hookedMethods)
				{
					bool flag2 = false;
					Type? declaringType = item.DeclaringType;
					object obj;
					if ((object)declaringType != null)
					{
						obj = declaringType.Assembly.GetName().Name;
						if (obj != null)
						{
							goto IL_01aa;
						}
					}
					else
					{
						obj = null;
					}
					obj = "";
					goto IL_01aa;
					IL_01aa:
					string text = (string)obj;
					string[] array = string_0;
					foreach (string value2 in array)
					{
						if (text.Contains(value2))
						{
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						Logger.Fatal("[HarmonyHookDetector] Non-whitelisted hooked method: " + item.DeclaringType?.Name + "." + item.Name);
						return true;
					}
				}
			}
			return false;
		}
		catch (Exception ex)
		{
			Logger.Warn("[HarmonyHookDetector] DetectHarmonyHooks failed: " + ex.Message);
			return false;
		}
	}

	public static List<MethodInfo> GetHookedMethods()
	{
		List<MethodInfo> list = new List<MethodInfo>();
		try
		{
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (Assembly assembly in assemblies)
			{
				try
				{
					Type[] types = assembly.GetTypes();
					foreach (Type type in types)
					{
						try
						{
							MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
							foreach (MethodInfo methodInfo in methods)
							{
								if (IsMethodHooked(methodInfo))
								{
									list.Add(methodInfo);
								}
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
		}
		catch (Exception ex)
		{
			Logger.Warn("[HarmonyHookDetector] GetHookedMethods failed: " + ex.Message);
		}
		return list;
	}

	private static bool IsMethodHooked(MethodInfo method)
	{
		try
		{
			nint functionPointer = method.MethodHandle.GetFunctionPointer();
			if (functionPointer != IntPtr.Zero)
			{
				byte[] array = new byte[16];
				Marshal.Copy(functionPointer, array, 0, 16);
				if (array[0] != 233)
				{
					if (array[0] != 232)
					{
						if (array[0] != 204)
						{
							if (array[0] == 72 && array[1] == 184 && array[10] == byte.MaxValue && array[11] == 224)
							{
								return true;
							}
							return false;
						}
						return true;
					}
					return true;
				}
				return true;
			}
			return false;
		}
		catch
		{
			return false;
		}
	}
}
