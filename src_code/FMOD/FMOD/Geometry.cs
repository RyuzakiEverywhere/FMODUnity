using System;
using System.Runtime.InteropServices;

namespace FMOD
{
	// Token: 0x0200004B RID: 75
	public struct Geometry
	{
		// Token: 0x0600038B RID: 907 RVA: 0x0000464D File Offset: 0x0000284D
		public RESULT release()
		{
			return Geometry.FMOD5_Geometry_Release(this.handle);
		}

		// Token: 0x0600038C RID: 908 RVA: 0x0000465A File Offset: 0x0000285A
		public RESULT addPolygon(float directocclusion, float reverbocclusion, bool doublesided, int numvertices, VECTOR[] vertices, out int polygonindex)
		{
			return Geometry.FMOD5_Geometry_AddPolygon(this.handle, directocclusion, reverbocclusion, doublesided, numvertices, vertices, out polygonindex);
		}

		// Token: 0x0600038D RID: 909 RVA: 0x00004670 File Offset: 0x00002870
		public RESULT getNumPolygons(out int numpolygons)
		{
			return Geometry.FMOD5_Geometry_GetNumPolygons(this.handle, out numpolygons);
		}

		// Token: 0x0600038E RID: 910 RVA: 0x0000467E File Offset: 0x0000287E
		public RESULT getMaxPolygons(out int maxpolygons, out int maxvertices)
		{
			return Geometry.FMOD5_Geometry_GetMaxPolygons(this.handle, out maxpolygons, out maxvertices);
		}

		// Token: 0x0600038F RID: 911 RVA: 0x0000468D File Offset: 0x0000288D
		public RESULT getPolygonNumVertices(int index, out int numvertices)
		{
			return Geometry.FMOD5_Geometry_GetPolygonNumVertices(this.handle, index, out numvertices);
		}

		// Token: 0x06000390 RID: 912 RVA: 0x0000469C File Offset: 0x0000289C
		public RESULT setPolygonVertex(int index, int vertexindex, ref VECTOR vertex)
		{
			return Geometry.FMOD5_Geometry_SetPolygonVertex(this.handle, index, vertexindex, ref vertex);
		}

		// Token: 0x06000391 RID: 913 RVA: 0x000046AC File Offset: 0x000028AC
		public RESULT getPolygonVertex(int index, int vertexindex, out VECTOR vertex)
		{
			return Geometry.FMOD5_Geometry_GetPolygonVertex(this.handle, index, vertexindex, out vertex);
		}

		// Token: 0x06000392 RID: 914 RVA: 0x000046BC File Offset: 0x000028BC
		public RESULT setPolygonAttributes(int index, float directocclusion, float reverbocclusion, bool doublesided)
		{
			return Geometry.FMOD5_Geometry_SetPolygonAttributes(this.handle, index, directocclusion, reverbocclusion, doublesided);
		}

		// Token: 0x06000393 RID: 915 RVA: 0x000046CE File Offset: 0x000028CE
		public RESULT getPolygonAttributes(int index, out float directocclusion, out float reverbocclusion, out bool doublesided)
		{
			return Geometry.FMOD5_Geometry_GetPolygonAttributes(this.handle, index, out directocclusion, out reverbocclusion, out doublesided);
		}

		// Token: 0x06000394 RID: 916 RVA: 0x000046E0 File Offset: 0x000028E0
		public RESULT setActive(bool active)
		{
			return Geometry.FMOD5_Geometry_SetActive(this.handle, active);
		}

		// Token: 0x06000395 RID: 917 RVA: 0x000046EE File Offset: 0x000028EE
		public RESULT getActive(out bool active)
		{
			return Geometry.FMOD5_Geometry_GetActive(this.handle, out active);
		}

		// Token: 0x06000396 RID: 918 RVA: 0x000046FC File Offset: 0x000028FC
		public RESULT setRotation(ref VECTOR forward, ref VECTOR up)
		{
			return Geometry.FMOD5_Geometry_SetRotation(this.handle, ref forward, ref up);
		}

		// Token: 0x06000397 RID: 919 RVA: 0x0000470B File Offset: 0x0000290B
		public RESULT getRotation(out VECTOR forward, out VECTOR up)
		{
			return Geometry.FMOD5_Geometry_GetRotation(this.handle, out forward, out up);
		}

		// Token: 0x06000398 RID: 920 RVA: 0x0000471A File Offset: 0x0000291A
		public RESULT setPosition(ref VECTOR position)
		{
			return Geometry.FMOD5_Geometry_SetPosition(this.handle, ref position);
		}

		// Token: 0x06000399 RID: 921 RVA: 0x00004728 File Offset: 0x00002928
		public RESULT getPosition(out VECTOR position)
		{
			return Geometry.FMOD5_Geometry_GetPosition(this.handle, out position);
		}

