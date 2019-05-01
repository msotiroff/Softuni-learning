using System;
using System.Linq;

namespace _02.Ladybugs
{
    class Ladybugs
    {
        static void Main(string[] args)
        {
            int sizeOfField = int.Parse(Console.ReadLine());
            int[] ladybugsIndexes = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            string[] allFields = new string[sizeOfField];

            FillAllFields(ladybugsIndexes, allFields);

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandParameters = command.Split(' ');
                int startIndex = int.Parse(commandParameters[0]);
                string direction = commandParameters[1];
                int jumpPower = int.Parse(commandParameters[2]);

                if (startIndex < 0 || startIndex > allFields.Length - 1)
                {
                    command = Console.ReadLine();
                    continue;
                }
                if (allFields[startIndex] == "0")
                {
                    command = Console.ReadLine();
                    continue;
                }

                int currentPosition = startIndex;
                allFields[startIndex] = "0";

                while (true)
                {
                    if (direction == "right")
                    {
                        currentPosition += jumpPower;
                    }
                    else if (direction == "left")
                    {
                        currentPosition -= jumpPower;
                    }

                    if (currentPosition < 0 || currentPosition >= sizeOfField)
                    {
                        break;
                    }
                    if (allFields[currentPosition] == "1")
                    {
                        continue;
                    }
                    else
                    {
                        allFields[currentPosition] = "1";
                        break;
                    }
                }


                command = Console.ReadLine();
            }


            Console.WriteLine(string.Join(" ", allFields));

        }

        public static void FillAllFields(int[] ladybugsIndexes, string[] allFields)
        {
            for (int i = 0; i < allFields.Length; i++)
            {
                if (ladybugsIndexes.Contains(i))
                {
                    allFields[i] = "1";
                }
                else
                {
                    allFields[i] = "0";
                }
            }
        }
    }
}
