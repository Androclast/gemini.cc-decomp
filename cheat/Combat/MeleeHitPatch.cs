using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Content.Shared.Mobs;
using Content.Shared.Mobs.Systems;
using Content.Shared.Weapons.Melee;
using HarmonyLib;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using SoundPlayer;
using CerberusConfig;

namespace MeleeHitPatch;

public sealed class MeleeHitPatch
{
	private class SoundPack
	{
		[CompilerGenerated]
		private string Q6inYWHW49;

		[CompilerGenerated]
		private string[] IjRnlSubmo;

		private string string_0;

		private char char_0;

		private double double_1;

		private char char_1;

		public string Name
		{
			[CompilerGenerated]
			get
			{
				return Q6inYWHW49;
			}
			[CompilerGenerated]
			set
			{
				Q6inYWHW49 = value;
			}
		}

		public string[] Resources
		{
			[CompilerGenerated]
			get
			{
				return IjRnlSubmo;
			}
			[CompilerGenerated]
			set
			{
				IjRnlSubmo = value;
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

		private string method_6(bool bool_0, char char_2, bool bool_1)
		{
			return "Хитролох_иди_нахуй.__0___5_7_";
		}
	}

	private static readonly Dictionary<string, byte[]> dictionary_0 = new Dictionary<string, byte[]>();

	private static readonly Assembly assembly_0 = Assembly.GetExecutingAssembly();

	private static readonly Random random_0 = new Random();

	private static DateTime dateTime_0 = DateTime.MinValue;

	private static DateTime dateTime_1 = DateTime.MinValue;

	private static DateTime dateTime_2 = DateTime.MinValue;

	private static readonly List<SoundPack> list_0 = new List<SoundPack>
	{
		new SoundPack
		{
			Name = "Rust Headshot",
			Resources = new string[1] { "Kaban.cc.Resources.Sounds.Hit.rust.wav" }
		},
		new SoundPack
		{
			Name = "Bell (Rust)",
			Resources = new string[1] { "Kaban.cc.Resources.Sounds.Hit.bell.wav" }
		},
		new SoundPack
		{
			Name = "Skeet",
			Resources = new string[1] { "Kaban.cc.Resources.Sounds.Hit.bell2.wav" }
		},
		new SoundPack
		{
			Name = "Crime",
			Resources = new string[1] { "Kaban.cc.Resources.Sounds.Hit.crime.wav" }
		},
		new SoundPack
		{
			Name = "Marker",
			Resources = new string[1] { "Kaban.cc.Resources.Sounds.Hit.Marker.wav" }
		},
		new SoundPack
		{
			Name = "Metallic",
			Resources = new string[1] { "Kaban.cc.Resources.Sounds.Hit.metallic.wav" }
		},
		new SoundPack
		{
			Name = "Moan / Ston Pack",
			Resources = new string[6] { "Kaban.cc.Resources.Sounds.Hit.Moan.wav", "Kaban.cc.Resources.Sounds.Hit.moan1.wav", "Kaban.cc.Resources.Sounds.Hit.moan2.wav", "Kaban.cc.Resources.Sounds.Hit.moan3.wav", "Kaban.cc.Resources.Sounds.Hit.moan4.wav", "Kaban.cc.Resources.Sounds.Hit.ston.wav" }
		},
		new SoundPack
		{
			Name = "Soft",
			Resources = new string[1] { "Kaban.cc.Resources.Sounds.Hit.soft.wav" }
		},
		new SoundPack
		{
			Name = "Soft Hit",
			Resources = new string[1] { "Kaban.cc.Resources.Sounds.Hit.softhit.wav" }
		},
		new SoundPack
		{
			Name = "UwU",
			Resources = new string[1] { "Kaban.cc.Resources.Sounds.Hit.UwU.wav" }
		},
		new SoundPack
		{
			Name = "Hit 3",
			Resources = new string[1] { "Kaban.cc.Resources.Sounds.Hit.hit3.wav" }
		},
		new SoundPack
		{
			Name = "Hit 4",
			Resources = new string[1] { "Kaban.cc.Resources.Sounds.Hit.hit4.wav" }
		},
		new SoundPack
		{
			Name = "Kolokolnia Kill",
			Resources = new string[1] { "Kaban.cc.Resources.Sounds.Hit.kolokolnia_kill.wav" }
		},
		new SoundPack
		{
			Name = "Hitsound TF2",
			Resources = new string[1] { "Kaban.cc.Resources.Sounds.Hit.hitsound-tf2.wav" }
		},
		new SoundPack
		{
			Name = "Critical Hit TF2",
			Resources = new string[1] { "Kaban.cc.Resources.Sounds.Hit.critical-hit-tf2_1.wav" }
		},
		new SoundPack
		{
			Name = "Impressive (Quake III)",
			Resources = new string[1] { "Kaban.cc.Resources.Sounds.Hit.impressive-quake-iii.wav" }
		}
	};

	public static Dictionary<EntityUid, DateTime> dictionary_1 = new Dictionary<EntityUid, DateTime>();

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

	[DllImport("winmm.dll", SetLastError = true)]
	private static extern bool PlaySound(byte[] ptrToSound, nuint hmod, uint fdwSound);

	public static void NotifyPlayer(string message)
	{
	}

	public static void ApplyPatches(Harmony harmony)
	{
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		try
		{
			MethodInfo methodInfo = (MethodInfo)((MeleeHitPatch)(object)typeof(SharedMeleeWeaponSystem)).method_0("DoLightAttack", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (methodInfo != null)
			{
				harmony.Patch((MethodBase)methodInfo, (HarmonyMethod)null, new HarmonyMethod((MethodInfo)((MeleeHitPatch)(object)typeof(MeleeHitPatch)).method_0("LightAttackPostfix", BindingFlags.Static | BindingFlags.Public)), (HarmonyMethod)null, (HarmonyMethod)null);
			}
		}
		catch
		{
		}
		try
		{
			MethodInfo methodInfo2 = (MethodInfo)((MeleeHitPatch)(object)typeof(SharedMeleeWeaponSystem)).method_0("DoHeavyAttack", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (methodInfo2 != null)
			{
				harmony.Patch((MethodBase)methodInfo2, (HarmonyMethod)null, new HarmonyMethod((MethodInfo)((MeleeHitPatch)(object)typeof(MeleeHitPatch)).method_0("HeavyAttackPostfix", BindingFlags.Static | BindingFlags.Public)), (HarmonyMethod)null, (HarmonyMethod)null);
			}
		}
		catch
		{
		}
		try
		{
			MethodInfo methodInfo3 = (MethodInfo)((MeleeHitPatch)(object)typeof(MobStateSystem)).method_0("ChangeState", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (methodInfo3 != null)
			{
				harmony.Patch((MethodBase)methodInfo3, (HarmonyMethod)null, new HarmonyMethod((MethodInfo)((MeleeHitPatch)(object)typeof(MeleeHitPatch)).method_0("KillPostfix_Sunrise", BindingFlags.Static | BindingFlags.Public)), (HarmonyMethod)null, (HarmonyMethod)null);
			}
		}
		catch
		{
		}
	}

	private static void ProcessAttack(EntityUid user, object ev, string attackType)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (ev == null || !IoCManager.Resolve<IGameTiming>().IsFirstTimePredicted)
			{
				return;
			}
			IEntityManager entMan = IoCManager.Resolve<IEntityManager>();
			ICommonSession localSession = ((ISharedPlayerManager)IoCManager.Resolve<IPlayerManager>()).LocalSession;
			EntityUid? val = ((localSession != null) ? localSession.AttachedEntity : ((EntityUid?)null));
			if (!val.HasValue || user != val.Value)
			{
				return;
			}
			Type type = ev.GetType();
			bool flag = false;
			object obj = null;
			PropertyInfo property = type.GetProperty("Target");
			if (property != null)
			{
				obj = property.GetValue(ev);
			}
			else
			{
				FieldInfo field = type.GetField("Target");
				if (field != null)
				{
					obj = field.GetValue(ev);
				}
			}
			if (obj != null)
			{
				EntityUid? val2 = ResolveEntity(entMan, obj);
				if (val2.HasValue)
				{
					RegisterHit(val2.Value, attackType);
					flag = true;
				}
			}
			if (flag)
			{
				return;
			}
			object obj2 = null;
			PropertyInfo propertyInfo = type.GetProperty("Entities") ?? type.GetProperty("HitEntities");
			if (propertyInfo != null)
			{
				obj2 = propertyInfo.GetValue(ev);
			}
			else
			{
				FieldInfo fieldInfo = type.GetField("Entities") ?? type.GetField("HitEntities");
				if (fieldInfo != null)
				{
					obj2 = fieldInfo.GetValue(ev);
				}
			}
			if (!(obj2 is IEnumerable enumerable))
			{
				return;
			}
			foreach (object item in enumerable)
			{
				EntityUid? val3 = ResolveEntity(entMan, item);
				if (val3.HasValue)
				{
					RegisterHit(val3.Value, attackType);
					break;
				}
			}
		}
		catch (Exception ex)
		{
			Logger.Info("[HitSoundSystem] Error: " + ex.Message);
		}
	}

	private static EntityUid? ResolveEntity(IEntityManager entMan, object obj)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		if (!(obj is EntityUid))
		{
			if (obj is NetEntity val)
			{
				try
				{
					return entMan.GetEntity(val);
				}
				catch
				{
				}
			}
			return null;
		}
		return (EntityUid)obj;
	}

	public static void LightAttackPostfix(EntityUid user, object ev)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		ProcessAttack(user, ev, "LIGHT");
	}

