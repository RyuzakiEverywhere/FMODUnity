using System;
using FMOD;
using FMOD.Studio;
using UnityEngine;

namespace FMODUnity
{
	// Token: 0x02000114 RID: 276
	[AddComponentMenu("FMOD Studio/FMOD Studio Global Parameter Trigger")]
	public class StudioGlobalParameterTrigger : EventHandler
	{
		// Token: 0x17000041 RID: 65
		// (get) Token: 0x0600072F RID: 1839 RVA: 0x0000A6E6 File Offset: 0x000088E6
		public PARAMETER_DESCRIPTION ParameterDesctription
		{
			get
			{
				return this.parameterDescription;
			}
		}

		// Token: 0x06000730 RID: 1840 RVA: 0x0000A6F0 File Offset: 0x000088F0
		private RESULT Lookup()
		{
			return RuntimeManager.StudioSystem.getParameterDescriptionByName(this.parameter, out this.parameterDescription);
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x0000A716 File Offset: 0x00008916
		private void Awake()
		{
			if (string.IsNullOrEmpty(this.parameterDescription.name))
			{
				this.Lookup();
			}
		}

		// Token: 0x06000732 RID: 1842 RVA: 0x0000A736 File Offset: 0x00008936
		protected override void HandleGameEvent(EmitterGameEvent gameEvent)
		{
			if (this.TriggerEvent == gameEvent)
			{
				this.TriggerParameters();
			}
		}

		// Token: 0x06000733 RID: 1843 RVA: 0x0000A748 File Offset: 0x00008948
		public void TriggerParameters()
		{
			if (!string.IsNullOrEmpty(this.parameter))
			{
				RESULT result = RuntimeManager.StudioSystem.setParameterByID(this.parameterDescription.id, this.value, false);
				if (result != RESULT.OK)
				{
					UnityEngine.Debug.LogError(string.Format("[FMOD] StudioGlobalParameterTrigger failed to set parameter {0} : result = {1}", this.parameter, result));
				}
			}
		}

		// Token: 0x040005E1 RID: 1505
		[ParamRef]
		public string parameter;

		// Token: 0x040005E2 RID: 1506
		public EmitterGameEvent TriggerEvent;

		// Token: 0x040005E3 RID: 1507
		public float value;

		// Token: 0x040005E4 RID: 1508
		private PARAMETER_DESCRIPTION parameterDescription;
	}
}
