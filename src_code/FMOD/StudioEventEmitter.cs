using System;
using System.Collections.Generic;
using System.Threading;
using FMOD;
using FMOD.Studio;
using UnityEngine;

namespace FMODUnity
{
	// Token: 0x02000113 RID: 275
	[AddComponentMenu("FMOD Studio/FMOD Studio Event Emitter")]
	public class StudioEventEmitter : EventHandler
	{
		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600071C RID: 1820 RVA: 0x00009C14 File Offset: 0x00007E14
		public EventDescription EventDescription
		{
			get
			{
				return this.eventDescription;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600071D RID: 1821 RVA: 0x00009C1C File Offset: 0x00007E1C
		public EventInstance EventInstance
		{
			get
			{
				return this.instance;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600071E RID: 1822 RVA: 0x00009C24 File Offset: 0x00007E24
		// (set) Token: 0x0600071F RID: 1823 RVA: 0x00009C2C File Offset: 0x00007E2C
		public bool IsActive { get; private set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000720 RID: 1824 RVA: 0x00009C38 File Offset: 0x00007E38
		public float MaxDistance
		{
			get
			{
				if (this.OverrideAttenuation)
				{
					return this.OverrideMaxDistance;
				}
				if (!this.eventDescription.isValid())
				{
					this.Lookup();
				}
				float result;
				this.eventDescription.getMaximumDistance(out result);
				return result;
			}
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x00009C78 File Offset: 0x00007E78
		private void Start()
		{
			RuntimeUtils.EnforceLibraryOrder();
			if (this.Preload)
			{
				this.Lookup();
				this.eventDescription.loadSampleData();
				RuntimeManager.StudioSystem.update();
				LOADING_STATE loading_STATE;
				this.eventDescription.getSampleLoadingState(out loading_STATE);
				while (loading_STATE == LOADING_STATE.LOADING)
				{
					Thread.Sleep(1);
					this.eventDescription.getSampleLoadingState(out loading_STATE);
				}
			}
			if (StudioEventEmitter.Listener == null)
			{
				StudioEventEmitter.Listener = Object.FindObjectOfType<StudioListener>();
			}
			this.HandleGameEvent(EmitterGameEvent.ObjectStart);
			this.HandleGameEvent(EmitterGameEvent.ObjectEnable);
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x00009D00 File Offset: 0x00007F00
		private void Update()
		{
			if (StudioEventEmitter.Listener == null || StudioEventEmitter.Listener.ListenerNumber < 0)
			{
				StudioEventEmitter.Listener = null;
				for (int i = 0; i < RuntimeManager.Listeners.Count; i++)
				{
					StudioListener studioListener = RuntimeManager.Listeners[i];
					if (studioListener != null && studioListener.ListenerNumber >= 0)
					{
						StudioEventEmitter.Listener = studioListener;
						break;
					}
				}
				if (StudioEventEmitter.Listener == null)
				{
					return;
				}
			}
			if (this.Event != this.lastEventPath)
			{
				this.lastEventPath = this.Event;
				this.Lookup();
			}
			if (this.is3D)
			{
				if (this.IsPlaying())
				{
					if (!this.logic_visible || (this.StopOnDistanceExit && Vector3.Distance(StudioEventEmitter.Listener.transform.position, base.transform.position) > this.maxDistance))
					{
						this.Stop();
					}
				}
				else if (this.logic_visible && this.PlayOnDistanceEnter && Vector3.Distance(StudioEventEmitter.Listener.transform.position, base.transform.position) <= this.maxDistance)
				{
					this.Play();
				}
			}
			if (this.LogDistanceToListener && StudioEventEmitter.Listener != null)
			{
				PLAYBACK_STATE playback_STATE = PLAYBACK_STATE.SUSTAINING;
				this.EventInstance.getPlaybackState(out playback_STATE);
				float num = Vector3.Distance(StudioEventEmitter.Listener.transform.position, base.transform.position);
				if (num != this.lastDist || this.lastDist < 0f || playback_STATE != this.lastPlaying)
				{
					string format = "Distance to {0} (in {1}): {2} | IsPlaying: {3}";
					object[] array = new object[4];
					array[0] = base.transform.name;
					int num2 = 1;
					Transform parent = base.transform.parent;
					array[num2] = ((parent != null) ? parent.name : null);
					array[2] = num;
					array[3] = playback_STATE;
					UnityEngine.Debug.Log(string.Format(format, array));
					this.lastDist = num;
					this.lastPlaying = playback_STATE;
				}
			}
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x00009EF5 File Offset: 0x000080F5
		private void OnApplicationQuit()
		{
			this.isQuitting = true;
		}

		// Token: 0x06000724 RID: 1828 RVA: 0x00009F00 File Offset: 0x00008100
		private void OnDestroy()
		{
			if (!this.isQuitting)
			{
				this.HandleGameEvent(EmitterGameEvent.ObjectDestroy);
				if (this.instance.isValid())
				{
					RuntimeManager.DetachInstanceFromGameObject(this.instance);
					if (this.eventDescription.isValid() && this.isOneshot)
					{
						this.instance.release();
						this.instance.clearHandle();
					}
				}
				RuntimeManager.DeregisterActiveEmitter(this);
				if (this.Preload)
				{
					this.eventDescription.unloadSampleData();
				}
			}
		}

		// Token: 0x06000725 RID: 1829 RVA: 0x00009F7C File Offset: 0x0000817C
		protected override void HandleGameEvent(EmitterGameEvent gameEvent)
		{
			string format = "{0} in {1}";
			object name = base.name;
			Transform parent = base.transform.parent;
			string item = string.Format(format, name, (parent != null) ? parent.name : null);
			if (this.PlayEvent == gameEvent)
			{
				if (StudioEventEmitter.Listener != null && !StudioEventEmitter.Listener.EventsPlaying.Contains(item))
				{
					StudioEventEmitter.Listener.EventsPlaying.Add(item);
				}
				if (!this.IsPlaying())
				{
					this.Play();
				}
			}
			if (this.StopEvent == gameEvent)
			{
				if (StudioEventEmitter.Listener != null && StudioEventEmitter.Listener.EventsPlaying.Contains(item))
				{
					StudioEventEmitter.Listener.EventsPlaying.Remove(item);
				}
				if (this.IsPlaying())
				{
					this.Stop();
				}
			}
		}

		// Token: 0x06000726 RID: 1830 RVA: 0x0000A040 File Offset: 0x00008240
		private void Lookup()
		{
			if (string.IsNullOrEmpty(this.Event))
			{
				return;
			}
			this.eventDescription = RuntimeManager.GetEventDescription(this.Event);
			if (this.eventDescription.isValid())
			{
				for (int i = 0; i < this.Params.Length; i++)
				{
					PARAMETER_DESCRIPTION parameter_DESCRIPTION;
					this.eventDescription.getParameterDescriptionByName(this.Params[i].Name, out parameter_DESCRIPTION);
					this.Params[i].ID = parameter_DESCRIPTION.id;
				}
			}
			this.eventDescription.is3D(out this.is3D);
			if (this.is3D)
			{
				this.maxDistance = -1f;
				PARAMETER_DESCRIPTION parameter_DESCRIPTION2;
				if (this.eventDescription.getParameterDescriptionByName("Distance", out parameter_DESCRIPTION2) == RESULT.OK)
				{
					this.maxDistance = parameter_DESCRIPTION2.maximum;
				}
				if (this.maxDistance <= 0f)
				{
					this.eventDescription.getMaximumDistance(out this.maxDistance);
				}
			}
		}

		// Token: 0x06000727 RID: 1831 RVA: 0x0000A120 File Offset: 0x00008320
		public void Play()
		{
			if (this.TriggerOnce && this.hasTriggered)
			{
				return;
			}
			if (string.IsNullOrEmpty(this.Event))
			{
				return;
			}
			this.cachedParams.Clear();
			if (Time.timeScale == 0f && this.IsPausable)
			{
				return;
			}
			if (!this.eventDescription.isValid() || this.Event != this.lastEventPath)
			{
				this.lastEventPath = this.Event;
				this.Lookup();
			}
			if (!this.Event.StartsWith("snapshot", StringComparison.CurrentCultureIgnoreCase))
			{
				this.eventDescription.isOneshot(out this.isOneshot);
			}
			bool flag;
			this.eventDescription.is3D(out flag);
			this.IsActive = true;
			if (flag && !this.isOneshot && Settings.Instance.StopEventsOutsideMaxDistance)
			{
				RuntimeManager.RegisterActiveEmitter(this);
				RuntimeManager.UpdateActiveEmitter(this, true);
				return;
			}
			this.PlayInstance();
		}

		// Token: 0x06000728 RID: 1832 RVA: 0x0000A204 File Offset: 0x00008404
		public void PlayInstance()
		{
			if (!this.instance.isValid())
			{
				this.instance.clearHandle();
			}
			if (this.isOneshot && this.instance.isValid())
			{
				this.instance.release();
				this.instance.clearHandle();
			}
			bool flag;
			this.eventDescription.is3D(out flag);
			if (!this.instance.isValid())
			{
				this.eventDescription.createInstance(out this.instance);
				PARAMETER_DESCRIPTION parameter_DESCRIPTION;
				this.eventDescription.getParameterDescriptionByName("HasScatterer", out parameter_DESCRIPTION);
				bool flag2 = parameter_DESCRIPTION.defaultvalue == 1f;
				if (flag || flag2)
				{
					Transform component = base.GetComponent<Transform>();
					if (base.GetComponent<Rigidbody>())
					{
						Rigidbody component2 = base.GetComponent<Rigidbody>();
						this.instance.set3DAttributes(RuntimeUtils.To3DAttributes(base.gameObject, component2));
						RuntimeManager.AttachInstanceToGameObject(this.instance, component, component2);
					}
					else if (base.GetComponent<Rigidbody2D>())
					{
						Rigidbody2D component3 = base.GetComponent<Rigidbody2D>();
						this.instance.set3DAttributes(RuntimeUtils.To3DAttributes(base.gameObject, component3));
						RuntimeManager.AttachInstanceToGameObject(this.instance, component, component3);
					}
					else
					{
						this.instance.set3DAttributes(base.gameObject.To3DAttributes());
						RuntimeManager.AttachInstanceToGameObject(this.instance, component);
					}
				}
			}
			foreach (ParamRef paramRef in this.Params)
			{
				this.instance.setParameterByID(paramRef.ID, paramRef.Value, false);
			}
			foreach (ParamRef paramRef2 in this.cachedParams)
			{
				this.instance.setParameterByID(paramRef2.ID, paramRef2.Value, false);
			}
			if (flag && this.OverrideAttenuation)
			{
				this.instance.setProperty(EVENT_PROPERTY.MINIMUM_DISTANCE, this.OverrideMinDistance);
				this.instance.setProperty(EVENT_PROPERTY.MAXIMUM_DISTANCE, this.OverrideMaxDistance);
			}
			this.instance.start();
			this.hasTriggered = true;
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x0000A434 File Offset: 0x00008634
		public void Stop()
		{
			RuntimeManager.DeregisterActiveEmitter(this);
			this.IsActive = false;
			this.cachedParams.Clear();
			this.StopInstance();
		}

		// Token: 0x0600072A RID: 1834 RVA: 0x0000A454 File Offset: 0x00008654
		public void StopInstance()
		{
			if (this.TriggerOnce && this.hasTriggered)
			{
				RuntimeManager.DeregisterActiveEmitter(this);
			}
			if (this.instance.isValid())
			{
				this.instance.stop(this.AllowFadeout ? STOP_MODE.ALLOWFADEOUT : STOP_MODE.IMMEDIATE);
				this.instance.release();
				this.instance.clearHandle();
			}
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x0000A4B4 File Offset: 0x000086B4
		public void SetParameter(string name, float value, bool ignoreseekspeed = false)
		{
			if (Settings.Instance.StopEventsOutsideMaxDistance && this.IsActive)
			{
				ParamRef paramRef = this.cachedParams.Find((ParamRef x) => x.Name == name);
				if (paramRef == null)
				{
					PARAMETER_DESCRIPTION parameter_DESCRIPTION;
					this.eventDescription.getParameterDescriptionByName(name, out parameter_DESCRIPTION);
					paramRef = new ParamRef();
					paramRef.ID = parameter_DESCRIPTION.id;
					paramRef.Name = parameter_DESCRIPTION.name;
					this.cachedParams.Add(paramRef);
				}
				paramRef.Value = value;
			}
			if (this.instance.isValid())
			{
				this.instance.setParameterByName(name, value, ignoreseekspeed);
			}
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x0000A568 File Offset: 0x00008768
		public void SetParameter(PARAMETER_ID id, float value, bool ignoreseekspeed = false)
		{
			if (Settings.Instance.StopEventsOutsideMaxDistance && this.IsActive)
			{
				ParamRef paramRef = this.cachedParams.Find((ParamRef x) => x.ID.Equals(id));
				if (paramRef == null)
				{
					PARAMETER_DESCRIPTION parameter_DESCRIPTION;
					this.eventDescription.getParameterDescriptionByID(id, out parameter_DESCRIPTION);
					paramRef = new ParamRef();
					paramRef.ID = parameter_DESCRIPTION.id;
					paramRef.Name = parameter_DESCRIPTION.name;
					this.cachedParams.Add(paramRef);
				}
				paramRef.Value = value;
			}
			if (this.instance.isValid())
			{
				this.instance.setParameterByID(id, value, ignoreseekspeed);
			}
		}

		// Token: 0x0600072D RID: 1837 RVA: 0x0000A61C File Offset: 0x0000881C
		public bool IsPlaying()
		{
			if (this.instance.isValid())
			{
				PLAYBACK_STATE playback_STATE;
				this.instance.getPlaybackState(out playback_STATE);
				return playback_STATE != PLAYBACK_STATE.STOPPED;
			}
			return false;
		}

		// Token: 0x040005C2 RID: 1474
		[EventRef]
		public string Event = "";

		// Token: 0x040005C3 RID: 1475
		public EmitterGameEvent PlayEvent;

		// Token: 0x040005C4 RID: 1476
		public EmitterGameEvent StopEvent;

		// Token: 0x040005C5 RID: 1477
		public bool AllowFadeout = true;

		// Token: 0x040005C6 RID: 1478
		public bool TriggerOnce;

		// Token: 0x040005C7 RID: 1479
		public bool EnableLogging;

		// Token: 0x040005C8 RID: 1480
		public bool PlayOnDistanceEnter = true;

		// Token: 0x040005C9 RID: 1481
		public bool StopOnDistanceExit = true;

		// Token: 0x040005CA RID: 1482
		public bool IsPausable = true;

		// Token: 0x040005CB RID: 1483
		public static StudioListener Listener;

		// Token: 0x040005CC RID: 1484
		public bool LogDistanceToListener;

		// Token: 0x040005CD RID: 1485
		public bool Preload;

		// Token: 0x040005CE RID: 1486
		public ParamRef[] Params = new ParamRef[0];

		// Token: 0x040005CF RID: 1487
		public bool OverrideAttenuation;

		// Token: 0x040005D0 RID: 1488
		public float OverrideMinDistance = -1f;

		// Token: 0x040005D1 RID: 1489
		public float OverrideMaxDistance = -1f;

		// Token: 0x040005D2 RID: 1490
		public float Pitch = 1f;

		// Token: 0x040005D3 RID: 1491
		[NonSerialized]
		public bool logic_visible = true;

		// Token: 0x040005D4 RID: 1492
		protected EventDescription eventDescription;

		// Token: 0x040005D5 RID: 1493
		protected EventInstance instance;

		// Token: 0x040005D6 RID: 1494
		private bool hasTriggered;

		// Token: 0x040005D7 RID: 1495
		private bool isQuitting;

		// Token: 0x040005D8 RID: 1496
		private bool isOneshot;

		// Token: 0x040005D9 RID: 1497
		private List<ParamRef> cachedParams = new List<ParamRef>();

		// Token: 0x040005DA RID: 1498
		private bool is3D;

		// Token: 0x040005DB RID: 1499
		private float maxDistance = -1f;

		// Token: 0x040005DC RID: 1500
		private float lastDist = -1f;

		// Token: 0x040005DD RID: 1501
		private string lastEventPath;

		// Token: 0x040005DE RID: 1502
		private PLAYBACK_STATE lastPlaying = PLAYBACK_STATE.SUSTAINING;

		// Token: 0x040005DF RID: 1503
		private const string SnapshotString = "snapshot";
	}
}