	public static void HeavyAttackPostfix(EntityUid user, object ev)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		ProcessAttack(user, ev, "HEAVY");
	}

	private static void RegisterHit(EntityUid target, string attackType)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		if (!dictionary_1.ContainsKey(target))
		{
			dictionary_1.Add(target, DateTime.UtcNow);
		}
		else
		{
			dictionary_1[target] = DateTime.UtcNow;
		}
		PlayHitSound();
	}

	public static void KillPostfix_Sunrise(EntityUid target, MobState newState)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Invalid comparison between Unknown and I4
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Invalid comparison between Unknown and I4
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Invalid comparison between Unknown and I4
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Invalid comparison between Unknown and I4
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (IoCManager.Resolve<IGameTiming>().IsFirstTimePredicted && ((int)newState == 3 || (int)newState == 2) && dictionary_1.TryGetValue(target, out var value) && (DateTime.UtcNow - value).TotalSeconds < 30.0)
			{
				string entityName = GetEntityName(target);
				string text = (((int)newState != 3) ? "CRITICAL" : "KILLED");
				NotifyPlayer("[" + text + "] " + entityName);
				PlayHitSound(isKill: true);
				if ((int)newState == 3)
				{
					CerberusConfig.HudOverlay.SessionKills++;
				}
				if ((int)newState == 3)
				{
					dictionary_1.Remove(target);
				}
			}
		}
		catch
		{
		}
	}

	private unsafe static string GetEntityName(EntityUid uid)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			return EntityStringRepresentation.op_Implicit(IoCManager.Resolve<IEntityManager>().ToPrettyString(Entity<MetaDataComponent>.op_Implicit(uid)));
		}
		catch
		{
			return ((object)(*(EntityUid*)(&uid))/*cast due to constrained. prefix*/).ToString();
		}
	}

	public static void PlayHitSound(bool isKill = false, bool force = false)
	{
		if (isKill)
		{
			if (!CerberusConfig.KillSound.Enabled && !force)
			{
				return;
			}
		}
		else if (!CerberusConfig.HitSound.Enabled && !force)
		{
			return;
		}
		DateTime utcNow = DateTime.UtcNow;
		if (!force)
		{
			if (!isKill && utcNow < dateTime_0)
			{
				return;
			}
			if (isKill)
			{
				dateTime_0 = utcNow.AddSeconds(0.5);
			}
			if (!isKill)
			{
				if (!((utcNow - dateTime_1).TotalSeconds >= 0.1))
				{
					return;
				}
				dateTime_1 = utcNow;
			}
			else
			{
				if (!((utcNow - dateTime_2).TotalSeconds >= 0.1))
				{
					return;
				}
				dateTime_2 = utcNow;
			}
		}
		Task.Run(async delegate
		{
			try
			{
				if (isKill && !force)
				{
					await Task.Delay(20);
				}
				int num = ((!isKill) ? CerberusConfig.HitSound.SoundIndex : CerberusConfig.KillSound.SoundIndex);
				float num2 = (isKill ? CerberusConfig.KillSound.Volume : CerberusConfig.HitSound.Volume);
				if (num < 0 || num >= list_0.Count)
				{
					num = 0;
				}
				SoundPack soundPack = list_0[num];
				if (soundPack.Resources != null && soundPack.Resources.Length != 0)
				{
					string text = soundPack.Resources[random_0.Next(soundPack.Resources.Length)];
					byte[] value;
					lock (dictionary_0)
					{
						if (!dictionary_0.TryGetValue(text, out value))
						{
							using Stream stream = assembly_0.GetManifestResourceStream(text);
							if (stream == null)
							{
								return;
							}
							using MemoryStream memoryStream = new MemoryStream();
							stream.CopyTo(memoryStream);
							value = memoryStream.ToArray();
							dictionary_0[text] = value;
						}
					}
					float num3 = num2 / 100f;
					byte[] ptrToSound = value;
					if (!(Math.Abs(num3 - 1f) <= 0.01f))
					{
						ptrToSound = SoundPlayer.ApplyVolume(value, num3);
					}
					PlaySound(ptrToSound, UIntPtr.Zero, 5u);
				}
			}
			catch
			{
			}
		});
	}

	public object method_0(string string_1, BindingFlags bindingFlags_0)
	{
		return ((Type)this).GetMethod(string_1, bindingFlags_0);
	}
}
