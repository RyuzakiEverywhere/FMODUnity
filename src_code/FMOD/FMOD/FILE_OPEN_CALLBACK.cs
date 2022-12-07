using System;

namespace FMOD
{
	// Token: 0x02000024 RID: 36
	// (Invoke) Token: 0x0600001C RID: 28
	public delegate RESULT FILE_OPEN_CALLBACK(IntPtr name, ref uint filesize, ref IntPtr handle, IntPtr userdata);
}
