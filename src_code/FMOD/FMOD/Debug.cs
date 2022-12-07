using System;
using System.Runtime.InteropServices;

namespace FMOD
{
	// Token: 0x02000041 RID: 65
	public struct Debug
	{
		// Token: 0x06000067 RID: 103 RVA: 0x00002868 File Offset: 0x00000A68
		public static RESULT Initialize(DEBUG_FLAGS flags, DEBUG_MODE mode = DEBUG_MODE.TTY, DEBUG_CALLBACK callback = null, string filename = null)
		{
			RESULT result;
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				result = Debug.FMOD5_Debug_Initialize(flags, mode, callback, freeHelper.byteFromStringUTF8(filename));
			}
			return result;
		}

		// Token: 0x06000068 RID: 104
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Debug_Initialize(DEBUG_FLAGS flags, DEBUG_MODE mode, DEBUG_CALLBACK callback, byte[] filename);
	}
}
