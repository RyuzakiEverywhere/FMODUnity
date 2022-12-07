using System;
using System.Runtime.InteropServices;

namespace FMOD
{
	// Token: 0x02000081 RID: 129
	[StructLayout(LayoutKind.Explicit)]
	public struct DSP_PARAMETER_DESC_UNION
	{
		// Token: 0x04000298 RID: 664
		[FieldOffset(0)]
		public DSP_PARAMETER_DESC_FLOAT floatdesc;

		// Token: 0x04000299 RID: 665
		[FieldOffset(0)]
		public DSP_PARAMETER_DESC_INT intdesc;

		// Token: 0x0400029A RID: 666
		[FieldOffset(0)]
		public DSP_PARAMETER_DESC_BOOL booldesc;

		// Token: 0x0400029B RID: 667
		[FieldOffset(0)]
		public DSP_PARAMETER_DESC_DATA datadesc;
	}
}
