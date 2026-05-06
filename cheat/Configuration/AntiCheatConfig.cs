using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AntiCheatConfig;

public class AntiCheatConfig
{
	[CompilerGenerated]
	private bool bool_0 = true;

	[CompilerGenerated]
	private bool bool_1 = true;

	[CompilerGenerated]
	private bool bool_2 = true;

	[CompilerGenerated]
	private bool bool_3 = true;

	[CompilerGenerated]
	private bool bool_4 = true;

	[CompilerGenerated]
	private bool bool_5 = true;

	[CompilerGenerated]
	private bool bool_6 = true;

	[CompilerGenerated]
	private bool bool_7 = true;

	[CompilerGenerated]
	private List<string> list_0 = new List<string>();

	[CompilerGenerated]
	private List<string> list_1 = new List<string> { "kernel32.dll", "ntdll.dll", "user32.dll", "advapi32.dll", "mscoree.dll", "mscorlib.dll" };

	[CompilerGenerated]
	private List<string> list_2 = new List<string> { "Kaban.cc.dll", "Cerberus.dll", "TargetStrafe.dll" };

	[CompilerGenerated]
	private List<string> list_3 = new List<string>
	{
		"ollydbg", "x32dbg", "x64dbg", "windbg", "windbgx", "ida", "ida64", "idaq", "idaq64", "idaw",
		"idaw64", "immunity", "immunitydebugger", "dnspy", "ilspy", "dotpeek", "reflector", "megadumper", "extremedumper", "procdump",
		"procdump64", "ghidra", "radare2", "r2", "cutter", "hopper", "cheatengine", "cheatengine-x86_64", "artmoney", "devenv",
		"rider"
	};

	[CompilerGenerated]
	private List<string> list_4 = new List<string> { "inject.dll", "hook.dll", "detour.dll", "easyhook.dll", "dnlib.dll", "scyllahide.dll", "scyllahidex64.dll", "sbiedll.dll", "cuckoomon.dll" };

	[CompilerGenerated]
	private int int_0 = 5;

	[CompilerGenerated]
	private int int_1 = 5;

	[CompilerGenerated]
	private int int_2 = 15;

	[CompilerGenerated]
	private int int_3 = 10;

	[CompilerGenerated]
	private int int_4 = 10;

	[CompilerGenerated]
	private bool bool_8 = true;

	[CompilerGenerated]
	private int int_5 = 30;

	[CompilerGenerated]
	private bool bool_9 = true;

	[CompilerGenerated]
	private string string_0 = "telemetry_cache.dat";

	[CompilerGenerated]
	private bool bool_10 = true;

	[CompilerGenerated]
	private bool bool_11 = true;

	[CompilerGenerated]
	private bool bool_12 = true;

	[CompilerGenerated]
	private bool bool_13 = true;

	[CompilerGenerated]
	private bool bool_14 = true;

	[CompilerGenerated]
	private bool bool_15 = true;

	[CompilerGenerated]
	private bool bool_16 = true;

	[CompilerGenerated]
	private int int_6 = 15;

	private double double_1;

	private bool bool_18;

	private string string_1;

	public bool EnableAntiDebug
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

	public bool EnableAntiVM
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

	public bool EnableAntiDump
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

	public bool EnableAntiInjection
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

	public bool EnableHooksDetection
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

	public bool EnableProcessHiding
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

	public bool EnableAntiTamper
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

	public bool EnableWatcherProcess
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

	public List<string> ProcessWhitelist
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

	public List<string> DllWhitelist
	{
		[CompilerGenerated]
		get
		{
			return list_1;
		}
		[CompilerGenerated]
		set
		{
			list_1 = value;
		}
	}

	public List<string> HarmonyWhitelist
	{
		[CompilerGenerated]
		get
		{
			return list_2;
		}
		[CompilerGenerated]
		set
		{
			list_2 = value;
		}
	}

	public List<string> ProcessBlacklist
	{
		[CompilerGenerated]
		get
		{
			return list_3;
		}
		[CompilerGenerated]
		set
		{
			list_3 = value;
		}
	}

	public List<string> DllBlacklist
	{
		[CompilerGenerated]
		get
		{
			return list_4;
		}
		[CompilerGenerated]
		set
		{
			list_4 = value;
		}
	}

	public int MonitoringInterval
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

	public int WatcherHeartbeatInterval
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

	public int OpcodesCheckInterval
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

	public int DebuggerKillerInterval
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

	public int HeaderRestorationCheckInterval
	{
		[CompilerGenerated]
		get
		{
			return int_4;
		}
		[CompilerGenerated]
		set
		{
			int_4 = value;
		}
	}

	public bool EnableTelemetry
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

	public int TelemetryBatchInterval
	{
		[CompilerGenerated]
		get
		{
			return int_5;
		}
		[CompilerGenerated]
		set
		{
			int_5 = value;
		}
	}

	public bool TelemetryOfflineStorage
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

	public string TelemetryStoragePath
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

	public bool EnableSystemIntegrityChecks
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

	public bool EnableRegistryValidation
	{
		[CompilerGenerated]
		get
		{
			return bool_11;
		}
		[CompilerGenerated]
		set
		{
			bool_11 = value;
		}
	}

	public bool EnableAssemblyValidation
	{
		[CompilerGenerated]
		get
		{
			return bool_12;
		}
		[CompilerGenerated]
		set
		{
			bool_12 = value;
		}
	}

	public bool EnableCheatEngineDetection
	{
		[CompilerGenerated]
		get
		{
			return bool_13;
		}
		[CompilerGenerated]
		set
		{
			bool_13 = value;
		}
	}

	public bool EnableAntiCMD
	{
		[CompilerGenerated]
		get
		{
			return bool_14;
		}
		[CompilerGenerated]
		set
		{
			bool_14 = value;
		}
	}

	public bool EnableAntiDLL
	{
		[CompilerGenerated]
		get
		{
			return bool_15;
		}
		[CompilerGenerated]
		set
		{
			bool_15 = value;
		}
	}

	public bool WatcherEncryptCommunication
	{
		[CompilerGenerated]
		get
		{
			return bool_16;
		}
		[CompilerGenerated]
		set
		{
			bool_16 = value;
		}
	}

	public int WatcherTimeout
	{
		[CompilerGenerated]
		get
		{
			return int_6;
		}
		[CompilerGenerated]
		set
		{
			int_6 = value;
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

	private bool Boolean_0
	{
		get
		{
			return bool_18;
		}
		set
		{
			bool_18 = value;
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

	private string method_5(float float_1)
	{
		return "Хитролох_иди_нахуй._____________9__1_____";
	}
}
