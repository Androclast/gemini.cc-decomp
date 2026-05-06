using System.Numerics;
using System.Runtime.CompilerServices;
using Robust.Shared.GameObjects;
using Robust.Shared.Player;

[CompilerGenerated]
public class PlayerInfo
{
	private string string_0;

	private byte byte_0;

	private double double_0;

	private bool bool_2;

	public ICommonSession Session { get; set; }

	public string Status { get; set; }

	public string EntityName { get; set; }

	public EntityUid? AttachedEntity { get; set; }

	public Vector2 LastKnownPosition { get; set; }

	public string Job { get; set; }

	public bool IsVisible { get; set; }

	public float Health { get; set; }

	public float MaxHealth { get; set; }

	public bool IsAlive { get; set; }

	public bool IsAntag { get; set; }

	public float Distance { get; set; }

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

	public PlayerInfo(ICommonSession session)
	{
		Session = session;
		Status = "Online";
		EntityName = "Loading...";
		LastKnownPosition = Vector2.Zero;
		Job = "Loading...";
		Health = 0f;
		MaxHealth = 100f;
		IsAlive = true;
		IsAntag = false;
		Distance = 0f;
		IsVisible = false;
	}
}
