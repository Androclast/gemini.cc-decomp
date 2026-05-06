using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Robust.Client.GameObjects;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Player;
using CerberusConfig;

namespace RenderOptimizer;

public sealed class RenderOptimizer : EntitySystem
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	private SpriteSystem spriteSystem_0;

	private TransformSystem transformSystem_0;

	private float float_0;

	private readonly HashSet<EntityUid> hashSet_0 = new HashSet<EntityUid>();

	private int int_0;

	private HashSet<EntityUid> hashSet_1 = new HashSet<EntityUid>();

	private HashSet<EntityUid> hashSet_2 = new HashSet<EntityUid>();

	private HashSet<EntityUid> hashSet_3 = new HashSet<EntityUid>();

	private HashSet<EntityUid> hashSet_4 = new HashSet<EntityUid>();

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private long long_0;

	private char char_0;

	private byte byte_1;

	private char char_1;

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
			return char_0;
		}
		set
		{
			char_0 = value;
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

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
		spriteSystem_0 = ientityManager_0.System<SpriteSystem>();
		transformSystem_0 = ientityManager_0.System<TransformSystem>();
	}

	public override void Update(float frameTime)
	{
		((EntitySystem)this).Update(frameTime);
		if (CerberusConfig.Performance.Enabled)
		{
			CheckAndRestoreSettings();
			float_0 += frameTime;
			if (float_0 >= 5f)
			{
				float_0 = 0f;
				if (CerberusConfig.Performance.DisableAnimations)
				{
					OptimizeAnimations();
				}
				if (CerberusConfig.Performance.AggressiveCulling)
				{
					OptimizeCulling();
				}
				if (CerberusConfig.Performance.SimplifyShaders)
				{
					SimplifySprites();
				}
				if (CerberusConfig.Performance.LowQualitySprites)
				{
					AggressiveSimplifySprites();
				}
			}
		}
		else
		{
			if (hashSet_1.Count > 0 || hashSet_2.Count > 0 || hashSet_3.Count > 0 || hashSet_4.Count > 0)
			{
				RestoreAll();
			}
			bool_0 = false;
			bool_1 = false;
			bool_2 = false;
			bool_3 = false;
		}
	}

	private void CheckAndRestoreSettings()
	{
		if (bool_0 && !CerberusConfig.Performance.DisableAnimations)
		{
			RestoreAnimations();
		}
		if (bool_1 && !CerberusConfig.Performance.AggressiveCulling)
		{
			RestoreCulling();
		}
		if (bool_2 && !CerberusConfig.Performance.SimplifyShaders)
		{
			RestoreSimplifiedSprites();
		}
		if (bool_3 && !CerberusConfig.Performance.LowQualitySprites)
		{
			RestoreLowQualitySprites();
		}
		bool_0 = CerberusConfig.Performance.DisableAnimations;
		bool_1 = CerberusConfig.Performance.AggressiveCulling;
		bool_2 = CerberusConfig.Performance.SimplifyShaders;
		bool_3 = CerberusConfig.Performance.LowQualitySprites;
	}

	private void OptimizeAnimations()
	{
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (!localEntity.HasValue)
		{
			return;
		}
		Vector2 worldPosition = ((SharedTransformSystem)transformSystem_0).GetWorldPosition(localEntity.Value);
		AllEntityQueryEnumerator<SpriteComponent, TransformComponent> val = ientityManager_0.AllEntityQueryEnumerator<SpriteComponent, TransformComponent>();
		int num = 0;
		int num2 = 0;
		EntityUid val2 = default(EntityUid);
		SpriteComponent val3 = default(SpriteComponent);
		TransformComponent val4 = default(TransformComponent);
		Layer val5 = default(Layer);
		while (val.MoveNext(ref val2, ref val3, ref val4) && num2 < 100)
		{
			num2++;
			if (hashSet_1.Contains(val2))
			{
				continue;
			}
			Vector2 worldPosition2 = ((SharedTransformSystem)transformSystem_0).GetWorldPosition(val2);
			if (Vector2.Distance(worldPosition, worldPosition2) > 30f)
			{
				continue;
			}
			try
			{
				bool flag = false;
				int num3 = Math.Min(val3.AllLayers.Count(), 5);
				for (int i = 0; i < num3; i++)
				{
					if (spriteSystem_0.TryGetLayer(Entity<SpriteComponent>.op_Implicit((val2, val3)), i, ref val5, false) && val5.AutoAnimated)
					{
						flag = true;
						spriteSystem_0.LayerSetAutoAnimated(Entity<SpriteComponent>.op_Implicit((val2, val3)), i, false);
					}
				}
				if (flag)
				{
					hashSet_1.Add(val2);
					num++;
				}
			}
			catch
			{
			}
		}
	}

	private void OptimizeCulling()
	{
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (!localEntity.HasValue)
		{
			return;
		}
		Vector2 worldPosition = ((SharedTransformSystem)transformSystem_0).GetWorldPosition(localEntity.Value);
		float cullingDistance = CerberusConfig.Performance.CullingDistance;
		AllEntityQueryEnumerator<SpriteComponent, TransformComponent> val = ientityManager_0.AllEntityQueryEnumerator<SpriteComponent, TransformComponent>();
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int_0++;
		int num4 = int_0 % 3 * 50;
		int num5 = 0;
		EntityUid val2 = default(EntityUid);
		SpriteComponent item = default(SpriteComponent);
		TransformComponent val3 = default(TransformComponent);
		while (val.MoveNext(ref val2, ref item, ref val3))
		{
			num5++;
			if (num5 < num4)
			{
				continue;
			}
			if (num3 >= 50)
			{
				break;
			}
			num3++;
			if (val2 == localEntity.Value)
			{
				continue;
			}
			try
			{
				bool flag = (((SharedTransformSystem)transformSystem_0).GetWorldPosition(val2) - worldPosition).Length() > cullingDistance;
				bool flag2 = hashSet_2.Contains(val2);
				if (flag && !flag2)
				{
					spriteSystem_0.SetVisible(Entity<SpriteComponent>.op_Implicit((val2, item)), false);
					hashSet_2.Add(val2);
					num++;
				}
				else if (!flag && flag2)
				{
					spriteSystem_0.SetVisible(Entity<SpriteComponent>.op_Implicit((val2, item)), true);
					hashSet_2.Remove(val2);
					num2++;
				}
			}
			catch
			{
			}
		}
		if (num <= 0)
		{
		}
	}

	private void SimplifySprites()
	{
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (!localEntity.HasValue)
		{
			return;
		}
		Vector2 worldPosition = ((SharedTransformSystem)transformSystem_0).GetWorldPosition(localEntity.Value);
		float num = CerberusConfig.Performance.CullingDistance * 0.5f;
		AllEntityQueryEnumerator<SpriteComponent, TransformComponent> val = ientityManager_0.AllEntityQueryEnumerator<SpriteComponent, TransformComponent>();
		int num2 = 0;
		EntityUid val2 = default(EntityUid);
		SpriteComponent val3 = default(SpriteComponent);
		TransformComponent val4 = default(TransformComponent);
		Layer val5 = default(Layer);
		while (val.MoveNext(ref val2, ref val3, ref val4))
		{
			if (val2 == localEntity.Value || hashSet_3.Contains(val2) || hashSet_4.Contains(val2))
			{
				continue;
			}
			try
			{
				if (!((((SharedTransformSystem)transformSystem_0).GetWorldPosition(val2) - worldPosition).Length() > num))
				{
					continue;
				}
				int num3 = val3.AllLayers.Count();
				if (num3 <= 3)
				{
					continue;
				}
				for (int i = 3; i < num3; i++)
				{
					if (spriteSystem_0.TryGetLayer(Entity<SpriteComponent>.op_Implicit((val2, val3)), i, ref val5, false) && val5.Visible)
					{
						spriteSystem_0.LayerSetVisible(Entity<SpriteComponent>.op_Implicit((val2, val3)), i, false);
					}
				}
				hashSet_3.Add(val2);
				num2++;
			}
			catch
			{
			}
		}
	}

	private void AggressiveSimplifySprites()
	{
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		AllEntityQueryEnumerator<SpriteComponent> val = ientityManager_0.AllEntityQueryEnumerator<SpriteComponent>();
		int num = 0;
		EntityUid val2 = default(EntityUid);
		SpriteComponent val3 = default(SpriteComponent);
		Layer val4 = default(Layer);
		while (val.MoveNext(ref val2, ref val3))
		{
			if (hashSet_4.Contains(val2))
			{
				continue;
			}
			try
			{
				int num2 = val3.AllLayers.Count();
				if (num2 <= 1)
				{
					continue;
				}
				for (int i = 1; i < num2; i++)
				{
					if (spriteSystem_0.TryGetLayer(Entity<SpriteComponent>.op_Implicit((val2, val3)), i, ref val4, false) && val4.Visible)
					{
						spriteSystem_0.LayerSetVisible(Entity<SpriteComponent>.op_Implicit((val2, val3)), i, false);
					}
				}
				hashSet_4.Add(val2);
				num++;
			}
			catch
			{
			}
		}
	}

	private void RestoreAnimations()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		SpriteComponent val = default(SpriteComponent);
		Layer val2 = default(Layer);
		foreach (EntityUid item in hashSet_1.ToList())
		{
			if (!ientityManager_0.TryGetComponent<SpriteComponent>(item, ref val))
			{
				continue;
			}
			try
			{
				for (int i = 0; i < val.AllLayers.Count(); i++)
				{
					if (spriteSystem_0.TryGetLayer(Entity<SpriteComponent>.op_Implicit((item, val)), i, ref val2, false))
					{
						spriteSystem_0.LayerSetAutoAnimated(Entity<SpriteComponent>.op_Implicit((item, val)), i, true);
					}
				}
				num++;
			}
			catch
			{
			}
		}
		hashSet_1.Clear();
	}

	private void RestoreCulling()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		SpriteComponent item = default(SpriteComponent);
		foreach (EntityUid item2 in hashSet_2.ToList())
		{
			if (ientityManager_0.TryGetComponent<SpriteComponent>(item2, ref item))
			{
				try
				{
					spriteSystem_0.SetVisible(Entity<SpriteComponent>.op_Implicit((item2, item)), true);
					num++;
				}
				catch
				{
				}
			}
		}
		hashSet_2.Clear();
	}

	private void RestoreSimplifiedSprites()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		SpriteComponent val = default(SpriteComponent);
		Layer val2 = default(Layer);
		foreach (EntityUid item in hashSet_3.ToList())
		{
			if (!ientityManager_0.TryGetComponent<SpriteComponent>(item, ref val))
			{
				continue;
			}
			try
			{
				for (int i = 3; i < val.AllLayers.Count(); i++)
				{
					if (spriteSystem_0.TryGetLayer(Entity<SpriteComponent>.op_Implicit((item, val)), i, ref val2, false))
					{
						spriteSystem_0.LayerSetVisible(Entity<SpriteComponent>.op_Implicit((item, val)), i, true);
					}
				}
				num++;
			}
			catch
			{
			}
		}
		hashSet_3.Clear();
	}

	private void RestoreLowQualitySprites()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		SpriteComponent val = default(SpriteComponent);
		Layer val2 = default(Layer);
		foreach (EntityUid item in hashSet_4.ToList())
		{
			if (!ientityManager_0.TryGetComponent<SpriteComponent>(item, ref val))
			{
				continue;
			}
			try
			{
				for (int i = 1; i < val.AllLayers.Count(); i++)
				{
					if (spriteSystem_0.TryGetLayer(Entity<SpriteComponent>.op_Implicit((item, val)), i, ref val2, false))
					{
						spriteSystem_0.LayerSetVisible(Entity<SpriteComponent>.op_Implicit((item, val)), i, true);
					}
				}
				num++;
			}
			catch
			{
			}
		}
		hashSet_4.Clear();
	}

	private void RestoreAll()
	{
		RestoreAnimations();
		RestoreCulling();
		RestoreSimplifiedSprites();
		RestoreLowQualitySprites();
	}

	public override void Shutdown()
	{
		((EntitySystem)this).Shutdown();
		RestoreAll();
	}
}
