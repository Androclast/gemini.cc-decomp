using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Content.Shared.Access.Components;
using Content.Shared.Access.Systems;
using Content.Shared.Contraband;
using Content.Shared.Examine;
using Content.Shared.Roles;
using Content.Shared.Verbs;
using Robust.Shared.Containers;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Localization;
using Robust.Shared.Prototypes;
using Robust.Shared.Utility;

[CompilerGenerated]
public sealed class ContrabandCheckSystem : EntitySystem
{
	[Dependency]
	private readonly IComponentFactory icomponentFactory_0;

	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IPrototypeManager iprototypeManager_0;

	[Dependency]
	private readonly SharedContainerSystem sharedContainerSystem_0;

	[Dependency]
	private readonly ExamineSystemShared examineSystemShared_0;

	[Dependency]
	private readonly SharedIdCardSystem sharedIdCardSystem_0;

	private readonly PlayerComponentHelper gclass0_0 = new PlayerComponentHelper();

	private readonly Dictionary<string, string> dictionary_0 = new Dictionary<string, string>
	{
		{ "contraband-examine-text-Minor", "[color=yellow]Этот предмет считается мелкой контрабандой.[/color]" },
		{ "contraband-examine-text-Restricted", "[color=yellow]Этот предмет ограничен отделом.[/color]" },
		{ "contraband-examine-text-Restricted-department", "[color=yellow]Этот предмет ограничен для {departments}, и может считаться контрабандой.[/color]" },
		{ "contraband-examine-text-Major", "[color=red]Этот предмет считается крупной контрабандой.[/color]" },
		{ "contraband-examine-text-GrandTheft", "[color=red]Этот предмет является очень ценной целью для агентов Синдиката![/color]" },
		{ "contraband-examine-text-Syndicate", "[color=crimson]Этот предмет является крайне незаконной контрабандой Синдиката![/color]" },
		{ "contraband-examine-text-avoid-carrying-around", "[color=red][italic]Вам, вероятно, не стоит носить его с собой без веской причины.[/italic][/color]" },
		{ "contraband-examine-text-in-the-clear", "[color=green][italic]Вы должны быть чисты, чтобы носить этот предмет на виду.[/italic][/color]" }
	};

	private readonly HashSet<string> hashSet_0 = new HashSet<string>
	{
		"Emag", "ClothingHandsGlovesNorthStar", "Telecrystal1", "BibleNecronomicon", "HotPotato", "SupermatterGrenade", "WhiteholeGrenade", "EmpGrenade", "C4", "SyndieMiniBomb",
		"SyndiHypo", "EnergyDagger", "PenExploding", "Hypopen", "HolyHandGrenade", "TrashBananaPeelExplosive", "RubberStampSyndicate", "SoapSyndie", "SlipocalypseClusterSoap", "NocturineChemistryBottle",
		"Stimpack", "StimpackMini", "ExGrenade", "ChameleonProjector", "ClothingHandsGlovesBoxingRigged"
	};

