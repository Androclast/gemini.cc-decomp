using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Content.Shared.Chat;
using Robust.Client.Player;
using Robust.Shared.Asynchronous;
using Robust.Shared.Console;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Player;
using Robust.Shared.Utility;
using CerberusConfig;

public sealed class ChatSpammer : EntitySystem
{
	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IConsoleHost iconsoleHost_0;

	private readonly Random random_0 = new Random();

	private static readonly char[] char_0 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();

	private int int_0;

	private float float_1;

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

	private float Single_0
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	public void StartSpamChat()
	{
		Task.Run((Func<Task?>)SpamChat);
	}

	public void StartSpamAHelp()
	{
		Task.Run((Func<Task?>)SpamAHelp);
	}

	public void AddChannel(ChatSelectChannel channel)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected I4, but got Unknown
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected I4, but got Unknown
		if (!CerberusConfig.Spammer.Channels.Contains((int)channel))
		{
			CerberusConfig.Spammer.Channels.Add((int)channel);
		}
	}

	public void RemoveChannel(ChatSelectChannel channel)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected I4, but got Unknown
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected I4, but got Unknown
		if (CerberusConfig.Spammer.Channels.Contains((int)channel))
		{
			CerberusConfig.Spammer.Channels.Remove((int)channel);
		}
	}

	private string GenerateProtectWord(int length = 6)
	{
		int num = (CerberusConfig.Spammer.ProtectRandomLength ? random_0.Next(3, 9) : length);
		char[] array = new char[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = char_0[random_0.Next(char_0.Length)];
		}
		return new string(array);
	}

	private async Task SpamChat()
	{
		while (CerberusConfig.Spammer.ChatEnabled)
		{
			List<int> list = CerberusConfig.Spammer.Channels.ToList();
			foreach (int MNqNyrDlDK in list)
			{
				string jj1NRPRMA9 = (CerberusConfig.Spammer.ProtectTextEnabled ? (CerberusConfig.Spammer.ChatText + " \n" + GenerateProtectWord()) : CerberusConfig.Spammer.ChatText);
				IoCManager.Resolve<ITaskManager>().RunOnMainThread((Action)delegate
				{
					SendMessage(jj1NRPRMA9, (ChatSelectChannel)(ushort)MNqNyrDlDK);
				});
				await Task.Delay(CerberusConfig.Spammer.ChatDelay);
			}
		}
	}

	private async Task SpamAHelp()
	{
		while (CerberusConfig.Spammer.AHelpEnabled)
		{
			if (!((ISharedPlayerManager)iplayerManager_0).LocalUser.HasValue)
			{
				await Task.Delay(1000);
				continue;
			}
			string GwaNEsWgUc = CerberusConfig.Spammer.AHelpText;
			IoCManager.Resolve<ITaskManager>().RunOnMainThread((Action)delegate
			{
				iconsoleHost_0.ExecuteCommand("ahelp \"" + CommandParsing.Escape(GwaNEsWgUc) + "\"");
			});
			await Task.Delay(CerberusConfig.Spammer.AHelpDelay);
		}
	}

	private void SendMessage(string text, ChatSelectChannel channel)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Invalid comparison between Unknown and I4
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Invalid comparison between Unknown and I4
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Invalid comparison between Unknown and I4
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Invalid comparison between Unknown and I4
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Invalid comparison between Unknown and I4
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Invalid comparison between Unknown and I4
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Invalid comparison between Unknown and I4
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Invalid comparison between Unknown and I4
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Invalid comparison between Unknown and I4
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Invalid comparison between Unknown and I4
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Invalid comparison between Unknown and I4
		string text2 = "";
		if ((int)channel <= 32)
		{
			if ((int)channel > 2)
			{
				if ((int)channel == 16)
				{
					text2 = "say \";" + CommandParsing.Escape(text) + "\"";
				}
				else
				{
					if ((int)channel != 32)
					{
						goto IL_0041;
					}
					text2 = "looc \"" + CommandParsing.Escape(text) + "\"";
				}
			}
			else if ((int)channel == 1)
			{
				text2 = "say \"" + CommandParsing.Escape(text) + "\"";
			}
			else
			{
				if ((int)channel != 2)
				{
					goto IL_0041;
				}
				text2 = "whisper \"" + CommandParsing.Escape(text) + "\"";
			}
		}
		else if ((int)channel > 512)
		{
			if ((int)channel == 1024)
			{
				text2 = "say \"" + CommandParsing.Escape(text) + "\"";
			}
			else
			{
				if ((int)channel != 8192)
				{
					goto IL_0041;
				}
				text2 = "asay \"" + CommandParsing.Escape(text) + "\"";
			}
		}
		else if ((int)channel != 64)
		{
			if ((int)channel != 512)
			{
				goto IL_0041;
			}
			text2 = "me \"" + CommandParsing.Escape(text) + "\"";
		}
		else
		{
			text2 = "ooc \"" + CommandParsing.Escape(text) + "\"";
		}
		goto IL_004e;
		IL_004e:
		if (!string.IsNullOrEmpty(text2))
		{
			iconsoleHost_0.ExecuteCommand(text2);
		}
		return;
		IL_0041:
		if ((int)channel == 16384)
		{
			iconsoleHost_0.ExecuteCommand(text);
			return;
		}
		goto IL_004e;
	}
}
