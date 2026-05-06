using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Hexa.NET.ImGui;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

[CompilerGenerated]
public sealed class ImGuiImageManager
{
	[StructLayout(LayoutKind.Auto)]
	public struct GEnum0 : Enum
	{
	}

	private static readonly Dictionary<string, ImTextureID> dictionary_0 = new Dictionary<string, ImTextureID>();

	private byte byte_0;

	private string string_0;

	private byte byte_1;

	private double double_0;

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

	private byte Byte_1
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

	public static bool AddImage(string key, byte[] imageData, int filterMode = 0)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		if (!string.IsNullOrEmpty(key) && imageData != null && imageData.Length != 0)
		{
			if (dictionary_0.TryGetValue(key, out var value))
			{
				uint textures = (uint)((ImTextureID)(ref value)).Handle;
				if (textures != 0)
				{
					try
					{
						OpenGLNativeApi.glDeleteTextures(1, ref textures);
					}
					catch
					{
					}
				}
				dictionary_0.Remove(key);
			}
			ImTextureID value2 = LoadImageAsTexture(imageData, filterMode);
			if (((ImTextureID)(ref value2)).Equals(default(ImTextureID)))
			{
				return false;
			}
			dictionary_0[key] = value2;
			return true;
		}
		return false;
	}

	public static ImTextureID GetImage(string key)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		if (!dictionary_0.TryGetValue(key, out var value))
		{
			return default(ImTextureID);
		}
		return value;
	}

	public static void DisposeAll()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		foreach (ImTextureID value in dictionary_0.Values)
		{
			ImTextureID current = value;
			uint textures = (uint)((ImTextureID)(ref current)).Handle;
			if (textures != 0)
			{
				try
				{
					OpenGLNativeApi.glDeleteTextures(1, ref textures);
				}
				catch
				{
				}
			}
		}
		dictionary_0.Clear();
	}

	private static ImTextureID LoadImageAsTexture(byte[] imageData, int filterMode)
	{
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		uint textures = 0u;
		GCHandle gCHandle = default(GCHandle);
		ImTextureID result;
		try
		{
			Image<Rgba32> val = Image.Load<Rgba32>((ReadOnlySpan<byte>)imageData);
			try
			{
				int width = ((Image)val).Width;
				int height = ((Image)val).Height;
				byte[] array = new byte[width * height * 4];
				val.CopyPixelDataTo((Span<byte>)array);
				gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
				nint num = gCHandle.AddrOfPinnedObject();
				if (num != IntPtr.Zero)
				{
					OpenGLNativeApi.glGenTextures(1, out textures);
					if (textures == 0)
					{
						result = default(ImTextureID);
					}
					else
					{
						OpenGLNativeApi.glBindTexture(3553u, textures);
						int param;
						int param2;
						if (filterMode == 0 || filterMode != 1)
						{
							param = 9729;
							param2 = 9729;
						}
						else
						{
							param = 9728;
							param2 = 9728;
						}
						OpenGLNativeApi.glTexParameteri(3553u, 10241u, param);
						OpenGLNativeApi.glTexParameteri(3553u, 10240u, param2);
						OpenGLNativeApi.glTexParameteri(3553u, 10242u, 33071);
						OpenGLNativeApi.glTexParameteri(3553u, 10243u, 33071);
						OpenGLNativeApi.glTexImage2D(3553u, 0, 32856, width, height, 0, 6408u, 5121u, num);
						if (OpenGLNativeApi.glGetError() == 0)
						{
							OpenGLNativeApi.glBindTexture(3553u, 0u);
							result = new ImTextureID((ulong)textures);
							return result;
						}
						OpenGLNativeApi.glDeleteTextures(1, ref textures);
						result = default(ImTextureID);
					}
				}
				else
				{
					result = default(ImTextureID);
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
		catch
		{
			if (textures == 0)
			{
				result = default(ImTextureID);
			}
			else
			{
				try
				{
					OpenGLNativeApi.glDeleteTextures(1, ref textures);
				}
				catch
				{
				}
				result = default(ImTextureID);
			}
		}
		finally
		{
			if (gCHandle.IsAllocated)
			{
				gCHandle.Free();
			}
		}
		return result;
	}
}
