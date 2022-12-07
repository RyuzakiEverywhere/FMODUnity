using System;
using UnityEngine;

namespace FMODUnity
{
	// Token: 0x020000EF RID: 239
	public class PlatformLinux : Platform
	{
		// Token: 0x0600061F RID: 1567 RVA: 0x000066DC File Offset: 0x000048DC
		static PlatformLinux()
		{
			Settings.AddPlatformTemplate<PlatformLinux>("b7716510a1f36934c87976f3a81dbf3d");
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000620 RID: 1568 RVA: 0x000066E8 File Offset: 0x000048E8
		public override string DisplayName
		{
			get
			{
				return "Linux";
			}
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x000066EF File Offset: 0x000048EF
		public override void DeclareUnityMappings(Settings settings)
		{
			settings.DeclareRuntimePlatform(RuntimePlatform.LinuxPlayer, this);
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x000066FA File Offset: 0x000048FA
		public override string GetPluginPath(string pluginName)
		{
			return string.Format("{0}/lib{1}.so", this.GetPluginBasePath(), pluginName);
		}
	}
}
