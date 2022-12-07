using System;

namespace FMOD
{
	// Token: 0x02000076 RID: 118
	// (Invoke) Token: 0x0600045A RID: 1114
	public delegate RESULT DSP_PAN_SUMSTEREOTOSURROUNDMATRIX_FUNC(ref DSP_STATE dsp_state, int targetSpeakerMode, float direction, float extent, float rotation, float lowFrequencyGain, float overallGain, int matrixHop, IntPtr matrix);
}
