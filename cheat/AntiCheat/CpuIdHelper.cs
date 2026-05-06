namespace CpuIdHelper;

internal sealed class CpuIdHelper
{
	private int int_1;

	private byte byte_1;

	private byte byte_2;

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

	private byte Byte_1
	{
		get
		{
			return byte_2;
		}
		set
		{
			byte_2 = value;
		}
	}

	public static bool TryGetCPUID(int function, int[] result)
	{
		try
		{
			if (function != 1)
			{
				return false;
			}
			result[0] = 0;
			result[1] = 0;
			result[2] = 0;
			result[3] = 0;
			return false;
		}
		catch
		{
			return false;
		}
	}
}
