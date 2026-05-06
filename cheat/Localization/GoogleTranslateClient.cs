using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

public sealed class GoogleTranslateClient
{
	private static readonly HttpClient httpClient_0 = new HttpClient
	{
		BaseAddress = new Uri("https://ftapi.pythonanywhere.com")
	};

	private char char_0;

	private int int_0;

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

	public static async Task<TranslationResult> TranslateAsync(string text, string destinationLanguage, string sourceLanguage = null)
	{
		if (string.IsNullOrWhiteSpace(text))
		{
			throw new ArgumentException("Text must be provided", "text");
		}
		if (string.IsNullOrWhiteSpace(destinationLanguage))
		{
			throw new ArgumentException("Destination language must be provided", "destinationLanguage");
		}
		StringBuilder stringBuilder = new StringBuilder("/translate?dl=");
		stringBuilder.Append(Uri.EscapeDataString(destinationLanguage));
		stringBuilder.Append("&text=");
		stringBuilder.Append(Uri.EscapeDataString(text));
		if (!string.IsNullOrWhiteSpace(sourceLanguage))
		{
			stringBuilder.Append("&sl=");
			stringBuilder.Append(Uri.EscapeDataString(sourceLanguage));
		}
		try
		{
			using HttpResponseMessage httpResponse = await httpClient_0.GetAsync(stringBuilder.ToString());
			httpResponse.EnsureSuccessStatusCode();
			using Stream stream = await httpResponse.Content.ReadAsStreamAsync();
			JsonSerializerOptions options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};
			return await JsonSerializer.DeserializeAsync<TranslationResult>(stream, options, CancellationToken.None);
		}
		catch (Exception)
		{
			throw;
		}
	}
}
