using System;

namespace FMOD.Studio
{
	// Token: 0x020000D4 RID: 212
	[Flags]
	public enum INITFLAGS : uint
	{
		// Token: 0x040004A5 RID: 1189
		NORMAL = 0U,
		// Token: 0x040004A6 RID: 1190
		LIVEUPDATE = 1U,
		// Token: 0x040004A7 RID: 1191
		ALLOW_MISSING_PLUGINS = 2U,
		// Token: 0x040004A8 RID: 1192
		SYNCHRONOUS_UPDATE = 4U,
		// Token: 0x040004A9 RID: 1193
		DEFERRED_CALLBACKS = 8U,
		// Token: 0x040004AA RID: 1194
		LOAD_FROM_UPDATE = 16U,
		// Token: 0x040004AB RID: 1195
		MEMORY_TRACKING = 32U
	}
}
