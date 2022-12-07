using System;

namespace FMOD
{
	// Token: 0x0200008F RID: 143
	public struct DSP_STATE
	{
		// Token: 0x040002EB RID: 747
		public IntPtr instance;

		// Token: 0x040002EC RID: 748
		public IntPtr plugindata;

		// Token: 0x040002ED RID: 749
		public uint channelmask;

		// Token: 0x040002EE RID: 750
		public int source_speakermode;

		// Token: 0x040002EF RID: 751
		public IntPtr sidechaindata;

		// Token: 0x040002F0 RID: 752
		public int sidechainchannels;

		// Token: 0x040002F1 RID: 753
		public IntPtr functions;

		// Token: 0x040002F2 RID: 754
		public int systemobject;
	}
}
