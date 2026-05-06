using System;
using System.Collections.Generic;
using System.Numerics;
using CerberusWareV3.MyImGui;
using Hexa.NET.ImGui;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using EventLogEntry;
using EventSpammer;
using CerberusConfig;

namespace EventSenderWindow;

public sealed class EventSenderWindow : IOverlay
{
	private bool bool_0;

	private EventSpammer? gclass253_0;

	private readonly Vector4 vector4_0 = new Vector4(0.02f, 0.71f, 0.83f, 1f);

	private readonly Vector4 vector4_1 = new Vector4(0.66f, 0.33f, 0.97f, 1f);

	private readonly Vector4 vector4_2 = new Vector4(0.04f, 0.04f, 0.06f, 0.95f);

	private readonly Vector4 vector4_3 = new Vector4(0.02f, 0.02f, 0.04f, 1f);

	private readonly Vector4 vector4_4 = new Vector4(1f, 1f, 1f, 0.15f);

	private readonly Vector4 vector4_5 = new Vector4(1f, 1f, 1f, 1f);

	private readonly Vector4 vector4_6 = new Vector4(0.7f, 0.7f, 0.7f, 1f);

	private readonly Vector4 vector4_7 = new Vector4(0.2f, 0.9f, 0.4f, 1f);

	private readonly Vector4 vector4_8 = new Vector4(0.9f, 0.2f, 0.3f, 1f);

	private readonly Vector4 vector4_9 = new Vector4(0.95f, 0.85f, 0.2f, 1f);

	private int int_0;

	private int int_1;

	private double double_1;

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

