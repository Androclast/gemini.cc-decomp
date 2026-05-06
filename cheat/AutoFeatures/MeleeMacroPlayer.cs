using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text.Json;
using Content.Client.Weapons.Melee;
using Content.Shared.Input;
using Content.Shared.Mobs.Components;
using Content.Shared.Weapons.Melee;
using Content.Shared.Weapons.Melee.Events;
using Hexa.NET.ImGui;
using Robust.Client.GameObjects;
using Robust.Client.Input;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.Input;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using MacroAction;
using Macro;
using CerberusConfig;

namespace MeleeMacroPlayer;

public sealed class MeleeMacroPlayer : EntitySystem
{
	[Dependency]
	private readonly IPlayerManager iplayerManager_0;

	[Dependency]
	private readonly IInputManager iinputManager_0;

	[Dependency]
	private readonly InputSystem inputSystem_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly SharedTransformSystem sharedTransformSystem_0;

	[Dependency]
	private readonly EntityLookupSystem entityLookupSystem_0;

	[Dependency]
	private readonly MeleeWeaponSystem meleeWeaponSystem_0;

	[Dependency]
	private readonly FriendsList gclass6_0;

	private static readonly string string_0 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Kaban.cc", "combo");

	private static readonly JsonSerializerOptions jsonSerializerOptions_0 = new JsonSerializerOptions
	{
		WriteIndented = true
	};

	private readonly List<Macro> list_0 = new List<Macro>();

	private Macro? gclass238_0;

	private int int_0;

	private int int_1;

	private float float_0;

	private EntityUid? nullable_0;

	private bool bool_0;

	private readonly HashSet<ImGuiKey> hashSet_0 = new HashSet<ImGuiKey>();

	private bool bool_1;

	private int int_2;

