using System;
using System.Runtime.InteropServices;

namespace FMOD.Studio
{
	// Token: 0x020000E3 RID: 227
	public struct Util
	{
		// Token: 0x06000480 RID: 1152 RVA: 0x00004E14 File Offset: 0x00003014
		public static RESULT parseID(string idString, out Guid id)
		{
			RESULT result;
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				result = Util.FMOD_Studio_ParseID(freeHelper.byteFromStringUTF8(idString), out id);
			}
			return result;
		}

		// Token: 0x06000481 RID: 1153
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_ParseID(byte[] idString, out Guid id);
	}
}
