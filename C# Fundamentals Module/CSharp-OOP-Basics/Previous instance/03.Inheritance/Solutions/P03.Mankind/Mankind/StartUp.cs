namespace Mankind
{
    using Models;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var studentParams = Console.ReadLine().Split();
            var workerParams = Console.ReadLine().Split();

            try
            {
                var student = new Student(studentParams[0], studentParams[1], studentParams[2]);
                var worker = new Worker(workerParams[0], workerParams[1], decimal.Parse(workerParams[2]), decimal.Parse(workerParams[3]));

                Console.WriteLine(student);
                Console.WriteLine(worker);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
