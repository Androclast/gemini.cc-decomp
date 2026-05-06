using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Content.Client.Eui;
using Content.Client.UserInterface.Systems.Ghost.Controls.Roles;
using Content.Shared.Ghost.Roles;

namespace GhostRoleAutoTaker;

public sealed class GhostRoleAutoTaker
{
	public static HashSet<string> hashSet_0 = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

	public static bool bool_0 = false;

	public static int int_0 = 0;

	private static MethodInfo methodInfo_0;

	private static bool bool_1 = false;

	private char char_0;

	private char char_1;

	private byte byte_1;

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

	private char Char_1
	{
		get
		{
			return char_1;
		}
		set
		{
			char_1 = value;
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

	public static void OnRolesUpdated(GhostRolesEui eui, GhostRolesEuiState state)
	{
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		if (!bool_0 || state.GhostRoles == null || bool_1)
		{
			return;
		}
		if (methodInfo_0 == null)
		{
			methodInfo_0 = (MethodInfo)((GhostRoleAutoTaker)(object)typeof(BaseEui)).method_0("SendMessage", BindingFlags.Instance | BindingFlags.NonPublic);
		}
		List<GhostRoleInfo> e3UksTHBBj = state.GhostRoles.Where((GhostRoleInfo role) => (int)((GhostRoleInfo)(ref role)).Kind != 3 && hashSet_0.Any((string wanted) => ((GhostRoleInfo)(ref role)).Name.Contains(wanted, StringComparison.OrdinalIgnoreCase))).ToList();
		if (e3UksTHBBj.Count == 0)
		{
			return;
		}
		if (int_0 > 0)
		{
			bool_1 = true;
			Task.Run(async delegate
			{
				try
				{
					foreach (GhostRoleInfo item in e3UksTHBBj)
					{
						GhostRoleInfo val2 = item;
						await Task.Delay(int_0);
						RequestGhostRoleMessage val3 = new RequestGhostRoleMessage(((GhostRoleInfo)(ref val2)).Identifier);
						methodInfo_0?.Invoke(eui, new object[1] { val3 });
						val2 = default(GhostRoleInfo);
					}
				}
				finally
				{
					bool_1 = false;
				}
			});
			return;
		}
		foreach (GhostRoleInfo item2 in e3UksTHBBj)
		{
			GhostRoleInfo current = item2;
			RequestGhostRoleMessage val = new RequestGhostRoleMessage(((GhostRoleInfo)(ref current)).Identifier);
			methodInfo_0?.Invoke(eui, new object[1] { val });
		}
	}

	public object method_0(string string_0, BindingFlags bindingFlags_0)
	{
		return ((Type)this).GetMethod(string_0, bindingFlags_0);
	}
}
