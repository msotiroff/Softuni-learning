namespace P01.StudentsResults
{
    using System;

    public class StudentsResults
    {
        public static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());

            Console.WriteLine(string.Format("{0, -10}|{1, 7}|{2, 7}|{3, 7}|{4, 7}|",
                                "Name", "CAdv", "COOP", "AdvOOP", "Average"));

            for (int i = 0; i < numberOfStudents; i++)
            {
                // Input format: {name} - {firstResult}, {secondResult}, {thirdResult}
                var input = Console.ReadLine().Split(new char[] { ',', '-' }, StringSplitOptions.RemoveEmptyEntries);

                var studentName = input[0];
                var advGrade = double.Parse(input[1]);
                var oopBasicGrade = double.Parse(input[2]);
                var oopAdvGrade = double.Parse(input[3]);

                var avgGrade = (advGrade + oopBasicGrade + oopAdvGrade) / 3;

                Console.WriteLine(string.Format("{0, -10}|{1, 7:f2}|{2, 7:f2}|{3, 7:f2}|{4, 7:f4}|",
                                studentName, advGrade, oopBasicGrade, oopAdvGrade, avgGrade));
            }
        }
    }
}
