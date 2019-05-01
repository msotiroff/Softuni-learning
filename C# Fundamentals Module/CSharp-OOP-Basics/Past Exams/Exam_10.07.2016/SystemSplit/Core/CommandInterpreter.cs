using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CommandInterpreter
{
    private List<Hardware> hardwares;
    private List<Hardware> dump;

    public CommandInterpreter()
    {
        this.hardwares = new List<Hardware>();
        this.dump = new List<Hardware>();
    }

    public void RegisterPowerHardware(string[] commandArgs)
    {
        var name = commandArgs[0];
        var capacity = int.Parse(commandArgs[1]);
        var memory = int.Parse(commandArgs[2]);

        Hardware hardware = new PowerHardware(name, capacity, memory);

        this.hardwares.Add(hardware);
    }

    public void RegisterHeavyHardware(string[] commandArgs)
    {
        var name = commandArgs[0];
        var capacity = int.Parse(commandArgs[1]);
        var memory = int.Parse(commandArgs[2]);

        Hardware hardware = new HeavyHardware(name, capacity, memory);

        this.hardwares.Add(hardware);
    }

    public void RegisterExpressSoftware(string[] commandArgs)
    {
        var hardwareName = commandArgs[0];
        var softwareName = commandArgs[1];
        var capacity = int.Parse(commandArgs[2]);
        var memory = int.Parse(commandArgs[3]);

        Software software = new ExpressSoftware(softwareName, capacity, memory);

        var hardware = hardwares.FirstOrDefault(h => h.Name == hardwareName);

        if (hardware != null)
        {
            hardware.RegisterSoftware(software);
        }
    }

    public void RegisterLightSoftware(string[] commandArgs)
    {
        var hardwareName = commandArgs[0];
        var softwareName = commandArgs[1];
        var capacity = int.Parse(commandArgs[2]);
        var memory = int.Parse(commandArgs[3]);

        Software software = new LightSoftware(softwareName, capacity, memory);

        var hardware = hardwares.FirstOrDefault(h => h.Name == hardwareName);

        if (hardware != null)
        {
            hardware.RegisterSoftware(software);
        }
    }

    public void ReleaseSoftwareComponent(string[] commandArgs)
    {
        var hardwareComponentName = commandArgs[0];
        var softwareComponentName = commandArgs[1];

        var hardware = this.hardwares.FirstOrDefault(h => h.Name == hardwareComponentName);

        if (hardware != null)
        {
            hardware.ReleaseSoftware(softwareComponentName);
        }
    }

    public void Dump(string[] commandArgs)
    {
        var hardwareName = commandArgs[0];

        var hardware = this.hardwares.FirstOrDefault(h => h.Name == hardwareName);

        if (hardware != null)
        {
            this.dump.Add(hardware);
            this.hardwares.Remove(hardware);
        }
    }

    public void Restore(string[] commandArgs)
    {
        var hardwareName = commandArgs[0];

        var hardware = this.dump.FirstOrDefault(h => h.Name == hardwareName);

        if (hardware != null)
        {
            this.hardwares.Add(hardware);
            this.dump.Remove(hardware);
        }
    }

    public string Analyze()
    {
        var countOfHardwareComponents = this.hardwares.Count;

        var countOfSoftwareComponents = this.hardwares.Sum(h => h.Softwares.Count);

        var totalOperationalMemoryInUse = this.hardwares
            .Sum(h => h.Softwares
                .Sum(s => s.MemoryConsumption));

        var totalCapacityTaken = this.hardwares
            .Sum(h => h.Softwares
                .Sum(s => s.CapacityConsumption));

        var maximumMemory = this.hardwares
            .Sum(h => h.MaxMemory);

        var maximumCapacity = this.hardwares
            .Sum(h => h.MaxCapacity);
        
        var result = new StringBuilder()
            .AppendLine("System Analysis")
            .AppendLine($"Hardware Components: {countOfHardwareComponents}")
            .AppendLine($"Software Components: {countOfSoftwareComponents}")
            .AppendLine($"Total Operational Memory: {totalOperationalMemoryInUse} / {maximumMemory}")
            .Append($"Total Capacity Taken: {totalCapacityTaken} / {maximumCapacity}");

        return result.ToString();
    }

    public void Destroy(string[] commandArgs)
    {
        var hardwareName = commandArgs[0];

        var hardware = this.dump.FirstOrDefault(h => h.Name == hardwareName);

        if (hardware != null)
        {
            this.dump.Remove(hardware);
        }
    }

    public string DumpAnalyze()
    {
        var countOfPowerHardwareComponents = this.dump
            .Count(h => h.GetType().Name == nameof(PowerHardware));

        var countOfHeavyHardwareComponents = this.dump
            .Count(h => h.GetType().Name == nameof(HeavyHardware));

        var countOfExpressSoftwareComponents = this.dump
            .Sum(h => h.Softwares
                .Count(s => s.GetType().Name == nameof(ExpressSoftware)));

        var countOfLightSoftwareComponents = this.dump
            .Sum(h => h.Softwares
                .Count(s => s.GetType().Name == nameof(LightSoftware)));

        var totalDumpedMemory = this.dump
            .Sum(h => h.Softwares
                .Sum(s => s.MemoryConsumption));

        var totalDumpedCapacity = this.dump
            .Sum(h => h.Softwares
                .Sum(s => s.CapacityConsumption));

        var result = new StringBuilder()
            .AppendLine("Dump Analysis")
            .AppendLine($"Power Hardware Components: {countOfPowerHardwareComponents}")
            .AppendLine($"Heavy Hardware Components: {countOfHeavyHardwareComponents}")
            .AppendLine($"Express Software Components: {countOfExpressSoftwareComponents}")
            .AppendLine($"Light Software Components: {countOfLightSoftwareComponents}")
            .AppendLine($"Total Dumped Memory: {totalDumpedMemory}")
            .Append($"Total Dumped Capacity: {totalDumpedCapacity}");

        return result.ToString();
    }

    public string SystemSplit(string[] commandArgs)
    {
        var result = new StringBuilder();

        this.hardwares
            .OrderByDescending(h => h.GetType().Name)
            .ToList()
            .ForEach(h => result.AppendLine(h.ToString()));

        return result.ToString().TrimEnd();
    }
}
