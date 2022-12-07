using System;
using System.Collections.Generic;
using System.Linq;
using FMOD;
using UnityEngine;

namespace FMODUnity
{
	// Token: 0x02000110 RID: 272
	public class Settings : ScriptableObject
	{
		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060006EB RID: 1771 RVA: 0x000090F8 File Offset: 0x000072F8
		public static Settings Instance
		{
			get
			{
				if (Settings.isInitializing)
				{
					return null;
				}
				if (Settings.instance == null)
				{
					Settings.isInitializing = true;
					Settings.instance = (Resources.Load("FMODStudioSettings") as Settings);
					if (Settings.instance == null)
					{
						UnityEngine.Debug.Log("[FMOD] Cannot find integration settings, creating default settings");
						Settings.instance = ScriptableObject.CreateInstance<Settings>();
						Settings.instance.name = "FMOD Studio Integration Settings";
					}
					Settings.isInitializing = false;
				}
				return Settings.instance;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060006EC RID: 1772 RVA: 0x00009170 File Offset: 0x00007370
		// (set) Token: 0x060006ED RID: 1773 RVA: 0x00009178 File Offset: 0x00007378
		public string SourceProjectPath
		{
			get
			{
				return this.sourceProjectPath;
			}
			set
			{
				this.sourceProjectPath = value;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060006EE RID: 1774 RVA: 0x00009181 File Offset: 0x00007381
		// (set) Token: 0x060006EF RID: 1775 RVA: 0x00009189 File Offset: 0x00007389
		public string SourceBankPath
		{
			get
			{
				return this.sourceBankPath;
			}
			set
			{
				this.sourceBankPath = value;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060006F0 RID: 1776 RVA: 0x00009194 File Offset: 0x00007394
		public string TargetPath
		{
			get
			{
				if (this.ImportType == ImportType.AssetBundle)
				{
					if (string.IsNullOrEmpty(this.TargetAssetPath))
					{
						return Application.dataPath;
					}
					return Application.dataPath + "/" + this.TargetAssetPath;
				}
				else
				{
					if (string.IsNullOrEmpty(this.TargetBankFolder))
					{
						return Application.streamingAssetsPath;
					}
					return Application.streamingAssetsPath + "/" + this.TargetBankFolder;
				}
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060006F1 RID: 1777 RVA: 0x000091FB File Offset: 0x000073FB
		// (set) Token: 0x060006F2 RID: 1778 RVA: 0x00009213 File Offset: 0x00007413
		public string TargetSubFolder
		{
			get
			{
				if (this.ImportType == ImportType.AssetBundle)
				{
					return this.TargetAssetPath;
				}
				return this.TargetBankFolder;
			}
			set
			{
				if (this.ImportType == ImportType.AssetBundle)
				{
					this.TargetAssetPath = value;
					return;
				}
				this.TargetBankFolder = value;
			}
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x00009230 File Offset: 0x00007430
		public Platform FindPlatform(string identifier)
		{
			foreach (Platform platform in this.Platforms)
			{
				if (platform.Identifier == identifier)
				{
					return platform;
				}
			}
			return null;
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x00009294 File Offset: 0x00007494
		public bool PlatformExists(string identifier)
		{
			return this.FindPlatform(identifier) != null;
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x000092A4 File Offset: 0x000074A4
		public void ForEachPlatform(Action<Platform> action)
		{
			foreach (Platform obj in this.Platforms)
			{
				action(obj);
			}
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x000092F8 File Offset: 0x000074F8
		public IEnumerable<Platform> EnumeratePlatforms()
		{
			return this.Platforms;
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x00009300 File Offset: 0x00007500
		private void AddPlatform(Platform platform)
		{
			if (this.PlatformExists(platform.Identifier))
			{
				throw new ArgumentException(string.Format("Duplicate platform identifier: {0}", platform.Identifier));
			}
			this.Platforms.Add(platform);
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x00009334 File Offset: 0x00007534
		public void RemovePlatform(string identifier)
		{
			this.Platforms.RemoveAll((Platform p) => p.Identifier == identifier);
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060006F9 RID: 1785 RVA: 0x00009366 File Offset: 0x00007566
		public Platform DefaultPlatform
		{
			get
			{
				return this.defaultPlatform;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060006FA RID: 1786 RVA: 0x0000936E File Offset: 0x0000756E
		public Platform PlayInEditorPlatform
		{
			get
			{
				return this.playInEditorPlatform;
			}
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x00009376 File Offset: 0x00007576
		private void LinkPlatform(Platform platform)
		{
			this.LinkPlatformToParent(platform);
			platform.DeclareUnityMappings(this);
		}

		// Token: 0x060006FC RID: 1788 RVA: 0x00009388 File Offset: 0x00007588
		public void DeclareRuntimePlatform(RuntimePlatform runtimePlatform, Platform platform)
		{
			List<Platform> list;
			if (!this.PlatformForRuntimePlatform.TryGetValue(runtimePlatform, out list))
			{
				list = new List<Platform>();
				this.PlatformForRuntimePlatform.Add(runtimePlatform, list);
			}
			list.Add(platform);
			list.Sort((Platform a, Platform b) => b.Priority.CompareTo(a.Priority));
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x000093E4 File Offset: 0x000075E4
		private void LinkPlatformToParent(Platform platform)
		{
			if (!string.IsNullOrEmpty(platform.ParentIdentifier))
			{
				this.SetPlatformParent(platform, this.FindPlatform(platform.ParentIdentifier));
			}
		}

		// Token: 0x060006FE RID: 1790 RVA: 0x00009408 File Offset: 0x00007608
		public Platform FindCurrentPlatform()
		{
			List<Platform> list;
			if (this.PlatformForRuntimePlatform.TryGetValue(Application.platform, out list))
			{
				foreach (Platform platform in list)
				{
					if (platform.MatchesCurrentEnvironment)
					{
						return platform;
					}
				}
			}
			return this.defaultPlatform;
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x00009478 File Offset: 0x00007678
		public SPEAKERMODE GetEditorSpeakerMode()
		{
			return this.playInEditorPlatform.SpeakerMode;
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x00009488 File Offset: 0x00007688
		private Settings()
		{
			this.MasterBanks = new List<string>();
			this.Banks = new List<string>();
			this.BanksToLoad = new List<string>();
			this.RealChannelSettings = new List<Legacy.PlatformIntSetting>();
			this.VirtualChannelSettings = new List<Legacy.PlatformIntSetting>();
			this.LoggingSettings = new List<Legacy.PlatformBoolSetting>();
			this.LiveUpdateSettings = new List<Legacy.PlatformBoolSetting>();
			this.OverlaySettings = new List<Legacy.PlatformBoolSetting>();
			this.SampleRateSettings = new List<Legacy.PlatformIntSetting>();
			this.SpeakerModeSettings = new List<Legacy.PlatformIntSetting>();
			this.BankDirectorySettings = new List<Legacy.PlatformStringSetting>();
			this.ImportType = ImportType.StreamingAssets;
			this.AutomaticEventLoading = true;
			this.AutomaticSampleLoading = false;
			this.EnableMemoryTracking = false;
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x00009595 File Offset: 0x00007795
		public void AddPlatformProperties(Platform platform)
		{
			platform.AffirmProperties();
			this.LinkPlatformToParent(platform);
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x000095A4 File Offset: 0x000077A4
		public void SetPlatformParent(Platform platform, Platform newParent)
		{
			platform.Parent = newParent;
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x000095B0 File Offset: 0x000077B0
		public static void AddPlatformTemplate<T>(string identifier) where T : Platform
		{
			Settings.platformTemplates.Add(new Settings.PlatformTemplate
			{
				Identifier = identifier,
				CreateInstance = (() => Settings.CreatePlatformInstance<T>(identifier))
			});
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x000095FD File Offset: 0x000077FD
		private static Platform CreatePlatformInstance<T>(string identifier) where T : Platform
		{
			T t = ScriptableObject.CreateInstance<T>();
			t.InitializeProperties();
			t.Identifier = identifier;
			return t;
		}

		// Token: 0x06000705 RID: 1797 RVA: 0x00009618 File Offset: 0x00007818
		private void OnEnable()
		{
			if (this.hasLoaded)
			{
				return;
			}
			this.hasLoaded = true;
			this.PopulatePlatformsFromAsset();
			this.defaultPlatform = this.Platforms.FirstOrDefault((Platform platform) => platform is PlatformDefault);
			this.playInEditorPlatform = this.Platforms.FirstOrDefault((Platform platform) => platform is PlatformPlayInEditor);
			this.ForEachPlatform(new Action<Platform>(this.LinkPlatform));
		}

		// Token: 0x06000706 RID: 1798 RVA: 0x000096B0 File Offset: 0x000078B0
		private void PopulatePlatformsFromAsset()
		{
			this.Platforms.Clear();
			foreach (Platform platform in Resources.LoadAll<Platform>("FMODStudioSettings"))
			{
				Platform platform2 = this.FindPlatform(platform.Identifier);
				if (platform2 != null)
				{
					Platform platform3;
					if (platform.Active && !platform2.Active)
					{
						this.RemovePlatform(platform2.Identifier);
						platform3 = platform2;
						platform2 = null;
					}
					else
					{
						platform3 = platform;
					}
					UnityEngine.Debug.LogWarningFormat("FMOD: Cleaning up duplicate platform: ID  = {0}, name = '{1}', type = {2}", new object[]
					{
						platform3.Identifier,
						platform3.DisplayName,
						platform3.GetType().Name
					});
					Object.DestroyImmediate(platform3, true);
				}
				if (platform2 == null)
				{
					platform.EnsurePropertiesAreValid();
					this.AddPlatform(platform);
				}
			}
		}

		// Token: 0x0400058C RID: 1420
		private const string SettingsAssetName = "FMODStudioSettings";

		// Token: 0x0400058D RID: 1421
		private static Settings instance = null;

		// Token: 0x0400058E RID: 1422
		private static bool isInitializing = false;

		// Token: 0x0400058F RID: 1423
		[SerializeField]
		public bool HasSourceProject = true;

		// Token: 0x04000590 RID: 1424
		[SerializeField]
		public bool HasPlatforms = true;

		// Token: 0x04000591 RID: 1425
		[SerializeField]
		private string sourceProjectPath;

		// Token: 0x04000592 RID: 1426
		[SerializeField]
		private string sourceBankPath;

		// Token: 0x04000593 RID: 1427
		[SerializeField]
		public string SourceBankPathUnformatted;

		// Token: 0x04000594 RID: 1428
		[SerializeField]
		public int BankRefreshCooldown = 5;

		// Token: 0x04000595 RID: 1429
		[SerializeField]
		public bool ShowBankRefreshWindow = true;

		// Token: 0x04000596 RID: 1430
		public const int BankRefreshPrompt = -1;

		// Token: 0x04000597 RID: 1431
		public const int BankRefreshManual = -2;

		// Token: 0x04000598 RID: 1432
		[SerializeField]
		public bool AutomaticEventLoading;

		// Token: 0x04000599 RID: 1433
		[SerializeField]
		public BankLoadType BankLoadType;

		// Token: 0x0400059A RID: 1434
		[SerializeField]
		public bool AutomaticSampleLoading;

		// Token: 0x0400059B RID: 1435
		[SerializeField]
		public string EncryptionKey;

		// Token: 0x0400059C RID: 1436
		[SerializeField]
		public ImportType ImportType;

		// Token: 0x0400059D RID: 1437
		[SerializeField]
		public string TargetAssetPath = "FMODBanks";

		// Token: 0x0400059E RID: 1438
		[SerializeField]
		public string TargetBankFolder = "";

		// Token: 0x0400059F RID: 1439
		[SerializeField]
		public DEBUG_FLAGS LoggingLevel = DEBUG_FLAGS.WARNING;

		// Token: 0x040005A0 RID: 1440
		[SerializeField]
		public List<Legacy.PlatformIntSetting> SpeakerModeSettings;

		// Token: 0x040005A1 RID: 1441
		[SerializeField]
		public List<Legacy.PlatformIntSetting> SampleRateSettings;

		// Token: 0x040005A2 RID: 1442
		[SerializeField]
		public List<Legacy.PlatformBoolSetting> LiveUpdateSettings;

		// Token: 0x040005A3 RID: 1443
		[SerializeField]
		public List<Legacy.PlatformBoolSetting> OverlaySettings;

		// Token: 0x040005A4 RID: 1444
		[SerializeField]
		public List<Legacy.PlatformBoolSetting> LoggingSettings;

		// Token: 0x040005A5 RID: 1445
		[SerializeField]
		public List<Legacy.PlatformStringSetting> BankDirectorySettings;

		// Token: 0x040005A6 RID: 1446
		[SerializeField]
		public List<Legacy.PlatformIntSetting> VirtualChannelSettings;

		// Token: 0x040005A7 RID: 1447
		[SerializeField]
		public List<Legacy.PlatformIntSetting> RealChannelSettings;

		// Token: 0x040005A8 RID: 1448
		[SerializeField]
		public List<string> Plugins = new List<string>();

		// Token: 0x040005A9 RID: 1449
		[SerializeField]
		public List<string> MasterBanks;

		// Token: 0x040005AA RID: 1450
		[SerializeField]
		public List<string> Banks;

		// Token: 0x040005AB RID: 1451
		[SerializeField]
		public List<string> BanksToLoad;

		// Token: 0x040005AC RID: 1452
		[SerializeField]
		public ushort LiveUpdatePort = 9264;

		// Token: 0x040005AD RID: 1453
		[SerializeField]
		public bool EnableMemoryTracking;

		// Token: 0x040005AE RID: 1454
		[SerializeField]
		public bool AndroidUseOBB;

		// Token: 0x040005AF RID: 1455
		[SerializeField]
		public MeterChannelOrderingType MeterChannelOrdering;

		// Token: 0x040005B0 RID: 1456
		[SerializeField]
		public bool StopEventsOutsideMaxDistance;

		// Token: 0x040005B1 RID: 1457
		[SerializeField]
		public bool BoltUnitOptionsBuildPending;

		// Token: 0x040005B2 RID: 1458
		[SerializeField]
		public bool EnableErrorCallback;

		// Token: 0x040005B3 RID: 1459
		[SerializeField]
		public Settings.SharedLibraryUpdateStages SharedLibraryUpdateStage;

		// Token: 0x040005B4 RID: 1460
		[SerializeField]
		public double SharedLibraryTimeSinceStart;

		// Token: 0x040005B5 RID: 1461
		[SerializeField]
		public bool HideSetupWizard;

		// Token: 0x040005B6 RID: 1462
		[SerializeField]
		private List<Platform> Platforms = new List<Platform>();

		// Token: 0x040005B7 RID: 1463
		private Dictionary<RuntimePlatform, List<Platform>> PlatformForRuntimePlatform = new Dictionary<RuntimePlatform, List<Platform>>();

		// Token: 0x040005B8 RID: 1464
		[NonSerialized]
		private Platform defaultPlatform;

		// Token: 0x040005B9 RID: 1465
		[NonSerialized]
		private Platform playInEditorPlatform;

		// Token: 0x040005BA RID: 1466
		private static List<Settings.PlatformTemplate> platformTemplates = new List<Settings.PlatformTemplate>();

		// Token: 0x040005BB RID: 1467
		[NonSerialized]
		private bool hasLoaded;

		// Token: 0x02000132 RID: 306
		public enum SharedLibraryUpdateStages
		{
			// Token: 0x04000640 RID: 1600
			DisableExistingLibraries,
			// Token: 0x04000641 RID: 1601
			RestartUnity,
			// Token: 0x04000642 RID: 1602
			CopyNewLibraries
		}

		// Token: 0x02000133 RID: 307
		private struct PlatformTemplate
		{
			// Token: 0x04000643 RID: 1603
			public string Identifier;

			// Token: 0x04000644 RID: 1604
			public Func<Platform> CreateInstance;
		}
	}
}
