using System.Text;

public class CommonItem : IItem
{
    public CommonItem(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitpointsBonus, long damageBonus)
    {
        this.Name = name;
        this.StrengthBonus = strengthBonus;
        this.AgilityBonus = agilityBonus;
        this.IntelligenceBonus = intelligenceBonus;
        this.HitPointsBonus = hitpointsBonus;
        this.DamageBonus = damageBonus;
    }

    public string Name { get; }

    public long AgilityBonus { get; }

    public long DamageBonus { get; }

    public long HitPointsBonus { get; }

    public long IntelligenceBonus { get; }

    public long StrengthBonus { get; }

    public override string ToString()
    {
        var builder = new StringBuilder()
            .AppendLine($"###Item: {this.Name}")
            .AppendLine($"###+{this.StrengthBonus} Strength")
            .AppendLine($"###+{this.AgilityBonus} Agility")
            .AppendLine($"###+{this.IntelligenceBonus} Intelligence")
            .AppendLine($"###+{this.HitPointsBonus} HitPoints")
            .Append($"###+{this.DamageBonus} Damage");

        return builder.ToString();
    }
}
