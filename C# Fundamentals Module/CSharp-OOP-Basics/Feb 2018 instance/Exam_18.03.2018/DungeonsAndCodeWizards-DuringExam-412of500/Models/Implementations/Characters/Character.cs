namespace DungeonsAndCodeWizards.Models.Implementations.Characters
{
    using DungeonsAndCodeWizards.Common;
    using DungeonsAndCodeWizards.Models.Enums;
    using DungeonsAndCodeWizards.Models.Implementations.Bags;
    using DungeonsAndCodeWizards.Models.Implementations.Items;
    using System;

    public abstract class Character
    {
        private const double InitialRestMultiplier = 0.2;

        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.Health = health;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.RestHealMultiplier = InitialRestMultiplier;
            this.IsAlive = true;
            this.BaseHealth = health;
            this.BaseArmor = armor;
        }

        public double AbilityPoints { get; private set; }

        public Bag Bag { get; private set; }

        public Faction Faction { get; private set; }

        public bool IsAlive { get; private set; }

        public virtual double RestHealMultiplier { get; protected set; }

        public double Armor
        {
            get => this.armor;
            set
            {
                this.armor = value;
            }
        }


        public double BaseArmor
        {
            get => this.baseArmor;
            private set
            {
                this.baseArmor = value;
            }
        }
        
        public double Health
        {
            get => this.health;

            set
            {
                if (value <= 0)
                {
                    this.IsAlive = false;
                    this.health = 0;
                }
                else
                {
                    this.health = value;
                }
            }
        }
        
        public double BaseHealth
        {
            get => this.baseHealth;

            private set
            {
                this.baseHealth = value;
            }
        }
        
        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ErrorMessages.InvalidCharacterName);
                }
                this.name = value;
            }
        }

        public void TakeDamage(double hitPoints)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ErrorMessages.CharacterIsNotAlive);
            }

            var pointsToTakeByArmor = Math.Min(this.Armor, hitPoints);

            this.Armor -= pointsToTakeByArmor;

            var hitPointsLeft = hitPoints - pointsToTakeByArmor;

            this.Health -= hitPointsLeft;
        }

        public void Rest()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ErrorMessages.CharacterIsNotAlive);
            }

            var newValue = this.Health + this.BaseHealth * this.RestHealMultiplier;

            this.Health = Math.Min(newValue, this.BaseHealth);
        }

        public void UseItem(Item item)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ErrorMessages.CharacterIsNotAlive);
            }

            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException(ErrorMessages.CharacterIsNotAlive);
            }

            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException(ErrorMessages.CharacterIsNotAlive);
            }

            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ErrorMessages.CharacterIsNotAlive);
            }

            this.Bag.AddItem(item);
        }

        public override string ToString()
        {
            var status = this.IsAlive ? "Alive" : "Dead";
            return $"{name} - HP: {health}/{baseHealth}, AP: {armor}/{baseArmor}, Status: {status}";
        }
    }
}
