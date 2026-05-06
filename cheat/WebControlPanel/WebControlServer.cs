using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using CerberusWareV3.Configuration;
using CerberusWareV3.Features.Events;
using CerberusWareV3.Features.Network;
using CerberusWareV3.Features.Utility;
using CerberusWareV3.Localization;
using Content.Shared.PDA;
using Hexa.NET.ImGui;
using Robust.Shared.Asynchronous;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Network;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using GhostRoleAutoTaker;
using SoundPlayer;
using MeleeHitPatch;
using MacroAction;
using Macro;
using MeleeMacroPlayer;
using NukeBruteforceEngine;
using CrayonImageDrawer;
using EventLogEntry;
using EventSpammer;
using PacketLogEntry;
using PacketSpammer;
using PacketLogger;
using PacketLogEntryFull;
using PacketField;
using LuaScriptManager;
using LuaScriptRunner;
using LuaUiCheckbox;
using AutoBuyPreset;
using LuaUiSlider;
using LuaUiButton;
using LuaUiComboBox;
using LuaUiColorPicker;
using LuaUiTextInput;
using LuaUiLabel;
using EventLogger;
using EventLogEntryFull;
using EventField;
using AntagAutoBuyEngine;
using CerberusConfig;
using ConfigAutoSaver;
using AntagStoreListing;
using ConfigManager;
using CerberusConfigData;
using UplinkBruteforceEngine;
using AutoChemRecipe;
using AutoChemRecipeManager;
using AutoChemCooker;

namespace WebControlServer;

public class WebControlServer : IDisposable
{
	private class ItemDto
	{
		[CompilerGenerated]
		private string C2KPzEQGys;

		[CompilerGenerated]
		private string njb8pkGhHm;

		private char char_0;

		private long long_0;

		private int int_0;

		public string Name
		{
			[CompilerGenerated]
			get
			{
				return C2KPzEQGys;
			}
			[CompilerGenerated]
			set
			{
				C2KPzEQGys = value;
			}
		}

