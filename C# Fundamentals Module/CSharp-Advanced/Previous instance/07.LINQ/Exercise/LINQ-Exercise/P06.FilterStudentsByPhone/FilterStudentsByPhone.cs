namespace P06.FilterStudentsByPhone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FilterStudentsByPhone
    {
        public static void Main(string[] args)
        {
            var allStudents = new List<Student>();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                var inputArgs = inputLine
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var firstName = inputArgs[0];
                var lastName = inputArgs[1];
                var phone = inputArgs[2];

                allStudents.Add(new Student(firstName, lastName, phone));
            }

            allStudents
                .Where(s => s.Phone.StartsWith("02") || s.Phone.StartsWith("+3592"))
                .ToList()
                .ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName}"));
        }
    }
}
