using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HeroManager : IHeroManager
{
    private IDictionary<string, IHero> allHeroes;
    private IDictionary<string, IItem> allItems;

    public HeroManager()
    {
        this.allHeroes = new Dictionary<string, IHero>();
        this.allItems = new Dictionary<string, IItem>();
    }

    public string AddHero(string name, string type)
    {
        var heroType = Type.GetType(type);

        var instance = (IHero)Activator.CreateInstance(heroType, new object[] { name });

        this.allHeroes.Add(name, instance);

        return string.Format(Constants.HeroCreateMessage, type, name);
    }

    public string AddItemToHero(string itemName, string heroName, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitpointsBonus, long damageBonus)
    {
        IItem item = new CommonItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitpointsBonus, damageBonus);

        var hero = this.allHeroes[heroName];
        hero.Inventory.AddCommonItem(item);

        return string.Format(Constants.ItemCreateMessage, itemName, heroName);
    }

    public string AddRecipeToHero(string recipeName, string heroName, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitpointsBonus, long damageBonus, string[] requiredItems)
    {
        var recipe = new RecipeItem(recipeName, strengthBonus, agilityBonus, intelligenceBonus, hitpointsBonus, damageBonus, requiredItems);

        var hero = this.allHeroes[heroName];

        hero.AddRecipe(recipe);

        return string.Format(Constants.RecipeCreatedMessage, recipeName, heroName);
    }

    public string Inspect(string heroName)
    {
        var hero = this.allHeroes[heroName];

        return hero.ToString();
    }

    public string Quit()
    {
        var builder = new StringBuilder();

        var orderedHeroes = this.allHeroes
            .OrderByDescending(h => h.Value.PrimaryStats)
            .ThenByDescending(h => h.Value.SecondaryStats)
            .Select(h => h.Value);

        var rank = 1;

        foreach (var hero in orderedHeroes)
        {
            builder.AppendLine($"{rank++}. {hero.ShortToString()}");
        }

        var result = builder.ToString().TrimEnd();

        return result;
    }
}