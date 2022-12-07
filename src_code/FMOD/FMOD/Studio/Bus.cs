using System;
using System.Runtime.InteropServices;

namespace FMOD.Studio
{
	// Token: 0x020000E7 RID: 231
	public struct Bus
	{
		// Token: 0x06000584 RID: 1412 RVA: 0x00005DA6 File Offset: 0x00003FA6
		public RESULT getID(out Guid id)
		{
			return Bus.FMOD_Studio_Bus_GetID(this.handle, out id);
		}

		// Token: 0x06000585 RID: 1413 RVA: 0x00005DB4 File Offset: 0x00003FB4
		public RESULT getPath(out string path)
		{
			path = null;
			RESULT result2;
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				IntPtr intPtr = Marshal.AllocHGlobal(256);
				int num = 0;
				RESULT result = Bus.FMOD_Studio_Bus_GetPath(this.handle, intPtr, 256, out num);
				if (result == RESULT.ERR_TRUNCATED)
				{
					Marshal.FreeHGlobal(intPtr);
					intPtr = Marshal.AllocHGlobal(num);
					result = Bus.FMOD_Studio_Bus_GetPath(this.handle, intPtr, num, out num);
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

		// Token: 0x06000586 RID: 1414 RVA: 0x00005E40 File Offset: 0x00004040
		public RESULT getVolume(out float volume)
		{
			float num;
			return this.getVolume(out volume, out num);
		}

		// Token: 0x06000587 RID: 1415 RVA: 0x00005E56 File Offset: 0x00004056
		public RESULT getVolume(out float volume, out float finalvolume)
		{
			return Bus.FMOD_Studio_Bus_GetVolume(this.handle, out volume, out finalvolume);
		}

		// Token: 0x06000588 RID: 1416 RVA: 0x00005E65 File Offset: 0x00004065
		public RESULT setVolume(float volume)
		{
			return Bus.FMOD_Studio_Bus_SetVolume(this.handle, volume);
		}

		// Token: 0x06000589 RID: 1417 RVA: 0x00005E73 File Offset: 0x00004073
		public RESULT getPaused(out bool paused)
		{
			return Bus.FMOD_Studio_Bus_GetPaused(this.handle, out paused);
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x00005E81 File Offset: 0x00004081
		public RESULT setPaused(bool paused)
		{
			return Bus.FMOD_Studio_Bus_SetPaused(this.handle, paused);
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x00005E8F File Offset: 0x0000408F
		public RESULT getMute(out bool mute)
		{
			return Bus.FMOD_Studio_Bus_GetMute(this.handle, out mute);
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x00005E9D File Offset: 0x0000409D
		public RESULT setMute(bool mute)
		{
			return Bus.FMOD_Studio_Bus_SetMute(this.handle, mute);
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x00005EAB File Offset: 0x000040AB
		public RESULT stopAllEvents(STOP_MODE mode)
		{
			return Bus.FMOD_Studio_Bus_StopAllEvents(this.handle, mode);
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x00005EB9 File Offset: 0x000040B9
		public RESULT lockChannelGroup()
		{
			return Bus.FMOD_Studio_Bus_LockChannelGroup(this.handle);
		}

		// Token: 0x0600058F RID: 1423 RVA: 0x00005EC6 File Offset: 0x000040C6
		public RESULT unlockChannelGroup()
		{
			return Bus.FMOD_Studio_Bus_UnlockChannelGroup(this.handle);
		}

		// Token: 0x06000590 RID: 1424 RVA: 0x00005ED3 File Offset: 0x000040D3
		public RESULT getChannelGroup(out ChannelGroup group)
		{
			return Bus.FMOD_Studio_Bus_GetChannelGroup(this.handle, out group.handle);
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x00005EE6 File Offset: 0x000040E6
		public RESULT getCPUUsage(out uint exclusive, out uint inclusive)
		{
			return Bus.FMOD_Studio_Bus_GetCPUUsage(this.handle, out exclusive, out inclusive);
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x00005EF5 File Offset: 0x000040F5
		public RESULT getMemoryUsage(out MEMORY_USAGE memoryusage)
		{
			return Bus.FMOD_Studio_Bus_GetMemoryUsage(this.handle, out memoryusage);
		}

		// Token: 0x06000593 RID: 1427
		[DllImport("fmodstudio")]
		private static extern bool FMOD_Studio_Bus_IsValid(IntPtr bus);

		// Token: 0x06000594 RID: 1428
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_Bus_GetID(IntPtr bus, out Guid id);

		// Token: 0x06000595 RID: 1429
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_Bus_GetPath(IntPtr bus, IntPtr path, int size, out int retrieved);

		// Token: 0x06000596 RID: 1430
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_Bus_GetVolume(IntPtr bus, out float volume, out float finalvolume);

		// Token: 0x06000597 RID: 1431
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_Bus_SetVolume(IntPtr bus, float volume);

		// Token: 0x06000598 RID: 1432
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_Bus_GetPaused(IntPtr bus, out bool paused);

		// Token: 0x06000599 RID: 1433
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_Bus_SetPaused(IntPtr bus, bool paused);

		// Token: 0x0600059A RID: 1434
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_Bus_GetMute(IntPtr bus, out bool mute);

		// Token: 0x0600059B RID: 1435
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_Bus_SetMute(IntPtr bus, bool mute);

		// Token: 0x0600059C RID: 1436
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_Bus_StopAllEvents(IntPtr bus, STOP_MODE mode);

		// Token: 0x0600059D RID: 1437
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_Bus_LockChannelGroup(IntPtr bus);

		// Token: 0x0600059E RID: 1438
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_Bus_UnlockChannelGroup(IntPtr bus);

		// Token: 0x0600059F RID: 1439
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_Bus_GetChannelGroup(IntPtr bus, out IntPtr group);

		// Token: 0x060005A0 RID: 1440
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_Bus_GetCPUUsage(IntPtr bus, out uint exclusive, out uint inclusive);

		// Token: 0x060005A1 RID: 1441
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_Bus_GetMemoryUsage(IntPtr bus, out MEMORY_USAGE memoryusage);

		// Token: 0x060005A2 RID: 1442 RVA: 0x00005F03 File Offset: 0x00004103
		public Bus(IntPtr ptr)
		{
			this.handle = ptr;
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x00005F0C File Offset: 0x0000410C
		public bool hasHandle()
		{
			return this.handle != IntPtr.Zero;
		}

		// Token: 0x060005A4 RID: 1444 RVA: 0x00005F1E File Offset: 0x0000411E
		public void clearHandle()
		{
			this.handle = IntPtr.Zero;
		}

		// Token: 0x060005A5 RID: 1445 RVA: 0x00005F2B File Offset: 0x0000412B
		public bool isValid()
		{
			return this.hasHandle() && Bus.FMOD_Studio_Bus_IsValid(this.handle);
		}

		// Token: 0x040004F8 RID: 1272
		public IntPtr handle;
	}
}
