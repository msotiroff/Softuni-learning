using P06.Animals.Contracts;
using System;
using System.Text;

namespace P06.Animals.Models
{
    public class Animal : ISoundProducable
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
                if (string.IsNullOrWhiteSpace(value))
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.name = value;
            }
        }

        public virtual string ProduceSound()
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
