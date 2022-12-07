using System;
using FMOD;
using FMOD.Studio;
using UnityEngine;

namespace FMODUnity
{
	// Token: 0x020000F9 RID: 249
	public class PlatformCallbackHandler : ScriptableObject
	{
		// Token: 0x0600064A RID: 1610 RVA: 0x00005DA4 File Offset: 0x00003FA4
		public virtual void PreInitialize(FMOD.Studio.System system, Action<RESULT, string> reportResult)
		{
		}
	}
}
