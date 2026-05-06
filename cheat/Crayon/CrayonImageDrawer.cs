using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CerberusWareV3.Features.Utility;
using Content.Shared.Crayon;
using Content.Shared.Decals;
using Content.Shared.Hands.Components;
using Content.Shared.Hands.EntitySystems;
using Robust.Client.GameObjects;
using Robust.Client.Input;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.Input;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Map.Components;
using Robust.Shared.Maths;
using Robust.Shared.Player;
using Robust.Shared.Prototypes;
using Robust.Shared.Timing;

namespace CrayonImageDrawer;

public sealed class CrayonImageDrawer : EntitySystem
{
	[StructLayout(LayoutKind.Auto)]
	private struct Enum7 : Enum
	{
	}

	private struct DrawCommand
	{
		public string orw20ucSnb;

		public Color MbJ2Pe3OIW;

		public Vector2 m3N28bU8wo;

		public GEnum6 v6M2kXG2N7;
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003C_003Ec__DisplayClass47_0
	{
		public List<DecalInfo> t8E2eYdRvx;
	}

	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IPrototypeManager iprototypeManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly SharedHandsSystem sharedHandsSystem_0;

	[Dependency]
	private readonly IMapManager imapManager_0;

	[Dependency]
	private readonly IInputManager iinputManager_0;

	[Dependency]
	private readonly InputSystem inputSystem_0;

	private bool bool_0;

	private string? string_0;

	private List<DrawCommand> list_0 = new List<DrawCommand>();

	private int int_0;

	private GameTick gameTick_0;

	private int int_1 = 100;

	private EntityUid? nullable_0;

	private List<DecalInfo> list_1 = new List<DecalInfo>();

	private Dictionary<GEnum6, List<DecalInfo>> dictionary_0 = new Dictionary<GEnum6, List<DecalInfo>>();

	private Bitmap? bitmap_0;

	private Bitmap? bitmap_1;

	private int int_2 = 32;

	private int int_3 = 2;

	private long long_2;

	private bool bool_1;

