using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TelemetryEvent;
using PerformanceMetrics;

namespace TelemetryBatch;

public class TelemetryBatch
{
	[CompilerGenerated]
	private string string_0 = string.Empty;

	[CompilerGenerated]
	private string string_1 = string.Empty;

	[CompilerGenerated]
	private DateTime dateTime_0;

	[CompilerGenerated]
	private List<TelemetryEvent> list_0 = new List<TelemetryEvent>();

	[CompilerGenerated]
	private PerformanceMetrics gclass158_0 = new PerformanceMetrics();

	private float float_1;

	private bool bool_0;

	private char char_0;

	public string Hwid
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

	public string SessionId
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

	public DateTime Timestamp
	{
		[CompilerGenerated]
		get
		{
			return dateTime_0;
		}
		[CompilerGenerated]
		set
		{
			dateTime_0 = value;
		}
	}

	public List<TelemetryEvent> Events
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

	public PerformanceMetrics Performance
	{
		[CompilerGenerated]
		get
		{
			return gclass158_0;
		}
		[CompilerGenerated]
		set
		{
			gclass158_0 = value;
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

	private bool Boolean_0
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
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
