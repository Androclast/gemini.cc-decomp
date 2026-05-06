using System.Runtime.CompilerServices;

namespace AntagStoreListing;

public sealed class AntagStoreListing
{
	[CompilerGenerated]
	private readonly string id;

	[CompilerGenerated]
	private readonly string name;

	[CompilerGenerated]
	private readonly string cost;

	[CompilerGenerated]
	private readonly string category;

	private char char_0;

	private long long_0;

	private bool bool_1;

	private double double_0;

	public string Id
	{
		[CompilerGenerated]
		get
		{
			return id;
		}
	}

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return name;
		}
	}

	public string Cost
	{
		[CompilerGenerated]
		get
		{
			return cost;
		}
	}

	public string Category
	{
		[CompilerGenerated]
		get
		{
			return category;
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

	public AntagStoreListing(string id, string name, string cost, string category)
	{
		this.id = id;
		this.name = name;
		this.cost = cost;
		this.category = category;
	}
}
