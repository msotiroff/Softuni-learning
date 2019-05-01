namespace P02.StudentsByFirsAandLastName
{
    internal class Student
    {
        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
