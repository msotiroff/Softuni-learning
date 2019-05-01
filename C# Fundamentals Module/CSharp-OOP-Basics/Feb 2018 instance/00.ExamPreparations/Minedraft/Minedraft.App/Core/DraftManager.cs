using System;
using System.Collections.Generic;
using System.Linq;

public class DraftManager
{
    private string mode;
    private double totalStoredEnergy;
    private double totalMinedOre;
    private IList<Harvester> allHarvesters;
    private IList<Provider> allProviders;
    private HarvesterFactory harvesterFactory;
    private ProviderFactory providerFactory;

    public DraftManager(HarvesterFactory harvesterFactory, ProviderFactory providerFactory)
    {
        this.mode = "Full";
        this.harvesterFactory = harvesterFactory;
        this.providerFactory = providerFactory;
        this.allHarvesters = new List<Harvester>();
        this.allProviders = new List<Provider>();
    }

    public string RegisterHarvester(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];

        try
        {
            Harvester harvester = this.harvesterFactory.CreateInstance(arguments);

            this.allHarvesters.Add(harvester);

            return $"Successfully registered {type} Harvester - {id}";
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        
        try
        {
            Provider provider = this.providerFactory.CreateInstance(arguments);

            this.allProviders.Add(provider);

            return $"Successfully registered {type} Provider - {id}";
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
        }
    }

    public string Day()
    {
        var summedEnergyOutput = this.allProviders.Sum(p => p.EnergyOutput);
        this.totalStoredEnergy += summedEnergyOutput;

        var energyRequired = this.allHarvesters.Sum(h => h.EnergyRequirement);
        var summedOreOutput = this.allHarvesters.Sum(h => h.OreOutput);

        if (this.mode == "Half")
        {
            energyRequired *= 0.6;
            summedOreOutput *= 0.5;
        }
        else if (this.mode == "Energy")
        {
            energyRequired = 0;
            summedOreOutput = 0;
        }

        if (this.totalStoredEnergy >= energyRequired)
        {
            this.totalStoredEnergy -= energyRequired;
            this.totalMinedOre += summedOreOutput;
        }
        else
        {
            summedOreOutput = 0;
        }

        var result = "A day has passed." + Environment.NewLine
            + $"Energy Provided: {summedEnergyOutput}" + Environment.NewLine
            + $"Plumbus Ore Mined: {summedOreOutput}";

        return result;
    }

    public string Mode(List<string> arguments)
    {
        var newMode = arguments[0];

        this.mode = newMode;

        return $"Successfully changed working mode to {newMode} Mode";
    }

    public string Check(List<string> arguments)
    {
        var id = arguments[0];

        var harvester = allHarvesters.FirstOrDefault(h => h.Id == id);
        if (harvester != null)
        {
            return harvester.ToString();
        }

        var provider = this.allProviders.FirstOrDefault(p => p.Id == id);
        if (provider != null)
        {
            return provider.ToString();
        }

        return $"No element found with id - {id}";
    }

    public string ShutDown()
    {
        var result = $"System Shutdown" + Environment.NewLine
            + $"Total Energy Stored: {this.totalStoredEnergy}" + Environment.NewLine
            + $"Total Mined Plumbus Ore: {this.totalMinedOre}";

        return result;
    }

}
