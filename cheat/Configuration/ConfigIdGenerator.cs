using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ConfigIdGenerator;

public sealed class ConfigIdGenerator
{
	private string string_0;

	private bool bool_0;

	private bool bool_1;

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

	private bool Boolean_1
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public static void Generate()
	{
		Console.WriteLine("=== Config ID Generator ===");
		Console.WriteLine("Generating ConfigId attributes for all fields in CerberusConfig...\n");
		string text = FindConfigFile();
		if (!string.IsNullOrEmpty(text))
		{
			Console.WriteLine("Found config file: " + text);
			string text2 = File.ReadAllText(text);
			string contents = AddConfigIdAttributes(text2);
			string text3 = text + ".backup";
			File.WriteAllText(text3, text2);
			Console.WriteLine("Backup created: " + text3);
			File.WriteAllText(text, contents);
			Console.WriteLine("\nConfig file updated successfully!");
			Console.WriteLine("Please review the changes and rebuild the project.");
		}
		else
		{
			Console.WriteLine("ERROR: Could not find CerberusConfig.cs file!");
		}
	}

	private static string FindConfigFile()
	{
		string[] array = new string[4] { "Kaban.cc/Configuration/CerberusConfig.cs", "../Kaban.cc/Configuration/CerberusConfig.cs", "../../Kaban.cc/Configuration/CerberusConfig.cs", "Configuration/CerberusConfig.cs" };
		int num = 0;
		string path;
		while (true)
		{
			if (num >= array.Length)
			{
				return null;
			}
			path = array[num];
			if (File.Exists(path))
			{
				break;
			}
			num++;
		}
		return Path.GetFullPath(path);
	}

	private static string AddConfigIdAttributes(string content)
	{
		string[] array = content.Split('\n');
		StringBuilder stringBuilder = new StringBuilder();
		string text = null;
		int num = 0;
		for (int i = 0; i < array.Length; i++)
		{
			string text2 = array[i];
			string text3 = text2.Trim();
			if (text3.StartsWith("public static class "))
			{
				Match match = Regex.Match(text3, "public static class (\\w+)");
				if (match.Success)
				{
					text = match.Groups[1].Value;
				}
			}
			if (IsFieldDeclaration(text3) && !string.IsNullOrEmpty(text))
			{
				bool flag = false;
				if (i > 0 && array[i - 1].Trim().Contains("[ConfigId("))
				{
					flag = true;
				}
				if (!flag)
				{
					string text4 = ExtractFieldName(text3);
					if (!string.IsNullOrEmpty(text4))
					{
						string value = GenerateId(text, text4);
						string indentation = GetIndentation(text2);
						StringBuilder stringBuilder2 = stringBuilder;
						StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(14, 2, stringBuilder2);
						handler.AppendFormatted(indentation);
						handler.AppendLiteral("[ConfigId(\"");
						handler.AppendFormatted(value);
						handler.AppendLiteral("\")]");
						stringBuilder2.AppendLine(ref handler);
						num++;
					}
				}
			}
			stringBuilder.AppendLine(text2.TrimEnd('\r'));
		}
		Console.WriteLine($"Added {num} ConfigId attributes");
		return stringBuilder.ToString();
	}

	private static bool IsFieldDeclaration(string line)
	{
		if (line.StartsWith("//") || line.StartsWith("/*") || line.StartsWith("*"))
		{
			return false;
		}
		if (!line.Contains("public static") || (!line.Contains("=") && !line.Contains(";")))
		{
			return false;
		}
		if (line.Contains("(") || line.Contains("{") || line.Contains("get") || line.Contains("set"))
		{
			return false;
		}
		return true;
	}

	private static string ExtractFieldName(string line)
	{
		Match match = Regex.Match(line, "public static \\w+(?:<[^>]+>)?\\s+(\\w+)");
		if (!match.Success)
		{
			return null;
		}
		return match.Groups[1].Value;
	}

	private static string GenerateId(string className, string fieldName)
	{
		string text = ToSnakeCase(className);
		string text2 = ToSnakeCase(fieldName);
		return text + "." + text2;
	}

	private static string ToSnakeCase(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return text;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < text.Length; i++)
		{
			char c = text[i];
			if (!char.IsUpper(c))
			{
				stringBuilder.Append(c);
				continue;
			}
			if (i > 0)
			{
				stringBuilder.Append('_');
			}
			stringBuilder.Append(char.ToLower(c));
		}
		return stringBuilder.ToString();
	}

	private static string GetIndentation(string line)
	{
		int num = 0;
		foreach (char c in line)
		{
			if (c != ' ' && c != '\t')
			{
				break;
			}
			num++;
		}
		return line.Substring(0, num);
	}
}
