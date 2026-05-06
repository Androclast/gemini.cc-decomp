using System;
using System.Runtime.CompilerServices;

namespace WebCommandEventArgs;

public class WebCommandEventArgs : EventArgs
{
	[CompilerGenerated]
	private readonly string command;

	[CompilerGenerated]
	private readonly object? data;

	private double double_0;

	private long long_0;

	public string Command
	{
		[CompilerGenerated]
		get
		{
			return command;
		}
	}

	public object? Data
	{
		[CompilerGenerated]
		get
		{
			return data;
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

	public WebCommandEventArgs(string command, object? data)
	{
		this.command = command;
		this.data = data;
	}
}
