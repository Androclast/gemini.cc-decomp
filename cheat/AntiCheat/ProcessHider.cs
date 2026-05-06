using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ProcessHider;

public sealed class ProcessHider
{
	private static bool bool_0;

	private float float_1;

	private char char_0;

	private float float_2;

	private string string_1;

	private float Single_0
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
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

	private float Single_1
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

	[DllImport("ntdll.dll")]
	private static extern int NtSetInformationProcess(nint processHandle, int processInformationClass, ref int processInformation, int processInformationLength);

	[DllImport("user32.dll")]
	private static extern bool SetWindowDisplayAffinity(nint hwnd, uint dwAffinity);

	[DllImport("kernel32.dll")]
	private static extern nint GetCurrentProcess();

	public static void Initialize()
	{
		try
		{
			HideFromTaskManager();
			HideFromDumpers();
		}
		catch (Exception)
		{
		}
	}

	public static bool HideFromProcessExplorer()
	{
		return false;
	}

	public static void Cleanup()
	{
		if (!bool_0)
		{
			return;
		}
		try
		{
			nint currentProcess = GetCurrentProcess();
			int processInformation = 0;
			if (NtSetInformationProcess(currentProcess, 29, ref processInformation, 4) == 0)
			{
				bool_0 = false;
			}
		}
		catch (Exception)
		{
		}
	}

	public static bool HideFromTaskManager()
	{
		try
		{
			nint mainWindowHandle = Process.GetCurrentProcess().MainWindowHandle;
			if (mainWindowHandle == IntPtr.Zero || !SetWindowDisplayAffinity(mainWindowHandle, 1u))
			{
				return false;
			}
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public static bool HideFromDumpers()
	{
		try
		{
			Logger.Info("[ProcessHider] Applying anti-dumper protections");
			return true;
		}
		catch (Exception ex)
		{
			Logger.Error("[ProcessHider] HideFromDumpers failed: " + ex.Message);
			return false;
		}
	}
}
