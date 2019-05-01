namespace WildFarm.Models.Animals
{
    using Models.Animals.AbstractTypes;

    public class Zebra : Mammal
    {
        public Zebra(string animalName, double animalWeight, string animalLivingRegion) 
            : base(animalName, animalWeight, animalLivingRegion)
        {
        }

        public override string MakeSound()
        {
            return "Zs";
        }
    }
}
