namespace P02.KingsGambit.Models
{
    using Contracts;
    using System;

    public class BaseCitizen : INamable
    {
        private const string InvalidNameMsg = "Name is invalid!";

        private string name;

        public BaseCitizen(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(InvalidNameMsg);
                }

                this.name = value;
            }
        }

    }
}
