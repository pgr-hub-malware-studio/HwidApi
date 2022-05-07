using System;
using System.Runtime.InteropServices;

namespace HwidGetCurrentEx
{
	// Token: 0x02000005 RID: 5
	public static class CPUID
	{
		// Token: 0x0600001B RID: 27 RVA: 0x00002560 File Offset: 0x00000760
		public static byte[] Invoke(int level)
		{
			IntPtr intPtr = IntPtr.Zero;
			byte[] result;
			try
			{
				bool flag = IntPtr.Size == 4;
				byte[] array;
				if (flag)
				{
					array = CPUID.x86CodeBytes;
				}
				else
				{
					array = CPUID.x64CodeBytes;
				}
				intPtr = CPUID.VirtualAlloc(IntPtr.Zero, new UIntPtr((uint)array.Length), CPUID.AllocationType.COMMIT | CPUID.AllocationType.RESERVE, CPUID.MemoryProtection.EXECUTE_READWRITE);
				Marshal.Copy(array, 0, intPtr, array.Length);
				CPUID.CpuIDDelegate cpuIDDelegate = (CPUID.CpuIDDelegate)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(CPUID.CpuIDDelegate));
				GCHandle a = default(GCHandle);
				byte[] array2 = new byte[0x10];
				try
				{
					a = GCHandle.Alloc(array2, GCHandleType.Pinned);
					cpuIDDelegate(level, array2);
				}
				finally
				{
					bool flag2 = a != default(GCHandle);
					if (flag2)
					{
						a.Free();
					}
				}
				result = array2;
			}
			finally
			{
				bool flag3 = intPtr != IntPtr.Zero;
				if (flag3)
				{
					CPUID.VirtualFree(intPtr, 0U, 0x8000U);
					intPtr = IntPtr.Zero;
				}
			}
			return result;
		}

		// Token: 0x0600001C RID: 28
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr VirtualAlloc(IntPtr lpAddress, UIntPtr dwSize, CPUID.AllocationType flAllocationType, CPUID.MemoryProtection flProtect);

		// Token: 0x0600001D RID: 29
		[DllImport("kernel32")]
		private static extern bool VirtualFree(IntPtr lpAddress, uint dwSize, uint dwFreeType);

		// Token: 0x0600001E RID: 30 RVA: 0x0000266C File Offset: 0x0000086C
		// Note: this type is marked as 'beforefieldinit'.
		static CPUID()
		{
		}

		// Token: 0x0400000B RID: 11
		private static readonly byte[] x86CodeBytes = new byte[]
		{
			0x55,
			0x8B,
			0xEC,
			0x53,
			0x57,
			0x8B,
			0x45,
			8,
			0xF,
			0xA2,
			0x8B,
			0x7D,
			0xC,
			0x89,
			7,
			0x89,
			0x5F,
			4,
			0x89,
			0x4F,
			8,
			0x89,
			0x57,
			0xC,
			0x5F,
			0x5B,
			0x8B,
			0xE5,
			0x5D,
			0xC3
		};

		// Token: 0x0400000C RID: 12
		private static readonly byte[] x64CodeBytes = new byte[]
		{
			0x53,
			0x49,
			0x89,
			0xD0,
			0x89,
			0xC8,
			0xF,
			0xA2,
			0x41,
			0x89,
			0x40,
			0,
			0x41,
			0x89,
			0x58,
			4,
			0x41,
			0x89,
			0x48,
			8,
			0x41,
			0x89,
			0x50,
			0xC,
			0x5B,
			0xC3
		};

		// Token: 0x02000018 RID: 24
		// (Invoke) Token: 0x06000083 RID: 131
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate void CpuIDDelegate(int level, byte[] buffer);

		// Token: 0x02000019 RID: 25
		[Flags]
		private enum AllocationType : uint
		{
			// Token: 0x04000050 RID: 80
			COMMIT = 0x1000U,
			// Token: 0x04000051 RID: 81
			RESERVE = 0x2000U,
			// Token: 0x04000052 RID: 82
			RESET = 0x80000U,
			// Token: 0x04000053 RID: 83
			LARGE_PAGES = 0x20000000U,
			// Token: 0x04000054 RID: 84
			PHYSICAL = 0x400000U,
			// Token: 0x04000055 RID: 85
			TOP_DOWN = 0x100000U,
			// Token: 0x04000056 RID: 86
			WRITE_WATCH = 0x200000U
		}

		// Token: 0x0200001A RID: 26
		[Flags]
		private enum MemoryProtection : uint
		{
			// Token: 0x04000058 RID: 88
			EXECUTE = 0x10U,
			// Token: 0x04000059 RID: 89
			EXECUTE_READ = 0x20U,
			// Token: 0x0400005A RID: 90
			EXECUTE_READWRITE = 0x40U,
			// Token: 0x0400005B RID: 91
			EXECUTE_WRITECOPY = 0x80U,
			// Token: 0x0400005C RID: 92
			NOACCESS = 1U,
			// Token: 0x0400005D RID: 93
			READONLY = 2U,
			// Token: 0x0400005E RID: 94
			READWRITE = 4U,
			// Token: 0x0400005F RID: 95
			WRITECOPY = 8U,
			// Token: 0x04000060 RID: 96
			GUARD_Modifierflag = 0x100U,
			// Token: 0x04000061 RID: 97
			NOCACHE_Modifierflag = 0x200U,
			// Token: 0x04000062 RID: 98
			WRITECOMBINE_Modifierflag = 0x400U
		}
	}
}
