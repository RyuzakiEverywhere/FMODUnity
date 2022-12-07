using System;
using UnityEngine;

namespace FMODUnity
{
	// Token: 0x020000FC RID: 252
	public class PlatformGroup : Platform
	{
		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000681 RID: 1665 RVA: 0x00006FD6 File Offset: 0x000051D6
		public override string DisplayName
		{
			get
			{
				return this.displayName;
			}
		}

		// Token: 0x06000682 RID: 1666 RVA: 0x00005DA4 File Offset: 0x00003FA4
		public override void DeclareUnityMappings(Settings settings)
		{
		}

		// Token: 0x0400051F RID: 1311
		[SerializeField]
		public string displayName;

		// Token: 0x04000520 RID: 1312
		[SerializeField]
		private Legacy.Platform legacyIdentifier;
	}
}
