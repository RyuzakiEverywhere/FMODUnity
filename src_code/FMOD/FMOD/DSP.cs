using System;
using System.Runtime.InteropServices;

namespace FMOD
{
	// Token: 0x02000049 RID: 73
	public struct DSP
	{
		// Token: 0x0600031C RID: 796 RVA: 0x00004204 File Offset: 0x00002404
		public RESULT release()
		{
			return DSP.FMOD5_DSP_Release(this.handle);
		}

		// Token: 0x0600031D RID: 797 RVA: 0x00004211 File Offset: 0x00002411
		public RESULT getSystemObject(out System system)
		{
			return DSP.FMOD5_DSP_GetSystemObject(this.handle, out system.handle);
		}

		// Token: 0x0600031E RID: 798 RVA: 0x00004224 File Offset: 0x00002424
		public RESULT addInput(DSP input)
		{
			return DSP.FMOD5_DSP_AddInput(this.handle, input.handle, IntPtr.Zero, DSPCONNECTION_TYPE.STANDARD);
		}

		// Token: 0x0600031F RID: 799 RVA: 0x0000423D File Offset: 0x0000243D
		public RESULT addInput(DSP input, out DSPConnection connection, DSPCONNECTION_TYPE type = DSPCONNECTION_TYPE.STANDARD)
		{
			return DSP.FMOD5_DSP_AddInput(this.handle, input.handle, out connection.handle, type);
		}

		// Token: 0x06000320 RID: 800 RVA: 0x00004257 File Offset: 0x00002457
		public RESULT disconnectFrom(DSP target, DSPConnection connection)
		{
			return DSP.FMOD5_DSP_DisconnectFrom(this.handle, target.handle, connection.handle);
		}

		// Token: 0x06000321 RID: 801 RVA: 0x00004270 File Offset: 0x00002470
		public RESULT disconnectAll(bool inputs, bool outputs)
		{
			return DSP.FMOD5_DSP_DisconnectAll(this.handle, inputs, outputs);
		}

		// Token: 0x06000322 RID: 802 RVA: 0x0000427F File Offset: 0x0000247F
		public RESULT getNumInputs(out int numinputs)
		{
			return DSP.FMOD5_DSP_GetNumInputs(this.handle, out numinputs);
		}

		// Token: 0x06000323 RID: 803 RVA: 0x0000428D File Offset: 0x0000248D
		public RESULT getNumOutputs(out int numoutputs)
		{
			return DSP.FMOD5_DSP_GetNumOutputs(this.handle, out numoutputs);
		}

		// Token: 0x06000324 RID: 804 RVA: 0x0000429B File Offset: 0x0000249B
		public RESULT getInput(int index, out DSP input, out DSPConnection inputconnection)
		{
			return DSP.FMOD5_DSP_GetInput(this.handle, index, out input.handle, out inputconnection.handle);
		}

		// Token: 0x06000325 RID: 805 RVA: 0x000042B5 File Offset: 0x000024B5
		public RESULT getOutput(int index, out DSP output, out DSPConnection outputconnection)
		{
			return DSP.FMOD5_DSP_GetOutput(this.handle, index, out output.handle, out outputconnection.handle);
		}

		// Token: 0x06000326 RID: 806 RVA: 0x000042CF File Offset: 0x000024CF
		public RESULT setActive(bool active)
		{
			return DSP.FMOD5_DSP_SetActive(this.handle, active);
		}

		// Token: 0x06000327 RID: 807 RVA: 0x000042DD File Offset: 0x000024DD
		public RESULT getActive(out bool active)
		{
			return DSP.FMOD5_DSP_GetActive(this.handle, out active);
		}

		// Token: 0x06000328 RID: 808 RVA: 0x000042EB File Offset: 0x000024EB
		public RESULT setBypass(bool bypass)
		{
			return DSP.FMOD5_DSP_SetBypass(this.handle, bypass);
		}

		// Token: 0x06000329 RID: 809 RVA: 0x000042F9 File Offset: 0x000024F9
		public RESULT getBypass(out bool bypass)
		{
			return DSP.FMOD5_DSP_GetBypass(this.handle, out bypass);
		}

