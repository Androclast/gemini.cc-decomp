using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using CerberusWareV3.MyImGui;
using Hexa.NET.ImGui;
using Hexa.NET.ImGui.Backends.OpenGL3;
using Hexa.NET.ImGui.Backends.Win32;
using Robust.Shared.IoC;
using Robust.Shared.Log;

[CompilerGenerated]
public sealed class RenderHookManager : IDisposable
{
	private delegate nint WndProcDelegate(nint hWnd, uint msg, nint wParam, nint lParam);

	public delegate bool EventHandler();

	private nint intptr_0 = IntPtr.Zero;

	private WndProcDelegate wndProcDelegate_0;

	private readonly EmbeddedNativeLibraryLoader gclass3_0;

	private readonly List<IOverlay> list_0 = new List<IOverlay>();

	private readonly Lock lock_0 = new Lock();

	private WglSwapBuffersHook class29_0;

	private ImGuiContextPtr imGuiContextPtr_0;

	private bool bool_0;

	private nint intptr_1 = IntPtr.Zero;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private EventHandler eventHandler_0;

	private nint intptr_2 = IntPtr.Zero;

	private nint intptr_3 = IntPtr.Zero;

	private ISawmill isawmill_0 = Logger.GetSawmill("imgui-manager");

	private int int_0;

	private int int_1;

	public static RenderHookManager Instance { get; } = new RenderHookManager();

	private int Int32_0
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	private int Int32_1
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

