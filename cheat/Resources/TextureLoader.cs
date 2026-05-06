using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Robust.Client.Graphics;
using Robust.Shared.Graphics;

namespace TextureLoader;

public sealed class TextureLoader
{
	private static readonly Dictionary<string, Texture> dictionary_0 = new Dictionary<string, Texture>();

	private static readonly Assembly assembly_0 = Assembly.GetExecutingAssembly();

	private int int_0;

	private string string_0;

	private int int_1;

	private float float_0;

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

	private int Int32_1
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

	public static Texture LoadTexture(string resourcePath, string textureName)
	{
		if (dictionary_0.TryGetValue(resourcePath, out Texture value))
		{
			return value;
		}
		try
		{
			using Stream stream = assembly_0.GetManifestResourceStream(resourcePath);
			if (stream != null)
			{
				Texture val = Texture.LoadFromPNGStream(stream, textureName, (TextureLoadParameters?)null);
				if (val != null)
				{
					dictionary_0[resourcePath] = val;
				}
				return val;
			}
			return null;
		}
		catch (Exception)
		{
			return null;
		}
	}

	public static void ClearCache()
	{
		dictionary_0.Clear();
	}
}
