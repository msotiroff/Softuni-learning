using System.Collections.Generic;

public class RecipeItem : IRecipe
{
    public RecipeItem(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, 
        long hitpointsBonus, long damageBonus, IList<string> requiredItems)
    {
        this.Name = name;
        this.StrengthBonus = strengthBonus;
        this.AgilityBonus = agilityBonus;
        this.IntelligenceBonus = intelligenceBonus;
        this.HitPointsBonus = hitpointsBonus;
        this.DamageBonus = damageBonus;
        this.RequiredItems = requiredItems;
    }

    public string Name { get; }

    public long AgilityBonus { get; }

    public long DamageBonus { get; }

    public long HitPointsBonus { get; }

    public long IntelligenceBonus { get; }

    public long StrengthBonus { get; }

    public IList<string> RequiredItems { get; }
}
