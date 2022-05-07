using System;
using System.Runtime.InteropServices;

namespace HwidGetCurrentEx
{
	// Token: 0x02000004 RID: 4
	public static class ComHelper
	{
		// Token: 0x0200000D RID: 13
		public struct MyGuid
		{
			// Token: 0x0600006D RID: 109 RVA: 0x0000539C File Offset: 0x0000359C
			public MyGuid(Guid g)
			{
				byte[] array = g.ToByteArray();
				this.Data1 = BitConverter.ToInt32(array, 0);
				this.Data2 = BitConverter.ToInt16(array, 4);
				this.Data3 = BitConverter.ToInt16(array, 6);
				this.Data4 = new byte[8];
				Buffer.BlockCopy(array, 8, this.Data4, 0, 8);
			}

			// Token: 0x0600006E RID: 110 RVA: 0x000053F8 File Offset: 0x000035F8
			public Guid ToGuid()
			{
				return new Guid(this.Data1, this.Data2, this.Data3, this.Data4);
			}

			// Token: 0x0400004B RID: 75
			public int Data1;

			// Token: 0x0400004C RID: 76
			public short Data2;

			// Token: 0x0400004D RID: 77
			public short Data3;

			// Token: 0x0400004E RID: 78
			public byte[] Data4;
		}

		// Token: 0x0200000E RID: 14
		[ComImport]
		[ComVisible(false)]
		[Guid("eb89a21b-1f9c-4093-9a4d-05d4002543f6")]
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IUnknown
		{
			// Token: 0x0600006F RID: 111
			int QueryInterface(IntPtr pUnk, ref Guid riid, out IntPtr pVoid);

			// Token: 0x06000070 RID: 112
			[PreserveSig]
			int AddRef(IntPtr pUnk);

			// Token: 0x06000071 RID: 113
			[PreserveSig]
			int Release(IntPtr pUnk);
		}

		// Token: 0x0200000F RID: 15
		[ClassInterface(ClassInterfaceType.None)]
		[Guid("eb89a21b-1f9c-4093-9a4d-05d4002543f6")]
		public class MyUnknown : ComHelper.IUnknown
		{
			// Token: 0x06000072 RID: 114 RVA: 0x00005428 File Offset: 0x00003628
			public int QueryInterface(IntPtr pUnk, ref Guid riid, out IntPtr pVoid)
			{
				return Marshal.QueryInterface(pUnk, ref riid, out pVoid);
			}

			// Token: 0x06000073 RID: 115 RVA: 0x00005444 File Offset: 0x00003644
			public int AddRef(IntPtr pUnk)
			{
				return Marshal.AddRef(pUnk);
			}

			// Token: 0x06000074 RID: 116 RVA: 0x0000545C File Offset: 0x0000365C
			public int Release(IntPtr pUnk)
			{
				return Marshal.Release(pUnk);
			}

			// Token: 0x06000075 RID: 117 RVA: 0x00005474 File Offset: 0x00003674
			public MyUnknown()
			{
			}
		}

		// Token: 0x02000010 RID: 16
		[ComImport]
		[ComVisible(false)]
		[Guid("dca42645-c410-4859-ab3c-9e9c563c57bb")]
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ISppNamedParamsReadWrite
		{
			// Token: 0x06000076 RID: 118
			int QueryInterface(IntPtr pUnk, ref Guid riid, out IntPtr pVoid);
		}

		// Token: 0x02000011 RID: 17
		[ClassInterface(ClassInterfaceType.None)]
		[Guid("dca42645-c410-4859-ab3c-9e9c563c57bb")]
		public class MySppNamedParamsReadWrite : ComHelper.ISppNamedParamsReadWrite
		{
			// Token: 0x06000077 RID: 119 RVA: 0x00005480 File Offset: 0x00003680
			public int QueryInterface(IntPtr pUnk, ref Guid riid, out IntPtr pVoid)
			{
				return Marshal.QueryInterface(pUnk, ref riid, out pVoid);
			}

			// Token: 0x06000078 RID: 120 RVA: 0x0000549A File Offset: 0x0000369A
			public MySppNamedParamsReadWrite()
			{
			}
		}

		// Token: 0x02000012 RID: 18
		[ComImport]
		[ComVisible(false)]
		[Guid("22F58556-C467-43CD-98FF-7DBCADB2F661")]
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ISppNamedParamsReadOnly
		{
			// Token: 0x06000079 RID: 121
			int QueryInterface(IntPtr pUnk, ref Guid riid, out IntPtr pVoid);
		}

		// Token: 0x02000013 RID: 19
		[ClassInterface(ClassInterfaceType.None)]
		[Guid("22F58556-C467-43CD-98FF-7DBCADB2F661")]
		public class MySppNamedParamsReadOnly : ComHelper.ISppNamedParamsReadOnly
		{
			// Token: 0x0600007A RID: 122 RVA: 0x000054A4 File Offset: 0x000036A4
			public int QueryInterface(IntPtr pUnk, ref Guid riid, out IntPtr pVoid)
			{
				return Marshal.QueryInterface(pUnk, ref riid, out pVoid);
			}

			// Token: 0x0600007B RID: 123 RVA: 0x000054BE File Offset: 0x000036BE
			public MySppNamedParamsReadOnly()
			{
			}
		}

		// Token: 0x02000014 RID: 20
		[ComImport]
		[ComVisible(false)]
		[Guid("96B97320-ED0E-4D9F-B390-6C17EAF67277")]
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ISppParamsReadWrite
		{
			// Token: 0x0600007C RID: 124
			int QueryInterface(IntPtr pUnk, ref Guid riid, out IntPtr pVoid);
		}

		// Token: 0x02000015 RID: 21
		[ClassInterface(ClassInterfaceType.None)]
		[Guid("96B97320-ED0E-4D9F-B390-6C17EAF67277")]
		public class MySppParamsReadWrite : ComHelper.ISppParamsReadWrite
		{
			// Token: 0x0600007D RID: 125 RVA: 0x000054C8 File Offset: 0x000036C8
			public int QueryInterface(IntPtr pUnk, ref Guid riid, out IntPtr pVoid)
			{
				return Marshal.QueryInterface(pUnk, ref riid, out pVoid);
			}

			// Token: 0x0600007E RID: 126 RVA: 0x000054E2 File Offset: 0x000036E2
			public MySppParamsReadWrite()
			{
			}
		}

		// Token: 0x02000016 RID: 22
		[ComImport]
		[ComVisible(false)]
		[Guid("BE73DD34-4DAD-4AC5-BBE0-7930F45CED73")]
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ISppParamsReadOnly
		{
			// Token: 0x0600007F RID: 127
			int QueryInterface(IntPtr pUnk, ref Guid riid, out IntPtr pVoid);
		}

		// Token: 0x02000017 RID: 23
		[ClassInterface(ClassInterfaceType.None)]
		[Guid("BE73DD34-4DAD-4AC5-BBE0-7930F45CED73")]
		public class MySppParamsReadOnly : ComHelper.ISppParamsReadOnly
		{
			// Token: 0x06000080 RID: 128 RVA: 0x000054EC File Offset: 0x000036EC
			public int QueryInterface(IntPtr pUnk, ref Guid riid, out IntPtr pVoid)
			{
				return Marshal.QueryInterface(pUnk, ref riid, out pVoid);
			}

			// Token: 0x06000081 RID: 129 RVA: 0x00005506 File Offset: 0x00003706
			public MySppParamsReadOnly()
			{
			}
		}
	}
}
