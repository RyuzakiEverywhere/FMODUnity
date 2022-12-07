using System;
using UnityEngine;

namespace FMODUnity
{
	// Token: 0x020000EB RID: 235
	public class FMODRuntimeManagerOnGUIHelper : MonoBehaviour
	{
		// Token: 0x0600060A RID: 1546 RVA: 0x000065FD File Offset: 0x000047FD
		private void OnGUI()
		{
			if (this.TargetRuntimeManager)
			{
				this.TargetRuntimeManager.ExecuteOnGUI();
			}
		}

		// Token: 0x040004FC RID: 1276
		public RuntimeManager TargetRuntimeManager;
	}
}
