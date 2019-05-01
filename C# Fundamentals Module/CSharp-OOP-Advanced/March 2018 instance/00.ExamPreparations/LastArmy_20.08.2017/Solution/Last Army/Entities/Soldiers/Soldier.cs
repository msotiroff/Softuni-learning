using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private const double EnduranceMaxValue = 100.0;

    private double endurance;

    protected Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        this.Weapons = this.InitializeAllAllowedWepons();
    }
    
    public string Name { get; }

    public int Age { get; }

    public double Experience { get; private set; }

    public double Endurance
    {
        get => this.endurance;
        protected set
        {
            this.endurance = Math.Min(value, EnduranceMaxValue);
        }
    }

    public double OverallSkill => (this.Age + this.Experience) * this.OverallSkillMultiplier;

    public IDictionary<string, IAmmunition> Weapons { get; }

    protected abstract IList<string> WeaponsAllowed { get; }

    protected abstract double OverallSkillMultiplier { get; }

    public void CompleteMission(IMission mission)
    {
        this.Experience += mission.EnduranceRequired;
        this.Endurance -= mission.EnduranceRequired;

        foreach (var weapon in this.Weapons.Values.Where(w => w != null).ToList())
        {
            weapon.DecreaseWearLevel(mission.WearLevelDecrement);
            if (weapon.WearLevel <= 0)
            {
                this.Weapons[weapon.Name] = null;
            }
        }
    }

    public bool ReadyForMission(IMission mission)
    {
        var hasEnoughEndurance = this.Endurance >= mission.EnduranceRequired;
        var hasAllWeapons = this.Weapons.All(w => w.Value != null);
        var allAmmunitionsHaveEnoughWearLevel = this.Weapons.Where(w => w.Value != null).All(w => w.Value.WearLevel > 0);

        return hasEnoughEndurance && hasAllWeapons && allAmmunitionsHaveEnoughWearLevel;
    }

    public abstract void Regenerate();

    private IDictionary<string, IAmmunition> InitializeAllAllowedWepons()
    {
        var weapons = new Dictionary<string, IAmmunition>();

        var weaponsAllowed = this.WeaponsAllowed;

        foreach (var weaponName in weaponsAllowed)
        {
            weapons.Add(weaponName, null);
        }

        return weapons;
    }

    public override string ToString()
    {
        return string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);
    }
}
