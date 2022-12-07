using System;

namespace FMOD
{
	// Token: 0x02000045 RID: 69
	internal interface IChannelControl
	{
		// Token: 0x0600018B RID: 395
		RESULT getSystemObject(out System system);

		// Token: 0x0600018C RID: 396
		RESULT stop();

		// Token: 0x0600018D RID: 397
		RESULT setPaused(bool paused);

		// Token: 0x0600018E RID: 398
		RESULT getPaused(out bool paused);

		// Token: 0x0600018F RID: 399
		RESULT setVolume(float volume);

		// Token: 0x06000190 RID: 400
		RESULT getVolume(out float volume);

		// Token: 0x06000191 RID: 401
		RESULT setVolumeRamp(bool ramp);

		// Token: 0x06000192 RID: 402
		RESULT getVolumeRamp(out bool ramp);

		// Token: 0x06000193 RID: 403
		RESULT getAudibility(out float audibility);

		// Token: 0x06000194 RID: 404
		RESULT setPitch(float pitch);

		// Token: 0x06000195 RID: 405
		RESULT getPitch(out float pitch);

		// Token: 0x06000196 RID: 406
		RESULT setMute(bool mute);

		// Token: 0x06000197 RID: 407
		RESULT getMute(out bool mute);

		// Token: 0x06000198 RID: 408
		RESULT setReverbProperties(int instance, float wet);

		// Token: 0x06000199 RID: 409
		RESULT getReverbProperties(int instance, out float wet);

		// Token: 0x0600019A RID: 410
		RESULT setLowPassGain(float gain);

		// Token: 0x0600019B RID: 411
		RESULT getLowPassGain(out float gain);

		// Token: 0x0600019C RID: 412
		RESULT setMode(MODE mode);

		// Token: 0x0600019D RID: 413
		RESULT getMode(out MODE mode);

		// Token: 0x0600019E RID: 414
		RESULT setCallback(CHANNELCONTROL_CALLBACK callback);

		// Token: 0x0600019F RID: 415
		RESULT isPlaying(out bool isplaying);

		// Token: 0x060001A0 RID: 416
		RESULT setPan(float pan);

		// Token: 0x060001A1 RID: 417
		RESULT setMixLevelsOutput(float frontleft, float frontright, float center, float lfe, float surroundleft, float surroundright, float backleft, float backright);

		// Token: 0x060001A2 RID: 418
		RESULT setMixLevelsInput(float[] levels, int numlevels);

		// Token: 0x060001A3 RID: 419
		RESULT setMixMatrix(float[] matrix, int outchannels, int inchannels, int inchannel_hop);

		// Token: 0x060001A4 RID: 420
		RESULT getMixMatrix(float[] matrix, out int outchannels, out int inchannels, int inchannel_hop);

		// Token: 0x060001A5 RID: 421
		RESULT getDSPClock(out ulong dspclock, out ulong parentclock);

		// Token: 0x060001A6 RID: 422
		RESULT setDelay(ulong dspclock_start, ulong dspclock_end, bool stopchannels);

		// Token: 0x060001A7 RID: 423
		RESULT getDelay(out ulong dspclock_start, out ulong dspclock_end);

		// Token: 0x060001A8 RID: 424
		RESULT getDelay(out ulong dspclock_start, out ulong dspclock_end, out bool stopchannels);

		// Token: 0x060001A9 RID: 425
		RESULT addFadePoint(ulong dspclock, float volume);

		// Token: 0x060001AA RID: 426
		RESULT setFadePointRamp(ulong dspclock, float volume);

		// Token: 0x060001AB RID: 427
		RESULT removeFadePoints(ulong dspclock_start, ulong dspclock_end);

		// Token: 0x060001AC RID: 428
		RESULT getFadePoints(ref uint numpoints, ulong[] point_dspclock, float[] point_volume);

		// Token: 0x060001AD RID: 429
		RESULT getDSP(int index, out DSP dsp);

		// Token: 0x060001AE RID: 430
		RESULT addDSP(int index, DSP dsp);

		// Token: 0x060001AF RID: 431
		RESULT removeDSP(DSP dsp);

		// Token: 0x060001B0 RID: 432
		RESULT getNumDSPs(out int numdsps);

		// Token: 0x060001B1 RID: 433
		RESULT setDSPIndex(DSP dsp, int index);

		// Token: 0x060001B2 RID: 434
		RESULT getDSPIndex(DSP dsp, out int index);

		// Token: 0x060001B3 RID: 435
		RESULT set3DAttributes(ref VECTOR pos, ref VECTOR vel);

		// Token: 0x060001B4 RID: 436
		RESULT get3DAttributes(out VECTOR pos, out VECTOR vel);

		// Token: 0x060001B5 RID: 437
		RESULT set3DMinMaxDistance(float mindistance, float maxdistance);

		// Token: 0x060001B6 RID: 438
		RESULT get3DMinMaxDistance(out float mindistance, out float maxdistance);

		// Token: 0x060001B7 RID: 439
		RESULT set3DConeSettings(float insideconeangle, float outsideconeangle, float outsidevolume);

		// Token: 0x060001B8 RID: 440
		RESULT get3DConeSettings(out float insideconeangle, out float outsideconeangle, out float outsidevolume);

		// Token: 0x060001B9 RID: 441
		RESULT set3DConeOrientation(ref VECTOR orientation);

		// Token: 0x060001BA RID: 442
		RESULT get3DConeOrientation(out VECTOR orientation);

		// Token: 0x060001BB RID: 443
		RESULT set3DCustomRolloff(ref VECTOR points, int numpoints);

		// Token: 0x060001BC RID: 444
		RESULT get3DCustomRolloff(out IntPtr points, out int numpoints);

		// Token: 0x060001BD RID: 445
		RESULT set3DOcclusion(float directocclusion, float reverbocclusion);

		// Token: 0x060001BE RID: 446
		RESULT get3DOcclusion(out float directocclusion, out float reverbocclusion);

		// Token: 0x060001BF RID: 447
		RESULT set3DSpread(float angle);

		// Token: 0x060001C0 RID: 448
		RESULT get3DSpread(out float angle);

		// Token: 0x060001C1 RID: 449
		RESULT set3DLevel(float level);

		// Token: 0x060001C2 RID: 450
		RESULT get3DLevel(out float level);

		// Token: 0x060001C3 RID: 451
		RESULT set3DDopplerLevel(float level);

		// Token: 0x060001C4 RID: 452
		RESULT get3DDopplerLevel(out float level);

		// Token: 0x060001C5 RID: 453
		RESULT set3DDistanceFilter(bool custom, float customLevel, float centerFreq);

		// Token: 0x060001C6 RID: 454
		RESULT get3DDistanceFilter(out bool custom, out float customLevel, out float centerFreq);

		// Token: 0x060001C7 RID: 455
		RESULT setUserData(IntPtr userdata);

		// Token: 0x060001C8 RID: 456
		RESULT getUserData(out IntPtr userdata);
	}
}
