using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using CerberusWareV3.Features.Utility;
using Robust.Shared.Maths;

namespace CrayonImageParser;

public sealed class CrayonImageParser
{
	private class ImageRegion
	{
		public List<(int, int)> aDd2naWrZa = new List<(int, int)>();

		public Color W8B22fwT3f;

		public Vector2 SOj2H7uMdI;

		public int OAA2Z31hlt;

		public int tVE2t1iTvw;

		public float YAJ26SrLe8;

		private float float_0;

		private long long_0;

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
	}

	public struct SmartDrawCommand
	{
		public string DecalId;

		public Color Color;

		public Vector2 Position;

		public GEnum6 DecalType;

		public int RegionSize;

		public float Confidence;
	}

	private string string_0;

	private byte byte_0;

	private float float_2;

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

	private float Single_0
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	public static List<SmartDrawCommand> ParseImage(Bitmap bitmap, Dictionary<GEnum6, List<DecalInfo>> decalsByType)
	{
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected O, but got I4
		List<SmartDrawCommand> list = new List<SmartDrawCommand>();
		bool[,] array = new bool[((Image)bitmap).Width, ((Image)bitmap).Height];
		Logger.Info($"[AutoPainter] Smart parsing: {((Image)bitmap).Width}x{((Image)bitmap).Height}");
		for (int i = 0; i < ((Image)bitmap).Height; i++)
		{
			for (int j = 0; j < ((Image)bitmap).Width; j++)
			{
				if (array[j, i])
				{
					continue;
				}
				if (bitmap.GetPixel(j, i).A < 128)
				{
					array[j, i] = true;
					continue;
				}
				ImageRegion imageRegion = AnalyzeRegion(bitmap, j, i, array);
				if (imageRegion.aDd2naWrZa.Count != 0)
				{
					int num = DetermineRegionDecalType(imageRegion);
					string decalId = SelectBestDecalForRegion(imageRegion, num, decalsByType);
					SmartDrawCommand item = new SmartDrawCommand
					{
						DecalId = decalId,
						Color = imageRegion.W8B22fwT3f,
						Position = imageRegion.SOj2H7uMdI,
						DecalType = (GEnum6)num,
						RegionSize = imageRegion.aDd2naWrZa.Count,
						Confidence = imageRegion.YAJ26SrLe8
					};
					list.Add(item);
				}
			}
		}
		Logger.Info($"[AutoPainter] Smart parsing complete: {list.Count} regions found");
		return list.OrderByDescending((SmartDrawCommand c) => (float)c.RegionSize * c.Confidence).ToList();
	}

	private static ImageRegion AnalyzeRegion(Bitmap bitmap, int startX, int startY, bool[,] visited)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		ImageRegion imageRegion = new ImageRegion();
		Queue<(int, int)> queue = new Queue<(int, int)>();
		bitmap.GetPixel(startX, startY);
		queue.Enqueue((startX, startY));
		visited[startX, startY] = true;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = startX;
		int num6 = startX;
		int num7 = startY;
		int num8 = startY;
		while (queue.Count > 0 && imageRegion.aDd2naWrZa.Count < 100)
		{
			(int, int) tuple = queue.Dequeue();
			int item = tuple.Item1;
			int item2 = tuple.Item2;
			Color pixel = bitmap.GetPixel(item, item2);
			imageRegion.aDd2naWrZa.Add((item, item2));
			num += pixel.R;
			num2 += pixel.G;
			num3 += pixel.B;
			num4 += pixel.A;
			num5 = Math.Min(num5, item);
			num6 = Math.Max(num6, item);
			num7 = Math.Min(num7, item2);
			num8 = Math.Max(num8, item2);
			(int, int)[] array = new(int, int)[4]
			{
				(item - 1, item2),
				(item + 1, item2),
				(item, item2 - 1),
				(item, item2 + 1)
			};
			for (int i = 0; i < array.Length; i++)
			{
				var (num9, num10) = array[i];
				if (num9 >= 0 && num9 < ((Image)bitmap).Width && num10 >= 0 && num10 < ((Image)bitmap).Height && !visited[num9, num10])
				{
					Color pixel2 = bitmap.GetPixel(num9, num10);
					if (pixel2.A >= 128 && ColorDistance(pixel, pixel2) < 50)
					{
						queue.Enqueue((num9, num10));
						visited[num9, num10] = true;
					}
				}
			}
		}
		int count = imageRegion.aDd2naWrZa.Count;
		imageRegion.W8B22fwT3f = new Color((float)(num / count), (float)(num2 / count), (float)(num3 / count), (float)(num4 / count));
		imageRegion.SOj2H7uMdI = new Vector2((float)(num5 + num6) / 2f * 0.5f, (float)(-(num7 + num8)) / 2f * 0.5f);
		imageRegion.OAA2Z31hlt = num6 - num5 + 1;
		imageRegion.tVE2t1iTvw = num8 - num7 + 1;
		imageRegion.YAJ26SrLe8 = Math.Min(1f, (float)count / 10f);
		return imageRegion;
	}

	private static int ColorDistance(Color c1, Color c2)
	{
		int num = c1.R - c2.R;
		int num2 = c1.G - c2.G;
		int num3 = c1.B - c2.B;
		return (int)Math.Sqrt(num * num + num2 * num2 + num3 * num3);
	}

	private static int DetermineRegionDecalType(ImageRegion region)
	{
		float num = (float)region.OAA2Z31hlt / (float)region.tVE2t1iTvw;
		if (region.aDd2naWrZa.Count != 1)
		{
			if (region.aDd2naWrZa.Count > 3)
			{
				if (!(num <= 3f) || !(num >= 0.33f))
				{
					return 1;
				}
				if (num <= 0.7f || !(num < 1.3f) || region.aDd2naWrZa.Count <= 4)
				{
					return 0;
				}
				return 2;
			}
			return 0;
		}
		return 0;
	}

	private static string SelectBestDecalForRegion(ImageRegion region, int type, Dictionary<GEnum6, List<DecalInfo>> decalsByType)
	{
		//IL_003b: Expected O, but got I4
		//IL_004a: Expected O, but got I4
		if (decalsByType.TryGetValue((GEnum6)type, out List<DecalInfo> value) && value.Count != 0)
		{
			int index = Math.Min(region.aDd2naWrZa.Count / 10, value.Count - 1);
			return value[index].string_0;
		}
		if (!decalsByType.TryGetValue((GEnum6)0, out List<DecalInfo> value2) || value2.Count <= 0)
		{
			return "rune1";
		}
		return value2[0].string_0;
	}
}
