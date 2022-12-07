using System;
using System.Collections.Generic;

namespace FMODUnity
{
	// Token: 0x020000FB RID: 251
	public class PlatformDefault : Platform
	{
		// Token: 0x0600067B RID: 1659 RVA: 0x00006F4F File Offset: 0x0000514F
		public PlatformDefault()
		{
			base.Identifier = "default";
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600067C RID: 1660 RVA: 0x00006F62 File Offset: 0x00005162
		public override string DisplayName
		{
			get
			{
				return "Default";
			}
		}

		// Token: 0x0600067D RID: 1661 RVA: 0x00005DA4 File Offset: 0x00003FA4
		public override void DeclareUnityMappings(Settings settings)
		{
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600067E RID: 1662 RVA: 0x00006A19 File Offset: 0x00004C19
		public override bool IsIntrinsic
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600067F RID: 1663 RVA: 0x00006F6C File Offset: 0x0000516C
		public override void InitializeProperties()
		{
			base.InitializeProperties();
			Platform.PropertyAccessors.Plugins.Set(this, new List<string>());
			Platform.PropertyAccessors.StaticPlugins.Set(this, new List<string>());
		}

		// Token: 0x06000680 RID: 1664 RVA: 0x00006FA8 File Offset: 0x000051A8
		public override void EnsurePropertiesAreValid()
		{
			base.EnsurePropertiesAreValid();
			if (base.StaticPlugins == null)
			{
				Platform.PropertyAccessors.StaticPlugins.Set(this, new List<string>());
			}
		}

		// Token: 0x0400051E RID: 1310
		public const string ConstIdentifier = "default";
	}
}
