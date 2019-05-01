namespace DungeonsAndCodeWizards.Models.Implementations.Bags
{
    using DungeonsAndCodeWizards.Common;
    using DungeonsAndCodeWizards.Models.Implementations.Items;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Bag
    {
        private List<Item> items;

        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity { get; private set; } = 100;

        public IReadOnlyCollection<Item> Items => this.items;

        public int Load => this.Items.Sum(i => i.Weight);

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(ErrorMessages.NotEnoughSpaceInTheBag);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.Items.Count() == 0)
            {
                throw new InvalidOperationException(ErrorMessages.BagIsEmpry);
            }

            if (!this.Items.Any(i => i.GetType().Name == name))
            {
                throw new ArgumentException(string.Format(ErrorMessages.ItemDoesNotExistInThisBag, name));
            }

            var item = this.Items
                .Last(i => i.GetType().Name == name);

            this.items.Remove(item);

            return item;
        }
    }
}
