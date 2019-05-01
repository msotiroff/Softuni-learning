namespace P03_StudentSystem
{
    using Core;
    using Repositories;
    using System;

    class StartUp
    {
        static void Main()
        {
            StudentRepository studentRepository = new StudentRepository();
            CommandParser commandParser = new CommandParser(studentRepository);

            while (true)
            {
                var commandArgs = Console.ReadLine().Split();

                var result = commandParser.ParseCommand(commandArgs);

                if (result != string.Empty)
                {
                    Console.WriteLine(result);
                }
            }
        }
    }
}
