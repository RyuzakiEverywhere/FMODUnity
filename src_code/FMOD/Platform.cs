using System;
using System.Collections.Generic;
using FMOD;
using FMOD.Studio;
using UnityEngine;

namespace FMODUnity
{
	// Token: 0x020000FA RID: 250
	public abstract class Platform : ScriptableObject
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600064C RID: 1612 RVA: 0x00006A01 File Offset: 0x00004C01
		// (set) Token: 0x0600064D RID: 1613 RVA: 0x00006A09 File Offset: 0x00004C09
		public string Identifier
		{
			get
			{
				return this.identifier;
			}
			set
			{
				this.identifier = value;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600064E RID: 1614
		public abstract string DisplayName { get; }

		// Token: 0x0600064F RID: 1615
		public abstract void DeclareUnityMappings(Settings settings);

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000650 RID: 1616 RVA: 0x00006A12 File Offset: 0x00004C12
		public virtual float Priority
		{
			get
			{
				return 0f;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000651 RID: 1617 RVA: 0x00006A19 File Offset: 0x00004C19
		public virtual bool MatchesCurrentEnvironment
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000652 RID: 1618 RVA: 0x00006A1C File Offset: 0x00004C1C
		public virtual bool IsIntrinsic
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000653 RID: 1619 RVA: 0x00005DA4 File Offset: 0x00003FA4
		public virtual void PreSystemCreate(Action<RESULT, string> reportResult)
		{
		}

		// Token: 0x06000654 RID: 1620 RVA: 0x00005DA4 File Offset: 0x00003FA4
		public virtual void PreInitialize(FMOD.Studio.System studioSystem)
		{
		}

		// Token: 0x06000655 RID: 1621 RVA: 0x00006A1F File Offset: 0x00004C1F
		public virtual string GetBankFolder()
		{
			return Application.streamingAssetsPath;
		}

		// Token: 0x06000656 RID: 1622 RVA: 0x00006A26 File Offset: 0x00004C26
		protected virtual string GetPluginBasePath()
		{
			return string.Format("{0}/Plugins", Application.dataPath);
		}

		// Token: 0x06000657 RID: 1623 RVA: 0x00006A37 File Offset: 0x00004C37
		protected virtual string GetEditorPluginBasePath()
		{
			return string.Format("{0}/FMOD/lib", this.GetPluginBasePath());
		}

		// Token: 0x06000658 RID: 1624 RVA: 0x00006A49 File Offset: 0x00004C49
		public virtual string GetPluginPath(string pluginName)
		{
			throw new NotImplementedException(string.Format("Plugins are not implemented on platform {0}", this.Identifier));
		}

		// Token: 0x06000659 RID: 1625 RVA: 0x00006A60 File Offset: 0x00004C60
		public virtual void LoadPlugins(FMOD.System coreSystem, Action<RESULT, string> reportResult)
		{
			this.LoadDynamicPlugins(coreSystem, reportResult);
			this.LoadStaticPlugins(coreSystem, reportResult);
		}

		// Token: 0x0600065A RID: 1626 RVA: 0x00006A74 File Offset: 0x00004C74
		public virtual void LoadDynamicPlugins(FMOD.System coreSystem, Action<RESULT, string> reportResult)
		{
			List<string> plugins = this.Plugins;
			if (plugins == null)
			{
				return;
			}
			foreach (string text in plugins)
			{
				if (!string.IsNullOrEmpty(text))
				{
					string pluginPath = this.GetPluginPath(text);
					uint num;
					RESULT result = coreSystem.loadPlugin(pluginPath, out num, 0U);
					if (result == RESULT.ERR_FILE_BAD || result == RESULT.ERR_FILE_NOTFOUND)
					{
						string pluginPath2 = this.GetPluginPath(text + "64");
						result = coreSystem.loadPlugin(pluginPath2, out num, 0U);
					}
					reportResult(result, string.Format("Loading plugin '{0}' from '{1}'", text, pluginPath));
				}
			}
		}

		// Token: 0x0600065B RID: 1627 RVA: 0x00006B24 File Offset: 0x00004D24
		public virtual void LoadStaticPlugins(FMOD.System coreSystem, Action<RESULT, string> reportResult)
		{
			if (this.StaticPlugins.Count > 0)
			{
				UnityEngine.Debug.LogWarningFormat("FMOD: {0} static plugins specified, but static plugins are only supported on the IL2CPP scripting backend", new object[]
				{
					this.StaticPlugins.Count
				});
			}
		}

		// Token: 0x0600065C RID: 1628 RVA: 0x00006B57 File Offset: 0x00004D57
		public void AffirmProperties()
		{
			if (!this.active)
			{
				this.Properties = new Platform.PropertyStorage();
				this.InitializeProperties();
				this.active = true;
			}
		}

		// Token: 0x0600065D RID: 1629 RVA: 0x00006B79 File Offset: 0x00004D79
		public void ClearProperties()
		{
			if (this.active)
			{
				this.Properties = new Platform.PropertyStorage();
				this.active = false;
			}
		}

		// Token: 0x0600065E RID: 1630 RVA: 0x00006B95 File Offset: 0x00004D95
		public virtual void InitializeProperties()
		{
			if (!this.IsIntrinsic)
			{
				this.ParentIdentifier = "default";
			}
		}

		// Token: 0x0600065F RID: 1631 RVA: 0x00006BAA File Offset: 0x00004DAA
		public virtual void EnsurePropertiesAreValid()
		{
			if (!this.IsIntrinsic && string.IsNullOrEmpty(this.ParentIdentifier))
			{
				this.ParentIdentifier = "default";
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000660 RID: 1632 RVA: 0x00006BCC File Offset: 0x00004DCC
		// (set) Token: 0x06000661 RID: 1633 RVA: 0x00006BD4 File Offset: 0x00004DD4
		public string ParentIdentifier
		{
			get
			{
				return this.parentIdentifier;
			}
			set
			{
				this.parentIdentifier = value;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000662 RID: 1634 RVA: 0x00006BDD File Offset: 0x00004DDD
		public bool IsLiveUpdateEnabled
		{
			get
			{
				return this.LiveUpdate == TriStateBool.Enabled;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000663 RID: 1635 RVA: 0x00006BE8 File Offset: 0x00004DE8
		public bool IsOverlayEnabled
		{
			get
			{
				return this.Overlay == TriStateBool.Enabled;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000664 RID: 1636 RVA: 0x00006BF3 File Offset: 0x00004DF3
		public bool Active
		{
			get
			{
				return this.active;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000665 RID: 1637 RVA: 0x00006BFC File Offset: 0x00004DFC
		public bool HasAnyOverriddenProperties
		{
			get
			{
				return this.active && (this.Properties.LiveUpdate.HasValue || this.Properties.LiveUpdatePort.HasValue || this.Properties.Overlay.HasValue || this.Properties.Logging.HasValue || this.Properties.SampleRate.HasValue || this.Properties.BuildDirectory.HasValue || this.Properties.SpeakerMode.HasValue || this.Properties.VirtualChannelCount.HasValue || this.Properties.RealChannelCount.HasValue || this.Properties.DSPBufferLength.HasValue || this.Properties.DSPBufferCount.HasValue || this.Properties.Plugins.HasValue || this.Properties.StaticPlugins.HasValue);
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000666 RID: 1638 RVA: 0x00006D10 File Offset: 0x00004F10
		public TriStateBool LiveUpdate
		{
			get
			{
				return Platform.PropertyAccessors.LiveUpdate.Get(this);
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000667 RID: 1639 RVA: 0x00006D2C File Offset: 0x00004F2C
		public int LiveUpdatePort
		{
			get
			{
				return Platform.PropertyAccessors.LiveUpdatePort.Get(this);
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000668 RID: 1640 RVA: 0x00006D48 File Offset: 0x00004F48
		public TriStateBool Overlay
		{
			get
			{
				return Platform.PropertyAccessors.Overlay.Get(this);
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000669 RID: 1641 RVA: 0x00006D64 File Offset: 0x00004F64
		public TriStateBool Logging
		{
			get
			{
				return Platform.PropertyAccessors.Logging.Get(this);
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600066A RID: 1642 RVA: 0x00006D80 File Offset: 0x00004F80
		public int SampleRate
		{
			get
			{
				return Platform.PropertyAccessors.SampleRate.Get(this);
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600066B RID: 1643 RVA: 0x00006D9C File Offset: 0x00004F9C
		public string BuildDirectory
		{
			get
			{
				return Platform.PropertyAccessors.BuildDirectory.Get(this);
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600066C RID: 1644 RVA: 0x00006DB8 File Offset: 0x00004FB8
		public SPEAKERMODE SpeakerMode
		{
			get
			{
				return Platform.PropertyAccessors.SpeakerMode.Get(this);
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600066D RID: 1645 RVA: 0x00006DD4 File Offset: 0x00004FD4
		public int VirtualChannelCount
		{
			get
			{
				return Platform.PropertyAccessors.VirtualChannelCount.Get(this);
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600066E RID: 1646 RVA: 0x00006DF0 File Offset: 0x00004FF0
		public int RealChannelCount
		{
			get
			{
				return Platform.PropertyAccessors.RealChannelCount.Get(this);
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600066F RID: 1647 RVA: 0x00006E0C File Offset: 0x0000500C
		public int DSPBufferLength
		{
			get
			{
				return Platform.PropertyAccessors.DSPBufferLength.Get(this);
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000670 RID: 1648 RVA: 0x00006E28 File Offset: 0x00005028
		public int DSPBufferCount
		{
			get
			{
				return Platform.PropertyAccessors.DSPBufferCount.Get(this);
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000671 RID: 1649 RVA: 0x00006E44 File Offset: 0x00005044
		public List<string> Plugins
		{
			get
			{
				return Platform.PropertyAccessors.Plugins.Get(this);
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000672 RID: 1650 RVA: 0x00006E60 File Offset: 0x00005060
		public List<string> StaticPlugins
		{
			get
			{
				return Platform.PropertyAccessors.StaticPlugins.Get(this);
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000673 RID: 1651 RVA: 0x00006E7C File Offset: 0x0000507C
		public PlatformCallbackHandler CallbackHandler
		{
			get
			{
				return Platform.PropertyAccessors.CallbackHandler.Get(this);
			}
		}

		// Token: 0x06000674 RID: 1652 RVA: 0x00006E97 File Offset: 0x00005097
		public bool InheritsFrom(Platform platform)
		{
			return platform == this || (this.Parent != null && this.Parent.InheritsFrom(platform));
		}

		// Token: 0x06000675 RID: 1653 RVA: 0x00006EC0 File Offset: 0x000050C0
		public OUTPUTTYPE GetOutputType()
		{
			if (Enum.IsDefined(typeof(OUTPUTTYPE), this.outputType))
			{
				return (OUTPUTTYPE)Enum.Parse(typeof(OUTPUTTYPE), this.outputType);
			}
			return OUTPUTTYPE.AUTODETECT;
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000676 RID: 1654 RVA: 0x00006EF5 File Offset: 0x000050F5
		public virtual List<ThreadAffinityGroup> DefaultThreadAffinities
		{
			get
			{
				return Platform.StaticThreadAffinities;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000677 RID: 1655 RVA: 0x00006EFC File Offset: 0x000050FC
		public IEnumerable<ThreadAffinityGroup> ThreadAffinities
		{
			get
			{
				if (this.threadAffinities.HasValue)
				{
					return this.threadAffinities.Value;
				}
				return this.DefaultThreadAffinities;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000678 RID: 1656 RVA: 0x00006F1D File Offset: 0x0000511D
		public Platform.PropertyThreadAffinityList ThreadAffinitiesProperty
		{
			get
			{
				return this.threadAffinities;
			}
		}

		// Token: 0x04000513 RID: 1299
		[SerializeField]
		private string identifier;

		// Token: 0x04000514 RID: 1300
		public const float DefaultPriority = 0f;

		// Token: 0x04000515 RID: 1301
		public const string RegisterStaticPluginsClassName = "StaticPluginManager";

		// Token: 0x04000516 RID: 1302
		public const string RegisterStaticPluginsFunctionName = "Register";

		// Token: 0x04000517 RID: 1303
		[SerializeField]
		private string parentIdentifier;

		// Token: 0x04000518 RID: 1304
		[SerializeField]
		private bool active;

		// Token: 0x04000519 RID: 1305
		[SerializeField]
		protected Platform.PropertyStorage Properties = new Platform.PropertyStorage();

		// Token: 0x0400051A RID: 1306
		[NonSerialized]
		public Platform Parent;

		// Token: 0x0400051B RID: 1307
		[SerializeField]
		public string outputType;

		// Token: 0x0400051C RID: 1308
		private static List<ThreadAffinityGroup> StaticThreadAffinities = new List<ThreadAffinityGroup>();

		// Token: 0x0400051D RID: 1309
		[SerializeField]
		private Platform.PropertyThreadAffinityList threadAffinities = new Platform.PropertyThreadAffinityList();

		// Token: 0x0200011F RID: 287
		public class Property<T>
		{
			// Token: 0x0400060F RID: 1551
			public T Value;

			// Token: 0x04000610 RID: 1552
			public bool HasValue;
		}

		// Token: 0x02000120 RID: 288
		[Serializable]
		public class PropertyBool : Platform.Property<TriStateBool>
		{
		}

		// Token: 0x02000121 RID: 289
		[Serializable]
		public class PropertyInt : Platform.Property<int>
		{
		}

		// Token: 0x02000122 RID: 290
		[Serializable]
		public class PropertySpeakerMode : Platform.Property<SPEAKERMODE>
		{
		}

		// Token: 0x02000123 RID: 291
		[Serializable]
		public class PropertyString : Platform.Property<string>
		{
		}

		// Token: 0x02000124 RID: 292
		[Serializable]
		public class PropertyStringList : Platform.Property<List<string>>
		{
		}

		// Token: 0x02000125 RID: 293
		[Serializable]
		public class PropertyCallbackHandler : Platform.Property<PlatformCallbackHandler>
		{
		}

		// Token: 0x02000126 RID: 294
		public interface PropertyOverrideControl
		{
			// Token: 0x06000762 RID: 1890
			bool HasValue(Platform platform);

			// Token: 0x06000763 RID: 1891
			void Clear(Platform platform);
		}

		// Token: 0x02000127 RID: 295
		public struct PropertyAccessor<T> : Platform.PropertyOverrideControl
		{
			// Token: 0x06000764 RID: 1892 RVA: 0x0000B213 File Offset: 0x00009413
			public PropertyAccessor(Func<Platform.PropertyStorage, Platform.Property<T>> getter, T defaultValue)
			{
				this.Getter = getter;
				this.DefaultValue = defaultValue;
			}

			// Token: 0x06000765 RID: 1893 RVA: 0x0000B223 File Offset: 0x00009423
			public bool HasValue(Platform platform)
			{
				return platform.Active && this.Getter(platform.Properties).HasValue;
			}

			// Token: 0x06000766 RID: 1894 RVA: 0x0000B248 File Offset: 0x00009448
			public T Get(Platform platform)
			{
				Platform platform2 = platform;
				while (platform2 != null)
				{
					if (platform2.Active)
					{
						Platform.Property<T> property = this.Getter(platform2.Properties);
						if (property.HasValue)
						{
							return property.Value;
						}
					}
					platform2 = platform2.Parent;
				}
				return this.DefaultValue;
			}

			// Token: 0x06000767 RID: 1895 RVA: 0x0000B298 File Offset: 0x00009498
			public void Set(Platform platform, T value)
			{
				Platform.Property<T> property = this.Getter(platform.Properties);
				property.Value = value;
				property.HasValue = true;
			}

			// Token: 0x06000768 RID: 1896 RVA: 0x0000B2B8 File Offset: 0x000094B8
			public void Clear(Platform platform)
			{
				this.Getter(platform.Properties).HasValue = false;
			}

			// Token: 0x04000611 RID: 1553
			private readonly Func<Platform.PropertyStorage, Platform.Property<T>> Getter;

			// Token: 0x04000612 RID: 1554
			private readonly T DefaultValue;
		}

		// Token: 0x02000128 RID: 296
		[Serializable]
		public class PropertyStorage
		{
			// Token: 0x04000613 RID: 1555
			public Platform.PropertyBool LiveUpdate = new Platform.PropertyBool();

			// Token: 0x04000614 RID: 1556
			public Platform.PropertyInt LiveUpdatePort = new Platform.PropertyInt();

			// Token: 0x04000615 RID: 1557
			public Platform.PropertyBool Overlay = new Platform.PropertyBool();

			// Token: 0x04000616 RID: 1558
			public Platform.PropertyBool Logging = new Platform.PropertyBool();

			// Token: 0x04000617 RID: 1559
			public Platform.PropertyInt SampleRate = new Platform.PropertyInt();

			// Token: 0x04000618 RID: 1560
			public Platform.PropertyString BuildDirectory = new Platform.PropertyString();

			// Token: 0x04000619 RID: 1561
			public Platform.PropertySpeakerMode SpeakerMode = new Platform.PropertySpeakerMode();

			// Token: 0x0400061A RID: 1562
			public Platform.PropertyInt VirtualChannelCount = new Platform.PropertyInt();

			// Token: 0x0400061B RID: 1563
			public Platform.PropertyInt RealChannelCount = new Platform.PropertyInt();

			// Token: 0x0400061C RID: 1564
			public Platform.PropertyInt DSPBufferLength = new Platform.PropertyInt();

			// Token: 0x0400061D RID: 1565
			public Platform.PropertyInt DSPBufferCount = new Platform.PropertyInt();

			// Token: 0x0400061E RID: 1566
			public Platform.PropertyStringList Plugins = new Platform.PropertyStringList();

			// Token: 0x0400061F RID: 1567
			public Platform.PropertyStringList StaticPlugins = new Platform.PropertyStringList();

			// Token: 0x04000620 RID: 1568
			public Platform.PropertyCallbackHandler CallbackHandler = new Platform.PropertyCallbackHandler();
		}

		// Token: 0x02000129 RID: 297
		public static class PropertyAccessors
		{
			// Token: 0x04000621 RID: 1569
			public static readonly Platform.PropertyAccessor<TriStateBool> LiveUpdate = new Platform.PropertyAccessor<TriStateBool>((Platform.PropertyStorage properties) => properties.LiveUpdate, TriStateBool.Disabled);

			// Token: 0x04000622 RID: 1570
			public static readonly Platform.PropertyAccessor<int> LiveUpdatePort = new Platform.PropertyAccessor<int>((Platform.PropertyStorage properties) => properties.LiveUpdatePort, 9264);

			// Token: 0x04000623 RID: 1571
			public static readonly Platform.PropertyAccessor<TriStateBool> Overlay = new Platform.PropertyAccessor<TriStateBool>((Platform.PropertyStorage properties) => properties.Overlay, TriStateBool.Disabled);

			// Token: 0x04000624 RID: 1572
			public static readonly Platform.PropertyAccessor<TriStateBool> Logging = new Platform.PropertyAccessor<TriStateBool>((Platform.PropertyStorage properties) => properties.Logging, TriStateBool.Disabled);

			// Token: 0x04000625 RID: 1573
			public static readonly Platform.PropertyAccessor<int> SampleRate = new Platform.PropertyAccessor<int>((Platform.PropertyStorage properties) => properties.SampleRate, 0);

			// Token: 0x04000626 RID: 1574
			public static readonly Platform.PropertyAccessor<string> BuildDirectory = new Platform.PropertyAccessor<string>((Platform.PropertyStorage properties) => properties.BuildDirectory, "Desktop");

			// Token: 0x04000627 RID: 1575
			public static readonly Platform.PropertyAccessor<SPEAKERMODE> SpeakerMode = new Platform.PropertyAccessor<SPEAKERMODE>((Platform.PropertyStorage properties) => properties.SpeakerMode, SPEAKERMODE.STEREO);

			// Token: 0x04000628 RID: 1576
			public static readonly Platform.PropertyAccessor<int> VirtualChannelCount = new Platform.PropertyAccessor<int>((Platform.PropertyStorage properties) => properties.VirtualChannelCount, 128);

			// Token: 0x04000629 RID: 1577
			public static readonly Platform.PropertyAccessor<int> RealChannelCount = new Platform.PropertyAccessor<int>((Platform.PropertyStorage properties) => properties.RealChannelCount, 32);

			// Token: 0x0400062A RID: 1578
			public static readonly Platform.PropertyAccessor<int> DSPBufferLength = new Platform.PropertyAccessor<int>((Platform.PropertyStorage properties) => properties.DSPBufferLength, 0);

			// Token: 0x0400062B RID: 1579
			public static readonly Platform.PropertyAccessor<int> DSPBufferCount = new Platform.PropertyAccessor<int>((Platform.PropertyStorage properties) => properties.DSPBufferCount, 0);

			// Token: 0x0400062C RID: 1580
			public static readonly Platform.PropertyAccessor<List<string>> Plugins = new Platform.PropertyAccessor<List<string>>((Platform.PropertyStorage properties) => properties.Plugins, null);

			// Token: 0x0400062D RID: 1581
			public static readonly Platform.PropertyAccessor<List<string>> StaticPlugins = new Platform.PropertyAccessor<List<string>>((Platform.PropertyStorage properties) => properties.StaticPlugins, null);

			// Token: 0x0400062E RID: 1582
			public static readonly Platform.PropertyAccessor<PlatformCallbackHandler> CallbackHandler = new Platform.PropertyAccessor<PlatformCallbackHandler>((Platform.PropertyStorage properties) => properties.CallbackHandler, null);
		}

		// Token: 0x0200012A RID: 298
		[Serializable]
		public class PropertyThreadAffinityList : Platform.Property<List<ThreadAffinityGroup>>
		{
		}
	}
}
