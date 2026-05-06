using DiscordRPC;
using DiscordRPC.Events;
using DiscordRPC.Logging;
using DiscordRPC.Message;
using WebControlServer;

public class DiscordRpcManager
{
	private DiscordRpcClient discordRpcClient_0;

	private WebControlServer server;

	private double double_1;

	private double double_2;

	private string string_1;

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

	private double Double_1
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
		}
	}

	private string String_0
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public DiscordRpcManager(WebControlServer server)
	{
		this.server = server;
		Initialize();
	}

	private void Initialize()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		discordRpcClient_0 = new DiscordRpcClient("1457012453178347550");
		discordRpcClient_0.Logger = (ILogger)new ConsoleLogger
		{
			Level = (LogLevel)3
		};
		discordRpcClient_0.OnReady += (OnReadyEvent)delegate(object sender, ReadyMessage e)
		{
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Expected O, but got Unknown
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Expected O, but got Unknown
			User user = e.User;
			string avatarURL = user.GetAvatarURL((AvatarFormat)0, (AvatarSize)64);
			server.UpdateDiscordInfo(user.Username, avatarURL, user.Discriminator.ToString(), user.ID.ToString());
			discordRpcClient_0.SetPresence(new RichPresence
			{
				Details = "Injecting chaos",
				State = "In Game",
				Assets = new Assets
				{
					LargeImageKey = "logo",
					LargeImageText = "Kaban.cc",
					SmallImageKey = "small_logo"
				},
				Timestamps = Timestamps.Now
			});
		};
		discordRpcClient_0.Initialize();
	}

	public void Shutdown()
	{
		DiscordRpcClient obj = discordRpcClient_0;
		if (obj != null)
		{
			obj.Dispose();
		}
	}
}
