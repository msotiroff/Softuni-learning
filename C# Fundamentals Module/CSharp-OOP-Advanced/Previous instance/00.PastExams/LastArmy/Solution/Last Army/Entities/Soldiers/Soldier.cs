using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private const double enduranceMaxValue = 100.0;

    private double endurance;

    protected Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        this.Weapons = this.InitializeAvailableWeapons();
    }

    protected abstract IReadOnlyList<string> WeaponsAllowed { get; }
    
    public IDictionary<string, IAmmunition> Weapons { get; protected set; }
    
    public string Name { get; }

    public int Age { get; }

    public double Experience { get; private set; }

    public double Endurance
    {
        get => this.endurance;
        protected set
        {
            this.endurance = Math.Min(enduranceMaxValue, value);
        }
    }

    public virtual double OverallSkill => this.Age + this.Experience;

    public void CompleteMission(IMission mission)
    {
        this.Endurance -= mission.EnduranceRequired;
        this.Experience += mission.EnduranceRequired;

        var missionWearLevelDecrement = mission.WearLevelDecrement;

        IEnumerable<string> weaponNames = this.Weapons.Keys.ToArray();

        foreach (string weaponName in weaponNames)
        {
            this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (this.Weapons[weaponName].WearLevel <= 0)
            {
                this.Weapons[weaponName] = null;
            }
        }
    }

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        if (this.Weapons.Any(w => w.Value == null))
        {
            return false;
        }

        if (this.Weapons.Any(w => w.Value.WearLevel <= 0))
        {
            return false;
        }

        return true;
    }

    public virtual void Regenerate()
    {
        this.Endurance += this.Age;
    }

    protected IDictionary<string, IAmmunition> InitializeAvailableWeapons()
    {
        var weapons = new Dictionary<string, IAmmunition>();

        foreach (var weaponType in this.WeaponsAllowed)
        {
            weapons.Add(weaponType, null);
        }

        return weapons;
    }

    public override string ToString()
    {
        return string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);
    }
}