namespace P11.StudentsJoinedToSpecialties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsJoinedToSpecialties
    {
        public static void Main(string[] args)
        {
            var allSpecialities = new HashSet<StudentSpecialty>();
            var allStudents = new HashSet<Student>();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "Students:")
            {
                var inputParams = inputLine
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var facultyNumber = inputParams.Last();
                var specialityName = inputLine.Replace(facultyNumber, string.Empty).Trim();

                allSpecialities.Add(new StudentSpecialty(specialityName, facultyNumber));
            }

            while ((inputLine = Console.ReadLine()) != "END")
            {
                var inputParams = inputLine
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var facultyNumber = inputParams.First();
                var name = inputLine.Replace(facultyNumber, string.Empty).Trim();

                allStudents.Add(new Student(name, facultyNumber));
            }

            var result = allStudents
                .Join(allSpecialities,
                        stud => stud.FacultyNumber,
                        spec => spec.FacultyNumber,
                        (stud, spec) => new
                        {
                            StudentName = stud.StudentName,
                            FacultyNumber = stud.FacultyNumber,
                            Speciality = spec.SpecialityName
                        })
                        .OrderBy(a => a.StudentName)
                        .ToList();

            result
                .ForEach(a => Console.WriteLine($"{a.StudentName} {a.FacultyNumber} {a.Speciality}"));
        }
    }
}
