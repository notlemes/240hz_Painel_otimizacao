using Painel240hz.Utils;

namespace Painel240hz.Optimizations
{
    public class RestorePointManager
    {
        public static void CreateRestorePoint()
        {
            CommandRunner.RunPowerShell(
                "Checkpoint-Computer -Description \"240HzOptimizer\" -RestorePointType \"MODIFY_SETTINGS\""
            );
        }
    }
}