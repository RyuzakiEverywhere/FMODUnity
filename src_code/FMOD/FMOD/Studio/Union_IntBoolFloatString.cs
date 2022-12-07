using System;
using System.Runtime.InteropServices;

namespace FMOD.Studio
{
	// Token: 0x020000D3 RID: 211
	[StructLayout(LayoutKind.Explicit)]
	internal struct Union_IntBoolFloatString
	{
		// Token: 0x040004A0 RID: 1184
		[FieldOffset(0)]
		public int intvalue;

		// Token: 0x040004A1 RID: 1185
		[FieldOffset(0)]
		public bool boolvalue;

		// Token: 0x040004A2 RID: 1186
		[FieldOffset(0)]
		public float floatvalue;

		// Token: 0x040004A3 RID: 1187
		[FieldOffset(0)]
		public StringWrapper stringvalue;
	}
}
