using System;
using System.IO;
using FileIntegrityVerifier;

namespace WebMenuHashGenerator;

public class WebMenuHashGenerator
{
	private double double_0;

	private byte byte_1;

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

	public static void Main(string[] args)
	{
		Console.WriteLine("=== Web Menu File Integrity Hash Generator ===");
		Console.WriteLine("Task 39.7: Generate SHA-256 hashes for Web Menu files");
		Console.WriteLine();
		string text = ((args.Length != 0) ? args[0] : Path.Combine(FindProjectRoot(), "Kaban.cc", "Resources", "Web"));
		Console.WriteLine("Web Resources Path: " + text);
		Console.WriteLine();
		if (!Directory.Exists(text))
		{
			Console.WriteLine("❌ ERROR: Directory not found: " + text);
			Console.WriteLine();
			Console.WriteLine("Usage: GenerateWebMenuHashes [path-to-web-resources]");
			Console.WriteLine("Example: GenerateWebMenuHashes C:\\Projects\\Kaban.cc\\Resources\\Web");
			Environment.Exit(1);
			return;
		}
		try
		{
			Console.WriteLine("Generating hashes...");
			Console.WriteLine();
			string text2 = FileIntegrityVerifier.GenerateHashesCode(text);
			Console.WriteLine();
			Console.WriteLine("=== Generated C# Code ===");
			Console.WriteLine("Copy this code to FileIntegrityChecker.cs (replace ExpectedHashes dictionary):");
			Console.WriteLine();
			Console.WriteLine(text2);
			Console.WriteLine();
			string text3 = Path.Combine(text, "generated-hashes.txt");
			File.WriteAllText(text3, text2);
			Console.WriteLine("✓ Hashes saved to: " + text3);
			Console.WriteLine();
			Console.WriteLine("=== Next Steps ===");
			Console.WriteLine("1. Copy the generated code above");
			Console.WriteLine("2. Replace the ExpectedHashes dictionary in FileIntegrityChecker.cs");
			Console.WriteLine("3. Rebuild the project");
			Console.WriteLine();
			Console.WriteLine("✓ Hash generation completed successfully!");
		}
		catch (Exception ex)
		{
			Console.WriteLine("❌ ERROR: " + ex.Message);
			Console.WriteLine(ex.StackTrace);
			Environment.Exit(1);
		}
	}

	private static string FindProjectRoot()
	{
		for (string text = Directory.GetCurrentDirectory(); text != null; text = Directory.GetParent(text)?.FullName)
		{
			if (Directory.GetFiles(text, "*.sln").Length != 0 || Directory.Exists(Path.Combine(text, "Kaban.cc")))
			{
				return text;
			}
		}
		return Directory.GetCurrentDirectory();
	}
}
