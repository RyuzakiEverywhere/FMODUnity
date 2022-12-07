using System;

namespace FMODUnity
{
	// Token: 0x02000109 RID: 265
	[Flags]
	public enum ThreadAffinity : uint
	{
		// Token: 0x0400056A RID: 1386
		Any = 0U,
		// Token: 0x0400056B RID: 1387
		Core0 = 1U,
		// Token: 0x0400056C RID: 1388
		Core1 = 2U,
		// Token: 0x0400056D RID: 1389
		Core2 = 4U,
		// Token: 0x0400056E RID: 1390
		Core3 = 8U,
		// Token: 0x0400056F RID: 1391
		Core4 = 16U,
		// Token: 0x04000570 RID: 1392
		Core5 = 32U,
		// Token: 0x04000571 RID: 1393
		Core6 = 64U,
		// Token: 0x04000572 RID: 1394
		Core7 = 128U,
		// Token: 0x04000573 RID: 1395
		Core8 = 256U,
		// Token: 0x04000574 RID: 1396
		Core9 = 512U,
		// Token: 0x04000575 RID: 1397
		Core10 = 1024U,
		// Token: 0x04000576 RID: 1398
		Core11 = 2048U,
		// Token: 0x04000577 RID: 1399
		Core12 = 4096U,
		// Token: 0x04000578 RID: 1400
		Core13 = 8192U,
		// Token: 0x04000579 RID: 1401
		Core14 = 16384U,
		// Token: 0x0400057A RID: 1402
		Core15 = 32768U
	}
}
