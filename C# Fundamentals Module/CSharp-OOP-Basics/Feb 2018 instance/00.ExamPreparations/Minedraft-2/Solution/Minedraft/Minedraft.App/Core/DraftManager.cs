using System;
using System.Collections.Generic;
using System.Linq;

public class DraftManager : IDraftManager
{
    private double totalStoredEnergy;
    private double totalMinedOre;

    private IList<Harvester> harvesters;
    private IList<Provider> providers;
    private IHarvesterFactory harvesterFactory;
    private IProviderFactory providerFactory;
    private string mode;

    public DraftManager()
    {
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.providerFactory = new ProviderFactory();
        this.harvesterFactory = new HarvesterFactory();
        this.mode = "Full";
    }


    public string Check(List<string> arguments)
    {
        var id = arguments[0];

        Entity entity = this.providers.FirstOrDefault(p => p.Id == id);

        if (entity == null)
        {
            entity = this.harvesters.FirstOrDefault(h => h.Id == id);
        }

        var result = entity != null
            ? entity.ToString()
            : $"No element found with id - {id}";

        return result;
    }

    public string Day()
    {
        var energyProducedToday = this.providers.Sum(p => p.EnergyOutput);
        this.totalStoredEnergy += energyProducedToday;
        var neededEnergy = this.harvesters.Sum(h => h.EnergyRequirement);
        var minedOre = this.harvesters.Sum(h => h.OreOutput);

        switch (this.mode)
        {
            case "Half":
                neededEnergy *= 0.6;
                minedOre *= 0.5;
                break;
            case "Energy":
                neededEnergy = 0;
                minedOre = 0;
                break;
            default:
                break;
        }

        if (this.totalStoredEnergy >= neededEnergy)
        {
            this.totalStoredEnergy -= neededEnergy;
            this.totalMinedOre += minedOre;
        }
        else
        {
            minedOre = 0;
        }

        var result = "A day has passed."
            + Environment.NewLine
            + $"Energy Provided: {energyProducedToday}"
            + Environment.NewLine
            + $"Plumbus Ore Mined: {minedOre}";

        return result;
    }

    public string Mode(List<string> arguments)
    {
        var newMode = arguments[0];

        this.mode = newMode;

        var result = $"Successfully changed working mode to {newMode} Mode";

        return result;
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            var harvester = this.harvesterFactory.GenerateHarvester(arguments);

            this.harvesters.Add(harvester);

            var harvesterType = harvester.GetType().Name.Replace("Harvester", string.Empty);

            var result = $"Successfully registered {harvesterType} Harvester - {harvester.Id}";

            return result;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            var provider = this.providerFactory.GenerateProvider(arguments);

            this.providers.Add(provider);

            var providerType = provider.GetType().Name.Replace("Provider", string.Empty);

            var result = $"Successfully registered {providerType} Provider - {provider.Id}";

            return result;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string ShutDown()
    {
        var result = "System Shutdown"
            + Environment.NewLine
            + $"Total Energy Stored: {this.totalStoredEnergy}"
            + Environment.NewLine
            + $"Total Mined Plumbus Ore: {this.totalMinedOre}";

        return result;
    }
}
