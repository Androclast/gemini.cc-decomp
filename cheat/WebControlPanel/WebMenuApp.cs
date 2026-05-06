using System.Threading.Tasks;
using System.Windows;
using WebViewWindow;

namespace WebMenuApp;

public sealed class WebMenuApp
{
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

	public static async Task<WebViewWindow> CreateAndShowWebMenu(string authToken)
	{
		WebViewWindow window = new WebViewWindow();
		await window.InitializeAsync(authToken);
		window.NavigateToMenu("https://localhost:5000/menu");
		((Window)window).Show();
		return window;
	}
}
