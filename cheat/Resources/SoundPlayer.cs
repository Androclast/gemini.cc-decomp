using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using CerberusConfig;

namespace SoundPlayer;

public sealed class SoundPlayer
{
	private static readonly Dictionary<string, byte[]> dictionary_0;

	private static readonly Assembly assembly_0;

	private static readonly string[] string_0;

	private static readonly string[] string_1;

	private char char_0;

	private float float_0;

	private char char_1;

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

	private char Char_1
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

	[DllImport("winmm.dll", SetLastError = true)]
	private static extern bool PlaySound(byte[] ptrToSound, nuint hmod, uint fdwSound);

	static SoundPlayer()
	{
		dictionary_0 = new Dictionary<string, byte[]>();
		assembly_0 = Assembly.GetExecutingAssembly();
		string_0 = new string[22]
		{
			"Kaban.cc.Resources.Sounds.Enable.Enable1.wav", "Kaban.cc.Resources.Sounds.Enable.Enable2.wav", "Kaban.cc.Resources.Sounds.Enable.Enable3.wav", "Kaban.cc.Resources.Sounds.Enable.Enable4.wav", "Kaban.cc.Resources.Sounds.Enable.Enable5.wav", "Kaban.cc.Resources.Sounds.Enable.Enable6.wav", "Kaban.cc.Resources.Sounds.Enable.Enable7.wav", "Kaban.cc.Resources.Sounds.Enable.Enable8.wav", "Kaban.cc.Resources.Sounds.Enable.Enable9.wav", "Kaban.cc.Resources.Sounds.Enable.Enable10.wav",
			"Kaban.cc.Resources.Sounds.Enable.Enable11.wav", "Kaban.cc.Resources.Sounds.Enable.Enable12.wav", "Kaban.cc.Resources.Sounds.Enable.Enable13.wav", "Kaban.cc.Resources.Sounds.Enable.Enable14.wav", "Kaban.cc.Resources.Sounds.Enable.Enable15.wav", "Kaban.cc.Resources.Sounds.Enable.Enable16.wav", "Kaban.cc.Resources.Sounds.Enable.Enable17.wav", "Kaban.cc.Resources.Sounds.Enable.Enable18.wav", "Kaban.cc.Resources.Sounds.Enable.Enable19.wav", "Kaban.cc.Resources.Sounds.Enable.Enable20.wav",
			"Kaban.cc.Resources.Sounds.Enable.Enable21.wav", "Kaban.cc.Resources.Sounds.Enable.Enable22.wav"
		};
		string_1 = new string[22]
		{
			"Kaban.cc.Resources.Sounds.Disable.Disable1.wav", "Kaban.cc.Resources.Sounds.Disable.Disable2.wav", "Kaban.cc.Resources.Sounds.Disable.Disable3.wav", "Kaban.cc.Resources.Sounds.Disable.Disable4.wav", "Kaban.cc.Resources.Sounds.Disable.Disable5.wav", "Kaban.cc.Resources.Sounds.Disable.Disable6.wav", "Kaban.cc.Resources.Sounds.Disable.Disable7.wav", "Kaban.cc.Resources.Sounds.Disable.Disable8.wav", "Kaban.cc.Resources.Sounds.Disable.Disable9.wav", "Kaban.cc.Resources.Sounds.Disable.Disable10.wav",
			"Kaban.cc.Resources.Sounds.Disable.Disable11.wav", "Kaban.cc.Resources.Sounds.Disable.Disable12.wav", "Kaban.cc.Resources.Sounds.Disable.Disable13.wav", "Kaban.cc.Resources.Sounds.Disable.Disable14.wav", "Kaban.cc.Resources.Sounds.Disable.Disable15.wav", "Kaban.cc.Resources.Sounds.Disable.Disable16.wav", "Kaban.cc.Resources.Sounds.Disable.Disable17.wav", "Kaban.cc.Resources.Sounds.Disable.Disable18.wav", "Kaban.cc.Resources.Sounds.Disable.Disable19.wav", "Kaban.cc.Resources.Sounds.Disable.Disable20.wav",
			"Kaban.cc.Resources.Sounds.Disable.Disable21.wav", "Kaban.cc.Resources.Sounds.Disable.Disable22.wav"
		};
	}

	public static void PlayEnableSound()
	{
		PlayInternal(isEnable: true);
	}

	public static void PlayDisableSound()
	{
		PlayInternal(isEnable: false);
	}

	private static void PlayInternal(bool isEnable)
	{
		if (!CerberusConfig.Sounds.Enabled)
		{
			return;
		}
		try
		{
			int num = CerberusConfig.Sounds.SelectedPackIndex;
			string[] array = (isEnable ? string_0 : string_1);
			if (num < 0 || num >= array.Length)
			{
				num = 0;
			}
			string text = array[num];
			if (!dictionary_0.TryGetValue(text, out byte[] value))
			{
				using Stream stream = assembly_0.GetManifestResourceStream(text);
				if (stream == null)
				{
					string[] manifestResourceNames = assembly_0.GetManifestResourceNames();
					for (int i = 0; i < manifestResourceNames.Length; i++)
					{
					}
					return;
				}
				using MemoryStream memoryStream = new MemoryStream();
				stream.CopyTo(memoryStream);
				value = memoryStream.ToArray();
				dictionary_0[text] = value;
			}
			float volume = CerberusConfig.Sounds.Volume;
			byte[] ptrToSound = value;
			if (Math.Abs(volume - 100f) > 0.1f)
			{
				ptrToSound = ApplyVolume(value, volume / 100f);
			}
			PlaySound(ptrToSound, UIntPtr.Zero, 7u);
		}
		catch (Exception)
		{
		}
	}

	public static byte[] ApplyVolume(byte[] audioData, float volumeMultiplier)
	{
		try
		{
			byte[] array = new byte[audioData.Length];
			Array.Copy(audioData, array, audioData.Length);
			int num = -1;
			for (int i = 12; i < array.Length - 4; i++)
			{
				if (array[i] == 100 && array[i + 1] == 97 && array[i + 2] == 116 && array[i + 3] == 97)
				{
					num = i + 8;
					break;
				}
			}
			if (num == -1)
			{
				num = 44;
			}
			for (int j = num; j < array.Length - 1; j += 2)
			{
				int num2 = (int)((float)BitConverter.ToInt16(array, j) * volumeMultiplier);
				if (num2 <= 32767)
				{
					if (num2 < -32768)
					{
						num2 = -32768;
					}
				}
				else
				{
					num2 = 32767;
				}
				byte[] bytes = BitConverter.GetBytes((short)num2);
				array[j] = bytes[0];
				array[j + 1] = bytes[1];
			}
			return array;
		}
		catch
		{
			return audioData;
		}
	}
}
