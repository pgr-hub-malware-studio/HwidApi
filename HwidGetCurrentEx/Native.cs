using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace HwidGetCurrentEx
{
	// Token: 0x02000007 RID: 7
	public static class Native
	{
		// Token: 0x06000021 RID: 33
		[DllImport("setupapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern bool SetupDiGetDriverInfoDetail(IntPtr DeviceInfoSet, ref Native.SP_DEVINFO_DATA DeviceInfoData, ref Native.SP_DRVINFO_DATA DriverInfoData, ref Native.SP_DRVINFO_DETAIL_DATA DriverInfoDetailData, int DriverInfoDetailDataSize, ref int RequiredSize);

		// Token: 0x06000022 RID: 34
		[DllImport("setupapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern bool SetupDiEnumDriverInfo(IntPtr DeviceInfoSet, ref Native.SP_DEVINFO_DATA DeviceInfoData, int DriverType, int MemberIndex, ref Native.SP_DRVINFO_DATA DriverInfoData);

		// Token: 0x06000023 RID: 35
		[DllImport("setupapi.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SetupDiGetClassDevs(ref Guid ClassGuid, [MarshalAs(UnmanagedType.LPTStr)] string Enumerator, IntPtr hwndParent, uint Flags);

		// Token: 0x06000024 RID: 36
		[DllImport("setupapi.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SetupDiGetClassDevs(ref Guid ClassGuid, IntPtr Enumerator, IntPtr hwndParent, int Flags);

		// Token: 0x06000025 RID: 37
		[DllImport("setupapi.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SetupDiGetClassDevs(IntPtr ClassGuid, [MarshalAs(UnmanagedType.LPTStr)] string Enumerator, IntPtr hwndParent, int Flags);

		// Token: 0x06000026 RID: 38
		[DllImport("setupapi.dll", SetLastError = true)]
		public static extern IntPtr SetupDiGetClassDevsW([In] ref Guid ClassGuid, [MarshalAs(UnmanagedType.LPWStr)] string Enumerator, IntPtr parent, int flags);

		// Token: 0x06000027 RID: 39
		[DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool SetupDiEnumDeviceInterfaces(IntPtr hDevInfo, IntPtr devInfo, ref Guid interfaceClassGuid, uint memberIndex, ref Native.SP_DEVICE_INTERFACE_DATA deviceInterfaceData);

		// Token: 0x06000028 RID: 40
		[DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool SetupDiGetDeviceInterfaceDetailW(IntPtr hDevInfo, ref Native.SP_DEVICE_INTERFACE_DATA deviceInterfaceData, ref Native.SP_DEVICE_INTERFACE_DETAIL_DATA deviceInterfaceDetailData, uint deviceInterfaceDetailDataSize, out uint requiredSize, ref Native.SP_DEVINFO_DATA deviceInfoData);

		// Token: 0x06000029 RID: 41
		[DllImport("setupapi.dll", CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
		public static extern bool SetupDiGetDeviceInterfaceDetailW(IntPtr hDevInfo, ref Native.SP_DEVICE_INTERFACE_DATA deviceInterfaceData, IntPtr deviceInterfaceDetailData, uint deviceInterfaceDetailDataSize, out uint requiredSize, IntPtr deviceInfoData);

		// Token: 0x0600002A RID: 42
		[DllImport("setupapi.dll", SetLastError = true)]
		public static extern bool SetupDiDestroyDeviceInfoList(IntPtr DeviceInfoSet);

		// Token: 0x0600002B RID: 43
		[DllImport("setupapi.dll", SetLastError = true)]
		public static extern bool SetupDiEnumDeviceInfo(IntPtr DeviceInfoSet, uint MemberIndex, ref Native.SP_DEVINFO_DATA DeviceInfoData);

		// Token: 0x0600002C RID: 44
		[DllImport("setupapi.dll")]
		public static extern int CM_Get_Parent(ref IntPtr pdnDevInst, IntPtr dnDevInst, int ulFlags);

		// Token: 0x0600002D RID: 45
		[DllImport("kernel32.dll")]
		public static extern uint GetLastError();

		// Token: 0x0600002E RID: 46
		[DllImport("cfgmgr32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern int CM_Get_DevNode_Registry_PropertyW(IntPtr dnDevInst, int ulProperty, ref int pulRegDataType, IntPtr Buffer, ref int pulLength, int ulFlags);

		// Token: 0x0600002F RID: 47
		[DllImport("cfgmgr32.dll", CharSet = CharSet.Ansi, EntryPoint = "CM_Get_DevNode_Registry_PropertyA", ExactSpelling = true, SetLastError = true)]
		public static extern int CM_Get_DevNode_Registry_Property(IntPtr dnDevInst, int ulProperty, ref int pulRegDataType, ref IntPtr Buffer, ref int pulLength, int ulFlags);

		// Token: 0x06000030 RID: 48
		[DllImport("cfgmgr32.dll", SetLastError = true)]
		public static extern int CM_Get_DevNode_Status(ref int status, ref int probNum, IntPtr devInst, int flags);

		// Token: 0x06000031 RID: 49
		[DllImport("setupapi.dll", SetLastError = true)]
		public static extern int CM_Get_Device_ID(IntPtr pdnDevInst, ref IntPtr buffer, int bufferLen, int flags);

		// Token: 0x06000032 RID: 50
		[DllImport("setupapi.dll", SetLastError = true)]
		public static extern int CM_Get_Device_IDW(IntPtr pdnDevInst, IntPtr Buffer, uint bufferLen, uint flags);

		// Token: 0x06000033 RID: 51
		[DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool SetupDiGetDeviceRegistryProperty(IntPtr deviceInfoSet, ref Native.SP_DEVINFO_DATA deviceInfoData, uint property, int propertyRegDataType, IntPtr propertyBuffer, uint propertyBufferSize, ref int requiredSize);

		// Token: 0x06000034 RID: 52
		[DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool SetupDiGetDeviceRegistryPropertyW(IntPtr deviceInfoSet, ref Native.SP_DEVINFO_DATA deviceInfoData, int property, int propertyRegDataType, byte[] propertyBuffer, int propertyBufferSize, out int requiredSize);

		// Token: 0x06000035 RID: 53
		[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr memcpy(IntPtr dest, IntPtr src, UIntPtr count);

		// Token: 0x06000036 RID: 54
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, uint lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, uint hTemplateFile);

		// Token: 0x06000037 RID: 55
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr CreateFileW(string filename, uint dwDesiredAccess, uint dwShareMode, uint lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, uint hTemplateFile);

		// Token: 0x06000038 RID: 56
		[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern bool CloseHandle(IntPtr hObject);

		// Token: 0x06000039 RID: 57
		[DllImport("hid.dll", ExactSpelling = true)]
		public static extern bool HidD_GetAttributes(IntPtr HidDeviceObject, ref Native.HidD_Attributes Attributes);

		// Token: 0x0600003A RID: 58
		[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern bool DeviceIoControl(IntPtr hDevice, uint dwIoControlCode, IntPtr lpInBuffer, int nInBufferSize, IntPtr lpOutBuffer, int nOutBufferSize, out uint lpBytesReturned, IntPtr lpOverlapped);

		// Token: 0x0600003B RID: 59
		[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern bool DeviceIoControl(IntPtr hDevice, uint dwIoControlCode, ref uint lpInBuffer, int nInBufferSize, IntPtr lpOutBuffer, int nOutBufferSize, out uint lpBytesReturned, IntPtr lpOverlapped);

		// Token: 0x0600003C RID: 60
		[DllImport("advapi32.dll", SetLastError = true)]
		public static extern bool GetCurrentHwProfile(IntPtr fProfile);

		// Token: 0x0600003D RID: 61
		[DllImport("kernel32")]
		public static extern bool GlobalMemoryStatusEx(ref Native.MEMORYSTATUSEX stat);

		// Token: 0x0600003E RID: 62
		[DllImport("kernel32.dll")]
		public static extern uint GetSystemFirmwareTable(uint FirmwareTableProviderSignature, uint FirmwareTableID, IntPtr pFirmwareTableBuffer, uint BufferSize);

		// Token: 0x0600003F RID: 63
		[DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPStr)] string lpFileName);

		// Token: 0x06000040 RID: 64
		[DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

		// Token: 0x06000041 RID: 65
		[DllImport("wwapi.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int WwanOpenHandle(int dwClientVersion, IntPtr pReserved, out int pdwNegotiatedVersion, out IntPtr phClientHandle);

		// Token: 0x06000042 RID: 66
		[DllImport("wwapi.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int WwanCloseHandle(IntPtr hClientHandle, IntPtr pReserved);

		// Token: 0x06000043 RID: 67
		[DllImport("wwapi.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int WwanEnumerateInterfaces(IntPtr hClientHandle, int pdwReserved, out Native.WWAN_INTERFACE_INFO_LIST ppInterfaceList);

		// Token: 0x06000044 RID: 68
		[DllImport("wwapi.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int WwanFreeMemory(IntPtr pMem);

		// Token: 0x06000045 RID: 69
		[DllImport("wwapi.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int WwanSetInterface(IntPtr hClientHandle, Guid pInterfaceGuid, int OpCode, int dwDataSize, IntPtr pData, IntPtr pReserved1, IntPtr pReserved2, IntPtr pReserved3);

		// Token: 0x06000046 RID: 70
		[DllImport("wwapi.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int WlanQueryInterface(IntPtr hClientHandle, Guid pInterfaceGuid, int OpCode, IntPtr pReserved, out int pdwDataSize, out IntPtr ppData, out int pWlanOpcodeValueType);

		// Token: 0x06000047 RID: 71
		[DllImport("rpcrt4.dll", SetLastError = true)]
		public static extern int UuidCreateSequential(out Guid guid);

		// Token: 0x04000017 RID: 23
		public const int ERROR_INVALID_HANDLE_VALUE = -1;

		// Token: 0x04000018 RID: 24
		public const uint GENERIC_READ = 0x80000000U;

		// Token: 0x04000019 RID: 25
		public const uint GENERIC_WRITE = 0x40000000U;

		// Token: 0x0400001A RID: 26
		public const uint FILE_SHARE_READ = 1U;

		// Token: 0x0400001B RID: 27
		public const uint FILE_SHARE_WRITE = 2U;

		// Token: 0x0400001C RID: 28
		public const uint OPEN_EXISTING = 3U;

		// Token: 0x0400001D RID: 29
		public const uint IOCTL_VOLUME_GET_VOLUME_DISK_EXTENTS = 0x560000U;

		// Token: 0x0400001E RID: 30
		public const uint IOCTL_STORAGE_QUERY_PROPERTY = 0x2D1400U;

		// Token: 0x0400001F RID: 31
		public const uint IOCTL_BTH_GET_LOCAL_INFO = 0x410000U;

		// Token: 0x04000020 RID: 32
		public const uint IOCTL_NDIS_QUERY_GLOBAL_STATS = 0x170002U;

		// Token: 0x04000021 RID: 33
		public const uint PERMANENT_ADDRESS = 0x1010101U;

		// Token: 0x04000022 RID: 34
		public const uint RSMB = 0x52534D42U;

		// Token: 0x0200001B RID: 27
		public enum DI_FUNCTION
		{
			// Token: 0x04000064 RID: 100
			DIF_SELECTDEVICE = 1,
			// Token: 0x04000065 RID: 101
			DIF_INSTALLDEVICE,
			// Token: 0x04000066 RID: 102
			DIF_ASSIGNRESOURCES,
			// Token: 0x04000067 RID: 103
			DIF_PROPERTIES,
			// Token: 0x04000068 RID: 104
			DIF_REMOVE,
			// Token: 0x04000069 RID: 105
			DIF_FIRSTTIMESETUP,
			// Token: 0x0400006A RID: 106
			DIF_FOUNDDEVICE,
			// Token: 0x0400006B RID: 107
			DIF_SELECTCLASSDRIVERS,
			// Token: 0x0400006C RID: 108
			DIF_VALIDATECLASSDRIVERS,
			// Token: 0x0400006D RID: 109
			DIF_INSTALLCLASSDRIVERS,
			// Token: 0x0400006E RID: 110
			DIF_CALCDISKSPACE,
			// Token: 0x0400006F RID: 111
			DIF_DESTROYPRIVATEDATA,
			// Token: 0x04000070 RID: 112
			DIF_VALIDATEDRIVER,
			// Token: 0x04000071 RID: 113
			DIF_MOVEDEVICE,
			// Token: 0x04000072 RID: 114
			DIF_DETECT,
			// Token: 0x04000073 RID: 115
			DIF_INSTALLWIZARD,
			// Token: 0x04000074 RID: 116
			DIF_DESTROYWIZARDDATA,
			// Token: 0x04000075 RID: 117
			DIF_PROPERTYCHANGE,
			// Token: 0x04000076 RID: 118
			DIF_ENABLECLASS,
			// Token: 0x04000077 RID: 119
			DIF_DETECTVERIFY,
			// Token: 0x04000078 RID: 120
			DIF_INSTALLDEVICEFILES,
			// Token: 0x04000079 RID: 121
			DIF_UNREMOVE,
			// Token: 0x0400007A RID: 122
			DIF_SELECTBESTCOMPATDRV,
			// Token: 0x0400007B RID: 123
			DIF_ALLOW_INSTALL,
			// Token: 0x0400007C RID: 124
			DIF_REGISTERDEVICE,
			// Token: 0x0400007D RID: 125
			DIF_NEWDEVICEWIZARD_PRESELECT,
			// Token: 0x0400007E RID: 126
			DIF_NEWDEVICEWIZARD_SELECT,
			// Token: 0x0400007F RID: 127
			DIF_NEWDEVICEWIZARD_PREANALYZE,
			// Token: 0x04000080 RID: 128
			DIF_NEWDEVICEWIZARD_POSTANALYZE,
			// Token: 0x04000081 RID: 129
			DIF_NEWDEVICEWIZARD_FINISHINSTALL,
			// Token: 0x04000082 RID: 130
			DIF_UNUSED1,
			// Token: 0x04000083 RID: 131
			DIF_INSTALLINTERFACES,
			// Token: 0x04000084 RID: 132
			DIF_DETECTCANCEL,
			// Token: 0x04000085 RID: 133
			DIF_REGISTER_COINSTALLERS,
			// Token: 0x04000086 RID: 134
			DIF_ADDPROPERTYPAGE_ADVANCED,
			// Token: 0x04000087 RID: 135
			DIF_ADDPROPERTYPAGE_BASIC,
			// Token: 0x04000088 RID: 136
			DIF_RESERVED1,
			// Token: 0x04000089 RID: 137
			DIF_TROUBLESHOOTER,
			// Token: 0x0400008A RID: 138
			DIF_POWERMESSAGEWAKE,
			// Token: 0x0400008B RID: 139
			DIF_ADDREMOTEPROPERTYPAGE_ADVANCED,
			// Token: 0x0400008C RID: 140
			DIF_UPDATEDRIVER_UI,
			// Token: 0x0400008D RID: 141
			DIF_RESERVED2 = 0x30
		}

		// Token: 0x0200001C RID: 28
		public struct MEMORYSTATUSEX
		{
			// Token: 0x0400008E RID: 142
			public uint dwLength;

			// Token: 0x0400008F RID: 143
			public uint dwMemoryLoad;

			// Token: 0x04000090 RID: 144
			public ulong ullTotalPhys;

			// Token: 0x04000091 RID: 145
			public ulong ullAvailPhys;

			// Token: 0x04000092 RID: 146
			public ulong ullTotalPageFile;

			// Token: 0x04000093 RID: 147
			public ulong ullAvailPageFile;

			// Token: 0x04000094 RID: 148
			public ulong ullTotalVirtual;

			// Token: 0x04000095 RID: 149
			public ulong ullAvailVirtual;

			// Token: 0x04000096 RID: 150
			public ulong ullAvailExtendedVirtual;
		}

		// Token: 0x0200001D RID: 29
		[StructLayout(LayoutKind.Sequential)]
		public class HWProfile
		{
			// Token: 0x06000086 RID: 134 RVA: 0x0000550F File Offset: 0x0000370F
			public HWProfile()
			{
			}

			// Token: 0x04000097 RID: 151
			public int dwDockInfo;

			// Token: 0x04000098 RID: 152
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x27)]
			public string szHwProfileGuid;

			// Token: 0x04000099 RID: 153
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x50)]
			public string szHwProfileName;
		}

		// Token: 0x0200001E RID: 30
		[StructLayout(LayoutKind.Sequential)]
		public class DISK_EXTENT
		{
			// Token: 0x06000087 RID: 135 RVA: 0x00005518 File Offset: 0x00003718
			public DISK_EXTENT()
			{
			}

			// Token: 0x0400009A RID: 154
			public uint DiskNumber;

			// Token: 0x0400009B RID: 155
			public long StartingOffset;

			// Token: 0x0400009C RID: 156
			public long ExtentLength;
		}

		// Token: 0x0200001F RID: 31
		[StructLayout(LayoutKind.Sequential)]
		public class VOLUME_DISK_EXTENTS
		{
			// Token: 0x06000088 RID: 136 RVA: 0x00005521 File Offset: 0x00003721
			public VOLUME_DISK_EXTENTS()
			{
			}

			// Token: 0x0400009D RID: 157
			public uint NumberOfDiskExtents;

			// Token: 0x0400009E RID: 158
			public Native.DISK_EXTENT Extents;
		}

		// Token: 0x02000020 RID: 32
		public struct DEVICE_SEEK_PENALTY_DESCRIPTOR
		{
			// Token: 0x0400009F RID: 159
			public readonly uint Version;

			// Token: 0x040000A0 RID: 160
			public readonly uint Size;

			// Token: 0x040000A1 RID: 161
			[MarshalAs(UnmanagedType.U1)]
			public readonly bool IncursSeekPenalty;
		}

		// Token: 0x02000021 RID: 33
		public struct STORAGE_DESCRIPTOR_HEADER
		{
			// Token: 0x040000A2 RID: 162
			public uint Version;

			// Token: 0x040000A3 RID: 163
			public uint Size;
		}

		// Token: 0x02000022 RID: 34
		public struct STORAGE_DEVICE_DESCRIPTOR
		{
			// Token: 0x040000A4 RID: 164
			public uint Version;

			// Token: 0x040000A5 RID: 165
			public uint Size;

			// Token: 0x040000A6 RID: 166
			public byte DeviceType;

			// Token: 0x040000A7 RID: 167
			public byte DeviceTypeModifier;

			// Token: 0x040000A8 RID: 168
			public byte RemovableMedia;

			// Token: 0x040000A9 RID: 169
			public byte CommandQueueing;

			// Token: 0x040000AA RID: 170
			public uint VendorIdOffset;

			// Token: 0x040000AB RID: 171
			public uint ProductIdOffset;

			// Token: 0x040000AC RID: 172
			public uint ProductRevisionOffset;

			// Token: 0x040000AD RID: 173
			public uint SerialNumberOffset;

			// Token: 0x040000AE RID: 174
			public byte BusType;

			// Token: 0x040000AF RID: 175
			public uint RawPropertiesLength;

			// Token: 0x040000B0 RID: 176
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public byte[] RawDeviceProperties;
		}

		// Token: 0x02000023 RID: 35
		public enum WWAN_INTERFACE_STATE
		{
			// Token: 0x040000B2 RID: 178
			WwanInterfaceStateNotReady,
			// Token: 0x040000B3 RID: 179
			WwanInterfaceStateDeviceLocked,
			// Token: 0x040000B4 RID: 180
			WwanInterfaceStateUserAccountNotActivated,
			// Token: 0x040000B5 RID: 181
			WwanInterfaceStateRegistered,
			// Token: 0x040000B6 RID: 182
			WwanInterfaceStateRegistering,
			// Token: 0x040000B7 RID: 183
			WwanInterfaceStateDeregistered,
			// Token: 0x040000B8 RID: 184
			WwanInterfaceStateAttached,
			// Token: 0x040000B9 RID: 185
			WwanInterfaceStateAttaching,
			// Token: 0x040000BA RID: 186
			WwanInterfaceStateDetaching,
			// Token: 0x040000BB RID: 187
			WwanInterfaceStateActivated,
			// Token: 0x040000BC RID: 188
			WwanInterfaceStateActivating,
			// Token: 0x040000BD RID: 189
			WwanInterfaceStateDeactivating
		}

		// Token: 0x02000024 RID: 36
		public struct WWAN_INTERFACE_STATUS
		{
			// Token: 0x040000BE RID: 190
			private bool fInitialized;

			// Token: 0x040000BF RID: 191
			private Native.WWAN_INTERFACE_STATE InterfaceState;
		}

		// Token: 0x02000025 RID: 37
		public struct WWAN_INTERFACE_INFO
		{
			// Token: 0x040000C0 RID: 192
			public Guid InterfaceGuid;

			// Token: 0x040000C1 RID: 193
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x100)]
			public byte[] strInterfaceDescription;

			// Token: 0x040000C2 RID: 194
			public Native.WWAN_INTERFACE_STATUS InterfaceStatus;

			// Token: 0x040000C3 RID: 195
			public int dwReserved1;

			// Token: 0x040000C4 RID: 196
			public Guid guidReserved;

			// Token: 0x040000C5 RID: 197
			public Guid ParentInterfaceGuid;

			// Token: 0x040000C6 RID: 198
			public int dwReserved2;

			// Token: 0x040000C7 RID: 199
			public int dwIndex;

			// Token: 0x040000C8 RID: 200
			public int dwReserved3;

			// Token: 0x040000C9 RID: 201
			public int dwReserved4;
		}

		// Token: 0x02000026 RID: 38
		public struct WWAN_INTERFACE_INFO_LIST
		{
			// Token: 0x040000CA RID: 202
			public int dwNumberOfItems;

			// Token: 0x040000CB RID: 203
			public Native.WWAN_INTERFACE_INFO[] InterfaceInfo;
		}

		// Token: 0x02000027 RID: 39
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 2)]
		public struct SP_DRVINFO_DATA
		{
			// Token: 0x040000CC RID: 204
			public int cbSize;

			// Token: 0x040000CD RID: 205
			public uint DriverType;

			// Token: 0x040000CE RID: 206
			public UIntPtr Reserved;

			// Token: 0x040000CF RID: 207
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x100)]
			public string Description;

			// Token: 0x040000D0 RID: 208
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x100)]
			public string MfgName;

			// Token: 0x040000D1 RID: 209
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x100)]
			public string ProviderName;

			// Token: 0x040000D2 RID: 210
			public System.Runtime.InteropServices.ComTypes.FILETIME DriverDate;

			// Token: 0x040000D3 RID: 211
			public ulong DriverVersion;
		}

		// Token: 0x02000028 RID: 40
		public struct STORAGE_PROPERTY_QUERY
		{
			// Token: 0x040000D4 RID: 212
			public int PropertyId;

			// Token: 0x040000D5 RID: 213
			public int QueryType;

			// Token: 0x040000D6 RID: 214
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public byte[] AdditionalParameters;
		}

		// Token: 0x02000029 RID: 41
		public struct HidD_Attributes
		{
			// Token: 0x040000D7 RID: 215
			public int Size;

			// Token: 0x040000D8 RID: 216
			public ushort VendorID;

			// Token: 0x040000D9 RID: 217
			public ushort ProductID;

			// Token: 0x040000DA RID: 218
			public ushort VersionNumber;
		}

		// Token: 0x0200002A RID: 42
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 2)]
		public struct SP_DRVINFO_DETAIL_DATA
		{
			// Token: 0x040000DB RID: 219
			public int cbSize;

			// Token: 0x040000DC RID: 220
			public System.Runtime.InteropServices.ComTypes.FILETIME InfDate;

			// Token: 0x040000DD RID: 221
			public int CompatIDsOffset;

			// Token: 0x040000DE RID: 222
			public int CompatIDsLength;

			// Token: 0x040000DF RID: 223
			public IntPtr Reserved;

			// Token: 0x040000E0 RID: 224
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x100)]
			public string SectionName;

			// Token: 0x040000E1 RID: 225
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x104)]
			public string InfFileName;

			// Token: 0x040000E2 RID: 226
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x100)]
			public string DrvDescription;

			// Token: 0x040000E3 RID: 227
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
			public string HardwareID;
		}

		// Token: 0x0200002B RID: 43
		[Flags]
		public enum DiGetClassFlags : uint
		{
			// Token: 0x040000E5 RID: 229
			DIGCF_DEFAULT = 1U,
			// Token: 0x040000E6 RID: 230
			DIGCF_PRESENT = 2U,
			// Token: 0x040000E7 RID: 231
			DIGCF_ALLCLASSES = 4U,
			// Token: 0x040000E8 RID: 232
			SPDRP_UNUSED2 = 6U,
			// Token: 0x040000E9 RID: 233
			DIGCF_PROFILE = 8U,
			// Token: 0x040000EA RID: 234
			DIGCF_DEVICEINTERFACE = 0x10U
		}

		// Token: 0x0200002C RID: 44
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SP_DEVICE_INTERFACE_DATA
		{
			// Token: 0x040000EB RID: 235
			public uint cbSize;

			// Token: 0x040000EC RID: 236
			public Guid InterfaceClassGuid;

			// Token: 0x040000ED RID: 237
			public uint Flags;

			// Token: 0x040000EE RID: 238
			public IntPtr Reserved;
		}

		// Token: 0x0200002D RID: 45
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SP_DEVINFO_DATA
		{
			// Token: 0x040000EF RID: 239
			public uint cbSize;

			// Token: 0x040000F0 RID: 240
			public Guid ClassGuid;

			// Token: 0x040000F1 RID: 241
			public uint DevInst;

			// Token: 0x040000F2 RID: 242
			public IntPtr Reserved;
		}

		// Token: 0x0200002E RID: 46
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 1)]
		public struct NativeDeviceInterfaceDetailData
		{
			// Token: 0x040000F3 RID: 243
			public int size;

			// Token: 0x040000F4 RID: 244
			public char devicePath;
		}

		// Token: 0x0200002F RID: 47
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SP_DEVICE_INTERFACE_DETAIL_DATA
		{
			// Token: 0x040000F5 RID: 245
			public int cbSize;

			// Token: 0x040000F6 RID: 246
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x200)]
			public string DevicePath;
		}
	}
}
