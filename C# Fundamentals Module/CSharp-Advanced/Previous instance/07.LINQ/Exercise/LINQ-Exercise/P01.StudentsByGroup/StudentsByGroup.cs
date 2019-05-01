namespace P01.StudentsByGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsByGroup
    {
        public static void Main(string[] args)
        {
            var students = new Dictionary<string, int>();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                var inputArgs = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var student = string.Join(" ", inputArgs.Take(2));
                var grade = int.Parse(inputArgs.Last());

                students[student] = grade;
            }

            foreach (var student in students.Where(s => s.Value == 2).OrderBy(s => s.Key))
            {
                Console.WriteLine(student.Key);
            }
        }
    }
}
