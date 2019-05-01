namespace P01.Person.Models
{
    using System;

    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public virtual int Age
        {
            get => this.age;

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age must be positive!");
                }

                this.age = value;
            }
        }

        public virtual string Name
        {
            get => this.name;

            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Name's length should not be less than 3 symbols!");
                }

                this.name = value;
            }
        }

        public override string ToString()
        {
            return String.Format("Name: {0}, Age: {1}",
                         this.Name,
                         this.Age);

        }
    }
}
