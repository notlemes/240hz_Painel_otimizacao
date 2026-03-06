using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Management;

namespace Painel240hz.Optimization
{
    public static class OptimizationEngine
    {

        // ============================
        // CRIAR PONTO DE RESTAURAÇÃO
        // ============================

        public static void CreateRestorePoint()
        {
            try
            {
                ManagementClass mc = new ManagementClass("SystemRestore");

                mc.InvokeMethod(
                    "CreateRestorePoint",
                    new object[]
                    {
                        "240Hz Optimization",
                        0,
                        100
                    }
                );
            }
            catch { }
        }

        // ============================
        // DESATIVAR SERVIÇOS
        // ============================

        public static void DisableServices()
        {
            string[] services =
            {
                "DiagTrack",            // Telemetria
                "dmwappushservice",
                "SysMain",
                "WSearch",
                "Fax",
                "MapsBroker",
                "RetailDemo",
                "XblGameSave",
                "XboxNetApiSvc",
                "XboxGipSvc",
                "OneSyncSvc",
                "WMPNetworkSvc",
                "WerSvc",
                "RemoteRegistry",
                "PrintNotify",
                "BluetoothUserService",
                "DiagTrack",
                "DPS",
                "PcaSvc"
            };

            foreach (var service in services)
            {
                RunCommand($"sc stop {service}");
                RunCommand($"sc config {service} start= disabled");
            }
        }

        // ============================
        // TWEAKS DE REGISTRO
        // ============================

        public static void ApplyRegistryTweaks()
        {
            try
            {

                // DESATIVAR TELEMETRIA
                Registry.SetValue(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DataCollection",
                    "AllowTelemetry",
                    0,
                    RegistryValueKind.DWord
                );


                // DESATIVAR CORTANA
                Registry.SetValue(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Windows Search",
                    "AllowCortana",
                    0,
                    RegistryValueKind.DWord
                );


                // DESATIVAR APPS EM BACKGROUND
                Registry.SetValue(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications",
                    "GlobalUserDisabled",
                    1,
                    RegistryValueKind.DWord
                );


                // PRIORIDADE DE CPU PARA PROGRAMAS
                Registry.SetValue(
                    @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\PriorityControl",
                    "Win32PrioritySeparation",
                    38,
                    RegistryValueKind.DWord
                );


                // HAGS GPU
                Registry.SetValue(
                    @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GraphicsDrivers",
                    "HwSchMode",
                    2,
                    RegistryValueKind.DWord
                );  

            }
            catch { }
        }

        // ============================
        // EXECUTAR COMANDO CMD
        // ============================

        private static void RunCommand(string command)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c " + command,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            })?.WaitForExit();
        }

    }
}