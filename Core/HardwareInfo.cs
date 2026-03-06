using System;
using System.Management;

namespace Painel240hz.Core
{
    public class HardwareInfo
    {
        public static double GetRAMUsage()
        {
            double total = 0;
            double free = 0;

            var searcher = new ManagementObjectSearcher(
                "SELECT TotalVisibleMemorySize,FreePhysicalMemory FROM Win32_OperatingSystem");

            foreach (ManagementObject obj in searcher.Get())
            {
                total = Convert.ToDouble(obj["TotalVisibleMemorySize"]);
                free = Convert.ToDouble(obj["FreePhysicalMemory"]);
            }

            double used = total - free;
            double percent = (used / total) * 100;

            return Math.Round(percent, 2);
        }
    }
}