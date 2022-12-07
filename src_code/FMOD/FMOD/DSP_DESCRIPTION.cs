using System;
using System.Runtime.InteropServices;

namespace FMOD
{
	// Token: 0x0200008B RID: 139
	public struct DSP_DESCRIPTION
	{
		// Token: 0x040002BD RID: 701
		public uint pluginsdkversion;

		// Token: 0x040002BE RID: 702
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		public byte[] name;

		// Token: 0x040002BF RID: 703
		public uint version;

		// Token: 0x040002C0 RID: 704
		public int numinputbuffers;

		// Token: 0x040002C1 RID: 705
		public int numoutputbuffers;

		// Token: 0x040002C2 RID: 706
		public DSP_CREATECALLBACK create;

		// Token: 0x040002C3 RID: 707
		public DSP_RELEASECALLBACK release;

		// Token: 0x040002C4 RID: 708
		public DSP_RESETCALLBACK reset;

		// Token: 0x040002C5 RID: 709
		public DSP_READCALLBACK read;

		// Token: 0x040002C6 RID: 710
		public DSP_PROCESS_CALLBACK process;

		// Token: 0x040002C7 RID: 711
		public DSP_SETPOSITIONCALLBACK setposition;

		// Token: 0x040002C8 RID: 712
		public int numparameters;

		// Token: 0x040002C9 RID: 713
		public IntPtr paramdesc;

		// Token: 0x040002CA RID: 714
		public DSP_SETPARAM_FLOAT_CALLBACK setparameterfloat;

		// Token: 0x040002CB RID: 715
		public DSP_SETPARAM_INT_CALLBACK setparameterint;

		// Token: 0x040002CC RID: 716
		public DSP_SETPARAM_BOOL_CALLBACK setparameterbool;

		// Token: 0x040002CD RID: 717
		public DSP_SETPARAM_DATA_CALLBACK setparameterdata;

		// Token: 0x040002CE RID: 718
		public DSP_GETPARAM_FLOAT_CALLBACK getparameterfloat;

		// Token: 0x040002CF RID: 719
		public DSP_GETPARAM_INT_CALLBACK getparameterint;

		// Token: 0x040002D0 RID: 720
		public DSP_GETPARAM_BOOL_CALLBACK getparameterbool;

		// Token: 0x040002D1 RID: 721
		public DSP_GETPARAM_DATA_CALLBACK getparameterdata;

		// Token: 0x040002D2 RID: 722
		public DSP_SHOULDIPROCESS_CALLBACK shouldiprocess;

		// Token: 0x040002D3 RID: 723
		public IntPtr userdata;

		// Token: 0x040002D4 RID: 724
		public DSP_SYSTEM_REGISTER_CALLBACK sys_register;

		// Token: 0x040002D5 RID: 725
		public DSP_SYSTEM_DEREGISTER_CALLBACK sys_deregister;

		// Token: 0x040002D6 RID: 726
		public DSP_SYSTEM_MIX_CALLBACK sys_mix;
	}
}
