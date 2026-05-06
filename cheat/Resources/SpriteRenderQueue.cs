using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Hexa.NET.ImGui;
using Robust.Client.GameObjects;
using Robust.Client.Graphics;
using Robust.Client.UserInterface;
using Robust.Shared.GameObjects;
using Robust.Shared.Graphics;
using Robust.Shared.IoC;
using Robust.Shared.Maths;
using Robust.Shared.Timing;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

[CompilerGenerated]
public sealed class SpriteRenderQueue : EntitySystem
{
	private sealed class ContentSpriteControl : Control
	{
		private readonly SpriteRenderQueue HbeN4axruC;

		private readonly Queue<(IRenderTexture, EntityUid, Direction, TaskCompletionSource<bool>)> LEmNTYV1aq = new Queue<(IRenderTexture, EntityUid, Direction, TaskCompletionSource<bool>)>();

		private int int_2;

		private string string_1;

		private char char_1;

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

		public ContentSpriteControl(SpriteRenderQueue system)
		{
			IoCManager.InjectDependencies<ContentSpriteControl>(this);
			HbeN4axruC = system;
		}

		public void QueueRender((IRenderTexture, EntityUid, Direction, TaskCompletionSource<bool>) job)
		{
			LEmNTYV1aq.Enqueue(job);
		}

		protected override void Draw(DrawingHandleScreen handle)
		{
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			((Control)this).Draw(handle);
			while (true)
			{
				if (LEmNTYV1aq.TryDequeue(out var zGYKxHxTbH))
				{
					((DrawingHandleBase)handle).RenderInRenderTarget((IRenderTarget)(object)zGYKxHxTbH.Item1, (Action)delegate
					{
						//IL_0011: Unknown result type (might be due to invalid IL or missing references)
						//IL_0016: Unknown result type (might be due to invalid IL or missing references)
						//IL_0022: Unknown result type (might be due to invalid IL or missing references)
						//IL_002c: Unknown result type (might be due to invalid IL or missing references)
						//IL_003f: Unknown result type (might be due to invalid IL or missing references)
						//IL_0051: Unknown result type (might be due to invalid IL or missing references)
						//IL_005b: Unknown result type (might be due to invalid IL or missing references)
						//IL_0061: Unknown result type (might be due to invalid IL or missing references)
						//IL_0067: Unknown result type (might be due to invalid IL or missing references)
						DrawingHandleScreen obj = handle;
						EntityUid item = zGYKxHxTbH.Item2;
						Vector2 vector = Vector2i.op_Implicit(((IRenderTarget)zGYKxHxTbH.Item1).Size / 2);
						Vector2 one = Vector2.One;
						Angle? val = Angle.Zero;
						Direction? val2 = zGYKxHxTbH.Item3;
						obj.DrawEntity(item, vector, one, val, default(Angle), val2, (SpriteComponent)null, (TransformComponent)null, (SharedTransformSystem)null);
					}, (Color?)Color.Transparent);
					string key = $"player_{zGYKxHxTbH.Item2}";
					HbeN4axruC.ConvertToImGuiTexture(zGYKxHxTbH.Item1, key);
					((IDisposable)zGYKxHxTbH.Item1).Dispose();
					zGYKxHxTbH.Item4.SetResult(result: true);
					continue;
				}
				break;
			}
		}

		private string method_6(byte byte_0)
		{
			return "Хитролох_иди_нахуй.______________86_4_____";
		}
	}

	[Dependency]
	private readonly IClyde iclyde_0;

	[Dependency]
	private readonly IGameTiming igameTiming_0;

	[Dependency]
	private readonly IUserInterfaceManager iuserInterfaceManager_0;

	private ContentSpriteControl contentSpriteControl_0;

	private long long_0;

	private bool bool_2;

	private char char_0;

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

	public override void Initialize()
	{
		((EntitySystem)this).Initialize();
		contentSpriteControl_0 = new ContentSpriteControl(this);
		((Control)iuserInterfaceManager_0.RootControl).AddChild((Control)(object)contentSpriteControl_0);
	}

	public override void Shutdown()
	{
		((EntitySystem)this).Shutdown();
		((Control)iuserInterfaceManager_0.RootControl).RemoveChild((Control)(object)contentSpriteControl_0);
	}

	public async Task RenderSpriteAsync(EntityUid entity, Direction direction = (Direction)0, CancellationToken cancelToken = default(CancellationToken))
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		SpriteComponent val = default(SpriteComponent);
		if (igameTiming_0.IsFirstTimePredicted || !((EntitySystem)this).TryComp<SpriteComponent>(entity, ref val))
		{
			return;
		}
		Vector2i val2 = Vector2i.Zero;
		foreach (ISpriteLayer allLayer in val.AllLayers)
		{
			if (allLayer.Visible)
			{
				val2 = Vector2i.ComponentMax(val2, allLayer.PixelSize);
			}
		}
		if (val2 == Vector2i.Zero)
		{
			return;
		}
		IRenderTexture renderTarget = iclyde_0.CreateRenderTarget(val2, new RenderTargetFormatParameters((RenderTargetColorFormat)1, false), (TextureSampleParameters?)null, "player_preview");
		TaskCompletionSource<bool> S1ONNGyk3m = new TaskCompletionSource<bool>();
		using (cancelToken.Register(delegate
		{
			S1ONNGyk3m.TrySetCanceled();
		}))
		{
			contentSpriteControl_0.QueueRender((renderTarget, entity, direction, S1ONNGyk3m));
			try
			{
				await S1ONNGyk3m.Task.ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (TaskCanceledException)
			{
				((IDisposable)renderTarget).Dispose();
			}
		}
	}

	public ImTextureID GetImGuiTexture(EntityUid entity)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		return ImGuiImageManager.GetImage($"player_{entity}");
	}

	private ImTextureID ConvertToImGuiTexture(IRenderTexture rt, string key)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		((IRenderTarget)rt).CopyPixelsToMemory<Rgba32>((CopyPixelsDelegate<Rgba32>)delegate(Image<Rgba32> image)
		{
			using MemoryStream memoryStream = new MemoryStream();
			ImageExtensions.SaveAsPng((Image)(object)image, (Stream)memoryStream);
			ImGuiImageManager.AddImage(key, memoryStream.ToArray(), 1);
		}, (UIBox2i?)null);
		return ImGuiImageManager.GetImage(key);
	}
}
