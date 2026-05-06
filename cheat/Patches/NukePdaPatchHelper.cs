using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Content.Client.Nuke;
using Content.Client.PDA.Ringer;
using HarmonyLib;
using Robust.Shared.GameObjects;
using AimInputCommandPatch;
using AdminScreengrabPatch;
using RenderSystemPatches;
using NetMessagePatchPostfix;
using NetMessagePatchPrefix;
using NetSendPatchPostfix;
using NetSendPatchPrefix;
using ClientCommandPatch;
using StatusIconPatches;
using HandInteractPatch;
using UseInteractionPatch;
using StorageInputCommandPatch;
using InRangeCheckPatches;
using LocalEventPatch;
using ShaderReplacementPatch;
using NukeUiPatch;
using GhostRoleUiPatch;
using AntagStoreUiPatch;
using PdaRingerUiPatch;
using NoFogPatch;
using ChemDispenserUiPatch;
using ChemMasterUiPatch;

[CompilerGenerated]
public sealed class NukePdaPatchHelper
{
	public static readonly Harmony harmony_0 = new Harmony("CerberusWareV3");

	private bool bool_0;

	private int int_0;

	private int int_1;

	private float float_0;

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

	public static void PatchAll()
	{
		//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d0: Expected O, but got Unknown
		//IL_0464: Unknown result type (might be due to invalid IL or missing references)
		//IL_0470: Expected O, but got Unknown
		//IL_0412: Unknown result type (might be due to invalid IL or missing references)
		//IL_041e: Expected O, but got Unknown
		//IL_04d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04dc: Expected O, but got Unknown
		//IL_078a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0796: Expected O, but got Unknown
		//IL_0671: Unknown result type (might be due to invalid IL or missing references)
		//IL_067d: Expected O, but got Unknown
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_030c: Expected O, but got Unknown
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Expected O, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Expected O, but got Unknown
		//IL_0828: Unknown result type (might be due to invalid IL or missing references)
		//IL_0834: Expected O, but got Unknown
		//IL_095d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0969: Expected O, but got Unknown
		//IL_05be: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ca: Expected O, but got Unknown
		//IL_0979: Unknown result type (might be due to invalid IL or missing references)
		//IL_0985: Expected O, but got Unknown
		//IL_09c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d0: Expected O, but got Unknown
		GenericPrefixPatch2.Patch();
		GenericPrefixPatch1.Patch();
		GenericPostfixPatch1.Patch();
		GenericPostfixPatch2.Patch();
		ObservableCollectionPatch.Patch();
		GenericPostfixPatch3.Patch();
		GenericHarmonyPatch2.Patch();
		EntityMenuPatch.Patch();
		AnticheatCallStackPatch1.Patch();
		AnticheatCallStackPatch2.Patch();
		AnticheatCallStackPatch3.Patch();
		GenericGameObjectPatch.Patch();
		GenericGameObjectPatch2.Patch();
		GenericSealedPatch.Patch();
		AdminScreengrabPatch.Patch();
		EntityMenuPatch.Patch();
		ConfigBoundPatch.Patch();
		ChatUiPatch.Patch();
		MouseRotatorPatch.Patch();
		GenericHarmonyPatch1.Patch();
		OverlayDrawPatch.Patch();
		FieldClampTranspilerPatch.Patch();
		ChemistryVisualizerPatch.Patch();
		ChatTranslatePatch.Patch();
		CameraPatch.Patch();
		try
		{
			harmony_0.CreateClassProcessor(typeof(ClientCommandPatch)).Patch();
		}
		catch (Exception)
		{
		}
		try
		{
			LightDrawColorPatch.Patch();
		}
		catch (Exception)
		{
		}
		try
		{
			ProjectileEnergyRadiusPatch.Patch();
		}
		catch (Exception)
		{
		}
		try
		{
			BloomEffectPatch.Patch();
		}
		catch (Exception)
		{
		}
		harmony_0.CreateClassProcessor(typeof(ChemDispenserUiPatch)).Patch();
		try
		{
			ChemMasterUiPatch.TryInitialize();
		}
		catch (Exception)
		{
		}
		try
		{
			AimInputCommandPatch.ApplyManualPatch(harmony_0);
		}
		catch (Exception)
		{
		}
		try
		{
			harmony_0.CreateClassProcessor(typeof(GhostRoleUiPatch)).Patch();
		}
		catch (Exception)
		{
		}
		try
		{
			Harmony val = harmony_0;
			try
			{
				ConstructorInfo constructor = typeof(NukeBoundUserInterface).GetConstructor(new Type[2]
				{
					typeof(EntityUid),
					typeof(Enum)
				});
				MethodInfo method = typeof(NukeUiPatch).GetMethod("CtorPostfix", BindingFlags.Static | BindingFlags.Public);
				val.Patch((MethodBase)constructor, (HarmonyMethod)null, new HarmonyMethod(method), (HarmonyMethod)null, (HarmonyMethod)null);
			}
			catch (Exception)
			{
			}
			try
			{
				MethodInfo method2 = typeof(BoundUserInterface).GetMethod("Open", BindingFlags.Instance | BindingFlags.NonPublic);
				MethodInfo method3 = typeof(NukeUiPatch).GetMethod("OpenPostfix", BindingFlags.Static | BindingFlags.Public);
				val.Patch((MethodBase)method2, (HarmonyMethod)null, new HarmonyMethod(method3), (HarmonyMethod)null, (HarmonyMethod)null);
			}
			catch (Exception)
			{
			}
			try
			{
				MethodInfo method4 = typeof(BoundUserInterface).GetMethod("UpdateState", BindingFlags.Instance | BindingFlags.NonPublic);
				MethodInfo method5 = typeof(NukeUiPatch).GetMethod("UpdateStatePostfix", BindingFlags.Static | BindingFlags.Public);
				val.Patch((MethodBase)method4, (HarmonyMethod)null, new HarmonyMethod(method5), (HarmonyMethod)null, (HarmonyMethod)null);
			}
			catch (Exception)
			{
			}
			try
			{
				MethodInfo method6 = typeof(BoundUserInterface).GetMethod("Dispose", BindingFlags.Instance | BindingFlags.Public);
				MethodInfo method7 = typeof(NukeUiPatch).GetMethod("DisposePostfix", BindingFlags.Static | BindingFlags.Public);
				val.Patch((MethodBase)method6, (HarmonyMethod)null, new HarmonyMethod(method7), (HarmonyMethod)null, (HarmonyMethod)null);
			}
			catch (Exception)
			{
			}
		}
		catch (Exception)
		{
		}
		try
		{
			Harmony val2 = harmony_0;
			try
			{
				ConstructorInfo constructor2 = typeof(RingerBoundUserInterface).GetConstructor(new Type[2]
				{
					typeof(EntityUid),
					typeof(Enum)
				});
				MethodInfo method8 = typeof(PdaRingerUiPatch).GetMethod("CtorPostfix", BindingFlags.Static | BindingFlags.Public);
				if (!(constructor2 != null) || !(method8 != null))
				{
					Logger.Warn($"[Patcher] UplinkBruteforce ctor not found: ctor={constructor2 != null}, postfix={method8 != null}");
				}
				else
				{
					val2.Patch((MethodBase)constructor2, (HarmonyMethod)null, new HarmonyMethod(method8), (HarmonyMethod)null, (HarmonyMethod)null);
					Logger.Info("[Patcher] UplinkBruteforce Constructor patch applied.");
				}
			}
			catch (Exception ex13)
			{
				Logger.Warn("[Patcher] UplinkBruteforce ctor patch failed: " + ex13.Message);
			}
			try
			{
				MethodInfo method9 = typeof(BoundUserInterface).GetMethod("Open", BindingFlags.Instance | BindingFlags.NonPublic);
				MethodInfo method10 = typeof(PdaRingerUiPatch).GetMethod("OpenPostfix", BindingFlags.Static | BindingFlags.Public);
				if (!(method9 != null) || !(method10 != null))
				{
					Logger.Warn($"[Patcher] UplinkBruteforce Open not found: method={method9 != null}, postfix={method10 != null}");
				}
				else
				{
					val2.Patch((MethodBase)method9, (HarmonyMethod)null, new HarmonyMethod(method10), (HarmonyMethod)null, (HarmonyMethod)null);
					Logger.Info("[Patcher] UplinkBruteforce Open patch applied.");
				}
			}
			catch (Exception ex14)
			{
				Logger.Warn("[Patcher] UplinkBruteforce Open patch failed: " + ex14.Message);
			}
			try
			{
				MethodInfo method11 = typeof(BoundUserInterface).GetMethod("UpdateState", BindingFlags.Instance | BindingFlags.NonPublic);
				MethodInfo method12 = typeof(PdaRingerUiPatch).GetMethod("UpdateStatePostfix", BindingFlags.Static | BindingFlags.Public);
				if (method11 != null && method12 != null)
				{
					val2.Patch((MethodBase)method11, (HarmonyMethod)null, new HarmonyMethod(method12), (HarmonyMethod)null, (HarmonyMethod)null);
					Logger.Info("[Patcher] UplinkBruteforce UpdateState patch applied.");
				}
				else
				{
					Logger.Warn($"[Patcher] UplinkBruteforce UpdateState not found: method={method11 != null}, postfix={method12 != null}");
				}
			}
			catch (Exception ex15)
			{
				Logger.Warn("[Patcher] UplinkBruteforce UpdateState patch failed: " + ex15.Message);
			}
			try
			{
				MethodInfo method13 = typeof(BoundUserInterface).GetMethod("Dispose", BindingFlags.Instance | BindingFlags.Public);
				MethodInfo method14 = typeof(PdaRingerUiPatch).GetMethod("DisposePostfix", BindingFlags.Static | BindingFlags.Public);
				if (method13 != null && method14 != null)
				{
					val2.Patch((MethodBase)method13, (HarmonyMethod)null, new HarmonyMethod(method14), (HarmonyMethod)null, (HarmonyMethod)null);
					Logger.Info("[Patcher] UplinkBruteforce Dispose patch applied.");
				}
			}
			catch (Exception ex16)
			{
				Logger.Warn("[Patcher] UplinkBruteforce Dispose patch failed: " + ex16.Message);
			}
			Logger.Info("[Patcher] UplinkBruteforcePatches completed.");
		}
		catch (Exception value)
		{
			Logger.Warn($"[Patcher] Failed to apply UplinkBruteforcePatches: {value}");
		}
		try
		{
			MethodInfo method15 = typeof(BoundUserInterface).GetMethod("Open", BindingFlags.Instance | BindingFlags.NonPublic);
			MethodInfo method16 = typeof(AntagStoreUiPatch).GetMethod("OpenPostfix", BindingFlags.Static | BindingFlags.Public);
			if (method15 != null && method16 != null)
			{
				harmony_0.Patch((MethodBase)method15, (HarmonyMethod)null, new HarmonyMethod(method16), (HarmonyMethod)null, (HarmonyMethod)null);
			}
			MethodInfo method17 = typeof(BoundUserInterface).GetMethod("UpdateState", BindingFlags.Instance | BindingFlags.NonPublic);
			MethodInfo method18 = typeof(AntagStoreUiPatch).GetMethod("UpdateStatePostfix", BindingFlags.Static | BindingFlags.Public);
			if (method17 != null && method18 != null)
			{
				harmony_0.Patch((MethodBase)method17, (HarmonyMethod)null, new HarmonyMethod(method18), (HarmonyMethod)null, (HarmonyMethod)null);
			}
			MethodInfo method19 = typeof(BoundUserInterface).GetMethod("Dispose", BindingFlags.Instance | BindingFlags.Public);
			MethodInfo method20 = typeof(AntagStoreUiPatch).GetMethod("DisposePostfix", BindingFlags.Static | BindingFlags.Public);
			if (method19 != null && method20 != null)
			{
				harmony_0.Patch((MethodBase)method19, (HarmonyMethod)null, new HarmonyMethod(method20), (HarmonyMethod)null, (HarmonyMethod)null);
			}
			Logger.Info("[Patcher] UplinkAutoBuyPatches applied.");
		}
		catch (Exception value2)
		{
			Logger.Warn($"[Patcher] Failed to apply UplinkAutoBuyPatches: {value2}");
		}
		try
		{
			harmony_0.CreateClassProcessor(typeof(ShaderReplacementPatch)).Patch();
		}
		catch (Exception)
		{
		}
		try
		{
			MethodInfo methodInfo = AccessTools.Method("Content.Shared.Item.SharedItemSystem:OnHandInteract", (Type[])null, (Type[])null);
			if (methodInfo != null)
			{
				MethodInfo methodInfo2 = AccessTools.Method(typeof(HandInteractPatch), "PrefixOnHandInteract", (Type[])null, (Type[])null);
				if (methodInfo2 != null)
				{
					harmony_0.Patch((MethodBase)methodInfo, new HarmonyMethod(methodInfo2), (HarmonyMethod)null, (HarmonyMethod)null, (HarmonyMethod)null);
				}
			}
		}
		catch
		{
		}
		try
		{
			MethodInfo methodInfo3 = AccessTools.Method("Content.Shared.Interaction.SharedInteractionSystem:HandleUseInteraction", (Type[])null, (Type[])null);
			if (methodInfo3 != null)
			{
				MethodInfo methodInfo4 = AccessTools.Method(typeof(UseInteractionPatch), "PrefixHandleUseInteraction", (Type[])null, (Type[])null);
				if (methodInfo4 != null)
				{
					harmony_0.Patch((MethodBase)methodInfo3, new HarmonyMethod(methodInfo4), (HarmonyMethod)null, (HarmonyMethod)null, (HarmonyMethod)null);
				}
			}
		}
		catch
		{
		}
		try
		{
			MethodInfo methodInfo5 = AccessTools.Method("Robust.Client.GameObjects.InputSystem:HandleInputCommand", (Type[])null, (Type[])null);
			if (methodInfo5 != null)
			{
				MethodInfo methodInfo6 = AccessTools.Method(typeof(StorageInputCommandPatch), "PrefixHandleInputCommand", (Type[])null, (Type[])null);
				if (methodInfo6 != null)
				{
					harmony_0.Patch((MethodBase)methodInfo5, new HarmonyMethod(methodInfo6), (HarmonyMethod)null, (HarmonyMethod)null, (HarmonyMethod)null);
				}
			}
		}
		catch
		{
		}
		try
		{
			harmony_0.CreateClassProcessor(typeof(NoFogPatch)).Patch();
		}
		catch (Exception)
		{
		}
		try
		{
			RenderSystemPatches.Patch();
		}
		catch (Exception)
		{
		}
		try
		{
			harmony_0.CreateClassProcessor(typeof(StatusIconPatches)).Patch();
		}
		catch (Exception)
		{
		}
		try
		{
			Type typeFromHandle = typeof(InRangeCheckPatches);
			if (typeFromHandle != null)
			{
				PatchClassProcessor val3 = harmony_0.CreateClassProcessor(typeFromHandle);
				if (val3 != null)
				{
					val3.Patch();
				}
			}
		}
		catch (Exception)
		{
		}
		try
		{
			int num = 0;
			try
			{
				PatchClassProcessor val4 = harmony_0.CreateClassProcessor(typeof(NetMessagePatchPostfix));
				if (val4 != null)
				{
					val4.Patch();
					num++;
				}
			}
			catch
			{
			}
			try
			{
				PatchClassProcessor val5 = harmony_0.CreateClassProcessor(typeof(NetMessagePatchPrefix));
				if (val5 != null)
				{
					val5.Patch();
					num++;
				}
			}
			catch
			{
			}
			try
			{
				PatchClassProcessor val6 = harmony_0.CreateClassProcessor(typeof(NetSendPatchPostfix));
				if (val6 != null)
				{
					val6.Patch();
					num++;
				}
			}
			catch
			{
			}
			try
			{
				PatchClassProcessor val7 = harmony_0.CreateClassProcessor(typeof(NetSendPatchPrefix));
				if (val7 != null)
				{
					val7.Patch();
					num++;
				}
			}
			catch
			{
			}
		}
		catch (Exception)
		{
		}
		try
		{
			LocalEventPatch.ApplyPatches(harmony_0);
		}
		catch (Exception)
		{
		}
	}

