using LibreHardwareMonitor.Hardware;


public class UpdateVisitor : IVisitor
{
    public void VisitComputer(IComputer computer)
    {
        computer.Traverse(this);
    }
    public void VisitHardware(IHardware hardware)
    {
        hardware.Update();
        foreach (IHardware subHardware in hardware.SubHardware) subHardware.Accept(this);
    }
    public void VisitSensor(ISensor sensor) { }
    public void VisitParameter(IParameter parameter) { }
}

namespace My_Dashboard.Hardware_monitor
{
    public class HardwareMonitor
    {
        public string? cpuStats;
        public string? gpuStats;
        public string? ramStats;
        public string? motherboardStats;
        public string? storage;

        public string? cpuName;
        public float? cpuLoad;
        public float? cpuPower;
        public float? cpuClocks;
        public float? cpuTemperature;

        public string? gpuName;
        public float? gpuLoad;
        public float? gpuPower;
        public float? gpuClock;
        public float? gpuTemperature;
        public float? gpuHotspotTemp;
        public float? gpuMemoryUsed;
        public float? gpuMemoryTotal;
        public float? gpuMemoryFree;
        public float? gpuFanSpeed;
        public float? gpuFanPer;

        public float? ramLoad;
        public float? ramUsed;
        public float? ramAvailable;

        public string? motherboardSub;
        public float? motherboardTemps;
        public float? motherboardFanSpeed;

        public string hardwareStats = "";

        public void ResetHardware(string reset)
        {
            cpuName = reset;
            cpuLoad = 0;
            cpuPower = 0;
            cpuClocks = 0;
            cpuTemperature = 0;

            gpuName = reset;
            gpuLoad = 0;
            gpuPower = 0;
            gpuClock = 0;
            gpuTemperature = 0;
            //gpuMemory = 0;
            gpuFanSpeed = 0;
            gpuFanPer = 0;

            ramLoad = 0;
            ramUsed = 0;
            ramAvailable = 0;

            motherboardSub = reset;
            motherboardTemps = 0;
            motherboardFanSpeed = 0;
        }

        public readonly Computer computer = new()
        {
            IsCpuEnabled = true,
            IsGpuEnabled = true,
            IsMemoryEnabled = true,
            IsMotherboardEnabled = true,
            IsControllerEnabled = false,
            IsNetworkEnabled = false,
            IsStorageEnabled = false
        };

