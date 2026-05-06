using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Content.Client.Chat.Managers;
using Content.Shared.Chat;
using Content.Shared.Ghost;
using Content.Shared.Mobs;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using CerberusConfig;

[CompilerGenerated]
public sealed class TrashTalkSystem : EntitySystem
{
	[Dependency]
	private readonly IChatManager ichatManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	private readonly Dictionary<EntityUid, TimeSpan> dictionary_0 = new Dictionary<EntityUid, TimeSpan>();

	private List<string> list_0 = new List<string>();

	private float float_0;

	private char char_0;

	private bool bool_0;

	private long long_1;

	public bool Enabled { get; set; }

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

	private long Int64_0
	{
		get
		{
			return long_1;
		}
		set
		{
			long_1 = value;
		}
	}

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
		((EntitySystem)this).SubscribeLocalEvent<MobStateChangedEvent>((EntityEventHandler<MobStateChangedEvent>)TrashTalkSend, (Type[])null, (Type[])null);
		LoadPhrases();
	}

	private void LoadPhrases()
	{
		string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CerberusWare");
		string path = Path.Combine(text, "TrashTalkPhrases.txt");
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		if (!File.Exists(path))
		{
			File.WriteAllLines(path, new string[74]
			{
				"Ниже твоего кд только твой iq", "Купи себе ПК, хватит играть на компе из школьной библиотеки", "Назвать тебя дауном это комплимент, учитывая то, насколько ты на самом деле туп.", "В твоём теле около 37 миллионов клеток, и ты, прямо сейчас, разочаровываешь их всех.", "Если бы я спрыгнул с твоего чсв на твой iq я бы умер на полпути от голода.", "Учёные придумали число 0 когда подсчитали твои шансы сделать что-нибудь полезное.", "Ты из тех людей которые занимают третье место, играя 1 v 1", "Ты причина легализации абортов.", "Кто поставил сложность ботов на мирную?", "Я бы назвал тебя раком, но рак убивает.",
				"Я бы спросил сколько тебе лет, но я знаю что ты не умеешь считать до таких больших чисел.", "Некоторым  платят за оральный ceкc, но ты делаешь это бесплатно.", "Две ошибки всегда приводят к третьей. Твои родители наглядный тому пример.", "Я бы посоветовал тебе застрелиться, но уверен что ты промажешь.", "Посоветуй сайт где можно скинуться тебе на лечение.", "Дешевле тебя был только тот рваный гандон который использовал твой отец.", "Бог юморист: не веришь — посмотри на себя в зеркало.", "Любое сходство между тобой и человеком является чисто случайным.", "Твой плейстайл доказательство того, что мастурбация вызывает слепоту", "Сразу видно: мать не хотела, отец не старался.",
				"Я уверен что твоя дакимакура гордиться тобой", "Некоторых детей роняли на голову, но тебя явно кидали об стену.", "Даже если ты выстрелишь в землю, ты промажешь.", "Ты знаешь что акулы убивают 5 человек за год? Похоже у тебя есть серьёзные конкуренты.", "Выключи сску. Просто выйди на улицу и подойди к ближайшему дереву и извинись за то, что тратишь кислород.", "Тебя MEE6 роль не дал ибо даже за человека тебя не считает", "Извините за нецензурную брань. Но ты упал башкой об пол, 1, сукин сын", "Я твою \"Инв4лидную к0ляску\" \"КеРпИчЕм\" отхуярил", "упал минус мать", "nn4ik shat on",
				"a вы (you) сэр собственно кто (who)?", "ой а кто (who) ты (you) такой вотзефак мен))))))", "плиз скажи мне свой реальный никнейм, мне для медии надо)))", "нищий улетел", "*DEAD* пофикси нищ", "але найс упал нищ ЛОООООООЛ", "ой нищий упал щас скорую вызовем", "бля че тут эта нищая собака заскулила", "на мыло и веревку то деньги есть нищ????", "жаль конечно что против нищей играть надо)))",
				"не хотелось даже руки об тебя марать нищ сука", "БЛЯ НИЩ ХУЯК ХУЯК И ТЕБЯ НЕТ КАК МОЖНО ТАКИМ БЫТЬ?????? ОБЬЯСНИСЬ БЛЯТЬ", "с тобой там все хорошо????????????? а да ты нищ нахуя я спрашиваю ПХАХАХАХАХХА", "бля я рядом только прошел а ты уже упал АУУ НИЩ С ТОБОЙ ВСЕ ХОРОШО??????????))))))", "алло это скорая? тут такая ситуация нищ упал))) ОЙ А ВЫ НИЩАМ ТО НЕ ПОМОГАЕТЕ?? ПОНЯТНО Я ПОЙДУ ТОГДА))))))))", "спи", "спать", "на завод иди", "а вы че клины???", "ебать тебя унесло",
				"набутылирован лол", "рефандни пожалуйста", "ты че там отлетел то", "обоссал дауна лол", "прости что без смазки)))", "але а противники то где???", "бля пиздос может рефнешь???", "хуя тебя опустили манька))))", "сука не позорься и ливни лол", "как там жизнь с рупастой??????",
				"даун down, на завод нахуй", "насрал тебе в ротешник проверяй", "ебать ты красиво на бутылку упал", "научи потом как так сосать на хвх", "iq больше двух будет пмнешь ок????", "ты можешь заселлить лишнюю хромосому???", "как ты на пк накопил даже не знаю )))))))))", "тебе права голоса не давали thirdworlder ебаный", "когда не накопил на гормоны и чулки)))))))))))))", "нихуя ты там как самолет отлетел ХАХАХХАХАХАХАХХХААХАА",
				"опущены стяги, легион и.. А БЛЯТЬ ТЫЖ ТУТ ОПУЩ НАХУЙ ПХГАХААХАХАХА)))))))", "але я бот_кик в консоль вроде прописал а вас там не кикнуло эт че баг??)))))))))", "я не понял ты такой жирный потомучто дошики каждый день жрешь???? нормальную работу найди может на еду денег хватит))))))))))))", "Устал от того, что тебя постоянно овнят? CerberusWare прикупи nn4ik ах да я забыл ты нищий тебе даже на дошик не хватает, сочувствую)))))"
			});
		}
		list_0 = new List<string>(File.ReadAllLines(path));
	}

	private void TrashTalkSend(MobStateChangedEvent args)
	{
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Invalid comparison between Unknown and I4
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Invalid comparison between Unknown and I4
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (CerberusConfig.Misc.TrashTalkEnabled && ichatManager_0 != null && igameTiming_0 != null && iplayerManager_0 != null)
			{
				EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
				EntityUid target = ((MobStateChangedEvent)(ref args)).Target;
				if ((!localEntity.HasValue || !(localEntity.GetValueOrDefault() == target)) && !((EntitySystem)this).HasComp<GhostComponent>(((ISharedPlayerManager)iplayerManager_0).LocalEntity) && (int)((MobStateChangedEvent)(ref args)).NewMobState == 2 && (int)((MobStateChangedEvent)(ref args)).OldMobState == 1 && (!dictionary_0.TryGetValue(((MobStateChangedEvent)(ref args)).Target, out var value) || !(igameTiming_0.CurTime - value < TimeSpan.FromSeconds(3.0))) && list_0 != null && list_0.Count != 0)
				{
					Random random = new Random();
					string text = list_0[random.Next(list_0.Count)];
					ichatManager_0.SendMessage(text, (ChatSelectChannel)1);
					dictionary_0[((MobStateChangedEvent)(ref args)).Target] = igameTiming_0.CurTime;
				}
			}
		}
		catch (Exception ex)
		{
			Logger.Error("[TrashTalk] Error: " + ex.Message);
		}
	}

	private string method_8(byte byte_1, bool bool_1, bool bool_2)
	{
		return "Хитролох_иди_нахуй.___6__9___5_";
	}
}
