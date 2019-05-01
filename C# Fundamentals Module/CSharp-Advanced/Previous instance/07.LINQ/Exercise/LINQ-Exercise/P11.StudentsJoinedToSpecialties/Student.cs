namespace P11.StudentsJoinedToSpecialties
{
    internal class Student
    {
        public Student(string name, string facNumber)
        {
            this.StudentName = name;
            this.FacultyNumber = facNumber;
        }

        public string StudentName { get; set; }

        public string FacultyNumber { get; set; }
    }
}
