using System.Collections.Generic;

public class RecipeItem : AbstractItem, IRecipe
{
    private IList<string> requiredItems;

    public RecipeItem(string name, long strength, long agility, long intelligence, long hitpoints, long damage, string[] commonItems) 
        : base(name, strength, agility, intelligence, hitpoints, damage)
    {
        this.RequiredItems = commonItems;
    }

    public IList<string> RequiredItems
    {
        get => requiredItems;
        private set => requiredItems = value;
    }
}
