using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Win32;

namespace HwidProvider;

public sealed class HwidProvider
{
	private struct SYSTEM_INFO
	{
		public ushort tcbwYZGN2l;

		public uint N6pixXMAGW;

		public uint mRDi1PlJOG;

		public ushort kOLiadi3bZ;

		public ushort U4BiQrvrRB;
	}

	private byte byte_1;

	private byte byte_2;

	private byte Byte_0
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = value;
		}
	}

	private byte Byte_1
	{
		get
		{
			return byte_2;
		}
		set
		{
			byte_2 = value;
		}
	}

	[DllImport("kernel32.dll")]
	private static extern void GetSystemInfo(out SYSTEM_INFO lpSystemInfo);

	public static string GetOrCreateHWID()
	{
		return GenerateHWID();
	}

	private static string GenerateHWID()
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			string cPUIDInfo = GetCPUIDInfo();
			stringBuilder.Append("CPUID:");
			stringBuilder.Append(cPUIDInfo);
			stringBuilder.Append('|');
			GetSystemInfo(out var lpSystemInfo);
			stringBuilder.Append("ARCH:");
			stringBuilder.Append(lpSystemInfo.tcbwYZGN2l);
			stringBuilder.Append("|CORES:");
			stringBuilder.Append(lpSystemInfo.N6pixXMAGW);
			stringBuilder.Append("|TYPE:");
			stringBuilder.Append(lpSystemInfo.mRDi1PlJOG);
			stringBuilder.Append("|LEVEL:");
			stringBuilder.Append(lpSystemInfo.kOLiadi3bZ);
			stringBuilder.Append("|REV:");
			stringBuilder.Append(lpSystemInfo.U4BiQrvrRB);
			string machineGuid = GetMachineGuid();
			stringBuilder.Append("|GUID:");
			stringBuilder.Append(machineGuid);
			string text = stringBuilder.ToString();
			Logger.Info("[HWID] Raw: " + text);
			string text2 = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(text)));
			Logger.Info("[HWID] Generated: " + text2);
			return text2;
		}
		catch (Exception ex)
		{
			Logger.Error("[HWID] Error: " + ex.Message);
			string machineGuid2 = GetMachineGuid();
			return Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(machineGuid2)));
		}
	}

	private static string GetCPUIDInfo()
	{
		try
		{
			int processorCount = Environment.ProcessorCount;
			string value = RuntimeInformation.ProcessArchitecture.ToString();
			return $"{value}_{processorCount}";
		}
		catch
		{
			return "UNKNOWN_CPU";
		}
	}

	private static string GetMachineGuid()
	{
		try
		{
			using RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Cryptography");
			if (registryKey != null)
			{
				string text = registryKey.GetValue("MachineGuid")?.ToString();
				if (!string.IsNullOrWhiteSpace(text))
				{
					return text.ToUpperInvariant().Replace("-", "");
				}
			}
		}
		catch (Exception ex)
		{
			Logger.Debug("[HWID] MachineGuid error: " + ex.Message);
		}
		return Environment.MachineName.ToUpperInvariant();
	}
}
