using System;
using System.Runtime.InteropServices;

namespace FMOD
{
	// Token: 0x02000047 RID: 71
	public struct ChannelGroup : IChannelControl
	{
		// Token: 0x06000266 RID: 614 RVA: 0x00003BC1 File Offset: 0x00001DC1
		public RESULT release()
		{
			return ChannelGroup.FMOD5_ChannelGroup_Release(this.handle);
		}

		// Token: 0x06000267 RID: 615 RVA: 0x00003BCE File Offset: 0x00001DCE
		public RESULT addGroup(ChannelGroup group, bool propagatedspclock = true)
		{
			return ChannelGroup.FMOD5_ChannelGroup_AddGroup(this.handle, group.handle, propagatedspclock, IntPtr.Zero);
		}

		// Token: 0x06000268 RID: 616 RVA: 0x00003BE7 File Offset: 0x00001DE7
		public RESULT addGroup(ChannelGroup group, bool propagatedspclock, out DSPConnection connection)
		{
			return ChannelGroup.FMOD5_ChannelGroup_AddGroup(this.handle, group.handle, propagatedspclock, out connection.handle);
		}

		// Token: 0x06000269 RID: 617 RVA: 0x00003C01 File Offset: 0x00001E01
		public RESULT getNumGroups(out int numgroups)
		{
			return ChannelGroup.FMOD5_ChannelGroup_GetNumGroups(this.handle, out numgroups);
		}

		// Token: 0x0600026A RID: 618 RVA: 0x00003C0F File Offset: 0x00001E0F
		public RESULT getGroup(int index, out ChannelGroup group)
		{
			return ChannelGroup.FMOD5_ChannelGroup_GetGroup(this.handle, index, out group.handle);
		}

		// Token: 0x0600026B RID: 619 RVA: 0x00003C23 File Offset: 0x00001E23
		public RESULT getParentGroup(out ChannelGroup group)
		{
			return ChannelGroup.FMOD5_ChannelGroup_GetParentGroup(this.handle, out group.handle);
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00003C38 File Offset: 0x00001E38
		public RESULT getName(out string name, int namelen)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(namelen);
			RESULT result = ChannelGroup.FMOD5_ChannelGroup_GetName(this.handle, intPtr, namelen);
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				name = freeHelper.stringFromNative(intPtr);
			}
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		// Token: 0x0600026D RID: 621 RVA: 0x00003C8C File Offset: 0x00001E8C
		public RESULT getNumChannels(out int numchannels)
		{
			return ChannelGroup.FMOD5_ChannelGroup_GetNumChannels(this.handle, out numchannels);
		}

		// Token: 0x0600026E RID: 622 RVA: 0x00003C9A File Offset: 0x00001E9A
		public RESULT getChannel(int index, out Channel channel)
		{
			return ChannelGroup.FMOD5_ChannelGroup_GetChannel(this.handle, index, out channel.handle);
		}

