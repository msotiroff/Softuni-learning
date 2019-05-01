using System;

public interface IHero : IComparable<IHero>
{
    long Agility { get; }
    long Damage { get; }
    long HitPoints { get; }
    long Intelligence { get; }
    long Strength { get; }
    
    System.Collections.Generic.ICollection<IItem> Items { get; }

    string Name { get; }
    long PrimaryStats { get; }
    long SecondaryStats { get; }

    void AddRecipe(IRecipe recipe);
    void AddCommonItem(IItem item);
    string ToShortString();
}