	private readonly HashSet<string> hashSet_1 = new HashSet<string>
	{
		"WeaponRifleAk", "WeaponLaserSvalinn", "WeaponLaserGun", "WeaponMakeshiftLaser", "WeaponTeslaGun", "WeaponLaserCarbine", "WeaponLaserCarbinePractice", "WeaponPulsePistol", "WeaponPulseCarbine", "WeaponPulseRifle",
		"WeaponLaserCannon", "WeaponParticleDecelerator", "WeaponXrayCannon", "WeaponDisabler", "WeaponDisablerSMG", "WeaponDisablerPractice", "WeaponTaser", "WeaponAntiqueLaser", "WeaponAdvancedLaser", "WeaponPistolCHIMP",
		"WeaponPistolCHIMPUpgraded", "WeaponBehonkerLaser", "BaseWeaponHeavyMachineGun", "WeaponMinigun", "BaseWeaponLauncher", "WeaponLauncherChinaLake", "WeaponLauncherRocket", "WeaponLauncherMultipleRocket", "WeaponLauncherPirateCannon", "WeaponTetherGun",
		"WeaponForceGun", "WeaponGrapplingGun", "WeaponTetherGunAdmin", "WeaponForceGunAdmin", "WeaponLauncherAdmemeMeteorLarge", "WeaponLauncherAdmemeImmovableRodSlow", "BaseWeaponLightMachineGun", "WeaponLightMachineGunL6", "WeaponLightMachineGunL6C", "BaseWeaponPistol",
		"WeaponPistolViper", "WeaponPistolCobra", "WeaponPistolMk58", "WeaponPistolN1984", "WeaponRifleAk", "WeaponRifleM90GrenadeLauncher", "WeaponRifleLecter", "WeaponRifleAk", "WeaponRifleM90GrenadeLauncher", "WeaponRifleLecter",
		"WeaponShotgunBulldog", "WeaponShotgunDoubleBarreled", "WeaponShotgunDoubleBarreledRubber", "WeaponShotgunEnforcer", "WeaponShotgunEnforcerRubber", "WeaponShotgunKammerer", "WeaponShotgunSawn", "WeaponShotgunSawnEmpty", "WeaponShotgunHandmade", "WeaponShotgunBlunderbuss",
		"WeaponShotgunImprovised", "WeaponShotgunImprovisedLoaded", "BaseWeaponRevolver", "WeaponRevolverDeckard", "WeaponRevolverInspector", "WeaponRevolverMateba", "WeaponRevolverPython", "WeaponRevolverPythonAP", "WeaponRevolverPirate", "WeaponSubMachineGunAtreides",
		"WeaponSubMachineGunC20r", "WeaponSubMachineGunDrozd", "WeaponSubMachineGunVector", "WeaponSubMachineGunWt550", "WeaponSniperMosin", "WeaponSniperHristov", "Musket", "WeaponPistolFlintlock", "EnergySword", "EnergySwordDouble"
	};

	private bool bool_0;

	private Type type_0;

	private string string_1;

	private string string_2;

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

	private string String_1
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public override void Initialize()
	{
		ComponentRegistration val = default(ComponentRegistration);
		bool_0 = icomponentFactory_0.TryGetRegistration("Contraband", ref val, false);
		if (bool_0)
		{
			type_0 = ((val != null) ? val.Type : null);
		}
		((EntitySystem)this).SubscribeLocalEvent<GetVerbsEvent<Verb>>((EntityEventHandler<GetVerbsEvent<Verb>>)AddContrabandCheckVerb, (Type[])null, (Type[])null);
	}

	private void AddContrabandCheckVerb(GetVerbsEvent<Verb> args)
	{
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		ContainerManagerComponent val = default(ContainerManagerComponent);
		if (args.CanInteract && args.Hands != null && ((EntitySystem)this).TryComp<ContainerManagerComponent>(args.Target, ref val) && val.Containers.Count != 0 && (!bool_0 || !ientityManager_0.HasComponent(args.Target, type_0)) && (HasContraband(args.Target) || HasImplants(args.Target)))
		{
			AlternativeVerb item = new AlternativeVerb
			{
				Act = delegate
				{
					//IL_000c: Unknown result type (might be due to invalid IL or missing references)
					//IL_0028: Unknown result type (might be due to invalid IL or missing references)
					//IL_0033: Unknown result type (might be due to invalid IL or missing references)
					FormattedMessage examineText = GetExamineText(args.Target);
					examineSystemShared_0.SendExamineTooltip(args.User, args.Target, examineText, false, false);
				},
				Text = "Information",
				ClientExclusive = true
			};
			args.Verbs.Add((Verb)(object)item);
		}
	}

