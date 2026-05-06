using System;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Content.Shared.Weapons.Ranged.Components;
using Content.Shared.Weapons.Ranged.Systems;
using Robust.Shared.Configuration;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Network;
using Robust.Shared.Physics.Components;
using Robust.Shared.Physics.Systems;
using Robust.Shared.Timing;
using GunHelper;
using CerberusConfig;

[CompilerGenerated]
public sealed class ProjectilePredictor
{
	[Dependency]
	private static IEntityManager ientityManager_0;

	private static SharedTransformSystem sharedTransformSystem_0;

	private static SharedPhysicsSystem sharedPhysicsSystem_0;

	private static SharedGunSystem sharedGunSystem_0;

	private static IClientNetManager iclientNetManager_0;

	private static IGameTiming igameTiming_0;

	private bool bool_2;

	private string string_1;

	private long long_0;

	private bool bool_3;

	public static bool _isInitialized { get; private set; }

	private bool Boolean_0
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
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

	private bool Boolean_1
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public static void InitializeDependencies(IClientNetManager netManager, IGameTiming gameTiming, IConfigurationManager cfgManager, IEntityManager entityManager)
	{
		ientityManager_0 = entityManager;
		sharedTransformSystem_0 = ientityManager_0.System<SharedTransformSystem>();
		sharedPhysicsSystem_0 = ientityManager_0.System<SharedPhysicsSystem>();
		sharedGunSystem_0 = ientityManager_0.System<SharedGunSystem>();
		iclientNetManager_0 = netManager;
		igameTiming_0 = gameTiming;
		_isInitialized = true;
	}

