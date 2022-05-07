using System;
using System.Runtime.CompilerServices;

namespace HwidGetCurrentEx
{
	// Token: 0x02000003 RID: 3
	public static class MinWinDef
	{
		// Token: 0x0600001A RID: 26 RVA: 0x00002480 File Offset: 0x00000680
		// Note: this type is marked as 'beforefieldinit'.
		static MinWinDef()
		{
		}

		// Token: 0x04000001 RID: 1
		internal static Func<object, object, object> MAKEWORD = (object a, object b) => (ushort)((int)((byte)((ulong)a & 0xFFUL)) | (int)((byte)((ulong)b & 0xFFUL)) << 8);

		// Token: 0x04000002 RID: 2
		internal static Func<object, object, object> MAKELONG = (object a, object b) => (ulong)((long)((int)((ushort)((ulong)a & 0xFFUL)) | (int)((byte)((ulong)b & 0xFFUL)) << 8));

		// Token: 0x04000003 RID: 3
		internal static Func<object, object> LOWORD = (object l) => (ushort)((ulong)l & 0xFFFFUL);

		// Token: 0x04000004 RID: 4
		internal static Func<object, object> HIWORD = (object l) => (ushort)((ulong)l >> 0x10 & 0xFFFFUL);

		// Token: 0x04000005 RID: 5
		internal static Func<object, object> LOBYTE = (object w) => (byte)((ulong)w & 0xFFUL);

		// Token: 0x04000006 RID: 6
		internal static Func<object, object> HIBYTE = (object w) => (byte)((ulong)w >> 8 & 0xFFUL);

		// Token: 0x04000007 RID: 7
		internal static Func<object, object> GET_WHEEL_DELTA_WPARAM = (object wParam) => (short)MinWinDef.HIWORD(wParam);

		// Token: 0x04000008 RID: 8
		internal static Func<object, object> GET_KEYSTATE_WPARAM = (object wParam) => MinWinDef.LOWORD(wParam);

		// Token: 0x04000009 RID: 9
		internal static Func<object, object> GET_NCHITTEST_WPARAM = (object wParam) => (short)MinWinDef.LOWORD(wParam);

		// Token: 0x0400000A RID: 10
		internal static Func<object, object> GET_XBUTTON_WPARAM = (object wParam) => MinWinDef.HIWORD(wParam);

		// Token: 0x0200000C RID: 12
		[CompilerGenerated]
		[Serializable]
		private sealed class c
		{
			// Token: 0x06000061 RID: 97 RVA: 0x00005297 File Offset: 0x00003497
			// Note: this type is marked as 'beforefieldinit'.
			static c()
			{
			}

			// Token: 0x06000062 RID: 98 RVA: 0x000052A3 File Offset: 0x000034A3
			public c()
			{
			}

			// Token: 0x06000063 RID: 99 RVA: 0x000052AC File Offset: 0x000034AC
			internal object b__10_0(object a, object b)
			{
				return (ushort)((int)((byte)((ulong)a & 0xFFUL)) | (int)((byte)((ulong)b & 0xFFUL)) << 8);
			}

			// Token: 0x06000064 RID: 100 RVA: 0x000052D3 File Offset: 0x000034D3
			internal object b__10_1(object a, object b)
			{
				return (ulong)((long)((int)((ushort)((ulong)a & 0xFFUL)) | (int)((byte)((ulong)b & 0xFFUL)) << 8));
			}

			// Token: 0x06000065 RID: 101 RVA: 0x000052FA File Offset: 0x000034FA
			internal object b__10_2(object l)
			{
				return (ushort)((ulong)l & 0xFFFFUL);
			}

			// Token: 0x06000066 RID: 102 RVA: 0x0000530F File Offset: 0x0000350F
			internal object b__10_3(object l)
			{
				return (ushort)((ulong)l >> 0x10 & 0xFFFFUL);
			}

			// Token: 0x06000067 RID: 103 RVA: 0x00005327 File Offset: 0x00003527
			internal object b__10_4(object w)
			{
				return (byte)((ulong)w & 0xFFUL);
			}

			// Token: 0x06000068 RID: 104 RVA: 0x0000533C File Offset: 0x0000353C
			internal object b__10_5(object w)
			{
				return (byte)((ulong)w >> 8 & 0xFFUL);
			}

			// Token: 0x06000069 RID: 105 RVA: 0x00005353 File Offset: 0x00003553
			internal object b__10_6(object wParam)
			{
				return (short)MinWinDef.HIWORD(wParam);
			}

			// Token: 0x0600006A RID: 106 RVA: 0x0000536A File Offset: 0x0000356A
			internal object b__10_7(object wParam)
			{
				return MinWinDef.LOWORD(wParam);
			}

			// Token: 0x0600006B RID: 107 RVA: 0x00005377 File Offset: 0x00003577
			internal object b__10_8(object wParam)
			{
				return (short)MinWinDef.LOWORD(wParam);
			}

			// Token: 0x0600006C RID: 108 RVA: 0x0000538E File Offset: 0x0000358E
			internal object b__10_9(object wParam)
			{
				return MinWinDef.HIWORD(wParam);
			}

			// Token: 0x0400004A RID: 74
			public static readonly MinWinDef.c n9 = new MinWinDef.c();
		}
	}
}
