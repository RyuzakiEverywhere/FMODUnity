using System;
using System.Runtime.InteropServices;

namespace FMOD
{
	// Token: 0x02000044 RID: 68
	public struct Sound
	{
		// Token: 0x06000131 RID: 305 RVA: 0x000032F8 File Offset: 0x000014F8
		public RESULT release()
		{
			return Sound.FMOD5_Sound_Release(this.handle);
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00003305 File Offset: 0x00001505
		public RESULT getSystemObject(out System system)
		{
			return Sound.FMOD5_Sound_GetSystemObject(this.handle, out system.handle);
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00003318 File Offset: 0x00001518
		public RESULT @lock(uint offset, uint length, out IntPtr ptr1, out IntPtr ptr2, out uint len1, out uint len2)
		{
			return Sound.FMOD5_Sound_Lock(this.handle, offset, length, out ptr1, out ptr2, out len1, out len2);
		}

		// Token: 0x06000134 RID: 308 RVA: 0x0000332E File Offset: 0x0000152E
		public RESULT unlock(IntPtr ptr1, IntPtr ptr2, uint len1, uint len2)
		{
			return Sound.FMOD5_Sound_Unlock(this.handle, ptr1, ptr2, len1, len2);
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00003340 File Offset: 0x00001540
		public RESULT setDefaults(float frequency, int priority)
		{
			return Sound.FMOD5_Sound_SetDefaults(this.handle, frequency, priority);
		}

		// Token: 0x06000136 RID: 310 RVA: 0x0000334F File Offset: 0x0000154F
		public RESULT getDefaults(out float frequency, out int priority)
		{
			return Sound.FMOD5_Sound_GetDefaults(this.handle, out frequency, out priority);
		}

		// Token: 0x06000137 RID: 311 RVA: 0x0000335E File Offset: 0x0000155E
		public RESULT set3DMinMaxDistance(float min, float max)
		{
			return Sound.FMOD5_Sound_Set3DMinMaxDistance(this.handle, min, max);
		}

		// Token: 0x06000138 RID: 312 RVA: 0x0000336D File Offset: 0x0000156D
		public RESULT get3DMinMaxDistance(out float min, out float max)
		{
			return Sound.FMOD5_Sound_Get3DMinMaxDistance(this.handle, out min, out max);
		}

		// Token: 0x06000139 RID: 313 RVA: 0x0000337C File Offset: 0x0000157C
		public RESULT set3DConeSettings(float insideconeangle, float outsideconeangle, float outsidevolume)
		{
			return Sound.FMOD5_Sound_Set3DConeSettings(this.handle, insideconeangle, outsideconeangle, outsidevolume);
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0000338C File Offset: 0x0000158C
		public RESULT get3DConeSettings(out float insideconeangle, out float outsideconeangle, out float outsidevolume)
		{
			return Sound.FMOD5_Sound_Get3DConeSettings(this.handle, out insideconeangle, out outsideconeangle, out outsidevolume);
		}

		// Token: 0x0600013B RID: 315 RVA: 0x0000339C File Offset: 0x0000159C
		public RESULT set3DCustomRolloff(ref VECTOR points, int numpoints)
		{
			return Sound.FMOD5_Sound_Set3DCustomRolloff(this.handle, ref points, numpoints);
		}

		// Token: 0x0600013C RID: 316 RVA: 0x000033AB File Offset: 0x000015AB
		public RESULT get3DCustomRolloff(out IntPtr points, out int numpoints)
		{
			return Sound.FMOD5_Sound_Get3DCustomRolloff(this.handle, out points, out numpoints);
		}

		// Token: 0x0600013D RID: 317 RVA: 0x000033BA File Offset: 0x000015BA
		public RESULT getSubSound(int index, out Sound subsound)
		{
			return Sound.FMOD5_Sound_GetSubSound(this.handle, index, out subsound.handle);
		}

		// Token: 0x0600013E RID: 318 RVA: 0x000033CE File Offset: 0x000015CE
		public RESULT getSubSoundParent(out Sound parentsound)
		{
			return Sound.FMOD5_Sound_GetSubSoundParent(this.handle, out parentsound.handle);
		}

		// Token: 0x0600013F RID: 319 RVA: 0x000033E4 File Offset: 0x000015E4
		public RESULT getName(out string name, int namelen)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(namelen);
			RESULT result = Sound.FMOD5_Sound_GetName(this.handle, intPtr, namelen);
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				name = freeHelper.stringFromNative(intPtr);
			}
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00003438 File Offset: 0x00001638
		public RESULT getLength(out uint length, TIMEUNIT lengthtype)
		{
			return Sound.FMOD5_Sound_GetLength(this.handle, out length, lengthtype);
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00003447 File Offset: 0x00001647
		public RESULT getFormat(out SOUND_TYPE type, out SOUND_FORMAT format, out int channels, out int bits)
		{
			return Sound.FMOD5_Sound_GetFormat(this.handle, out type, out format, out channels, out bits);
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00003459 File Offset: 0x00001659
		public RESULT getNumSubSounds(out int numsubsounds)
		{
			return Sound.FMOD5_Sound_GetNumSubSounds(this.handle, out numsubsounds);
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00003467 File Offset: 0x00001667
		public RESULT getNumTags(out int numtags, out int numtagsupdated)
		{
			return Sound.FMOD5_Sound_GetNumTags(this.handle, out numtags, out numtagsupdated);
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00003478 File Offset: 0x00001678
		public RESULT getTag(string name, int index, out TAG tag)
		{
			RESULT result;
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				result = Sound.FMOD5_Sound_GetTag(this.handle, freeHelper.byteFromStringUTF8(name), index, out tag);
			}
			return result;
		}

		// Token: 0x06000145 RID: 325 RVA: 0x000034C0 File Offset: 0x000016C0
		public RESULT getOpenState(out OPENSTATE openstate, out uint percentbuffered, out bool starving, out bool diskbusy)
		{
			return Sound.FMOD5_Sound_GetOpenState(this.handle, out openstate, out percentbuffered, out starving, out diskbusy);
		}

		// Token: 0x06000146 RID: 326 RVA: 0x000034D2 File Offset: 0x000016D2
		public RESULT readData(IntPtr buffer, uint length, out uint read)
		{
			return Sound.FMOD5_Sound_ReadData(this.handle, buffer, length, out read);
		}

		// Token: 0x06000147 RID: 327 RVA: 0x000034E2 File Offset: 0x000016E2
		public RESULT seekData(uint pcm)
		{
			return Sound.FMOD5_Sound_SeekData(this.handle, pcm);
		}

		// Token: 0x06000148 RID: 328 RVA: 0x000034F0 File Offset: 0x000016F0
		public RESULT setSoundGroup(SoundGroup soundgroup)
		{
			return Sound.FMOD5_Sound_SetSoundGroup(this.handle, soundgroup.handle);
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00003503 File Offset: 0x00001703
		public RESULT getSoundGroup(out SoundGroup soundgroup)
		{
			return Sound.FMOD5_Sound_GetSoundGroup(this.handle, out soundgroup.handle);
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00003516 File Offset: 0x00001716
		public RESULT getNumSyncPoints(out int numsyncpoints)
		{
			return Sound.FMOD5_Sound_GetNumSyncPoints(this.handle, out numsyncpoints);
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00003524 File Offset: 0x00001724
		public RESULT getSyncPoint(int index, out IntPtr point)
		{
			return Sound.FMOD5_Sound_GetSyncPoint(this.handle, index, out point);
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00003534 File Offset: 0x00001734
		public RESULT getSyncPointInfo(IntPtr point, out string name, int namelen, out uint offset, TIMEUNIT offsettype)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(namelen);
			RESULT result = Sound.FMOD5_Sound_GetSyncPointInfo(this.handle, point, intPtr, namelen, out offset, offsettype);
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				name = freeHelper.stringFromNative(intPtr);
			}
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00003590 File Offset: 0x00001790
		public RESULT getSyncPointInfo(IntPtr point, out uint offset, TIMEUNIT offsettype)
		{
			return Sound.FMOD5_Sound_GetSyncPointInfo(this.handle, point, IntPtr.Zero, 0, out offset, offsettype);
		}

		// Token: 0x0600014E RID: 334 RVA: 0x000035A8 File Offset: 0x000017A8
		public RESULT addSyncPoint(uint offset, TIMEUNIT offsettype, string name, out IntPtr point)
		{
			RESULT result;
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				result = Sound.FMOD5_Sound_AddSyncPoint(this.handle, offset, offsettype, freeHelper.byteFromStringUTF8(name), out point);
			}
			return result;
		}

		// Token: 0x0600014F RID: 335 RVA: 0x000035F0 File Offset: 0x000017F0
		public RESULT deleteSyncPoint(IntPtr point)
		{
			return Sound.FMOD5_Sound_DeleteSyncPoint(this.handle, point);
		}

		// Token: 0x06000150 RID: 336 RVA: 0x000035FE File Offset: 0x000017FE
		public RESULT setMode(MODE mode)
		{
			return Sound.FMOD5_Sound_SetMode(this.handle, mode);
		}

		// Token: 0x06000151 RID: 337 RVA: 0x0000360C File Offset: 0x0000180C
		public RESULT getMode(out MODE mode)
		{
			return Sound.FMOD5_Sound_GetMode(this.handle, out mode);
		}

		// Token: 0x06000152 RID: 338 RVA: 0x0000361A File Offset: 0x0000181A
		public RESULT setLoopCount(int loopcount)
		{
			return Sound.FMOD5_Sound_SetLoopCount(this.handle, loopcount);
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00003628 File Offset: 0x00001828
		public RESULT getLoopCount(out int loopcount)
		{
			return Sound.FMOD5_Sound_GetLoopCount(this.handle, out loopcount);
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00003636 File Offset: 0x00001836
		public RESULT setLoopPoints(uint loopstart, TIMEUNIT loopstarttype, uint loopend, TIMEUNIT loopendtype)
		{
			return Sound.FMOD5_Sound_SetLoopPoints(this.handle, loopstart, loopstarttype, loopend, loopendtype);
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00003648 File Offset: 0x00001848
		public RESULT getLoopPoints(out uint loopstart, TIMEUNIT loopstarttype, out uint loopend, TIMEUNIT loopendtype)
		{
			return Sound.FMOD5_Sound_GetLoopPoints(this.handle, out loopstart, loopstarttype, out loopend, loopendtype);
		}

		// Token: 0x06000156 RID: 342 RVA: 0x0000365A File Offset: 0x0000185A
		public RESULT getMusicNumChannels(out int numchannels)
		{
			return Sound.FMOD5_Sound_GetMusicNumChannels(this.handle, out numchannels);
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00003668 File Offset: 0x00001868
		public RESULT setMusicChannelVolume(int channel, float volume)
		{
			return Sound.FMOD5_Sound_SetMusicChannelVolume(this.handle, channel, volume);
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00003677 File Offset: 0x00001877
		public RESULT getMusicChannelVolume(int channel, out float volume)
		{
			return Sound.FMOD5_Sound_GetMusicChannelVolume(this.handle, channel, out volume);
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00003686 File Offset: 0x00001886
		public RESULT setMusicSpeed(float speed)
		{
			return Sound.FMOD5_Sound_SetMusicSpeed(this.handle, speed);
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00003694 File Offset: 0x00001894
		public RESULT getMusicSpeed(out float speed)
		{
			return Sound.FMOD5_Sound_GetMusicSpeed(this.handle, out speed);
		}

		// Token: 0x0600015B RID: 347 RVA: 0x000036A2 File Offset: 0x000018A2
		public RESULT setUserData(IntPtr userdata)
		{
			return Sound.FMOD5_Sound_SetUserData(this.handle, userdata);
		}

		// Token: 0x0600015C RID: 348 RVA: 0x000036B0 File Offset: 0x000018B0
		public RESULT getUserData(out IntPtr userdata)
		{
			return Sound.FMOD5_Sound_GetUserData(this.handle, out userdata);
		}

		// Token: 0x0600015D RID: 349
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_Release(IntPtr sound);

		// Token: 0x0600015E RID: 350
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_GetSystemObject(IntPtr sound, out IntPtr system);

		// Token: 0x0600015F RID: 351
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_Lock(IntPtr sound, uint offset, uint length, out IntPtr ptr1, out IntPtr ptr2, out uint len1, out uint len2);

		// Token: 0x06000160 RID: 352
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_Unlock(IntPtr sound, IntPtr ptr1, IntPtr ptr2, uint len1, uint len2);

		// Token: 0x06000161 RID: 353
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_SetDefaults(IntPtr sound, float frequency, int priority);

		// Token: 0x06000162 RID: 354
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_GetDefaults(IntPtr sound, out float frequency, out int priority);

		// Token: 0x06000163 RID: 355
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_Set3DMinMaxDistance(IntPtr sound, float min, float max);

		// Token: 0x06000164 RID: 356
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_Get3DMinMaxDistance(IntPtr sound, out float min, out float max);

		// Token: 0x06000165 RID: 357
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_Set3DConeSettings(IntPtr sound, float insideconeangle, float outsideconeangle, float outsidevolume);

		// Token: 0x06000166 RID: 358
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_Get3DConeSettings(IntPtr sound, out float insideconeangle, out float outsideconeangle, out float outsidevolume);

		// Token: 0x06000167 RID: 359
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_Set3DCustomRolloff(IntPtr sound, ref VECTOR points, int numpoints);

		// Token: 0x06000168 RID: 360
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_Get3DCustomRolloff(IntPtr sound, out IntPtr points, out int numpoints);

		// Token: 0x06000169 RID: 361
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_GetSubSound(IntPtr sound, int index, out IntPtr subsound);

		// Token: 0x0600016A RID: 362
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_GetSubSoundParent(IntPtr sound, out IntPtr parentsound);

		// Token: 0x0600016B RID: 363
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_GetName(IntPtr sound, IntPtr name, int namelen);

		// Token: 0x0600016C RID: 364
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_GetLength(IntPtr sound, out uint length, TIMEUNIT lengthtype);

		// Token: 0x0600016D RID: 365
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_GetFormat(IntPtr sound, out SOUND_TYPE type, out SOUND_FORMAT format, out int channels, out int bits);

		// Token: 0x0600016E RID: 366
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_GetNumSubSounds(IntPtr sound, out int numsubsounds);

		// Token: 0x0600016F RID: 367
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_GetNumTags(IntPtr sound, out int numtags, out int numtagsupdated);

		// Token: 0x06000170 RID: 368
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_GetTag(IntPtr sound, byte[] name, int index, out TAG tag);

		// Token: 0x06000171 RID: 369
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_GetOpenState(IntPtr sound, out OPENSTATE openstate, out uint percentbuffered, out bool starving, out bool diskbusy);

		// Token: 0x06000172 RID: 370
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_ReadData(IntPtr sound, IntPtr buffer, uint length, out uint read);

		// Token: 0x06000173 RID: 371
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_SeekData(IntPtr sound, uint pcm);

		// Token: 0x06000174 RID: 372
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_SetSoundGroup(IntPtr sound, IntPtr soundgroup);

		// Token: 0x06000175 RID: 373
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_GetSoundGroup(IntPtr sound, out IntPtr soundgroup);

		// Token: 0x06000176 RID: 374
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_GetNumSyncPoints(IntPtr sound, out int numsyncpoints);

		// Token: 0x06000177 RID: 375
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_GetSyncPoint(IntPtr sound, int index, out IntPtr point);

		// Token: 0x06000178 RID: 376
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_GetSyncPointInfo(IntPtr sound, IntPtr point, IntPtr name, int namelen, out uint offset, TIMEUNIT offsettype);

		// Token: 0x06000179 RID: 377
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_AddSyncPoint(IntPtr sound, uint offset, TIMEUNIT offsettype, byte[] name, out IntPtr point);

		// Token: 0x0600017A RID: 378
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_DeleteSyncPoint(IntPtr sound, IntPtr point);

		// Token: 0x0600017B RID: 379
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_SetMode(IntPtr sound, MODE mode);

		// Token: 0x0600017C RID: 380
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_GetMode(IntPtr sound, out MODE mode);

		// Token: 0x0600017D RID: 381
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_SetLoopCount(IntPtr sound, int loopcount);

		// Token: 0x0600017E RID: 382
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_GetLoopCount(IntPtr sound, out int loopcount);

		// Token: 0x0600017F RID: 383
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_SetLoopPoints(IntPtr sound, uint loopstart, TIMEUNIT loopstarttype, uint loopend, TIMEUNIT loopendtype);

		// Token: 0x06000180 RID: 384
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_GetLoopPoints(IntPtr sound, out uint loopstart, TIMEUNIT loopstarttype, out uint loopend, TIMEUNIT loopendtype);

		// Token: 0x06000181 RID: 385
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_GetMusicNumChannels(IntPtr sound, out int numchannels);

		// Token: 0x06000182 RID: 386
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_SetMusicChannelVolume(IntPtr sound, int channel, float volume);

		// Token: 0x06000183 RID: 387
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_GetMusicChannelVolume(IntPtr sound, int channel, out float volume);

		// Token: 0x06000184 RID: 388
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_SetMusicSpeed(IntPtr sound, float speed);

		// Token: 0x06000185 RID: 389
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_GetMusicSpeed(IntPtr sound, out float speed);

		// Token: 0x06000186 RID: 390
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_SetUserData(IntPtr sound, IntPtr userdata);

		// Token: 0x06000187 RID: 391
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Sound_GetUserData(IntPtr sound, out IntPtr userdata);

		// Token: 0x06000188 RID: 392 RVA: 0x000036BE File Offset: 0x000018BE
		public Sound(IntPtr ptr)
		{
			this.handle = ptr;
		}

		// Token: 0x06000189 RID: 393 RVA: 0x000036C7 File Offset: 0x000018C7
		public bool hasHandle()
		{
			return this.handle != IntPtr.Zero;
		}

		// Token: 0x0600018A RID: 394 RVA: 0x000036D9 File Offset: 0x000018D9
		public void clearHandle()
		{
			this.handle = IntPtr.Zero;
		}

		// Token: 0x0400023F RID: 575
		public IntPtr handle;
	}
}
