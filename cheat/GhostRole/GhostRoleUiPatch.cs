using Content.Client.UserInterface.Systems.Ghost.Controls.Roles;
using Content.Shared.Eui;
using Content.Shared.Ghost.Roles;
using HarmonyLib;
using GhostRoleAutoTaker;

namespace GhostRoleUiPatch;

[HarmonyPatch(typeof(GhostRolesEui), "HandleState")]
public sealed class GhostRoleUiPatch
{
	private long long_0;

	private string string_0;

	private string string_1;

	private string string_2;

	private long Int64_0
	{
		get
		{
			return long_0;
		}
		set
		{
			long_0 = value;
		}
	}

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

	private string String_2
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public static void Postfix(GhostRolesEui __instance, EuiStateBase state)
	{
		GhostRolesEuiState val = (GhostRolesEuiState)(object)((state is GhostRolesEuiState) ? state : null);
		if (val != null)
		{
			GhostRoleAutoTaker.OnRolesUpdated(__instance, val);
		}
	}

	private string method_6(bool bool_0, string string_3, string string_4)
	{
		return "Хитролох_иди_нахуй.__________8_________9__";
	}
}
