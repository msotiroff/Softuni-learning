using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder : INationsBuilder
{
    private Dictionary<string, List<Bender>> benders;
    private Dictionary<string, List<Monument>> monuments;
    private List<string> allWars;

    public NationsBuilder()
    {
        this.allWars = new List<string>();
        this.benders = new Dictionary<string, List<Bender>>()
        {
            ["Air"] = new List<Bender>(),
            ["Water"] = new List<Bender>(),
            ["Fire"] = new List<Bender>(),
            ["Earth"] = new List<Bender>(),
        };
        this.monuments = new Dictionary<string, List<Monument>>()
        {
            ["Air"] = new List<Monument>(),
            ["Water"] = new List<Monument>(),
            ["Fire"] = new List<Monument>(),
            ["Earth"] = new List<Monument>(),
        };
    }

    public void AssignBender(List<string> benderArgs)
    {
        // Input format: type (string), name (string), power (int), secondaryParameter (floating-point number).

        var type = benderArgs[0];
        var name = benderArgs[1];
        var power = double.Parse(benderArgs[2]);
        var specificParameter = double.Parse(benderArgs[3]);

        Bender bender = null;

        switch (type)
        {
            case "Air":
                bender = new AirBender(name, power, specificParameter);
                break;
            case "Water":
                bender = new WaterBender(name, power, specificParameter);
                break;
            case "Fire":
                bender = new FireBender(name, power, specificParameter);
                break;
            case "Earth":
                bender = new EarthBender(name, power, specificParameter);
                break;
            default:
                break;
        }

        if (bender != null)
        {
            this.benders[type].Add(bender);
        }
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        // input format: type (string), name (string), affinity (int)

        var type = monumentArgs[0];
        var name = monumentArgs[1];
        var affinity = int.Parse(monumentArgs[2]);

        Monument monument = null;

        switch (type)
        {
            case "Air":
                monument = new AirMonument(name, affinity);
                break;
            case "Water":
                monument = new WaterMonument(name, affinity);
                break;
            case "Fire":
                monument = new FireMonument(name, affinity);
                break;
            case "Earth":
                monument = new EarthMonument(name, affinity);
                break;
            default:
                break;
        }

        if (monument != null)
        {
            this.monuments[type].Add(monument);
        }
    }

    public string GetStatus(string nationsType)
    {
        var allBenders = this
            .benders
            .First(n => n.Key == nationsType)
            .Value;

        var allMonuments = this
            .monuments
            .First(m => m.Key == nationsType)
            .Value;

        var result = GetNationDetails(nationsType, allBenders, allMonuments);

        return result;
    }

    private string GetNationDetails(string nationType, List<Bender> allBenders, List<Monument> allMonuments)
    {
        var builder = new StringBuilder()
            .AppendLine($"{nationType} Nation")
            .AppendLine(allBenders.Any() ? "Benders:" : "Benders: None");

        foreach (var bender in allBenders)
        {
            builder.AppendLine($"###{bender.ToString()}");
        }

        builder.AppendLine(allMonuments.Any() ? "Monuments:" : "Monuments: None");

        foreach (var monument in allMonuments)
        {
            builder.AppendLine($"###{monument.ToString()}");
        }

        return builder.ToString().TrimEnd();
    }

    public string GetWarsRecord()
    {
        var result = new StringBuilder();

        var warNumber = 1;

        foreach (var warNation in this.allWars)
        {
            result.AppendLine($"War {warNumber} issued by {warNation}");
            warNumber++;
        }

        return result.ToString().TrimEnd();
    }

    public void IssueWar(string nationsType)
    {
        this.allWars.Add(nationsType);

        var winner = nationsType;
        var winnerPower = 0.0d;

        var givenNation = this.benders.First(n => n.Key == nationsType).Value;
        var givenMonuments = this.monuments.First(m => m.Key == nationsType).Value;
        
        var givenNationTotalPower = givenNation.Sum(n => n.TotalPower);
        givenNationTotalPower += givenNationTotalPower * givenMonuments.Sum(m => m.GetAffinity()) / 100;
        winnerPower = givenNationTotalPower;
        
        var enemiesNames = this.benders.Keys.Where(k => k != nationsType).ToArray();

        foreach (var enemy in enemiesNames)
        {
            var enemyTotalPower = this.benders[enemy].Sum(b => b.TotalPower);
            enemyTotalPower += enemyTotalPower * this.monuments[enemy].Sum(m => m.GetAffinity()) / 100;

            if (winnerPower < enemyTotalPower)
            {
                winnerPower = enemyTotalPower;
                winner = enemy;
            }
        }

        var lostNations = this.benders.Where(n => n.Key != winner).Select(n => n.Key);

        foreach (var lost in lostNations)
        {
            this.benders[lost].Clear();
            this.monuments[lost].Clear();
        }
    }
}
