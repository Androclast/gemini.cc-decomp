using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using CerberusWareV3.Features.Network;
using CerberusWareV3.MyImGui;
using Hexa.NET.ImGui;
using PacketLogger;
using PacketLogEntryFull;
using PacketField;

namespace PacketEditorWindow;

public sealed class PacketEditorWindow : IOverlay
{
	private bool bool_0;

	private HashSet<int> hashSet_0 = new HashSet<int>();

	private int? nullable_0;

	private string string_0 = "";

	private bool bool_1 = true;

	private bool bool_2 = true;

	private bool bool_3 = true;

	private float float_0 = 600f;

	private bool bool_4;

	private float float_1;

	private bool bool_5;

	private HashSet<string> hashSet_1 = new HashSet<string> { "MsgStateAck", "MsgState", "MsgTick", "MsgPing", "MsgPong", "GasOverlayUpdateEvent" };

	private bool bool_6;

	private PacketLogEntryFull? gclass265_0;

	private Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

	private readonly Vector4 vector4_0 = new Vector4(0.49f, 0.78f, 0.89f, 1f);

	private readonly Vector4 vector4_1 = new Vector4(0.94f, 0.75f, 0.25f, 1f);

	private readonly Vector4 vector4_2 = new Vector4(0.26f, 0.59f, 0.98f, 0.4f);

	private readonly Vector4 vector4_3 = new Vector4(0.8f, 0.6f, 1f, 1f);

	private double double_0;

	private float float_2;

	private float float_3;

	private bool bool_8;

	private double Double_0
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	private float Single_0
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	private float Single_1
	{
		get
		{
			return float_3;
		}
		set
		{
			float_3 = value;
		}
	}

	private bool Boolean_0
	{
		get
		{
			return bool_8;
		}
		set
		{
			bool_8 = value;
		}
	}

	public void ToggleWindow()
	{
		bool_0 = !bool_0;
	}

	public void Render()
	{
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		if (!bool_0)
		{
			return;
		}
		try
		{
			PacketLogger.ProcessQueue();
			ImGuiIOPtr iO;
			if (bool_4 && hashSet_0.Count > 0)
			{
				float num = float_1;
				iO = ImGui.GetIO();
				float_1 = num + ((ImGuiIOPtr)(ref iO)).DeltaTime;
				if (float_1 >= 0.1f)
				{
					float_1 = 0f;
					PacketLogger.ResendPackets(hashSet_0);
				}
			}
			ImGui.SetWindowFontScale(1.4f);
			ImGui.SetNextWindowSize(new Vector2(1000f, 650f), (ImGuiCond)4);
			ImGui.SetNextWindowPos(new Vector2(160f, 50f), (ImGuiCond)4);
			if (ImGui.Begin("Network Logger [Harmony]", ref bool_0, (ImGuiWindowFlags)0))
			{
				DrawHeader();
				DrawControls();
				ImGui.Spacing();
				float x = ImGui.GetContentRegionAvail().X;
				float y = ImGui.GetContentRegionAvail().Y;
				if (!(float_0 >= 250f))
				{
					float_0 = 250f;
				}
				if (!(float_0 <= x - 250f))
				{
					float_0 = x - 250f;
				}
				if (ImGui.BeginChild("PacketList", new Vector2(float_0, y), (ImGuiChildFlags)1))
				{
					DrawPacketList();
				}
				ImGui.EndChild();
				ImGui.SameLine();
				ImGui.Button("##splitter", new Vector2(4f, y));
				if (ImGui.IsItemActive())
				{
					float num2 = float_0;
					iO = ImGui.GetIO();
					float_0 = num2 + ((ImGuiIOPtr)(ref iO)).MouseDelta.X;
				}
				if (ImGui.IsItemHovered())
				{
					ImGui.SetMouseCursor((ImGuiMouseCursor)2);
				}
				ImGui.SameLine();
				float x2 = x - float_0 - 12f;
				if (ImGui.BeginChild("PacketDetails", new Vector2(x2, y), (ImGuiChildFlags)1))
				{
					DrawPacketDetails();
				}
				ImGui.EndChild();
			}
			ImGui.End();
			ImGui.SetWindowFontScale(1f);
			if (bool_6)
			{
				DrawEditWindow();
			}
		}
		catch (Exception)
		{
		}
	}

	private void DrawHeader()
	{
		List<PacketLogEntryFull> list = PacketLogger.GetPackets().ToList();
		ImGui.Text($"PACKETS: {list.Count}");
		ImGui.SameLine();
		if (hashSet_0.Count > 0)
		{
			ImGui.TextColored(vector4_2, $"Selected: {hashSet_0.Count}");
		}
		ImGui.SameLine();
		if (bool_4)
		{
			ImGui.TextColored(new Vector4(0.2f, 0.9f, 0.4f, 1f), "[AUTO-RESEND ACTIVE]");
		}
		ImGui.Separator();
	}

