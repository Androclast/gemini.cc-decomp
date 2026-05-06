using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using CerberusWareV3.MyImGui;
using Hexa.NET.ImGui;
using CerberusConfig;

[CompilerGenerated]
public class NotificationOverlay : IOverlay
{
	private class Notification
	{
		[CompilerGenerated]
		private readonly Guid KgOPLZBn5G;

		[CompilerGenerated]
		private readonly string EDXPFgikuD;

		[CompilerGenerated]
		private readonly float GJaPI6norF;

		[CompilerGenerated]
		private readonly float kkCPX3tQNs;

		[CompilerGenerated]
		private readonly float PO2PcZteMf;

		[CompilerGenerated]
		private readonly float YAkPmjUCpB;

		[CompilerGenerated]
		private readonly Vector4 P8BPE8SZi9;

		[CompilerGenerated]
		private readonly bool J6nPqkQic5;

		[CompilerGenerated]
		private float Wv6PyxNCLU;

		[CompilerGenerated]
		private float YXhPRh1yHJ;

		[CompilerGenerated]
		private float bYSPJjaHmE;

		[CompilerGenerated]
		private bool f9YPvHBoTi;

		[CompilerGenerated]
		private float FcQPSmTfS6;

		private byte byte_0;

		private char char_1;

		private int int_0;

		private string string_0;

