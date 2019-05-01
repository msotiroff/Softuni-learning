public interface IHeroManager
{
    string AddHero(IHero hero);
    string AddItemToHero(IItem item, string heroName);
    string AddRecipeToHero(IRecipe recipe, string heroName);
    string GenerateResult();
    string Inspect(string heroName);
}