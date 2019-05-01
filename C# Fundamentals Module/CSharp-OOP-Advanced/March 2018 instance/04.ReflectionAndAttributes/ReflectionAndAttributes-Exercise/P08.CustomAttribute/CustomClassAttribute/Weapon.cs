namespace CustomClassAttribute
{
    [WeaponInfo("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
    public class Weapon
    {
        //public BaseWeapon(string name, int minDamage, int maxDamage, IGem[] sockets, Rarity rarity)
        //{
        //    this.Name = name;
        //    this.MinDamage = minDamage * (int)rarity;
        //    this.MaxDamage = maxDamage * (int)rarity;
        //    this.Sockets = sockets;
        //}

        public string Name { get; private set; }

        public int MinDamage { get; private set; }

        public int MaxDamage { get; private set; }
    }
}