		// Token: 0x0600039A RID: 922 RVA: 0x00004736 File Offset: 0x00002936
		public RESULT setScale(ref VECTOR scale)
		{
			return Geometry.FMOD5_Geometry_SetScale(this.handle, ref scale);
		}

		// Token: 0x0600039B RID: 923 RVA: 0x00004744 File Offset: 0x00002944
		public RESULT getScale(out VECTOR scale)
		{
			return Geometry.FMOD5_Geometry_GetScale(this.handle, out scale);
		}

		// Token: 0x0600039C RID: 924 RVA: 0x00004752 File Offset: 0x00002952
		public RESULT save(IntPtr data, out int datasize)
		{
			return Geometry.FMOD5_Geometry_Save(this.handle, data, out datasize);
		}

		// Token: 0x0600039D RID: 925 RVA: 0x00004761 File Offset: 0x00002961
		public RESULT setUserData(IntPtr userdata)
		{
			return Geometry.FMOD5_Geometry_SetUserData(this.handle, userdata);
		}

		// Token: 0x0600039E RID: 926 RVA: 0x0000476F File Offset: 0x0000296F
		public RESULT getUserData(out IntPtr userdata)
		{
			return Geometry.FMOD5_Geometry_GetUserData(this.handle, out userdata);
		}

		// Token: 0x0600039F RID: 927
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Geometry_Release(IntPtr geometry);

		// Token: 0x060003A0 RID: 928
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Geometry_AddPolygon(IntPtr geometry, float directocclusion, float reverbocclusion, bool doublesided, int numvertices, VECTOR[] vertices, out int polygonindex);

		// Token: 0x060003A1 RID: 929
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Geometry_GetNumPolygons(IntPtr geometry, out int numpolygons);

		// Token: 0x060003A2 RID: 930
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Geometry_GetMaxPolygons(IntPtr geometry, out int maxpolygons, out int maxvertices);

		// Token: 0x060003A3 RID: 931
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Geometry_GetPolygonNumVertices(IntPtr geometry, int index, out int numvertices);

		// Token: 0x060003A4 RID: 932
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Geometry_SetPolygonVertex(IntPtr geometry, int index, int vertexindex, ref VECTOR vertex);

		// Token: 0x060003A5 RID: 933
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Geometry_GetPolygonVertex(IntPtr geometry, int index, int vertexindex, out VECTOR vertex);

		// Token: 0x060003A6 RID: 934
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Geometry_SetPolygonAttributes(IntPtr geometry, int index, float directocclusion, float reverbocclusion, bool doublesided);

		// Token: 0x060003A7 RID: 935
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Geometry_GetPolygonAttributes(IntPtr geometry, int index, out float directocclusion, out float reverbocclusion, out bool doublesided);

		// Token: 0x060003A8 RID: 936
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Geometry_SetActive(IntPtr geometry, bool active);

		// Token: 0x060003A9 RID: 937
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Geometry_GetActive(IntPtr geometry, out bool active);

		// Token: 0x060003AA RID: 938
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Geometry_SetRotation(IntPtr geometry, ref VECTOR forward, ref VECTOR up);

		// Token: 0x060003AB RID: 939
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Geometry_GetRotation(IntPtr geometry, out VECTOR forward, out VECTOR up);

		// Token: 0x060003AC RID: 940
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Geometry_SetPosition(IntPtr geometry, ref VECTOR position);

		// Token: 0x060003AD RID: 941
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Geometry_GetPosition(IntPtr geometry, out VECTOR position);

		// Token: 0x060003AE RID: 942
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Geometry_SetScale(IntPtr geometry, ref VECTOR scale);

		// Token: 0x060003AF RID: 943
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Geometry_GetScale(IntPtr geometry, out VECTOR scale);

		// Token: 0x060003B0 RID: 944
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Geometry_Save(IntPtr geometry, IntPtr data, out int datasize);

		// Token: 0x060003B1 RID: 945
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Geometry_SetUserData(IntPtr geometry, IntPtr userdata);

		// Token: 0x060003B2 RID: 946
		[DllImport("fmodstudio")]
		private static extern RESULT FMOD5_Geometry_GetUserData(IntPtr geometry, out IntPtr userdata);

		// Token: 0x060003B3 RID: 947 RVA: 0x0000477D File Offset: 0x0000297D
		public Geometry(IntPtr ptr)
		{
			this.handle = ptr;
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x00004786 File Offset: 0x00002986
		public bool hasHandle()
		{
			return this.handle != IntPtr.Zero;
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x00004798 File Offset: 0x00002998
		public void clearHandle()
		{
			this.handle = IntPtr.Zero;
		}

		// Token: 0x04000245 RID: 581
		public IntPtr handle;
	}
}
