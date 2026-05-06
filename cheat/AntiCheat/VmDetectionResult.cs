using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace VmDetectionResult;

public class VmDetectionResult
{
	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private List<string> list_0 = new List<string>();

	private float float_2;

	private double double_0;

	public bool IsVM
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

	public List<string> Indicators
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

	private float Single_0
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
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
}
