using System;
using System.Linq;

public class StartUp
{
    public static void Main(string[] args)
    {
        var myList = new MyList<string>();

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            var commandParams = command.Split();

            switch (commandParams[0])
            {
                case "Add":
                    myList.Add(commandParams[1]);
                    break;
                case "Remove":
                    myList.Remove(int.Parse(commandParams[1]));
                    break;
                case "Contains":
                    Console.WriteLine(myList.Contains(commandParams[1]));
                    break;
                case "Swap":
                    myList.Swap(int.Parse(commandParams[1]), int.Parse(commandParams[2]));
                    break;
                case "Greater":
                    Console.WriteLine(myList.CountGreaterThan(commandParams[1]));
                    break;
                case "Max":
                    Console.WriteLine(myList.Max());
                    break;
                case "Min":
                    Console.WriteLine(myList.Min());
                    break;
                case "Print":
                    Console.WriteLine(myList);
                    break;
                default:
                    break;
            }
        }
    }
}