using DungeonsAndCodeWizards.Common;
using DungeonsAndCodeWizards.Models.Implementations.Characters;
using System;

namespace DungeonsAndCodeWizards.Models.Implementations.Items
{
    public class ArmorRepairKit : Item
    {
        private const int InitialWeight = 10;

        public ArmorRepairKit() 
            : base(InitialWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ErrorMessages.CharacterIsNotAlive);
            }

            character.Armor = character.BaseArmor;
        }
    }
}