	public static Vector2 GetPredictedWorldShootPosition(EntityUid shooterUid, EntityUid targetUid, float projectileSpeed)
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		if (_isInitialized && ientityManager_0 != null)
		{
			TransformComponent val = default(TransformComponent);
			TransformComponent val2 = default(TransformComponent);
			if (ientityManager_0.TryGetComponent<TransformComponent>(shooterUid, ref val) && ientityManager_0.TryGetComponent<TransformComponent>(targetUid, ref val2))
			{
				float realProjectileSpeed = GetRealProjectileSpeed(shooterUid, projectileSpeed);
				Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(val);
				Vector2 worldPosition2 = sharedTransformSystem_0.GetWorldPosition(val2);
				float num = MathF.Sqrt((worldPosition2 - worldPosition).LengthSquared());
				if (!(num >= 2f) || realProjectileSpeed >= 1000f)
				{
					return worldPosition2;
				}
				Vector2 vector = Vector2.Zero;
				PhysicsComponent val3 = default(PhysicsComponent);
				if (ientityManager_0.TryGetComponent<PhysicsComponent>(targetUid, ref val3))
				{
					vector = sharedPhysicsSystem_0.GetMapLinearVelocity(targetUid, val3, val2);
				}
				if (vector.LengthSquared() >= 0.01f)
				{
					float pingCompensation = GetPingCompensation();
					Vector2 vector2 = worldPosition2 + vector * pingCompensation;
					float num2 = CalculateInterceptionTime(worldPosition, vector2, vector, realProjectileSpeed, num);
					float maxPredictTime = CerberusConfig.GunAimBot.MaxPredictTime;
					if (num2 >= 0f && num2 <= maxPredictTime)
					{
						float predictStrength = CerberusConfig.GunAimBot.PredictStrength;
						num2 *= predictStrength;
						Vector2 vector3 = CalculateAimPoint(vector2, vector, num2, targetUid);
						float predictDamping = CerberusConfig.GunAimBot.PredictDamping;
						if (predictDamping > 0.001f)
						{
							vector3 = Vector2.Lerp(vector2, vector3, 1f - predictDamping);
						}
						return vector3;
					}
					return vector2;
				}
				return worldPosition2;
			}
			return Vector2.Zero;
		}
		return Vector2.Zero;
	}

	private static float GetRealProjectileSpeed(EntityUid shooterUid, float fallbackSpeed)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (GunHelper.TryGetGunSafe(sharedGunSystem_0, shooterUid, out Entity<GunComponent> gunEntity))
			{
				GunComponent comp = gunEntity.Comp;
				if (!(comp.ProjectileSpeedModified <= 0f))
				{
					return comp.ProjectileSpeedModified;
				}
				Type type = ((object)comp).GetType();
				PropertyInfo property = type.GetProperty("ProjectileSpeed");
				if (property != null && property.GetValue(comp) is float num && !(num <= 0f))
				{
					return num;
				}
				PropertyInfo propertyInfo = type.GetProperty("HitScan") ?? type.GetProperty("IsHitscan");
				if (propertyInfo != null)
				{
					object value = propertyInfo.GetValue(comp);
					bool flag = default(bool);
					int num2;
					if (value is bool)
					{
						flag = (bool)value;
						num2 = 1;
					}
					else
					{
						num2 = 0;
					}
					if (((uint)num2 & (flag ? 1u : 0u)) != 0)
					{
						return 1000f;
					}
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("[PredictionUtils] Error getting projectile speed: " + ex.Message);
		}
		if (!(fallbackSpeed > 0f))
		{
			return 20f;
		}
		return fallbackSpeed;
	}

	private static float GetPingCompensation()
	{
		IClientNetManager obj = iclientNetManager_0;
		if (((obj != null) ? obj.ServerChannel : null) == null)
		{
			return 0f;
		}
		return (float)iclientNetManager_0.ServerChannel.Ping / 2f / 1000f + 0.03f;
	}

	private static float CalculateInterceptionTime(Vector2 shooterPos, Vector2 targetPos, Vector2 targetVel, float projectileSpeed, float distance)
	{
		Vector2 vector = targetPos - shooterPos;
		Vector2 vector2 = targetVel;
		float a = Vector2.Dot(vector2, vector2) - projectileSpeed * projectileSpeed;
		float b = 2f * Vector2.Dot(vector2, vector);
		float c = Vector2.Dot(vector, vector);
		float num = SolveQuadratic(a, b, c);
		if (num < 0f)
		{
			targetVel.Length();
			Vector2 value = Vector2.Normalize(vector);
			float num2 = Vector2.Dot(targetVel, value);
			if (!(num2 >= 0f) && Math.Abs(num2) >= projectileSpeed)
			{
				return 0.8f;
			}
			num = distance / projectileSpeed;
		}
		return Math.Clamp(num, 0.01f, 0.8f);
	}

	private static Vector2 CalculateAimPoint(Vector2 targetPos, Vector2 targetVel, float time, EntityUid targetUid)
	{
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		Vector2 result = targetPos + targetVel * time;
		if (CerberusConfig.GunAimBot.PredictStrafeCompensation)
		{
			float num = targetVel.Length();
			PhysicsComponent val = default(PhysicsComponent);
			if (!(num <= 3f) && ientityManager_0.TryGetComponent<PhysicsComponent>(targetUid, ref val))
			{
				_ = Vector2.Zero;
				Vector2 value = new Vector2(0f - targetVel.Y, targetVel.X);
				if (value.LengthSquared() > 0.01f)
				{
					value = Vector2.Normalize(value);
					float val2 = num * 0.08f * time;
					val2 = Math.Min(val2, 0.5f);
					result += value * val2 * 0.5f;
				}
			}
			return result;
		}
		return result;
	}

	private static float SolveQuadratic(float a, float b, float c)
	{
		if (Math.Abs(a) >= 1E-06f)
		{
			float num = b * b - 4f * a * c;
			if (num < 0f)
			{
				return -1f;
			}
			float num2 = (float)Math.Sqrt(num);
			float num3 = (0f - b - num2) / (2f * a);
			float num4 = (0f - b + num2) / (2f * a);
			if (num3 <= 0f || !(num4 > 0f))
			{
				if (num3 <= 0f)
				{
					if (num4 <= 0f)
					{
						return -1f;
					}
					return num4;
				}
				return num3;
			}
			return Math.Min(num3, num4);
		}
		if (Math.Abs(b) >= 1E-06f)
		{
			return (0f - c) / b;
		}
		return -1f;
	}
}
