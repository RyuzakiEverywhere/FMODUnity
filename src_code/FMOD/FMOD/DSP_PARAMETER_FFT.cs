using System;
using System.Runtime.InteropServices;

namespace FMOD
{
	// Token: 0x02000088 RID: 136
	public struct DSP_PARAMETER_FFT
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000461 RID: 1121 RVA: 0x00004948 File Offset: 0x00002B48
		public float[][] spectrum
		{
			get
			{
				float[][] array = new float[this.numchannels][];
				for (int i = 0; i < this.numchannels; i++)
				{
					array[i] = new float[this.length];
					Marshal.Copy(this.spectrum_internal[i], array[i], 0, this.length);
				}
				return array;
			}
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x00004998 File Offset: 0x00002B98
		public void getSpectrum(ref float[][] buffer)
		{
			int num = Math.Min(buffer.Length, this.numchannels);
			for (int i = 0; i < num; i++)
			{
				this.getSpectrum(i, ref buffer[i]);
			}
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x000049D0 File Offset: 0x00002BD0
		public void getSpectrum(int channel, ref float[] buffer)
		{
			int num = Math.Min(buffer.Length, this.length);
			Marshal.Copy(this.spectrum_internal[channel], buffer, 0, num);
		}

		// Token: 0x040002B1 RID: 689
		public int length;

		// Token: 0x040002B2 RID: 690
		public int numchannels;

		// Token: 0x040002B3 RID: 691
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		private IntPtr[] spectrum_internal;
	}
}
