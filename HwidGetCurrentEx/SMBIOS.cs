using System;
using System.Runtime.InteropServices;

namespace HwidGetCurrentEx
{
	// Token: 0x0200000A RID: 10
	public class SMBIOS
	{
		// Token: 0x06000060 RID: 96 RVA: 0x0000528E File Offset: 0x0000348E
		public SMBIOS()
		{
		}

		// Token: 0x02000030 RID: 48
		public enum SMBIOSTableType : sbyte
		{
			// Token: 0x040000F8 RID: 248
			BaseBoardInformation = 2,
			// Token: 0x040000F9 RID: 249
			BIOSInformation = 0,
			// Token: 0x040000FA RID: 250
			BIOSLanguageInformation = 0xD,
			// Token: 0x040000FB RID: 251
			CacheInformation = 7,
			// Token: 0x040000FC RID: 252
			const_11 = 0xB,
			// Token: 0x040000FD RID: 253
			EnclosureInformation = 3,
			// Token: 0x040000FE RID: 254
			EndofTable = 0x7F,
			// Token: 0x040000FF RID: 255
			GroupAssociations = 0xE,
			// Token: 0x04000100 RID: 256
			MemoryArrayMappedAddress = 0x13,
			// Token: 0x04000101 RID: 257
			MemoryControllerInformation = 5,
			// Token: 0x04000102 RID: 258
			MemoryDevice = 0x11,
			// Token: 0x04000103 RID: 259
			MemoryDeviceMappedAddress = 0x14,
			// Token: 0x04000104 RID: 260
			MemoryErrorInformation = 0x12,
			// Token: 0x04000105 RID: 261
			MemoryModuleInformation = 6,
			// Token: 0x04000106 RID: 262
			OnBoardDevicesInformation = 0xA,
			// Token: 0x04000107 RID: 263
			PhysicalMemoryArray = 0x10,
			// Token: 0x04000108 RID: 264
			PortConnectorInformation = 8,
			// Token: 0x04000109 RID: 265
			ProcessorInformation = 4,
			// Token: 0x0400010A RID: 266
			SystemConfigurationOptions = 0xC,
			// Token: 0x0400010B RID: 267
			SystemEventLog = 0xF,
			// Token: 0x0400010C RID: 268
			SystemInformation = 1,
			// Token: 0x0400010D RID: 269
			SystemSlotsInformation = 9
		}

		// Token: 0x02000031 RID: 49
		public struct SMBIOSTableHeader
		{
			// Token: 0x0400010E RID: 270
			public SMBIOS.SMBIOSTableType type;

			// Token: 0x0400010F RID: 271
			public byte length;

			// Token: 0x04000110 RID: 272
			public ushort Handle;
		}

		// Token: 0x02000032 RID: 50
		public struct SMBIOSTableSystemInfo
		{
			// Token: 0x04000111 RID: 273
			public SMBIOS.SMBIOSTableHeader header;

			// Token: 0x04000112 RID: 274
			public byte manufacturer;

			// Token: 0x04000113 RID: 275
			public byte productName;

			// Token: 0x04000114 RID: 276
			public byte version;

			// Token: 0x04000115 RID: 277
			public byte serialNumber;

