using System;
using System.Text;
using Хитролох_иди_нахуй;

internal class ObfuscatorJunkAttribute
{
	internal class UDeI7RWk9e8HZbAF57 : Attribute
	{
		internal class TlgJaUaQEO0K1skGJY<T>
		{
			private char char_0;

			private long long_0;

			private bool bool_0;

			private byte byte_0;

			private char Char_0
			{
				get
				{
					return ((TlgJaUaQEO0K1skGJY<>)(object)this).char_0;
				}
				set
				{
					((TlgJaUaQEO0K1skGJY<>)(object)this).char_0 = value;
				}
			}

			private long Int64_0
			{
				get
				{
					return ((TlgJaUaQEO0K1skGJY<>)(object)this).long_0;
				}
				set
				{
					((TlgJaUaQEO0K1skGJY<>)(object)this).long_0 = value;
				}
			}

			private bool Boolean_0
			{
				get
				{
					return ((TlgJaUaQEO0K1skGJY<>)(object)this).bool_0;
				}
				set
				{
					((TlgJaUaQEO0K1skGJY<>)(object)this).bool_0 = value;
				}
			}

			private byte Byte_0
			{
				get
				{
					return ((TlgJaUaQEO0K1skGJY<>)(object)this).byte_0;
				}
				set
				{
					((TlgJaUaQEO0K1skGJY<>)(object)this).byte_0 = value;
				}
			}

			public TlgJaUaQEO0K1skGJY()
			{
				TlgJaUaQEO0K1skGJY<T>.smethod_0();
				base._002Ector();
				if (TlgJaUaQEO0K1skGJY<T>.smethod_1(907700666) == 0)
				{
				}
			}
		}

		private byte byte_0;

		private string string_0;

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

		private string String_0
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		[UDeI7RWk9e8HZbAF57(typeof(TlgJaUaQEO0K1skGJY<object>[]))]
		public UDeI7RWk9e8HZbAF57(object M448gdJtBGnIC5sjsy)
		{
		}
	}

	private static byte[] byte_0;

	private byte[] M448gdJtBGnIC5sjsy;

	private byte[] aIjvxlZbyG3o15igbU;

	private int int_1;

	private float float_1;

	private double double_0;

	private float float_2;

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

	static ObfuscatorJunkAttribute()
	{
		byte_0 = new byte[0];
	}

	private ObfuscatorJunkAttribute()
	{
	}

	private ObfuscatorJunkAttribute(byte[] M448gdJtBGnIC5sjsy, byte[] aIjvxlZbyG3o15igbU)
	{
		this.M448gdJtBGnIC5sjsy = M448gdJtBGnIC5sjsy;
		this.aIjvxlZbyG3o15igbU = aIjvxlZbyG3o15igbU;
	}

	private byte[] lgXZQJyjKotW8pE105(byte[] M448gdJtBGnIC5sjsy)
	{
		if (M448gdJtBGnIC5sjsy.Length != 0)
		{
			int num = M448gdJtBGnIC5sjsy.Length % 4;
			int num2 = M448gdJtBGnIC5sjsy.Length / 4;
			byte[] array = new byte[M448gdJtBGnIC5sjsy.Length];
			int num3 = this.M448gdJtBGnIC5sjsy.Length / 4;
			uint num4 = 0u;
			uint num5 = 0u;
			uint num6 = 0u;
			if (num > 0)
			{
				num2++;
			}
			uint num7 = 0u;
			for (int i = 0; i < num2; i++)
			{
				int num8 = i % num3;
				int num9 = i * 4;
				num7 = (uint)(num8 * 4);
				num5 = (uint)((this.M448gdJtBGnIC5sjsy[num7 + 3] << 24) | (this.M448gdJtBGnIC5sjsy[num7 + 2] << 16) | (this.M448gdJtBGnIC5sjsy[num7 + 1] << 8) | this.M448gdJtBGnIC5sjsy[num7]);
				if (i != num2 - 1 || num <= 0)
				{
					num7 = (uint)num9;
					num6 = (uint)((M448gdJtBGnIC5sjsy[num7 + 3] << 24) | (M448gdJtBGnIC5sjsy[num7 + 2] << 16) | (M448gdJtBGnIC5sjsy[num7 + 1] << 8) | M448gdJtBGnIC5sjsy[num7]);
					num4 += num5;
					num4 += rflFGid8pAjvGSRT1s(num4);
					uint num10 = num4 ^ num6;
					array[num9] = (byte)(num10 & 0xFF);
					array[num9 + 1] = (byte)((num10 & 0xFF00) >> 8);
					array[num9 + 2] = (byte)((num10 & 0xFF0000) >> 16);
					array[num9 + 3] = (byte)((num10 & 0xFF000000u) >> 24);
					continue;
				}
				num6 = 0u;
				uint num11 = 255u;
				int num12 = 0;
				for (int j = 0; j < num; j++)
				{
					if (j > 0)
					{
						num6 <<= 8;
					}
					num6 |= M448gdJtBGnIC5sjsy[^(1 + j)];
				}
				num4 += num5;
				num4 += rflFGid8pAjvGSRT1s(num4);
				uint num13 = num4 ^ num6;
				for (int k = 0; k < num; k++)
				{
					if (k > 0)
					{
						num11 <<= 8;
						num12 += 8;
					}
					array[num9 + k] = (byte)((num13 & num11) >> num12);
				}
			}
			return array;
		}
		return new byte[0];
	}

