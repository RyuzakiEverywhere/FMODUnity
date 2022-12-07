using System;

namespace FMODUnity
{
	// Token: 0x02000102 RID: 258
	public class BusNotFoundException : Exception
	{
		// Token: 0x060006D4 RID: 1748 RVA: 0x00008BC8 File Offset: 0x00006DC8
		public BusNotFoundException(string path) : base("[FMOD] Bus not found '" + path + "'")
		{
			this.Path = path;
		}

		// Token: 0x04000539 RID: 1337
		public string Path;
	}
}
