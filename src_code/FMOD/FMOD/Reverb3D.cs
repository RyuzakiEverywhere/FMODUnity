using System;
using System.Runtime.InteropServices;

namespace FMOD
{
	// Token: 0x0200004C RID: 76
	public struct Reverb3D
	{
		// Token: 0x060003B6 RID: 950 RVA: 0x000047A5 File Offset: 0x000029A5
		public RESULT release()
		{
			return Reverb3D.FMOD5_Reverb3D_Release(this.handle);
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x000047B2 File Offset: 0x000029B2
		public RESULT set3DAttributes(ref VECTOR position, float mindistance, float maxdistance)
		{
			return Reverb3D.FMOD5_Reverb3D_Set3DAttributes(this.handle, ref position, mindistance, maxdistance);
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x000047C2 File Offset: 0x000029C2
		public RESULT get3DAttributes(ref VECTOR position, ref float mindistance, ref float maxdistance)
		{
			return Reverb3D.FMOD5_Reverb3D_Get3DAttributes(this.handle, ref position, ref mindistance, ref maxdistance);
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x000047D2 File Offset: 0x000029D2
		public RESULT setProperties(ref REVERB_PROPERTIES properties)
		{
			return Reverb3D.FMOD5_Reverb3D_SetProperties(this.handle, ref properties);
		}

		// Token: 0x060003BA RID: 954 RVA: 0x000047E0 File Offset: 0x000029E0
		public RESULT getProperties(ref REVERB_PROPERTIES properties)
		{
			return Reverb3D.FMOD5_Reverb3D_GetProperties(this.handle, ref properties);
		}

		// Token: 0x060003BB RID: 955 RVA: 0x000047EE File Offset: 0x000029EE
		public RESULT setActive(bool active)
		{
			return Reverb3D.FMOD5_Reverb3D_SetActive(this.handle, active);
		}

		// Token: 0x060003BC RID: 956 RVA: 0x000047FC File Offset: 0x000029FC
		public RESULT getActive(out bool active)
		{
			return Reverb3D.FMOD5_Reverb3D_GetActive(this.handle, out active);
		}

		// Token: 0x060003BD RID: 957 RVA: 0x0000480A File Offset: 0x00002A0A
		public RESULT setUserData(IntPtr userdata)
		{
			return Reverb3D.FMOD5_Reverb3D_SetUserData(this.handle, userdata);
		}

		// Token: 0x060003BE RID: 958 RVA: 0x00004818 File Offset: 0x00002A18
		public RESULT getUserData(out IntPtr userdata)
		{
			return Reverb3D.FMOD5_Reverb3D_GetUserData(this.handle, out userdata);
		}

		// Token: 0x060003BF RID: 959
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Reverb3D_Release(IntPtr reverb3d);

		// Token: 0x060003C0 RID: 960
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Reverb3D_Set3DAttributes(IntPtr reverb3d, ref VECTOR position, float mindistance, float maxdistance);

		// Token: 0x060003C1 RID: 961
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Reverb3D_Get3DAttributes(IntPtr reverb3d, ref VECTOR position, ref float mindistance, ref float maxdistance);

		// Token: 0x060003C2 RID: 962
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Reverb3D_SetProperties(IntPtr reverb3d, ref REVERB_PROPERTIES properties);

		// Token: 0x060003C3 RID: 963
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Reverb3D_GetProperties(IntPtr reverb3d, ref REVERB_PROPERTIES properties);

		// Token: 0x060003C4 RID: 964
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Reverb3D_SetActive(IntPtr reverb3d, bool active);

		// Token: 0x060003C5 RID: 965
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Reverb3D_GetActive(IntPtr reverb3d, out bool active);

		// Token: 0x060003C6 RID: 966
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Reverb3D_SetUserData(IntPtr reverb3d, IntPtr userdata);

		// Token: 0x060003C7 RID: 967
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Reverb3D_GetUserData(IntPtr reverb3d, out IntPtr userdata);

		// Token: 0x060003C8 RID: 968 RVA: 0x00004826 File Offset: 0x00002A26
		public Reverb3D(IntPtr ptr)
		{
			this.handle = ptr;
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x0000482F File Offset: 0x00002A2F
		public bool hasHandle()
		{
			return this.handle != IntPtr.Zero;
		}

		// Token: 0x060003CA RID: 970 RVA: 0x00004841 File Offset: 0x00002A41
		public void clearHandle()
		{
			this.handle = IntPtr.Zero;
		}

		// Token: 0x04000246 RID: 582
		public IntPtr handle;
	}
}
