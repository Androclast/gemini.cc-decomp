using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Hexa.NET.ImGui;
using Hexa.NET.ImGui.Utilities;

[CompilerGenerated]
public sealed class ImGuiFontManager
{
	private static readonly Dictionary<string, ImFontPtr> dictionary_0 = new Dictionary<string, ImFontPtr>();

	private double double_0;

	private long long_0;

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

	private long Int64_0
	{
		get
		{
			return long_0;
		}
		set
		{
			long_0 = value;
		}
	}

	public static void AddFont(string key, byte[] font, float size = 12f)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		if (!dictionary_0.ContainsKey(key))
		{
			dictionary_0.Add(key, LoadFontFromBytes(font, size));
		}
	}

	public static ImFontPtr GetFont(string key)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		if (!dictionary_0.TryGetValue(key, out var value))
		{
			return ImFontPtr.Null;
		}
		return value;
	}

	private unsafe static ImFontPtr LoadFontFromBytes(byte[] font, float size)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		ImFontPtr result = ImFontPtr.Null;
		try
		{
			ImGuiFontBuilder val = new ImGuiFontBuilder();
			FontBlob val2 = default(FontBlob);
			((FontBlob)(ref val2))._002Ector((ReadOnlySpan<byte>)font);
			ImGuiIOPtr iO = ImGui.GetIO();
			uint* glyphRangesCyrillic = ((ImFontAtlasPtr)(ref ((ImGuiIOPtr)(ref iO)).Fonts)).GetGlyphRangesCyrillic();
			val.AddFontFromMemoryTTF(val2.Data, val2.Length, size, glyphRangesCyrillic);
			result = val.Build();
		}
		catch
		{
		}
		return result;
	}
}
