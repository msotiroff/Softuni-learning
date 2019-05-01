namespace DungeonsAndCodeWizards.Models.Implementations.Items
{
    using DungeonsAndCodeWizards.Models.Implementations.Characters;

    public abstract class Item
    {
        protected Item(int weight)
        {
            this.Weight = weight;
        }

        public int Weight { get; private set; }

        public abstract void AffectCharacter(Character character);
    }
}
