using System;
using UnityEngine;

namespace FMODUnity
{
	// Token: 0x020000EC RID: 236
	public class PlatformAndroid : Platform
	{
		// Token: 0x0600060C RID: 1548 RVA: 0x0000661F File Offset: 0x0000481F
		static PlatformAndroid()
		{
			Settings.AddPlatformTemplate<PlatformAndroid>("2fea114e74ecf3c4f920e1d5cc1c4c40");
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600060D RID: 1549 RVA: 0x0000662B File Offset: 0x0000482B
		public override string DisplayName
		{
			get
			{
				return "Android";
			}
		}

		// Token: 0x0600060E RID: 1550 RVA: 0x00006632 File Offset: 0x00004832
		public override void DeclareUnityMappings(Settings settings)
		{
			settings.DeclareRuntimePlatform(RuntimePlatform.Android, this);
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x0000663D File Offset: 0x0000483D
		public override string GetBankFolder()
		{
			return PlatformAndroid.StaticGetBankFolder();
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x00006644 File Offset: 0x00004844
		public static string StaticGetBankFolder()
		{
			if (!Settings.Instance.AndroidUseOBB)
			{
				return "file:///android_asset";
			}
			return Application.streamingAssetsPath;
		}

		// Token: 0x06000611 RID: 1553 RVA: 0x0000665D File Offset: 0x0000485D
		public override string GetPluginPath(string pluginName)
		{
			return PlatformAndroid.StaticGetPluginPath(pluginName);
		}

		// Token: 0x06000612 RID: 1554 RVA: 0x00006665 File Offset: 0x00004865
		public static string StaticGetPluginPath(string pluginName)
		{
			return string.Format("lib{0}.so", pluginName);
		}
	}
}
