using System;
using System.Runtime.InteropServices;

namespace FMOD
{
	// Token: 0x02000086 RID: 134
	public struct DSP_PARAMETER_3DATTRIBUTES_MULTI
	{
		// Token: 0x040002AC RID: 684
		public int numlisteners;

		// Token: 0x040002AD RID: 685
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public ATTRIBUTES_3D[] relative;

		// Token: 0x040002AE RID: 686
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public float[] weight;

		// Token: 0x040002AF RID: 687
		public ATTRIBUTES_3D absolute;
	}
}
