namespace WildFarm.Models.Animals
{
    using Models.Animals.AbstractTypes;

    public class Mouse : Mammal
    {
        public Mouse(string animalName, double animalWeight, string animalLivingRegion) 
            : base(animalName, animalWeight, animalLivingRegion)
        {
        }
        
        public override string MakeSound()
        {
            return "SQUEEEAAAK!";
        }
    }
}
