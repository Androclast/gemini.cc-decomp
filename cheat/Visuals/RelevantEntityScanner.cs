using System;
using System.Collections.Generic;
using HarmonyLib;
using Robust.Client.GameObjects;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Prototypes;
using CerberusConfig;

namespace RelevantEntityScanner;

public sealed class RelevantEntityScanner : EntitySystem
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	private readonly HashSet<EntityUid> hashSet_0 = new HashSet<EntityUid>();

	private readonly HashSet<EntityUid> hashSet_1 = new HashSet<EntityUid>();

	private float float_0;

	private static readonly string[] string_0 = new string[64]
	{
		"SurgeryHumanBodyPartExternalTorso", "SurgeryHumanBodyPartExternalHead", "SurgeryHumanBodyPartExternalShoulderLeft", "SurgeryHumanBodyPartExternalShoulderRight", "SurgeryHumanBodyPartExternalBelly", "SurgeryHumanBodyPartExternalNeck", "SurgeryHumanBodyPartExternalArmLeft", "SurgeryHumanBodyPartExternalArmRight", "SurgeryHumanBodyPartExternalLegLeft", "SurgeryHumanBodyPartExternalLegRight",
		"SurgeryHumanBodyPartExternalFootLeft", "SurgeryHumanBodyPartExternalFootRight", "SurgeryHumanBodyPartExternalPalmLeft", "SurgeryHumanBodyPartExternalPalmRight", "SurgeryHumanBodyPartExternalHipLeft", "SurgeryHumanBodyPartExternalHipRight", "SurgeryReptilianBodyPartExternalTorso", "SurgeryReptilianBodyPartExternalHead", "SurgeryReptilianBodyPartExternalShoulderLeft", "SurgeryReptilianBodyPartExternalShoulderRight",
		"SurgeryReptilianBodyPartExternalBelly", "SurgeryReptilianBodyPartExternalNeck", "SurgeryReptilianBodyPartExternalArmLeft", "SurgeryReptilianBodyPartExternalArmRight", "SurgeryReptilianBodyPartExternalLegLeft", "SurgeryReptilianBodyPartExternalLegRight", "SurgeryReptilianBodyPartExternalFootLeft", "SurgeryReptilianBodyPartExternalFootRight", "SurgeryReptilianBodyPartExternalPalmLeft", "SurgeryReptilianBodyPartExternalPalmRight",
		"SurgeryReptilianBodyPartExternalHipLeft", "SurgeryReptilianBodyPartExternalHipRight", "SurgeryMothBodyPartExternalTorso", "SurgeryMothBodyPartExternalHead", "SurgeryMothBodyPartExternalShoulderLeft", "SurgeryMothBodyPartExternalShoulderRight", "SurgeryMothBodyPartExternalBelly", "SurgeryMothBodyPartExternalNeck", "SurgeryMothBodyPartExternalArmLeft", "SurgeryMothBodyPartExternalArmRight",
		"SurgeryMothBodyPartExternalLegLeft", "SurgeryMothBodyPartExternalLegRight", "SurgeryMothBodyPartExternalFootLeft", "SurgeryMothBodyPartExternalFootRight", "SurgeryMothBodyPartExternalPalmLeft", "SurgeryMothBodyPartExternalPalmRight", "SurgeryMothBodyPartExternalHipLeft", "SurgeryMothBodyPartExternalHipRight", "SurgeryArachnidBodyPartExternalTorso", "SurgeryArachnidBodyPartExternalHead",
		"SurgeryArachnidBodyPartExternalShoulderLeft", "SurgeryArachnidBodyPartExternalShoulderRight", "SurgeryArachnidBodyPartExternalBelly", "SurgeryArachnidBodyPartExternalNeck", "SurgeryArachnidBodyPartExternalArmLeft", "SurgeryArachnidBodyPartExternalArmRight", "SurgeryArachnidBodyPartExternalLegLeft", "SurgeryArachnidBodyPartExternalLegRight", "SurgeryArachnidBodyPartExternalFootLeft", "SurgeryArachnidBodyPartExternalFootRight",
		"SurgeryArachnidBodyPartExternalPalmLeft", "SurgeryArachnidBodyPartExternalPalmRight", "SurgeryArachnidBodyPartExternalHipLeft", "SurgeryArachnidBodyPartExternalHipRight"
	};

	private static readonly string[] string_1 = new string[14]
	{
		"SurgeryHumanBodyPartSkeletonRibs", "SurgeryHumanBodyPartSkeletonScull", "SurgeryReptilianBodyPartSkeletonRibs", "SurgeryReptilianBodyPartSkeletonScull", "SurgeryMothBodyPartSkeletonRibs", "SurgeryMothBodyPartSkeletonScull", "SurgeryMothBodyPartSkeletonHead", "SurgeryMothBodyPartSkeletonTorso", "SurgeryMothBodyPartSkeletonBelly", "SurgeryArachnidBodyPartSkeletonRibs",
		"SurgeryArachnidBodyPartSkeletonScull", "SurgeryArachnidBodyPartSkeletonHead", "SurgeryArachnidBodyPartSkeletonTorso", "SurgeryArachnidBodyPartSkeletonBelly"
	};

	private byte byte_0;

	private byte byte_1;

	private float float_1;

	private char char_0;

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

	private byte Byte_1
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

	public override void Update(float frameTime)
	{
		((EntitySystem)this).Update(frameTime);
		if (CerberusConfig.SurgeryExploit.Enabled)
		{
			float_0 += frameTime;
			if (!(float_0 < 0.3f))
			{
				float_0 = 0f;
				PerformScan();
			}
		}
	}

	private void PerformScan()
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			foreach (MetaDataComponent item in ientityManager_0.EntityQuery<MetaDataComponent>(false))
			{
				EntityUid owner = ((Component)item).Owner;
				if (!hashSet_0.Contains(owner) && !hashSet_1.Contains(owner))
				{
					if (!CheckIsRelevant(owner))
					{
						hashSet_0.Add(owner);
					}
					else
					{
						hashSet_1.Add(owner);
					}
				}
			}
			MetaDataComponent val = default(MetaDataComponent);
			SpriteComponent val2 = default(SpriteComponent);
			foreach (EntityUid item2 in hashSet_1)
			{
				if (!ientityManager_0.EntityExists(item2) || !ientityManager_0.TryGetComponent<MetaDataComponent>(item2, ref val) || !ientityManager_0.TryGetComponent<SpriteComponent>(item2, ref val2))
				{
					continue;
				}
				EntityPrototype entityPrototype = val.EntityPrototype;
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
						goto IL_00d6;
					}
				}
				obj = string.Empty;
				goto IL_00d6;
				IL_00d6:
				string proto = (string)obj;
				if (MatchesPrototype(proto, string_0))
				{
					val2.DrawDepth = (CerberusConfig.SurgeryExploit.Group1DepthEnabled ? (-1) : 8);
				}
				if (MatchesPrototype(proto, string_1))
				{
					val2.DrawDepth = (CerberusConfig.SurgeryExploit.Group2DepthEnabled ? (-1) : 6);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private bool CheckIsRelevant(EntityUid uid)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			bool num = HasComponentByName(uid, "Content.Shared.Imperial.Surgery.SurgeryDamagebleComponent");
			bool flag = HasComponentByName(uid, "Content.Shared.Imperial.Surgery.SurgeryBodypartComponent");
			if (!num || !flag)
			{
				return false;
			}
			MetaDataComponent val = default(MetaDataComponent);
			object obj;
			if (ientityManager_0.TryGetComponent<MetaDataComponent>(uid, ref val))
			{
				EntityPrototype entityPrototype = val.EntityPrototype;
				if (entityPrototype != null)
				{
					obj = entityPrototype.ID;
					if (obj != null)
					{
						goto IL_0043;
					}
				}
				else
				{
					obj = null;
				}
				obj = string.Empty;
				goto IL_0043;
			}
			return false;
			IL_0043:
			string proto = (string)obj;
			return MatchesPrototype(proto, string_0) || MatchesPrototype(proto, string_1);
		}
		catch
		{
			return false;
		}
	}

	private bool HasComponentByName(EntityUid uid, string componentTypeName)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Type type = AccessTools.TypeByName(componentTypeName);
			if (type == null)
			{
				return false;
			}
			return ientityManager_0.HasComponent(uid, type);
		}
		catch
		{
			return false;
		}
	}

	private bool MatchesPrototype(string proto, string[] list)
	{
		int num = 0;
		while (true)
		{
			if (num < list.Length)
			{
				string text = list[num];
				if (proto == text)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}
}
