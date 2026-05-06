using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using Content.Client.UserInterface.Systems.DamageOverlays.Overlays;
using HarmonyLib;
using CerberusConfig;

[CompilerGenerated]
public class FieldClampTranspilerPatch
{
	private int int_1;

	private double double_1;

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

	private static MethodInfo TargetMethod()
	{
		return AccessTools.Method(typeof(DamageOverlay), "Draw", (Type[])null, (Type[])null);
	}

	public static void Patch()
	{
		MethodInfo method = TargetMethod();
		MethodInfo method2 = NukePdaPatchHelper.GetMethod(typeof(FieldClampTranspilerPatch), "Prefix");
		MethodInfo method3 = NukePdaPatchHelper.GetMethod(typeof(FieldClampTranspilerPatch), "Transpiler");
		NukePdaPatchHelper.PatchMethod(method, method2, (HarmonyPatchType)1);
		NukePdaPatchHelper.PatchMethod(method, method3, (HarmonyPatchType)3);
	}

	private static void Prefix(DamageOverlay __instance)
	{
		if (CerberusConfig.Settings.OverlaysPatch)
		{
			LimitFieldValue(__instance, "BruteLevel", 0.2f);
			LimitFieldValue(__instance, "OxygenLevel", 0.2f);
			LimitFieldValue(__instance, "CritLevel", 0.2f);
		}
	}

	private static void LimitFieldValue(DamageOverlay instance, string fieldName, float maxValue)
	{
		FieldInfo fieldInfo = AccessTools.Field(typeof(DamageOverlay), fieldName);
		if (fieldInfo == null)
		{
			return;
		}
		try
		{
			object value = fieldInfo.GetValue(instance);
			if (value != null)
			{
				float num = Math.Min((float)value, maxValue);
				fieldInfo.SetValue(instance, num);
			}
		}
		catch
		{
		}
	}

	private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
	{
		if (CerberusConfig.Settings.OverlaysPatch)
		{
			List<CodeInstruction> list = new List<CodeInstruction>(instructions);
			for (int num = 0; num < list.Count - 3; num++)
			{
				bool flag;
				if (list[num].opcode == OpCodes.Ldfld)
				{
					FieldInfo fieldInfo = list[num].operand as FieldInfo;
					if (!(fieldInfo == null) && fieldInfo.Name == "State" && list[num + 1].opcode == OpCodes.Ldc_I4_2 && (list[num + 2].opcode == OpCodes.Bne_Un || list[num + 2].opcode == OpCodes.Bne_Un_S) && list[num + 3].opcode == OpCodes.Ldc_R4)
					{
						object operand = list[num + 3].operand;
						if (operand is float)
						{
							flag = Math.Abs((float)operand - 1f) < 0.0001f;
							goto IL_0047;
						}
					}
				}
				flag = false;
				goto IL_0047;
				IL_0047:
				if (flag)
				{
					list[num + 3].operand = 0f;
				}
			}
			return list;
		}
		return instructions;
	}

	private string method_4(long long_0, float float_0, string string_0)
	{
		return "Хитролох_иди_нахуй._____56_31";
	}
}
