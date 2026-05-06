using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace LocalizationStringTools;

public class LocalizationStringTools
{
	private double double_0;

	private bool bool_0;

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

	private bool Boolean_0
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	[Obsolete("Exclude")]
	public static byte[] smethod_0(Stream stream_0)
	{
		using MemoryStream memoryStream = new MemoryStream();
		stream_0.CopyTo(memoryStream);
		return memoryStream.ToArray();
	}

	[Obsolete("Exclude")]
	public static void smethod_1(string string_1)
	{
		if (!string.IsNullOrEmpty(string_1))
		{
			EazfuscatorResourceDecoder.string_0 = new string[0];
			Stream manifestResourceStream = typeof(EazfuscatorResourceDecoder).Assembly.GetManifestResourceStream(string_1);
			StreamReader streamReader = new StreamReader(new MemoryStream(EazfuscatorResourceDecoder.smethod_3(smethod_0(manifestResourceStream))));
			string text;
			while ((text = streamReader.ReadLine()) != null)
			{
				Array.Resize(ref EazfuscatorResourceDecoder.string_0, EazfuscatorResourceDecoder.string_0.Length + 1);
				EazfuscatorResourceDecoder.string_0[EazfuscatorResourceDecoder.string_0.Length - 1] = text;
			}
		}
	}

	[Obsolete("Exclude")]
	public static string smethod_2(string[] string_1, uint? nullable_0, string string_2, int int_0, DateTime dateTime_0, bool bool_1)
	{
		if (EazfuscatorResourceDecoder.dictionary_1 == null)
		{
			EazfuscatorResourceDecoder.dictionary_1 = new Dictionary<string, string>();
		}
		if (int_0 >= 0 && int_0 < string_1.Length)
		{
			string text = string_1[int_0];
			nullable_0 = EazfuscatorResourceDecoder.nullable_0;
			if (nullable_0.HasValue)
			{
				return string.Empty;
			}
			lock (EazfuscatorResourceDecoder.dictionary_1)
			{
				if (EazfuscatorResourceDecoder.dictionary_1.TryGetValue(text, out var value))
				{
					return value;
				}
			}
			if (!(dateTime_0 == default(DateTime)))
			{
				try
				{
					byte[] bytes = Convert.FromBase64String(string_2);
					string s = Encoding.UTF8.GetString(bytes);
					byte[] bytes2 = Encoding.UTF8.GetBytes(s);
					byte[] array = Convert.FromBase64String(text);
					for (int i = 0; i < array.Length; i++)
					{
						array[i] ^= bytes2[i % bytes2.Length];
					}
					string str = Encoding.UTF8.GetString(array);
					TextElementEnumerator textElementEnumerator = StringInfo.GetTextElementEnumerator(str);
					List<string> list = new List<string>();
					while (textElementEnumerator.MoveNext())
					{
						list.Add(textElementEnumerator.GetTextElement());
					}
					list.Reverse();
					string string_3 = string.Concat(list);
					string_3 = smethod_5(string_3);
					string_3 = smethod_3(string_3, 5);
					byte[] bytes3 = Convert.FromBase64String(string_3);
					string text2 = Encoding.UTF8.GetString(bytes3);
					lock (EazfuscatorResourceDecoder.dictionary_1)
					{
						EazfuscatorResourceDecoder.dictionary_1[text] = text2;
					}
					return text2;
				}
				catch
				{
					return string.Empty;
				}
			}
			return dateTime_0.ToLongDateString();
		}
		return string.Empty;
	}

	[Obsolete("Exclude")]
	public static string smethod_3(string string_1, int int_0)
	{
		if (!string.IsNullOrEmpty(string_1))
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char c in string_1)
			{
				if (c < ' ' || c > '~')
				{
					stringBuilder.Append(c);
					continue;
				}
				int num = (c - 32 - int_0 + 95) % 95 + 32;
				stringBuilder.Append((char)num);
			}
			return stringBuilder.ToString();
		}
		return string_1;
	}

	[Obsolete("Exclude")]
	public static string smethod_4(this string string_1)
	{
		StringBuilder stringBuilder = new StringBuilder(string_1);
		StringBuilder stringBuilder2 = new StringBuilder(string_1.Length);
		for (int i = 0; i < string_1.Length; i++)
		{
			char c = stringBuilder[i];
			c = (char)(c ^ 1);
			stringBuilder2.Append(c);
		}
		return stringBuilder2.ToString();
	}

	[Obsolete("Exclude")]
	public static string smethod_5(this string string_1)
	{
		if (!string.IsNullOrEmpty(string_1))
		{
			string str = smethod_4(string_1);
			TextElementEnumerator textElementEnumerator = StringInfo.GetTextElementEnumerator(str);
			List<string> list = new List<string>();
			while (textElementEnumerator.MoveNext())
			{
				list.Add(textElementEnumerator.GetTextElement());
			}
			list.Reverse();
			return string.Concat(list);
		}
		return string_1;
	}
}
