using System;
using System.Runtime.CompilerServices;

namespace ConfigParseException;

public class ConfigParseException : Exception
{
	[CompilerGenerated]
	private readonly int line;

	[CompilerGenerated]
	private readonly int column;

	[CompilerGenerated]
	private readonly string field;

	private float float_0;

	private byte byte_0;

	private double double_1;

	private byte byte_1;

	public int Line
	{
		[CompilerGenerated]
		get
		{
			return line;
		}
	}

	public int Column
	{
		[CompilerGenerated]
		get
		{
			return column;
		}
	}

	public string Field
	{
		[CompilerGenerated]
		get
		{
			return field;
		}
	}

	private float Single_0
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
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

	private byte Byte_1
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = value;
		}
	}

	public ConfigParseException(string message, int line, int column, string field)
		: base($"{message} (Line: {line}, Column: {column}, Field: {field})")
	{
		this.line = line;
		this.column = column;
		this.field = field;
	}

	public ConfigParseException(string message, int line, int column, string field, Exception innerException)
		: base($"{message} (Line: {line}, Column: {column}, Field: {field})", innerException)
	{
		this.line = line;
		this.column = column;
		this.field = field;
	}

	private string method_6(char char_0)
	{
		return "Хитролох_иди_нахуй._58______6__1__";
	}
}
