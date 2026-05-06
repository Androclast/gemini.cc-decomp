using System;
using System.Runtime.CompilerServices;
using EndpointCheckResult;

namespace EndpointValidationSummary;

public class EndpointValidationSummary
{
	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private int int_1;

	[CompilerGenerated]
	private string[] string_0 = Array.Empty<string>();

	[CompilerGenerated]
	private EndpointCheckResult[] gclass140_0 = Array.Empty<EndpointCheckResult>();

	private bool bool_1;

	private byte byte_0;

	private string string_2;

	private char char_0;

	public bool AllEndpointsAvailable
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

	public int TotalEndpoints
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

	public int AvailableEndpoints
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

	public string[] FailedEndpoints
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

	public EndpointCheckResult[] Results
	{
		[CompilerGenerated]
		get
		{
			return gclass140_0;
		}
		[CompilerGenerated]
		set
		{
			gclass140_0 = value;
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
			return string_2;
		}
		set
		{
			string_2 = value;
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
