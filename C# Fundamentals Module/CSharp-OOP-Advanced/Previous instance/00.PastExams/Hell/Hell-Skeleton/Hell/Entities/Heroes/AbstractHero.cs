using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class AbstractHero : IHero, IComparable<IHero>
{
    private IInventory inventory;
    private long strength;
    private long agility;
    private long intelligence;
    private long hitPoints;
    private long damage;

    protected AbstractHero(string name, long strength, long agility, long intelligence, long hitPoints, long damage)
    {
        this.Name = name;
        this.strength = strength;
        this.agility = agility;
        this.intelligence = intelligence;
        this.hitPoints = hitPoints;
        this.damage = damage;
        this.Inventory = new HeroInventory();
    }

    public string Name { get; private set; }

    public long Strength
    {
        get { return this.strength + this.inventory.TotalStrengthBonus; }
        set { this.strength = value; }
    }

    public long Agility
    {
        get { return this.agility + this.inventory.TotalAgilityBonus; }
        set { this.agility = value; }
    }

    public long Intelligence
    {
        get { return this.intelligence + this.inventory.TotalIntelligenceBonus; }
        set { this.intelligence = value; }
    }

    public long HitPoints
    {
        get { return this.hitPoints + this.inventory.TotalHitPointsBonus; }
        set { this.hitPoints = value; }
    }

    public long Damage
    {
        get { return this.damage + this.inventory.TotalDamageBonus; }
        set { this.damage = value; }
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
    public ICollection<IItem> Items
    {
        get
        {
            var commonItems = (IDictionary<string, IItem>)typeof(HeroInventory)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(fi => fi.GetCustomAttributes()
                    .Any(ca => ca.GetType() == typeof(ItemAttribute)))
                .GetValue(this.Inventory);

            return commonItems.Values;
        }
    }

    public IInventory Inventory
    {
        get => this.inventory;
        private set => this.inventory = value;
    }

    public void AddRecipe(IRecipe recipe)
    {
        this.Inventory.AddRecipeItem(recipe);
    }
    
    public int CompareTo(IHero other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }
        if (ReferenceEquals(null, other))
        {
            return 1;
        }
        var primary = this.PrimaryStats.CompareTo(other.PrimaryStats);
        if (primary != 0)
        {
            return primary;
        }
        return this.SecondaryStats.CompareTo(other.SecondaryStats);
    }

    public string ShortToString()
    {
        var items = this.Items.Any()
            ? string.Join(", ", this.Items.Select(i => i.Name))
            : "None";

        var builder = new StringBuilder()
            .AppendLine($"{this.GetType().Name}: {this.Name}")
            .AppendLine($"###HitPoints: {this.HitPoints}")
            .AppendLine($"###Damage: {this.Damage}")
            .AppendLine($"###Strength: {this.Strength}")
            .AppendLine($"###Agility: {this.Agility}")
            .AppendLine($"###Intelligence: {this.Intelligence}")
            .AppendLine($"###Items: {items}");

        var result = builder.ToString().TrimEnd();

        return result;
    }

    public override string ToString()
    {
        var builder = new StringBuilder()
            .AppendLine($"Hero: {this.Name}, Class: {this.GetType().Name}")
            .AppendLine($"HitPoints: {this.HitPoints}, Damage: {this.Damage}")
            .AppendLine($"Strength: {this.Strength}")
            .AppendLine($"Agility: {this.Agility}")
            .AppendLine($"Intelligence: {this.Intelligence}")
            .Append("Items: ");

        builder
            .AppendLine(this.Items.Count == 0 
                ? "None" 
                : $"{Environment.NewLine}{string.Join(Environment.NewLine, this.Items.Select(i => i.ToString()))}");

        var result = builder.ToString().TrimEnd();

        return result;
    }
}