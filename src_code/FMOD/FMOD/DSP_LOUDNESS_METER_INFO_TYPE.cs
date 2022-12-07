using System;
using System.Runtime.InteropServices;

namespace FMOD
{
	// Token: 0x02000089 RID: 137
	public struct DSP_LOUDNESS_METER_INFO_TYPE
	{
		// Token: 0x040002B4 RID: 692
		public float momentaryloudness;

		// Token: 0x040002B5 RID: 693
		public float shorttermloudness;

		// Token: 0x040002B6 RID: 694
		public float integratedloudness;

		// Token: 0x040002B7 RID: 695
		public float loudness10thpercentile;

		// Token: 0x040002B8 RID: 696
		public float loudness95thpercentile;

		// Token: 0x040002B9 RID: 697
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 66)]
		public float[] loudnesshistogram;

		// Token: 0x040002BA RID: 698
		public float maxtruepeak;

		// Token: 0x040002BB RID: 699
		public float maxmomentaryloudness;
	}
}
