using System;

namespace FMOD
{
	// Token: 0x02000036 RID: 54
	public struct CREATESOUNDEXINFO
	{
		// Token: 0x0400019E RID: 414
		public int cbsize;

		// Token: 0x0400019F RID: 415
		public uint length;

		// Token: 0x040001A0 RID: 416
		public uint fileoffset;

		// Token: 0x040001A1 RID: 417
		public int numchannels;

		// Token: 0x040001A2 RID: 418
		public int defaultfrequency;

		// Token: 0x040001A3 RID: 419
		public SOUND_FORMAT format;

		// Token: 0x040001A4 RID: 420
		public uint decodebuffersize;

		// Token: 0x040001A5 RID: 421
		public int initialsubsound;

		// Token: 0x040001A6 RID: 422
		public int numsubsounds;

		// Token: 0x040001A7 RID: 423
		public IntPtr inclusionlist;

		// Token: 0x040001A8 RID: 424
		public int inclusionlistnum;

		// Token: 0x040001A9 RID: 425
		public SOUND_PCMREAD_CALLBACK pcmreadcallback;

		// Token: 0x040001AA RID: 426
		public SOUND_PCMSETPOS_CALLBACK pcmsetposcallback;

		// Token: 0x040001AB RID: 427
		public SOUND_NONBLOCK_CALLBACK nonblockcallback;

		// Token: 0x040001AC RID: 428
		public IntPtr dlsname;

		// Token: 0x040001AD RID: 429
		public IntPtr encryptionkey;

		// Token: 0x040001AE RID: 430
		public int maxpolyphony;

		// Token: 0x040001AF RID: 431
		public IntPtr userdata;

		// Token: 0x040001B0 RID: 432
		public SOUND_TYPE suggestedsoundtype;

		// Token: 0x040001B1 RID: 433
		public FILE_OPEN_CALLBACK fileuseropen;

		// Token: 0x040001B2 RID: 434
		public FILE_CLOSE_CALLBACK fileuserclose;

		// Token: 0x040001B3 RID: 435
		public FILE_READ_CALLBACK fileuserread;

		// Token: 0x040001B4 RID: 436
		public FILE_SEEK_CALLBACK fileuserseek;

		// Token: 0x040001B5 RID: 437
		public FILE_ASYNCREAD_CALLBACK fileuserasyncread;

		// Token: 0x040001B6 RID: 438
		public FILE_ASYNCCANCEL_CALLBACK fileuserasynccancel;

		// Token: 0x040001B7 RID: 439
		public IntPtr fileuserdata;

		// Token: 0x040001B8 RID: 440
		public int filebuffersize;

		// Token: 0x040001B9 RID: 441
		public CHANNELORDER channelorder;

		// Token: 0x040001BA RID: 442
		public IntPtr initialsoundgroup;

		// Token: 0x040001BB RID: 443
		public uint initialseekposition;

		// Token: 0x040001BC RID: 444
		public TIMEUNIT initialseekpostype;

		// Token: 0x040001BD RID: 445
		public int ignoresetfilesystem;

		// Token: 0x040001BE RID: 446
		public uint audioqueuepolicy;

		// Token: 0x040001BF RID: 447
		public uint minmidigranularity;

		// Token: 0x040001C0 RID: 448
		public int nonblockthreadid;

		// Token: 0x040001C1 RID: 449
		public IntPtr fsbguid;
	}
}