		// Token: 0x0600032A RID: 810 RVA: 0x00004307 File Offset: 0x00002507
		public RESULT setWetDryMix(float prewet, float postwet, float dry)
		{
			return DSP.FMOD5_DSP_SetWetDryMix(this.handle, prewet, postwet, dry);
		}

		// Token: 0x0600032B RID: 811 RVA: 0x00004317 File Offset: 0x00002517
		public RESULT getWetDryMix(out float prewet, out float postwet, out float dry)
		{
			return DSP.FMOD5_DSP_GetWetDryMix(this.handle, out prewet, out postwet, out dry);
		}

		// Token: 0x0600032C RID: 812 RVA: 0x00004327 File Offset: 0x00002527
		public RESULT setChannelFormat(CHANNELMASK channelmask, int numchannels, SPEAKERMODE source_speakermode)
		{
			return DSP.FMOD5_DSP_SetChannelFormat(this.handle, channelmask, numchannels, source_speakermode);
		}

		// Token: 0x0600032D RID: 813 RVA: 0x00004337 File Offset: 0x00002537
		public RESULT getChannelFormat(out CHANNELMASK channelmask, out int numchannels, out SPEAKERMODE source_speakermode)
		{
			return DSP.FMOD5_DSP_GetChannelFormat(this.handle, out channelmask, out numchannels, out source_speakermode);
		}

		// Token: 0x0600032E RID: 814 RVA: 0x00004347 File Offset: 0x00002547
		public RESULT getOutputChannelFormat(CHANNELMASK inmask, int inchannels, SPEAKERMODE inspeakermode, out CHANNELMASK outmask, out int outchannels, out SPEAKERMODE outspeakermode)
		{
			return DSP.FMOD5_DSP_GetOutputChannelFormat(this.handle, inmask, inchannels, inspeakermode, out outmask, out outchannels, out outspeakermode);
		}

		// Token: 0x0600032F RID: 815 RVA: 0x0000435D File Offset: 0x0000255D
		public RESULT reset()
		{
			return DSP.FMOD5_DSP_Reset(this.handle);
		}

		// Token: 0x06000330 RID: 816 RVA: 0x0000436A File Offset: 0x0000256A
		public RESULT setParameterFloat(int index, float value)
		{
			return DSP.FMOD5_DSP_SetParameterFloat(this.handle, index, value);
		}

		// Token: 0x06000331 RID: 817 RVA: 0x00004379 File Offset: 0x00002579
		public RESULT setParameterInt(int index, int value)
		{
			return DSP.FMOD5_DSP_SetParameterInt(this.handle, index, value);
		}

		// Token: 0x06000332 RID: 818 RVA: 0x00004388 File Offset: 0x00002588
		public RESULT setParameterBool(int index, bool value)
		{
			return DSP.FMOD5_DSP_SetParameterBool(this.handle, index, value);
		}

		// Token: 0x06000333 RID: 819 RVA: 0x00004397 File Offset: 0x00002597
		public RESULT setParameterData(int index, byte[] data)
		{
			return DSP.FMOD5_DSP_SetParameterData(this.handle, index, Marshal.UnsafeAddrOfPinnedArrayElement<byte>(data, 0), (uint)data.Length);
		}

		// Token: 0x06000334 RID: 820 RVA: 0x000043AF File Offset: 0x000025AF
		public RESULT getParameterFloat(int index, out float value)
		{
			return DSP.FMOD5_DSP_GetParameterFloat(this.handle, index, out value, IntPtr.Zero, 0);
		}

		// Token: 0x06000335 RID: 821 RVA: 0x000043C4 File Offset: 0x000025C4
		public RESULT getParameterInt(int index, out int value)
		{
			return DSP.FMOD5_DSP_GetParameterInt(this.handle, index, out value, IntPtr.Zero, 0);
		}

		// Token: 0x06000336 RID: 822 RVA: 0x000043D9 File Offset: 0x000025D9
		public RESULT getParameterBool(int index, out bool value)
		{
			return DSP.FMOD5_DSP_GetParameterBool(this.handle, index, out value, IntPtr.Zero, 0);
		}

