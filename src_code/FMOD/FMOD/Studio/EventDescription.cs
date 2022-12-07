using System;
using System.Runtime.InteropServices;

namespace FMOD.Studio
{
	// Token: 0x020000E5 RID: 229
	public struct EventDescription
	{
		// Token: 0x060004F4 RID: 1268 RVA: 0x000056C9 File Offset: 0x000038C9
		public RESULT getID(out Guid id)
		{
			return EventDescription.FMOD_Studio_EventDescription_GetID(this.handle, out id);
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x000056D8 File Offset: 0x000038D8
		public RESULT getPath(out string path)
		{
			path = null;
			RESULT result2;
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				IntPtr intPtr = Marshal.AllocHGlobal(256);
				int num = 0;
				RESULT result = EventDescription.FMOD_Studio_EventDescription_GetPath(this.handle, intPtr, 256, out num);
				if (result == RESULT.ERR_TRUNCATED)
				{
					Marshal.FreeHGlobal(intPtr);
					intPtr = Marshal.AllocHGlobal(num);
					result = EventDescription.FMOD_Studio_EventDescription_GetPath(this.handle, intPtr, num, out num);
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

		// Token: 0x060004F6 RID: 1270 RVA: 0x00005764 File Offset: 0x00003964
		public RESULT getParameterDescriptionCount(out int count)
		{
			return EventDescription.FMOD_Studio_EventDescription_GetParameterDescriptionCount(this.handle, out count);
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x00005772 File Offset: 0x00003972
		public RESULT getParameterDescriptionByIndex(int index, out PARAMETER_DESCRIPTION parameter)
		{
			return EventDescription.FMOD_Studio_EventDescription_GetParameterDescriptionByIndex(this.handle, index, out parameter);
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x00005784 File Offset: 0x00003984
		public RESULT getParameterDescriptionByName(string name, out PARAMETER_DESCRIPTION parameter)
		{
			RESULT result;
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				result = EventDescription.FMOD_Studio_EventDescription_GetParameterDescriptionByName(this.handle, freeHelper.byteFromStringUTF8(name), out parameter);
			}
			return result;
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x000057C8 File Offset: 0x000039C8
		public RESULT getParameterDescriptionByID(PARAMETER_ID id, out PARAMETER_DESCRIPTION parameter)
		{
			return EventDescription.FMOD_Studio_EventDescription_GetParameterDescriptionByID(this.handle, id, out parameter);
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x000057D7 File Offset: 0x000039D7
		public RESULT getUserPropertyCount(out int count)
		{
			return EventDescription.FMOD_Studio_EventDescription_GetUserPropertyCount(this.handle, out count);
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x000057E5 File Offset: 0x000039E5
		public RESULT getUserPropertyByIndex(int index, out USER_PROPERTY property)
		{
			return EventDescription.FMOD_Studio_EventDescription_GetUserPropertyByIndex(this.handle, index, out property);
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x000057F4 File Offset: 0x000039F4
		public RESULT getUserProperty(string name, out USER_PROPERTY property)
		{
			RESULT result;
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				result = EventDescription.FMOD_Studio_EventDescription_GetUserProperty(this.handle, freeHelper.byteFromStringUTF8(name), out property);
			}
			return result;
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x00005838 File Offset: 0x00003A38
		public RESULT getLength(out int length)
		{
			return EventDescription.FMOD_Studio_EventDescription_GetLength(this.handle, out length);
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x00005846 File Offset: 0x00003A46
		public RESULT getMinimumDistance(out float distance)
		{
			return EventDescription.FMOD_Studio_EventDescription_GetMinimumDistance(this.handle, out distance);
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x00005854 File Offset: 0x00003A54
		public RESULT getMaximumDistance(out float distance)
		{
			return EventDescription.FMOD_Studio_EventDescription_GetMaximumDistance(this.handle, out distance);
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x00005862 File Offset: 0x00003A62
		public RESULT getSoundSize(out float size)
		{
			return EventDescription.FMOD_Studio_EventDescription_GetSoundSize(this.handle, out size);
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x00005870 File Offset: 0x00003A70
		public RESULT isSnapshot(out bool snapshot)
		{
			return EventDescription.FMOD_Studio_EventDescription_IsSnapshot(this.handle, out snapshot);
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x0000587E File Offset: 0x00003A7E
		public RESULT isOneshot(out bool oneshot)
		{
			return EventDescription.FMOD_Studio_EventDescription_IsOneshot(this.handle, out oneshot);
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x0000588C File Offset: 0x00003A8C
		public RESULT isStream(out bool isStream)
		{
			return EventDescription.FMOD_Studio_EventDescription_IsStream(this.handle, out isStream);
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x0000589A File Offset: 0x00003A9A
		public RESULT is3D(out bool is3D)
		{
			return EventDescription.FMOD_Studio_EventDescription_Is3D(this.handle, out is3D);
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x000058A8 File Offset: 0x00003AA8
		public RESULT isDopplerEnabled(out bool doppler)
		{
			return EventDescription.FMOD_Studio_EventDescription_IsDopplerEnabled(this.handle, out doppler);
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x000058B6 File Offset: 0x00003AB6
		public RESULT hasCue(out bool cue)
		{
			return EventDescription.FMOD_Studio_EventDescription_HasCue(this.handle, out cue);
		}

		// Token: 0x06000507 RID: 1287 RVA: 0x000058C4 File Offset: 0x00003AC4
		public RESULT createInstance(out EventInstance instance)
		{
			return EventDescription.FMOD_Studio_EventDescription_CreateInstance(this.handle, out instance.handle);
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x000058D7 File Offset: 0x00003AD7
		public RESULT getInstanceCount(out int count)
		{
			return EventDescription.FMOD_Studio_EventDescription_GetInstanceCount(this.handle, out count);
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x000058E8 File Offset: 0x00003AE8
		public RESULT getInstanceList(out EventInstance[] array)
		{
			array = null;
			int num;
			RESULT result = EventDescription.FMOD_Studio_EventDescription_GetInstanceCount(this.handle, out num);
			if (result != RESULT.OK)
			{
				return result;
			}
			if (num == 0)
			{
				array = new EventInstance[0];
				return result;
			}
			IntPtr[] array2 = new IntPtr[num];
			int num2;
			result = EventDescription.FMOD_Studio_EventDescription_GetInstanceList(this.handle, array2, num, out num2);
			if (result != RESULT.OK)
			{
				return result;
			}
			if (num2 > num)
			{
				num2 = num;
			}
			array = new EventInstance[num2];
			for (int i = 0; i < num2; i++)
			{
				array[i].handle = array2[i];
			}
			return RESULT.OK;
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x00005965 File Offset: 0x00003B65
		public RESULT loadSampleData()
		{
			return EventDescription.FMOD_Studio_EventDescription_LoadSampleData(this.handle);
		}

		// Token: 0x0600050B RID: 1291 RVA: 0x00005972 File Offset: 0x00003B72
		public RESULT unloadSampleData()
		{
			return EventDescription.FMOD_Studio_EventDescription_UnloadSampleData(this.handle);
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x0000597F File Offset: 0x00003B7F
		public RESULT getSampleLoadingState(out LOADING_STATE state)
		{
			return EventDescription.FMOD_Studio_EventDescription_GetSampleLoadingState(this.handle, out state);
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x0000598D File Offset: 0x00003B8D
		public RESULT releaseAllInstances()
		{
			return EventDescription.FMOD_Studio_EventDescription_ReleaseAllInstances(this.handle);
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x0000599A File Offset: 0x00003B9A
		public RESULT setCallback(EVENT_CALLBACK callback, EVENT_CALLBACK_TYPE callbackmask = EVENT_CALLBACK_TYPE.ALL)
		{
			return EventDescription.FMOD_Studio_EventDescription_SetCallback(this.handle, callback, callbackmask);
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x000059A9 File Offset: 0x00003BA9
		public RESULT getUserData(out IntPtr userdata)
		{
			return EventDescription.FMOD_Studio_EventDescription_GetUserData(this.handle, out userdata);
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x000059B7 File Offset: 0x00003BB7
		public RESULT setUserData(IntPtr userdata)
		{
			return EventDescription.FMOD_Studio_EventDescription_SetUserData(this.handle, userdata);
		}

		// Token: 0x06000511 RID: 1297
		[DllImport("fmodstudio")]
		private static extern bool FMOD_Studio_EventDescription_IsValid(IntPtr eventdescription);

		// Token: 0x06000512 RID: 1298
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventDescription_GetID(IntPtr eventdescription, out Guid id);

		// Token: 0x06000513 RID: 1299
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventDescription_GetPath(IntPtr eventdescription, IntPtr path, int size, out int retrieved);

		// Token: 0x06000514 RID: 1300
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventDescription_GetParameterDescriptionCount(IntPtr eventdescription, out int count);

		// Token: 0x06000515 RID: 1301
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventDescription_GetParameterDescriptionByIndex(IntPtr eventdescription, int index, out PARAMETER_DESCRIPTION parameter);

		// Token: 0x06000516 RID: 1302
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventDescription_GetParameterDescriptionByName(IntPtr eventdescription, byte[] name, out PARAMETER_DESCRIPTION parameter);

		// Token: 0x06000517 RID: 1303
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventDescription_GetParameterDescriptionByID(IntPtr eventdescription, PARAMETER_ID id, out PARAMETER_DESCRIPTION parameter);

		// Token: 0x06000518 RID: 1304
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventDescription_GetUserPropertyCount(IntPtr eventdescription, out int count);

		// Token: 0x06000519 RID: 1305
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventDescription_GetUserPropertyByIndex(IntPtr eventdescription, int index, out USER_PROPERTY property);

		// Token: 0x0600051A RID: 1306
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventDescription_GetUserProperty(IntPtr eventdescription, byte[] name, out USER_PROPERTY property);

		// Token: 0x0600051B RID: 1307
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventDescription_GetLength(IntPtr eventdescription, out int length);

		// Token: 0x0600051C RID: 1308
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventDescription_GetMinimumDistance(IntPtr eventdescription, out float distance);

		// Token: 0x0600051D RID: 1309
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventDescription_GetMaximumDistance(IntPtr eventdescription, out float distance);

		// Token: 0x0600051E RID: 1310
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventDescription_GetSoundSize(IntPtr eventdescription, out float size);

		// Token: 0x0600051F RID: 1311
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventDescription_IsSnapshot(IntPtr eventdescription, out bool snapshot);

		// Token: 0x06000520 RID: 1312
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventDescription_IsOneshot(IntPtr eventdescription, out bool oneshot);

		// Token: 0x06000521 RID: 1313
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventDescription_IsStream(IntPtr eventdescription, out bool isStream);

		// Token: 0x06000522 RID: 1314
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventDescription_Is3D(IntPtr eventdescription, out bool is3D);

		// Token: 0x06000523 RID: 1315
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventDescription_IsDopplerEnabled(IntPtr eventdescription, out bool doppler);

		// Token: 0x06000524 RID: 1316
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventDescription_HasCue(IntPtr eventdescription, out bool cue);

		// Token: 0x06000525 RID: 1317
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventDescription_CreateInstance(IntPtr eventdescription, out IntPtr instance);

		// Token: 0x06000526 RID: 1318
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventDescription_GetInstanceCount(IntPtr eventdescription, out int count);

		// Token: 0x06000527 RID: 1319
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventDescription_GetInstanceList(IntPtr eventdescription, IntPtr[] array, int capacity, out int count);

		// Token: 0x06000528 RID: 1320
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventDescription_LoadSampleData(IntPtr eventdescription);

		// Token: 0x06000529 RID: 1321
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventDescription_UnloadSampleData(IntPtr eventdescription);

		// Token: 0x0600052A RID: 1322
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventDescription_GetSampleLoadingState(IntPtr eventdescription, out LOADING_STATE state);

		// Token: 0x0600052B RID: 1323
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventDescription_ReleaseAllInstances(IntPtr eventdescription);

		// Token: 0x0600052C RID: 1324
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventDescription_SetCallback(IntPtr eventdescription, EVENT_CALLBACK callback, EVENT_CALLBACK_TYPE callbackmask);

		// Token: 0x0600052D RID: 1325
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventDescription_GetUserData(IntPtr eventdescription, out IntPtr userdata);

		// Token: 0x0600052E RID: 1326
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_EventDescription_SetUserData(IntPtr eventdescription, IntPtr userdata);

		// Token: 0x0600052F RID: 1327 RVA: 0x000059C5 File Offset: 0x00003BC5
		public EventDescription(IntPtr ptr)
		{
			this.handle = ptr;
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x000059CE File Offset: 0x00003BCE
		public bool hasHandle()
		{
			return this.handle != IntPtr.Zero;
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x000059E0 File Offset: 0x00003BE0
		public void clearHandle()
		{
			this.handle = IntPtr.Zero;
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x000059ED File Offset: 0x00003BED
		public bool isValid()
		{
			return this.hasHandle() && EventDescription.FMOD_Studio_EventDescription_IsValid(this.handle);
		}

		// Token: 0x040004F5 RID: 1269
		public IntPtr handle;
	}
}
