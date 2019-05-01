namespace DungeonsAndCodeWizards.Factories
{
    using DungeonsAndCodeWizards.Common;
    using DungeonsAndCodeWizards.Models.Enums;
    using DungeonsAndCodeWizards.Models.Implementations.Characters;
    using System;

    public class CharacterFactory
    {
        public Character CreateCharacter(string factionName, string charType, string charName)
        {
            Faction faction;
            var isFactionValid = Enum.TryParse(factionName, out faction);

            if (!isFactionValid)
            {
                throw new ArgumentException(string.Format(ErrorMessages.InvalidTypeOfFaction, factionName));
            }

            var characterType = charType;
            var name = charName;

            Character character = null;

            switch (characterType)
            {
                case nameof(Warrior):
                    character = new Warrior(name, faction);
                    break;
                case nameof(Cleric):
                    character = new Cleric(name, faction);
                    break;
                default:
                    throw new ArgumentException(string.Format(ErrorMessages.InvalidCharacterType, characterType));
            }

            return character;
        }
    }
}