	private uint rflFGid8pAjvGSRT1s(uint M448gdJtBGnIC5sjsy)
	{
		uint num = M448gdJtBGnIC5sjsy;
		uint num2 = 973202305u;
		uint num3 = 1582787682u;
		uint num4 = 1577548636u;
		uint num5 = 332884210u;
		ulong num6 = num4 * 1313243236;
		num6 |= 1;
		num3 = (uint)(num3 * num3 % num6);
		ulong num7 = 1907532890 * num4;
		if (num7 == 0L)
		{
			num7--;
		}
		_ = 698203908u % num7;
		num2 = (uint)(-502326134 - num3);
		ulong num8 = num3 * 183835789;
		num8 |= 1;
		num4 = (uint)(num4 * num4 % num8);
		uint num9 = ((num5 >> 6) | (num5 << 26)) ^ num3;
		uint num10 = num9 & 0xF0F0F0F;
		num5 = ((num9 & 0xF0F0F0F0u) >> 4) | (num10 << 4);
		num ^= num << 3;
		num += num2;
		num ^= num << 11;
		num += num4;
		num ^= num >> 27;
		num += num5;
		return (((num2 << 11) - num3) ^ num4) - num;
	}

	[UDeI7RWk9e8HZbAF57(typeof(TlgJaUaQEO0K1skGJY<object>[]))]
	internal static string S5EVCEoVRsUhN2TLgb(string M448gdJtBGnIC5sjsy)
	{
		"308G2F7no1B3pymOUq".Trim();
		byte[] array = Convert.FromBase64String(M448gdJtBGnIC5sjsy);
		return Encoding.Unicode.GetString(array, 0, array.Length);
	}

	[UDeI7RWk9e8HZbAF57(typeof(TlgJaUaQEO0K1skGJY<object>[]))]
	private static byte[] yXqvlKOf7TI5f2lymB(byte[] M448gdJtBGnIC5sjsy)
	{
		return new ObfuscatorJunkAttribute(new byte[32]
		{
			123, 5, 74, 12, 244, 156, 221, 154, 121, 221,
			183, 41, 121, 65, 9, 43, 67, 81, 23, 43,
			74, 63, 64, 23, 95, 185, 226, 244, 45, 194,
			211, 43
		}, new byte[16]
		{
			117, 254, 41, 121, 65, 52, 9, 43, 221, 154,
			12, 54, 68, 241, 68, 66
		}).lgXZQJyjKotW8pE105(M448gdJtBGnIC5sjsy);
	}

	private byte[] YVlkenloekN6WfIuTH()
	{
		_ = "rH4wQuCAv5Pyg1z9m".Length;
		return new byte[2] { 1, 2 };
	}

	private byte[] w7oBPQVmcyicA7eaY8()
	{
		_ = "DnEMfihylFVZtHKeEONo6R".Length;
		return new byte[2] { 1, 2 };
	}
}
