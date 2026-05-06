using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

[CompilerGenerated]
public sealed class EmbeddedNativeLibraryLoader : IDisposable
{
	private readonly Dictionary<string, (string, nint)> dictionary_0 = new Dictionary<string, (string, nint)>();

	private readonly Lock lock_0 = new Lock();

	private string string_0;

	private bool bool_0;

	private char char_0;

	private char char_1;

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

	public EmbeddedNativeLibraryLoader()
	{
		try
		{
			string_0 = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
			Directory.CreateDirectory(string_0);
		}
		catch (Exception)
		{
			string_0 = null;
		}
	}

	public void Dispose()
	{
		using (lock_0.EnterScope())
		{
			foreach (KeyValuePair<string, (string, nint)> item in dictionary_0.Reverse())
			{
				_ = item.Key;
				(string, nint) value = item.Value;
				var (filePath, _) = value;
				if (!Win32WindowApi.FreeLibrary(value.Item2))
				{
					Marshal.GetLastWin32Error();
				}
				TryDeleteFile(filePath);
			}
			dictionary_0.Clear();
		}
		if (string.IsNullOrEmpty(string_0) || !Directory.Exists(string_0))
		{
			return;
		}
		try
		{
			Directory.Delete(string_0, recursive: true);
		}
		catch (IOException)
		{
		}
		catch (UnauthorizedAccessException)
		{
		}
		catch (Exception)
		{
		}
		finally
		{
			string_0 = null;
		}
	}

	public nint LoadLibraryFromResource(string libraryFileName, Assembly callingAssembly)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(libraryFileName, "libraryFileName");
		ArgumentNullException.ThrowIfNull(callingAssembly, "callingAssembly");
		if (string.IsNullOrEmpty(string_0))
		{
			return IntPtr.Zero;
		}
		using (lock_0.EnterScope())
		{
			if (dictionary_0.TryGetValue(libraryFileName, out (string, nint) value))
			{
				return value.Item2;
			}
			string text = callingAssembly.GetManifestResourceNames().FirstOrDefault((string name) => name.EndsWith(libraryFileName, StringComparison.OrdinalIgnoreCase));
			if (string.IsNullOrEmpty(text))
			{
				return IntPtr.Zero;
			}
			string text2 = Path.Combine(string_0, libraryFileName);
			try
			{
				using Stream stream = callingAssembly.GetManifestResourceStream(text);
				if (stream == null)
				{
					return IntPtr.Zero;
				}
				using FileStream destination = new FileStream(text2, FileMode.Create, FileAccess.Write, FileShare.None);
				stream.CopyTo(destination);
			}
			catch (Exception)
			{
				TryDeleteFile(text2);
				return IntPtr.Zero;
			}
			nint num = Win32WindowApi.LoadLibrary(text2);
			if (num != IntPtr.Zero)
			{
				dictionary_0[libraryFileName] = (text2, num);
				return num;
			}
			Marshal.GetLastWin32Error();
			TryDeleteFile(text2);
			return IntPtr.Zero;
		}
	}

	private void TryDeleteFile(string filePath)
	{
		if (File.Exists(filePath))
		{
			try
			{
				File.Delete(filePath);
			}
			catch (Exception)
			{
			}
		}
	}

	private string method_6(bool bool_1, float float_0, string string_1)
	{
		return "Хитролох_иди_нахуй.__5__3__8__6_83__";
	}
}
