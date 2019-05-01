using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Enums;
using System;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Cleric : Character, IHealable
    {
        private const string HealingEnemyErrorMsg = "Cannot heal enemy character!";
        private const double DefaultBaseHealth = 50.0;
        private const double DefaultBaseArmor = 25.0;
        private const double DefaultAbilityPoints = 40.0;

        public Cleric(string name, Faction faction) 
            : base(name, DefaultBaseHealth, DefaultBaseArmor, DefaultAbilityPoints, new Backpack(), faction)
        {
        }

        public override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {
            this.EnsureAlive();
            character.EnsureAlive();

            if (this.Faction.ToString() != character.Faction.ToString())
            {
                throw new InvalidOperationException(HealingEnemyErrorMsg);
            }

            character.Health += this.AbilityPoints;
        }
    }
}
