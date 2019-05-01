using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class PoisonPotion : Item
    {
        private const int DefaultWeight = 5;
        private const int HealthDecreaser = 20;

        public PoisonPotion()
            : base(DefaultWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health -= HealthDecreaser;
        }
    }
}
