using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using CerberusWareV3.Localization;
using Hexa.NET.ImGui;
using ConfigIdAttribute;

namespace CerberusConfigData;

public class CerberusConfigData
{
	public class ProjectileEspDataClass
	{
		[CompilerGenerated]
		private bool hCpHt3FDZW = true;

		[CompilerGenerated]
		private bool bJQH68kaRt = true;

		[CompilerGenerated]
		private float xKfHg5cLl2 = 30f;

		[CompilerGenerated]
		private Vector4 vmyHhAvOWH = new Vector4(1f, 0f, 0f, 1f);

		[CompilerGenerated]
		private bool AOwHjTO7SZ;

		[CompilerGenerated]
		private float glvH5LqOpr;

		private string string_0;

		private long long_0;

		private long long_1;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return hCpHt3FDZW;
			}
			[CompilerGenerated]
			set
			{
				hCpHt3FDZW = value;
			}
		}

		public bool ShowTrajectory
		{
			[CompilerGenerated]
			get
			{
				return bJQH68kaRt;
			}
			[CompilerGenerated]
			set
			{
				bJQH68kaRt = value;
			}
		}

		public float DetectionRadius
		{
			[CompilerGenerated]
			get
			{
				return xKfHg5cLl2;
			}
			[CompilerGenerated]
			set
			{
				xKfHg5cLl2 = value;
			}
		}

		public Vector4 Color
		{
			[CompilerGenerated]
			get
			{
				return vmyHhAvOWH;
			}
			[CompilerGenerated]
			set
			{
				vmyHhAvOWH = value;
			}
		}

		public bool AutoDodge
		{
			[CompilerGenerated]
			get
			{
				return AOwHjTO7SZ;
			}
			[CompilerGenerated]
			set
			{
				AOwHjTO7SZ = value;
			}
		}

		public float DodgeRange
		{
			[CompilerGenerated]
			get
			{
				return glvH5LqOpr;
			}
			[CompilerGenerated]
			set
			{
				glvH5LqOpr = value;
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

		private long Int64_1
		{
			get
			{
				return long_1;
			}
			set
			{
				long_1 = value;
			}
		}
	}

	public class GunAimBotDataClass
	{
		[CompilerGenerated]
		private bool WAAHG2GYFb;

		[CompilerGenerated]
		private ImGuiKey mWPHYt71J8;

		[CompilerGenerated]
		private bool q4mHlba1Y1;

		[CompilerGenerated]
		private bool AohHKpwZrD;

		[CompilerGenerated]
		private bool uMyHBkBY5I;

		[CompilerGenerated]
		private bool m8NHzHI5Er;

		[CompilerGenerated]
		private bool PbuZp51DK2;

		[CompilerGenerated]
		private float LT4ZxQ9kxV;

		[CompilerGenerated]
		private bool OXcZ13pwcx;

		[CompilerGenerated]
		private bool OfEZVeDqm3;

		[CompilerGenerated]
		private float JEPZaEdycE;

		[CompilerGenerated]
		private Vector4 DAXZQbqck1;

		[CompilerGenerated]
		private int IOfZWmp4du;

		[CompilerGenerated]
		private bool kBGZCGAI99;

		[CompilerGenerated]
		private bool rAfZUM4KFJ;

		[CompilerGenerated]
		private int oOlZ9gxsRP;

		[CompilerGenerated]
		private bool mm8ZsR17bp;

		[CompilerGenerated]
		private bool z7hZbvJFJ4;

		[CompilerGenerated]
		private bool YGuZrbGWS7;

		[CompilerGenerated]
		private bool lujZD7xL27;

		[CompilerGenerated]
		private List<string> u9fZuDw2De = new List<string>();

		[CompilerGenerated]
		private List<string> XuOZAGAAEn = new List<string>();

		[CompilerGenerated]
		private List<string> uedZLoWgib = new List<string>();

		private double double_1;

		private int int_0;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return WAAHG2GYFb;
			}
			[CompilerGenerated]
			set
			{
				WAAHG2GYFb = value;
			}
		}

		public ImGuiKey HotKey
		{
			[CompilerGenerated]
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return mWPHYt71J8;
			}
			[CompilerGenerated]
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				mWPHYt71J8 = value;
			}
		}

		public bool TargetCritical
		{
			[CompilerGenerated]
			get
			{
				return q4mHlba1Y1;
			}
			[CompilerGenerated]
			set
			{
				q4mHlba1Y1 = value;
			}
		}

		public bool MinSpread
		{
			[CompilerGenerated]
			get
			{
				return AohHKpwZrD;
			}
			[CompilerGenerated]
			set
			{
				AohHKpwZrD = value;
			}
		}

		public bool HitScan
		{
			[CompilerGenerated]
			get
			{
				return uMyHBkBY5I;
			}
			[CompilerGenerated]
			set
			{
				uMyHBkBY5I = value;
			}
		}

		public bool AutoPredict
		{
			[CompilerGenerated]
			get
			{
				return m8NHzHI5Er;
			}
			[CompilerGenerated]
			set
			{
				m8NHzHI5Er = value;
			}
		}

		public bool PredictEnabled
		{
			[CompilerGenerated]
			get
			{
				return PbuZp51DK2;
			}
			[CompilerGenerated]
			set
			{
				PbuZp51DK2 = value;
			}
		}

		public float PredictCorrection
		{
			[CompilerGenerated]
			get
			{
				return LT4ZxQ9kxV;
			}
			[CompilerGenerated]
			set
			{
				LT4ZxQ9kxV = value;
			}
		}

		public bool ShowCircle
		{
			[CompilerGenerated]
			get
			{
				return OXcZ13pwcx;
			}
			[CompilerGenerated]
			set
			{
				OXcZ13pwcx = value;
			}
		}

		public bool ShowLine
		{
			[CompilerGenerated]
			get
			{
				return OfEZVeDqm3;
			}
			[CompilerGenerated]
			set
			{
				OfEZVeDqm3 = value;
			}
		}

		public float CircleRadius
		{
			[CompilerGenerated]
			get
			{
				return JEPZaEdycE;
			}
			[CompilerGenerated]
			set
			{
				JEPZaEdycE = value;
			}
		}

		public Vector4 Color
		{
			[CompilerGenerated]
			get
			{
				return DAXZQbqck1;
			}
			[CompilerGenerated]
			set
			{
				DAXZQbqck1 = value;
			}
		}

		public int TargetPriority
		{
			[CompilerGenerated]
			get
			{
				return IOfZWmp4du;
			}
			[CompilerGenerated]
			set
			{
				IOfZWmp4du = value;
			}
		}

		public bool OnlyPriority
		{
			[CompilerGenerated]
			get
			{
				return kBGZCGAI99;
			}
			[CompilerGenerated]
			set
			{
				kBGZCGAI99 = value;
			}
		}

		public bool MultiTarget
		{
			[CompilerGenerated]
			get
			{
				return rAfZUM4KFJ;
			}
			[CompilerGenerated]
			set
			{
				rAfZUM4KFJ = value;
			}
		}

		public int MultiTargetCount
		{
			[CompilerGenerated]
			get
			{
				return oOlZ9gxsRP;
			}
			[CompilerGenerated]
			set
			{
				oOlZ9gxsRP = value;
			}
		}

		public bool IgnoreCuffed
		{
			[CompilerGenerated]
			get
			{
				return mm8ZsR17bp;
			}
			[CompilerGenerated]
			set
			{
				mm8ZsR17bp = value;
			}
		}

		public bool IgnoreDowned
		{
			[CompilerGenerated]
			get
			{
				return z7hZbvJFJ4;
			}
			[CompilerGenerated]
			set
			{
				z7hZbvJFJ4 = value;
			}
		}

		public bool IgnoreDead
		{
			[CompilerGenerated]
			get
			{
				return YGuZrbGWS7;
			}
			[CompilerGenerated]
			set
			{
				YGuZrbGWS7 = value;
			}
		}

		public bool OnlyVisibleTargets
		{
			[CompilerGenerated]
			get
			{
				return lujZD7xL27;
			}
			[CompilerGenerated]
			set
			{
				lujZD7xL27 = value;
			}
		}

		public List<string> AllowedJobs
		{
			[CompilerGenerated]
			get
			{
				return u9fZuDw2De;
			}
			[CompilerGenerated]
			set
			{
				u9fZuDw2De = value;
			}
		}

		public List<string> BlockedJobs
		{
			[CompilerGenerated]
			get
			{
				return XuOZAGAAEn;
			}
			[CompilerGenerated]
			set
			{
				XuOZAGAAEn = value;
			}
		}

		public List<string> RolePriority
		{
			[CompilerGenerated]
			get
			{
				return uedZLoWgib;
			}
			[CompilerGenerated]
			set
			{
				uedZLoWgib = value;
			}
		}

		private double Double_0
		{
			get
			{
				return double_1;
			}
			set
			{
				double_1 = value;
			}
		}

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
	}

	public class MovementDataClass
	{
		[CompilerGenerated]
		private bool J6qZF1GEKc;

		[CompilerGenerated]
		private float o4CZIGQli8 = 0.35f;

		[CompilerGenerated]
		private ImGuiKey ApqZX5qbRE;

		[CompilerGenerated]
		private bool QnXZcOU5Cx;

		[CompilerGenerated]
		private float zSFZmFXGmM = 0.5f;

		[CompilerGenerated]
		private float CvNZEZIeRF = 0.3f;

		[CompilerGenerated]
		private bool ylSZqbv0HM;

		[CompilerGenerated]
		private ImGuiKey e7MZy0kOHm;

		[CompilerGenerated]
		private int BckZRaOcOv;

		[CompilerGenerated]
		private bool J97ZJf8iyd;

		[CompilerGenerated]
		private int E0nZvcr558 = 50;

		private float float_0;

		private int int_1;

		public bool ShieldSurfEnabled
		{
			[CompilerGenerated]
			get
			{
				return J6qZF1GEKc;
			}
			[CompilerGenerated]
			set
			{
				J6qZF1GEKc = value;
			}
		}

		public float ShieldSurfRadius
		{
			[CompilerGenerated]
			get
			{
				return o4CZIGQli8;
			}
			[CompilerGenerated]
			set
			{
				o4CZIGQli8 = value;
			}
		}

		public ImGuiKey ToggleKey
		{
			[CompilerGenerated]
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return ApqZX5qbRE;
			}
			[CompilerGenerated]
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				ApqZX5qbRE = value;
			}
		}

		public bool AntiAimEnabled
		{
			[CompilerGenerated]
			get
			{
				return QnXZcOU5Cx;
			}
			[CompilerGenerated]
			set
			{
				QnXZcOU5Cx = value;
			}
		}

		public float AntiAimStepLength
		{
			[CompilerGenerated]
			get
			{
				return zSFZmFXGmM;
			}
			[CompilerGenerated]
			set
			{
				zSFZmFXGmM = value;
			}
		}

		public float AntiAimCircleRadius
		{
			[CompilerGenerated]
			get
			{
				return CvNZEZIeRF;
			}
			[CompilerGenerated]
			set
			{
				CvNZEZIeRF = value;
			}
		}

		public bool PixelSurfEnabled
		{
			[CompilerGenerated]
			get
			{
				return ylSZqbv0HM;
			}
			[CompilerGenerated]
			set
			{
				ylSZqbv0HM = value;
			}
		}

		public ImGuiKey PixelSurfKey
		{
			[CompilerGenerated]
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return e7MZy0kOHm;
			}
			[CompilerGenerated]
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				e7MZy0kOHm = value;
			}
		}

		public int PixelSurfMode
		{
			[CompilerGenerated]
			get
			{
				return BckZRaOcOv;
			}
			[CompilerGenerated]
			set
			{
				BckZRaOcOv = value;
			}
		}

		public bool SpeedSaverEnabled
		{
			[CompilerGenerated]
			get
			{
				return J97ZJf8iyd;
			}
			[CompilerGenerated]
			set
			{
				J97ZJf8iyd = value;
			}
		}

		public int SpeedSaverStrafeDurationMs
		{
			[CompilerGenerated]
			get
			{
				return E0nZvcr558;
			}
			[CompilerGenerated]
			set
			{
				E0nZvcr558 = value;
			}
		}

		private float Single_0
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
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
	}

	public class ThrowAimbotDataClass
	{
		[CompilerGenerated]
		private bool RMwZSQ47Ig;

		[CompilerGenerated]
		private float zPVZOK1xey = 15f;

		[CompilerGenerated]
		private float DvYZdOpHMO = 15f;

		[CompilerGenerated]
		private bool L9BZ7pCJxh = true;

		[CompilerGenerated]
		private bool iwPZ4ufZbK = true;

		[CompilerGenerated]
		private int LJJZTLu2lY;

		[CompilerGenerated]
		private bool voFZNMIVlV;

		[CompilerGenerated]
		private bool eeaZ0OeFUu = true;

		[CompilerGenerated]
		private bool twiZPpeypf;

		[CompilerGenerated]
		private bool AOYZ8Dh7FX = true;

		[CompilerGenerated]
		private List<string> LguZkvJqF7 = new List<string>();

		[CompilerGenerated]
		private List<string> XZNZ3XDJlu = new List<string>();

		[CompilerGenerated]
		private List<string> Pt8ZMFTvr9 = new List<string>();

		private bool bool_0;

		private bool bool_1;

		private int int_0;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return RMwZSQ47Ig;
			}
			[CompilerGenerated]
			set
			{
				RMwZSQ47Ig = value;
			}
		}

		public float Range
		{
			[CompilerGenerated]
			get
			{
				return zPVZOK1xey;
			}
			[CompilerGenerated]
			set
			{
				zPVZOK1xey = value;
			}
		}

		public float ThrowSpeed
		{
			[CompilerGenerated]
			get
			{
				return DvYZdOpHMO;
			}
			[CompilerGenerated]
			set
			{
				DvYZdOpHMO = value;
			}
		}

		public bool PredictionEnabled
		{
			[CompilerGenerated]
			get
			{
				return L9BZ7pCJxh;
			}
			[CompilerGenerated]
			set
			{
				L9BZ7pCJxh = value;
			}
		}

		public bool ShowTrajectory
		{
			[CompilerGenerated]
			get
			{
				return iwPZ4ufZbK;
			}
			[CompilerGenerated]
			set
			{
				iwPZ4ufZbK = value;
			}
		}

		public int TargetPriority
		{
			[CompilerGenerated]
			get
			{
				return LJJZTLu2lY;
			}
			[CompilerGenerated]
			set
			{
				LJJZTLu2lY = value;
			}
		}

		public bool OnlyPriority
		{
			[CompilerGenerated]
			get
			{
				return voFZNMIVlV;
			}
			[CompilerGenerated]
			set
			{
				voFZNMIVlV = value;
			}
		}

		public bool IgnoreCuffed
		{
			[CompilerGenerated]
			get
			{
				return eeaZ0OeFUu;
			}
			[CompilerGenerated]
			set
			{
				eeaZ0OeFUu = value;
			}
		}

		public bool IgnoreDowned
		{
			[CompilerGenerated]
			get
			{
				return twiZPpeypf;
			}
			[CompilerGenerated]
			set
			{
				twiZPpeypf = value;
			}
		}

		public bool IgnoreDead
		{
			[CompilerGenerated]
			get
			{
				return AOYZ8Dh7FX;
			}
			[CompilerGenerated]
			set
			{
				AOYZ8Dh7FX = value;
			}
		}

		public List<string> AllowedJobs
		{
			[CompilerGenerated]
			get
			{
				return LguZkvJqF7;
			}
			[CompilerGenerated]
			set
			{
				LguZkvJqF7 = value;
			}
		}

		public List<string> BlockedJobs
		{
			[CompilerGenerated]
			get
			{
				return XZNZ3XDJlu;
			}
			[CompilerGenerated]
			set
			{
				XZNZ3XDJlu = value;
			}
		}

		public List<string> RolePriority
		{
			[CompilerGenerated]
			get
			{
				return Pt8ZMFTvr9;
			}
			[CompilerGenerated]
			set
			{
				Pt8ZMFTvr9 = value;
			}
		}

		private bool Boolean_0
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		private bool Boolean_1
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
				return int_0;
			}
			set
			{
				int_0 = value;
			}
		}
	}

	public class AutoSlipDataClass
	{
		[CompilerGenerated]
		private bool zl9ZfyPGYj;

		[CompilerGenerated]
		private ImGuiKey UmVZefsjuv;

		[CompilerGenerated]
		private float EmVZwSYmop = 15f;

		[CompilerGenerated]
		private float fS6ZiQC0XE = 15f;

		[CompilerGenerated]
		private bool JQeZoYmA2g = true;

		[CompilerGenerated]
		private float qDmZnRm23b = 1.5f;

		[CompilerGenerated]
		private bool VLuZ2BA0By = true;

		private float float_0;

		private bool bool_1;

		private string string_2;

		private int int_0;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return zl9ZfyPGYj;
			}
			[CompilerGenerated]
			set
			{
				zl9ZfyPGYj = value;
			}
		}

		public ImGuiKey ActivationKey
		{
			[CompilerGenerated]
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return UmVZefsjuv;
			}
			[CompilerGenerated]
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				UmVZefsjuv = value;
			}
		}

		public float Range
		{
			[CompilerGenerated]
			get
			{
				return EmVZwSYmop;
			}
			[CompilerGenerated]
			set
			{
				EmVZwSYmop = value;
			}
		}

		public float ThrowSpeed
		{
			[CompilerGenerated]
			get
			{
				return fS6ZiQC0XE;
			}
			[CompilerGenerated]
			set
			{
				fS6ZiQC0XE = value;
			}
		}

		public bool UsePrediction
		{
			[CompilerGenerated]
			get
			{
				return JQeZoYmA2g;
			}
			[CompilerGenerated]
			set
			{
				JQeZoYmA2g = value;
			}
		}

		public float LeadDistance
		{
			[CompilerGenerated]
			get
			{
				return qDmZnRm23b;
			}
			[CompilerGenerated]
			set
			{
				qDmZnRm23b = value;
			}
		}

		public bool UseRolePriority
		{
			[CompilerGenerated]
			get
			{
				return VLuZ2BA0By;
			}
			[CompilerGenerated]
			set
			{
				VLuZ2BA0By = value;
			}
		}

		private float Single_0
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
			}
		}

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

		private string String_0
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
	}

	public class ChamsDataClass
	{
		[CompilerGenerated]
		private bool hgCZHxNsED;

		[CompilerGenerated]
		private int at5ZZd21t0;

		[CompilerGenerated]
		private Vector4 P2XZtig32L = new Vector4(0f, 1f, 0f, 0.5f);

		[CompilerGenerated]
		private bool K5OZ6cbcSj;

		private byte byte_0;

		private byte byte_1;

		private int int_1;

		private string string_0;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return hgCZHxNsED;
			}
			[CompilerGenerated]
			set
			{
				hgCZHxNsED = value;
			}
		}

		public int Mode
		{
			[CompilerGenerated]
			get
			{
				return at5ZZd21t0;
			}
			[CompilerGenerated]
			set
			{
				at5ZZd21t0 = value;
			}
		}

		public Vector4 Color
		{
			[CompilerGenerated]
			get
			{
				return P2XZtig32L;
			}
			[CompilerGenerated]
			set
			{
				P2XZtig32L = value;
			}
		}

		public bool ShowOnLocalPlayer
		{
			[CompilerGenerated]
			get
			{
				return K5OZ6cbcSj;
			}
			[CompilerGenerated]
			set
			{
				K5OZ6cbcSj = value;
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
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}
	}

	public class GrenadeHelperDataClass
	{
		[CompilerGenerated]
		private bool uswZgLTrQm;

		[CompilerGenerated]
		private bool n9IZhja6Uq;

		[CompilerGenerated]
		private bool sZ7ZjgvoXI;

		[CompilerGenerated]
		private bool jivZ575XLL;

		private double double_1;

		private int int_0;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return uswZgLTrQm;
			}
			[CompilerGenerated]
			set
			{
				uswZgLTrQm = value;
			}
		}

		public bool ShowTimer
		{
			[CompilerGenerated]
			get
			{
				return n9IZhja6Uq;
			}
			[CompilerGenerated]
			set
			{
				n9IZhja6Uq = value;
			}
		}

		public bool ShowRadius
		{
			[CompilerGenerated]
			get
			{
				return sZ7ZjgvoXI;
			}
			[CompilerGenerated]
			set
			{
				sZ7ZjgvoXI = value;
			}
		}

		public bool ShowTrajectory
		{
			[CompilerGenerated]
			get
			{
				return jivZ575XLL;
			}
			[CompilerGenerated]
			set
			{
				jivZ575XLL = value;
			}
		}

		private double Double_0
		{
			get
			{
				return double_1;
			}
			set
			{
				double_1 = value;
			}
		}

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
	}

	public class MinecraftVisualsDataClass
	{
		[CompilerGenerated]
		private bool DisZG113fq;

		[CompilerGenerated]
		private int hUjZYGaSlx;

		[CompilerGenerated]
		private float tpEZlLHUTi = 1f;

		[CompilerGenerated]
		private float YOlZKP4KFl = 1f;

		[CompilerGenerated]
		private float XGBZBZ1hX2 = 1f;

		[CompilerGenerated]
		private Vector4 bwUZzWFoJX = new Vector4(1f, 1f, 1f, 1f);

		[CompilerGenerated]
		private bool y1JtpLibwS;

		private string string_0;

		private bool bool_0;

		private byte byte_1;

		private string string_1;

		public bool JumpCirclesEnabled
		{
			[CompilerGenerated]
			get
			{
				return DisZG113fq;
			}
			[CompilerGenerated]
			set
			{
				DisZG113fq = value;
			}
		}

		public int JumpCircleVariant
		{
			[CompilerGenerated]
			get
			{
				return hUjZYGaSlx;
			}
			[CompilerGenerated]
			set
			{
				hUjZYGaSlx = value;
			}
		}

		public float JumpCircleFadeInSpeed
		{
			[CompilerGenerated]
			get
			{
				return tpEZlLHUTi;
			}
			[CompilerGenerated]
			set
			{
				tpEZlLHUTi = value;
			}
		}

		public float JumpCircleFadeOutSpeed
		{
			[CompilerGenerated]
			get
			{
				return YOlZKP4KFl;
			}
			[CompilerGenerated]
			set
			{
				YOlZKP4KFl = value;
			}
		}

		public float JumpCircleRotationSpeed
		{
			[CompilerGenerated]
			get
			{
				return XGBZBZ1hX2;
			}
			[CompilerGenerated]
			set
			{
				XGBZBZ1hX2 = value;
			}
		}

		public Vector4 JumpCircleColor
		{
			[CompilerGenerated]
			get
			{
				return bwUZzWFoJX;
			}
			[CompilerGenerated]
			set
			{
				bwUZzWFoJX = value;
			}
		}

		public bool BlockOutlineEnabled
		{
			[CompilerGenerated]
			get
			{
				return y1JtpLibwS;
			}
			[CompilerGenerated]
			set
			{
				y1JtpLibwS = value;
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

		private bool Boolean_0
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

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

		private string String_1
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

		private string method_7(bool bool_1)
		{
			return "Хитролох_иди_нахуй.____4___4_";
		}
	}

	public class LightSmoothDataClass
	{
		[CompilerGenerated]
		private bool XqQtxHRZS9;

		[CompilerGenerated]
		private float eWSt1STMI7 = 0.5f;

		[CompilerGenerated]
		private float rt6tV5KvdS = 1f;

		[CompilerGenerated]
		private Vector4 T8xtaDPBkT = new Vector4(0.3f, 0.4f, 0.6f, 1f);

		[CompilerGenerated]
		private Vector4 QVEtQ3TIes = new Vector4(1f, 0.95f, 0.9f, 1f);

		[CompilerGenerated]
		private float CjntWD0irw = 1f;

		private char char_1;

		private string string_0;

		private double double_0;

		private bool bool_0;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return XqQtxHRZS9;
			}
			[CompilerGenerated]
			set
			{
				XqQtxHRZS9 = value;
			}
		}

		public float FogDensity
		{
			[CompilerGenerated]
			get
			{
				return eWSt1STMI7;
			}
			[CompilerGenerated]
			set
			{
				eWSt1STMI7 = value;
			}
		}

		public float Brightness
		{
			[CompilerGenerated]
			get
			{
				return rt6tV5KvdS;
			}
			[CompilerGenerated]
			set
			{
				rt6tV5KvdS = value;
			}
		}

		public Vector4 FogColor
		{
			[CompilerGenerated]
			get
			{
				return T8xtaDPBkT;
			}
			[CompilerGenerated]
			set
			{
				T8xtaDPBkT = value;
			}
		}

		public Vector4 TintColor
		{
			[CompilerGenerated]
			get
			{
				return QVEtQ3TIes;
			}
			[CompilerGenerated]
			set
			{
				QVEtQ3TIes = value;
			}
		}

		public float VignetteStrength
		{
			[CompilerGenerated]
			get
			{
				return CjntWD0irw;
			}
			[CompilerGenerated]
			set
			{
				CjntWD0irw = value;
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
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}
	}

	public class WorldParticlesDataClass
	{
		[CompilerGenerated]
		private bool hx7tCgpUaR;

		[CompilerGenerated]
		private int gx4tUpgeqZ = 60;

		[CompilerGenerated]
		private float L9Rt9ZMTAV = 15f;

		[CompilerGenerated]
		private float mh2tsgHQQJ = 1f;

		[CompilerGenerated]
		private float VkNtbX6vu3 = 1f;

		[CompilerGenerated]
		private int vH1trIyPoj;

		[CompilerGenerated]
		private float TD1tDvu5dO = 0.8f;

		[CompilerGenerated]
		private bool mV5tuJEgoa = true;

		[CompilerGenerated]
		private bool EhCtAKOkg4;

		[CompilerGenerated]
		private Vector4 elstLgUHYG = new Vector4(1f, 1f, 1f, 1f);

		private bool bool_0;

		private int int_1;

		private bool bool_1;

		private char char_0;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return hx7tCgpUaR;
			}
			[CompilerGenerated]
			set
			{
				hx7tCgpUaR = value;
			}
		}

		public int ParticleCount
		{
			[CompilerGenerated]
			get
			{
				return gx4tUpgeqZ;
			}
			[CompilerGenerated]
			set
			{
				gx4tUpgeqZ = value;
			}
		}

		public float SpawnRadius
		{
			[CompilerGenerated]
			get
			{
				return L9Rt9ZMTAV;
			}
			[CompilerGenerated]
			set
			{
				L9Rt9ZMTAV = value;
			}
		}

		public float Speed
		{
			[CompilerGenerated]
			get
			{
				return mh2tsgHQQJ;
			}
			[CompilerGenerated]
			set
			{
				mh2tsgHQQJ = value;
			}
		}

		public float Size
		{
			[CompilerGenerated]
			get
			{
				return VkNtbX6vu3;
			}
			[CompilerGenerated]
			set
			{
				VkNtbX6vu3 = value;
			}
		}

		public int ParticleMode
		{
			[CompilerGenerated]
			get
			{
				return vH1trIyPoj;
			}
			[CompilerGenerated]
			set
			{
				vH1trIyPoj = value;
			}
		}

		public float Opacity
		{
			[CompilerGenerated]
			get
			{
				return TD1tDvu5dO;
			}
			[CompilerGenerated]
			set
			{
				TD1tDvu5dO = value;
			}
		}

		public bool UseGlow
		{
			[CompilerGenerated]
			get
			{
				return mV5tuJEgoa;
			}
			[CompilerGenerated]
			set
			{
				mV5tuJEgoa = value;
			}
		}

		public bool UseBlur
		{
			[CompilerGenerated]
			get
			{
				return EhCtAKOkg4;
			}
			[CompilerGenerated]
			set
			{
				EhCtAKOkg4 = value;
			}
		}

		public Vector4 ParticleColor
		{
			[CompilerGenerated]
			get
			{
				return elstLgUHYG;
			}
			[CompilerGenerated]
			set
			{
				elstLgUHYG = value;
			}
		}

		private bool Boolean_0
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
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

		private bool Boolean_1
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
	}

	public class TrailsDataClass
	{
		[CompilerGenerated]
		private bool xjStFCNFbF;

		[CompilerGenerated]
		private int V1GtIyqjRy = 16;

		[CompilerGenerated]
		private float gkStXoVj1o = 0.3f;

		[CompilerGenerated]
		private float SAttcMhRQU = 2f;

		[CompilerGenerated]
		private float PmPtmrAP76 = 1f;

		[CompilerGenerated]
		private int BqMtEGrPae = 50;

		[CompilerGenerated]
		private float OvetqlxVC0 = 3f;

		[CompilerGenerated]
		private Vector4 uagty9dqgk = new Vector4(1f, 1f, 1f, 1f);

		private string string_0;

		private long long_0;

		private string string_1;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return xjStFCNFbF;
			}
			[CompilerGenerated]
			set
			{
				xjStFCNFbF = value;
			}
		}

		public int TrailMode
		{
			[CompilerGenerated]
			get
			{
				return V1GtIyqjRy;
			}
			[CompilerGenerated]
			set
			{
				V1GtIyqjRy = value;
			}
		}

		public float TrailSize
		{
			[CompilerGenerated]
			get
			{
				return gkStXoVj1o;
			}
			[CompilerGenerated]
			set
			{
				gkStXoVj1o = value;
			}
		}

		public float TrailLifetime
		{
			[CompilerGenerated]
			get
			{
				return SAttcMhRQU;
			}
			[CompilerGenerated]
			set
			{
				SAttcMhRQU = value;
			}
		}

		public float TrailLength
		{
			[CompilerGenerated]
			get
			{
				return PmPtmrAP76;
			}
			[CompilerGenerated]
			set
			{
				PmPtmrAP76 = value;
			}
		}

		public int ParticleCount
		{
			[CompilerGenerated]
			get
			{
				return BqMtEGrPae;
			}
			[CompilerGenerated]
			set
			{
				BqMtEGrPae = value;
			}
		}

		public float ParticleSpawnRate
		{
			[CompilerGenerated]
			get
			{
				return OvetqlxVC0;
			}
			[CompilerGenerated]
			set
			{
				OvetqlxVC0 = value;
			}
		}

		public Vector4 TrailColor
		{
			[CompilerGenerated]
			get
			{
				return uagty9dqgk;
			}
			[CompilerGenerated]
			set
			{
				uagty9dqgk = value;
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

		private string String_1
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
	}

	public class PlayerGlowDataClass
	{
		[CompilerGenerated]
		private bool iWstROb8P0;

		[CompilerGenerated]
		private float yQDtJOamcA = 0.15f;

		[CompilerGenerated]
		private int HFBtv2JVvp = 30;

		[CompilerGenerated]
		private Vector4 l8QtS4sD8P = new Vector4(1f, 1f, 1f, 1f);

		private float float_0;

		private char char_0;

		private int int_1;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return iWstROb8P0;
			}
			[CompilerGenerated]
			set
			{
				iWstROb8P0 = value;
			}
		}

		public float GlowSize
		{
			[CompilerGenerated]
			get
			{
				return yQDtJOamcA;
			}
			[CompilerGenerated]
			set
			{
				yQDtJOamcA = value;
			}
		}

		public int GlowDensity
		{
			[CompilerGenerated]
			get
			{
				return HFBtv2JVvp;
			}
			[CompilerGenerated]
			set
			{
				HFBtv2JVvp = value;
			}
		}

		public Vector4 GlowColor
		{
			[CompilerGenerated]
			get
			{
				return l8QtS4sD8P;
			}
			[CompilerGenerated]
			set
			{
				l8QtS4sD8P = value;
			}
		}

		private float Single_0
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
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

		private string method_9(double double_0, int int_2, bool bool_0)
		{
			return "Хитролох_иди_нахуй.______7_____20_______";
		}
	}

	public class HitParticlesDataClass
	{
		[CompilerGenerated]
		private bool lWktO1mdQp;

		[CompilerGenerated]
		private int EELtdBkCgB = 15;

		[CompilerGenerated]
		private int qu6t7xEGIj;

		[CompilerGenerated]
		private float t2Tt4C0DLq = 0.8f;

		[CompilerGenerated]
		private float nTNtT7s7ts = 1f;

		[CompilerGenerated]
		private float qOKtNS69oc = 0.8f;

		[CompilerGenerated]
		private Vector4 zYDt0bXEkK = new Vector4(1f, 1f, 1f, 1f);

		private float float_0;

		private string string_0;

		private byte byte_1;

		private int int_0;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return lWktO1mdQp;
			}
			[CompilerGenerated]
			set
			{
				lWktO1mdQp = value;
			}
		}

		public int ParticleCount
		{
			[CompilerGenerated]
			get
			{
				return EELtdBkCgB;
			}
			[CompilerGenerated]
			set
			{
				EELtdBkCgB = value;
			}
		}

		public int ParticleMode
		{
			[CompilerGenerated]
			get
			{
				return qu6t7xEGIj;
			}
			[CompilerGenerated]
			set
			{
				qu6t7xEGIj = value;
			}
		}

		public float Opacity
		{
			[CompilerGenerated]
			get
			{
				return t2Tt4C0DLq;
			}
			[CompilerGenerated]
			set
			{
				t2Tt4C0DLq = value;
			}
		}

		public float ParticleSize
		{
			[CompilerGenerated]
			get
			{
				return nTNtT7s7ts;
			}
			[CompilerGenerated]
			set
			{
				nTNtT7s7ts = value;
			}
		}

		public float ParticleLifetime
		{
			[CompilerGenerated]
			get
			{
				return qOKtNS69oc;
			}
			[CompilerGenerated]
			set
			{
				qOKtNS69oc = value;
			}
		}

		public Vector4 ParticleColor
		{
			[CompilerGenerated]
			get
			{
				return zYDt0bXEkK;
			}
			[CompilerGenerated]
			set
			{
				zYDt0bXEkK = value;
			}
		}

		private float Single_0
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
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
	}

	public class CloakedPlayerDetectorDataClass
	{
		[CompilerGenerated]
		private bool CBRtPmBH4U;

		[CompilerGenerated]
		private float ANUt8FvIJ1 = 30f;

		[CompilerGenerated]
		private Vector4 DSYtkaGuyY = new Vector4(1f, 0f, 1f, 0.7f);

		[CompilerGenerated]
		private Vector4 PBht3eqisi = new Vector4(1f, 0f, 0f, 1f);

		[CompilerGenerated]
		private bool WEctMZybJm = true;

		[CompilerGenerated]
		private bool DsYtfoQ6q9 = true;

		[CompilerGenerated]
		private float w2AteDN6fa = 0.5f;

		private byte byte_0;

		private double double_2;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return CBRtPmBH4U;
			}
			[CompilerGenerated]
			set
			{
				CBRtPmBH4U = value;
			}
		}

		public float MaxDistance
		{
			[CompilerGenerated]
			get
			{
				return ANUt8FvIJ1;
			}
			[CompilerGenerated]
			set
			{
				ANUt8FvIJ1 = value;
			}
		}

		public Vector4 CloakedColor
		{
			[CompilerGenerated]
			get
			{
				return DSYtkaGuyY;
			}
			[CompilerGenerated]
			set
			{
				DSYtkaGuyY = value;
			}
		}

		public Vector4 NinjaColor
		{
			[CompilerGenerated]
			get
			{
				return PBht3eqisi;
			}
			[CompilerGenerated]
			set
			{
				PBht3eqisi = value;
			}
		}

		public bool ShowOutline
		{
			[CompilerGenerated]
			get
			{
				return WEctMZybJm;
			}
			[CompilerGenerated]
			set
			{
				WEctMZybJm = value;
			}
		}

		public bool ShowWarningForNinja
		{
			[CompilerGenerated]
			get
			{
				return DsYtfoQ6q9;
			}
			[CompilerGenerated]
			set
			{
				DsYtfoQ6q9 = value;
			}
		}

		public float MinVisibilityThreshold
		{
			[CompilerGenerated]
			get
			{
				return w2AteDN6fa;
			}
			[CompilerGenerated]
			set
			{
				w2AteDN6fa = value;
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
				return double_2;
			}
			set
			{
				double_2 = value;
			}
		}
	}

	public class AutoCuffDataClass
	{
		[CompilerGenerated]
		private bool TnHtwfNl9p;

		[CompilerGenerated]
		private string wvgtinZyH8 = "None";

		[CompilerGenerated]
		private int vTotodIeM9 = 1;

		[CompilerGenerated]
		private bool Lv2tnTYXi8 = true;

		private double double_0;

		private char char_1;

		private byte byte_0;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return TnHtwfNl9p;
			}
			[CompilerGenerated]
			set
			{
				TnHtwfNl9p = value;
			}
		}

		public string ActivationKey
		{
			[CompilerGenerated]
			get
			{
				return wvgtinZyH8;
			}
			[CompilerGenerated]
			set
			{
				wvgtinZyH8 = value;
			}
		}

		public int TargetPriority
		{
			[CompilerGenerated]
			get
			{
				return vTotodIeM9;
			}
			[CompilerGenerated]
			set
			{
				vTotodIeM9 = value;
			}
		}

		public bool OnlyStunned
		{
			[CompilerGenerated]
			get
			{
				return Lv2tnTYXi8;
			}
			[CompilerGenerated]
			set
			{
				Lv2tnTYXi8 = value;
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

		private string method_9(int int_0, long long_2)
		{
			return "Хитролох_иди_нахуй.__55__2__1_________";
		}
	}

	public class AutoStopDataClass
	{
		[CompilerGenerated]
		private bool eFLt2kNIII;

		[CompilerGenerated]
		private string lq6tHfJJV9 = "None";

		[CompilerGenerated]
		private float w3PtZlb5U8 = 100f;

		private string string_0;

		private float float_0;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return eFLt2kNIII;
			}
			[CompilerGenerated]
			set
			{
				eFLt2kNIII = value;
			}
		}

		public string ActivationKey
		{
			[CompilerGenerated]
			get
			{
				return lq6tHfJJV9;
			}
			[CompilerGenerated]
			set
			{
				lq6tHfJJV9 = value;
			}
		}

		public float IntervalMs
		{
			[CompilerGenerated]
			get
			{
				return w3PtZlb5U8;
			}
			[CompilerGenerated]
			set
			{
				w3PtZlb5U8 = value;
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

		private float Single_0
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
			}
		}
	}

	public class AutoHypoDataClass
	{
		[CompilerGenerated]
		private bool eDRttGwXFI;

		[CompilerGenerated]
		private float jFtt6CiLHN = 50f;

		[CompilerGenerated]
		private int mEMtg1176D = 1;

		[CompilerGenerated]
		private string XhdthablK6 = "None";

		private int int_0;

		private bool bool_1;

		private bool bool_2;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return eDRttGwXFI;
			}
			[CompilerGenerated]
			set
			{
				eDRttGwXFI = value;
			}
		}

		public float HpThreshold
		{
			[CompilerGenerated]
			get
			{
				return jFtt6CiLHN;
			}
			[CompilerGenerated]
			set
			{
				jFtt6CiLHN = value;
			}
		}

		public int InjectCount
		{
			[CompilerGenerated]
			get
			{
				return mEMtg1176D;
			}
			[CompilerGenerated]
			set
			{
				mEMtg1176D = value;
			}
		}

		public string ForceKey
		{
			[CompilerGenerated]
			get
			{
				return XhdthablK6;
			}
			[CompilerGenerated]
			set
			{
				XhdthablK6 = value;
			}
		}

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

		private bool Boolean_1
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
	}

	public class AutoHackDoorsDataClass
	{
		[CompilerGenerated]
		private bool NWWtjqZmix;

		[CompilerGenerated]
		private float zMht5OCEwV = 2f;

		[CompilerGenerated]
		private float fxLtGPFidB = 1f;

		[CompilerGenerated]
		private bool xartYGUnob = true;

		[CompilerGenerated]
		private bool UEttliyrua = true;

		[CompilerGenerated]
		private bool RgstK0PXKm;

		private long long_0;

		private double double_1;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return NWWtjqZmix;
			}
			[CompilerGenerated]
			set
			{
				NWWtjqZmix = value;
			}
		}

		public float Range
		{
			[CompilerGenerated]
			get
			{
				return zMht5OCEwV;
			}
			[CompilerGenerated]
			set
			{
				zMht5OCEwV = value;
			}
		}

		public float Cooldown
		{
			[CompilerGenerated]
			get
			{
				return fxLtGPFidB;
			}
			[CompilerGenerated]
			set
			{
				fxLtGPFidB = value;
			}
		}

		public bool RequireMultitool
		{
			[CompilerGenerated]
			get
			{
				return xartYGUnob;
			}
			[CompilerGenerated]
			set
			{
				xartYGUnob = value;
			}
		}

		public bool OnlyBoltedDoors
		{
			[CompilerGenerated]
			get
			{
				return UEttliyrua;
			}
			[CompilerGenerated]
			set
			{
				UEttliyrua = value;
			}
		}

		public bool OnlyLockedDoors
		{
			[CompilerGenerated]
			get
			{
				return RgstK0PXKm;
			}
			[CompilerGenerated]
			set
			{
				RgstK0PXKm = value;
			}
		}

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
				return double_1;
			}
			set
			{
				double_1 = value;
			}
		}
	}

	public class AutoStripDataClass
	{
		[CompilerGenerated]
		private bool SYitBE24ei;

		[CompilerGenerated]
		private float iQltzwEQEl = 1.5f;

		[CompilerGenerated]
		private float sIV6pVQsOe = 0.5f;

		[CompilerGenerated]
		private bool XNC6x5LCTP = true;

		[CompilerGenerated]
		private bool XMR61s6Nqr = true;

		[CompilerGenerated]
		private bool A9o6VxtAAN;

		[CompilerGenerated]
		private bool Pjp6aorl3L;

		[CompilerGenerated]
		private string Dfy6QhRkDC = "None";

		private byte byte_1;

		private float float_0;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return SYitBE24ei;
			}
			[CompilerGenerated]
			set
			{
				SYitBE24ei = value;
			}
		}

		public float Range
		{
			[CompilerGenerated]
			get
			{
				return iQltzwEQEl;
			}
			[CompilerGenerated]
			set
			{
				iQltzwEQEl = value;
			}
		}

		public float Cooldown
		{
			[CompilerGenerated]
			get
			{
				return sIV6pVQsOe;
			}
			[CompilerGenerated]
			set
			{
				sIV6pVQsOe = value;
			}
		}

		public bool StripWeaponsFirst
		{
			[CompilerGenerated]
			get
			{
				return XNC6x5LCTP;
			}
			[CompilerGenerated]
			set
			{
				XNC6x5LCTP = value;
			}
		}

		public bool StripArmor
		{
			[CompilerGenerated]
			get
			{
				return XMR61s6Nqr;
			}
			[CompilerGenerated]
			set
			{
				XMR61s6Nqr = value;
			}
		}

		public bool StripClothing
		{
			[CompilerGenerated]
			get
			{
				return A9o6VxtAAN;
			}
			[CompilerGenerated]
			set
			{
				A9o6VxtAAN = value;
			}
		}

		public bool AutoMode
		{
			[CompilerGenerated]
			get
			{
				return Pjp6aorl3L;
			}
			[CompilerGenerated]
			set
			{
				Pjp6aorl3L = value;
			}
		}

		public string StripAllKey
		{
			[CompilerGenerated]
			get
			{
				return Dfy6QhRkDC;
			}
			[CompilerGenerated]
			set
			{
				Dfy6QhRkDC = value;
			}
		}

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

		private float Single_0
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
			}
		}
	}

	public class AutoPathDataClass
	{
		[CompilerGenerated]
		private bool iCT6WEh40r;

		private int int_0;

		private double double_0;

		private bool bool_0;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return iCT6WEh40r;
			}
			[CompilerGenerated]
			set
			{
				iCT6WEh40r = value;
			}
		}

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
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}
	}

	public class TurretEspDataClass
	{
		[CompilerGenerated]
		private bool LGA6CZQS9C;

		[CompilerGenerated]
		private float TSV6UVVA2A = 30f;

		[CompilerGenerated]
		private bool UAx69BO9Hj = true;

		[CompilerGenerated]
		private Vector4 q886sNdgTv = new Vector4(1f, 0f, 0f, 1f);

		[CompilerGenerated]
		private Vector4 Oew6bfXMt7 = new Vector4(0f, 1f, 0f, 1f);

		private bool bool_1;

		private string string_0;

		private byte byte_0;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return LGA6CZQS9C;
			}
			[CompilerGenerated]
			set
			{
				LGA6CZQS9C = value;
			}
		}

		public float MaxDistance
		{
			[CompilerGenerated]
			get
			{
				return TSV6UVVA2A;
			}
			[CompilerGenerated]
			set
			{
				TSV6UVVA2A = value;
			}
		}

		public bool ShowAttackRadius
		{
			[CompilerGenerated]
			get
			{
				return UAx69BO9Hj;
			}
			[CompilerGenerated]
			set
			{
				UAx69BO9Hj = value;
			}
		}

		public Vector4 HostileColor
		{
			[CompilerGenerated]
			get
			{
				return q886sNdgTv;
			}
			[CompilerGenerated]
			set
			{
				q886sNdgTv = value;
			}
		}

		public Vector4 FriendlyColor
		{
			[CompilerGenerated]
			get
			{
				return Oew6bfXMt7;
			}
			[CompilerGenerated]
			set
			{
				Oew6bfXMt7 = value;
			}
		}

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
	}

	public class TrapEspDataClass
	{
		[CompilerGenerated]
		private bool Hir6rmS2Ad;

		[CompilerGenerated]
		private float Tsg6Du6Hk6 = 20f;

		[CompilerGenerated]
		private bool fiW6ujaRlo = true;

		[CompilerGenerated]
		private bool B6c6A2QpA9 = true;

		[CompilerGenerated]
		private bool WDr6LNdH0V = true;

		[CompilerGenerated]
		private bool ckY6Ft0TSH = true;

		[CompilerGenerated]
		private Vector4 ltw6I72vok = new Vector4(1f, 0f, 0f, 1f);

		[CompilerGenerated]
		private Vector4 Qd46XiysAL = new Vector4(0f, 1f, 0f, 0.5f);

		private byte byte_0;

		private byte byte_1;

		private long long_1;

		private bool bool_0;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return Hir6rmS2Ad;
			}
			[CompilerGenerated]
			set
			{
				Hir6rmS2Ad = value;
			}
		}

		public float MaxDistance
		{
			[CompilerGenerated]
			get
			{
				return Tsg6Du6Hk6;
			}
			[CompilerGenerated]
			set
			{
				Tsg6Du6Hk6 = value;
			}
		}

		public bool ShowLandMines
		{
			[CompilerGenerated]
			get
			{
				return fiW6ujaRlo;
			}
			[CompilerGenerated]
			set
			{
				fiW6ujaRlo = value;
			}
		}

		public bool ShowProximitySensors
		{
			[CompilerGenerated]
			get
			{
				return B6c6A2QpA9;
			}
			[CompilerGenerated]
			set
			{
				B6c6A2QpA9 = value;
			}
		}

		public bool ShowStepTriggers
		{
			[CompilerGenerated]
			get
			{
				return WDr6LNdH0V;
			}
			[CompilerGenerated]
			set
			{
				WDr6LNdH0V = value;
			}
		}

		public bool ShowTriggerRadius
		{
			[CompilerGenerated]
			get
			{
				return ckY6Ft0TSH;
			}
			[CompilerGenerated]
			set
			{
				ckY6Ft0TSH = value;
			}
		}

		public Vector4 ArmedColor
		{
			[CompilerGenerated]
			get
			{
				return ltw6I72vok;
			}
			[CompilerGenerated]
			set
			{
				ltw6I72vok = value;
			}
		}

		public Vector4 DisarmedColor
		{
			[CompilerGenerated]
			get
			{
				return Qd46XiysAL;
			}
			[CompilerGenerated]
			set
			{
				Qd46XiysAL = value;
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

		private long Int64_0
		{
			get
			{
				return long_1;
			}
			set
			{
				long_1 = value;
			}
		}

		private bool Boolean_0
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}
	}

	public class KillSoundDataClass
	{
		[CompilerGenerated]
		private bool N2d6ccShj7;

		[CompilerGenerated]
		private int TDY6m6aM0B;

		[CompilerGenerated]
		private float aFM6EFObMw;

		private float float_0;

		private int int_1;

		private long long_0;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return N2d6ccShj7;
			}
			[CompilerGenerated]
			set
			{
				N2d6ccShj7 = value;
			}
		}

		public int SoundIndex
		{
			[CompilerGenerated]
			get
			{
				return TDY6m6aM0B;
			}
			[CompilerGenerated]
			set
			{
				TDY6m6aM0B = value;
			}
		}

		public float Volume
		{
			[CompilerGenerated]
			get
			{
				return aFM6EFObMw;
			}
			[CompilerGenerated]
			set
			{
				aFM6EFObMw = value;
			}
		}

		private float Single_0
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
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
	}

	public class TargetEspDataClass
	{
		[CompilerGenerated]
		private bool vpt6qTlhjn = true;

		[CompilerGenerated]
		private Vector4 jQr6yE2567 = new Vector4(1f, 0f, 1f, 1f);

		[CompilerGenerated]
		private float w1H6RHZLX9 = 0.7f;

		[CompilerGenerated]
		private float U6w6J6letF = 0.2f;

		[CompilerGenerated]
		private float dRw6vGoHDs = 3f;

		[CompilerGenerated]
		private float vQg6SEPPnu = 0.12f;

		[CompilerGenerated]
		private float itw6OM0qRi = 1.2f;

		[CompilerGenerated]
		private bool Itt6dYudB9 = true;

		[CompilerGenerated]
		private int NPK67E49rY;

		[CompilerGenerated]
		private bool QjQ640S9TZ;

		[CompilerGenerated]
		private bool SCR6Txiln7;

		[CompilerGenerated]
		private Vector4 Icu6N2HJ4M = new Vector4(1f, 1f, 1f, 1f);

		private double double_0;

		private double double_1;

		private long long_1;

		public bool SpiritsEnabled
		{
			[CompilerGenerated]
			get
			{
				return vpt6qTlhjn;
			}
			[CompilerGenerated]
			set
			{
				vpt6qTlhjn = value;
			}
		}

		public Vector4 SpiritsColor
		{
			[CompilerGenerated]
			get
			{
				return jQr6yE2567;
			}
			[CompilerGenerated]
			set
			{
				jQr6yE2567 = value;
			}
		}

		public float SpiritsOrbitRadiusX
		{
			[CompilerGenerated]
			get
			{
				return w1H6RHZLX9;
			}
			[CompilerGenerated]
			set
			{
				w1H6RHZLX9 = value;
			}
		}

		public float SpiritsOrbitRadiusY
		{
			[CompilerGenerated]
			get
			{
				return U6w6J6letF;
			}
			[CompilerGenerated]
			set
			{
				U6w6J6letF = value;
			}
		}

		public float SpiritsSpeed
		{
			[CompilerGenerated]
			get
			{
				return dRw6vGoHDs;
			}
			[CompilerGenerated]
			set
			{
				dRw6vGoHDs = value;
			}
		}

		public float SpiritsSize
		{
			[CompilerGenerated]
			get
			{
				return vQg6SEPPnu;
			}
			[CompilerGenerated]
			set
			{
				vQg6SEPPnu = value;
			}
		}

		public float SpiritsTrailLength
		{
			[CompilerGenerated]
			get
			{
				return itw6OM0qRi;
			}
			[CompilerGenerated]
			set
			{
				itw6OM0qRi = value;
			}
		}

		public bool SpiritsSmoothFade
		{
			[CompilerGenerated]
			get
			{
				return Itt6dYudB9;
			}
			[CompilerGenerated]
			set
			{
				Itt6dYudB9 = value;
			}
		}

		public int SpiritsMode
		{
			[CompilerGenerated]
			get
			{
				return NPK67E49rY;
			}
			[CompilerGenerated]
			set
			{
				NPK67E49rY = value;
			}
		}

		public bool EnableSpringEffect
		{
			[CompilerGenerated]
			get
			{
				return QjQ640S9TZ;
			}
			[CompilerGenerated]
			set
			{
				QjQ640S9TZ = value;
			}
		}

		public bool EnableColorTint
		{
			[CompilerGenerated]
			get
			{
				return SCR6Txiln7;
			}
			[CompilerGenerated]
			set
			{
				SCR6Txiln7 = value;
			}
		}

		public Vector4 PngTintColor
		{
			[CompilerGenerated]
			get
			{
				return Icu6N2HJ4M;
			}
			[CompilerGenerated]
			set
			{
				Icu6N2HJ4M = value;
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

		private double Double_1
		{
			get
			{
				return double_1;
			}
			set
			{
				double_1 = value;
			}
		}

		private long Int64_0
		{
			get
			{
				return long_1;
			}
			set
			{
				long_1 = value;
			}
		}
	}

	public class TracersDataClass
	{
		[CompilerGenerated]
		private bool pDh60rASig;

		[CompilerGenerated]
		private int DmB6P33HVr;

		[CompilerGenerated]
		private Vector4 HTd683BieV = new Vector4(1f, 1f, 1f, 1f);

		private float float_0;

		private float float_1;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return pDh60rASig;
			}
			[CompilerGenerated]
			set
			{
				pDh60rASig = value;
			}
		}

		public int ArrowVariant
		{
			[CompilerGenerated]
			get
			{
				return DmB6P33HVr;
			}
			[CompilerGenerated]
			set
			{
				DmB6P33HVr = value;
			}
		}

		public Vector4 ArrowColor
		{
			[CompilerGenerated]
			get
			{
				return HTd683BieV;
			}
			[CompilerGenerated]
			set
			{
				HTd683BieV = value;
			}
		}

		private float Single_0
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
			}
		}

		private float Single_1
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
	}

	public class HitSoundDataClass
	{
		[CompilerGenerated]
		private bool bd36klWumf;

		[CompilerGenerated]
		private int udT63aS1U9;

		[CompilerGenerated]
		private float ehu6MGYyOk;

		private string string_1;

		private string string_2;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return bd36klWumf;
			}
			[CompilerGenerated]
			set
			{
				bd36klWumf = value;
			}
		}

		public int SoundIndex
		{
			[CompilerGenerated]
			get
			{
				return udT63aS1U9;
			}
			[CompilerGenerated]
			set
			{
				udT63aS1U9 = value;
			}
		}

		public float Volume
		{
			[CompilerGenerated]
			get
			{
				return ehu6MGYyOk;
			}
			[CompilerGenerated]
			set
			{
				ehu6MGYyOk = value;
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

		private string method_10(byte byte_0, long long_1)
		{
			return "Хитролох_иди_нахуй._______77_5_2__";
		}
	}

	public class HudOverlayDataClass
	{
		[CompilerGenerated]
		private bool EYs6fNULRr = true;

		[CompilerGenerated]
		private bool pNv6eGCr3j;

		[CompilerGenerated]
		private bool NZk6w6fZsZ = true;

		[CompilerGenerated]
		private Vector2 vNV6iPrMeJ = new Vector2(10f, 10f);

		[CompilerGenerated]
		private bool ij26ou26G5 = true;

		[CompilerGenerated]
		private Vector2 oZV6nCGgaD = new Vector2(10f, 30f);

		[CompilerGenerated]
		private bool Hmr62Gc80C = true;

		[CompilerGenerated]
		private Vector2 vab6H9rHyF = new Vector2(10f, 50f);

		[CompilerGenerated]
		private bool lHn6ZV8MEf = true;

		[CompilerGenerated]
		private Vector2 sNR6tmEBUN = new Vector2(10f, 70f);

		[CompilerGenerated]
		private Vector4 E8666uhKP1 = new Vector4(1f, 1f, 1f, 1f);

		[CompilerGenerated]
		private Vector4 tlR6gNeD9m = new Vector4(0f, 0f, 0f, 0.4f);

		[CompilerGenerated]
		private bool pNn6hx2KFS = true;

		[CompilerGenerated]
		private Vector2 kHN6jIuf0R = new Vector2(500f, 500f);

		[CompilerGenerated]
		private bool CvD65pZqIs = true;

		[CompilerGenerated]
		private Vector2 XFj6GKBHGo = new Vector2(10f, 90f);

		[CompilerGenerated]
		private bool As56YOjZtC = true;

		[CompilerGenerated]
		private Vector2 ot36lTvF92 = new Vector2(10f, 110f);

		[CompilerGenerated]
		private bool nsw6KLuumt = true;

		[CompilerGenerated]
		private Vector2 NUM6BPCNjs = new Vector2(10f, 200f);

		[CompilerGenerated]
		private bool BSa6z6nZyR = true;

		[CompilerGenerated]
		private bool BgMgp0DuJV;

		[CompilerGenerated]
		private Vector2 hmNgxGBx3h = new Vector2(10f, 240f);

		[CompilerGenerated]
		private float E7fg1nm8e7 = 30f;

		[CompilerGenerated]
		private bool bBcgVjVXT0;

		[CompilerGenerated]
		private Vector2 gDfgaV5aPX = new Vector2(100f, 100f);

		[CompilerGenerated]
		private bool oEFgQK30NW;

		[CompilerGenerated]
		private Vector2 dIIgWFXRYM = new Vector2(10f, 130f);

		[CompilerGenerated]
		private bool Pw7gCnsMbw;

		[CompilerGenerated]
		private Vector2 J0EgUTh2tO = new Vector2(10f, 150f);

		[CompilerGenerated]
		private bool EZOg99YKxj;

		[CompilerGenerated]
		private Vector2 EMAgsTHO3E = new Vector2(10f, 170f);

		[CompilerGenerated]
		private bool kr1gbGft8S;

		[CompilerGenerated]
		private Vector2 ef0grYuH4x = new Vector2(10f, 190f);

		[CompilerGenerated]
		private bool xmMgDKyrU3;

		[CompilerGenerated]
		private Vector2 JyPguU9Mjr = new Vector2(10f, 210f);

		[CompilerGenerated]
		private bool wL4gAv6kHq;

		[CompilerGenerated]
		private int cSmgLtk0lV;

		[CompilerGenerated]
		private Vector4 TELgFljQMW = new Vector4(0f, 1f, 0f, 1f);

		[CompilerGenerated]
		private bool PB9gI4yAov;

		[CompilerGenerated]
		private Vector2 E8BgXHSWXu = new Vector2(800f, 100f);

		[CompilerGenerated]
		private float x4AgcEcMB8 = 20f;

		[CompilerGenerated]
		private bool YX3gmr2q4q;

		[CompilerGenerated]
		private Vector2 cmBgEJQlfG = new Vector2(10f, 230f);

		[CompilerGenerated]
		private bool EcqgqIfYnu = true;

		[CompilerGenerated]
		private bool kjygygD9O0 = true;

		[CompilerGenerated]
		private bool m78gRglRNy = true;

		[CompilerGenerated]
		private bool xC7gJ788a2;

		[CompilerGenerated]
		private Vector2 mvIgvZZUnU = new Vector2(10f, 280f);

		[CompilerGenerated]
		private bool ncFgStikhb = true;

		[CompilerGenerated]
		private bool FingOZeu80 = true;

		[CompilerGenerated]
		private int RC3gdMK0ce = 100;

		[CompilerGenerated]
		private bool OgLg7AQ8OA;

		[CompilerGenerated]
		private Vector2 UIZg4hNyf1 = new Vector2(10f, 230f);

		[CompilerGenerated]
		private bool Le5gTbEUyd;

		[CompilerGenerated]
		private Vector2 bQMgNU8GRJ = new Vector2(10f, 250f);

		[CompilerGenerated]
		private bool niHg0rC9n4;

		[CompilerGenerated]
		private Vector2 NTNgPvfbOj = new Vector2(10f, 270f);

		[CompilerGenerated]
		private bool M6bg8xnMej;

		[CompilerGenerated]
		private Vector2 C5ngkLXQgx = new Vector2(10f, 290f);

		private char char_1;

		private int int_0;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return EYs6fNULRr;
			}
			[CompilerGenerated]
			set
			{
				EYs6fNULRr = value;
			}
		}

		public bool EditMode
		{
			[CompilerGenerated]
			get
			{
				return pNv6eGCr3j;
			}
			[CompilerGenerated]
			set
			{
				pNv6eGCr3j = value;
			}
		}

		public bool ShowWatermark
		{
			[CompilerGenerated]
			get
			{
				return NZk6w6fZsZ;
			}
			[CompilerGenerated]
			set
			{
				NZk6w6fZsZ = value;
			}
		}

		public Vector2 WatermarkPos
		{
			[CompilerGenerated]
			get
			{
				return vNV6iPrMeJ;
			}
			[CompilerGenerated]
			set
			{
				vNV6iPrMeJ = value;
			}
		}

		public bool ShowFps
		{
			[CompilerGenerated]
			get
			{
				return ij26ou26G5;
			}
			[CompilerGenerated]
			set
			{
				ij26ou26G5 = value;
			}
		}

		public Vector2 FpsPos
		{
			[CompilerGenerated]
			get
			{
				return oZV6nCGgaD;
			}
			[CompilerGenerated]
			set
			{
				oZV6nCGgaD = value;
			}
		}

		public bool ShowCoords
		{
			[CompilerGenerated]
			get
			{
				return Hmr62Gc80C;
			}
			[CompilerGenerated]
			set
			{
				Hmr62Gc80C = value;
			}
		}

		public Vector2 CoordsPos
		{
			[CompilerGenerated]
			get
			{
				return vab6H9rHyF;
			}
			[CompilerGenerated]
			set
			{
				vab6H9rHyF = value;
			}
		}

		public bool ShowSpeed
		{
			[CompilerGenerated]
			get
			{
				return lHn6ZV8MEf;
			}
			[CompilerGenerated]
			set
			{
				lHn6ZV8MEf = value;
			}
		}

		public Vector2 SpeedPos
		{
			[CompilerGenerated]
			get
			{
				return sNR6tmEBUN;
			}
			[CompilerGenerated]
			set
			{
				sNR6tmEBUN = value;
			}
		}

		public Vector4 TextColor
		{
			[CompilerGenerated]
			get
			{
				return E8666uhKP1;
			}
			[CompilerGenerated]
			set
			{
				E8666uhKP1 = value;
			}
		}

		public Vector4 BgColor
		{
			[CompilerGenerated]
			get
			{
				return tlR6gNeD9m;
			}
			[CompilerGenerated]
			set
			{
				tlR6gNeD9m = value;
			}
		}

		public bool ShowTargetInfo
		{
			[CompilerGenerated]
			get
			{
				return pNn6hx2KFS;
			}
			[CompilerGenerated]
			set
			{
				pNn6hx2KFS = value;
			}
		}

		public Vector2 TargetInfoPos
		{
			[CompilerGenerated]
			get
			{
				return kHN6jIuf0R;
			}
			[CompilerGenerated]
			set
			{
				kHN6jIuf0R = value;
			}
		}

		public bool ShowPing
		{
			[CompilerGenerated]
			get
			{
				return CvD65pZqIs;
			}
			[CompilerGenerated]
			set
			{
				CvD65pZqIs = value;
			}
		}

		public Vector2 PingPos
		{
			[CompilerGenerated]
			get
			{
				return XFj6GKBHGo;
			}
			[CompilerGenerated]
			set
			{
				XFj6GKBHGo = value;
			}
		}

		public bool ShowRoundTime
		{
			[CompilerGenerated]
			get
			{
				return As56YOjZtC;
			}
			[CompilerGenerated]
			set
			{
				As56YOjZtC = value;
			}
		}

		public Vector2 RoundTimePos
		{
			[CompilerGenerated]
			get
			{
				return ot36lTvF92;
			}
			[CompilerGenerated]
			set
			{
				ot36lTvF92 = value;
			}
		}

		public bool ShowArrayList
		{
			[CompilerGenerated]
			get
			{
				return nsw6KLuumt;
			}
			[CompilerGenerated]
			set
			{
				nsw6KLuumt = value;
			}
		}

		public Vector2 ArrayListPos
		{
			[CompilerGenerated]
			get
			{
				return NUM6BPCNjs;
			}
			[CompilerGenerated]
			set
			{
				NUM6BPCNjs = value;
			}
		}

		public bool ArrayListRainbow
		{
			[CompilerGenerated]
			get
			{
				return BSa6z6nZyR;
			}
			[CompilerGenerated]
			set
			{
				BSa6z6nZyR = value;
			}
		}

		public bool ShowStaffList
		{
			[CompilerGenerated]
			get
			{
				return BgMgp0DuJV;
			}
			[CompilerGenerated]
			set
			{
				BgMgp0DuJV = value;
			}
		}

		public Vector2 StaffListPos
		{
			[CompilerGenerated]
			get
			{
				return hmNgxGBx3h;
			}
			[CompilerGenerated]
			set
			{
				hmNgxGBx3h = value;
			}
		}

		public float StaffListRefreshSeconds
		{
			[CompilerGenerated]
			get
			{
				return E7fg1nm8e7;
			}
			[CompilerGenerated]
			set
			{
				E7fg1nm8e7 = value;
			}
		}

		public bool ShowCompass
		{
			[CompilerGenerated]
			get
			{
				return bBcgVjVXT0;
			}
			[CompilerGenerated]
			set
			{
				bBcgVjVXT0 = value;
			}
		}

		public Vector2 CompassPos
		{
			[CompilerGenerated]
			get
			{
				return gDfgaV5aPX;
			}
			[CompilerGenerated]
			set
			{
				gDfgaV5aPX = value;
			}
		}

		public bool ShowSessionTimer
		{
			[CompilerGenerated]
			get
			{
				return oEFgQK30NW;
			}
			[CompilerGenerated]
			set
			{
				oEFgQK30NW = value;
			}
		}

		public Vector2 SessionTimerPos
		{
			[CompilerGenerated]
			get
			{
				return dIIgWFXRYM;
			}
			[CompilerGenerated]
			set
			{
				dIIgWFXRYM = value;
			}
		}

		public bool ShowKillCounter
		{
			[CompilerGenerated]
			get
			{
				return Pw7gCnsMbw;
			}
			[CompilerGenerated]
			set
			{
				Pw7gCnsMbw = value;
			}
		}

		public Vector2 KillCounterPos
		{
			[CompilerGenerated]
			get
			{
				return J0EgUTh2tO;
			}
			[CompilerGenerated]
			set
			{
				J0EgUTh2tO = value;
			}
		}

		public bool ShowVelocityMeter
		{
			[CompilerGenerated]
			get
			{
				return EZOg99YKxj;
			}
			[CompilerGenerated]
			set
			{
				EZOg99YKxj = value;
			}
		}

		public Vector2 VelocityMeterPos
		{
			[CompilerGenerated]
			get
			{
				return EMAgsTHO3E;
			}
			[CompilerGenerated]
			set
			{
				EMAgsTHO3E = value;
			}
		}

		public bool ShowServerInfo
		{
			[CompilerGenerated]
			get
			{
				return kr1gbGft8S;
			}
			[CompilerGenerated]
			set
			{
				kr1gbGft8S = value;
			}
		}

		public Vector2 ServerInfoPos
		{
			[CompilerGenerated]
			get
			{
				return ef0grYuH4x;
			}
			[CompilerGenerated]
			set
			{
				ef0grYuH4x = value;
			}
		}

		public bool ShowKeybinds
		{
			[CompilerGenerated]
			get
			{
				return xmMgDKyrU3;
			}
			[CompilerGenerated]
			set
			{
				xmMgDKyrU3 = value;
			}
		}

		public Vector2 KeybindsPos
		{
			[CompilerGenerated]
			get
			{
				return JyPguU9Mjr;
			}
			[CompilerGenerated]
			set
			{
				JyPguU9Mjr = value;
			}
		}

		public bool ShowCrosshair
		{
			[CompilerGenerated]
			get
			{
				return wL4gAv6kHq;
			}
			[CompilerGenerated]
			set
			{
				wL4gAv6kHq = value;
			}
		}

		public int CrosshairStyle
		{
			[CompilerGenerated]
			get
			{
				return cSmgLtk0lV;
			}
			[CompilerGenerated]
			set
			{
				cSmgLtk0lV = value;
			}
		}

		public Vector4 CrosshairColor
		{
			[CompilerGenerated]
			get
			{
				return TELgFljQMW;
			}
			[CompilerGenerated]
			set
			{
				TELgFljQMW = value;
			}
		}

		public bool ShowRadar
		{
			[CompilerGenerated]
			get
			{
				return PB9gI4yAov;
			}
			[CompilerGenerated]
			set
			{
				PB9gI4yAov = value;
			}
		}

		public Vector2 RadarPos
		{
			[CompilerGenerated]
			get
			{
				return E8BgXHSWXu;
			}
			[CompilerGenerated]
			set
			{
				E8BgXHSWXu = value;
			}
		}

		public float RadarRange
		{
			[CompilerGenerated]
			get
			{
				return x4AgcEcMB8;
			}
			[CompilerGenerated]
			set
			{
				x4AgcEcMB8 = value;
			}
		}

		public bool ShowShuttleTracker
		{
			[CompilerGenerated]
			get
			{
				return YX3gmr2q4q;
			}
			[CompilerGenerated]
			set
			{
				YX3gmr2q4q = value;
			}
		}

		public Vector2 ShuttleTrackerPos
		{
			[CompilerGenerated]
			get
			{
				return cmBgEJQlfG;
			}
			[CompilerGenerated]
			set
			{
				cmBgEJQlfG = value;
			}
		}

		public bool ShuttleShowDistance
		{
			[CompilerGenerated]
			get
			{
				return EcqgqIfYnu;
			}
			[CompilerGenerated]
			set
			{
				EcqgqIfYnu = value;
			}
		}

		public bool ShuttleShowDirection
		{
			[CompilerGenerated]
			get
			{
				return kjygygD9O0;
			}
			[CompilerGenerated]
			set
			{
				kjygygD9O0 = value;
			}
		}

		public bool ShuttleShowStatus
		{
			[CompilerGenerated]
			get
			{
				return m78gRglRNy;
			}
			[CompilerGenerated]
			set
			{
				m78gRglRNy = value;
			}
		}

		public bool ShowConnectionQuality
		{
			[CompilerGenerated]
			get
			{
				return xC7gJ788a2;
			}
			[CompilerGenerated]
			set
			{
				xC7gJ788a2 = value;
			}
		}

		public Vector2 ConnectionQualityPos
		{
			[CompilerGenerated]
			get
			{
				return mvIgvZZUnU;
			}
			[CompilerGenerated]
			set
			{
				mvIgvZZUnU = value;
			}
		}

		public bool ConnectionShowGraph
		{
			[CompilerGenerated]
			get
			{
				return ncFgStikhb;
			}
			[CompilerGenerated]
			set
			{
				ncFgStikhb = value;
			}
		}

		public bool ConnectionShowStats
		{
			[CompilerGenerated]
			get
			{
				return FingOZeu80;
			}
			[CompilerGenerated]
			set
			{
				FingOZeu80 = value;
			}
		}

		public int ConnectionHistorySize
		{
			[CompilerGenerated]
			get
			{
				return RC3gdMK0ce;
			}
			[CompilerGenerated]
			set
			{
				RC3gdMK0ce = value;
			}
		}

		public bool ShowSpectatorList
		{
			[CompilerGenerated]
			get
			{
				return OgLg7AQ8OA;
			}
			[CompilerGenerated]
			set
			{
				OgLg7AQ8OA = value;
			}
		}

		public Vector2 SpectatorListPos
		{
			[CompilerGenerated]
			get
			{
				return UIZg4hNyf1;
			}
			[CompilerGenerated]
			set
			{
				UIZg4hNyf1 = value;
			}
		}

		public bool ShowDamageCounter
		{
			[CompilerGenerated]
			get
			{
				return Le5gTbEUyd;
			}
			[CompilerGenerated]
			set
			{
				Le5gTbEUyd = value;
			}
		}

		public Vector2 DamageCounterPos
		{
			[CompilerGenerated]
			get
			{
				return bQMgNU8GRJ;
			}
			[CompilerGenerated]
			set
			{
				bQMgNU8GRJ = value;
			}
		}

		public bool ShowMovementKeys
		{
			[CompilerGenerated]
			get
			{
				return niHg0rC9n4;
			}
			[CompilerGenerated]
			set
			{
				niHg0rC9n4 = value;
			}
		}

		public Vector2 MovementKeysPos
		{
			[CompilerGenerated]
			get
			{
				return NTNgPvfbOj;
			}
			[CompilerGenerated]
			set
			{
				NTNgPvfbOj = value;
			}
		}

		public bool ShowCPS
		{
			[CompilerGenerated]
			get
			{
				return M6bg8xnMej;
			}
			[CompilerGenerated]
			set
			{
				M6bg8xnMej = value;
			}
		}

		public Vector2 CPSPos
		{
			[CompilerGenerated]
			get
			{
				return C5ngkLXQgx;
			}
			[CompilerGenerated]
			set
			{
				C5ngkLXQgx = value;
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
	}

	public class MeleeAimBotDataClass
	{
		[CompilerGenerated]
		private bool A1Rg3jxe4F;

		[CompilerGenerated]
		private ImGuiKey lV2gMD8AAN;

		[CompilerGenerated]
		private ImGuiKey dBGgfd8ORJ;

		[CompilerGenerated]
		private bool ne0gehSecg;

		[CompilerGenerated]
		private bool IiHgwUthuP;

		[CompilerGenerated]
		private bool QkMgiPAjmM;

		[CompilerGenerated]
		private float YsEgo04bD9;

		[CompilerGenerated]
		private Vector4 D4vgnXOI9g;

		[CompilerGenerated]
		private int Tvdg26cYBk;

		[CompilerGenerated]
		private bool lt4gHTIcfQ;

		[CompilerGenerated]
		private bool GWVgZEIuQZ;

		[CompilerGenerated]
		private float EVMgtsknhp;

		[CompilerGenerated]
		private bool yOyg6qL36x = true;

		[CompilerGenerated]
		private bool Ooagge9jNC;

		[CompilerGenerated]
		private bool O2ngh8gxEK = true;

		[CompilerGenerated]
		private List<string> A87gj4MtII = new List<string>();

		[CompilerGenerated]
		private List<string> ixWg5ww4Hu = new List<string>();

		[CompilerGenerated]
		private List<string> DlGgGOskaf = new List<string>();

		private double double_0;

		private long long_0;

		private double double_1;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return A1Rg3jxe4F;
			}
			[CompilerGenerated]
			set
			{
				A1Rg3jxe4F = value;
			}
		}

		public ImGuiKey LightHotKey
		{
			[CompilerGenerated]
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return lV2gMD8AAN;
			}
			[CompilerGenerated]
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				lV2gMD8AAN = value;
			}
		}

		public ImGuiKey HeavyHotKey
		{
			[CompilerGenerated]
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return dBGgfd8ORJ;
			}
			[CompilerGenerated]
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				dBGgfd8ORJ = value;
			}
		}

		public bool TargetCritical
		{
			[CompilerGenerated]
			get
			{
				return ne0gehSecg;
			}
			[CompilerGenerated]
			set
			{
				ne0gehSecg = value;
			}
		}

		public bool ShowCircle
		{
			[CompilerGenerated]
			get
			{
				return IiHgwUthuP;
			}
			[CompilerGenerated]
			set
			{
				IiHgwUthuP = value;
			}
		}

		public bool ShowLine
		{
			[CompilerGenerated]
			get
			{
				return QkMgiPAjmM;
			}
			[CompilerGenerated]
			set
			{
				QkMgiPAjmM = value;
			}
		}

		public float CircleRadius
		{
			[CompilerGenerated]
			get
			{
				return YsEgo04bD9;
			}
			[CompilerGenerated]
			set
			{
				YsEgo04bD9 = value;
			}
		}

		public Vector4 Color
		{
			[CompilerGenerated]
			get
			{
				return D4vgnXOI9g;
			}
			[CompilerGenerated]
			set
			{
				D4vgnXOI9g = value;
			}
		}

		public int TargetPriority
		{
			[CompilerGenerated]
			get
			{
				return Tvdg26cYBk;
			}
			[CompilerGenerated]
			set
			{
				Tvdg26cYBk = value;
			}
		}

		public bool OnlyPriority
		{
			[CompilerGenerated]
			get
			{
				return lt4gHTIcfQ;
			}
			[CompilerGenerated]
			set
			{
				lt4gHTIcfQ = value;
			}
		}

		public bool FixNetworkDelay
		{
			[CompilerGenerated]
			get
			{
				return GWVgZEIuQZ;
			}
			[CompilerGenerated]
			set
			{
				GWVgZEIuQZ = value;
			}
		}

		public float FixDelay
		{
			[CompilerGenerated]
			get
			{
				return EVMgtsknhp;
			}
			[CompilerGenerated]
			set
			{
				EVMgtsknhp = value;
			}
		}

		public bool IgnoreCuffed
		{
			[CompilerGenerated]
			get
			{
				return yOyg6qL36x;
			}
			[CompilerGenerated]
			set
			{
				yOyg6qL36x = value;
			}
		}

		public bool IgnoreDowned
		{
			[CompilerGenerated]
			get
			{
				return Ooagge9jNC;
			}
			[CompilerGenerated]
			set
			{
				Ooagge9jNC = value;
			}
		}

		public bool IgnoreDead
		{
			[CompilerGenerated]
			get
			{
				return O2ngh8gxEK;
			}
			[CompilerGenerated]
			set
			{
				O2ngh8gxEK = value;
			}
		}

		public List<string> AllowedJobs
		{
			[CompilerGenerated]
			get
			{
				return A87gj4MtII;
			}
			[CompilerGenerated]
			set
			{
				A87gj4MtII = value;
			}
		}

		public List<string> BlockedJobs
		{
			[CompilerGenerated]
			get
			{
				return ixWg5ww4Hu;
			}
			[CompilerGenerated]
			set
			{
				ixWg5ww4Hu = value;
			}
		}

		public List<string> RolePriority
		{
			[CompilerGenerated]
			get
			{
				return DlGgGOskaf;
			}
			[CompilerGenerated]
			set
			{
				DlGgGOskaf = value;
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

		private double Double_1
		{
			get
			{
				return double_1;
			}
			set
			{
				double_1 = value;
			}
		}
	}

	public class GunHelperDataClass
	{
		[CompilerGenerated]
		private bool wfcgYXEn9j;

		[CompilerGenerated]
		private bool ES2glgEwXb;

		[CompilerGenerated]
		private bool ONqgKh8EA6;

		[CompilerGenerated]
		private bool y9ygBh5c4k;

		[CompilerGenerated]
		private float pKFgzVbZvO;

		[CompilerGenerated]
		private bool mKNhplT3fR;

		private double double_0;

		private string string_0;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return wfcgYXEn9j;
			}
			[CompilerGenerated]
			set
			{
				wfcgYXEn9j = value;
			}
		}

		public bool ShowAmmo
		{
			[CompilerGenerated]
			get
			{
				return ES2glgEwXb;
			}
			[CompilerGenerated]
			set
			{
				ES2glgEwXb = value;
			}
		}

		public bool AutoBolt
		{
			[CompilerGenerated]
			get
			{
				return ONqgKh8EA6;
			}
			[CompilerGenerated]
			set
			{
				ONqgKh8EA6 = value;
			}
		}

		public bool AutoReload
		{
			[CompilerGenerated]
			get
			{
				return y9ygBh5c4k;
			}
			[CompilerGenerated]
			set
			{
				y9ygBh5c4k = value;
			}
		}

		public float AutoReloadDelay
		{
			[CompilerGenerated]
			get
			{
				return pKFgzVbZvO;
			}
			[CompilerGenerated]
			set
			{
				pKFgzVbZvO = value;
			}
		}

		public bool RotateToTarget
		{
			[CompilerGenerated]
			get
			{
				return mKNhplT3fR;
			}
			[CompilerGenerated]
			set
			{
				mKNhplT3fR = value;
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
	}

	public class SoundsDataClass
	{
		[CompilerGenerated]
		private bool JlHhxqDpkP = true;

		[CompilerGenerated]
		private int r8Ph1eLgTl;

		private float float_1;

		private bool bool_0;

		private char char_1;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return JlHhxqDpkP;
			}
			[CompilerGenerated]
			set
			{
				JlHhxqDpkP = value;
			}
		}

		public int SelectedPackIndex
		{
			[CompilerGenerated]
			get
			{
				return r8Ph1eLgTl;
			}
			[CompilerGenerated]
			set
			{
				r8Ph1eLgTl = value;
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

		private bool Boolean_0
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
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
	}

	public class MeleeHelperDataClass
	{
		[CompilerGenerated]
		private bool nrahVely1q;

		[CompilerGenerated]
		private bool jU5ha3kVaf;

		[CompilerGenerated]
		private bool vYhhQDHPf4;

		[CompilerGenerated]
		private bool roXhWSMDOx;

		private float float_0;

		private bool bool_0;

		private long long_0;

		private float float_1;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return nrahVely1q;
			}
			[CompilerGenerated]
			set
			{
				nrahVely1q = value;
			}
		}

		public bool Attack360
		{
			[CompilerGenerated]
			get
			{
				return jU5ha3kVaf;
			}
			[CompilerGenerated]
			set
			{
				jU5ha3kVaf = value;
			}
		}

		public bool AutoAttack
		{
			[CompilerGenerated]
			get
			{
				return vYhhQDHPf4;
			}
			[CompilerGenerated]
			set
			{
				vYhhQDHPf4 = value;
			}
		}

		public bool RotateToTarget
		{
			[CompilerGenerated]
			get
			{
				return roXhWSMDOx;
			}
			[CompilerGenerated]
			set
			{
				roXhWSMDOx = value;
			}
		}

		private float Single_0
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
			}
		}

		private bool Boolean_0
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

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

		private float Single_1
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
	}

	public class EspDataClass
	{
		[CompilerGenerated]
		private bool aZ9hC12JOu;

		[CompilerGenerated]
		private bool PEYhUuMJgD;

		[CompilerGenerated]
		private bool THQh9mWofJ;

		[CompilerGenerated]
		private bool A82hsoImI0;

		[CompilerGenerated]
		private bool JyyhbIoq9o;

		[CompilerGenerated]
		private bool MovhrNIbLt;

		[CompilerGenerated]
		private bool bdKhDlTN7x;

		[CompilerGenerated]
		private bool EFYhu7A9qh;

		[CompilerGenerated]
		private bool TvdhADpYKZ;

		[CompilerGenerated]
		private bool KOmhLHA80B;

		[CompilerGenerated]
		private bool lTThF8qUTL;

		[CompilerGenerated]
		private Vector4 hqyhIM3IOL;

		[CompilerGenerated]
		private Vector4 qyDhX4ZkM4;

		[CompilerGenerated]
		private Vector4 Pj5hcdAxDD;

		[CompilerGenerated]
		private Vector4 HcrhmupQA8;

		[CompilerGenerated]
		private Vector4 aZkhEksss0;

		[CompilerGenerated]
		private Vector4 t7shqxExoy;

		[CompilerGenerated]
		private Vector4 OVNhyKi63w;

		[CompilerGenerated]
		private Vector4 hydhRqeKlE;

		[CompilerGenerated]
		private Vector4 arWhJGmYW2;

		[CompilerGenerated]
		private Vector4 LZyhvvY1MU;

		[CompilerGenerated]
		private string ojjhS7SSZH;

		[CompilerGenerated]
		private int QdChOZneZy;

		[CompilerGenerated]
		private int FTmhdsfSBP;

		[CompilerGenerated]
		private string L7Lh7at4CE;

		[CompilerGenerated]
		private int bYAh4Im0JF;

		[CompilerGenerated]
		private int HUdhTX85Q2;

		[CompilerGenerated]
		private int qeNhN14guI;

		[CompilerGenerated]
		private float QSmh0FsjR4;

		[CompilerGenerated]
		private float xuMhPGeGRa;

		private float float_0;

		private string string_0;

		private byte byte_1;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return aZ9hC12JOu;
			}
			[CompilerGenerated]
			set
			{
				aZ9hC12JOu = value;
			}
		}

		public bool ShowName
		{
			[CompilerGenerated]
			get
			{
				return PEYhUuMJgD;
			}
			[CompilerGenerated]
			set
			{
				PEYhUuMJgD = value;
			}
		}

		public bool ShowCKey
		{
			[CompilerGenerated]
			get
			{
				return THQh9mWofJ;
			}
			[CompilerGenerated]
			set
			{
				THQh9mWofJ = value;
			}
		}

		public bool ShowAntag
		{
			[CompilerGenerated]
			get
			{
				return A82hsoImI0;
			}
			[CompilerGenerated]
			set
			{
				A82hsoImI0 = value;
			}
		}

		public bool ShowFriend
		{
			[CompilerGenerated]
			get
			{
				return JyyhbIoq9o;
			}
			[CompilerGenerated]
			set
			{
				JyyhbIoq9o = value;
			}
		}

		public bool ShowPriority
		{
			[CompilerGenerated]
			get
			{
				return MovhrNIbLt;
			}
			[CompilerGenerated]
			set
			{
				MovhrNIbLt = value;
			}
		}

		public bool ShowCombatMode
		{
			[CompilerGenerated]
			get
			{
				return bdKhDlTN7x;
			}
			[CompilerGenerated]
			set
			{
				bdKhDlTN7x = value;
			}
		}

		public bool ShowImplants
		{
			[CompilerGenerated]
			get
			{
				return EFYhu7A9qh;
			}
			[CompilerGenerated]
			set
			{
				EFYhu7A9qh = value;
			}
		}

		public bool ShowContraband
		{
			[CompilerGenerated]
			get
			{
				return TvdhADpYKZ;
			}
			[CompilerGenerated]
			set
			{
				TvdhADpYKZ = value;
			}
		}

		public bool ShowWeapon
		{
			[CompilerGenerated]
			get
			{
				return KOmhLHA80B;
			}
			[CompilerGenerated]
			set
			{
				KOmhLHA80B = value;
			}
		}

		public bool ShowNoSlip
		{
			[CompilerGenerated]
			get
			{
				return lTThF8qUTL;
			}
			[CompilerGenerated]
			set
			{
				lTThF8qUTL = value;
			}
		}

		public Vector4 NameColor
		{
			[CompilerGenerated]
			get
			{
				return hqyhIM3IOL;
			}
			[CompilerGenerated]
			set
			{
				hqyhIM3IOL = value;
			}
		}

		public Vector4 CKeyColor
		{
			[CompilerGenerated]
			get
			{
				return qyDhX4ZkM4;
			}
			[CompilerGenerated]
			set
			{
				qyDhX4ZkM4 = value;
			}
		}

		public Vector4 AntagColor
		{
			[CompilerGenerated]
			get
			{
				return Pj5hcdAxDD;
			}
			[CompilerGenerated]
			set
			{
				Pj5hcdAxDD = value;
			}
		}

		public Vector4 FriendColor
		{
			[CompilerGenerated]
			get
			{
				return HcrhmupQA8;
			}
			[CompilerGenerated]
			set
			{
				HcrhmupQA8 = value;
			}
		}

		public Vector4 PriorityColor
		{
			[CompilerGenerated]
			get
			{
				return aZkhEksss0;
			}
			[CompilerGenerated]
			set
			{
				aZkhEksss0 = value;
			}
		}

		public Vector4 CombatModeColor
		{
			[CompilerGenerated]
			get
			{
				return t7shqxExoy;
			}
			[CompilerGenerated]
			set
			{
				t7shqxExoy = value;
			}
		}

		public Vector4 ImplantsColor
		{
			[CompilerGenerated]
			get
			{
				return OVNhyKi63w;
			}
			[CompilerGenerated]
			set
			{
				OVNhyKi63w = value;
			}
		}

		public Vector4 ContrabandColor
		{
			[CompilerGenerated]
			get
			{
				return hydhRqeKlE;
			}
			[CompilerGenerated]
			set
			{
				hydhRqeKlE = value;
			}
		}

		public Vector4 WeaponColor
		{
			[CompilerGenerated]
			get
			{
				return arWhJGmYW2;
			}
			[CompilerGenerated]
			set
			{
				arWhJGmYW2 = value;
			}
		}

		public Vector4 NoSlipColor
		{
			[CompilerGenerated]
			get
			{
				return LZyhvvY1MU;
			}
			[CompilerGenerated]
			set
			{
				LZyhvvY1MU = value;
			}
		}

		public string MainFontPath
		{
			[CompilerGenerated]
			get
			{
				return ojjhS7SSZH;
			}
			[CompilerGenerated]
			set
			{
				ojjhS7SSZH = value;
			}
		}

		public int MainFontIndex
		{
			[CompilerGenerated]
			get
			{
				return QdChOZneZy;
			}
			[CompilerGenerated]
			set
			{
				QdChOZneZy = value;
			}
		}

		public int MainFontSize
		{
			[CompilerGenerated]
			get
			{
				return FTmhdsfSBP;
			}
			[CompilerGenerated]
			set
			{
				FTmhdsfSBP = value;
			}
		}

		public string OtherFontPath
		{
			[CompilerGenerated]
			get
			{
				return L7Lh7at4CE;
			}
			[CompilerGenerated]
			set
			{
				L7Lh7at4CE = value;
			}
		}

		public int OtherFontIndex
		{
			[CompilerGenerated]
			get
			{
				return bYAh4Im0JF;
			}
			[CompilerGenerated]
			set
			{
				bYAh4Im0JF = value;
			}
		}

		public int OtherFontSize
		{
			[CompilerGenerated]
			get
			{
				return HUdhTX85Q2;
			}
			[CompilerGenerated]
			set
			{
				HUdhTX85Q2 = value;
			}
		}

		public int FontInterval
		{
			[CompilerGenerated]
			get
			{
				return qeNhN14guI;
			}
			[CompilerGenerated]
			set
			{
				qeNhN14guI = value;
			}
		}

		public float TextOffsetX
		{
			[CompilerGenerated]
			get
			{
				return QSmh0FsjR4;
			}
			[CompilerGenerated]
			set
			{
				QSmh0FsjR4 = value;
			}
		}

		public float TextOffsetY
		{
			[CompilerGenerated]
			get
			{
				return xuMhPGeGRa;
			}
			[CompilerGenerated]
			set
			{
				xuMhPGeGRa = value;
			}
		}

		private float Single_0
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
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
	}

	public class EyeDataClass
	{
		[CompilerGenerated]
		private bool MrLh86nPE5;

		[CompilerGenerated]
		private bool UPnhkOTkwd;

		[CompilerGenerated]
		private float qZch3TgVBh;

		[CompilerGenerated]
		private bool FEAhMcUCpw;

		[CompilerGenerated]
		private ImGuiKey cTyhfTei86;

		[CompilerGenerated]
		private ImGuiKey Ph7hepoZnB;

		[CompilerGenerated]
		private ImGuiKey O5HhwklSCi;

		[CompilerGenerated]
		private ImGuiKey Lmxhimy6iR;

		private int int_0;

		private float float_0;

		private bool bool_0;

		private byte byte_2;

		public bool FovEnabled
		{
			[CompilerGenerated]
			get
			{
				return MrLh86nPE5;
			}
			[CompilerGenerated]
			set
			{
				MrLh86nPE5 = value;
			}
		}

		public bool FullBrightEnabled
		{
			[CompilerGenerated]
			get
			{
				return UPnhkOTkwd;
			}
			[CompilerGenerated]
			set
			{
				UPnhkOTkwd = value;
			}
		}

		public float Zoom
		{
			[CompilerGenerated]
			get
			{
				return qZch3TgVBh;
			}
			[CompilerGenerated]
			set
			{
				qZch3TgVBh = value;
			}
		}

		public bool SuperFastZoom
		{
			[CompilerGenerated]
			get
			{
				return FEAhMcUCpw;
			}
			[CompilerGenerated]
			set
			{
				FEAhMcUCpw = value;
			}
		}

		public ImGuiKey FovHotKey
		{
			[CompilerGenerated]
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return cTyhfTei86;
			}
			[CompilerGenerated]
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				cTyhfTei86 = value;
			}
		}

		public ImGuiKey FullBrightHotKey
		{
			[CompilerGenerated]
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return Ph7hepoZnB;
			}
			[CompilerGenerated]
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				Ph7hepoZnB = value;
			}
		}

		public ImGuiKey ZoomUpHotKey
		{
			[CompilerGenerated]
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return O5HhwklSCi;
			}
			[CompilerGenerated]
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				O5HhwklSCi = value;
			}
		}

		public ImGuiKey ZoomDownHotKey
		{
			[CompilerGenerated]
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return Lmxhimy6iR;
			}
			[CompilerGenerated]
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				Lmxhimy6iR = value;
			}
		}

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

		private float Single_0
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
			}
		}

		private bool Boolean_0
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		private byte Byte_0
		{
			get
			{
				return byte_2;
			}
			set
			{
				byte_2 = value;
			}
		}
	}

	public class HudDataClass
	{
		[CompilerGenerated]
		private bool eNXhoFk4kQ;

		[CompilerGenerated]
		private bool imPhnWqMqe;

		[CompilerGenerated]
		private bool O0lh2pj0GC;

		[CompilerGenerated]
		private bool soLhHkvpcF;

		[CompilerGenerated]
		private bool D91hZcTAgi;

		[CompilerGenerated]
		private bool JvxhtSpU2b;

		[CompilerGenerated]
		private bool sBfh6VwpxY;

		[CompilerGenerated]
		private bool KIBhgnhf0K;

		[CompilerGenerated]
		private bool uBPhh9o97a;

		[CompilerGenerated]
		private Vector4 jWGhj4GmIn;

		[CompilerGenerated]
		private bool zc6h5F4AyP;

		[CompilerGenerated]
		private bool VGZhGc7e6y;

		[CompilerGenerated]
		private bool ABbhYSWbpI;

		[CompilerGenerated]
		private bool c2Phlc2uJh;

		[CompilerGenerated]
		private float wmyhKC93nh;

		[CompilerGenerated]
		private float qo0hB6T5fx;

		[CompilerGenerated]
		private float abthzWjE7U;

		[CompilerGenerated]
		private float OrSjpV7nsC;

		[CompilerGenerated]
		private float okbjxWd8ub;

		[CompilerGenerated]
		private float W4bj1f04EK;

		[CompilerGenerated]
		private float oFvjVOp1YN;

		[CompilerGenerated]
		private float VVmjaDHQXq;

		private char char_0;

		private double double_0;

		public bool ShowHealth
		{
			[CompilerGenerated]
			get
			{
				return eNXhoFk4kQ;
			}
			[CompilerGenerated]
			set
			{
				eNXhoFk4kQ = value;
			}
		}

		public bool ShowAntag
		{
			[CompilerGenerated]
			get
			{
				return imPhnWqMqe;
			}
			[CompilerGenerated]
			set
			{
				imPhnWqMqe = value;
			}
		}

		public bool ShowJobIcons
		{
			[CompilerGenerated]
			get
			{
				return O0lh2pj0GC;
			}
			[CompilerGenerated]
			set
			{
				O0lh2pj0GC = value;
			}
		}

		public bool ShowMindShieldIcons
		{
			[CompilerGenerated]
			get
			{
				return soLhHkvpcF;
			}
			[CompilerGenerated]
			set
			{
				soLhHkvpcF = value;
			}
		}

		public bool ShowCriminalRecordIcons
		{
			[CompilerGenerated]
			get
			{
				return D91hZcTAgi;
			}
			[CompilerGenerated]
			set
			{
				D91hZcTAgi = value;
			}
		}

		public bool ShowSyndicateIcons
		{
			[CompilerGenerated]
			get
			{
				return JvxhtSpU2b;
			}
			[CompilerGenerated]
			set
			{
				JvxhtSpU2b = value;
			}
		}

		public bool ChemicalAnalysis
		{
			[CompilerGenerated]
			get
			{
				return sBfh6VwpxY;
			}
			[CompilerGenerated]
			set
			{
				sBfh6VwpxY = value;
			}
		}

		public bool ShowElectrocution
		{
			[CompilerGenerated]
			get
			{
				return KIBhgnhf0K;
			}
			[CompilerGenerated]
			set
			{
				KIBhgnhf0K = value;
			}
		}

		public bool ShowStamina
		{
			[CompilerGenerated]
			get
			{
				return uBPhh9o97a;
			}
			[CompilerGenerated]
			set
			{
				uBPhh9o97a = value;
			}
		}

		public Vector4 StaminaColor
		{
			[CompilerGenerated]
			get
			{
				return jWGhj4GmIn;
			}
			[CompilerGenerated]
			set
			{
				jWGhj4GmIn = value;
			}
		}

		public bool ShowThirstIcons
		{
			[CompilerGenerated]
			get
			{
				return zc6h5F4AyP;
			}
			[CompilerGenerated]
			set
			{
				zc6h5F4AyP = value;
			}
		}

		public bool ShowHungerIcons
		{
			[CompilerGenerated]
			get
			{
				return VGZhGc7e6y;
			}
			[CompilerGenerated]
			set
			{
				VGZhGc7e6y = value;
			}
		}

		public bool ShowContrabandDetails
		{
			[CompilerGenerated]
			get
			{
				return ABbhYSWbpI;
			}
			[CompilerGenerated]
			set
			{
				ABbhYSWbpI = value;
			}
		}

		public bool ShowAccessReaderSettings
		{
			[CompilerGenerated]
			get
			{
				return c2Phlc2uJh;
			}
			[CompilerGenerated]
			set
			{
				c2Phlc2uJh = value;
			}
		}

		public float HealthBarOffsetX
		{
			[CompilerGenerated]
			get
			{
				return wmyhKC93nh;
			}
			[CompilerGenerated]
			set
			{
				wmyhKC93nh = value;
			}
		}

		public float HealthBarOffsetY
		{
			[CompilerGenerated]
			get
			{
				return qo0hB6T5fx;
			}
			[CompilerGenerated]
			set
			{
				qo0hB6T5fx = value;
			}
		}

		public float HealthBarWidth
		{
			[CompilerGenerated]
			get
			{
				return abthzWjE7U;
			}
			[CompilerGenerated]
			set
			{
				abthzWjE7U = value;
			}
		}

		public float HealthBarHeight
		{
			[CompilerGenerated]
			get
			{
				return OrSjpV7nsC;
			}
			[CompilerGenerated]
			set
			{
				OrSjpV7nsC = value;
			}
		}

		public float StaminaBarOffsetX
		{
			[CompilerGenerated]
			get
			{
				return okbjxWd8ub;
			}
			[CompilerGenerated]
			set
			{
				okbjxWd8ub = value;
			}
		}

		public float StaminaBarOffsetY
		{
			[CompilerGenerated]
			get
			{
				return W4bj1f04EK;
			}
			[CompilerGenerated]
			set
			{
				W4bj1f04EK = value;
			}
		}

		public float StaminaBarWidth
		{
			[CompilerGenerated]
			get
			{
				return oFvjVOp1YN;
			}
			[CompilerGenerated]
			set
			{
				oFvjVOp1YN = value;
			}
		}

		public float StaminaBarHeight
		{
			[CompilerGenerated]
			get
			{
				return VVmjaDHQXq;
			}
			[CompilerGenerated]
			set
			{
				VVmjaDHQXq = value;
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
	}

	public class StorageViewerDataClass
	{
		[CompilerGenerated]
		private bool RdUjQQOwdP;

		[CompilerGenerated]
		private Vector4 srajWw2xmp;

		[CompilerGenerated]
		private ImGuiKey pjIjChInM4;

		[CompilerGenerated]
		private string NIMjUaGq1a;

		[CompilerGenerated]
		private int hfkj9mspGh;

		private string string_0;

		private byte byte_0;

		private long long_1;

		private byte byte_1;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return RdUjQQOwdP;
			}
			[CompilerGenerated]
			set
			{
				RdUjQQOwdP = value;
			}
		}

		public Vector4 Color
		{
			[CompilerGenerated]
			get
			{
				return srajWw2xmp;
			}
			[CompilerGenerated]
			set
			{
				srajWw2xmp = value;
			}
		}

		public ImGuiKey HotKey
		{
			[CompilerGenerated]
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return pjIjChInM4;
			}
			[CompilerGenerated]
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				pjIjChInM4 = value;
			}
		}

		public string FontPath
		{
			[CompilerGenerated]
			get
			{
				return NIMjUaGq1a;
			}
			[CompilerGenerated]
			set
			{
				NIMjUaGq1a = value;
			}
		}

		public int FontSize
		{
			[CompilerGenerated]
			get
			{
				return hfkj9mspGh;
			}
			[CompilerGenerated]
			set
			{
				hfkj9mspGh = value;
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

		private long Int64_0
		{
			get
			{
				return long_1;
			}
			set
			{
				long_1 = value;
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
	}

	public class AccessViewerDataClass
	{
		[CompilerGenerated]
		private bool nLHjsbg5nq;

		[CompilerGenerated]
		private Vector4 CiajbM58DL;

		[CompilerGenerated]
		private ImGuiKey iTUjrHZ1o9;

		[CompilerGenerated]
		private string rIAjD5e1aY;

		[CompilerGenerated]
		private int YXJjuR1Jn4;

		private byte byte_0;

		private string string_0;

		private char char_1;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return nLHjsbg5nq;
			}
			[CompilerGenerated]
			set
			{
				nLHjsbg5nq = value;
			}
		}

		public Vector4 Color
		{
			[CompilerGenerated]
			get
			{
				return CiajbM58DL;
			}
			[CompilerGenerated]
			set
			{
				CiajbM58DL = value;
			}
		}

		public ImGuiKey HotKey
		{
			[CompilerGenerated]
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return iTUjrHZ1o9;
			}
			[CompilerGenerated]
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				iTUjrHZ1o9 = value;
			}
		}

		public string FontPath
		{
			[CompilerGenerated]
			get
			{
				return rIAjD5e1aY;
			}
			[CompilerGenerated]
			set
			{
				rIAjD5e1aY = value;
			}
		}

		public int FontSize
		{
			[CompilerGenerated]
			get
			{
				return YXJjuR1Jn4;
			}
			[CompilerGenerated]
			set
			{
				YXJjuR1Jn4 = value;
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
				return char_1;
			}
			set
			{
				char_1 = value;
			}
		}
	}

	public class AccessCheckerDataClass
	{
		[CompilerGenerated]
		private bool FJRjAqwGKZ;

		[CompilerGenerated]
		private float UIIjLeC2C3;

		[CompilerGenerated]
		private float MJGjF7gXIP;

		[CompilerGenerated]
		private Vector4 cNGjIE0M0j;

		[CompilerGenerated]
		private Vector4 T0yjXliQrT;

		[CompilerGenerated]
		private bool Kmhjc7A68i;

		private char char_1;

		private byte byte_0;

		private long long_1;

		private long long_2;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return FJRjAqwGKZ;
			}
			[CompilerGenerated]
			set
			{
				FJRjAqwGKZ = value;
			}
		}

		public float Range
		{
			[CompilerGenerated]
			get
			{
				return UIIjLeC2C3;
			}
			[CompilerGenerated]
			set
			{
				UIIjLeC2C3 = value;
			}
		}

		public float IconSize
		{
			[CompilerGenerated]
			get
			{
				return MJGjF7gXIP;
			}
			[CompilerGenerated]
			set
			{
				MJGjF7gXIP = value;
			}
		}

		public Vector4 CheckmarkColor
		{
			[CompilerGenerated]
			get
			{
				return cNGjIE0M0j;
			}
			[CompilerGenerated]
			set
			{
				cNGjIE0M0j = value;
			}
		}

		public Vector4 CrossColor
		{
			[CompilerGenerated]
			get
			{
				return T0yjXliQrT;
			}
			[CompilerGenerated]
			set
			{
				T0yjXliQrT = value;
			}
		}

		public bool UseTextures
		{
			[CompilerGenerated]
			get
			{
				return Kmhjc7A68i;
			}
			[CompilerGenerated]
			set
			{
				Kmhjc7A68i = value;
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

		private long Int64_0
		{
			get
			{
				return long_1;
			}
			set
			{
				long_1 = value;
			}
		}

		private long Int64_1
		{
			get
			{
				return long_2;
			}
			set
			{
				long_2 = value;
			}
		}

		private string method_6(string string_0, double double_0, int int_0)
		{
			return "Хитролох_иди_нахуй._93__50____38____";
		}
	}

	public class GrillElectrocutionDataClass
	{
		[CompilerGenerated]
		private bool y6jjmb0Ybm;

		[CompilerGenerated]
		private Vector4 JDPjEla8xE;

		[CompilerGenerated]
		private float kVjjqhsfdK;

		[CompilerGenerated]
		private float fw7jyWxcFS;

		private string string_0;

		private bool bool_0;

		private char char_0;

		private long long_0;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return y6jjmb0Ybm;
			}
			[CompilerGenerated]
			set
			{
				y6jjmb0Ybm = value;
			}
		}

		public Vector4 Color
		{
			[CompilerGenerated]
			get
			{
				return JDPjEla8xE;
			}
			[CompilerGenerated]
			set
			{
				JDPjEla8xE = value;
			}
		}

		public float MaxDistance
		{
			[CompilerGenerated]
			get
			{
				return kVjjqhsfdK;
			}
			[CompilerGenerated]
			set
			{
				kVjjqhsfdK = value;
			}
		}

		public float Opacity
		{
			[CompilerGenerated]
			get
			{
				return fw7jyWxcFS;
			}
			[CompilerGenerated]
			set
			{
				fw7jyWxcFS = value;
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

		private bool Boolean_0
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
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

		private string method_4(int int_1, string string_1)
		{
			return "Хитролох_иди_нахуй._7_5___0____________";
		}
	}

	public class HealthInfoDataClass
	{
		[CompilerGenerated]
		private bool XWPjRmRbm9;

		[CompilerGenerated]
		private string ym1jJL14cN;

		[CompilerGenerated]
		private int e4mjvk8Z5M;

		[CompilerGenerated]
		private int uGHjS0Bo8h;

		[CompilerGenerated]
		private Vector2 s9bjO30qtH;

		[CompilerGenerated]
		private ImGuiKey yQojdU7V3v;

		private bool bool_0;

		private double double_1;

		private long long_2;

		private double double_2;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return XWPjRmRbm9;
			}
			[CompilerGenerated]
			set
			{
				XWPjRmRbm9 = value;
			}
		}

		public string FontPath
		{
			[CompilerGenerated]
			get
			{
				return ym1jJL14cN;
			}
			[CompilerGenerated]
			set
			{
				ym1jJL14cN = value;
			}
		}

		public int FontIndex
		{
			[CompilerGenerated]
			get
			{
				return e4mjvk8Z5M;
			}
			[CompilerGenerated]
			set
			{
				e4mjvk8Z5M = value;
			}
		}

		public int FontSize
		{
			[CompilerGenerated]
			get
			{
				return uGHjS0Bo8h;
			}
			[CompilerGenerated]
			set
			{
				uGHjS0Bo8h = value;
			}
		}

		public Vector2 TextOffset
		{
			[CompilerGenerated]
			get
			{
				return s9bjO30qtH;
			}
			[CompilerGenerated]
			set
			{
				s9bjO30qtH = value;
			}
		}

		public ImGuiKey HoldKey
		{
			[CompilerGenerated]
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return yQojdU7V3v;
			}
			[CompilerGenerated]
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				yQojdU7V3v = value;
			}
		}

		private bool Boolean_0
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		private double Double_0
		{
			get
			{
				return double_1;
			}
			set
			{
				double_1 = value;
			}
		}

		private long Int64_0
		{
			get
			{
				return long_2;
			}
			set
			{
				long_2 = value;
			}
		}

		private double Double_1
		{
			get
			{
				return double_2;
			}
			set
			{
				double_2 = value;
			}
		}
	}

	public class AnomalyScannerDataClass
	{
		[CompilerGenerated]
		private bool jW7j7BES2B;

		[CompilerGenerated]
		private Vector4 D1Cj4eVL5K;

		[CompilerGenerated]
		private float mr0jTsSKgF;

		[CompilerGenerated]
		private string ljXjNMwEPK;

		[CompilerGenerated]
		private int R0lj0eZt2M;

		[CompilerGenerated]
		private ImGuiKey XaUjPjpKn0;

		private byte byte_1;

		private long long_0;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return jW7j7BES2B;
			}
			[CompilerGenerated]
			set
			{
				jW7j7BES2B = value;
			}
		}

		public Vector4 Color
		{
			[CompilerGenerated]
			get
			{
				return D1Cj4eVL5K;
			}
			[CompilerGenerated]
			set
			{
				D1Cj4eVL5K = value;
			}
		}

		public float MaxDistance
		{
			[CompilerGenerated]
			get
			{
				return mr0jTsSKgF;
			}
			[CompilerGenerated]
			set
			{
				mr0jTsSKgF = value;
			}
		}

		public string FontPath
		{
			[CompilerGenerated]
			get
			{
				return ljXjNMwEPK;
			}
			[CompilerGenerated]
			set
			{
				ljXjNMwEPK = value;
			}
		}

		public int FontSize
		{
			[CompilerGenerated]
			get
			{
				return R0lj0eZt2M;
			}
			[CompilerGenerated]
			set
			{
				R0lj0eZt2M = value;
			}
		}

		public ImGuiKey HotKey
		{
			[CompilerGenerated]
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return XaUjPjpKn0;
			}
			[CompilerGenerated]
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				XaUjPjpKn0 = value;
			}
		}

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
	}

	public class PerformanceDataClass
	{
		[CompilerGenerated]
		private bool Jonj8P3uQH;

		[CompilerGenerated]
		private bool dN7jkcGiBU;

		[CompilerGenerated]
		private bool ntsj3BKHkE;

		[CompilerGenerated]
		private bool rT6jMdwuVf;

		[CompilerGenerated]
		private bool iF6jf7gdwY;

		[CompilerGenerated]
		private bool zZCjemZa59;

		[CompilerGenerated]
		private bool rp1jwr8HCV;

		[CompilerGenerated]
		private float ktPji3Quls;

		[CompilerGenerated]
		private bool eyNjoRKEsq;

		[CompilerGenerated]
		private bool NG5jnKy2ro;

		[CompilerGenerated]
		private bool DDhj2i2oGA;

		[CompilerGenerated]
		private bool Rq1jHQS2Rt;

		[CompilerGenerated]
		private bool L5KjZeVV3u;

		private string string_1;

		private int int_0;

		private char char_0;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return Jonj8P3uQH;
			}
			[CompilerGenerated]
			set
			{
				Jonj8P3uQH = value;
			}
		}

		public bool DisableParticles
		{
			[CompilerGenerated]
			get
			{
				return dN7jkcGiBU;
			}
			[CompilerGenerated]
			set
			{
				dN7jkcGiBU = value;
			}
		}

		public bool DisableAnimations
		{
			[CompilerGenerated]
			get
			{
				return ntsj3BKHkE;
			}
			[CompilerGenerated]
			set
			{
				ntsj3BKHkE = value;
			}
		}

		public bool SimplifyShaders
		{
			[CompilerGenerated]
			get
			{
				return rT6jMdwuVf;
			}
			[CompilerGenerated]
			set
			{
				rT6jMdwuVf = value;
			}
		}

		public bool SimplifyLighting
		{
			[CompilerGenerated]
			get
			{
				return iF6jf7gdwY;
			}
			[CompilerGenerated]
			set
			{
				iF6jf7gdwY = value;
			}
		}

		public bool DisablePostProcessing
		{
			[CompilerGenerated]
			get
			{
				return zZCjemZa59;
			}
			[CompilerGenerated]
			set
			{
				zZCjemZa59 = value;
			}
		}

		public bool AggressiveCulling
		{
			[CompilerGenerated]
			get
			{
				return rp1jwr8HCV;
			}
			[CompilerGenerated]
			set
			{
				rp1jwr8HCV = value;
			}
		}

		public float CullingDistance
		{
			[CompilerGenerated]
			get
			{
				return ktPji3Quls;
			}
			[CompilerGenerated]
			set
			{
				ktPji3Quls = value;
			}
		}

		public bool DisableDecals
		{
			[CompilerGenerated]
			get
			{
				return eyNjoRKEsq;
			}
			[CompilerGenerated]
			set
			{
				eyNjoRKEsq = value;
			}
		}

		public bool LowQualitySprites
		{
			[CompilerGenerated]
			get
			{
				return NG5jnKy2ro;
			}
			[CompilerGenerated]
			set
			{
				NG5jnKy2ro = value;
			}
		}

		public bool DisableWeatherEffects
		{
			[CompilerGenerated]
			get
			{
				return DDhj2i2oGA;
			}
			[CompilerGenerated]
			set
			{
				DDhj2i2oGA = value;
			}
		}

		public bool ReducePhysicsQuality
		{
			[CompilerGenerated]
			get
			{
				return Rq1jHQS2Rt;
			}
			[CompilerGenerated]
			set
			{
				Rq1jHQS2Rt = value;
			}
		}

		public bool DisableFootsteps
		{
			[CompilerGenerated]
			get
			{
				return L5KjZeVV3u;
			}
			[CompilerGenerated]
			set
			{
				L5KjZeVV3u = value;
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
	}

	public class CombatDataClass
	{
		[CompilerGenerated]
		private bool zeUjtVAy9K;

		[CompilerGenerated]
		private bool yWvj6Uvc7R;

		[CompilerGenerated]
		private float IZLjglscaU;

		private float float_0;

		private char char_0;

		public bool AutoBlockEnabled
		{
			[CompilerGenerated]
			get
			{
				return zeUjtVAy9K;
			}
			[CompilerGenerated]
			set
			{
				zeUjtVAy9K = value;
			}
		}

		public bool AutoLaydownEnabled
		{
			[CompilerGenerated]
			get
			{
				return yWvj6Uvc7R;
			}
			[CompilerGenerated]
			set
			{
				yWvj6Uvc7R = value;
			}
		}

		public float AutoLaydownStandUpDelay
		{
			[CompilerGenerated]
			get
			{
				return IZLjglscaU;
			}
			[CompilerGenerated]
			set
			{
				IZLjglscaU = value;
			}
		}

		private float Single_0
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
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

		private string method_9(string string_0, double double_2)
		{
			return "Хитролох_иди_нахуй._____8__87________";
		}
	}

	public class SpammerDataClass
	{
		[CompilerGenerated]
		private bool RCOjhrf7Rb;

		[CompilerGenerated]
		private string Wh9jjEnnb4;

		[CompilerGenerated]
		private int hd1j5gnpCb;

		[CompilerGenerated]
		private bool TFQjGFxqEY;

		[CompilerGenerated]
		private bool thTjYn1KpL;

		[CompilerGenerated]
		private int vZQjlIdwA2;

		[CompilerGenerated]
		private bool RETjKDTN0R;

		[CompilerGenerated]
		private string aWQjB64L8K;

		[CompilerGenerated]
		private int eFZjzR3hFn;

		[CompilerGenerated]
		private List<int> ReF5pf7oBk;

		private float float_1;

		private double double_0;

		private bool bool_0;

		private string string_0;

		public bool ChatEnabled
		{
			[CompilerGenerated]
			get
			{
				return RCOjhrf7Rb;
			}
			[CompilerGenerated]
			set
			{
				RCOjhrf7Rb = value;
			}
		}

		public string ChatText
		{
			[CompilerGenerated]
			get
			{
				return Wh9jjEnnb4;
			}
			[CompilerGenerated]
			set
			{
				Wh9jjEnnb4 = value;
			}
		}

		public int ChatDelay
		{
			[CompilerGenerated]
			get
			{
				return hd1j5gnpCb;
			}
			[CompilerGenerated]
			set
			{
				hd1j5gnpCb = value;
			}
		}

		public bool ProtectTextEnabled
		{
			[CompilerGenerated]
			get
			{
				return TFQjGFxqEY;
			}
			[CompilerGenerated]
			set
			{
				TFQjGFxqEY = value;
			}
		}

		public bool ProtectRandomLength
		{
			[CompilerGenerated]
			get
			{
				return thTjYn1KpL;
			}
			[CompilerGenerated]
			set
			{
				thTjYn1KpL = value;
			}
		}

		public int ProtectLength
		{
			[CompilerGenerated]
			get
			{
				return vZQjlIdwA2;
			}
			[CompilerGenerated]
			set
			{
				vZQjlIdwA2 = value;
			}
		}

		public bool AHelpEnabled
		{
			[CompilerGenerated]
			get
			{
				return RETjKDTN0R;
			}
			[CompilerGenerated]
			set
			{
				RETjKDTN0R = value;
			}
		}

		public string AHelpText
		{
			[CompilerGenerated]
			get
			{
				return aWQjB64L8K;
			}
			[CompilerGenerated]
			set
			{
				aWQjB64L8K = value;
			}
		}

		public int AHelpDelay
		{
			[CompilerGenerated]
			get
			{
				return eFZjzR3hFn;
			}
			[CompilerGenerated]
			set
			{
				eFZjzR3hFn = value;
			}
		}

		public List<int> Channels
		{
			[CompilerGenerated]
			get
			{
				return ReF5pf7oBk;
			}
			[CompilerGenerated]
			set
			{
				ReF5pf7oBk = value;
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
				return bool_0;
			}
			set
			{
				bool_0 = value;
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
	}

	public class PacketSpammerDataClass
	{
		[CompilerGenerated]
		private bool Xmx5xUZF92;

		[CompilerGenerated]
		private int fei51yBXM5 = 102400;

		[CompilerGenerated]
		private int n575VuUpxw = 50;

		[CompilerGenerated]
		private int Bx55aBjgL7;

		[CompilerGenerated]
		private int U6l5Qj8xdE = 4;

		[CompilerGenerated]
		private bool KRi5WJNp3h = true;

		[CompilerGenerated]
		private bool tu45C1ho9c = true;

		[CompilerGenerated]
		private int UlS5Ug1Gqf;

		private int int_0;

		private double double_1;

		private long long_0;

		private string string_1;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return Xmx5xUZF92;
			}
			[CompilerGenerated]
			set
			{
				Xmx5xUZF92 = value;
			}
		}

		public int PacketSize
		{
			[CompilerGenerated]
			get
			{
				return fei51yBXM5;
			}
			[CompilerGenerated]
			set
			{
				fei51yBXM5 = value;
			}
		}

		public int PacketsPerBurst
		{
			[CompilerGenerated]
			get
			{
				return n575VuUpxw;
			}
			[CompilerGenerated]
			set
			{
				n575VuUpxw = value;
			}
		}

		public int BurstDelay
		{
			[CompilerGenerated]
			get
			{
				return Bx55aBjgL7;
			}
			[CompilerGenerated]
			set
			{
				Bx55aBjgL7 = value;
			}
		}

		public int ThreadCount
		{
			[CompilerGenerated]
			get
			{
				return U6l5Qj8xdE;
			}
			[CompilerGenerated]
			set
			{
				U6l5Qj8xdE = value;
			}
		}

		public bool UseRandomData
		{
			[CompilerGenerated]
			get
			{
				return KRi5WJNp3h;
			}
			[CompilerGenerated]
			set
			{
				KRi5WJNp3h = value;
			}
		}

		public bool LogSending
		{
			[CompilerGenerated]
			get
			{
				return tu45C1ho9c;
			}
			[CompilerGenerated]
			set
			{
				tu45C1ho9c = value;
			}
		}

		public int PacketType
		{
			[CompilerGenerated]
			get
			{
				return UlS5Ug1Gqf;
			}
			[CompilerGenerated]
			set
			{
				UlS5Ug1Gqf = value;
			}
		}

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

		private double Double_0
		{
			get
			{
				return double_1;
			}
			set
			{
				double_1 = value;
			}
		}

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

		private string method_5(int int_1, bool bool_0)
		{
			return "Хитролох_иди_нахуй._0_________6";
		}
	}

	public class EventSpammerDataClass
	{
		[CompilerGenerated]
		private bool a0n59xQI3G;

		[CompilerGenerated]
		private int bDg5sdMdMW = 50;

		[CompilerGenerated]
		private int hsF5bPPWei = 200;

		[CompilerGenerated]
		private bool LIs5ro7028;

		[CompilerGenerated]
		private int vIT5DrnaXg = 5;

		[CompilerGenerated]
		private bool XV55uy0UVU = true;

		[CompilerGenerated]
		private bool dB75AX8P0j = true;

		[CompilerGenerated]
		private bool W0J5Lfleeq = true;

		[CompilerGenerated]
		private bool y6p5FZJv9C = true;

		[CompilerGenerated]
		private bool nkU5Iqm8Qv = true;

		[CompilerGenerated]
		private bool mWv5XI3hcy = true;

		[CompilerGenerated]
		private bool u8q5cIAgwu = true;

		[CompilerGenerated]
		private bool ki55mhFc1I = true;

		[CompilerGenerated]
		private bool Qua5EKoRH1 = true;

		[CompilerGenerated]
		private bool F8W5q3dCZT = true;

		[CompilerGenerated]
		private bool NMi5yrFOJs = true;

		[CompilerGenerated]
		private bool omO5RS8PRq = true;

		[CompilerGenerated]
		private bool U4S5JAZvV9 = true;

		[CompilerGenerated]
		private bool qbp5vuKf8f = true;

		[CompilerGenerated]
		private bool kvj5Sc7CV8 = true;

		[CompilerGenerated]
		private bool NT35OteKBV = true;

		[CompilerGenerated]
		private bool AM15dB76d1 = true;

		[CompilerGenerated]
		private bool LSY57oWCJK = true;

		[CompilerGenerated]
		private bool TcG54U59IT = true;

		private bool bool_0;

		private long long_1;

		private char char_0;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return a0n59xQI3G;
			}
			[CompilerGenerated]
			set
			{
				a0n59xQI3G = value;
			}
		}

		public int MinDelay
		{
			[CompilerGenerated]
			get
			{
				return bDg5sdMdMW;
			}
			[CompilerGenerated]
			set
			{
				bDg5sdMdMW = value;
			}
		}

		public int MaxDelay
		{
			[CompilerGenerated]
			get
			{
				return hsF5bPPWei;
			}
			[CompilerGenerated]
			set
			{
				hsF5bPPWei = value;
			}
		}

		public bool BurstMode
		{
			[CompilerGenerated]
			get
			{
				return LIs5ro7028;
			}
			[CompilerGenerated]
			set
			{
				LIs5ro7028 = value;
			}
		}

		public int BurstSize
		{
			[CompilerGenerated]
			get
			{
				return vIT5DrnaXg;
			}
			[CompilerGenerated]
			set
			{
				vIT5DrnaXg = value;
			}
		}

		public bool SpamInteraction
		{
			[CompilerGenerated]
			get
			{
				return XV55uy0UVU;
			}
			[CompilerGenerated]
			set
			{
				XV55uy0UVU = value;
			}
		}

		public bool SpamHandActivate
		{
			[CompilerGenerated]
			get
			{
				return dB75AX8P0j;
			}
			[CompilerGenerated]
			set
			{
				dB75AX8P0j = value;
			}
		}

		public bool SpamItemDrop
		{
			[CompilerGenerated]
			get
			{
				return W0J5Lfleeq;
			}
			[CompilerGenerated]
			set
			{
				W0J5Lfleeq = value;
			}
		}

		public bool SpamItemPickup
		{
			[CompilerGenerated]
			get
			{
				return y6p5FZJv9C;
			}
			[CompilerGenerated]
			set
			{
				y6p5FZJv9C = value;
			}
		}

		public bool SpamPull
		{
			[CompilerGenerated]
			get
			{
				return nkU5Iqm8Qv;
			}
			[CompilerGenerated]
			set
			{
				nkU5Iqm8Qv = value;
			}
		}

		public bool SpamPush
		{
			[CompilerGenerated]
			get
			{
				return mWv5XI3hcy;
			}
			[CompilerGenerated]
			set
			{
				mWv5XI3hcy = value;
			}
		}

		public bool SpamMoveInput
		{
			[CompilerGenerated]
			get
			{
				return u8q5cIAgwu;
			}
			[CompilerGenerated]
			set
			{
				u8q5cIAgwu = value;
			}
		}

		public bool SpamSprint
		{
			[CompilerGenerated]
			get
			{
				return ki55mhFc1I;
			}
			[CompilerGenerated]
			set
			{
				ki55mhFc1I = value;
			}
		}

		public bool SpamCrouch
		{
			[CompilerGenerated]
			get
			{
				return Qua5EKoRH1;
			}
			[CompilerGenerated]
			set
			{
				Qua5EKoRH1 = value;
			}
		}

		public bool SpamVerb
		{
			[CompilerGenerated]
			get
			{
				return F8W5q3dCZT;
			}
			[CompilerGenerated]
			set
			{
				F8W5q3dCZT = value;
			}
		}

		public bool SpamExamine
		{
			[CompilerGenerated]
			get
			{
				return NMi5yrFOJs;
			}
			[CompilerGenerated]
			set
			{
				NMi5yrFOJs = value;
			}
		}

		public bool SpamAttack
		{
			[CompilerGenerated]
			get
			{
				return omO5RS8PRq;
			}
			[CompilerGenerated]
			set
			{
				omO5RS8PRq = value;
			}
		}

		public bool SpamUse
		{
			[CompilerGenerated]
			get
			{
				return U4S5JAZvV9;
			}
			[CompilerGenerated]
			set
			{
				U4S5JAZvV9 = value;
			}
		}

		public bool SpamThrow
		{
			[CompilerGenerated]
			get
			{
				return qbp5vuKf8f;
			}
			[CompilerGenerated]
			set
			{
				qbp5vuKf8f = value;
			}
		}

		public bool SpamEquip
		{
			[CompilerGenerated]
			get
			{
				return kvj5Sc7CV8;
			}
			[CompilerGenerated]
			set
			{
				kvj5Sc7CV8 = value;
			}
		}

		public bool SpamUnequip
		{
			[CompilerGenerated]
			get
			{
				return NT35OteKBV;
			}
			[CompilerGenerated]
			set
			{
				NT35OteKBV = value;
			}
		}

		public bool SpamStorage
		{
			[CompilerGenerated]
			get
			{
				return AM15dB76d1;
			}
			[CompilerGenerated]
			set
			{
				AM15dB76d1 = value;
			}
		}

		public bool SpamContainer
		{
			[CompilerGenerated]
			get
			{
				return LSY57oWCJK;
			}
			[CompilerGenerated]
			set
			{
				LSY57oWCJK = value;
			}
		}

		public bool SpamWield
		{
			[CompilerGenerated]
			get
			{
				return TcG54U59IT;
			}
			[CompilerGenerated]
			set
			{
				TcG54U59IT = value;
			}
		}

		private bool Boolean_0
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		private long Int64_0
		{
			get
			{
				return long_1;
			}
			set
			{
				long_1 = value;
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
	}

	public class MiscDataClass
	{
		[CompilerGenerated]
		private bool FCX5TEFES1;

		[CompilerGenerated]
		private float wXo5NxpY5o;

		[CompilerGenerated]
		private bool S4L50BOf5A;

		[CompilerGenerated]
		private float Ree5PuTo84 = 0.2f;

		[CompilerGenerated]
		private float gnZ58YGS4T = 10f;

		[CompilerGenerated]
		private bool TOF5kLNgML;

		[CompilerGenerated]
		private bool v8n53GWfDK;

		[CompilerGenerated]
		private bool vmP5M4vP8H;

		[CompilerGenerated]
		private bool VVu5fq9TAc;

		[CompilerGenerated]
		private bool S615e0cqNT;

		[CompilerGenerated]
		private float VmB5wnnO0T;

		[CompilerGenerated]
		private bool lMw5iKGpx3;

		[CompilerGenerated]
		private List<ColoredString> I3k5oXvRe0;

		[CompilerGenerated]
		private bool lKW5nR6JKg;

		[CompilerGenerated]
		private bool nY8523iHNX;

		[CompilerGenerated]
		private bool QXn5HahpBd;

		[CompilerGenerated]
		private bool LHe5ZddNSs;

		[CompilerGenerated]
		private ImGuiKey W3H5t86h9E;

		[CompilerGenerated]
		private Vector4 JJm56KJ4qH = new Vector4(0f, 1f, 0f, 1f);

		[CompilerGenerated]
		private bool gbC5g6nlXZ;

		[CompilerGenerated]
		private List<string> bGN5h9D9s9 = new List<string>();

		[CompilerGenerated]
		private int Py25jdrp08;

		private float float_1;

		private bool bool_0;

		public bool ZeroGSpeedHackEnabled
		{
			[CompilerGenerated]
			get
			{
				return FCX5TEFES1;
			}
			[CompilerGenerated]
			set
			{
				FCX5TEFES1 = value;
			}
		}

		public float ZeroGSpeedDelay
		{
			[CompilerGenerated]
			get
			{
				return wXo5NxpY5o;
			}
			[CompilerGenerated]
			set
			{
				wXo5NxpY5o = value;
			}
		}

		public bool TargetStrafeEnabled
		{
			[CompilerGenerated]
			get
			{
				return S4L50BOf5A;
			}
			[CompilerGenerated]
			set
			{
				S4L50BOf5A = value;
			}
		}

		public float TargetStrafeDistance
		{
			[CompilerGenerated]
			get
			{
				return Ree5PuTo84;
			}
			[CompilerGenerated]
			set
			{
				Ree5PuTo84 = value;
			}
		}

		public float TargetStrafeRange
		{
			[CompilerGenerated]
			get
			{
				return gnZ58YGS4T;
			}
			[CompilerGenerated]
			set
			{
				gnZ58YGS4T = value;
			}
		}

		public bool TrashTalkEnabled
		{
			[CompilerGenerated]
			get
			{
				return TOF5kLNgML;
			}
			[CompilerGenerated]
			set
			{
				TOF5kLNgML = value;
			}
		}

		public bool DamageOverlayEnabled
		{
			[CompilerGenerated]
			get
			{
				return v8n53GWfDK;
			}
			[CompilerGenerated]
			set
			{
				v8n53GWfDK = value;
			}
		}

		public bool AntiSoapEnabled
		{
			[CompilerGenerated]
			get
			{
				return vmP5M4vP8H;
			}
			[CompilerGenerated]
			set
			{
				vmP5M4vP8H = value;
			}
		}

		public bool AntiAfkEnabled
		{
			[CompilerGenerated]
			get
			{
				return VVu5fq9TAc;
			}
			[CompilerGenerated]
			set
			{
				VVu5fq9TAc = value;
			}
		}

		public bool AntiAimEnabled
		{
			[CompilerGenerated]
			get
			{
				return S615e0cqNT;
			}
			[CompilerGenerated]
			set
			{
				S615e0cqNT = value;
			}
		}

		public float AutoRotateSpeed
		{
			[CompilerGenerated]
			get
			{
				return VmB5wnnO0T;
			}
			[CompilerGenerated]
			set
			{
				VmB5wnnO0T = value;
			}
		}

		public bool ItemSearcherEnabled
		{
			[CompilerGenerated]
			get
			{
				return lMw5iKGpx3;
			}
			[CompilerGenerated]
			set
			{
				lMw5iKGpx3 = value;
			}
		}

		public List<ColoredString> ItemSearchEntries
		{
			[CompilerGenerated]
			get
			{
				return I3k5oXvRe0;
			}
			[CompilerGenerated]
			set
			{
				I3k5oXvRe0 = value;
			}
		}

		public bool ItemSearcherShowName
		{
			[CompilerGenerated]
			get
			{
				return lKW5nR6JKg;
			}
			[CompilerGenerated]
			set
			{
				lKW5nR6JKg = value;
			}
		}

		public bool ShowExplosive
		{
			[CompilerGenerated]
			get
			{
				return nY8523iHNX;
			}
			[CompilerGenerated]
			set
			{
				nY8523iHNX = value;
			}
		}

		public bool ShowTrajectory
		{
			[CompilerGenerated]
			get
			{
				return QXn5HahpBd;
			}
			[CompilerGenerated]
			set
			{
				QXn5HahpBd = value;
			}
		}

		public bool AutoPeekEnabled
		{
			[CompilerGenerated]
			get
			{
				return LHe5ZddNSs;
			}
			[CompilerGenerated]
			set
			{
				LHe5ZddNSs = value;
			}
		}

		public ImGuiKey AutoPeekKey
		{
			[CompilerGenerated]
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return W3H5t86h9E;
			}
			[CompilerGenerated]
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				W3H5t86h9E = value;
			}
		}

		public Vector4 AutoPeekColor
		{
			[CompilerGenerated]
			get
			{
				return JJm56KJ4qH;
			}
			[CompilerGenerated]
			set
			{
				JJm56KJ4qH = value;
			}
		}

		public bool AutoGhostRoleEnabled
		{
			[CompilerGenerated]
			get
			{
				return gbC5g6nlXZ;
			}
			[CompilerGenerated]
			set
			{
				gbC5g6nlXZ = value;
			}
		}

		public List<string> AutoGhostRoleWantedRoles
		{
			[CompilerGenerated]
			get
			{
				return bGN5h9D9s9;
			}
			[CompilerGenerated]
			set
			{
				bGN5h9D9s9 = value;
			}
		}

		public int AutoGhostRolePickDelay
		{
			[CompilerGenerated]
			get
			{
				return Py25jdrp08;
			}
			[CompilerGenerated]
			set
			{
				Py25jdrp08 = value;
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

		private bool Boolean_0
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}
	}

	public class AutoDoorDataClass
	{
		[CompilerGenerated]
		private bool HUP55peuAV;

		[CompilerGenerated]
		private bool bIp5GdOF4Y;

		private byte byte_1;

		private bool bool_1;

		private byte byte_2;

		private long long_0;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return HUP55peuAV;
			}
			[CompilerGenerated]
			set
			{
				HUP55peuAV = value;
			}
		}

		public bool AutoClose
		{
			[CompilerGenerated]
			get
			{
				return bIp5GdOF4Y;
			}
			[CompilerGenerated]
			set
			{
				bIp5GdOF4Y = value;
			}
		}

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

		private byte Byte_1
		{
			get
			{
				return byte_2;
			}
			set
			{
				byte_2 = value;
			}
		}

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
	}

	public class FunDataClass
	{
		[CompilerGenerated]
		private bool WZC5Y5NWDq;

		[CompilerGenerated]
		private bool Kyd5lOYMdT;

		[CompilerGenerated]
		private bool Ghp5KKSCcY;

		[CompilerGenerated]
		private bool YS25BxwHWG;

		[CompilerGenerated]
		private bool Nyo5z8xRMh;

		[CompilerGenerated]
		private bool PMNGpJV7gk;

		[CompilerGenerated]
		private float YWZGxaDX4G;

		[CompilerGenerated]
		private Vector4 YseG1bxOlT;

		[CompilerGenerated]
		private float eDeGVZKNUM;

		[CompilerGenerated]
		private float XZiGa2Lc7F;

		[CompilerGenerated]
		private float tX4GQQ1ooM;

		[CompilerGenerated]
		private bool FlAGWYeTLP;

		[CompilerGenerated]
		private bool slwGCvRWun;

		[CompilerGenerated]
		private bool PMXGUBAhav;

		private double double_0;

		private float float_0;

		private double double_1;

		private string string_2;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return WZC5Y5NWDq;
			}
			[CompilerGenerated]
			set
			{
				WZC5Y5NWDq = value;
			}
		}

		public bool RainbowEnabled
		{
			[CompilerGenerated]
			get
			{
				return Kyd5lOYMdT;
			}
			[CompilerGenerated]
			set
			{
				Kyd5lOYMdT = value;
			}
		}

		public bool RotationEnabled
		{
			[CompilerGenerated]
			get
			{
				return Ghp5KKSCcY;
			}
			[CompilerGenerated]
			set
			{
				Ghp5KKSCcY = value;
			}
		}

		public bool TrailsEnabled
		{
			[CompilerGenerated]
			get
			{
				return YS25BxwHWG;
			}
			[CompilerGenerated]
			set
			{
				YS25BxwHWG = value;
			}
		}

		public bool JumpEnabled
		{
			[CompilerGenerated]
			get
			{
				return Nyo5z8xRMh;
			}
			[CompilerGenerated]
			set
			{
				Nyo5z8xRMh = value;
			}
		}

		public bool ShakeEnabled
		{
			[CompilerGenerated]
			get
			{
				return PMNGpJV7gk;
			}
			[CompilerGenerated]
			set
			{
				PMNGpJV7gk = value;
			}
		}

		public float RotationSpeed
		{
			[CompilerGenerated]
			get
			{
				return YWZGxaDX4G;
			}
			[CompilerGenerated]
			set
			{
				YWZGxaDX4G = value;
			}
		}

		public Vector4 Color
		{
			[CompilerGenerated]
			get
			{
				return YseG1bxOlT;
			}
			[CompilerGenerated]
			set
			{
				YseG1bxOlT = value;
			}
		}

		public float ScaleX
		{
			[CompilerGenerated]
			get
			{
				return eDeGVZKNUM;
			}
			[CompilerGenerated]
			set
			{
				eDeGVZKNUM = value;
			}
		}

		public float ScaleY
		{
			[CompilerGenerated]
			get
			{
				return XZiGa2Lc7F;
			}
			[CompilerGenerated]
			set
			{
				XZiGa2Lc7F = value;
			}
		}

		public float RainbowSpeed
		{
			[CompilerGenerated]
			get
			{
				return tX4GQQ1ooM;
			}
			[CompilerGenerated]
			set
			{
				tX4GQQ1ooM = value;
			}
		}

		public bool AffectPlayer
		{
			[CompilerGenerated]
			get
			{
				return FlAGWYeTLP;
			}
			[CompilerGenerated]
			set
			{
				FlAGWYeTLP = value;
			}
		}

		public bool AffectMobs
		{
			[CompilerGenerated]
			get
			{
				return slwGCvRWun;
			}
			[CompilerGenerated]
			set
			{
				slwGCvRWun = value;
			}
		}

		public bool AffectOthers
		{
			[CompilerGenerated]
			get
			{
				return PMXGUBAhav;
			}
			[CompilerGenerated]
			set
			{
				PMXGUBAhav = value;
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

		private float Single_0
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
			}
		}

		private double Double_1
		{
			get
			{
				return double_1;
			}
			set
			{
				double_1 = value;
			}
		}

		private string String_0
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
	}

	public class TextureDataClass
	{
		[CompilerGenerated]
		private bool NBSG9fUQvE;

		[CompilerGenerated]
		private float wRbGsrijhK;

		[CompilerGenerated]
		private bool YKvGbHPquN;

		private char char_1;

		private int int_0;

		private bool bool_0;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return NBSG9fUQvE;
			}
			[CompilerGenerated]
			set
			{
				NBSG9fUQvE = value;
			}
		}

		public float Size
		{
			[CompilerGenerated]
			get
			{
				return wRbGsrijhK;
			}
			[CompilerGenerated]
			set
			{
				wRbGsrijhK = value;
			}
		}

		public bool MakeEntitiesInvisible
		{
			[CompilerGenerated]
			get
			{
				return YKvGbHPquN;
			}
			[CompilerGenerated]
			set
			{
				YKvGbHPquN = value;
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

		private bool Boolean_0
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}
	}

	public class SettingsDataClass
	{
		[CompilerGenerated]
		private bool c5YGr9w10D;

		[CompilerGenerated]
		private bool j0GGDl5kb1;

		[CompilerGenerated]
		private ImGuiKey xXhGubbSq2;

		[CompilerGenerated]
		private bool UP3GAkm814;

		[CompilerGenerated]
		private GEnum4 oBXGL0yJwl;

		[CompilerGenerated]
		private bool o0EGFDGIHR;

		[CompilerGenerated]
		private bool CMTGIG4PSp;

		[CompilerGenerated]
		private bool q3LGXI2wtw;

		[CompilerGenerated]
		private bool RJxGckhnMp;

		[CompilerGenerated]
		private bool BgKGm6G9BS;

		[CompilerGenerated]
		private bool Ey2GE8siDR;

		[CompilerGenerated]
		private bool uXfGqVXr5U;

		[CompilerGenerated]
		private bool AWTGyptaqp;

		[CompilerGenerated]
		private string etYGRJLHeF;

		[CompilerGenerated]
		private bool BDOGJtKHrO;

		[CompilerGenerated]
		private string wkAGvtQLAq;

		[CompilerGenerated]
		private bool lcbGSyBDiH;

		private char char_0;

		private bool bool_1;

		public bool UiCustomizable
		{
			[CompilerGenerated]
			get
			{
				return c5YGr9w10D;
			}
			[CompilerGenerated]
			set
			{
				c5YGr9w10D = value;
			}
		}

		public bool ShowMenu
		{
			[CompilerGenerated]
			get
			{
				return j0GGDl5kb1;
			}
			[CompilerGenerated]
			set
			{
				j0GGDl5kb1 = value;
			}
		}

		public ImGuiKey ShowMenuHotKey
		{
			[CompilerGenerated]
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return xXhGubbSq2;
			}
			[CompilerGenerated]
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				xXhGubbSq2 = value;
			}
		}

		public bool ShowDebugConsole
		{
			[CompilerGenerated]
			get
			{
				return UP3GAkm814;
			}
			[CompilerGenerated]
			set
			{
				UP3GAkm814 = value;
			}
		}

		public GEnum4 CurrentLanguage
		{
			[CompilerGenerated]
			get
			{
				return oBXGL0yJwl;
			}
			[CompilerGenerated]
			set
			{
				oBXGL0yJwl = value;
			}
		}

		public bool ClydePatch
		{
			[CompilerGenerated]
			get
			{
				return o0EGFDGIHR;
			}
			[CompilerGenerated]
			set
			{
				o0EGFDGIHR = value;
			}
		}

		public bool OverlaysPatch
		{
			[CompilerGenerated]
			get
			{
				return CMTGIG4PSp;
			}
			[CompilerGenerated]
			set
			{
				CMTGIG4PSp = value;
			}
		}

		public bool SmokePatch
		{
			[CompilerGenerated]
			get
			{
				return q3LGXI2wtw;
			}
			[CompilerGenerated]
			set
			{
				q3LGXI2wtw = value;
			}
		}

		public bool AdminPatch
		{
			[CompilerGenerated]
			get
			{
				return RJxGckhnMp;
			}
			[CompilerGenerated]
			set
			{
				RJxGckhnMp = value;
			}
		}

		public bool DamageForcePatch
		{
			[CompilerGenerated]
			get
			{
				return BgKGm6G9BS;
			}
			[CompilerGenerated]
			set
			{
				BgKGm6G9BS = value;
			}
		}

		public bool NoDmgFriendPatch
		{
			[CompilerGenerated]
			get
			{
				return Ey2GE8siDR;
			}
			[CompilerGenerated]
			set
			{
				Ey2GE8siDR = value;
			}
		}

		public bool AntiScreenGrubPatch
		{
			[CompilerGenerated]
			get
			{
				return uXfGqVXr5U;
			}
			[CompilerGenerated]
			set
			{
				uXfGqVXr5U = value;
			}
		}

		public bool TranslateChatPatch
		{
			[CompilerGenerated]
			get
			{
				return AWTGyptaqp;
			}
			[CompilerGenerated]
			set
			{
				AWTGyptaqp = value;
			}
		}

		public string TranslateChatLang
		{
			[CompilerGenerated]
			get
			{
				return etYGRJLHeF;
			}
			[CompilerGenerated]
			set
			{
				etYGRJLHeF = value;
			}
		}

		public bool TranslateMePatch
		{
			[CompilerGenerated]
			get
			{
				return BDOGJtKHrO;
			}
			[CompilerGenerated]
			set
			{
				BDOGJtKHrO = value;
			}
		}

		public string TranslateMeLang
		{
			[CompilerGenerated]
			get
			{
				return wkAGvtQLAq;
			}
			[CompilerGenerated]
			set
			{
				wkAGvtQLAq = value;
			}
		}

		public bool NoCameraKickPatch
		{
			[CompilerGenerated]
			get
			{
				return lcbGSyBDiH;
			}
			[CompilerGenerated]
			set
			{
				lcbGSyBDiH = value;
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

		private string method_7(bool bool_2)
		{
			return "Хитролох_иди_нахуй.____1_0_________552___";
		}
	}

	public class NotificationsDataClass
	{
		[CompilerGenerated]
		private bool WaQGOfvM55;

		[CompilerGenerated]
		private int NSiGddpMtV;

		[CompilerGenerated]
		private int vs3G7r2PNw;

		[CompilerGenerated]
		private Vector2 lW1G4FJAmY;

		[CompilerGenerated]
		private bool BuAGTNpeNt;

		private double double_1;

		private byte byte_1;

		private double double_2;

		private float float_0;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return WaQGOfvM55;
			}
			[CompilerGenerated]
			set
			{
				WaQGOfvM55 = value;
			}
		}

		public int MaxNotifications
		{
			[CompilerGenerated]
			get
			{
				return NSiGddpMtV;
			}
			[CompilerGenerated]
			set
			{
				NSiGddpMtV = value;
			}
		}

		public int FontSize
		{
			[CompilerGenerated]
			get
			{
				return vs3G7r2PNw;
			}
			[CompilerGenerated]
			set
			{
				vs3G7r2PNw = value;
			}
		}

		public Vector2 AnchorPosition
		{
			[CompilerGenerated]
			get
			{
				return lW1G4FJAmY;
			}
			[CompilerGenerated]
			set
			{
				lW1G4FJAmY = value;
			}
		}

		public bool IgnoreSizeCheck
		{
			[CompilerGenerated]
			get
			{
				return BuAGTNpeNt;
			}
			[CompilerGenerated]
			set
			{
				BuAGTNpeNt = value;
			}
		}

		private double Double_0
		{
			get
			{
				return double_1;
			}
			set
			{
				double_1 = value;
			}
		}

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

		private double Double_1
		{
			get
			{
				return double_2;
			}
			set
			{
				double_2 = value;
			}
		}

		private float Single_0
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
			}
		}

		private string method_6(long long_0, bool bool_0, double double_3)
		{
			return "Хитролох_иди_нахуй._____4_0______2___";
		}
	}

	public class NotificationSettingsDataClass
	{
		[CompilerGenerated]
		private bool BJNGNLwsyB = true;

		[CompilerGenerated]
		private bool JlfG0igeJ9 = true;

		[CompilerGenerated]
		private float V6SGPf5fLC = 50f;

		[CompilerGenerated]
		private bool wOKG8m4a1f = true;

		[CompilerGenerated]
		private float sIJGkRahTQ = 30f;

		[CompilerGenerated]
		private bool ze7G3iagMU = true;

		[CompilerGenerated]
		private float PrXGMPWVuy = 180f;

		[CompilerGenerated]
		private bool M1wGfIkyUg = true;

		[CompilerGenerated]
		private bool WXkGeUWa0s = true;

		[CompilerGenerated]
		private int Y9TGw7iNyP = 10;

		[CompilerGenerated]
		private bool kLIGihaGgB = true;

		[CompilerGenerated]
		private bool hXbGoBEABX = true;

		[CompilerGenerated]
		private bool ub1GnyBfip = true;

		[CompilerGenerated]
		private int oh8G2sqt3K;

		[CompilerGenerated]
		private float tkMGHlFu7Q = 0.3f;

		[CompilerGenerated]
		private float btCGZraeAI = 0.5f;

		[CompilerGenerated]
		private bool rWbGtlgT7F = true;

		private string string_1;

		private string string_2;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return BJNGNLwsyB;
			}
			[CompilerGenerated]
			set
			{
				BJNGNLwsyB = value;
			}
		}

		public bool LowHpNotification
		{
			[CompilerGenerated]
			get
			{
				return JlfG0igeJ9;
			}
			[CompilerGenerated]
			set
			{
				JlfG0igeJ9 = value;
			}
		}

		public float LowHpThreshold
		{
			[CompilerGenerated]
			get
			{
				return V6SGPf5fLC;
			}
			[CompilerGenerated]
			set
			{
				V6SGPf5fLC = value;
			}
		}

		public bool LowStaminaNotification
		{
			[CompilerGenerated]
			get
			{
				return wOKG8m4a1f;
			}
			[CompilerGenerated]
			set
			{
				wOKG8m4a1f = value;
			}
		}

		public float LowStaminaThreshold
		{
			[CompilerGenerated]
			get
			{
				return sIJGkRahTQ;
			}
			[CompilerGenerated]
			set
			{
				sIJGkRahTQ = value;
			}
		}

		public bool AntagSpawnNotification
		{
			[CompilerGenerated]
			get
			{
				return ze7G3iagMU;
			}
			[CompilerGenerated]
			set
			{
				ze7G3iagMU = value;
			}
		}

		public float AntagSpawnDelay
		{
			[CompilerGenerated]
			get
			{
				return PrXGMPWVuy;
			}
			[CompilerGenerated]
			set
			{
				PrXGMPWVuy = value;
			}
		}

		public bool FeatureToggleNotification
		{
			[CompilerGenerated]
			get
			{
				return M1wGfIkyUg;
			}
			[CompilerGenerated]
			set
			{
				M1wGfIkyUg = value;
			}
		}

		public bool LowAmmoNotification
		{
			[CompilerGenerated]
			get
			{
				return WXkGeUWa0s;
			}
			[CompilerGenerated]
			set
			{
				WXkGeUWa0s = value;
			}
		}

		public int LowAmmoThreshold
		{
			[CompilerGenerated]
			get
			{
				return Y9TGw7iNyP;
			}
			[CompilerGenerated]
			set
			{
				Y9TGw7iNyP = value;
			}
		}

		public bool FriendJoinNotification
		{
			[CompilerGenerated]
			get
			{
				return kLIGihaGgB;
			}
			[CompilerGenerated]
			set
			{
				kLIGihaGgB = value;
			}
		}

		public bool DangerousAtmosNotification
		{
			[CompilerGenerated]
			get
			{
				return hXbGoBEABX;
			}
			[CompilerGenerated]
			set
			{
				hXbGoBEABX = value;
			}
		}

		public bool FeatureAutoDisableNotification
		{
			[CompilerGenerated]
			get
			{
				return ub1GnyBfip;
			}
			[CompilerGenerated]
			set
			{
				ub1GnyBfip = value;
			}
		}

		public int AnimationMode
		{
			[CompilerGenerated]
			get
			{
				return oh8G2sqt3K;
			}
			[CompilerGenerated]
			set
			{
				oh8G2sqt3K = value;
			}
		}

		public float FadeInTime
		{
			[CompilerGenerated]
			get
			{
				return tkMGHlFu7Q;
			}
			[CompilerGenerated]
			set
			{
				tkMGHlFu7Q = value;
			}
		}

		public float FadeOutTime
		{
			[CompilerGenerated]
			get
			{
				return btCGZraeAI;
			}
			[CompilerGenerated]
			set
			{
				btCGZraeAI = value;
			}
		}

		public bool ShowProgressBar
		{
			[CompilerGenerated]
			get
			{
				return rWbGtlgT7F;
			}
			[CompilerGenerated]
			set
			{
				rWbGtlgT7F = value;
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

		private string method_9(string string_3, bool bool_0, double double_0)
		{
			return "Хитролох_иди_нахуй._7______27_982_8___2__";
		}
	}

	public class NoSavedConfigDataClass
	{
		[CompilerGenerated]
		private bool DVCG6HXFuh;

		[CompilerGenerated]
		private bool VwRGgFMbtr;

		[CompilerGenerated]
		private string a7VGhZvROI;

		private int int_0;

		private double double_0;

		private float float_0;

		private bool bool_0;

		public bool HasTarget
		{
			[CompilerGenerated]
			get
			{
				return DVCG6HXFuh;
			}
			[CompilerGenerated]
			set
			{
				DVCG6HXFuh = value;
			}
		}

		public bool HasAntiCheat
		{
			[CompilerGenerated]
			get
			{
				return VwRGgFMbtr;
			}
			[CompilerGenerated]
			set
			{
				VwRGgFMbtr = value;
			}
		}

		public string Version
		{
			[CompilerGenerated]
			get
			{
				return a7VGhZvROI;
			}
			[CompilerGenerated]
			set
			{
				a7VGhZvROI = value;
			}
		}

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

		private float Single_0
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
			}
		}

		private bool Boolean_0
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}
	}

	public class AutoLooterDataClass
	{
		[CompilerGenerated]
		private bool XXqGjrPSfG;

		[CompilerGenerated]
		private float ugjG5H1TFV = 2.5f;

		[CompilerGenerated]
		private float iCiGGJAAhy = 0.5f;

		[CompilerGenerated]
		private ImGuiKey qesGYYnrt2;

		[CompilerGenerated]
		private List<ColoredString> S7yGl7LKo2 = new List<ColoredString>();

		private int int_0;

		private string string_0;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return XXqGjrPSfG;
			}
			[CompilerGenerated]
			set
			{
				XXqGjrPSfG = value;
			}
		}

		public float Range
		{
			[CompilerGenerated]
			get
			{
				return ugjG5H1TFV;
			}
			[CompilerGenerated]
			set
			{
				ugjG5H1TFV = value;
			}
		}

		public float PickupDelay
		{
			[CompilerGenerated]
			get
			{
				return iCiGGJAAhy;
			}
			[CompilerGenerated]
			set
			{
				iCiGGJAAhy = value;
			}
		}

		public ImGuiKey ToggleKey
		{
			[CompilerGenerated]
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return qesGYYnrt2;
			}
			[CompilerGenerated]
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				qesGYYnrt2 = value;
			}
		}

		public List<ColoredString> LootEntries
		{
			[CompilerGenerated]
			get
			{
				return S7yGl7LKo2;
			}
			[CompilerGenerated]
			set
			{
				S7yGl7LKo2 = value;
			}
		}

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
	}

	public class AutoMedipenDataClass
	{
		[CompilerGenerated]
		private bool DSeGKNwlad;

		[CompilerGenerated]
		private float GiAGB4Cs70 = 50f;

		[CompilerGenerated]
		private List<string> NmZGz1Qjuf = new List<string>();

		[CompilerGenerated]
		private int J7WYpiHRX9;

		private int int_0;

		private int int_1;

		private string string_0;

		private string string_1;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return DSeGKNwlad;
			}
			[CompilerGenerated]
			set
			{
				DSeGKNwlad = value;
			}
		}

		public float HpThreshold
		{
			[CompilerGenerated]
			get
			{
				return GiAGB4Cs70;
			}
			[CompilerGenerated]
			set
			{
				GiAGB4Cs70 = value;
			}
		}

		public List<string> AllowedMedipens
		{
			[CompilerGenerated]
			get
			{
				return NmZGz1Qjuf;
			}
			[CompilerGenerated]
			set
			{
				NmZGz1Qjuf = value;
			}
		}

		public int ActionDelay
		{
			[CompilerGenerated]
			get
			{
				return J7WYpiHRX9;
			}
			[CompilerGenerated]
			set
			{
				J7WYpiHRX9 = value;
			}
		}

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

		private string String_1
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
	}

	public class AutoImplantDataClass
	{
		[CompilerGenerated]
		private bool rqNYxsn5Tt;

		[CompilerGenerated]
		private float hvMY1H3Ru0 = 30f;

		[CompilerGenerated]
		private List<string> QYJYVqk36b = new List<string>();

		private byte byte_1;

		private int int_0;

		private bool bool_1;

		private char char_2;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return rqNYxsn5Tt;
			}
			[CompilerGenerated]
			set
			{
				rqNYxsn5Tt = value;
			}
		}

		public float HpThreshold
		{
			[CompilerGenerated]
			get
			{
				return hvMY1H3Ru0;
			}
			[CompilerGenerated]
			set
			{
				hvMY1H3Ru0 = value;
			}
		}

		public List<string> AllowedImplants
		{
			[CompilerGenerated]
			get
			{
				return QYJYVqk36b;
			}
			[CompilerGenerated]
			set
			{
				QYJYVqk36b = value;
			}
		}

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

		private char Char_0
		{
			get
			{
				return char_2;
			}
			set
			{
				char_2 = value;
			}
		}
	}

	public class AutoDeconstructDataClass
	{
		[CompilerGenerated]
		private bool SBhYaCWFBo;

		[CompilerGenerated]
		private ImGuiKey CFFYQXtCbI;

		[CompilerGenerated]
		private int JnqYWTFrKd;

		private double double_0;

		private float float_1;

		private string string_0;

		private byte byte_1;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return SBhYaCWFBo;
			}
			[CompilerGenerated]
			set
			{
				SBhYaCWFBo = value;
			}
		}

		public ImGuiKey TargetKey
		{
			[CompilerGenerated]
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return CFFYQXtCbI;
			}
			[CompilerGenerated]
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				CFFYQXtCbI = value;
			}
		}

		public int ActionDelay
		{
			[CompilerGenerated]
			get
			{
				return JnqYWTFrKd;
			}
			[CompilerGenerated]
			set
			{
				JnqYWTFrKd = value;
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
				return byte_1;
			}
			set
			{
				byte_1 = value;
			}
		}
	}

	public class NukeBruteforceDataClass
	{
		[CompilerGenerated]
		private bool z5vYC2Nkfu;

		[CompilerGenerated]
		private int mVOYULaLwM = 6;

		[CompilerGenerated]
		private int PPWY9J4KbZ = 100;

		[CompilerGenerated]
		private int kEJYsLoSRZ = 50;

		private string string_1;

		private string string_2;

		private string string_3;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return z5vYC2Nkfu;
			}
			[CompilerGenerated]
			set
			{
				z5vYC2Nkfu = value;
			}
		}

		public int CodeLength
		{
			[CompilerGenerated]
			get
			{
				return mVOYULaLwM;
			}
			[CompilerGenerated]
			set
			{
				mVOYULaLwM = value;
			}
		}

		public int Speed
		{
			[CompilerGenerated]
			get
			{
				return PPWY9J4KbZ;
			}
			[CompilerGenerated]
			set
			{
				PPWY9J4KbZ = value;
			}
		}

		public int InputDelay
		{
			[CompilerGenerated]
			get
			{
				return kEJYsLoSRZ;
			}
			[CompilerGenerated]
			set
			{
				kEJYsLoSRZ = value;
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

		private string String_2
		{
			get
			{
				return string_3;
			}
			set
			{
				string_3 = value;
			}
		}
	}

	public class UplinkBruteforceDataClass
	{
		[CompilerGenerated]
		private bool fQhYbYhj8P;

		[CompilerGenerated]
		private int XfoYrGTeXG = 50;

		[CompilerGenerated]
		private int wIPYDKxa7D;

		[CompilerGenerated]
		private bool qfaYuaVbAh;

		private char char_0;

		private char char_1;

		private string string_0;

		private byte byte_0;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return fQhYbYhj8P;
			}
			[CompilerGenerated]
			set
			{
				fQhYbYhj8P = value;
			}
		}

		public int Speed
		{
			[CompilerGenerated]
			get
			{
				return XfoYrGTeXG;
			}
			[CompilerGenerated]
			set
			{
				XfoYrGTeXG = value;
			}
		}

		public int InputDelay
		{
			[CompilerGenerated]
			get
			{
				return wIPYDKxa7D;
			}
			[CompilerGenerated]
			set
			{
				wIPYDKxa7D = value;
			}
		}

		public bool RandomMode
		{
			[CompilerGenerated]
			get
			{
				return qfaYuaVbAh;
			}
			[CompilerGenerated]
			set
			{
				qfaYuaVbAh = value;
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

		private char Char_1
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
	}

	public class InstantPickupDataClass
	{
		[CompilerGenerated]
		private bool n9MYAcwfNh;

		[CompilerGenerated]
		private bool A5WYL43RyZ;

		private char char_1;

		private int int_0;

		private string string_0;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return n9MYAcwfNh;
			}
			[CompilerGenerated]
			set
			{
				n9MYAcwfNh = value;
			}
		}

		public bool SmartEquipEnabled
		{
			[CompilerGenerated]
			get
			{
				return A5WYL43RyZ;
			}
			[CompilerGenerated]
			set
			{
				A5WYL43RyZ = value;
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
	}

	public class BacktrackDataClass
	{
		[CompilerGenerated]
		private bool kqJYFeJUwd;

		[CompilerGenerated]
		private int W8VYIsuKVA = 1;

		[CompilerGenerated]
		private bool bsaYXgceYF;

		[CompilerGenerated]
		private int F12YcmSJbX = 200;

		[CompilerGenerated]
		private bool Gn3YmfucKU = true;

		[CompilerGenerated]
		private int zVtYEfrns0 = 6;

		[CompilerGenerated]
		private Vector4 tMeYqaSdgx = new Vector4(1f, 0f, 1f, 0.5f);

		[CompilerGenerated]
		private bool yKDYyRrnNW = true;

		private string string_0;

		private byte byte_0;

		private char char_0;

		private string string_1;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return kqJYFeJUwd;
			}
			[CompilerGenerated]
			set
			{
				kqJYFeJUwd = value;
			}
		}

		public int Mode
		{
			[CompilerGenerated]
			get
			{
				return W8VYIsuKVA;
			}
			[CompilerGenerated]
			set
			{
				W8VYIsuKVA = value;
			}
		}

		public bool UseFakeLag
		{
			[CompilerGenerated]
			get
			{
				return bsaYXgceYF;
			}
			[CompilerGenerated]
			set
			{
				bsaYXgceYF = value;
			}
		}

		public int FakeLagMs
		{
			[CompilerGenerated]
			get
			{
				return F12YcmSJbX;
			}
			[CompilerGenerated]
			set
			{
				F12YcmSJbX = value;
			}
		}

		public bool ShowVisuals
		{
			[CompilerGenerated]
			get
			{
				return Gn3YmfucKU;
			}
			[CompilerGenerated]
			set
			{
				Gn3YmfucKU = value;
			}
		}

		public int VisualsMode
		{
			[CompilerGenerated]
			get
			{
				return zVtYEfrns0;
			}
			[CompilerGenerated]
			set
			{
				zVtYEfrns0 = value;
			}
		}

		public Vector4 VisualsColor
		{
			[CompilerGenerated]
			get
			{
				return tMeYqaSdgx;
			}
			[CompilerGenerated]
			set
			{
				tMeYqaSdgx = value;
			}
		}

		public bool ShowLine
		{
			[CompilerGenerated]
			get
			{
				return yKDYyRrnNW;
			}
			[CompilerGenerated]
			set
			{
				yKDYyRrnNW = value;
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

		private string String_1
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
	}

	public class AutoInteractDataClass
	{
		[CompilerGenerated]
		private bool NVWYR6dWoP;

		[CompilerGenerated]
		private float Hl9YJI1eRK = 2f;

		[CompilerGenerated]
		private float k0mYvEoHg3 = 0.5f;

		[CompilerGenerated]
		private bool KpMYSbxmW8 = true;

		[CompilerGenerated]
		private bool zO1YO8sZmV = true;

		private string string_1;

		private bool bool_0;

		private double double_0;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return NVWYR6dWoP;
			}
			[CompilerGenerated]
			set
			{
				NVWYR6dWoP = value;
			}
		}

		public float Range
		{
			[CompilerGenerated]
			get
			{
				return Hl9YJI1eRK;
			}
			[CompilerGenerated]
			set
			{
				Hl9YJI1eRK = value;
			}
		}

		public float Cooldown
		{
			[CompilerGenerated]
			get
			{
				return k0mYvEoHg3;
			}
			[CompilerGenerated]
			set
			{
				k0mYvEoHg3 = value;
			}
		}

		public bool AutoPickup
		{
			[CompilerGenerated]
			get
			{
				return KpMYSbxmW8;
			}
			[CompilerGenerated]
			set
			{
				KpMYSbxmW8 = value;
			}
		}

		public bool AutoActivate
		{
			[CompilerGenerated]
			get
			{
				return zO1YO8sZmV;
			}
			[CompilerGenerated]
			set
			{
				zO1YO8sZmV = value;
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

		private bool Boolean_0
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
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
	}

	public class QuickUseDataClass
	{
		[CompilerGenerated]
		private bool YygYdugAlm;

		[CompilerGenerated]
		private ImGuiKey RVmY7APxBS = (ImGuiKey)571;

		[CompilerGenerated]
		private ImGuiKey dRBY4pXsi4 = (ImGuiKey)569;

		[CompilerGenerated]
		private ImGuiKey QGtYT3bScc = (ImGuiKey)548;

		private string string_3;

		private char char_0;

		private char char_1;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return YygYdugAlm;
			}
			[CompilerGenerated]
			set
			{
				YygYdugAlm = value;
			}
		}

		public ImGuiKey MedipenKey
		{
			[CompilerGenerated]
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return RVmY7APxBS;
			}
			[CompilerGenerated]
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				RVmY7APxBS = value;
			}
		}

		public ImGuiKey FoodKey
		{
			[CompilerGenerated]
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return dRBY4pXsi4;
			}
			[CompilerGenerated]
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				dRBY4pXsi4 = value;
			}
		}

		public ImGuiKey DrinkKey
		{
			[CompilerGenerated]
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return QGtYT3bScc;
			}
			[CompilerGenerated]
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				QGtYT3bScc = value;
			}
		}

		private string String_0
		{
			get
			{
				return string_3;
			}
			set
			{
				string_3 = value;
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

		private char Char_1
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
	}

	public class XRayDataClass
	{
		[CompilerGenerated]
		private bool r5GYNqIFRb;

		[CompilerGenerated]
		private float r7aY0pZcKZ = 20f;

		[CompilerGenerated]
		private float XF0YPfAaQH = 0.5f;

		[CompilerGenerated]
		private bool cdmY8JU1qG = true;

		[CompilerGenerated]
		private Vector4 g79Ykrra9Z = new Vector4(1f, 1f, 1f, 1f);

		[CompilerGenerated]
		private Vector4 bpAY3hBCcx = new Vector4(1f, 0f, 0f, 1f);

		[CompilerGenerated]
		private Vector4 kfbYMTY10y = new Vector4(0f, 1f, 0f, 1f);

		[CompilerGenerated]
		private Vector4 buTYfMJH22 = new Vector4(0f, 0.5f, 1f, 1f);

		private byte byte_0;

		private char char_0;

		private char char_1;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return r5GYNqIFRb;
			}
			[CompilerGenerated]
			set
			{
				r5GYNqIFRb = value;
			}
		}

		public float Range
		{
			[CompilerGenerated]
			get
			{
				return r7aY0pZcKZ;
			}
			[CompilerGenerated]
			set
			{
				r7aY0pZcKZ = value;
			}
		}

		public float Alpha
		{
			[CompilerGenerated]
			get
			{
				return XF0YPfAaQH;
			}
			[CompilerGenerated]
			set
			{
				XF0YPfAaQH = value;
			}
		}

		public bool ShowCenter
		{
			[CompilerGenerated]
			get
			{
				return cdmY8JU1qG;
			}
			[CompilerGenerated]
			set
			{
				cdmY8JU1qG = value;
			}
		}

		public Vector4 DefaultColor
		{
			[CompilerGenerated]
			get
			{
				return g79Ykrra9Z;
			}
			[CompilerGenerated]
			set
			{
				g79Ykrra9Z = value;
			}
		}

		public Vector4 PlayerColor
		{
			[CompilerGenerated]
			get
			{
				return bpAY3hBCcx;
			}
			[CompilerGenerated]
			set
			{
				bpAY3hBCcx = value;
			}
		}

		public Vector4 ItemColor
		{
			[CompilerGenerated]
			get
			{
				return kfbYMTY10y;
			}
			[CompilerGenerated]
			set
			{
				kfbYMTY10y = value;
			}
		}

		public Vector4 DoorColor
		{
			[CompilerGenerated]
			get
			{
				return buTYfMJH22;
			}
			[CompilerGenerated]
			set
			{
				buTYfMJH22 = value;
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

		private char Char_1
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
	}

	public class SmartTargetSelectionDataClass
	{
		[CompilerGenerated]
		private bool yDvYe2kGr4;

		[CompilerGenerated]
		private int eQbYwlkk4V = 2;

		[CompilerGenerated]
		private bool l7jYi0NQTe = true;

		[CompilerGenerated]
		private bool mo9YoU04om = true;

		[CompilerGenerated]
		private bool LI9YnCUN5A = true;

		[CompilerGenerated]
		private float cffY2eo0yX = 20f;

		private float float_1;

		private string string_0;

		private float float_2;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return yDvYe2kGr4;
			}
			[CompilerGenerated]
			set
			{
				yDvYe2kGr4 = value;
			}
		}

		public int Priority
		{
			[CompilerGenerated]
			get
			{
				return eQbYwlkk4V;
			}
			[CompilerGenerated]
			set
			{
				eQbYwlkk4V = value;
			}
		}

		public bool IgnoreTeammates
		{
			[CompilerGenerated]
			get
			{
				return l7jYi0NQTe;
			}
			[CompilerGenerated]
			set
			{
				l7jYi0NQTe = value;
			}
		}

		public bool IgnoreCuffed
		{
			[CompilerGenerated]
			get
			{
				return mo9YoU04om;
			}
			[CompilerGenerated]
			set
			{
				mo9YoU04om = value;
			}
		}

		public bool IgnoreDead
		{
			[CompilerGenerated]
			get
			{
				return LI9YnCUN5A;
			}
			[CompilerGenerated]
			set
			{
				LI9YnCUN5A = value;
			}
		}

		public float MaxRange
		{
			[CompilerGenerated]
			get
			{
				return cffY2eo0yX;
			}
			[CompilerGenerated]
			set
			{
				cffY2eo0yX = value;
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

		private float Single_1
		{
			get
			{
				return float_2;
			}
			set
			{
				float_2 = value;
			}
		}
	}

	public class TargetLockDataClass
	{
		[CompilerGenerated]
		private bool pmgYHhIHCV;

		[CompilerGenerated]
		private ImGuiKey QTYYZjToGd = (ImGuiKey)565;

		[CompilerGenerated]
		private ImGuiKey j1GYtu3Yfk = (ImGuiKey)570;

		[CompilerGenerated]
		private float VHFY6UQmV0 = 25f;

		[CompilerGenerated]
		private bool e4MYgrFjr5 = true;

		[CompilerGenerated]
		private bool d9EYhM2WOa = true;

		[CompilerGenerated]
		private Vector4 LTbYjCcheu = new Vector4(1f, 0f, 0f, 1f);

		private float float_0;

		private char char_1;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return pmgYHhIHCV;
			}
			[CompilerGenerated]
			set
			{
				pmgYHhIHCV = value;
			}
		}

		public ImGuiKey LockKey
		{
			[CompilerGenerated]
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return QTYYZjToGd;
			}
			[CompilerGenerated]
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				QTYYZjToGd = value;
			}
		}

		public ImGuiKey UnlockKey
		{
			[CompilerGenerated]
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return j1GYtu3Yfk;
			}
			[CompilerGenerated]
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				j1GYtu3Yfk = value;
			}
		}

		public float MaxDistance
		{
			[CompilerGenerated]
			get
			{
				return VHFY6UQmV0;
			}
			[CompilerGenerated]
			set
			{
				VHFY6UQmV0 = value;
			}
		}

		public bool UnlockOnDeath
		{
			[CompilerGenerated]
			get
			{
				return e4MYgrFjr5;
			}
			[CompilerGenerated]
			set
			{
				e4MYgrFjr5 = value;
			}
		}

		public bool ShowLockIndicator
		{
			[CompilerGenerated]
			get
			{
				return d9EYhM2WOa;
			}
			[CompilerGenerated]
			set
			{
				d9EYhM2WOa = value;
			}
		}

		public Vector4 LockColor
		{
			[CompilerGenerated]
			get
			{
				return LTbYjCcheu;
			}
			[CompilerGenerated]
			set
			{
				LTbYjCcheu = value;
			}
		}

		private float Single_0
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
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
	}

	public class AutoShootDataClass
	{
		[CompilerGenerated]
		private bool cd0Y5BIqhO;

		[CompilerGenerated]
		private float zb2YGZ1Fn3 = 0.1f;

		[CompilerGenerated]
		private int pDRYYrlcil = 100;

		[CompilerGenerated]
		private bool fbQYlVylAJ = true;

		[CompilerGenerated]
		private bool XU2YKZBqxe = true;

		private float float_0;

		private bool bool_0;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return cd0Y5BIqhO;
			}
			[CompilerGenerated]
			set
			{
				cd0Y5BIqhO = value;
			}
		}

		public float AimTolerance
		{
			[CompilerGenerated]
			get
			{
				return zb2YGZ1Fn3;
			}
			[CompilerGenerated]
			set
			{
				zb2YGZ1Fn3 = value;
			}
		}

		public int FireDelay
		{
			[CompilerGenerated]
			get
			{
				return pDRYYrlcil;
			}
			[CompilerGenerated]
			set
			{
				pDRYYrlcil = value;
			}
		}

		public bool OnlyWhenLocked
		{
			[CompilerGenerated]
			get
			{
				return fbQYlVylAJ;
			}
			[CompilerGenerated]
			set
			{
				fbQYlVylAJ = value;
			}
		}

		public bool RequireLineOfSight
		{
			[CompilerGenerated]
			get
			{
				return XU2YKZBqxe;
			}
			[CompilerGenerated]
			set
			{
				XU2YKZBqxe = value;
			}
		}

		private float Single_0
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
			}
		}

		private bool Boolean_0
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}
	}

	public class TargetFiltersDataClass
	{
		[CompilerGenerated]
		private bool lLBYBn5h3v = true;

		[CompilerGenerated]
		private bool eJJYzBh89T = true;

		[CompilerGenerated]
		private bool lHJlpWV2Gg;

		[CompilerGenerated]
		private float Nqklx7c3ZE = 0.3f;

		[CompilerGenerated]
		private bool PQMl1rCBQu = true;

		[CompilerGenerated]
		private bool trZlV1SHSI = true;

		[CompilerGenerated]
		private bool fwblaeyALO = true;

		[CompilerGenerated]
		private bool VNplQGdAil;

		[CompilerGenerated]
		private bool zZIlWQUDIx = true;

		[CompilerGenerated]
		private bool w4slCxSSjG = true;

		[CompilerGenerated]
		private float tO5lU5bwkC;

		[CompilerGenerated]
		private float lPcl9q0QfP = 100f;

		[CompilerGenerated]
		private bool RNVlsNN4QE;

		[CompilerGenerated]
		private bool OK1lbFRhtZ;

		[CompilerGenerated]
		private bool hpElrEx43v;

		[CompilerGenerated]
		private bool mwVlD5c9Aw;

		[CompilerGenerated]
		private bool Ga6ludOA1V;

		[CompilerGenerated]
		private bool mB6lAA4G81;

		[CompilerGenerated]
		private bool OMflLB0V0A;

		[CompilerGenerated]
		private bool RNulFCZ4Pc;

		[CompilerGenerated]
		private bool zZAlIKYGBU;

		[CompilerGenerated]
		private bool XGllX6us1v = true;

		[CompilerGenerated]
		private bool aLDlcgFxTb = true;

		[CompilerGenerated]
		private float vuRlmyEV09 = 20f;

		[CompilerGenerated]
		private float XnDlEG2lLv;

		private float float_0;

		private string string_1;

		private byte byte_0;

		private bool bool_0;

		public bool IgnoreDead
		{
			[CompilerGenerated]
			get
			{
				return lLBYBn5h3v;
			}
			[CompilerGenerated]
			set
			{
				lLBYBn5h3v = value;
			}
		}

		public bool IgnoreGhosts
		{
			[CompilerGenerated]
			get
			{
				return eJJYzBh89T;
			}
			[CompilerGenerated]
			set
			{
				eJJYzBh89T = value;
			}
		}

		public bool IgnoreInvisible
		{
			[CompilerGenerated]
			get
			{
				return lHJlpWV2Gg;
			}
			[CompilerGenerated]
			set
			{
				lHJlpWV2Gg = value;
			}
		}

		public float MinVisibility
		{
			[CompilerGenerated]
			get
			{
				return Nqklx7c3ZE;
			}
			[CompilerGenerated]
			set
			{
				Nqklx7c3ZE = value;
			}
		}

		public bool IgnoreCuffed
		{
			[CompilerGenerated]
			get
			{
				return PQMl1rCBQu;
			}
			[CompilerGenerated]
			set
			{
				PQMl1rCBQu = value;
			}
		}

		public bool IgnoreStunned
		{
			[CompilerGenerated]
			get
			{
				return trZlV1SHSI;
			}
			[CompilerGenerated]
			set
			{
				trZlV1SHSI = value;
			}
		}

		public bool IgnoreSleeping
		{
			[CompilerGenerated]
			get
			{
				return fwblaeyALO;
			}
			[CompilerGenerated]
			set
			{
				fwblaeyALO = value;
			}
		}

		public bool IgnoreBuckled
		{
			[CompilerGenerated]
			get
			{
				return VNplQGdAil;
			}
			[CompilerGenerated]
			set
			{
				VNplQGdAil = value;
			}
		}

		public bool IgnoreCritical
		{
			[CompilerGenerated]
			get
			{
				return zZIlWQUDIx;
			}
			[CompilerGenerated]
			set
			{
				zZIlWQUDIx = value;
			}
		}

		public bool IgnoreParalyzed
		{
			[CompilerGenerated]
			get
			{
				return w4slCxSSjG;
			}
			[CompilerGenerated]
			set
			{
				w4slCxSSjG = value;
			}
		}

		public float MinHealthPercent
		{
			[CompilerGenerated]
			get
			{
				return tO5lU5bwkC;
			}
			[CompilerGenerated]
			set
			{
				tO5lU5bwkC = value;
			}
		}

		public float MaxHealthPercent
		{
			[CompilerGenerated]
			get
			{
				return lPcl9q0QfP;
			}
			[CompilerGenerated]
			set
			{
				lPcl9q0QfP = value;
			}
		}

		public bool OnlyArmed
		{
			[CompilerGenerated]
			get
			{
				return RNVlsNN4QE;
			}
			[CompilerGenerated]
			set
			{
				RNVlsNN4QE = value;
			}
		}

		public bool OnlyWithGuns
		{
			[CompilerGenerated]
			get
			{
				return OK1lbFRhtZ;
			}
			[CompilerGenerated]
			set
			{
				OK1lbFRhtZ = value;
			}
		}

		public bool IgnoreUnarmed
		{
			[CompilerGenerated]
			get
			{
				return hpElrEx43v;
			}
			[CompilerGenerated]
			set
			{
				hpElrEx43v = value;
			}
		}

		public bool OnlyInCombatMode
		{
			[CompilerGenerated]
			get
			{
				return mwVlD5c9Aw;
			}
			[CompilerGenerated]
			set
			{
				mwVlD5c9Aw = value;
			}
		}

		public bool IgnoreSecurity
		{
			[CompilerGenerated]
			get
			{
				return Ga6ludOA1V;
			}
			[CompilerGenerated]
			set
			{
				Ga6ludOA1V = value;
			}
		}

		public bool IgnoreMedical
		{
			[CompilerGenerated]
			get
			{
				return mB6lAA4G81;
			}
			[CompilerGenerated]
			set
			{
				mB6lAA4G81 = value;
			}
		}

		public bool OnlyAntagonists
		{
			[CompilerGenerated]
			get
			{
				return OMflLB0V0A;
			}
			[CompilerGenerated]
			set
			{
				OMflLB0V0A = value;
			}
		}

		public bool IgnoreNinja
		{
			[CompilerGenerated]
			get
			{
				return RNulFCZ4Pc;
			}
			[CompilerGenerated]
			set
			{
				RNulFCZ4Pc = value;
			}
		}

		public bool IgnoreNukeOps
		{
			[CompilerGenerated]
			get
			{
				return zZAlIKYGBU;
			}
			[CompilerGenerated]
			set
			{
				zZAlIKYGBU = value;
			}
		}

		public bool IgnoreTeammates
		{
			[CompilerGenerated]
			get
			{
				return XGllX6us1v;
			}
			[CompilerGenerated]
			set
			{
				XGllX6us1v = value;
			}
		}

		public bool IgnoreAdmins
		{
			[CompilerGenerated]
			get
			{
				return aLDlcgFxTb;
			}
			[CompilerGenerated]
			set
			{
				aLDlcgFxTb = value;
			}
		}

		public float MaxDistance
		{
			[CompilerGenerated]
			get
			{
				return vuRlmyEV09;
			}
			[CompilerGenerated]
			set
			{
				vuRlmyEV09 = value;
			}
		}

		public float MinDistance
		{
			[CompilerGenerated]
			get
			{
				return XnDlEG2lLv;
			}
			[CompilerGenerated]
			set
			{
				XnDlEG2lLv = value;
			}
		}

		private float Single_0
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
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

		private bool Boolean_0
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}
	}

	public class AmbientLightDataClass
	{
		[CompilerGenerated]
		private bool jMKlqifixS;

		[CompilerGenerated]
		private int ViflyeAZvh;

		[CompilerGenerated]
		private float bf9lRYUkNY = 1f;

		[CompilerGenerated]
		private Vector4 w8AlJlSopa = new Vector4(1f, 1f, 1f, 1f);

		private double double_0;

		private char char_1;

		private double double_1;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return jMKlqifixS;
			}
			[CompilerGenerated]
			set
			{
				jMKlqifixS = value;
			}
		}

		public int Mode
		{
			[CompilerGenerated]
			get
			{
				return ViflyeAZvh;
			}
			[CompilerGenerated]
			set
			{
				ViflyeAZvh = value;
			}
		}

		public float Intensity
		{
			[CompilerGenerated]
			get
			{
				return bf9lRYUkNY;
			}
			[CompilerGenerated]
			set
			{
				bf9lRYUkNY = value;
			}
		}

		public Vector4 CustomColor
		{
			[CompilerGenerated]
			get
			{
				return w8AlJlSopa;
			}
			[CompilerGenerated]
			set
			{
				w8AlJlSopa = value;
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

		private double Double_1
		{
			get
			{
				return double_1;
			}
			set
			{
				double_1 = value;
			}
		}
	}

	public class LightEnhancementDataClass
	{
		[CompilerGenerated]
		private bool RNflvOl0oB;

		[CompilerGenerated]
		private float Da1lSUsfDe = 2f;

		[CompilerGenerated]
		private float JG4lOwr0FH = 1.5f;

		private long long_0;

		private float float_0;

		private double double_0;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return RNflvOl0oB;
			}
			[CompilerGenerated]
			set
			{
				RNflvOl0oB = value;
			}
		}

		public float EnergyMultiplier
		{
			[CompilerGenerated]
			get
			{
				return Da1lSUsfDe;
			}
			[CompilerGenerated]
			set
			{
				Da1lSUsfDe = value;
			}
		}

		public float RadiusMultiplier
		{
			[CompilerGenerated]
			get
			{
				return JG4lOwr0FH;
			}
			[CompilerGenerated]
			set
			{
				JG4lOwr0FH = value;
			}
		}

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

		private float Single_0
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
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
	}

	public class HardwareUnlockerDataClass
	{
		[CompilerGenerated]
		private bool oHWldy2WZY;

		[CompilerGenerated]
		private bool tyUl7dwbtA;

		[CompilerGenerated]
		private bool QFUl4UOqoM;

		[CompilerGenerated]
		private bool QtQlTLUZ2L;

		[CompilerGenerated]
		private bool fOjlNsJDul;

		[CompilerGenerated]
		private bool Df4l06N8Ws;

		[CompilerGenerated]
		private bool LtnlPrlV3r;

		private double double_1;

		private char char_0;

		private long long_0;

		private int int_0;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return oHWldy2WZY;
			}
			[CompilerGenerated]
			set
			{
				oHWldy2WZY = value;
			}
		}

		public bool HighPriority
		{
			[CompilerGenerated]
			get
			{
				return tyUl7dwbtA;
			}
			[CompilerGenerated]
			set
			{
				tyUl7dwbtA = value;
			}
		}

		public bool RealtimePriority
		{
			[CompilerGenerated]
			get
			{
				return QFUl4UOqoM;
			}
			[CompilerGenerated]
			set
			{
				QFUl4UOqoM = value;
			}
		}

		public bool UnlockAllCores
		{
			[CompilerGenerated]
			get
			{
				return QtQlTLUZ2L;
			}
			[CompilerGenerated]
			set
			{
				QtQlTLUZ2L = value;
			}
		}

		public bool OptimizeThreadPool
		{
			[CompilerGenerated]
			get
			{
				return fOjlNsJDul;
			}
			[CompilerGenerated]
			set
			{
				fOjlNsJDul = value;
			}
		}

		public bool OptimizeGC
		{
			[CompilerGenerated]
			get
			{
				return Df4l06N8Ws;
			}
			[CompilerGenerated]
			set
			{
				Df4l06N8Ws = value;
			}
		}

		public bool GPUPriority
		{
			[CompilerGenerated]
			get
			{
				return LtnlPrlV3r;
			}
			[CompilerGenerated]
			set
			{
				LtnlPrlV3r = value;
			}
		}

		private double Double_0
		{
			get
			{
				return double_1;
			}
			set
			{
				double_1 = value;
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
	}

	public class NoTrashDataClass
	{
		[CompilerGenerated]
		private bool bsMl8gWf4l;

		[CompilerGenerated]
		private bool snElk1MJ8X;

		[CompilerGenerated]
		private bool M7dl3tyfod;

		private int int_0;

		private float float_0;

		private double double_0;

		private char char_1;

		public bool HideCasings
		{
			[CompilerGenerated]
			get
			{
				return bsMl8gWf4l;
			}
			[CompilerGenerated]
			set
			{
				bsMl8gWf4l = value;
			}
		}

		public bool HideDecals
		{
			[CompilerGenerated]
			get
			{
				return snElk1MJ8X;
			}
			[CompilerGenerated]
			set
			{
				snElk1MJ8X = value;
			}
		}

		public bool HideLamps
		{
			[CompilerGenerated]
			get
			{
				return M7dl3tyfod;
			}
			[CompilerGenerated]
			set
			{
				M7dl3tyfod = value;
			}
		}

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

		private float Single_0
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
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
	}

	public class FoamFadingDataClass
	{
		[CompilerGenerated]
		private bool HHNlMtvVBO;

		[CompilerGenerated]
		private float R1qlfqrHwT = 0.3f;

		private string string_0;

		private bool bool_1;

		private int int_0;

		private string string_1;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return HHNlMtvVBO;
			}
			[CompilerGenerated]
			set
			{
				HHNlMtvVBO = value;
			}
		}

		public float Alpha
		{
			[CompilerGenerated]
			get
			{
				return R1qlfqrHwT;
			}
			[CompilerGenerated]
			set
			{
				R1qlfqrHwT = value;
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
				return int_0;
			}
			set
			{
				int_0 = value;
			}
		}

		private string String_1
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

		private string method_7(float float_0, float float_1, int int_1)
		{
			return "Хитролох_иди_нахуй.________0__63_4__7_97";
		}
	}

	public class InsulationCheckerDataClass
	{
		[CompilerGenerated]
		private bool XwRleIdvSL;

		private int int_1;

		private double double_1;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return XwRleIdvSL;
			}
			[CompilerGenerated]
			set
			{
				XwRleIdvSL = value;
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

		private double Double_0
		{
			get
			{
				return double_1;
			}
			set
			{
				double_1 = value;
			}
		}
	}

	public class FreeCamDataClass
	{
		[CompilerGenerated]
		private bool rqWlwG7t7Z;

		[CompilerGenerated]
		private float RemlinT1Yc = 10f;

		private long long_2;

		private double double_0;

		private int int_1;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return rqWlwG7t7Z;
			}
			[CompilerGenerated]
			set
			{
				rqWlwG7t7Z = value;
			}
		}

		public float Speed
		{
			[CompilerGenerated]
			get
			{
				return RemlinT1Yc;
			}
			[CompilerGenerated]
			set
			{
				RemlinT1Yc = value;
			}
		}

		private long Int64_0
		{
			get
			{
				return long_2;
			}
			set
			{
				long_2 = value;
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
	}

	public class HitboxVisualizerDataClass
	{
		[CompilerGenerated]
		private bool zoXloI3R18;

		private int int_1;

		private int int_2;

		private bool bool_0;

		private char char_0;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return zoXloI3R18;
			}
			[CompilerGenerated]
			set
			{
				zoXloI3R18 = value;
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

		private int Int32_1
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

		private bool Boolean_0
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
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
	}

	public class SolutionScannerDataClass
	{
		[CompilerGenerated]
		private bool YFglnkr4wT;

		private long long_0;

		private string string_0;

		private string string_1;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return YFglnkr4wT;
			}
			[CompilerGenerated]
			set
			{
				YFglnkr4wT = value;
			}
		}

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

		private string String_1
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
	}

	public class NoInteractDataClass
	{
		[CompilerGenerated]
		private bool Y3ql2XJ0QB;

		private double double_1;

		private int int_1;

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return Y3ql2XJ0QB;
			}
			[CompilerGenerated]
			set
			{
				Y3ql2XJ0QB = value;
			}
		}

		private double Double_0
		{
			get
			{
				return double_1;
			}
			set
			{
				double_1 = value;
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
	}

	[CompilerGenerated]
	private ProjectileEspDataClass projectileEspDataClass_0 = new ProjectileEspDataClass();

	[CompilerGenerated]
	private AutoLooterDataClass autoLooterDataClass_0 = new AutoLooterDataClass();

	[CompilerGenerated]
	private AutoMedipenDataClass autoMedipenDataClass_0 = new AutoMedipenDataClass();

	[CompilerGenerated]
	private AutoImplantDataClass autoImplantDataClass_0 = new AutoImplantDataClass();

	[CompilerGenerated]
	private AutoDeconstructDataClass autoDeconstructDataClass_0 = new AutoDeconstructDataClass();

	[CompilerGenerated]
	private NukeBruteforceDataClass nukeBruteforceDataClass_0 = new NukeBruteforceDataClass();

	[CompilerGenerated]
	private UplinkBruteforceDataClass uplinkBruteforceDataClass_0 = new UplinkBruteforceDataClass();

	[CompilerGenerated]
	private InstantPickupDataClass instantPickupDataClass_0 = new InstantPickupDataClass();

	[CompilerGenerated]
	private GunAimBotDataClass gunAimBotDataClass_0 = new GunAimBotDataClass();

	[CompilerGenerated]
	private MeleeAimBotDataClass meleeAimBotDataClass_0 = new MeleeAimBotDataClass();

	[CompilerGenerated]
	private GunHelperDataClass gunHelperDataClass_0 = new GunHelperDataClass();

	[CompilerGenerated]
	private MeleeHelperDataClass meleeHelperDataClass_0 = new MeleeHelperDataClass();

	[CompilerGenerated]
	private EspDataClass espDataClass_0 = new EspDataClass();

	[CompilerGenerated]
	private EyeDataClass eyeDataClass_0 = new EyeDataClass();

	[CompilerGenerated]
	private HudDataClass hudDataClass_0 = new HudDataClass();

	[CompilerGenerated]
	private HitSoundDataClass hitSoundDataClass_0 = new HitSoundDataClass();

	[CompilerGenerated]
	private ThrowAimbotDataClass throwAimbotDataClass_0 = new ThrowAimbotDataClass();

	[CompilerGenerated]
	private AutoSlipDataClass autoSlipDataClass_0 = new AutoSlipDataClass();

	[CompilerGenerated]
	private BacktrackDataClass backtrackDataClass_0 = new BacktrackDataClass();

	[CompilerGenerated]
	private SoundsDataClass soundsDataClass_0 = new SoundsDataClass();

	[CompilerGenerated]
	private AutoDoorDataClass autoDoorDataClass_0 = new AutoDoorDataClass();

	[CompilerGenerated]
	private KillSoundDataClass killSoundDataClass_0 = new KillSoundDataClass();

	[CompilerGenerated]
	private HudOverlayDataClass hudOverlayDataClass_0 = new HudOverlayDataClass();

	[CompilerGenerated]
	private StorageViewerDataClass storageViewerDataClass_0 = new StorageViewerDataClass();

	[CompilerGenerated]
	private AccessViewerDataClass accessViewerDataClass_0 = new AccessViewerDataClass();

	[CompilerGenerated]
	private AccessCheckerDataClass accessCheckerDataClass_0 = new AccessCheckerDataClass();

	[CompilerGenerated]
	private GrillElectrocutionDataClass grillElectrocutionDataClass_0 = new GrillElectrocutionDataClass();

	[CompilerGenerated]
	private HealthInfoDataClass healthInfoDataClass_0 = new HealthInfoDataClass();

	[CompilerGenerated]
	private AnomalyScannerDataClass anomalyScannerDataClass_0 = new AnomalyScannerDataClass();

	[CompilerGenerated]
	private PerformanceDataClass performanceDataClass_0 = new PerformanceDataClass();

	[CompilerGenerated]
	private SpammerDataClass spammerDataClass_0 = new SpammerDataClass();

	[CompilerGenerated]
	private PacketSpammerDataClass packetSpammerDataClass_0 = new PacketSpammerDataClass();

	[CompilerGenerated]
	private EventSpammerDataClass eventSpammerDataClass_0 = new EventSpammerDataClass();

	[CompilerGenerated]
	private TargetEspDataClass targetEspDataClass_0 = new TargetEspDataClass();

	[CompilerGenerated]
	private TargetEspDataClass targetEspDataClass_1 = new TargetEspDataClass();

	[CompilerGenerated]
	private TargetEspDataClass targetEspDataClass_2 = new TargetEspDataClass();

	[CompilerGenerated]
	private TargetEspDataClass targetEspDataClass_3 = new TargetEspDataClass();

	[CompilerGenerated]
	private TargetEspDataClass targetEspDataClass_4 = new TargetEspDataClass();

	[CompilerGenerated]
	private GrenadeHelperDataClass grenadeHelperDataClass_0 = new GrenadeHelperDataClass();

	[CompilerGenerated]
	private CombatDataClass combatDataClass_0 = new CombatDataClass();

	[CompilerGenerated]
	private MovementDataClass movementDataClass_0 = new MovementDataClass();

	[CompilerGenerated]
	private TargetEspDataClass targetEspDataClass_5 = new TargetEspDataClass();

	[CompilerGenerated]
	private MiscDataClass miscDataClass_0 = new MiscDataClass();

	[CompilerGenerated]
	private FunDataClass funDataClass_0 = new FunDataClass();

	[CompilerGenerated]
	private TextureDataClass textureDataClass_0 = new TextureDataClass();

	[CompilerGenerated]
	private SettingsDataClass settingsDataClass_0 = new SettingsDataClass();

	[CompilerGenerated]
	private TargetEspDataClass targetEspDataClass_6 = new TargetEspDataClass();

	[CompilerGenerated]
	private NotificationsDataClass notificationsDataClass_0 = new NotificationsDataClass();

	[CompilerGenerated]
	private NotificationSettingsDataClass notificationSettingsDataClass_0 = new NotificationSettingsDataClass();

	[CompilerGenerated]
	private NoSavedConfigDataClass noSavedConfigDataClass_0 = new NoSavedConfigDataClass();

	[CompilerGenerated]
	private TracersDataClass tracersDataClass_0 = new TracersDataClass();

	[CompilerGenerated]
	private ChamsDataClass chamsDataClass_0 = new ChamsDataClass();

	[CompilerGenerated]
	private MinecraftVisualsDataClass minecraftVisualsDataClass_0 = new MinecraftVisualsDataClass();

	[CompilerGenerated]
	private LightSmoothDataClass lightSmoothDataClass_0 = new LightSmoothDataClass();

	[CompilerGenerated]
	private WorldParticlesDataClass worldParticlesDataClass_0 = new WorldParticlesDataClass();

	[CompilerGenerated]
	private TrailsDataClass trailsDataClass_0 = new TrailsDataClass();

	[CompilerGenerated]
	private PlayerGlowDataClass playerGlowDataClass_0 = new PlayerGlowDataClass();

	[CompilerGenerated]
	private HitParticlesDataClass hitParticlesDataClass_0 = new HitParticlesDataClass();

	[CompilerGenerated]
	private CloakedPlayerDetectorDataClass cloakedPlayerDetectorDataClass_0 = new CloakedPlayerDetectorDataClass();

	[CompilerGenerated]
	private AutoCuffDataClass autoCuffDataClass_0 = new AutoCuffDataClass();

	[CompilerGenerated]
	private AutoStopDataClass autoStopDataClass_0 = new AutoStopDataClass();

	[CompilerGenerated]
	private AutoHypoDataClass autoHypoDataClass_0 = new AutoHypoDataClass();

	[CompilerGenerated]
	private AutoHackDoorsDataClass autoHackDoorsDataClass_0 = new AutoHackDoorsDataClass();

	[CompilerGenerated]
	private AutoStripDataClass autoStripDataClass_0 = new AutoStripDataClass();

	[CompilerGenerated]
	private AutoPathDataClass autoPathDataClass_0 = new AutoPathDataClass();

	[CompilerGenerated]
	private TurretEspDataClass turretEspDataClass_0 = new TurretEspDataClass();

	[CompilerGenerated]
	private TrapEspDataClass trapEspDataClass_0 = new TrapEspDataClass();

	[CompilerGenerated]
	private SmartTargetSelectionDataClass smartTargetSelectionDataClass_0 = new SmartTargetSelectionDataClass();

	[CompilerGenerated]
	private TargetLockDataClass targetLockDataClass_0 = new TargetLockDataClass();

	[CompilerGenerated]
	private AutoShootDataClass autoShootDataClass_0 = new AutoShootDataClass();

	[CompilerGenerated]
	private TargetFiltersDataClass targetFiltersDataClass_0 = new TargetFiltersDataClass();

	[CompilerGenerated]
	private AmbientLightDataClass ambientLightDataClass_0 = new AmbientLightDataClass();

	[CompilerGenerated]
	private LightEnhancementDataClass lightEnhancementDataClass_0 = new LightEnhancementDataClass();

	[CompilerGenerated]
	private HardwareUnlockerDataClass hardwareUnlockerDataClass_0 = new HardwareUnlockerDataClass();

	[CompilerGenerated]
	private NoTrashDataClass noTrashDataClass_0 = new NoTrashDataClass();

	[CompilerGenerated]
	private FoamFadingDataClass foamFadingDataClass_0 = new FoamFadingDataClass();

	[CompilerGenerated]
	private InsulationCheckerDataClass insulationCheckerDataClass_0 = new InsulationCheckerDataClass();

	[CompilerGenerated]
	private FreeCamDataClass freeCamDataClass_0 = new FreeCamDataClass();

	[CompilerGenerated]
	private HitboxVisualizerDataClass hitboxVisualizerDataClass_0 = new HitboxVisualizerDataClass();

	[CompilerGenerated]
	private SolutionScannerDataClass solutionScannerDataClass_0 = new SolutionScannerDataClass();

	[CompilerGenerated]
	private NoInteractDataClass noInteractDataClass_0 = new NoInteractDataClass();

	[CompilerGenerated]
	private string string_0 = "dispenser";

	[CompilerGenerated]
	private List<string> list_0 = new List<string>();

	[CompilerGenerated]
	private List<string> list_1 = new List<string>();

	private char char_0;

	private int int_0;

	private int int_1;

	private float float_0;

	public ProjectileEspDataClass ProjectileEspData
	{
		[CompilerGenerated]
		get
		{
			return projectileEspDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			projectileEspDataClass_0 = value;
		}
	}

	public AutoLooterDataClass AutoLooterData
	{
		[CompilerGenerated]
		get
		{
			return autoLooterDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			autoLooterDataClass_0 = value;
		}
	}

	public AutoMedipenDataClass AutoMedipenData
	{
		[CompilerGenerated]
		get
		{
			return autoMedipenDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			autoMedipenDataClass_0 = value;
		}
	}

	public AutoImplantDataClass AutoImplantData
	{
		[CompilerGenerated]
		get
		{
			return autoImplantDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			autoImplantDataClass_0 = value;
		}
	}

	public AutoDeconstructDataClass AutoDeconstructData
	{
		[CompilerGenerated]
		get
		{
			return autoDeconstructDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			autoDeconstructDataClass_0 = value;
		}
	}

	public NukeBruteforceDataClass NukeBruteforceData
	{
		[CompilerGenerated]
		get
		{
			return nukeBruteforceDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			nukeBruteforceDataClass_0 = value;
		}
	}

	public UplinkBruteforceDataClass UplinkBruteforceData
	{
		[CompilerGenerated]
		get
		{
			return uplinkBruteforceDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			uplinkBruteforceDataClass_0 = value;
		}
	}

	public InstantPickupDataClass InstantPickupData
	{
		[CompilerGenerated]
		get
		{
			return instantPickupDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			instantPickupDataClass_0 = value;
		}
	}

	public GunAimBotDataClass GunAimBotData
	{
		[CompilerGenerated]
		get
		{
			return gunAimBotDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			gunAimBotDataClass_0 = value;
		}
	}

	public MeleeAimBotDataClass MeleeAimBotData
	{
		[CompilerGenerated]
		get
		{
			return meleeAimBotDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			meleeAimBotDataClass_0 = value;
		}
	}

	public GunHelperDataClass GunHelperData
	{
		[CompilerGenerated]
		get
		{
			return gunHelperDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			gunHelperDataClass_0 = value;
		}
	}

	public MeleeHelperDataClass MeleeHelperData
	{
		[CompilerGenerated]
		get
		{
			return meleeHelperDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			meleeHelperDataClass_0 = value;
		}
	}

	public EspDataClass EspData
	{
		[CompilerGenerated]
		get
		{
			return espDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			espDataClass_0 = value;
		}
	}

	public EyeDataClass EyeData
	{
		[CompilerGenerated]
		get
		{
			return eyeDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			eyeDataClass_0 = value;
		}
	}

	public HudDataClass HudData
	{
		[CompilerGenerated]
		get
		{
			return hudDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			hudDataClass_0 = value;
		}
	}

	public HitSoundDataClass HitSoundData
	{
		[CompilerGenerated]
		get
		{
			return hitSoundDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			hitSoundDataClass_0 = value;
		}
	}

	public ThrowAimbotDataClass ThrowAimbotData
	{
		[CompilerGenerated]
		get
		{
			return throwAimbotDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			throwAimbotDataClass_0 = value;
		}
	}

	public AutoSlipDataClass AutoSlipData
	{
		[CompilerGenerated]
		get
		{
			return autoSlipDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			autoSlipDataClass_0 = value;
		}
	}

	public BacktrackDataClass BacktrackData
	{
		[CompilerGenerated]
		get
		{
			return backtrackDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			backtrackDataClass_0 = value;
		}
	}

	public SoundsDataClass SoundsData
	{
		[CompilerGenerated]
		get
		{
			return soundsDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			soundsDataClass_0 = value;
		}
	}

	public AutoDoorDataClass AutoDoorData
	{
		[CompilerGenerated]
		get
		{
			return autoDoorDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			autoDoorDataClass_0 = value;
		}
	}

	public KillSoundDataClass KillSoundData
	{
		[CompilerGenerated]
		get
		{
			return killSoundDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			killSoundDataClass_0 = value;
		}
	}

	public HudOverlayDataClass HudOverlayData
	{
		[CompilerGenerated]
		get
		{
			return hudOverlayDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			hudOverlayDataClass_0 = value;
		}
	}

	public StorageViewerDataClass StorageViewerData
	{
		[CompilerGenerated]
		get
		{
			return storageViewerDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			storageViewerDataClass_0 = value;
		}
	}

	public AccessViewerDataClass AccessViewerData
	{
		[CompilerGenerated]
		get
		{
			return accessViewerDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			accessViewerDataClass_0 = value;
		}
	}

	public AccessCheckerDataClass AccessCheckerData
	{
		[CompilerGenerated]
		get
		{
			return accessCheckerDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			accessCheckerDataClass_0 = value;
		}
	}

	public GrillElectrocutionDataClass GrillElectrocutionData
	{
		[CompilerGenerated]
		get
		{
			return grillElectrocutionDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			grillElectrocutionDataClass_0 = value;
		}
	}

	public HealthInfoDataClass HealthInfoData
	{
		[CompilerGenerated]
		get
		{
			return healthInfoDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			healthInfoDataClass_0 = value;
		}
	}

	public AnomalyScannerDataClass AnomalyScannerData
	{
		[CompilerGenerated]
		get
		{
			return anomalyScannerDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			anomalyScannerDataClass_0 = value;
		}
	}

	public PerformanceDataClass PerformanceData
	{
		[CompilerGenerated]
		get
		{
			return performanceDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			performanceDataClass_0 = value;
		}
	}

	public SpammerDataClass SpammerData
	{
		[CompilerGenerated]
		get
		{
			return spammerDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			spammerDataClass_0 = value;
		}
	}

	public PacketSpammerDataClass PacketSpammerData
	{
		[CompilerGenerated]
		get
		{
			return packetSpammerDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			packetSpammerDataClass_0 = value;
		}
	}

	public EventSpammerDataClass EventSpammerData
	{
		[CompilerGenerated]
		get
		{
			return eventSpammerDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			eventSpammerDataClass_0 = value;
		}
	}

	public TargetEspDataClass SpiritsOrbitRadiusX
	{
		[CompilerGenerated]
		get
		{
			return targetEspDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			targetEspDataClass_0 = value;
		}
	}

	public TargetEspDataClass SpiritsOrbitRadiusY
	{
		[CompilerGenerated]
		get
		{
			return targetEspDataClass_1;
		}
		[CompilerGenerated]
		set
		{
			targetEspDataClass_1 = value;
		}
	}

	public TargetEspDataClass SpiritsSpeed
	{
		[CompilerGenerated]
		get
		{
			return targetEspDataClass_2;
		}
		[CompilerGenerated]
		set
		{
			targetEspDataClass_2 = value;
		}
	}

	public TargetEspDataClass SpiritsSize
	{
		[CompilerGenerated]
		get
		{
			return targetEspDataClass_3;
		}
		[CompilerGenerated]
		set
		{
			targetEspDataClass_3 = value;
		}
	}

	public TargetEspDataClass SpiritsTrailLength
	{
		[CompilerGenerated]
		get
		{
			return targetEspDataClass_4;
		}
		[CompilerGenerated]
		set
		{
			targetEspDataClass_4 = value;
		}
	}

	public GrenadeHelperDataClass GrenadeHelperData
	{
		[CompilerGenerated]
		get
		{
			return grenadeHelperDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			grenadeHelperDataClass_0 = value;
		}
	}

	public CombatDataClass CombatData
	{
		[CompilerGenerated]
		get
		{
			return combatDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			combatDataClass_0 = value;
		}
	}

	public MovementDataClass MovementData
	{
		[CompilerGenerated]
		get
		{
			return movementDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			movementDataClass_0 = value;
		}
	}

	public TargetEspDataClass SpiritsSmoothFade
	{
		[CompilerGenerated]
		get
		{
			return targetEspDataClass_5;
		}
		[CompilerGenerated]
		set
		{
			targetEspDataClass_5 = value;
		}
	}

	public MiscDataClass MiscData
	{
		[CompilerGenerated]
		get
		{
			return miscDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			miscDataClass_0 = value;
		}
	}

	public FunDataClass FunData
	{
		[CompilerGenerated]
		get
		{
			return funDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			funDataClass_0 = value;
		}
	}

	public TextureDataClass TextureData
	{
		[CompilerGenerated]
		get
		{
			return textureDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			textureDataClass_0 = value;
		}
	}

	public SettingsDataClass SettingsData
	{
		[CompilerGenerated]
		get
		{
			return settingsDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			settingsDataClass_0 = value;
		}
	}

	public TargetEspDataClass TargetEspData
	{
		[CompilerGenerated]
		get
		{
			return targetEspDataClass_6;
		}
		[CompilerGenerated]
		set
		{
			targetEspDataClass_6 = value;
		}
	}

	public NotificationsDataClass NotificationsData
	{
		[CompilerGenerated]
		get
		{
			return notificationsDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			notificationsDataClass_0 = value;
		}
	}

	public NotificationSettingsDataClass NotificationSettingsData
	{
		[CompilerGenerated]
		get
		{
			return notificationSettingsDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			notificationSettingsDataClass_0 = value;
		}
	}

	public NoSavedConfigDataClass NoSavedConfigData
	{
		[CompilerGenerated]
		get
		{
			return noSavedConfigDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			noSavedConfigDataClass_0 = value;
		}
	}

	public TracersDataClass TracersData
	{
		[CompilerGenerated]
		get
		{
			return tracersDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			tracersDataClass_0 = value;
		}
	}

	public ChamsDataClass ChamsData
	{
		[CompilerGenerated]
		get
		{
			return chamsDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			chamsDataClass_0 = value;
		}
	}

	public MinecraftVisualsDataClass MinecraftVisualsData
	{
		[CompilerGenerated]
		get
		{
			return minecraftVisualsDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			minecraftVisualsDataClass_0 = value;
		}
	}

	public LightSmoothDataClass LightSmoothData
	{
		[CompilerGenerated]
		get
		{
			return lightSmoothDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			lightSmoothDataClass_0 = value;
		}
	}

	public WorldParticlesDataClass WorldParticlesData
	{
		[CompilerGenerated]
		get
		{
			return worldParticlesDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			worldParticlesDataClass_0 = value;
		}
	}

	public TrailsDataClass TrailsData
	{
		[CompilerGenerated]
		get
		{
			return trailsDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			trailsDataClass_0 = value;
		}
	}

	public PlayerGlowDataClass PlayerGlowData
	{
		[CompilerGenerated]
		get
		{
			return playerGlowDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			playerGlowDataClass_0 = value;
		}
	}

	public HitParticlesDataClass HitParticlesData
	{
		[CompilerGenerated]
		get
		{
			return hitParticlesDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			hitParticlesDataClass_0 = value;
		}
	}

	public CloakedPlayerDetectorDataClass CloakedPlayerDetectorData
	{
		[CompilerGenerated]
		get
		{
			return cloakedPlayerDetectorDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			cloakedPlayerDetectorDataClass_0 = value;
		}
	}

	public AutoCuffDataClass AutoCuffData
	{
		[CompilerGenerated]
		get
		{
			return autoCuffDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			autoCuffDataClass_0 = value;
		}
	}

	public AutoStopDataClass AutoStopData
	{
		[CompilerGenerated]
		get
		{
			return autoStopDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			autoStopDataClass_0 = value;
		}
	}

	public AutoHypoDataClass AutoHypoData
	{
		[CompilerGenerated]
		get
		{
			return autoHypoDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			autoHypoDataClass_0 = value;
		}
	}

	public AutoHackDoorsDataClass AutoHackDoorsData
	{
		[CompilerGenerated]
		get
		{
			return autoHackDoorsDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			autoHackDoorsDataClass_0 = value;
		}
	}

	public AutoStripDataClass AutoStripData
	{
		[CompilerGenerated]
		get
		{
			return autoStripDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			autoStripDataClass_0 = value;
		}
	}

	public AutoPathDataClass AutoPathData
	{
		[CompilerGenerated]
		get
		{
			return autoPathDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			autoPathDataClass_0 = value;
		}
	}

	public TurretEspDataClass TurretEspData
	{
		[CompilerGenerated]
		get
		{
			return turretEspDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			turretEspDataClass_0 = value;
		}
	}

	public TrapEspDataClass TrapEspData
	{
		[CompilerGenerated]
		get
		{
			return trapEspDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			trapEspDataClass_0 = value;
		}
	}

	public SmartTargetSelectionDataClass SmartTargetSelectionData
	{
		[CompilerGenerated]
		get
		{
			return smartTargetSelectionDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			smartTargetSelectionDataClass_0 = value;
		}
	}

	public TargetLockDataClass TargetLockData
	{
		[CompilerGenerated]
		get
		{
			return targetLockDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			targetLockDataClass_0 = value;
		}
	}

	public AutoShootDataClass AutoShootData
	{
		[CompilerGenerated]
		get
		{
			return autoShootDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			autoShootDataClass_0 = value;
		}
	}

	public TargetFiltersDataClass TargetFiltersData
	{
		[CompilerGenerated]
		get
		{
			return targetFiltersDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			targetFiltersDataClass_0 = value;
		}
	}

	public AmbientLightDataClass AmbientLightData
	{
		[CompilerGenerated]
		get
		{
			return ambientLightDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			ambientLightDataClass_0 = value;
		}
	}

	public LightEnhancementDataClass LightEnhancementData
	{
		[CompilerGenerated]
		get
		{
			return lightEnhancementDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			lightEnhancementDataClass_0 = value;
		}
	}

	public HardwareUnlockerDataClass HardwareUnlockerData
	{
		[CompilerGenerated]
		get
		{
			return hardwareUnlockerDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			hardwareUnlockerDataClass_0 = value;
		}
	}

	public NoTrashDataClass NoTrashData
	{
		[CompilerGenerated]
		get
		{
			return noTrashDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			noTrashDataClass_0 = value;
		}
	}

	public FoamFadingDataClass FoamFadingData
	{
		[CompilerGenerated]
		get
		{
			return foamFadingDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			foamFadingDataClass_0 = value;
		}
	}

	public InsulationCheckerDataClass InsulationCheckerData
	{
		[CompilerGenerated]
		get
		{
			return insulationCheckerDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			insulationCheckerDataClass_0 = value;
		}
	}

	public FreeCamDataClass FreeCamData
	{
		[CompilerGenerated]
		get
		{
			return freeCamDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			freeCamDataClass_0 = value;
		}
	}

	public HitboxVisualizerDataClass HitboxVisualizerData
	{
		[CompilerGenerated]
		get
		{
			return hitboxVisualizerDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			hitboxVisualizerDataClass_0 = value;
		}
	}

	public SolutionScannerDataClass SolutionScannerData
	{
		[CompilerGenerated]
		get
		{
			return solutionScannerDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			solutionScannerDataClass_0 = value;
		}
	}

	public NoInteractDataClass NoInteractData
	{
		[CompilerGenerated]
		get
		{
			return noInteractDataClass_0;
		}
		[CompilerGenerated]
		set
		{
			noInteractDataClass_0 = value;
		}
	}

	[ConfigIdAttribute("autochem_mode")]
	public string AutoChemMode
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public List<string> FriendsList
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
		[CompilerGenerated]
		set
		{
			list_0 = value;
		}
	}

	public List<string> PriorityList
	{
		[CompilerGenerated]
		get
		{
			return list_1;
		}
		[CompilerGenerated]
		set
		{
			list_1 = value;
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

	private float Single_0
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	private string method_7(double double_1, byte byte_0)
	{
		return "Хитролох_иди_нахуй._______4__7___8_________";
	}
}
