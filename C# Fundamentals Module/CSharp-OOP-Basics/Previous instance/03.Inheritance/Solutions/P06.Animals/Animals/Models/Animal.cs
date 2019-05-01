using System;
using System.Text;

namespace Animals.Models
{
    public class Animal
    {
        private string name;
        private int age;
        private string gender;

        protected Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Gender
        {
            get => this.gender;

            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.gender = value;
            }
        }

        public int Age
        {
            get => this.age;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.age = value;
            }
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.name = value;
            }
        }

        protected virtual string ProduceSound()
        {
            return string.Empty;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(this.GetType().Name);
            result.AppendLine($"{this.name} {this.age} {this.gender}");
            result.Append(this.ProduceSound());

            return result.ToString();
        }
    }
}
