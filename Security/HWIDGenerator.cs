using System.Management;

namespace Painel240hz.Security
{
    public class HWIDGenerator
    {
        public static string GetHWID()
        {
            var searcher = new ManagementObjectSearcher("select * from Win32_Processor");

            foreach (var item in searcher.Get())
                return item["ProcessorId"].ToString();

            return "UNKNOWN";
        }
    }
}