using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager : IDraftManager
{
    private const string FullMode = "Full";
    private const string HalfMode = "Half";
    private const string EnergyMode = "Energy";

    private string mode;
    private List<Harvester> allHarvesters;
    private List<Provider> allProviders;
    private double totalEnergyStored;
    private double totalMinedOre;

    public DraftManager()
    {
        this.mode = FullMode;
        this.allHarvesters = new List<Harvester>();
        this.allProviders = new List<Provider>();
    }

    public string Check(List<string> arguments)
    {
        var id = arguments[0];

        var harvester = allHarvesters
            .FirstOrDefault(h => h.Id == id);

        var provider = allProviders
            .FirstOrDefault(p => p.Id == id);

        return harvester != null
            ? harvester.ToString()
            : provider != null
                ? provider.ToString()
                : $"No element found with id - {id}";
    }

    public string Day()
    {
        var summedEnergyOutput = this.allProviders.Sum(p => p.EnergyOutput);

        var neededEnergy = this.allHarvesters.Sum(h => h.EnergyRequirement);
        var summedOreOutput = this.allHarvesters.Sum(h => h.OreOutput);

        if (this.mode == HalfMode)
        {
            neededEnergy *= 0.6;
            summedOreOutput *= 0.5;
        }
        else if (this.mode == EnergyMode)
        {
            neededEnergy = 0;
            summedOreOutput = 0;
        }

        this.totalEnergyStored += summedEnergyOutput;

        if (this.totalEnergyStored >= neededEnergy)
        {
            this.totalEnergyStored -= neededEnergy;
            this.totalMinedOre += summedOreOutput;
        }
        else
        {
            summedOreOutput = 0;
        }

        var result = new StringBuilder()
            .AppendLine("A day has passed.")
            .AppendLine($"Energy Provided: {summedEnergyOutput}")
            .Append($"Plumbus Ore Mined: {summedOreOutput}");

        return result.ToString();
    }

    public string Mode(List<string> arguments)
    {
        var newMode = arguments[0];

        this.mode = newMode;

        return $"Successfully changed working mode to {this.mode} Mode";
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            var harvester = HarvesterFactory.CreateInstance(arguments);
            allHarvesters.Add(harvester);
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
        }

        var harvesterType = arguments[0];
        var id = arguments[1];

        return $"Successfully registered {harvesterType} Harvester - {id}";
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            var provider = ProviderFactory.CreateInstance(arguments);
            allProviders.Add(provider);
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
        }

        var providerType = arguments[0];
        var id = arguments[1];

        return $"Successfully registered {providerType} Provider - {id}";
    }

    public string ShutDown()
    {
        var result = new StringBuilder()
            .AppendLine("System Shutdown")
            .AppendLine($"Total Energy Stored: {this.totalEnergyStored}")
            .Append($"Total Mined Plumbus Ore: {this.totalMinedOre}");
        
        return result.ToString();
    }
}