using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace FMOD.Studio
{
	// Token: 0x020000E6 RID: 230
	public struct EventInstance
	{
		// Token: 0x06000533 RID: 1331 RVA: 0x00005A04 File Offset: 0x00003C04
		public override string ToString()
		{
			EventDescription eventDescription;
			string str;
			if (this.getDescription(out eventDescription) == RESULT.OK && eventDescription.getPath(out str) == RESULT.OK)
			{
				return "Event: " + str;
			}
			return base.ToString();
		}

		// Token: 0x06000534 RID: 1332 RVA: 0x00005A42 File Offset: 0x00003C42
		public RESULT getDescription(out EventDescription description)
		{
			return EventInstance.FMOD_Studio_EventInstance_GetDescription(this.handle, out description.handle);
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x00005A55 File Offset: 0x00003C55
		public RESULT getVolume(out float volume)
		{
			return EventInstance.FMOD_Studio_EventInstance_GetVolume(this.handle, out volume, IntPtr.Zero);
		}

		// Token: 0x06000536 RID: 1334 RVA: 0x00005A68 File Offset: 0x00003C68
		public RESULT getVolume(out float volume, out float finalvolume)
		{
			return EventInstance.FMOD_Studio_EventInstance_GetVolume(this.handle, out volume, out finalvolume);
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x00005A77 File Offset: 0x00003C77
		public RESULT setVolume(float volume)
		{
			return EventInstance.FMOD_Studio_EventInstance_SetVolume(this.handle, volume);
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x00005A85 File Offset: 0x00003C85
		public RESULT getPitch(out float pitch)
		{
			return EventInstance.FMOD_Studio_EventInstance_GetPitch(this.handle, out pitch, IntPtr.Zero);
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x00005A98 File Offset: 0x00003C98
		public RESULT getPitch(out float pitch, out float finalpitch)
		{
			return EventInstance.FMOD_Studio_EventInstance_GetPitch(this.handle, out pitch, out finalpitch);
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x00005AA7 File Offset: 0x00003CA7
		public RESULT setPitch(float pitch)
		{
			return EventInstance.FMOD_Studio_EventInstance_SetPitch(this.handle, pitch);
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x00005AB5 File Offset: 0x00003CB5
		public RESULT get3DAttributes(out ATTRIBUTES_3D attributes)
		{
			return EventInstance.FMOD_Studio_EventInstance_Get3DAttributes(this.handle, out attributes);
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x00005AC3 File Offset: 0x00003CC3
		public RESULT set3DAttributes(ATTRIBUTES_3D attributes)
		{
			return EventInstance.FMOD_Studio_EventInstance_Set3DAttributes(this.handle, ref attributes);
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x00005AD2 File Offset: 0x00003CD2
		public RESULT getListenerMask(out uint mask)
		{
			return EventInstance.FMOD_Studio_EventInstance_GetListenerMask(this.handle, out mask);
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x00005AE0 File Offset: 0x00003CE0
		public RESULT setListenerMask(uint mask)
		{
			return EventInstance.FMOD_Studio_EventInstance_SetListenerMask(this.handle, mask);
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x00005AEE File Offset: 0x00003CEE
		public RESULT getProperty(EVENT_PROPERTY index, out float value)
		{
			return EventInstance.FMOD_Studio_EventInstance_GetProperty(this.handle, index, out value);
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x00005AFD File Offset: 0x00003CFD
		public RESULT setProperty(EVENT_PROPERTY index, float value)
		{
			return EventInstance.FMOD_Studio_EventInstance_SetProperty(this.handle, index, value);
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x00005B0C File Offset: 0x00003D0C
		public RESULT getReverbLevel(int index, out float level)
		{
			return EventInstance.FMOD_Studio_EventInstance_GetReverbLevel(this.handle, index, out level);
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x00005B1B File Offset: 0x00003D1B
		public RESULT setReverbLevel(int index, float level)
		{
			return EventInstance.FMOD_Studio_EventInstance_SetReverbLevel(this.handle, index, level);
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x00005B2A File Offset: 0x00003D2A
		public RESULT getPaused(out bool paused)
		{
			return EventInstance.FMOD_Studio_EventInstance_GetPaused(this.handle, out paused);
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x00005B38 File Offset: 0x00003D38
		public RESULT setPaused(bool paused)
		{
			return EventInstance.FMOD_Studio_EventInstance_SetPaused(this.handle, paused);
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x00005B46 File Offset: 0x00003D46
		public RESULT start()
		{
			if (EventInstance.LogEvents)
			{
				Debug.Log(string.Format("Starting {0}", this));
			}
			return EventInstance.FMOD_Studio_EventInstance_Start(this.handle);
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x00005B74 File Offset: 0x00003D74
		public RESULT stop(STOP_MODE mode)
		{
			if (EventInstance.LogEvents)
			{
				Debug.Log(string.Format("Stopping {0}", this));
			}
			return EventInstance.FMOD_Studio_EventInstance_Stop(this.handle, mode);
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x00005BA3 File Offset: 0x00003DA3
		public RESULT getTimelinePosition(out int position)
		{
			return EventInstance.FMOD_Studio_EventInstance_GetTimelinePosition(this.handle, out position);
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x00005BB1 File Offset: 0x00003DB1
		public RESULT setTimelinePosition(int position)
		{
			return EventInstance.FMOD_Studio_EventInstance_SetTimelinePosition(this.handle, position);
		}

		// Token: 0x06000549 RID: 1353 RVA: 0x00005BBF File Offset: 0x00003DBF
		public RESULT getPlaybackState(out PLAYBACK_STATE state)
		{
			return EventInstance.FMOD_Studio_EventInstance_GetPlaybackState(this.handle, out state);
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x00005BCD File Offset: 0x00003DCD
		public RESULT getChannelGroup(out ChannelGroup group)
		{
			return EventInstance.FMOD_Studio_EventInstance_GetChannelGroup(this.handle, out group.handle);
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x00005BE0 File Offset: 0x00003DE0
		public RESULT release()
		{
			if (EventInstance.LogEvents)
			{
				Debug.Log(string.Format("Releasing {0}", this));
			}
			return EventInstance.FMOD_Studio_EventInstance_Release(this.handle);
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x00005C0E File Offset: 0x00003E0E
		public RESULT isVirtual(out bool virtualstate)
		{
			return EventInstance.FMOD_Studio_EventInstance_IsVirtual(this.handle, out virtualstate);
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x00005C1C File Offset: 0x00003E1C
		public RESULT getParameterByID(PARAMETER_ID id, out float value)
		{
			float num;
			return this.getParameterByID(id, out value, out num);
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x00005C33 File Offset: 0x00003E33
		public RESULT getParameterByID(PARAMETER_ID id, out float value, out float finalvalue)
		{
			return EventInstance.FMOD_Studio_EventInstance_GetParameterByID(this.handle, id, out value, out finalvalue);
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x00005C43 File Offset: 0x00003E43
		public RESULT setParameterByID(PARAMETER_ID id, float value, bool ignoreseekspeed = false)
		{
			return EventInstance.FMOD_Studio_EventInstance_SetParameterByID(this.handle, id, value, ignoreseekspeed);
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x00005C53 File Offset: 0x00003E53
		public RESULT setParametersByIDs(PARAMETER_ID[] ids, float[] values, int count, bool ignoreseekspeed = false)
		{
			return EventInstance.FMOD_Studio_EventInstance_SetParametersByIDs(this.handle, ids, values, count, ignoreseekspeed);
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x00005C68 File Offset: 0x00003E68
		public RESULT getParameterByName(string name, out float value)
		{
			float num;
			return this.getParameterByName(name, out value, out num);
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x00005C80 File Offset: 0x00003E80
		public RESULT getParameterByName(string name, out float value, out float finalvalue)
		{
			RESULT result;
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				result = EventInstance.FMOD_Studio_EventInstance_GetParameterByName(this.handle, freeHelper.byteFromStringUTF8(name), out value, out finalvalue);
			}
			return result;
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x00005CC8 File Offset: 0x00003EC8
		public RESULT setParameterByName(string name, float value, bool ignoreseekspeed = false)
		{
			RESULT result;
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				result = EventInstance.FMOD_Studio_EventInstance_SetParameterByName(this.handle, freeHelper.byteFromStringUTF8(name), value, ignoreseekspeed);
			}
			return result;
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x00005D10 File Offset: 0x00003F10
		public RESULT triggerCue()
		{
			return EventInstance.FMOD_Studio_EventInstance_TriggerCue(this.handle);
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x00005D1D File Offset: 0x00003F1D
		public RESULT setCallback(EVENT_CALLBACK callback, EVENT_CALLBACK_TYPE callbackmask = EVENT_CALLBACK_TYPE.ALL)
		{
			return EventInstance.FMOD_Studio_EventInstance_SetCallback(this.handle, callback, callbackmask);
		}

		// Token: 0x06000556 RID: 1366 RVA: 0x00005D2C File Offset: 0x00003F2C
		public RESULT getUserData(out IntPtr userdata)
		{
			return EventInstance.FMOD_Studio_EventInstance_GetUserData(this.handle, out userdata);
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x00005D3A File Offset: 0x00003F3A
		public RESULT setUserData(IntPtr userdata)
		{
			return EventInstance.FMOD_Studio_EventInstance_SetUserData(this.handle, userdata);
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x00005D48 File Offset: 0x00003F48
		public RESULT getCPUUsage(out uint exclusive, out uint inclusive)
		{
			return EventInstance.FMOD_Studio_EventInstance_GetCPUUsage(this.handle, out exclusive, out inclusive);
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x00005D57 File Offset: 0x00003F57
		public RESULT getMemoryUsage(out MEMORY_USAGE memoryusage)
		{
			return EventInstance.FMOD_Studio_EventInstance_GetMemoryUsage(this.handle, out memoryusage);
		}

		// Token: 0x0600055A RID: 1370
		[DllImport("fmodstudio")]
		private static extern bool FMOD_Studio_EventInstance_IsValid(IntPtr _event);

		// Token: 0x0600055B RID: 1371
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_GetDescription(IntPtr _event, out IntPtr description);

		// Token: 0x0600055C RID: 1372
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_GetVolume(IntPtr _event, out float volume, IntPtr zero);

		// Token: 0x0600055D RID: 1373
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_GetVolume(IntPtr _event, out float volume, out float finalvolume);

		// Token: 0x0600055E RID: 1374
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_SetVolume(IntPtr _event, float volume);

		// Token: 0x0600055F RID: 1375
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_GetPitch(IntPtr _event, out float pitch, IntPtr zero);

		// Token: 0x06000560 RID: 1376
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_GetPitch(IntPtr _event, out float pitch, out float finalpitch);

		// Token: 0x06000561 RID: 1377
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_SetPitch(IntPtr _event, float pitch);

		// Token: 0x06000562 RID: 1378
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_Get3DAttributes(IntPtr _event, out ATTRIBUTES_3D attributes);

		// Token: 0x06000563 RID: 1379
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_Set3DAttributes(IntPtr _event, ref ATTRIBUTES_3D attributes);

		// Token: 0x06000564 RID: 1380
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_GetListenerMask(IntPtr _event, out uint mask);

		// Token: 0x06000565 RID: 1381
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_SetListenerMask(IntPtr _event, uint mask);

		// Token: 0x06000566 RID: 1382
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_GetProperty(IntPtr _event, EVENT_PROPERTY index, out float value);

		// Token: 0x06000567 RID: 1383
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_SetProperty(IntPtr _event, EVENT_PROPERTY index, float value);

		// Token: 0x06000568 RID: 1384
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_GetReverbLevel(IntPtr _event, int index, out float level);

		// Token: 0x06000569 RID: 1385
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_SetReverbLevel(IntPtr _event, int index, float level);

		// Token: 0x0600056A RID: 1386
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_GetPaused(IntPtr _event, out bool paused);

		// Token: 0x0600056B RID: 1387
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_SetPaused(IntPtr _event, bool paused);

		// Token: 0x0600056C RID: 1388
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_Start(IntPtr _event);

		// Token: 0x0600056D RID: 1389
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_Stop(IntPtr _event, STOP_MODE mode);

		// Token: 0x0600056E RID: 1390
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_GetTimelinePosition(IntPtr _event, out int position);

		// Token: 0x0600056F RID: 1391
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_SetTimelinePosition(IntPtr _event, int position);

		// Token: 0x06000570 RID: 1392
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_GetPlaybackState(IntPtr _event, out PLAYBACK_STATE state);

		// Token: 0x06000571 RID: 1393
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_GetChannelGroup(IntPtr _event, out IntPtr group);

		// Token: 0x06000572 RID: 1394
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_Release(IntPtr _event);

		// Token: 0x06000573 RID: 1395
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_IsVirtual(IntPtr _event, out bool virtualstate);

		// Token: 0x06000574 RID: 1396
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_GetParameterByName(IntPtr _event, byte[] name, out float value, out float finalvalue);

		// Token: 0x06000575 RID: 1397
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_SetParameterByName(IntPtr _event, byte[] name, float value, bool ignoreseekspeed);

		// Token: 0x06000576 RID: 1398
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_GetParameterByID(IntPtr _event, PARAMETER_ID id, out float value, out float finalvalue);

		// Token: 0x06000577 RID: 1399
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_SetParameterByID(IntPtr _event, PARAMETER_ID id, float value, bool ignoreseekspeed);

		// Token: 0x06000578 RID: 1400
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_SetParametersByIDs(IntPtr _event, PARAMETER_ID[] ids, float[] values, int count, bool ignoreseekspeed);

		// Token: 0x06000579 RID: 1401
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_TriggerCue(IntPtr _event);

		// Token: 0x0600057A RID: 1402
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_SetCallback(IntPtr _event, EVENT_CALLBACK callback, EVENT_CALLBACK_TYPE callbackmask);

		// Token: 0x0600057B RID: 1403
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_GetUserData(IntPtr _event, out IntPtr userdata);

		// Token: 0x0600057C RID: 1404
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_SetUserData(IntPtr _event, IntPtr userdata);

		// Token: 0x0600057D RID: 1405
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_GetCPUUsage(IntPtr _event, out uint exclusive, out uint inclusive);

		// Token: 0x0600057E RID: 1406
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventInstance_GetMemoryUsage(IntPtr _event, out MEMORY_USAGE memoryusage);

		// Token: 0x0600057F RID: 1407 RVA: 0x00005D65 File Offset: 0x00003F65
		public EventInstance(IntPtr ptr)
		{
			this.handle = ptr;
		}

		// Token: 0x06000580 RID: 1408 RVA: 0x00005D6E File Offset: 0x00003F6E
		public bool hasHandle()
		{
			return this.handle != IntPtr.Zero;
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x00005D80 File Offset: 0x00003F80
		public void clearHandle()
		{
			this.handle = IntPtr.Zero;
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x00005D8D File Offset: 0x00003F8D
		public bool isValid()
		{
			return this.hasHandle() && EventInstance.FMOD_Studio_EventInstance_IsValid(this.handle);
		}

		// Token: 0x040004F6 RID: 1270
		public static bool LogEvents;

		// Token: 0x040004F7 RID: 1271
		public IntPtr handle;
	}
}
