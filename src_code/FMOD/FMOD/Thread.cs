using System;
using System.Runtime.InteropServices;

namespace FMOD
{
	// Token: 0x02000042 RID: 66
	public struct Thread
	{
		// Token: 0x06000069 RID: 105 RVA: 0x000028A8 File Offset: 0x00000AA8
		public static RESULT SetAttributes(THREAD_TYPE type, THREAD_AFFINITY affinity = THREAD_AFFINITY.GROUP_DEFAULT, THREAD_PRIORITY priority = THREAD_PRIORITY.DEFAULT, THREAD_STACK_SIZE stacksize = THREAD_STACK_SIZE.DEFAULT)
		{
			if ((affinity & THREAD_AFFINITY.GROUP_DEFAULT) != THREAD_AFFINITY.CORE_ALL)
			{
				affinity &= ~THREAD_AFFINITY.GROUP_DEFAULT;
				affinity |= (THREAD_AFFINITY)(-9223372036854775808L);
			}
			return Thread.FMOD5_Thread_SetAttributes(type, affinity, priority, stacksize);
		}

		// Token: 0x0600006A RID: 106
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Thread_SetAttributes(THREAD_TYPE type, THREAD_AFFINITY affinity, THREAD_PRIORITY priority, THREAD_STACK_SIZE stacksize);
	}
}
