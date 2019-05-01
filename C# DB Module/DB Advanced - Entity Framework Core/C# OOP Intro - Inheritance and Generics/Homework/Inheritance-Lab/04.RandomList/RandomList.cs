namespace _04.RandomList
{
    using System;
    using System.Collections.Generic;

    public class RandomList : List<string>
    {
        private Random random;

        public RandomList()
            : base()
        {
            this.random = new Random();
        }

        public string RandomString()
        {
            int index = random.Next(0, this.Count - 1);
            string removedString = this[index];
            this.RemoveAt(index);
            return removedString;
        }
    }
}
