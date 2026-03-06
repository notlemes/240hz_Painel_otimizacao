using System;
using System.IO;

namespace Painel240hz.Utils
{
    public class Logger
    {
        static string logFile = "log.txt";

        public static void Log(string message)
        {
            string line = $"{DateTime.Now} - {message}";

            File.AppendAllText(logFile, line + Environment.NewLine);
        }
    }
}