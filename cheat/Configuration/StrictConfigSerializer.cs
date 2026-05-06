using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using ConfigParseException;
using AntiCheatConfig;

namespace StrictConfigSerializer;

public sealed class StrictConfigSerializer
{
	private static readonly JsonSerializerOptions jsonSerializerOptions_0 = new JsonSerializerOptions
	{
		WriteIndented = true,
		PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
		DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
		AllowTrailingCommas = true,
		ReadCommentHandling = JsonCommentHandling.Skip
	};

	private long long_1;

	private float float_0;

	private byte byte_0;

	private float float_1;

	private long Int64_0
	{
		get
		{
			return long_1;
		}
		set
		{
			long_1 = value;
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

	private float Single_1
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	public static AntiCheatConfig LoadDefault()
	{
		try
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			string text = "Kaban.cc.Core.Security.AntiCrack.Config.security_config.json";
			using Stream stream = executingAssembly.GetManifestResourceStream(text);
			if (stream == null)
			{
				Logger.Warn("[ConfigParser] Embedded resource not found: " + text + ", using hardcoded defaults");
				return GetHardcodedDefault();
			}
			using StreamReader streamReader = new StreamReader(stream);
			string text2 = streamReader.ReadToEnd();
			if (string.IsNullOrWhiteSpace(text2))
			{
				return GetHardcodedDefault();
			}
			AntiCheatConfig gClass = JsonSerializer.Deserialize<AntiCheatConfig>(text2, jsonSerializerOptions_0);
			if (gClass != null)
			{
				Validate(gClass);
				return gClass;
			}
			return GetHardcodedDefault();
		}
		catch (Exception)
		{
			return GetHardcodedDefault();
		}
	}

	private static AntiCheatConfig GetHardcodedDefault()
	{
		return new AntiCheatConfig
		{
			EnableAntiDebug = true,
			EnableAntiVM = true,
			EnableAntiDump = true,
			EnableAntiInjection = true,
			EnableHooksDetection = true,
			EnableProcessHiding = true,
			EnableAntiTamper = true,
			EnableWatcherProcess = true,
			EnableSystemIntegrityChecks = true,
			EnableRegistryValidation = true,
			EnableAssemblyValidation = true,
			EnableCheatEngineDetection = true,
			EnableAntiCMD = true,
			EnableAntiDLL = true,
			MonitoringInterval = 5,
			WatcherHeartbeatInterval = 5,
			OpcodesCheckInterval = 15,
			DebuggerKillerInterval = 10,
			HeaderRestorationCheckInterval = 10,
			EnableTelemetry = true,
			TelemetryBatchInterval = 30,
			TelemetryOfflineStorage = true,
			TelemetryStoragePath = "telemetry_cache.dat",
			WatcherEncryptCommunication = true,
			WatcherTimeout = 15,
			ProcessWhitelist = new List<string> { "KabanDropper.exe", "Kaban.cc.exe" },
			DllWhitelist = new List<string> { "kernel32.dll", "ntdll.dll", "user32.dll", "advapi32.dll", "mscoree.dll", "mscorlib.dll", "Kaban.cc.dll", "Cerberus.dll", "TargetStrafe.dll" },
			HarmonyWhitelist = new List<string> { "Kaban.cc.dll", "Cerberus.dll", "TargetStrafe.dll" },
			ProcessBlacklist = new List<string> { "ollydbg", "x32dbg", "x64dbg", "windbg", "ida", "dnspy", "ilspy", "cheatengine", "megadumper", "extremedumper" },
			DllBlacklist = new List<string> { "inject.dll", "hook.dll", "detour.dll", "easyhook.dll" }
		};
	}

	public static AntiCheatConfig Parse(string filePath)
	{
		try
		{
			if (!File.Exists(filePath))
			{
				throw new ConfigParseException("Configuration file not found: " + filePath, 0, 0, "filePath");
			}
			string text = File.ReadAllText(filePath);
			if (!string.IsNullOrWhiteSpace(text))
			{
				AntiCheatConfig? obj = JsonSerializer.Deserialize<AntiCheatConfig>(text, jsonSerializerOptions_0) ?? throw new ConfigParseException("Failed to deserialize configuration", 0, 0, "root");
				Validate(obj);
				return obj;
			}
			throw new ConfigParseException("Configuration file is empty", 0, 0, "content");
		}
		catch (JsonException ex)
		{
			int line = 0;
			int column = 0;
			string field = "unknown";
			if (ex.Path != null)
			{
				field = ex.Path;
			}
			if (ex.LineNumber.HasValue)
			{
				line = (int)ex.LineNumber.Value;
			}
			if (ex.BytePositionInLine.HasValue)
			{
				column = (int)ex.BytePositionInLine.Value;
			}
			throw new ConfigParseException("JSON parsing error: " + ex.Message, line, column, field, ex);
		}
		catch (ConfigParseException)
		{
			throw;
		}
		catch (Exception ex2)
		{
			throw new ConfigParseException("Unexpected error parsing configuration: " + ex2.Message, 0, 0, "unknown", ex2);
		}
	}

	public static string Serialize(AntiCheatConfig config)
	{
		if (config == null)
		{
			throw new ArgumentNullException("config");
		}
		try
		{
			return JsonSerializer.Serialize(config, jsonSerializerOptions_0);
		}
		catch (Exception ex)
		{
			throw new ConfigParseException("Failed to serialize configuration: " + ex.Message, 0, 0, "serialization", ex);
		}
	}

	public static void Save(AntiCheatConfig config, string filePath)
	{
		if (config != null)
		{
			if (string.IsNullOrWhiteSpace(filePath))
			{
				throw new ArgumentException("File path cannot be empty", "filePath");
			}
			try
			{
				string contents = Serialize(config);
				string directoryName = Path.GetDirectoryName(filePath);
				if (!string.IsNullOrEmpty(directoryName) && !Directory.Exists(directoryName))
				{
					Directory.CreateDirectory(directoryName);
				}
				File.WriteAllText(filePath, contents);
				return;
			}
			catch (Exception ex)
			{
				throw new ConfigParseException("Failed to save configuration: " + ex.Message, 0, 0, "save", ex);
			}
		}
		throw new ArgumentNullException("config");
	}

	public static void Validate(AntiCheatConfig config)
	{
		if (config != null)
		{
			if (config.MonitoringInterval > 0)
			{
				if (config.WatcherHeartbeatInterval > 0)
				{
					if (config.OpcodesCheckInterval <= 0)
					{
						throw new ConfigParseException("OpcodesCheckInterval must be greater than 0", 0, 0, "opcodesCheckInterval");
					}
					if (config.TelemetryBatchInterval > 0)
					{
						if (config.ProcessWhitelist != null)
						{
							if (config.DllWhitelist != null)
							{
								if (config.HarmonyWhitelist != null)
								{
									if (config.ProcessBlacklist == null)
									{
										throw new ConfigParseException("ProcessBlacklist cannot be null", 0, 0, "processBlacklist");
									}
									if (config.DllBlacklist == null)
									{
										throw new ConfigParseException("DllBlacklist cannot be null", 0, 0, "dllBlacklist");
									}
									return;
								}
								throw new ConfigParseException("HarmonyWhitelist cannot be null", 0, 0, "harmonyWhitelist");
							}
							throw new ConfigParseException("DllWhitelist cannot be null", 0, 0, "dllWhitelist");
						}
						throw new ConfigParseException("ProcessWhitelist cannot be null", 0, 0, "processWhitelist");
					}
					throw new ConfigParseException("TelemetryBatchInterval must be greater than 0", 0, 0, "telemetryBatchInterval");
				}
				throw new ConfigParseException("WatcherHeartbeatInterval must be greater than 0", 0, 0, "watcherHeartbeatInterval");
			}
			throw new ConfigParseException("MonitoringInterval must be greater than 0", 0, 0, "monitoringInterval");
		}
		throw new ConfigParseException("Configuration cannot be null", 0, 0, "root");
	}
}
