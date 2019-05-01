namespace P06.FilterStudentsByPhone
{
    internal class Student
    {
        public Student(string firstName, string lastName, string phone)
        {
           this.FirstName = firstName;
           this.LastName = lastName;
           this.Phone = phone;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }
    }
}
