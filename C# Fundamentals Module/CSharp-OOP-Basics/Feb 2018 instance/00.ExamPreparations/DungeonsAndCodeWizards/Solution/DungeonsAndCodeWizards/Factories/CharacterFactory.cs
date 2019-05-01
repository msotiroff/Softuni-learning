using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Enums;
using System;
using System.Linq;
using System.Reflection;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string factionType, string characterType, string name)
        {
            Faction faction;
            if (!Enum.TryParse<Faction>(factionType, out faction))
            {
                throw new ArgumentException($"Invalid faction \"{factionType}\"!");
            }

            var type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.BaseType == typeof(Character)
                    && !t.IsAbstract)
                .FirstOrDefault(t => t.Name == characterType);

            if (type == null)
            {
                throw new ArgumentException($"Invalid character type \"{characterType}\"!");
            }

            var character = (Character)Activator.CreateInstance(type, new object[] { name, faction });

            return character;
        }
    }
}
