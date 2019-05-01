using System;

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
        get { return this.facultyNumber; }
        private set
        {
            if (value.Length < 5 || value.Length > 10)
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            for (int i = 0; i < value.Length; i++)
            {
                if (!Char.IsLetterOrDigit(value[i]))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
            }
            this.facultyNumber = value;
        }
    }
}