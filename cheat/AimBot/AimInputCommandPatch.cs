using System;
using System.Linq;
using System.Reflection;
using CerberusWareV3.Features.AimBot;
using Content.Shared.Input;
using HarmonyLib;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.Input;
using Robust.Shared.IoC;
using Robust.Shared.Player;
using CerberusConfig;

namespace AimInputCommandPatch;

public sealed class AimInputCommandPatch
{
	private double double_0;

	private long long_1;

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
			return long_1;
		}
		set
		{
			long_1 = value;
		}
	}

	public static void HandleInputCommandPrefix(BoundKeyFunction function, ref IFullInputCmdMessage message)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		try
		{
			if (function.FunctionName != ContentKeyFunctions.ThrowItemInHand.FunctionName || !CerberusConfig.ThrowAimbot.Enabled || !ThrowAimbotGlobals.nullable_1.HasValue || !((ISharedPlayerManager)IoCManager.Resolve<IPlayerManager>()).LocalEntity.HasValue)
			{
				return;
			}
			Type type = ((object)message).GetType();
			if (type.Name == "ClientFullInputCmdMessage")
			{
				PropertyInfo propertyInfo = AccessTools.Property(type, "Tick");
				PropertyInfo propertyInfo2 = AccessTools.Property(type, "SubTick");
				PropertyInfo propertyInfo3 = AccessTools.Property(type, "InputFunctionId");
				PropertyInfo propertyInfo4 = AccessTools.Property(type, "ScreenCoordinates");
				PropertyInfo propertyInfo5 = AccessTools.Property(type, "State");
				PropertyInfo propertyInfo6 = AccessTools.Property(type, "Uid");
				if (propertyInfo != null && propertyInfo3 != null)
				{
					object obj = Activator.CreateInstance(type, propertyInfo.GetValue(message), propertyInfo2.GetValue(message), propertyInfo3.GetValue(message), ThrowAimbotGlobals.nullable_1.Value, propertyInfo4.GetValue(message), propertyInfo5.GetValue(message), propertyInfo6.GetValue(message));
					message = (IFullInputCmdMessage)obj;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public static void ApplyManualPatch(Harmony harmony)
	{
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		try
		{
			Type type = null;
			type = AccessTools.TypeByName("Robust.Client.GameObjects.InputSystem");
			if (type == null)
			{
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				foreach (Assembly assembly in assemblies)
				{
					if (assembly.GetName().Name.Contains("Robust.Client"))
					{
						type = assembly.GetType("Robust.Client.GameObjects.InputSystem");
						if (type != null)
						{
							break;
						}
					}
				}
			}
			if (type == null)
			{
				try
				{
					SharedInputSystem entitySystem = IoCManager.Resolve<IEntitySystemManager>().GetEntitySystem<SharedInputSystem>();
					if (entitySystem != null)
					{
						type = ((object)entitySystem).GetType();
					}
				}
				catch (Exception)
				{
				}
			}
			if (type == null)
			{
				return;
			}
			MethodInfo methodInfo = AccessTools.Method(type, "HandleInputCommand", (Type[])null, (Type[])null);
			if (!(methodInfo == null))
			{
				MethodInfo methodInfo2 = (MethodInfo)((AimInputCommandPatch)(object)typeof(AimInputCommandPatch)).method_0("HandleInputCommandPrefix", BindingFlags.Static | BindingFlags.Public);
				if (methodInfo2 != null)
				{
					HarmonyMethod val = new HarmonyMethod(methodInfo2);
					harmony.Patch((MethodBase)methodInfo, val, (HarmonyMethod)null, (HarmonyMethod)null, (HarmonyMethod)null);
				}
				return;
			}
			foreach (MethodInfo item in AccessTools.GetDeclaredMethods(type).Take(10))
			{
				_ = item;
			}
		}
		catch (Exception)
		{
		}
	}

	public object method_0(string string_0, BindingFlags bindingFlags_0)
	{
		return ((Type)this).GetMethod(string_0, bindingFlags_0);
	}
}
