using DungeonsAndCodeWizards.Common;
using DungeonsAndCodeWizards.Models.Contracts;
using DungeonsAndCodeWizards.Models.Enums;
using DungeonsAndCodeWizards.Models.Implementations.Bags;
using System;

namespace DungeonsAndCodeWizards.Models.Implementations.Characters
{
    public class Warrior : Character, IAttackable
    {
        private const double InitialBaseHealth = 100.0;
        private const double InitialBaseArmor = 50.0;
        private const double InitialAbilityPoints = 40.0;

        public Warrior(string name, Faction faction) 
            : base(name, InitialBaseHealth, InitialBaseArmor, InitialAbilityPoints, new Satchel(), faction)
        {
        }

        public void Attack(Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException(ErrorMessages.CharacterIsNotAlive);
            }
            if (this.Name == character.Name)
            {
                throw new InvalidOperationException(ErrorMessages.CannotAttackSelf);
            }
            if (this.Faction.ToString() == character.Faction.ToString())
            {
                throw new ArgumentException(string.Format(ErrorMessages.FriendlyFireUnavailable, this.Faction.ToString()));
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
