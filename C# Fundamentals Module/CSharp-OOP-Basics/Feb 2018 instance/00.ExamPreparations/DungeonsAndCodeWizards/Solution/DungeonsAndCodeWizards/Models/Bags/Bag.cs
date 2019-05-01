using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public abstract class Bag
    {
        private const string BagFullErrorMsg = "Bag is full!";
        private const string BagEmptyErrorMsg = "Bag is empty!";
        private const string MissingItemErrorMsg = "No item with name {0} in bag!";

        private List<Item> items;

        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public IReadOnlyCollection<Item> Items => this.items;

        public int Capacity { get; }

        public int Load => this.Items.Sum(i => i.Weight);

        public void AddItem(Item item)
        {
            if (item.Weight + this.Load > this.Capacity)
            {
                throw new InvalidOperationException(BagFullErrorMsg);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.Items.Count == 0)
            {
                throw new InvalidOperationException(BagEmptyErrorMsg);
            }

            var item = this.items.FirstOrDefault(i => i.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException(string.Format(MissingItemErrorMsg, name));
            }

            this.items.Remove(item);

            return item;
        }
    }
}
