using System;
using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    private Mode currentMode;
    private List<IHarvester> harvesters;
    private IHarvesterFactory harvesterFactory;
    private IEnergyRepository energyRepository;

    public HarvesterController(IEnergyRepository energyRepository)
    {
        this.currentMode = Mode.Full;
        this.energyRepository = energyRepository;
        this.harvesters = new List<IHarvester>();
        this.harvesterFactory = new HarvesterFactory();
    }

    public IReadOnlyCollection<IEntity> Entities => this.harvesters.AsReadOnly();

    public double OreProduced { get; private set; }

    public string ChangeMode(string mode)
    {
        var newMode = (Mode)Enum.Parse(typeof(Mode), mode);

        this.currentMode = newMode;

        this.DecreaseDurabilityOfAllHarvesters();

        return string.Format(Constants.ModeChanged, mode);
    }
        
    public string Produce()
    {
        var energyNeeded = this.harvesters.Sum(h => h.EnergyRequirement);

        energyNeeded *= (int)this.currentMode / 100.0;

        var hasEnoughEnergy = this.energyRepository.TakeEnergy(energyNeeded);

        var producedOre = 0.0;

        if (hasEnoughEnergy)
        {
            producedOre = this.harvesters.Sum(h => h.Produce());

            producedOre *= (int)this.currentMode / 100.0;

            this.OreProduced += producedOre;
        }

        var result = string.Format(Constants.OreOutputToday, producedOre);

        return result;
    }

    public string Register(IList<string> args)
    {
        var harvester = this.harvesterFactory.GenerateHarvester(args);

        this.harvesters.Add(harvester);

        return string.Format(Constants.SuccessfullRegistration,
            harvester.GetType().Name);
    }

    private void DecreaseDurabilityOfAllHarvesters()
    {
        List<IHarvester> reminder = new List<IHarvester>();

        foreach (var harvester in this.harvesters)
        {
            try
            {
                harvester.Broke();
            }
            catch (Exception)
            {
                reminder.Add(harvester);
            }
        }

        foreach (var entity in reminder)
        {
            this.harvesters.Remove(entity);
        }
    }

}
