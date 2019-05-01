using System;
using System.Collections.Generic;

public class RecipeFactory : IRecipeFactory
{
    public IRecipe CreateRecipe(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, 
        long hitpointsBonus, long damageBonus, IList<string> requiredItems)
    {
        var ctorParams = new object[] { name, strengthBonus, agilityBonus, intelligenceBonus, hitpointsBonus, damageBonus, requiredItems };

        var item = Activator.CreateInstance(typeof(RecipeItem), ctorParams);

        return (IRecipe)item;
    }
}
