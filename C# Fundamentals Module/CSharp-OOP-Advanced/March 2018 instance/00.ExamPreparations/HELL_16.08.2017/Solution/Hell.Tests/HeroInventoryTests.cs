using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

[TestFixture]
public class HeroInventoryTests
{
    private HeroInventory inventory;

    [SetUp]
    public void InitializeInventory()
    {
        this.inventory = new HeroInventory();
    }

    [Test]
    public void StrenghtBonusShouldBeCorrect()
    {
        var strengthBonus = 10;
        var agilityBonus = 20;
        var intelligenceBonus = 30;
        var hitPointsBonus = 40;
        var damageBonus = 50;

        var item = new CommonItem("Axe", strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus);
        this.inventory.AddCommonItem(item);

        Assert.AreEqual(strengthBonus, this.inventory.TotalStrengthBonus);
    }

    [Test]
    public void AgilityBonusShouldBeCorrect()
    {
        var strengthBonus = 10;
        var agilityBonus = 20;
        var intelligenceBonus = 30;
        var hitPointsBonus = 40;
        var damageBonus = 50;

        var item = new CommonItem("Axe", strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus);
        this.inventory.AddCommonItem(item);

        Assert.AreEqual(agilityBonus, this.inventory.TotalAgilityBonus);
    }

    [Test]
    public void IntelligenceBonusShouldBeCorrect()
    {
        var strengthBonus = 10;
        var agilityBonus = 20;
        var intelligenceBonus = 30;
        var hitPointsBonus = 40;
        var damageBonus = 50;

        var item = new CommonItem("Axe", strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus);
        this.inventory.AddCommonItem(item);

        Assert.AreEqual(intelligenceBonus, this.inventory.TotalIntelligenceBonus);
    }

    [Test]
    public void HitpointsBonusShouldBeCorrect()
    {
        var strengthBonus = 10;
        var agilityBonus = 20;
        var intelligenceBonus = 30;
        var hitPointsBonus = 40;
        var damageBonus = 50;

        var item = new CommonItem("Axe", strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus);
        this.inventory.AddCommonItem(item);

        Assert.AreEqual(hitPointsBonus, this.inventory.TotalHitPointsBonus);
    }

    [Test]
    public void DamageBonusShouldBeCorrect()
    {
        var strengthBonus = 10;
        var agilityBonus = 20;
        var intelligenceBonus = 30;
        var hitPointsBonus = 40;
        var damageBonus = 50;

        var item = new CommonItem("Axe", strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus);
        this.inventory.AddCommonItem(item);

        Assert.AreEqual(damageBonus, this.inventory.TotalDamageBonus);
    }

    [Test]
    public void AddCommonItemShouldCombineCommonItemsWhenHasAllOfThem()
    {
        var item1 = new CommonItem("Axe", 20, 20, 20, 20, 20);
        var item2 = new CommonItem("Knife", 30, 30, 30, 30, 30);
        this.inventory.AddCommonItem(item1);

        var recipe = new RecipeItem("SomeRecipe", 200, 200, 200, 200, 200, new List<string>() { "Axe", "Knife" });
        this.inventory.AddRecipeItem(recipe);

        this.inventory.AddCommonItem(item2);
        
        var itemsCount = this.GetCommonItems().Count;

        Assert.AreEqual(1, itemsCount);
    }

    [Test]
    public void AddCommonItemShouldIncreaseTotalBonusesSum()
    {
        var item1 = new CommonItem("Axe", 20, 20, 20, 20, 20);
        var item2 = new CommonItem("Knife", 30, 30, 30, 30, 30);
        this.inventory.AddCommonItem(item1);

        var recipe = new RecipeItem("SomeRecipe", 200, 200, 200, 200, 200, new List<string>() { "Axe", "Knife" });
        this.inventory.AddRecipeItem(recipe);

        this.inventory.AddCommonItem(item2);
        
        var statsSum = this.inventory.TotalAgilityBonus
            + this.inventory.TotalDamageBonus
            + this.inventory.TotalHitPointsBonus
            + this.inventory.TotalIntelligenceBonus
            + this.inventory.TotalStrengthBonus;

        Assert.AreEqual(1000, statsSum);
    }

    [Test]
    public void AddRecipeShouldDeleteOnlyNeededItems()
    {
        var item1 = new CommonItem("Axe", 20, 20, 20, 20, 20);
        var item2 = new CommonItem("Knife", 30, 30, 30, 30, 30);
        var item3 = new CommonItem("Hammer", 30, 30, 30, 30, 30);
        this.inventory.AddCommonItem(item1);
        this.inventory.AddCommonItem(item2);
        this.inventory.AddCommonItem(item3);

        var recipe = new RecipeItem("SomeRecipe", 200, 200, 200, 200, 200, new List<string>() { "Axe", "Knife" });
        this.inventory.AddRecipeItem(recipe);

        var itemsCount = this.GetCommonItems().Count;

        Assert.AreEqual(2, itemsCount);
    }

