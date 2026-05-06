using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace WatcherProcess;

public sealed class WatcherProcess
{
	private static Process process_0;

	private static bool bool_0;

	private static string string_0;

	private long long_2;

	private string string_1;

	private string string_2;

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

	private string String_1
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public static void StartWatcher()
	{
		try
		{
			int id = Process.GetCurrentProcess().Id;
			string_0 = $"KabanWatcher_{id}";
			string fileName = Process.GetCurrentProcess().MainModule.FileName;
			string arguments = $"--watcher {id}";
			process_0 = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = fileName,
					Arguments = arguments,
					UseShellExecute = false,
					CreateNoWindow = true
				}
			};
			process_0.Start();
			bool_0 = true;
			Task.Run(delegate
			{
				HeartbeatLoop();
			});
		}
		catch (Exception)
		{
		}
	}

	public static void StopWatcher()
	{
		try
		{
			bool_0 = false;
			if (process_0 != null && !process_0.HasExited)
			{
				process_0.Kill();
			}
		}
		catch (Exception)
		{
		}
	}

	public static bool IsWatcherAlive()
	{
		if (process_0 == null)
		{
			return false;
		}
		return !process_0.HasExited;
	}

	private static void HeartbeatLoop()
	{
		while (bool_0)
		{
			try
			{
				if (!IsWatcherAlive())
				{
					Environment.Exit(1);
				}
				Thread.Sleep(10000);
			}
			catch (Exception)
			{
			}
		}
	}

	public static void RunWatcherLoop(int mainProcessId)
	{
		try
		{
			Logger.Info($"[WatcherProcess] Monitoring process {mainProcessId}");
			while (true)
			{
				try
				{
					if (!Process.GetProcessById(mainProcessId).HasExited)
					{
						Thread.Sleep(10000);
						continue;
					}
					break;
				}
				catch
				{
					break;
				}
			}
		}
		catch (Exception)
		{
		}
	}
}
