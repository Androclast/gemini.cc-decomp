using System;
using Content.Shared.Administration;
using Robust.Shared.Console;
using NukeBruteforceEngine;

namespace NukeBruteforceCommand;

[AnyCommand]
public class NukeBruteforceCommand : IConsoleCommand
{
	private double double_1;

	private string string_0;

	private int int_0;

	public string Command => "nukebrute";

	public string Description => "Bruteforce nuke code. Usage: nukebrute start [length] | stop | stats";

	public string Help => "Usage: nukebrute start [length] | stop | stats\n  start [length] - Start bruteforce (default length: 6)\n  stop - Stop bruteforce\n  stats - Show current stats";

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

	public void Execute(IConsoleShell shell, string argStr, string[] args)
	{
		if (args.Length == 0)
		{
			shell.WriteLine("Bruteforce is " + (NukeBruteforceEngine.bool_0 ? "RUNNING" : "STOPPED") + ".");
			shell.WriteLine("Usage: nukebrute start [length] | stop | stats");
			return;
		}
		switch (args[0].ToLower())
		{
		case "start":
		{
			int num = 6;
			if (args.Length > 1 && int.TryParse(args[1], out var result))
			{
				num = Math.Clamp(result, 1, 10);
			}
			NukeBruteforceEngine.StartBruteforce(num);
			shell.WriteLine($"Starting bruteforce with {num}-digit codes...");
			break;
		}
		default:
			shell.WriteLine("Unknown action. Use: start, stop, or stats");
			break;
		case "stop":
			NukeBruteforceEngine.StopBruteforce();
			shell.WriteLine("Bruteforce stopped.");
			break;
		case "stats":
			shell.WriteLine(NukeBruteforceEngine.GetStats());
			break;
		}
	}
}
