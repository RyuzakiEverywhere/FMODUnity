using System;

namespace FMOD
{
	// Token: 0x02000050 RID: 80
	public struct DSP_BUFFER_ARRAY
	{
		// Token: 0x04000249 RID: 585
		public int numbuffers;

		// Token: 0x0400024A RID: 586
		public int[] buffernumchannels;

		// Token: 0x0400024B RID: 587
		public CHANNELMASK[] bufferchannelmask;

		// Token: 0x0400024C RID: 588
		public IntPtr[] buffers;

		// Token: 0x0400024D RID: 589
		public SPEAKERMODE speakermode;
	}
}
