using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

public class TranslationResult
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private string string_2;

	[CompilerGenerated]
	private string string_3;

	[CompilerGenerated]
	private JsonElement jsonElement_0;

	[CompilerGenerated]
	private JsonElement jsonElement_1;

	[CompilerGenerated]
	private JsonElement jsonElement_2;

	[CompilerGenerated]
	private JsonElement jsonElement_3;

	private char char_0;

	private string string_5;

	[JsonPropertyName("source-language")]
	public string SourceLanguage
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

	[JsonPropertyName("source-text")]
	public string SourceText
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

	[JsonPropertyName("destination-language")]
	public string DestinationLanguage
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
		[CompilerGenerated]
		set
		{
			string_2 = value;
		}
	}

	[JsonPropertyName("destination-text")]
	public string DestinationText
	{
		[CompilerGenerated]
		get
		{
			return string_3;
		}
		[CompilerGenerated]
		set
		{
			string_3 = value;
		}
	}

	public JsonElement Translations
	{
		[CompilerGenerated]
		get
		{
			return jsonElement_0;
		}
		[CompilerGenerated]
		set
		{
			jsonElement_0 = value;
		}
	}

	public JsonElement Pronunciation
	{
		[CompilerGenerated]
		get
		{
			return jsonElement_1;
		}
		[CompilerGenerated]
		set
		{
			jsonElement_1 = value;
		}
	}

	public JsonElement Definitions
	{
		[CompilerGenerated]
		get
		{
			return jsonElement_2;
		}
		[CompilerGenerated]
		set
		{
			jsonElement_2 = value;
		}
	}

	[JsonPropertyName("see-also")]
	public JsonElement SeeAlso
	{
		[CompilerGenerated]
		get
		{
			return jsonElement_3;
		}
		[CompilerGenerated]
		set
		{
			jsonElement_3 = value;
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

	private string String_0
	{
		get
		{
			return string_5;
		}
		set
		{
			string_5 = value;
		}
	}
}
