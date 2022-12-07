using System;
using System.IO;
using FMOD;
using UnityEngine;

namespace FMODUnity
{
	// Token: 0x020000FF RID: 255
	public class PlatformPlayInEditor : Platform
	{
		// Token: 0x0600068F RID: 1679 RVA: 0x00007046 File Offset: 0x00005246
		public PlatformPlayInEditor()
		{
			base.Identifier = "playInEditor";
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000690 RID: 1680 RVA: 0x00007059 File Offset: 0x00005259
		public override string DisplayName
		{
			get
			{
				return "Editor";
			}
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x00007060 File Offset: 0x00005260
		public override void DeclareUnityMappings(Settings settings)
		{
			settings.DeclareRuntimePlatform(RuntimePlatform.OSXEditor, this);
			settings.DeclareRuntimePlatform(RuntimePlatform.WindowsEditor, this);
			settings.DeclareRuntimePlatform(RuntimePlatform.LinuxEditor, this);
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000692 RID: 1682 RVA: 0x00006A19 File Offset: 0x00004C19
		public override bool IsIntrinsic
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000693 RID: 1683 RVA: 0x0000707C File Offset: 0x0000527C
		public override string GetBankFolder()
		{
			Settings instance = Settings.Instance;
			string text = instance.SourceBankPath;
			if (instance.HasPlatforms)
			{
				text = RuntimeUtils.GetCommonPlatformPath(Path.Combine(text, base.BuildDirectory));
			}
			return text;
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x00005DA4 File Offset: 0x00003FA4
		public override void LoadStaticPlugins(System coreSystem, Action<RESULT, string> reportResult)
		{
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x000070B0 File Offset: 0x000052B0
		public override void InitializeProperties()
		{
			base.InitializeProperties();
			Platform.PropertyAccessors.LiveUpdate.Set(this, TriStateBool.Enabled);
			Platform.PropertyAccessors.Overlay.Set(this, TriStateBool.Disabled);
			Platform.PropertyAccessors.SampleRate.Set(this, 48000);
			Platform.PropertyAccessors.RealChannelCount.Set(this, 256);
			Platform.PropertyAccessors.VirtualChannelCount.Set(this, 1024);
		}
	}
}
