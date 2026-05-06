using System;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Content.Client.UserInterface.Systems.Chat;
using Content.Shared.Chat;
using HarmonyLib;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using CerberusConfig;

[CompilerGenerated]
public sealed class ChatTranslatePatch
{
	private static readonly Vector4 vector4_0 = new Vector4(0.9f, 0.2f, 0.2f, 1f);

	private char char_0;

	private bool bool_0;

	private byte byte_0;

	private char char_1;

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

	private bool Boolean_0
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
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

	private char Char_1
	{
		get
		{
			return char_1;
		}
		set
		{
			char_1 = value;
		}
	}

	private static MethodInfo TargetMethod()
	{
		return AccessTools.Method(typeof(ChatUIController), "OnChatMessage", (Type[])null, (Type[])null);
	}

	public static void Patch()
	{
		MethodInfo method = TargetMethod();
		MethodInfo method2 = NukePdaPatchHelper.GetMethod(typeof(ChatTranslatePatch), "Prefix");
		NukePdaPatchHelper.PatchMethod(method, method2, (HarmonyPatchType)1);
	}

	public static bool Prefix(ChatUIController __instance, MsgChatMessage message)
	{
		if (CerberusConfig.Settings.TranslateChatPatch && !string.IsNullOrEmpty(message.Message.Message))
		{
			Translate(message, __instance);
			return false;
		}
		return true;
	}

	private static async Task Translate(MsgChatMessage message, ChatUIController __instance)
	{
		ChatMessage msg = message.Message;
		try
		{
			msg.WrappedMessage = ReplaceContent(msg, (await GoogleTranslateClient.TranslateAsync(msg.Message, CerberusConfig.Settings.TranslateChatLang)).DestinationText);
			__instance.ProcessChatMessage(msg, true);
		}
		catch (Exception)
		{
			NotificationOverlay.ShowNotification("Failed to translate message", 5f, 0.3f, 0.5f, vector4_0, useProgressBar: true);
		}
	}

	private static string ReplaceContent(ChatMessage msg, string newContent)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Invalid comparison between Unknown and I4
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Invalid comparison between Unknown and I4
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Invalid comparison between Unknown and I4
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Invalid comparison between Unknown and I4
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		IEntityManager val = IoCManager.Resolve<IEntityManager>();
		EntityUid entity = val.GetEntity(msg.SenderEntity);
		ChatChannel channel = msg.Channel;
		string pattern;
		string replacement;
		if ((int)channel > 16)
		{
			if ((int)channel == 512)
			{
				string entityName = val.GetComponent<MetaDataComponent>(entity).EntityName;
				pattern = "(\\[italic\\])(.*?)(\\[/italic\\])";
				replacement = $"$1{entityName} {newContent}$3";
				return Regex.Replace(msg.WrappedMessage, pattern, replacement);
			}
			if ((int)channel != 1024)
			{
				goto IL_0050;
			}
		}
		else if ((ushort)(channel - 1) > 1)
		{
			if ((int)channel == 16)
			{
				pattern = "(\\[font=.*?\\])(\"|)(.*?)(\\2)(\\[/font\\])";
				replacement = "$1\"" + newContent + "\"$5";
				string text = Regex.Replace(msg.WrappedMessage, pattern, replacement);
				if (text == msg.WrappedMessage)
				{
					string pattern2 = "\\[font size=12\\]\\s*(.*?)\\s*\\[\\/bold\\]";
					replacement = $"[font size=12]{Environment.NewLine}{newContent}{Environment.NewLine}[/bold]";
					text = Regex.Replace(msg.WrappedMessage, pattern2, replacement);
				}
				return text;
			}
			goto IL_0050;
		}
		pattern = "(\\[BubbleContent\\])(.*?)(\\[/BubbleContent\\])";
		replacement = "[BubbleContent]" + newContent + "[/BubbleContent]";
		return Regex.Replace(msg.WrappedMessage, pattern, replacement);
		IL_0050:
		pattern = "(\\[bold\\].*?\\[\\/bold\\])\\s*(.*)";
		replacement = "$1 " + newContent;
		return Regex.Replace(msg.WrappedMessage, pattern, replacement);
	}

	private string method_10(string string_1, long long_1, float float_0)
	{
		return "Хитролох_иди_нахуй._____0____4__2____6_";
	}
}
