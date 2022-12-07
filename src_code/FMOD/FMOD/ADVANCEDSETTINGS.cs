using System;

namespace FMOD
{
	// Token: 0x02000039 RID: 57
	public struct ADVANCEDSETTINGS
	{
		// Token: 0x040001CE RID: 462
		public int cbSize;

		// Token: 0x040001CF RID: 463
		public int maxMPEGCodecs;

		// Token: 0x040001D0 RID: 464
		public int maxADPCMCodecs;

		// Token: 0x040001D1 RID: 465
		public int maxXMACodecs;

		// Token: 0x040001D2 RID: 466
		public int maxVorbisCodecs;

		// Token: 0x040001D3 RID: 467
		public int maxAT9Codecs;

		// Token: 0x040001D4 RID: 468
		public int maxFADPCMCodecs;

		// Token: 0x040001D5 RID: 469
		public int maxPCMCodecs;

		// Token: 0x040001D6 RID: 470
		public int ASIONumChannels;

		// Token: 0x040001D7 RID: 471
		public IntPtr ASIOChannelList;

		// Token: 0x040001D8 RID: 472
		public IntPtr ASIOSpeakerList;

		// Token: 0x040001D9 RID: 473
		public float vol0virtualvol;

		// Token: 0x040001DA RID: 474
		public uint defaultDecodeBufferSize;

		// Token: 0x040001DB RID: 475
		public ushort profilePort;

		// Token: 0x040001DC RID: 476
		public uint geometryMaxFadeTime;

		// Token: 0x040001DD RID: 477
		public float distanceFilterCenterFreq;

		// Token: 0x040001DE RID: 478
		public int reverb3Dinstance;

		// Token: 0x040001DF RID: 479
		public int DSPBufferPoolSize;

		// Token: 0x040001E0 RID: 480
		public DSP_RESAMPLER resamplerMethod;

		// Token: 0x040001E1 RID: 481
		public uint randomSeed;

		// Token: 0x040001E2 RID: 482
		public int maxConvolutionThreads;
	}
}
