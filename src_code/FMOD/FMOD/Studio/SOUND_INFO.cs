using System;

namespace FMOD.Studio
{
	// Token: 0x020000D0 RID: 208
	public struct SOUND_INFO
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600046B RID: 1131 RVA: 0x00004D54 File Offset: 0x00002F54
		public string name
		{
			get
			{
				string result;
				using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
				{
					result = (((this.mode & (MODE.OPENMEMORY | MODE.OPENMEMORY_POINT)) == MODE.DEFAULT) ? freeHelper.stringFromNative(this.name_or_data) : string.Empty);
				}
				return result;
			}
		}

		// Token: 0x04000494 RID: 1172
		public IntPtr name_or_data;

		// Token: 0x04000495 RID: 1173
		public MODE mode;

		// Token: 0x04000496 RID: 1174
		public CREATESOUNDEXINFO exinfo;

		// Token: 0x04000497 RID: 1175
		public int subsoundindex;
	}
}
