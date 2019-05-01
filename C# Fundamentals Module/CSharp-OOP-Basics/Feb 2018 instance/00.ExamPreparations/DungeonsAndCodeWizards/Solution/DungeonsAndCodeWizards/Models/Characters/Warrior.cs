using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Enums;
using System;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Warrior : Character, IAttackable
    {
        private const string FriendlyFireErrorMsg = "Friendly fire! Both characters are from {0} faction!";
        private const string AttackSelfErrorMsg = "Cannot attack self!";
        private const double DefaultBaseHealth = 100.0;
        private const double DefaultBaseArmor = 50.0;
        private const double DefaultAbilityPoints = 40.0;

        public Warrior(string name, Faction faction) 
            : base(name, DefaultBaseHealth, DefaultBaseArmor, DefaultAbilityPoints, new Satchel(), faction)
        {
        }

        public void Attack(Character character)
        {
            this.EnsureAlive();
            character.EnsureAlive();

            if (this.Equals(character))
            {
                throw new InvalidOperationException(AttackSelfErrorMsg);
            }

            if (this.Faction.ToString() == character.Faction.ToString())
            {
                throw new ArgumentException(string.Format(FriendlyFireErrorMsg, this.Faction.ToString()));
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
