using System;
using System.Collections.Generic;
using System.Numerics;
using Robust.Client.Graphics;
using Robust.Client.Player;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using Robust.Shared.Player;
using Robust.Shared.Prototypes;
using Robust.Shared.Timing;
using CerberusConfig;

namespace PlayerArrowsOverlay;

public sealed class PlayerArrowsOverlay : Overlay
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	private readonly Dictionary<EntityUid, bool> dictionary_0 = new Dictionary<EntityUid, bool>();

	private readonly Dictionary<Vector2i, HashSet<EntityUid>> dictionary_1 = new Dictionary<Vector2i, HashSet<EntityUid>>();

	private bool bool_0;

	private TimeSpan timeSpan_0 = TimeSpan.Zero;

	private float float_1;

	private byte byte_0;

	public override OverlaySpace Space => (OverlaySpace)4;

	private float Single_0
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

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

	public PlayerArrowsOverlay()
	{
		IoCManager.InjectDependencies<PlayerArrowsOverlay>(this);
		((Overlay)this).ZIndex = 100;
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		if (CerberusConfig.GrillElectrocution.Enabled)
		{
			EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
			TransformComponent val = default(TransformComponent);
			if (!localEntity.HasValue || !ientityManager_0.TryGetComponent<TransformComponent>(localEntity.Value, ref val))
			{
				return;
			}
			TimeSpan curTime = igameTiming_0.CurTime;
			if (!((float)(curTime - timeSpan_0).TotalSeconds < 0.5f) || !bool_0)
			{
				timeSpan_0 = curTime;
				UpdateCache();
				bool_0 = true;
			}
			DrawingHandleWorld worldHandle = ((OverlayDrawArgs)(ref args)).WorldHandle;
			SharedTransformSystem val2 = ientityManager_0.System<SharedTransformSystem>();
			Vector2 worldPosition = val2.GetWorldPosition(val);
			float num = CerberusConfig.GrillElectrocution.MaxDistance * CerberusConfig.GrillElectrocution.MaxDistance;
			Color val3 = default(Color);
			((Color)(ref val3))._002Ector(CerberusConfig.GrillElectrocution.Color.X, CerberusConfig.GrillElectrocution.Color.Y, CerberusConfig.GrillElectrocution.Color.Z, CerberusConfig.GrillElectrocution.Opacity);
			EntityUid? gridUid = val.GridUid;
			Matrix3x2 identity = Matrix3x2.Identity;
			Matrix3x2 result = Matrix3x2.Identity;
			bool flag = false;
			TransformComponent val4 = default(TransformComponent);
			if (gridUid.HasValue && ientityManager_0.TryGetComponent<TransformComponent>(gridUid.Value, ref val4))
			{
				identity = val2.GetWorldMatrix(val4);
				Matrix3x2.Invert(identity, out result);
				flag = true;
				((DrawingHandleBase)worldHandle).SetTransform(ref identity);
			}
			TransformComponent val5 = default(TransformComponent);
			Box2 val6 = default(Box2);
			foreach (KeyValuePair<EntityUid, bool> item in dictionary_0)
			{
				if (!item.Value)
				{
					continue;
				}
				EntityUid key = item.Key;
				if (ientityManager_0.EntityExists(key) && ientityManager_0.TryGetComponent<TransformComponent>(key, ref val5) && !(val5.MapID != args.MapId))
				{
					EntityCoordinates coordinates = val5.Coordinates;
					Vector2 vector = ((EntityCoordinates)(ref coordinates)).ToMapPos(ientityManager_0, val2);
					if (!((vector - worldPosition).LengthSquared() > num))
					{
						Vector2 vector2 = (flag ? Vector2.Transform(vector, result) : vector);
						((Box2)(ref val6))._002Ector(vector2 - new Vector2(0.5f, 0.5f), vector2 + new Vector2(0.5f, 0.5f));
						worldHandle.DrawRect(val6, val3, true);
					}
				}
			}
			if (flag)
			{
				Matrix3x2 identity2 = Matrix3x2.Identity;
				((DrawingHandleBase)worldHandle).SetTransform(ref identity2);
			}
		}
		else if (dictionary_0.Count > 0)
		{
			dictionary_0.Clear();
			dictionary_1.Clear();
			bool_0 = false;
		}
	}

	private void UpdateCache()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		dictionary_0.Clear();
		dictionary_1.Clear();
		SharedTransformSystem val = ientityManager_0.System<SharedTransformSystem>();
		EntityQueryEnumerator<MetaDataComponent, TransformComponent> val2 = ientityManager_0.EntityQueryEnumerator<MetaDataComponent, TransformComponent>();
		EntityUid item = default(EntityUid);
		MetaDataComponent val3 = default(MetaDataComponent);
		TransformComponent val4 = default(TransformComponent);
		Vector2i key = default(Vector2i);
		while (val2.MoveNext(ref item, ref val3, ref val4))
		{
			EntityPrototype entityPrototype = val3.EntityPrototype;
			object obj;
			if (entityPrototype == null)
			{
				obj = null;
			}
			else
			{
				obj = entityPrototype.ID;
				if (obj != null)
				{
					goto IL_0207;
				}
			}
			obj = "";
			goto IL_0207;
			IL_0207:
			string text = (string)obj;
			if ((text.Contains("Cable", StringComparison.OrdinalIgnoreCase) || text.Contains("Wire", StringComparison.OrdinalIgnoreCase) || text.Contains("HV", StringComparison.OrdinalIgnoreCase) || text.Contains("MV", StringComparison.OrdinalIgnoreCase) || text.Contains("LV", StringComparison.OrdinalIgnoreCase)) && !(val4.MapID == MapId.Nullspace))
			{
				Vector2 worldPosition = val.GetWorldPosition(val4);
				((Vector2i)(ref key))._002Ector((int)Math.Floor(worldPosition.X), (int)Math.Floor(worldPosition.Y));
				if (!dictionary_1.ContainsKey(key))
				{
					dictionary_1[key] = new HashSet<EntityUid>();
				}
				dictionary_1[key].Add(item);
			}
		}
		EntityQueryEnumerator<MetaDataComponent, TransformComponent> val5 = ientityManager_0.EntityQueryEnumerator<MetaDataComponent, TransformComponent>();
		EntityUid key2 = default(EntityUid);
		MetaDataComponent val6 = default(MetaDataComponent);
		TransformComponent val7 = default(TransformComponent);
		Vector2i key3 = default(Vector2i);
		while (val5.MoveNext(ref key2, ref val6, ref val7))
		{
			EntityPrototype entityPrototype2 = val6.EntityPrototype;
			object obj2;
			if (entityPrototype2 != null)
			{
				obj2 = entityPrototype2.ID;
				if (obj2 != null)
				{
					goto IL_006c;
				}
			}
			else
			{
				obj2 = null;
			}
			obj2 = "";
			goto IL_006c;
			IL_006c:
			if (((string)obj2).Contains("Grill", StringComparison.OrdinalIgnoreCase) && !(val7.MapID == MapId.Nullspace))
			{
				Vector2 worldPosition2 = val.GetWorldPosition(val7);
				((Vector2i)(ref key3))._002Ector((int)Math.Floor(worldPosition2.X), (int)Math.Floor(worldPosition2.Y));
				bool value = dictionary_1.ContainsKey(key3) && dictionary_1[key3].Count > 0;
				dictionary_0[key2] = value;
			}
		}
	}
}