	private void DrawControls()
	{
		ImGui.Text("CONTROLS");
		ImGui.Separator();
		if (ImGui.BeginChild("ControlsSection", new Vector2(0f, 170f), (ImGuiChildFlags)1))
		{
			if (ImGui.Button("Clear All", new Vector2(140f, 38f)))
			{
				PacketLogger.Clear();
				hashSet_0.Clear();
				nullable_0 = null;
			}
			ImGui.SameLine();
			if (ImGui.Button("Select All", new Vector2(140f, 38f)))
			{
				SelectAll();
			}
			ImGui.SameLine();
			if (ImGui.Button("Deselect All", new Vector2(140f, 38f)))
			{
				hashSet_0.Clear();
				nullable_0 = null;
			}
			ImGui.SameLine();
			ImGui.Checkbox("Auto Scroll", ref bool_3);
			ImGui.SameLine();
			ImGui.Checkbox("Anti-Spam", ref bool_5);
			if (ImGui.IsItemHovered())
			{
				ImGui.SetTooltip("Скрывает MsgStateAck, MsgState, MsgTick, MsgPing, MsgPong");
			}
			ImGui.SetNextItemWidth(350f);
			ImGui.InputText("Search", ref string_0, (UIntPtr)(nuint)256u);
			ImGui.SameLine();
			ImGui.Checkbox("Incoming", ref bool_1);
			ImGui.SameLine();
			ImGui.Checkbox("Outgoing", ref bool_2);
			bool num = hashSet_0.Count > 0;
			if (!num)
			{
				ImGui.BeginDisabled();
			}
			if (ImGui.Button("Resend Selected", new Vector2(200f, 38f)))
			{
				PacketLogger.ResendPackets(hashSet_0);
			}
			ImGui.SameLine();
			if (ImGui.Button("Edit Selected", new Vector2(200f, 38f)) && hashSet_0.Count > 0)
			{
				int packetId = hashSet_0.First();
				OpenEditWindow(packetId);
			}
			ImGui.SameLine();
			bool flag = bool_4;
			if (ImGui.Checkbox("Auto-Resend (0.1s)", ref flag))
			{
				bool_4 = flag;
				float_1 = 0f;
			}
			if (!num)
			{
				ImGui.EndDisabled();
			}
		}
		ImGui.EndChild();
	}

