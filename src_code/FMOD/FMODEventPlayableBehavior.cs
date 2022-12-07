using System;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace FMODUnity
{
	// Token: 0x0200011B RID: 283
	[Serializable]
	public class FMODEventPlayableBehavior : PlayableBehaviour
	{
		// Token: 0x06000748 RID: 1864 RVA: 0x0000ABA4 File Offset: 0x00008DA4
		protected void PlayEvent()
		{
			if (!string.IsNullOrEmpty(this.eventName))
			{
				this.eventInstance = RuntimeManager.CreateInstance(this.eventName, true);
				if (Application.isPlaying && this.TrackTargetObject)
				{
					if (this.TrackTargetObject.GetComponent<Rigidbody>())
					{
						RuntimeManager.AttachInstanceToGameObject(this.eventInstance, this.TrackTargetObject.transform, this.TrackTargetObject.GetComponent<Rigidbody>());
					}
					else if (this.TrackTargetObject.GetComponent<Rigidbody2D>())
					{
						RuntimeManager.AttachInstanceToGameObject(this.eventInstance, this.TrackTargetObject.transform, this.TrackTargetObject.GetComponent<Rigidbody2D>());
					}
					else
					{
						RuntimeManager.AttachInstanceToGameObject(this.eventInstance, this.TrackTargetObject.transform);
					}
				}
				else
				{
					this.eventInstance.set3DAttributes(Vector3.zero.To3DAttributes());
				}
				foreach (ParamRef paramRef in this.parameters)
				{
					this.eventInstance.setParameterByID(paramRef.ID, paramRef.Value, false);
				}
				this.eventInstance.setVolume(this.currentVolume);
				this.eventInstance.start();
			}
		}

		// Token: 0x06000749 RID: 1865 RVA: 0x0000ACD5 File Offset: 0x00008ED5
		public void OnEnter()
		{
			if (!this.isPlayheadInside)
			{
				this.PlayEvent();
				this.isPlayheadInside = true;
			}
		}

		// Token: 0x0600074A RID: 1866 RVA: 0x0000ACEC File Offset: 0x00008EEC
		public void OnExit()
		{
			if (this.isPlayheadInside)
			{
				if (this.eventInstance.isValid())
				{
					if (this.stopType != STOP_MODE.None)
					{
						this.eventInstance.stop((this.stopType == STOP_MODE.Immediate) ? STOP_MODE.IMMEDIATE : STOP_MODE.ALLOWFADEOUT);
					}
					this.eventInstance.release();
				}
				this.isPlayheadInside = false;
			}
		}

		// Token: 0x0600074B RID: 1867 RVA: 0x0000AD44 File Offset: 0x00008F44
		public override void ProcessFrame(Playable playable, FrameData info, object playerData)
		{
			if (this.eventInstance.isValid())
			{
				foreach (ParameterAutomationLink parameterAutomationLink in this.parameterLinks)
				{
					float value = this.parameterAutomation.GetValue(parameterAutomationLink.Slot);
					this.eventInstance.setParameterByID(parameterAutomationLink.ID, value, false);
				}
			}
		}

		// Token: 0x0600074C RID: 1868 RVA: 0x0000ADC4 File Offset: 0x00008FC4
		public void UpdateBehavior(float time, float volume)
		{
			if (volume != this.currentVolume)
			{
				this.currentVolume = volume;
				if (this.eventInstance.isValid())
				{
					this.eventInstance.setVolume(volume);
				}
			}
			if ((double)time >= this.OwningClip.start && (double)time < this.OwningClip.end)
			{
				this.OnEnter();
				return;
			}
			this.OnExit();
		}

		// Token: 0x0600074D RID: 1869 RVA: 0x0000AE28 File Offset: 0x00009028
		public override void OnGraphStop(Playable playable)
		{
			this.isPlayheadInside = false;
			if (this.eventInstance.isValid())
			{
				this.eventInstance.stop(STOP_MODE.IMMEDIATE);
				this.eventInstance.release();
				RuntimeManager.StudioSystem.update();
			}
		}

		// Token: 0x040005FE RID: 1534
		public string eventName;

		// Token: 0x040005FF RID: 1535
		public STOP_MODE stopType;

		// Token: 0x04000600 RID: 1536
		[NotKeyable]
		public ParamRef[] parameters = new ParamRef[0];

		// Token: 0x04000601 RID: 1537
		public List<ParameterAutomationLink> parameterLinks = new List<ParameterAutomationLink>();

		// Token: 0x04000602 RID: 1538
		[NonSerialized]
		public GameObject TrackTargetObject;

		// Token: 0x04000603 RID: 1539
		[NonSerialized]
		public TimelineClip OwningClip;

		// Token: 0x04000604 RID: 1540
		public AutomatableSlots parameterAutomation;

		// Token: 0x04000605 RID: 1541
		private bool isPlayheadInside;

		// Token: 0x04000606 RID: 1542
		private EventInstance eventInstance;

		// Token: 0x04000607 RID: 1543
		private float currentVolume = 1f;
	}
}
