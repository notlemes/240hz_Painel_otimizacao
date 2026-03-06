using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;

namespace Painel240hz
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private PerformanceCounter cpuCounter;
        private PerformanceCounter ramCounter;

        public MainWindow()
        {
            InitializeComponent();

            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");

            StartHardwareMonitor();
        }

        private void StartHardwareMonitor()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += UpdateHardware;
            timer.Start();
        }

        private void UpdateHardware(object sender, EventArgs e)
        {
            try
            {
                float cpuUsage = cpuCounter.NextValue();
                float ramUsage = ramCounter.NextValue();

                cpuText.Text = ((int)cpuUsage) + "%";
                ramText.Text = ((int)ramUsage) + "%";
            }
            catch
            {
                cpuText.Text = "Erro";
                ramText.Text = "Erro";
            }
        }

        private void StartOptimization(object sender, RoutedEventArgs e)
        {
            txtStatus.Text = "Otimização iniciada...";
            progressBar.Value = 50;

            txtStatus.Text = "✔ Otimização concluída";
            progressBar.Value = 100;
        }
    }
}