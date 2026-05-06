using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using HarmonyLib;
using CerberusConfig;

namespace AdminScreengrabPatch;

public sealed class AdminScreengrabPatch
{
	private sealed class SavedState
	{
		public bool r3FnpO4dV1;

		public bool tThnx8W2Pg;

		public bool WfQn153DhD;

		public bool MsYnVW0hHb;

		public bool SK5nakBHCy;

		public bool bXQnQ3d5u6;

		public bool oVjnWx3EtP;

		public bool rgJnCpmyMM;

		public bool jMmnUFtMLK;

		public bool C0sn9HY6XQ;

		public bool PuvnsAT27B;

		public bool gGTnb4UScC;

		public bool gUSnrASxQE;

		public bool P7lnD0o9fA;

		public bool C6tnue30NY;

		public bool qKXnAbnxhm;

		public bool d5vnLK2CIr;

		public bool qCvnFPwDBv;

		public bool usAnIK0VaQ;

		public bool JaKnXGS75d;

		public bool HBEncnjpte;

		public bool ILLnmkjSa8;

		public bool tHXnECvIXE;

		public bool ukTnqMJR88;

		public bool OBony2qVTu;

		public bool ONinRbtPht;

		public bool J5NnJbMQad;

		public bool Hg5nvAwtES;

		public bool jwAnSB2863;

		public bool Ji8nOag7ZX;

		public bool xTbnd4Gfbi;

		public bool xe3n78J9fL;

		public bool u1Pn47EuOx;

		public bool pV2nT4dPdR;

		public bool q5JnNpfunI;

		public bool M3On0VSxId;

		public bool u9pnPpXYA4;

		public bool fMAn8rwK8T;

		public bool dl7nknsLuS;

		public bool eN6n3FCD8e;

		private long long_0;

		private long long_1;

		private string string_1;

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

		private long Int64_1
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
	}

	private static DateTime dateTime_0 = DateTime.MinValue;

	private static bool bool_0 = false;

	private static SavedState savedState_0 = null;

	private char char_0;

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

	private static IEnumerable<MethodBase> TargetMethods()
	{
		List<MethodBase> list = new List<MethodBase>();
		Type type = AccessTools.TypeByName("Robust.Client.Graphics.Clyde.Clyde");
		if (type != null)
		{
			MethodInfo methodInfo = AccessTools.Method(type, "Screenshot", (Type[])null, (Type[])null);
			if (methodInfo != null)
			{
				list.Add(methodInfo);
			}
			MethodInfo methodInfo2 = AccessTools.Method(type, "ScreenshotAsync", (Type[])null, (Type[])null);
			if (methodInfo2 != null)
			{
				list.Add(methodInfo2);
			}
		}
		Type type2 = AccessTools.TypeByName("Content.Client.Screenshot.ScreenshotHook");
		if (type2 != null)
		{
			foreach (MethodInfo declaredMethod in AccessTools.GetDeclaredMethods(type2))
			{
				list.Add(declaredMethod);
			}
		}
		string[] array = new string[4] { "Content.Client._CorvaxGoob.Photo.CaptureSystem", "Content.Client.CorvaxGoob.Photo.CaptureSystem", "Content.Client.Corvax.Photo.CaptureSystem", "Content.Client.Photo.CaptureSystem" };
		for (int i = 0; i < array.Length; i++)
		{
			Type type3 = AccessTools.TypeByName(array[i]);
			if (type3 != null)
			{
				MethodInfo methodInfo3 = AccessTools.Method(type3, "RequestCaptureScreen", (Type[])null, (Type[])null);
				if (methodInfo3 != null)
				{
					list.Add(methodInfo3);
					break;
				}
			}
		}
		return list;
	}

	public static void Patch()
	{
		if (!CerberusConfig.Settings.AntiScreenGrubPatch)
		{
			return;
		}
		MethodInfo patch = AccessTools.Method(typeof(AdminScreengrabPatch), "Prefix", (Type[])null, (Type[])null);
		MethodInfo patch2 = AccessTools.Method(typeof(AdminScreengrabPatch), "Postfix", (Type[])null, (Type[])null);
		foreach (MethodBase item in TargetMethods())
		{
			if (item == null)
			{
				continue;
			}
			try
			{
				MethodInfo methodInfo = item as MethodInfo;
				if (!(methodInfo == null))
				{
					NukePdaPatchHelper.PatchMethod(methodInfo, patch, (HarmonyPatchType)1);
					NukePdaPatchHelper.PatchMethod(methodInfo, patch2, (HarmonyPatchType)2);
				}
			}
			catch
			{
			}
		}
	}

