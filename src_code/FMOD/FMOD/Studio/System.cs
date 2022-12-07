using System;
using System.Runtime.InteropServices;

namespace FMOD.Studio
{
	// Token: 0x020000E4 RID: 228
	public struct System
	{
		// Token: 0x06000482 RID: 1154 RVA: 0x00004E54 File Offset: 0x00003054
		public static RESULT create(out System system)
		{
			return System.FMOD_Studio_System_Create(out system.handle, 131345U);
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x00004E66 File Offset: 0x00003066
		public RESULT setAdvancedSettings(ADVANCEDSETTINGS settings)
		{
			settings.cbsize = MarshalHelper.SizeOf(typeof(ADVANCEDSETTINGS));
			return System.FMOD_Studio_System_SetAdvancedSettings(this.handle, ref settings);
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x00004E8C File Offset: 0x0000308C
		public RESULT setAdvancedSettings(ADVANCEDSETTINGS settings, string encryptionKey)
		{
			RESULT result2;
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				IntPtr encryptionkey = settings.encryptionkey;
				settings.encryptionkey = freeHelper.intptrFromStringUTF8(encryptionKey);
				RESULT result = this.setAdvancedSettings(settings);
				settings.encryptionkey = encryptionkey;
				result2 = result;
			}
			return result2;
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x00004EE4 File Offset: 0x000030E4
		public RESULT getAdvancedSettings(out ADVANCEDSETTINGS settings)
		{
			settings.cbsize = MarshalHelper.SizeOf(typeof(ADVANCEDSETTINGS));
			return System.FMOD_Studio_System_GetAdvancedSettings(this.handle, out settings);
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x00004F07 File Offset: 0x00003107
		public RESULT initialize(int maxchannels, INITFLAGS studioflags, INITFLAGS flags, IntPtr extradriverdata)
		{
			return System.FMOD_Studio_System_Initialize(this.handle, maxchannels, studioflags, flags, extradriverdata);
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x00004F19 File Offset: 0x00003119
		public RESULT release()
		{
			return System.FMOD_Studio_System_Release(this.handle);
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x00004F26 File Offset: 0x00003126
		public RESULT update()
		{
			return System.FMOD_Studio_System_Update(this.handle);
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x00004F33 File Offset: 0x00003133
		public RESULT getCoreSystem(out System coresystem)
		{
			return System.FMOD_Studio_System_GetCoreSystem(this.handle, out coresystem.handle);
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x00004F48 File Offset: 0x00003148
		public RESULT getEvent(string path, out EventDescription _event)
		{
			RESULT result;
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				result = System.FMOD_Studio_System_GetEvent(this.handle, freeHelper.byteFromStringUTF8(path), out _event.handle);
			}
			return result;
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x00004F94 File Offset: 0x00003194
		public RESULT getBus(string path, out Bus bus)
		{
			RESULT result;
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				result = System.FMOD_Studio_System_GetBus(this.handle, freeHelper.byteFromStringUTF8(path), out bus.handle);
			}
			return result;
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x00004FE0 File Offset: 0x000031E0
		public RESULT getVCA(string path, out VCA vca)
		{
			RESULT result;
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				result = System.FMOD_Studio_System_GetVCA(this.handle, freeHelper.byteFromStringUTF8(path), out vca.handle);
			}
			return result;
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x0000502C File Offset: 0x0000322C
		public RESULT getBank(string path, out Bank bank)
		{
			RESULT result;
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				result = System.FMOD_Studio_System_GetBank(this.handle, freeHelper.byteFromStringUTF8(path), out bank.handle);
			}
			return result;
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x00005078 File Offset: 0x00003278
		public RESULT getEventByID(Guid id, out EventDescription _event)
		{
			return System.FMOD_Studio_System_GetEventByID(this.handle, ref id, out _event.handle);
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x0000508D File Offset: 0x0000328D
		public RESULT getBusByID(Guid id, out Bus bus)
		{
			return System.FMOD_Studio_System_GetBusByID(this.handle, ref id, out bus.handle);
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x000050A2 File Offset: 0x000032A2
		public RESULT getVCAByID(Guid id, out VCA vca)
		{
			return System.FMOD_Studio_System_GetVCAByID(this.handle, ref id, out vca.handle);
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x000050B7 File Offset: 0x000032B7
		public RESULT getBankByID(Guid id, out Bank bank)
		{
			return System.FMOD_Studio_System_GetBankByID(this.handle, ref id, out bank.handle);
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x000050CC File Offset: 0x000032CC
		public RESULT getSoundInfo(string key, out SOUND_INFO info)
		{
			RESULT result;
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				result = System.FMOD_Studio_System_GetSoundInfo(this.handle, freeHelper.byteFromStringUTF8(key), out info);
			}
			return result;
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x00005110 File Offset: 0x00003310
		public RESULT getParameterDescriptionByName(string name, out PARAMETER_DESCRIPTION parameter)
		{
			RESULT result;
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				result = System.FMOD_Studio_System_GetParameterDescriptionByName(this.handle, freeHelper.byteFromStringUTF8(name), out parameter);
			}
			return result;
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x00005154 File Offset: 0x00003354
		public RESULT getParameterDescriptionByID(PARAMETER_ID id, out PARAMETER_DESCRIPTION parameter)
		{
			return System.FMOD_Studio_System_GetParameterDescriptionByID(this.handle, id, out parameter);
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x00005164 File Offset: 0x00003364
		public RESULT getParameterByID(PARAMETER_ID id, out float value)
		{
			float num;
			return this.getParameterByID(id, out value, out num);
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x0000517B File Offset: 0x0000337B
		public RESULT getParameterByID(PARAMETER_ID id, out float value, out float finalvalue)
		{
			return System.FMOD_Studio_System_GetParameterByID(this.handle, id, out value, out finalvalue);
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x0000518B File Offset: 0x0000338B
		public RESULT setParameterByID(PARAMETER_ID id, float value, bool ignoreseekspeed = false)
		{
			return System.FMOD_Studio_System_SetParameterByID(this.handle, id, value, ignoreseekspeed);
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x0000519B File Offset: 0x0000339B
		public RESULT setParametersByIDs(PARAMETER_ID[] ids, float[] values, int count, bool ignoreseekspeed = false)
		{
			return System.FMOD_Studio_System_SetParametersByIDs(this.handle, ids, values, count, ignoreseekspeed);
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x000051B0 File Offset: 0x000033B0
		public RESULT getParameterByName(string name, out float value)
		{
			float num;
			return this.getParameterByName(name, out value, out num);
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x000051C8 File Offset: 0x000033C8
		public RESULT getParameterByName(string name, out float value, out float finalvalue)
		{
			RESULT result;
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				result = System.FMOD_Studio_System_GetParameterByName(this.handle, freeHelper.byteFromStringUTF8(name), out value, out finalvalue);
			}
			return result;
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x00005210 File Offset: 0x00003410
		public RESULT setParameterByName(string name, float value, bool ignoreseekspeed = false)
		{
			RESULT result;
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				result = System.FMOD_Studio_System_SetParameterByName(this.handle, freeHelper.byteFromStringUTF8(name), value, ignoreseekspeed);
			}
			return result;
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x00005258 File Offset: 0x00003458
		public RESULT lookupID(string path, out Guid id)
		{
			RESULT result;
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				result = System.FMOD_Studio_System_LookupID(this.handle, freeHelper.byteFromStringUTF8(path), out id);
			}
			return result;
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x0000529C File Offset: 0x0000349C
		public RESULT lookupPath(Guid id, out string path)
		{
			path = null;
			RESULT result2;
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				IntPtr intPtr = Marshal.AllocHGlobal(256);
				int num = 0;
				RESULT result = System.FMOD_Studio_System_LookupPath(this.handle, ref id, intPtr, 256, out num);
				if (result == RESULT.ERR_TRUNCATED)
				{
					Marshal.FreeHGlobal(intPtr);
					intPtr = Marshal.AllocHGlobal(num);
					result = System.FMOD_Studio_System_LookupPath(this.handle, ref id, intPtr, num, out num);
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

		// Token: 0x0600049E RID: 1182 RVA: 0x0000532C File Offset: 0x0000352C
		public RESULT getNumListeners(out int numlisteners)
		{
			return System.FMOD_Studio_System_GetNumListeners(this.handle, out numlisteners);
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x0000533A File Offset: 0x0000353A
		public RESULT setNumListeners(int numlisteners)
		{
			return System.FMOD_Studio_System_SetNumListeners(this.handle, numlisteners);
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x00005348 File Offset: 0x00003548
		public RESULT getListenerAttributes(int listener, out ATTRIBUTES_3D attributes)
		{
			return System.FMOD_Studio_System_GetListenerAttributes(this.handle, listener, out attributes, IntPtr.Zero);
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x0000535C File Offset: 0x0000355C
		public RESULT getListenerAttributes(int listener, out ATTRIBUTES_3D attributes, out VECTOR attenuationposition)
		{
			return System.FMOD_Studio_System_GetListenerAttributes(this.handle, listener, out attributes, out attenuationposition);
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x0000536C File Offset: 0x0000356C
		public RESULT setListenerAttributes(int listener, ATTRIBUTES_3D attributes)
		{
			return System.FMOD_Studio_System_SetListenerAttributes(this.handle, listener, ref attributes, IntPtr.Zero);
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x00005381 File Offset: 0x00003581
		public RESULT setListenerAttributes(int listener, ATTRIBUTES_3D attributes, VECTOR attenuationposition)
		{
			return System.FMOD_Studio_System_SetListenerAttributes(this.handle, listener, ref attributes, ref attenuationposition);
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x00005393 File Offset: 0x00003593
		public RESULT getListenerWeight(int listener, out float weight)
		{
			return System.FMOD_Studio_System_GetListenerWeight(this.handle, listener, out weight);
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x000053A2 File Offset: 0x000035A2
		public RESULT setListenerWeight(int listener, float weight)
		{
			return System.FMOD_Studio_System_SetListenerWeight(this.handle, listener, weight);
		}

		// Token: 0x060004A6 RID: 1190 RVA: 0x000053B4 File Offset: 0x000035B4
		public RESULT loadBankFile(string filename, LOAD_BANK_FLAGS flags, out Bank bank)
		{
			RESULT result;
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				result = System.FMOD_Studio_System_LoadBankFile(this.handle, freeHelper.byteFromStringUTF8(filename), flags, out bank.handle);
			}
			return result;
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x00005400 File Offset: 0x00003600
		public RESULT loadBankMemory(byte[] buffer, LOAD_BANK_FLAGS flags, out Bank bank)
		{
			GCHandle gchandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
			IntPtr buffer2 = gchandle.AddrOfPinnedObject();
			RESULT result = System.FMOD_Studio_System_LoadBankMemory(this.handle, buffer2, buffer.Length, LOAD_MEMORY_MODE.LOAD_MEMORY, flags, out bank.handle);
			gchandle.Free();
			return result;
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x0000543B File Offset: 0x0000363B
		public RESULT loadBankCustom(BANK_INFO info, LOAD_BANK_FLAGS flags, out Bank bank)
		{
			info.size = MarshalHelper.SizeOf(typeof(BANK_INFO));
			return System.FMOD_Studio_System_LoadBankCustom(this.handle, ref info, flags, out bank.handle);
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x00005467 File Offset: 0x00003667
		public RESULT unloadAll()
		{
			return System.FMOD_Studio_System_UnloadAll(this.handle);
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x00005474 File Offset: 0x00003674
		public RESULT flushCommands()
		{
			return System.FMOD_Studio_System_FlushCommands(this.handle);
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x00005481 File Offset: 0x00003681
		public RESULT flushSampleLoading()
		{
			return System.FMOD_Studio_System_FlushSampleLoading(this.handle);
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x00005490 File Offset: 0x00003690
		public RESULT startCommandCapture(string filename, COMMANDCAPTURE_FLAGS flags)
		{
			RESULT result;
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				result = System.FMOD_Studio_System_StartCommandCapture(this.handle, freeHelper.byteFromStringUTF8(filename), flags);
			}
			return result;
		}

		// Token: 0x060004AD RID: 1197 RVA: 0x000054D4 File Offset: 0x000036D4
		public RESULT stopCommandCapture()
		{
			return System.FMOD_Studio_System_StopCommandCapture(this.handle);
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x000054E4 File Offset: 0x000036E4
		public RESULT loadCommandReplay(string filename, COMMANDREPLAY_FLAGS flags, out CommandReplay replay)
		{
			RESULT result;
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				result = System.FMOD_Studio_System_LoadCommandReplay(this.handle, freeHelper.byteFromStringUTF8(filename), flags, out replay.handle);
			}
			return result;
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x00005530 File Offset: 0x00003730
		public RESULT getBankCount(out int count)
		{
			return System.FMOD_Studio_System_GetBankCount(this.handle, out count);
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x00005540 File Offset: 0x00003740
		public RESULT getBankList(out Bank[] array)
		{
			array = null;
			int num;
			RESULT result = System.FMOD_Studio_System_GetBankCount(this.handle, out num);
			if (result != RESULT.OK)
			{
				return result;
			}
			if (num == 0)
			{
				array = new Bank[0];
				return result;
			}
			IntPtr[] array2 = new IntPtr[num];
			int num2;
			result = System.FMOD_Studio_System_GetBankList(this.handle, array2, num, out num2);
			if (result != RESULT.OK)
			{
				return result;
			}
			if (num2 > num)
			{
				num2 = num;
			}
			array = new Bank[num2];
			for (int i = 0; i < num2; i++)
			{
				array[i].handle = array2[i];
			}
			return RESULT.OK;
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x000055BD File Offset: 0x000037BD
		public RESULT getParameterDescriptionCount(out int count)
		{
			return System.FMOD_Studio_System_GetParameterDescriptionCount(this.handle, out count);
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x000055CC File Offset: 0x000037CC
		public RESULT getParameterDescriptionList(out PARAMETER_DESCRIPTION[] array)
		{
			array = null;
			int num;
			RESULT result = System.FMOD_Studio_System_GetParameterDescriptionCount(this.handle, out num);
			if (result != RESULT.OK)
			{
				return result;
			}
			if (num == 0)
			{
				array = new PARAMETER_DESCRIPTION[0];
				return RESULT.OK;
			}
			PARAMETER_DESCRIPTION[] array2 = new PARAMETER_DESCRIPTION[num];
			int num2;
			result = System.FMOD_Studio_System_GetParameterDescriptionList(this.handle, array2, num, out num2);
			if (result != RESULT.OK)
			{
				return result;
			}
			if (num2 != num)
			{
				Array.Resize<PARAMETER_DESCRIPTION>(ref array2, num2);
			}
			array = array2;
			return RESULT.OK;
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x00005628 File Offset: 0x00003828
		public RESULT getCPUUsage(out CPU_USAGE usage)
		{
			return System.FMOD_Studio_System_GetCPUUsage(this.handle, out usage);
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x00005636 File Offset: 0x00003836
		public RESULT getBufferUsage(out BUFFER_USAGE usage)
		{
			return System.FMOD_Studio_System_GetBufferUsage(this.handle, out usage);
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x00005644 File Offset: 0x00003844
		public RESULT resetBufferUsage()
		{
			return System.FMOD_Studio_System_ResetBufferUsage(this.handle);
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x00005651 File Offset: 0x00003851
		public RESULT setCallback(SYSTEM_CALLBACK callback, SYSTEM_CALLBACK_TYPE callbackmask = SYSTEM_CALLBACK_TYPE.ALL)
		{
			return System.FMOD_Studio_System_SetCallback(this.handle, callback, callbackmask);
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x00005660 File Offset: 0x00003860
		public RESULT getUserData(out IntPtr userdata)
		{
			return System.FMOD_Studio_System_GetUserData(this.handle, out userdata);
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x0000566E File Offset: 0x0000386E
		public RESULT setUserData(IntPtr userdata)
		{
			return System.FMOD_Studio_System_SetUserData(this.handle, userdata);
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x0000567C File Offset: 0x0000387C
		public RESULT getMemoryUsage(out MEMORY_USAGE memoryusage)
		{
			return System.FMOD_Studio_System_GetMemoryUsage(this.handle, out memoryusage);
		}

		// Token: 0x060004BA RID: 1210
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_Create(out IntPtr system, uint headerversion);

		// Token: 0x060004BB RID: 1211
		[DllImport("fmodstudio")]
		private static extern bool FMOD_Studio_System_IsValid(IntPtr system);

		// Token: 0x060004BC RID: 1212
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_SetAdvancedSettings(IntPtr system, ref ADVANCEDSETTINGS settings);

		// Token: 0x060004BD RID: 1213
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_GetAdvancedSettings(IntPtr system, out ADVANCEDSETTINGS settings);

		// Token: 0x060004BE RID: 1214
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_Initialize(IntPtr system, int maxchannels, INITFLAGS studioflags, INITFLAGS flags, IntPtr extradriverdata);

		// Token: 0x060004BF RID: 1215
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_Release(IntPtr system);

		// Token: 0x060004C0 RID: 1216
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_Update(IntPtr system);

		// Token: 0x060004C1 RID: 1217
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_GetCoreSystem(IntPtr system, out IntPtr coresystem);

		// Token: 0x060004C2 RID: 1218
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_GetEvent(IntPtr system, byte[] path, out IntPtr _event);

		// Token: 0x060004C3 RID: 1219
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_GetBus(IntPtr system, byte[] path, out IntPtr bus);

		// Token: 0x060004C4 RID: 1220
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_GetVCA(IntPtr system, byte[] path, out IntPtr vca);

		// Token: 0x060004C5 RID: 1221
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_GetBank(IntPtr system, byte[] path, out IntPtr bank);

		// Token: 0x060004C6 RID: 1222
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_GetEventByID(IntPtr system, ref Guid id, out IntPtr _event);

		// Token: 0x060004C7 RID: 1223
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_GetBusByID(IntPtr system, ref Guid id, out IntPtr bus);

		// Token: 0x060004C8 RID: 1224
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_GetVCAByID(IntPtr system, ref Guid id, out IntPtr vca);

		// Token: 0x060004C9 RID: 1225
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_GetBankByID(IntPtr system, ref Guid id, out IntPtr bank);

		// Token: 0x060004CA RID: 1226
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_GetSoundInfo(IntPtr system, byte[] key, out SOUND_INFO info);

		// Token: 0x060004CB RID: 1227
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_GetParameterDescriptionByName(IntPtr system, byte[] name, out PARAMETER_DESCRIPTION parameter);

		// Token: 0x060004CC RID: 1228
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_GetParameterDescriptionByID(IntPtr system, PARAMETER_ID id, out PARAMETER_DESCRIPTION parameter);

		// Token: 0x060004CD RID: 1229
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_GetParameterByID(IntPtr system, PARAMETER_ID id, out float value, out float finalvalue);

		// Token: 0x060004CE RID: 1230
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_SetParameterByID(IntPtr system, PARAMETER_ID id, float value, bool ignoreseekspeed);

		// Token: 0x060004CF RID: 1231
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_SetParametersByIDs(IntPtr system, PARAMETER_ID[] ids, float[] values, int count, bool ignoreseekspeed);

		// Token: 0x060004D0 RID: 1232
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_GetParameterByName(IntPtr system, byte[] name, out float value, out float finalvalue);

		// Token: 0x060004D1 RID: 1233
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_SetParameterByName(IntPtr system, byte[] name, float value, bool ignoreseekspeed);

		// Token: 0x060004D2 RID: 1234
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_LookupID(IntPtr system, byte[] path, out Guid id);

		// Token: 0x060004D3 RID: 1235
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_LookupPath(IntPtr system, ref Guid id, IntPtr path, int size, out int retrieved);

		// Token: 0x060004D4 RID: 1236
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_GetNumListeners(IntPtr system, out int numlisteners);

		// Token: 0x060004D5 RID: 1237
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_SetNumListeners(IntPtr system, int numlisteners);

		// Token: 0x060004D6 RID: 1238
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_GetListenerAttributes(IntPtr system, int listener, out ATTRIBUTES_3D attributes, IntPtr zero);

		// Token: 0x060004D7 RID: 1239
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_GetListenerAttributes(IntPtr system, int listener, out ATTRIBUTES_3D attributes, out VECTOR attenuationposition);

		// Token: 0x060004D8 RID: 1240
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_SetListenerAttributes(IntPtr system, int listener, ref ATTRIBUTES_3D attributes, IntPtr zero);

		// Token: 0x060004D9 RID: 1241
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_SetListenerAttributes(IntPtr system, int listener, ref ATTRIBUTES_3D attributes, ref VECTOR attenuationposition);

		// Token: 0x060004DA RID: 1242
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_GetListenerWeight(IntPtr system, int listener, out float weight);

		// Token: 0x060004DB RID: 1243
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_SetListenerWeight(IntPtr system, int listener, float weight);

		// Token: 0x060004DC RID: 1244
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_LoadBankFile(IntPtr system, byte[] filename, LOAD_BANK_FLAGS flags, out IntPtr bank);

		// Token: 0x060004DD RID: 1245
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_LoadBankMemory(IntPtr system, IntPtr buffer, int length, LOAD_MEMORY_MODE mode, LOAD_BANK_FLAGS flags, out IntPtr bank);

		// Token: 0x060004DE RID: 1246
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_LoadBankCustom(IntPtr system, ref BANK_INFO info, LOAD_BANK_FLAGS flags, out IntPtr bank);

		// Token: 0x060004DF RID: 1247
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_UnloadAll(IntPtr system);

		// Token: 0x060004E0 RID: 1248
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_FlushCommands(IntPtr system);

		// Token: 0x060004E1 RID: 1249
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_FlushSampleLoading(IntPtr system);

		// Token: 0x060004E2 RID: 1250
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_StartCommandCapture(IntPtr system, byte[] filename, COMMANDCAPTURE_FLAGS flags);

		// Token: 0x060004E3 RID: 1251
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_StopCommandCapture(IntPtr system);

		// Token: 0x060004E4 RID: 1252
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_LoadCommandReplay(IntPtr system, byte[] filename, COMMANDREPLAY_FLAGS flags, out IntPtr replay);

		// Token: 0x060004E5 RID: 1253
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_GetBankCount(IntPtr system, out int count);

		// Token: 0x060004E6 RID: 1254
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_GetBankList(IntPtr system, IntPtr[] array, int capacity, out int count);

		// Token: 0x060004E7 RID: 1255
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_GetParameterDescriptionCount(IntPtr system, out int count);

		// Token: 0x060004E8 RID: 1256
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_GetParameterDescriptionList(IntPtr system, [Out] PARAMETER_DESCRIPTION[] array, int capacity, out int count);

		// Token: 0x060004E9 RID: 1257
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_GetCPUUsage(IntPtr system, out CPU_USAGE usage);

		// Token: 0x060004EA RID: 1258
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_GetBufferUsage(IntPtr system, out BUFFER_USAGE usage);

		// Token: 0x060004EB RID: 1259
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_ResetBufferUsage(IntPtr system);

		// Token: 0x060004EC RID: 1260
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_SetCallback(IntPtr system, SYSTEM_CALLBACK callback, SYSTEM_CALLBACK_TYPE callbackmask);

		// Token: 0x060004ED RID: 1261
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_GetUserData(IntPtr system, out IntPtr userdata);

		// Token: 0x060004EE RID: 1262
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_SetUserData(IntPtr system, IntPtr userdata);

		// Token: 0x060004EF RID: 1263
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_System_GetMemoryUsage(IntPtr system, out MEMORY_USAGE memoryusage);

		// Token: 0x060004F0 RID: 1264 RVA: 0x0000568A File Offset: 0x0000388A
		public System(IntPtr ptr)
		{
			this.handle = ptr;
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x00005693 File Offset: 0x00003893
		public bool hasHandle()
		{
			return this.handle != IntPtr.Zero;
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x000056A5 File Offset: 0x000038A5
		public void clearHandle()
		{
			this.handle = IntPtr.Zero;
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x000056B2 File Offset: 0x000038B2
		public bool isValid()
		{
			return this.hasHandle() && System.FMOD_Studio_System_IsValid(this.handle);
		}

		// Token: 0x040004F4 RID: 1268
		public IntPtr handle;
	}
}
