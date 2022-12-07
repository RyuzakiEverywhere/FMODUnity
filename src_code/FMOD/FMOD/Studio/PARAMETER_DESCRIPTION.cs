using System;

namespace FMOD.Studio
{
	// Token: 0x020000CD RID: 205
	public struct PARAMETER_DESCRIPTION
	{
		// Token: 0x04000488 RID: 1160
		public StringWrapper name;

		// Token: 0x04000489 RID: 1161
		public PARAMETER_ID id;

		// Token: 0x0400048A RID: 1162
		public float minimum;

		// Token: 0x0400048B RID: 1163
		public float maximum;

		// Token: 0x0400048C RID: 1164
		public float defaultvalue;

		// Token: 0x0400048D RID: 1165
		public PARAMETER_TYPE type;

		// Token: 0x0400048E RID: 1166
		public PARAMETER_FLAGS flags;
	}
}
