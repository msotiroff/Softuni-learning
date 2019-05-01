namespace P03.Mankind.Models
{
    using System;
    using static Common.Constants;

    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber) 
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get => this.facultyNumber;

            private set
            {
                if (value.Length < FacultyNumberMinimum || value.Length > FacultyNumberMaximum)
                {
                    throw new ArgumentException("Invalid faculty number!");
                    //throw new ArgumentException(InvalidFacultyNumber);
                }

                for (int i = 0; i < value.Length; i++)
                {
                    if (!Char.IsLetterOrDigit(value[i]))
                    {
                        throw new ArgumentException("Invalid faculty number!");
                        //throw new ArgumentException(InvalidFacultyNumber);
                    }
                }

                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            var result = base.ToString();

            result += $"Faculty number: {this.facultyNumber}";

            return result;
        }
    }
}
