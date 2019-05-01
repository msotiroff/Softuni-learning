using System;
using System.Linq;

public class StartUp
{
    public static void Main(string[] args)
    {
        ListyIterator<string> listyOperator = null;

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            var commandParams = command.Split().ToList();

            var mainCommand = commandParams[0];
            var commandArgs = commandParams.Skip(1).ToArray();

            try
            {
                switch (mainCommand)
                {
                    case "Create":
                        listyOperator = new ListyIterator<string>(commandArgs);
                        break;
                    case "Move":
                        Console.WriteLine(listyOperator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(listyOperator.HasNext);
                        break;
                    case "Print":
                        Console.WriteLine(listyOperator.Print());
                        break;
                    default:
                        break;
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
