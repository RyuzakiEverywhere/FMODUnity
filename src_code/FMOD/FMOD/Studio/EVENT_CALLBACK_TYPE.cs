﻿using System;

namespace FMOD.Studio
{
	// Token: 0x020000DB RID: 219
	[Flags]
	public enum EVENT_CALLBACK_TYPE : uint
	{
		// Token: 0x040004CB RID: 1227
		CREATED = 1U,
		// Token: 0x040004CC RID: 1228
		DESTROYED = 2U,
		// Token: 0x040004CD RID: 1229
		STARTING = 4U,
		// Token: 0x040004CE RID: 1230
		STARTED = 8U,
		// Token: 0x040004CF RID: 1231
		RESTARTED = 16U,
		// Token: 0x040004D0 RID: 1232
		STOPPED = 32U,
		// Token: 0x040004D1 RID: 1233
		START_FAILED = 64U,
		// Token: 0x040004D2 RID: 1234
		CREATE_PROGRAMMER_SOUND = 128U,
		// Token: 0x040004D3 RID: 1235
		DESTROY_PROGRAMMER_SOUND = 256U,
		// Token: 0x040004D4 RID: 1236
		PLUGIN_CREATED = 512U,
		// Token: 0x040004D5 RID: 1237
		PLUGIN_DESTROYED = 1024U,
		// Token: 0x040004D6 RID: 1238
		TIMELINE_MARKER = 2048U,
		// Token: 0x040004D7 RID: 1239
		TIMELINE_BEAT = 4096U,
		// Token: 0x040004D8 RID: 1240
		SOUND_PLAYED = 8192U,
		// Token: 0x040004D9 RID: 1241
		SOUND_STOPPED = 16384U,
		// Token: 0x040004DA RID: 1242
		REAL_TO_VIRTUAL = 32768U,
		// Token: 0x040004DB RID: 1243
		VIRTUAL_TO_REAL = 65536U,
		// Token: 0x040004DC RID: 1244
		START_EVENT_COMMAND = 131072U,
		// Token: 0x040004DD RID: 1245
		NESTED_TIMELINE_BEAT = 262144U,
		// Token: 0x040004DE RID: 1246
		ALL = 4294967295U
	}
}