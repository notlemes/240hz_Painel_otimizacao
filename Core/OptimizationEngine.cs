using Painel240hz.Optimizations;

namespace Painel240hz.Core
{
    public class OptimizationEngine
    {
        public static void RunAll()
        {
            RestorePointManager.CreateRestorePoint();

            ServiceOptimizer.DisableServices();

            RegistryOptimizer.ApplyTweaks();
        }
    }
}