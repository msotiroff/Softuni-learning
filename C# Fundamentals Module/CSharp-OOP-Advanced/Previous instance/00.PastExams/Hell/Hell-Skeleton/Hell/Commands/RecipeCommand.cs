using System.Collections.Generic;
using System.Linq;

public class RecipeCommand : AbstractCommand
{
    public RecipeCommand(IHeroManager heroManager, IList<string> arguments) 
        : base(heroManager, arguments)
    {
    }

    public override string Execute()
    {
        var recipeName = this.Arguments[0];
        var heroName = this.Arguments[1];
        var strengthBonus = long.Parse(this.Arguments[2]);
        var agilityBonus = long.Parse(this.Arguments[3]);
        var intelligenceBonus = long.Parse(this.Arguments[4]);
        var hitpointsBonus = long.Parse(this.Arguments[5]);
        var damageBonus = long.Parse(this.Arguments[6]);
        var requiredItems = this.Arguments.Skip(7).ToArray();

        return this.HeroManager
            .AddRecipeToHero(recipeName, heroName, strengthBonus, agilityBonus, intelligenceBonus, hitpointsBonus, damageBonus, requiredItems);
    }
}
