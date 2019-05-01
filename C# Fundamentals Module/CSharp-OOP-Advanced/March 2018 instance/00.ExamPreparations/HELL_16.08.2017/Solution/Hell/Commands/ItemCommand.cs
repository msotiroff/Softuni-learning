using System.Collections.Generic;

public class ItemCommand : AbstractCommand
{
    private IHeroManager heroManager;
    private IItemFactory itemFactory;

    public ItemCommand(IHeroManager heroManager, IItemFactory itemFactory, IList<string> args) 
        : base(args)
    {
        this.heroManager = heroManager;
        this.itemFactory = itemFactory;
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

        var item = this.itemFactory.CreateItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitpointsBonus, damageBonus);

        var result = this.heroManager.AddItemToHero(item, heroName);

        return result;
    }
}
