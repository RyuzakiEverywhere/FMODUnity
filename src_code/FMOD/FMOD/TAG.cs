using System;

namespace FMOD
{
	// Token: 0x02000033 RID: 51
	public struct TAG
	{
		// Token: 0x0400018E RID: 398
		public TAGTYPE type;

		// Token: 0x0400018F RID: 399
		public TAGDATATYPE datatype;

		// Token: 0x04000190 RID: 400
		public StringWrapper name;

		// Token: 0x04000191 RID: 401
		public IntPtr data;

		// Token: 0x04000192 RID: 402
		public uint datalen;

		// Token: 0x04000193 RID: 403
		public bool updated;
	}
}