		public string Color
		{
			[CompilerGenerated]
			get
			{
				return njb8pkGhHm;
			}
			[CompilerGenerated]
			set
			{
				njb8pkGhHm = value;
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
	}

	[CompilerGenerated]
	private static WebControlServer gclass85_0;

	private SessionTrackerSystem gclass7_0;

	private ITaskManager itaskManager_0;

	private HttpListener httpListener_0;

	private CancellationTokenSource cancellationTokenSource_0;

	private ConcurrentDictionary<string, WebSocket> concurrentDictionary_0 = new ConcurrentDictionary<string, WebSocket>();

	private readonly Assembly assembly_0;

	private readonly string string_0 = "Kaban.cc.Resources.Web.";

	private string string_1;

	[Dependency]
	private readonly IEntityManager ientityManager_0;

	private char char_1;

	private byte byte_0;

	public static WebControlServer Instance
	{
		[CompilerGenerated]
		get
		{
			return gclass85_0;
		}
		[CompilerGenerated]
		private set
		{
			gclass85_0 = value;
		}
	}

	private char Char_0
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

	public WebControlServer(string uriPrefix = "http://localhost:4649/")
	{
		assembly_0 = Assembly.GetExecutingAssembly();
		httpListener_0 = new HttpListener();
		httpListener_0.Prefixes.Add(uriPrefix);
		Instance = this;
	}

	public void SetPlayerTracker(SessionTrackerSystem tracker)
	{
		gclass7_0 = tracker;
	}

	public void SetTaskManager(ITaskManager taskManager)
	{
		itaskManager_0 = taskManager;
	}

	public void Start()
	{
		try
		{
			httpListener_0.Start();
			cancellationTokenSource_0 = new CancellationTokenSource();
			Task.Run(() => ListenLoop(cancellationTokenSource_0.Token));
			AntagAutoBuyEngine.Event_0 += async delegate
			{
				try
				{
					await BroadcastListings();
				}
				catch
				{
				}
			};
		}
		catch (Exception)
		{
		}
	}

	public async void UpdateDiscordInfo(string username, string avatarUrl, string discriminator, string id)
	{
		try
		{
			var value = new
			{
				type = "discord_info",
				data = new { username, avatarUrl, discriminator, id }
			};
			string_1 = JsonSerializer.Serialize(value);
			byte[] bytes = Encoding.UTF8.GetBytes(string_1);
			ArraySegment<byte> segment = new ArraySegment<byte>(bytes);
			foreach (WebSocket value2 in concurrentDictionary_0.Values)
			{
				if (value2.State == WebSocketState.Open)
				{
					await value2.SendAsync(segment, WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
				}
			}
		}
		catch
		{
		}
	}

	private async Task ListenLoop(CancellationToken token)
	{
		while (!token.IsCancellationRequested)
		{
			try
			{
				HttpListenerContext httpListenerContext = await httpListener_0.GetContextAsync();
				if (!httpListenerContext.Request.IsWebSocketRequest)
				{
					ServeStaticContent(httpListenerContext);
				}
				else
				{
					ProcessWebSocketRequest(httpListenerContext);
				}
			}
			catch
			{
				break;
			}
		}
	}

	private void ServeStaticContent(HttpListenerContext context)
	{
		try
		{
			string text = context.Request.Url.AbsolutePath;
			if (text == "/" || text == "/index.html")
			{
				text = "index.html";
			}
			string name = string_0 + text.TrimStart('/').Replace('/', '.');
			using (Stream stream = assembly_0.GetManifestResourceStream(name))
			{
				if (stream == null)
				{
					context.Response.StatusCode = 404;
				}
				else
				{
					context.Response.StatusCode = 200;
					if (!text.EndsWith(".html"))
					{
						if (text.EndsWith(".js"))
						{
							context.Response.ContentType = "application/javascript";
						}
						else if (text.EndsWith(".css"))
						{
							context.Response.ContentType = "text/css";
						}
					}
					else
					{
						context.Response.ContentType = "text/html; charset=utf-8";
					}
					stream.CopyTo(context.Response.OutputStream);
				}
			}
			context.Response.Close();
		}
		catch
		{
			context.Response.Close();
		}
	}

	private async void ProcessWebSocketRequest(HttpListenerContext context)
	{
		WebSocketContext wsContext = null;
		try
		{
			wsContext = await context.AcceptWebSocketAsync(null);
			string clientId = Guid.NewGuid().ToString();
			concurrentDictionary_0.TryAdd(clientId, wsContext.WebSocket);
			await SendConfig(wsContext.WebSocket);
			await SendConfigList(wsContext.WebSocket);
			await SendChemRecipes(wsContext.WebSocket);
			await SendLuaScripts(wsContext.WebSocket);
			await SendComboList(wsContext.WebSocket);
			if (!string.IsNullOrEmpty(string_1))
			{
				byte[] bytes = Encoding.UTF8.GetBytes(string_1);
				await wsContext.WebSocket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
			}
			await ReceiveLoop(wsContext.WebSocket, clientId);
		}
		catch (Exception)
		{
			wsContext?.WebSocket.Dispose();
		}
	}

	private async Task ReceiveLoop(WebSocket ws, string clientId)
	{
		byte[] buffer = new byte[65536];
		List<byte> messageBuffer = new List<byte>();
		while (ws.State == WebSocketState.Open)
		{
			try
			{
				WebSocketReceiveResult webSocketReceiveResult = await ws.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
				if (webSocketReceiveResult.MessageType == WebSocketMessageType.Close)
				{
					await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed", CancellationToken.None);
					continue;
				}
				messageBuffer.AddRange(buffer.Take(webSocketReceiveResult.Count));
				if (webSocketReceiveResult.EndOfMessage)
				{
					string json = Encoding.UTF8.GetString(messageBuffer.ToArray());
					await HandleMessage(json, ws);
					messageBuffer.Clear();
				}
			}
			catch
			{
				break;
			}
		}
		concurrentDictionary_0.TryRemove(clientId, out WebSocket _);
	}

	private async Task HandleMessage(string json, WebSocket ws)
	{
		try
		{
			using JsonDocument doc = JsonDocument.Parse(json);
			JsonElement rootElement = doc.RootElement;
			if (!rootElement.TryGetProperty("type", out var value))
			{
				return;
			}
			string text = value.GetString();
			if ((text != null && text.StartsWith("save_combo")) || text == "get_combos" || text == "delete_combo")
			{
				Logger.Info("[WebUI] HandleMessage type='" + text + "'");
			}
			switch (text)
			{
			case "update_throw_allowed_jobs":
			{
				List<string> list7 = JsonSerializer.Deserialize<List<string>>(rootElement.GetProperty("value").GetRawText());
				if (list7 != null)
				{
					CerberusConfig.ThrowAimbot.AllowedJobs = list7;
				}
				break;
			}
			case "autobuy_get_presets":
				await SendAutoBuyPresets(ws);
				break;
			case "update_tag_list":
			{
				List<string> list6 = JsonSerializer.Deserialize<List<string>>(rootElement.GetProperty("value").GetRawText());
				if (list6 != null)
				{
					CerberusConfig.NoInteract.BlockedTags = list6;
				}
				break;
			}
			case "update_combo_keybind":
			{
				JsonElement property3 = rootElement.GetProperty("value");
				string u2E8MxUY2O = property3.GetProperty("name").GetString();
				string MHB8f2EhYI = property3.GetProperty("key").GetString();
				if (Enum.TryParse<ImGuiKey>(MHB8f2EhYI, true, out ImGuiKey result))
				{
					CerberusConfig.AutoCombo.MacroKeybinds[u2E8MxUY2O] = result;
					Logger.Info("[WebUI] Updated combo keybind for " + u2E8MxUY2O + ": " + MHB8f2EhYI);
					if (itaskManager_0 != null)
					{
						itaskManager_0.RunOnMainThread((Action)delegate
						{
							try
							{
								string path2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Kaban.cc", "combo");
								string path3 = string.Join("_", u2E8MxUY2O.Split(Path.GetInvalidFileNameChars())) + ".json";
								string path4 = Path.Combine(path2, path3);
								if (File.Exists(path4))
								{
									Macro gClass2 = JsonSerializer.Deserialize<Macro>(File.ReadAllText(path4));
									if (gClass2 != null)
									{
										gClass2.Hotkey = MHB8f2EhYI;
										string contents = JsonSerializer.Serialize(gClass2, new JsonSerializerOptions
										{
											WriteIndented = true
										});
										File.WriteAllText(path4, contents);
									}
								}
								try
								{
									IoCManager.Resolve<IEntitySystemManager>().GetEntitySystem<MeleeMacroPlayer>().LoadMacros();
								}
								catch
								{
								}
							}
							catch (Exception ex3)
							{
								Logger.Error("[WebUI] Failed to update combo hotkey in file: " + ex3.Message);
							}
						});
					}
				}
				await SendComboList(ws);
				break;
			}
			case "get_config_list":
				await SendConfigList(ws);
				break;
			case "button_click":
			{
				string text4 = rootElement.GetProperty("id").GetString();
				if (!text4.StartsWith("lua_"))
				{
					await HandleButtonClick(text4, rootElement);
				}
				else
				{
					await HandleLuaButtonClick(text4, rootElement, ws);
				}
				break;
			}
			case "update_hardware_unlocker":
			{
				if (rootElement.TryGetProperty("enabled", out var value19))
				{
					CerberusConfig.HardwareUnlocker.Enabled = value19.GetBoolean();
				}
				if (rootElement.TryGetProperty("high_priority", out var value20))
				{
					CerberusConfig.HardwareUnlocker.HighPriority = value20.GetBoolean();
				}
				if (rootElement.TryGetProperty("realtime_priority", out var value21))
				{
					CerberusConfig.HardwareUnlocker.RealtimePriority = value21.GetBoolean();
				}
				if (rootElement.TryGetProperty("unlock_all_cores", out var value22))
				{
					CerberusConfig.HardwareUnlocker.UnlockAllCores = value22.GetBoolean();
				}
				if (rootElement.TryGetProperty("optimize_thread_pool", out var value23))
				{
					CerberusConfig.HardwareUnlocker.OptimizeThreadPool = value23.GetBoolean();
				}
				if (rootElement.TryGetProperty("optimize_gc", out var value24))
				{
					CerberusConfig.HardwareUnlocker.OptimizeGC = value24.GetBoolean();
				}
				if (rootElement.TryGetProperty("gpu_priority", out var value25))
				{
					CerberusConfig.HardwareUnlocker.GPUPriority = value25.GetBoolean();
				}
				break;
			}
			case "get_nuke_brute_status":
				await SendNukeBruteforceStatus(ws);
				break;
			case "uplink_brute_stop":
				if (itaskManager_0 != null)
				{
					itaskManager_0.RunOnMainThread((Action)delegate
					{
						try
						{
							UplinkBruteforceEngine.StopBruteforce();
						}
						catch
						{
						}
					});
				}
				await SendUplinkBruteforceStatus(ws);
				break;
			case "update":
			{
				if (rootElement.TryGetProperty("id", out var value27) && value27.GetString() == "ghostrole_pick_delay")
				{
					if (rootElement.TryGetProperty("value", out var value28))
					{
						GhostRoleAutoTaker.int_0 = value28.GetInt32();
						ConfigAutoSaver.MarkDirty();
					}
					break;
				}
				goto default;
			}
			default:
				if (!(text == "autochem_mode"))
				{
					if (text == "update" && rootElement.TryGetProperty("id", out var value17) && value17.GetString() == "autochem_delay")
					{
						if (rootElement.TryGetProperty("value", out var value18))
						{
							AutoChemCooker.int_1 = value18.GetInt32();
						}
					}
					else if (!text.StartsWith("lua_"))
					{
						if (!text.StartsWith("netlogger_"))
						{
							if (text.StartsWith("eventlogger_"))
							{
								await HandleEventLoggerMessage(text, rootElement, ws);
								break;
							}
							if (text.StartsWith("packetspammer_"))
							{
								await HandlePacketSpammerMessage(text, rootElement, ws);
								break;
							}
							if (text.StartsWith("eventspammer_"))
							{
								await HandleEventSpammerMessage(text, rootElement, ws);
								break;
							}
							switch (text)
							{
							case "painter_start":
								await HandlePainterStart(ws);
								break;
							case "painter_load_image":
								await HandlePainterLoadImage(rootElement, ws);
								break;
							case "painter_reset":
								await HandlePainterReset(ws);
								break;
							case "painter_stop":
								await HandlePainterStop(ws);
								break;
							}
						}
						else
						{
							await HandleNetLoggerMessage(text, rootElement, ws);
						}
					}
					else
					{
						await HandleLuaMessage(text, rootElement, ws);
					}
				}
				else
				{
					string text11 = rootElement.GetProperty("mode").GetString();
					if (text11 == "dispenser")
					{
						AutoChemCooker.int_0 = 0;
					}
					else if (text11 == "chemmaster")
					{
						AutoChemCooker.int_0 = 1;
					}
				}
				break;
			case "update_keybind":
			{
				string id2 = rootElement.GetProperty("id").GetString();
				string keyName = rootElement.GetProperty("value").GetString();
				ApplyKeybindUpdate(id2, keyName);
				break;
			}
			case "select_config":
			{
				string text12 = rootElement.GetProperty("value").GetString();
				if (!string.IsNullOrEmpty(text12))
				{
					ConfigManager.string_0 = text12;
					ConfigAutoSaver.SetConfigName(text12);
				}
				break;
			}
			case "update_gun_blocked_jobs":
			{
				List<string> list8 = JsonSerializer.Deserialize<List<string>>(rootElement.GetProperty("value").GetRawText());
				if (list8 != null)
				{
					CerberusConfig.GunAimBot.BlockedJobs = list8;
				}
				break;
			}
			case "nuke_brute_stop":
				if (itaskManager_0 != null)
				{
					itaskManager_0.RunOnMainThread((Action)delegate
					{
						try
						{
							NukeBruteforceEngine.StopBruteforce();
						}
						catch (Exception)
						{
						}
					});
				}
				await SendNukeBruteforceStatus(ws);
				break;
			case "update_autorole_list":
			{
				List<string> list4 = JsonSerializer.Deserialize<List<string>>(rootElement.GetProperty("value").GetRawText());
				if (list4 == null)
				{
					break;
				}
				GhostRoleAutoTaker.hashSet_0.Clear();
				foreach (string item in list4)
				{
					GhostRoleAutoTaker.hashSet_0.Add(item);
				}
				break;
			}
			case "get_players":
				await SendPlayerList(ws);
				break;
			case "delete_combo":
			{
				string fxp80AtnfZ = rootElement.GetProperty("value").GetProperty("name").GetString();
				TaskCompletionSource<bool> MGp8PyrOOh = new TaskCompletionSource<bool>();
				if (itaskManager_0 != null)
				{
					itaskManager_0.RunOnMainThread((Action)delegate
					{
						try
						{
							string path2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Kaban.cc", "combo");
							string path3 = string.Join("_", fxp80AtnfZ.Split(Path.GetInvalidFileNameChars())) + ".json";
							string path4 = Path.Combine(path2, path3);
							if (File.Exists(path4))
							{
								File.Delete(path4);
							}
							try
							{
								IoCManager.Resolve<IEntitySystemManager>().GetEntitySystem<MeleeMacroPlayer>().DeleteMacro(fxp80AtnfZ);
							}
							catch
							{
							}
							CerberusConfig.AutoCombo.MacroKeybinds.Remove(fxp80AtnfZ);
							Logger.Info("[WebUI] Deleted combo macro: " + fxp80AtnfZ);
							MGp8PyrOOh.SetResult(result: true);
						}
						catch (Exception ex3)
						{
							Logger.Error("[WebUI] Failed to delete combo: " + ex3.Message);
							MGp8PyrOOh.SetResult(result: false);
						}
					});
				}
				else
				{
					MGp8PyrOOh.SetResult(result: false);
				}
				await MGp8PyrOOh.Task;
				await SendComboList(ws);
				break;
			}
			case "get_uplink_brute_status":
				await SendUplinkBruteforceStatus(ws);
				break;
			case "autobuy_get_listings":
			{
				var data = AntagAutoBuyEngine.CachedListings.Select((AntagStoreListing l) => new
				{
					id = l.Id,
					name = l.Name,
					cost = l.Cost,
					category = l.Category
				}).ToList();
				string s = JsonSerializer.Serialize(new
				{
					type = "autobuy_listings",
					data = data
				});
				byte[] bytes = Encoding.UTF8.GetBytes(s);
				await ws.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
				break;
			}
			case "toggle_autorole":
				GhostRoleAutoTaker.bool_0 = rootElement.GetProperty("value").GetBoolean();
				break;
			case "autobuy_save_preset":
			{
				JsonElement property4 = rootElement.GetProperty("value");
				AntagAutoBuyEngine.SavePreset(new AutoBuyPreset
				{
					Name = (property4.GetProperty("name").GetString() ?? "Preset"),
					Items = (JsonSerializer.Deserialize<List<string>>(property4.GetProperty("items").GetRawText()) ?? new List<string>())
				});
				await SendAutoBuyPresets(ws);
				break;
			}
			case "chem_dispense":
			{
				string p9g8w5B1go = null;
				int VDP8iNYIrf = 10;
				if (!rootElement.TryGetProperty("recipe", out var value4))
				{
					if (rootElement.TryGetProperty("id", out var value5))
					{
						p9g8w5B1go = value5.GetString();
					}
				}
				else
				{
					p9g8w5B1go = value4.GetString();
				}
				JsonElement value7;
				if (rootElement.TryGetProperty("amount", out var value6))
				{
					VDP8iNYIrf = value6.GetInt32();
				}
				else if (rootElement.TryGetProperty("value", out value7))
				{
					VDP8iNYIrf = value7.GetInt32();
				}
				if (string.IsNullOrEmpty(p9g8w5B1go) || itaskManager_0 == null)
				{
					break;
				}
				itaskManager_0.RunOnMainThread((Action)delegate
				{
					try
					{
						AutoChemCooker.Cook(p9g8w5B1go, VDP8iNYIrf);
					}
					catch (Exception)
					{
					}
				});
				break;
			}
			case "update_implant_list":
			{
				List<string> list = JsonSerializer.Deserialize<List<string>>(rootElement.GetProperty("value").GetRawText());
				if (list != null)
				{
					CerberusConfig.AutoImplant.AllowedImplants = list;
				}
				break;
			}
			case "get_combos":
				await SendComboList(ws);
				break;
			case "uplink_brute_start":
				if (itaskManager_0 != null)
				{
					itaskManager_0.RunOnMainThread((Action)delegate
					{
						try
						{
							UplinkBruteforceEngine.StartBruteforce();
						}
						catch
						{
						}
					});
				}
				await SendUplinkBruteforceStatus(ws);
				break;
			case "nuke_brute_start":
			{
				int tMc8eGrxBx = CerberusConfig.NukeBruteforce.CodeLength;
				if (itaskManager_0 != null)
				{
					itaskManager_0.RunOnMainThread((Action)delegate
					{
						try
						{
							NukeBruteforceEngine.StartBruteforce(tMc8eGrxBx);
						}
						catch (Exception)
						{
						}
					});
				}
				await SendNukeBruteforceStatus(ws);
				break;
			}
			case "save_combo":
			{
				Logger.Info($"[AutoCombo] Received save_combo, raw JSON length: {json.Length}");
				JsonElement property2 = rootElement.GetProperty("value").GetProperty("macro");
				Logger.Info("[AutoCombo] macro JSON: " + property2.GetRawText().Substring(0, Math.Min(300, property2.GetRawText().Length)));
				JsonElement value8;
				JsonElement value9;
				Macro AJu8NPjGUb = new Macro
				{
					Name = (property2.GetProperty("name").GetString() ?? "Combo"),
					Enabled = (property2.TryGetProperty("enabled", out value8) && value8.GetBoolean()),
					Hotkey = ((!property2.TryGetProperty("hotkey", out value9)) ? "NONE" : (value9.GetString() ?? "NONE"))
				};
				if (property2.TryGetProperty("actions", out var value10))
				{
					foreach (JsonElement item2 in value10.EnumerateArray())
					{
						MacroAction gClass = new MacroAction();
						if (item2.TryGetProperty("type", out var value11))
						{
							gClass.TypeId = value11.GetInt32();
						}
						if (item2.TryGetProperty("delay", out var value12))
						{
							gClass.Delay = ((value12.ValueKind != JsonValueKind.Number) ? 0.1f : ((float)value12.GetDouble()));
						}
						if (item2.TryGetProperty("repeat", out var value13))
						{
							gClass.Repeat = value13.GetInt32();
						}
						AJu8NPjGUb.Actions.Add(gClass);
					}
				}
				Logger.Info($"[AutoCombo] Parsed: name='{AJu8NPjGUb.Name}', actions={AJu8NPjGUb.Actions.Count}, hotkey='{AJu8NPjGUb.Hotkey}'");
				try
				{
					string text5 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Kaban.cc", "combo");
					Logger.Info($"[AutoCombo] Save: name='{AJu8NPjGUb.Name}', actions={AJu8NPjGUb.Actions.Count}, dir='{text5}'");
					if (!Directory.Exists(text5))
					{
						Directory.CreateDirectory(text5);
						Logger.Info("[AutoCombo] Created directory: " + text5);
					}
					else
					{
						Logger.Info("[AutoCombo] Directory exists: " + text5);
					}
					string text6 = AJu8NPjGUb.Name ?? "unnamed";
					string path = string.Join("_", text6.Split(Path.GetInvalidFileNameChars())) + ".json";
					string text7 = Path.Combine(text5, path);
					Logger.Info("[AutoCombo] Writing to: " + text7);
					string text8 = JsonSerializer.Serialize(AJu8NPjGUb, new JsonSerializerOptions
					{
						WriteIndented = true
					});
					Logger.Info($"[AutoCombo] JSON length: {text8.Length}, content: {text8.Substring(0, Math.Min(200, text8.Length))}");
					File.WriteAllText(text7, text8);
					bool value14 = File.Exists(text7);
					Logger.Info($"[AutoCombo] File written, exists={value14}, path={text7}");
				}
				catch (Exception ex)
				{
					Logger.Error("[AutoCombo] SAVE FAILED: " + ex.GetType().Name + ": " + ex.Message);
					Logger.Error("[AutoCombo] Stack: " + ex.StackTrace);
				}
				if (itaskManager_0 != null)
				{
					itaskManager_0.RunOnMainThread((Action)delegate
					{
						//IL_003e: Unknown result type (might be due to invalid IL or missing references)
						try
						{
							IoCManager.Resolve<IEntitySystemManager>().GetEntitySystem<MeleeMacroPlayer>().SaveMacro(AJu8NPjGUb);
						}
						catch
						{
						}
						if (!string.IsNullOrEmpty(AJu8NPjGUb.Hotkey) && Enum.TryParse<ImGuiKey>(AJu8NPjGUb.Hotkey, true, out ImGuiKey result2))
						{
							CerberusConfig.AutoCombo.MacroKeybinds[AJu8NPjGUb.Name] = result2;
						}
					});
				}
				await SendComboList(ws);
				break;
			}
			case "update_medipen_list":
			{
				List<string> list3 = JsonSerializer.Deserialize<List<string>>(rootElement.GetProperty("value").GetRawText());
				if (list3 != null)
				{
					CerberusConfig.AutoMedipen.AllowedMedipens = list3;
				}
				break;
			}
			case "update_throw_blocked_jobs":
			{
				List<string> list2 = JsonSerializer.Deserialize<List<string>>(rootElement.GetProperty("value").GetRawText());
				if (list2 != null)
				{
					CerberusConfig.ThrowAimbot.BlockedJobs = list2;
				}
				break;
			}
			case "autobuy_delete_preset":
				AntagAutoBuyEngine.DeletePreset(rootElement.GetProperty("value").GetString() ?? "");
				await SendAutoBuyPresets(ws);
				break;
			case "autobuy_execute":
			{
				string TDH8kQThYL = rootElement.GetProperty("value").GetString() ?? "";
				JsonElement value26;
				int RvW83cOgd3 = ((!rootElement.TryGetProperty("delay", out value26)) ? 150 : value26.GetInt32());
				if (itaskManager_0 != null)
				{
					itaskManager_0.RunOnMainThread((Action)delegate
					{
						AntagAutoBuyEngine.ExecutePreset(TDH8kQThYL, RvW83cOgd3);
					});
				}
				break;
			}
			case "add_player":
			{
				if (!rootElement.TryGetProperty("id", out var value15) || !rootElement.TryGetProperty("value", out var value16))
				{
					break;
				}
				string text9 = value15.GetString();
				string text10 = value16.GetString()?.Trim();
				if (string.IsNullOrEmpty(text10))
				{
					break;
				}
				if (text9 == "friend")
				{
					if (!CerberusConfig.list_0.Contains(text10))
					{
						CerberusConfig.list_0.Add(text10);
					}
				}
				else if (text9 == "priority" && !CerberusConfig.list_1.Contains(text10))
				{
					CerberusConfig.list_1.Add(text10);
				}
				ConfigAutoSaver.MarkDirty();
				await BroadcastConfig();
				break;
			}
			case "get_chem_recipes":
				await SendChemRecipes(ws);
				break;
			case "update_gun_allowed_jobs":
			{
				List<string> list5 = JsonSerializer.Deserialize<List<string>>(rootElement.GetProperty("value").GetRawText());
				if (list5 != null)
				{
					CerberusConfig.GunAimBot.AllowedJobs = list5;
				}
				break;
			}
			case "remove_player":
			{
				if (!rootElement.TryGetProperty("id", out var value2) || !rootElement.TryGetProperty("value", out var value3))
				{
					break;
				}
				string text2 = value2.GetString();
				string text3 = value3.GetString()?.Trim();
				if (string.IsNullOrEmpty(text3))
				{
					break;
				}
				if (!(text2 == "friend"))
				{
					if (text2 == "priority")
					{
						CerberusConfig.list_1.Remove(text3);
					}
				}
				else
				{
					CerberusConfig.list_0.Remove(text3);
				}
				ConfigAutoSaver.MarkDirty();
				await BroadcastConfig();
				break;
			}
			case "delete_config":
				ConfigManager.DeleteConfig(rootElement.GetProperty("value").GetString());
				await SendConfigList(ws);
				break;
			case "execute_combo":
			{
				string OS388vtqWn = rootElement.GetProperty("value").GetProperty("name").GetString();
				if (itaskManager_0 == null)
				{
					break;
				}
				itaskManager_0.RunOnMainThread((Action)delegate
				{
					try
					{
						IoCManager.Resolve<IEntitySystemManager>().GetEntitySystem<MeleeMacroPlayer>().ExecuteMacro(OS388vtqWn);
						Logger.Info("[WebUI] Executing combo macro: " + OS388vtqWn);
					}
					catch (Exception ex3)
					{
						Logger.Error("[WebUI] Failed to execute combo: " + ex3.Message);
					}
				});
				break;
			}
			case "update_feature":
			{
				string id = rootElement.GetProperty("id").GetString();
				JsonElement property = rootElement.GetProperty("value");
				ApplyFeatureUpdate(id, property);
				break;
			}
			}
		}
		catch (Exception)
		{
		}
	}

	private async Task HandleButtonClick(string id, JsonElement root)
	{
		try
		{
			if (id == null)
			{
				return;
			}
			switch (id.Length)
			{
			case 6:
			case 14:
			case 15:
				break;
			case 13:
				switch (id[8])
				{
				case 'l':
				{
					if (!(id == "remove_player") || !root.TryGetProperty("value", out var value5) || value5.ValueKind != JsonValueKind.String)
					{
						break;
					}
					string text6 = value5.GetString()?.Trim();
					string text7 = id;
					if (root.TryGetProperty("id", out var value6) && value6.ValueKind == JsonValueKind.String)
					{
						text7 = value6.GetString();
					}
					if (string.IsNullOrEmpty(text6))
					{
						break;
					}
					if (!(text7 == "friend"))
					{
						if (text7 == "priority")
						{
							CerberusConfig.list_1.Remove(text6);
						}
					}
					else
					{
						CerberusConfig.list_0.Remove(text6);
					}
					ConfigAutoSaver.MarkDirty();
					await BroadcastConfig();
					break;
				}
				case 's':
					if (id == "painter_start")
					{
						await HandlePainterStart(null);
					}
					break;
				case 'r':
					if (id == "painter_reset")
					{
						await HandlePainterReset(null);
					}
					break;
				}
				break;
			case 9:
				if (id == "st_unload")
				{
					FeatureToggleState.Instance.Unload();
				}
				break;
			case 16:
				if (id == "chem_open_folder")
				{
					string text5 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "kaban.cc", "chem");
					if (!Directory.Exists(text5))
					{
						Directory.CreateDirectory(text5);
					}
					Process.Start("explorer.exe", text5);
				}
				break;
			case 7:
				if (id == "y_reset")
				{
					CerberusConfig.Eye.Zoom = 1f;
				}
				break;
			case 5:
				if (id == "st_ru")
				{
					if ((object)CerberusConfig.Settings.CurrentLanguage != null)
					{
						CerberusConfig.Settings.CurrentLanguage = (GEnum4)0;
					}
					else
					{
						CerberusConfig.Settings.CurrentLanguage = (GEnum4)1;
					}
				}
				break;
			case 11:
				if (id == "chem_reload")
				{
					AutoChemRecipeManager.LoadRecipesFromFiles();
					await BroadcastChemRecipes();
				}
				break;
			case 10:
			{
				if (!(id == "add_player") || !root.TryGetProperty("value", out var value3) || value3.ValueKind != JsonValueKind.String)
				{
					break;
				}
				string text3 = value3.GetString()?.Trim();
				string text4 = id;
				if (root.TryGetProperty("id", out var value4) && value4.ValueKind == JsonValueKind.String)
				{
					text4 = value4.GetString();
				}
				if (string.IsNullOrEmpty(text3))
				{
					break;
				}
				if (!(text4 == "friend"))
				{
					if (text4 == "priority" && !CerberusConfig.list_1.Contains(text3))
					{
						CerberusConfig.list_1.Add(text3);
					}
				}
				else if (!CerberusConfig.list_0.Contains(text3))
				{
					CerberusConfig.list_0.Add(text3);
				}
				ConfigAutoSaver.MarkDirty();
				await BroadcastConfig();
				break;
			}
			case 8:
				switch (id[4])
				{
				case 'l':
				{
					if (!(id == "cfg_load"))
					{
						break;
					}
					string text2 = "default";
					if (root.TryGetProperty("value", out var value2) && value2.ValueKind == JsonValueKind.String)
					{
						text2 = value2.GetString() ?? "default";
					}
					CerberusConfigData gClass = ConfigManager.LoadConfig(text2);
					ConfigManager.string_0 = text2;
					ConfigAutoSaver.SetConfigName(text2);
					if (gClass?.MiscData != null)
					{
						GhostRoleAutoTaker.bool_0 = gClass.MiscData.AutoGhostRoleEnabled;
						GhostRoleAutoTaker.hashSet_0.Clear();
						if (gClass.MiscData.AutoGhostRoleWantedRoles != null)
						{
							foreach (string autoGhostRoleWantedRole in gClass.MiscData.AutoGhostRoleWantedRoles)
							{
								GhostRoleAutoTaker.hashSet_0.Add(autoGhostRoleWantedRole);
							}
						}
					}
					HudRenderer.ForcePositionUpdate();
					await BroadcastConfig();
					Task.Run(async delegate
					{
						await Task.Delay(500);
						await BroadcastConfig();
					});
					break;
				}
				case 'o':
					if (id == "cfg_open")
					{
						Process.Start("explorer.exe", ConfigManager.string_1);
					}
					break;
				case 's':
				{
					if (!(id == "cfg_save"))
					{
						break;
					}
					string text = "default";
					if (!root.TryGetProperty("value", out var value) || value.ValueKind != JsonValueKind.String)
					{
						if (!string.IsNullOrEmpty(ConfigManager.string_0))
						{
							text = ConfigManager.string_0;
						}
					}
					else
					{
						text = value.GetString() ?? "default";
					}
					ConfigManager.string_0 = text;
					ConfigManager.SaveConfig(text);
					ConfigAutoSaver.SetConfigName(text);
					break;
				}
				}
				break;
			case 12:
				if (id == "painter_stop")
				{
					await HandlePainterStop(null);
				}
				break;
			}
		}
		catch (Exception ex)
		{
			Logger.Error("[WebUI-HandleButtonClick] ERROR for id '" + id + "': " + ex.Message);
			Logger.Error("[WebUI-HandleButtonClick] Stack trace: " + ex.StackTrace);
		}
	}

	private void ApplyKeybindUpdate(string id, string keyName)
	{
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_038d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			ConfigAutoSaver.MarkDirty();
			if (!Enum.TryParse<ImGuiKey>(keyName, true, out ImGuiKey result))
			{
				result = (ImGuiKey)0;
			}
			if (id == null)
			{
				return;
			}
			switch (id.Length)
			{
			case 9:
				switch (id[0])
				{
				case 'k':
					if (id == "key_y_fov")
					{
						CerberusConfig.Eye.FovHotKey = result;
					}
					break;
				case 'm':
					if (id == "m_enabled")
					{
						CerberusConfig.MeleeAimBot.LightHotKey = result;
					}
					break;
				}
				break;
			case 17:
				if (id == "access_viewer_key")
				{
					CerberusConfig.AccessViewer.HotKey = result;
				}
				break;
			case 22:
				if (id == "anomaly_scanner_hotkey")
				{
					CerberusConfig.AnomalyScanner.HotKey = result;
				}
				break;
			case 16:
				if (id == "key_y_fullbright")
				{
					CerberusConfig.Eye.FullBrightHotKey = result;
				}
				break;
			case 15:
				if (id == "deconstruct_key")
				{
					CerberusConfig.AutoDeconstruct.TargetKey = result;
				}
				break;
			case 12:
				switch (id[1])
				{
				case 'i':
					if (id == "mi_apeek_key")
					{
						CerberusConfig.Misc.AutoPeekKey = result;
					}
					break;
				case '_':
					if (id == "m_heavy_bind")
					{
						CerberusConfig.MeleeAimBot.HeavyHotKey = result;
					}
					break;
				case 'o':
					if (id == "mov_surf_key")
					{
						CerberusConfig.Movement.ToggleKey = result;
					}
					break;
				}
				break;
			case 13:
				switch (id[6])
				{
				case 'e':
					if (id == "key_g_enabled")
					{
						CerberusConfig.GunAimBot.HotKey = result;
					}
					break;
				case 'l':
					if (id == "auto_slip_key")
					{
						CerberusConfig.AutoSlip.ActivationKey = result;
					}
					break;
				case 'u':
					if (id == "auto_cuff_key")
					{
						CerberusConfig.AutoCuff.ActivationKey = result;
					}
					break;
				case 'y':
					if (id == "auto_hypo_key")
					{
						CerberusConfig.AutoHypo.ForceKey = result;
					}
					break;
				case 't':
					if (id == "auto_stop_key")
					{
						CerberusConfig.AutoStop.ActivationKey = result;
					}
					break;
				}
				break;
			case 11:
				if (id == "key_y_st_en")
				{
					CerberusConfig.StorageViewer.HotKey = result;
				}
				break;
			case 20:
				if (id == "health_info_hold_key")
				{
					CerberusConfig.HealthInfo.HoldKey = result;
				}
				break;
			case 10:
				switch (id[0])
				{
				case 'l':
					if (id == "looter_key")
					{
						CerberusConfig.AutoLooter.ToggleKey = result;
					}
					break;
				case 'k':
					if (id == "key_y_zoom")
					{
						CerberusConfig.Eye.ZoomUpHotKey = result;
					}
					break;
				}
				break;
			case 7:
				if (id == "st_menu")
				{
					CerberusConfig.Settings.ShowMenuHotKey = result;
				}
				break;
			case 14:
				switch (id[0])
				{
				case 'm':
					if (id == "mov_pxsurf_key")
					{
						CerberusConfig.Movement.PixelSurfKey = result;
					}
					break;
				case 'a':
					if (id == "auto_strip_key")
					{
						CerberusConfig.AutoStrip.StripAllKey = result;
					}
					break;
				}
				break;
			case 8:
			case 18:
			case 19:
			case 21:
				break;
			}
		}
		catch (Exception ex)
		{
			Logger.Info("Keybind Error: " + ex.Message);
		}
	}

