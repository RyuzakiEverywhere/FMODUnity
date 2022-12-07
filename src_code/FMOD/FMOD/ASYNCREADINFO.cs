using System;

namespace FMOD
{
	// Token: 0x02000008 RID: 8
	public struct ASYNCREADINFO
	{
		// Token: 0x04000066 RID: 102
		public IntPtr handle;

		// Token: 0x04000067 RID: 103
		public uint offset;

		// Token: 0x04000068 RID: 104
		public uint sizebytes;

		// Token: 0x04000069 RID: 105
		public int priority;

		// Token: 0x0400006A RID: 106
		public IntPtr userdata;

		// Token: 0x0400006B RID: 107
		public IntPtr buffer;

		// Token: 0x0400006C RID: 108
		public uint bytesread;

		// Token: 0x0400006D RID: 109
		public FILE_ASYNCDONE_FUNC done;
	}
}
