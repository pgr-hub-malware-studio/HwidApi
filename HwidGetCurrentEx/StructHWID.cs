using System;

namespace HwidGetCurrentEx
{
	// Token: 0x02000008 RID: 8
	public class StructHWID
	{
		// Token: 0x06000048 RID: 72 RVA: 0x0000274B File Offset: 0x0000094B
		public StructHWID()
		{
		}

		// Token: 0x04000023 RID: 35
		public int cbsize;

		// Token: 0x04000024 RID: 36
		public short BiosHwidCount;

		// Token: 0x04000025 RID: 37
		public short MemoryHwidCount;

		// Token: 0x04000026 RID: 38
		public short CpuHwidCount;

		// Token: 0x04000027 RID: 39
		public short NdisHwidCount;

		// Token: 0x04000028 RID: 40
		public short HWProfileCount;

		// Token: 0x04000029 RID: 41
		public short GuidHwidCount;

		// Token: 0x0400002A RID: 42
		public short PcmciaHwidCount;

		// Token: 0x0400002B RID: 43
		public short BthPortHwidCount;

		// Token: 0x0400002C RID: 44
		public short ScsiAdapterHwidCount;

		// Token: 0x0400002D RID: 45
		public short DisplayHwidCount;

		// Token: 0x0400002E RID: 46
		public short DiskHwidCount;

		// Token: 0x0400002F RID: 47
		public short HdcHwidCount;

		// Token: 0x04000030 RID: 48
		public short WwanHwidCount;

		// Token: 0x04000031 RID: 49
		public short CdromHwidCount;

		// Token: 0x04000032 RID: 50
		public byte[] BiosHwidBlock;

		// Token: 0x04000033 RID: 51
		public byte[] MemoryHwidBlock;

		// Token: 0x04000034 RID: 52
		public byte[] CpuHwidBlock;

		// Token: 0x04000035 RID: 53
		public byte[] NdisHwidBlock;

		// Token: 0x04000036 RID: 54
		public byte[] HWProfileBlock;

		// Token: 0x04000037 RID: 55
		public byte[] GuidHwidBlock;

		// Token: 0x04000038 RID: 56
		public byte[] PcmciaHwidBlock;

		// Token: 0x04000039 RID: 57
		public byte[] BthPortHwidBlock;

		// Token: 0x0400003A RID: 58
		public byte[] ScsiAdapterHwidBlock;

		// Token: 0x0400003B RID: 59
		public byte[] DisplayHwidBlock;

		// Token: 0x0400003C RID: 60
		public byte[] DiskHwidBlock;

		// Token: 0x0400003D RID: 61
		public byte[] HdcHwidBlock;

		// Token: 0x0400003E RID: 62
		public byte[] WwanHwidBlock;

		// Token: 0x0400003F RID: 63
		public byte[] CdromHwidBlock;
	}
}
