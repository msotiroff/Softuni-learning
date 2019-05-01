using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    private const string FullMode = "Full";
    private const double FullCoef = 1.0;
    private const string HalfMode = "Half";
    private const double HalfCoef = 0.5;
    private const string EnergyMode = "Energy";
    private const double EnergyCoef = 0.2;

    private IHarvesterFactory harvesterFactory;
    private IEnergyRepository energyRepository;
    private List<IHarvester> allHarvesters;
    private string currentMode;
    
    public HarvesterController(IEnergyRepository energyRepository)
    {
        this.harvesterFactory = new HarvesterFactory();
        this.energyRepository = energyRepository;
        this.allHarvesters = new List<IHarvester>();
        this.currentMode = FullMode;
    }

    public IReadOnlyCollection<IEntity> Entities => this.allHarvesters.AsReadOnly();

    public double OreProduced { get; private set; }

    public string ChangeMode(string mode)
    {
        this.currentMode = mode;

        var brokenHarvesters = new List<IHarvester>();

        foreach (var harvester in allHarvesters)
        {
            try
            {
                harvester.Broke();
            }
            catch
            {
                brokenHarvesters.Add(harvester);
            }
        }

        foreach (var entity in brokenHarvesters)
        {
            this.allHarvesters.Remove(entity);
        }

        return string.Format(Constants.ModeChanged, mode);
    }

    public string Produce()
    {
        var neededEnergy = this.CalculateNeededEnergy();

        if (this.energyRepository.EnergyStored < neededEnergy)
        {
            return string.Format(Constants.OreOutputToday, 0);
        }

        this.energyRepository.TakeEnergy(neededEnergy);

        var oreOutput = this.CalculateOreOutput();

        this.OreProduced += oreOutput;

        return string.Format(Constants.OreOutputToday, oreOutput);
    }

    private double CalculateOreOutput()
    {
        var oreOutput = this.allHarvesters.Sum(h => h.OreOutput);

        switch (this.currentMode)
        {
            case HalfMode:
                oreOutput *= HalfCoef;
                break;
            case EnergyMode:
                oreOutput *= EnergyCoef;
                break;
            default:
                break;
        }

        return oreOutput;
    }

    private double CalculateNeededEnergy()
    {
        var neededEnergy = this.allHarvesters.Sum(h => h.EnergyRequirement);

        switch (this.currentMode)
        {
            case HalfMode:
                neededEnergy *= HalfCoef;
                break;
            case EnergyMode:
                neededEnergy *= EnergyCoef;
                break;
            default:
                break;
        }

        return neededEnergy;
    }

    public string Register(IList<string> args)
    {
        var harvester = this.harvesterFactory.GenerateHarvester(args);

        this.allHarvesters.Add(harvester);

        return string.Format(Constants.SuccessfullRegistration,
            harvester.GetType().Name);
    }
}
