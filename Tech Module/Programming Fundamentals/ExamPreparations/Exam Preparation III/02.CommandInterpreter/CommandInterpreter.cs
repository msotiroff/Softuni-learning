using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.CommandInterpreter
{
    class CommandInterpreter
    {
        static void Main(string[] args)
        {
            List<string> userInput = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandParameters = command.Split(' ').ToArray();

                string currentCommand = commandParameters[0];

                if (currentCommand == "reverse")
                {
                    int startIndex = int.Parse(commandParameters[2]);
                    if (startIndex < 0 || startIndex > userInput.Count - 1)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        command = Console.ReadLine();
                        continue;
                    }
                    int count = int.Parse(commandParameters[4]);
                    if (startIndex + count > userInput.Count || count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        command = Console.ReadLine();
                        continue;
                    }

                    List<string> leftPart = userInput.Take(startIndex).ToList();
                    List<string> toReverse = userInput.Skip(startIndex).Take(count).Reverse().ToList();
                    List<string> rightPart = userInput.Skip(startIndex + count).ToList();

                    userInput = leftPart.Concat(toReverse).Concat(rightPart).ToList();
                }
                else if (currentCommand == "sort")
                {
                    int startIndex = int.Parse(commandParameters[2]);
                    if (startIndex < 0 || startIndex > userInput.Count - 1)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        command = Console.ReadLine();
                        continue;
                    }
                    int count = int.Parse(commandParameters[4]);
                    if (startIndex + count > userInput.Count || count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        command = Console.ReadLine();
                        continue;
                    }

                    List<string> leftPart = userInput.Take(startIndex).ToList();
                    List<string> toSort = userInput.Skip(startIndex).Take(count).OrderBy(x => x).ToList();
                    List<string> rightPart = userInput.Skip(startIndex + count).ToList();

                    userInput = leftPart.Concat(toSort).Concat(rightPart).ToList();
                }
                else if (currentCommand == "rollLeft")
                {
                    int count = int.Parse(commandParameters[1]);
                    if (count >= 0)
                    {
                        for (int i = 0; i < count % userInput.Count; i++)
                        {
                            string firstElement = userInput[0];
                            userInput.Add(firstElement);
                            userInput.RemoveAt(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                        command = Console.ReadLine();
                        continue;
                    }
                }
                else if (currentCommand == "rollRight")
                {
                    int count = int.Parse(commandParameters[1]);
                    if (count >= 0)
                    {
                        for (int i = 0; i < count % userInput.Count; i++)
                        {
                            string lastElement = userInput[userInput.Count - 1];
                            userInput.RemoveAt(userInput.Count - 1);
                            userInput.Insert(0, lastElement);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                        command = Console.ReadLine();
                        continue;
                    }
                }

                command = Console.ReadLine();
            }


            Console.WriteLine("[{0}]", string.Join(", ", userInput));
        }

        
    }
}
