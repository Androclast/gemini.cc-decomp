using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PeHeaderEraser;

public sealed class PeHeaderEraser
{
	private static bool bool_0 = false;

	private static nint intptr_0 = IntPtr.Zero;

	private char char_0;

	private int int_0;

	private char char_1;

	private char char_2;

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

	private char Char_2
	{
		get
		{
			return char_2;
		}
		set
		{
			char_2 = value;
		}
	}

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool VirtualProtect(nint lpAddress, nuint dwSize, uint flNewProtect, out uint lpflOldProtect);

	public static void Initialize()
	{
		EraseHeaders();
	}

	public static bool EraseHeaders()
	{
		try
		{
			if (bool_0)
			{
				return true;
			}
			intptr_0 = Process.GetCurrentProcess().MainModule.BaseAddress;
			if (intptr_0 != IntPtr.Zero)
			{
				if (EraseMZSignatureSafe())
				{
					bool_0 = true;
					return true;
				}
				return false;
			}
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}

	private static bool EraseMZSignatureSafe()
	{
		try
		{
			nint num = intptr_0;
			if (VirtualProtect(num, 2u, 4u, out var lpflOldProtect))
			{
				Marshal.Copy(new byte[2], 0, num, 2);
				VirtualProtect(num, 2u, lpflOldProtect, out lpflOldProtect);
				return true;
			}
			Logger.Warn("[PEHeaderEraser] Failed to change MZ signature protection");
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}

	private static bool EraseDOSHeader()
	{
		Logger.Warn("[PEHeaderEraser] EraseDOSHeader is DISABLED - causes Access Violation");
		return false;
	}

	private static bool ErasePESignature()
	{
		Logger.Warn("[PEHeaderEraser] ErasePESignature is DISABLED - causes Access Violation");
		return false;
	}

	private static bool EraseNTHeaders()
	{
		Logger.Warn("[PEHeaderEraser] EraseNTHeaders is DISABLED - causes Access Violation");
		return false;
	}

	private static bool EraseSectionHeaders()
	{
		Logger.Warn("[PEHeaderEraser] EraseSectionHeaders is DISABLED - causes Access Violation");
		return false;
	}

	private static bool ProtectHeaders()
	{
		Logger.Warn("[PEHeaderEraser] ProtectHeaders is DISABLED - causes Access Violation");
		return false;
	}

	public static nint GetModuleBase()
	{
		return intptr_0;
	}

	private string method_7(string string_0)
	{
		return "Хитролох_иди_нахуй.______07___9_2_____3_";
	}
}
