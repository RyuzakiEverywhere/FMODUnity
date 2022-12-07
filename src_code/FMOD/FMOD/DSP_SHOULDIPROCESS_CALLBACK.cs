using System;

namespace FMOD
{
	// Token: 0x02000059 RID: 89
	// (Invoke) Token: 0x060003E6 RID: 998
	public delegate RESULT DSP_SHOULDIPROCESS_CALLBACK(ref DSP_STATE dsp_state, bool inputsidle, uint length, CHANNELMASK inmask, int inchannels, SPEAKERMODE speakermode);
}
