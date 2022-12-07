using System;
using FMOD;
using FMOD.Studio;
using UnityEngine;

namespace FMODUnity
{
	// Token: 0x0200010B RID: 267
	public static class RuntimeUtils
	{
		// Token: 0x060006DD RID: 1757 RVA: 0x00008D08 File Offset: 0x00006F08
		public static string GetCommonPlatformPath(string path)
		{
			if (string.IsNullOrEmpty(path))
			{
				return path;
			}
			return path.Replace('\\', '/');
		}

		// Token: 0x060006DE RID: 1758 RVA: 0x00008D20 File Offset: 0x00006F20
		public static VECTOR ToFMODVector(this Vector3 vec)
		{
			VECTOR result;
			result.x = vec.x;
			result.y = vec.y;
			result.z = vec.z;
			return result;
		}

		// Token: 0x060006DF RID: 1759 RVA: 0x00008D58 File Offset: 0x00006F58
		public static ATTRIBUTES_3D To3DAttributes(this Vector3 pos)
		{
			return new ATTRIBUTES_3D
			{
				forward = Vector3.forward.ToFMODVector(),
				up = Vector3.up.ToFMODVector(),
				position = pos.ToFMODVector()
			};
		}

		// Token: 0x060006E0 RID: 1760 RVA: 0x00008DA0 File Offset: 0x00006FA0
		public static ATTRIBUTES_3D To3DAttributes(this Transform transform)
		{
			return new ATTRIBUTES_3D
			{
				forward = transform.forward.ToFMODVector(),
				up = transform.up.ToFMODVector(),
				position = transform.position.ToFMODVector()
			};
		}

