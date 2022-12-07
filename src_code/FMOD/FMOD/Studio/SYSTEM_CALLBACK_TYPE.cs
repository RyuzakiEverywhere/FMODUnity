using System;

namespace FMOD.Studio
{
	// Token: 0x020000C8 RID: 200
	[Flags]
	public enum SYSTEM_CALLBACK_TYPE : uint
	{
		// Token: 0x04000470 RID: 1136
		PREUPDATE = 1U,
		// Token: 0x04000471 RID: 1137
		POSTUPDATE = 2U,
		// Token: 0x04000472 RID: 1138
		BANK_UNLOAD = 4U,
		// Token: 0x04000473 RID: 1139
		LIVEUPDATE_CONNECTED = 8U,
		// Token: 0x04000474 RID: 1140
		LIVEUPDATE_DISCONNECTED = 16U,
		// Token: 0x04000475 RID: 1141
		ALL = 4294967295U
	}
}
