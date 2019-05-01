using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.MentorGroup
{
    public class Student
    {
        public string Name { get; set; }
        public List<DateTime> DatesAttended { get; set; }
        public List<string> Comments { get; set; }
    }

    class MentorGroup
    {
        static void Main(string[] args)
        {
            string nameAndDates = Console.ReadLine();

            List<Student> allSudents = new List<Student>();

            while (nameAndDates != "end of dates")
            {
                string[] datesParams = nameAndDates.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string currStudentName = datesParams[0];
                List<DateTime> currStudentDates = new List<DateTime>();
                for (int i = 1; i < datesParams.Length; i++)
                {
                    currStudentDates.Add(DateTime.ParseExact(datesParams[i], "dd/MM/yyyy", CultureInfo.InvariantCulture));
                }

                if (allSudents.Any(st => st.Name == currStudentName))
                {
                    foreach (var student in allSudents)
                    {
                        if (student.Name == currStudentName)
                        {
                            student.DatesAttended.AddRange(currStudentDates);
                        }
                    }
                }
                else
                {
                    Student currentStudent = new Student()
                    {
                        Name = currStudentName,
                        Comments = new List<string>(),
                        DatesAttended = new List<DateTime>()
                    };
                    currentStudent.DatesAttended.AddRange(currStudentDates);

                    allSudents.Add(currentStudent);
                }

                nameAndDates = Console.ReadLine();
            }

            string comment = Console.ReadLine();

            while (comment != "end of comments")
            {
                string[] commentParams = comment.Split('-');
                string name = commentParams[0];
                string currentComment = commentParams[1];

                if (allSudents.Any(st => st.Name == name))
                {
                    foreach (var student in allSudents)
                    {
                        if (student.Name == name)
                        {
                            student.Comments.Add(currentComment);
                        }
                    }
                }
                
                comment = Console.ReadLine();
            }


            foreach (var student in allSudents.OrderBy(st => st.Name))
            {
                Console.WriteLine(student.Name);
                Console.WriteLine("Comments:");
                foreach (var commentar in student.Comments)
                {
                    Console.WriteLine($"- {commentar}");
                }
                Console.WriteLine("Dates attended:");
                foreach (var date in student.DatesAttended.OrderBy(d => d))
                {
                    Console.WriteLine($"-- {date.ToString("dd/MM/yyyy")}");
                }
            }

        }
    }
}
