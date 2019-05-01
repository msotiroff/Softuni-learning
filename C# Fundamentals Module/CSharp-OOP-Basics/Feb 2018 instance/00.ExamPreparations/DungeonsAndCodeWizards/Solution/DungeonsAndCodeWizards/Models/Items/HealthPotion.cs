using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class HealthPotion : Item
    {
        private const int DefaultWeigth = 5;
        private const int HealthIncreaser = 20;

        public HealthPotion() 
            : base(DefaultWeigth)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health += HealthIncreaser;
        }
    }
}
