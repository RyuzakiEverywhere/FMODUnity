using System;
using System.Runtime.InteropServices;

namespace FMOD.Studio
{
	// Token: 0x020000E8 RID: 232
	public struct VCA
	{
		// Token: 0x060005A6 RID: 1446 RVA: 0x00005F42 File Offset: 0x00004142
		public RESULT getID(out Guid id)
		{
			return VCA.FMOD_Studio_VCA_GetID(this.handle, out id);
		}

		// Token: 0x060005A7 RID: 1447 RVA: 0x00005F50 File Offset: 0x00004150
		public RESULT getPath(out string path)
		{
			path = null;
			RESULT result2;
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				IntPtr intPtr = Marshal.AllocHGlobal(256);
				int num = 0;
				RESULT result = VCA.FMOD_Studio_VCA_GetPath(this.handle, intPtr, 256, out num);
				if (result == RESULT.ERR_TRUNCATED)
				{
					Marshal.FreeHGlobal(intPtr);
					intPtr = Marshal.AllocHGlobal(num);
					result = VCA.FMOD_Studio_VCA_GetPath(this.handle, intPtr, num, out num);
				}
				if (result == RESULT.OK)
				{
					path = freeHelper.stringFromNative(intPtr);
				}
				Marshal.FreeHGlobal(intPtr);
				result2 = result;
			}
			return result2;
		}

		// Token: 0x060005A8 RID: 1448 RVA: 0x00005FDC File Offset: 0x000041DC
		public RESULT getVolume(out float volume)
		{
			float num;
			return this.getVolume(out volume, out num);
		}

		// Token: 0x060005A9 RID: 1449 RVA: 0x00005FF2 File Offset: 0x000041F2
		public RESULT getVolume(out float volume, out float finalvolume)
		{
			return VCA.FMOD_Studio_VCA_GetVolume(this.handle, out volume, out finalvolume);
		}

		// Token: 0x060005AA RID: 1450 RVA: 0x00006001 File Offset: 0x00004201
		public RESULT setVolume(float volume)
		{
			return VCA.FMOD_Studio_VCA_SetVolume(this.handle, volume);
		}

		// Token: 0x060005AB RID: 1451
		[DllImport("fmodstudio")]
		private static extern bool FMOD_Studio_VCA_IsValid(IntPtr vca);

		// Token: 0x060005AC RID: 1452
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_VCA_GetID(IntPtr vca, out Guid id);

		// Token: 0x060005AD RID: 1453
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_VCA_GetPath(IntPtr vca, IntPtr path, int size, out int retrieved);

		// Token: 0x060005AE RID: 1454
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_VCA_GetVolume(IntPtr vca, out float volume, out float finalvolume);

		// Token: 0x060005AF RID: 1455
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_VCA_SetVolume(IntPtr vca, float volume);

		// Token: 0x060005B0 RID: 1456 RVA: 0x0000600F File Offset: 0x0000420F
		public VCA(IntPtr ptr)
		{
			this.handle = ptr;
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x00006018 File Offset: 0x00004218
		public bool hasHandle()
		{
			return this.handle != IntPtr.Zero;
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x0000602A File Offset: 0x0000422A
		public void clearHandle()
		{
			this.handle = IntPtr.Zero;
		}

		// Token: 0x060005B3 RID: 1459 RVA: 0x00006037 File Offset: 0x00004237
		public bool isValid()
		{
			return this.hasHandle() && VCA.FMOD_Studio_VCA_IsValid(this.handle);
		}

		// Token: 0x040004F9 RID: 1273
		public IntPtr handle;
	}
}
