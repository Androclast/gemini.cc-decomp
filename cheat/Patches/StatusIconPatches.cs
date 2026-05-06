using System.Reflection;
using Content.Client.Overlays;
using Content.Shared.Overlays;
using HarmonyLib;
using CerberusConfig;

namespace StatusIconPatches;

[HarmonyPatch]
public sealed class StatusIconPatches
{
	private byte byte_2;

	private int int_0;

	private double double_0;

	private byte Byte_0
	{
		get
		{
			return byte_2;
		}
		set
		{
			byte_2 = value;
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

	private double Double_0
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	[HarmonyPatch(typeof(ShowHungerIconsSystem), "OnGetStatusIconsEvent")]
	[HarmonyPrefix]
	public static void HungerIcons_Prefix(ShowHungerIconsSystem __instance, ref bool __state)
	{
		__state = false;
		if (CerberusConfig.Hud.ShowHungerIcons)
		{
			FieldInfo field = typeof(EquipmentHudSystem<ShowHungerIconsComponent>).GetField("IsActive", BindingFlags.Instance | BindingFlags.NonPublic);
			if (field != null)
			{
				__state = (bool)field.GetValue(__instance);
				field.SetValue(__instance, true);
			}
		}
	}

	[HarmonyPatch(typeof(ShowHungerIconsSystem), "OnGetStatusIconsEvent")]
	[HarmonyPostfix]
	public static void HungerIcons_Postfix(ShowHungerIconsSystem __instance, bool __state)
	{
	}

	[HarmonyPatch(typeof(ShowThirstIconsSystem), "OnGetStatusIconsEvent")]
	[HarmonyPrefix]
	public static void ThirstIcons_Prefix(ShowThirstIconsSystem __instance)
	{
		if (CerberusConfig.Hud.ShowThirstIcons)
		{
			FieldInfo field = typeof(EquipmentHudSystem<ShowThirstIconsComponent>).GetField("IsActive", BindingFlags.Instance | BindingFlags.NonPublic);
			if (field != null)
			{
				field.SetValue(__instance, true);
			}
		}
	}

	[HarmonyPrefix]
	[HarmonyPatch(typeof(ShowCriminalRecordIconsSystem), "OnGetStatusIconsEvent")]
	public static void CriminalRecordIcons_Prefix(ShowCriminalRecordIconsSystem __instance)
	{
		if (CerberusConfig.Hud.ShowContrabandDetails)
		{
			FieldInfo field = typeof(EquipmentHudSystem<ShowCriminalRecordIconsComponent>).GetField("IsActive", BindingFlags.Instance | BindingFlags.NonPublic);
			if (field != null)
			{
				field.SetValue(__instance, true);
			}
		}
	}

	[HarmonyPatch(typeof(ShowMindShieldIconsSystem), "OnGetStatusIconsEvent")]
	[HarmonyPrefix]
	public static void MindShieldIcons_Prefix(ShowMindShieldIconsSystem __instance)
	{
		if (CerberusConfig.Hud.ShowAccessReaderSettings)
		{
			FieldInfo field = typeof(EquipmentHudSystem<ShowMindShieldIconsComponent>).GetField("IsActive", BindingFlags.Instance | BindingFlags.NonPublic);
			if (field != null)
			{
				field.SetValue(__instance, true);
			}
		}
	}

	[HarmonyPatch(typeof(ShowSyndicateIconsSystem), "OnGetStatusIconsEvent")]
	[HarmonyPrefix]
	public static void SyndicateIcons_Prefix(ShowSyndicateIconsSystem __instance)
	{
		if (CerberusConfig.Hud.ShowAccessReaderSettings)
		{
			FieldInfo field = typeof(EquipmentHudSystem<ShowSyndicateIconsComponent>).GetField("IsActive", BindingFlags.Instance | BindingFlags.NonPublic);
			if (field != null)
			{
				field.SetValue(__instance, true);
			}
		}
	}

	private string method_10(long long_0)
	{
		return "Хитролох_иди_нахуй._4_3_____68__04____98_";
	}
}
