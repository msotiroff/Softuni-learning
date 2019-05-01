namespace DungeonsAndCodeWizards.Models.Implementations.Bags
{
    public class Backpack : Bag
    {
        private const int InitialCapacity = 100;

        public Backpack() 
            : base(InitialCapacity)
        {
        }
    }
}
