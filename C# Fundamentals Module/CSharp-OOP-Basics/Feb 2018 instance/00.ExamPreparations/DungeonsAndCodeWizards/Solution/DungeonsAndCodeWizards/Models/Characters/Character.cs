using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Enums;
using DungeonsAndCodeWizards.Models.Items;
using System;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public abstract class Character
    {
        private const double DefaultRestHealMultiplier = 0.2;
        private const string NotAliveErrorMsg = "Must be alive to perform this action!";
        private const string InvalidNameErrorMsg = "Name cannot be null or whitespace!";

        private string name;
        private double health;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.BaseHealth = health;
            this.BaseArmor = armor;

            this.Name = name;
            this.Health = health;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;

            this.IsAlive = true;
        }

        public double Armor
        {
            get => this.armor;
            set
            {
                this.armor = Math.Max(0, Math.Min(this.BaseArmor, value));
            }
        }

        public double Health
        {
            get => this.health;

            set
            {
                this.health = Math.Max(0, Math.Min(this.BaseHealth, value));
                if (this.Health == 0)
                {
                    this.IsAlive = false;
                }
            }
        }

        public Bag Bag { get; }

        public Faction Faction { get; }

        public double BaseHealth { get; }

        public double BaseArmor { get; }

        public double AbilityPoints { get; }

        public bool IsAlive { get; private set; }

        public virtual double RestHealMultiplier => DefaultRestHealMultiplier;

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidNameErrorMsg);
                }

                this.name = value;
            }
        }

        public void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(NotAliveErrorMsg);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            var pointsToTake = Math.Min(hitPoints, this.Armor);

            this.Armor -= pointsToTake;
            hitPoints -= pointsToTake;

            this.Health -= hitPoints;
        }

        public void Rest()
        {
            this.EnsureAlive();

            var restValue = this.BaseHealth * this.RestHealMultiplier;

            this.Health += restValue;
        }

        public void UseItem(Item item)
        {
            this.EnsureAlive();

            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            this.EnsureAlive();
            character.EnsureAlive();

            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            this.EnsureAlive();
            character.EnsureAlive();

            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            this.EnsureAlive();

            this.Bag.AddItem(item);
        }

        public override string ToString()
        {
            var status = this.IsAlive
                ? "Alive"
                : "Dead";

            return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {status}";
        }
    }
}
