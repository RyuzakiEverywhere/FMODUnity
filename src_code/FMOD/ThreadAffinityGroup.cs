using System;
using System.Collections.Generic;

namespace FMODUnity
{
	// Token: 0x0200010A RID: 266
	[Serializable]
	public class ThreadAffinityGroup
	{
		// Token: 0x060006DA RID: 1754 RVA: 0x00008C9F File Offset: 0x00006E9F
		public ThreadAffinityGroup()
		{
		}

		// Token: 0x060006DB RID: 1755 RVA: 0x00008CB2 File Offset: 0x00006EB2
		public ThreadAffinityGroup(ThreadAffinityGroup other)
		{
			this.threads = new List<ThreadType>(other.threads);
			this.affinity = other.affinity;
		}

		// Token: 0x060006DC RID: 1756 RVA: 0x00008CE2 File Offset: 0x00006EE2
		public ThreadAffinityGroup(ThreadAffinity affinity, params ThreadType[] threads)
		{
			this.threads = new List<ThreadType>(threads);
			this.affinity = affinity;
		}

		// Token: 0x0400057B RID: 1403
		public List<ThreadType> threads = new List<ThreadType>();

		// Token: 0x0400057C RID: 1404
		public ThreadAffinity affinity;
	}
}
