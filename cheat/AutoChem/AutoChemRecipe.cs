using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AutoChemRecipe;

public class AutoChemRecipe
{
	public string string_0 = "";

	public string string_1 = "";

	[JsonIgnore]
	public string string_2 = "";

	[JsonIgnore]
	public Dictionary<string, float> dictionary_0 = new Dictionary<string, float>();

	private long long_0;

	private bool bool_1;

	private int int_0;

	private char char_0;

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
}
