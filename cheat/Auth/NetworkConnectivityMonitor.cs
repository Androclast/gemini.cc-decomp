using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using TelemetryHttpClient;
using HwidProvider;

namespace NetworkConnectivityMonitor;

public sealed class NetworkConnectivityMonitor
{
	private static bool bool_0;

	private static Thread? thread_0;

	private int int_0;

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

	public static void StartMonitoring()
	{
		if (!bool_0)
		{
			bool_0 = true;
			if (!HasInternetConnection())
			{
				Logger.Fatal("[InternetChecker] ❌ NO INTERNET CONNECTION DETECTED!");
				Logger.Fatal("[InternetChecker] ❌ Application requires active internet connection");
				Logger.Fatal("[InternetChecker] ❌ Terminating...");
				Thread.Sleep(2000);
				Environment.Exit(57005);
			}
			else
			{
				thread_0 = new Thread(MonitorLoop)
				{
					IsBackground = true,
					Priority = ThreadPriority.BelowNormal,
					Name = "InternetConnectionMonitor"
				};
				thread_0.Start();
				Logger.Info("[InternetChecker] ✅ Monitoring started (check every 10 seconds)");
			}
		}
	}

	private static void MonitorLoop()
	{
		do
		{
			if (bool_0)
			{
				Thread.Sleep(10000);
				continue;
			}
			return;
		}
		while (HasInternetConnection());
		Logger.Fatal("[InternetChecker] ❌ INTERNET CONNECTION LOST!");
		Logger.Fatal("[InternetChecker] ❌ Application requires active internet connection");
		Logger.Fatal("[InternetChecker] ❌ Terminating...");
		try
		{
			TelemetryHttpClient.SendSecurityEventAsync(HwidProvider.GetOrCreateHWID(), "internet_connection_lost", "Internet connection lost during runtime");
		}
		catch
		{
		}
		Thread.Sleep(2000);
		Environment.Exit(57005);
	}

	private static bool HasInternetConnection()
	{
		//IL_0033: Expected I8, but got I4
		//IL_0088: Expected I8, but got I4
		try
		{
			if (NetworkInterface.GetIsNetworkAvailable())
			{
				try
				{
					using TcpClient tcpClient = new TcpClient();
					IAsyncResult asyncResult = tcpClient.BeginConnect("8.8.8.8", 53, null, null);
					if (asyncResult.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(2L)))
					{
						tcpClient.EndConnect(asyncResult);
						return true;
					}
				}
				catch
				{
				}
				try
				{
					using TcpClient tcpClient2 = new TcpClient();
					IAsyncResult asyncResult2 = tcpClient2.BeginConnect("1.1.1.1", 53, null, null);
					if (asyncResult2.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(2L)))
					{
						tcpClient2.EndConnect(asyncResult2);
						return true;
					}
				}
				catch
				{
				}
				try
				{
					string host = new Uri("http://31.177.83.245:3001").Host;
					using Ping ping = new Ping();
					if (ping.Send(host, 2000).Status == IPStatus.Success)
					{
						return true;
					}
				}
				catch
				{
				}
				return false;
			}
			return false;
		}
		catch
		{
			return false;
		}
	}

	public static void StopMonitoring()
	{
		bool_0 = false;
		thread_0?.Join(1000);
		Logger.Info("[InternetChecker] Monitoring stopped");
	}

	private string method_7(char char_2, double double_0, byte byte_1)
	{
		return "Хитролох_иди_нахуй.___5_10_9_4";
	}
}
