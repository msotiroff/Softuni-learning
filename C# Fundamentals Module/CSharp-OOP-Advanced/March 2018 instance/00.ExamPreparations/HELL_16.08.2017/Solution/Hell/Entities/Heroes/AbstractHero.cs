using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public abstract class AbstractHero : IHero
{
    private IInventory inventory;
    private long strength;
    private long agility;
    private long intelligence;
    private long hitPoints;
    private long damage;

    protected AbstractHero(string name, int strength, int agility, int intelligence, int hitPoints, int damage)
    {
        this.Name = name;
        this.Strength = strength;
        this.Agility = agility;
        this.Intelligence = intelligence;
        this.HitPoints = hitPoints;
        this.Damage = damage;
        this.inventory = new HeroInventory();
    }

    public string Name { get; private set; }

    public long Strength
    {
        get { return this.strength + this.inventory.TotalStrengthBonus; }
        private set { this.strength = value; }
    }

    public long Agility
    {
        get { return this.agility + this.inventory.TotalAgilityBonus; }
        private set { this.agility = value; }
    }

    public long Intelligence
    {
        get { return this.intelligence + this.inventory.TotalIntelligenceBonus; }
        private set { this.intelligence = value; }
    }

    public long HitPoints
    {
        get { return this.hitPoints + this.inventory.TotalHitPointsBonus; }
        private set { this.hitPoints = value; }
    }

    public long Damage
    {
        get { return this.damage + this.inventory.TotalDamageBonus; }
        private set { this.damage = value; }
    }

    public long PrimaryStats
    {
        get { return this.Strength + this.Agility + this.Intelligence; }
    }

    public long SecondaryStats
    {
        get { return this.HitPoints + this.Damage; }
    }

    //REFLECTION
    public ICollection<IItem> Items => this.GetItems();
    
    public void AddRecipe(IRecipe recipe)
    {
        this.inventory.AddRecipeItem(recipe);
    }

    public void AddCommonItem(IItem item)
    {
        this.inventory.AddCommonItem(item);
    }

    public int CompareTo(IHero other)
    {
        var primary = this.PrimaryStats.CompareTo(other.PrimaryStats);
        if (primary != 0)
        {
            return primary;
        }
        return this.SecondaryStats.CompareTo(other.SecondaryStats);
    }

    public string ToShortString()
    {
        var selectedItems = this.Items.Any()
            ? string.Join(", ", this.Items.Select(i => i.Name))
            : "None";

        var builder = new StringBuilder()
            .AppendLine($"{this.GetType().Name}: {this.Name}")
            .AppendLine($"###HitPoints: {this.HitPoints}")
            .AppendLine($"###Damage: {this.Damage}")
            .AppendLine($"###Strength: {this.Strength}")
            .AppendLine($"###Agility: {this.Agility}")
            .AppendLine($"###Intelligence: {this.Intelligence}")
            .Append($"###Items: {string.Join(", ", selectedItems)}");

        return builder.ToString();
    }

    public override string ToString()
    {
        var items = this.Items.Any()
            ? $"{Environment.NewLine}{string.Join(Environment.NewLine, this.Items.Select(i => i.ToString()))}"
            : " None";

        var builder = new StringBuilder()
            .AppendLine($"Hero: {this.Name}, Class: {this.GetType().Name}")
            .AppendLine($"HitPoints: {this.HitPoints}, Damage: {this.Damage}")
            .AppendLine($"Strength: {this.Strength}")
            .AppendLine($"Agility: {this.Agility}")
            .AppendLine($"Intelligence: {this.Intelligence}")
            .Append($"Items:{items}");

        var result = builder.ToString().Trim();

        return result;
    }

    private ICollection<IItem> GetItems()
    {
        var items = (Dictionary<string, IItem>)typeof(HeroInventory)
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .Where(fi => fi.GetCustomAttribute<ItemAttribute>() != null)
            .FirstOrDefault()
            ?.GetValue(this.inventory);

        var itemCollection = (ICollection<IItem>)items.Values;

        return itemCollection;
    }
}