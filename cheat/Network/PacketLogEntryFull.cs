using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Robust.Shared.Network;
using PacketField;

namespace PacketLogEntryFull;

public class PacketLogEntryFull
{
	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private DateTime dateTime_0;

	[CompilerGenerated]
	private int int_1;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private string string_2 = "";

	[CompilerGenerated]
	private string string_3;

	[CompilerGenerated]
	private int int_2;

	[CompilerGenerated]
	private string string_4;

	[CompilerGenerated]
	private string string_5;

	[CompilerGenerated]
	private Dictionary<string, PacketField> dictionary_0 = new Dictionary<string, PacketField>();

	[CompilerGenerated]
	private NetMessage netMessage_0;

	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private int int_3 = 1;

	[CompilerGenerated]
	private List<int> list_0 = new List<int>();

	private string string_8;

	private int int_5;

	private byte byte_0;

	private int int_6;

	public int Id
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

	public int Direction
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public string MessageType
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

	public string MsgName
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

	public string DetailName
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
		[CompilerGenerated]
		set
		{
			string_2 = value;
		}
	}

	public string MsgGroup
	{
		[CompilerGenerated]
		get
		{
			return string_3;
		}
		[CompilerGenerated]
		set
		{
			string_3 = value;
		}
	}

	public int Size
	{
		[CompilerGenerated]
		get
		{
			return int_2;
		}
		[CompilerGenerated]
		set
		{
			int_2 = value;
		}
	}

	public string Channel
	{
		[CompilerGenerated]
		get
		{
			return string_4;
		}
		[CompilerGenerated]
		set
		{
			string_4 = value;
		}
	}

	public string RawData
	{
		[CompilerGenerated]
		get
		{
			return string_5;
		}
		[CompilerGenerated]
		set
		{
			string_5 = value;
		}
	}

	public Dictionary<string, PacketField> Fields
	{
		[CompilerGenerated]
		get
		{
			return dictionary_0;
		}
		[CompilerGenerated]
		set
		{
			dictionary_0 = value;
		}
	}

	public NetMessage OriginalMessage
	{
		[CompilerGenerated]
		get
		{
			return netMessage_0;
		}
		[CompilerGenerated]
		set
		{
			netMessage_0 = value;
		}
	}

	public bool IsGrouped
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

	public int GroupCount
	{
		[CompilerGenerated]
		get
		{
			return int_3;
		}
		[CompilerGenerated]
		set
		{
			int_3 = value;
		}
	}

	public List<int> GroupedPacketIds
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

	public string DisplayName
	{
		get
		{
			if (!string.IsNullOrEmpty(DetailName))
			{
				return MsgName + " › " + DetailName;
			}
			return MsgName;
		}
	}

	private string String_0
	{
		get
		{
			return string_8;
		}
		set
		{
			string_8 = value;
		}
	}

	private int Int32_0
	{
		get
		{
			return int_5;
		}
		set
		{
			int_5 = value;
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

	private int Int32_1
	{
		get
		{
			return int_6;
		}
		set
		{
			int_6 = value;
		}
	}

	private string method_8(long long_1)
	{
		return "Хитролох_иди_нахуй.________09_";
	}
}
