using System;

namespace FMOD
{
	// Token: 0x02000073 RID: 115
	// (Invoke) Token: 0x0600044E RID: 1102
	public delegate RESULT DSP_PAN_SUMSTEREOMATRIX_FUNC(ref DSP_STATE dsp_state, int sourceSpeakerMode, float pan, float lowFrequencyGain, float overallGain, int matrixHop, IntPtr matrix);
}
