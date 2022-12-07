using System;
using System.Collections.Generic;

namespace FMODUnity
{
	// Token: 0x02000111 RID: 273
	public static class Legacy
	{
		// Token: 0x06000708 RID: 1800 RVA: 0x00009790 File Offset: 0x00007990
		public static void CopySetting<T, U>(List<T> list, Legacy.Platform fromPlatform, Legacy.Platform toPlatform) where T : Legacy.PlatformSetting<U>, new()
		{
			T t = list.Find((T x) => x.Platform == fromPlatform);
			T t2 = list.Find((T x) => x.Platform == toPlatform);
			if (t != null)
			{
				if (t2 == null)
				{
					T t3 = Activator.CreateInstance<T>();
					t3.Platform = toPlatform;
					t2 = t3;
					list.Add(t2);
				}
				t2.Value = t.Value;
				return;
			}
			if (t2 != null)
			{
				list.Remove(t2);
			}
		}

		// Token: 0x06000709 RID: 1801 RVA: 0x0000982C File Offset: 0x00007A2C
		public static void CopySetting(List<Legacy.PlatformBoolSetting> list, Legacy.Platform fromPlatform, Legacy.Platform toPlatform)
		{
			Legacy.CopySetting<Legacy.PlatformBoolSetting, TriStateBool>(list, fromPlatform, toPlatform);
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x00009836 File Offset: 0x00007A36
		public static void CopySetting(List<Legacy.PlatformIntSetting> list, Legacy.Platform fromPlatform, Legacy.Platform toPlatform)
		{
			Legacy.CopySetting<Legacy.PlatformIntSetting, int>(list, fromPlatform, toPlatform);
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x00009840 File Offset: 0x00007A40
		public static string DisplayName(Legacy.Platform platform)
		{
			switch (platform)
			{
			case Legacy.Platform.Desktop:
				return "Desktop";
			case Legacy.Platform.Mobile:
				return "Mobile";
			case Legacy.Platform.MobileHigh:
				return "High-End Mobile";
			case Legacy.Platform.MobileLow:
				return "Low-End Mobile";
			case Legacy.Platform.Console:
				return "Console";
			case Legacy.Platform.Windows:
				return "Windows";
			case Legacy.Platform.Mac:
				return "OSX";
			case Legacy.Platform.Linux:
				return "Linux";
			case Legacy.Platform.iOS:
				return "iOS";
			case Legacy.Platform.Android:
				return "Android";
			case Legacy.Platform.XboxOne:
				return "XBox One";
			case Legacy.Platform.PS4:
				return "PS4";
			case Legacy.Platform.AppleTV:
				return "Apple TV";
			case Legacy.Platform.UWP:
				return "UWP";
			case Legacy.Platform.Switch:
				return "Switch";
			case Legacy.Platform.WebGL:
				return "WebGL";
			case Legacy.Platform.Stadia:
				return "Stadia";
			}
			return "Unknown";
		}

		// Token: 0x0600070C RID: 1804 RVA: 0x00009914 File Offset: 0x00007B14
		public static float SortOrder(Legacy.Platform legacyPlatform)
		{
			switch (legacyPlatform)
			{
			case Legacy.Platform.Desktop:
				return 1f;
			case Legacy.Platform.Mobile:
				return 2f;
			case Legacy.Platform.MobileHigh:
				return 2.1f;
			case Legacy.Platform.MobileLow:
				return 2.2f;
			case Legacy.Platform.Console:
				return 3f;
			case Legacy.Platform.Windows:
				return 1.1f;
			case Legacy.Platform.Mac:
				return 1.2f;
			case Legacy.Platform.Linux:
				return 1.3f;
			case Legacy.Platform.XboxOne:
				return 3.1f;
			case Legacy.Platform.PS4:
				return 3.2f;
			case Legacy.Platform.AppleTV:
				return 2.3f;
			case Legacy.Platform.Switch:
				return 3.3f;
			case Legacy.Platform.Stadia:
				return 3.4f;
			}
			return 0f;
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x000099D0 File Offset: 0x00007BD0
		public static Legacy.Platform Parent(Legacy.Platform platform)
		{
			switch (platform)
			{
			case Legacy.Platform.Desktop:
			case Legacy.Platform.Mobile:
			case Legacy.Platform.Console:
				return Legacy.Platform.Default;
			case Legacy.Platform.MobileHigh:
			case Legacy.Platform.MobileLow:
			case Legacy.Platform.iOS:
			case Legacy.Platform.Android:
			case Legacy.Platform.AppleTV:
				return Legacy.Platform.Mobile;
			case Legacy.Platform.Windows:
			case Legacy.Platform.Mac:
			case Legacy.Platform.Linux:
			case Legacy.Platform.UWP:
			case Legacy.Platform.WebGL:
				return Legacy.Platform.Desktop;
			case Legacy.Platform.XboxOne:
			case Legacy.Platform.PS4:
			case Legacy.Platform.Switch:
			case Legacy.Platform.Stadia:
			case Legacy.Platform.Reserved_1:
			case Legacy.Platform.Reserved_2:
			case Legacy.Platform.Reserved_3:
				return Legacy.Platform.Console;
			}
			return Legacy.Platform.None;
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x00009A54 File Offset: 0x00007C54
		public static bool IsGroup(Legacy.Platform platform)
		{
			return platform - Legacy.Platform.Desktop <= 1 || platform == Legacy.Platform.Console;
		}

		// Token: 0x02000137 RID: 311
		[Serializable]
		public enum Platform
		{
			// Token: 0x0400064C RID: 1612
			None,
			// Token: 0x0400064D RID: 1613
			PlayInEditor,
			// Token: 0x0400064E RID: 1614
			Default,
			// Token: 0x0400064F RID: 1615
			Desktop,
			// Token: 0x04000650 RID: 1616
			Mobile,
			// Token: 0x04000651 RID: 1617
			MobileHigh,
			// Token: 0x04000652 RID: 1618
			MobileLow,
			// Token: 0x04000653 RID: 1619
			Console,
			// Token: 0x04000654 RID: 1620
			Windows,
			// Token: 0x04000655 RID: 1621
			Mac,
			// Token: 0x04000656 RID: 1622
			Linux,
			// Token: 0x04000657 RID: 1623
			iOS,
			// Token: 0x04000658 RID: 1624
			Android,
			// Token: 0x04000659 RID: 1625
			Deprecated_1,
			// Token: 0x0400065A RID: 1626
			XboxOne,
			// Token: 0x0400065B RID: 1627
			PS4,
			// Token: 0x0400065C RID: 1628
			Deprecated_2,
			// Token: 0x0400065D RID: 1629
			Deprecated_3,
			// Token: 0x0400065E RID: 1630
			AppleTV,
			// Token: 0x0400065F RID: 1631
			UWP,
			// Token: 0x04000660 RID: 1632
			Switch,
			// Token: 0x04000661 RID: 1633
			WebGL,
			// Token: 0x04000662 RID: 1634
			Stadia,
			// Token: 0x04000663 RID: 1635
			Reserved_1,
			// Token: 0x04000664 RID: 1636
			Reserved_2,
			// Token: 0x04000665 RID: 1637
			Reserved_3,
			// Token: 0x04000666 RID: 1638
			Count
		}

		// Token: 0x02000138 RID: 312
		public class PlatformSettingBase
		{
			// Token: 0x04000667 RID: 1639
			public Legacy.Platform Platform;
		}

		// Token: 0x02000139 RID: 313
		public class PlatformSetting<T> : Legacy.PlatformSettingBase
		{
			// Token: 0x04000668 RID: 1640
			public T Value;
		}

		// Token: 0x0200013A RID: 314
		[Serializable]
		public class PlatformIntSetting : Legacy.PlatformSetting<int>
		{
		}

		// Token: 0x0200013B RID: 315
		[Serializable]
		public class PlatformStringSetting : Legacy.PlatformSetting<string>
		{
		}

		// Token: 0x0200013C RID: 316
		[Serializable]
		public class PlatformBoolSetting : Legacy.PlatformSetting<TriStateBool>
		{
		}
	}
}
