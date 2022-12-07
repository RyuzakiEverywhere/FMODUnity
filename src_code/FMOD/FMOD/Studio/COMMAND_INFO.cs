using System;

namespace FMOD.Studio
{
	// Token: 0x020000E1 RID: 225
	public struct COMMAND_INFO
	{
		// Token: 0x040004E9 RID: 1257
		public StringWrapper commandname;

		// Token: 0x040004EA RID: 1258
		public int parentcommandindex;

		// Token: 0x040004EB RID: 1259
		public int framenumber;

		// Token: 0x040004EC RID: 1260
		public float frametime;

		// Token: 0x040004ED RID: 1261
		public INSTANCETYPE instancetype;

		// Token: 0x040004EE RID: 1262
		public INSTANCETYPE outputtype;

		// Token: 0x040004EF RID: 1263
		public uint instancehandle;

		// Token: 0x040004F0 RID: 1264
		public uint outputhandle;
	}
}