		public string Message
		{
			[CompilerGenerated]
			get
			{
				return EDXPFgikuD;
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

		private char Char_0
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

		[SpecialName]
		[CompilerGenerated]
		public Guid EbK0HVUsSt()
		{
			return KgOPLZBn5G;
		}

		[SpecialName]
		[CompilerGenerated]
		public float Hm206dMqQK()
		{
			return GJaPI6norF;
		}

		[SpecialName]
		[CompilerGenerated]
		public float OeK0heKtyG()
		{
			return kkCPX3tQNs;
		}

		[SpecialName]
		[CompilerGenerated]
		public float Lfx05XPpPS()
		{
			return PO2PcZteMf;
		}

		[SpecialName]
		[CompilerGenerated]
		public float JcA0YN6yNs()
		{
			return YAkPmjUCpB;
		}

		[SpecialName]
		[CompilerGenerated]
		public Vector4 HD10KN7lTk()
		{
			return P8BPE8SZi9;
		}

		[SpecialName]
		[CompilerGenerated]
		public bool J4k0zYYvIZ()
		{
			return J6nPqkQic5;
		}

		[SpecialName]
		[CompilerGenerated]
		public float kWcPxRSP9E()
		{
			return Wv6PyxNCLU;
		}

		[SpecialName]
		[CompilerGenerated]
		public void FxMP1YVLFb(float float_0)
		{
			Wv6PyxNCLU = float_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public float pyQPaLblmm()
		{
			return YXhPRh1yHJ;
		}

		[SpecialName]
		[CompilerGenerated]
		public void oJIPQVY22e(float float_0)
		{
			YXhPRh1yHJ = float_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public float DPVPCtfUBQ()
		{
			return bYSPJjaHmE;
		}

		[SpecialName]
		[CompilerGenerated]
		public void rJsPU10jI1(float float_0)
		{
			bYSPJjaHmE = float_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public bool Y76PstHj1N()
		{
			return f9YPvHBoTi;
		}

		[SpecialName]
		[CompilerGenerated]
		public void SCoPbHeH3J(bool bool_1)
		{
			f9YPvHBoTi = bool_1;
		}

		[SpecialName]
		[CompilerGenerated]
		public float VMQPDRmEUY()
		{
			return FcQPSmTfS6;
		}

		[SpecialName]
		[CompilerGenerated]
		public void KIpPuy2Xut(float float_0)
		{
			FcQPSmTfS6 = float_0;
		}

		public Notification(string message, float duration, float fadeInTime, float fadeOutTime, Vector4? lineColor, bool useProgressBar)
		{
			KIpPuy2Xut(float.PositiveInfinity);
			KgOPLZBn5G = Guid.NewGuid();
			EDXPFgikuD = message;
			GJaPI6norF = Math.Max(duration, fadeInTime + fadeOutTime);
			kkCPX3tQNs = Math.Min(fadeInTime, Hm206dMqQK() / 2f);
			PO2PcZteMf = Math.Min(fadeOutTime, Hm206dMqQK() / 2f);
			YAkPmjUCpB = (float)ImGui.GetTime();
			P8BPE8SZi9 = lineColor ?? new Vector4(0.02f, 0.71f, 0.83f, 1f);
			J6nPqkQic5 = useProgressBar;
			FxMP1YVLFb(80f);
			SCoPbHeH3J(bool_1: false);
		}

		public bool GetAnimationState(float currentTime, out float alpha, out float fadeInOffsetY, out float lifeProgress)
		{
			float num = currentTime - JcA0YN6yNs();
			float num2 = currentTime - VMQPDRmEUY();
			alpha = 0f;
			fadeInOffsetY = 0f;
			lifeProgress = Math.Clamp(num / Hm206dMqQK(), 0f, 1f);
			if (!(num2 >= 0f))
			{
				if (num < 0f)
				{
					num = 0f;
				}
				if (num < OeK0heKtyG())
				{
					float t = ((!(OeK0heKtyG() <= 0f)) ? (num / OeK0heKtyG()) : 1f);
					alpha = MathHelper.Lerp(0f, 1f, t);
					fadeInOffsetY = MathHelper.Lerp(20f, 0f, t);
					return true;
				}
				if (!(num < Hm206dMqQK() - Lfx05XPpPS()))
				{
					if (!(num < Hm206dMqQK()))
					{
						alpha = 0f;
						return false;
					}
					if (Lfx05XPpPS() > 0f)
					{
						float t2 = (num - (Hm206dMqQK() - Lfx05XPpPS())) / Lfx05XPpPS();
						alpha = MathHelper.Lerp(1f, 0f, t2);
					}
					else
					{
						alpha = 0f;
					}
					return alpha > 0.001f;
				}
				alpha = 1f;
				return true;
			}
			if (!(Lfx05XPpPS() > 0f))
			{
				alpha = 0f;
				return false;
			}
			float num3 = Math.Clamp(num2 / Lfx05XPpPS(), 0f, 1f);
			alpha = MathHelper.Lerp(1f, 0f, num3);
			return num3 < 1f;
		}
	}

	private sealed class MathHelper
	{
		private long long_0;

		private byte byte_0;

		private float float_0;

		private double double_0;

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

		public static float Lerp(float a, float b, float t)
		{
			t = Math.Max(0f, Math.Min(1f, t));
			return a + (b - a) * t;
		}

		public static float LerpSmooth(float a, float b, float factor, float deltaTime)
		{
			float value = 1f - (float)Math.Pow(1f - factor, deltaTime * 60f);
			value = Math.Clamp(value, 0f, 1f);
			if (Math.Abs(a - b) < 0.1f)
			{
				return b;
			}
			return a + (b - a) * value;
		}

		private string method_6(int int_0, float float_1, bool bool_2)
		{
			return "Хитролох_иди_нахуй.______4__02_";
		}
	}

	private static Vector2 vector2_0 = Vector2.Zero;

	private static readonly Vector2 vector2_1 = new Vector2(1f, 1f);

	private static bool bool_0;

	private static readonly Guid guid_0 = Guid.Empty;

	private static readonly List<Notification> list_0 = new List<Notification>();

	private static readonly float float_0 = 15f;

	private static readonly float float_1 = 0.15f;

	private static readonly float float_2 = 4f;

	private static readonly Vector4 vector4_0 = new Vector4(0.02f, 0.71f, 0.83f, 1f);

	private static readonly Vector4 vector4_1 = new Vector4(0.66f, 0.33f, 0.97f, 1f);

	private static readonly Vector4 vector4_2 = new Vector4(0.04f, 0.04f, 0.06f, 0.9f);

	private static readonly Vector4 vector4_3 = new Vector4(1f, 1f, 1f, 0.2f);

	private string string_1;

	private long long_0;

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

	public static void ShowNotification(string message, float duration = 5f, float fadeInTime = 0.3f, float fadeOutTime = 0.5f, Vector4? lineColor = null, bool useProgressBar = false)
	{
		if (!CerberusConfig.Settings.UiCustomizable)
		{
			if (CerberusConfig.Notifications.MaxNotifications > 0 && list_0.Count >= CerberusConfig.Notifications.MaxNotifications)
			{
				list_0.RemoveAt(0);
			}
			list_0.Add(new Notification(message, duration, fadeInTime, fadeOutTime, lineColor, useProgressBar));
		}
	}

	public unsafe void Render()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (!bool_0)
			{
				InitializeDefaultPosition();
				bool_0 = true;
			}
			ValidateAndCorrectAnchorPosition();
			ImFontPtr font = ImGuiFontManager.GetFont("global");
			switch (CerberusConfig.Notifications.FontSize)
			{
			case 2:
				font = ImGuiFontManager.GetFont("global-large");
				break;
			case 1:
				font = ImGuiFontManager.GetFont("global");
				break;
			case 0:
				font = ImGuiFontManager.GetFont("global-small");
				break;
			}
			bool flag = false;
			if (font.Handle != null)
			{
				ImGui.PushFont(font);
				flag = true;
			}
			if (!CerberusConfig.Settings.UiCustomizable)
			{
				if (CerberusConfig.Notifications.Enabled)
				{
					RenderNormalModeNotifications();
				}
			}
			else
			{
				RenderSetupModeNotification();
				list_0.Clear();
			}
			if (flag)
			{
				ImGui.PopFont();
			}
		}
		catch (Exception)
		{
		}
	}

	private static void InitializeDefaultPosition()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			ImGuiViewportPtr mainViewport = ImGui.GetMainViewport();
			Vector2 workPos = ((ImGuiViewportPtr)(ref mainViewport)).WorkPos;
			Vector2 workSize = ((ImGuiViewportPtr)(ref mainViewport)).WorkSize;
			if (workSize.X > 0f && workSize.Y > 0f)
			{
				float x = 15f;
				float y = 15f;
				vector2_0 = workPos + workSize - new Vector2(x, y);
				if (CerberusConfig.Notifications.AnchorPosition == Vector2.Zero)
				{
					CerberusConfig.Notifications.AnchorPosition = vector2_0;
				}
			}
		}
		catch
		{
			vector2_0 = new Vector2(1900f, 1050f);
			if (CerberusConfig.Notifications.AnchorPosition == Vector2.Zero)
			{
				CerberusConfig.Notifications.AnchorPosition = vector2_0;
			}
		}
	}

