using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace LicenseValidationResult;

public class LicenseValidationResult
{
	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private string? string_0;

	[CompilerGenerated]
	private DateTime? nullable_0;

	[CompilerGenerated]
	private string[]? string_1;

	private string? string_2;

	private bool bool_1;

	private double double_2;

	private bool bool_2;

	[JsonProperty("valid")]
	public bool Valid
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

	[JsonProperty("message")]
	public string? Message
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

	[JsonProperty("expiresAt")]
	public DateTime? ExpiresAt
	{
		[CompilerGenerated]
		get
		{
			return nullable_0;
		}
		[CompilerGenerated]
		set
		{
			nullable_0 = value;
		}
	}

	[JsonProperty("features")]
	public string[]? Features
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

	private string? String_0
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
			return double_2;
		}
		set
		{
			double_2 = value;
		}
	}

	private bool Boolean_1
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
}
