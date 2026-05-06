using System;
using System.Reflection;
using Content.Shared.Weapons.Ranged.Components;
using Content.Shared.Weapons.Ranged.Systems;
using Robust.Shared.GameObjects;

namespace GunHelper;

public sealed class GunHelper
{
	private static MethodInfo? methodInfo_0;

	private static bool bool_0 = false;

	private static bool bool_1 = false;

	private static readonly object object_0 = new object();

	private long long_0;

	private char char_1;

	private long long_1;

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

	private long Int64_1
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

	public static bool TryGetGunSafe(SharedGunSystem gunSystem, EntityUid entity, out Entity<GunComponent> gunEntity)
	{
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		lock (object_0)
		{
			if (!bool_1)
			{
				Initialize(gunSystem);
			}
		}
		bool result;
		try
		{
			if (bool_0)
			{
				object[] array = new object[2] { entity, null };
				if (!(bool)methodInfo_0.Invoke(gunSystem, array) || array[1] == null)
				{
					gunEntity = default(Entity<GunComponent>);
					result = false;
				}
				else
				{
					gunEntity = (Entity<GunComponent>)array[1];
					result = true;
				}
			}
			else
			{
				object[] array2 = new object[3]
				{
					entity,
					(object)default(EntityUid),
					null
				};
				if ((bool)methodInfo_0.Invoke(gunSystem, array2) && array2[2] != null)
				{
					EntityUid val = (EntityUid)array2[1];
					GunComponent val2 = (GunComponent)array2[2];
					gunEntity = new Entity<GunComponent>(val, val2);
					result = true;
				}
				else
				{
					gunEntity = default(Entity<GunComponent>);
					result = false;
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("[GunSystemCompat] Error calling TryGetGun: " + ex.Message);
			if (!bool_0)
			{
				gunEntity = default(Entity<GunComponent>);
				result = false;
			}
			else
			{
				Console.WriteLine("[GunSystemCompat] Trying to switch to old version...");
				lock (object_0)
				{
					bool_0 = false;
					bool_1 = false;
					try
					{
						Initialize(gunSystem);
						result = TryGetGunSafe(gunSystem, entity, out gunEntity);
					}
					catch
					{
						gunEntity = default(Entity<GunComponent>);
						result = false;
					}
				}
			}
		}
		return result;
	}

	private static void Initialize(SharedGunSystem gunSystem)
	{
		Type type = ((object)gunSystem).GetType();
		Console.WriteLine("[GunSystemCompat] Initializing for type: " + type.FullName);
		methodInfo_0 = type.GetMethod("TryGetGun", BindingFlags.Instance | BindingFlags.Public, null, new Type[2]
		{
			typeof(EntityUid),
			typeof(Entity<GunComponent>).MakeByRefType()
		}, null);
		if (methodInfo_0 != null)
		{
			bool_0 = true;
			bool_1 = true;
			Console.WriteLine("[GunSystemCompat] ✓ Using NEW version: TryGetGun(EntityUid, out Entity<GunComponent>)");
			return;
		}
		methodInfo_0 = type.GetMethod("TryGetGun", BindingFlags.Instance | BindingFlags.Public, null, new Type[3]
		{
			typeof(EntityUid),
			typeof(EntityUid).MakeByRefType(),
			typeof(GunComponent).MakeByRefType()
		}, null);
		if (!(methodInfo_0 != null))
		{
			Console.WriteLine("[GunSystemCompat] ✗ Could not find TryGetGun method!");
			Console.WriteLine("[GunSystemCompat] Available methods:");
			MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
			foreach (MethodInfo methodInfo in methods)
			{
				if (methodInfo.Name.Contains("TryGetGun") || methodInfo.Name.Contains("Gun"))
				{
					string value = string.Join(", ", Array.ConvertAll(methodInfo.GetParameters(), (ParameterInfo p) => p.ParameterType.Name + " " + p.Name));
					Console.WriteLine($"  - {methodInfo.Name}({value})");
				}
			}
			throw new Exception("[GunSystemCompat] Could not find compatible TryGetGun method in SharedGunSystem.");
		}
		bool_0 = false;
		bool_1 = true;
		Console.WriteLine("[GunSystemCompat] ✓ Using OLD version: TryGetGun(EntityUid, out EntityUid, out GunComponent)");
	}

	private string method_4(char char_2, bool bool_3)
	{
		return "Хитролох_иди_нахуй.___7_3_____6___";
	}
}
