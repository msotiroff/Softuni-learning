namespace P09.StudentsEnrolledIn2014or2015
{
    internal class Student
    {
        public Student(string facultyNumber, int[] grades)
        {
            FacultyNumber = facultyNumber;
            Grades = grades;
        }

        public string FacultyNumber { get; set; }

        public int[] Grades { get; set; }
    }
}
