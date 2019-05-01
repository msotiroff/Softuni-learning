using DungeonsAndCodeWizards.Common;
using DungeonsAndCodeWizards.Models.Contracts;
using DungeonsAndCodeWizards.Models.Enums;
using DungeonsAndCodeWizards.Models.Implementations.Bags;
using System;

namespace DungeonsAndCodeWizards.Models.Implementations.Characters
{
    public class Cleric : Character, IHealable
    {
        private const double InitialBaseHealth = 50.0;
        private const double InitialBaseArmor = 25.0;
        private const double InitialAbilityPoints = 40.0;

        public Cleric(string name, Faction faction)
            : base(name, InitialBaseHealth, InitialBaseArmor, InitialAbilityPoints, new Backpack(), faction)
        {
        }

        public override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException(ErrorMessages.CharacterIsNotAlive);
            }

            if (this.Faction.ToString() != character.Faction.ToString())
            {
                throw new InvalidOperationException(ErrorMessages.CannotHealEnemy);
            }

            character.Health = Math.Min(character.BaseHealth, character.Health + this.AbilityPoints);
        }
    }
}
