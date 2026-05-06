using System.Linq;
using Content.Shared.Administration;
using Robust.Shared.Console;
using GhostRoleAutoTaker;

namespace GhostRoleAutoTakeCommand;

[AnyCommand]
public class GhostRoleAutoTakeCommand : IConsoleCommand
{
	private byte byte_0;

	private string string_0;

	public string Command => "autorole";

	public string Description => "Manage auto-take ghost roles. Usage: autorole add <name> | remove <name> | list | toggle";

	public string Help => "Usage: autorole add <name> | remove <name> | list | toggle";

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

	public void Execute(IConsoleShell shell, string argStr, string[] args)
	{
		if (args.Length == 0)
		{
			shell.WriteLine("AutoGhostRole is " + ((!GhostRoleAutoTaker.bool_0) ? "DISABLED" : "ENABLED") + ".");
			return;
		}
		switch (args[0].ToLower())
		{
		case "remove":
			if (args.Length >= 2)
			{
				string text = string.Join(" ", args.Skip(1));
				GhostRoleAutoTaker.hashSet_0.Remove(text);
				shell.WriteLine("Removed '" + text + "'");
			}
			break;
		case "clear":
			GhostRoleAutoTaker.hashSet_0.Clear();
			shell.WriteLine("Cleared.");
			break;
		case "add":
			if (args.Length >= 2)
			{
				string text2 = string.Join(" ", args.Skip(1));
				GhostRoleAutoTaker.hashSet_0.Add(text2);
				shell.WriteLine("Added '" + text2 + "'");
			}
			break;
		case "list":
			shell.WriteLine("Wanted Roles: " + string.Join(", ", GhostRoleAutoTaker.hashSet_0));
			break;
		case "toggle":
			GhostRoleAutoTaker.bool_0 = !GhostRoleAutoTaker.bool_0;
			shell.WriteLine("AutoGhostRole is now " + (GhostRoleAutoTaker.bool_0 ? "ENABLED" : "DISABLED") + ".");
			break;
		}
	}
}
