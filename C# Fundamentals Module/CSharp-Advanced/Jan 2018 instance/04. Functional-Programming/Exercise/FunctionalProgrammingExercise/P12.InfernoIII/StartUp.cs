namespace P12.InfernoIII
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var gems = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var allCommands = new List<string>();

            string command;
            while ((command = Console.ReadLine()) != "Forge")
            {
                var commandParams = command
                    .Split(';');

                var mainCommand = commandParams[0];
                var subCommand = commandParams[1];
                var condition = int.Parse(commandParams[2]);

                var currentCommand = $"{subCommand};{condition}";

                switch (mainCommand)
                {
                    case "Exclude":
                        allCommands.Add(currentCommand);
                        break;
                    case "Reverse":
                        var lastIndexOfGivenCommand = allCommands.LastIndexOf(currentCommand);
                        if (lastIndexOfGivenCommand != -1)
                        {
                            allCommands.RemoveAt(lastIndexOfGivenCommand);
                        }
                        break;
                    default:
                        break;
                }
            }

            var allGemsForRemove = new List<int>();

            foreach (var excludeCommand in allCommands)
            {
                var subCommand = excludeCommand.Split(';')[0];
                var condition = int.Parse(excludeCommand.Split(';')[1]);

                switch (subCommand)
                {
                    case "Sum Left":
                        allGemsForRemove.AddRange(IndecesBySumLeft(gems, condition));
                        break;
                    case "Sum Right":
                        allGemsForRemove.AddRange(IndecesBySumRight(gems, condition));
                        break;
                    case "Sum Left Right":
                        allGemsForRemove.AddRange(IndecesByLeftAndRight(gems, condition));
                        break;
                    default:
                        break;
                }
            }

            allGemsForRemove = allGemsForRemove.Distinct().ToList();

            var result = new List<int>();

            for (int i = 0; i < gems.Length; i++)
            {
                if (!allGemsForRemove.Contains(i))
                {
                    result.Add(gems[i]);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }

        private static HashSet<int> IndecesByLeftAndRight(int[] gems, int condition)
        {
            var result = new HashSet<int>();

            for (int i = 0; i < gems.Length; i++)
            {
                var leftElement = i == 0 ? 0 : gems[i - 1];
                int rightElement = i == gems.Length - 1 ? 0 : gems[i + 1];

                var currentSum = leftElement + gems[i] + rightElement;

                if (currentSum == condition)
                {
                    result.Add(i);
                }
            }

            return result;
        }

        private static HashSet<int> IndecesBySumRight(int[] gems, int condition)
        {
            var result = new HashSet<int>();

            for (int i = 0; i < gems.Length; i++)
            {
                int rightElement = i == gems.Length - 1 ? 0 : gems[i + 1];
                var currentSum = gems[i] + rightElement;

                if (currentSum == condition)
                {
                    result.Add(i);
                }
            }

            return result;
        }

        private static HashSet<int> IndecesBySumLeft(int[] gems, int condition)
        {
            var result = new HashSet<int>();

            for (int i = 0; i < gems.Length; i++)
            {
                var leftElement = i == 0 ? 0 : gems[i - 1];
                var currentSum = leftElement + gems[i];

                if (currentSum == condition)
                {
                    result.Add(i);
                }
            }

            return result;
        }
    }
}
