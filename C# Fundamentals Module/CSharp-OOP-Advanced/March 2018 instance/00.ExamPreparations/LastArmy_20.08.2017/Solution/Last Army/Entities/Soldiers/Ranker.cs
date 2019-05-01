using System.Collections;
using System.Collections.Generic;

public class Ranker : Soldier
{
    private const double RegenerateValue = 10.0;
    private const double DefaultOverallSkillsMultiplier = 1.5;
    private readonly IList<string> weaponsAllowed = new List<string>
    {
        nameof(Gun),
        nameof(AutomaticMachine),
        nameof(Helmet)
    };

    public Ranker(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }
    
    protected override IList<string> WeaponsAllowed => this.weaponsAllowed;

    protected override double OverallSkillMultiplier => DefaultOverallSkillsMultiplier;

    public override void Regenerate()
    {
        this.Endurance += RegenerateValue + this.Age;
    }
}

