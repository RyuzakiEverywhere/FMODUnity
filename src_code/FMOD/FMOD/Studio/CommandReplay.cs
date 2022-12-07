using System;
using System.Runtime.InteropServices;

namespace FMOD.Studio
{
	// Token: 0x020000EA RID: 234
	public struct CommandReplay
	{
		// Token: 0x060005DB RID: 1499 RVA: 0x000063D8 File Offset: 0x000045D8
		public RESULT getSystem(out System system)
		{
			return CommandReplay.FMOD_Studio_CommandReplay_GetSystem(this.handle, out system.handle);
		}

		// Token: 0x060005DC RID: 1500 RVA: 0x000063EB File Offset: 0x000045EB
		public RESULT getLength(out float length)
		{
			return CommandReplay.FMOD_Studio_CommandReplay_GetLength(this.handle, out length);
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x000063F9 File Offset: 0x000045F9
		public RESULT getCommandCount(out int count)
		{
			return CommandReplay.FMOD_Studio_CommandReplay_GetCommandCount(this.handle, out count);
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x00006407 File Offset: 0x00004607
		public RESULT getCommandInfo(int commandIndex, out COMMAND_INFO info)
		{
			return CommandReplay.FMOD_Studio_CommandReplay_GetCommandInfo(this.handle, commandIndex, out info);
		}

		// Token: 0x060005DF RID: 1503 RVA: 0x00006418 File Offset: 0x00004618
		public RESULT getCommandString(int commandIndex, out string buffer)
		{
			buffer = null;
			RESULT result2;
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				int num = 256;
				IntPtr intPtr = Marshal.AllocHGlobal(256);
				RESULT result;
				for (result = CommandReplay.FMOD_Studio_CommandReplay_GetCommandString(this.handle, commandIndex, intPtr, num); result == RESULT.ERR_TRUNCATED; result = CommandReplay.FMOD_Studio_CommandReplay_GetCommandString(this.handle, commandIndex, intPtr, num))
				{
					Marshal.FreeHGlobal(intPtr);
					num *= 2;
					intPtr = Marshal.AllocHGlobal(num);
				}
				if (result == RESULT.OK)
				{
					buffer = freeHelper.stringFromNative(intPtr);
				}
				Marshal.FreeHGlobal(intPtr);
				result2 = result;
			}
			return result2;
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x000064A8 File Offset: 0x000046A8
		public RESULT getCommandAtTime(float time, out int commandIndex)
		{
			return CommandReplay.FMOD_Studio_CommandReplay_GetCommandAtTime(this.handle, time, out commandIndex);
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x000064B8 File Offset: 0x000046B8
		public RESULT setBankPath(string bankPath)
		{
			RESULT result;
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				result = CommandReplay.FMOD_Studio_CommandReplay_SetBankPath(this.handle, freeHelper.byteFromStringUTF8(bankPath));
			}
			return result;
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x000064FC File Offset: 0x000046FC
		public RESULT start()
		{
			return CommandReplay.FMOD_Studio_CommandReplay_Start(this.handle);
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x00006509 File Offset: 0x00004709
		public RESULT stop()
		{
			return CommandReplay.FMOD_Studio_CommandReplay_Stop(this.handle);
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x00006516 File Offset: 0x00004716
		public RESULT seekToTime(float time)
		{
			return CommandReplay.FMOD_Studio_CommandReplay_SeekToTime(this.handle, time);
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x00006524 File Offset: 0x00004724
		public RESULT seekToCommand(int commandIndex)
		{
			return CommandReplay.FMOD_Studio_CommandReplay_SeekToCommand(this.handle, commandIndex);
		}

		// Token: 0x060005E6 RID: 1510 RVA: 0x00006532 File Offset: 0x00004732
		public RESULT getPaused(out bool paused)
		{
			return CommandReplay.FMOD_Studio_CommandReplay_GetPaused(this.handle, out paused);
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x00006540 File Offset: 0x00004740
		public RESULT setPaused(bool paused)
		{
			return CommandReplay.FMOD_Studio_CommandReplay_SetPaused(this.handle, paused);
		}

		// Token: 0x060005E8 RID: 1512 RVA: 0x0000654E File Offset: 0x0000474E
		public RESULT getPlaybackState(out PLAYBACK_STATE state)
		{
			return CommandReplay.FMOD_Studio_CommandReplay_GetPlaybackState(this.handle, out state);
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x0000655C File Offset: 0x0000475C
		public RESULT getCurrentCommand(out int commandIndex, out float currentTime)
		{
			return CommandReplay.FMOD_Studio_CommandReplay_GetCurrentCommand(this.handle, out commandIndex, out currentTime);
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x0000656B File Offset: 0x0000476B
		public RESULT release()
		{
			return CommandReplay.FMOD_Studio_CommandReplay_Release(this.handle);
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x00006578 File Offset: 0x00004778
		public RESULT setFrameCallback(COMMANDREPLAY_FRAME_CALLBACK callback)
		{
			return CommandReplay.FMOD_Studio_CommandReplay_SetFrameCallback(this.handle, callback);
		}

		// Token: 0x060005EC RID: 1516 RVA: 0x00006586 File Offset: 0x00004786
		public RESULT setLoadBankCallback(COMMANDREPLAY_LOAD_BANK_CALLBACK callback)
		{
			return CommandReplay.FMOD_Studio_CommandReplay_SetLoadBankCallback(this.handle, callback);
		}

		// Token: 0x060005ED RID: 1517 RVA: 0x00006594 File Offset: 0x00004794
		public RESULT setCreateInstanceCallback(COMMANDREPLAY_CREATE_INSTANCE_CALLBACK callback)
		{
			return CommandReplay.FMOD_Studio_CommandReplay_SetCreateInstanceCallback(this.handle, callback);
		}

		// Token: 0x060005EE RID: 1518 RVA: 0x000065A2 File Offset: 0x000047A2
		public RESULT getUserData(out IntPtr userdata)
		{
			return CommandReplay.FMOD_Studio_CommandReplay_GetUserData(this.handle, out userdata);
		}

		// Token: 0x060005EF RID: 1519 RVA: 0x000065B0 File Offset: 0x000047B0
		public RESULT setUserData(IntPtr userdata)
		{
			return CommandReplay.FMOD_Studio_CommandReplay_SetUserData(this.handle, userdata);
		}

		// Token: 0x060005F0 RID: 1520
		[DllImport("fmodstudio")]
		private static extern bool FMOD_Studio_CommandReplay_IsValid(IntPtr replay);

		// Token: 0x060005F1 RID: 1521
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_CommandReplay_GetSystem(IntPtr replay, out IntPtr system);

		// Token: 0x060005F2 RID: 1522
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_CommandReplay_GetLength(IntPtr replay, out float length);

		// Token: 0x060005F3 RID: 1523
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_CommandReplay_GetCommandCount(IntPtr replay, out int count);

		// Token: 0x060005F4 RID: 1524
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_CommandReplay_GetCommandInfo(IntPtr replay, int commandindex, out COMMAND_INFO info);

		// Token: 0x060005F5 RID: 1525
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_CommandReplay_GetCommandString(IntPtr replay, int commandIndex, IntPtr buffer, int length);

		// Token: 0x060005F6 RID: 1526
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_CommandReplay_GetCommandAtTime(IntPtr replay, float time, out int commandIndex);

		// Token: 0x060005F7 RID: 1527
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_CommandReplay_SetBankPath(IntPtr replay, byte[] bankPath);

		// Token: 0x060005F8 RID: 1528
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_CommandReplay_Start(IntPtr replay);

		// Token: 0x060005F9 RID: 1529
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_CommandReplay_Stop(IntPtr replay);

		// Token: 0x060005FA RID: 1530
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_CommandReplay_SeekToTime(IntPtr replay, float time);

		// Token: 0x060005FB RID: 1531
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_CommandReplay_SeekToCommand(IntPtr replay, int commandIndex);

		// Token: 0x060005FC RID: 1532
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_CommandReplay_GetPaused(IntPtr replay, out bool paused);

		// Token: 0x060005FD RID: 1533
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_CommandReplay_SetPaused(IntPtr replay, bool paused);

		// Token: 0x060005FE RID: 1534
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_CommandReplay_GetPlaybackState(IntPtr replay, out PLAYBACK_STATE state);

		// Token: 0x060005FF RID: 1535
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_CommandReplay_GetCurrentCommand(IntPtr replay, out int commandIndex, out float currentTime);

		// Token: 0x06000600 RID: 1536
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_CommandReplay_Release(IntPtr replay);

		// Token: 0x06000601 RID: 1537
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_CommandReplay_SetFrameCallback(IntPtr replay, COMMANDREPLAY_FRAME_CALLBACK callback);

		// Token: 0x06000602 RID: 1538
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_CommandReplay_SetLoadBankCallback(IntPtr replay, COMMANDREPLAY_LOAD_BANK_CALLBACK callback);

		// Token: 0x06000603 RID: 1539
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_CommandReplay_SetCreateInstanceCallback(IntPtr replay, COMMANDREPLAY_CREATE_INSTANCE_CALLBACK callback);

		// Token: 0x06000604 RID: 1540
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_CommandReplay_GetUserData(IntPtr replay, out IntPtr userdata);

		// Token: 0x06000605 RID: 1541
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_CommandReplay_SetUserData(IntPtr replay, IntPtr userdata);

		// Token: 0x06000606 RID: 1542 RVA: 0x000065BE File Offset: 0x000047BE
		public CommandReplay(IntPtr ptr)
		{
			this.handle = ptr;
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x000065C7 File Offset: 0x000047C7
		public bool hasHandle()
		{
			return this.handle != IntPtr.Zero;
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x000065D9 File Offset: 0x000047D9
		public void clearHandle()
		{
			this.handle = IntPtr.Zero;
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x000065E6 File Offset: 0x000047E6
		public bool isValid()
		{
			return this.hasHandle() && CommandReplay.FMOD_Studio_CommandReplay_IsValid(this.handle);
		}

		// Token: 0x040004FB RID: 1275
		public IntPtr handle;
	}
}
