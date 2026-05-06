using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using PeHeaderEraser;

namespace PeHeaderRestoreDetector;

public sealed class PeHeaderRestoreDetector
{
	private static bool bool_0;

	[CompilerGenerated]
	private static Action action_0;

	private bool bool_2;

	private double double_0;

	private bool Boolean_0
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

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

	public static event Action Event_0
	{
		[CompilerGenerated]
		add
		{
			Action action = action_0;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = action_0;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public static void StartMonitoring()
	{
		if (!bool_0)
		{
			bool_0 = true;
			Task.Run(delegate
			{
				MonitoringLoop();
			});
			Logger.Info("[MemoryProtector] Monitoring started (using ThreadPool)");
		}
	}

	public static void StopMonitoring()
	{
		bool_0 = false;
		Logger.Info("[MemoryProtector] Monitoring stopped");
	}

	private static void MonitoringLoop()
	{
		while (bool_0)
		{
			try
			{
				if (CheckHeaderRestoration())
				{
					Logger.Fatal("[MemoryProtector] PE header restoration detected!");
					action_0?.Invoke();
					Environment.Exit(1);
				}
				Thread.Sleep(10000);
			}
			catch (Exception ex)
			{
				Logger.Error("[MemoryProtector] Monitoring error: " + ex.Message);
			}
		}
	}

	private static bool CheckHeaderRestoration()
	{
		try
		{
			nint moduleBase = PeHeaderEraser.GetModuleBase();
			if (moduleBase != IntPtr.Zero)
			{
				if (CheckDOSHeaderRestoration(moduleBase))
				{
					return true;
				}
				if (CheckPESignatureRestoration(moduleBase))
				{
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

	private static bool CheckDOSHeaderRestoration(nint moduleBase)
	{
		try
		{
			byte[] array = new byte[2];
			try
			{
				Marshal.Copy(moduleBase, array, 0, 2);
			}
			catch
			{
				return false;
			}
			if (array[0] != 77 || array[1] != 90)
			{
				bool flag = false;
				byte[] array2 = new byte[64];
				try
				{
					Marshal.Copy(moduleBase, array2, 0, 64);
					byte[] array3 = array2;
					for (int i = 0; i < array3.Length; i++)
					{
						if (array3[i] != 0)
						{
							flag = true;
							break;
						}
					}
				}
				catch
				{
					return false;
				}
				if (!flag)
				{
					return false;
				}
				Logger.Warn("[MemoryProtector] Partial DOS header restoration detected");
				return true;
			}
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	private static bool CheckPESignatureRestoration(nint moduleBase)
	{
		try
		{
			nint ptr = IntPtr.Add(moduleBase, 60);
			int num;
			try
			{
				num = Marshal.ReadInt32(ptr);
			}
			catch
			{
				return false;
			}
			if (num != 0 && num < 1024)
			{
				nint source = IntPtr.Add(moduleBase, num);
				byte[] array = new byte[4];
				try
				{
					Marshal.Copy(source, array, 0, 4);
				}
				catch
				{
					return false;
				}
				if (array[0] == 80 && array[1] == 69 && array[2] == 0 && array[3] == 0)
				{
					return true;
				}
			}
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}
}
