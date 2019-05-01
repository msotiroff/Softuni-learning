using System;
using System.Linq;

public class StartUp
{
    public static void Main(string[] args)
    {
        var stack = new Stack<string>();

        string inputLine;
        while ((inputLine  = Console.ReadLine()) != "END")
        {
            var inputParams = inputLine.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            var mainCommand = inputParams[0];
            var commandParams = inputParams.Skip(1).ToArray();

            try
            {
                switch (mainCommand)
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
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
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
