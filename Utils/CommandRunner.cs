using System.Diagnostics;

namespace Painel240hz.Utils
{
    public class CommandRunner
    {
        public static void Run(string command)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "cmd.exe";
            psi.Arguments = "/c " + command;
            psi.Verb = "runas";
            psi.CreateNoWindow = true;
            psi.UseShellExecute = true;

            Process.Start(psi);
        }

        public static void RunPowerShell(string command)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "powershell.exe";
            psi.Arguments = "-ExecutionPolicy Bypass -Command " + command;
            psi.Verb = "runas";
            psi.CreateNoWindow = true;
            psi.UseShellExecute = true;

            Process.Start(psi);
        }
    }
}