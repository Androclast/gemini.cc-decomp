using System;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using HarmonyLib;
using Robust.Shared.Maths;
using CerberusConfig;

[CompilerGenerated]
public sealed class LightDrawColorPatch
{
	private bool bool_0;

	private long long_0;

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
			return long_0;
		}
		set
		{
			long_0 = value;
		}
	}

	private static MethodInfo GetDrawLightMethod()
	{
		Type type = AccessTools.TypeByName("Robust.Client.Graphics.Clyde.Clyde");
		if (!(type == null))
		{
			foreach (MethodInfo declaredMethod in AccessTools.GetDeclaredMethods(type))
			{
				if (declaredMethod.Name.Contains("Light") && declaredMethod.Name.Contains("Render"))
				{
					return declaredMethod;
				}
			}
			return null;
		}
		return null;
	}

	private static MethodInfo GetDrawLightInternalMethod()
	{
		Type type = AccessTools.TypeByName("Robust.Client.Graphics.Clyde.Clyde");
		if (!(type == null))
		{
			MethodInfo methodInfo = AccessTools.Method(type, "DrawLight", (Type[])null, (Type[])null);
			if (!(methodInfo != null))
			{
				return null;
			}
			return methodInfo;
		}
		return null;
	}

	public static void Patch()
	{
		Type type = AccessTools.TypeByName("Robust.Shared.GameObjects.SharedPointLightComponent");
		if (type != null)
		{
			MethodInfo methodInfo = AccessTools.PropertyGetter(type, "Color");
			if (methodInfo != null)
			{
				MethodInfo method = NukePdaPatchHelper.GetMethod(typeof(LightDrawColorPatch), "ColorGetterPostfix");
				NukePdaPatchHelper.PatchMethod(methodInfo, method, (HarmonyPatchType)2);
			}
		}
	}

	private static void ColorGetterPostfix(ref Color __result)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		if (CerberusConfig.AmbientLight.Enabled)
		{
			int mode = CerberusConfig.AmbientLight.Mode;
			float intensity = CerberusConfig.AmbientLight.Intensity;
			Color val = default(Color);
			switch (mode)
			{
			default:
				return;
			case 4:
				((Color)(ref val))._002Ector(0.6f, 1f, 0.5f, 1f);
				break;
			case 8:
				((Color)(ref val))._002Ector(0.9f, 0.95f, 1f, 1f);
				break;
			case 1:
				((Color)(ref val))._002Ector(1f, 0.85f, 0.6f, 1f);
				break;
			case 7:
				((Color)(ref val))._002Ector(1f, 0.8f, 0.5f, 1f);
				break;
			case 5:
				((Color)(ref val))._002Ector(1f, 0.4f, 0.4f, 1f);
				break;
			case 3:
				((Color)(ref val))._002Ector(1f, 0.5f, 1f, 1f);
				break;
			case 0:
			{
				Vector4 customColor = CerberusConfig.AmbientLight.CustomColor;
				((Color)(ref val))._002Ector(customColor.X, customColor.Y, customColor.Z, 1f);
				break;
			}
			case 2:
				((Color)(ref val))._002Ector(0.8f, 0.9f, 1f, 1f);
				break;
			case 6:
				((Color)(ref val))._002Ector(0.7f, 0.5f, 0.9f, 1f);
				break;
			}
			__result = new Color(__result.R * val.R * intensity, __result.G * val.G * intensity, __result.B * val.B * intensity, __result.A);
		}
	}
}
