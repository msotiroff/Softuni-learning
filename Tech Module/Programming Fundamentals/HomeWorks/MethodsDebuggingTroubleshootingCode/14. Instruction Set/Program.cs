using System;
using System.Linq;

class InstructionSet_broken
{
    static void Main()
    {
        string inputLine = Console.ReadLine();

        

        while (inputLine != "END")
        {
            string[] inputParameters = inputLine.Split(' ').ToArray();

            long result = 0;

            switch (inputParameters[0])
            {
                case "INC":
                    {
                        long operandOne = long.Parse(inputParameters[1]);
                        result = operandOne + 1;
                        break;
                    }
                case "DEC":
                    {
                        long operandOne = long.Parse(inputParameters[1]);
                        result = operandOne - 1;
                        break;
                    }
                case "ADD":
                    {
                        long operandOne = long.Parse(inputParameters[1]);
                        long operandTwo = long.Parse(inputParameters[2]);
                        result = operandOne + operandTwo;
                        break;
                    }
                case "MLA":
                    {
                        long operandOne = long.Parse(inputParameters[1]);
                        long operandTwo = long.Parse(inputParameters[2]);
                        result = operandOne * operandTwo;
                        break;
                    }
            }
            Console.WriteLine(result);
            inputLine = Console.ReadLine();
        }

        
    }
}