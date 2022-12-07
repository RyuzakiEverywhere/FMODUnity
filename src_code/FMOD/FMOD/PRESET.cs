using System;

namespace FMOD
{
	// Token: 0x02000038 RID: 56
	public class PRESET
	{
		// Token: 0x06000048 RID: 72 RVA: 0x000020C4 File Offset: 0x000002C4
		public static REVERB_PROPERTIES OFF()
		{
			return new REVERB_PROPERTIES(1000f, 7f, 11f, 5000f, 100f, 100f, 100f, 250f, 0f, 20f, 96f, -80f);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002114 File Offset: 0x00000314
		public static REVERB_PROPERTIES GENERIC()
		{
			return new REVERB_PROPERTIES(1500f, 7f, 11f, 5000f, 83f, 100f, 100f, 250f, 0f, 14500f, 96f, -8f);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002164 File Offset: 0x00000364
		public static REVERB_PROPERTIES PADDEDCELL()
		{
			return new REVERB_PROPERTIES(170f, 1f, 2f, 5000f, 10f, 100f, 100f, 250f, 0f, 160f, 84f, -7.8f);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000021B4 File Offset: 0x000003B4
		public static REVERB_PROPERTIES ROOM()
		{
			return new REVERB_PROPERTIES(400f, 2f, 3f, 5000f, 83f, 100f, 100f, 250f, 0f, 6050f, 88f, -9.4f);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002204 File Offset: 0x00000404
		public static REVERB_PROPERTIES BATHROOM()
		{
			return new REVERB_PROPERTIES(1500f, 7f, 11f, 5000f, 54f, 100f, 60f, 250f, 0f, 2900f, 83f, 0.5f);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002254 File Offset: 0x00000454
		public static REVERB_PROPERTIES LIVINGROOM()
		{
			return new REVERB_PROPERTIES(500f, 3f, 4f, 5000f, 10f, 100f, 100f, 250f, 0f, 160f, 58f, -19f);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000022A4 File Offset: 0x000004A4
		public static REVERB_PROPERTIES STONEROOM()
		{
			return new REVERB_PROPERTIES(2300f, 12f, 17f, 5000f, 64f, 100f, 100f, 250f, 0f, 7800f, 71f, -8.5f);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000022F4 File Offset: 0x000004F4
		public static REVERB_PROPERTIES AUDITORIUM()
		{
			return new REVERB_PROPERTIES(4300f, 20f, 30f, 5000f, 59f, 100f, 100f, 250f, 0f, 5850f, 64f, -11.7f);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00002344 File Offset: 0x00000544
		public static REVERB_PROPERTIES CONCERTHALL()
		{
			return new REVERB_PROPERTIES(3900f, 20f, 29f, 5000f, 70f, 100f, 100f, 250f, 0f, 5650f, 80f, -9.8f);
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002394 File Offset: 0x00000594
		public static REVERB_PROPERTIES CAVE()
		{
			return new REVERB_PROPERTIES(2900f, 15f, 22f, 5000f, 100f, 100f, 100f, 250f, 0f, 20000f, 59f, -11.3f);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x000023E4 File Offset: 0x000005E4
		public static REVERB_PROPERTIES ARENA()
		{
			return new REVERB_PROPERTIES(7200f, 20f, 30f, 5000f, 33f, 100f, 100f, 250f, 0f, 4500f, 80f, -9.6f);
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002434 File Offset: 0x00000634
		public static REVERB_PROPERTIES HANGAR()
		{
			return new REVERB_PROPERTIES(10000f, 20f, 30f, 5000f, 23f, 100f, 100f, 250f, 0f, 3400f, 72f, -7.4f);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002484 File Offset: 0x00000684
		public static REVERB_PROPERTIES CARPETTEDHALLWAY()
		{
			return new REVERB_PROPERTIES(300f, 2f, 30f, 5000f, 10f, 100f, 100f, 250f, 0f, 500f, 56f, -24f);
		}

		// Token: 0x06000055 RID: 85 RVA: 0x000024D4 File Offset: 0x000006D4
		public static REVERB_PROPERTIES HALLWAY()
		{
			return new REVERB_PROPERTIES(1500f, 7f, 11f, 5000f, 59f, 100f, 100f, 250f, 0f, 7800f, 87f, -5.5f);
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002524 File Offset: 0x00000724
		public static REVERB_PROPERTIES STONECORRIDOR()
		{
			return new REVERB_PROPERTIES(270f, 13f, 20f, 5000f, 79f, 100f, 100f, 250f, 0f, 9000f, 86f, -6f);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00002574 File Offset: 0x00000774
		public static REVERB_PROPERTIES ALLEY()
		{
			return new REVERB_PROPERTIES(1500f, 7f, 11f, 5000f, 86f, 100f, 100f, 250f, 0f, 8300f, 80f, -9.8f);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000025C4 File Offset: 0x000007C4
		public static REVERB_PROPERTIES FOREST()
		{
			return new REVERB_PROPERTIES(1500f, 162f, 88f, 5000f, 54f, 79f, 100f, 250f, 0f, 760f, 94f, -12.3f);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00002614 File Offset: 0x00000814
		public static REVERB_PROPERTIES CITY()
		{
			return new REVERB_PROPERTIES(1500f, 7f, 11f, 5000f, 67f, 50f, 100f, 250f, 0f, 4050f, 66f, -26f);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00002664 File Offset: 0x00000864
		public static REVERB_PROPERTIES MOUNTAINS()
		{
			return new REVERB_PROPERTIES(1500f, 300f, 100f, 5000f, 21f, 27f, 100f, 250f, 0f, 1220f, 82f, -24f);
		}

		// Token: 0x0600005B RID: 91 RVA: 0x000026B4 File Offset: 0x000008B4
		public static REVERB_PROPERTIES QUARRY()
		{
			return new REVERB_PROPERTIES(1500f, 61f, 25f, 5000f, 83f, 100f, 100f, 250f, 0f, 3400f, 100f, -5f);
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00002704 File Offset: 0x00000904
		public static REVERB_PROPERTIES PLAIN()
		{
			return new REVERB_PROPERTIES(1500f, 179f, 100f, 5000f, 50f, 21f, 100f, 250f, 0f, 1670f, 65f, -28f);
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00002754 File Offset: 0x00000954
		public static REVERB_PROPERTIES PARKINGLOT()
		{
			return new REVERB_PROPERTIES(1700f, 8f, 12f, 5000f, 100f, 100f, 100f, 250f, 0f, 20000f, 56f, -19.5f);
		}

		// Token: 0x0600005E RID: 94 RVA: 0x000027A4 File Offset: 0x000009A4
		public static REVERB_PROPERTIES SEWERPIPE()
		{
			return new REVERB_PROPERTIES(2800f, 14f, 21f, 5000f, 14f, 80f, 60f, 250f, 0f, 3400f, 66f, 1.2f);
		}

		// Token: 0x0600005F RID: 95 RVA: 0x000027F4 File Offset: 0x000009F4
		public static REVERB_PROPERTIES UNDERWATER()
		{
			return new REVERB_PROPERTIES(1500f, 7f, 11f, 5000f, 10f, 100f, 100f, 250f, 0f, 500f, 92f, 7f);
		}
	}
}
