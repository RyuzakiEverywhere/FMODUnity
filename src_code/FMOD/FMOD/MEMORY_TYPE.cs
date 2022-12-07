using System;

namespace FMOD
{
	// Token: 0x0200000C RID: 12
	[Flags]
	public enum MEMORY_TYPE : uint
	{
		// Token: 0x04000094 RID: 148
		NORMAL = 0U,
		// Token: 0x04000095 RID: 149
		STREAM_FILE = 1U,
		// Token: 0x04000096 RID: 150
		STREAM_DECODE = 2U,
		// Token: 0x04000097 RID: 151
		SAMPLEDATA = 4U,
		// Token: 0x04000098 RID: 152
		DSP_BUFFER = 8U,
		// Token: 0x04000099 RID: 153
		PLUGIN = 16U,
		// Token: 0x0400009A RID: 154
		PERSISTENT = 2097152U,
		// Token: 0x0400009B RID: 155
		ALL = 4294967295U
	}
}
