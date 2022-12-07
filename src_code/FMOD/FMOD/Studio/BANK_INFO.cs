using System;

namespace FMOD.Studio
{
	// Token: 0x020000C7 RID: 199
	public struct BANK_INFO
	{
		// Token: 0x04000468 RID: 1128
		public int size;

		// Token: 0x04000469 RID: 1129
		public IntPtr userdata;

		// Token: 0x0400046A RID: 1130
		public int userdatalength;

		// Token: 0x0400046B RID: 1131
		public FILE_OPEN_CALLBACK opencallback;

		// Token: 0x0400046C RID: 1132
		public FILE_CLOSE_CALLBACK closecallback;

		// Token: 0x0400046D RID: 1133
		public FILE_READ_CALLBACK readcallback;

		// Token: 0x0400046E RID: 1134
		public FILE_SEEK_CALLBACK seekcallback;
	}
}
