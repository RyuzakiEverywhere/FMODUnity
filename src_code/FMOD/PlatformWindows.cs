using System;
using UnityEngine;

namespace FMODUnity
{
	// Token: 0x020000F2 RID: 242
	public class PlatformWindows : Platform
	{
		// Token: 0x0600062E RID: 1582 RVA: 0x0000675B File Offset: 0x0000495B
		static PlatformWindows()
		{
			Settings.AddPlatformTemplate<PlatformWindows>("2c5177b11d81d824dbb064f9ac8527da");
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600062F RID: 1583 RVA: 0x00006767 File Offset: 0x00004967
		public override string DisplayName
		{
			get
			{
				return "Windows";
			}
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x0000676E File Offset: 0x0000496E
		public override void DeclareUnityMappings(Settings settings)
		{
			settings.DeclareRuntimePlatform(RuntimePlatform.WindowsPlayer, this);
			settings.DeclareRuntimePlatform(RuntimePlatform.MetroPlayerX86, this);
			settings.DeclareRuntimePlatform(RuntimePlatform.MetroPlayerX64, this);
			settings.DeclareRuntimePlatform(RuntimePlatform.MetroPlayerARM, this);
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x00006793 File Offset: 0x00004993
		public override string GetPluginPath(string pluginName)
		{
			return string.Format("{0}/X86_64/{1}.dll", this.GetPluginBasePath(), pluginName);
		}
	}
}
