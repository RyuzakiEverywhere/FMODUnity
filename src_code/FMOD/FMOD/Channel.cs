using System;
using System.Runtime.InteropServices;

namespace FMOD
{
	// Token: 0x02000046 RID: 70
	public struct Channel : IChannelControl
	{
		// Token: 0x060001C9 RID: 457 RVA: 0x000036E6 File Offset: 0x000018E6
		public RESULT setFrequency(float frequency)
		{
			return Channel.FMOD5_Channel_SetFrequency(this.handle, frequency);
		}

		// Token: 0x060001CA RID: 458 RVA: 0x000036F4 File Offset: 0x000018F4
		public RESULT getFrequency(out float frequency)
		{
			return Channel.FMOD5_Channel_GetFrequency(this.handle, out frequency);
		}

		// Token: 0x060001CB RID: 459 RVA: 0x00003702 File Offset: 0x00001902
		public RESULT setPriority(int priority)
		{
			return Channel.FMOD5_Channel_SetPriority(this.handle, priority);
		}

		// Token: 0x060001CC RID: 460 RVA: 0x00003710 File Offset: 0x00001910
		public RESULT getPriority(out int priority)
		{
			return Channel.FMOD5_Channel_GetPriority(this.handle, out priority);
		}

		// Token: 0x060001CD RID: 461 RVA: 0x0000371E File Offset: 0x0000191E
		public RESULT setPosition(uint position, TIMEUNIT postype)
		{
			return Channel.FMOD5_Channel_SetPosition(this.handle, position, postype);
		}

		// Token: 0x060001CE RID: 462 RVA: 0x0000372D File Offset: 0x0000192D
		public RESULT getPosition(out uint position, TIMEUNIT postype)
		{
			return Channel.FMOD5_Channel_GetPosition(this.handle, out position, postype);
		}

