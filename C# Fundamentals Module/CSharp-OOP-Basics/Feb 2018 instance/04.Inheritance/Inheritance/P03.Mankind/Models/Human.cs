namespace P03.Mankind.Models
{
    using System;
    using System.Text;
    using static Common.Constants;

    public class Human
    {
        private string firstName;
        private string lastName;

        public Human (string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string LastName
        {
            get => this.lastName;

            private set
            {
                if (!char.IsUpper(value[0]))
                {
                    throw new ArgumentException(string.Format(InvalidNameBegining, nameof(lastName)));
                }
                if (value.Length < LastNameMinLength)
                {
                    throw new ArgumentException(string.Format(InvalidNameLength, LastNameMinLength, nameof(lastName)));
                }

                this.lastName = value;
            }
        }

        public string FirstName
        {
            get => this.firstName;

            private set
            {
                if (!char.IsUpper(value[0]))
                {
                    throw new ArgumentException(string.Format(InvalidNameBegining, nameof(firstName)));
                }
                if (value.Length < FirstNameMinLength)
                {
                    throw new ArgumentException(string.Format(InvalidNameLength, FirstNameMinLength, nameof(firstName)));
                }

                this.firstName = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"First Name: {this.firstName}");
            result.AppendLine($"Last Name: {this.lastName}");

            return result.ToString();
        }
    }
}