			// Token: 0x04000116 RID: 278
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x10)]
			public byte[] UUID;
		}

		// Token: 0x02000033 RID: 51
		public struct SMBIOSTableBaseBoardInfo
		{
			// Token: 0x04000117 RID: 279
			public SMBIOS.SMBIOSTableHeader header;
		}

		// Token: 0x02000034 RID: 52
		public struct SMBIOSTableEnclosureInfo
		{
			// Token: 0x04000118 RID: 280
			public SMBIOS.SMBIOSTableHeader header;
		}

		// Token: 0x02000035 RID: 53
		public struct SMBIOSTableProcessorInfo
		{
			// Token: 0x04000119 RID: 281
			public SMBIOS.SMBIOSTableHeader header;
		}

		// Token: 0x02000036 RID: 54
		public struct SMBIOSTableCacheInfo
		{
			// Token: 0x0400011A RID: 282
			public SMBIOS.SMBIOSTableHeader header;
		}

		// Token: 0x02000037 RID: 55
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct UnkownInfo
		{
			// Token: 0x0400011B RID: 283
			public SMBIOS.SMBIOSTableHeader header;
		}

		// Token: 0x02000038 RID: 56
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct SHAInfo
		{
			// Token: 0x0400011C RID: 284
			public SMBIOS.SMBIOSTableHeader header;

			// Token: 0x0400011D RID: 285
			public int size;

			// Token: 0x0400011E RID: 286
			public byte cache;
		}

		// Token: 0x02000039 RID: 57
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct PhysicalMemoryArray
		{
			// Token: 0x0400011F RID: 287
			public SMBIOS.SMBIOSTableHeader header;

			// Token: 0x04000120 RID: 288
			public uint EmptyPageNumber;

			// Token: 0x04000121 RID: 289
			public uint TotalPageNumber;
		}

		// Token: 0x0200003A RID: 58
		public struct BIOSInformation
		{
			// Token: 0x04000122 RID: 290
			public SMBIOS.SMBIOSTableHeader header;

			// Token: 0x04000123 RID: 291
			public byte vendor;

			// Token: 0x04000124 RID: 292
			public byte version;

			// Token: 0x04000125 RID: 293
			public ushort startingSegment;

			// Token: 0x04000126 RID: 294
			public byte releaseDate;

			// Token: 0x04000127 RID: 295
			public byte biosRomSize;

			// Token: 0x04000128 RID: 296
			public ulong characteristics;

			// Token: 0x04000129 RID: 297
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
			public byte[] extensionBytes;
		}

		// Token: 0x0200003B RID: 59
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct MemCtrlInfo
		{
			// Token: 0x0400012A RID: 298
			public SMBIOS.SMBIOSTableHeader header;
		}

		// Token: 0x0200003C RID: 60
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct MemModuleInfo
		{
			// Token: 0x0400012B RID: 299
			public SMBIOS.SMBIOSTableHeader header;

			// Token: 0x0400012C RID: 300
			public byte SocketDesignation;

			// Token: 0x0400012D RID: 301
			public byte BankConnections;

			// Token: 0x0400012E RID: 302
			public byte CurrentSpeed;
		}

		// Token: 0x0200003D RID: 61
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct OemString
		{
			// Token: 0x0400012F RID: 303
			public SMBIOS.SMBIOSTableHeader header;
		}

		// Token: 0x0200003E RID: 62
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct MemoryArrayMappedAddress
		{
			// Token: 0x04000130 RID: 304
			public SMBIOS.SMBIOSTableHeader header;

			// Token: 0x04000131 RID: 305
			public uint Starting;

			// Token: 0x04000132 RID: 306
			public uint Ending;

			// Token: 0x04000133 RID: 307
			public ushort Handle;

			// Token: 0x04000134 RID: 308
			public byte PartitionWidth;
		}

		// Token: 0x0200003F RID: 63
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct BuiltinPointDevice
		{
			// Token: 0x04000135 RID: 309
			public SMBIOS.SMBIOSTableHeader header;
		}

		// Token: 0x02000040 RID: 64
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct PortableBattery
		{
			// Token: 0x04000136 RID: 310
			public SMBIOS.SMBIOSTableHeader header;
		}

		// Token: 0x02000041 RID: 65
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct MemoryDevice
		{
			// Token: 0x04000137 RID: 311
			public SMBIOS.SMBIOSTableHeader header;

			// Token: 0x04000138 RID: 312
			public ushort PhysicalArrayHandle;

			// Token: 0x04000139 RID: 313
			public ushort ErrorInformationHandle;

			// Token: 0x0400013A RID: 314
			public ushort TotalWidth;

			// Token: 0x0400013B RID: 315
			public ushort DataWidth;

			// Token: 0x0400013C RID: 316
			public ushort Size;
		}

		// Token: 0x02000042 RID: 66
		public struct RawSMBIOSData
		{
			// Token: 0x0400013D RID: 317
			public byte Used20CallingMethod;

			// Token: 0x0400013E RID: 318
			public byte SMBIOSMajorVersion;

			// Token: 0x0400013F RID: 319
			public byte SMBIOSMinorVersion;

			// Token: 0x04000140 RID: 320
			public byte DmiRevision;

			// Token: 0x04000141 RID: 321
			public uint Length;
		}
	}
}
