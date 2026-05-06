using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Hexa.NET.ImGui;

public sealed class KeyStateHelper
{
	private bool bool_0;

	private float float_0;

	private int int_1;

	private string string_0;

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

	private int Int32_0
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

	[DllImport("user32.dll")]
	private static extern short GetAsyncKeyState(int vKey);

	[DllImport("user32.dll")]
	private static extern nint GetForegroundWindow();

	[DllImport("user32.dll")]
	private static extern uint GetWindowThreadProcessId(nint hWnd, out uint lpdwProcessId);

	public static bool IsGameWindowFocused()
	{
		try
		{
			nint foregroundWindow = GetForegroundWindow();
			if (foregroundWindow != IntPtr.Zero)
			{
				GetWindowThreadProcessId(foregroundWindow, out var lpdwProcessId);
				return lpdwProcessId == (uint)Process.GetCurrentProcess().Id;
			}
			return false;
		}
		catch
		{
			return true;
		}
	}

	public static bool IsKeyDown(ImGuiKey key)
	{
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected I4, but got Unknown
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected I4, but got Unknown
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Invalid comparison between Unknown and I4
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Invalid comparison between Unknown and I4
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Invalid comparison between Unknown and I4
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Invalid comparison between Unknown and I4
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected I4, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected I4, but got Unknown
		if (!IsGameWindowFocused())
		{
			return false;
		}
		int num = 0;
		if ((int)key == 0)
		{
			return false;
		}
		switch (key - 512)
		{
		case 5:
			num = 33;
			break;
		case 16:
			num = 160;
			break;
		case 12:
			num = 32;
			break;
		case 13:
			num = 13;
			break;
		case 9:
			num = 45;
			break;
		case 4:
			num = 40;
			break;
		case 0:
			num = 9;
			break;
		case 17:
			num = 164;
			break;
		case 11:
			num = 8;
			break;
		case 1:
			num = 37;
			break;
		case 15:
			num = 162;
			break;
		case 14:
			num = 27;
			break;
		case 6:
			num = 34;
			break;
		case 10:
			num = 46;
			break;
		default:
			switch (key - 656)
			{
			case 1:
				num = 2;
				break;
			case 4:
				num = 6;
				break;
			case 0:
				num = 1;
				break;
			case 3:
				num = 5;
				break;
			default:
				if ((int)key >= 546 && (int)key <= 571)
				{
					num = key - 546 + 65;
				}
				else if ((int)key >= 536 && (int)key <= 545)
				{
					num = key - 536 + 48;
				}
				break;
			case 2:
				num = 4;
				break;
			}
			break;
		case 8:
			num = 35;
			break;
		case 3:
			num = 38;
			break;
		case 2:
			num = 39;
			break;
		case 7:
			num = 36;
			break;
		}
		if (num != 0)
		{
			return (GetAsyncKeyState(num) & 0x8000) != 0;
		}
		return false;
	}
}
