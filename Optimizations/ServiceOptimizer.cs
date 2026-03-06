using Painel240hz.Utils;

namespace Painel240hz.Optimizations
{
    public class ServiceOptimizer
    {
        public static void DisableServices()
        {
            string[] services =
            {
                "DiagTrack",
                "dmwappushservice",
                "MapsBroker",
                "WSearch",
                "Fax",
                "XblGameSave",
                "XboxNetApiSvc",
                "XboxGipSvc",
                "RemoteRegistry",
                "RetailDemo",
                "SharedAccess",
                "TrkWks",
                "WMPNetworkSvc",
                "WpcMonSvc",
                "lfsvc",
                "PcaSvc",
                "WerSvc"
            };

            foreach (string service in services)
            {
                CommandRunner.Run($"sc stop {service}");
                CommandRunner.Run($"sc config {service} start= disabled");
            }
        }
    }
}