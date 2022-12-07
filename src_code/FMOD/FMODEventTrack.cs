using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace FMODUnity
{
	// Token: 0x0200011C RID: 284
	[TrackColor(0.066f, 0.134f, 0.244f)]
	[TrackClipType(typeof(FMODEventPlayable))]
	[TrackBindingType(typeof(GameObject))]
	[DisplayName("FMOD/Event Track")]
	public class FMODEventTrack : TrackAsset
	{
		// Token: 0x0600074F RID: 1871 RVA: 0x0000AE9C File Offset: 0x0000909C
		public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
		{
			GameObject trackTargetObject = go.GetComponent<PlayableDirector>().GetGenericBinding(this) as GameObject;
			foreach (TimelineClip timelineClip in base.GetClips())
			{
				FMODEventPlayable fmodeventPlayable = timelineClip.asset as FMODEventPlayable;
				if (fmodeventPlayable)
				{
					fmodeventPlayable.TrackTargetObject = trackTargetObject;
					fmodeventPlayable.OwningClip = timelineClip;
				}
			}
			return ScriptPlayable<FMODEventMixerBehaviour>.Create(graph, this.template, inputCount);
		}

		// Token: 0x04000608 RID: 1544
		public FMODEventMixerBehaviour template = new FMODEventMixerBehaviour();
	}
}
