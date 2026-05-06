using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using Robust.Client.Graphics;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Player;
using Robust.Shared.Random;
using Robust.Shared.Timing;
using DamageNumbersOverlay;
using CerberusConfig;

namespace DamageNumbersHook;

public sealed class DamageNumbersHook : EntitySystem
{
	[Dependency]
	private readonly IOverlayManager ioverlayManager_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly SharedTransformSystem sharedTransformSystem_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly IRobustRandom irobustRandom_0;

	private DamageNumbersOverlay? gclass222_0;

	private readonly Dictionary<EntityUid, float> dictionary_0 = new Dictionary<EntityUid, float>();

	private readonly Dictionary<EntityUid, TimeSpan> dictionary_1 = new Dictionary<EntityUid, TimeSpan>();

	private static Type? type_0;

	private static Type? type_1;

	private static bool bool_0;

	private byte byte_0;

	private string string_0;

	private double double_0;

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

	private static void EnsureTypesInitialized()
	{
		if (bool_0)
		{
			return;
		}
		bool_0 = true;
		try
		{
			Assembly assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault((Assembly a) => a.GetName().Name == "Content.Shared");
			if (assembly != null)
			{
				type_0 = assembly.GetType("Content.Shared.Damage.Components.DamageableComponent");
				type_1 = assembly.GetType("Content.Shared.Damage.DamageChangedEvent");
				if (type_0 != null)
				{
					_ = type_1 != null;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
		EnsureTypesInitialized();
		gclass222_0 = new DamageNumbersOverlay();
		ioverlayManager_0.AddOverlay((Overlay)(object)gclass222_0);
		if (!(type_0 != null) || !(type_1 != null))
		{
			return;
		}
		try
		{
			MethodInfo methodInfo = ((DamageNumbersHook)(object)typeof(EntitySystem)).method_0().FirstOrDefault((MethodInfo m) => m.Name == "SubscribeLocalEvent" && m.IsGenericMethodDefinition && m.GetGenericArguments().Length == 2 && m.GetParameters().Length == 1);
			if (methodInfo != null)
			{
				MethodInfo methodInfo2 = methodInfo.MakeGenericMethod(type_0, type_1);
				Type type = typeof(EntityEventHandler<>).MakeGenericType(type_1);
				MethodInfo method = ((object)this).GetType().GetMethod("OnDamageChangedDynamic", BindingFlags.Instance | BindingFlags.NonPublic);
				if (method != null)
				{
					Delegate obj = Delegate.CreateDelegate(type, this, method);
					methodInfo2.Invoke(this, new object[1] { obj });
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public override void Shutdown()
	{
		((EntitySystem)this).Shutdown();
		if (gclass222_0 != null)
		{
			ioverlayManager_0.RemoveOverlay((Overlay)(object)gclass222_0);
			gclass222_0 = null;
		}
	}

	private void OnDamageChangedDynamic(EntityUid uid, object component, object args)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.Misc.DamageOverlayEnabled || gclass222_0 == null)
		{
			return;
		}
		ICommonSession localSession = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
		EntityUid? val = ((localSession == null) ? ((EntityUid?)null) : localSession.AttachedEntity);
		if (val.HasValue && uid == val.GetValueOrDefault())
		{
			return;
		}
		float num = 0f;
		try
		{
			PropertyInfo property = component.GetType().GetProperty("TotalDamage", BindingFlags.Instance | BindingFlags.Public);
			if (property != null)
			{
				num = NumericValue.FromObject(property.GetValue(component)).ToFloat();
			}
		}
		catch
		{
			return;
		}
		if (num > 0f)
		{
			if (dictionary_0.TryGetValue(uid, out var value))
			{
				float num2 = num - value;
				if (Math.Abs(num2) < 0.5f)
				{
					return;
				}
				TimeSpan curTime = igameTiming_0.CurTime;
				if (!dictionary_1.TryGetValue(uid, out var value2) || (curTime - value2).TotalSeconds >= 0.15)
				{
					dictionary_0[uid] = num;
					dictionary_1[uid] = curTime;
					TransformComponent val2 = default(TransformComponent);
					if (((EntitySystem)this).TryComp<TransformComponent>(uid, ref val2))
					{
						Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(val2);
						double num3 = irobustRandom_0.NextDouble() * 2.0 * Math.PI;
						double num4 = irobustRandom_0.NextDouble() * 0.5;
						float x = (float)(Math.Cos(num3) * num4);
						float y = (float)(Math.Sin(num3) * num4);
						worldPosition += new Vector2(x, y);
						bool isHealing = num2 < 0f;
						float damage = Math.Abs(num2);
						gclass222_0.AddDamageNumber(worldPosition, damage, isHealing);
					}
				}
				else
				{
					dictionary_0[uid] = num;
				}
			}
			else
			{
				dictionary_0[uid] = num;
			}
		}
		else
		{
			dictionary_0.Remove(uid);
			dictionary_1.Remove(uid);
		}
	}

	public MethodInfo[] method_0()
	{
		return ((Type)this).GetMethods();
	}

	private string method_10(long long_1, long long_2)
	{
		return "Хитролох_иди_нахуй._2__6___97_________2__";
	}
}
