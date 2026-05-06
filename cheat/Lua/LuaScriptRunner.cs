using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using HarmonyLib;
using NLua;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Player;
using LuaScriptManifest;
using LuaUiCheckbox;
using LuaUiSlider;
using LuaUiButton;
using LuaUiComboBox;
using LuaUiColorPicker;
using LuaUiTextInput;
using LuaUiLabel;

namespace LuaScriptRunner;

public class LuaScriptRunner
{
	[CompilerGenerated]
	private readonly string name;

	[CompilerGenerated]
	private readonly string filePath;

	[CompilerGenerated]
	private readonly bool isZipMod;

	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private readonly LuaScriptManifest? config;

	private Lua? lua_0;

	private readonly Dictionary<string, object> dictionary_0 = new Dictionary<string, object>();

	private readonly Dictionary<string, string>? modFiles;

	private Harmony? harmony_0;

	private char char_0;

	private char char_1;

	private int int_0;

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return name;
		}
	}

	public string FilePath
	{
		[CompilerGenerated]
		get
		{
			return filePath;
		}
	}

	public bool IsZipMod
	{
		[CompilerGenerated]
		get
		{
			return isZipMod;
		}
	}

	public bool IsRunning
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		private set
		{
			bool_0 = value;
		}
	}

	public LuaScriptManifest? ModConfig
	{
		[CompilerGenerated]
		get
		{
			return config;
		}
	}

	public IReadOnlyDictionary<string, object> UIElements => dictionary_0;

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

	private char Char_1
	{
		get
		{
			return char_1;
		}
		set
		{
			char_1 = value;
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

	public LuaScriptRunner(string name, string filePath, bool isZipMod = false, LuaScriptManifest? config = null, Dictionary<string, string>? modFiles = null)
	{
		this.name = name;
		this.filePath = filePath;
		this.isZipMod = isZipMod;
		this.config = config;
		this.modFiles = modFiles;
	}

	public void Execute()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		try
		{
			if (IsRunning)
			{
				return;
			}
			lua_0 = new Lua(true);
			lua_0.State.Encoding = Encoding.UTF8;
			harmony_0 = new Harmony("kaban.lua." + Name);
			RegisterAPI();
			string value;
			if (!IsZipMod || modFiles == null || ModConfig == null)
			{
				if (!File.Exists(FilePath))
				{
					throw new Exception("File not found: " + FilePath);
				}
				value = File.ReadAllText(FilePath);
			}
			else if (!modFiles.TryGetValue(ModConfig.MainFile, out value))
			{
				throw new Exception("Main file " + ModConfig.MainFile + " not found in mod");
			}
			lua_0.DoString(value, "chunk");
			IsRunning = true;
			if (dictionary_0.Count <= 0)
			{
				return;
			}
			foreach (KeyValuePair<string, object> item in dictionary_0)
			{
				_ = item;
			}
		}
		catch (Exception ex)
		{
			_ = ex.InnerException;
			Stop();
		}
	}

	public void Stop()
	{
		try
		{
			if (lua_0 != null)
			{
				lua_0.Dispose();
				lua_0 = null;
			}
			if (harmony_0 != null)
			{
				harmony_0.UnpatchAll(harmony_0.Id);
				harmony_0 = null;
			}
			IsRunning = false;
			dictionary_0.Clear();
		}
		catch (Exception)
		{
		}
	}

	private void RegisterAPI()
	{
		if (lua_0 != null)
		{
			lua_0.RegisterFunction("AddCheckbox", (object)this, (MethodBase)GetType().GetMethod("AddCheckbox"));
			lua_0.RegisterFunction("AddSlider", (object)this, (MethodBase)GetType().GetMethod("AddSlider"));
			lua_0.RegisterFunction("AddButton", (object)this, (MethodBase)GetType().GetMethod("AddButton"));
			lua_0.RegisterFunction("AddComboBox", (object)this, (MethodBase)GetType().GetMethod("AddComboBox"));
			lua_0.RegisterFunction("AddColorPicker", (object)this, (MethodBase)GetType().GetMethod("AddColorPicker"));
			lua_0.RegisterFunction("AddTextInput", (object)this, (MethodBase)GetType().GetMethod("AddTextInput"));
			lua_0.RegisterFunction("AddLabel", (object)this, (MethodBase)GetType().GetMethod("AddLabel"));
			lua_0.RegisterFunction("Log", (object)this, (MethodBase)GetType().GetMethod("Log"));
			lua_0.RegisterFunction("GetLocalPlayer", (object)this, (MethodBase)GetType().GetMethod("GetLocalPlayer"));
			lua_0.RegisterFunction("GetAllPlayers", (object)this, (MethodBase)GetType().GetMethod("GetAllPlayers"));
			if (harmony_0 != null)
			{
				lua_0["Harmony"] = harmony_0;
			}
		}
	}

	public void AddCheckbox(string id, string label, bool defaultValue)
	{
		dictionary_0[id] = new LuaUiCheckbox
		{
			Id = id,
			Label = label,
			Value = defaultValue
		};
	}

	public void AddSlider(string id, string label, double min, double max, double defaultValue)
	{
		dictionary_0[id] = new LuaUiSlider
		{
			Id = id,
			Label = label,
			Min = min,
			Max = max,
			Value = defaultValue
		};
	}

	public void AddButton(string id, string label)
	{
		dictionary_0[id] = new LuaUiButton
		{
			Id = id,
			Label = label
		};
	}

	public void AddComboBox(string id, string label, object items, int defaultIndex)
	{
		LuaTable val = (LuaTable)((items is LuaTable) ? items : null);
		string[] items2;
		if (val != null)
		{
			List<string> list = new List<string>();
			foreach (object key in val.Keys)
			{
				object obj = val[key];
				if (obj != null)
				{
					list.Add(obj.ToString());
				}
			}
			items2 = list.ToArray();
		}
		else
		{
			if (!(items is string[] array))
			{
				return;
			}
			items2 = array;
		}
		dictionary_0[id] = new LuaUiComboBox
		{
			Id = id,
			Label = label,
			Items = items2,
			SelectedIndex = defaultIndex
		};
	}

	public void AddColorPicker(string id, string label, float r, float g, float b, float a)
	{
		dictionary_0[id] = new LuaUiColorPicker
		{
			Id = id,
			Label = label,
			R = r,
			G = g,
			B = b,
			A = a
		};
	}

	public void AddTextInput(string id, string label, string defaultValue)
	{
		dictionary_0[id] = new LuaUiTextInput
		{
			Id = id,
			Label = label,
			Value = defaultValue
		};
	}

	public void AddLabel(string id, string text)
	{
		dictionary_0[id] = new LuaUiLabel
		{
			Id = id,
			Text = text
		};
	}

	public void Log(string message)
	{
	}

	public object? GetLocalPlayer()
	{
		try
		{
			LocalPlayer localPlayer = IoCManager.Resolve<IPlayerManager>().LocalPlayer;
			return (localPlayer == null) ? ((EntityUid?)null) : localPlayer.ControlledEntity;
		}
		catch (Exception)
		{
			return null;
		}
	}

	public object? GetAllPlayers()
	{
		try
		{
			List<ICommonSession> list = ((ISharedPlayerManager)IoCManager.Resolve<IPlayerManager>()).Sessions.ToList();
			if (lua_0 != null)
			{
				lua_0.NewTable("temp_players_table");
				object obj = lua_0["temp_players_table"];
				LuaTable val = (LuaTable)((obj is LuaTable) ? obj : null);
				if (val != null)
				{
					for (int i = 0; i < list.Count; i++)
					{
						val[(object)(i + 1)] = list[i];
					}
					return val;
				}
			}
			return list;
		}
		catch (Exception)
		{
			return null;
		}
	}

	public object? GetUIElement(string id)
	{
		if (!dictionary_0.TryGetValue(id, out object value))
		{
			return null;
		}
		return value;
	}

	public void SetUIElementValue(string id, object value)
	{
		if (!dictionary_0.TryGetValue(id, out object value2))
		{
			return;
		}
		if (value2 is LuaUiCheckbox gClass)
		{
			gClass.Value = Convert.ToBoolean(value);
		}
		else if (!(value2 is LuaUiSlider gClass2))
		{
			if (value2 is LuaUiTextInput gClass3)
			{
				gClass3.Value = value.ToString() ?? "";
			}
			else if (value2 is LuaUiComboBox gClass4)
			{
				gClass4.SelectedIndex = Convert.ToInt32(value);
			}
			else if (value2 is LuaUiColorPicker gClass5 && value is float[] array && array.Length >= 4)
			{
				gClass5.R = array[0];
				gClass5.G = array[1];
				gClass5.B = array[2];
				gClass5.A = array[3];
			}
		}
		else
		{
			gClass2.Value = Convert.ToDouble(value);
		}
	}
}
