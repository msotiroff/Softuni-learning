using System.Collections.Generic;
using System.Linq;

public class RecipeCommand : AbstractCommand
{
    private IHeroManager heroManager;
    private IRecipeFactory recipeFactory;

    public RecipeCommand(IHeroManager heroManager, IRecipeFactory recipeFactory, IList<string> args) 
        : base(args)
    {
        this.heroManager = heroManager;
        this.recipeFactory = recipeFactory;
    }

    public override string Execute()
    {
        var itemName = this.Arguments[0];
        var heroName = this.Arguments[1];
        var strengthBonus = int.Parse(this.Arguments[2]);
        var agilityBonus = int.Parse(this.Arguments[3]);
        var intelligenceBonus = int.Parse(this.Arguments[4]);
        var hitpointsBonus = int.Parse(this.Arguments[5]);
        var damageBonus = int.Parse(this.Arguments[6]);
        var requiredItems = this.Arguments.Skip(7).ToList();

        var recipe = this.recipeFactory.CreateRecipe(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitpointsBonus, damageBonus, requiredItems);

        var result = this.heroManager.AddRecipeToHero(recipe, heroName);

        return result;
    }
}
