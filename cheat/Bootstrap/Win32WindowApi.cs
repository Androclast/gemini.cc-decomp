using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[CompilerGenerated]
internal sealed class Win32WindowApi
{
	private int int_0;

	private bool bool_0;

	private char char_1;

	private byte byte_0;

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

	[DllImport("user32.dll", SetLastError = true)]
	public static extern nint WindowFromDC(nint hdc);

	[DllImport("user32.dll", SetLastError = true)]
	private static extern nint SetWindowLongPtrW(nint hWnd, int nIndex, nint dwNewLong);

	[DllImport("user32.dll", SetLastError = true)]
	private static extern nint SetWindowLongW(nint hWnd, int nIndex, nint dwNewLong);

	public static nint SetWindowLongPtr(nint hWnd, int nIndex, nint dwNewLong)
	{
		if (IntPtr.Size == 8)
		{
			return SetWindowLongPtrW(hWnd, nIndex, dwNewLong);
		}
		return SetWindowLongW(hWnd, nIndex, dwNewLong);
	}

	[DllImport("user32.dll")]
	public static extern nint GetWindowLongPtrW(nint hWnd, int nIndex);

	[DllImport("user32.dll")]
	public static extern nint CallWindowProc(nint lpPrevWndFunc, nint hWnd, uint Msg, nint wParam, nint lParam);

	[DllImport("user32.dll")]
	public static extern nint DefWindowProc(nint hWnd, uint uMsg, nint wParam, nint lParam);

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern nint LoadLibrary(string lpFileName);

	[DllImport("kernel32.dll", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FreeLibrary(nint hModule);

	private string method_5(long long_0)
	{
		return "Хитролох_иди_нахуй.__03____4__7__5_";
	}
}