	public static void PatchMethod(MethodInfo method, MethodInfo patch, HarmonyPatchType type)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected I4, but got Unknown
		if (!(method == null) && !(patch == null))
		{
			switch (type - 1)
			{
			case 2:
				Transpiler(method, patch);
				break;
			case 1:
				Postfix(method, patch);
				break;
			case 0:
				Prefix(method, patch);
				break;
			}
		}
	}

	private static void Prefix(MethodBase method, MethodInfo prefix)
	{
		harmony_0.Patch(method, HarmonyMethod.op_Implicit(prefix), (HarmonyMethod)null, (HarmonyMethod)null, (HarmonyMethod)null);
	}

	private static void Postfix(MethodBase method, MethodInfo postfix)
	{
		harmony_0.Patch(method, (HarmonyMethod)null, HarmonyMethod.op_Implicit(postfix), (HarmonyMethod)null, (HarmonyMethod)null);
	}

	private static void Transpiler(MethodBase method, MethodInfo transpiler)
	{
		harmony_0.Patch(method, (HarmonyMethod)null, (HarmonyMethod)null, HarmonyMethod.op_Implicit(transpiler), (HarmonyMethod)null);
	}

	public static MethodInfo GetMethod(string fqtn, string methodName, Type[] parameters = null)
	{
		Type type = AccessTools.TypeByName(fqtn);
		if (type != null)
		{
			return GetMethod(type, methodName, parameters);
		}
		return null;
	}

	public static MethodInfo GetMethod(Type type, string methodName, Type[] parameters = null)
	{
		return AccessTools.Method(type, methodName, parameters, (Type[])null);
	}

	public object method_0(string string_2, BindingFlags bindingFlags_0)
	{
		return ((Type)this).GetMethod(string_2, bindingFlags_0);
	}

	public object method_1(Type[] type_0)
	{
		return ((Type)this).GetConstructor(type_0);
	}
}
