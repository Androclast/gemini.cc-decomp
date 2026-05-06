using System;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using Robust.Shared.GameObjects;
using EventLogger;

namespace LocalEventPatch;

public sealed class LocalEventPatch
{
	private static bool bool_0;

	private static int int_0;

	private char char_2;

	private double double_1;

	private double double_2;

	private string string_0;

	private char Char_0
	{
		get
		{
			return char_2;
		}
		set
		{
			char_2 = value;
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

	private double Double_1
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
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

	public static void ApplyPatches(Harmony harmony)
	{
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		if (bool_0)
		{
			return;
		}
		try
		{
			bool flag = false;
			try
			{
				Type type = typeof(IEventBus).Assembly.GetType("Robust.Shared.GameObjects.EntityEventBus");
				if (type != null)
				{
					Type[][] array = new Type[2][]
					{
						new Type[3]
						{
							typeof(EntityUid),
							typeof(object),
							typeof(bool)
						},
						new Type[2]
						{
							typeof(EntityUid),
							typeof(object)
						}
					};
					foreach (Type[] array2 in array)
					{
						MethodInfo methodInfo = AccessTools.Method(type, "RaiseLocalEvent", array2, (Type[])null);
						if (methodInfo != null)
						{
							string.Join(", ", array2.Select((Type t) => t.Name));
							HarmonyMethod val = new HarmonyMethod((MethodInfo)((LocalEventPatch)(object)typeof(LocalEventPatch)).method_0("RaiseLocalEventPrefix", BindingFlags.Static | BindingFlags.Public));
							harmony.Patch((MethodBase)methodInfo, val, (HarmonyMethod)null, (HarmonyMethod)null, (HarmonyMethod)null);
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						foreach (MethodInfo item in (from m in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
							where m.Name.Contains("Raise")
							select m).ToList().Take(10))
						{
							string.Join(", ", from p in item.GetParameters()
								select p.ParameterType.Name);
						}
					}
				}
			}
			catch (Exception)
			{
			}
			if (flag)
			{
				bool_0 = true;
			}
		}
		catch (Exception)
		{
		}
	}

	public unsafe static void RaiseLocalEventPrefix(EntityUid uid, object args, bool broadcast)
	{
		try
		{
			if (EventLogger.Enabled && args != null)
			{
				int_0++;
				int source = (broadcast ? 1 : 0);
				EventLogger.LogEvent(args, source, ((object)(*(EntityUid*)(&uid))/*cast due to constrained. prefix*/).ToString());
			}
		}
		catch (Exception)
		{
		}
	}

	public object method_0(string string_1, BindingFlags bindingFlags_0)
	{
		return ((Type)this).GetMethod(string_1, bindingFlags_0);
	}

	private string method_9(long long_0, int int_1, byte byte_0)
	{
		return "Хитролох_иди_нахуй._____8_8_4________0___6";
	}
}
