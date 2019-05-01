namespace P07.ExcellentStudents
{
    internal class Student
    {
        public Student(string firstName, string lastName, double[] grades)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grades = grades;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double[] Grades { get; set; }
    }
}
