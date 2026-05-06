using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace HardwareDetectionResult;

public class HardwareDetectionResult
{
	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private bool bool_1;

	[CompilerGenerated]
	private bool bool_2;

	[CompilerGenerated]
	private bool bool_3;

	[CompilerGenerated]
	private bool bool_4;

	[CompilerGenerated]
	private bool bool_5;

	[CompilerGenerated]
	private bool bool_6;

	[CompilerGenerated]
	private bool bool_7;

	[CompilerGenerated]
	private bool bool_8;

	[CompilerGenerated]
	private bool bool_9;

	[CompilerGenerated]
	private bool bool_10;

	private string string_1;

	private byte byte_0;

	private float float_0;

	public bool IsVMDetected
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

	public bool CPUCountSuspicious
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

	public bool RAMSizeSuspicious
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
		[CompilerGenerated]
		set
		{
			bool_2 = value;
		}
	}

	public bool DiskSizeSuspicious
	{
		[CompilerGenerated]
		get
		{
			return bool_3;
		}
		[CompilerGenerated]
		set
		{
			bool_3 = value;
		}
	}

	public bool AVXSupported
	{
		[CompilerGenerated]
		get
		{
			return bool_4;
		}
		[CompilerGenerated]
		set
		{
			bool_4 = value;
		}
	}

	public bool RDRANDSupported
	{
		[CompilerGenerated]
		get
		{
			return bool_5;
		}
		[CompilerGenerated]
		set
		{
			bool_5 = value;
		}
	}

	public bool ACPITablesDetected
	{
		[CompilerGenerated]
		get
		{
			return bool_6;
		}
		[CompilerGenerated]
		set
		{
			bool_6 = value;
		}
	}

	public bool SandboxDetected
	{
		[CompilerGenerated]
		get
		{
			return bool_7;
		}
		[CompilerGenerated]
		set
		{
			bool_7 = value;
		}
	}

	public bool WineDetected
	{
		[CompilerGenerated]
		get
		{
			return bool_8;
		}
		[CompilerGenerated]
		set
		{
			bool_8 = value;
		}
	}

	public bool KVMDetected
	{
		[CompilerGenerated]
		get
		{
			return bool_9;
		}
		[CompilerGenerated]
		set
		{
			bool_9 = value;
		}
	}

	public bool QemuDetected
	{
		[CompilerGenerated]
		get
		{
			return bool_10;
		}
		[CompilerGenerated]
		set
		{
			bool_10 = value;
		}
	}

	private string String_0
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
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

	public string GetDetectionSummary()
	{
		List<string> list = new List<string>();
		if (CPUCountSuspicious)
		{
			list.Add("Low CPU count");
		}
		if (RAMSizeSuspicious)
		{
			list.Add("Low RAM");
		}
		if (DiskSizeSuspicious)
		{
			list.Add("Low disk space");
		}
		if (!AVXSupported)
		{
			list.Add("No AVX");
		}
		if (!RDRANDSupported)
		{
			list.Add("No RDRAND");
		}
		if (ACPITablesDetected)
		{
			list.Add("VM ACPI");
		}
		if (SandboxDetected)
		{
			list.Add("Sandbox");
		}
		if (WineDetected)
		{
			list.Add("Wine");
		}
		if (KVMDetected)
		{
			list.Add("KVM");
		}
		if (QemuDetected)
		{
			list.Add("QEMU");
		}
		return string.Join(", ", list);
	}
}