		// Token: 0x06000337 RID: 823 RVA: 0x000043EE File Offset: 0x000025EE
		public RESULT getParameterData(int index, out IntPtr data, out uint length)
		{
			return DSP.FMOD5_DSP_GetParameterData(this.handle, index, out data, out length, IntPtr.Zero, 0);
		}

		// Token: 0x06000338 RID: 824 RVA: 0x00004404 File Offset: 0x00002604
		public RESULT getNumParameters(out int numparams)
		{
			return DSP.FMOD5_DSP_GetNumParameters(this.handle, out numparams);
		}

		// Token: 0x06000339 RID: 825 RVA: 0x00004414 File Offset: 0x00002614
		public RESULT getParameterInfo(int index, out DSP_PARAMETER_DESC desc)
		{
			IntPtr ptr;
			RESULT result = DSP.FMOD5_DSP_GetParameterInfo(this.handle, index, out ptr);
			desc = (DSP_PARAMETER_DESC)MarshalHelper.PtrToStructure(ptr, typeof(DSP_PARAMETER_DESC));
			return result;
		}

		// Token: 0x0600033A RID: 826 RVA: 0x0000444A File Offset: 0x0000264A
		public RESULT getDataParameterIndex(int datatype, out int index)
		{
			return DSP.FMOD5_DSP_GetDataParameterIndex(this.handle, datatype, out index);
		}

		// Token: 0x0600033B RID: 827 RVA: 0x00004459 File Offset: 0x00002659
		public RESULT showConfigDialog(IntPtr hwnd, bool show)
		{
			return DSP.FMOD5_DSP_ShowConfigDialog(this.handle, hwnd, show);
		}

		// Token: 0x0600033C RID: 828 RVA: 0x00004468 File Offset: 0x00002668
		public RESULT getInfo(out string name, out uint version, out int channels, out int configwidth, out int configheight)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(32);
			RESULT result = DSP.FMOD5_DSP_GetInfo(this.handle, intPtr, out version, out channels, out configwidth, out configheight);
			using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
			{
				name = freeHelper.stringFromNative(intPtr);
			}
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		// Token: 0x0600033D RID: 829 RVA: 0x000044C4 File Offset: 0x000026C4
		public RESULT getInfo(out uint version, out int channels, out int configwidth, out int configheight)
		{
			return DSP.FMOD5_DSP_GetInfo(this.handle, IntPtr.Zero, out version, out channels, out configwidth, out configheight);
		}

		// Token: 0x0600033E RID: 830 RVA: 0x000044DB File Offset: 0x000026DB
		public RESULT getType(out DSP_TYPE type)
		{
			return DSP.FMOD5_DSP_GetType(this.handle, out type);
		}

		// Token: 0x0600033F RID: 831 RVA: 0x000044E9 File Offset: 0x000026E9
		public RESULT getIdle(out bool idle)
		{
			return DSP.FMOD5_DSP_GetIdle(this.handle, out idle);
		}

		// Token: 0x06000340 RID: 832 RVA: 0x000044F7 File Offset: 0x000026F7
		public RESULT setUserData(IntPtr userdata)
		{
			return DSP.FMOD5_DSP_SetUserData(this.handle, userdata);
		}

		// Token: 0x06000341 RID: 833 RVA: 0x00004505 File Offset: 0x00002705
		public RESULT getUserData(out IntPtr userdata)
		{
			return DSP.FMOD5_DSP_GetUserData(this.handle, out userdata);
		}

		// Token: 0x06000342 RID: 834 RVA: 0x00004513 File Offset: 0x00002713
		public RESULT setMeteringEnabled(bool inputEnabled, bool outputEnabled)
		{
			return DSP.FMOD5_DSP_SetMeteringEnabled(this.handle, inputEnabled, outputEnabled);
		}

		// Token: 0x06000343 RID: 835 RVA: 0x00004522 File Offset: 0x00002722
		public RESULT getMeteringEnabled(out bool inputEnabled, out bool outputEnabled)
		{
			return DSP.FMOD5_DSP_GetMeteringEnabled(this.handle, out inputEnabled, out outputEnabled);
		}

