namespace InfernoInfinity.Core.Implementations.Factories
{
    using InfernoInfinity.Core.Contracts;
    using InfernoInfinity.Models.Contracts;
    using InfernoInfinity.Models.Enums;
    using System;
    using System.Linq;
    using System.Reflection;

    public class WeaponFactory : IFactory<IWeapon>
    {
        private const string InvalidRarity = "Invalid weapon rarity!";
        private const string InvalidWeaponType = "Invalid weapon type!";

        public IWeapon CreateInstance(params string[] parameters)
        {
            // string type, string name, string rarity

            var type = parameters[0];
            var name = parameters[1];
            Rarity rarity;
            if (!Enum.TryParse<Rarity>(parameters[2], out rarity))
            {
                throw new ArgumentException(InvalidRarity);
            }

            var weaponType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces()
                    .Contains(typeof(IWeapon)))
                .Where(t => !t.IsAbstract)
                .FirstOrDefault(t => t.Name == type);

            if (weaponType == null)
            {
                throw new ArgumentException(InvalidWeaponType);
            }

            var weapon = (IWeapon)Activator.CreateInstance(weaponType, new object[] { name, rarity });

            return weapon;
        }
    }
}