        public void Monitor()
        {
            //computer.Open();
            computer.Accept(new UpdateVisitor());
            cpuStats = "CPU:";
            gpuStats = "GPU:";
            ramStats = "RAM:";
            motherboardStats = "Motherboard:";

            //CPU
            foreach (IHardware hardware in computer.Hardware)
            {
                if (hardware.HardwareType == HardwareType.Cpu)
                {
                    hardware.Update();
                    cpuName = hardware.Name;

                    foreach (ISensor sensor in hardware.Sensors)
                    {
                        //Console.WriteLine("\tSensor: {0}, value: {1}", sensor.Name, sensor.Value);
                        //hardwareStats = hardwareStats + "[" + sensor.Name + ": " + sensor.Value + "],\n";
                        if (sensor.SensorType == SensorType.Load && sensor.Name.Contains("Total"))
                            cpuLoad = sensor.Value;
                        else if (sensor.SensorType == SensorType.Power && sensor.Name.Contains("Package"))
                            cpuPower = sensor.Value;
                        else if (sensor.SensorType == SensorType.Clock && !sensor.Name.Contains("Bus"))
                            cpuClocks = sensor.Value;
                        else if (sensor.SensorType == SensorType.Temperature)
                            cpuTemperature = sensor.Value;
                        else
                            continue;
                        //Console.WriteLine(cpuStats);
                    }

                    cpuStats = cpuStats + cpuName + cpuLoad + cpuPower + cpuClocks + cpuTemperature + "\n";
                }
            }

            //GPU
            foreach (IHardware hardware in computer.Hardware)
            {
                if (hardware.HardwareType == HardwareType.GpuAmd)
                {
                    hardware.Update();
                    gpuName = hardware.Name;

                    foreach (ISensor sensor in hardware.Sensors)
                    {
                        //Console.WriteLine("\tSensor: {0}, value: {1}", sensor.Name, sensor.Value);
                        //hardwareStats = hardwareStats + "[" + sensor.Name + ": " + sensor.Value + "],\n";
                        if (sensor.SensorType == SensorType.Load && sensor.Name.Contains("GPU Core"))
                            gpuLoad = sensor.Value;
                        else if (sensor.SensorType == SensorType.Power)
                            gpuPower = sensor.Value;
                        else if (sensor.SensorType == SensorType.Clock)
                            gpuClock = sensor.Value;
                        else if (sensor.SensorType == SensorType.Temperature && sensor.Name.Contains("GPU Core"))
                            gpuTemperature = sensor.Value;
                        else if (sensor.SensorType == SensorType.Temperature && sensor.Name.Contains("GPU Hot Spot"))
                            gpuHotspotTemp = sensor.Value;
                        else if (sensor.SensorType == SensorType.SmallData && sensor.Name.Contains("GPU Memory Used"))
                            gpuMemoryUsed = sensor.Value;
                        else if (sensor.SensorType == SensorType.SmallData && sensor.Name.Contains("GPU Memory Total"))
                            gpuMemoryTotal = sensor.Value;
                        else if (sensor.SensorType == SensorType.SmallData && sensor.Name.Contains("GPU Memory Free"))
                            gpuMemoryFree= sensor.Value;
                        else if (sensor.SensorType == SensorType.Fan)
                            gpuFanSpeed = sensor.Value;
                        else if (sensor.SensorType == SensorType.Control)
                            gpuFanPer = sensor.Value;
                        else
                            continue;
                        //Console.WriteLine(cpuStats);
                    }

                    gpuStats = gpuStats + gpuName + gpuLoad + gpuPower + gpuClock + gpuTemperature +
                        gpuMemoryUsed + gpuFanSpeed + gpuFanPer + "\n";
                }
            }

            //Memory
            foreach (IHardware hardware in computer.Hardware)
            {
                if (hardware.HardwareType == HardwareType.Memory)
                {
                    hardware.Update();

                    foreach (ISensor sensor in hardware.Sensors)
                    {
                        //Console.WriteLine("\tSensor: {0}, value: {1}", sensor.Name, sensor.Value);
                        //hardwareStats = hardwareStats + "[" + sensor.Name + ": " + sensor.Value + "],\n";
                        if (sensor.SensorType == SensorType.Load && sensor.Name.Contains("Memory") && !sensor.Name.Contains("Virtual"))
                            ramLoad = sensor.Value;
                        else if (sensor.SensorType == SensorType.Data && sensor.Name.Contains("Memory Used") && !sensor.Name.Contains("Virtual"))
                            ramUsed = sensor.Value;
                        else if (sensor.SensorType == SensorType.Data && sensor.Name.Contains("Memory Available") && !sensor.Name.Contains("Virtual"))
                            ramAvailable = sensor.Value;

                        //Console.WriteLine(cpuStats);
                    }

                    ramStats = ramStats + ramLoad + ramUsed + ramAvailable + "\n";
                }
            }

            //MotherBoard
            foreach (IHardware hardware in computer.Hardware)
            {
                if (hardware.HardwareType == HardwareType.Motherboard)
                {
                    hardware.Update();
                    foreach (IHardware subhardware in hardware.SubHardware)
                    {
                        //Console.WriteLine("\tSubhardware: {0}", subhardware.Name);
                        motherboardSub = "\n" + subhardware.Name;
                        //hardwareStats = hardwareStats + "[" + subhardware.Name + ": ";

                        foreach (ISensor sensor in subhardware.Sensors)
                        {
                            //Console.WriteLine("\tSensor: {0}, value: {1}", sensor.Name, sensor.Value);
                            //hardwareStats = hardwareStats + "[" + sensor.Name + ": " + sensor.Value + "],\n";
                            if (sensor.SensorType == SensorType.Temperature)
                                motherboardTemps = sensor.Value;
                            else if (sensor.SensorType == SensorType.Fan && sensor.Name.Contains("Fan #1") || sensor.Name.Contains("Fan #3") || sensor.Name.Contains("Fan #4"))
                                if (sensor.Value.HasValue)
                                    motherboardFanSpeed = sensor.Value;
                                else
                                    continue;
                            //Console.WriteLine(cpuStats);
                        }

                    }

                    motherboardStats = motherboardStats + motherboardSub + motherboardTemps + motherboardFanSpeed + "\n";
                }
            }

            //computer.Close();
        }

    }
}
