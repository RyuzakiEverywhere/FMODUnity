using System;

namespace FMOD
{
	// Token: 0x0200001C RID: 28
	public struct ERRORCALLBACK_INFO
	{
		// Token: 0x04000154 RID: 340
		public RESULT result;

		// Token: 0x04000155 RID: 341
		public ERRORCALLBACK_INSTANCETYPE instancetype;

		// Token: 0x04000156 RID: 342
		public IntPtr instance;

		// Token: 0x04000157 RID: 343
		public StringWrapper functionname;

		// Token: 0x04000158 RID: 344
		public StringWrapper functionparams;
	}
}