	public bool HasContraband(EntityUid target)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		if (bool_0)
		{
			ContainerManagerComponent val = default(ContainerManagerComponent);
			if (((EntitySystem)this).TryComp<ContainerManagerComponent>(target, ref val))
			{
				foreach (BaseContainer value in val.Containers.Values)
				{
					foreach (EntityUid containedEntity in value.ContainedEntities)
					{
						if (IsContraband(containedEntity, target))
						{
							return true;
						}
					}
				}
			}
			return false;
		}
		ContainerManagerComponent val2 = default(ContainerManagerComponent);
		if (((EntitySystem)this).TryComp<ContainerManagerComponent>(target, ref val2))
		{
			foreach (BaseContainer value2 in val2.Containers.Values)
			{
				foreach (EntityUid containedEntity2 in value2.ContainedEntities)
				{
					EntityPrototype entityPrototype = ((EntitySystem)this).MetaData(containedEntity2).EntityPrototype;
					string text = ((entityPrototype != null) ? entityPrototype.ID : null);
					if (text != null && hashSet_0.Contains(text))
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	public bool HasImplants(EntityUid target)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		BaseContainer val = default(BaseContainer);
		if (sharedContainerSystem_0.TryGetContainer(target, "implant", ref val, (ContainerManagerComponent)null))
		{
			return val.ContainedEntities.Count > 0;
		}
		return false;
	}

	public bool HasWeapons(EntityUid target)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		ContainerManagerComponent val = default(ContainerManagerComponent);
		if (((EntitySystem)this).TryComp<ContainerManagerComponent>(target, ref val))
		{
			foreach (BaseContainer value in val.Containers.Values)
			{
				foreach (EntityUid containedEntity in value.ContainedEntities)
				{
					EntityPrototype entityPrototype = ((EntitySystem)this).MetaData(containedEntity).EntityPrototype;
					string text = ((entityPrototype == null) ? null : entityPrototype.ID);
					if (text == null || !hashSet_1.Contains(text))
					{
						continue;
					}
					goto IL_00a9;
				}
			}
		}
		return false;
		IL_00a9:
		return true;
	}

	private bool IsContraband(EntityUid target, EntityUid idCardOwner)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		if (bool_0)
		{
			ContrabandComponent val = default(ContrabandComponent);
			if (((EntitySystem)this).TryComp<ContrabandComponent>(target, ref val))
			{
				List<ProtoId<DepartmentPrototype>> list = null;
				Entity<IdCardComponent> val2 = default(Entity<IdCardComponent>);
				if (sharedIdCardSystem_0.TryFindIdCard(idCardOwner, ref val2))
				{
					list = val2.Comp.JobDepartments;
				}
				return val.AllowedDepartments == null || list == null || !list.Intersect(val.AllowedDepartments).Any();
			}
			return false;
		}
		return false;
	}

