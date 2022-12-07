using System;
using UnityEngine;

namespace FMODUnity
{
	// Token: 0x020000FE RID: 254
	public class PlatformMobileLow : Platform
	{
		// Token: 0x06000689 RID: 1673 RVA: 0x00007011 File Offset: 0x00005211
		static PlatformMobileLow()
		{
			Settings.AddPlatformTemplate<PlatformMobileLow>("c88d16e5272a4e241b0ef0ac2e53b73d");
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600068A RID: 1674 RVA: 0x0000701D File Offset: 0x0000521D
		public override string DisplayName
		{
			get
			{
				return "Low-End Mobile";
			}
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x00007024 File Offset: 0x00005224
		public override void DeclareUnityMappings(Settings settings)
		{
			settings.DeclareRuntimePlatform(RuntimePlatform.IPhonePlayer, this);
			settings.DeclareRuntimePlatform(RuntimePlatform.Android, this);
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600068C RID: 1676 RVA: 0x00007037 File Offset: 0x00005237
		public override float Priority
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600068D RID: 1677 RVA: 0x0000703E File Offset: 0x0000523E
		public override bool MatchesCurrentEnvironment
		{
			get
			{
				return base.Active;
			}
		}
	}
}
