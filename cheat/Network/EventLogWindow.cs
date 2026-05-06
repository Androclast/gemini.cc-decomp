using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using CerberusWareV3.Features.Events;
using CerberusWareV3.MyImGui;
using Hexa.NET.ImGui;
using EventLogger;
using EventLogEntryFull;

namespace EventLogWindow;

public sealed class EventLogWindow : IOverlay
{
	private bool bool_0;

	private int? nullable_0;

	private string string_0 = "";

	private string string_1 = "All";

	private bool bool_1 = true;

	private float float_0 = 900f;

	private readonly Vector4 vector4_0 = new Vector4(0.02f, 0.71f, 0.83f, 1f);

	private readonly Vector4 vector4_1 = new Vector4(0.66f, 0.33f, 0.97f, 1f);

	private readonly Vector4 vector4_2 = new Vector4(0.04f, 0.04f, 0.06f, 0.95f);

	private readonly Vector4 vector4_3 = new Vector4(0.02f, 0.02f, 0.04f, 1f);

	private readonly Vector4 vector4_4 = new Vector4(1f, 1f, 1f, 0.15f);

	private readonly Vector4 vector4_5 = new Vector4(1f, 1f, 1f, 1f);

	private readonly Vector4 vector4_6 = new Vector4(0.7f, 0.7f, 0.7f, 1f);

	private readonly Vector4 vector4_7 = new Vector4(0.2f, 0.9f, 0.4f, 1f);

	private readonly Vector4 vector4_8 = new Vector4(0.9f, 0.2f, 0.3f, 1f);

	private readonly Vector4 vector4_9 = new Vector4(0.7f, 0.3f, 0.9f, 1f);

	private readonly Vector4 vector4_10 = new Vector4(0.9f, 0.8f, 0.2f, 1f);

	private long long_2;

	private long long_3;

	private double double_1;

	private long Int64_0
	{
		get
		{
			return long_2;
		}
		set
		{
			long_2 = value;
		}
	}

