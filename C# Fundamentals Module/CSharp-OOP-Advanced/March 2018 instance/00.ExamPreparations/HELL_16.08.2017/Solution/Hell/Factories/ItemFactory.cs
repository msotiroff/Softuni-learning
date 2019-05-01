using System;

public class ItemFactory : IItemFactory
{
    public IItem CreateItem(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitpointsBonus, long damageBonus)
    {
        var ctorParams = new object[] { name, strengthBonus, agilityBonus, intelligenceBonus, hitpointsBonus, damageBonus };
        
        var item = Activator.CreateInstance(typeof(CommonItem), ctorParams);

        return (IItem)item;
    }
}
