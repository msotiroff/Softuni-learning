namespace DungeonsAndCodeWizards.Factories
{
    using DungeonsAndCodeWizards.Common;
    using DungeonsAndCodeWizards.Models.Implementations.Items;
    using System;

    public class ItemFactory
    {
        public Item CreateItem(string itemName)
        {
            Item item = null;

            switch (itemName)
            {
                case nameof(HealthPotion):
                    item = new HealthPotion();
                    break;
                case nameof(PoisonPotion):
                    item = new PoisonPotion();
                    break;
                case nameof(ArmorRepairKit):
                    item = new ArmorRepairKit();
                    break;
                default:
                    throw new ArgumentException(string.Format(ErrorMessages.InvalidItemType, itemName));
            }

            return item;
        }
    }
}
