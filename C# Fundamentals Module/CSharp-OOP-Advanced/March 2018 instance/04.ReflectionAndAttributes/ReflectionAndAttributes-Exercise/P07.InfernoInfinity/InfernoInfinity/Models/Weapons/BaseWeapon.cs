namespace InfernoInfinity.Models.Weapons
{
    using InfernoInfinity.Models.Contracts;
    using InfernoInfinity.Models.Enums;
    using System;
    using System.Linq;

    public abstract class BaseWeapon : IWeapon
    {
        private const int MinDamageStrengthIncreaseValue = 2;
        private const int MinDamageAgilityIncreaseValue = 1;
        private const int MaxDamageStrengthIncreaseValue = 3;
        private const int MaxDamageAgilityIncreaseValue = 4;

        private string name;
        private int minDamage;
        private int maxDamage;
        private IGem[] sockets;
        
        protected BaseWeapon(string name, int minDamage, int maxDamage, IGem[] sockets, Rarity rarity)
        {
            this.Name = name;
            this.MinDamage = minDamage * (int)rarity;
            this.MaxDamage = maxDamage * (int)rarity;
            this.Sockets = sockets;
        }

        public string Name
        {
            get => name;
            private set => name = value;
        }

        public int MinDamage
        {
            get => minDamage;
            private set => minDamage = Math.Max(0, value);
        }

        public int MaxDamage
        {
            get => maxDamage;
            private set => maxDamage = Math.Max(0, value);
        }

        public IGem[] Sockets
        {
            get => sockets;
            private set => sockets = value;
        }

        public void AddGem(IGem gem, int index)
        {
            if (this.IsIndexValid(index))
            {
                this.Sockets[index] = gem;
            }
        }
        
        public void RemoveGem(int index)
        {
            if (this.IsIndexValid(index))
            {
                var removedGem = this.Sockets[index];

                if (removedGem != null)
                {
                    this.Sockets[index] = null;
                }
            }
        }

        private bool IsIndexValid(int index) => index >= 0 && index < this.Sockets.Length;

        public override string ToString()
        {
            var strengthPoints = this.Sockets.Where(g => g != null).Sum(g => g.Strength);
            var agilityPoints = this.Sockets.Where(g => g != null).Sum(g => g.Agility);
            var vitalityPoints = this.Sockets.Where(g => g != null).Sum(g => g.Vitality);

            var summedMinDamage = this.MinDamage 
                + strengthPoints * MinDamageStrengthIncreaseValue 
                + agilityPoints * MinDamageAgilityIncreaseValue;

            var summedMaxDamage = this.MaxDamage 
                + strengthPoints * MaxDamageStrengthIncreaseValue 
                + agilityPoints * MaxDamageAgilityIncreaseValue;

            return $"{this.Name}: {summedMinDamage}-{summedMaxDamage} Damage, " +
                $"+{strengthPoints} Strength, +{agilityPoints} Agility, +{vitalityPoints} Vitality";
        }
    }
}