		// Token: 0x0600026F RID: 623 RVA: 0x00003CAE File Offset: 0x00001EAE
		public RESULT getSystemObject(out System system)
		{
			return ChannelGroup.FMOD5_ChannelGroup_GetSystemObject(this.handle, out system.handle);
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00003CC1 File Offset: 0x00001EC1
		public RESULT stop()
		{
			return ChannelGroup.FMOD5_ChannelGroup_Stop(this.handle);
		}

		// Token: 0x06000271 RID: 625 RVA: 0x00003CCE File Offset: 0x00001ECE
		public RESULT setPaused(bool paused)
		{
			return ChannelGroup.FMOD5_ChannelGroup_SetPaused(this.handle, paused);
		}

		// Token: 0x06000272 RID: 626 RVA: 0x00003CDC File Offset: 0x00001EDC
		public RESULT getPaused(out bool paused)
		{
			return ChannelGroup.FMOD5_ChannelGroup_GetPaused(this.handle, out paused);
		}

		// Token: 0x06000273 RID: 627 RVA: 0x00003CEA File Offset: 0x00001EEA
		public RESULT setVolume(float volume)
		{
			return ChannelGroup.FMOD5_ChannelGroup_SetVolume(this.handle, volume);
		}

		// Token: 0x06000274 RID: 628 RVA: 0x00003CF8 File Offset: 0x00001EF8
		public RESULT getVolume(out float volume)
		{
			return ChannelGroup.FMOD5_ChannelGroup_GetVolume(this.handle, out volume);
		}

		// Token: 0x06000275 RID: 629 RVA: 0x00003D06 File Offset: 0x00001F06
		public RESULT setVolumeRamp(bool ramp)
		{
			return ChannelGroup.FMOD5_ChannelGroup_SetVolumeRamp(this.handle, ramp);
		}

		// Token: 0x06000276 RID: 630 RVA: 0x00003D14 File Offset: 0x00001F14
		public RESULT getVolumeRamp(out bool ramp)
		{
			return ChannelGroup.FMOD5_ChannelGroup_GetVolumeRamp(this.handle, out ramp);
		}

		// Token: 0x06000277 RID: 631 RVA: 0x00003D22 File Offset: 0x00001F22
		public RESULT getAudibility(out float audibility)
		{
			return ChannelGroup.FMOD5_ChannelGroup_GetAudibility(this.handle, out audibility);
		}

		// Token: 0x06000278 RID: 632 RVA: 0x00003D30 File Offset: 0x00001F30
		public RESULT setPitch(float pitch)
		{
			return ChannelGroup.FMOD5_ChannelGroup_SetPitch(this.handle, pitch);
		}

		// Token: 0x06000279 RID: 633 RVA: 0x00003D3E File Offset: 0x00001F3E
		public RESULT getPitch(out float pitch)
		{
			return ChannelGroup.FMOD5_ChannelGroup_GetPitch(this.handle, out pitch);
		}

		// Token: 0x0600027A RID: 634 RVA: 0x00003D4C File Offset: 0x00001F4C
		public RESULT setMute(bool mute)
		{
			return ChannelGroup.FMOD5_ChannelGroup_SetMute(this.handle, mute);
		}

		// Token: 0x0600027B RID: 635 RVA: 0x00003D5A File Offset: 0x00001F5A
		public RESULT getMute(out bool mute)
		{
			return ChannelGroup.FMOD5_ChannelGroup_GetMute(this.handle, out mute);
		}

		// Token: 0x0600027C RID: 636 RVA: 0x00003D68 File Offset: 0x00001F68
		public RESULT setReverbProperties(int instance, float wet)
		{
			return ChannelGroup.FMOD5_ChannelGroup_SetReverbProperties(this.handle, instance, wet);
		}

		// Token: 0x0600027D RID: 637 RVA: 0x00003D77 File Offset: 0x00001F77
		public RESULT getReverbProperties(int instance, out float wet)
		{
			return ChannelGroup.FMOD5_ChannelGroup_GetReverbProperties(this.handle, instance, out wet);
		}

		// Token: 0x0600027E RID: 638 RVA: 0x00003D86 File Offset: 0x00001F86
		public RESULT setLowPassGain(float gain)
		{
			return ChannelGroup.FMOD5_ChannelGroup_SetLowPassGain(this.handle, gain);
		}

		// Token: 0x0600027F RID: 639 RVA: 0x00003D94 File Offset: 0x00001F94
		public RESULT getLowPassGain(out float gain)
		{
			return ChannelGroup.FMOD5_ChannelGroup_GetLowPassGain(this.handle, out gain);
		}

		// Token: 0x06000280 RID: 640 RVA: 0x00003DA2 File Offset: 0x00001FA2
		public RESULT setMode(MODE mode)
		{
			return ChannelGroup.FMOD5_ChannelGroup_SetMode(this.handle, mode);
		}

		// Token: 0x06000281 RID: 641 RVA: 0x00003DB0 File Offset: 0x00001FB0
		public RESULT getMode(out MODE mode)
		{
			return ChannelGroup.FMOD5_ChannelGroup_GetMode(this.handle, out mode);
		}

		// Token: 0x06000282 RID: 642 RVA: 0x00003DBE File Offset: 0x00001FBE
		public RESULT setCallback(CHANNELCONTROL_CALLBACK callback)
		{
			return ChannelGroup.FMOD5_ChannelGroup_SetCallback(this.handle, callback);
		}

		// Token: 0x06000283 RID: 643 RVA: 0x00003DCC File Offset: 0x00001FCC
		public RESULT isPlaying(out bool isplaying)
		{
			return ChannelGroup.FMOD5_ChannelGroup_IsPlaying(this.handle, out isplaying);
		}

		// Token: 0x06000284 RID: 644 RVA: 0x00003DDA File Offset: 0x00001FDA
		public RESULT setPan(float pan)
		{
			return ChannelGroup.FMOD5_ChannelGroup_SetPan(this.handle, pan);
		}

		// Token: 0x06000285 RID: 645 RVA: 0x00003DE8 File Offset: 0x00001FE8
		public RESULT setMixLevelsOutput(float frontleft, float frontright, float center, float lfe, float surroundleft, float surroundright, float backleft, float backright)
		{
			return ChannelGroup.FMOD5_ChannelGroup_SetMixLevelsOutput(this.handle, frontleft, frontright, center, lfe, surroundleft, surroundright, backleft, backright);
		}

		// Token: 0x06000286 RID: 646 RVA: 0x00003E0D File Offset: 0x0000200D
		public RESULT setMixLevelsInput(float[] levels, int numlevels)
		{
			return ChannelGroup.FMOD5_ChannelGroup_SetMixLevelsInput(this.handle, levels, numlevels);
		}

		// Token: 0x06000287 RID: 647 RVA: 0x00003E1C File Offset: 0x0000201C
		public RESULT setMixMatrix(float[] matrix, int outchannels, int inchannels, int inchannel_hop)
		{
			return ChannelGroup.FMOD5_ChannelGroup_SetMixMatrix(this.handle, matrix, outchannels, inchannels, inchannel_hop);
		}

		// Token: 0x06000288 RID: 648 RVA: 0x00003E2E File Offset: 0x0000202E
		public RESULT getMixMatrix(float[] matrix, out int outchannels, out int inchannels, int inchannel_hop)
		{
			return ChannelGroup.FMOD5_ChannelGroup_GetMixMatrix(this.handle, matrix, out outchannels, out inchannels, inchannel_hop);
		}

		// Token: 0x06000289 RID: 649 RVA: 0x00003E40 File Offset: 0x00002040
		public RESULT getDSPClock(out ulong dspclock, out ulong parentclock)
		{
			return ChannelGroup.FMOD5_ChannelGroup_GetDSPClock(this.handle, out dspclock, out parentclock);
		}

		// Token: 0x0600028A RID: 650 RVA: 0x00003E4F File Offset: 0x0000204F
		public RESULT setDelay(ulong dspclock_start, ulong dspclock_end, bool stopchannels)
		{
			return ChannelGroup.FMOD5_ChannelGroup_SetDelay(this.handle, dspclock_start, dspclock_end, stopchannels);
		}

		// Token: 0x0600028B RID: 651 RVA: 0x00003E5F File Offset: 0x0000205F
		public RESULT getDelay(out ulong dspclock_start, out ulong dspclock_end)
		{
			return ChannelGroup.FMOD5_ChannelGroup_GetDelay(this.handle, out dspclock_start, out dspclock_end, IntPtr.Zero);
		}

		// Token: 0x0600028C RID: 652 RVA: 0x00003E73 File Offset: 0x00002073
		public RESULT getDelay(out ulong dspclock_start, out ulong dspclock_end, out bool stopchannels)
		{
			return ChannelGroup.FMOD5_ChannelGroup_GetDelay(this.handle, out dspclock_start, out dspclock_end, out stopchannels);
		}

		// Token: 0x0600028D RID: 653 RVA: 0x00003E83 File Offset: 0x00002083
		public RESULT addFadePoint(ulong dspclock, float volume)
		{
			return ChannelGroup.FMOD5_ChannelGroup_AddFadePoint(this.handle, dspclock, volume);
		}

		// Token: 0x0600028E RID: 654 RVA: 0x00003E92 File Offset: 0x00002092
		public RESULT setFadePointRamp(ulong dspclock, float volume)
		{
			return ChannelGroup.FMOD5_ChannelGroup_SetFadePointRamp(this.handle, dspclock, volume);
		}

		// Token: 0x0600028F RID: 655 RVA: 0x00003EA1 File Offset: 0x000020A1
		public RESULT removeFadePoints(ulong dspclock_start, ulong dspclock_end)
		{
			return ChannelGroup.FMOD5_ChannelGroup_RemoveFadePoints(this.handle, dspclock_start, dspclock_end);
		}

		// Token: 0x06000290 RID: 656 RVA: 0x00003EB0 File Offset: 0x000020B0
		public RESULT getFadePoints(ref uint numpoints, ulong[] point_dspclock, float[] point_volume)
		{
			return ChannelGroup.FMOD5_ChannelGroup_GetFadePoints(this.handle, ref numpoints, point_dspclock, point_volume);
		}

		// Token: 0x06000291 RID: 657 RVA: 0x00003EC0 File Offset: 0x000020C0
		public RESULT getDSP(int index, out DSP dsp)
		{
			return ChannelGroup.FMOD5_ChannelGroup_GetDSP(this.handle, index, out dsp.handle);
		}

		// Token: 0x06000292 RID: 658 RVA: 0x00003ED4 File Offset: 0x000020D4
		public RESULT addDSP(int index, DSP dsp)
		{
			return ChannelGroup.FMOD5_ChannelGroup_AddDSP(this.handle, index, dsp.handle);
		}

		// Token: 0x06000293 RID: 659 RVA: 0x00003EE8 File Offset: 0x000020E8
		public RESULT removeDSP(DSP dsp)
		{
			return ChannelGroup.FMOD5_ChannelGroup_RemoveDSP(this.handle, dsp.handle);
		}

		// Token: 0x06000294 RID: 660 RVA: 0x00003EFB File Offset: 0x000020FB
		public RESULT getNumDSPs(out int numdsps)
		{
			return ChannelGroup.FMOD5_ChannelGroup_GetNumDSPs(this.handle, out numdsps);
		}

		// Token: 0x06000295 RID: 661 RVA: 0x00003F09 File Offset: 0x00002109
		public RESULT setDSPIndex(DSP dsp, int index)
		{
			return ChannelGroup.FMOD5_ChannelGroup_SetDSPIndex(this.handle, dsp.handle, index);
		}

		// Token: 0x06000296 RID: 662 RVA: 0x00003F1D File Offset: 0x0000211D
		public RESULT getDSPIndex(DSP dsp, out int index)
		{
			return ChannelGroup.FMOD5_ChannelGroup_GetDSPIndex(this.handle, dsp.handle, out index);
		}

		// Token: 0x06000297 RID: 663 RVA: 0x00003F31 File Offset: 0x00002131
		public RESULT set3DAttributes(ref VECTOR pos, ref VECTOR vel)
		{
			return ChannelGroup.FMOD5_ChannelGroup_Set3DAttributes(this.handle, ref pos, ref vel);
		}

		// Token: 0x06000298 RID: 664 RVA: 0x00003F40 File Offset: 0x00002140
		public RESULT get3DAttributes(out VECTOR pos, out VECTOR vel)
		{
			return ChannelGroup.FMOD5_ChannelGroup_Get3DAttributes(this.handle, out pos, out vel);
		}

		// Token: 0x06000299 RID: 665 RVA: 0x00003F4F File Offset: 0x0000214F
		public RESULT set3DMinMaxDistance(float mindistance, float maxdistance)
		{
			return ChannelGroup.FMOD5_ChannelGroup_Set3DMinMaxDistance(this.handle, mindistance, maxdistance);
		}

		// Token: 0x0600029A RID: 666 RVA: 0x00003F5E File Offset: 0x0000215E
		public RESULT get3DMinMaxDistance(out float mindistance, out float maxdistance)
		{
			return ChannelGroup.FMOD5_ChannelGroup_Get3DMinMaxDistance(this.handle, out mindistance, out maxdistance);
		}

		// Token: 0x0600029B RID: 667 RVA: 0x00003F6D File Offset: 0x0000216D
		public RESULT set3DConeSettings(float insideconeangle, float outsideconeangle, float outsidevolume)
		{
			return ChannelGroup.FMOD5_ChannelGroup_Set3DConeSettings(this.handle, insideconeangle, outsideconeangle, outsidevolume);
		}

		// Token: 0x0600029C RID: 668 RVA: 0x00003F7D File Offset: 0x0000217D
		public RESULT get3DConeSettings(out float insideconeangle, out float outsideconeangle, out float outsidevolume)
		{
			return ChannelGroup.FMOD5_ChannelGroup_Get3DConeSettings(this.handle, out insideconeangle, out outsideconeangle, out outsidevolume);
		}

		// Token: 0x0600029D RID: 669 RVA: 0x00003F8D File Offset: 0x0000218D
		public RESULT set3DConeOrientation(ref VECTOR orientation)
		{
			return ChannelGroup.FMOD5_ChannelGroup_Set3DConeOrientation(this.handle, ref orientation);
		}

		// Token: 0x0600029E RID: 670 RVA: 0x00003F9B File Offset: 0x0000219B
		public RESULT get3DConeOrientation(out VECTOR orientation)
		{
			return ChannelGroup.FMOD5_ChannelGroup_Get3DConeOrientation(this.handle, out orientation);
		}

		// Token: 0x0600029F RID: 671 RVA: 0x00003FA9 File Offset: 0x000021A9
		public RESULT set3DCustomRolloff(ref VECTOR points, int numpoints)
		{
			return ChannelGroup.FMOD5_ChannelGroup_Set3DCustomRolloff(this.handle, ref points, numpoints);
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x00003FB8 File Offset: 0x000021B8
		public RESULT get3DCustomRolloff(out IntPtr points, out int numpoints)
		{
			return ChannelGroup.FMOD5_ChannelGroup_Get3DCustomRolloff(this.handle, out points, out numpoints);
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x00003FC7 File Offset: 0x000021C7
		public RESULT set3DOcclusion(float directocclusion, float reverbocclusion)
		{
			return ChannelGroup.FMOD5_ChannelGroup_Set3DOcclusion(this.handle, directocclusion, reverbocclusion);
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x00003FD6 File Offset: 0x000021D6
		public RESULT get3DOcclusion(out float directocclusion, out float reverbocclusion)
		{
			return ChannelGroup.FMOD5_ChannelGroup_Get3DOcclusion(this.handle, out directocclusion, out reverbocclusion);
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x00003FE5 File Offset: 0x000021E5
		public RESULT set3DSpread(float angle)
		{
			return ChannelGroup.FMOD5_ChannelGroup_Set3DSpread(this.handle, angle);
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x00003FF3 File Offset: 0x000021F3
		public RESULT get3DSpread(out float angle)
		{
			return ChannelGroup.FMOD5_ChannelGroup_Get3DSpread(this.handle, out angle);
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x00004001 File Offset: 0x00002201
		public RESULT set3DLevel(float level)
		{
			return ChannelGroup.FMOD5_ChannelGroup_Set3DLevel(this.handle, level);
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x0000400F File Offset: 0x0000220F
		public RESULT get3DLevel(out float level)
		{
			return ChannelGroup.FMOD5_ChannelGroup_Get3DLevel(this.handle, out level);
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x0000401D File Offset: 0x0000221D
		public RESULT set3DDopplerLevel(float level)
		{
			return ChannelGroup.FMOD5_ChannelGroup_Set3DDopplerLevel(this.handle, level);
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0000402B File Offset: 0x0000222B
		public RESULT get3DDopplerLevel(out float level)
		{
			return ChannelGroup.FMOD5_ChannelGroup_Get3DDopplerLevel(this.handle, out level);
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x00004039 File Offset: 0x00002239
		public RESULT set3DDistanceFilter(bool custom, float customLevel, float centerFreq)
		{
			return ChannelGroup.FMOD5_ChannelGroup_Set3DDistanceFilter(this.handle, custom, customLevel, centerFreq);
		}

		// Token: 0x060002AA RID: 682 RVA: 0x00004049 File Offset: 0x00002249
		public RESULT get3DDistanceFilter(out bool custom, out float customLevel, out float centerFreq)
		{
			return ChannelGroup.FMOD5_ChannelGroup_Get3DDistanceFilter(this.handle, out custom, out customLevel, out centerFreq);
		}

		// Token: 0x060002AB RID: 683 RVA: 0x00004059 File Offset: 0x00002259
		public RESULT setUserData(IntPtr userdata)
		{
			return ChannelGroup.FMOD5_ChannelGroup_SetUserData(this.handle, userdata);
		}

		// Token: 0x060002AC RID: 684 RVA: 0x00004067 File Offset: 0x00002267
		public RESULT getUserData(out IntPtr userdata)
		{
			return ChannelGroup.FMOD5_ChannelGroup_GetUserData(this.handle, out userdata);
		}

		// Token: 0x060002AD RID: 685
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_Release(IntPtr channelgroup);

		// Token: 0x060002AE RID: 686
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_AddGroup(IntPtr channelgroup, IntPtr group, bool propagatedspclock, IntPtr zero);

		// Token: 0x060002AF RID: 687
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_AddGroup(IntPtr channelgroup, IntPtr group, bool propagatedspclock, out IntPtr connection);

		// Token: 0x060002B0 RID: 688
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_GetNumGroups(IntPtr channelgroup, out int numgroups);

		// Token: 0x060002B1 RID: 689
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_GetGroup(IntPtr channelgroup, int index, out IntPtr group);

		// Token: 0x060002B2 RID: 690
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_GetParentGroup(IntPtr channelgroup, out IntPtr group);

		// Token: 0x060002B3 RID: 691
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_GetName(IntPtr channelgroup, IntPtr name, int namelen);

		// Token: 0x060002B4 RID: 692
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_GetNumChannels(IntPtr channelgroup, out int numchannels);

		// Token: 0x060002B5 RID: 693
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_GetChannel(IntPtr channelgroup, int index, out IntPtr channel);

		// Token: 0x060002B6 RID: 694
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_GetSystemObject(IntPtr channelgroup, out IntPtr system);

		// Token: 0x060002B7 RID: 695
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_Stop(IntPtr channelgroup);

		// Token: 0x060002B8 RID: 696
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_SetPaused(IntPtr channelgroup, bool paused);

		// Token: 0x060002B9 RID: 697
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_GetPaused(IntPtr channelgroup, out bool paused);

		// Token: 0x060002BA RID: 698
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_SetVolume(IntPtr channelgroup, float volume);

		// Token: 0x060002BB RID: 699
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_GetVolume(IntPtr channelgroup, out float volume);

		// Token: 0x060002BC RID: 700
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_SetVolumeRamp(IntPtr channelgroup, bool ramp);

		// Token: 0x060002BD RID: 701
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_GetVolumeRamp(IntPtr channelgroup, out bool ramp);

		// Token: 0x060002BE RID: 702
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_GetAudibility(IntPtr channelgroup, out float audibility);

		// Token: 0x060002BF RID: 703
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_SetPitch(IntPtr channelgroup, float pitch);

		// Token: 0x060002C0 RID: 704
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_GetPitch(IntPtr channelgroup, out float pitch);

		// Token: 0x060002C1 RID: 705
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_SetMute(IntPtr channelgroup, bool mute);

		// Token: 0x060002C2 RID: 706
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_GetMute(IntPtr channelgroup, out bool mute);

		// Token: 0x060002C3 RID: 707
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_SetReverbProperties(IntPtr channelgroup, int instance, float wet);

		// Token: 0x060002C4 RID: 708
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_GetReverbProperties(IntPtr channelgroup, int instance, out float wet);

		// Token: 0x060002C5 RID: 709
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_SetLowPassGain(IntPtr channelgroup, float gain);

		// Token: 0x060002C6 RID: 710
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_GetLowPassGain(IntPtr channelgroup, out float gain);

		// Token: 0x060002C7 RID: 711
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_SetMode(IntPtr channelgroup, MODE mode);

		// Token: 0x060002C8 RID: 712
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_GetMode(IntPtr channelgroup, out MODE mode);

		// Token: 0x060002C9 RID: 713
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_SetCallback(IntPtr channelgroup, CHANNELCONTROL_CALLBACK callback);

		// Token: 0x060002CA RID: 714
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_IsPlaying(IntPtr channelgroup, out bool isplaying);

		// Token: 0x060002CB RID: 715
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_SetPan(IntPtr channelgroup, float pan);

		// Token: 0x060002CC RID: 716
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_SetMixLevelsOutput(IntPtr channelgroup, float frontleft, float frontright, float center, float lfe, float surroundleft, float surroundright, float backleft, float backright);

		// Token: 0x060002CD RID: 717
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_SetMixLevelsInput(IntPtr channelgroup, float[] levels, int numlevels);

		// Token: 0x060002CE RID: 718
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_SetMixMatrix(IntPtr channelgroup, float[] matrix, int outchannels, int inchannels, int inchannel_hop);

		// Token: 0x060002CF RID: 719
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_GetMixMatrix(IntPtr channelgroup, float[] matrix, out int outchannels, out int inchannels, int inchannel_hop);

		// Token: 0x060002D0 RID: 720
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_GetDSPClock(IntPtr channelgroup, out ulong dspclock, out ulong parentclock);

		// Token: 0x060002D1 RID: 721
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_SetDelay(IntPtr channelgroup, ulong dspclock_start, ulong dspclock_end, bool stopchannels);

		// Token: 0x060002D2 RID: 722
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_GetDelay(IntPtr channelgroup, out ulong dspclock_start, out ulong dspclock_end, IntPtr zero);

		// Token: 0x060002D3 RID: 723
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_GetDelay(IntPtr channelgroup, out ulong dspclock_start, out ulong dspclock_end, out bool stopchannels);

		// Token: 0x060002D4 RID: 724
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_AddFadePoint(IntPtr channelgroup, ulong dspclock, float volume);

		// Token: 0x060002D5 RID: 725
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_SetFadePointRamp(IntPtr channelgroup, ulong dspclock, float volume);

		// Token: 0x060002D6 RID: 726
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_RemoveFadePoints(IntPtr channelgroup, ulong dspclock_start, ulong dspclock_end);

		// Token: 0x060002D7 RID: 727
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_GetFadePoints(IntPtr channelgroup, ref uint numpoints, ulong[] point_dspclock, float[] point_volume);

		// Token: 0x060002D8 RID: 728
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_GetDSP(IntPtr channelgroup, int index, out IntPtr dsp);

		// Token: 0x060002D9 RID: 729
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_AddDSP(IntPtr channelgroup, int index, IntPtr dsp);

		// Token: 0x060002DA RID: 730
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_RemoveDSP(IntPtr channelgroup, IntPtr dsp);

		// Token: 0x060002DB RID: 731
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_GetNumDSPs(IntPtr channelgroup, out int numdsps);

		// Token: 0x060002DC RID: 732
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_SetDSPIndex(IntPtr channelgroup, IntPtr dsp, int index);

		// Token: 0x060002DD RID: 733
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_GetDSPIndex(IntPtr channelgroup, IntPtr dsp, out int index);

		// Token: 0x060002DE RID: 734
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_Set3DAttributes(IntPtr channelgroup, ref VECTOR pos, ref VECTOR vel);

		// Token: 0x060002DF RID: 735
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_Get3DAttributes(IntPtr channelgroup, out VECTOR pos, out VECTOR vel);

		// Token: 0x060002E0 RID: 736
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_Set3DMinMaxDistance(IntPtr channelgroup, float mindistance, float maxdistance);

		// Token: 0x060002E1 RID: 737
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_Get3DMinMaxDistance(IntPtr channelgroup, out float mindistance, out float maxdistance);

		// Token: 0x060002E2 RID: 738
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_Set3DConeSettings(IntPtr channelgroup, float insideconeangle, float outsideconeangle, float outsidevolume);

		// Token: 0x060002E3 RID: 739
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_Get3DConeSettings(IntPtr channelgroup, out float insideconeangle, out float outsideconeangle, out float outsidevolume);

		// Token: 0x060002E4 RID: 740
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_Set3DConeOrientation(IntPtr channelgroup, ref VECTOR orientation);

		// Token: 0x060002E5 RID: 741
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_Get3DConeOrientation(IntPtr channelgroup, out VECTOR orientation);

		// Token: 0x060002E6 RID: 742
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_Set3DCustomRolloff(IntPtr channelgroup, ref VECTOR points, int numpoints);

		// Token: 0x060002E7 RID: 743
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_Get3DCustomRolloff(IntPtr channelgroup, out IntPtr points, out int numpoints);

		// Token: 0x060002E8 RID: 744
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_Set3DOcclusion(IntPtr channelgroup, float directocclusion, float reverbocclusion);

		// Token: 0x060002E9 RID: 745
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_Get3DOcclusion(IntPtr channelgroup, out float directocclusion, out float reverbocclusion);

		// Token: 0x060002EA RID: 746
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_Set3DSpread(IntPtr channelgroup, float angle);

		// Token: 0x060002EB RID: 747
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_Get3DSpread(IntPtr channelgroup, out float angle);

		// Token: 0x060002EC RID: 748
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_Set3DLevel(IntPtr channelgroup, float level);

		// Token: 0x060002ED RID: 749
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_Get3DLevel(IntPtr channelgroup, out float level);

		// Token: 0x060002EE RID: 750
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_Set3DDopplerLevel(IntPtr channelgroup, float level);

		// Token: 0x060002EF RID: 751
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_Get3DDopplerLevel(IntPtr channelgroup, out float level);

		// Token: 0x060002F0 RID: 752
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_Set3DDistanceFilter(IntPtr channelgroup, bool custom, float customLevel, float centerFreq);

		// Token: 0x060002F1 RID: 753
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_Get3DDistanceFilter(IntPtr channelgroup, out bool custom, out float customLevel, out float centerFreq);

		// Token: 0x060002F2 RID: 754
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_SetUserData(IntPtr channelgroup, IntPtr userdata);

		// Token: 0x060002F3 RID: 755
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_ChannelGroup_GetUserData(IntPtr channelgroup, out IntPtr userdata);

		// Token: 0x060002F4 RID: 756 RVA: 0x00004075 File Offset: 0x00002275
		public ChannelGroup(IntPtr ptr)
		{
			this.handle = ptr;
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x0000407E File Offset: 0x0000227E
		public bool hasHandle()
		{
			return this.handle != IntPtr.Zero;
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x00004090 File Offset: 0x00002290
		public void clearHandle()
		{
			this.handle = IntPtr.Zero;
		}

		// Token: 0x04000241 RID: 577
		public IntPtr handle;
	}
}
