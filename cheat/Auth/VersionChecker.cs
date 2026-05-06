using System;
using System.Threading;
using System.Threading.Tasks;
using TelemetryHttpClient;
using HwidProvider;

namespace VersionChecker;

public sealed class VersionChecker
{
	private static bool bool_0;

	private char char_0;

	private bool bool_2;

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

	public static void StartMonitoring()
	{
		if (bool_0)
		{
			return;
		}
		bool_0 = true;
		Thread thread = new Thread((ThreadStart)async delegate
		{
			if (await CheckVersionAsync())
			{
				do
				{
					await Task.Delay(300000);
				}
				while (await CheckVersionAsync());
				Logger.Fatal("[VersionChecker] ❌ VERSION OUTDATED DETECTED!");
				Logger.Fatal("[VersionChecker] ❌ A new version is available on the server");
				Logger.Fatal("[VersionChecker] ❌ Please restart and update");
				Logger.Fatal("[VersionChecker] ❌ Terminating...");
				try
				{
					await TelemetryHttpClient.SendSecurityEventAsync(HwidProvider.GetOrCreateHWID(), "outdated_version_detected", "Client version 1.0.0 is outdated", new
					{
						currentVersion = "1.0.0"
					});
				}
				catch
				{
				}
				Thread.Sleep(3000);
				Environment.Exit(1);
			}
			else
			{
				Logger.Fatal("[VersionChecker] ❌ VERSION CHECK FAILED!");
				Logger.Fatal("[VersionChecker] ❌ Your version is outdated or server is unavailable");
				Logger.Fatal("[VersionChecker] ❌ Please update to the latest version");
				Logger.Fatal("[VersionChecker] ❌ Terminating...");
				Thread.Sleep(3000);
				Environment.Exit(1);
			}
		});
		thread.IsBackground = true;
		thread.Priority = ThreadPriority.BelowNormal;
		thread.Start();
		Logger.Info("[VersionChecker] ✅ Monitoring started (async)");
	}

	private static async Task<bool> CheckVersionAsync()
	{
		try
		{
			string orCreateHWID = HwidProvider.GetOrCreateHWID();
			string apiUrl = "http://localhost:3001";
			if (!(await TelemetryHttpClient.CheckVersionAsync("1.0.0", orCreateHWID, apiUrl)).IsLatest)
			{
				return false;
			}
			return true;
		}
		catch (Exception)
		{
			return true;
		}
	}

	private string method_8(byte byte_0, string string_1)
	{
		return "Хитролох_иди_нахуй.__6_0____8___6____";
	}
}
