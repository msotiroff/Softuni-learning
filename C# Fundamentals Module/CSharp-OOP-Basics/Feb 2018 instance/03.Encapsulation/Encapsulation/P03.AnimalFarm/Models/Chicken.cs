﻿namespace P03.AnimalFarm.Models
{
    using System;

    public class Chicken
    {
        public const int MinAge = 0;
        public const int MaxAge = 15;

        private string name;
        private int age;

        public Chicken(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{nameof(this.Name)} cannot be empty.");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;
            private set
            {
                if (value < 0 || value > 15)
                {
                    throw new ArgumentException($"{nameof(this.Age)} should be between {MinAge} and {MaxAge}.");
                }

                this.age = value;
            }
        }

        public double ProductPerDay
        {
			get => this.CalculateProductPerDay();
        }

        private double CalculateProductPerDay()
        {
            switch (this.age)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return 1.5;
                case 4:
                case 5:
                case 6:
                case 7:
                    return 2;
                case 8:
                case 9:
                case 10:
                case 11:
                    return 1;
                default:
                    return 0.75;
            }
        }

        public override string ToString()
        {
            return string.Format("Chicken {0} (age {1}) can produce {2} eggs per day.",
                this.name,
                this.age,
                this.ProductPerDay);
        }
    }
}