	private void ApplyFeatureUpdate(string id, JsonElement value)
	{
		//IL_0453: Unknown result type (might be due to invalid IL or missing references)
		//IL_0458: Unknown result type (might be due to invalid IL or missing references)
		//IL_117c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1181: Unknown result type (might be due to invalid IL or missing references)
		//IL_4d41: Unknown result type (might be due to invalid IL or missing references)
		//IL_4d46: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b8a: Expected O, but got I4
		try
		{
			if (value.ValueKind == JsonValueKind.True || value.ValueKind == JsonValueKind.False)
			{
				if (value.GetBoolean())
				{
					SoundPlayer.PlayEnableSound();
				}
				else
				{
					SoundPlayer.PlayDisableSound();
				}
			}
			ConfigAutoSaver.MarkDirty();
			switch (id)
			{
			case "snd_volume":
				if (value.ValueKind == JsonValueKind.Number)
				{
					CerberusConfig.Sounds.Volume = value.GetSingle();
				}
				break;
			case "hud_enabled":
				CerberusConfig.HudOverlay.Enabled = value.GetBoolean();
				break;
			case "throw_traj":
				CerberusConfig.ThrowAimbot.ShowTrajectory = value.GetBoolean();
				break;
			case "deconstruct_en":
				CerberusConfig.AutoDeconstruct.Enabled = value.GetBoolean();
				break;
			case "nointeract_tags":
			{
				List<string> list3 = JsonSerializer.Deserialize<List<string>>(value.GetRawText());
				if (list3 != null)
				{
					CerberusConfig.NoInteract.BlockedTags = list3;
				}
				break;
			}
			case "cloaked_detector_show_ninja_warning":
				CerberusConfig.CloakedPlayerDetector.ShowWarningForNinja = value.GetBoolean();
				break;
			case "trap_esp_armed_color":
				CerberusConfig.TrapEsp.ArmedColor = ParseColor(value.GetString());
				break;
			case "nuke_brute_length":
				CerberusConfig.NukeBruteforce.CodeLength = value.GetInt32();
				break;
			case "g_ignore_downed":
				CerberusConfig.GunAimBot.IgnoreDowned = value.GetBoolean();
				break;
			case "hitsound_vol":
				if (value.ValueKind == JsonValueKind.Number)
				{
					CerberusConfig.HitSound.Volume = value.GetSingle();
				}
				break;
			case "hud_kill_counter":
				CerberusConfig.HudOverlay.ShowKillCounter = value.GetBoolean();
				break;
			case "cloaked_color":
				CerberusConfig.CloakedPlayerDetector.CloakedColor = ParseColor(value.GetString());
				break;
			case "hud_server_info":
				CerberusConfig.HudOverlay.ShowServerInfo = value.GetBoolean();
				break;
			case "esp_target_spirits_col":
				CerberusConfig.TargetEsp.SpiritsColor = ParseColor(value.GetString());
				break;
			case "trap_esp_mines":
				CerberusConfig.TrapEsp.ShowLandMines = value.GetBoolean();
				break;
			case "gren_radius":
				CerberusConfig.GrenadeHelper.ShowRadius = value.GetBoolean();
				break;
			case "backtrack_show_line":
				CerberusConfig.Backtrack.ShowLine = value.GetBoolean();
				break;
			case "g_only_visible":
				CerberusConfig.GunAimBot.OnlyVisibleTargets = value.GetBoolean();
				break;
			case "uplink_brute_input_delay":
				CerberusConfig.UplinkBruteforce.InputDelay = value.GetInt32();
				break;
			case "worldparticles_speed":
				CerberusConfig.WorldParticles.Speed = value.GetSingle();
				break;
			case "access_checker_checkmark_color":
				CerberusConfig.AccessChecker.CheckmarkColor = ParseColor(value.GetString());
				break;
			case "hud_shuttle_tracker":
				CerberusConfig.HudOverlay.ShowShuttleTracker = value.GetBoolean();
				break;
			case "auto_stop_key":
				CerberusConfig.AutoStop.ActivationKey = ParseImGuiKey(value.GetString());
				break;
			case "anomaly_scanner_color":
				CerberusConfig.AnomalyScanner.Color = ParseColor(value.GetString());
				break;
			case "hitbox_en":
				CerberusConfig.HitboxVisualizer.Enabled = value.GetBoolean();
				break;
			case "nuke_brute_speed":
				CerberusConfig.NukeBruteforce.Speed = value.GetInt32();
				break;
			case "auto_strip_weapons_first":
				CerberusConfig.AutoStrip.StripWeaponsFirst = value.GetBoolean();
				break;
			case "grill_electrocution_opacity":
				CerberusConfig.GrillElectrocution.Opacity = value.GetSingle();
				break;
			case "backtrack_use_fakelag":
				CerberusConfig.Backtrack.UseFakeLag = value.GetBoolean();
				break;
			case "turret_esp_enabled":
				CerberusConfig.TurretEsp.Enabled = value.GetBoolean();
				break;
			case "hitbox_extend":
				CerberusConfig.HitboxVisualizer.ExtendReach = value.GetBoolean();
				break;
			case "auto_hack_range":
				CerberusConfig.AutoHackDoors.Range = value.GetSingle();
				break;
			case "notrash_casings":
				CerberusConfig.NoTrash.HideCasings = value.GetBoolean();
				break;
			case "chams_mode":
				if (value.ValueKind != JsonValueKind.String)
				{
					CerberusConfig.Chams.Mode = value.GetInt32();
					break;
				}
				switch (value.GetString())
				{
				case "Rainbow":
					CerberusConfig.Chams.Mode = 4;
					break;
				case "Wireframe":
					CerberusConfig.Chams.Mode = 5;
					break;
				case "Flat":
					CerberusConfig.Chams.Mode = 0;
					break;
				case "Galaxy":
					CerberusConfig.Chams.Mode = 2;
					break;
				case "Glow":
					CerberusConfig.Chams.Mode = 6;
					break;
				case "Metallic":
					CerberusConfig.Chams.Mode = 3;
					break;
				case "Pulse":
					CerberusConfig.Chams.Mode = 1;
					break;
				}
				break;
			case "auto_stop_interval":
				CerberusConfig.AutoStop.IntervalMs = value.GetSingle();
				break;
			case "y_job_i":
				CerberusConfig.Hud.ShowJobIcons = value.GetBoolean();
				break;
			case "p_enabled":
				CerberusConfig.ProjectileEsp.Enabled = value.GetBoolean();
				break;
			case "hud_round_time":
				CerberusConfig.HudOverlay.ShowRoundTime = value.GetBoolean();
				break;
			case "auto_painter.detail_level":
				if (value.ValueKind == JsonValueKind.Number)
				{
					int detailLevel = (CerberusConfig.AutoPainter.DetailLevel = value.GetInt32());
					CrayonImageDrawer gClass4 = default(CrayonImageDrawer);
					if (IoCManager.Resolve<IEntitySystemManager>().TryGetEntitySystem<CrayonImageDrawer>(ref gClass4))
					{
						gClass4.DetailLevel = detailLevel;
					}
				}
				break;
			case "deconstruct_delay":
				CerberusConfig.AutoDeconstruct.ActionDelay = value.GetInt32();
				break;
			case "p_dodge_range":
				CerberusConfig.ProjectileEsp.DodgeRange = value.GetSingle();
				break;
			case "cloaked_enabled":
				CerberusConfig.CloakedPlayerDetector.Enabled = value.GetBoolean();
				break;
			case "hitparticles_lifetime":
				CerberusConfig.HitParticles.ParticleLifetime = value.GetSingle();
				break;
			case "backtrack_visuals":
				CerberusConfig.Backtrack.ShowVisuals = value.GetBoolean();
				break;
			case "health_info_offset_y":
				CerberusConfig.HealthInfo.TextOffset = new Vector2(CerberusConfig.HealthInfo.TextOffset.X, value.GetSingle());
				break;
			case "g_multi_target":
				CerberusConfig.GunAimBot.MultiTarget = value.GetBoolean();
				break;
			case "storage_viewer_font_path":
				CerberusConfig.StorageViewer.FontPath = value.GetString();
				break;
			case "instant_pickup_smart_equip":
				CerberusConfig.InstantPickup.SmartEquipEnabled = value.GetBoolean();
				break;
			case "anomaly_scanner_max_distance":
				CerberusConfig.AnomalyScanner.MaxDistance = value.GetSingle();
				break;
			case "notrash_decals":
				CerberusConfig.NoTrash.HideDecals = value.GetBoolean();
				break;
			case "lightenhancement_energy":
				CerberusConfig.LightEnhancement.EnergyMultiplier = value.GetSingle();
				break;
			case "gren_enabled":
				CerberusConfig.GrenadeHelper.Enabled = value.GetBoolean();
				break;
			case "killsound_idx":
				CerberusConfig.KillSound.SoundIndex = value.GetInt32();
				MeleeHitPatch.PlayHitSound(isKill: true, force: true);
				break;
			case "perf_physics":
				CerberusConfig.Performance.ReducePhysicsQuality = value.GetBoolean();
				break;
			case "notrash_lamps":
				CerberusConfig.NoTrash.HideLamps = value.GetBoolean();
				break;
			case "hud_session_timer":
				CerberusConfig.HudOverlay.ShowSessionTimer = value.GetBoolean();
				break;
			case "m_prio":
				switch (value.GetString())
				{
				case "Distance":
					CerberusConfig.MeleeAimBot.TargetPriority = 0;
					break;
				case "Mouse":
					CerberusConfig.MeleeAimBot.TargetPriority = 1;
					break;
				case "Health":
					CerberusConfig.MeleeAimBot.TargetPriority = 2;
					break;
				}
				break;
			case "hud_staff_list":
				CerberusConfig.HudOverlay.ShowStaffList = value.GetBoolean();
				break;
			case "m_fixdelayval":
				CerberusConfig.MeleeAimBot.FixDelay = value.GetSingle();
				break;
			case "cloaked_detector_show_outline":
				CerberusConfig.CloakedPlayerDetector.ShowOutline = value.GetBoolean();
				break;
			case "e_contra":
				CerberusConfig.Esp.ShowContraband = value.GetBoolean();
				break;
			case "cloaked_detector_cloaked_color":
				CerberusConfig.CloakedPlayerDetector.CloakedColor = ParseColor(value.GetString());
				break;
			case "worldparticles_enabled":
				CerberusConfig.WorldParticles.Enabled = value.GetBoolean();
				break;
			case "trails_length":
				CerberusConfig.Trails.TrailLength = value.GetSingle();
				break;
			case "y_smoke":
				CerberusConfig.Settings.SmokePatch = value.GetBoolean();
				break;
			case "y_hud_col":
				CerberusConfig.Hud.StaminaColor = ParseColor(value.GetString());
				break;
			case "g_prio":
				switch (value.GetString())
				{
				case "Distance":
					CerberusConfig.GunAimBot.TargetPriority = 0;
					break;
				case "Health":
					CerberusConfig.GunAimBot.TargetPriority = 2;
					break;
				case "Mouse":
					CerberusConfig.GunAimBot.TargetPriority = 1;
					break;
				}
				break;
			case "g_pred":
				CerberusConfig.GunAimBot.PredictEnabled = value.GetBoolean();
				break;
			case "foam_fading_en":
				CerberusConfig.FoamFading.Enabled = value.GetBoolean();
				break;
			case "y_rec_i":
				CerberusConfig.Hud.ShowCriminalRecordIcons = value.GetBoolean();
				break;
			case "light_boost_energy":
				CerberusConfig.LightEnhancement.EnergyMultiplier = value.GetSingle();
				break;
			case "notif_feature_toggle":
				CerberusConfig.NotificationSettings.FeatureToggleNotification = value.GetBoolean();
				break;
			case "trap_esp_maxdist":
				CerberusConfig.TrapEsp.MaxDistance = value.GetSingle();
				break;
			case "perf_animations":
				CerberusConfig.Performance.DisableAnimations = value.GetBoolean();
				break;
			case "auto_shoot_delay":
				CerberusConfig.AutoShoot.FireDelay = value.GetInt32();
				break;
			case "y_stamina_bar_width":
				CerberusConfig.Hud.StaminaBarWidth = value.GetSingle();
				break;
			case "hud_bg":
				CerberusConfig.HudOverlay.BgColor = ParseColor(value.GetString());
				break;
			case "grill_electrocution_enabled":
				CerberusConfig.GrillElectrocution.Enabled = value.GetBoolean();
				break;
			case "y_health_bar_height":
				CerberusConfig.Hud.HealthBarHeight = value.GetSingle();
				break;
			case "target_lock_unlock_death":
				CerberusConfig.TargetLock.UnlockOnDeath = value.GetBoolean();
				break;
			case "ambient_light_enabled":
				CerberusConfig.AmbientLight.Enabled = value.GetBoolean();
				break;
			case "throw_ignore_downed":
				CerberusConfig.ThrowAimbot.IgnoreDowned = value.GetBoolean();
				break;
			case "cloaked_outline":
				CerberusConfig.CloakedPlayerDetector.ShowOutline = value.GetBoolean();
				break;
			case "notif_fade_in":
				CerberusConfig.NotificationSettings.FadeInTime = value.GetSingle();
				break;
			case "ambient_light_mode":
				CerberusConfig.AmbientLight.Mode = value.GetInt32();
				break;
			case "tracers_variant":
				CerberusConfig.Tracers.ArrowVariant = value.GetInt32();
				break;
			case "hud_shuttle_show_direction":
				CerberusConfig.HudOverlay.ShuttleShowDirection = value.GetBoolean();
				break;
			case "hitparticles_color":
				CerberusConfig.HitParticles.ParticleColor = ParseColor(value.GetString());
				break;
			case "auto_cuff_only_stunned":
				CerberusConfig.AutoCuff.OnlyStunned = value.GetBoolean();
				break;
			case "health_info_font_path":
				CerberusConfig.HealthInfo.FontPath = value.GetString();
				break;
			case "hud_edit":
				CerberusConfig.HudOverlay.EditMode = value.GetBoolean();
				break;
			case "abilityspeed_delay":
				CerberusConfig.AbilitySpeed.DelayMs = value.GetInt32();
				break;
			case "mi_exp":
				CerberusConfig.Misc.ShowExplosive = value.GetBoolean();
				break;
			case "st_dmg_fs":
				CerberusConfig.Settings.DamageForcePatch = value.GetBoolean();
				break;
			case "esp_target_spirits_size":
				CerberusConfig.TargetEsp.SpiritsSize = value.GetSingle();
				break;
			case "g_circle":
				CerberusConfig.GunAimBot.ShowCircle = value.GetBoolean();
				break;
			case "notif_antag_delay":
				CerberusConfig.NotificationSettings.AntagSpawnDelay = value.GetSingle();
				break;
			case "trails_size":
				CerberusConfig.Trails.TrailSize = value.GetSingle();
				break;
			case "trails_mode":
				CerberusConfig.Trails.TrailMode = value.GetInt32();
				break;
			case "cloaked_threshold":
				CerberusConfig.CloakedPlayerDetector.MinVisibilityThreshold = value.GetSingle();
				break;
			case "m_crit":
				CerberusConfig.MeleeAimBot.TargetCritical = value.GetBoolean();
				break;
			case "hud_connection_quality":
				CerberusConfig.HudOverlay.ShowConnectionQuality = value.GetBoolean();
				break;
			case "g_onlyprio":
				CerberusConfig.GunAimBot.OnlyPriority = value.GetBoolean();
				break;
			case "solution_scanner_en":
				CerberusConfig.SolutionScanner.Enabled = value.GetBoolean();
				break;
			case "ambient_light_intensity":
				CerberusConfig.AmbientLight.Intensity = value.GetSingle();
				break;
			case "auto_cuff_key":
				CerberusConfig.AutoCuff.ActivationKey = ParseImGuiKey(value.GetString());
				break;
			case "hud_arraylist":
				CerberusConfig.HudOverlay.ShowArrayList = value.GetBoolean();
				break;
			case "e_prio":
				CerberusConfig.Esp.ShowPriority = value.GetBoolean();
				break;
			case "e_wep":
				CerberusConfig.Esp.ShowWeapon = value.GetBoolean();
				break;
			case "filter_ignore_ghosts":
				CerberusConfig.TargetFilters.IgnoreGhosts = value.GetBoolean();
				break;
			case "hud_net_graph":
				CerberusConfig.HudOverlay.ShowConnectionQuality = value.GetBoolean();
				break;
			case "e_c_friend":
				CerberusConfig.Esp.FriendColor = ParseColor(value.GetString());
				break;
			case "hud_speed":
				CerberusConfig.HudOverlay.ShowSpeed = value.GetBoolean();
				break;
			case "uplink_brute_random_mode":
				CerberusConfig.UplinkBruteforce.RandomMode = value.GetBoolean();
				break;
			case "hitbox_reach":
				CerberusConfig.HitboxVisualizer.ReachMultiplier = value.GetSingle();
				break;
			case "y_overlay":
				CerberusConfig.Settings.OverlaysPatch = value.GetBoolean();
				break;
			case "hud_color":
				CerberusConfig.HudOverlay.TextColor = ParseColor(value.GetString());
				break;
			case "snd_pack":
				CerberusConfig.Sounds.SelectedPackIndex = value.GetInt32();
				SoundPlayer.PlayEnableSound();
				break;
			case "hitbox_items":
				CerberusConfig.HitboxVisualizer.ShowItems = value.GetBoolean();
				break;
			case "gh_rotate":
				CerberusConfig.GunHelper.RotateToTarget = value.GetBoolean();
				break;
			case "worldparticles_radius":
				CerberusConfig.WorldParticles.SpawnRadius = value.GetSingle();
				break;
			case "y_contraband_i":
				CerberusConfig.Hud.ShowContrabandDetails = value.GetBoolean();
				break;
			case "mc_jump_variant":
				CerberusConfig.MinecraftVisuals.JumpCircleVariant = value.GetInt32();
				break;
			case "cloaked_detector_enabled":
				CerberusConfig.CloakedPlayerDetector.Enabled = value.GetBoolean();
				break;
			case "foam_fading_alpha":
				CerberusConfig.FoamFading.Alpha = value.GetSingle();
				break;
			case "free_cam_speed":
				CerberusConfig.FreeCam.Speed = value.GetSingle();
				break;
			case "mi_strafe_range":
				CerberusConfig.Misc.TargetStrafeRange = value.GetSingle();
				break;
			case "auto_slip_role_prio":
				CerberusConfig.AutoSlip.UseRolePriority = value.GetBoolean();
				break;
			case "auto_shoot_enabled":
				CerberusConfig.AutoShoot.Enabled = value.GetBoolean();
				break;
			case "no_interact_en":
				CerberusConfig.NoInteract.Enabled = value.GetBoolean();
				break;
			case "freecam_speed":
				CerberusConfig.FreeCam.Speed = value.GetSingle();
				break;
			case "auto_strip_clothing":
				CerberusConfig.AutoStrip.StripClothing = value.GetBoolean();
				break;
			case "ambient_light_custom_color":
				CerberusConfig.AmbientLight.CustomColor = ParseColor(value.GetString());
				break;
			case "glow_size":
				CerberusConfig.PlayerGlow.GlowSize = value.GetSingle();
				break;
			case "notif_low_hp":
				CerberusConfig.NotificationSettings.LowHpNotification = value.GetBoolean();
				break;
			case "s_item_list":
			{
				List<ItemDto> list2 = JsonSerializer.Deserialize<List<ItemDto>>(value.GetRawText(), new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});
				CerberusConfig.Misc.ItemSearchEntries.Clear();
				if (list2 == null)
				{
					break;
				}
				{
					foreach (ItemDto item in list2)
					{
						CerberusConfig.Misc.ItemSearchEntries.Add(new ColoredString
						{
							string_0 = item.Name,
							vector4_0 = ParseColor(item.Color)
						});
					}
					break;
				}
			}
			case "hitparticles_en":
				CerberusConfig.HitParticles.Enabled = value.GetBoolean();
				break;
			case "ambient_fog_density":
				CerberusConfig.LightSmooth.FogDensity = value.GetSingle();
				break;
			case "notif_stamina_threshold":
				CerberusConfig.NotificationSettings.LowStaminaThreshold = value.GetSingle();
				break;
			case "g_radius":
				CerberusConfig.GunAimBot.CircleRadius = value.GetSingle();
				break;
			case "looter_delay":
				CerberusConfig.AutoLooter.PickupDelay = value.GetSingle();
				break;
			case "trap_esp_disarmed_color":
				CerberusConfig.TrapEsp.DisarmedColor = ParseColor(value.GetString());
				break;
			case "medipen_hp":
				CerberusConfig.AutoMedipen.HpThreshold = value.GetSingle();
				break;
			case "hud_crosshair_color":
				CerberusConfig.HudOverlay.CrosshairColor = ParseColor(value.GetString());
				break;
			case "packet_spammer_packet_size":
				CerberusConfig.PacketSpammer.PacketSize = value.GetInt32();
				break;
			case "turret_esp_radius":
				CerberusConfig.TurretEsp.ShowAttackRadius = value.GetBoolean();
				break;
			case "m_fixdelay":
				CerberusConfig.MeleeAimBot.FixNetworkDelay = value.GetBoolean();
				break;
			case "implant_hp":
				CerberusConfig.AutoImplant.HpThreshold = value.GetSingle();
				break;
			case "g_hitscan":
				CerberusConfig.GunAimBot.HitScan = value.GetBoolean();
				break;
			case "health_info_font_index":
				CerberusConfig.HealthInfo.FontIndex = value.GetInt32();
				break;
			case "trap_esp_triggers":
				CerberusConfig.TrapEsp.ShowStepTriggers = value.GetBoolean();
				break;
			case "y_st_en":
				CerberusConfig.StorageViewer.Enabled = value.GetBoolean();
				break;
			case "esp_target_spirits_trail":
				CerberusConfig.TargetEsp.SpiritsTrailLength = value.GetSingle();
				break;
			case "hud_ping":
				CerberusConfig.HudOverlay.ShowPing = value.GetBoolean();
				break;
			case "smart_target_prio":
				CerberusConfig.SmartTargetSelection.Priority = value.GetInt32();
				break;
			case "perf_culling":
				CerberusConfig.Performance.AggressiveCulling = value.GetBoolean();
				break;
			case "combat_autoblock":
				CerberusConfig.Combat.AutoBlockEnabled = value.GetBoolean();
				break;
			case "m_radius":
				CerberusConfig.MeleeAimBot.CircleRadius = value.GetSingle();
				break;
			case "door_close":
				CerberusConfig.AutoDoor.AutoClose = value.GetBoolean();
				break;
			case "gren_timer":
				CerberusConfig.GrenadeHelper.ShowTimer = value.GetBoolean();
				break;
			case "throw_enabled":
				CerberusConfig.ThrowAimbot.Enabled = value.GetBoolean();
				break;
			case "lightenhancement_radius":
				CerberusConfig.LightEnhancement.RadiusMultiplier = value.GetSingle();
				break;
			case "mov_surf":
				CerberusConfig.Movement.ShieldSurfEnabled = value.GetBoolean();
				break;
			case "mi_strafe_dist":
				CerberusConfig.Misc.TargetStrafeDistance = value.GetSingle();
				break;
			case "hitbox_item_color":
				CerberusConfig.HitboxVisualizer.ItemColor = ParseColor(value.GetString());
				break;
			case "g_predcorr":
				CerberusConfig.GunAimBot.PredictCorrection = value.GetSingle();
				break;
			case "snd_enabled":
				CerberusConfig.Sounds.Enabled = value.GetBoolean();
				break;
			case "hitsound_idx":
				CerberusConfig.HitSound.SoundIndex = value.GetInt32();
				MeleeHitPatch.PlayHitSound();
				break;
			case "s_item_name":
				CerberusConfig.Misc.ItemSearcherShowName = value.GetBoolean();
				break;
			case "e_size":
				CerberusConfig.Esp.MainFontSize = value.GetInt32();
				break;
			case "hud_crosshair_style":
				CerberusConfig.HudOverlay.CrosshairStyle = value.GetInt32();
				break;
			case "st_grab":
				CerberusConfig.Settings.AntiScreenGrubPatch = value.GetBoolean();
				break;
			case "mi_apeek_col":
				CerberusConfig.Misc.AutoPeekColor = ParseColor(value.GetString());
				break;
			case "ambient_tint_color":
				CerberusConfig.LightSmooth.TintColor = ParseColor(value.GetString());
				break;
			case "target_lock_enabled":
				CerberusConfig.TargetLock.Enabled = value.GetBoolean();
				break;
			case "e_c_ckey":
				CerberusConfig.Esp.CKeyColor = ParseColor(value.GetString());
				break;
			case "auto_hack_cooldown":
				CerberusConfig.AutoHackDoors.Cooldown = value.GetSingle();
				break;
			case "m_enabled":
				CerberusConfig.MeleeAimBot.Enabled = value.GetBoolean();
				break;
			case "storage_viewer_font_size":
				CerberusConfig.StorageViewer.FontSize = value.GetInt32();
				break;
			case "trails_color":
				CerberusConfig.Trails.TrailColor = ParseColor(value.GetString());
				break;
			case "auto_hypo_count":
				CerberusConfig.AutoHypo.InjectCount = value.GetInt32();
				break;
			case "lightenhancement_enabled":
				CerberusConfig.LightEnhancement.Enabled = value.GetBoolean();
				break;
			case "light_boost_enabled":
				CerberusConfig.LightEnhancement.Enabled = value.GetBoolean();
				break;
			case "hitparticles_opacity":
				CerberusConfig.HitParticles.Opacity = value.GetSingle();
				break;
			case "mi_afk":
				CerberusConfig.Misc.AntiAfkEnabled = value.GetBoolean();
				break;
			case "e_friend":
				CerberusConfig.Esp.ShowFriend = value.GetBoolean();
				break;
			case "worldparticles_mode":
				CerberusConfig.WorldParticles.ParticleMode = value.GetInt32();
				break;
			case "ambientlight_mode":
				CerberusConfig.AmbientLight.Mode = value.GetInt32();
				break;
			case "mi_apeek":
				CerberusConfig.Misc.AutoPeekEnabled = value.GetBoolean();
				break;
			case "nointeract_en":
				CerberusConfig.NoInteract.Enabled = value.GetBoolean();
				break;
			case "y_clyde":
				CerberusConfig.Settings.ClydePatch = value.GetBoolean();
				break;
			case "backtrack_mode":
				switch (value.GetString())
				{
				case "Aggressive":
					CerberusConfig.Backtrack.Mode = 0;
					break;
				case "Normal":
					CerberusConfig.Backtrack.Mode = 1;
					break;
				case "Conservative":
					CerberusConfig.Backtrack.Mode = 2;
					break;
				}
				break;
			case "backtrack_visuals_color":
				CerberusConfig.Backtrack.VisualsColor = ParseColor(value.GetString());
				break;
			case "ambient_fog_color":
				CerberusConfig.LightSmooth.FogColor = ParseColor(value.GetString());
				break;
			case "auto_hack_enabled":
				CerberusConfig.AutoHackDoors.Enabled = value.GetBoolean();
				break;
			case "trap_esp_proximity":
				CerberusConfig.TrapEsp.ShowProximitySensors = value.GetBoolean();
				break;
			case "mh_360":
				CerberusConfig.MeleeHelper.Attack360 = value.GetBoolean();
				break;
			case "y_stamina_bar_offset_y":
				CerberusConfig.Hud.StaminaBarOffsetY = value.GetSingle();
				break;
			case "e_interval":
				CerberusConfig.Esp.FontInterval = value.GetInt32();
				break;
			case "cloaked_ninja_color":
				CerberusConfig.CloakedPlayerDetector.NinjaColor = ParseColor(value.GetString());
				break;
			case "uplink_brute_en":
				CerberusConfig.UplinkBruteforce.Enabled = value.GetBoolean();
				break;
			case "trails_enabled":
				CerberusConfig.Trails.Enabled = value.GetBoolean();
				break;
			case "grill_electrocution_color":
				CerberusConfig.GrillElectrocution.Color = ParseColor(value.GetString());
				break;
			case "auto_path_enabled":
				CerberusConfig.AutoPath.Enabled = value.GetBoolean();
				break;
			case "worldparticles_opacity":
				CerberusConfig.WorldParticles.Opacity = value.GetSingle();
				break;
			case "auto_hack_only_bolted":
				CerberusConfig.AutoHackDoors.OnlyBoltedDoors = value.GetBoolean();
				break;
			case "access_viewer_col":
				CerberusConfig.AccessViewer.Color = ParseColor(value.GetString());
				break;
			case "surgery_exploit_en":
				CerberusConfig.SurgeryExploit.Enabled = value.GetBoolean();
				break;
			case "perf_decals":
				CerberusConfig.Performance.DisableDecals = value.GetBoolean();
				break;
			case "e_name":
				CerberusConfig.Esp.ShowName = value.GetBoolean();
				break;
			case "e_c_wep":
				CerberusConfig.Esp.WeaponColor = ParseColor(value.GetString());
				break;
			case "e_ckey":
				CerberusConfig.Esp.ShowCKey = value.GetBoolean();
				break;
			case "worldparticles_glow":
				CerberusConfig.WorldParticles.UseGlow = value.GetBoolean();
				break;
			case "perf_en":
				CerberusConfig.Performance.Enabled = value.GetBoolean();
				break;
			case "perf_postprocess":
				CerberusConfig.Performance.DisablePostProcessing = value.GetBoolean();
				break;
			case "auto_slip_range":
				CerberusConfig.AutoSlip.Range = value.GetSingle();
				break;
			case "gh_ammo":
				CerberusConfig.GunHelper.ShowAmmo = value.GetBoolean();
				break;
			case "p_traj":
				CerberusConfig.ProjectileEsp.ShowTrajectory = value.GetBoolean();
				break;
			case "gh_enabled":
				CerberusConfig.GunHelper.Enabled = value.GetBoolean();
				break;
			case "g_line":
				CerberusConfig.GunAimBot.ShowLine = value.GetBoolean();
				break;
			case "mi_speedhack_delay":
				CerberusConfig.Misc.ZeroGSpeedDelay = value.GetSingle();
				break;
			case "trap_esp_radius":
				CerberusConfig.TrapEsp.ShowTriggerRadius = value.GetBoolean();
				break;
			case "uplink_brute_speed":
				CerberusConfig.UplinkBruteforce.Speed = value.GetInt32();
				break;
			case "access_viewer_font_path":
				CerberusConfig.AccessViewer.FontPath = value.GetString();
				break;
			case "e_text_offset_x":
				CerberusConfig.Esp.TextOffsetX = value.GetSingle();
				break;
			case "notif_hp_threshold":
				CerberusConfig.NotificationSettings.LowHpThreshold = value.GetSingle();
				break;
			case "mi_trash":
				CerberusConfig.Misc.TrashTalkEnabled = value.GetBoolean();
				break;
			case "g_enabled":
				CerberusConfig.GunAimBot.Enabled = value.GetBoolean();
				break;
			case "g_reload_delay":
				CerberusConfig.GunHelper.AutoReloadDelay = value.GetSingle();
				break;
			case "backtrack_fakelag_ms":
				CerberusConfig.Backtrack.FakeLagMs = value.GetInt32();
				break;
			case "auto_painter.draw_delay_ms":
				if (value.ValueKind == JsonValueKind.Number)
				{
					int drawDelayMs = (CerberusConfig.AutoPainter.DrawDelayMs = value.GetInt32());
					CrayonImageDrawer gClass3 = default(CrayonImageDrawer);
					if (IoCManager.Resolve<IEntitySystemManager>().TryGetEntitySystem<CrayonImageDrawer>(ref gClass3))
					{
						gClass3.DrawDelayMs = drawDelayMs;
					}
				}
				break;
			case "y_syn_i":
				CerberusConfig.Hud.ShowSyndicateIcons = value.GetBoolean();
				break;
			case "g_minspread":
				CerberusConfig.GunAimBot.MinSpread = value.GetBoolean();
				break;
			case "auto_strip_range":
				CerberusConfig.AutoStrip.Range = value.GetSingle();
				break;
			case "auto_strip_armor":
				CerberusConfig.AutoStrip.StripArmor = value.GetBoolean();
				break;
			case "mi_strafe":
				CerberusConfig.Misc.TargetStrafeEnabled = value.GetBoolean();
				break;
			case "gh_bolt":
				CerberusConfig.GunHelper.AutoBolt = value.GetBoolean();
				break;
			case "y_mind_i":
				CerberusConfig.Hud.ShowMindShieldIcons = value.GetBoolean();
				break;
			case "door_en":
				CerberusConfig.AutoDoor.Enabled = value.GetBoolean();
				break;
			case "hud_crosshair":
				CerberusConfig.HudOverlay.ShowCrosshair = value.GetBoolean();
				break;
			case "hitbox_all":
				CerberusConfig.HitboxVisualizer.ShowAll = value.GetBoolean();
				break;
			case "target_lock_max_dist":
				CerberusConfig.TargetLock.MaxDistance = value.GetSingle();
				break;
			case "notif_animation_mode":
				CerberusConfig.NotificationSettings.AnimationMode = value.GetInt32();
				break;
			case "mc_fade_out_speed":
				CerberusConfig.MinecraftVisuals.JumpCircleFadeOutSpeed = value.GetSingle();
				break;
			case "grill_electrocution_max_distance":
				CerberusConfig.GrillElectrocution.MaxDistance = value.GetSingle();
				break;
			case "notif_ammo_threshold":
				CerberusConfig.NotificationSettings.LowAmmoThreshold = value.GetInt32();
				break;
			case "perf_shaders":
				CerberusConfig.Performance.SimplifyShaders = value.GetBoolean();
				break;
			case "auto_strip_enabled":
				CerberusConfig.AutoStrip.Enabled = value.GetBoolean();
				break;
			case "anomaly_scanner_font_size":
				CerberusConfig.AnomalyScanner.FontSize = value.GetInt32();
				break;
			case "e_text_offset_y":
				CerberusConfig.Esp.TextOffsetY = value.GetSingle();
				break;
			case "trails_count":
				CerberusConfig.Trails.ParticleCount = value.GetInt32();
				break;
			case "surgery_exploit_group2":
				CerberusConfig.SurgeryExploit.Group2DepthEnabled = value.GetBoolean();
				break;
			case "hud_connection_show_graph":
				CerberusConfig.HudOverlay.ConnectionShowGraph = value.GetBoolean();
				break;
			case "hud_shuttle_show_distance":
				CerberusConfig.HudOverlay.ShuttleShowDistance = value.GetBoolean();
				break;
			case "p_radius":
				CerberusConfig.ProjectileEsp.DetectionRadius = value.GetSingle();
				break;
			case "medipen_en":
				CerberusConfig.AutoMedipen.Enabled = value.GetBoolean();
				break;
			case "instant_pickup_en":
				CerberusConfig.InstantPickup.Enabled = value.GetBoolean();
				break;
			case "auto_hypo_enabled":
				CerberusConfig.AutoHypo.Enabled = value.GetBoolean();
				break;
			case "mc_rotation_speed":
				CerberusConfig.MinecraftVisuals.JumpCircleRotationSpeed = value.GetSingle();
				break;
			case "packet_spammer_burst_delay":
				CerberusConfig.PacketSpammer.BurstDelay = value.GetInt32();
				break;
			case "mi_dmg":
				CerberusConfig.Misc.DamageOverlayEnabled = value.GetBoolean();
				break;
			case "cloaked_detector_min_visibility":
				CerberusConfig.CloakedPlayerDetector.MinVisibilityThreshold = value.GetSingle();
				break;
			case "e_antag":
				CerberusConfig.Esp.ShowAntag = value.GetBoolean();
				break;
			case "throw_ignore_cuffed":
				CerberusConfig.ThrowAimbot.IgnoreCuffed = value.GetBoolean();
				break;
			case "backtrack_enabled":
				CerberusConfig.Backtrack.Enabled = value.GetBoolean();
				break;
			case "gh_reload":
				CerberusConfig.GunHelper.AutoReload = value.GetBoolean();
				break;
			case "throw_only_priority":
				CerberusConfig.ThrowAimbot.OnlyPriority = value.GetBoolean();
				break;
			case "notif_low_ammo":
				CerberusConfig.NotificationSettings.LowAmmoNotification = value.GetBoolean();
				break;
			case "auto_hack_require_multitool":
				CerberusConfig.AutoHackDoors.RequireMultitool = value.GetBoolean();
				break;
			case "trails_lifetime":
				CerberusConfig.Trails.TrailLifetime = value.GetSingle();
				break;
			case "esp_target_spirits":
				CerberusConfig.TargetEsp.SpiritsEnabled = value.GetBoolean();
				break;
			case "auto_slip_speed":
				CerberusConfig.AutoSlip.ThrowSpeed = value.GetSingle();
				break;
			case "p_dodge":
				CerberusConfig.ProjectileEsp.AutoDodge = value.GetBoolean();
				break;
			case "g_ignore_cuffed":
				CerberusConfig.GunAimBot.IgnoreCuffed = value.GetBoolean();
				break;
			case "nuke_brute_en":
				CerberusConfig.NukeBruteforce.Enabled = value.GetBoolean();
				break;
			case "mi_autofuckrules_mode":
				CerberusConfig.Misc.AutoFuckRulesMode = value.GetInt32();
				break;
			case "freecam_smoothing":
				CerberusConfig.FreeCam.Smoothing = value.GetSingle();
				break;
			case "perf_lowquality":
				CerberusConfig.Performance.LowQualitySprites = value.GetBoolean();
				break;
			case "packet_spammer_packet_type":
				CerberusConfig.PacketSpammer.PacketType = value.GetInt32();
				break;
			case "y_fov":
				CerberusConfig.Eye.FovEnabled = value.GetBoolean();
				break;
			case "perf_weather":
				CerberusConfig.Performance.DisableWeatherEffects = value.GetBoolean();
				break;
			case "g_crit":
				CerberusConfig.GunAimBot.TargetCritical = value.GetBoolean();
				break;
			case "auto_stop_enabled":
				CerberusConfig.AutoStop.Enabled = value.GetBoolean();
				break;
			case "perf_footsteps":
				CerberusConfig.Performance.DisableFootsteps = value.GetBoolean();
				break;
			case "mh_auto":
				CerberusConfig.MeleeHelper.AutoAttack = value.GetBoolean();
				break;
			case "auto_cuff_enabled":
				CerberusConfig.AutoCuff.Enabled = value.GetBoolean();
				break;
			case "ambient_vignette":
				CerberusConfig.LightSmooth.VignetteStrength = value.GetSingle();
				break;
			case "combat_autolaydown_delay":
				CerberusConfig.Combat.AutoLaydownStandUpDelay = value.GetSingle();
				break;
			case "m_line":
				CerberusConfig.MeleeAimBot.ShowLine = value.GetBoolean();
				break;
			case "glow_density":
				CerberusConfig.PlayerGlow.GlowDensity = value.GetInt32();
				break;
			case "g_color":
				CerberusConfig.GunAimBot.Color = ParseColor(value.GetString());
				break;
			case "access_checker_enabled":
				CerberusConfig.AccessChecker.Enabled = value.GetBoolean();
				break;
			case "filter_max_dist":
				CerberusConfig.TargetFilters.MaxDistance = value.GetSingle();
				break;
			case "freecam_enabled":
				CerberusConfig.FreeCam.Enabled = value.GetBoolean();
				break;
			case "m_onlyprio":
				CerberusConfig.MeleeAimBot.OnlyPriority = value.GetBoolean();
				break;
			case "perf_culling_dist":
				CerberusConfig.Performance.CullingDistance = value.GetSingle();
				break;
			case "anti_aim_enabled":
				CerberusConfig.Movement.AntiAimEnabled = value.GetBoolean();
				break;
			case "notif_progress_bar":
				CerberusConfig.NotificationSettings.ShowProgressBar = value.GetBoolean();
				break;
			case "g_ignore_dead":
				CerberusConfig.GunAimBot.IgnoreDead = value.GetBoolean();
				break;
			case "hud_fps":
				CerberusConfig.HudOverlay.ShowFps = value.GetBoolean();
				break;
			case "access_viewer_font_size":
				CerberusConfig.AccessViewer.FontSize = value.GetInt32();
				break;
			case "hitbox_other_color":
				CerberusConfig.HitboxVisualizer.OtherColor = ParseColor(value.GetString());
				break;
			case "y_health_bar_offset_y":
				CerberusConfig.Hud.HealthBarOffsetY = value.GetSingle();
				break;
			case "y_antag_i":
				CerberusConfig.Hud.ShowAntag = value.GetBoolean();
				break;
			case "hitbox_player_color":
				CerberusConfig.HitboxVisualizer.PlayerColor = ParseColor(value.GetString());
				break;
			case "y_thirst_i":
				CerberusConfig.Hud.ShowThirstIcons = value.GetBoolean();
				break;
			case "killsound_en":
				CerberusConfig.KillSound.Enabled = value.GetBoolean();
				break;
			case "e_c_impl":
				CerberusConfig.Esp.ImplantsColor = ParseColor(value.GetString());
				break;
			case "esp_target_spirits_rad_y":
				CerberusConfig.TargetEsp.SpiritsOrbitRadiusY = value.GetSingle();
				break;
			case "notif_fade_out":
				CerberusConfig.NotificationSettings.FadeOutTime = value.GetSingle();
				break;
			case "mov_pxsurf_mode":
				CerberusConfig.Movement.PixelSurfMode = value.GetInt32();
				break;
			case "perf_particles":
				CerberusConfig.Performance.DisableParticles = value.GetBoolean();
				break;
			case "st_admin":
				CerberusConfig.Settings.AdminPatch = value.GetBoolean();
				break;
			case "cloaked_detector_maxdist":
				CerberusConfig.CloakedPlayerDetector.MaxDistance = value.GetSingle();
				break;
			case "worldparticles_count":
				CerberusConfig.WorldParticles.ParticleCount = value.GetInt32();
				break;
			case "auto_cuff_priority":
				CerberusConfig.AutoCuff.TargetPriority = (GEnum11)value.GetInt32();
				break;
			case "access_viewer_en":
				CerberusConfig.AccessViewer.Enabled = value.GetBoolean();
				break;
			case "y_stamina_bar_offset_x":
				CerberusConfig.Hud.StaminaBarOffsetX = value.GetSingle();
				break;
			case "abilityspeed_distance":
				CerberusConfig.AbilitySpeed.DashDistance = value.GetSingle();
				break;
			case "looter_range":
				CerberusConfig.AutoLooter.Range = value.GetSingle();
				break;
			case "health_info_font_size":
				CerberusConfig.HealthInfo.FontSize = value.GetInt32();
				break;
			case "filter_min_dist":
				CerberusConfig.TargetFilters.MinDistance = value.GetSingle();
				break;
			case "hitparticles_mode":
				CerberusConfig.HitParticles.ParticleMode = value.GetInt32();
				break;
			case "notif_enabled":
				CerberusConfig.NotificationSettings.Enabled = value.GetBoolean();
				break;
			case "notif_dangerous_atmos":
				CerberusConfig.NotificationSettings.DangerousAtmosNotification = value.GetBoolean();
				break;
			case "hud_connection_show_stats":
				CerberusConfig.HudOverlay.ConnectionShowStats = value.GetBoolean();
				break;
			case "e_font_other":
			{
				string fontName2 = value.GetString();
				CerberusConfig.Esp.OtherFontPath = GetFontPath(fontName2);
				CerberusConfig.Esp.OtherFontIndex = GetFontIndex(fontName2);
				break;
			}
			case "e_size_other":
				CerberusConfig.Esp.OtherFontSize = value.GetInt32();
				break;
			case "packet_spammer_use_random_data":
				CerberusConfig.PacketSpammer.UseRandomData = value.GetBoolean();
				break;
			case "hud_shuttle_show_status":
				CerberusConfig.HudOverlay.ShuttleShowStatus = value.GetBoolean();
				break;
			case "hud_arraylist_rainbow":
				CerberusConfig.HudOverlay.ArrayListRainbow = value.GetBoolean();
				break;
			case "y_access_i":
				CerberusConfig.Hud.ShowAccessReaderSettings = value.GetBoolean();
				break;
			case "looter_list":
			{
				List<ItemDto> list = JsonSerializer.Deserialize<List<ItemDto>>(value.GetRawText(), new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});
				CerberusConfig.AutoLooter.LootEntries.Clear();
				if (list == null)
				{
					break;
				}
				{
					foreach (ItemDto item2 in list)
					{
						CerberusConfig.AutoLooter.LootEntries.Add(new ColoredString
						{
							string_0 = item2.Name,
							vector4_0 = ParseColor(item2.Color)
						});
					}
					break;
				}
			}
			case "filter_ignore_dead":
				CerberusConfig.TargetFilters.IgnoreDead = value.GetBoolean();
				break;
			case "trap_esp_enabled":
				CerberusConfig.TrapEsp.Enabled = value.GetBoolean();
				break;
			case "hud_connection_history_size":
				CerberusConfig.HudOverlay.ConnectionHistorySize = value.GetInt32();
				break;
			case "throw_ignore_dead":
				CerberusConfig.ThrowAimbot.IgnoreDead = value.GetBoolean();
				break;
			case "hitparticles_size":
				CerberusConfig.HitParticles.ParticleSize = value.GetSingle();
				break;
			case "st_ui_customizable":
				CerberusConfig.Settings.UiCustomizable = value.GetBoolean();
				break;
			case "free_cam_en":
				CerberusConfig.FreeCam.Enabled = value.GetBoolean();
				break;
			case "mov_speed_saver":
				CerberusConfig.Movement.SpeedSaverEnabled = value.GetBoolean();
				break;
			case "health_info_offset_x":
				CerberusConfig.HealthInfo.TextOffset = new Vector2(value.GetSingle(), CerberusConfig.HealthInfo.TextOffset.Y);
				break;
			case "anomaly_scanner_enabled":
				CerberusConfig.AnomalyScanner.Enabled = value.GetBoolean();
				break;
			case "combat_autolaydown":
				CerberusConfig.Combat.AutoLaydownEnabled = value.GetBoolean();
				break;
			case "cloaked_maxdist":
				CerberusConfig.CloakedPlayerDetector.MaxDistance = value.GetSingle();
				break;
			case "hitbox_visualizer_en":
				CerberusConfig.HitboxVisualizer.Enabled = value.GetBoolean();
				break;
			case "throw_target_priority":
				switch (value.GetString())
				{
				case "Mouse":
					CerberusConfig.ThrowAimbot.TargetPriority = 1;
					break;
				case "Distance":
					CerberusConfig.ThrowAimbot.TargetPriority = 0;
					break;
				case "Health":
					CerberusConfig.ThrowAimbot.TargetPriority = 2;
					break;
				}
				break;
			case "mi_speedhack":
				CerberusConfig.Misc.ZeroGSpeedHackEnabled = value.GetBoolean();
				break;
			case "s_item_en":
				CerberusConfig.Misc.ItemSearcherEnabled = value.GetBoolean();
				break;
			case "notif_feature_autodisable":
				CerberusConfig.NotificationSettings.FeatureAutoDisableNotification = value.GetBoolean();
				break;
			case "mh_enabled":
				CerberusConfig.MeleeHelper.Enabled = value.GetBoolean();
				break;
			case "killsound_vol":
				if (value.ValueKind == JsonValueKind.Number)
				{
					CerberusConfig.KillSound.Volume = value.GetSingle();
				}
				break;
			case "smart_target_enabled":
				CerberusConfig.SmartTargetSelection.Enabled = value.GetBoolean();
				break;
			case "auto_slip_enabled":
				CerberusConfig.AutoSlip.Enabled = value.GetBoolean();
				break;
			case "e_c_slip":
				CerberusConfig.Esp.NoSlipColor = ParseColor(value.GetString());
				break;
			case "auto_strip_cooldown":
				CerberusConfig.AutoStrip.Cooldown = value.GetSingle();
				break;
			case "ambientlight_color":
				CerberusConfig.AmbientLight.CustomColor = ParseColor(value.GetString());
				break;
			case "access_checker_range":
				CerberusConfig.AccessChecker.Range = value.GetSingle();
				break;
			case "esp_target_spirits_mode":
				CerberusConfig.TargetEsp.SpiritsMode = value.GetInt32();
				break;
			case "m_circle":
				CerberusConfig.MeleeAimBot.ShowCircle = value.GetBoolean();
				break;
			case "auto_strip_auto_mode":
				CerberusConfig.AutoStrip.AutoMode = value.GetBoolean();
				break;
			case "hud_radar":
				CerberusConfig.HudOverlay.ShowRadar = value.GetBoolean();
				break;
			case "notif_low_stamina":
				CerberusConfig.NotificationSettings.LowStaminaNotification = value.GetBoolean();
				break;
			case "esp_target_spirits_speed":
				CerberusConfig.TargetEsp.SpiritsSpeed = value.GetSingle();
				break;
			case "e_c_cont":
				CerberusConfig.Esp.ContrabandColor = ParseColor(value.GetString());
				break;
			case "esp_target_spirits_rad_x":
				CerberusConfig.TargetEsp.SpiritsOrbitRadiusX = value.GetSingle();
				break;
			case "p_color":
				CerberusConfig.ProjectileEsp.Color = ParseColor(value.GetString());
				break;
			case "abilityspeed_mode":
				CerberusConfig.AbilitySpeed.Mode = value.GetInt32();
				break;
			case "hitparticles_count":
				CerberusConfig.HitParticles.ParticleCount = value.GetInt32();
				break;
			case "backtrack_visuals_mode":
				switch (value.GetString())
				{
				case "Pulse":
					CerberusConfig.Backtrack.VisualsMode = 1;
					break;
				case "Wireframe":
					CerberusConfig.Backtrack.VisualsMode = 5;
					break;
				case "Flat":
					CerberusConfig.Backtrack.VisualsMode = 0;
					break;
				case "Galaxy":
					CerberusConfig.Backtrack.VisualsMode = 2;
					break;
				case "Metallic":
					CerberusConfig.Backtrack.VisualsMode = 3;
					break;
				case "Glow":
					CerberusConfig.Backtrack.VisualsMode = 6;
					break;
				case "Rainbow":
					CerberusConfig.Backtrack.VisualsMode = 4;
					break;
				}
				break;
			case "access_checker_use_textures":
				CerberusConfig.AccessChecker.UseTextures = value.GetBoolean();
				break;
			case "medipen_delay":
				CerberusConfig.AutoMedipen.ActionDelay = value.GetInt32();
				break;
			case "e_font_main":
			{
				string fontName = value.GetString();
				CerberusConfig.Esp.MainFontPath = GetFontPath(fontName);
				CerberusConfig.Esp.MainFontIndex = GetFontIndex(fontName);
				break;
			}
			case "e_c_antag":
				CerberusConfig.Esp.AntagColor = ParseColor(value.GetString());
				break;
			case "anomaly_scanner_font_path":
				CerberusConfig.AnomalyScanner.FontPath = value.GetString();
				break;
			case "y_health_bar_offset_x":
				CerberusConfig.Hud.HealthBarOffsetX = value.GetSingle();
				break;
			case "looter_en":
				CerberusConfig.AutoLooter.Enabled = value.GetBoolean();
				break;
			case "y_fullbright":
				CerberusConfig.Eye.FullBrightEnabled = value.GetBoolean();
				break;
			case "surgery_exploit_group1":
				CerberusConfig.SurgeryExploit.Group1DepthEnabled = value.GetBoolean();
				break;
			case "e_c_combat":
				CerberusConfig.Esp.CombatModeColor = ParseColor(value.GetString());
				break;
			case "y_hunger_i":
				CerberusConfig.Hud.ShowHungerIcons = value.GetBoolean();
				break;
			case "y_health":
				CerberusConfig.Hud.ShowHealth = value.GetBoolean();
				break;
			case "mi_autofuckrules":
				CerberusConfig.Misc.AutoFuckRulesEnabled = value.GetBoolean();
				break;
			case "implant_en":
				CerberusConfig.AutoImplant.Enabled = value.GetBoolean();
				break;
			case "chams_color":
				CerberusConfig.Chams.Color = ParseColor(value.GetString());
				break;
			case "gren_traj":
				CerberusConfig.GrenadeHelper.ShowTrajectory = value.GetBoolean();
				break;
			case "esp_target_tint":
				CerberusConfig.TargetEsp.EnableColorTint = value.GetBoolean();
				break;
			case "anti_aim_circle_radius":
				CerberusConfig.Movement.AntiAimCircleRadius = value.GetSingle();
				break;
			case "auto_hypo_key":
				CerberusConfig.AutoHypo.ForceKey = ParseImGuiKey(value.GetString());
				break;
			case "mi_traj":
				CerberusConfig.Misc.ShowTrajectory = value.GetBoolean();
				break;
			case "e_enabled":
				CerberusConfig.Esp.Enabled = value.GetBoolean();
				break;
			case "auto_hack_only_locked":
				CerberusConfig.AutoHackDoors.OnlyLockedDoors = value.GetBoolean();
				break;
			case "cloaked_ninja_warning":
				CerberusConfig.CloakedPlayerDetector.ShowWarningForNinja = value.GetBoolean();
				break;
			case "turret_esp_friendly_color":
				CerberusConfig.TurretEsp.FriendlyColor = ParseColor(value.GetString());
				break;
			case "mov_speed_saver_duration":
				CerberusConfig.Movement.SpeedSaverStrafeDurationMs = value.GetInt32();
				break;
			case "filter_max_health":
				CerberusConfig.TargetFilters.MaxHealthPercent = value.GetSingle();
				break;
			case "e_c_name":
				CerberusConfig.Esp.NameColor = ParseColor(value.GetString());
				break;
			case "mi_speed":
				CerberusConfig.Misc.AutoRotateSpeed = value.GetSingle();
				break;
			case "cloaked_detector_ninja_color":
				CerberusConfig.CloakedPlayerDetector.NinjaColor = ParseColor(value.GetString());
				break;
			case "mi_soap":
				CerberusConfig.Misc.AntiSoapEnabled = value.GetBoolean();
				break;
			case "hud_keybinds":
				CerberusConfig.HudOverlay.ShowKeybinds = value.GetBoolean();
				break;
			case "mc_jump_circles":
				CerberusConfig.MinecraftVisuals.JumpCirclesEnabled = value.GetBoolean();
				break;
			case "e_combat":
				CerberusConfig.Esp.ShowCombatMode = value.GetBoolean();
				break;
			case "y_health_bar_width":
				CerberusConfig.Hud.HealthBarWidth = value.GetSingle();
				break;
			case "hud_compass":
				CerberusConfig.HudOverlay.ShowCompass = value.GetBoolean();
				break;
			case "tracers_color":
				CerberusConfig.Tracers.ArrowColor = ParseColor(value.GetString());
				break;
			case "tracers_enabled":
				CerberusConfig.Tracers.Enabled = value.GetBoolean();
				break;
			case "y_stam":
				CerberusConfig.Hud.ShowStamina = value.GetBoolean();
				break;
			case "auto_hypo_hp":
				CerberusConfig.AutoHypo.HpThreshold = value.GetSingle();
				break;
			case "abilityspeed_en":
				CerberusConfig.AbilitySpeed.Enabled = value.GetBoolean();
				break;
			case "auto_slip_pred":
				CerberusConfig.AutoSlip.UsePrediction = value.GetBoolean();
				break;
			case "notif_antag_spawn":
				CerberusConfig.NotificationSettings.AntagSpawnNotification = value.GetBoolean();
				break;
			case "turret_esp_maxdist":
				CerberusConfig.TurretEsp.MaxDistance = value.GetSingle();
				break;
			case "glow_enabled":
				CerberusConfig.PlayerGlow.Enabled = value.GetBoolean();
				break;
			case "chams_self":
				CerberusConfig.Chams.ShowOnLocalPlayer = value.GetBoolean();
				break;
			case "hud_velocity_meter":
				CerberusConfig.HudOverlay.ShowVelocityMeter = value.GetBoolean();
				break;
			case "y_zoom":
				CerberusConfig.Eye.Zoom = value.GetSingle();
				break;
			case "insulation_checker_en":
				CerberusConfig.InsulationChecker.Enabled = value.GetBoolean();
				break;
			case "st_dmg_friend":
				CerberusConfig.Settings.NoDmgFriendPatch = value.GetBoolean();
				break;
			case "auto_slip_lead":
				CerberusConfig.AutoSlip.LeadDistance = value.GetSingle();
				break;
			case "notif_friend_join":
				CerberusConfig.NotificationSettings.FriendJoinNotification = value.GetBoolean();
				break;
			case "m_color":
				CerberusConfig.MeleeAimBot.Color = ParseColor(value.GetString());
				break;
			case "e_c_prio":
				CerberusConfig.Esp.PriorityColor = ParseColor(value.GetString());
				break;
			case "mov_pxsurf":
				CerberusConfig.Movement.PixelSurfEnabled = value.GetBoolean();
				break;
			case "g_autopred":
				CerberusConfig.GunAimBot.AutoPredict = value.GetBoolean();
				break;
			case "nuke_brute_input_delay":
				CerberusConfig.NukeBruteforce.InputDelay = value.GetInt32();
				break;
			case "g_multi_target_count":
				CerberusConfig.GunAimBot.MultiTargetCount = value.GetInt32();
				break;
			case "mi_antiaim":
				CerberusConfig.Misc.AntiAimEnabled = value.GetBoolean();
				break;
			case "esp_target_tint_col":
				CerberusConfig.TargetEsp.PngTintColor = ParseColor(value.GetString());
				break;
			case "mc_jump_color":
				CerberusConfig.MinecraftVisuals.JumpCircleColor = ParseColor(value.GetString());
				break;
			case "hud_watermark":
				CerberusConfig.HudOverlay.ShowWatermark = value.GetBoolean();
				break;
			case "filter_min_health":
				CerberusConfig.TargetFilters.MinHealthPercent = value.GetSingle();
				break;
			case "hud_radar_range":
				CerberusConfig.HudOverlay.RadarRange = value.GetSingle();
				break;
			case "mc_fade_in_speed":
				CerberusConfig.MinecraftVisuals.JumpCircleFadeInSpeed = value.GetSingle();
				break;
			case "ambient_brightness":
				CerberusConfig.LightSmooth.Brightness = value.GetSingle();
				break;
			case "packet_spammer_log_sending":
				CerberusConfig.PacketSpammer.LogSending = value.GetBoolean();
				break;
			case "m_rotate":
				CerberusConfig.MeleeHelper.RotateToTarget = value.GetBoolean();
				break;
			case "access_checker_icon_size":
				CerberusConfig.AccessChecker.IconSize = value.GetSingle();
				break;
			case "esp_target_spring":
				CerberusConfig.TargetEsp.EnableSpringEffect = value.GetBoolean();
				break;
			case "packet_spammer_enabled":
				CerberusConfig.PacketSpammer.Enabled = value.GetBoolean();
				break;
			case "throw_range":
				CerberusConfig.ThrowAimbot.Range = value.GetSingle();
				break;
			case "mc_block_esp":
				CerberusConfig.MinecraftVisuals.BlockOutlineEnabled = value.GetBoolean();
				break;
			case "packet_spammer_packets_per_burst":
				CerberusConfig.PacketSpammer.PacketsPerBurst = value.GetInt32();
				break;
			case "y_stamina_bar_height":
				CerberusConfig.Hud.StaminaBarHeight = value.GetSingle();
				break;
			case "health_info_en":
				CerberusConfig.HealthInfo.Enabled = value.GetBoolean();
				break;
			case "hitbox_thickness":
				CerberusConfig.HitboxVisualizer.LineThickness = value.GetSingle();
				break;
			case "turret_esp_hostile_color":
				CerberusConfig.TurretEsp.HostileColor = ParseColor(value.GetString());
				break;
			case "hitbox_players":
				CerberusConfig.HitboxVisualizer.ShowPlayers = value.GetBoolean();
				break;
			case "worldparticles_blur":
				CerberusConfig.WorldParticles.UseBlur = value.GetBoolean();
				break;
			case "perf_lighting":
				CerberusConfig.Performance.SimplifyLighting = value.GetBoolean();
				break;
			case "y_st_col":
				CerberusConfig.StorageViewer.Color = ParseColor(value.GetString());
				break;
			case "throw_speed":
				CerberusConfig.ThrowAimbot.ThrowSpeed = value.GetSingle();
				break;
			case "ambientlight_enabled":
				CerberusConfig.AmbientLight.Enabled = value.GetBoolean();
				break;
			case "glow_color":
				CerberusConfig.PlayerGlow.GlowColor = ParseColor(value.GetString());
				break;
			case "worldparticles_color":
				CerberusConfig.WorldParticles.ParticleColor = ParseColor(value.GetString());
				break;
			case "ambientlight_intensity":
				CerberusConfig.AmbientLight.Intensity = value.GetSingle();
				break;
			case "mov_surf_rad":
				CerberusConfig.Movement.ShieldSurfRadius = value.GetSingle();
				break;
			case "packet_spammer_thread_count":
				CerberusConfig.PacketSpammer.ThreadCount = value.GetInt32();
				break;
			case "ambient_enabled":
				CerberusConfig.LightSmooth.Enabled = value.GetBoolean();
				break;
			case "trails_spawnrate":
				CerberusConfig.Trails.ParticleSpawnRate = value.GetSingle();
				break;
			case "auto_painter.enabled":
			{
				CerberusConfig.AutoPainter.Enabled = value.GetBoolean();
				CrayonImageDrawer gClass2 = default(CrayonImageDrawer);
				if (IoCManager.Resolve<IEntitySystemManager>().TryGetEntitySystem<CrayonImageDrawer>(ref gClass2))
				{
					gClass2.Enabled = value.GetBoolean();
				}
				break;
			}
			case "worldparticles_size":
				CerberusConfig.WorldParticles.Size = value.GetSingle();
				break;
			case "chams_enabled":
				CerberusConfig.Chams.Enabled = value.GetBoolean();
				break;
			case "hitsound_en":
				CerberusConfig.HitSound.Enabled = value.GetBoolean();
				break;
			case "e_slip":
				CerberusConfig.Esp.ShowNoSlip = value.GetBoolean();
				break;
			case "light_boost_radius":
				CerberusConfig.LightEnhancement.RadiusMultiplier = value.GetSingle();
				break;
			case "hud_target_info":
				CerberusConfig.HudOverlay.ShowTargetInfo = value.GetBoolean();
				break;
			case "throw_pred":
				CerberusConfig.ThrowAimbot.PredictionEnabled = value.GetBoolean();
				break;
			case "access_checker_cross_color":
				CerberusConfig.AccessChecker.CrossColor = ParseColor(value.GetString());
				break;
			case "e_implants":
				CerberusConfig.Esp.ShowImplants = value.GetBoolean();
				break;
			case "y_recoil":
				CerberusConfig.Settings.NoCameraKickPatch = value.GetBoolean();
				break;
			case "hud_coords":
				CerberusConfig.HudOverlay.ShowCoords = value.GetBoolean();
				break;
			case "auto_painter.target_size":
				if (value.ValueKind == JsonValueKind.Number)
				{
					int targetSize = (CerberusConfig.AutoPainter.TargetSize = value.GetInt32());
					CrayonImageDrawer gClass = default(CrayonImageDrawer);
					if (IoCManager.Resolve<IEntitySystemManager>().TryGetEntitySystem<CrayonImageDrawer>(ref gClass))
					{
						gClass.TargetSize = targetSize;
					}
				}
				break;
			case "anti_aim_step_length":
				CerberusConfig.Movement.AntiAimStepLength = value.GetSingle();
				break;
			}
		}
		catch (Exception)
		{
		}
	}

	private async Task SendPlayerList(WebSocket ws)
	{
		try
		{
			if (gclass7_0 == null)
			{
				if (itaskManager_0 == null)
				{
					return;
				}
				bool HvY8nfqNNI = false;
				itaskManager_0.RunOnMainThread((Action)delegate
				{
					try
					{
						IEntitySystemManager val = IoCManager.Resolve<IEntitySystemManager>();
						SessionTrackerSystem gClass = default(SessionTrackerSystem);
						if (val != null && val.TryGetEntitySystem<SessionTrackerSystem>(ref gClass))
						{
							gclass7_0 = gClass;
							HvY8nfqNNI = true;
						}
					}
					catch (Exception)
					{
					}
				});
				await Task.Delay(100);
				if (!HvY8nfqNNI || gclass7_0 == null)
				{
					string s = JsonSerializer.Serialize(new
					{
						type = "player_list",
						data = new List<object>()
					});
					byte[] bytes = Encoding.UTF8.GetBytes(s);
					if (ws.State == WebSocketState.Open)
					{
						await ws.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
					}
					return;
				}
			}
			if (gclass7_0 == null)
			{
				return;
			}
			List<object> list = new List<object>();
			IEnumerable<PlayerInfo> enumerable = null;
			try
			{
				if (gclass7_0.AllPlayerSessions != null)
				{
					enumerable = gclass7_0.AllPlayerSessions.Values.ToArray();
				}
			}
			catch (Exception)
			{
			}
			if (enumerable != null)
			{
				foreach (PlayerInfo item in enumerable)
				{
					if (item == null)
					{
						continue;
					}
					ICommonSession session = item.Session;
					object obj;
					if (session != null)
					{
						obj = session.Name;
						if (obj != null)
						{
							goto IL_0105;
						}
					}
					obj = "Unknown";
					goto IL_0105;
					IL_0133:
					object charName;
					object obj2;
					list.Add(new
					{
						name = (string)obj,
						charName = (string)charName,
						entity = (string)obj2,
						status = (item.Status ?? "Offline"),
						job = (item.Job ?? "Unknown"),
						health = item.Health,
						maxHealth = item.MaxHealth,
						isAlive = item.IsAlive,
						isAntag = item.IsAntag,
						distance = Math.Round(item.Distance, 1),
						position = new
						{
							x = item.LastKnownPosition.X,
							y = item.LastKnownPosition.Y
						}
					});
					continue;
					IL_0105:
					charName = item.EntityName ?? "Unknown";
					EntityUid? attachedEntity = item.AttachedEntity;
					if (attachedEntity.HasValue)
					{
						obj2 = ((object)attachedEntity.GetValueOrDefault()/*cast due to constrained. prefix*/).ToString();
						if (obj2 != null)
						{
							goto IL_0133;
						}
					}
					obj2 = "None";
					goto IL_0133;
				}
			}
			string s2 = JsonSerializer.Serialize(new
			{
				type = "player_list",
				data = list
			});
			byte[] bytes2 = Encoding.UTF8.GetBytes(s2);
			if (ws.State == WebSocketState.Open)
			{
				await ws.SendAsync(new ArraySegment<byte>(bytes2), WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
			}
		}
		catch (Exception)
		{
		}
	}

	private async Task SendConfig(WebSocket ws)
	{
		try
		{
			CerberusConfigData data = ConfigManager.GatherData();
			JsonSerializerOptions options = new JsonSerializerOptions
			{
				Converters = { (JsonConverter)new JsonStringEnumConverter() },
				PropertyNamingPolicy = null
			};
			string s = JsonSerializer.Serialize(new
			{
				type = "config_sync",
				data = data
			}, options);
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			await ws.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
		}
		catch
		{
		}
	}

	private async Task SendNukeBruteforceStatus(WebSocket ws)
	{
		try
		{
			List<string> attemptHistory = NukeBruteforceEngine.GetAttemptHistory();
			string s = JsonSerializer.Serialize(new
			{
				type = "nuke_brute_status",
				isRunning = NukeBruteforceEngine.bool_0,
				history = attemptHistory
			});
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			await ws.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
		}
		catch
		{
		}
	}

	private unsafe async Task SendUplinkBruteforceStatus(WebSocket ws)
	{
		try
		{
			List<string> attemptHistory = UplinkBruteforceEngine.GetAttemptHistory();
			Note[] note_ = UplinkBruteforceEngine.note_1;
			string s = JsonSerializer.Serialize(new
			{
				type = "uplink_brute_status",
				isRunning = UplinkBruteforceEngine.bool_0,
				foundCode = UplinkBruteforceEngine.bool_1,
				foundRingtone = ((note_ == null) ? null : string.Join("-", note_.Select((Note n) => ((object)(*(Note*)(&n))/*cast due to constrained. prefix*/).ToString()))),
				current = UplinkBruteforceEngine.CurrentIndex,
				total = UplinkBruteforceEngine.Total,
				history = attemptHistory
			});
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			await ws.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
		}
		catch
		{
		}
	}

	private async Task SendConfigList(WebSocket ws)
	{
		try
		{
			List<string> configList = ConfigManager.GetConfigList();
			string s = JsonSerializer.Serialize(new
			{
				type = "config_list",
				data = configList
			});
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			if (ws.State == WebSocketState.Open)
			{
				await ws.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
			}
		}
		catch (Exception)
		{
		}
	}

	private static List<Macro> LoadMacrosFromDisk()
	{
		List<Macro> list = new List<Macro>();
		string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Kaban.cc", "combo");
		if (!Directory.Exists(path))
		{
			return list;
		}
		string[] files = Directory.GetFiles(path, "*.json");
		foreach (string path2 in files)
		{
			try
			{
				Macro gClass = JsonSerializer.Deserialize<Macro>(File.ReadAllText(path2));
				if (gClass != null)
				{
					list.Add(gClass);
				}
			}
			catch
			{
			}
		}
		return list;
	}

	private async Task SendAutoBuyPresets(WebSocket ws)
	{
		try
		{
			AntagAutoBuyEngine.LoadPresets();
			var data = AntagAutoBuyEngine.Presets.Select((AutoBuyPreset p) => new
			{
				name = p.Name,
				items = p.Items
			}).ToList();
			string s = JsonSerializer.Serialize(new
			{
				type = "autobuy_presets",
				data = data
			});
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			if (ws.State == WebSocketState.Open)
			{
				await ws.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
			}
		}
		catch
		{
		}
	}

	private async Task BroadcastListings()
	{
		try
		{
			var data = AntagAutoBuyEngine.CachedListings.Select((AntagStoreListing l) => new
			{
				id = l.Id,
				name = l.Name,
				cost = l.Cost,
				category = l.Category
			}).ToList();
			string s = JsonSerializer.Serialize(new
			{
				type = "autobuy_listings",
				data = data
			});
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			ArraySegment<byte> segment = new ArraySegment<byte>(bytes);
			foreach (WebSocket value in concurrentDictionary_0.Values)
			{
				if (value.State == WebSocketState.Open)
				{
					await value.SendAsync(segment, WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
				}
			}
		}
		catch
		{
		}
	}

	private async Task SendComboList(WebSocket ws)
	{
		try
		{
			MeleeMacroPlayer gClass = null;
			try
			{
				gClass = IoCManager.Resolve<IEntitySystemManager>().GetEntitySystem<MeleeMacroPlayer>();
			}
			catch
			{
			}
			List<Macro> source = ((gClass == null) ? LoadMacrosFromDisk() : gClass.GetMacros());
			var data = source.Select((Macro m) => new
			{
				name = m.Name,
				actions = m.Actions.Select((MacroAction a) => new
				{
					type = a.TypeId,
					delay = (int)(a.Delay * 1000f),
					repeat = a.Repeat
				}).ToList(),
				enabled = m.Enabled,
				hotkey = (CerberusConfig.AutoCombo.MacroKeybinds.ContainsKey(m.Name) ? ((object)CerberusConfig.AutoCombo.MacroKeybinds[m.Name]/*cast due to constrained. prefix*/).ToString() : "NONE")
			}).ToList();
			string s = JsonSerializer.Serialize(new
			{
				type = "combo_list",
				data = data
			});
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			if (ws.State == WebSocketState.Open)
			{
				await ws.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
			}
		}
		catch (Exception ex)
		{
			Logger.Error("SendComboList Error: " + ex.Message);
		}
	}

	public async Task BroadcastConfig()
	{
		try
		{
			CerberusConfigData data = ConfigManager.GatherData();
			JsonSerializerOptions options = new JsonSerializerOptions
			{
				Converters = { (JsonConverter)new JsonStringEnumConverter() },
				PropertyNamingPolicy = null
			};
			string s = JsonSerializer.Serialize(new
			{
				type = "config_sync",
				data = data
			}, options);
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			foreach (WebSocket value in concurrentDictionary_0.Values)
			{
				if (value.State == WebSocketState.Open)
				{
					await value.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private async Task BroadcastReload()
	{
		try
		{
			string s = JsonSerializer.Serialize(new
			{
				type = "reload_page"
			});
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			foreach (WebSocket value in concurrentDictionary_0.Values)
			{
				if (value.State == WebSocketState.Open)
				{
					await value.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private async Task SendChemRecipes(WebSocket ws)
	{
		try
		{
			AutoChemRecipeManager.EnsureInitialized();
			var data = (from r in AutoChemRecipeManager.GetAllRecipes()
				select new
				{
					name = r.string_0,
					recipe = string.Join(", ", r.dictionary_0.Keys)
				}).ToList();
			string s = JsonSerializer.Serialize(new
			{
				type = "chem_recipes",
				data = data
			});
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			if (ws.State == WebSocketState.Open)
			{
				await ws.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
			}
		}
		catch (Exception)
		{
		}
	}

	private async Task BroadcastChemRecipes()
	{
		try
		{
			AutoChemRecipeManager.EnsureInitialized();
			var data = (from r in AutoChemRecipeManager.GetAllRecipes()
				select new
				{
					name = r.string_0,
					recipe = string.Join(", ", r.dictionary_0.Keys)
				}).ToList();
			string s = JsonSerializer.Serialize(new
			{
				type = "chem_recipes",
				data = data
			});
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			int sentCount = 0;
			foreach (WebSocket value in concurrentDictionary_0.Values)
			{
				if (value.State == WebSocketState.Open)
				{
					await value.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
					sentCount++;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private Vector4 ParseColor(string hex)
	{
		if (!string.IsNullOrEmpty(hex))
		{
			hex = hex.TrimStart('#');
			if (hex.Length != 6)
			{
				return Vector4.One;
			}
			float x = (float)Convert.ToInt32(hex.Substring(0, 2), 16) / 255f;
			float y = (float)Convert.ToInt32(hex.Substring(2, 2), 16) / 255f;
			float z = (float)Convert.ToInt32(hex.Substring(4, 2), 16) / 255f;
			return new Vector4(x, y, z, 1f);
		}
		return Vector4.One;
	}

	private ImGuiKey ParseImGuiKey(string keyName)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(keyName) || keyName == "None")
		{
			return (ImGuiKey)0;
		}
		if (!Enum.TryParse<ImGuiKey>(keyName, true, out ImGuiKey result))
		{
			return (ImGuiKey)0;
		}
		return result;
	}

	private string GetFontPath(string fontName)
	{
		return fontName switch
		{
			"Boxfont Round" => "/Fonts/Boxfont-round/Boxfont Round.ttf", 
			"NotoSans Italic" => "/Fonts/NotoSans/NotoSans-Italic.ttf", 
			"NotoSans Regular" => "/Fonts/NotoSans/NotoSans-Regular.ttf", 
			"NotoSans Bold" => "/Fonts/NotoSans/NotoSans-Bold.ttf", 
			_ => "/Fonts/Boxfont-round/Boxfont Round.ttf", 
		};
	}

	private int GetFontIndex(string fontName)
	{
		return fontName switch
		{
			"NotoSans Italic" => 3, 
			"NotoSans Bold" => 2, 
			"Boxfont Round" => 0, 
			"NotoSans Regular" => 1, 
			_ => 0, 
		};
	}

	private async Task HandleLuaButtonClick(string id, JsonElement root, WebSocket ws)
	{
		try
		{
			switch (id)
			{
			case "lua_open_folder":
				if (itaskManager_0 != null)
				{
					itaskManager_0.RunOnMainThread((Action)delegate
					{
						LuaScriptManager.Instance.OpenLuaFolder();
					});
				}
				break;
			case "lua_execute":
			{
				if (!root.TryGetProperty("value", out var value2))
				{
					break;
				}
				string SSx82nbIK2 = value2.GetString();
				if (itaskManager_0 != null)
				{
					itaskManager_0.RunOnMainThread((Action)delegate
					{
						LuaScriptManager.Instance.ExecuteScript(SSx82nbIK2);
					});
				}
				await Task.Delay(100);
				await BroadcastLuaScripts();
				break;
			}
			case "lua_refresh":
				if (itaskManager_0 != null)
				{
					itaskManager_0.RunOnMainThread((Action)delegate
					{
						LuaScriptManager.Instance.LoadScripts();
					});
				}
				await Task.Delay(100);
				await BroadcastLuaScripts();
				break;
			case "lua_stop":
			{
				if (!root.TryGetProperty("value", out var value))
				{
					break;
				}
				string AcY8HBtEKf = value.GetString();
				if (itaskManager_0 != null)
				{
					itaskManager_0.RunOnMainThread((Action)delegate
					{
						LuaScriptManager.Instance.StopScript(AcY8HBtEKf);
					});
				}
				await Task.Delay(100);
				await BroadcastLuaScripts();
				break;
			}
			}
		}
		catch (Exception)
		{
		}
	}

	private async Task SendLuaScripts(WebSocket ws)
	{
		try
		{
			var data = LuaScriptManager.Instance.LoadedScripts.Values.Select(delegate(LuaScriptRunner gClass)
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				foreach (KeyValuePair<string, object> uIElement in gClass.UIElements)
				{
					object value = uIElement.Value;
					_ = value.GetType().Name;
					if (!(value is LuaUiCheckbox gClass2))
					{
						if (!(value is LuaUiSlider gClass3))
						{
							if (value is LuaUiButton gClass4)
							{
								dictionary[uIElement.Key] = new
								{
									type = "LuaButton",
									id = gClass4.Id,
									label = gClass4.Label
								};
							}
							else if (value is LuaUiComboBox gClass5)
							{
								dictionary[uIElement.Key] = new
								{
									type = "LuaComboBox",
									id = gClass5.Id,
									label = gClass5.Label,
									items = gClass5.Items,
									selectedIndex = gClass5.SelectedIndex
								};
							}
							else if (!(value is LuaUiColorPicker gClass6))
							{
								if (!(value is LuaUiTextInput gClass7))
								{
									if (value is LuaUiLabel gClass8)
									{
										dictionary[uIElement.Key] = new
										{
											type = "LuaLabel",
											id = gClass8.Id,
											text = gClass8.Text
										};
									}
								}
								else
								{
									dictionary[uIElement.Key] = new
									{
										type = "LuaTextInput",
										id = gClass7.Id,
										label = gClass7.Label,
										value = gClass7.Value
									};
								}
							}
							else
							{
								dictionary[uIElement.Key] = new
								{
									type = "LuaColorPicker",
									id = gClass6.Id,
									label = gClass6.Label,
									r = gClass6.R,
									g = gClass6.G,
									b = gClass6.B,
									a = gClass6.A
								};
							}
						}
						else
						{
							dictionary[uIElement.Key] = new
							{
								type = "LuaSlider",
								id = gClass3.Id,
								label = gClass3.Label,
								min = gClass3.Min,
								max = gClass3.Max,
								value = gClass3.Value
							};
						}
					}
					else
					{
						dictionary[uIElement.Key] = new
						{
							type = "LuaCheckbox",
							id = gClass2.Id,
							label = gClass2.Label,
							value = gClass2.Value
						};
					}
				}
				return new
				{
					name = gClass.Name,
					filePath = gClass.FilePath,
					isRunning = gClass.IsRunning,
					isZipMod = gClass.IsZipMod,
					modConfig = ((gClass.ModConfig != null) ? new
					{
						name = gClass.ModConfig.Name,
						description = gClass.ModConfig.Description,
						author = gClass.ModConfig.Author,
						version = gClass.ModConfig.Version
					} : null),
					uiElements = dictionary
				};
			}).ToList();
			string s = JsonSerializer.Serialize(new
			{
				type = "lua_scripts",
				data = data
			});
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			await ws.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
		}
		catch (Exception)
		{
		}
	}

	private async Task BroadcastLuaScripts()
	{
		foreach (WebSocket value in concurrentDictionary_0.Values)
		{
			if (value.State == WebSocketState.Open)
			{
				await SendLuaScripts(value);
			}
		}
	}

	private async Task HandleLuaMessage(string type, JsonElement root, WebSocket ws)
	{
		try
		{
			switch (type)
			{
			case "lua_execute":
			{
				if (!root.TryGetProperty("scriptName", out var value5))
				{
					break;
				}
				string Fra8ZRKLyp = value5.GetString();
				if (itaskManager_0 != null)
				{
					itaskManager_0.RunOnMainThread((Action)delegate
					{
						LuaScriptManager.Instance.ExecuteScript(Fra8ZRKLyp);
					});
				}
				await Task.Delay(100);
				await BroadcastLuaScripts();
				break;
			}
			case "lua_refresh":
				if (itaskManager_0 != null)
				{
					itaskManager_0.RunOnMainThread((Action)delegate
					{
						LuaScriptManager.Instance.LoadScripts();
					});
				}
				await Task.Delay(100);
				await BroadcastLuaScripts();
				break;
			case "lua_get_scripts":
				await SendLuaScripts(ws);
				break;
			case "lua_update_element":
			{
				if (!root.TryGetProperty("scriptName", out var value2) || !root.TryGetProperty("elementId", out var value3) || !root.TryGetProperty("value", out var value4))
				{
					break;
				}
				string MSA86xvaT2 = value2.GetString();
				string yyl8gJl7Gs = value3.GetString();
				object D5c8hJ9SYD = null;
				if (value4.ValueKind != JsonValueKind.True && value4.ValueKind != JsonValueKind.False)
				{
					if (value4.ValueKind != JsonValueKind.Number)
					{
						if (value4.ValueKind != JsonValueKind.String)
						{
							if (value4.ValueKind == JsonValueKind.Array)
							{
								float[] array = (from e in value4.EnumerateArray()
									select e.GetSingle()).ToArray();
								D5c8hJ9SYD = array;
							}
						}
						else
						{
							D5c8hJ9SYD = value4.GetString();
						}
					}
					else
					{
						D5c8hJ9SYD = value4.GetDouble();
					}
				}
				else
				{
					D5c8hJ9SYD = value4.GetBoolean();
				}
				if (itaskManager_0 == null || D5c8hJ9SYD == null)
				{
					break;
				}
				itaskManager_0.RunOnMainThread((Action)delegate
				{
					LuaScriptManager.Instance.LoadedScripts.Values.FirstOrDefault((LuaScriptRunner s) => s.Name == MSA86xvaT2)?.SetUIElementValue(yyl8gJl7Gs, D5c8hJ9SYD);
				});
				break;
			}
			case "lua_open_folder":
				if (itaskManager_0 != null)
				{
					itaskManager_0.RunOnMainThread((Action)delegate
					{
						LuaScriptManager.Instance.OpenLuaFolder();
					});
				}
				break;
			case "lua_stop":
			{
				if (!root.TryGetProperty("scriptName", out var value))
				{
					break;
				}
				string pys8txQd2R = value.GetString();
				if (itaskManager_0 != null)
				{
					itaskManager_0.RunOnMainThread((Action)delegate
					{
						LuaScriptManager.Instance.StopScript(pys8txQd2R);
					});
				}
				await Task.Delay(100);
				await BroadcastLuaScripts();
				break;
			}
			}
		}
		catch (Exception)
		{
		}
	}

	private async Task HandleNetLoggerMessage(string type, JsonElement root, WebSocket ws)
	{
		try
		{
			if (type == null)
			{
				return;
			}
			switch (type.Length)
			{
			case 23:
			{
				if (type == "netlogger_replay_packet" && root.TryGetProperty("packetId", out var value5))
				{
					int int2 = value5.GetInt32();
					await ReplayPacket(int2);
				}
				break;
			}
			case 21:
				if (type == "netlogger_get_packets")
				{
					await SendNetLoggerPackets(ws);
				}
				break;
			case 15:
				if (type == "netlogger_clear")
				{
					PacketLogger.Clear();
					await BroadcastNetLoggerPackets();
				}
				break;
			case 22:
			{
				if (type == "netlogger_update_field" && root.TryGetProperty("packetId", out var value2) && root.TryGetProperty("fieldName", out var value3) && root.TryGetProperty("newValue", out var value4))
				{
					int @int = value2.GetInt32();
					string fieldName = value3.GetString();
					string newValue = value4.GetString();
					if (PacketLogger.UpdatePacketField(@int, fieldName, newValue))
					{
						await SendPacketDetails(ws, @int);
					}
				}
				break;
			}
			case 20:
				switch (type[10])
				{
				case 's':
					if (type == "netlogger_set_filter")
					{
						if (root.TryGetProperty("filterByFields", out var value7))
						{
							PacketLogger.FilterByFields = value7.GetBoolean();
						}
						if (root.TryGetProperty("minFields", out var value8))
						{
							PacketLogger.MinFields = value8.GetInt32();
						}
						if (root.TryGetProperty("filterBySize", out var value9))
						{
							PacketLogger.FilterBySize = value9.GetBoolean();
						}
						if (root.TryGetProperty("minSize", out var value10))
						{
							PacketLogger.MinSizeBytes = value10.GetInt32();
						}
						if (root.TryGetProperty("groupSimilar", out var value11))
						{
							PacketLogger.GroupSimilarPackets = value11.GetBoolean();
						}
						if (root.TryGetProperty("groupTimeWindow", out var value12))
						{
							PacketLogger.GroupTimeWindowMs = value12.GetInt32();
						}
					}
					break;
				case 'o':
					if (!(type == "netlogger_open_imgui") || itaskManager_0 == null)
					{
						break;
					}
					itaskManager_0.RunOnMainThread((Action)delegate
					{
						try
						{
							if (FeatureToggleState.NetLoggerOverlay != null)
							{
								FeatureToggleState.NetLoggerOverlay.ToggleWindow();
							}
						}
						catch (Exception)
						{
						}
					});
					break;
				}
				break;
			case 28:
			{
				if (type == "netlogger_get_packet_details" && root.TryGetProperty("packetId", out var value6))
				{
					int int3 = value6.GetInt32();
					await SendPacketDetails(ws, int3);
				}
				break;
			}
			case 16:
			{
				if (type == "netlogger_toggle" && root.TryGetProperty("enabled", out var value))
				{
					PacketLogger.Enabled = value.GetBoolean();
				}
				break;
			}
			}
		}
		catch (Exception)
		{
		}
	}

	private async Task SendNetLoggerPackets(WebSocket ws)
	{
		try
		{
			var data = (from p in (from p in PacketLogger.GetPackets().ToList()
					orderby p.Id descending
					select p).Take(500)
				select new
				{
					id = p.Id,
					timestamp = p.Timestamp.ToString("HH:mm:ss.fff"),
					direction = ((GEnum8)p.Direction/*cast due to constrained. prefix*/).ToString(),
					messageType = p.MessageType,
					msgName = p.MsgName,
					msgGroup = p.MsgGroup,
					size = p.Size,
					channel = p.Channel,
					isGrouped = p.IsGrouped,
					groupCount = p.GroupCount,
					groupedPacketIds = p.GroupedPacketIds
				}).ToList();
			string s = JsonSerializer.Serialize(new
			{
				type = "netlogger_packets",
				data = data
			});
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			await ws.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
		}
		catch (Exception)
		{
		}
	}

	private async Task SendPacketDetails(WebSocket ws, int packetId)
	{
		try
		{
			PacketLogEntryFull packetById = PacketLogger.GetPacketById(packetId);
			if (packetById != null)
			{
				var fields = Enumerable.Select(packetById.Fields, (KeyValuePair<string, PacketField> kvp) => new
				{
					name = kvp.Key,
					type = kvp.Value.Type,
					value = kvp.Value.Value,
					isEditable = kvp.Value.IsEditable
				}).ToList();
				string s = JsonSerializer.Serialize(new
				{
					type = "netlogger_packet_details",
					data = new
					{
						id = packetById.Id,
						timestamp = packetById.Timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff"),
						direction = ((GEnum8)packetById.Direction/*cast due to constrained. prefix*/).ToString(),
						messageType = packetById.MessageType,
						msgName = packetById.MsgName,
						msgGroup = packetById.MsgGroup,
						size = packetById.Size,
						channel = packetById.Channel,
						rawData = packetById.RawData,
						fields = fields,
						isGrouped = packetById.IsGrouped,
						groupCount = packetById.GroupCount,
						groupedPacketIds = packetById.GroupedPacketIds
					}
				});
				byte[] bytes = Encoding.UTF8.GetBytes(s);
				await ws.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
			}
		}
		catch (Exception)
		{
		}
	}

	private async Task ReplayPacket(int packetId)
	{
		try
		{
			NetMessage mUQ85JNoD4 = PacketLogger.GetMessageForReplay(packetId);
			if (mUQ85JNoD4 == null || itaskManager_0 == null)
			{
				return;
			}
			itaskManager_0.RunOnMainThread((Action)delegate
			{
				//IL_0156: Unknown result type (might be due to invalid IL or missing references)
				//IL_015b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0164: Unknown result type (might be due to invalid IL or missing references)
				//IL_0266: Unknown result type (might be due to invalid IL or missing references)
				//IL_026b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0275: Unknown result type (might be due to invalid IL or missing references)
				try
				{
					IClientNetManager val = IoCManager.Resolve<IClientNetManager>();
					IGameTiming val2 = IoCManager.Resolve<IGameTiming>();
					if (val != null && ((INetManager)val).IsConnected)
					{
						try
						{
							Type type = ((object)mUQ85JNoD4).GetType();
							PropertyInfo property = type.GetProperty("Tick");
							if (property != null && property.CanWrite && val2 != null)
							{
								property.SetValue(value: val2.CurTick, obj: mUQ85JNoD4);
							}
							PropertyInfo property2 = type.GetProperty("SourceTick");
							if (property2 != null && property2.CanWrite && val2 != null)
							{
								property2.SetValue(value: val2.CurTick, obj: mUQ85JNoD4);
							}
							PropertyInfo property3 = type.GetProperty("SubTick");
							if (property3 != null && property3.CanWrite)
							{
								property3.SetValue(value: (ushort)(DateTime.Now.Millisecond % 65535), obj: mUQ85JNoD4);
							}
							PropertyInfo property4 = type.GetProperty("Sequence");
							if (property4 != null && property4.CanWrite)
							{
								object value = property4.GetValue(mUQ85JNoD4);
								if (value is uint num)
								{
									property4.SetValue(value: num + (uint)new Random().Next(1, 100), obj: mUQ85JNoD4);
								}
								else if (value is int num2)
								{
									property4.SetValue(value: num2 + new Random().Next(1, 100), obj: mUQ85JNoD4);
								}
							}
							PropertyInfo property5 = type.GetProperty("InputSequence");
							if (property5 != null && property5.CanWrite && property5.GetValue(mUQ85JNoD4) is uint num3)
							{
								property5.SetValue(value: num3 + (uint)new Random().Next(1, 100), obj: mUQ85JNoD4);
							}
							PropertyInfo property6 = type.GetProperty("Timestamp");
							if (property6 != null && property6.CanWrite)
							{
								if (property6.PropertyType == typeof(DateTime))
								{
									property6.SetValue(mUQ85JNoD4, DateTime.Now);
								}
								else if (property6.PropertyType == typeof(long))
								{
									property6.SetValue(mUQ85JNoD4, DateTime.Now.Ticks);
								}
							}
						}
						catch (Exception)
						{
						}
						bool flag = false;
						try
						{
							MethodInfo method = ((object)val).GetType().GetMethod("ClientSendMessage", BindingFlags.Instance | BindingFlags.Public);
							if (method != null)
							{
								method.Invoke(val, new object[1] { mUQ85JNoD4 });
								flag = true;
							}
						}
						catch (Exception)
						{
						}
						if (!flag)
						{
							try
							{
								MethodInfo method2 = ((object)val).GetType().GetMethod("SendMessage", BindingFlags.Instance | BindingFlags.Public);
								if (method2 != null)
								{
									method2.Invoke(val, new object[1] { mUQ85JNoD4 });
									flag = true;
								}
							}
							catch (Exception)
							{
							}
						}
						if (!flag)
						{
							MethodInfo[] methods = ((object)val).GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public);
							foreach (MethodInfo methodInfo in methods)
							{
								if (methodInfo.Name.Contains("Send") || methodInfo.Name.Contains("Message"))
								{
									string.Join(", ", from p in methodInfo.GetParameters()
										select p.ParameterType.Name);
								}
							}
						}
					}
				}
				catch (Exception)
				{
				}
			});
		}
		catch (Exception)
		{
		}
	}

	private async Task BroadcastNetLoggerPackets()
	{
		foreach (WebSocket value in concurrentDictionary_0.Values)
		{
			if (value.State == WebSocketState.Open)
			{
				await SendNetLoggerPackets(value);
			}
		}
	}

	private async Task HandleEventLoggerMessage(string type, JsonElement root, WebSocket ws)
	{
		try
		{
			if (type == null)
			{
				return;
			}
			switch (type.Length)
			{
			case 18:
			{
				if (type == "eventlogger_toggle" && root.TryGetProperty("enabled", out var value7))
				{
					EventLogger.Enabled = value7.GetBoolean();
				}
				break;
			}
			case 22:
				switch (type[12])
				{
				case 'o':
					if (!(type == "eventlogger_open_imgui") || itaskManager_0 == null)
					{
						break;
					}
					itaskManager_0.RunOnMainThread((Action)delegate
					{
						try
						{
							if (FeatureToggleState.EventLoggerOverlay != null)
							{
								FeatureToggleState.EventLoggerOverlay.ToggleWindow();
							}
						}
						catch (Exception)
						{
						}
					});
					break;
				case 's':
				{
					if (!(type == "eventlogger_set_filter"))
					{
						break;
					}
					if (root.TryGetProperty("filterByType", out var value2))
					{
						EventLogger.FilterByType = value2.GetBoolean();
					}
					if (root.TryGetProperty("allowedTypes", out var value3))
					{
						List<string> list = JsonSerializer.Deserialize<List<string>>(value3.GetRawText());
						if (list != null)
						{
							EventLogger.AllowedEventTypes.Clear();
							foreach (string item in list)
							{
								EventLogger.AllowedEventTypes.Add(item);
							}
						}
					}
					if (root.TryGetProperty("groupSimilar", out var value4))
					{
						EventLogger.GroupSimilarEvents = value4.GetBoolean();
					}
					if (root.TryGetProperty("groupTimeWindow", out var value5))
					{
						EventLogger.GroupTimeWindowMs = value5.GetInt32();
					}
					break;
				}
				case 'g':
					if (type == "eventlogger_get_events")
					{
						await SendEventLoggerEvents(ws);
					}
					break;
				}
				break;
			case 17:
				if (type == "eventlogger_clear")
				{
					EventLogger.Clear();
					await BroadcastEventLoggerEvents();
				}
				break;
			case 24:
			{
				if (type == "eventlogger_replay_event" && root.TryGetProperty("eventId", out var value6))
				{
					int int2 = value6.GetInt32();
					ReplayEvent(int2);
				}
				break;
			}
			case 29:
			{
				if (type == "eventlogger_get_event_details" && root.TryGetProperty("eventId", out var value))
				{
					int @int = value.GetInt32();
					await SendEventDetails(ws, @int);
				}
				break;
			}
			}
		}
		catch (Exception)
		{
		}
	}

	private async Task HandlePacketSpammerMessage(string type, JsonElement root, WebSocket ws)
	{
		try
		{
			if (type == null)
			{
				return;
			}
			switch (type.Length)
			{
			case 25:
				if (!(type == "packetspammer_send_single"))
				{
				}
				break;
			case 21:
			case 23:
				break;
			case 22:
				if (type == "packetspammer_get_logs")
				{
					await SendPacketSpammerLogs(ws);
				}
				break;
			case 24:
				switch (type[14])
				{
				case 'o':
					if (!(type == "packetspammer_open_imgui") || itaskManager_0 == null)
					{
						break;
					}
					itaskManager_0.RunOnMainThread((Action)delegate
					{
						try
						{
							if (FeatureToggleState.PacketSpammerOverlay != null)
							{
								FeatureToggleState.PacketSpammerOverlay.ToggleWindow();
							}
						}
						catch (Exception)
						{
						}
					});
					break;
				case 'c':
					if (type == "packetspammer_clear_logs")
					{
						PacketSpammer.ClearLogs();
					}
					break;
				}
				break;
			case 20:
			{
				if (type == "packetspammer_toggle" && root.TryGetProperty("enabled", out var value))
				{
					CerberusConfig.PacketSpammer.Enabled = value.GetBoolean();
				}
				break;
			}
			case 18:
				if (!(type == "packetspammer_stop") || itaskManager_0 == null)
				{
					break;
				}
				itaskManager_0.RunOnMainThread((Action)delegate
				{
					try
					{
						IEntitySystemManager obj = IoCManager.Resolve<IEntitySystemManager>();
						((obj == null) ? null : obj.GetEntitySystem<PacketSpammer>())?.StopPacketSpam();
					}
					catch (Exception)
					{
					}
				});
				break;
			case 19:
				if (!(type == "packetspammer_start") || itaskManager_0 == null)
				{
					break;
				}
				itaskManager_0.RunOnMainThread((Action)delegate
				{
					try
					{
						IEntitySystemManager obj = IoCManager.Resolve<IEntitySystemManager>();
						((obj == null) ? null : obj.GetEntitySystem<PacketSpammer>())?.StartPacketSpam();
					}
					catch (Exception)
					{
					}
				});
				break;
			}
		}
		catch (Exception)
		{
		}
	}

	private async Task HandleEventSpammerMessage(string type, JsonElement root, WebSocket ws)
	{
		try
		{
			if (type == null)
			{
				return;
			}
			switch (type.Length)
			{
			case 20:
			case 22:
				break;
			case 19:
			{
				if (type == "eventspammer_toggle" && root.TryGetProperty("enabled", out var value))
				{
					CerberusConfig.EventSpammer.Enabled = value.GetBoolean();
				}
				break;
			}
			case 17:
				if (!(type == "eventspammer_stop") || itaskManager_0 == null)
				{
					break;
				}
				itaskManager_0.RunOnMainThread((Action)delegate
				{
					try
					{
						IEntitySystemManager obj = IoCManager.Resolve<IEntitySystemManager>();
						((obj == null) ? null : obj.GetEntitySystem<EventSpammer>())?.StopEventSpam();
					}
					catch (Exception)
					{
					}
				});
				break;
			case 24:
			{
				if (!(type == "eventspammer_send_single") || !root.TryGetProperty("type", out var value2))
				{
					break;
				}
				string bV78GdvTWP = value2.GetString();
				if (itaskManager_0 == null)
				{
					break;
				}
				itaskManager_0.RunOnMainThread((Action)delegate
				{
					//IL_005a: Expected O, but got I4
					//IL_0025: Expected I4, but got O
					//IL_016a: Expected O, but got I4
					//IL_01e9: Expected O, but got I4
					//IL_01b1: Expected O, but got I4
					//IL_01ce: Expected O, but got I4
					//IL_0040: Expected O, but got I4
					//IL_0077: Expected O, but got I4
					//IL_032d: Expected O, but got I4
					//IL_03cf: Expected O, but got I4
					//IL_0300: Expected O, but got I4
					//IL_01ff: Expected O, but got I4
					//IL_0269: Expected O, but got I4
					//IL_037e: Expected O, but got I4
					//IL_024c: Expected O, but got I4
					//IL_0118: Expected O, but got I4
					//IL_010d: Expected O, but got I4
					//IL_006f: Expected O, but got I4
					//IL_01f4: Expected O, but got I4
					//IL_00a2: Expected O, but got I4
					//IL_007f: Expected O, but got I4
					try
					{
						IEntitySystemManager obj = IoCManager.Resolve<IEntitySystemManager>();
						EventSpammer gClass = ((obj == null) ? null : obj.GetEntitySystem<EventSpammer>());
						if (gClass == null)
						{
							return;
						}
						string text = bV78GdvTWP;
						if (text != null)
						{
							switch (text.Length)
							{
							case 13:
								goto IL_00e5;
							case 7:
								goto IL_0134;
							case 9:
								goto IL_0146;
							case 10:
								goto IL_01d3;
							case 5:
								goto IL_0204;
							case 11:
								goto IL_0216;
							case 6:
								goto IL_0297;
							case 3:
								goto IL_0353;
							case 4:
								goto IL_03de;
							}
						}
						goto IL_0054;
						IL_0216:
						char c = text[1];
						GEnum7 gEnum;
						if (c == 'n')
						{
							if (text == "interaction")
							{
								gEnum = (GEnum7)0;
								goto IL_001c;
							}
						}
						else if (c == 't' && text == "item_pickup")
						{
							gEnum = (GEnum7)3;
							goto IL_001c;
						}
						goto IL_0054;
						IL_0297:
						c = text[0];
						if (c == 'a')
						{
							if (text == "attack")
							{
								gEnum = (GEnum7)11;
								goto IL_001c;
							}
						}
						else if (c == 'c')
						{
							if (text == "crouch")
							{
								gEnum = (GEnum7)8;
								goto IL_001c;
							}
						}
						else if (c == 's' && text == "sprint")
						{
							gEnum = (GEnum7)7;
							goto IL_001c;
						}
						goto IL_0054;
						IL_0134:
						c = text[0];
						if (c == 'e')
						{
							if (text == "examine")
							{
								gEnum = (GEnum7)10;
								goto IL_001c;
							}
						}
						else if (c == 's')
						{
							if (text == "storage")
							{
								gEnum = (GEnum7)16;
								goto IL_001c;
							}
						}
						else if (c == 'u' && text == "unequip")
						{
							gEnum = (GEnum7)15;
							goto IL_001c;
						}
						goto IL_0054;
						IL_0054:
						gEnum = (GEnum7)0;
						goto IL_001c;
						IL_01d3:
						if (text == "move_input")
						{
							gEnum = (GEnum7)6;
							goto IL_001c;
						}
						goto IL_0054;
						IL_0353:
						if (text == "use")
						{
							gEnum = (GEnum7)12;
							goto IL_001c;
						}
						goto IL_0054;
						IL_0146:
						c = text[0];
						if (c == 'c')
						{
							if (text == "container")
							{
								gEnum = (GEnum7)17;
								goto IL_001c;
							}
						}
						else if (c == 'i' && text == "item_drop")
						{
							gEnum = (GEnum7)2;
							goto IL_001c;
						}
						goto IL_0054;
						IL_03de:
						c = text[2];
						if (c == 'l')
						{
							if (text == "pull")
							{
								gEnum = (GEnum7)4;
								goto IL_001c;
							}
						}
						else if (c == 'r')
						{
							if (text == "verb")
							{
								gEnum = (GEnum7)9;
								goto IL_001c;
							}
						}
						else if (c == 's' && text == "push")
						{
							gEnum = (GEnum7)5;
							goto IL_001c;
						}
						goto IL_0054;
						IL_001c:
						GEnum7 gEnum2 = gEnum;
						gClass.SendSpecificEvent((int)gEnum2);
						return;
						IL_00e5:
						if (text == "hand_activate")
						{
							gEnum = (GEnum7)1;
							goto IL_001c;
						}
						goto IL_0054;
						IL_0204:
						c = text[0];
						if (c == 'e')
						{
							if (text == "equip")
							{
								gEnum = (GEnum7)14;
								goto IL_001c;
							}
						}
						else if (c != 't')
						{
							if (c == 'w' && text == "wield")
							{
								gEnum = (GEnum7)18;
								goto IL_001c;
							}
						}
						else if (text == "throw")
						{
							gEnum = (GEnum7)13;
							goto IL_001c;
						}
						goto IL_0054;
					}
					catch (Exception)
					{
					}
				});
				break;
			}
			case 23:
				switch (type[13])
				{
				case 'o':
					if (!(type == "eventspammer_open_imgui") || itaskManager_0 == null)
					{
						break;
					}
					itaskManager_0.RunOnMainThread((Action)delegate
					{
						try
						{
							if (FeatureToggleState.EventSpammerOverlay != null)
							{
								FeatureToggleState.EventSpammerOverlay.ToggleWindow();
							}
						}
						catch (Exception)
						{
						}
					});
					break;
				case 'c':
					if (type == "eventspammer_clear_logs")
					{
						EventSpammer.ClearLogs();
					}
					break;
				}
				break;
			case 21:
				if (type == "eventspammer_get_logs")
				{
					await SendEventSpammerLogs(ws);
				}
				break;
			case 18:
				if (!(type == "eventspammer_start") || itaskManager_0 == null)
				{
					break;
				}
				itaskManager_0.RunOnMainThread((Action)delegate
				{
					try
					{
						IEntitySystemManager obj = IoCManager.Resolve<IEntitySystemManager>();
						((obj == null) ? null : obj.GetEntitySystem<EventSpammer>())?.StartEventSpam();
					}
					catch (Exception)
					{
					}
				});
				break;
			}
		}
		catch (Exception)
		{
		}
	}

	private async Task SendEventSpammerLogs(WebSocket ws)
	{
		try
		{
			List<EventLogEntry> logs = EventSpammer.GetLogs();
			string s = JsonSerializer.Serialize(new
			{
				type = "eventspammer_logs",
				data = logs
			});
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			await ws.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
		}
		catch (Exception)
		{
		}
	}

	private async Task SendPacketSpammerLogs(WebSocket ws)
	{
		try
		{
			List<PacketLogEntry> logs = PacketSpammer.GetLogs();
			string s = JsonSerializer.Serialize(new
			{
				type = "packetspammer_logs",
				data = logs
			});
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			await ws.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
		}
		catch (Exception)
		{
		}
	}

	private async Task HandlePainterLoadImage(JsonElement root, WebSocket ws)
	{
		try
		{
			if (!root.TryGetProperty("data", out var value) || value.ValueKind != JsonValueKind.String)
			{
				return;
			}
			string text = value.GetString();
			int MCD8l33Qmu = 32;
			int w2g8Kjau9E = 2;
			if (root.TryGetProperty("targetSize", out var value2) && value2.ValueKind == JsonValueKind.Number)
			{
				MCD8l33Qmu = value2.GetInt32();
			}
			if (root.TryGetProperty("detailLevel", out var value3) && value3.ValueKind == JsonValueKind.Number)
			{
				w2g8Kjau9E = value3.GetInt32();
			}
			try
			{
				if (text.Contains(","))
				{
					text = text.Split(',')[1];
				}
				byte[] bytes = Convert.FromBase64String(text);
				string MHD8Bn7J1Z = Path.Combine(Path.GetTempPath(), $"autopainter_{Guid.NewGuid()}.png");
				File.WriteAllBytes(MHD8Bn7J1Z, bytes);
				if (itaskManager_0 != null)
				{
					itaskManager_0.RunOnMainThread((Action)delegate
					{
						try
						{
							CrayonImageDrawer gClass = default(CrayonImageDrawer);
							if (!IoCManager.Resolve<IEntitySystemManager>().TryGetEntitySystem<CrayonImageDrawer>(ref gClass))
							{
								Logger.Error("[WebUI] AutoPainterSystem not found!");
							}
							else if (gClass != null)
							{
								gClass.TargetSize = MCD8l33Qmu;
								gClass.DetailLevel = w2g8Kjau9E;
								if (gClass.LoadImage(MHD8Bn7J1Z))
								{
									CerberusConfig.AutoPainter.LoadedImagePath = MHD8Bn7J1Z;
									CerberusConfig.AutoPainter.TargetSize = MCD8l33Qmu;
									CerberusConfig.AutoPainter.DetailLevel = w2g8Kjau9E;
									string processedImageBase = gClass.GetProcessedImageBase64();
									if (!string.IsNullOrEmpty(processedImageBase))
									{
										string s = JsonSerializer.Serialize(new
										{
											type = "painter_preview",
											processed = "data:image/png;base64," + processedImageBase
										});
										byte[] bytes2 = Encoding.UTF8.GetBytes(s);
										ArraySegment<byte> T6l8zOrGaU = new ArraySegment<byte>(bytes2);
										{
											foreach (WebSocket Yd4kp3DRGC in concurrentDictionary_0.Values)
											{
												if (Yd4kp3DRGC.State == WebSocketState.Open)
												{
													Task.Run(async delegate
													{
														try
														{
															await Yd4kp3DRGC.SendAsync(T6l8zOrGaU, WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
														}
														catch (Exception ex4)
														{
															Logger.Error("[WebUI] Failed to send to client: " + ex4.Message);
														}
													});
												}
											}
											return;
										}
									}
								}
								else
								{
									Logger.Error("[WebUI] LoadImage failed");
								}
							}
							else
							{
								Logger.Error("[WebUI] AutoPainterSystem is null!");
							}
						}
						catch (Exception ex3)
						{
							Logger.Error("[WebUI] Error in main thread: " + ex3.Message);
							Logger.Error("[WebUI] Stack trace: " + ex3.StackTrace);
						}
					});
				}
				else
				{
					Logger.Error("[WebUI] TaskManager is null, cannot execute on main thread");
				}
			}
			catch (Exception ex)
			{
				Logger.Error("[WebUI] Error processing image: " + ex.Message);
				Logger.Error("[WebUI] Stack trace: " + ex.StackTrace);
			}
		}
		catch (Exception ex2)
		{
			Logger.Error("[WebUI] HandlePainterLoadImage Error: " + ex2.Message);
		}
	}

	private async Task HandlePainterStart(WebSocket ws)
	{
		try
		{
			if (itaskManager_0 == null)
			{
				Logger.Error("[WebUI] TaskManager is null in HandlePainterStart");
				return;
			}
			itaskManager_0.RunOnMainThread((Action)delegate
			{
				try
				{
					CrayonImageDrawer u1vk1rOkdQ = default(CrayonImageDrawer);
					if (!IoCManager.Resolve<IEntitySystemManager>().TryGetEntitySystem<CrayonImageDrawer>(ref u1vk1rOkdQ))
					{
						Logger.Error("[WebUI] AutoPainterSystem not found in HandlePainterStart!");
					}
					else
					{
						u1vk1rOkdQ.Enabled = true;
						CerberusConfig.AutoPainter.Enabled = true;
						Task.Run(async delegate
						{
							try
							{
								await SendPainterStatus(u1vk1rOkdQ);
							}
							catch (Exception ex3)
							{
								Logger.Error("[WebUI] Failed to send painter status: " + ex3.Message);
							}
						});
					}
				}
				catch (Exception ex2)
				{
					Logger.Error("[WebUI] HandlePainterStart inner error: " + ex2.Message);
				}
			});
		}
		catch (Exception ex)
		{
			Logger.Error("[WebUI] HandlePainterStart Error: " + ex.Message);
		}
	}

	private async Task HandlePainterStop(WebSocket ws)
	{
		try
		{
			if (itaskManager_0 != null)
			{
				itaskManager_0.RunOnMainThread((Action)delegate
				{
					try
					{
						CrayonImageDrawer tvwkaHGvcF = default(CrayonImageDrawer);
						if (IoCManager.Resolve<IEntitySystemManager>().TryGetEntitySystem<CrayonImageDrawer>(ref tvwkaHGvcF))
						{
							tvwkaHGvcF.Enabled = false;
							CerberusConfig.AutoPainter.Enabled = false;
							Task.Run(async delegate
							{
								try
								{
									await SendPainterStatus(tvwkaHGvcF);
								}
								catch (Exception ex3)
								{
									Logger.Error("[WebUI] Failed to send painter status: " + ex3.Message);
								}
							});
						}
						else
						{
							Logger.Error("[WebUI] AutoPainterSystem not found in HandlePainterStop!");
						}
					}
					catch (Exception ex2)
					{
						Logger.Error("[WebUI] HandlePainterStop inner error: " + ex2.Message);
					}
				});
			}
			else
			{
				Logger.Error("[WebUI] TaskManager is null in HandlePainterStop");
			}
		}
		catch (Exception ex)
		{
			Logger.Error("[WebUI] HandlePainterStop Error: " + ex.Message);
		}
	}

	private async Task HandlePainterReset(WebSocket ws)
	{
		try
		{
			if (itaskManager_0 != null)
			{
				itaskManager_0.RunOnMainThread((Action)delegate
				{
					try
					{
						CrayonImageDrawer synkWvhXYW = default(CrayonImageDrawer);
						if (IoCManager.Resolve<IEntitySystemManager>().TryGetEntitySystem<CrayonImageDrawer>(ref synkWvhXYW))
						{
							synkWvhXYW.Reset();
							Task.Run(async delegate
							{
								try
								{
									await SendPainterStatus(synkWvhXYW);
								}
								catch (Exception ex3)
								{
									Logger.Error("[WebUI] Failed to send painter status: " + ex3.Message);
								}
							});
						}
						else
						{
							Logger.Error("[WebUI] AutoPainterSystem not found in HandlePainterReset!");
						}
					}
					catch (Exception ex2)
					{
						Logger.Error("[WebUI] HandlePainterReset inner error: " + ex2.Message);
					}
				});
			}
			else
			{
				Logger.Error("[WebUI] TaskManager is null in HandlePainterReset");
			}
		}
		catch (Exception ex)
		{
			Logger.Error("[WebUI] HandlePainterReset Error: " + ex.Message);
		}
	}

	private async Task SendPainterStatus(CrayonImageDrawer painterSystem)
	{
		try
		{
			string status = ((!painterSystem.Enabled) ? "Выключен" : "Включен");
			string s = JsonSerializer.Serialize(new
			{
				type = "painter_status",
				status = status,
				enabled = painterSystem.Enabled
			});
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			ArraySegment<byte> responseSegment = new ArraySegment<byte>(bytes);
			foreach (WebSocket value in concurrentDictionary_0.Values)
			{
				if (value.State == WebSocketState.Open)
				{
					await value.SendAsync(responseSegment, WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
				}
			}
		}
		catch (Exception ex)
		{
			Logger.Error("[WebUI] SendPainterStatus Error: " + ex.Message);
		}
	}

	private async Task SendEventLoggerEvents(WebSocket ws)
	{
		try
		{
			var data = (from e in (from e in EventLogger.GetEvents().ToList()
					orderby e.Id descending
					select e).Take(500)
				select new
				{
					id = e.Id,
					timestamp = e.Timestamp.ToString("HH:mm:ss.fff"),
					source = ((GEnum9)e.Source/*cast due to constrained. prefix*/).ToString(),
					eventType = e.EventType,
					eventNamespace = e.EventNamespace,
					entityId = e.EntityId,
					isGrouped = e.IsGrouped,
					groupCount = e.GroupCount,
					groupedEventIds = e.GroupedEventIds
				}).ToList();
			string s = JsonSerializer.Serialize(new
			{
				type = "eventlogger_events",
				data = data
			});
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			await ws.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
		}
		catch (Exception)
		{
		}
	}

	private async Task SendEventDetails(WebSocket ws, int eventId)
	{
		try
		{
			EventLogEntryFull eventById = EventLogger.GetEventById(eventId);
			if (eventById != null)
			{
				var fields = Enumerable.Select(eventById.Fields, (KeyValuePair<string, EventField> kvp) => new
				{
					name = kvp.Key,
					type = kvp.Value.Type,
					value = kvp.Value.Value
				}).ToList();
				string s = JsonSerializer.Serialize(new
				{
					type = "eventlogger_event_details",
					data = new
					{
						id = eventById.Id,
						timestamp = eventById.Timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff"),
						source = ((GEnum9)eventById.Source/*cast due to constrained. prefix*/).ToString(),
						eventType = eventById.EventType,
						eventNamespace = eventById.EventNamespace,
						entityId = eventById.EntityId,
						rawData = eventById.RawData,
						fields = fields,
						isGrouped = eventById.IsGrouped,
						groupCount = eventById.GroupCount,
						groupedEventIds = eventById.GroupedEventIds
					}
				});
				byte[] bytes = Encoding.UTF8.GetBytes(s);
				await ws.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
			}
		}
		catch (Exception)
		{
		}
	}

	private async Task BroadcastEventLoggerEvents()
	{
		foreach (WebSocket value in concurrentDictionary_0.Values)
		{
			if (value.State == WebSocketState.Open)
			{
				await SendEventLoggerEvents(value);
			}
		}
	}

	private void ReplayEvent(int eventId)
	{
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			object eventForReplay = EventLogger.GetEventForReplay(eventId);
			if (eventForReplay == null)
			{
				return;
			}
			EventLogEntryFull eventById = EventLogger.GetEventById(eventId);
			EntityUid val = default(EntityUid);
			if (eventById == null || ientityManager_0 == null || string.IsNullOrEmpty(eventById.EntityId) || !EntityUid.TryParse(eventById.EntityId.AsSpan(), ref val))
			{
				return;
			}
			object obj = null;
			try
			{
				Type type = eventForReplay.GetType();
				MethodInfo method = type.GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic);
				if (!(method != null))
				{
					obj = eventForReplay;
				}
				else
				{
					obj = method.Invoke(eventForReplay, null);
					PropertyInfo property = type.GetProperty("Handled");
					if (property != null && property.CanWrite)
					{
						property.SetValue(obj, false);
					}
				}
			}
			catch (Exception)
			{
				obj = eventForReplay;
			}
			bool flag = eventById.Source == 1;
			((IDirectedEventBus)ientityManager_0.EventBus).RaiseLocalEvent(val, obj, flag);
		}
		catch (Exception)
		{
		}
	}

	public void Dispose()
	{
		cancellationTokenSource_0?.Cancel();
		httpListener_0?.Stop();
		foreach (WebSocket value in concurrentDictionary_0.Values)
		{
			value.Dispose();
		}
	}
}
