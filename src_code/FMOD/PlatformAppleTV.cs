using System;
using FMOD;
using UnityEngine;

namespace FMODUnity
{
	// Token: 0x020000F1 RID: 241
	public class PlatformAppleTV : Platform
	{
		// Token: 0x06000629 RID: 1577 RVA: 0x0000673D File Offset: 0x0000493D
		static PlatformAppleTV()
		{
			Settings.AddPlatformTemplate<PlatformAppleTV>("e7a046c753c3c3d4aacc91f6597f310d");
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600062A RID: 1578 RVA: 0x00006749 File Offset: 0x00004949
		public override string DisplayName
		{
			get
			{
				return "Apple TV";
			}
		}

		// Token: 0x0600062B RID: 1579 RVA: 0x00006750 File Offset: 0x00004950
		public override void DeclareUnityMappings(Settings settings)
		{
			settings.DeclareRuntimePlatform(RuntimePlatform.tvOS, this);
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x000066C8 File Offset: 0x000048C8
		public override void LoadPlugins(System coreSystem, Action<RESULT, string> reportResult)
		{
			PlatformIOS.StaticLoadPlugins(this, coreSystem, reportResult);
		}
	}
}
