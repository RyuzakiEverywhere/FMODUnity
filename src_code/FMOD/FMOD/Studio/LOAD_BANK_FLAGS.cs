using System;

namespace FMOD.Studio
{
	// Token: 0x020000D5 RID: 213
	[Flags]
	public enum LOAD_BANK_FLAGS : uint
	{
		// Token: 0x040004AD RID: 1197
		NORMAL = 0U,
		// Token: 0x040004AE RID: 1198
		NONBLOCKING = 1U,
		// Token: 0x040004AF RID: 1199
		DECOMPRESS_SAMPLES = 2U,
		// Token: 0x040004B0 RID: 1200
		UNENCRYPTED = 4U
	}
}