	private static bool Prefix(MethodBase __originalMethod)
	{
		if (!CerberusConfig.Settings.AntiScreenGrubPatch)
		{
			return true;
		}
		string name = __originalMethod.Name;
		Type? declaringType = __originalMethod.DeclaringType;
		object obj;
		if ((object)declaringType == null)
		{
			obj = null;
		}
		else
		{
			obj = declaringType.FullName;
			if (obj != null)
			{
				goto IL_0094;
			}
		}
		obj = "";
		goto IL_0094;
		IL_0094:
		string typeName = (string)obj;
		if (IsTargetMethod(name, typeName))
		{
			HideAll();
			if ((DateTime.Now - dateTime_0).TotalSeconds > 3.0)
			{
				dateTime_0 = DateTime.Now;
				try
				{
					NotificationOverlay.ShowNotification(IsAdminScreengrab() ? "\ud83d\udee1\ufe0f Admin Screengrab Detected! All features hidden." : "\ud83d\udee1\ufe0f Screenshot Detected! All features hidden.", 4f);
				}
				catch
				{
				}
			}
			return true;
		}
		return true;
	}

	private static void Postfix(MethodBase __originalMethod)
	{
		if (!CerberusConfig.Settings.AntiScreenGrubPatch)
		{
			return;
		}
		string name = __originalMethod.Name;
		Type? declaringType = __originalMethod.DeclaringType;
		object obj;
		if ((object)declaringType != null)
		{
			obj = declaringType.FullName;
			if (obj != null)
			{
				goto IL_0024;
			}
		}
		else
		{
			obj = null;
		}
		obj = "";
		goto IL_0024;
		IL_0024:
		string typeName = (string)obj;
		if (IsTargetMethod(name, typeName))
		{
			Task.Delay(500).ContinueWith(delegate
			{
				RestoreAll();
			});
		}
	}

	private static bool IsTargetMethod(string methodName, string typeName)
	{
		if (!(methodName == "Screenshot") || !typeName.Contains("Clyde"))
		{
			if (!(methodName == "ScreenshotAsync") || !typeName.Contains("Clyde"))
			{
				if (!(methodName == "RequestCaptureScreen") || !typeName.Contains("CaptureSystem"))
				{
					if (!typeName.Contains("ScreenshotHook") || (!methodName.Contains("b__6_0") && !methodName.Contains("b__6_1")))
					{
						return false;
					}
					return true;
				}
				return true;
			}
			return true;
		}
		return true;
	}

	private static bool IsAdminScreengrab()
	{
		StackTrace stackTrace = new StackTrace();
		for (int i = 0; i < Math.Min(stackTrace.FrameCount, 20); i++)
		{
			MethodBase methodBase = stackTrace.GetFrame(i)?.GetMethod();
			if (!(methodBase?.DeclaringType == null))
			{
				string text = methodBase.DeclaringType.FullName ?? "";
				if (text.Contains("CaptureSystem") || text.Contains("Photo") || methodBase.Name.Contains("RequestCaptureScreen"))
				{
					return true;
				}
			}
		}
		return false;
	}

