using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace HwidGetCurrentEx
{
	// Token: 0x02000002 RID: 2
	internal static class BitUtil
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static string ReadNullTerminatedAnsiString(byte[] buffer, int offset)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (char c = (char)buffer[offset]; c > '\0'; c = (char)buffer[offset])
			{
				stringBuilder.Append(c);
				offset++;
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002090 File Offset: 0x00000290
		public static byte[] StrToByteArray(string str)
		{
			Dictionary<string, byte> dictionary = new Dictionary<string, byte>();
			for (int i = 0; i <= 0xFF; i++)
			{
				dictionary.Add(i.ToString("X2"), (byte)i);
			}
			List<byte> list = new List<byte>();
			for (int j = 0; j < str.Length; j += 2)
			{
				list.Add(dictionary[str.Substring(j, 2)]);
			}
			return list.ToArray();
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002114 File Offset: 0x00000314
		public static ulong array2ulong(byte[] bytes, int start, int length)
		{
			bytes = bytes.Skip(start).Take(length).ToArray<byte>();
			ulong num = 0UL;
			foreach (byte b in bytes)
			{
				num = num * 0x100UL + (ulong)b;
			}
			return num;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002161 File Offset: 0x00000361
		public static T[] Concats<T>(this T[] array1, params T[] array2)
		{
			return BitUtil.ConcatArray<T>(new T[][]
			{
				array1,
				array2
			});
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002178 File Offset: 0x00000378
		public static T[] ConcatArray<T>(params T[][] arrays)
		{
			int num;
			for (int i = num = 0; i < arrays.Length; i++)
			{
				num += arrays[i].Length;
			}
			T[] array = new T[num];
			for (int i = num = 0; i < arrays.Length; i++)
			{
				arrays[i].CopyTo(array, num);
				num += arrays[i].Length;
			}
			return array;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000021DC File Offset: 0x000003DC
		public static byte LOBYTE(int a)
		{
			return (byte)((short)a & 0xFF);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000021F8 File Offset: 0x000003F8
		public static short MAKEWORD(byte a, byte b)
		{
			return (short)((int)(a & byte.MaxValue) | (int)(b & byte.MaxValue) << 8);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002220 File Offset: 0x00000420
		public static byte LOBYTE(short a)
		{
			return (byte)(a & 0xFF);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x0000223C File Offset: 0x0000043C
		public static byte HIBYTE(short a)
		{
			return (byte)(a >> 8);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002254 File Offset: 0x00000454
		public static int MAKELONG(short a, short b)
		{
			return ((int)a & 0xFFFF) | ((int)b & 0xFFFF) << 0x10;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002278 File Offset: 0x00000478
		public static short HIWORD(int a)
		{
			return (short)(a >> 0x10);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002290 File Offset: 0x00000490
		public static short LOWORD(int a)
		{
			return (short)(a & 0xFFFF);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000022AC File Offset: 0x000004AC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint RotateLeft(uint value, int offset)
		{
			return value << offset | value >> 0x20 - offset;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000022D0 File Offset: 0x000004D0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong RotateLeft64(ulong value, int offset)
		{
			return value << offset | value >> 0x40 - offset;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000022F4 File Offset: 0x000004F4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint RotateRight(uint value, int offset)
		{
			return value >> offset | value << 0x20 - offset;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002318 File Offset: 0x00000518
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong RotateRight64(ulong value, int offset)
		{
			return value >> offset | value << 0x40 - offset;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000233C File Offset: 0x0000053C
		public static int HIDWORD(long intValue)
		{
			return Convert.ToInt32(intValue >> 0x20);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002358 File Offset: 0x00000558
		public static int LODWORD(long intValue)
		{
			long num = intValue << 0x20;
			return Convert.ToInt32(num >> 0x20);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002378 File Offset: 0x00000578
		public static short PAIR(sbyte high, sbyte low)
		{
			return (short)((int)high << 8 | (int)((byte)low));
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002394 File Offset: 0x00000594
		public static int PAIR(short high, int low)
		{
			return (int)high << 0x10 | (int)((ushort)low);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000023B0 File Offset: 0x000005B0
		public static long PAIR(int high, long low)
		{
			return (long)high << 0x20 | (long)((ulong)((uint)low));
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000023CC File Offset: 0x000005CC
		public static ushort PAIR(byte high, ushort low)
		{
			return (ushort)((int)high << 8 | (int)((byte)low));
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000023E8 File Offset: 0x000005E8
		public static uint PAIR(ushort high, uint low)
		{
			return (uint)((int)high << 0x10 | (int)((ushort)low));
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002404 File Offset: 0x00000604
		public static ulong PAIR(uint high, ulong low)
		{
			return (ulong)high << 0x20 | (ulong)((uint)low);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002420 File Offset: 0x00000620
		public static int adc(uint first, uint second, ref uint carry)
		{
			uint num = 0U;
			bool flag = carry == 0U;
			int result;
			if (flag)
			{
				uint num2 = first + second;
				carry = ((num2 < first && num2 < second) ? 1U : 0U);
				result = (int)num2;
			}
			else
			{
				uint num2 = (uint)BitUtil.adc(first, second, ref num);
				bool flag2 = carry > 0U;
				if (flag2)
				{
					num2 += 1U;
					num |= ((num2 == 0U) ? 1U : 0U);
				}
				carry = num;
				result = (int)num2;
			}
			return result;
		}
	}
}
