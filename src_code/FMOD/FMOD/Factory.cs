using System;
using System.Runtime.InteropServices;

namespace FMOD
{
	// Token: 0x0200003F RID: 63
	public struct Factory
	{
		// Token: 0x06000061 RID: 97 RVA: 0x00002842 File Offset: 0x00000A42
		public static RESULT System_Create(out System system)
		{
			return Factory.FMOD5_System_Create(out system.handle);
		}

		// Token: 0x06000062 RID: 98
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_System_Create(out IntPtr system);
	}
}
