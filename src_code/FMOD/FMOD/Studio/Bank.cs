using System;
using System.Runtime.InteropServices;

namespace FMOD.Studio
{
	// Token: 0x020000E9 RID: 233
	public struct Bank
	{
		// Token: 0x060005B4 RID: 1460 RVA: 0x0000604E File Offset: 0x0000424E
		public RESULT getID(out Guid id)
		{
			return Bank.FMOD_Studio_Bank_GetID(this.handle, out id);
		}

		// Token: 0x060005B5 RID: 1461 RVA: 0x0000605C File Offset: 0x0000425C
		public RESULT getPath(out string path)
		{
			path = null;
			RESULT result2;
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				IntPtr intPtr = Marshal.AllocHGlobal(256);
				int num = 0;
				RESULT result = Bank.FMOD_Studio_Bank_GetPath(this.handle, intPtr, 256, out num);
				if (result == RESULT.ERR_TRUNCATED)
				{
					Marshal.FreeHGlobal(intPtr);
					intPtr = Marshal.AllocHGlobal(num);
					result = Bank.FMOD_Studio_Bank_GetPath(this.handle, intPtr, num, out num);
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

		// Token: 0x060005B6 RID: 1462 RVA: 0x000060E8 File Offset: 0x000042E8
		public RESULT unload()
		{
			return Bank.FMOD_Studio_Bank_Unload(this.handle);
		}

		// Token: 0x060005B7 RID: 1463 RVA: 0x000060F5 File Offset: 0x000042F5
		public RESULT loadSampleData()
		{
			return Bank.FMOD_Studio_Bank_LoadSampleData(this.handle);
		}

		// Token: 0x060005B8 RID: 1464 RVA: 0x00006102 File Offset: 0x00004302
		public RESULT unloadSampleData()
		{
			return Bank.FMOD_Studio_Bank_UnloadSampleData(this.handle);
		}

		// Token: 0x060005B9 RID: 1465 RVA: 0x0000610F File Offset: 0x0000430F
		public RESULT getLoadingState(out LOADING_STATE state)
		{
			return Bank.FMOD_Studio_Bank_GetLoadingState(this.handle, out state);
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x0000611D File Offset: 0x0000431D
		public RESULT getSampleLoadingState(out LOADING_STATE state)
		{
			return Bank.FMOD_Studio_Bank_GetSampleLoadingState(this.handle, out state);
		}

		// Token: 0x060005BB RID: 1467 RVA: 0x0000612B File Offset: 0x0000432B
		public RESULT getStringCount(out int count)
		{
			return Bank.FMOD_Studio_Bank_GetStringCount(this.handle, out count);
		}

		// Token: 0x060005BC RID: 1468 RVA: 0x0000613C File Offset: 0x0000433C
		public RESULT getStringInfo(int index, out Guid id, out string path)
		{
			path = null;
			id = Guid.Empty;
			RESULT result2;
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				IntPtr intPtr = Marshal.AllocHGlobal(256);
				int num = 0;
				RESULT result = Bank.FMOD_Studio_Bank_GetStringInfo(this.handle, index, out id, intPtr, 256, out num);
				if (result == RESULT.ERR_TRUNCATED)
				{
					Marshal.FreeHGlobal(intPtr);
					intPtr = Marshal.AllocHGlobal(num);
					result = Bank.FMOD_Studio_Bank_GetStringInfo(this.handle, index, out id, intPtr, num, out num);
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

		// Token: 0x060005BD RID: 1469 RVA: 0x000061D8 File Offset: 0x000043D8
		public RESULT getEventCount(out int count)
		{
			return Bank.FMOD_Studio_Bank_GetEventCount(this.handle, out count);
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x000061E8 File Offset: 0x000043E8
		public RESULT getEventList(out EventDescription[] array)
		{
			array = null;
			int num;
			RESULT result = Bank.FMOD_Studio_Bank_GetEventCount(this.handle, out num);
			if (result != RESULT.OK)
			{
				return result;
			}
			if (num == 0)
			{
				array = new EventDescription[0];
				return result;
			}
			IntPtr[] array2 = new IntPtr[num];
			int num2;
			result = Bank.FMOD_Studio_Bank_GetEventList(this.handle, array2, num, out num2);
			if (result != RESULT.OK)
			{
				return result;
			}
			if (num2 > num)
			{
				num2 = num;
			}
			array = new EventDescription[num2];
			for (int i = 0; i < num2; i++)
			{
				array[i].handle = array2[i];
			}
			return RESULT.OK;
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x00006265 File Offset: 0x00004465
		public RESULT getBusCount(out int count)
		{
			return Bank.FMOD_Studio_Bank_GetBusCount(this.handle, out count);
		}

		// Token: 0x060005C0 RID: 1472 RVA: 0x00006274 File Offset: 0x00004474
		public RESULT getBusList(out Bus[] array)
		{
			array = null;
			int num;
			RESULT result = Bank.FMOD_Studio_Bank_GetBusCount(this.handle, out num);
			if (result != RESULT.OK)
			{
				return result;
			}
			if (num == 0)
			{
				array = new Bus[0];
				return result;
			}
			IntPtr[] array2 = new IntPtr[num];
			int num2;
			result = Bank.FMOD_Studio_Bank_GetBusList(this.handle, array2, num, out num2);
			if (result != RESULT.OK)
			{
				return result;
			}
			if (num2 > num)
			{
				num2 = num;
			}
			array = new Bus[num2];
			for (int i = 0; i < num2; i++)
			{
				array[i].handle = array2[i];
			}
			return RESULT.OK;
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x000062F1 File Offset: 0x000044F1
		public RESULT getVCACount(out int count)
		{
			return Bank.FMOD_Studio_Bank_GetVCACount(this.handle, out count);
		}

		// Token: 0x060005C2 RID: 1474 RVA: 0x00006300 File Offset: 0x00004500
		public RESULT getVCAList(out VCA[] array)
		{
			array = null;
			int num;
			RESULT result = Bank.FMOD_Studio_Bank_GetVCACount(this.handle, out num);
			if (result != RESULT.OK)
			{
				return result;
			}
			if (num == 0)
			{
				array = new VCA[0];
				return result;
			}
			IntPtr[] array2 = new IntPtr[num];
			int num2;
			result = Bank.FMOD_Studio_Bank_GetVCAList(this.handle, array2, num, out num2);
			if (result != RESULT.OK)
			{
				return result;
			}
			if (num2 > num)
			{
				num2 = num;
			}
			array = new VCA[num2];
			for (int i = 0; i < num2; i++)
			{
				array[i].handle = array2[i];
			}
			return RESULT.OK;
		}

		// Token: 0x060005C3 RID: 1475 RVA: 0x0000637D File Offset: 0x0000457D
		public RESULT getUserData(out IntPtr userdata)
		{
			return Bank.FMOD_Studio_Bank_GetUserData(this.handle, out userdata);
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x0000638B File Offset: 0x0000458B
		public RESULT setUserData(IntPtr userdata)
		{
			return Bank.FMOD_Studio_Bank_SetUserData(this.handle, userdata);
		}

		// Token: 0x060005C5 RID: 1477
		[DllImport("fmodstudio")]
		private static extern bool FMOD_Studio_Bank_IsValid(IntPtr bank);

		// Token: 0x060005C6 RID: 1478
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_Bank_GetID(IntPtr bank, out Guid id);

		// Token: 0x060005C7 RID: 1479
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_Bank_GetPath(IntPtr bank, IntPtr path, int size, out int retrieved);

		// Token: 0x060005C8 RID: 1480
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_Bank_Unload(IntPtr bank);

		// Token: 0x060005C9 RID: 1481
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_Bank_LoadSampleData(IntPtr bank);

		// Token: 0x060005CA RID: 1482
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_Bank_UnloadSampleData(IntPtr bank);

		// Token: 0x060005CB RID: 1483
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_Bank_GetLoadingState(IntPtr bank, out LOADING_STATE state);

		// Token: 0x060005CC RID: 1484
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_Bank_GetSampleLoadingState(IntPtr bank, out LOADING_STATE state);

		// Token: 0x060005CD RID: 1485
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_Bank_GetStringCount(IntPtr bank, out int count);

		// Token: 0x060005CE RID: 1486
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_Bank_GetStringInfo(IntPtr bank, int index, out Guid id, IntPtr path, int size, out int retrieved);

		// Token: 0x060005CF RID: 1487
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_Bank_GetEventCount(IntPtr bank, out int count);

		// Token: 0x060005D0 RID: 1488
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_Bank_GetEventList(IntPtr bank, IntPtr[] array, int capacity, out int count);

		// Token: 0x060005D1 RID: 1489
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_Bank_GetBusCount(IntPtr bank, out int count);

		// Token: 0x060005D2 RID: 1490
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_Bank_GetBusList(IntPtr bank, IntPtr[] array, int capacity, out int count);

		// Token: 0x060005D3 RID: 1491
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_Bank_GetVCACount(IntPtr bank, out int count);

		// Token: 0x060005D4 RID: 1492
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_Bank_GetVCAList(IntPtr bank, IntPtr[] array, int capacity, out int count);

		// Token: 0x060005D5 RID: 1493
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_Bank_GetUserData(IntPtr bank, out IntPtr userdata);

		// Token: 0x060005D6 RID: 1494
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_Bank_SetUserData(IntPtr bank, IntPtr userdata);

		// Token: 0x060005D7 RID: 1495 RVA: 0x00006399 File Offset: 0x00004599
		public Bank(IntPtr ptr)
		{
			this.handle = ptr;
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x000063A2 File Offset: 0x000045A2
		public bool hasHandle()
		{
			return this.handle != IntPtr.Zero;
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x000063B4 File Offset: 0x000045B4
		public void clearHandle()
		{
			this.handle = IntPtr.Zero;
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x000063C1 File Offset: 0x000045C1
		public bool isValid()
		{
			return this.hasHandle() && Bank.FMOD_Studio_Bank_IsValid(this.handle);
		}

		// Token: 0x040004FA RID: 1274
		public IntPtr handle;
	}
}