	public event EventHandler Event_0
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}
	}

	public RenderHookManager()
	{
		IoCManager.InjectDependencies<RenderHookManager>(this);
		gclass3_0 = new EmbeddedNativeLibraryLoader();
	}

	public void RegisterRender(IOverlay overlay)
	{
		ArgumentNullException.ThrowIfNull(overlay, "overlay");
		using (lock_0.EnterScope())
		{
			if (!list_0.Contains(overlay))
			{
				list_0.Add(overlay);
			}
		}
	}

	public void UnregisterRender(IOverlay overlay)
	{
		ArgumentNullException.ThrowIfNull(overlay, "overlay");
		using (lock_0.EnterScope())
		{
			list_0.Remove(overlay);
		}
	}

	public bool Initialize()
	{
		if (LoadNativeLibraries())
		{
			try
			{
				class29_0 = new WglSwapBuffersHook();
				class29_0.Event_0 += SwapBuffersHooked;
				class29_0.Install();
			}
			catch (Exception)
			{
				gclass3_0.Dispose();
				goto IL_005c;
			}
			return true;
		}
		return false;
		IL_005c:
		return false;
	}

	public void Dispose()
	{
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		using (lock_0.EnterScope())
		{
			list_0.Clear();
		}
		RestoreWndProc();
		if (class29_0 != null)
		{
			class29_0.Event_0 -= SwapBuffersHooked;
			class29_0.Uninstall();
			class29_0 = null;
		}
		if (bool_0 && imGuiContextPtr_0 != ImGuiContextPtr.Null)
		{
			ImGui.SetCurrentContext(imGuiContextPtr_0);
			ImGuiImplOpenGL3.Shutdown();
			ImGuiImplWin32.Shutdown();
		}
		if (imGuiContextPtr_0 != ImGuiContextPtr.Null)
		{
			ImGui.DestroyContext(imGuiContextPtr_0);
			imGuiContextPtr_0 = default(ImGuiContextPtr);
		}
		gclass3_0.Dispose();
		bool_0 = false;
	}

	private bool SwapBuffersHooked(nint hdc)
	{
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		if (!bool_0)
		{
			if (!InitializeHook(hdc))
			{
				return class29_0?.OriginalSwapBuffers?.Invoke(hdc) ?? true;
			}
			bool_0 = true;
		}
		try
		{
			ImGuiImplOpenGL3.NewFrame();
			ImGuiImplWin32.NewFrame();
			ImGui.NewFrame();
			List<IOverlay> list;
			using (lock_0.EnterScope())
			{
				list = list_0.ToList();
			}
			foreach (IOverlay item in list)
			{
				try
				{
					item.Render();
				}
				catch (Exception)
				{
					UnregisterRender(item);
				}
			}
			ImGui.Render();
			OpenGLNativeApi.glDisable(36281u);
			ImGuiImplOpenGL3.RenderDrawData(ImGui.GetDrawData());
			OpenGLNativeApi.glEnable(36281u);
		}
		catch (Exception)
		{
		}
		return class29_0?.OriginalSwapBuffers?.Invoke(hdc) ?? true;
	}

	private bool InitializeHook(nint hdc)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			imGuiContextPtr_0 = ImGui.CreateContext();
			if (!(imGuiContextPtr_0 == ImGuiContextPtr.Null))
			{
				intptr_1 = Win32WindowApi.WindowFromDC(hdc);
				if (intptr_1 != IntPtr.Zero)
				{
					if (!SubclassWndProc())
					{
						ImGui.DestroyContext(imGuiContextPtr_0);
						imGuiContextPtr_0 = default(ImGuiContextPtr);
						return false;
					}
					ImGui.SetCurrentContext(imGuiContextPtr_0);
					eventHandler_0?.Invoke();
					ImGuiImplWin32.SetCurrentContext(imGuiContextPtr_0);
					if (!ImGuiImplWin32.InitForOpenGL((IntPtr)intptr_1))
					{
						RestoreWndProc();
						ImGui.DestroyContext(imGuiContextPtr_0);
						imGuiContextPtr_0 = default(ImGuiContextPtr);
						return false;
					}
					ImGuiImplOpenGL3.SetCurrentContext(imGuiContextPtr_0);
					if (ImGuiImplOpenGL3.Init("#version 330 core"))
					{
						return true;
					}
					RestoreWndProc();
					ImGuiImplWin32.Shutdown();
					ImGui.DestroyContext(imGuiContextPtr_0);
					imGuiContextPtr_0 = default(ImGuiContextPtr);
					return false;
				}
				ImGui.DestroyContext(imGuiContextPtr_0);
				imGuiContextPtr_0 = default(ImGuiContextPtr);
				return false;
			}
			return false;
		}
		catch (Exception)
		{
			RestoreWndProc();
			if (imGuiContextPtr_0 != ImGuiContextPtr.Null)
			{
				ImGui.SetCurrentContext(imGuiContextPtr_0);
				ImGuiImplOpenGL3.Shutdown();
				ImGuiImplWin32.Shutdown();
				ImGui.DestroyContext(imGuiContextPtr_0);
				imGuiContextPtr_0 = default(ImGuiContextPtr);
			}
			return false;
		}
	}

	private bool SubclassWndProc()
	{
		if (intptr_1 == IntPtr.Zero)
		{
			return false;
		}
		if (intptr_0 != IntPtr.Zero)
		{
			return true;
		}
		wndProcDelegate_0 = NewWndProc;
		nint functionPointerForDelegate = Marshal.GetFunctionPointerForDelegate(wndProcDelegate_0);
		intptr_0 = Win32WindowApi.SetWindowLongPtr(intptr_1, -4, functionPointerForDelegate);
		if (intptr_0 != IntPtr.Zero)
		{
			return true;
		}
		Marshal.GetLastWin32Error();
		wndProcDelegate_0 = null;
		return false;
	}

	private void RestoreWndProc()
	{
		if (intptr_1 != IntPtr.Zero && intptr_0 != IntPtr.Zero)
		{
			nint windowLongPtrW = Win32WindowApi.GetWindowLongPtrW(intptr_1, -4);
			nint num = ((wndProcDelegate_0 != null) ? Marshal.GetFunctionPointerForDelegate(wndProcDelegate_0) : IntPtr.Zero);
			if (windowLongPtrW == num)
			{
				Win32WindowApi.SetWindowLongPtr(intptr_1, -4, intptr_0);
			}
			intptr_0 = IntPtr.Zero;
			wndProcDelegate_0 = null;
		}
	}

	private nint NewWndProc(nint hWnd, uint msg, nint wParam, nint lParam)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		nint num = ImGuiImplWin32.WndProcHandler((IntPtr)hWnd, msg, (UIntPtr)(nuint)wParam, (IntPtr)lParam);
		ImGuiIOPtr iO = ImGui.GetIO();
		bool flag = ((ImGuiIOPtr)(ref iO)).WantCaptureMouse || ((ImGuiIOPtr)(ref iO)).WantCaptureKeyboard;
		if (!flag)
		{
			flag = ImGui.IsAnyItemActive() || ImGui.IsAnyItemFocused();
		}
		if (!flag || (msg - 256 > 6 && msg - 512 > 10))
		{
			if (num != IntPtr.Zero)
			{
				return IntPtr.Zero;
			}
			return (intptr_0 == IntPtr.Zero) ? Win32WindowApi.DefWindowProc(hWnd, msg, wParam, lParam) : Win32WindowApi.CallWindowProc(intptr_0, hWnd, msg, wParam, lParam);
		}
		return IntPtr.Zero;
	}

	private bool LoadNativeLibraries()
	{
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		intptr_2 = gclass3_0.LoadLibraryFromResource("cimgui.dll", executingAssembly);
		if (intptr_2 != IntPtr.Zero)
		{
			intptr_3 = gclass3_0.LoadLibraryFromResource("ImGuiImpl.dll", executingAssembly);
			if (intptr_3 != IntPtr.Zero)
			{
				return true;
			}
			gclass3_0.Dispose();
			return false;
		}
		return false;
	}
}
