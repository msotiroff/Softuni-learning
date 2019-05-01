namespace P05.FilterStudentsByEmailDomain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FilterStudentsByEmailDomain
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
                var email = inputArgs[2];

                allStudents.Add(new Student(firstName, lastName, email));
            }

            allStudents
                .Where(s => s.Email.Split('@').Last() == "gmail.com")
                .ToList()
                .ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName}"));
        }
    }
}
