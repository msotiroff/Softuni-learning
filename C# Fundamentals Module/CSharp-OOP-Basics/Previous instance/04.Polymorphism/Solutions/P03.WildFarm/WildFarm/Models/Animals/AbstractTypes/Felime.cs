namespace WildFarm.Models.Animals.AbstractTypes
{
    public abstract class Felime : Mammal
    {
        protected Felime(string animalName, double animalWeight, string animalLivingRegion)
            : base(animalName, animalWeight, animalLivingRegion)
        {
        }
    }
}
