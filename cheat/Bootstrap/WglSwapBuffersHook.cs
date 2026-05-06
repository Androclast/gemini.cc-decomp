using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using MinHook;

[CompilerGenerated]
internal sealed class WglSwapBuffersHook : IDisposable
{
	private GCHandle? nullable_0;

	private HookEngine hookEngine_0;

	private bool bool_0;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private OpenGLNativeApi.WglSwapBuffersFunc wglSwapBuffersFunc_0;

	private byte byte_1;

	private string string_0;

	private char char_0;

	public OpenGLNativeApi.WglSwapBuffersFunc OriginalSwapBuffers { get; private set; }

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

	public event OpenGLNativeApi.WglSwapBuffersFunc Event_0
	{
		[CompilerGenerated]
		add
		{
			OpenGLNativeApi.WglSwapBuffersFunc wglSwapBuffersFunc = wglSwapBuffersFunc_0;
			OpenGLNativeApi.WglSwapBuffersFunc wglSwapBuffersFunc2;
			do
			{
				wglSwapBuffersFunc2 = wglSwapBuffersFunc;
				OpenGLNativeApi.WglSwapBuffersFunc value2 = (OpenGLNativeApi.WglSwapBuffersFunc)Delegate.Combine(wglSwapBuffersFunc2, value);
				wglSwapBuffersFunc = Interlocked.CompareExchange(ref wglSwapBuffersFunc_0, value2, wglSwapBuffersFunc2);
			}
			while (wglSwapBuffersFunc != wglSwapBuffersFunc2);
		}
		[CompilerGenerated]
		remove
		{
			OpenGLNativeApi.WglSwapBuffersFunc wglSwapBuffersFunc = wglSwapBuffersFunc_0;
			OpenGLNativeApi.WglSwapBuffersFunc wglSwapBuffersFunc2;
			do
			{
				wglSwapBuffersFunc2 = wglSwapBuffersFunc;
				OpenGLNativeApi.WglSwapBuffersFunc value2 = (OpenGLNativeApi.WglSwapBuffersFunc)Delegate.Remove(wglSwapBuffersFunc2, value);
				wglSwapBuffersFunc = Interlocked.CompareExchange(ref wglSwapBuffersFunc_0, value2, wglSwapBuffersFunc2);
			}
			while (wglSwapBuffersFunc != wglSwapBuffersFunc2);
		}
	}

	public void Install()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		if (hookEngine_0 != null)
		{
			return;
		}
		hookEngine_0 = new HookEngine();
		nint num = OpenGLNativeApi.wglGetProcAddress("wglSwapBuffers");
		if (num == IntPtr.Zero)
		{
			nint moduleHandle = OpenGLNativeApi.GetModuleHandle("opengl32.dll");
			if (moduleHandle != IntPtr.Zero)
			{
				num = OpenGLNativeApi.GetProcAddress(moduleHandle, "wglSwapBuffers");
			}
			if (num == IntPtr.Zero)
			{
				hookEngine_0.Dispose();
				hookEngine_0 = null;
				throw new EntryPointNotFoundException("Could not find wglSwapBuffers entry point via wglGetProcAddress or GetProcAddress(opengl32.dll).");
			}
		}
		OpenGLNativeApi.WglSwapBuffersFunc wglSwapBuffersFunc = WglSwapBuffersDetour;
		nullable_0 = GCHandle.Alloc(wglSwapBuffersFunc);
		try
		{
			OriginalSwapBuffers = hookEngine_0.CreateHook<OpenGLNativeApi.WglSwapBuffersFunc>((IntPtr)num, wglSwapBuffersFunc);
			hookEngine_0.EnableHooks();
		}
		catch (Exception)
		{
			Uninstall();
			throw;
		}
	}

	public void Uninstall()
	{
		if (hookEngine_0 != null)
		{
			try
			{
				hookEngine_0.DisableHooks();
			}
			catch
			{
			}
			hookEngine_0.Dispose();
			hookEngine_0 = null;
			OriginalSwapBuffers = null;
		}
		if (nullable_0.HasValue)
		{
			if (nullable_0.Value.IsAllocated)
			{
				nullable_0.Value.Free();
			}
			nullable_0 = null;
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	private bool WglSwapBuffersDetour(nint hdc)
	{
		if (wglSwapBuffersFunc_0 == null)
		{
			if (OriginalSwapBuffers == null)
			{
				return false;
			}
			return OriginalSwapBuffers(hdc);
		}
		try
		{
			return wglSwapBuffersFunc_0(hdc);
		}
		catch (Exception)
		{
			return false;
		}
	}

	private void Dispose(bool disposing)
	{
		if (!bool_0)
		{
			if (disposing)
			{
				Uninstall();
			}
			bool_0 = true;
		}
	}

	~WglSwapBuffersHook()
	{
		Dispose(disposing: false);
	}
}
