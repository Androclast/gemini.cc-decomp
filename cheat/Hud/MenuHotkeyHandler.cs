using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Robust.Shared.GameObjects;
using CerberusConfig;

[CompilerGenerated]
public class MenuHotkeyHandler : EntitySystem
{
	private bool bool_0;

	private float float_0;

	private byte byte_1;

	private char char_0;

	private long long_1;

	private string string_1;

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
			return long_1;
		}
		set
		{
			long_1 = value;
		}
	}

	private string String_0
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public override void Update(float frameTime)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		float_0 += frameTime;
		if (float_0 >= 0.05f)
		{
			float_0 = 0f;
			if ((int)CerberusConfig.Settings.ShowMenuHotKey != 0)
			{
				HandleMenuHotkey();
			}
		}
	}

	private void HandleMenuHotkey()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		bool flag = KeyStateHelper.IsKeyDown(CerberusConfig.Settings.ShowMenuHotKey);
		if (flag && !bool_0)
		{
			ToggleMenuWindow();
		}
		bool_0 = flag;
	}

	private void ToggleMenuWindow()
	{
		try
		{
			if (WinFormsMenuWindow.Instance == null)
			{
				return;
			}
			((Control)WinFormsMenuWindow.Instance).BeginInvoke((Delegate)(Action)delegate
			{
				try
				{
					if (!((Control)WinFormsMenuWindow.Instance).Visible)
					{
						((Control)WinFormsMenuWindow.Instance).Show();
					}
					else
					{
						((Control)WinFormsMenuWindow.Instance).Hide();
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
}
