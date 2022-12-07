using System;

namespace FMOD
{
	// Token: 0x0200000F RID: 15
	[Flags]
	public enum CHANNELMASK : uint
	{
		// Token: 0x040000B7 RID: 183
		FRONT_LEFT = 1U,
		// Token: 0x040000B8 RID: 184
		FRONT_RIGHT = 2U,
		// Token: 0x040000B9 RID: 185
		FRONT_CENTER = 4U,
		// Token: 0x040000BA RID: 186
		LOW_FREQUENCY = 8U,
		// Token: 0x040000BB RID: 187
		SURROUND_LEFT = 16U,
		// Token: 0x040000BC RID: 188
		SURROUND_RIGHT = 32U,
		// Token: 0x040000BD RID: 189
		BACK_LEFT = 64U,
		// Token: 0x040000BE RID: 190
		BACK_RIGHT = 128U,
		// Token: 0x040000BF RID: 191
		BACK_CENTER = 256U,
		// Token: 0x040000C0 RID: 192
		MONO = 1U,
		// Token: 0x040000C1 RID: 193
		STEREO = 3U,
		// Token: 0x040000C2 RID: 194
		LRC = 7U,
		// Token: 0x040000C3 RID: 195
		QUAD = 51U,
		// Token: 0x040000C4 RID: 196
		SURROUND = 55U,
		// Token: 0x040000C5 RID: 197
		_5POINT1 = 63U,
		// Token: 0x040000C6 RID: 198
		_5POINT1_REARS = 207U,
		// Token: 0x040000C7 RID: 199
		_7POINT0 = 247U,
		// Token: 0x040000C8 RID: 200
		_7POINT1 = 255U
	}
}
