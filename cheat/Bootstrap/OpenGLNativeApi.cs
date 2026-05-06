using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[CompilerGenerated]
internal sealed class OpenGLNativeApi
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, SetLastError = true)]
	public delegate bool WglSwapBuffersFunc(nint hdc);

	private byte byte_0;

	private double double_0;

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

	[DllImport("opengl32.dll")]
	public static extern void glEnable(uint cap);

	[DllImport("opengl32.dll")]
	public static extern void glDisable(uint cap);

	[DllImport("opengl32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	internal static extern nint wglGetProcAddress(string procName);

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	internal static extern nint GetModuleHandle(string lpModuleName);

	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	internal static extern nint GetProcAddress(nint hModule, string procName);

	[DllImport("opengl32.dll")]
	public static extern void glGenTextures(int n, out uint textures);

	[DllImport("opengl32.dll")]
	public static extern void glBindTexture(uint target, uint texture);

	[DllImport("opengl32.dll")]
	public static extern void glDeleteTextures(int n, ref uint textures);

	[DllImport("opengl32.dll")]
	public static extern void glTexParameteri(uint target, uint pname, int param);

	[DllImport("opengl32.dll")]
	public unsafe static extern void glTexImage2D(uint target, int level, int internalformat, int width, int height, int border, uint format, uint type, void* data);

	[DllImport("opengl32.dll")]
	public static extern void glTexImage2D(uint target, int level, int internalformat, int width, int height, int border, uint format, uint type, nint data);

	[DllImport("opengl32.dll")]
	public static extern uint glGetError();

	private string method_8(byte byte_1, int int_0)
	{
		return "Хитролох_иди_нахуй._0___7____4";
	}
}
