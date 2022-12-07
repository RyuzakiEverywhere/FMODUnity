using System;
using FMOD;

namespace FMODUnity
{
	// Token: 0x02000104 RID: 260
	public class BankLoadException : Exception
	{
		// Token: 0x060006D6 RID: 1750 RVA: 0x00008C06 File Offset: 0x00006E06
		public BankLoadException(string path, RESULT result) : base(string.Format("[FMOD] Could not load bank '{0}' : {1} : {2}", path, result.ToString(), Error.String(result)))
		{
			this.Path = path;
			this.Result = result;
		}

		// Token: 0x060006D7 RID: 1751 RVA: 0x00008C3A File Offset: 0x00006E3A
		public BankLoadException(string path, string error) : base(string.Format("[FMOD] Could not load bank '{0}' : {1}", path, error))
		{
			this.Path = path;
			this.Result = RESULT.ERR_INTERNAL;
		}

		// Token: 0x0400053B RID: 1339
		public string Path;

		// Token: 0x0400053C RID: 1340
		public RESULT Result;
	}
}
