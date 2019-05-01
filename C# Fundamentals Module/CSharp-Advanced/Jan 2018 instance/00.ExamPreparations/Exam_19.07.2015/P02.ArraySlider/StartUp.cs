namespace P02.ArraySlider
{
    using System;
    using System.Linq;
    using System.Numerics;

    class StartUp
    {
        static void Main(string[] args)
        {
            var sequence = Console.ReadLine()
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(BigInteger.Parse)
                .ToArray();

            int sequenceLength = sequence.Length;

            int currentIndex = 0;

            string command;
            while ((command = Console.ReadLine()) != "stop")
            {
                var commandParams = command.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                var offset = int.Parse(commandParams[0]) % sequenceLength;
                var operation = commandParams[1];
                var operand = int.Parse(commandParams[2]);

                if (offset < 0)
                {
                    offset += sequenceLength;
                }

                currentIndex = (currentIndex + offset) % sequenceLength;

                switch (operation)
                {
                    case "&":
                        sequence[currentIndex] &= operand;
                        break;
                    case "|":
                        sequence[currentIndex] |= operand;
                        break;
                    case "^":
                        sequence[currentIndex] ^= operand;
                        break;
                    case "+":
                        sequence[currentIndex] += operand;
                        break;
                    case "-":
                        sequence[currentIndex] = sequence[currentIndex] - operand;
                        break;
                    case "*":
                        sequence[currentIndex] *= operand;
                        break;
                    case "/":
                        sequence[currentIndex] /= operand;
                        break;
                    default:
                        break;
                }

                if (sequence[currentIndex] < 0)
                {
                    sequence[currentIndex] = 0;
                }
            }

            Console.WriteLine("[{0}]", string.Join(", ", sequence));
        }
    }
}
