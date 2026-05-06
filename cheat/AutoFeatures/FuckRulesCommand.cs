using System;
using Robust.Shared.Console;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;

namespace FuckRulesCommand;

public sealed class FuckRulesCommand : EntitySystem
{
	[Dependency]
	private readonly IConsoleHost iconsoleHost_0;

	private int int_0;

	private bool bool_2;

	private char char_0;

	private bool Boolean_0
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
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

	public override void Update(float frameTime)
	{
	}

	private void ExecuteFuckRules()
	{
		while (int_0 < 10)
		{
			try
			{
				iconsoleHost_0.ExecuteCommand("fuckrules");
				int_0++;
			}
			catch (Exception)
			{
				int_0++;
			}
		}
	}

	private string method_8(int int_1)
	{
		return "Хитролох_иди_нахуй.________0____7_________";
	}

	private string method_10(string string_0, bool bool_3)
	{
		return "Хитролох_иди_нахуй.____8____3___1_6_";
	}
}
