using System;
using System.Runtime.InteropServices;

namespace FMOD
{
	// Token: 0x02000040 RID: 64
	public struct Memory
	{
		// Token: 0x06000063 RID: 99 RVA: 0x0000284F File Offset: 0x00000A4F
		public static RESULT Initialize(IntPtr poolmem, int poollen, MEMORY_ALLOC_CALLBACK useralloc, MEMORY_REALLOC_CALLBACK userrealloc, MEMORY_FREE_CALLBACK userfree, MEMORY_TYPE memtypeflags = MEMORY_TYPE.ALL)
		{
			return Memory.FMOD5_Memory_Initialize(poolmem, poollen, useralloc, userrealloc, userfree, memtypeflags);
		}

		// Token: 0x06000064 RID: 100 RVA: 0x0000285E File Offset: 0x00000A5E
		public static RESULT GetStats(out int currentalloced, out int maxalloced, bool blocking = true)
		{
			return Memory.FMOD5_Memory_GetStats(out currentalloced, out maxalloced, blocking);
		}

		// Token: 0x06000065 RID: 101
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Memory_Initialize(IntPtr poolmem, int poollen, MEMORY_ALLOC_CALLBACK useralloc, MEMORY_REALLOC_CALLBACK userrealloc, MEMORY_FREE_CALLBACK userfree, MEMORY_TYPE memtypeflags);

		// Token: 0x06000066 RID: 102
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Memory_GetStats(out int currentalloced, out int maxalloced, bool blocking);
	}
}
