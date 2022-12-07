using System;

namespace FMODUnity
{
	// Token: 0x020000FD RID: 253
	public class PlatformMobileHigh : PlatformMobileLow
	{
		// Token: 0x06000684 RID: 1668 RVA: 0x00006FDE File Offset: 0x000051DE
		static PlatformMobileHigh()
		{
			Settings.AddPlatformTemplate<PlatformMobileHigh>("fd7c55dab0fce234b8c25f6ffca523c1");
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000685 RID: 1669 RVA: 0x00006FEA File Offset: 0x000051EA
		public override string DisplayName
		{
			get
			{
				return "High-End Mobile";
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000686 RID: 1670 RVA: 0x00006FF1 File Offset: 0x000051F1
		public override float Priority
		{
			get
			{
				return base.Priority + 1f;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000687 RID: 1671 RVA: 0x00006FFF File Offset: 0x000051FF
		public override bool MatchesCurrentEnvironment
		{
			get
			{
				bool active = base.Active;
				return false;
			}
		}
	}
}
