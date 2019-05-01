using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CommandInterpreter
{
    class CommandInterpreter
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandParameters = command.Split(' ');
                string mainCommand = commandParameters[0];

                if (mainCommand == "reverse")
                {
                    int startIndex = int.Parse(commandParameters[2]);
                    int count = int.Parse(commandParameters[4]);
                    if (startIndex < 0 || startIndex > elements.Count - 1)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        command = Console.ReadLine();
                        continue;
                    }
                    if (count < 0 || startIndex + count > elements.Count)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        command = Console.ReadLine();
                        continue;
                    }

                    List<string> toReverce = elements.Skip(startIndex).Take(count).Reverse().ToList();
                    List<string> sequenceBegining = elements.Take(startIndex).ToList();
                    List<string> sequenceEnd = elements.Skip(startIndex + count).ToList();

                    elements = sequenceBegining.Concat(toReverce).Concat(sequenceEnd).ToList();
                }
                else if (mainCommand == "sort")
                {
                    int startIndex = int.Parse(commandParameters[2]);
                    int count = int.Parse(commandParameters[4]);
                    if (startIndex < 0 || startIndex > elements.Count - 1)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        command = Console.ReadLine();
                        continue;
                    }
                    if (count < 0 || startIndex + count > elements.Count)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        command = Console.ReadLine();
                        continue;
                    }

                    List<string> toSort = elements.Skip(startIndex).Take(count).OrderBy(x => x).ToList();
                    List<string> sequenceBegining = elements.Take(startIndex).ToList();
                    List<string> sequenceEnd = elements.Skip(startIndex + count).ToList();

                    elements = sequenceBegining.Concat(toSort).Concat(sequenceEnd).ToList();
                }
                else if (mainCommand == "rollLeft")
                {
                    int count = int.Parse(commandParameters[1]);
                    if (count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        command = Console.ReadLine();
                        continue;
                    }

                    for (int i = 0; i < count % elements.Count; i++)
                    {
                        string firstElement = elements[0];
                        elements.Add(firstElement);
                        elements.RemoveAt(0);                        
                    }
                }
                else if (mainCommand == "rollRight")
                {
                    int count = int.Parse(commandParameters[1]);
                    if (count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        command = Console.ReadLine();
                        continue;
                    }

                    for (int i = 0; i < count % elements.Count; i++)
                    {
                        string lastElement = elements.Last();
                        elements.RemoveAt(elements.Count - 1);
                        elements.Insert(0, lastElement);
                    }
                }


                command = Console.ReadLine();
            }

            Console.WriteLine("[{0}]", string.Join(", ", elements));
        }
    }
}
