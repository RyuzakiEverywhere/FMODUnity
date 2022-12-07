using System;

namespace FMOD
{
	// Token: 0x0200000B RID: 11
	[Flags]
	public enum DEBUG_FLAGS : uint
	{
		// Token: 0x04000088 RID: 136
		NONE = 0U,
		// Token: 0x04000089 RID: 137
		ERROR = 1U,
		// Token: 0x0400008A RID: 138
		WARNING = 2U,
		// Token: 0x0400008B RID: 139
		LOG = 4U,
		// Token: 0x0400008C RID: 140
		TYPE_MEMORY = 256U,
		// Token: 0x0400008D RID: 141
		TYPE_FILE = 512U,
		// Token: 0x0400008E RID: 142
		TYPE_CODEC = 1024U,
		// Token: 0x0400008F RID: 143
		TYPE_TRACE = 2048U,
		// Token: 0x04000090 RID: 144
		DISPLAY_TIMESTAMPS = 65536U,
		// Token: 0x04000091 RID: 145
		DISPLAY_LINENUMBERS = 131072U,
		// Token: 0x04000092 RID: 146
		DISPLAY_THREAD = 262144U
	}
}
