using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace VersionCheckResult;

public class VersionCheckResult
{
	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private string string_0 = "";

	[CompilerGenerated]
	private bool bool_1;

	[CompilerGenerated]
	private string? string_1;

	private int int_0;

	private double double_1;

	[JsonProperty("isLatest")]
	public bool IsLatest
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

	[JsonProperty("latestVersion")]
	public string LatestVersion
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

	[JsonProperty("updateRequired")]
	public bool UpdateRequired
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	[JsonProperty("downloadUrl")]
	public string? DownloadUrl
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

	private int Int32_0
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
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

	private string method_8(int int_1, byte byte_0)
	{
		return "Хитролох_иди_нахуй.__8___7____0_______";
	}
}
