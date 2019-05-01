using System.Collections.Generic;

public interface IHeroManager
{
    string AddHero(string name, string type);

    string AddItemToHero(string itemName, string heroName, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitpointsBonus, long damageBonus);

    string AddRecipeToHero(string recipeName, string heroName, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitpointsBonus, long damageBonus, string[] requiredItems);
    string Quit();
    string Inspect(string heroName);
}