	private static void ValidateAndCorrectAnchorPosition()
	{
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.Notifications.IgnoreSizeCheck)
		{
			ImGuiViewportPtr mainViewport = ImGui.GetMainViewport();
			Vector2 workPos = ((ImGuiViewportPtr)(ref mainViewport)).WorkPos;
			Vector2 workSize = ((ImGuiViewportPtr)(ref mainViewport)).WorkSize;
			if (CerberusConfig.Notifications.AnchorPosition.X < workPos.X || CerberusConfig.Notifications.AnchorPosition.X > workPos.X + workSize.X || !(CerberusConfig.Notifications.AnchorPosition.Y >= workPos.Y) || CerberusConfig.Notifications.AnchorPosition.Y > workPos.Y + workSize.Y)
			{
				CerberusConfig.Notifications.AnchorPosition = vector2_0;
			}
		}
	}

	private static void RenderSetupModeNotification()
	{
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		string obj = $"Notification##{guid_0}";
		ImGui.SetNextWindowPos(CerberusConfig.Notifications.AnchorPosition, (ImGuiCond)8, vector2_1);
		ImGui.SetNextWindowBgAlpha(0f);
		ImGui.PushStyleVar((ImGuiStyleVar)4, 0f);
		ImGui.PushStyleVar((ImGuiStyleVar)2, new Vector2(24f, 16f));
		if (ImGui.Begin(obj, ref CerberusConfig.Settings.UiCustomizable, (ImGuiWindowFlags)481))
		{
			ImDrawListPtr windowDrawList = ImGui.GetWindowDrawList();
			Vector2 windowPos = ImGui.GetWindowPos();
			Vector2 windowSize = ImGui.GetWindowSize();
			Vector2 vector = windowPos;
			Vector2 vector2 = windowPos + windowSize;
			((ImDrawListPtr)(ref windowDrawList)).AddRectFilled(vector, vector2, ImGui.GetColorU32(vector4_2), 14f);
			((ImDrawListPtr)(ref windowDrawList)).AddRect(vector, vector2, ImGui.GetColorU32(vector4_3), 14f, (ImDrawFlags)0, 2f);
			Vector2 vector3 = new Vector2(vector.X + 6f, vector.Y + 6f);
			Vector2 vector4 = new Vector2(vector.X + 10f, vector2.Y - 6f);
			uint colorU = ImGui.GetColorU32(vector4_0);
			uint colorU2 = ImGui.GetColorU32(vector4_1);
			((ImDrawListPtr)(ref windowDrawList)).AddRectFilledMultiColor(vector3, vector4, colorU, colorU, colorU2, colorU2);
			ImGui.SetCursorPosX(ImGui.GetCursorPosX() + 8f);
			ImGui.PushStyleVar((ImGuiStyleVar)14, new Vector2(8f, 8f));
			ImGui.TextUnformatted(LocalizationStringProvider.GetString("Notification_TestMessage"));
			ImGui.PopStyleVar();
			Vector2 windowPos2 = ImGui.GetWindowPos();
			Vector2 windowSize2 = ImGui.GetWindowSize();
			CerberusConfig.Notifications.AnchorPosition = windowPos2 + windowSize2 * vector2_1;
			ImGui.End();
		}
		ImGui.PopStyleVar(2);
	}

