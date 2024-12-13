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
        public int CpuPowerGauge => MapToGauge(CpuPower);
        public int CpuTempGauge => MapToGauge(CpuTemp);


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
        public int RamUtilizationGauge => MapToGauge(RamUtilization);
        public int RamAvailableGauge => MapToGauge(RamAvailable);


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
        public int GpuPowerGauge => MapToGauge(GpuPower);
        public int GpuTempGauge => MapToGauge(GpuTemp);
        public int GpuHotSpotTempGauge => MapToGauge(GpuHotSpotTemp);
        public int GpuMemoryGauge => MapToGauge(GpuMemory);
        public int GpuFanGauge => MapToGauge(GpuFan);

        private int MapToGauge(int value)
        {
            return (int)((value * 2.5) - 150);
        }


        public ComputerDashboardViewModel()
        {
            CpuName = "AMD";
            RamName = "RAM";
            gpuName = "GPU";
            //CpuLoad = 50;
            //Task.Run(UpdateRandomValuesAsync);
            //Task.Run(test);
        }

        private async Task UpdateRandomValuesAsync()
        {
            Random rand = new();
            while (true)
            {
                CpuLoad = rand.Next(0, 120);
                CpuPower = rand.Next(0, 120);
                CpuTemp = rand.Next(0, 90);
                RamLoad = rand.Next(0, 100);
                await Task.Delay(3000);
            }
        }

        public async Task test()
        {
            while (true)
            {
                await Task.Delay(5000);
                CpuName += "1";
            }
        }
    }
}
