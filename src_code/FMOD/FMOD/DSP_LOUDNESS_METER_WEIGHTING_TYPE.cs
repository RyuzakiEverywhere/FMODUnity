using System;
using System.Runtime.InteropServices;

namespace FMOD
{
	// Token: 0x0200008A RID: 138
	public struct DSP_LOUDNESS_METER_WEIGHTING_TYPE
	{
		// Token: 0x040002BC RID: 700
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		public float[] channelweight;
	}
}
