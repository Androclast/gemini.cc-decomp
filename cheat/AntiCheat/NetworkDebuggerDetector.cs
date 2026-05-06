using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using TelemetryHttpClient;
using HwidProvider;

namespace NetworkDebuggerDetector;

public sealed class NetworkDebuggerDetector
{
	[StructLayout(LayoutKind.Auto)]
	private struct Enum5 : Enum
	{
	}

	private struct MIB_TCPROW_OWNER_PID
	{
		public byte a14ik16DLv;

		public byte htpi3OUeTd;

		public byte jJmiwwsfFq;

		public byte seYiiWC2o2;

		public int x1Ti2559pO;

		private char char_0;

		private float float_0;

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

		private float Single_0
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
			}
		}

		[SpecialName]
		public ushort GuKi4e2CxO()
		{
			return (ushort)((a14ik16DLv << 8) + htpi3OUeTd);
		}

		[SpecialName]
		public ushort AHdiNVDwTg()
		{
			return (ushort)((jJmiwwsfFq << 8) + seYiiWC2o2);
		}
	}

	private struct MIB_TCPTABLE_OWNER_PID
	{
		public uint m0OiHoQkgV;
	}

	private static readonly HashSet<string> hashSet_0 = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
	{
		"rzappmanager", "razer", "synapse", "rzsynapse", "rzdeviceengine", "corsair", "icue", "logitech", "lghub", "logitechgaming",
		"steelseries", "sse3", "steelseriesengine", "aura", "armoury", "asus", "msi", "mysticlight", "dragon", "evga",
		"precision", "afterburner", "nvidia", "nvcontainer", "geforce", "shadowplay", "amd", "radeon", "adrenalin", "realtek",
		"nahimic", "sonic", "windows defender", "msmpeng", "antimalware", "kaspersky", "avast", "avg", "bitdefender", "norton",
		"svchost", "explorer", "dwm", "csrss", "lsass", "services", "taskhostw", "runtimebroker", "searchindexer", "steam",
		"epic", "origin", "uplay", "battlenet", "gog", "discord", "teamspeak", "mumble", "skype", "zoom",
		"chrome", "firefox", "edge", "opera", "brave"
	};

	private static readonly HashSet<string> hashSet_1 = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
	{
		"fiddler", "charles", "burpsuite", "burp", "burpsuite_pro", "burp-suite", "mitmproxy", "mitmweb", "mitmdump", "proxifier",
		"proxyman", "httpanalyzer", "httpwatch", "httpdebugger", "httptoolkit", "wireshark", "tshark", "tcpdump", "windump", "networkminer",
		"ettercap", "cain", "abel", "dsniff", "tcpview", "tcplogview", "paros", "zap", "zaproxy", "owasp",
		"owaspzap", "telerik", "postman", "insomnia", "hoppscotch", "burpcollaborator", "burp-collaborator", "bettercap", "responder", "mitmf",
		"sslstrip", "arpspoof", "dnsspoof", "nmap", "zenmap", "nessus", "metasploit", "charlesproxy", "fiddlereverywhere", "fiddler-everywhere",
		"proxyman-macos", "httpscoop", "paw", "rapidapi"
	};

	private static readonly int[] int_0 = new int[64]
	{
		8080, 8888, 8443, 3128, 1080, 9090, 8081, 8082, 8083, 8084,
		8000, 8001, 8002, 8003, 8004, 8005, 8006, 8007, 8008, 8009,
		3129, 3130, 9091, 9092, 9093, 9094, 9095, 9096, 9097, 9098,
		8080, 8081, 8082, 8083, 8084, 8085, 8888, 8889, 8866, 8877,
		8888, 8080, 8090, 8080, 8081, 3128, 3129, 3130, 1080, 1081,
		9050, 9051, 4444, 4445, 8180, 8181, 8182, 8183, 8184, 8185,
		8186, 8187, 8188, 8189
	};

	private static readonly HashSet<string> hashSet_2 = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
	{
		"wireshark", "tshark", "tcpdump", "windump", "networkminer", "ettercap", "cain", "abel", "dsniff", "arpspoof",
		"dnsspoof", "dumpcap", "sslstrip", "mitmf", "bettercap", "responder", "evilginx", "modlishka", "xerosploit", "mitmproxy",
		"mitmweb", "nmap", "zenmap", "masscan", "zmap", "angry-ip-scanner", "nessus", "openvas", "nexpose", "qualys",
		"acunetix", "metasploit", "msfconsole", "armitage", "cobalt-strike", "empire", "powersploit", "bloodhound", "crackmapexec", "tcpview",
		"tcplogview", "networkmonitor", "microsoft-message-analyzer", "fiddler-cap", "http-analyzer", "charles-proxy"
	};

	private static readonly HashSet<string> hashSet_3 = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "npf", "npcap", "winpcap", "packet.dll", "wpcap.dll" };

	private static readonly HashSet<string> hashSet_4 = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { ".pcap", ".pcapng", ".cap", ".dmp", ".5vw", ".acp", ".apc", ".atc" };

	private static readonly HashSet<int> hashSet_5 = new HashSet<int>();

	private static readonly object object_0 = new object();

	private static HashSet<int>? hashSet_6;

	private static DateTime dateTime_0 = DateTime.MinValue;

	private static readonly TimeSpan timeSpan_0 = TimeSpan.FromSeconds(5L);

	private byte byte_0;

	private char char_0;

	private float float_0;

	private int int_1;

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

	private float Single_0
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	private int Int32_0
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	[DllImport("iphlpapi.dll", SetLastError = true)]
	private static extern uint GetExtendedTcpTable(nint pTcpTable, ref int dwOutBufLen, bool sort, int ipVersion, Enum5 tblClass, int reserved);

	public static void StartMonitoring()
	{
		Thread thread = new Thread((ThreadStart)delegate
		{
			//IL_0068: Expected I8, but got I4
			Thread.Sleep(15000);
			while (true)
			{
				try
				{
					if (DetectNetworkDebuggers())
					{
						Console.WriteLine("[NetworkDebugger] ⚠\ufe0f NETWORK DEBUGGER DETECTED!");
						try
						{
							BootstrapHooks.SendSecurityScreenshot("Network Debugger Detected");
						}
						catch (Exception ex)
						{
							Console.WriteLine("[NetworkDebugger] Screenshot failed: " + ex.Message);
						}
						Task.Run(async delegate
						{
							try
							{
								await TelemetryHttpClient.SendSecurityEventAsync(HwidProvider.GetOrCreateHWID(), "network_debugger", "Network debugger detected", new
								{
									timestamp = DateTime.UtcNow
								});
								Console.WriteLine("[NetworkDebugger] Security alert sent");
							}
							catch (Exception ex3)
							{
								Console.WriteLine("[NetworkDebugger] Alert failed: " + ex3.Message);
							}
						}).Wait(TimeSpan.FromSeconds(3L));
						Console.WriteLine("[NetworkDebugger] Terminating process...");
						Environment.Exit(1);
					}
				}
				catch (Exception ex2)
				{
					Console.WriteLine("[NetworkDebugger] Monitoring error: " + ex2.Message);
				}
				Thread.Sleep(5000);
			}
		});
		thread.IsBackground = true;
		thread.Priority = ThreadPriority.BelowNormal;
		thread.Start();
		Console.WriteLine("[NetworkDebugger] ✅ Monitoring started (production mode)");
	}

	public static bool DetectNetworkDebuggers()
	{
		try
		{
			if (!CheckProxyProcesses())
			{
				if (!CheckProxyPorts())
				{
					if (CheckSystemProxy())
					{
						Logger.Warn("[NetworkDebugger] System proxy detected");
						return true;
					}
					if (CheckNetworkTools())
					{
						Logger.Warn("[NetworkDebugger] Network analysis tool detected");
						return true;
					}
					if (CheckProxyCertificates())
					{
						Logger.Warn("[NetworkDebugger] Proxy certificate detected");
						return true;
					}
					if (!CheckWiresharkDrivers())
					{
						if (!CheckPromiscuousMode())
						{
							if (!CheckPacketCaptureFiles())
							{
								return false;
							}
							Logger.Warn("[NetworkDebugger] Packet capture file detected");
							return true;
						}
						Logger.Warn("[NetworkDebugger] Network interface in promiscuous mode detected");
						return true;
					}
					Logger.Warn("[NetworkDebugger] Wireshark driver detected");
					return true;
				}
				Logger.Warn("[NetworkDebugger] Proxy port detected");
				return true;
			}
			Logger.Warn("[NetworkDebugger] Proxy process detected");
			return true;
		}
		catch (Exception ex)
		{
			Logger.Warn("[NetworkDebugger] Detection error: " + ex.Message);
			return false;
		}
	}

	private static bool CheckProxyProcesses()
	{
		bool result;
		try
		{
			Process[] processes = Process.GetProcesses();
			int num = 0;
			while (true)
			{
				if (num < processes.Length)
				{
					Process process = processes[num];
					try
					{
						int id = process.Id;
						string text = process.ProcessName.ToLower();
						bool flag = false;
						foreach (string item in hashSet_0)
						{
							if (text.Contains(item))
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							lock (object_0)
							{
								if (!hashSet_5.Contains(id))
								{
									goto end_IL_005d;
								}
								goto end_IL_0015;
								end_IL_005d:;
							}
							foreach (string item2 in hashSet_1)
							{
								if (text.Contains(item2))
								{
									Console.WriteLine($"[NetworkDebugger] Found proxy process: {process.ProcessName} (PID: {id})");
									result = true;
									goto end_IL_01c3;
								}
							}
							lock (object_0)
							{
								hashSet_5.Add(id);
							}
						}
						end_IL_0015:;
					}
					catch
					{
					}
					finally
					{
						process.Dispose();
					}
					num++;
					continue;
				}
				result = false;
				break;
				continue;
				end_IL_01c3:
				break;
			}
		}
		catch
		{
			result = false;
		}
		return result;
	}

	private static bool CheckProxyPorts()
	{
		try
		{
			int[] array;
			if (hashSet_6 == null || !(DateTime.UtcNow - dateTime_0 < timeSpan_0))
			{
				HashSet<int> hashSet = new HashSet<int>();
				IPEndPoint[] activeTcpListeners = IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpListeners();
				foreach (IPEndPoint iPEndPoint in activeTcpListeners)
				{
					hashSet.Add(iPEndPoint.Port);
				}
				hashSet_6 = hashSet;
				dateTime_0 = DateTime.UtcNow;
				array = int_0;
				foreach (int num in array)
				{
					if (hashSet.Contains(num))
					{
						Logger.Warn($"[NetworkDebugger] Proxy port detected: {num}");
						return true;
					}
				}
				return false;
			}
			array = int_0;
			foreach (int num2 in array)
			{
				if (hashSet_6.Contains(num2))
				{
					Logger.Warn($"[NetworkDebugger] Proxy port detected: {num2}");
					return true;
				}
			}
			return false;
		}
		catch
		{
			return false;
		}
	}

	private static bool CheckSystemProxy()
	{
		try
		{
			IWebProxy systemWebProxy = WebRequest.GetSystemWebProxy();
			Uri uri = new Uri("http://www.google.com");
			Uri proxy = systemWebProxy.GetProxy(uri);
			if (proxy != uri)
			{
				switch (proxy.Host.ToLower())
				{
				case "localhost":
				case "127.0.0.1":
				case "::1":
					return false;
				default:
					if (!new int[4] { 80, 443, 3128, 8080 }.Contains(proxy.Port))
					{
						Logger.Warn($"[NetworkDebugger] Suspicious proxy detected: {proxy}");
						return true;
					}
					Logger.Info($"[NetworkDebugger] Corporate proxy detected: {proxy} (ignored)");
					return false;
				}
			}
			return false;
		}
		catch
		{
			return false;
		}
	}

	private static bool CheckNetworkTools()
	{
		try
		{
			Process[] processes = Process.GetProcesses();
			foreach (Process process in processes)
			{
				try
				{
					string text = process.ProcessName.ToLower();
					foreach (string item in hashSet_2)
					{
						if (text.Contains(item))
						{
							Logger.Warn("[NetworkDebugger] Found network tool: " + process.ProcessName);
							return true;
						}
					}
				}
				catch
				{
				}
				finally
				{
					process.Dispose();
				}
			}
			return false;
		}
		catch
		{
			return false;
		}
	}

	private static bool CheckProxyCertificates()
	{
		try
		{
			X509Store x509Store = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
			x509Store.Open(OpenFlags.ReadOnly);
			string[] array = new string[22]
			{
				"DO_NOT_TRUST_FiddlerRoot", "FiddlerRoot", "Fiddler", "Telerik Fiddler", "Charles Proxy", "Charles SSL Proxying", "Charles Web Debugging Proxy", "Burp Suite", "PortSwigger", "Burp CA",
				"BurpSuite", "mitmproxy", "mitmproxy CA", "OWASP ZAP", "ZAP Root CA", "Zed Attack Proxy", "Proxifier", "Paros", "HTTP Toolkit", "Proxyman",
				"Fiddler Everywhere", "Charles Root Certificate"
			};
			foreach (X509Certificate2 certificate in x509Store.Certificates)
			{
				string text = certificate.Issuer.ToLower();
				string text2 = certificate.Subject.ToLower();
				string[] array2 = array;
				foreach (string text3 in array2)
				{
					if (text.Contains(text3.ToLower()) || text2.Contains(text3.ToLower()))
					{
						Console.WriteLine("[NetworkDebugger] Found proxy certificate: " + certificate.Subject);
						x509Store.Close();
						return true;
					}
				}
			}
			x509Store.Close();
			return false;
		}
		catch
		{
			return false;
		}
	}

	private static bool CheckWiresharkDrivers()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		try
		{
			bool flag = false;
			try
			{
				Process[] processes = Process.GetProcesses();
				foreach (Process process in processes)
				{
					try
					{
						string text = process.ProcessName.ToLower();
						if (!text.Contains("wireshark") && !text.Contains("tshark") && !text.Contains("dumpcap"))
						{
							continue;
						}
						flag = true;
						break;
					}
					catch
					{
					}
				}
			}
			catch
			{
			}
			if (flag)
			{
				ManagementObjectSearcher val = new ManagementObjectSearcher("SELECT * FROM Win32_SystemDriver");
				try
				{
					ManagementObjectEnumerator enumerator = val.Get().GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							ManagementBaseObject current = enumerator.Current;
							object obj3 = current["Name"];
							object obj4;
							if (obj3 != null)
							{
								string? text2 = obj3.ToString();
								if (text2 == null)
								{
									obj4 = null;
								}
								else
								{
									obj4 = text2.ToLower();
									if (obj4 != null)
									{
										goto IL_005c;
									}
								}
							}
							else
							{
								obj4 = null;
							}
							obj4 = "";
							goto IL_005c;
							IL_005c:
							string text3 = (string)obj4;
							object obj5 = current["DisplayName"];
							object obj6;
							if (obj5 == null)
							{
								obj6 = null;
							}
							else
							{
								string? text4 = obj5.ToString();
								if (text4 != null)
								{
									obj6 = text4.ToLower();
									if (obj6 != null)
									{
										goto IL_0078;
									}
								}
								else
								{
									obj6 = null;
								}
							}
							obj6 = "";
							goto IL_0078;
							IL_0078:
							string text5 = (string)obj6;
							foreach (string item in hashSet_3)
							{
								if (text3.Contains(item) || text5.Contains(item))
								{
									Logger.Warn($"[NetworkDebugger] Wireshark is running with driver: {current["DisplayName"]}");
									return true;
								}
							}
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
				}
				finally
				{
					((IDisposable)val)?.Dispose();
				}
				return false;
			}
			return false;
		}
		catch (Exception ex)
		{
			Logger.Warn("[NetworkDebugger] Error checking Wireshark drivers: " + ex.Message);
			return false;
		}
	}

	private static bool CheckPromiscuousMode()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		try
		{
			ManagementObjectSearcher val = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapter WHERE NetEnabled = TRUE");
			try
			{
				ManagementObjectEnumerator enumerator = val.Get().GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						ManagementBaseObject current = enumerator.Current;
						object obj = current["Name"];
						object obj2;
						object obj3;
						if (obj != null)
						{
							string? text = obj.ToString();
							if (text != null)
							{
								obj2 = text.ToLower() ?? "";
								goto IL_004a;
							}
							obj3 = null;
						}
						else
						{
							obj3 = null;
						}
						obj2 = "";
						goto IL_004a;
						IL_004a:
						string text2 = (string)obj2;
						if (text2.Contains("npcap") || text2.Contains("winpcap") || text2.Contains("loopback capture"))
						{
							Logger.Warn($"[NetworkDebugger] Found packet capture adapter: {current["Name"]}");
							return true;
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			return false;
		}
		catch (Exception ex)
		{
			Logger.Warn("[NetworkDebugger] Error checking promiscuous mode: " + ex.Message);
			return false;
		}
	}

	private static bool CheckPacketCaptureFiles()
	{
		try
		{
			string[] array = new string[4]
			{
				Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
				Environment.GetFolderPath(Environment.SpecialFolder.Personal),
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads"),
				Path.GetTempPath()
			};
			foreach (string path in array)
			{
				if (!Directory.Exists(path))
				{
					continue;
				}
				try
				{
					string[] files = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly);
					foreach (string text in files)
					{
						string item = Path.GetExtension(text).ToLower();
						if (hashSet_4.Contains(item))
						{
							FileInfo fileInfo = new FileInfo(text);
							if ((DateTime.Now - fileInfo.CreationTime).TotalHours < 24.0)
							{
								Logger.Warn("[NetworkDebugger] Found recent packet capture file: " + text);
								return true;
							}
						}
					}
				}
				catch
				{
				}
			}
			return false;
		}
		catch (Exception ex)
		{
			Logger.Warn("[NetworkDebugger] Error checking packet capture files: " + ex.Message);
			return false;
		}
	}

	public static bool CheckSuspiciousConnections()
	{
		//IL_0026: Expected O, but got I4
		//IL_004a: Expected O, but got I4
		try
		{
			int dwOutBufLen = 0;
			GetExtendedTcpTable(IntPtr.Zero, ref dwOutBufLen, sort: true, 2, (Enum5)5, 0);
			nint num = Marshal.AllocHGlobal(dwOutBufLen);
			try
			{
				if (GetExtendedTcpTable(num, ref dwOutBufLen, sort: true, 2, (Enum5)5, 0) == 0)
				{
					MIB_TCPTABLE_OWNER_PID mIB_TCPTABLE_OWNER_PID = (MIB_TCPTABLE_OWNER_PID)Marshal.PtrToStructure(num, typeof(MIB_TCPTABLE_OWNER_PID));
					nint num2 = (nint)((long)num + (long)Marshal.SizeOf(mIB_TCPTABLE_OWNER_PID.m0OiHoQkgV));
					int id = Process.GetCurrentProcess().Id;
					for (int i = 0; i < mIB_TCPTABLE_OWNER_PID.m0OiHoQkgV; i++)
					{
						MIB_TCPROW_OWNER_PID mIB_TCPROW_OWNER_PID = (MIB_TCPROW_OWNER_PID)Marshal.PtrToStructure(num2, typeof(MIB_TCPROW_OWNER_PID));
						if (mIB_TCPROW_OWNER_PID.x1Ti2559pO != id || !int_0.Contains(mIB_TCPROW_OWNER_PID.AHdiNVDwTg()))
						{
							num2 = (nint)((long)num2 + (long)Marshal.SizeOf(typeof(MIB_TCPROW_OWNER_PID)));
							continue;
						}
						Logger.Warn($"[NetworkDebugger] Our process connected through proxy port: {mIB_TCPROW_OWNER_PID.AHdiNVDwTg()}");
						return true;
					}
					return false;
				}
				return false;
			}
			finally
			{
				Marshal.FreeHGlobal(num);
			}
		}
		catch
		{
			return false;
		}
	}
}
