using System;
using System.Collections.Generic;
using System.Numerics;
using Robust.Client.Graphics;
using Robust.Client.ResourceManagement;
using Robust.Shared.Enums;
using Robust.Shared.IoC;
using Robust.Shared.Maths;
using Robust.Shared.Timing;
using CerberusConfig;

namespace DamageNumbersOverlay;

public sealed class DamageNumbersOverlay : Overlay
{
	private class DamageNumber
	{
		public Vector2 zqq210dNc6;

		public float vgL2VmN4W9;

		public bool CfQ2aHRyei;

		public TimeSpan jLr2QsWlaN;

		public Vector2 PRR2WvxkUC;

		private int int_0;

		private string string_0;

		private bool bool_0;

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
	}

	[Dependency]
	private readonly IEyeManager ieyeManager_0;

	[Dependency]
	private readonly IResourceCache iresourceCache_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	private readonly List<DamageNumber> list_0 = new List<DamageNumber>();

	private Font? font_0;

	private int int_0 = 24;

	private char char_1;

	private float float_0;

	private byte byte_0;

	public override OverlaySpace Space => (OverlaySpace)2;

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

	public DamageNumbersOverlay()
	{
		IoCManager.InjectDependencies<DamageNumbersOverlay>(this);
	}

	public void AddDamageNumber(Vector2 worldPos, float damage, bool isHealing)
	{
		list_0.Add(new DamageNumber
		{
			zqq210dNc6 = worldPos,
			vgL2VmN4W9 = damage,
			CfQ2aHRyei = isHealing,
			jLr2QsWlaN = igameTiming_0.CurTime,
			PRR2WvxkUC = new Vector2(0f, 0f)
		});
	}

	private void EnsureFont()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		if (font_0 == null || int_0 != 24)
		{
			FontResource val = default(FontResource);
			if (iresourceCache_0.TryGetResource<FontResource>("/Fonts/NotoSans/NotoSans-Bold.ttf", ref val))
			{
				font_0 = (Font?)new VectorFont(val, 24);
				int_0 = 24;
			}
			else if (iresourceCache_0.TryGetResource<FontResource>("/Fonts/NotoSans/NotoSans-Regular.ttf", ref val))
			{
				font_0 = (Font?)new VectorFont(val, 24);
				int_0 = 24;
			}
		}
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.Misc.DamageOverlayEnabled)
		{
			return;
		}
		EnsureFont();
		if (font_0 == null)
		{
			return;
		}
		DrawingHandleScreen screenHandle = ((OverlayDrawArgs)(ref args)).ScreenHandle;
		TimeSpan curTime = igameTiming_0.CurTime;
		Color val2 = default(Color);
		for (int num = list_0.Count - 1; num >= 0; num--)
		{
			DamageNumber damageNumber = list_0[num];
			float num2 = (float)(curTime - damageNumber.jLr2QsWlaN).TotalSeconds;
			if (num2 <= 2f)
			{
				float num3 = num2 / 2f;
				damageNumber.PRR2WvxkUC = new Vector2(0f, (0f - num2) * 60f);
				float num4 = 1f - num3;
				Vector2 vector = ieyeManager_0.WorldToScreen(damageNumber.zqq210dNc6);
				vector += damageNumber.PRR2WvxkUC;
				Color val = ((!damageNumber.CfQ2aHRyei) ? new Color(1f, 0.2f, 0.2f, num4) : new Color(0.2f, 1f, 0.2f, num4));
				string text = ((!damageNumber.CfQ2aHRyei) ? $"-{(int)damageNumber.vgL2VmN4W9}" : $"+{(int)damageNumber.vgL2VmN4W9}");
				((Color)(ref val2))._002Ector(0f, 0f, 0f, num4 * 0.8f);
				screenHandle.DrawString(font_0, vector + new Vector2(2f, 2f), text, val2);
				screenHandle.DrawString(font_0, vector, text, val);
			}
			else
			{
				list_0.RemoveAt(num);
			}
		}
	}
}