	private static void RenderNormalModeNotifications()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		float DlnPOeHS0b = (float)ImGui.GetTime();
		ImGuiIOPtr iO = ImGui.GetIO();
		float deltaTime = ((ImGuiIOPtr)(ref iO)).DeltaTime;
		List<Notification> tajPdIIjyT = new List<Notification>();
		list_0.RemoveAll(delegate(Notification n)
		{
			float alpha2;
			float fadeInOffsetY2;
			float lifeProgress2;
			bool animationState = n.GetAnimationState(DlnPOeHS0b, out alpha2, out fadeInOffsetY2, out lifeProgress2);
			if (animationState)
			{
				tajPdIIjyT.Add(n);
			}
			return !animationState;
		});
		float num = CerberusConfig.Notifications.AnchorPosition.Y;
		for (int num2 = tajPdIIjyT.Count - 1; num2 >= 0; num2--)
		{
			Notification notification = tajPdIIjyT[num2];
			notification.rJsPU10jI1(num);
			if (!notification.Y76PstHj1N())
			{
				notification.oJIPQVY22e(notification.DPVPCtfUBQ() + notification.kWcPxRSP9E());
				notification.SCoPbHeH3J(bool_1: true);
			}
			notification.oJIPQVY22e(MathHelper.LerpSmooth(notification.pyQPaLblmm(), notification.DPVPCtfUBQ(), float_1, deltaTime));
			notification.GetAnimationState(DlnPOeHS0b, out var alpha, out var fadeInOffsetY, out var lifeProgress);
			RenderSingleNotification(notification, alpha, fadeInOffsetY, lifeProgress, DlnPOeHS0b);
			if (alpha > 0.01f)
			{
				num -= notification.kWcPxRSP9E() + float_0;
			}
		}
	}

	private static void RenderSingleNotification(Notification notification, float alpha, float fadeInOffsetY, float lifeProgress, float currentTime)
	{
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		float x = CerberusConfig.Notifications.AnchorPosition.X;
		float y = notification.pyQPaLblmm() + fadeInOffsetY;
		ImGui.SetNextWindowPos(new Vector2(x, y), (ImGuiCond)1, vector2_1);
		ImGui.SetNextWindowBgAlpha(0f);
		string obj = $"Notification##{notification.EbK0HVUsSt()}";
		ImGui.PushStyleVar((ImGuiStyleVar)4, 0f);
		ImGui.PushStyleVar((ImGuiStyleVar)2, new Vector2(28f, 18f));
		ImGui.SetNextWindowSizeConstraints(new Vector2(320f, 0f), new Vector2(600f, 200f));
		if (ImGui.Begin(obj, (ImGuiWindowFlags)201199))
		{
			if (ImGui.IsWindowHovered() && ImGui.IsMouseClicked((ImGuiMouseButton)0) && float.IsPositiveInfinity(notification.VMQPDRmEUY()))
			{
				notification.KIpPuy2Xut(currentTime);
			}
			ImDrawListPtr windowDrawList = ImGui.GetWindowDrawList();
			Vector2 windowPos = ImGui.GetWindowPos();
			Vector2 windowSize = ImGui.GetWindowSize();
			Vector2 vector = windowPos;
			Vector2 vector2 = windowPos + windowSize;
			Vector4 vector3 = vector4_2;
			vector3.W *= alpha;
			((ImDrawListPtr)(ref windowDrawList)).AddRectFilled(vector, vector2, ImGui.GetColorU32(vector3), 14f);
			Vector4 vector4 = vector4_3;
			vector4.W *= alpha;
			((ImDrawListPtr)(ref windowDrawList)).AddRect(vector, vector2, ImGui.GetColorU32(vector4), 14f, (ImDrawFlags)0, 2f);
			Vector2 vector5 = new Vector2(vector.X + 6f, vector.Y + 6f);
			Vector2 vector6 = new Vector2(vector.X + 10f, vector2.Y - 6f);
			Vector4 vector7 = notification.HD10KN7lTk();
			vector7.W *= alpha;
			Vector4 vector8 = vector4_1;
			vector8.W *= alpha;
			uint colorU = ImGui.GetColorU32(vector7);
			uint colorU2 = ImGui.GetColorU32(vector8);
			((ImDrawListPtr)(ref windowDrawList)).AddRectFilledMultiColor(vector5, vector6, colorU, colorU, colorU2, colorU2);
			if (notification.J4k0zYYvIZ() && alpha > 0.001f)
			{
				float num = 4f;
				Vector2 vector9 = new Vector2(vector.X + 16f, vector2.Y - num - 8f);
				Vector2 vector10 = new Vector2(vector2.X - 16f, vector2.Y - 8f);
				Vector4 vector11 = new Vector4(0.2f, 0.2f, 0.2f, alpha * 0.5f);
				((ImDrawListPtr)(ref windowDrawList)).AddRectFilled(vector9, vector10, ImGui.GetColorU32(vector11), 2f);
				float num2 = (vector10.X - vector9.X) * (1f - lifeProgress);
				Vector2 vector12 = new Vector2(vector9.X + num2, vector10.Y);
				Vector4 vector13 = vector4_0;
				vector13.W *= alpha;
				Vector4 vector14 = vector4_1;
				vector14.W *= alpha;
				uint colorU3 = ImGui.GetColorU32(vector13);
				uint colorU4 = ImGui.GetColorU32(vector14);
				((ImDrawListPtr)(ref windowDrawList)).AddRectFilledMultiColor(vector9, vector12, colorU3, colorU4, colorU4, colorU3);
			}
			ImGui.SetCursorPosX(ImGui.GetCursorPosX() + 8f);
			Vector2 cursorScreenPos = ImGui.GetCursorScreenPos();
			Vector4 vector15 = new Vector4(0f, 0f, 0f, alpha * 0.8f);
			((ImDrawListPtr)(ref windowDrawList)).AddText(cursorScreenPos + new Vector2(1f, 1f), ImGui.GetColorU32(vector15), notification.Message);
			Vector4 vector16 = new Vector4(1f, 1f, 1f, alpha);
			ImGui.PushStyleColor((ImGuiCol)0, vector16);
			ImGui.PushStyleVar((ImGuiStyleVar)14, new Vector2(8f, 8f));
			ImGui.TextUnformatted(notification.Message);
			ImGui.PopStyleVar();
			ImGui.PopStyleColor();
			notification.FxMP1YVLFb(ImGui.GetWindowHeight());
			ImGui.End();
		}
		ImGui.PopStyleVar(2);
	}
}
