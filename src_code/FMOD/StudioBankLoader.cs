using System;
using System.Collections.Generic;
using UnityEngine;

namespace FMODUnity
{
	// Token: 0x02000112 RID: 274
	[AddComponentMenu("FMOD Studio/FMOD Studio Bank Loader")]
	public class StudioBankLoader : MonoBehaviour
	{
		// Token: 0x0600070F RID: 1807 RVA: 0x00009A63 File Offset: 0x00007C63
		private void HandleGameEvent(LoaderGameEvent gameEvent)
		{
			if (this.LoadEvent == gameEvent)
			{
				this.Load();
			}
			if (this.UnloadEvent == gameEvent)
			{
				this.Unload();
			}
		}

		// Token: 0x06000710 RID: 1808 RVA: 0x00009A83 File Offset: 0x00007C83
		private void Start()
		{
			RuntimeUtils.EnforceLibraryOrder();
			this.HandleGameEvent(LoaderGameEvent.ObjectStart);
		}

		// Token: 0x06000711 RID: 1809 RVA: 0x00009A91 File Offset: 0x00007C91
		private void OnApplicationQuit()
		{
			this.isQuitting = true;
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x00009A9A File Offset: 0x00007C9A
		private void OnDestroy()
		{
			if (!this.isQuitting)
			{
				this.HandleGameEvent(LoaderGameEvent.ObjectDestroy);
			}
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x00009AAB File Offset: 0x00007CAB
		private void OnTriggerEnter(Collider other)
		{
			if (string.IsNullOrEmpty(this.CollisionTag) || other.CompareTag(this.CollisionTag))
			{
				this.HandleGameEvent(LoaderGameEvent.TriggerEnter);
			}
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x00009ACF File Offset: 0x00007CCF
		private void OnTriggerExit(Collider other)
		{
			if (string.IsNullOrEmpty(this.CollisionTag) || other.CompareTag(this.CollisionTag))
			{
				this.HandleGameEvent(LoaderGameEvent.TriggerExit);
			}
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x00009AF3 File Offset: 0x00007CF3
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (string.IsNullOrEmpty(this.CollisionTag) || other.CompareTag(this.CollisionTag))
			{
				this.HandleGameEvent(LoaderGameEvent.TriggerEnter2D);
			}
		}

		// Token: 0x06000716 RID: 1814 RVA: 0x00009B17 File Offset: 0x00007D17
		private void OnTriggerExit2D(Collider2D other)
		{
			if (string.IsNullOrEmpty(this.CollisionTag) || other.CompareTag(this.CollisionTag))
			{
				this.HandleGameEvent(LoaderGameEvent.TriggerExit2D);
			}
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x00009B3B File Offset: 0x00007D3B
		private void OnEnable()
		{
			this.HandleGameEvent(LoaderGameEvent.ObjectEnable);
		}

		// Token: 0x06000718 RID: 1816 RVA: 0x00009B44 File Offset: 0x00007D44
		private void OnDisable()
		{
			this.HandleGameEvent(LoaderGameEvent.ObjectDisable);
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x00009B50 File Offset: 0x00007D50
		public void Load()
		{
			foreach (string bankName in this.Banks)
			{
				try
				{
					RuntimeManager.LoadBank(bankName, this.PreloadSamples);
				}
				catch (BankLoadException exception)
				{
					Debug.LogException(exception);
				}
			}
			RuntimeManager.WaitForAllLoads();
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x00009BC4 File Offset: 0x00007DC4
		public void Unload()
		{
			foreach (string bankName in this.Banks)
			{
				RuntimeManager.UnloadBank(bankName);
			}
		}

		// Token: 0x040005BC RID: 1468
		public LoaderGameEvent LoadEvent;

		// Token: 0x040005BD RID: 1469
		public LoaderGameEvent UnloadEvent;

		// Token: 0x040005BE RID: 1470
		[BankRef]
		public List<string> Banks;

		// Token: 0x040005BF RID: 1471
		public string CollisionTag;

		// Token: 0x040005C0 RID: 1472
		public bool PreloadSamples;

		// Token: 0x040005C1 RID: 1473
		private bool isQuitting;
	}
}
