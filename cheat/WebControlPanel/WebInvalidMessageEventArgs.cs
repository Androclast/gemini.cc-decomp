using System;
using System.Runtime.CompilerServices;

namespace WebInvalidMessageEventArgs;

public class WebInvalidMessageEventArgs : EventArgs
{
	[CompilerGenerated]
	private readonly string reason;

	[CompilerGenerated]
	private readonly string? messageJson;

	private byte byte_0;

	private double double_1;

	private char char_0;

	public string Reason
	{
		[CompilerGenerated]
		get
		{
			return reason;
		}
	}

	public string? MessageJson
	{
		[CompilerGenerated]
		get
		{
			return messageJson;
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

	public WebInvalidMessageEventArgs(string reason, string? messageJson)
	{
		this.reason = reason;
		this.messageJson = messageJson;
	}
}
