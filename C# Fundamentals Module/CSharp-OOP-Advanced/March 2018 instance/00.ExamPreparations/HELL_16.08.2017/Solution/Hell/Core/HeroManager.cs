using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HeroManager : IHeroManager
{
    private IDictionary<string, IHero> allHeroes;

    public HeroManager()
    {
        this.allHeroes = new Dictionary<string, IHero>();
    }

    public string AddHero(IHero hero)
    {
        var heroName = hero.Name;

        //if (this.allHeroes.ContainsKey(heroName))
        //{
        //    throw new InvalidOperationException("Hero already exist!");
        //}

        this.allHeroes[heroName] = hero;

        var result = string.Format(Constants.HeroCreateMessage, hero.GetType().Name, heroName);

        return result;
    }

    public string AddItemToHero(IItem item, string heroName)
    {
        var hero = this.allHeroes[heroName];

        hero.AddCommonItem(item);

        var result = string.Format(Constants.ItemCreateMessage, item.Name, hero.Name);

        return result;
    }

    public string AddRecipeToHero(IRecipe recipe, string heroName)
    {
        var hero = this.allHeroes[heroName];

        hero.AddRecipe(recipe);

        var result = string.Format(Constants.RecipeCreatedMessage, recipe.Name, hero.Name);

        return result;
    }
    
    public string Inspect(string heroName)
    {
        var hero = this.allHeroes[heroName]; // TODO: throw if null...

        var result = hero.ToString();

        return result;
    }

    public string GenerateResult()
    {
        var builder = new StringBuilder();

        var orderedHeroes = this.allHeroes.Select(h => h.Value).OrderByDescending(h => h).ToList();

        var rank = 1;

        foreach (var hero in orderedHeroes)
        {
            var currentHero = $"{rank++}. {hero.ToShortString()}";

            builder.AppendLine(currentHero);
        }

        var result = builder.ToString().Trim();

        return result;
    }
}