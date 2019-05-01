using System;
using System.Collections.Generic;

public interface IHero
{
    string Name { get; }

    long Agility { get; }

    long Damage { get; }

    long HitPoints { get; }

    long Intelligence { get; }

    ICollection<IItem> Items { get; }

    IInventory Inventory { get; }

    long PrimaryStats { get; }

    long SecondaryStats { get; }

    long Strength { get; }

    void AddRecipe(IRecipe recipe);

    string ShortToString();
}