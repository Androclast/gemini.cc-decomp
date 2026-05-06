using System;
using System.Collections.Generic;
using System.Numerics;
using CerberusWareV3.MyImGui;
using Hexa.NET.ImGui;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using PacketLogEntry;
using PacketSpammer;
using CerberusConfig;

namespace NotificationWindow;

public sealed class NotificationWindow : IOverlay
{
	private PacketSpammer? gclass260_0;

	private bool bool_0;

	private bool bool_1;

	private byte byte_1;

	private byte byte_2;

	private string string_0;

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

	private string String_0
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public void ToggleWindow()
	{
		bool_0 = !bool_0;
	}

	public void OpenWindow()
	{
		bool_0 = true;
	}

	public void CloseWindow()
	{
		bool_0 = false;
		if (CerberusConfig.PacketSpammer.Enabled)
		{
			CerberusConfig.PacketSpammer.Enabled = false;
			gclass260_0?.StopPacketSpam();
		}
	}

	public void Render()
	{
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		if (!bool_0)
		{
			return;
		}
		try
		{
			if (gclass260_0 == null)
			{
				try
				{
					IEntitySystemManager val = IoCManager.Resolve<IEntitySystemManager>();
					gclass260_0 = val.GetEntitySystem<PacketSpammer>();
				}
				catch (Exception)
				{
				}
			}
			ImGui.SetNextWindowSize(new Vector2(1000f, 750f), (ImGuiCond)4);
			ImGui.PushStyleVar((ImGuiStyleVar)14, new Vector2(10f, 10f));
			ImGui.PushStyleVar((ImGuiStyleVar)11, new Vector2(10f, 8f));
			ImGui.PushStyleVar((ImGuiStyleVar)2, new Vector2(15f, 15f));
			bool flag = true;
			if (ImGui.Begin("\ud83d\udc80 Packet Spammer (Lidgren)", ref flag, (ImGuiWindowFlags)0))
			{
				if (flag)
				{
					ImDrawListPtr windowDrawList = ImGui.GetWindowDrawList();
					Vector2 cursorScreenPos = ImGui.GetCursorScreenPos();
					Vector2 vector = new Vector2(cursorScreenPos.X + ImGui.GetWindowWidth() - 30f, cursorScreenPos.Y + 65f);
					((ImDrawListPtr)(ref windowDrawList)).AddRectFilledMultiColor(cursorScreenPos, vector, ImGui.GetColorU32(new Vector4(0.15f, 0.15f, 0.15f, 1f)), ImGui.GetColorU32(new Vector4(0.25f, 0.15f, 0.15f, 1f)), ImGui.GetColorU32(new Vector4(0.25f, 0.15f, 0.15f, 1f)), ImGui.GetColorU32(new Vector4(0.15f, 0.15f, 0.15f, 1f)));
					ImGui.SetCursorPosY(ImGui.GetCursorPosY() + 12f);
					ImGui.PushStyleColor((ImGuiCol)0, new Vector4(1f, 0.4f, 0f, 1f));
					ImGui.SetWindowFontScale(1.5f);
					ImGui.Text("\ud83d\udc80  LIDGREN PACKET SPAMMER");
					ImGui.SetWindowFontScale(1f);
					ImGui.PopStyleColor();
					ImGui.SameLine();
					ImGui.SetCursorPosX(ImGui.GetWindowWidth() - 340f);
					ImGui.PushStyleColor((ImGuiCol)0, new Vector4(0.6f, 0.6f, 0.6f, 1f));
					ImGui.Text("MTU=1  |  FlushSendQueue  |  Channel=0");
					ImGui.PopStyleColor();
					ImGui.SetCursorPosY(ImGui.GetCursorPosY() + 12f);
					ImGui.Separator();
					ImGui.Spacing();
					ImGui.Spacing();
					float num = 380f;
					ImGui.SetCursorPosX((ImGui.GetWindowWidth() - num) * 0.5f);
					bool enabled = CerberusConfig.PacketSpammer.Enabled;
					ImGui.PushStyleVar((ImGuiStyleVar)12, 10f);
					if (enabled)
					{
						ImGui.PushStyleColor((ImGuiCol)21, new Vector4(0.7f, 0f, 0f, 1f));
						ImGui.PushStyleColor((ImGuiCol)22, new Vector4(0.9f, 0f, 0f, 1f));
						ImGui.PushStyleColor((ImGuiCol)23, new Vector4(0.5f, 0f, 0f, 1f));
						ImGui.SetWindowFontScale(1.4f);
						if (ImGui.Button("⏹   STOP SPAM", new Vector2(num, 60f)))
						{
							CerberusConfig.PacketSpammer.Enabled = false;
							gclass260_0?.StopPacketSpam();
						}
						ImGui.SetWindowFontScale(1f);
						ImGui.PopStyleColor(3);
					}
					else
					{
						ImGui.PushStyleColor((ImGuiCol)21, new Vector4(0f, 0.5f, 0f, 1f));
						ImGui.PushStyleColor((ImGuiCol)22, new Vector4(0f, 0.7f, 0f, 1f));
						ImGui.PushStyleColor((ImGuiCol)23, new Vector4(0f, 0.3f, 0f, 1f));
						ImGui.SetWindowFontScale(1.4f);
						if (ImGui.Button("▶   START SPAM", new Vector2(num, 60f)))
						{
							CerberusConfig.PacketSpammer.Enabled = true;
							gclass260_0?.StartPacketSpam();
						}
						ImGui.SetWindowFontScale(1f);
						ImGui.PopStyleColor(3);
					}
					ImGui.PopStyleVar();
					ImGui.Spacing();
					ImGui.Spacing();
					ImGui.Separator();
					ImGui.Spacing();
					ImGui.Spacing();
					float x = (ImGui.GetWindowWidth() - 45f) * 0.5f;
					ImGui.PushStyleVar((ImGuiStyleVar)7, 8f);
					ImGui.PushStyleColor((ImGuiCol)3, new Vector4(0.12f, 0.12f, 0.12f, 0.9f));
					if (ImGui.BeginChild("LeftColumn", new Vector2(x, 380f), (ImGuiChildFlags)1))
					{
						ImGui.Spacing();
						ImGui.SetWindowFontScale(1.2f);
						ImGui.TextColored(new Vector4(0.4f, 0.8f, 1f, 1f), "⚙\ufe0f   ОСНОВНЫЕ НАСТРОЙКИ");
						ImGui.SetWindowFontScale(1f);
						ImGui.Separator();
						ImGui.Spacing();
						ImGui.Spacing();
						int packetSize = CerberusConfig.PacketSpammer.PacketSize;
						ImGui.Text("Packet Size:");
						ImGui.SetNextItemWidth(-1f);
						ImGui.PushStyleColor((ImGuiCol)7, new Vector4(0.2f, 0.2f, 0.25f, 1f));
						ImGui.PushStyleColor((ImGuiCol)19, new Vector4(0.4f, 0.6f, 1f, 1f));
						ImGui.PushStyleColor((ImGuiCol)20, new Vector4(0.5f, 0.7f, 1f, 1f));
						if (ImGui.SliderInt("##PacketSize", ref packetSize, 1, 1000, $"{packetSize} bytes"))
						{
							CerberusConfig.PacketSpammer.PacketSize = packetSize;
						}
						ImGui.PopStyleColor(3);
						ImGui.Spacing();
						int packetsPerBurst = CerberusConfig.PacketSpammer.PacketsPerBurst;
						ImGui.Text("Packets Per Burst:");
						ImGui.SetNextItemWidth(-1f);
						ImGui.PushStyleColor((ImGuiCol)7, new Vector4(0.2f, 0.2f, 0.25f, 1f));
						ImGui.PushStyleColor((ImGuiCol)19, new Vector4(0.4f, 0.6f, 1f, 1f));
						ImGui.PushStyleColor((ImGuiCol)20, new Vector4(0.5f, 0.7f, 1f, 1f));
						if (ImGui.SliderInt("##PacketsPerBurst", ref packetsPerBurst, 1, 1000))
						{
							CerberusConfig.PacketSpammer.PacketsPerBurst = packetsPerBurst;
						}
						ImGui.PopStyleColor(3);
						ImGui.Spacing();
						int burstDelay = CerberusConfig.PacketSpammer.BurstDelay;
						ImGui.Text("Burst Delay (ms):");
						ImGui.SetNextItemWidth(-1f);
						ImGui.PushStyleColor((ImGuiCol)7, new Vector4(0.2f, 0.2f, 0.25f, 1f));
						ImGui.PushStyleColor((ImGuiCol)19, new Vector4(0.4f, 0.6f, 1f, 1f));
						ImGui.PushStyleColor((ImGuiCol)20, new Vector4(0.5f, 0.7f, 1f, 1f));
						if (ImGui.SliderInt("##BurstDelay", ref burstDelay, 0, 1000))
						{
							CerberusConfig.PacketSpammer.BurstDelay = burstDelay;
						}
						ImGui.PopStyleColor(3);
						ImGui.Spacing();
						int threadCount = CerberusConfig.PacketSpammer.ThreadCount;
						ImGui.Text("Thread Count:");
						ImGui.SetNextItemWidth(-1f);
						ImGui.PushStyleColor((ImGuiCol)7, new Vector4(0.2f, 0.2f, 0.25f, 1f));
						ImGui.PushStyleColor((ImGuiCol)19, new Vector4(0.4f, 0.6f, 1f, 1f));
						ImGui.PushStyleColor((ImGuiCol)20, new Vector4(0.5f, 0.7f, 1f, 1f));
						if (ImGui.SliderInt("##ThreadCount", ref threadCount, 1, 32))
						{
							CerberusConfig.PacketSpammer.ThreadCount = threadCount;
						}
						ImGui.PopStyleColor(3);
						ImGui.Spacing();
						ImGui.Spacing();
						ImGui.Separator();
						ImGui.Spacing();
						ImGui.SetWindowFontScale(1.2f);
						ImGui.TextColored(new Vector4(0.4f, 0.8f, 1f, 1f), "\ud83d\udce6   ТИП ПАКЕТОВ");
						ImGui.SetWindowFontScale(1f);
						ImGui.Separator();
						ImGui.Spacing();
						int packetType = CerberusConfig.PacketSpammer.PacketType;
						ImGui.PushStyleColor((ImGuiCol)18, new Vector4(0.4f, 0.8f, 1f, 1f));
						if (ImGui.RadioButton("Битые (Random)", packetType == 0))
						{
							CerberusConfig.PacketSpammer.PacketType = 0;
						}
						if (ImGui.RadioButton("Тяжелые (Zeros)", packetType == 1))
						{
							CerberusConfig.PacketSpammer.PacketType = 1;
						}
						if (ImGui.RadioButton("Смешанные", packetType == 2))
						{
							CerberusConfig.PacketSpammer.PacketType = 2;
						}
						ImGui.PopStyleColor();
						ImGui.Spacing();
						ImGui.Separator();
						ImGui.Spacing();
						bool logSending = CerberusConfig.PacketSpammer.LogSending;
						ImGui.PushStyleColor((ImGuiCol)18, new Vector4(0.4f, 0.8f, 1f, 1f));
						if (ImGui.Checkbox("Log Sending (консоль)", ref logSending))
						{
							CerberusConfig.PacketSpammer.LogSending = logSending;
						}
						ImGui.PopStyleColor();
					}
					ImGui.EndChild();
					ImGui.PopStyleColor();
					ImGui.PopStyleVar();
					ImGui.SameLine();
					ImGui.PushStyleVar((ImGuiStyleVar)7, 8f);
					ImGui.PushStyleColor((ImGuiCol)3, new Vector4(0.12f, 0.12f, 0.12f, 0.9f));
					if (ImGui.BeginChild("RightColumn", new Vector2(x, 380f), (ImGuiChildFlags)1))
					{
						ImGui.Spacing();
						ImGui.SetWindowFontScale(1.2f);
						ImGui.TextColored(new Vector4(1f, 0.8f, 0.2f, 1f), "\ud83d\udcca   СТАТУС РАБОТЫ");
						ImGui.SetWindowFontScale(1f);
						ImGui.Separator();
						ImGui.Spacing();
						ImGui.Spacing();
						ImGui.TextColored(enabled ? new Vector4(0.2f, 1f, 0.2f, 1f) : new Vector4(0.7f, 0.7f, 0.7f, 1f), "Статус:  " + PacketSpammer.string_0);
						ImGui.Text($"Активных потоков:  {PacketSpammer.int_4}");
						ImGui.Spacing();
						ImGui.Separator();
						ImGui.Spacing();
						ImGui.TextColored(new Vector4(0.4f, 1f, 0.4f, 1f), "Статистика:");
						ImGui.Text($"Burst'ов отправлено:   {PacketSpammer.int_1}");
						ImGui.Text($"Пакетов отправлено:   {PacketSpammer.int_2}");
						if (PacketSpammer.int_3 > 0)
						{
							ImGui.TextColored(new Vector4(1f, 0.5f, 0f, 1f), $"Ошибок:   {PacketSpammer.int_3}");
						}
						if (PacketSpammer.nullable_0.HasValue)
						{
							TimeSpan timeSpan = DateTime.Now - PacketSpammer.nullable_0.Value;
							ImGui.Text($"Последний burst:   {timeSpan.TotalSeconds:F1}s назад");
						}
						ImGui.Spacing();
						ImGui.Separator();
						ImGui.Spacing();
						ImGui.TextColored(new Vector4(0.4f, 0.8f, 1f, 1f), "Подключение:");
						Vector4 vector2 = (PacketSpammer.bool_1 ? new Vector4(0.2f, 1f, 0.2f, 1f) : new Vector4(1f, 0.2f, 0.2f, 1f));
						Vector4 obj = (PacketSpammer.bool_2 ? new Vector4(0.2f, 1f, 0.2f, 1f) : new Vector4(1f, 0.2f, 0.2f, 1f));
						ImGui.TextColored(vector2, (!PacketSpammer.bool_1) ? "❌   NetPeer: NULL" : "✅   NetPeer: OK");
						ImGui.TextColored(obj, (!PacketSpammer.bool_2) ? "❌   Connection: NULL" : "✅   Connection: OK");
						ImGui.Spacing();
						ImGui.Separator();
						ImGui.Spacing();
						ImGui.TextColored(new Vector4(1f, 0.8f, 0.2f, 1f), "Нагрузка:");
						int packetSize2 = CerberusConfig.PacketSpammer.PacketSize;
						int packetsPerBurst2 = CerberusConfig.PacketSpammer.PacketsPerBurst;
						int burstDelay2 = CerberusConfig.PacketSpammer.BurstDelay;
						int threadCount2 = CerberusConfig.PacketSpammer.ThreadCount;
						float num2 = (float)(packetSize2 * packetsPerBurst2) / 1024f;
						ImGui.Text($"За burst:   {num2:F2} KB");
						if (burstDelay2 <= 0)
						{
							ImGui.TextColored(new Vector4(1f, 0.2f, 0.2f, 1f), "В секунду:   МАКСИМУМ");
						}
						else
						{
							float num3 = 1000f / (float)burstDelay2;
							float value = num2 * num3 * (float)threadCount2;
							ImGui.Text($"В секунду:   ~{value:F2} KB/s");
						}
						ImGui.Spacing();
						ImGui.Separator();
						ImGui.Spacing();
						ImGui.TextColored(new Vector4(0.4f, 1f, 0.4f, 1f), "\ud83c\udfaf   ПРЕСЕТЫ:");
						ImGui.Spacing();
						ImGui.PushStyleVar((ImGuiStyleVar)12, 5f);
						ImGui.PushStyleColor((ImGuiCol)21, new Vector4(0.2f, 0.4f, 0.6f, 1f));
						ImGui.PushStyleColor((ImGuiCol)22, new Vector4(0.3f, 0.5f, 0.7f, 1f));
						ImGui.PushStyleColor((ImGuiCol)23, new Vector4(0.15f, 0.3f, 0.5f, 1f));
						if (ImGui.Button("Легкий лаг", new Vector2(-1f, 30f)))
						{
							CerberusConfig.PacketSpammer.PacketSize = 8;
							CerberusConfig.PacketSpammer.PacketsPerBurst = 300;
							CerberusConfig.PacketSpammer.BurstDelay = 400;
							CerberusConfig.PacketSpammer.ThreadCount = 2;
						}
						ImGui.PopStyleColor(3);
						ImGui.PushStyleColor((ImGuiCol)21, new Vector4(0.6f, 0.4f, 0.2f, 1f));
						ImGui.PushStyleColor((ImGuiCol)22, new Vector4(0.7f, 0.5f, 0.3f, 1f));
						ImGui.PushStyleColor((ImGuiCol)23, new Vector4(0.5f, 0.3f, 0.15f, 1f));
						if (ImGui.Button("Средний лаг", new Vector2(-1f, 30f)))
						{
							CerberusConfig.PacketSpammer.PacketSize = 12;
							CerberusConfig.PacketSpammer.PacketsPerBurst = 800;
							CerberusConfig.PacketSpammer.BurstDelay = 100;
							CerberusConfig.PacketSpammer.ThreadCount = 4;
						}
						ImGui.PopStyleColor(3);
						ImGui.PushStyleColor((ImGuiCol)21, new Vector4(0.7f, 0.3f, 0f, 1f));
						ImGui.PushStyleColor((ImGuiCol)22, new Vector4(0.8f, 0.4f, 0f, 1f));
						ImGui.PushStyleColor((ImGuiCol)23, new Vector4(0.6f, 0.2f, 0f, 1f));
						if (ImGui.Button("Connection Timeout", new Vector2(-1f, 30f)))
						{
							CerberusConfig.PacketSpammer.PacketSize = 16;
							CerberusConfig.PacketSpammer.PacketsPerBurst = 1500;
							CerberusConfig.PacketSpammer.BurstDelay = 1;
							CerberusConfig.PacketSpammer.ThreadCount = 8;
						}
						ImGui.PopStyleColor(3);
						ImGui.PushStyleColor((ImGuiCol)21, new Vector4(0.6f, 0f, 0f, 1f));
						ImGui.PushStyleColor((ImGuiCol)22, new Vector4(0.8f, 0f, 0f, 1f));
						ImGui.PushStyleColor((ImGuiCol)23, new Vector4(0.4f, 0f, 0f, 1f));
						if (ImGui.Button("МАКСИМУМ \ud83d\udc80", new Vector2(-1f, 30f)))
						{
							CerberusConfig.PacketSpammer.PacketSize = 8150;
							CerberusConfig.PacketSpammer.PacketsPerBurst = 3000;
							CerberusConfig.PacketSpammer.BurstDelay = 1;
							CerberusConfig.PacketSpammer.ThreadCount = 16;
						}
						ImGui.PopStyleColor(3);
						ImGui.PopStyleVar();
					}
					ImGui.EndChild();
					ImGui.PopStyleColor();
					ImGui.PopStyleVar();
					ImGui.Spacing();
					ImGui.Spacing();
					ImGui.Separator();
					ImGui.Spacing();
					ImGui.SetWindowFontScale(1.2f);
					ImGui.TextColored(new Vector4(1f, 0.8f, 0.2f, 1f), "\ud83d\udccb   ЛОГИ ОТПРАВКИ");
					ImGui.SetWindowFontScale(1f);
					ImGui.SameLine();
					ImGui.PushStyleVar((ImGuiStyleVar)12, 5f);
					ImGui.PushStyleColor((ImGuiCol)21, new Vector4(0.3f, 0.3f, 0.4f, 1f));
					ImGui.PushStyleColor((ImGuiCol)22, new Vector4(0.4f, 0.4f, 0.5f, 1f));
					ImGui.PushStyleColor((ImGuiCol)23, new Vector4(0.2f, 0.2f, 0.3f, 1f));
					if (ImGui.Button("Очистить логи"))
					{
						PacketSpammer.ClearLogs();
					}
					ImGui.PopStyleColor(3);
					ImGui.PopStyleVar();
					ImGui.Spacing();
					ImGui.PushStyleVar((ImGuiStyleVar)7, 8f);
					ImGui.PushStyleColor((ImGuiCol)3, new Vector4(0.08f, 0.08f, 0.08f, 0.95f));
					if (ImGui.BeginChild("LogsZone", new Vector2(-1f, 160f), (ImGuiChildFlags)1))
					{
						List<PacketLogEntry> logs = PacketSpammer.GetLogs();
						if (logs.Count != 0)
						{
							ImGui.TextColored(new Vector4(0.4f, 0.8f, 1f, 1f), $"Всего записей:  {logs.Count}");
							ImGui.Separator();
							ImGui.Spacing();
							foreach (PacketLogEntry item in logs)
							{
								ImGui.TextColored((item.Status == "success") ? new Vector4(0.2f, 1f, 0.2f, 1f) : new Vector4(1f, 0.2f, 0.2f, 1f), $"[{item.Timestamp}]   {item.Type}:   {item.Error}");
							}
						}
						else
						{
							ImGui.Spacing();
							ImGui.Spacing();
							ImGui.TextColored(new Vector4(0.6f, 0.6f, 0.6f, 1f), "Логи пусты. Включи 'Log Sending' и нажми START SPAM.");
						}
					}
					ImGui.EndChild();
					ImGui.PopStyleColor();
					ImGui.PopStyleVar();
					ImGui.Spacing();
					ImGui.Separator();
					ImGui.Spacing();
					ImGui.PushStyleColor((ImGuiCol)0, new Vector4(1f, 0.3f, 0.3f, 1f));
					ImGui.Text("⚠\ufe0f   ВНИМАНИЕ:  Используй только на своих серверах! Может привести к бану.");
					ImGui.PopStyleColor();
					ImGui.PopStyleVar(3);
					ImGui.End();
				}
				else
				{
					CloseWindow();
					ImGui.PopStyleVar(3);
					ImGui.End();
				}
			}
			else
			{
				ImGui.PopStyleVar(3);
				ImGui.End();
			}
		}
		catch (Exception)
		{
			try
			{
				ImGui.End();
			}
			catch
			{
			}
		}
	}
}
