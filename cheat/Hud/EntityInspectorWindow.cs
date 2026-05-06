using System;
using System.Numerics;
using CerberusWareV3.MyImGui;
using Hexa.NET.ImGui;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using PacketSpammer;
using CerberusConfig;

namespace EntityInspectorWindow;

public sealed class EntityInspectorWindow : IOverlay
{
	private PacketSpammer? gclass260_0;

	private long long_0;

	private bool bool_0;

	private int int_0;

	private double double_1;

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

	private bool Boolean_0
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
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

	public void Render()
	{
		try
		{
			if (ImGui.Begin("Packet Spammer TEST", (ImGuiWindowFlags)64))
			{
				ImGui.Text("TEST WINDOW - If you see this, overlay works!");
				if (gclass260_0 != null)
				{
					ImGui.TextColored(new Vector4(0f, 1f, 0f, 1f), "System: OK!");
				}
				else
				{
					try
					{
						IEntitySystemManager val = IoCManager.Resolve<IEntitySystemManager>();
						gclass260_0 = val.GetEntitySystem<PacketSpammer>();
						ImGui.Text("System: Getting...");
					}
					catch (Exception ex)
					{
						ImGui.TextColored(new Vector4(1f, 0f, 0f, 1f), "Error: " + ex.Message);
					}
				}
				ImGui.Separator();
				bool enabled = CerberusConfig.PacketSpammer.Enabled;
				ImGui.Text("Status: " + (enabled ? "RUNNING" : "STOPPED"));
				if (ImGui.Button(enabled ? "STOP" : "START", new Vector2(200f, 40f)))
				{
					CerberusConfig.PacketSpammer.Enabled = !enabled;
					if (enabled)
					{
						gclass260_0?.StopPacketSpam();
					}
					else
					{
						gclass260_0?.StartPacketSpam();
					}
				}
				ImGui.End();
			}
			else
			{
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