	private void DrawPacketList()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		ImGui.Text("PACKET LIST (Ctrl+Click, Shift+Click)");
		ImGui.Separator();
		if (ImGui.BeginChild("PacketListContent", new Vector2(0f, 0f)))
		{
			IEnumerable<PacketLogEntryFull> source = PacketLogger.GetPackets().ToList().AsEnumerable();
			if (!string.IsNullOrEmpty(string_0))
			{
				source = source.Where((PacketLogEntryFull p) => p.MsgName.Contains(string_0, StringComparison.OrdinalIgnoreCase) || p.DisplayName.Contains(string_0, StringComparison.OrdinalIgnoreCase) || p.MsgGroup.Contains(string_0, StringComparison.OrdinalIgnoreCase));
			}
			if (!bool_1)
			{
				source = source.Where((PacketLogEntryFull p) => p.Direction != 1);
			}
			if (!bool_2)
			{
				source = source.Where((PacketLogEntryFull p) => p.Direction != 0);
			}
			if (bool_5)
			{
				source = source.Where((PacketLogEntryFull p) => !hashSet_1.Contains(p.MsgName));
			}
			List<PacketLogEntryFull> list = source.ToList();
			ImGuiIOPtr iO = ImGui.GetIO();
			bool keyCtrl = ((ImGuiIOPtr)(ref iO)).KeyCtrl;
			iO = ImGui.GetIO();
			bool keyShift = ((ImGuiIOPtr)(ref iO)).KeyShift;
			foreach (PacketLogEntryFull item in list)
			{
				bool flag = hashSet_0.Contains(item.Id);
				Vector4 vector = ((item.Direction != 1) ? vector4_1 : vector4_0);
				if (item.IsGrouped)
				{
					vector = vector4_3;
				}
				ImGui.PushStyleColor((ImGuiCol)0, vector);
				if (ImGui.Selectable(item.IsGrouped ? $"#{item.Id} [{item.Timestamp:HH:mm:ss.fff}] {item.DisplayName} ×{item.GroupCount}" : $"#{item.Id} [{item.Timestamp:HH:mm:ss.fff}] {item.DisplayName} ({item.Size}B)", flag))
				{
					HandlePacketClick(item.Id, keyCtrl, keyShift, list);
				}
				ImGui.PopStyleColor();
			}
			if (bool_3 && list.Count > 0)
			{
				ImGui.SetScrollHereY(1f);
			}
		}
		ImGui.EndChild();
	}

	private void HandlePacketClick(int clickedId, bool ctrl, bool shift, List<PacketLogEntryFull> allPackets)
	{
		if (!shift || !nullable_0.HasValue)
		{
			if (!ctrl)
			{
				hashSet_0.Clear();
				hashSet_0.Add(clickedId);
				nullable_0 = clickedId;
				return;
			}
			if (hashSet_0.Contains(clickedId))
			{
				hashSet_0.Remove(clickedId);
			}
			else
			{
				hashSet_0.Add(clickedId);
			}
			nullable_0 = clickedId;
			return;
		}
		List<int> list = allPackets.Select((PacketLogEntryFull p) => p.Id).ToList();
		int num = list.IndexOf(nullable_0.Value);
		int num2 = list.IndexOf(clickedId);
		if (num >= 0 && num2 >= 0)
		{
			if (!ctrl)
			{
				hashSet_0.Clear();
			}
			int num3 = Math.Min(num, num2);
			int num4 = Math.Max(num, num2);
			for (int num5 = num3; num5 <= num4; num5++)
			{
				hashSet_0.Add(list[num5]);
			}
		}
	}

	private void SelectAll()
	{
		IEnumerable<PacketLogEntryFull> packets = PacketLogger.GetPackets();
		hashSet_0.Clear();
		foreach (PacketLogEntryFull item in packets)
		{
			hashSet_0.Add(item.Id);
		}
		if (hashSet_0.Count > 0)
		{
			nullable_0 = hashSet_0.Last();
		}
	}

	private void DrawPacketDetails()
	{
		//IL_0320: Expected O, but got I4
		ImGui.Text("PACKET DETAILS");
		ImGui.Separator();
		if (ImGui.BeginChild("PacketDetailsContent", new Vector2(0f, 0f)))
		{
			if (hashSet_0.Count == 0)
			{
				ImGui.Text("No packet selected");
			}
			else if (hashSet_0.Count == 1)
			{
				int num = hashSet_0.First();
				PacketLogEntryFull packetById = PacketLogger.GetPacketById(num);
				if (packetById != null)
				{
					ImGui.Text($"ID: #{packetById.Id}");
					ImGui.Text($"Timestamp: {packetById.Timestamp:HH:mm:ss.fff}");
					ImGui.TextColored((packetById.Direction == 1) ? vector4_0 : vector4_1, $"Direction: {(GEnum8)(object)packetById.Direction}");
					ImGui.Text("Message Type: " + packetById.MessageType);
					ImGui.Text("Message Name: " + packetById.DisplayName);
					ImGui.Text("Message Group: " + packetById.MsgGroup);
					ImGui.Text($"Size: {packetById.Size} bytes");
					ImGui.Text("Channel: " + packetById.Channel);
					if (packetById.IsGrouped)
					{
						ImGui.TextColored(vector4_3, $"Grouped: {packetById.GroupCount} similar packets");
					}
					ImGui.Separator();
					ImGui.Spacing();
					if (packetById.Fields.Count > 0)
					{
						ImGui.Text("FIELDS:");
						if (ImGui.BeginChild("FieldsList", new Vector2(0f, 150f), (ImGuiChildFlags)1))
						{
							foreach (KeyValuePair<string, PacketField> field in packetById.Fields)
							{
								ImGui.Text($"{field.Key} ({field.Value.Type}): {field.Value.Value}");
							}
						}
						ImGui.EndChild();
						ImGui.Spacing();
					}
					ImGui.Text("RAW DATA:");
					string rawData = packetById.RawData;
					ImGui.InputTextMultiline("##rawdata", ref rawData, (UIntPtr)(nuint)10000u, new Vector2(-1f, 300f), (ImGuiInputTextFlags)512);
				}
				else
				{
					ImGui.Text("Packet not found (may have been cleared)");
					hashSet_0.Remove(num);
				}
			}
			else
			{
				ImGui.Text($"Multiple packets selected: {hashSet_0.Count}");
				ImGui.Spacing();
				ImGui.Text("Actions available:");
				ImGui.BulletText("Resend Selected - sends all selected packets");
				ImGui.BulletText("Auto-Resend - continuously resends selected packets");
			}
		}
		ImGui.EndChild();
	}

	private void OpenEditWindow(int packetId)
	{
		PacketLogEntryFull packetById = PacketLogger.GetPacketById(packetId);
		if (packetById == null)
		{
			return;
		}
		gclass265_0 = packetById;
		dictionary_0.Clear();
		foreach (KeyValuePair<string, PacketField> field in packetById.Fields)
		{
			if (field.Value.IsEditable)
			{
				dictionary_0[field.Key] = field.Value.Value;
			}
		}
		bool_6 = true;
	}

	private void DrawEditWindow()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		if (gclass265_0 != null)
		{
			ImGui.SetNextWindowSize(new Vector2(500f, 600f), (ImGuiCond)4);
			ImGuiViewportPtr mainViewport = ImGui.GetMainViewport();
			ImGui.SetNextWindowPos(new Vector2(((ImGuiViewportPtr)(ref mainViewport)).WorkPos.X + ((ImGuiViewportPtr)(ref mainViewport)).WorkSize.X * 0.5f, ((ImGuiViewportPtr)(ref mainViewport)).WorkPos.Y + ((ImGuiViewportPtr)(ref mainViewport)).WorkSize.Y * 0.5f), (ImGuiCond)8, new Vector2(0.5f, 0.5f));
			if (ImGui.Begin("Edit Packet", ref bool_6, (ImGuiWindowFlags)0))
			{
				ImGui.Text("Editing: " + gclass265_0.DisplayName);
				ImGui.Text($"ID: #{gclass265_0.Id}");
				ImGui.Separator();
				ImGui.Spacing();
				if (dictionary_0.Count != 0)
				{
					ImGui.Text("EDITABLE FIELDS:");
					ImGui.Spacing();
					if (ImGui.BeginChild("EditFieldsList", new Vector2(0f, -40f)))
					{
						foreach (string item in dictionary_0.Keys.ToList())
						{
							ImGui.Text(item + ":");
							ImGui.SameLine();
							ImGui.SetNextItemWidth(-1f);
							string value = dictionary_0[item];
							if (ImGui.InputText("##" + item, ref value, (UIntPtr)(nuint)256u))
							{
								dictionary_0[item] = value;
							}
						}
					}
					ImGui.EndChild();
				}
				else
				{
					ImGui.Text("No editable fields in this packet");
				}
				ImGui.Spacing();
				if (ImGui.Button("Send Edited", new Vector2(150f, 30f)))
				{
					ApplyEditsAndSend();
				}
				ImGui.SameLine();
				if (ImGui.Button("Cancel", new Vector2(150f, 30f)))
				{
					bool_6 = false;
				}
			}
			ImGui.End();
			if (!bool_6)
			{
				gclass265_0 = null;
				dictionary_0.Clear();
			}
		}
		else
		{
			bool_6 = false;
		}
	}

	private void ApplyEditsAndSend()
	{
		if (gclass265_0 == null)
		{
			return;
		}
		foreach (KeyValuePair<string, string> item in dictionary_0)
		{
			PacketLogger.UpdatePacketField(gclass265_0.Id, item.Key, item.Value);
		}
		PacketLogger.ResendPacket(gclass265_0.Id);
		bool_6 = false;
	}

	private void DrawSectionHeader(string title, Vector4 color)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		ImDrawListPtr windowDrawList = ImGui.GetWindowDrawList();
		Vector2 cursorScreenPos = ImGui.GetCursorScreenPos();
		Vector2 vector = new Vector2(ImGui.GetContentRegionAvail().X, 25f);
		Vector4 vector2 = new Vector4(color.X * 0.35f, color.Y * 0.35f, color.Z * 0.35f, color.W);
		Vector4 vector3 = new Vector4(color.X * 0.15f, color.Y * 0.15f, color.Z * 0.15f, color.W);
		((ImDrawListPtr)(ref windowDrawList)).AddRectFilledMultiColor(cursorScreenPos, cursorScreenPos + vector, ImGui.GetColorU32(vector2), ImGui.GetColorU32(vector3), ImGui.GetColorU32(vector3), ImGui.GetColorU32(vector2));
		Vector4 vector4 = new Vector4(1f, 1f, 1f, 0.15f);
		((ImDrawListPtr)(ref windowDrawList)).AddRect(cursorScreenPos, cursorScreenPos + vector, ImGui.GetColorU32(vector4), 4f, (ImDrawFlags)0, 1f);
		ImGui.SetCursorPosY(ImGui.GetCursorPosY() + 6f);
		ImGui.Indent(8f);
		ImGui.PushStyleColor((ImGuiCol)0, color);
		ImGui.Text(title);
		ImGui.PopStyleColor();
		ImGui.Unindent(8f);
		ImGui.SetCursorPosY(ImGui.GetCursorPosY() + 6f);
	}
}
