using System;
using System.Runtime.CompilerServices;

namespace ConfigIdAttribute;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public sealed class ConfigIdAttribute : Attribute
{
	[CompilerGenerated]
	private readonly string id;

	[CompilerGenerated]
	private int int_0 = 1;

	[CompilerGenerated]
	private string string_0 = "";

	private byte byte_1;

	private int int_1;

	public string Id
	{
		[CompilerGenerated]
		get
		{
			return id;
		}
	}

	public int Version
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

	public string Description
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

	private byte Byte_0
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

	private int Int32_0
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public ConfigIdAttribute(string id)
	{
		if (!string.IsNullOrWhiteSpace(id))
		{
			this.id = id;
			return;
		}
		throw new ArgumentException("Config ID cannot be null or empty", "id");
	}

	private string method_6(string string_1, float float_0)
	{
		return "Хитролох_иди_нахуй.________0___0__6__5____";
	}
}
