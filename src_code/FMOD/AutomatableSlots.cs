using System;

namespace FMODUnity
{
	// Token: 0x020000F3 RID: 243
	[Serializable]
	public struct AutomatableSlots
	{
		// Token: 0x06000633 RID: 1587 RVA: 0x000067A8 File Offset: 0x000049A8
		public float GetValue(int index)
		{
			switch (index)
			{
			case 0:
				return this.slot00;
			case 1:
				return this.slot01;
			case 2:
				return this.slot02;
			case 3:
				return this.slot03;
			case 4:
				return this.slot04;
			case 5:
				return this.slot05;
			case 6:
				return this.slot06;
			case 7:
				return this.slot07;
			case 8:
				return this.slot08;
			case 9:
				return this.slot09;
			case 10:
				return this.slot10;
			case 11:
				return this.slot11;
			case 12:
				return this.slot12;
			case 13:
				return this.slot13;
			case 14:
				return this.slot14;
			case 15:
				return this.slot15;
			default:
				throw new ArgumentException(string.Format("Invalid slot index: {0}", index));
			}
		}

		// Token: 0x040004FD RID: 1277
		public float slot00;

		// Token: 0x040004FE RID: 1278
		public float slot01;

		// Token: 0x040004FF RID: 1279
		public float slot02;

		// Token: 0x04000500 RID: 1280
		public float slot03;

		// Token: 0x04000501 RID: 1281
		public float slot04;

		// Token: 0x04000502 RID: 1282
		public float slot05;

		// Token: 0x04000503 RID: 1283
		public float slot06;

		// Token: 0x04000504 RID: 1284
		public float slot07;

		// Token: 0x04000505 RID: 1285
		public float slot08;

		// Token: 0x04000506 RID: 1286
		public float slot09;

		// Token: 0x04000507 RID: 1287
		public float slot10;

		// Token: 0x04000508 RID: 1288
		public float slot11;

		// Token: 0x04000509 RID: 1289
		public float slot12;

		// Token: 0x0400050A RID: 1290
		public float slot13;

		// Token: 0x0400050B RID: 1291
		public float slot14;

		// Token: 0x0400050C RID: 1292
		public float slot15;

		// Token: 0x0400050D RID: 1293
		public const int Count = 16;
	}
}
