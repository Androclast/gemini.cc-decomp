using System.Numerics;
using System.Runtime.CompilerServices;
using Robust.Client.Graphics;
using Robust.Client.ResourceManagement;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Maths;
using DamageableHelper;
using CerberusConfig;

namespace DamageBreakdownOverlay;

public sealed class DamageBreakdownOverlay : Overlay
{
	[Dependency]
	private readonly IEntityManager ientityManager_0;

	[Dependency]
	private readonly IEyeManager ieyeManager_0;

	[Dependency]
	private readonly IResourceCache iresourceCache_0;

	[CompilerGenerated]
	private static DamageBreakdownOverlay gclass226_0;

	[CompilerGenerated]
	private EntityUid? nullable_0;

	[CompilerGenerated]
	private EntityUid? nullable_1;

	private SharedTransformSystem sharedTransformSystem_0;

	private VectorFont vectorFont_0;

	private int int_0;

	private string string_0 = "";

	private long long_0;

	private double double_0;

	private int int_1;

	private string string_1;

	public static DamageBreakdownOverlay Instance
	{
		[CompilerGenerated]
		get
		{
			return gclass226_0;
		}
		[CompilerGenerated]
		private set
		{
			gclass226_0 = value;
		}
	}

	public EntityUid? Selected
	{
		[CompilerGenerated]
		get
		{
			return nullable_0;
		}
		[CompilerGenerated]
		set
		{
			nullable_0 = value;
		}
	}

	public EntityUid? LockedTarget
	{
		[CompilerGenerated]
		get
		{
			return nullable_1;
		}
		[CompilerGenerated]
		set
		{
			nullable_1 = value;
		}
	}

	public override OverlaySpace Space => (OverlaySpace)2;

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
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	private int Int32_0
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
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

	public DamageBreakdownOverlay()
	{
		IoCManager.InjectDependencies<DamageBreakdownOverlay>(this);
		DamageableHelper.Initialize();
		Instance = this;
	}

	private void EnsureFont()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		FontResource val = default(FontResource);
		if ((vectorFont_0 == null || int_0 != CerberusConfig.HealthInfo.FontSize || !(string_0 == CerberusConfig.HealthInfo.FontPath)) && iresourceCache_0.TryGetResource<FontResource>(CerberusConfig.HealthInfo.FontPath, ref val))
		{
			vectorFont_0 = new VectorFont(val, CerberusConfig.HealthInfo.FontSize);
			int_0 = CerberusConfig.HealthInfo.FontSize;
			string_0 = CerberusConfig.HealthInfo.FontPath;
		}
	}

	protected override void Draw(in OverlayDrawArgs args)
	{
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		if (!CerberusConfig.HealthInfo.Enabled)
		{
			return;
		}
		EntityUid? val = LockedTarget ?? Selected;
		if (val.HasValue && !ientityManager_0.Deleted(val.Value))
		{
			if (!DamageableHelper.TryGetDamageableComponent(val.Value, ientityManager_0, out object component) || component == null)
			{
				return;
			}
			float totalDamage = DamageableHelper.GetTotalDamage(component);
			if (!(totalDamage > 0f))
			{
				return;
			}
			EnsureFont();
			TransformComponent val2 = default(TransformComponent);
			if (vectorFont_0 != null && ientityManager_0.TryGetComponent<TransformComponent>(val.Value, ref val2))
			{
				if (sharedTransformSystem_0 == null)
				{
					sharedTransformSystem_0 = ientityManager_0.System<SharedTransformSystem>();
				}
				Vector2 worldPosition = sharedTransformSystem_0.GetWorldPosition(val2);
				Vector2 vector = ieyeManager_0.WorldToScreen(worldPosition);
				if (float.IsFinite(vector.X) && float.IsFinite(vector.Y) && ((UIBox2i)(ref args.ViewportBounds)).Contains((int)vector.X, (int)vector.Y))
				{
					DrawingHandleScreen screenHandle = ((OverlayDrawArgs)(ref args)).ScreenHandle;
					float x = vector.X + CerberusConfig.HealthInfo.TextOffset.X;
					float y = vector.Y + CerberusConfig.HealthInfo.TextOffset.Y;
					string entityName = ientityManager_0.GetComponent<MetaDataComponent>(val.Value).EntityName;
					screenHandle.DrawString((Font)(object)vectorFont_0, new Vector2(x, y - (float)(CerberusConfig.HealthInfo.FontSize + 2)), entityName, Color.Yellow);
					DrawGroup(screenHandle, (Font)(object)vectorFont_0, component, x, "Brute", "Brute", ref y);
					DrawGroup(screenHandle, (Font)(object)vectorFont_0, component, x, "Burn", "Burn", ref y);
					DrawGroup(screenHandle, (Font)(object)vectorFont_0, component, x, "Genetic", "Genetic", ref y);
					DrawType(screenHandle, (Font)(object)vectorFont_0, component, x, "Poison", "Toxin", Color.PaleGreen, ref y);
					DrawType(screenHandle, (Font)(object)vectorFont_0, component, x, "Radiation", "Radiation", Color.GreenYellow, ref y);
					DrawType(screenHandle, (Font)(object)vectorFont_0, component, x, "Asphyxiation", "Asphyxiation", Color.LightBlue, ref y);
					DrawType(screenHandle, (Font)(object)vectorFont_0, component, x, "Bloodloss", "Bloodloss", Color.Red, ref y);
					y += 2f;
					screenHandle.DrawString((Font)(object)vectorFont_0, new Vector2(x, y), $"Total: {totalDamage:0.#}", Color.White);
				}
			}
		}
		else if (LockedTarget.HasValue && ientityManager_0.Deleted(LockedTarget.Value))
		{
			LockedTarget = null;
		}
	}

	private void DrawGroup(DrawingHandleScreen handle, Font font, object damageableComp, float x, string groupId, string label, ref float y)
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		float damageByGroup = DamageableHelper.GetDamageByGroup(damageableComp, groupId);
		if (damageByGroup >= 1f)
		{
			Color damageColor = GetDamageColor(groupId);
			handle.DrawString(font, new Vector2(x, y), $"{label}: {(int)damageByGroup}", damageColor);
			y += CerberusConfig.HealthInfo.FontSize + 2;
		}
	}

	private void DrawType(DrawingHandleScreen handle, Font font, object damageableComp, float x, string typeId, string label, Color color, ref float y)
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		float damageByType = DamageableHelper.GetDamageByType(damageableComp, typeId);
		if (damageByType >= 1f)
		{
			handle.DrawString(font, new Vector2(x, y), $"{label}: {(int)damageByType}", color);
			y += CerberusConfig.HealthInfo.FontSize + 2;
		}
	}

	private Color GetDamageColor(string groupId)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		return (Color)(groupId switch
		{
			"Brute" => Color.Red, 
			"Burn" => Color.Orange, 
			"Genetic" => Color.Purple, 
			_ => Color.White, 
		});
	}
}
