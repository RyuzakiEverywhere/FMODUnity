using System;
using FMOD.Studio;
using UnityEngine;

namespace FMODUnity
{
	// Token: 0x02000117 RID: 279
	[AddComponentMenu("FMOD Studio/FMOD Studio Parameter Trigger")]
	public class StudioParameterTrigger : EventHandler
	{
		// Token: 0x0600073B RID: 1851 RVA: 0x0000A894 File Offset: 0x00008A94
		private void Awake()
		{
			for (int i = 0; i < this.Emitters.Length; i++)
			{
				EmitterRef emitterRef = this.Emitters[i];
				if (emitterRef.Target != null && !string.IsNullOrEmpty(emitterRef.Target.Event))
				{
					EventDescription eventDescription = RuntimeManager.GetEventDescription(emitterRef.Target.Event);
					if (eventDescription.isValid())
					{
						for (int j = 0; j < this.Emitters[i].Params.Length; j++)
						{
							PARAMETER_DESCRIPTION parameter_DESCRIPTION;
							eventDescription.getParameterDescriptionByName(emitterRef.Params[j].Name, out parameter_DESCRIPTION);
							emitterRef.Params[j].ID = parameter_DESCRIPTION.id;
						}
					}
				}
			}
		}

		// Token: 0x0600073C RID: 1852 RVA: 0x0000A942 File Offset: 0x00008B42
		protected override void HandleGameEvent(EmitterGameEvent gameEvent)
		{
			if (this.TriggerEvent == gameEvent)
			{
				this.TriggerParameters();
			}
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x0000A954 File Offset: 0x00008B54
		public void TriggerParameters()
		{
			for (int i = 0; i < this.Emitters.Length; i++)
			{
				EmitterRef emitterRef = this.Emitters[i];
				if (emitterRef.Target != null && emitterRef.Target.EventInstance.isValid())
				{
					for (int j = 0; j < this.Emitters[i].Params.Length; j++)
					{
						emitterRef.Target.EventInstance.setParameterByID(this.Emitters[i].Params[j].ID, this.Emitters[i].Params[j].Value, false);
					}
				}
			}
		}

		// Token: 0x040005EC RID: 1516
		public EmitterRef[] Emitters;

		// Token: 0x040005ED RID: 1517
		public EmitterGameEvent TriggerEvent;
	}
}