	private static void HideAll()
	{
		if (!bool_0)
		{
			bool_0 = true;
			try
			{
				savedState_0 = new SavedState
				{
					r3FnpO4dV1 = CerberusConfig.HudOverlay.Enabled,
					tThnx8W2Pg = CerberusConfig.Esp.Enabled,
					WfQn153DhD = CerberusConfig.GunAimBot.Enabled,
					MsYnVW0hHb = CerberusConfig.MeleeAimBot.Enabled,
					SK5nakBHCy = CerberusConfig.GunHelper.Enabled,
					bXQnQ3d5u6 = CerberusConfig.MeleeHelper.Enabled,
					oVjnWx3EtP = CerberusConfig.Eye.FovEnabled,
					rgJnCpmyMM = CerberusConfig.Eye.FullBrightEnabled,
					jMmnUFtMLK = CerberusConfig.Settings.ClydePatch,
					C0sn9HY6XQ = CerberusConfig.Settings.OverlaysPatch,
					PuvnsAT27B = CerberusConfig.Settings.SmokePatch,
					gGTnb4UScC = CerberusConfig.Misc.AntiAimEnabled,
					gUSnrASxQE = CerberusConfig.Misc.TargetStrafeEnabled,
					P7lnD0o9fA = CerberusConfig.Misc.DamageOverlayEnabled,
					C6tnue30NY = CerberusConfig.Backtrack.Enabled,
					qKXnAbnxhm = CerberusConfig.Chams.Enabled,
					d5vnLK2CIr = CerberusConfig.ThrowAimbot.Enabled,
					qCvnFPwDBv = CerberusConfig.Tracers.Enabled,
					usAnIK0VaQ = CerberusConfig.TargetEsp.SpiritsEnabled,
					JaKnXGS75d = CerberusConfig.MinecraftVisuals.JumpCirclesEnabled,
					HBEncnjpte = CerberusConfig.MinecraftVisuals.BlockOutlineEnabled,
					ILLnmkjSa8 = CerberusConfig.HitParticles.Enabled,
					tHXnECvIXE = CerberusConfig.ProjectileEsp.Enabled,
					ukTnqMJR88 = CerberusConfig.HealthInfo.Enabled,
					OBony2qVTu = CerberusConfig.AnomalyScanner.Enabled,
					ONinRbtPht = CerberusConfig.AccessChecker.Enabled,
					J5NnJbMQad = CerberusConfig.GrillElectrocution.Enabled,
					Hg5nvAwtES = CerberusConfig.StorageViewer.Enabled,
					jwAnSB2863 = CerberusConfig.AccessViewer.Enabled,
					Ji8nOag7ZX = CerberusConfig.AutoSlip.Enabled,
					xTbnd4Gfbi = CerberusConfig.AutoCuff.Enabled,
					xe3n78J9fL = CerberusConfig.AutoStop.Enabled,
					u1Pn47EuOx = CerberusConfig.AutoHypo.Enabled,
					pV2nT4dPdR = CerberusConfig.AutoMedipen.Enabled,
					q5JnNpfunI = CerberusConfig.AutoImplant.Enabled,
					M3On0VSxId = CerberusConfig.AutoDoor.Enabled,
					u9pnPpXYA4 = CerberusConfig.GrenadeHelper.Enabled,
					fMAn8rwK8T = CerberusConfig.Combat.AutoBlockEnabled,
					dl7nknsLuS = CerberusConfig.Combat.AutoLaydownEnabled,
					eN6n3FCD8e = CerberusConfig.LightSmooth.Enabled
				};
				CerberusConfig.HudOverlay.Enabled = false;
				CerberusConfig.Esp.Enabled = false;
				CerberusConfig.GunAimBot.Enabled = false;
				CerberusConfig.MeleeAimBot.Enabled = false;
				CerberusConfig.GunHelper.Enabled = false;
				CerberusConfig.MeleeHelper.Enabled = false;
				CerberusConfig.Eye.FovEnabled = false;
				CerberusConfig.Eye.FullBrightEnabled = false;
				CerberusConfig.Settings.ClydePatch = false;
				CerberusConfig.Settings.OverlaysPatch = false;
				CerberusConfig.Settings.SmokePatch = false;
				CerberusConfig.Misc.AntiAimEnabled = false;
				CerberusConfig.Misc.TargetStrafeEnabled = false;
				CerberusConfig.Misc.DamageOverlayEnabled = false;
				CerberusConfig.Backtrack.Enabled = false;
				CerberusConfig.Chams.Enabled = false;
				CerberusConfig.ThrowAimbot.Enabled = false;
				CerberusConfig.Tracers.Enabled = false;
				CerberusConfig.TargetEsp.SpiritsEnabled = false;
				CerberusConfig.MinecraftVisuals.JumpCirclesEnabled = false;
				CerberusConfig.MinecraftVisuals.BlockOutlineEnabled = false;
				CerberusConfig.HitParticles.Enabled = false;
				CerberusConfig.ProjectileEsp.Enabled = false;
				CerberusConfig.HealthInfo.Enabled = false;
				CerberusConfig.AnomalyScanner.Enabled = false;
				CerberusConfig.AccessChecker.Enabled = false;
				CerberusConfig.GrillElectrocution.Enabled = false;
				CerberusConfig.StorageViewer.Enabled = false;
				CerberusConfig.AccessViewer.Enabled = false;
				CerberusConfig.AutoSlip.Enabled = false;
				CerberusConfig.AutoCuff.Enabled = false;
				CerberusConfig.AutoStop.Enabled = false;
				CerberusConfig.AutoHypo.Enabled = false;
				CerberusConfig.AutoMedipen.Enabled = false;
				CerberusConfig.AutoImplant.Enabled = false;
				CerberusConfig.AutoDoor.Enabled = false;
				CerberusConfig.GrenadeHelper.Enabled = false;
				CerberusConfig.Combat.AutoBlockEnabled = false;
				CerberusConfig.Combat.AutoLaydownEnabled = false;
				CerberusConfig.LightSmooth.Enabled = false;
			}
			catch
			{
			}
		}
	}

