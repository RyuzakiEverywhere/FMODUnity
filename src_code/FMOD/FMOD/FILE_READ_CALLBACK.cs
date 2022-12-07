using System;

namespace FMOD
{
	// Token: 0x02000026 RID: 38
	// (Invoke) Token: 0x06000024 RID: 36
	public delegate RESULT FILE_READ_CALLBACK(IntPtr handle, IntPtr buffer, uint sizebytes, ref uint bytesread, IntPtr userdata);
}
