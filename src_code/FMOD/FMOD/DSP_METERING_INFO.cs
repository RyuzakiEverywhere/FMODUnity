using System;
using System.Runtime.InteropServices;

namespace FMOD
{
	// Token: 0x02000090 RID: 144
	public struct DSP_METERING_INFO
	{
		// Token: 0x040002F3 RID: 755
		public int numsamples;

		// Token: 0x040002F4 RID: 756
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		public float[] peaklevel;

		// Token: 0x040002F5 RID: 757
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		public float[] rmslevel;

		// Token: 0x040002F6 RID: 758
		public short numchannels;
	}
}
