namespace DungeonsAndCodeWizards.Models.Implementations.Bags
{
    public class Satchel : Bag
    {
        private const int InitialCapacity = 20;

        public Satchel() 
            : base(InitialCapacity)
        {
        }
    }
}
