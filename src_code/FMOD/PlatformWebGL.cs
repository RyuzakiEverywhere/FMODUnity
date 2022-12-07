using System;
using UnityEngine;

namespace FMODUnity
{
	// Token: 0x020000ED RID: 237
	public class PlatformWebGL : Platform
	{
		// Token: 0x06000614 RID: 1556 RVA: 0x0000667A File Offset: 0x0000487A
		static PlatformWebGL()
		{
			Settings.AddPlatformTemplate<PlatformWebGL>("46fbfdf3fc43db0458918377fd40293e");
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000615 RID: 1557 RVA: 0x00006686 File Offset: 0x00004886
		public override string DisplayName
		{
			get
			{
				return "WebGL";
			}
		}

		// Token: 0x06000616 RID: 1558 RVA: 0x0000668D File Offset: 0x0000488D
		public override void DeclareUnityMappings(Settings settings)
		{
			settings.DeclareRuntimePlatform(RuntimePlatform.WebGLPlayer, this);
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x00006698 File Offset: 0x00004898
		public override string GetPluginPath(string pluginName)
		{
			return string.Format("{0}/{1}.bc", this.GetPluginBasePath(), pluginName);
		}
	}
}
