using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using MacroAction;

namespace Macro;

public sealed class Macro
{
	[CompilerGenerated]
	private string string_0 = "New Combo";

	[CompilerGenerated]
	private List<MacroAction> list_0 = new List<MacroAction>();

	[CompilerGenerated]
	private string string_1 = "NONE";

	[CompilerGenerated]
	private bool bool_0 = true;

	private char char_3;

	private long long_0;

	private double double_0;

	private string string_3;

	[JsonPropertyName("n")]
	public string Name
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	[JsonPropertyName("a")]
	public List<MacroAction> Actions
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
		[CompilerGenerated]
		set
		{
			list_0 = value;
		}
	}

	[JsonPropertyName("h")]
	public string Hotkey
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	[JsonPropertyName("e")]
	public bool Enabled
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	private char Char_0
	{
		get
		{
			return char_3;
		}
		set
		{
			char_3 = value;
		}
	}

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

	private string String_0
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	private string method_6(float float_0)
	{
		return "Хитролох_иди_нахуй.____9_____5________9__7_";
	}
}
