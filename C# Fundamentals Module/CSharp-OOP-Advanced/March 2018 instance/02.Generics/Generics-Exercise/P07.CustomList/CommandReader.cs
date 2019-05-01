using System;
using System.Linq;

internal class CommandReader
{
    private CustomList<string> elements;

    public CommandReader(CustomList<string> elements)
    {
        this.elements = elements;
    }

    public void StartReadingCommands()
    {
        while (true)
        {
            var result = string.Empty;

            var commandLine = Console.ReadLine().Split();

            var mainCommand = commandLine.First();

            var commandArgs = commandLine.Skip(1).ToArray();

            switch (mainCommand)
            {
                case "":

                    break;
                case "Add":
                    this.elements.Add(commandArgs[0]);
                    break;
                case "Remove":
                    this.elements.Remove(int.Parse(commandArgs[0]));
                    break;
                case "Contains":
                    result = this.elements.Contains(commandArgs[0]).ToString();
                    break;
                case "Swap":
                    this.elements.Swap(int.Parse(commandArgs[0]), int.Parse(commandArgs[1]));
                    break;
                case "Greater":
                    result = this.elements.CountGreaterThan(commandArgs[0]).ToString();
                    break;
                case "Max":
                    result = this.elements.Max();
                    break;
                case "Min":
                    result = this.elements.Min();
                    break;
                case "Sort":
                    this.elements = Sorter.Sort(this.elements);
                    break;
                case "Print":
                    result = this.elements.ToString();
                    break;
                case "END":
                    Environment.Exit(0);
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