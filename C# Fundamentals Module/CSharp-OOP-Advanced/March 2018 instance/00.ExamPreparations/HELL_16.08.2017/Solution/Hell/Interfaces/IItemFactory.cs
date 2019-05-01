public interface IItemFactory
{
    IItem CreateItem(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitpointsBonus, long damageBonus);
}