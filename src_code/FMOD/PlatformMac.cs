using System;
using UnityEngine;

namespace FMODUnity
{
	// Token: 0x020000F0 RID: 240
	public class PlatformMac : Platform
	{
		// Token: 0x06000624 RID: 1572 RVA: 0x0000670D File Offset: 0x0000490D
		static PlatformMac()
		{
			Settings.AddPlatformTemplate<PlatformMac>("52eb9df5db46521439908db3a29a1bbb");
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000625 RID: 1573 RVA: 0x00006719 File Offset: 0x00004919
		public override string DisplayName
		{
			get
			{
				return "macOS";
			}
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x00006720 File Offset: 0x00004920
		public override void DeclareUnityMappings(Settings settings)
		{
			settings.DeclareRuntimePlatform(RuntimePlatform.OSXPlayer, this);
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x0000672A File Offset: 0x0000492A
		public override string GetPluginPath(string pluginName)
		{
			return string.Format("{0}/{1}.bundle", this.GetPluginBasePath(), pluginName);
		}
	}
}
