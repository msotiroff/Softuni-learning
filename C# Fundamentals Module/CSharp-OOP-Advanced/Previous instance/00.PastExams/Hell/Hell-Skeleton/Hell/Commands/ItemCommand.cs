using System.Collections.Generic;

public class ItemCommand : AbstractCommand
{
    public ItemCommand(IHeroManager heroManager, IList<string> arguments) 
        : base(heroManager, arguments)
    {
    }

    public override string Execute()
    {
        var itemName = this.Arguments[0];
        var heroName = this.Arguments[1];
        var strengthBonus = long.Parse(this.Arguments[2]);
        var agilityBonus = long.Parse(this.Arguments[3]);
        var intelligenceBonus = long.Parse(this.Arguments[4]);
        var hitpointsBonus = long.Parse(this.Arguments[5]);
        var damageBonus = long.Parse(this.Arguments[6]);

        return this.HeroManager
            .AddItemToHero(itemName, heroName, strengthBonus, agilityBonus, intelligenceBonus, hitpointsBonus, damageBonus);
    }
}
