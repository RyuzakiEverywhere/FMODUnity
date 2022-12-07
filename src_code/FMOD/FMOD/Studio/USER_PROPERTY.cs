using System;

namespace FMOD.Studio
{
	// Token: 0x020000D2 RID: 210
	public struct USER_PROPERTY
	{
		// Token: 0x0600046C RID: 1132 RVA: 0x00004DA8 File Offset: 0x00002FA8
		public int intValue()
		{
			if (this.type != USER_PROPERTY_TYPE.INTEGER)
			{
				return -1;
			}
			return this.value.intvalue;
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x00004DBF File Offset: 0x00002FBF
		public bool boolValue()
		{
			return this.type == USER_PROPERTY_TYPE.BOOLEAN && this.value.boolvalue;
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x00004DD7 File Offset: 0x00002FD7
		public float floatValue()
		{
			if (this.type != USER_PROPERTY_TYPE.FLOAT)
			{
				return -1f;
			}
			return this.value.floatvalue;
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x00004DF3 File Offset: 0x00002FF3
		public string stringValue()
		{
			if (this.type != USER_PROPERTY_TYPE.STRING)
			{
				return "";
			}
			return this.value.stringvalue;
		}

		// Token: 0x0400049D RID: 1181
		public StringWrapper name;

		// Token: 0x0400049E RID: 1182
		public USER_PROPERTY_TYPE type;

		// Token: 0x0400049F RID: 1183
		private Union_IntBoolFloatString value;
	}
}