	private bool Boolean_0
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	private int Int32_0
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
		Directory.CreateDirectory(string_0);
		LoadMacros();
	}

	public override void Update(float frameTime)
	{
		((EntitySystem)this).Update(frameTime);
		if (gclass238_0 == null)
		{
			CheckKeybinds();
		}
		else
		{
			TickExecution(frameTime);
		}
	}

	private void CheckKeybinds()
	{
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		foreach (Macro item in list_0)
		{
			if (!item.Enabled || !CerberusConfig.AutoCombo.MacroKeybinds.TryGetValue(item.Name, out var value) || (int)value == 0)
			{
				continue;
			}
			if (KeyStateHelper.IsKeyDown(value))
			{
				if (!hashSet_0.Contains(value))
				{
					hashSet_0.Add(value);
					StartMacro(item);
					break;
				}
			}
			else
			{
				hashSet_0.Remove(value);
			}
		}
	}

	private void StartMacro(Macro macro)
	{
		if (macro.Actions.Count != 0)
		{
			gclass238_0 = macro;
			int_0 = 0;
			int_1 = 0;
			float_0 = 0f;
			nullable_0 = null;
			bool_0 = false;
			Logger.Info("[AutoCombo] Starting: " + macro.Name);
		}
	}

	private void TickExecution(float frameTime)
	{
		if (gclass238_0 == null || !igameTiming_0.IsFirstTimePredicted)
		{
			return;
		}
		float_0 -= frameTime;
		if (!(float_0 <= 0f))
		{
			return;
		}
		if (int_0 >= gclass238_0.Actions.Count)
		{
			Logger.Info("[AutoCombo] Done: " + gclass238_0.Name);
			gclass238_0 = null;
			return;
		}
		MacroAction gClass = gclass238_0.Actions[int_0];
		if (gClass.Type != 3)
		{
			ExecuteAction(gClass.Type);
		}
		int_1++;
		if (int_1 >= gClass.Repeat)
		{
			int_0++;
			int_1 = 0;
		}
		float_0 = Math.Max(gClass.Delay, 0.05f);
	}

	private void ExecuteAction(int type)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		EntityUid? localEntity = ((ISharedPlayerManager)iplayerManager_0).LocalEntity;
		if (!localEntity.HasValue)
		{
			return;
		}
		EntityUid? val = FindNearestTarget(localEntity.Value);
		if (val.HasValue)
		{
			switch (type)
			{
			case 2:
				DoDisarm(localEntity.Value, val.Value);
				break;
			case 0:
				DoGrab(localEntity.Value, val.Value);
				break;
			case 1:
				DoPunch(localEntity.Value, val.Value);
				break;
			}
		}
	}

	private void DoGrab(EntityUid user, EntityUid target)
	{
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			ICommonSession localSession = ((ISharedPlayerManager)iplayerManager_0).LocalSession;
			if (localSession != null)
			{
				BoundKeyFunction tryPullObject = ContentKeyFunctions.TryPullObject;
				KeyFunctionId val = iinputManager_0.NetworkBindMap.KeyFunctionID(tryPullObject);
				EntityCoordinates moverCoordinates = sharedTransformSystem_0.GetMoverCoordinates(target);
				ClientFullInputCmdMessage val2 = new ClientFullInputCmdMessage(igameTiming_0.CurTick, igameTiming_0.TickFraction, val);
				val2.set_State((BoundKeyState)1);
				val2.set_Coordinates(moverCoordinates);
				val2.set_ScreenCoordinates(iinputManager_0.MouseScreenPosition);
				val2.set_Uid(target);
				ClientFullInputCmdMessage val3 = val2;
				inputSystem_0.HandleInputCommand(localSession, tryPullObject, (IFullInputCmdMessage)(object)val3, false);
				ClientFullInputCmdMessage val4 = new ClientFullInputCmdMessage(igameTiming_0.CurTick, igameTiming_0.TickFraction, val);
				val4.set_State((BoundKeyState)0);
				val4.set_Coordinates(moverCoordinates);
				val4.set_ScreenCoordinates(iinputManager_0.MouseScreenPosition);
				val4.set_Uid(target);
				ClientFullInputCmdMessage val5 = val4;
				inputSystem_0.HandleInputCommand(localSession, tryPullObject, (IFullInputCmdMessage)(object)val5, false);
			}
		}
		catch (Exception ex)
		{
			Logger.Warn("[AutoCombo] Grab error: " + ex.Message);
		}
	}

	private void DoPunch(EntityUid user, EntityUid target)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		try
		{
			EntityUid val = default(EntityUid);
			MeleeWeaponComponent val2 = default(MeleeWeaponComponent);
			if (igameTiming_0.IsFirstTimePredicted && ((SharedMeleeWeaponSystem)meleeWeaponSystem_0).TryGetWeapon(user, ref val, ref val2))
			{
				Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(target);
				TryRotateToTarget(worldPosition);
				EntityCoordinates val3 = sharedTransformSystem_0.ToCoordinates(Entity<TransformComponent>.op_Implicit(target), sharedTransformSystem_0.GetMapCoordinates(target, (TransformComponent)null));
				base.EntityManager.RaisePredictiveEvent<LightAttackEvent>(new LightAttackEvent((NetEntity?)base.EntityManager.GetNetEntity(target, (MetaDataComponent)null), base.EntityManager.GetNetEntity(val, (MetaDataComponent)null), base.EntityManager.GetNetCoordinates(val3, (MetaDataComponent)null)));
			}
		}
		catch (Exception ex)
		{
			Logger.Warn("[AutoCombo] Punch error: " + ex.Message);
		}
	}

	private void DoDisarm(EntityUid user, EntityUid target)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		try
		{
			if (igameTiming_0.IsFirstTimePredicted)
			{
				Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(target);
				TryRotateToTarget(worldPosition);
				EntityCoordinates val = sharedTransformSystem_0.ToCoordinates(Entity<TransformComponent>.op_Implicit(target), sharedTransformSystem_0.GetMapCoordinates(target, (TransformComponent)null));
				base.EntityManager.RaisePredictiveEvent<DisarmAttackEvent>(new DisarmAttackEvent((NetEntity?)base.EntityManager.GetNetEntity(target, (MetaDataComponent)null), base.EntityManager.GetNetCoordinates(val, (MetaDataComponent)null)));
			}
		}
		catch (Exception ex)
		{
			Logger.Warn("[AutoCombo] Disarm error: " + ex.Message);
		}
	}

	private void TryRotateToTarget(Vector2 targetPos)
	{
		try
		{
			base.EntityManager.System<PlayerRotator>()?.RotateToTarget(targetPos);
		}
		catch
		{
		}
	}

	private EntityUid GetWeaponEntity(EntityUid user)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		EntityUid result = default(EntityUid);
		MeleeWeaponComponent val = default(MeleeWeaponComponent);
		if (((SharedMeleeWeaponSystem)meleeWeaponSystem_0).TryGetWeapon(user, ref result, ref val))
		{
			return result;
		}
		return user;
	}

	private EntityUid? FindNearestTarget(EntityUid user)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Invalid comparison between Unknown and I4
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(user);
		MapId mapId = sharedTransformSystem_0.GetMapId(Entity<TransformComponent>.op_Implicit(user));
		EntityUid? result = null;
		float num = float.MaxValue;
		MobStateComponent val = default(MobStateComponent);
		foreach (EntityUid item in entityLookupSystem_0.GetEntitiesInRange(mapId, worldPosition, 3f, (LookupFlags)110))
		{
			if (!(item == user) && base.EntityManager.HasComponent<MobStateComponent>(item) && (!base.EntityManager.TryGetComponent<MobStateComponent>(item, ref val) || (int)val.CurrentState != 3) && !gclass6_0.IsFriend(item))
			{
				float num2 = (sharedTransformSystem_0.GetWorldPosition(item) - worldPosition).LengthSquared();
				if (num2 < num)
				{
					num = num2;
					result = item;
				}
			}
		}
		return result;
	}

	public void LoadMacros()
	{
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		list_0.Clear();
		if (!Directory.Exists(string_0))
		{
			return;
		}
		string[] files = Directory.GetFiles(string_0, "*.json");
		foreach (string path in files)
		{
			try
			{
				Macro gClass = JsonSerializer.Deserialize<Macro>(File.ReadAllText(path), jsonSerializerOptions_0);
				if (gClass != null)
				{
					list_0.Add(gClass);
					if (!string.IsNullOrEmpty(gClass.Hotkey) && gClass.Hotkey != "NONE" && Enum.TryParse<ImGuiKey>(gClass.Hotkey, true, out ImGuiKey result))
					{
						CerberusConfig.AutoCombo.MacroKeybinds[gClass.Name] = result;
					}
				}
			}
			catch (Exception ex)
			{
				Logger.Warn("[AutoCombo] Load failed " + Path.GetFileName(path) + ": " + ex.Message);
			}
		}
		Logger.Info($"[AutoCombo] Loaded {list_0.Count} macros");
	}

	public void SaveMacro(Macro macro)
	{
		try
		{
			string path = SanitizeFileName(macro.Name) + ".json";
			string path2 = Path.Combine(string_0, path);
			string contents = JsonSerializer.Serialize(macro, jsonSerializerOptions_0);
			File.WriteAllText(path2, contents);
			int num = list_0.FindIndex((Macro m) => m.Name == macro.Name);
			if (num < 0)
			{
				list_0.Add(macro);
			}
			else
			{
				list_0[num] = macro;
			}
			Logger.Info("[AutoCombo] Saved: " + macro.Name);
		}
		catch (Exception ex)
		{
			Logger.Error("[AutoCombo] Save failed: " + ex.Message);
		}
	}

	public void DeleteMacro(string macroName)
	{
		try
		{
			string path = SanitizeFileName(macroName) + ".json";
			string path2 = Path.Combine(string_0, path);
			if (File.Exists(path2))
			{
				File.Delete(path2);
			}
			list_0.RemoveAll((Macro m) => m.Name == macroName);
		}
		catch (Exception ex)
		{
			Logger.Error("[AutoCombo] Delete failed: " + ex.Message);
		}
	}

	public void ExecuteMacro(string macroName)
	{
		Macro gClass = list_0.FirstOrDefault((Macro m) => m.Name == macroName && m.Enabled);
		if (gClass != null)
		{
			StartMacro(gClass);
		}
	}

	public List<Macro> GetMacros()
	{
		return new List<Macro>(list_0);
	}

	private static string SanitizeFileName(string name)
	{
		char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
		return string.Join("_", name.Split(invalidFileNameChars, StringSplitOptions.RemoveEmptyEntries)).TrimEnd('.');
	}

	private string method_7(int int_3, bool bool_2)
	{
		return "Хитролох_иди_нахуй._______3___06___3_";
	}
}
