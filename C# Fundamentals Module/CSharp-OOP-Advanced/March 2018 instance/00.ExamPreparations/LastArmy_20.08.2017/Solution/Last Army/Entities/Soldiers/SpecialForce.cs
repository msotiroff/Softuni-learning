using System.Collections.Generic;

public class SpecialForce : Soldier
{
    private const double RegenerateValue = 30;
    private const double DefaultOverallSkillsMultiplier = 3.5;
    private readonly IList<string> weaponsAllowed = new List<string>
    {
       nameof(Gun),
       nameof(AutomaticMachine),
       nameof(MachineGun),
       nameof(RPG),
       nameof(Helmet),
       nameof(Knife),
       nameof(NightVision)
    };

    public SpecialForce(string name, int age, double experience, double endurance) 
        : base(name, age, experience, endurance)
    {
    }

    protected override double OverallSkillMultiplier => DefaultOverallSkillsMultiplier;
    
    protected override IList<string> WeaponsAllowed => this.weaponsAllowed;

    public override void Regenerate()
    {
        this.Endurance += RegenerateValue + this.Age;
    }
}

