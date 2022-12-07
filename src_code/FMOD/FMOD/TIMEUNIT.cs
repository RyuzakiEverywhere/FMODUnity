using System;

namespace FMOD
{
	// Token: 0x02000034 RID: 52
	[Flags]
	public enum TIMEUNIT : uint
	{
		// Token: 0x04000195 RID: 405
		MS = 1U,
		// Token: 0x04000196 RID: 406
		PCM = 2U,
		// Token: 0x04000197 RID: 407
		PCMBYTES = 4U,
		// Token: 0x04000198 RID: 408
		RAWBYTES = 8U,
		// Token: 0x04000199 RID: 409
		PCMFRACTION = 16U,
		// Token: 0x0400019A RID: 410
		MODORDER = 256U,
		// Token: 0x0400019B RID: 411
		MODROW = 512U,
		// Token: 0x0400019C RID: 412
		MODPATTERN = 1024U
	}
}
