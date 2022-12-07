using System;

namespace FMOD.Studio
{
	// Token: 0x020000DE RID: 222
	// (Invoke) Token: 0x06000479 RID: 1145
	public delegate RESULT COMMANDREPLAY_LOAD_BANK_CALLBACK(IntPtr replay, int commandindex, Guid bankguid, IntPtr bankfilename, LOAD_BANK_FLAGS flags, out IntPtr bank, IntPtr userdata);
}
