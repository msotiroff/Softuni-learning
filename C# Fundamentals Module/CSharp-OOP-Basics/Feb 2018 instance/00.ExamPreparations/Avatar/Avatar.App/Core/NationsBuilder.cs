using System;
using System.Collections.Generic;
using System.Linq;

public class NationsBuilder
{
    private IDictionary<string, Nation> allNations;
    private IList<string> issuedWars;

    public NationsBuilder()
    {
        this.allNations = this.InitializeAllValidNations();
        this.issuedWars = new List<string>();
    }
    
    public void AssignBender(List<string> benderArgs)
    {
        // Bender {type} {name} {power} {secondaryParameter}

        var type = benderArgs[0];
        var name = benderArgs[1];
        var power = int.Parse(benderArgs[2]);
        var specialCharacteristic = double.Parse(benderArgs[3]);

        Bender bender = null;

        switch (type)
        {
            case "Air":
                bender = new AirBender(name, power, specialCharacteristic);
                this.allNations["Air"].Benders.Add(bender);
                break;
            case "Water":
                bender = new WaterBender(name, power, specialCharacteristic);
                this.allNations["Water"].Benders.Add(bender);
                break;
            case "Fire":
                bender = new FireBender(name, power, specialCharacteristic);
                this.allNations["Fire"].Benders.Add(bender);
                break;
            case "Earth":
                bender = new EarthBender(name, power, specialCharacteristic);
                this.allNations["Earth"].Benders.Add(bender);
                break;
            default:
                break;
        }
    }
    public void AssignMonument(List<string> monumentArgs)
    {
        // Monument {type} {name} {affinity}

        var type = monumentArgs[0];
        var name = monumentArgs[1];
        var affinity = int.Parse(monumentArgs[2]);

        Monument monument = null;

        switch (type)
        {
            case "Air":
                monument = new AirMonument(name, affinity);
                this.allNations["Air"].Monuments.Add(monument);
                break;
            case "Water":
                monument = new WaterMonument(name, affinity);
                this.allNations["Water"].Monuments.Add(monument);
                break;
            case "Fire":
                monument = new FireMonument(name, affinity);
                this.allNations["Fire"].Monuments.Add(monument);
                break;
            case "Earth":
                monument = new EarthMonument(name, affinity);
                this.allNations["Earth"].Monuments.Add(monument);
                break;
            default:
                break;
        }
    }

    public string GetStatus(string nationsType)
    {
        return $"{nationsType} Nation"
            + Environment.NewLine
            + this.allNations[nationsType].ToString();
    }

    public void IssueWar(string nationsType)
    {
        // War {nation}

        int warNumber = this.issuedWars.Count + 1;

        this.issuedWars.Add($"War {warNumber} issued by {nationsType}");

        var sortedNations = this.allNations
            .OrderByDescending(n => n.Value.GetTotalPower())
            .ToList();
        
        var losers = sortedNations.Skip(1).ToList();

        losers.ForEach(l => l.Value.KillThemAll());
    }
    public string GetWarsRecord()
    {
        return string.Join(Environment.NewLine, this.issuedWars);
    }

    private Dictionary<string, Nation> InitializeAllValidNations()
    {
        return new Dictionary<string, Nation>()
        {
            ["Air"] = new Nation(),
            ["Fire"] = new Nation(),
            ["Water"] = new Nation(),
            ["Earth"] = new Nation()
        };
    }
}
