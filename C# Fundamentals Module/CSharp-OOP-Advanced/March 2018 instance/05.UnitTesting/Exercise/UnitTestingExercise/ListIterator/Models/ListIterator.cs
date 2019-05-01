namespace ListIterator.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ListIterator
    {
        private const string InvalidOperationErrorMsg = "Invalid Operation!";

        private IList<string> items;
        private int currentIndex;

        public ListIterator(params string[] items)
        {
            this.ValidateData(items);
            this.currentIndex = 0;
        }

        public IReadOnlyList<string> Items => this.items.ToList();

        public string Print()
        {
            if (this.items.Any())
            {
                return this.items[this.currentIndex];
            }

            throw new InvalidOperationException(InvalidOperationErrorMsg);
        }

        public bool Move()
        {
            if (!this.HasNext())
            {
                return false;
            }

            this.currentIndex++;
            return true;
        }

        public bool HasNext() => this.currentIndex < this.items.Count - 1;

        private void ValidateData(string[] items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(InvalidOperationErrorMsg);
            }

            this.items = items;
        }
    }
}