		// Token: 0x060001CF RID: 463 RVA: 0x0000373C File Offset: 0x0000193C
		public RESULT setChannelGroup(ChannelGroup channelgroup)
		{
			return Channel.FMOD5_Channel_SetChannelGroup(this.handle, channelgroup.handle);
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x0000374F File Offset: 0x0000194F
		public RESULT getChannelGroup(out ChannelGroup channelgroup)
		{
			return Channel.FMOD5_Channel_GetChannelGroup(this.handle, out channelgroup.handle);
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x00003762 File Offset: 0x00001962
		public RESULT setLoopCount(int loopcount)
		{
			return Channel.FMOD5_Channel_SetLoopCount(this.handle, loopcount);
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x00003770 File Offset: 0x00001970
		public RESULT getLoopCount(out int loopcount)
		{
			return Channel.FMOD5_Channel_GetLoopCount(this.handle, out loopcount);
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x0000377E File Offset: 0x0000197E
		public RESULT setLoopPoints(uint loopstart, TIMEUNIT loopstarttype, uint loopend, TIMEUNIT loopendtype)
		{
			return Channel.FMOD5_Channel_SetLoopPoints(this.handle, loopstart, loopstarttype, loopend, loopendtype);
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x00003790 File Offset: 0x00001990
		public RESULT getLoopPoints(out uint loopstart, TIMEUNIT loopstarttype, out uint loopend, TIMEUNIT loopendtype)
		{
			return Channel.FMOD5_Channel_GetLoopPoints(this.handle, out loopstart, loopstarttype, out loopend, loopendtype);
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x000037A2 File Offset: 0x000019A2
		public RESULT isVirtual(out bool isvirtual)
		{
			return Channel.FMOD5_Channel_IsVirtual(this.handle, out isvirtual);
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x000037B0 File Offset: 0x000019B0
		public RESULT getCurrentSound(out Sound sound)
		{
			return Channel.FMOD5_Channel_GetCurrentSound(this.handle, out sound.handle);
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x000037C3 File Offset: 0x000019C3
		public RESULT getIndex(out int index)
		{
			return Channel.FMOD5_Channel_GetIndex(this.handle, out index);
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x000037D1 File Offset: 0x000019D1
		public RESULT getSystemObject(out System system)
		{
			return Channel.FMOD5_Channel_GetSystemObject(this.handle, out system.handle);
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x000037E4 File Offset: 0x000019E4
		public RESULT stop()
		{
			return Channel.FMOD5_Channel_Stop(this.handle);
		}

		// Token: 0x060001DA RID: 474 RVA: 0x000037F1 File Offset: 0x000019F1
		public RESULT setPaused(bool paused)
		{
			return Channel.FMOD5_Channel_SetPaused(this.handle, paused);
		}

		// Token: 0x060001DB RID: 475 RVA: 0x000037FF File Offset: 0x000019FF
		public RESULT getPaused(out bool paused)
		{
			return Channel.FMOD5_Channel_GetPaused(this.handle, out paused);
		}

		// Token: 0x060001DC RID: 476 RVA: 0x0000380D File Offset: 0x00001A0D
		public RESULT setVolume(float volume)
		{
			return Channel.FMOD5_Channel_SetVolume(this.handle, volume);
		}

		// Token: 0x060001DD RID: 477 RVA: 0x0000381B File Offset: 0x00001A1B
		public RESULT getVolume(out float volume)
		{
			return Channel.FMOD5_Channel_GetVolume(this.handle, out volume);
		}

		// Token: 0x060001DE RID: 478 RVA: 0x00003829 File Offset: 0x00001A29
		public RESULT setVolumeRamp(bool ramp)
		{
			return Channel.FMOD5_Channel_SetVolumeRamp(this.handle, ramp);
		}

		// Token: 0x060001DF RID: 479 RVA: 0x00003837 File Offset: 0x00001A37
		public RESULT getVolumeRamp(out bool ramp)
		{
			return Channel.FMOD5_Channel_GetVolumeRamp(this.handle, out ramp);
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x00003845 File Offset: 0x00001A45
		public RESULT getAudibility(out float audibility)
		{
			return Channel.FMOD5_Channel_GetAudibility(this.handle, out audibility);
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x00003853 File Offset: 0x00001A53
		public RESULT setPitch(float pitch)
		{
			return Channel.FMOD5_Channel_SetPitch(this.handle, pitch);
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x00003861 File Offset: 0x00001A61
		public RESULT getPitch(out float pitch)
		{
			return Channel.FMOD5_Channel_GetPitch(this.handle, out pitch);
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x0000386F File Offset: 0x00001A6F
		public RESULT setMute(bool mute)
		{
			return Channel.FMOD5_Channel_SetMute(this.handle, mute);
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x0000387D File Offset: 0x00001A7D
		public RESULT getMute(out bool mute)
		{
			return Channel.FMOD5_Channel_GetMute(this.handle, out mute);
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x0000388B File Offset: 0x00001A8B
		public RESULT setReverbProperties(int instance, float wet)
		{
			return Channel.FMOD5_Channel_SetReverbProperties(this.handle, instance, wet);
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x0000389A File Offset: 0x00001A9A
		public RESULT getReverbProperties(int instance, out float wet)
		{
			return Channel.FMOD5_Channel_GetReverbProperties(this.handle, instance, out wet);
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x000038A9 File Offset: 0x00001AA9
		public RESULT setLowPassGain(float gain)
		{
			return Channel.FMOD5_Channel_SetLowPassGain(this.handle, gain);
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x000038B7 File Offset: 0x00001AB7
		public RESULT getLowPassGain(out float gain)
		{
			return Channel.FMOD5_Channel_GetLowPassGain(this.handle, out gain);
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x000038C5 File Offset: 0x00001AC5
		public RESULT setMode(MODE mode)
		{
			return Channel.FMOD5_Channel_SetMode(this.handle, mode);
		}

		// Token: 0x060001EA RID: 490 RVA: 0x000038D3 File Offset: 0x00001AD3
		public RESULT getMode(out MODE mode)
		{
			return Channel.FMOD5_Channel_GetMode(this.handle, out mode);
		}

		// Token: 0x060001EB RID: 491 RVA: 0x000038E1 File Offset: 0x00001AE1
		public RESULT setCallback(CHANNELCONTROL_CALLBACK callback)
		{
			return Channel.FMOD5_Channel_SetCallback(this.handle, callback);
		}

		// Token: 0x060001EC RID: 492 RVA: 0x000038EF File Offset: 0x00001AEF
		public RESULT isPlaying(out bool isplaying)
		{
			return Channel.FMOD5_Channel_IsPlaying(this.handle, out isplaying);
		}

		// Token: 0x060001ED RID: 493 RVA: 0x000038FD File Offset: 0x00001AFD
		public RESULT setPan(float pan)
		{
			return Channel.FMOD5_Channel_SetPan(this.handle, pan);
		}

		// Token: 0x060001EE RID: 494 RVA: 0x0000390C File Offset: 0x00001B0C
		public RESULT setMixLevelsOutput(float frontleft, float frontright, float center, float lfe, float surroundleft, float surroundright, float backleft, float backright)
		{
			return Channel.FMOD5_Channel_SetMixLevelsOutput(this.handle, frontleft, frontright, center, lfe, surroundleft, surroundright, backleft, backright);
		}

		// Token: 0x060001EF RID: 495 RVA: 0x00003931 File Offset: 0x00001B31
		public RESULT setMixLevelsInput(float[] levels, int numlevels)
		{
			return Channel.FMOD5_Channel_SetMixLevelsInput(this.handle, levels, numlevels);
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x00003940 File Offset: 0x00001B40
		public RESULT setMixMatrix(float[] matrix, int outchannels, int inchannels, int inchannel_hop = 0)
		{
			return Channel.FMOD5_Channel_SetMixMatrix(this.handle, matrix, outchannels, inchannels, inchannel_hop);
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x00003952 File Offset: 0x00001B52
		public RESULT getMixMatrix(float[] matrix, out int outchannels, out int inchannels, int inchannel_hop = 0)
		{
			return Channel.FMOD5_Channel_GetMixMatrix(this.handle, matrix, out outchannels, out inchannels, inchannel_hop);
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x00003964 File Offset: 0x00001B64
		public RESULT getDSPClock(out ulong dspclock, out ulong parentclock)
		{
			return Channel.FMOD5_Channel_GetDSPClock(this.handle, out dspclock, out parentclock);
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x00003973 File Offset: 0x00001B73
		public RESULT setDelay(ulong dspclock_start, ulong dspclock_end, bool stopchannels = true)
		{
			return Channel.FMOD5_Channel_SetDelay(this.handle, dspclock_start, dspclock_end, stopchannels);
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x00003983 File Offset: 0x00001B83
		public RESULT getDelay(out ulong dspclock_start, out ulong dspclock_end)
		{
			return Channel.FMOD5_Channel_GetDelay(this.handle, out dspclock_start, out dspclock_end, IntPtr.Zero);
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x00003997 File Offset: 0x00001B97
		public RESULT getDelay(out ulong dspclock_start, out ulong dspclock_end, out bool stopchannels)
		{
			return Channel.FMOD5_Channel_GetDelay(this.handle, out dspclock_start, out dspclock_end, out stopchannels);
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x000039A7 File Offset: 0x00001BA7
		public RESULT addFadePoint(ulong dspclock, float volume)
		{
			return Channel.FMOD5_Channel_AddFadePoint(this.handle, dspclock, volume);
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x000039B6 File Offset: 0x00001BB6
		public RESULT setFadePointRamp(ulong dspclock, float volume)
		{
			return Channel.FMOD5_Channel_SetFadePointRamp(this.handle, dspclock, volume);
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x000039C5 File Offset: 0x00001BC5
		public RESULT removeFadePoints(ulong dspclock_start, ulong dspclock_end)
		{
			return Channel.FMOD5_Channel_RemoveFadePoints(this.handle, dspclock_start, dspclock_end);
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x000039D4 File Offset: 0x00001BD4
		public RESULT getFadePoints(ref uint numpoints, ulong[] point_dspclock, float[] point_volume)
		{
			return Channel.FMOD5_Channel_GetFadePoints(this.handle, ref numpoints, point_dspclock, point_volume);
		}

		// Token: 0x060001FA RID: 506 RVA: 0x000039E4 File Offset: 0x00001BE4
		public RESULT getDSP(int index, out DSP dsp)
		{
			return Channel.FMOD5_Channel_GetDSP(this.handle, index, out dsp.handle);
		}

		// Token: 0x060001FB RID: 507 RVA: 0x000039F8 File Offset: 0x00001BF8
		public RESULT addDSP(int index, DSP dsp)
		{
			return Channel.FMOD5_Channel_AddDSP(this.handle, index, dsp.handle);
		}

		// Token: 0x060001FC RID: 508 RVA: 0x00003A0C File Offset: 0x00001C0C
		public RESULT removeDSP(DSP dsp)
		{
			return Channel.FMOD5_Channel_RemoveDSP(this.handle, dsp.handle);
		}

		// Token: 0x060001FD RID: 509 RVA: 0x00003A1F File Offset: 0x00001C1F
		public RESULT getNumDSPs(out int numdsps)
		{
			return Channel.FMOD5_Channel_GetNumDSPs(this.handle, out numdsps);
		}

		// Token: 0x060001FE RID: 510 RVA: 0x00003A2D File Offset: 0x00001C2D
		public RESULT setDSPIndex(DSP dsp, int index)
		{
			return Channel.FMOD5_Channel_SetDSPIndex(this.handle, dsp.handle, index);
		}

		// Token: 0x060001FF RID: 511 RVA: 0x00003A41 File Offset: 0x00001C41
		public RESULT getDSPIndex(DSP dsp, out int index)
		{
			return Channel.FMOD5_Channel_GetDSPIndex(this.handle, dsp.handle, out index);
		}

		// Token: 0x06000200 RID: 512 RVA: 0x00003A55 File Offset: 0x00001C55
		public RESULT set3DAttributes(ref VECTOR pos, ref VECTOR vel)
		{
			return Channel.FMOD5_Channel_Set3DAttributes(this.handle, ref pos, ref vel);
		}

		// Token: 0x06000201 RID: 513 RVA: 0x00003A64 File Offset: 0x00001C64
		public RESULT get3DAttributes(out VECTOR pos, out VECTOR vel)
		{
			return Channel.FMOD5_Channel_Get3DAttributes(this.handle, out pos, out vel);
		}

		// Token: 0x06000202 RID: 514 RVA: 0x00003A73 File Offset: 0x00001C73
		public RESULT set3DMinMaxDistance(float mindistance, float maxdistance)
		{
			return Channel.FMOD5_Channel_Set3DMinMaxDistance(this.handle, mindistance, maxdistance);
		}

		// Token: 0x06000203 RID: 515 RVA: 0x00003A82 File Offset: 0x00001C82
		public RESULT get3DMinMaxDistance(out float mindistance, out float maxdistance)
		{
			return Channel.FMOD5_Channel_Get3DMinMaxDistance(this.handle, out mindistance, out maxdistance);
		}

		// Token: 0x06000204 RID: 516 RVA: 0x00003A91 File Offset: 0x00001C91
		public RESULT set3DConeSettings(float insideconeangle, float outsideconeangle, float outsidevolume)
		{
			return Channel.FMOD5_Channel_Set3DConeSettings(this.handle, insideconeangle, outsideconeangle, outsidevolume);
		}

		// Token: 0x06000205 RID: 517 RVA: 0x00003AA1 File Offset: 0x00001CA1
		public RESULT get3DConeSettings(out float insideconeangle, out float outsideconeangle, out float outsidevolume)
		{
			return Channel.FMOD5_Channel_Get3DConeSettings(this.handle, out insideconeangle, out outsideconeangle, out outsidevolume);
		}

		// Token: 0x06000206 RID: 518 RVA: 0x00003AB1 File Offset: 0x00001CB1
		public RESULT set3DConeOrientation(ref VECTOR orientation)
		{
			return Channel.FMOD5_Channel_Set3DConeOrientation(this.handle, ref orientation);
		}

		// Token: 0x06000207 RID: 519 RVA: 0x00003ABF File Offset: 0x00001CBF
		public RESULT get3DConeOrientation(out VECTOR orientation)
		{
			return Channel.FMOD5_Channel_Get3DConeOrientation(this.handle, out orientation);
		}

		// Token: 0x06000208 RID: 520 RVA: 0x00003ACD File Offset: 0x00001CCD
		public RESULT set3DCustomRolloff(ref VECTOR points, int numpoints)
		{
			return Channel.FMOD5_Channel_Set3DCustomRolloff(this.handle, ref points, numpoints);
		}

		// Token: 0x06000209 RID: 521 RVA: 0x00003ADC File Offset: 0x00001CDC
		public RESULT get3DCustomRolloff(out IntPtr points, out int numpoints)
		{
			return Channel.FMOD5_Channel_Get3DCustomRolloff(this.handle, out points, out numpoints);
		}

		// Token: 0x0600020A RID: 522 RVA: 0x00003AEB File Offset: 0x00001CEB
		public RESULT set3DOcclusion(float directocclusion, float reverbocclusion)
		{
			return Channel.FMOD5_Channel_Set3DOcclusion(this.handle, directocclusion, reverbocclusion);
		}

		// Token: 0x0600020B RID: 523 RVA: 0x00003AFA File Offset: 0x00001CFA
		public RESULT get3DOcclusion(out float directocclusion, out float reverbocclusion)
		{
			return Channel.FMOD5_Channel_Get3DOcclusion(this.handle, out directocclusion, out reverbocclusion);
		}

		// Token: 0x0600020C RID: 524 RVA: 0x00003B09 File Offset: 0x00001D09
		public RESULT set3DSpread(float angle)
		{
			return Channel.FMOD5_Channel_Set3DSpread(this.handle, angle);
		}

		// Token: 0x0600020D RID: 525 RVA: 0x00003B17 File Offset: 0x00001D17
		public RESULT get3DSpread(out float angle)
		{
			return Channel.FMOD5_Channel_Get3DSpread(this.handle, out angle);
		}

		// Token: 0x0600020E RID: 526 RVA: 0x00003B25 File Offset: 0x00001D25
		public RESULT set3DLevel(float level)
		{
			return Channel.FMOD5_Channel_Set3DLevel(this.handle, level);
		}

		// Token: 0x0600020F RID: 527 RVA: 0x00003B33 File Offset: 0x00001D33
		public RESULT get3DLevel(out float level)
		{
			return Channel.FMOD5_Channel_Get3DLevel(this.handle, out level);
		}

		// Token: 0x06000210 RID: 528 RVA: 0x00003B41 File Offset: 0x00001D41
		public RESULT set3DDopplerLevel(float level)
		{
			return Channel.FMOD5_Channel_Set3DDopplerLevel(this.handle, level);
		}

		// Token: 0x06000211 RID: 529 RVA: 0x00003B4F File Offset: 0x00001D4F
		public RESULT get3DDopplerLevel(out float level)
		{
			return Channel.FMOD5_Channel_Get3DDopplerLevel(this.handle, out level);
		}

		// Token: 0x06000212 RID: 530 RVA: 0x00003B5D File Offset: 0x00001D5D
		public RESULT set3DDistanceFilter(bool custom, float customLevel, float centerFreq)
		{
			return Channel.FMOD5_Channel_Set3DDistanceFilter(this.handle, custom, customLevel, centerFreq);
		}

		// Token: 0x06000213 RID: 531 RVA: 0x00003B6D File Offset: 0x00001D6D
		public RESULT get3DDistanceFilter(out bool custom, out float customLevel, out float centerFreq)
		{
			return Channel.FMOD5_Channel_Get3DDistanceFilter(this.handle, out custom, out customLevel, out centerFreq);
		}

		// Token: 0x06000214 RID: 532 RVA: 0x00003B7D File Offset: 0x00001D7D
		public RESULT setUserData(IntPtr userdata)
		{
			return Channel.FMOD5_Channel_SetUserData(this.handle, userdata);
		}

		// Token: 0x06000215 RID: 533 RVA: 0x00003B8B File Offset: 0x00001D8B
		public RESULT getUserData(out IntPtr userdata)
		{
			return Channel.FMOD5_Channel_GetUserData(this.handle, out userdata);
		}

		// Token: 0x06000216 RID: 534
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_SetFrequency(IntPtr channel, float frequency);

		// Token: 0x06000217 RID: 535
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_GetFrequency(IntPtr channel, out float frequency);

		// Token: 0x06000218 RID: 536
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_SetPriority(IntPtr channel, int priority);

		// Token: 0x06000219 RID: 537
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_GetPriority(IntPtr channel, out int priority);

		// Token: 0x0600021A RID: 538
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_SetPosition(IntPtr channel, uint position, TIMEUNIT postype);

		// Token: 0x0600021B RID: 539
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_GetPosition(IntPtr channel, out uint position, TIMEUNIT postype);

		// Token: 0x0600021C RID: 540
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_SetChannelGroup(IntPtr channel, IntPtr channelgroup);

		// Token: 0x0600021D RID: 541
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_GetChannelGroup(IntPtr channel, out IntPtr channelgroup);

		// Token: 0x0600021E RID: 542
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_SetLoopCount(IntPtr channel, int loopcount);

		// Token: 0x0600021F RID: 543
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_GetLoopCount(IntPtr channel, out int loopcount);

		// Token: 0x06000220 RID: 544
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_SetLoopPoints(IntPtr channel, uint loopstart, TIMEUNIT loopstarttype, uint loopend, TIMEUNIT loopendtype);

		// Token: 0x06000221 RID: 545
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_GetLoopPoints(IntPtr channel, out uint loopstart, TIMEUNIT loopstarttype, out uint loopend, TIMEUNIT loopendtype);

		// Token: 0x06000222 RID: 546
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_IsVirtual(IntPtr channel, out bool isvirtual);

		// Token: 0x06000223 RID: 547
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_GetCurrentSound(IntPtr channel, out IntPtr sound);

		// Token: 0x06000224 RID: 548
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_GetIndex(IntPtr channel, out int index);

		// Token: 0x06000225 RID: 549
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_GetSystemObject(IntPtr channel, out IntPtr system);

		// Token: 0x06000226 RID: 550
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_Stop(IntPtr channel);

		// Token: 0x06000227 RID: 551
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_SetPaused(IntPtr channel, bool paused);

		// Token: 0x06000228 RID: 552
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_GetPaused(IntPtr channel, out bool paused);

		// Token: 0x06000229 RID: 553
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_SetVolume(IntPtr channel, float volume);

		// Token: 0x0600022A RID: 554
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_GetVolume(IntPtr channel, out float volume);

		// Token: 0x0600022B RID: 555
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_SetVolumeRamp(IntPtr channel, bool ramp);

		// Token: 0x0600022C RID: 556
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_GetVolumeRamp(IntPtr channel, out bool ramp);

		// Token: 0x0600022D RID: 557
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_GetAudibility(IntPtr channel, out float audibility);

		// Token: 0x0600022E RID: 558
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_SetPitch(IntPtr channel, float pitch);

		// Token: 0x0600022F RID: 559
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_GetPitch(IntPtr channel, out float pitch);

		// Token: 0x06000230 RID: 560
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_SetMute(IntPtr channel, bool mute);

		// Token: 0x06000231 RID: 561
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_GetMute(IntPtr channel, out bool mute);

		// Token: 0x06000232 RID: 562
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_SetReverbProperties(IntPtr channel, int instance, float wet);

		// Token: 0x06000233 RID: 563
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_GetReverbProperties(IntPtr channel, int instance, out float wet);

		// Token: 0x06000234 RID: 564
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_SetLowPassGain(IntPtr channel, float gain);

		// Token: 0x06000235 RID: 565
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_GetLowPassGain(IntPtr channel, out float gain);

		// Token: 0x06000236 RID: 566
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_SetMode(IntPtr channel, MODE mode);

		// Token: 0x06000237 RID: 567
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_GetMode(IntPtr channel, out MODE mode);

		// Token: 0x06000238 RID: 568
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_SetCallback(IntPtr channel, CHANNELCONTROL_CALLBACK callback);

		// Token: 0x06000239 RID: 569
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_IsPlaying(IntPtr channel, out bool isplaying);

		// Token: 0x0600023A RID: 570
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_SetPan(IntPtr channel, float pan);

		// Token: 0x0600023B RID: 571
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_SetMixLevelsOutput(IntPtr channel, float frontleft, float frontright, float center, float lfe, float surroundleft, float surroundright, float backleft, float backright);

		// Token: 0x0600023C RID: 572
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_SetMixLevelsInput(IntPtr channel, float[] levels, int numlevels);

		// Token: 0x0600023D RID: 573
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_SetMixMatrix(IntPtr channel, float[] matrix, int outchannels, int inchannels, int inchannel_hop);

		// Token: 0x0600023E RID: 574
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_GetMixMatrix(IntPtr channel, float[] matrix, out int outchannels, out int inchannels, int inchannel_hop);

		// Token: 0x0600023F RID: 575
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_GetDSPClock(IntPtr channel, out ulong dspclock, out ulong parentclock);

		// Token: 0x06000240 RID: 576
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_SetDelay(IntPtr channel, ulong dspclock_start, ulong dspclock_end, bool stopchannels);

		// Token: 0x06000241 RID: 577
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_GetDelay(IntPtr channel, out ulong dspclock_start, out ulong dspclock_end, IntPtr zero);

		// Token: 0x06000242 RID: 578
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_GetDelay(IntPtr channel, out ulong dspclock_start, out ulong dspclock_end, out bool stopchannels);

		// Token: 0x06000243 RID: 579
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_AddFadePoint(IntPtr channel, ulong dspclock, float volume);

		// Token: 0x06000244 RID: 580
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_SetFadePointRamp(IntPtr channel, ulong dspclock, float volume);

		// Token: 0x06000245 RID: 581
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_RemoveFadePoints(IntPtr channel, ulong dspclock_start, ulong dspclock_end);

		// Token: 0x06000246 RID: 582
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_GetFadePoints(IntPtr channel, ref uint numpoints, ulong[] point_dspclock, float[] point_volume);

		// Token: 0x06000247 RID: 583
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_GetDSP(IntPtr channel, int index, out IntPtr dsp);

		// Token: 0x06000248 RID: 584
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_AddDSP(IntPtr channel, int index, IntPtr dsp);

		// Token: 0x06000249 RID: 585
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_RemoveDSP(IntPtr channel, IntPtr dsp);

		// Token: 0x0600024A RID: 586
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_GetNumDSPs(IntPtr channel, out int numdsps);

		// Token: 0x0600024B RID: 587
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_SetDSPIndex(IntPtr channel, IntPtr dsp, int index);

		// Token: 0x0600024C RID: 588
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_GetDSPIndex(IntPtr channel, IntPtr dsp, out int index);

		// Token: 0x0600024D RID: 589
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_Set3DAttributes(IntPtr channel, ref VECTOR pos, ref VECTOR vel);

		// Token: 0x0600024E RID: 590
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_Get3DAttributes(IntPtr channel, out VECTOR pos, out VECTOR vel);

		// Token: 0x0600024F RID: 591
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_Set3DMinMaxDistance(IntPtr channel, float mindistance, float maxdistance);

		// Token: 0x06000250 RID: 592
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_Get3DMinMaxDistance(IntPtr channel, out float mindistance, out float maxdistance);

		// Token: 0x06000251 RID: 593
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_Set3DConeSettings(IntPtr channel, float insideconeangle, float outsideconeangle, float outsidevolume);

		// Token: 0x06000252 RID: 594
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_Get3DConeSettings(IntPtr channel, out float insideconeangle, out float outsideconeangle, out float outsidevolume);

		// Token: 0x06000253 RID: 595
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_Set3DConeOrientation(IntPtr channel, ref VECTOR orientation);

		// Token: 0x06000254 RID: 596
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_Get3DConeOrientation(IntPtr channel, out VECTOR orientation);

		// Token: 0x06000255 RID: 597
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_Set3DCustomRolloff(IntPtr channel, ref VECTOR points, int numpoints);

		// Token: 0x06000256 RID: 598
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_Get3DCustomRolloff(IntPtr channel, out IntPtr points, out int numpoints);

		// Token: 0x06000257 RID: 599
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_Set3DOcclusion(IntPtr channel, float directocclusion, float reverbocclusion);

		// Token: 0x06000258 RID: 600
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_Get3DOcclusion(IntPtr channel, out float directocclusion, out float reverbocclusion);

		// Token: 0x06000259 RID: 601
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_Set3DSpread(IntPtr channel, float angle);

		// Token: 0x0600025A RID: 602
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_Get3DSpread(IntPtr channel, out float angle);

		// Token: 0x0600025B RID: 603
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_Set3DLevel(IntPtr channel, float level);

		// Token: 0x0600025C RID: 604
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_Get3DLevel(IntPtr channel, out float level);

		// Token: 0x0600025D RID: 605
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_Set3DDopplerLevel(IntPtr channel, float level);

		// Token: 0x0600025E RID: 606
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_Get3DDopplerLevel(IntPtr channel, out float level);

		// Token: 0x0600025F RID: 607
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_Set3DDistanceFilter(IntPtr channel, bool custom, float customLevel, float centerFreq);

		// Token: 0x06000260 RID: 608
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_Get3DDistanceFilter(IntPtr channel, out bool custom, out float customLevel, out float centerFreq);

		// Token: 0x06000261 RID: 609
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_SetUserData(IntPtr channel, IntPtr userdata);

		// Token: 0x06000262 RID: 610
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Channel_GetUserData(IntPtr channel, out IntPtr userdata);

		// Token: 0x06000263 RID: 611 RVA: 0x00003B99 File Offset: 0x00001D99
		public Channel(IntPtr ptr)
		{
			this.handle = ptr;
		}

		// Token: 0x06000264 RID: 612 RVA: 0x00003BA2 File Offset: 0x00001DA2
		public bool hasHandle()
		{
			return this.handle != IntPtr.Zero;
		}

		// Token: 0x06000265 RID: 613 RVA: 0x00003BB4 File Offset: 0x00001DB4
		public void clearHandle()
		{
			this.handle = IntPtr.Zero;
		}

		// Token: 0x04000240 RID: 576
		public IntPtr handle;
	}
}