		// Token: 0x060006E1 RID: 1761 RVA: 0x00008DEC File Offset: 0x00006FEC
		public static ATTRIBUTES_3D To3DAttributes(this GameObject go)
		{
			return go.transform.To3DAttributes();
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x00008DFC File Offset: 0x00006FFC
		public static ATTRIBUTES_3D To3DAttributes(Transform transform, Rigidbody rigidbody = null)
		{
			ATTRIBUTES_3D result = transform.To3DAttributes();
			if (rigidbody)
			{
				result.velocity = rigidbody.velocity.ToFMODVector();
			}
			return result;
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x00008E2C File Offset: 0x0000702C
		public static ATTRIBUTES_3D To3DAttributes(GameObject go, Rigidbody rigidbody)
		{
			ATTRIBUTES_3D result = go.transform.To3DAttributes();
			if (rigidbody)
			{
				result.velocity = rigidbody.velocity.ToFMODVector();
			}
			return result;
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x00008E60 File Offset: 0x00007060
		public static ATTRIBUTES_3D To3DAttributes(Transform transform, Rigidbody2D rigidbody)
		{
			ATTRIBUTES_3D result = transform.To3DAttributes();
			if (rigidbody)
			{
				VECTOR velocity;
				velocity.x = rigidbody.velocity.x;
				velocity.y = rigidbody.velocity.y;
				velocity.z = 0f;
				result.velocity = velocity;
			}
			return result;
		}

		// Token: 0x060006E5 RID: 1765 RVA: 0x00008EB8 File Offset: 0x000070B8
		public static ATTRIBUTES_3D To3DAttributes(GameObject go, Rigidbody2D rigidbody)
		{
			ATTRIBUTES_3D result = go.transform.To3DAttributes();
			if (rigidbody)
			{
				VECTOR velocity;
				velocity.x = rigidbody.velocity.x;
				velocity.y = rigidbody.velocity.y;
				velocity.z = 0f;
				result.velocity = velocity;
			}
			return result;
		}

		// Token: 0x060006E6 RID: 1766 RVA: 0x00008F14 File Offset: 0x00007114
		public static THREAD_TYPE ToFMODThreadType(ThreadType threadType)
		{
			switch (threadType)
			{
			case ThreadType.Mixer:
				return THREAD_TYPE.MIXER;
			case ThreadType.Feeder:
				return THREAD_TYPE.FEEDER;
			case ThreadType.Stream:
				return THREAD_TYPE.STREAM;
			case ThreadType.File:
				return THREAD_TYPE.FILE;
			case ThreadType.Nonblocking:
				return THREAD_TYPE.NONBLOCKING;
			case ThreadType.Record:
				return THREAD_TYPE.RECORD;
			case ThreadType.Geometry:
				return THREAD_TYPE.GEOMETRY;
			case ThreadType.Profiler:
				return THREAD_TYPE.PROFILER;
			case ThreadType.Studio_Update:
				return THREAD_TYPE.STUDIO_UPDATE;
			case ThreadType.Studio_Load_Bank:
				return THREAD_TYPE.STUDIO_LOAD_BANK;
			case ThreadType.Studio_Load_Sample:
				return THREAD_TYPE.STUDIO_LOAD_SAMPLE;
			case ThreadType.Convolution_1:
				return THREAD_TYPE.CONVOLUTION1;
			case ThreadType.Convolution_2:
				return THREAD_TYPE.CONVOLUTION2;
			default:
				throw new ArgumentException("Unrecognised thread type '" + threadType.ToString() + "'");
			}
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x00008F9C File Offset: 0x0000719C
		public static string DisplayName(this ThreadType thread)
		{
			return thread.ToString().Replace('_', ' ');
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x00008FB4 File Offset: 0x000071B4
		public static THREAD_AFFINITY ToFMODThreadAffinity(ThreadAffinity affinity)
		{
			THREAD_AFFINITY result = THREAD_AFFINITY.CORE_ALL;
			RuntimeUtils.SetFMODAffinityBit(affinity, ThreadAffinity.Core0, THREAD_AFFINITY.CORE_0, ref result);
			RuntimeUtils.SetFMODAffinityBit(affinity, ThreadAffinity.Core1, THREAD_AFFINITY.CORE_1, ref result);
			RuntimeUtils.SetFMODAffinityBit(affinity, ThreadAffinity.Core2, THREAD_AFFINITY.CORE_2, ref result);
			RuntimeUtils.SetFMODAffinityBit(affinity, ThreadAffinity.Core3, THREAD_AFFINITY.CORE_3, ref result);
			RuntimeUtils.SetFMODAffinityBit(affinity, ThreadAffinity.Core4, THREAD_AFFINITY.CORE_4, ref result);
			RuntimeUtils.SetFMODAffinityBit(affinity, ThreadAffinity.Core5, THREAD_AFFINITY.CORE_5, ref result);
			RuntimeUtils.SetFMODAffinityBit(affinity, ThreadAffinity.Core6, THREAD_AFFINITY.CORE_6, ref result);
			RuntimeUtils.SetFMODAffinityBit(affinity, ThreadAffinity.Core7, THREAD_AFFINITY.CORE_7, ref result);
			RuntimeUtils.SetFMODAffinityBit(affinity, ThreadAffinity.Core8, THREAD_AFFINITY.CORE_8, ref result);
			RuntimeUtils.SetFMODAffinityBit(affinity, ThreadAffinity.Core9, THREAD_AFFINITY.CORE_9, ref result);
			RuntimeUtils.SetFMODAffinityBit(affinity, ThreadAffinity.Core10, THREAD_AFFINITY.CORE_10, ref result);
			RuntimeUtils.SetFMODAffinityBit(affinity, ThreadAffinity.Core11, THREAD_AFFINITY.CORE_11, ref result);
			RuntimeUtils.SetFMODAffinityBit(affinity, ThreadAffinity.Core12, THREAD_AFFINITY.CORE_12, ref result);
			RuntimeUtils.SetFMODAffinityBit(affinity, ThreadAffinity.Core13, THREAD_AFFINITY.CORE_13, ref result);
			RuntimeUtils.SetFMODAffinityBit(affinity, ThreadAffinity.Core14, THREAD_AFFINITY.CORE_14, ref result);
			RuntimeUtils.SetFMODAffinityBit(affinity, ThreadAffinity.Core15, THREAD_AFFINITY.CORE_15, ref result);
			return result;
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x000090C3 File Offset: 0x000072C3
		private static void SetFMODAffinityBit(ThreadAffinity affinity, ThreadAffinity mask, THREAD_AFFINITY fmodMask, ref THREAD_AFFINITY fmodAffinity)
		{
			if ((affinity & mask) != ThreadAffinity.Any)
			{
				fmodAffinity |= fmodMask;
			}
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x000090D0 File Offset: 0x000072D0
		public static void EnforceLibraryOrder()
		{
			int num;
			int num2;
			Memory.GetStats(out num, out num2, true);
			Guid guid;
			Util.parseID("", out guid);
		}
	}
}
