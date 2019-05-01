using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var stack = new MyStack<string>();

        string inputLine;
        while ((inputLine = Console.ReadLine()) != "END")
        {
            try
            {
                var commandSplitted = inputLine.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                var command = commandSplitted.First();
                var commandParams = commandSplitted.Skip(1).ToArray();

                switch (command)
                {
                    case "Push":
                        stack.Push(commandParams);
                        break;
                    case "Pop":
                        stack.Pop();
                        break;
                    default:
                        break;
                }
            }
            catch (InvalidOperationException oe)
            {
                Console.WriteLine(oe.Message);
            }
        }

        for (int i = 0; i < 2; i++)
        {
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
