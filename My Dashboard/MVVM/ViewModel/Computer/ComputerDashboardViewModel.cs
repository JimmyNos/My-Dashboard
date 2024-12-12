using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Threading.Tasks;

namespace My_Dashboard.MVVM.ViewModel.Computer
{
    public partial class ComputerDashboardViewModel : ObservableObject
    {
        [ObservableProperty] 
        private string cpuName = "AMD";

        [ObservableProperty] 
        private int cpuLoad = 80;

        [ObservableProperty] 
        private int cpuPower = 100;

        [ObservableProperty] 
        private int cpuTemp = 60;

        public int CpuULoadGauge => MapToGauge(CpuLoad);
        public int CpuPowerGauge => MapToGauge(CpuPower);
        public int CpuTempGauge => MapToGauge(CpuTemp);

        [ObservableProperty]
        private string ramName = "RAM";

        [ObservableProperty] 
        private int ramLoad = 60;

        [ObservableProperty] 
        private int ramUtilization = 32;

        [ObservableProperty] 
        private int ramAvailable = 16;

        public int RamLoadGauge => MapToGauge(RamLoad);
        public int RamUtilizationGauge => MapToGauge(RamUtilization);
        public int RamAvailableGauge => MapToGauge(RamAvailable);


        [ObservableProperty]
        private string gpuName = "GPU";

        [ObservableProperty] 
        private int gpuLoad = 50;

        [ObservableProperty] 
        private int gpuPower = 150;

        [ObservableProperty] 
        private int gpuTemp = 70;
        
        [ObservableProperty] 
        private int gpuHotSpotTemp = 70;

        [ObservableProperty]
        private int gpuMemory = 70;

        [ObservableProperty]
        private int gpuFan = 70;

        public int GpuLoadGauge => MapToGauge(GpuLoad);
        public int GpuPowerGauge => MapToGauge(GpuPower);
        public int GpuTempGauge => MapToGauge(GpuTemp);
        public int GpuHotSpotTempGauge => MapToGauge(GpuHotSpotTemp);
        public int GpuMemoryGauge => MapToGauge(GpuMemory);
        public int GpuFanGauge => MapToGauge(GpuFan);

        private int MapToGauge(int value) => (int)((value * 100) / 100); // Adjust to scale

        public ComputerDashboardViewModel()
        {
            Task.Run(UpdateRandomValuesAsync);
        }

        private async Task UpdateRandomValuesAsync()
        {
            Random rand = new();
            while (true)
            {
                CpuLoad = rand.Next(0, 101);
                CpuPower = rand.Next(50, 150);
                CpuTemp = rand.Next(40, 90);
                await Task.Delay(3000);
            }
        }
    }
}
