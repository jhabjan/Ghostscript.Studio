using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Management;

namespace Ghostscript.Studio.Helpers
{
    internal class DiskHelper
    {
        [DllImport("kernel32.dll")]
        private static extern long GetVolumeInformation(
            string PathName,
            StringBuilder VolumeNameBuffer,
            UInt32 VolumeNameSize,
            ref UInt32 VolumeSerialNumber,
            ref UInt32 MaximumComponentLength,
            ref UInt32 FileSystemFlags,
            StringBuilder FileSystemNameBuffer,
            UInt32 FileSystemNameSize);

        public static string GetVolumeSerialNumber(string driveLetter)
        {
            uint serial_number = 0;
            uint max_component_length = 0;
            StringBuilder sb_volume_name = new StringBuilder(256);
            UInt32 file_system_flags = new UInt32();
            StringBuilder sb_file_system_name = new StringBuilder(256);

            if (GetVolumeInformation(driveLetter, sb_volume_name,
                (UInt32)sb_volume_name.Capacity, ref serial_number, ref max_component_length,
                ref file_system_flags, sb_file_system_name, (UInt32)sb_file_system_name.Capacity) == 0)
            {
                return string.Empty;
            }
            else
            {
                return serial_number.ToString();
            }
        }
    }
}
