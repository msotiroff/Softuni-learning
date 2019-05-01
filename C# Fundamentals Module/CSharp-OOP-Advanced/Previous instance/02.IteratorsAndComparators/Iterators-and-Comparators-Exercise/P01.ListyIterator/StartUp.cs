using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var listyIterator = new ListyIterator<string>();

        string inputLine;
        while ((inputLine = Console.ReadLine()) != "END")
        {
            var command = inputLine.Split();

            var commandName = command.First();
            var commandArgs = command.Skip(1).ToArray();

            var result = string.Empty;

            switch (commandName)
            {
                case "Create":
                    listyIterator.Create(commandArgs);
                    break;
                case "Move":
                    result = listyIterator.Move().ToString();
                    break;
                case "Print":
                    result = listyIterator.Print();
                    break;
                case "HasNext":
                    result = listyIterator.HasNext().ToString();
                    break;
                default:
                    break;
            }

            if (result != string.Empty)
            {
                Console.WriteLine(result);
            }
        }
    }
}
