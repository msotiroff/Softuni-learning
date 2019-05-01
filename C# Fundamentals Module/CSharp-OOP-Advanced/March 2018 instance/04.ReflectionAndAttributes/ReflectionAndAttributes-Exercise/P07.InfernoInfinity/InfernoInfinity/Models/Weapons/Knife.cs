namespace InfernoInfinity.Models.Weapons
{
    using InfernoInfinity.Models.Contracts;
    using InfernoInfinity.Models.Enums;

    public class Knife : BaseWeapon
    {
        private const int DefaultMinDamage = 3;
        private const int DefaultMaxDamage = 4;
        private const int SocketsCount = 2;
        
        public Knife(string name, Rarity rarity) 
            : base(name, DefaultMinDamage, DefaultMaxDamage, new IGem[SocketsCount], rarity)
        {
        }
    }
}
