using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Text.Json;
using Robust.Shared.IoC;
using LuaScriptManifest;
using LuaScriptRunner;

namespace LuaScriptManager;

public sealed class LuaScriptManager
{
	private static LuaScriptManager? gclass276_0;

	private readonly Dictionary<string, LuaScriptRunner> dictionary_0 = new Dictionary<string, LuaScriptRunner>();

	private readonly string string_0;

	private bool bool_1;

	private bool bool_2;

	private int int_2;

	private bool bool_3;

	public static LuaScriptManager Instance => gclass276_0 ?? (gclass276_0 = new LuaScriptManager());

	public IReadOnlyDictionary<string, LuaScriptRunner> LoadedScripts => dictionary_0;

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

	private bool Boolean_1
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	private int Int32_0
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	private bool Boolean_2
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	private LuaScriptManager()
	{
		IoCManager.InjectDependencies<LuaScriptManager>(this);
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		string_0 = Path.Combine(folderPath, "Kaban.cc", "Lua");
		if (!Directory.Exists(string_0))
		{
			Directory.CreateDirectory(string_0);
		}
	}

	public string GetLuaFolderPath()
	{
		return string_0;
	}

	public void OpenLuaFolder()
	{
		try
		{
			if (Directory.Exists(string_0))
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = string_0,
					UseShellExecute = true,
					Verb = "open"
				});
			}
		}
		catch (Exception)
		{
		}
	}

	public void LoadScripts()
	{
		try
		{
			dictionary_0.Clear();
			if (!Directory.Exists(string_0))
			{
				return;
			}
			string[] files = Directory.GetFiles(string_0, "*.lua", SearchOption.TopDirectoryOnly);
			foreach (string text in files)
			{
				try
				{
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
					LuaScriptRunner value = new LuaScriptRunner(fileNameWithoutExtension, text);
					dictionary_0[fileNameWithoutExtension] = value;
				}
				catch (Exception)
				{
				}
			}
			files = Directory.GetFiles(string_0, "*.zip", SearchOption.TopDirectoryOnly);
			foreach (string zipPath in files)
			{
				try
				{
					LuaScriptRunner gClass = LoadZipMod(zipPath);
					if (gClass != null)
					{
						dictionary_0[gClass.Name] = gClass;
					}
				}
				catch (Exception)
				{
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private LuaScriptRunner? LoadZipMod(string zipPath)
	{
		try
		{
			using ZipArchive zipArchive = ZipFile.OpenRead(zipPath);
			LuaScriptManifest gClass = null;
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			foreach (ZipArchiveEntry entry in zipArchive.Entries)
			{
				if (entry.FullName.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
				{
					using Stream utf8Json = entry.Open();
					gClass = JsonSerializer.Deserialize<LuaScriptManifest>(utf8Json);
				}
				else
				{
					if (!entry.FullName.EndsWith(".lua", StringComparison.OrdinalIgnoreCase))
					{
						continue;
					}
					using Stream stream = entry.Open();
					using StreamReader streamReader = new StreamReader(stream);
					dictionary[entry.FullName] = streamReader.ReadToEnd();
				}
			}
			if (gClass == null || !dictionary.ContainsKey(gClass.MainFile))
			{
				return null;
			}
			return new LuaScriptRunner(gClass.Name, zipPath, isZipMod: true, gClass, dictionary);
		}
		catch (Exception)
		{
			return null;
		}
	}

	public bool ExecuteScript(string scriptName)
	{
		try
		{
			if (dictionary_0.TryGetValue(scriptName, out LuaScriptRunner value))
			{
				value.Execute();
				return true;
			}
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public void StopScript(string scriptName)
	{
		try
		{
			if (dictionary_0.TryGetValue(scriptName, out LuaScriptRunner value))
			{
				value.Stop();
			}
		}
		catch (Exception)
		{
		}
	}

	public void StopAllScripts()
	{
		foreach (LuaScriptRunner value in dictionary_0.Values)
		{
			try
			{
				value.Stop();
			}
			catch
			{
			}
		}
	}
}
