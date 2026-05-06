using Content.Shared.Administration;
using Robust.Shared.Console;
using AutoChemCooker;

namespace AutoChemCommand;

[AnyCommand]
public class AutoChemCommand : IConsoleCommand
{
	private long long_0;

	private bool bool_1;

	private double double_1;

	private double double_2;

	public string Command => "autochem";

	public string Description => "Dispense reagent. Usage: autochem <name> [amount]";

	public string Help => "Usage: autochem <name> [amount]";

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

	private double Double_1
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
		}
	}

	public void Execute(IConsoleShell shell, string argStr, string[] args)
	{
		if (args.Length < 1)
		{
			shell.WriteLine("Usage: autochem <name> [amount]");
			return;
		}
		string text = args[0];
		int num = 10;
		if (args.Length > 1 && int.TryParse(args[1], out var result))
		{
			num = result;
		}
		Logger.Info($"[AutoChem] Command executed: autochem {text} {num}");
		AutoChemCooker.TryDispense(text, num);
	}
}
