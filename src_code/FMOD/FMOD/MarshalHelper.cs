using System;
using System.Runtime.InteropServices;

namespace FMOD
{
	// Token: 0x0200004F RID: 79
	public static class MarshalHelper
	{
		// Token: 0x060003CF RID: 975 RVA: 0x00004935 File Offset: 0x00002B35
		public static int SizeOf(Type t)
		{
			return Marshal.SizeOf(t);
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x0000493D File Offset: 0x00002B3D
		public static object PtrToStructure(IntPtr ptr, Type structureType)
		{
			return Marshal.PtrToStructure(ptr, structureType);
		}
	}
}
