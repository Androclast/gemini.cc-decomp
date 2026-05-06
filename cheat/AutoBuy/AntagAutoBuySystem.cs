using Robust.Shared.GameObjects;
using AntagAutoBuyEngine;

namespace AntagAutoBuySystem;

public sealed class AntagAutoBuySystem : EntitySystem
{
	private float float_0;

	private char char_0;

	private string string_1;

	private bool bool_1;

	private float float_2;

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

	private bool Boolean_0
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	private float Single_0
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	public override void Update(float frameTime)
	{
		((EntitySystem)this).Update(frameTime);
		if (AntagAutoBuyEngine.bool_0)
		{
			float_0 += frameTime;
			if (float_0 >= 0.05f)
			{
				float_0 = 0f;
				AntagAutoBuyEngine.Update(frameTime);
			}
		}
	}
}
