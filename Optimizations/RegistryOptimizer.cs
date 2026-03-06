using Painel240hz.Utils;

namespace Painel240hz.Optimizations
{
    public class RegistryOptimizer
    {
        public static void ApplyTweaks()
        {
            CommandRunner.Run("reg add \"HKLM\\SYSTEM\\CurrentControlSet\\Control\\PriorityControl\" /v Win32PrioritySeparation /t REG_DWORD /d 26 /f");

            CommandRunner.Run("reg add \"HKCU\\Control Panel\\Desktop\" /v MenuShowDelay /t REG_SZ /d 0 /f");

            CommandRunner.Run("reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection\" /v AllowTelemetry /t REG_DWORD /d 0 /f");
        }
    }
}