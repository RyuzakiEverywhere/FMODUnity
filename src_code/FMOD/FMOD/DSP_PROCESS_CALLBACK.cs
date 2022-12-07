using System;

namespace FMOD
{
	// Token: 0x0200005A RID: 90
	// (Invoke) Token: 0x060003EA RID: 1002
	public delegate RESULT DSP_PROCESS_CALLBACK(ref DSP_STATE dsp_state, uint length, ref DSP_BUFFER_ARRAY inbufferarray, ref DSP_BUFFER_ARRAY outbufferarray, bool inputsidle, DSP_PROCESS_OPERATION op);
}