	private long Int64_1
	{
		get
		{
			return long_3;
		}
		set
		{
			long_3 = value;
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

	public void ToggleWindow()
	{
		bool_0 = !bool_0;
	}

	public void Render()
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		if (!bool_0)
		{
			return;
		}
		try
		{
			ImGui.SetNextWindowSize(new Vector2(1600f, 900f), (ImGuiCond)4);
			ImGui.SetNextWindowPos(new Vector2(160f, 50f), (ImGuiCond)4);
			if (ImGui.Begin("Event Logger", ref bool_0, (ImGuiWindowFlags)0))
			{
				DrawHeader();
				DrawControls();
				ImGui.Spacing();
				float x = ImGui.GetContentRegionAvail().X;
				float y = ImGui.GetContentRegionAvail().Y;
				if (float_0 < 300f)
				{
					float_0 = 300f;
				}
				if (!(float_0 <= x - 300f))
				{
					float_0 = x - 300f;
				}
				if (ImGui.BeginChild("EventList", new Vector2(float_0, y), (ImGuiChildFlags)1))
				{
					DrawEventList();
				}
				ImGui.EndChild();
				ImGui.SameLine();
				ImGui.Button("##splitter", new Vector2(4f, y));
				if (ImGui.IsItemActive())
				{
					float num = float_0;
					ImGuiIOPtr iO = ImGui.GetIO();
					float_0 = num + ((ImGuiIOPtr)(ref iO)).MouseDelta.X;
				}
				if (ImGui.IsItemHovered())
				{
					ImGui.SetMouseCursor((ImGuiMouseCursor)2);
				}
				ImGui.SameLine();
				float x2 = x - float_0 - 12f;
				if (ImGui.BeginChild("EventDetails", new Vector2(x2, y), (ImGuiChildFlags)1))
				{
					DrawEventDetails();
				}
				ImGui.EndChild();
			}
			ImGui.End();
		}
		catch (Exception)
		{
		}
	}

	private void DrawHeader()
	{
		List<EventLogEntryFull> list = EventLogger.GetEvents().ToList();
		ImGui.Text($"EVENTS: {list.Count}");
		ImGui.SameLine();
		if (nullable_0.HasValue)
		{
			ImGui.Text($"Selected: #{nullable_0.Value}");
		}
		ImGui.Separator();
	}

	private void DrawControls()
	{
		ImGui.Text("CONTROLS");
		ImGui.Separator();
		ImGui.PushStyleVar((ImGuiStyleVar)8, 1f);
		if (ImGui.BeginChild("ControlsSection", new Vector2(0f, 80f)))
		{
			if (ImGui.Button("Clear All", new Vector2(100f, 25f)))
			{
				EventLogger.Clear();
				nullable_0 = null;
			}
			ImGui.SameLine();
			bool flag = bool_1;
			if (ImGui.Checkbox("Auto Scroll", ref flag))
			{
				bool_1 = flag;
			}
			ImGui.SameLine();
			ImGui.SetNextItemWidth(200f);
			ImGui.InputText("Search", ref string_0, (UIntPtr)(nuint)256u);
			ImGui.SameLine();
			ImGui.Text("Source:");
			ImGui.SameLine();
			ImGui.SetNextItemWidth(120f);
			if (ImGui.BeginCombo("##source", string_1))
			{
				if (ImGui.Selectable("All", string_1 == "All"))
				{
					string_1 = "All";
				}
				if (ImGui.Selectable("Local", string_1 == "Local"))
				{
					string_1 = "Local";
				}
				if (ImGui.Selectable("Network", string_1 == "Network"))
				{
					string_1 = "Network";
				}
				ImGui.EndCombo();
			}
		}
		ImGui.EndChild();
		ImGui.PopStyleVar();
	}

	private void DrawEventList()
	{
		ImGui.Text("EVENT LIST");
		ImGui.Separator();
		if (ImGui.BeginChild("EventListContent", new Vector2(0f, 0f)))
		{
			ImGui.Columns(5, "EventColumns", true);
			ImGui.SetColumnWidth(0, 50f);
			ImGui.SetColumnWidth(1, 80f);
			ImGui.SetColumnWidth(2, 80f);
			ImGui.SetColumnWidth(3, 250f);
			ImGui.SetColumnWidth(4, 150f);
			ImGui.Text("ID");
			ImGui.NextColumn();
			ImGui.Text("Time");
			ImGui.NextColumn();
			ImGui.Text("Source");
			ImGui.NextColumn();
			ImGui.Text("Event Type");
			ImGui.NextColumn();
			ImGui.Text("Entity");
			ImGui.NextColumn();
			ImGui.Separator();
			IEnumerable<EventLogEntryFull> source = EventLogger.GetEvents().AsEnumerable();
			if (!string.IsNullOrEmpty(string_0))
			{
				source = source.Where((EventLogEntryFull e) => e.EventType.Contains(string_0, StringComparison.OrdinalIgnoreCase) || e.EventNamespace.Contains(string_0, StringComparison.OrdinalIgnoreCase));
			}
			if (string_1 != "All")
			{
				source = source.Where((EventLogEntryFull e) => e.Source.ToString() == string_1);
			}
			List<EventLogEntryFull> list = source.ToList();
			foreach (EventLogEntryFull item in list)
			{
				bool flag = nullable_0 == item.Id;
				if (!flag)
				{
					Vector4 vector = ((item.Source != 0) ? vector4_9 : vector4_10);
					ImGui.PushStyleColor((ImGuiCol)0, vector);
				}
				else
				{
					ImGui.PushStyleColor((ImGuiCol)0, vector4_7);
				}
				if (ImGui.Selectable($"#{item.Id}", flag, (ImGuiSelectableFlags)2))
				{
					nullable_0 = item.Id;
				}
				ImGui.NextColumn();
				ImGui.Text(item.Timestamp.ToString("HH:mm:ss.fff"));
				ImGui.NextColumn();
				ImGui.Text(item.Source.ToString());
				ImGui.NextColumn();
				ImGui.Text(item.EventType);
				ImGui.NextColumn();
				ImGui.Text(item.EntityId ?? "N/A");
				ImGui.NextColumn();
				ImGui.PopStyleColor();
			}
			ImGui.Columns(1);
			if (bool_1 && list.Count > 0)
			{
				ImGui.SetScrollHereY(1f);
			}
		}
		ImGui.EndChild();
	}

	private void DrawEventDetails()
	{
		//IL_00a6: Expected O, but got I4
		ImGui.Text("EVENT DETAILS");
		ImGui.Separator();
		if (ImGui.BeginChild("EventDetailsContent", new Vector2(0f, 0f)))
		{
			if (nullable_0.HasValue)
			{
				EventLogEntryFull eventById = EventLogger.GetEventById(nullable_0.Value);
				if (eventById == null)
				{
					ImGui.Text("Event not found (may have been cleared)");
					nullable_0 = null;
				}
				else
				{
					ImGui.Text($"ID: #{eventById.Id}");
					ImGui.Text($"Timestamp: {eventById.Timestamp:HH:mm:ss.fff}");
					ImGui.Text($"Source: {(GEnum9)(object)eventById.Source}");
					ImGui.Text("Event Type: " + eventById.EventType);
					ImGui.Text("Namespace: " + eventById.EventNamespace);
					ImGui.Text("Entity ID: " + (eventById.EntityId ?? "N/A"));
					if (eventById.IsGrouped)
					{
						ImGui.Text($"Grouped: {eventById.GroupCount} similar events");
					}
					ImGui.Separator();
					ImGui.Spacing();
					ImGui.Text("Raw Data:");
					string rawData = eventById.RawData;
					ImGui.InputTextMultiline("##rawdata", ref rawData, (UIntPtr)(nuint)10000u, new Vector2(-1f, 300f), (ImGuiInputTextFlags)512);
					ImGui.Spacing();
					ImGui.Button("Replay Event", new Vector2(150f, 30f));
					ImGui.SameLine();
					if (ImGui.Button("Copy Data", new Vector2(150f, 30f)))
					{
						ImGui.SetClipboardText(eventById.RawData);
					}
				}
			}
			else
			{
				ImGui.Text("No event selected");
			}
		}
		ImGui.EndChild();
	}
}
