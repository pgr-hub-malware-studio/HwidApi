using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace HwidGetCurrentEx
{
	// Token: 0x02000009 RID: 9
	public static class HWID
	{
		// Token: 0x06000049 RID: 73 RVA: 0x00002754 File Offset: 0x00000954
		public static string HwidCreateBlock(byte[] arrayHWID, int cbsize)
		{
			byte[] array = new byte[]
			{
				0,
				2,
				0,
				1,
				1,
				0,
				2,
				5,
				0,
				3,
				1,
				0,
				4,
				2,
				0,
				6,
				1,
				0,
				8,
				7,
				0,
				9,
				3,
				0,
				0xA,
				1,
				0,
				0xC,
				7,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			};
			int num = cbsize + 6 + 0x25;
			byte[] array2 = new byte[num];
			array2[0] = (byte)num;
			array2[4] = 0x13;
			Buffer.BlockCopy(arrayHWID, 0, array2, 6, cbsize);
			array2[cbsize + 6] = 0xC;
			Buffer.BlockCopy(array, 0, array2, cbsize + 6 + 1, array.Length);
			return Convert.ToBase64String(array2);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000027BC File Offset: 0x000009BC
		public static byte[] HwidGetCurrentEx()
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			byte[] array = new byte[0x118];
			List<ushort> list = new List<ushort>();
			int i = 0;
			while (i < HWID.signByte.Length)
			{
				byte b = HWID.signByte[i];
				bool flag = b == 0;
				if (flag)
				{
					list = HWID.CollectInternal(ref GUID_DEVINTERFACE.GUID_DEVINTERFACE_CDROM, false);
					num2 = 0;
					goto IL_1FB;
				}
				bool flag2 = b == 0xE;
				if (flag2)
				{
					list = HWID.CollectWwan();
					num2 = 0;
					goto IL_1FB;
				}
				bool flag3 = b == 1;
				if (flag3)
				{
					list = HWID.CollectInternal(ref GUID_DEVINTERFACE.GUID_DEVCLASS_HDC, false);
					num2 = 1;
					goto IL_1FB;
				}
				bool flag4 = b == 2;
				if (flag4)
				{
					list = HWID.EnumInterfaces(ref GUID_DEVINTERFACE.GUID_DEVINTERFACE_DISK, 0x2D1400U);
					num2 = 2;
					goto IL_1FB;
				}
				bool flag5 = b == 3;
				if (flag5)
				{
					list = HWID.CollectInternal(ref GUID_DEVINTERFACE.GUID_DEVCLASS_DISPLAY, false);
					num2 = 3;
					goto IL_1FB;
				}
				bool flag6 = b == 4;
				if (flag6)
				{
					list = HWID.CollectInternal(ref GUID_DEVINTERFACE.GUID_DEVCLASS_SCSIADAPTER, false);
					num2 = 4;
					goto IL_1FB;
				}
				bool flag7 = b == 0xF;
				if (flag7)
				{
					list = HWID.EnumInterfaces(ref GUID_DEVINTERFACE.GUID_BTHPORT_DEVICE_INTERFACE, 0x410000U);
					num2 = 4;
					goto IL_1FB;
				}
				bool flag8 = b == 5;
				if (flag8)
				{
					list = HWID.CollectInternal(ref GUID_DEVINTERFACE.GUID_DEVCLASS_PCMCIA, false);
					num2 = -1;
					goto IL_1FB;
				}
				bool flag9 = b == 6;
				if (flag9)
				{
					list = HWID.CollectInternal(ref GUID_DEVINTERFACE.GUID_6994ad04_93ef_11d0_a3cc_00a0c9223196, true);
					num2 = 5;
					goto IL_1FB;
				}
				bool flag10 = b == 7;
				if (flag10)
				{
					list = HWID.CollectHWProfile();
					array[0x16] = 1;
				}
				else
				{
					bool flag11 = b == 8;
					if (flag11)
					{
						list = HWID.EnumInterfaces(ref GUID_DEVINTERFACE.GUID_NDIS_LAN_CLASS, 0x170002U);
						num2 = 7;
						goto IL_1FB;
					}
					bool flag12 = b == 9;
					if (flag12)
					{
						list = HWID.CollectCPU();
						num2 = 8;
						goto IL_1FB;
					}
					bool flag13 = b == 0xA;
					if (flag13)
					{
						list = HWID.CollectMemory();
						num2 = -2;
						num3 -= list.Count;
						num = -2;
						goto IL_1FB;
					}
					bool flag14 = b == 0xC;
					if (flag14)
					{
						list = HWID.CollectBIOS();
						num2 = -1;
						num3 -= list.Count;
						num = -1;
						goto IL_1FB;
					}
					goto IL_1FB;
				}
				IL_2C2:
				i++;
				continue;
				IL_1FB:
				bool flag15 = list.Count > 0;
				if (flag15)
				{
					bool flag16 = num2 >= 0;
					if (flag16)
					{
						int num4 = num2 * 2 + 4;
						byte[] array2 = array;
						int num5 = num4;
						array2[num5] += (byte)(list.Count & 0xFF);
					}
					list.Sort();
					for (int j = 0; j < list.Count; j++)
					{
						int num6 = (num + 0xE) * 2;
						byte[] bytes = BitConverter.GetBytes(list[j]);
						array[num6 + 1] = bytes[1];
						array[num6] = bytes[0];
						num3++;
						num++;
					}
				}
				else
				{
					int num7 = num2 * 2 + 4;
					byte[] array3 = array;
					int num8 = num7 + 1;
					array3[num8] += (byte)(list.Count & 0xFF);
				}
				goto IL_2C2;
			}
			array[0] = (byte)(num3 * 2 + 0x1C);
			Debug.Print(array[0].ToString() + Environment.NewLine + BitConverter.ToString(array.Take((int)array[0]).ToArray<byte>()).Replace("-", " "));
			return array.Take((int)array[0]).ToArray<byte>();
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002B04 File Offset: 0x00000D04
		private static List<ushort> CollectWwan()
		{
			List<ushort> list = new List<ushort>();
			IntPtr zero = IntPtr.Zero;
			int dwClientVersion = 1;
			int num = 0;
			int num2 = 5;
			int num3 = 0;
			Native.WWAN_INTERFACE_INFO_LIST wwan_INTERFACE_INFO_LIST = default(Native.WWAN_INTERFACE_INFO_LIST);
			try
			{
				int num4 = Native.WwanOpenHandle(dwClientVersion, IntPtr.Zero, out num, out zero);
				bool flag = num4 != 0;
				if (flag)
				{
					bool flag7;
					do
					{
						num4 = Native.WwanEnumerateInterfaces(zero, 0, out wwan_INTERFACE_INFO_LIST);
						bool flag2 = num4 != 0;
						if (flag2)
						{
							break;
						}
						num3++;
						bool flag3 = num3 > num2;
						if (flag3)
						{
							break;
						}
						bool flag4 = false;
						for (int i = 0; i < wwan_INTERFACE_INFO_LIST.dwNumberOfItems; i++)
						{
							Native.WWAN_INTERFACE_INFO wwan_INTERFACE_INFO = wwan_INTERFACE_INFO_LIST.InterfaceInfo[i];
							int num5;
							IntPtr intPtr;
							int num6;
							num4 = Native.WlanQueryInterface(zero, wwan_INTERFACE_INFO.InterfaceGuid, 7, IntPtr.Zero, out num5, out intPtr, out num6);
							bool flag5 = num4 != 0;
							if (flag5)
							{
								byte[] array = new byte[0x24];
								Marshal.Copy(new IntPtr((IntPtr.Size == 4) ? ((long)(intPtr.ToInt32() + 0x28C)) : (intPtr.ToInt64() + 0x28CL)), array, 0, array.Length);
								ushort item = HWID.AddInstanceHash(array, 0x24U, true);
								bool flag6 = !list.Contains(item);
								if (flag6)
								{
									list.Add(item);
								}
							}
						}
						flag7 = flag4;
					}
					while (!flag7);
				}
				bool flag8 = zero != IntPtr.Zero;
				if (flag8)
				{
					Native.WwanCloseHandle(zero, IntPtr.Zero);
				}
			}
			catch
			{
			}
			return list;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002CB8 File Offset: 0x00000EB8
		private static List<ushort> CollectHWProfile()
		{
			List<ushort> list = new List<ushort>();
			IntPtr intPtr = Marshal.AllocHGlobal(0x7B);
			Native.HWProfile hwprofile = new Native.HWProfile();
			Marshal.StructureToPtr<Native.HWProfile>(hwprofile, intPtr, false);
			bool currentHwProfile = Native.GetCurrentHwProfile(intPtr);
			if (currentHwProfile)
			{
				Marshal.PtrToStructure<Native.HWProfile>(intPtr, hwprofile);
			}
			else
			{
				hwprofile.dwDockInfo = 1;
			}
			bool flag = (hwprofile.dwDockInfo & 4) == 0;
			if (flag)
			{
				int num = hwprofile.dwDockInfo & 3;
				bool flag2 = num != 3;
				if (flag2)
				{
					byte[] bytes = BitConverter.GetBytes(hwprofile.dwDockInfo);
					ushort item = HWID.AddInstanceHash(bytes, 4U, false);
					bool flag3 = !list.Contains(item);
					if (flag3)
					{
						list.Add(item);
					}
				}
			}
			Marshal.FreeHGlobal(intPtr);
			return list;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002D70 File Offset: 0x00000F70
		private static List<ushort> CollectCPU()
		{
			List<ushort> list = new List<ushort>();
			byte[] array = new byte[0];
			byte[] source = CPUID.Invoke(0);
			byte[] value = CPUID.Invoke(1);
			int value2 = (int)(BitConverter.ToUInt32(value, 0) & 0xFFFFFFF0U);
			int value3 = (int)(BitConverter.ToUInt32(value, 4) & 0xFFFFFFU);
			array = array.Concat(source.Skip(4).Take(4).ToArray<byte>()).Concat(source.Skip(0xC).Take(4).ToArray<byte>()).Concat(source.Skip(8).Take(4).ToArray<byte>()).Concat(BitConverter.GetBytes(value2)).Concat(BitConverter.GetBytes(value3)).ToArray<byte>();
			ushort item = HWID.AddInstanceHash(array, 0x14U, true);
			bool flag = !list.Contains(item);
			if (flag)
			{
				list.Add(item);
			}
			return list;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002E48 File Offset: 0x00001048
		private static List<ushort> CollectMemory()
		{
			List<ushort> list = new List<ushort>();
			Native.MEMORYSTATUSEX memorystatusex = default(Native.MEMORYSTATUSEX);
			memorystatusex.dwLength = (uint)Marshal.SizeOf(typeof(Native.MEMORYSTATUSEX));
			Native.GlobalMemoryStatusEx(ref memorystatusex);
			byte[] bytes = BitConverter.GetBytes(memorystatusex.ullTotalPhys);
			int num = BitConverter.ToInt32(bytes, 0);
			int num2 = BitConverter.ToInt32(bytes, 4);
			int num3 = (int)(BitUtil.PAIR(num2, (long)num) >> 0xA);
			int num4 = num2 >> 0xA;
			uint num5 = 0U;
			bool flag = !HWID.GetInstalledMemorySize(ref num5);
			if (flag)
			{
				num5 = 0U;
			}
			bool flag2 = (ulong)num5 < (ulong)((long)num3);
			if (flag2)
			{
				num5 = (uint)num3;
			}
			uint num6 = (uint)(BitUtil.PAIR(0U, (ulong)num5) >> 0x16);
			uint num7 = num5 << 0xA;
			int num8 = 0;
			do
			{
				bool flag3 = num6 < HWID.MemoryMagic[2 * num8] || (num6 <= HWID.MemoryMagic[2 * num8] && num7 <= HWID.MemoryMagic[2 * num8]);
				if (flag3)
				{
					break;
				}
				num8++;
			}
			while (num8 < 8);
			bool flag4 = num8 == 8;
			int value;
			if (flag4)
			{
				ulong numLong;
                unchecked
                {
					numLong = (ulong)-0x40000000;

				}
				value = 8 * (int)(BitUtil.PAIR(num6, (ulong)num7) - numLong >> 0x1E) + 7;
			}
			else
			{
				value = num8;
			}
			byte[] bytes2 = BitConverter.GetBytes(value);
			ushort item = HWID.AddInstanceHash(bytes2, 4U, true);
			bool flag5 = !list.Contains(item);
			if (flag5)
			{
				list.Add(item);
			}
			return list;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002FB0 File Offset: 0x000011B0
		private static int GetProductName(ref List<string> productList, ref IntPtr buffer, ref int position)
		{
			do
			{
				string text = Marshal.PtrToStringAnsi(new IntPtr((IntPtr.Size == 4) ? ((long)(buffer.ToInt32() + position)) : (buffer.ToInt64() + (long)position)));
				bool flag = !string.IsNullOrEmpty(text);
				if (flag)
				{
					productList.Add(text);
				}
				position += text.Length + 1;
			}
			while (Marshal.ReadByte(buffer, position) > 0);
			position++;
			return position;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00003028 File Offset: 0x00001228
		private static List<ushort> CollectBIOS()
		{
			List<ushort> list = new List<ushort>();
			List<string> list2 = new List<string>();
			uint systemFirmwareTable = Native.GetSystemFirmwareTable(0x52534D42U, 0U, IntPtr.Zero, 0U);
			IntPtr intPtr = Marshal.AllocHGlobal((int)systemFirmwareTable);
			systemFirmwareTable = Native.GetSystemFirmwareTable(0x52534D42U, 0U, intPtr, systemFirmwareTable);
			int num = 8;
			SMBIOS.BIOSInformation biosinformation = (SMBIOS.BIOSInformation)Marshal.PtrToStructure(new IntPtr((IntPtr.Size == 4) ? ((long)(intPtr.ToInt32() + num)) : (intPtr.ToInt64() + (long)num)), typeof(SMBIOS.BIOSInformation));
			num += (int)biosinformation.header.length;
			string text = Marshal.PtrToStringAnsi(new IntPtr((IntPtr.Size == 4) ? ((long)(intPtr.ToInt32() + num)) : (intPtr.ToInt64() + (long)num)));
			num += text.Length + 1;
			string text2 = Marshal.PtrToStringAnsi(new IntPtr((IntPtr.Size == 4) ? ((long)(intPtr.ToInt32() + num)) : (intPtr.ToInt64() + (long)num)));
			num += text2.Length + 1;
			string text3 = Marshal.PtrToStringAnsi(new IntPtr((IntPtr.Size == 4) ? ((long)(intPtr.ToInt32() + num)) : (intPtr.ToInt64() + (long)num)));
			num += text3.Length + 1;
			num++;
			int num2 = num + 8;
			SMBIOS.SMBIOSTableSystemInfo smbiostableSystemInfo = (SMBIOS.SMBIOSTableSystemInfo)Marshal.PtrToStructure(new IntPtr((IntPtr.Size == 4) ? ((long)(intPtr.ToInt32() + num)) : (intPtr.ToInt64() + (long)num)), typeof(SMBIOS.SMBIOSTableSystemInfo));
			num += (int)smbiostableSystemInfo.header.length;
			string text4 = Marshal.PtrToStringAnsi(new IntPtr((IntPtr.Size == 4) ? ((long)(intPtr.ToInt32() + num)) : (intPtr.ToInt64() + (long)num)));
			num += text4.Length + 1;
			string text5 = Marshal.PtrToStringAnsi(new IntPtr((IntPtr.Size == 4) ? ((long)(intPtr.ToInt32() + num)) : (intPtr.ToInt64() + (long)num)));
			num += text5.Length + 1;
			string text6 = Marshal.PtrToStringAnsi(new IntPtr((IntPtr.Size == 4) ? ((long)(intPtr.ToInt32() + num)) : (intPtr.ToInt64() + (long)num)));
			num += text6.Length + 1;
			string text7 = Marshal.PtrToStringAnsi(new IntPtr((IntPtr.Size == 4) ? ((long)(intPtr.ToInt32() + num)) : (intPtr.ToInt64() + (long)num)));
			num += text7.Length + 1;
			byte[] array = new byte[0x10];
			Marshal.Copy(new IntPtr((IntPtr.Size == 4) ? ((long)(intPtr.ToInt32() + num2)) : (intPtr.ToInt64() + (long)num2)), array, 0, array.Length);
			byte[] array2 = new byte[0];
			bool flag = text5 == "None";
			if (flag)
			{
				array2 = array.Concat(Encoding.UTF8.GetBytes(text4)).Concat(Encoding.UTF8.GetBytes(text7)).Concat(Encoding.UTF8.GetBytes(text6)).Concat(Encoding.UTF8.GetBytes(text)).ToArray<byte>();
			}
			else
			{
				array2 = array.Concat(Encoding.UTF8.GetBytes(text4)).Concat(Encoding.UTF8.GetBytes(text5)).Concat(Encoding.UTF8.GetBytes(text7)).Concat(Encoding.UTF8.GetBytes(text)).ToArray<byte>();
			}
			ushort item = HWID.AddInstanceHash(array2, (uint)array2.Length, true);
			bool flag2 = !list.Contains(item);
			if (flag2)
			{
				list.Add(item);
			}
			Marshal.FreeHGlobal(intPtr);
			return list;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000033D4 File Offset: 0x000015D4
		private static bool GetInstalledMemorySize(ref uint InstalledMemorySize)
		{
			List<string> list = new List<string>();
			uint systemFirmwareTable = Native.GetSystemFirmwareTable(0x52534D42U, 0U, IntPtr.Zero, 0U);
			IntPtr intPtr = Marshal.AllocHGlobal((int)systemFirmwareTable);
			systemFirmwareTable = Native.GetSystemFirmwareTable(0x52534D42U, 0U, intPtr, systemFirmwareTable);
			bool flag = systemFirmwareTable > 0U;
			if (flag)
			{
				int num = 8;
				byte b = Marshal.ReadByte(intPtr, num);
				while ((long)(num + 4) < (long)((ulong)systemFirmwareTable) && b != 0x7F)
				{
					byte b2 = b;
					byte b3 = b2;
					if (b3 != 0x11)
					{
						int num2 = (int)Marshal.ReadByte(intPtr, num + 1);
						num += num2;
						num = HWID.GetProductName(ref list, ref intPtr, ref num);
						b = Marshal.ReadByte(intPtr, num);
					}
					else
					{
						SMBIOS.MemoryDevice memoryDevice = (SMBIOS.MemoryDevice)Marshal.PtrToStructure(new IntPtr((IntPtr.Size == 4) ? ((long)(intPtr.ToInt32() + num)) : (intPtr.ToInt64() + (long)num)), typeof(SMBIOS.MemoryDevice));
						bool flag2 = memoryDevice.Size == 0;
						if (flag2)
						{
							return false;
						}
						InstalledMemorySize += (uint)((uint)memoryDevice.Size << 0xA);
						num += (int)memoryDevice.header.length;
						num = HWID.GetProductName(ref list, ref intPtr, ref num);
						b = Marshal.ReadByte(intPtr, num);
					}
				}
			}
			return true;
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00003520 File Offset: 0x00001720
		private static bool HwidGetPnPDeviceRegistryProperty(IntPtr hDevInfo, Native.SP_DEVINFO_DATA devData, ref int cbsize, ref byte[] buffer)
		{
			int num = 0;
			bool flag = !Native.SetupDiGetDeviceRegistryPropertyW(hDevInfo, ref devData, 8, 0, null, 0, out num);
			if (flag)
			{
				int lastWin32Error = Marshal.GetLastWin32Error();
				bool flag2 = lastWin32Error == 0xD;
				if (flag2)
				{
					return false;
				}
				bool flag3 = lastWin32Error != 0x7A;
				if (flag3)
				{
					return false;
				}
				buffer = new byte[num];
				bool flag4 = Native.SetupDiGetDeviceRegistryPropertyW(hDevInfo, ref devData, 8, 0, buffer, num, out num);
				if (flag4)
				{
					cbsize = num;
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000053 RID: 83 RVA: 0x000035A0 File Offset: 0x000017A0
		private static bool HwidGetPnPRemovalPolicy(IntPtr hDevInfo, Native.SP_DEVINFO_DATA devData)
		{
			int num = 0;
			byte[] array = new byte[4];
			bool flag = Native.SetupDiGetDeviceRegistryPropertyW(hDevInfo, ref devData, 0x1F, 0, array, 4, out num);
			bool flag2 = flag;
			if (flag2)
			{
				bool flag3 = BitConverter.ToInt32(array, 0) != 1;
				if (flag3)
				{
					return BitConverter.ToInt32(array, 0) - 2 > 3;
				}
			}
			return true;
		}

		// Token: 0x06000054 RID: 84 RVA: 0x000035F8 File Offset: 0x000017F8
		public static ushort EnumInterfaceCallback(IntPtr hFile)
		{
			ushort result = 0;
			IntPtr lpOutBuffer = Marshal.AllocHGlobal(0x124);
			uint num;
			bool flag = Native.DeviceIoControl(hFile, 0x410000U, IntPtr.Zero, 0, lpOutBuffer, 0x124, out num, IntPtr.Zero);
			bool flag2 = !flag;
			if (flag2)
			{
				int lastWin32Error = Marshal.GetLastWin32Error();
			}
			bool flag3 = num == 0x124U;
			if (flag3)
			{
				byte[] array = new byte[6];
				Marshal.Copy(new IntPtr((IntPtr.Size == 4) ? ((long)(lpOutBuffer.ToInt32() + 8)) : (lpOutBuffer.ToInt64() + 8L)), array, 0, array.Length);
				string s = BitConverter.ToString(array.Reverse<byte>().ToArray<byte>()).Replace("-", "").ToLower();
				byte[] buffer = Encoding.Unicode.GetBytes(s).Concat(new byte[2]).ToArray<byte>();
				result = HWID.AddInstanceHash(buffer, 0x1AU, true);
			}
			return result;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x000036E8 File Offset: 0x000018E8
		public static bool NextInterface(IntPtr hDevInfo, ref Guid ClassGuid, ref Native.SP_DEVICE_INTERFACE_DETAIL_DATA devDetail, ref Native.SP_DEVINFO_DATA deviceInfoData, ref uint index)
		{
			uint num = 0U;
			Native.SP_DEVICE_INTERFACE_DATA structure = default(Native.SP_DEVICE_INTERFACE_DATA);
			structure.cbSize = (uint)Marshal.SizeOf<Native.SP_DEVICE_INTERFACE_DATA>(structure);
			bool flag = Native.SetupDiEnumDeviceInterfaces(hDevInfo, IntPtr.Zero, ref ClassGuid, index, ref structure);
			bool flag2 = flag;
			bool result;
			if (flag2)
			{
				Native.SetupDiGetDeviceInterfaceDetailW(hDevInfo, ref structure, IntPtr.Zero, 0U, out num, IntPtr.Zero);
				bool flag3 = num > 6U;
				if (flag3)
				{
					Native.SP_DEVICE_INTERFACE_DETAIL_DATA sp_DEVICE_INTERFACE_DETAIL_DATA = default(Native.SP_DEVICE_INTERFACE_DETAIL_DATA);
					bool flag4 = IntPtr.Size == 8;
					if (flag4)
					{
						sp_DEVICE_INTERFACE_DETAIL_DATA.cbSize = 8;
					}
					else
					{
						sp_DEVICE_INTERFACE_DETAIL_DATA.cbSize = 4 + Marshal.SystemDefaultCharSize;
					}
					Native.SP_DEVINFO_DATA sp_DEVINFO_DATA = default(Native.SP_DEVINFO_DATA);
					sp_DEVINFO_DATA.cbSize = (uint)Marshal.SizeOf<Native.SP_DEVINFO_DATA>(sp_DEVINFO_DATA);
					bool flag5 = Native.SetupDiGetDeviceInterfaceDetailW(hDevInfo, ref structure, ref sp_DEVICE_INTERFACE_DETAIL_DATA, num, out num, ref sp_DEVINFO_DATA);
					if (flag5)
					{
						devDetail = sp_DEVICE_INTERFACE_DETAIL_DATA;
						deviceInfoData = sp_DEVINFO_DATA;
					}
				}
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000037C4 File Offset: 0x000019C4
		public static bool NextInterfaceDeviceHandle(IntPtr hDevInfo, ref Guid ClassGuid, ref bool readable, ref uint index, ref IntPtr hFile)
		{
			Native.SP_DEVICE_INTERFACE_DETAIL_DATA sp_DEVICE_INTERFACE_DETAIL_DATA = default(Native.SP_DEVICE_INTERFACE_DETAIL_DATA);
			Native.SP_DEVINFO_DATA sp_DEVINFO_DATA = default(Native.SP_DEVINFO_DATA);
			for (;;)
			{
				sp_DEVICE_INTERFACE_DETAIL_DATA = default(Native.SP_DEVICE_INTERFACE_DETAIL_DATA);
				sp_DEVINFO_DATA = default(Native.SP_DEVINFO_DATA);
				bool flag = HWID.NextInterface(hDevInfo, ref ClassGuid, ref sp_DEVICE_INTERFACE_DETAIL_DATA, ref sp_DEVINFO_DATA, ref index);
				if (!flag)
				{
					break;
				}
				index += 1U;
				bool flag2 = sp_DEVINFO_DATA.cbSize >= 0U;
				if (flag2)
				{
					bool flag3 = HWID.IsSoftwareDevice(new IntPtr((long)((ulong)sp_DEVINFO_DATA.DevInst)));
					bool flag4 = !flag3;
					if (flag4)
					{
						hFile = Native.CreateFileW(sp_DEVICE_INTERFACE_DETAIL_DATA.DevicePath, 0U, 3U, 0U, 3U, 0U, 0U);
					}
				}
				if (!(hFile == IntPtr.Zero) && hFile.ToInt32() != -1)
				{
					goto Block_5;
				}
			}
			return false;
			Block_5:
			bool flag5 = hFile != IntPtr.Zero && hFile.ToInt32() != -1;
			if (flag5)
			{
				readable = HWID.HwidGetPnPRemovalPolicy(hDevInfo, sp_DEVINFO_DATA);
				bool flag6 = !readable;
				if (flag6)
				{
				}
			}
			else
			{
				hDevInfo = IntPtr.Zero;
			}
			return true;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x000038D0 File Offset: 0x00001AD0
		private static List<ushort> EnumInterfaces(ref Guid ClassGuid, uint dwIoControlCode)
		{
			uint num = 0U;
			bool flag = false;
			IntPtr zero = IntPtr.Zero;
			List<ushort> list = new List<ushort>();
			try
			{
				IntPtr intPtr = Native.SetupDiGetClassDevsW(ref ClassGuid, null, IntPtr.Zero, 0x12);
				bool flag2 = intPtr != IntPtr.Zero;
				if (flag2)
				{
					ushort num7;
					for (;;)
					{
						bool flag3 = zero != IntPtr.Zero && zero.ToInt32() != -1;
						if (flag3)
						{
							try
							{
								Native.CloseHandle(zero);
								zero = IntPtr.Zero;
							}
							catch (Exception ex)
							{
								Debug.Print(ex.ToString());
								zero = IntPtr.Zero;
							}
						}
						Native.SP_DEVICE_INTERFACE_DATA structure = default(Native.SP_DEVICE_INTERFACE_DATA);
						structure.cbSize = (uint)Marshal.SizeOf<Native.SP_DEVICE_INTERFACE_DATA>(structure);
						bool flag4 = HWID.NextInterfaceDeviceHandle(intPtr, ref ClassGuid, ref flag, ref num, ref zero);
						if (!flag4)
						{
							goto IL_456;
						}
						bool flag5 = zero != IntPtr.Zero && zero.ToInt32() != -1;
						if (flag5)
						{
							bool flag6 = dwIoControlCode == 0x2D1400U;
							if (flag6)
							{
								bool flag7 = flag;
								if (flag7)
								{
									IntPtr intPtr2 = Marshal.AllocHGlobal(0x400);
									uint num2 = 0U;
									uint num3 = 0U;
									bool flag8 = Native.DeviceIoControl(zero, 0x2D1400U, ref num3, 0xC, intPtr2, 0x400, out num2, IntPtr.Zero);
									bool flag9 = !flag8;
									if (flag9)
									{
										int lastWin32Error = Marshal.GetLastWin32Error();
									}
									Native.STORAGE_DEVICE_DESCRIPTOR storage_DEVICE_DESCRIPTOR = (Native.STORAGE_DEVICE_DESCRIPTOR)Marshal.PtrToStructure(intPtr2, typeof(Native.STORAGE_DEVICE_DESCRIPTOR));
									int num4 = Marshal.SizeOf<Native.STORAGE_DEVICE_DESCRIPTOR>(storage_DEVICE_DESCRIPTOR);
									int num5 = (int)(storage_DEVICE_DESCRIPTOR.Size - (uint)num4);
									storage_DEVICE_DESCRIPTOR.RawDeviceProperties = new byte[num5];
									Marshal.Copy(new IntPtr(intPtr2.ToInt64() + (long)num4), storage_DEVICE_DESCRIPTOR.RawDeviceProperties, 0, num5);
									string text = string.Empty;
									string text2 = string.Empty;
									bool flag10 = storage_DEVICE_DESCRIPTOR.VendorIdOffset > 0U;
									if (flag10)
									{
										int offset = (int)(storage_DEVICE_DESCRIPTOR.VendorIdOffset - (uint)Marshal.SizeOf<Native.STORAGE_DEVICE_DESCRIPTOR>(storage_DEVICE_DESCRIPTOR));
										string text3 = BitUtil.ReadNullTerminatedAnsiString(storage_DEVICE_DESCRIPTOR.RawDeviceProperties, offset);
										while (text3.EndsWith("  "))
										{
											text3 = text3.Remove(text3.Length - 1);
										}
										text += text3;
									}
									bool flag11 = storage_DEVICE_DESCRIPTOR.ProductIdOffset > 0U;
									if (flag11)
									{
										int offset2 = (int)(storage_DEVICE_DESCRIPTOR.ProductIdOffset - (uint)Marshal.SizeOf<Native.STORAGE_DEVICE_DESCRIPTOR>(storage_DEVICE_DESCRIPTOR));
										string text4 = BitUtil.ReadNullTerminatedAnsiString(storage_DEVICE_DESCRIPTOR.RawDeviceProperties, offset2);
										text += text4.Trim();
									}
									bool flag12 = storage_DEVICE_DESCRIPTOR.SerialNumberOffset > 0U && storage_DEVICE_DESCRIPTOR.SerialNumberOffset != uint.MaxValue;
									if (flag12)
									{
										int offset3 = (int)(storage_DEVICE_DESCRIPTOR.SerialNumberOffset - (uint)Marshal.SizeOf<Native.STORAGE_DEVICE_DESCRIPTOR>(storage_DEVICE_DESCRIPTOR));
										text2 = BitUtil.ReadNullTerminatedAnsiString(storage_DEVICE_DESCRIPTOR.RawDeviceProperties, offset3);
									}
									bool flag13 = !string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(text2);
									if (flag13)
									{
										byte[] array = new byte[1].Concats(Encoding.UTF8.GetBytes(text)).Concats(new byte[1]).Concats(Encoding.UTF8.GetBytes(text2)).Concats(new byte[1]).ToArray<byte>();
										ushort num6 = HWID.AddInstanceHash(array, (uint)array.Length, true);
										bool flag14 = !flag;
										if (flag14)
										{
											num6 += 1;
										}
										bool flag15 = !list.Contains(num6);
										if (flag15)
										{
											list.Add(num6);
										}
									}
								}
							}
							else
							{
								bool flag16 = dwIoControlCode == 0x410000U;
								if (flag16)
								{
									num7 = HWID.EnumInterfaceCallback(zero);
									bool flag17 = num7 > 0;
									if (flag17)
									{
										break;
									}
								}
								else
								{
									bool flag18 = dwIoControlCode == 0x170002U;
									if (flag18)
									{
										IntPtr intPtr3 = Marshal.AllocHGlobal(6);
										uint num8 = 0U;
										uint num9 = 0x1010101U;
										bool flag19 = Native.DeviceIoControl(zero, 0x170002U, ref num9, 4, intPtr3, 6, out num8, IntPtr.Zero);
										bool flag20 = !flag19;
										if (flag20)
										{
											int lastWin32Error2 = Marshal.GetLastWin32Error();
										}
										bool flag21 = num8 == 6U;
										if (flag21)
										{
											byte[] array2 = new byte[6];
											Marshal.Copy(intPtr3, array2, 0, array2.Length);
											ushort num10 = HWID.AddInstanceHash(array2, 6U, true);
											bool flag22 = !flag;
											if (flag22)
											{
												num10 += 1;
											}
											bool flag23 = !list.Contains(num10);
											if (flag23)
											{
												list.Add(num10);
											}
										}
										Marshal.FreeHGlobal(intPtr3);
									}
								}
							}
						}
					}
					bool flag24 = !flag;
					if (flag24)
					{
						num7 += 1;
					}
					bool flag25 = !list.Contains(num7);
					if (flag25)
					{
						list.Add(num7);
					}
					return list;
					IL_456:;
				}
				Native.SetupDiDestroyDeviceInfoList(intPtr);
			}
			catch (Exception ex2)
			{
				Debug.Print(ex2.ToString());
			}
			return list;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00003D9C File Offset: 0x00001F9C
		private static ushort AddInstanceHash(byte[] buffer, uint cbsize, bool readable)
		{
			uint[] array = HWID.SHA256Init();
			HWID.SHA256Update(ref array, buffer, cbsize);
			uint[] array2 = HWID.SHA256Final(ref array);
			ushort num = (ushort)(array2[0] & 0xFFFEU);
			bool flag = !readable;
			if (flag)
			{
				num |= 1;
			}
			return num;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00003DE4 File Offset: 0x00001FE4
		private static bool IsSoftwareDevice(IntPtr DevInst)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(0xCE);
			int num = 0x192;
			int num2 = 0;
			int num3 = Native.CM_Get_DevNode_Registry_PropertyW(DevInst, 0x17, ref num2, intPtr, ref num, 0);
			bool flag = num3 == 0;
			if (flag)
			{
				bool flag2 = num2 != 1 || num < 2 || Marshal.PtrToStringUni(intPtr).ToString().Trim() == "SWD";
				if (flag2)
				{
					return true;
				}
				int num4 = 0;
				int num5 = 0;
				bool flag3 = Native.CM_Get_DevNode_Status(ref num4, ref num5, DevInst, 0) == 0;
				if (flag3)
				{
					bool flag4 = (num4 & 1) == 0;
					if (flag4)
					{
						return false;
					}
					IntPtr pdnDevInst = (IntPtr)0;
					bool flag5 = Native.CM_Get_Parent(ref pdnDevInst, DevInst, 0) == 0;
					if (flag5)
					{
						bool flag6 = Native.CM_Get_Device_IDW(pdnDevInst, intPtr, 0xC9U, 0U) == 0;
						if (flag6)
						{
							bool flag7 = Marshal.PtrToStringUni(intPtr).Contains("HTREE\\ROOT\\0");
							if (flag7)
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00003EE0 File Offset: 0x000020E0
		private static List<ushort> CollectInternal(ref Guid ClassGuid, bool UnknownDevice)
		{
			List<ushort> list = new List<ushort>();
			Guid empty = Guid.Empty;
			IntPtr intPtr = Native.SetupDiGetClassDevsW(ref ClassGuid, null, IntPtr.Zero, UnknownDevice ? 0x12 : 6);
			bool flag = intPtr != IntPtr.Zero;
			if (flag)
			{
				Native.SP_DEVINFO_DATA sp_DEVINFO_DATA = default(Native.SP_DEVINFO_DATA);
				sp_DEVINFO_DATA.cbSize = (uint)Marshal.SizeOf<Native.SP_DEVINFO_DATA>(default(Native.SP_DEVINFO_DATA));
				uint num = 0U;
				while (Native.SetupDiEnumDeviceInfo(intPtr, num, ref sp_DEVINFO_DATA))
				{
					bool flag2 = Native.SetupDiEnumDeviceInfo(intPtr, num, ref sp_DEVINFO_DATA);
					if (flag2)
					{
						Guid b = Guid.Empty;
						if (UnknownDevice)
						{
							int num2 = 0;
							byte[] bytes = new byte[0];
							bool flag3 = HWID.HwidGetPnPDeviceRegistryProperty(intPtr, sp_DEVINFO_DATA, ref num2, ref bytes);
							if (flag3)
							{
								ulong numUlong;
                                unchecked
                                {
									numUlong = (ulong)-2;

								}
								bool flag4 = ((long)num2 & (long)numUlong) == 0x4EL;
								if (flag4)
								{
									string g = Encoding.Unicode.GetString(bytes).Replace("\0", "");
									b = new Guid(g);
								}
							}
						}
						else
						{
							b = ClassGuid;
						}
						bool flag5 = sp_DEVINFO_DATA.ClassGuid == b;
						if (flag5)
						{
							bool flag6 = !HWID.IsSoftwareDevice(new IntPtr((long)((ulong)sp_DEVINFO_DATA.DevInst)));
							if (flag6)
							{
								bool flag7 = sp_DEVINFO_DATA.Reserved != IntPtr.Zero;
								if (flag7)
								{
									int num3 = 0;
									IntPtr intPtr2 = Marshal.AllocHGlobal(0x200);
									bool flag8 = Native.SetupDiGetDeviceRegistryProperty(intPtr, ref sp_DEVINFO_DATA, 1U, 0, intPtr2, 0x800U, ref num3);
									if (flag8)
									{
										string text = Marshal.PtrToStringUni(intPtr2);
										int num4 = text.Length * 2;
										num4 += 2;
										byte[] array = new byte[num3];
										Marshal.Copy(intPtr2, array, 0, num3);
										bool readable = HWID.HwidGetPnPRemovalPolicy(intPtr, sp_DEVINFO_DATA);
										ushort item = HWID.AddInstanceHash(array, (uint)num4, readable);
										bool flag9 = !list.Contains(item);
										if (flag9)
										{
											list.Add(item);
										}
									}
									Marshal.FreeHGlobal(intPtr2);
								}
							}
						}
					}
					num += 1U;
				}
			}
			Native.SetupDiDestroyDeviceInfoList(intPtr);
			return list;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x000040E4 File Offset: 0x000022E4
		private static uint[] SHA256Init()
		{
			uint[] array = new uint[0x70];
			uint[] array2 = new uint[]
			{
				0x6A09E667U,
				0xBB67AE85U,
				0x3C6EF372U,
				0xA54FF53AU,
				0x510E527FU,
				0x9B05688CU,
				0x1F83D9ABU,
				0x5BE0CD19U,
				0U,
				0U
			};
			Buffer.BlockCopy(array2, 0, array, 0, array2.Length * 4);
			return array;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00004124 File Offset: 0x00002324
		private static void SHA256Update(ref uint[] SHA256Init, byte[] buffer, uint cbsize)
		{
			int num = 0;
			byte[] array = new byte[0];
			bool flag = buffer.Length % 4 != 0;
			if (flag)
			{
				buffer = buffer.Concat(new byte[4 - buffer.Length % 4]).ToArray<byte>();
			}
			uint[] array2 = new uint[buffer.Length / 4];
			Buffer.BlockCopy(buffer, 0, array2, 0, buffer.Length);
			byte[] array3 = SHA256Init.SelectMany(new Func<uint, IEnumerable<byte>>(BitConverter.GetBytes)).ToArray<byte>();
			uint num2 = cbsize + (uint)array3[0x24];
			int num3 = (int)(array3[0x24] & 0x3F);
			int num4 = (int)(array3[0x24] & 0x3F);
			array3[0x24] = (byte)num2;
			SHA256Init[9] = (uint)((byte)num2);
			bool flag2 = num2 < cbsize;
			if (flag2)
			{
				byte[] array4 = array3;
				int num5 = 0x20;
				array4[num5] += 1;
			}
			long num6 = (long)num3 + (long)((ulong)cbsize);
			bool flag3 = num3 != 0 && num6 == (long)num3 + (long)((ulong)cbsize) && (uint)((long)num3 + (long)((ulong)cbsize)) >= 0x40U;
			if (flag3)
			{
				Buffer.BlockCopy(buffer, 0, SHA256Init, num3 + 0x28, 0x40 - num3);
				cbsize = (uint)(num6 - 0x40L);
				uint[] array5 = new uint[(SHA256Init.Length - 0x28) * 4];
				Buffer.BlockCopy(SHA256Init, 0x28, array5, 0, (SHA256Init.Length - 0x28) * 4);
				uint[] array6 = HWID.SHA256Transform(ref SHA256Init, array5);
				array = new byte[buffer.Length - (0x40 - num4)];
				Buffer.BlockCopy(buffer, 0x40 - num4, array, 0, buffer.Length - (0x40 - num4));
				num = array.Length;
			}
			bool flag4 = num >= 3;
			if (flag4)
			{
				bool flag5 = cbsize >= 0x40U;
				if (flag5)
				{
					uint[] array7 = new uint[array3.Length - 0x28];
					Buffer.BlockCopy(SHA256Init, 0x28, array7, 0, array7.Length);
					int num7 = (int)(cbsize >> 6);
					do
					{
						bool flag6 = cbsize > 0U;
						if (flag6)
						{
							Buffer.BlockCopy(array, 0, array7, 0, 0x40);
							uint[] array8 = HWID.SHA256Transform(ref SHA256Init, array7);
							Buffer.BlockCopy(array3, 0, array7, 0, 0x28);
							Buffer.BlockCopy(array3, 0, array2, 0, 0x40);
						}
						cbsize -= 0x40U;
						num7--;
					}
					while (num7 != 0);
				}
			}
			bool flag7 = cbsize >= 0x40U;
			if (flag7)
			{
				int num8 = (int)(cbsize >> 6);
				do
				{
					uint[] array9 = HWID.SHA256Transform(ref SHA256Init, array2);
					cbsize -= 0x40U;
					bool flag8 = cbsize > 0U;
					if (flag8)
					{
						Buffer.BlockCopy(buffer, 0x40, array2, 0, buffer.Length - 0x40);
					}
					num8--;
				}
				while (num8 != 0);
			}
			bool flag9 = cbsize > 0U;
			if (flag9)
			{
				Buffer.BlockCopy(array2, 0, SHA256Init, num4 + 0x28, (int)cbsize);
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x0000438C File Offset: 0x0000258C
		private static uint[] SHA256Transform(ref uint[] SHA256Init, uint[] buffer)
		{
			uint[] array = SHA256Init;
			uint[] array2 = new uint[0x10];
			int i = 0;
			uint num = 0U;
			uint num2 = 0U;
			while (i < 0x10)
			{
				byte[] value = BitConverter.GetBytes(buffer[i]).Reverse<byte>().ToArray<byte>();
				array2[i] = BitConverter.ToUInt32(value, 0);
				i++;
			}
			uint num3 = SHA256Init[1];
			uint num4 = SHA256Init[4];
			uint num5 = SHA256Init[3];
			uint num6 = SHA256Init[0];
			uint num7 = SHA256Init[2];
			uint num8 = SHA256Init[5];
			uint num9 = SHA256Init[6];
			uint num10 = SHA256Init[7];
			uint num11 = 0U;
			uint num12 = num3;
			uint num13 = num4;
			uint num14 = num6;
			for (;;)
			{
				uint num15 = num10 + array2[(int)num11] + HWID.SHA256Magic[(int)num11] + ((num13 & num8) ^ (num9 & ~num4)) + (BitUtil.RotateRight(num4, 6) ^ BitUtil.RotateRight(num4, 0xB) ^ BitUtil.RotateRight(num4, 0x19));
				uint num16 = num15 + num5;
				uint num17 = num14 ^ num3;
				uint num18 = num14 & num3;
				uint num19 = num15 + (BitUtil.RotateRight(num14, 2) ^ BitUtil.RotateRight(num14, 0xD) ^ BitUtil.RotateRight(num14, 0x16)) + (num18 ^ (num7 & num17));
				uint num20 = num9 + array2[(int)(1U + num11)] + HWID.SHA256Magic[(int)(num11 + 1U)] + ((num16 & num13) ^ (num8 & ~num16)) + (BitUtil.RotateRight(num16, 6) ^ BitUtil.RotateRight(num16, 0xB) ^ BitUtil.RotateRight(num16, 0x19));
				uint num21 = num20 + num7;
				uint num22 = num20 + (BitUtil.RotateRight(num19, 2) ^ BitUtil.RotateRight(num19, 0xD) ^ BitUtil.RotateRight(num19, 0x16)) + (num18 ^ (num19 & num17));
				uint num23 = num22;
				uint num24 = num8 + array2[(int)(2U + num11)] + HWID.SHA256Magic[(int)(num11 + 2U)] + ((num21 & num16) ^ (num13 & ~num21)) + (BitUtil.RotateRight(num21, 6) ^ BitUtil.RotateRight(num21, 0xB) ^ BitUtil.RotateRight(num21, 0x19));
				uint num25 = num24 + num12;
				uint num26 = num24 + (BitUtil.RotateRight(num23, 2) ^ BitUtil.RotateRight(num23, 0xD) ^ BitUtil.RotateRight(num23, 0x16)) + ((num14 & num22) ^ (num19 & (num14 ^ num22)));
				uint num27 = num13 + array2[(int)(3U + num11)] + HWID.SHA256Magic[(int)(num11 + 3U)] + ((num25 & num21) ^ (num16 & ~num25)) + (BitUtil.RotateRight(num25, 6) ^ BitUtil.RotateRight(num25, 0xB) ^ BitUtil.RotateRight(num25, 0x19));
				uint num28 = num27 + num14;
				uint num29 = num27 + (BitUtil.RotateRight(num26, 2) ^ BitUtil.RotateRight(num26, 0xD) ^ BitUtil.RotateRight(num26, 0x16)) + ((num26 & num22) ^ (num19 & (num26 ^ num22)));
				uint num30 = num16 + array2[(int)(4U + num11)] + HWID.SHA256Magic[(int)(num11 + 4U)] + ((num28 & num25) ^ (num21 & ~num28)) + (BitUtil.RotateRight(num28, 6) ^ BitUtil.RotateRight(num28, 0xB) ^ BitUtil.RotateRight(num28, 0x19));
				num10 = num30 + num19;
				num5 = num30 + (BitUtil.RotateRight(num29, 2) ^ BitUtil.RotateRight(num29, 0xD) ^ BitUtil.RotateRight(num29, 0x16)) + ((num29 & num26) ^ (num22 & (num29 ^ num26)));
				uint num31 = num21 + array2[(int)(5U + num11)] + HWID.SHA256Magic[(int)(num11 + 5U)] + ((num28 & num10) ^ (num25 & ~num10)) + (BitUtil.RotateRight(num10, 6) ^ BitUtil.RotateRight(num10, 0xB) ^ BitUtil.RotateRight(num10, 0x19));
				num9 = num31 + num23;
				uint num32 = num31 + (BitUtil.RotateRight(num5, 2) ^ BitUtil.RotateRight(num5, 0xD) ^ BitUtil.RotateRight(num5, 0x16)) + ((num5 & num29) ^ (num26 & (num5 ^ num29)));
				num7 = num32;
				uint num33 = num25 + array2[(int)(6U + num11)] + HWID.SHA256Magic[(int)(num11 + 6U)] + ((num9 & num10) ^ (num28 & ~num9)) + (BitUtil.RotateRight(num9, 6) ^ BitUtil.RotateRight(num9, 0xB) ^ BitUtil.RotateRight(num9, 0x19));
				num8 = num33 + num26;
				num12 = num33 + (BitUtil.RotateRight(num32, 2) ^ BitUtil.RotateRight(num32, 0xD) ^ BitUtil.RotateRight(num32, 0x16)) + ((num32 & num5) ^ (num29 & (num32 ^ num5)));
				uint num34 = array2[(int)(7U + num11)] + HWID.SHA256Magic[(int)(num11 + 7U)] + ((num8 & num9) ^ (num10 & ~num8)) + (BitUtil.RotateRight(num8, 6) ^ BitUtil.RotateRight(num8, 0xB) ^ BitUtil.RotateRight(num8, 0x19));
				num11 += 8U;
				uint num35 = num28 + num34;
				num13 = num35 + num29;
				uint num36 = num35 + (BitUtil.RotateRight(num12, 2) ^ BitUtil.RotateRight(num12, 0xD) ^ BitUtil.RotateRight(num12, 0x16));
				uint num37 = (num12 & num32) ^ (num5 & (num12 ^ num32));
				uint num38 = num36 + num37;
				num14 = num36 + num37;
				bool flag = num11 >= 0x10U;
				if (flag)
				{
					break;
				}
				num4 = num13;
				num3 = num12;
			}
			bool flag2 = num11 < 0x40U;
			if (flag2)
			{
				char c = (char)(num11 - 2U);
				int num39 = (int)(num11 - 7U);
				char c2 = (char)(num11 + 1U);
				int num40 = (int)(num11 - 2U);
				int num41 = (int)(num11 + 1U);
				do
				{
					uint num42 = array2[(int)(num11 & 0xFU)];
					char c3 = (char)num39;
					int num43 = num39 + 1;
					num42 += array2[(int)(c3 & '\u000f')] + (array2[(int)(c2 & '\u000f')] >> 3 ^ BitUtil.RotateRight(array2[(int)(c2 & '\u000f')], 7) ^ BitUtil.RotateRight(array2[(int)(c2 & '\u000f')], 0x12)) + (array2[(int)(c & '\u000f')] >> 0xA ^ BitUtil.RotateRight(array2[(int)(c & '\u000f')], 0x11) ^ BitUtil.RotateRight(array2[(int)(c & '\u000f')], 0x13));
					array2[(int)(num11 & 0xFU)] = num42;
					uint num44 = num10 + num42 + HWID.SHA256Magic[(int)num11] + ((num13 & num8) ^ (num9 & ~num13)) + (BitUtil.RotateRight(num13, 6) ^ BitUtil.RotateRight(num13, 0xB) ^ BitUtil.RotateRight(num13, 0x19));
					uint num45 = num44 + num5;
					int num46 = num41 + 1;
					int num47 = num46;
					int num48 = num40 + 1;
					int num49 = num48;
					uint num50 = num44 + (BitUtil.RotateRight(num14, 2) ^ BitUtil.RotateRight(num14, 0xD) ^ BitUtil.RotateRight(num14, 0x16)) + ((num14 & num12) ^ (num7 & (num14 ^ num12)));
					uint num51 = array2[(int)(num11 + 2U & 0xFU)];
					uint num52 = array2[(int)(num11 + 1U & 0xFU)];
					int num53 = num43++ & 0xF;
					num52 += array2[num53] + (num51 >> 3 ^ BitUtil.RotateRight(num51, 7) ^ BitUtil.RotateRight(num51, 0x12)) + (array2[num48 & 0xF] >> 0xA ^ BitUtil.RotateRight(array2[num48 & 0xF], 0x11) ^ BitUtil.RotateRight(array2[num48 & 0xF], 0x13));
					array2[(int)(num11 + 1U & 0xFU)] = num52;
					uint num54 = num9 + num52 + HWID.SHA256Magic[(int)(num11 + 1U)] + ((num45 & num13) ^ (num8 & ~num45)) + (BitUtil.RotateRight(num45, 6) ^ BitUtil.RotateRight(num45, 0xB) ^ BitUtil.RotateRight(num45, 0x19));
					uint num55 = num54 + num7;
					uint num56 = num54 + (BitUtil.RotateRight(num50, 2) ^ BitUtil.RotateRight(num50, 0xD) ^ BitUtil.RotateRight(num50, 0x16)) + ((num14 & num12) ^ (num50 & (num14 ^ num12)));
					int num57 = num47 + 1;
					int num58 = num57;
					uint num59 = array2[(int)(num11 + 3U & 0xFU)];
					uint num60 = array2[(int)(num11 + 2U & 0xFU)];
					int num61 = num43++ & 0xF;
					num60 += array2[num61] + (num59 >> 3 ^ BitUtil.RotateRight(num59, 7) ^ BitUtil.RotateRight(num59, 0x12)) + (array2[num48 + 1 & 0xF] >> 0xA ^ BitUtil.RotateRight(array2[num48 + 1 & 0xF], 0x11) ^ BitUtil.RotateRight(array2[num48 + 1 & 0xF], 0x13));
					array2[(int)(num11 + 2U & 0xFU)] = num60;
					uint num62 = num8 + num60 + HWID.SHA256Magic[(int)(num11 + 2U)] + ((num55 & num45) ^ (num13 & ~num55)) + (BitUtil.RotateRight(num55, 6) ^ BitUtil.RotateRight(num55, 0xB) ^ BitUtil.RotateRight(num55, 0x19));
					uint num63 = num62 + num12;
					num61 = (int)BitUtil.LOBYTE(num58 + 1);
					num48 = (int)BitUtil.LOBYTE(num48 + 2);
					uint num64 = num62 + (BitUtil.RotateRight(num56, 2) ^ BitUtil.RotateRight(num56, 0xD) ^ BitUtil.RotateRight(num56, 0x16)) + ((num14 & num56) ^ (num50 & (num14 ^ num56)));
					uint num65 = array2[(int)(num11 + 3U & 0xFU)];
					num65 += array2[num43++ & 0xF] + (array2[num61 & 0xF] >> 3 ^ BitUtil.RotateRight(array2[num61 & 0xF], 7) ^ BitUtil.RotateRight(array2[num61 & 0xF], 0x12)) + (array2[num48 & 0xF] >> 0xA ^ BitUtil.RotateRight(array2[num48 & 0xF], 0x11) ^ BitUtil.RotateRight(array2[num48 & 0xF], 0x13));
					array2[(int)(num11 + 3U & 0xFU)] = num65;
					uint num66 = num13 + num65 + HWID.SHA256Magic[(int)(num11 + 3U)] + ((num63 & num55) ^ (num45 & ~num63)) + (BitUtil.RotateRight(num63, 6) ^ BitUtil.RotateRight(num63, 0xB) ^ BitUtil.RotateRight(num63, 0x19));
					uint num67 = num66 + num14;
					num61 = (int)BitUtil.LOBYTE(num58 + 2);
					uint num68 = num66 + (BitUtil.RotateRight(num64, 2) ^ BitUtil.RotateRight(num64, 0xD) ^ BitUtil.RotateRight(num64, 0x16)) + ((num64 & num56) ^ (num50 & (num64 ^ num56)));
					uint num69 = array2[(int)(num11 + 4U & 0xFU)];
					num69 += array2[num43++ & 0xF] + (array2[num61 & 0xF] >> 3 ^ BitUtil.RotateRight(array2[num61 & 0xF], 7) ^ BitUtil.RotateRight(array2[num61 & 0xF], 0x12)) + (array2[num49 + 3 & 0xF] >> 0xA ^ BitUtil.RotateRight(array2[num49 + 3 & 0xF], 0x11) ^ BitUtil.RotateRight(array2[num49 + 3 & 0xF], 0x13));
					array2[(int)(num11 + 4U & 0xFU)] = num69;
					uint num70 = num45 + num69 + HWID.SHA256Magic[(int)(num11 + 4U)] + ((num67 & num63) ^ (num55 & ~num67)) + (BitUtil.RotateRight(num67, 6) ^ BitUtil.RotateRight(num67, 0xB) ^ BitUtil.RotateRight(num67, 0x19));
					num10 = num70 + num50;
					num61 = (int)BitUtil.LOBYTE(num58 + 3);
					uint num71 = num70 + (BitUtil.RotateRight(num68, 2) ^ BitUtil.RotateRight(num68, 0xD) ^ BitUtil.RotateRight(num68, 0x16)) + ((num68 & num64) ^ (num56 & (num68 ^ num64)));
					uint num72 = array2[(int)(num11 + 5U & 0xFU)];
					num72 += array2[num43 & 0xF] + (array2[num61 & 0xF] >> 3 ^ BitUtil.RotateRight(array2[num61 & 0xF], 7) ^ BitUtil.RotateRight(array2[num61 & 0xF], 0x12)) + (array2[num49 + 4 & 0xF] >> 0xA ^ BitUtil.RotateRight(array2[num49 + 4 & 0xF], 0x11) ^ BitUtil.RotateRight(array2[num49 + 4 & 0xF], 0x13));
					array2[(int)(num11 + 5U & 0xFU)] = num72;
					uint num73 = num55 + num72 + HWID.SHA256Magic[(int)(num11 + 5U)] + ((num67 & num10) ^ (num63 & ~num10)) + (BitUtil.RotateRight(num10, 6) ^ BitUtil.RotateRight(num10, 0xB) ^ BitUtil.RotateRight(num10, 0x19));
					num9 = num73 + num56;
					num43++;
					num61 = (int)BitUtil.LOBYTE(num58 + 4);
					num7 = num73 + (BitUtil.RotateRight(num71, 2) ^ BitUtil.RotateRight(num71, 0xD) ^ BitUtil.RotateRight(num71, 0x16)) + ((num71 & num68) ^ (num64 & (num71 ^ num68)));
					uint num74 = array2[(int)(num11 + 6U & 0xFU)];
					num74 += array2[num43 & 0xF] + (array2[num61 & 0xF] >> 3 ^ BitUtil.RotateRight(array2[num61 & 0xF], 7) ^ BitUtil.RotateRight(array2[num61 & 0xF], 0x12)) + (array2[num49 + 5 & 0xF] >> 0xA ^ BitUtil.RotateRight(array2[num49 + 5 & 0xF], 0x11) ^ BitUtil.RotateRight(array2[num49 + 5 & 0xF], 0x13));
					array2[(int)(num11 + 6U & 0xFU)] = num74;
					uint num75 = num63 + num74 + HWID.SHA256Magic[(int)(num11 + 6U)] + ((num9 & num10) ^ (num67 & ~num9)) + (BitUtil.RotateRight(num9, 6) ^ BitUtil.RotateRight(num9, 0xB) ^ BitUtil.RotateRight(num9, 0x19));
					num8 = num75 + num64;
					num43++;
					int num76 = num58 + 5;
					int num77 = num76;
					int num78 = num49 + 6;
					int num79 = num78;
					num12 = num75 + (BitUtil.RotateRight(num7, 2) ^ BitUtil.RotateRight(num7, 0xD) ^ BitUtil.RotateRight(num7, 0x16)) + ((num7 & num71) ^ (num68 & (num7 ^ num71)));
					uint num80 = array2[(int)(num11 + 7U & 0xFU)];
					num80 += array2[num43 & 0xF] + (array2[num76 & 0xF] >> 3 ^ BitUtil.RotateRight(array2[num76 & 0xF], 7) ^ BitUtil.RotateRight(array2[num76 & 0xF], 0x12)) + (array2[num78 & 0xF] >> 0xA ^ BitUtil.RotateRight(array2[num78 & 0xF], 0x11) ^ BitUtil.RotateRight(array2[num78 & 0xF], 0x13));
					array2[(int)(num11 + 7U & 0xFU)] = num80;
					uint num81 = num80 + HWID.SHA256Magic[(int)(num11 + 7U)] + ((num8 & num9) ^ (num10 & ~num8)) + (BitUtil.RotateRight(num8, 6) ^ BitUtil.RotateRight(num8, 0xB) ^ BitUtil.RotateRight(num8, 0x19));
					num2 = num7;
					uint num82 = num67 + num81;
					num13 = num82 + num68;
					num5 = num71;
					num11 += 8U;
					num = num82 + (BitUtil.RotateRight(num12, 2) ^ BitUtil.RotateRight(num12, 0xD) ^ BitUtil.RotateRight(num12, 0x16)) + ((num12 & num7) ^ (num71 & (num12 ^ num7)));
					c2 = (char)(num77 + 1);
					num39 = num43 + 1;
					c = (char)(num78 + 1);
					num14 = num;
					num41 = num77 + 1;
					num40 = num79 + 1;
				}
				while (num11 < 0x40U);
			}
			uint num83 = num + num6;
			array[0] = num83;
			array[3] += num5;
			array[2] += num2;
			array[1] += num12;
			array[4] += num13;
			array[5] += num8;
			array[6] += num9;
			array[7] += num10;
			Buffer.BlockCopy(array, 0, SHA256Init, 0, array.Length * 4);
			return array2;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x000050E4 File Offset: 0x000032E4
		private static uint[] SHA256Final(ref uint[] bSHA256Init)
		{
			uint num = 0x40U - (bSHA256Init[9] & 0x3FU);
			bool flag = num <= 8U;
			if (flag)
			{
				num += 0x40U;
			}
			byte[] array = new byte[num - 8U];
			array[0] = 0x80;
			uint value = bSHA256Init[9] >> 0x1D | 8U * bSHA256Init[8];
			uint value2 = 8U * bSHA256Init[9];
			array = array.Concat(BitConverter.GetBytes(value).Reverse<byte>().ToArray<byte>()).Concat(BitConverter.GetBytes(value2).Reverse<byte>().ToArray<byte>()).ToArray<byte>();
			HWID.SHA256Update(ref bSHA256Init, array, num);
			uint[] array2 = new uint[8];
			int num2 = 0;
			do
			{
				uint num3 = BitConverter.ToUInt32(BitConverter.GetBytes(bSHA256Init[num2]).Reverse<byte>().ToArray<byte>(), 0);
				array2[num2] = num3;
				num2++;
			}
			while (num2 < 8);
			bSHA256Init[8] = 0U;
			bSHA256Init[9] = 0U;
			bSHA256Init[0] = 0x6A09E667U;
			bSHA256Init[1] = 0xBB67AE85U;
			bSHA256Init[2] = 0x3C6EF372U;
			bSHA256Init[3] = 0xA54FF53AU;
			bSHA256Init[4] = 0x510E527FU;
			bSHA256Init[5] = 0x9B05688CU;
			bSHA256Init[6] = 0x1F83D9ABU;
			bSHA256Init[7] = 0x5BE0CD19U;
			int num4 = 0x10;
			num2 = 0;
			do
			{
				bSHA256Init[0xA + num2] = 0U;
				num2++;
				num4--;
			}
			while (num4 != 0);
			return array2;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x0000523C File Offset: 0x0000343C
		// Note: this type is marked as 'beforefieldinit'.
		static HWID()
		{
		}

		// Token: 0x04000040 RID: 64
		private static byte[] signByte = new byte[]
		{
			0,
			0xE,
			1,
			2,
			3,
			4,
			0xF,
			5,
			6,
			7,
			8,
			9,
			0xA,
			0xC
		};

		// Token: 0x04000041 RID: 65
		private static uint[] SHA256Magic = new uint[]
		{
			0x428A2F98U,
			0x71374491U,
			0xB5C0FBCFU,
			0xE9B5DBA5U,
			0x3956C25BU,
			0x59F111F1U,
			0x923F82A4U,
			0xAB1C5ED5U,
			0xD807AA98U,
			0x12835B01U,
			0x243185BEU,
			0x550C7DC3U,
			0x72BE5D74U,
			0x80DEB1FEU,
			0x9BDC06A7U,
			0xC19BF174U,
			0xE49B69C1U,
			0xEFBE4786U,
			0xFC19DC6U,
			0x240CA1CCU,
			0x2DE92C6FU,
			0x4A7484AAU,
			0x5CB0A9DCU,
			0x76F988DAU,
			0x983E5152U,
			0xA831C66DU,
			0xB00327C8U,
			0xBF597FC7U,
			0xC6E00BF3U,
			0xD5A79147U,
			0x6CA6351U,
			0x14292967U,
			0x27B70A85U,
			0x2E1B2138U,
			0x4D2C6DFCU,
			0x53380D13U,
			0x650A7354U,
			0x766A0ABBU,
			0x81C2C92EU,
			0x92722C85U,
			0xA2BFE8A1U,
			0xA81A664BU,
			0xC24B8B70U,
			0xC76C51A3U,
			0xD192E819U,
			0xD6990624U,
			0xF40E3585U,
			0x106AA070U,
			0x19A4C116U,
			0x1E376C08U,
			0x2748774CU,
			0x34B0BCB5U,
			0x391C0CB3U,
			0x4ED8AA4AU,
			0x5B9CCA4FU,
			0x682E6FF3U,
			0x748F82EEU,
			0x78A5636FU,
			0x84C87814U,
			0x8CC70208U,
			0x90BEFFFAU,
			0xA4506CEBU,
			0xBEF9A3F7U,
			0xC67178F2U
		};

		// Token: 0x04000042 RID: 66
		private static uint[] MemoryMagic = new uint[]
		{
			0U,
			0x10000000U,
			0U,
			0x20000000U,
			0U,
			0x40000000U,
			0U,
			0x60000000U,
			0U,
			0x80000000U,
			0U,
			0xC0000000U,
			0U,
			0x40000000U,
			0U
		};
	}
}
