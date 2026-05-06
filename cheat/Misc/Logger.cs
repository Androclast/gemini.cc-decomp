using System;
using System.Reflection;
using System.Runtime.InteropServices;

public sealed class Logger
{
	[StructLayout(LayoutKind.Auto)]
	private struct Enum2 : Enum
	{
	}

	public delegate void Forward(AssemblyName asm, string message);

	private static object? object_0;

	private static MethodInfo? methodInfo_0;

	private static MethodInfo? methodInfo_1;

	private static MethodInfo? methodInfo_2;

	private static MethodInfo? methodInfo_3;

	public static Forward forward_0;

	private double double_0;

	private bool bool_0;

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

	static Logger()
	{
		try
		{
			Type type = Type.GetType("Robust.Shared.Log.Logger, Robust.Shared");
			if (!(type != null))
			{
				return;
			}
			MethodInfo method = type.GetMethod("GetSawmill", new Type[1] { typeof(string) });
			if (method != null)
			{
				object_0 = method.Invoke(null, new object[1] { "Kaban.cc" });
				if (object_0 != null)
				{
					Type type2 = object_0.GetType();
					methodInfo_0 = type2.GetMethod("Info", new Type[1] { typeof(string) });
					methodInfo_1 = type2.GetMethod("Warning", new Type[1] { typeof(string) });
					methodInfo_2 = type2.GetMethod("Error", new Type[1] { typeof(string) });
					methodInfo_3 = type2.GetMethod("Debug", new Type[1] { typeof(string) });
				}
			}
		}
		catch
		{
			object_0 = null;
		}
	}

	private static void Log(int type, string message)
	{
		//IL_0083: Expected O, but got I4
		try
		{
			if (object_0 != null)
			{
				switch (type)
				{
				case 3:
					methodInfo_3?.Invoke(object_0, new object[1] { message });
					break;
				case 2:
					methodInfo_2?.Invoke(object_0, new object[1] { message });
					break;
				case 0:
					methodInfo_0?.Invoke(object_0, new object[1] { message });
					break;
				case 1:
					methodInfo_1?.Invoke(object_0, new object[1] { message });
					break;
				}
			}
			else
			{
				Console.WriteLine($"[Kaban.cc][{(Enum2)(object)type}] {message}");
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("[Kaban.cc][LOG_ERROR] " + message + " | Exception: " + ex.Message);
		}
		Forward forward = forward_0;
		if (forward != null)
		{
			try
			{
				forward(Assembly.GetExecutingAssembly().GetName(), "[" + type + "] " + message);
			}
			catch
			{
			}
		}
	}

	public static void Info(string message)
	{
		Log(0, message);
	}

	public static void Warn(string message)
	{
		Log(1, message);
	}

	public static void Fatal(string message)
	{
		Log(2, message);
	}

	public static void Error(string message)
	{
		Log(2, message);
	}

	public static void Debug(string message)
	{
		Log(3, message);
	}
}