	private int Int32_1
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
		if (!bool_0 || gclass253_0 != null)
		{
			return;
		}
		try
		{
			EventSpammer gClass = default(EventSpammer);
			if (IoCManager.Resolve<IEntitySystemManager>().TryGetEntitySystem<EventSpammer>(ref gClass))
			{
				gclass253_0 = gClass;
			}
		}
		catch (Exception)
		{
		}
	}

	public void Render()
	{
		if (!bool_0)
		{
			return;
		}
		if (gclass253_0 == null)
		{
			try
			{
				EventSpammer gClass = default(EventSpammer);
				if (!IoCManager.Resolve<IEntitySystemManager>().TryGetEntitySystem<EventSpammer>(ref gClass))
				{
					return;
				}
				gclass253_0 = gClass;
			}
			catch (Exception)
			{
				return;
			}
		}
		try
		{
			ImGui.SetNextWindowSize(new Vector2(1400f, 550f), (ImGuiCond)4);
			ImGui.SetNextWindowPos(new Vector2(260f, 100f), (ImGuiCond)4);
			if (ImGui.Begin("Event Spammer", ref bool_0, (ImGuiWindowFlags)0))
			{
				DrawHeader();
				float num = 650f;
				float x = ImGui.GetContentRegionAvail().X - num - 8f;
				if (ImGui.BeginChild("LeftColumn", new Vector2(num, 0f)))
				{
					DrawControls();
					ImGui.Spacing();
					DrawLogs();
				}
				ImGui.EndChild();
				ImGui.SameLine();
				if (ImGui.BeginChild("RightColumn", new Vector2(x, 0f)))
				{
					DrawEventTypes();
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
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		ImDrawListPtr windowDrawList = ImGui.GetWindowDrawList();
		Vector2 cursorScreenPos = ImGui.GetCursorScreenPos();
		Vector2 vector = new Vector2(ImGui.GetContentRegionAvail().X, 35f);
		((ImDrawListPtr)(ref windowDrawList)).AddRectFilledMultiColor(cursorScreenPos, cursorScreenPos + vector, ImGui.GetColorU32(vector4_0 * 0.4f), ImGui.GetColorU32(vector4_1 * 0.4f), ImGui.GetColorU32(vector4_1 * 0.2f), ImGui.GetColorU32(vector4_0 * 0.2f));
		((ImDrawListPtr)(ref windowDrawList)).AddRect(cursorScreenPos, cursorScreenPos + vector, ImGui.GetColorU32(vector4_4), 6f, (ImDrawFlags)0, 1.2f);
		ImGui.SetCursorPosY(ImGui.GetCursorPosY() + 8f);
		ImGui.Indent(10f);
		List<EventLogEntry> logs = EventSpammer.GetLogs();
		int num = 0;
		int num2 = 0;
		foreach (EventLogEntry item in logs)
		{
			if (item.Status == "success")
			{
				num++;
			}
			else if (item.Status == "failed")
			{
				num2++;
			}
		}
		bool enabled = CerberusConfig.EventSpammer.Enabled;
		ImGui.PushStyleColor((ImGuiCol)0, (!enabled) ? vector4_6 : vector4_7);
		ImGui.Text(enabled ? "ACTIVE" : "INACTIVE");
		ImGui.PopStyleColor();
		ImGui.SameLine(ImGui.GetContentRegionAvail().X - 280f);
		ImGui.Text($"Total: {logs.Count}");
		ImGui.SameLine();
		ImGui.PushStyleColor((ImGuiCol)0, vector4_7);
		ImGui.Text($"OK: {num}");
		ImGui.PopStyleColor();
		ImGui.SameLine();
		ImGui.PushStyleColor((ImGuiCol)0, vector4_8);
		ImGui.Text($"FAIL: {num2}");
		ImGui.PopStyleColor();
		ImGui.Unindent(10f);
		ImGui.SetCursorPosY(ImGui.GetCursorPosY() + 8f);
	}

	private void DrawControls()
	{
		ImGui.Text("CONTROLS");
		ImGui.Separator();
		ImGui.PushStyleVar((ImGuiStyleVar)8, 1f);
		if (ImGui.BeginChild("ControlsSection", new Vector2(0f, 180f)))
		{
			bool enabled = CerberusConfig.EventSpammer.Enabled;
			if (ImGui.Button((!enabled) ? "DISABLED" : "ENABLED", new Vector2(-1f, 35f)))
			{
				CerberusConfig.EventSpammer.Enabled = !enabled;
				if (enabled || gclass253_0 == null)
				{
					if (enabled && gclass253_0 != null)
					{
						gclass253_0.StopEventSpam();
					}
				}
				else
				{
					gclass253_0.StartEventSpam();
				}
			}
			ImGui.Separator();
			ImGui.Columns(2, "TimingColumns", false);
			ImGui.Text("Timing");
			int minDelay = CerberusConfig.EventSpammer.MinDelay;
			ImGui.SetNextItemWidth(ImGui.GetContentRegionAvail().X - 8f);
			ImGui.SliderInt("Min (ms)", ref minDelay, 0, 500);
			CerberusConfig.EventSpammer.MinDelay = minDelay;
			int maxDelay = CerberusConfig.EventSpammer.MaxDelay;
			ImGui.SetNextItemWidth(ImGui.GetContentRegionAvail().X - 8f);
			ImGui.SliderInt("Max (ms)", ref maxDelay, 0, 1000);
			CerberusConfig.EventSpammer.MaxDelay = maxDelay;
			ImGui.NextColumn();
			ImGui.Text("Burst");
			bool burstMode = CerberusConfig.EventSpammer.BurstMode;
			if (ImGui.Checkbox("Burst Mode", ref burstMode))
			{
				CerberusConfig.EventSpammer.BurstMode = burstMode;
			}
			if (burstMode)
			{
				ImGui.Indent(8f);
				int burstSize = CerberusConfig.EventSpammer.BurstSize;
				ImGui.SetNextItemWidth(ImGui.GetContentRegionAvail().X - 8f);
				ImGui.SliderInt("Size", ref burstSize, 1, 20);
				CerberusConfig.EventSpammer.BurstSize = burstSize;
				ImGui.Unindent(8f);
			}
			bool parallelMode = CerberusConfig.EventSpammer.ParallelMode;
			if (ImGui.Checkbox("Parallel Mode", ref parallelMode))
			{
				CerberusConfig.EventSpammer.ParallelMode = parallelMode;
			}
			ImGui.Columns(1);
		}
		ImGui.EndChild();
		ImGui.PopStyleVar();
	}

	private void DrawEventTypes()
	{
		ImGui.Text("EVENT TYPES");
		ImGui.Separator();
		ImGui.PushStyleVar((ImGuiStyleVar)8, 1f);
		if (ImGui.BeginChild("EventTypesSection", new Vector2(0f, 0f)))
		{
			if (ImGui.CollapsingHeader("Interaction & Hands", (ImGuiTreeNodeFlags)32))
			{
				DrawEventItem("Interaction", ref CerberusConfig.EventSpammer.SpamInteraction, 0);
				DrawEventItem("Hand Activate", ref CerberusConfig.EventSpammer.SpamHandActivate, 1);
				DrawEventItem("Use", ref CerberusConfig.EventSpammer.SpamUse, 12);
				DrawEventItem("Throw", ref CerberusConfig.EventSpammer.SpamThrow, 13);
			}
			if (ImGui.CollapsingHeader("Items & Inventory", (ImGuiTreeNodeFlags)32))
			{
				DrawEventItem("Item Drop", ref CerberusConfig.EventSpammer.SpamItemDrop, 2);
				DrawEventItem("Item Pickup", ref CerberusConfig.EventSpammer.SpamItemPickup, 3);
				DrawEventItem("Equip", ref CerberusConfig.EventSpammer.SpamEquip, 14);
				DrawEventItem("Unequip", ref CerberusConfig.EventSpammer.SpamUnequip, 15);
				DrawEventItem("Wield", ref CerberusConfig.EventSpammer.SpamWield, 18);
			}
			if (ImGui.CollapsingHeader("Movement & Physics", (ImGuiTreeNodeFlags)32))
			{
				DrawEventItem("Move Input", ref CerberusConfig.EventSpammer.SpamMoveInput, 6);
				DrawEventItem("Sprint", ref CerberusConfig.EventSpammer.SpamSprint, 7);
				DrawEventItem("Crouch", ref CerberusConfig.EventSpammer.SpamCrouch, 8);
				DrawEventItem("Pull", ref CerberusConfig.EventSpammer.SpamPull, 4);
				DrawEventItem("Push", ref CerberusConfig.EventSpammer.SpamPush, 5);
			}
			if (ImGui.CollapsingHeader("Combat & Actions", (ImGuiTreeNodeFlags)32))
			{
				DrawEventItem("Attack", ref CerberusConfig.EventSpammer.SpamAttack, 11);
				DrawEventItem("Examine", ref CerberusConfig.EventSpammer.SpamExamine, 10);
				DrawEventItem("Verb", ref CerberusConfig.EventSpammer.SpamVerb, 9);
			}
			if (ImGui.CollapsingHeader("Storage & Containers", (ImGuiTreeNodeFlags)32))
			{
				DrawEventItem("Storage", ref CerberusConfig.EventSpammer.SpamStorage, 16);
				DrawEventItem("Container", ref CerberusConfig.EventSpammer.SpamContainer, 17);
			}
		}
		ImGui.EndChild();
		ImGui.PopStyleVar();
	}

	private void DrawEventItem(string label, ref bool value, int type)
	{
		ImGui.PushID(label);
		bool flag = value;
		ImGui.PushStyleColor((ImGuiCol)18, (!value) ? vector4_0 : vector4_7);
		ImGui.Checkbox("##checkbox_" + label, ref flag);
		ImGui.PopStyleColor();
		value = flag;
		ImGui.SameLine();
		ImGui.Text(label);
		float num = 60f;
		ImGui.SameLine(ImGui.GetContentRegionAvail().X - num + ImGui.GetCursorPosX());
		ImGui.PushStyleColor((ImGuiCol)21, vector4_0 * 0.6f);
		ImGui.PushStyleColor((ImGuiCol)22, vector4_0 * 0.8f);
		ImGui.PushStyleColor((ImGuiCol)23, vector4_0);
		if (ImGui.Button("Send##btn_" + label, new Vector2(num, 0f)))
		{
			gclass253_0?.SendSpecificEvent(type);
		}
		ImGui.PopStyleColor(3);
		ImGui.PopID();
	}

	private void DrawLogs()
	{
		ImGui.Text("LOGS");
		ImGui.Separator();
		ImGui.PushStyleVar((ImGuiStyleVar)8, 1f);
		if (ImGui.BeginChild("LogsSection", new Vector2(0f, 0f)))
		{
			if (ImGui.Button("Clear", new Vector2(80f, 22f)))
			{
				EventSpammer.ClearLogs();
			}
			ImGui.SameLine();
			List<EventLogEntry> logs = EventSpammer.GetLogs();
			ImGui.Text($"Total: {logs.Count}");
			ImGui.Separator();
			if (logs.Count != 0)
			{
				for (int num = logs.Count - 1; num >= 0; num--)
				{
					EventLogEntry gClass = logs[num];
					ImGui.Text(gClass.Status switch
					{
						"success" => "[OK]", 
						"failed" => "[FAIL]", 
						"sending" => "[...]", 
						_ => "[?]", 
					});
					ImGui.SameLine();
					ImGui.Text("[" + gClass.Timestamp + "] " + gClass.Type);
					if (!string.IsNullOrEmpty(gClass.Error))
					{
						ImGui.SameLine();
						ImGui.Text("- " + gClass.Error);
					}
				}
			}
			else
			{
				ImGui.Text("No events sent yet...");
			}
		}
		ImGui.EndChild();
		ImGui.PopStyleVar();
	}
}
