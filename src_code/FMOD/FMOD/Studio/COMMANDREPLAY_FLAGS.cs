using System;

namespace FMOD.Studio
{
	// Token: 0x020000D7 RID: 215
	[Flags]
	public enum COMMANDREPLAY_FLAGS : uint
	{
		// Token: 0x040004B6 RID: 1206
		NORMAL = 0U,
		// Token: 0x040004B7 RID: 1207
		SKIP_CLEANUP = 1U,
		// Token: 0x040004B8 RID: 1208
		FAST_FORWARD = 2U,
		// Token: 0x040004B9 RID: 1209
		SKIP_BANK_LOAD = 4U
	}
}
