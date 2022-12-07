using System;

namespace FMODUnity
{
	// Token: 0x02000101 RID: 257
	public class EventNotFoundException : Exception
	{
		// Token: 0x060006D2 RID: 1746 RVA: 0x00008B7B File Offset: 0x00006D7B
		public EventNotFoundException(string path) : base("[FMOD] Event not found '" + path + "'")
		{
			this.Path = path;
		}

		// Token: 0x060006D3 RID: 1747 RVA: 0x00008B9A File Offset: 0x00006D9A
		public EventNotFoundException(Guid guid) : base(("[FMOD] Event not found " + guid.ToString("b")) ?? "")
		{
			this.Guid = guid;
		}

		// Token: 0x04000537 RID: 1335
		public Guid Guid;

		// Token: 0x04000538 RID: 1336
		public string Path;
	}
}
