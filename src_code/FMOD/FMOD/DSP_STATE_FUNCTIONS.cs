using System;

namespace FMOD
{
	// Token: 0x0200008E RID: 142
	public struct DSP_STATE_FUNCTIONS
	{
		// Token: 0x040002DF RID: 735
		public DSP_ALLOC_FUNC alloc;

		// Token: 0x040002E0 RID: 736
		public DSP_REALLOC_FUNC realloc;

		// Token: 0x040002E1 RID: 737
		public DSP_FREE_FUNC free;

		// Token: 0x040002E2 RID: 738
		public DSP_GETSAMPLERATE_FUNC getsamplerate;

		// Token: 0x040002E3 RID: 739
		public DSP_GETBLOCKSIZE_FUNC getblocksize;

		// Token: 0x040002E4 RID: 740
		public IntPtr dft;

		// Token: 0x040002E5 RID: 741
		public IntPtr pan;

		// Token: 0x040002E6 RID: 742
		public DSP_GETSPEAKERMODE_FUNC getspeakermode;

		// Token: 0x040002E7 RID: 743
		public DSP_GETCLOCK_FUNC getclock;

		// Token: 0x040002E8 RID: 744
		public DSP_GETLISTENERATTRIBUTES_FUNC getlistenerattributes;

		// Token: 0x040002E9 RID: 745
		public DSP_LOG_FUNC log;

		// Token: 0x040002EA RID: 746
		public DSP_GETUSERDATA_FUNC getuserdata;
	}
}
