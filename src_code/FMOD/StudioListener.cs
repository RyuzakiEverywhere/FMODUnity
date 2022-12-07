using System;
using System.Collections.Generic;
using UnityEngine;

namespace FMODUnity
{
	// Token: 0x02000115 RID: 277
	[AddComponentMenu("FMOD Studio/FMOD Studio Listener")]
	public class StudioListener : MonoBehaviour
	{
		// Token: 0x06000735 RID: 1845 RVA: 0x0000A7A8 File Offset: 0x000089A8
		private void OnEnable()
		{
			RuntimeUtils.EnforceLibraryOrder();
			this.rigidBody = base.gameObject.GetComponent<Rigidbody>();
			this.rigidBody2D = base.gameObject.GetComponent<Rigidbody2D>();
			this.ListenerNumber = RuntimeManager.AddListener(this);
		}

		// Token: 0x06000736 RID: 1846 RVA: 0x0000A7DD File Offset: 0x000089DD
		private void OnDisable()
		{
			RuntimeManager.RemoveListener(this);
		}

		// Token: 0x06000737 RID: 1847 RVA: 0x0000A7E6 File Offset: 0x000089E6
		private void Update()
		{
			if (this.ListenerNumber >= 0 && this.ListenerNumber < 8)
			{
				this.SetListenerLocation();
			}
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x0000A800 File Offset: 0x00008A00
		private void SetListenerLocation()
		{
			if (this.rigidBody)
			{
				RuntimeManager.SetListenerLocation(this.ListenerNumber, base.gameObject, this.rigidBody, this.attenuationObject);
				return;
			}
			if (this.rigidBody2D)
			{
				RuntimeManager.SetListenerLocation(this.ListenerNumber, base.gameObject, this.rigidBody2D, this.attenuationObject);
				return;
			}
			RuntimeManager.SetListenerLocation(this.ListenerNumber, base.gameObject, this.attenuationObject);
		}

		// Token: 0x040005E5 RID: 1509
		private Rigidbody rigidBody;

		// Token: 0x040005E6 RID: 1510
		private Rigidbody2D rigidBody2D;

		// Token: 0x040005E7 RID: 1511
		public GameObject attenuationObject;

		// Token: 0x040005E8 RID: 1512
		public int ListenerNumber = -1;

		// Token: 0x040005E9 RID: 1513
		public List<string> EventsPlaying = new List<string>();
	}
}
