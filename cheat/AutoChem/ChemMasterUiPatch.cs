using System;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using Robust.Shared.GameObjects;
using AutoChemCooker;

namespace ChemMasterUiPatch;

[HarmonyPatch]
public sealed class ChemMasterUiPatch
{
	private static bool bool_0;

	private bool bool_1;

	private byte byte_0;

	private char char_0;

	private float float_0;

	private bool Boolean_0
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
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

	public static void TryInitialize()
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_036e: Expected O, but got Unknown
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		if (bool_0)
		{
			return;
		}
		bool_0 = true;
		try
		{
			Harmony val = new Harmony("kaban.autochem.chemmaster");
			Type type = null;
			Type type2 = null;
			try
			{
				Assembly assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault((Assembly a) => a.GetName().Name == "Content.Client");
				if (assembly != null)
				{
					Logger.Info("[AutoChem] Found Content.Client assembly");
					Type[] exportedTypes = assembly.GetExportedTypes();
					type = exportedTypes.FirstOrDefault((Type t) => t.Name == "ChemMasterBoundUserInterface");
					type2 = exportedTypes.FirstOrDefault((Type t) => t.Name == "ChemMasterBoundUserInterfaceState");
					if (type != null)
					{
						Logger.Info("[AutoChem] Found ChemMasterBoundUserInterface: " + type.FullName);
					}
					if (type2 != null)
					{
						Logger.Info("[AutoChem] Found ChemMasterBoundUserInterfaceState: " + type2.FullName);
					}
				}
			}
			catch (Exception ex)
			{
				Logger.Warn("[AutoChem] Error finding ChemMaster types: " + ex.Message);
				return;
			}
			if (type == null)
			{
				Logger.Warn("[AutoChem] ChemMasterBoundUserInterface type not found in Content.Client");
				return;
			}
			Type baseType = type.BaseType;
			object obj;
			if ((object)baseType != null)
			{
				obj = baseType.FullName;
				if (obj != null)
				{
					goto IL_0041;
				}
			}
			else
			{
				obj = null;
			}
			obj = "null";
			goto IL_0041;
			IL_0041:
			Logger.Info("[AutoChem] Base type: " + (string?)obj);
			try
			{
				MethodInfo methodInfo = (MethodInfo)(((ChemMasterUiPatch)(object)baseType)?.method_2("Open", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
				Logger.Info($"[AutoChem] Open method found: {methodInfo != null}");
				if (methodInfo != null)
				{
					val.Patch((MethodBase)methodInfo, (HarmonyMethod)null, new HarmonyMethod((MethodInfo)((ChemMasterUiPatch)(object)typeof(ChemMasterUiPatch)).method_0("OpenPostfix")), (HarmonyMethod)null, (HarmonyMethod)null);
					Logger.Info("[AutoChem] Patched ChemMaster Open method");
				}
				else
				{
					Logger.Warn("[AutoChem] Open method not found in base class");
				}
			}
			catch (Exception ex2)
			{
				Logger.Warn("[AutoChem] Error patching Open: " + ex2.Message);
			}
			try
			{
				MethodInfo methodInfo2 = (MethodInfo)(((ChemMasterUiPatch)(object)baseType)?.method_2("UpdateState", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
				Logger.Info($"[AutoChem] UpdateState method found: {methodInfo2 != null}");
				if (methodInfo2 != null)
				{
					val.Patch((MethodBase)methodInfo2, (HarmonyMethod)null, new HarmonyMethod((MethodInfo)((ChemMasterUiPatch)(object)typeof(ChemMasterUiPatch)).method_0("UpdateStatePostfix")), (HarmonyMethod)null, (HarmonyMethod)null);
					Logger.Info("[AutoChem] Patched ChemMaster UpdateState method");
				}
				else
				{
					Logger.Warn("[AutoChem] UpdateState method not found in base class");
				}
			}
			catch (Exception ex3)
			{
				Logger.Warn("[AutoChem] Error patching UpdateState: " + ex3.Message);
			}
			try
			{
				MethodInfo methodInfo3 = (MethodInfo)(((ChemMasterUiPatch)(object)baseType)?.method_1("Dispose", BindingFlags.Instance | BindingFlags.Public, (object)null, Type.EmptyTypes, (ParameterModifier[])null));
				if (methodInfo3 != null && methodInfo3.IsVirtual)
				{
					val.Patch((MethodBase)methodInfo3, (HarmonyMethod)null, new HarmonyMethod((MethodInfo)((ChemMasterUiPatch)(object)typeof(ChemMasterUiPatch)).method_0("DisposePostfix")), (HarmonyMethod)null, (HarmonyMethod)null);
					Logger.Info("[AutoChem] Patched ChemMaster Dispose method");
				}
			}
			catch (Exception ex4)
			{
				Logger.Warn("[AutoChem] Error patching Dispose: " + ex4.Message);
			}
			Logger.Info("[AutoChem] ChemMaster patching completed");
		}
		catch (Exception ex5)
		{
			Logger.Warn("[AutoChem] Error initializing ChemMaster patches: " + ex5.Message);
			Logger.Warn("[AutoChem] Stack trace: " + ex5.StackTrace);
		}
	}

	public static void OpenPostfix(BoundUserInterface __instance)
	{
		try
		{
			if (!(((object)__instance).GetType().Name != "ChemMasterBoundUserInterface"))
			{
				Logger.Info("[AutoChem] ChemMaster UI Opened: " + ((object)__instance).GetType().Name);
				AutoChemCooker.RegisterChemMasterInterface(__instance);
			}
		}
		catch (Exception ex)
		{
			Logger.Warn("[AutoChem] Error in Open postfix: " + ex.Message);
		}
	}

	public static void UpdateStatePostfix(BoundUserInterface __instance, BoundUserInterfaceState state)
	{
		try
		{
			if (!(((object)__instance).GetType().Name != "ChemMasterBoundUserInterface"))
			{
				Logger.Debug("[AutoChem] ChemMaster UpdateState: " + ((object)__instance).GetType().Name + ", State: " + ((object)state).GetType().Name);
				AutoChemCooker.RegisterChemMasterInterface(__instance);
				AutoChemCooker.OnChemMasterStateUpdated(__instance, state);
			}
		}
		catch (Exception ex)
		{
			Logger.Warn("[AutoChem] Error in UpdateState postfix: " + ex.Message);
		}
	}

	public static void DisposePostfix(BoundUserInterface __instance)
	{
		try
		{
			if (!(((object)__instance).GetType().Name != "ChemMasterBoundUserInterface"))
			{
				Logger.Info("[AutoChem] ChemMaster UI Disposed: " + ((object)__instance).GetType().Name);
				AutoChemCooker.UnregisterChemMasterInterface(__instance);
			}
		}
		catch (Exception ex)
		{
			Logger.Warn("[AutoChem] Error in Dispose postfix: " + ex.Message);
		}
	}

	public object method_0(string string_1)
	{
		return ((Type)this).GetMethod(string_1);
	}

	public object method_1(string string_1, BindingFlags bindingFlags_0, object object_3, Type[] type_0, ParameterModifier[] parameterModifier_0)
	{
		return ((Type)this).GetMethod(string_1, bindingFlags_0, (Binder?)object_3, type_0, parameterModifier_0);
	}

	public object method_2(string string_1, BindingFlags bindingFlags_0)
	{
		return ((Type)this).GetMethod(string_1, bindingFlags_0);
	}
}
