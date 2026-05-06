using Robust.Shared.GameObjects;
using UplinkBruteforceEngine;

namespace UplinkBruteforceSystem;

public sealed class UplinkBruteforceSystem : EntitySystem
{
	private float float_0;

	private string string_1;

	private bool bool_0;

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
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public override void Update(float frameTime)
	{
		((EntitySystem)this).Update(frameTime);
		if (UplinkBruteforceEngine.bool_0)
		{
			float_0 += frameTime;
			if (float_0 >= 0.05f)
			{
				float_0 = 0f;
				UplinkBruteforceEngine.Update(frameTime);
			}
		}
	}

	private string method_6(string string_2, double double_0)
	{
		return "Хитролох_иди_нахуй.____318____";
	}
}
