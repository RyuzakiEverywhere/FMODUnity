using System;
using System.Runtime.InteropServices;

namespace FMOD
{
	// Token: 0x0200004A RID: 74
	public struct DSPConnection
	{
		// Token: 0x06000376 RID: 886 RVA: 0x00004595 File Offset: 0x00002795
		public RESULT getInput(out DSP input)
		{
			return DSPConnection.FMOD5_DSPConnection_GetInput(this.handle, out input.handle);
		}

		// Token: 0x06000377 RID: 887 RVA: 0x000045A8 File Offset: 0x000027A8
		public RESULT getOutput(out DSP output)
		{
			return DSPConnection.FMOD5_DSPConnection_GetOutput(this.handle, out output.handle);
		}

		// Token: 0x06000378 RID: 888 RVA: 0x000045BB File Offset: 0x000027BB
		public RESULT setMix(float volume)
		{
			return DSPConnection.FMOD5_DSPConnection_SetMix(this.handle, volume);
		}

		// Token: 0x06000379 RID: 889 RVA: 0x000045C9 File Offset: 0x000027C9
		public RESULT getMix(out float volume)
		{
			return DSPConnection.FMOD5_DSPConnection_GetMix(this.handle, out volume);
		}

		// Token: 0x0600037A RID: 890 RVA: 0x000045D7 File Offset: 0x000027D7
		public RESULT setMixMatrix(float[] matrix, int outchannels, int inchannels, int inchannel_hop = 0)
		{
			return DSPConnection.FMOD5_DSPConnection_SetMixMatrix(this.handle, matrix, outchannels, inchannels, inchannel_hop);
		}

		// Token: 0x0600037B RID: 891 RVA: 0x000045E9 File Offset: 0x000027E9
		public RESULT getMixMatrix(float[] matrix, out int outchannels, out int inchannels, int inchannel_hop = 0)
		{
			return DSPConnection.FMOD5_DSPConnection_GetMixMatrix(this.handle, matrix, out outchannels, out inchannels, inchannel_hop);
		}

		// Token: 0x0600037C RID: 892 RVA: 0x000045FB File Offset: 0x000027FB
		public RESULT getType(out DSPCONNECTION_TYPE type)
		{
			return DSPConnection.FMOD5_DSPConnection_GetType(this.handle, out type);
		}

		// Token: 0x0600037D RID: 893 RVA: 0x00004609 File Offset: 0x00002809
		public RESULT setUserData(IntPtr userdata)
		{
			return DSPConnection.FMOD5_DSPConnection_SetUserData(this.handle, userdata);
		}

		// Token: 0x0600037E RID: 894 RVA: 0x00004617 File Offset: 0x00002817
		public RESULT getUserData(out IntPtr userdata)
		{
			return DSPConnection.FMOD5_DSPConnection_GetUserData(this.handle, out userdata);
		}

		// Token: 0x0600037F RID: 895
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSPConnection_GetInput(IntPtr dspconnection, out IntPtr input);

		// Token: 0x06000380 RID: 896
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSPConnection_GetOutput(IntPtr dspconnection, out IntPtr output);

		// Token: 0x06000381 RID: 897
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSPConnection_SetMix(IntPtr dspconnection, float volume);

		// Token: 0x06000382 RID: 898
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSPConnection_GetMix(IntPtr dspconnection, out float volume);

		// Token: 0x06000383 RID: 899
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSPConnection_SetMixMatrix(IntPtr dspconnection, float[] matrix, int outchannels, int inchannels, int inchannel_hop);

		// Token: 0x06000384 RID: 900
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSPConnection_GetMixMatrix(IntPtr dspconnection, float[] matrix, out int outchannels, out int inchannels, int inchannel_hop);

		// Token: 0x06000385 RID: 901
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSPConnection_GetType(IntPtr dspconnection, out DSPCONNECTION_TYPE type);

		// Token: 0x06000386 RID: 902
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSPConnection_SetUserData(IntPtr dspconnection, IntPtr userdata);

		// Token: 0x06000387 RID: 903
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSPConnection_GetUserData(IntPtr dspconnection, out IntPtr userdata);

		// Token: 0x06000388 RID: 904 RVA: 0x00004625 File Offset: 0x00002825
		public DSPConnection(IntPtr ptr)
		{
			this.handle = ptr;
		}

		// Token: 0x06000389 RID: 905 RVA: 0x0000462E File Offset: 0x0000282E
		public bool hasHandle()
		{
			return this.handle != IntPtr.Zero;
		}

		// Token: 0x0600038A RID: 906 RVA: 0x00004640 File Offset: 0x00002840
		public void clearHandle()
		{
			this.handle = IntPtr.Zero;
		}

		// Token: 0x04000244 RID: 580
		public IntPtr handle;
	}
}
