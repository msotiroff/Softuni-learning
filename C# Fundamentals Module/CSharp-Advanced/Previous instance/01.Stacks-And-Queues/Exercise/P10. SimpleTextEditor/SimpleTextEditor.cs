namespace P10._SimpleTextEditor
{
    using System;
    using System.Collections.Generic;

    public class SimpleTextEditor
    {
        public static void Main(string[] args)
        {
            int countOfLines = int.Parse(Console.ReadLine());

            var text = string.Empty;

            var versionControl = new Stack<string>();
            versionControl.Push(text);

            for (int i = 0; i < countOfLines; i++)
            {
                string[] inputLine = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var command = inputLine[0];
                var parameter = string.Empty;
                if (inputLine.Length > 1)
                {
                    parameter = inputLine[1];
                }

                switch (command)
                {
                    case "1":
                        text = AppendCommand(parameter, text, versionControl);
                        break;
                    case "2":
                        text = EraseCommand(int.Parse(parameter), text, versionControl);
                        break;
                    case "3":
                        var result = ReturnCommand(int.Parse(parameter), text);
                        Console.WriteLine(result);
                        break;
                    case "4":
                        text = UndoCommand(text, versionControl);
                        break;
                    default:
                        break;
                }
            }
        }

        private static string UndoCommand(string text, Stack<string> versionControl)
        {
            versionControl.Pop();

            text = versionControl.Peek();

            return text;
        }

        private static string ReturnCommand(int elementNumber, string text)
        {
            var result = text[elementNumber - 1].ToString();

            return result;
        }

        private static string EraseCommand(int count, string text, Stack<string> versionControl)
        {
            var newTextLength = text.Length - count;

            text = text.Substring(0, newTextLength);

            versionControl.Push(text);

            return text;
        }

        private static string AppendCommand(string parameter, string text, Stack<string> versionControl)
        {
            text = text + parameter;

            versionControl.Push(text);

            return text;
        }
    }
}
