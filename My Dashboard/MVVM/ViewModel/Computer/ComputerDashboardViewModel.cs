using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Threading.Tasks;

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


        //// Example properties for HardwareLabel bindings
        //[ObservableProperty]
        //private string statName = "Load";

        //[ObservableProperty]
        //private int statGauge = 50; // or any dynamic value

        //[ObservableProperty]
        //private int statValue = 20;

        //[ObservableProperty]
        //private string statSymbol = "%";


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
        private string gpuName;

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
        [NotifyPropertyChangedFor(nameof(GpuFanGauge))]
        private int gpuFan;

        public int GpuLoadGauge => MapToGauge(GpuLoad);
        public int GpuPowerGauge => MapToPowerGauge(GpuPower);
        public int GpuTempGauge => MapToTempGauge(GpuTemp);
        public int GpuHotSpotTempGauge => MapToTempGauge(GpuHotSpotTemp);
        public int GpuMemoryGauge => MapToGpuMemoryGauge(GpuMemory);
        public int GpuFanGauge => MapToGpuFanGauge(GpuFan);

        private static int MapToGauge(int value) => (int)((value * 3) - 150);
        private static int MapToPowerGauge(int value) => (int)((value * 2.5) - 150);
        private static int MapToTempGauge(int value) => (int)((value * 3.3) - 150);
        private static int MapToGpuMemoryGauge(int value) => (int)((value * 37.5) - 150);
        private static int MapToMemoryGauge(int value) => (int)((value * 6.25) - 150);
        private static int MapToGpuFanGauge(int value) => (int)((value * 0.3) - 150);

        public ComputerDashboardViewModel()
        {
            CpuName = "AMD";
            RamName = "RAM";
            gpuName = "GPU";
            //CpuLoad = 50;
            Task.Run(UpdateRandomValuesAsync);
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
    }
}
