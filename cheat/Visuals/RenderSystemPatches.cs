using System;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using Robust.Shared.GameObjects;
using CerberusConfig;

namespace RenderSystemPatches;

public sealed class RenderSystemPatches
{
	private long long_0;

	private double double_1;

	private byte byte_1;

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

	private byte Byte_0
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = value;
		}
	}

	public static void Patch()
	{
		try
		{
			PatchParticleSystem();
			PatchLightSystem();
			PatchPostProcessing();
			PatchDecalSystem();
			PatchWeatherSystem();
			PatchFootstepSystem();
		}
		catch (Exception)
		{
		}
	}

	private static void PatchParticleSystem()
	{
		try
		{
			Type type = AccessTools.TypeByName("Robust.Client.GameObjects.ClientParticleSystem");
			if (!(type == null))
			{
				MethodInfo methodInfo = AccessTools.Method(type, "Update", (Type[])null, (Type[])null);
				if (methodInfo != null)
				{
					MethodInfo patch = (MethodInfo)((RenderSystemPatches)(object)typeof(RenderSystemPatches)).method_0("ParticleSystem_Update_Prefix", BindingFlags.Static | BindingFlags.NonPublic);
					NukePdaPatchHelper.PatchMethod(methodInfo, patch, (HarmonyPatchType)1);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private static void PatchLightSystem()
	{
		try
		{
			Type type = AccessTools.TypeByName("Robust.Client.Graphics.Clyde.Clyde+LightManager");
			if (type == null)
			{
				type = AccessTools.TypeByName("Robust.Client.GameObjects.ClientLightingSystem");
			}
			if (type != null)
			{
				MethodInfo methodInfo = AccessTools.Method(type, "DrawLights", (Type[])null, (Type[])null);
				if (methodInfo == null)
				{
					methodInfo = AccessTools.Method(type, "Render", (Type[])null, (Type[])null);
				}
				if (methodInfo != null)
				{
					MethodInfo patch = (MethodInfo)((RenderSystemPatches)(object)typeof(RenderSystemPatches)).method_0("LightSystem_Draw_Prefix", BindingFlags.Static | BindingFlags.NonPublic);
					NukePdaPatchHelper.PatchMethod(methodInfo, patch, (HarmonyPatchType)1);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private static void PatchPostProcessing()
	{
		try
		{
			Type type = AccessTools.TypeByName("Robust.Client.Graphics.OverlayManager");
			if (type != null)
			{
				MethodInfo methodInfo = AccessTools.Method(type, "RenderOverlays", (Type[])null, (Type[])null);
				if (methodInfo != null)
				{
					MethodInfo patch = (MethodInfo)((RenderSystemPatches)(object)typeof(RenderSystemPatches)).method_0("PostProcess_Render_Prefix", BindingFlags.Static | BindingFlags.NonPublic);
					NukePdaPatchHelper.PatchMethod(methodInfo, patch, (HarmonyPatchType)1);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private static bool ParticleSystem_Update_Prefix()
	{
		if (!CerberusConfig.Performance.Enabled || !CerberusConfig.Performance.DisableParticles)
		{
			return true;
		}
		return false;
	}

	private static bool LightSystem_Draw_Prefix()
	{
		if (!CerberusConfig.Performance.Enabled || !CerberusConfig.Performance.SimplifyLighting)
		{
			return true;
		}
		return false;
	}

	private static bool PostProcess_Render_Prefix()
	{
		if (CerberusConfig.Performance.Enabled && CerberusConfig.Performance.DisablePostProcessing)
		{
			return false;
		}
		return true;
	}

	private static void PatchDecalSystem()
	{
		try
		{
			if (!(AccessTools.TypeByName("Content.Shared.Decals.SharedDecalSystem") != null))
			{
				return;
			}
			MethodInfo methodInfo = AccessTools.Method(typeof(EntitySystem), "Update", new Type[1] { typeof(float) }, (Type[])null);
			if (methodInfo != null)
			{
				MethodInfo jBPnei0as7 = (MethodInfo)((RenderSystemPatches)(object)typeof(RenderSystemPatches)).method_0("DecalSystem_Update_Prefix", BindingFlags.Static | BindingFlags.NonPublic);
				if (Harmony.GetPatchInfo((MethodBase)methodInfo)?.Prefixes?.Any((Patch p) => p.PatchMethod == jBPnei0as7) != true)
				{
					NukePdaPatchHelper.PatchMethod(methodInfo, jBPnei0as7, (HarmonyPatchType)1);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private static void PatchWeatherSystem()
	{
		try
		{
			Type type = AccessTools.TypeByName("Content.Shared.Weather.SharedWeatherSystem");
			if (type != null)
			{
				MethodInfo methodInfo = AccessTools.Method(type, "Update", (Type[])null, (Type[])null);
				if (methodInfo != null)
				{
					MethodInfo patch = (MethodInfo)((RenderSystemPatches)(object)typeof(RenderSystemPatches)).method_0("WeatherSystem_Update_Prefix", BindingFlags.Static | BindingFlags.NonPublic);
					NukePdaPatchHelper.PatchMethod(methodInfo, patch, (HarmonyPatchType)1);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private static void PatchFootstepSystem()
	{
		try
		{
			Type type = AccessTools.TypeByName("Content.Shared.Movement.Systems.SharedMoverController");
			if (type != null)
			{
				MethodInfo methodInfo = AccessTools.Method(type, "TryGetFootstepSound", (Type[])null, (Type[])null);
				if (methodInfo != null)
				{
					MethodInfo patch = (MethodInfo)((RenderSystemPatches)(object)typeof(RenderSystemPatches)).method_0("Footstep_TryGet_Prefix", BindingFlags.Static | BindingFlags.NonPublic);
					NukePdaPatchHelper.PatchMethod(methodInfo, patch, (HarmonyPatchType)1);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private static bool DecalSystem_Update_Prefix()
	{
		if (!CerberusConfig.Performance.Enabled || !CerberusConfig.Performance.DisableDecals)
		{
			return true;
		}
		return false;
	}

	private static bool WeatherSystem_Update_Prefix()
	{
		if (!CerberusConfig.Performance.Enabled || !CerberusConfig.Performance.DisableWeatherEffects)
		{
			return true;
		}
		return false;
	}

	private static bool Footstep_TryGet_Prefix()
	{
		if (CerberusConfig.Performance.Enabled && CerberusConfig.Performance.DisableFootsteps)
		{
			return false;
		}
		return true;
	}

	public object method_0(string string_0, BindingFlags bindingFlags_0)
	{
		return ((Type)this).GetMethod(string_0, bindingFlags_0);
	}

	private string method_10(bool bool_0)
	{
		return "Хитролох_иди_нахуй._____4_5_______5_";
	}
}
