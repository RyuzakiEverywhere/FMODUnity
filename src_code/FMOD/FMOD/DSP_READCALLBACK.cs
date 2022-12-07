using System;

namespace FMOD
{
	// Token: 0x02000058 RID: 88
	// (Invoke) Token: 0x060003E2 RID: 994
	public delegate RESULT DSP_READCALLBACK(ref DSP_STATE dsp_state, IntPtr inbuffer, IntPtr outbuffer, uint length, int inchannels, ref int outchannels);
}
