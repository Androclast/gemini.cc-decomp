using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FileIntegrityVerifier;

public class FileIntegrityVerifier
{
	private static readonly Dictionary<string, string> dictionary_0 = new Dictionary<string, string>
	{
		{ "index.html", "PLACEHOLDER_HASH_INDEX_HTML" },
		{ "security-init.js", "PLACEHOLDER_HASH_SECURITY_INIT_JS" },
		{ "devtools-detector.js", "PLACEHOLDER_HASH_DEVTOOLS_DETECTOR_JS" },
		{ "devtools-detector.obfuscated.js", "PLACEHOLDER_HASH_DEVTOOLS_DETECTOR_OBFUSCATED_JS" },
		{ "anti-debug.js", "PLACEHOLDER_HASH_ANTI_DEBUG_JS" },
		{ "obfuscate.js", "PLACEHOLDER_HASH_OBFUSCATE_JS" },
		{ "index.css", "PLACEHOLDER_HASH_INDEX_CSS" }
	};

	private readonly string webResourcesPath;

	private readonly Dictionary<string, string> dictionary_1;

	private bool bool_0;

	private int int_0;

	private char char_0;

	private char char_1;

	private string string_1;

	public bool IsIntegrityVerified => bool_0;

	public IReadOnlyDictionary<string, string> VerifiedHashes => dictionary_1;

	public string WebResourcesPath => webResourcesPath;

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
			return char_0;
		}
		set
		{
			char_0 = value;
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

	public FileIntegrityVerifier(string webResourcesPath)
	{
		if (!string.IsNullOrEmpty(webResourcesPath))
		{
			if (!Directory.Exists(webResourcesPath))
			{
				throw new DirectoryNotFoundException("Web resources directory not found: " + webResourcesPath);
			}
			this.webResourcesPath = webResourcesPath;
			dictionary_1 = new Dictionary<string, string>();
			bool_0 = false;
			return;
		}
		throw new ArgumentException("Web resources path cannot be null or empty", "webResourcesPath");
	}

	public bool VerifyIntegrity()
	{
		Console.WriteLine("[FileIntegrityChecker] Starting integrity verification for Web Menu files...");
		try
		{
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, string> item in dictionary_0)
			{
				string key = item.Key;
				string value = item.Value;
				string text = Path.Combine(webResourcesPath, key);
				if (File.Exists(text))
				{
					string text2 = CalculateFileHash(text);
					dictionary_1[key] = text2;
					if (text2 != value)
					{
						Console.WriteLine("[FileIntegrityChecker] ❌ Hash mismatch for " + key);
						Console.WriteLine("[FileIntegrityChecker]    Expected: " + value);
						Console.WriteLine("[FileIntegrityChecker]    Actual:   " + text2);
						list.Add(key + " (hash mismatch)");
					}
					else
					{
						Console.WriteLine("[FileIntegrityChecker] ✓ " + key + " verified successfully");
					}
				}
				else
				{
					Console.WriteLine("[FileIntegrityChecker] ❌ File not found: " + key);
					list.Add(key + " (not found)");
				}
			}
			if (list.Count <= 0)
			{
				Console.WriteLine("[FileIntegrityChecker] ✓ All files verified successfully");
				bool_0 = true;
				return true;
			}
			Console.WriteLine($"[FileIntegrityChecker] ❌ Integrity verification FAILED for {list.Count} file(s):");
			foreach (string item2 in list)
			{
				Console.WriteLine("[FileIntegrityChecker]    - " + item2);
			}
			bool_0 = false;
			return false;
		}
		catch (Exception ex)
		{
			Console.WriteLine("[FileIntegrityChecker] ❌ Error during integrity verification: " + ex.Message);
			bool_0 = false;
			return false;
		}
	}

	public bool VerifyFile(string fileName)
	{
		if (string.IsNullOrEmpty(fileName))
		{
			throw new ArgumentException("File name cannot be null or empty", "fileName");
		}
		if (!dictionary_0.ContainsKey(fileName))
		{
			Console.WriteLine("[FileIntegrityChecker] ⚠\ufe0f No expected hash for file: " + fileName);
			return false;
		}
		string text = Path.Combine(webResourcesPath, fileName);
		if (!File.Exists(text))
		{
			Console.WriteLine("[FileIntegrityChecker] ❌ File not found: " + fileName);
			return false;
		}
		string text2 = CalculateFileHash(text);
		string text3 = dictionary_0[fileName];
		if (text2 != text3)
		{
			Console.WriteLine("[FileIntegrityChecker] ❌ Hash mismatch for " + fileName);
			Console.WriteLine("[FileIntegrityChecker]    Expected: " + text3);
			Console.WriteLine("[FileIntegrityChecker]    Actual:   " + text2);
			return false;
		}
		Console.WriteLine("[FileIntegrityChecker] ✓ " + fileName + " verified successfully");
		dictionary_1[fileName] = text2;
		return true;
	}

	private static string CalculateFileHash(string filePath)
	{
		using SHA256 sHA = SHA256.Create();
		using FileStream inputStream = File.OpenRead(filePath);
		return BitConverter.ToString(sHA.ComputeHash(inputStream)).Replace("-", "").ToLowerInvariant();
	}

	public static Dictionary<string, string> GenerateHashes(string webResourcesPath)
	{
		if (!string.IsNullOrEmpty(webResourcesPath))
		{
			if (Directory.Exists(webResourcesPath))
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				string[] crHw5L52Kq = new string[3] { ".html", ".css", ".js" };
				List<string> list = (from f in Directory.GetFiles(webResourcesPath, "*.*", SearchOption.TopDirectoryOnly)
					where crHw5L52Kq.Contains(Path.GetExtension(f).ToLowerInvariant())
					select f).ToList();
				Console.WriteLine($"[FileIntegrityChecker] Generating hashes for {list.Count} files...");
				{
					foreach (string item in list)
					{
						string fileName = Path.GetFileName(item);
						string text = (dictionary[fileName] = CalculateFileHash(item));
						Console.WriteLine("[FileIntegrityChecker] " + fileName + ": " + text);
					}
					return dictionary;
				}
			}
			throw new DirectoryNotFoundException("Web resources directory not found: " + webResourcesPath);
		}
		throw new ArgumentException("Web resources path cannot be null or empty", "webResourcesPath");
	}

	public static string GenerateHashesCode(string webResourcesPath)
	{
		Dictionary<string, string> source = GenerateHashes(webResourcesPath);
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("private static readonly Dictionary<string, string> ExpectedHashes = new()");
		stringBuilder.AppendLine("{");
		foreach (KeyValuePair<string, string> item in source.OrderBy<KeyValuePair<string, string>, string>((KeyValuePair<string, string> h) => h.Key))
		{
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(15, 2, stringBuilder2);
			handler.AppendLiteral("    { \"");
			handler.AppendFormatted(item.Key);
			handler.AppendLiteral("\", \"");
			handler.AppendFormatted(item.Value);
			handler.AppendLiteral("\" },");
			stringBuilder2.AppendLine(ref handler);
		}
		stringBuilder.AppendLine("};");
		return stringBuilder.ToString();
	}
}