		// Token: 0x06000344 RID: 836 RVA: 0x00004531 File Offset: 0x00002731
		public RESULT getMeteringInfo(IntPtr zero, out DSP_METERING_INFO outputInfo)
		{
			return DSP.FMOD5_DSP_GetMeteringInfo(this.handle, zero, out outputInfo);
		}

		// Token: 0x06000345 RID: 837 RVA: 0x00004540 File Offset: 0x00002740
		public RESULT getMeteringInfo(out DSP_METERING_INFO inputInfo, IntPtr zero)
		{
			return DSP.FMOD5_DSP_GetMeteringInfo(this.handle, out inputInfo, zero);
		}

		// Token: 0x06000346 RID: 838 RVA: 0x0000454F File Offset: 0x0000274F
		public RESULT getMeteringInfo(out DSP_METERING_INFO inputInfo, out DSP_METERING_INFO outputInfo)
		{
			return DSP.FMOD5_DSP_GetMeteringInfo(this.handle, out inputInfo, out outputInfo);
		}

		// Token: 0x06000347 RID: 839 RVA: 0x0000455E File Offset: 0x0000275E
		public RESULT getCPUUsage(out uint exclusive, out uint inclusive)
		{
			return DSP.FMOD5_DSP_GetCPUUsage(this.handle, out exclusive, out inclusive);
		}

		// Token: 0x06000348 RID: 840
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_Release(IntPtr dsp);

		// Token: 0x06000349 RID: 841
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_GetSystemObject(IntPtr dsp, out IntPtr system);

		// Token: 0x0600034A RID: 842
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_AddInput(IntPtr dsp, IntPtr input, IntPtr zero, DSPCONNECTION_TYPE type);

		// Token: 0x0600034B RID: 843
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_AddInput(IntPtr dsp, IntPtr input, out IntPtr connection, DSPCONNECTION_TYPE type);

		// Token: 0x0600034C RID: 844
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_DisconnectFrom(IntPtr dsp, IntPtr target, IntPtr connection);

		// Token: 0x0600034D RID: 845
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_DisconnectAll(IntPtr dsp, bool inputs, bool outputs);

		// Token: 0x0600034E RID: 846
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_GetNumInputs(IntPtr dsp, out int numinputs);

		// Token: 0x0600034F RID: 847
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_GetNumOutputs(IntPtr dsp, out int numoutputs);

		// Token: 0x06000350 RID: 848
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_GetInput(IntPtr dsp, int index, out IntPtr input, out IntPtr inputconnection);

		// Token: 0x06000351 RID: 849
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_GetOutput(IntPtr dsp, int index, out IntPtr output, out IntPtr outputconnection);

		// Token: 0x06000352 RID: 850
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_SetActive(IntPtr dsp, bool active);

		// Token: 0x06000353 RID: 851
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_GetActive(IntPtr dsp, out bool active);

		// Token: 0x06000354 RID: 852
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_SetBypass(IntPtr dsp, bool bypass);

		// Token: 0x06000355 RID: 853
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_GetBypass(IntPtr dsp, out bool bypass);

		// Token: 0x06000356 RID: 854
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_SetWetDryMix(IntPtr dsp, float prewet, float postwet, float dry);

		// Token: 0x06000357 RID: 855
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_GetWetDryMix(IntPtr dsp, out float prewet, out float postwet, out float dry);

		// Token: 0x06000358 RID: 856
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_SetChannelFormat(IntPtr dsp, CHANNELMASK channelmask, int numchannels, SPEAKERMODE source_speakermode);

		// Token: 0x06000359 RID: 857
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_GetChannelFormat(IntPtr dsp, out CHANNELMASK channelmask, out int numchannels, out SPEAKERMODE source_speakermode);

		// Token: 0x0600035A RID: 858
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_GetOutputChannelFormat(IntPtr dsp, CHANNELMASK inmask, int inchannels, SPEAKERMODE inspeakermode, out CHANNELMASK outmask, out int outchannels, out SPEAKERMODE outspeakermode);

		// Token: 0x0600035B RID: 859
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_Reset(IntPtr dsp);

		// Token: 0x0600035C RID: 860
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_SetParameterFloat(IntPtr dsp, int index, float value);

		// Token: 0x0600035D RID: 861
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_SetParameterInt(IntPtr dsp, int index, int value);

