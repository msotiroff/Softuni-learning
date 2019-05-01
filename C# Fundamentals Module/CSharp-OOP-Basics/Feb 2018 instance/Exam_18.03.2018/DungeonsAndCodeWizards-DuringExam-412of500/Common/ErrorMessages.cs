namespace DungeonsAndCodeWizards.Common
{
    public class ErrorMessages
    {
        public const string NotEnoughSpaceInTheBag = "Bag is full!";
        public const string BagIsEmpry = "Bag is empty!";
        public const string ItemDoesNotExistInThisBag = "No item with name {0} in bag!";

        public const string InvalidCharacterName = "Name cannot be null or whitespace!";

        public const string CharacterIsNotAlive = "Must be alive to perform this action!";

        public const string CannotAttackSelf = "Cannot attack self!";
        public const string FriendlyFireUnavailable = "Friendly fire! Both characters are from {0} faction!";
        public const string CannotHealEnemy = "Cannot heal enemy character!";

        public const string InvalidTypeOfFaction = "Invalid faction \"{0}\"!";
        public const string InvalidCharacterType = "Invalid character type \"{0}\"!";
        public const string InvalidItemType = "Invalid item \"{0}\"!";
        public const string CharacterNotFound = "Character {0} not found!";
        public const string NoItemsLeftInThePool = "No items left in pool!";
        public const string AttackerCannotAttack = "{0} cannot attack!";
        public const string HealerCannotHeal = "{0} cannot heal!";

    }
}