	private FormattedMessage GetExamineText(EntityUid target)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		FormattedMessage val = new FormattedMessage();
		ContainerManagerComponent val2 = default(ContainerManagerComponent);
		if (((EntitySystem)this).TryComp<ContainerManagerComponent>(target, ref val2))
		{
			List<string>.Enumerator enumerator = default(List<string>.Enumerator);
			if (HasImplants(target))
			{
				List<string> implants = GetImplants(target);
				val.AddMarkup("[color=red]Detected implants:[/color]\n");
				enumerator = implants.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						string current = enumerator.Current;
						val.AddMarkup("- " + current + "\n");
						val.PushNewline();
					}
				}
				finally
				{
					((IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
				}
			}
			if (HasContraband(target))
			{
				if (!bool_0)
				{
					List<string> contrabandItemsWithoutComponent = GetContrabandItemsWithoutComponent(target);
					val.AddMarkup("[color=red]Detected contraband:[/color]\n");
					enumerator = contrabandItemsWithoutComponent.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							string current2 = enumerator.Current;
							val.AddMarkup("- " + current2 + "\n");
						}
					}
					finally
					{
						((IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
					}
				}
				else
				{
					Dictionary<string, List<string>> contrabandItems = GetContrabandItems(target);
					val.AddMarkup("[color=red]Detected contraband:[/color]\n");
					foreach (var (text2, list2) in contrabandItems)
					{
						val.AddMarkup(text2 + "\n");
						enumerator = list2.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								string current3 = enumerator.Current;
								val.AddMarkup("- " + current3 + "\n");
							}
						}
						finally
						{
							((IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
						}
					}
				}
			}
			if (HasWeapons(target))
			{
				List<string> weaponItems = GetWeaponItems(target);
				val.AddMarkup("[color=red]Detected weapon:[/color]\n");
				enumerator = weaponItems.GetEnumerator();
			}
			try
			{
				while (enumerator.MoveNext())
				{
					string current4 = enumerator.Current;
					val.AddMarkup("- " + current4 + "\n");
					val.PushNewline();
				}
			}
			finally
			{
				((IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
			}
		}
		return val;
	}

	private Dictionary<string, List<string>> GetContrabandItems(EntityUid target)
	{
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		if (!bool_0)
		{
			return new Dictionary<string, List<string>>();
		}
		Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
		ContainerManagerComponent val = default(ContainerManagerComponent);
		if (((EntitySystem)this).TryComp<ContainerManagerComponent>(target, ref val))
		{
			foreach (BaseContainer value2 in val.Containers.Values)
			{
				foreach (EntityUid containedEntity in value2.ContainedEntities)
				{
					if (IsContraband(containedEntity, target))
					{
						string text = ((object)Unsafe.As<LocId, LocId>(ref iprototypeManager_0.Index<ContrabandSeverityPrototype>(((EntitySystem)this).Comp<ContrabandComponent>(containedEntity).Severity).ExamineText)/*cast due to constrained. prefix*/).ToString();
						string value;
						string key = (dictionary_0.TryGetValue(text, out value) ? value : text);
						if (!dictionary.ContainsKey(key))
						{
							dictionary[key] = new List<string>();
						}
						dictionary[key].Add(((EntitySystem)this).Name(containedEntity, (MetaDataComponent)null));
					}
				}
			}
		}
		return dictionary;
	}

	private List<string> GetImplants(EntityUid target)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		List<string> list = new List<string>();
		BaseContainer val = default(BaseContainer);
		if (sharedContainerSystem_0.TryGetContainer(target, "implant", ref val, (ContainerManagerComponent)null))
		{
			list.AddRange(val.ContainedEntities.Select(delegate(EntityUid e)
			{
				//IL_0021: Unknown result type (might be due to invalid IL or missing references)
				MetaDataComponent val2 = ((EntitySystem)this).Comp<MetaDataComponent>(e);
				EntityPrototype entityPrototype = val2.EntityPrototype;
				return (!string.IsNullOrEmpty((entityPrototype != null) ? entityPrototype.EditorSuffix : null)) ? val2.EntityPrototype.EditorSuffix : val2.EntityName;
			}));
		}
		return list;
	}

	private List<string> GetWeaponItems(EntityUid target)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		List<string> list = new List<string>();
		ContainerManagerComponent val = default(ContainerManagerComponent);
		if (((EntitySystem)this).TryComp<ContainerManagerComponent>(target, ref val))
		{
			foreach (BaseContainer value in val.Containers.Values)
			{
				foreach (EntityUid containedEntity in value.ContainedEntities)
				{
					HashSet<string> hashSet = hashSet_1;
					EntityPrototype entityPrototype = ((EntitySystem)this).MetaData(containedEntity).EntityPrototype;
					object obj;
					if (entityPrototype != null)
					{
						obj = entityPrototype.ID;
						if (obj != null)
						{
							goto IL_005a;
						}
					}
					else
					{
						obj = null;
					}
					obj = string.Empty;
					goto IL_005a;
					IL_005a:
					if (hashSet.Contains((string)obj))
					{
						list.Add(((EntitySystem)this).Name(containedEntity, (MetaDataComponent)null));
					}
				}
			}
		}
		return list;
	}

	private List<string> GetContrabandItemsWithoutComponent(EntityUid target)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		List<string> list = new List<string>();
		ContainerManagerComponent val = default(ContainerManagerComponent);
		if (((EntitySystem)this).TryComp<ContainerManagerComponent>(target, ref val))
		{
			foreach (BaseContainer value in val.Containers.Values)
			{
				foreach (EntityUid containedEntity in value.ContainedEntities)
				{
					HashSet<string> hashSet = hashSet_0;
					EntityPrototype entityPrototype = ((EntitySystem)this).MetaData(containedEntity).EntityPrototype;
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
							goto IL_0068;
						}
					}
					obj = string.Empty;
					goto IL_0068;
					IL_0068:
					if (hashSet.Contains((string)obj))
					{
						list.Add(((EntitySystem)this).Name(containedEntity, (MetaDataComponent)null));
					}
				}
			}
		}
		return list;
	}
}
