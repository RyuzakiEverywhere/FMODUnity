using System;
using FMOD;

namespace FMODUnity
{
	// Token: 0x02000105 RID: 261
	public class SystemNotInitializedException : Exception
	{
		// Token: 0x060006D8 RID: 1752 RVA: 0x00008C5D File Offset: 0x00006E5D
		public SystemNotInitializedException(RESULT result, string location) : base(string.Format("[FMOD] Initialization failed : {2} : {0} : {1}", result.ToString(), Error.String(result), location))
		{
			this.Result = result;
			this.Location = location;
		}

		// Token: 0x060006D9 RID: 1753 RVA: 0x00008C91 File Offset: 0x00006E91
		public SystemNotInitializedException(Exception inner) : base("[FMOD] Initialization failed", inner)
		{
		}

		// Token: 0x0400053D RID: 1341
		public RESULT Result;

		// Token: 0x0400053E RID: 1342
		public string Location;
	}
}