	private static void RestoreAll()
	{
		if (!bool_0 || savedState_0 == null)
		{
			return;
		}
		try
		{
			SavedState savedState = savedState_0;
			CerberusConfig.HudOverlay.Enabled = savedState.r3FnpO4dV1;
			CerberusConfig.Esp.Enabled = savedState.tThnx8W2Pg;
			CerberusConfig.GunAimBot.Enabled = savedState.WfQn153DhD;
			CerberusConfig.MeleeAimBot.Enabled = savedState.MsYnVW0hHb;
			CerberusConfig.GunHelper.Enabled = savedState.SK5nakBHCy;
			CerberusConfig.MeleeHelper.Enabled = savedState.bXQnQ3d5u6;
			CerberusConfig.Eye.FovEnabled = savedState.oVjnWx3EtP;
			CerberusConfig.Eye.FullBrightEnabled = savedState.rgJnCpmyMM;
			CerberusConfig.Settings.ClydePatch = savedState.jMmnUFtMLK;
			CerberusConfig.Settings.OverlaysPatch = savedState.C0sn9HY6XQ;
			CerberusConfig.Settings.SmokePatch = savedState.PuvnsAT27B;
			CerberusConfig.Misc.AntiAimEnabled = savedState.gGTnb4UScC;
			CerberusConfig.Misc.TargetStrafeEnabled = savedState.gUSnrASxQE;
			CerberusConfig.Misc.DamageOverlayEnabled = savedState.P7lnD0o9fA;
			CerberusConfig.Backtrack.Enabled = savedState.C6tnue30NY;
			CerberusConfig.Chams.Enabled = savedState.qKXnAbnxhm;
			CerberusConfig.ThrowAimbot.Enabled = savedState.d5vnLK2CIr;
			CerberusConfig.Tracers.Enabled = savedState.qCvnFPwDBv;
			CerberusConfig.TargetEsp.SpiritsEnabled = savedState.usAnIK0VaQ;
			CerberusConfig.MinecraftVisuals.JumpCirclesEnabled = savedState.JaKnXGS75d;
			CerberusConfig.MinecraftVisuals.BlockOutlineEnabled = savedState.HBEncnjpte;
			CerberusConfig.HitParticles.Enabled = savedState.ILLnmkjSa8;
			CerberusConfig.ProjectileEsp.Enabled = savedState.tHXnECvIXE;
			CerberusConfig.HealthInfo.Enabled = savedState.ukTnqMJR88;
			CerberusConfig.AnomalyScanner.Enabled = savedState.OBony2qVTu;
			CerberusConfig.AccessChecker.Enabled = savedState.ONinRbtPht;
			CerberusConfig.GrillElectrocution.Enabled = savedState.J5NnJbMQad;
			CerberusConfig.StorageViewer.Enabled = savedState.Hg5nvAwtES;
			CerberusConfig.AccessViewer.Enabled = savedState.jwAnSB2863;
			CerberusConfig.AutoSlip.Enabled = savedState.Ji8nOag7ZX;
			CerberusConfig.AutoCuff.Enabled = savedState.xTbnd4Gfbi;
			CerberusConfig.AutoStop.Enabled = savedState.xe3n78J9fL;
			CerberusConfig.AutoHypo.Enabled = savedState.u1Pn47EuOx;
			CerberusConfig.AutoMedipen.Enabled = savedState.pV2nT4dPdR;
			CerberusConfig.AutoImplant.Enabled = savedState.q5JnNpfunI;
			CerberusConfig.AutoDoor.Enabled = savedState.M3On0VSxId;
			CerberusConfig.GrenadeHelper.Enabled = savedState.u9pnPpXYA4;
			CerberusConfig.Combat.AutoBlockEnabled = savedState.fMAn8rwK8T;
			CerberusConfig.Combat.AutoLaydownEnabled = savedState.dl7nknsLuS;
			CerberusConfig.LightSmooth.Enabled = savedState.eN6n3FCD8e;
			savedState_0 = null;
			bool_0 = false;
			try
			{
				NotificationOverlay.ShowNotification("✅ Features restored after screenshot.", 2f);
			}
			catch
			{
			}
		}
		catch
		{
		}
	}
}
