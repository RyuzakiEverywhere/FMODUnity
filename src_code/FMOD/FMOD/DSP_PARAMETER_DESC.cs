using System;
using System.Runtime.InteropServices;

namespace FMOD
{
	// Token: 0x02000082 RID: 130
	public struct DSP_PARAMETER_DESC
	{
		// Token: 0x0400029C RID: 668
		public DSP_PARAMETER_TYPE type;

		// Token: 0x0400029D RID: 669
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] name;

		// Token: 0x0400029E RID: 670
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] label;

		// Token: 0x0400029F RID: 671
		public string description;

		// Token: 0x040002A0 RID: 672
		public DSP_PARAMETER_DESC_UNION desc;
	}
}
