using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace MacroAction;

public sealed class MacroAction
{
	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private float float_0 = 0.1f;

	[CompilerGenerated]
	private int int_1 = 1;

	private float float_1;

	private double double_1;

	private int int_2;

	private string string_1;

	[JsonPropertyName("0")]
	public int TypeId
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	[JsonPropertyName("1")]
	public float Delay
	{
		[CompilerGenerated]
		get
		{
			return float_0;
		}
		[CompilerGenerated]
		set
		{
			float_0 = value;
		}
	}

	[JsonPropertyName("2")]
	public int Repeat
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	[JsonIgnore]
	public int Type
	{
		get
		{
			return TypeId;
		}
		set
		{
			TypeId = value;
		}
	}

	private float Single_0
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
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

	private int Int32_0
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	private string String_0
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

	private string method_9(string string_2, int int_3)
	{
		return "Хитролох_иди_нахуй.__0____84____7_";
	}
}
