using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AesStringCrypto;

public sealed class AesStringCrypto
{
	private static readonly byte[] byte_0 = Encoding.UTF8.GetBytes("KabanSecurityKey2024!@#$%^&*()[]");

	private static readonly byte[] byte_1 = Encoding.UTF8.GetBytes("KabanIV123456789");

	private int int_1;

	private float float_0;

	private float float_1;

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
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	private float Single_1
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

	public static string Encrypt(string plainText)
	{
		if (!string.IsNullOrEmpty(plainText))
		{
			using (Aes aes = Aes.Create())
			{
				aes.Key = byte_0;
				aes.IV = byte_1;
				aes.Mode = CipherMode.CBC;
				aes.Padding = PaddingMode.PKCS7;
				using ICryptoTransform transform = aes.CreateEncryptor();
				using MemoryStream memoryStream = new MemoryStream();
				using (CryptoStream stream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
				{
					using StreamWriter streamWriter = new StreamWriter(stream);
					streamWriter.Write(plainText);
				}
				return Convert.ToBase64String(memoryStream.ToArray());
			}
		}
		return string.Empty;
	}

	public static string Decrypt(string cipherText)
	{
		if (string.IsNullOrEmpty(cipherText))
		{
			return string.Empty;
		}
		try
		{
			using Aes aes = Aes.Create();
			aes.Key = byte_0;
			aes.IV = byte_1;
			aes.Mode = CipherMode.CBC;
			aes.Padding = PaddingMode.PKCS7;
			using ICryptoTransform transform = aes.CreateDecryptor();
			using MemoryStream stream = new MemoryStream(Convert.FromBase64String(cipherText));
			using CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
			using StreamReader streamReader = new StreamReader(stream2);
			return streamReader.ReadToEnd();
		}
		catch
		{
			return string.Empty;
		}
	}
}