    [Test]
    public void AddRecipeShouldSetNewItemNameToRecipeName()
    {
        var item1 = new CommonItem("Axe", 20, 20, 20, 20, 20);
        var item2 = new CommonItem("Knife", 30, 30, 30, 30, 30);
        this.inventory.AddCommonItem(item1);
        this.inventory.AddCommonItem(item2);

        var recipe = new RecipeItem("SomeRecipe", 200, 200, 200, 200, 200, new List<string>() { "Axe", "Knife" });
        this.inventory.AddRecipeItem(recipe);

        var itemName = this.GetCommonItems().First().Name;

        Assert.AreEqual("SomeRecipe", itemName);
    }

    [Test]
    public void AddRecipeShouldIncreaseTotalBonusesSum()
    {
        var item1 = new CommonItem("Axe", 20, 20, 20, 20, 20);
        var item2 = new CommonItem("Knife", 30, 30, 30, 30, 30);
        this.inventory.AddCommonItem(item1);
        this.inventory.AddCommonItem(item2);

        var recipe = new RecipeItem("SomeRecipe", 200, 200, 200, 200, 200, new List<string>() { "Axe", "Knife" });
        this.inventory.AddRecipeItem(recipe);

        var statsSum = this.inventory.TotalAgilityBonus
            + this.inventory.TotalDamageBonus
            + this.inventory.TotalHitPointsBonus
            + this.inventory.TotalIntelligenceBonus
            + this.inventory.TotalStrengthBonus;

        Assert.AreEqual(1000, statsSum);
    }

    [Test]
    public void AddRecipeShouldCombineCommonItemsWhenHasAllOfThem()
    {
        var item1 = new CommonItem("Axe", 20, 20, 20, 20, 20);
        var item2 = new CommonItem("Knife", 30, 30, 30, 30, 30);
        this.inventory.AddCommonItem(item1);
        this.inventory.AddCommonItem(item2);

        var recipe = new RecipeItem("SomeRecipe", 200, 200, 200, 200, 200, new List<string>() { "Axe", "Knife" });
        this.inventory.AddRecipeItem(recipe);

        var itemsCount = this.GetCommonItems().Count;

        Assert.AreEqual(1, itemsCount);
    }

    [Test]
    public void AddItemShouldIncreaseStatsCorrectly()
    {
        var item1 = new CommonItem("Axe", 20, 20, 20, 20, 20);
        var item2 = new CommonItem("Knife", 30, 30, 30, 30, 30);

        this.inventory.AddCommonItem(item1);
        this.inventory.AddCommonItem(item2);

        var statsSum = this.inventory.TotalAgilityBonus
            + this.inventory.TotalDamageBonus
            + this.inventory.TotalHitPointsBonus
            + this.inventory.TotalIntelligenceBonus
            + this.inventory.TotalStrengthBonus;

        Assert.AreEqual(250, statsSum);
    }

    [Test]
    public void InitialTotalStatsShouldBeCorrect()
    {
        var totalStats = this.inventory.TotalAgilityBonus
            + this.inventory.TotalDamageBonus
            + this.inventory.TotalHitPointsBonus
            + this.inventory.TotalIntelligenceBonus
            + this.inventory.TotalStrengthBonus;

        Assert.AreEqual(0, totalStats);
    }

    [Test]
    public void AddRecipeShouldThrowExceptionWhenTryToAddNull()
    {
        Assert.That(() => this.inventory.AddRecipeItem(null), Throws.Exception);
    }

    [Test]
    public void AddRecipeItemShouldAddReciepeToInnerCollection()
    {
        var recipe = new RecipeItem("SomeRecipe", 20, 20, 20, 20, 20, new List<string>() { "Axe", "Knife" });

        this.inventory.AddRecipeItem(recipe);

        var recipesCount = this.GetRecipes().Count;

        Assert.AreEqual(1, recipesCount);
    }

    [Test]
    public void AddCommonShouldThrowExceptionWhenTryToAddNull()
    {
        Assert.That(() => this.inventory.AddCommonItem(null), Throws.Exception);
    }

    [Test]
    public void AddCommonItemShouldAddItemToInnerCollection()
    {
        var item = new CommonItem("Axe", 20, 20, 20, 20, 20);

        this.inventory.AddCommonItem(item);

        var items = GetCommonItems();

        var actual = items.Count;

        Assert.AreEqual(1, actual);
    }

    private ICollection<IItem> GetCommonItems()
    {
        var items = (Dictionary<string, IItem>)typeof(HeroInventory)
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .Where(fi => fi.GetCustomAttribute<ItemAttribute>() != null)
            .FirstOrDefault()
            ?.GetValue(this.inventory);

        var itemCollection = (ICollection<IItem>)items.Values;

        return itemCollection;
    }

    private ICollection<IRecipe> GetRecipes()
    {
        var items = (Dictionary<string, IRecipe>)typeof(HeroInventory)
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .FirstOrDefault(fi => fi.FieldType == typeof(Dictionary<string, IRecipe>))
            ?.GetValue(this.inventory);

        var itemCollection = (ICollection<IRecipe>)items.Values;

        return itemCollection;
    }
}
