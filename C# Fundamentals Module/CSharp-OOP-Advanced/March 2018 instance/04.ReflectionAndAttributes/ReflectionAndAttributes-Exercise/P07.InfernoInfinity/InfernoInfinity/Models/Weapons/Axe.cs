namespace InfernoInfinity.Models.Weapons
{
    using InfernoInfinity.Models.Contracts;
    using InfernoInfinity.Models.Enums;

    public class Axe : BaseWeapon
    {
        private const int DefaultMinDamage = 5;
        private const int DefaultMaxDamage = 10;
        private const int SocketsCount = 4;
        
        public Axe(string name, Rarity rarity) 
            : base(name, DefaultMinDamage, DefaultMaxDamage, new IGem[SocketsCount], rarity)
        {
        }
    }
}
