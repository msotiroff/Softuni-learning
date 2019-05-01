namespace P09.LinkedListTraversal
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var list = new LinkedList<int>();

            var commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                var parameters = Console.ReadLine().Split();
                var command = parameters.First();
                var value = int.Parse(parameters.Last());

                switch (command)
                {
                    case "Add":
                        list.Add(value);
                        break;
                    case "Remove":
                        list.Remove(value);
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(list.Count);
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
