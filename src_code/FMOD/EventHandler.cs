using System;
using UnityEngine;

namespace FMODUnity
{
	// Token: 0x020000F5 RID: 245
	public abstract class EventHandler : MonoBehaviour
	{
		// Token: 0x06000635 RID: 1589 RVA: 0x0000688A File Offset: 0x00004A8A
		private void OnEnable()
		{
			this.HandleGameEvent(EmitterGameEvent.ObjectEnable);
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x00006894 File Offset: 0x00004A94
		private void OnDisable()
		{
			this.HandleGameEvent(EmitterGameEvent.ObjectDisable);
		}

		// Token: 0x06000637 RID: 1591 RVA: 0x000068A0 File Offset: 0x00004AA0
		private void OnTriggerEnter(Collider other)
		{
			if (string.IsNullOrEmpty(this.CollisionTag) || other.CompareTag(this.CollisionTag) || (other.attachedRigidbody && other.attachedRigidbody.CompareTag(this.CollisionTag)))
			{
				this.HandleGameEvent(EmitterGameEvent.TriggerEnter);
			}
		}

		// Token: 0x06000638 RID: 1592 RVA: 0x000068F0 File Offset: 0x00004AF0
		private void OnTriggerExit(Collider other)
		{
			if (string.IsNullOrEmpty(this.CollisionTag) || other.CompareTag(this.CollisionTag) || (other.attachedRigidbody && other.attachedRigidbody.CompareTag(this.CollisionTag)))
			{
				this.HandleGameEvent(EmitterGameEvent.TriggerExit);
			}
		}

		// Token: 0x06000639 RID: 1593 RVA: 0x0000693F File Offset: 0x00004B3F
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (string.IsNullOrEmpty(this.CollisionTag) || other.CompareTag(this.CollisionTag))
			{
				this.HandleGameEvent(EmitterGameEvent.TriggerEnter2D);
			}
		}

		// Token: 0x0600063A RID: 1594 RVA: 0x00006963 File Offset: 0x00004B63
		private void OnTriggerExit2D(Collider2D other)
		{
			if (string.IsNullOrEmpty(this.CollisionTag) || other.CompareTag(this.CollisionTag))
			{
				this.HandleGameEvent(EmitterGameEvent.TriggerExit2D);
			}
		}

		// Token: 0x0600063B RID: 1595 RVA: 0x00006987 File Offset: 0x00004B87
		private void OnCollisionEnter()
		{
			this.HandleGameEvent(EmitterGameEvent.CollisionEnter);
		}

		// Token: 0x0600063C RID: 1596 RVA: 0x00006990 File Offset: 0x00004B90
		private void OnCollisionExit()
		{
			this.HandleGameEvent(EmitterGameEvent.CollisionExit);
		}

		// Token: 0x0600063D RID: 1597 RVA: 0x00006999 File Offset: 0x00004B99
		private void OnCollisionEnter2D()
		{
			this.HandleGameEvent(EmitterGameEvent.CollisionEnter2D);
		}

		// Token: 0x0600063E RID: 1598 RVA: 0x000069A3 File Offset: 0x00004BA3
		private void OnCollisionExit2D()
		{
			this.HandleGameEvent(EmitterGameEvent.CollisionExit2D);
		}

		// Token: 0x0600063F RID: 1599 RVA: 0x000069AD File Offset: 0x00004BAD
		private void OnMouseEnter()
		{
			this.HandleGameEvent(EmitterGameEvent.MouseEnter);
		}

		// Token: 0x06000640 RID: 1600 RVA: 0x000069B7 File Offset: 0x00004BB7
		private void OnMouseExit()
		{
			this.HandleGameEvent(EmitterGameEvent.MouseExit);
		}

		// Token: 0x06000641 RID: 1601 RVA: 0x000069C1 File Offset: 0x00004BC1
		private void OnMouseDown()
		{
			this.HandleGameEvent(EmitterGameEvent.MouseDown);
		}

		// Token: 0x06000642 RID: 1602 RVA: 0x000069CB File Offset: 0x00004BCB
		private void OnMouseUp()
		{
			this.HandleGameEvent(EmitterGameEvent.MouseUp);
		}

		// Token: 0x06000643 RID: 1603
		protected abstract void HandleGameEvent(EmitterGameEvent gameEvent);

		// Token: 0x0400050E RID: 1294
		public string CollisionTag = "";
	}
}
