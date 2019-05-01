using System.Text;

public class AbstractItem : IItem
{
    public AbstractItem(string name, long strength, long agility, long intelligence, long hitpoints, long damage)
    {
        this.Name = name;
        this.StrengthBonus = strength;
        this.AgilityBonus = agility;
        this.IntelligenceBonus = intelligence;
        this.HitPointsBonus = hitpoints;
        this.DamageBonus = damage;
    }

    public string Name { get; private set; }

    public long StrengthBonus { get; private set; }

    public long AgilityBonus { get; private set; }

    public long IntelligenceBonus { get; private set; }

    public long HitPointsBonus { get; private set; }

    public long DamageBonus { get; private set; }

    public override string ToString()
    {
        var builder = new StringBuilder()
            .AppendLine($"###Item: {this.Name}")
            .AppendLine($"###+{this.StrengthBonus} Strength")
            .AppendLine($"###+{this.AgilityBonus} Agility")
            .AppendLine($"###+{this.IntelligenceBonus} Intelligence")
            .AppendLine($"###+{this.HitPointsBonus} HitPoints")
            .AppendLine($"###+{this.DamageBonus} Damage");

        var result = builder.ToString().TrimEnd();

        return result;
    }
}
