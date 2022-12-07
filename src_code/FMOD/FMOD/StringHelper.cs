using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace FMOD
{
	// Token: 0x0200004E RID: 78
	internal static class StringHelper
	{
		// Token: 0x060003CD RID: 973 RVA: 0x00004898 File Offset: 0x00002A98
		public static StringHelper.ThreadSafeEncoding GetFreeHelper()
		{
			List<StringHelper.ThreadSafeEncoding> obj = StringHelper.encoders;
			StringHelper.ThreadSafeEncoding result;
			lock (obj)
			{
				StringHelper.ThreadSafeEncoding threadSafeEncoding = null;
				for (int i = 0; i < StringHelper.encoders.Count; i++)
				{
					if (!StringHelper.encoders[i].InUse())
					{
						threadSafeEncoding = StringHelper.encoders[i];
						break;
					}
				}
				if (threadSafeEncoding == null)
				{
					threadSafeEncoding = new StringHelper.ThreadSafeEncoding();
					StringHelper.encoders.Add(threadSafeEncoding);
				}
				threadSafeEncoding.SetInUse();
				result = threadSafeEncoding;
			}
			return result;
		}

		// Token: 0x04000248 RID: 584
		private static List<StringHelper.ThreadSafeEncoding> encoders = new List<StringHelper.ThreadSafeEncoding>(1);

		// Token: 0x0200011E RID: 286
		public class ThreadSafeEncoding : IDisposable
		{
			// Token: 0x06000753 RID: 1875 RVA: 0x0000AFA6 File Offset: 0x000091A6
			public bool InUse()
			{
				return this.inUse;
			}

			// Token: 0x06000754 RID: 1876 RVA: 0x0000AFAE File Offset: 0x000091AE
			public void SetInUse()
			{
				this.inUse = true;
			}

			// Token: 0x06000755 RID: 1877 RVA: 0x0000AFB8 File Offset: 0x000091B8
			private int roundUpPowerTwo(int number)
			{
				int i;
				for (i = 1; i <= number; i *= 2)
				{
				}
				return i;
			}

			// Token: 0x06000756 RID: 1878 RVA: 0x0000AFD4 File Offset: 0x000091D4
			public byte[] byteFromStringUTF8(string s)
			{
				if (s == null)
				{
					return null;
				}
				if (this.encoding.GetMaxByteCount(s.Length) + 1 > this.encodedBuffer.Length)
				{
					int num = this.encoding.GetByteCount(s) + 1;
					if (num > this.encodedBuffer.Length)
					{
						this.encodedBuffer = new byte[this.roundUpPowerTwo(num)];
					}
				}
				int bytes = this.encoding.GetBytes(s, 0, s.Length, this.encodedBuffer, 0);
				this.encodedBuffer[bytes] = 0;
				return this.encodedBuffer;
			}

			// Token: 0x06000757 RID: 1879 RVA: 0x0000B059 File Offset: 0x00009259
			public IntPtr intptrFromStringUTF8(string s)
			{
				if (s == null)
				{
					return IntPtr.Zero;
				}
				this.gcHandle = GCHandle.Alloc(this.byteFromStringUTF8(s), GCHandleType.Pinned);
				return this.gcHandle.AddrOfPinnedObject();
			}

			// Token: 0x06000758 RID: 1880 RVA: 0x0000B084 File Offset: 0x00009284
			public string stringFromNative(IntPtr nativePtr)
			{
				if (nativePtr == IntPtr.Zero)
				{
					return "";
				}
				int num = 0;
				while (Marshal.ReadByte(nativePtr, num) != 0)
				{
					num++;
				}
				if (num == 0)
				{
					return "";
				}
				if (num > this.encodedBuffer.Length)
				{
					this.encodedBuffer = new byte[this.roundUpPowerTwo(num)];
				}
				Marshal.Copy(nativePtr, this.encodedBuffer, 0, num);
				if (this.encoding.GetMaxCharCount(num) > this.decodedBuffer.Length)
				{
					int charCount = this.encoding.GetCharCount(this.encodedBuffer, 0, num);
					if (charCount > this.decodedBuffer.Length)
					{
						this.decodedBuffer = new char[this.roundUpPowerTwo(charCount)];
					}
				}
				int chars = this.encoding.GetChars(this.encodedBuffer, 0, num, this.decodedBuffer, 0);
				return new string(this.decodedBuffer, 0, chars);
			}

			// Token: 0x06000759 RID: 1881 RVA: 0x0000B158 File Offset: 0x00009358
			public void Dispose()
			{
				if (this.gcHandle.IsAllocated)
				{
					this.gcHandle.Free();
				}
				List<StringHelper.ThreadSafeEncoding> encoders = StringHelper.encoders;
				lock (encoders)
				{
					this.inUse = false;
				}
			}

			// Token: 0x0400060A RID: 1546
			private UTF8Encoding encoding = new UTF8Encoding();

			// Token: 0x0400060B RID: 1547
			private byte[] encodedBuffer = new byte[128];

			// Token: 0x0400060C RID: 1548
			private char[] decodedBuffer = new char[128];

			// Token: 0x0400060D RID: 1549
			private bool inUse;

			// Token: 0x0400060E RID: 1550
			private GCHandle gcHandle;
		}
	}
}
