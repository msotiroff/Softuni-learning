using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Hardware
{
    public Hardware(string name, int maxCapacity, int maxMemory)
    {
        this.Name = name;
        this.MaxCapacity = maxCapacity;
        this.MaxMemory = maxMemory;
        this.Softwares = new List<Software>();
    }

    public string Name { get; private set; }

    public int MaxCapacity { get; protected set; }

    public int MaxMemory { get; protected set; }

    public List<Software> Softwares { get; private set; }
    
    protected abstract void ChangeParameters();

    public void RegisterSoftware(Software software)
    {
        var hasEnoughMemory = this.MaxMemory - this.Softwares.Sum(s => s.MemoryConsumption) >= software.MemoryConsumption;
        var hasEnoughCapacity = this.MaxCapacity - this.Softwares.Sum(s => s.CapacityConsumption) >= software.CapacityConsumption;

        if (hasEnoughCapacity && hasEnoughMemory)
        {
            this.Softwares.Add(software);
        }
    }

    public void ReleaseSoftware(string softwareName)
    {
        var hasSuchASoftware = this.Softwares.Any(s => s.Name == softwareName);

        if (hasSuchASoftware)
        {
            this.Softwares.RemoveAll(s => s.Name == softwareName);
        }
    }

    public override string ToString()
    {
        var countOfExpressSoftwareComponents = this.Softwares
            .Where(s => s.GetType().Name == nameof(ExpressSoftware))
            .Count();

        var countOfLightSoftwareComponents = this.Softwares
            .Where(s => s.GetType().Name == nameof(LightSoftware))
            .Count();

        var memoryUsed = this.Softwares.Sum(s => s.MemoryConsumption);

        var capacityUsed = this.Softwares.Sum(s => s.CapacityConsumption);

        var maximumMemory = this.MaxMemory;

        var maximumCapacity = this.MaxCapacity;

        var  hardwareType = this.GetType().Name.Replace("Hardware", string.Empty);

        var softwareComponents = this.Softwares.Any()
            ? string.Join(", ", this.Softwares.Select(s => s.Name))
            : "None";
        
        var builder = new StringBuilder()
                .AppendLine($"Hardware Component - {this.Name}")
                .AppendLine($"Express Software Components - {countOfExpressSoftwareComponents}")
                .AppendLine($"Light Software Components - {countOfLightSoftwareComponents}")
                .AppendLine($"Memory Usage: {memoryUsed} / {maximumMemory}")
                .AppendLine($"Capacity Usage: {capacityUsed} / {maximumCapacity}")
                .AppendLine($"Type: {hardwareType}")
                .Append($"Software Components: {softwareComponents}");

        return builder.ToString();
    }
}
