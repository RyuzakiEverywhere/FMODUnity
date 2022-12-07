using System;
using System.Runtime.InteropServices;

namespace FMOD
{
	// Token: 0x02000048 RID: 72
	public struct SoundGroup
	{
		// Token: 0x060002F7 RID: 759 RVA: 0x0000409D File Offset: 0x0000229D
		public RESULT release()
		{
			return SoundGroup.FMOD5_SoundGroup_Release(this.handle);
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x000040AA File Offset: 0x000022AA
		public RESULT getSystemObject(out System system)
		{
			return SoundGroup.FMOD5_SoundGroup_GetSystemObject(this.handle, out system.handle);
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x000040BD File Offset: 0x000022BD
		public RESULT setMaxAudible(int maxaudible)
		{
			return SoundGroup.FMOD5_SoundGroup_SetMaxAudible(this.handle, maxaudible);
		}

		// Token: 0x060002FA RID: 762 RVA: 0x000040CB File Offset: 0x000022CB
		public RESULT getMaxAudible(out int maxaudible)
		{
			return SoundGroup.FMOD5_SoundGroup_GetMaxAudible(this.handle, out maxaudible);
		}

		// Token: 0x060002FB RID: 763 RVA: 0x000040D9 File Offset: 0x000022D9
		public RESULT setMaxAudibleBehavior(SOUNDGROUP_BEHAVIOR behavior)
		{
			return SoundGroup.FMOD5_SoundGroup_SetMaxAudibleBehavior(this.handle, behavior);
		}

		// Token: 0x060002FC RID: 764 RVA: 0x000040E7 File Offset: 0x000022E7
		public RESULT getMaxAudibleBehavior(out SOUNDGROUP_BEHAVIOR behavior)
		{
			return SoundGroup.FMOD5_SoundGroup_GetMaxAudibleBehavior(this.handle, out behavior);
		}

		// Token: 0x060002FD RID: 765 RVA: 0x000040F5 File Offset: 0x000022F5
		public RESULT setMuteFadeSpeed(float speed)
		{
			return SoundGroup.FMOD5_SoundGroup_SetMuteFadeSpeed(this.handle, speed);
		}

		// Token: 0x060002FE RID: 766 RVA: 0x00004103 File Offset: 0x00002303
		public RESULT getMuteFadeSpeed(out float speed)
		{
			return SoundGroup.FMOD5_SoundGroup_GetMuteFadeSpeed(this.handle, out speed);
		}

		// Token: 0x060002FF RID: 767 RVA: 0x00004111 File Offset: 0x00002311
		public RESULT setVolume(float volume)
		{
			return SoundGroup.FMOD5_SoundGroup_SetVolume(this.handle, volume);
		}

		// Token: 0x06000300 RID: 768 RVA: 0x0000411F File Offset: 0x0000231F
		public RESULT getVolume(out float volume)
		{
			return SoundGroup.FMOD5_SoundGroup_GetVolume(this.handle, out volume);
		}

		// Token: 0x06000301 RID: 769 RVA: 0x0000412D File Offset: 0x0000232D
		public RESULT stop()
		{
			return SoundGroup.FMOD5_SoundGroup_Stop(this.handle);
		}

		// Token: 0x06000302 RID: 770 RVA: 0x0000413C File Offset: 0x0000233C
		public RESULT getName(out string name, int namelen)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(namelen);
			RESULT result = SoundGroup.FMOD5_SoundGroup_GetName(this.handle, intPtr, namelen);
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				name = freeHelper.stringFromNative(intPtr);
			}
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		// Token: 0x06000303 RID: 771 RVA: 0x00004190 File Offset: 0x00002390
		public RESULT getNumSounds(out int numsounds)
		{
			return SoundGroup.FMOD5_SoundGroup_GetNumSounds(this.handle, out numsounds);
		}

		// Token: 0x06000304 RID: 772 RVA: 0x0000419E File Offset: 0x0000239E
		public RESULT getSound(int index, out Sound sound)
		{
			return SoundGroup.FMOD5_SoundGroup_GetSound(this.handle, index, out sound.handle);
		}

		// Token: 0x06000305 RID: 773 RVA: 0x000041B2 File Offset: 0x000023B2
		public RESULT getNumPlaying(out int numplaying)
		{
			return SoundGroup.FMOD5_SoundGroup_GetNumPlaying(this.handle, out numplaying);
		}

		// Token: 0x06000306 RID: 774 RVA: 0x000041C0 File Offset: 0x000023C0
		public RESULT setUserData(IntPtr userdata)
		{
			return SoundGroup.FMOD5_SoundGroup_SetUserData(this.handle, userdata);
		}

		// Token: 0x06000307 RID: 775 RVA: 0x000041CE File Offset: 0x000023CE
		public RESULT getUserData(out IntPtr userdata)
		{
			return SoundGroup.FMOD5_SoundGroup_GetUserData(this.handle, out userdata);
		}

		// Token: 0x06000308 RID: 776
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_SoundGroup_Release(IntPtr soundgroup);

		// Token: 0x06000309 RID: 777
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_SoundGroup_GetSystemObject(IntPtr soundgroup, out IntPtr system);

		// Token: 0x0600030A RID: 778
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_SoundGroup_SetMaxAudible(IntPtr soundgroup, int maxaudible);

		// Token: 0x0600030B RID: 779
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_SoundGroup_GetMaxAudible(IntPtr soundgroup, out int maxaudible);

		// Token: 0x0600030C RID: 780
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_SoundGroup_SetMaxAudibleBehavior(IntPtr soundgroup, SOUNDGROUP_BEHAVIOR behavior);

		// Token: 0x0600030D RID: 781
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_SoundGroup_GetMaxAudibleBehavior(IntPtr soundgroup, out SOUNDGROUP_BEHAVIOR behavior);

		// Token: 0x0600030E RID: 782
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_SoundGroup_SetMuteFadeSpeed(IntPtr soundgroup, float speed);

		// Token: 0x0600030F RID: 783
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_SoundGroup_GetMuteFadeSpeed(IntPtr soundgroup, out float speed);

		// Token: 0x06000310 RID: 784
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_SoundGroup_SetVolume(IntPtr soundgroup, float volume);

		// Token: 0x06000311 RID: 785
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_SoundGroup_GetVolume(IntPtr soundgroup, out float volume);

		// Token: 0x06000312 RID: 786
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_SoundGroup_Stop(IntPtr soundgroup);

		// Token: 0x06000313 RID: 787
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_SoundGroup_GetName(IntPtr soundgroup, IntPtr name, int namelen);

		// Token: 0x06000314 RID: 788
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_SoundGroup_GetNumSounds(IntPtr soundgroup, out int numsounds);

		// Token: 0x06000315 RID: 789
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_SoundGroup_GetSound(IntPtr soundgroup, int index, out IntPtr sound);

		// Token: 0x06000316 RID: 790
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_SoundGroup_GetNumPlaying(IntPtr soundgroup, out int numplaying);

		// Token: 0x06000317 RID: 791
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_SoundGroup_SetUserData(IntPtr soundgroup, IntPtr userdata);

		// Token: 0x06000318 RID: 792
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_SoundGroup_GetUserData(IntPtr soundgroup, out IntPtr userdata);

		// Token: 0x06000319 RID: 793 RVA: 0x000041DC File Offset: 0x000023DC
		public SoundGroup(IntPtr ptr)
		{
			this.handle = ptr;
		}

		// Token: 0x0600031A RID: 794 RVA: 0x000041E5 File Offset: 0x000023E5
		public bool hasHandle()
		{
			return this.handle != IntPtr.Zero;
		}

		// Token: 0x0600031B RID: 795 RVA: 0x000041F7 File Offset: 0x000023F7
		public void clearHandle()
		{
			this.handle = IntPtr.Zero;
		}

		// Token: 0x04000242 RID: 578
		public IntPtr handle;
	}
}
