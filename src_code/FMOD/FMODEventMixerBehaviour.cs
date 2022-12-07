using System;
using UnityEngine;
using UnityEngine.Playables;

namespace FMODUnity
{
	// Token: 0x0200011D RID: 285
	[Serializable]
	public class FMODEventMixerBehaviour : PlayableBehaviour
	{
		// Token: 0x06000751 RID: 1873 RVA: 0x0000AF3C File Offset: 0x0000913C
		public override void ProcessFrame(Playable playable, FrameData info, object playerData)
		{
			int inputCount = playable.GetInputCount<Playable>();
			float time = (float)playable.GetGraph<Playable>().GetRootPlayable(0).GetTime<Playable>();
			for (int i = 0; i < inputCount; i++)
			{
				((ScriptPlayable<T>)playable.GetInput(i)).GetBehaviour().UpdateBehavior(time, this.volume);
			}
		}

		// Token: 0x04000609 RID: 1545
		[Range(0f, 1f)]
		public float volume = 1f;
	}
}