	public bool Enabled
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
			if (!bool_0)
			{
				int_0 = 0;
			}
			Logger.Info("[AutoPainter] " + (bool_0 ? "Включен" : "Выключен"));
		}
	}

	public int DrawDelayMs
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = Math.Max(10, Math.Min(5000, value));
		}
	}

	public int TargetSize
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = Math.Max(8, Math.Min(64, value));
			if (bitmap_0 != null)
			{
				ProcessImage();
			}
		}
	}

	public int DetailLevel
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = Math.Max(1, Math.Min(5, value));
			if (bitmap_0 != null)
			{
				ProcessImage();
			}
		}
	}

	private long Int64_0
	{
		get
		{
			return long_2;
		}
		set
		{
			long_2 = value;
		}
	}

	private bool Boolean_0
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

	public string? GetOriginalImageBase64()
	{
		if (bitmap_0 != null)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				((Image)bitmap_0).Save((Stream)memoryStream, ImageFormat.Png);
				return Convert.ToBase64String(memoryStream.ToArray());
			}
		}
		return null;
	}

	public string? GetProcessedImageBase64()
	{
		if (bitmap_1 != null)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				((Image)bitmap_1).Save((Stream)memoryStream, ImageFormat.Png);
				return Convert.ToBase64String(memoryStream.ToArray());
			}
		}
		return null;
	}

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
		LoadAvailableDecals();
		Logger.Info("[AutoPainter] Система инициализирована");
	}

	private void LoadAvailableDecals()
	{
		//IL_0152: Expected I4, but got O
		//IL_00af: Expected O, but got I4
		//IL_005c: Expected O, but got I4
		//IL_00c2: Expected O, but got I4
		//IL_0169: Expected O, but got I4
		//IL_018d: Expected O, but got I4
		try
		{
			list_1.Clear();
			dictionary_0.Clear();
			foreach (DecalPrototype item2 in iprototypeManager_0.EnumeratePrototypes<DecalPrototype>())
			{
				if (!item2.Tags.Contains("crayon"))
				{
					continue;
				}
				int num = ClassifyDecal(item2.ID);
				if (num != 3)
				{
					DecalInfo item = new DecalInfo
					{
						string_0 = item2.ID,
						int_0 = num
					};
					list_1.Add(item);
					if (!dictionary_0.ContainsKey((GEnum6)item.int_0))
					{
						dictionary_0[(GEnum6)item.int_0] = new List<DecalInfo>();
					}
					dictionary_0[(GEnum6)item.int_0].Add(item);
				}
			}
			Logger.Info($"[AutoPainter] Загружено {list_1.Count} декалей:");
			foreach (GEnum6 key in dictionary_0.Keys)
			{
				int num2 = (int)key;
				Logger.Info($"  - {(GEnum6)(object)num2}: {dictionary_0[(GEnum6)num2].Count} шт.");
			}
		}
		catch (Exception ex)
		{
			Logger.Error("[AutoPainter] Ошибка загрузки декалей: " + ex.Message);
		}
	}

	private int ClassifyDecal(string id)
	{
		string text = id.ToLower();
		if (text.Contains("brush"))
		{
			return 0;
		}
		if (text.Contains("cyr_") || text.Contains("logo") || text.Contains("corp"))
		{
			return 3;
		}
		if (text.Length == 1 && (char.IsLetter(text[0]) || char.IsDigit(text[0])))
		{
			return 3;
		}
		if (text.Contains("rune") || text.Contains("dot") || text.Contains("point"))
		{
			return 0;
		}
		if (text.Contains("line") || text.Contains("arrow"))
		{
			return 1;
		}
		if (text.Contains("box") || text.Contains("square") || text.Contains("block"))
		{
			return 2;
		}
		return 3;
	}

	public bool LoadImage(string imagePath)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		try
		{
			if (File.Exists(imagePath))
			{
				Logger.Info("[AutoPainter] Загрузка изображения: " + imagePath);
				Bitmap? obj = bitmap_0;
				if (obj != null)
				{
					((Image)obj).Dispose();
				}
				Bitmap? obj2 = bitmap_1;
				if (obj2 != null)
				{
					((Image)obj2).Dispose();
				}
				bitmap_0 = new Bitmap(imagePath);
				string_0 = imagePath;
				Logger.Info($"[AutoPainter] Изображение загружено. Оригинал: {((Image)bitmap_0).Width}x{((Image)bitmap_0).Height}");
				Logger.Info("[AutoPainter] Начинаем обработку...");
				ProcessImage();
				Logger.Info("[AutoPainter] Обработка завершена");
				return true;
			}
			Logger.Error("[AutoPainter] Файл не найден: " + imagePath);
			return false;
		}
		catch (Exception ex)
		{
			Logger.Error("[AutoPainter] Ошибка загрузки изображения: " + ex.Message);
			Logger.Error("[AutoPainter] Stack trace: " + ex.StackTrace);
			return false;
		}
	}

	private void ProcessImage()
	{
		if (bitmap_0 == null)
		{
			return;
		}
		try
		{
			Logger.Info("[AutoPainter] ProcessImage: начало обработки");
			Bitmap? obj = bitmap_1;
			if (obj != null)
			{
				((Image)obj).Dispose();
			}
			Logger.Info($"[AutoPainter] Масштабирование до {int_2}...");
			bitmap_1 = ScaleImage(bitmap_0, int_2);
			Logger.Info($"[AutoPainter] Масштабировано: {((Image)bitmap_1).Width}x{((Image)bitmap_1).Height}");
			Logger.Info($"[AutoPainter] Применение детализации уровня {int_3}...");
			bitmap_1 = ApplyDetailLevel(bitmap_1, int_3);
			Logger.Info("[AutoPainter] Детализация применена");
			Logger.Info("[AutoPainter] Конвертация в команды рисования (попиксельно)...");
			list_0 = ConvertImageToDrawCommands(bitmap_1);
			int_0 = 0;
			Logger.Info($"[AutoPainter] Обработано: {((Image)bitmap_1).Width}x{((Image)bitmap_1).Height}, команд: {list_0.Count}, детализация: {int_3}");
		}
		catch (Exception ex)
		{
			Logger.Error("[AutoPainter] Ошибка обработки изображения: " + ex.Message);
			Logger.Error("[AutoPainter] Stack trace: " + ex.StackTrace);
		}
	}

	private Bitmap ScaleImage(Bitmap source, int targetSize)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Expected O, but got Unknown
		float num = Math.Min((float)targetSize / (float)((Image)source).Width, (float)targetSize / (float)((Image)source).Height);
		int num2 = (int)((float)((Image)source).Width * num);
		int num3 = (int)((float)((Image)source).Height * num);
		Bitmap val = new Bitmap(num2, num3);
		Graphics val2 = Graphics.FromImage((Image)(object)val);
		try
		{
			val2.InterpolationMode = (InterpolationMode)7;
			val2.DrawImage((Image)(object)source, 0, 0, num2, num3);
			return val;
		}
		finally
		{
			((IDisposable)val2)?.Dispose();
		}
	}

	private Bitmap ApplyDetailLevel(Bitmap source, int detailLevel)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		Bitmap val = new Bitmap(((Image)source).Width, ((Image)source).Height);
		for (int i = 0; i < ((Image)source).Height; i++)
		{
			for (int j = 0; j < ((Image)source).Width; j++)
			{
				Color pixel = source.GetPixel(j, i);
				if (pixel.A >= 128)
				{
					Color color = QuantizeColor(pixel, detailLevel);
					val.SetPixel(j, i, color);
				}
				else
				{
					val.SetPixel(j, i, Color.Transparent);
				}
			}
		}
		return val;
	}

	private Color QuantizeColor(Color color, int detailLevel)
	{
		int num = 256 / detailLevel switch
		{
			5 => 32, 
			2 => 4, 
			1 => 2, 
			4 => 16, 
			3 => 8, 
			_ => 8, 
		};
		int red = color.R / num * num;
		int green = color.G / num * num;
		int blue = color.B / num * num;
		return Color.FromArgb(color.A, red, green, blue);
	}

	private List<DrawCommand> ConvertImageToDrawCommands(Bitmap bitmap)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got I4
		List<DrawCommand> list = new List<DrawCommand>();
		Logger.Info($"[AutoPainter] Умный анализ изображения {((Image)bitmap).Width}x{((Image)bitmap).Height}...");
		float[,] array = new float[((Image)bitmap).Width, ((Image)bitmap).Height];
		for (int i = 0; i < ((Image)bitmap).Height; i++)
		{
			for (int j = 0; j < ((Image)bitmap).Width; j++)
			{
				if (bitmap.GetPixel(j, i).A < 128)
				{
					continue;
				}
				int num = 0;
				for (int k = -1; k <= 1; k++)
				{
					for (int l = -1; l <= 1; l++)
					{
						int num2 = j + l;
						int num3 = i + k;
						if (num2 >= 0 && num2 < ((Image)bitmap).Width && num3 >= 0 && num3 < ((Image)bitmap).Height && bitmap.GetPixel(num2, num3).A >= 128)
						{
							num++;
						}
					}
				}
				array[j, i] = (float)num / 9f;
			}
		}
		Color mbJ2Pe3OIW = default(Color);
		for (int m = 0; m < ((Image)bitmap).Height; m++)
		{
			for (int n = 0; n < ((Image)bitmap).Width; n++)
			{
				Color pixel = bitmap.GetPixel(n, m);
				if (pixel.A >= 128)
				{
					string orw20ucSnb = AnalyzeAndSelectDecal(bitmap, n, m, pixel, array);
					((Color)(ref mbJ2Pe3OIW))._002Ector(pixel.R, pixel.G, pixel.B, pixel.A);
					Vector2 m3N28bU8wo = new Vector2((float)n * 0.5f, (float)(-m) * 0.5f);
					list.Add(new DrawCommand
					{
						orw20ucSnb = orw20ucSnb,
						MbJ2Pe3OIW = mbJ2Pe3OIW,
						m3N28bU8wo = m3N28bU8wo,
						v6M2kXG2N7 = (GEnum6)0
					});
				}
			}
		}
		Logger.Info($"[AutoPainter] Создано {list.Count} команд с умным выбором декалей");
		return list;
	}

	private string AnalyzeAndSelectDecal(Bitmap bitmap, int x, int y, Color pixel, float[,] densityMap)
	{
		float density = densityMap[x, y];
		int num = 0;
		bool hasLeft = false;
		bool hasRight = false;
		bool hasTop = false;
		bool hasBottom = false;
		bool hasTopLeft = false;
		bool hasTopRight = false;
		bool hasBottomLeft = false;
		bool hasBottomRight = false;
		if (x > 0 && bitmap.GetPixel(x - 1, y).A >= 128)
		{
			num++;
			hasLeft = true;
		}
		if (x < ((Image)bitmap).Width - 1 && bitmap.GetPixel(x + 1, y).A >= 128)
		{
			num++;
			hasRight = true;
		}
		if (y > 0 && bitmap.GetPixel(x, y - 1).A >= 128)
		{
			num++;
			hasTop = true;
		}
		if (y < ((Image)bitmap).Height - 1 && bitmap.GetPixel(x, y + 1).A >= 128)
		{
			num++;
			hasBottom = true;
		}
		if (x > 0 && y > 0 && bitmap.GetPixel(x - 1, y - 1).A >= 128)
		{
			num++;
			hasTopLeft = true;
		}
		if (x < ((Image)bitmap).Width - 1 && y > 0 && bitmap.GetPixel(x + 1, y - 1).A >= 128)
		{
			num++;
			hasTopRight = true;
		}
		if (x > 0 && y < ((Image)bitmap).Height - 1 && bitmap.GetPixel(x - 1, y + 1).A >= 128)
		{
			num++;
			hasBottomLeft = true;
		}
		if (x < ((Image)bitmap).Width - 1 && y < ((Image)bitmap).Height - 1 && bitmap.GetPixel(x + 1, y + 1).A >= 128)
		{
			num++;
			hasBottomRight = true;
		}
		bool isEdge = IsEdgePixel(bitmap, x, y);
		return SelectDecalByPattern(num, hasLeft, hasRight, hasTop, hasBottom, hasTopLeft, hasTopRight, hasBottomLeft, hasBottomRight, density, isEdge, pixel);
	}

	private bool IsEdgePixel(Bitmap bitmap, int x, int y)
	{
		if (x == 0 || x == ((Image)bitmap).Width - 1 || y == 0 || y == ((Image)bitmap).Height - 1)
		{
			return true;
		}
		if (bitmap.GetPixel(x - 1, y).A >= 128)
		{
			if (bitmap.GetPixel(x + 1, y).A >= 128)
			{
				if (bitmap.GetPixel(x, y - 1).A < 128)
				{
					return true;
				}
				if (bitmap.GetPixel(x, y + 1).A < 128)
				{
					return true;
				}
				return false;
			}
			return true;
		}
		return true;
	}

	private string SelectDecalByPattern(int neighbors, bool hasLeft, bool hasRight, bool hasTop, bool hasBottom, bool hasTopLeft, bool hasTopRight, bool hasBottomLeft, bool hasBottomRight, float density, bool isEdge, Color pixel)
	{
		//IL_003a: Expected O, but got I4
		//IL_0412: Expected O, but got I4
		//IL_0059: Expected O, but got I4
		//IL_03d1: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		//IL_0324: Expected O, but got I4
		float num = (float)(pixel.R + pixel.G + pixel.B) / 765f;
		GetSaturation(pixel);
		_003C_003Ec__DisplayClass47_0 _003C_003Ec__DisplayClass47_0_ = default(_003C_003Ec__DisplayClass47_0);
		_003C_003Ec__DisplayClass47_0_.t8E2eYdRvx = (dictionary_0.ContainsKey((GEnum6)0) ? dictionary_0[(GEnum6)0] : new List<DecalInfo>());
		List<DecalInfo> source = (dictionary_0.ContainsKey((GEnum6)1) ? dictionary_0[(GEnum6)1] : new List<DecalInfo>());
		List<DecalInfo> source2 = (dictionary_0.ContainsKey((GEnum6)2) ? dictionary_0[(GEnum6)2] : new List<DecalInfo>());
		if (neighbors > 1)
		{
			if (!isEdge)
			{
				if (!(hasLeft || hasRight) || hasTop || hasBottom || neighbors > 3)
				{
					if (!(hasTop || hasBottom) || hasLeft || hasRight || neighbors > 3)
					{
						if (neighbors != 2 || (!(hasLeft && hasTop) && !(hasRight && hasTop) && !(hasLeft && hasBottom) && !(hasRight && hasBottom)))
						{
							if (neighbors != 3)
							{
								if (hasLeft && hasRight && hasTop && hasBottom)
								{
									return smethod_0("large", ref _003C_003Ec__DisplayClass47_0_);
								}
								if (neighbors < 5 || density <= 0.6f)
								{
									if ((!(hasTopLeft && hasBottomRight) && !(hasTopRight && hasBottomLeft)) || neighbors > 3)
									{
										if (neighbors < 4)
										{
											return smethod_0("medium", ref _003C_003Ec__DisplayClass47_0_);
										}
										return smethod_0("medium", ref _003C_003Ec__DisplayClass47_0_);
									}
									return smethod_0("medium", ref _003C_003Ec__DisplayClass47_0_);
								}
								DecalInfo decalInfo = source2.FirstOrDefault();
								if (string.IsNullOrEmpty(decalInfo.string_0))
								{
									if (num >= 0.3f)
									{
										if (num <= 0.7f)
										{
											return smethod_0("medium", ref _003C_003Ec__DisplayClass47_0_);
										}
										return smethod_0("small", ref _003C_003Ec__DisplayClass47_0_);
									}
									return smethod_0("large", ref _003C_003Ec__DisplayClass47_0_);
								}
								return decalInfo.string_0;
							}
							return smethod_0("large", ref _003C_003Ec__DisplayClass47_0_);
						}
						return smethod_0("medium", ref _003C_003Ec__DisplayClass47_0_);
					}
					if (!(hasTop && hasBottom) || hasTopLeft || hasTopRight || hasBottomLeft || hasBottomRight)
					{
						return smethod_0("medium", ref _003C_003Ec__DisplayClass47_0_);
					}
					DecalInfo decalInfo2 = source.FirstOrDefault();
					if (!string.IsNullOrEmpty(decalInfo2.string_0))
					{
						return decalInfo2.string_0;
					}
					return smethod_0("large", ref _003C_003Ec__DisplayClass47_0_);
				}
				if (!(hasLeft && hasRight) || hasTopLeft || hasTopRight || hasBottomLeft || hasBottomRight)
				{
					return smethod_0("medium", ref _003C_003Ec__DisplayClass47_0_);
				}
				DecalInfo decalInfo3 = source.FirstOrDefault();
				if (string.IsNullOrEmpty(decalInfo3.string_0))
				{
					return smethod_0("large", ref _003C_003Ec__DisplayClass47_0_);
				}
				return decalInfo3.string_0;
			}
			if (!(density > 0.7f))
			{
				if (density <= 0.4f)
				{
					return smethod_0("small", ref _003C_003Ec__DisplayClass47_0_);
				}
				return smethod_0("medium", ref _003C_003Ec__DisplayClass47_0_);
			}
			return smethod_0("large", ref _003C_003Ec__DisplayClass47_0_);
		}
		DecalInfo decalInfo4 = _003C_003Ec__DisplayClass47_0_.t8E2eYdRvx.FirstOrDefault((DecalInfo d) => d.string_0.Contains("rune"));
		if (string.IsNullOrEmpty(decalInfo4.string_0))
		{
			return smethod_0("small", ref _003C_003Ec__DisplayClass47_0_);
		}
		return decalInfo4.string_0;
	}

	private float GetSaturation(Color color)
	{
		float val = (float)(int)color.R / 255f;
		float val2 = (float)(int)color.G / 255f;
		float val3 = (float)(int)color.B / 255f;
		float num = Math.Max(val, Math.Max(val2, val3));
		float num2 = Math.Min(val, Math.Min(val2, val3));
		if (num != 0f)
		{
			return (num - num2) / num;
		}
		return 0f;
	}

	private int DetermineDecalType(Bitmap bitmap, int x, int y)
	{
		bool num = x > 0 && bitmap.GetPixel(x - 1, y).A >= 128;
		bool flag = x < ((Image)bitmap).Width - 1 && bitmap.GetPixel(x + 1, y).A >= 128;
		bool flag2 = y > 0 && bitmap.GetPixel(x, y - 1).A >= 128;
		bool flag3 = y < ((Image)bitmap).Height - 1 && bitmap.GetPixel(x, y + 1).A >= 128;
		return ((num ? 1 : 0) + (flag ? 1 : 0) + (flag2 ? 1 : 0) + (flag3 ? 1 : 0)) switch
		{
			0 => 0, 
			2 => 1, 
			4 => 2, 
			3 => 2, 
			1 => 0, 
			_ => 0, 
		};
	}

	private string SelectBestDecal(int type, Color color)
	{
		//IL_000e: Expected O, but got I4
		//IL_0022: Expected O, but got I4
		if (!dictionary_0.TryGetValue((GEnum6)type, out List<DecalInfo> value) || value.Count == 0)
		{
			if (!dictionary_0.TryGetValue((GEnum6)0, out List<DecalInfo> value2) || value2.Count <= 0)
			{
				if (list_1.Count <= 0)
				{
					return "rune1";
				}
				return list_1[0].string_0;
			}
			return value2[0].string_0;
		}
		Random random = new Random(color.GetHashCode());
		return value[random.Next(value.Count)].string_0;
	}

	public override void Update(float frameTime)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		((EntitySystem)this).Update(frameTime);
		if (bool_0)
		{
			Logger.Debug($"[AutoPainter] Update: Enabled={bool_0}, Commands={list_0.Count}, Index={int_0}");
		}
		if (!bool_0)
		{
			return;
		}
		if (list_0.Count != 0)
		{
			GameTick curTick = igameTiming_0.CurTick;
			uint num = curTick.Value - gameTick_0.Value;
			int num2 = (int)((double)int_1 / (1000.0 / (double)(int)igameTiming_0.TickRate));
			Logger.Debug($"[AutoPainter] Timing: ticksSinceLastDraw={num}, requiredTicks={num2}");
			if (num < num2)
			{
				return;
			}
			Logger.Debug("[AutoPainter] Поиск мелка в руках...");
			if (!FindCrayonInHands())
			{
				Logger.Warn("[AutoPainter] Мелок не найден в руках. Остановка.");
				bool_0 = false;
				return;
			}
			Logger.Debug($"[AutoPainter] Мелок найден: {nullable_0}");
			if (int_0 < list_0.Count)
			{
				DrawCommand command = list_0[int_0];
				Logger.Debug($"[AutoPainter] Выполнение команды {int_0}: DecalId={command.orw20ucSnb}, Color={command.MbJ2Pe3OIW}");
				if (DrawDecal(command))
				{
					int_0++;
					gameTick_0 = curTick;
					Logger.Info($"[AutoPainter] Прогресс: {int_0}/{list_0.Count}");
				}
				else
				{
					Logger.Error($"[AutoPainter] Не удалось выполнить команду {int_0}");
				}
			}
			else
			{
				Logger.Info("[AutoPainter] Рисование завершено!");
				bool_0 = false;
				int_0 = 0;
			}
		}
		else
		{
			Logger.Warn("[AutoPainter] Update: _drawCommands пуст! Остановка.");
			bool_0 = false;
		}
	}

	private bool FindCrayonInHands()
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			LocalPlayer localPlayer = iplayerManager_0.LocalPlayer;
			EntityUid? val = ((localPlayer != null) ? localPlayer.ControlledEntity : ((EntityUid?)null));
			if (!val.HasValue)
			{
				Logger.Debug("[AutoPainter] FindCrayonInHands: player is null");
				return false;
			}
			HandsComponent val2 = default(HandsComponent);
			if (!ientityManager_0.TryGetComponent<HandsComponent>(val.Value, ref val2))
			{
				Logger.Debug("[AutoPainter] FindCrayonInHands: HandsComponent not found");
				return false;
			}
			Logger.Debug($"[AutoPainter] FindCrayonInHands: Проверка {val2.Hands.Count} рук");
			foreach (string key in val2.Hands.Keys)
			{
				EntityUid? heldItem = sharedHandsSystem_0.GetHeldItem(Entity<HandsComponent>.op_Implicit((val.Value, val2)), key);
				if (heldItem.HasValue)
				{
					Logger.Debug($"[AutoPainter] FindCrayonInHands: Рука '{key}' содержит {heldItem.Value}");
					if (ientityManager_0.HasComponent<CrayonComponent>(heldItem.Value))
					{
						nullable_0 = heldItem.Value;
						Logger.Info($"[AutoPainter] FindCrayonInHands: Мелок найден в руке '{key}': {nullable_0}");
						return true;
					}
				}
				else
				{
					Logger.Debug("[AutoPainter] FindCrayonInHands: Рука '" + key + "' пуста");
				}
			}
			nullable_0 = null;
			Logger.Debug("[AutoPainter] FindCrayonInHands: Мелок не найден ни в одной руке");
			return false;
		}
		catch (Exception ex)
		{
			Logger.Error("[AutoPainter] Ошибка поиска мелка: " + ex.Message);
			Logger.Error("[AutoPainter] Stack trace: " + ex.StackTrace);
			return false;
		}
	}

	private bool DrawDecal(DrawCommand command)
	{
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (nullable_0.HasValue)
			{
				LocalPlayer localPlayer = iplayerManager_0.LocalPlayer;
				EntityUid? val = ((localPlayer != null) ? localPlayer.ControlledEntity : ((EntityUid?)null));
				if (val.HasValue)
				{
					TransformComponent val2 = default(TransformComponent);
					if (ientityManager_0.TryGetComponent<TransformComponent>(val.Value, ref val2))
					{
						Vector2 vector = val2.WorldPosition + command.m3N28bU8wo;
						MapCoordinates val3 = default(MapCoordinates);
						((MapCoordinates)(ref val3))._002Ector(vector, val2.MapID);
						EntityUid val4 = default(EntityUid);
						MapGridComponent val5 = default(MapGridComponent);
						EntityUid val6;
						EntityCoordinates coordinates = default(EntityCoordinates);
						if (imapManager_0.TryFindGridAt(val3, ref val4, ref val5))
						{
							val6 = val4;
							TransformComponent component = ientityManager_0.GetComponent<TransformComponent>(val4);
							Vector2 vector2 = Vector2.Transform(vector, component.InvWorldMatrix);
							((EntityCoordinates)(ref coordinates))._002Ector(val4, vector2);
						}
						else
						{
							val6 = imapManager_0.GetMapEntityId(val2.MapID);
							((EntityCoordinates)(ref coordinates))._002Ector(val6, val3.Position);
						}
						CrayonComponent val7 = default(CrayonComponent);
						if (!ientityManager_0.TryGetComponent<CrayonComponent>(nullable_0.Value, ref val7))
						{
							Logger.Error("[AutoPainter] DrawDecal: CrayonComponent not found");
							return false;
						}
						Logger.Debug($"[AutoPainter] DrawDecal: worldPos={vector}, mapID={val2.MapID}, targetEntity={val6}, currentDecal={val7.SelectedState}");
						try
						{
							KeyFunctionId val8 = iinputManager_0.NetworkBindMap.KeyFunctionID(BoundKeyFunction.op_Implicit("Use"));
							ScreenCoordinates mouseScreenPosition = iinputManager_0.MouseScreenPosition;
							ClientFullInputCmdMessage val9 = new ClientFullInputCmdMessage(igameTiming_0.CurTick, igameTiming_0.TickFraction, val8);
							val9.set_State((BoundKeyState)1);
							val9.set_Coordinates(coordinates);
							val9.set_ScreenCoordinates(mouseScreenPosition);
							val9.set_Uid(val6);
							ClientFullInputCmdMessage val10 = val9;
							ClientFullInputCmdMessage val11 = new ClientFullInputCmdMessage(igameTiming_0.CurTick, igameTiming_0.TickFraction, val8);
							val11.set_State((BoundKeyState)0);
							val11.set_Coordinates(coordinates);
							val11.set_ScreenCoordinates(mouseScreenPosition);
							val11.set_Uid(val6);
							ClientFullInputCmdMessage val12 = val11;
							inputSystem_0.HandleInputCommand(((ISharedPlayerManager)iplayerManager_0).LocalSession, BoundKeyFunction.op_Implicit("Use"), (IFullInputCmdMessage)(object)val10, false);
							inputSystem_0.HandleInputCommand(((ISharedPlayerManager)iplayerManager_0).LocalSession, BoundKeyFunction.op_Implicit("Use"), (IFullInputCmdMessage)(object)val12, false);
							Logger.Debug("[AutoPainter] DrawDecal: Sent Use input command");
						}
						catch (Exception ex)
						{
							Logger.Error("[AutoPainter] Error sending Use command: " + ex.Message);
						}
						return true;
					}
					Logger.Error("[AutoPainter] DrawDecal: TransformComponent not found");
					return false;
				}
				Logger.Error("[AutoPainter] DrawDecal: player is null");
				return false;
			}
			Logger.Error("[AutoPainter] DrawDecal: _crayonEntity is null");
			return false;
		}
		catch (Exception ex2)
		{
			Logger.Error("[AutoPainter] Ошибка рисования: " + ex2.Message);
			Logger.Error("[AutoPainter] Stack trace: " + ex2.StackTrace);
			return false;
		}
	}

	public void Reset()
	{
		bool_0 = false;
		int_0 = 0;
		list_0.Clear();
		string_0 = null;
		nullable_0 = null;
		Bitmap? obj = bitmap_0;
		if (obj != null)
		{
			((Image)obj).Dispose();
		}
		Bitmap? obj2 = bitmap_1;
		if (obj2 != null)
		{
			((Image)obj2).Dispose();
		}
		bitmap_0 = null;
		bitmap_1 = null;
		Logger.Info("[AutoPainter] Сброс системы");
	}

	public string GetStatus()
	{
		if (!bool_0)
		{
			return "Выключен";
		}
		if (list_0.Count != 0)
		{
			return $"Рисование: {int_0}/{list_0.Count} ({int_0 * 100 / list_0.Count}%)";
		}
		return "Нет загруженного изображения";
	}

	[CompilerGenerated]
	internal static string smethod_0(string preferred, ref _003C_003Ec__DisplayClass47_0 _003C_003Ec__DisplayClass47_0_0)
	{
		DecalInfo decalInfo = _003C_003Ec__DisplayClass47_0_0.t8E2eYdRvx.FirstOrDefault((DecalInfo d) => d.string_0.Contains(preferred));
		if (!string.IsNullOrEmpty(decalInfo.string_0))
		{
			return decalInfo.string_0;
		}
		DecalInfo decalInfo2 = _003C_003Ec__DisplayClass47_0_0.t8E2eYdRvx.FirstOrDefault((DecalInfo d) => d.string_0.Contains("brush"));
		if (!string.IsNullOrEmpty(decalInfo2.string_0))
		{
			return decalInfo2.string_0;
		}
		DecalInfo decalInfo3 = _003C_003Ec__DisplayClass47_0_0.t8E2eYdRvx.FirstOrDefault();
		if (string.IsNullOrEmpty(decalInfo3.string_0))
		{
			return "largebrush";
		}
		return decalInfo3.string_0;
	}
}
