using System.Collections.Generic;

public interface IRecipeFactory
{
    IRecipe CreateRecipe(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitpointsBonus, long damageBonus, IList<string> requiredItems);
}