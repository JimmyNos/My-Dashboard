using CommunityToolkit.Mvvm.ComponentModel;
using My_Dashboard.Hardware_monitor;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace My_Dashboard.MVVM.ViewModel.Computer
{
    public partial class ComputerDashboardViewModel : ObservableObject
    {
        [ObservableProperty]
        private string cpuName;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(CpuLoadGauge))]
        private int cpuLoad;

        [ObservableProperty] 
        [NotifyPropertyChangedFor(nameof(CpuPowerGauge))]
        private int cpuPower;

        [ObservableProperty] 
        [NotifyPropertyChangedFor(nameof(CpuTempGauge))]
        private int cpuTemp;

        public int CpuLoadGauge => MapToGauge(CpuLoad);
        public int CpuPowerGauge => MapToPowerGauge(CpuPower);
        public int CpuTempGauge => MapToTempGauge(CpuTemp);

        [ObservableProperty]
        private string ramName;

        [ObservableProperty] 
        [NotifyPropertyChangedFor(nameof(RamLoadGauge))]
        private int ramLoad;

        [ObservableProperty] 
        [NotifyPropertyChangedFor(nameof(RamUtilizationGauge))]
        private int ramUtilization;

        [ObservableProperty] 
        [NotifyPropertyChangedFor(nameof(RamAvailableGauge))]
        private int ramAvailable;

        public int RamLoadGauge => MapToGauge(RamLoad);
        public int RamUtilizationGauge => MapToMemoryGauge(RamUtilization);
        public int RamAvailableGauge => MapToMemoryGauge(RamAvailable);

        [ObservableProperty]
        private string? gpuName;

        [ObservableProperty] 
        [NotifyPropertyChangedFor(nameof(GpuLoadGauge))]
        private int gpuLoad;

        [ObservableProperty] 
        [NotifyPropertyChangedFor(nameof(GpuPowerGauge))]
        private int gpuPower;

        [ObservableProperty] 
        [NotifyPropertyChangedFor(nameof(GpuTempGauge))]
        private int gpuTemp;

        [ObservableProperty] 
        [NotifyPropertyChangedFor(nameof(GpuHotSpotTempGauge))]
        private int gpuHotSpotTemp;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(GpuMemoryGauge))]
        private int gpuMemory;

        [ObservableProperty]
        private string gpuMemoryTotal;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(GpuFanGauge))]
        private int gpuFan;

        [ObservableProperty]
        private string gpuFanSpeed;

        public int GpuLoadGauge => MapToGauge(GpuLoad);
        public int GpuPowerGauge => MapToPowerGauge(GpuPower);
        public int GpuTempGauge => MapToTempGauge(GpuTemp);
        public int GpuHotSpotTempGauge => MapToTempGauge(GpuHotSpotTemp);
        public int GpuMemoryGauge => MapToGpuMemoryGauge(GpuMemory);
        public int GpuFanGauge => MapToGpuFanGauge(GpuFan);

        private static int MapToGauge(int? value = 0)
        {
            if (value is null)
            {
                return 0;
            }

            return (int)(value * 3 - 150);
        }

        private static int MapToPowerGauge(int? value)
        {
            if (value is null)
            {
                return 0;
            }
            return (int)((value * 2.5) - 150);
        }

        private static int MapToTempGauge(int? value)
        {
            if (value is null)
            {
                return 0;
            }
            return (int)((value * 3.3) - 150);
        }

        private static int MapToGpuMemoryGauge(int? value)
        {
            if (value is null)
            {
                return 0;
            }
            return (int)((value * 3) - 150);
        }

        private static int MapToMemoryGauge(int? value)
        {
            if (value is null)
            {
                return 0;
            }
            return (int)((value * 6.25) - 150);
        }

        private static int MapToGpuFanGauge(int? value)
        {
            if (value is null)
            {
                return 0;
            }
            return (int)((value * 3) - 150);
        }

        public HardwareMonitor? hardwareMonitor = new();

        public ComputerDashboardViewModel()
        {
            
            Task.Run(Monitor);
            //CpuLoad = Convert.ToInt32(hardwareMonitor.cpuLoad);

            
            //CpuLoad = 50;
            //Task.Run(Test);
        }

        private async Task UpdateRandomValuesAsync()
        {
            Random rand = new();
            while (true)
            {
                CpuLoad = rand.Next(0, 100);
                CpuPower = rand.Next(0, 120);
                CpuTemp = rand.Next(0, 90);

                RamLoad = rand.Next(0, 100);
                RamUtilization = rand.Next(0,48);
                RamAvailable = rand.Next(0,48);

                GpuLoad = rand.Next(0, 100);
                GpuPower = rand.Next(0, 120);
                GpuTemp = rand.Next(0, 90);
                GpuHotSpotTemp= rand.Next(0, 90);
                GpuMemory = rand.Next(0, 8);
                GpuFan = rand.Next(0, 1000);
                await Task.Delay(1300);
            }
        }

        public async Task Test()
        {
            while (true)
            {
                await Task.Delay(5000);
                CpuName += "1";
            }
        }

        public async Task Monitor()
        {
            while (true) 
            {
                try
                {
                    hardwareMonitor.computer.Open();
                    hardwareMonitor.Monitor();

                    CpuName = hardwareMonitor.cpuName;
                    RamName = Convert.ToInt32(hardwareMonitor.ramAvailable + hardwareMonitor.ramUsed).ToString() + "GB";
                    gpuName = hardwareMonitor.gpuName;
                    //MessageBox.Show(hardwareMonitor.cpuLoad);
                    CpuLoad = Convert.ToInt32(hardwareMonitor.cpuLoad);
                    CpuPower = Convert.ToInt32(hardwareMonitor.cpuPower);
                    CpuTemp = Convert.ToInt32(hardwareMonitor.cpuTemperature);

                    RamLoad = Convert.ToInt32(hardwareMonitor.ramLoad);
                    RamUtilization = Convert.ToInt32(hardwareMonitor.ramUsed);
                    RamAvailable = Convert.ToInt32(hardwareMonitor.ramAvailable);

                    GpuLoad = Convert.ToInt32(hardwareMonitor.gpuLoad);
                    GpuPower = Convert.ToInt32(hardwareMonitor.gpuPower);
                    GpuTemp = Convert.ToInt32(hardwareMonitor.gpuTemperature);
                    GpuHotSpotTemp = Convert.ToInt32(hardwareMonitor.gpuHotspotTemp);
                    GpuMemory = (int)(hardwareMonitor.gpuMemoryUsed / hardwareMonitor.gpuMemoryTotal * 100);
                    GpuMemoryTotal = $"{(int)(hardwareMonitor.gpuMemoryUsed / 1000)} / {(int)(hardwareMonitor.gpuMemoryTotal / 1000)} GB";
                    GpuFan = Convert.ToInt32(hardwareMonitor.gpuFanPer);
                    GpuFanSpeed = hardwareMonitor.gpuFanSpeed + " RPM";

                    //hardwareMonitor.ResetHardware("");

                    await Task.Delay(2000);
                    //MessageBox.Show("ran");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    break;
                }
                
            }
            
        }
    }
}
