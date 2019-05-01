namespace P03.Mankind
{
    using Models;
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var studentParams = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var workerParams = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                var student = new Student(studentParams[0], studentParams[1], studentParams[2]);
                var worker = new Worker(workerParams[0], workerParams[1], decimal.Parse(workerParams[2]), double.Parse(workerParams[3]));

                Console.WriteLine(student);
                Console.WriteLine();
                Console.WriteLine(worker);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetBaseException().Message);
            }
        }
    }
}
