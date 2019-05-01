namespace P10.SimpleTextEditor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SimpleTextEditor
    {
        private static string text;
        private static Stack<string> versionControl;

        static void Main(string[] args)
        {
            text = string.Empty;
            versionControl = new Stack<string>();

            versionControl.Push(text);

            int countOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfInputs; i++)
            {
                var command = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var mainCommand = command.First();

                switch (mainCommand)
                {
                    case "1":
                        var stringToBeAppended = command.Last();
                        text = text + stringToBeAppended;
                        versionControl.Push(text);
                        break;
                    case "2":
                        var countOfSymbolsToBeDeleted = int.Parse(command.Last());
                        var newTextLength = text.Length - countOfSymbolsToBeDeleted;

                        text = text.Substring(0, newTextLength);
                        versionControl.Push(text);

                        break;
                    case "3":
                        var index = int.Parse(command.Last()) - 1;
                        Console.WriteLine(text[index]);
                        break;
                    case "4":
                        versionControl.Pop();
                        text = versionControl.Peek();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
