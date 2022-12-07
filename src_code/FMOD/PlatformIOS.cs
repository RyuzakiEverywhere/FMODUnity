using System;
using FMOD;
using UnityEngine;

namespace FMODUnity
{
	// Token: 0x020000EE RID: 238
	public class PlatformIOS : Platform
	{
		// Token: 0x06000619 RID: 1561 RVA: 0x000066AB File Offset: 0x000048AB
		static PlatformIOS()
		{
			Settings.AddPlatformTemplate<PlatformIOS>("0f8eb3f400726694eb47beb1a9f94ce8");
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600061A RID: 1562 RVA: 0x000066B7 File Offset: 0x000048B7
		public override string DisplayName
		{
			get
			{
				return "iOS";
			}
		}

		// Token: 0x0600061B RID: 1563 RVA: 0x000066BE File Offset: 0x000048BE
		public override void DeclareUnityMappings(Settings settings)
		{
			settings.DeclareRuntimePlatform(RuntimePlatform.IPhonePlayer, this);
		}

		// Token: 0x0600061C RID: 1564 RVA: 0x000066C8 File Offset: 0x000048C8
		public override void LoadPlugins(System coreSystem, Action<RESULT, string> reportResult)
		{
			PlatformIOS.StaticLoadPlugins(this, coreSystem, reportResult);
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x000066D2 File Offset: 0x000048D2
		public static void StaticLoadPlugins(Platform platform, System coreSystem, Action<RESULT, string> reportResult)
		{
			platform.LoadStaticPlugins(coreSystem, reportResult);
		}
	}
}
