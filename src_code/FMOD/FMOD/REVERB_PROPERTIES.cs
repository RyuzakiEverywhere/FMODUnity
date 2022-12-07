using System;

namespace FMOD
{
	// Token: 0x02000037 RID: 55
	public struct REVERB_PROPERTIES
	{
		// Token: 0x06000047 RID: 71 RVA: 0x00002058 File Offset: 0x00000258
		public REVERB_PROPERTIES(float decayTime, float earlyDelay, float lateDelay, float hfReference, float hfDecayRatio, float diffusion, float density, float lowShelfFrequency, float lowShelfGain, float highCut, float earlyLateMix, float wetLevel)
		{
			this.DecayTime = decayTime;
			this.EarlyDelay = earlyDelay;
			this.LateDelay = lateDelay;
			this.HFReference = hfReference;
			this.HFDecayRatio = hfDecayRatio;
			this.Diffusion = diffusion;
			this.Density = density;
			this.LowShelfFrequency = lowShelfFrequency;
			this.LowShelfGain = lowShelfGain;
			this.HighCut = highCut;
			this.EarlyLateMix = earlyLateMix;
			this.WetLevel = wetLevel;
		}

		// Token: 0x040001C2 RID: 450
		public float DecayTime;

		// Token: 0x040001C3 RID: 451
		public float EarlyDelay;

		// Token: 0x040001C4 RID: 452
		public float LateDelay;

		// Token: 0x040001C5 RID: 453
		public float HFReference;

		// Token: 0x040001C6 RID: 454
		public float HFDecayRatio;

		// Token: 0x040001C7 RID: 455
		public float Diffusion;

		// Token: 0x040001C8 RID: 456
		public float Density;

		// Token: 0x040001C9 RID: 457
		public float LowShelfFrequency;

		// Token: 0x040001CA RID: 458
		public float LowShelfGain;

		// Token: 0x040001CB RID: 459
		public float HighCut;

		// Token: 0x040001CC RID: 460
		public float EarlyLateMix;

		// Token: 0x040001CD RID: 461
		public float WetLevel;
	}
}
