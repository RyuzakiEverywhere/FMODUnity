using System;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace FMODUnity
{
	// Token: 0x02000118 RID: 280
	[Serializable]
	public class FMODEventPlayable : PlayableAsset, ITimelineClipAsset
	{
		// Token: 0x17000042 RID: 66
		// (get) Token: 0x0600073F RID: 1855 RVA: 0x0000A9FD File Offset: 0x00008BFD
		// (set) Token: 0x06000740 RID: 1856 RVA: 0x0000AA05 File Offset: 0x00008C05
		public GameObject TrackTargetObject { get; set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000741 RID: 1857 RVA: 0x0000AA0E File Offset: 0x00008C0E
		public override double duration
		{
			get
			{
				if (this.eventName == null)
				{
					return base.duration;
				}
				return (double)this.eventLength;
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000742 RID: 1858 RVA: 0x00006A1C File Offset: 0x00004C1C
		public ClipCaps clipCaps
		{
			get
			{
				return ClipCaps.None;
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000743 RID: 1859 RVA: 0x0000AA26 File Offset: 0x00008C26
		// (set) Token: 0x06000744 RID: 1860 RVA: 0x0000AA2E File Offset: 0x00008C2E
		public TimelineClip OwningClip { get; set; }

		// Token: 0x06000745 RID: 1861 RVA: 0x0000AA38 File Offset: 0x00008C38
		public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
		{
			if (!this.cachedParameters && !string.IsNullOrEmpty(this.eventName))
			{
				EventDescription eventDescription;
				RuntimeManager.StudioSystem.getEvent(this.eventName, out eventDescription);
				for (int i = 0; i < this.parameters.Length; i++)
				{
					PARAMETER_DESCRIPTION parameter_DESCRIPTION;
					eventDescription.getParameterDescriptionByName(this.parameters[i].Name, out parameter_DESCRIPTION);
					this.parameters[i].ID = parameter_DESCRIPTION.id;
				}
				List<ParameterAutomationLink> parameterLinks = this.template.parameterLinks;
				for (int j = 0; j < parameterLinks.Count; j++)
				{
					PARAMETER_DESCRIPTION parameter_DESCRIPTION2;
					eventDescription.getParameterDescriptionByName(parameterLinks[j].Name, out parameter_DESCRIPTION2);
					parameterLinks[j].ID = parameter_DESCRIPTION2.id;
				}
				this.cachedParameters = true;
			}
			ScriptPlayable<FMODEventPlayableBehavior> playable = ScriptPlayable<FMODEventPlayableBehavior>.Create(graph, this.template, 0);
			this.behavior = playable.GetBehaviour();
			this.behavior.TrackTargetObject = this.TrackTargetObject;
			this.behavior.eventName = this.eventName;
			this.behavior.stopType = this.stopType;
			this.behavior.parameters = this.parameters;
			this.behavior.OwningClip = this.OwningClip;
			return playable;
		}

		// Token: 0x040005EE RID: 1518
		public FMODEventPlayableBehavior template = new FMODEventPlayableBehavior();

		// Token: 0x040005F0 RID: 1520
		public float eventLength;

		// Token: 0x040005F1 RID: 1521
		private FMODEventPlayableBehavior behavior;

		// Token: 0x040005F2 RID: 1522
		[EventRef]
		[SerializeField]
		public string eventName;

		// Token: 0x040005F3 RID: 1523
		[SerializeField]
		public STOP_MODE stopType;

		// Token: 0x040005F4 RID: 1524
		[SerializeField]
		public ParamRef[] parameters = new ParamRef[0];

		// Token: 0x040005F5 RID: 1525
		[NonSerialized]
		public bool cachedParameters;
	}
}
