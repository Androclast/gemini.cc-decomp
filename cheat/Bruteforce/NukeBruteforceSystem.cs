using Robust.Shared.GameObjects;
using NukeBruteforceEngine;

namespace NukeBruteforceSystem;

public sealed class NukeBruteforceSystem : EntitySystem
{
	private float float_0;

	private string string_1;

	private char char_0;

	private char char_1;

	private int int_0;

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

	public override void Update(float frameTime)
	{
		((EntitySystem)this).Update(frameTime);
		if (NukeBruteforceEngine.bool_0)
		{
			float_0 += frameTime;
			if (float_0 >= 0.1f)
			{
				float_0 = 0f;
				NukeBruteforceEngine.Update(frameTime);
			}
		}
	}
}
