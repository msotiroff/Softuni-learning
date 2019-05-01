namespace P11.StudentsJoinedToSpecialties
{
    internal class StudentSpecialty
    {
        public StudentSpecialty(string specialityName, string facNumber)
        {
            this.SpecialityName = specialityName;
            this.FacultyNumber = facNumber;
        }

        public string SpecialityName { get; set; }

        public string FacultyNumber { get; set; }
    }
}