		// Token: 0x0600035E RID: 862
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_SetParameterBool(IntPtr dsp, int index, bool value);

		// Token: 0x0600035F RID: 863
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_SetParameterData(IntPtr dsp, int index, IntPtr data, uint length);

		// Token: 0x06000360 RID: 864
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_GetParameterFloat(IntPtr dsp, int index, out float value, IntPtr valuestr, int valuestrlen);

		// Token: 0x06000361 RID: 865
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_GetParameterInt(IntPtr dsp, int index, out int value, IntPtr valuestr, int valuestrlen);

		// Token: 0x06000362 RID: 866
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_GetParameterBool(IntPtr dsp, int index, out bool value, IntPtr valuestr, int valuestrlen);

		// Token: 0x06000363 RID: 867
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_GetParameterData(IntPtr dsp, int index, out IntPtr data, out uint length, IntPtr valuestr, int valuestrlen);

		// Token: 0x06000364 RID: 868
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_GetNumParameters(IntPtr dsp, out int numparams);

		// Token: 0x06000365 RID: 869
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_GetParameterInfo(IntPtr dsp, int index, out IntPtr desc);

		// Token: 0x06000366 RID: 870
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_GetDataParameterIndex(IntPtr dsp, int datatype, out int index);

		// Token: 0x06000367 RID: 871
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_ShowConfigDialog(IntPtr dsp, IntPtr hwnd, bool show);

		// Token: 0x06000368 RID: 872
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_GetInfo(IntPtr dsp, IntPtr name, out uint version, out int channels, out int configwidth, out int configheight);

		// Token: 0x06000369 RID: 873
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_GetType(IntPtr dsp, out DSP_TYPE type);

		// Token: 0x0600036A RID: 874
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_GetIdle(IntPtr dsp, out bool idle);

		// Token: 0x0600036B RID: 875
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_SetUserData(IntPtr dsp, IntPtr userdata);

		// Token: 0x0600036C RID: 876
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_DSP_GetUserData(IntPtr dsp, out IntPtr userdata);

		// Token: 0x0600036D RID: 877
		[DllImport("fmodstudio")]
		public static extern RESULT FMOD5_DSP_SetMeteringEnabled(IntPtr dsp, bool inputEnabled, bool outputEnabled);

		// Token: 0x0600036E RID: 878
		[DllImport("fmodstudio")]
		public static extern RESULT FMOD5_DSP_GetMeteringEnabled(IntPtr dsp, out bool inputEnabled, out bool outputEnabled);

		// Token: 0x0600036F RID: 879
		[DllImport("fmodstudio")]
		public static extern RESULT FMOD5_DSP_GetMeteringInfo(IntPtr dsp, IntPtr zero, out DSP_METERING_INFO outputInfo);

		// Token: 0x06000370 RID: 880
		[DllImport("fmodstudio")]
		public static extern RESULT FMOD5_DSP_GetMeteringInfo(IntPtr dsp, out DSP_METERING_INFO inputInfo, IntPtr zero);

		// Token: 0x06000371 RID: 881
		[DllImport("fmodstudio")]
		public static extern RESULT FMOD5_DSP_GetMeteringInfo(IntPtr dsp, out DSP_METERING_INFO inputInfo, out DSP_METERING_INFO outputInfo);

		// Token: 0x06000372 RID: 882
		[DllImport("fmodstudio")]
		public static extern RESULT FMOD5_DSP_GetCPUUsage(IntPtr dsp, out uint exclusive, out uint inclusive);

		// Token: 0x06000373 RID: 883 RVA: 0x0000456D File Offset: 0x0000276D
		public DSP(IntPtr ptr)
		{
			this.handle = ptr;
		}

		// Token: 0x06000374 RID: 884 RVA: 0x00004576 File Offset: 0x00002776
		public bool hasHandle()
		{
			return this.handle != IntPtr.Zero;
		}

		// Token: 0x06000375 RID: 885 RVA: 0x00004588 File Offset: 0x00002788
		public void clearHandle()
		{
			this.handle = IntPtr.Zero;
		}

		// Token: 0x04000243 RID: 579
		public IntPtr handle;
	}
}
