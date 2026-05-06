using System;
using System.Runtime.CompilerServices;

namespace LuaUiButton;

public class LuaUiButton
{
	[CompilerGenerated]
	private string string_0 = "";

	[CompilerGenerated]
	private string string_1 = "";

	[CompilerGenerated]
	private Action? action_0;

	private double double_0;

	private bool bool_1;

	private double double_1;

	public string Id
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

	public string Label
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

	public Action? OnClick
	{
		[CompilerGenerated]
		get
		{
			return action_0;
		}
		[CompilerGenerated]
		set
		{
			action_0 = value;
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

	private double Double_1
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
}
