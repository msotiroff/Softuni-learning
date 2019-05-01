using System;
using System.Linq;

namespace DataBase.Models
{
    public class Database
    {
        private const string DatabaseEmpty = "There is no elements in the database";
        private const string DatabaseOverflowErrorMessage = "You cannot add more than {0} elements at the database!";
        private const int Capacity = 16;

        private int currentIndex;
        private long[] data;

        private Database()
        {
            this.data = new long[Capacity];
        }

        public Database(params long[] numbers)
            : this()
        {
            this.AddInitialNumbers(numbers);
        }

        public void Add(long number)
        {
            if (this.currentIndex == Capacity)
            {
                throw new InvalidOperationException(string.Format(DatabaseOverflowErrorMessage, Capacity));
            }

            this.data[currentIndex] = number;
            currentIndex++;
        }

        public void Remove()
        {
            if (currentIndex == 0)
            {
                throw new InvalidOperationException(DatabaseEmpty);
            }

            this.currentIndex--;
            this.data[currentIndex] = default(long);
        }

        public long[] Fetch() => this.data.Take(this.currentIndex).ToArray();

        private void AddInitialNumbers(long[] numbers)
        {
            if (numbers.Length > Capacity)
            {
                throw new InvalidOperationException(string.Format(DatabaseOverflowErrorMessage, Capacity));
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                this.Add(numbers[i]);
            }
        }

        public long this[int index] => this.data[index];
    }
}
