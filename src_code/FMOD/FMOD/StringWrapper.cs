using System;

namespace FMOD
{
	// Token: 0x0200004D RID: 77
	public struct StringWrapper
	{
		// Token: 0x060003CB RID: 971 RVA: 0x0000484E File Offset: 0x00002A4E
		public StringWrapper(IntPtr ptr)
		{
			this.nativeUtf8Ptr = ptr;
		}

		// Token: 0x060003CC RID: 972 RVA: 0x00004858 File Offset: 0x00002A58
		public static implicit operator string(StringWrapper fstring)
		{
			string result;
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				result = freeHelper.stringFromNative(fstring.nativeUtf8Ptr);
			}
			return result;
		}

		// Token: 0x04000247 RID: 583
		private IntPtr nativeUtf8Ptr;
	}
}
